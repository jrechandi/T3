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

namespace T3
{
    public partial class Frm_Inf_ComprasDetalladas2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios.</summary>
        _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Devuelve el nombre de la compañía.</summary>
        /// <returns>Nombre de la compañía.</returns>
        private string _Mtd_ObtenerCompañia()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }

            return "";
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

        #endregion

        #region Eventos

        public Frm_Inf_ComprasDetalladas2014()
        {
            InitializeComponent();

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            
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
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                Nombre = "cfecha",
                TituloFiltrarPor = "POR FECHA"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cotros",
                TituloFiltrarPor = "OTROS",
                TituloEtiqueta = "Criterio:",
                TituloGrid = "Otros:"
            });

            _Ctrl_Multifiltro.SeleccionarTodos = true;
            _Ctrl_Multifiltro.cargarEstados(cargarProveedores());
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);
        }

        private void Frm_Inf_ComprasDetalladas2014_Resize(object sender, EventArgs e)
        {
            int iIzquierda = (ClientSize.Width - _Ctrl_Multifiltro.Width) / 2;
            int iAlto = (ClientSize.Height - _Ctrl_Multifiltro.Height) / 2;
            int iDerecho = (_Pnl_Barra.ClientRectangle.Width - 50);

            _Ctrl_Multifiltro.Location = new Point(iIzquierda, iAlto);

            _Img_Logo.Left = iDerecho;
        }

        private void _Ctrl_Multifiltro_FiltroSeleccionado(FiltroCombo pFiltro, List<FiltroGrid> pFiltrosGrid)
        {
            switch (pFiltro.Nombre)
            {
                case "cotros":

                    _Ctrl_Multifiltro.agregarEstado("CON IMPUESTO", "0");
                    _Ctrl_Multifiltro.agregarEstado("SIN IMPUESTO", "1");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cproveedor":

                    _Ctrl_Multifiltro.cargarEstados(cargarProveedores());
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;
            }
        }

        private void _Btn_FiltrarPor_Click(object sender, EventArgs e)
        {
            _Btn_FiltrarPor.Enabled = false;
            _Ctrl_Multifiltro.Visible = true;
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sDesde = "nulo", sHasta = "nulo", sProveedor="nulo";
            
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
            }

            ReportParameter[] oParametros = new ReportParameter[5];

            oParametros[0] = new ReportParameter("CNOMBEMP", _Mtd_ObtenerCompañia());
            oParametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            oParametros[2] = new ReportParameter("CPROVEEDOR", sProveedor);
            oParametros[3] = new ReportParameter("CFECHAI", sDesde);
            oParametros[4] = new ReportParameter("CFECHAF", sHasta);

            _Rpt_VisorReportes.ServerReport.ReportPath = (CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ListCprProductos");
            _Rpt_VisorReportes.ServerReport.SetParameters(oParametros);
            _Rpt_VisorReportes.ServerReport.Refresh();            
            _Rpt_VisorReportes.RefreshReport();

            _Btn_FiltrarPor.Enabled = true;
        }

        #endregion
    }
}
