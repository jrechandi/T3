using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ComprobISLRManual : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        
        private bool _Bol_PermitirClicTabDetalle = false;
        private bool _Bol_Agregando = false;
        
        private string _Str_CompanyRetenExterna = "";

        private string _Str_Global_Sustraendo = "";
        private string _Str_Global_ID_ISLR_Misterioso = "";
        private string _Str_Global_Formula = "";
        private string _Str_Global_FechaVencimientoDocumento = "";


        public Frm_ComprobISLRManual()
        {
            InitializeComponent();
        }

        private void Frm_ComprobISLRManual_Load(object sender, EventArgs e)
        {
            _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Tb_Tab.SelectedIndex = 0;

            _Mtd_LlenarGridPrincipal();

            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            
            // desactiva los controles en la pestaña detalle
            _Mtd_DesactivarTodo();

            // hace que el textbox acepte 'solo montos'
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_BaseImponible);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_MontoIVA);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_MontoExento);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Invendible);

        }

        private void _Mtd_LlenarGridPrincipal()
        {
            
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("No. comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidcomprobislr";
            _Str_Campos[1] = "c_nomb_comer";

            // muestra todos los comprobantes no anulados
            string _Str_Sql = "Select cidcomprobislr, c_nomb_comer as Proveedor,dbo.Fnc_Formatear(ctotmontosi) as ctotmontosi,dbo.Fnc_Formatear(ctotretenido) as ctotretenido,cimpreso_descrip as Impreso from VST_COMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado= 0 AND NOT EXISTS(SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobislr=VST_COMPROBANISLRC.cidcomprobislr AND cestatusfirma='1') ";

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Sql, _Str_Campos, "Comprobantes", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //_Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;

                _Mtd_LimpiarDetalle();
                _Mtd_DesactivarTodo();

                _Bol_PermitirClicTabDetalle = false;
                
                _Bol_Agregando = false;
            }


            if (e.TabPageIndex == 1 && !_Bol_PermitirClicTabDetalle)
            {
                e.Cancel = true;
            }
        }


        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                // --------------------------------------------------------------------------------------------------------------------------
                string _Str_NumeroComprobante = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex).Trim();
                string _Str_CodigoCompania = Frm_Padre._Str_Comp;

                _Mtd_MostrarDetalle(_Str_CodigoCompania, _Str_NumeroComprobante);

                //---------------------------------------------------------------------------------------------------------------------------
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
            string _Str_Cadena = "SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobislr='" + _Str_NumeroComprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Mtd_MostrarDetalle(string _Str_CodigoCompania, string _Str_NumeroComprobante)
        {
            _Mtd_LimpiarDetalle();

            string _Str_Sql = "SELECT ccompany, cidcomprobislr, cidcomprob, cproveedor, c_rif, c_nomb_comer, c_direcc_fiscal, CONVERT(VARCHAR,cfechaemiislr,103) as cfechaemiislr, CONVERT(VARCHAR,cfechavencislr,103) as cfechavencislr,cfechaentislr, cnumdocumafec, cnumctrldocumafec, ctotmontosi, ctotsustraendo, ctotretenido, cformula, cformulacad, cformula_name, cimpreso, cascii, canulado, cimpreso_descrip FROM VST_COMPROBANISLRC WHERE ccompany='" + _Str_CodigoCompania + "' AND cidcomprobislr='" + _Str_NumeroComprobante + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_NumeroComprobante.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidcomprobislr"]);
                
                _Txt_NumeroDocumento.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumdocumafec"]);

                if (_Txt_NumeroDocumento.Text.Trim() == "0")
                {
                    _Rb_SinDocumento.Checked = true; }
                else 
                {
                    if (_Mtd_ConDocumento(_Str_NumeroComprobante))
                    {
                        _Rb_ConDocumento.Checked = true;
                    }
                    else
                    {
                        _Rb_IngresarDocumento.Checked = true;
                    }
                }

                _Txt_Formula.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cformula_name"]);

                _DTP_FechaEmisionComprobante.Value = Convert.ToDateTime(Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfechaemiislr"]));
                //_DTP_FechaVencimientoComprobante.Value = Convert.ToDateTime(Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfechavencislr"]));

                _Cmb_Proveedor.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]);

                _Txt_Retenido.Text = Convert.ToDouble(_Ds_Data.Tables[0].Rows[0]["ctotretenido"]).ToString("#,##0.00");
                
                string _Str_Sql_Detalle = "select ctdocumentname,cnumdocu,cnumcontrolfact,CONVERT(varchar, cfechadocu, 103) as cfechadocu, cmontosi_doc, calicuota, csustraendo,cretenido_doc,ctdocument,ciddetalleislr FROM VST_COMPROBANISLRD WHERE ccompany='" + _Str_CodigoCompania + "' AND cidcomprobislr='" + _Str_NumeroComprobante + "'";
                DataSet _Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql_Detalle);
                if (_Ds_Detalle.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_Detalle.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim() == "NA")
                    {
                        _Chk_FactMaqFis.Checked = true;
                    }
                    else
                    {
                        _Chk_FactMaqFis.Checked = false;
                        _Txt_NumCtrlPref.Text = _Ds_Detalle.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().Substring(0, _Ds_Detalle.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().IndexOf("-"));
                        _Txt_NumCtrl.Text = _Ds_Detalle.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().Substring(_Ds_Detalle.Tables[0].Rows[0]["cnumcontrolfact"].ToString().Trim().IndexOf("-") + 1);
                    }
                    //_Txt_NumCtrl.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cnumcontrolfact"]);
                    _Txt_FechaEmisionDocumento.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cfechadocu"]);
                    //_Txt_Alicuota.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["calicuota"]);
                    //_Txt_Sustraendo.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["csustraendo"]);
                    _Txt_Retenido.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cretenido_doc"]);
                }


                if (_Rb_ConDocumento.Checked)
                {
                    _Str_Sql_Detalle = "select ctipodocument, dbo.Fnc_Formatear(calicuota) as calicuota, dbo.Fnc_Formatear(ctotal) as ctotal, dbo.Fnc_Formatear(cmontoinvendible) as cmontoinvendible, dbo.Fnc_Formatear(ctotalimp) as ctotalimp, dbo.Fnc_Formatear(ctotalsimp) as ctotalsimp, dbo.Fnc_Formatear(ctotmontexcento) as ctotmontexcento from dbo.TFACTPPAGARM WHERE ccompany='" + _Str_CodigoCompania + "' AND cidcomprobislr='" + _Str_NumeroComprobante + "' and canulado = 0";
                    _Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql_Detalle);
                    if (_Ds_Detalle.Tables[0].Rows.Count > 0)
                    {
                        _Txt_BaseImponible.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotalsimp"]);
                        _Txt_AlicuotaIVA.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["calicuota"]); ;
                        _Txt_MontoIVA.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotalimp"]);
                        _Txt_MontoExento.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotmontexcento"]);
                        _Txt_Invendible.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cmontoinvendible"]);
                        _Txt_MontoTotal.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotal"]);

                        switch (Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctipodocument"]))
                        {
                            case "FACT": _Txt_TipoDocumento.Text = "FACTURA"; break;
                            case "NDP": _Txt_TipoDocumento.Text = "NOTA DE DEBITO"; break;
                            case "NA": _Txt_TipoDocumento.Text = "NO APLICA"; break;
                            default: _Txt_TipoDocumento.Text = ""; break;
                        }
                    }
                }

                if (_Rb_SinDocumento.Checked || _Rb_IngresarDocumento.Checked)
                {
                    _Str_Sql_Detalle = "select dbo.Fnc_Formatear(ctotmontosi) as ctotmontosi, dbo.Fnc_Formatear(ctotcaomp_iva) as ctotcaomp_iva FROM TCOMPROBANISLRC WHERE ccompany='" + _Str_CodigoCompania + "' AND cidcomprobislr='" + _Str_NumeroComprobante + "' and canulado = 0";
                    _Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql_Detalle);
                    if (_Ds_Detalle.Tables[0].Rows.Count > 0)
                    {
                        // Nota con respecto a _Str_BaseImponible, _Str_MontoExento y _Str_MontoInvendible:
                        // como estos campos no existen en TCOMPROBANISLRC, entonces se optó por guardarlos en 
                        // TFACTPPAGARM, en los registros que "corresponden" al comprobante (los que tienen ctipodocument = 'RETISLR')
                        // El numero de comprobante se guarda en cnumdocu. En los dos registros se guardan los mismos valores para los campos, que se guardan asi:
                        //
                        //  _Str_BaseImponible se guarda en CTOTALIMP
                        //  _Str_MontoExento se guarda en CTOTMONTEXCENTO
                        //  _Str_MontoInvendible se guarda en CMONTOINVENDIBLE
                        
                        //_Txt_BaseImponible.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotmontosi"]);
                        _Txt_BaseImponible.Text = _Mtd_ObtenerBaseImponibleComprobanteGuardado(_Str_CodigoCompania, _Str_NumeroComprobante);
                        _Txt_MontoIVA.Text = (Convert.ToDouble(_Ds_Detalle.Tables[0].Rows[0]["ctotcaomp_iva"]) - Convert.ToDouble(_Ds_Detalle.Tables[0].Rows[0]["ctotmontosi"])).ToString("#,##0.00");
                        _Txt_AlicuotaIVA.Text = ((Convert.ToDouble(_Txt_MontoIVA.Text) * 100) / Convert.ToDouble(_Txt_BaseImponible.Text)).ToString("#,##0.00");
                        _Txt_MontoExento.Text = _Mtd_ObtenerMontoExentoComprobanteGuardado(_Str_CodigoCompania, _Str_NumeroComprobante);
                        _Txt_Invendible.Text = _Mtd_ObtenerInvendibleComprobanteGuardado(_Str_CodigoCompania, _Str_NumeroComprobante);
                        _Txt_MontoTotal.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotcaomp_iva"]);
                        _Txt_TipoDocumento.Text = "NO APLICA";
                        
                    }
                }


            }

            // desactiva los controles en la pestaña detalle
            _Mtd_DesactivarTodo();
        }

        private void _Mtd_LimpiarDetalle()
        {
            if (_Cmb_TipoProv.Items.Count > 0) _Cmb_TipoProv.SelectedIndex = 0;
            if (_Cmb_CategProv.Items.Count > 0) _Cmb_CategProv.SelectedIndex = 0;
            if (_Cmb_Proveedor.Items.Count > 0) _Cmb_Proveedor.SelectedIndex = 0;

            _Rb_ConDocumento.Checked = false;
            _Rb_SinDocumento.Checked = false;

            _DTP_FechaEmisionComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            //_DTP_FechaVencimientoComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();

            _Txt_NumeroComprobante.Text = "";
            _Txt_TipoDocumento.Text = "";
            _Txt_TipoDocumento.Tag = "";
            _Txt_NumeroDocumento.Text = "";
            _Txt_NumeroDocumento.Tag = "";
            _Txt_NumCtrl.Text = "";
            _Txt_FechaEmisionDocumento.Text = "";
            
            _Txt_BaseImponible.Text = "";
            _Txt_MontoExento.Text = "";
            _Txt_Formula.Text = "";
            _Txt_Formula.Tag = "";
            _Txt_Retenido.Text = "";


            _Txt_Invendible.Text = "";
            _Txt_AlicuotaIVA.Text = ""; 
            _Txt_MontoIVA.Text = "";
            _Txt_MontoTotal.Text = "";

        }

        private void _Mtd_LimpiarDetalleNuevoProveedor()
        {
            _Rb_SinDocumento.Checked = true;

            _Txt_BaseImponible.Text = "";
            _Txt_MontoExento.Text = "";
            _Txt_Formula.Text = "";
            _Txt_Formula.Tag = "";
            _Txt_Retenido.Text = "";

            _Txt_Invendible.Text = "";
            _Txt_AlicuotaIVA.Text = "";
            _Txt_MontoIVA.Text = "";
            _Txt_MontoTotal.Text = "";

        }

        private void _Mtd_LimpiarDetalleDocumento()
        {
            _Txt_NumeroComprobante.Text = "";
            _Txt_TipoDocumento.Text = "";
            _Txt_TipoDocumento.Tag = "";
            _Txt_NumeroDocumento.Text = "";
            _Txt_NumeroDocumento.Tag = "";
            _Txt_NumCtrl.Text = "";
            _Txt_FechaEmisionDocumento.Text = "";

            _Txt_BaseImponible.Text = "";
            _Txt_MontoExento.Text = "";
            _Txt_Formula.Text = "";
            _Txt_Formula.Tag = "";
            _Txt_Retenido.Text = "";
            
            _Txt_Invendible.Text = "";
            _Txt_AlicuotaIVA.Text = "";
            _Txt_MontoIVA.Text = "";
            _Txt_MontoTotal.Text = "";
        }

        // copiado de Frm_RelPagPRov.cs
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

        // copiado de Frm_RelPagPRov.cs
        private void _Mtd_CargarCategProv()
        {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
                if (_Cmb_TipoProv.SelectedIndex > 0)
                { _Str_Cadena += " AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
                _Str_Cadena += " ORDER BY Nombre";
                _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_CategProv, _Str_Cadena);
                Cursor = Cursors.Default;
        }

        // copiado de Frm_RelPagPRov.cs
        private void _Mtd_CargarProvee()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                if (_Cmb_TipoProv.SelectedValue.ToString().Trim() == "0" | _Cmb_TipoProv.SelectedValue.ToString().Trim() == "2")
                { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
                else
                { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            }
            else
            { _Str_Cadena += " AND ((TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1') OR (TPROVEEDOR.cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //-----------
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_comer";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }

        // copiado de Frm_RelPagPRov.cs
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

        // copiado de Frm_RelPagPRov.cs
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
                _Rb_SinDocumento.Enabled = true;
                _Rb_ConDocumento.Enabled = true;
                _Rb_IngresarDocumento.Enabled = true;
            }
        }

        private void _Rb_SinDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinDocumento.Checked)
            {
                _Mtd_DesactivarTodo();
                if (_Bol_Agregando)
                {
                    _Mtd_LimpiarDetalleDocumento();
                    _Mtd_ActivarNuevoSinDocumento();
                    _Mtd_InicializarControles();
                    _Txt_TipoDocumento.Text = "NO APLICA";
                    _Txt_AlicuotaIVA.Text = _Mtd_PorcentajeIVAActual();
                }
            }
        }

        private void _Rb_ConDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_ConDocumento.Checked)
            {
                _Mtd_DesactivarTodo();
                if (_Bol_Agregando)
                {
                    _Mtd_LimpiarDetalleDocumento();
                    _Mtd_ActivarNuevoConDocumento();
                    _Mtd_InicializarControles();
                }
            }
        }

        private void Frm_ComprobISLRManual_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;


            if (_Bol_Agregando)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }

            this.Text = "Comprobante de retención de ISLR manual";
        }

        public void _Mtd_Nuevo()
        {
            _Bol_Agregando = true;

            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;

            _Mtd_MostrarPestanaDetalle();
            _Mtd_LimpiarDetalle();
            
            
            _Rb_SinDocumento.Checked = true;

            _Mtd_InicializarControles();

            _DTP_FechaEmisionComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            //_DTP_FechaVencimientoComprobante.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddDays(1);

            _Txt_AlicuotaIVA.Text = _Mtd_PorcentajeIVAActual();
            _Rb_SinDocumento.Enabled = false;
            _Rb_ConDocumento.Enabled = false;
            _Rb_IngresarDocumento.Enabled = false;

        }

        private void _Mtd_InicializarControles()
        {
            _Txt_BaseImponible.Text = "0,00";
            _Txt_MontoExento.Text = "0,00";
            _Txt_Retenido.Text = "0,00";
            
            _Txt_Formula.Text = "";
            _Txt_Formula.Tag = "";
                        
            _Txt_Invendible.Text = "0,00";
            _Txt_AlicuotaIVA.Text = "";
            _Txt_AlicuotaIVA.Tag = "";
            _Txt_MontoIVA.Text = "0,00";
            _Txt_MontoTotal.Text = "0,00";

            
        }

        private void _Mtd_DesactivarTodo()
        {
            // ----------------------------------------------------
            _Cmb_TipoProv.Enabled = false;
            _Cmb_CategProv.Enabled = false;
            _Cmb_Proveedor.Enabled = false;

            _Txt_NumeroComprobante.Enabled = false;
            _DTP_FechaEmisionComprobante.Enabled = false;
            //_DTP_FechaVencimientoComprobante.Enabled = false;
            
            // ----------------------------------------------------
            
            _Rb_SinDocumento.Enabled = false;
            _Rb_ConDocumento.Enabled = false;
            _Rb_IngresarDocumento.Enabled = false;

            _Txt_TipoDocumento.Enabled = false;
            _Txt_NumeroDocumento.Enabled = false;
            _Btn_Documento.Enabled = false;

            _Txt_FechaEmisionDocumento.Enabled = false;
            _Txt_NumCtrl.Enabled = false;
            
            // ----------------------------------------------------

            _Txt_BaseImponible.Enabled = false;
            _Txt_MontoExento.Enabled = false;
            _Txt_Invendible.Enabled = false;
            _Btn_AlicuotaIVA.Enabled = false;
            _Txt_MontoIVA.Enabled = false;
            _Txt_MontoTotal.Enabled = false;

            
            _Txt_Formula.Enabled = false;
            _Btn_Formula.Enabled = false;
            _Txt_Retenido.Enabled = false;


            //------
            _Txt_NumCtrl.Enabled = false;
            _Txt_NumCtrlPref.Enabled = false;
            _Chk_FactMaqFis.Enabled = false;
            //------
            _Dtp_Emision.Visible = false;
            _Txt_FechaEmisionDocumento.Visible = true;

        }

        private void _Mtd_ActivarNuevoSinDocumento()
        {
            _Rb_SinDocumento.Enabled = true;
            _Rb_ConDocumento.Enabled = true;
            _Rb_IngresarDocumento.Enabled = true;
            //_DTP_FechaEmisionComprobante.Enabled = true;
            //_DTP_FechaVencimientoComprobante.Enabled = true;
            // ----------------------------------------------------
            _Cmb_TipoProv.Enabled = true;
            _Cmb_CategProv.Enabled = true;
            _Cmb_Proveedor.Enabled = true;
            // ----------------------------------------------------
            _Txt_BaseImponible.Enabled = true;
            _Txt_MontoExento.Enabled = true;
            _Btn_AlicuotaIVA.Enabled = true;
            _Btn_Formula.Enabled = true;

        }

        private void _Mtd_ActivarNuevoConDocumento()
        {
            _Rb_SinDocumento.Enabled = true;
            _Rb_ConDocumento.Enabled = true;
            _Rb_IngresarDocumento.Enabled = true;
            //_DTP_FechaEmisionComprobante.Enabled = true;
            //_DTP_FechaVencimientoComprobante.Enabled = true;
            // ----------------------------------------------------
            _Cmb_TipoProv.Enabled = true;
            _Cmb_CategProv.Enabled = true;
            _Cmb_Proveedor.Enabled = true;
            // ----------------------------------------------------
            _Btn_Documento.Enabled = true;
            _Btn_Formula.Enabled = true;

        }
     
        private void Frm_ComprobISLRManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            
            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;

        }

        private void _Btn_Formula_Click(object sender, EventArgs e)
        {
            // valida que esté seleccionado un proveedor
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                string _Str_Formula = "";
                string _Str_DescripcionFormula = "";
                string _Str_CodigoFormula = "";
                string _Str_BaseImponible = "";
                string _Str_MontoExento = "";
                string _Str_ID_ISLR_Misterioso = "";

                _Txt_Retenido.Text = "0,00";

                _Txt_Formula.Text = "";
                _Txt_Formula.Tag = "";


                string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
                string _Str_CodigoTipoProveedor = _Mtd_CodigoTipoProveedor(_Str_CodigoProveedor);
                string _Str_CodigoCategoriaProveedor = _Mtd_CodigoCategoriaProveedor(_Str_CodigoProveedor);

                string _Str_ConsultaISLR = _Mtd_DeterminarSqlISLR(_Str_CodigoTipoProveedor, _Str_CodigoCategoriaProveedor, _Str_CodigoProveedor);

                //string _Str_ConsultaISLR = "SELECT cpjdformulaver AS [Persona Jurídica Domiciliada],cislr_id,cpjdformulaname AS Identificador,cpjdformula,cdescrip AS Concepto,cpagador AS Pagador,CASE WHEN cpjdalic IS NULL THEN '0' ELSE cpjdalic END AS cpjdalic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpjdformula<>'0'";

                if (_Str_ConsultaISLR != "")
                {
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(57, _Str_ConsultaISLR);
                    _Frm.ShowDialog();
                    if (_Frm._Str_FrmResult == "1")
                    {
                        _Str_Formula = _Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Frm._Dg_Grid.CurrentCell.RowIndex);
                        _Str_ID_ISLR_Misterioso = _Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, _Frm._Dg_Grid.CurrentCell.RowIndex);
                        _Str_DescripcionFormula = _Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, _Frm._Dg_Grid.CurrentCell.RowIndex);
                        _Str_CodigoFormula = _Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, _Frm._Dg_Grid.CurrentCell.RowIndex); ;

                        _Str_BaseImponible = _Txt_BaseImponible.Text;
                        _Str_MontoExento = _Txt_MontoExento.Text;

                        _Mtd_ActualizarMontoRetenido(_Str_Formula, _Str_BaseImponible, _Str_MontoExento);

                        _Txt_Formula.Text = _Str_DescripcionFormula;
                        _Txt_Formula.Tag = _Str_CodigoFormula;

                        // estos valores se guardan en variables globales porque no hay controles para ellos en el formulario
                        _Str_Global_ID_ISLR_Misterioso = _Str_ID_ISLR_Misterioso;
                        _Str_Global_Formula = _Str_Formula;
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor antes de seguir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        
        private void _Mtd_ActualizarMontoRetenido(string _Str_Formula, string _Str_BaseImponible, string _Str_MontoExento)
        {
            string _Str_MontoRetenido = "0";
            string _Str_Sustraendo = "0";
            string _Str_MontoBaseParaRetener = "0";

            if (_Mtd_IsNumeric(_Str_BaseImponible) && _Mtd_IsNumeric(_Str_MontoExento)) 
                _Str_MontoBaseParaRetener = (Convert.ToDouble(_Str_BaseImponible)).ToString();

            _Mtd_ObtenerISLR(_Str_Formula, _Str_MontoBaseParaRetener, this._Ctrl_Busqueda1, this._Dg_Grid.CurrentCell.RowIndex, out _Str_MontoRetenido, out _Str_Sustraendo);

            if (!_Mtd_IsNumeric(_Str_MontoRetenido)) _Str_MontoRetenido = "0";
            if (!_Mtd_IsNumeric(_Str_Sustraendo)) _Str_Sustraendo = "0";
            _Txt_Retenido.Text = Convert.ToDouble(_Str_MontoRetenido).ToString("#,##0.00");
            _Str_Global_Sustraendo = _Str_Sustraendo;

        }

        private void _Mtd_ObtenerISLR(string _Pr_Str_Formula, string _Pr_Str_BaseImpo, Controles._Ctrl_Busqueda _P_Ctrl_Busqueda, int _P_Int_RowIndex, out string _Str_MontoRetenido, out string _Str_Sustraendo)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_R = "";
            CLASES.cls_ExcelFuncion ExcelFuncion = new CLASES.cls_ExcelFuncion();
            string _Str_Sql = "";
            string _Str_Formula = "";
            bool _Bol_Sw = false;
            char[] words = new char[0];
            string[] words_var = new string[0];
            string[] words_const = new string[0];
            string _Str_VarMontoPagar = "BI";
            string _Str_VarIB = "IB";
            string _Str_Asus = "A";
            string _Str_Bsus = "B", _Str_Bimp = "";
            double _Dbl_Sustarendo = 0;
            int _Int_C = 0;
            int _Int_Ini = 0;
            DataSet _Ds = new DataSet();
            _Str_Formula = _Pr_Str_Formula;
            string _Str_Cad = "";
            //CARGO LOS PARAMETROS
            _Str_Sql = "SELECT cvarislrib,csustraendoa,csustraendob,cvarislrmpagar,cvarislrbi FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_VarIB = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrib"]).Trim();
                _Str_Asus = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]).Trim();
                _Str_Bsus = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]).Trim();
                _Str_VarMontoPagar = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrmpagar"]).Trim();
                _Str_Bimp = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrbi"]).Trim();
            }
            //las variables
            words = _Pr_Str_Formula.ToCharArray();
            foreach (char s in words)
            {
                if (s.ToString() == "{")
                {
                    _Int_Ini = _Int_C;
                }
                if (s.ToString() == "}")
                {
                    _Str_Cad = _Pr_Str_Formula.Substring(_Int_Ini, (_Int_C - _Int_Ini) + 1);
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_VarMontoPagar)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_VarIB)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_Bimp)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                }
                _Int_C++;
            }
            _Int_C = 0;
            foreach (char s in words)
            {
                _Bol_Sw = false;
                if (s.ToString() == "[")
                {
                    _Int_Ini = _Int_C;
                }
                if (s.ToString() == "]")
                {
                    _Str_Cad = _Pr_Str_Formula.Substring(_Int_Ini, (_Int_C - _Int_Ini) + 1);

                    _Str_Sql = "select cunitrib,cvalor,csustraendoa,csustraendob from TUNITRIBUT where cdelete=0";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Str_Cad.Replace("]", "").Replace("[", "") == Convert.ToString(_Ds.Tables[0].Rows[0]["cunitrib"]))
                        {
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["cvalor"]));
                            _Bol_Sw = true;
                        }
                        if (_Str_Cad.Replace("]", "").Replace("[", "") == _Str_Asus)
                        {
                            _Dbl_Sustarendo = _Dbl_Sustarendo + Convert.ToDouble(_Ds.Tables[0].Rows[0]["csustraendoa"]);
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]));
                            _Bol_Sw = true;
                        }
                        if (_Str_Cad.Replace("]", "").Replace("[", "") == _Str_Bsus)
                        {
                            _Dbl_Sustarendo = _Dbl_Sustarendo + Convert.ToDouble(_Ds.Tables[0].Rows[0]["csustraendob"]);
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]));
                            _Bol_Sw = true;
                        }
                    }

                    if (!_Bol_Sw)
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cidentif,cconst_valor from TCONST where cidentif='" + _Str_Cad.Replace("[", "").Replace("]", "") + "'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["cconst_valor"]));
                        }
                    }
                }
                _Int_C++;
            }
            try
            { _Str_R = ExcelFuncion._Mtd_UsarFuncion(_Str_Formula); }
            catch
            { _Str_R = "0"; }

            _Str_MontoRetenido = _Str_R;
            _Str_Sustraendo = _Dbl_Sustarendo.ToString();
            
            Cursor = Cursors.Default;
        }

        private void _Btn_Documento_Click(object sender, EventArgs e)
        {
            // valida que esté seleccionado un proveedor
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                string _Str_CodigoGrupoCompania = Frm_Padre._Str_GroupComp;
                string _Str_CodigoCompania = Frm_Padre._Str_Comp;
                string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();

                Frm_Busqueda2 _Frm = new Frm_Busqueda2(80, _Str_CodigoGrupoCompania, _Str_CodigoCompania, _Str_CodigoProveedor);
                
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult != "0")
                {
                    _Mtd_MostrarDetalleDocumento(_Str_CodigoCompania,_Str_CodigoProveedor,_Frm._Str_FrmResult);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor antes de seguir.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void _Mtd_MostrarDetalleDocumento(string _Str_CodigoCompania,string _Str_CodigoProveedor, string _Str_NumeroDocumento)
        {
            // resuelve el problema de algunos numeros de factura con ceros a la izquierda
            long _Int_NumeroDocumento = Convert.ToInt64(_Str_NumeroDocumento);
            string _Str_NumeroDocumentoSinCeros = _Int_NumeroDocumento.ToString();

            _Str_Global_FechaVencimientoDocumento = "";

            // ojo, Roberto y Juan dicen que aqui no se debe usar _Str_NumeroDocumentoSinCeros, por eso lo cambié...
            //string _Str_Sql_Detalle = "select cidfactxp, dbo.Fnc_Formatear(calicuota) as calicuota, dbo.Fnc_Formatear(ctotal) as ctotal, dbo.Fnc_Formatear(cmontoinvendible) as cmontoinvendible, dbo.Fnc_Formatear(ctotalimp) as ctotalimp, convert(VARCHAR,cfechaemision,103) as cfechaemision, convert(VARCHAR,cfechavencimiento,103) as cfechavencimiento, cnumdocuctrl, ctipodocument, dbo.Fnc_Formatear(ctotalsimp) as ctotalsimp, dbo.Fnc_Formatear(ctotmontexcento) as ctotmontexcento from dbo.TFACTPPAGARM WHERE ccompany='" + _Str_CodigoCompania + "' AND cproveedor ='" + _Str_CodigoProveedor + "' and cnumdocu = '" + _Str_NumeroDocumentoSinCeros + "'";

           
            string _Str_Sql_Detalle = "select cidfactxp, dbo.Fnc_Formatear(calicuota) as calicuota, dbo.Fnc_Formatear(ctotal) as ctotal, dbo.Fnc_Formatear(cmontoinvendible) as cmontoinvendible, dbo.Fnc_Formatear(ctotalimp) as ctotalimp, convert(VARCHAR,cdateemifactura,103) as cfechaemision, convert(VARCHAR,cfechavencimiento,103) as cfechavencimiento, cnumdocuctrl, ctipodocument, dbo.Fnc_Formatear(ctotalsimp) as ctotalsimp, dbo.Fnc_Formatear(ctotmontexcento) as ctotmontexcento from dbo.TFACTPPAGARM WHERE ccompany='" + _Str_CodigoCompania + "' AND cproveedor ='" + _Str_CodigoProveedor + "' and cnumdocu = '" + _Str_NumeroDocumento + "'";
            DataSet _Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql_Detalle);
            _Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql_Detalle);
            if (_Ds_Detalle.Tables[0].Rows.Count > 0)
            {
                // ojo, Roberto y Juan dicen que aqui no se debe usar _Str_NumeroDocumentoSinCeros, por eso lo cambié...
                // _Txt_NumeroDocumento.Text = _Str_NumeroDocumentoSinCeros;
                _Txt_NumeroDocumento.Text = _Str_NumeroDocumento;
                _Txt_NumeroDocumento.Tag = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cidfactxp"]);
                _Txt_BaseImponible.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotalsimp"]);
                _Txt_MontoExento.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotmontexcento"]);
                //_Txt_NumCtrl.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cnumdocuctrl"]);
                //----
                if (_Ds_Detalle.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim() == "NA")
                {
                    _Chk_FactMaqFis.Checked = true;
                }
                else
                {
                    _Chk_FactMaqFis.Checked = false;
                    _Txt_NumCtrlPref.Text = _Ds_Detalle.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().Substring(0, _Ds_Detalle.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().IndexOf("-"));
                    _Txt_NumCtrl.Text = _Ds_Detalle.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().Substring(_Ds_Detalle.Tables[0].Rows[0]["cnumdocuctrl"].ToString().Trim().IndexOf("-") + 1);
                }
                //----
                _Txt_FechaEmisionDocumento.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cfechaemision"]);
                _Str_Global_FechaVencimientoDocumento = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cfechavencimiento"]);
                _Txt_MontoIVA.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotalimp"]);
                _Txt_Invendible.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["cmontoinvendible"]);
                _Txt_MontoTotal.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotal"]);
                _Txt_AlicuotaIVA.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["calicuota"]);

                switch (Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctipodocument"]))
                {
                    case "FACT": _Txt_TipoDocumento.Text = "FACTURA"; break;
                    case "NDP": _Txt_TipoDocumento.Text = "NOTA DE DEBITO"; break;
                    default: _Txt_TipoDocumento.Text = ""; break;
                }
            }

            _Txt_Retenido.Text = "0,00";
            _Txt_Formula.Text = "";
            _Txt_Formula.Tag = "";

        }

        private void _Mtd_InicializarFomulario()
        {
            if (_Bol_Agregando)
            {
                //_Mtd_LimpiarDetalleNuevoProveedor();
                _Rb_SinDocumento.Checked = true;
                _Mtd_InicializarControles();
               if (_Rb_SinDocumento.Checked) _Txt_AlicuotaIVA.Text = _Mtd_PorcentajeIVAActual();
            }

            if (_Bol_Agregando && _Cmb_Proveedor.Items.Count > 1 && _Cmb_Proveedor.SelectedValue != null)
            {
                _Mtd_ActualizarInvendible(_Cmb_Proveedor.SelectedValue.ToString());
            }
            _Rb_SinDocumento.Enabled = false;
            _Rb_ConDocumento.Enabled = false;
            _Rb_IngresarDocumento.Enabled = false;
        }

        private bool _Mtd_DocumentoExistente(string _P_Str_Proveedor, string _P_Str_TipoDocument, string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Documento + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        public bool _Mtd_Guardar()
        {
            if (_Mtd_NuevoRegistroEsValido())
            {
                // campos comunes (ambos casos)
                string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
                string _Str_CodigoTipoProveedor = _Mtd_CodigoTipoProveedor(_Str_CodigoProveedor);
                string _Str_CodigoCategoriaProveedor = _Mtd_CodigoCategoriaProveedor(_Str_CodigoProveedor);
                // el id del comprobante se genera más abajo -- 
                string _Str_FechaEmisionComprobante = _DTP_FechaEmisionComprobante.Text;
                //string _Str_FechaVencimientoComprobante = _DTP_FechaVencimientoComprobante.Text;
                string _Str_FechaVencimientoComprobante = _DTP_FechaEmisionComprobante.Value.AddDays(1).ToShortDateString();

                // campos condicionales (con documento o sin documento)
                string _Str_TipoDocumento = "";
                string _Str_NumeroDocumento = "";
                string _Str_NumeroDocumento_TCOMPROBANISLRD = "";
                string _Str_IDDocumento = "";
                string _Str_FechaEmisionDocumento = "";
                string _Str_FechaVencimientoDocumento = "";
                string _Str_NumeroControlDocumento = _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper();
                //--------------------------------------------------------------------
                if (_Rb_ConDocumento.Checked || _Rb_IngresarDocumento.Checked)
                {
                    switch (_Txt_TipoDocumento.Text)
                    {
                        case "FACTURA": _Str_TipoDocumento = "FACT"; break;
                        case "NOTA DE DEBITO": _Str_TipoDocumento = "NDP"; break;
                    }
                    _Str_NumeroDocumento = _Txt_NumeroDocumento.Text;
                    _Str_NumeroDocumento_TCOMPROBANISLRD = _Txt_NumeroDocumento.Text;
                    if (_Rb_ConDocumento.Checked)
                        _Str_IDDocumento = _Txt_NumeroDocumento.Tag.ToString();
                    _Str_FechaEmisionDocumento = _Txt_FechaEmisionDocumento.Text;
                    _Str_FechaVencimientoDocumento = _Str_Global_FechaVencimientoDocumento;
                    //_Str_NumeroControlDocumento = _Txt_NumCtrl.Text;
                }

                if (_Rb_SinDocumento.Checked)
                {
                    _Str_TipoDocumento = "NA";
                    _Str_IDDocumento = "0";
                    _Str_NumeroDocumento = "0";
                    _Str_NumeroDocumento_TCOMPROBANISLRD = "NA";
                    _Str_FechaEmisionDocumento = "null";
                    _Str_FechaVencimientoDocumento = "null";
                    //_Str_NumeroControlDocumento = "NA";
                }


                string _Str_FechaEmisionDocumentoSQL = "";
                string _Str_FechaVencimientoDocumentoSQL = "";
                string _Str_FechaEmisionDocumentoSQL_TCOMPROBANISLRD = "";

                // resuelve el problema de que no se puede insertar la palabra null entre comillas simples, sino que debe ser sin comillas
                if (_Str_FechaVencimientoDocumento == "null")
                {
                    _Str_FechaEmisionDocumentoSQL = "null";
                    _Str_FechaVencimientoDocumentoSQL = "null";

                    // caso especial, aqui la fecha nunca puede ser null, sino que por omision se le coloca la fecha contable del dia...
                    // en este caso _Str_FechaEmisionComprobante tiene esa fecha contable!
                    _Str_FechaEmisionDocumentoSQL_TCOMPROBANISLRD = "'" + _Str_FechaEmisionComprobante + "'";
                }
                else
                {
                    _Str_FechaEmisionDocumentoSQL = "'" + _Str_FechaEmisionDocumento + "'";
                    _Str_FechaVencimientoDocumentoSQL = "'" + _Str_FechaVencimientoDocumento + "'";
                    
                    _Str_FechaEmisionDocumentoSQL_TCOMPROBANISLRD = "'" + _Str_FechaEmisionDocumento + "'";
                }

                if (_Rb_IngresarDocumento.Checked)
                {
                    _Str_FechaEmisionDocumentoSQL = "'" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "'";
                    _Str_FechaEmisionDocumentoSQL_TCOMPROBANISLRD = "'" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "'";
                }
                // campos comunes (ambos casos)
                string _Str_BaseImponible = _Txt_BaseImponible.Text;
                string _Str_CodigoFormula = _Txt_Formula.Tag.ToString();
                string _Str_Retenido = _Txt_Retenido.Text;
                string _Str_MontoExento = _Txt_MontoExento.Text;
                string _Str_AlicuotaIVA = _Txt_AlicuotaIVA.Text;
                string _Str_MontoIVA = _Txt_MontoIVA.Text;
                string _Str_Invendible = _Txt_Invendible.Text;
                string _Str_MontoTotal = _Txt_MontoTotal.Text;
                string _Str_ID_ISLR_Misterioso = _Str_Global_ID_ISLR_Misterioso;
                string _Str_Formula = _Str_Global_Formula;
                string _Str_DescripcionFormula = _Txt_Formula.Text;
                string _Str_Sustraendo = _Str_Global_Sustraendo;
                string _Str_AlicuotaISLR = _Mtd_ObtenerAlicuotaISLR(_Str_CodigoFormula, _Str_BaseImponible);

                // ambos casos, otros campos, copiado de Frm_RelPagProv ----------------------------
                string _Str_TipoDocISLR = "";
                string _Str_ProvRetISLR = "";
                string _Str_TipoDocRetIVA = "";
                string _Str_ProvRetIVA = "";
                string _Str_CatCompaRel = "";
                string _Str_CatAccion = "";
                string _Str_COMPROBANTE_RETEN = "";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretislr,cprovretislr,cprovretiva,ctipdocretiva,ccatproveciarel,ccatproveaccio FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_TipoDocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
                    _Str_ProvRetISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretislr"]);
                    _Str_TipoDocRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                    _Str_ProvRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretiva"]);
                    _Str_CatCompaRel = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]);
                    _Str_CatAccion = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]);
                }
                //--------------------------------------------------------------------


                if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                {
                    // genera el ID del comprobante
                    string _Str_ID_Ret_ISLR = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidcomprobislr) FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "'");

                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna()) //--------RETENCIÓN EXTERNA
                    {
                        _Str_ID_Ret_ISLR = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(cidcomprobislr) FROM TCOMPROBANISLRC WHERE ccompany='" + _Str_CompanyRetenExterna + "'");
                    }

                    _Txt_NumeroComprobante.Text = _Str_ID_Ret_ISLR;

                    // aqui comienza a guardar como tal! ------------- |||||||||||||||||||||||||||||||||||||||||||||||||||--- ---------------------------------------------------------------------------
                    string _Str_Cadena = "";
                    int _Int_ComprobRetISLR = _Mtd_GenerarComprobRetenISLR(_Str_CodigoTipoProveedor, _Str_CodigoCategoriaProveedor, _Str_CatCompaRel, _Str_CatAccion, Convert.ToDouble(_Str_Retenido), _Str_ID_Ret_ISLR,_Str_TipoDocumento,_Str_NumeroDocumento,_Str_FechaEmisionDocumento, _Str_FechaVencimientoDocumento);
                    _Str_Cadena = "INSERT INTO TCOMPROBANISLRC (ccompany,cidcomprobislr,cidcomprob,cproveedor,cfechaemiislr,cfechavencislr,cnumdocumafec,cnumctrldocumafec,ctotmontosi,ctotretenido,ctotsustraendo,cformula,ctotcaomp_iva,cdateadd,cuseradd,cmanual) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_ID_Ret_ISLR + "','" + _Int_ComprobRetISLR.ToString() + "','" + _Str_CodigoProveedor + "','" + _Str_FechaEmisionComprobante + "','" + _Str_FechaVencimientoComprobante + "','" + _Str_NumeroDocumento + "','" + _Str_NumeroControlDocumento + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','0','" + _Str_CodigoFormula + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoTotal)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','1')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "INSERT INTO TCOMPROBANISLRC (ccompany,cidcomprobislr,cidcomprob,cproveedor,cfechaemiislr,cfechavencislr,cnumdocumafec,cnumctrldocumafec,ctotmontosi,ctotretenido,ctotsustraendo,cformula,ctotcaomp_iva,cimpreso,cagregacomp,cdateadd,cuseradd,cmanual) VALUES ('" + _Str_CompanyRetenExterna + "','" + _Str_ID_Ret_ISLR + "','" + _Int_ComprobRetISLR.ToString() + "','" + _Str_CodigoProveedor + "','" + _Str_FechaEmisionComprobante + "','" + _Str_FechaVencimientoComprobante + "','" + _Str_NumeroDocumento + "','" + _Str_NumeroControlDocumento + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','0','" + _Str_CodigoFormula + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoTotal)) + "','1','" + Frm_Padre._Str_Comp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','1')";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //---------------------------
                    //CUENTA POR PAGAR DE RETENCION DE ISLR AL PROVEEDOR DE RETENCION
                    
                    // Nota con respecto a _Str_BaseImponible, _Str_MontoExento y _Str_MontoInvendible:
                    // como estos campos no existen en TCOMPROBANISLRC, entonces se optó por guardarlos en 
                    // TFACTPPAGARM, en los registros que "corresponden" al comprobante (los que tienen ctipodocument = 'RETISLR')
                    // El numero de comprobante se guarda en cnumdocu. En los dos registros se guardan los mismos valores para los campos, que se guardan asi:
                    //
                    //  _Str_BaseImponible se guarda en CTOTALIMP
                    //  _Str_MontoExento se guarda en CTOTMONTEXCENTO
                    //  _Str_MontoInvendible se guarda en CMONTOINVENDIBLE
                    
                    string _Str_ID_Factura_CxP_ISLR = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                    _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_ISLR + "','" + _Str_ProvRetISLR + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','0','" + _Str_CodigoTipoProveedor + "','" + _Str_CodigoCategoriaProveedor + "','" + _Str_FechaEmisionComprobante + "','" + _Str_FechaVencimientoComprobante + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Invendible)) + "',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoExento)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ProvRetISLR + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','" + _Str_FechaEmisionComprobante + "',null,'0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //---------------------------
                    //CUENTA POR PAGAR DE RETENCION ISLR AL PROVEEDOR QUE SE LE AFECTA(DISMINUYE)
                    string _Str_ID_Factura_CxP_ISLR_Prov = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                    _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_ISLR_Prov + "','" + _Str_CodigoProveedor + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','0','" + _Str_CodigoTipoProveedor + "','" + _Str_CodigoCategoriaProveedor + "','" + _Str_FechaEmisionComprobante + "','" + _Str_FechaVencimientoComprobante + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Invendible)) + "',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido) * -1) + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_MontoExento)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido) * -1) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_CodigoProveedor + "','" + _Str_TipoDocISLR + "','" + _Str_ID_Ret_ISLR + "','" + _Str_FechaEmisionComprobante + "',null,'0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido) * -1) + "','0','" + _Int_ComprobRetISLR.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido) * -1) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //---------------------------
                    string _Str_FormulaDetalle = "";
                    string _Str_DescripISLR = "";
                    string _Str_ID_Factura_CxP = "";
                    string _Str_ID_Factura_CxP_ISLR_D = "";
                    string _Str_ID_Ret_ISLR_D = "";
                    string _Str_CodigoConcepto = "";

                    _Str_FormulaDetalle = _Mtd_ObtenerFormula(_Str_CodigoFormula);
                    _Str_DescripISLR = _Mtd_ObtenerDescripISLR(_Str_ID_ISLR_Misterioso);
                    _Str_CodigoConcepto = _Mtd_ObtenerCodigoConcepto(_Str_ID_ISLR_Misterioso, _Str_CodigoFormula);
                    _Str_ID_Factura_CxP = _Str_IDDocumento;
                    
                    
                    // en esta tabla se inserta registro sólo si se hace retencion CON DOCUMENTO
                    if (_Rb_ConDocumento.Checked)
                    {
                        _Str_ID_Factura_CxP_ISLR_D = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetaislrfactxp) FROM TFACTPPAGARISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp=" + _Str_ID_Factura_CxP);
                        _Str_Cadena = "INSERT INTO TFACTPPAGARISLRD (cgroupcomp,ccompany,cidfactxp,ciddetaislrfactxp,cmontosimp,cformula,cmontoislr,cislr_id,cformula_id,csustraendo,calicuota) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP + "','" + _Str_ID_Factura_CxP_ISLR_D + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','" + _Str_FormulaDetalle + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','" + _Str_ID_ISLR_Misterioso + "','" + _Str_CodigoFormula + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Sustraendo)) + "','" + _Str_AlicuotaISLR + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }

                    _Str_ID_Ret_ISLR_D = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(ciddetalleislr) FROM TCOMPROBANISLRD WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_ID_Ret_ISLR_D = _Cls_VariosMetodos._Mtd_CorrelativoExterno("SELECT MAX(ciddetalleislr) FROM TCOMPROBANISLRD WHERE ccompany='" + _Str_CompanyRetenExterna + "'");
                    }
                    //--------
                    _Str_Cadena = "INSERT INTO TCOMPROBANISLRD (ccompany,cidcomprobislr,cproveedor,ciddetalleislr,ctdocument,cnumdocu,cnumcontrolfact,cfechadocu,cconcepto,cmontosi,calicuota,csustraendo,cretenido,cdateadd,cuseradd,ccodconcepto) VALUES('" + Frm_Padre._Str_Comp + "','" + _Str_ID_Ret_ISLR + "','" + _Str_CodigoProveedor + "','" + _Str_ID_Ret_ISLR_D + "','" + _Str_TipoDocumento + "','" + _Str_NumeroDocumento_TCOMPROBANISLRD + "','" + _Str_NumeroControlDocumento + "'," + _Str_FechaEmisionDocumentoSQL_TCOMPROBANISLRD + ",'" + _Str_DescripISLR + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','" + _Str_DescripcionFormula + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Sustraendo)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CodigoConcepto + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "INSERT INTO TCOMPROBANISLRD (ccompany,cidcomprobislr,cproveedor,ciddetalleislr,ctdocument,cnumdocu,cnumcontrolfact,cfechadocu,cconcepto,cmontosi,calicuota,csustraendo,cretenido,cdateadd,cuseradd,ccodconcepto) VALUES('" + _Str_CompanyRetenExterna + "','" + _Str_ID_Ret_ISLR + "','" + _Str_CodigoProveedor + "','" + _Str_ID_Ret_ISLR_D + "','" + _Str_TipoDocumento + "','" + _Str_NumeroDocumento_TCOMPROBANISLRD + "','" + _Str_NumeroControlDocumento + "'," + _Str_FechaEmisionDocumentoSQL_TCOMPROBANISLRD + ",'" + _Str_DescripISLR + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_BaseImponible)) + "','" + _Str_DescripcionFormula + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Sustraendo)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Retenido)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CodigoConcepto + "')";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //--------
                    if (_Rb_ConDocumento.Checked)
                    {
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET cidcomprobislr='" + _Str_ID_Ret_ISLR + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Str_ID_Factura_CxP + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }

                    // aqui termina de guardar como tal! ------|||||||||||||||||||||||||||||||||||||||||||||||||||--- --------------------------------------- --------------------------------------------------------------------------

                    _Bol_Agregando = false;

                    MessageBox.Show("El registro se ha guardado satisfactoriamente.\n\rEl comprobante generado es el No. " + _Str_ID_Ret_ISLR, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Text = "Comprobante de retención de ISLR manual";
                    
                    // actualiza el gris ppal
                    _Mtd_LlenarGridPrincipal();
                    
                    // vuelve a la primera pestaña
                    _Tb_Tab.SelectedIndex = 0;

                    return true;
                }
                else
                {
                    MessageBox.Show("Problemas de conexión para crear las retenciones. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private string _Mtd_NumeroControl(string _P_Str_NumCtrlPref, string _P_Str_NumCtrl)
        {
            if (_P_Str_NumCtrl.Trim().Length == 0)
            {
                return "NA";
            }
            else
            {
                string _Str_Pref = _P_Str_NumCtrlPref.Trim();
                string _Str_NumCtrl = "00000000";
                if (_P_Str_NumCtrlPref.Trim().Length == 0)
                {
                    _Str_Pref = "00";
                }
                else if (_P_Str_NumCtrlPref.Trim().Length == 1 & _Cls_VariosMetodos._Mtd_IsNumeric(_P_Str_NumCtrlPref.Trim()))
                {
                    _Str_Pref = "0" + _P_Str_NumCtrlPref.Trim();
                }
                _Str_NumCtrl = _Str_NumCtrl.Remove(0, _P_Str_NumCtrl.Trim().Length) + _P_Str_NumCtrl.Trim();
                return _Str_Pref + "-" + _P_Str_NumCtrl;//_Str_NumCtrl
            }
        }

        private bool _Mtd_NuevoRegistroEsValido()
        {
            string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
            string _Str_CodigoTipoProveedor = _Mtd_CodigoTipoProveedor(_Str_CodigoProveedor);
            string _Str_CodigoCategoriaProveedor = _Mtd_CodigoCategoriaProveedor(_Str_CodigoProveedor);
            
            
            // verifica que los campos no esten en blanco
            if (_Cmb_Proveedor.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor antes de seguir. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (_Txt_NumeroComprobante.Text.Trim() == "")
            //{
            //    MessageBox.Show("El número del comprobante no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (_DTP_FechaEmisionComprobante.Text.Trim() == "")
            {
                MessageBox.Show("La fecha de emisión del comprobante no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (_DTP_FechaVencimientoComprobante.Text.Trim() == "")
            //{
            //    MessageBox.Show("La fecha de vencimiento del comprobante no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (_DTP_FechaVencimientoComprobante.Value <= _DTP_FechaEmisionComprobante.Value)
            //{
            //    MessageBox.Show("La fecha de vencimiento del comprobante debe ser mayor que la fecha de emisión. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            // verifica que no esten en blanco los detalles del documento, en caso de que el usuario este usando la opcion 'con documento'
            if (_Rb_ConDocumento.Checked)
            {
                if (_Txt_NumeroDocumento.Text.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un documento antes de seguir. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //--------------------------------------------------------------------
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

                if (_Txt_TipoDocumento.Text.Trim() == "")
                {
                    MessageBox.Show("El tipo de documento no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim()))
            {
                MessageBox.Show("La base imponible no es válida. Verifique.","Información",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            //verifica que la base imponible + monto exento no sea cero
            if (Convert.ToDouble(_Txt_BaseImponible.Text) + Convert.ToDouble(_Txt_MontoExento.Text) <= 0)
            {
                MessageBox.Show("La suma de la base imponible mas el monto exento debe ser un monto mayor que cero. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_Txt_Formula.Text.Trim() == "")
            {
                MessageBox.Show("La fórmula no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_Mtd_IsNumeric(_Txt_MontoExento.Text.Trim()))
            {
                MessageBox.Show("El monto exento no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_Mtd_IsNumeric(_Txt_Retenido.Text.Trim()))
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

            if (!_Mtd_IsNumeric(_Txt_Invendible.Text.Trim()))
            {
                MessageBox.Show("El invendible no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_Mtd_IsNumeric(_Txt_Retenido.Text.Trim()))
            {
                MessageBox.Show("El monto retenido no es válido. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (Convert.ToDouble(_Txt_Retenido.Text) <= 0)
            {
                MessageBox.Show("El monto retenido debe ser mayor que cero. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_Str_CodigoTipoProveedor == "1") //"MATERIA PRIMA"
            {
                MessageBox.Show("No es posible generar comprobantes de ISLR manual para el tipo de proveedor 'MATERIA PRIMA'. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_Rb_SinDocumento.Checked)
            {
                bool _Bol_Valido = false;

                if (_Str_CodigoCategoriaProveedor == "37") _Bol_Valido = true; // "ACCIONISTAS"
                if (_Str_CodigoCategoriaProveedor == "35") _Bol_Valido = true; // "SUELDOS DIRECTORES"
                if (_Str_CodigoCategoriaProveedor == "36") _Bol_Valido = true; // "SUELDOS, SALARIOS Y OTROS EMOLUMENTOS"

                if (!_Bol_Valido)    
                {
                    MessageBox.Show("Sólo puede generar comprobantes de ISLR manual INDEPENDIENTES para las categorias de proveedor\n\r'ACCIONISTAS', 'SUELDOS DIRECTORES' y 'SUELDOS, SALARIOS Y OTROS EMOLUMENTOS', del tipo de proveedor 'OTROS'. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (_Rb_IngresarDocumento.Checked)
            {
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) & !_Chk_FactMaqFis.Checked)
                {
                    MessageBox.Show("El número de control del documento no puede estar en blanco. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (_Mtd_DocumentoExistente(_Str_CodigoProveedor, Convert.ToString(_Txt_TipoDocumento.Tag), _Txt_NumeroDocumento.Text))
                {
                    MessageBox.Show("No se puede generar la retención. El documento que introdujo existe en las cuentas por pagar para el proveedor seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Obtiene un valor que indica si el contedito de un TextBox esta validado
        /// </summary>
        /// <param name="_P_Txt_TextBox">TextBox que se va a verificar</param>
        /// <returns>bool</returns>
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }

        private void _Txt_BaseImponible_TextChanged(object sender, EventArgs e)
        {
            if (_Bol_Agregando && (_Rb_SinDocumento.Checked || _Rb_IngresarDocumento.Checked))
            {
                _Mtd_ActualizarMontoIVA();
                _Mtd_ActualizarMontoTotal();
            }

            if (_Bol_Agregando)
            {
                _Txt_Formula.Text = "";
                _Txt_Formula.Tag = "";
                _Txt_Retenido.Text = "0,00";
            }
        }

        private void _Txt_BaseImponible_Click(object sender, EventArgs e)
        {
            _Txt_BaseImponible.SelectAll();
        }

        private int _Mtd_GenerarComprobRetenISLR(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_CatCompRel, string _P_Str_CatAccion, double _P_Dbl_ISLR, string _P_Str_ID_Ret_ISLR, string _Str_TipoDocumento, string _Str_NumeroDocumento, string _Str_FechaEmisionDocumento, string _Str_FechaVencimientoDocumento)
        {
            string _Str_CodigoProveedor = _Cmb_Proveedor.SelectedValue.ToString();
            string _Str_FechaEmisionDocumentoSQL = "";
            string _Str_FechaVencimientoDocumentoSQL = "";

            // resuelve el problema de que no se puede insertar la palabra null entre comillas simples, sino que debe ser sin comillas
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

            string _Str_PROCESOCONTABLE = "";
            if (_P_Str_TipoProv.Trim() == "0")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
            }
            else if (_P_Str_TipoProv.Trim() == "1")
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
            }
            else if (_P_Str_TipoProv.Trim() == "2" & _P_Str_CategProv.Trim().ToUpper() == _P_Str_CatCompRel.Trim().ToUpper())
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETISLRCR";
            }
            else if (_P_Str_TipoProv.Trim() == "2" & _P_Str_CategProv.Trim().ToUpper() == _P_Str_CatAccion.Trim().ToUpper())
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETISLRAC";
            }
            else
            {
                _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
            }
            //-------------------------------------------------------
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_PROCESOCONTABLE);
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------
            int _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','0','0')";//Preguntar si el cstatus se debe guardar en 0 ó en 1.
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            //-------------------------------------------------------
            int _Int_corder = 0;
            string _Str_Cuenta = "";
            string _Str_Descrip = "";
            string _Str_DescripD = "";
            string _Str_NombProveedor = _Mtd_NombAbrevProveedor(_Str_CodigoProveedor);
            string _Str_TipoDocRecISLR = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr");
            string[] _Str_Cuenta_Descrip;
            _Str_Cadena = "select ccount,ctipodocumento,cnaturaleza,cideprocesod,ccountname from VST_PROCESOSCONTD where cidproceso='" + _Str_PROCESOCONTABLE + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_Cuenta_Descrip = _Mtd_ExtraerCuenta(_Row["ccount"].ToString(), _P_Str_TipoProv, _Row["ccountname"].ToString(),_Str_CodigoProveedor);
                _Str_Cuenta = _Str_Cuenta_Descrip[0];
                _Str_DescripD = _Str_Cuenta_Descrip[1];
                //-------------
                if (_Str_TipoDocumento == "FACT")
                { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION ISLR # " + _P_Str_ID_Ret_ISLR + " S/F# " + _Str_NumeroDocumento + " " + _Str_NombProveedor + " VEC:" + _Str_FechaEmisionDocumento; }
                
                if (_Str_TipoDocumento == "NDP")
                { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION ISLR # " + _P_Str_ID_Ret_ISLR + " S/N.D# " + _Str_NumeroDocumento + " " + _Str_NombProveedor + " VEC:" + _Str_FechaEmisionDocumento; }

                if (_Str_TipoDocumento == "NA")
                { _Str_Descrip = _Str_DescripD + " COMPROBANTE DE RETENCION ISLR # " + _P_Str_ID_Ret_ISLR + " " + _Str_NombProveedor; }
                //-------------
                if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "D")
                { _Str_Cadena = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + _Int_corder.ToString() + "','" + _Str_Cuenta + "','" + _Str_TipoDocRecISLR + "','" + _P_Str_ID_Ret_ISLR + "'," + _Str_FechaEmisionDocumentoSQL + ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')"; }
                else if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "H")
                { _Str_Cadena = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + _Int_corder.ToString() + "','" + _Str_Cuenta + "','" + _Str_TipoDocRecISLR + "','" + _P_Str_ID_Ret_ISLR + "'," + _Str_FechaEmisionDocumentoSQL + ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, _Str_CodigoProveedor, _Str_Descrip, _Str_TipoDocRecISLR, _P_Str_ID_Ret_ISLR, _Str_FechaEmisionDocumento, _Str_FechaVencimientoDocumento, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_ISLR), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), _Row["cnaturaleza"].ToString().Trim().ToUpper());
            }
            return _Int_Comprobante;
        }

        private void _Mtd_ActualizarMontoTotal()
        {
            double _Dbl_BaseImponible = 0; if (_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim())) _Dbl_BaseImponible = Convert.ToDouble(_Txt_BaseImponible.Text);
            double _Dbl_MontoIVA = 0; if (_Mtd_IsNumeric(_Txt_MontoIVA.Text.Trim())) _Dbl_MontoIVA = Convert.ToDouble(_Txt_MontoIVA.Text);
            double _Dbl_MontoExento = 0; if (_Mtd_IsNumeric(_Txt_MontoExento.Text.Trim())) _Dbl_MontoExento = Convert.ToDouble(_Txt_MontoExento.Text);
            double _Dbl_Invendible = 0; if (_Mtd_IsNumeric(_Txt_Invendible.Text.Trim())) _Dbl_Invendible = Convert.ToDouble(_Txt_Invendible.Text);

            double _Dbl_MontoTotal = (_Dbl_BaseImponible + _Dbl_MontoIVA + _Dbl_MontoExento) - _Dbl_Invendible;

            _Txt_MontoTotal.Text = _Dbl_MontoTotal.ToString("#,##0.00");
        
        }

        private void _Txt_MontoExento_TextChanged(object sender, EventArgs e)
        {
            if (_Bol_Agregando && (_Rb_SinDocumento.Checked || _Rb_IngresarDocumento.Checked))
            {
                //_Mtd_ActualizarMontoIVA(); // no afecta el IVA en este caso
                _Mtd_ActualizarMontoTotal();
            }

            if (_Bol_Agregando)
            {
                _Txt_Formula.Text = "";
                _Txt_Formula.Tag = "";
                _Txt_Retenido.Text = "0,00";
            }
        }

        private void _Txt_Invendible_TextChanged(object sender, EventArgs e)
        {
            if (_Bol_Agregando && _Rb_SinDocumento.Checked) _Mtd_ActualizarMontoTotal();
        }

        private void _Txt_MontoIVA_TextChanged(object sender, EventArgs e)
        {
            if (_Bol_Agregando && _Rb_SinDocumento.Checked) _Mtd_ActualizarMontoTotal();
        }

        private void _Btn_AlicuotaIVA_Click(object sender, EventArgs e)
        {
            //_Txt_AlicuotaIVA.Text = "";
            //_Txt_MontoIVA.Text = "0,00";
            
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(56, _Txt_AlicuotaIVA, 1, "");
            _Frm.ShowDialog();
            _Mtd_ActualizarMontoIVA();
            _Mtd_ActualizarMontoTotal();
        }

        private void _Txt_MontoExento_Click(object sender, EventArgs e)
        {
            _Txt_MontoExento.SelectAll();
        }

        private void _Txt_Invendible_Click(object sender, EventArgs e)
        {
            _Txt_Invendible.SelectAll();
        }

        private void _Mtd_ActualizarMontoIVA()
        {
            double _Dbl_BaseImponible = 0; if (_Mtd_IsNumeric(_Txt_BaseImponible.Text.Trim())) _Dbl_BaseImponible = Convert.ToDouble(_Txt_BaseImponible.Text);
            double _Dbl_AlicuotaIVA = 0; if (_Mtd_IsNumeric(_Txt_AlicuotaIVA.Text.Trim())) _Dbl_AlicuotaIVA = Convert.ToDouble(_Txt_AlicuotaIVA.Text);

            double _Dbl_MontoIVA = _Dbl_BaseImponible * (_Dbl_AlicuotaIVA / 100);

            _Txt_MontoIVA.Text = _Dbl_MontoIVA.ToString("#,##0.00");
        }

        private double _Mtd_ActualizarInvendible(string _Str_CodigoProveedor)
        {
            string _Str_Cadena = "SELECT ISNULL(cporcinvendible,0) FROM TPROVEEDOR WHERE cproveedor='" + _Str_CodigoProveedor + "' AND cglobal='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            else
            {
                return 0;
            }
            
        }

        private string _Mtd_CodigoTipoProveedor(string _Str_CodigoProveedor)
        {
            string _Str_Sql = "SELECT cglobal from TPROVEEDOR where CPROVEEDOR = '" + _Str_CodigoProveedor +"'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cglobal"]);
            }
            else
            {
                return "";
            }   
        }

        private string _Mtd_CodigoCategoriaProveedor(string _Str_CodigoProveedor)
        {
            // devuelve '0' si la categoria es null, o si no encuentra el proveedor
            string _Str_Sql = "SELECT ISNULL(ccatproveedor,0) as ccatproveedor from TPROVEEDOR where CPROVEEDOR = '" + _Str_CodigoProveedor + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ccatproveedor"]);
            }
            else
            {
                return "0";
            }
        }

        // copiado de Frm_RelPagoProv.cs
        private string _Mtd_ObtenerFormula(string _P_Str_ID_Formula)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cformula FROM TFORMULAS WHERE cformula_id='" + _P_Str_ID_Formula + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return ""; }
        }
        
        // copiado de Frm_RelPagoProv.cs
        private string _Mtd_ObtenerDescripISLR(string _P_Str_ID_ISLR)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdescrip FROM TISLR WHERE cislr_id='" + _P_Str_ID_ISLR + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return ""; }
        }

        private string _Mtd_ObtenerCodigoConcepto(string _P_Str_Id_Islr, string _P_Str_Id_Formula)
        {
            string _Str_Cadena = "SELECT CASE WHEN cpnrformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pnr WHEN cpnnrformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pnnr WHEN cpjdformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pjd WHEN cpjndformula='" + _P_Str_Id_Formula + "' THEN ccodconcepto_pjnd ELSE '0' END " +
            "FROM TISLR INNER JOIN TISLRCODCONCEP ON TISLR.cislr_id=TISLRCODCONCEP.cislr_id WHERE TISLR.cislr_id='" + _P_Str_Id_Islr + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        
        // copiado de Frm_RelPagoProv.cs
        private string _Mtd_ObtenerAlicuotaISLR(string _P_Str_ID_Formula, string _P_Str_Monto)
        {
            if (_P_Str_Monto.Trim().Length == 0)
            { _P_Str_Monto = "0"; }
            string _Str_Cadena = "SELECT TOP 1 calicuota FROM TFORMULASD WHERE cformula_id='" + _P_Str_ID_Formula + "' AND (cexpresion='?' OR (cexpresion='<=' AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Monto)) + "'<=chasta) OR (cexpresion='>' AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Monto)) + "'>chasta)) ORDER BY CAST(REPLACE(REPLACE(calicuota,',','.'),'%','') AS NUMERIC(18,2))";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0%";
        }

        // copiado de Frm_RelPagoProv.cs
        private string _Mtd_NombAbrevProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_abreviado FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            return "";
        }

        // copiado de Frm_RelPagoProv.cs
        private string[] _Mtd_ExtraerCuenta(string _P_Str_Cuenta, string _P_Str_Global, string _P_Str_Descripcion, string _Str_CodigoProveedor)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "0")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR INNER JOIN TCOUNT ON TPROVEEDOR.ctcount=TCOUNT.ccount AND TPROVEEDOR.ccompany=TCOUNT.ccompany WHERE TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_CodigoProveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString() }; }
                }
            }
            else if (_Ds.Tables[0].Rows.Count == 0 & _P_Str_Global.Trim() == "1")
            {
                _Str_Cadena = "SELECT TPROVEEDOR.ctcount, TCOUNT.cname from TPROVEEDOR INNER JOIN TCOUNT ON TPROVEEDOR.ctcount=TCOUNT.ccount WHERE TPROVEEDOR.cglobal='1' AND cproveedor='" + _Str_CodigoProveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { return new string[] { _Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString() }; }
                }
            }
            return new string[] { _P_Str_Cuenta, _P_Str_Descripcion };
        }

        private void _DTP_FechaEmisionComprobante_ValueChanged(object sender, EventArgs e)
        {
            //if (_Bol_Agregando) _DTP_FechaVencimientoComprobante.Value = _DTP_FechaEmisionComprobante.Value.AddDays(1);
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            double _Dbl_Double;
            try
            {
                Convert.ToDouble(Expression);
                return true;
            }
            catch
            {
                return false;
            }
            
            //bool isNum;
            //double retNum;

            //isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            //return isNum;
        }

        private string _Mtd_PorcentajeIVAActual()
        {
            string _Str_Sql = "SELECT cpercent FROM TTAX";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpercent"]);
            }
            else
            {
                return "0";
            }
        }

        //        //_Txt_BaseImponible.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotmontosi"]);
        //_Txt_BaseImponible.Text = _Mtd_ObtenerBaseImponibleComprobanteGuardado(_Str_CodigoCompania, _Str_NumeroComprobante);
        //_Txt_MontoIVA.Text = (Convert.ToDouble(_Ds_Detalle.Tables[0].Rows[0]["ctotcaomp_iva"]) - Convert.ToDouble(_Ds_Detalle.Tables[0].Rows[0]["ctotmontosi"])).ToString("#,##0.00");
        //_Txt_AlicuotaIVA.Text = ((Convert.ToDouble(_Txt_MontoIVA.Text) * 100) / Convert.ToDouble(_Txt_BaseImponible.Text)).ToString("#,##0.00");
        //_Txt_MontoExento.Text = _Mtd_ObtenerMontoExentoComprobanteGuardado(_Str_CodigoCompania, _Str_NumeroComprobante);
        //_Txt_Invendible.Text = _Mtd_ObtenerInvendibleComprobanteGuardado(_Str_CodigoCompania, _Str_NumeroComprobante);
        //_Txt_MontoTotal.Text = Convert.ToString(_Ds_Detalle.Tables[0].Rows[0]["ctotcaomp_iva"]);
        //_Txt_TipoDocumento.Text = "NO APLICA";

        private string _Mtd_ObtenerBaseImponibleComprobanteGuardado(string _Str_CodigoCompania, string _Str_NumeroComprobante)
        {
            // Nota con respecto a _Str_BaseImponible, _Str_MontoExento y _Str_MontoInvendible:
            // como estos campos no existen en TCOMPROBANISLRC, entonces se optó por guardarlos en 
            // TFACTPPAGARM, en los registros que "corresponden" al comprobante (los que tienen ctipodocument = 'RETISLR')
            // El numero de comprobante se guarda en cnumdocu. En los dos registros se guardan los mismos valores para los campos, que se guardan asi:
            //
            //  _Str_BaseImponible se guarda en CTOTALIMP
            //  _Str_MontoExento se guarda en CTOTMONTEXCENTO
            //  _Str_MontoInvendible se guarda en CMONTOINVENDIBLE

            string _Str_Sql = "SELECT dbo.Fnc_Formatear(ctotalimp) as  ctotalimp FROM TFACTPPAGARM where ccompany = '" + _Str_CodigoCompania + "' and cnumdocu = '" + _Str_NumeroComprobante + "' and ctipodocument = 'RETISLR'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctotalimp"]);
            }
            else
            {
                return "0,00";
            }
        }

        private string _Mtd_ObtenerMontoExentoComprobanteGuardado(string _Str_CodigoCompania, string _Str_NumeroComprobante)
        {
            // Nota con respecto a _Str_BaseImponible, _Str_MontoExento y _Str_MontoInvendible:
            // como estos campos no existen en TCOMPROBANISLRC, entonces se optó por guardarlos en 
            // TFACTPPAGARM, en los registros que "corresponden" al comprobante (los que tienen ctipodocument = 'RETISLR')
            // El numero de comprobante se guarda en cnumdocu. En los dos registros se guardan los mismos valores para los campos, que se guardan asi:
            //
            //  _Str_BaseImponible se guarda en CTOTALIMP
            //  _Str_MontoExento se guarda en CTOTMONTEXCENTO
            //  _Str_MontoInvendible se guarda en CMONTOINVENDIBLE

            string _Str_Sql = "SELECT dbo.Fnc_Formatear(CTOTMONTEXCENTO) as  CTOTMONTEXCENTO FROM TFACTPPAGARM where ccompany = '" + _Str_CodigoCompania + "' and cnumdocu = '" + _Str_NumeroComprobante + "' and ctipodocument = 'RETISLR'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(_Ds_Data.Tables[0].Rows[0]["CTOTMONTEXCENTO"]);
            }
            else
            {
                return "0,00";
            }
        }

        private string _Mtd_ObtenerInvendibleComprobanteGuardado(string _Str_CodigoCompania, string _Str_NumeroComprobante)
        {
            // Nota con respecto a _Str_BaseImponible, _Str_MontoExento y _Str_MontoInvendible:
            // como estos campos no existen en TCOMPROBANISLRC, entonces se optó por guardarlos en 
            // TFACTPPAGARM, en los registros que "corresponden" al comprobante (los que tienen ctipodocument = 'RETISLR')
            // El numero de comprobante se guarda en cnumdocu. En los dos registros se guardan los mismos valores para los campos, que se guardan asi:
            //
            //  _Str_BaseImponible se guarda en CTOTALIMP
            //  _Str_MontoExento se guarda en CTOTMONTEXCENTO
            //  _Str_MontoInvendible se guarda en CMONTOINVENDIBLE

            string _Str_Sql = "SELECT dbo.Fnc_Formatear(CMONTOINVENDIBLE) as  CMONTOINVENDIBLE FROM TFACTPPAGARM where ccompany = '" + _Str_CodigoCompania + "' and cnumdocu = '" + _Str_NumeroComprobante + "' and ctipodocument = 'RETISLR'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(_Ds_Data.Tables[0].Rows[0]["CMONTOINVENDIBLE"]);
            }
            else
            {
                return "0,00";
            }
        }

        private string _Mtd_DeterminarSqlISLR(string _P_Str_TipoProv, string _P_Str_CategProv, string _P_Str_Proveedor)
        {
            bool _Bol_Domiciliada = false;
            bool _Bol_Juridica = false;
            string _Str_Cadena = "SELECT cpjuridica,cdomiciliada FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                { _Bol_Juridica = Convert.ToBoolean(_Ds.Tables[0].Rows[0][0]); }
                if (_Ds.Tables[0].Rows[0][1].ToString().Trim().Length > 0)
                { _Bol_Domiciliada = Convert.ToBoolean(_Ds.Tables[0].Rows[0][1]); }
                //-----------------------------------------------------------------
                if (_Bol_Juridica & _Bol_Domiciliada)
                {
                    _Str_Cadena = "SELECT cpjdformulaver AS [Persona Jurídica Domiciliada],cislr_id,cpjdformulaname AS Identificador,cpjdformula,cdescrip AS Concepto,cpagador AS Pagador,CASE WHEN cpjdalic IS NULL THEN '0' ELSE cpjdalic END AS cpjdalic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpjdformula<>'0'";
                    if (_P_Str_TipoProv.Trim() == "0")
                    {
                        _Str_Cadena += " AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                    }
                }
                else if (_Bol_Juridica & !_Bol_Domiciliada)
                {
                    _Str_Cadena = "SELECT cpjndformulaver AS [Persona Jurídica No Domiciliada],cislr_id,cpjndformulaname AS Identificador,cpjndformula,cdescrip AS Concepto,cpagador AS Pagador,cpjndalic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpjndformula<>'0' AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                }
                else if (!_Bol_Juridica & _Bol_Domiciliada)
                {
                    _Str_Cadena = "SELECT cpnrformulaver AS [Persona Natural Residenciada],cislr_id,cpnrformulaname AS Identificador,cpnrformula,cdescrip AS Concepto,cpagador AS Pagador,cpnralic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpnrformula<>'0' AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                }
                else
                {
                    _Str_Cadena = "SELECT cpnnrformulaver AS [Persona Natural No Residenciada],cislr_id,cpnnrformulaname AS Identificador,cpnnrformula,cdescrip AS Concepto,cpagador AS Pagador,cpnnralic FROM VST_ISLRDET WHERE cactivo='1' AND cinactivo='0' AND cpnnrformula<>'0' AND cglobal='" + _P_Str_TipoProv + "' AND ccatproveedor='" + _P_Str_CategProv + "'";
                }
            }

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Str_Cadena; 
            }
            else
            {
                MessageBox.Show("El proveedor seleccionado no está configurado para generar retenciones de ISLR. Verifique.","Información",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return ""; 
            }
        }

        private void _Rb_IngresarDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_IngresarDocumento.Checked)
            {
                _Mtd_DesactivarTodo();
                if (_Bol_Agregando)
                {
                    _Mtd_LimpiarDetalleDocumento();
                    _Mtd_ActivarNuevoSinDocumento();
                    _Mtd_InicializarControles();
                    _Txt_AlicuotaIVA.Text = _Mtd_PorcentajeIVAActual();
                    string _Str_Cadena = "SELECT TCONFIGCXP.ctipdocfact,TDOCUMENT.cname FROM TCONFIGCXP INNER JOIN TDOCUMENT ON TCONFIGCXP.ctipdocfact = TDOCUMENT.ctdocument WHERE TCONFIGCXP.ccompany='" + Frm_Padre._Str_Comp + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Txt_TipoDocumento.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim().ToUpper();
                        _Txt_TipoDocumento.Tag = _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper();
                    }
                    _Txt_NumeroDocumento.Enabled = true;
                    _Btn_Documento.Enabled = false;
                    _Txt_NumCtrl.Enabled = true;
                    _Txt_NumCtrlPref.Enabled = true;
                    _Chk_FactMaqFis.Enabled = true;
                    _Txt_FechaEmisionDocumento.Visible = false;
                    _Dtp_Emision.Visible = true;
                    _Dtp_Emision.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
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
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "-" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }

        private void _Txt_NumCtrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NumCtrl, e, 8, 0);
        }

        private void _Txt_NumCtrl_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NumCtrl.Text)) { _Txt_NumCtrl.Text = ""; }
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void _Cntx_Contex_Opening(object sender, CancelEventArgs e)
        {

        }

        private void _Cntx_Contex_Opening_1(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANULAR_RETENCIONES"));
        }
        private bool _Mtd_VerificarMesComprobanteRETEN(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT TCOMPROBANC.cmontacco FROM TCOMPROBANISLRC INNER JOIN TCOMPROBANC ON TCOMPROBANISLRC.ccompany = TCOMPROBANC.ccompany AND TCOMPROBANISLRC.cidcomprob = TCOMPROBANC.cidcomprob WHERE (TCOMPROBANISLRC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCOMPROBANISLRC.cidcomprobislr = '" + _P_Str_ComprobRetencion + "') AND (TCOMPROBANC.cyearacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "') AND (TCOMPROBANC.cmontacco = '" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarComprobRETENImpreso(string _P_Str_ComprobRetencion)
        {
            bool _Bol_Valido = true;
            //Se verifica que no tenga orden de pago hecha
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretislr FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            string _Str_TipoDocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
            string _Str_Cadena = "SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cordenpaghecha='1' AND CNUMDOCU='" + _P_Str_ComprobRetencion + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TipoDocISLR + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                _Bol_Valido = false;
            }
            if (_Bol_Valido)
            {
                _Str_Cadena = "SELECT cordenpaghecha FROM TFACTPPAGARM WHERE csaldo<>0 AND CNUMDOCU='" + _P_Str_ComprobRetencion + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TipoDocISLR + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count < 2)
                {
                    _Bol_Valido = false;
                }
            }
            return _Bol_Valido;
        }
        private bool _Mtd_CuentasInactivas(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                if (_Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_Comprobante))
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("El comprobante inicial tiene cuentas inactivas.\nDebe reemplazar las cuentas inactivas desde el notificador 'CUENTAS CONTABLES INACTIVAS POR REEMPLAZAR' para realizar la anulación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("No se obtuvo el comprobante inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private string _Mtd_Obtener_ID_Fact_CxP(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
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
        private string _Mtd_Proveedor(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cproveedor FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        private void _Mtd_Anular(string _P_Str_ComprobRetencion)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Id_Comprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                string _Str_ID_Fact_CxP = _Mtd_Obtener_ID_Fact_CxP(_P_Str_ComprobRetencion);
                if (_Str_Id_Comprob.Trim().Length > 0 & _Str_Id_Comprob.Trim() != "0")
                {
                    string _Str_Id_ComprobAnul = _Cls_VariosMetodos._Mtd_CrearComprobanteAnulacion(_Str_Id_Comprob);
                    _Str_Cadena = "UPDATE TCOMPROBANISLRC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //--------RETENCIÓN EXTERNA
                    if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                    {
                        _Str_Cadena = "UPDATE TCOMPROBANISLRC SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
                        Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //--------
                    _Mtd_InsertarAuxiliar(_Str_Id_ComprobAnul, _Mtd_Proveedor(_P_Str_ComprobRetencion), _Str_ID_Fact_CxP);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_Comprob + "' AND CSTATUS='0'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_ComprobAnul + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                _Str_Cadena = "UPDATE TCOMPROBANISLRC SET canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //--------RETENCIÓN EXTERNA
                if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
                {
                    _Str_Cadena = "UPDATE TCOMPROBANISLRC SET canulado=1,cimpreso='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _Str_CompanyRetenExterna + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "'";
                    Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                //--------
                _Str_Cadena = "DELETE FROM TFACTPPAGARISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp='" + _Str_ID_Fact_CxP + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretislr FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                string _Str_TipoDocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _P_Str_ComprobRetencion + "' AND ctipodocument='" + _Str_TipoDocISLR + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumdocu='" + _P_Str_ComprobRetencion + "' AND ctipodocument='" + _Str_TipoDocISLR + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente. Se van a imprimir los comprobantes contables.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Imprimir(_P_Str_ComprobRetencion);
            }
        }
        private bool _Mtd_Anulado(string _P_Str_ComprobRetencion)
        {
            string _Str_Cadena = "SELECT cidcomprobislr FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetencion + "' AND canulado = 1";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        string _Str_ComprobanteAAnular;
        private void _Mtd_Imprimir(string _Str_ComprobanteRetencion)
        {
            try
            {
                string _Str_Sql = "";
                int _Int_Sw = 0;
                REPORTESS _Frm;
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    if (_Mtd_Anulado(_Str_ComprobanteRetencion))
                    {
                        _Str_Sql = "SELECT cidcomprob,cidcomprobanul FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _Str_ComprobanteRetencion + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            string _Str_cidcomprob = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                            string _Str_cidcomprobanul = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
                            if (_Str_cidcomprob.Trim().Length == 0) { _Str_cidcomprob = "0"; }
                            if (_Str_cidcomprobanul.Trim().Length == 0) { _Str_cidcomprobanul = "0"; }
                            //------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Frm = new REPORTESS(new string[] { "VST_COMPROBANISLR_REPORT" }, "", "T3.Report.rPagoISRL", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobislr='" + _Str_ComprobanteRetencion + "'", _Print, true);
                            Cursor = Cursors.Default;
                            _Frm.ShowDialog();
                            if (MessageBox.Show("¿El comprobante de retención de ISLR se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                                goto _PrintComprob;
                            }
                            //------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' AND (cidcomprob='" + _Str_cidcomprob + "' OR cidcomprob='" + _Str_cidcomprobanul + "')", _Print, true);
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿El comprobante contable se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                                goto _PrintComprob;
                            }
                            //------------------------------
                        }
                    }                    
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. Debe intentarlo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void anularToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_Mtd_VerificarMesComprobanteRETEN(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()))
            { _Pnl_Clave.Visible = true; }
            else
            { MessageBox.Show("No es posible anular la retención ya que el mes contable del comprobante de la retención no es igual al mes contable actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                string _Str_IdRetencion=Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim();
                if (_Mtd_VerificarComprobRETENImpreso(_Str_IdRetencion))
                {
                    if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                    {
                        if (_Mtd_CuentasInactivas(_Str_IdRetencion))
                            return;
                        _Mtd_Anular(_Str_IdRetencion); _Mtd_LlenarGridPrincipal();
                    }
                    else
                    {
                        MessageBox.Show("Problemas de conexión para anular la retención. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                { MessageBox.Show("No se puede anular la retención porque ha sido cerrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

    } // formulario
} // namespace
