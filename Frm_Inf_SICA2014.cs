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
    public partial class Frm_Inf_SICA2014 : Form
    {
        #region Métodos

        /// <summary>Constructor.</summary>
        public Frm_Inf_SICA2014()
        {
            InitializeComponent();

            _Ctrl_Multifiltro.agregarFiltrarPor(new FiltroCombo
            {
                Tipo = _Enu_MultifiltroTipos.MultifiltroTipoCaja,
                Nombre = "cprecarga",
                TituloFiltrarPor = "POR PRECARGA",
                TituloEtiqueta = "Precarga:",
                TituloGrid = "Precarga:"
            });

            _Ctrl_Multifiltro.mostrarFiltro(_Enu_MultifiltroTipos.MultifiltroTipoCaja);
            _Ctrl_Multifiltro.Visor = _Rpt_VisorReportes;
        }

        #endregion

        #region Eventos

        private void Frm_Inf_SICA2014_Resize(object sender, EventArgs e)
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

        private void _Ctrl_Multifiltro_BotonConsultarClick(List<FiltroGrid> pFiltros)
        {
            string sPrecarga = "";

            ReportParameter[] oParametros;

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cprecarga")
                {
                    sPrecarga = oFiltro.Valor.Trim();
                }
            }

            oParametros = new ReportParameter[3];
            oParametros[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            oParametros[1] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            oParametros[2] = new ReportParameter("CPRECARGA", sPrecarga);

            _Ctrl_Multifiltro.cargarReporte("Rpt_InfSica", oParametros);

            _Btn_FiltrarPor.Enabled = true;

            _Rpt_VisorReportes.Enabled = true;
        }

        private void _Ctrl_Multifiltro_Validando(List<FiltroGrid> pFiltros, ref bool pCancelar)
        {
            string sPrecarga = "";

            foreach (FiltroGrid oFiltro in pFiltros)
            {
                if (oFiltro.Nombre == "cprecarga")
                {
                    sPrecarga = oFiltro.Valor.Trim();
                }
            }

            if (sPrecarga == "")
            {
                MessageBox.Show(
                    "Debe indicar una precarga.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                pCancelar = true;

                return;
            }
        }

        #endregion
    }
}
