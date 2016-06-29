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
    public partial class Frm_Inf_Precarga2014 : Form
    {
        #region Atributos

        /// <summary>Objeto con métodos varios para el formato de los datos.</summary>
        private _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos oUtilidad = new _Cls_Varios_Metodos(true);

        #endregion

        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_Precarga2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cruta",
                TituloFiltrarPor = "POR RUTA",
                TituloEtiqueta = "Ruta:",
                TituloGrid = "Ruta:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCompuesto,
                Nombre = "ctransporte",
                TituloFiltrarPor = "POR TRANSPORTE",
                TituloEtiqueta = "Transporte:",
                TituloGrid = "Transporte:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoFecha,
                Nombre = "cfecha",
                TituloFiltrarPor = "POR FECHA"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCaja,
                Nombre = "cprecarga",
                TituloFiltrarPor = "POR PRECARGA",
                TituloEtiqueta = "Precarga:",
                TituloGrid = "Precarga:"
            });

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCombo,
                Nombre = "cestado",
                TituloFiltrarPor = "POR ESTADO",
                TituloEtiqueta = "Estado:",
                TituloGrid = "Estado:"
            });

            _Ctrl_Multifiltro.cargarEstados(cargarRutas(Frm_Padre._Str_GroupComp));
            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);
        }

        /// <summary>Carga las rutas de visitas.</summary>
        /// <param name="pGrupo">Grupo de compañia.</param>
        /// <returns>Conjunto de resultados con las rutas.</returns>
        private DataSet cargarRutas(string pGrupo)
        {
            string sSQL = "select distinct cidrutdespacho, cdescripcion from VST_PRECARGADR where cgroupcomp='" + pGrupo + "' and cdescripcion <> '';";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Carga las rutas de visitas.</summary>
        /// <param name="pGrupo">Grupo de compañia.</param>
        /// <param name="pRuta">Ruta de transporte.</param>
        /// <returns>Conjunto de resultados con los transportes.</returns>
        private DataSet cargarTransporte(string pGrupo, string pRuta)
        {
            string sSQL = "select cplaca, (ccedula + ': ' + convert(varchar(100),ctransportista)) from VST_PRECARGADR where cgroupcomp='" + pGrupo + "' and cidrutdespacho='" + pRuta + "';";

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

        private void Frm_Inf_Precarga2014_Resize(object sender, EventArgs e)
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
            string sRuta = "";

            foreach (FiltroGrid oFiltro in pFiltrosGrid)
            {
                if (oFiltro.Nombre == "cruta")
                {
                    sRuta = oFiltro.Valor;
                }
            }

            switch (pFiltro.Nombre)
            {
                case "cruta":

                    _Ctrl_Multifiltro.cargarCompuesto(cargarRutas(Frm_Padre._Str_GroupComp));

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "ctransporte":

                    if (sRuta == "")
                    {
                        MessageBox.Show("Indica una ruta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _Ctrl_Multifiltro.mostrarFiltro("cruta");

                        return;
                    }

                    _Ctrl_Multifiltro.cargarCompuesto(cargarTransporte(Frm_Padre._Str_GroupComp, sRuta));

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCompuesto);

                    break;

                case "cfecha":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoFecha);

                    break;

                case "cestado":

                    _Ctrl_Multifiltro.eliminarEstados();
                    _Ctrl_Multifiltro.agregarEstado("IMPRESA", "0");
                    _Ctrl_Multifiltro.agregarEstado("PRE-CARGA FACTURADA", "1");
                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCombo);

                    break;

                case "cprecarga":

                    _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCaja);

                    break;
            }
        }

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            bool bImpuesto = false;

            string sRuta="", sTransporte="", sDesde="", sHasta="", sOtros="", sPrecarga="", sCedula="", sSQL;

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cruta")
                {
                    sRuta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "ctransporte")
                {
                    sCedula = oFiltro.Descripcion;
                    sCedula = sCedula.Substring(0, sCedula.IndexOf(':'));

                    sTransporte += ((sTransporte == "") ? "" : " or ");
                    sTransporte += "(ccedula='" + sCedula + "' and cplaca='" + oFiltro.Valor.Trim() + "')";
                }

                if (oFiltro.Nombre == "cdesde")
                {
                    sDesde = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "chasta")
                {
                    sHasta = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cotros")
                {
                    sOtros = oFiltro.Valor.Trim();
                }

                if (oFiltro.Nombre == "cprecarga")
                {
                    sPrecarga = oFiltro.Valor.Trim();
                }
            }

            sSQL = "select * from " + ((sPrecarga != "") ? "VST_PRECARGALISTADO_2" : "VST_PRECARGALISTADO") + " where";

            if (sPrecarga == "")
            {
                sSQL += " cidrutdespacho=" + sRuta;
                sSQL += (((sDesde != "") && (sHasta != "")) ? " and (convert(datetime, convert(varchar(255), cfechaprecarga, 103)) between '" + sDesde + "' and '" + sHasta + "')" : "");
                sSQL += ((sTransporte != "") ? " and (" + sTransporte + ")" : "");
                sSQL += ((sOtros == "0") ? " and cimprimeprecarga=1" : " and cimprimefactura=1");
            }
            else
            {
                sSQL += " cprecarga='" + sPrecarga + "'";
            }

            sSQL += " and cgroupcomp='" + Frm_Padre._Str_GroupComp + "';";

            DataSet oDatos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
            DataSet oRIF = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");

            ReportParameter[] oParametros = new ReportParameter[2];

            oParametros[0] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[1] = new ReportParameter("CRIF", oRIF.Tables[0].Rows[0]["crif"].ToString());

            reiniciarVisorReportes();

            _Rpt_VisorReportes.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_Inf_Precarga.rdlc";
            _Rpt_VisorReportes.LocalReport.DataSources.Clear();
            _Rpt_VisorReportes.LocalReport.SetParameters(oParametros);
            _Rpt_VisorReportes.LocalReport.DataSources.Add(new ReportDataSource("DataSource2", (DataTable)oDatos.Tables[0]));
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
            string sDesde = "", sHasta = "", sPrecarga="";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cprecarga")
                {
                    sPrecarga = oFiltro.Valor.Trim();
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

            if (((sDesde == "") && (sHasta == "")) && (sPrecarga == ""))
            {
                MessageBox.Show(
                    "Indica una fecha.",
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