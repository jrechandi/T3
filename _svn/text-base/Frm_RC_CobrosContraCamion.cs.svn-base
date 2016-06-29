using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_RC_CobrosContraCamion : Form
    {
        private string _G_Str_Cguiadesp = "";
        private Dictionary<string, _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente> _Dic_Colores;

        public Frm_RC_CobrosContraCamion()
        {
            InitializeComponent();
        }

        private void Frm_CobrosContraCamion_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            _Mtd_Actualizar();
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            _Dg_Grid_Guia.SuspendLayout();

            var _Str_Cadena = "SELECT * FROM VST_RC_GUIASPORCOBRAR WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid_Guia.DataSource = _Ds.Tables[0];
            _Dg_Grid_Guia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid_Guia.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Guia.Columns[3].DefaultCellStyle.Format = "c";
            _Dg_Grid_Guia.Columns[4].Visible = false;

            ////Consultamos los Montos Cobrados
            //_Dg_Grid_Guia.Rows.Cast<DataGridViewRow>().ToList().ForEach(row =>
            //    {
            //        var _Str_cguiadesp = row.Cells["Guía"].Value.ToString();
            //        var _Dbl_Monto = 0.0;
            //        _Str_Cadena = "SELECT * FROM VST_RC_GUIASPORCOBRAR_SALDO WHERE cguiadesp = '" + _Str_cguiadesp + "'";
            //        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //        if (_Ds.Tables[0].Rows.Count > 0)
            //            Double.TryParse(_Ds.Tables[0].Rows[0]["Saldo"].ToString(), out _Dbl_Monto);
            //        var _Str_Monto = _Dbl_Monto.ToString("c");
            //        row.Cells["Monto Cobrado"].Value = _Str_Monto;
            //    });

            _Dg_Grid_Guia.ResumeLayout();
            Cursor = Cursors.Default;
        }

        private void _Dg_Grid_Guia_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid_Guia.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                _G_Str_Cguiadesp = Convert.ToString(_Dg_Grid_Guia.Rows[_Dg_Grid_Guia.CurrentCell.RowIndex].Cells["Guía"].Value);
                _Mtd_CargarClientes(_G_Str_Cguiadesp);
                _Tb_Tab.SelectTab(1);
                _Mtd_ColorearClientes(_G_Str_Cguiadesp, true);
                _Tb_Tab_Clientes.Text = "Clientes - Guia #" + _G_Str_Cguiadesp;
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_CargarClientes(string _P_Str_Cguiadesp)
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los Clientes al grid
            var _Str_Cadena = "SELECT * " +
                              "FROM VST_RC_CLIENTESPORCOBRAR " +
                              "WHERE (cguiadesp = '" + _P_Str_Cguiadesp + "') " +
                              "ORDER BY Cliente"; 
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid_Clientes.DataSource = _Ds.Tables[0];
            _Dg_Grid_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid_Clientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Clientes.Columns[2].DefaultCellStyle.Format = "C";
            _Dg_Grid_Clientes.Columns[3].Visible = false;

            ////Consutamos los Montos Cobrados (por cliente)
            //_Dg_Grid_Clientes.Rows.Cast<DataGridViewRow>().ToList().ForEach(row =>
            //{
            //    var _Str_ccliente = row.Cells["Cliente"].Value.ToString();
            //    var _Dbl_MontoOriginal = Convert.ToDouble(row.Cells["Saldo"].Value);
            //    //_Str_Cadena = "SELECT SUM((cmontocancelado+cmontoretencion+cmontodescuentos+cmontonotascredito)) As [Monto] FROM VST_RC_COBROSCONTRACAMION_MONTOCOBRADO WHERE cguiacobro='" + _P_Str_Cguiadesp + "' AND ccliente = '" + _Str_ccliente + "'";
            //    _Str_Cadena = "SELECT * FROM VST_RC_CLIENTESPORCOBRAR_SALDO  WHERE cguiacobro='" + _P_Str_Cguiadesp + "' AND ccliente = '" + _Str_ccliente + "'";
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //    if (_Ds.Tables[0].Rows.Count > 0)
            //    {
            //        var _Dbl_Monto = 0.0;
            //        Double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Monto);
            //        if (_Dbl_Monto > 0)
            //            row.Cells["Saldo"].Value = _Dbl_MontoOriginal - _Dbl_Monto;
            //    }
            //});

            Cursor = Cursors.Default;
        }

        private void _Mtd_ObtenerColoresCliente(string _P_Str_Cguiadesp)
        {
            //Cargamos los documentos en al guia
            var _Docs_EnGuia = _Cls_RutinasGuiasRelacionesCobranza._Mtd_ObtenerTodosLosDocumentosSegunGuiaDespacho_EnGuia(_P_Str_Cguiadesp, Frm_Padre._Str_GroupComp);
            var _Docs_EnCobranza = _Cls_RutinasGuiasRelacionesCobranza._Mtd_ObtenerTodosLosDocumentosSegunGuiaDespacho_EnCobranza(_P_Str_Cguiadesp, Frm_Padre._Str_GroupComp);

            //Inicializamos
            _Dic_Colores = new Dictionary<string, _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente>();

            foreach (DataGridViewRow _DtRow in _Dg_Grid_Clientes.Rows)
            {
                var _TipoEstadoCobranza = _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.NadaCargado;
                var _Str_ccliente = _DtRow.Cells["Cliente"].Value.ToString();

                //Obtenemos los datos a comparar
                var _Docs_EnGuia_Cliente = _Docs_EnGuia.Where(x => x.ccliente == _Str_ccliente).ToList();
                var _Docs_EnCobranza_Cliente = _Docs_EnCobranza.Where(x => x.ccliente == _Str_ccliente).ToList();

                //Comparamos
                //Nada cargado
                if ((_Docs_EnGuia_Cliente.Count > 0) == (_Docs_EnCobranza_Cliente.Count == 0))
                {
                    _TipoEstadoCobranza = _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.NadaCargado;
                }
                //Completa
                else if (_Docs_EnGuia_Cliente.Count == _Docs_EnCobranza_Cliente.Count)
                {
                    _TipoEstadoCobranza = _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.Completa;
                }
                //Incompleta
                else if (_Docs_EnGuia_Cliente.Count > _Docs_EnCobranza_Cliente.Count)
                {
                    _TipoEstadoCobranza = _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.Incompleta;
                }

                //Añadimos al diccionario
                _Dic_Colores.Add(_Str_ccliente, _TipoEstadoCobranza);

            }
        }

        private void _Mtd_ColorearClientes(string _P_Str_Cguiadesp, bool _P_Bol_ConsultarColores = false)
        {
            //Si hay que consultar los colores
            if (_P_Bol_ConsultarColores)
                _Mtd_ObtenerColoresCliente(_P_Str_Cguiadesp);

            //Asignamos los colores al grid
            foreach (DataGridViewRow _DtRow in _Dg_Grid_Clientes.Rows)
            {
                var _TipoEstadoCobranza = _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.NadaCargado;
                var _Str_ccliente = _DtRow.Cells["Cliente"].Value.ToString();

                //Obtenemos el color
                _Dic_Colores.TryGetValue(_Str_ccliente, out _TipoEstadoCobranza);

                //Coloreamos los clientes segun su estado
                switch (_TipoEstadoCobranza)
                {
                    case _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.NadaCargado:
                        _DtRow.DefaultCellStyle.BackColor = Color.White;
                        break;
                    case _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.Incompleta:
                        _DtRow.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case _Cls_RutinasGuiasRelacionesCobranza._TiposEstadoCobranzaCliente.Completa:
                        _DtRow.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        break;
                }
            }
        }
        private void _Btn_MarcarGuiaCobrada_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //Solo si hay cargada una guia
            if (_G_Str_Cguiadesp.Length == 0)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se ha cargado la guía... verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ====================================  MARCAMOS LA GUIA COMO COBRADA   ====================================  

            //Llamar a Rutina de Validacion de la Relación 
            var _Bool_GuiaVerificada = _Cls_RutinasGuiasRelacionesCobranza._Mtd_EsValidaCobranza(Frm_Padre._Str_GroupComp,_G_Str_Cguiadesp, true);

            //Sitodo esta bien, actualizamos
            if (_Bool_GuiaVerificada)
            {
                //Marcamos la Guia como Cobrada
                var _Str_Cadena = "UPDATE TGUIADESPACHOM SET cguiacobrada = '1' WHERE TGUIADESPACHOM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOM.cguiadesp='" + _G_Str_Cguiadesp + "' ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                //Asignamos los codigos de vendedor
                _Cls_RutinasGuiasRelacionesCobranza._Mtd_AsignarCodigosDeVendedor(Frm_Padre._Str_GroupComp, _G_Str_Cguiadesp);

                // ====================================  IMPRESION   ====================================  

                //Mensaje
                MessageBox.Show("Se va a proceder a imprimir el reporte de la relación de cobranza para su verificación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _ImprimirReporte:

                //Mensaje
                MessageBox.Show("Se va a imprimir el reporte de la guía #" + _G_Str_Cguiadesp + " ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Imprimo
                Cursor = Cursors.WaitCursor;
                Frm_RC_Resumen._Mtd_ImprimirReporte(Frm_Padre._Str_GroupComp, Frm_Padre._Str_Comp, _G_Str_Cguiadesp, "0", false);
                Cursor = Cursors.Default;
                //Confirmo que imprimio correctamente 
                Cursor = Cursors.Default;
                if (MessageBox.Show("¿El reporte de verificación de la guía #" + _G_Str_Cguiadesp + " se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    //Devuelvo
                    goto _ImprimirReporte;
                }

                // ====================================  IMPRESION   ====================================  

                //Nos colocamos en la primera pestaña
                _Tb_Tab.SelectTab(0);

                //Recargamos el Grid
                _Mtd_Actualizar();
            }

            Cursor = Cursors.Default;
        }

        private void _Dg_Grid_Clientes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Variables a Pasar 
            var _Str_ccliente = Convert.ToString(_Dg_Grid_Clientes.Rows[_Dg_Grid_Clientes.CurrentCell.RowIndex].Cells["Cliente"].Value);

            //Verificamos si se permite cargar la cobranza del cliente
            if (!_Mtd_EsPermitidoCargarCobranzaCliente(_Str_ccliente, _G_Str_Cguiadesp))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Disculpe, el documento tiene un pago procesado por parte de su casa matriz, solo puede procesar pagos con el código de la casa matriz... verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Llamamos al Formulario de Modo Modal
            var _Frm = new Frm_RC_DocumentosClientes(_G_Str_Cguiadesp, _Str_ccliente, Cobranza.TiposEstadoRelacion.EstadoPagoNueva);
            _Frm.ShowDialog();
            
            _Frm.Dispose();
            _Frm = null;

            //Recargamos el Grid de Clientes
            _Mtd_CargarClientes(_G_Str_Cguiadesp);

            //Coloreamos
            _Mtd_ColorearClientes(_G_Str_Cguiadesp, true);

        }

        public static bool _Mtd_EsPermitidoCargarCobranzaCliente(string _P_Str_ccliente, string _P_Str_cguiaddespacho)
        {
            //Buscamos a ver si existen pagos de los documentos del cliente a actual realizados por otro cliente 
            var _Str_Cadena = " SELECT TTRCPAGOM.ccliente " + 
                              " FROM TTRCPAGOM INNER JOIN TTRCPAGOD ON TTRCPAGOM.cidpago = TTRCPAGOD.cidpago INNER JOIN TTRCDOCUMENTO ON TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia " +
                              " WHERE (TTRCPAGOM.cdelete = 0) AND (TTRCPAGOD.cdelete = 0) AND (TTRCDOCUMENTO.cdelete = 0) AND (TTRCDOCUMENTO.ccliente = " + _P_Str_ccliente + ") AND (TTRCPAGOM.ccliente <> TTRCDOCUMENTO.ccliente)  AND (TTRCPAGOM.cguia = '" + _P_Str_cguiaddespacho + "') ";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count <= 0;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _G_Str_Cguiadesp = "";
                _Tb_Tab_Clientes.Text = "Clientes";
                _Mtd_Actualizar();
            }
            if (e.TabPageIndex != 0)
            {
                if (_G_Str_Cguiadesp == "")
                    e.Cancel = true;
            }
        }

        private void _Dg_Grid_Clientes_Sorted(object sender, EventArgs e)
        {
            //Coloreamos
            _Mtd_ColorearClientes(_G_Str_Cguiadesp);
        }
    }
}