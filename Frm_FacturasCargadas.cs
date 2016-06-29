using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_FacturasCargadas : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        bool _Bool_Generar = false;
        public Frm_FacturasCargadas(bool _P_Bool_Generar)
        {
            InitializeComponent();
            _Bool_Generar = _P_Bool_Generar;
            if (!_P_Bool_Generar)
            { _Mtd_Actulizar_Facturas(); _Chk_Pendientes.Visible = true; }
            else
            { _Mtd_Actulizar_Facturas_Generar(); _Bt_Generar.Enabled = true; }
        }
        public Frm_FacturasCargadas(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Proveedor)
        {
            InitializeComponent();
            _Mtd_Actulizar_Facturas();
            bool _Bol_Encontrado = false;
            int _Int_Row = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells[4].Value.ToString().Trim() == _P_Str_Recepcion.Trim() & _Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Factura.Trim() & _Dg_Row.Cells[5].Value.ToString().Trim() == _P_Str_Proveedor.Trim())
                { _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Grid.Rows[_Int_Row].Cells[0];
                _Dg_Grid.CurrentCell = _Dg_Cel;
                _Mtd_RowHeaderMouseClick();
            }
        }
        string _Str_Proveedor = "";
        string _Str_Recepcion = "";
        string _Str_Factura = "";
        //*****************************************
        string _Str_TpoDocGian = "";
        string _Str_DocFechaEmiGian = "";
        string _Str_DocNumCtrlGian = "";
        string _Str_ProveedorGian = "";
        string _Str_DocFechaVencGian = "";
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);

        //****************************************

        private void _Mtd_Actulizar_Facturas()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Factura");
            _Tsm_Menu[1] = new ToolStripMenuItem("Fecha");
            _Tsm_Menu[2] = new ToolStripMenuItem("Total");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "Factura";
            _Str_Campos[1] = "Fecha";
            _Str_Campos[2] = "Total";
            string _Str_Cadena = "SELECT cnfacturapro AS Factura, cdateemifactura AS Fecha, dbo.Fnc_Formatear(ctotfactura) AS Total,(Select Top 1 c_nomb_abreviado from TPROVEEDOR where TPROVEEDOR.cproveedor=TRECEPCIONDFM.cproveedor) as Proveedor,cidrecepcion,cproveedor,ccopiaoc FROM TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and  cnotarecepcion='1'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Recepción", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int _Int_i = 0;
            foreach (DataGridViewColumn _Gg_Col in _Dg_Grid.Columns)
            {
                if (_Int_i > 3)
                {
                    _Gg_Col.Visible = false;
                }
                _Int_i++;
            }
        }
        private void _Mtd_Actulizar_Facturas_Generar()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Factura");
            _Tsm_Menu[1] = new ToolStripMenuItem("Fecha");
            _Tsm_Menu[2] = new ToolStripMenuItem("Total");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "Factura";
            _Str_Campos[1] = "Fecha";
            _Str_Campos[2] = "Total";
            string _Str_Cadena = "SELECT cnfacturapro AS Factura, cdateemifactura AS Fecha, ctotfactura AS Total,c_nomb_abreviado as Proveedor,cidrecepcion,cproveedor,ccopiaoc FROM vst_tabdecomprobantnr where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Recepción", _Tsm_Menu, _Dg_Grid, true,"");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int _Int_i = 0;
            foreach (DataGridViewColumn _Gg_Col in _Dg_Grid.Columns)
            {
                if (_Int_i > 3)
                {
                    _Gg_Col.Visible = false;
                }
                _Int_i++;
            }
        }
        private double _Mtd_PorcRetencion(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT ISNULL(cporcenreteniva,0) FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return 0;
        }
        private double _Mtd_RetornarInvendible(string _P_Str_cidrecepcion, string _P_Str_Proveedor, string _P_Str_Factuta)
        {
            string _Str_Cadena = "SELECT ROUND(ISNULL(SUM(((ISNULL(cpresioprocarg,0)-ISNULL(cdescuento1,0))*ISNULL(cporcinvendible,0))/100),0),2,1) FROM TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_cidrecepcion + "' AND cnfacturapro='" + _P_Str_Factuta + "' AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return 0;
        }
        private bool _Mtd_ExisteComprobanteRetencion(string _P_Str_Proveedor, string _P_Str_TipoDocumento, string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT cidcomprobret FROM TCOMPROBANRETD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctdocument='" + _P_Str_TipoDocumento + "' AND cnumdocu='" + _P_Str_Documento + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Generar(string _P_Str_cidnotrecepc, string _P_Str_cidrecepcion, string _P_Str_Proveedor, string _P_Str_Factuta)
        {
            string _Str_Cadena = "SELECT ISNULL(cidcomprob,0) FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _P_Str_cidnotrecepc + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_ID_Comprobante = new int();
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                {
                    double _Dbl_MontoInvend = 0;
                    if (_Txt_Invendible.Text.Trim().Length > 0) { _Dbl_MontoInvend = Convert.ToDouble(_Txt_Invendible.Text); }
                    CLASES._Cls_Varios_Metodos _Cls_Procesos = new T3.CLASES._Cls_Varios_Metodos(true);
                    if (_Dbl_MontoInvend == 0)
                    { _Int_ID_Comprobante = _Cls_Procesos._Mtd_Proceso_P_COMPRA(_Txt_NR.Text.Trim(), _P_Str_cidrecepcion, _P_Str_Proveedor, _P_Str_Factuta); }
                    else
                    {
                        _Dbl_MontoInvend = _Mtd_RetornarInvendible(_P_Str_cidrecepcion, _P_Str_Proveedor, _P_Str_Factuta);
                        _Int_ID_Comprobante = _Cls_Procesos._Mtd_Proceso_P_COMPRA_INVEND(_Txt_NR.Text.Trim(), _P_Str_cidrecepcion, _Dbl_MontoInvend, _P_Str_Proveedor, _P_Str_Factuta); 
                    }
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTARECEPC", "cidcomprob='" + _Int_ID_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _P_Str_cidnotrecepc + "'");
                }
                else
                { _Int_ID_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()); }
                try
                {
                    Cursor = Cursors.WaitCursor;
                    PrintDialog _Print = new PrintDialog();
                    Cursor = Cursors.Default;
                _PrintComprob:
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_ID_Comprobante + "'", _Print, true);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Frm.Close();
                            _Frm.Dispose();
                            double _Dbl_Reten = _Mtd_PorcRetencion(_P_Str_Proveedor);
                            string _Str_Impuesto = _Txt_Impuesto.Text;
                            if (_Str_Impuesto.Trim().Length == 0) { _Str_Impuesto = "0"; }
                            bool _Bol_Verificar = true;
                            if (_Dbl_Reten > 1 & Convert.ToDouble(_Str_Impuesto) > 0 & _Cls_VariosMetodos._Mtd_CompaniaRetieneImp(Frm_Padre._Str_Comp))
                            {
                                Cursor = Cursors.WaitCursor;
                                if (CLASES._Cls_Varios_Metodos._Mtd_VerificarConexionExterna())
                                {
                                    if (!_Mtd_ExisteComprobanteRetencion(_Str_Proveedor, _Str_TpoDocGian, _P_Str_Factuta))
                                    { _Cls_VariosMetodos._Mtd_Proceso_GenerarComprobRetencion(_Str_Proveedor, _Str_TpoDocGian, _Txt_Document.Text, _Str_Recepcion); }
                                }
                                else
                                { _Bol_Verificar = false; }
                                Cursor = Cursors.Default;
                            }
                            if (_Bol_Verificar)
                            {
                                _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_ID_Comprobante + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            { MessageBox.Show("Problemas de conexión para crear la retención. Por favor espere un minuto e intente nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            this.Close();
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
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                    }
                }
                catch (Exception _Ex) { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            { MessageBox.Show("No se encontró la nota de recepción", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void Frm_FacturasCargadas_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }
        private void _Mtd_RowHeaderMouseClick()
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(csubtotal-ctotdescuento) as csubtotal,dbo.Fnc_Formatear(cporcinvendible) as cporcinvendible,dbo.Fnc_Formatear(ctotalimp) as ctotalimp,dbo.Fnc_Formatear(ctotfactura) as ctotfactura,cdateemifactura,cnumdocuctrl,cproveedor,cdatevencimiento from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim() + "' and cnfacturapro='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "' and cproveedor='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[5].Value.ToString().Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Proveedor = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, _Dg_Grid.CurrentCell.RowIndex);
                    _Str_Recepcion = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, _Dg_Grid.CurrentCell.RowIndex);
                    _Str_Factura = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex);
                    _Txt_Document.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex);
                    _Txt_OC.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, _Dg_Grid.CurrentCell.RowIndex);
                    _Txt_Proveedor.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, _Dg_Grid.CurrentCell.RowIndex);
                    _Txt_Monto.Text = _Ds.Tables[0].Rows[0][0].ToString();
                    //_Txt_Invendible.Text = _Ds.Tables[0].Rows[0][1].ToString();
                    _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0][2].ToString();
                    _Txt_Total.Text = _Ds.Tables[0].Rows[0][3].ToString();
                    _Str_DocFechaEmiGian = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdateemifactura"]).ToShortDateString();//***gian
                    _Str_DocFechaVencGian = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdatevencimiento"]).ToShortDateString();//***gian
                    _Str_DocNumCtrlGian = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocuctrl"]);//***gian
                    _Str_ProveedorGian = Convert.ToString(_Ds.Tables[0].Rows[0]["cproveedor"]);//***gian
                }
                _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
    "FROM TDOCUMENT INNER JOIN " +
    "TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentrp " +
    "WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_TipoDocument.Text = _Ds.Tables[0].Rows[0][1].ToString();
                    _Str_TpoDocGian = Convert.ToString(_Ds.Tables[0].Rows[0][0]);//***gian
                }

                _Str_Cadena = "Select ctiponotreceprp from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    string _Str_TNR = _Ds.Tables[0].Rows[0][0].ToString();
                    if (_Str_TNR == "A")
                    { _Txt_TNR.Text = "Devolución de Mercancía"; }
                    else if (_Str_TNR == "B")
                    { _Txt_TNR.Text = "Devolución de Mercancía mal estado"; }
                    else if (_Str_TNR == "C")
                    { _Txt_TNR.Text = "Recepción de Mercancía a Proveedores"; }
                }
                _Str_Cadena = "Select cidnotrecepc,cfechanotrecep,dbo.Fnc_Formatear(cporcinvendible) AS cporcinvendible from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrecepcion='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim() + "' and cnumdocu='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_NR.Text = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    _Txt_FechNR.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                    _Txt_Invendible.Text = _Ds.Tables[0].Rows[0][2].ToString();
                }
                _Mtd_Mostar_Detalle(_Str_Recepcion, _Str_Factura, _Str_Proveedor);
                _Tb_Tab.SelectedIndex = 1;
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_RowHeaderMouseClick();
            Cursor = Cursors.Default;
        }
        private void _Mtd_Mostar_Detalle(string _P_Str_Recepcion,string _P_Str_Factura,string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TRECEPCIONDFD.cproducto as Producto,(Select top 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where TPRODUCTO.cproducto=TRECEPCIONDFD.cproducto) as Descripción,TRECEPCIONDFD.cempaques as Cajas,TRECEPCIONDFD.cunidades as Unidades,dbo.Fnc_Formatear(TRECEPCIONDFD.cprecioxpro) AS Monto, " +
"dbo.Fnc_Formatear(TRECEPCIONDFD.cporcinvendible) AS Invendible, " +
"dbo.Fnc_Formatear(TRECEPCIONDFD.ccalcimp) AS Impuesto, " +
"dbo.Fnc_Formatear((TRECEPCIONDFD.cpresioprocarg-TRECEPCIONDFD.cporcinvendible)+TRECEPCIONDFD.ccalcimp) as Total, " +
"dbo.Fnc_Formatear(TRECEPCIONDFD.ccostobrutolote) AS [Costo bruto], dbo.Fnc_Formatear(TRECEPCIONDFD.cprecioventamax) AS PMV, dbo.Fnc_Formatear(TRECEPCIONDFD.cpreciolista) AS [Precio Lista] " +
"FROM TRECEPCIONDFD LEFT OUTER JOIN " +
"TPROVEEDOR ON TRECEPCIONDFD.cproveedor = TPROVEEDOR.cproveedor " +
"WHERE (TRECEPCIONDFD.cnfacturapro = '" + _P_Str_Factura + "') AND (TRECEPCIONDFD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRECEPCIONDFD.cidrecepcion = '" + _P_Str_Recepcion + "') AND " +
"(TRECEPCIONDFD.cproveedor = '" + _P_Str_Proveedor + "')";           
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void Frm_FacturasCargadas_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_FacturasCargadas_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
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

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Mtd_Generar(_Txt_NR.Text.Trim(), _Str_Recepcion, _Str_Proveedor, _Str_Factura);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            string _Str_Cadena1 = "Esta seguro de generar el comprobante de la NR# " + _Txt_NR.Text.Trim();
            _Lbl_Texto.Text = "¿Esta seguro de generar el comprobante?";
            if (_Dg_Detalle.Rows.Count > 0)
            {
                if (MessageBox.Show(_Str_Cadena1, "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Pnl_Clave.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para la generación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void _Chk_Pendientes_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Pendientes.Checked)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Actulizar_Facturas_Generar();
                Cursor = Cursors.Default;
                _Bool_Generar = true;
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Actulizar_Facturas();
                Cursor = Cursors.Default;
                _Bool_Generar = false;
            }
        }
    }
}