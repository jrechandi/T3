using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
namespace T3
{
    public partial class Frm_Inf_ValorizaInventario : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_ValorizaInventario()
        {
            InitializeComponent();
            _Rb_Resumen.Checked = true;
            _Rb_Detalle.Checked = false;
            this.Cursor = Cursors.WaitCursor;
            _Mtd_MesAnoCierreContable();
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_MesAnoCierreContable()
        {
            try
            {
                string _Str_SentenciaSQL = "SELECT DISTINCT CONVERT(DATETIME,'01'+'/'+CONVERT(VARCHAR,cmescont)+'/'+CONVERT(VARCHAR,canocont)) AS EEE,CONVERT(VARCHAR,canocont)+'-'+CONVERT(VARCHAR,cmescont) AS CVALOR FROM THISTINVENT WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' ORDER BY EEE DESC ";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _myUtilidad._Mtd_CargarCombo(_Cb_MesAnoCierre, _Ds_DataSet, "CVALOR", "CVALOR");
            }
            catch
            {
            }
        }
        private void _Mtd_CargarProveedores()
        {
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) ORDER BY TPROVEEDOR.c_nomb_abreviado";
            _myUtilidad._Mtd_CargarCombo(_Cb_ProveedorFind, _Str_Cadena);
        }

//        private void _Mtd_CargarMarca(string _P_Str_Proveedor, string _P_Str_Grupo)
//        {
//            string _Str_Cadena = "SELECT TMARCASM.cmarca, TMARCASM.cname " +
//"FROM TMARCASM INNER JOIN " +
//"TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca " +
//"WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') ORDER BY TMARCAS.cname";
//            _myUtilidad._Mtd_CargarCombo(_Cb_MarcaFind, _Str_Cadena);
//        }

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
            string _Str_Sql="";
            if (!_Chk_MalEstado.Checked)
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    _Str_Sql = "SELECT DISTINCT VST_VALORIZADOINVENTARIO.* FROM VST_VALORIZADOINVENTARIO INNER JOIN TGRUPPROVEE ON VST_VALORIZADOINVENTARIO.cproveedor =TGRUPPROVEE.cproveedor  WHERE TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TGRUPPROVEE.CDELETE='0'";
                }
                else
                {
                    string _Str_Mes = "";
                    string _Str_Ano = "";
                    string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                    _Str_Mes = _Str_MesAno[1];
                    _Str_Ano = _Str_MesAno[0];
                    _Str_Sql = "SELECT DISTINCT VST_PRODUCTOS_HIST_INVENT.* FROM VST_PRODUCTOS_HIST_INVENT WHERE VST_PRODUCTOS_HIST_INVENT.CCOMPANYPROV='" + Frm_Padre._Str_Comp + "' AND VST_PRODUCTOS_HIST_INVENT.CMESCONT='" + _Str_Mes + "'  AND VST_PRODUCTOS_HIST_INVENT.CANOCONT='" + _Str_Ano + "'";
                }
            }
            else
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    _Str_Sql = "SELECT DISTINCT " +
                            "VST_PRODUCTOS.cproveedor, c_nomb_comer, cgrupo, cgruponame, csku, " +
                             "cproducto, cpaleta, csector, carea, calmacen, " +
                             "csubgrupo, cprodregular, ccodfabrica, ccodcorrugado, " +
                             "ccodproveedor, cactivate, clinea, cfechaini, cnamef, " +
                             "cnamei, cinformacion, cpresentacion, cimagen, " +
                             "cunidadma1, ccontenidoma1, cunidadma2, ccontenidoma2, " +
                             "cunidad2, cunidadme, ccontenidome, caltura, cancho, " +
                             "cprofundidad, calturac, canchoc, cprofundidadc, " +
                             "cpesounid1, cpesounid2, cu1xpaleta, cu1xcamada, " +
                             "cimpuesto1, ctax1, cname, cpercent, ctax2, " +
                             "ctax3, ctax4, ctax5, ccomision, ccodebar, " +
                             "ccostobruto_u1, ccostoneto_u1, ccostobruto_u2, ccostoneto_u2, " +
                             "ccostpromu1, ccostpromu2, clistprecio1, clistprecio2, " +
                             "clistprecio3, clistprecio4, clistprecio5, cpreciosuge, " +
                             "0 + cexismmeu1 as cexisrealu1, 0 + cexismmeu2 as cexisrealu2, cexiscomu1, cexiscomu2, " +
                             "cexisllegar1, cexisllegar2, VST_PRODUCTOS.ccompany, cexisdesp1, " +
                             "cexisdesp2, cstockmi, cstockmax, cstockped, cstockpro, " +
                             "cpreciomin, ctcomision, ccodbarsku, cultcosto, c_edit_1, " +
                             "c_edit_2, czona, cmarca, ccodebaru, ccodunidad, " +
                             "c_nuevo_win, ccodeold, valido_, cdescnetonac, " +
                             "cdesclinnac1, cdesclinnac2, cdesclinnac3, cdesclinnac4, " +
                             "cfecexisreal, cfecexiscomp, cfecexistllegar, cfecultcomp_u1, " +
                             "cexisultcomp_u1, cfecpromvta3m, cpromvta3m_u1, cfecpromcomp3m, " +
                             "cpromcomp3m, ccompdelmes, cfecvtapmes, cfeccompmes, " +
                             "cvtadelmes, cfecdiarotultcomp, cdiarotultcomp, cfecinvmin, " +
                             "cinvmin, cfecdifcontrinv, cdifcontrinv, cinvmax, " +
                             "cfecinvmax, cnecinvactual, cfecinvactual, cnecvactual, " +
                             "cfecnecvactual, cfecinvsuge, cinvsugerido, cpedidoprome, " +
                             "cpuntoreorden, cbackorder, cestratificacion, ccombogene, " +
                             "ccombocomp, cpreciolista, cdescondp1, cdescondp2, " +
                             "cdescondp3, cdescondp4, cdescondp5, cexismmeu1, " +
                             "cexismmeu2, cpresentaciondescrip, costoneto_uni_new, costoneto_uni, " +
                             "produc_descrip2, precioList1Caja, precioList1Und, porcUtilidadList1CB," +
                             "porcUtilidadList1CN, precioList2Caja, precioList2Und, porcUtilidadList2CB, " +
                             "porcUtilidadList2CN, precioList3Caja, precioList3Und, porcUtilidadList3CB, " +
                             "porcUtilidadList3CN, produc_descrip, produc_descrip_2, cventaund2, " +
                             "cnamefc, ccompanyprov, csubgruponame " +
        "FROM VST_PRODUCTOS INNER JOIN TGRUPPROVEE ON VST_PRODUCTOS.cproveedor = TGRUPPROVEE.cproveedor WHERE TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TGRUPPROVEE.CDELETE='0'";
                }
                else
                {
                    string _Str_Mes = "";
                    string _Str_Ano = "";
                    string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                    _Str_Mes = _Str_MesAno[1];
                    _Str_Ano = _Str_MesAno[0];
                    _Str_Sql = "SELECT DISTINCT " +
                   "VST_PRODUCTOS_HIST_INVENT.cproveedor, VST_PRODUCTOS_HIST_INVENT.c_nomb_comer, VST_PRODUCTOS_HIST_INVENT.cgrupo, VST_PRODUCTOS_HIST_INVENT.cgruponame, VST_PRODUCTOS_HIST_INVENT.csku, " +
                             "VST_PRODUCTOS_HIST_INVENT.cproducto, VST_PRODUCTOS_HIST_INVENT.cpaleta, VST_PRODUCTOS_HIST_INVENT.csector, VST_PRODUCTOS_HIST_INVENT.carea, VST_PRODUCTOS_HIST_INVENT.calmacen," +
                            " VST_PRODUCTOS_HIST_INVENT.csubgrupo, VST_PRODUCTOS_HIST_INVENT.cprodregular, VST_PRODUCTOS_HIST_INVENT.ccodfabrica, VST_PRODUCTOS_HIST_INVENT.ccodcorrugado, " +
                             "VST_PRODUCTOS_HIST_INVENT.ccodproveedor, VST_PRODUCTOS_HIST_INVENT.cactivate, VST_PRODUCTOS_HIST_INVENT.clinea, VST_PRODUCTOS_HIST_INVENT.cfechaini, VST_PRODUCTOS_HIST_INVENT.cnamef, " +
                             "VST_PRODUCTOS_HIST_INVENT.cnamei, VST_PRODUCTOS_HIST_INVENT.cinformacion, VST_PRODUCTOS_HIST_INVENT.cpresentacion, VST_PRODUCTOS_HIST_INVENT.cimagen, " +
                             "VST_PRODUCTOS_HIST_INVENT.cunidadma1, VST_PRODUCTOS_HIST_INVENT.ccontenidoma1, VST_PRODUCTOS_HIST_INVENT.cunidadma2, VST_PRODUCTOS_HIST_INVENT.ccontenidoma2, " +
                             "VST_PRODUCTOS_HIST_INVENT.cunidad2, VST_PRODUCTOS_HIST_INVENT.cunidadme, VST_PRODUCTOS_HIST_INVENT.ccontenidome, VST_PRODUCTOS_HIST_INVENT.caltura, VST_PRODUCTOS_HIST_INVENT.cancho, " +
                             "VST_PRODUCTOS_HIST_INVENT.cprofundidad, VST_PRODUCTOS_HIST_INVENT.calturac, VST_PRODUCTOS_HIST_INVENT.canchoc, VST_PRODUCTOS_HIST_INVENT.cprofundidadc, " +
                             "VST_PRODUCTOS_HIST_INVENT.cpesounid1, VST_PRODUCTOS_HIST_INVENT.cpesounid2, VST_PRODUCTOS_HIST_INVENT.cu1xpaleta, VST_PRODUCTOS_HIST_INVENT.cu1xcamada, " +
                             "VST_PRODUCTOS_HIST_INVENT.cimpuesto1, VST_PRODUCTOS_HIST_INVENT.ctax1, VST_PRODUCTOS_HIST_INVENT.cname, VST_PRODUCTOS_HIST_INVENT.cpercent, VST_PRODUCTOS_HIST_INVENT.ctax2, " +
                             "VST_PRODUCTOS_HIST_INVENT.ctax3, VST_PRODUCTOS_HIST_INVENT.ctax4, VST_PRODUCTOS_HIST_INVENT.ctax5, VST_PRODUCTOS_HIST_INVENT.ccomision, VST_PRODUCTOS_HIST_INVENT.ccodebar, " +
                             "VST_PRODUCTOS_HIST_INVENT.ccostobruto_u1, VST_PRODUCTOS_HIST_INVENT.ccostoneto_u1, VST_PRODUCTOS_HIST_INVENT.ccostobruto_u2, VST_PRODUCTOS_HIST_INVENT.ccostoneto_u2, " +
                             "VST_PRODUCTOS_HIST_INVENT.ccostpromu1, VST_PRODUCTOS_HIST_INVENT.ccostpromu2, VST_PRODUCTOS_HIST_INVENT.clistprecio1, VST_PRODUCTOS_HIST_INVENT.clistprecio2, " +
                             "VST_PRODUCTOS_HIST_INVENT.clistprecio3, VST_PRODUCTOS_HIST_INVENT.clistprecio4, VST_PRODUCTOS_HIST_INVENT.clistprecio5, VST_PRODUCTOS_HIST_INVENT.cpreciosuge, " +
                             "0 + VST_PRODUCTOS_HIST_INVENT.cexismmeu1 as cexisrealu1, 0 + VST_PRODUCTOS_HIST_INVENT.cexismmeu2 as cexisrealu2, VST_PRODUCTOS_HIST_INVENT.cexiscomu1, VST_PRODUCTOS_HIST_INVENT.cexiscomu2, " +
                             "VST_PRODUCTOS_HIST_INVENT.cexisllegar1, VST_PRODUCTOS_HIST_INVENT.cexisllegar2, VST_PRODUCTOS_HIST_INVENT.ccompany, VST_PRODUCTOS_HIST_INVENT.cexisdesp1, " +
                             "VST_PRODUCTOS_HIST_INVENT.cexisdesp2, VST_PRODUCTOS_HIST_INVENT.cstockmi, VST_PRODUCTOS_HIST_INVENT.cstockmax, VST_PRODUCTOS_HIST_INVENT.cstockped, VST_PRODUCTOS_HIST_INVENT.cstockpro, " +
                             "VST_PRODUCTOS_HIST_INVENT.cpreciomin, VST_PRODUCTOS_HIST_INVENT.ctcomision, VST_PRODUCTOS_HIST_INVENT.ccodbarsku, VST_PRODUCTOS_HIST_INVENT.cultcosto, VST_PRODUCTOS_HIST_INVENT.c_edit_1, " +
                             "VST_PRODUCTOS_HIST_INVENT.c_edit_2, VST_PRODUCTOS_HIST_INVENT.czona, VST_PRODUCTOS_HIST_INVENT.cmarca, VST_PRODUCTOS_HIST_INVENT.ccodebaru, VST_PRODUCTOS_HIST_INVENT.ccodunidad, " +
                             "VST_PRODUCTOS_HIST_INVENT.c_nuevo_win, VST_PRODUCTOS_HIST_INVENT.ccodeold, VST_PRODUCTOS_HIST_INVENT.valido_, VST_PRODUCTOS_HIST_INVENT.cdescnetonac, " +
                             "VST_PRODUCTOS_HIST_INVENT.cdesclinnac1, VST_PRODUCTOS_HIST_INVENT.cdesclinnac2, VST_PRODUCTOS_HIST_INVENT.cdesclinnac3, VST_PRODUCTOS_HIST_INVENT.cdesclinnac4, " +
                             "VST_PRODUCTOS_HIST_INVENT.cfecexisreal, VST_PRODUCTOS_HIST_INVENT.cfecexiscomp, VST_PRODUCTOS_HIST_INVENT.cfecexistllegar, VST_PRODUCTOS_HIST_INVENT.cfecultcomp_u1, " +
                             "VST_PRODUCTOS_HIST_INVENT.cexisultcomp_u1, VST_PRODUCTOS_HIST_INVENT.cfecpromvta3m, VST_PRODUCTOS_HIST_INVENT.cpromvta3m_u1, VST_PRODUCTOS_HIST_INVENT.cfecpromcomp3m, " +
                             "VST_PRODUCTOS_HIST_INVENT.cpromcomp3m, VST_PRODUCTOS_HIST_INVENT.ccompdelmes, VST_PRODUCTOS_HIST_INVENT.cfecvtapmes, VST_PRODUCTOS_HIST_INVENT.cfeccompmes, " +
                             "VST_PRODUCTOS_HIST_INVENT.cvtadelmes, VST_PRODUCTOS_HIST_INVENT.cfecdiarotultcomp, VST_PRODUCTOS_HIST_INVENT.cdiarotultcomp, VST_PRODUCTOS_HIST_INVENT.cfecinvmin, " +
                             "VST_PRODUCTOS_HIST_INVENT.cinvmin, VST_PRODUCTOS_HIST_INVENT.cfecdifcontrinv, VST_PRODUCTOS_HIST_INVENT.cdifcontrinv, VST_PRODUCTOS_HIST_INVENT.cinvmax, " +
                             "VST_PRODUCTOS_HIST_INVENT.cfecinvmax, VST_PRODUCTOS_HIST_INVENT.cnecinvactual, VST_PRODUCTOS_HIST_INVENT.cfecinvactual, VST_PRODUCTOS_HIST_INVENT.cnecvactual, " +
                             "VST_PRODUCTOS_HIST_INVENT.cfecnecvactual, VST_PRODUCTOS_HIST_INVENT.cfecinvsuge, VST_PRODUCTOS_HIST_INVENT.cinvsugerido, VST_PRODUCTOS_HIST_INVENT.cpedidoprome, " +
                             "VST_PRODUCTOS_HIST_INVENT.cpuntoreorden, VST_PRODUCTOS_HIST_INVENT.cbackorder, VST_PRODUCTOS_HIST_INVENT.cestratificacion, VST_PRODUCTOS_HIST_INVENT.ccombogene, " +
                             "VST_PRODUCTOS_HIST_INVENT.ccombocomp, VST_PRODUCTOS_HIST_INVENT.cpreciolista, VST_PRODUCTOS_HIST_INVENT.cdescondp1, VST_PRODUCTOS_HIST_INVENT.cdescondp2, " +
                             "VST_PRODUCTOS_HIST_INVENT.cdescondp3, VST_PRODUCTOS_HIST_INVENT.cdescondp4, VST_PRODUCTOS_HIST_INVENT.cdescondp5, VST_PRODUCTOS_HIST_INVENT.cexismmeu1, " +
                             "VST_PRODUCTOS_HIST_INVENT.cexismmeu2, VST_PRODUCTOS_HIST_INVENT.cpresentaciondescrip, VST_PRODUCTOS_HIST_INVENT.costoneto_uni_new, VST_PRODUCTOS_HIST_INVENT.costoneto_uni, " +
                             "VST_PRODUCTOS_HIST_INVENT.produc_descrip2, VST_PRODUCTOS_HIST_INVENT.precioList1Caja, VST_PRODUCTOS_HIST_INVENT.precioList1Und, VST_PRODUCTOS_HIST_INVENT.porcUtilidadList1CB," +
                             "VST_PRODUCTOS_HIST_INVENT.porcUtilidadList1CN, VST_PRODUCTOS_HIST_INVENT.precioList2Caja, VST_PRODUCTOS_HIST_INVENT.precioList2Und, VST_PRODUCTOS_HIST_INVENT.porcUtilidadList2CB, " +
                             "VST_PRODUCTOS_HIST_INVENT.porcUtilidadList2CN, VST_PRODUCTOS_HIST_INVENT.precioList3Caja, VST_PRODUCTOS_HIST_INVENT.precioList3Und, VST_PRODUCTOS_HIST_INVENT.porcUtilidadList3CB, " +
                             "VST_PRODUCTOS_HIST_INVENT.porcUtilidadList3CN, VST_PRODUCTOS_HIST_INVENT.produc_descrip, VST_PRODUCTOS_HIST_INVENT.produc_descrip_2, VST_PRODUCTOS_HIST_INVENT.cventaund2, " +
                             "VST_PRODUCTOS_HIST_INVENT.cnamefc, VST_PRODUCTOS_HIST_INVENT.ccompanyprov, VST_PRODUCTOS_HIST_INVENT.csubgruponame " +
                             "FROM VST_PRODUCTOS_HIST_INVENT WHERE VST_PRODUCTOS_HIST_INVENT.CCOMPANYPROV='" + Frm_Padre._Str_Comp + "' AND VST_PRODUCTOS_HIST_INVENT.CMESCONT='" + _Str_Mes + "'  AND VST_PRODUCTOS_HIST_INVENT.CANOCONT='" + _Str_Ano + "'";
                }
            }
            if (_Chk_AllProductos.Checked)
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    _Str_Sql = _Str_Sql + " AND (cexisrealu1>-1 OR cexisrealu2>-1 OR cexismmeu1>-1 OR cexismmeu2>-1)";
                }
                else
                {
                    _Str_Sql = _Str_Sql + " AND (VST_PRODUCTOS_HIST_INVENT.cexisrealu1>-1 OR VST_PRODUCTOS_HIST_INVENT.cexisrealu2>-1 OR VST_PRODUCTOS_HIST_INVENT.cexismmeu1>-1 OR VST_PRODUCTOS_HIST_INVENT.cexismmeu2>-1)";
                }
            }
            else
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    _Str_Sql = _Str_Sql + " AND (cexisrealu1>0 OR cexisrealu2>0 OR cexismmeu1>0 OR cexismmeu2>0)";
                }
                else
                {
                    _Str_Sql = _Str_Sql + " AND (VST_PRODUCTOS_HIST_INVENT.cexisrealu1>0 OR VST_PRODUCTOS_HIST_INVENT.cexisrealu2>0 OR VST_PRODUCTOS_HIST_INVENT.cexismmeu1>0 OR VST_PRODUCTOS_HIST_INVENT.cexismmeu2>0)";
                }
            }
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    if (!_Chk_MalEstado.Checked)
                    {
                        _Str_Sql = _Str_Sql + " AND VST_VALORIZADOINVENTARIO.cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        _Str_Sql = _Str_Sql + " AND VST_PRODUCTOS.cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
                    }
                }
                else
                {
                    _Str_Sql = _Str_Sql + " AND VST_PRODUCTOS_HIST_INVENT.cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
                }
            }
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    _Str_Sql = _Str_Sql + " AND cgrupo='" + _Cb_GrupoFind.SelectedValue.ToString() + "'";
                }
                else
                {
                    _Str_Sql = _Str_Sql + " AND VST_PRODUCTOS_HIST_INVENT.cgrupo='" + _Cb_GrupoFind.SelectedValue.ToString() + "'";
                }
            }
            if (_Cb_SubGrupoFind.SelectedIndex > 0)
            {
                if (_Rbt_ReporteActual.Checked)
                {
                    _Str_Sql = _Str_Sql + " AND csubgrupo='" + _Cb_SubGrupoFind.SelectedValue.ToString() + "'";
                }
                else
                {
                    _Str_Sql = _Str_Sql + " AND VST_PRODUCTOS_HIST_INVENT.csubgrupo='" + _Cb_SubGrupoFind.SelectedValue.ToString() + "'";
                }
            }
            //if (_Cb_MarcaFind.SelectedIndex > 0)
            //{
            //    if (_Rbt_ReporteActual.Checked)
            //    {
            //        _Str_Sql = _Str_Sql + " AND cmarca='" + _Cb_MarcaFind.SelectedValue.ToString() + "'";
            //    }
            //    else
            //    {
            //        _Str_Sql = _Str_Sql + " AND VST_PRODUCTOS_HIST_INVENT.cmarca='" + _Cb_MarcaFind.SelectedValue.ToString() + "'";
            //    }
            //}
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Rb_Resumen.Checked)
                {
                    if (!_Chk_Imp.Checked)
                    {
                        dynamic _My_Reporte;
                        if (_Cb_Resumen.SelectedIndex == 0)
                            _My_Reporte = new T3.Report.rInventValorResProveedor();
                        else if (_Cb_Resumen.SelectedIndex == 1)
                            _My_Reporte = new T3.Report.rInventValorResGrupo();
                        else
                            _My_Reporte = new T3.Report.rInventValorResSubGrupo();
                        _My_Reporte.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        this._Rpv_Main.ReportSource = _My_Reporte;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        dynamic _My_Reporte;
                        if (_Cb_Resumen.SelectedIndex == 0)
                            _My_Reporte = new T3.Report.rInventValorResProveedorImp();
                        else if (_Cb_Resumen.SelectedIndex == 1)
                            _My_Reporte = new T3.Report.rInventValorResGrupoImp();
                        else
                            _My_Reporte = new T3.Report.rInventValorResSubGrupoImp();
                        _My_Reporte.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        this._Rpv_Main.ReportSource = _My_Reporte;
                        _Rpv_Main.RefreshReport();
                    }
                }
                else if (_Rb_Detalle.Checked)
                {
                    if (!_Chk_Imp.Checked)
                    {
                        T3.Report.rInventValor _My_Reporte = new T3.Report.rInventValor();   
                        _My_Reporte.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        this._Rpv_Main.ReportSource = _My_Reporte;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        T3.Report.rInventValorImp _My_Reporte = new T3.Report.rInventValorImp();
                        _My_Reporte.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        this._Rpv_Main.ReportSource = _My_Reporte;
                        _Rpv_Main.RefreshReport();
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Rpv_Main.ReportSource = null;
            }
        }


        private void _Rb_Resumen_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Resumen.Checked)
            {
                _Cb_Resumen.Enabled = true;
                _Cb_Detalle.SelectedIndex = -1;
                _Rpv_Main.ReportSource = null;
            }
            else
            {
                _Cb_Resumen.SelectedIndex = -1;
                _Cb_Resumen.Enabled = false;
            }
            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Rb_Detalle_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Detalle.Checked)
            {
                _Cb_Detalle.Enabled = true;
                _Cb_Resumen.SelectedIndex = -1;
                _Rpv_Main.ReportSource = null;
            }
            else
            {
                _Cb_Detalle.SelectedIndex = -1;
                _Cb_Detalle.Enabled = false;
            }
            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_Resumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Resumen.SelectedIndex == 0)
            {
                _Cb_ProveedorFind.Enabled = true;
                _Cb_GrupoFind.Enabled = false;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                //_Cb_MarcaFind.Enabled = false;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Resumen.SelectedIndex == 1)
            {
                _Cb_GrupoFind.Enabled = true;
                _Cb_ProveedorFind.Enabled = true;
                
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                //_Cb_MarcaFind.Enabled = false;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Resumen.SelectedIndex == 2)
            {
                _Cb_SubGrupoFind.Enabled = true;
                _Cb_GrupoFind.Enabled = true;
                _Cb_ProveedorFind.Enabled = true;

                //_Cb_MarcaFind.Enabled = false;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Resumen.SelectedIndex == 3)
            {
                //_Cb_MarcaFind.Enabled = true;
                _Cb_GrupoFind.Enabled = true;
                _Cb_ProveedorFind.Enabled = true;

                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
            }
            else
            {
                _Cb_GrupoFind.Enabled = false;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_ProveedorFind.Enabled = false;
                _Cb_ProveedorFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                //_Cb_MarcaFind.Enabled = false;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }

            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_Detalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Detalle.SelectedIndex == 0)
            {
                _Cb_GrupoFind.Enabled = true;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_ProveedorFind.Enabled = true;
                _Cb_ProveedorFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = true;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                //_Cb_MarcaFind.Enabled = true;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Detalle.SelectedIndex == 1)
            {
                _Cb_GrupoFind.Enabled = false;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_ProveedorFind.Enabled = false;
                _Cb_ProveedorFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                //_Cb_MarcaFind.Enabled = false;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }
            else
            {
                _Cb_GrupoFind.Enabled = false;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_ProveedorFind.Enabled = false;
                _Cb_ProveedorFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                //_Cb_MarcaFind.Enabled = false;
                //_Cb_MarcaFind.SelectedIndex = -1;
            }
            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
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

        //private void _Cb_MarcaFind_DropDown(object sender, EventArgs e)
        //{
        //    if (_Cb_GrupoFind.SelectedIndex > 0)
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        _Mtd_CargarMarca(_Cb_ProveedorFind.SelectedValue.ToString(), _Cb_GrupoFind.SelectedValue.ToString());
        //        this.Cursor = Cursors.Default;
        //    }
        //}

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            bool _Bol_ReporteCierreVal = false;
            if (_Rbt_ReporteCierre.Checked)
            {
                if (_Cb_MesAnoCierre.SelectedIndex > 0)
                {
                    _Bol_ReporteCierreVal = true;
                }
                else
                {
                    MessageBox.Show("Seleccione el mes y año contable para la consulta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                _Bol_ReporteCierreVal = true;
            }
            if (_Bol_ReporteCierreVal)
            {
                if (_Cb_Detalle.SelectedIndex > -1 || _Cb_Resumen.SelectedIndex > -1)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _Mtd_Busqueda();
                    // exportar solo disponible con versión detallada del reporte
                    _Bt_Exportar.Enabled = _Rb_Detalle.Checked;
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Seleccione el tipo de consulta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void _Cb_ProveedorFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cb_GrupoFind.SelectedIndex = -1;
            _Cb_SubGrupoFind.SelectedIndex = -1;
            //_Cb_MarcaFind.SelectedIndex = -1;

            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_GrupoFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cb_SubGrupoFind.SelectedIndex = -1;
            //_Cb_MarcaFind.SelectedIndex = -1;

            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        //private void _Cb_MarcaFind_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //  // deshabilita el boton de exportar
        //  _Bt_Exportar.Enabled = false;
        //}

        private void _Chk_Imp_CheckedChanged(object sender, EventArgs e)
        {
            _Rpv_Main.ReportSource = null;
          
          // deshabilita el boton de exportar
          _Bt_Exportar.Enabled = false;
        }

        private void _Chk_AllProductos_CheckedChanged(object sender, EventArgs e)
        {
            _Rpv_Main.ReportSource = null;
            
            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void Frm_Inf_ValorizaInventario_Load(object sender, EventArgs e)
        {
          _Bt_Exportar.Enabled = false;

        }

        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
             bool _Bol_ReporteCierreVal = false;
            if (_Rbt_ReporteCierre.Checked)
            {
                if (_Cb_MesAnoCierre.SelectedIndex > 0)
                {
                    _Bol_ReporteCierreVal = true;
                }
                else
                {
                    MessageBox.Show("Seleccione el mes y año contable para la consulta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                _Bol_ReporteCierreVal = true;
            }
            if (_Bol_ReporteCierreVal)
            {
                string _Str_Sql = "";
                string _Str_Mes = "";
                string _Str_Ano = "";

                if (_Rb_Detalle.Checked) // detallado
                {
                    if (_Rbt_ReporteActual.Checked)
                    {
                        if (!_Chk_Imp.Checked) // sin impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidproductod as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion, TUNIMEDI.cname as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),(ccostoneto_u1*cexisrealu1) + (costoneto_uni_new * cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_VALORIZADOINVENTARIO LEFT JOIN TUNIMEDI ON VST_VALORIZADOINVENTARIO.cunidadme = TUNIMEDI.cunidadmed WHERE VST_VALORIZADOINVENTARIO.CCOMPANYPROV='" + Frm_Padre._Str_Comp + "' ";
                        }
                        else // con impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidproductod as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion, TUNIMEDI.cname as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),((ccostoneto_u1+(ccostoneto_u1*cpercent/100))*cexisrealu1) + ((costoneto_uni_new+(costoneto_uni_new*cpercent/100))*cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_VALORIZADOINVENTARIO LEFT JOIN TUNIMEDI ON VST_VALORIZADOINVENTARIO.cunidadme = TUNIMEDI.cunidadmed WHERE VST_VALORIZADOINVENTARIO.CCOMPANYPROV='" + Frm_Padre._Str_Comp + "' ";
                        }
                    }
                    else
                    {
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        if (!_Chk_Imp.Checked) // sin impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidproductod as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion,CNAMEMED as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),(ccostoneto_u1*cexisrealu1) + (costoneto_uni_new * cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_PRODUCTOS_HIST_INVENT WHERE VST_PRODUCTOS_HIST_INVENT.CCOMPANYPROV='" + Frm_Padre._Str_Comp + "' ";
                        }
                        else // con impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidproductod as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion,CNAMEMED as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),((ccostoneto_u1+(ccostoneto_u1*cpercent/100))*cexisrealu1) + ((costoneto_uni_new+(costoneto_uni_new*cpercent/100))*cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_PRODUCTOS_HIST_INVENT WHERE VST_PRODUCTOS_HIST_INVENT.CCOMPANYPROV='" + Frm_Padre._Str_Comp + "' ";
                        }
                    }
                }

                _Str_Sql += "AND ";
                if (_Rbt_ReporteCierre.Checked)
                {
                    _Str_Sql += " VST_PRODUCTOS_HIST_INVENT.CMESCONT='" + _Str_Mes + "'  AND VST_PRODUCTOS_HIST_INVENT.CANOCONT='" + _Str_Ano + "' AND ";
                }
                if (_Chk_AllProductos.Checked) _Str_Sql = _Str_Sql + " (cexisrealu1>-1 OR cexisrealu2>-1)"; else _Str_Sql = _Str_Sql + " (cexisrealu1>0 OR cexisrealu2>0)";
                if (_Cb_ProveedorFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
                if (_Cb_GrupoFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND cgrupo='" + _Cb_GrupoFind.SelectedValue.ToString() + "'";
                if (_Cb_SubGrupoFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND csubgrupo='" + _Cb_SubGrupoFind.SelectedValue.ToString() + "'";
                //if (_Cb_MarcaFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND cmarca='" + _Cb_MarcaFind.SelectedValue.ToString() + "'";

                _Str_Sql += " ORDER BY cproveedor, cproducto ";


                Cursor = Cursors.WaitCursor;
                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                Cursor = Cursors.Default;
                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        if (_Sfd_1.ShowDialog() == DialogResult.OK)
                        {
                            Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Consultar));
                            _Thr_Thread.Start();
                            while (!_Thr_Thread.IsAlive) ;
                            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                            _Frm_Form.ShowDialog(this);
                            _Frm_Form.Dispose();
                        }
                    }
                    catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }
        DataSet _Ds_Temp;
        private void _Mtd_Consultar()
        {
            Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
            _MyExcel._Mtd_DatasetToExcel(_Ds_Temp.Tables[0], _Sfd_1.FileName, "VALORIZACION_INV " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            _MyExcel = null;
        }
        private void _Cb_SubGrupoFind_SelectedIndexChanged(object sender, EventArgs e)
        {
          // deshabilita el boton de exportar
          _Bt_Exportar.Enabled = false;
        }

        private void _Chk_MalEstado_CheckedChanged(object sender, EventArgs e)
        {
            _Rpv_Main.ReportSource = null;

            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_MesAnoCierre_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_MesAnoCierreContable();
            this.Cursor = Cursors.Default;
        }

        private void _Rbt_ReporteActual_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_ReporteActual.Checked)
            {
                _Cb_MesAnoCierre.Enabled = false;
                _Cb_MesAnoCierre.SelectedIndex = 0;
            }
        }

        private void _Rbt_ReporteCierre_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_ReporteCierre.Checked)
            {
                _Cb_MesAnoCierre.Enabled = true;
                _Cb_MesAnoCierre.SelectedIndex = 0;
            }
        }
    }
}