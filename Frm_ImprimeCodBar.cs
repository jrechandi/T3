using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using C1.Win.C1Chart;
namespace T3
{
    public partial class Frm_ImprimeCodBar : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ImprimeCodBar()
        {
            InitializeComponent();
            string _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where 5<4";
            _Mtd_Actualizar(_Str_Cadena);
            _Mtd_Cargar_Proveedor();
            //_Mtd_Cargar_Marca();
        }
        private void _Mtd_Cargar_Proveedor()
        {
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "'))";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname " +
"FROM TGRUPPROM INNER JOIN " +
"TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete " +
"WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0)";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor,string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname " +
"FROM TSUBGRUPOM INNER JOIN " +
"TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
"TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete " +
"WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "')";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TMARCASM.cmarca, TMARCASM.cname " +
            "FROM TMARCASM INNER JOIN " +
            "TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca " +
            "WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "')";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
        }

        private void _Mtd_Buscar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Codbar = "";
            if (_Rb_Si.Checked)
            { _Str_Codbar = " and ccodcorrugado!='0'"; }
            else
            { _Str_Codbar = " and ccodcorrugado='0'"; }
            string _Str_Cadena = "";
            bool _Bol_Entrada = false;
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "' and csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'" + _Str_Codbar; _Bol_Entrada = true; }
            else if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'" + _Str_Codbar; _Bol_Entrada = true; }
            else if (_Cmb_Subgrupo.SelectedIndex < 1 & _Cmb_Grupo.SelectedIndex < 1 & _Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'" + _Str_Codbar; _Bol_Entrada = true; }
            if (_Bol_Entrada)
            {
                if (_Cmb_Marca.SelectedIndex >0)
                { _Str_Cadena = _Str_Cadena + " and cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            }
            else
            {
                if (_Cmb_Marca.SelectedIndex > 0)
                { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'" + _Str_Codbar; _Bol_Entrada = true; }
            }
            if (_Bol_Entrada)
            {
                if (_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and cprodregular is not null"; }
                else if (!_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and cprodregular is null"; }
                else if (_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and 0=0"; }
                if (_Txt_Buscar.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                if (_Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                if (_Txt_CodigoIn.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                if (_Rb_Activo_Bus.Checked)
                { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                else if (_Rb_Inactivo_Bus.Checked)
                { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
            }
            else
            {
                _Bol_Entrada = false;
                if ( _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cprodregular is not null" + _Str_Codbar; _Bol_Entrada = true; }
                else if (!_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cprodregular is null" + _Str_Codbar; _Bol_Entrada = true; }
                else if ( _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where 0=0" + _Str_Codbar; _Bol_Entrada = true; }
                if (_Bol_Entrada)
                {
                    if (_Txt_Buscar.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                    if (_Txt_CodigoEs.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                    if (_Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                    if (_Rb_Activo_Bus.Checked)
                    { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                    else if (_Rb_Inactivo_Bus.Checked)
                    { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
                }
                else
                {
                    _Bol_Entrada = false;
                    if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')" + _Str_Codbar; _Bol_Entrada = true; }
                    if (_Bol_Entrada)
                    {
                        if (_Rb_Activo_Bus.Checked)
                        { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                        else if (_Rb_Inactivo_Bus.Checked)
                        { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
                    }
                    else
                    {
                        if (_Rb_Activo_Bus.Checked)
                        { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cactivate='1'" + _Str_Codbar; }
                        else if (_Rb_Inactivo_Bus.Checked)
                        { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where cactivate='0'" + _Str_Codbar; }
                        else if (_Rbt_Todos_Bus.Checked)
                        { _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where 0=0" + _Str_Codbar; }
                    }
                }
            }
            if (_Str_Cadena.Length > 0)
            {
                _Mtd_Actualizar(_Str_Cadena);
                Cursor = Cursors.Default;
                if (_Dg_Grid.Rows.Count == 0)
                { MessageBox.Show("La consulta no devolvio ningún registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Debe especificar algún criterio de busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void _Mtd_Actualizar(string _P_Str_Cadena)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //___________________________________
        }
        private void _Mtd_MensajesError(int _P_Int_Row, int _P_Int_Col, DataGridView _Dg_Grid2)
        {
            try
            {
                if (_P_Int_Col == 3)
                {
                    if (!_Mtd_IsNumeric(_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value) | _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().IndexOf(".") >= 0 | _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().IndexOf(",") == 0)
                    {
                        if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(".") >= 0)
                        {
                            MessageBox.Show("No debe Introducir puntos (.)");
                        }
                        else if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == 0)
                        {
                            MessageBox.Show("No debe Introducir comas (,)");
                        }
                        else if (!_Mtd_IsNumeric(_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value))
                        {
                            MessageBox.Show("No debe Introducir valores alfanuméricos");
                        }
                        _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                    }
                    else
                    {
                        if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().Length - 1)
                        {
                            _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString() + "0";
                        }
                        else if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") > 0 & _P_Int_Col != 3)
                        {
                            string _Str_Cadena = _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().Substring(_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().IndexOf(",") + 1);
                            if (_Str_Cadena.IndexOf(",") >= 0)
                            {
                                MessageBox.Show("No debe Introducir mas de una coma (,)");
                                _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                            }
                        }
                        else if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") >= 0 & _P_Int_Col == 3)
                        {
                            MessageBox.Show("No debe Introducir decimales");
                            _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                        }
                    }
                }
            }
            catch { }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        bool _Bol_Sw = false;
        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Cmb_Grupo.Enabled = true;
                _Chbox_Proveedores.Checked = true;
            }
            else
            {
                _Cmb_Grupo.DataSource = null;
                _Cmb_Grupo.Enabled = false;
                _Chbox_Grupos.Checked = false;
            }
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Chbox_Grupos.Checked = true;
                _Cmb_Subgrupo.Enabled = true;
            }
            else
            {
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Marca.DataSource = null;
                _Chbox_Grupos.Checked = false;
                _Cmb_Subgrupo.Enabled = false;
                _Chbox_Subgrupos.Checked = false;
                _Cmb_Marca.Enabled = false;
                _Chbox_Marcas.Checked = false;
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Mtd_Buscar();
        }

        private void _Chbox_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Proveedores.Checked)
            { _Cmb_Proveedor.Enabled = true; }
            else
            {
                _Cmb_Proveedor.Enabled = false;
                if (_Cmb_Proveedor.DataSource != null)
                {
                    _Cmb_Proveedor.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Proveedor.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Grupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Grupos.Checked)
            { _Cmb_Grupo.Enabled = true; }
            else
            { 
                _Cmb_Grupo.Enabled = false;
                if (_Cmb_Grupo.DataSource != null)
                {
                    _Cmb_Grupo.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Grupo.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Subgrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Subgrupos.Checked)
            { _Cmb_Subgrupo.Enabled = true; }
            else
            { 
                _Cmb_Subgrupo.Enabled = false;
                if (_Cmb_Subgrupo.DataSource != null)
                {
                    _Cmb_Subgrupo.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Subgrupo.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Marcas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Marcas.Checked)
            { _Cmb_Marca.Enabled = true; }
            else
            { 
                _Cmb_Marca.Enabled = false;
                if (_Cmb_Marca.DataSource != null)
                {
                    _Cmb_Marca.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Marca.SelectedIndex = -1;
                }
            }
        }

        private void _Mtd_Restablecer()
        {
            _Txt_Buscar.Text = "";
            _Txt_CodigoEs.Text = "";
            _Txt_CodigoIn.Text = "";
            _Rb_No.Checked = true;
            _Rb_Activo_Bus.Checked = true;
            _Chbox_Promocional.Checked = false;
            _Chbox_Regular.Checked = false;
            _Chbox_Proveedores.Checked = false;
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
            string _Str_Cadena = "Select cproducto,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Checks from tproducto INNER JOIN TMARCASM ON tproducto.cmarca=TMARCASM.cmarca where 5<4";
            _Mtd_Actualizar(_Str_Cadena);
            _Cmb_Proveedor.Enabled = true;
        }
        private bool _Mtd_Seleccionar()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells[3].Value == null)
                { }
                else if (_Dg_Row.Cells[3].Value.ToString().Trim() == "1")
                { Cursor = Cursors.Default; return true; }
            }
            Cursor = Cursors.Default;
            return false;
        }
        private bool _Mtd_Cantidad()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[3].Value == null)
                { }
                else if (_Dg_Row.Cells[3].Value.ToString().Trim() != "0")
                { Cursor = Cursors.Default; return true; }
            }
            Cursor = Cursors.Default;
            return false;
        }
        private string _Mtd_Imp_Selec()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "0=0 and (";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells[3].Value == null)
                { }
                else if (_Dg_Row.Cells[3].Value.ToString().Trim() == "1")
                {
                    _Str_Cadena = _Str_Cadena + "cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' or ";
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 3);
            Cursor = Cursors.Default;
            return _Str_Cadena + ")";
        }
        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { 
                _Chbox_Subgrupos.Checked = true;
                _Cmb_Marca.Enabled = true;
            }
        }

        private void _Cmb_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Marca.SelectedIndex > 0)
            { 
                _Chbox_Marcas.Checked = true;
            }
            else
            { 
                _Chbox_Marcas.Checked = false;
            }
        }

        ///////////////////////////////////////////////
        private void _Mtd_Texto_Formato(TextBox _P_Txt_Txt)
        {
            _P_Txt_Txt.TextChanged += new EventHandler(_P_Txt_Txt_TextChanged);
        }

        void _P_Txt_Txt_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length > 0)
            {
                ((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Trim()).ToString("F2");
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _Mtd_MensajesError(e.RowIndex, e.ColumnIndex, _Dg_Grid2);
        }

        private void _Lnk_Seleccionar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Mtd_Seleccionar())
            {
                string _Str_Cadena = "Select cproducto as Producto,ccodcorrugado as Corrugado,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as Descripción,'1' as Cantidad FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where " + _Mtd_Imp_Selec();
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = _Ds.Tables[0];
                _Dg_Grid2.Columns[0].ReadOnly = true;
                _Dg_Grid2.Columns[1].ReadOnly = true;
                _Dg_Grid2.Columns[2].ReadOnly = true;
                _Dg_Grid2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Tb_Tab.SelectedIndex = 1;
            }
            else
            { MessageBox.Show("No se han seleccionado productos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }


        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_Mtd_Seleccionar() & _Tb_Tab.SelectedIndex==1)
            { _Tb_Tab.SelectedIndex = 0; }
        }

        private void _Lnk_Imprimir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Mtd_Cantidad())
            {
                PrintDialog _Prin = new PrintDialog();
                if (_Prin.ShowDialog() == DialogResult.OK)
                {
                    _Ctrl_P.printDocument1.PrinterSettings.PrinterName = _Prin.PrinterSettings.PrinterName;
                    Cursor = Cursors.WaitCursor;
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
                    {
                        _Ctrl_P._Titulo = _Dg_Row.Cells[2].Value.ToString().Trim().ToUpper();
                        if (_Rb_Si.Checked)
                        { _Ctrl_P._CodigoBarra = _Dg_Row.Cells[1].Value.ToString().Trim().ToUpper(); }
                        else
                        { _Ctrl_P._CodigoBarra = _Dg_Row.Cells[0].Value.ToString().Trim().ToUpper(); }
                        for (int _Int_j = 0; _Int_j < Convert.ToInt32(_Dg_Row.Cells[3].Value.ToString().Trim().ToUpper()); _Int_j++)
                        {
                            _Ctrl_P.printDocument1.Print();
                        }
                    }
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Debe especificar cantidades", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_ImprimeCodBar_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Cmb_Proveedor.SelectedIndexChanged -= new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "'))";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            _Cmb_Proveedor.SelectedIndexChanged += new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Cmb_Grupo.SelectedIndexChanged -= new EventHandler(_Cmb_Grupo_SelectedIndexChanged);
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString());
                _Cmb_Grupo.SelectedIndexChanged += new EventHandler(_Cmb_Grupo_SelectedIndexChanged);
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cmb_Subgrupo_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Cmb_Subgrupo.SelectedIndexChanged -= new EventHandler(_Cmb_Subgrupo_SelectedIndexChanged);
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                _Cmb_Subgrupo.SelectedIndexChanged += new EventHandler(_Cmb_Subgrupo_SelectedIndexChanged);
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cmb_Marca_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Cmb_Marca.SelectedIndexChanged -= new EventHandler(_Cmb_Marca_SelectedIndexChanged);
                _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                _Cmb_Marca.SelectedIndexChanged += new EventHandler(_Cmb_Marca_SelectedIndexChanged);
                this.Cursor = Cursors.Default;
            }
        }
    }
}