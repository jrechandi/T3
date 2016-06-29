using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Busqueda2 : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Busqueda2()
        {
            InitializeComponent();
        }
        int _Int_Sw = 0;
        TextBox _Txt_Textbox1;
        TextBox _Txt_Textbox2;
        TextBox _Txt_Textbox3;
        int _Int_Col_Index1 = 0;
        int _Int_Col_Index2 = 0;
        int _Int_Col_Index3 = 0;
        string _Str_Param1 = "";
        string _Str_Param2 = "";
        public string _Str_FrmResult = "";
        public string[,] _Str_RutasPrefacturas;
        public string[] _G_Str_Resultados;

        public Frm_Busqueda2(int _P_Int_Sw, string _P_Str_Param1)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            if (_P_Int_Sw == 25)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw25();
                this.Text = "Consulta de Productos";
            }
            else if (_P_Int_Sw == 28)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw28();
                this.Text = "Consulta de Facturas";
            }
            else if (_P_Int_Sw == 40)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw40();
                this.Text = "FACTURAS COMPRAS";
            }
            else if (_P_Int_Sw == 44)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw44(); this.Text = "ZONAS SIN CUOTAS";
            }
            else if (_P_Int_Sw == 57)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw57(); this.Text = "FÓRMULAS";
            }
            else if (_P_Int_Sw == 81)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw81();
                this.Text = "MERCANCÍA EN MAL ESTADO";
            }
        }
        /// <summary>
        /// Primer Constructor del formulario.
        /// </summary>
        /// <param name="_P_Int_Sw">switch que representa el trabajo a realizar del formulario</param>
        public Frm_Busqueda2(int _P_Int_Sw)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            if (_P_Int_Sw == 1)
            { _Mtd_Actualizar_Sw1(); this.Text = "ZONAS SIN RUTAS"; }
            else if (_P_Int_Sw == 2)
            { _Mtd_Actualizar_Sw2(); this.Text = "EVALUACIONES POR IMPRIMIR"; _Ctrl_Busqueda1.Visible = false; }
            else if (_P_Int_Sw == 3)
            { _Mtd_Actualizar_Sw3(); this.Text = "CATEGORÍA DEL PROVEEDOR"; _Rbt_Ser.Visible = true; _Rbt_Mat.Visible = true; _Rbt_Otros.Visible = true; }
            else if (_P_Int_Sw == 4)
            { _Mtd_Actualizar_Sw4(); this.Text = "RETENCIONES IVA"; this.Size = new Size(400, 350); }
            else if (_P_Int_Sw == 5)
            { _Mtd_Actualizar_Sw5(); this.Text = "COMPARATIVO FÍSICO vs TEÓRICO"; }
            else if (_P_Int_Sw == 6)
            { _Mtd_Actualizar_Sw6(); this.Text = "RETENCIONES ISLR"; }
            else if (_P_Int_Sw == 8)
            { _Mtd_Actualizar_Sw8(); this.Text = "PROVEEDORES CON MERCANCIA EN MAL ESTADO"; _Dg_Grid.ContextMenuStrip = _Ctrl_Contex; }
            else if (_P_Int_Sw == 10)
            { _Mtd_Actualizar_Sw10(); this.Text = "CONSULTA DE MOTIVOS"; }
            else if (_P_Int_Sw == 11)
            { _Mtd_Actualizar_Sw11(); this.Text = "CONSULTA DE LÍMITES DE CRÉDITO"; }
            else if (_P_Int_Sw == 17)
            { _Mtd_Actualizar_Sw17(); this.Text = "FACTURAS IMPRESAS"; }
            else if (_P_Int_Sw == 19)
            { _Mtd_Actualizar_Sw19(); this.Text = "N.D. POR IMPRIMIR - PROVEEDORES"; }
            else if (_P_Int_Sw == 20)
            { _Mtd_Actualizar_Sw20(); this.Text = "N.C. POR IMPRIMIR - PROVEEDORES"; }
            else if (_P_Int_Sw == 23)
            { _Mtd_Actualizar_Sw23(); this.Text = "CAJA PENDIENTE POR CERRAR"; }
            else if (_P_Int_Sw == 24)
            { _Mtd_Actualizar_Sw24(); this.Text = "CONSULTA DE FACTURAS"; }
            else if (_P_Int_Sw == 26)
            { _Mtd_Actualizar_Sw26(); this.Text = "CLIENTES SIN ENRUTAR"; }
            else if (_P_Int_Sw == 30)
            { _Mtd_Actualizar_Sw30(); this.Text = "N.C. GENERADAS EN EL CIERRE DE CAJA"; }
            else if (_P_Int_Sw == 31)
            { _Mtd_Actualizar_Sw31(); this.Text = "AJUSTE POR CONTEO DE INVENTARIO"; }
            else if (_P_Int_Sw == 32)
            { _Mtd_Actualizar_Sw32(); this.Text = "CLIENTES"; }
            else if (_P_Int_Sw == 33)
            { _Mtd_Actualizar_Sw33(); this.Text = "PROVEEDORES MATERIA PRIMA"; }
            else if (_P_Int_Sw == 34)
            { _Mtd_Actualizar_Sw34(); this.Text = "PROVEEDORES DE SERVICIO"; }
            else if (_P_Int_Sw == 35)
            { _Mtd_Actualizar_Sw35(); this.Text = "PROVEEDORES OTROS"; }
            else if (_P_Int_Sw == 36)
            { _Mtd_Actualizar_Sw36(); this.Text = "EMPLEADOS"; }
            else if (_P_Int_Sw == 37)
            { _Mtd_Actualizar_Sw37(); this.Text = "BANCO"; }
            else if (_P_Int_Sw == 38)
            { _Mtd_Actualizar_Sw38(); this.Text = "AUXILIARES CONTABLES"; }
            else if (_P_Int_Sw == 39)
            { _Mtd_Actualizar_Sw39(); this.Text = "PROVEEDORES"; }
            else if (_P_Int_Sw == 41)
            { _Mtd_Actualizar_Sw41(); this.Text = "FACTURAS DEVUELTAS"; _Dg_Grid.ContextMenuStrip = _Ctrl_Context3; }
            else if (_P_Int_Sw == 42)
            { _Mtd_Actualizar_Sw42(); this.Text = "CLIENTES CASA MATRIZ"; }
            else if (_P_Int_Sw == 43)
            { _Mtd_Actualizar_Sw43(); this.Text = "BACKORDER BLOQUEADOS POR CRÉDITO"; }
            else if (_P_Int_Sw == 46)
            { _Mtd_Actualizar_Sw46(); this.Text = "COMPROBANTES INCOMPLETOS"; }
            else if (_P_Int_Sw == 47)
            { _Mtd_Actualizar_Sw47(); this.Text = "COMPROBANTES INCOMPLETOS"; }
            else if (_P_Int_Sw == 48)
            { _Mtd_Actualizar_Sw48(); this.Text = "COMPROBANTES POR APROBAR"; }
            else if (_P_Int_Sw == 49)
            { _Mtd_Actualizar_Sw49(); this.Text = "CIERRE CONTABLE PENDIENTE"; }
            else if (_P_Int_Sw == 53)
            { _Mtd_Actualizar_Sw53(); this.Text = "N.C. EXCEDENTE POR IMPRIMIR"; }
            else if (_P_Int_Sw == 58)
            { _Mtd_Actualizar_Sw58(); this.Text = "GUÍA CON DEVOLUCIONES PARCIALES"; }
            else if (_P_Int_Sw == 60)
            { _Mtd_Actualizar_Sw60(); this.Text = "COMPROBANTES DE CHEQUE POR IMPRIMIR"; }
            else if (_P_Int_Sw == 61)
            { _Mtd_Actualizar_Sw61(); this.Text = "PRODUCTOS - COSTO BRUTO MENOR A COSTO NETO"; }
            else if (_P_Int_Sw == 62)
            { _Mtd_Actualizar_Sw62(); this.Text = "EGRE-CHEQ-TRANS POR IMPRIMIR SEGÚN CAJA"; }
            else if (_P_Int_Sw == 63)
            { _Mtd_Actualizar_Sw63(); this.Text = "NOTAS DE RECEPCIÓN POR GENERAR"; }
            else if (_P_Int_Sw == 73)
            { _Mtd_Actualizar_Sw73(); this.Text = "COMPROBANTES DE ANTICIPOS POR IMPRIMIR"; }
            else if (_P_Int_Sw == 77)
            { _Mtd_Actualizar_Sw77(); this.Text = "CLIENTES ZONIFICADOS"; }
            else if (_P_Int_Sw == 78)
            { _Mtd_Actualizar_Sw78(); this.Text = "CLIENTES ENRUTADOS"; }
            else if (_P_Int_Sw == 82)
            { _Mtd_Actualizar_Sw82(); this.Text = "PRODUCTOS POR VENCER"; }
            else if (_P_Int_Sw == 83)
            { _Mtd_Actualizar_Sw83(); this.Text = "RECEPCIONES DE TRANSPORTE"; }
            else if (_P_Int_Sw == 84)
            { _Mtd_Actualizar_Sw84(); this.Text = "RECEPCIONES POR VERIFICAR"; }
            else if (_P_Int_Sw == 85)
            { _Mtd_Actualizar_Sw85(); this.Text = "RECEPCIONES MAL CARGADAS"; }
            else if (_P_Int_Sw == 86)
            { _Mtd_Actualizar_Sw86(); this.Text = "RECEPCIONES APROBADAS"; }
            else if (_P_Int_Sw == 89)
            { _Mtd_Actualizar_Sw89(); this.Text = "N.C. INTERCOMPAÑÍAS POR IMPRIMIR"; }
            else if (_P_Int_Sw == 90)
            { _Mtd_Actualizar_Sw90(); this.Text = "N.D. INTERCOMPAÑÍAS POR IMPRIMIR"; }
            else if (_P_Int_Sw == 94)
            { _Mtd_Actualizar_Sw94(); this.Text = "CLIENTES INTERCOMPAÑIA"; }
            else if (_P_Int_Sw == 95)
            { _Mtd_Actualizar_Sw95(); this.Text = "PROVEEDORES INTERCOMPAÑIA"; }
            else if (_P_Int_Sw == 97)
            { _Mtd_Actualizar_Sw97(); this.Text = "APROBACIÓN DE CONC. MANUALES TERMINADAS"; }
            else if (_P_Int_Sw == 98)
            { _Mtd_Actualizar_Sw98(); this.Text = "CONCILIACIONES MANUALES POR APROBAR"; }
            else if (_P_Int_Sw == 101)
            { _Mtd_Actualizar_Sw101(); this.Text = "CONCILIACIONES PENDIENTES"; }
            else if (_P_Int_Sw == 102)
            { _Mtd_Actualizar_Sw102(); this.Text = "RETENCIONES ISLR MANUALES"; }
            else if (_P_Int_Sw == 103)
            { _Mtd_Actualizar_Sw103(); this.Text = "RETENCIONES IVA MANUALES"; }
            else if (_P_Int_Sw == 104)
            { _Mtd_Actualizar_Sw104(); this.Text = "RETENCIONES PATENTE MANUALES"; }
        }
        /// <summary>
        /// Segundo Constructor del formulario.
        /// </summary>
        /// <param name="_P_Int_Sw">switch que representa el trabajo a realizar del formulario</param>
        /// <param name="_P_Txt_Texbox1">Control que tomará el valor del campo ubicado en la primera posición especificada del registro seleccionado</param>
        /// <param name="_P_Txt_Texbox2">Control que tomará el valor del campo ubicado en la segunda posición especificada del registro seleccionado</param>
        /// <param name="_P_Int_Col_Index1">Primera posición del campo en el registro seleccionado</param>
        /// <param name="_P_Int_Col_Index2">Segunda posición del campo en el registro seleccionado</param>
        /// <param name="_P_Str_Param1">Criterio que se le anexará a la consulta</param>
        public Frm_Busqueda2(int _P_Int_Sw, TextBox _P_Txt_Texbox1, TextBox _P_Txt_Texbox2, int _P_Int_Col_Index1, int _P_Int_Col_Index2, string _P_Str_Param1)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            _Txt_Textbox1 = _P_Txt_Texbox1;
            _Txt_Textbox2 = _P_Txt_Texbox2;
            _Int_Col_Index1 = _P_Int_Col_Index1;
            _Int_Col_Index2 = _P_Int_Col_Index2;
            _Str_Param1 = _P_Str_Param1;
            if (_P_Int_Sw == 7)
            { _Mtd_Actualizar_Sw7(); this.Text = "Consulta"; _Dg_Grid.ContextMenuStrip = _Ctrl_Contex; }
            if (_P_Int_Sw == 9)
            {
                _Mtd_Actualizar_Sw9(_P_Str_Param1); this.Text = "Consulta";
            }
            else if (_P_Int_Sw == 12)
            { _Mtd_Actualizar_Sw12(); this.Text = "CONSULTA DE USUARIOS"; }
            else if (_P_Int_Sw == 13)
            { _Mtd_Actualizar_Sw13(); this.Text = "TRANSPORTES DISPONIBLES"; }
            else if (_P_Int_Sw == 14)
            { _Mtd_Actualizar_Sw14(); this.Text = "TRANSPORTISTAS"; }
            else if (_P_Int_Sw == 15)
            { _Mtd_Actualizar_Sw15(); this.Text = "RUTAS SEGÚN PRE-FACTURAS"; _Dg_Grid.ContextMenuStrip = _Ctrl_Contex1; _Ctrl_Contex1_MItem1.Text = "Enviar a Prefactura"; }
            else if (_P_Int_Sw == 16)
            { _Mtd_Actualizar_Sw16(); _Int_Sw = 16; this.Text = "PRE-FACTURAS"; _Dg_Grid.ContextMenuStrip = _Ctrl_Contex1; _Ctrl_Contex1_MItem1.Text = "Enviar a Prefactura"; _Lbl_DgInfo.Text = "Use: doble click, botón derecho"; _Tol_Txt_Ver.Visible = true; }
            else if (_P_Int_Sw == 18)
            { _Mtd_Actualizar_Sw18(); this.Text = "CONSULTA DE CLIENTES"; }
            else if (_P_Int_Sw == 22)
            { _Mtd_Actualizar_Sw22(); this.Text = "CONSULTA DE FACTURAS"; }
            else if (_P_Int_Sw == 27)
            { _Mtd_Actualizar_Sw27(); this.Text = "CONSULTA DE FACTURAS"; }
            else if (_P_Int_Sw == 29)
            { _Mtd_Actualizar_Sw29(); this.Text = "CONSULTA DE CLIENTES"; }
        }
        public Frm_Busqueda2(int _P_Int_Sw, TextBox _P_Txt_Texbox1, TextBox _P_Txt_Texbox2, TextBox _P_Txt_Texbox3, int _P_Int_Col_Index1, int _P_Int_Col_Index2, int _P_Int_Col_Index3, string _P_Str_Param1)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            _Txt_Textbox1 = _P_Txt_Texbox1;
            _Txt_Textbox2 = _P_Txt_Texbox2;
            _Txt_Textbox3 = _P_Txt_Texbox3;
            _Int_Col_Index1 = _P_Int_Col_Index1;
            _Int_Col_Index2 = _P_Int_Col_Index2;
            _Int_Col_Index3 = _P_Int_Col_Index3;
            _Str_Param1 = _P_Str_Param1;

        }
        public Frm_Busqueda2(int _P_Int_Sw, TextBox _P_Txt_Texbox1, int _P_Int_Col_Index1, string _P_Str_Param1)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            _Txt_Textbox1 = _P_Txt_Texbox1;
            _Int_Col_Index1 = _P_Int_Col_Index1;
            _Str_Param1 = _P_Str_Param1;
            if (_P_Int_Sw == 21)
            {
                _Mtd_Actualizar_Sw21(); this.Text = "Relaciones de cobranza"; this.Size = new Size(500, 300);
            }
            if (_P_Int_Sw == 42)
            {
                _Mtd_Actualizar_Sw42(); this.Text = "CLIENTES CASA MATRIZ"; this.Size = new Size(550, 300);
            }
            if (_P_Int_Sw == 45)
            { _Mtd_Actualizar_Sw45(); this.Text = "CUENTAS"; this.Size = new Size(550, 300); }
            if (_P_Int_Sw == 50)
            { _Mtd_Actualizar_Sw50(); this.Text = "PROVEEDORES"; }
            if (_P_Int_Sw == 51)
            {
                _Mtd_Actualizar_Sw51();

                string _Str_Cadena = "SELECT cname FROM TDOCUMENT WHERE ctdocument='" + _P_Str_Param1 + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    this.Text = "CONSULTA DE " + _Ds.Tables[0].Rows[0][0].ToString().ToLower().Trim() + " (CxP)";
                }
                this.Size = new Size(1100, 300);
            }
            if (_P_Int_Sw == 52)
            {
                _Mtd_Actualizar_Sw52(); this.Text = "CONSULTA DE CAJAS CXC"; this.Size = new Size(550, 300);
            }
            if (_P_Int_Sw == 54)
            {
                _Mtd_Actualizar_Sw54(); this.Text = "PROCESOS CONTABLES"; this.Size = new Size(550, 300);
            }
            if (_P_Int_Sw == 55)
            {
                _Mtd_Actualizar_Sw55(); this.Text = "GERENTES DE ÁREA";
            }
            if (_P_Int_Sw == 56)
            {
                _Mtd_Actualizar_Sw56(); this.Text = "IMPUESTOS"; this.Size = new Size(463, 286);
            }
            else if (_P_Int_Sw == 59)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw59(); this.Text = "CLIENTES";
            }
            else if (_P_Int_Sw == 64)
            {
                _Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw64(); this.Text = "CLIENTES";
            }
            else if (_P_Int_Sw == 65)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw65(); this.Text = "RUTAS";
            }
            else if (_P_Int_Sw == 66)
            {
                _Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw66(); this.Text = "TRANSPORTISTAS";
            }
            else if (_P_Int_Sw == 67)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw67(); this.Text = "PEDIDOS";
            }
            else if (_P_Int_Sw == 68)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw68(); this.Text = "FACTURAS";
            }
            else if (_P_Int_Sw == 69)
            {
                _Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw69(); this.Text = "VENDEDORES";
            }
            else if (_P_Int_Sw == 70) // pedidos con inner join a clientes y a vendedores
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw70(); this.Text = "PEDIDOS";
            }
            else if (_P_Int_Sw == 71) // guias
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw71(); this.Text = "GUIAS";
            }
            else if (_P_Int_Sw == 72) // placas 
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw72(); this.Text = "PLACAS";
            }
            else if (_P_Int_Sw == 74)
            {
                _Mtd_Actualizar_Sw74(); this.Text = "CUENTAS"; this.Size = new Size(550, 300);
            }
            else if (_P_Int_Sw == 75)
            {
                _Mtd_Actualizar_Sw75(); this.Text = "CLIENTES";
            }
            else if (_P_Int_Sw == 76)
            {
                _Mtd_Actualizar_Sw76(); this.Text = "BANCOS";
            }
            else if (_P_Int_Sw == 79)
            {
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw79(); this.Text = "ZONAS";
            }
            else if (_P_Int_Sw == 87)
            {
                _Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw87(); this.Text = "TRANSPORTISTAS";
            }
            else if (_P_Int_Sw == 88)
            {
                _Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw88(); this.Text = "RANGOS";
            }
            else if (_P_Int_Sw == 93)
            {
                _Mtd_Actualizar_Sw93(); this.Text = "CUENTAS"; this.Size = new Size(550, 300);
            }
            else if (_P_Int_Sw == 95)
            { 
                _Mtd_Actualizar_Sw95(); this.Text = "PROVEEDORES INTERCOMPAÑIA"; 
            }
            else if (_P_Int_Sw == 96)
            {
                _Mtd_Actualizar_Sw96(); this.Text = "PRODUCTOS";
            }
            else if (_P_Int_Sw == 99)
            {
                _Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw99(); this.Text = "VENDEDORES";
            }
            else if (_P_Int_Sw == 102)
            {
                //_Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw102(); this.Text = "RETENCIONES ISLR MANUALES";
            }
            else if (_P_Int_Sw == 103)
            {
                //_Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw103(); this.Text = "RETENCIONES IVA MANUALES";
            }
            else if (_P_Int_Sw == 104)
            {
                //_Pnl_Filtro.Visible = true;
                _Str_Param1 = _P_Str_Param1;
                _Mtd_Actualizar_Sw104(); this.Text = "RETENCIONES PATENTE MANUALES";
            }
        }

        /*
         *  Constructor para la generación de orden de pago intercompañía.
         */

        public Frm_Busqueda2(string _P_Str_Proveedor)
        {
            string _Str_Cadena;
            string[] _Str_Campos = new string[2];

            ToolStripMenuItem[] _Tsm_Menu;

            _Int_Sw = 100;

            _Str_Campos[0] = "cnumdocu";
            _Str_Campos[1] = "ctipo";

            _Str_Cadena = "SELECT cnumdocu, convert(VARCHAR,cfechaemision,103) ascfechaemision, convert(VARCHAR,cfechavencimiento,103) as cfechavencimiento, dbo.Fnc_Formatear(CASE WHEN ctipo IN('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO CXC') THEN cmonto ELSE -1*cmonto END) as cmonto, ctipo";
            _Str_Cadena += " FROM VST_CONSOLIDADO_INTERCOMPANIAS";
            _Str_Cadena += " WHERE ccompany = '" + Frm_Padre._Str_Comp + "'";
            _Str_Cadena += " AND canulado = 0";
            _Str_Cadena += " AND cimpreso = 1";
            _Str_Cadena += " AND cestado = 0 ";
            _Str_Cadena += " AND cproveedor = '" + _P_Str_Proveedor + "' ";
            _Str_Cadena += " AND csaldo <> 0 ";

            _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Número documento");
            _Tsm_Menu[1] = new ToolStripMenuItem("Tipo documento");

            InitializeComponent();

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "DOCUMENTOS INTERCOMPAÑÍAS", _Tsm_Menu, _Dg_Grid, false,"");
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "DOCUMENTOS INTERCOMPAÑÍAS", _Tsm_Menu, _Dg_Grid, "");

            Text = "DOCUMENTOS INTERCOMPAÑÍAS";

            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            _Dg_Grid.Columns[0].HeaderText = "N° de documento";
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[0].Width = 100;
            _Dg_Grid.Columns[1].HeaderText = "Fecha de emsión";
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[1].Width = 100;
            _Dg_Grid.Columns[2].HeaderText = "Fecha de vencimiento";
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[2].Width = 120;
            _Dg_Grid.Columns[3].HeaderText = "Monto";
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].Width = 100;
            _Dg_Grid.Columns[4].HeaderText = "Tipo de documento";
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Grid.Columns[4].Width = 300;
        }

        private void _Mtd_Actualizar_Sw1()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Zona");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "c_zona";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select c_zona as Zona,cname as Descripción,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TZONAVENTA.cgrupovta) as [G. Ventas],cgrupovta from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND NOT EXISTS(SELECT * FROM  TRUTAVISITAM WHERE (cdelete='0') AND (TRUTAVISITAM.ccompany =TZONAVENTA.ccompany) AND (TRUTAVISITAM.c_zona = TZONAVENTA.c_zona))";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Zonas de Venta", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw2()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[4];
            _Tsm_Menu[0] = new ToolStripMenuItem("Recepción");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            _Tsm_Menu[2] = new ToolStripMenuItem("Producto");
            _Tsm_Menu[3] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[4];
            _Str_Campos[0] = "cidrecepcion";
            _Str_Campos[1] = "Proveedor";
            _Str_Campos[2] = "cproducto";
            _Str_Campos[3] = "cnamef";
            string _Str_Cadena = "Select cidrecepcion as Recepción,(Select top 1 c_nomb_abreviado from TPROVEEDOR where TPROVEEDOR.cproveedor=vst_facturacomparada.cproveedor) as Proveedor,COUNT(*) as Existencia,CASE WHEN cfaltante='1' THEN 'Por llegar' ELSE 'Sobrante' END AS Diferencia,cnfacturapro,cnumoc,cidrecepcion,cproveedor,cfaltante from vst_facturacomparada where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpreso='0' and (cfaltante='1' or cfaltante='2') group by cnfacturapro,cnumoc,cidrecepcion,cproveedor,cfaltante";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Evaluaciones por Imprimir", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.Rows.Count == 0)
            { this.Close(); }
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw3()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccatproveedor";
            _Str_Campos[1] = "cnombre";
            string _Str_Cadena = "Select ccatproveedor as Código,cnombre as Descripción from TCATPROVEEDOR where cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Categoría del Proveedor", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw3_Tipo(int _P_Int_Tipo)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccatproveedor";
            _Str_Campos[1] = "cnombre";
            string _Str_Cadena = "Select ccatproveedor as Código,cnombre as Descripción from TCATPROVEEDOR where cdelete='0' and cglobal='" + _P_Int_Tipo + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Categoría del Proveedor", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw4()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cnumdocu";
            _Str_Campos[1] = "c_nomb_abreviado";
            string _Str_Cadena = "SELECT cidcomprobret as Código, dbo.Fnc_Formatear(cretenido) as [Retenido],cnumdocumafec AS [Factura],cproveedor,cidcomprob,(select ctipdocfact from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "') AS tpodocument FROM TCOMPROBANRETC where ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 and canulado=0 AND NOT EXISTS(SELECT cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobret=TCOMPROBANRETC.cidcomprobret AND cestatusfirma='1')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RETENCIÓN IMPUESTO", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //___________________________________
        }
        public void _Mtd_Actualizar_Sw5()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("ID");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "id_conteohist";
            string _Str_Cadena = "Select id_conteohist as ID,cdate as Fecha,dbo.Fnc_Formatear(SUM(ccostoinvent)) as [Total Diferencia] from VST_INVENTARIOFISICOREPORTE where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "Inventario", _Tsm_Menu, _Dg_Grid, "group by id_conteohist,cdate");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.ContextMenuStrip = _Ctrl_Context2;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw6()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cidcomprobislr";
            string _Str_Cadena = "SELECT cidcomprobislr AS [Código Ret.], c_nomb_comer as [Proveedor], cnumdocumafec as [Fact. Afectada], ctotmontosi as [Monto Pagado o Abonado], ctotretenido as [Retenido], cproveedor FROM VST_COMPROBANISLRC where ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND canulado='0' AND NOT EXISTS(SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobislr=VST_COMPROBANISLRC.cidcomprobislr AND cestatusfirma='1')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RETENCIÓN ISLR", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //___________________________________
        }
        private void _Mtd_Actualizar_Sw7()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("[N.R.]");
            _Tsm_Menu[1] = new ToolStripMenuItem("Factura");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotrecepc";
            _Str_Campos[1] = "cnumdocu";
            string _Str_Cadena = "Select convert(varchar, cfechanotrecep,103) as Fecha,cidnotrecepc as [N.R.],cnumdocu as Factura,cidrecepcion,cproveedor FROM TNOTARECEPC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ctipodocument='FACT' AND cproveedor='" + _Str_Param1 + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Documentos", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw8()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Proveedor");
            _Tsm_Menu[1] = new ToolStripMenuItem("Código");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproveedor";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT TPRODUCTO.cproducto AS Producto,TPRODUCTO.cnamefc AS Descripción,dbo.Fnc_Formatear(TPRODUCTOVENCIMIENTO.cprecioventamax) AS PVJusto,TPRODUCTOVENCIMIENTO.cnotarecepcion as [Nota Recepción], TPRODUCTOVENCIMIENTO.cnumfactura as [N° Factura],TPRODUCTOVENCIMIENTO.CEMPAQUES AS Cajas, TPRODUCTOVENCIMIENTO.CUNIDADES AS Unidades,TPRODUCTOVENCIMIENTO.cfechavencimiento AS Vence FROM TPRODUCTOVENCIMIENTO INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOVENCIMIENTO.CPRODUCTO WHERE TPRODUCTOVENCIMIENTO.ccompany='" + Frm_Padre._Str_Comp + "' and TPRODUCTOVENCIMIENTO.cfechavencimiento<getdate() AND (TPRODUCTO.cactivate = 1) AND (TPRODUCTOVENCIMIENTO.cempaques>0 OR TPRODUCTOVENCIMIENTO.cunidades>0) order by TPRODUCTOVENCIMIENTO.cfechavencimiento asc";
            //string _Str_Cadena = "Select cproveedor as Código,c_nomb_comer as Proveedor,Cajas,Unidades from VST_TABPROVEEDORMERCMALESTADO order by c_nomb_comer";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Proveedores", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw9(string _P_Str_Param1)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Producto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "Producto";
            _Str_Campos[1] = "cnamef";
            _Ctrl_Busqueda1._Mtd_Inicializar(_P_Str_Param1, _Str_Campos, "Consulta", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw10()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidmotivo";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidmotivo as Código,cdescripcion as Descripción FROM TMOTIVO WHERE cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Motivos", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw11()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccodlimite";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select ccodlimite as Código,cdescripcion as Descripción FROM TLIMITCREDITO WHERE cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Límites", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw12()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Usuario");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cuser";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cuser as Usuario,cname as Descripción FROM TUSER WHERE cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Usuarios", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw13()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[4];
            _Tsm_Menu[0] = new ToolStripMenuItem("Placa");
            _Tsm_Menu[1] = new ToolStripMenuItem("Modelo");
            _Tsm_Menu[2] = new ToolStripMenuItem("Tipo");
            _Tsm_Menu[3] = new ToolStripMenuItem("Capacidad Kg");
            string[] _Str_Campos = new string[4];
            _Str_Campos[0] = "cplaca";
            _Str_Campos[1] = "cmodelo";
            _Str_Campos[2] = "cname";
            _Str_Campos[3] = "ccapcarg";
            string _Str_Cadena = "SELECT RTRIM(cplaca) AS Placa, RTRIM(cmodelo) AS Modelo, RTRIM(cname) AS Nombre, ccapcarg as Kg " +
            "FROM VST_TRANSPORTES_DISP where cesperando='1'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Transportes", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw14()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cédula");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccedula";
            _Str_Campos[1] = "cnombre";
            string _Str_Cadena = "Select ccedula as Cédula,cnombre as Nombre from TTRANSPORTISTA where cactivate='1' AND cdelete='0'";
            //string _Str_Cadena = "Select ccedula as Cédula,cnombre as Nombre from TTRANSPORTISTA where cactivate='1' AND cdelete='0' AND NOT EXISTS(SELECT * FROM TTRANSPORTE WHERE TTRANSPORTE.cplaca=TTRANSPORTISTA.cplaca AND TTRANSPORTE.cdelete='0')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Transportistas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw15()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Id");
            _Tsm_Menu[1] = new ToolStripMenuItem("Ruta");
            _Tsm_Menu[2] = new ToolStripMenuItem("Km");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidrutdespacho";
            _Str_Campos[1] = "cdescripcion";
            _Str_Campos[2] = "cdistanciakm";
            string _Str_Cadena = "Select DISTINCT cidrutdespacho as Id,cdescripcion as Ruta,cdistanciakm as Km from VST_RUTAS_SEG_PREFACT_SINPRECARGA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Rutas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw16()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Pre-Factura");
            _Tsm_Menu[1] = new ToolStripMenuItem("Kilos");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "VST_PREFACTURASSEGUNRUTAS.cpfactura";
            _Str_Campos[1] = "VST_PREFACTURASSEGUNRUTAS.Kilos";
            string _Str_Cadena = "SELECT VST_PREFACTURASSEGUNRUTAS.ccompany AS Compañía,VST_PREFACTURASSEGUNRUTAS.cpfactura AS [Pre-Factura], VST_PREFACTURASSEGUNRUTAS.c_nomb_comer AS Cliente,CASE WHEN c_tip_contribuy='2' THEN 'Especial' ELSE 'Regular' END AS Contribuyente, VST_PREFACTURASSEGUNRUTAS.cempaques AS Cajas, VST_PREFACTURASSEGUNRUTAS.cunidades AS Unidades, VST_PREFACTURASSEGUNRUTAS.Kilos, dbo.Fnc_Formatear(c_monto_si) AS Total, CASE WHEN LEN(LTRIM(RTRIM(TCOTPEDFACM.cobservaciones)))>0 THEN 'SI' ELSE 'NO' END AS Observación, CONVERT(VARCHAR,TCOTPEDFACM.c_fecha_pedido,103) AS [Fec. Pedido],RTRIM(VST_PREFACTURASSEGUNRUTAS.cnamecanal) AS Canal,VST_PREFACTURASSEGUNRUTAS.c_factdevuelta, c_rif, VST_PREFACTURASSEGUNRUTAS.ccliente, cidrutdespacho, Metros, Monto, ciudad, VST_PREFACTURASSEGUNRUTAS.c_factdevuelta, VST_PREFACTURASSEGUNRUTAS.cprecarga, c_facturaanul FROM VST_PREFACTURASSEGUNRUTAS INNER JOIN TPREFACTURAM ON VST_PREFACTURASSEGUNRUTAS.cpfactura = TPREFACTURAM.cpfactura AND VST_PREFACTURASSEGUNRUTAS.ccompany = TPREFACTURAM.ccompany INNER JOIN TCOTPEDFACM ON TPREFACTURAM.cpedido = TCOTPEDFACM.cpedido AND TPREFACTURAM.ccompany = TCOTPEDFACM.ccompany WHERE 0=0 " + _Str_Param1 + " ORDER BY VST_PREFACTURASSEGUNRUTAS.CCLIENTE";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Pre-Facturas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[11].Visible = false;
            _Dg_Grid.Columns[12].Visible = false;
            _Dg_Grid.Columns[13].Visible = false;
            _Dg_Grid.Columns[14].Visible = false;
            _Dg_Grid.Columns[15].Visible = false;
            _Dg_Grid.Columns[16].Visible = false;
            _Dg_Grid.Columns[17].Visible = false;
            _Dg_Grid.Columns[18].Visible = false;
            _Dg_Grid.Columns[19].Visible = false;
            _Dg_Grid.Columns[20].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Verificar_PrefacturasDev()
        {
            string _Str_Comp = "";
            string _Str_Prefact = "";
            string _Str_Sql = "";
            _Str_Sql = "SELECT CPFACTURA,CCOMPANY FROM VST_T3_FACTURASPORANULAR";
            DataSet _Ds_DataSetFactuAnul = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);         
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Str_Comp = _Dg_Row.Cells[0].Value.ToString();
                _Str_Prefact = _Dg_Row.Cells[1].Value.ToString();
                if (_Dg_Row.Cells["c_factdevuelta"].Value.ToString().Trim() == "1")
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                }
                if (_Ds_DataSetFactuAnul.Tables[0].Select("cpfactura='" + _Str_Prefact + "' and ccompany='" + _Str_Comp + "'").Length > 0)
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 90, 90);
                }
                //if (_Mtd_PreFacturaTieneFacturasDevueltasParaAnular(_Str_Prefact)) {  }
                //_Dg_Row.DefaultCellStyle.ApplyStyle(
            }
        }
        private void _Mtd_Actualizar_Sw17()
        {
            //___________________________________FACTURAS IMPRESAS
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Factura");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cfactura";
            string _Str_Cadena = "SELECT convert(varchar, c_fecha_factura,103) AS c_fecha_factura,cfactura,cempaques,cunidades,c_nomb_comer,ccliente,cprecarga FROM VST_FACTURAG WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND c_impresa=1";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Facturas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw18()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "Select ccliente as Código,CONVERT(VARCHAR(10),ccliente) + '-' + RTRIM(c_nomb_comer) as Descripción from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw19()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocc";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotadebitocc as Código,cdescripcion as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTADEBICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Débito", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw20()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotcredicc";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotcredicc as Código,cdescripcion as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Crédito", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw21()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Nº Cheque");
            _Tsm_Menu[1] = new ToolStripMenuItem("Documento");
            _Tsm_Menu[2] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cnumcheque";
            _Str_Campos[1] = "cnumdocu";
            _Str_Campos[2] = "c_nomb_comer";
            //string _Str_Cadena = "Select cnumcheque as [Nº Cheque],dbo.formatear(cmontocheq) as [Monto Cheque],convert(varchar,ccliente)+ ' - ' +RTRIM(c_nomb_comer) as Cliente,ctipodocument_name as Tipo,cnumdocu as Documento,cidrelacobro as Relación,CONVERT(varchar, cfeahcaemision, 103) as [Fecha de Emisión],cmontocheq,ccliente,cvendedor,RelTipo,ctipodocument,ctipocobro,cbancodepo,cnumcuentadepo from VST_RELCOBD_CHEQDEP where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT * FROM TCHEQDEVUELT WHERE TCHEQDEVUELT.cgroupcomp=VST_RELCOBD_CHEQDEP.cgroupcomp AND TCHEQDEVUELT.ccompany=VST_RELCOBD_CHEQDEP.ccompany AND TCHEQDEVUELT.cnumcheque=VST_RELCOBD_CHEQDEP.cnumcheque AND TCHEQDEVUELT.ccliente=VST_RELCOBD_CHEQDEP.ccliente AND TCHEQDEVUELT.cidrelacobro=VST_RELCOBD_CHEQDEP.cidrelacobro) " + _Str_Param1;//Se le quito el filtro de banco en el Not Exists.
            //string _Str_Cadena = "Select cnumcheque as [Nº Cheque],dbo.formatear(cmontocheq) as [Monto Cheque],CONVERT(VARCHAR,ccliente)+ ' - ' +RTRIM(c_nomb_comer) as Cliente,cidrelacobro as Relación,CONVERT(VARCHAR, cfechaemision, 103) as [Fecha de Emisión],ccliente,cvendedor,RelTipo,ctipocobro,cbancodepo,cnumcuentadepo,ciddrelacobro_depd,ciddrelacobrodep,cbancocheque FROM VST_CONSULTA_CHEQUES WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cfechaemision BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'  AND NOT EXISTS(SELECT cnumcheque FROM TCHEQDEVUELT WHERE TCHEQDEVUELT.cgroupcomp=VST_CONSULTA_CHEQUES.cgroupcomp AND TCHEQDEVUELT.ccompany=VST_CONSULTA_CHEQUES.ccompany AND TCHEQDEVUELT.cnumcheque=VST_CONSULTA_CHEQUES.cnumcheque AND TCHEQDEVUELT.ccliente=VST_CONSULTA_CHEQUES.ccliente AND TCHEQDEVUELT.cidrelacobro=VST_CONSULTA_CHEQUES.cidrelacobro) " + _Str_Param1;
            string _Str_Cadena = "Select cnumcheque as [Nº Cheque],dbo.formatear(cmontocheq) as [Monto Cheque],CONVERT(VARCHAR,ccliente)+ ' - ' +RTRIM(c_nomb_comer) as Cliente,cidrelacobro as Relación,CONVERT(VARCHAR, cfechaemision, 103) as [Fecha de Emisión],ccliente,cvendedor,RelTipo,ctipocobro,cbancodepo,cnumcuentadepo,ciddrelacobro_depd,ciddrelacobrodep,cbancocheque FROM VST_CONSULTA_CHEQUES WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT cnumcheque FROM TCHEQDEVUELT WHERE TCHEQDEVUELT.cgroupcomp=VST_CONSULTA_CHEQUES.cgroupcomp AND TCHEQDEVUELT.ccompany=VST_CONSULTA_CHEQUES.ccompany AND TCHEQDEVUELT.cnumcheque=VST_CONSULTA_CHEQUES.cnumcheque AND TCHEQDEVUELT.ccliente=VST_CONSULTA_CHEQUES.ccliente AND TCHEQDEVUELT.cidrelacobro=VST_CONSULTA_CHEQUES.cidrelacobro) " + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = false;
            _Dg_Grid.Columns[11].Visible = false;
            _Dg_Grid.Columns[12].Visible = false;
            _Dg_Grid.Columns[13].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw22()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("FACTURA");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cfactura";
            string _Str_Cadena = "Select cfactura as Factura,c_nomb_comer as [Cliente],dbo.Fnc_Formatear(c_montotot_si_bs) as Total,ccliente from VST_FACTURAM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' and c_fact_anul='0' AND c_entregacliente='0' order by cfactura";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Relaciones", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw23()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("CAJA PENDIENTES");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cfactura";
            string _Str_Cadena = "Select ccaja AS Caja,CONVERT(varchar, cfecha, 103) AS Fecha,cidcaja,(SELECT COUNT(cidrelacobro) FROM TRELACCOBM WHERE TRELACCOBM.cgroupcomp=TCAJACXC.cgroupcomp AND TRELACCOBM.ccompany=TCAJACXC.ccompany AND TRELACCOBM.ccaja=TCAJACXC.ccaja) AS Relaciones FROM TCAJACXC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccerrada='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Caja", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw24()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("FACTURA");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cfactura";
            string _Str_Cadena = "Select top 100 cfactura as Factura,c_nomb_comer as [Cliente],dbo.Fnc_Formatear(c_montotot_si_bs) as Total,ccliente from VST_FACTURA_ONLY where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' and c_fact_anul='0' AND c_entregacliente='1' AND EXISTS(SELECT cfactura FROM TFACTURAD WHERE TFACTURAD.cgroupcomp=VST_FACTURA_ONLY.cgroupcomp AND TFACTURAD.ccompany=VST_FACTURA_ONLY.ccompany AND TFACTURAD.cfactura=VST_FACTURA_ONLY.cfactura)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "", " cfactura");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw25()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("PRODUCTO");
            _Tsm_Menu[1] = new ToolStripMenuItem("DESCRIPCIÓN");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproducto";
            _Str_Campos[1] = "cnamefc";
            string _Str_Cadena = "Select cproducto as Producto,cnamefc [Descripción], emp Cajas, und as Unidades, cidproductod as [Lote], cprecioventamax as [PMV],cidproductod FROM VST_FACTURDEVDETALLE_3 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and (emp>0 or und>0) " + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Detalle de Factura", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw26()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("COD. CLIENTE");
            _Tsm_Menu[1] = new ToolStripMenuItem("NOMBRE CLIENTE");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT DISTINCT CONVERT(varchar, c_fech_inicio, 103) AS [Fecha Inicio],(CONVERT(VARCHAR(10),TCLIENTE.ccliente) + '-' + rtrim(TCLIENTE.c_nomb_comer)) as Cliente,TCLIENTE.c_rif AS RIF FROM TCLIENTE INNER JOIN TZONACLIENTE ON TCLIENTE.ccliente=TZONACLIENTE.ccliente WHERE NOT EXISTS (SELECT TRUTAVISITAD.ccliente FROM TRUTAVISITAD WHERE TRUTAVISITAD.ccliente=TZONACLIENTE.ccliente AND TRUTAVISITAD.ccompany=TZONACLIENTE.ccompany AND ISNULL(TRUTAVISITAD.cdelete,0)=ISNULL(TZONACLIENTE.cdelete,0)) AND TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND TZONACLIENTE.cdelete='0' AND TCLIENTE.cdelete='0' and TCLIENTE.c_activo='1' ORDER BY [Fecha Inicio] DESC";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw27()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("FACTURA");
            _Tsm_Menu[1] = new ToolStripMenuItem("CLIENTE");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cnumdocu";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT cnumdocu AS Factura,c_nomb_comer AS [Cliente],dbo.Fnc_Formatear(cmontofactci) AS Total,ccliente FROM VST_SALDOSFACTURAS WHERE NOT EXISTS (SELECT cfactura FROM VST_NOVALID_FACTANUL WHERE VST_NOVALID_FACTANUL.cgroupcomp=VST_SALDOSFACTURAS.cgroupcomp AND VST_NOVALID_FACTANUL.ccompany=VST_SALDOSFACTURAS.ccompany AND VST_NOVALID_FACTANUL.cfactura=VST_SALDOSFACTURAS.cnumdocu) AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete_fact=0 AND c_fact_anul=0 AND c_entregacliente=0 AND c_impresa=1 AND csaldofactura>0 " + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "", " cnumdocu");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw28()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("FACTURA");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cnumdocu";
            string _Str_Cadena = "Select cnumdocu as Factura,CONVERT(VARCHAR,ccliente)+' - '+c_nomb_comer as [Cliente],dbo.Fnc_Formatear(cmontofactci) as Total,ccliente,cvendedor,calicuota,cvendedor+' - '+cnamevendedor as Vendedor from VST_BUSCSALDOFACTURA where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete_fact=0 and c_fact_anul=0 AND c_entregacliente=1 AND c_impresa=1 " + _Str_Param1 + " ORDER BY cnumdocu";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw29()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "select distinct ccliente as Código,RTRIM(c_nomb_comer) as Descripción from dbo.VST_SALDOSFACTURAS where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete_fact=0 and c_fact_anul=0 AND c_entregacliente=1 AND c_impresa=1 AND csaldofactura>0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "", " ccliente");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw30()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("CAJA");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "ccaja";
            string _Str_Cadena = "SELECT ccaja AS Caja,CONVERT(varchar, cfecha, 103) AS Fecha,(SELECT COUNT(*) FROM TNOTACREDICC WHERE TNOTACREDICC.cgroupcomp=TCAJACXC.cgroupcomp AND TNOTACREDICC.ccompany=TCAJACXC.ccompany AND TNOTACREDICC.ccaja=TCAJACXC.ccaja AND TNOTACREDICC.cactivo=0 AND TNOTACREDICC.cimpresa=0 AND TNOTACREDICC.cestatusfirma=3 AND TNOTACREDICC.cdelete=0) AS NC FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccerrada='1' AND (SELECT COUNT(*) FROM TNOTACREDICC WHERE TNOTACREDICC.cgroupcomp=TCAJACXC.cgroupcomp AND TNOTACREDICC.ccompany=TCAJACXC.ccompany AND TNOTACREDICC.ccaja=TCAJACXC.ccaja AND TNOTACREDICC.cactivo=0 AND TNOTACREDICC.cimpresa=0 AND TNOTACREDICC.cestatusfirma=3 AND TNOTACREDICC.cdelete=0)>0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "NC GENERADAS EN CAJA", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void _Mtd_Actualizar_Sw31()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("ID");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "id_conteohist";
            string _Str_Cadena = "SELECT DISTINCT id_conteohist as ID,cdate as Fecha,(SELECT SUM(ccostoinvent) FROM TINVFISICOTEOHIST WHERE TINVFISICOTEOHIST.ccompany=VST_INVENTARIOFISICOREPORTE.ccompany AND TINVFISICOTEOHIST.id_conteohist=VST_INVENTARIOFISICOREPORTE.id_conteohist) as [Total Diferencia],(SELECT COUNT(*) FROM TINVFISICOTEOHIST WHERE TINVFISICOTEOHIST.ccompany=VST_INVENTARIOFISICOREPORTE.ccompany AND TINVFISICOTEOHIST.id_conteohist=VST_INVENTARIOFISICOREPORTE.id_conteohist AND TINVFISICOTEOHIST.cnecajussal=1) AS AjustesSalida,(SELECT COUNT(*) FROM TINVFISICOTEOHIST WHERE TINVFISICOTEOHIST.ccompany=VST_INVENTARIOFISICOREPORTE.ccompany AND TINVFISICOTEOHIST.id_conteohist=VST_INVENTARIOFISICOREPORTE.id_conteohist AND TINVFISICOTEOHIST.cnecajusent=1) AS AjusteEntrada FROM VST_INVENTARIOFISICOREPORTE WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cajustado='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "Inventario", _Tsm_Menu, _Dg_Grid, "group by id_conteohist,cdate,ccompany");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.ContextMenuStrip = _Ctrl_Context2;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw32()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(ccliente) as Código,rtrim(c_nomb_comer) as Nombre FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete=0 AND c_activo='1'";
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw33()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TPROVEEDOR.cproveedor";
            _Str_Campos[1] = "TPROVEEDOR.c_nomb_comer";
            string _Str_Cadena = "SELECT  DISTINCT  RTRIM(TPROVEEDOR.cproveedor) AS Código, RTRIM(TPROVEEDOR.c_nomb_comer) AS Nombre FROM TPROVEEDOR INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor =TGRUPPROVEE.cproveedor INNER JOIN TPRODUCTO ON TPROVEEDOR.cproveedor = TPRODUCTO.cproveedor WHERE TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TGRUPPROVEE.CDELETE='0' AND TPROVEEDOR.cglobal=1 AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND TPRODUCTO.cactivate='1'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PROVEEDORES MAT. PRIMA", _Tsm_Menu, _Dg_Grid, true, "", "Código");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw34()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproveedor";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(cproveedor) as Código,rtrim(c_nomb_comer) as Nombre FROM TPROVEEDOR WHERE cglobal=0 AND ISNULL(cdelete,0)=0 AND c_activo='1' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "PROVEEDORES DE SERVICIO", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw35()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproveedor";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(cproveedor) as Código,rtrim(c_nomb_comer) as Nombre FROM TPROVEEDOR WHERE cglobal=2 AND ISNULL(cdelete,0)=0 AND c_activo='1' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "PROVEEDORES OTROS", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw36()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cédula");
            _Tsm_Menu[1] = new ToolStripMenuItem("Código SPI");
            _Tsm_Menu[2] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccedula";
            _Str_Campos[1] = "cid_spi";
            _Str_Campos[2] = "ISNULL(cnombre1,'')+' '+ISNULL(cnombre2,'')+' '+ISNULL(capellido1,'')+' '+ISNULL(capellido2,'')";
            string _Str_Cadena = "SELECT ccedula AS Cédula,cid_spi AS [Código SPI],ISNULL(cnombre1,'')+' '+ISNULL(cnombre2,'')+' '+ISNULL(capellido1,'')+' '+ISNULL(capellido2,'') AS Nombre FROM TEMPLEADOS_SPI WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cid_spi>0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Empleados", _Tsm_Menu, _Dg_Grid, true, "", "Nombre");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw37()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cbanco";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cbanco as Código,RTRIM(cname) as Descripción FROM TBANCO WHERE cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "BANCOS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw38()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidtipoauxiliar";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidtipoauxiliar as Código,RTRIM(cdescripcion) as Descripción FROM TTIPAUXILIARCONT WHERE cdelete='0' AND cactivo=1";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "AUXILIARES CONTABLES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw39()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TPROVEEDOR.cproveedor";
            _Str_Campos[1] = "TPROVEEDOR.c_nomb_comer";
            string _Str_Cadena = "SELECT DISTINCT  RTRIM(TPROVEEDOR.cproveedor) as Código,rtrim(c_nomb_comer) as Nombre FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "') OR (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PROVEEDORES", _Tsm_Menu, _Dg_Grid, true, "", "Nombre");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw40()
        {
            string _Str_TpoDocFact = "";
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("FACTURA");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cnumdocu";
            string _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
            }

            _Str_Sql = "SELECT cnumdocu AS Factura,ctotal as Monto,calicuota FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocFact + "' AND cactivo=1 AND canulado=0 AND cordenpaghecha=0" + _Str_Param1 + " ORDER BY cnumdocu ASC";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Sql, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw41()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("FACTURA");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cfactura";
            string _Str_Sql = "SELECT cfactura as [Factura], convert(varchar,c_fecha_factura,103) as [Fecha],ccliente as [Cliente],cempaques AS [Empaques], cunidades as [Unidades],ccantidad as [Devoluciones]  FROM VST_FACTURADEVMAESTRATAB where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Sql, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw42()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(ccliente) as Código,rtrim(c_nomb_comer) as Nombre FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete=0 AND c_clasifica='C'";
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw43()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Pedido");
            _Tsm_Menu[1] = new ToolStripMenuItem("Código Cliente");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cpedido";
            _Str_Campos[1] = "ccliente";
            _Str_Campos[2] = "c_nomb_comer";
            string _Str_Cadena = "SELECT cpedido as [Pedido],convert(varchar,c_fecha_pedido,103) as [Fecha],rtrim(ccliente) as Código,rtrim(c_nomb_comer) as Descripción, c_rif as [Rif],cempaques AS Cajas FROM VST_PEDIDOSBACKORDER WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PEDIDOS BLOQUEADOS POR CRÉDITO", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw44()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Zona");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "c_zona";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT c_zona as Zona, cname as Descripción FROM VST_ZONASSINCUOTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Param1;
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "ZONAS SIN CUOTAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw45()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cuenta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Tipo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccount";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "ctcount";
            string _Str_Cadena = "SELECT ccount as Cuenta, cname as Descripción, ctcount as Tipo FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cactivate='1'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Cuentas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw46()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Tipo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcorrel";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "ctypcomp";
            string _Str_Cadena = "SELECT convert(varchar, cregdate,103) as Fecha, cidcomprob, cidcorrel as Comprobante, TCOMPROBANC.cname as Descripción,TTCOMPROBAN.cname as Tipo FROM TCOMPROBANC INNER JOIN TTCOMPROBAN ON TCOMPROBANC.ctypcomp = TTCOMPROBAN.ctypcompro WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND csistema='0' AND ((ccuadrado='0' AND cestatusfirma='1') OR cestatusfirma='4')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Comprobantes", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[1].Visible = false;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw47()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Tipo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcorrel";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "ctypcomp";
            string _Str_Cadena = "SELECT convert(varchar, cregdate,103) as Fecha, cidcomprob, cidcorrel as Comprobante, TCOMPROBANC.cname as Descripción,TTCOMPROBAN.cname as Tipo FROM TCOMPROBANC INNER JOIN TTCOMPROBAN ON TCOMPROBANC.ctypcomp = TTCOMPROBAN.ctypcompro WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND csistema='0' AND ccuadrado='0' AND cestatusfirma='2'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Comprobantes", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[1].Visible = false;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw48()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Tipo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcorrel";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "ctypcomp";
            string _Str_Cadena = "SELECT convert(varchar, cregdate,103) as Fecha, cidcomprob, cidcorrel as Comprobante, TCOMPROBANC.cname as Descripción,TTCOMPROBAN.cname as Tipo FROM TCOMPROBANC INNER JOIN TTCOMPROBAN ON TCOMPROBANC.ctypcomp = TTCOMPROBAN.ctypcompro WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='0' AND csistema='0' AND ccuadrado='1' AND (cestatusfirma='1' OR cestatusfirma='2')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Cuentas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[1].Visible = false;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw49()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("cmontacco");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cmontacco";
            string _Str_Cadena = "SELECT cmontacco as Mes,cyearacco as Año FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' AND creabierto='0' AND convert(datetime,'1/" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "/" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "')>convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco))";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Meses Contables", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw50()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TPROVEEDOR.cproveedor";
            _Str_Campos[1] = "TPROVEEDOR.c_nomb_comer";
            string _Str_Cadena = "SELECT DISTINCT  RTRIM(TPROVEEDOR.cproveedor) as Código,rtrim(c_nomb_comer) as Nombre FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PROVEEDORES", _Tsm_Menu, _Dg_Grid, true, "", "Código");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw51()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("N# Documento");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cnumdocu";
            string _Str_Cadena = "SELECT Tipo,DesCategoria as Categoría,c_nomb_comer as Proveedor,cname as Documento,cnumdocu as [N# Documento],CONVERT(VARCHAR,cfechaemision,103) as [Fecha Emisión],ctotal as Monto, csaldo as Saldo,cidfactxp FROM VST_FACTURA_ANUL_CXP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_Param1 + "' AND canulado='0' AND csaldo2>0 AND cestatusfirma<>'1' AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND VST_PAGOS.cproveedor=VST_FACTURA_ANUL_CXP.cproveedor AND VST_PAGOS.cnumdocu=VST_FACTURA_ANUL_CXP.cnumdocu AND VST_PAGOS.ctipodocument=VST_FACTURA_ANUL_CXP.ctipodocument AND VST_PAGOS.canulado='0')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, _Str_Param1, _Tsm_Menu, _Dg_Grid, true, "", "cnumdocu");
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw52()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccaja";
            string _Str_Cadena = "SELECT ccaja as Caja,convert(varchar,cfecha,103) as Fecha FROM TCAJACXC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and ccerrada='1' and ccaja>0" + _Str_Param1 + " ORDER BY cast(CCAJA as integer) DESC";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CAJAS CXC", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw53()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotcredicc";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotcredicc as Código,cdescripcion as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cexedentecobro='1' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND (cidnotrecepc=0 or cidnotrecepc is null)";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "NOTAS DE CRÉDITO", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw54()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Proceso");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidproceso";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "SELECT RTRIM(cidproceso) AS Proceso,RTRIM(cdescripcion) AS Descripción FROM TPROCESOSCONT WHERE cdelete=0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PROCESOS CONTABLES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw55()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cvendedor AS Código,cname as Descripción from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='2' and c_activo='1'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "GERENTES DE ÁREA", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw56()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Impuesto");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cname";
            string _Str_Cadena = "SELECT DISTINCT TTAX.cname, TTAXUPD.cpercent, TTAXUPD.ctax " +
            "FROM TTAX INNER JOIN " +
            "TTAXUPD ON dbo.TTAX.ctax = dbo.TTAXUPD.ctax COLLATE DATABASE_DEFAULT INNER JOIN " +
            "TCONFIGCXP ON dbo.TTAX.ctax = dbo.TCONFIGCXP.ctipimpuesto " +
            "WHERE (TCONFIGCXP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TTAX.cdelete = '0')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "IMPUESTOS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw57()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("ISLR");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cislr_id";
            string _Str_Cadena = _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FÓRMULAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].Visible = false;
            _Dg_Grid.Columns[1].Visible = false;
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        public void _Mtd_Actualizar_Sw58()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[4];
            _Tsm_Menu[0] = new ToolStripMenuItem("Guía");
            _Tsm_Menu[1] = new ToolStripMenuItem("Factura");
            _Tsm_Menu[2] = new ToolStripMenuItem("Cod. Cliente");
            _Tsm_Menu[3] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[4];
            _Str_Campos[0] = "TGUIADESPACHOD.cguiadesp";
            _Str_Campos[1] = "TFACTURAM.cfactura";
            _Str_Campos[2] = "TCLIENTE.ccliente";
            _Str_Campos[3] = "TCLIENTE.c_nomb_comer";
            string _Str_Cadena = "SELECT TGUIADESPACHOD.cguiadesp AS Guia,TFACTURAM.cfactura AS Factura,CONVERT(VARCHAR,TCLIENTE.ccliente)+' - '+TCLIENTE.c_nomb_comer AS Cliente,dbo.Fnc_Formatear(c_montotot_si_bs) AS Monto,CONVERT(VARCHAR,c_fecha_factura,103) AS Fecha,TCLIENTE.ccliente,TGUIADESPACHOD.c_motdevolcion,TFACTURAM.cvendedor FROM TFACTURAM INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTURAM.ccompany='" + Frm_Padre._Str_Comp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TFACTURAM.cgroupcomp AND TDEVVENTAM.ccompany=TFACTURAM.ccompany AND TDEVVENTAM.cfactura=TFACTURAM.cfactura)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.RowCount == 0)
            {
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                this.Close();
            }

            //___________________________________
        }
        public void _Mtd_Actualizar_Sw59()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cod. Cliente");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "VST_VENDGERCLIENTES.CCLIENTE";
            _Str_Campos[1] = "VST_VENDGERCLIENTES.C_NOMB_COMER";
            string _Str_Cadena = "SELECT distinct VST_VENDGERCLIENTES.CCLIENTE,VST_VENDGERCLIENTES.C_NOMB_COMER FROM VST_VENDGERCLIENTES WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.RowCount == 0)
            {
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                this.Close();
            }

            //___________________________________
        }
        public void _Mtd_Actualizar_Sw60()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cheque");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TCOMPROBANC.cidcorrel";
            _Str_Campos[1] = "TEMICHEQTRANSM.cnumcheqtransac";
            string _Str_Cadena = "SELECT TEMICHEQTRANSM.cidemisioncheq,TPAGOSCXPM.cproveedor,TCOMPROBANC.cidcomprob,CONVERT(VARCHAR,TCOMPROBANC.ctypcomp)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cmontacco)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cyearacco)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cidcorrel) AS Comprobante,TEMICHEQTRANSM.cnumcheqtransac AS Cheque,TEMICHEQTRANSM.cidordpago AS [Orden Pago], TBANCO.cname AS Banco,TEMICHEQTRANSM.cidemisioncheq AS [ID Emision],TEMICHEQTRANSM.cconcepto AS Concepto " +
            "FROM TEMICHEQTRANSM INNER JOIN " +
            "TPAGOSCXPM ON TEMICHEQTRANSM.cgroupcomp = TPAGOSCXPM.cgroupcomp AND " +
            "TEMICHEQTRANSM.ccompany = TPAGOSCXPM.ccompany AND " +
            "TEMICHEQTRANSM.cidcomprob = TPAGOSCXPM.cidcomprob INNER JOIN " +
            "TCOMPROBANC ON TPAGOSCXPM.ccompany = TCOMPROBANC.ccompany AND " +
            "TPAGOSCXPM.cidcomprob = TCOMPROBANC.cidcomprob INNER JOIN " +
            "TBANCO ON TBANCO.ccompany = TEMICHEQTRANSM.ccompany AND TBANCO.cbanco = TEMICHEQTRANSM.cbanco " +
            "WHERE  (TEMICHEQTRANSM.cimpimiocheq = 1) AND (TPAGOSCXPM.ccancelado = 1) AND (TCOMPROBANC.cstatus = '0') AND " +
            "(TEMICHEQTRANSM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TEMICHEQTRANSM.ccompany = '" + Frm_Padre._Str_Comp + "')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "COMPROBANTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].Visible = false;
            _Dg_Grid.Columns[1].Visible = false;
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.RowCount == 0) { this.Close(); }
            //___________________________________
        }
        public void _Mtd_Actualizar_Sw61()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Producto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproducto";
            _Str_Campos[1] = "cnamef";
            string _Str_Cadena = "SELECT DISTINCT TPRODUCTO.cproducto as Producto, TPRODUCTO.cnamef AS Descripción,dbo.Fnc_Formatear(TPRODUCTO.ccostobruto_u1) AS [Costo Bruto],dbo.Fnc_Formatear(TPRODUCTO.ccostoneto_u1) AS [Costo Neto], dbo.Fnc_Formatear(TPRODUCTO.cexisrealu1) AS [Cajas existencia], dbo.Fnc_Formatear(TPRODUCTO.cexisrealu2) AS [Unidades existencia] FROM TPRODUCTO INNER JOIN TPROVEEDOR ON TPRODUCTO.cproveedor=TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((TPROVEEDOR.cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) AND TPRODUCTO.ccostobruto_u1<TPRODUCTO.ccostoneto_u1 AND TPRODUCTO.cactivate='1'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PRODUCTOS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        public void _Mtd_Actualizar_Sw62()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Caja");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "ccaja";
            string _Str_Cadena = "SELECT DISTINCT ccaja AS Caja,dbo.Fnc_Formatear(SUM(cmontodeefectivo)) AS [Monto Total Bs.] FROM VST_TEGRECHEQGTRAN_RELCOB WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso=0 AND NOT ccaja IS NULL GROUP BY ccaja";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CAJAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.RowCount == 0) { this.Close(); }
            //___________________________________
        }
        public void _Mtd_Actualizar_Sw63()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Recepción");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "TRECEPCIONM.cidrecepcion";
            string _Str_Cadena = "SELECT TRECEPCIONM.cidrecepcion AS Recepción, CONVERT(VARCHAR, TRECEPCIONM.cdate, 103) AS Fecha, TRECEPCIONDFM.cnfacturapro AS Factura, TPROVEEDOR.c_nomb_comer AS Proveedor, TRECEPCIONM.cproveedor " +
            "FROM  TRECEPCIONM INNER JOIN " +
            "TRECEPCIONDFM ON TRECEPCIONM.cgroupcomp = TRECEPCIONDFM.cgroupcomp AND " +
            "TRECEPCIONM.cidrecepcion = TRECEPCIONDFM.cidrecepcion AND " +
            "TRECEPCIONM.cproveedor = TRECEPCIONDFM.cproveedor INNER JOIN " +
            "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor " +
            "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRECEPCIONM.cdescargo = '1') AND (TRECEPCIONM.cevaluado = '1') AND (TRECEPCIONDFM.ccomparafactdes='1') AND (TRECEPCIONDFM.cnotarecepcion='0') ORDER BY TRECEPCIONM.cidrecepcion";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Recepciones", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw64()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(ccliente) as Código,rtrim(c_nomb_comer) as Nombre FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND c_activo='" + Convert.ToInt32(_Rb_Act.Checked) + "' AND cdelete=0" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw65()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Ruta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidrutdespacho";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidrutdespacho AS Ruta,cdescripcion AS Descripción from TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cidrutdespacho";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RUTAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw66()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cédula");
            _Tsm_Menu[1] = new ToolStripMenuItem("Trasportista");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccedula";
            _Str_Campos[1] = "cnombre";
            string _Str_Cadena = "Select ccedula AS Cédula,cnombre AS Trasportista from TTRANSPORTISTA WHERE cdelete='" + Convert.ToInt32(!_Rb_Act.Checked) + "'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "TRANSPORTISTAS", _Tsm_Menu, _Dg_Grid, true, "", "cnombre");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw67()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Pedido");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TCOTPEDFACM.cpedido";
            _Str_Campos[1] = "TCLIENTE.c_nomb_comer";
            string _Str_Cadena = "SELECT TCOTPEDFACM.cpedido AS Pedido, CONVERT(VARCHAR, TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer AS Cliente FROM TCOTPEDFACM INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TCOTPEDFACM.cdelete=0" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PEDIDOS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw68()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Factura");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TFACTURAM.cfactura";
            _Str_Campos[1] = "TCLIENTE.c_nomb_comer";
            string _Str_Cadena = "SELECT TFACTURAM.cfactura as Factura, CONVERT(VARCHAR, TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer AS Cliente FROM  TFACTURAM INNER JOIN TCLIENTE ON TFACTURAM.ccliente = TCLIENTE.ccliente WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTURAM.cdelete=0" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw69()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Vendedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cvendedor as Código, cname as Vendedor FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND c_activo='" + Convert.ToInt32(_Rb_Act.Checked) + "' AND cdelete=0" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "VENDEDORES", _Tsm_Menu, _Dg_Grid, true, "", "cast(replace(cvendedor,rtrim(ccompany)+'_','') as integer)");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }


        private void _Mtd_Actualizar_Sw70()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Pedido");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            _Tsm_Menu[2] = new ToolStripMenuItem("Vendedor");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "TCOTPEDFACM.cpedido";
            _Str_Campos[1] = "TCLIENTE.ccliente";
            _Str_Campos[2] = "TVENDEDOR.cvendedor";
            string _Str_Cadena = "";
            _Str_Cadena += "SELECT TCOTPEDFACM.cpedido AS Pedido, CONVERT(varchar, TCLIENTE.ccliente) + ' - ' + CONVERT(varchar, TCLIENTE.c_nomb_comer) AS Cliente, CONVERT(varchar, TVENDEDOR.cvendedor) + ' - ' + CONVERT(varchar, TVENDEDOR.cname) AS Vendedor" + " ";
            _Str_Cadena += "FROM TVENDEDOR INNER JOIN TCOTPEDFACM ON TVENDEDOR.ccompany = TCOTPEDFACM.ccompany AND TVENDEDOR.cvendedor = TCOTPEDFACM.cvendedor INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente" + " ";
            _Str_Cadena += "WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TCOTPEDFACM.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOTPEDFACM.cdelete = 0" + " " + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PEDIDOS", _Tsm_Menu, _Dg_Grid, true, "", "TCOTPEDFACM.cpedido");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw71()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Relacion");
            _Tsm_Menu[1] = new ToolStripMenuItem("Placa");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cguiadesp";
            _Str_Campos[1] = "cplaca";

            string _Str_Cadena = "";
            _Str_Cadena += "SELECT cguiadesp as Relacion, cplaca as Placa" + " ";
            _Str_Cadena += "FROM TGUIADESPACHOM" + " ";
            _Str_Cadena += "WHERE (cguiadesp > 0) AND (cgroupcomp = " + Frm_Padre._Str_GroupComp + ") " + " " + _Str_Param1;

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RELACIONES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw72()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Placa");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cplaca";

            string _Str_Cadena = "";
            _Str_Cadena += "SELECT DISTINCT cplaca AS Placa" + " ";
            _Str_Cadena += "FROM TGUIADESPACHOM" + " ";
            _Str_Cadena += "WHERE (cguiadesp > 0) AND (cgroupcomp = " + Frm_Padre._Str_GroupComp + ") " + " " + _Str_Param1;

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PLACAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        public void _Mtd_Actualizar_Sw73()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Comprobante");
            _Tsm_Menu[1] = new ToolStripMenuItem("Orden Pago");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "TCOMPROBANC.cidcorrel";
            _Str_Campos[1] = "TPAGOSCXPM.cidordpago";
            string _Str_Cadena = "SELECT DISTINCT TCOMPROBANC.cidcomprob,CONVERT(VARCHAR,TCOMPROBANC.ctypcomp)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cmontacco)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cyearacco)+'-'+CONVERT(VARCHAR,TCOMPROBANC.cidcorrel) AS Comprobante,TPAGOSCXPM.cidordpago AS [Orden Pago] FROM TPAGOSCXPM INNER JOIN TCOMPROBANC ON TPAGOSCXPM.ccompany = TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob = TCOMPROBANC.cidcomprob INNER JOIN TPAGOSCXPANT ON TPAGOSCXPM.cgroupcomp = TPAGOSCXPANT.cgroupcomp AND TPAGOSCXPM.ccompany = TPAGOSCXPANT.ccompany AND TPAGOSCXPM.cidordpago = TPAGOSCXPANT.cidordpago WHERE (TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TPAGOSCXPM.ccompany='" + Frm_Padre._Str_Comp + "') AND (TPAGOSCXPM.ccancelado = '1') AND (TPAGOSCXPM.canulado = '0') AND (TCOMPROBANC.cstatus = '0') AND (TPAGOSCXPM.cotrospago = '0') AND NOT EXISTS(SELECT cidordpago FROM TEMICHEQTRANSM WHERE TEMICHEQTRANSM.cgroupcomp=TPAGOSCXPM.cgroupcomp AND TEMICHEQTRANSM.ccompany=TPAGOSCXPM.ccompany AND TEMICHEQTRANSM.cidordpago=TPAGOSCXPM.cidordpago)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "COMPROBANTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[0].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.RowCount == 0) { this.Close(); }
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw74()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cuenta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Tipo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccount";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "ctcount";
            string _Str_Cadena = "SELECT ccount as Cuenta, cname as Descripción, ctcount as Tipo FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Cuentas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw75()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(ccliente) as Código,rtrim(c_nomb_comer) as Nombre FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete=0 AND c_activo='1'" + _Str_Param1;
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw76()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cbanco";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cbanco as Código,RTRIM(cname) as Descripción FROM TBANCO WHERE cdelete='0'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "BANCOS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw77()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Rif");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            _Str_Campos[2] = "c_rif";
            string _Str_Cadena = "SELECT DISTINCT TCLIENTE.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS Descripción, TCLIENTE.c_rif AS RIF FROM TCLIENTE INNER JOIN TZONACLIENTE ON TCLIENTE.ccliente=TZONACLIENTE.ccliente WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND TZONACLIENTE.cdelete='0' AND TCLIENTE.cdelete='0' and TCLIENTE.c_activo='1' ORDER BY TCLIENTE.ccliente";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw78()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Rif");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            _Str_Campos[2] = "c_rif";
            string _Str_Cadena = "SELECT DISTINCT TCLIENTE.ccliente AS Cliente, RTRIM(TCLIENTE.c_nomb_comer) AS Descripción, TCLIENTE.c_rif AS RIF FROM TCLIENTE INNER JOIN TZONACLIENTE ON TCLIENTE.ccliente = TZONACLIENTE.ccliente INNER JOIN TRUTAVISITAD ON TZONACLIENTE.ccompany = TRUTAVISITAD.ccompany AND TZONACLIENTE.ccliente = TRUTAVISITAD.ccliente AND ISNULL(TZONACLIENTE.cdelete, 0) = ISNULL(TRUTAVISITAD.cdelete, 0) WHERE TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TZONACLIENTE.ccompany='" + Frm_Padre._Str_Comp + "' AND TZONACLIENTE.cdelete='0' AND TCLIENTE.cdelete='0' and TCLIENTE.c_activo='1' ORDER BY TCLIENTE.ccliente";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw79()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("ZONA");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descricpión");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "c_zona";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT c_zona AS ZONA,cname AS Descricpión FROM TZONAVENTA WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "ZONAS", _Tsm_Menu, _Dg_Grid, true, "", "c_zona");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw80(string _Str_CodigoGrupoCompania, string _Str_CodigoCompania, string _Str_CodigoProveedor)
        {
            this._Str_FrmResult = "0";
            this._Int_Sw = 80;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("No. documento");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cnumdocu";
            string _Str_Cadena = "SELECT cname as Documento,cnumdocu as [No. documento],CONVERT(VARCHAR,cfechaemision,103) as [Fecha emisión],dbo.Fnc_Formatear(ctotalsimp) as [Base imponible] FROM VST_FACTURA_ANUL_CXP where cgroupcomp='" + _Str_CodigoGrupoCompania + "' AND ccompany='" + _Str_CodigoCompania + "' AND canulado='0' AND csaldo2>0 AND cestatusfirma<>'1' AND NOT EXISTS(SELECT cidordpago FROM VST_PAGOS WHERE cgroupcomp='" + _Str_CodigoGrupoCompania + "' AND ccompany='" + _Str_CodigoCompania + "' AND VST_PAGOS.cproveedor=VST_FACTURA_ANUL_CXP.cproveedor AND VST_PAGOS.cnumdocu=VST_FACTURA_ANUL_CXP.cnumdocu AND VST_PAGOS.ctipodocument=VST_FACTURA_ANUL_CXP.ctipodocument AND VST_PAGOS.canulado='0') AND VST_FACTURA_ANUL_CXP.cproveedor = '" + _Str_CodigoProveedor + "' and (VST_FACTURA_ANUL_CXP.ctipodocument = 'NDP' OR VST_FACTURA_ANUL_CXP.ctipodocument = 'FACT')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "DOCUMENTOS PROVEEDOR", _Tsm_Menu, _Dg_Grid, true, "", "cnumdocu");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw81()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Produto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproducto";
            _Str_Campos[1] = "cnamefc";
            string _Str_Cadena = "SELECT cproducto AS Producto,cnamefc AS Descripción,cexismmeu1 AS Cajas, cexismmeu2 AS Unidades FROM TPRODUCTO WHERE (cexismmeu1 > 0 OR cexismmeu2 > 0)" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Productos", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw82()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Produto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproducto";
            _Str_Campos[1] = "cnamefc";
            //string _Str_Cadena = "SELECT COUNT(TPRODUCTOVENCIMIENTO.cproducto) FROM TPRODUCTOVENCIMIENTO INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOVENCIMIENTO.CPRODUCTO WHERE DATEDIFF(d,GETDATE(),TPRODUCTOVENCIMIENTO.cfechavencimiento) between 0 and (SELECT ISNULL(cdiasvencproduc,0) FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "') AND (TPRODUCTO.cactivate = 1) AND (TPRODUCTOVENCIMIENTO.cempaques>0 OR TPRODUCTOVENCIMIENTO.cunidades>0)";
            string _Str_Cadena = "SELECT TPRODUCTO.cproducto AS Producto,TPRODUCTO.cnamefc AS Descripción,dbo.Fnc_Formatear(TPRODUCTOVENCIMIENTO.cprecioventamax) AS PVJusto,TPRODUCTOVENCIMIENTO.cnotarecepcion as [Nota Recepción], TPRODUCTOVENCIMIENTO.cnumfactura as [N° Factura],TPRODUCTOVENCIMIENTO.CEMPAQUES AS Cajas, TPRODUCTOVENCIMIENTO.CUNIDADES AS Unidades,TPRODUCTOVENCIMIENTO.cfechavencimiento AS Vence FROM TPRODUCTOVENCIMIENTO INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOVENCIMIENTO.CPRODUCTO WHERE TPRODUCTOVENCIMIENTO.ccompany='" + Frm_Padre._Str_Comp + "' and DATEDIFF(d,GETDATE(),TPRODUCTOVENCIMIENTO.cfechavencimiento) between 0 and (SELECT ISNULL(cdiasvencproduc,0) FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "') AND (TPRODUCTO.cactivate = 1) AND (TPRODUCTOVENCIMIENTO.cempaques>0 OR TPRODUCTOVENCIMIENTO.cunidades>0) order by TPRODUCTOVENCIMIENTO.cfechavencimiento asc";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Productos", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Sort(_Dg_Grid.Columns[4], ListSortDirection.Ascending);
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw83()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Recepción");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidrecepcion";
            _Str_Campos[1] = "c_nomb_abreviado";
            string _Str_Cadena = "SELECT DISTINCT TRECEPCIONM.cidrecepcion as Recepción,TRECEPCIONM.cdate AS Fecha, TPROVEEDOR.c_nomb_abreviado AS Proveedor,TRECEPCIONM.cproveedor,TRECEPCIONM.cplaca, TGRUPPROVEE.ccompany AS Compañía " +
                                 "FROM TRECEPCIONM INNER JOIN " +
                                 "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor " +
                                 "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND cglobal='1' AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 0)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Recepciones", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw84()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Recepción");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidrecepcion";
            _Str_Campos[1] = "c_nomb_abreviado";
            string _Str_Cadena = "SELECT DISTINCT TRECEPCIONM.cidrecepcion as Recepción,TRECEPCIONM.cdate AS Fecha, TPROVEEDOR.c_nomb_abreviado AS Proveedor,TRECEPCIONM.cproveedor,TRECEPCIONM.cplaca, TGRUPPROVEE.ccompany AS Compañía " +
                                 "FROM TRECEPCIONM INNER JOIN " +
                                 "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor " +
                                 "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND cglobal='1' AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 2) AND (SELECT COUNT(cnfacturapro) FROM TRECEPCIONDFM WHERE cgroupcomp=TRECEPCIONM.cgroupcomp AND cidrecepcion=TRECEPCIONM.cidrecepcion AND cfactverif='0')>0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Recepciones", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw85()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Recepción");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidrecepcion";
            _Str_Campos[1] = "c_nomb_abreviado";
            string _Str_Cadena = "SELECT DISTINCT TRECEPCIONM.cidrecepcion as Recepción,TRECEPCIONM.cdate AS Fecha, TPROVEEDOR.c_nomb_abreviado AS Proveedor,TRECEPCIONM.cproveedor,TRECEPCIONM.cplaca, TGRUPPROVEE.ccompany AS Compañía " +
                                 "FROM TRECEPCIONM INNER JOIN " +
                                 "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor " +
                                 "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND cglobal='1' AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 2) AND (SELECT COUNT(cnfacturapro) FROM TRECEPCIONDFM WHERE cgroupcomp=TRECEPCIONM.cgroupcomp AND cidrecepcion=TRECEPCIONM.cidrecepcion AND cfactverif='2')>0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Recepciones", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw86()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Recepción");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidrecepcion";
            _Str_Campos[1] = "c_nomb_abreviado";
            string _Str_Cadena = "SELECT DISTINCT TRECEPCIONM.cidrecepcion as Recepción,TRECEPCIONM.cdate AS Fecha, TPROVEEDOR.c_nomb_abreviado AS Proveedor,TRECEPCIONM.cproveedor,TRECEPCIONM.cplaca, TGRUPPROVEE.ccompany AS Compañía " +
                                 "FROM TRECEPCIONM INNER JOIN " +
                                 "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor " +
                                 "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND cglobal='1' AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.ccargfactura = 1) AND (TRECEPCIONM.cevaluado = 0)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Recepciones", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw87()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Placa");
            _Tsm_Menu[1] = new ToolStripMenuItem("Trasportista");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cplaca";
            _Str_Campos[1] = "cnombre";
            string _Str_Cadena = "Select cplaca AS Placa,cnombre AS Trasportista from TTRANSPORTISTA WHERE cdelete='" + Convert.ToInt32(!_Rb_Act.Checked) + "'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "TRANSPORTISTAS", _Tsm_Menu, _Dg_Grid, true, "", "cnombre");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw88()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];

            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");

            string[] _Str_Campos = new string[2];

            _Str_Campos[0] = "ccodlimite";
            _Str_Campos[1] = "cdescripcion";

            string _Str_Cadena = "SELECT ccodlimite AS Código, cdescripcion AS Descripción FROM TLIMITCREDITO";

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RANGOS", _Tsm_Menu, _Dg_Grid, true, "", "cdescripcion");

            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_Actualizar_Sw89()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotcredicc";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotcredicc as Código,cdescripcion as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTACREDICC INNER JOIN TICRELAPROCLI ON TNOTACREDICC.ccliente=TICRELAPROCLI.ccliente where TNOTACREDICC.cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cexedentecobro<>1 and cimpresa='0' and cactivo='0' AND (cestatusfirma=2 OR cidnotrecepc>0) AND ISNULL(TICRELAPROCLI.cdelete,0)=0";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "NOTAS DE CRÉDITO", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw90()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocc";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotadebitocc as Código,cdescripcion as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTADEBICC INNER JOIN TICRELAPROCLI ON TNOTADEBICC.ccliente=TICRELAPROCLI.ccliente where TNOTADEBICC.cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and TNOTADEBICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND ISNULL(TICRELAPROCLI.cdelete,0)=0";
            _Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "NOTAS DE CRÉDITO", _Tsm_Menu, _Dg_Grid, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw91() //Busqueda de documentos cobrados para cobranzas intercompañia
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];

            _Tsm_Menu[0] = new ToolStripMenuItem("Número documento");
            _Tsm_Menu[1] = new ToolStripMenuItem("Tipo de documento");

            string[] _Str_Campos = new string[2];

            _Str_Campos[0] = "cnumdocu";
            _Str_Campos[1] = "ctipo";

            string _Str_Cadena = "";
            _Str_Cadena += "SELECT ";
            _Str_Cadena += "cnumdocu AS [Documento]";
            _Str_Cadena += ", convert(varchar, cfechaemision,103) AS [Emisión]";
            _Str_Cadena += ", convert(varchar, cfechavencimiento,103) AS [Vencimiento] ";
            _Str_Cadena += ", dbo.Fnc_Formatear(CASE WHEN ctipo IN('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXC') THEN cmonto ELSE -1*cmonto END) AS [Monto]";
            _Str_Cadena += ", ctipo AS [Tipo] ";
            _Str_Cadena += "FROM VST_CONSOLIDADO_INTERCOMPANIAS ";
            _Str_Cadena += "WHERE ccompany = '" + Frm_Padre._Str_Comp + "' and cestado=0 AND canulado = 0 AND cimpreso = 1 AND csaldo <> 0 ";
            _Str_Cadena += "AND ctipo IN ('FACTURA CXC','NOTA DE CREDITO CXC','NOTA DE DEBITO CXC','AVISO DE COBRO CXC')";
            _Str_Cadena += "AND cproveedor = '" + _Str_Param1 + "' ";
            if (_Str_Param2.Length > 0)
            {
                _Str_Cadena += " " + _Str_Param2 + " ";
            }

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "DOCUMENTOS", _Tsm_Menu, _Dg_Grid, true, "", "ctipo");
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Sw92() //Busqueda de documentos de pago para cobranzas intecompañia
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];

            _Tsm_Menu[0] = new ToolStripMenuItem("Número documento");
            _Tsm_Menu[1] = new ToolStripMenuItem("Tipo de documento");

            string[] _Str_Campos = new string[2];

            _Str_Campos[0] = "cnumdocu";
            _Str_Campos[1] = "ctipo";

            string _Str_Cadena = "";
            _Str_Cadena += "SELECT ";
            _Str_Cadena += "cnumdocu AS [Documento]";
            _Str_Cadena += ", convert(varchar, cfechaemision,103) AS [Emisión]";
            _Str_Cadena += ", convert(varchar, cfechavencimiento,103) AS [Vencimiento] ";
            _Str_Cadena += ", dbo.Fnc_Formatear(CASE WHEN ctipo IN('NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP') THEN cmonto ELSE -1*cmonto END) AS [Monto]";
            _Str_Cadena += ", ctipo AS [Tipo] ";
            _Str_Cadena += "FROM VST_CONSOLIDADO_INTERCOMPANIAS ";
            _Str_Cadena += "WHERE ccompany = '" + Frm_Padre._Str_Comp + "' and cestado=0 AND canulado = 0 AND cimpreso = 1 AND csaldo <> 0 ";
            _Str_Cadena += "AND ctipo IN ('FACTURA CXP','NOTA DE CREDITO CXP','NOTA DE DEBITO CXP','NOTA DE CREDITO PROVEEDOR CXP','NOTA DE DEBITO PROVEEDOR CXP','AVISO DE COBRO CXP')";
            _Str_Cadena += "AND cproveedor = '" + _Str_Param1 + "' ";
            if (_Str_Param2.Length > 0)
            {
                _Str_Cadena += " " + _Str_Param2 + " ";
            }

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "DOCUMENTOS", _Tsm_Menu, _Dg_Grid, true, "", "ctipo");
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void _Mtd_Actualizar_Sw93()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cuenta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccount";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT ccount as Cuenta, cname as Descripción FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Param1;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Cuentas", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Actualizar_Sw94()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT rtrim(ccliente) as Código,rtrim(c_nomb_comer) as Nombre FROM TCLIENTE INNER JOIN TCONFIGCOMP ON TCLIENTE.c_canal = TCONFIGCOMP.ccanalic WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND c_activo='1'";
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw95()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TPROVEEDOR.cproveedor) as Código,rtrim(c_nomb_comer) as Nombre FROM TICRELAPROCLI INNER JOIN TPROVEEDOR ON TICRELAPROCLI.cproveedor = TPROVEEDOR.cproveedor WHERE TICRELAPROCLI.CDELETE = 0";
            //_Ctrl_Busqueda1._Mtd_Inicializar2(_Str_Cadena, _Str_Campos, "CLIENTES", _Tsm_Menu, _Dg_Grid, "");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PROVEEDORES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw96()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cproducto";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cproducto as [Código], cnamef as [Nombre] FROM TPRODUCTO where cdelete=0 and cactivate=1";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PRODUCTOS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw97()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Id Conciliación");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cidconciliacion";
            string _Str_Cadena = "SELECT DISTINCT TCONCILIACION.cidconciliacion AS [Id Conciliación], TBANCO.CNAME AS [Banco], TCONCILIACION.cnumcuenta AS [Cuenta], CONVERT(VARCHAR, TCONCILIACION.cfechadesde, 103) AS [Fecha Desde], CONVERT(VARCHAR, TCONCILIACION.cfechahasta, 103) AS [Fecha Hasta] FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUALV2 ON TCONCILIACION.cidconciliacion = TCONCILIACIOND_MANUALV2.cidconciliacion AND  TCONCILIACION.ccompany = TCONCILIACIOND_MANUALV2.ccompany INNER JOIN TBANCO ON TCONCILIACION.cbanco = TBANCO.cbanco AND  TCONCILIACION.ccompany = TBANCO.ccompany WHERE TCONCILIACION.ccompany='" + Frm_Padre._Str_Comp + "' AND TCONCILIACION.cfinalizado = 0 " +
                   "AND NOT EXISTS(SELECT cidconciliacion FROM TCONCILIACIOND_MANUALV2 AS DETALLE_MANUAL WHERE DETALLE_MANUAL.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND DETALLE_MANUAL.ccompany=TCONCILIACIOND_MANUALV2.ccompany AND ISNULL(DETALLE_MANUAL.caprobado,0)=0)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CONCILIACIONES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw98()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Id Conciliación");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cidconciliacion";
