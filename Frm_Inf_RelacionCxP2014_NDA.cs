using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.Controles;
using Microsoft.Reporting.WinForms;
using T3.CLASES;
using clslibraryconssa;

namespace T3
{
    public partial class Frm_Inf_RelacionCxP2014_NDA : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios para el formato de los datos.</summary>
        private _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_RelacionCxP2014_NDA()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ctipo",
                TituloFiltrarPor = "POR TIPO",
                TituloEtiqueta = "Tipo:",
                TituloGrid = "Tipo:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ccategoria",
                TituloFiltrarPor = "POR CATEGORIA",
                TituloEtiqueta = "Categoría:",
                TituloGrid = "Categoría:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cproveedor",
                TituloFiltrarPor = "POR PROVEEDOR",
                TituloEtiqueta = "Proveedor:",
                TituloGrid = "Proveedor:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cestatus",
                TituloFiltrarPor = "POR ESTADO",
                TituloEtiqueta = "Estado:",
                TituloGrid = "Estado:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                Nombre = "cfecha",
                TituloFiltrarPor = "POR FECHA"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoAñoMes,
                Nombre = "cmes",
                TituloFiltrarPor = "POR AÑO Y MES"
            });

            _Ctrl_Multifiltro.agregarEstado("SERVICIO", "0");
            _Ctrl_Multifiltro.agregarEstado("MATERIA PRIMA", "1");
            _Ctrl_Multifiltro.agregarEstado("OTROS", "2");
            _Ctrl_Multifiltro.cargarAñosCombo(cargarAño());
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);
        }

        /// <summary>Carga los datos del proveedor.</summary>
        /// <param name="pTipo">Tipo de proveedor.</param>
        /// <param name="pCompañia">Código de la compañía.</param>
        /// <param name="pCategoria">Categoría del proveedor.</param>
        /// <returns>Conjunto de resultados con la información del proveedor.</returns>
        private DataSet cargarProveedores(string pCompañia, string pTipo, string pCategoria)
        {
            string sSQL;

            sSQL = "select distinct TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado from TPROVEEDOR";
            sSQL += " left join TGRUPPROVEE on TPROVEEDOR.cproveedor=TGRUPPROVEE.cproveedor";
            sSQL += " where isnull(TPROVEEDOR.cdelete,0)='0' and isnull(TGRUPPROVEE.cdelete,0)='0' and TPROVEEDOR.c_activo='1'";

            if (pTipo == "")
            {
                sSQL += " and ((TGRUPPROVEE.CCOMPANY='" + pCompañia + "' and TPROVEEDOR.cglobal='" + pTipo + "') or (TPROVEEDOR.cglobal<>'" + pTipo + "' and TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))";
            }
            else
            {
                if ((pTipo == "0") || (pTipo == "2"))
                {
                    sSQL += " and TPROVEEDOR.ccompany='" + pCompañia + "' and TPROVEEDOR.cglobal='" + pTipo + "'";
                }
                else
                {
                    sSQL += " and TGRUPPROVEE.ccompany='" + pCompañia + "' and cglobal='" + pTipo + "'";
                }
            }

            if (pCategoria != "")
            {
                sSQL += " AND TPROVEEDOR.ccatproveedor='" + pCategoria + "'";
            }

            sSQL += " union select TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado from TPROVEEDOR inner join  TPROVEEDORHISTORICO on TPROVEEDOR.cproveedor=TPROVEEDORHISTORICO.cproveedor and TPROVEEDOR.c_rif=TPROVEEDORHISTORICO.c_rif";
            sSQL += " where TPROVEEDORHISTORICO.ccompany='" + pCompañia + "'  ORDER BY TPROVEEDOR.c_nomb_abreviado";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga las categorías de los proveedores.</summary>
        /// <param name="pTipo">Tipo de proveedor.</param>
        /// <returns>Conjunto de resultados con la información del proveedor.</returns>
        private DataSet cargarCategoria(string pTipo)
        {
            string sSQL;

            sSQL = "select ccatproveedor, upper(cnombre) as cnombre from TCATPROVEEDOR where cdelete='0'";

            if (pTipo != "")
            {
                sSQL += " and cglobal='" + pTipo + "'";
            }

            sSQL += " order by cnombre;";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga los años contables para la empresa seleccionado.</summary>
        /// <returns>Conjunto de resultado con los años contables.</returns>
        private DataSet cargarAño()
        {
            string sSQL = "select distinct cyearacco, cyearacco from TCALENDCONT where cyearacco <= year(getdate()) and (cyearacco <> 0) order by cyearacco desc;";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga meses contables para la empresa seleccionado.</summary>
        /// <returns>Conjunto de resultado con los meses contables.</returns>
        private DataSet cargarMes(string pAño)
        {
            string sSQL;

            sSQL = "select distinct cmontacco, case";
            sSQL += " when cmontacco=1 then 'ENERO'";
            sSQL += " when cmontacco=2 then 'FEBRERO'";
            sSQL += " when cmontacco=3 then 'MARZO'";
            sSQL += " when cmontacco=4 then 'ABRIL'";
            sSQL += " when cmontacco=5 then 'MAYO'";
            sSQL += " when cmontacco=6 then 'JUNIO'";
            sSQL += " when cmontacco=7 then 'JULIO'";
            sSQL += " when cmontacco=8 then 'AGOSTO'";
            sSQL += " when cmontacco=9 then 'SEPTIEMBRE'";
            sSQL += " when cmontacco=10 then 'OCTUBRE'";
            sSQL += " when cmontacco=11 then 'NOVIEMBRE'";
            sSQL += " when cmontacco=12 then 'DICIEMBRE'";
            sSQL += " end as cmes from TCALENDCONT where cyearacco='" + pAño + "'";
            sSQL += " and ((cyearacco = year(getdate()) and cmontacco <= month(getdate())) or (cyearacco <> year(getdate()))) order by cmontacco desc;";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Retorna la fecha desde según el año y el mes seleccionado en el filtro.</summary>
        /// <param name="pAño">Año del calendario.</param>
        /// <param name="pMes">Mes del calendario.</param>
        /// <param name="pDesde">Tipo booleano, indica si devuelve el desde o el hasta.</param>
        /// <returns>Fecha desde.</returns>
        private string obtenerFechaCalendario(string pAño, string pMes, bool pDesde = true)
        {
            string sSQL;

            sSQL = "select top 1 convert(varchar, cdiafecha_reg, 103) as cfecha from TCALENDCONT where cyearacco='" + pAño + "' and cmontacco='" + pMes + "' and cdelete='0'";
            sSQL += " order by convert(datetime, cdiafecha_reg)" + ((pDesde) ? " asc;" : " desc;");

            DataSet oFecha = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            return oFormato._Mtd_fecha(Convert.ToDateTime(oFecha.Tables[0].Rows[0]["cfecha"].ToString()));
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
        /// <param name="pGrupo">Grupo de compañia.</param>
        /// <param name="pCompañia">Compañía.</param>
        /// <param name="pGlobal">Tipo de proveedor.</param>
        /// <param name="pImpresa">Verdadero, filtra las notas de débito impresas.</param>
        /// <param name="pDesde">Fecha desde.</param>
        /// <param name="pHasta">Fecha hasta.</param>
        private void mostrarNotasDebitoAnuladas(string pGrupo, string pCompañia, string pTipo, bool pImpresa, string pDesde, string pHasta)
        {
            string sSQL;

            sSQL = "select cidnotadebitocxp, cfechand, cglobal, cproveedor, c_nomb_comer, c_rif, cmontototsi, cbaseexcenta, cimpuesto, ctotaldocu from VST_TNOTADEBITOCP where cgroupcomp='" + pGrupo + "' and ccompany='" + pCompañia + "'";
            sSQL += " and cimpresa=" + (pImpresa ? "1" : "0") + " AND canulado=1 and cglobal=" + (pTipo != "nulo" ? pTipo : "1");
            sSQL += " and convert(datetime, convert(varchar(255), cfechand, 103)) between '" + pDesde + "' and '" + pHasta + "'";

            DataSet oDatos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "';");

            ReportParameter[] oParametros = new ReportParameter[3];

            oParametros[0] = new ReportParameter("CNOMCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());
            oParametros[2] = new ReportParameter("CESTATUS", "0");

            reiniciarVisorReportes();

            _Rpt_VisorReportes.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_Inf_CxP_ND.rdlc";
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

            _Ctrl_Multifiltro.Visible = true;
        }

        private void _Ctrl_Multifiltro_Cerrando()
        {
            _Btn_FiltrarPor.Enabled = true;
        }

        private void Frm_Inf_RelacionCxP2014_ND_Resize(object sender, EventArgs e)
        {
            int iIzquierda = (ClientSize.Width - _Ctrl_Multifiltro.Width) / 2;
            int iAlto = (ClientSize.Height - _Ctrl_Multifiltro.Height) / 2;
            int iDerecho = (_Pnl_Barra.ClientRectangle.Width - 40);

            _Ctrl_Multifiltro.Location = new Point(iIzquierda, iAlto);

            _Img_Logo.Left = iDerecho;
            _Img_Logo.Top -= 1;
        }

        private void _Ctrl_Multifiltro_FiltroSeleccionado(FiltroCombo pFiltro, List<FiltroGrid> pFiltrosGrid)
        {
            string sTipo = "", sCategoria = "";

            foreach (FiltroGrid oFiltro in pFiltrosGrid)
            {
                if (oFiltro.Nombre == "ctipo")
                {
                    sTipo = oFiltro.Valor;
                }

                if (oFiltro.Nombre == "ccategoria")
                {
                    sCategoria = oFiltro.Valor;
                }
            }

            switch (pFiltro.Nombre)
            {
                case "ctipo":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("SERVICIO", "0");
                    _Ctrl_Multifiltro.agregarEstado("MATERIA PRIMA", "1");
                    _Ctrl_Multifiltro.agregarEstado("OTROS", "2");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "ccategoria":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.cargarEstados(cargarCategoria(sTipo));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cproveedor":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.cargarEstados(cargarProveedores(Frm_Padre._Str_Comp.Trim(), sTipo, sCategoria));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cestatus":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("IMPRESA", "1");
                    _Ctrl_Multifiltro.agregarEstado("NO IMPRESA", "0");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;

                case "cmes":

                    _Ctrl_Multifiltro.cargarMesesCombo(cargarMes(_Ctrl_Multifiltro.Año));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoAñoMes);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sProveedor = "nulo", sDesde = "", sHasta = "", sAño = "", sMes = "", sCategoria = "nulo", sTipo = "nulo";

            bool bImpresa = true;

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cproveedor")
                {
                    sProveedor = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cdesde")
                {
                    sDesde = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "chasta")
                {
                    sHasta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cano")
                {
                    sAño = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cmes")
                {
                    sMes = oFiltro.Valor.Trim();

                    sDesde = obtenerFechaCalendario(sAño, sMes, true);
                    sHasta = obtenerFechaCalendario(sAño, sMes, false);
                }

                if (oFiltro.Nombre == "ccategoria")
                {
                    sCategoria = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ctipo")
                {
                    sTipo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cestatus")
                {
                    bImpresa = (oFiltro.Valor == "1") ? true : false;
                }
            }

            mostrarNotasDebitoAnuladas
            (
                Frm_Padre._Str_GroupComp,
                Frm_Padre._Str_Comp,
                sTipo,
                bImpresa,
                sDesde,
                sHasta
            );

            _Btn_FiltrarPor.Enabled = true;
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sDesde = "", sHasta = "", sMes = "", sAño = "";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cdesde")
                {
                    sDesde = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "chasta")
                {
                    sHasta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cano")
                {
                    sAño = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cmes")
                {
                    sMes = oFiltro.Valor.Trim();

                    sDesde = obtenerFechaCalendario(sAño, sMes, true);
                    sHasta = obtenerFechaCalendario(sAño, sMes, false);
                }
            }

            if ((sDesde == "") && (sHasta == ""))
            {
                MessageBox.Show(
                    "Debe indicar un rango de fechas o un mes para ver la consulta.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                pCancelar = true;
            }
        }

        #endregion
    }
}
