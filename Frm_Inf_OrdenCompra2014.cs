using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.Controles;
using T3.CLASES;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing;
using clslibraryconssa;

namespace T3
{
    public partial class Frm_Inf_OrdenCompra2014 : Form
    {
        #region Atributos

        _Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        _Cls_Varios_Metodos _myUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_OrdenCompra2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCompuesto,
                Nombre = "cproveedor",
                TituloFiltrarPor = "POR PROVEEDOR",
                TituloEtiqueta = "Proveedor:",
                TituloGrid = "Proveedor:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                Nombre = "cfecha",
                TituloFiltrarPor = "POR FECHA"
            });

            _Ctrl_Multifiltro.SeleccionarTodos = true;
            _Ctrl_Multifiltro.cargarCompuesto(cargarProveedores());
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCompuesto);
        }

        /// <summary>Carga los datos del proveedor.</summary>
        /// <returns>Conjunto de resultados con la información del proveedor.</returns>
        private DataSet cargarProveedores()
        {
            string sSQL;

            sSQL = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor, VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado";
            sSQL += " from VST_PRODUCTOS_A where not exists(select * from TFILTROREGIONALP where VST_PRODUCTOS_A.cproveedor = TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto";
            sSQL += " and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0')";
            sSQL += " and VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' and VST_PRODUCTOS_A.cdelete=0 order by VST_PRODUCTOS_A.c_nomb_abreviado;";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Cargar las ordenes de compra.</summary>
        /// <param name="pProveedor">Código del proveedor.</param>
        /// <param name="pFechaDesde">Fecha desde.</param>
        /// <param name="pFechaHasta">fecha hasta.</param>
        private void cargarOrdenes(string pProveedor, string pFechaDesde, string pFechaHasta)
        {
            string sSQL;

            object[] oDatos = new object[7];

            _Dtg_Ordenes.Rows.Clear();

            _Chk_Todos.Checked = false;

            sSQL = "select TORDENCOMPM.ccompany, TORDENCOMPM.cnumoc, TORDENCOMPM.cproveedor, TPROVEEDOR.c_nomb_fiscal, (TORDENCOMPM.cproveedor + ' - ' + TPROVEEDOR.c_nomb_fiscal) as cprovname,";
            sSQL += " convert(varchar, convert(datetime, TORDENCOMPM.cfechaoc, 101), 103) as cfechaoc, TORDENCOMPM.cdelete from TPROVEEDOR";
            sSQL += " inner join TORDENCOMPM on TPROVEEDOR.cproveedor = TORDENCOMPM.cproveedor";
            sSQL += " where TORDENCOMPM.cdelete=0 and TORDENCOMPM.ccompany='" + Frm_Padre._Str_Comp + "'";
            sSQL += " and (convert(datetime, convert(varchar(255), TORDENCOMPM.cfechaoc, 103)) between convert(datetime, '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(pFechaDesde)) + "', 103) and convert(datetime, '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(pFechaHasta)) + "', 103))";
            sSQL += " and (" + pProveedor + ") order by TORDENCOMPM.cproveedor,TORDENCOMPM.cnumoc;";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            foreach (DataRow oFila in oResultado.Tables[0].Rows)
            {
                oDatos[0] = null;
                oDatos[1] = oFila["cnumoc"].ToString();
                oDatos[2] = Convert.ToDateTime(oFila["cfechaoc"]).ToShortDateString();
                oDatos[3] = oFila["cprovname"].ToString().Trim();

                sSQL = "select * from vst_tabordencompra";
                sSQL += " where (ccompany = '" + Frm_Padre._Str_Comp + "') and cnumoc='" + oFila["cnumoc"].ToString() + "' and (cocaprovee=1) and (centroinvent=0) and (ccerrada=0) and (cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'));";

                DataSet oResultadoA = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                if (oResultadoA.Tables[0].Rows.Count > 0)
                {
                    oDatos[4] = true;
                }
                else
                {
                    oDatos[4] = false;
                }

                sSQL = "select * from TRECEPCIONDFM inner join TNOTARECEPC on TRECEPCIONDFM.cgroupcomp = TNOTARECEPC.cgroupcomp and TRECEPCIONDFM.cidrecepcion = TNOTARECEPC.cidrecepcion and TRECEPCIONDFM.cnfacturapro = TNOTARECEPC.cnumdocu inner join TPROVEEDOR on TRECEPCIONDFM.cproveedor = TPROVEEDOR.cproveedor";
                sSQL += " where (TRECEPCIONDFM.cnotarecepcion = '1') and ccopiaoc='" + oFila["cnumoc"].ToString() + "' and TRECEPCIONDFM.cproveedor='" + oFila["cproveedor"].ToString() + "' and TNOTARECEPC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TNOTARECEPC.ccompany='" + Frm_Padre._Str_Comp + "';";
                
                DataSet oResultadoB = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                if (oResultadoB.Tables[0].Rows.Count > 0)
                {
                    oDatos[5] = true;
                }
                else
                {
                    oDatos[5] = false;
                }

                oDatos[6] = oFila["cproveedor"].ToString();

                _Dtg_Ordenes.Rows.Add(oDatos);
            }

            foreach (DataGridViewColumn oColumna in _Dtg_Ordenes.Columns)
            {
                if (oColumna.Index > 0) oColumna.ReadOnly = true;
            }

            _Dtg_Ordenes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            _Dtg_Ordenes.AllowUserToResizeRows = false;
            _Dtg_Ordenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dtg_Ordenes.AllowUserToResizeColumns = false;
            _Dtg_Ordenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _Dtg_Ordenes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            _Dtg_Ordenes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dtg_Ordenes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>Este método reinicia el visor de los reportes, al parecer hay un problema con VS2008 y se necesita hacer esto para mostrarlo.</summary>
        private void reiniciarVisorReportes()
        {
            _Rpt_VisorReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            _Rpt_VisorReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            _Rpt_VisorReportes.DocumentMapCollapsed = true;
            _Rpt_VisorReportes.Location = new System.Drawing.Point(0, 39);
            _Rpt_VisorReportes.Name = "_Rpt_VisorReportes";
            _Rpt_VisorReportes.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            _Rpt_VisorReportes.ShowParameterPrompts = false;
            _Rpt_VisorReportes.Size = new System.Drawing.Size(1087, 450);
            _Rpt_VisorReportes.TabIndex = 172;
            _Rpt_VisorReportes.ProcessingMode = ProcessingMode.Local;

            this.Controls.RemoveByKey("_Rpt_VisorReportes");
            this.Controls.Add(_Rpt_VisorReportes);
        }

        /// <summary>Muestar las notas de crédito de la empresa al proveedor.</summary>
        /// <param name="pCompañia">Compañía.</param>ç
        /// <param name="pOrdenes">Órdenes de compra.</param>
        private void mostrarOrdenes(string pCompañia, string pOrdenes)
        {
            string sSQL;

            sSQL = "select cnumoc, cfechaoc, c_nomb_comer, cproducto, cnamef, cpresentacion, ccantunidadma1, ccantunidadma2, ccostobruto_u1, ccostoneto_u1, cdescuento1, cdescuento2, ctotcostosimp, ctotsimp, ctotimp from VST_OC";
            sSQL += " where ccompany='" + pCompañia + "' and (" + pOrdenes + ");";

            DataSet oDatos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "';");

            ReportParameter[] oParametros = new ReportParameter[2];

            oParametros[0] = new ReportParameter("CNOMCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());

            reiniciarVisorReportes();

            _Rpt_VisorReportes.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_Inf_OrdenCompra.rdlc";
            _Rpt_VisorReportes.LocalReport.DataSources.Clear();
            _Rpt_VisorReportes.LocalReport.SetParameters(oParametros);
            _Rpt_VisorReportes.LocalReport.DataSources.Add(new ReportDataSource("DataSource2", (DataTable)oDatos.Tables[0]));
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
            _Rpt_VisorReportes.BringToFront();

            _Pnl_Barra.SendToBack();

            _Ctrl_Multifiltro.BringToFront();

            UpdateZOrder();
        }

        #endregion

        #region Eventos

        private void _Btn_FiltrarPor_Click(object sender, EventArgs e)
        {
            _Btn_FiltrarPor.Enabled = false;
            _Chk_Todos.Enabled = false;
            _Dtg_Ordenes.Enabled = false;
            _Btn_Imprimir.Enabled = false;

            _Ctrl_Multifiltro.Visible = true;
        }

        private void _Ctrl_Multifiltro_Cerrando()
        {
            _Btn_FiltrarPor.Enabled = true;
        }

        private void Frm_Inf_OrdenCompra2014_Resize(object sender, EventArgs e)
        {
            int iIzquierda = (ClientSize.Width - _Ctrl_Multifiltro.Width) / 2;
            int iAlto = (ClientSize.Height - _Ctrl_Multifiltro.Height) / 2;
            int iDerecho = (_Pnl_Barra.ClientRectangle.Width - 40);

            _Ctrl_Multifiltro.Location = new Point(iIzquierda, iAlto);

            _Img_Logo.Left = iDerecho;
            _Img_Logo.Top -= 1;

            _Btn_Imprimir.Top += 1;
            _Btn_Imprimir.Left = (iDerecho - 75);

            _Btn_Regresar.Top += 1;
            _Btn_Regresar.Left = _Btn_Imprimir.Left;

            _Chk_Todos.Top += 2;
        }

        private void _Ctrl_Multifiltro_FiltroSeleccionado(FiltroCombo pFiltro, List<FiltroGrid> pFiltrosGrid)
        {
            switch (pFiltro.Nombre)
            {
                case "cproveedor":

                    _Ctrl_Multifiltro.cargarCompuesto(cargarProveedores());
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCompuesto);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sProveedor = "", sDesde = "nulo", sHasta = "nulo";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                switch (oFiltro.Nombre)
                {
                    case "cproveedor":
                        
                        sProveedor += (sProveedor == "") ? "TORDENCOMPM.cproveedor='" + oFiltro.Valor.Trim() + "'" : " or TORDENCOMPM.cproveedor='" + oFiltro.Valor.Trim() + "'";

                        break;

                    case "cdesde":

                        sDesde = oFiltro.Valor.Trim();

                        break;

                    case "chasta":
                        
                        sHasta = oFiltro.Valor.Trim();

                        break;
                }
            }

            cargarOrdenes(sProveedor, sDesde, sHasta);

            _Btn_FiltrarPor.Enabled = true;
            _Chk_Todos.Enabled = true;
            _Dtg_Ordenes.Enabled = true;
            _Btn_Imprimir.Enabled = true;
        }

        private void _Chk_Todos_Click(object sender, EventArgs e)
        {
            if (_Chk_Todos.Checked)
            {
                foreach (DataGridViewRow oFila in _Dtg_Ordenes.Rows)
                {
                    oFila.Cells[0].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow oFila in _Dtg_Ordenes.Rows)
                {
                    oFila.Cells[0].Value = false;
                }
            }

            if (_Dtg_Ordenes.Rows.Count > 0)
            {
                _Dtg_Ordenes.CurrentCell = _Dtg_Ordenes[0, _Dtg_Ordenes.RowCount - 1];
            }
        }

        private void _Btn_Imprimir_Click(object sender, EventArgs e)
        {
            string sOrdenes = "";

            Cursor = Cursors.WaitCursor;

            foreach (DataGridViewRow oFila in _Dtg_Ordenes.Rows)
            {
                if (Convert.ToBoolean(oFila.Cells[0].Value))
                {
                    sOrdenes += ((sOrdenes != "") ? "or " : "");
                    sOrdenes += "(cnumoc = " + oFila.Cells[1].Value.ToString() + ")";
                }
            }

            if (sOrdenes.Length > 0)
            {
                mostrarOrdenes(Frm_Padre._Str_Comp, sOrdenes);

                _Pnl_Barra.Visible = false;

                _Rpt_VisorReportes.BringToFront();

                _Btn_Imprimir.Visible = false;
                _Btn_Regresar.Visible = true;

                _Chk_Todos.Visible = false;
            }
            else
            {
                MessageBox.Show
                (
                    "No ha seleccionado ordenes de compra.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            Cursor = Cursors.Default;
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sProveedor = "nulo", sDesde = "nulo", sHasta = "nulo";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cproveedor")
                {
                    sProveedor = oFiltro.Valor;
                }

                if (oFiltro.Nombre == "cdesde")
                {
                    sDesde = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "chasta")
                {
                    sHasta = oFiltro.Valor.Trim();
                }
            }

            if ((sProveedor == "") || (sProveedor == "nulo"))
            {
                MessageBox.Show("Indique un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }

            if ((sDesde == "nulo") && (sHasta == "nulo"))
            {
                MessageBox.Show("Indique un rango de fechas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
        }

        private void _Btn_Regresar_Click(object sender, EventArgs e)
        {
            _Pnl_Barra.Visible = true;

            _Rpt_VisorReportes.SendToBack();

            _Btn_Imprimir.Visible = true;
            _Btn_Regresar.Visible = false;

            _Chk_Todos.Visible = true;
        }

        #endregion
    }
}