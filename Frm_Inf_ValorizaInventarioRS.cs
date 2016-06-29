using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_ValorizaInventarioRS : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        public Frm_Inf_ValorizaInventarioRS()
        {
            InitializeComponent();

            this._Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            this._Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ValorizadoInventario";

            this._Rb_Resumen.Checked = true;
            this._Rb_Detalle.Checked = false;

            this.Cursor = Cursors.WaitCursor;
            this._Mtd_MesAnoCierreContable();
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

        private void _Mtd_CargarMarca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TMARCASM.cmarca, TMARCASM.cname FROM TMARCASM INNER JOIN TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') ORDER BY TMARCAS.cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_MarcaFind, _Str_Cadena);
        }

        private void _Mtd_CargarGrupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname FROM TGRUPPROM INNER JOIN TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_GrupoFind, _Str_Cadena);
        }

        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname FROM TSUBGRUPOM INNER JOIN TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_SubGrupoFind, _Str_Cadena);
        }

        private void _Rb_Resumen_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Resumen.Checked)
            {
                _Cb_Resumen.Enabled = true;
                _Cb_Detalle.SelectedIndex = -1;
                //_Rpv_Main.ReportSource = null;
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
                //_Rpv_Main.ReportSource = null;
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
                _Cb_MarcaFind.Enabled = false;
                _Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Resumen.SelectedIndex == 1)
            {
                _Cb_GrupoFind.Enabled = true;
                _Cb_ProveedorFind.Enabled = true;
                
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                _Cb_MarcaFind.Enabled = false;
                _Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Resumen.SelectedIndex == 2)
            {
                _Cb_SubGrupoFind.Enabled = true;
                _Cb_GrupoFind.Enabled = true;
                _Cb_ProveedorFind.Enabled = true;

                _Cb_MarcaFind.Enabled = false;
                _Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Resumen.SelectedIndex == 3)
            {
                _Cb_MarcaFind.Enabled = true;
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
                _Cb_MarcaFind.Enabled = false;
                _Cb_MarcaFind.SelectedIndex = -1;
            }

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
                _Cb_MarcaFind.Enabled = true;
                _Cb_MarcaFind.SelectedIndex = -1;
            }
            else if (_Cb_Detalle.SelectedIndex == 1)
            {
                _Cb_GrupoFind.Enabled = false;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_ProveedorFind.Enabled = false;
                _Cb_ProveedorFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                _Cb_MarcaFind.Enabled = false;
                _Cb_MarcaFind.SelectedIndex = -1;
            }
            else
            {
                _Cb_GrupoFind.Enabled = false;
                _Cb_GrupoFind.SelectedIndex = -1;
                _Cb_ProveedorFind.Enabled = false;
                _Cb_ProveedorFind.SelectedIndex = -1;
                _Cb_SubGrupoFind.Enabled = false;
                _Cb_SubGrupoFind.SelectedIndex = -1;
                _Cb_MarcaFind.Enabled = false;
                _Cb_MarcaFind.SelectedIndex = -1;
            }

            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_ProveedorFind_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this._Mtd_CargarProveedores();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_GrupoFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Mtd_CargarGrupo(_Cb_ProveedorFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_SubGrupoFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Mtd_Cargar_Subgrupo(_Cb_ProveedorFind.SelectedValue.ToString(), _Cb_GrupoFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void _Cb_MarcaFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_GrupoFind.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Mtd_CargarMarca(_Cb_ProveedorFind.SelectedValue.ToString(), _Cb_GrupoFind.SelectedValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

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
                    
                    //_Mtd_Busqueda();

                    this._Mtd_MostrarReporte();

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
            _Cb_MarcaFind.SelectedIndex = -1;

            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_GrupoFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cb_SubGrupoFind.SelectedIndex = -1;
            _Cb_MarcaFind.SelectedIndex = -1;

            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void _Cb_MarcaFind_SelectedIndexChanged(object sender, EventArgs e)
        {
          // deshabilita el boton de exportar
          _Bt_Exportar.Enabled = false;
        }

        private void _Chk_Imp_CheckedChanged(object sender, EventArgs e)
        {
            //_Rpv_Main.ReportSource = null;
          
          // deshabilita el boton de exportar
          _Bt_Exportar.Enabled = false;
        }

        private void _Chk_AllProductos_CheckedChanged(object sender, EventArgs e)
        {
            //_Rpv_Main.ReportSource = null;
            
            // deshabilita el boton de exportar
            _Bt_Exportar.Enabled = false;
        }

        private void Frm_Inf_ValorizaInventarioRS_Load(object sender, EventArgs e)
        {
            this._Bt_Exportar.Enabled = false;
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
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidnotrecepc as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion, TUNIMEDI.cname as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),(ccostoneto_u1*cexisrealu1) + (costoneto_uni_new * cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_COSTOUTILIDADPRODUCTO LEFT JOIN TUNIMEDI ON VST_COSTOUTILIDADPRODUCTO.cunidadme = TUNIMEDI.cunidadmed ";
                        }
                        else // con impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidnotrecepc as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion, TUNIMEDI.cname as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),((ccostoneto_u1+(ccostoneto_u1*cpercent/100))*cexisrealu1) + ((costoneto_uni_new+(costoneto_uni_new*cpercent/100))*cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_COSTOUTILIDADPRODUCTO LEFT JOIN TUNIMEDI ON VST_COSTOUTILIDADPRODUCTO.cunidadme = TUNIMEDI.cunidadmed ";
                        }
                    }
                    else
                    {
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        if (!_Chk_Imp.Checked) // sin impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidnotrecepc as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion,CNAMEMED as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),(ccostoneto_u1*cexisrealu1) + (costoneto_uni_new * cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_PRODUCTOS_HIST_INVENT ";
                        }
                        else // con impuesto
                        {
                            _Str_Sql += "SELECT cproveedor as Proveedor, cproducto as Codigo, ccodcorrugado as Corrugado,cidnotrecepc as [N° Lote],cprecioventamax as PMV, produc_descrip as Descripcion, produc_descrip_2 as Presentacion,CNAMEMED as 'Unidad de medida', cexisrealu1 as 'Caja Exist.', cexisrealu2 as 'Unid. exist', CONVERT(NUMERIC(18,2),ccostoneto_u1) as 'Costo neto Caj.', CONVERT(NUMERIC(18,2),ccostoneto_u2) as 'Costo Neto Uni.', CONVERT(NUMERIC(18,2),((ccostoneto_u1+(ccostoneto_u1*cpercent/100))*cexisrealu1) + ((costoneto_uni_new+(costoneto_uni_new*cpercent/100))*cexisrealu2)) as Total ";
                            _Str_Sql += "FROM VST_PRODUCTOS_HIST_INVENT ";
                        }
                    }
                }

                _Str_Sql += "WHERE ";
                if (_Rbt_ReporteCierre.Checked)
                {
                    _Str_Sql += " VST_PRODUCTOS_HIST_INVENT.CMESCONT='" + _Str_Mes + "'  AND VST_PRODUCTOS_HIST_INVENT.CANOCONT='" + _Str_Ano + "' AND ";
                }
                if (_Chk_AllProductos.Checked) _Str_Sql = _Str_Sql + " (cexisrealu1>-1 OR cexisrealu2>-1)"; else _Str_Sql = _Str_Sql + " (cexisrealu1>0 OR cexisrealu2>0)";
                if (_Cb_ProveedorFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
                if (_Cb_GrupoFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND cgrupo='" + _Cb_GrupoFind.SelectedValue.ToString() + "'";
                if (_Cb_SubGrupoFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND csubgrupo='" + _Cb_SubGrupoFind.SelectedValue.ToString() + "'";
                if (_Cb_MarcaFind.SelectedIndex > 0) _Str_Sql = _Str_Sql + " AND cmarca='" + _Cb_MarcaFind.SelectedValue.ToString() + "'";

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
            //_Rpv_Main.ReportSource = null;

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
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        /// <summary>
        /// Muestra el reporte utilizando el visor de Reporting Services.
        /// </summary>
        private void _Mtd_MostrarReporte()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

            string[] _Str_MesAno = this._Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
            
            ReportParameter[] _Obj_Parametros = new ReportParameter[14];

            _Obj_Parametros[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Obj_Parametros[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());

            if (this._Cb_ProveedorFind.SelectedIndex > 0)
            {
                _Obj_Parametros[2] = new ReportParameter("CPROVEEDOR", this._Cb_ProveedorFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[2] = new ReportParameter("CPROVEEDOR", "NULL");
            }

            if (this._Cb_GrupoFind.SelectedIndex > 0)
            {
                _Obj_Parametros[3] = new ReportParameter("CGRUPO", this._Cb_GrupoFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[3] = new ReportParameter("CGRUPO", "NULL");
            }

            if (this._Cb_SubGrupoFind.SelectedIndex > 0)
            {
                _Obj_Parametros[4] = new ReportParameter("CSUBGRUPO", this._Cb_SubGrupoFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[4] = new ReportParameter("CSUBGRUPO", "NULL");
            }

            if (this._Cb_MarcaFind.SelectedIndex > 0)
            {
                _Obj_Parametros[5] = new ReportParameter("CMARCA", this._Cb_MarcaFind.SelectedValue.ToString());
            }
            else
            {
                _Obj_Parametros[5] = new ReportParameter("CMARCA", "NULL");
            }

            _Obj_Parametros[6] = new ReportParameter("CACTUAL", this._Rbt_ReporteActual.Checked.ToString());

            if (this._Rbt_ReporteActual.Checked == true)
            {                
                _Obj_Parametros[7] = new ReportParameter("CMES", "0");
                _Obj_Parametros[8] = new ReportParameter("CANO", "0");
            }
            else
            {
                _Obj_Parametros[7] = new ReportParameter("CMES", _Str_MesAno[1]);
                _Obj_Parametros[8] = new ReportParameter("CANO", _Str_MesAno[0]);
            }

            _Obj_Parametros[9] = new ReportParameter("CTODOSLOSPRODUCTOS", this._Chk_AllProductos.Checked.ToString());
            _Obj_Parametros[10] = new ReportParameter("CMALESTADO", this._Chk_MalEstado.Checked.ToString());
            _Obj_Parametros[11] = new ReportParameter("CIMPUESTO", this._Chk_Imp.Checked.ToString());
            _Obj_Parametros[12] = new ReportParameter("CRESUMIDO", this._Chk_Resumido.Checked.ToString());
            _Obj_Parametros[13] = new ReportParameter("CCOMPROMETIDO", this._Chk_Comprometido.Checked.ToString());

            this._Rpt_Report.ServerReport.SetParameters(_Obj_Parametros);
            this._Rpt_Report.ServerReport.Refresh();
            this._Rpt_Report.RefreshReport();
        }
    }
}