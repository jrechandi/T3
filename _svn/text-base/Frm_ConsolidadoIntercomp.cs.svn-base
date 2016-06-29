// código verificado el 12/06/2012, revision svn 1151 por dgavidia (nomenclatura + comentarios ///)

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
    public partial class Frm_ConsolidadoIntercomp : Form
    {
        // color de la fila seleccionada
        Color _G_Col_ColorFilaSeleccionada = Color.FromArgb(255, 192, 192);

        // se instancia la clase de utilidades
        CLASES._Cls_Varios_Metodos _Cls_Varios_Metodos = new CLASES._Cls_Varios_Metodos(true);

        /// <summary>
        /// ¡constructor!
        /// </summary>
        public Frm_ConsolidadoIntercomp()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// llena los combos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_ConsolidadoIntercomp_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            _Dtg_Principal.DefaultCellStyle.BackColor = Color.White;

            _Mtd_LlenarComboTipoConsulta();
            _Mtd_LlenarComboCompaniasRelacionadas();
            _Mtd_LlenarComboEstado();

            /*
             * Se filtran los documentos si se está llamando el formulario desde Frm_ConsolidadoInterResumido.
             */

            if (gCodigoCompañia != null)
            {
                _Cmb_CompaniaRelacionadaCons.SelectedValue = gCodigoCompañia;
                _Cmb_Estatus.SelectedValue = "0";
                _Cmb_TipoConsulta.SelectedIndex = 0;

                _Mtd_Consultar();
            }
        }

        /// <summary>
        /// Carga del combo de compañias relacionadas
        /// </summary>
        private void _Mtd_LlenarComboCompaniasRelacionadas()
        {
            string _Str_SQL = "";
            
            try
            {
                _Str_SQL = "SELECT dbo.TICRELAPROCLI.cproveedor, dbo.TICRELAPROCLI.cproveedor + ' - ' + dbo.TPROVEEDOR.c_nomb_comer FROM dbo.TICRELAPROCLI INNER JOIN dbo.TPROVEEDOR ON dbo.TICRELAPROCLI.cproveedor = dbo.TPROVEEDOR.cproveedor WHERE (dbo.TPROVEEDOR.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TICRELAPROCLI.cproveedor";
                _Cls_Varios_Metodos._Mtd_CargarCombo(_Cmb_CompaniaRelacionadaCons, _Str_SQL);
            }
            catch
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los estatus dependiendo del proceso
        /// </summary>
        private void _Mtd_LlenarComboEstado()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            string[,] _Str_Listado = null;
            _Str_Listado = new string[,] { { "POR COBRAR Y POR PAGAR", "0" }, { "POR COBRAR", "1" }, { "POR PAGAR", "2" }, { "COBRADOS", "3" }, { "PAGADOS", "4" }, { "ANULADOS", "5" }, { "POR IMPRIMIR", "6" } };
            for (int _Int_I = 0; _Int_I < _Str_Listado.GetLength(0); _Int_I++)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
            }
            _Cmb_Estatus.DataSource = _myArrayList;
            _Cmb_Estatus.DisplayMember = "Display";
            _Cmb_Estatus.ValueMember = "Value";
            _Cmb_Estatus.SelectedValue = "0";
        }

        /// <summary>
        /// Llena el combro de tipo de consulta
        /// </summary>
        private void _Mtd_LlenarComboTipoConsulta()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            string[,] _Str_Listado = null;
            _Str_Listado = new string[,] { { "FACTURAS, NC y ND", "0" }, { "AVISOS DE COBRO", "1" } };
            for (int _Int_I = 0; _Int_I < _Str_Listado.GetLength(0); _Int_I++)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
            }
            _Cmb_TipoConsulta.DataSource = _myArrayList;
            _Cmb_TipoConsulta.DisplayMember = "Display";
            _Cmb_TipoConsulta.ValueMember = "Value";
            _Cmb_TipoConsulta.SelectedValue = "0";
        }

        /// <summary>
        /// actializa el combo, en caso de que haya algun cambio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_CompaniaRelacionadaCons_DropDown(object sender, EventArgs e)
        {
            _Mtd_LlenarComboCompaniasRelacionadas();
        }

        /// <summary>
        /// Llena y actualiza el grid principal
        /// </summary>
        private void _Mtd_Consultar()
        {
            string _Str_SQL = "";
            _Str_SQL += "SELECT cproveedor, cproveedor as [Código], c_nomb_comer as [Compañía relacionada], cnumdocu as [Número documento], CONVERT(VARCHAR,cfechaemision,103) AS [Fecha de Emisión], CONVERT(VARCHAR,cfechavencimiento,103) AS [Fecha de Vencimiento], CASE WHEN ctipo IN('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO CXC') THEN 'NEGRO' ELSE 'ROJO' END as ccolorfila, dbo.Fnc_Formatear(CASE WHEN ctipo IN('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO CXC') THEN cmonto ELSE -1*cmonto END) as [Monto], cimpreso,ctipo as [Tipo documento] ";
            _Str_SQL += "FROM VST_CONSOLIDADO_INTERCOMPANIAS ";
            _Str_SQL += "WHERE CCOMPANY ='" + Frm_Padre._Str_Comp + "'";

            if (_Cmb_TipoConsulta.SelectedIndex > 0)
            {
                switch (_Cmb_TipoConsulta.SelectedValue.ToString())
                {
                    // { "FACTURAS, NC y ND", "0" }
                    case "0": _Str_SQL += "and VST_CONSOLIDADO_INTERCOMPANIAS.ctipo IN ('FACTURA CXC', 'FACTURA CXP', 'NOTA DE CREDITO CXP', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO PROVEEDOR CXP', 'NOTA DE CREDITO CXC', 'NOTA DE DEBITO CXC') "; break;

                    //{ "AVISOS DE COBRO", "1" }, 
                    case "1": _Str_SQL += "and VST_CONSOLIDADO_INTERCOMPANIAS.ctipo IN ('AVISO DE COBRO CXC', 'AVISO DE COBRO CXP') "; break;
                }
            }


            if (_Cmb_CompaniaRelacionadaCons.SelectedIndex > 0)
            {
                _Str_SQL += "and VST_CONSOLIDADO_INTERCOMPANIAS.cproveedor = '" + _Cmb_CompaniaRelacionadaCons.SelectedValue.ToString().Trim() + "'";
            }


            if (_Cmb_Estatus.SelectedIndex > 0) 
            {
                switch(_Cmb_Estatus.SelectedValue.ToString())
                {
                    // { "Por Cobrar y Por Pagar", "0" }
                    case "0": _Str_SQL += "and cimpreso=1 and cestado=0 and canulado=0 and csaldo<>0 and cestado =0"; break;
                    
                    //{ "Por Cobrar", "1" }, 
                    case "1": _Str_SQL += "and cimpreso=1 and cestado=0 and canulado = 0 and csaldo<>0 and ctipo IN ('AVISO DE COBRO CXC','FACTURA CXC','NOTA DE CREDITO CXC','NOTA DE DEBITO CXC') "; break;

                    //{ "Por Pagar", "2" }, 
                    case "2": _Str_SQL += "and cimpreso=1 and cestado=0 and canulado = 0 and csaldo<>0 and ctipo IN ('AVISO DE COBRO CXP','FACTURA CXP','NOTA DE CREDITO CXP','NOTA DE DEBITO CXP','NOTA DE CREDITO PROVEEDOR CXP','NOTA DE DEBITO PROVEEDOR CXP') "; break;

                    //{ "Cobradas", "3" }, 
                    case "3": _Str_SQL += "and cimpreso=1 and cestado=1 and canulado = 0 and ctipo IN ('AVISO DE COBRO CXC','FACTURA CXC','NOTA DE CREDITO CXC','NOTA DE DEBITO CXC') "; break;

                    // { "Pagadas", "4" }, 
                    case "4": _Str_SQL += "and cimpreso=1 and cestado=1 and canulado = 0 and ctipo IN ('AVISO DE COBRO CXP','FACTURA CXP','NOTA DE CREDITO CXP','NOTA DE DEBITO CXP','NOTA DE CREDITO PROVEEDOR CXP','NOTA DE DEBITO PROVEEDOR CXP') "; break;

                    // { "Anuladas", "5" } };
                    case "5": _Str_SQL += "and canulado=1 "; break;

                    // { "Por imprimir", "5" } };
                    case "6": _Str_SQL += "and cimpreso=0 "; break;
                }
            
            }

            _Str_SQL += "ORDER BY VST_CONSOLIDADO_INTERCOMPANIAS.cproveedor, VST_CONSOLIDADO_INTERCOMPANIAS.ctipo, VST_CONSOLIDADO_INTERCOMPANIAS.cnumdocu ";

            try
            {
                _Dtg_Principal.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0];
            }
            catch
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _Dtg_Principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dtg_Principal.Columns["cproveedor"].Visible = false;
            _Dtg_Principal.Columns["cimpreso"].Visible = false;
            _Dtg_Principal.Columns["ccolorfila"].Visible = false;
            _Dtg_Principal.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        
            _Mtd_ActualizarColores();
            _Mtd_Totalizar();

        }

        /// <summary>
        /// Recorre el grid principal y colorea de rojo los documentos 'negativos' segun especificacion del DAS
        /// </summary>
        private void _Mtd_ActualizarColores()
        {
            _Dtg_Principal.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["ccolorfila"].Value.ToString() == "ROJO").ToList().ForEach(x =>{x.DefaultCellStyle.ForeColor = Color.Red;});
        }

        /// <summary>
        /// Calcula y actualiza los totales según los documentos que se encuentran en el grid.
        /// </summary>
        private void _Mtd_Totalizar()
        {
            Decimal _Dec_TotalCobrar = 0;
            Decimal _Dec_TotalPagar = 0;
            Decimal _Dec_Saldo = 0;
            Decimal _Dec_SaldoSeleccion = 0;

            foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
            {
                // suma todos los documentos del grid al 'saldo total'
                _Dec_Saldo += Convert.ToDecimal(_DR_Fila.Cells["Monto"].Value);
                
                // suma solo los documentos seleccionados al 'saldo seleccion'
                if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada) _Dec_SaldoSeleccion += Convert.ToDecimal(_DR_Fila.Cells["Monto"].Value);
               
                // dependiento de si el documento es de CXC o CXP, suma de un lado o del otro
                switch (_DR_Fila.Cells["Tipo documento"].Value.ToString())
                {
                    case "AVISO DE COBRO CXC":case "FACTURA CXC":case "NOTA DE DEBITO CXC": case "NOTA DE CREDITO CXC": _Dec_TotalCobrar += Convert.ToDecimal(_DR_Fila.Cells["Monto"].Value); break;
                    case "AVISO DE COBRO CXP":case "FACTURA CXP":case "NOTA DE DEBITO CXP": case "NOTA DE CREDITO CXP": case "NOTA DE CREDITO PROVEEDOR CXP": case "NOTA DE DEBITO PROVEEDOR CXP": _Dec_TotalPagar += Convert.ToDecimal(_DR_Fila.Cells["Monto"].Value); break;
                }
            }

            _Txt_TotalCobrar.Text = _Dec_TotalCobrar.ToString("#,##0.00");
            _Txt_TotalPagar.Text = _Dec_TotalPagar.ToString("#,##0.00");
            _Txt_TotalSaldo.Text = _Dec_Saldo.ToString("#,##0.00");
            _Txt_TotalSeleccion.Text = _Dec_SaldoSeleccion.ToString("#,##0.00");

        }

        /// <summary>
        /// actualiza el grid principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Consultar();
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Muestra u oculta el tooltip del grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Dtg_Principal_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
            {
                this._Lbl_DgInfo.Visible = true;
            }
            else
            {
                this._Lbl_DgInfo.Visible = false;
            }
        }

        /// <summary>
        /// colorea de rosado el registro seleccionado y actualiza los totales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Mnu_Seleccionar_Click(object sender, EventArgs e)
        {
            if (_Dtg_Principal.RowCount > 0 && _Dtg_Principal.SelectedRows.Count > 0)
            {
                // colorea de rosado el registro seleccionado
                using (DataGridViewRow _DR_Fila = this._Dtg_Principal.Rows[this._Dtg_Principal.CurrentCell.RowIndex])
                {
                    _DR_Fila.DefaultCellStyle.BackColor = _G_Col_ColorFilaSeleccionada;
                }

                // actualiza los totales
                _Mtd_Totalizar();
            }
        }

        /// <summary>
        /// colorea de blanco el registro de-seleccionado y actualiza los totales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Mnu_Deseleccionar_Click(object sender, EventArgs e)
        {
            if (_Dtg_Principal.RowCount > 0 && _Dtg_Principal.SelectedRows.Count > 0)
            {
                // colorea de blanco el registro de-seleccionado
                using (DataGridViewRow _DR_Fila = this._Dtg_Principal.Rows[this._Dtg_Principal.CurrentCell.RowIndex])
                {
                    _DR_Fila.DefaultCellStyle.BackColor = Color.White;
                }

                // actualiza los totales
                _Mtd_Totalizar();
            }
        }
        
        /// <summary>
        /// realiza las validaciones correspondientes a orden de pago
        /// </summary>
        /// <returns>true si es válidos, false si falta alguna validación</returns>
        private bool _Mtd_ValidarOrdenPago()
        {
            int _Int_CantidadDeDocumentosSeleccionados = 0;
            
            // determina cuantos documentos hay seleccionados
            foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
            {
                if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada) _Int_CantidadDeDocumentosSeleccionados++;
            }

        
            // valida que haya algun documento seleccionado
            if (_Int_CantidadDeDocumentosSeleccionados == 0)
            {
                MessageBox.Show("No hay ningún documento seleccionado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

 
            // cicla los documentos seleccionados
            foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
            {
                // si el documento está seleccionado...
                if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada)
                {
                    string _Str_CodigoProveedor = _DR_Fila.Cells["cproveedor"].Value.ToString().Trim();
                    string _Str_TipoDocumento = _DR_Fila.Cells["Tipo documento"].Value.ToString().Trim();
                    string _Str_NumeroDocumento = _DR_Fila.Cells["Número documento"].Value.ToString().Trim();

                    //// verifica que no esté seleccionado algún aviso de cobro...
                    //if (_Str_TipoDocumento == "AVISO DE COBRO CXC" || _Str_TipoDocumento == "AVISO DE COBRO CXP")
                    //{
                    //    MessageBox.Show("No es posible procesar avisos de cobro desde esta pantalla. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}

                    string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor,_Str_TipoDocumento,_Str_NumeroDocumento);
                    if (_Str_CodigoOrdenPago != "")
                    {
                        MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. "+_Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraCobranza(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoCobranzaIC != "")
                    {
                        MessageBox.Show("El siguiente documento ya se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (_Mtd_DocumentoEstaAnulado(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento))
                    {
                        MessageBox.Show("El siguiente documento está anulado, y no puede ser procesado. Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (_Mtd_DocumentoEstaPorImprimir(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento))
                    {
                        MessageBox.Show("El siguiente documento está aún pendiente por imprimir, y no puede ser procesado. Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }

            if (_Mtd_HayMasDeUnProveedoresSeleccionado())
            {
                MessageBox.Show("Algunos de los documentos seleccionados pertenecen a diferentes compañias relacionadas. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(_Txt_TotalSeleccion.Text) >= 0)
            {
                MessageBox.Show("El saldo de la selección no es válido. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// realiza las validaciones correspondientes a la cobranza
        /// </summary>
        /// <returns>true si es válido, false si salta alguna validación</returns>
        private bool _Mtd_ValidarCobranza()
        {
            int _Int_CantidadDeDocumentosSeleccionados = 0;

            // determina cuantos documentos hay seleccionados
            foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
            {
                if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada) _Int_CantidadDeDocumentosSeleccionados++;
            }


            // valida que haya algun documento seleccionado
            if (_Int_CantidadDeDocumentosSeleccionados == 0)
            {
                MessageBox.Show("No hay ningún documento seleccionado. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            // cicla los documentos seleccionados
            foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
            {
                // si el documento está seleccionado...
                if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada)
                {
                    string _Str_CodigoProveedor = _DR_Fila.Cells["cproveedor"].Value.ToString().Trim();
                    string _Str_TipoDocumento = _DR_Fila.Cells["Tipo documento"].Value.ToString().Trim();
                    string _Str_NumeroDocumento = _DR_Fila.Cells["Número documento"].Value.ToString().Trim();

                    //// verifica que no esté seleccionado algún aviso de cobro...
                    //if (_Str_TipoDocumento == "AVISO DE COBRO CXC" || _Str_TipoDocumento == "AVISO DE COBRO CXP")
                    //{
                    //    MessageBox.Show("No es posible procesar avisos de cobro desde esta pantalla. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}

                    string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraCobranza(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoCobranzaIC != "")
                    {
                        MessageBox.Show("El siguiente documento ya se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoOrdenPago != "")
                    {
                        MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (_Mtd_DocumentoEstaAnulado(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento))
                    {
                        MessageBox.Show("El siguiente documento está anulado, y no puede ser procesado. Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (_Mtd_DocumentoEstaPorImprimir(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento))
                    {
                        MessageBox.Show("El siguiente documento está aún pendiente por imprimir, y no puede ser procesado. Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }

            if (_Mtd_HayMasDeUnProveedoresSeleccionado())
            {
                MessageBox.Show("Algunos de los documentos seleccionados pertenecen a diferentes compañias relacionadas. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(_Txt_TotalSeleccion.Text) < 0)
            {
                MessageBox.Show("El saldo de la selección no debe ser un monto negativo. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// determina si hay más de un proveedor seleccionado
        /// </summary>
        private bool _Mtd_HayMasDeUnProveedoresSeleccionado()
        {
            int _Int_CantidadDeProveedoresSeleccionados = 0;
            
            string _Str_CodigoProveedor = "";
            string _Str_CodigoProveedorCiclando = "";

            // cicla los documentos seleccionados
            foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
            {
                // si el documento está seleccionado...
                if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada)
                {
                    _Str_CodigoProveedorCiclando = _DR_Fila.Cells["cproveedor"].Value.ToString().Trim();

                    // cuenta cuantos proveedores diferentes hay... debe ser exactamente 1
                    if (_Str_CodigoProveedor != _Str_CodigoProveedorCiclando)
                    {
                        _Str_CodigoProveedor = _Str_CodigoProveedorCiclando;
                        _Int_CantidadDeProveedoresSeleccionados++;
                    } 
                }
            }

            if (_Int_CantidadDeProveedoresSeleccionados > 1) return true; else return false;
        }

        /// <summary>
        /// Determina si un documento se está anulado. Prevee el caso en que el documento se anule mientras se generar la OP simultaneamente.
        /// </summary>
        /// <param name="_Str_CodigoProveedor">Código del proveedor al que corresponde el documento</param>
        /// <param name="_Str_TipoDocumento">Tipo 'largo' de documento ic</param>
        /// <param name="_Str_NumeroDocumento">Número o código del documento</param>
        /// <returns>true si el documento está anulado, false en caso contrario</returns>
        private bool _Mtd_DocumentoEstaAnulado(string _P_Str_CodigoProveedor, string _P_Str_TipoDocumento, string _P_Str_NumeroDocumento)
        {
            string _Str_SQL = "";

            _Str_SQL += "SELECT canulado ";
            _Str_SQL += "FROM VST_CONSOLIDADO_INTERCOMPANIAS ";
            _Str_SQL += "WHERE ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _P_Str_CodigoProveedor + "' AND ctipo = '" + _P_Str_TipoDocumento + "' AND cnumdocu = '"+ _P_Str_NumeroDocumento + "' ";
            
            try
            {
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_DataSet.Tables[0].Rows[0]["canulado"].ToString() == "1") return true; else return false;
                }
            }
            catch
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determina si un documento se está por imprimir. 
        /// </summary>
        /// <param name="_Str_CodigoProveedor">Código del proveedor al que corresponde el documento</param>
        /// <param name="_Str_TipoDocumento">Tipo 'largo' de documento ic</param>
        /// <param name="_Str_NumeroDocumento">Número o código del documento</param>
        /// <returns>true si el documento está po imprimir, false en caso contrario</returns>
        private bool _Mtd_DocumentoEstaPorImprimir(string _P_Str_CodigoProveedor, string _P_Str_TipoDocumento, string _P_Str_NumeroDocumento)
        {
            string _Str_SQL = "";

            _Str_SQL += "SELECT cimpreso ";
            _Str_SQL += "FROM VST_CONSOLIDADO_INTERCOMPANIAS ";
            _Str_SQL += "WHERE ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _P_Str_CodigoProveedor + "' AND ctipo = '" + _P_Str_TipoDocumento + "' AND cnumdocu = '" + _P_Str_NumeroDocumento + "' ";

            try
            {
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_DataSet.Tables[0].Rows[0]["cimpreso"].ToString() == "0") return true; else return false;
                }
            }
            catch
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        /// <summary>
        /// valida y luego invoca el fomrulario de orden de pago IC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Mnu_GenerarOrdenPago_Click(object sender, EventArgs e)
        {
            if (_Dtg_Principal.RowCount > 0)
            {
                if (_Mtd_ValidarOrdenPago())
                {

                    int _Int_CantidadDeDocumentosSeleccionados = 0;

                    // determina cuantos documentos hay seleccionados
                    foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
                    {
                        if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada) _Int_CantidadDeDocumentosSeleccionados++;
                    }


                    // genera tres arreglos de string con el codigo proveedor, tipo de documento, y numero de documento de los documentos seleccionados
                    string _Str_CodigoProveedor = "";
                    string[] _Str_TiposDocumento = new string[_Int_CantidadDeDocumentosSeleccionados];
                    string[] _Str_NumerosDocumento = new string[_Int_CantidadDeDocumentosSeleccionados];
                    int _Int_Contador = 0;

                    _Dtg_Principal.Rows.Cast<DataGridViewRow>().Where(_DR_Fila => _DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada).ToList().ForEach
                    (_DR_Fila =>
                        {
                            _Str_CodigoProveedor = _DR_Fila.Cells["cproveedor"].Value.ToString().Trim();
                            _Str_TiposDocumento[_Int_Contador] = _DR_Fila.Cells["Tipo documento"].Value.ToString().Trim();
                            _Str_NumerosDocumento[_Int_Contador] = _DR_Fila.Cells["Número documento"].Value.ToString().Trim();
                            _Int_Contador++;
                        }
                    );


                    Frm_IC_GeneracionOP _Frm_IC_GeneracionOP = new Frm_IC_GeneracionOP(_Str_CodigoProveedor, _Str_TiposDocumento, _Str_NumerosDocumento);

                    if (_Frm_IC_GeneracionOP.ShowDialog(this) == DialogResult.Yes)
                    {
                        this._Mtd_Consultar();
                    }
                }
            }
        }

        /// <summary>
        /// valida, y luego invoca el fomrulario de cobrnaza IC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Mnu_RegistrarCobranza_Click(object sender, EventArgs e)
        {
            if (_Dtg_Principal.RowCount > 0)
            {
                if (_Mtd_ValidarCobranza())
                {
                    int _Int_CantidadDeDocumentosSeleccionados = 0;

                    // determina cuantos documentos hay seleccionados
                    foreach (DataGridViewRow _DR_Fila in _Dtg_Principal.Rows)
                    {
                        if (_DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada) _Int_CantidadDeDocumentosSeleccionados++;
                    }


                    // genera tres arreglos de string con el codigo proveedor, tipo de documento, y numero de documento de los documentos seleccionados
                    string _Str_CodigoProveedor = "";
                    string[] _Str_TiposDocumento = new string[_Int_CantidadDeDocumentosSeleccionados];
                    string[] _Str_NumerosDocumento = new string[_Int_CantidadDeDocumentosSeleccionados];
                    int _Int_Contador = 0;

                    _Dtg_Principal.Rows.Cast<DataGridViewRow>().Where(_DR_Fila => _DR_Fila.DefaultCellStyle.BackColor == _G_Col_ColorFilaSeleccionada).ToList().ForEach
                    (_DR_Fila =>
                    {
                        _Str_CodigoProveedor = _DR_Fila.Cells["cproveedor"].Value.ToString().Trim();
                        _Str_TiposDocumento[_Int_Contador] = _DR_Fila.Cells["Tipo documento"].Value.ToString().Trim();
                        _Str_NumerosDocumento[_Int_Contador] = _DR_Fila.Cells["Número documento"].Value.ToString().Trim();
                        _Int_Contador++;
                    }
                    );


                    Frm_IC_Cobranza _Frm_IC_Cobranza = new Frm_IC_Cobranza(_Str_CodigoProveedor, _Str_TiposDocumento, _Str_NumerosDocumento, this.MdiParent);

                    _Frm_IC_Cobranza.Show();


                }
            }
        }

        private void _Dtg_Principal_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_ActualizarColores();
        }

        #region Cambios del consolidado intercompañía utilizando Frm_ConsolidadoInterResumido.

        /// <summary>
        /// Esta variable es para seleccionar la empresa relacionada.
        /// </summary>
        private string gCodigoCompañia = null;

        /// <summary>
        /// Esta versión del constructor es para llamar al formulario desde el Frm_ConsolidadoInterResumido.
        /// </summary>
        /// <param name="pCodigoCompañia">Código de la empresa relacionada seleccionado en el grid de Frm_ConsolidadoInterResumido.</param>
        public Frm_ConsolidadoIntercomp(string pCodigoCompañia)
        {
            gCodigoCompañia = pCodigoCompañia;

            InitializeComponent();
        }

        private void Frm_ConsolidadoIntercomp_Activated(object sender, EventArgs e)
        {
            if (gCodigoCompañia != "")
                _Mtd_ActualizarColores();
        }

        #endregion        
    }

}
