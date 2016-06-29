using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace T3
{
    public partial class Frm_Inf_CostoUtilProducto : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_CostoUtilProducto()
        {
            InitializeComponent();
        }

        private void _Mtd_CargarProveedores()
        {
            //string _Str_Cadena = "SELECT cproveedor,c_nomb_abreviado FROM TPROVEEDOR WHERE (cglobal='1' and cdelete='0' and c_activo=1) ORDER BY c_nomb_abreviado";
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) ORDER BY TPROVEEDOR.c_nomb_abreviado";
            _myUtilidad._Mtd_CargarCombo(_Cb_ProveedorFind, _Str_Cadena);
        }

        private void _Mtd_CargarMarca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TMARCASM.cmarca, TMARCASM.cname " +
"FROM TMARCASM INNER JOIN " +
"TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca " +
"WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') ORDER BY TMARCASM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_MarcaFind, _Str_Cadena);
        }

        private void _Mtd_CargarGrupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname " +
"FROM TGRUPPROM INNER JOIN " +
"TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete " +
"WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_GrupoFind, _Str_Cadena);
        }

        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname " +
"FROM TSUBGRUPOM INNER JOIN " +
"TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
"TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete " +
"WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_SubGrupoFind, _Str_Cadena);
        }

        private void _Mtd_Busqueda()
        {
            string _Str_Sql = "SELECT CNAMEFC AS produc_descrip,* FROM VST_COSTOUTILIDADPRODUCTO WHERE CCOMPANYPROV='" + Frm_Padre._Str_Comp + "'";
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
            }
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND cgrupo='" + _Cb_GrupoFind.SelectedValue.ToString() + "'";
            }
            if (_Cb_SubGrupoFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND csubgrupo='" + _Cb_SubGrupoFind.SelectedValue.ToString() + "'";
            }
            if (_Cb_MarcaFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND cmarca='" + _Cb_MarcaFind.SelectedValue.ToString() + "'";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                T3.Report.rValorCostoUtilidad _My_Reporte = new T3.Report.rValorCostoUtilidad();
                object datas = _Ds.Tables[0];
                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(
                    "SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp +
                    "'").Tables[0].Rows[0][0].ToString();
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Rpv_Main.ReportSource = null;
            }
        }

        private void _Cb_ProveedorFind_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarProveedores();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_GrupoFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_CargarGrupo(_Cb_ProveedorFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_SubGrupoFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Cargar_Subgrupo(_Cb_ProveedorFind.SelectedValue.ToString(), _Cb_GrupoFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_MarcaFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_CargarMarca(_Cb_ProveedorFind.SelectedValue.ToString(), _Cb_GrupoFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_ProveedorFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cb_GrupoFind.SelectedIndex = -1;
            _Cb_SubGrupoFind.SelectedIndex = -1;
            _Cb_MarcaFind.SelectedIndex = -1;
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
                _Cb_GrupoFind.Enabled = true;
            }
            else
            {
                _Cb_GrupoFind.Enabled = false;
            }
        }

        private void _Cb_GrupoFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cb_SubGrupoFind.SelectedIndex = -1;
            _Cb_MarcaFind.SelectedIndex = -1;
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                _Cb_MarcaFind.Enabled = true;
                _Cb_SubGrupoFind.Enabled = true;
            }
            else
            {
                _Cb_MarcaFind.Enabled = false;
                _Cb_SubGrupoFind.Enabled = false;
            }

        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            this.Cursor = Cursors.Default;
        }
    }
}