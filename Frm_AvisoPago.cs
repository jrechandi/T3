// código verificado el 12/06/2012, revision 1151 por dgavidia (nomenclatura + comentarios ///)

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using T3.Clases;

namespace T3
{
    public partial class Frm_AvisoPago : Form
    {
        string _G_Str_SentenciaSQL;
        bool _G_Bol_ModoGuardar = false;
        string _G_Str_ValorCeldaTem = "XXXX";
        bool _G_Int_Anulacion = false;
        bool _G_Bol_Impreso;
        bool _G_Bol_ModoConsultar = false;
        bool _G_Bol_ModoAnular = false;
        DataSet _G_Ds_DataSet = new DataSet();
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        int _G_Int_Proceso;
        int _G_Int_IdDocumento;
        
         public Frm_AvisoPago()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor de Aviso de cobro
        /// </summary>
        /// <param name="_P_Int_Proceso">Proceso 0 -> consulta / creación 1 -> anulación 2 -> impresión</param>
        /// <param name="_P_Int_IdDocumento">0 -> significa que no consulta ningún documento específico n -> ID de un documento específico que se está consultando</param>
         public Frm_AvisoPago(int _P_Int_Proceso, int _P_Int_IdDocumento)
        {            
            _G_Int_Proceso=_P_Int_Proceso;
            _G_Int_IdDocumento=_P_Int_IdDocumento;
            InitializeComponent();
            _Mtd_CompaniasRelacionadas();
            _Mtd_CargarEstatus(_P_Int_Proceso);
            _Mtd_CargarFormulario(_P_Int_Proceso);
            if (_P_Int_IdDocumento > 0)
            {
                string _Str_Aviso = "";
                _Str_Aviso = _P_Int_IdDocumento.ToString();
                _G_Str_SentenciaSQL = "SELECT ccodavisocob,cfechaemision,cproveedor,cmonto,cconcepto,cdescripcion,cidcomprob,canulado,CIDCOMPROBANUL,cmotivoanul FROM TAVISOPAGM WHERE ccodavisopag='" + _Str_Aviso + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Txt_Concepto.Text = _G_Ds_DataSet.Tables[0].Rows[0]["cconcepto"].ToString();
                _Txt_Descripcion.Text = _G_Ds_DataSet.Tables[0].Rows[0]["cdescripcion"].ToString();
                _Txt_Monto.KeyPress -= new KeyPressEventHandler(_Txt_Monto_KeyPress);
                _Txt_Monto.TextChanged -= new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Monto.Text = Convert.ToDouble(_G_Ds_DataSet.Tables[0].Rows[0]["cmonto"].ToString()).ToString("#,##0");
                _Txt_Monto.KeyPress += new KeyPressEventHandler(_Txt_Monto_KeyPress);
                _Txt_Monto.TextChanged += new EventHandler(_Txt_Monto_TextChanged);
                _Cmb_CompaniaRelacionada.SelectedValue = _G_Ds_DataSet.Tables[0].Rows[0]["cproveedor"].ToString();
                string _Str_IdComprobante = _G_Ds_DataSet.Tables[0].Rows[0]["cidcomprob"].ToString();
                string _Str_Anulado = _G_Ds_DataSet.Tables[0].Rows[0]["canulado"].ToString();
                string _Str_MotivoAnul = _G_Ds_DataSet.Tables[0].Rows[0]["cmotivoanul"].ToString();
                string _Str_IdComprobAnul = _G_Ds_DataSet.Tables[0].Rows[0]["cidcomprobanul"].ToString();
                _Txt_Cod.Text = _P_Int_IdDocumento.ToString();
                _G_Bol_ModoConsultar = true;
                _Mtd_Deshabilitar();
                _Dg_Comprobante.CellClick -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
                _Dg_Comprobante.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
                _Dg_Comprobante.CellBeginEdit -= new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
                _Dg_Comprobante.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
                _Tb_Tab.SelectedIndex = 1;
                _Mtd_VisualizarComprobanteEmitido(_Txt_Cod.Text, Frm_Padre._Str_Comp);
                if (_Str_Anulado == "1" || _Str_IdComprobAnul != "0")
                {
                    this.Text = "Aviso de Cobro CxP (Anulación)";
                    _Mtd_CargarMotivoAnulacion();
                    _Pnl_Anulacion.Visible = true;
                    _Cmb_MotivoAnulacion.Enabled = false;
                    _Cmb_MotivoAnulacion.SelectedValue = _Str_MotivoAnul;
                    //Muestra el motivo de anulación
                }
                else
                {
                    this.Text = "Aviso de Cobro CxP";
                    _Pnl_Anulacion.Visible = false;
                }
            }
            else
            {
                _Mtd_Consultar();
            }
        }        

        private void Frm_AvisoPago_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Método para verificar si el aviso de cobro tiene ordenes de pago. 
        /// </summary>
        /// <param name="_P_Str_AvisoCobro">Número o código de la orden de pago</param>
        /// <returns>Verdadero si ya tiene orden de pago asignada</returns>
        private bool _Mtd_TieneOrdenPago(string _P_Str_AvisoCobro)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT cidordpago";
            _Str_SQL += " FROM TAVISOPAGM";
            _Str_SQL += " WHERE cidordpago>0 AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_SQL += " AND ccodavisopag = '" + _P_Str_AvisoCobro + "'";

