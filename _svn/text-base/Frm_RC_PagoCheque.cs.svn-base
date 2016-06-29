using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.RelacionCobranza;

namespace T3
{
    public partial class Frm_RC_PagoCheque : Form
    {
        #region Variables

        /// <summary>Código de la guía de despacho.</summary>
        private string gGuiaDespacho;

        /// <summary>Código del cliente de la guía de despacho.</summary>
        private string gCliente;

        /// <summary>Lista con los cheques cargados por el usuario.</summary>
        private List<ChequePago> gListaCheques = new List<ChequePago>();

        #endregion

        #region Métodos

        /// <summary>Constructor del formulario.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <param name="pCliente">Código del cliente de la guía.</param>
        public Frm_RC_PagoCheque(string pGuia, string pCliente)
        {
            InitializeComponent();

            gGuiaDespacho = pGuia;
            gCliente = pCliente;            

            cargarFacturas(pGuia, pCliente);
            cargarNotasCredito(pCliente);
            cargarBancos(cmbBanco);
        }

        /// <summary>Carga los bancos en combo correspondiente.</summary>
        /// <param name="pCombo">Combo del banco.</param>
        private void cargarBancos(ComboBox pCombo)
        {
            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select distinct cbanco, cname from TBANCO where (cdelete=0) order by cbanco asc;");

            pCombo.DataSource = oResultado.Tables[0];
            pCombo.DisplayMember = "cname";
            pCombo.ValueMember = "cbanco";
        }

        /// <summary>Carga las facturas del cliente según la guía o la relación de cobranza.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <param name="pCliente">Código del cliente de la guía de despacho.</param>
        private void cargarFacturas(string pGuia, string pCliente)
        {
            string sSQL;

            sSQL = "select dbo.TGUIADESPACHOD.ccompany, dbo.TGUIADESPACHOD.cfactura, convert(varchar, convert(datetime, dbo.TFACTURAM.c_fecha_factura, 103), 101) as c_fecha_factura, convert(varchar, convert(datetime, dbo.TSALDOCLIENTED.cfechaentrega, 103), 101) as cfechaentrega, (dbo.TFACTURAM.c_montotot_si_bs + dbo.TFACTURAM.c_impuesto_bs) AS cmontototal from dbo.TSALDOCLIENTED";
            sSQL += " inner join dbo.TCONFIGCXC on dbo.TSALDOCLIENTED.ctipodocument = dbo.TCONFIGCXC.ctipdocfact and dbo.TSALDOCLIENTED.ccompany = dbo.TCONFIGCXC.ccompany";
            sSQL += " inner join dbo.TGUIADESPACHOD";
            sSQL += " inner join dbo.TFACTURAM on dbo.TGUIADESPACHOD.cfactura = dbo.TFACTURAM.cfactura and dbo.TGUIADESPACHOD.ccompany = dbo.TFACTURAM.ccompany and dbo.TGUIADESPACHOD.cgroupcomp = dbo.TFACTURAM.cgroupcomp";
            sSQL += " inner join dbo.TVENDEDOR on dbo.TFACTURAM.cvendedor = dbo.TVENDEDOR.cvendedor and dbo.TFACTURAM.ccompany = dbo.TVENDEDOR.ccompany on dbo.TSALDOCLIENTED.cgroupcomp = dbo.TFACTURAM.cgroupcomp AND dbo.TSALDOCLIENTED.ccompany = dbo.TFACTURAM.ccompany and dbo.TSALDOCLIENTED.cnumdocu = dbo.TFACTURAM.cfactura";
            sSQL += " where ((TGUIADESPACHOD.cguiadesp=" + pGuia + ") and (TFACTURAM.ccliente=" + pCliente + ") and (TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') and (TGUIADESPACHOD.c_fact_anul=0) and (c_estatus='PAG'));";

            DataSet oDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            dtgFacturas.DataSource = oDetalle.Tables[0];
        }

