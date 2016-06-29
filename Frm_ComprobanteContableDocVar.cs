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
    public partial class Frm_ComprobanteContableDocVar : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        DataGridViewRow _Dg_Row;
        public Frm_ComprobanteContableDocVar(DataGridViewRow _P_Dg_Row, int _P_Int_TipoEntidad)
        {
            InitializeComponent();
            _Mtd_CargarTipoDocument();
            _Mtd_CargarTipoEntidad();
            _Cmb_TipoEntidad.SelectedValue = _P_Int_TipoEntidad.ToString();
            _Cmb_TipoEntidad.Enabled = false;
            _Mtd_Actualizar();
            _Dg_Row = _P_Dg_Row;
            this.DialogResult = DialogResult.No;
        }
        public Frm_ComprobanteContableDocVar()
        {
            InitializeComponent();
            _Mtd_CargarTipoDocument();
            _Mtd_CargarTipoEntidad();
            _Mtd_Actualizar();
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            this.DialogResult = DialogResult.No;
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
        private void _Mtd_CargarTipoDocument()
        {
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_TipoDoc, "SELECT ctdocument,cname FROM TDOCUMENT");
        }
        private void _Mtd_CargarTipoEntidad()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoEntidad.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("CLIENTE", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("PROVEEDOR", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("EMPLEADO", "2"));
            _Cmb_TipoEntidad.DataSource = _myArrayList;
            _Cmb_TipoEntidad.DisplayMember = "Display";
            _Cmb_TipoEntidad.ValueMember = "Value";
            _Cmb_TipoEntidad.SelectedValue = "nulo";
            _Cmb_TipoEntidad.DataSource = _myArrayList;
            _Cmb_TipoEntidad.SelectedIndex = 0;
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Entidad");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Documento");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "centidad";
            _Str_Campos[1] = "centidaddesc";
            _Str_Campos[2] = "cnumdocu";
            string _Str_Cadena = "SELECT ctipoentidaddesc AS [Tipo Entidad],centidad AS Entidad,centidaddesc AS [Desc. Entidad],ctipodocument AS [Tipo Doc.],cnumdocu AS Documento, dbo.Fnc_Formatear(cmontodoc) AS Monto, CONVERT(VARCHAR,cfechadoc,103) AS [Fecha Documento],ctipoentidad,cgensistema FROM VST_DOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Cmb_TipoEntidad.SelectedIndex > 0 & !_Cmb_TipoEntidad.Enabled)
            {
                _Str_Cadena += " AND ctipoentidad='" + Convert.ToString(_Cmb_TipoEntidad.SelectedValue).Trim() + "'";
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Documentos varios", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns["Tipo Doc."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Fecha Documento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["ctipoentidad"].Visible = false;
            _Dg_Grid.Columns["cgensistema"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private bool _Mtd_InsertarRegistros(double _P_Dbl_Monto,string _P_Str_Documento)
        {
            try
            {
                string _Str_Cadena = "INSERT INTO TDOCVARIOS (ccompany,ctipodocument,cnumdocu,ctipoentidad,centidad,cmontodoc,cfechadoc,cgensistema,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim() + "','" + _P_Str_Documento + "','" + Convert.ToString(_Cmb_TipoEntidad.SelectedValue) + "','" + Convert.ToString(_Txt_Entidad.Tag).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(_Dtp_FechaDoc.Value) + "','" + Convert.ToInt32(_Chk_GenSistema.Checked) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                return true;
            }
            catch (Exception Ex) 
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void _Mtd_Inicializar()
        {
            _Mtd_CargarTipoDocument();
            _Mtd_CargarTipoEntidad();
            _Txt_Documento.Text = "";
            _Txt_Entidad.Tag = "";
            _Txt_Entidad.Text = "";
            _Txt_Monto.Text = "";
            _Chk_GenSistema.Checked = false;
        }
        private string _Mtd_CodigoAutomatico()
        {
            string _Str_Cadena = "SELECT ISNULL(MAX(cnumdocu),0)+1 FROM TDOCVARIOS WHERE ISNUMERIC(cnumdocu)=1 AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgensistema='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows[0][0].ToString().Trim();
        }
        private bool _Mtd_VerificarDocExistente(string _P_Str_Entidad, string _P_Str_TipoDoc, string _P_Str_Documento)
        {
            string _Str_TipoDocFACT_CxC = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocfact");
            string _Str_TipoDocNC_CxC = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocnotcred");
            string _Str_TipoDocND_CxC = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocnotdeb");
            //-------------------------
            string _Str_TipoDocFACT_CxP = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
            string _Str_TipoDocNC_CxP = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnc");
            string _Str_TipoDocND_CxP = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnd");
            string _Str_TipoDocRETIVA = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva");
            string _Str_TipoDocRETISLR = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr");
            //-------------------------
            DataSet _Ds;
            string _Str_Cadena = "";
            if (Convert.ToString(_Cmb_TipoEntidad.SelectedValue).Trim() == "0")
            {
                if (_P_Str_TipoDoc.Trim().ToUpper() == _Str_TipoDocFACT_CxC.ToUpper())
                {
                    if (_Cls_VariosMetodos._Mtd_IsNumeric(_P_Str_Documento))
                    {
                        _Str_Cadena = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Entidad + "' AND cfactura='" + _P_Str_Documento + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { return true; }
                    }
                }
                else if (_P_Str_TipoDoc.Trim().ToUpper() == _Str_TipoDocNC_CxC.ToUpper())
                {
                    if (_Cls_VariosMetodos._Mtd_IsNumeric(_P_Str_Documento))
                    {
                        _Str_Cadena = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Entidad + "' AND cidnotcredicc='" + _P_Str_Documento + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { return true; }
                    }
                }
                else if (_P_Str_TipoDoc.Trim().ToUpper() == _Str_TipoDocND_CxC.ToUpper())
                {
                    if (_Cls_VariosMetodos._Mtd_IsNumeric(_P_Str_Documento))
                    {
                        _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Entidad + "' AND cidnotadebitocc='" + _P_Str_Documento + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { return true; }
                    }
                }
                //--------------------------
                _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='0' AND centidad='" + _P_Str_Entidad + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND cnumdocu='" + _P_Str_Documento + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { return true; }
            }
            else if (Convert.ToString(_Cmb_TipoEntidad.SelectedValue).Trim() == "1")
            {
                _Str_Cadena = "SELECT cnumdocu FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Entidad + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND cnumdocu='" + _P_Str_Documento + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { return true; }
                //--------------------------
                _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='1' AND centidad='" + _P_Str_Entidad + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND cnumdocu='" + _P_Str_Documento + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { return true; }
            }
            else
            {
                _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='2' AND centidad='" + _P_Str_Entidad + "' AND ctipodocument='" + _P_Str_TipoDoc + "' AND cnumdocu='" + _P_Str_Documento + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { return true; }
            }
            return false;
        }
        private void Frm_ComprobanteContableDocVar_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void _Txt_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }

        private void _Txt_Documento_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Documento.Text.Contains("'") | _Txt_Documento.Text.Contains("*") | _Txt_Documento.Text.Contains("=") | _Txt_Documento.Text.Contains("%"))
            {
                _Txt_Documento.Text = _Txt_Documento.Text.Replace("'", "").Replace("*", "").Replace("=", "").Replace("%", "");
                _Txt_Documento.Select(_Txt_Documento.TextLength, 0);
            }
        }

        private void _Chk_GenSistema_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_Documento.Enabled = !_Chk_GenSistema.Checked;
            _Txt_Documento.Text = "";
        }

        private void _Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Monto.Text)) { _Txt_Monto.Text = ""; }
        }

        private void _Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Monto, e, 15, 2);
        }
        private void _Cmb_TipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Txt_Entidad.Text = "";
            _Txt_Entidad.Tag = "";
            _Bt_BuscarEntidad.Enabled = _Cmb_TipoEntidad.SelectedIndex > 0;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            double _Dbl_Monto = 0;
            double.TryParse(_Txt_Monto.Text, out _Dbl_Monto);
            _Er_Error.Dispose();
            if (_Cmb_TipoDoc.SelectedIndex > 0 & (_Txt_Documento.Text.Trim().Length > 0 | _Chk_GenSistema.Checked) & _Cmb_TipoEntidad.SelectedIndex > 0 & Convert.ToString(_Txt_Entidad.Tag).Trim().Length > 0 & _Dbl_Monto > 0)
            {
                bool _Bol_DocExiste = false;
                if (!_Chk_GenSistema.Checked)
                {
                    _Bol_DocExiste = _Mtd_VerificarDocExistente(Convert.ToString(_Txt_Entidad.Tag).Trim(), Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim(), _Txt_Documento.Text.Trim());
                }
                if (_Bol_DocExiste)
                { MessageBox.Show("El documento que intenta registrar ya existe en la base de datos del sistema. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    string _Str_Documento = _Txt_Documento.Text.Trim();
                    
                    if (_Chk_GenSistema.Checked)
                    { 
                        _Str_Documento = _Mtd_CodigoAutomatico();
                        _Bol_DocExiste = _Mtd_VerificarDocExistente(Convert.ToString(_Txt_Entidad.Tag).Trim(), Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim(), _Str_Documento);

                        /*
                         * Mientras el número se repita, se incrementa el número de documento, esto es para evitar conflictos de clave
                         * primaria con los números que agregan manualmente los usuarios.
                         */

                        while (_Bol_DocExiste)
                        {
                            _Str_Documento = (Convert.ToInt32(_Str_Documento) + 1).ToString();
                            _Bol_DocExiste = _Mtd_VerificarDocExistente(Convert.ToString(_Txt_Entidad.Tag).Trim(), Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim(), _Str_Documento);
                        }
                    }

                    if (_Mtd_InsertarRegistros(_Dbl_Monto, _Str_Documento))
                    {
                        if (_Dg_Row != null)
                        {
                            _Txt_Documento.Text = _Str_Documento;
                            _Dg_Row.Cells["Tipo"].Value = _Cmb_TipoDoc.SelectedValue;
                            _Dg_Row.Cells["cidauxiliarcont"].Value = _Txt_Entidad.Tag;
                            _Dg_Row.Cells["Documento"].Value = _Txt_Documento.Text;
                            _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                            this.DialogResult = DialogResult.Yes;
                        }
                        else
                        {
                            _Mtd_Inicializar();
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                        MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (_Cmb_TipoDoc.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_TipoDoc, "Información requerida!!!"); }
                if (_Txt_Documento.Text.Trim().Length == 0 & !_Chk_GenSistema.Checked) { _Er_Error.SetError(_Txt_Documento, "Información requerida!!!"); }
                if (_Cmb_TipoEntidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_TipoDoc, "Información requerida!!!"); }
                if (Convert.ToString(_Txt_Entidad.Tag).Trim().Length == 0) { _Er_Error.SetError(_Bt_BuscarEntidad, "Información requerida!!!"); }
                if (_Dbl_Monto <= 0) { _Er_Error.SetError(_Txt_Monto, "Información requerida!!!"); }
            }
        }

        private void _Cmb_TipoDoc_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTipoDocument();
        }

        private void _Cmb_TipoEntidad_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTipoEntidad();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Row != null)
            {
                if (e.RowIndex != -1 & _Dg_Grid.SelectedRows.Count == 1)
                {
                    _Cmb_TipoDoc.SelectedValue = _Dg_Grid.Rows[e.RowIndex].Cells["Tipo Doc."].Value;
                    _Cmb_TipoEntidad.SelectedValue = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["ctipoentidad"].Value);
                    _Txt_Entidad.Tag = _Dg_Grid.Rows[e.RowIndex].Cells["Entidad"].Value;
                    _Txt_Entidad.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Desc. Entidad"].Value);
                    _Txt_Monto.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Monto"].Value);
                    _Chk_GenSistema.Checked = Convert.ToBoolean(int.Parse(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cgensistema"].Value)));
                    _Txt_Documento.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value);
                    //----------------
                    _Dg_Row.Cells["Tipo"].Value = Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim();
                    _Dg_Row.Cells["cidauxiliarcont"].Value = _Txt_Entidad.Tag;
                    _Dg_Row.Cells["Documento"].Value = _Txt_Documento.Text;
                    _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                    this.DialogResult = DialogResult.Yes;
                    //----------------
                }
            }
        }

        private void _Bt_BuscarEntidad_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_TipoEntidad.SelectedValue).Trim() == "0")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult == "1")
                {
                    _Txt_Entidad.Tag = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                    _Txt_Entidad.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                }
            }
            else if (Convert.ToString(_Cmb_TipoEntidad.SelectedValue).Trim() == "1")
            {
                string _Str_Cadena = " AND (cglobal='1' OR TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "')";
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_Entidad, 0, _Str_Cadena);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(36);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult == "1")
                {
                    _Txt_Entidad.Tag = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                    _Txt_Entidad.Text = _Frm._Dg_Grid[2, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                }
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 1)
            { e.Cancel = true; }
        }

        private void _Bt_Nuevo_Click(object sender, EventArgs e)
        {
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Cmb_TipoDoc.Focus();
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgCargaInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgCargaInfo.Visible = false;
        }

        private void Frm_ComprobanteContableDocVar_Shown(object sender, EventArgs e)
        {
            _Cmb_TipoDoc.Focus();
        }
    }
}
