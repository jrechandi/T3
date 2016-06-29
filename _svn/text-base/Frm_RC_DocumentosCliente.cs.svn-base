using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.RelacionCobranza;
using T3.CLASES;
using clslibraryconssa;

namespace T3
{
    #region Clases

    namespace RelacionCobranza
    {
        /// <summary>Almacena temporalemente los datos del encabezado de la relación de cobranza por compañía.</summary>
        public class EncabezadoRelacion
        {
            /// <summary>Establece o devuelve el identificador de la relación de cobranza.</summary>
            public string IdRelacion { get; set; }

            /// <summary>Establece o devuelve el identificador de la compañía.</summary>
            public string IdCompañia { get; set; }

            /// <summary>Establece o devuelve si el usuario es vendedor.</summary>
            public string IdVendedor { get; set; }

            /// <summary>Establece o devuelve el identificador del gerente de área.</summary>
            public string IdGerenteArea { get; set; }
            
            /// <summary>Establece o devuelve el identificador de la zona.</summary>
            public string IdZona { get; set; }

            /// <summary>Establece o devuelve el identificador del usuario.</summary>
            public string IdUsuario { get; set; }

            /// <summary>Establece o devuelve el nombre de la compañía.</summary>
            public string NombreCompañia { get; set; }
        }

        /// <summary>Almacena temporalmento los datos del cheque cargado en el pago.</summary>
        public class ChequePago
        {
            /// <summary>Establece o devuelve el identificador del banco del cheque.</summary>
            public string IdBanco { get; set; }

            /// <summary>Establece o devuelve el identificador el nombre del banco.</summary>
            public string Banco { get; set; }

            /// <summary>Establece o devuelve el texto mostrado en el combo.</summary>
            public string Texto { get; set; }

            /// <summary>Establece o devuelve el número del cheque.</summary>
            public string NumeroCheque { get; set; }

            /// <summary>Establece o devuelve la fecha de emisión.</summary>
            public DateTime FechaEmision { get; set; }

            /// <summary>Establece o devuelve la fecha de depositar.</summary>
            public DateTime FechaDepositar { get; set; }

            /// <summary>Establece o devuelve el monto del cheque.</summary>
            public double Monto { get; set; }
        }
    }

    #endregion

    public partial class Frm_RC_DocumentosCliente : Form
    {
        #region Variables

        /// <summary>Código de la guía de despacho.</summary>
        private string gGuiaDespacho;

        /// <summary>Código del cliente de la guía de despacho.</summary>
        private string gCliente;

        /// <summary>Objeto con métodos varios.</summary>
        private _Cls_Varios_Metodos gUtilidad = new _Cls_Varios_Metodos(true);

        /// <summary>Lista para los encabezados de las relaciones.</summary>
        private List<EncabezadoRelacion> gEncabezadoRelacion = new List<EncabezadoRelacion>();

        #endregion

        #region Métodos

        /// <summary>Contructor del formulario.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <param name="pCliente">Código del cliente.</param>
        public Frm_RC_DocumentosCliente(string pGuia, string pCliente)
        {
            bool bCancelar = false;

            DataSet oCompañias = obtenerEmpresasGuia(pGuia);

            gGuiaDespacho = pGuia;

            gCliente = pCliente;

            /* 
             *  Aqui se hace lo siguiente:
             * 
             *      1. Se genera los encabezados de la relación o se buscan para la guía ingresada.
             *      2. Se verifica si el usuario actual está creado como un vendedor en TUSUARIOCOBRANZA.
             *      3. Se emitirá un mensaje de advertencia y se cierra el formulario cuando el usuario no sea vendedor en una de las compañías.
             *      4. Cargamos el detalle el detalle de la guía de despacho o de las relaciones de cobranza si tiene asignada.
             */

            foreach (DataRow oFila in oCompañias.Tables[0].Rows)
            {
                cargarEncabezados(pGuia, oFila["ccompany"].ToString());
            }

            foreach (EncabezadoRelacion oCampo in gEncabezadoRelacion)
            {
                //if (oCampo.IdVendedor == "")
                //{
                //    MessageBox.Show
                //    (
                //        "Para cargar las relaciones de cobranza, su usuario debe estar creado como un vendedor en " + oCampo.NombreCompañia + ".",
                //        "Advertencia",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information
                //    );

                //    bCancelar = true;

                //    break;
                //}

                //if (oCampo.IdGerenteArea == "")
                //{
                //    MessageBox.Show
                //    (
                //        "Para cargar las relaciones de cobranza, su usuario debe tener un gerente de área asignado en " + oCampo.NombreCompañia + ".",
                //        "Advertencia",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information
                //    );

                //    bCancelar = true;

                //    break;
                //}

                //if (oCampo.IdZona == "")
                //{
                //    MessageBox.Show
                //    (
                //        "Para cargar las relaciones de cobranza, su usuario debe tener una zona asignada en " + oCampo.NombreCompañia + ".",
                //        "Advertencia",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information
                //    );

                //    bCancelar = true;

                //    break;
                //}
            }

            if (bCancelar)
            {
                gEncabezadoRelacion.Clear();

                Close();
            }
            else
            {
                InitializeComponent();

                mostrarCliente(pCliente);

                cargarDetalles(pGuia, pCliente);
            }
        }

