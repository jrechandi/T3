using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.CLASES;
using T3.Clases;
using clslibraryconssa;

namespace T3
{
    public partial class Frm_ConsolidadoInterResumido : Form
    {
        #region Atributos
                
        _Cls_Varios_Metodos oVariosMetodos = new _Cls_Varios_Metodos(true);
        _Cls_Conexion oConexion = new _Cls_Conexion();
        _Cls_Formato oFormato = new _Cls_Formato("es-VE");

        Color oColorFilaSeleccionada = Color.FromArgb(255, 192, 192);

        #endregion

        #region Métodos

        /// <summary>
        /// Método para calcular los totales del consolidado.
        /// </summary>
        private void _Mtd_CalcularTotales()
        {
            double dTotalMenor = 0;
            double dTotalMayor = 0;
            double dSaldo = 0;

            foreach (DataGridViewRow oFila in dtgConsolidado.Rows)
            {
                dTotalMenor += Convert.ToDouble(oFila.Cells["colMenor"].Value);
                dTotalMayor += Convert.ToDouble(oFila.Cells["colMayor"].Value);
            }

            dSaldo = (Math.Abs(dTotalMenor) - Math.Abs(dTotalMayor));

            txtTotalMenor.Text = dTotalMenor.ToString("#,##0.00");
            txtTotalMayor.Text = dTotalMayor.ToString("#,##0.00");
            txtSaldo.Text = dSaldo.ToString("#,##0.00");
        }

        /// <summary>
        /// Método para cargar las compañías relacionada.
        /// </summary>
        private void _Mtd_CargarComboCompañias()
        {
            string sSQL;

            sSQL = "select dbo.TICRELAPROCLI.cproveedor, dbo.TICRELAPROCLI.cproveedor + ' - ' + dbo.TPROVEEDOR.c_nomb_comer";
            sSQL += " from dbo.TICRELAPROCLI inner join dbo.TPROVEEDOR on dbo.TICRELAPROCLI.cproveedor = dbo.TPROVEEDOR.cproveedor";
            sSQL += " where (dbo.TPROVEEDOR.ccompany = '" + Frm_Padre._Str_Comp + "') order by TICRELAPROCLI.cproveedor";

            oVariosMetodos._Mtd_CargarCombo(cmbCompaniaRelacionada, sSQL);
        }

        /// <summary>
        /// Método para consultar el consolidado resumido.
        /// </summary>
        private void _Mtd_ConsultarConsolidadoResumido()
        {
            string sSQL;

            sSQL = "select temporal.cproveedor, c_nomb_comer, dbo.Fnc_Formatear(sum(cmontomenor)) as cmonto1, dbo.Fnc_Formatear(sum(cmontomayor)) as cmonto2 from (";
            sSQL += " select VST_CONSOLIDADO_INTERCOMPANIAS.cproveedor, case when ctipo in ('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO CXC') then cmonto else (-1 * cmonto) end as cmontomenor, 0 as cmontomayor from VST_CONSOLIDADO_INTERCOMPANIAS";
            sSQL += " where (datediff(day, cfechaemision, cfechavencimiento) <= 30) and (cestado = 0) and (cimpreso = 1) and (canulado = 0) and (csaldo <> 0)";
            sSQL += cmbCompaniaRelacionada.SelectedIndex != 0 ? " and cproveedor = '" + cmbCompaniaRelacionada.SelectedValue + "'" : "";
            sSQL += " union select VST_CONSOLIDADO_INTERCOMPANIAS.cproveedor, 0 as cmontomenor, case when ctipo in ('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO CXC') then cmonto else (-1 * cmonto) end as cmontomayor from VST_CONSOLIDADO_INTERCOMPANIAS";
            sSQL += " where (datediff(day, cfechaemision, cfechavencimiento) > 30) and (cestado = 0) and (cimpreso = 1) and (canulado = 0) and (csaldo <> 0)";
            sSQL += cmbCompaniaRelacionada.SelectedIndex != 0 ? " and cproveedor = '" + cmbCompaniaRelacionada.SelectedValue + "'" : "";
            sSQL += " ) as temporal inner join TPROVEEDOR on temporal.cproveedor = TPROVEEDOR.cproveedor group by temporal.cproveedor, c_nomb_comer";

            dtgConsolidado.DataSource = oConexion._mtd_conexion._Mtd_RetornarDataset(sSQL).Tables[0];
            dtgConsolidado.Columns["colProveedor"].Visible = (cmbCompaniaRelacionada.SelectedIndex == 0) ? true : false;
            dtgConsolidado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        #endregion

        #region Eventos

        public Frm_ConsolidadoInterResumido()
        {
            InitializeComponent();

            _Mtd_CargarComboCompañias();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            _Mtd_ConsultarConsolidadoResumido();
            _Mtd_CalcularTotales();

            Cursor = Cursors.Default;
        }

        private void dtgConsolidado_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string sCodigoProveedor = dtgConsolidado.Rows[e.RowIndex].Cells["colCodigo"].Value.ToString();

                if (sCodigoProveedor != null)
                {
                    Frm_ConsolidadoIntercomp oFormulario = new Frm_ConsolidadoIntercomp(sCodigoProveedor);

                    oFormulario.MdiParent = this.MdiParent;
                    oFormulario.Dock = DockStyle.Fill;
                    oFormulario.Show();
                }
            }
        }

        #endregion        
    }
}