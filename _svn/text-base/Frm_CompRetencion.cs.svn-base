using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_CompRetencion : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_CompanyRetenExterna = "";
        public Frm_CompRetencion()
        {
            InitializeComponent();
        }

        bool _Bol_FrmOpenRetencion = false;
        /// <summary>
        /// CONSTRUCTOR QUE LE PASO EL ID DE LA RETENCION DE IVA
        /// </summary>
        /// <param name="_Pr_Str_ComprobRetId"></param>
        public Frm_CompRetencion(string _Pr_Str_ComprobRetId)
        {
            InitializeComponent();
            _Bol_Validar = true;
            _Txt_ComprobRetId.Text = _Pr_Str_ComprobRetId;
            _Bol_FrmOpenRetencion = true;
        }

        bool _Bol_FrmOpenDeRecepcion = false;
        /// <summary>
        /// CONSTRUCTOR QUE LE PASO EL ID DE LA RETENCION DE IVA, LA RECEPCION Y OTROS DATOS
        /// </summary>
        /// <param name="_Pr_Str_ComprobRetId"></param>
        /// <param name="_Pr_Str_ProvId"></param>
        /// <param name="_Pr_Str_FechaEmi"></param>
        /// <param name="_Pr_Str_Fact"></param>
        /// <param name="_Pr_Str_Recep"></param>
        public Frm_CompRetencion(string _Pr_Str_ComprobRetId, string _Pr_Str_ProvId, string _Pr_Str_FechaEmi, string _Pr_Str_Fact, string _Pr_Str_Recep)
        {
            InitializeComponent();

            string _Str_Sql = "";
            string _Str_FechaEmi = "";
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            object[] _Str_RowNew = new object[11];
            _Bol_FrmOpenDeRecepcion = true;
            _Str_FrmSw = "1";
            _Str_MyProceso = "M";
            _Pnl_Datos.Visible = false;
            _Txt_ComprobRetId.Enabled = false;
            _Cb_Proveedor.Enabled = false;
            _Dt_Emision.Enabled = false;
            _Txt_Cuenta.Enabled = false;
            _Txt_TotRetenido.Enabled = false;
            _Bt_AddDoc.Enabled = true;
            _Txt_ProvDatos.Enabled = false;
            _Bt_Print.Enabled = false;
            _Bt_Comprobante.Enabled = false;
            _Rb_100.Enabled = true;
            _Rb_75.Enabled = true;

            _Str_FrmProvId = _Pr_Str_ProvId;
            _Mtd_CargarProveedores();

            _Str_FrmFactura = _Pr_Str_Fact;
            _Cb_Proveedor.SelectedValue = _Pr_Str_ProvId;
            _Txt_ComprobRetId.Text = _Pr_Str_ComprobRetId;
            _Str_FrmRecep = _Pr_Str_Recep;
            _Dt_Emision.Value = Convert.ToDateTime(_Pr_Str_FechaEmi);

            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
            }
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cidcomprob from TCOMPROBANRETC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Pr_Str_ComprobRetId + "' and cproveedor='" + _Pr_Str_ProvId + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_FrmComprobante = _Ds_A.Tables[0].Rows[0][0].ToString();
            }
            _Mtd_CargarDatosProv(_Pr_Str_ProvId);
            _Dg_Doc.Rows.Clear();
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctdocumentname,cnumdocu,cnumcontrolfact,cfechadocu,cretenido,ctdocument,ctotmontexcento,calicuotaporc,cbaseimponible,cimpuesto,ctotcaomp_iva from VST_COMPROBANRET_FACT where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Pr_Str_ComprobRetId + " AND ctdocument='" + _Str_Fact + "'");
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                //_DRow["ctotcaomp_iva"] = Convert.ToDouble(_DRow["ctotcaomp_iva"]).ToString("#,##0.00");
                //_DRow["cfechadocu"] = Convert.ToDateTime(_DRow["cfechadocu"]).ToShortDateString();
                //_DRow["cretenido"] = Convert.ToDouble(_DRow["cretenido"]).ToString("#,##0.00");
                Array.Copy(_DRow.ItemArray, _Str_RowNew, _DRow.ItemArray.Length);
                _Dg_Doc.Rows.Add(_Str_RowNew);
                _Dg_Doc[3, _Dg_Doc.RowCount - 1].Value = Convert.ToDateTime(_Dg_Doc[3, _Dg_Doc.RowCount - 1].Value).ToShortDateString();
                _Dg_Doc[4, _Dg_Doc.RowCount - 1].Value = Convert.ToDouble(_Dg_Doc[4, _Dg_Doc.RowCount - 1].Value).ToString("#,##0.00");
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT SUM(cretenido) FROM VST_COMPROBANRET_FACT where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Pr_Str_ComprobRetId);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_TotRetenido.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]).ToString("#,##0.00");
            }
            _Dg_Doc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Tb_Tab.SelectedIndex = 1;
            //TRAIGO EL MONTO CON IVA DE LA FACTURA
            _Str_Sql = "SELECT ctotalimp FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Str_FrmRecep + "' AND cnfacturapro='" + _Str_FrmFactura + "' AND cproveedor='" + _Str_FrmProvId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_FrmMontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
            }

        }

        string _Str_FrmProvId = "";
        string _Str_FrmFactura = "";
        string _Str_FrmComprobante = "";
        string _Str_FrmRecep = "";
        int _Int_FrmImpreso = 0;
        string _Str_FrmSw = "";
        double _Dbl_FrmMontoImp = 0;
        string[] _Str_FrmIva = new string[0];
        string _Str_MyProceso = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        Control[] _Ctrl_Controles = new Control[4];

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

        private void Frm_CompRetencion_Load(object sender, EventArgs e)
        {
            _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            string _Str_Ret = "";
            _Mtd_CargarProveedoresFind();
            _Rb_SiFind.Checked = true;
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            if (!_Bol_FrmOpenDeRecepcion)
            {
                _Str_Ret = _Txt_ComprobRetId.Text;
                _Mtd_Ini();
            }
            if (_Bol_FrmOpenRetencion)
            {
                _Txt_ComprobRetId.Text = _Str_Ret;
                _Mtd_CargarData(_Txt_ComprobRetId.Text);
                _Bt_Print.Enabled = true;
                _Bt_Comprobante.Enabled = true;
                _Tb_Tab.SelectTab(1);
            }
            _Mtd_Color_Estandar(this);
            _Mtd_BotonesMenu();
        }
        /// <summary>
        /// CARGO EL COMBO DE LOS PROVEEDORES
        /// </summary>
        private void _Mtd_CargarProveedores()
        {
            string _Str_Sql = "SELECT DISTINCT cproveedor,c_nomb_abreviado FROM TPROVEEDOR ORDER BY c_nomb_abreviado";

            _Cb_Proveedor.SelectedIndexChanged -= new EventHandler(_Cb_Proveedor_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_Proveedor, _Str_Sql);
            _Cb_Proveedor.SelectedIndexChanged += new EventHandler(_Cb_Proveedor_SelectedIndexChanged);
        }
        /// <summary>
        /// CARGO EL COMBO DE TIPO DE DOCUMENTOS MARCADOS PA LA RETENCION DE IVA
        /// </summary>
        private void _Mtd_CargarTpoDoc()
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE ccomprobanret=1 AND cdelete=0 ORDER BY cname";
            _Cb_TpoDoc.SelectedIndexChanged -= new EventHandler(_Cb_TpoDoc_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_TpoDoc, _Str_Sql);
            _Cb_TpoDoc.SelectedIndexChanged += new EventHandler(_Cb_TpoDoc_SelectedIndexChanged);
        }

        private void _Bt_AddDoc_Click(object sender, EventArgs e)
        {
            _Pnl_Datos.Visible = true;
            _Txt_Factura.Text = _Mtd_ObtenerFacturaGrid();
        }
        /// <summary>
        /// OBTIENE LA FACTURA ASOCIADA EN EL DETALLE DE LA RETENCION
        /// </summary>
        /// <returns></returns>
        private string _Mtd_ObtenerFacturaGrid()
        {
            string _Str_Fact = "";
            string _Str_R = "";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
            }
            foreach (DataGridViewRow _DgRow in _Dg_Doc.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[5].Value) == _Str_Fact)
                {
                    _Str_R = Convert.ToString(_DgRow.Cells[1].Value);
                    break;
                }
            }
            return _Str_R;
        }


        private void _Pnl_Datos_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Datos.Visible)
            {
                _Mtd_CargarTpoDoc(); _Cb_TpoDoc.Focus(); _Mtd_BloquearInfAtras(false);
                _Er_Error.SetError(_Cb_TpoDoc, "");
                _Er_Error.SetError(_Txt_Doc, "");
                _Er_Error.SetError(_Txt_DocCtrl, "");
                _Er_Error.SetError(_Txt_DocMontoTot, "");
                _Er_Error.SetError(_Txt_DocMontoExcento, "");
                _Er_Error.SetError(_Txt_Alicuota, "");
                _Er_Error.SetError(_Txt_BaseImponible, "");

            }
            else
            { _Mtd_BloquearInfAtras(true); }
        }

        private void _Cb_TpoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            if (_Pnl_Datos.Visible)
            {
                if (_Cb_TpoDoc.SelectedIndex > 0)
                {
                    _Txt_Doc.Text = "";
                    _Txt_Doc.Focus();
                    _Txt_DocCtrl.Text = "";
                    _Dt_DocAddEmision.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                    _Txt_DocImpRet.Text = "";
                    _Txt_DocMontoExcento.Text = "";
                    _Txt_Alicuota.Text = "";
                    _Txt_BaseImponible.Text = "";
                    _Txt_DocImp.Text = "";
                    _Txt_DocMontoTot.Text = "";


                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                        _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                        _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                    }
                    if (_Str_ND == Convert.ToString(_Cb_TpoDoc.SelectedValue) || _Str_NC == Convert.ToString(_Cb_TpoDoc.SelectedValue))
                    {
                        _Txt_DocMontoExcento.Text = "0";
                    }
                }
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            bool _Bol_Sw = false;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
            }
            if (_Cb_TpoDoc.SelectedIndex<=0)
            {
                _Er_Error.SetError(_Cb_TpoDoc, "Seleccione el Tipo de Documento.");
                _Bol_Sw = true;
            }
            if (_Txt_Doc.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_Doc, "Ingrese el Número de Documento.");
                _Bol_Sw = true;
            }
            if (_Txt_DocCtrl.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_DocCtrl, "Ingrese el Número de Control del Documento.");
                _Bol_Sw = true;
            }
            if (_Txt_DocMontoTot.Text.Trim() == "" || Convert.ToDouble(_Txt_DocMontoTot.Text) == 0)
            {
                _Er_Error.SetError(_Txt_DocMontoTot, "Ingrese el Monto del Documento.");
                _Bol_Sw = true;
            }
            if (_Txt_Alicuota.Text.Trim() == "" || Convert.ToDouble(_Txt_Alicuota.Text) == 0)
            {
                _Er_Error.SetError(_Txt_Alicuota, "Ingrese la Alicuota del Documento.");
                _Bol_Sw = true;
            }
            if (_Txt_BaseImponible.Text.Trim() == "" || Convert.ToDouble(_Txt_BaseImponible.Text) == 0)
            {
                _Er_Error.SetError(_Txt_BaseImponible, "Ingrese la Base Imponible del Documento.");
                _Bol_Sw = true;
            }

            //VALIDO QUE NO EXISTA EL DOC EN EL GRID
            if (!_Bol_Sw)
            {
                foreach (DataGridViewRow _DgRow in _Dg_Doc.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells[5].Value) == _Cb_TpoDoc.SelectedValue.ToString() && Convert.ToString(_DgRow.Cells[1].Value) == _Txt_Doc.Text)
                    {
                        MessageBox.Show("Ya se ingreso el Documento.", "Validación");
                        _Bol_Sw = true;
                        break;
                    }
                }
            }


            if (!_Bol_Sw)
            {
                _Dg_Doc.Rows.Add();
                _Dg_Doc[0, _Dg_Doc.RowCount - 1].Value = _Cb_TpoDoc.Text;
                _Dg_Doc[1, _Dg_Doc.RowCount - 1].Value = _Txt_Doc.Text;
                _Dg_Doc[2, _Dg_Doc.RowCount - 1].Value = _Txt_DocCtrl.Text;
                _Dg_Doc[3, _Dg_Doc.RowCount - 1].Value = _Dt_DocAddEmision.Value.ToShortDateString();
                if (Convert.ToString(_Cb_TpoDoc.SelectedValue) == _Str_ND)
                { _Dg_Doc[4, _Dg_Doc.RowCount - 1].Value = "-" + _Txt_DocImpRet.Text; }
                else
                { _Dg_Doc[4, _Dg_Doc.RowCount - 1].Value = _Txt_DocImpRet.Text; }
                _Dg_Doc[5, _Dg_Doc.RowCount - 1].Value = _Cb_TpoDoc.SelectedValue;
                _Dg_Doc[6, _Dg_Doc.RowCount - 1].Value = _Txt_DocMontoExcento.Text;
                _Dg_Doc[7, _Dg_Doc.RowCount - 1].Value = _Txt_Alicuota.Text;
                _Dg_Doc[8, _Dg_Doc.RowCount - 1].Value = _Txt_BaseImponible.Text;
                _Dg_Doc[9, _Dg_Doc.RowCount - 1].Value = _Txt_DocImp.Text;
                _Dg_Doc[10, _Dg_Doc.RowCount - 1].Value = _Txt_DocMontoTot.Text;
                _Txt_TotRetenido.Text = _Mtd_ObtenerTotal().ToString("#,##0.00");
                _Pnl_Datos.Visible = false;
            }

        }

        public bool _Mtd_Editar()
        {
            bool _Bol_Val = false;
            bool _Bl_R = false;
            string _Str_Sql = "";
            string _Str_ctipotransacc = "";
            string _Str_Cor = "";

            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";

            double _Dbl_PorcRetiene = 0;
            double _Dbl_ImpRetenido = 0;

            double _Dbl_TotMontoSImp = 0;
            double _Dbl_TotMonto = 0;
            double _Dbl_TotRetenido = 0;
            double _Dbl_TotExcento = 0;
            double _Dbl_TotImp = 0;

            if (_Rb_100.Checked)
            { _Dbl_PorcRetiene = 1; }
            if (_Rb_75.Checked)
            { _Dbl_PorcRetiene = 0.75; }
            _Dbl_ImpRetenido = _Dbl_PorcRetiene * _Dbl_FrmMontoImp;
            try
            {
                //DETALLE DE LA RETENCION
                foreach (DataGridViewRow _DgRow in _Dg_Doc.Rows)
                {
                    DataSet _Ds_E = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_E.Tables[0].Rows.Count > 0)
                    {
                        _Str_Fact = Convert.ToString(_Ds_E.Tables[0].Rows[0]["ctipdocfact"]);
                        _Str_ND = Convert.ToString(_Ds_E.Tables[0].Rows[0]["ctipodocnd"]);
                        _Str_NC = Convert.ToString(_Ds_E.Tables[0].Rows[0]["ctipodocnc"]);
                    }

                    _Ds_E = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentgov FROM TDOCUMENT WHERE ctdocument='" + _DgRow.Cells[5].Value.ToString() + "'");
                    if (_Ds_E.Tables[0].Rows.Count > 0)
                    { _Str_ctipotransacc = Convert.ToString(_Ds_E.Tables[0].Rows[0][0]); }
                    _Str_Sql = "select * from TCOMPROBANRETD where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Txt_ComprobRetId.Text + "' and cproveedor='" + _Str_FrmProvId + "' and ctdocument='" + _DgRow.Cells[5].Value.ToString() + "' and cnumdocu='" + _DgRow.Cells[1].Value.ToString() + "'";
                    _Ds_E = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_E.Tables[0].Rows.Count == 0)
                    {
                        _Str_Cor = myUtilidad._Mtd_Correlativo("select max(ciddetalleret) from TCOMPROBANRETD where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Txt_ComprobRetId.Text + "' and cproveedor='" + _Str_FrmProvId + "'");
                        _Str_Sql = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,ctotmontexcento,ciddetalleret) VALUES('" +
                        Frm_Padre._Str_Comp + "'," + _Txt_ComprobRetId.Text + ",'" + _Str_FrmProvId + "','" + _DgRow.Cells[5].Value.ToString() + "','" + _DgRow.Cells[1].Value.ToString() + "','" + _DgRow.Cells[3].Value.ToString() + "','" + _DgRow.Cells[2].Value.ToString() + "','" + _Str_ctipotransacc + "'," + _DgRow.Cells[10].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + "," + _DgRow.Cells[8].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + "," + _DgRow.Cells[7].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + "," + _DgRow.Cells[9].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + "," + _DgRow.Cells[4].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + "," + _DgRow.Cells[6].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + "," + _Str_Cor + ")";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                    else
                    {
                        _Str_Sql = "UPDATE TCOMPROBANRETD set cretenido=" + _DgRow.Cells[4].Value.ToString().Replace(".", "").Replace(",", ".").Replace("-","") + " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Txt_ComprobRetId.Text + "' and cproveedor='" + _Str_FrmProvId + "' and ctdocument='" + _DgRow.Cells[5].Value.ToString() + "' and cnumdocu='" + _DgRow.Cells[1].Value.ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                    if (_Str_ND == Convert.ToString(_DgRow.Cells[5].Value))
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value) != "")
                        {
                            if (Convert.ToDouble(_DgRow.Cells[8].Value) < 0)
                            { _Dbl_TotMontoSImp = _Dbl_TotMontoSImp + Convert.ToDouble(_DgRow.Cells[8].Value); }
                            else
                            { _Dbl_TotMontoSImp = _Dbl_TotMontoSImp - Convert.ToDouble(_DgRow.Cells[8].Value); }
                        }

                        if (Convert.ToString(_DgRow.Cells[10].Value) != "")
                        {
                            if (Convert.ToDouble(_DgRow.Cells[10].Value) < 0)
                            { _Dbl_TotMonto = _Dbl_TotMonto + Convert.ToDouble(_DgRow.Cells[10].Value); }
                            else
                            { _Dbl_TotMonto = _Dbl_TotMonto - Convert.ToDouble(_DgRow.Cells[10].Value); }
                        }

                        if (Convert.ToString(_DgRow.Cells[4].Value) != "")
                        {
                            if (Convert.ToDouble(_DgRow.Cells[4].Value) < 0)
                            { _Dbl_TotRetenido = _Dbl_TotRetenido + Convert.ToDouble(_DgRow.Cells[4].Value); }
                            else
                            { _Dbl_TotRetenido = _Dbl_TotRetenido - Convert.ToDouble(_DgRow.Cells[4].Value); }
                        }

                        if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                        {
                            if (Convert.ToDouble(_DgRow.Cells[6].Value) < 0)
                            { _Dbl_TotExcento = _Dbl_TotExcento - Convert.ToDouble(_DgRow.Cells[6].Value); }
                            else
                            { _Dbl_TotExcento = _Dbl_TotExcento - Convert.ToDouble(_DgRow.Cells[6].Value); }
                        }

                        if (Convert.ToString(_DgRow.Cells[9].Value) != "")
                        {
                            if (Convert.ToDouble(_DgRow.Cells[9].Value) < 0)
                            { _Dbl_TotImp = _Dbl_TotImp - Convert.ToDouble(_DgRow.Cells[9].Value); }
                            else
                            { _Dbl_TotImp = _Dbl_TotImp - Convert.ToDouble(_DgRow.Cells[9].Value); }
                        }
                    }
                    else
                    {
                        _Dbl_TotMontoSImp = _Dbl_TotMontoSImp + Convert.ToDouble(_DgRow.Cells[8].Value);
                        _Dbl_TotMonto = _Dbl_TotMonto + Convert.ToDouble(_DgRow.Cells[10].Value);
                        _Dbl_TotRetenido = _Dbl_TotRetenido + Convert.ToDouble(_DgRow.Cells[4].Value);
                        _Dbl_TotExcento = _Dbl_TotExcento + Convert.ToDouble(_DgRow.Cells[6].Value);
                        _Dbl_TotImp = _Dbl_TotImp + Convert.ToDouble(_DgRow.Cells[9].Value);
                    }
                    //CARGO LA RETENCION AL DOCUMENTO
                    //if (_Str_Fact != Convert.ToString(_DgRow.Cells[5].Value))
                    //{
                        _Str_Sql = "UPDATE TFACTPPAGARM set cidcomprobret=" + _Txt_ComprobRetId.Text;
                        _Str_Sql = _Str_Sql + " WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Str_FrmProvId + "' and ctipodocument='" + Convert.ToString(_DgRow.Cells[5].Value) + "' and cnumdocu='" + Convert.ToString(_DgRow.Cells[1].Value) + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    //}
                }
                //GUARDO LA CABECERA DE LA RETENCION
                _Str_Sql = "UPDATE TCOMPROBANRETC SET ctotcaomp_iva=" + _Dbl_TotMonto.ToString().Replace(",", ".") + ",ctotmontexcento=" + _Dbl_TotExcento.ToString().Replace(",", ".") + ",cimpuesto=" + _Dbl_TotImp.ToString().Replace(",", ".") + ",ctotcaomp_siva=" + _Dbl_TotMontoSImp.ToString().Replace(".", "").Replace(",", ".") + ",cretenido=" + _Dbl_TotRetenido.ToString().Replace(",",".") +
                    " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Txt_ComprobRetId.Text + " and cproveedor='" + _Str_FrmProvId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //MODIFICO EL COMPROBANTE CONTABLE DE LA RETENCION
                _Str_Sql = "update TCOMPROBAND set ctotdebe=" + _Txt_TotRetenido.Text.Replace(".", "").Replace(",", ".") + " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_FrmComprobante + "' and ctotdebe<>0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "update TCOMPROBAND set ctothaber=" + _Txt_TotRetenido.Text.Replace(".", "").Replace(",", ".") + " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_FrmComprobante + "' and ctothaber<>0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "update TCOMPROBANC set ctotdebe=" + _Txt_TotRetenido.Text.Replace(".", "").Replace(",", ".") + ",ctothaber=" + _Txt_TotRetenido.Text.Replace(".", "").Replace(",", ".") + " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_FrmComprobante + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                MessageBox.Show("Se guardó correctamente la Transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    _Mtd_BloquearInfAtras(false);
                    _Grb_PorcRetiene.Enabled = false;
                    _Pnl_Datos.Visible = false;
                }
                catch
                { MessageBox.Show("Problemas al Reiniciar."); }
                _Bt_Comprobante.Enabled = true;
                _Bt_Print.Enabled = true;
                _Str_MyProceso = "";
                _Mtd_Actualizar();
                _Bl_R = true;
            }
            catch
            {
                MessageBox.Show("Problemas al Guardar la Transacción.");
                _Bl_R = false;
            }

            return _Bl_R;
        }
        /// <summary>
        /// OBTIENE EL TOTAL DEL DETALLE QUE SE MUESTRA EN EL GRID
        /// </summary>
        /// <returns></returns>
        private double _Mtd_ObtenerTotal()
        {
            double _Dbl_Tot = 0;
            string _Str_Sql = "";
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
            }
            foreach (DataGridViewRow _DgRow in _Dg_Doc.Rows)
            {
                if (_DgRow.Cells[5].Value.ToString() == _Str_Fact || _DgRow.Cells[5].Value.ToString() == _Str_NC)
                { _Dbl_Tot = _Dbl_Tot + Convert.ToDouble(_DgRow.Cells[4].Value); }
                if (_DgRow.Cells[5].Value.ToString() == _Str_ND)
                { _Dbl_Tot = _Dbl_Tot + Convert.ToDouble(_DgRow.Cells[4].Value); }
            }
            return _Dbl_Tot;
        }

        private void _Mtd_BloquearInfAtras(bool _Pr_Bol_Sw)
        {
            _Txt_ComprobRetId.Enabled = false;
            _Dt_Emision.Enabled = _Pr_Bol_Sw;
            _Grb_PorcRetiene.Enabled = _Pr_Bol_Sw;
            _Bt_AddDoc.Enabled = _Pr_Bol_Sw;
            _Bt_Comprobante.Enabled = _Pr_Bol_Sw;
            _Txt_ProvDatos.Enabled = false;
            _Cb_Proveedor.Enabled = false;
            _Dt_Emision.Enabled = false;
            _Txt_Cuenta.Enabled = false;
            _Txt_TotRetenido.Enabled = false;
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Mtd_BloquearInfAtras(_Pr_Bol_A);
        }

        public void _Mtd_Ini()
        {
            _Mtd_BloquearInfAtras(false);
            _Str_MyProceso = "";
            _Str_FrmComprobante = "";
            _Str_FrmProvId = "";
            _Txt_ComprobRetId.Text = "";
            _Dt_Emision.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Txt_ProvDatos.Text = "";
            _Rb_75.Checked = false;
            _Rb_100.Checked = false;
            _Txt_Cuenta.Text = "";
            _Txt_TotRetenido.Text = "";
            _Dg_Doc.Rows.Clear();
            _Pnl_Datos.Visible = false;
            _Bt_Print.Enabled = false;
            _Mtd_BotonesMenu();
            _Mtd_CargarProveedores();
            _Int_FrmImpreso = 0;
        }

        private void _Mtd_ObtenerIva(string _Pr_Str_Prov, string _Pr_Str_Doc, string _Pr_Str_RecepId)
        {
            string _Str_Sql = "";
            _Str_Sql = "select ctasaimp,cgroupcomp,cidrecepcion,cnfacturapro,cproveedor from TRECEPCIONDFD GROUP BY ctasaimp HAVING cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Str_FrmRecep + "' and cnfacturapro='" + _Str_FrmFactura + "' and cproveedor='" + _Str_FrmProvId + "' and ctasaimp<>0";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Txt_Alicuota.Text = _Ds_A.Tables[0].Rows[0][0].ToString();
            }
        }
        /// <summary>
        /// CONFIGURA LA BOTONERA DEL FORMULARIO PADRE
        /// </summary>
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            if (_Str_MyProceso == "A")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_ComprobRetId.Text != "")
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    if (_Int_FrmImpreso == 0)
                    { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false; }
                    else
                    { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false; }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }

        private void _Txt_DocImp_TextChanged(object sender, EventArgs e)
        {
            double _Dbl_Imp = 0;
            double _Dbl_ImpRet = 0;
            double _Dbl_PorcRet = 0;
            if (_Txt_DocImp.Text != "")
            {
                if (_Rb_100.Checked)
                { _Dbl_PorcRet = 1; }
                else
                { _Dbl_PorcRet = 0.75; }
                _Dbl_Imp = Convert.ToDouble(_Txt_DocImp.Text);
                _Dbl_ImpRet = _Dbl_Imp * _Dbl_PorcRet;
                _Txt_DocImpRet.Text = _Dbl_ImpRet.ToString("#,##0.00");
            }
        }

        private void _Bt_Doc_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            myUtilidad._Mtd_CerrarFormHijo((Frm_Padre)this.MdiParent, "Frm_Busqueda");
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
            }
            if (_Str_FrmFactura == "")
            {
                _Str_FrmFactura = _Txt_Factura.Text;
            }
            if (_Str_ND == _Cb_TpoDoc.SelectedValue.ToString())
            {
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
                _Tsm_Menu[0] = new ToolStripMenuItem("Número de Documento");
                string[] _Str_Campos = new string[1];
                _Str_Campos[0] = "cidnotadebitocxp";
                string _Str_Cadena = "Select cidnotadebitocxp as [Documento],cfechand as [Emisión],cfvfnotadebitop AS [Vencimiento],ctotaldocu AS Monto,cnumdocu as [Factura] from TNOTADEBITOCP where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_FrmProvId + "' and cnumdocu='" + _Str_FrmFactura + "' and ctipodocument='" + _Str_Fact + "' and cimpresa=1";
                Frm_Busqueda _Frm = new Frm_Busqueda(_Str_Cadena, _Str_Campos, "Notas de Débito", _Tsm_Menu, _Txt_Doc);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
            }
            if (_Str_NC == _Cb_TpoDoc.SelectedValue.ToString())
            {
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
                _Tsm_Menu[0] = new ToolStripMenuItem("Número de Documento");
                string[] _Str_Campos = new string[1];
                _Str_Campos[0] = "cidnotacreditocxp";
                string _Str_Cadena = "Select cidnotacreditocxp as [Documento],cfechanc as [Emisión],cfvfnotacredp AS [Vencimiento],ctotaldocu AS Monto,cnumdocu as [Factura] from TNOTACREDICP where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_FrmProvId + "' and cnumdocu='" + _Str_FrmFactura + "' and ctipodocument='" + _Str_Fact + "'  and cimpresa=1";
                Frm_Busqueda _Frm = new Frm_Busqueda(_Str_Cadena, _Str_Campos, "Notas de Crédito", _Tsm_Menu, _Txt_Doc);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
            }
            if (_Str_Fact == _Cb_TpoDoc.SelectedValue.ToString())
            {
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
                _Tsm_Menu[0] = new ToolStripMenuItem("Número de Factura");
                string[] _Str_Campos = new string[1];
                _Str_Campos[0] = "cnfacturapro";
                string _Str_Cadena = "Select cnfacturapro as [Documento],cdateemifactura as [Emisión],cdatevencimiento AS [Vencimiento],ctotfactura AS Monto from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cproveedor='" + _Str_FrmProvId + "'";
                Frm_Busqueda _Frm = new Frm_Busqueda(_Str_Cadena, _Str_Campos, "Facturas", _Tsm_Menu, _Txt_Doc);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
            }
        }

        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
        }

        private void _Bt_Comprobante_Click(object sender, EventArgs e)
        {
            Frm_VerComprobante _Frm_VerComprobante = new Frm_VerComprobante(_Str_FrmComprobante);
            if (!_Mtd_AbiertoOno(_Frm_VerComprobante, (Frm_Padre)this.MdiParent))
            {
                _Frm_VerComprobante.MdiParent = this.MdiParent;
                _Frm_VerComprobante.Show();
            }
            else
            { _Frm_VerComprobante.Dispose(); }
        }

        public bool _Mtd_AbiertoOno(Form _Frm_Formulario, Frm_Padre _Pr_Frm_Padre)
        {
            foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Frm_Formulario.Name)
                {
                    _Frm_Hijo.Activate();
                    return true;
                }
            }
            return false;
        }

        private void _Txt_Doc_TextChanged(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            if (_Txt_Doc.Text != "")
            {
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                    _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                    _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                }


                //_Str_Sql = "select ctasaimp,cgroupcomp,cidrecepcion,cnfacturapro,cproveedor from TRECEPCIONDFD GROUP BY ctasaimp,cgroupcomp,cidrecepcion,cnfacturapro,cproveedor HAVING cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Str_FrmRecep + "' and cnfacturapro='" + _Str_FrmFactura + "' and cproveedor='" + _Str_FrmProvId + "' and ctasaimp<>0";
                _Str_Sql = "select ctasaimp,cgroupcomp,cidrecepcion,cnfacturapro,cproveedor from TRECEPCIONDFD GROUP BY ctasaimp,cgroupcomp,cidrecepcion,cnfacturapro,cproveedor HAVING cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnfacturapro='" + _Str_FrmFactura + "' and cproveedor='" + _Str_FrmProvId + "' and ctasaimp<>0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                { _Txt_Alicuota.Text = _Ds_A.Tables[0].Rows[0][0].ToString(); }

                //CARGO LOS DATOS DEL DOCUMENTO
                if (_Txt_Doc.Text != "")
                {
                    if (_Str_ND == _Cb_TpoDoc.SelectedValue.ToString())
                    {
                        _Str_Sql = "Select * from TNOTADEBITOCP where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_FrmProvId + "' and cidnotadebitocxp='" + _Txt_Doc.Text + "'";
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            _Txt_DocCtrl.Text = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cnumcontrolnd"]);
                            _Dt_DocAddEmision.Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechand"]);
                            _Txt_Factura.Text = _Str_FrmFactura;
                            _Txt_DocMontoTot.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                            _Txt_DocMontoExcento.Text = "0";
                            _Txt_DocImp.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                            _Txt_BaseImponible.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cmontototsi"]).ToString("#,##0.00");
                        }
                    }
                    if (_Str_NC == _Cb_TpoDoc.SelectedValue.ToString())
                    {
                        _Str_Sql = "Select * from TNOTACREDICP where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_FrmProvId + "' and cidnotacreditocxp='" + _Txt_Doc.Text + "'";
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            _Txt_DocCtrl.Text = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cnumcontrolnc"]);
                            _Dt_DocAddEmision.Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechanc"]);
                            _Txt_Factura.Text = _Str_FrmFactura;
                            _Txt_DocMontoTot.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                            _Txt_DocMontoExcento.Text = "0";
                            _Txt_DocImp.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                            _Txt_BaseImponible.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cmontototsi"]).ToString("#,##0.00");
                        }
                    }
                }
            }

        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            _Pnl_Datos.Visible = false;
        }

        private void Frm_CompRetencion_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;

            _Ctrl_Controles[0] = _Txt_ComprobRetId;
            _Ctrl_Controles[1] = _Cb_Proveedor;
            _Ctrl_Controles[2] = _Txt_ProvDatos;
            _Ctrl_Controles[3] = _Txt_Cuenta;
            CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "";

            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_Str_MyProceso == "A")
                { _Bt_Comprobante.Focus(); }
            }

            //CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            //_Cls_CL._Mtd_Foco();
            _Mtd_BotonesMenu();
        }

        private void Frm_CompRetencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            myUtilidad._Mtd_CerrarFormHijo((Frm_Padre)this.MdiParent, "Frm_VerComprobante");
            myUtilidad._Mtd_CerrarFormHijo((Frm_Padre)this.MdiParent, "Frm_Busqueda");
        }

        private void _Rb_75_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_75.Checked && _Str_MyProceso != "")
            {
                double _Dbl_PorcRetiene = 0.75;
                double _Dbl_Imp = 0;
                double _Dbl_ImpRetenido = 0;
                foreach (DataGridViewRow _DgRow in _Dg_Doc.Rows)
                {//verificar como carga el valor
                    _Dbl_Imp = Convert.ToDouble(_DgRow.Cells[9].Value);
                    _Dbl_ImpRetenido = _Dbl_Imp * _Dbl_PorcRetiene;
                    _DgRow.Cells[4].Value = _Dbl_ImpRetenido.ToString("#,##0.00");
                }
                _Txt_TotRetenido.Text = _Mtd_ObtenerTotal().ToString("#,##0.00");
            }
        }

        private void _Rb_100_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_100.Checked && _Str_MyProceso != "")
            {
                double _Dbl_PorcRetiene = 1;
                double _Dbl_Imp = 0;
                double _Dbl_ImpRetenido = 0;
                foreach (DataGridViewRow _DgRow in _Dg_Doc.Rows)
                {
                    _Dbl_Imp = Convert.ToDouble(_DgRow.Cells[9].Value);
                    _Dbl_ImpRetenido = _Dbl_Imp * _Dbl_PorcRetiene;
                    _DgRow.Cells[4].Value = _Dbl_ImpRetenido.ToString("#,##0.00");
                }
                _Txt_TotRetenido.Text = _Mtd_ObtenerTotal().ToString("#,##0.00");
            }
        }

        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select cidcomprobret as Código,c_nomb_comer as Proveedor,cporcretiene as [% Retenido],dbo.Fnc_Formatear(cretenido) as Retenido,cimpreso_descrip as Impreso from VST_COMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT * FROM VST_COMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret=" + _Pr_Str_Id;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                //cimpreso
                _Int_FrmImpreso = Convert.ToInt16(_Ds_Data.Tables[0].Rows[0]["cimpreso"]); ;
                _Str_FrmComprobante = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidcomprob"]); ;
                _Txt_ComprobRetId.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidcomprobret"]);
                _Dt_Emision.Value = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfechaemiret"]);
                _Str_FrmProvId = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]);
                _Cb_Proveedor.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]);
                _Mtd_CargarDatosProv(Convert.ToString(_Cb_Proveedor.SelectedValue));

                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cporcretiene"]) == "100")
                { _Rb_100.Checked = true; }
                else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cporcretiene"]) == "75")
                { _Rb_75.Checked = true; }
                //CARGO EL DETALLE
                _Mtd_CargarDetalle(_Pr_Str_Id);
            }
        }
        /// <summary>
        /// CONSTRUYE LA DESCRIPCION DEL PROVEEDOR
        /// </summary>
        /// <param name="_Pr_Str_ProvId"></param>
        private void _Mtd_CargarDatosProv(string _Pr_Str_ProvId)
        {
            string[] _Str_DatosVec = new string[2];
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Pr_Str_ProvId + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Str_FrmSw != "")
                {
                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcenreteniva"]) == 75)
                    { _Rb_75.Checked = true; }
                    else if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcenreteniva"]) == 100)
                    { _Rb_100.Checked = true; }
                    else
                    { _Rb_100.Checked = false; _Rb_75.Checked = false; }
                }

                _Str_DatosVec[0] = "RIF:" + Convert.ToString(_Ds.Tables[0].Rows[0]["c_rif"]) + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_fiscal"]) + ".";
                _Str_DatosVec[1] = "DIRECCION:" + Convert.ToString(_Ds.Tables[0].Rows[0]["c_direcc_fiscal"]);
                _Txt_ProvDatos.Lines = _Str_DatosVec;
                _Txt_ProvDatos.Text = _Txt_ProvDatos.Text.ToUpper();
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + Convert.ToString(_Ds.Tables[0].Rows[0]["ctcount"]) + "'");
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Txt_Cuenta.Text = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                }
            }
        }

        private void _Mtd_CargarDetalle(string _Pr_Str_Id)
        {
            object[] _Str_RowNew = new object[12];
            string _Str_Sql = "";
            _Dg_Doc.Rows.Clear();
            _Str_Sql = "select ctdocumentname,cnumdocu,cnumcontrolfact,CONVERT(varchar, cfechadocu, 103) as cfechadocu,cretenido_doc,ctdocument,ctotmontexcento,calicuotaporc,cbaseimponible_doc,cimpuesto_doc,ctotcaomp_iva_doc,ciddetalleret FROM VST_COMPROBANRET_REPORT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Txt_ComprobRetId.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _DRow["cretenido_doc"] = Convert.ToDouble(_DRow["cretenido_doc"]).ToString("#,##0.00");
                Array.Copy(_DRow.ItemArray, _Str_RowNew, _DRow.ItemArray.Length);
                _Dg_Doc.Rows.Add(_Str_RowNew);
                _Dg_Doc[4, _Dg_Doc.RowCount - 1].Value = Convert.ToDouble(_Dg_Doc[4, _Dg_Doc.RowCount - 1].Value).ToString("#,##0.00");
            }
            _Dg_Doc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_TotRetenido.Text = _Mtd_ObtenerTotal().ToString("#,##0.00");
        }

        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Bt_Print.Enabled = false;
            _Bt_Comprobante.Enabled = false;
            _Tb_Tab.SelectTab(1);
            _Str_MyProceso = "M";
        }

        private void _Cb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount >= 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarData(Convert.ToString(_Dg_Grid[0, e.RowIndex].Value));
                _Bt_Comprobante.Enabled = true;
                _Bt_Print.Enabled = true;
                _Bol_Validar = true;
                _Tb_Tab.SelectTab(1);
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
            }
        }
        private bool _Mtd_Anulado(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprobret FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "' AND canulado = 1";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Imprimir()
        {
            try
            {
                string _Str_Sql = "";
                int _Int_Sw = 0;
                REPORTESS _Frm;
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    if (_Mtd_Anulado(_Txt_ComprobRetId.Text.Trim()))
                    {
                        _Str_Sql = "SELECT cidcomprob,cidcomprobanul FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Txt_ComprobRetId.Text.Trim() + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            string _Str_cidcomprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                            string _Str_cidcomprobanul = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
                            if (_Str_cidcomprob.Trim().Length == 0) { _Str_cidcomprob = "0"; }
                            if (_Str_cidcomprobanul.Trim().Length == 0) { _Str_cidcomprobanul = "0"; }
                            //------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Frm = new REPORTESS(new string[] { "VST_COMPROBANRET_REPORT" }, "", "T3.Report.rComprobRetencion", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Txt_ComprobRetId.Text + "'", _Print, true);
                            Cursor = Cursors.Default;
                            _Frm.ShowDialog();
                            if (MessageBox.Show("¿El comprobante de retención se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                                goto _PrintComprob;
                            }
                            //------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' AND (cidcomprob='" + _Str_cidcomprob + "' OR cidcomprob='" + _Str_cidcomprobanul + "')", _Print, true);
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿El comprobante contable se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                                goto _PrintComprob;
                            }
                            //------------------------------
                        }
                    }
                    else
                    {
                        if (_Int_Sw == 0 | _Int_Sw == 1)
                        {
                            Cursor = Cursors.WaitCursor;
                            _Frm = new REPORTESS(new string[] { "VST_COMPROBANRET_REPORT" }, "", "T3.Report.rComprobRetencion", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Txt_ComprobRetId.Text + "' AND cproveedor='" + _Str_FrmProvId + "'", _Print, true);
                            Cursor = Cursors.Default;
                            _Frm.ShowDialog();
                            if (MessageBox.Show("¿El comprobante de retención se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                                _Int_Sw = 1;
                                goto _PrintComprob;
                            }
                            else
                            { _Int_Sw = 0; }
                        }
                        if (!_Chk_Anulados.Checked)
                        {
                            if (_Int_Sw == 0 | _Int_Sw == 2)
                            {
                                if (_Int_Sw == 0)
                                { MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Int_Sw = 2; goto _PrintComprob; }
                                Cursor = Cursors.WaitCursor;
                                _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_FrmComprobante + "'", _Print, true);
                                Cursor = Cursors.Default;
                                if (MessageBox.Show("¿El comprobante contable se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    _Frm.Close();
                                    _Frm.Dispose();
                                    goto _PrintComprob;
                                }
                            }
                            if (_Int_FrmImpreso == 0)
                            {
                                if (!_Mtd_ComprobActualizado(_Str_FrmComprobante))
                                {
                                    if (MessageBox.Show("¿Desea cerrar la Retención y actualizar el comprobante contable?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        _Str_Sql = "Update TCOMPROBANC set cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob=" + _Str_FrmComprobante;
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                        _Str_Sql = "Update TCOMPROBANRETC Set cimpreso=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Txt_ComprobRetId.Text + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. Debe intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void _Bt_Print_Click(object sender, EventArgs e)
        {
            _Mtd_Imprimir();
        }
        private bool _Mtd_ComprobActualizado(string _P_Str_Comprob)
        {
            string _Str_Cadena = "SELECT cstatus FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprob + "' AND cstatus='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_CargarProveedoresFind()
        {
            string _Str_Sql = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "') OR (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "')) ORDER BY c_nomb_abreviado";
            _Cb_ProveeFind.SelectedIndexChanged -= new EventHandler(_Cb_ProveeFind_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_ProveeFind, _Str_Sql);
            _Cb_ProveeFind.SelectedIndexChanged += new EventHandler(_Cb_ProveeFind_SelectedIndexChanged);
        }

        private void _Mtd_CargarBusqueda()
        {
            string _Str_Sql = "";
            object[] _Str_RowNew = new object[5];
            _Str_Sql = "Select cidcomprobret as Código,c_nomb_comer as Proveedor,cporcretiene as [% Retenido],dbo.Fnc_Formatear(cretenido) as Retenido,cimpreso_descrip as Impreso from VST_COMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=" + Convert.ToInt32(_Chk_Anulados.Checked) + " AND ISNULL(cmanual,0)='0' AND NOT EXISTS(SELECT cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobret=VST_COMPROBANRETC.cidcomprobret AND cestatusfirma='1')";
            if (_Cb_ProveeFind.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " and cproveedor='" + Convert.ToString(_Cb_ProveeFind.SelectedValue) + "'"; }
            if (_Rb_SiFind.Checked)
            { _Str_Sql = _Str_Sql + " and cimpreso=1"; }
            else if (_Rb_NoFind.Checked)
            { _Str_Sql = _Str_Sql + " and cimpreso=0"; }

            _Str_Sql += " ORDER BY Código;";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Grid.Rows.Add(_Str_RowNew);
            }
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Tb_Tab.SelectedIndex = 0;
        }

        
        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_CargarBusqueda();
        }

        private void _Grb_Find_Enter(object sender, EventArgs e)
        {

        }

        private void _Cb_ProveeFind_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void _Chk_Anulados_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Anulados.Checked)
            {
                _Dg_Grid.Rows.Clear(); 
                _Rb_NoFind.Enabled = false;
                _Rb_SiFind.Enabled = false;
                _Rb_NoFind.Checked = false;
                _Rb_SiFind.Checked = false;
            }
            else
            {
                _Rb_NoFind.Enabled = true;
                _Rb_SiFind.Enabled = true;
                _Rb_SiFind.Checked = true;
            }
        }
        bool _Bol_Validar = false;
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1 & !_Bol_Validar)
            { e.Cancel = true; }
            else if (e.TabPageIndex == 0)
            { _Bol_Validar = false; }
        }

        private void _Rb_SiFind_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SiFind.Checked)
            { _Dg_Grid.Rows.Clear(); }
        }

        private void _Rb_NoFind_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_NoFind.Checked)
            { _Dg_Grid.Rows.Clear(); }
        }
        private bool _Mtd_VerificarCompRetenEnOrdPago(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT ctipdocretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_TipoDocIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
            _Str_Cadena = "SELECT TPAGOSCXPM.cidordpago FROM TPAGOSCXPM INNER JOIN TPAGOSCXPD ON TPAGOSCXPM.cgroupcomp = TPAGOSCXPD.cgroupcomp AND TPAGOSCXPM.ccompany = TPAGOSCXPD.ccompany AND TPAGOSCXPM.cidordpago = TPAGOSCXPD.cidordpago AND TPAGOSCXPM.cproveedor = TPAGOSCXPD.cproveedor WHERE (TPAGOSCXPM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPAGOSCXPM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TPAGOSCXPD.ctipodocument = '" + _Str_TipoDocIVA + "') AND (TPAGOSCXPD.cnumdocu = '" + _P_Str_ComprobRetencion + "') AND (TPAGOSCXPM.canulado = 0)";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarComprobRETENImpreso(string _P_Str_ComprobRetencion)
        {
            bool _Bol_Valido = true;
            //Se verifica que no tenga orden de pago hecha
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            string _Str_TipoDocIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
            string _Str_Cadena = "SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cordenpaghecha='1' AND CNUMDOCU='" + _P_Str_ComprobRetencion + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                _Bol_Valido = false;
            }
            if (_Bol_Valido)
            {
                _Str_Cadena = "SELECT cordenpaghecha FROM TFACTPPAGARM WHERE csaldo<>0 AND CNUMDOCU='" + _P_Str_ComprobRetencion + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count < 2)
                {
                    _Bol_Valido = false;
                }
            }
            return _Bol_Valido;
        }
        private bool _Mtd_VerificarMesComprobanteRETEN(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TCOMPROBANRETC INNER JOIN TCOMPROBANC ON TCOMPROBANRETC.ccompany = TCOMPROBANC.ccompany AND TCOMPROBANRETC.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TCOMPROBANRETC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCOMPROBANRETC.cidcomprobret = '" + _P_Str_ComprobRetencion + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private DateTime _Mtd_FechaEmision(string _P_Str_ID_Fact_CxP)
        {
            string _Str_Cadena = "SELECT cfechaemision FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Fact_CxP + "'";
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
        private string _Mtd_Proveedor(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cproveedor FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        public void _Mtd_InsertarAuxiliar(string _P_Str_Comprobante, string _P_Str_Proveedor,string _P_Str_ID_FacturaCxP)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            DateTime _Dtm_FechaEmi = _Mtd_FechaEmision(_P_Str_ID_FacturaCxP);
            DateTime _Dtm_FechaVenc = _Mtd_FechaVencimiento(_P_Str_ID_FacturaCxP);
            double _Dbl_Monto = 0;
            string _Str_Cadena = "SELECT cidcomprob,ccount,cdescrip,ctdocument,cnumdocu,CASE WHEN ctotdebe>0 THEN ctotdebe ELSE ctothaber END AS Monto,CASE WHEN ctotdebe>0 THEN 'D' ELSE 'H' END AS Naturaleza FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dbl_Monto = Convert.ToDouble(_Row["Monto"].ToString().Trim());
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row["ccount"].ToString().Trim(), _P_Str_Proveedor, _Row["cdescrip"].ToString().Trim(), _Row["ctdocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _Cls_Formato._Mtd_fecha(_Dtm_FechaEmi), _Cls_Formato._Mtd_fecha(_Dtm_FechaVenc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["Naturaleza"].ToString().Trim().ToUpper());
            }
        }
        private string _Mtd_Obtener_ID_Fact_CxP(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        private void _Mtd_Anular(string _P_Str_ComprobRetencion)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_ID_Fact_CxP = _Mtd_Obtener_ID_Fact_CxP(_P_Str_ComprobRetencion);
                if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                {
                    string _Str_Id_ComprobAnul = myUtilidad._Mtd_CrearComprobanteAnulacion(_Str_Id_Comprob);
                    _Str_Cadena = "UPDATE TCOMPROBANRETC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "UPDATE TCOMPROBANRETC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //--------
                    _Mtd_InsertarAuxiliar(_Str_Id_ComprobAnul,_Mtd_Proveedor(_P_Str_ComprobRetencion), _Str_ID_Fact_CxP);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_Comprob + "' and cstatus='0'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_ComprobAnul + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                _Str_Cadena = "UPDATE TCOMPROBANRETC SET canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //--------RETENCIÓN EXTERNA
                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                {
                    _Str_Cadena = "UPDATE TCOMPROBANRETC SET canulado=1,cimpreso='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                    Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                //--------
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                string _Str_TipoDocIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _P_Str_ComprobRetencion + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _P_Str_ComprobRetencion + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente. Se van a imprimir los comprobantes contables.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Imprimir();
            }
        }

        private bool _Mtd_CuentasInactivas(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                if (myUtilidad._Mtd_CuentasInactivas(_Str_Comprobante))
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

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Txt_ComprobRetId.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim();
                if (_Mtd_VerificarComprobRETENImpreso(_Txt_ComprobRetId.Text))
                {
                    if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                    {
                        if (_Mtd_CuentasInactivas(_Txt_ComprobRetId.Text))
                            return;
                        _Mtd_Anular(_Txt_ComprobRetId.Text); _Mtd_CargarBusqueda();
                    }
                    else
                    {
                        MessageBox.Show("Problemas de conexión para anular la retención. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                { MessageBox.Show("No se puede anular la retención porque ha sido cerrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Cntx_Contex_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0  | _Chk_Anulados.Checked | !(myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANULAR_RETENCIONES"));
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarMesComprobanteRETEN(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()))
            { _Pnl_Clave.Visible = true; }
            else
            { MessageBox.Show("No es posible anular la retención ya que el mes contable del comprobante de la retención no es igual al mes contable actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}