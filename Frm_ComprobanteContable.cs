using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace T3
{
    public partial class Frm_ComprobanteContable : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        DataGridViewCell _Dg_Cel;
        int _Int_ComprExistente = 0;
        bool _Bol_ComprobanteImportado = false;
        public Frm_ComprobanteContable()
        {
            InitializeComponent();
        }
        public Frm_ComprobanteContable(int _P_Int_Comprobante)
        {
            InitializeComponent();
            _Int_ComprExistente = _P_Int_Comprobante;
            _Mtd_CargarTipo(true);
            _Mtd_CargarComboGrid((DataGridViewComboBoxColumn)_Dg_Grid.Columns["Tipo"]);
            _Mtd_CargarFormulario(_P_Int_Comprobante);
            _Dg_Grid.ReadOnly = false; _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true;
            _Txt_Numero.Enabled = true;
            _Txt_Descripcion.Enabled = true;
            _Cmb_Tipo.Enabled = false;
            _Bt_FechaCont.Enabled = false;
            _Bol_ComprobanteImportado = _Mtd_ComprobanteImportado(_P_Int_Comprobante.ToString());
            if (_Bol_ComprobanteImportado)
            { _Dg_Grid.Columns["Cuenta"].ReadOnly = true; _Dg_Grid.Columns["Debe"].ReadOnly = true; _Dg_Grid.Columns["Haber"].ReadOnly = true; }
            else
            { _Dg_Grid.Rows.Add(); }
            if (_Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC"))
            {
                _Bt_Aprobar.Visible = true;
                _Bt_Rechazar.Visible = true;
                _Bt_Aprobar.Focus();
            }
        }
        private bool _Mtd_ComprobanteImportado(string _P_Str_Comprobante)
        {
            string _Str_CompSpi = _Mtd_CompSpi();
            string _Str_Cadena = "SELECT cidcomprob FROM TCALINCIMPORTSPI WHERE ccompanyspi='" + _Str_CompSpi + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_CargarFormulario(int _P_Int_Comprobante)
        {
            string _Str_Cadena = "SELECT ctypcomp,cname,cyearacco,cmontacco,convert(varchar, cregdate,103) as cregdate,ctotdebe,ctothaber,cbalance,cidcorrel FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Numero.Text = _Ds.Tables[0].Rows[0]["ctypcomp"].ToString() + "-" + _Ds.Tables[0].Rows[0]["cmontacco"].ToString() + "-" + _Ds.Tables[0].Rows[0]["cyearacco"].ToString() + "-" + _Ds.Tables[0].Rows[0]["cidcorrel"].ToString();
                _Txt_Descripcion.Text = _Ds.Tables[0].Rows[0]["cname"].ToString();
                _Txt_Fecha.Text = _Ds.Tables[0].Rows[0]["cregdate"].ToString();
                _Str_AnoCont = _Ds.Tables[0].Rows[0]["cyearacco"].ToString();
                _Str_MesCont = _Ds.Tables[0].Rows[0]["cmontacco"].ToString();
                _Txt_MesAno.Text = _Ds.Tables[0].Rows[0]["cmontacco"].ToString() + "-" + _Ds.Tables[0].Rows[0]["cyearacco"].ToString();
                _Cmb_Tipo.SelectedValue = _Ds.Tables[0].Rows[0]["ctypcomp"].ToString();
                if (_Ds.Tables[0].Rows[0]["ctotdebe"] != System.DBNull.Value)
                { _Txt_Debe.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotdebe"]).ToString("#,##0.00"); }
                if (_Ds.Tables[0].Rows[0]["ctothaber"] != System.DBNull.Value)
                { _Txt_Haber.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctothaber"]).ToString("#,##0.00"); }
                if (_Ds.Tables[0].Rows[0]["cbalance"] != System.DBNull.Value)
                { _Txt_Saldo.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbalance"]).ToString("#,##0.00"); }
                _Str_Cadena = "SELECT TCOMPROBAND.ccount, TCOMPROBAND.cdescrip, TCOMPROBAND.ctdocument, TCOMPROBAND.cnumdocu, TCOMPROBAND.ctotdebe, TCOMPROBAND.ctothaber, TCOMPROBANDD.cidauxiliarcont FROM TCOMPROBAND LEFT OUTER JOIN TCOMPROBANDD ON TCOMPROBAND.corder = TCOMPROBANDD.corder AND TCOMPROBAND.cidcomprob = TCOMPROBANDD.cidcomprob AND TCOMPROBAND.ccompany = TCOMPROBANDD.ccompany AND TCOMPROBAND.ccount = TCOMPROBANDD.ccount AND TCOMPROBANDD.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANDD.cidcomprob='" + _P_Int_Comprobante + "' WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Int_Comprobante + "' ORDER BY TCOMPROBAND.corder";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_DebeD = "";
                string _Str_HaberD = "";
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_DebeD = ""; if (_Row["ctotdebe"] != System.DBNull.Value) { if (Convert.ToDouble(_Row["ctotdebe"]) > 0) { _Str_DebeD = _Row["ctotdebe"].ToString(); } }
                    _Str_HaberD = ""; if (_Row["ctothaber"] != System.DBNull.Value) { if (Convert.ToDouble(_Row["ctothaber"]) > 0) { _Str_HaberD = _Row["ctothaber"].ToString(); } }
                    _Dg_Grid.Rows.Add(new object[] { _Row["ccount"], ' ', _Row["cdescrip"], _Row["cidauxiliarcont"], ' ', _Row["ctdocument"], _Row["cnumdocu"], _Str_DebeD, _Str_HaberD });
                }
            }

        }
        private void _Mtd_CargarTipo(bool _P_Bol_Constructor)
        {
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_Tipo, "Select ctypcompro,cname from TTCOMPROBAN" + (_P_Bol_Constructor ? "" : " WHERE ctypcompro<>'01'"));
        }
        private void _Mtd_CargarComboGrid(DataGridViewComboBoxColumn _P_Cmd_ComboboxColumn)
        {   
            string _Str_Cadena = "Select ctdocument,cname from TDOCUMENT";
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmd_ComboboxColumn.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _P_Cmd_ComboboxColumn.DataSource = _myArrayList;
            _P_Cmd_ComboboxColumn.DisplayMember = "Display";
            _P_Cmd_ComboboxColumn.ValueMember = "Value";
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
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private bool _Mtd_Auxiliar(string _P_Str_Cuenta)
        {
            //Cuando este lista la interface de Empleados y los Bancos ir modificando el filtro de cclasificauxiliar
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "SELECT ccount FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _P_Str_Cuenta + "' AND cauxiliary='1' AND (cclasificauxiliar='1' OR cclasificauxiliar='2' OR cclasificauxiliar='3' OR cclasificauxiliar='4' OR (cclasificauxiliar='5' AND (SELECT TOP 1 COUNT(cid_spi) FROM TEMPLEADOS_SPI WHERE ccompany=TCOUNT.ccompany)>0))";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private bool _Mtd_MarcarAuxiliar(int _P_Int_RowIndex)
        {
            if (_Mtd_Auxiliar(_Mtd_Cuenta(_P_Int_RowIndex)))
            {
                if (Convert.ToString(_Dg_Grid.Rows[_P_Int_RowIndex].Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Grid.Rows[_P_Int_RowIndex].Cells["cidauxiliarcont"].Value).Trim() == "0") { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Tipo"].Value == null) { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Tipo"].Value.ToString().Trim() == "nulo") { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Documento"].Value == null) { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Documento"].Value.ToString().Trim().Length == 0) { return true; }
            }
            return false;
        }
        private void _Mtd_Ini()
        {
            _Mtd_CargarTipo(false);
            _Mtd_CargarComboGrid((DataGridViewComboBoxColumn)_Dg_Grid.Columns["Tipo"]);
            _Cmb_Tipo.Enabled = true;
            _Bt_FechaCont.Enabled = true;
            _Txt_Descripcion.Enabled = true;
            _Txt_Descripcion.Text = "";
            _Txt_Numero.Enabled = true;
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.Rows.Add();
            _Dg_Grid.Columns["Cuenta"].ReadOnly = false; _Dg_Grid.Columns["Debe"].ReadOnly = false; _Dg_Grid.Columns["Haber"].ReadOnly = false;
            _Dg_Grid.ReadOnly = true;
            _Txt_Numero.Text = "";
            _Txt_Debe.Text = "0";
            _Txt_Haber.Text = "0";
            _Txt_Saldo.Text = "0";
            _Bt_Importar.Enabled = _Cls_Variosmetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_COMPROBC") & _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IMPORTAR_SPI");
            _Str_Temp_Cuenta = "";
            _Str_Temp_Descripcion = "";
            _Str_Temp_Auxiliar = "";
            _Str_Temp_Tipo = "";
            _Str_Temp_Documento = "";
        }
        public void _Mtd_Nuevo()
        {
            if (!((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled ||
                (((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled && MessageBox.Show("Se perderán los datos. ¿Esta seguro de continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes))
            {
                _Mtd_Ini();
                _Bol_ComprobanteImportado = false;
                _Int_ComprExistente = 0;
                _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(_Mtd_UltimaFechaPorMes(_Str_AnoCont, _Str_MesCont));
                _Cmb_Tipo.Focus();
            }
        }
        private void _Mtd_DeshabilitarTodo()
        {
            _Mtd_CargarTipo(false);
            _Cmb_Tipo.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Txt_Descripcion.Text = "";
            _Txt_Numero.Enabled = false;
            _Dg_Grid.Rows.Clear();
            _Txt_Numero.Text = "";
            _Txt_Debe.Text = "0";
            _Txt_Haber.Text = "0";
            _Txt_Saldo.Text = "0";
            _Txt_Fecha.Text = "";
        }
        private string _Mtd_DescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();                
            }
            return "";
        }
        private bool _Mtd_VerificarDocExistente(DataGridViewRow _Dg_Row)
        {
            string _Str_TipoDocFACT_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocfact");
            string _Str_TipoDocNC_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocnotcred");
            string _Str_TipoDocND_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocnotdeb");
            //-------------------------
            string _Str_TipoDocFACT_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
            string _Str_TipoDocNC_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnc");
            string _Str_TipoDocND_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnd");
            string _Str_TipoDocRETIVA = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva");
            string _Str_TipoDocRETISLR = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr");
            //-------------------------
            DataSet _Ds;
            string _Str_Cadena = "";
            bool _Bol_Return = true;
            bool _Bol_ColorKhaki = false;
            if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Row.Index)))
            {
                _Str_Cadena = "SELECT cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Mtd_Cuenta(_Dg_Row.Index) + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocFACT_CxC.ToUpper())
                    {
                        if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
                        {
                            _Str_Cadena = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                            { _Bol_ColorKhaki = true; }
                        }
                        else
                        { _Bol_ColorKhaki = true; }
                    }
                    else if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocNC_CxC.ToUpper())
                    {
                        if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
                        {
                            _Str_Cadena = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cidnotcredicc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                            { _Bol_ColorKhaki = true; }
                        }
                        else
                        { _Bol_ColorKhaki = true; }
                    }
                    else if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocND_CxC.ToUpper())
                    {
                        if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
                        {
                            _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cidnotadebitocc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                            { _Bol_ColorKhaki = true; }
                        }
                        else
                        { _Bol_ColorKhaki = true; }
                    }
                    //-------------
                    if (_Bol_ColorKhaki)
                    {
                        _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='0' AND centidad='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { _Bol_ColorKhaki = false; }
                    }
                    //-------------
                }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "2" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "3" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "4")
                {
                    _Str_Cadena = "SELECT cnumdocu FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                    { _Bol_ColorKhaki = true; }
                    //-------------
                    if (_Bol_ColorKhaki)
                    {
                        _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='1' AND centidad='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { _Bol_ColorKhaki = false; }
                    }
                    //-------------
                }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "5")
                {
                    _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='2' AND centidad='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                    { _Bol_ColorKhaki = true; }
                }
                //-----------------
                if (_Bol_ColorKhaki) { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                else { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
                //-----------------
                if (_Bol_ColorKhaki) { _Bol_Return = false; }
            }
            return _Bol_Return;
        }
        private bool _Mtd_VerificarDocExistentes()
        {
            bool _Bol_Return = true;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (!_Mtd_VerificarDocExistente(_Dg_Row))
                { _Bol_Return = false; }
            }
            _Lbl_DgInformacion.Visible = !_Bol_Return;
            return _Bol_Return;
        }

        private bool _Mtd_VerificarIdAuxTipDocNumDocNull()
        {
            bool _Bol_Return = false;
            bool _Bol_ColorKhaki = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Bol_ColorKhaki = false;
                if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Row.Index)))
                {
                    if (Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() == "0") { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Tipo"].Value == null) { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Tipo"].Value.ToString().Trim() == "nulo") { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Documento"].Value == null) { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Documento"].Value.ToString().Trim().Length == 0) { _Bol_ColorKhaki = true; }
                    //-----------------
                    if (_Bol_ColorKhaki) { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                    else { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
                    //-----------------
                    if (_Bol_ColorKhaki) { _Bol_Return = true; }
                }
            }
            return _Bol_Return;
        }

        private bool _Mtd_ExistenCuentasBancarias()
        {
            bool _Bol_Return = false;
            bool _Bol_TipoAjusteContable = Convert.ToString(_Cmb_Tipo.SelectedValue) == "06";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Bol_TipoAjusteContable && _Mtd_EsCuentaBancaria(_Mtd_Cuenta(_Dg_Row.Index)))
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                    _Bol_Return = true;
                }
                else
                    _Dg_Row.DefaultCellStyle.BackColor = Color.White;
            }
            return _Bol_Return;
        }

        public bool _Mtd_Guardar()
        {
            _Dg_Grid.EndEdit();
            int _Int_Comprobante = 0;
            if (_Txt_Debe.Text.Trim().Length == 0)
            { _Txt_Debe.Text = "0"; }
            if (_Txt_Haber.Text.Trim().Length == 0)
            { _Txt_Haber.Text = "0"; }
            if (_Txt_Saldo.Text.Trim().Length == 0)
            { _Txt_Saldo.Text = "0"; }
            bool _Bol_VerificarIdAuxTipDocNumDocNull = _Mtd_VerificarIdAuxTipDocNumDocNull();
            if ((!_Bol_ComprobanteImportado & _Mtd_VerificarFormulario() & !_Bol_VerificarIdAuxTipDocNumDocNull) | (_Bol_ComprobanteImportado & !_Bol_VerificarIdAuxTipDocNumDocNull))
            {
                if (_Mtd_VerificarDocExistentes())
                {
                    if (_Mtd_ExistenCuentasBancarias())
                    {
                        MessageBox.Show("Los registros marcados no son válidos. Los ajustes contables (06) no deben tocar cuentas contables de las cuentas bancarias.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    _Mtd_CalcularTotales();
                    if (_Mtd_CuentasSinMonto(true)) return false;
                    if (Convert.ToDouble(_Txt_Debe.Text) > 0 & Convert.ToDouble(_Txt_Haber.Text) > 0 & Convert.ToDouble(_Txt_Saldo.Text) == 0)
                    {
                        if (!_Bt_Aprobar.Visible)
                        {
                            _Int_Comprobante = _Mtd_ActualizarComprobante(true, 1, false);
                            if (_Bol_Mensaje)//Es para saber si se muestra el mensaje
                            { MessageBox.Show("La operación ha sido realizadad correctamente. Comprobante: " + _Mtd_RetornarID_Correl(_Int_Comprobante.ToString()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            if (_Int_ComprExistente != 0)//Para saber si se abrio desde el tabs
                            { this.Close(); }
                            else
                            { _Mtd_DeshabilitarTodo(); }
                        }
                        else
                        {
                            _Int_Comprobante = _Mtd_ActualizarComprobante(true, 2, false);
                            if (_Bol_Mensaje)
                            { MessageBox.Show("La operación ha sido realizadad correctamente. Comprobante: " + _Mtd_RetornarID_Correl(_Int_Comprobante.ToString()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("El comprobante esta descuadrado o faltan montos por ingresar. ¿Esta seguro de guardarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (!_Bt_Aprobar.Visible)
                            {
                                _Int_Comprobante = _Mtd_ActualizarComprobante(false, 1, true);
                                if (_Bol_Mensaje)
                                { MessageBox.Show("La operación ha sido realizadad correctamente. Comprobante: " + _Mtd_RetornarID_Correl(_Int_Comprobante.ToString()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                if (_Int_ComprExistente != 0)//Para saber si se abrio desde el tabs
                                { this.Close(); }
                                else
                                { _Mtd_DeshabilitarTodo(); }
                            }
                            else
                            {
                                _Int_Comprobante = _Mtd_ActualizarComprobante(false, 2, false);
                                if (_Bol_Mensaje)
                                { MessageBox.Show("La operación ha sido realizadad correctamente. Comprobante: " + _Mtd_RetornarID_Correl(_Int_Comprobante.ToString()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                        }
                        else
                        {
                            _Bol_Mensaje2 = false;
                            return false;
                        }
                    }
                }
                else
                { MessageBox.Show("Los documentos marcados no existen en la base de datos del sistema. Verifique que la\ninformación en auxiliar, tipo de documento y documento sea correcta para cada\nregistro marcado.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }
            }
            else
            {
                if (_Bol_VerificarIdAuxTipDocNumDocNull)
                { MessageBox.Show("Verifique que en los registros marcados esten identificados el auxiliar, tipo de documento y documento", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (!_Bol_ComprobanteImportado)
                {
                    _Mtd_ValidarFila();
                    _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Selected = true;
                }
                return false;
            }
            if (!_Bt_Aprobar.Visible)
            { return true; }
            else
            { return false; }
        }
        private string _Mtd_CompSpi()
        {
            string _Str_Cadena = "SELECT ccodspi FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        public string _Mtd_Id_CapturaSpi()
        {
            string _Str_Cadena = "SELECT ISNULL(MAX(cidcapturaspi),0)+1 FROM TCALINCIMPORTSPI WHERE ccompanyspi='" + _Mtd_CompSpi() + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        public string _Mtd_Id_CapturaSpiDet(string _P_Str_CompSpi, string _P_Str_Id_CapturaSpi)
        {
            string _Str_Cadena = "SELECT ISNULL(MAX(ciddetalle),0)+1 FROM TCALINCIMPORTSPI WHERE ccompanyspi='" + _P_Str_CompSpi + "' AND cidcapturaspi='" + _P_Str_Id_CapturaSpi + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        public int _Mtd_ActualizarComprobante(bool _P_Bol_Cuadrado, int _P_Int_Firma, bool _P_Bol_SinMonto)
        {
            int _Int_Comprobante = 0;
            bool _Bol_Existe = false;
            string _Str_Cadena = "";
            if (_Int_ComprExistente != 0)
            { _Int_Comprobante = _Int_ComprExistente; }
            else
            { _Int_Comprobante = _Cls_Variosmetodos._Mtd_Consecutivo_TCOMPROBANC(); }
            if (_Int_ComprExistente != 0)//Si es diferente de '0' significa que ya existe
            {
                _Bol_Existe = true;
                _Str_Cadena = "DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if (_P_Bol_Cuadrado & _P_Int_Firma == 2)//Aqui entra solo una condicion
                { _Str_Cadena = "UPDATE TCOMPROBANC SET ctypcomp='" + _Cmb_Tipo.SelectedValue + "',cname='" + _Txt_Descripcion.Text.ToUpper().Trim() + "',cyearacco='" + _Str_AnoCont + "',cmontacco='" + _Str_MesCont + "',cregdate='" + _Cls_Formato._Mtd_fecha(_Mtd_UltimaFechaPorMes(_Str_AnoCont, _Str_MesCont)) + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Debe.Text)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Haber.Text)) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Saldo.Text)) + "',cstatus='0',cestatusfirma='" + _P_Int_Firma + "',csistema='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'"; }
                else//Aqui entran las tres condiciones restantes
                {
                    if (_P_Bol_SinMonto) { _P_Int_Firma = 4; }
                    _Str_Cadena = "UPDATE TCOMPROBANC SET ctypcomp='" + _Cmb_Tipo.SelectedValue + "',cname='" + _Txt_Descripcion.Text.ToUpper().Trim() + "',cyearacco='" + _Str_AnoCont + "',cmontacco='" + _Str_MesCont + "',cregdate='" + _Cls_Formato._Mtd_fecha(_Mtd_UltimaFechaPorMes(_Str_AnoCont, _Str_MesCont)) + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Debe.Text)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Haber.Text)) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Saldo.Text)) + "',cstatus='0',cestatusfirma='" + _P_Int_Firma + "',csistema='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                }
            }
            else
            {
                if (_P_Bol_Cuadrado & _P_Int_Firma == 2)//Aqui entra solo una condicion
                { _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cstatus,cestatusfirma,csistema,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Cmb_Tipo.SelectedValue + "','" + _Txt_Descripcion.Text.ToUpper().Trim() + "','" + _Str_AnoCont + "','" + _Str_MesCont + "','" + _Cls_Formato._Mtd_fecha(_Mtd_UltimaFechaPorMes(_Str_AnoCont, _Str_MesCont)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Debe.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Haber.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Saldo.Text)) + "','0','" + _P_Int_Firma + "','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')"; }
                else//Aqui entran las tres condiciones restantes
                {
                    if (_P_Bol_SinMonto) { _P_Int_Firma = 4; }
                    _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cstatus,cestatusfirma,csistema,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Cmb_Tipo.SelectedValue + "','" + _Txt_Descripcion.Text.ToUpper().Trim() + "','" + _Str_AnoCont + "','" + _Str_MesCont + "','" + _Cls_Formato._Mtd_fecha(_Mtd_UltimaFechaPorMes(_Str_AnoCont, _Str_MesCont)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Debe.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Haber.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Saldo.Text)) + "','0','" + _P_Int_Firma + "','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')"; 
                }
            }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Cmb_Tipo.Enabled = false;
            _Bt_FechaCont.Enabled = false;
            string _Str_Tipo = "";
            string _Str_Documento = "";
            string _Str_ID_Auxiliar = "";
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                    {
                        _Dg_Row.Cells["Descripcion"].Value = Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Replace("'", "").Replace("*", "").Replace("=", "").Replace("%", "");
                        //------------------------------------------------------------------------
                        if (_Dg_Row.Cells["Tipo"].Value == null) { _Str_Tipo = "0"; }
                        else if (_Dg_Row.Cells["Tipo"].Value.ToString().Trim() == "nulo") { _Str_Tipo = "0"; }
                        else { _Str_Tipo = _Dg_Row.Cells["Tipo"].Value.ToString().Trim(); }
                        //-----------
                        if (_Dg_Row.Cells["Documento"].Value == null) { _Str_Documento = "0"; }
                        else if (_Dg_Row.Cells["Documento"].Value.ToString().Trim() == "nulo") { _Str_Documento = "0"; }
                        else { _Str_Documento = _Dg_Row.Cells["Documento"].Value.ToString().Trim(); }
                        //------------------------------------------------------------------------
                        _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //------------------------------------------------------------------------
                        _Str_ID_Auxiliar = ""; 
                        if (Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim().Length > 0)
                        { _Str_ID_Auxiliar = Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim(); }
                        //------------------------------------------------------------------------
                        try
                        {
                            if (_Bol_Existe)//Para determinar si se coloca cdateadd ó cuseradd
                            { _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,ctotdebe,ctothaber,cdateupd,cuserupd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToUpper() + "','" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')"; }
                            else
                            { _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,ctotdebe,ctothaber,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToUpper() + "','" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')"; }
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            if (Convert.ToDouble(_Ob_DebeD) > 0)
                            { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim(), _Str_ID_Auxiliar, Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToString().ToUpper(), Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)), _Str_MesCont, _Str_AnoCont, "D", Convert.ToString(_Dg_Row.Index + 1)); }
                            else if (Convert.ToDouble(_Ob_HaberD) > 0)
                            { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim(), _Str_ID_Auxiliar, Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToString().ToUpper(), Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)), _Str_MesCont, _Str_AnoCont, "H", Convert.ToString(_Dg_Row.Index + 1)); }
                        }
                        catch (Exception _ex)
                        { MessageBox.Show(_ex.Message); break; }
                    }
                }
            }
            if (_Bol_ComprobanteImportado & !_Bol_Existe)
            {
                string _Str_CompSpi = _Mtd_CompSpi();
                string _Str_Id_CapturaSpi = _Mtd_Id_CapturaSpi();
                string _Str_Id_CapturaSpiDet = "";
                foreach (DataRow _Row in _Ds_Import.Tables[0].Rows)
                {
                    _Str_Id_CapturaSpiDet = _Mtd_Id_CapturaSpiDet(_Str_CompSpi, _Str_Id_CapturaSpi);
                    _Str_Cadena = "INSERT INTO TCALINCIMPORTSPI (ccompanyspi,cidcapturaspi,ciddetalle,cfechacaptura,cidempleado,ccount,cdescrip,cregdate,cyearacco,cmontacco,cdebe,chaber,cidcomprob,cdateadd,cuseradd) VALUES ('" + _Str_CompSpi + "','" + _Str_Id_CapturaSpi + "','" + _Str_Id_CapturaSpiDet + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + _Row[1].ToString().Trim() + "','" + _Row[2].ToString().Trim() + "','" + _Row[3].ToString().Trim() + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row[4].ToString().Trim())) + "','" + _Row[5].ToString().Trim() + "','" + _Row[6].ToString().Trim() + "','" + _Row[7].ToString().Trim() + "','" + _Row[8].ToString().Trim() + "','" + _Int_Comprobante + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            return _Int_Comprobante;
        }
        string _Str_AnoCont = "";
        string _Str_MesCont = "";
        private void _Mtd_VerificarAnoyMesContable()
        {
            string _Str_Cadena = "SELECT cmontacco,cyearacco FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' AND cmontacco<'" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Pnl_MesAnoContable.Visible = true;
            }
            else
            {
                _Str_MesCont = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                _Str_AnoCont = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                _Txt_MesAno.Text = _Str_MesCont + "-" + _Str_AnoCont;
            }
        }
        private void _Mtd_CargarMesAno()
        {
            var _Str_Mes = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month;
            var _Str_Ano = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year;
            string _Str_Cadena = "SELECT cmontacco,CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) as Descripcion FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' AND CONVERT(DATETIME,'01-'+CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco))<=CONVERT(DATETIME,'01-'+CONVERT(VARCHAR,'" + _Str_Mes + "')+'-'+CONVERT(VARCHAR,'" + _Str_Ano + "'))";
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_MesAno, _Str_Cadena);
        }
        private string _Mtd_ExtraerAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return _P_Str_Items.Substring(_Int_i + 1).Trim();
        }
        private DateTime _Mtd_UltimaFechaPorMes(string _P_Str_Ano, string _P_Str_Mes)
        {
            if (new DateTime(Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))), Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))), 1) == new DateTime(Convert.ToInt32(_P_Str_Ano), Convert.ToInt32(_P_Str_Mes), 1))
            {
                return CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            }
            else if (new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month, 1) == new DateTime(Convert.ToInt32(_P_Str_Ano), Convert.ToInt32(_P_Str_Mes), 1))
            {
                return CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            }
            else
            {
                DateTime _Dtm_Temp = new DateTime(Convert.ToInt32(_P_Str_Ano), Convert.ToInt32(_P_Str_Mes), 1).AddMonths(1);
                return _Dtm_Temp.AddDays(-1);
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
                    _Tlt_Tips.Show(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), this, (_Dg_Grid.Location.X + (_Dg_Grid.Width / 2)) - (Convert.ToInt32(CreateGraphics().MeasureString(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _P_Fnt_Fuente).Width) / 2), _Pnl_Pie.Location.Y + 50, 360000);
                }
                else
                {
                    _Tlt_Tips.Hide(this);
                }
            }
            else
            { _Tlt_Tips.Hide(this); }
        }
        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns></returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and cactivate='1' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }
        private string _Mtd_RetornarID_Correl(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT CONVERT(VARCHAR,ISNULL(TCOMPROBANC.ctypcomp,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cmontacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cyearacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cidcorrel,0)) FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        private int _Mtd_TipoEntidad(DataGridViewRow _Dg_Row)
        {
            string _Str_Cadena = "SELECT cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Mtd_Cuenta(_Dg_Row.Index) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
            {
                return 0;
            }
            else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "2" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "3" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "4")
            {
                return 1;
            }
            else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "5")
            {
                return 2;
            }
            return -1;
        }
        
        //aqui
        public static string[] contiene = new string[] { "36", "1", "18", "19", "27", "34", "30" };
        public static DataSet dsn = CLASES._Cls_Varios_Metodos.dataset2;
        private void Frm_ComprobanteContable_Load(object sender, EventArgs e)
        {
            if (dsn.Tables.Count > 0)
            {
                _Bt_FechaCont.Enabled = false;
                _Bt_DocVarios.Enabled = false;
                _Bt_Importar.Enabled = false;
                button1.Enabled = true;
                button1.Visible = true;

                //if (contiene.Contains(Frm_Padre._Str_UserGroup.ToString()))
                //{MessageBox.Show("desde el otro formulario grupo");}
                //else{MessageBox.Show("desde el otro formulario");}

                    _Dg_Grid.AllowUserToAddRows = true; decimal debe = 0;decimal haber = 0;
                    _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_Tipo, "Select ctypcompro,cname from TTCOMPROBAN WHERE ctypcompro = '01'");
                    _Cmb_Tipo.SelectedIndex = 1; _Txt_Descripcion.Text = "REGISTRO DE NOMINA OBREROS SEM DEL " + Frm_ImportNomina.Datemin.ToShortDateString() + " - " + Frm_ImportNomina.Datemax.ToShortDateString();
                    _Txt_Descripcion.Enabled = true;
                
                foreach (DataRow _Row in dsn.Tables[0].Rows)
                {
                    _Dg_Grid.Rows.Add(new object[] { 
                        _Row["CUENTACONTABLE"].ToString(), ' ', 
                        _Row["DESCRIPCIONPROCESO"].ToString() + _Cls_Variosmetodos.cficha(_Row["FICHATRABAJADOR"].ToString()),
                        ' ', ' ', ' ', ' ',
                        Convert.ToDouble(Convert.ToDecimal(_Row["MONTODEBE"].ToString().Replace('.', ','))).ToString("#,##0.00"), 
                        Convert.ToDouble(Convert.ToDecimal(_Row["MONTOHABER"].ToString().Replace('.', ','))).ToString("#,##0.00") });
                    _Txt_Fecha.Text = _Row["FECHACONTABILIZACION"].ToString();
                    _Txt_MesAno.Text = _Row["MESCONTABLE"].ToString() + "-" + _Row["ANOCONTABILIZACION"].ToString();

                    debe += Convert.ToDecimal(_Row["MONTODEBE"].ToString().Replace('.', ',')); haber += Convert.ToDecimal(_Row["MONTOHABER"].ToString().Replace('.', ','));
                    _Txt_Debe.Text = debe.ToString(); _Txt_Haber.Text = haber.ToString(); _Txt_Saldo.Text = (debe - haber).ToString();
                }
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                this.Dock = DockStyle.Fill;
                _Pnl_MesAnoContable.BringToFront();
                _Pnl_Clave.BringToFront();
                _Pnl_MesAnoContable.Left = (this.Width / 2) - (_Pnl_MesAnoContable.Width / 2);
                _Pnl_MesAnoContable.Top = (this.Height / 2) - (_Pnl_MesAnoContable.Height / 2);
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                _Mtd_Color_Estandar(this);
                _Mtd_Sorted();
                if (_Txt_MesAno.Text.Trim().Length == 0)
                { _Mtd_VerificarAnoyMesContable(); }
                _Tlt_Tips.Hide(this);
                new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this, true);
            }
            //this.Dock = DockStyle.Fill;
            //_Pnl_MesAnoContable.BringToFront();
            //_Pnl_Clave.BringToFront();
            //_Pnl_MesAnoContable.Left = (this.Width / 2) - (_Pnl_MesAnoContable.Width / 2);
            //_Pnl_MesAnoContable.Top = (this.Height / 2) - (_Pnl_MesAnoContable.Height / 2);
            //_Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            //_Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            //_Mtd_Color_Estandar(this);
            //_Mtd_Sorted();
            //if (_Txt_MesAno.Text.Trim().Length == 0)
            //{ _Mtd_VerificarAnoyMesContable(); }
            //_Tlt_Tips.Hide(this);
            //new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this, true);
            
        }

        private void Frm_ComprobanteContable_Activated(object sender, EventArgs e)
        {
            _Mtd_Activated();
        }
        private void _Mtd_Activated()
        {
            if (_Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_COMPROBC") | _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC"))//Si el boton de Aprobar esta visible no se puede modificar la información
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                if (_Txt_Numero.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
                //El Primero es porque el usuario firmante F_N2_COMPROBC no debe cargar y el segundo es para cuando se invoque
                //el evento Activate no habilite el boton Nuevo si el panel esta visible
                if (_Bt_Aprobar.Visible | _Pnl_MesAnoContable.Visible)
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
        private void Frm_ComprobanteContable_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Cmb_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Tipo.SelectedIndex > 0 & _Txt_Descripcion.Text.Trim().Length > 0)
            { _Dg_Grid.ReadOnly = false; _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true; }
            else
            { _Dg_Grid.ReadOnly = true; }
        }

        private void _Txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Tipo.SelectedIndex > 0)
            { _Dg_Grid.ReadOnly = false; _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true; }
            else
            {
                _Dg_Grid.ReadOnly = true;
            }
        }

        private void _Cmb_Tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Cmb_Tipo.SelectedIndex > 0 & _Txt_Descripcion.Text.Trim().Length > 0)
                {
                    _Dg_Grid.Focus();
                    _Dg_Cel = _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["BotonCuenta"];
                    try
                    {
                        _Dg_Grid.CurrentCell = _Dg_Cel;
                    }
                    catch { }
                }
                else if (_Cmb_Tipo.SelectedIndex > 0 & _Txt_Descripcion.Text.Trim().Length == 0)
                { _Txt_Descripcion.Focus(); }
            }
        }

        private void _Txt_Descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Tipo.SelectedIndex > 0)
                {
                    _Dg_Grid.Focus();
                    _Dg_Cel = _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["BotonCuenta"];
                    try
                    {
                        _Dg_Grid.CurrentCell = _Dg_Cel;
                    }
                    catch { }
                }
                else if (_Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Tipo.SelectedIndex <= 0)
                { _Cmb_Tipo.Focus(); }
            }
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell.ColumnIndex == 0)
            {
                _Mtd_MostrarToolTipsCell(((TextBox)sender).Text, ((TextBox)sender).Font);
            }
            else if (_Dg_Grid.CurrentCell.ColumnIndex == 7 || _Dg_Grid.CurrentCell.ColumnIndex == 8)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(".", "");
                if (!_Cls_Variosmetodos._Mtd_IsNumeric(((TextBox)sender).Text))
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
            if (_Dg_Grid.CurrentCell.ColumnIndex == 7 | _Dg_Grid.CurrentCell.ColumnIndex == 8)
            {
                _Cls_Variosmetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2);
            }
        }
        /// <summary>
        /// Determina si el foco se debe mover al Debe
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_Debe()
        {
            if (_Dg_Grid.CurrentCell.RowIndex > 0)
            {
                object _Ob_DebeD = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex - 1].Cells["Debe"].Value;
                if (_Ob_DebeD == null)
                { _Ob_DebeD = 0; }
                else if (_Ob_DebeD.ToString().Trim().Length == 0)
                { _Ob_DebeD = 0; }
                //-----------
                if (Convert.ToDouble(_Ob_DebeD) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool _Mtd_VerificarFormulario()
        {
            bool _Bol_Cuenta = false;
            bool _Bol_FilaValidada = false;
            if (_Dg_Grid.RowCount > 0)
            {
                if (_Cmb_Tipo.SelectedIndex > 0 & _Txt_Descripcion.Text.Trim().Length > 0)
                {
                    //-----------------------------------------Esto es para que valide la ultima fila en _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))
                    _Dg_Cel = _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["BotonCuenta"];
                    try
                    {
                        _Dg_Grid.CurrentCell = _Dg_Cel;
                    }
                    catch { }
                    //-----------------------------------------
                    if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Cuenta"].Value == null) { _Bol_Cuenta = true; }
                    else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Cuenta"].Value.ToString().Trim().Length == 0) { _Bol_Cuenta = true; }
                    else
                    {
                        //----------------
                        if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value == null) { return false; }
                        else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value.ToString().Trim().Length == 0) { return false; }
                        //----------------
                        if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                        {
                            if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["cidauxiliarcont"].Value).Trim() == "0") { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Tipo"].Value == null) { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Tipo"].Value.ToString().Trim() == "nulo") { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Documento"].Value == null) { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Documento"].Value.ToString().Trim().Length == 0) { return false; }
                        }
                        _Bol_FilaValidada = true;
                    }
                    if ((_Bol_Cuenta & _Dg_Grid.RowCount > 1) | _Bol_FilaValidada)//Esto es para saber si la ultima fila se debe tomar en cuenta
                    { return true; }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
            return false;
        }
        private void _Mtd_CalcularTotalesBD(string _P_Str_Comprob)
        {
            string _Str_Cadena = "SELECT SUM(ctotdebe) AS ctotdebe,SUM(ctothaber) AS ctothaber,SUM(ctotdebe-ctothaber) AS csaldo FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprob + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Debe.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotdebe"]).ToString("#,##0.00");
                _Txt_Debe.Tag = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotdebe"]);//Para guardar
                _Txt_Haber.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctothaber"]).ToString("#,##0.00");
                _Txt_Haber.Tag = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctothaber"]);//Para guardar
                _Txt_Saldo.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["csaldo"]).ToString("#,##0.00");
                _Txt_Saldo.Tag = Convert.ToDouble(_Ds.Tables[0].Rows[0]["csaldo"]);//Para guardar
            }
        }
        private void _Mtd_CalcularTotales()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        _Dbl_Debe += Convert.ToDouble(_Ob_DebeD);
                        _Dbl_Haber += Convert.ToDouble(_Ob_HaberD);
                    }
                }
            }
            _Txt_Debe.Text = _Dbl_Debe.ToString("#,##0.00");
            _Txt_Debe.Tag = _Dbl_Debe;//Para guardar
            _Txt_Haber.Text = _Dbl_Haber.ToString("#,##0.00");
            _Txt_Haber.Tag = _Dbl_Haber;//Para guardar
            _Txt_Saldo.Text = Convert.ToDouble(_Dbl_Debe - _Dbl_Haber).ToString("#,##0.00");
            _Txt_Saldo.Tag = Convert.ToDouble(_Dbl_Debe - _Dbl_Haber);//Para guardar
        }
        private void _Mtd_CalcularDebeoHaber()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                if (_Ob_DebeD == null)
                { _Ob_DebeD = 0; }
                else if (_Ob_DebeD.ToString().Trim().Length == 0)
                { _Ob_DebeD = 0; }
                //---------------------------
                _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                if (_Ob_HaberD == null)
                { _Ob_HaberD = 0; }
                else if (_Ob_HaberD.ToString().Trim().Length == 0)
                { _Ob_HaberD = 0; }
                _Dbl_Debe += Convert.ToDouble(_Ob_DebeD);
                _Dbl_Haber += Convert.ToDouble(_Ob_HaberD);
            }
            if (_Dbl_Debe > _Dbl_Haber)
            { _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Haber"].Value = _Dbl_Debe - _Dbl_Haber; }
            else if (_Dbl_Haber > _Dbl_Debe)
            { _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Debe"].Value = _Dbl_Haber - _Dbl_Debe; }
        }

        private bool _Mtd_CuentasSinMonto(bool _P_Bol_Mensaje)
        {
            var _Ob_DebeD = new object();
            var _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim().Length > 0)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        if (Convert.ToDouble(_Ob_DebeD) == 0 && Convert.ToDouble(_Ob_HaberD) == 0)
                        {
                            if (_P_Bol_Mensaje)
                            {
                                MessageBox.Show("Debe ingresar el debe o el haber en todas las cuentas.", "Requerimiento",
                                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);   
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool _Mtd_ValiadarCuenta(string _P_Str_Cuenta)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim() == _P_Str_Cuenta)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Devuelve la cuenta de la fila si la hay
        /// </summary>
        /// <returns></returns>
        private string _Mtd_Cuenta(int _P_Int_RowIndex)
        {
            if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Cuenta"].Value != null)
            {
                if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                {
                    return _Dg_Grid.Rows[_P_Int_RowIndex].Cells["Cuenta"].Value.ToString().Trim();
                }
            }
            return "";
        }
        private void _Mtd_ValidarFila()
        {
            if (!_Bol_ComprobanteImportado)
            {
                if (_Dg_Grid.RowCount > 0)
                {
                    if (_Cmb_Tipo.SelectedIndex > 0 & _Txt_Descripcion.Text.Trim().Length > 0)
                    {
                        string _Str_Campos = "";
                        if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cuenta"].Value).Trim().Length == 0)
                        {
                            _Str_Campos = _Str_Campos + "Cuenta, ";
                        }
                        //----------------
                        if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Descripcion"].Value).Trim().Length == 0)
                        {
                            _Str_Campos = _Str_Campos + "Descripción del Movimiento, ";
                        }
                        //----------------
                        if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                        {
                            if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value).Trim() == "0")
                            {
                                _Str_Campos = _Str_Campos + "Id Auxiliar, ";
                            }
                            if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Tipo"].Value).Trim().Length == 0)
                            {
                                _Str_Campos = _Str_Campos + "Tipo de Documento, ";
                            }
                            else if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Tipo"].Value).Trim() == "nulo")
                            {
                                _Str_Campos = _Str_Campos + "Tipo de Documento, ";
                            }
                            //-------
                            if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim().Length == 0)
                            {
                                _Str_Campos = _Str_Campos + "Documento, ";
                            }
                        }
                        if (_Str_Campos.Length > 0)
                        {
                            _Lbl_DgInformacion.Visible = false;
                            _Str_Campos = _Str_Campos.Remove(_Str_Campos.Length - 2);
                            _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Khaki;
                            MessageBox.Show("Debe introducir los siguientes datos: " + _Str_Campos, "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (_Dg_Grid.CurrentCell.RowIndex == _Dg_Grid.RowCount - 1)
                            {
                                _Dg_Grid.Rows.Add();
                                _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value = _Dg_Grid.Rows[_Dg_Grid.RowCount - 2].Cells["Descripcion"].Value;
                                _Mtd_CalcularDebeoHaber();
                                _Lbl_DgInformacion.Visible = !_Mtd_VerificarDocExistente(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex]);
                            }
                        }
                        _Mtd_CalcularTotales();
                    }
                }
            }
        }
        private bool _Mtd_EsCuentaBancaria(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "SELECT ccount FROM TCUENTBANC WHERE ccount='" + _P_Str_Cuenta + "' AND cactivo='1' AND ISNULL(cdelete,0)='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        string _Str_Temp_Cuenta = "";
        string _Str_Temp_Descripcion = "";
        string _Str_Temp_Auxiliar = "";
        string _Str_Temp_Tipo = "";
        string _Str_Temp_Documento = "";
        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta;
                    }
                    else
                    {
                        if (!_Mtd_CuentaDetalle(_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Debe ingresar una cuenta de detalle.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                            _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta;
                        }
                        else if (Convert.ToString(_Cmb_Tipo.SelectedValue) == "06" && _Mtd_EsCuentaBancaria(_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Los ajustes contables (06) no deben tocar cuentas contables de las cuentas bancarias.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta;
                        }
                        else
                        {
                            if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value != _Str_Temp_Cuenta)
                            {
                                _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = null;
                                _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = null;
                                _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = null;
                                if (_Mtd_MarcarAuxiliar(e.RowIndex))
                                { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki; }
                                else
                                { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; }
                            }
                        }
                    }
                }
                else
                { _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta; }
            }
            else if (e.ColumnIndex == 2)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value = _Str_Temp_Descripcion;
                    }
                }
                else
                { _Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value = _Str_Temp_Descripcion; }
                //-------------------------------------------------------------------------------
            }
            else if (e.ColumnIndex == 3)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value.ToString().Trim().Length == 0 & _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = _Str_Temp_Auxiliar;
                    }
                }
                else
                {
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))) { _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = _Str_Temp_Auxiliar; }
                }
                //-------------------------------------------------------------------------------
            }
            else if (e.ColumnIndex == 5)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value.ToString().Trim() == "nulo" & _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = _Str_Temp_Tipo;
                    }
                }
                else
                {
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))) { _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = _Str_Temp_Tipo; }
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value.ToString().Trim().Length == 0 & _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = _Str_Temp_Documento;
                    }
                }
                else
                {
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))) { _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = _Str_Temp_Documento; }
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Debe"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Debe"].Value.ToString().Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Haber"].Value = null;
                    }
                }
                _Mtd_CalcularTotales();
            }
            else if (e.ColumnIndex == 8)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Haber"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Haber"].Value.ToString().Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Debe"].Value = null;
                    }
                }
                _Mtd_CalcularTotales();
            }
            _Bol_Boleano = false;
        }
        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Dg_Grid.ReadOnly & e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1)
                {
                    if (!_Bol_ComprobanteImportado)
                    {
                        TextBox _Txt_Temp = new TextBox();
                        Cursor = Cursors.WaitCursor;
                        Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
                        Cursor = Cursors.Default;
                        _Frm.ShowDialog();
                        if (_Txt_Temp.Text.Trim().Length > 0)
                        {
                            if (Convert.ToString(_Cmb_Tipo.SelectedValue) == "06" && _Mtd_EsCuentaBancaria(_Txt_Temp.Text.Trim()))
                            {
                                MessageBox.Show("Los ajustes contables (06) no deben tocar cuentas contables de las cuentas bancarias.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Txt_Temp.Text.Trim();
                            _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = null;
                            _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = null;
                            _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = null;
                            if (_Mtd_MarcarAuxiliar(e.RowIndex))
                            { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki; }
                            else
                            { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; }
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ComprobanteContableAux _Frm = new Frm_ComprobanteContableAux(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cuenta"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value).Trim());
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (Convert.ToString(_Frm._Txt_ID_Auxiliar.Tag).Trim() != "0" & Convert.ToString(_Frm._Txt_ID_Auxiliar.Tag).Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value = Convert.ToString(_Frm._Txt_ID_Auxiliar.Tag).Trim();
                        //_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            else
            {
                if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Cmb_Tipo.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Tipo, "Información requerida!!!"); }
            }
        }

        private void _Dg_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Mtd_ValidarFila();
            }
        }

        private void _Dg_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Dg_Grid.Rows.RemoveAt(_Dg_Grid.CurrentCell.RowIndex);
                if (_Dg_Grid.RowCount == 0)
                {
                    _Dg_Grid.Rows.Add();
                }
                _Mtd_CalcularTotales();
            }
        }

        private void _Ctrl_Contex_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.ReadOnly | _Bol_ComprobanteImportado)
            { e.Cancel = true; }
            else
            { _Tool_Crear.Enabled = _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)); }
        }

        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value != null)
                {
                    _Str_Temp_Cuenta = _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value != null)
                {
                    _Str_Temp_Descripcion = _Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value != null)
                {
                    _Str_Temp_Auxiliar = _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value != null)
                {
                    _Str_Temp_Tipo = _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value != null)
                {
                    _Str_Temp_Documento = _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value.ToString();
                }
            }
        }
        private void _Mtd_Aprobar(int _P_Int_Comprobante)
        {
            PrintDialog _Print = new PrintDialog();
                _PrintG:
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Int_Comprobante.ToString() + "'", _Print, true);
                if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    this.Close();
                }
                else
                {
                    _Frm.Close();
                    GC.Collect();
                    goto _PrintG;
                }
            }
            
        }
        private void _Mtd_Rechazar(int _P_Int_Comprobante)
        {
            string _Str_Cadena = "UPDATE TCOMPROBANC SET cestatusfirma='4',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_Comprobante + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            MessageBox.Show("El comprobante fue rechazado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            this.Close();
        }
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if(_Cls_Variosmetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                if (_Int_Sw == 0)
                { _Mtd_Aprobar(_Int_ComprExistente); }
                else
                { _Mtd_Rechazar(_Int_ComprExistente); }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                _Pnl_Cabecera.Enabled = false;
                _Pnl_Pie.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC");
                _Pnl_Cabecera.Enabled = true;
                _Pnl_Pie.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        bool _Bol_Mensaje = true;//Para que no se muestren los mensajes de _Mtd_Guardar()
        bool _Bol_Mensaje2 = true;//Para que no se muestre el mensaje de _Bt_Aprobar_Click
        int _Int_Sw = 0;
        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            _Dg_Grid.EndEdit();
            _Bol_Mensaje = false;
            bool _Bol_VerificarIdAuxTipDocNumDocNull = _Mtd_VerificarIdAuxTipDocNumDocNull();
            if ((!_Bol_ComprobanteImportado & _Mtd_VerificarFormulario() & !_Bol_VerificarIdAuxTipDocNumDocNull) | (_Bol_ComprobanteImportado & !_Bol_VerificarIdAuxTipDocNumDocNull))
            {
                if (_Mtd_VerificarDocExistentes())
                {
                    _Mtd_Guardar();
                    _Mtd_CalcularTotalesBD(_Int_ComprExistente.ToString());
                    if (Convert.ToDouble(_Txt_Debe.Text) > 0 & Convert.ToDouble(_Txt_Haber.Text) > 0 & Convert.ToDouble(_Txt_Saldo.Text) == 0)
                    {
                        if (_Mtd_CuentasSinMonto(false))
                            return;
                        _Int_Sw = 0; _Pnl_Clave.Visible = true;
                    }
                    else
                    {
                        if (_Bol_Mensaje2)
                        {
                            MessageBox.Show("No es posible aprobar el comprobante " + _Mtd_RetornarID_Correl(_Int_ComprExistente.ToString()) + " porque esta descuadrado o no se han ingresado montos.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                { MessageBox.Show("Los documentos marcados no existen en la base de datos del sistema. Verifique que la\ninformación en auxiliar, tipo de documento y documento sea correcta para cada\nregistro marcado.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else
            {
                if (_Bol_VerificarIdAuxTipDocNumDocNull)
                { MessageBox.Show("Verifique que en los registros marcados esten identificados el auxiliar, tipo de documento y documento", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (!_Bol_ComprobanteImportado)
                {
                    _Mtd_ValidarFila();
                    _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Selected = true;
                }
            }
            _Bol_Mensaje = true;
            _Bol_Mensaje2 = true;
        }

        //aqui
        private void _Pnl_MesAnoContable_VisibleChanged(object sender, EventArgs e)
        {
            if (dsn.Tables.Count == 0)
            {
                if (_Pnl_MesAnoContable.Visible)
                {
                    _Pnl_Cabecera.Enabled = false;
                    _Pnl_Pie.Enabled = false;
                    _Dg_Grid.Enabled = false;
                    _Mtd_CargarMesAno();
                    _Cmb_MesAno.Focus();
                    //--------------------------
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    //--------------------------
                }
                else
                {
                    _Pnl_Cabecera.Enabled = true;
                    _Pnl_Pie.Enabled = true;
                    _Dg_Grid.Enabled = true;
                    //--------------------------
                    _Mtd_Activated();
                    //--------------------------
                }
            }
        }

        private void _Bt_FechaCont_Click(object sender, EventArgs e)
        {
            _Pnl_MesAnoContable.Visible = true;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cmb_MesAno.SelectedIndex > 0)
            {
                _Str_MesCont = _Cmb_MesAno.SelectedValue.ToString();
                _Str_AnoCont = _Mtd_ExtraerAno(_Cmb_MesAno.Text);
                _Txt_MesAno.Text = _Str_MesCont + "-" + _Str_AnoCont;
                _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(_Mtd_UltimaFechaPorMes(_Str_AnoCont, _Str_MesCont));
                _Pnl_MesAnoContable.Visible = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un mes contable", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Cmb_MesAno.Focus();
            }
        }

        private void _Dg_Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Grid.CurrentCell.RowIndex != -1)
                {
                    _Mtd_MostrarToolTipsCell(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cuenta"].Value).Trim(), _Txt_Clave.Font);
                }
            }
            catch { }
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            _Int_Sw = 1; 
            _Pnl_Clave.Visible = true;
        }
        DataSet _Ds_Import = new DataSet();
        private DataTable _Mtd_CrearColums()
        {
            DataTable _Dt_Table = new DataTable("Tabla");
            _Dt_Table.Columns.Add("_P_Str_Id_Comp");
            _Dt_Table.Columns.Add("_P_Str_Id_Empleado");
            _Dt_Table.Columns.Add("_P_Str_Count");
            _Dt_Table.Columns.Add("_P_Str_Descrip");
            _Dt_Table.Columns.Add("_P_Str_Fecha");
            _Dt_Table.Columns.Add("_P_Str_Año");
            _Dt_Table.Columns.Add("_P_Str_Mes");
            _Dt_Table.Columns.Add("_P_Str_Debe");
            _Dt_Table.Columns.Add("_P_Str_Haber");
            return _Dt_Table;
        }
        private string[] _Mtd_CorregirArray(string[] _P_Str_Linea)
        {
            int _Int_Index = 0;
            foreach (string _Str in _P_Str_Linea)
            {
                if (_Int_Index == 0)
                { _P_Str_Linea[_Int_Index] = _P_Str_Linea[_Int_Index].Substring(1, _P_Str_Linea[_Int_Index].Length - 1); }
                else if (_Int_Index == _P_Str_Linea.Length - 1)
                { _P_Str_Linea[_Int_Index] = _P_Str_Linea[_Int_Index].Substring(0, _P_Str_Linea[_Int_Index].Length - 1); }
                _Int_Index++;
            }
            return _P_Str_Linea;
        }
        private void _Mtd_ImportarArchivo(string _P_Str_Archivo)
        {
            _Dg_Grid.Rows.Clear();
            _Ds_Import = new DataSet();
            _Ds_Import.Tables.Add(_Mtd_CrearColums());
            string _Str_DebeD = "";
            string _Str_HaberD = "";
            StreamReader _Stream = new StreamReader(_P_Str_Archivo);
            string _Str_Linea = "";
            string[] _Str_Datos = new string[0];
            while (!_Stream.EndOfStream)
            {
                _Str_Linea = Convert.ToString(_Stream.ReadLine()).Trim();
                if (_Str_Linea.Length > 0)
                {
                    _Str_Datos = _Str_Linea.Split(new string[] { "\",\"" }, StringSplitOptions.None);
                    _Str_Datos = _Mtd_CorregirArray(_Str_Datos);
                    if (Frm_Padre._Str_Comp.Trim().ToUpper() != _Str_Datos[0].Trim().ToUpper())
                    {
                        MessageBox.Show("El archivo seleccionado no corresponde con la compañía actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                    }
                    _Str_DebeD = Convert.ToDouble(_Str_Datos[7].Replace(".",",")).ToString();
                    _Str_HaberD = Convert.ToDouble(_Str_Datos[8].Replace(".", ",")).ToString();
                    if (_Str_DebeD.Trim().Length > 0) { if (Convert.ToDouble(_Str_DebeD.Trim()) == 0) { _Str_DebeD = ""; } }
                    if (_Str_HaberD.Trim().Length > 0) { if (Convert.ToDouble(_Str_HaberD.Trim()) == 0) { _Str_HaberD = ""; } }
                    _Dg_Grid.Rows.Add(new object[] { _Str_Datos[2].Trim(), ' ', _Str_Datos[3].Trim().ToUpper(), null, ' ', null, null, _Str_DebeD, _Str_HaberD });
                    _Ds_Import.Tables[0].Rows.Add((object[])_Str_Datos);
                }
            }
            _Stream.Close();
            _Mtd_CalcularTotales();
            if (_Dg_Grid.RowCount > 0) { _Bol_ComprobanteImportado = true; _Dg_Grid.Columns["Cuenta"].ReadOnly = true; _Dg_Grid.Columns["Debe"].ReadOnly = true; _Dg_Grid.Columns["Haber"].ReadOnly = true; }
        }

        private void _Bt_Importar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Tipo.SelectedIndex > 0)
            {
                _Opfd_File.FileName = "";
                _Opfd_File.Filter = "txt files (*.txt)|*.txt";
                _Opfd_File.ShowDialog();
                if (_Opfd_File.FileName.Trim().Length > 0)
                {
                    FileInfo _FilInf_Archivo = new FileInfo(_Opfd_File.FileName.Trim());
                    if (_FilInf_Archivo.Extension.ToUpper() == ".TXT")
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_ImportarArchivo(_Opfd_File.FileName);
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("Archivo no válido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                if (_Cmb_Tipo.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Tipo, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
            }
        }

        private void _Tool_Crear_Click(object sender, EventArgs e)
        {
            int _Int_TipoEntidad = _Mtd_TipoEntidad(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex]);
            Frm_ComprobanteContableDocVar _Frm = new Frm_ComprobanteContableDocVar(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex], _Int_TipoEntidad);
            _Frm.ShowDialog();
        }

        private void _Bt_DocVarios_Click(object sender, EventArgs e)
        {
            Frm_ComprobanteContableDocVar _Frm = new Frm_ComprobanteContableDocVar();
            _Frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var ccomp = dsn.Tables[0].Rows[0][0].ToString().Trim();
            var cfechacom = dsn.Tables[0].Rows[0][4].ToString().Trim();
            var cano = dsn.Tables[0].Rows[0][5].ToString().Trim();
            var cmes = dsn.Tables[0].Rows[0][6].ToString().Trim();
            var cidcom = _Cls_Variosmetodos._Mtd_Consecutivo_TCOMPROBANC();

            string _Str_Sql = Tcomprobanc_Ins2() + " \n";
            string _Str_Sql2 = "";//

            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim().Length > 0)
                {
                    _Str_Sql +=
                        "INSERT INTO TNOMINACONTABILIDAD VALUES (GETDATE(), '" +
                        ccomp +
                        "', '', '" +
                        _Dg_Row.Cells[0].Value.ToString().Trim() + "', '" +
                        _Dg_Row.Cells[2].Value.ToString().Trim() + "', " +
                        "CONVERT(datetime, '" + cfechacom + "',103), " +
                        cano + ", " + cmes + ", " +
                        Val_Null(Convert.ToDecimal(_Dg_Row.Cells[7].Value).ToString().Replace(',', '.')) + ", " +
                        Val_Null(Convert.ToDecimal(_Dg_Row.Cells[8].Value).ToString().Replace(',', '.')) + ", " +
                        cidcom + ", 0) \n";

                    _Str_Sql +=
                        "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,ctotdebe,ctothaber,cdateadd,cuseradd) VALUES ('" + 
                                                            Frm_Padre._Str_Comp + "', " +
                                                            cidcom + ", " +
                                                            _Dg_Row.Index + 1 + ", '" +
                                                            _Dg_Row.Cells[0].Value.ToString() + "', '" +
                                                            _Dg_Row.Cells[2].Value.ToString() + "', '" +
                                                            _Dg_Row.Cells[5].Value.ToString() + "', '" +
                                                            _Dg_Row.Cells[6].Value.ToString() + "', " +
                                                            Val_Null(Convert.ToDecimal(_Dg_Row.Cells[7].Value).ToString().Replace(',', '.')) + ", " +
                                                            Val_Null(Convert.ToDecimal(_Dg_Row.Cells[8].Value).ToString().Replace(',', '.')) + ", " +
                                                            "GETDATE(), '" +
                                                            Frm_Padre._Str_Use + "') \n";
                }
            }

            //foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            //{
            //    if (Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim().Length > 0){
            //        _Str_Sql += "INSERT INTO TCOMPROBAND VALUES ('" + Frm_Padre._Str_Comp + "', " + cidcom + ", " + _Dg_Row.Index + 1 + ", '" + _Dg_Row.Cells[0].Value.ToString() + "', '" + _Dg_Row.Cells[2].Value.ToString() + "', '" + _Dg_Row.Cells[6].Value.ToString() + "', " + _Dg_Row.Cells[0].Value.ToString() + ", " + Val_Null(Convert.ToDecimal(_Dg_Row.Cells[7].Value).ToString().Replace(',', '.')) + ", " + Val_Null(Convert.ToDecimal(_Dg_Row.Cells[8].Value).ToString().Replace(',', '.')) + ", " + "GETDATE(), '" + Frm_Padre._Str_Use + "') \n";}
            //}
            
            //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }

        public string Tcomprobanc_Ins2()
        {
            string _Str_Sql = "INSERT INTO TCOMPROBANC VALUES ('" +
                                Frm_Padre._Str_Comp + "', " +
                                _Cls_Variosmetodos._Mtd_Consecutivo_TCOMPROBANC() + ", " +
                                "'06', '" +
                                _Txt_Descripcion.Text.Trim() + "', " +
                                dsn.Tables[0].Rows[0][5].ToString().Trim() + ", " +
                                dsn.Tables[0].Rows[0][6].ToString().Trim() + ", " +
                                "GETDATE(), " +
                                _Txt_Debe.Text.Replace(',', '.') + ", " +
                                _Txt_Haber.Text.Replace(',', '.') + ", " +
                                _Txt_Saldo.Text.Replace(',', '.') + ", " +
                                "0, 0, 0, '0', '0', '0', '0', 0, 0, GETDATE(), '" +
                                Frm_Padre._Str_Use + "', " +
                                "GETDATE(), GETDATE(), '" +
                                Frm_Padre._Str_Use +
                                "', '0', 0,NULL, 0, 0, 0, '0')";
            return _Str_Sql;
        }

        public string Val_Null(string Val)
        {
            if (string.IsNullOrEmpty(Val) == true){return "00.0";}
            else{return Val;}
        }
    }
}