        /// <summary>Carga el encabezado de la relación de cobranza por compañía.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <param name="pCompañia">Código de la compañía.</param>
        private void cargarEncabezados(string pGuia, string pCompañia)
        {
            string sSQL;

            /* 
             *  Aqui se hace lo siguiente:
             * 
             *      1. Se verifica si la guía tiene relaciones de cobranza asignadas, se toma el encabezado si la tiene.
             *      2. En caso contrario se genera un nuevo encabezado.
             */

            sSQL = "select TRELACCOBM.ccompany, cidrelacobro, cvendedor, cgerarea, c_zona, cname, TRELACCOBM.cuseradd from TRELACCOBM";
            sSQL += " inner join TCOMPANY on TRELACCOBM.ccompany=TCOMPANY.ccompany";
            sSQL += " where ((cguiacobro=" + pGuia + ") and TRELACCOBM.ccompany=('" + pCompañia + "') and (TRELACCOBM.cdelete=0));";

            DataSet oEncabezadoRelacion = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            if (oEncabezadoRelacion.Tables[0].Rows.Count == 0)
            {
                sSQL = "select TVENDEDOR.cvendedor, cgerarea, c_zona, ltrim(rtrim(TCOMPANY.cname)) as cname from TUSUARIOCOBRANZA";
                sSQL += " inner join TVENDEDOR on TUSUARIOCOBRANZA.cvendedor=TVENDEDOR.cvendedor";
                sSQL += " inner join TCOMPANY on TUSUARIOCOBRANZA.ccompany=TCOMPANY.ccompany";
                sSQL += " where ((cuser='" + Frm_Padre._Str_Use + "') and TUSUARIOCOBRANZA.ccompany=('" + pCompañia + "') and (TUSUARIOCOBRANZA.cdelete=0));";

                DataSet oEncabezadoNuevo = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                if (oEncabezadoNuevo.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow oCampo in oEncabezadoNuevo.Tables[0].Rows)
                    {
                        gEncabezadoRelacion.Add(new EncabezadoRelacion
                        {
                            IdCompañia = pCompañia,
                            IdVendedor = oCampo["cvendedor"].ToString().Trim(),
                            IdGerenteArea = oCampo["cgerarea"].ToString().Trim(),
                            IdZona = oCampo["c_zona"].ToString().Trim(),
                            IdUsuario = Frm_Padre._Str_Use,
                            NombreCompañia = oCampo["cname"].ToString()
                        });
                    }
                }
            }
            else
            {
                foreach (DataRow oCampo in oEncabezadoRelacion.Tables[0].Rows)
                {
                    gEncabezadoRelacion.Add(new EncabezadoRelacion
                    {
                        IdCompañia = oCampo["ccompany"].ToString().Trim(),
                        IdVendedor = oCampo["cvendedor"].ToString().Trim(),
                        IdGerenteArea = oCampo["cgerarea"].ToString().Trim(),
                        IdZona = oCampo["c_zona"].ToString().Trim(),
                        IdUsuario = oCampo["cuseradd"].ToString(),
                        NombreCompañia = oCampo["cname"].ToString().Trim()
                    });
                }
            }
        }

