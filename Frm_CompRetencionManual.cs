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
    public partial class Frm_CompRetencionManual : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_ValorCeldaTem = "XXXX";
        DataGridViewCell _Dg_Cel;
        string _Str_CompanyRetenExterna = "";
        bool _Bol_CompRetiene = false;
        int _Int_Sw = 0;
        bool _Bol_Notificador = false;
        public Frm_CompRetencionManual()
        {
            InitializeComponent();
            _Mtd_CargarTipoProv(_Cmb_TipoProv);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
            _Bol_CompRetiene = _Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp);
        }

        public Frm_CompRetencionManual(string _P_Str_ComprobRetencion)
        {
            InitializeComponent();
            _Mtd_CargarTipoProv(_Cmb_TipoProv);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
            _Bol_CompRetiene = _Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp);
            _Mtd_CargarFormulario(_P_Str_ComprobRetencion);
            _Bol_Notificador = true;
        }

        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                else
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }

        private void _Mtd_CargarTipoProv(ComboBox _P_Cmb_TipoProv)
        {
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
            _P_Cmb_TipoProv.SelectedIndex = 1;
        }

        private void _Mtd_CargarCategProv(ComboBox _P_Cmb_CategProv, ComboBox _P_Cmb_TipoProv)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_P_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _P_Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_CategProv, _Str_Cadena);
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarProvee(ComboBox _P_Cmb_Proveedor, ComboBox _P_Cmb_CategProv, ComboBox _P_Cmb_TipoProv)
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
            _Str_Cadena += " UNION ";
            _Str_Cadena += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer ";
            _Str_Cadena += " FROM TPROVEEDOR INNER JOIN ";
            _Str_Cadena += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
            _Str_Cadena += " WHERE ";
            _Str_Cadena += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_comer";

            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "Select cidcomprobret as Código,c_nomb_comer as Proveedor,cporcretiene as [% Retenido],dbo.Fnc_Formatear(cretenido) as Retenido,cimpreso_descrip as Impreso from VST_COMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmanual='1'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
                _Str_Cadena += " AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'";
            if (_Cmb_CategProv.SelectedIndex > 0)
                _Str_Cadena += " AND ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'";
            if (_Cmb_Proveedor.SelectedIndex > 0)
                _Str_Cadena += " AND cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString().Trim() + "'";
            if (_Rb_Impresos.Checked)
                _Str_Cadena += " AND cimpreso=1 AND ISNULL(canulado,0)=0";
            else if (_Rb_NoImpresos.Checked)
                _Str_Cadena += " AND ISNULL(cimpreso,0)=0 AND ISNULL(canulado,0)=0";
            else
                _Str_Cadena += " AND canulado=1";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["% Retenido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Retenido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Impreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_CargarTipoProv(_Cmb_TipoProvD);
            _Mtd_CargarCategProv(_Cmb_CategProvD, _Cmb_TipoProvD);
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Mtd_InicializarFormulario();
            _Mtd_Hab_Deshab_Controles(false);
            _Cmb_CategProvD.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }

        public void _Mtd_Ini()
        {
            _Pnl_Clave.Visible = false;
            _Tb_Tab.SelectedIndex = 0;
        }

        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            var _Bol_Error = false;
            if (_Cmb_CategProvD.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cmb_CategProvD, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (_Cmb_ProveedorD.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cmb_ProveedorD, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (!_Rb_75.Checked && !_Rb_100.Checked)
            {
                MessageBox.Show("El proveedor seleccionado no genera comprobante de reteción. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_Str_Proveedor))
            {
                MessageBox.Show("El proveedor seleccionado es de intercompañías, por lo tanto no genera retención. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (_Bol_Error)
                return false;
            if (_Rb_NC.Checked && !_Mtd_VerifContTextBoxVarcharNoCero(_Txt_DocAfect))
            {
                _Er_Error.SetError(_Txt_DocAfect, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (_Rb_NC.Checked && !_Mtd_DocumentoExistente(_Str_Proveedor, _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact"), _Txt_DocAfect.Text.Trim()))
            {
                MessageBox.Show("El documento afectado que introdujo no existe para el proveedor seleccionado. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Rb_NC.Checked)
            {
                string _Str_TipoDocFact = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
                var _Dbl_MontoRetanteOp = _Cls_VariosMetodos._Mtd_ObtenerAbonoOrdPago(_Txt_DocAfect.Text.Trim(), _Str_TipoDocFact, _Str_Proveedor);
                if (_Dbl_MontoRetanteOp > 0)
                {
                    MessageBox.Show("No se puede generar la retención. Ya se le ha generado orden de pago al documento afectado que introdujo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Documento))
            {
                _Er_Error.SetError(_Txt_Documento, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (_Mtd_DocumentoExistente(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag), _Txt_Documento.Text))
            {
                MessageBox.Show("No se puede generar la retención. El documento que introdujo existe en las cuentas por pagar para el proveedor seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Mtd_RetencionExistente(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag), _Txt_Documento.Text))
            {
                MessageBox.Show("Ya existe una retención para el documento del proveedor seleccionado. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!_Chk_FactMaqFis.Checked && !_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl))
            {
                _Er_Error.SetError(_Txt_NumCtrl, "Información requerida!!!");
                _Bol_Error = true;
            }
            if (!_Mtd_VerifContTextBoxNumeric(_Txt_BaseImpon))
            {
                _Er_Error.SetError(_Txt_BaseImpon, "Información requerida!!!");
                _Bol_Error = true;
            }
            else if (!_Mtd_VerifContTextBoxNumeric(_Txt_MontoRetenido))
            {
                MessageBox.Show("El monto a retener no puede ser igual a cero.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (_Bol_Error)
                return false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            _Int_Sw = 1;
            _Pnl_Clave.Visible = true;
            return false;
        }

        private void _Mtd_InicializarFormulario()
        {
            _Str_Proveedor = "";
            _Rb_Fact.Checked = true;
            _Rb_75.Checked = false;
            _Rb_100.Checked = false;
            _Chk_FactMaqFis.Checked = false;
            _Txt_DocAfect.Text = "";
            _Txt_Documento.Text = "";
            _Txt_NumCtrlPref.Text = "";
            _Txt_NumCtrl.Text = "";
            _Txt_BaseImpon.Text = "";
            _Txt_MontoExcento.Text = "";
            _Txt_Total.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_Alicuota.Text = _Mtd_OptenerImpuesto();           
            _Dtp_Emision.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Vencimiento.MinDate = _Dtp_Emision.Value.AddDays(1);
            _Dtp_Vencimiento.Value = _Dtp_Emision.Value.AddDays(1);
            _Dtp_EmisionComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Mtd_EstablecerTipDocument();
            _Rb_ConIva.Checked = true;
            _Bol_Notificador = false;
        }

        private void _Mtd_Hab_Deshab_Controles(bool _P_Bol_Valor)
        {
            _Rb_Fact.Enabled = _P_Bol_Valor;
            _Rb_ND.Enabled = _P_Bol_Valor;
            _Rb_NC.Enabled = _P_Bol_Valor;
            _Txt_DocAfect.Enabled = false;
            _Txt_Documento.Enabled = _P_Bol_Valor;
            _Chk_FactMaqFis.Enabled = _P_Bol_Valor;
            _Txt_NumCtrlPref.Enabled = _P_Bol_Valor;
            _Txt_NumCtrl.Enabled = _P_Bol_Valor;
            _Dtp_Emision.Enabled = _P_Bol_Valor;
            _Dtp_Vencimiento.Enabled = _P_Bol_Valor;
            _Bt_Imprimir.Enabled = false;
            _Bt_ComprobRetenc.Enabled = false;
            _Rb_ConIva.Enabled = _P_Bol_Valor;
            _Rb_Varias.Enabled = _P_Bol_Valor;
            _Bt_Alicuota.Enabled = _P_Bol_Valor;
            _Txt_BaseImpon.Enabled = _P_Bol_Valor;
            _Txt_MontoExcento.Enabled = _P_Bol_Valor;
        }

        private void _Mtd_EstablecerTipDocument()
        {
            string _Str_Cadena = "";
            if (_Rb_Fact.Checked)
            { _Str_Cadena = "SELECT TCONFIGCXP.ctipdocfact, TDOCUMENT.cname FROM TCONFIGCXP INNER JOIN TDOCUMENT ON TCONFIGCXP.ctipdocfact = TDOCUMENT.ctdocument WHERE TCONFIGCXP.ccompany='" + Frm_Padre._Str_Comp + "'"; }
            else if (_Rb_ND.Checked)
            { _Str_Cadena = "SELECT TCONFIGCXP.ctipodocndp, TDOCUMENT.cname FROM TCONFIGCXP INNER JOIN TDOCUMENT ON TCONFIGCXP.ctipodocndp = TDOCUMENT.ctdocument WHERE TCONFIGCXP.ccompany='" + Frm_Padre._Str_Comp + "'"; }
            else
            { _Str_Cadena = "SELECT TCONFIGCXP.ctipodocncp, TDOCUMENT.cname FROM TCONFIGCXP INNER JOIN TDOCUMENT ON TCONFIGCXP.ctipodocncp = TDOCUMENT.ctdocument WHERE TCONFIGCXP.ccompany='" + Frm_Padre._Str_Comp + "'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_TipoDoc.Tag = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Txt_TipoDoc.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            else
            {
                _Txt_TipoDoc.Tag = "";
                _Txt_TipoDoc.Text = "";
            }
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

        private void _Mtd_ProveedorRetenConfig(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT ISNULL(cporcenreteniva,0) FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "75")
                { _Rb_75.Checked = true; }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "100")
                { _Rb_100.Checked = true; }
            }
        }

        private void _Mtd_ConfigurarPanelImpuestos()
        {
            _Lbl_Separador2.Visible = false;
            _Bt_Alicuota.Visible = false;
            _Txt_Alicuota.Visible = false;
            _Lbl_Separador1.Visible = false;
            _Lbl_Alicuota.Visible = false;
            _Bt_Varias.Visible = false;
            _Txt_BaseImpon.Enabled = false;
            _Rb_100.Checked = false;
            _Rb_75.Checked = false;
            _Txt_Alicuota.Text = "";
            _Txt_BaseImpon.Text = "";
            _Txt_MontoExcento.Text = "";
            _Txt_Total.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_MontoRetenido.Text = "";
            if (_Rb_ConIva.Checked) 
            { _Lbl_Separador2.Visible = true; _Bt_Alicuota.Visible = true; _Lbl_Separador1.Visible = true; _Txt_Alicuota.Visible = true; _Lbl_Alicuota.Visible = true; _Txt_BaseImpon.Enabled = true; _Txt_Alicuota.Text = _Mtd_OptenerImpuesto(); _Mtd_ProveedorRetenConfig(_Str_Proveedor);}
            else 
            { _Bt_Varias.Visible = true; _Pnl_Varias.Visible = true; _Mtd_ProveedorRetenConfig(_Str_Proveedor); }
        }

        private bool _Mtd_VerificarGridImpuesto()
        {
            bool _Bol_Sw = false;
            object _Ob_BaseImponible = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Impuestos.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    _Bol_Sw = true;
                    _Ob_BaseImponible = _Dg_Row.Cells[2].Value;
                    if (_Ob_BaseImponible == null)
                    { _Ob_BaseImponible = 0; }
                    else if (_Ob_BaseImponible.ToString().Trim().Length == 0)
                    { _Ob_BaseImponible = 0; }
                    if (Convert.ToDouble(_Ob_BaseImponible) <= 0)
                    { return false; }
                }
            }
            return _Bol_Sw;
        }

        private double _Mtd_Invendible(string _P_Str_TipoProv, string _P_Str_Proveedor)
        {
            if (_P_Str_TipoProv == "1")
            {
                if (!_Chk_AplicaInvend.Checked)
                { return 0; }
                string _Str_Cadena = "SELECT ISNULL(cporcinvendible,0) FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND cglobal='1'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                }
            }
            return 0;
        }

        private void _Mtd_CalcularImpuesto(int _P_Int_RowIndex)
        {
            double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
            double _Dbl_InvendibleD = 0;
            object _Ob_Alicuota = _Dg_Impuestos.Rows[_P_Int_RowIndex].Cells[0].Value;
            object _Ob_BaseImponible = _Dg_Impuestos.Rows[_P_Int_RowIndex].Cells[2].Value;
            if (Convert.ToString(_Ob_Alicuota).Trim().Length == 0) { _Ob_Alicuota = "0"; }
            if (Convert.ToString(_Ob_BaseImponible).Trim().Length == 0) { _Ob_BaseImponible = "0"; }
            //---------------------------
            _Dbl_InvendibleD = Math.Round(((Convert.ToDouble(_Ob_BaseImponible) * _Dbl_Invendible) / 100), 2);
            //---------------------------
            double _Dbl_Impuesto = ((Convert.ToDouble(_Ob_BaseImponible) - _Dbl_InvendibleD) * Convert.ToDouble(_Ob_Alicuota)) / 100;
            _Dg_Impuestos.Rows[_P_Int_RowIndex].Cells[3].Value = _Dbl_Impuesto.ToString("#,##0.00");
            if (_Dbl_Impuesto > 0)
            {
                if (_Dg_Impuestos.CurrentCell.RowIndex == _Dg_Impuestos.RowCount - 1)
                {
                    _Dg_Impuestos.Rows.Add();
                    _Dg_Cel = _Dg_Impuestos.Rows[_Dg_Impuestos.RowCount - 1].Cells[1];
                    try
                    { _Dg_Impuestos.CurrentCell = _Dg_Cel; }
                    catch { }
                }
                else
                {
                    _Dg_Cel = _Dg_Impuestos.Rows[_Dg_Impuestos.CurrentCell.RowIndex + 1].Cells[1];
                    try { _Dg_Impuestos.CurrentCell = _Dg_Cel; }
                    catch { }
                }
            }
        }

        private void _Mtd_CalcularTotalesImpuestos()
        {
            double _Dbl_TotalImpuesto = 0;
            double _Dbl_TotalBaseImponible = 0;
            double _Dbl_TotalInvendible = 0;
            double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
            double _Dbl_InvendibleD = 0;
            object _Ob_Alicuota = new object();
            object _Ob_BaseImponible = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Impuestos.Rows)
            {
                _Dbl_InvendibleD = 0;
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_Alicuota = _Dg_Row.Cells[0].Value;
                        if (_Ob_Alicuota == null)
                        { _Ob_Alicuota = 0; }
                        else if (_Ob_Alicuota.ToString().Trim().Length == 0)
                        { _Ob_Alicuota = 0; }
                        //---------------------------
                        _Ob_BaseImponible = _Dg_Row.Cells[2].Value;
                        if (_Ob_BaseImponible == null)
                        { _Ob_BaseImponible = 0; }
                        else if (_Ob_BaseImponible.ToString().Trim().Length == 0)
                        { _Ob_BaseImponible = 0; }
                        //---------------------------
                        _Dbl_InvendibleD = Math.Round(((Convert.ToDouble(_Ob_BaseImponible) * _Dbl_Invendible) / 100), 2);
                        //---------------------------
                        _Dbl_TotalInvendible += _Dbl_InvendibleD;
                        _Dbl_TotalImpuesto += Math.Round(((Convert.ToDouble(_Ob_BaseImponible) - _Dbl_InvendibleD) * Convert.ToDouble(_Ob_Alicuota)) / 100, 2);
                        _Dbl_TotalBaseImponible += Convert.ToDouble(_Ob_BaseImponible);
                    }
                }
            }
            _Txt_Invendible.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_TotalInvendible).ToString();
            _Txt_Impuesto.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_TotalImpuesto).ToString();
            _Txt_BaseImpon.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_TotalBaseImponible).ToString();
        }

        private void _Mtd_EliminarNulosGridImpuesto()
        {
            if (_Dg_Impuestos.RowCount > 0)
            {
                object _Ob_BaseImponible = new object();
                if (Convert.ToString(_Dg_Impuestos.Rows[_Dg_Impuestos.RowCount - 1].Cells[0].Value).Trim().Length > 0)
                {
                    _Ob_BaseImponible = _Dg_Impuestos.Rows[_Dg_Impuestos.RowCount - 1].Cells[2].Value;
                    if (_Ob_BaseImponible == null)
                    { _Ob_BaseImponible = 0; }
                    else if (_Ob_BaseImponible.ToString().Trim().Length == 0)
                    { _Ob_BaseImponible = 0; }
                    if (Convert.ToDouble(_Ob_BaseImponible) <= 0)
                    {
                        _Dg_Impuestos.Rows.RemoveAt(_Dg_Impuestos.RowCount - 1);
                    }
                }
            }
        }

        private bool _Mtd_ExistenciaImpuesto(string _P_Str_ID_Impuesto, string _P_Str_ID_Alicuota, int _P_Int_Index)
        {
            foreach (DataGridViewRow _DgRow in _Dg_Impuestos.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Col_ID_Impuesto"].Value).Trim() == _P_Str_ID_Impuesto.Trim() && Convert.ToString(_DgRow.Cells["Alicuota"].Value).Trim() == _P_Str_ID_Alicuota.Trim() && _DgRow.Index != _P_Int_Index)
                {
                    return true;
                }
            }
            return false;
        }

        private void _Mtd_CentrarPaneles()
        {
            _Pnl_Varias.Size = new Size(361, 190);
            _Pnl_Varias.Left = (this.Width / 2) - (_Pnl_Varias.Width / 2);
            _Pnl_Varias.Top = (this.Height / 2) - (_Pnl_Varias.Height / 2);
            //-----------------
            _Pnl_Clave.Left = (Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void _Mtd_CalularMontos()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Alicuota = 0;
            double _Dbl_Impuesto = 0;
            double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
            //------------
            if (_Txt_BaseImpon.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImpon.Text); }
            //------------
            if (_Txt_MontoExcento.Text.Trim().Length > 0)
            { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExcento.Text); }
            //------------
            if (_Txt_Alicuota.Text.Trim().Length > 0)
            { _Dbl_Alicuota = Convert.ToDouble(_Txt_Alicuota.Text); }
            //------------
            if (_Txt_Impuesto.Text.Trim().Length > 0)
            { _Dbl_Impuesto = Convert.ToDouble(_Txt_Impuesto.Text); }
            //------------
            if (_Rb_ConIva.Checked)
            {
                _Dbl_Invendible = Convert.ToDouble(Math.Round(((_Dbl_BaseImpon + _Dbl_MontoExcento) * _Dbl_Invendible) / 100, 2));
                _Dbl_Impuesto = ((_Dbl_BaseImpon - _Dbl_Invendible) * _Dbl_Alicuota / 100);
                _Txt_Impuesto.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Impuesto).ToString();
                _Txt_Invendible.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Invendible).ToString();
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2((_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto) - _Dbl_Invendible).ToString();
            }
            else
            {
                double _Dbl_InvendibleD = 0;
                if (_Txt_Invendible.Text.Trim().Length > 0)
                { _Dbl_InvendibleD = Convert.ToDouble(_Txt_Invendible.Text); }
                //------------
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(((_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto) - _Dbl_InvendibleD)).ToString();
            }
            double _Dbl_Retencion = 0;
            if (_Rb_100.Checked)
            { _Dbl_Retencion = Convert.ToDouble(_Txt_Impuesto.Text); }
            else if (_Rb_75.Checked)
            { _Dbl_Retencion = Convert.ToDouble(_Txt_Impuesto.Text) * 0.75; }
            _Txt_MontoRetenido.Text = _Dbl_Retencion.ToString("#,##0.00");
        }

        /// <summary>
        /// Obtiene un valor que indica si el contedito de un TextBox esta validado
        /// </summary>
        /// <param name="_P_Txt_TextBox">TextBox que se va a verificar</param>
        /// <returns>bool</returns>
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
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

        private bool _Mtd_DocumentoExistente(string _P_Str_Proveedor, string _P_Str_TipoDocument, string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Documento + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_RetencionExistente(string _P_Str_Proveedor, string _P_Str_TipoDocument, string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT TCOMPROBANRETD.cnumdocu FROM TCOMPROBANRETC INNER JOIN TCOMPROBANRETD ON TCOMPROBANRETC.ccompany=TCOMPROBANRETD.ccompany AND TCOMPROBANRETC.cidcomprobret=TCOMPROBANRETD.cidcomprobret WHERE TCOMPROBANRETC.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETD.cproveedor='" + _P_Str_Proveedor + "' AND TCOMPROBANRETD.ctdocument='" + _P_Str_TipoDocument + "' AND TCOMPROBANRETD.cnumdocu='" + _P_Str_Documento + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private string _Mtd_NombAbrevProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_abreviado FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            return "";
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

        /// <summary>
        /// Verifica si la cuenta no existe y si el tipo de proveedor es de servicio o materia prima
        /// para retornar la cuenta del proveedor, sino es asi retorna la cuenta
        /// que trae el parametro
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Str_Global">Tipo de Proveedor</param>
        /// <returns></returns>
        private string[] _Mtd_ExtraerCuenta(string _P_Str_Cuenta, string _P_Str_Global, string _P_Str_Descripcion)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "0")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR INNER JOIN TCOUNT ON TPROVEEDOR.ctcount=TCOUNT.ccount AND TPROVEEDOR.ccompany=TCOUNT.ccompany WHERE TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString() }; }
                }
            }
            else if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "1")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR INNER JOIN TCOUNT ON TPROVEEDOR.ctcount=TCOUNT.ccount WHERE TPROVEEDOR.cglobal='1' AND cproveedor='" + _Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString() }; }
                }
            }
            return new string[] { _P_Str_Cuenta, _P_Str_Descripcion };
        }

        private int _Mtd_GenerarComprobRetenComp(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_CatCompRel, string _P_Str_CatAccion, double _P_Dbl_Retencion, string _P_Str_C_ID_ComprobRet)
        {
            string _Str_PROCESOCONTABLE = "";
            if (_P_Str_TipoProv.Trim() == "0")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_S_O";
            }
            else if (_P_Str_TipoProv.Trim() == "1")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_M";
            }
            else if (_P_Str_TipoProv.Trim() == "2" & _P_Str_CategProv.Trim().ToUpper() == _P_Str_CatCompRel.Trim().ToUpper())
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_C";
            }
            else if (_P_Str_TipoProv.Trim() == "2" & _P_Str_CategProv.Trim().ToUpper() == _P_Str_CatAccion.Trim().ToUpper())
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_S_O";
            }
            else
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_S_O";
            }
            //-------------------------------------------------------
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_PROCESOCONTABLE);
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------
            int _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','0','0')";//Preguntar si el cstatus se debe guardar en 0 ó en 1.
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            //-------------------------------------------------------
            int _Int_corder = 0;
            string _Str_Cuenta = "";
            string _Str_Descrip = "";
            string _Str_DescripD = "";
            string _Str_NombProveedor = _Mtd_NombAbrevProveedor(_Str_Proveedor);
            string _Str_TipoDocRecIVA = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva");
            string[] _Str_Cuenta_Descrip;
            _Str_Cadena = "select ccount,ctipodocumento,cnaturaleza,cideprocesod,ccountname from VST_PROCESOSCONTD where cidproceso='" + _Str_PROCESOCONTABLE + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_Cuenta_Descrip = _Mtd_ExtraerCuenta(_Row["ccount"].ToString(), _P_Str_TipoProv, _Row["ccountname"].ToString());
                _Str_Cuenta = _Str_Cuenta_Descrip[0];
                _Str_DescripD = _Str_Cuenta_Descrip[1];
                //-------------
                if (_Str_PROCESOCONTABLE == "P_CXP_COMP_RETEN_C")
                {
                    if (_Rb_Fact.Checked)
                    { _Str_Descrip = _Str_DescripD.Replace("COMPAÑÍAS RELACIONADAS", "").Replace("COMPAÑIAS RELACIONADAS", "") + " COMPAÑÍAS RELACIONADAS " + _Str_NombProveedor + " retención # " + _P_Str_C_ID_ComprobRet + " canc. fact. " + _Txt_Documento.Text.Trim().ToUpper(); }
                    else if (_Rb_ND.Checked)
                    { _Str_Descrip = _Str_DescripD.Replace("COMPAÑÍAS RELACIONADAS", "").Replace("COMPAÑIAS RELACIONADAS", "") + " COMPAÑÍAS RELACIONADAS " + _Str_NombProveedor + " retención # " + _P_Str_C_ID_ComprobRet + " canc. nd. " + _Txt_Documento.Text.Trim().ToUpper(); }
                    else
                    { _Str_Descrip = _Str_DescripD.Replace("COMPAÑÍAS RELACIONADAS", "").Replace("COMPAÑIAS RELACIONADAS", "") + " COMPAÑÍAS RELACIONADAS " + _Str_NombProveedor + " retención # " + _P_Str_C_ID_ComprobRet + " canc. nc. " + _Txt_Documento.Text.Trim().ToUpper(); }
                }
                else
                {
                    if (_Rb_Fact.Checked)
                    { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION # " + _P_Str_C_ID_ComprobRet + " S/F# " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Str_NombProveedor + " VEC:" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                    else if (_Rb_ND.Checked)
                    { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION # " + _P_Str_C_ID_ComprobRet + " S/N.D# " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Str_NombProveedor + " VEC:" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                    else
                    { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION # " + _P_Str_C_ID_ComprobRet + " S/N.C# " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Str_NombProveedor + " VEC:" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                }
                //-------------
                if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "D")
                { _Str_Cadena = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu," + (_Rb_NC.Checked ? "ctothaber" : "ctotdebe") + ",cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + _Int_corder.ToString() + "','" + _Str_Cuenta + "','" + _Str_TipoDocRecIVA + "','" + _P_Str_C_ID_ComprobRet + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')"; }
                else if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "H")
                { _Str_Cadena = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu," + (_Rb_NC.Checked ? "ctotdebe" : "ctothaber") + ",cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + _Int_corder.ToString() + "','" + _Str_Cuenta + "','" + _Str_TipoDocRecIVA + "','" + _P_Str_C_ID_ComprobRet + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if (_Rb_NC.Checked)
                {
                    string _Str_Naturaleza = _Row["cnaturaleza"].ToString().Trim().ToUpper() == "D" ? "H" : "D";
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Str_TipoDocRecIVA, _P_Str_C_ID_ComprobRet, _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Str_Naturaleza);
                }
                else
                { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Str_TipoDocRecIVA, _P_Str_C_ID_ComprobRet, _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["cnaturaleza"].ToString().Trim().ToUpper()); }
            }
            return _Int_Comprobante;
        }

        private int _Mtd_GuardarRetencion()
        {
            string _Str_Cadena;
            //-------------
            string _Str_CategoriaProveedor = "0";
            if (_Cmb_CategProvD.SelectedIndex > 0) { _Str_CategoriaProveedor = Convert.ToString(_Cmb_CategProvD.SelectedValue).Trim(); }
            //-------------
            _Txt_BaseImpon.TextChanged -= new EventHandler(_Txt_BaseImpon_TextChanged);
            if (_Txt_BaseImpon.Text.Trim().Length == 0) { _Txt_BaseImpon.Text = "0"; }
            _Txt_BaseImpon.TextChanged += new EventHandler(_Txt_BaseImpon_TextChanged);
            if (_Txt_MontoExcento.Text.Trim().Length == 0) { _Txt_MontoExcento.Text = "0"; }
            if (_Txt_Total.Text.Trim().Length == 0) { _Txt_Total.Text = "0"; }
            if (_Txt_Impuesto.Text.Trim().Length == 0) { _Txt_Impuesto.Text = "0"; }
            if (_Txt_Invendible.Text.Trim().Length == 0) { _Txt_Invendible.Text = "0"; }
            if (_Txt_Alicuota.Text.Trim().Length == 0) { _Txt_Alicuota.Text = "0"; }
            //--------------------------------------------------------------------
            string _Str_NumControl = _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper();
            //--------------------------------------------------------------------
            double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
            //--------------------------------------------------------------------
            string _Str_TipoDocRetIVA = "", _Str_ProvRetIVA = "", _Str_ProvRetIVA_Categoria = "",
                _Str_ProvRetIVA_Tipo = "", _Str_CatCompaRel = "", _Str_CatAccion = "";
            //---------------------------
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cprovretiva,ctipdocretiva,ccatproveciarel,ccatproveaccio FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TipoDocRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_ProvRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretiva"]);
                _Str_CatCompaRel = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]);
                _Str_CatAccion = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]);
            }
            //---------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveedor,cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Str_ProvRetIVA + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProvRetIVA_Categoria = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveedor"]);
                _Str_ProvRetIVA_Tipo = Convert.ToString(_Ds.Tables[0].Rows[0]["cglobal"]);
            }
            //---------------------------
            string _Str_CtipoTransac = "";
            double _Dbl_Retencion = 0;
            double _Dbl_Porc_Retencion = 0;
            //-------------------------
            int _Int_PorcReten = 100;
            if (_Rb_100.Checked)
            { _Dbl_Retencion = Convert.ToDouble(_Txt_Impuesto.Text); _Dbl_Porc_Retencion = 1; }
            else if (_Rb_75.Checked)
            { _Dbl_Retencion = Convert.ToDouble(_Txt_Impuesto.Text) * 0.75; _Dbl_Porc_Retencion = 0.75; _Int_PorcReten = 75; }
            //-------------------------
            if (_Dbl_Retencion > 0)
            {
                string _Str_C_ID_ComprobRet = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                //--------RETENCIÓN EXTERNA
                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                {
                    _Str_C_ID_ComprobRet = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETC WHERE ccompany='" + _Str_CompanyRetenExterna + "'");
                }
                //--------
                int _Int_ComprobRetencion = _Mtd_GenerarComprobRetenComp(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Str_CategoriaProveedor, _Str_CatCompaRel, _Str_CatAccion, _Dbl_Retencion, _Str_C_ID_ComprobRet);
                //-------------------------
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentgov FROM TDOCUMENT WHERE ctdocument='" + Convert.ToString(_Txt_TipoDoc.Tag) + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Str_CtipoTransac = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim(); }
                _Str_Cadena = "INSERT INTO TCOMPROBANRETC (ccompany,cidcomprobret,cidcomprob,cproveedor,cfechaemiret,cnumdocumafec,ctotcaomp_iva,ctotmontexcento,cimpuesto,cretenido,cimpreso,cascii,canulado,cfechavencret,cporcnreten,cdateadd,cuseradd,cmanual) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_C_ID_ComprobRet + "','" + _Int_ComprobRetencion + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion) + "','0','0','0','" + _Cls_VariosMetodos._Mtd_ObtenerFechaLimite(_Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value)) + "','" + _Int_PorcReten + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','1')";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                //--------RETENCIÓN EXTERNA
                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                {
                    _Str_Cadena = "INSERT INTO TCOMPROBANRETC (ccompany,cidcomprobret,cidcomprob,cproveedor,cfechaemiret,cnumdocumafec,ctotcaomp_iva,ctotmontexcento,cimpuesto,cretenido,cimpreso,cascii,canulado,cfechavencret,cporcnreten,cagregacomp,cdateadd,cuseradd,cmanual) VALUES ('" + _Str_CompanyRetenExterna + "','" + _Str_C_ID_ComprobRet + "','" + _Int_ComprobRetencion + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion) + "','1','0','0','" + _Cls_VariosMetodos._Mtd_ObtenerFechaLimite(_Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value)) + "','" + _Int_PorcReten + "','" + Frm_Padre._Str_Comp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','1')";
                    Program._MyClsCnn._Mtd_ConexionExterna._Mtd_RetornarDataset(_Str_Cadena);
                }
                //--------
                //-------------------------
                //CUENTA POR PAGAR DEL PROVEEDOR QUE ES AGENTE DEL IVA
                string _Str_ID_Factura_CxP_RETEN = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_RETEN + "','" + _Str_ProvRetIVA + "','" + _Str_TipoDocRetIVA + "','" + _Str_C_ID_ComprobRet + "','0','" + _Str_ProvRetIVA_Tipo + "','" + _Str_ProvRetIVA_Categoria + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','0',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion * -1 : _Dbl_Retencion) + "','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion * -1 : _Dbl_Retencion) + "','0','" + _Int_ComprobRetencion.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ProvRetIVA + "','" + _Str_TipoDocRetIVA + "','" + _Str_C_ID_ComprobRet + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion * -1 : _Dbl_Retencion) + "','0','" + _Int_ComprobRetencion.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion * -1 : _Dbl_Retencion) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //---------------------------
                //CUENTA POR PAGAR DEL PROVEEDOR QUE SE LE DESCUENTA
                string _Str_ID_Factura_CxP_RETEN_Prov = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_RETEN_Prov + "','" + _Str_Proveedor + "','" + _Str_TipoDocRetIVA + "','" + _Str_C_ID_ComprobRet + "','0','" + _Cmb_TipoProvD.SelectedValue.ToString().Trim() + "','" + _Str_CategoriaProveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','0',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion : _Dbl_Retencion * -1) + "','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion : _Dbl_Retencion * -1) + "','0','" + _Int_ComprobRetencion.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Proveedor + "','" + _Str_TipoDocRetIVA + "','" + _Str_C_ID_ComprobRet + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion : _Dbl_Retencion * -1) + "','0','" + _Int_ComprobRetencion.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Rb_NC.Checked ? _Dbl_Retencion : _Dbl_Retencion * -1) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //-------------------------
                if (_Rb_ConIva.Checked)
                {
                    string _Str_C_ID_ComprobRet_D = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetalleret) FROM TCOMPROBANRETD WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Str_C_ID_ComprobRet + "'");
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_C_ID_ComprobRet_D = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(ciddetalleret) FROM TCOMPROBANRETD WHERE ccompany='" + _Str_CompanyRetenExterna + "' and cidcomprobret='" + _Str_C_ID_ComprobRet + "'");
                    }
                    //--------
                    _Str_Cadena = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,ciddetalleret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,cdateadd,cuseradd,ctotmontexcento,cdocumentafect) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_C_ID_ComprobRet + "','" + _Str_C_ID_ComprobRet_D + "','" + _Str_Proveedor + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Str_NumControl + "','" + _Str_CtipoTransac + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text) - Convert.ToDouble(_Txt_Invendible.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alicuota.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + _Txt_DocAfect.Text.Trim().ToUpper() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,ciddetalleret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,cdateadd,cuseradd,ctotmontexcento,cdocumentafect) VALUES ('" + _Str_CompanyRetenExterna + "','" + _Str_C_ID_ComprobRet + "','" + _Str_C_ID_ComprobRet_D + "','" + _Str_Proveedor + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Str_NumControl + "','" + _Str_CtipoTransac + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text) - Convert.ToDouble(_Txt_Invendible.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alicuota.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + _Txt_DocAfect.Text.Trim().ToUpper() + "')";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_RetornarDataset(_Str_Cadena);
                    }
                    //--------
                }
                else if (_Rb_Varias.Checked)
                {
                    string _Str_C_ID_ComprobRet_D = "";
                    double _Dbl_Impuesto = 0;
                    double _Dbl_Total_D = 0;
                    double _Dbl_Retencion_D = 0;
                    object _Ob_Alicuota = new object();
                    object _Ob_BaseImponible = new object();
                    double _Dbl_InvendibleD = 0;
                    double _Dbl_MontoExcentoD = Convert.ToDouble(_Txt_MontoExcento.Text);
                    foreach (DataGridViewRow _Dg_Row in _Dg_Impuestos.Rows)
                    {
                        if (_Dg_Row.Cells[0].Value != null)
                        {
                            if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                            {
                                _Ob_Alicuota = _Dg_Row.Cells[0].Value; if (_Ob_Alicuota == null) { _Ob_Alicuota = 0; } else if (_Ob_Alicuota.ToString().Trim().Length == 0) { _Ob_Alicuota = 0; }
                                //---------------------------
                                _Ob_BaseImponible = _Dg_Row.Cells[2].Value; if (_Ob_BaseImponible == null) { _Ob_BaseImponible = 0; } else if (_Ob_BaseImponible.ToString().Trim().Length == 0) { _Ob_BaseImponible = 0; }
                                //---------------------------
                                _Dbl_InvendibleD = Math.Round(((Convert.ToDouble(_Ob_BaseImponible) * _Dbl_Invendible) / 100), 2);
                                //---------------------------
                                _Dbl_Impuesto = Math.Round(((Convert.ToDouble(_Ob_BaseImponible) - _Dbl_InvendibleD) * Convert.ToDouble(_Ob_Alicuota)) / 100, 2);
                                _Dbl_Total_D = (Convert.ToDouble(_Ob_BaseImponible) - _Dbl_InvendibleD) + _Dbl_MontoExcentoD + _Dbl_Impuesto;
                                _Dbl_Retencion_D = _Dbl_Porc_Retencion * _Dbl_Impuesto;
                                //---------------------------
                                _Str_C_ID_ComprobRet_D = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetalleret) FROM TCOMPROBANRETD WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Str_C_ID_ComprobRet + "'");
                                //--------RETENCIÓN EXTERNA
                                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                                {
                                    _Str_C_ID_ComprobRet_D = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(ciddetalleret) FROM TCOMPROBANRETD WHERE ccompany='" + _Str_CompanyRetenExterna + "' and cidcomprobret='" + _Str_C_ID_ComprobRet + "'");
                                }
                                //--------
                                _Str_Cadena = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,ciddetalleret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,cdateadd,cuseradd,ctotmontexcento,cdocumentafect) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_C_ID_ComprobRet + "','" + _Str_C_ID_ComprobRet_D + "','" + _Str_Proveedor + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Str_NumControl + "','" + _Str_CtipoTransac + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_BaseImponible)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_Alicuota)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion_D) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcentoD) + "','" + _Txt_DocAfect.Text.Trim().ToUpper() + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                //--------RETENCIÓN EXTERNA
                                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                                {
                                    _Str_Cadena = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,ciddetalleret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,cdateadd,cuseradd,ctotmontexcento,cdocumentafect) VALUES ('" + _Str_CompanyRetenExterna + "','" + _Str_C_ID_ComprobRet + "','" + _Str_C_ID_ComprobRet_D + "','" + _Str_Proveedor + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Str_NumControl + "','" + _Str_CtipoTransac + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_BaseImponible)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_Alicuota)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion_D) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcentoD) + "','" + _Txt_DocAfect.Text.Trim().ToUpper() + "')";
                                    Program._MyClsCnn._Mtd_ConexionExterna._Mtd_RetornarDataset(_Str_Cadena);
                                }
                                _Dbl_MontoExcentoD = 0;
                                //--------
                            }
                        }
                    }
                }
                //-------------------------
                _Str_Cadena = "UPDATE TCOMPROBANC SET cidcomprobret='" + _Str_C_ID_ComprobRet + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_ComprobRetencion + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                //-------------------------
                int _Int_Retencion = 0;
                int.TryParse(_Str_C_ID_ComprobRet, out _Int_Retencion);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                return _Int_Retencion;
            }
            return 0;
        }

        private bool _Mtd_Anulado(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprobret FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "' AND canulado = 1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_ComprobActualizado(string _P_Str_Comprob)
        {
            string _Str_Cadena = "SELECT cstatus FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprob + "' AND cstatus='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_VerificarMesComprobanteReten(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TCOMPROBANRETC INNER JOIN TCOMPROBANC ON TCOMPROBANRETC.ccompany = TCOMPROBANC.ccompany AND TCOMPROBANRETC.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TCOMPROBANRETC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCOMPROBANRETC.cidcomprobret = '" + _P_Str_ComprobRetencion + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_VerificarComprobRetenImpreso(string _P_Str_ComprobRetencion)
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

        private string _Mtd_ComprobanteContableRetencion(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
                return _Ds.Tables[0].Rows[0][0].ToString();
            return "";
        }

        private bool _Mtd_CuentasInactivas(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                if (_Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_Comprobante))
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

        public void _Mtd_InsertarAuxiliar(string _P_Str_Comprobante, string _P_Str_Proveedor, string _P_Str_FechaEmision, string _P_Str_FechaVencimiento)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            DateTime _Dtm_FechaEmi = Convert.ToDateTime(_P_Str_FechaEmision);
            DateTime _Dtm_FechaVenc = Convert.ToDateTime(_P_Str_FechaVencimiento);
            double _Dbl_Monto = 0;
            string _Str_Cadena = "SELECT cidcomprob,ccount,cdescrip,ctdocument,cnumdocu,CASE WHEN ctotdebe>0 THEN ctotdebe ELSE ctothaber END AS Monto,CASE WHEN ctotdebe>0 THEN 'D' ELSE 'H' END AS Naturaleza FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dbl_Monto = Convert.ToDouble(_Row["Monto"].ToString().Trim());
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row["ccount"].ToString().Trim(), _P_Str_Proveedor, _Row["cdescrip"].ToString().Trim(), _Row["ctdocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _Cls_Formato._Mtd_fecha(_Dtm_FechaEmi), _Cls_Formato._Mtd_fecha(_Dtm_FechaVenc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["Naturaleza"].ToString().Trim().ToUpper());
            }
        }

        private void _Mtd_Imprimir(string _P_Str_ComprobRetencion)
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
                    _Str_Sql = "SELECT ISNULL(cidcomprob,0) AS cidcomprob, ISNULL(cidcomprobanul,0) AS cidcomprobanul, ISNULL(cimpreso,0) AS cimpreso FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        string _Str_cidcomprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                        string _Str_cidcomprobanul = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
                        int _Int_Impreso = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cimpreso"].ToString().Trim());
                        //------------------------------
                        if (_Mtd_Anulado(_P_Str_ComprobRetencion))
                        {
                            //------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Frm = new REPORTESS(new string[] { "VST_COMPROBANRET_REPORT" }, "", "T3.Report.rComprobRetencion", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _P_Str_ComprobRetencion + "'", _Print, true);
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
                        }
                        else
                        {
                            if (_Int_Sw == 0 | _Int_Sw == 1)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Frm = new REPORTESS(new string[] { "VST_COMPROBANRET_REPORT" }, "", "T3.Report.rComprobRetencion", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _P_Str_ComprobRetencion + "'", _Print, true);
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
                            if (!_Rb_Anulados.Checked)
                            {
                                if (_Int_Sw == 0 | _Int_Sw == 2)
                                {
                                    if (_Int_Sw == 0)
                                    { MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Int_Sw = 2; goto _PrintComprob; }
                                    Cursor = Cursors.WaitCursor;
                                    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'", _Print, true);
                                    Cursor = Cursors.Default;
                                    if (MessageBox.Show("¿El comprobante contable se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        _Frm.Close();
                                        _Frm.Dispose();
                                        goto _PrintComprob;
                                    }
                                }
                                if (_Int_Impreso == 0)
                                {
                                    if (!_Mtd_ComprobActualizado(_Str_cidcomprob))
                                    {
                                        if (MessageBox.Show("¿Desea cerrar la Retención y actualizar el comprobante contable?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            _Str_Sql = "Update TCOMPROBANC set cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob=" + _Str_cidcomprob;
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            _Str_Sql = "Update TCOMPROBANRETC Set cimpreso=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (_Bol_Notificador)
                                            {
                                                _Tb_Tab.SelectedIndex = 0;
                                                _Mtd_Actualizar();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. Debe intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void _Mtd_Anular(string _P_Str_ComprobRetencion)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT TCOMPROBANRETC.cidcomprob,TCOMPROBANRETD.cfechadocu,TCOMPROBANRETC.cfechavencret,TCOMPROBANRETC.cproveedor FROM TCOMPROBANRETC INNER JOIN TCOMPROBANRETD ON TCOMPROBANRETC.ccompany=TCOMPROBANRETD.ccompany AND TCOMPROBANRETC.cidcomprobret=TCOMPROBANRETD.cidcomprobret WHERE TCOMPROBANRETC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETC.cidcomprobret='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_FechaEmision = _Ds.Tables[0].Rows[0]["cfechadocu"].ToString().Trim();
                string _Str_FechaVencimiento = _Ds.Tables[0].Rows[0]["cfechavencret"].ToString().Trim();
                string _Str_Proveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim();
                if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                {
                    string _Str_Id_ComprobAnul = _Cls_VariosMetodos._Mtd_CrearComprobanteAnulacion(_Str_Id_Comprob);
                    _Str_Cadena = "UPDATE TCOMPROBANRETC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "UPDATE TCOMPROBANRETC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "'";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //--------
                    _Mtd_InsertarAuxiliar(_Str_Id_ComprobAnul, _Str_Proveedor, _Str_FechaEmision, _Str_FechaVencimiento);
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
                _Mtd_Imprimir(_P_Str_ComprobRetencion);
            }
        }

        private void _Mtd_SeleccionarTipoDocumet(string _P_Str_TipoDoc)
        {
            string _Str_Cadena = "SELECT ctipdocfact,ctipodocndp,ctipodocncp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper())
                { _Rb_Fact.Checked = true; }
                else if (_P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocndp"].ToString().Trim().ToUpper())
                { _Rb_ND.Checked = true; }
                else if (_P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocncp"].ToString().Trim().ToUpper())
                { _Rb_NC.Checked = true; }
            }
        }

        private void _Mtd_CargarFormulario(string _P_Str_ComprobRetencion)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT TPROVEEDOR.cglobal,TPROVEEDOR.ccatproveedor,TCOMPROBANRETC.cproveedor,TCOMPROBANRETC.cfechaemiret,TCOMPROBANRETD.cdocumentafect,TCOMPROBANRETD.ctdocument,TCOMPROBANRETD.cnumdocu,TCOMPROBANRETD.cnumcontrolfact,TCOMPROBANRETD.cfechadocu,TCOMPROBANRETC.cfechavencret," +
                "dbo.Fnc_Formatear(SUM(TCOMPROBANRETD.cbaseimponible)) AS cbaseimponible,dbo.Fnc_Formatear(SUM(TCOMPROBANRETD.ctotmontexcento)) AS ctotmontexcento,dbo.Fnc_Formatear(SUM(TCOMPROBANRETD.ctotcaomp_iva)) AS ctotcaomp_iva,dbo.Fnc_Formatear(SUM(TCOMPROBANRETD.cimpuesto)) AS cimpuesto,dbo.Fnc_Formatear(TCOMPROBANRETC.cretenido) as cretenido,TCOMPROBANRETC.cporcnreten " +
                "FROM TCOMPROBANRETC INNER JOIN TCOMPROBANRETD ON TCOMPROBANRETC.ccompany=TCOMPROBANRETD.ccompany AND TCOMPROBANRETC.cidcomprobret=TCOMPROBANRETD.cidcomprobret INNER JOIN " +
                "TPROVEEDOR ON TCOMPROBANRETC.cproveedor = TPROVEEDOR.cproveedor AND (dbo.TPROVEEDOR.cglobal = '1' OR TPROVEEDOR.ccompany = dbo.TCOMPROBANRETC.ccompany) " +
                "WHERE TCOMPROBANRETC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETC.cidcomprobret='" + _P_Str_ComprobRetencion + "' " +
                "GROUP BY TPROVEEDOR.cglobal,TPROVEEDOR.ccatproveedor,TCOMPROBANRETC.cproveedor,TCOMPROBANRETC.cfechaemiret,TCOMPROBANRETD.cdocumentafect,TCOMPROBANRETD.ctdocument," +
                "TCOMPROBANRETD.cnumdocu,TCOMPROBANRETD.cnumcontrolfact,TCOMPROBANRETD.cfechadocu,TCOMPROBANRETC.cfechavencret,TCOMPROBANRETC.cretenido,TCOMPROBANRETC.cporcnreten";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_NumeroComprobante.Text = _P_Str_ComprobRetencion;
                _Dtp_EmisionComprobante.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemiret"]);
                _Mtd_CargarTipoProv(_Cmb_TipoProvD);
                //---------------------
                _Cmb_CategProvD.SelectedIndexChanged -= new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
                _Mtd_CargarCategProv(_Cmb_CategProvD, _Cmb_TipoProvD);
                if (_Ds.Tables[0].Rows[0]["cglobal"].ToString().Trim() != "1")
                {
                    _Cmb_CategProvD.SelectedValue = _Ds.Tables[0].Rows[0]["ccatproveedor"].ToString().Trim();
                }
                _Cmb_CategProvD.SelectedIndexChanged += new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
                //---------------------
                _Str_Proveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim();
                //---------------------
                _Cmb_ProveedorD.SelectedIndexChanged -= new EventHandler(_Cmb_ProveedorD_SelectedIndexChanged);
                _Mtd_CargarProvee(_Cmb_ProveedorD, _Cmb_CategProvD, _Cmb_TipoProvD);
                _Cmb_ProveedorD.SelectedValue = _Str_Proveedor;
                _Cmb_ProveedorD.SelectedIndexChanged += new EventHandler(_Cmb_ProveedorD_SelectedIndexChanged);
                //---------------------
                _Rb_Fact.CheckedChanged -= new EventHandler(_Rb_TipoDocument_CheckedChanged);
                _Rb_ND.CheckedChanged -= new EventHandler(_Rb_TipoDocument_CheckedChanged);
                _Rb_NC.CheckedChanged -= new EventHandler(_Rb_TipoDocument_CheckedChanged);
                _Mtd_SeleccionarTipoDocumet(_Ds.Tables[0].Rows[0]["ctdocument"].ToString().Trim());
                _Rb_Fact.CheckedChanged += new EventHandler(_Rb_TipoDocument_CheckedChanged);
                _Rb_ND.CheckedChanged += new EventHandler(_Rb_TipoDocument_CheckedChanged);
                _Rb_NC.CheckedChanged += new EventHandler(_Rb_TipoDocument_CheckedChanged);
                _Mtd_EstablecerTipDocument();
                //---------------------
                _Txt_DocAfect.Text = _Ds.Tables[0].Rows[0]["cdocumentafect"].ToString().Trim();
                _Txt_Documento.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().Trim();
                //---------------------
                if (_Ds.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim() == "NA")
                {
                    _Chk_FactMaqFis.Checked = true;
                }
                else
                {
                    _Chk_FactMaqFis.Checked = false;
                    _Txt_NumCtrlPref.Text = _Ds.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().Substring(0, _Ds.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().IndexOf("-"));
                    _Txt_NumCtrl.Text = _Ds.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().Substring(_Ds.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().IndexOf("-") + 1);
                }
                //---------------------
                _Dtp_Emision.MinDate = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadocu"]);
                _Dtp_Emision.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadocu"]);
                _Dtp_Vencimiento.MinDate = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechavencret"]);
                _Dtp_Vencimiento.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechavencret"]);
                //---------------------
                _Txt_BaseImpon.TextChanged -= new EventHandler(_Txt_BaseImpon_TextChanged);
                _Txt_BaseImpon.Text = _Ds.Tables[0].Rows[0]["cbaseimponible"].ToString().Trim();
                _Txt_BaseImpon.TextChanged += new EventHandler(_Txt_BaseImpon_TextChanged);
                //---------------------
                _Txt_MontoExcento.TextChanged -= new EventHandler(_Txt_MontoExcento_TextChanged);
                _Txt_MontoExcento.Text = _Ds.Tables[0].Rows[0]["ctotmontexcento"].ToString().Trim();
                _Txt_MontoExcento.TextChanged += new EventHandler(_Txt_MontoExcento_TextChanged);
                //---------------------
                _Txt_Total.Text = _Ds.Tables[0].Rows[0]["ctotcaomp_iva"].ToString().Trim();
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0]["cimpuesto"].ToString().Trim();
                //---------------------
                _Txt_MontoRetenido.Text = _Ds.Tables[0].Rows[0]["cretenido"].ToString().Trim();
                //---------------------
                if (_Ds.Tables[0].Rows[0]["cporcnreten"].ToString().Trim() == "75")
                { _Rb_75.Checked = true; }
                else
                { _Rb_100.Checked = true; }
                //---------------------
                _Bt_Imprimir.Enabled = true;
                _Bt_ComprobRetenc.Enabled = true;
                //---------------------
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            }
            Cursor = Cursors.Default;
        }

        private void _Mtd_ConfigurarControles()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Bol_CompRetiene;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            if (_Cmb_CategProvD.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
        }

        private void Frm_CompRetencionManual_Load(object sender, EventArgs e)
        {
            _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
            _Mtd_CentrarPaneles();
            _Mtd_Actualizar();
        }

        private void Frm_CompRetencionManual_Activated(object sender, EventArgs e)
        {
            _Mtd_ConfigurarControles();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Cmb_CategProv_DropDown(object sender, EventArgs e)
        {
            _Cmb_CategProv.SelectedIndexChanged -= new EventHandler(_Cmb_CategProv_SelectedIndexChanged);
            _Mtd_CargarCategProv(_Cmb_CategProv, _Cmb_TipoProv);
            _Mtd_CargarProvee(_Cmb_Proveedor, _Cmb_CategProv, _Cmb_TipoProv);
            _Cmb_CategProv.SelectedIndexChanged += new EventHandler(_Cmb_CategProv_SelectedIndexChanged);
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarProvee(_Cmb_Proveedor, _Cmb_CategProv, _Cmb_TipoProv);
            _Dg_Grid.DataSource = null;
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee(_Cmb_Proveedor, _Cmb_CategProv, _Cmb_TipoProv);
        }

        private void _Cmb_CategProvD_DropDown(object sender, EventArgs e)
        {
            _Cmb_CategProvD.SelectedIndexChanged -= new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
            _Mtd_CargarCategProv(_Cmb_CategProvD, _Cmb_TipoProvD);
            _Cmb_ProveedorD.DataSource = null; 
            _Cmb_ProveedorD.Enabled = false;
            _Cmb_CategProvD.SelectedIndexChanged += new EventHandler(_Cmb_CategProvD_SelectedIndexChanged);
        }

        private void _Cmb_CategProvD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CategProvD.SelectedIndex > 0)
            {
                _Mtd_CargarProvee(_Cmb_ProveedorD, _Cmb_CategProvD, _Cmb_TipoProvD);
                _Cmb_ProveedorD.Enabled = true;
            }
            else
            {
                _Cmb_ProveedorD.DataSource = null; 
                _Cmb_ProveedorD.Enabled = false;
            }
        }

        private void Frm_CompRetencionManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_InicializarFormulario(); 
                _Mtd_Hab_Deshab_Controles(false);
                _Cmb_CategProvD.Enabled = false;
                _Cmb_ProveedorD.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else if (!_Cmb_ProveedorD.Enabled)
                e.Cancel = true;
        }

        private void _Rb_TipoDocument_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                _Mtd_EstablecerTipDocument();
            }
            _Txt_DocAfect.Text = "";
            _Txt_DocAfect.Enabled = ((RadioButton)sender).Checked & ((RadioButton)sender).Name == "_Rb_NC";
            //_Chk_AplicaInvend.Enabled = ((RadioButton)sender).Checked & (((RadioButton)sender).Name == "_Rb_NC" || ((RadioButton)sender).Name == "_Rb_ND");
            //_Chk_AplicaInvend.Checked = true;
        }

        private void _Evento_CheckedChanged_Impuestos(object sender, EventArgs e)
        {
            _Mtd_ConfigurarPanelImpuestos();
        }

        string _Str_Proveedor = "";
        private void _Cmb_ProveedorD_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_InicializarFormulario();
            if (_Cmb_ProveedorD.SelectedIndex > 0)
            {
                _Mtd_Hab_Deshab_Controles(true);
                _Str_Proveedor = _Cmb_ProveedorD.SelectedValue.ToString().Trim();
                _Mtd_ConfigurarPanelImpuestos();
            }
            else
            {
                _Mtd_Hab_Deshab_Controles(false);
            }
        }

        private void _Bt_Aceptar_Varias_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarGridImpuesto() | (_Dg_Impuestos.RowCount == 1 & _Dg_Impuestos.Rows[0].Cells[0].Value == null))
            { _Dg_Impuestos.EndEdit(); _Mtd_CalcularTotalesImpuestos(); _Pnl_Varias.Visible = false; }
            else
            { MessageBox.Show("Algunos datos estan incompletos. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Cerrar_Varias_Click(object sender, EventArgs e)
        {
            _Pnl_Varias.Visible = false;
        }

        private void _Pnl_Varias_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Varias.Visible)
            {
                _Tb_Tab.Enabled = false;
                if (_Txt_Impuesto.Text.Trim().Length == 0 | _Dg_Impuestos.RowCount == 0)
                { _Dg_Impuestos.Rows.Clear(); _Dg_Impuestos.Rows.Add(); }
                else if (_Dg_Impuestos.RowCount > 0)
                { if (Convert.ToString(_Dg_Impuestos.Rows[_Dg_Impuestos.RowCount - 1].Cells[0].Value).Trim().Length > 0) { _Dg_Impuestos.Rows.Add(); } }
            }
            else
            {
                _Mtd_EliminarNulosGridImpuesto(); _Tb_Tab.Enabled = true;
                if (_Dg_Impuestos.RowCount == 1)
                { if (Convert.ToString(_Dg_Impuestos.Rows[0].Cells[0].Value).Trim().Length == 0) { _Rb_ConIva.Checked = true; } }
                else if (_Dg_Impuestos.RowCount == 0) { _Rb_ConIva.Checked = true; }
            }
        }

        private void _Dg_Impuestos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                if (_Dg_Impuestos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    _Str_ValorCeldaTem = _Dg_Impuestos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }

        private void _Dg_Impuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1)
                {
                    TextBox _Txt_Temp = new TextBox();
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(56, _Txt_Temp, 0, "");
                    _Frm.ShowDialog();
                    if (!_Mtd_ExistenciaImpuesto(Convert.ToString(_Txt_Temp.Tag).Trim(), _Txt_Temp.Text, e.RowIndex))
                    {
                        if (_Txt_Temp.Text.Trim().Length > 0)
                        {
                            _Dg_Impuestos.Rows[e.RowIndex].Cells[0].Value = _Txt_Temp.Text.Trim();
                            _Dg_Impuestos.Rows[e.RowIndex].Cells[2].Value = null;
                            _Dg_Impuestos.Rows[e.RowIndex].Cells[3].Value = null;
                            _Dg_Impuestos.Rows[e.RowIndex].Cells[4].Value = Convert.ToString(_Txt_Temp.Tag).Trim();
                            DataGridViewCell _Dg_Cel = _Dg_Impuestos.Rows[_Dg_Impuestos.CurrentCell.RowIndex].Cells[2];
                            _Dg_Impuestos.CurrentCell = _Dg_Cel;
                            _Mtd_CalcularTotalesImpuestos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El impuesto ya fué agregado. Seleccione uno diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void _Dg_Impuestos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                if (_Dg_Impuestos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (_Dg_Impuestos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length == 0)
                    {
                        if (_Str_ValorCeldaTem != "XXXX")
                            _Dg_Impuestos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_ValorCeldaTem;
                    }
                    else
                    {
                        _Mtd_CalcularImpuesto(e.RowIndex);
                        _Mtd_CalcularTotalesImpuestos();
                    }
                }
                else
                {
                    if (_Str_ValorCeldaTem != "XXXX")
                        _Dg_Impuestos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_ValorCeldaTem;
                }
            }
        }

        private void _Dg_Impuestos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (_Dg_Impuestos.Rows[e.RowIndex].Cells[0].Value == null)
                { _Dg_Impuestos.Rows[e.RowIndex].Cells[2].ReadOnly = true; }
                else
                { _Dg_Impuestos.Rows[e.RowIndex].Cells[2].ReadOnly = false; }
            }
        }
        bool _Bol_Boleano1 = false;
        private void _Dg_Impuestos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano1)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                _Bol_Boleano1 = true;
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Impuestos.CurrentCell.ColumnIndex == 0)
            {
                _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 10, 2);
            }
            else if (_Dg_Impuestos.CurrentCell.ColumnIndex == 2 | _Dg_Impuestos.CurrentCell.ColumnIndex == 3)
            { _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Mtd_Hab_Deshab_Controles_Clave(true);
                _Txt_Clave.Text = ""; 
                _Txt_Clave.Focus(); 
            }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
        }

        private void _Mtd_Hab_Deshab_Controles_Clave(bool _P_Bol_Valor)
        {
            _Txt_Clave.Enabled = _P_Bol_Valor;
            _Bt_CancelarClave.Enabled = _P_Bol_Valor;
            _Bt_AceptarClave.Enabled = _P_Bol_Valor;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Int_Sw == 1)
                {
                    _Mtd_Hab_Deshab_Controles_Clave(false);
                    Application.DoEvents();
                    var _Int_Retencion = _Mtd_GuardarRetencion();
                    if (_Int_Retencion > 0)
                    {
                        _Txt_NumeroComprobante.Text = _Int_Retencion.ToString();
                        _Mtd_Imprimir(_Int_Retencion.ToString());
                    }
                    else
                    { MessageBox.Show("Error en la operacion. No se genero la retención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    _Pnl_Clave.Visible = false;
                    _Tb_Tab.SelectedIndex = 0;
                    _Mtd_Actualizar();
                }
                else
                {
                    _Mtd_Hab_Deshab_Controles_Clave(false);
                    Application.DoEvents();
                    string _Str_ComprobanteRetencion = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim();
                    if (_Mtd_VerificarComprobRetenImpreso(_Str_ComprobanteRetencion))
                    {
                        if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                        {
                            if (_Mtd_CuentasInactivas(_Str_ComprobanteRetencion))
                                return;
                            _Mtd_Anular(_Str_ComprobanteRetencion);
                            _Pnl_Clave.Visible = false;
                            _Mtd_Actualizar();
                        }
                        else
                        {
                            MessageBox.Show("Problemas de conexión para anular la retención. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    { MessageBox.Show("No se puede anular la retención porque ha sido cerrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Alicuota_Click(object sender, EventArgs e)
        {
            string _Str_Alicuota = _Txt_Alicuota.Text.Trim();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(56, _Txt_Alicuota, 1, "");
            _Frm.ShowDialog();
            if (_Txt_Alicuota.Text.Trim() != _Str_Alicuota)
            { _Mtd_CalularMontos(); }
        }

        private void _Txt_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
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

        private void _Dtp_Emision_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Vencimiento.MinDate = _Dtp_Emision.Value.AddDays(1);
            _Dtp_Vencimiento.Value = _Dtp_Emision.Value.AddDays(1);
        }

        private void _Txt_BaseImpon_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_BaseImpon, e, 15, 2);
        }

        private void _Txt_BaseImpon_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_BaseImpon.Text)) { _Txt_BaseImpon.Text = ""; }
            _Mtd_CalularMontos();
        }

        private void _Txt_MontoExcento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_MontoExcento, e, 15, 2);
        }

        private void _Txt_MontoExcento_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_MontoExcento.Text)) { _Txt_MontoExcento.Text = ""; }
            _Mtd_CalularMontos();
        }

        private void _Bt_Varias_Click(object sender, EventArgs e)
        {
            _Pnl_Varias.Visible = true;
        }

        private void _Cntx_Contex_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 || _Rb_Anulados.Checked || !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANULAR_RETENCIONES"));
        }

        private void _Mnu_Anular_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarMesComprobanteReten(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()))
            {
                _Int_Sw = 2;
                _Pnl_Clave.Visible = true; 
            }
            else
            { MessageBox.Show("No es posible anular la retención ya que el mes contable del comprobante de la retención no es igual al mes contable actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_ComprobRetenc_Click(object sender, EventArgs e)
        {
            string _Str_ComprobanteContable = _Mtd_ComprobanteContableRetencion(_Txt_NumeroComprobante.Text);
            if (string.IsNullOrEmpty(_Str_ComprobanteContable))
            {
                MessageBox.Show("No se obtuvo el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Frm_VerComprobante _Frm = new Frm_VerComprobante(_Str_ComprobanteContable);
                _Frm.FormClosed += new FormClosedEventHandler(_Frm_FormClosed);
                _Frm.ShowDialog();
            }
        }

        void _Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Mtd_ConfigurarControles();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _Mtd_CargarFormulario(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim());
            }
        }

        private void _Cntx_Impuesto_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Impuestos.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void _Mnu_Eliminar_Click(object sender, EventArgs e)
        {
            _Dg_Impuestos.SelectedRows.Cast<DataGridViewRow>().Where(x => x.Cells[0].Value != null).ToList().ForEach(x =>
            {
                _Dg_Impuestos.Rows.Remove(x);
            });
            _Mtd_CalcularTotalesImpuestos();
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            _Mtd_Imprimir(_Txt_NumeroComprobante.Text);
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

        private void _Rb_Consulta_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }
    }
}