        /// <summary>Sobrecarga que obtiene las facturas del cliente según la guía o la relación de cobranza y la compañia.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <param name="pCliente">Código del cliente de la guía de despacho.</param>
        /// <param name="pCompañia">Código de la compañia.</param>
        /// <returns>Facturas filtradas por compañia.</returns>
        private DataTable cargarFacturas(string pGuia, string pCliente, string pCompañia)
        {
            string sSQL;

            sSQL = "select dbo.TGUIADESPACHOD.cfactura from dbo.TSALDOCLIENTED";
            sSQL += " inner join dbo.TCONFIGCXC on dbo.TSALDOCLIENTED.ctipodocument = dbo.TCONFIGCXC.ctipdocfact and dbo.TSALDOCLIENTED.ccompany = dbo.TCONFIGCXC.ccompany";
            sSQL += " inner join dbo.TGUIADESPACHOD";
            sSQL += " inner join dbo.TFACTURAM on dbo.TGUIADESPACHOD.cfactura = dbo.TFACTURAM.cfactura and dbo.TGUIADESPACHOD.ccompany = dbo.TFACTURAM.ccompany and dbo.TGUIADESPACHOD.cgroupcomp = dbo.TFACTURAM.cgroupcomp";
            sSQL += " inner join dbo.TVENDEDOR on dbo.TFACTURAM.cvendedor = dbo.TVENDEDOR.cvendedor and dbo.TFACTURAM.ccompany = dbo.TVENDEDOR.ccompany on dbo.TSALDOCLIENTED.cgroupcomp = dbo.TFACTURAM.cgroupcomp AND dbo.TSALDOCLIENTED.ccompany = dbo.TFACTURAM.ccompany and dbo.TSALDOCLIENTED.cnumdocu = dbo.TFACTURAM.cfactura";
            sSQL += " where ((TGUIADESPACHOD.ccompany='" + pCompañia + "') and (TGUIADESPACHOD.cguiadesp=" + pGuia + ") and (TFACTURAM.ccliente=" + pCliente + ") and (TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') and (TGUIADESPACHOD.c_fact_anul=0) and (c_estatus='PAG'));";

            DataSet oDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            return oDetalle.Tables[0];
        }

        /// <summary>Carga las notas de crédito del cliente sin aplicar.</summary>
        /// <param name="pCliente">Código del cliente.</param>
        private void cargarNotasCredito(string pCliente)
        {
            string sSQL = "";

            if (retieneImpuesto(pCliente))
            {
                
            }
            else
            {
                sSQL = "select ccompany, cidnotcredicc, ctotaldocu from TNOTACREDICC";
                sSQL += " where ((cgroupcomp='" + Frm_Padre._Str_GroupComp + "') and (ccompany='" + Frm_Padre._Str_Comp + "') and (ccliente='" + pCliente + "') and (cdescontada=0) and (canulado=0) and (cactivo=1))";
                sSQL += " order by cidnotcredicc;";
            }

            DataSet oDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            dtgNotasCreditos.DataSource = oDetalle.Tables[0];
        }

        /// <summary>Verifica si el cliente retiene impuesto.</summary>
        /// <param name="pCliente">Código del cliente.</param>
        /// <returns>Verdadero si es un cliente de retencíón.</returns>
        private bool retieneImpuesto(string pCliente)
        {
            string sSQL;

            bool bRetieneImpuesto = false;

            sSQL = "select cretieneimp from TCLIENTE";
            sSQL += " inner join TCONTRIBUYENTE on TCLIENTE.c_tip_contribuy = TCONTRIBUYENTE.CCONTRIBUYENTE";
            sSQL += " where ((tcliente.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') and (tcliente.CCLIENTE='" + pCliente + "'));";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            if (oResultado.Tables[0].Rows.Count > 0)
            {
                bRetieneImpuesto = ((oResultado.Tables[0].Rows[0]["cretieneimp"].ToString() == "1") ? true : false);
            }

            return bRetieneImpuesto;
        }

        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgNotasCreditos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewComboBoxCell oCeldaCombo = (DataGridViewComboBoxCell)dtgNotasCreditos.Rows[e.RowIndex].Cells[1];
            DataGridViewTextBoxCell oCeldaCompañia = (DataGridViewTextBoxCell) dtgNotasCreditos.Rows[e.RowIndex].Cells[2];