        /// <summary>Carga los documentos del cliente según la guía o la relación de cobranza.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <param name="pCliente">Código del cliente.</param>
        private void cargarDetalles(string pGuia, string pCliente)
        {
            string sSQL;

            /* 
             *  Aqui se hace lo siguiente:
             * 
             *      1. Se verifica si la guía tiene una relación de cobranza asignada, se toman los documentos de la misma, si la tiene.
             *      2. En caso contrario, se busca en el detalle de la guía los documentos y se genera un nuevo detalle.
             */

            sSQL = "select cidrelacobro from TRELACCOBM where ((cguiacobro=" + pGuia + ") and (cdelete=0));";

            DataSet oRelacion = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            if (oRelacion.Tables[0].Rows.Count == 0)
            {
                sSQL = "select dbo.TGUIADESPACHOD.ccompany, dbo.TGUIADESPACHOD.cfactura, dbo.TVENDEDOR.cvendedor, (dbo.TVENDEDOR.cvendedor + ' - ' + dbo.TVENDEDOR.cname) as cname, convert(varchar, convert(datetime, dbo.TFACTURAM.c_fecha_factura, 103), 101) as c_fecha_factura, (dbo.TFACTURAM.c_montotot_si_bs + dbo.TFACTURAM.c_impuesto_bs) AS cmontototal, '' as cnotacredito, '' as cretencion, 0 as ccobradocheque, 0 as ccobradoefectivo, (dbo.TFACTURAM.c_montotot_si_bs + dbo.TFACTURAM.c_impuesto_bs) AS csaldo from dbo.TSALDOCLIENTED";
                sSQL += " inner join dbo.TCONFIGCXC on dbo.TSALDOCLIENTED.ctipodocument = dbo.TCONFIGCXC.ctipdocfact and dbo.TSALDOCLIENTED.ccompany = dbo.TCONFIGCXC.ccompany";
                sSQL += " inner join dbo.TGUIADESPACHOD";
                sSQL += " inner join dbo.TFACTURAM on dbo.TGUIADESPACHOD.cfactura = dbo.TFACTURAM.cfactura and dbo.TGUIADESPACHOD.ccompany = dbo.TFACTURAM.ccompany and dbo.TGUIADESPACHOD.cgroupcomp = dbo.TFACTURAM.cgroupcomp";
                sSQL += " inner join dbo.TVENDEDOR on dbo.TFACTURAM.cvendedor = dbo.TVENDEDOR.cvendedor and dbo.TFACTURAM.ccompany = dbo.TVENDEDOR.ccompany on dbo.TSALDOCLIENTED.cgroupcomp = dbo.TFACTURAM.cgroupcomp AND dbo.TSALDOCLIENTED.ccompany = dbo.TFACTURAM.ccompany and dbo.TSALDOCLIENTED.cnumdocu = dbo.TFACTURAM.cfactura";
                sSQL += " where ((TGUIADESPACHOD.cguiadesp=" + pGuia + ") and (TFACTURAM.ccliente=" + pCliente + ") and (TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') and (TGUIADESPACHOD.c_fact_anul=0) and (c_estatus='PAG'));";
            }
            else
            {
                sSQL = "select cgroupcompany, ccompany, ccliente, ctipodocument, cnumdocu from TRELACCOBD";
                sSQL += " inner join TRELACCOBM.cidrelacobro=TRELACCOBD.cidrelacobro and TRELACCOBM.ccompany=TRELACCOBD.ccompany and TRELACCOBM.cgroupcomp=TRELACCOBD.cgroupcomp";
                sSQL += " where ((ccliente='" + pCliente + "') and (cguiacobro=" + pGuia + "));";
            }

            DataSet oDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            dtgDocumentos.DataSource = oDetalle.Tables[0].DefaultView;
            dtgDocumentos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dtgDocumentos.AllowUserToAddRows = false;
            dtgDocumentos.AllowUserToResizeRows = false;
            dtgDocumentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgDocumentos.AllowUserToResizeColumns = false;
            dtgDocumentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgDocumentos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            
            dtgDocumentos.Columns[0].Visible = false;

            dtgDocumentos.Columns[1].HeaderText = "Factura";            
            dtgDocumentos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDocumentos.Columns[1].Width = 100;
            dtgDocumentos.Columns[1].ReadOnly = true;

            dtgDocumentos.Columns[2].Visible = false;

            dtgDocumentos.Columns[3].HeaderText = "Vendedor";            
            dtgDocumentos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDocumentos.Columns[3].Width = 290;
            dtgDocumentos.Columns[3].ReadOnly = true;
            
            dtgDocumentos.Columns[4].Visible = false;

            dtgDocumentos.Columns[5].HeaderText = "Monto";
            dtgDocumentos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDocumentos.Columns[5].Width = 120;
            dtgDocumentos.Columns[5].ReadOnly = true;
            dtgDocumentos.Columns[5].DefaultCellStyle.Format = "c";

            dtgDocumentos.Columns[6].HeaderText = "Nota crédito";
            dtgDocumentos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDocumentos.Columns[6].Width = 100;
            dtgDocumentos.Columns[6].ReadOnly = true;

            dtgDocumentos.Columns[7].HeaderText = "Retención";
            dtgDocumentos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDocumentos.Columns[7].Width = 100;
            dtgDocumentos.Columns[7].ReadOnly = true;

            dtgDocumentos.Columns[8].HeaderText = "Cobrado en cheque";
            dtgDocumentos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDocumentos.Columns[8].Width = 120;
            dtgDocumentos.Columns[8].ReadOnly = true;
            dtgDocumentos.Columns[8].DefaultCellStyle.Format = "c";

            dtgDocumentos.Columns[9].HeaderText = "Cobrado en efectivo";
            dtgDocumentos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDocumentos.Columns[9].Width = 120;
            dtgDocumentos.Columns[9].ReadOnly = true;
            dtgDocumentos.Columns[9].DefaultCellStyle.Format = "c";

            dtgDocumentos.Columns[10].HeaderText = "Saldo";
            dtgDocumentos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDocumentos.Columns[10].Width = 120;
            dtgDocumentos.Columns[10].ReadOnly = true;
            dtgDocumentos.Columns[10].DefaultCellStyle.Format = "c";
            
            double dTotal = 0;

            foreach (DataGridViewRow oFila in dtgDocumentos.Rows)
            {
                dTotal += Convert.ToDouble(oFila.Cells["cmontototal"].Value.ToString());
            }

            txtTotalCobrado.Text = dTotal.ToString("c");
        }

