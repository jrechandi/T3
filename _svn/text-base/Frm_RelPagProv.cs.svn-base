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
    public partial class Frm_RelPagProv : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        DataGridViewCell _Dg_Cel;
        string _Str_ValorCeldaTem = "XXXX";
        string _Str_CompanyRetenExterna = "";
        private int _Int_CantidadDeRegistrosComprobante = 0;
        private double _Dbl_MontoExcentoOriginal = 0;
        private DataGridViewRow _Dgvr_RegistroComprobante;
        private bool _Bool_ModoConsulta;
        public Frm_RelPagProv()
        {
            InitializeComponent();
            //-------------------
            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            //-------------------
            _Mtd_CargarTipoProvD();
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
            _Mtd_Sorted(_Dg_Comprobante);
            _Mtd_Sorted(_Dg_Impuestos);
            _Mtd_Sorted(_Dg_ISLR);
        }
        public Frm_RelPagProv(string _P_Str_Proveedor)
        {
            InitializeComponent();
            //-------------------
            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            _Cmb_Proveedor.SelectedValue = _P_Str_Proveedor.ToString();
            //-------------------
            _Mtd_CargarTipoProvD();
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
            _Mtd_Sorted(_Dg_Comprobante);
            _Mtd_Sorted(_Dg_Impuestos);
            _Mtd_Sorted(_Dg_ISLR);
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
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
        private void _Mtd_CentrarPaneles()
        {
            _Pnl_Varias.Size = new Size(361, 190);
            _Pnl_Varias.Left = (this.Width / 2) - (_Pnl_Varias.Width / 2);
            _Pnl_Varias.Top = (this.Height / 2) - (_Pnl_Varias.Height / 2);
            //-----------------
            _Pnl_ISLR.Size = new Size(452, 190);
            _Pnl_ISLR.Left = (this.Width / 2) - (_Pnl_ISLR.Width / 2);
            _Pnl_ISLR.Top = (this.Height / 2) - (_Pnl_ISLR.Height / 2);
            //-----------------
            //_Pnl_ISLR.Size = new Size(452, 190);
            _Pnl_EditarMontoCuentaComprobante.Left = (this.Width / 2) - (_Pnl_EditarMontoCuentaComprobante.Width / 2);
            _Pnl_EditarMontoCuentaComprobante.Top = (this.Height / 2) - (_Pnl_EditarMontoCuentaComprobante.Height / 2);
        }
        private void _Mtd_Actualizar()
        {
            _Mtd_Ini_SeleccionarRegistros();
            string _Str_Cadena = "SELECT c_nomb_comer AS Proveedor,CONVERT(VARCHAR, cfechaemision, 103) AS Emisión,CONVERT(VARCHAR, cfechavencimiento, 103) AS Vencimiento,cnumdocu AS Documento,cname AS Tipo,dbo.Fnc_Formatear(cmontodocshow) AS Monto,dbo.Fnc_Formatear(csaldoshow) AS Saldo,vencimiento AS Vencidos,cvencimientodias AS [Por Vencer],cfact_afectada AS [Factura Afec.],cidcomprobret AS Retención,cidfactxp,cidnotrecepc,ctipodocument,ctotalimp,cproveedor,cordenpaghecha FROM VST_FACTPPAGARM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=1 AND canulado=0 AND csaldo <> 0";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal=" + Convert.ToString(_Cmb_TipoProv.SelectedValue).Trim(); }
            //---
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND ccatproveedor='" + Convert.ToString(_Cmb_CategProv.SelectedValue).Trim() + "'"; }
            //---
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Cadena += " AND cproveedor='" + Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() + "'"; }
            //---
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            //---
            _Dg_Grid.Columns["cidfactxp"].Visible = false;
            _Dg_Grid.Columns["cproveedor"].Visible = false;
            _Dg_Grid.Columns["cordenpaghecha"].Visible = false;
            _Dg_Grid.Columns["ctotalimp"].Visible = false;
            _Dg_Grid.Columns["ctipodocument"].Visible = false;
            _Dg_Grid.Columns["cidnotrecepc"].Visible = false;
            _Dg_Grid.Columns["Emisión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Vencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Documento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            _Dg_Grid.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Saldo"].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            double _Dbl_Monto = 0;
            double _Dbl_Saldo = 0;
            //---
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["cordenpaghecha"] != null)
                {
                    if (_Dg_Row.Cells["cordenpaghecha"].Value.ToString().Trim() == "1") { _Dg_Row.DefaultCellStyle.BackColor = Color.LightGray; }
                }
                if (_Dg_Row.Cells["Monto"] != null)
                {
                    if (_Dg_Row.Cells["Monto"].Value.ToString().Trim().Length > 0)
                    {
                        _Dbl_Monto += Convert.ToDouble(_Dg_Row.Cells["Monto"].Value.ToString().Trim());
                        if (Convert.ToDouble(_Dg_Row.Cells["Monto"].Value.ToString().Trim()) < 0) { _Dg_Row.Cells["Monto"].Style.ForeColor = Color.Red; }
                    }
                }
                if (_Dg_Row.Cells["Saldo"] != null)
                {
                    if (_Dg_Row.Cells["Saldo"].Value.ToString().Trim().Length > 0)
                    {
                        _Dbl_Saldo += Convert.ToDouble(_Dg_Row.Cells["Saldo"].Value.ToString().Trim());
                        if (Convert.ToDouble(_Dg_Row.Cells["Saldo"].Value.ToString().Trim()) < 0) { _Dg_Row.Cells["Saldo"].Style.ForeColor = Color.Red; }
                    }
                }
            }
            _Dg_Grid.Font = new Font("Verdana", (float)8);
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_Monto.Text = _Dbl_Monto.ToString("#,##0.00");
            _Txt_Saldo.Text = _Dbl_Saldo.ToString("#,##0.00");
        }
        private void _Mtd_CargarTipoProv()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoProv.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.DisplayMember = "Display";
            _Cmb_TipoProv.ValueMember = "Value";
            _Cmb_TipoProv.SelectedValue = "nulo";
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.SelectedIndex = 0;
        }
        private void _Mtd_CargarTipoProvD()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoProvD.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cmb_TipoProvD.DataSource = _myArrayList;
            _Cmb_TipoProvD.DisplayMember = "Display";
            _Cmb_TipoProvD.ValueMember = "Value";
            _Cmb_TipoProvD.SelectedValue = "nulo";
            _Cmb_TipoProvD.DataSource = _myArrayList;
            _Cmb_TipoProvD.SelectedIndex = 0;
        }
        private void _Mtd_CargarCategProvD()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_Cmb_TipoProvD.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _Cmb_TipoProvD.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_CategProvD, _Str_Cadena);
            Cursor = Cursors.Default;
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
        private void _Mtd_CargarProvee()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                if (_Cmb_TipoProv.SelectedValue.ToString().Trim() == "0" | _Cmb_TipoProv.SelectedValue.ToString().Trim() == "2")
                { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
                else
                { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            }
            else
            { _Str_Cadena += " AND ((TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1') OR (TPROVEEDOR.cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //-----------
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'"; }
            //_Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            //Union PQseada para que salgan los proveedores no activos
            _Str_Cadena += " UNION ";
            _Str_Cadena += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado ";
            _Str_Cadena += " FROM TPROVEEDOR INNER JOIN ";
            _Str_Cadena += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
            _Str_Cadena += " WHERE ";
            _Str_Cadena += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_SeleccionarCategoriaProvee(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT ccatproveedor FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND cglobal='2' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Cmb_CategProvD.SelectedValue = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
        }
        private bool _Mtd_ProveedorRetenConfig(string _P_Str_Proveedor)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
            { return true; }
            string _Str_Cadena = "SELECT ISNULL(cporcenreteniva,0) FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                { return true; }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "75")
                { _Rb_75.Checked = true; return true; }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "100")
                { _Rb_100.Checked = true; return true; }
            }
            return false;
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
            _Chk_ISRL.Checked = false;
            _Rb_100.Checked = false;
            _Rb_75.Checked = false;
            _Txt_Alicuota.Text = "";
            _Txt_BaseImpon.Text = "";
            _Txt_MontoExcento.Text = "";
            _Txt_Total.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_ISLR.Text = "";
            _Dg_Comprobante.Rows.Clear();
            if (_Rb_ConIva.Checked) { _Lbl_Separador2.Visible = true; _Bt_Alicuota.Visible = true; _Lbl_Separador1.Visible = true; _Txt_Alicuota.Visible = true; _Lbl_Alicuota.Visible = true; _Txt_BaseImpon.Enabled = true; _Txt_Alicuota.Text = _Mtd_ObtenerImpuesto(); _Mtd_ProveedorRetenConfig(_Str_Proveedor); _Txt_BaseImpon.Focus(); }
            else if (_Rb_Varias.Checked) { _Bt_Varias.Visible = true; _Pnl_Varias.Visible = true; _Mtd_ProveedorRetenConfig(_Str_Proveedor); }
            else { _Txt_MontoExcento.Focus(); }
            _Mtd_HabilitarIvaCredNoComp();
        }
        string[] _Str_ChkListProveedor;
        private void _Mtd_CargarListaCheckProv(string _P_Str_TipoProv, string _P_Str_CategProv)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Ini(); _Mtd_DesHabilitarNuevo(); _ChkList_Prov.Items.Clear();
            _Str_ChkListProveedor = new string[0];
            /////////
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_fiscal FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor =TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_P_Str_TipoProv == "0" | _P_Str_TipoProv == "2")
            { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _P_Str_TipoProv + "'"; }
            else
            { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _P_Str_TipoProv + "'"; }
            //-----------
            if (_P_Str_CategProv.Trim().Length > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _P_Str_CategProv.Trim() + "'"; }
            _Str_Cadena += " ORDER BY c_nomb_fiscal";
            /////////
            //---------------------------------------------------------------
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_ChkListProveedor = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_ChkListProveedor, _Str_ChkListProveedor.Length + 1);
                _Str_ChkListProveedor[_Str_ChkListProveedor.Length - 1] = _Row[0].ToString();
                _ChkList_Prov.Items.Add(_Row[1].ToString());
            }
            Cursor = Cursors.Default;
        }
        private void _Mtd_SeleccionarProveedor(string _P_Str_Proveedor)
        {
            if (_P_Str_Proveedor.Trim().Length > 0)
            {
                int _Int_Index = 0;
                _ChkList_Prov.ItemCheck -= new ItemCheckEventHandler(_ChkList_Prov_ItemCheck);
                foreach (string _Str in _Str_ChkListProveedor)
                {
                    if (_Str == _P_Str_Proveedor)
                    {
                        break;
                    }
                    _Int_Index++;
                }
                _ChkList_Prov.SetItemChecked(_Int_Index, true);
                _ChkList_Prov.ItemCheck += new ItemCheckEventHandler(_ChkList_Prov_ItemCheck);
            }
        }

        private void _Mtd_EstablecerTipDocumnt()
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
        /// <summary>
        /// Muestra en un ToolTips la descripción de la cuenta que se esta introduciendo manualmente
        /// </summary>
        /// <param name="_P_Str_Cuenta"></param>
        private void _Mtd_MostrarToolTipsCell(string _P_Str_Cuenta, Font _P_Fnt_Fuente)
        {
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Tlt_Tips.Show(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), this, (_Dg_Comprobante.Location.X + (_Dg_Comprobante.Width / 2)) - (Convert.ToInt32(CreateGraphics().MeasureString(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _P_Fnt_Fuente).Width) / 2), _Pnl_Inferior.Location.Y + 50, 2000);
                }
                else
                {
                    _Tlt_Tips.Hide(this);
                }
            }
            else
            { _Tlt_Tips.Hide(this); }
        }
        bool _Bol_Nuevo = false;
        public void _Mtd_Nuevo()
        {
            ((Frm_Padre)this.MdiParent).Cursor = Cursors.WaitCursor;
            _Er_Error.Dispose();
            _Mtd_CargarTipoProvD();
            _Cmb_TipoProvD.Enabled = true;
            _Bool_ModoConsulta = false;
            _Bol_Nuevo = true;
            _Mtd_Ini();
            _Bol_Nuevo = false;
            _Tb_Tab.SelectTab(1);
            _Cmb_TipoProvD.Focus();
            ((Frm_Padre)this.MdiParent).Cursor = Cursors.Default;
        }
        public void _Mtd_Ini()
        {
            if (_ChkList_Prov.Items.Count > 0 | _Bol_Nuevo)
            {
                _Txt_Alicuota.Text = "";
                _Txt_BaseImpon.Text = "";
                _Txt_FechNotRecep.Text = "";
                _Txt_Impuesto.Text = "";
                _Txt_Invendible.Text = "";
                _Txt_MontoExcento.Text = "";
                _Txt_NotaRecep.Text = "";
                _Txt_NumCtrl.Text = "";
                _Txt_NumCtrlPref.Text = "";
                _Txt_Documento.Text = "";
                _Txt_TipoDoc.Text = "";
                _Txt_Total.Text = "";
                _Mtd_Ini_SeleccionarRegistros();
                _Chk_FactMaqFis.Checked = false;
                _Bt_Pagar.Enabled = false;
                _Rb_Fact.Checked = true;
                _ChkList_Prov.Enabled = true;
                _Mtd_EstablecerTipDocumnt();//Debe ir abajo de _Rb_Fact.Checked = true;
                _Rb_ConIva.Checked = false;
                _Rb_SinIva.Checked = true;
                _Rb_Varias.Checked = false;
                _Pnl_Visor_ISLR.Enabled = false;
                _Bt_Visulizar.Enabled = false;
                _Bt_ComprobRetenc.Enabled = false;
                _Dg_Comprobante.Rows.Clear();
                _Dtp_Emision.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                _Dtp_Vencimiento.MinDate = _Dtp_Emision.Value.AddDays(1);
                _Dtp_Vencimiento.Value = _Dtp_Emision.Value.AddDays(1);
            }
        }
        private void _Mtd_HabilitarNuevo()
        {
            _Rb_Fact.Enabled = true;
            _Rb_ND.Enabled = true;
            _Rb_NC.Enabled = true;
            _Rb_ConIva.Enabled = true;
            _Rb_SinIva.Enabled = true;
            _Rb_Varias.Enabled = true;
            _Chk_FactMaqFis.Enabled = true;
            _Txt_Documento.Enabled = true;
            _Txt_NumCtrl.Enabled = true;
            _Txt_NumCtrlPref.Enabled = true;
            _Dtp_Emision.Enabled = true;
            _Dtp_Vencimiento.Enabled = true;
            _Txt_MontoExcento.Enabled = true;
            _Bt_Visulizar.Enabled = true;
        }
        private void _Mtd_DesHabilitarNuevo()
        {
            _Rb_Fact.Enabled = false;
            _Rb_ND.Enabled = false;
            _Rb_NC.Enabled = false;
            _Rb_ConIva.Enabled = false;
            _Rb_SinIva.Enabled = false;
            _Rb_Varias.Enabled = false;
            _Chk_FactMaqFis.Enabled = false;
            _Txt_Documento.Enabled = false;
            _Txt_NumCtrl.Enabled = false;
            _Txt_NumCtrlPref.Enabled = false;
            _Dtp_Emision.Enabled = false;
            _Dtp_Vencimiento.Enabled = false;
            _Txt_MontoExcento.Enabled = false;
            _Txt_BaseImpon.Enabled = false;
            _Bt_Visulizar.Enabled = false;
        }
        private string _Mtd_ObtenerProcesoCont(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_Proveedor)
        {
            if (_Chk_IvaCredNoCom.Checked)
                return "P_CTASPAGAR_IVACNC";
            string _Str_Cadena = "SELECT cexcepcioncomp,cidproceso,cidprocesonc,cidprocesond FROM TCATPROVEEDOR WHERE cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cexcepcioncomp"]) == "1")
                {
                    if (_Mtd_TipoDocumentNCP(Convert.ToString(_Txt_TipoDoc.Tag)))
                        return Convert.ToString(_Ds.Tables[0].Rows[0]["cidprocesonc"]).Trim();
                    else if (_Mtd_TipoDocumentNDP(Convert.ToString(_Txt_TipoDoc.Tag)))
                        return Convert.ToString(_Ds.Tables[0].Rows[0]["cidprocesond"]).Trim();
                    return Convert.ToString(_Ds.Tables[0].Rows[0]["cidproceso"]).Trim();
                }
            }
            if (_Mtd_TipoDocumentNCP(Convert.ToString(_Txt_TipoDoc.Tag)))
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                    return "P_CxP_NCP_CIA_RELAC";
                if (_P_Str_TipoProv == "1")
                    return "CXP_NCP";
                return "CXP_NCPSO";
            }
            else if (_Mtd_TipoDocumentNDP(Convert.ToString(_Txt_TipoDoc.Tag)))
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                    return "P_CxP_NDP_CIA_RELAC";
                if (_P_Str_TipoProv == "1")
                    return "CXP_NDP";
                return "CXP_NDPSO";
            }
            else
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                    return "P_CXP_CIARELAC";
                if (_P_Str_TipoProv == "1")
                    return "P_CTASPAGARMP";
                return "P_CTASPAGAR";
            }
        }
        private string _Mtd_DeterminarSqlISLR(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_Proveedor)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                return "";
            bool _Bol_Domiciliada = false;
            bool _Bol_Juridica = false;
            string _Str_Cadena = "SELECT cpjuridica,cdomiciliada FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                { _Bol_Juridica = Convert.ToBoolean(_Ds.Tables[0].Rows[0][0]); }
                if (_Ds.Tables[0].Rows[0][1].ToString().Trim().Length > 0)
                { _Bol_Domiciliada = Convert.ToBoolean(_Ds.Tables[0].Rows[0][1]); }
                //-----------------------------------------------------------------
                if (_Bol_Juridica & _Bol_Domiciliada)
                {
                    _Str_Cadena = "SELECT cpjdformulaver AS [Persona Jurídica Domiciliada],cislr_id,cpjdformulaname AS Identificador,cpjdformula,cdescrip AS Concepto,cpagador AS Pagador,CASE WHEN cpjdalic IS NULL THEN '0' ELSE cpjdalic END AS cpjdalic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpjdformula<>'0'";
                    if (_P_Str_TipoProv.Trim() == "0")
                    {
                        _Str_Cadena += " AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                    }
                }
                else if (_Bol_Juridica & !_Bol_Domiciliada)
                {
                    _Str_Cadena = "SELECT cpjndformulaver AS [Persona Jurídica No Domiciliada],cislr_id,cpjndformulaname AS Identificador,cpjndformula,cdescrip AS Concepto,cpagador AS Pagador,cpjndalic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpjndformula<>'0' AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                }
                else if (!_Bol_Juridica & _Bol_Domiciliada)
                {
                    _Str_Cadena = "SELECT cpnrformulaver AS [Persona Natural Residenciada],cislr_id,cpnrformulaname AS Identificador,cpnrformula,cdescrip AS Concepto,cpagador AS Pagador,cpnralic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpnrformula<>'0' AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                }
                else
                {
                    _Str_Cadena = "SELECT cpnnrformulaver AS [Persona Natural No Residenciada],cislr_id,cpnnrformulaname AS Identificador,cpnnrformula,cdescrip AS Concepto,cpagador AS Pagador,cpnnralic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpnnrformula<>'0' AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                }
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Pnl_Visor_ISLR.Enabled = true;
                return _Str_Cadena;
            }
            else
            { return ""; }
        }
        private string _Mtd_ObtenerImpuesto()
        {
            string _Str_Cadena = "SELECT cpercent FROM TTAX WHERE ctax=(SELECT ctipimpuesto FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return "0"; }
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
        private void _Mtd_EliminarNulosGridISLR()
        {
            if (_Dg_ISLR.RowCount > 0)
            {
                object _Ob_BaseImponible = new object();
                _Ob_BaseImponible = 0;
                if (Convert.ToString(_Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[0].Value).Trim().Length > 0)
                {
                    _Ob_BaseImponible = _Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[0].Value;
                    if (_Ob_BaseImponible == null)
                    { _Ob_BaseImponible = 0; }
                    else if (_Ob_BaseImponible.ToString().Trim().Length == 0)
                    { _Ob_BaseImponible = 0; }
                }
                object _Ob_ISLR = new object();
                _Ob_ISLR = 0;
                if (Convert.ToString(_Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[3].Value).Trim().Length > 0)
                {
                    _Ob_ISLR = _Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[3].Value;
                    if (_Ob_ISLR == null)
                    { _Ob_ISLR = 0; }
                    else if (_Ob_ISLR.ToString().Trim().Length == 0)
                    { _Ob_ISLR = 0; }
                }
                if (Convert.ToDouble(_Ob_BaseImponible) <= 0 | Convert.ToDouble(_Ob_ISLR) <= 0)
                {
                    _Dg_ISLR.Rows.RemoveAt(_Dg_ISLR.RowCount - 1);
                }
            }
        }
        private void _Mtd_CalularMontos()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Alicuota = 0;
            double _Dbl_Impuesto = 0;
            double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
            double _Dbl_PorcentajeDescuentoFinanciero = 0;
            double _Dbl_DescFinan = 0;
            double _Dbl_DescFinanImp = 0;
            _Dg_Comprobante.Rows.Clear();
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
            if (_Chk_AplicaDescuentoFinanciero.Checked)
            {
                _Dbl_PorcentajeDescuentoFinanciero = _Cls_VariosMetodos._Mtd_MontoPorcentajeDescuentoFinanciero(Frm_Padre._Str_GroupComp, _Str_Proveedor, _Txt_DocAfect.Text);
                _Dbl_DescFinan = Math.Round((_Dbl_BaseImpon + _Dbl_MontoExcento) * (_Dbl_PorcentajeDescuentoFinanciero / 100),2);
                _Dbl_DescFinanImp = Math.Round(((_Dbl_BaseImpon *_Dbl_PorcentajeDescuentoFinanciero / 100) * _Dbl_Alicuota) / 100, 2);
            }
            //------------
            if (_Rb_ConIva.Checked)
            {
                _Dbl_Invendible = Convert.ToDouble(Math.Round(((_Dbl_BaseImpon + _Dbl_MontoExcento) * _Dbl_Invendible) / 100, 2));
                _Dbl_Impuesto = ((_Dbl_BaseImpon - _Dbl_Invendible) * _Dbl_Alicuota / 100) - _Dbl_DescFinanImp;
                _Txt_DescuentoFinanciero.Text = _Dbl_DescFinan.ToString("#,##0.00");
                _Txt_Impuesto.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Impuesto).ToString();
                _Txt_Invendible.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Invendible).ToString();
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2((_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto) - _Dbl_Invendible - _Dbl_DescFinan).ToString();
            }
            else if (_Rb_Varias.Checked)
            {
                double _Dbl_InvendibleD = 0;
                if (_Txt_Invendible.Text.Trim().Length > 0)
                { _Dbl_InvendibleD = Convert.ToDouble(_Txt_Invendible.Text); }
                //------------
                _Txt_DescuentoFinanciero.Text = _Dbl_DescFinan.ToString("#,##0.00");
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(((_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto) - _Dbl_InvendibleD - _Dbl_DescFinan - _Dbl_DescFinanImp)).ToString();
            }
            else
            {
                _Dbl_Invendible = Convert.ToDouble(Math.Round((_Dbl_MontoExcento * _Dbl_Invendible) / 100, 2));
                _Txt_Invendible.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Invendible).ToString();
                _Txt_DescuentoFinanciero.Text = _Dbl_DescFinan.ToString("#,##0.00");
                _Txt_Total.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_MontoExcento - _Dbl_Invendible - _Dbl_DescFinan - _Dbl_DescFinanImp).ToString();
            }
            //----------Validación de ISLR
            //if (_Dbl_MontoExcento == 0)
            //{
            _Chk_ISRL.Checked = false;
            //}
            //----------
        }
        private bool _Mtd_CalcularTotalesISLR()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Dg_TotalBaseImponible = 0;
            double _Dbl_Dg_TotalISLR = 0;
            object _Ob_BaseImponible = new object();
            object _Ob_ISLR = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_ISLR.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_BaseImponible = _Dg_Row.Cells[0].Value;
                        if (Convert.ToString(_Ob_BaseImponible).Trim().Length == 0)
                        { _Ob_BaseImponible = 0; }
                        //---------------------------
                        _Ob_ISLR = _Dg_Row.Cells[3].Value;
                        if (Convert.ToString(_Dg_Row.Cells[3].Value).Trim().Length == 0 | Convert.ToString(_Dg_Row.Cells[3].Value).Trim() == "ERROR")
                        { _Ob_ISLR = 0; }
                        //---------------------------
                        _Dbl_Dg_TotalBaseImponible += Convert.ToDouble(_Ob_BaseImponible);
                        _Dbl_Dg_TotalISLR += Convert.ToDouble(_Ob_ISLR);
                    }
                }
            }
            //------------
            if (_Txt_BaseImpon.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImpon.Text); }
            //------------
            if (_Txt_MontoExcento.Text.Trim().Length > 0)
            { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExcento.Text); }
            //------------
            if (_Dbl_Dg_TotalBaseImponible > _Dbl_BaseImpon + _Dbl_MontoExcento)
            {
                return false;
            }
            _Txt_ISLR.Text = _Dbl_Dg_TotalISLR.ToString();
            return true;
        }
        private void _Mtd_ImprimirComprobante(string _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El comprobante ha sido actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Debe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.\nDebe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void _Mtd_SetearContexMenuStrip()
        {
            _Dg_Comprobante.ContextMenuStrip = null;
            if (_Cmb_TipoProvD.SelectedIndex > 0 && _Rb_Fact.Checked)
            {
                if (_Cmb_TipoProvD.SelectedValue.ToString().Trim() == "0")
                {
                    _Dg_Comprobante.ContextMenuStrip = _Cntx_Comprob;
                }
                else if (_Cmb_TipoProvD.SelectedValue.ToString().Trim() == "2")
                {
                    _Dg_Comprobante.ContextMenuStrip = _Cntx_ComprobanteO;
                }
            }
        }

        List<string> _Lis_CuentasEditables = new List<string>();
        private void _Mtd_AgregarCuentaEditable(string _P_Str_Cuenta, string _P_Str_DescripCuenta, TextBox _P_Txt_MontoComprob)
        {
            if (_Dg_Comprobante.Rows.Cast<DataGridViewRow>().Where(x => !string.IsNullOrEmpty(Convert.ToString(x.Cells[0].Value))).Any(x => Convert.ToString(x.Cells[0].Value).Trim() == _P_Str_Cuenta.Trim()))
            {
                MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!_Mtd_VerifContTextBoxVarcharNoCero(_P_Txt_MontoComprob))
            {
                MessageBox.Show("El campo Monto es obligatorio.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var _Ob_Fila = new object[5];
            _Ob_Fila[0] = _P_Str_Cuenta;
            _Ob_Fila[1] = null;
            _Ob_Fila[2] = _P_Str_DescripCuenta;
            _Ob_Fila[3] = Convert.ToDouble(_P_Txt_MontoComprob.Text).ToString("#,##0.00");
            _Ob_Fila[4] = "";
            //var _Dbl_Monto = Convert.ToDouble(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value);
            //_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value = (_Dbl_Monto - Convert.ToDouble(_P_Txt_MontoComprob.Text)).ToString("#,##0.00");
            _Dg_Comprobante.Rows.Insert(0, _Ob_Fila);
            _Dg_Comprobante.Rows[0].Cells[0].ReadOnly = true; 
            _Lis_CuentasEditables.Add(_P_Str_Cuenta);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_ActualizarMontosComprobante();
            _Bt_CancelarComprob.PerformClick();
        }

        private void _Mtd_EditarCuentaEditable(string _P_Str_Cuenta, string _P_Str_DescripCuenta, TextBox _P_Txt_MontoComprob)
        {
            if (_Dg_Comprobante.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells[0].Value).Trim() != Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[0].Value).Trim()).Any(x => Convert.ToString(x.Cells[0].Value).Trim() == _P_Str_Cuenta.Trim()))
            {
                MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!_Mtd_VerifContTextBoxVarcharNoCero(_P_Txt_MontoComprob))
            {
                MessageBox.Show("El campo Monto es obligatorio.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[0].Value = _P_Str_Cuenta;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[1].Value = null;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[2].Value = _P_Str_DescripCuenta;
            if (string.IsNullOrEmpty(Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value)))
            {
                _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value = "";
                _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[4].Value = Convert.ToDouble(_P_Txt_MontoComprob.Text).ToString("#,##0.00");
            }
            else
            {
                _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value = Convert.ToDouble(_P_Txt_MontoComprob.Text).ToString("#,##0.00");
                _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[4].Value = "";
            }
            _Lis_CuentasEditables.Add(_P_Str_Cuenta);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_ActualizarMontosComprobante();
            _Bt_CancelarComprob.PerformClick();
        }

        private void _Mtd_EliminarCuentaEditable(int _P_Int_RowIndex)
        {
            _Dg_Comprobante.Rows.RemoveAt(_P_Int_RowIndex);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_ActualizarMontosComprobante();
        }

        private bool _Mtd_EsCuentaEditable(string _P_Str_Cuenta)
        {
            return _Lis_CuentasEditables.Exists(x => x == _P_Str_Cuenta);
        }

        private void _Mtd_InicializarListaCuentasEditables(string _P_Str_Proveedor,string _P_Str_ProcesoContable)
        {
            _Lis_CuentasEditables.Clear();
            if (_Cmb_TipoProvD.SelectedIndex > 0 && _Cmb_TipoProvD.SelectedValue.ToString().Trim() == "0" && _Rb_Fact.Checked)
            {
                string _Str_Cadena = "SELECT ctcount FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND LEN(LTRIM(RTRIM(ctcount)))>0";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                    _Lis_CuentasEditables.Add(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                else
                {
                    _Str_Cadena = "SELECT TPROCESOSCONTD.ccount FROM TPROCESOSCONTD INNER JOIN TCOUNT ON " +
                    "TPROCESOSCONTD.ccount = TCOUNT.ccount WHERE (TPROCESOSCONTD.cidproceso = '" + _P_Str_ProcesoContable + "') AND " +
                    "(TCOUNT.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TPROCESOSCONTD.cideprocesod=1)";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                        _Lis_CuentasEditables.Add(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                }
            }
        }

        private string _Mtd_ComprobanteContableRetencion(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetencion + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
                return _Ds.Tables[0].Rows[0][0].ToString();
            return "";
        }

        private void _Mtd_ConfigurarControles()
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            if (_Cmb_TipoProvD.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void _Mtd_HabilitarIvaCredNoComp()
        {
            _Chk_IvaCredNoCom.Checked = false;
            if (_Cmb_TipoProvD.SelectedIndex > 0 && _Cmb_CategProvD.SelectedIndex > 0 && _Rb_Fact.Checked && !_Rb_SinIva.Checked)
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

        private void Frm_RelPagProv_Load(object sender, EventArgs e)
        {
            _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
            _Mtd_CentrarPaneles();
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            _Dg_Grid.DataSource = null;
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
            _Dg_Grid.DataSource = null;
        }

        private void _Cmb_CategProv_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Evento_CheckedChanged_ParaImpuestos(object sender, EventArgs e)
        {
            _Mtd_ConfigurarPanelImpuestos();
        }

        private void _Cmb_TipoProvD_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Ini(); _Mtd_DesHabilitarNuevo(); _ChkList_Prov.Items.Clear(); _Mtd_CargarCategProvD(); _Cmb_CategProvD.Enabled = false;
            if (_Cmb_TipoProvD.SelectedIndex > 0)
            {
                _Cmb_CategProvD.Enabled = true;
                if (_Cmb_TipoProvD.SelectedValue.ToString().Trim() == "1")
                {
                    _Mtd_CargarListaCheckProv(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), "");
                    _Cmb_CategProvD.Enabled = false;
                }
            }
            _Mtd_SetearContexMenuStrip();
        }
        string _Str_Proveedor = "";
        string _Str_ConsultaISLR = "";
        private void _ChkList_Prov_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if ((_ChkList_Prov.CheckedItems.Count == 0 & e.NewValue == CheckState.Checked) | (_ChkList_Prov.CheckedItems.Count == 1 & e.NewValue == CheckState.Checked))
            {
                _Mtd_Ini(); _Mtd_DesHabilitarNuevo();
                _Str_Proveedor = _Str_ChkListProveedor[e.Index];
                string _Str_CategProvTemp = _Cmb_CategProvD.SelectedValue.ToString().Trim();
                _Mtd_SeleccionarCategoriaProvee(_Str_Proveedor);
                _Mtd_HabilitarNuevo();
                _Rb_ConIva.Checked = true;
                _Rb_Fact.Focus();
                foreach (int _MyItem in _ChkList_Prov.CheckedIndices)
                {
                    _ChkList_Prov.SetItemChecked(_MyItem, false);
                }
                //-------------------------------------
                _Mtd_SeleccionarProveedor(_Str_Proveedor);
                if (_ChkList_Prov.Items.Count > 1 & _ChkList_Prov.CheckedItems.Count > 0)
                {
                    if (_Str_CategProvTemp != _Cmb_CategProvD.SelectedValue.ToString().Trim())
                    {
                        e.NewValue = CheckState.Unchecked;
                    }
                }
                //-------------------------------------
                if (_Cmb_TipoProvD.SelectedIndex > 0 & _Cmb_CategProvD.SelectedIndex > 0 & _Str_Proveedor.Trim().Length > 0)
                { _Str_ConsultaISLR = _Mtd_DeterminarSqlISLR(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Cmb_CategProvD.SelectedValue.ToString().Trim(), _Str_Proveedor); }
                else { _Str_ConsultaISLR = ""; }
                //-------------------------------------
            }
            else if (_ChkList_Prov.CheckedItems.Count == 1 & e.NewValue == CheckState.Unchecked & e.Index == _ChkList_Prov.SelectedIndex)
            { _Str_Proveedor = ""; _Str_ConsultaISLR = ""; _Mtd_Ini(); _Mtd_DesHabilitarNuevo(); }
        }

        private void _Dtp_Emision_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Vencimiento.MinDate = _Dtp_Emision.Value.AddDays(1);
            _Dtp_Vencimiento.Value = _Dtp_Emision.Value.AddDays(1);
        }

        private void _Cmb_CategProvD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CategProvD.SelectedIndex > 0)
            { _Mtd_CargarListaCheckProv(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Cmb_CategProvD.SelectedValue.ToString().Trim()); }
            else
            { _Mtd_Ini(); _Mtd_DesHabilitarNuevo(); _ChkList_Prov.Items.Clear(); }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (!_Cmb_TipoProvD.Enabled & _Cmb_TipoProvD.SelectedIndex == 0)
                { e.Cancel = true; }
            }
        }

        private void Frm_RelPagProv_Activated(object sender, EventArgs e)
        {
            _Mtd_ConfigurarControles();
        }
        bool _Bol_Pnl_ISLR_Enabled = false;
        private void _Rb_TipoDocument_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                _Mtd_EstablecerTipDocumnt();
                _Dg_Comprobante.Rows.Clear();
            }
            _Mtd_SetearContexMenuStrip();
            _Txt_DocAfect.Text = "";
            _Txt_DocAfect.Enabled = ((RadioButton)sender).Checked & ((RadioButton)sender).Name == "_Rb_NC";
            _Chk_AplicaInvend.Enabled = ((RadioButton)sender).Checked & (((RadioButton)sender).Name == "_Rb_NC" || ((RadioButton)sender).Name == "_Rb_ND");
            _Chk_AplicaInvend.Checked = true;
            _Mtd_HabilitarIvaCredNoComp();
            if (((RadioButton)sender).Name == "_Rb_NC" & _Pnl_Visor_ISLR.Enabled)
            { _Bol_Pnl_ISLR_Enabled = true; _Pnl_Visor_ISLR.Enabled = false; }
            else if (((RadioButton)sender).Name != "_Rb_NC" & _Bol_Pnl_ISLR_Enabled)
            { _Pnl_Visor_ISLR.Enabled = true; _Bol_Pnl_ISLR_Enabled = false; }
        }

        private void _Txt_Documento_TextChanged(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Clear();
        }

        private void _Txt_NumCtrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NumCtrl, e, 8, 0);
        }

        private void _Txt_NumCtrl_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NumCtrl.Text)) { _Txt_NumCtrl.Text = ""; }
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

        private void _Txt_BaseImpon_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_BaseImpon, e, 15, 2);
        }

        private void _Txt_BaseImpon_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_BaseImpon.Text)) { _Txt_BaseImpon.Text = ""; }
            _Mtd_CalularMontos();
        }

        private void _Chk_ISRL_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_ISRL.Checked)
            {
                if (_Rb_SinIva.Checked)
                {
                    _Txt_MontoExcento.TextChanged -= new EventHandler(_Txt_MontoExcento_TextChanged);
                    if (_Txt_MontoExcento.Text.Trim().Length == 0)
                    { _Txt_MontoExcento.Text = "0"; }
                    _Txt_MontoExcento.TextChanged += new EventHandler(_Txt_MontoExcento_TextChanged);
                    //---------------------
                    _Txt_BaseImpon.TextChanged -= new EventHandler(_Txt_BaseImpon_TextChanged);
                    if (_Txt_BaseImpon.Text.Trim().Length == 0)
                    { _Txt_BaseImpon.Text = "0"; }
                    _Txt_BaseImpon.TextChanged += new EventHandler(_Txt_BaseImpon_TextChanged);
                    if (Convert.ToDouble(_Txt_MontoExcento.Text.Trim()) <= 0)
                    { MessageBox.Show("Debe ingresar el monto excento", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); _Chk_ISRL.Checked = false; _Txt_MontoExcento.Focus(); }
                    else
                    { _Pnl_ISLR.Visible = true; _Bt_ISLR.Enabled = true; }
                }
                else
                {
                    _Txt_MontoExcento.TextChanged -= new EventHandler(_Txt_MontoExcento_TextChanged);
                    if (_Txt_MontoExcento.Text.Trim().Length == 0)
                    { _Txt_MontoExcento.Text = "0"; }
                    _Txt_MontoExcento.TextChanged += new EventHandler(_Txt_MontoExcento_TextChanged);
                    //---------------------
                    _Txt_BaseImpon.TextChanged -= new EventHandler(_Txt_BaseImpon_TextChanged);
                    if (_Txt_BaseImpon.Text.Trim().Length == 0)
                    { _Txt_BaseImpon.Text = "0"; }
                    _Txt_BaseImpon.TextChanged += new EventHandler(_Txt_BaseImpon_TextChanged);
                    if (Convert.ToDouble(_Txt_BaseImpon.Text.Trim()) <= 0)
                    { MessageBox.Show("Debe ingresar la base imponible", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); _Chk_ISRL.Checked = false; _Txt_BaseImpon.Focus(); }
                    else
                    { _Pnl_ISLR.Visible = true; _Bt_ISLR.Enabled = true; }
                }
            }
            else
            { _Txt_ISLR.Text = ""; _Bt_ISLR.Enabled = false; }
        }

        private void _Bt_Alicuota_Click(object sender, EventArgs e)
        {
            string _Str_Alicuota = _Txt_Alicuota.Text.Trim();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(56, _Txt_Alicuota, 1, "");
            _Frm.ShowDialog();
            if (_Txt_Alicuota.Text.Trim() != _Str_Alicuota)
            { _Mtd_CalularMontos(); }
        }

        private void _Pnl_Impuestos_VisibleChanged(object sender, EventArgs e)
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
                { if (Convert.ToString(_Dg_Impuestos.Rows[0].Cells[0].Value).Trim().Length == 0) { _Rb_SinIva.Checked = true; } }
                else if (_Dg_Impuestos.RowCount == 0) { _Rb_SinIva.Checked = true; }
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Pnl_Varias.Visible)
            {
                if (_Dg_Impuestos.CurrentCell != null)
                {
                    if (_Dg_Impuestos.Rows[_Dg_Impuestos.CurrentCell.RowIndex].Cells[0].Value != null)
                    {
                        _Dg_Impuestos.Rows.RemoveAt(_Dg_Impuestos.CurrentCell.RowIndex);
                        if (_Dg_Impuestos.RowCount == 0)
                        {
                            _Dg_Impuestos.Rows.Add();
                        }
                    }
                    _Mtd_CalcularTotalesImpuestos();
                }
            }
            else if (_Pnl_ISLR.Visible)
            {
                if (_Dg_ISLR.CurrentCell != null)
                {
                    if (_Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells[3].Value != null)
                    {
                        _Dg_ISLR.Rows.RemoveAt(_Dg_ISLR.CurrentCell.RowIndex);
                        if (_Dg_ISLR.RowCount == 0)
                        {
                            _Dg_ISLR.Rows.Add();
                        }
                    }
                    _Mtd_CalcularTotalesISLR();
                }
            }
        }

        private void _Bt_Varias_Click(object sender, EventArgs e)
        {
            _Pnl_Varias.Visible = true;
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

        private void _Bt_Cerrar_ISLR_Click(object sender, EventArgs e)
        {
            _Pnl_ISLR.Visible = false;
        }

        private void _Bt_Cerrar_Varias_Click(object sender, EventArgs e)
        {
            _Pnl_Varias.Visible = false;

        }

        private void _Bt_Aceptar_Varias_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarGridImpuesto() | (_Dg_Impuestos.RowCount == 1 & _Dg_Impuestos.Rows[0].Cells[0].Value == null))
            { _Dg_Impuestos.EndEdit(); _Mtd_CalcularTotalesImpuestos(); _Pnl_Varias.Visible = false; }
            else
            { MessageBox.Show("Algunos datos estan incompletos. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Aceptar_ISLR_Click(object sender, EventArgs e)
        {
            if (_Mtd_CalcularTotalesISLR())
            { _Pnl_ISLR.Visible = false; }
        }
        private double _Mtd_ObtenerBaseImponible()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            //------------
            if (_Txt_BaseImpon.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImpon.Text); }
            //------------
            if (_Txt_MontoExcento.Text.Trim().Length > 0)
            { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExcento.Text); }
            //------------
            return _Dbl_BaseImpon + _Dbl_MontoExcento;
        }
        private bool _Mtd_ObtenerISLR(string _Pr_Str_Formula, string _Pr_Str_BaseImpo, Controles._Ctrl_Busqueda _P_Ctrl_Busqueda, int _P_Int_RowIndex)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_R = "";
            CLASES.cls_ExcelFuncion ExcelFuncion = new CLASES.cls_ExcelFuncion();
            string _Str_Sql = "";
            string _Str_Formula = "";
            bool _Bol_Sw = false;
            char[] words = new char[0];
            string[] words_var = new string[0];
            string[] words_const = new string[0];
            string _Str_VarMontoPagar = "BI";
            string _Str_VarIB = "IB";
            string _Str_Asus = "A";
            string _Str_Bsus = "B", _Str_Bimp = "";
            double _Dbl_Sustarendo = 0;
            int _Int_C = 0;
            int _Int_Ini = 0;
            DataSet _Ds = new DataSet();
            _Str_Formula = _Pr_Str_Formula;
            string _Str_Cad = "";
            //CARGO LOS PARAMETROS
            _Str_Sql = "SELECT cvarislrib,csustraendoa,csustraendob,cvarislrmpagar,cvarislrbi FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_VarIB = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrib"]).Trim();
                _Str_Asus = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]).Trim();
                _Str_Bsus = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]).Trim();
                _Str_VarMontoPagar = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrmpagar"]).Trim();
                _Str_Bimp = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrbi"]).Trim();
            }
            //las variables
            words = _Pr_Str_Formula.ToCharArray();
            foreach (char s in words)
            {
                if (s.ToString() == "{")
                {
                    _Int_Ini = _Int_C;
                }
                if (s.ToString() == "}")
                {
                    _Str_Cad = _Pr_Str_Formula.Substring(_Int_Ini, (_Int_C - _Int_Ini) + 1);
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_VarMontoPagar)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_VarIB)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_Bimp)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                }
                _Int_C++;
            }
            _Int_C = 0;
            foreach (char s in words)
            {
                _Bol_Sw = false;
                if (s.ToString() == "[")
                {
                    _Int_Ini = _Int_C;
                }
                if (s.ToString() == "]")
                {
                    _Str_Cad = _Pr_Str_Formula.Substring(_Int_Ini, (_Int_C - _Int_Ini) + 1);

                    _Str_Sql = "select cunitrib,cvalor,csustraendoa,csustraendob from TUNITRIBUT where cdelete=0";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Str_Cad.Replace("]", "").Replace("[", "") == Convert.ToString(_Ds.Tables[0].Rows[0]["cunitrib"]))
                        {
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["cvalor"]));
                            _Bol_Sw = true;
                        }
                        if (_Str_Cad.Replace("]", "").Replace("[", "") == _Str_Asus)
                        {
                            _Dbl_Sustarendo = _Dbl_Sustarendo + Convert.ToDouble(_Ds.Tables[0].Rows[0]["csustraendoa"]);
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]));
                            _Bol_Sw = true;
                        }
                        if (_Str_Cad.Replace("]", "").Replace("[", "") == _Str_Bsus)
                        {
                            _Dbl_Sustarendo = _Dbl_Sustarendo + Convert.ToDouble(_Ds.Tables[0].Rows[0]["csustraendob"]);
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]));
                            _Bol_Sw = true;
                        }
                    }

                    if (!_Bol_Sw)
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cidentif,cconst_valor from TCONST where cidentif='" + _Str_Cad.Replace("[", "").Replace("]", "") + "'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["cconst_valor"]));
                        }
                    }
                }
                _Int_C++;
            }
            try
            { _Str_R = ExcelFuncion._Mtd_UsarFuncion(_Str_Formula); }
            catch
            { _Str_R = "0"; }
            _Str_Sql = "SELECT cvalor FROM TUNITRIBUT WHERE cdelete=0";
            double _Dbl_UT = 0;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cvalor"]).Trim().Length > 0)
                {
                    _Dbl_UT = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cvalor"]);
                }
            }
            //_Dbl_Sustarendo = _Dbl_Sustarendo * _Dbl_UT;
            ExcelFuncion._Mtd_Cerrar();
            ExcelFuncion = null;
            if (_Str_R != "ERROR")
            {
                _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells["_Col_Islr"].Value = _Str_R;
                _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells["_Col_Sust"].Value = _Dbl_Sustarendo;
                if (_P_Ctrl_Busqueda != null)
                {
                    _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells["_Col_For"].Value = _P_Ctrl_Busqueda._Mtd_RetornarStringCelda(2, _P_Int_RowIndex);
                    _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells["_Col_Id_Islr"].Value = _P_Ctrl_Busqueda._Mtd_RetornarStringCelda(1, _P_Int_RowIndex);
                    _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells["_Col_Id_For"].Value = _P_Ctrl_Busqueda._Mtd_RetornarStringCelda(3, _P_Int_RowIndex);
                    _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex].Cells["_Col_Alic"].Value = _Mtd_ObtenerAlicuotaISLR(_P_Ctrl_Busqueda._Mtd_RetornarStringCelda(3, _P_Int_RowIndex), _Str_R);// _P_Ctrl_Busqueda._Mtd_RetornarStringCelda(6, _P_Int_RowIndex);
                }
                Cursor = Cursors.Default;
                return true;
            }
            Cursor = Cursors.Default;
            return false;
        }
        private string _Mtd_ObtenerAlicuotaISLR(string _P_Str_ID_Formula, string _P_Str_Monto)
        {
            if (_P_Str_Monto.Trim().Length == 0)
            { _P_Str_Monto = "0"; }
            string _Str_Cadena = "SELECT TOP 1 calicuota FROM TFORMULASD WHERE cformula_id='" + _P_Str_ID_Formula + "' AND (cexpresion='?' OR (cexpresion='<=' AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Monto)) + "'<=chasta) OR (cexpresion='>' AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Monto)) + "'>chasta)) ORDER BY CAST(REPLACE(REPLACE(calicuota,',','.'),'%','') AS NUMERIC(18,2))";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0%";
        }
        private bool _Mtd_ExistenciaISLR(string _P_Str_ID_ISLR)
        {
            foreach (DataGridViewRow _DgRow in _Dg_ISLR.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Col_Id_Islr"].Value).Trim() == _P_Str_ID_ISLR.Trim())
                {
                    return true;
                }
            }
            return false;
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
        private void _Pnl_ISLR_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_ISLR.Visible)
            {
                _Tb_Tab.Enabled = false;
                if (_Txt_ISLR.Text.Trim().Length == 0 | _Dg_ISLR.RowCount == 0)
                { _Dg_ISLR.Rows.Clear(); _Dg_ISLR.Rows.Add(); _Dg_ISLR.Rows[0].Cells[0].Value = _Mtd_ObtenerBaseImponible(); }
                else if (_Dg_ISLR.RowCount > 0)
                { if (Convert.ToString(_Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[0].Value).Trim().Length > 0) { _Dg_ISLR.Rows.Add(); } }
            }
            else
            {
                _Mtd_EliminarNulosGridISLR(); _Tb_Tab.Enabled = true;
                if (_Dg_ISLR.RowCount == 1)
                { if (Convert.ToDouble(_Dg_ISLR.Rows[0].Cells[0].Value) <= 0) { _Chk_ISRL.Checked = false; } }
                else if (_Dg_ISLR.RowCount == 0)
                { _Chk_ISRL.Checked = false; }
            }
        }
        private string _Mtd_ObtenerDescripISLR(string _P_Str_ID_ISLR)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdescrip FROM TISLR WHERE cislr_id='" + _P_Str_ID_ISLR + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return ""; }
        }
        private string _Mtd_ObtenerFormula(string _P_Str_ID_Formula)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cformula FROM TFORMULAS WHERE cformula_id='" + _P_Str_ID_Formula + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return ""; }
        }
        bool _Bol_Boleano2 = false;
        private void _Dg_ISLR_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano2)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress2);
                _Bol_Boleano2 = true;
            }
        }

        void Control_KeyPress2(object sender, KeyPressEventArgs e)
        {
            if (_Dg_ISLR.CurrentCell.ColumnIndex == 0)
            {
                _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2);
            }
        }

        private void _Dg_ISLR_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    _Str_ValorCeldaTem = _Dg_ISLR.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }

        private void _Dg_ISLR_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().Length == 0)
                    {
                        if (_Str_ValorCeldaTem != "XXXX")
                            _Dg_ISLR.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem;
                    }
                    else
                    {
                        if (Convert.ToString(_Dg_ISLR.Rows[e.RowIndex].Cells[1].Value).Trim().Length > 0)
                        {
                            _Mtd_ObtenerISLR(_Mtd_ObtenerFormula(Convert.ToString(_Dg_ISLR.Rows[e.RowIndex].Cells["_Col_Id_For"].Value).Trim()), Convert.ToString(_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value), null, e.RowIndex);
                            if (!_Mtd_CalcularTotalesISLR())
                            {
                                MessageBox.Show("La suma de los montos de la Base Imponible del Cálculo del ISLR sobrepasa el total de la Base Imponible y Monto Excento de la " + _Txt_TipoDoc.Text.Trim() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Dg_ISLR.Rows.RemoveAt(e.RowIndex);
                                if (_Dg_ISLR.RowCount == 1) { _Dg_ISLR.Rows[0].Cells[0].Value = _Mtd_ObtenerBaseImponible(); }
                                _Mtd_CalcularTotalesISLR();
                            }
                        }
                    }
                }
                else
                {
                    if (_Str_ValorCeldaTem != "XXXX")
                        _Dg_ISLR.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem;
                }
            }
        }

        private void _Dg_ISLR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 2)
                {
                    if (_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        if (Convert.ToDouble(_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value) > 0)
                        {
                            Frm_Busqueda2 _Frm = new Frm_Busqueda2(57, _Str_ConsultaISLR);
                            _Frm.ShowDialog();
                            if (_Frm._Str_FrmResult == "1")
                            {
                                if (!_Mtd_ExistenciaISLR(_Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, _Frm._Dg_Grid.CurrentCell.RowIndex)))
                                {
                                    if (_Mtd_ObtenerISLR(_Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Frm._Dg_Grid.CurrentCell.RowIndex), Convert.ToString(_Dg_ISLR.Rows[e.RowIndex].Cells[0].Value), _Frm._Ctrl_Busqueda1, _Frm._Dg_Grid.CurrentCell.RowIndex))
                                    {
                                        if (_Mtd_CalcularTotalesISLR())
                                        {
                                            if (_Dg_ISLR.CurrentCell.RowIndex == _Dg_ISLR.RowCount - 1)
                                            {
                                                _Dg_ISLR.Rows.Add();
                                                _Dg_Cel = _Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[0];
                                                _Dg_ISLR.CurrentCell = _Dg_Cel;
                                            }
                                            else
                                            {
                                                _Dg_Cel = _Dg_ISLR.Rows[_Dg_ISLR.CurrentCell.RowIndex + 1].Cells[0];
                                                _Dg_ISLR.CurrentCell = _Dg_Cel;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("La suma de los montos de la Base Imponible del Cálculo del ISLR sobrepasa el total de la Base Imponible y Monto Excento de la " + _Txt_TipoDoc.Text.Trim() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            _Dg_ISLR.Rows.RemoveAt(e.RowIndex);
                                            if (e.RowIndex == _Dg_ISLR.RowCount - 1 | _Dg_ISLR.RowCount <= 1)
                                            { _Dg_ISLR.Rows.Add(); if (_Dg_ISLR.RowCount == 1) { _Dg_ISLR.Rows[0].Cells[0].Value = _Mtd_ObtenerBaseImponible(); } }
                                            _Dg_Cel = _Dg_ISLR.Rows[_Dg_ISLR.RowCount - 1].Cells[0];
                                            _Dg_ISLR.CurrentCell = _Dg_Cel;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya seleccionó esta opción para el cálculo del ISLR.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Algunos datos estan incompletos. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Algunos datos estan incompletos. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        private void _Bt_ISLR_Click(object sender, EventArgs e)
        {
            _Pnl_ISLR.Visible = true;
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
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    _Str_Cadena = "Select ctcount,cactivate from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    { return false; }
                    else if (_Ds.Tables[0].Rows[0]["ctcount"].ToString().Trim().ToUpper() != "D" || _Ds.Tables[0].Rows[0]["cactivate"].ToString().Trim().ToUpper() != "1")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Verifica si todas las cuentas agregadas tiene monto mayor a cero
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_VerificarMontosCuentas()
        {
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            bool _Bol_Return = true;
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells[3].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells[4].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //---------------------------
                        if (Convert.ToDouble(_Ob_DebeD) <= 0 && Convert.ToDouble(_Ob_HaberD) <= 0)
                        {
                            _Bol_Return = false;
                        }
                    }
                }
            };
            return _Bol_Return;
        }
        /// <summary>
        /// Verifica si la cuenta ya ha sido ingresada.
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Int_RowIndex">Índice de la fila</param>
        /// <returns></returns>
        private bool _Mtd_ValidarCuenta(string _P_Str_Cuenta, int _P_Int_RowIndex)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Cuenta & _Dg_Row.Index != _P_Int_RowIndex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns></returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }
        private string _Mtd_ObtenerDescripProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_abreviado FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }
        private string _Mtd_ObtenerDescripComerProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }
        private string _Mtd_ObtenerDescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Descrip = "";
            if (_Rb_NC.Checked)
            { _Str_Descrip = " S/NC # " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Mtd_ObtenerDescripComerProveedor(_Str_Proveedor) + ". VEC: " + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value); }
            else if (_Rb_ND.Checked)
            { _Str_Descrip = " S/ND # " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Mtd_ObtenerDescripComerProveedor(_Str_Proveedor) + ". VEC: " + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value); }
            else
            { _Str_Descrip = " S/F # " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Mtd_ObtenerDescripComerProveedor(_Str_Proveedor) + ". VEC: " + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value); }
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + _Str_Descrip; }
            else
            { return ""; }
        }
        private void _Mtd_HabilitarCeldaXXXX(bool _P_Bol_Habilitar)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() == "XXXX")
                { _Dg_Row.Cells[0].ReadOnly = !_P_Bol_Habilitar; }
                else
                { _Dg_Row.Cells[0].ReadOnly = true; }
            }
        }
        private string _Mtd_TotalDebeHaber(int _P_Int_Col_Index)
        {
            double _Dbl_Total = 0;
            object _Ob_Valor = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_Valor = _Dg_Row.Cells[_P_Int_Col_Index].Value;
                        if (_Ob_Valor == null)
                        { _Ob_Valor = 0; }
                        else if (_Ob_Valor.ToString().Trim().Length == 0)
                        { _Ob_Valor = 0; }
                        _Dbl_Total += Convert.ToDouble(_Ob_Valor);
                    }
                }
            }
            return _Dbl_Total.ToString("#,##0.00");
        }
        private double _Mtd_MontoPlanAhorro(string _P_Str_ProcesoCont, string _P_Str_Proveedor)
        {
            if (_P_Str_ProcesoCont == "P_CTASPAGAR")
            {
                string _Str_Cadena = "select ISNULL(TPLANAHORROTRANS.cporcentaje,0) from TPROVEEDOR INNER JOIN TPLANAHORROTRANS ON TPROVEEDOR.ccompany=TPLANAHORROTRANS.ccompany AND TPROVEEDOR.cidplanahorro=TPLANAHORROTRANS.cidplanahorro where cproveedor='" + _P_Str_Proveedor + "' and TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    double _Dbl_MontoTotal = 0;
                    double.TryParse(_Txt_BaseImpon.Text, out _Dbl_MontoTotal);
                    double _Dbl_Porc = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    return CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2((_Dbl_MontoTotal * _Dbl_Porc) / 100);
                }
            }
            return 0;
        }
        private void _Mtd_VisualizarComprobante(string _P_Str_ProcesoCont, string _P_Str_Documento, string _P_Str_Proveedor, string _P_Str_TipoProv, DateTime _P_Str_FechaVenc)
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Impuesto = 0;
            double _Dbl_Invendible = 0;
            double _Dbl_DescuentoFinanciero = 0;
            _Dg_Comprobante.Rows.Clear();
            //------------
            if (_Txt_BaseImpon.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImpon.Text); }
            //------------
            if (_Txt_MontoExcento.Text.Trim().Length > 0)
            { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExcento.Text); }
            //------------
            if (_Txt_Impuesto.Text.Trim().Length > 0)
            { _Dbl_Impuesto = Convert.ToDouble(_Txt_Impuesto.Text); }
            //------------
            if (_Txt_Invendible.Text.Trim().Length > 0)
            { _Dbl_Invendible = Convert.ToDouble(_Txt_Invendible.Text); }
            //------------
            if (_Txt_DescuentoFinanciero.Text.Trim().Length > 0)
            { _Dbl_DescuentoFinanciero = Convert.ToDouble(_Txt_DescuentoFinanciero.Text); }
            //------------
            int _Int_SwTipoDoc = 0;
            if (_Rb_Fact.Checked)
            { _Int_SwTipoDoc = 1; }
            else if (_Rb_ND.Checked)
            { _Int_SwTipoDoc = 2; }
            else
            { _Int_SwTipoDoc = 3; }
            //------------
            var _List_Alicuotas = new List<_Cls_Impuesto>();
            if (_Rb_ConIva.Checked)
            {
                _List_Alicuotas.Add(new _Cls_Impuesto { Alicuota = _Txt_Alicuota.Text, Impuesto = _Dbl_Impuesto });
            }
            else if (_Rb_Varias.Checked)
            {
                _Dg_Impuestos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[0].Value != null).ToList().ForEach(x =>
                {
                    _List_Alicuotas.Add(new _Cls_Impuesto { Alicuota = x.Cells["Alicuota"].Value.ToString(), Impuesto = Convert.ToDouble(x.Cells["Impuesto"].Value) });
                });
            }
            else
            {
                _List_Alicuotas.Add(new _Cls_Impuesto { Alicuota = "", Impuesto = 0 });
            }
            //------------
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_ProcesoCont);
            if (_P_Str_ProcesoCont == "P_CTASPAGAR" || _P_Str_ProcesoCont == "P_CTASPAGAR_IVACNC" || _P_Str_ProcesoCont == "P_CTASPAGARMP" || _P_Str_ProcesoCont == "CXP_NDP" || _P_Str_ProcesoCont == "CXP_NDPSO" || _P_Str_ProcesoCont == "CXP_NCP" || _P_Str_ProcesoCont == "CXP_NCPSO")
            {
                _My_Cls_ProcesosCont._Mtd_Proceso_CTAXPAGAR(_Dg_Comprobante, _P_Str_Documento, _P_Str_Proveedor, _P_Str_TipoProv, (_Dbl_BaseImpon + _Dbl_MontoExcento), _Dbl_Impuesto, _Cls_Formato._Mtd_fecha(_P_Str_FechaVenc), _Mtd_MontoPlanAhorro(_P_Str_ProcesoCont, _P_Str_Proveedor), _Dbl_Invendible, _Dbl_DescuentoFinanciero, _List_Alicuotas);
            }
            else if (_P_Str_ProcesoCont == "P_CXP_ACC" || _P_Str_ProcesoCont == "P_CXP_ACC_ND" || _P_Str_ProcesoCont == "P_CXP_ACC_NC")
            {
                _My_Cls_ProcesosCont._Mtd_Proceso_P_CXP_ACC(_Dg_Comprobante, _P_Str_Documento, _P_Str_Proveedor, _P_Str_TipoProv, (_Dbl_BaseImpon + _Dbl_MontoExcento), _Dbl_Impuesto, _Cls_Formato._Mtd_fecha(_P_Str_FechaVenc), _Int_SwTipoDoc, _Dbl_Invendible, _Dbl_DescuentoFinanciero, _List_Alicuotas);
            }
            else if (_P_Str_ProcesoCont == "P_CXP_CIARELAC" || _P_Str_ProcesoCont == "P_CxP_NDP_CIA_RELAC" || _P_Str_ProcesoCont == "P_CxP_NCP_CIA_RELAC")
            {
                _My_Cls_ProcesosCont._Mtd_Proceso_P_CXP_CIARELAC(_Dg_Comprobante, _P_Str_Documento, _P_Str_Proveedor, _P_Str_TipoProv, (_Dbl_BaseImpon + _Dbl_MontoExcento), _Dbl_Impuesto, _Cls_Formato._Mtd_fecha(_P_Str_FechaVenc), _Int_SwTipoDoc, _Dbl_Invendible, _Dbl_DescuentoFinanciero, _List_Alicuotas);
            }
            if (_Dg_Comprobante.RowCount > 0)
            {
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
            }
            //Guardo, la cantidad de registros obtenidos
            _Int_CantidadDeRegistrosComprobante = _Dg_Comprobante.Rows.Count;
            //Guardo el monto original
            _Dbl_MontoExcentoOriginal = (_Dbl_BaseImpon + _Dbl_MontoExcento) - _Dbl_Invendible;
            //Guardo la plantilla del primer registro
            _Dgvr_RegistroComprobante = new DataGridViewRow();
            _Dgvr_RegistroComprobante = _Dg_Comprobante.Rows[0];

            _Mtd_HabilitarCeldaXXXX(true);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private bool _Mtd_DebeIgualHaber(string _P_Str_TipoProv)
        {
            double _Dbl_Debe = Convert.ToDouble(_Mtd_TotalDebeHaber(3));
            double _Dbl_Haber = Convert.ToDouble(_Mtd_TotalDebeHaber(4));
            if (_P_Str_TipoProv.Trim() == "1")
            {
                _Dbl_Haber = Math.Round(_Dbl_Haber, 3);
                _Dbl_Debe = Math.Round(_Dbl_Debe, 3);
            }
            else
            {
                _Dbl_Haber = Math.Round(_Dbl_Haber, 2);
                _Dbl_Debe = Math.Round(_Dbl_Debe, 2);
            }
            return _Dbl_Haber == _Dbl_Debe;
        }
        private double _Mtd_VerificarCelda(object _P_Ob_Valor)
        {
            if (Convert.ToString(_P_Ob_Valor).Trim().Length > 0)
            {
                return Convert.ToDouble(Convert.ToString(_P_Ob_Valor));
            }
            return 0;
        }
        private string _Mtd_NombAbrevProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_abreviado FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            return "";
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
        private int _Mtd_GenerarComprobCxP()
        {
            //-------------------------------------------------------
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Mtd_ObtenerProcesoCont(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Cmb_CategProvD.SelectedValue.ToString().Trim(), _Str_Proveedor));
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------
            int _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(3))) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(4))) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','1','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            //-------------------------------------------------------
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            string _Str_DescripD = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells[3].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells[4].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //---------------------------
                        _Str_DescripD = Convert.ToString(_Dg_Row.Cells[2].Value).Trim().ToUpper();
                        //------------------------------------------------------------------------
                        if (Convert.ToDouble(_Ob_DebeD) > 0 || Convert.ToDouble(_Ob_HaberD) > 0)
                        {
                            _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "','" + _Str_DescripD.Replace("'", "''") + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        if (Convert.ToDouble(_Ob_DebeD) > 0)
                        {
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Str_Proveedor, _Str_DescripD.Replace("'", "''"), Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "D");
                        }
                        else if (Convert.ToDouble(_Ob_HaberD) > 0)
                        {
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Str_Proveedor, _Str_DescripD.Replace("'", "''"), Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "H");
                        }
                    }
                }
            }
            return _Int_Comprobante;
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
                if(_Rb_NC.Checked)
                {
                    string _Str_Naturaleza = _Row["cnaturaleza"].ToString().Trim().ToUpper() == "D" ? "H" : "D";
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Str_TipoDocRecIVA, _P_Str_C_ID_ComprobRet, _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Str_Naturaleza); 
                }
                else
                { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Str_TipoDocRecIVA, _P_Str_C_ID_ComprobRet, _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Retencion), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["cnaturaleza"].ToString().Trim().ToUpper()); }
            }
            return _Int_Comprobante;
        }
        private int _Mtd_GenerarComprobRetenISLR(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_CatCompRel, string _P_Str_CatAccion, double _P_Dbl_ISLR, string _P_Str_ID_Ret_ISLR)
        {
            string _Str_PROCESOCONTABLE = "";
            if (_P_Str_TipoProv.Trim() == "0")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
            }
            else if (_P_Str_TipoProv.Trim() == "1")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
            }
            else if (_P_Str_TipoProv.Trim() == "2" & _P_Str_CategProv.Trim().ToUpper() == _P_Str_CatCompRel.Trim().ToUpper())
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETISLRCR";
            }
            else if (_P_Str_TipoProv.Trim() == "2" & _P_Str_CategProv.Trim().ToUpper() == _P_Str_CatAccion.Trim().ToUpper())
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETISLRAC";
            }
            else
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
            }
            //-------------------------------------------------------
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_PROCESOCONTABLE);
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------
            int _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','0','0')";//Preguntar si el cstatus se debe guardar en 0 ó en 1.
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            //-------------------------------------------------------
            int _Int_corder = 0;
            string _Str_Cuenta = "";
            string _Str_Descrip = "";
            string _Str_DescripD = "";
            string _Str_NombProveedor = _Mtd_NombAbrevProveedor(_Str_Proveedor);
            string _Str_TipoDocRecISLR = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr");
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
                if (_Rb_Fact.Checked)
                { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION ISLR # " + _P_Str_ID_Ret_ISLR + " S/F# " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Str_NombProveedor + " VEC:" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                else if (_Rb_ND.Checked)
                { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION ISLR # " + _P_Str_ID_Ret_ISLR + " S/N.D# " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Str_NombProveedor + " VEC:" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                else
                { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION ISLR # " + _P_Str_ID_Ret_ISLR + " S/N.C# " + _Txt_Documento.Text.Trim().ToUpper() + " " + _Str_NombProveedor + " VEC:" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                //-------------
                if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "D")
                { _Str_Cadena = "INSERT into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + _Int_corder.ToString() + "','" + _Str_Cuenta + "','" + _Str_TipoDocRecISLR + "','" + _P_Str_ID_Ret_ISLR + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')"; }
                else if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "H")
                { _Str_Cadena = "INSERT into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + _Int_corder.ToString() + "','" + _Str_Cuenta + "','" + _Str_TipoDocRecISLR + "','" + _P_Str_ID_Ret_ISLR + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Str_TipoDocRecISLR, _P_Str_ID_Ret_ISLR, _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["cnaturaleza"].ToString().Trim().ToUpper());
            }
            return _Int_Comprobante;
        }

        private string _Mtd_ObtenerCodigoConcepto(string _P_Str_Id_Islr,string _P_Str_Id_Formula)
        {
            string _Str_Cadena = "SELECT CASE WHEN cpnrformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pnr WHEN cpnnrformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pnnr WHEN cpjdformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pjd WHEN cpjndformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pjnd ELSE '0' END " +
            "FROM TISLR INNER JOIN TISLRCODCONCEP ON TISLR.cislr_id=TISLRCODCONCEP.cislr_id WHERE TISLR.cislr_id='" + _P_Str_Id_Islr + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }

        public void _Mtd_GuardarCxP()
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
            {
                //-------------
                string _Str_NotaRecep = "0"; if (_Txt_NotaRecep.Text.Trim().Length > 0) { _Str_NotaRecep = _Txt_NotaRecep.Text.Trim(); }
                string _Str_FechaNotaRecep = "null"; if (_Txt_FechNotRecep.Text.Trim().Length > 0) { _Str_FechaNotaRecep = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_FechNotRecep.Text.Trim())); }
                if (_Str_FechaNotaRecep != "null") { _Str_FechaNotaRecep = "'" + _Str_FechaNotaRecep + "'"; }
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
                if (_Txt_ISLR.Text.Trim().Length == 0) { _Txt_ISLR.Text = "0"; }
                if (_Txt_Alicuota.Text.Trim().Length == 0) { _Txt_Alicuota.Text = "0"; }
                //--------------------------------------------------------------------
                string _Str_NumControl = _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper();
                //--------------------------------------------------------------------
                double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
                //--------------------------------------------------------------------
                string _Str_TipoDocISLR = "";
                string _Str_ProvRetISLR = "";
                string _Str_TipoDocRetIVA = "";
                string _Str_ProvRetIVA = "";
                string _Str_CatCompaRel = "";
                string _Str_CatAccion = "";
                string _Str_TipoDocFact = "";
                double _Dbl_Alicuota = 0;
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretislr,cprovretislr,cprovretiva,ctipdocretiva,ccatproveciarel,ccatproveaccio,ctipdocfact FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_TipoDocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
                    _Str_ProvRetISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretislr"]);
                    _Str_TipoDocRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                    _Str_ProvRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretiva"]);
                    _Str_CatCompaRel = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]);
                    _Str_CatAccion = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]);
                    _Str_TipoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                }
                //--------------------------------------------------------------------
                string _Str_ID_Factura_CxP = "";
                string _Str_Cadena = "";
                string _Str_ProcesoCont = _Mtd_ObtenerProcesoCont(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Cmb_CategProvD.SelectedValue.ToString().Trim(), _Str_Proveedor);
                double _Dbl_MontoPlanAhorro = _Mtd_MontoPlanAhorro(_Str_ProcesoCont, _Str_Proveedor);
                double _Dbl_Saldo = Convert.ToDouble(_Txt_Total.Text) - _Dbl_MontoPlanAhorro;
                if (_Bol_Editar)
                {
                    _Str_ID_Factura_CxP = _Mtd_ObtenerFacturaEditanto(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper());
                    _Mtd_AnularGeneradosCxP(_Str_ID_Factura_CxP);
                    _Str_Cadena = "UPDATE TFACTPPAGARM SET cidnotrecepc='" + _Str_NotaRecep + "',cfechaemision='" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "',cdateemifactura='" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "',cfechavencimiento='" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "',ctotalimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "',ctotalsimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text)) + "',canulado='0',cactivo='1',cmontoinvendible='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Invendible.Text)) + "',cfechanotrecep=" + _Str_FechaNotaRecep + ",cfacturaactivo='0',csaldo='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Saldo) + "',cnumdocuctrl='" + _Str_NumControl + "',ctotmontexcento='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "',ctotal='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "',ctotalislr='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "',cdocumentafect='" + _Txt_DocAfect.Text.Trim().ToUpper() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "',cmontoplanahorro='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoPlanAhorro) + "',civacrednocomp='" + Convert.ToInt32(_Chk_IvaCredNoCom.Checked) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Str_ID_Factura_CxP + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TMOVCXPM SET cfechaemision='" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "',cfechavencimiento='" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "',ctotalimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "',ctotalsimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text)) + "',canulado='0',cactivo='1',csaldo='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Saldo) + "',ctotalislr='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "',ctotal='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Txt_Documento.Text.Trim().ToUpper() + "' AND ctipodocument='" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "' AND cproveedor='" + _Str_Proveedor + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else
                {
                    _Str_ID_Factura_CxP = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                    _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,cfacturaactivo,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cdateemifactura,cdocumentafect,cdateadd,cuseradd,cmontoplanahorro,civacrednocomp) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP + "','" + _Str_Proveedor + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Str_NotaRecep + "','" + _Cmb_TipoProvD.SelectedValue.ToString().Trim() + "','" + _Str_CategoriaProveedor + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text)) + "','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Invendible.Text)) + "'," + _Str_FechaNotaRecep + ",'0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Saldo) + "','" + _Str_NumControl + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Txt_DocAfect.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoPlanAhorro) + "','" + Convert.ToInt32(_Chk_IvaCredNoCom.Checked) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Proveedor + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text)) + "','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Saldo) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                //--------------------------------------------------------------------
                if (_Rb_ConIva.Checked)
                {
                    _Dbl_Alicuota = Convert.ToDouble(_Txt_Alicuota.Text);
                    string _Str_ID_Factura_CxP_Imp = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetafactxp) FROM TFACTPPAGARIMPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp=" + _Str_ID_Factura_CxP);
                    _Str_Cadena = "INSERT INTO TFACTPPAGARIMPD (cgroupcomp,ccompany,cidfactxp,ciddetafactxp,cimpuesto,cmontosimp,cmontoimp,cmontoinvendible,cmontototal,cmontoexcento) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP + "','" + _Str_ID_Factura_CxP_Imp + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alicuota.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImpon.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Invendible.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else if (_Rb_Varias.Checked)
                {
                    string _Str_ID_Factura_CxP_Imp = "";
                    double _Dbl_Impuesto = 0;
                    double _Dbl_Total_D = 0;
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
                                _Dbl_Alicuota = Convert.ToDouble(_Ob_Alicuota);
                                _Dbl_Impuesto = Math.Round(((Convert.ToDouble(_Ob_BaseImponible) - _Dbl_InvendibleD) * Convert.ToDouble(_Ob_Alicuota)) / 100, 2);
                                _Dbl_Total_D = (Convert.ToDouble(_Ob_BaseImponible) - _Dbl_InvendibleD) + _Dbl_Impuesto + _Dbl_MontoExcentoD;

                                _Str_ID_Factura_CxP_Imp = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetafactxp) FROM TFACTPPAGARIMPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp=" + _Str_ID_Factura_CxP);
                                _Str_Cadena = "INSERT INTO TFACTPPAGARIMPD (cgroupcomp,ccompany,cidfactxp,ciddetafactxp,cimpuesto,cmontosimp,cmontoimp,cmontoinvendible,cmontototal,cmontoexcento) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP + "','" + _Str_ID_Factura_CxP_Imp + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_Alicuota)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_BaseImponible)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_InvendibleD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcentoD) + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Dbl_MontoExcentoD = 0;
                            }
                        }
                    }
                }
                //--------------------------------------------------------------------
                if (_Chk_ISRL.Checked)
                {
                    if (Convert.ToDouble(_Txt_ISLR.Text) > 0)
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveedor,cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Str_ProvRetISLR + "'");
                        string _Str_ProvRetISLR_Categoria = "";
                        string _Str_ProvRetISLR_Tipo = "";
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_ProvRetISLR_Categoria = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveedor"]);
                            _Str_ProvRetISLR_Tipo = Convert.ToString(_Ds.Tables[0].Rows[0]["cglobal"]);
                        }
                        //---------------------------
                        string _Str_ID_Ret_ISLR = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidcomprobislr) FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                        //--------RETENCIÓN EXTERNA
                        if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                        {
                            _Str_ID_Ret_ISLR = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(cidcomprobislr) FROM TCOMPROBANISLRC WHERE ccompany='" + _Str_CompanyRetenExterna + "'");
                        }
                        //--------
                        int _Int_ComprobRetISLR = _Mtd_GenerarComprobRetenISLR(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Str_CategoriaProveedor, _Str_CatCompaRel, _Str_CatAccion, Convert.ToDouble(_Txt_ISLR.Text), _Str_ID_Ret_ISLR);
                        _Str_Cadena = "INSERT INTO TCOMPROBANISLRC (ccompany,cidcomprobislr,cidcomprob,cproveedor,cfechaemiislr,cnumdocumafec,cnumctrldocumafec,ctotmontosi,ctotretenido,ctotsustraendo,cformula,cfechavencislr,ctotcaomp_iva,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_ID_Ret_ISLR + "','" + _Int_ComprobRetISLR.ToString() + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Str_NumControl + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text) + Convert.ToDouble(_Txt_BaseImpon.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','0','" + Convert.ToString(_Dg_ISLR.Rows[0].Cells["_Col_Id_For"].Value) + "','" + _Cls_VariosMetodos._Mtd_ObtenerFechaLimite(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //--------RETENCIÓN EXTERNA
                        if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                        {
                            _Str_Cadena = "INSERT INTO TCOMPROBANISLRC (ccompany,cidcomprobislr,cidcomprob,cproveedor,cfechaemiislr,cnumdocumafec,cnumctrldocumafec,ctotmontosi,ctotretenido,ctotsustraendo,cformula,cfechavencislr,ctotcaomp_iva,cimpreso,cagregacomp,cdateadd,cuseradd) VALUES ('" + _Str_CompanyRetenExterna + "','" + _Str_ID_Ret_ISLR + "','" + _Int_ComprobRetISLR.ToString() + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Str_NumControl + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text) + Convert.ToDouble(_Txt_BaseImpon.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','0','" + Convert.ToString(_Dg_ISLR.Rows[0].Cells["_Col_Id_For"].Value) + "','" + _Cls_VariosMetodos._Mtd_ObtenerFechaLimite(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','1','" + Frm_Padre._Str_Comp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        //--------
                        //---------------------------
                        //CUENTA POR PAGAR DE RETENCION DE ISLR AL PROVEEDOR DE RETENCION
                        string _Str_ID_Factura_CxP_ISLR = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                        _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_ISLR + "','" + _Str_ProvRetISLR + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','0','" + _Str_ProvRetISLR_Tipo + "','" + _Str_ProvRetISLR_Categoria + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','0',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ProvRetISLR + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //---------------------------
                        //CUENTA POR PAGAR DE RETENCION ISLR AL PROVEEDOR QUE SE LE AFECTA(DISMINUYE)
                        string _Str_ID_Factura_CxP_ISLR_Prov = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                        _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_ISLR_Prov + "','" + _Str_Proveedor + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','0','" + _Cmb_TipoProvD.SelectedValue.ToString().Trim() + "','" + _Str_CategoriaProveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','0',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text) * -1) + "','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text) * -1) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Proveedor + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value) + "','0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text) * -1) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_ISLR.Text) * -1) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //---------------------------
                        string _Str_Formula = "";
                        string _Str_DescripISLR = "";
                        string _Str_ID_Factura_CxP_ISLR_D = "";
                        string _Str_ID_Ret_ISLR_D = "";
                        string _Str_CodigoConcepto = "";
                        foreach (DataGridViewRow _Dg_Row in _Dg_ISLR.Rows)
                        {
                            if (Convert.ToString(_Dg_Row.Cells["_Col_Base"].Value).Trim().Length > 0 & Convert.ToString(_Dg_Row.Cells["_Col_Islr"].Value).Trim().Length > 0)
                            {
                                _Str_Formula = _Mtd_ObtenerFormula(Convert.ToString(_Dg_Row.Cells["_Col_Id_For"].Value).Trim());
                                _Str_DescripISLR = _Mtd_ObtenerDescripISLR(Convert.ToString(_Dg_Row.Cells["_Col_Id_Islr"].Value).Trim());
                                _Str_CodigoConcepto = _Mtd_ObtenerCodigoConcepto(Convert.ToString(_Dg_Row.Cells["_Col_Id_Islr"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Id_For"].Value).Trim());
                                _Str_ID_Factura_CxP_ISLR_D = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetaislrfactxp) FROM TFACTPPAGARISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp=" + _Str_ID_Factura_CxP);
                                _Str_Cadena = "INSERT INTO TFACTPPAGARISLRD (cgroupcomp,ccompany,cidfactxp,ciddetaislrfactxp,cmontosimp,cformula,cmontoislr,cislr_id,cformula_id,csustraendo,calicuota) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP + "','" + _Str_ID_Factura_CxP_ISLR_D + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Base"].Value)) + "','" + _Str_Formula + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Islr"].Value)) + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Id_Islr"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Id_For"].Value).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Sust"].Value)) + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Alic"].Value).Trim() + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Str_ID_Ret_ISLR_D = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetalleislr) FROM TCOMPROBANISLRD WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                                //--------RETENCIÓN EXTERNA
                                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                                {
                                    _Str_ID_Ret_ISLR_D = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(ciddetalleislr) FROM TCOMPROBANISLRD WHERE ccompany='" + _Str_CompanyRetenExterna + "'");
                                }
                                //--------
                                _Str_Cadena = "INSERT INTO TCOMPROBANISLRD (ccompany,cidcomprobislr,cproveedor,ciddetalleislr,ctdocument,cnumdocu,cnumcontrolfact,cfechadocu,cconcepto,cmontosi,calicuota,csustraendo,cretenido,cdateadd,cuseradd,ccodconcepto) VALUES('" + Frm_Padre._Str_Comp + "','" + _Str_ID_Ret_ISLR + "','" + _Str_Proveedor + "','" + _Str_ID_Ret_ISLR_D + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Str_NumControl + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Str_DescripISLR + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Base"].Value)) + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Alic"].Value).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Sust"].Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Islr"].Value)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CodigoConcepto + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                //--------RETENCIÓN EXTERNA
                                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                                {
                                    _Str_Cadena = "INSERT INTO TCOMPROBANISLRD (ccompany,cidcomprobislr,cproveedor,ciddetalleislr,ctdocument,cnumdocu,cnumcontrolfact,cfechadocu,cconcepto,cmontosi,calicuota,csustraendo,cretenido,cdateadd,cuseradd,ccodconcepto) VALUES('" + _Str_CompanyRetenExterna + "','" + _Str_ID_Ret_ISLR + "','" + _Str_Proveedor + "','" + _Str_ID_Ret_ISLR_D + "','" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + _Str_NumControl + "','" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "','" + _Str_DescripISLR + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Base"].Value)) + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Alic"].Value).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Sust"].Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_VerificarCelda(_Dg_Row.Cells["_Col_Islr"].Value)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CodigoConcepto + "')";
                                    Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                                //--------
                            }
                        }
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET cidcomprobislr='" + _Str_ID_Ret_ISLR + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Str_ID_Factura_CxP + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
                //--------------------------------------------------------------------
                //_Mtd_ObtenerRestanteOrdPago
                var _Bol_GenerarRet = true;
                if (_Rb_NC.Checked)
                {
                    var _Dbl_MontoRetanteOp = _Cls_VariosMetodos._Mtd_ObtenerAbonoOrdPago(_Txt_DocAfect.Text.Trim(), _Str_TipoDocFact, _Str_Proveedor);
                    _Bol_GenerarRet = _Dbl_MontoRetanteOp == 0;
                }
                //--------------------------------------------------------------------
                if (_Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp) && (_Rb_100.Checked | _Rb_75.Checked) && _Bol_GenerarRet)
                {
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveedor,cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Str_ProvRetIVA + "'");
                    string _Str_ProvRetIVA_Categoria = "";
                    string _Str_ProvRetIVA_Tipo = "";
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
                        _Str_Cadena = "INSERT INTO TCOMPROBANRETC (ccompany,cidcomprobret,cidcomprob,cproveedor,cfechaemiret,cnumdocumafec,ctotcaomp_iva,ctotmontexcento,cimpuesto,cretenido,cimpreso,cascii,canulado,cfechavencret,cporcnreten,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_C_ID_ComprobRet + "','" + _Int_ComprobRetencion + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion) + "','0','0','0','" + _Cls_VariosMetodos._Mtd_ObtenerFechaLimite(_Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value)) + "','" + _Int_PorcReten + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        //--------RETENCIÓN EXTERNA
                        if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                        {
                            _Str_Cadena = "INSERT INTO TCOMPROBANRETC (ccompany,cidcomprobret,cidcomprob,cproveedor,cfechaemiret,cnumdocumafec,ctotcaomp_iva,ctotmontexcento,cimpuesto,cretenido,cimpreso,cascii,canulado,cfechavencret,cporcnreten,cagregacomp,cdateadd,cuseradd) VALUES ('" + _Str_CompanyRetenExterna + "','" + _Str_C_ID_ComprobRet + "','" + _Int_ComprobRetencion + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Documento.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExcento.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retencion) + "','1','0','0','" + _Cls_VariosMetodos._Mtd_ObtenerFechaLimite(_Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value)) + "','" + _Int_PorcReten + "','" + Frm_Padre._Str_Comp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
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
                        _Str_Cadena = "UPDATE TFACTPPAGARM set cidcomprobret='" + _Str_C_ID_ComprobRet + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Str_Proveedor + "' and ctipodocument='" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "' and cnumdocu='" + _Txt_Documento.Text.Trim().ToUpper() + "'";
                        if (_Cmb_TipoProvD.SelectedValue.ToString().Trim() == "1")
                        { _Str_Cadena = _Str_Cadena + " AND cidnotrecepc='" + _Str_NotaRecep + "'"; }
                        Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        //-------------------------
                    }
                }
                //--------------------------------------------------------------------
                int _Int_ComprobanteCxP = _Mtd_GenerarComprobCxP();
                //--------------------------------------------------------------------
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cidcomprob='" + _Int_ComprobanteCxP + "',calicuota='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Alicuota) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Str_ID_Factura_CxP + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET cidcomprob='" + _Int_ComprobanteCxP + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + Convert.ToString(_Txt_TipoDoc.Tag).Trim() + "' AND cnumdocu='" + _Txt_Documento.Text.Trim().ToUpper() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //--------------------------------------------------------------------
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                MessageBox.Show("La operación ha sido realizada correctamente.\nSe va a proceder a imprimir el comprobante: " + _Mtd_RetornarID_Correl(_Int_ComprobanteCxP.ToString()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_ImprimirComprobante(_Int_ComprobanteCxP.ToString());
                _Cmb_TipoProvD.SelectedIndex = 0;
                _Cmb_TipoProvD.Enabled = false;
                _Tb_Tab.SelectedIndex = 0;
                _Mtd_Actualizar();
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
            }
            else
            { MessageBox.Show("Problemas de conexión para crear las retenciones. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private string _Mtd_RetornarID_Correl(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcorrel FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        /// <summary>
        /// Obtiene un valor que indica si el mes contable en que fue generado un comprobante de una CxP es igual al mes contable actual.
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_VerificarMesComprobanteCxP(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Factura_CxP + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TFACTPPAGARM INNER JOIN TCOMPROBANC ON TFACTPPAGARM.ccompany = TCOMPROBANC.ccompany AND TFACTPPAGARM.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TFACTPPAGARM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTPPAGARM.cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (dbo.TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return true;//Si llega hasta aqui hubo un error en la creación del comprobante.
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
        private bool _Mtd_FacturaAnulada(string _P_Str_ID_Factura_CxP)
        {
            string _Str_Cadena = "SELECT canulado FROM TFACTPPAGARM WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cidfactxp = '" + _P_Str_ID_Factura_CxP + "') AND (canulado='1' or cestatusfirma='1')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_FacturaDeRetencionManual(string _P_Str_Proveedor, string _P_Str_TipoDoc, string _P_Str_Documet)
        {
            string _Str_Cadena = "SELECT TCOMPROBANRETD.cnumdocu FROM TCOMPROBANRETC INNER JOIN TCOMPROBANRETD ON TCOMPROBANRETC.ccompany=TCOMPROBANRETD.ccompany AND TCOMPROBANRETC.cidcomprobret=TCOMPROBANRETD.cidcomprobret WHERE TCOMPROBANRETC.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETD.cproveedor='" + _P_Str_Proveedor + "' AND TCOMPROBANRETD.ctdocument='" + _P_Str_TipoDoc + "' AND TCOMPROBANRETD.cnumdocu='" + _P_Str_Documet + "' AND TCOMPROBANRETC.cmanual='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_FacturaDeRetencionIslrManual(string _P_Str_Proveedor, string _P_Str_TipoDoc, string _P_Str_Documet)
        {
            string _Str_Cadena = "SELECT TCOMPROBANISLRD.cnumdocu FROM TCOMPROBANISLRC INNER JOIN TCOMPROBANISLRD ON TCOMPROBANISLRC.ccompany=TCOMPROBANISLRD.ccompany AND TCOMPROBANISLRC.cidcomprobislr=TCOMPROBANISLRD.cidcomprobislr WHERE TCOMPROBANISLRC.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBANISLRD.cproveedor='" + _P_Str_Proveedor + "' AND TCOMPROBANISLRD.ctdocument='" + _P_Str_TipoDoc + "' AND TCOMPROBANISLRD.cnumdocu='" + _P_Str_Documet + "' AND TCOMPROBANISLRC.cmanual='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_MismoProvRetencISLR(string _P_Str_Proveedor)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cprovretislr FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _P_Str_Proveedor.Trim() == _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return false;
        }
        private bool _Mtd_VerificarExistMovCxp(string _P_Str_Proveedor, string _P_Str_TipoDoc, string _P_Str_Documet)
        {
            string _Str_Cadena = "SELECT cnumdocu FROM TMOVCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND cnumdocu='" + _P_Str_Documet + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarFactEnOrdenPago(string _P_Str_Proveedor, string _P_Str_TipoDoc, string _P_Str_Documet)
        {
            string _Str_Cadena = "SELECT cidordpago FROM VST_PAGOS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND cnumdocu='" + _P_Str_Documet + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND canulado='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private string _Mtd_ObtenerFacturaEditanto(string _P_Str_Proveedor, string _P_Str_TipoDoc, string _P_Str_Documet)
        {
            string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND cnumdocu='" + _P_Str_Documet + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows[0][0].ToString().Trim();
        }
        private bool _Mtd_VerificarFacturacompra(string _P_Str_Proveedor, string _P_Str_Documet)
        {
            string _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND cnfacturapro='" + _P_Str_Documet + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_TipoDocumentNCValidado(string _P_Str_Proveedor)
        {
            if (_Rb_NC.Checked)
            {
                string _Str_TipoDocFact = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
                string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _Str_TipoDocFact + "' AND cnumdocu='" + _Txt_DocAfect.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                return _Ds.Tables[0].Rows.Count > 0;
            }
            else
            { return true; }
        }
        bool _Bol_Editar = false;
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            //-------------
            bool _Bol_DebeIgualHaber = _Mtd_DebeIgualHaber(_Cmb_TipoProvD.SelectedValue.ToString().Trim());
            bool _Bol_VerificarCuentas = _Mtd_VerificarCuentas();
            bool _Bol_VerificarMontosCuentas = _Mtd_VerificarMontosCuentas();
            bool _Bol_MismoProvRetencISLR = _Mtd_MismoProvRetencISLR(_Str_Proveedor);
            bool _Bol_VerificarFacturacompra = _Mtd_VerificarFacturacompra(_Str_Proveedor, _Txt_Documento.Text.Trim());
            _Rb_75.Checked = false; _Rb_100.Checked = false;
            bool _Bol_ProveedorRetenConfig = _Mtd_ProveedorRetenConfig(_Str_Proveedor);
            bool _Bol_TipoDocumentNCValidado = _Mtd_TipoDocumentNCValidado(_Str_Proveedor);
            //-------------
            if (_Dg_Comprobante.RowCount > 0 & _Bol_DebeIgualHaber & _Bol_VerificarCuentas & _Bol_VerificarMontosCuentas & (_Bol_ProveedorRetenConfig | !_Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp)) & (_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) | _Chk_FactMaqFis.Checked) & _Mtd_VerifContTextBoxVarcharNoCero(_Txt_Documento) & ((_Mtd_VerifContTextBoxNumeric(_Txt_MontoExcento) & _Rb_SinIva.Checked) | (_Txt_MontoExcento.Text.Trim().Length > 0 & !_Rb_SinIva.Checked)) & ((_Rb_ConIva.Checked & _Mtd_VerifContTextBoxNumeric(_Txt_BaseImpon) | !_Rb_ConIva.Checked)) & ((!_Bol_MismoProvRetencISLR & _Chk_ISRL.Checked) | !_Chk_ISRL.Checked) & ((_Mtd_VerifContTextBoxVarcharNoCero(_Txt_DocAfect) & _Rb_NC.Checked) | !_Rb_NC.Checked) & _Bol_TipoDocumentNCValidado)// & (!_Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp) | (_Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp) & (_Rb_75.Checked | _Rb_100.Checked)))
            {
                if (_Bol_VerificarFacturacompra)
                { MessageBox.Show("Estos datos ya fueron ingresados anteriormente desde el módulo de compras. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else if (!_Mtd_VerificarExistMovCxp(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text))
                {
                    bool _Bol_IntroducirClave = false;
                    if (_Chk_IvaCredNoCom.Enabled && _Chk_IvaCredNoCom.Checked)
                    {
                        _Bol_IntroducirClave = MessageBox.Show("¿Esta seguro de que la factura es IVA crédito no compensado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
                    }
                    else if (_Chk_IvaCredNoCom.Enabled)
                    {
                        _Bol_IntroducirClave = MessageBox.Show("¿Esta seguro de que la factura no es IVA crédito no compensado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
                    }
                    else
                    {
                        _Bol_IntroducirClave = true;
                    }
                    if (_Bol_IntroducirClave)
                    { _Bol_Editar = false; _Ctrl_Clave _Ctrl = new _Ctrl_Clave(4, this); }
                }
                else
                {
                    if (_Mtd_VerificarFactEnOrdenPago(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text))
                    { MessageBox.Show("Estos datos ya fueron ingresados anteriormente.\nNo es posible editar la factura ya que se le ha generado una orden de pago.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    {
                        string _Str_ID_Factura_CxP = _Mtd_ObtenerFacturaEditanto(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper());
                        bool _Bol_VerificarComprobISLRImpreso = _Mtd_VerificarComprobISLRImpreso(_Str_ID_Factura_CxP);
                        bool _Bol_VerificarComprobRETENImpreso = _Mtd_VerificarComprobRETENImpreso(_Str_ID_Factura_CxP);
                        bool _Bol_VerificarMesComprobanteCxP = _Mtd_VerificarMesComprobanteCxP(_Str_ID_Factura_CxP);
                        bool _Bol_FacturaAnulada = _Mtd_FacturaAnulada(_Str_ID_Factura_CxP);
                        bool _Bol_FacturaDeRetencionManual = _Mtd_FacturaDeRetencionManual(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper());
                        bool _Bol_FacturaDeRetencionIslrManual = _Mtd_FacturaDeRetencionIslrManual(_Str_Proveedor, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper());
                        if (_Bol_VerificarComprobISLRImpreso | _Bol_VerificarComprobRETENImpreso | !_Bol_VerificarMesComprobanteCxP | _Bol_FacturaAnulada | _Bol_FacturaDeRetencionManual | _Bol_FacturaDeRetencionIslrManual)
                        {
                            if (_Bol_FacturaAnulada)
                            { MessageBox.Show("Estos datos ya fueron ingresados anteriormente.\nNo es posible editar la factura ya que ha sido anulada o esta en proceso de anulación.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else if (!_Bol_VerificarMesComprobanteCxP)
                            { MessageBox.Show("Estos datos ya fueron ingresados anteriormente.\nNo es posible editar la factura ya que el mes contable del comprobante de la factura actual no es igual al mes contable actual.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else if (_Bol_VerificarComprobISLRImpreso)
                            { MessageBox.Show("Estos datos ya fueron ingresados anteriormente.\nNo es posible editar la factura ya que se ha actualizado el comprobante de ISLR de la factura.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else if (_Bol_VerificarComprobRETENImpreso)
                            { MessageBox.Show("Estos datos ya fueron ingresados anteriormente.\nNo es posible editar la factura ya que se ha actualizado el comprobante de retención de impuesto de la factura.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else if (_Bol_FacturaDeRetencionManual)
                            {MessageBox.Show("Estos datos ya fueron ingresados desde la carga de reteciones de IVA manual.\nNo se pueden guardar los datos ingresados. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else if (_Bol_FacturaDeRetencionIslrManual)
                            { MessageBox.Show("Estos datos ya fueron ingresados desde la carga de reteciones de ISLR manual.\nNo se pueden guardar los datos ingresados. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                        else
                        {
                            if (MessageBox.Show("Estos datos ya fueron ingresados anteriormente. \nSi usted continúa se modificarán los datos ingresados anteriormente, se anularan los comprobantes que fueron generados \ny se crearan los nuevos comprobantes.\n¿Esta seguro de continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                bool _Bol_IntroducirClave = false;
                                if (_Chk_IvaCredNoCom.Enabled && _Chk_IvaCredNoCom.Checked)
                                {
                                    _Bol_IntroducirClave = MessageBox.Show("¿Esta seguro de que la factura es IVA crédito no compensado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
                                }
                                else if (_Chk_IvaCredNoCom.Enabled)
                                {
                                    _Bol_IntroducirClave = MessageBox.Show("¿Esta seguro de que la factura no es IVA crédito no compensado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
                                }
                                else
                                {
                                    _Bol_IntroducirClave = true;
                                }
                                if (_Bol_IntroducirClave)
                                { _Bol_Editar = true; _Ctrl_Clave _Ctrl = new _Ctrl_Clave(4, this); }
                            }
                        }
                    }
                }
            }
            else
            {
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) & !_Chk_FactMaqFis.Checked) { _Er_Error.SetError(_Txt_NumCtrl, "Información Requerida!!!"); }
                if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Documento)) { _Er_Error.SetError(_Txt_Documento, "Información Requerida!!!"); }
                if ((!_Mtd_VerifContTextBoxNumeric(_Txt_MontoExcento) & _Rb_SinIva.Checked) | _Txt_MontoExcento.Text.Trim().Length == 0 & !_Rb_SinIva.Checked) { _Er_Error.SetError(_Txt_MontoExcento, "Información Requerida!!!"); }
                if (_Rb_ConIva.Checked & !_Mtd_VerifContTextBoxNumeric(_Txt_BaseImpon)) { _Er_Error.SetError(_Txt_BaseImpon, "Información Requerida!!!"); }
                if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_DocAfect) & _Rb_NC.Checked) { _Er_Error.SetError(_Txt_DocAfect, "Información Requerida!!!"); }
                if ((_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) | _Chk_FactMaqFis.Checked) & _Mtd_VerifContTextBoxVarcharNoCero(_Txt_Documento) & ((_Mtd_VerifContTextBoxNumeric(_Txt_MontoExcento) & _Rb_SinIva.Checked) | (_Txt_MontoExcento.Text.Trim().Length > 0 & !_Rb_SinIva.Checked)) & ((_Rb_ConIva.Checked & _Mtd_VerifContTextBoxNumeric(_Txt_BaseImpon) | !_Rb_ConIva.Checked)) & ((_Mtd_VerifContTextBoxVarcharNoCero(_Txt_DocAfect) & _Rb_NC.Checked) | !_Rb_NC.Checked))
                {
                    //if (_Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp) & !_Rb_75.Checked & !_Rb_100.Checked) { MessageBox.Show("Debe seleccionar el porcentaje a retener.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    if (_Dg_Comprobante.RowCount == 0) { MessageBox.Show("Debe visualizar el comprobante.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (!_Bol_VerificarCuentas) { MessageBox.Show("El registro contable solo puede realizarce con cuentas de detalle que estén activas.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (!_Bol_VerificarMontosCuentas) { MessageBox.Show("El registro contable posee algunas cuentas con monto menor o igual a cero. Verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (!_Bol_DebeIgualHaber) { MessageBox.Show("Los totales del comprobante no son iguales. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (_Bol_MismoProvRetencISLR & _Chk_ISRL.Checked) { MessageBox.Show("El proveedor seleccionado es el mismo proveedor que retiene. No se puede relizar la operación.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (!_Bol_ProveedorRetenConfig & _Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp)) { MessageBox.Show("Debe configurar el porcentaje de retención del proveedor, de lo contrario debe configurarlo como exento de retención.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (!_Bol_TipoDocumentNCValidado) { MessageBox.Show("El documento afectado que introdujo no existe para el proveedor seleccionado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
            }
            return false;
        }
        private void _Bt_Visulizar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Documento) & ((_Mtd_VerifContTextBoxNumeric(_Txt_MontoExcento) & _Rb_SinIva.Checked) | (_Txt_MontoExcento.Text.Trim().Length > 0 & !_Rb_SinIva.Checked)) & ((_Rb_ConIva.Checked & _Mtd_VerifContTextBoxNumeric(_Txt_BaseImpon) | !_Rb_ConIva.Checked)))
            {
                string _Str_ProcesoCont = _Mtd_ObtenerProcesoCont(_Cmb_TipoProvD.SelectedValue.ToString().Trim(), _Cmb_CategProvD.SelectedValue.ToString().Trim(), _Str_Proveedor);
                if (_Str_ProcesoCont.Trim().Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_VisualizarComprobante(_Str_ProcesoCont.Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Str_Proveedor, Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Dtp_Vencimiento.Value);
                    if (_Rb_ConIva.Checked || _Rb_Varias.Checked) 
                    { _Mtd_ProveedorRetenConfig(_Str_Proveedor); }
                    _Mtd_InicializarListaCuentasEditables(_Str_Proveedor, _Str_ProcesoCont.Trim());
                    Cursor = Cursors.Default;
                }
                else
                { MessageBox.Show("Error. No se obtuvo el proceso contable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Documento)) { _Er_Error.SetError(_Txt_Documento, "Información Requerida!!!"); }
                if ((!_Mtd_VerifContTextBoxNumeric(_Txt_MontoExcento) & _Rb_SinIva.Checked) | _Txt_MontoExcento.Text.Trim().Length == 0 & !_Rb_SinIva.Checked) { _Er_Error.SetError(_Txt_MontoExcento, "Información Requerida!!!"); }
                if (_Rb_ConIva.Checked & !_Mtd_VerifContTextBoxNumeric(_Txt_BaseImpon)) { _Er_Error.SetError(_Txt_BaseImpon, "Información Requerida!!!"); }
            }
        }
        bool _Bol_Boleano = false;
        private void _Dg_Comprobante_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
        }

        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Comprobante.CurrentCell.ColumnIndex == 0)
            {
                _Mtd_MostrarToolTipsCell(((TextBox)sender).Text, ((TextBox)sender).Font);
            }
        }

        private void _Dg_Comprobante_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    _Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem;
                    }
                    else
                    {
                        if (_Mtd_CuentaDetalle(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), e.RowIndex))
                            {
                                _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                            }
                            else
                            {
                                MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem;
                                _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX";
                            }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX"; }
                    }
                }
                else
                { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem; }
            }
        }

        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1 & !_Dg_Comprobante.Rows[e.RowIndex].Cells[0].ReadOnly)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_VstCuentas _Frm = new Frm_VstCuentas();
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
                    {
                        if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Frm._Str_FrmNodeSelec.Trim(), e.RowIndex))
                            {
                                _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Frm._Str_FrmNodeSelec.Trim(); _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim()); _Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                            }
                            else
                            {
                                MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX";
                            }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX"; }
                    }
                    _Frm.Dispose();
                }
            }
        }

        private void _Bt_ComprobRetenc_Click(object sender, EventArgs e)
        {
            string _Str_ComprobanteContable = _Mtd_ComprobanteContableRetencion(_Str_ComprobanteRetenExist);
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
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
                }
                _Mtd_HabilitarCeldaXXXX(false);
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
        /// <summary>
        /// Devuelve un valor que indica si el tipo de documento es factura o nota de débito. Si no es ninguno devuelve false.
        /// </summary>
        /// <param name="_P_Str_TipoDoc">Tipo de documento</param>
        /// <returns>Bool</returns>
        private bool _Mtd_TipoDocumentValido(string _P_Str_TipoDoc)
        {
            string _Str_Cadena = "SELECT ctipdocfact,ctipodocndp,ctipodocncp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper() | _P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocndp"].ToString().Trim().ToUpper() | _P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocncp"].ToString().Trim().ToUpper();
            }
            return false;
        }
        private bool _Mtd_TipoDocumentFact(string _P_Str_TipoDoc)
        {
            string _Str_Cadena = "SELECT ctipdocfact FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper())
                { return true; }
            }
            return false;
        }
        private bool _Mtd_TipoDocumentNDP(string _P_Str_TipoDoc)
        {
            string _Str_Cadena = "SELECT ctipodocndp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocndp"].ToString().Trim().ToUpper())
                { return true; }
            }
            return false;
        }
        private bool _Mtd_TipoDocumentNCP(string _P_Str_TipoDoc)
        {
            string _Str_Cadena = "SELECT ctipodocncp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Str_TipoDoc.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocncp"].ToString().Trim().ToUpper())
                { return true; }
            }
            return false;
        }
        string _Str_ID_Factura_CxP_G = "";
        string _Str_ComprobanteExistente = "0";
        string _Str_ComprobanteRetenExist = "0";
        private void _Mtd_CargarFormulario(string _P_Str_ID_Factura_CxP)
        {
            //No alterar el orden de este código
            string _Str_Cadena = "SELECT cidfactxp,cglobal,ccatproveedor,cproveedor,ctipodocument,cnumdocu,cnumdocuctrl,cfechaemision,cfechavencimiento,cidnotrecepc,cfechanotrecep,dbo.Fnc_Formatear(ctotalsimp) AS ctotalsimp,dbo.Fnc_Formatear(ctotmontexcento) AS ctotmontexcento,dbo.Fnc_Formatear(ctotal) AS ctotal,dbo.Fnc_Formatear(ctotalimp) AS ctotalimp,dbo.Fnc_Formatear(cmontoinvendible) AS cmontoinvendible,cidcomprob,ISNULL(cidcomprobret,0) AS cidcomprobret,dbo.Fnc_Formatear(ctotalislr) AS ctotalislr,cordenpaghecha,cfact_afectada,ISNULL(civacrednocomp,0) AS civacrednocomp FROM VST_FACTPPAGARM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Factura_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Mtd_TipoDocumentValido(_Ds.Tables[0].Rows[0]["ctipodocument"].ToString().Trim()))
                {
                    _Str_ComprobanteExistente = "0";
                    _Str_ComprobanteRetenExist = "0";
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    _Str_ID_Factura_CxP_G = _Ds.Tables[0].Rows[0]["cidfactxp"].ToString().Trim();
                    _Cmb_TipoProvD.SelectedIndex = 0;
                    _Cmb_TipoProvD.Enabled = false;
                    _Cmb_TipoProvD.SelectedValue = _Ds.Tables[0].Rows[0]["cglobal"].ToString().Trim();
                    _Mtd_SeleccionarTipoDocumet(_Ds.Tables[0].Rows[0]["ctipodocument"].ToString().Trim());
                    if (_Ds.Tables[0].Rows[0]["cglobal"].ToString().Trim() != "1")
                    { _Cmb_CategProvD.SelectedValue = _Ds.Tables[0].Rows[0]["ccatproveedor"].ToString().Trim(); }
                    _Str_Proveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim();
                    _Mtd_SeleccionarProveedor(_Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim());
                    _ChkList_Prov.SelectedIndex = _ChkList_Prov.CheckedIndices[0];// Aqui se selecciona el proveedor para que el scroll y se pueda ver el proveedor seleccionado
                    _ChkList_Prov.SelectedIndex = -1;//Aqui se quita la seleccion para que solo se vea el item checkeado pero no se vea la seleccion.
                    _Cmb_CategProvD.Enabled = false;
                    _ChkList_Prov.Enabled = false;
                    _Txt_Documento.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().Trim();
                    if (_Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim() == "NA")
                    {
                        _Chk_FactMaqFis.Checked = true;
                    }
                    else
                    {
                        _Chk_FactMaqFis.Checked = false;
                        _Txt_NumCtrlPref.Text = _Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().Substring(0, _Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().IndexOf("-"));
                        _Txt_NumCtrl.Text = _Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().Substring(_Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().IndexOf("-") + 1);
                    }
                    if (_Ds.Tables[0].Rows[0]["cfechaemision"] != System.DBNull.Value)
                    { _Dtp_Emision.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]); }
                    if (_Ds.Tables[0].Rows[0]["cfechavencimiento"] != System.DBNull.Value)
                    {
                        if (Convert.ToDateTime(_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechavencimiento"]))) > _Dtp_Vencimiento.MinDate)
                        { _Dtp_Vencimiento.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechavencimiento"]); }
                    }
                    _Txt_NotaRecep.Text = _Ds.Tables[0].Rows[0]["cidnotrecepc"].ToString().Trim();
                    if (_Ds.Tables[0].Rows[0]["cfechanotrecep"] != System.DBNull.Value)
                    { _Txt_FechNotRecep.Text = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechanotrecep"])); }
                    _Rb_ConIva.Checked = false; _Rb_SinIva.Checked = false; _Rb_Varias.Checked = false;
                    //---------------------
                    _Txt_BaseImpon.TextChanged -= new EventHandler(_Txt_BaseImpon_TextChanged);
                    _Txt_BaseImpon.Text = _Ds.Tables[0].Rows[0]["ctotalsimp"].ToString().Trim();
                    _Txt_BaseImpon.TextChanged += new EventHandler(_Txt_BaseImpon_TextChanged);
                    //---------------------
                    _Txt_MontoExcento.TextChanged -= new EventHandler(_Txt_MontoExcento_TextChanged);
                    _Txt_MontoExcento.Text = _Ds.Tables[0].Rows[0]["ctotmontexcento"].ToString().Trim();
                    _Txt_MontoExcento.TextChanged += new EventHandler(_Txt_MontoExcento_TextChanged);
                    //---------------------
                    _Txt_Total.Text = _Ds.Tables[0].Rows[0]["ctotal"].ToString().Trim();
                    _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0]["ctotalimp"].ToString().Trim();
                    _Txt_Invendible.Text = _Ds.Tables[0].Rows[0]["cmontoinvendible"].ToString().Trim();
                    if (_Ds.Tables[0].Rows[0]["cidcomprob"] != System.DBNull.Value)
                    { _Str_ComprobanteExistente = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim(); _Mtd_VisualizarComprobanteExis(_Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim()); }
                    if (_Ds.Tables[0].Rows[0]["cidcomprobret"] != System.DBNull.Value)
                    { _Str_ComprobanteRetenExist = _Ds.Tables[0].Rows[0]["cidcomprobret"].ToString().Trim(); }
                    _Bt_ComprobRetenc.Enabled = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcomprobret"]) > 0;
                    _Txt_ISLR.Text = _Ds.Tables[0].Rows[0]["ctotalislr"].ToString().Trim();
                    //if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ORDEN_PAGO") & _Ds.Tables[0].Rows[0]["cordenpaghecha"].ToString().Trim() != "1")
                    //{ _Bt_Pagar.Enabled = true; }
                    //else
                    //{ _Bt_Pagar.Enabled = false; }
                    if ((_Cls_VariosMetodos._Mtd_ObtenerRestanteOrdPago(_Ds.Tables[0].Rows[0]["cnumdocu"].ToString().Trim(), _Ds.Tables[0].Rows[0]["ctipodocument"].ToString().Trim(), _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim()) == 0) || !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1") || !_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ORDEN_PAGO") || CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_Str_Proveedor))
                    { _Bt_Pagar.Enabled = false; }
                    else
                    { _Bt_Pagar.Enabled = true; }
                    if (_Rb_NC.Checked || _Rb_ND.Checked)
                    {
                        _Bt_Pagar.Enabled = false;
                        _Txt_DocAfect.Text = _Ds.Tables[0].Rows[0]["cfact_afectada"].ToString().Trim();
                        _Txt_DocAfect.Enabled = false;
                        _Chk_AplicaInvend.Enabled = false;
                        double _Dbl_Invendible = _Mtd_Invendible(Convert.ToString(_Cmb_TipoProvD.SelectedValue).Trim(), _Str_Proveedor);
                        if (_Dbl_Invendible > 0 & !_Mtd_VerifContTextBoxNumeric(_Txt_Invendible))
                        {
                            _Chk_AplicaInvend.CheckedChanged -= new EventHandler(_Chk_AplicaInvend_CheckedChanged);
                            _Chk_AplicaInvend.Checked = false;
                            _Chk_AplicaInvend.CheckedChanged += new EventHandler(_Chk_AplicaInvend_CheckedChanged);
                        }
                    }
                    //---------------------
                    _Chk_IvaCredNoCom.Checked = Convert.ToBoolean(Convert.ToInt32(_Ds.Tables[0].Rows[0]["civacrednocomp"].ToString().Trim()));
                    _Chk_IvaCredNoCom.Enabled = false;
                    //---------------------
                    _Tb_Tab.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Solo se pueden seleccionar facturas y notas de débito o de crédito de proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (_Mtd_FacturaAnulada(_P_Str_ID_Factura_CxP))
                { MessageBox.Show("La factura ha sido anulada o esta en proceso de anulación. No se puede realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _Bool_ModoConsulta = true;
                _Mtd_CargarFormulario(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidfactxp"].Value).Trim());
            }
        }
        string _Str_ProveeSelecOrdenPag = "";
        int _Int_Seleccionados = 0;
        double _Dbl_MontoSelecOrdenPag = 0;
        private void _Mtd_Ini_SeleccionarRegistros()
        {
            _Str_ProveeSelecOrdenPag = "";
            _Int_Seleccionados = 0;
            _Dbl_MontoSelecOrdenPag = 0;
        }
        private void _Mtd_SeleccionarRegistros(bool _P_Bol_Seleccionar, string _P_Str_Proveedor, string _P_Str_TipoDocument, string _P_Str_Documento, double _P_Dbl_Monto, string _P_Str_Id_CxP)
        {
            if (_P_Bol_Seleccionar)
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                {
                    MessageBox.Show("Los pagos de este tipo de proveedor se generan desde el consolidado de intercompañías.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool _Bol_RetIslrPorImpr = _Cls_VariosMetodos._Mtd_ObtenerStsImpresoRETISLRxFact(_P_Str_Proveedor, _P_Str_Documento, _P_Str_TipoDocument);
                bool _Bol_RetIvaPorImpr = _Cls_VariosMetodos._Mtd_ObtenerStsImpresoRETIVAxFact(_P_Str_Proveedor, _P_Str_Documento, _P_Str_TipoDocument);
                bool _Bol_RetPatentePorImpr = _Cls_VariosMetodos._Mtd_ObtenerStsImpresoRETPatentexFact(_P_Str_Proveedor, _P_Str_Documento, _P_Str_TipoDocument);
                bool _Bol_VeriricarAnulacion = _Mtd_FacturaAnulada(_P_Str_Id_CxP);
                string _Str_ImpresionComprob = _Mtd_VeririfcarImpresionComprob(_P_Str_Id_CxP);
                if ((_Dbl_MontoSelecOrdenPag + _P_Dbl_Monto >= 0) & !_Bol_RetPatentePorImpr & !_Bol_RetIslrPorImpr & !_Bol_RetIvaPorImpr & _Str_ImpresionComprob.Trim().Length == 0 & (_Str_ProveeSelecOrdenPag == "" | _Str_ProveeSelecOrdenPag == _P_Str_Proveedor) & !_Bol_VeriricarAnulacion)
                {
                    //string _Str_Cadena = "SELECT cmontlimited,cmontlimiteh FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cusuariop='" + Frm_Padre._Str_Use + "' AND ctipoproveedor=(SELECT cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "') AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoSelecOrdenPag + _P_Dbl_Monto) + "' BETWEEN cmontlimited AND cmontlimiteh";// Andres pidio quitar esto
                    //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //if (_Ds.Tables[0].Rows.Count > 0)
                    //{
                    _Int_Seleccionados += 1;
                    _Str_ProveeSelecOrdenPag = _P_Str_Proveedor;
                    _Dbl_MontoSelecOrdenPag += _P_Dbl_Monto;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    //}
                    //else
                    //{ MessageBox.Show("Usted no tiene permisos ó el monto a enviar a 'Orden de Pago' está fuera de sus límites", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else
                {
                    if (_Str_ProveeSelecOrdenPag != "" & _Str_ProveeSelecOrdenPag != _P_Str_Proveedor)
                    { MessageBox.Show("El pago debe ser solo a un proveedor", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (_Dbl_MontoSelecOrdenPag + _P_Dbl_Monto < 0)
                    { MessageBox.Show("El monto a pagar es negativo. Esta seleccionando una nota de débito cuyo monto no es válido para el proceso de pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (_Bol_VeriricarAnulacion)
                    { MessageBox.Show("La factura ha sido anulada o esta en proceso de anulación. No se puede realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (_Bol_RetIslrPorImpr)
                    { MessageBox.Show("La " + _Txt_TipoDoc.Text.Trim() + " Nº " + _Txt_Documento.Text + " tiene 'Retenciones de ISLR' por imprimir.", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (_Bol_RetPatentePorImpr)
                    { MessageBox.Show("La " + _Txt_TipoDoc.Text.Trim() + " Nº " + _Txt_Documento.Text + " tiene 'Retenciones de Patente' por imprimir.", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (_Bol_RetIvaPorImpr)
                    { MessageBox.Show("La " + _Txt_TipoDoc.Text.Trim() + " Nº " + _Txt_Documento.Text + " tiene 'Retenciones de IVA' por imprimir.", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (_Str_ImpresionComprob.Trim().Length > 0)
                    { MessageBox.Show("Debe actualizar el comprobante " + _Mtd_RetornarID_Correl(_Str_ImpresionComprob) + " del documento seleccionado que se\nencuantra en el notificador 'Comprobantes por Actualizar'", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
            }
            else
            {
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    _Int_Seleccionados -= 1;
                    _Dbl_MontoSelecOrdenPag -= _P_Dbl_Monto;
                    if (_Int_Seleccionados <= 0)
                    { _Dbl_MontoSelecOrdenPag = 0; _Str_ProveeSelecOrdenPag = ""; }
                    if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cordenpaghecha"].Value).Trim() == "1")
                    { _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.LightGray; }
                    else
                    {
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Monto"].Style.BackColor = Color.FromArgb(192, 192, 255);
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Saldo"].Style.BackColor = Color.FromArgb(255, 255, 192);
                    }
                }
            }
        }
        private void _Mtd_AnularGeneradosCxP(string _P_Str_ID_CxP)
        {
            string _Str_Cadena = "SELECT cnumdocu,ctipodocument,cproveedor,cidcomprob,cidcomprobislr,cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Documento = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().Trim();
                string _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocument"].ToString().Trim();
                string _Str_PProveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim();
                string _Str_ID_Comprob_CxP = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_ComprobRetISRL = _Ds.Tables[0].Rows[0]["cidcomprobislr"].ToString().Trim();
                string _Str_ComprobRetCOMP = _Ds.Tables[0].Rows[0]["cidcomprobret"].ToString().Trim();
                //-----------------------------------ELIMINAR RETENCIÓN DE LA COMPAÑÍA Y ANULAR COMPROBANTE
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
                            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_Comprob + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
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
                        //_Str_Cadena = "DELETE FROM TCOMPROBANRETD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobRetCOMP + "'";
                        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                        string _Str_TipoDocIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Str_ComprobRetCOMP + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TMOVCXPM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _Str_ComprobRetCOMP + "' AND ctipodocument='" + _Str_TipoDocIVA + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
                //-----------------------------------ELIMINAR RETENCIÓN ISLR Y ANULAR COMPROBANTE
                if (_Str_ComprobRetISRL.Trim().Length > 0 & _Str_ComprobRetISRL.Trim() != "0")
                {
                    _Str_Cadena = "select cidcomprob from TCOMPROBANISLRC  where ccompany='" + Frm_Padre._Str_Comp + "' and  cidcomprobislr='" + _Str_ComprobRetISRL + "' and canulado='0' AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS INNER JOIN TCONFIGCXP ON TCONFIGCXP.ccompany=VST_PAGOS.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_PAGOS.ccompany='" + Frm_Padre._Str_Comp + "' AND VST_PAGOS.cproveedor=TCOMPROBANISLRC.cproveedor AND VST_PAGOS.cnumdocu=CONVERT(VARCHAR,TCOMPROBANISLRC.cidcomprobislr,0) AND VST_PAGOS.ctipodocument=TCONFIGCXP.ctipdocretislr AND VST_PAGOS.canulado='0')";
                    //_Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                        if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                        {
                            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_Comprob + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
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
                        //_Str_Cadena = "DELETE FROM TCOMPROBANISLRD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobRetISRL + "'";
                        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
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
                //-----------------------------------ELIMINAR IMPUESTOS
                _Str_Cadena = "DELETE FROM TFACTPPAGARIMPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_CxP + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //-----------------------------------ANULAR COMPROBANTE DE CxP
                if (_Str_ID_Comprob_CxP.Trim().Length > 0)//Si viene vacio la edición se debe a un error en la creación del comprobante.
                {
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_ID_Comprob_CxP + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }
        private string _Mtd_VeririfcarImpresionComprob(string _P_Str_Id_CxP)
        {
            string _Str_Cadena = "SELECT TFACTPPAGARM.cidcomprob,ISNULL(TCOMPROBANC.cstatus,0) AS cstatus FROM TCOMPROBANC INNER JOIN TFACTPPAGARM ON TCOMPROBANC.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANC.cidcomprob = TFACTPPAGARM.cidcomprob WHERE (TFACTPPAGARM.cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (TFACTPPAGARM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTPPAGARM.cidfactxp = '" + _P_Str_Id_CxP + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cstatus"].ToString().Trim() == "0")
                { return _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim(); }
            }
            return "";
        }
        private bool _Mtd_VeriricarAnulacion(string _P_Str_Id_CxP)
        {
            string _Str_Cadena = "SELECT * FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_Id_CxP + "' AND cestatusfirma='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Pagar_Click(object sender, EventArgs e)
        {
            bool _Bol_RetIslrPorImpr = _Cls_VariosMetodos._Mtd_ObtenerStsImpresoRETISLRxFact(_Str_Proveedor, _Txt_Documento.Text.Trim().ToUpper(), "");
            bool _Bol_RetIvaPorImpr = _Cls_VariosMetodos._Mtd_ObtenerStsImpresoRETIVAxFact(_Str_Proveedor, _Txt_Documento.Text.Trim().ToUpper(), "");
            bool _Bol_VeriricarAnulacion = _Mtd_FacturaAnulada(_Str_ID_Factura_CxP_G);
            string _Str_ImpresionComprob = _Mtd_VeririfcarImpresionComprob(_Str_ID_Factura_CxP_G);
            if (_Txt_Total.Text.Trim().Length == 0) { _Txt_Total.Text = "0"; }
            //string _Str_Cadena = "SELECT cmontlimited,cmontlimiteh FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cusuariop='" + Frm_Padre._Str_Use + "' AND ctipoproveedor=(SELECT cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + _Str_Proveedor + "') AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "' BETWEEN cmontlimited AND cmontlimiteh";// Andres pidio quitar esto
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //if (_Ds.Tables[0].Rows.Count > 0 & !_Bol_RetIslrPorImpr & !_Bol_RetIvaPorImpr & _Str_ImpresionComprob.Trim().Length == 0 & !_Bol_VeriricarAnulacion)
            if (!_Bol_RetIslrPorImpr & !_Bol_RetIvaPorImpr & _Str_ImpresionComprob.Trim().Length == 0 & !_Bol_VeriricarAnulacion)
            {
                Frm_OrdenPago _Frm = new Frm_OrdenPago("1", _Str_ID_Factura_CxP_G, _Str_ComprobanteRetenExist, _Txt_NotaRecep.Text);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Dock = DockStyle.Fill;
                _Frm.Show();
                this.FormClosing -= new FormClosingEventHandler(Frm_RelPagProv_FormClosing);
                this.Close();
            }
            else
            {
                //if (_Ds.Tables[0].Rows.Count == 0)
                //{ MessageBox.Show("Usted no tiene permisos ó el monto a enviar a 'Orden de Pago' está fuera de sus límites", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                if (_Bol_VeriricarAnulacion)
                { MessageBox.Show("La factura ha sido anulada o esta en proceso de anulación. No se puede realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else if (_Bol_RetIslrPorImpr)
                { MessageBox.Show("La " + _Txt_TipoDoc.Text.Trim() + " Nº " + _Txt_Documento.Text + " tiene 'Retenciones de ISLR' por imprimir.", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (_Bol_RetIvaPorImpr)
                { MessageBox.Show("La " + _Txt_TipoDoc.Text.Trim() + " Nº " + _Txt_Documento.Text + " tiene 'Retenciones de IVA' por imprimir.", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (_Str_ImpresionComprob.Trim().Length > 0)
                { MessageBox.Show("Debe actualizar el comprobante " + _Mtd_RetornarID_Correl(_Str_ImpresionComprob) + " del documento seleccionado que se\nencuantra en el notificador 'Comprobantes por Actualizar'", "Requerimineto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            }
        }
        private bool _Mtd_RetencionNoIngresadaEnOrdenPago(string _P_Str_NumDoc, string _P_Str_TpoDoc, string _P_Str_ProvId)
        {
            string _P_Str_TipoDocIVA = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva").Trim();
            string _P_Str_TipoDocISLR = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr").Trim();
            if (_P_Str_TpoDoc == _P_Str_TipoDocIVA | _P_Str_TpoDoc == _P_Str_TipoDocISLR)
            {
                string _Str_Cadena = "select cidordpago from VST_PAGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_ProvId + "' and cnumdocu='" + _P_Str_NumDoc + "' and ctipodocument='" + _P_Str_TpoDoc + "' and canulado=0";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool _Mtd_RetencionEnReposicion(string _P_Str_NumDoc, string _P_Str_TpoDoc, string _P_Str_ProvId)
        {
            string _P_Str_TipoDocIVA = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva").Trim();
            string _P_Str_TipoDocISLR = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr").Trim();
            if (_P_Str_TpoDoc == _P_Str_TipoDocIVA | _P_Str_TpoDoc == _P_Str_TipoDocISLR)
            {
                string _Str_Cadena = "select cidreposiciones from TREPOSICIONESD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_ProvId + "' and cnumdocu='" + _P_Str_NumDoc + "' and ctipodocument='" + _P_Str_TpoDoc + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell.RowIndex != -1)
            {
                //if (!(_Cls_VariosMetodos._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ctipodocument"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value).Trim()) != 0) | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1") | !_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ORDEN_PAGO") | Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cordenpaghecha"].Value).Trim()=="1")
                if ((_Cls_VariosMetodos._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ctipodocument"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value).Trim()) == 0) | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1") | !_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ORDEN_PAGO") | !_Mtd_RetencionNoIngresadaEnOrdenPago(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ctipodocument"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value).Trim()))
                {
                    e.Cancel = true;
                    return;
                }
                if (_Mtd_RetencionEnReposicion(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ctipodocument"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value).Trim()))
                {
                    e.Cancel = true;
                    return;
                }
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor.Name == Color.Red.Name)
                { _CMen_OrdPago_Sel.Text = "Quitar selección"; _CMen_OrdPago_Generar.Enabled = true; }
                else
                { _CMen_OrdPago_Sel.Text = "Seleccionar"; _CMen_OrdPago_Generar.Enabled = false; }
            }
        }

        private void _CMen_OrdPago_Sel_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor.Name == Color.Red.Name)
            {
                _Mtd_SeleccionarRegistros(false, Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ctipodocument"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim(), Convert.ToDouble(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Saldo"].Value).Trim()), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidfactxp"].Value).Trim());
            }
            else
            {
                if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Saldo"].Value).Trim().Length > 0)
                {
                    _Mtd_SeleccionarRegistros(true, Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ctipodocument"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim(), Convert.ToDouble(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Saldo"].Value).Trim()), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidfactxp"].Value).Trim());
                }
            }
        }

        private void _CMen_OrdPago_Generar_Click(object sender, EventArgs e)
        {
            Frm_OrdenPago _Frm = new Frm_OrdenPago("1", _Dg_Grid.Rows);
            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
            this.FormClosing -= new FormClosingEventHandler(Frm_RelPagProv_FormClosing);
            this.Close();
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Grid.DataSource = null;
        }

        private void Frm_RelPagProv_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
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


        private void _Chk_AplicaInvend_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_CalularMontos();
        }

        private void _Chk_AplicaDescuentoFinanciero_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_CalularMontos();
        }

        private DataGridViewRow _Mtd_CrearNuevoRegistroDesdePlantilla(double _P_Monto)
        {
            //Agregar un cuenta desde la plantilla
            DataGridViewRow _Dgvr_Nueva = new DataGridViewRow();
            _Dgvr_Nueva.CreateCells(_Dg_Comprobante,
                                    "XXXX",
                                    _Dgvr_RegistroComprobante.Cells[1].Value,
                                    _Dgvr_RegistroComprobante.Cells[2].Value,
                                    _P_Monto.ToString("#,##0.00"),
                                    _Dgvr_RegistroComprobante.Cells[4].Value);

            _Dgvr_Nueva.Cells[0].ReadOnly = false;

            return _Dgvr_Nueva;
        }
        private bool _Mtd_EsValidoFilaComprobante(bool _P_ComprobarParaEliminar)
        {
            bool _Bool_FilaSePuedeEditarEliminar = true;
            //Obtengo el indice de la fila
            int _Int_IndiceFila = _Dg_Comprobante.CurrentCell.RowIndex;
            //Verifica si la celda es correcta
            if (_Int_IndiceFila > 0)
            {
                //Obtengo la cantidad de filas en el comprobante
                int _Int_CantidadDeRegistrosComprobanteAComparar = _Dg_Comprobante.Rows.Count;
                //Verifico si existen más filas
                if (_Int_CantidadDeRegistrosComprobanteAComparar > _Int_CantidadDeRegistrosComprobante)
                {
                    //Calculo la Diferencia
                    int _Int_Diferencia = _Int_CantidadDeRegistrosComprobanteAComparar - _Int_CantidadDeRegistrosComprobante;
                    //Verifico
                    if (_Int_IndiceFila > _Int_Diferencia)
                    {
                        _Bool_FilaSePuedeEditarEliminar = false;
                    }
                }
                else
                {
                    _Bool_FilaSePuedeEditarEliminar = false;
                }
            }
            else
            {
                //Si estamos eliminando
                if (_P_ComprobarParaEliminar)
                {
                    //Obtengo la cantidad de filas en el comprobante
                    int _Int_CantidadDeRegistrosComprobanteAComparar = _Dg_Comprobante.Rows.Count;
                    //Verifico si existen más filas
                    if (_Int_CantidadDeRegistrosComprobanteAComparar > _Int_CantidadDeRegistrosComprobante)
                    {
                        //Calculo la Diferencia
                        int _Int_Diferencia = _Int_CantidadDeRegistrosComprobanteAComparar - _Int_CantidadDeRegistrosComprobante;
                        //Verifico
                        if (_Int_IndiceFila > _Int_Diferencia)
                        {
                            _Bool_FilaSePuedeEditarEliminar = false;
                        }
                        else if (_Int_IndiceFila == 0) //No se permite eliminar la primera fila
                        {
                            _Bool_FilaSePuedeEditarEliminar = false;
                        }
                    }
                    else
                    {
                        _Bool_FilaSePuedeEditarEliminar = false;
                    }
                }
            }
            return _Bool_FilaSePuedeEditarEliminar;
        }

        private double _Mtd_ObtenerMontosRegistrosNuevosComprobante()
        {
            double _Dbl_MontoAcumulado = 0;
            //Obtengo la cantidad de filas en el comprobante
            int _Int_CantidadDeRegistrosComprobanteAComparar = _Dg_Comprobante.Rows.Count;
            //Verifico si existen más filas
            if (_Int_CantidadDeRegistrosComprobanteAComparar > _Int_CantidadDeRegistrosComprobante)
            {
                //Calculo la Diferencia
                int _Int_Diferencia = _Int_CantidadDeRegistrosComprobanteAComparar - _Int_CantidadDeRegistrosComprobante;
                //Acumulo
                for (int _Fila = 0; _Fila <= _Int_Diferencia; _Fila++)
                {
                    _Dbl_MontoAcumulado = _Dbl_MontoAcumulado + Convert.ToDouble(_Dg_Comprobante.Rows[_Fila].Cells[3].Value);
                }
            }
            else
            {
                _Dbl_MontoAcumulado = _Dbl_MontoAcumulado + Convert.ToDouble(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value);
            }
            return _Dbl_MontoAcumulado;
        }
        private void _CMen_Comprobante_Agregar_Click(object sender, EventArgs e)
        {
            if (_Bool_ModoConsulta)
            {
                return;
            }
            if (_Rb_Fact.Checked == false)
            {
                MessageBox.Show("Esto solo se permite en facturas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Obtengo el Monto del primer registro
            double _Dbl_Monto = Convert.ToDouble(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value);
            //Verifico si el monto de la primera fila es el monto original
            if (_Dbl_Monto == _Dbl_MontoExcentoOriginal)
            {
                MessageBox.Show("Debe editar primero el monto de la primera cuenta para poder agregar otro detalle.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Calculo los montos de las cuentas agregardas mas la original
            double _Dbl_MontoAcumulado = _Mtd_ObtenerMontosRegistrosNuevosComprobante();
            //Calculo la Diferencia
            double _Dbl_Diferencia = _Dbl_MontoExcentoOriginal - _Dbl_MontoAcumulado;
            //Agregar un cuenta desde la plantilla
            _Dg_Comprobante.Rows.Insert(1, _Mtd_CrearNuevoRegistroDesdePlantilla(_Dbl_Diferencia));
            //Actualizo los totales
            _Mtd_ActualizarMontosComprobante();
        }
        private void _Mtd_ActualizarMontosComprobante()
        {
            int _Int_IndiceFilatotales = _Dg_Comprobante.Rows.Count - 1;
            //Total Debe
            _Dg_Comprobante.Rows[_Int_IndiceFilatotales].Cells[3].Value = _Mtd_TotalDebeHaber(3);
            //Total Haber
            _Dg_Comprobante.Rows[_Int_IndiceFilatotales].Cells[4].Value = _Mtd_TotalDebeHaber(4);
        }
        private void _CMen_Comprobante_Editar_Click(object sender, EventArgs e)
        {
            if (_Bool_ModoConsulta)
            {
                return;
            }
            if (_Rb_Fact.Checked == false)
            {
                MessageBox.Show("Esto solo se permite en facturas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //bool _Bool_FilaSePuedeEditar = _Mtd_EsValidoFilaComprobante(false);
            ////Si la fila no se puede editar
            //if (!_Bool_FilaSePuedeEditar)
            //{
            //    MessageBox.Show("Solo puede editar registros que pertenecen a cuentas detalle.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //Obtengo el Monto del prime registro
            double _Dbl_Monto = Convert.ToDouble(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value);
            //Edita el Monto del registro
            _Tb_Tab.Enabled = false;
            _Pnl_EditarMontoCuentaComprobante.Visible = true;
            _Txt_MontoCuentaComprobante.Text = _Dbl_Monto.ToString();
            _Txt_MontoCuentaComprobante.Enabled = true;
            _Txt_MontoCuentaComprobante.ReadOnly = false;
            _Txt_MontoCuentaComprobante.SelectAll();
            _Txt_MontoCuentaComprobante.Focus();
        }

        private void _CMen_Comprobante_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Bool_ModoConsulta)
            {
                return;
            }
            if (_Rb_Fact.Checked == false)
            {
                MessageBox.Show("Esto solo se permite en facturas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool _Bool_FilaSePuedeEliminar = _Mtd_EsValidoFilaComprobante(true);
            //Si la fila no se puede eliminar
            if (!_Bool_FilaSePuedeEliminar)
            {
                MessageBox.Show("Este registro no se permite eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Elimino la Fila Seleccionada
            _Dg_Comprobante.Rows.Remove(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex]);
            //Actualizo los totales
            _Mtd_ActualizarMontosComprobante();
        }

        private void _Bt_CerrarEditarMontoCuentaComprobante_Click(object sender, EventArgs e)
        {
            _Tb_Tab.Enabled = true;
            _Pnl_EditarMontoCuentaComprobante.Visible = false;
        }

        private void _Bt_GuardarMontoCuentaComprobante_Click(object sender, EventArgs e)
        {
            //Valido el monto
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_MontoCuentaComprobante.Text))
            {
                MessageBox.Show("Debe introducir un monto válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Valido que no sea mayor que el original
            double _DblMonto = Convert.ToDouble(_Txt_MontoCuentaComprobante.Text);
            if (_DblMonto > _Dbl_MontoExcentoOriginal)
            {
                MessageBox.Show("El monto no puede ser mayor a " + _Dbl_MontoExcentoOriginal.ToString("#,##0.00") + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Edito
            int _Int_IndiceFila = _Dg_Comprobante.CurrentCell.RowIndex;
            _Dg_Comprobante.Rows[_Int_IndiceFila].Cells[3].Value = _DblMonto.ToString("#,##0.00");
            _Tb_Tab.Enabled = true;
            _Pnl_EditarMontoCuentaComprobante.Visible = false;
            //Actualizo los totales
            _Mtd_ActualizarMontosComprobante();
        }

        private void _Txt_MontoCuentaComprobante_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_MontoCuentaComprobante.Text)) { _Txt_MontoCuentaComprobante.Text = ""; }
        }

        private void _Txt_MontoCuentaComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_MontoCuentaComprobante, e, 15, 2);
        }

        private void _Cntx_Comprobante_Opening(object sender, CancelEventArgs e)
        {
            if (_Bool_ModoConsulta)
                e.Cancel = true;
            else if (_Rb_Fact.Checked == false)
                e.Cancel = true;
            else
            {
                if (_Dg_Comprobante.Rows.Count > 0)
                {
                    //Verifico si la celda es de solo lectura
                    if (_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[0].ReadOnly)
                    {
                        e.Cancel = true;
                    }
                    //else
                    //{
                    //    bool _Bool_FilaSePuedeEditarEliminar = _Mtd_EsValidoFilaComprobante(false);
                    //    //Si la fila no se puede editar ni eliminar
                    //    if (!_Bool_FilaSePuedeEditarEliminar)
                    //    {
                    //        e.Cancel = true;
                    //    }
                    //}
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }

        private void _Txt_DocAfect_Leave(object sender, EventArgs e)
        {
            //Si la factura tiene descuento financiero
            var _Dbl_PorcentajeDescuentoFinanciero = _Cls_VariosMetodos._Mtd_MontoPorcentajeDescuentoFinanciero(Frm_Padre._Str_GroupComp, _Str_Proveedor, _Txt_DocAfect.Text);
            if (_Dbl_PorcentajeDescuentoFinanciero == 0)
            {
                _Chk_AplicaDescuentoFinanciero.Checked = false;
                _Chk_AplicaDescuentoFinanciero.Enabled = false;
            }
            else
            {
                _Chk_AplicaDescuentoFinanciero.Checked = true;
                _Chk_AplicaDescuentoFinanciero.Enabled = true;
            }

        }

        private void _Cntx_Impuesto_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Impuestos.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void _Menu_Imp_Eliminar_Click(object sender, EventArgs e)
        {
            _Dg_Impuestos.SelectedRows.Cast<DataGridViewRow>().Where(x => x.Cells[0].Value != null).ToList().ForEach(x =>
            {
                _Dg_Impuestos.Rows.Remove(x);
            });
            _Mtd_CalcularTotalesImpuestos();
        }

        private void _Bt_BuscarComprob_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_VstCuentas _Frm = new Frm_VstCuentas();
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
            {
                if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                {
                    _Txt_CuentaComprob.Text = _Frm._Str_FrmNodeSelec.Trim();
                    _Txt_CuentaComprob.Tag = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim());
                }
                else
                { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        private void _Bt_CancelarComprob_Click(object sender, EventArgs e)
        {
            _Pnl_Comprob.Visible = false;
            _Txt_CuentaComprob.Tag = "";
            _Txt_CuentaComprob.Text = "";
            _Txt_MontoComprob.Text = "";
        }

        private void _Pnl_Comprob_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Comprob.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Bt_BuscarComprob.Focus();
            }
        }

        private void _Txt_MontoComprob_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_MontoComprob, e, 15, 2);
        }

        private void _Txt_MontoComprob_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_MontoComprob.Text)) { _Txt_MontoComprob.Text = ""; }
        }

        private void _Bt_AceptarComprob_Click(object sender, EventArgs e)
        {
            if (_Bol_EditarComprob)
            { _Mtd_EditarCuentaEditable(_Txt_CuentaComprob.Text, Convert.ToString(_Txt_CuentaComprob.Tag), _Txt_MontoComprob); }
            else
            { _Mtd_AgregarCuentaEditable(_Txt_CuentaComprob.Text, Convert.ToString(_Txt_CuentaComprob.Tag), _Txt_MontoComprob); }
        }

        private void _Cntx_Comprob_Opening(object sender, CancelEventArgs e)
        {
            if (!_Bool_ModoConsulta && _Dg_Comprobante.SelectedRows.Count == 1 && _Dg_Comprobante.CurrentCell.RowIndex != null && _Dg_Comprobante.CurrentCell.RowIndex >= 0)
            {
                if (_Mtd_EsCuentaEditable(Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[0].Value).Trim()))
                {
                    _CMen_Comprob_Editar.Enabled = true;
                    _CMen_Comprob_Eliminar.Enabled = true;
                }
                else
                {
                    _CMen_Comprob_Editar.Enabled = false;
                    _CMen_Comprob_Eliminar.Enabled = false;
                }
            }
            else
            { e.Cancel = true; }
        }
        bool _Bol_EditarComprob = false;
        private void _CMen_Comprob_Agregar_Click(object sender, EventArgs e)
        {
            _Bol_EditarComprob = false;
            _Pnl_Comprob.Visible = true;
        }

        private void _CMen_Comprob_Editar_Click(object sender, EventArgs e)
        {
            _Bol_EditarComprob = true;
            _Txt_CuentaComprob.Text = Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[0].Value).Trim();
            _Txt_CuentaComprob.Tag = Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[2].Value).Trim();
            double _Dbl_Monto = 0;
            if (double.TryParse(Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[3].Value).Trim(), out _Dbl_Monto))
            {
                _Txt_MontoComprob.Text = _Dbl_Monto.ToString();
            }
            else
            {
                _Txt_MontoComprob.Text = Convert.ToDouble(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells[4].Value).ToString();
            }
            _Pnl_Comprob.Visible = true;
        }

        private void _CMen_Comprob_Eliminar_Click(object sender, EventArgs e)
        {
            _Mtd_EliminarCuentaEditable(_Dg_Comprobante.CurrentCell.RowIndex);
        }

        private void _Chk_IvaCredNoCom_CheckedChanged(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Clear();
        }
    }
    public class _Cls_Impuesto
    {
        public string Alicuota { get; set; }
        public double Impuesto { get; set; }
    }
}
