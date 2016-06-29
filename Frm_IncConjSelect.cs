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
    public partial class Frm_IncConjSelect : Form
    {
        TextBox _Txt_Producto;
        string _Str_GrupoInc = "";
        public Frm_IncConjSelect()
        {
            InitializeComponent();
        }
        public Frm_IncConjSelect(string _P_Str_GrupoInc, TextBox _P_Txt_Producto)
        {
            InitializeComponent();
            _Str_GrupoInc = _P_Str_GrupoInc;
            _Txt_Producto = _P_Txt_Producto;
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Conjunto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TINCMARCAFOCODD.cconjunto";
            _Str_Campos[1] = "cconjuntodesc";
            string _Str_Cadena = "SELECT DISTINCT TINCMARCAFOCODD.cconjunto AS Conjunto, TINCMARCAFOCOD.cconjuntodesc AS Descripción " +
            "FROM TGRUPPROVEE INNER JOIN " +
            "TGRUPOIV ON TGRUPPROVEE.cgrupovta = TGRUPOIV.cgrupovta AND " +
            "TGRUPPROVEE.ccompany = TGRUPOIV.ccompany INNER JOIN " +
            "VST_PRODUCTOS_A ON TGRUPPROVEE.cproveedor = VST_PRODUCTOS_A.cproveedor AND " +
            "TGRUPOIV.ccompany = VST_PRODUCTOS_A.companyprov INNER JOIN " +
            "TINCMARCAFOCODD ON VST_PRODUCTOS_A.cproducto = TINCMARCAFOCODD.cproducto INNER JOIN " +
            "TINCMARCAFOCOD ON TGRUPOIV.cgroupcomp = TINCMARCAFOCOD.cgroupcomp AND " +
            "TGRUPOIV.ccompany = TINCMARCAFOCOD.ccompany AND TINCMARCAFOCODD.cconjunto = TINCMARCAFOCOD.cconjunto " +
            "WHERE (NOT EXISTS (SELECT cproveedor FROM TFILTROREGIONALP " +
            "WHERE (VST_PRODUCTOS_A.cproveedor = cproveedor) AND (VST_PRODUCTOS_A.cproducto = cproducto) AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cdelete = '0'))) AND (TGRUPOIV.cidgrupincentivar = '" + _Str_GrupoInc + "') and VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY TINCMARCAFOCODD.cconjunto";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Conjuntos", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
            Cursor = Cursors.Default;
        }
        private void Frm_IncConjSelect_Load(object sender, EventArgs e)
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

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "SELECT DISTINCT TINCMARCAFOCODD.cproducto " +
                "FROM TGRUPPROVEE INNER JOIN " +
                "TGRUPOIV ON TGRUPPROVEE.cgrupovta = TGRUPOIV.cgrupovta AND " +
                "TGRUPPROVEE.ccompany = TGRUPOIV.ccompany INNER JOIN " +
                "VST_PRODUCTOS_A ON TGRUPPROVEE.cproveedor = VST_PRODUCTOS_A.cproveedor AND " +
                "TGRUPOIV.ccompany = VST_PRODUCTOS_A.companyprov INNER JOIN " +
                "TINCMARCAFOCODD ON VST_PRODUCTOS_A.cproducto = TINCMARCAFOCODD.cproducto INNER JOIN " +
                "TINCMARCAFOCOD ON TGRUPOIV.cgroupcomp = TINCMARCAFOCOD.cgroupcomp AND " +
                "TGRUPOIV.ccompany = TINCMARCAFOCOD.ccompany AND TINCMARCAFOCODD.cconjunto = TINCMARCAFOCOD.cconjunto " +
                "WHERE (NOT EXISTS (SELECT cproveedor FROM TFILTROREGIONALP " +
                "WHERE (VST_PRODUCTOS_A.cproveedor = cproveedor) AND (VST_PRODUCTOS_A.cproducto = cproducto) AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cdelete = '0'))) AND (TGRUPOIV.cidgrupincentivar = '" + _Str_GrupoInc + "') AND VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' AND TINCMARCAFOCOD.cconjunto='" + Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Conjunto"].Value).Trim() + "' ORDER BY TINCMARCAFOCODD.cproducto";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Str_Cadena = "";
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Cadena += _Row[0].ToString().Trim() + ",";
                }
                _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 1);
                ((Frm_IncConjunto)this.Owner)._Mtd_Restablecer();
                _Txt_Producto.Text = _Str_Cadena;
                ((Frm_IncConjunto)this.Owner)._Mtd_Buscar();
                Cursor = Cursors.Default;
                this.Close();
            }
        }
    }
}