            DataSet _Ds_Resultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Resultado.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Carga del combo de compañias relacionadas
        /// </summary>
        private void _Mtd_CompaniasRelacionadas()
        {
            try
            {
                //_G_Str_SentenciaSQL = "SELECT cproveedor,c_nomb_abreviado FROM VST_COMPANIASRELACIONADAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _G_Str_SentenciaSQL = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.cproveedor + ' - ' + TPROVEEDOR.c_nomb_comer AS c_nomb_abreviado FROM TICRELAPROCLI INNER JOIN TPROVEEDOR ON TICRELAPROCLI.cproveedor = TPROVEEDOR.cproveedor WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _myUtilidad._Mtd_CargarCombo(_Cmb_CompaniaRelacionada, _G_Str_SentenciaSQL);
                _myUtilidad._Mtd_CargarCombo(_Cmb_CompaniaRelacionadaCons, _G_Str_SentenciaSQL);
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que cargará dependiendo del tipo de proceso el formulario.
        /// </summary>
        /// <param name="_P_Int_Proceso">Proceso 0 -> consulta / creación 1 -> anulación 2 -> impresión</param>
        private void _Mtd_CargarFormulario(int _P_Int_Proceso)
        {
            switch (_P_Int_Proceso)
            {
                case 0:
                    _Bt_Visulizar.Text = "Visualizar comprobante a generar..";
                    //Creación o consulta de avisos
                    break;
                case 1:
                    _Bt_Visulizar.Text = "Generar comprobante de anulación";
                    _Pnl_Anulacion.Visible = true;
                    _G_Int_Anulacion = true;
                    _G_Bol_ModoGuardar = false;
                    _Mtd_CargarMotivoAnulacion();
                    _Cmb_MotivoAnulacion.Enabled = true;
                    _G_Bol_ModoAnular = true;
                    _Dg_Comprobante.CellClick-=new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
                    _Dg_Comprobante.CellEndEdit-=new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
                    _Dg_Comprobante.CellBeginEdit-=new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
                    _Dg_Comprobante.EditingControlShowing-=new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
                    //Anulación de avisos
                    break;
                case 2:
                    _Bt_Visulizar.Text = "Generar comprobante de anulación";
                    //Impresión de avisos
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Carga los estatus dependiendo del proceso
        /// </summary>
        private void _Mtd_CargarEstatus(int _P_Int_Proceso)
        {
            if (_G_Int_Proceso == 1)
            {
                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
                string[,] _Str_Listado = null;
                _Str_Listado = new string[,] { { "Por Pagar", "0" } };
                for (int _Int_I = 0; _Int_I< _Str_Listado.GetLength(0); _Int_I++)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
                }
                _Cmb_Estatus.DataSource = _myArrayList;
                _Cmb_Estatus.DisplayMember = "Display";
                _Cmb_Estatus.ValueMember = "Value";
                _Cmb_Estatus.Enabled = false;
                _Cmb_Estatus.SelectedValue = "0";
                this.Text = "Aviso de Cobro CxP (Anulación)";
            }
            else if (_G_Int_Proceso == 0)
            {
                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
                string[,] _Str_Listado = null;
                _Str_Listado = new string[,] { { "Por Pagar", "0" }, { "Cancelados", "1" }, { "Anulados", "2" } };
                for (int _Int_I = 0; _Int_I< _Str_Listado.GetLength(0); _Int_I++)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
                }
                _Cmb_Estatus.DataSource = _myArrayList;
                _Cmb_Estatus.DisplayMember = "Display";
                _Cmb_Estatus.ValueMember = "Value";
                _Cmb_Estatus.SelectedValue = "0";
                this.Text = "Aviso de Cobro CxP (Consulta)";
            }
            else
            {
                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
                string[,] _Str_Listado = null;
                _Str_Listado = new string[,] { { "Por Pagar", "0" } };
                for (int _Int_I = 0; _Int_I< _Str_Listado.GetLength(0); _Int_I++)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
                }
                _Cmb_Estatus.DataSource = _myArrayList;
                _Cmb_Estatus.DisplayMember = "Display";
                _Cmb_Estatus.ValueMember = "Value";
                _Cmb_Estatus.Enabled = false;
                _Cmb_Estatus.SelectedValue = "0";
                this.Text = "Aviso de Cobro CxP (Impresión)";
            }
        }
        /// <summary>
        /// Evento del boton consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Consultar();
        }
        /// <summary>
        /// Método para la consulta de avisos de cobro por estatus 
        /// </summary>
        private void _Mtd_Consultar()
        {
            try
            {
                string _Str_Estatus = "";
                if (_Cmb_Estatus.SelectedValue != null)
                {
                    if (_Cmb_Estatus.SelectedValue.ToString() != "nulo")
                    {
                        _Str_Estatus = _Cmb_Estatus.SelectedValue.ToString();
                    }
                }
                string _Str_Where = "";
                if (_Str_Estatus.Length > 0)
                {   
                    if (_Str_Estatus == "0" || _Str_Estatus == "1")
                    {
                        _Str_Where += " AND CESTADO='" + _Str_Estatus + "' AND CANULADO='0'";
                    }
                    else
                    {
                        _Str_Where += " AND CANULADO='1'";
                    }
                }
                if (_Cmb_CompaniaRelacionadaCons.SelectedValue != null)
                {
                    if (_Cmb_CompaniaRelacionadaCons.SelectedValue.ToString() != "nulo")
                    {
                        _Str_Where += " AND CPROVEEDOR='" + _Cmb_CompaniaRelacionadaCons.SelectedValue.ToString() + "'";
                    }
                }
                _G_Str_SentenciaSQL = "SELECT ccodavisopag as [Código],c_nomb_comer as [Compañía relacionada], cproveedor, CONVERT(VARCHAR,cfechaemision,103) AS [Fecha de Emisión], dbo.Fnc_Formatear(cmonto * -1) as [Monto], ccodavisopag, cestado, canulado FROM VST_AVISOSCOBROSPAGARCOMPANIA WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
                _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL).Tables[0];
                _Dg_Grid.Columns["Compañía relacionada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dg_Grid.Columns["cproveedor"].Visible = false;
                _Dg_Grid.Columns["ccodavisopag"].Visible = false;
                _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns["cestado"].Visible = false;
                _Dg_Grid.Columns["canulado"].Visible = false;
            }
            catch (Exception _Err_)
            {
            }

        }
        /// <summary>
        /// Método nuevo de la botonera
        /// </summary>
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
        }
        /// <summary>
        /// Evento activated del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_AvisoPago_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _G_Int_Proceso==0;//_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_REPOSICIONES");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _G_Bol_ModoGuardar;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }
        /// <summary>
        /// Método que inicializa el formulario
        /// </summary>
        private void _Mtd_Ini()
        {
            _Pnl_Anulacion.Visible = false;
            if (_Cmb_MotivoAnulacion.Items.Count > 0)
            {
                _Cmb_MotivoAnulacion.SelectedIndex = 0;
            }
            _Cmb_CompaniaRelacionada.SelectedIndex = 0;
            _Txt_Monto.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Cod.Text = "";
            _Txt_IdAvisoCobro.Enabled = true;
            _Txt_IdAvisoCobro.Text = "";
            _Dtp_Emision.Enabled = false;
            _G_Int_Anulacion = false;
            _G_Bol_ModoGuardar = true;
            _Bt_Visulizar.Enabled = true;
            _Txt_Descripcion.Enabled = true;
            _Dg_Comprobante.Rows.Clear();
            _G_Bol_Impreso = false;
            _G_Bol_ModoConsultar = false;
            _G_Bol_ModoAnular = false;
            _Bt_Visulizar.Enabled = true;
            _Txt_Concepto.Enabled = true;
            _Txt_Monto.Enabled = true;
            _Cmb_CompaniaRelacionada.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            _Dg_Comprobante.CellClick -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
            _Dg_Comprobante.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
            _Dg_Comprobante.CellBeginEdit -= new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
            _Dg_Comprobante.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
            _Dg_Comprobante.CellClick += new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
            _Dg_Comprobante.CellEndEdit += new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
            _Dg_Comprobante.CellBeginEdit += new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
            _Dg_Comprobante.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
        }
        /// <summary>
        /// Método para la carga de los motivos de anulación 
        /// </summary>
        private void _Mtd_CargarMotivoAnulacion()
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotianulfact='1' ORDER BY cdescripcion ASC";
                _myUtilidad._Mtd_CargarCombo(_Cmb_MotivoAnulacion, _G_Str_SentenciaSQL);
            }
            catch
            {
            }
        }
        /// <summary>
        /// Evento de FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_AvisoPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        /// <summary>
        /// Evento TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            if (!_myUtilidad._Mtd_IsNumeric(_Txt_Monto.Text)) { _Txt_Monto.Text = ""; }
            _Dg_Comprobante.Rows.Clear();
        }
        /// <summary>
        /// Evento KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Monto, e, 15, 2);
            _Dg_Comprobante.Rows.Clear();
        }
        /// <summary>
        /// Verifica si el monto es mayor a 0 o está vacio.
        /// </summary>
        /// <param name="_P_Txt_TextBox"></param>
        /// <returns></returns>
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }
        /// <summary>
        /// Evento del boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Bt_Visulizar_Click(object sender, EventArgs e)
        {
            string _Str_Proveedor = "";
            string _Str_AnulacionMotivo="";
            _Er_Error.Dispose();
            if (_Cmb_CompaniaRelacionada.SelectedValue != null)
            {
                if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() != "nulo")
                {
                    _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                }
            }
            if (_Mtd_VerifContTextBoxNumeric(_Txt_IdAvisoCobro)&&_Str_Proveedor != "" && _Str_Proveedor != "nulo" && _Mtd_VerifContTextBoxNumeric(_Txt_Monto) && _Txt_Concepto.Text.Trim() != "" && _Txt_Descripcion.Text.Trim() != "")
            {
                string _Str_ProcesoCont = "P_AVISO_COBRO_PAGAR";
                Cursor = Cursors.WaitCursor;
                if (_G_Int_Anulacion)
                {
                    if (_Cmb_MotivoAnulacion.SelectedValue != null)
                    {
                        if (_Cmb_MotivoAnulacion.SelectedValue.ToString() != "nulo")
                        {
                            _Str_AnulacionMotivo = _Cmb_MotivoAnulacion.SelectedValue.ToString();
                            if (_Str_AnulacionMotivo.Trim() != "" && _Str_AnulacionMotivo.Trim() != "nulo")
                            {
                                _Mtd_ReversarComprobante(_Txt_Cod.Text, Frm_Padre._Str_Comp);
                            }
                        }
                        else
                        {
                            if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto)) { _Er_Error.SetError(_Txt_IdAvisoCobro, "Información Requerida!!!"); }
                            if (_Txt_Concepto.Text.Trim() == "") { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                            if (_Txt_Descripcion.Text.Trim() == "") { _Er_Error.SetError(_Txt_Descripcion, "Información Requerida!!!"); }
                            if (_Str_Proveedor.Trim() == "" || _Str_Proveedor.Trim() == "nulo") { _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!"); }
                            if (_G_Int_Anulacion)
                            {
                                if (_Str_AnulacionMotivo.Trim() == "" || _Str_AnulacionMotivo.Trim() == "nulo") { _Er_Error.SetError(_Cmb_MotivoAnulacion, "Información Requerida!!!"); }
                            }
                        }
                    }
                    else
                    {
                        if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto)) { _Er_Error.SetError(_Txt_Monto, "Información Requerida!!!"); }
                        if (_Txt_Concepto.Text.Trim() == "") { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                        if (_Txt_Descripcion.Text.Trim() == "") { _Er_Error.SetError(_Txt_Descripcion, "Información Requerida!!!"); }
                        if (_Str_Proveedor.Trim() == "" || _Str_Proveedor.Trim() == "nulo") { _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!"); }
                        if (_G_Int_Anulacion)
                        {
                            if (_Str_AnulacionMotivo.Trim() == "" || _Str_AnulacionMotivo.Trim() == "nulo") { _Er_Error.SetError(_Cmb_MotivoAnulacion, "Información Requerida!!!"); }
                        }
                    }
                }
                else
                {
                    _Mtd_VisualizarComprobante(_Str_ProcesoCont.Trim(), _Str_Proveedor);
                }
                Cursor = Cursors.Default;
            }
            else
            {
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_IdAvisoCobro)) { _Er_Error.SetError(_Txt_IdAvisoCobro, "Información Requerida!!!"); }
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto)) { _Er_Error.SetError(_Txt_Monto, "Información Requerida!!!"); }
                if (_Txt_Concepto.Text.Trim() == "") { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim() == "") { _Er_Error.SetError(_Txt_Descripcion, "Información Requerida!!!"); }
                if (_Str_Proveedor.Trim() == "" || _Str_Proveedor.Trim() == "nulo") { _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!"); }
                if (_G_Int_Anulacion)
                {
                    if (_Str_AnulacionMotivo.Trim() == "" || _Str_AnulacionMotivo.Trim() == "nulo") { _Er_Error.SetError(_Cmb_MotivoAnulacion, "Información Requerida!!!"); }
                }
            }
        }
        /// <summary>
        /// Verifica si todas las cuentas existen
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_VerificarCuentas()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    { return false; }
                    else if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() != "D")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Método que valida al guardar el aviso
        /// </summary>
        /// <returns>Retorna si es valido o no</returns>
        private bool _Mtd_Validar()
        {
            string _Str_Proveedor = "";
            string _Str_AnulacionMotivo = "";
            _Er_Error.Dispose();
            if (_Cmb_CompaniaRelacionada.SelectedValue != null)
            {
                if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() != "nulo")
                {
                    _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                }
            }
            if (_G_Int_Anulacion)
            {
                if (_Cmb_MotivoAnulacion.SelectedValue != null)
                {
                    if (_Cmb_MotivoAnulacion.SelectedValue.ToString() != "nulo")
                    {
                        _Str_AnulacionMotivo = _Cmb_MotivoAnulacion.SelectedValue.ToString();
                    }
                }
            }
            if (_Mtd_VerifContTextBoxNumeric(_Txt_IdAvisoCobro)&& _Str_Proveedor != "" && _Str_Proveedor!="nulo" && _Mtd_VerifContTextBoxNumeric(_Txt_Monto) && _Txt_Concepto.Text.Trim() != "" && _Txt_Descripcion.Text.Trim() != "")
            {
                if (_G_Int_Anulacion)
                {

                    //-- Inicio -- Validacion de documentos ya usados en orden de pago y/o cobranza
                    string _Str_CodigoProveedor = _Str_Proveedor;
                    string _Str_TipoDocumento = "AVISO DE COBRO CXC";
                    string _Str_NumeroDocumento = _Txt_Cod.Text;
                    //Verifico que el Documento ya no este en una cobranza
                    string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraCobranza(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoCobranzaIC != "")
                    {
                        MessageBox.Show("El siguiente documento se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . No es posible anular. Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    //Verifico que el Documento ya no este en una orden de pago
                    string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoOrdenPago != "")
                    {
                        MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . No es posible anular. Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    //-- Fin -- Validacion de documentos ya usados en orden de pago y/o cobranza
                    
                    if (_Cmb_MotivoAnulacion.SelectedValue != null)
                    {
                        if (_Cmb_MotivoAnulacion.SelectedValue.ToString() != "nulo")
                        {
                            _Str_AnulacionMotivo = _Cmb_MotivoAnulacion.SelectedValue.ToString();
                            return true;
                        }
                        else
                        {
                            if (!_Mtd_VerifContTextBoxNumeric(_Txt_IdAvisoCobro)) { _Er_Error.SetError(_Txt_IdAvisoCobro, "Información Requerida!!!"); }
                            if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto)) { _Er_Error.SetError(_Txt_Monto, "Información Requerida!!!"); }
                            if (_Txt_Concepto.Text.Trim() == "") { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                            if (_Txt_Descripcion.Text.Trim() == "") { _Er_Error.SetError(_Txt_Descripcion, "Información Requerida!!!"); }
                            if (_Str_Proveedor.Trim() == "" || _Str_Proveedor.Trim() == "nulo") { _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!"); }
                            if (_G_Int_Anulacion)
                            {
                                if (_Str_AnulacionMotivo.Trim() == "" || _Str_AnulacionMotivo.Trim() == "nulo") { _Er_Error.SetError(_Cmb_MotivoAnulacion, "Información Requerida!!!"); }
                            }
                            return false;
                        }
                    }
                    else
                    {
                        if (!_Mtd_VerifContTextBoxNumeric(_Txt_IdAvisoCobro)) { _Er_Error.SetError(_Txt_IdAvisoCobro, "Información Requerida!!!"); }
                        if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto)) { _Er_Error.SetError(_Txt_Monto, "Información Requerida!!!"); }
                        if (_Txt_Concepto.Text.Trim() == "") { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                        if (_Txt_Descripcion.Text.Trim() == "") { _Er_Error.SetError(_Txt_Descripcion, "Información Requerida!!!"); }
                        if (_Str_Proveedor.Trim() == "" || _Str_Proveedor.Trim() == "nulo") { _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!"); }
                        if (_G_Int_Anulacion)
                        {
                            if (_Str_AnulacionMotivo.Trim() == "" || _Str_AnulacionMotivo.Trim() == "nulo") { _Er_Error.SetError(_Cmb_MotivoAnulacion, "Información Requerida!!!"); }
                        }
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_IdAvisoCobro)) { _Er_Error.SetError(_Txt_IdAvisoCobro, "Información Requerida!!!"); }
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto)) { _Er_Error.SetError(_Txt_Monto, "Información Requerida!!!"); }
                if (_Txt_Concepto.Text.Trim() == "") { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim() == "") { _Er_Error.SetError(_Txt_Descripcion, "Información Requerida!!!"); }
                if (_Str_Proveedor.Trim() == "" || _Str_Proveedor.Trim() == "nulo") { _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!"); }
                if (_G_Int_Anulacion)
                {
                    if (_Str_AnulacionMotivo.Trim() == "" || _Str_AnulacionMotivo.Trim() == "nulo") { _Er_Error.SetError(_Cmb_MotivoAnulacion, "Información Requerida!!!"); }
                }
                return false;
            }
        }
        /// <summary>
        /// Método para visualizar el comprobante contable para la carga.
        /// </summary>
        /// <param name="_P_Str_ProcesoCont">Código del Proceso contable</param>
        private void _Mtd_VisualizarComprobante(string _P_Str_ProcesoCont, string _P_Str_Proveedor)
        {
            double _Dbl_Monto = 0;
            _Dg_Comprobante.Rows.Clear();
            //------------

            if (_Txt_Monto.Text.Trim().Length > 0)
            { _Dbl_Monto = Convert.ToDouble(_Txt_Monto.Text); }

            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_ProcesoCont);

            _My_Cls_ProcesosCont._Mtd_Proceso_P_AVISO_COBRO_COBRAR(_Dg_Comprobante, _P_Str_Proveedor, _Dbl_Monto);

            if (_Dg_Comprobante.RowCount > 0)
            {
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
            }
            _Mtd_HabilitarCeldaXXXX(true);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        /// <summary>
        /// Método que devuelve la suma de las filas del debe o el haber según sea el caso
        /// </summary>
        /// <param name="_P_Int_Col_Index">Número de columna del grid</param>
        /// <returns></returns>
        private string _Mtd_TotalDebeHaber(int _P_Int_Col_Index)
        {
            double _Dbl_Total = 0;
            object _Ob_Valor = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_Valor = _Dg_Row.Cells[_P_Int_Col_Index].Value;
                        if (_Ob_Valor == null)
                        { _Ob_Valor = 0; }
                        else if (_Ob_Valor.ToString().Trim().Length == 0)
                        { _Ob_Valor = 0; }
                        _Dbl_Total += Convert.ToDouble(_Ob_Valor);
                    }
                }
            }
            return _Dbl_Total.ToString("#,##0.00");
        }
        /// <summary>
        /// Método que habilita las celda con XXXX
        /// </summary>
        /// <param name="_P_Bol_Habilitar">Booleano para habilitar o deshabilitar</param>
        private void _Mtd_HabilitarCeldaXXXX(bool _P_Bol_Habilitar)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() == "XXXX")
                { _Dg_Row.Cells[0].ReadOnly = !_P_Bol_Habilitar; }
                else
                { _Dg_Row.Cells[0].ReadOnly = true; }
            }
        }
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _G_Bol_ModoConsultar = false;
                if (_G_Bol_ModoGuardar)
                {
                    if (MessageBox.Show("Se perderá cualquier información cargada hasta ahora en el aviso. ¿Está seguro de que desea volver a la consulta?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        _G_Bol_ModoGuardar = false;
                        _Er_Error.Dispose();
                    }
                    if (!_G_Bol_ModoAnular)
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    }
                }
            }
            if (e.TabPageIndex == 1)
            {
                if (!_G_Bol_ModoConsultar)
                {
                    e.Cancel = !_G_Bol_ModoGuardar;
                }
                else{
                    e.Cancel = !_G_Bol_ModoConsultar;
                }
            }
        }

        private void _Dg_Comprobante_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    _G_Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }

        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1 & !_Dg_Comprobante.Rows[e.RowIndex].Cells[0].ReadOnly)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_VstCuentas _Frm = new Frm_VstCuentas();
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
                    {
                        if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Frm._Str_FrmNodeSelec.Trim(), e.RowIndex))
                            { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Frm._Str_FrmNodeSelec.Trim(); _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim()); _G_Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(); }
                            else
                            { MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                    }
                    _Frm.Dispose();
                }
            }
        }
        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns>Booleano si es valido o no</returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }
        /// <summary>
        /// Verifica si la cuenta ya ha sido ingresada.
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Int_RowIndex">Índice de la fila</param>
        /// <returns>Booleano si es valido o no</returns>
        private bool _Mtd_ValidarCuenta(string _P_Str_Cuenta, int _P_Int_RowIndex)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Cuenta & _Dg_Row.Index != _P_Int_RowIndex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Método para obtener la descripción de la cuenta
        /// </summary>
        /// <param name="_P_Str_Cuenta">Código de la cuenta</param>
        /// <returns>Descripción de la cuenta</returns>
        private string _Mtd_ObtenerDescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Descrip = "";
            string _Str_Proveedor = "";
            _Er_Error.Dispose();
            if (_Cmb_CompaniaRelacionada.SelectedValue != null)
            {
                if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() != "nulo")
                {
                    _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                }
            }
            _Str_Descrip = _Mtd_ObtenerDescripComerProveedor(_Str_Proveedor);
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + " "+_Str_Descrip; }
            else
            { return ""; }
        }
        /// <summary>
        /// Método para obtener la descripción del proveedor
        /// </summary>
        /// <param name="_P_Str_Proveedor">Código del proveedor</param>
        /// <returns>Nombre del proveedor</returns>
        private string _Mtd_ObtenerDescripComerProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem;
                    }
                    else
                    {
                        if (_Mtd_CuentaDetalle(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), e.RowIndex))
                            { _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()); }
                            else
                            { MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                    }
                }
                else
                { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
            }
        }
        bool _G_Bol_Boleano = false;
        private void _Dg_Comprobante_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_G_Bol_Boleano)
            {
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _G_Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Comprobante.CurrentCell.ColumnIndex == 0)
            {
                _Mtd_MostrarToolTipsCell(((TextBox)sender).Text, ((TextBox)sender).Font);
            }
        }
        /// <summary>
        /// Muestra en un ToolTips la descripción de la cuenta que se esta introduciendo manualmente
        /// </summary>
        /// <param name="_P_Str_Cuenta"></param>
        private void _Mtd_MostrarToolTipsCell(string _P_Str_Cuenta, Font _P_Fnt_Fuente)
        {
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Tlt_Tips.Show(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), this, (_Dg_Comprobante.Location.X + (_Dg_Comprobante.Width / 2)) - (Convert.ToInt32(CreateGraphics().MeasureString(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _P_Fnt_Fuente).Width) / 2), this.Height - 50, 2000);
                }
                else
                {
                    _Tlt_Tips.Hide(this);
                }
            }
            else
            { _Tlt_Tips.Hide(this); }
        }

        private void _Cmb_CompaniaRelacionada_DropDown(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Clear();
            _Mtd_CompaniasRelacionadas();
        }

        private void _Cmb_CompaniaRelacionadaCons_DropDown(object sender, EventArgs e)
        {
            _Mtd_CompaniasRelacionadas();
        }

        private void _Cmb_CompaniaRelacionada_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Clear();
        }

        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        /// <summary>
        /// Método para Guardar el aviso de cobro
        /// </summary>
        public bool _Mtd_Guardar()
        {
            if (_Mtd_Validar())
            {
                if (_Dg_Comprobante.Rows.Count > 0)
                {
                    if (_Mtd_VerificarCuentas())
                    {
                        if (_G_Int_Anulacion)
                        {
                            _Mtd_GenerarComprobateAnulacion(_Txt_Cod.Text, Frm_Padre._Str_Comp);
                            return false;
                        }
                        else
                        {
                            _Mtd_ProcesarAvisoComprobante(Frm_Padre._Str_Comp, _Cmb_CompaniaRelacionada.SelectedValue.ToString());
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El registro contable solo puede realizarse con cuentas de detalle.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false; 
                    }
                }
                else
                {
                    MessageBox.Show("Debe visualizar y completar el comprobante contable.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Genera el comprobante de anulación
        /// </summary>
        /// <param name="_P_Str_Aviso">Código del aviso</param>
        /// <param name="_P_Str_Compania">Código de la compañia</param>
        private void _Mtd_GenerarComprobateAnulacion(string _P_Str_Aviso, string _P_Str_Compania)
        {
            //Registro del comprobante contable
            int _Int_IdComprobante = _Mtd_GenerarComprobante();
            //Se modifica el comprobante que fue generado
            _G_Str_SentenciaSQL = "UPDATE TAVISOPAGM SET cmotivoanul='" + _Cmb_MotivoAnulacion.SelectedValue.ToString() + "',CIDCOMPROBANUL='" + _Int_IdComprobante + "' WHERE CCOMPANY='" + _P_Str_Compania + "' AND ccodavisopag='" + _P_Str_Aviso + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            _G_Str_SentenciaSQL = "UPDATE TCOMPROBANC SET cname =cname+ ' ANULACIÓN' WHERE CIDCOMPROB='"+_Int_IdComprobante+"' AND CCOMPANY='"+_P_Str_Compania+"'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            if (_Int_IdComprobante > 0)
            {
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Está preparada la impresora para imprimir el comprobante contable?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Mtd_ImprimirComprobante(_Txt_Cod.Text, Frm_Padre._Str_Comp, Convert.ToInt32(_Int_IdComprobante));
                }
                else
                {
                    _Mtd_TerminarProceso();
                }
            }
        }
        /// <summary>
        /// Método que registra el aviso por cobrar y el comprobante contable y luego manda a imprimir tanto el aviso como el comprobante.
        /// </summary>
        /// <param name="_P_Str_Compania">Compañia del aviso</param>
        /// <param name="_P_Str_Proveedor">Proveedor del aviso</param>
        private void _Mtd_ProcesarAvisoComprobante(string _P_Str_Compania, string _P_Str_Proveedor)
        {
            try
            {
                //Registro del aviso de cobro
                _G_Str_SentenciaSQL = "SELECT ISNULL(MAX(ccodavisopag),0)+1 FROM TAVISOPAGM WHERE CCOMPANY='" + _P_Str_Compania + "'";
                _G_Ds_DataSet=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                string _Str_Aviso=_G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                
                // _Str_MontoTotal -> se inserta como cmonto y como csaldo
                string _Str_MontoTotal = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Txt_Monto.Text));
                
                _G_Str_SentenciaSQL = "INSERT INTO TAVISOPAGM ([ccompany],ccodavisocob,[ccodavisopag],CFECHAEMISION,[cproveedor],[cestado],[cmonto],[cconcepto],[cdescripcion],[canulado],[cidcomprob],[cdateadd],[cuseradd],[cdelete],cidcomprobanul,cmotivoanul,csaldo)";
                _G_Str_SentenciaSQL += " VALUES ('"+_P_Str_Compania+"','"+_Txt_IdAvisoCobro.Text+"','"+_Str_Aviso+"','"+_Dtp_Emision.Value.ToShortDateString()+"','"+_P_Str_Proveedor+"','0','"+ _Str_MontoTotal +"','"+_Txt_Concepto.Text+"','"+_Txt_Descripcion.Text+"','0','0',GETDATE(),'"+Frm_Padre._Str_Use+"','0','0','0'," + _Str_MontoTotal +")";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                _Txt_Cod.Text = _Str_Aviso;

                // una vez guardado el comprobante, desactiva el botón de guardar, deshabilita los demas controles, y vuelve al estado consultar
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                _Mtd_Deshabilitar();
                _G_Bol_ModoGuardar = false;
                _G_Bol_ModoConsultar = true;
                

                //Registro del comprobante contable
                int _Int_IdComprobante = _Mtd_GenerarComprobante();
                //Imprimir comprobante contable
                if (_Int_IdComprobante > 0)
                {
                    _G_Str_SentenciaSQL = "UPDATE TAVISOPAGM SET CIDCOMPROB='" + _Int_IdComprobante + "' WHERE CCOMPANY='" + _P_Str_Compania + "' AND ccodavisopag='" + _Str_Aviso + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ImprimirComprobante(_Str_Aviso, _P_Str_Compania, _Int_IdComprobante);                    
                }
                //
            }
            catch(Exception _Err_)
            {
            }
        }
        /// <summary>
        /// Método que se encarga de imprimir el comprobante contable
        /// </summary>
        /// <param name="_P_Str_Aviso">Código del aviso </param>
        /// <param name="_P_Str_Compania">Código de la compañia</param>
        /// <param name="_P_Int_IdComprobante">Código del comprobante</param>
        private void _Mtd_ImprimirComprobante(string _P_Str_Aviso, string _P_Str_Compania,int _P_Int_IdComprobante)
        {
            try
            {
                //Imprime el comprobante
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Int_IdComprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _G_Bol_Impreso = true;
                        _Frm.Close();
                        _Frm.Dispose();
                        string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_IdComprobante + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        if (_G_Bol_ModoAnular)
                        {
                            _G_Str_SentenciaSQL = "UPDATE TCOMPROBAND SET cdatedocu=GETDATE(),cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_IdComprobante + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                            _G_Str_SentenciaSQL = "UPDATE TAVISOPAGM SET canulado='1',CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "' WHERE ccodavisopag='" + _P_Str_Aviso + "' AND CCOMPANY='" + _P_Str_Compania + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else
                        {
                            _Str_Cadena = "UPDATE TCOMPROBAND SET cdatedocu=getdate(),cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_IdComprobante + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }                        
                        MessageBox.Show("El proceso se finalizó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_TerminarProceso();
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _PrintComprob;
                    }
                }
                else
                {
                    MessageBox.Show("El comprobante puede ser impreso desde este formulario en la pestaña consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_TerminarProceso();
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.\nDebe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        /// <summary>
        /// Método que se usa para el cierre del proceso.
        /// </summary>
        private void _Mtd_TerminarProceso()
        {
            if (_G_Bol_ModoAnular && !_G_Bol_Impreso)
            {
                MessageBox.Show("El comprobante de anulación puede ser impreso desde este formulario en la pestaña consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _G_Bol_ModoGuardar = false;
            _Mtd_Consultar();
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            _Tb_Tab.SelectedIndex = 0;
        }
        /// <summary>
        /// Método que muestra el comprobante que será reversado.
        /// </summary>
        /// <param name="_P_Str_Aviso">Código del aviso</param>
        /// <param name="_P_Str_Compania">Código de la compañia</param>
        private void _Mtd_ReversarComprobante(string _P_Str_Aviso, string _P_Str_Compania)
        {
            try
            {
                _Dg_Comprobante.Rows.Clear();
                string _Str_IdComprob = "";
                _G_Str_SentenciaSQL = "SELECT CIDCOMPROB FROM TAVISOPAGM WHERE CCOMPANY='" + _P_Str_Compania + "' AND ccodavisopag='" + _P_Str_Aviso + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Str_IdComprob = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                _G_Str_SentenciaSQL = "SELECT ccount, cdescrip,ctotdebe, ctothaber FROM TCOMPROBAND WHERE CIDCOMPROB='" + _Str_IdComprob + "' AND CCOMPANY='"+_P_Str_Compania+"'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["ccount"].ToString().Trim();
                    _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["cdescrip"] + " " + " ANULACIÓN";
                    if (Convert.ToDouble(_Dtw_Item["ctothaber"].ToString())>0)
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctothaber"].ToString()).ToString("#,##0.00");
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "";
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()).ToString("#,##0.00");
                    }
                }
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
                }
                _Mtd_HabilitarCeldaXXXX(true);
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que genera el comprobante contable del aviso
        /// </summary>
        /// <returns>Retorna el id del comprobante contable</returns>
        private int _Mtd_GenerarComprobante()
        {
            _G_Str_SentenciaSQL="SELECT ctipdocavisocobro FROM TCONFIGCXC WHERE CCOMPANY='"+Frm_Padre._Str_Comp+"'";
            string _Str_TipoDocAviso = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL).Tables[0].Rows[0][0].ToString();
            //-------------------------------------------------------
            string _Str_ProcesoCont = "P_AVISO_COBRO_PAGAR";
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------
            int _Int_Comprobante = _myUtilidad._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(3))) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(4))) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','1','9')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //-------------------------------------------------------
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            string _Str_DescripD = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells[3].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells[4].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //---------------------------
                        _Str_DescripD = Convert.ToString(_Dg_Row.Cells[2].Value).Trim().ToUpper()+ " SEGÚN AVISO DE COBRO POR PAGAR N° "+_Txt_Cod.Text;
                        //------------------------------------------------------------------------
                        _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd)";
                        _Str_Cadena += " VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "','" + _Str_DescripD + "','" + _Str_TipoDocAviso + "','" + _Txt_Cod.Text.Trim().ToUpper() + "',GETDATE(),'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        
                        //if (Convert.ToDouble(_Ob_DebeD) > 0)
                        //{
                        //    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Str_Proveedor, _Str_DescripD, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "D");
                        //}
                        //else
                        //{
                        //    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Str_Proveedor, _Str_DescripD, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "H");
                        //}
                    }
                }
            }
            return _Int_Comprobante;
        }
        /// <summary>
        /// Método para deshabilitar el formulario
        /// </summary>
        private void _Mtd_Deshabilitar()
        {
            _Bt_Visulizar.Enabled = false;
            _Txt_Cod.Enabled = false;
            _Txt_Concepto.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Txt_Monto.Enabled = false;
            _Txt_IdAvisoCobro.Enabled = false;
            _Dtp_Emision.Enabled = false;
            _Cmb_CompaniaRelacionada.Enabled = false;
        }
        /// <summary>
        /// Método que permite visualizar el comprobante emitido por el aviso
        /// </summary>
        /// <param name="_P_Str_Aviso">Código del aviso</param>
        /// <param name="_P_Str_Compania">Código de la compañia.</param>
        private void _Mtd_VisualizarComprobanteEmitido(string _P_Str_Aviso, string _P_Str_Compania)
        {
            try
            {
                _Dg_Comprobante.Rows.Clear();
                string _Str_IdComprob = "";
                _G_Str_SentenciaSQL = "SELECT CIDCOMPROB FROM TAVISOPAGM WHERE CCOMPANY='" + _P_Str_Compania + "' AND ccodavisopag='" + _P_Str_Aviso + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Str_IdComprob = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                _G_Str_SentenciaSQL = "SELECT ccount, cdescrip,ctotdebe, ctothaber FROM TCOMPROBAND WHERE CIDCOMPROB='" + _Str_IdComprob + "' AND CCOMPANY='" + _P_Str_Compania + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["ccount"].ToString().Trim();
                    _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["cdescrip"] + " " + " ANULACIÓN";
                    if (Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()) > 0)
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()).ToString("#,##0.00");
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "";
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctothaber"].ToString()).ToString("#,##0.00");
                    }
                }
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
                }
                _Mtd_HabilitarCeldaXXXX(true);
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Bt_Visulizar.Enabled = false;
            }
            catch
            {
            }
        }
        private void _Dg_Grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        /// <summary>
        /// Método que permite visualizar el comprobante de anulación emitido por el aviso
        /// </summary>
        /// <param name="_P_Str_Aviso">Código del aviso</param>
        /// <param name="_P_Str_Compania">Código de la compañia.</param>
        private void _Mtd_VisualizarComprobanteAnulacionEmitido(string _P_Str_Aviso, string _P_Str_Compania)
        {
            try
            {
                _Dg_Comprobante.Rows.Clear();
                string _Str_IdComprob = "";
                _G_Str_SentenciaSQL = "SELECT CIDCOMPROBANUL FROM TAVISOPAGM WHERE CCOMPANY='" + _P_Str_Compania + "' AND ccodavisopag='" + _P_Str_Aviso + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Str_IdComprob = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                _G_Str_SentenciaSQL = "SELECT ccount, cdescrip,ctotdebe, ctothaber FROM TCOMPROBAND WHERE CIDCOMPROB='" + _Str_IdComprob + "' AND CCOMPANY='" + _P_Str_Compania + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["ccount"].ToString().Trim();
                    _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["cdescrip"] + " " + " ANULACIÓN";
                    if (Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()) > 0)
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()).ToString("#,##0.00");
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "";
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctothaber"].ToString()).ToString("#,##0.00");
                    }
                }
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
                }
                _Mtd_HabilitarCeldaXXXX(true);
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Bt_Visulizar.Enabled = false;
            }
            catch
            {
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _G_Bol_ModoConsultar = true;
            string _Str_Aviso = "";
            _Str_Aviso = _Dg_Grid.Rows[e.RowIndex].Cells["ccodavisopag"].Value.ToString();
            _G_Str_SentenciaSQL = "SELECT ccodavisocob,cfechaemision,cproveedor,cmonto,cconcepto,cdescripcion,cidcomprob,canulado,CIDCOMPROBANUL,cmotivoanul FROM TAVISOPAGM WHERE ccodavisopag='" + _Str_Aviso + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
            _Txt_Concepto.Text = _G_Ds_DataSet.Tables[0].Rows[0]["cconcepto"].ToString();
            _Txt_Descripcion.Text = _G_Ds_DataSet.Tables[0].Rows[0]["cdescripcion"].ToString();
            _Txt_Monto.KeyPress -= new KeyPressEventHandler(_Txt_Monto_KeyPress);
            _Txt_Monto.TextChanged -= new EventHandler(_Txt_Monto_TextChanged);
            _Txt_Monto.Text = Convert.ToDouble(_G_Ds_DataSet.Tables[0].Rows[0]["cmonto"].ToString()).ToString("#,##0");
            _Txt_Monto.KeyPress += new KeyPressEventHandler(_Txt_Monto_KeyPress);
            _Txt_Monto.TextChanged += new EventHandler(_Txt_Monto_TextChanged); 
            _Cmb_CompaniaRelacionada.SelectedValue = _G_Ds_DataSet.Tables[0].Rows[0]["cproveedor"].ToString();
            string _Str_IdComprobante = _G_Ds_DataSet.Tables[0].Rows[0]["cidcomprob"].ToString();
            string _Str_Anulado = _G_Ds_DataSet.Tables[0].Rows[0]["canulado"].ToString();
            string _Str_MotivoAnul = _G_Ds_DataSet.Tables[0].Rows[0]["cmotivoanul"].ToString();
            string _Str_IdComprobAnul = _G_Ds_DataSet.Tables[0].Rows[0]["cidcomprobanul"].ToString();
            _Txt_IdAvisoCobro.Text = _G_Ds_DataSet.Tables[0].Rows[0]["ccodavisocob"].ToString();
            _Dtp_Emision.Value = Convert.ToDateTime(_G_Ds_DataSet.Tables[0].Rows[0]["cfechaemision"].ToString()); ;
            _G_Str_SentenciaSQL = "SELECT CSTATUS FROM TCOMPROBANC WHERE CIDCOMPROB='"+_Str_IdComprobante+"' AND CCOMPANY='"+Frm_Padre._Str_Comp+"'";
            string _Str_Status = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL).Tables[0].Rows[0][0].ToString();
            string _Str_Impreso = "";
            if (_Str_Status == "9")
            {
                _Str_Impreso = "0";
            }
            if (_Str_Anulado == "1" || _Str_IdComprobAnul != "0")
            {
                _Mtd_CargarMotivoAnulacion();
                _Pnl_Anulacion.Visible = true;
                _Cmb_MotivoAnulacion.Enabled = false;
                _Cmb_MotivoAnulacion.SelectedValue = _Str_MotivoAnul;
                //Muestra el motivo de anulación
            }
            else
            {
                _Pnl_Anulacion.Visible = false;
            }
            if (_G_Int_Proceso == 0)
            {                
                _Txt_Cod.Text = _Str_Aviso;
                _G_Bol_ModoConsultar = true;
                _Mtd_Deshabilitar();
                _Dg_Comprobante.CellClick -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
                _Dg_Comprobante.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
                _Dg_Comprobante.CellBeginEdit -= new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
                _Dg_Comprobante.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
                _Tb_Tab.SelectedIndex = 1;
                _Mtd_VisualizarComprobanteEmitido(_Txt_Cod.Text, Frm_Padre._Str_Comp);
                if (_Str_Impreso == "0")
                {
                    _G_Bol_Impreso = false;
                    _Mtd_ImprimirComprobante(_Txt_Cod.Text, Frm_Padre._Str_Comp, Convert.ToInt32(_Str_IdComprobante));
                }
                else
                {
                    if (_Str_Anulado == "0" && _Str_IdComprobAnul != "0")
                    {
                        _G_Bol_ModoAnular=true;
                        _Mtd_ImprimirComprobante(_Txt_Cod.Text, Frm_Padre._Str_Comp, Convert.ToInt32(_Str_IdComprobAnul));
                    }
                }
            }
            else if (_G_Int_Proceso == 1)
            {
                _Txt_Cod.Text = _Str_Aviso;
                _Mtd_Deshabilitar();
                _G_Bol_ModoGuardar = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _G_Bol_ModoGuardar;
                _Bt_Visulizar.Enabled = true;
                _Pnl_Anulacion.Visible = true;
                _Tb_Tab.SelectedIndex = 1;
                if (_Cmb_MotivoAnulacion.Items.Count > 0)
                {
                    if (_Str_Anulado == "1" || _Str_IdComprobAnul != "0")
                    {
                        _G_Bol_ModoGuardar = false;
                        _G_Bol_Impreso = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _G_Bol_ModoGuardar;
                        _Mtd_VisualizarComprobanteAnulacionEmitido(_Txt_Cod.Text, Frm_Padre._Str_Comp);
                        if (MessageBox.Show("Está preparada la impresora para imprimir el comprobante contable?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            _Mtd_ImprimirComprobante(_Txt_Cod.Text, Frm_Padre._Str_Comp, Convert.ToInt32(_Str_IdComprobAnul));
                        }
                        else
                        {
                            _G_Bol_Impreso = false;
                            _Mtd_TerminarProceso();
                        }
                    }
                    else
                    {
                        _Cmb_MotivoAnulacion.Enabled = true;
                        _Cmb_MotivoAnulacion.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                _Txt_Cod.Text = _Str_Aviso;
                _G_Bol_ModoConsultar = true;
                _Mtd_Deshabilitar();
                _Dg_Comprobante.CellClick -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
                _Dg_Comprobante.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
                _Dg_Comprobante.CellBeginEdit -= new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
                _Dg_Comprobante.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
                _Tb_Tab.SelectedIndex = 1;
                _Mtd_VisualizarComprobanteEmitido(_Txt_Cod.Text, Frm_Padre._Str_Comp);
                if (_Str_Impreso == "0")
                {
                    _G_Bol_Impreso = false;
                    _Mtd_ImprimirComprobante(_Txt_Cod.Text, Frm_Padre._Str_Comp, Convert.ToInt32(_Str_IdComprobante));
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void _Txt_IdAvisoCobro_TextChanged(object sender, EventArgs e)
        {
            if (!_myUtilidad._Mtd_IsNumeric(_Txt_IdAvisoCobro.Text)) { _Txt_IdAvisoCobro.Text = ""; }
            _Dg_Comprobante.Rows.Clear();
            _Txt_IdAvisoCobro.Text=_Txt_IdAvisoCobro.Text.Replace(".", "").Replace(",", "");
        }

        private void _Txt_IdAvisoCobro_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_IdAvisoCobro, e, 15, 2);
            _Dg_Comprobante.Rows.Clear();
            _Txt_IdAvisoCobro.Text=_Txt_IdAvisoCobro.Text.Replace(".", "").Replace(",", "");
        }

        private void _Mnu_Opciones_Opening(object sender, CancelEventArgs e)
        {
            if (this._Dg_Grid.SelectedRows.Count != 1)
            {
                e.Cancel = true;
            }
        }

        private void _Mnu_Seleccionar_Click(object sender, EventArgs e)
        {
            using (DataGridViewRow Fila = this._Dg_Grid.Rows[this._Dg_Grid.CurrentCell.RowIndex])
            {
                if (Fila.DefaultCellStyle.BackColor == Color.White)
                {
                    Fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                }

                this._Mnu_Seleccionar.Enabled = false;
                this._Mnu_Deseleccionar.Enabled = true;
                this._Mnu_GenerarOrdenPago.Enabled = true;
            }
        }

        private void _Mnu_Deseleccionar_Click(object sender, EventArgs e)
        {
            using (DataGridViewRow Fila = this._Dg_Grid.Rows[this._Dg_Grid.CurrentCell.RowIndex])
            {
                if (Fila.DefaultCellStyle.BackColor == Color.FromArgb(255, 192, 192))
                {
                    Fila.DefaultCellStyle.BackColor = Color.White;
                }

                this._Mnu_Seleccionar.Enabled = true;
                this._Mnu_Deseleccionar.Enabled = false;
                this._Mnu_GenerarOrdenPago.Enabled = false;
            }
        }

        private void _Mnu_GenerarOrdenPago_Click(object sender, EventArgs e)
        {
            string _Str_Proveedor;
            string _Str_Descripcion;
            long _Lng_Total;
            int _Int_Contador;
            Frm_GeneracionOP _Frm_Generador;

            /*
             * Verificamos que el aviso de cobro no tenga orden de pago, que sus proveedores sean los mismo, que el estado esté por pagar 
             * y que no estén anulados.
             */

            using (DataGridViewRow FilaActual = this._Dg_Grid.Rows[this._Dg_Grid.CurrentCell.RowIndex])
            {
                _Str_Proveedor = FilaActual.Cells[2].Value.ToString();
                _Str_Descripcion = FilaActual.Cells[1].Value.ToString();

                if (this._Mtd_TieneOrdenPago(FilaActual.Cells[5].Value.ToString()))
                {
                    MessageBox.Show("Este aviso ya tiene una orden de pago generada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this._Mnu_Deseleccionar_Click(sender, e);
                    return;
                }

                if (Convert.ToInt32(FilaActual.Cells["canulado"].Value.ToString()) != 0)
                {
                    MessageBox.Show("Este aviso está anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this._Mnu_Deseleccionar_Click(sender, e);
                    return;
                }

                for (int i = 0; i < this._Dg_Grid.Rows.Count; i++)
                {
                    using (DataGridViewRow FilaSeleccionada = this._Dg_Grid.Rows[i])
                    {
                        if (FilaSeleccionada.DefaultCellStyle.BackColor == Color.FromArgb(255, 192, 192))
                        {
                            if ((_Str_Proveedor != FilaSeleccionada.Cells[2].Value.ToString()) || (_Str_Descripcion != FilaSeleccionada.Cells[1].Value.ToString()))
                            {
                                MessageBox.Show("Los avisos de cobro no tienen el mismo proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this._Mnu_Deseleccionar_Click(sender, e);
                                return;
                            }
                        }
                    }
                }
            }

            _Lng_Total = 0;

            /*
             * Determinamos cuantos campos estan seleccionados.
             */


            for (int i = 0; i < this._Dg_Grid.Rows.Count; i++)
            {
                using (DataGridViewRow FilaSeleccionada = this._Dg_Grid.Rows[i])
                {
                    if (FilaSeleccionada.DefaultCellStyle.BackColor == Color.FromArgb(255, 192, 192))
                    {
                        _Lng_Total++;
                    }
                }
            }

            /*
             * Si todos los campos están correctos llamamos al formulario de ordenes de pago.
             */
                        
            _Int_Contador = 0;

            string[] _Str_CodAvisosPagos = new string[_Lng_Total];
            string[] _Str_CodAvisosCobros = new string[_Lng_Total];
            double[] _Str_Montos = new double[_Lng_Total];
            
            for (int i = 0; i < this._Dg_Grid.Rows.Count; i++)
            {
                using (DataGridViewRow Fila = this._Dg_Grid.Rows[i])
                {
                    if (Fila.DefaultCellStyle.BackColor == Color.FromArgb(255, 192, 192))
                    {
                        _Str_CodAvisosPagos[_Int_Contador] = Fila.Cells[5].Value.ToString();
                        _Str_CodAvisosCobros[_Int_Contador] = Fila.Cells[0].Value.ToString();
                        _Str_Montos[_Int_Contador] = Convert.ToDouble(Fila.Cells[4].Value.ToString());

                        _Int_Contador++;
                    }
                }
            }

            _Frm_Generador = new Frm_GeneracionOP(_Str_CodAvisosPagos, _Str_CodAvisosCobros, _Str_Montos, _Str_Proveedor, _Str_Descripcion);

            if (_Frm_Generador.ShowDialog(this) == DialogResult.Yes)
            {
                this._Mtd_Consultar();
            }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                using (DataGridViewRow Fila = this._Dg_Grid.Rows[this._Dg_Grid.CurrentCell.RowIndex])
                {
                    if (Fila.DefaultCellStyle.BackColor == Color.FromArgb(255, 192, 192))
                    {
                        this._Mnu_Seleccionar.Enabled = false;
                        this._Mnu_Deseleccionar.Enabled = true;
                        this._Mnu_GenerarOrdenPago.Enabled = true;
                    }
                    else
                    {
                        this._Mnu_Seleccionar.Enabled = true;
                        this._Mnu_Deseleccionar.Enabled = false;
                        this._Mnu_GenerarOrdenPago.Enabled = false;
                    }
                }
            }
        }
    }
}