            oCeldaCombo.DataSource = cargarFacturas(gGuiaDespacho, gCliente, oCeldaCompañia.Value.ToString().Trim());
            oCeldaCombo.DisplayMember = "cfactura";
            oCeldaCombo.ValueMember = "cfactura";
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            if (cmbChequeTransito.SelectedIndex == -1)
            {
                if (txtNumeroCheque.Text == "")
                {
                    MessageBox.Show
                    (
                        "Indica el número del cheque.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtNumeroCheque.Focus();

                    return;
                }

                if (txtMontoCheque.Text == "")
                {
                    MessageBox.Show
                    (
                        "Indica un monto.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtMontoCheque.Focus();

                    return;
                }

                gListaCheques.Add(new ChequePago
                {
                    Texto = ("Cheque: " + txtNumeroCheque.Text + " - " + Convert.ToDouble(txtMontoCheque.Text).ToString("c")),
                    NumeroCheque = txtNumeroCheque.Text,
                    FechaEmision = dtpFechaEmision.Value,
                    FechaDepositar = dtpFechaDepositar.Value,
                    IdBanco = cmbBanco.SelectedValue.ToString(),
                    Banco = cmbBanco.SelectedText,
                    Monto = Convert.ToDouble(txtMontoCheque.Text)
                });

                cmbChequeTransito.DataSource = null;
                cmbChequeTransito.DataSource = gListaCheques;
                cmbChequeTransito.DisplayMember = "Texto";
                cmbChequeTransito.ValueMember = "NumeroCheque";
                cmbChequeTransito.SelectedIndex = -1;

                cmbBanco.SelectedIndex = 0;

                dtpFechaEmision.Value = DateTime.Now;
                dtpFechaDepositar.Value = DateTime.Now;

                txtNumeroCheque.Text = "";

                txtMontoCheque.Text = "";

                txtSaldo.Text = "";
            }
            else
            {
                cmbBanco.SelectedIndex = 0;

                dtpFechaEmision.Value = DateTime.Now;
                dtpFechaEmision.Enabled = true;

                dtpFechaDepositar.Value = DateTime.Now;
                dtpFechaDepositar.Enabled = true;

                txtNumeroCheque.Text = "";
                txtNumeroCheque.ReadOnly = false;
                txtNumeroCheque.Focus();

                txtMontoCheque.Text = "";
                txtMontoCheque.ReadOnly = false;

                txtSaldo.Text = "";

                cmbBanco.Enabled = true;
            }
        }

        private void cmbChequeTransito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChequeTransito.SelectedItem != null)
            {
                ChequePago oCheque = (ChequePago)cmbChequeTransito.SelectedItem;

                cmbBanco.SelectedValue = oCheque.IdBanco;
                cmbBanco.Enabled = false;

                dtpFechaEmision.Value = oCheque.FechaEmision;
                dtpFechaEmision.Enabled = false;

                dtpFechaDepositar.Value = oCheque.FechaDepositar;
                dtpFechaDepositar.Enabled = false;

                txtNumeroCheque.Text = oCheque.NumeroCheque;
                txtNumeroCheque.ReadOnly = true;

                txtMontoCheque.Text = oCheque.Monto.ToString("c");
                txtMontoCheque.ReadOnly = true;

                txtSaldo.Text = oCheque.Monto.ToString("c");
            }
            else
            {
                cmbBanco.Enabled = true;

                dtpFechaEmision.Enabled = true;
                dtpFechaDepositar.Enabled = true;

                txtNumeroCheque.ReadOnly = false;
                txtMontoCheque.ReadOnly = false;
            }
        }

        #endregion
    }
}
