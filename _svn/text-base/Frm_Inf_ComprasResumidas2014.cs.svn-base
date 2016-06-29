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
    public partial class Frm_Inf_ComprasResumidas2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios.</summary>
        _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_ComprasResumidas2014()
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

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cimpuesto",
                TituloFiltrarPor = "IMPUESTO",
                TituloEtiqueta = "Opción:",
                TituloGrid = "Impuesto:"
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

        private void Frm_Inf_ComprasResumidas2014_Resize(object sender, EventArgs e)
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
                case "cimpuesto":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("CON IMPUESTO", "1");
                    _Ctrl_Multifiltro.agregarEstado("SIN IMPUESTO", "0");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

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
            bool bImpuesto = false;

            string sDesde = "nulo", sHasta = "nulo", sProveedor = "nulo", sSQL;

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cproveedor")
                {
                    if (sProveedor == "nulo")
                    {
                        sProveedor = " (cproveedor='" + oFiltro.Valor.Trim() + "')";
                    }
                    else
                    {
                        sProveedor += " or (cproveedor='" + oFiltro.Valor.Trim() + "')";
                    }
                }

                if (oFiltro.Nombre == "cdesde")
                {
                    sDesde = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "chasta")
                {
                    sHasta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cimpuesto")
                {
                    bImpuesto = (oFiltro.Valor == "1") ? true : false;
                }
            }

            sSQL = "select cproveedor, c_nomb_comer, cempaquestotal, cunidadestotal, cmontosiTotal, cmontoimpTotal from VST_COMPRASRESUMEN";
            sSQL += " where (" + sProveedor + ") and (convert(datetime, convert(varchar(255), cfechanotrecep, 103)) BETWEEN '" + sDesde + "' AND '" + sHasta + "')";
            sSQL += " and ccompany='" + Frm_Padre._Str_Comp + "';";

            DataSet oDatos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");

            ReportParameter[] oParametros = new ReportParameter[6];

            oParametros[0] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CFECHAI", sDesde);
            oParametros[2] = new ReportParameter("CFECHAF", sHasta);
            oParametros[3] = new ReportParameter("CIMPUESTO", bImpuesto.ToString());
            oParametros[4] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            oParametros[5] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());

            reiniciarVisorReportes();

            _Rpt_VisorReportes.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_ListCprProvResumen.rdlc";
            _Rpt_VisorReportes.LocalReport.DataSources.Clear();
            _Rpt_VisorReportes.LocalReport.SetParameters(oParametros);
            _Rpt_VisorReportes.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", (DataTable)oDatos.Tables[0]));
            _Rpt_VisorReportes.LocalReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
            _Rpt_VisorReportes.BringToFront();

            _Pnl_Barra.SendToBack();

            _Ctrl_Multifiltro.BringToFront();

            _Btn_FiltrarPor.Enabled = true;

            UpdateZOrder();
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

        #endregion
    }
}
