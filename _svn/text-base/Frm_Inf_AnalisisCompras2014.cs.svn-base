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
    public partial class Frm_Inf_NotaRecepcionDetallado : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios.</summary>
        _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_NotaRecepcionDetallado()
        {
            InitializeComponent();

            _Bt_Generar.Enabled = oUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & oUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_GENERAR_PREORDEN");

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
                Nombre = "cgrupo",
                TituloFiltrarPor = "POR GRUPO",
                TituloEtiqueta = "Grupo:",
                TituloGrid = "Grupo:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "csubgrupo",
                TituloFiltrarPor = "POR SUBGRUPO",
                TituloEtiqueta = "Subgrupo:",
                TituloGrid = "Subgrupo:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cmarca",
                TituloFiltrarPor = "POR MARCA",
                TituloEtiqueta = "Marca:",
                TituloGrid = "Marca:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cestratificacion",
                TituloFiltrarPor = "POR ESTRATIFICACIÓN",
                TituloEtiqueta = "Estratificación:",
                TituloGrid = "Estratificación:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCaja,
                Nombre = "ccodigo",
                TituloFiltrarPor = "POR CÓDIGO",
                TituloEtiqueta = "Código:",
                TituloGrid = "Código:"
            });

            _Ctrl_Multifiltro.cargarEstados(cargarProveedores());
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);
        }

        /// <summary>Carga los datos del proveedor.</summary>
        /// <returns>Conjunto de resultados con la información del proveedor.</returns>
        private DataSet cargarProveedores()
        {
            string sSQL;

            sSQL = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado";
            sSQL += " FROM VST_PRODUCTOS_A WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto";
            sSQL += " and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0')";
            sSQL += " AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' and VST_PRODUCTOS_A.cdelete=0 ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado;";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga los datos del grupo.</summary>
        /// <param name="pProveedor">Código del proveedor.</param>
        /// <returns>Conjunto de resultados con la información del grupo.</returns>
        private DataSet cargarGrupo(string pProveedor)
        {
            string sSQL;

            sSQL = "SELECT distinct dbo.TGRUPPROM.ccodgrupop, dbo.TGRUPPROM.cname ";
            sSQL += "FROM dbo.TGRUPPROM INNER JOIN ";
            sSQL += "dbo.TGRUPPROD ON dbo.TGRUPPROM.ccodgrupop = dbo.TGRUPPROD.ccodgrupop AND ";
            sSQL += "dbo.TGRUPPROM.cdelete = dbo.TGRUPPROD.cdelete INNER JOIN ";
            sSQL += "dbo.TPRODUCTO ON dbo.TGRUPPROD.cproveedor = dbo.TPRODUCTO.cproveedor AND dbo.TGRUPPROD.ccodgrupop = dbo.TPRODUCTO.cgrupo ";
            sSQL += "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') ";
            sSQL += "AND (TGRUPPROD.cproveedor = '" + pProveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga los datos del subgrupo.</summary>
        /// <param name="pProveedor">Código del proveedor.</param>
        /// <param name="pGrupo">Código del grupo.</param>
        /// <returns>Conjunto de resultados con la información del subgrupo.</returns>
        private DataSet cargarSubgrupo(string pProveedor, string pGrupo)
        {
            string sSQL;

            sSQL = "SELECT distinct dbo.TSUBGRUPOM.ccodsubgrup, dbo.TSUBGRUPOM.cname ";
            sSQL += "FROM dbo.TSUBGRUPOM INNER JOIN ";
            sSQL += "dbo.TSUBGRUPOD ON dbo.TSUBGRUPOM.ccodsubgrup = dbo.TSUBGRUPOD.ccodsubgrup AND ";
            sSQL += "dbo.TSUBGRUPOM.cdelete = dbo.TSUBGRUPOD.cdelete INNER JOIN ";
            sSQL += "dbo.TPRODUCTO ON dbo.TSUBGRUPOD.cproveedor = dbo.TPRODUCTO.cproveedor AND ";
            sSQL += "dbo.TSUBGRUPOD.ccodsubgrup = dbo.TPRODUCTO.csubgrupo AND dbo.TSUBGRUPOD.ccodgrupop = dbo.TPRODUCTO.cgrupo ";
            sSQL += "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') ";
            sSQL += "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + pProveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + pGrupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY TSUBGRUPOM.cname";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga los datos de la marca.</summary>
        /// <param name="pProveedor">Código del proveedor.</param>
        /// <param name="pGrupo">Código del grupo.</param>
        /// <returns>Conjunto de resultados con la información de la marca.</returns>
        private DataSet cargarMarca(string pProveedor, string pGrupo)
        {
            string sSQL;

            sSQL = "SELECT distinct dbo.TMARCASM.cmarca, dbo.TMARCASM.cname ";
            sSQL += "FROM dbo.TMARCASM INNER JOIN ";
            sSQL += "dbo.TMARCAS ON dbo.TMARCASM.cmarca = dbo.TMARCAS.cmarca INNER JOIN ";
            sSQL += "dbo.TPRODUCTO ON dbo.TMARCASM.cmarca = dbo.TPRODUCTO.cmarca ";
            sSQL += "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TPRODUCTO.cmarca=TFILTROREGIONALP.cmarca and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') ";
            sSQL += "AND (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + pGrupo + "') AND (TMARCAS.cproveedor = '" + pProveedor + "') AND (TPRODUCTO.cdelete=0) ORDER BY TMARCASM.cname";

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

        private void Frm_ConsultaMultipleCompras_Resize(object sender, EventArgs e)
        {
            int iIzquierda = (ClientSize.Width - _Ctrl_Multifiltro.Width) / 2;
            int iAlto = (ClientSize.Height - _Ctrl_Multifiltro.Height) / 2;
            int iDerecho = (_Pnl_Barra.ClientRectangle.Width - 40);

            _Ctrl_Multifiltro.Location = new Point(iIzquierda, iAlto);

            _Img_Logo.Left = iDerecho;
            _Img_Logo.Top -= 1;

            _Bt_Generar.Left = (iDerecho - 250);
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

                case "cgrupo":

                    foreach (FiltroGrid oFiltro in pFiltrosGrid)
                    {
                        if (oFiltro.Nombre == "cproveedor")
                        {
                            sProveedor = oFiltro.Valor;
                        }
                    }

                    _Ctrl_Multifiltro.cargarEstados(cargarGrupo(sProveedor));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "csubgrupo":

                    foreach (FiltroGrid oFiltro in pFiltrosGrid)
                    {
                        if (oFiltro.Nombre == "cproveedor")
                        {
                            sProveedor = oFiltro.Valor;
                        }

                        if (oFiltro.Nombre == "cgrupo")
                        {
                            sGrupo = oFiltro.Valor;
                        }
                    }

                    _Ctrl_Multifiltro.cargarEstados(cargarSubgrupo(sProveedor, sGrupo));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cmarca":

                    foreach (FiltroGrid oFiltro in pFiltrosGrid)
                    {
                        if (oFiltro.Nombre == "cproveedor")
                        {
                            sProveedor = oFiltro.Valor;
                        }

                        if (oFiltro.Nombre == "cgrupo")
                        {
                            sGrupo = oFiltro.Valor;
                        }
                    }

                    _Ctrl_Multifiltro.cargarEstados(cargarMarca(sProveedor, sGrupo));
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cestratificacion":

                    _Ctrl_Multifiltro.agregarEstado("A", "A");
                    _Ctrl_Multifiltro.agregarEstado("B", "B");
                    _Ctrl_Multifiltro.agregarEstado("C", "C");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "ccodigo":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCaja);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sProveedor = "nulo", sProducto = "nulo", sGrupo = "nulo", sSubgrupo = "nulo", sMarca = "nulo", sEstratificacion = "nulo";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cproveedor")
                {
                    sProveedor = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cgrupo")
                {
                    sGrupo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "csubgrupo")
                {
                    sSubgrupo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cmarca")
                {
                    sMarca = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cestratificacion")
                {
                    sEstratificacion = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ccodigo")
                {
                    sProducto = oFiltro.Valor.Trim();
                }
            }

            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");

            ReportParameter[] oParametros = new ReportParameter[9];

            oParametros[0] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            oParametros[2] = new ReportParameter("CPROVEEDOR", sProveedor);
            oParametros[3] = new ReportParameter("CPRODUCTO", sProducto);
            oParametros[4] = new ReportParameter("CGRUPO", sGrupo);
            oParametros[5] = new ReportParameter("CSUBGRUPO", sSubgrupo);
            oParametros[6] = new ReportParameter("CMARCA", sMarca);
            oParametros[7] = new ReportParameter("CESTRATIFICACION", sEstratificacion);
            oParametros[8] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfAnalisisCompInv";
            _Rpt_VisorReportes.ServerReport.SetParameters(oParametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();

            _Btn_FiltrarPor.Enabled = true;
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            string sProveedor = "nulo", sProducto = "nulo", sGrupo = "nulo", sSubgrupo = "nulo", sMarca = "nulo", sEstratificacion = "nulo";

            foreach (FiltroGrid oFiltro in _Ctrl_Multifiltro.Filtros)
            {
                if (oFiltro.Nombre == "cproveedor")
                {
                    sProveedor = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cgrupo")
                {
                    sGrupo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "csubgrupo")
                {
                    sSubgrupo = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cmarca")
                {
                    sMarca = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cestratificacion")
                {
                    sEstratificacion = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ccodigo")
                {
                    sProducto = oFiltro.Valor.Trim();
                }
            }

            if (sProveedor == "nulo")
            {
                MessageBox.Show("Debe elegir un proveedor para realizar la operación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            Cursor = Cursors.WaitCursor;

            Frm_PreOrden _Frm = new Frm_PreOrden(sProveedor, sGrupo, sSubgrupo, sMarca, sProducto, sEstratificacion);

            Cursor = Cursors.Default;

            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sProveedor = "nulo";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cproveedor")
                {
                    sProveedor = oFiltro.Valor;
                }
            }

            if ((sProveedor == "") || (sProveedor == "nulo"))
            {
                MessageBox.Show("Indique un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
        }

        #endregion
    }
}