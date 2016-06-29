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
    public partial class Frm_Inf_TiemposDespacho2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios para el formato de los datos.</summary>
        private _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_TiemposDespacho2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoBuscar,
                Nombre = "ccliente",
                TituloFiltrarPor = "POR CLIENTE",
                TituloEtiqueta = "Cliente:",
                TituloGrid = "Cliente:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoBuscar,
                Nombre = "cpedido",
                TituloFiltrarPor = "POR PEDIDO",
                TituloEtiqueta = "Pedido:",
                TituloGrid = "Pedido:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoBuscar,
                Nombre = "cfactura",
                TituloFiltrarPor = "POR FACTURA",
                TituloEtiqueta = "Factura:",
                TituloGrid = "Factura:"
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

        /// <summary>Obtiene el pedido de la factura.</summary>
        /// <param name="pFactura">Número de la factura.</param>
        /// <returns>Número del pedido.</returns>
        private string cargarPedido(string pFactura)
        {
            string sPedido = "";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cpedido from TFACTURAM where cfactura=" + pFactura + ";");

            if (oResultado.Tables[0].Rows.Count > 0)
            {
                sPedido = oResultado.Tables[0].Rows[0]["cpedido"].ToString();
            }

            return sPedido;
        }

        #endregion

        #region Eventos

        private void Frm_Inf_TiemposDespacho2014_Resize(object sender, EventArgs e)
        {
            int iIzquierda = (ClientSize.Width - _Ctrl_Multifiltro.Width) / 2;
            int iAlto = (ClientSize.Height - _Ctrl_Multifiltro.Height) / 2;
            int iDerecho = (_Pnl_Barra.ClientRectangle.Width - 40);

            _Ctrl_Multifiltro.Location = new Point(iIzquierda, iAlto);

            _Img_Logo.Left = iDerecho;
            _Img_Logo.Top -= 1;
        }

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

        private void _Ctrl_Multifiltro_AñoSeleccionado(string pAño)
        {
            _Ctrl_Multifiltro.cargarMesesCombo(cargarMes(pAño));
        }

        private void _Ctrl_Multifiltro_FiltroSeleccionado(FiltroCombo pFiltro, List<FiltroGrid> pFiltrosGrid)
        {
            switch (pFiltro.Nombre)
            {
                case "ccliente":
                case "cpedido":
                case "cfactura":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoBuscar);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;

                case "cano":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoAñoMes);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonBuscarClick(string pNombreFiltro, TextBox pControl)
        {
            string sCliente = "", sPedido = "";

            Frm_Busqueda2 oFormulario = null;

            foreach (FiltroGrid oFila in _Ctrl_Multifiltro.Filtros)
            {
                if (oFila.Nombre == "ccliente")
                {
                    sCliente = oFila.Valor;
                }

                if (oFila.Nombre == "cpedido")
                {
                    sPedido = oFila.Valor;
                }
            }

            switch (pNombreFiltro)
            {
                case "ccliente":

                    oFormulario = new Frm_Busqueda2(64, pControl, 0, "");

                    break;

                case "cpedido":

                    oFormulario = new Frm_Busqueda2(67, pControl, 0, ((sCliente != "") ? " and TCOTPEDFACM.ccliente=" + sCliente : ""));

                    break;

                case "cfactura":

                    if ((sCliente == "") && (sPedido != ""))
                    {
                        oFormulario = new Frm_Busqueda2(68, pControl, 0, (" and TFACTURAM.cpedido=" + sPedido));
                    }
                    else if ((sCliente != "") && (sPedido == ""))
                    {
                        oFormulario = new Frm_Busqueda2(68, pControl, 0, (" and TCLIENTE.ccliente=" + sCliente));
                    }
                    else if ((sCliente != "") && (sPedido != ""))
                    {
                        oFormulario = new Frm_Busqueda2(68, pControl, 0, (" and TCLIENTE.ccliente=" + sCliente + " and TFACTURAM.cpedido=" + sPedido));
                    }                    

                    break;
            }

            if (oFormulario != null)
            {
                oFormulario.ShowDialog();
            }
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

                return;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sDesde = "", sHasta = "", sAño = "", sMes = "", sPedido = "", sFactura = "", sCliente = "";

            ReportParameter[] oParametros;

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cpedido")
                {
                    sPedido = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cfactura")
                {
                    sFactura = oFiltro.Valor.Trim();
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
            }

            oParametros = new ReportParameter[7];
            oParametros[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            oParametros[1] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[2] = new ReportParameter("CPEDIDO", sPedido);
            oParametros[3] = new ReportParameter("CFACTURA", sFactura);
            oParametros[4] = new ReportParameter("CCLIENTE", sCliente);
            oParametros[5] = new ReportParameter("CFECHAINIBUS", sDesde);
            oParametros[6] = new ReportParameter("CFECHAFINBUS", sHasta);

            _Ctrl_Multifiltro.cargarReporte("Rpt_IndicadoresDespacho", oParametros);

            _Btn_FiltrarPor.Enabled = true;

            _Rpt_VisorReportes.Enabled = true;
        }

        #endregion
    }
}
