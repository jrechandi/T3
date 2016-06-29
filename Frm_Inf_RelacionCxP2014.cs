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
    public partial class Frm_Inf_RelacionCxP2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios.</summary>
        _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_RelacionCxP2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ctipo",
                TituloFiltrarPor = "POR TIPO",
                TituloEtiqueta = "Tipo:",
                TituloGrid = "Tipo:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "ccategoria",
                TituloFiltrarPor = "POR CATEGORIA",
                TituloEtiqueta = "Categoría:",
                TituloGrid = "Categoría:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cproveedor",
                TituloFiltrarPor = "POR PROVEEDOR",
                TituloEtiqueta = "Proveedor:",
                TituloGrid = "Proveedor:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cestatus",
                TituloFiltrarPor = "POR ESTATUS",
                TituloEtiqueta = "Opciones:",
                TituloGrid = "Estatus:"
            });

            _Ctrl_Multifiltro.eliminarEstados();
            _Ctrl_Multifiltro.agregarEstado("SERVICIO", "0");
            _Ctrl_Multifiltro.agregarEstado("MATERIA PRIMA", "1");
            _Ctrl_Multifiltro.agregarEstado("OTROS", "2");
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);
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

        /// <summary>Carga las categorías de los proveedores.</summary>
        /// <param name="pTipoProveedor">Tipo de proveedor.</param>
        /// <returns>Conjunto de resultados con la información del proveedor.</returns>
        private DataSet cargarCategoria(string pTipoProveedor)
        {
            string sSQL;

            sSQL = "select ccatproveedor, upper(cnombre) as cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + pTipoProveedor + "' order by cnombre;";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
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

        private void Frm_Inf_RelacionCxP2014_Resize(object sender, EventArgs e)
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
            string sTipo = "";

            foreach (FiltroGrid oFiltro in pFiltrosGrid)
            {
                if (oFiltro.Nombre == "ctipo")
                {
                    sTipo = oFiltro.Valor;
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
                    _Ctrl_Multifiltro.cargarEstados(cargarProveedores());
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cestatus":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("TODAS", "0");
                    _Ctrl_Multifiltro.agregarEstado("VENCIDAS", "1");
                    _Ctrl_Multifiltro.agregarEstado("POR VENCER", "2");
                    _Ctrl_Multifiltro.agregarEstado("CANCELADAS", "3");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sTipo = "", sCategoria = "", sProveedor = "", sEstatus = "";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "ctipo")
                {
                    sTipo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ccategoria")
                {
                    sCategoria = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cproveedor")
                {
                    sProveedor = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cestatus")
                {
                    sEstatus = oFiltro.Valor.Trim();
                }
            }

            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");

            ReportParameter[] oParametros = new ReportParameter[8];

            oParametros[0] = new ReportParameter("CFILTRO", Frm_Padre._Str_Comp.Trim());
            oParametros[1] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp.Trim());
            oParametros[2] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            oParametros[3] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[4] = new ReportParameter("CGLOBAL", sTipo);
            oParametros[5] = new ReportParameter("CCATPROVEEDOR", sCategoria);
            oParametros[6] = new ReportParameter("CPROVEEDOR", sProveedor);
            oParametros[7] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_CxP";
            _Rpt_VisorReportes.ServerReport.SetParameters(oParametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();

            _Btn_FiltrarPor.Enabled = true;
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sTipo = "nulo", sCategoria = "nulo", sProveedor = "nulo", sEstatus="nulo";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                switch (oFiltro.Nombre)
                {
                    case "ctipo":
                        sTipo = oFiltro.Valor;
                        break;

                    case "ccategoria":
                        sCategoria = oFiltro.Valor;
                        break;

                    case "cproveedor":
                        sProveedor = oFiltro.Valor;
                        break;

                    case "cestatus":
                        sEstatus = oFiltro.Valor;
                        break;
                }
            }

            if ((sTipo == "") || (sTipo == "nulo"))
            {
                MessageBox.Show("Indique un tipo de proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
            else if ((sCategoria == "") || (sCategoria == "nulo"))
            {
                MessageBox.Show("Indique una categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
            else if ((sProveedor == "") || (sProveedor == "nulo"))
            {
                MessageBox.Show("Indique un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
            else if ((sEstatus == "") || (sEstatus == "nulo"))
            {
                MessageBox.Show("Indique un estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
        }

        #endregion
    }
}
