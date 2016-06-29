using System.Data;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ReImpresionAjustes : Form
    {
        #region Metodos

        private void _Mtd_MostrarReporte()
        {
            string _Str_Ajuste;
            REPORTESS Frm_Reporte;
            PrintDialog _Print = new PrintDialog();

            Cursor = Cursors.WaitCursor;

            if (_Print.ShowDialog() == DialogResult.OK)
            {
                if (_Tab_Fichas.SelectedTab.TabIndex == 1)
                {
                    _Str_Ajuste = _Dtg_GridAjustesSalida.CurrentRow.Cells[0].Value.ToString();

                    Frm_Reporte = new REPORTESS(new string[] {"VST_AJUSTESAL_RPT"}, "", "T3.Report.rAjtSalida",
                                                "Section1", "cabecera", "rif", "nit",
                                                "ccompany='" + Frm_Padre._Str_Comp + "' AND cajustsal='" +
                                                _Str_Ajuste + "'", _Print, true);
                }
                else
                {
                    _Str_Ajuste = _Dtg_GridAjustesEntrada.CurrentRow.Cells[0].Value.ToString();

                    Frm_Reporte = new REPORTESS(new string[] {"VST_AJUSTEENT_RPT"}, "", "T3.Report.rAjtEntrada",
                                                "Section1", "cabecera", "rif", "nit",
                                                "ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" +
                                                _Str_Ajuste + "'", _Print, true);
                }

                Frm_Reporte.crystalReportViewer1.ShowExportButton = false;
                Frm_Reporte.crystalReportViewer1.ShowGroupTreeButton = false;
                Frm_Reporte.crystalReportViewer1.ShowPageNavigateButtons = false;
                Frm_Reporte.WindowState = FormWindowState.Maximized;
                Frm_Reporte.Show();
            }

            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarAjustes()
        {
            string _Str_SQL;
            string[] _Str_Campos = new string[2];
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];

            if (_Tab_Fichas.SelectedTab.TabIndex == 1)
            {
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Fecha");

                _Str_Campos[0] = "cajustsal";
                _Str_Campos[1] = "cname";

                _Str_SQL = "SELECT cajustsal AS Código,";
                _Str_SQL += " CONVERT(varchar, cdateajus, 3) AS Fecha,";
                _Str_SQL += " cname AS Descripción,";
                _Str_SQL += " dbo.Fnc_Formatear(ccosttotsimp) AS Monto,";
                _Str_SQL += " dbo.Fnc_Formatear(cvalorimp) AS Impuesto,";
                _Str_SQL += " CASE WHEN cejecutada='1' THEN 'Sí' ELSE 'No' END AS Actualizado";
                _Str_SQL += " FROM TAJUSSALC";
                _Str_SQL += " WHERE ccompany = '" + Frm_Padre._Str_Comp + "'";
                _Str_SQL += " AND cdelete = '0'";
                _Str_SQL += " AND canulado = '0'";
                _Str_SQL += " AND cimpreso = 1";
                _Str_SQL += " AND cejecutada = 1";

                _Ctrl_FiltroAjusteSalida._Mtd_Inicializar(_Str_SQL, _Str_Campos, "Ajustes de salida", _Tsm_Menu, _Dtg_GridAjustesSalida, true, "");
            }
            else
            {
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                
                _Str_Campos[0] = "cajustent";
                _Str_Campos[1] = "cname";

                _Str_SQL = "SELECT cajustent AS Código,";
                _Str_SQL += " CONVERT(varchar, cdateajus, 3) AS Fecha,";
                _Str_SQL += " cname AS Descripción,";
                _Str_SQL += " dbo.Fnc_Formatear(ccosttotsimp) AS Monto,";
                _Str_SQL += " dbo.Fnc_Formatear(cvalorimp) AS Impuesto,";
                _Str_SQL += " CASE WHEN cejecutada='1' THEN 'Sí' ELSE 'No' END AS Actualizado";
                _Str_SQL += " FROM TAJUSENTC";
                _Str_SQL += " WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Str_SQL += " AND cdelete='0'";
                _Str_SQL += " AND canulado='0'";
                _Str_SQL += " AND cimpreso = 1";
                _Str_SQL += " AND cejecutada = 1";

                _Ctrl_FiltroAjusteEntrada._Mtd_Inicializar(_Str_SQL, _Str_Campos, "Ajustes de entrada", _Tsm_Menu, _Dtg_GridAjustesEntrada, true, "");
            }
        }

        #endregion

        #region Eventos

        public Frm_ReImpresionAjustes()
        {
            InitializeComponent();

            _Mtd_CargarAjustes();
        }

        private void _Mnu_Imprimir_Click(object sender, System.EventArgs e)
        {
            _Mtd_MostrarReporte();
        }

        private void _Tab_Fichas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _Mtd_CargarAjustes();
        }

        #endregion
    }
}
