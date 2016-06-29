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
    public partial class Frm_Inf_NotaRecepcionDetallado2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios para el formato de los datos.</summary>
        private _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_NotaRecepcionDetallado2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                Nombre = "cfecha",
                TituloFiltrarPor = "POR FECHA"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoAñoMes,
                Nombre = "cmes",
                TituloFiltrarPor = "POR AÑO Y MES"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCaja,
                Nombre = "ccodigo",
                TituloFiltrarPor = "POR CÓDIGO",
                TituloEtiqueta = "Código:",
                TituloGrid = "Codigo:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cproveedor",
                TituloFiltrarPor = "POR PROVEEDOR",
                TituloEtiqueta = "Proveedor:",
                TituloGrid = "Proveedor:"
            });

            _Ctrl_Multifiltro.cargarEstados(cargarProveedores());
            _Ctrl_Multifiltro.cargarAñosCombo(cargarAño());
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);
        }

        /// <summary>Carga los datos del proveedor.</summary>
        /// <returns>Conjunto de resultados con la información del proveedor.</returns>
        private DataSet cargarProveedores()
        {
            string sSQL;

            sSQL = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado";
            sSQL += " from VST_PRODUCTOS_A where not exists(select * from TFILTROREGIONALP where VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto";
            sSQL += " and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0')";
            sSQL += " and VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' and VST_PRODUCTOS_A.cdelete=0 order by VST_PRODUCTOS_A.c_nomb_abreviado;";

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

        private void Frm_Inf_NotaRecepcionDetallado2014_Resize(object sender, EventArgs e)
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
            string sProveedor = "", sGrupo = "";

            switch (pFiltro.Nombre)
            {
                case "cproveedor":

                    _Ctrl_Multifiltro.cargarEstados(cargarProveedores());
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;

                case "cmes":

                    _Ctrl_Multifiltro.cargarMesesCombo(cargarMes(_Ctrl_Multifiltro.Año));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoAñoMes);

                    break;

                case "ccodigo":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCaja);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_AñoSeleccionado(string pAño)
        {
            _Ctrl_Multifiltro.cargarMesesCombo(cargarMes(pAño));
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sProveedor = "", sDesde = "", sHasta = "", sAño="", sMes="", sCodigo="";

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

                if (oFiltro.Nombre == "ccodigo")
                {
                    sCodigo = oFiltro.Valor.Trim();
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
            }
            else
            {
                ReportParameter[] oParametros = new ReportParameter[7];

                oParametros[0] = new ReportParameter("CGRUPO", Frm_Padre._Str_GroupComp.Trim());
                oParametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp.Trim());
                oParametros[2] = new ReportParameter("CNOMBREMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
                oParametros[3] = new ReportParameter("CNOTA", (sCodigo != "") ? sCodigo : "0");
                oParametros[4] = new ReportParameter("CPROVEEDOR", (sProveedor != "") ? sProveedor : "0");
                oParametros[5] = new ReportParameter("CFECHADESDE", sDesde);
                oParametros[6] = new ReportParameter("CFECHAHASTA", sHasta);

                _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_NotaRecepcionDetallado";
                _Rpt_VisorReportes.ServerReport.SetParameters(oParametros);
                _Rpt_VisorReportes.ServerReport.Refresh();
                _Rpt_VisorReportes.RefreshReport();
            }

            _Btn_FiltrarPor.Enabled = true;
        }

        #endregion
    }
}