        /// <summary>Obtiene las empresas de la guía de despacho.</summary>
        /// <param name="pGuia">Código de la guía de despacho.</param>
        /// <returns>Compañías en el detalle de la guía de despacho.</returns>
        private DataSet obtenerEmpresasGuia(string pGuia)
        {
            string sSQL;

            sSQL = "select distinct ltrim(rtrim(TGUIADESPACHOD.ccompany)) as ccompany, ltrim(rtrim(cname)) as cname from TGUIADESPACHOD";
            sSQL += " inner join TCOMPANY on TGUIADESPACHOD.ccompany=TCOMPANY.ccompany";
            sSQL += " where ((cguiadesp=" + pGuia + ") and (cgroupcomp='" + Frm_Padre._Str_GroupComp + "'));";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);
        }

        /// <summary>Obtiene el nombre del cliente de la guía de despacho.</summary>
        /// <param name="pCliente">Código del cliente</param>
        private void mostrarCliente(string pCliente)
        {
            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select c_nomb_comer from TCLIENTE where (ccliente=" + pCliente + ");");

            Text = Text.Replace("Documentos", pCliente);
            Text = Text.Replace("[Nombre]", oResultado.Tables[0].Rows[0]["c_nomb_comer"].ToString());
        }

        #endregion

        #region Eventos

        private void btPagoCheque_Click(object sender, EventArgs e)
        {
            Frm_RC_PagoCheque frmPagoCheque = new Frm_RC_PagoCheque(gGuiaDespacho, gCliente);

            frmPagoCheque.ShowDialog();
        }

        private void btPagoEfectivo_Click(object sender, EventArgs e)
        {

        }

        private void btFinalizar_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
