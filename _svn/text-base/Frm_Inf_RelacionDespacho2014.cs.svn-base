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
    public partial class Frm_Inf_RelacionDespacho2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios para el formato de los datos.</summary>
        private _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_RelacionDespacho2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoBuscar,
                Nombre = "cruta",
                TituloFiltrarPor = "POR RUTA",
                TituloEtiqueta = "Ruta:",
                TituloGrid = "Ruta:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ctransportista",
                TituloFiltrarPor = "POR TRANSPORTISTA",
                TituloEtiqueta = "Transportista:",
                TituloGrid = "Transportista:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ccliente",
                TituloFiltrarPor = "POR CLIENTE",
                TituloEtiqueta = "Cliente:",
                TituloGrid = "Cliente:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "crelacion",
                TituloFiltrarPor = "RELACIÓN",
                TituloEtiqueta = "Relación:",
                TituloGrid = "Relación:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cplaca",
                TituloFiltrarPor = "PLACA",
                TituloEtiqueta = "Placa:",
                TituloGrid = "Placa:"
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
                Nombre = "cano",
                TituloFiltrarPor = "POR AÑO Y MES"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ctipo",
                TituloFiltrarPor = "TIPO DE REPORTE",
                TituloEtiqueta = "Tipo:",
                TituloGrid = "Tipo:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cotros",
                TituloFiltrarPor = "OTROS...",
                TituloEtiqueta = "Otros:",
                TituloGrid = "Otros:"
            });

            _Ctrl_Multifiltro.cargarAñosCombo(cargarAño());
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoBuscar);
            _Ctrl_Multifiltro.Visor = _Rpt_VisorReportes;
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

        #endregion

        #region Eventos

        private void _Btn_FiltrarPor_Click(object sender, EventArgs e)
        {
            _Btn_FiltrarPor.Enabled = false;

            _Rpt_VisorReportes.Enabled = false;

            _Ctrl_Multifiltro.Visible = true;
        }

        private void _Ctrl_Multifiltro_Cerrando()
        {
            _Btn_FiltrarPor.Enabled = true;

            _Rpt_VisorReportes.Enabled = true;
        }

        private void Frm_Inf_RelacionDespacho2014_Resize(object sender, EventArgs e)
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
            switch (pFiltro.Nombre)
            {
                case "cruta":
                case "ctransportista":
                case "ccliente":
                case "cplaca":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoBuscar);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;

                case "cano":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoAñoMes);

                    break;

                case "ctipo":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("RESUMIDO", "0");
                    _Ctrl_Multifiltro.agregarEstado("DETALLADO", "1");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cotros":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("RELACIONES LIQUIDADAS", "1");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonBuscarClick(string pNombreFiltro, TextBox pControl)
        {
            Frm_Busqueda2 oFormulario = null;

            switch (pNombreFiltro)
            {
                case "cruta":

                    oFormulario = new Frm_Busqueda2(65, pControl, 0, "");

                    break;

                case "ctransportista":

                    oFormulario = new Frm_Busqueda2(66, pControl, 0, "");

                    break;

                case "ccliente":

                    oFormulario = new Frm_Busqueda2(64, pControl, 0, "");

                    break;
            }

            if (oFormulario != null)
            {
                oFormulario.ShowDialog();
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sRuta = "", sTransportista = "", sCliente = "", sDesde = "", sHasta = "", sAño = "", sMes = "", sRelacion = "", sTipo = "", sOtros = "", sPlaca = "";

            bool bImpresa = true;

            ReportParameter[] oParametros;

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cruta")
                {
                    sRuta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ctransportista")
                {
                    sTransportista = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ccliente")
                {
                    sCliente = oFiltro.Valor.Trim();
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

                if (oFiltro.Nombre == "crelacion")
                {
                    sRelacion = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cplaca")
                {
                    sPlaca = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ctipo")
                {
                    sTipo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cotros")
                {
                    sOtros = oFiltro.Valor.Trim();
                }
            }

            sTipo = ((sTipo == "") ? "0" : sTipo);            
            sRelacion = ((sRelacion == "") ? "0" : sRelacion);
            sPlaca = ((sPlaca == "") ? "0" : sPlaca);
            
            oParametros = ((sTipo == "1") ? new ReportParameter[10] : new ReportParameter[9]);
            oParametros[0] = new ReportParameter("CNOMBCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CLIQUIDADA", ((sOtros != "") ? sOtros : "0"));
            oParametros[2] = new ReportParameter("CFECHAINI", sDesde);
            oParametros[3] = new ReportParameter("CFECHAFIN", sHasta);
            oParametros[4] = new ReportParameter("CIDRUTDESPACHO", sRuta);
            oParametros[5] = new ReportParameter("CCEDULA", sTransportista);
            oParametros[6] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);

            if (sTipo == "1")
            {
                oParametros[7] = new ReportParameter("CCLIENTE", sCliente);
                oParametros[8] = new ReportParameter("CGUIA", sRelacion);
                oParametros[9] = new ReportParameter("CPLACA", sPlaca);
            }
            else
            {
                oParametros[7] = new ReportParameter("CGUIA", sRelacion);
                oParametros[8] = new ReportParameter("CPLACA", sPlaca);
            }

            _Ctrl_Multifiltro.cargarReporte((sTipo == "0") ? "Rpt_RelaDespaResumido" : "Rpt_RelaDespaDetallado", oParametros);            

            _Btn_FiltrarPor.Enabled = true;
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sRuta = "", sTransportista = "", sDesde = "", sHasta = "", sMes = "", sAño = "", sTipo = "", sCliente = "";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cruta")
                {
                    sRuta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ctransportista")
                {
                    sTransportista = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ccliente")
                {
                    sCliente = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ctipo")
                {
                    sTipo = oFiltro.Valor.Trim();
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
            }

            if (sRuta == "")
            {
                MessageBox.Show(
                    "Debe indicar una ruta de despacho.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                pCancelar = true;

                return;
            }

            if (sTransportista == "")
            {
                MessageBox.Show(
                    "Debe indicar un transportista.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                pCancelar = true;

                return;
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

                return;
            }

            if ((sTipo == "1") && (sCliente == ""))
            {
                MessageBox.Show(
                    "Debe indicar un cliente.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                pCancelar = true;

                return;
            }
        }

        private void _Ctrl_Multifiltro_AñoSeleccionado(string pAño)
        {
            _Ctrl_Multifiltro.cargarMesesCombo(cargarMes(pAño));
        }

        #endregion
    }
}
