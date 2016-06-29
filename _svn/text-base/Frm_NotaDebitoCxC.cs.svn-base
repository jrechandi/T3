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
    public partial class Frm_NotaDebitoCxC : Form
    {
        bool _G_Bol_Edit = false;
        string _G_Str_Vendedor = "";
        string _Str_MyProceso = "";
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_NotaDebitoCxC()
        {
            InitializeComponent();
            _Rb_Aplicada.Checked = true;
            //_Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Motivo();
            _Mtd_CargarVendedores();
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Monto);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Exento);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Impuesto);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Total);
        }
        public Frm_NotaDebitoCxC(string _P_Str_Codigo,Form _P_Frm_Padre)
        {
            InitializeComponent();
            _Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Motivo();
            _Mtd_CargarVendedores();
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Monto);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Exento);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Impuesto);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Total);
            _Mtd_Dg_Grid_RowHeaderMouseDoubleClick(_P_Str_Codigo, _P_Frm_Padre);
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Name != _Rb_Aplicada.Name && _Ctrl.Name != _Rb_NoAplicada.Name && _Ctrl.Name != _Chk_FindAprob.Name && _Ctrl.Name != _Rb_Rechazada.Name)
                {
                    if (_Ctrl.Controls.Count > 0)
                    {
                        _Mtd_Color_Estandar(_Ctrl);
                    }
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            //_Str_Campos[0] = "cidnotadebitocc";
            //_Str_Campos[1] = "cdescripcion";
            _Str_Campos[0] = "t1.cidnotadebitocc";
            _Str_Campos[1] = "t1.cdescripcion";
            string _Str_Where = "";
            if (_Rb_Aplicada.Checked)
            {//_Str_Where = _Str_Where + " AND cdescontada = '1'";
                _Str_Where = _Str_Where + " AND t2.csaldofactura = 0";}
            else if (_Rb_NoAplicada.Checked)
            {//_Str_Where = _Str_Where + " AND cdescontada = '0'";
                _Str_Where = _Str_Where + " AND t2.csaldofactura > 0";}
            else
            {//_Str_Where = _Str_Where + " AND cestatusfirma = '9'"; 
                _Str_Where = _Str_Where + " AND t1.cestatusfirma = '9'";}
            if (!_Rb_Rechazada.Checked)
            {
                if (!_Chk_FindAprob.Checked)
                {//_Str_Where = _Str_Where + " AND (cestatusfirma = '2')"; 
                    _Str_Where = _Str_Where + " AND (t1.cestatusfirma = '2')";}
                else
                {//_Str_Where = " AND cestatusfirma = '1'"; 
                    _Str_Where = " AND t1.cestatusfirma = '1'";}
            }
            if (_Rb_Rechazada.Checked || (_Rb_NoAplicada.Checked && _Chk_FindAprob.Checked))
            {
                //string _Str_FindSql = "Select top ?sel cidnotadebitocctemp AS Código, cdescripcion AS Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto,ccliente,'NO' AS Impresa FROM TNOTADEBICCTEMP WHERE NOT cidnotadebitocctemp IN (select top ?omi cidnotadebitocctemp FROM TNOTADEBICCTEMP WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where + ")) AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
                string _Str_FindSql = "Select top ?sel t1.cidnotadebitocctemp AS Código, t1.cdescripcion AS Descripción,dbo.Fnc_Formatear(t1.ctotaldocu) as Monto,t1.ccliente,'NO' AS Impresa FROM TNOTADEBICCTEMP as t1 WHERE NOT t1.cidnotadebitocctemp IN (select top ?omi t1.cidnotadebitocctemp FROM TNOTADEBICCTEMP as t1 WHERE (t1.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND t1.ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where + ")) AND t1.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND t1.ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
                Cursor = Cursors.WaitCursor;
                //_Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Débito", _Tsm_Menu, _Dg_Grid, "TNOTADEBICCTEMP", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where, 100, "ORDER BY cidnotadebitocctemp");
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Débito", _Tsm_Menu, _Dg_Grid, "TNOTADEBICCTEMP as t1", "WHERE (t1.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND t1.ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where, 100, "ORDER BY t1.cidnotadebitocctemp");
                Cursor = Cursors.Default;
            }
            else
            {
                //string _Str_FindSql = "Select top ?sel cidnotadebitocc AS Código, cdescripcion AS Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto,ccliente,CASE WHEN cimpresa=1 THEN 'SI' ELSE 'NO' END AS Impresa FROM TNOTADEBICC WHERE NOT cidnotadebitocc IN (select top ?omi cidnotadebitocc FROM TNOTADEBICC WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND canulado=0" + _Str_Where + ")) and cdelete=0 AND canulado=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
                string _Str_FindSql = "Select top ?sel t1.cidnotadebitocc AS Código, t1.cdescripcion AS Descripción,dbo.Fnc_Formatear(t1.ctotaldocu) as Monto,t1.ccliente, CASE WHEN t1.cimpresa=1 THEN 'SI' ELSE 'NO' END AS Impresa FROM TNOTADEBICC as t1 JOIN TSALDOCLIENTED as t2 ON t1.cidnotadebitocc = t2.cnumdocu AND t1.ccliente = t2.ccliente AND t1. ccompany = t2.ccompany AND t1.cgroupcomp = t2.cgroupcomp WHERE t1.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND t1.ccompany='" + Frm_Padre._Str_Comp + "' AND t1.cdelete=0 AND t1.canulado=0 AND t2.ctipodocument = 'N/D'" + _Str_Where +
                                      " AND NOT t1.cidnotadebitocc IN(Select top ?omi t1.cidnotadebitocc FROM TNOTADEBICC as t1 JOIN TSALDOCLIENTED as t2 ON t1.cidnotadebitocc = t2.cnumdocu AND t1.ccliente = t2.ccliente AND t1. ccompany = t2.ccompany AND t1.cgroupcomp = t2.cgroupcomp WHERE t1.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND t1.ccompany='" + Frm_Padre._Str_Comp + "' AND t1.cdelete=0 AND t1.canulado=0 AND t2.ctipodocument = 'N/D'" + _Str_Where + ")";
                Cursor = Cursors.WaitCursor;
                //_Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Débito", _Tsm_Menu, _Dg_Grid, "TNOTADEBICC", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND canulado=0" + _Str_Where, 100, "ORDER BY cidnotadebitocc");
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Débito", _Tsm_Menu, _Dg_Grid, "TNOTADEBICC as t1 JOIN TSALDOCLIENTED as t2 ON t1.cidnotadebitocc = t2.cnumdocu AND t1.ccliente = t2.ccliente AND t1.ccompany = t2.ccompany AND t1.cgroupcomp = t2.cgroupcomp", "WHERE t1.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND t1.ccompany='" + Frm_Padre._Str_Comp + "' AND t1.cdelete=0 AND t1.canulado=0 AND t2.ctipodocument = 'N/D'" + _Str_Where, 100, "ORDER BY t1.cidnotadebitocc");
                Cursor = Cursors.Default;
            }
            //___________________________________
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidnotadebitocc DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        public int _Mtd_EntradaTemp()
        {
            string _Str_Cadena = "SELECT cidnotadebitocctemp FROM TNOTADEBICCTEMP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidnotadebitocctemp DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void _Mtd_Cargar_Motivo()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(cidmotivo) as cidmotivo,RTRIM(cdescripcion) AS cdescripcion FROM TMOTIVO where cdocumentndcc='1' or cmotivodevcheq='1' ORDER BY cdescripcion ASC";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarVendedores()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cvendedor,cvendedor + '-' + cname as Descr from TVENDEDOR WHERE c_activo='1' and cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend='1'";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Vendedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Txt_Cod.Text = "";
            _Txt_CodCliente.Text = "";
            _Txt_DesCliente.Text = "";
            _Txt_Control.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Document.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Exento.Text = "";
            _Txt_Total.Text = "";
            _G_Str_Vendedor = "";
            _Rb_ConFact.Checked = true;
            _Bt_Firmar.Visible = false;
            _Bt_Rechazar.Visible = false;
            _Mtd_Cargar_Motivo();
            _Mtd_CargarVendedores();
            _Txt_Cod.Enabled = true;
            _G_Bol_Edit = false;
            _Str_MyProceso = "";
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Cod.Enabled = false;
            _Bt_Imprimir.Enabled = false;
            _Bt_Cliente.Enabled = true;
            _Txt_Monto.Enabled = true;
            _Cmb_Motivo.Enabled = true;
            _Rb_ConFact.Enabled = true;
            _Rb_SinFact.Enabled = true;
            _Bt_Descrip.Enabled = true;
            _Cmb_Vendedor.Enabled = _Cmb_Vendedor.SelectedIndex > 0;
            _Bt_FindDoc.Enabled = _Txt_Document.Text.Trim().Length > 0;
            _Str_MyProceso = "M";
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Cod.Enabled = false;
            _Bt_Cliente.Enabled = false;
            _Txt_Document.Enabled = false;
            _Txt_Monto.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Cmb_Vendedor.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Bt_Descrip.Enabled = false;
            _Rb_ConFact.Enabled = false;
            _Rb_SinFact.Enabled = false;
            _Bt_FindDoc.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            _Bt_Cliente.Enabled = true;
            _Bt_Cliente.Focus();
            _Str_MyProceso = "A";
            _Tb_Tab.SelectedIndex = 1;
        }
        private double _Mtd_Impuesto(double _P_Dbl_Monto)
        {
            string _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCXC ON TTAX.ctax = TCONFIGCXC.ctax WHERE (TCONFIGCXC.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return (_P_Dbl_Monto * Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString())) / 100;
                }
                else
                { return 0; }
            }
            else
            { return 0; }
        }
        private double _Mtd_Alicuota()
        {
            string _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCXC ON TTAX.ctax = TCONFIGCXC.ctax WHERE (TCONFIGCXC.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                { return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
            }
            return 0;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private string _Mtd_ValidarFactura(string _Pr_Str_Fact)
        {
            string _Str_Mensaje = "";
            string _Str_Sql = "SELECT c_impresa,c_entregacliente,c_factdevuelta FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Pr_Str_Fact + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_impresa"]) == "0")
                {
                    _Str_Mensaje = "La factura no ha sido impresa.";
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_entregacliente"]) == "0")
                {
                    _Str_Mensaje = "La factura no ha sido entregada al cliente.";
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_factdevuelta"]) == "1")
                {
                    _Str_Mensaje = "La factura ha sido devuelta.";
                }
                _Str_Sql = "SELECT * FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument=(SELECT TCONFIGCXC.ctipdocfact FROM TCONFIGCXC WHERE TCONFIGCXC.ccompany='" + Frm_Padre._Str_Comp + "') AND cnumdocu='" + _Pr_Str_Fact + "' AND csaldofactura=0 AND cactivo=1 AND cdelete=0";
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Str_Mensaje = "La factura no tiene saldo pendiente.";
                }
            }
            else
            {
                _Str_Mensaje = "La factura no existe.";
            }
            return _Str_Mensaje;
        }
        private bool _Mtd_MotivoDPP(string _P_Str_Id_Motivo)
        {
            string _Str_Cadena = "SELECT cmotivodescpp FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmotivodescpp='" + _P_Str_Id_Motivo + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private int _Mtd_MotivoDPP(string _P_Str_Factura, string _P_Str_Id_Motivo)
        {
            string _Str_Cadena = "SELECT TFACTURAM.cfactura FROM TFACTURAM INNER JOIN TFACTURAD ON TFACTURAM.cgroupcomp=TFACTURAD.cgroupcomp AND TFACTURAM.ccompany=TFACTURAD.ccompany AND TFACTURAM.cfactura=TFACTURAD.cfactura WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTURAM.ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTURAM.cfactura='" + _P_Str_Factura + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,TFACTURAM.c_fecha_factura,103))>=CONVERT(DATETIME,'01/07/2011') GROUP BY TFACTURAM.cfactura HAVING SUM(TFACTURAD.cdescppmonto)>0";
            bool _Bol_FacturaValida = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            _Str_Cadena = "SELECT cmotivodescpp FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmotivodescpp='" + _P_Str_Id_Motivo + "'";
            bool _Bol_MotivoDPP = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            if (!_Bol_MotivoDPP)
            { return 0; }//Crear ND normal
            else if (_Bol_MotivoDPP & _Bol_FacturaValida)
            { return 1; }//Crear ND con detalle
            else
            { return 2; }//Mostrar mensaje de que no se le puede aplicar el descuento
        }
        private bool _Mtd_ExisteND_DPP(string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT cmotivodescpp FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_MotivoDPP = _Ds.Tables[0].Rows[0][0].ToString().Trim();
            _Str_Cadena = "SELECT cproducto FROM VST_FACTURASDPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "' AND DESCPPSINNC>0 AND " +
                          "NOT EXISTS(SELECT TNOTADEBICCDTEMP.cproducto FROM TNOTADEBICCTEMP INNER JOIN TNOTADEBICCDTEMP ON TNOTADEBICCTEMP.cgroupcomp = TNOTADEBICCDTEMP.cgroupcomp AND " +
                          "TNOTADEBICCTEMP.ccompany = TNOTADEBICCDTEMP.ccompany AND TNOTADEBICCTEMP.cidnotadebitocctemp = TNOTADEBICCDTEMP.cidnotadebitocctemp AND " +
                          "TNOTADEBICCTEMP.cgroupcomp=VST_FACTURASDPP.cgroupcomp AND TNOTADEBICCTEMP.ccompany=VST_FACTURASDPP.ccompany AND TNOTADEBICCTEMP.cnumdocu=VST_FACTURASDPP.cfactura AND TNOTADEBICCDTEMP.cproducto=VST_FACTURASDPP.cproducto AND TNOTADEBICCTEMP.cestatusfirma<>'9')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0;
        }
        private bool _Mtd_ND_Es_DPP(string _P_Str_ND)
        {
            string _Str_Cadena = "SELECT cmotivodescpp FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_MotivoDPP = _Ds.Tables[0].Rows[0][0].ToString().Trim();
            _Str_Cadena = "SELECT cidnotadebitocctemp FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _P_Str_ND + "' AND cidmotivo='" + _Str_MotivoDPP + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private double _Mtd_MontoResFacturaConNC_DPP(string _P_Str_Factura)
        {
            double _Dbl_DppFactBaseImp = 0;
            double _Dbl_DppFactExent = 0;
            string _Str_Cadena = "SELECT SUM(CASE WHEN c_impuesto_fact>0 THEN ISNULL(DESCPPSINNC,0) ELSE 0 END) As BaseImp,SUM(CASE WHEN c_impuesto_fact=0 THEN ISNULL(DESCPPSINNC,0) ELSE 0 END) As Exent FROM VST_FACTURASDPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_DppFactBaseImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["BaseImp"]);
                _Dbl_DppFactExent = Convert.ToDouble(_Ds.Tables[0].Rows[0]["Exent"]);
            }
            return _Dbl_DppFactBaseImp + _Dbl_DppFactExent;
        }
        private bool _Mtd_ValidaSave()
        {
            string _Str_Msj = "";
            bool _Bol_R = true;
            _Er_Error.Dispose();
            if (_Txt_Impuesto.Text.Trim().Length == 0)
            { _Txt_Impuesto.Text = "0"; }
            if (_Txt_Total.Text.Trim().Length == 0)
            { _Txt_Total.Text = "0"; }
            if (_Txt_Exento.Text.Trim().Length == 0)
            { _Txt_Exento.Text = "0"; }
            if (_Txt_CodCliente.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_DesCliente, "Información requerida!!!");
                _Bol_R = false;
            }
            if (_Txt_Descripcion.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!");
                _Bol_R = false;
            }
            if (_Cmb_Motivo.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!");
                _Bol_R = false;
            }
            if (_Rb_ConFact.Checked)
            {
                if (_Txt_Document.Text.Trim().Length == 0)
                {
                    _Er_Error.SetError(_Txt_Document, "Información requerida!!!");
                    _Bol_R = false;
                }
                else
                {
                    _Str_Msj = _Mtd_ValidarFactura(_Txt_Document.Text);
                    if (_Str_Msj.Length > 0)
                    {
                        _Er_Error.SetError(_Txt_Document, _Str_Msj);
                        _Bol_R = false;
                    }
                }
            }
            else
            {
                if (_Cmb_Vendedor.SelectedIndex <= 0)
                {
                    _Er_Error.SetError(_Cmb_Vendedor, "Información requerida!!!");
                    _Bol_R = false;
                }
            }
            if (_Txt_Monto.Text.Trim().Length == 0)
            { _Txt_Monto.Text = "0"; }
            if (_Txt_Monto.Text.Trim().Length == 0)
            { _Txt_Monto.Text = "0"; }
            bool _Bol_VerificarMontos = _Mtd_VerificarMontos();
            bool _Bol_MotivoDPP = _Mtd_MotivoDPP(Convert.ToString(_Cmb_Motivo.SelectedValue).Trim());

            if (_Bol_R)
            {
                if (_Bol_MotivoDPP)
                {
                    if (_Rb_SinFact.Checked)
                    {
                        MessageBox.Show("No se puede aplicar el motivo elegido a una ND sin factura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Bol_R = false;
                    }
                    else
                    {
                        int _Int_SwMotivoDPP = _Mtd_MotivoDPP(_Txt_Document.Text, Convert.ToString(_Cmb_Motivo.SelectedValue).Trim());
                        if (_Int_SwMotivoDPP == 1)
                        {
                            if (_Mtd_ExisteND_DPP(_Txt_Document.Text))
                            {
                                MessageBox.Show("Ya se ha generado una ND de descuento por pronto pago para el documento seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _Bol_R = false;
                            }
                            else
                            {
                                if (_Mtd_MontoResFacturaConNC_DPP(_Txt_Document.Text) <= 0)
                                {
                                    MessageBox.Show("No se puede realizar la operación. Al documento se le ha hecho una devolución completa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    _Bol_R = false;
                                }
                            }
                        }
                        else if (_Int_SwMotivoDPP == 2)
                        {
                            MessageBox.Show("El documento seleccionado no lleva descuento por pronto pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Bol_R = false;
                        }
                    }
                }
                else 
                {
                    if (!_Bol_VerificarMontos)
                    {
                        _Er_Error.SetError(_Txt_Monto, "Información requerida!!!");
                        _Er_Error.SetError(_Txt_Exento, "Información requerida!!!");
                        _Bol_R = false;
                    }
                }
            }
            return _Bol_R;
        }
        private void _Mtd_ObtenerMontos(string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT CASE WHEN c_impuesto_fact>0 THEN DESCPPSINNC ELSE 0 END AS MontoSinImp, ((DESCPPSINNC * ISNULL(c_impuesto_fact,0))/100) AS MontoImp, DESCPPSINNC + ((DESCPPSINNC * ISNULL(c_impuesto_fact,0))/100) AS MontoTotal, CASE WHEN c_impuesto_fact=0 THEN DESCPPSINNC ELSE 0 END AS MontoExent FROM VST_FACTURASDPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "' AND DESCPPSINNC>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //----------------------
                double _Dbl_MontoSinImp = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_MontoTotal = 0;
                double _Dbl_MontoExento = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Dbl_MontoSinImp += Convert.ToDouble(_Row["MontoSinImp"].ToString());
                    _Dbl_Impuesto += Convert.ToDouble(_Row["MontoImp"].ToString());
                    _Dbl_MontoTotal += Convert.ToDouble(_Row["MontoTotal"].ToString());
                    _Dbl_MontoExento += Convert.ToDouble(_Row["MontoExent"].ToString());
                }
                _Txt_Monto.TextChanged -= new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Monto.Text = _Dbl_MontoSinImp.ToString();
                _Txt_Monto.TextChanged += new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Exento.TextChanged -= new EventHandler(_Txt_Exento_TextChanged);
                _Txt_Exento.Text = _Dbl_MontoExento.ToString();
                _Txt_Exento.TextChanged += new EventHandler(_Txt_Exento_TextChanged);
                _Txt_Impuesto.Text = _Dbl_Impuesto.ToString();
                _Txt_Total.Text = _Dbl_MontoTotal.ToString();
            }
            //}
        }
        private void _Mtd_GenerarND_DET(string _P_Str_Factura, string _P_Str_Cliente, string _P_Str_TipoDoc, string _P_Str_Motivo, string _P_Str_Descripcion, string _P_Str_Vendedor, double _P_Dbl_Alicuota)
        {
        _Et_Retorno:
            string _Str_Cadena = "SELECT TOP 6 CASE WHEN c_impuesto_fact>0 THEN DESCPPSINNC ELSE 0 END AS MontoSinImp, ((DESCPPSINNC * ISNULL(c_impuesto_fact,0))/100) AS MontoImp, DESCPPSINNC + ((DESCPPSINNC * ISNULL(c_impuesto_fact,0))/100) AS MontoTotal, CASE WHEN c_impuesto_fact=0 THEN DESCPPSINNC ELSE 0 END AS MontoExent FROM VST_FACTURASDPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "' AND DESCPPSINNC>0 AND " +
                   "NOT EXISTS(SELECT TNOTADEBICCDTEMP.cproducto FROM TNOTADEBICCTEMP INNER JOIN TNOTADEBICCDTEMP ON TNOTADEBICCTEMP.cgroupcomp = TNOTADEBICCDTEMP.cgroupcomp AND " +
                   "TNOTADEBICCTEMP.ccompany = TNOTADEBICCDTEMP.ccompany AND TNOTADEBICCTEMP.cidnotadebitocctemp = TNOTADEBICCDTEMP.cidnotadebitocctemp AND " +
                   "TNOTADEBICCTEMP.cgroupcomp=VST_FACTURASDPP.cgroupcomp AND TNOTADEBICCTEMP.ccompany=VST_FACTURASDPP.ccompany AND TNOTADEBICCTEMP.cnumdocu=VST_FACTURASDPP.cfactura AND TNOTADEBICCDTEMP.cproducto=VST_FACTURASDPP.cproducto AND TNOTADEBICCTEMP.cestatusfirma<>'9')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocctemp) FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                //----------------------
                double _Dbl_MontoSinImp = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_MontoTotal = 0;
                double _Dbl_MontoExento = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Dbl_MontoSinImp += Convert.ToDouble(_Row["MontoSinImp"].ToString());
                    _Dbl_Impuesto += Convert.ToDouble(_Row["MontoImp"].ToString());
                    _Dbl_MontoTotal += Convert.ToDouble(_Row["MontoTotal"].ToString());
                    _Dbl_MontoExento += Convert.ToDouble(_Row["MontoExent"].ToString());
                }
                //-----------------
                _Str_Cadena = "INSERT INTO TNOTADEBICCTEMP (cgroupcomp,ccompany,cidnotadebitocctemp,ccliente,ctipodocument,cnumdocu,cfecha,cidmotivo,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cdateadd,cuseradd,cestatusfirma,cvendedor,cvendedorc,cgerarea,calicuota,cexento) VALUES " +
                "('" + Frm_Padre._Str_GroupComp + "', '" + Frm_Padre._Str_Comp + "', '" + _Str_ND + "', '" + _P_Str_Cliente + "', " + _P_Str_TipoDoc + ", " + _P_Str_Factura + ", '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "', '" + _P_Str_Motivo + "', '" + _P_Str_Descripcion + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoSinImp) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','1','" + _P_Str_Vendedor + "','" + _P_Str_Vendedor + "','" + _Mtd_GerenteDeArea(_P_Str_Vendedor) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Alicuota) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExento) + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //----------------------
                _Str_Cadena = "INSERT INTO TNOTADEBICCDTEMP (cgroupcomp,ccompany,cidnotadebitocctemp,cproducto,ccajas,cunidades,cmontosimp,cimpuesto,cmontototal,cbasegrabada,cbasexcenta,calicuota) " +
                "SELECT TOP 6 cgroupcomp, ccompany, '" + _Str_ND + "', cproducto, ISNULL(EMPAQUESINNC,0), ISNULL(UNIDADESSINNC,0), CASE WHEN c_impuesto_fact>0 THEN DESCPPSINNC ELSE 0 END AS MontoSinImp, ((DESCPPSINNC * ISNULL(c_impuesto_fact,0))/100) AS MontoImp, DESCPPSINNC + ((DESCPPSINNC * ISNULL(c_impuesto_fact,0))/100) AS MontoTotal, CASE WHEN c_impuesto_fact>0 THEN DESCPPSINNC ELSE 0 END AS MontoSinImp, CASE WHEN c_impuesto_fact=0 THEN DESCPPSINNC ELSE 0 END AS MontoExent,c_impuesto_fact " +
                "FROM VST_FACTURASDPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Factura + "' AND DESCPPSINNC>0 AND " +
                "NOT EXISTS(SELECT TNOTADEBICCDTEMP.cproducto FROM TNOTADEBICCTEMP INNER JOIN TNOTADEBICCDTEMP ON TNOTADEBICCTEMP.cgroupcomp = TNOTADEBICCDTEMP.cgroupcomp AND " +
                "TNOTADEBICCTEMP.ccompany = TNOTADEBICCDTEMP.ccompany AND TNOTADEBICCTEMP.cidnotadebitocctemp = TNOTADEBICCDTEMP.cidnotadebitocctemp AND " +
                "TNOTADEBICCTEMP.cgroupcomp=VST_FACTURASDPP.cgroupcomp AND TNOTADEBICCTEMP.ccompany=VST_FACTURASDPP.ccompany AND TNOTADEBICCTEMP.cnumdocu=VST_FACTURASDPP.cfactura AND TNOTADEBICCDTEMP.cproducto=VST_FACTURASDPP.cproducto AND TNOTADEBICCTEMP.cestatusfirma<>'9')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                goto _Et_Retorno;
            }
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            bool _Bol_R = false;
            string _Str_TpoDoc = "", _Str_NumDoc = "";
            _Txt_Cod.Text = _Mtd_EntradaTemp().ToString();
            if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
            {
                if (_Mtd_ValidaSave())
                {
                    if (_Pnl_Clave.Visible)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select cgroupcomp from TNOTADEBICCTEMP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocctemp='" + _Txt_Cod.Text.Trim() + "'"))
                        {
                            MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Bol_R = false;
                        }
                        else
                        {
                            Cursor = Cursors.WaitCursor;
                            string _Str_Cadena = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Str_TpoDoc = "'" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
                                _Str_NumDoc = _Txt_Document.Text;
                            }
                            if (_Str_NumDoc.Trim().Length == 0)
                            { _Str_NumDoc = "0"; }
                            if (_Rb_SinFact.Checked)
                            { _G_Str_Vendedor = Convert.ToString(_Cmb_Vendedor.SelectedValue); }
                            double _Dbl_Alicuota = _Mtd_Alicuota();
                            if (Convert.ToString(_Txt_Document.Tag).Trim().Length > 0)
                            {
                                if (Convert.ToDouble(_Txt_Document.Tag) > 0)
                                { _Dbl_Alicuota = Convert.ToDouble(_Txt_Document.Tag); }
                            }
                            int _Int_MotivoDPP = 0;
                            if (_Rb_ConFact.Checked)
                            { _Int_MotivoDPP = _Mtd_MotivoDPP(_Txt_Document.Text, Convert.ToString(_Cmb_Motivo.SelectedValue).Trim()); }
                            if (_Int_MotivoDPP == 0)
                            {
                                _Str_Cadena = "insert into TNOTADEBICCTEMP (cgroupcomp,ccompany,cidnotadebitocctemp,ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cidmotivo,cdateadd,cuseradd,cestatusfirma,cvendedor,cvendedorc,cgerarea,calicuota,cexento)"+
                                    " values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Cod.Text.Trim() + "','" + _Txt_CodCliente.Text.Trim() + "'," + _Str_TpoDoc + ",'" + _Str_NumDoc + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text)) + "','" + _Cmb_Motivo.SelectedValue + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',1,'" + _G_Str_Vendedor + "','" + _G_Str_Vendedor + "','" + _Mtd_GerenteDeArea(_G_Str_Vendedor) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Alicuota) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Exento.Text)) + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                            else//Debe ser solo _Int_MotivoDPP == 1 porque el 2 es el mensaje de validación.
                            {
                                _Mtd_GenerarND_DET(_Str_NumDoc, _Txt_CodCliente.Text.Trim(), _Str_TpoDoc, Convert.ToString(_Cmb_Motivo.SelectedValue).Trim(), _Txt_Descripcion.Text.Trim().ToUpper(), _G_Str_Vendedor, _Dbl_Alicuota);
                            }
                            Cursor = Cursors.Default;
                            MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar();
                            _Mtd_Deshabilitar_Todo();
                            _G_Bol_Edit = false;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            _Bol_R = true;
                        }
                    }
                    else
                    {
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Focus();
                        _Bol_R = false;
                    }
                }
                else
                {
                    _Bol_R = false;
                }
            }
            else
            {
                MessageBox.Show("Usted no puede cargar Notas de Débito.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _Bol_R = false;
            }
            return _Bol_R;
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            bool _Bol_R = false;
            string _Str_TpoDoc = "", _Str_NumDoc = "";
            if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
            {
                if (_Mtd_ValidaSave())
                {
                    if (_Pnl_Clave.Visible)
                    {
                        Cursor = Cursors.WaitCursor;
                        string _Str_Cadena = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_TpoDoc = "'" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
                            _Str_NumDoc = _Txt_Document.Text;
                        }
                        if (_Str_NumDoc.Trim().Length == 0)
                        { _Str_NumDoc = "0"; }
                        if (_Rb_SinFact.Checked)
                        { _G_Str_Vendedor = Convert.ToString(_Cmb_Vendedor.SelectedValue); }
                        double _Dbl_Alicuota = _Mtd_Alicuota();
                        if (Convert.ToString(_Txt_Document.Tag).Trim().Length > 0)
                        {
                            if (Convert.ToDouble(_Txt_Document.Tag) > 0)
                            { _Dbl_Alicuota = Convert.ToDouble(_Txt_Document.Tag); }
                        }
                        _Str_Cadena = "UPDATE TNOTADEBICCTEMP Set ccliente='" + _Txt_CodCliente.Text.Trim() + "',ctipodocument=" + _Str_TpoDoc + ",cnumdocu=" + _Str_NumDoc + ",cfecha='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text.Trim())) + "',cdescripcion='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',cmontototsi='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim())) + "',cimpuesto='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text.Trim())) + "',ctotaldocu='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Total.Text.Trim())) + "',cidmotivo='" + _Cmb_Motivo.SelectedValue + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "',cvendedor='" + _G_Str_Vendedor + "',cvendedorc='" + _G_Str_Vendedor + "', cgerarea='" + _Mtd_GerenteDeArea(_G_Str_Vendedor) + "',calicuota='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Alicuota) + "',cexento='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Exento.Text.Trim())) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocctemp='" + _Txt_Cod.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Mtd_Actualizar();
                        _Mtd_Deshabilitar_Todo();
                        _G_Bol_Edit = false;
                        _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        _Er_Error.Dispose();
                        _Bol_R = true;
                    }
                    else
                    {
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Focus();
                        _Bol_R = false;
                    }
                }
                else
                {
                    _Bol_R = false;
                }
            }
            else
            {
                MessageBox.Show("Usted no puede editar Notas de Débito.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _Bol_R = false;
            }
            return _Bol_R;
        }
        public bool _Mtd_Eliminar()
        {
            bool _Bol_Bol_Temp = false;
            string _Str_Cadena = "Select cimpresa from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        _Bol_Bol_Temp = true;
                    }
                }
            }
            if (!_Bol_Bol_Temp)
            {
                DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eli == DialogResult.Yes)
                {
                    _Str_Cadena = "UPDATE TNOTADEBICC Set cdatedel='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                }
                else
                {
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("EL registro no puede ser eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        private DataTable _Dt_Table(string _P_Str_NotaDebito)
        {
            DataTable _Dta_Tabla = new DataTable("Temporal");
            object _Ob_ItemTemp = new object();
            string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
            string _Str_Cadena = "SELECT ccliente,c_nomb_comer,c_telefono,cvendedor,cname,c_rif,'" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotadebitocc) AS cidnotadebitocc,cdescripcion,cfecha,cmontototsi,cimpuesto,ctotaldocu,c_direcc_fiscal,c_razsocial_1,ISNULL(cexento,0) AS cexento,ccajas,cunidades,cmontosimpdet,cimpuestodet,cmontototaldet,cbasegrabadadet,cbasexcentadet,calicuotadet,cproducto,cnamefc,cfactura,c_fecha_factura,ctotal_fact FROM VST_ND_EMISION WHERE 0>1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dta_Tabla = _Ds.Tables[0].Copy();
            _Str_Cadena = "SELECT ccliente,c_nomb_comer,c_telefono,cvendedor,cname,c_rif,'" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotadebitocc) AS cidnotadebitocc,cdescripcion,cfecha,cmontototsi,cimpuesto,ctotaldocu,c_direcc_fiscal,c_razsocial_1,ISNULL(cexento,0) AS cexento,ccajas,cunidades,cmontosimpdet,cimpuestodet,cmontototaldet,cbasegrabadadet,cbasexcentadet,calicuotadet,cproducto,cnamefc,cfactura,c_fecha_factura,ctotal_fact FROM VST_ND_EMISION WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc ='" + _P_Str_NotaDebito + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
            {
                _Dta_Tabla.Rows.Add(new object[] { _Dtw_Item[0].ToString().TrimEnd(), _Dtw_Item[1].ToString().TrimEnd(), _Dtw_Item[2].ToString().TrimEnd(), _Dtw_Item[3].ToString().TrimEnd(), _Dtw_Item[4].ToString().TrimEnd(), _Dtw_Item[5].ToString().TrimEnd(), _Dtw_Item[6].ToString().TrimEnd(), _Dtw_Item[7].ToString().TrimEnd(), _Dtw_Item[8].ToString().TrimEnd(), _Dtw_Item[9].ToString().TrimEnd(), _Dtw_Item[10].ToString().TrimEnd(), _Dtw_Item[11].ToString().TrimEnd(), _Dtw_Item[12].ToString().TrimEnd(), _Dtw_Item[13].ToString().TrimEnd(), _Dtw_Item[14].ToString().TrimEnd(), _Dtw_Item[15].ToString().TrimEnd(), _Dtw_Item[16].ToString().TrimEnd(), _Dtw_Item[17].ToString().TrimEnd(), _Dtw_Item[18].ToString().TrimEnd(), _Dtw_Item[19].ToString().TrimEnd(), _Dtw_Item[20].ToString().TrimEnd(), _Dtw_Item[21].ToString().TrimEnd(), _Dtw_Item[22].ToString().TrimEnd(), _Dtw_Item[23].ToString().TrimEnd(), _Dtw_Item[24].ToString().TrimEnd(), _Dtw_Item[25].ToString().TrimEnd(), _Dtw_Item[26].ToString().TrimEnd(), _Dtw_Item[27].ToString().TrimEnd() });
                _Ob_ItemTemp = _Dtw_Item;
            }
            DataRow _Dtw_ItemTemp = (DataRow)_Ob_ItemTemp;
            for (int _Int_I = 6; _Int_I > _Ds.Tables[0].Rows.Count; _Int_I--)
            {
                _Dta_Tabla.Rows.Add(new object[] { _Dtw_ItemTemp[0].ToString().TrimEnd(), _Dtw_ItemTemp[1].ToString().TrimEnd(), _Dtw_ItemTemp[2].ToString().TrimEnd(), _Dtw_ItemTemp[3].ToString().TrimEnd(), _Dtw_ItemTemp[4].ToString().TrimEnd(), _Dtw_ItemTemp[5].ToString().TrimEnd(), _Dtw_ItemTemp[6].ToString().TrimEnd(), _Dtw_ItemTemp[7].ToString().TrimEnd(), _Dtw_ItemTemp[8].ToString().TrimEnd(), _Dtw_ItemTemp[9].ToString().TrimEnd(), _Dtw_ItemTemp[10].ToString().TrimEnd(), _Dtw_ItemTemp[11].ToString().TrimEnd(), _Dtw_ItemTemp[12].ToString().TrimEnd(), _Dtw_ItemTemp[13].ToString().TrimEnd(), _Dtw_ItemTemp[14].ToString().TrimEnd(), 0, 0, 0, 0, 0, 0, 0, 0, "", "", "","",0 });
            }
            return _Dta_Tabla;
        }
        private void _Mtd_Imprimir()
        {
            try
            {
                string _Str_Cadena = "select cimpresa,cidcomprob,cnumdocu,ccliente,ctipodocument from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text + "' and ccliente='" + _Txt_CodCliente.Text + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Ds2.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        PrintDialog _Print = new PrintDialog();
                    _PrintG:
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            _Txt_Clave.Text = "";
                            _Pnl_Clave.Visible = false;
                            Cursor = Cursors.WaitCursor;
                            //------------------ACTUALIACIÓN DE FECHA
                            _Str_Cadena = "Update TNOTADEBICC set cfecha='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            //------------------
                            REPORTESS _Frm = new REPORTESS("T3.Report.rEmisionND", _Dt_Table(_Txt_Cod.Text.Trim()), _Print, true, "Section2", "", "", "");
                            Cursor = Cursors.Default;
                            //_________________________________
                            int _Int_Id_Comprobante = new int();
                            Cursor = Cursors.WaitCursor;
                            CLASES._Cls_Varios_Metodos _Cls_Proceso = new T3.CLASES._Cls_Varios_Metodos(true);
                            _Str_Cadena = "Select cidcomprob from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            {
                                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() == "0")
                                {
                                    if (CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(_Txt_CodCliente.Text.Trim()))
                                    { _Int_Id_Comprobante = Convert.ToInt32(_Cls_Proceso._Mtd_Proceso_P_CXC_ND(_Txt_Cod.Text.Trim(), "P_CXC_ND_CIA_RELAC")); }
                                    else
                                    { _Int_Id_Comprobante = Convert.ToInt32(_Cls_Proceso._Mtd_Proceso_P_CXC_ND(_Txt_Cod.Text.Trim(), "P_CXC_ND")); }
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBICC", "cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'");
                                }
                                else
                                {
                                    _Int_Id_Comprobante = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                                }
                            }
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //_________________________________
                                MessageBox.Show("Se va a imprimir el comprobante contable.  Coloque el tipo de papel para este documento", "Requerimieno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor = Cursors.WaitCursor;
                                _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", _Print, true);
                                Cursor = Cursors.Default;
                                if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                A:
                                    string _Str_Numero = InputBox.Show("Introduzca el número de control").Text;
                                    if (_Str_Numero.Trim().Length > 0)
                                    {
                                        _Str_Cadena = "Select * from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cnumcontrolnd='" + _Str_Numero + "'";
                                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                                        {
                                            if (MessageBox.Show("El número de control del documento ya fue registrado. ¿Desea intentarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                goto A;
                                            }
                                        }
                                        else
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'");
                                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBICC", "cfvfnotadebitop='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cimpresa='1',cactivo='1',cnumcontrolnd ='" + _Str_Numero + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text + "' and ccliente='" + _Txt_CodCliente.Text + "'");
                                            Cursor = Cursors.Default;
                                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                            this.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Verifique la información y vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                _Frm.Close();
                                GC.Collect();
                                goto _PrintG;
                            }
                        }
                        else
                        {
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("La ND ya fue impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                        _Bt_Imprimir.Focus();
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        private string _Mtd_GerenteDeArea(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "Select cgerarea from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _P_Str_Vendedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }else
                {return "";}
            }else
            {return "";}
        }
        private bool _Mtd_VerificarMontos()
        {
            double _Dbl_Monto = 0;
            double _Dbl_Exento = 0;
            if (_Txt_Monto.Text.Trim().Length > 0) { _Dbl_Monto = Convert.ToDouble(_Txt_Monto.Text); }
            if (_Txt_Exento.Text.Trim().Length > 0) { _Dbl_Exento = Convert.ToDouble(_Txt_Exento.Text); }
            _Txt_Impuesto.Text = _Mtd_Impuesto(_Dbl_Monto).ToString("#,##0.00");
            _Txt_Total.Text = Convert.ToDouble(_Dbl_Monto + _Dbl_Exento + Convert.ToDouble(_Txt_Impuesto.Text)).ToString("#,##0.00");
            return Convert.ToDouble(_Txt_Total.Text) > 0;
        }
        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Motivo();
            this.Cursor = Cursors.Default;
        }

        private void Frm_NotaDebitoCxC_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_NotaDebitoCxC_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
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
        private void _Mtd_Dg_Grid_RowHeaderMouseDoubleClick(string _P_Str_Codigo,Form _P_Frm_Padre)
        {
            this.Cursor = Cursors.WaitCursor;
            _Er_Error.Dispose();
            bool _Bol_Manual = true;
            _Txt_Cod.Text = _P_Str_Codigo;
            int _Int_cestatusfirma = 0;
            string _Str_Cadena = "Select dbo.Fnc_Formatear(cmontototsi) as cmontototsi,ctipodocument,cnumdocu,convert(varchar,cfecha,103) as cfecha,cnumcontrolnd,cidmotivo,ccliente,dbo.Fnc_Formatear(cimpuesto) as cimpuesto,dbo.Fnc_Formatear(ctotaldocu) as ctotaldocu,cvendedor,calicuota,cexento,cmanual,cestatusfirma from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cmanual"].ToString().Trim() != "1")
                { _Bol_Manual = false; }
                _Txt_Control.Text = _Ds.Tables[0].Rows[0]["cnumcontrolnd"].ToString();
                _Txt_CodCliente.Text = _Ds.Tables[0].Rows[0]["ccliente"].ToString();
                _Txt_Fecha.Text = _Ds.Tables[0].Rows[0]["cfecha"].ToString();
                _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["cidmotivo"].ToString();
                _Txt_Document.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Txt_Document.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["calicuota"]);
                if (_Mtd_VerifContTextBoxNumeric(_Txt_Document))
                { _Rb_ConFact.Checked = true; }
                else
                { _Rb_SinFact.Checked = true; }
                _G_Str_Vendedor = _Ds.Tables[0].Rows[0]["cvendedor"].ToString();
                _Cmb_Vendedor.SelectedValue = _G_Str_Vendedor;
                _Txt_Monto.TextChanged -= new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["cmontototsi"].ToString();
                _Txt_Monto.TextChanged += new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Exento.TextChanged -= new EventHandler(_Txt_Exento_TextChanged);
                _Txt_Exento.Text = _Ds.Tables[0].Rows[0]["cexento"].ToString();
                _Txt_Exento.TextChanged += new EventHandler(_Txt_Exento_TextChanged);
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0]["cimpuesto"].ToString();
                _Txt_Total.Text = _Ds.Tables[0].Rows[0]["ctotaldocu"].ToString();
                if (_Ds.Tables[0].Rows[0]["cestatusfirma"] != System.DBNull.Value)
                {
                    if (_Ds.Tables[0].Rows[0]["cestatusfirma"].ToString().Trim().Length > 0)
                    { _Int_cestatusfirma = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cestatusfirma"]); }
                }
            }
            _G_Bol_Edit = false;
            _Str_Cadena = "Select c_nomb_comer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_DesCliente.Text = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "SELECT * FROM TNOTADEBICC WHERE cestatusfirma='2' AND cactivo=0 AND cimpresa=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Txt_Cod.Text + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
            {
                _Bt_Imprimir.Enabled = true;
            }
            else
            {
                _Bt_Imprimir.Enabled = false;
            }
            if (_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ND_CXC") & _Int_cestatusfirma == 1)
            {
                _Bt_Firmar.Visible = true;
                _Bt_Rechazar.Visible = _Bol_Manual;
            }
            else
            {
                _Bt_Firmar.Visible = false;
                _Bt_Rechazar.Visible = false;
            }
            _Mtd_Deshabilitar_Todo();
            this.Cursor = Cursors.Default;
            ((Frm_Padre)_P_Frm_Padre)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)_P_Frm_Padre)._Ctrl_Buscar1._Bt_editar2.Enabled = _G_Bol_Edit & !_Mtd_ND_Es_DPP(_Txt_Cod.Text.Trim());
            ((Frm_Padre)_P_Frm_Padre)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            _Tb_Tab.SelectedIndex = 1;
        }
        private void _Mtd_Dg_Grid_RowHeaderMouseDoubleClickTemp(string _P_Str_Codigo, Form _P_Frm_Padre)
        {
            this.Cursor = Cursors.WaitCursor;
            _Er_Error.Dispose();
            bool _Bol_Manual = true;
            _Txt_Cod.Text = _P_Str_Codigo;
            int _Int_cestatusfirma = 0;
            string _Str_Cadena = "Select dbo.Fnc_Formatear(cmontototsi) as cmontototsi,ctipodocument,cnumdocu,convert(varchar,cfecha,103) as cfecha,'' as cnumcontrolnd,cidmotivo,ccliente,dbo.Fnc_Formatear(cimpuesto) as cimpuesto,dbo.Fnc_Formatear(ctotaldocu) as ctotaldocu,cvendedor,calicuota,cexento,cestatusfirma from TNOTADEBICCTEMP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocctemp='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {                
                _Txt_Control.Text = _Ds.Tables[0].Rows[0]["cnumcontrolnd"].ToString();
                _Txt_CodCliente.Text = _Ds.Tables[0].Rows[0]["ccliente"].ToString();
                _Txt_Fecha.Text = _Ds.Tables[0].Rows[0]["cfecha"].ToString();
                _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["cidmotivo"].ToString();
                _Txt_Document.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Txt_Document.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["calicuota"]);
                if (_Mtd_VerifContTextBoxNumeric(_Txt_Document))
                { _Rb_ConFact.Checked = true; }
                else
                { _Rb_SinFact.Checked = true; }
                _G_Str_Vendedor = _Ds.Tables[0].Rows[0]["cvendedor"].ToString();
                _Cmb_Vendedor.SelectedValue = _G_Str_Vendedor;
                _Txt_Monto.TextChanged -= new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["cmontototsi"].ToString();
                _Txt_Monto.TextChanged += new EventHandler(_Txt_Monto_TextChanged);
                _Txt_Exento.TextChanged -= new EventHandler(_Txt_Exento_TextChanged);
                _Txt_Exento.Text = _Ds.Tables[0].Rows[0]["cexento"].ToString();
                _Txt_Exento.TextChanged += new EventHandler(_Txt_Exento_TextChanged);
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0]["cimpuesto"].ToString();
                _Txt_Total.Text = _Ds.Tables[0].Rows[0]["ctotaldocu"].ToString();
                if (_Ds.Tables[0].Rows[0]["cestatusfirma"] != System.DBNull.Value)
                {
                    if (_Ds.Tables[0].Rows[0]["cestatusfirma"].ToString().Trim().Length > 0)
                    { _Int_cestatusfirma = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cestatusfirma"]); }
                }
            }
            _Str_Cadena = "SELECT * FROM TNOTADEBICCTEMP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocctemp='" + _P_Str_Codigo + "' AND (cestatusfirma=1)";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
            {
                _G_Bol_Edit = true;
            }
            else
            {
                _G_Bol_Edit = false;
            }
            _Str_Cadena = "Select c_nomb_comer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_DesCliente.Text = _Ds.Tables[0].Rows[0][0].ToString();
            }            
            if (_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_ND_CXC") & _Int_cestatusfirma == 1)
            {
                _Bt_Firmar.Visible = true;
                _Bt_Rechazar.Visible = _Bol_Manual;
            }
            else
            {
                _Bt_Firmar.Visible = false;
                _Bt_Rechazar.Visible = false;
            }
            _Mtd_Deshabilitar_Todo();
            this.Cursor = Cursors.Default;
            ((Frm_Padre)_P_Frm_Padre)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)_P_Frm_Padre)._Ctrl_Buscar1._Bt_editar2.Enabled = _G_Bol_Edit & !_Mtd_ND_Es_DPP(_Txt_Cod.Text.Trim());
            ((Frm_Padre)_P_Frm_Padre)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            _Tb_Tab.SelectedIndex = 1;
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                if (_Rb_Rechazada.Checked || (_Rb_NoAplicada.Checked && _Chk_FindAprob.Checked))
                {
                    _Mtd_Dg_Grid_RowHeaderMouseDoubleClickTemp(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), this.MdiParent);
                }
                else
                {
                    _Mtd_Dg_Grid_RowHeaderMouseDoubleClick(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), this.MdiParent);
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Cliente_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Er_Error.Dispose();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
            _Frm.ShowDialog(this);
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_CodCliente.Text = _Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Frm._Dg_Grid.CurrentCell.RowIndex);
                _Txt_DesCliente.Text = _Frm._Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, _Frm._Dg_Grid.CurrentCell.RowIndex);
                _Mtd_Cargar_Motivo();
                _Cmb_Motivo.Enabled = true;
            }
            this.Cursor = Cursors.Default;
        }

        private void _Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            _Mtd_VerificarMontos();
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            {
                _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim();
                _Bt_Descrip.Enabled = true;
                _Rb_ConFact.Enabled = true;
                _Rb_SinFact.Enabled = true;
                if (_Rb_ConFact.Checked)
                {
                    _Bt_FindDoc.Enabled = true;
                }
                else
                { _Cmb_Vendedor.Enabled = true; }
            }
            else
            {
                _Mtd_CargarVendedores();
                _Txt_Descripcion.Text = "";
                _Bt_FindDoc.Enabled = false;
                _Bt_Descrip.Enabled = false;
                _Rb_ConFact.Enabled = false;
                _Rb_SinFact.Enabled = false;
                _Cmb_Vendedor.Enabled = false;
                _Txt_Monto.Enabled = false;
                _Txt_Monto.Text = "";
                _Txt_Monto.Text = "";
                _Txt_Document.Text = "";
            }
        }

        private void _Txt_Document_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Document.Text))
            {
                _Txt_Document.Text = "";
                if (_Cmb_Motivo.SelectedIndex != -1)
                {
                    _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim();
                }
                else
                {
                    _Txt_Descripcion.Text = "";
                }
            }
            else
            {
                if (_Cmb_Motivo.SelectedIndex != -1 & _Txt_Document.Text.Trim().Length > 0)
                {
                    _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim() + " FACTURA# " + _Txt_Document.Text;
                }
                else if (_Cmb_Motivo.SelectedIndex != -1)
                {
                    _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim();
                }
                else
                {
                    _Txt_Descripcion.Text = "";
                }
            }
        }

        private void _Txt_Document_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false; }
            else
            { _Tb_Tab.Enabled = true; ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = _Str_MyProceso == "A" | _Str_MyProceso == "M"; }
        }
        private bool _Mtd_ND_AntPorImprimir(string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cdelete='0' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimpresa='0' AND cactivo='0' AND cestatusfirma=2 AND cidnotadebitocc<" + _P_Str_Documento;
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de imprimir la ND# " + _Txt_Cod.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_Mtd_ND_AntPorImprimir(_Txt_Cod.Text.Trim()))
                { MessageBox.Show("Existen ND por imprimir anteriores a la seleccionada. Debe imprimir las ND en orden descendente.\nPor favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Focus();
                }
            }
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Str_MyProceso == "A" | _Str_MyProceso == "M")
                {
                    if (CONTROLES._Ctrl_Buscar._Bl_Modifi)
                    {
                        if (_Mtd_Editar())
                        {
                            _Tb_Tab.SelectTab(0);
                            _Mtd_BotonesMenu();
                        }
                    }
                    else
                    {
                        if (_Mtd_Guardar())
                        {
                            _Tb_Tab.SelectTab(0);
                            _Mtd_BotonesMenu();
                        }
                    }
                    _Pnl_Clave.Visible = false;
                }
                else if (_Str_MyProceso == "F2")
                {
                    Cursor = Cursors.WaitCursor;
                    //Se inserta la nota de crédito por aprobar si no existe.
                    DataSet _Ds_DataSet = new DataSet();
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidnotadebitocc FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "'");
                    if (_Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim().Length == 0)
                    {
                        int _Int_IdNotFinal = _Mtd_Entrada();
                        string _Str_Sql = "EXEC PA_INSERTARNDTEMPAFINAL '" + _Txt_Cod.Text + "','" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Int_IdNotFinal + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);                        
                    }
                    else
                    {
                        int _Int_IdNotFinal = Convert.ToInt32(_Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim());
                        string _Str_Sql = "UPDATE TNOTADEBICC SET cestatusfirma=2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc=" + _Int_IdNotFinal + "";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "UPDATE TNOTADEBICCTEMP SET cestatusfirma=2,cidnotadebitocc=" + _Int_IdNotFinal + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }                   
                    Cursor = Cursors.Default;
                    MessageBox.Show("Nota de débito aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Pnl_Clave.Visible = false;
                    _Tb_Tab.SelectTab(0);
                    _Mtd_BotonesMenu();
                }
                else if (_Str_MyProceso == "R")
                {
                    if (Application.OpenForms["Frm_ImpresionLote"] == null)
                    {
                        DataSet _Ds_DataSet = new DataSet();
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidnotadebitocc FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "'");
                        if (_Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim().Length == 0)
                        {
                            string _Str_Sql = "SELECT cestatusfirma FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "' AND cestatusfirma='2'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("No se puede rechazar la Nota de Débito porque ya ha sido aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                _Str_Sql = "UPDATE TNOTADEBICCTEMP SET cestatusfirma='9' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                Cursor = Cursors.Default;
                                MessageBox.Show("Nota de débito rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            string _Str_Sql = "SELECT cestatusfirma FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "' AND cestatusfirma='2'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("No se puede rechazar la Nota de Débito porque ya ha sido aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                int _Int_IdNotFinal = Convert.ToInt32(_Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim());
                                _Str_Sql = "UPDATE TNOTADEBICCTEMP SET cestatusfirma='9' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocctemp='" + _Txt_Cod.Text + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "UPDATE TNOTADEBICC SET cestatusfirma='9' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Int_IdNotFinal + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                Cursor = Cursors.Default;
                                MessageBox.Show("Nota de débito rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }                        
                        _Mtd_Actualizar();
                        _Pnl_Clave.Visible = false;
                        _Tb_Tab.SelectTab(0);
                        _Mtd_BotonesMenu();
                    }
                    else
                    {
                        MessageBox.Show("Debe cerrar el formulario de Impresión en Lote para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    _Mtd_Imprimir();
                }
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Txt_Clave.Focus();
                _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Txt_Monto_Enter(object sender, EventArgs e)
        {
            _Txt_Monto.SelectAll();
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Bt_Cliente.Enabled & _Txt_CodCliente.Text.Trim().Length == 0 & e.TabPageIndex != 0)
            { e.Cancel = true; }
            else if (e.TabPageIndex == 0)
            {
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Mtd_BotonesMenu();
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

        private void _Rb_Aplicada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Aplicada.Checked)
            {
                _Chk_FindAprob.CheckedChanged -= new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Checked = false;
                _Chk_FindAprob.CheckedChanged += new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                this.Cursor = Cursors.Default;
            }
        }

        private void _Rb_NoAplicada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_NoAplicada.Checked)
            {
                _Chk_FindAprob.CheckedChanged -= new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Checked = false;
                _Chk_FindAprob.CheckedChanged += new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Enabled = true;
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                this.Cursor = Cursors.Default;
            }
        }

        private void _Rb_Rechazada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Rechazada.Checked)
            {
                _Chk_FindAprob.CheckedChanged -= new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Checked = false;
                _Chk_FindAprob.CheckedChanged += new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Enabled = false;
                _Mtd_Actualizar();
            }
        }
        private void _Chk_FindAprob_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Firmar_Click(object sender, EventArgs e)
        {
            _Str_MyProceso = "F2";
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Focus();
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_Cod.Text.Trim().Length > 0 && _Bt_Cliente.Enabled)
                {
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else if (_Txt_Cod.Text.Trim().Length > 0 && !_Bt_Cliente.Enabled)
                {
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _G_Bol_Edit;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else if (_Txt_Cod.Text.Trim().Length == 0 && !_Bt_Cliente.Enabled)
                {
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXC"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }

        private void _Rb_SinFact_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFact.Checked)
            {
                _Er_Error.Dispose();
                _Mtd_CargarVendedores();
                _Txt_Document.Text = "";
                _Txt_Document.Enabled = false;
                _Bt_FindDoc.Enabled = false;
                _Cmb_Vendedor.Enabled = true;
            }
        }

        private void _Rb_ConFact_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_ConFact.Checked)
            {
                _Mtd_CargarVendedores();
                _Cmb_Vendedor.Enabled = false;
                _Txt_Document.Text = "";
                _Bt_FindDoc.Enabled = true;
            }
        }

        private void _Bt_FindDoc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            TextBox _Txt_TemporalCod = new TextBox();
            TextBox _Txt_TemporalCliente = new TextBox();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(28, " AND ccliente='" + _Txt_CodCliente.Text + "'");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult.Length > 0)
            {
                _Txt_Document.Text = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                if (_Frm._Dg_Grid[5, _Frm._Dg_Grid.CurrentCell.RowIndex].Value == null)
                { _Txt_Document.Tag = 0; }
                else if (_Frm._Dg_Grid[5, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().Trim().Length == 0)
                { _Txt_Document.Tag = 0; }
                else
                { _Txt_Document.Tag = _Frm._Dg_Grid[5, _Frm._Dg_Grid.CurrentCell.RowIndex].Value; }
                _G_Str_Vendedor = _Frm._Dg_Grid[4, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                _Txt_Monto.Text = ""; _Txt_Exento.Text = "";
                if (_Mtd_MotivoDPP(Convert.ToString(_Cmb_Motivo.SelectedValue).Trim()))
                {
                    _Txt_Monto.Enabled = false;
                    _Mtd_ObtenerMontos(_Txt_Document.Text);
                }
                else
                { _Txt_Monto.Enabled = true; }
                _Txt_Monto.Focus();
            }
            _Frm.Dispose();
        }

        private void _Txt_Document_Validating(object sender, CancelEventArgs e)
        {
            if (_Txt_Document.Text.Length > 0)
            {
                string _Str_Mensaje = _Mtd_ValidarFactura(_Txt_Document.Text);
                if (_Str_Mensaje.Length > 0)
                {
                    MessageBox.Show(_Str_Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }

        private void Frm_NotaDebitoCxC_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Descrip_Click(object sender, EventArgs e)
        {
            _Txt_Descripcion.Enabled = !_Txt_Descripcion.Enabled;
            _Txt_Descripcion.Focus();
        }

        private void _Cmb_Vendedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarVendedores();
        }

        private void _Cmb_Vendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Vendedor.SelectedIndex > 0)
            { _Txt_Monto.Enabled = !_Mtd_MotivoDPP(Convert.ToString(_Cmb_Motivo.SelectedValue).Trim()); }
            else
            { _Txt_Monto.Enabled = false; }
            _Txt_Monto.Text = ""; _Txt_Exento.Text = "";
        }

        private void _Txt_Exento_Enter(object sender, EventArgs e)
        {
            _Txt_Exento.SelectAll();
        }

        private void _Txt_Exento_TextChanged(object sender, EventArgs e)
        {
            _Mtd_VerificarMontos();
        }

        private void _Txt_Monto_EnabledChanged(object sender, EventArgs e)
        {
            _Txt_Exento.Enabled = _Txt_Monto.Enabled;
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            _Str_MyProceso = "R";
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Focus();
        }

        private void _Bt_Detalle_Click(object sender, EventArgs e)
        {

        }
    }
}