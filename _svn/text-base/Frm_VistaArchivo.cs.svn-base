using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using T3.Clases;
namespace T3
{
    public partial class Frm_VistaArchivo : Form
    {
        public Frm_VistaArchivo()
        {
            InitializeComponent();
        }

        public Frm_VistaArchivo(string _P_Str_Archivo)
        {
            InitializeComponent();
            _Txt_Archivo.Text = _P_Str_Archivo;
            _Txt_LineaInicioDatos.Text = "1";
        }
        #region _Mtd_Crearlinea
        private void _Mtd_Crearlinea(RichTextBox _P_Rich_TextBox, DataGridView _P_Dg_Grid, int _P_Int_X)
        {
            Label _Lbl_Linea = new Label();
            _Lbl_Linea.BackColor = Color.Black;
            _Lbl_Linea.Location = new Point(_P_Int_X, 0);
            _Lbl_Linea.Tag = _P_Rich_TextBox.SelectionStart;
            _Lbl_Linea.Size = new Size(1, _P_Rich_TextBox.Height);
            _P_Rich_TextBox.Controls.Add(_Lbl_Linea);
            _Mtd_RenombrarLineas(_P_Rich_TextBox, _P_Dg_Grid, "_Lbl_");
        }
        private void _Mtd_RenombrarLineas(RichTextBox _P_Rich_TextBox, DataGridView _P_Dg_Grid, string _P_Str_Name)
        {
            var _Var_Ctrl = (from _Ctrl in _P_Rich_TextBox.Controls.Cast<Control>() select _Ctrl).OrderBy(c => c.Location.X);
            _P_Dg_Grid.Columns.Clear();
            int _Int_Index = 0, _Int_Linea = 0, _Int_CaracterFinal = 0, _Int_CaracterInicial = 0, _Int_Posicion_Inicial = 0, _Int_Posicion_Final = 0, _Int_Length = 0;
            foreach (Control _Ctrl in _Var_Ctrl)
            {
                _Int_Linea = _P_Rich_TextBox.GetLineFromCharIndex(Convert.ToInt32(_Ctrl.Tag));
                _Int_Posicion_Inicial = _P_Rich_TextBox.GetFirstCharIndexFromLine(_Int_Linea);
                _Int_Posicion_Final = Convert.ToInt32(_Ctrl.Tag);
                _Int_Length = _Int_Posicion_Final - _Int_Posicion_Inicial;
                _Int_CaracterInicial = _Int_CaracterInicial + _Int_CaracterFinal;
                _Int_CaracterFinal = _Int_Length - _Int_CaracterInicial;
                _Mtd_CrearGrid(_P_Rich_TextBox, _P_Dg_Grid, _Int_Index, _Int_CaracterInicial, _Int_CaracterFinal);
                _Int_Index += 1;
            }
        }
        private void _Mtd_CrearGrid(RichTextBox _P_Rich_TextBox, DataGridView _P_Dg_Grid, int _P_Int_Index, int _Int_CaracterInicial, int _Int_CaracterFinal)
        {
            try
            {
                _P_Dg_Grid.Columns.Add("_Col_" + Convert.ToString(_P_Int_Index + 1), Convert.ToString(_P_Int_Index + 1));
                int _Int_I = 0;
                foreach (string _Linas in _P_Rich_TextBox.Lines)
                {
                    if (_Linas.Trim().Length > 0)
                    {
                        if (_P_Dg_Grid.Columns.Count == 1)
                        {
                            _P_Dg_Grid.Rows.Add();
                        }
                        _P_Dg_Grid.Rows[_Int_I].Cells[_P_Int_Index].Value = _Linas.Substring(_Int_CaracterInicial, _Int_CaracterFinal);
                    }
                    _Int_I += 1;
                }
            }
            catch { }
        }
        #endregion
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Carga.Columns.Count; _Int_i++)
            {
                _Dg_Carga.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_ProcesarFileSeparadores()
        {
            bool _Bol_Sw = false;
            string[] _DelimiterChars = new string[0];
            if (_Rb_Espacio.Checked)
            {
                _DelimiterChars = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_DelimiterChars, _DelimiterChars.Length + 1);
                _DelimiterChars[_DelimiterChars.Length - 1] = " ";
                _Mtd_SepararArchivo(_Txt_Archivo.Text, _DelimiterChars, Convert.ToInt32(_Txt_LineaInicioDatos.Text));
            }
            else if (_Rb_PuntoYComa.Checked)
            {
                _DelimiterChars = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_DelimiterChars, _DelimiterChars.Length + 1);
                _DelimiterChars[_DelimiterChars.Length - 1] = ";";
                _Mtd_SepararArchivo(_Txt_Archivo.Text, _DelimiterChars,Convert.ToInt32( _Txt_LineaInicioDatos.Text));
            }
            else if (_Rb_Coma.Checked)
            {
                _DelimiterChars = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_DelimiterChars, _DelimiterChars.Length + 1);
                _DelimiterChars[_DelimiterChars.Length - 1] = ",";
                _Mtd_SepararArchivo(_Txt_Archivo.Text, _DelimiterChars,Convert.ToInt32( _Txt_LineaInicioDatos.Text));
            }
            else if (_Rb_Tabulacion.Checked)
            {
                _DelimiterChars = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_DelimiterChars, _DelimiterChars.Length + 1);
                _DelimiterChars[_DelimiterChars.Length - 1] = "\t";
                _Mtd_SepararArchivo(_Txt_Archivo.Text, _DelimiterChars,Convert.ToInt32( _Txt_LineaInicioDatos.Text));
            }
            else if (_Rb_Otro.Checked)
            {
                _DelimiterChars = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_DelimiterChars, _DelimiterChars.Length + 1);
                _DelimiterChars[_DelimiterChars.Length - 1] = _Txt_Otro.Text;
                _Mtd_SepararArchivo(_Txt_Archivo.Text, _DelimiterChars, Convert.ToInt32(_Txt_LineaInicioDatos.Text));
            }
        }
        private bool _Mtd_ValidarColsName(string _Pr_Str_ColName)
        {
            foreach (DataGridViewColumn _DgCol in _Dg_Carga.Columns)
            {
                if (_DgCol.Name == _Pr_Str_ColName)
                {
                    return true;
                }
            }
            return false;
        }
        private void _Mtd_SepararArchivo(string _Pr_Str_File, string[] _Pr_Delimitadores, int _Str_LineaInicioDatos)
        {

            _Bt_Aceptar.Enabled = false;
            _Bt_Cancelar.Enabled = false;
            _Bt_Ini.Enabled = false;

            //Desactivo el Dibujado del Grid para Acelerar la Vista
            Cursor = Cursors.WaitCursor;
            _Dg_Carga.SuspendLayout();
            _Dg_Carga.Rows.Clear();
            _Dg_Carga.Columns.Clear();

            //Cargo el archivo segun los parametros
            DataSet _Ds = _Cls_RutinasInterfazBancaria._Mtd_ObtenerDsDesdeArchivo(_Pr_Str_File, _Pr_Delimitadores, _Str_LineaInicioDatos);
            //Paso el Ds al Grid
            _Cls_RutinasInterfazBancaria._Mtd_ExportarDeDatasetADataGridView(_Ds, _Dg_Carga);

            _Dg_Carga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Carga.Visible = true;

            //Activo el Dibujado del Grid
            _Dg_Carga.ResumeLayout();
            Cursor = Cursors.Default;

            //Desactivo los Botones
            _Bt_Aceptar.Enabled = _Dg_Carga.ColumnCount > 0;
            _Bt_Cancelar.Enabled = true;
            _Bt_Ini.Enabled = true;

        }
        private void _Mtd_CargarArchivoText(string _Pr_Str_File)
        {
            string[] _StrVec = new string[0];
            StreamReader objReader = new StreamReader(_Pr_Str_File);
            string sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    if (sLine.Trim().Length > 0)
                    {
                        _StrVec = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_StrVec, _StrVec.Length + 1);
                        _StrVec[_StrVec.Length - 1] = sLine;
                    }
                }
            }
            objReader.Close();
            _RTxt_Vista.Lines = _StrVec;
        }
        private void _Mtd_DesCheckear(Control _P_Ctrl)
        {
            foreach (Control _Ctrl in _Grb_CaracteresSeparadores.Controls)
            {
                if (_Ctrl.GetType() == typeof(RadioButton))
                { ((RadioButton)_Ctrl).Checked = false; }
            }
        }
        private void _Mtd_InicializarGrid()
        {
            _Dg_Carga.Rows.Clear();
            _Dg_Carga.Columns.Clear();
        }
        private void _Rb_Caracteres_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Caracteres.Checked)
            { _Grb_CaracteresSeparadores.Enabled = true; _RTxt_Vista.Enabled = false; _Mtd_Ini(); }
        }

        private void _Rb_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_PorUsuario.Checked)
            { _Grb_CaracteresSeparadores.Enabled = false; _RTxt_Vista.Enabled = true; _Mtd_Ini(); _Mtd_CargarArchivoText(_Txt_Archivo.Text); }
        }

        private void _RTxt_Vista_MouseClick(object sender, MouseEventArgs e)
        {
            _Mtd_Crearlinea(_RTxt_Vista, _Dg_Carga, e.X);
        }

        private void _Rb_Tabulacion_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Tabulacion.Checked)
            { _Mtd_ProcesarFileSeparadores(); }
        }

        private void _Rb_Coma_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Coma.Checked)
            { _Mtd_ProcesarFileSeparadores(); }
        }

        private void _Rb_Punto_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_PuntoYComa.Checked)
            { _Mtd_ProcesarFileSeparadores(); }
        }

        private void _Rb_Espacio_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Espacio.Checked)
            { _Mtd_ProcesarFileSeparadores(); }
        }

        private void _Rb_Otro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Otro.Checked)
            { _Txt_Otro.Enabled = true; _Mtd_ProcesarFileSeparadores(); }
            else
            { _Txt_Otro.Enabled = false; _Txt_Otro.Text = ""; }
        }

        private void _Txt_Otro_TextChanged(object sender, EventArgs e)
        {
            if (_Rb_Otro.Checked)
            {
                _Mtd_ProcesarFileSeparadores();
            }
        }
        private void _Mtd_Ini()
        {
            _RTxt_Vista.Text = "";
            _Mtd_DesCheckear(_Grb_CaracteresSeparadores);
            _RTxt_Vista.Controls.Clear();
            _Mtd_InicializarGrid();
        }
        private void _Bt_Ini_Click(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _RTxt_Vista.Enabled = false;
            _Rb_Caracteres.Checked = false;
            _Rb_PorUsuario.Checked = false;
            _Grb_CaracteresSeparadores.Enabled = false;
            _Bt_Aceptar.Enabled = false;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void _Dg_Carga_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
           // _Bt_Aceptar.Enabled = _Dg_Carga.ColumnCount > 0; 
        }

        private void Frm_VistaArchivo_Load(object sender, EventArgs e)
        {
            _Mtd_Sorted();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void _Txt_LineaInicioDatos_TextChanged(object sender, EventArgs e)
        {
            if (!new CLASES._Cls_Varios_Metodos(true)._Mtd_IsNumeric(_Txt_LineaInicioDatos.Text))
            {
                _Txt_LineaInicioDatos.Text = "1";
            }
            _Mtd_ProcesarFileSeparadores();
        }

        private void _Txt_LineaInicioDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }

        private void _Txt_LineaInicioDatos_Enter(object sender, EventArgs e)
        {
            _Txt_LineaInicioDatos.SelectAll();
        }

    }
}