//            string _Str_Cadena = "SELECT DISTINCT TCONCILIACION.cidconciliacion AS [Id Conciliación], TBANCO.CNAME AS [Banco], TCONCILIACION.cnumcuenta AS [Cuenta], CONVERT(VARCHAR, TCONCILIACION.cfechadesde, 103) AS [Fecha Desde], CONVERT(VARCHAR, TCONCILIACION.cfechahasta, 103) AS [Fecha Hasta] FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUAL ON TCONCILIACION.cidconciliacion = TCONCILIACIOND_MANUAL.cidconciliacion AND  TCONCILIACION.ccompany = TCONCILIACIOND_MANUAL.ccompany INNER JOIN TBANCO ON TCONCILIACION.cbanco = TBANCO.cbanco AND  TCONCILIACION.ccompany = TBANCO.ccompany WHERE TCONCILIACION.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TCONCILIACIOND_MANUAL.caprobado,0)=0 ";
            string _Str_Cadena = "SELECT DISTINCT TCONCILIACION.cidconciliacion AS [Id Conciliación], TBANCO.CNAME AS [Banco], TCONCILIACION.cnumcuenta AS [Cuenta], CONVERT(VARCHAR, TCONCILIACION.cfechadesde, 103) AS [Fecha Desde], CONVERT(VARCHAR, TCONCILIACION.cfechahasta, 103) AS [Fecha Hasta] FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUALV2 ON TCONCILIACION.cidconciliacion = TCONCILIACIOND_MANUALV2.cidconciliacion AND  TCONCILIACION.ccompany = TCONCILIACIOND_MANUALV2.ccompany INNER JOIN TBANCO ON TCONCILIACION.cbanco = TBANCO.cbanco AND  TCONCILIACION.ccompany = TBANCO.ccompany WHERE TCONCILIACION.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TCONCILIACIOND_MANUALV2.caprobado,0)=0 ";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CONCILIACIONES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw99()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Vendedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            //string _Str_Cadena = "SELECT cvendedor as Código, cname as Vendedor FROM TVENDEDOR WHERE c_activo='" + Convert.ToInt32(_Rb_Act.Checked) + "' AND cdelete=0" + _Str_Param1;
            string _Str_Cadena = "SELECT cvendedor AS Código ,cname AS Vendedor FROM TVENDEDOR WHERE c_activo = '" + Convert.ToInt32(_Rb_Act.Checked) + "' AND cdelete = 0 " + _Str_Param1 + " AND NOT EXISTS (SELECT cvendedor FROM TUSUARIOCOBRANZA WHERE ccompany = TVENDEDOR.ccompany AND cvendedor = TVENDEDOR.cvendedor)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "VENDEDORES", _Tsm_Menu, _Dg_Grid, true, "", "cast(replace(cvendedor,rtrim(ccompany)+'_','') as integer)");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw101()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Banco");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "Banco";
            string _Str_Cadena = "SELECT TBANCO.cname AS Banco ,TCONCILIACION.cnumcuenta AS [Nº Cuenta] ,CONVERT(VARCHAR, MAX(TCONCILIACION.cfechahasta), 103) AS [Fech.Final.Últim.Conc] ,DATEDIFF(day, MAX(TCONCILIACION.cfechahasta), GETDATE() - 1) AS [Dias sin Conciliar] FROM TCONCILIACION INNER JOIN TBANCO ON TCONCILIACION.cbanco = TBANCO.cbanco AND TCONCILIACION.ccompany = TBANCO.ccompany INNER JOIN TCUENTBANC ON TCONCILIACION.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco AND TCONCILIACION.cnumcuenta = TCUENTBANC.cnumcuenta WHERE (TCONCILIACION.ccompany = '" + Frm_Padre._Str_Comp + "') AND (ISNULL(TCONCILIACION.cdelete, 0) = 0) AND (TCONCILIACION.cfinalizado = 1) GROUP BY TCONCILIACION.cbanco ,TCONCILIACION.cnumcuenta ,TBANCO.cname ,TCUENTBANC.cname";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "CONCILIACIONES PENDIENTES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw102() // RETENCIONES ISRL MANUALES
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            _Tsm_Menu[2] = new ToolStripMenuItem("Factura");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcomprobislr";
            _Str_Campos[1] = "c_nomb_comer";
            _Str_Campos[2] = "cnumdocumafec";
            string _Str_Cadena = "SELECT VST_COMPROBANISLRC.cidcomprobislr as Código, VST_COMPROBANISLRC.c_nomb_comer AS Proveedor, VST_COMPROBANISLRC.cnumdocumafec AS [Factura], dbo.Fnc_Formatear(VST_COMPROBANISLRC.ctotretenido) AS [Monto Retenido],VST_COMPROBANISLRC.cproveedor,VST_COMPROBANISLRC.cidcomprob " +
                                 "FROM VST_COMPROBANISLRC INNER JOIN TFACTPPAGARM ON VST_COMPROBANISLRC.ccompany = TFACTPPAGARM.ccompany AND VST_COMPROBANISLRC.cproveedor = TFACTPPAGARM.cproveedor INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany = TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument = TCONFIGCXP.ctipdocretislr  " +
                                 "WHERE VST_COMPROBANISLRC.ccompany = '" + Frm_Padre._Str_Comp + "' AND VST_COMPROBANISLRC.canulado = 0 AND VST_COMPROBANISLRC.cimpreso = '1' AND VST_COMPROBANISLRC.cmanual = '1'  and (TFACTPPAGARM.cordenpaghecha = 0) AND (TFACTPPAGARM.cdelete = 0) AND (TFACTPPAGARM.ctotal < 0) " +
                                 "AND NOT EXISTS (SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany = '" + Frm_Padre._Str_Comp + "' AND TFACTPPAGARM.cidcomprobislr = VST_COMPROBANISLRC.cidcomprobislr AND cestatusfirma = '1' ) " +
                                 "AND NOT EXISTS (SELECT TREPOSICIONESD.cnumdocu " +
                                 "FROM TREPOSICIONESM INNER JOIN TREPOSICIONESD ON TREPOSICIONESM.cgroupcomp = TREPOSICIONESD.cgroupcomp AND TREPOSICIONESM.ccompany = TREPOSICIONESD.ccompany AND TREPOSICIONESM.cidreposiciones = TREPOSICIONESD.cidreposiciones " +
                                 "WHERE (TREPOSICIONESM.cestatusfirma = 1) AND (TREPOSICIONESM.cdelete = 0) AND (TREPOSICIONESD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TREPOSICIONESD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TREPOSICIONESD.cnumdocu = VST_COMPROBANISLRC.cidcomprobislr) AND (TREPOSICIONESD.ctipodocumentodetalle = '" + (Byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionISLR + "')) "; 
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RETENCIONES ISRL MANUALES", _Tsm_Menu, _Dg_Grid, true, "");
            //Ocultamos
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            //Alineamos
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Mtd_Actualizar_Sw103() // RETENCIONES IVA MANUALES
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            _Tsm_Menu[2] = new ToolStripMenuItem("Factura");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcomprobret";
            _Str_Campos[1] = "c_nomb_comer";
            _Str_Campos[2] = "cnumdocumafec";
            string _Str_Cadena = "SELECT TCOMPROBANRETC.cidcomprobret AS Código, TPROVEEDOR.c_nomb_comer AS Proveedor, TCOMPROBANRETC.cnumdocumafec AS Factura ,dbo.Fnc_Formatear(TCOMPROBANRETC.cretenido) AS Retenido ,TCOMPROBANRETC.cproveedor ,TCOMPROBANRETC.cidcomprob " +
                                 "FROM TCOMPROBANRETC INNER JOIN TPROVEEDOR ON TCOMPROBANRETC.cproveedor = TPROVEEDOR.cproveedor AND TCOMPROBANRETC.ccompany = TPROVEEDOR.ccompany INNER JOIN TFACTPPAGARM ON TCOMPROBANRETC.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANRETC.cproveedor = TFACTPPAGARM.cproveedor AND TCOMPROBANRETC.cidcomprobret = TFACTPPAGARM.cnumdocu INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany = TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument = TCONFIGCXP.ctipdocretiva   " +
                                 "WHERE (TCOMPROBANRETC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCOMPROBANRETC.cimpreso = 1) AND (TCOMPROBANRETC.canulado = 0) AND (TCOMPROBANRETC.cmanual = 1) AND (TPROVEEDOR.cdelete = 0)   and (TFACTPPAGARM.cordenpaghecha = 0) AND (TFACTPPAGARM.cdelete = 0) AND (TFACTPPAGARM.ctotal < 0)  " +
                                 "AND (NOT EXISTS(SELECT cidcomprobret FROM TFACTPPAGARM WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cidcomprobret = TCOMPROBANRETC.cidcomprobret) AND (cestatusfirma = '1'))) " +
                                 "AND NOT EXISTS (SELECT TREPOSICIONESD.cnumdocu " +
                                 "FROM TREPOSICIONESM INNER JOIN TREPOSICIONESD ON TREPOSICIONESM.cgroupcomp = TREPOSICIONESD.cgroupcomp AND TREPOSICIONESM.ccompany = TREPOSICIONESD.ccompany AND TREPOSICIONESM.cidreposiciones = TREPOSICIONESD.cidreposiciones " +
                                 "WHERE (TREPOSICIONESM.cestatusfirma = 1) AND (TREPOSICIONESM.cdelete = 0) AND (TREPOSICIONESD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TREPOSICIONESD.ccompany = '" + Frm_Padre._Str_Comp + "')  AND (TREPOSICIONESD.cnumdocu = TCOMPROBANRETC.cidcomprobret) AND (TREPOSICIONESD.ctipodocumentodetalle = '" + (Byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionIVA + "')) "; 
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RETENCIONES IVA MANUALES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Ocultamos
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            //Alineamos
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //___________________________________
        }
        private void _Mtd_Actualizar_Sw104() // RETENCIONES PATENTE MANUALES
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            _Tsm_Menu[2] = new ToolStripMenuItem("Factura");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcomprobret";
            _Str_Campos[1] = "c_nomb_comer";
            _Str_Campos[2] = "cnumdocumafec";
            string _Str_Cadena = "SELECT TCOMPROBANRETPAT.cidcomprobret AS Código, TPROVEEDOR.c_nomb_comer AS Proveedor, TCOMPROBANRETPAT.cnumdocumafec AS Factura ,dbo.Fnc_Formatear(TCOMPROBANRETPAT.cretenido) AS Retenido ,TCOMPROBANRETPAT.cproveedor ,TCOMPROBANRETPAT.cidcomprob " +
                                 "FROM TCOMPROBANRETPAT INNER JOIN TPROVEEDOR ON TCOMPROBANRETPAT.cproveedor = TPROVEEDOR.cproveedor AND TCOMPROBANRETPAT.ccompany = TPROVEEDOR.ccompany INNER JOIN TFACTPPAGARM ON TCOMPROBANRETPAT.ccompany = TFACTPPAGARM.ccompany AND TCOMPROBANRETPAT.cproveedor = TFACTPPAGARM.cproveedor AND TCOMPROBANRETPAT.cidcomprobret = TFACTPPAGARM.cnumdocu INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany = TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument = TCONFIGCXP.ctipodocretpat   " +
                                 "WHERE TCOMPROBANRETPAT.caprobado='1' and (TCOMPROBANRETPAT.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCOMPROBANRETPAT.cimpreso = 1) AND (TCOMPROBANRETPAT.canulado = 0) AND (TCOMPROBANRETPAT.cmanual = 1) AND (TPROVEEDOR.cdelete = 0)   and (TFACTPPAGARM.cordenpaghecha = 0) AND (TFACTPPAGARM.cdelete = 0) AND (TFACTPPAGARM.ctotal < 0)  " +
                                 "AND (NOT EXISTS(SELECT cidcomprobretpat FROM TFACTPPAGARM WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cidcomprobretpat = TCOMPROBANRETPAT.cidcomprobret) AND (cestatusfirma = '1'))) " +
                                 "AND NOT EXISTS (SELECT TREPOSICIONESD.cnumdocu " +
                                 "FROM TREPOSICIONESM INNER JOIN TREPOSICIONESD ON TREPOSICIONESM.cgroupcomp = TREPOSICIONESD.cgroupcomp AND TREPOSICIONESM.ccompany = TREPOSICIONESD.ccompany AND TREPOSICIONESM.cidreposiciones = TREPOSICIONESD.cidreposiciones " +
                                 "WHERE (TREPOSICIONESM.cestatusfirma = 1) AND (TREPOSICIONESM.cdelete = 0) AND (TREPOSICIONESD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TREPOSICIONESD.ccompany = '" + Frm_Padre._Str_Comp + "')  AND (TREPOSICIONESD.cnumdocu = TCOMPROBANRETPAT.cidcomprobret) AND (TREPOSICIONESD.ctipodocumentodetalle = '" + (Byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionPatente + "')) ";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "RETENCIONES PATENTE MANUALES", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Ocultamos
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            //Alineamos
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //___________________________________
        }
        private void Frm_Busqueda2_Load(object sender, EventArgs e)
        {
            if (_Int_Sw == 16)
            {
                _Mtd_Verificar_PrefacturasDev();
            }
            else if (_Int_Sw == 43 | _Int_Sw == 44 | _Int_Sw == 26 | _Int_Sw == 46 | _Int_Sw == 47 | _Int_Sw == 48 | _Int_Sw == 49)
            {
                this.Dock = DockStyle.Fill;
            }
            else if (_Int_Sw == 5)
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select id_conteohist from TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + Convert.ToString(_Dg_Row.Cells[0].Value) + "' and cfinalizado='3'"))
                    {
                        _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                    }
                }
            }
        }
        private bool _Mtd_ComprobanteDeTransferencia(string _P_Str_Comprobante)
        {
            string _Str_Sql = "SELECT cdescrip FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND cdescrip LIKE '%TRANSFERENCIA #%'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0;
        }
        private void _Dg_Datagrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //De acuerdo al switch se desencadena una función diferente.
            if (_Dg_Grid.Rows.Count > 0)
            {
                if (_Int_Sw == 1)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_RutaVisitas _Frm = new Frm_RutaVisitas(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex));
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 2)
                {
                    //----------------------------------------
                    PrintDialog _Print = new PrintDialog();
                Print:
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            REPORTESS _Frm;
                            string _Str_Cadena = "";
                            Cursor = Cursors.WaitCursor;
                            _Str_Cadena = "SELECT * FROM vst_facturacomparada WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, _Dg_Grid.CurrentCell.RowIndex) + "' and cproveedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(7, _Dg_Grid.CurrentCell.RowIndex) + "'";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(8, _Dg_Grid.CurrentCell.RowIndex) == "1")
                            { _Frm = new REPORTESS("T3.Report.rFactComparada1", _Ds.Tables[0], _Print, true, "Section1", "cabecera", "rif", "nit", Frm_Padre._Str_Comp); }
                            else
                            { _Frm = new REPORTESS("T3.Report.rFactComparada2", _Ds.Tables[0], _Print, true, "Section1", "cabecera", "rif", "nit", Frm_Padre._Str_Comp); }
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿Se Imprimio correctamente el comprobante?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                _Frm.Close(); _Frm.Dispose(); goto Print;
                            }
                            else
                            {
                                _Frm.Close(); _Frm.Dispose();
                                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(8, _Dg_Grid.CurrentCell.RowIndex) == "1")
                                {
                                    _Str_Cadena = "Update TRECEPCIONDDDOCF Set cimpreso='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and   cidrecepcion='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, _Dg_Grid.CurrentCell.RowIndex) + "' and cproveedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(7, _Dg_Grid.CurrentCell.RowIndex) + "' and cnfacturapro='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, _Dg_Grid.CurrentCell.RowIndex) + "' and cnumoc='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, _Dg_Grid.CurrentCell.RowIndex) + "' and cfaltante='1'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                                else
                                {
                                    _Str_Cadena = "Update TRECEPCIONDDDOCF Set cimpreso='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and   cidrecepcion='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, _Dg_Grid.CurrentCell.RowIndex) + "' and cproveedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(7, _Dg_Grid.CurrentCell.RowIndex) + "' and cnfacturapro='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, _Dg_Grid.CurrentCell.RowIndex) + "' and cnumoc='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, _Dg_Grid.CurrentCell.RowIndex) + "' and cfaltante='2'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Mtd_Actualizar_Sw2();
                            }
                        }
                        catch (Exception _Ex) { Cursor = Cursors.Default; MessageBox.Show("Error al realizar la operación.\n" + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                else if (_Int_Sw == 4)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Cadena = "SELECT cidcomprobret FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex) + "' AND cmanual='1'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_CompRetencionManual _Frm = new Frm_CompRetencionManual(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex));
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                    }
                    else
                    {
                        Frm_CompRetencion _Frm = new Frm_CompRetencion(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex));
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show(); 
                    }
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 5)
                {
                    //Formulario Nuevo
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICOREPORTE" }, "", "T3.Report.rComparativo", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex) + "'");
                    _Frm_R.MdiParent = this.MdiParent;
                    _Frm_R.Dock = DockStyle.Fill;
                    _Frm_R.Show();
                    Cursor = Cursors.Default;
                }

                else if (_Int_Sw == 6)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ComprobISLR _Frm = new Frm_ComprobISLR(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex));
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    _Mtd_Actualizar_Sw6();
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 7)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 9)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 12)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 13)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 14)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 15)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 16)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 17)
                {
                    this._Str_FrmResult = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 18)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 19)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_NotaDebitoCxC _Frm = new Frm_NotaDebitoCxC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), this.MdiParent);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 20)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_NotaCreditoCxC _Frm = new Frm_NotaCreditoCxC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex), this.MdiParent);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 21)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 22)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 23)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ConsultaCajaAbierta _Frm = new Frm_ConsultaCajaAbierta(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex));
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 24)
                {
                    _Str_FrmResult = "1";
                    this.Close();
                }
                else if (_Int_Sw == 25)
                {
                    _Str_FrmResult = "1";
                    this.Close();
                }
                else if (_Int_Sw == 26)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_RutaVisitas _Frm = new Frm_RutaVisitas();
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 27)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 28)
                {
                    _Str_FrmResult = "1";
                    this.Close();
                }
                else if (_Int_Sw == 29)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 30)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ImpresionLote _Frm = new Frm_ImpresionLote(8, _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex));
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 31)
                {
                    Cursor = Cursors.WaitCursor;
                    DataSet _Ds_DataSet = new DataSet();
                    string _Str_Finalizado = "0";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cfinalizado from TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' AND id_conteohist='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex) + "'");
                    foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                    {
                        _Str_Finalizado = _Dtw_Item["cfinalizado"].ToString();
                    }
                    if (_Str_Finalizado == "1")
                    {
                        Frm_AjusInventario _Frm = new Frm_AjusInventario(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex));
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                    }
                    else
                    {
                        MessageBox.Show(this, "No puede ajustar el conteo hasta que se finalice el proceso de verificación de conteo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 32)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 33)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 34)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 35)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 36)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 37)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 38 || _Int_Sw == 39 || _Int_Sw == 40)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 42)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 43)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Cliente = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, _Dg_Grid.CurrentCell.RowIndex);
                    string _Str_ClienteD = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, _Dg_Grid.CurrentCell.RowIndex);
                    string _Str_Rif = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, _Dg_Grid.CurrentCell.RowIndex);
                    Frm_EstatusClientes _Frm_ECliente = new Frm_EstatusClientes(3);
                    Frm_EstatusClientesDetalle _Frm = new Frm_EstatusClientesDetalle(_Str_Cliente, _Str_Rif, _Str_ClienteD, 3, _Str_Cliente, _Frm_ECliente);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 45)
                {
                    if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) != null)
                    {
                        if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex).ToUpper() == "D")
                        {
                            _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                            _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Solo se debe seleccionar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else if (_Int_Sw == 46 | _Int_Sw == 47 | _Int_Sw == 48)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ComprobanteContable _Frm = new Frm_ComprobanteContable(Convert.ToInt32(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex)));
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 49)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Sql = "SELECT CMONTACCO, CYEARACCO FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' AND creabierto='0' AND CONVERT(DATETIME,'1/' + CONVERT(VARCHAR(2), cmontacco) + '/' + CONVERT(VARCHAR(4), cyearacco))<CONVERT(DATETIME,'1/" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "/" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex) + "')";
                    DataSet _Ds;
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Existen meses anteriores sin cerrar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        _Str_Sql = "SELECT cmontacco, cyearacco FROM tcalendcont WHERE cdiafecha_cal = CONVERT(DATETIME, CONVERT(VARCHAR(11), GETDATE()))";
                        DataSet _Ds_Con;
                        _Ds_Con = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_Con.Tables[0].Rows.Count > 0)
                        {
                            string Str_mes = "";
                            string Str_anio = "";

                            Str_mes = Convert.ToString(_Ds_Con.Tables[0].Rows[0]["cmontacco"]).Trim();
                            Str_anio = Convert.ToString(_Ds_Con.Tables[0].Rows[0]["cyearacco"]).Trim();
                            if (Convert.ToDateTime("1/" + Str_mes + "/" + Str_anio) > Convert.ToDateTime("1/" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "/" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex)))
                            {
                                Frm_MsjCierreContable _Frm = new Frm_MsjCierreContable(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex));
                                _Frm.MdiParent = this.MdiParent;
                                _Frm.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se puede cerrar el Mes Contable", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 50)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 51)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("N# Documento", e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cidfactxp", e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 52)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 53)
                {
                    Frm_NotaCreditoCxC _Frm = new Frm_NotaCreditoCxC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), this.MdiParent);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 54)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 55)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 56)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 57)
                {
                    _Str_FrmResult = "1";
                    this.Close();
                }
                else if (_Int_Sw == 58)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_DevolVenta _Frm = new Frm_DevolVenta(this, _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Factura", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("ccliente", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Cliente", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("c_motdevolcion", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cvendedor", e.RowIndex));
                    Cursor = Cursors.Default;
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                }
                else if (_Int_Sw == 59)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 60)
                {
                    MessageBox.Show("Se va a imprimir el comprobante. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PrintDialog _Print = new PrintDialog();
                Print:
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (_Mtd_ComprobanteDeTransferencia(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex)))
                            {
                                Cursor = Cursors.WaitCursor;
                                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) + "'", _Print, true);
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                REPORTESS _Frm = new REPORTESS(new string[] { "VST_COMPROP_CHEQUE_EGRESO" }, "", "T3.Report.rComprobanEgresoCheque", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidemisioncheq='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "' AND cproveedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex) + "'", _Print, true);
                                Cursor = Cursors.Default;
                            }
                            if (MessageBox.Show("¿Se Imprimio correctamente el comprobante?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            { goto Print; }
                            else
                            {
                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) + "'");
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Mtd_Actualizar_Sw60();
                            }
                        }
                        catch { Cursor = Cursors.Default; }
                    }
                }
                else if (_Int_Sw == 62)
                {
                    MessageBox.Show("Se va a imprimir el reporte de Egreso de Cheques en Tránsito. Coloque el tipo de papel para este documento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PrintDialog _Print = new PrintDialog();
                Print:
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_TEGRECHEQTRAN" }, "", "T3.Report.rEgreCheqTrans", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "' AND cimpreso='0'", _Print, true);
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿Se imprimió correctamente el reporte de Egreso de Cheques en Tránsito?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            { goto Print; }
                            else
                            {
                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TEGRECHEQTRAN", "cimpreso='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "' AND cimpreso='0'");
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Mtd_Actualizar_Sw62();
                            }
                        }
                        catch { Cursor = Cursors.Default; }
                    }
                }
                else if (_Int_Sw == 63)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ASCII_FAC _Frm = new Frm_ASCII_FAC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda("Factura", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Recepción", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cproveedor", e.RowIndex));
                    Cursor = Cursors.Default;
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 64)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 65)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 66)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 67)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 68)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 69)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 70)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 71)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 72)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 73)
                {
                    string _Str_Cadena = "SELECT cidnotadebitocxp FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "' AND cestatusfirma='3' AND cimpresa='0'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        string _P_Str_ND = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                        try
                        {
                            int _Int_Switch = 0;
                            REPORTESS _Frm;
                            PrintDialog _Print = new PrintDialog();
                        _PrintComprob:
                            if (_Print.ShowDialog() == DialogResult.OK)
                            {
                                if (_Int_Switch == 0 | _Int_Switch == 1)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    _Frm = new REPORTESS(new string[] { "VST_NOTADEBITO_SINDET" }, "", "T3.Report.rNotaDebitoSDet", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _P_Str_ND + "'", _Print, true);
                                    Cursor = Cursors.Default;
                                    _Frm.ShowDialog();
                                    if (MessageBox.Show("¿La ND se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        _Frm.Close();
                                        _Frm.Dispose();
                                        _Int_Switch = 1;
                                        goto _PrintComprob;
                                    }
                                    else
                                    {
                                    A:
                                        string _Str_Numero = InputBox.Show("Introduzca el número de control").Text;
                                        if (_Str_Numero.Trim().Length > 0)
                                        {
                                            _Str_Cadena = "Select cnumcontrolnd from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cnumcontrolnd='" + _Str_Numero + "'";
                                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                                            {
                                                MessageBox.Show("El número de control del documento ya fue registrado. Debe intentarlo nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                                goto A;
                                            }
                                            else
                                            {
                                                _Int_Switch = 0;
                                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cnumcontrolnd='" + _Str_Numero + "',cestatusfirma='2',cimpresa='1',cactivo='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _P_Str_ND + "'");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Debe ingresar el número de control", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                            goto A;
                                        }
                                    }
                                }
                                if (_Int_Switch == 0 | _Int_Switch == 2)
                                {
                                    if (_Int_Switch == 0)
                                    { MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Int_Switch = 2; goto _PrintComprob; }
                                    Cursor = Cursors.WaitCursor;
                                    _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'", _Print, true);
                                    Cursor = Cursors.Default;
                                    if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        _Frm.Close();
                                        _Frm.Dispose();
                                        goto _PrintComprob;
                                    }
                                    else
                                    {
                                        _Frm.Close();
                                        _Frm.Dispose();
                                        _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                                        MessageBox.Show("El comprobante ha sido actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        _Mtd_Actualizar_Sw73();
                                    }
                                }
                            }
                        }
                        catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("Se va a imprimir el comprobante. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PrintDialog _Print = new PrintDialog();
                    Print:
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'", _Print, true);
                                Cursor = Cursors.Default;
                                if (MessageBox.Show("¿Se Imprimio correctamente el comprobante?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                { goto Print; }
                                else
                                {
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'");
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _Mtd_Actualizar_Sw73();
                                }
                            }
                            catch { Cursor = Cursors.Default; }
                        }
                    }
                }
                else if (_Int_Sw == 74)
                {
                    if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) != null)
                    {
                        if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex).ToUpper() == "D")
                        {
                            _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                            _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Solo se debe seleccionar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else if (_Int_Sw == 75)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 76)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 79)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 80)
                {
                    this._Str_FrmResult = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 83)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_RecepcionB _Frm = new Frm_RecepcionB(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), 0);
                    Cursor = Cursors.Default;
                    _Frm.Text = "Facturas de recepciones pendientes";
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 84)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_RecepcionC _Frm = new Frm_RecepcionC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                    Cursor = Cursors.Default;
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 85)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_RecepcionB _Frm = new Frm_RecepcionB(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), 1);
                    Cursor = Cursors.Default;
                    _Frm.Text = "Facturas de recepciones mal cargadas";
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 86)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_RecepcionB _Frm = new Frm_RecepcionB(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), 2);
                    Cursor = Cursors.Default;
                    _Frm.Text = "Facturas de recepciones aprobadas";
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 87)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 88)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 89)
                {
                    Frm_NotaCreditoCxC _Frm = new Frm_NotaCreditoCxC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), this.MdiParent);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 90)
                {
                    Frm_NotaDebitoCxC _Frm = new Frm_NotaDebitoCxC(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), this.MdiParent);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 91)
                {
                    _Str_FrmResult = "1";
                    this.Close();
                }
                else if (_Int_Sw == 92)
                {
                    _Str_FrmResult = "1";
                    this.Close();
                }
                else if (_Int_Sw == 93)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 94)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_FrmResult = "1";
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 95)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 96)
                {
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 97)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ConciliacionBancariaV2 _Frm = new Frm_ConciliacionBancariaV2(int.Parse(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
                    Cursor = Cursors.Default;
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 98)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_AprobConcManuales _Frm = new Frm_AprobConcManuales(int.Parse(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
                    Cursor = Cursors.Default;
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
                else if (_Int_Sw == 99)
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                    this.Close();
                }
                else if (_Int_Sw == 100)
                {
                    _G_Str_Resultados = new string[2];

                    _G_Str_Resultados[0] = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                    _G_Str_Resultados[1] = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex);

                    Close();
                }
                else if (_Int_Sw == 101)
                {
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else if (_Int_Sw == 102) //RETENCIONES ISLR MANUALES
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                    Close();
                }
                else if (_Int_Sw == 103) //RETENCIONES IVA MANUALES
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                    Close();
                }
                else if (_Int_Sw == 104) //RETENCIONES PATENTE MANUALES
                {
                    _Txt_Textbox1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(_Int_Col_Index1, e.RowIndex);
                    _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                    Close();
                }
            }
        }

        private void Frm_Busqueda2_Activated(object sender, EventArgs e)
        {
            //CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Rbt_Ser_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Ser.Checked)
            { _Mtd_Actualizar_Sw3_Tipo(0); }
        }

        private void _Rbt_Mat_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Mat.Checked)
            { _Mtd_Actualizar_Sw3_Tipo(1); }
        }

        private void _Rbt_Otros_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Otros.Checked)
            { _Mtd_Actualizar_Sw3_Tipo(2); }
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                if (_Int_Sw == 7)
                {
                    Frm_FacturasCargadas _Frm = new Frm_FacturasCargadas(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[2].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                }
                else if (_Int_Sw == 8)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(81, " AND cproveedor='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim() + "'");
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog(this);
                }
            }
        }

        private void _Ctrl_Contex1_MItem1_Click(object sender, EventArgs e)
        {
            _Str_FrmResult = "";
            _Str_RutasPrefacturas=null;
            _Str_RutasPrefacturas = new string[_Dg_Grid.SelectedRows.Count, 3];
            int _Int_Contador = 0;
            foreach (DataGridViewRow _DgRow in _Dg_Grid.SelectedRows)
            {
                if (_Int_Sw == 16)
                { _Str_FrmResult = _Str_FrmResult + Convert.ToString(_DgRow.Cells[1].Value) + ","; }
                else
                {
                    _Str_RutasPrefacturas[_Int_Contador, 0] = Convert.ToString(_DgRow.Cells[0].Value);
                    _Str_RutasPrefacturas[_Int_Contador, 1] = Convert.ToString(_DgRow.Cells[1].Value);
                    _Str_RutasPrefacturas[_Int_Contador, 2] = Convert.ToString(_DgRow.Cells[2].Value);
                }
                _Int_Contador++;
            }
            if (_Str_FrmResult.Length > 0)
            {
                _Str_FrmResult = _Str_FrmResult.Remove(_Str_FrmResult.Length - 1);
            }
            this.Close();

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

        private void _Ctrl_Contex1_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell == null || _Dg_Grid.SelectedRows.Count < 1)
            {
                e.Cancel = true;
            }
        }

        private void _Dg_Grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _Dg_Grid.Rows[e.RowIndex].Selected = true;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Grid.CurrentCell != null)
                {
                    if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTAR_COMPARATIVO"))
                    {
                        string _Str_IdConteo = _Dg_Grid[0, _Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                        if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select id_conteohist from TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Str_IdConteo + "' and cfinalizado='3'"))
                        {
                            //Formulario Nuevo
                            //Frm_VerificaConteo _Frm_Form = new Frm_VerificaConteo(true, _Str_IdConteo);
                            Frm_FisicoVsTeorico _Frm_Form = new Frm_FisicoVsTeorico(this, _Int_Sw, _Str_IdConteo);
                            _Frm_Form.MdiParent = this.MdiParent;
                            _Frm_Form.Show();
                        }
                        else
                        {
                            MessageBox.Show("Ya el comparativo seleccionado fue finalizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene permisos para realizar la edición", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch
            {
            }
        }

        private void _Dg_Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Int_Sw == 16)
            {
                if (_Dg_Grid.RowCount > 0)
                {
                    _Mtd_Verificar_PrefacturasDev();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Grid.CurrentCell != null)
                {
                    string _Str_Factura = _Dg_Grid[0, _Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                    Frm_FacturasDevueltaDetalle _Frm_Form = new Frm_FacturasDevueltaDetalle(_Str_Factura, Frm_Padre._Str_Comp);
                    //_Frm_Form.ShowDialog();
                    _Frm_Form.MdiParent = this.MdiParent;
                    //_Frm_Form.Dock = DockStyle.Fill;
                    _Frm_Form.Show();
                    Cursor = Cursors.Default;

                }
                else
                {
                    MessageBox.Show("Seleccione una factura para la consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
            }
        }

        private void _Ctrl_Busqueda1_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Filtrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar_Sw21();
            Cursor = Cursors.Default;
        }

        private void _Tol_Txt_Ver_Click(object sender, EventArgs e)
        {
            Frm_ConsultaPreFacturaDetalle _Frm = new Frm_ConsultaPreFacturaDetalle(_Ctrl_Busqueda1._Mtd_RetornarStringCelda("Pre-Factura", _Dg_Grid.CurrentCell.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Compañía", _Dg_Grid.CurrentCell.RowIndex));
            _Frm.ShowDialog(this);
        }

        private void _Rb_Act_CheckedChanged(object sender, EventArgs e)
        {
            if (_Int_Sw == 64)
            { _Mtd_Actualizar_Sw64(); }
            else if (_Int_Sw == 66)
            { _Mtd_Actualizar_Sw66(); }
            else if (_Int_Sw == 69)
            { _Mtd_Actualizar_Sw69(); }
            else if (_Int_Sw == 87)
            { _Mtd_Actualizar_Sw87(); }
        }

        private bool _Mtd_PreFacturaTieneFacturasDevueltasParaAnular(string cpfactura)
        {
            string _Str_SQL = "SELECT TFACTURAM.cpfactura, TFACTURAM.cfactura, TGUIADESPACHOD.c_estatus FROM TFACTURAM INNER JOIN TGUIADESPACHOD ON TFACTURAM.cgroupcomp = TGUIADESPACHOD.cgroupcomp AND TFACTURAM.ccompany = TGUIADESPACHOD.ccompany AND TFACTURAM.cfactura = TGUIADESPACHOD.cfactura WHERE (TFACTURAM.cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (TFACTURAM.cpfactura = " + cpfactura + ") AND (TGUIADESPACHOD.c_devanular = 1) AND (TGUIADESPACHOD.c_estatus = 'DEV') AND NOT EXISTS (SELECT cfactura FROM TFACTURANUL WHERE TGUIADESPACHOD.ccompany = ccompany AND TGUIADESPACHOD.cfactura = cfactura)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return true; else return false;
        }

        public Frm_Busqueda2(int _Int_Sw, string _Str_ParametroString1, string _Str_ParametroString2, string _Str_ParametroString3)
        {
            InitializeComponent();

            switch (_Int_Sw)
            {
                case 80: _Mtd_Actualizar_Sw80(_Str_ParametroString1, _Str_ParametroString2, _Str_ParametroString3); this.Text = "DOCUMENTOS PROVEEDOR"; break;
            }

        }
        public Frm_Busqueda2(int _P_Int_Sw, string _P_Str_Param1, string _P_Str_Param2)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;

            if (_P_Int_Sw == 91)
            {
                _Str_Param1 = _P_Str_Param1;
                _Str_Param2 = _P_Str_Param2;
                _Mtd_Actualizar_Sw91();
                this.Text = "DOCUMENTOS INTERCOMPAÑIA COBRADOS";
            }
            else if (_P_Int_Sw == 92)
            {
                _Str_Param1 = _P_Str_Param1;
                _Str_Param2 = _P_Str_Param2;
                _Mtd_Actualizar_Sw92();
                this.Text = "DOCUMENTOS INTERCOMPAÑIA DE PAGO";
            }

        }
    }
}