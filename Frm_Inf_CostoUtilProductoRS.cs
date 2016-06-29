using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_Inf_CostoUtilProductoRS : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        
        public Frm_Inf_CostoUtilProductoRS()
        {
            InitializeComponent();

            this._Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            this._Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_CostoUtilidadProducto";
        }

        private void _Mtd_CargarProveedores()
        {
            string _Str_SQL;

            _Str_SQL = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado";
            _Str_SQL += " FROM TPROVEEDOR";
            _Str_SQL += " LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor";
            _Str_SQL += " WHERE ISNULL(TPROVEEDOR.cdelete,0)='0'";
            _Str_SQL += " AND ISNULL(TGRUPPROVEE.cdelete,0)='0'";
            _Str_SQL += " AND TPROVEEDOR.c_activo='1'";
            _Str_SQL += " AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "'))";
            _Str_SQL += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            this._myUtilidad._Mtd_CargarCombo(_Cb_ProveedorFind, _Str_SQL);
        }        

        private void _Mtd_CargarGrupo(string _P_Str_Proveedor)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname";
            _Str_SQL += " FROM TGRUPPROM";
            _Str_SQL += "  INNER JOIN TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop";
            _Str_SQL += " AND TGRUPPROM.cdelete = TGRUPPROD.cdelete ";
            _Str_SQL +=  "WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "')";
            _Str_SQL  += " AND (TGRUPPROM.cdelete = 0) ORDER BY cname";

            this._myUtilidad._Mtd_CargarCombo(_Cb_GrupoFind, _Str_SQL);
        }

        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_SQL;
                
            _Str_SQL = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname ";
            _Str_SQL += " FROM TSUBGRUPOM";
            _Str_SQL += "  INNER JOIN TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup";
            _Str_SQL += " AND TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete ";
            _Str_SQL += " WHERE (TSUBGRUPOM.cdelete = 0)";
            _Str_SQL += " AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "')";
            _Str_SQL += " AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "')";
            _Str_SQL += " ORDER BY cname";

            this._myUtilidad._Mtd_CargarCombo(_Cb_SubGrupoFind, _Str_SQL);
        }

        private void _Mtd_CargarMarca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT TMARCASM.cmarca, TMARCASM.cname";
            _Str_SQL += " FROM TMARCASM";
            _Str_SQL += " INNER JOIN TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca";
            _Str_SQL +=  " WHERE (TMARCASM.cdelete = 0)";
            _Str_SQL += " AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "')";
            _Str_SQL += " AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "')";
            _Str_SQL += " ORDER BY TMARCASM.cname";

            this._myUtilidad._Mtd_CargarCombo(_Cb_MarcaFind, _Str_SQL);
        }

        private void _Mtd_MostrarReporte()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

            ReportParameter[] _Obj_Parametros = new ReportParameter[5];

            _Obj_Parametros[0] = new ReportParameter("CCOMPANYPROV", Frm_Padre._Str_Comp);

            if (this._Cb_ProveedorFind.SelectedIndex > 0)
            {
                _Obj_Parametros[1] = new ReportParameter("CPROVEEDOR", this._Cb_ProveedorFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[1] = new ReportParameter("CPROVEEDOR", "NULL");
            }

            if (this._Cb_GrupoFind.SelectedIndex > 0)
            {
                _Obj_Parametros[2] = new ReportParameter("CGRUPO", this._Cb_GrupoFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[2] = new ReportParameter("CGRUPO", "NULL");
            }

            if (this._Cb_SubGrupoFind.SelectedIndex > 0)
            {
                _Obj_Parametros[3] = new ReportParameter("CSUBGRUPO", this._Cb_SubGrupoFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[3] = new ReportParameter("CSUBGRUPO", "NULL");
            }

            if (this._Cb_MarcaFind.SelectedIndex > 0)
            {
                _Obj_Parametros[4] = new ReportParameter("CMARCA", this._Cb_MarcaFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[4] = new ReportParameter("CMARCA", "NULL");
            }

            this._Rpt_Report.ServerReport.SetParameters(_Obj_Parametros);
            this._Rpt_Report.ServerReport.Refresh();
            this._Rpt_Report.RefreshReport();
        }

        private void _Cb_ProveedorFind_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this._Mtd_CargarProveedores();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_GrupoFind_DropDown(object sender, EventArgs e)
        {
            if (this._Cb_ProveedorFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Mtd_CargarGrupo(this._Cb_ProveedorFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_SubGrupoFind_DropDown(object sender, EventArgs e)
        {
            if (this._Cb_GrupoFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Mtd_Cargar_Subgrupo(this._Cb_ProveedorFind.SelectedValue.ToString(), this._Cb_GrupoFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_MarcaFind_DropDown(object sender, EventArgs e)
        {
            if (this._Cb_GrupoFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Mtd_CargarMarca(this._Cb_ProveedorFind.SelectedValue.ToString(), this._Cb_GrupoFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_ProveedorFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Cb_GrupoFind.SelectedIndex = -1;
            this._Cb_SubGrupoFind.SelectedIndex = -1;
            this._Cb_MarcaFind.SelectedIndex = -1;

            if (this._Cb_ProveedorFind.SelectedIndex > 0)
            {
                this._Cb_GrupoFind.Enabled = true;
            }
            else
            {
                this._Cb_GrupoFind.Enabled = false;
            }
        }

        private void _Cb_GrupoFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Cb_SubGrupoFind.SelectedIndex = -1;
            this._Cb_MarcaFind.SelectedIndex = -1;

            if (this._Cb_GrupoFind.SelectedIndex > 0)
            {
                this._Cb_MarcaFind.Enabled = true;
                this._Cb_SubGrupoFind.Enabled = true;
            }
            else
            {
                this._Cb_MarcaFind.Enabled = false;
                this._Cb_SubGrupoFind.Enabled = false;
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this._Mtd_MostrarReporte();
            this.Cursor = Cursors.Default;
        }
    }
}