using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_CuotaCobranza : Form
    {
        string _Str_FrmFindSql = "";
        string[] _Str_FindCampos = new string[2];
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
        public Frm_CuotaCobranza()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarFiltro()
        {
            int _Int_AnoMin = 0;
            string _Str_Sql = "SELECT MIN(canocalend) FROM TCALENDVTA WHERE cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Int_AnoMin = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    _Int_AnoMin = 2000;
                }
            }
            _Cb_Ano.Items.Clear();
            _Cb_Ano.Items.Add("...");
            for (int _I = _Int_AnoMin; _I <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year; _I++)
            {
                _Cb_Ano.Items.Add(_I);
            }
            _Cb_Ano.SelectedIndex = 0;
            _myUtilidad._Mtd_CargarMesesCombo(_Cb_Mes);
            _Mtd_CargarZonas();
        }
        private void _Mtd_CargarZonas()
        {
            string _Str_Sql = "SELECT c_zona,(rtrim(c_zona) + ': ' + rtrim(cname)) as descrip FROM TZONAVENTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 ORDER BY c_zona";
            _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVta, _Str_Sql);
        }
        public void _Mtd_Ini()
        {
            _Mtd_Sorted(_Dg_Grid);
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FrmFindSql, _Str_FindCampos, "Cuota Cobranza", _Tsm_Menu, _Dg_Grid, false, "ORDER BY czona");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            for (int _I = 0; _I < _Dg_Grid.Rows.Count; _I++)
            {
                if (Convert.ToString(_Dg_Grid[3,_I].Value) == "1")
                {
                    _Dg_Grid.Rows[_I].DefaultCellStyle.BackColor = Color.Khaki;
                }
            }
            
        }
        private void _Mtd_Sorted(DataGridView _Pr_Dg)
        {
            for (int _Int_i = 0; _Int_i < _Pr_Dg.Columns.Count; _Int_i++)
            {
                _Pr_Dg.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_FindDetalle()
        {
            if (_Cb_Ano.SelectedIndex < 1 || _Cb_Mes.SelectedIndex < 1 || _Cb_ZonaVta.SelectedIndex < 1)
            {
                MessageBox.Show("Seleccione todas las opciones de filtro por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                object[] _Str_RowNew = new object[5];
                string _Str_Sql = "SELECT cgrupo,rtrim(cgruponame),ccuotacaja,cpromesant,proyecvent FROM VST_TCUOTACOBCAL WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (_Cb_Ano.SelectedIndex > 0)
                {
                    _Str_Sql = _Str_Sql + " AND canocuota=" + _Cb_Ano.Text;
                }
                if (_Cb_Mes.SelectedIndex > 0)
                {
                    _Str_Sql = _Str_Sql + " AND cmescuota=" + _Cb_Mes.SelectedValue.ToString();
                }
                if (_Cb_ZonaVta.SelectedIndex > 0)
                {
                    _Str_Sql = _Str_Sql + " AND czona='" + _Cb_ZonaVta.SelectedValue.ToString() + "'";
                }
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Dg_Detalle.Rows.Clear();
                foreach (DataRow _DataR in _Ds.Tables[0].Rows)
                {
                    Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                    _Dg_Detalle.Rows.Add(_Str_RowNew);
                }
                _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Txt_CuotaCob.Text = _Mtd_CargarCuotaCob(Convert.ToInt32(_Cb_Ano.Text), Convert.ToInt32(_Cb_Mes.SelectedValue.ToString()), _Cb_ZonaVta.SelectedValue.ToString()).ToString("#,##0.00");
                this.Cursor = Cursors.Default;
            }
            
        }
        private double _Mtd_CargarCuotaCob(int _Pr_Int_Ano, int _Pr_Int_Mes, string _Pr_Str_Zona)
        {
            double _Dbl_R = 0;
            string _Str_Sql = "SELECT cuotacobra FROM TCUOTACOB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canocuota=" + _Pr_Int_Ano + " AND cmescuota=" + _Pr_Int_Mes + " AND czona='" + _Pr_Str_Zona + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_R;
        }
        private void _Mtd_GuardarCuotaCob(int _Pr_Int_Ano, int _Pr_Int_Mes, string _Pr_Str_Zona)
        {
            double _Dbl_CuotaCob = 0;
            string _Str_Sql = "";
            if (_Txt_CuotaCob.Text != "")
            {
                _Dbl_CuotaCob = Convert.ToDouble(_Txt_CuotaCob.Text);
            }
            if (_Dbl_CuotaCob > 0)
            {
                if (_Pr_Int_Ano == CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year && _Pr_Int_Mes == CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month)
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CUOTA_COBRO_MODI"))
                    {
                        _Str_Sql = "UPDATE TCUOTACOB SET cuotacobra=" + _Dbl_CuotaCob.ToString().Replace(",", ".") + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND czona='" + _Pr_Str_Zona + "' and canocuota=" + _Pr_Int_Ano + " and cmescuota=" + _Pr_Int_Mes;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene permiso para este realizar esta operación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se puede modificar la cuota de cobranza.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese la cuota de cobranza.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        private void Frm_CuotaCobranza_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Tsm_Menu[0] = new ToolStripMenuItem("Zona");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Str_FindCampos[0] = "czona";
            _Str_FindCampos[1] = "czonaname";
            _Str_FrmFindSql = "Select rtrim(czona) as [Zona],rtrim(czonaname) as [Descripción],rtrim(cgruponame) as [Grupo],cestatuscal,canocuota,cmescuota from VST_TCUOTACOBCAL WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_CargarFiltro();
        }

        private void _Bt_FindDet_Click(object sender, EventArgs e)
        {
            _Mtd_FindDetalle();
        }

        private void _Bt_SaveCuotaCob_Click(object sender, EventArgs e)
        {
            if (_Cb_Ano.SelectedIndex < 1 || _Cb_Mes.SelectedIndex < 1 || _Cb_ZonaVta.SelectedIndex < 1)
            {
                MessageBox.Show("Seleccione todas las opciones de filtro por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_GuardarCuotaCob(Convert.ToInt32(_Cb_Ano.Text), Convert.ToInt32(_Cb_Mes.SelectedValue.ToString()), _Cb_ZonaVta.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Detalle.Rows.Clear();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_CuotaCob.Text = "";
        }

        private void _Cb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Detalle.Rows.Clear();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_CuotaCob.Text = "";
        }

        private void _Cb_ZonaVta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Detalle.Rows.Clear();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_CuotaCob.Text = "";
        }

        private void _Cb_ZonaVta_DropDown(object sender, EventArgs e)
        {
            _Cb_ZonaVta.SelectedIndexChanged -= new EventHandler(_Cb_ZonaVta_SelectedIndexChanged);
            _Mtd_CargarZonas();
            _Cb_ZonaVta.SelectedIndexChanged += new EventHandler(_Cb_ZonaVta_SelectedIndexChanged);
        }

        private void _Txt_CuotaCob_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_CuotaCob, e, 15, 2);
        }

        private void _Txt_CuotaCob_Enter(object sender, EventArgs e)
        {
            if (_Txt_CuotaCob.Text != "")
            {
                _Txt_CuotaCob.Text = _Txt_CuotaCob.Text.Replace(".", "");
            }
        }

        private void _Txt_CuotaCob_Leave(object sender, EventArgs e)
        {
            if (_Txt_CuotaCob.Text != "")
            {
                _Txt_CuotaCob.Text = Convert.ToDouble(_Txt_CuotaCob.Text).ToString("#,##0.00");
            }
        }
    }
}