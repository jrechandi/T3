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
    public partial class Frm_ComplementoLibroCompras : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        readonly string _Str_TipoDocFACT, _Str_TipoDocNC, _Str_TipoDocND, _Str_TipoDocNCP, _Str_TipoDocNDP;
        readonly bool _Bol_PuedeCargar = false, _Bol_PuedeAprobar = false;
        public Frm_ComplementoLibroCompras(bool _P_Bol_PorAprobar)
        {
            InitializeComponent();
            _Mtd_CargarTipoProv(_Cmb_TipoProv);
            _Mtd_Color_Estandar(this);
            var _Dt = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtp_Desde.Value = new DateTime(_Dt.Year, _Dt.Month, 1);
            _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Cls_VariosMetodos._Mtd_Inyeccion_Sql(this, true);
            //-----------------
            string _Str_Cadena = "SELECT ctipdocfact,ctipodocnd,ctipodocndp,ctipodocnc,ctipodocncp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_TipoDocFACT = _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim();
            _Str_TipoDocND = _Ds.Tables[0].Rows[0]["ctipodocnd"].ToString().Trim();
            _Str_TipoDocNDP = _Ds.Tables[0].Rows[0]["ctipodocndp"].ToString().Trim();
            _Str_TipoDocNC = _Ds.Tables[0].Rows[0]["ctipodocnc"].ToString().Trim();
            _Str_TipoDocNCP = _Ds.Tables[0].Rows[0]["ctipodocncp"].ToString().Trim();
            //-----------------
            _Mtd_CargarTipoDocument(_Cmb_TipoDocumento);
            _Bol_PuedeCargar = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CARGA_LIBROCOMPRAS");
            _Bol_PuedeAprobar = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_LIBROCOMPRAS");
            if (_P_Bol_PorAprobar)
                _Rb_PorAprobar.Checked = true;
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

        private void _Mtd_ConfigurarControles()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Bol_PuedeCargar;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            if (_Dtp_FechaRegistro.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }
            else if (_Tb_Tab.SelectedIndex == 1)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = _Bol_PuedeAprobar;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }
        }

        private void _Mtd_CargarTipoProv(ComboBox _P_Cmb_TipoProv)
        {
            _Cmb_TipoProv.SelectedIndexChanged -= new EventHandler(_Cmb_TipoProv_SelectedIndexChanged);
            _Cmb_TipoProvD.SelectedIndexChanged -= new EventHandler(_Cmb_TipoProvD_SelectedIndexChanged);
            //--------------
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmb_TipoProv.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _P_Cmb_TipoProv.DataSource = _myArrayList;
            _P_Cmb_TipoProv.DisplayMember = "Display";
            _P_Cmb_TipoProv.ValueMember = "Value";
            _P_Cmb_TipoProv.SelectedValue = "nulo";
            _P_Cmb_TipoProv.DataSource = _myArrayList;
            //--------------
            _Cmb_TipoProv.SelectedIndexChanged += new EventHandler(_Cmb_TipoProv_SelectedIndexChanged);
            _Cmb_TipoProvD.SelectedIndexChanged += new EventHandler(_Cmb_TipoProvD_SelectedIndexChanged);
        }

        private void _Mtd_CargarCategProv(ComboBox _P_Cmb_CategProv, ComboBox _P_Cmb_TipoProv)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_P_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _P_Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cmb_CategProv.SelectedIndexChanged -= new EventHandler(_Cmb_CategProv_SelectedIndexChanged);
            _Cmb_CategProvD.SelectedIndexChanged -= new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_CategProv, _Str_Cadena);
            _Cmb_CategProv.SelectedIndexChanged += new EventHandler(_Cmb_CategProv_SelectedIndexChanged);
            _Cmb_CategProvD.SelectedIndexChanged += new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarProvee(ComboBox _P_Cmb_Proveedor, ComboBox _P_Cmb_CategProv, ComboBox _P_Cmb_TipoProv, bool _P_Bol_Historico)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_P_Cmb_TipoProv.SelectedIndex > 0)
            {
                if (_P_Cmb_TipoProv.SelectedValue.ToString().Trim() == "0" | _P_Cmb_TipoProv.SelectedValue.ToString().Trim() == "2")
                { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _P_Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
                else
                { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _P_Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            }
            else
            { _Str_Cadena += " AND ((TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1') OR (TPROVEEDOR.cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //-----------
            if (_P_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _P_Cmb_CategProv.SelectedValue.ToString().Trim() + "'"; }
            if (_P_Bol_Historico)
            {
                _Str_Cadena += " UNION ";
                _Str_Cadena += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer ";
                _Str_Cadena += " FROM TPROVEEDOR INNER JOIN ";
                _Str_Cadena += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
                _Str_Cadena += " WHERE ";
                _Str_Cadena += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            }
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_comer";
            //No hace falta colocar el combo _Cmb_Proveedor porque no tiene el evento SelectedIndexChanged
            _Cmb_ProveedorD.SelectedIndexChanged -= new EventHandler(_Cmb_ProveedorD_SelectedIndexChanged);
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Proveedor, _Str_Cadena);
            _Cmb_ProveedorD.SelectedIndexChanged += new EventHandler(_Cmb_ProveedorD_SelectedIndexChanged);
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarTipoDocument(ComboBox _P_Cmb_TipoDocumento)
        {
            _Cmb_TipoDocumentoD.SelectedIndexChanged -= new EventHandler(_Cmb_TipoDocumentoD_SelectedIndexChanged);
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_TipoDocumento, "SELECT ctdocument,cname FROM TDOCUMENT where ctdocument in ('" +
                                    _Str_TipoDocFACT + "','" + _Str_TipoDocND + "','" + _Str_TipoDocNDP + "','" + _Str_TipoDocNC + "'" +
                                    ",'" + _Str_TipoDocNCP + "')");
            _Cmb_TipoDocumentoD.SelectedIndexChanged += new EventHandler(_Cmb_TipoDocumentoD_SelectedIndexChanged);
        }

        private void _Mtd_CargarTipoTransaccion()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoTransaccion.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("01", "01"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("02", "02"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("03", "03"));
            _Cmb_TipoTransaccion.DataSource = _myArrayList;
            _Cmb_TipoTransaccion.DisplayMember = "Display";
            _Cmb_TipoTransaccion.ValueMember = "Value";
            _Cmb_TipoTransaccion.SelectedValue = "nulo";
            _Cmb_TipoTransaccion.DataSource = _myArrayList;
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            var _Str_Cadena =
                "SELECT cidcomplemento AS Complemento, c_nomb_comer AS Proveedor, convert(varchar,cfecharegistro,103) AS Fecha, cname AS [Tipo Documento], cnumdocu AS Documento, dbo.Fnc_Formatear(cbaseimponible+cbaseexenta+cimpuesto) AS Total, CASE WHEN cstatus='0' THEN 'POR APROBAR' ELSE 'APROBADO' END AS Estatus FROM TCOMPLEMENTOLCOMPRAS " +
                "INNER JOIN TPROVEEDOR ON TCOMPLEMENTOLCOMPRAS.cproveedor=TPROVEEDOR.cproveedor AND (TPROVEEDOR.cglobal='1' OR TCOMPLEMENTOLCOMPRAS.ccompany=TPROVEEDOR.ccompany) " +
                "INNER JOIN TDOCUMENT ON TCOMPLEMENTOLCOMPRAS.ctipodocumento=TDOCUMENT.ctdocument " +
                "WHERE TCOMPLEMENTOLCOMPRAS.ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfecharegistro,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "' AND TCOMPLEMENTOLCOMPRAS.cdelete='0'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
                _Str_Cadena += " AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'";
            if (_Cmb_CategProv.SelectedIndex > 0)
                _Str_Cadena += " AND ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'";
            if (_Cmb_Proveedor.SelectedIndex > 0)
                _Str_Cadena += " AND TCOMPLEMENTOLCOMPRAS.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString().Trim() + "'";
            if (_Cmb_TipoDocumento.SelectedIndex > 0)
                _Str_Cadena += " AND ctipodocumento='" + _Cmb_TipoDocumento.SelectedValue.ToString().Trim() + "'";
            if (!string.IsNullOrWhiteSpace(_Txt_Documento.Text))
                _Str_Cadena += " AND cnumdocu like '%" + _Txt_Documento.Text.Trim() + "%'";
            if (!_Rb_Todos.Checked)
                _Str_Cadena += " AND cstatus='" + Convert.ToInt32(_Rb_Aprobados.Checked) + "'";
            _Str_Cadena += " ORDER BY cidcomplemento DESC";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Mtd_HabilitarIvaCredNoComp()
        {
            _Chk_IvaCredNoCom.Checked = false;
            if (_Cmb_TipoProvD.SelectedIndex > 0 && _Cmb_CategProvD.SelectedIndex > 0 && Convert.ToString(_Cmb_TipoDocumentoD.SelectedValue).Trim() == _Str_TipoDocFACT && _Rb_ConIva.Checked)
            {
                string _Str_Cadena = "SELECT civacrednocomp FROM TCATPROVEEDOR WHERE cglobal='" + _Cmb_TipoProvD.SelectedValue.ToString().Trim() + "' AND ccatproveedor='" + _Cmb_CategProvD.SelectedValue.ToString().Trim() + "' AND civacrednocomp='1'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Chk_IvaCredNoCom.Enabled = true;
                    return;
                }
            }
            _Chk_IvaCredNoCom.Enabled = false;
        }

        private string _Mtd_ObtenerAlicuota()
        {
            string _Str_Cadena = "SELECT cpercent FROM TTAX WHERE ctax=(SELECT ctipimpuesto FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return "0"; }
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_CargarTipoProv(_Cmb_TipoProvD);
            _Cmb_CategProvD.DataSource = null;
            _Cmb_ProveedorD.DataSource = null;
            _Cmb_TipoDocumentoD.DataSource = null;
            _Cmb_TipoTransaccion.DataSource = null;
            _Mtd_InicializarFormulario();
            _Mtd_Hab_Deshab_Controles(false);
            _Dtp_FechaRegistro.Enabled = true;
            _Cmb_TipoProvD.Enabled = true;
            _Cmb_CategProvD.Enabled = false;
            _Cmb_ProveedorD.Enabled = false;
            _Tb_Tab.SelectedIndex = 1;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }

        public void _Mtd_Ini()
        {
            _Tb_Tab.SelectedIndex = 0;
        }

        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            var _Bol_Error = false;
            double _Dbl_Alicuota = 0, _Dbl_BaseImponible = 0, _Dbl_Exento = 0;
            if (_Cmb_TipoProvD.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cmb_TipoProvD, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (_Cmb_CategProvD.Enabled && _Cmb_CategProvD.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cmb_CategProvD, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (_Cmb_ProveedorD.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cmb_ProveedorD, "Información requerida!!!");
                _Bol_Error = true;
            }
            else
            {
                if (_Cmb_TipoDocumentoD.SelectedIndex <= 0)
                {
                    _Er_Error.SetError(_Cmb_TipoDocumentoD, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (_Cmb_TipoTransaccion.SelectedIndex <= 0)
                {
                    _Er_Error.SetError(_Cmb_TipoTransaccion, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_DocumentoD))
                {
                    _Er_Error.SetError(_Txt_DocumentoD, "Información requerida!!!");
                    _Bol_Error = true;
                }

                if (_Mtd_ConvertDouble(_Txt_NumCtrl.Text) == 0)
                {
                    _Er_Error.SetError(_Txt_NumCtrl, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (_Txt_DocumentAfect.Enabled && !_Mtd_VerifContTextBoxVarcharNoCero(_Txt_DocumentAfect))
                {
                    _Er_Error.SetError(_Txt_DocumentAfect, "Información requerida!!!");
                    _Bol_Error = true;
                }
                _Dbl_Exento = _Mtd_ConvertDouble(_Txt_Exento.Text);
                if (_Rb_ConIva.Checked)
                {
                    _Dbl_Alicuota = _Mtd_ConvertDouble(_Txt_Alicuota.Text);
                    if (_Dbl_Alicuota == 0)
                    {
                        _Er_Error.SetError(_Txt_Alicuota, "Información requerida!!!");
                        _Bol_Error = true;
                    }
                    _Dbl_BaseImponible = _Mtd_ConvertDouble(_Txt_BaseImponible.Text);
                    if (_Dbl_BaseImponible == 0)
                    {
                        _Er_Error.SetError(_Txt_BaseImponible, "Información requerida!!!");
                        _Bol_Error = true;
                    }
                }
                else
                {
                    if (_Dbl_Exento == 0)
                    {
                        _Er_Error.SetError(_Txt_Exento, "Información requerida!!!");
                        _Bol_Error = true;
                    }
                }
            }
            if (_Bol_Error)
                return false;
            if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                return false;
            //Comprobación del permiso hasta el último momento.
            if (!(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CARGA_LIBROCOMPRAS")))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta operación.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "INSERT INTO TCOMPLEMENTOLCOMPRAS (" +
                "ccompany" +
                ",cproveedor" +
                ",cfecharegistro" +
                ",ctipodocumento" +
                ",cnumdocu" +
                ",cnumdocuafec" +
                ",cnumcontrol" +
                ",ctipotransaccion" +
                ",cbaseimponible" +
                ",cbaseexenta" +
                ",cimpuesto" +
                ",calicuota" +
                ",civacrednocomp" +
                ",cstatus" +
                ",cdateadd" +
                ",cuseradd" +
                ",cdelete" +
                ") VALUES (" +
                "'" + Frm_Padre._Str_Comp.Trim() + "'" +
                ",'" + Convert.ToString(_Cmb_ProveedorD.SelectedValue).Trim() + "'" +
                ",'" + _Cls_Formato._Mtd_fecha(_Dtp_FechaRegistro.Value) + "'" +
                ",'" + Convert.ToString(_Cmb_TipoDocumentoD.SelectedValue).Trim() + "'" +
                ",'" + _Txt_DocumentoD.Text.Trim() + "'" +
                ",'" + _Txt_DocumentAfect.Text.Trim() + "'" +
                ",'" + _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper() + "'" +
                ",'" + Convert.ToString(_Cmb_TipoTransaccion.SelectedValue).Trim() + "'" +
                ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_BaseImponible) + "'" +
                ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Exento) + "'" +
                ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_ConvertDouble(_Txt_Impuesto.Text)) + "'" +
                ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Alicuota) + "'" +
                ",'" + Convert.ToInt32(_Chk_IvaCredNoCom.Checked) + "'" +
                ",'0'" +
                ",GETDATE()" +
                ",'" + Frm_Padre._Str_Use.Trim() + "'" +
                ",'0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                MessageBox.Show("La operación ha sido realizada correctamente.\nEl complemento ha pasado al proceso de aprobación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                _Tb_Tab.SelectedIndex = 0;
                _Mtd_Actualizar();
                return true;
            }
            catch (Exception _Ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error en la operación.\n" + _Ex.Message + "\nPor favor envíe un ticket adjuntando la imagen de este error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
                return _Str_Pref + "-" + _P_Str_NumCtrl;
            }
        }

        double _Mtd_ConvertDouble(string _P_Str_Texto)
        {
            double _Dbl_Double = 0;
            double.TryParse(_P_Str_Texto, out _Dbl_Double);
            return _Dbl_Double;
        }

        private bool _Mtd_VerifContTextBoxVarcharNoCero(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (_Cls_VariosMetodos._Mtd_IsNumeric(_P_Txt_TextBox.Text))
                {
                    if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                    { return true; }
                }
                else
                { return true; }
            }
            return false;
        }

        void _Mtd_InicializarFormulario()
        {
            _Er_Error.Dispose();
            _Txt_Complemento.Text = "";
            _Dtp_FechaRegistro.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Txt_DocumentoD.Text = "";
            _Txt_NumCtrlPref.Text = "";
            _Txt_NumCtrl.Text = "";
            _Txt_DocumentAfect.Text = "";
            _Txt_Alicuota.Text = "";
            _Chk_IvaCredNoCom.Checked = false;
            _Rb_ConIva.Checked = true;
            _Txt_Alicuota.Text = _Mtd_ObtenerAlicuota();
            _Txt_BaseImponible.Text = "";
            _Txt_Exento.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Total.Text = "";
        }

        void _Mtd_Hab_Deshab_Controles(bool _P_Bol_Valor)
        {
            _Dtp_FechaRegistro.Enabled = _P_Bol_Valor;
            _Cmb_TipoDocumentoD.Enabled = _P_Bol_Valor;
            _Cmb_TipoTransaccion.Enabled = _P_Bol_Valor;
            _Txt_DocumentoD.Enabled = _P_Bol_Valor;
            _Txt_NumCtrlPref.Enabled = _P_Bol_Valor;
            _Txt_NumCtrl.Enabled = _P_Bol_Valor;
            _Txt_DocumentAfect.Enabled = false;
            _Rb_ConIva.Enabled = _P_Bol_Valor;
            _Rb_SinIva.Enabled = _P_Bol_Valor;
            _Txt_Alicuota.Enabled = _P_Bol_Valor;
            _Chk_IvaCredNoCom.Enabled = false;
            _Txt_BaseImponible.Enabled = _P_Bol_Valor;
            _Txt_Exento.Enabled = _P_Bol_Valor;
            _Bt_Aprobar.Enabled = false;
        }

        private void _Mtd_CalularMontos()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Alicuota = 0;
            double _Dbl_Impuesto = 0;
            //------------
            double.TryParse(_Txt_BaseImponible.Text, out _Dbl_BaseImpon);
            double.TryParse(_Txt_Exento.Text, out _Dbl_MontoExcento);
            double.TryParse(_Txt_Alicuota.Text, out _Dbl_Alicuota);
            //------------
            if (_Rb_ConIva.Checked)
            {
                _Dbl_Impuesto = _Dbl_BaseImpon * _Dbl_Alicuota / 100;
                _Txt_Impuesto.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Impuesto).ToString("#,##0.00");
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto).ToString("#,##0.00");
            }
            else
            {
                _Txt_Impuesto.Text = "";
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto).ToString("#,##0.00");
            }
        }

        void _Mtd_CargarFormulario(string _P_Str_ComplementoId)
        {
            _Txt_Complemento.Text = _P_Str_ComplementoId;
            string _Str_Cadena = "SELECT cfecharegistro,TPROVEEDOR.cglobal,TPROVEEDOR.ccatproveedor,TCOMPLEMENTOLCOMPRAS.cproveedor,ctipodocumento,ctipotransaccion,cnumdocu,cnumcontrol,cnumdocuafec,calicuota,cbaseimponible,cbaseexenta,cimpuesto,civacrednocomp,cstatus " +
                                 "FROM TCOMPLEMENTOLCOMPRAS INNER JOIN TPROVEEDOR ON TCOMPLEMENTOLCOMPRAS.cproveedor=TPROVEEDOR.cproveedor AND (TPROVEEDOR.cglobal='1' OR TCOMPLEMENTOLCOMPRAS.ccompany=TPROVEEDOR.ccompany) " +
                                 "WHERE cidcomplemento='" + _P_Str_ComplementoId + "'";
            DataRow _DRow = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
            _Dtp_FechaRegistro.Value = Convert.ToDateTime(_DRow["cfecharegistro"]);
            //-------------
            _Mtd_CargarTipoProv(_Cmb_TipoProvD);
            _Cmb_TipoProvD.SelectedIndexChanged -= new EventHandler(_Cmb_TipoProvD_SelectedIndexChanged);
            _Cmb_TipoProvD.SelectedValue = _DRow["cglobal"].ToString();
            _Cmb_TipoProvD.SelectedIndexChanged += new EventHandler(_Cmb_TipoProvD_SelectedIndexChanged);
            //-------------
            _Mtd_CargarCategProv(_Cmb_CategProvD, _Cmb_TipoProvD);
            _Cmb_CategProvD.SelectedIndexChanged -= new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
            _Cmb_CategProvD.SelectedValue = _DRow["ccatproveedor"].ToString();
            _Cmb_CategProvD.SelectedIndexChanged += new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
            //-------------
            _Mtd_CargarProvee(_Cmb_ProveedorD, _Cmb_CategProvD, _Cmb_TipoProvD, false);
            _Cmb_ProveedorD.SelectedIndexChanged -= new EventHandler(_Cmb_ProveedorD_SelectedIndexChanged);
            _Cmb_ProveedorD.SelectedValue = _DRow["cproveedor"].ToString();
            _Cmb_ProveedorD.SelectedIndexChanged += new EventHandler(_Cmb_ProveedorD_SelectedIndexChanged);
            //-------------
            _Mtd_CargarTipoDocument(_Cmb_TipoDocumentoD);
            _Cmb_TipoDocumentoD.SelectedIndexChanged -= new EventHandler(_Cmb_TipoDocumentoD_SelectedIndexChanged);
            _Cmb_TipoDocumentoD.SelectedValue = _DRow["ctipodocumento"].ToString();
            _Cmb_TipoDocumentoD.SelectedIndexChanged += new EventHandler(_Cmb_TipoDocumentoD_SelectedIndexChanged);
            //-------------
            _Mtd_CargarTipoTransaccion();
            _Cmb_TipoTransaccion.SelectedValue = _DRow["ctipotransaccion"].ToString();
            _Txt_DocumentoD.Text = _DRow["cnumdocu"].ToString();
            _Txt_NumCtrlPref.Text = _DRow["cnumcontrol"].ToString().Trim().Substring(0, _DRow["cnumcontrol"].ToString().Trim().IndexOf("-"));
            _Txt_NumCtrl.Text = _DRow["cnumcontrol"].ToString().Trim().Substring(_DRow["cnumcontrol"].ToString().Trim().IndexOf("-") + 1);
            _Txt_DocumentAfect.Text=_DRow["cnumdocuafec"].ToString();
            _Chk_IvaCredNoCom.Checked = Convert.ToBoolean(Convert.ToInt32(_DRow["civacrednocomp"].ToString().Trim()));
            if (_Mtd_ConvertDouble(_DRow["calicuota"].ToString()) > 0)
            {
                _Txt_Alicuota.Text = _Mtd_ConvertDouble(_DRow["calicuota"].ToString()).ToString("#,##0.00");
                _Txt_BaseImponible.Text = _Mtd_ConvertDouble(_DRow["cbaseimponible"].ToString()).ToString("#,##0.00");
                _Txt_Impuesto.Text = _Mtd_ConvertDouble(_DRow["cimpuesto"].ToString()).ToString("#,##0.00");
            }
            else
            {
                _Rb_ConIva.CheckedChanged -= new EventHandler(_Rb_ConIva_CheckedChanged);
                _Rb_SinIva.Checked = true;
                _Rb_ConIva.CheckedChanged += new EventHandler(_Rb_ConIva_CheckedChanged);
            }
            _Txt_Exento.Text = _Mtd_ConvertDouble(_DRow["cbaseexenta"].ToString()).ToString("#,##0.00");
            _Bt_Aprobar.Enabled = _Bol_PuedeAprobar && _DRow["cstatus"].ToString().Trim() == "0";
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = _Bol_PuedeAprobar;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }

        public bool _Mtd_Eliminar()
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el complemento selecciondo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                return false;
            if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                return false;
            //Comprobación del permiso hasta el último momento.
            if (!(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_LIBROCOMPRAS")))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta operación.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "UPDATE TCOMPLEMENTOLCOMPRAS SET cdelete='1',cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use.Trim() + "' WHERE cidcomplemento='" + _Txt_Complemento.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            Cursor = Cursors.Default;
            MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_Actualizar();
            return true;
        }

        void _Mtd_Aprobar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "UPDATE TCOMPLEMENTOLCOMPRAS SET cstatus='1',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use.Trim() + "' WHERE cidcomplemento='" + _Txt_Complemento.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            Cursor = Cursors.Default;
            MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_Actualizar();
        }

        private void Frm_ComplementoLibroCompras_Activated(object sender, EventArgs e)
        {
            _Mtd_ConfigurarControles();
        }

        private void Frm_ComplementoLibroCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ComplementoLibroCompras_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Actualizar();
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_TipoProv.SelectedValue).Trim() == "1")
            {
                _Cmb_CategProv.DataSource = null;
                _Mtd_CargarProvee(_Cmb_Proveedor, _Cmb_CategProv, _Cmb_TipoProv, true);
                _Cmb_CategProv.Enabled = false;
            }
            else if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                _Mtd_CargarCategProv(_Cmb_CategProv, _Cmb_TipoProv);
                _Cmb_Proveedor.DataSource = null;
                _Cmb_CategProv.Enabled = true;
            }
            else
            {
                _Cmb_CategProv.DataSource = null;
            }
            _Dg_Grid.DataSource = null;
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarProvee(_Cmb_Proveedor, _Cmb_CategProv, _Cmb_TipoProv, true);
            _Dg_Grid.DataSource = null;
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee(_Cmb_Proveedor, _Cmb_CategProv, _Cmb_TipoProv, true);
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_InicializarFormulario();
                _Mtd_Hab_Deshab_Controles(false);
                _Cmb_TipoProvD.Enabled = false;
                _Cmb_CategProvD.Enabled = false;
                _Cmb_ProveedorD.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else if (!_Dtp_FechaRegistro.Enabled)
                e.Cancel = true;
        }

        private void _Cmb_TipoProvD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim() == "1")
            {
                _Cmb_CategProvD.DataSource = null;
                _Mtd_CargarProvee(_Cmb_ProveedorD, _Cmb_CategProvD, _Cmb_TipoProvD, false);
                _Cmb_CategProvD.Enabled = false;
                _Cmb_ProveedorD.Enabled = true;
            }
            else if (_Cmb_TipoProvD.SelectedIndex > 0)
            {
                _Mtd_CargarCategProv(_Cmb_CategProvD, _Cmb_TipoProvD);
                _Cmb_ProveedorD.DataSource = null;
                _Cmb_CategProvD.Enabled = true;
                _Cmb_ProveedorD.Enabled = false;
            }
            else
            {
                _Cmb_CategProvD.DataSource = null;
                _Cmb_ProveedorD.DataSource = null;
                _Cmb_CategProvD.Enabled = false;
                _Cmb_ProveedorD.Enabled = false;
            }
            _Cmb_TipoDocumentoD.DataSource = null;
            _Cmb_TipoTransaccion.DataSource = null;
            _Mtd_InicializarFormulario();
            _Mtd_Hab_Deshab_Controles(false);
        }

        private void _Cmb_CategProvD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CategProvD.SelectedIndex > 0)
                _Mtd_CargarProvee(_Cmb_ProveedorD, _Cmb_CategProvD, _Cmb_TipoProvD, false);
            else
                _Cmb_ProveedorD.DataSource = null;
            _Cmb_ProveedorD.Enabled = _Cmb_CategProvD.SelectedIndex > 0;
            //-------------------
            _Cmb_TipoDocumentoD.DataSource = null;
            _Cmb_TipoTransaccion.DataSource = null;
            _Mtd_InicializarFormulario();
            _Mtd_Hab_Deshab_Controles(false);
            //-------------------
        }

        private void _Cmb_ProveedorD_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee(_Cmb_ProveedorD, _Cmb_CategProvD, _Cmb_TipoProvD, false);
        }

        private void _Cmb_ProveedorD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_ProveedorD.SelectedIndex > 0)
            {
                _Mtd_CargarTipoDocument(_Cmb_TipoDocumentoD);
                _Mtd_CargarTipoTransaccion();
            }
            else
            {
                _Cmb_TipoDocumentoD.DataSource = null;
                _Cmb_TipoTransaccion.DataSource = null;
            }
            _Mtd_InicializarFormulario();
            _Mtd_Hab_Deshab_Controles(_Cmb_ProveedorD.SelectedIndex > 0);
        }

        private void _Txt_BaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_BaseImponible, e, 15, 2);
        }

        private void _Txt_BaseImponible_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_BaseImponible.Text)) { _Txt_BaseImponible.Text = ""; }
            _Mtd_CalularMontos();
        }

        private void _Txt_Exento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Exento, e, 15, 2);
        }

        private void _Txt_Exento_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Exento.Text)) { _Txt_Exento.Text = ""; }
            _Mtd_CalularMontos();
        }

        void _Mtd_VerificarMaximo()
        {
            double _Dbl_Alicuota = 0;
            double.TryParse(_Txt_Alicuota.Text, out _Dbl_Alicuota);
            if (_Dbl_Alicuota > 100)
            {
                _Txt_Alicuota.Text = "100";
                _Txt_Alicuota.Select(3, 0);
            }
        }

        private void _Txt_Alicuota_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Alicuota, e, 3, 2);
            _Mtd_VerificarMaximo();
        }

        private void _Txt_Alicuota_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Alicuota.Text)) { _Txt_Alicuota.Text = ""; }
            _Mtd_VerificarMaximo();
            _Mtd_CalularMontos();
        }

        private void _Rb_ConIva_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_HabilitarIvaCredNoComp();
            _Txt_BaseImponible.Enabled = _Rb_ConIva.Checked;
            _Txt_BaseImponible.Text = "";
            if (_Rb_ConIva.Checked)
            {
                _Txt_Alicuota.Text = _Mtd_ObtenerAlicuota();
                _Txt_Alicuota.Enabled = true;
                _Txt_BaseImponible.Focus();
            }
            else
            {
                _Txt_Alicuota.Text = "";
                _Txt_Alicuota.Enabled = false;
                _Txt_Exento.Focus();
            }
        }

        private void _Cmb_TipoDocumentoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Txt_DocumentAfect.Enabled = _Cmb_TipoDocumentoD.SelectedIndex > 0 &&
                !(Convert.ToString(_Cmb_TipoDocumentoD.SelectedValue) == _Str_TipoDocFACT ||
                Convert.ToString(_Cmb_TipoDocumentoD.SelectedValue) == _Str_TipoDocNDP);
            if (!_Txt_DocumentAfect.Enabled)
                _Txt_DocumentAfect.Text = "";
            _Mtd_HabilitarIvaCredNoComp();
        }

        private void _Txt_NumCtrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NumCtrl, e, 8, 0);
        }

        private void _Txt_NumCtrl_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NumCtrl.Text)) { _Txt_NumCtrl.Text = ""; }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarFormulario(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim());
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            if (new Frm_Clave().ShowDialog(this) == DialogResult.OK)
            {
                //Comprobación del permiso hasta el último momento.
                if (!(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_LIBROCOMPRAS")))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta operación.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                _Mtd_Aprobar();
            }
        }

        private void _Rb_FiltroConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                _Mtd_Actualizar();
        }
    }
}
