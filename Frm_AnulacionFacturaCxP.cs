using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_AnulacionFacturaCxP : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_CompanyRetenExterna = "";
        string _Str_TipoDocument = "";
        string _Str_TipoDocumentName = "";
        private bool _Bol_Rechazar;
        public Frm_AnulacionFacturaCxP(string _P_Str_TipoDocument)
        {
            InitializeComponent();
            //-------------------
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            //-------------------
            if (_P_Str_TipoDocument.Trim() == "FACT")
            {
                _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
            }
            else if (_P_Str_TipoDocument.Trim() == "NDP")
            {
                _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocndp"); 
            }
            else
            {
                _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocncp"); 
            }
            //-------------------
            string _Str_Cadena = "SELECT cname FROM TDOCUMENT WHERE ctdocument='" + _Str_TipoDocument + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this.Text = "Anulación de " + _Ds.Tables[0].Rows[0][0].ToString().ToLower().Trim() + " (CxP)";
                _Str_TipoDocumentName = _Ds.Tables[0].Rows[0][0].ToString().ToLower().Trim();
                _Grb_Buscar.Text = "Buscar " + _Str_TipoDocument;
            }
            //-------------------
            _Mtd_Actualizar();
            _Mtd_CargarMotivo();
        }
        public Frm_AnulacionFacturaCxP(string _P_Str_TipoDocument, bool _P_Bol_PorAprobar)
        {
            InitializeComponent();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            if (_P_Bol_PorAprobar)
                _Rb_PorAprobar.Checked = true;
            else
                _Rb_PorImprimir.Checked = true;
            //-------------------
            if (_P_Str_TipoDocument.Trim() == "FACT")
            {
                _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
            }
            else if (_P_Str_TipoDocument.Trim() == "NDP")
            {
                _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocndp");
            }
            else
            {
                _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocncp");
            }
            //-------------------
            string _Str_Cadena = "SELECT cname FROM TDOCUMENT WHERE ctdocument='" + _Str_TipoDocument + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this.Text = "Anulación de " + _Ds.Tables[0].Rows[0][0].ToString().ToLower().Trim() + " (CxP)";
                _Str_TipoDocumentName = _Ds.Tables[0].Rows[0][0].ToString().ToLower().Trim();
                _Grb_Buscar.Text = "Buscar " + _Str_TipoDocument;
            }
            //-------------------
            _Mtd_Actualizar();
            _Mtd_CargarMotivo();
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
        private void _Mtd_Actualizar()
        {
            string _Str_Where = "";
            if (_Rb_PorAprobar.Checked)
            { _Str_Where = " AND ctipodocument='" + _Str_TipoDocument + "' AND cestatusfirma=1 AND (cidcomprobanul<>'0' AND NOT cidcomprobanul IS NULL)"; }
            else if (_Rb_PorImprimir.Checked)
            { _Str_Where = " AND ctipodocument='" + _Str_TipoDocument + "' AND cidcomprobanul>0 AND cstatus='0'"; }
            else
            { _Str_Where = " AND ctipodocument='" + _Str_TipoDocument + "' AND CONVERT(DATETIME,CONVERT(VARCHAR(255),cfechaanul,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "' AND canulado=1 AND cestatusfirma=2"; }
            string _Str_Cadena = "SELECT top ?sel cname as Documento, cnumdocu as [N# Documento], Tipo, DesCategoria as Categoría, cproveedor+'-'+c_nomb_comer as Proveedor, ctotal as [Monto Total],cidfactxp FROM VST_FACTURA_ANUL_CXP WHERE NOT cnumdocu IN (SELECT top ?omi cnumdocu FROM VST_FACTURA_ANUL_CXP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where + ") AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("N# Documento");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cnumdocu";
            _Str_Campos[1] = "c_nomb_comer";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, _Str_TipoDocumentName, _Tsm_Menu, _Dg_Grid, "VST_FACTURA_ANUL_CXP", "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where, 100, "ORDER BY cnumdocu");
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["cidfactxp"].Visible = false;
            _Dg_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________  
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotianulfact='1' ORDER BY cdescripcion ASC";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
        }
        private void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Str_CuentaManual = "";
            _Str_CuentaDescripManual = "";
            _Txt_Documento.Text = "";
            _Txt_Documento.Tag = "";
            _Txt_TipoProveedor.Text = "";
            _Txt_CatProveedor.Text = "";
            _Txt_Proveedor.Text = "";
            _Txt_Proveedor.Tag = "";
            _Txt_Fecha.Text = "";
            _Txt_Monto.Text = "";
            _Str_TipoProveedor = "";
            _Str_CatProveedor = "";
            _Str_Id_CxP_G = "";
            _Str_ComprobanteExistente = "0";
            _Int_Index = -1;
            _Dg_Comprobante.Rows.Clear();
            _Mtd_CargarMotivo();
            _Bt_Imprimir.Visible = false;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_DesHabilitarTodo();
            _Mtd_Ini();
            _Bt_Buscar.Enabled = true;
            _Bt_Buscar.Focus();
            _Tb_Tab.SelectedIndex = 1;
        }
        private void _Mtd_DesHabilitarTodo()
        {
            _Bt_Buscar.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Bt_Visulizar.Enabled = false;
        }
        private void _Mtd_Activated()
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURACXP") || _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP")))
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                if (_Bt_Buscar.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
                if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP"))
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false; }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }
        public void _Mtd_InsertarAuxiliar(string _P_Str_Comprobante, string _P_Str_Proveedor)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            DateTime _Dtm_FechaEmi = Convert.ToDateTime(_Txt_Fecha.Text);
            DateTime _Dtm_FechaVenc = _Mtd_FechaVencimiento(_Str_Id_CxP_G);
            double _Dbl_Monto = 0;
            string _Str_Cadena = "SELECT cidcomprob,ccount,cdescrip,ctdocument,cnumdocu,CASE WHEN ctotdebe>0 THEN ctotdebe ELSE ctothaber END AS Monto,CASE WHEN ctotdebe>0 THEN 'D' ELSE 'H' END AS Naturaleza FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dbl_Monto = Convert.ToDouble(_Row["Monto"].ToString().Trim());
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row["ccount"].ToString().Trim(), _P_Str_Proveedor, _Row["cdescrip"].ToString().Trim(), _Row["ctdocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _Cls_Formato._Mtd_fecha(_Dtm_FechaEmi), _Cls_Formato._Mtd_fecha(_Dtm_FechaVenc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["Naturaleza"].ToString().Trim().ToUpper());
            }
        }
        private bool _Mtd_VerificarMesComprobanteISLR(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TFACTPPAGARM INNER JOIN TCOMPROBANISLRC ON TFACTPPAGARM.cproveedor = TCOMPROBANISLRC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANISLRC.ccompany AND TFACTPPAGARM.cidcomprobislr = TCOMPROBANISLRC.cidcomprobislr AND TFACTPPAGARM.cnumdocu = TCOMPROBANISLRC.cnumdocumafec INNER JOIN TCOMPROBANC ON TCOMPROBANISLRC.ccompany = TCOMPROBANC.ccompany AND TCOMPROBANISLRC.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (dbo.TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarMesComprobanteRETEN(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TFACTPPAGARM INNER JOIN TCOMPROBANRETC ON TFACTPPAGARM.cproveedor = TCOMPROBANRETC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANRETC.ccompany AND TFACTPPAGARM.cidcomprobret = TCOMPROBANRETC.cidcomprobret AND TFACTPPAGARM.cnumdocu = TCOMPROBANRETC.cnumdocumafec INNER JOIN TCOMPROBANC ON TCOMPROBANRETC.ccompany = TCOMPROBANC.ccompany AND TCOMPROBANRETC.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (dbo.TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_RetornarComprobAnulacionISLR(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT TCOMPROBANISLRC.cidcomprobanul FROM TCOMPROBANISLRC INNER JOIN TFACTPPAGARM ON TCOMPROBANISLRC.cproveedor = TFACTPPAGARM.cproveedor AND TCOMPROBANISLRC.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANISLRC.cnumdocumafec = TFACTPPAGARM.cnumdocu AND TCOMPROBANISLRC.cidcomprobislr = TFACTPPAGARM.cidcomprobislr WHERE (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0][0].ToString().Trim() != "0")
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
            }
            return "";
        }
        private string _Mtd_RetornarComprobAnulacionRETEN(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT TCOMPROBANRETC.cidcomprobanul FROM TCOMPROBANRETC INNER JOIN TFACTPPAGARM ON TCOMPROBANRETC.cproveedor = TFACTPPAGARM.cproveedor AND TCOMPROBANRETC.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANRETC.cnumdocumafec = TFACTPPAGARM.cnumdocu AND TCOMPROBANRETC.cidcomprobret = TFACTPPAGARM.cidcomprobret WHERE (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0][0].ToString().Trim() != "0")
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
            }
            return "";
        }
        private bool _Mtd_VerificarComprobISLRImpreso(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT TFACTPPAGARM.cidfactxp FROM TCOMPROBANISLRC INNER JOIN TFACTPPAGARM ON TCOMPROBANISLRC.cproveedor = TFACTPPAGARM.cproveedor AND TCOMPROBANISLRC.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANISLRC.cnumdocumafec = TFACTPPAGARM.cnumdocu AND TCOMPROBANISLRC.cidcomprobislr = TFACTPPAGARM.cidcomprobislr WHERE (TCOMPROBANISLRC.cimpreso = 1) AND (TCOMPROBANISLRC.canulado = 0) AND (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarComprobRETENImpreso(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT TFACTPPAGARM.cidfactxp FROM TCOMPROBANRETC INNER JOIN TFACTPPAGARM ON TCOMPROBANRETC.cproveedor = TFACTPPAGARM.cproveedor AND TCOMPROBANRETC.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANRETC.cnumdocumafec = TFACTPPAGARM.cnumdocu AND TCOMPROBANRETC.cidcomprobret = TFACTPPAGARM.cidcomprobret WHERE (TCOMPROBANRETC.cimpreso = 1) AND (TCOMPROBANRETC.canulado = 0) AND (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_AnularGeneradosCxP(string _P_Str_ID_CxP)
        {
            string _Str_Cadena = "SELECT cnumdocu,ctipodocument,cproveedor,cidcomprob,cidcomprobislr,cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Documento = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().Trim();
                string _Str_PProveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim();
                string _Str_ID_Comprob_CxP = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_ComprobRetISRL = _Ds.Tables[0].Rows[0]["cidcomprobislr"].ToString().Trim();
                string _Str_ComprobRetCOMP = _Ds.Tables[0].Rows[0]["cidcomprobret"].ToString().Trim();
                //-----------------------------------ELIMINAR RETENCIÓN DE LA COMPAÑÍA Y ANULAR COMPROBANTE
                if (_Mtd_VerificarMesComprobanteRETEN(_P_Str_ID_CxP))
                {
                    if (_Str_ComprobRetCOMP.Trim().Length > 0 & _Str_ComprobRetCOMP.Trim() != "0")
                    {
                        _Str_Cadena = "select cidcomprob from TCOMPROBANRETC  where ccompany='" + Frm_Padre._Str_Comp + "' and  cidcomprobret='" + _Str_ComprobRetCOMP + "' and canulado='0' AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS INNER JOIN TCONFIGCXP ON TCONFIGCXP.ccompany=VST_PAGOS.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_PAGOS.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_PAGOS.cproveedor=TCOMPROBANRETC.cproveedor AND VST_PAGOS.cnumdocu=CONVERT(VARCHAR,TCOMPROBANRETC.cidcomprobret) AND VST_PAGOS.ctipodocument=TCONFIGCXP.ctipdocretiva AND VST_PAGOS.canulado='0')";
                        //_Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Str_ComprobRetCOMP + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                            if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                            {
                                if (_Mtd_VerificarComprobRETENImpreso(_P_Str_ID_CxP))
                                {
                                    string _Str_Id_ComprobAnul = _Cls_VariosMetodos._Mtd_CrearComprobanteAnulacion(_Str_Id_Comprob);
                                    _Str_Cadena = "UPDATE TCOMPROBANRETC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Str_ComprobRetCOMP + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    //--------RETENCIÓN EXTERNA
                                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                                    {
                                        _Str_Cadena = "UPDATE TCOMPROBANRETC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobret='" + _Str_ComprobRetCOMP + "'";
                                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                                    }
                                    //--------
                                    _Mtd_InsertarAuxiliar(_Str_Id_ComprobAnul, Convert.ToString(_Txt_Proveedor.Tag));
                                }
                                else
                                {
                                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_Comprob + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                            }
                            _Str_Cadena = "UPDATE TCOMPROBANRETC SET canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Str_ComprobRetCOMP + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            //--------RETENCIÓN EXTERNA
                            if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                            {
                                _Str_Cadena = "UPDATE TCOMPROBANRETC SET canulado=1,cimpreso='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobret='" + _Str_ComprobRetCOMP + "'";
                                Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                            //--------
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                            string _Str_TipoDocIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                            _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Str_ComprobRetCOMP + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "UPDATE TMOVCXPM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Str_ComprobRetCOMP + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
                //-----------------------------------ELIMINAR RETENCIÓN ISLR Y ANULAR COMPROBANTE
                if (_Mtd_VerificarMesComprobanteISLR(_P_Str_ID_CxP))
                {
                    if (_Str_ComprobRetISRL.Trim().Length > 0 & _Str_ComprobRetISRL.Trim() != "0")
                    {
                        _Str_Cadena = "select cidcomprob from TCOMPROBANISLRC  where ccompany='" + Frm_Padre._Str_Comp + "' and  cidcomprobislr='" + _Str_ComprobRetISRL + "' and canulado='0' AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS INNER JOIN TCONFIGCXP ON TCONFIGCXP.ccompany=VST_PAGOS.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_PAGOS.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_PAGOS.cproveedor=TCOMPROBANISLRC.cproveedor AND VST_PAGOS.cnumdocu=CONVERT(VARCHAR,TCOMPROBANISLRC.cidcomprobislr) AND VST_PAGOS.ctipodocument=TCONFIGCXP.ctipdocretislr AND VST_PAGOS.canulado='0')";
                        //_Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                            if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                            {
                                if (_Mtd_VerificarComprobISLRImpreso(_P_Str_ID_CxP))
                                {
                                    string _Str_Id_ComprobAnul = _Cls_VariosMetodos._Mtd_CrearComprobanteAnulacion(_Str_Id_Comprob);
                                    _Str_Cadena = "UPDATE TCOMPROBANISLRC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    //--------RETENCIÓN EXTERNA
                                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                                    {
                                        _Str_Cadena = "UPDATE TCOMPROBANISLRC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                                    }
                                    //--------
                                    _Mtd_InsertarAuxiliar(_Str_Id_ComprobAnul, Convert.ToString(_Txt_Proveedor.Tag));
                                }
                                else
                                {
                                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_Comprob + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                            }
                            _Str_Cadena = "UPDATE TCOMPROBANISLRC SET canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            //--------RETENCIÓN EXTERNA
                            if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                            {
                                _Str_Cadena = "UPDATE TCOMPROBANISLRC SET canulado=1,cimpreso='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                                Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                            //--------
                            _Str_Cadena = "DELETE FROM TFACTPPAGARISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp='" + _P_Str_ID_CxP + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretislr FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                            string _Str_TipoDocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
                            _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Str_ComprobRetISRL + "' AND ctipodocument='" + _Str_TipoDocISLR + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "UPDATE TMOVCXPM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Str_ComprobRetISRL + "' AND ctipodocument='" + _Str_TipoDocISLR + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
                //-----------------------------------ELIMINAR IMPUESTOS
                _Str_Cadena = "DELETE FROM TFACTPPAGARIMPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private DateTime _Mtd_FechaVencimiento(string _P_Str_ID_Fact_CxP)
        {
            string _Str_Cadena = "SELECT cfechavencimiento FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Fact_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }
        private bool _Mtd_ComprobanteSinActualizar(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cstatus FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND ISNULL(cstatus,0)='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        string _Str_Id_CxP_G = "";
        private void _Mtd_CargarFormulario(string _P_Str_ID_Fact_CxP)
        {
            _Er_Error.Dispose();
            string _Str_Cadena = "SELECT Tipo,DesCategoria,c_nomb_comer,CONVERT(VARCHAR,cfechaemision,103) as cfechaemision,ctotal,cglobal,ccatproveedor,cmotivoanulacion,canulado,cidcomprobanul,cestatusfirma,cproveedor,cnumdocu FROM VST_FACTURA_ANUL_CXP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Fact_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Mtd_Ini();
                _Bt_Imprimir.Visible = false;
                //-- Inicio -- Validacion de documentos ya usados en orden de pago y/o cobranza
                string _Str_CodigoProveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().ToUpper();
                string _Str_TipoDocumento = "";
                switch (_Str_TipoDocument)
                {
                    case "FACT":
                        _Str_TipoDocumento = "FACTURA CXP";
                        break;
                    case "NDP":
                        _Str_TipoDocumento = "NOTA DE DEBITO PROVEEDOR CXP";
                        break;
                    case "NCP":
                        _Str_TipoDocumento = "NOTA DE CREDITO PROVEEDOR CXP";
                        break;
                }
                string _Str_NumeroDocumento = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().ToUpper();
                //Verifico que el Documento ya no este en una cobranza
                string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraCobranza(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                if (_Str_CodigoCobranzaIC != "")
                {
                    MessageBox.Show("El siguiente documento ya se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Verifico que el Documento ya no este en una orden de pago
                string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                if (_Str_CodigoOrdenPago != "")
                {
                    MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //-- Fin -- Validacion de documentos ya usados en orden de pago y/o cobranza

                _Txt_Documento.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().ToUpper();
                _Txt_TipoProveedor.Text = _Ds.Tables[0].Rows[0]["Tipo"].ToString().ToUpper();
                _Txt_CatProveedor.Text = _Ds.Tables[0].Rows[0]["DesCategoria"].ToString().ToUpper();
                _Txt_Proveedor.Text = _Ds.Tables[0].Rows[0]["c_nomb_comer"].ToString().ToUpper();
                _Txt_Proveedor.Tag = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().ToUpper();
                _Txt_Fecha.Text = _Ds.Tables[0].Rows[0]["cfechaemision"].ToString().ToUpper();
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["ctotal"].ToString().ToUpper();
                _Str_TipoProveedor = _Ds.Tables[0].Rows[0]["cglobal"].ToString().Trim();
                _Str_CatProveedor = _Ds.Tables[0].Rows[0]["ccatproveedor"].ToString().Trim();
                _Str_Id_CxP_G = _P_Str_ID_Fact_CxP;

                //if (_Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim() != "0")
                //{ _Str_ComprobanteExistente = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim(); }
                if ((_Ds.Tables[0].Rows[0]["cestatusfirma"].ToString().Trim() == "1" | _Ds.Tables[0].Rows[0]["cestatusfirma"].ToString().Trim() == "2") & _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim() != "0")
                {
                    _Str_ComprobanteExistente = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
                    _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["cmotivoanulacion"].ToString().Trim();
                    if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP") && _Rb_PorAprobar.Checked && _Ds.Tables[0].Rows[0]["cestatusfirma"].ToString().Trim() == "1")
                    {
                        var _Int_ComprobanteReemplazo = CuentasInactivasReemplazadas(_Str_Id_CxP_G);
                        if (_Int_ComprobanteReemplazo > 0)
                            _Str_ComprobanteExistente = _Int_ComprobanteReemplazo.ToString();
                        _Bt_Aprobar.Visible = true;
                        _Bt_Rechazar.Visible = true;
                    }
                    else
                    {
                        _Bt_Aprobar.Visible = false;
                        _Bt_Rechazar.Visible = false;
                        if (_Mtd_ComprobanteSinActualizar(_Str_ComprobanteExistente))
                            _Bt_Imprimir.Visible = true;
                    }
                    _Mtd_VisualizarComprobanteExis(_Str_ComprobanteExistente);
                    //_Bt_Visulizar.Enabled = true; 
                }
                else
                { _Cmb_Motivo.Enabled = true; _Mtd_CargarMotivo(); _Cmb_Motivo.Focus(); _Bt_Visulizar.Enabled = false; }
            }
        }
        /// <summary>
        /// Verifica si todas las cuentas existen
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_VerificarCuentas()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count == 0)
                        { return false; }
                        else if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() != "D")
                        {
                            return false;
                        }
                    }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
            return true;
        }
        /// <summary>
        /// Verifica si la cuenta no existe y si el tipo de proveedor es de servicio
        /// para retornar la cuenta del proveedor, sino es asi retorna la cuenta
        /// que trae el parametro
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Str_Global">Tipo de Proveedor</param>
        /// <returns></returns>
        private string[] _Mtd_ExtraerCuenta(string _P_Str_Cuenta, string _P_Str_Global,string _P_Str_Descripcion)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "0")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR INNER JOIN TCOUNT ON TPROVEEDOR.ctcount=TCOUNT.ccount AND TPROVEEDOR.ccompany=TCOUNT.ccompany WHERE TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_Proveedor.Tag + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString() }; }
                }
            }
            return new string[] { _P_Str_Cuenta, _P_Str_Descripcion };
        }
        /// <summary>
        /// Devuelve un valor que indica si una cuenta debe agregarse manualmente.
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Str_Global">Tipo de Proveedor</param>
        /// <returns></returns>
        private bool _Mtd_CuentaManual(string _P_Str_Cuenta, string _P_Str_Global)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "2")
            { return true; }
            return false;
        }
        private void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        string _Str_ComprobanteExistente = "0";
        private void _Mtd_VisualizarComprobanteExis(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT ccount,cdescrip,ctotdebe,ctothaber FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' ORDER BY corder ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object _Ob_Debe = "";
            object _Ob_Haber = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Ob_Debe = "";
                    _Ob_Haber = "";
                    //----------------------------------------------------
                    if (_Row["ctotdebe"] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()) != 0)
                        { _Ob_Debe = Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()).ToString("#,##0.00"); }
                    }
                    if (_Row["ctothaber"] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Row["ctothaber"].ToString().Trim()) != 0)
                        { _Ob_Haber = Convert.ToDouble(_Row["ctothaber"].ToString().Trim()).ToString("#,##0.00"); }
                    }
                    //----------------------------------------------------
                    _Dg_Comprobante.Rows.Add(new object[] { _Row["ccount"].ToString().Trim(), "", _Row["cdescrip"].ToString().Trim(), _Ob_Debe, _Ob_Haber });
                }
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private bool _Mtd_ImprimirComprobante(string _P_Str_Comprobante, string _P_Str_Id_CxP)
        {
            try
            {
                string _Str_Where = "ccompany='" + Frm_Padre._Str_Comp + "' and (cidcomprob='" + _P_Str_Comprobante + "'";
                string _Str_Id_ComprobISLR = _Mtd_RetornarComprobAnulacionISLR(_P_Str_Id_CxP);
                string _Str_Id_ComprobRETEN = _Mtd_RetornarComprobAnulacionRETEN(_P_Str_Id_CxP);
                if (_Str_Id_ComprobISLR.Trim().Length > 0)
                { _Str_Where += " OR cidcomprob='" + _Str_Id_ComprobISLR + "'"; }
                if (_Str_Id_ComprobRETEN.Trim().Length > 0)
                { _Str_Where += " OR cidcomprob='" + _Str_Id_ComprobRETEN + "'"; }
                _Str_Where += ")";
                PrintDialog _Print = new PrintDialog();
            _Print:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", _Str_Where, _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        return true; 
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _Print;
                    }
                }
            }
            catch (Exception _Ex) { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. " + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return false;
        }
        private void _Mtd_Aprobar(string _P_Str_Comprobante,string _P_Str_Id_CxP)
        {
            string _Str_Cadena = "";
            _Mtd_AnularGeneradosCxP(_P_Str_Id_CxP);
            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='0',clvalidado='0',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_ComprobanteExistente + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TFACTPPAGARM SET canulado='1',cactivo='0',cestatusfirma='2',cidcomprobanul='" + _P_Str_Comprobante + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_Proveedor.Tag.ToString() + "' AND ctipodocument='" + _Str_TipoDocument + "' AND cnumdocu='" + _Txt_Documento.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TMOVCXPM SET canulado='1',cactivo='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_Proveedor.Tag.ToString() + "' AND ctipodocument='" + _Str_TipoDocument + "' AND cnumdocu='" + _Txt_Documento.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        
        private int _Mtd_GenerarComprobante(bool _P_Bol_Visualizar, string _P_Str_ID_CxP)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Bol_Visualizar)
                {
                    int _Int_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                    _Str_Cadena = "SELECT CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBAND.ccount ELSE TCOUNTINAC.ccountactiva END AS ccount,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBAND.cdescrip)) ELSE REPLACE(TCOMPROBAND.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN' AS cdescrip,ctotdebe,ctothaber " +
                        "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
                        "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva RIGHT OUTER JOIN " +
                        "TCOMPROBAND INNER JOIN " +
                        "TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount ON  " +
                        "TCOUNTINAC.ccompany = TCOMPROBAND.ccompany AND TCOUNTINAC.ccountinactiva = TCOMPROBAND.ccount WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _Int_Comprobante + "' ORDER BY corder ASC";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    object _Ob_Debe = "";
                    object _Ob_Haber = "";
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _Row in _Ds.Tables[0].Rows)
                        {
                            _Ob_Debe = "";
                            _Ob_Haber = "";
                            //----------------------------------------------------
                            if (_Row["ctotdebe"] != System.DBNull.Value)
                            {
                                if (Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()) != 0)
                                { _Ob_Debe = Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()).ToString("#,##0.00"); }
                            }
                            if (_Row["ctothaber"] != System.DBNull.Value)
                            {
                                if (Convert.ToDouble(_Row["ctothaber"].ToString().Trim()) != 0)
                                { _Ob_Haber = Convert.ToDouble(_Row["ctothaber"].ToString().Trim()).ToString("#,##0.00"); }
                            }
                            //----------------------------------------------------
                            _Dg_Comprobante.Rows.Add(new object[] { _Row["ccount"].ToString().Trim(), "", _Row["cdescrip"].ToString().Trim() + " ANULACIÓN", _Ob_Haber, _Ob_Debe });
                        }
                    }
                    _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    int _Int_Comprobante =_Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
                    _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) SELECT ccompany,'" + _Int_Comprobante + "',ctypcomp,cname,'" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',ctotdebe,ctothaber,cbalance,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','9' FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) SELECT TCOMPROBAND.ccompany,'" + _Int_Comprobante + "',corder,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBAND.ccount ELSE TCOUNTINAC.ccountactiva END,ctdocument,cnumdocu,cdatedocu,ctothaber,ctotdebe,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBAND.cdescrip)) ELSE REPLACE(TCOMPROBAND.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN' " +
                        "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
                        "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva RIGHT OUTER JOIN " +
                        "TCOMPROBAND INNER JOIN " +
                        "TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount ON  " +
                        "TCOUNTINAC.ccompany = TCOMPROBAND.ccompany AND TCOUNTINAC.ccountinactiva = TCOMPROBAND.ccount WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_InsertarAuxiliar(_Int_Comprobante.ToString(), Convert.ToString(_Txt_Proveedor.Tag));
                    return _Int_Comprobante;
                }
            }
            return 0;
        }
        /// <summary>
        /// Retorna un comprobante. Si existe retorna el existente, sino existe crea uno y retorna el creado.
        /// </summary>
        /// <param name="_P_Str_Proveedor"></param>
        /// <param name="_P_Str_TipoDocumento"></param>
        /// <param name="_P_Str_Factura"></param>
        /// <returns></returns>
        private int _Mtd_RetornarComprobante(string _P_Str_Proveedor,string _P_Str_TipoDocumento,string _P_Str_Factura)
        {
            int _Int_Comprobante = 0;
            string _Str_Cadena = "Select cidcomprobanul from TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDocumento + "' AND cnumdocu='" + _P_Str_Factura + "' AND ISNULL(cidcomprobanul,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                _Int_Comprobante = _Mtd_GenerarComprobante(false, _Str_Id_CxP_G);
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cidcomprobanul='" + _Int_Comprobante + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDocumento + "' AND cnumdocu='" + _P_Str_Factura + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            return _Int_Comprobante;
        }
        /// <summary>
        /// Retorna un valor que indica si la factura ya posee un comprobante de anulación
        /// </summary>
        /// <param name="_P_Str_Proveedor"></param>
        /// <param name="_P_Str_TipoDocumento"></param>
        /// <param name="_P_Str_Factura"></param>
        /// <returns></returns>
        private bool _Mtd_ComprobanteCreadoFactuNoAnul(string _P_Str_Proveedor, string _P_Str_Factura)
        {
            string _Str_Cadena = "Select cidcomprobanul,cestatusfirma from TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0" | _Ds.Tables[0].Rows[0][0] == System.DBNull.Value)
            { return false; }//El comprobante no fue creado
            //else if (_Ds.Tables[0].Rows[0][1].ToString().Trim() == "0" | _Ds.Tables[0].Rows[0][1] == System.DBNull.Value)//El comprobante fue creado pero no se imprimio por lo tanto la factura no ha sido anulada
            //{ return false; }
            else
            { return true; }//El comprobante fue creado y la factura fue anulada
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            bool _Bol_VerificarCuenta = _Mtd_VerificarCuentas();
            if (_Txt_Documento.Text.Trim().Length > 0 & _Cmb_Motivo.SelectedIndex > 0 & _Dg_Comprobante.RowCount > 0 & _Bol_VerificarCuenta)
            {
                if (_Mtd_CuentasInactivas(_Str_Id_CxP_G))
                    return false;
                _Bol_Rechazar = false;
                _Bol_Aprobar = false;
                _Pnl_Clave.Visible = true;
            }
            else
            {
                if (_Txt_Documento.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Documento, "Información requerida!!!"); }
                if (_Cmb_Motivo.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                if (_Dg_Comprobante.RowCount == 0) { MessageBox.Show("Debe visualizar el comprobante antes de guardar", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (!_Bol_VerificarCuenta) { MessageBox.Show("Debe ingresar la cuenta contable", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            return false;
        }
        private void _Mtd_GuardarAnulacion()
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_RetornarComprobante(_Txt_Proveedor.Tag.ToString().Trim(), _Str_TipoDocument, _Txt_Documento.Text.Trim());
            string _Str_Cadena = "UPDATE TFACTPPAGARM SET cestatusfirma='1',cmotivoanulacion='" + _Cmb_Motivo.SelectedValue + "',cfechaanul='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_Proveedor.Tag.ToString() + "' AND ctipodocument='" + _Str_TipoDocument + "' AND cnumdocu='" + _Txt_Documento.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Método para rechazar la anulación de facturas de proveedores.
        /// </summary>
        private void _Mtd_RechazarAnulacion()
        {
            string _Str_SQL = "UPDATE TFACTPPAGARM";
            _Str_SQL += " SET cestatusfirma='0',";
            _Str_SQL += " cmotivoanulacion=NULL,";
            _Str_SQL += " cfechaanul=NULL,";
            _Str_SQL += " cidcomprobanul=NULL,";
            _Str_SQL += " cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',";
            _Str_SQL += " cuserupd='" + Frm_Padre._Str_Use + "'";
            _Str_SQL += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Str_SQL += " AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_SQL += " AND cproveedor='" + _Txt_Proveedor.Tag + "'";
            _Str_SQL += " AND ctipodocument='" + _Str_TipoDocument + "'";
            _Str_SQL += " AND cnumdocu='" + _Txt_Documento.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
        }

        private bool _Mtd_CuentasInactivas(string _P_Str_ID_CxP)
        {
            string _Str_Cadena = "SELECT cnumdocu,ctipodocument,cproveedor,cidcomprob,cidcomprobislr,cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_ID_Comprob_RetIva = "";
                string _Str_ID_Comprob_RetIslr = "";
                string _Str_ID_Comprob_CxP = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_ComprobRetISRL = _Ds.Tables[0].Rows[0]["cidcomprobislr"].ToString().Trim();
                string _Str_ComprobRetCOMP = _Ds.Tables[0].Rows[0]["cidcomprobret"].ToString().Trim();
                if (_Mtd_VerificarMesComprobanteRETEN(_P_Str_ID_CxP))
                {
                    if (_Str_ComprobRetCOMP.Trim().Length > 0 & _Str_ComprobRetCOMP.Trim() != "0")
                    {
                        _Str_Cadena = "select cidcomprob from TCOMPROBANRETC  where ccompany='" + Frm_Padre._Str_Comp + "' and  cidcomprobret='" + _Str_ComprobRetCOMP + "' and canulado='0' AND ISNULL(cidcomprob,0)>0 AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS INNER JOIN TCONFIGCXP ON TCONFIGCXP.ccompany=VST_PAGOS.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_PAGOS.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_PAGOS.cproveedor=TCOMPROBANRETC.cproveedor AND VST_PAGOS.cnumdocu=CONVERT(VARCHAR,TCOMPROBANRETC.cidcomprobret) AND VST_PAGOS.ctipodocument=TCONFIGCXP.ctipdocretiva AND VST_PAGOS.canulado='0')";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (_Mtd_VerificarComprobRETENImpreso(_P_Str_ID_CxP))
                            {
                                _Str_ID_Comprob_RetIva = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                            }
                        }
                    }
                }
                if (_Mtd_VerificarMesComprobanteISLR(_P_Str_ID_CxP))
                {
                    if (_Str_ComprobRetISRL.Trim().Length > 0 & _Str_ComprobRetISRL.Trim() != "0")
                    {
                        _Str_Cadena = "select cidcomprob from TCOMPROBANISLRC  where ccompany='" + Frm_Padre._Str_Comp + "' and  cidcomprobislr='" + _Str_ComprobRetISRL + "' and canulado='0' AND ISNULL(cidcomprob,0)>0 AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS INNER JOIN TCONFIGCXP ON TCONFIGCXP.ccompany=VST_PAGOS.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_PAGOS.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_PAGOS.cproveedor=TCOMPROBANISLRC.cproveedor AND VST_PAGOS.cnumdocu=CONVERT(VARCHAR,TCOMPROBANISLRC.cidcomprobislr) AND VST_PAGOS.ctipodocument=TCONFIGCXP.ctipdocretislr AND VST_PAGOS.canulado='0')";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (_Mtd_VerificarComprobISLRImpreso(_P_Str_ID_CxP))
                            {
                                _Str_ID_Comprob_RetIslr = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                            }
                        }
                    }
                }
                if (_Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_ID_Comprob_CxP) |
                   (!string.IsNullOrEmpty(_Str_ID_Comprob_RetIva) && _Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_ID_Comprob_RetIva)) |
                   (!string.IsNullOrEmpty(_Str_ID_Comprob_RetIslr) && _Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_ID_Comprob_RetIslr)))
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("El comprobante inicial tiene cuentas inactivas.\nDebe reemplazar las cuentas inactivas desde el notificador 'CUENTAS CONTABLES INACTIVAS POR REEMPLAZAR' para realizar la anulación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("No se obtuvo el comprobante inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private int CuentasInactivasReemplazadas(string _P_Str_ID_CxP)
        {
            string _Str_Cadena = "SELECT cidcomprobanul FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "' AND ISNULL(cidcomprobanul,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_ID_Comprob_Anul = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
                _Str_Cadena = "SELECT DISTINCT TCOMPROBAND.ccount FROM TCOMPROBAND INNER JOIN TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount WHERE TCOMPROBAND.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _Str_ID_Comprob_Anul + "' AND TCOUNT.cactivate = 0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0 && !_Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_ID_Comprob_Anul))
                {
                    var _Int_Comprobante = _Mtd_GenerarComprobante(false, _P_Str_ID_CxP);
                    _Str_Cadena = "UPDATE TFACTPPAGARM SET cidcomprobanul='" + _Int_Comprobante + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    return _Int_Comprobante;
                }
            }
            return 0;
        }

        private void Frm_AnulacionFacturaCxP_Load(object sender, EventArgs e)
        {
            _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Comprobante);
        }
        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }
        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()));
        }
        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ())).AddDays(-1);
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ())).AddDays(-1);
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ())).AddDays(-1);
        }
        private void _Rb_PorAprobar_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }
        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }
        string _Str_TipoProveedor = "";
        string _Str_CatProveedor = "";
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(51, _Txt_Documento, 0, _Str_TipoDocument);
            _Frm.ShowDialog();
            if (_Txt_Documento.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarFormulario(Convert.ToString(_Txt_Documento.Tag).Trim());
                Cursor = Cursors.Default;
                _Txt_Documento.Tag = "";
            }
        }
        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarMotivo();
        }
        private void Frm_AnulacionFacturaCxP_Activated(object sender, EventArgs e)
        {
            _Mtd_Activated();
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarFormulario(_Ctrl_Busqueda1._Mtd_RetornarStringCelda("cidfactxp", e.RowIndex));
                Cursor = Cursors.Default;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                _Bt_Buscar.Enabled = false;
                _Cmb_Motivo.Enabled = false;
                _Bt_Visulizar.Enabled = false;
                _Tb_Tab.SelectedIndex = 1;
            }
        }
        private void _Bt_Visulizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Dg_Comprobante.Rows.Clear();
            if (_Str_ComprobanteExistente != "0" & _Mtd_ComprobanteCreadoFactuNoAnul(_Txt_Proveedor.Tag.ToString().Trim(), _Txt_Documento.Text.Trim()))
            { _Mtd_VisualizarComprobanteExis(_Str_ComprobanteExistente); }
            else
            { _Mtd_GenerarComprobante(true, _Str_Id_CxP_G); }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            { _Er_Error.Dispose(); _Bt_Visulizar.Enabled = true; }
            else
            { _Bt_Visulizar.Enabled = false; _Dg_Comprobante.Rows.Clear(); }
        }

        private void Frm_AnulacionFacturaCxP_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        string _Str_CuentaManual = "";
        string _Str_CuentaDescripManual = "";
        int _Int_Index = -1;//Para saber cual es el indice de la fila que se carga manualmente si hay una que se cargue manualmente.
        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Comprobante.CurrentCell != null & _Bt_Buscar.Enabled)
            {
                if (e.ColumnIndex == 1 & e.RowIndex != -1)
                {
                    if (_Mtd_CuentaManual(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString(), _Str_TipoProveedor) | _Str_CuentaManual.Trim().Length > 0)
                    {//(_Str_CuentaManual.Trim().Length > 0)---> Es para saber si ya se ha introducido una cuenta. Esto permite cambiarla porque el metodo (_Mtd_CuentaManual) me devolveria que la no es manual.
                        TextBox _Txt_Temp = new TextBox();
                        Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
                        _Frm.ShowDialog();
                        if (_Txt_Temp.Text.Trim().Length > 0)
                        {
                            _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Txt_Temp.Text.Trim();
                            _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Txt_Temp.Tag.ToString().Trim();
                            _Str_CuentaManual = _Txt_Temp.Text.Trim();
                            _Str_CuentaDescripManual = _Txt_Temp.Tag.ToString().Trim();
                        }
                        _Txt_Temp.Dispose();
                    }
                }
            }
        }
        bool _Bol_Aprobar = false;
        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            if (_Mtd_CuentasInactivas(_Str_Id_CxP_G))
            {
                this.Close();
            }
            else
            {
                _Bol_Rechazar = false;
                _Bol_Aprobar = true;
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURACXP") || _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ANULFACTURACXP")))
            {
                if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                {
                    if (_Bol_Rechazar)
                    {
                        _Mtd_RechazarAnulacion();

                        MessageBox.Show("La operación fué realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        _Pnl_Clave.Visible = false;
                        _Mtd_Ini();
                        _Mtd_DesHabilitarTodo();
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                        return;
                    }
                    if (_Bol_Aprobar)
                    {
                        if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                        {
                            _Mtd_Aprobar(_Str_ComprobanteExistente, _Str_Id_CxP_G);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                            MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Bt_Aprobar.Visible = false;
                            _Bt_Rechazar.Visible = false;
                            _Pnl_Clave.Visible = false;
                            _Mtd_Ini();
                            _Mtd_DesHabilitarTodo();
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Problemas de conexión para anular las retenciones correspondientes al documento seleccionado.\nPor favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        _Mtd_GuardarAnulacion();
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                        MessageBox.Show("La operación fué realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Mtd_Ini();
                        _Mtd_DesHabilitarTodo();
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
                }
            }
            else
            { MessageBox.Show("Usted no tiene permisos para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void _Rb_Aprobadas_CheckedChanged(object sender, EventArgs e)
        {
            _Lbl_Desde.Enabled = _Rb_Aprobadas.Checked;
            _Lbl_Hasta.Enabled = _Rb_Aprobadas.Checked;
            _Dt_Desde.Enabled = _Rb_Aprobadas.Checked;
            _Dt_Hasta.Enabled = _Rb_Aprobadas.Checked;
            _Lkbl_Ayer.Enabled = _Rb_Aprobadas.Checked;
            _Lkbl_Hoy.Enabled = _Rb_Aprobadas.Checked;
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            _Bol_Aprobar = false;
            _Bol_Rechazar = true;
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (_Mtd_ImprimirComprobante(_Str_ComprobanteExistente, _Str_Id_CxP_G))
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "";
                string _Str_Id_ComprobISLR = _Mtd_RetornarComprobAnulacionISLR(_Str_Id_CxP_G);
                string _Str_Id_ComprobRETEN = _Mtd_RetornarComprobAnulacionRETEN(_Str_Id_CxP_G);
                if (_Str_Id_ComprobISLR.Trim().Length > 0)
                {
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Id_ComprobISLR + "' AND ISNULL(cstatus,0)='0'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                if (_Str_Id_ComprobRETEN.Trim().Length > 0)
                {
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Id_ComprobRETEN + "' AND ISNULL(cstatus,0)='0'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_ComprobanteExistente + "' AND ISNULL(cstatus,0)='0'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("Se ha actualizado el comprobante.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bt_Imprimir.Visible = false;
                _Mtd_Ini();
                _Mtd_DesHabilitarTodo();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
            }
        }

        private void _Rb_PorImprimir_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }
    }
}