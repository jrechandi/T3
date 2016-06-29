using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_NumControl : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_NumControl()
        {
            InitializeComponent();
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
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Actualizar(string _P_Str_Desde, string _P_Str_Hasta, int _P_Int_Seleccion,string _P_Str_Where)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "";
            if (_Rb_Fact.Checked)
            {
                _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TFACTURAM.cfactura AS Documento, TFACTURAM.c_numerocontrol AS NumeroAnt " +
                "FROM TCONFIGCXC INNER JOIN " +
                "TFACTURAM ON TCONFIGCXC.ccompany = TFACTURAM.ccompany INNER JOIN " +
                "TDOCUMENT ON TCONFIGCXC.ctipdocfact = TDOCUMENT.ctdocument " +
                "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTURAM.c_impresa = '1') AND (TFACTURAM.cfactura BETWEEN '" + _P_Str_Desde + "' AND '" + _P_Str_Hasta + "')" + _P_Str_Where;
                _Str_Cadena += " ORDER BY Documento";
            }
            else
            {
                _Str_Cadena = "SELECT TDOCUMENT.cname AS Tipo, TNOTACREDICC.cidnotcredicc AS Documento, TNOTACREDICC.cnumcontrolnc AS NumeroAnt " +
                "FROM TCONFIGCXC INNER JOIN "+
                "TNOTACREDICC ON TCONFIGCXC.ccompany = TNOTACREDICC.ccompany INNER JOIN " +
                "TDOCUMENT ON TCONFIGCXC.ctipdocnotcred = TDOCUMENT.ctdocument "+
                "WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cimpresa = '1') AND (TNOTACREDICC.cidnotcredicc BETWEEN '" + _P_Str_Desde + "' AND '" + _P_Str_Hasta + "')" + _P_Str_Where;
                _Str_Cadena += " ORDER BY Documento";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private bool _Mtd_BuscarIguales(int _P_Int_Index, object _P_Ob_Valor)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Index != _P_Int_Index)
                {
                    if (Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim() == _P_Ob_Valor.ToString().Trim())
                    { return true; }
                }
            }
            return false;
        }
        private void _Mtd_ColocarNumeros(int _P_Str_Numero)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Dg_Row.Cells["Numero"].Value = _P_Str_Numero;
                _P_Str_Numero++;
            }
        }
        private void _Mtd_ActualizarNumeros()
        {
            string _Str_Cadena = "";
            string _Str_IdHistorial = _Mtd_Entrada().ToString();
            if (_Rb_Fact.Checked)
            {
                string _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocfact");
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    _Str_Cadena = "UPDATE TFACTURAM SET c_numerocontrol='" + Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_GuardarHistorial(_Str_IdHistorial, _Str_TipoDocument, Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["NumCtrlAnt"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim());
                }
            }
            else
            {
                string _Str_TipoDocument = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocnotcred");
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    _Str_Cadena = "UPDATE TNOTACREDICC SET cnumcontrolnc='" + Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_GuardarHistorial(_Str_IdHistorial, _Str_TipoDocument, Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["NumCtrlAnt"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim());
                }
            }
        }
        private void _Mtd_Ini()
        {
            _Bt_Actualizar.Enabled = false;
            _Dg_Grid.Columns["Numero"].ReadOnly = true;
            _Mtd_Actualizar(_Txt_Desde.Text.Trim(), _Txt_Hasta.Text.Trim(), 0, " AND 0>1");//Para Inicializar
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cidhistorial FROM THISTNUMCTRL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidhistorial DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void _Mtd_GuardarHistorial(string _P_Str_IDHistorial,string _P_Str_TipoDocument, string _P_Str_Document, string _P_Str_NumCtrlAnterior, string _P_Str_NumCtrlNuevo)
        {
            string _Str_Cadena = "INSERT INTO THISTNUMCTRL (cgroupcomp,ccompany,cidhistorial,ctipodocument,cnumdocu,cnumctrlanterior,cnumctrlnuevo,cuser,cfechahora) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_IDHistorial + "','" + _P_Str_TipoDocument + "','" + _P_Str_Document + "','" + _P_Str_NumCtrlAnterior + "','" + _P_Str_NumCtrlNuevo + "','" + Frm_Padre._Str_Use + "',GETDATE())";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void Frm_NumControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Numero.Left = (this.Width / 2) - (_Pnl_Numero.Width / 2);
            _Pnl_Numero.Top = (this.Height / 2) - (_Pnl_Numero.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted();
        }

        private void _Txt_Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Desde, e, 10, 0);
        }

        private void _Txt_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Hasta, e, 10, 0);
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Desde.Text.Trim().Length > 0 & _Txt_Hasta.Text.Trim().Length > 0)
            {
                if (Convert.ToInt32(_Txt_Desde.Text) > 0 & Convert.ToInt32(_Txt_Hasta.Text) > 0)
                {
                    if (Convert.ToInt32(_Txt_Desde.Text) <= Convert.ToInt32(_Txt_Hasta.Text))
                    {
                        _Mtd_Ini();
                        _Mtd_Actualizar(_Txt_Desde.Text.Trim(), _Txt_Hasta.Text.Trim(), 0, " AND 1>0");
                    }
                    else
                    { MessageBox.Show("El número hasta debe ser mayor que el número desde", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else
                {
                    if (Convert.ToInt32(_Txt_Desde.Text) == 0) { _Er_Error.SetError(_Txt_Desde, "Información requerida!!!"); }
                    if (Convert.ToInt32(_Txt_Hasta.Text) == 0) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
                }
            }
            else
            {
                if (_Txt_Desde.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Desde, "Información requerida!!!"); }
                if (_Txt_Hasta.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Pnl_Superior.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; _Pnl_Superior.Enabled = true; }
        }
        string _Str_NumeroTemp = "";
        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Numero")
                {
                    _Str_NumeroTemp = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value);
                }
            }
        }

        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Numero")
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        if (_Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length == 0)
                        {
                            _Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_NumeroTemp;
                        }
                        else if (_Mtd_BuscarIguales(e.RowIndex, _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value))
                        {
                            MessageBox.Show("El valor que introdujo ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp;
                        }
                        else
                        { _Str_NumeroTemp = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value); }
                    }
                    else
                    { _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp; }
                }
            }
        }
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarNumeros();
                Cursor = Cursors.Default;
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Txt_Desde.Text = "";
                _Txt_Hasta.Text = "";
                _Mtd_Ini();
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Pnl_Numero_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Numero.Visible)
            { _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Pnl_Superior.Enabled = false; _Txt_Numero.Text = ""; _Txt_Numero.Focus(); }
            else
            { _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; _Pnl_Superior.Enabled = true; }
        }

        private void _Bt_CancelarNumero_Click(object sender, EventArgs e)
        {
            _Pnl_Numero.Visible = false;
        }

        private void _Txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Numero, e, 10, 0);
        }

        private void _Bt_AceptarNumero_Click(object sender, EventArgs e)
        {
            if (_Txt_Numero.Text.Trim().Length > 0)
            {
                _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text));
                _Dg_Grid.Columns["Numero"].ReadOnly = false;
                _Pnl_Numero.Visible = false;
                _Bt_Actualizar.Enabled = true;
            }
        }

        private void _Txt_Desde_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Desde.Text))
            {
                _Txt_Desde.Text = "";
            }
        }

        private void _Txt_Hasta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Hasta.Text))
            {
                _Txt_Hasta.Text = "";
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
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name.Trim() == "Numero")
            {
                if (!_Mtd_IsNumeric(((TextBox)sender).Text))
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name.Trim() == "Numero")
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void _Rb_Fact_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Fact.Checked)
            { _Mtd_Ini(); _Lbl_Desde.Text = "Factura desde:"; _Lbl_Hasta.Text = "Factura hasta:"; }
            else
            { _Mtd_Ini(); _Lbl_Desde.Text = "NC desde:"; _Lbl_Hasta.Text = "NC hasta:"; }
        }

        private void _Bt_NumCtrl_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                _Pnl_Numero.Visible = true; _Txt_Numero.Text = ""; _Txt_Numero.Focus();
            }
            else
            { MessageBox.Show("No existen registros para realizar la operación", "información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Txt_Numero_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Numero.Text))
            {
                _Txt_Numero.Text = "";
            }
        }

        private void Frm_NumControl_Shown(object sender, EventArgs e)
        {
            if (!(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CORREGIR_NUMCTRL")))
            {
                MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
            }
        }
    }
}