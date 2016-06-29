using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.EnterpriseServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_ComprobIAEManual : Form
    {
        private bool _Bol_PermitirClicTabDetalle = false, _Bol_Agregando = false, _Bol_ComprobaRetIAE_Impreso = false, _Bol_ComprobaCont_Impreso = false, _Bol_DocumentosImpresos = false, _Bol_Rechazando = false, _Bol_Editando = false, _Bol_Anulando = false;
        private string _Str_CompanyRetenExterna = "", _Str_Global_Sustraendo = "", _Str_Global_ID_IAE_Misterioso = "", _Str_Global_Formula = "", _Str_Global_FechaVencimientoDocumento = "", _Str_Proveedor_Edit = "", _Str_Global_IdRetencion = "";
        
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        
        public Frm_ComprobIAEManual(){InitializeComponent();}

        private bool _Bol_Aprobando = false, _Bol_Imprimiendo = false, _Bol_Rachazadas = false;
        public Frm_ComprobIAEManual(bool _Bol_Aprobador, bool _Bol_Imprimir, bool _Bol_Rechazar)
        {
            _Bol_Aprobando = _Bol_Aprobador;
            _Bol_Imprimiendo = _Bol_Imprimir;
            _Bol_Rachazadas = _Bol_Rechazar;
            InitializeComponent();
        }

        private void _Mtd_LlenarGridPrincipal()
        {
            string _Str_Cadena = "", _Str_Mensaje = "";
            string[] _Str_Campos = new string[2];

            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];

            _Tsm_Menu[0] = new ToolStripMenuItem("No. comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            _Str_Campos[0] = "cidcomprobret";
            _Str_Campos[1] = "c_nomb_comer";
            _Str_Mensaje = "Comprobantes registrados";
            // *****muestra todos los comprobantes pedientes por aprobar*****
            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
            if (_Rb_PorAprobar.Checked) { _Str_Cadena = "EXEC PA_GESTIONA_RETENCIONES_IAE 1, " + Frm_Padre._Str_GroupComp.Trim() + ", '" + Frm_Padre._Str_Comp.Trim() + "', 0"; }
            // *****muestra todos los comprobantes aprobados*****
            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
            if (_Rb_Aprobados.Checked && !_Bol_Imprimiendo) { _Str_Cadena = "EXEC PA_GESTIONA_RETENCIONES_IAE 4, " + Frm_Padre._Str_GroupComp.Trim() + ", '" + Frm_Padre._Str_Comp.Trim() + "', 0"; }
            // *****muestra todos los comprobantes aprobados e impresos*****
            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
            if (_Rb_Aprobados.Checked && _Bol_Imprimiendo) { _Str_Cadena = "EXEC PA_GESTIONA_RETENCIONES_IAE 3, " + Frm_Padre._Str_GroupComp.Trim() + ", '" + Frm_Padre._Str_Comp.Trim() + "', 0"; }
            // *****muestra todos los comprobantes rechazados*****
            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
            if (!_Rb_Aprobados.Checked && !_Rb_PorAprobar.Checked && !_Rb_Anulados.Checked && _Bol_Rachazadas)
            {
                _Str_Cadena = "EXEC PA_GESTIONA_RETENCIONES_IAE 5, " + Frm_Padre._Str_GroupComp.Trim() + ", '" + Frm_Padre._Str_Comp.Trim() + "', 0";
                _Str_Mensaje = "Comprobantes rechazados";
            }
            // *****muestra todos los comprobantes anulados*****
            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
            if (_Rb_Anulados.Checked) { _Str_Cadena = "EXEC PA_GESTIONA_RETENCIONES_IAE 6, " + Frm_Padre._Str_GroupComp.Trim() + ", '" + Frm_Padre._Str_Comp.Trim() + "', 0"; }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena.Trim(), _Str_Campos, _Str_Mensaje.Trim(), _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1) { _Lbl_DgInfo.Visible = true; }
            else { _Lbl_DgInfo.Visible = false; }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                if (!_Bol_Aprobando && !_Bol_Imprimiendo && !_Bol_Rachazadas){ _Mtd_Habilita_Botones_Menu(false,"Nuevo"); }
                if (_Bol_Rachazadas) { _Mtd_Habilita_Botones_Menu(false, ""); }
                _Mtd_LimpiarDetalle();
                _Mtd_DesactivarTodo();
                _Bol_PermitirClicTabDetalle = false;
                _Bol_Agregando = false;
            }
            if (e.TabPageIndex == 1 && !_Bol_PermitirClicTabDetalle)
            {
                e.Cancel = true;
            }
            else if (e.TabPageIndex == 1)
            {
                if (_Bol_Rachazadas){ _Mtd_Habilita_Botones_Menu(false, "Editar"); }
            }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                string _Str_NumeroComprobante = "", _Str_CodigoCompania = "";
                int Int_GrupoCompania = 0;

                Cursor = Cursors.WaitCursor;
                _Str_NumeroComprobante = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex).Trim();
                _Str_CodigoCompania = Frm_Padre._Str_Comp.ToString().Trim();
                Int_GrupoCompania = Convert.ToInt16(Frm_Padre._Str_GroupComp.ToString().Trim());
                _Mtd_MostrarDetalle(Int_GrupoCompania,_Str_CodigoCompania,_Str_NumeroComprobante);
                _Mtd_MostrarPestanaDetalle();
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_MostrarPestanaDetalle()
        {
            _Bol_PermitirClicTabDetalle = true;
            _Tb_Tab.SelectedIndex = 1;
            _Bol_PermitirClicTabDetalle = false;
        }

        private bool _Mtd_ConDocumento(string _Str_NumeroComprobante)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT cidcomprobret FROM TFACTPPAGARM " +
                          "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany = '" + Frm_Padre._Str_Comp + "' and cidcomprobret = '" + _Str_NumeroComprobante + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Mtd_MostrarDetalle(int _Int_GrupoCompania, string _Str_CodigoCompania, string _Str_NumeroComprobante)
        {
            string _Str_Cadena = "";

            DataSet _Ds = new DataSet();

            _Mtd_LimpiarDetalle();
            //***Obtiene y muestra detalle de una retenciòn seleccionada***
            //***Parametros de SP (Caso (INT) / Grupo de Compañìa (INT) / Compañìa (NVARCHAR) / @IdComprobanteRet (NUMERIC))****
            _Str_Cadena = "EXEC PA_GESTIONA_RETENCIONES_IAE 2, " + _Int_GrupoCompania + ", '" + _Str_CodigoCompania + "', " + Convert.ToInt32(_Str_NumeroComprobante);
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_IdComprobante.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cidcomprobret"]);
                _Txt_NumComprobante.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumcomprobante"]);
                _DTP_FechaEmisionComprobante.Value = Convert.ToDateTime(Convert.ToString(_Ds.Tables[0].Rows[0]["cfechaemiret"]));
                _Txt_NumeroDocumento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocumafec"]);
                if (_Txt_NumeroDocumento.Text.Trim() != "0")
                {
                    if (_Mtd_ConDocumento(_Txt_IdComprobante.Text.Trim())){_Rb_ConDocumento.Checked = true;}
                    else{_Rb_IngresarDocumento.Checked = true;}
                }
                _Cmb_TipoProv.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cglobal"]);
                _Cmb_CategProv.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveedor"]);
                _Txt_Rif.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_rif"]);
                _Txt_NumeroPatente.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumpatente"]);
                _Cmb_Proveedor.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cproveedor"]);
                _Txt_NumeroRUC.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumruc"]);
                _Txt_CodActEcon.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccodactividadecono"]);
                _Cmb_TipoDocumento.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumento"]);
                _Txt_FechaEmisionDocumento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cfechaemidoc"]);
                _Dtp_Emision.Value = Convert.ToDateTime(Convert.ToString(_Ds.Tables[0].Rows[0]["cfechaemidoc"]));
                _Txt_NumeroDocumento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocumafec"]);
                if (_Ds.Tables[0].Rows[0]["cnumctrldocumafec"].ToString().Trim() == "NA"){_Chk_FactMaqFis.Checked = true;}
                else
                {
                    _Chk_FactMaqFis.Checked = false;
                    _Txt_NumCtrlPref.Text = _Ds.Tables[0].Rows[0]["cnumctrldocumafec"].ToString().Trim().Substring(0,_Ds.Tables[0].Rows[0]["cnumctrldocumafec"].ToString().Trim().IndexOf("-"));
                    _Txt_NumCtrl.Text = _Ds.Tables[0].Rows[0]["cnumctrldocumafec"].ToString().Trim().Substring(_Ds.Tables[0].Rows[0]["cnumctrldocumafec"].ToString().Trim().IndexOf("-") + 1);
                }
                _Txt_BaseImponible.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotcaomp_siva"]);
                _Txt_MontoExento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotmontexcento"]);
                _Txt_AlicuotaIVA.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["calicuotaiva"]);
                _Txt_MontoIVA.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                _Txt_MontoTotal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotcaomp_iva"]);
                _Txt_AlicuotaRet.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cporcnreten"]);
                _Txt_MontoRetenido.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cretenido"]);
                _Mtd_DesactivarTodo();
                if (_Mtd_VerificaDocumentosImpresos(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim()))
                {
                    _Btn_VerComprobante.Visible = true;
                    _Btn_Imprimir.Visible = true;
                    _Bol_DocumentosImpresos = true;
                }
            }
        }

        private void _Mtd_LimpiarDetalle()
        {
            if (_Cmb_TipoProv.Items.Count > 0) _Cmb_TipoProv.SelectedIndex = 0;
            if (_Cmb_CategProv.Items.Count > 0) _Cmb_CategProv.SelectedIndex = 0;
            if (_Cmb_Proveedor.Items.Count > 0) _Cmb_Proveedor.SelectedIndex = 0;
            if (_Cmb_TipoDocumento.Items.Count > 0) _Cmb_TipoDocumento.SelectedIndex = 0;
            _Rb_ConDocumento.Checked = false;
            _DTP_FechaEmisionComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Txt_IdComprobante.Text = "";
            _Txt_NumComprobante.Text = "";
            _Txt_NumeroDocumento.Text = "";
            _Txt_NumeroDocumento.Tag = "";
            _Txt_NumCtrl.Text = "";
            _Txt_FechaEmisionDocumento.Text = "";
            _Txt_BaseImponible.Text = "";
            _Txt_MontoExento.Text = "";
            _Txt_MontoRetenido.Text = "";
            _Txt_AlicuotaIVA.Text = "";
            _Txt_MontoIVA.Text = "";
            _Txt_MontoTotal.Text = "";
            _Txt_Rif.Text = "";
            _Txt_NumeroPatente.Text = "";
            _Txt_NumeroRUC.Text = "";
            _Txt_CodActEcon.Text = "";
            _Txt_NumCtrlPref.Text = "";                
        }

        private void _Mtd_LimpiarDetalleDocumento()
        {
            _Txt_IdComprobante.Text = "";
            _Txt_NumComprobante.Text = "";
            _Txt_NumeroDocumento.Text = "";
            _Txt_NumeroDocumento.Tag = "";
            _Txt_NumCtrl.Text = "";
            _Txt_FechaEmisionDocumento.Text = "";
            _Txt_BaseImponible.Text = "";
            _Txt_MontoExento.Text = "";
            _Txt_MontoRetenido.Text = "";
            _Txt_AlicuotaIVA.Text = "";
            _Txt_MontoIVA.Text = "";
            _Txt_MontoTotal.Text = "";
        }

        private void _Mtd_CargarTipoProv()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_TipoProv.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.DisplayMember = "Display";
            _Cmb_TipoProv.ValueMember = "Value";
            _Cmb_TipoProv.SelectedValue = "nulo";
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.SelectedIndex = 0;
        }

        private void _Mtd_CargarCategProv()
        {
            string _Str_Cadena = "";

            Cursor = Cursors.WaitCursor;
            _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR " + 
                          "WHERE cdelete = '0' ";
            if (_Cmb_TipoProv.SelectedIndex > 0){ _Str_Cadena += "AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "' "; }
            _Str_Cadena += "ORDER BY Nombre";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_CategProv, _Str_Cadena.Trim());
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarTipoDodumento()
        {
            string _Str_Cadena = "";

            Cursor = Cursors.WaitCursor;
            _Str_Cadena = "select ctdocument, cname from [dbo].[TDOCUMENT] " +
                          "where ccomprobanret = 1";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_TipoDocumento, _Str_Cadena.Trim());
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarProvee()
        {
            string _Str_Cadena = "";

            Cursor = Cursors.WaitCursor;
            _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer FROM TPROVEEDOR " + 
                          "LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor " + 
                          "WHERE ISNULL(TPROVEEDOR.cdelete,0) = '0' AND ISNULL(TGRUPPROVEE.cdelete,0) = '0' AND TPROVEEDOR.c_activo = '1' ";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                if (_Cmb_TipoProv.SelectedValue.ToString().Trim() == "0" | _Cmb_TipoProv.SelectedValue.ToString().Trim() == "2") { _Str_Cadena += "AND TPROVEEDOR.ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND TPROVEEDOR.cglobal = '" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "' "; }
                else { _Str_Cadena += "AND TGRUPPROVEE.ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cglobal = '" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "' "; }
            }
            else { _Str_Cadena += "AND ((TGRUPPROVEE.CCOMPANY = '" + Frm_Padre._Str_Comp.Trim() + "' AND TPROVEEDOR.cglobal = '1') OR (TPROVEEDOR.cglobal <> '1' AND TPROVEEDOR.ccompany = '" + Frm_Padre._Str_Comp.Trim() + "')) "; }
            if (_Cmb_CategProv.SelectedIndex > 0) { _Str_Cadena += "AND TPROVEEDOR.ccatproveedor = '" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "' "; }
            _Str_Cadena += "ORDER BY TPROVEEDOR.c_nomb_comer ";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena.Trim());
            Cursor = Cursors.Default;
        }

        private void _Mtd_BuscaDatosProveedor(string _str_CodProveedor)
        {
            string _str_Cadena = "";
            bool _Bol_NoRetiene = false;
            DataSet _Ds = new DataSet();

            Cursor = Cursors.WaitCursor;
            _str_Cadena = "select isnull(cretienepatente,0) as cretienepatente, isnull(cnumpatente,0) as cnumpatente, isnull(cnumruc,0) as cnumruc, isnull(cporcenretpat,0) as cporcenretpat, c_rif, isnull(ccodactividadecono,0) as ccodactividadecono from tproveedor " + 
                          "where cproveedor = '" + _str_CodProveedor.Trim() + "' ";
            if (_Cmb_TipoProv.SelectedValue.ToString().Trim() != "1") { _str_Cadena = _str_Cadena + "and ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' "; }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(_Ds.Tables[0].Rows[0]["cretienepatente"]) == 1)
                {
                    _Bol_NoRetiene = true;
                    _Txt_Rif.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_rif"]).Trim();
                    _Txt_NumeroPatente.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumpatente"]).Trim();
                    _Txt_NumeroRUC.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumruc"]).Trim();
                    _Txt_CodActEcon.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccodactividadecono"]).Trim();
                    _Txt_AlicuotaRet.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cporcenretpat"]).Trim();
                }
                else{ MessageBox.Show("Este proveedor no está configurado para aplicar retención de actividades económicas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else{ MessageBox.Show("No se han encontrado los datos del proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if(!_Bol_NoRetiene)
            {
                _Txt_Rif.Text = "";
                _Txt_NumeroPatente.Text = "0";
                _Txt_NumeroRUC.Text = "0";
                _Txt_CodActEcon.Text = "0";
                _Txt_AlicuotaRet.Text = "0";
            }
            Cursor = Cursors.Default;
        }

        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cmb_CategProv.SelectedIndexChanged -= new EventHandler(_Cmb_CategProv_SelectedIndexChanged);
            _Mtd_CargarCategProv();
            _Cmb_CategProv.SelectedIndexChanged += new EventHandler(_Cmb_CategProv_SelectedIndexChanged);
            _Cmb_Proveedor.SelectedIndexChanged -= new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            _Mtd_CargarProvee();
            _Cmb_Proveedor.SelectedIndexChanged += new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            _Mtd_InicializarFomulario();
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cmb_Proveedor.SelectedIndexChanged -= new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            _Mtd_CargarProvee();
            _Cmb_Proveedor.SelectedIndexChanged += new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            _Mtd_InicializarFomulario();
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_InicializarFomulario();
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Rb_ConDocumento.Enabled = true;
                _Rb_IngresarDocumento.Enabled = true;
                _Mtd_BuscaDatosProveedor(this._Cmb_Proveedor.SelectedValue.ToString());
            }
        }

        private void _Rb_ConDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_ConDocumento.Checked)
            {
                _Mtd_DesactivarTodo();
                if (_Bol_Agregando || _Bol_Editando)
                {
                    _Mtd_LimpiarDetalleDocumento();
                    _Mtd_ActivarNuevoConDocumento();
                    _Mtd_InicializarControles();
                }
            }
        }

        public void _Mtd_Nuevo()
        {
            _Bol_Agregando = true;
            _Mtd_Habilita_Botones_Menu(false, "Guardar");
            _Mtd_MostrarPestanaDetalle();
            _Mtd_LimpiarDetalle();
            _Rb_ConDocumento.Checked = true;
            _Mtd_InicializarControles();
            _DTP_FechaEmisionComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Txt_AlicuotaIVA.Text = _Mtd_PorcentajeIVAActual();
            _Rb_ConDocumento.Enabled = false;
            _Rb_IngresarDocumento.Enabled = false;
        }

        public void _Mtd_Habilitar()
        {
            _Bol_Editando = true;
            _Str_Proveedor_Edit = _Cmb_Proveedor.SelectedValue.ToString();
            _Mtd_Habilita_Botones_Menu(false, "Guardar");
            _Mtd_MostrarPestanaDetalle();
            _Mtd_Habilita_Detalle();
        }

        private void _Mtd_InicializarControles()
        {
            _Txt_BaseImponible.Text = "0,00";
            _Txt_MontoExento.Text = "0,00";
            _Txt_MontoRetenido.Text = "0,00";
            _Txt_AlicuotaIVA.Text = "";
            _Txt_AlicuotaIVA.Tag = "";
            _Txt_MontoIVA.Text = "0,00";
            _Txt_MontoTotal.Text = "0,00";            
        }

        private void _Mtd_DesactivarTodo()
        {
            _Cmb_TipoProv.Enabled = false;
            _Cmb_CategProv.Enabled = false;
            _Cmb_Proveedor.Enabled = false;
            _Txt_IdComprobante.Enabled = false;
            _Txt_NumComprobante.Enabled = false;
            _DTP_FechaEmisionComprobante.Enabled = false;
            _Rb_ConDocumento.Enabled = false;
            _Rb_IngresarDocumento.Enabled = false;
            _Txt_NumeroDocumento.Enabled = false;
            _Btn_Documento.Enabled = false;
            _Txt_FechaEmisionDocumento.Enabled = false;
            _Txt_NumCtrl.Enabled = false;
            _Txt_BaseImponible.Enabled = false;
            _Txt_MontoExento.Enabled = false;
            _Btn_AlicuotaIVA.Enabled = false;
            _Txt_MontoIVA.Enabled = false;
            _Txt_MontoTotal.Enabled = false;
            _Txt_MontoRetenido.Enabled = false;
            _Txt_NumCtrl.Enabled = false;
            _Txt_NumCtrlPref.Enabled = false;
            _Chk_FactMaqFis.Enabled = false;
            _Dtp_Emision.Visible = false;
            _Txt_FechaEmisionDocumento.Visible = true;
            _Cmb_TipoDocumento.Enabled = false;
            _Btn_Aprobar.Visible = _Bol_Aprobando;
            _Btn_Rechazar.Visible = _Bol_Aprobando;
            _Btn_Anular.Visible = _Bol_Aprobando;
            _Btn_Imprimir.Visible = _Bol_Imprimiendo;
            _Btn_VerComprobante.Visible = _Bol_Imprimiendo;
            _Pnl_Clave.Visible = false;
            if (!_Bol_Aprobando && !_Bol_Imprimiendo && !_Bol_Rachazadas) { _Rb_Aprobados.Select(); }
            if (_Bol_Aprobando)
            {
                _Mtd_Desactivar_Rbn_Consultas(false);
                _Rb_PorAprobar.Enabled = true;
                _Rb_PorAprobar.Select();
            }
            if (_Bol_Imprimiendo)
            {
                _Mtd_Desactivar_Rbn_Consultas(false);
                _Rb_Aprobados.Enabled = true;
                _Rb_Aprobados.Select();
            }
            if (_Bol_Rachazadas)
            {
                _Mtd_Desactivar_Rbn_Consultas(false);
                _Mtd_LlenarGridPrincipal();
            }
        }

        private void _Mtd_Desactivar_Rbn_Consultas(bool _Bol_Habilita)
        {
            _Rb_PorAprobar.Enabled = _Bol_Habilita;
            _Rb_Aprobados.Enabled = _Bol_Habilita;
            _Rb_Anulados.Enabled = _Bol_Habilita;
        }

        private void _Mtd_ActivarNuevoSinDocumento()
        {
            _Rb_ConDocumento.Enabled = true;
            _Rb_IngresarDocumento.Enabled = true;
            _Cmb_TipoProv.Enabled = true;
            _Cmb_CategProv.Enabled = true;
            _Cmb_Proveedor.Enabled = true;
            _Txt_BaseImponible.Enabled = true;
            _Txt_MontoExento.Enabled = true;
            _Btn_AlicuotaIVA.Enabled = true;
        }

        private void _Mtd_ActivarNuevoConDocumento()
        {
            _Rb_ConDocumento.Enabled = true;
            _Rb_IngresarDocumento.Enabled = true;
            _Cmb_TipoProv.Enabled = true;
            _Cmb_CategProv.Enabled = true;
            _Cmb_Proveedor.Enabled = true;
            _Btn_Documento.Enabled = true;
        }

        private void Frm_ComprobIAEManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Mtd_Habilita_Botones_Menu(false, "");
        }
        
        private void _Mtd_ActualizarMontoRetenido()
        {
            double _Dbl_BaseImponible = 0, _Dbl_AlicuotaRet = 0, _Dbl_MontoRetenido = 0, _Dbl_MontoExcento = 0;

            if (_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim())) { _Dbl_BaseImponible = Convert.ToDouble(_Txt_BaseImponible.Text); }
            if (_Mtd_IsNumeric(_Txt_MontoExento.Text.Trim())) { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExento.Text); }
            if (_Mtd_IsNumeric(_Txt_AlicuotaRet.Text.Trim())) { _Dbl_AlicuotaRet = Convert.ToDouble(_Txt_AlicuotaRet.Text); }
            _Dbl_MontoRetenido = (((_Dbl_BaseImponible + _Dbl_MontoExcento) * _Dbl_AlicuotaRet) / 100);
            _Txt_MontoRetenido.Text = Convert.ToString(_Dbl_MontoRetenido.ToString("#,##0.00"));                

        }

        private void _Btn_Documento_Click(object sender, EventArgs e)
        {
            string _Str_CodigoGrupoCompania = "", _Str_CodigoCompania = "", _Str_CodigoProveedor = "";

            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Str_CodigoGrupoCompania = Frm_Padre._Str_GroupComp;
                _Str_CodigoCompania = Frm_Padre._Str_Comp;
                _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(80, _Str_CodigoGrupoCompania, _Str_CodigoCompania, _Str_CodigoProveedor);                
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult != "0") { _Mtd_MostrarDetalleDocumento(_Str_CodigoCompania,_Str_CodigoProveedor,_Frm._Str_FrmResult); }
            }
            else { MessageBox.Show("Seleccione un proveedor antes de seguir.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        }

        private void _Mtd_MostrarDetalleDocumento(string _Str_CodigoCompania,string _Str_CodigoProveedor, string _Str_NumeroDocumento)
        {
            long _Int_NumeroDocumento = 0;
            string _Str_NumeroDocumentoSinCeros = "", _Str_Global_FechaVencimientoDocumento = "", _Str_Cadena = "";

            DataSet _Ds = new DataSet();

            //_Int_NumeroDocumento = Convert.ToInt64(_Str_NumeroDocumento);
            _Str_NumeroDocumentoSinCeros = _Int_NumeroDocumento.ToString();

            _Str_Cadena = "select cidfactxp, dbo.Fnc_Formatear(calicuota) as calicuota, dbo.Fnc_Formatear(ctotal) as ctotal, dbo.Fnc_Formatear(cmontoinvendible) as cmontoinvendible, dbo.Fnc_Formatear(ctotalimp) as ctotalimp, convert(VARCHAR,cdateemifactura,103) as cfechaemision, convert(VARCHAR,cfechavencimiento,103) as cfechavencimiento, cnumdocuctrl, ctipodocument, dbo.Fnc_Formatear(ctotalsimp) as ctotalsimp, dbo.Fnc_Formatear(ctotmontexcento) as ctotmontexcento from dbo.TFACTPPAGARM " +
                          "WHERE ccompany = '" + _Str_CodigoCompania.Trim() + "' AND cproveedor ='" + _Str_CodigoProveedor.Trim() + "' and cnumdocu = '" + _Str_NumeroDocumento.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_NumeroDocumento.Text = _Str_NumeroDocumento;
                _Txt_NumeroDocumento.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cidfactxp"]);
                _Txt_BaseImponible.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotalsimp"]);
                _Txt_MontoExento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotmontexcento"]);
                if (_Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim() == "NA"){_Chk_FactMaqFis.Checked = true;}
                else
                {
                    _Chk_FactMaqFis.Checked = false;
                    _Txt_NumCtrlPref.Text = _Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().Substring(0, _Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().IndexOf("-"));
                    _Txt_NumCtrl.Text = _Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().Substring(_Ds.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().IndexOf("-") + 1);
                }
                _Txt_FechaEmisionDocumento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                _Str_Global_FechaVencimientoDocumento = Convert.ToString(_Ds.Tables[0].Rows[0]["cfechavencimiento"]);
                _Txt_MontoIVA.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotalimp"]);
                _Txt_MontoTotal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctotal"]);
                _Txt_AlicuotaIVA.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["calicuota"]);
                _Cmb_TipoDocumento.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument"]);             
            }
            _Mtd_ActualizarMontoRetenido();
        }

        private void _Mtd_InicializarFomulario()
        {
            if (_Bol_Agregando) { _Mtd_InicializarControles(); }
            if (_Bol_Agregando && _Cmb_Proveedor.Items.Count > 1 && _Cmb_Proveedor.SelectedValue != null) { _Mtd_ActualizarInvendible(_Cmb_Proveedor.SelectedValue.ToString()); }
            _Rb_ConDocumento.Enabled = false;
            _Rb_IngresarDocumento.Enabled = false;
        }

        public bool _Mtd_Guardar()
        {
            string _Str_CodigoProveedor = "", _Str_CodigoTipoProveedor = "", _Str_CodigoCategoriaProveedor = "", _Str_FechaEmisionComprobante = "", _Str_FechaVencimientoComprobante = "", _Str_TipoDocumento = "", _Str_NumeroDocumento = "", _Str_NumeroDocumento_TCOMPROBANIAE = "", _Str_IDDocumento = "", _Str_FechaEmisionDocumento = "", _Str_FechaVencimientoDocumento = "", _Str_NumeroControlDocumento = "", _Str_FechaEmisionDocumentoSQL = "", _Str_FechaVencimientoDocumentoSQL = "", _Str_FechaEmisionDocumentoSQL_TCOMPROBANIAE = "", _Str_BaseImponible = "", _Str_Retenido = "", _Str_MontoExento = "", _Str_AlicuotaIVA = "", _Str_MontoIVA = "", _Str_MontoTotal = "", _Str_ID_IAE_Misterioso = "", _Str_Formula = "", _Str_Sustraendo = "", _Str_TipoDocIAE = "", _Str_ProvRetIAE = "", _Str_COMPROBANTE_RETEN = "", _Str_ProcentajeRetencion = "", _Str_ID_Ret_IAE = "", _Str_Cadena = "", _Str_ID_Factura_CxP_IAE = "", _Str_ID_Factura_CxP_IAE_Prov = "", _Str_FormulaDetalle = "", _Str_DescripIAE = "", _Str_ID_Factura_CxP = "", _Str_ID_Factura_CxP_IAE_D = "", _Str_ID_Ret_IAE_D = "", _Str_CodigoConcepto = "", _Str_Descrip = "", _Str_Cadena1 = "";
            int _Int_ComprobRetIAE = 0;
            string _Str_TipoProcesoContable = "P_CXP_COMP_RETENPAT";

            DataSet _Ds = new DataSet();
            DataSet _Ds1 = new DataSet();

            if (_Mtd_NuevoRegistroEsValido())
            {
                _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
                _Str_CodigoTipoProveedor = _Mtd_CodigoTipoProveedor(_Str_CodigoProveedor);
                if (_Str_CodigoTipoProveedor == "1")
                {
                    _Str_TipoProcesoContable = "P_CXP_COMP_RETPATMP";
                }
                _Str_CodigoCategoriaProveedor = _Mtd_CodigoCategoriaProveedor(_Str_CodigoProveedor);
                _Str_FechaEmisionComprobante = _DTP_FechaEmisionComprobante.Text;
                _Str_FechaVencimientoComprobante = _DTP_FechaEmisionComprobante.Value.AddDays(1).ToShortDateString();
                _Str_NumeroControlDocumento = _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper();
                if (_Rb_ConDocumento.Checked || _Rb_IngresarDocumento.Checked)
                {
                    _Str_TipoDocumento = _Cmb_TipoDocumento.SelectedValue.ToString();
                    _Str_NumeroDocumento = _Txt_NumeroDocumento.Text;
                    //_Str_NumeroDocumento_TCOMPROBANIAE = _Txt_NumeroDocumento.Text;
                    if (_Rb_ConDocumento.Checked)
                    {
                        _Str_IDDocumento = _Txt_NumeroDocumento.Tag.ToString();
                        _Str_FechaEmisionDocumento = _Txt_FechaEmisionDocumento.Text;   
                    }
                    else { _Str_FechaEmisionDocumento = _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value); }
                    _Str_FechaVencimientoDocumento = _Str_Global_FechaVencimientoDocumento;
                }
                //if (_Str_FechaVencimientoDocumento == "null")
                //{
                //    _Str_FechaEmisionDocumentoSQL = "null";
                //    _Str_FechaVencimientoDocumentoSQL = "null";
                //    _Str_FechaEmisionDocumentoSQL_TCOMPROBANIAE = "'" + _Str_FechaEmisionComprobante + "'";
                //}
                //else
                //{
                //    _Str_FechaEmisionDocumentoSQL = "'" + _Str_FechaEmisionDocumento + "'";
                //    _Str_FechaVencimientoDocumentoSQL = "'" + _Str_FechaVencimientoDocumento + "'";
                //    _Str_FechaEmisionDocumentoSQL_TCOMPROBANIAE = "'" + _Str_FechaEmisionDocumento + "'";
                //}
                //if (_Rb_IngresarDocumento.Checked)
                //{
                //    _Str_FechaEmisionDocumentoSQL = "'" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "'";
                //    _Str_FechaEmisionDocumentoSQL_TCOMPROBANIAE = "'" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "'";
                //}
                _Str_BaseImponible = _Txt_BaseImponible.Text;
                _Str_Retenido = _Txt_MontoRetenido.Text;
                _Str_MontoExento = _Txt_MontoExento.Text;
                //_Str_AlicuotaIVA = _Txt_AlicuotaIVA.Text;
                _Str_MontoIVA = _Txt_MontoIVA.Text;
                _Str_MontoTotal = _Txt_MontoTotal.Text;
                _Str_ID_IAE_Misterioso = _Str_Global_ID_IAE_Misterioso;
                //_Str_Formula = _Str_Global_Formula;
                //_Str_Sustraendo = _Str_Global_Sustraendo;
                _Str_ProcentajeRetencion = _Txt_AlicuotaRet.Text;
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocretpat, cprovretpat from TCONFIGCXP "+
                                                                           "WHERE ccompany = '" + Frm_Padre._Str_Comp + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_TipoDocIAE = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocretpat"]);
                    _Str_ProvRetIAE = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretpat"]);
                }
                if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                {
                    if (_Bol_Agregando)
                    {
                        _Str_ID_Ret_IAE = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETPAT " +
                                                                              "WHERE ccompany = '" + Frm_Padre._Str_Comp + "'");
                        if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                        {
                            _Str_ID_Ret_IAE = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETPAT " +
                                                                                         "WHERE ccompany = '" + _Str_CompanyRetenExterna.Trim() + "'");
                        }
                        _Txt_IdComprobante.Text = _Str_ID_Ret_IAE;
                        _Int_ComprobRetIAE = _Mtd_GenerarComprobRetenIAE(_Str_CodigoTipoProveedor, _Str_CodigoCategoriaProveedor, "", "", Convert.ToDouble(_Str_Retenido), _Str_ID_Ret_IAE, _Str_TipoDocumento, _Str_NumeroDocumento, _Str_FechaEmisionDocumento, _Str_FechaVencimientoDocumento);
                        _Str_Cadena = "INSERT INTO TCOMPROBANRETPAT (ccompany, cidcomprobret, cidcomprob, cproveedor, cfechaemiret, cfechavencret, cnumdocumafec, cnumctrldocumafec, ctotcaomp_siva, cretenido, ctotcaomp_iva, cdateadd, cuseradd, cmanual, canulado, cimpreso, cascii, cporcnreten, ctdocumento, cimpuesto, cfechaemidoc, ctotmontexcento) " +
                                      "VALUES ('" + Frm_Padre._Str_Comp.Trim() + "', '" + _Str_ID_Ret_IAE.Trim() + "', '" + _Int_ComprobRetIAE + "', '" + _Str_CodigoProveedor.Trim() + "', '" + _Str_FechaEmisionComprobante.Trim() + "', '" + _Str_FechaVencimientoComprobante.Trim() + "', '" + _Str_NumeroDocumento.Trim() + "', '" + _Str_NumeroControlDocumento.Trim() + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible.Trim())) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoTotal.Trim())) + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', '1', '0', '0', '0', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_ProcentajeRetencion.Trim())) + "', '" + _Str_TipoDocumento.Trim() + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_MontoIVA.Trim())) + "', '" + _Str_FechaEmisionDocumento.Trim() + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoExento.Trim())) + "')";
                        if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                        {
                            _Str_Cadena = "INSERT INTO TCOMPROBANRETPAT (ccompany, cidcomprobret, cidcomprob, cproveedor, cfechaemiret, cfechavencret, cnumdocumafec, cnumctrldocumafec, ctotcaomp_siva, cretenido, ctotcaomp_iva, cimpreso, cagregacomp, cdateadd, cuseradd, cmanual, canulado, cimpreso, cascii, cporcnreten, ctdocumento, cimpuesto, cfechaemidoc, ctotmontexcento) " +
                                          "VALUES ('" + _Str_CompanyRetenExterna.Trim() + "', '" + _Str_ID_Ret_IAE.Trim() + "', '" + _Int_ComprobRetIAE + "', '" + _Str_CodigoProveedor.Trim() + "', '" + _Str_FechaEmisionComprobante.Trim() + "', '" + _Str_FechaVencimientoComprobante.Trim() + "', '" + _Str_NumeroDocumento.Trim() + "', '" + _Str_NumeroControlDocumento.Trim() + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible.Trim())) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoTotal.Trim())) + "', '1', '" + Frm_Padre._Str_Comp.Trim() + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', '1', '0', '0', '0', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_ProcentajeRetencion.Trim())) + "', '" + _Str_TipoDocumento.Trim() + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_MontoIVA.Trim())) + "', '" + _Str_FechaEmisionDocumento.Trim() + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoExento.Trim())) + "')";
                            Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Ds1 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cnumcomprobante FROM TCOMPROBANRETPAT " +
                                                                                    "WHERE ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' and cidcomprobret = '" + _Str_ID_Ret_IAE.Trim() + "'");
                        if (_Ds1.Tables[0].Rows.Count > 0) { _Txt_NumComprobante.Text = Convert.ToString(_Ds1.Tables[0].Rows[0]["cnumcomprobante"]); }
                        _Str_ID_Factura_CxP_IAE = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM " +
                                                                                      "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "'");
                        _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp, ccompany, cidfactxp, cproveedor, ctipodocument, cnumdocu, cidnotrecepc, cglobal, ccatproveedor, cfechaemision, cfechavencimiento, ctotalimp, ctotalsimp, canulado, cactivo, cmontoinvendible, cfechanotrecep, csaldo, cnumdocuctrl, ctotmontexcento, ctotal, ctotalislr, cidcomprob, cdateadd, cuseradd, cidcomprobretpat, cdocumentafect) " +
                                      "VALUES ('" + Frm_Padre._Str_GroupComp.Trim() + "', '" + Frm_Padre._Str_Comp.Trim() + "', '" + _Str_ID_Factura_CxP_IAE.Trim() + "', '" + _Str_ProvRetIAE.Trim() + "', '" + _Str_TipoDocIAE.Trim() + "', '" + _Str_ID_Ret_IAE.Trim() + "', '0', '" + _Str_CodigoTipoProveedor.Trim() + "', '" + _Str_CodigoCategoriaProveedor.Trim() + "', '" + _Str_FechaEmisionComprobante.Trim() + "', '" + _Str_FechaVencimientoComprobante.Trim() + "', '0', '0', '0', '1', '0', null, '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', '0', '0', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', '0', '" + _Int_ComprobRetIAE + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', null, '" + _Str_NumeroDocumento.Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp, ccompany, cproveedor, ctipodocument, cnumdocu, cfechaemision, cfechavencimiento, ctotalimp, ctotalsimp, canulado, cactivo, csaldo, ctotalislr, cidcomprob, ctotal, cdateadd, cuseradd) " +
                                      "VALUES ('" + Frm_Padre._Str_GroupComp.Trim() + "', '" + Frm_Padre._Str_Comp.Trim() + "', '" + _Str_ProvRetIAE.Trim() + "', '" + _Str_TipoDocIAE.Trim() + "', '" + _Str_ID_Ret_IAE.Trim() + "', '" + _Str_FechaEmisionComprobante.Trim() + "', null, '0', '0', '0', '1', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', '0', '" + _Int_ComprobRetIAE + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_ID_Factura_CxP_IAE_Prov = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM " +
                                                                                           "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "'");
                        _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp, ccompany, cidfactxp, cproveedor, ctipodocument, cnumdocu, cidnotrecepc, cglobal, ccatproveedor, cfechaemision, cfechavencimiento, ctotalimp, ctotalsimp, canulado, cactivo, cmontoinvendible, cfechanotrecep, csaldo, cnumdocuctrl, ctotmontexcento, ctotal, ctotalislr, cidcomprob, cdateadd, cuseradd, cidcomprobretpat, cdocumentafect) " +
                                      "VALUES ('" + Frm_Padre._Str_GroupComp.Trim() + "', '" + Frm_Padre._Str_Comp.Trim() + "', '" + _Str_ID_Factura_CxP_IAE_Prov.Trim() + "', '" + _Str_CodigoProveedor.Trim() + "', '" + _Str_TipoDocIAE.Trim() + "', '" + _Str_ID_Ret_IAE.Trim() + "', '0', '" + _Str_CodigoTipoProveedor.Trim() + "', '" + _Str_CodigoCategoriaProveedor.Trim() + "', '" + _Str_FechaEmisionComprobante.Trim() + "', '" + _Str_FechaVencimientoComprobante.Trim() + "', '0', '0', '0', '1', '0', null, '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', '0', '0', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', '0', '" + _Int_ComprobRetIAE + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', null, '" + _Str_NumeroDocumento.Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp, ccompany, cproveedor, ctipodocument, cnumdocu, cfechaemision, cfechavencimiento, ctotalimp, ctotalsimp, canulado, cactivo, csaldo, ctotalislr, cidcomprob, ctotal, cdateadd, cuseradd) " +
                                      "VALUES ('" + Frm_Padre._Str_GroupComp.Trim() + "', '" + Frm_Padre._Str_Comp.Trim() + "', '" + _Str_CodigoProveedor.Trim() + "', '" + _Str_TipoDocIAE.Trim() + "', '" + _Str_ID_Ret_IAE.Trim() + "', '" + _Str_FechaEmisionComprobante.Trim() + "', null, '0', '0', '0', '1', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', '0', '" + _Int_ComprobRetIAE + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_DescripIAE = _Mtd_ObtenerDescripIAE(_Str_ID_IAE_Misterioso);
                        _Str_ID_Factura_CxP = _Str_IDDocumento;
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET cidcomprobretpat = '" + _Str_ID_Ret_IAE.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                      "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidfactxp = '" + _Str_ID_Factura_CxP.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Bol_Agregando = false;
                        MessageBox.Show("Comprobante de retención generado #: " + _Txt_NumComprobante.Text.Trim() + " / Id #: " + _Str_ID_Ret_IAE + "\n\rPara finalizar este proceso debe esperar por su aprobación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    if (_Bol_Editando)
                    {
                        _Str_Cadena = "UPDATE TCOMPROBANRETPAT SET cproveedor = '" + _Str_CodigoProveedor.Trim() + "', cnumdocumafec = '" + _Str_NumeroDocumento.Trim() + "', cnumctrldocumafec = '" + _Str_NumeroControlDocumento.Trim() + "', ctotcaomp_siva = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible.Trim())) + "', cretenido = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', ctotcaomp_iva = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoTotal.Trim())) + "', cporcnreten = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_ProcentajeRetencion.Trim())) + "', ctdocumento = '" + _Str_TipoDocumento.Trim() + "', cimpuesto = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_MontoIVA.Trim())) + "', cfechaemidoc = '" + _Str_FechaEmisionDocumento.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "', ctotmontexcento = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoExento.Trim())) + "', caprobado = '0' " +
                            "WHERE ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidcomprobret = '" + _Txt_IdComprobante.Text.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(),_Bol_Anulando) + "' AND cproveedor = '" + _Str_Proveedor_Edit.Trim()+ "'";
                        if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                        {
                            _Str_Cadena = "UPDATE TCOMPROBANRETPAT SET cproveedor = '" + _Str_CodigoProveedor.Trim() + "', cnumdocumafec = '" + _Str_NumeroDocumento.Trim() + "', cnumctrldocumafec = '" + _Str_NumeroControlDocumento.Trim() + "', ctotcaomp_siva = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible.Trim())) + "', cretenido = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', ctotcaomp_iva = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoTotal.Trim())) + "', cporcnreten = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_ProcentajeRetencion.Trim())) + "', ctdocumento = '" + _Str_TipoDocumento.Trim() + "', cimpuesto = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Str_MontoIVA.Trim())) + "', cfechaemidoc = '" + _Str_FechaEmisionDocumento.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "', ctotmontexcento = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoExento.Trim())) + "', caprobado = '0' " +
                                          "WHERE ccompany = '" + _Str_CompanyRetenExterna.Trim() + "' AND cidcomprobret = '" + _Txt_IdComprobante.Text.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(),_Bol_Anulando) + "' AND cproveedor = '" + _Str_Proveedor_Edit.Trim() + "'";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET cproveedor = '" + _Str_ProvRetIAE.Trim() + "', cglobal = '" + _Str_CodigoTipoProveedor.Trim() + "', ccatproveedor = '" + _Str_CodigoCategoriaProveedor.Trim() + "', csaldo = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', ctotal = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', cdocumentafect = '" + _Str_NumeroDocumento + "' , cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                      "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _Str_ProvRetIAE.Trim() + "' AND ctipodocument = 'RETPAT' AND cidcomprobretpat = '" + _Txt_IdComprobante.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TMOVCXPM SET cproveedor = '" + _Str_ProvRetIAE.Trim() + "', csaldo = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', ctotal = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim())) + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                      "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _Str_ProvRetIAE.Trim() + "' AND ctipodocument = 'RETPAT' AND cnumdocu = '" + _Txt_IdComprobante.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET cproveedor = '" + _Str_CodigoProveedor.Trim() + "', cglobal = '" + _Str_CodigoTipoProveedor.Trim() + "', ccatproveedor = '" + _Str_CodigoCategoriaProveedor.Trim() + "', csaldo = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', ctotal = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "' , cdocumentafect = '" + _Str_NumeroDocumento + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                      "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _Str_Proveedor_Edit.Trim() + "' AND ctipodocument = 'RETPAT' AND cidcomprobretpat = '" + _Txt_IdComprobante.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TMOVCXPM SET cproveedor = '" + _Str_CodigoProveedor.Trim() + "', csaldo = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', ctotal = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido.Trim()) * -1) + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                      "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp.Trim() + "' AND ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _Str_Proveedor_Edit.Trim() + "' AND ctipodocument = 'RETPAT' AND cnumdocu = '" + _Txt_IdComprobante.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TCOMPROBANC SET ctotdebe = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "', ctothaber = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                      "where ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(),_Bol_Anulando) + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "select ccount, ctipodocumento, cnaturaleza, cideprocesod, ccountname from VST_PROCESOSCONTD " +
                                      "where cidproceso = '"+_Str_TipoProcesoContable+"' AND (ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' OR ccompany IS NULL) order by cideprocesod";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
                        foreach (DataRow _Row in _Ds.Tables[0].Rows)
                        {
                            _Str_Descrip = _Row["ccountname"].ToString().Trim().ToUpper() + " COMPROBANTE DE RETENCION IAE # " + _Txt_IdComprobante.Text.Trim() + " " + _Str_TipoDocumento + "# " + _Str_NumeroDocumento + " " + _Mtd_NombAbrevProveedor(_Str_CodigoProveedor) + " VEC:" + _Str_FechaEmisionDocumento;
                            if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "D") 
                            {
                                _Str_Cadena = "UPDATE TCOMPROBAND SET ctotdebe = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "', cdescrip = '" + _Str_Descrip.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                              "where ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(),_Bol_Anulando) + "' AND ccount = '" + _Row["ccount"].ToString().Trim() + "'";
                                _Str_Cadena1 = "UPDATE TCOMPROBANDD SET cdescrip = '" + _Str_Descrip + "', cdebe = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "', cidauxiliarcont = '" + _Str_CodigoProveedor.Trim() + "' " +
                                               "where ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(), _Bol_Anulando) + "' AND ccount='" + _Row["ccount"].ToString().Trim() + "'";
                            }
                            if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "H")
                            {
                                _Str_Cadena = "UPDATE TCOMPROBAND SET ctothaber = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "', cdescrip = '" + _Str_Descrip.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.Trim() + "' " +
                                              "where ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(), _Bol_Anulando) + "' AND ccount = '" + _Row["ccount"].ToString().Trim() + "'";
                                _Str_Cadena1 = "UPDATE TCOMPROBANDD SET cdescrip = '" + _Str_Descrip + "', chaber = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "', cidauxiliarcont = '" + _Str_ProvRetIAE.Trim() + "' " +
                                               "where ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(), _Bol_Anulando) + "' AND ccount='" + _Row["ccount"].ToString().Trim() + "'";
                            }
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena.Trim());
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1.Trim());
                        }
                        _Bol_Editando = false;
                        MessageBox.Show("Comprobante de retención #: " + _Txt_NumComprobante.Text.Trim() + " / Id #: " + _Txt_IdComprobante.Text.Trim() + " ha sido actualizado\n\rPara finalizar este proceso debe esperar por su aprobación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Text = "Comprobante de retención de IAE manual";
                    _Mtd_LlenarGridPrincipal();
                    _Tb_Tab.SelectedIndex = 0;
                    return true;
                }
                else
                {
                    MessageBox.Show("Problemas de conexión para crear las retenciones. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else { return false; }
        }

        private string _Mtd_NumeroControl(string _P_Str_NumCtrlPref, string _P_Str_NumCtrl)
        {
            string _Str_Pref = "", _Str_NumCtrl = "";

            if (_P_Str_NumCtrl.Trim().Length == 0) { return "NA"; }
            else
            {
                _Str_Pref = _P_Str_NumCtrlPref.Trim();
                _Str_NumCtrl = "00000000";
                if (_P_Str_NumCtrlPref.Trim().Length == 0) { _Str_Pref = "00"; }
                else if (_P_Str_NumCtrlPref.Trim().Length == 1 & _Cls_VariosMetodos._Mtd_IsNumeric(_P_Str_NumCtrlPref.Trim())) { _Str_Pref = "0" + _P_Str_NumCtrlPref.Trim(); }
                _Str_NumCtrl = _Str_NumCtrl.Remove(0, _P_Str_NumCtrl.Trim().Length) + _P_Str_NumCtrl.Trim();
                return _Str_Pref + "-" + _P_Str_NumCtrl;
            }
        }

        private bool _Mtd_NuevoRegistroEsValido()
        {
            string _Str_CodigoProveedor = "", _Str_CodigoTipoProveedor = "", _Str_CodigoCategoriaProveedor = "";
            decimal _Dec_MontominimoUT = 0;

            _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
            _Str_CodigoTipoProveedor = _Mtd_CodigoTipoProveedor(_Str_CodigoProveedor);
            _Str_CodigoCategoriaProveedor = _Mtd_CodigoCategoriaProveedor(_Str_CodigoProveedor);
            _Dec_MontominimoUT = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPermitidoMontoUT();
            if ((Convert.ToDecimal(_Txt_BaseImponible.Text.Trim()) + Convert.ToDecimal(_Txt_MontoExento.Text.Trim())) < _Dec_MontominimoUT)
            {
                if (_Txt_NumeroPatente.Text.Trim() != "0")
                {
                    MessageBox.Show("No aplica retención a este proveedor, el monto de la factura sin iva no debe ser menor a " + Convert.ToString(_Dec_MontominimoUT.ToString("#,##0.00")) + " Bs.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;                    
                }
            }
            if (_Cmb_Proveedor.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor antes de seguir. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_DTP_FechaEmisionComprobante.Text.Trim() == "")
            {
                MessageBox.Show("La fecha de emisión del comprobante no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_Rb_ConDocumento.Checked)
            {
                if (_Txt_NumeroDocumento.Text.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un documento antes de seguir. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) & !_Chk_FactMaqFis.Checked)
                {
                    MessageBox.Show("El número de control del documento no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (_Txt_FechaEmisionDocumento.Text.Trim() == "")
                {
                    MessageBox.Show("La fecha de emisión del documento no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (!_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim()))
            {
                MessageBox.Show("La base imponible no es válida. Verifique.","Información",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDouble(_Txt_BaseImponible.Text) + Convert.ToDouble(_Txt_MontoExento.Text) <= 0)
            {
                MessageBox.Show("La suma de la base imponible mas el monto exento debe ser un monto mayor que cero. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!_Mtd_IsNumeric(_Txt_MontoExento.Text.Trim()))
            {
                MessageBox.Show("El monto exento no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!_Mtd_IsNumeric(_Txt_MontoRetenido.Text.Trim()))
            {
                MessageBox.Show("El monto retenido no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!_Mtd_IsNumeric(_Txt_AlicuotaIVA.Text.Trim()))
            {
                MessageBox.Show("El alícuota IVA no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!_Mtd_IsNumeric(_Txt_MontoIVA.Text.Trim()))
            {
                MessageBox.Show("El monto IVA no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!_Mtd_IsNumeric(_Txt_MontoRetenido.Text.Trim()))
            {
                MessageBox.Show("El monto retenido no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDouble(_Txt_MontoRetenido.Text) <= 0)
            {
                MessageBox.Show("El monto retenido debe ser mayor que cero. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_Rb_IngresarDocumento.Checked)
            {
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) & !_Chk_FactMaqFis.Checked)
                {
                    MessageBox.Show("El número de control del documento no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0) { return true; }
            }
            return false;
        }

        private void _Txt_BaseImponible_TextChanged(object sender, EventArgs e)
        {
            if ((_Bol_Agregando || _Bol_Editando) && (_Rb_IngresarDocumento.Checked))
            {
                _Mtd_ActualizarMontoIVA();
                _Mtd_ActualizarMontoTotal();
                _Mtd_ActualizarMontoRetenido();
            }
        }

        private void _Txt_BaseImponible_Click(object sender, EventArgs e) { _Txt_BaseImponible.SelectAll(); }

        private int _Mtd_GenerarComprobRetenIAE(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_CatCompRel, string _P_Str_CatAccion, double _P_Dbl_IAE, string _P_Str_ID_Ret_IAE, string _Str_TipoDocumento, string _Str_NumeroDocumento, string _Str_FechaEmisionDocumento, string _Str_FechaVencimientoDocumento)
        {
            string _Str_CodigoProveedor = "", _Str_FechaEmisionDocumentoSQL = "", _Str_FechaVencimientoDocumentoSQL = "", _Str_PROCESOCONTABLE = "", _Str_Cconceptocomp = "", _Str_Ctypcompro = "", _Str_Cadena = "", _Str_Cuenta = "", _Str_Descrip = "", _Str_DescripD = "", _Str_NombProveedor = "", _Str_TipoDocRecIAE = "";
            string[] _Str_Cuenta_Descrip;
            int _Int_Comprobante = 0, _Int_corder = 0;

            DataSet _Ds = new DataSet();

            _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
            if (_Str_FechaVencimientoDocumento == "null")
            {
                _Str_FechaEmisionDocumentoSQL = "null";
                _Str_FechaVencimientoDocumentoSQL = "null";
            }
            else
            {
                _Str_FechaEmisionDocumentoSQL = "'" + _Str_FechaEmisionDocumento + "'";
                _Str_FechaVencimientoDocumentoSQL = "'" + _Str_FechaVencimientoDocumento + "'";
            }
            if (_P_Str_TipoProv == "1")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETPATMP";
            }
            else
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENPAT";
            }
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_PROCESOCONTABLE);
            _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany, cidcomprob, ctypcomp, cname, cyearacco, cmontacco, cregdate, ctotdebe, ctothaber, cbalance, cdateadd, cuseradd, clvalidado, cstatus) " + 
                          "VALUES ('" + Frm_Padre._Str_Comp.Trim() + "', '" + _Int_Comprobante + "', '" + _Str_Ctypcompro.Trim() + "', '" + _Str_Cconceptocomp.Trim() + "', '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "', '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "', '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_IAE) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_IAE) + "', '0', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', '0', '0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena.Trim());
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            _Str_NombProveedor = _Mtd_NombAbrevProveedor(_Str_CodigoProveedor);
            _Str_TipoDocRecIAE = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocretpat");
            _Str_Cadena = "select ccount, ctipodocumento, cnaturaleza, cideprocesod, ccountname from VST_PROCESOSCONTD " + 
                          "where cidproceso = '" + _Str_PROCESOCONTABLE.Trim() + "' AND (ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_Cuenta_Descrip = _Mtd_ExtraerCuenta(_Row["ccount"].ToString(), _P_Str_TipoProv, _Row["ccountname"].ToString(),_Str_CodigoProveedor);
                _Str_Cuenta = _Str_Cuenta_Descrip[0];
                _Str_DescripD = _Str_Cuenta_Descrip[1];
                _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION IAE # " + _P_Str_ID_Ret_IAE + " " + _Str_TipoDocumento + "# " + _Str_NumeroDocumento + " " + _Str_NombProveedor + " VEC:" + _Str_FechaEmisionDocumento;
                if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "D") { _Str_Cadena = "insert into TCOMPROBAND (ccompany, cidcomprob, corder, ccount, ctdocument, cnumdocu, cdatedocu, ctotdebe, cdateadd, cuseradd, cdescrip) " + 
                                                                                            "values ('" + Frm_Padre._Str_Comp.Trim() + "', '" + _Int_Comprobante + "', '" + _Int_corder + "', '" + _Str_Cuenta.Trim() + "', '" + _Str_TipoDocRecIAE.Trim() + "', '" + _P_Str_ID_Ret_IAE.Trim() + "', " + _Str_FechaEmisionDocumentoSQL.Trim() + ", '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_IAE) + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', '" + _Str_Descrip.Trim() + "')"; }
                else if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "H") { _Str_Cadena = "insert into TCOMPROBAND (ccompany, cidcomprob, corder, ccount, ctdocument, cnumdocu, cdatedocu, ctothaber, cdateadd, cuseradd, cdescrip) " + 
                                                                                                 "values ('" + Frm_Padre._Str_Comp.Trim() + "', '" + _Int_Comprobante + "', '" + _Int_corder + "', '" + _Str_Cuenta.Trim() + "', '" + _Str_TipoDocRecIAE.Trim() + "', '" + _P_Str_ID_Ret_IAE.Trim() + "', " + _Str_FechaEmisionDocumentoSQL.Trim() + ", '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_IAE) + "', GETDATE(), '" + Frm_Padre._Str_Use.Trim() + "', '" + _Str_Descrip.Trim() + "')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena.Trim());
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_CodigoProveedor, _Str_Descrip, _Str_TipoDocRecIAE, _P_Str_ID_Ret_IAE, _Str_FechaEmisionDocumento, _Str_FechaVencimientoDocumento, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_IAE), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["cnaturaleza"].ToString().Trim().ToUpper());
            }
            return _Int_Comprobante;
        }

        private void _Mtd_ActualizarMontoTotal()
        {
            double _Dbl_BaseImponible = 0, _Dbl_MontoIVA = 0, _Dbl_MontoExento = 0, _Dbl_MontoTotal = 0; 
            
            if (_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim())) { _Dbl_BaseImponible = Convert.ToDouble(_Txt_BaseImponible.Text); }
            if (_Mtd_IsNumeric(_Txt_MontoIVA.Text.Trim())) { _Dbl_MontoIVA = Convert.ToDouble(_Txt_MontoIVA.Text); }
            if (_Mtd_IsNumeric(_Txt_MontoExento.Text.Trim())) { _Dbl_MontoExento = Convert.ToDouble(_Txt_MontoExento.Text); }
            _Dbl_MontoTotal = (_Dbl_BaseImponible + _Dbl_MontoIVA + _Dbl_MontoExento);
            _Txt_MontoTotal.Text = _Dbl_MontoTotal.ToString("#,##0.00");       
        }

        private void _Btn_AlicuotaIVA_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(56, _Txt_AlicuotaIVA, 1, "");
            _Frm.ShowDialog();
            _Mtd_ActualizarMontoIVA();
            _Mtd_ActualizarMontoTotal();
        }

        private void _Mtd_ActualizarMontoIVA()
        {
            double _Dbl_BaseImponible = 0, _Dbl_AlicuotaIVA = 0, _Dbl_MontoIVA = 0; 

            if (_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim())) { _Dbl_BaseImponible = Convert.ToDouble(_Txt_BaseImponible.Text); }
            if (_Mtd_IsNumeric(_Txt_AlicuotaIVA.Text.Trim())) { _Dbl_AlicuotaIVA = Convert.ToDouble(_Txt_AlicuotaIVA.Text); }
            _Dbl_MontoIVA = _Dbl_BaseImponible * (_Dbl_AlicuotaIVA / 100);
            _Txt_MontoIVA.Text = _Dbl_MontoIVA.ToString("#,##0.00");
        }

        private double _Mtd_ActualizarInvendible(string _Str_CodigoProveedor)
        {
            string _Str_Cadena = "";
            
            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT ISNULL(cporcinvendible,0) FROM TPROVEEDOR " + 
                          "WHERE cproveedor = '" + _Str_CodigoProveedor.Trim() + "' AND cglobal = '1'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());            
            if (_Ds.Tables[0].Rows.Count > 0) { return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim()); }
            else { return 0; }            
        }

        private string _Mtd_CodigoTipoProveedor(string _Str_CodigoProveedor)
        {
            string _Str_Cadena = "";
            
            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT cglobal from TPROVEEDOR " + 
                          "where CPROVEEDOR = '" + _Str_CodigoProveedor.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0) { return Convert.ToString(_Ds.Tables[0].Rows[0]["cglobal"]); }
            else { return ""; }   
        }

        private string _Mtd_CodigoCategoriaProveedor(string _Str_CodigoProveedor)
        {
            string _Str_Cadena = "";
            
            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT ISNULL(ccatproveedor,0) as ccatproveedor from TPROVEEDOR " + 
                          "where CPROVEEDOR = '" + _Str_CodigoProveedor.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0) { return Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveedor"]); }
            else { return "0"; }
        }
        
        private string _Mtd_ObtenerDescripIAE(string _P_Str_ID_IAE)
        {
            DataSet _Ds = new DataSet();

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdescrip FROM TISLR " +
                                                                       "WHERE cislr_id = '" + _P_Str_ID_IAE.Trim() + "'");
            if (_Ds.Tables[0].Rows.Count > 0) { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else { return ""; }
        }

        private string _Mtd_NombAbrevProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "";

            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT c_nomb_abreviado FROM TPROVEEDOR " + 
                          "WHERE cproveedor = '" + _P_Str_Proveedor.Trim() + "' AND (ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' OR cglobal = '1')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0) { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            return "";
        }

        private string[] _Mtd_ExtraerCuenta(string _P_Str_Cuenta, string _P_Str_Global, string _P_Str_Descripcion, string _Str_CodigoProveedor)
        {
            string _Str_Cadena = "";

            DataSet _Ds = new DataSet();

            _Str_Cadena = "Select ctcount from TCOUNT " + 
                          "where ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' and ccount = '" + _P_Str_Cuenta.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "0")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR " + 
                              "INNER JOIN TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany " + 
                              "WHERE TPROVEEDOR.ccompany = '" + Frm_Padre._Str_Comp.Trim() + "' AND cproveedor = '" + _Str_CodigoProveedor.Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString()}; }
                }
            }
            else if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "1")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR " + 
                              "INNER JOIN TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount " + 
                              "WHERE TPROVEEDOR.cglobal = '1' AND cproveedor = '" + _Str_CodigoProveedor.Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
                if (_Ds.Tables[0].Rows.Count > 0){
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString()}; }
                }
            }
            return new string[] { _P_Str_Cuenta, _P_Str_Descripcion };
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            try
            {
                Convert.ToDouble(Expression);
                return true;
            }
            catch { return false; }
        }

        private string _Mtd_PorcentajeIVAActual()
        {
            string _Str_Cadena = "";

            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT cpercent FROM TTAX";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0) { return Convert.ToString(_Ds.Tables[0].Rows[0]["cpercent"]); }
            else { return "0"; }
        }

        private void _Rb_IngresarDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_IngresarDocumento.Checked)
            {
                _Mtd_DesactivarTodo();
                if (_Bol_Agregando || _Bol_Editando)
                {
                    _Mtd_LimpiarDetalleDocumento();
                    _Mtd_ActivarNuevoSinDocumento();
                    _Mtd_InicializarControles();
                    _Txt_AlicuotaIVA.Text = _Mtd_PorcentajeIVAActual();
                    _Txt_NumeroDocumento.Enabled = true;
                    _Btn_Documento.Enabled = false;
                    _Txt_NumCtrl.Enabled = true;
                    _Txt_NumCtrlPref.Enabled = true;
                    _Chk_FactMaqFis.Enabled = true;
                    _Txt_FechaEmisionDocumento.Visible = false;
                    _Dtp_Emision.Visible = true;
                    _Dtp_Emision.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                    _Cmb_TipoDocumento.Enabled = true;
                }
            }
        }

        private void _Chk_FactMaqFis_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_FactMaqFis.Checked)
            {
                _Txt_NumCtrlPref.Enabled = false;
                _Txt_NumCtrl.Enabled = false;
                _Txt_NumCtrlPref.Text = "";
                _Txt_NumCtrl.Text = "";
            }
            else
            {
                _Txt_NumCtrlPref.Enabled = true;
                _Txt_NumCtrl.Enabled = true;
                _Txt_NumCtrl.Text = "";
            }
        }

        private void _Txt_NumCtrlPref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "-" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%") { e.Handled = true; }
        }

        private void _Txt_NumCtrl_KeyPress(object sender, KeyPressEventArgs e) { _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NumCtrl, e, 8, 0); }

        private void _Txt_NumCtrl_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NumCtrl.Text)) { _Txt_NumCtrl.Text = ""; }
        }

        private void Frm_ComprobIAEManual_Load(object sender, EventArgs e)
        {
            _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_DesactivarTodo();
            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            _Mtd_CargarTipoDodumento();
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_BaseImponible);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_MontoIVA);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_MontoExento);
        }

        private void Frm_ComprobIAEManual_Activate(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            if (!_Bol_Aprobando && !_Bol_Imprimiendo && !_Bol_Rachazadas)
            {
                _Mtd_Habilita_Botones_Menu(false,"Nuevo");
            }



            //if (!_Bol_Aprobando && !_Bol_Imprimiendo && !_Bol_Rachazadas)
            //{
            //    CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            //    CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            //    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            //    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            //    CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //    if (_Bol_Agregando)
            //    {
            //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            //    }
            //    else
            //    {
            //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            //    }
            //}
            this.Text = "Comprobante de retención de IAE manual";
        }

        private void _Btn_Aprobar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirme que desea realizar la aprobación del comprobante de retención.", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
            else { _Pnl_Clave.Visible = false; }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = "", _Str_IDComprobRet = "";

            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.ToString().Trim()))
            {
                string _Str_Mensaje = "";

                _Txt_Clave.Text = "";
                _Pnl_Clave.Visible = false;
                if (!_Bol_Rechazando && !_Bol_Anulando)
                {
                    _Str_Cadena = "update TCOMPROBANRETPAT set caprobado = '1', cuserupd = '" + Frm_Padre._Str_Use.Trim() + "', cdateupd = getdate(), cuseraprob = '" + Frm_Padre._Str_Use.Trim() + "', cdateprob = getdate() " +
                                  "WHERE cidcomprobret = '" + _Txt_IdComprobante.Text.Trim() + "'";
                    _Str_Mensaje = "El comprobante de retención ha sido aprobado";
                }
                else if (_Bol_Rechazando && !_Bol_Anulando)
                {
                    _Str_Cadena = "update TCOMPROBANRETPAT set caprobado = '2', cuserupd = '" + Frm_Padre._Str_Use.Trim() + "', cdateupd = getdate() " +
                                  "WHERE cidcomprobret = '" + _Txt_IdComprobante.Text.Trim() + "'";
                    _Str_Mensaje = "El comprobante de retención ha sido rechazado";
                }
                else if (!_Bol_Rechazando && _Bol_Anulando)
                {
                    _Str_IDComprobRet = _Txt_IdComprobante.Text.Trim()=="" ? Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim() : _Txt_IdComprobante.Text.Trim();
                    if (_Mtd_VerificarComprobRETENProcesado(Frm_Padre._Str_Comp.Trim(), _Str_IDComprobRet.Trim()))
                    {
                        if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                        {
                            if (_Mtd_CuentasInactivas(_Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Str_IDComprobRet.Trim(), !_Bol_Anulando)))
                                return;
                            _Mtd_Anular(Frm_Padre._Str_GroupComp.Trim(), Frm_Padre._Str_Comp.Trim(), _Str_CompanyRetenExterna.Trim(), _Str_IDComprobRet.Trim(), Frm_Padre._Str_Use.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Problemas de conexiòn para anular la retenciòn. Por favor espere unos minutos e intente nuevamente","Informaciòn",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    else
                    {MessageBox.Show("No se puede anular la retenciòn debido a que ya ha sido cancelada", "Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                }
                if (!_Bol_Anulando)
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena.Trim());
                    MessageBox.Show(_Str_Mensaje.Trim(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_LlenarGridPrincipal();
                    _Tb_Tab.SelectedIndex = 0;                    
                }

            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            _Pnl_Clave.Visible = false;
        }

        private void _Rb_PorAprobar_Click(object sender, EventArgs e)
        {
            _Cntx_Contex.Enabled = true;
            _Mtd_LlenarGridPrincipal();
        }

        private void _Rb_Aprobados_Click(object sender, EventArgs e)
        {
            _Cntx_Contex.Enabled = true;
            _Mtd_LlenarGridPrincipal();
        }

        private void _Rb_Anulados_Click(object sender, EventArgs e)
        {
            _Cntx_Contex.Enabled = false;
            _Mtd_LlenarGridPrincipal();
        }

        private void _Btn_VerComprobante_Click(object sender, EventArgs e)
        {
            Frm_VerComprobante _Frm_VerComprobante = new Frm_VerComprobante(_Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Txt_IdComprobante.Text.Trim(), _Bol_Anulando));
            if (!_Mtd_AbiertoOno(_Frm_VerComprobante, (Frm_Padre)this.MdiParent))
            {
                _Frm_VerComprobante.MdiParent = this.MdiParent;
                _Frm_VerComprobante.Show();
            }
            else{ _Frm_VerComprobante.Dispose(); }
        }

        private bool _Mtd_AbiertoOno(Form _Frm_Formulario, Frm_Padre _Pr_Frm_Padre)
        {
            foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Frm_Formulario.Name)
                {
                    _Frm_Hijo.Activate();
                    return true;
                }
            }
            return false;
        }

        private string _Mtd_ObtenerNumeroComprobanteContable(string _Str_Compañia, string _Str_IDCompRet, bool P_Bol_Anulacion)
        {
            DataSet _Ds = new DataSet();

            if (!P_Bol_Anulacion)
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprob FROM TCOMPROBANRETPAT " +
                                                                           "WHERE ccompany = '" + _Str_Compañia.Trim() + "' AND  cidcomprobret = '" + _Str_IDCompRet.Trim() + "'");
            }
            else
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprobanul FROM TCOMPROBANRETPAT " +
                                                           "WHERE ccompany = '" + _Str_Compañia.Trim() + "' AND  cidcomprobret = '" + _Str_IDCompRet.Trim() + "'");
            }

            if (_Ds.Tables[0].Rows.Count > 0){ return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else { return ""; }
        }


        private void _Btn_Imprimir_Click(object sender, EventArgs e)
        {
            _Str_Global_IdRetencion = _Txt_IdComprobante.Text.Trim();
            _Bol_Anulando = false;
            _Mtd_Imprimir_Comprobante_Retencion_IAE(Frm_Padre._Str_Comp.Trim(), _Str_Global_IdRetencion.Trim());
        }

        private void _Mtd_Imprimir_Comprobante_Retencion_IAE(string _P_Str_Compañia, string _P_Str_ComprobRet)
        {
            _Rpt_ComprobRetIAE.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ComprobRetIAE.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ComprobRetIAE";
            ReportParameter[] parm = new ReportParameter[2];
            parm[0] = new ReportParameter("Compania", _P_Str_Compañia.Trim());
            parm[1] = new ReportParameter("IdComprobanteRet", _P_Str_ComprobRet.Trim());
            Cursor = Cursors.WaitCursor;
            _Rpt_ComprobRetIAE.ServerReport.SetParameters(parm);
            this._Rpt_ComprobRetIAE.ServerReport.Refresh();
            this._Rpt_ComprobRetIAE.RefreshReport();
            Cursor = Cursors.Default;
        }

        private void _Rpt_ComprobRetIAE_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            _RecepImprimir:
            if (MessageBox.Show("Está preparada la impresora para imprimir el comprobante de retención?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Rpt_ComprobRetIAE.PrintDialog();
                switch (MessageBox.Show("¿Se imprimió correctamente el comprobante de retención?", "Aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        _Mtd_Imprimir_Comprobante_Contable(Frm_Padre._Str_Comp.Trim(), _Str_Global_IdRetencion.Trim(), _Bol_Anulando);
                        break;
                    case DialogResult.No:
                        goto _RecepImprimir;
                        break;
                    case DialogResult.Cancel:
                        MessageBox.Show("El comprobante de retención no ha sido impreso", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else {MessageBox.Show("El comprobante de retención no ha sido impreso", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);}
        }

        private void _Mtd_Imprimir_Comprobante_Contable(string _P_Str_Compañia, string _P_Str_IdRetencion, bool P_Bol_Anulacion)
        {
            REPORTESS _Frm;
            PrintDialog _Print = new PrintDialog();
            _ComprobImprimir:
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                //if (!P_Bol_Anulacion)
                //{
                    MessageBox.Show("Se va a proceder a imprimir el comprobante contable", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany = '" + _P_Str_Compañia.Trim() + "' and (cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(_P_Str_Compañia.Trim(), _P_Str_IdRetencion.Trim(), false) + "' or cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(_P_Str_Compañia.Trim(), _P_Str_IdRetencion.Trim(), true) + "')", _Print, true);
                //}
                //else
                //{
                //    MessageBox.Show("Se va a proceder a imprimir el comprobante contable de anulaciòn.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany = '" + _P_Str_Compañia.Trim() + "' and cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(_P_Str_Compañia.Trim(), _P_Str_IdRetencion.Trim(), P_Bol_Anulacion) + "'", _Print, true);
                //}
                Cursor = Cursors.Default;
                if (MessageBox.Show("¿El comprobante contable se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    _Frm.Close();
                    _Frm.Dispose();
                    goto _ComprobImprimir;
                }
                else
                {
                    _Frm.Close();
                    _Frm.Dispose();
                    if (!_Bol_DocumentosImpresos)
                    {
                        _Mtd_FinalizaProceso(_P_Str_Compañia.Trim(), _P_Str_IdRetencion.Trim(), P_Bol_Anulacion, Frm_Padre._Str_Use.Trim());
                        MessageBox.Show("Los documentos han sido impresos y los comprobantes fueron actualizados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Los documentos han sido impresos satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    _Mtd_LlenarGridPrincipal();
                    _Tb_Tab.SelectedIndex = 0;
                }                
            }
        }

        private void _Mtd_FinalizaProceso(string _P_Str_Compañia, string _P_Str_IdRetencion, bool _P_Bol_Anulacion, string _P_Str_Usuario)
        {
            string _Str_Cadena = "";

            _Str_Cadena = "Update TCOMPROBANC set cstatus = '1', clvalidado = '1', cvalidate = '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' " +
                          "where ccompany = '" + _P_Str_Compañia.Trim() + "' and cidcomprob = '" + _Mtd_ObtenerNumeroComprobanteContable(_P_Str_Compañia.Trim(), _P_Str_IdRetencion.Trim(), _P_Bol_Anulacion) + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena.Trim());
            _Str_Cadena = "Update TCOMPROBANRETPAT Set cimpreso = 1, cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' " +
                          "where ccompany = '" + _P_Str_Compañia.Trim() + "' and cidcomprobret = '" + _P_Str_IdRetencion.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena.Trim());
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
        }

        private bool _Mtd_VerificaDocumentosImpresos(string _Str_Compañia, string _Str_IdComprobanteRetencion)
        {
            string _Str_Cadena = "";

            DataSet _Ds = new DataSet();

            _Str_Cadena = "SELECT cimpreso FROM TCOMPROBANRETPAT " + 
                          "WHERE ccompany = '" + _Str_Compañia.Trim() + "' AND cidcomprobret = '" + _Str_IdComprobanteRetencion.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim());
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["CIMPRESO"].ToString().Trim() == "1") { return true; }
                else { return false; }
            }
            return false;
        }

        private void _Btn_Rechazar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirme que desea rechazar el comprobante de retención", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Bol_Rechazando = true;
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
            else { _Pnl_Clave.Visible = false; }
        }

        private void _Mtd_Habilita_Botones_Menu(bool _Bol_Habilitar, string _Str_Tipo)
        {
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Bol_Habilitar;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Bol_Habilitar;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Bol_Habilitar;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = _Bol_Habilitar;
            switch (_Str_Tipo.Trim())
            {
                case "Nuevo":
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = !_Bol_Habilitar;
                    break;
                case "Editar":
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Bol_Habilitar;
                    break;
                case "Guardar":
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = !_Bol_Habilitar;
                    break;
                case "":
                    break;
            }
        }

        private void _Mtd_Habilita_Detalle()
        {
            _Rb_ConDocumento.Enabled = true;
            _Rb_IngresarDocumento.Enabled = true;
            _Cmb_TipoProv.Enabled = true;
            _Cmb_CategProv.Enabled = true;
            _Cmb_Proveedor.Enabled = true;
            if (_Rb_ConDocumento.Checked)
            {
                _Btn_Documento.Enabled = true;
            }
            else
            {
                _Cmb_TipoDocumento.Enabled = true;
                _Dtp_Emision.Visible = true;
                _Dtp_Emision.Value = Convert.ToDateTime(_Txt_FechaEmisionDocumento.Text.Trim());
                _Txt_FechaEmisionDocumento.Visible = false;
                _Txt_NumeroDocumento.Enabled = true;
                _Txt_NumCtrlPref.Enabled = true;
                _Txt_NumCtrl.Enabled = true;
                _Chk_FactMaqFis.Enabled = true;
                _Txt_BaseImponible.Enabled = true;
                _Txt_MontoExento.Enabled = true;
                _Btn_AlicuotaIVA.Enabled = true;
            }

        }

        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }

        private void _Btn_Anular_Click(object sender, EventArgs e)
        {
            string _Str_IdRetencion = "";

            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_COMPB_RET_PAT"))
            {
                if (MessageBox.Show("Confirme que desea realizar la anulaciòn del comprobante de retención", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Str_IdRetencion = sender.ToString() == "Anular" ? Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim() : _Txt_IdComprobante.Text.Trim();
                    if (_Mtd_VerificarMesComprobanteRETEN(Frm_Padre._Str_Comp.Trim(), _Mtd_ObtenerNumeroComprobanteContable(Frm_Padre._Str_Comp.Trim(), _Str_IdRetencion.Trim(), _Bol_Anulando)))
                    {
                        _Bol_Anulando = true;
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Focus();
                    }
                    else { MessageBox.Show("No es posible anular la retenciòn ya que el mes contable de este documento no es igual al mes actual.", "Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            else{MessageBox.Show("Usted no esta autorizado para realizar esta operaciòn", "Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information);}
        }

        private bool _Mtd_VerificarMesComprobanteRETEN(string _P_Str_Compañia, string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "";

            _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TCOMPROBANRETPAT INNER JOIN TCOMPROBANC ON TCOMPROBANRETPAT.ccompany = TCOMPROBANC.ccompany AND TCOMPROBANRETPAT.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TCOMPROBANRETPAT.ccompany = '" + _P_Str_Compañia.Trim() + "') AND (TCOMPROBANRETPAT.cidcomprob = '" + _P_Str_ComprobRetencion + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena.Trim()).Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_VerificarComprobRETENProcesado(String _P_Str_Compañia, string _P_Str_ComprobRetencion)
        {
            bool _Bol_Valido = true;
            //Se verifica que no tenga orden de pago hecha
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipodocretpat FROM TCONFIGCXP WHERE ccompany = '" + _P_Str_Compañia.Trim() + "'");
            string _Str_TipoDocumento = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocretpat"]);
            string _Str_Cadena = "SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cordenpaghecha = '1' AND CNUMDOCU = '" + _P_Str_ComprobRetencion.Trim() + "' AND CCOMPANY = '" + _P_Str_Compañia.Trim() + "' AND ctipodocument = '" + _Str_TipoDocumento.Trim() + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                _Bol_Valido = false;
            }
            if (_Bol_Valido)
            {
                _Str_Cadena = "SELECT cordenpaghecha FROM TFACTPPAGARM WHERE csaldo <> 0 AND CNUMDOCU = '" + _P_Str_ComprobRetencion.Trim() + "' AND CCOMPANY = '" + _P_Str_Compañia.Trim() + "' AND ctipodocument = '" + _Str_TipoDocumento.Trim() + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count < 2)
                {
                    _Bol_Valido = false;
                }
            }
            return _Bol_Valido;
        }

        private bool _Mtd_CuentasInactivas(string _P_Str_ComproContable)
        {
            if (_Cls_VariosMetodos._Mtd_CuentasInactivas(_P_Str_ComproContable))
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("El comprobante inicial tiene cuentas inactivas.\nDebe reemplazar las cuentas inactivas desde el notificador 'CUENTAS CONTABLES INACTIVAS POR REEMPLAZAR' para realizar la anulación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            return false;
        }

        private void _Mtd_Anular(string _P_Str_GrupoCompañia, string _P_Str_Compañia, string _P_Str_Compañia_Externa, string _P_Str_ComprobRetencion, string _P_Str_Usuario)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETPAT WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_ID_Fact_CxP = _Mtd_Obtener_ID_Fact_CxP(_P_Str_GrupoCompañia.Trim(), _P_Str_Compañia.Trim(), _P_Str_ComprobRetencion);
                if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                {
                    string _Str_Id_ComprobAnul = _Cls_VariosMetodos._Mtd_CrearComprobanteAnulacion(_Str_Id_Comprob);
                    _Str_Cadena = "UPDATE TCOMPROBANRETPAT SET cidcomprobanul = '" + _Str_Id_ComprobAnul.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "UPDATE TCOMPROBANRETPAT SET cidcomprobanul = '" + _Str_Id_ComprobAnul.Trim() + "', cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' WHERE ccompany = '" + _P_Str_Compañia_Externa.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "'";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //--------
                    _Mtd_InsertarAuxiliar(_Str_Id_ComprobAnul, _Mtd_Proveedor(_P_Str_Compañia.Trim(), _P_Str_ComprobRetencion), _Str_ID_Fact_CxP);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus = '1', clvalidado = '1', cvalidate = '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprob = '" + _Str_Id_Comprob.Trim() + "' AND CSTATUS = '0'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus = '1', clvalidado = '1', cvalidate = '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprob = '" + _Str_Id_ComprobAnul.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                _Str_Cadena = "UPDATE TCOMPROBANRETPAT SET canulado = 1, cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //--------RETENCIÓN EXTERNA
                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                {
                    _Str_Cadena = "UPDATE TCOMPROBANRETPAT SET canulado = 1, cimpreso = '0', cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' WHERE ccompany = '" + _P_Str_Compañia_Externa.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "'";
                    Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                //--------
                //_Str_Cadena = "DELETE FROM TFACTPPAGARISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp='" + _Str_ID_Fact_CxP + "'";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipodocretpat FROM TCONFIGCXP WHERE ccompany = '" + _P_Str_Compañia.Trim() + "'");
                string _Str_TipoDocIAE = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocretpat"]);
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo = 0, canulado = 1, cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' WHERE cgroupcomp = '" + _P_Str_GrupoCompañia.Trim() + "' AND ccompany = '" + _P_Str_Compañia.Trim() + "' AND cnumdocu = '" + _P_Str_ComprobRetencion.Trim() + "' AND ctipodocument = '" + _Str_TipoDocIAE.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET cactivo = 0, canulado = 1, cdateupd = GETDATE(), cuserupd = '" + _P_Str_Usuario.Trim() + "' WHERE cgroupcomp = '" + _P_Str_GrupoCompañia.Trim() + "' AND ccompany = '" + _P_Str_Compañia + "' AND cnumdocu = '" + _P_Str_ComprobRetencion + "' AND ctipodocument = '" + _Str_TipoDocIAE.Trim().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente. Se van a realizar la impresion de los comprobantes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Str_Global_IdRetencion = _P_Str_ComprobRetencion.Trim();
                _Bol_Anulando = true;
                //*****Verificar si el comprobante de ret y contable ha sido impreso y actualizado
                if (_Mtd_ComprobRet_Impreso(_P_Str_Compañia.Trim(), _P_Str_ComprobRetencion.Trim()))
                {
                    _Mtd_Imprimir_Comprobante_Contable(_P_Str_Compañia.Trim(), _P_Str_ComprobRetencion.Trim(), true);
                }
                else
                {
                    _Mtd_Imprimir_Comprobante_Retencion_IAE(_P_Str_Compañia.Trim(), _P_Str_ComprobRetencion.Trim());
                    //_Mtd_Imprimir_Comprobante_Contable(_P_Str_Compañia.Trim(), _P_Str_ComprobRetencion.Trim(), true);
                }
                
            }
        }

        private string _Mtd_Obtener_ID_Fact_CxP(string _P_Str_GrupoCompañia, string _P_Str_Compañia, string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp = '" + _P_Str_GrupoCompañia.Trim() + "' AND ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobretpat = '" + _P_Str_ComprobRetencion.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }

        public void _Mtd_InsertarAuxiliar(string _P_Str_Comprobante, string _P_Str_Proveedor, string _P_Str_ID_FacturaCxP)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            DateTime _Dtm_FechaEmi = _Mtd_FechaEmision(_P_Str_ID_FacturaCxP);
            DateTime _Dtm_FechaVenc = _Mtd_FechaVencimiento(_P_Str_ID_FacturaCxP);
            double _Dbl_Monto = 0;
            string _Str_Cadena = "SELECT cidcomprob,ccount,cdescrip,ctdocument,cnumdocu,CASE WHEN ctotdebe>0 THEN ctotdebe ELSE ctothaber END AS Monto,CASE WHEN ctotdebe>0 THEN 'D' ELSE 'H' END AS Naturaleza FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dbl_Monto = Convert.ToDouble(_Row["Monto"].ToString().Trim());
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row["ccount"].ToString().Trim(), _P_Str_Proveedor, _Row["cdescrip"].ToString().Trim(), _Row["ctdocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _Cls_Formato._Mtd_fecha(_Dtm_FechaEmi), _Cls_Formato._Mtd_fecha(_Dtm_FechaVenc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["Naturaleza"].ToString().Trim().ToUpper());
            }
        }

        private DateTime _Mtd_FechaEmision(string _P_Str_ID_Fact_CxP)
        {
            string _Str_Cadena = "SELECT cfechaemision FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Fact_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }

        private DateTime _Mtd_FechaVencimiento(string _P_Str_ID_Fact_CxP)
        {
            string _Str_Cadena = "SELECT cfechavencimiento FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _P_Str_ID_Fact_CxP + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }

        private string _Mtd_Proveedor(string _P_Str_Compañia, string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cproveedor FROM TCOMPROBANRETPAT WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }

//        private void _Mtd_Imprimir(string _P_Str_Compañia, string _P_Str_ComprobanteRetencion)
//        {
//            try
//            {
//                string _Str_Sql = "";
//                int _Int_Sw = 0;
////                REPORTESS _Frm;
////                PrintDialog _Print = new PrintDialog();
//            _PrintComprob:
//                //if (_Print.ShowDialog() == DialogResult.OK)
//                //{
//                    if (_Mtd_Anulado(_P_Str_Compañia.Trim(), _P_Str_ComprobanteRetencion.Trim()))
//                    {
//                        _Str_Sql = "SELECT cidcomprob, cidcomprobanul FROM TCOMPROBANRETPAT WHERE ccompany='" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobanteRetencion.Trim() + "'";
//                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
//                        if (_Ds.Tables[0].Rows.Count > 0)
//                        {
//                            string _Str_cidcomprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
//                            string _Str_cidcomprobanul = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
//                            if (_Str_cidcomprob.Trim().Length == 0) { _Str_cidcomprob = "0"; }
//                            if (_Str_cidcomprobanul.Trim().Length == 0) { _Str_cidcomprobanul = "0"; }
//                            //------------------------------
//                            //Cursor = Cursors.WaitCursor;
//                            _Mtd_Imprimir_Comprobante_Retencion_IAE(_P_Str_Compañia, _P_Str_ComprobanteRetencion);
//                            //_Frm = new REPORTESS(new string[] { "VST_COMPROBANISLR_REPORT" }, "", "T3.Report.rPagoISRL", "", "", "", "", "ccompany = '" + _P_Str_Compañia.Trim() + "' and cidcomprobislr='" + _Str_ComprobanteRetencion + "'", _Print, true);
//                            //Cursor = Cursors.Default;
//////                            _Frm.ShowDialog();
////                            if (MessageBox.Show("¿El comprobante de retención de ISLR se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
////                            {
////                                _Frm.Close();
////                                _Frm.Dispose();
////                                goto _PrintComprob;
////                            }
////                            //------------------------------
//                            //Cursor = Cursors.WaitCursor;
//                            //_Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' AND (cidcomprob='" + _Str_cidcomprob + "' OR cidcomprob='" + _Str_cidcomprobanul + "')", _Print, true);
//                            //Cursor = Cursors.Default;
//                            //if (MessageBox.Show("¿El comprobante contable se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
//                            //{
//                            //    _Frm.Close();
//                            //    _Frm.Dispose();
//                            //    goto _PrintComprob;
//                            //}
//                            //------------------------------
//                        }
//                    }
//                //}
//            }
//            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. Debe intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
//        }

        private bool _Mtd_Anulado(string _P_Str_Compañia, string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprobret FROM TCOMPROBANRETPAT WHERE ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim() + "' AND canulado = 1";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        private void anulartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Btn_Anular_Click(anulartoolStripMenuItem, e);
        }

        private bool _Mtd_ComprobRet_Impreso(string _P_Str_Compañia, string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "select cimpreso from TCOMPROBANRETPAT where ccompany = '" + _P_Str_Compañia.Trim() + "' AND cidcomprobret = '" + _P_Str_ComprobRetencion.Trim()+ "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cimpreso"].ToString().Trim() == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

    } // formulario
} // namespace