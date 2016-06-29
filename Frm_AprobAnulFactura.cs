using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace T3
{
    public partial class Frm_AprobAnulFactura : Form
    {
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        int _G_Int_Tipo = 0;
        public Frm_AprobAnulFactura(int _Pr_Int_Tipo)
        {
            InitializeComponent();
            _G_Int_Tipo = _Pr_Int_Tipo;
            _Mtd_CargarGrid();
            _Bt_Aprobar.Enabled = true;
            if (_G_Int_Tipo == 2)
            {
                _Bt_Aprobar.Text = "Anular";
            }
        }
        private void _Mtd_CargarGrid()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT '0' as Anular,cfactura,RTRIM(cvendedor_name) as cvendedor_name,RTRIM(c_nomb_comer) AS c_nomb_comer,tot_cajas,tot_unidades,dbo.Fnc_Formatear(monto_total) AS monto_total,RTRIM(motivo_cdescripcion) AS motivo_cdescripcion,cmotianulfact,ccliente,cfacturanu,c_montotot_si_bs,c_impuesto_bs,cpfactura,ISNULL(cidcomprobanul,0) AS cidcomprobanul FROM VST_FACTURA_ANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_G_Int_Tipo == 1)
            {//Facturas anuladas por aprobar
                _Str_Sql = _Str_Sql + " AND cactivo=0 AND cestatusfirma=1";
            }
            else if (_G_Int_Tipo == 2)
            {//Facturas pendientes por anular
                _Str_Sql = _Str_Sql + " AND cactivo=0 AND cestatusfirma=2";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Bt_Aprobar.Enabled = _Dg_Grid.Rows.Count > 0;
            Cursor = Cursors.Default;
        }

        private void _Tool_Seleccionar_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT '1' as Anular,cfactura,RTRIM(cvendedor_name) as cvendedor_name,RTRIM(c_nomb_comer) AS c_nomb_comer,tot_cajas,tot_unidades,dbo.Fnc_Formatear(monto_total) AS monto_total,RTRIM(motivo_cdescripcion) AS motivo_cdescripcion,cmotianulfact,ccliente,cfacturanu,c_montotot_si_bs,c_impuesto_bs,cpfactura,ISNULL(cidcomprobanul,0) AS cidcomprobanul FROM VST_FACTURA_ANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_G_Int_Tipo == 1)
            {//Facturas anuladas por aprobar
                _Str_Sql = _Str_Sql + " AND cactivo=0 AND cestatusfirma=1";
            }
            else if (_G_Int_Tipo == 2)
            {//Facturas pendientes por anular
                _Str_Sql = _Str_Sql + " AND cactivo=0 AND cestatusfirma=2";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Tool_Quitar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrid();
            this.Cursor = Cursors.Default;
        }

        private void _Tool_Actualizar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrid();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Convert.ToString(Campos.Cells["_Dg_GridCol_Print"].Value).Trim() == "1"
                             select Convert.ToString(Campos.Cells["_Dg_GridCol_cidcomprobanul"].Value).Trim();
            if (_Var_Datos.Distinct().Count() == 0)
            { MessageBox.Show("Debe seleccionar por lo menos un registro para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (_Var_Datos.Distinct().Count() > 1)
            { MessageBox.Show("Debe seleccionar registros de igual comprobante", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                string _Str_Comprob = _Var_Datos.First();
                _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                                 where Convert.ToString(Campos.Cells["_Dg_GridCol_Print"].Value).Trim() != "1" & Convert.ToString(Campos.Cells["_Dg_GridCol_cidcomprobanul"].Value).Trim() == _Str_Comprob
                                 select Convert.ToString(Campos.Cells["_Dg_GridCol_cidcomprobanul"].Value).Trim();
                if (_Var_Datos.Count() > 0 & _Str_Comprob != "0")
                {
                    MessageBox.Show("Debe seleccionar todos los registros que tengan comprobante Nº:" + _Str_Comprob, "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _Txt_Clave.Text = "";
                    _Pnl_Clave.Parent = this;
                    _Pnl_Clave.BringToFront();
                    _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                    _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                    _Pnl_Clave.Visible = true;
                }
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tool_Principal.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Bt_Aprobar.Enabled = false;
                _Txt_Clave.Focus();
            }
            else
            {
                _Tool_Principal.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }
        private bool _Mtd_ComprobActualizado(string _P_Str_IdComprob)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_IdComprob + "' AND cstatus='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            double _Dbl_MontoTotal = 0; 
            string _Str_Firma = "";
            string _Str_Sql = "", _Str_comprob = "", _Str_TpoDoc = "";
            if (_Txt_Clave.Text.Trim().Length > 0)
            {
                if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                {
                    _Pnl_Clave.Visible = false;
                    if (_G_Int_Tipo == 1)
                    {
                        _Str_Firma = "F_N2_ANULFACTURA";
                        if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, _Str_Firma))
                        {
                            Cursor = Cursors.WaitCursor;
                            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                            {
                                if (Convert.ToString(_Dg_Row.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                                {
                                    try
                                    {
                                        _Str_Sql = "UPDATE TFACTURANUL SET cactivo=0,cestatusfirma=2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Dg_Row.Cells["_Dg_GridCol_factura"].Value.ToString() + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Problemas al procesar la información de la factura " + _Dg_Row.Cells["_Dg_GridCol_factura"].Value.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            Cursor = Cursors.Default;
                            _Mtd_CargarGrid();
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Usted no está autorizado para aprobar las anulaciones de facturas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (_G_Int_Tipo == 2)
                    {
                        _Str_Firma = "F_N1_ANULFACTURA";
                        if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, _Str_Firma))
                        {
                            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                            {
                                if (Convert.ToString(_Dg_Row.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                                {
                                    _Dbl_MontoTotal = _Dbl_MontoTotal + Convert.ToDouble(_Dg_Row.Cells["_Dg_GridCol_Monto"].Value);
                                }
                            }

                            if (_Dbl_MontoTotal > 0)
                            {
                                _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Str_TpoDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                                }
                                //--------------------------------------------------
                                Cursor = Cursors.WaitCursor;
                                _Str_comprob = _Mtd_Proceso_P_CXC_FACTANUL(_Dbl_MontoTotal);
                                Cursor = Cursors.Default;
                                if (_Mtd_ImprimirComprobante(_Str_comprob))
                                {
                                    //bool _Bol_Error = false;
                                    int _Int_Num_Proceso = 0;
                                    Cursor = Cursors.WaitCursor;
                                    if (!_Mtd_ComprobActualizado(_Str_comprob))
                                    {
                                        _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_comprob + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                    foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                                    {
                                        _Int_Num_Proceso = 1;
                                        if (Convert.ToString(_DgRow.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                                        {
                                        _Lbl_Reintentar:
                                            try
                                            {
                                                if (_Int_Num_Proceso == 1)
                                                {
                                                    _Str_Sql = "UPDATE TFACTURANUL SET cactivo=1,cfechaanul='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim() + "'";
                                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                    _Int_Num_Proceso = 2;
                                                }
                                                if (_Int_Num_Proceso == 2)
                                                {
                                                    if (!_Mtd_FacturaAnulada(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim()))
                                                    {
                                                        _Str_Sql = "UPDATE TFACTURAM SET c_fact_anul='1',cfechaanul='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cmotianulfact='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_cmotianulfact"].Value).Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim() + "'";
                                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                    }
                                                    _Int_Num_Proceso = 3;
                                                }
                                                if (_Int_Num_Proceso == 3)
                                                {
                                                    _Str_Sql = "UPDATE TPREFACTURAM SET c_facturaanul='1' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cpfactura='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_cpfactura"].Value).Trim() + "'";
                                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                    _Int_Num_Proceso = 4;
                                                }
                                                if (_Int_Num_Proceso == 4)
                                                {
                                                    _Str_Sql = "DELETE FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDoc + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim() + "' AND ccliente='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim() + "'";
                                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                    _Int_Num_Proceso = 5;
                                                }
                                                if (_Int_Num_Proceso == 5)
                                                {
                                                    _Str_Sql = "UPDATE TSALDOCLIENTEM SET csaldopendi=csaldopendi-" + _DgRow.Cells["_Dg_GridCol_Monto"].Value.ToString().Replace(".", "").Replace(",", ".") + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim() + "'";
                                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                }
                                            }
                                            catch (Exception _Ex)
                                            {
                                                //MessageBox.Show("Problemas al procesar la factura " + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + ".\n" + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                goto _Lbl_Reintentar;
                                            }
                                        }
                                    }
                                    Cursor = Cursors.Default;
                                    _Mtd_CargarGrid();
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                    MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                //---------------------------------------
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usted no está autorizado para aprobar las anulaciones de facturas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    _Bt_Aprobar.Enabled = _Dg_Grid.Rows.Count > 0;
                }
                else
                {
                    MessageBox.Show("Clave incorrecta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese la clave.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool _Mtd_FacturaAnulada(string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "' AND c_fact_anul='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_ActualizarCidcomprobAnul(string _P_Str_IdComprob)
        {
            string _Str_Cadena = "";
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Convert.ToString(Campos.Cells["_Dg_GridCol_Print"].Value).Trim() == "1"
                             select Convert.ToString(Campos.Cells["_Dg_GridCol_factura"].Value).Trim();
            foreach (string _Str_Fact in _Var_Datos)
            {
                _Str_Cadena = "UPDATE TFACTURAM SET cidcomprobanul='" + _P_Str_IdComprob + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Str_Fact + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
        }
        private double _Mtd_MontoFactura(string _P_Str_Factura, int _P_Int_Sw)
        {
            string _Str_Sql = "SELECT SUM(ISNULL(TFACTURAD.c_monto_si_bs,0)+ISNULL(TFACTURAD.cdescppmonto,0)) AS c_montotot_si, SUM(ISNULL(TFACTURAD.c_impuesto_bs,0)) AS c_impuesto,SUM(ISNULL(TFACTURAD.cdescppmonto,0)) AS c_desc_dpp,SUM(ISNULL(TFACTURAD.c_monto_si_bs,0) + ISNULL(TFACTURAD.c_impuesto_bs,0)) AS c_montotot FROM TFACTURAM INNER JOIN TFACTURAD ON TFACTURAM.cgroupcomp=TFACTURAD.cgroupcomp AND TFACTURAM.ccompany=TFACTURAD.ccompany AND TFACTURAM.cfactura=TFACTURAD.cfactura WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTURAM.ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTURAM.cfactura='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_P_Int_Sw == 1)
            { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot"]); }
            else if (_P_Int_Sw == 2)
            { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si"]); }
            else if (_P_Int_Sw == 3)
            { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto"]); }
            else
            { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_desc_dpp"]); }
        }
        private double _Mtd_MontoTot()
        {
            double _Dbl_MontoTot = 0;
            foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                {
                    _Dbl_MontoTot += _Mtd_MontoFactura(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), 1) + _Mtd_MontoFactura(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), 4);
                }
            }
            return _Dbl_MontoTot;
        }

        private string _Mtd_Proceso_P_CXC_FACTANUL(double _Pr_Dbl_MontoTotal)
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Convert.ToString(Campos.Cells["_Dg_GridCol_Print"].Value).Trim() == "1" & Convert.ToInt32(Campos.Cells["_Dg_GridCol_cidcomprobanul"].Value) > 0
                             select Convert.ToString(Campos.Cells["_Dg_GridCol_cidcomprobanul"].Value).Trim();
            //-------------------------------------------------------------------
            if (_Var_Datos.Count() > 0)
            {
                return _Var_Datos.First();
            }
            else
            {
                string _Str_cidcomprob = "";
                string _Str_cconceptocomp = "";
                string _Str_ctypcompro = "";
                string _Str_cyearacco = "";
                string _Str_cmontacco = "";
                string _Str_ccount = "";
                string _Str_ctdocument = "";
                string _Str_ccountName = "";
                string _Str_cdescrip = "";
                string _Str_FechaFact = "";
                double _Dbl_Monto = 0;
                int _Int_corder = 0;
                string _Str_Sql = "";
                string _Str_TipoDocFact = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocfact");
                DataSet _Ds_A;
                DataSet _Ds;
                Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_FACTANUL");
                _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
                _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
                _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
                _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
                //GUARDO LA CABECERA
                double _Dbl_MontoTot = _Mtd_MontoTot();
                _Str_cidcomprob = Convert.ToString(_MyUtilidad._Mtd_Consecutivo_TCOMPROBANC());
                _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "',0,GETDATE(),'" + Frm_Padre._Str_Use + "',0,'9')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
                //
                _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_FANUL_CIA_RELA' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
                var _Ds_InterComp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //GUARDO EL DETALLE
                _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_FACTANUL' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                {
                    if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                    {
                        foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                        {
                            if (Convert.ToString(_DgRow.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                            {
                                //--------------------------------------------
                                var _Bol_EsInterComp =
                                    CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(
                                        Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim());
                                if (_Bol_EsInterComp)
                                {
                                    var _Row =
                                        _Ds_InterComp.Tables[0].Rows.Cast<DataRow>().Where(
                                            x => x["cideprocesod"].ToString() == "1").SingleOrDefault();
                                    if(_Row!=null)
                                    {
                                        _Str_ccount = Convert.ToString(_Row["ccount"]);
                                        _Str_ctdocument = Convert.ToString(_Row["ctipodocumento"]);
                                        _Str_ccountName = Convert.ToString(_Row["ccountname"]);
                                    }
                                }
                                else
                                {
                                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                                    _Str_ccountName = Convert.ToString(_Drow["ccountname"]);
                                }
                                //--------------------------------------------
                                _DgRow.Cells["_Dg_GridCol_cidcomprobanul"].Value = _Str_cidcomprob;
                                //----------------
                                _Int_corder++;
                                _Str_Sql = "SELECT c_fecha_factura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "'";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
                                    {
                                        _Str_FechaFact = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0][0]).ToShortDateString();
                                    }
                                }
                                _Str_cdescrip = _Str_ccountName + ".\nANUL.FACT " + _Str_FechaFact + " Nº " + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString();
                                _Dbl_Monto = _Mtd_MontoFactura(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), 1);
                                if (_Dbl_Monto > 0)
                                {
                                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                                    }
                                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                                    }
                                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim(), _Str_cdescrip, _Str_TipoDocFact, Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                                }
                            }
                        }
                    }
                    else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                    {
                        foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                        {
                            if (Convert.ToString(_DgRow.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                            {
                                //--------------------------------------------
                                var _Bol_EsInterComp =
                                    CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(
                                        Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim());
                                if (_Bol_EsInterComp)
                                {
                                    var _Row =
                                        _Ds_InterComp.Tables[0].Rows.Cast<DataRow>().Where(
                                            x => x["cideprocesod"].ToString() == "2").SingleOrDefault();
                                    if (_Row != null)
                                    {
                                        _Str_ccount = Convert.ToString(_Row["ccount"]);
                                        _Str_ctdocument = Convert.ToString(_Row["ctipodocumento"]);
                                        _Str_ccountName = Convert.ToString(_Row["ccountname"]);
                                    }
                                }
                                else
                                {
                                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                                    _Str_ccountName = Convert.ToString(_Drow["ccountname"]);
                                }
                                //--------------------------------------------
                                _Int_corder++;
                                _Str_Sql = "SELECT c_fecha_factura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "'";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
                                    {
                                        _Str_FechaFact = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0][0]).ToShortDateString();
                                    }
                                }
                                _Str_cdescrip = _Str_ccountName + ".\nANUL.FACT " + _Str_FechaFact + " Nº " + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString();
                                _Dbl_Monto = _Mtd_MontoFactura(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), 2);
                                if (_Dbl_Monto > 0)
                                {
                                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                                    }
                                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                                    }
                                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim(), _Str_cdescrip, _Str_TipoDocFact, Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                                }
                            }
                        }
                    }
                    else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                    {
                        foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                        {
                            if (Convert.ToString(_DgRow.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                            {
                                //--------------------------------------------
                                var _Bol_EsInterComp =
                                    CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(
                                        Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim());
                                if (_Bol_EsInterComp)
                                {
                                    var _Row =
                                        _Ds_InterComp.Tables[0].Rows.Cast<DataRow>().Where(
                                            x => x["cideprocesod"].ToString() == "3").SingleOrDefault();
                                    if (_Row != null)
                                    {
                                        _Str_ccount = Convert.ToString(_Row["ccount"]);
                                        _Str_ctdocument = Convert.ToString(_Row["ctipodocumento"]);
                                        _Str_ccountName = Convert.ToString(_Row["ccountname"]);
                                    }
                                }
                                else
                                {
                                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                                    _Str_ccountName = Convert.ToString(_Drow["ccountname"]);
                                }
                                //--------------------------------------------
                                _Int_corder++;
                                _Str_Sql = "SELECT c_fecha_factura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "'";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
                                    {
                                        _Str_FechaFact = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0][0]).ToShortDateString();
                                    }
                                }
                                _Str_cdescrip = _Str_ccountName + ".\nANUL.FACT " + _Str_FechaFact + " Nº " + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString();
                                _Dbl_Monto = _Mtd_MontoFactura(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), 3);
                                if (_Dbl_Monto > 0)
                                {
                                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                                    }
                                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                                    }
                                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim(), _Str_cdescrip, _Str_TipoDocFact, Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                        {
                            if (Convert.ToString(_DgRow.Cells["_Dg_GridCol_Print"].Value).Trim() == "1")
                            {
                                //--------------------------------------------
                                var _Bol_EsInterComp =
                                    CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(
                                        Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim());
                                if (_Bol_EsInterComp)
                                {
                                    var _Row =
                                        _Ds_InterComp.Tables[0].Rows.Cast<DataRow>().Where(
                                            x => x["cideprocesod"].ToString() == "4").SingleOrDefault();
                                    if (_Row != null)
                                    {
                                        _Str_ccount = Convert.ToString(_Row["ccount"]);
                                        _Str_ctdocument = Convert.ToString(_Row["ctipodocumento"]);
                                        _Str_ccountName = Convert.ToString(_Row["ccountname"]);
                                    }
                                }
                                else
                                {
                                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                                    _Str_ccountName = Convert.ToString(_Drow["ccountname"]);
                                }
                                //--------------------------------------------
                                _Int_corder++;
                                _Str_Sql = "SELECT c_fecha_factura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "'";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
                                    {
                                        _Str_FechaFact = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0][0]).ToShortDateString();
                                    }
                                }
                                _Str_cdescrip = _Str_ccountName + ".\nANUL.FACT " + _Str_FechaFact + " Nº " + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString();
                                _Dbl_Monto = _Mtd_MontoFactura(Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), 4);
                                if (_Dbl_Monto > 0)
                                {
                                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                                    }
                                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                                    {
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                                    }
                                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _DgRow.Cells["_Dg_GridCol_factura"].Value.ToString() + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, Convert.ToString(_DgRow.Cells["_Dg_GridCol_ccliente"].Value).Trim(), _Str_cdescrip, _Str_TipoDocFact, Convert.ToString(_DgRow.Cells["_Dg_GridCol_factura"].Value).Trim(), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                                }
                            }
                        }
                    }
                }
                _Mtd_ActualizarCidcomprobAnul(_Str_cidcomprob);
                return _Str_cidcomprob;
            }
            //-------------------------------------------------------------------
        }
        private bool _Mtd_ImprimirComprobante(string _Pr_Str_ComprobId)
        {
            bool _Bol_R = false;
        A:
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {

                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'", _Print, true);
                Cursor = Cursors.Default;
                if (MessageBox.Show("Se imprimió correctamente?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Bol_R = true;
                }
                else
                {
                    goto A;
                }
            }
            return _Bol_R;
        }
        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Bt_Aprobar.Enabled = true;
        }
        public void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Frm_AprobAnulFactura_Load(object sender, EventArgs e)
        {
            _Mtd_Sorted(_Dg_Grid);
            this.Dock = DockStyle.Fill;
            _Pnl_Rechazar.Left = (this.Width / 2) - (_Pnl_Rechazar.Width / 2);
            _Pnl_Rechazar.Top = (this.Height / 2) - (_Pnl_Rechazar.Height / 2);
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 0 | _G_Int_Tipo == 2)
            { e.Cancel = true; }
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotianulfact='1' ORDER BY cdescripcion ASC";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
        }
        private void _Mtd_Rechazar(string _P_Str_Factura,string _P_Str_Motivo)
        {
            string _Str_Sql = "DELETE FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Str_Sql = "UPDATE TFACTURAM SET cmotianulfact='" + _P_Str_Motivo + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }
        private void _Pnl_Rechazar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Rechazar.Visible)
            {
                _Tool_Principal.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Bt_Aprobar.Enabled = false;
                _Mtd_CargarMotivo();
                _Cmb_Motivo.Enabled = true; 
                _Txt_ClaveR.Text = ""; 
                _Txt_ClaveR.Enabled = false; 
                _Cmb_Motivo.Focus();
            }
            else
            {
                _Tool_Principal.Enabled = true;
                _Dg_Grid.Enabled = true;
                _Bt_Aprobar.Enabled = true;
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_ClaveR.Text.Trim()))
            {
                _Pnl_Rechazar.Visible = false;
                _Mtd_Rechazar(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["_Dg_GridCol_factura"].Value).Trim(), _Cmb_Motivo.SelectedValue.ToString().Trim());
                _Mtd_CargarGrid();
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            { _Txt_ClaveR.Enabled = true; _Txt_ClaveR.Focus(); }
            else
            { _Txt_ClaveR.Text = ""; _Txt_ClaveR.Enabled = false; }
        }

        private void rechazarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Pnl_Rechazar.Visible = true;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Rechazar.Visible = false;
        }
    }
}