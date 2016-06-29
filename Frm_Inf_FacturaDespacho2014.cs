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
    public partial class Frm_Inf_FacturaDespacho2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios para el formato de los datos.</summary>
        private _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_FacturaDespacho2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cestado",
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

            _Ctrl_Multifiltro.agregarEstado("TODAS", "0");
            _Ctrl_Multifiltro.agregarEstado("FACTURAS IMPRESAS", "1");
            _Ctrl_Multifiltro.agregarEstado("FACTURAS NO IMPRESAS", "2");
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);
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

        /// <summary>Muestra las facturas a despacharr.</summary>
        /// <param name="pCompañia">Compañía.</param>
        /// <param name="pDesde">Fecha desde.</param>
        /// <param name="pHasta">Fecha hasta.</param>
        /// <param name="pEstado">Estado de las facturas.</param>
        private void mostrarFacturasDespachar(string pDesde, string pHasta, string pEstado)
        {
            string sSQL;

            sSQL = "select cfactura, c_fecha_factura, ccliente, c_nomb_comer, cvendedor, c_montotot_si_bs, c_impuesto_bs, cdias, cplaca, cguiadesp from VST_FACTURAM";
            sSQL += " where ccompany='" + Frm_Padre._Str_Comp + "' and c_fact_anul='0' and cpfactura>0 and (cimprimeguiadesp=0 or (cliqguidespacho=0 or cliqguidespacho is null))";            

            if (pEstado == "1")
            {
                sSQL += " and c_impresa=1";
            }
            else if (pEstado == "2")
            {
                sSQL += " and c_impresa=0";
            }
            
            if ((pEstado != "0") && ((pDesde != "") || (pHasta != "")))
            {
                sSQL += " and convert(datetime, convert(varchar(255), c_fecha_factura, 103)) between '" + pDesde + "' and '" + pHasta + "'";
            }

            DataSet oDatos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "';");

            ReportParameter[] oParametros = new ReportParameter[4];

            oParametros[0] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());
            oParametros[2] = new ReportParameter("CFECHAINI", pDesde);
            oParametros[3] = new ReportParameter("CFECHAFIN", pHasta);

            reiniciarVisorReportes();

            _Rpt_VisorReportes.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_Inf_Factura.rdlc";
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

        private void _Pnl_Barra_Resize(object sender, EventArgs e)
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
                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;

                case "cestado":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("TODAS", "0");
                    _Ctrl_Multifiltro.agregarEstado("FACTURAS IMPRESAS", "1");
                    _Ctrl_Multifiltro.agregarEstado("FACTURAS NO IMPRESAS", "2");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sDesde="", sHasta="", sEstado = "";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cestado")
                {
                    sEstado = oFiltro.Valor.Trim();
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

            if (sEstado == "")
            {
                MessageBox.Show("Indica un estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }

            if ((sEstado != "0") && ((sDesde == "") && (sHasta == "")))
            {
                MessageBox.Show("Indica una fecha.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pCancelar = true;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sDesde="", sHasta="", sEstado="";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cestado")
                {
                    sEstado = oFiltro.Valor.Trim();
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

            mostrarFacturasDespachar(sDesde, sHasta, sEstado);

            _Btn_FiltrarPor.Enabled = true;
        }

        private void _Ctrl_Multifiltro_EstadoSeleccionado(string pTexto, string pValor)
        {
            if (pValor == "0")
            {
                _Ctrl_Multifiltro.HabilitarFiltrarPor = false;
            }
            else
            {
                _Ctrl_Multifiltro.HabilitarFiltrarPor = true;
            }
        }

        #endregion
    }
}
