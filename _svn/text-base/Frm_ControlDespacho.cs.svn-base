using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
namespace T3
{
    public partial class Frm_ControlDespacho : Form
    {
        int _Int_Estatus = 4;
        int _Int_EstatusPre = 0;
        int _Int_Imprimir = 0;
        int _Int_FrmNumPreFactAdd = 0;
        int _Int_FrmClaveProceso = 0;
        string _G_Str_ClienteAcc = "";
        string _G_Str_ClienteCompRela = "";
        string _G_Str_ClienteEmpl = "";
        string _G_Str_ClienteTransp = "";
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_FrmRutasAdd = "";
        public Frm_ControlDespacho()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
            _Mtd_Actualizar_Dg_GridTrasportes();
            //_Mtd_Actualizar_Dg_GridPreFacturas(_Int_Estatus, _Tool_Consulta.Text);
            _Dg_GridPreFacturas.ClearSelection();
            _Mtd_IniPreCarga();
            _Mtd_CrearDataSet();
            _Mtd_CargarCampoCliente();
            _Mtd_CargarTipoCliente();
            _Mtd_CargarTipoPrecarga();
        }
        DataSet _Ds_DataSetGen = new DataSet();
        private void _Mtd_CrearDataSet()
        {
            _Ds_DataSetGen = new DataSet();
            DataTable _Dta_Tabla = new DataTable("Prefacturas");
            DataColumn _Dta_Columna = new DataColumn("cprecarga", System.Type.GetType("System.String"));
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn("cpfactura", System.Type.GetType("System.String"));
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn("cedicion", System.Type.GetType("System.String"));
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn("cfechaedicion", System.Type.GetType("System.String"));
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Ds_DataSetGen.Tables.Add(_Dta_Tabla);
        }
        public Frm_ControlDespacho(string _Pr_Str_PrecargaSinCulminar)
        {
            InitializeComponent();
            _Mtd_CrearDataSet();
            _Mtd_Color_Estandar(this);
            if (_Pr_Str_PrecargaSinCulminar == "PS")
            {
                toolStripSplitButton1.Enabled = false;
                toolStripSplitButton4.Enabled = true;
                _Int_EstatusPre = 4; 
            }
            _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
            _Mtd_Actualizar_Dg_GridTrasportes();
            _Dg_GridPreFacturas.ClearSelection();
            _Mtd_IniPreCarga();
            _Mtd_CargarCampoCliente();
            _Mtd_CargarTipoCliente();
            _Mtd_CargarTipoPrecarga();
            if (_Pr_Str_PrecargaSinCulminar == "PS")
            {
                _Tb_Tab.SelectTab(2);
            }
        }

        public Frm_ControlDespacho(int _P_Int_Estatus)
        {
            InitializeComponent();
            _Mtd_CrearDataSet();
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
            _Mtd_Actualizar_Dg_GridTrasportes();
            _Dg_GridPreFacturas.ClearSelection();
            _Mtd_IniPreCarga();
            _Mtd_CargarCampoCliente();
            _Mtd_CargarTipoCliente();
            _Mtd_CargarTipoPrecarga();
            _Int_Estatus = _P_Int_Estatus;
        }

        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Actualizar_Dg_GridPreFacturas(int _P_Int_Estatus, string _P_Str_Prefactura)
        {
            string _Str_Cadena = "";
            if (_P_Int_Estatus < 0) { _P_Int_Estatus = _Int_Estatus; _P_Str_Prefactura = _Tool_Consulta.Text; }//Si entra aqui es porque se esta actualizando desde el formulario Frm_ConsultaPreFacturaDetalle

            _Str_Cadena = "SELECT TOP 100 PERCENT CASE WHEN RTRIM(TCOTPEDFACM.cobservaciones) <> '' THEN 'SI' ELSE 'NO' END AS c_pedidotieneobs, dbo.VST_PREFACTURAS_CTRLDESP.ccompany, CONVERT(varchar, dbo.VST_PREFACTURAS_CTRLDESP.c_fecha_pedido, 103) AS c_fecha_pedido, dbo.VST_PREFACTURAS_CTRLDESP.cpedido, dbo.VST_PREFACTURAS_CTRLDESP.cpfactura, RTRIM(dbo.VST_PREFACTURAS_CTRLDESP.c_nomb_comer) AS c_nomb_comer, dbo.VST_PREFACTURAS_CTRLDESP.cname, dbo.VST_PREFACTURAS_CTRLDESP.cempaques, dbo.VST_PREFACTURAS_CTRLDESP.cunidades, dbo.VST_PREFACTURAS_CTRLDESP.ruta_descrip, dbo.VST_PREFACTURAS_CTRLDESP.NameEstado, dbo.VST_PREFACTURAS_CTRLDESP.NameCiudad, dbo.Fnc_Formatear(dbo.VST_PREFACTURAS_CTRLDESP.c_montotot_si) AS c_montotot_si, dbo.VST_PREFACTURAS_CTRLDESP.ccliente, dbo.VST_PREFACTURAS_CTRLDESP.cfacturado, dbo.VST_PREFACTURAS_CTRLDESP.clistofacturar, dbo.VST_PREFACTURAS_CTRLDESP.cprecarga, dbo.VST_PREFACTURAS_CTRLDESP.cbackorder, dbo.VST_PREFACTURAS_CTRLDESP.cvendedor, dbo.VST_PREFACTURAS_CTRLDESP.c_factdevuelta, dbo.VST_PREFACTURAS_CTRLDESP.c_factdevuelta_descrip, CASE WHEN cfechaaprobcred IS NULL THEN DATEDIFF(d, CONVERT(datetime, VST_PREFACTURAS_CTRLDESP.c_fecha_pedido), GETDATE()) ELSE DATEDIFF(d, CONVERT(datetime, cfechaaprobcred), GETDATE()) END AS DiasT,VST_PREFACTURAS_CTRLDESP.FacturaaAnular as FacturaaAnular FROM dbo.VST_PREFACTURAS_CTRLDESP INNER JOIN dbo.TCOTPEDFACM ON dbo.VST_PREFACTURAS_CTRLDESP.cpedido = dbo.TCOTPEDFACM.cpedido AND dbo.VST_PREFACTURAS_CTRLDESP.ccompany = dbo.TCOTPEDFACM.ccompany ";

            if (_P_Str_Prefactura.Trim().Length == 0)
            {
                if (_P_Int_Estatus == 0)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0')) "; }
                else if (_P_Int_Estatus == 1)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0')) "; }
                else if (_P_Int_Estatus == 2)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and (VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') "; }
                else if (_P_Int_Estatus == 3)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.cfacturado='1' and VST_PREFACTURAS_CTRLDESP.c_factdevuelta='0') or (VST_PREFACTURAS_CTRLDESP.cfacturado='1' and VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0')) "; }
                else if (_P_Int_Estatus == 4)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') OR (VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0')) "; }
            }
            else
            {
                if (_P_Int_Estatus == 0)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cpfactura LIKE '" + _P_Str_Prefactura + "%' and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.cfacturado='1') or (VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0')) "; }
                else if (_P_Int_Estatus == 1)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cpfactura LIKE '" + _P_Str_Prefactura + "%' and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0')) "; }
                else if (_P_Int_Estatus == 2)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cpfactura LIKE '" + _P_Str_Prefactura + "%' and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and (VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') "; }
                else if (_P_Int_Estatus == 3)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cpfactura LIKE '" + _P_Str_Prefactura + "%' and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.cfacturado='1' and VST_PREFACTURAS_CTRLDESP.c_factdevuelta='0') or (VST_PREFACTURAS_CTRLDESP.cfacturado='1' and VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0')) "; }
                else if (_P_Int_Estatus == 4)
                { _Str_Cadena += "where " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_PREFACTURAS_CTRLDESP.ccompany") + " and VST_PREFACTURAS_CTRLDESP.cpfactura LIKE '" + _P_Str_Prefactura + "%' and VST_PREFACTURAS_CTRLDESP.cdelete='0' and VST_PREFACTURAS_CTRLDESP.c_facturaanul=0 and ((VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') OR (VST_PREFACTURAS_CTRLDESP.clistofacturar='1' and VST_PREFACTURAS_CTRLDESP.cprecarga>'0' and VST_PREFACTURAS_CTRLDESP.cfacturado='0') or (VST_PREFACTURAS_CTRLDESP.c_factdevuelta='1' and VST_PREFACTURAS_CTRLDESP.cprecarga='0')) "; }
            }

            _Str_Cadena += "ORDER BY VST_PREFACTURAS_CTRLDESP.cpfactura, VST_PREFACTURAS_CTRLDESP.c_fecha_pedido DESC ";

            Cursor = Cursors.WaitCursor;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridPreFacturas.DataSource = _Ds.Tables[0];
            _Dg_GridPreFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            _Dg_GridPreFacturas.ClearSelection();
            _Mtd_Verificar_PrefacturasDev();
        }
        private void _Mtd_Actualizar_Dg_GridPrecarga(int _P_Int_Estatus)
        {
            string _Str_Cadena = "";
            if (_P_Int_Estatus == 0)
            {
                _Str_Cadena = "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,Transporte,cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp,CTIPOCLIENTE from VST_PRECARGA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and (cimprimeprecarga='1' and cverificascanpalm='1' and cimprimefactura='0' and cimprimeguiadesp='0' AND cplaca<>'0' AND ccedula<>'0')";
                _Str_Cadena += " UNION ";
                _Str_Cadena += "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,'SIN TRANSPORTE' as Transporte,'SIN TRANSPORTISTA' as cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp, CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS CTIPOCLIENTE from TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and (cimprimeprecarga='0')";
                _Str_Cadena += " UNION ";
                _Str_Cadena += "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,'SIN TRANSPORTE' as Transporte,'SIN TRANSPORTISTA' as cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp, CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS CTIPOCLIENTE from TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim  where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and (cimprimeprecarga='1') and (cverificascanpalm='0') order by cprecarga,cfechaprecarga DESC";
            }
            else if (_P_Int_Estatus == 1)
            { _Str_Cadena = "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,'SIN TRANSPORTE' as Transporte,'SIN TRANSPORTISTA' as cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp, CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS CTIPOCLIENTE from TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim  where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and (cimprimeprecarga='0') order by cprecarga,cfechaprecarga DESC"; }
            else if (_P_Int_Estatus == 2)
            { _Str_Cadena = "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,'SIN TRANSPORTE' as Transporte,'SIN TRANSPORTISTA' as cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp, CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS CTIPOCLIENTE from TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim  where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and (cimprimeprecarga='1') and (cverificascanpalm='0') order by cprecarga,cfechaprecarga DESC"; }
            else if (_P_Int_Estatus == 3)
            { _Str_Cadena = "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,Transporte,cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp,CTIPOCLIENTE from VST_PRECARGA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and (cimprimeprecarga='1' and cverificascanpalm='1' and cimprimefactura='0' and cimprimeguiadesp='0' AND cplaca<>'0' AND ccedula<>'0') order by cprecarga,cfechaprecarga DESC"; }
            else if (_P_Int_Estatus == 4)
            { _Str_Cadena = "Select convert(varchar, cfechaprecarga,103) as cfechaprecarga,cprecarga,'SIN TRANSPORTE' as Transporte,'SIN TRANSPORTISTA' as cnombre,ctotalempaq,ctotalunidad,ctotalkg,cplaca,ccedula,cimprimeprecarga,cverificascanpalm,cimprimefactura,cimprimeguiadesp, CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS CTIPOCLIENTE from TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim  where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimprimeprecarga=0 OR cverificascanpalm=0 order by cprecarga,cfechaprecarga DESC"; }
            Cursor = Cursors.WaitCursor;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridPrecarga.DataSource = _Ds.Tables[0];
            _Dg_GridPrecarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            _Dg_GridPrecarga.ClearSelection();
        }
        private void _Mtd_Actualizar_Dg_GridTrasportes()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(cplaca) AS cplaca, RTRIM(cmodelo) AS cmodelo, RTRIM(cname) AS cname, ccapcarg, cesperando, cintext, cultfechaasig " +
            "FROM VST_TRANSPORTES_DISP where cesperando = '1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridTrasportes.DataSource = _Ds.Tables[0];
            _Dg_GridTrasportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;            
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar_Dg_GridTrasportesAll()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(cplaca) AS cplaca, RTRIM(cmodelo) AS cmodelo, RTRIM(cname) AS cname, ccapcarg, cesperando, cintext, cultfechaasig " +
            "FROM VST_TRANSPORTES_DISP ORDER BY cesperando";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridTrasportes.DataSource = _Ds.Tables[0];
            _Dg_GridTrasportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewRow _DgRow in _Dg_GridTrasportes.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_DgCol_cesperando"].Value).Trim()!="1")
                {
                    _DgRow.DefaultCellStyle.BackColor = Color.Khaki;
                }
            }
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar_Dg_GridVerificacion(string _P_Str_Precarga)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT TPRECARGASCANPAL.cproducto as Producto, TPRECARGADPFD.cpempaques as [Emp. Pre-Factura], TPRECARGADPFD.cpunidades as [Unid. Pre-Factura], TPRECARGASCANPAL.cgempaques as [Emp. Pre-Carga], " +
"TPRECARGASCANPAL.cgunidades as [Unid. Pre-Carga] " +
"FROM TPRECARGASCANPAL INNER JOIN " +
"TPRECARGADPFD ON TPRECARGASCANPAL.cgroupcomp = TPRECARGADPFD.cgroupcomp AND " +
"TPRECARGASCANPAL.cprecarga = TPRECARGADPFD.cprecarga AND TPRECARGASCANPAL.cproducto = TPRECARGADPFD.cproducto " +
"WHERE (TPRECARGASCANPAL.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGASCANPAL.cprecarga = '" + _P_Str_Precarga + "') AND (cdifempaques>0 or cdifereunidades>0)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridVerificacion.DataSource = _Ds.Tables[0];
            _Dg_GridVerificacion.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_GridVerificacion.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_GridVerificacion.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_GridVerificacion.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_GridVerificacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private string _Mtd_verificarTransportista(string _P_Str_Cedula)
        {
            string _Str_Cadena = "select cdc_fec_liccondu,cdc_fec_certsalud,cdc_fec_permsanit,cdc_fec_rcv,cpropietario from TTRANSPORTISTA where cplaca='" + _Txt_Placa.Text + "' and ccedula='" + _P_Str_Cedula + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_Cadena = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cdc_fec_liccondu"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_liccondu"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " la licencia para conducir,";}
                }
                if (_Ds.Tables[0].Rows[0]["cdc_fec_certsalud"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_certsalud"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " el certificado de Salud,"; }
                }
                if (_Ds.Tables[0].Rows[0]["cdc_fec_permsanit"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_permsanit"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " el permiso sanitario,";  }
                }
                if (_Ds.Tables[0].Rows[0]["cdc_fec_rcv"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_rcv"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " el permiso sanitario,"; }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cpropietario"]) == "1")
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cdc_fec_rcv"]) != "")
                    {
                        if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_rcv"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                        { _Str_Cadena = _Str_Cadena + " la fecha de vencimiento de responsabilidad civil."; }
                    }
                }
            }
            return _Str_Cadena;
        }
        private string _Mtd_BuscarLimites(string _P_Str_Placa)
        {
            string _Str_Cadena = "Select calto,cancho,cprofundidad,ctttransporte,ccapcarg from TTRANSPORTE where cplaca='" + _P_Str_Placa + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_Alto = 0;
            double _Dbl_Ancho = 0;
            double _Dbl_Profundidad = 0;
            double _Dbl_LimiteMt = 0;
            double _Dbl_LimiteKg=0;
            double _Dbl_LimiteBs=0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Dbl_Alto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString()); }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                { _Dbl_Ancho = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); }
                if (_Ds.Tables[0].Rows[0][2] != System.DBNull.Value)
                { _Dbl_Profundidad = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString()); }
                _Dbl_LimiteMt = _Dbl_Alto * _Dbl_Ancho * _Dbl_Profundidad;
                if (Convert.ToString(_Ds.Tables[0].Rows[0][4]) != "")
                {
                    _Dbl_LimiteKg = Convert.ToDouble(_Ds.Tables[0].Rows[0][4]);
                }
                //---------------------------------------------------------------------------
                if (_Ds.Tables[0].Rows[0][3].ToString().Trim().Length > 0)
                {
                    _Str_Cadena = "Select climitekg,climitebs from TTTRANSPORTE where cttransporte='" + _Ds.Tables[0].Rows[0][3].ToString().Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Dbl_LimiteBs = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); }
                    }
                }
            }
            _Str_Cadena = "";
            if (_Dbl_LimiteKg == 0)
            { _Str_Cadena = "La Capacidad de carga Kg."; }
            if (_Dbl_LimiteMt == 0)
            {
                if (_Dbl_LimiteKg == 0)
                { _Str_Cadena = _Str_Cadena + ", Capacidad de carga Mts"; }
                else
                { _Str_Cadena = _Str_Cadena + "La Capacidad de carga Mts"; }
            }
            if (_Dbl_LimiteBs == 0)
            {
                if (_Dbl_LimiteKg == 0 | _Dbl_LimiteMt == 0)
                { _Str_Cadena = _Str_Cadena + ", Límite en  Bs. / Bs.F."; }
                else
                { _Str_Cadena = _Str_Cadena + "El Límite en  Bs. / Bs.F."; }
            }
            _Txt_Mt.Text = _Dbl_LimiteMt.ToString();
            _Txt_Kg.Text = _Dbl_LimiteKg.ToString();
            _Txt_Bs.Text = _Dbl_LimiteBs.ToString("#,##0.00");
            _Prb_Kg.Maximum = Convert.ToInt32(_Dbl_LimiteKg);
            _Prb_Mt.Maximum = Convert.ToInt32(_Dbl_LimiteMt);
            _Prb_Bs.Maximum = Convert.ToInt32(_Dbl_LimiteBs);
            return _Str_Cadena;
        }
        private string _Mtd_Imp_Selec1()
        {
            string _Str_Cadena = " AND cidrutdespacho NOT IN (";
            bool _Bol_String = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridRutasAgre.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    _Str_Cadena = _Str_Cadena + "'" + _Dg_Row.Cells[0].Value.ToString().Trim() + "',";
                    _Bol_String = true;
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 1);
            if (_Bol_String)
            {
                return _Str_Cadena + ")";
            }
            else
            {
                return "";
            }
        }
        private string _Mtd_Imp_Selec2()
        {
            string _Str_Cadena = " AND cidrutdespacho IN ('-1',";
            bool _Bol_String = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridRutasAgre.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    _Str_Cadena = _Str_Cadena + "'" + _Dg_Row.Cells[0].Value.ToString().Trim() + "',";
                    _Bol_String = true;
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 1);
            if (_Bol_String)
            {
                return _Str_Cadena + ")";
            }
            else
            {
                return "";
            }
        }
        private string _Mtd_Imp_Selec3()
        {
            string _Str_Cadena = " AND VST_PREFACTURASSEGUNRUTAS.cpfactura NOT IN (";
            bool _Bol_String = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    _Str_Cadena = _Str_Cadena + "'" + _Dg_Row.Cells["cprefacagre"].Value.ToString().Trim() + "',";
                    _Bol_String = true;
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 1);
            if (_Bol_String)
            {
                return _Str_Cadena + ")" + _Mtd_Imp_Selec2();
            }
            else
            {
                return "" + _Mtd_Imp_Selec2();
            }
        }
        private string _Mtd_VerificarLimitesExcedidos(double _P_Dbl_Kilos, double _P_Dbl_Metros, double _P_Dbl_Monto)
        {
            string _Str_Cadena = "";
            double _Dbl_Kilos = 0;
            double _Dbl_Metros = 0;
            double _Dbl_Monto = 0;
            int _Int_KilosPorcentaje = (_Prb_Kg.Maximum * 10) / 100;
            int _Int_MetrosPorcentaje = (_Prb_Mt.Maximum * 10) / 100;
            int _Int_MontoPorcentaje = (_Prb_Bs.Maximum * 10) / 100;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Kilos"].Value).Length>0)
                { _Dbl_Kilos = _Dbl_Kilos + Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value); }
                if (Convert.ToString(_Dg_Row.Cells["Metros"].Value).Length>0)
                { _Dbl_Metros = _Dbl_Metros + Convert.ToDouble(_Dg_Row.Cells["Metros"].Value); }
                if (Convert.ToString(_Dg_Row.Cells["Monto"].Value).Length>0)
                { _Dbl_Monto = _Dbl_Monto + Convert.ToDouble(_Dg_Row.Cells["Monto"].Value); }
            }
            //_Dbl_Kilos = _Dbl_Kilos + _P_Dbl_Kilos;
            //_Dbl_Metros = _Dbl_Metros + _P_Dbl_Metros;
            //_Dbl_Monto = _Dbl_Monto + _P_Dbl_Monto;
            if (Convert.ToInt32(_Dbl_Kilos) > _Prb_Kg.Maximum + _Int_KilosPorcentaje)
            { _Str_Cadena = "La Capacidad de carga Kg. a mas del 10% "; }
            if (Convert.ToInt32(_Dbl_Metros) > _Prb_Mt.Maximum + _Int_MetrosPorcentaje)
            {
                if (Convert.ToInt32(_Dbl_Kilos) > _Prb_Kg.Maximum + _Int_KilosPorcentaje)
                { _Str_Cadena = _Str_Cadena + ", Capacidad de carga Mts a mas del 10% "; }
                else
                { _Str_Cadena = _Str_Cadena + "La Capacidad de carga Mts a mas del 10% "; }
            }
            if (Convert.ToInt32(_Dbl_Monto) > _Prb_Bs.Maximum + _Int_MontoPorcentaje)
            {
                if (Convert.ToInt32(_Dbl_Kilos) > _Prb_Kg.Maximum + _Int_KilosPorcentaje | Convert.ToInt32(_Dbl_Metros) > _Prb_Mt.Maximum + _Int_MetrosPorcentaje)
                { _Str_Cadena = _Str_Cadena + ", Límite en  Bs. / Bs.F. a mas del 10% "; }
                else
                { _Str_Cadena = _Str_Cadena + "El Límite en  Bs. / Bs.F. a mas del 10% "; }
            }
            return _Str_Cadena;
        }
        private void _Mtd_AjustarProgressbar()
        {
            double _Dbl_Kilos = 0;
            double _Dbl_Metros = 0;
            double _Dbl_Monto = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Kilos"].Value).Length>0)
                { _Dbl_Kilos = _Dbl_Kilos + Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value); }
                if (Convert.ToString(_Dg_Row.Cells["Metros"].Value).Length>0)
                { _Dbl_Metros = _Dbl_Metros + Convert.ToDouble(_Dg_Row.Cells["Metros"].Value); }
                if (Convert.ToString(_Dg_Row.Cells["Monto"].Value).Length>0)
                { _Dbl_Monto = _Dbl_Monto + Convert.ToDouble(_Dg_Row.Cells["Monto"].Value); }
            }
            _Lbl_Kg_Por.Text = Convert.ToDouble((100 * Convert.ToDouble(_Dbl_Kilos)) / _Prb_Kg.Maximum).ToString("#,##0.00") + "  %";
            _Lbl_Mts_Por.Text = Convert.ToDouble((100 * Convert.ToDouble(_Dbl_Metros)) / _Prb_Mt.Maximum).ToString("#,##0.00") + "     %";
            _Lbl_Bs_Por.Text = Convert.ToDouble((100 * Convert.ToDouble(_Dbl_Monto)) / _Prb_Bs.Maximum).ToString("#,##0.00") + "  %";
            _Lbl_Kg_Kilos.Text = _Dbl_Kilos.ToString("#,##0.00") + " Kg";
            _Lbl_Mts_Metros.Text = _Dbl_Metros.ToString("#,##0.00") + " Mts³";
            _Lbl_Bs_Bolivares.Text = _Dbl_Monto.ToString("#,##0.00") + " Bs.F.";
            if (Convert.ToInt32(_Dbl_Kilos) <= _Prb_Kg.Maximum)
            { _Prb_Kg.Value = Convert.ToInt32(_Dbl_Kilos); }
            else
            { _Prb_Kg.Value = _Prb_Kg.Maximum; }
            if (Convert.ToInt32(_Dbl_Metros) <= _Prb_Mt.Maximum)
            { _Prb_Mt.Value = Convert.ToInt32(_Dbl_Metros); }
            else
            { _Prb_Mt.Value = _Prb_Mt.Maximum; }
            if (Convert.ToInt32(_Dbl_Monto) <= _Prb_Bs.Maximum)
            { _Prb_Bs.Value = Convert.ToInt32(_Dbl_Monto); }
            else
            { _Prb_Bs.Value = _Prb_Bs.Maximum; }
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cprecarga FROM TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cprecarga  DESC";
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
        private byte[] _Mtd_convertirPicBoxImageparaByte(Image _img_pbImage)
        {
            System.IO.MemoryStream _ms = new System.IO.MemoryStream();
            _img_pbImage.Save(_ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return _ms.ToArray();
        }

        private void _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Txt_Precarga.Text.Trim().Length == 0)
            {
                _Txt_Precarga.Text = _Mtd_Entrada().ToString();
            }
            string _Str_Cadena = "Select cimprimeprecarga from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            PrintDialog _Print = new PrintDialog();
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Mtd_Met_Guardar(_Txt_Precarga.Text.Trim(), _Txt_Placa.Text.Trim(), _Str_Cedula, true);
                _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        //----------------------------------------------
                        bool _Bol_RequiereGuiaSada = _Mtd_RequiereGuiaSada(_Txt_Precarga.Text.Trim());
                        //----------------------------------------------
                        REPORTESS _Frm = new REPORTESS(new string[] { "VST_PRECARGALISTADO_2" }, new string[] { "VST_PRECARGALISTADO" }, "", "T3.Report.rPreCargaListado", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'", _Print, true, _Bol_RequiereGuiaSada);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Frm.Close();
                            _Frm.Dispose();
                            _Str_Cadena = "Update TPRECARGAM set cimprimeprecarga='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
                            _Chk_PreImp.Checked = true;
                            _Bt_Rutas.Enabled = false;
                            _Bt_Prefacturas.Enabled = false;
                            MessageBox.Show("A continuación se mostrará el informe 'Pre-Facturas' para imprimir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            Cursor = Cursors.WaitCursor;
                            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(1, _Txt_Precarga.Text.Trim());
                            Cursor = Cursors.Default;
                            _Frm_Inf.MdiParent = this.MdiParent;
                            _Frm_Inf.Dock = DockStyle.Fill;
                            _Frm_Inf.Show();
                        }
                    }
                    catch { MessageBox.Show("No se pudo contactar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Cursor = Cursors.Default; }
                }
            }
            else
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    MessageBox.Show("La pre-carga ya fue impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            //----------------------------------------------
                            bool _Bol_RequiereGuiaSada = _Mtd_RequiereGuiaSada(_Txt_Precarga.Text.Trim());
                            //----------------------------------------------
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_PRECARGALISTADO_2" }, new string[] { "VST_PRECARGALISTADO" }, "", "T3.Report.rPreCargaListado", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'", _Print, true, _Bol_RequiereGuiaSada);
                            if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                            }

                            Cursor = Cursors.Default;
                        }
                        catch (Exception err) {
                            err.GetBaseException();
                            MessageBox.Show("No se pudo contactar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Cursor = Cursors.Default; }
                    }
                }
                else
                {
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_Met_Editar(_Txt_Precarga.Text, _Txt_Placa.Text);
                        try
                        {
                            //----------------------------------------------
                            bool _Bol_RequiereGuiaSada = _Mtd_RequiereGuiaSada(_Txt_Precarga.Text.Trim());
                            //----------------------------------------------
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_PRECARGALISTADO_2" }, new string[] { "VST_PRECARGALISTADO" }, "", "T3.Report.rPreCargaListado", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'", _Print, true, _Bol_RequiereGuiaSada);
                            if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Frm.Close();
                                _Frm.Dispose();
                                _Str_Cadena = "Update TPRECARGAM set cimprimeprecarga='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
                                _Chk_PreImp.Checked = true;
                                MessageBox.Show("A continuación se mostrará el informe 'Pre-Facturas' para imprimir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                Cursor = Cursors.WaitCursor;
                                Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(1, _Txt_Precarga.Text.Trim());
                                Cursor = Cursors.Default;
                                _Frm_Inf.MdiParent = this.MdiParent;
                                _Frm_Inf.Dock = DockStyle.Fill;
                                _Frm_Inf.Show();
                            }
                        }
                        catch { MessageBox.Show("No se pudo contactar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Cursor = Cursors.Default; }
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        int _Int_Edicion = 0;
        private void _Mtd_Met_Editar(string _P_Str_Precarga, string _P_Str_Placa)
        {
            string _Str_Cadena = "";
            double _Dbl_TotalCajas = 0;
            double _Dbl_TotalUnidades = 0;
            double _Dbl_TotalKilos = 0;
            DataSet _Ds;
            //---------------------------------------------------------------TPRECARGAM
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (_Dg_Row.Cells["CajasP"].Value != null)
                { _Dbl_TotalCajas = _Dbl_TotalCajas + Convert.ToDouble(_Dg_Row.Cells["CajasP"].Value); }
                if (_Dg_Row.Cells["UnidadesP"].Value != null)
                { _Dbl_TotalUnidades = _Dbl_TotalUnidades + Convert.ToDouble(_Dg_Row.Cells["UnidadesP"].Value); }
                if (_Dg_Row.Cells["Kilos"].Value != null)
                { _Dbl_TotalKilos = _Dbl_TotalKilos + Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value); }
            }
            _Str_Cadena = "UPDATE TPRECARGAM SET cfechaprecarga='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',ctotalempaq='" + _Dbl_TotalCajas.ToString() + "',ctotalunidad='" + _Dbl_TotalUnidades.ToString() + "',ctotalkg='" + _Dbl_TotalKilos.ToString().Replace(",", ".") + "',ccaltabuladordes='" + _Txt_Costo.Text.Replace(".", "").Replace(",", ".") + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_Precarga + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //---------------------------------------------------------------TPRECARGAM

            //---------------------------------------------------------------TPRECARGADR
            _Str_Cadena = "DELETE FROM TPRECARGADR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_Precarga + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            foreach (DataGridViewRow _Dg_Row in _Dg_GridRutasAgre.Rows)
            {
                _Str_Cadena = "Insert into TPRECARGADR (cgroupcomp,cprecarga,cidrutdespacho) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells[0].Value + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            //---------------------------------------------------------------TPRECARGADR

            //---------------------------------------------------------------TPRECARGADPF
            _Dbl_TotalCajas = 0;
            _Dbl_TotalUnidades = 0;
            _Dbl_TotalKilos = 0;

            _Str_Cadena = "DELETE FROM TPRECARGADPF WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_Precarga + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "SELECT cpfactura,TPREFACTURAM.ccompany FROM TPREFACTURAM INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany=TPREFACTURAM.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Dss = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Dg_Roww in _Dss.Tables[0].Rows)
            {
                _Str_Cadena = "Update TPREFACTURAM set cprecarga=0 where ccompany='" + _Dg_Roww["ccompany"].ToString().Trim() + "' and cprecarga='" + _P_Str_Precarga + "' and cpfactura='" + _Dg_Roww["cpfactura"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            int _Int_EdicionPrecarga=0;
            string _Str_FechaEdicion="";
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (_Dg_Row.Cells["CajasP"].Value != null)
                { _Dbl_TotalCajas = Convert.ToDouble(_Dg_Row.Cells["CajasP"].Value); }
                if (_Dg_Row.Cells["UnidadesP"].Value != null)
                { _Dbl_TotalUnidades = Convert.ToDouble(_Dg_Row.Cells["UnidadesP"].Value); }
                if (_Dg_Row.Cells["Kilos"].Value != null)
                { _Dbl_TotalKilos = Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value); }
                if (_Bol_Editar)
                {
                    System.Data.DataRow[] _Dtw_Filas = _Ds_DataSetGen.Tables[0].Select("cprecarga='" + _P_Str_Precarga + "' and cpfactura='" + _Dg_Row.Cells["cprefacagre"].Value + "'");
                    if (_Dtw_Filas.Length > 0)
                    {
                        if (_Dtw_Filas[0]["cedicion"].ToString() != "")
                        {
                            _Int_EdicionPrecarga = Convert.ToInt32(_Dtw_Filas[0]["cedicion"].ToString());
                        }
                        else
                        {
                            _Int_EdicionPrecarga = 0;
                        }
                        if (_Dtw_Filas[0]["cfechaedicion"].ToString() != "")
                        {
                            _Str_FechaEdicion = Convert.ToDateTime(_Dtw_Filas[0]["cfechaedicion"].ToString()).ToString("dd/MM/yyyy");
                            _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho,cpfacturasnuevas,cpfacturasnuevasfechora) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "','" + _Int_EdicionPrecarga.ToString() + "','" + _Str_FechaEdicion + "')";
                        }
                        else
                        {
                            _Str_FechaEdicion = "";
                            _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho,cpfacturasnuevas,cpfacturasnuevasfechora) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "','" + _Int_EdicionPrecarga.ToString() + "',null)";
                        }
                    }
                    else
                    {
                        _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho,cpfacturasnuevas,cpfacturasnuevasfechora) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "','" + _Int_Edicion.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')";
                    }
                }
                else
                {
                    _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "')";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TPREFACTURAM set cprecarga='" + _P_Str_Precarga + "' where ccompany='" + _Dg_Row.Cells["ccompanyagre"].Value + "' and cpfactura='" + _Dg_Row.Cells["cprefacagre"].Value + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            //---------------------------------------------------------------TPRECARGADPF

            //---------------------------------------------------------------TPRECARGADPFD
            _Dbl_TotalCajas = 0;
            _Dbl_TotalUnidades = 0;
            _Dbl_TotalKilos = 0;
            _Str_Cadena = "DELETE FROM TPRECARGADPFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_Precarga + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                _Str_Cadena = "Select cproducto,cempaques,cunidades,Kilos,ISNULL(cidproductod,0) AS cidproductod from VST_KILOSDETALLEPREFACTURA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Dg_Row.Cells["ccompanyagre"].Value + "' and cpfactura='" + _Dg_Row.Cells["cprefacagre"].Value + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    if (_Row["cempaques"] != System.DBNull.Value)
                    { _Dbl_TotalCajas = Convert.ToDouble(_Row["cempaques"].ToString()); }
                    if (_Row["cunidades"] != System.DBNull.Value)
                    { _Dbl_TotalUnidades = Convert.ToDouble(_Row["cunidades"].ToString()); }
                    if (_Row["Kilos"] != System.DBNull.Value)
                    { _Dbl_TotalKilos = Convert.ToDouble(_Row["Kilos"].ToString()); }
                    _Str_Cadena = "Insert into TPRECARGADPFD (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,cproducto,cpempaques,cpunidades,ctotalkg,cidproductod) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Row[0].ToString() + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Row["cidproductod"].ToString().Trim() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }
        private void _Mtd_Met_Guardar(string _P_Str_Precarga, string _P_Str_Placa, string _P_Str_Cedula, bool _Bool_Guardar)
        {   
            string _Str_Cadena = "";
            double _Dbl_TotalCajas = 0;
            double _Dbl_TotalUnidades = 0;
            double _Dbl_TotalKilos = 0;
            //---------------------------------------------------------------TPRECARGAM
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (_Dg_Row.Cells["CajasP"].Value != null)
                { _Dbl_TotalCajas = _Dbl_TotalCajas + Convert.ToDouble(_Dg_Row.Cells["CajasP"].Value); }
                if (_Dg_Row.Cells["UnidadesP"].Value != null)
                { _Dbl_TotalUnidades = _Dbl_TotalUnidades + Convert.ToDouble(_Dg_Row.Cells["UnidadesP"].Value); }
                if (_Dg_Row.Cells["Kilos"].Value != null)
                { _Dbl_TotalKilos = _Dbl_TotalKilos + Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value); }
            }
            //_Str_Cadena = "Insert into TPRECARGAM (cgroupcomp,ccompany,cprecarga,cplaca,ccedula,cfechaprecarga,ctotalempaq,ctotalunidad,ctotalkg,ccaltabuladordes) values ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_Precarga + "','" + _P_Str_Placa + "','" + _P_Str_Cedula + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "'," + _Txt_Costo.Text.Replace(".", "").Replace(",", ".") + ")";
            _Str_Cadena = "Insert into TPRECARGAM (cgroupcomp,cprecarga,cplaca,ccedula,cfechaprecarga,ctotalempaq,ctotalunidad,ctotalkg,ccaltabuladordes,ctransportecal,ctipocliente,ctipoalimento) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','0','0','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "'," + _Txt_Costo.Text.Replace(".", "").Replace(",", ".") + ",'" + _Str_PlacaOculta + "','" + _G_Str_TipoClienteSel + "','" + _G_Str_TipoAlimentoSel + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //---------------------------------------------------------------TPRECARGAM

            //---------------------------------------------------------------TPRECARGADR
            foreach (DataGridViewRow _Dg_Row in _Dg_GridRutasAgre.Rows)
            {
                _Str_Cadena = "Insert into TPRECARGADR (cgroupcomp,cprecarga,cidrutdespacho) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells[0].Value + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            //---------------------------------------------------------------TPRECARGADR

            //---------------------------------------------------------------TPRECARGADPF
            _Dbl_TotalCajas = 0;
            _Dbl_TotalUnidades = 0;
            _Dbl_TotalKilos = 0;
            int _Int_EdicionPrecarga = 0;
            string _Str_FechaEdicion = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {               
                if (_Dg_Row.Cells["CajasP"].Value != null)
                { _Dbl_TotalCajas =  Convert.ToDouble(_Dg_Row.Cells["CajasP"].Value); }
                if (_Dg_Row.Cells["UnidadesP"].Value != null)
                { _Dbl_TotalUnidades =  Convert.ToDouble(_Dg_Row.Cells["UnidadesP"].Value); }
                if (_Dg_Row.Cells["Kilos"].Value != null)
                { _Dbl_TotalKilos = Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value); }
                if (_Bol_Editar)
                {
                    System.Data.DataRow[] _Dtw_Filas = _Ds_DataSetGen.Tables[0].Select("cprecarga='" + _P_Str_Precarga + "' and cpfactura='" + _Dg_Row.Cells["cprefacagre"].Value + "'");
                    if (_Dtw_Filas.Length > 0)
                    {
                        if (_Dtw_Filas[0]["cedicion"].ToString() != "")
                        {
                            _Int_EdicionPrecarga = Convert.ToInt32(_Dtw_Filas[0]["cedicion"].ToString());
                        }
                        else
                        {
                            _Int_EdicionPrecarga = 0;
                        }
                        if (_Dtw_Filas[0]["cfechaedicion"].ToString() != "")
                        {
                            _Str_FechaEdicion = Convert.ToDateTime(_Dtw_Filas[0]["cfechaedicion"].ToString()).ToString("dd/MM/yyyy");
                            _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho,cpfacturasnuevas,cpfacturasnuevasfechora) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "','" + _Int_EdicionPrecarga.ToString() + "','" + _Str_FechaEdicion + "')";
                        }
                        else
                        {
                            _Str_FechaEdicion = "";
                            _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho,cpfacturasnuevas,cpfacturasnuevasfechora) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "','" + _Int_EdicionPrecarga.ToString() + "',null)";
                        }
                    }
                    else
                    {
                        _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho,cpfacturasnuevas,cpfacturasnuevasfechora) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "','" + _Int_Edicion.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')";
                    }
                }
                else
                {
                    _Str_Cadena = "Insert into TPRECARGADPF (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,ctotalempaq,ctotalunidad,ctotalkg,cordendespacho) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Dg_Row.Cells["Orden"].Value + "')";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TPREFACTURAM set cprecarga='" + _P_Str_Precarga + "' where ccompany='" + _Dg_Row.Cells["ccompanyagre"].Value + "' and cpfactura='" + _Dg_Row.Cells["cprefacagre"].Value + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            //---------------------------------------------------------------TPRECARGADPF

            //---------------------------------------------------------------TPRECARGADPFD
            _Dbl_TotalCajas = 0;
            _Dbl_TotalUnidades = 0;
            _Dbl_TotalKilos = 0;
            DataSet _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                _Str_Cadena="Insert into TPRECARGADPFD (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,cproducto,cpempaques,cpunidades,ctotalkg,cidproductod)"+
                " Select '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "',cproducto,cempaques,cunidades,Kilos,ISNULL(cidproductod,0) AS cidproductod from VST_KILOSDETALLEPREFACTURA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Dg_Row.Cells["ccompanyagre"].Value + "' and cpfactura='" + _Dg_Row.Cells["cprefacagre"].Value + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //foreach (DataRow _Row in _Ds.Tables[0].Rows)
                //{
                //    if (_Row["cempaques"] != System.DBNull.Value)
                //    { _Dbl_TotalCajas = Convert.ToDouble(_Row["cempaques"].ToString()); }
                //    if (_Row["cunidades"] != System.DBNull.Value)
                //    { _Dbl_TotalUnidades = Convert.ToDouble(_Row["cunidades"].ToString()); }
                //    if (_Row["Kilos"] != System.DBNull.Value)
                //    { _Dbl_TotalKilos = Convert.ToDouble(_Row["Kilos"].ToString()); }
                //    _Str_Cadena = "Insert into TPRECARGADPFD (cgroupcomp,cprecarga,cidrutdespacho,cpfactura,cproducto,cpempaques,cpunidades,ctotalkg,cidproductod) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Precarga + "','" + _Dg_Row.Cells["cidrutdespacho2"].Value + "','" + _Dg_Row.Cells["cprefacagre"].Value + "','" + _Row[0].ToString() + "','" + _Dbl_TotalCajas.ToString() + "','" + _Dbl_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_TotalKilos) + "','" + _Row["cidproductod"].ToString().Trim() + "')";
                //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //}
            }
            //---------------------------------------------------------------TPRECARGADPFD
        }
        private int _Mtd_IntCantEdicion(string _Str_Precarga)
        {
            try
            {
                int _Int_Num = 0;
                if (_Ds_DataSetGen.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _Dtw_Item in _Ds_DataSetGen.Tables[0].Rows)
                    {
                        _Int_Num = Convert.ToInt32(_Dtw_Item["cedicion"].ToString());
                        _Int_Num++;
                    }
                }
                return _Int_Num;
            }
            catch
            {
                return 0;
            }
        }
        private void _Mtd_LeerArchivo(string _P_Str_File)
        {
            //bool _Bol_Sw = false;
            //StreamReader _StreamR = new StreamReader(_P_Str_File);
            //string _Str_Sql = "";
            //string _Str_Linea = "";
            //string _Str_Cadena = "";
            //string _Str_CodProd = "";
            //string _Str_CodFab = "";
            //DataSet _Ds = new DataSet();
            //DataSet _Ds_Temp = new DataSet();
            //DataSet _Ds_Aux;
            //double _Dbl_CajasPre = 0;
            //double _Dbl_UnidadesPre = 0;
            //double _Dbl_CajasAscii = 0;
            //double _Dbl_UnidadesAscii = 0;
            //double _Dbl_DiferenciaCajas = 0;
            //double _Dbl_DiferenciaUnidades = 0;
            //_Str_Cadena = "Delete from TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
            //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //try
            //{
            //    while (_Str_Linea != null)
            //    {
            //        _Str_Linea = _StreamR.ReadLine();
            //        if (_Str_Linea != null)
            //        {
            //            string[] _Str_Fila = _Str_Linea.Split(new char[] { ';' });
            //            if (_Str_Fila.Length == 6)
            //            {
            //                //if (_Str_Fila[0] != _Txt_Precarga.Text || _Str_Fila[1] != _Txt_Placa.Text)
            //                if (_Str_Fila[0] != _Txt_Precarga.Text)
            //                {
            //                    MessageBox.Show("Problemas al procesar el archivo. El archivo no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    _Str_Cadena = "delete from TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
            //                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                
            //                    break;
            //                }
            //            a:
            //                _Str_Sql = "SELECT cproducto,ccodfabrica FROM TPRODUCTO WHERE LTRIM(ccodcorrugado)='" + _Str_Fila[2] + "' AND cactivate='1'";
            //                _Ds_Aux = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

            //                if (_Ds_Aux.Tables[0].Rows.Count > 1)
            //                {
            //                    MessageBox.Show("Se ha encontrado duplicidad del corrugado " + _Str_Fila[2] + ". Por favor seleccione el producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                b:
            //                    TextBox _Txt_Codigo = new TextBox();
            //                    TextBox _Txt_Codigo2 = new TextBox();
            //                    ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            //                    _Tsm_Menu[0] = new ToolStripMenuItem("Producto");
            //                    _Tsm_Menu[1] = new ToolStripMenuItem("Cod.Fabric");
            //                    _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            //                    string[] _Str_Campos = new string[3];
            //                    _Str_Campos[0] = "cproducto";
            //                    _Str_Campos[1] = "ccodfabrica";
            //                    _Str_Campos[2] = "cnamef";
            //                    _Str_Cadena = "SELECT cproducto as Producto,ccodfabrica as [Cod.Fabric],(cnamefc) as Descripción FROM VST_PRODUCTOS WHERE LTRIM(ccodcorrugado)='" + _Str_Fila[2].Trim() + "' AND cactivate='1'";
            //                    Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Codigo, _Txt_Codigo2, _Str_Cadena, _Str_Campos, "Duplicidad de corrugado. PreFact:" + _Str_Fila[5] + " EMP:" + _Str_Fila[3] + " UND:" + _Str_Fila[4], _Tsm_Menu, 0, 1);
            //                    _Frm.ShowDialog();
            //                    if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Codigo2.Text.Trim().Length > 0)
            //                    {
            //                        _Str_CodProd = _Txt_Codigo.Text.Trim();
            //                        _Str_CodFab = _Txt_Codigo2.Text.Trim();
            //                        //VERIFICO SI YA SE INSERTO EN LA TPRECARGASCANPAL
            //                        _Str_Cadena = "SELECT * FROM TPRECARGASCANPAL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "' AND cproducto='" + _Str_CodProd + "' AND cpfactura='" + _Str_Fila[5] + "'";// AND cplaca='" + _Str_Fila[1] + "'";
            //                        if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
            //                        {
            //                            MessageBox.Show("El producto con el código " + _Str_CodProd + " ya fue registrado, seleccione correctamente.","Información",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //                            goto b;
            //                        }
                                    
            //                    }
            //                    else
            //                    { goto a; }
            //                }
            //                else
            //                {
            //                    if (_Ds_Aux.Tables[0].Rows.Count > 0)
            //                    {
            //                        _Str_CodProd = _Ds_Aux.Tables[0].Rows[0][0].ToString().Trim();
            //                        _Str_CodFab = _Ds_Aux.Tables[0].Rows[0][1].ToString().Trim();
                                    
            //                    }
            //                }

            //                _Dbl_CajasAscii = Convert.ToDouble(_Str_Fila[3]);
            //                _Dbl_UnidadesAscii = Convert.ToDouble(_Str_Fila[4]);
            //                _Str_Cadena = "Select SUM(cpempaques),SUM(cpunidades) from TPRECARGADPFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Str_Fila[0] + "' and cproducto='" + _Str_CodProd + "' and cpfactura='" + _Str_Fila[5] + "'";
            //                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //                if (_Ds_Temp.Tables[0].Rows.Count > 0)
            //                {
            //                    if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
            //                    { _Dbl_CajasPre = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
            //                    if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
            //                    { _Dbl_UnidadesPre = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
            //                }
            //                if (_Dbl_CajasPre > _Dbl_CajasAscii)
            //                { _Dbl_DiferenciaCajas = _Dbl_CajasPre - _Dbl_CajasAscii; }
            //                else
            //                { _Dbl_DiferenciaCajas = _Dbl_CajasAscii - _Dbl_CajasPre; }
            //                if (_Dbl_UnidadesPre > _Dbl_UnidadesAscii)
            //                { _Dbl_DiferenciaUnidades = _Dbl_UnidadesPre - _Dbl_UnidadesAscii; }
            //                else
            //                { _Dbl_DiferenciaUnidades = _Dbl_UnidadesAscii - _Dbl_UnidadesPre; }
            //                _Str_Cadena = "Insert into TPRECARGASCANPAL (cgroupcomp,cprecarga,cplaca,cproducto,cgempaques,cgunidades,cdifempaques,cdifereunidades,cpfactura) values ('" + Frm_Padre._Str_GroupComp + "','" + _Str_Fila[0] + "','" + _Str_Fila[1] + "','" + _Str_CodProd + "','" + _Dbl_CajasAscii.ToString() + "','" + _Dbl_UnidadesAscii.ToString() + "','" + _Dbl_DiferenciaCajas.ToString() + "','" + _Dbl_DiferenciaUnidades.ToString() + "','" + _Str_Fila[5] + "')";
            //                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //                _Bol_Sw = true;
            //            }
            //        }
            //    }
            //    _StreamR.Close();
            //}
            //catch
            //{
            //    _Chk_VerifRealiz.Checked = false;
            //    MessageBox.Show("Problemas al procesar el archivo. El archivo no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    _Str_Cadena = "delete from TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
            //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //    _Bol_Sw = false;
            //}

            //if (_Bol_Sw)
            //{
            //    _Mtd_Actualizar_Dg_GridVerificacion(_Txt_Precarga.Text.Trim());
            //    _Str_Cadena = "Select * from TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //    if (_Ds.Tables[0].Rows.Count > 0)
            //    {
            //        if (_Dg_GridVerificacion.Rows.Count == 0)
            //        {
                        //string _Str_Cadena = "Update TPRECARGAM set cverificascanpalm='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
                        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //MessageBox.Show("La verificación fue satisfactoria", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            _Tb_Tab.Deselecting -= new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
            //            _Tb_Tab.SelectTab(2);
            //            _Tb_Tab.Deselecting += new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
            //            _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
            //            _Chk_VerifRealiz.Checked = true;
            //        }
            //        else
            //        {
            //            _Chk_VerifRealiz.Checked = false;
            //            _Tb_Tab.Deselecting -= new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
            //            _Tb_Tab.SelectTab(1);
            //            _Tb_Tab.Deselecting += new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
            //            MessageBox.Show("Los datos del archivo no concuerdan con la precarga", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Problemas al procesar el archivo. El archivo no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    _Str_Cadena = "delete from TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
            //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //}
        }
        private void _Mtd_CargarTransportes()
        {
            string _Str_Cadena = "SELECT DISTINCT calto AS ALTO,cancho AS ANCHO,cprofundidad AS PROFUNDIDAD,ccapcarg AS CAPACIDAD FROM TTRANSPORTE WHERE cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private string _Mtd_ObtenerPlacaOculta(string _P_Str_Alto, string _P_Str_Ancho, string _P_Str_Profundidad, string _P_Str_Capacidad)
        {
            if (_P_Str_Alto.Trim().Length == 0) { _P_Str_Alto = "0"; }
            if (_P_Str_Ancho.Trim().Length == 0) { _P_Str_Ancho = "0"; }
            if (_P_Str_Profundidad.Trim().Length == 0) { _P_Str_Profundidad = "0"; }
            if (_P_Str_Capacidad.Trim().Length == 0) { _P_Str_Capacidad = "0"; }
            string _Str_Cadena = "SELECT TOP 1 cplaca FROM TTRANSPORTE WHERE calto='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Alto)) + "' AND cancho='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Ancho)) + "' AND cprofundidad='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Profundidad)) + "' AND ccapcarg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_P_Str_Capacidad)) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }
        string _Str_PlacaTemp = "";
        private void _Mtd_IniciarPreCarca(string _P_Str_Placa)
        {
            string _Str_Cadena = _Mtd_BuscarLimites(_P_Str_Placa);
            if (_Str_Cadena.Trim().Length > 0)
            {
                MessageBox.Show("No se Obtuvo: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transporte", "Avdertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _Txt_Precarga.Text = "";
            _Dg_GridRutasAgre.Rows.Clear();
            _Dg_GridPreFacturasAgre.Rows.Clear();
            _Bt_Rutas.Enabled = true;
            _Bt_EliminarRuta.Enabled = true;
            _Bt_Rutas.Focus();
        }
        private void Frm_ControlDespacho_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Carga.Left = (this.Width / 2) - (_Pnl_Carga.Width / 2);
            _Pnl_Carga.Top = (this.Height / 2) - (_Pnl_Carga.Height / 2);
            _Pnl_TipoCliente.Left = (this.Width / 2) - (_Pnl_TipoCliente.Width / 2);
            _Pnl_TipoCliente.Top = (this.Height / 2) - (_Pnl_TipoCliente.Height / 2);
            _Pnl_TipoCliente.Left = (this.Width / 2) - (_Pnl_TipoCliente.Width / 2);
            _Pnl_TipoCliente.Top = (this.Height / 2) - (_Pnl_TipoCliente.Height / 2);
            _Mtd_Sorted();
            _Mtd_CrearDataSet();
            _Mtd_Actualizar_Dg_GridPreFacturas(_Int_Estatus, _Tool_Consulta.Text);
        }

        private void _Mtd_ActualizarToolFactura(int Int_Estatus)
        {
            toolStripComboBox1.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar_Dg_GridPreFacturas(Int_Estatus, toolStripComboBox1.Text);
            _Mtd_Actualizar_Dg_GridTrasportes();
            Cursor = Cursors.Default;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;//TODAS LAS PREFACTURAS PENDIENTES
            _Mtd_ActualizarToolFactura(_Int_Estatus);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;//ESPERANDO POR FACTURAR
            _Mtd_ActualizarToolFactura(_Int_Estatus);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 2;
            _Mtd_ActualizarToolFactura(_Int_Estatus);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 3;
            _Mtd_ActualizarToolFactura(_Int_Estatus);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 2;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 3;
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Text = "";
            }
        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    _Mtd_Actualizar_Dg_GridPreFacturas(_Int_Estatus, toolStripComboBox1.Text);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //_Int_Estatus = 0; Quitado el 09/12/2008
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar_Dg_GridPreFacturas(_Int_Estatus, toolStripComboBox1.Text);
            _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
            //Actualiza Grid de Transporte
            _Mtd_Actualizar_Dg_GridTrasportes();
            //Función Comentada ¿?
            Cursor = Cursors.Default;
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPreFacturas.CurrentCell != null)
            {
                int _Int_Estatus_Temp = 0;
                if (_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["clistofacturar"].Value == null) { _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["clistofacturar"].Value = 0; }
                if (_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cprecarga"].Value == null) { _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cprecarga"].Value = 0; }
                if (_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cfacturado"].Value == null) { _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cfacturado"].Value = 0; }
                
                if ((_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "1" & _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value.ToString().Trim() == "0") | (_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "1" & _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value.ToString().Trim() == "1" & Convert.ToInt32(_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cprecarga"].Value) > 0)) 
                { _Int_Estatus_Temp = 3; }
                else if ((_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["clistofacturar"].Value.ToString().Trim() == "1" & _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cprecarga"].Value.ToString().Trim() == "0" & _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "0") | (_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value.ToString().Trim() == "1" & _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cprecarga"].Value.ToString().Trim() == "0"))
                { _Int_Estatus_Temp = 1; }
                else if (_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["clistofacturar"].Value.ToString().Trim() == "1" & Convert.ToInt32(_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cprecarga"].Value) > 0 & _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "0")
                { _Int_Estatus_Temp = 2; }


                Cursor = Cursors.WaitCursor;
                Frm_ConsultaPreFacturaDetalle _Frm = new Frm_ConsultaPreFacturaDetalle(_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cpfactura"].Value.ToString(), _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString(), _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["c_fecha_pedido"].Value.ToString(),
                                                                               _Int_Estatus_Temp, _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["ccliente"].Value.ToString(), _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["c_nomb_comer"].Value.ToString().Trim(),
                                                                               _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cvendedor"].Value.ToString(), _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cname"].Value.ToString(),
                                                                               _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cempaques"].Value.ToString(), _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cunidades"].Value.ToString(),
                                                                               _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["c_montotot_si"].Value.ToString(),
                                                                               Convert.ToInt32(_Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["cbackorder"].Value.ToString()), _Dg_GridPreFacturas.Rows[_Dg_GridPreFacturas.CurrentCell.RowIndex].Cells["ccompany"].Value.ToString(), this);
                Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
            }
        }
        private void _Mtd_Verificar_PrefacturasDev()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturas.Rows)
            {
                if (_Dg_Row.Cells["c_factdevuelta"].Value.ToString().Trim() == "1" & _Dg_Row.Cells["cprecarga"].Value.ToString().Trim() == "0")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;}
                else
                { _Dg_Row.DefaultCellStyle.BackColor = Color.White;}
                if (_Dg_Row.Cells["FacturaaAnular"].Value.ToString().Trim() == "1")
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 90, 90);
                }

                //if (_Mtd_PreFacturaTieneFacturasDevueltasParaAnular(_Dg_Row.Cells["cpfactura"].Value.ToString().Trim())) { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 90, 90); }
            }
        }
        private void _Mtd_Verificar_PrefacturasDev(DataGridView _Pr_Dg)
        {
            foreach (DataGridViewRow _Dg_Row in _Pr_Dg.Rows)
            {
                if (_Dg_Row.Cells["cfacturadev"].Value.ToString().Trim() == "1" & _Dg_Row.Cells["pdprecarga"].Value.ToString().Trim() == "0")
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                }

                if (_Dg_Row.Cells["c_facturaanul"].Value.ToString().Trim() == "1")
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 90, 90);
                }
            }
        }
        private void _Mtd_Verificar_PrefacturasDevSinPrecarga(DataGridView _Pr_Dg)
        {
            foreach (DataGridViewRow _Dg_Row in _Pr_Dg.Rows)
            {
                if (_Dg_Row.Cells["cfacturadev"].Value.ToString().Trim() == "1")
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                }

                if (_Dg_Row.Cells["c_facturaanul"].Value.ToString().Trim() == "1")
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 90, 90);
                }
            }
        }
        private void Frm_ControlDespacho_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_Transporte_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_Cadena = "";
            string _Str_Parametro = "";
            if (_Txt_Placa.Text.Trim().Length > 0)
            {
                _Str_Parametro = " AND cplaca<>'" + _Txt_Placa.Text.Trim() + "'";
                _Str_Cadena = "Update TTRANSPORTE set cesperando='1' where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
            TextBox _Txt_TemporalDes = new TextBox();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(13, _Txt_Placa, _Txt_TemporalDes, 0, 1, _Str_Parametro);
            _Frm.ShowDialog(this);
            if (_Txt_Placa.Text.Trim().Length > 0)
            {
                _Str_Cadena = _Mtd_BuscarLimites(_Txt_Placa.Text);
                if (_Str_Cadena.Trim().Length > 0)
                {
                    MessageBox.Show("No se Obtuvo: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transporte", "Avdertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _Str_Cadena = "Update TTRANSPORTE set cesperando='0' where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Str_PlacaTemp = _Txt_Placa.Text.Trim();
                _Bt_Transportista.Enabled = true;
                _Bt_Prefacturas.Enabled = false;
                _Bt_Rutas.Enabled = false;
                _Txt_Precarga.Text = "";
                _Dg_GridRutasAgre.Rows.Clear();
                _Dg_GridPreFacturasAgre.Rows.Clear();
                _Str_Cadena = "SELECT ccedula,cnombre FROM TTRANSPORTISTA WHERE cplaca='" + _Txt_Placa.Text.Trim() + "' and cdelete='0'";//Antes del 12/11/2008 no tenia el filtro de cdelete
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)//Antes del 12/11/2008 estaba _Ds.Tables[0].Rows.Count == 1
                {
                    _Str_Cedula = _Ds.Tables[0].Rows[0]["ccedula"].ToString();
                    _Txt_Transportista.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnombre"]);
                    _Str_Cadena = _Mtd_verificarTransportista(_Str_Cedula);
                    if (_Str_Cadena.Trim().Length > 0)
                    {
                        MessageBox.Show("Se ha vencido: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transportista", "Avdertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    _Bt_Rutas.Enabled = true;
                    _Bt_EliminarRuta.Enabled = true;
                }
            }
        }
        string _Str_Cedula = "";
        private void _Bt_Transportista_Click(object sender, EventArgs e)
        {
            TextBox _Txt_TemporalCod = new TextBox();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(14, _Txt_TemporalCod, _Txt_Transportista, 0, 1, _Txt_Placa.Text.Trim());
            _Frm.ShowDialog(this);
            if (_Txt_TemporalCod.Text.Trim().Length > 0)
            {
                _Str_Cedula = _Txt_TemporalCod.Text.Trim();
                string _Str_Cadena = _Mtd_verificarTransportista(_Txt_TemporalCod.Text.Trim());
                if (_Str_Cadena.Trim().Length > 0)
                {
                    MessageBox.Show("Se ha vencido: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transportista", "Avdertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _Bt_Rutas.Enabled = true;
                _Bt_EliminarRuta.Enabled = true;
            }
        }
        
        private void _Bt_Rutas_Click(object sender, EventArgs e)
        {
            char[] _DelimiterChars = { ',' };
            string _Str_Sql = "";
            DataSet _Ds;
            TextBox _Txt_TemporalCod = new TextBox();
            TextBox _Txt_TemporalDes = new TextBox();
            _Str_FrmRutasAdd = "";
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = null;
            if (_G_Str_TipoClienteSel == "0")
            {
                if (_G_Str_TipoAlimentoSel == "2")
                { _Frm = new Frm_Busqueda2(15, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, _Mtd_Imp_Selec1() + " AND clistofacturar='1' AND c_estable NOT IN ('" + _G_Str_ClienteAcc + "','" + _G_Str_ClienteCompRela + "','" + _G_Str_ClienteEmpl + "','" + _G_Str_ClienteTransp + "')"); }
                else
                { _Frm = new Frm_Busqueda2(15, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, _Mtd_Imp_Selec1() + " AND ctipoalimento='" + _G_Str_TipoAlimentoSel + "' AND  clistofacturar='1' AND c_estable NOT IN ('" + _G_Str_ClienteAcc + "','" + _G_Str_ClienteCompRela + "','" + _G_Str_ClienteEmpl + "','" + _G_Str_ClienteTransp + "')"); }
            }
            else
            {
                if (_G_Str_TipoAlimentoSel == "2")
                { _Frm = new Frm_Busqueda2(15, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, _Mtd_Imp_Selec1() + " AND clistofacturar='1' AND c_estable='" + _G_Str_TipoClienteSel + "'"); }
                else
                { _Frm = new Frm_Busqueda2(15, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, _Mtd_Imp_Selec1() + " AND ctipoalimento='" + _G_Str_TipoAlimentoSel + "' AND clistofacturar='1' AND c_estable='" + _G_Str_TipoClienteSel + "'"); }
            }            
            Cursor = Cursors.Default;
            _Frm.ShowDialog(this);     
            if (_Frm._Str_RutasPrefacturas !=null)
            {
                Cursor = Cursors.WaitCursor;
                //string[] words = _Frm._Str_FrmResult.Split(_DelimiterChars, StringSplitOptions.None);
                for (int _Int_Contador = 0; _Int_Contador < _Frm._Str_RutasPrefacturas.Length/3; _Int_Contador++)
                {
                    _Dg_GridRutasAgre.Rows.Add();
                    _Dg_GridRutasAgre[0, _Dg_GridRutasAgre.RowCount - 1].Value = _Frm._Str_RutasPrefacturas[_Int_Contador, 0];
                    _Dg_GridRutasAgre[1, _Dg_GridRutasAgre.RowCount - 1].Value = _Frm._Str_RutasPrefacturas[_Int_Contador, 1];
                    _Dg_GridRutasAgre[2, _Dg_GridRutasAgre.RowCount - 1].Value = _Frm._Str_RutasPrefacturas[_Int_Contador, 2];
                    //if (_G_Str_TipoClienteSel == "0")
                    //{
                    //    if (_G_Str_TipoAlimentoSel == "2")
                    //    { _Str_Sql = "Select cidrutdespacho as Id,cdescripcion as Ruta,cdistanciakm as Km from VST_RUTASSEGUNPREFACTURAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _Str_Cad + "'"; }
                    //    else
                    //    { _Str_Sql = "Select cidrutdespacho as Id,cdescripcion as Ruta,cdistanciakm as Km from VST_RUTASSEGUNPREFACTURAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _Str_Cad + "' AND ctipoalimento='" + _G_Str_TipoAlimentoSel + "'"; }
                    //}
                    //else
                    //{
                    //    if (_G_Str_TipoAlimentoSel == "2")
                    //    { _Str_Sql = "Select cidrutdespacho as Id,cdescripcion as Ruta,cdistanciakm as Km from VST_RUTASSEGUNPREFACTURAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _Str_Cad + "'"; }
                    //    else
                    //    { _Str_Sql = "Select cidrutdespacho as Id,cdescripcion as Ruta,cdistanciakm as Km from VST_RUTASSEGUNPREFACTURAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _Str_Cad + "' AND ctipoalimento='" + _G_Str_TipoAlimentoSel + "'"; }
                    //}
                    //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    //if (_Ds.Tables[0].Rows.Count > 0)
                    //{
                    //    _Dg_GridRutasAgre[1, _Dg_GridRutasAgre.RowCount - 1].Value = Convert.ToString(_Ds.Tables[0].Rows[0]["Ruta"]).Trim();
                    //    _Dg_GridRutasAgre[2, _Dg_GridRutasAgre.RowCount - 1].Value = Convert.ToString(_Ds.Tables[0].Rows[0]["Km"]).Trim();
                    //}
                    _Str_FrmRutasAdd = _Str_FrmRutasAdd + _Frm._Str_RutasPrefacturas[_Int_Contador, 0] + ",";
                }
                _Str_FrmRutasAdd = _Str_FrmRutasAdd.Substring(0, _Str_FrmRutasAdd.Length - 1);
                Cursor = Cursors.Default;
            }
            else
            {
                if (_Txt_TemporalCod.Text.Trim().Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Cadena = "Select cdistanciakm,Numero from VST_RUTASSEGUNPREFACTURAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Txt_TemporalCod.Text.Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        object[] _Ob = new object[3];
                        _Ob[0] = _Txt_TemporalCod.Text.Trim();
                        _Ob[1] = _Txt_TemporalDes.Text.Trim();
                        _Ob[2] = _Ds.Tables[0].Rows[0][0].ToString();
                        _Dg_GridRutasAgre.Rows.Add(_Ob);
                        DataGridViewCell _Dgv_Cell = _Dg_GridRutasAgre.Rows[_Dg_GridRutasAgre.Rows.Count - 1].Cells[0];
                        _Dg_GridRutasAgre.CurrentCell = _Dgv_Cell;
                        _Dg_GridRutasAgre.ClearSelection();
                        _Bt_EliminarPrefactura.Enabled = true;
                        _Bt_Subir.Enabled = true;
                        _Bt_Bajar.Enabled = true;
                    }
                    Cursor = Cursors.Default;
                    _Str_FrmRutasAdd = _Txt_TemporalCod.Text.Trim();
                }
            }
            _Bt_Prefacturas.Enabled = true;
            _Dg_GridRutasAgre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Mtd_FiltroRutasDuplicadas().Length > 0)
            {
                _Pnl_SelRuta.Parent = this;
                _Pnl_SelRuta.Visible = true;
            }
        }
        object[] _ObTemp = new object[8];
        private void _Bt_Prefacturas_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            DataSet _Ds;
            TextBox _Txt_TemporalCod = new TextBox();
            TextBox _Txt_TemporalDes = new TextBox();
            double _Dbl_Kilos = 0;
            double _Dbl_Metros = 0;
            double _Dbl_Monto = 0;
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = null;
            if (_G_Str_TipoClienteSel == "0")
            {
                if (_G_Str_TipoAlimentoSel == "2")
                { _Frm = new Frm_Busqueda2(16, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, " AND VST_PREFACTURASSEGUNRUTAS.C_ESTABLE  NOT IN ('" + _G_Str_ClienteAcc + "','" + _G_Str_ClienteCompRela + "','" + _G_Str_ClienteEmpl + "','" + _G_Str_ClienteTransp + "') AND  VST_PREFACTURASSEGUNRUTAS.cprecarga='0' AND " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "TCOTPEDFACM.ccompany") + _Mtd_Imp_Selec3()); }
                else
                { _Frm = new Frm_Busqueda2(16, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, " AND VST_PREFACTURASSEGUNRUTAS.ctipoalimento='" + _G_Str_TipoAlimentoSel + "' AND VST_PREFACTURASSEGUNRUTAS.C_ESTABLE  NOT IN ('" + _G_Str_ClienteAcc + "','" + _G_Str_ClienteCompRela + "','" + _G_Str_ClienteEmpl + "','" + _G_Str_ClienteTransp + "') AND  VST_PREFACTURASSEGUNRUTAS.cprecarga='0' AND " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "TCOTPEDFACM.ccompany") + _Mtd_Imp_Selec3()); }
            }
            else
            {
                if (_G_Str_TipoAlimentoSel == "2")
                { _Frm = new Frm_Busqueda2(16, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, " AND VST_PREFACTURASSEGUNRUTAS.C_ESTABLE='" + _G_Str_TipoClienteSel + "' AND  VST_PREFACTURASSEGUNRUTAS.cprecarga='0' AND " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "TCOTPEDFACM.ccompany") + _Mtd_Imp_Selec3()); }
                else
                { _Frm = new Frm_Busqueda2(16, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, " AND VST_PREFACTURASSEGUNRUTAS.ctipoalimento='" + _G_Str_TipoAlimentoSel + "' AND VST_PREFACTURASSEGUNRUTAS.C_ESTABLE='" + _G_Str_TipoClienteSel + "' AND  VST_PREFACTURASSEGUNRUTAS.cprecarga='0' AND " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "TCOTPEDFACM.ccompany") + _Mtd_Imp_Selec3()); }
            }
            this.Cursor = Cursors.Default;
            _Frm.ShowDialog(this);
            if (_Frm._Str_FrmResult != "")
            {
                _ObTemp.Initialize();

                Cursor = Cursors.WaitCursor;

                foreach (DataGridViewRow _Dg_Row in _Frm._Dg_Grid.SelectedRows)
                {
                    _Dg_GridPreFacturasAgre.Rows.Add();
                    _Dg_GridPreFacturasAgre[0, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Compañía"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[1, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Pre-Factura"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[2, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Cliente"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[3, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Cajas"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[4, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Unidades"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[5, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Kilos"].Value.ToString().Trim();

                    if (_Dg_Row.Cells["Kilos"].Value.ToString().Trim() != "")
                    {
                        _Dbl_Kilos = _Dbl_Kilos + Convert.ToDouble(_Dg_Row.Cells["Kilos"].Value);
                    }

                    _Dg_GridPreFacturasAgre[6, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_GridPreFacturasAgre.Rows.Count;
                    _Dg_GridPreFacturasAgre[7, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["cidrutdespacho"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[8, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Metros"].Value.ToString().Trim();

                    if (_Dg_Row.Cells["Metros"].Value.ToString().Trim() != "")
                    {
                        _Dbl_Metros = _Dbl_Metros + Convert.ToDouble(_Dg_Row.Cells["Metros"].Value);
                    }

                    _Dg_GridPreFacturasAgre[9, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["Monto"].Value.ToString().Trim();

                    if (_Dg_Row.Cells["Monto"].Value.ToString().Trim() != "")
                    {
                        _Dbl_Monto = _Dbl_Monto + Convert.ToDouble(_Dg_Row.Cells["Monto"].Value);
                    }

                    _Dg_GridPreFacturasAgre[10, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["ccliente"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[11, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["c_rif"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[12, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["ciudad"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[13, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["c_factdevuelta"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[14, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["cprecarga"].Value.ToString().Trim();
                    _Dg_GridPreFacturasAgre[15, _Dg_GridPreFacturasAgre.RowCount - 1].Value = _Dg_Row.Cells["c_facturaanul"].Value.ToString().Trim();
                }

                Cursor = Cursors.Default;

                _Mtd_AjustarProgressbar();
                
                _Str_Sql = _Mtd_VerificarLimitesExcedidos(_Dbl_Kilos, _Dbl_Metros, _Dbl_Monto);
                if (_Str_Sql.Trim().Length > 0)
                {
                    if (MessageBox.Show("Se ha excedido: " + _Str_Sql.Substring(0, _Str_Sql.Length - 1) + " del Transporte. ¿Esta seguro de ingresar esta prefactura?", "Avdertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _Int_Imprimir = 0;
                        _Lbl_TituloClave.Text = "Autorize la carga";
                        _Int_FrmClaveProceso = 1;
                        _Pnl_Clave.Visible = true;
                    }
                    else
                    {
                        for (int _I = 1; _I <= _Int_FrmNumPreFactAdd; _I++)
                        {
                            _Dg_GridPreFacturasAgre.Rows.RemoveAt(_Dg_GridPreFacturasAgre.RowCount - 1);
                        }
                        _Mtd_AjustarProgressbar();
                        _Int_FrmNumPreFactAdd = 0;
                    }
                }
                else
                {
                    _Mtd_AjustarProgressbar();
                    DataGridViewCell _Dgv_Cell = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.Rows.Count - 1].Cells[0];
                    _Dg_GridPreFacturasAgre.CurrentCell = _Dgv_Cell;
                    _Dg_GridPreFacturasAgre.ClearSelection();
                    
                }
                if (!_Pnl_Clave.Visible)
                {
                    _Bt_Imprimir.Enabled = true;
                }
                _Bt_EliminarPrefactura.Enabled = true;
            }
            else
            {
                if (_Txt_TemporalCod.Text.Trim().Length > 0)
                {
                    _Int_FrmNumPreFactAdd = 1;
                    string _Str_Cadena = "SELECT VST_PREFACTURASSEGUNRUTAS.ccompany AS Compañía,VST_PREFACTURASSEGUNRUTAS.cpfactura AS [Pre-Factura], VST_PREFACTURASSEGUNRUTAS.c_nomb_comer AS Cliente, VST_PREFACTURASSEGUNRUTAS.cempaques AS Cajas, VST_PREFACTURASSEGUNRUTAS.cunidades AS Unidades, VST_PREFACTURASSEGUNRUTAS.Kilos, dbo.Fnc_Formatear(c_monto_si) AS Total, CASE WHEN LEN(LTRIM(RTRIM(TCOTPEDFACM.cobservaciones)))>0 THEN 'SI' ELSE 'NO' END AS Observación, CONVERT(VARCHAR,TCOTPEDFACM.c_fecha_pedido,103) AS [Fec. Pedido],RTRIM(VST_PREFACTURASSEGUNRUTAS.cnamecanal) AS Canal,VST_PREFACTURASSEGUNRUTAS.c_factdevuelta, c_rif, VST_PREFACTURASSEGUNRUTAS.ccliente, cidrutdespacho, Metros, Monto, ciudad, VST_PREFACTURASSEGUNRUTAS.c_factdevuelta, VST_PREFACTURASSEGUNRUTAS.cprecarga, c_facturaanul FROM VST_PREFACTURASSEGUNRUTAS INNER JOIN TPREFACTURAM ON VST_PREFACTURASSEGUNRUTAS.cpfactura = TPREFACTURAM.cpfactura AND VST_PREFACTURASSEGUNRUTAS.ccompany = TPREFACTURAM.ccompany INNER JOIN TCOTPEDFACM ON TPREFACTURAM.cpedido = TCOTPEDFACM.cpedido AND TPREFACTURAM.ccompany = TCOTPEDFACM.ccompany WHERE VST_PREFACTURASSEGUNRUTAS.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_PREFACTURASSEGUNRUTAS.ccompany='" + Convert.ToString(_Txt_TemporalCod.Tag) + "' AND VST_PREFACTURASSEGUNRUTAS.cpfactura='" + _Txt_TemporalCod.Text.Trim() + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        object[] _Ob = new object[16];
                        _Ob[0] = Convert.ToString(_Txt_TemporalCod.Tag).Trim();
                        _Ob[1] = _Txt_TemporalCod.Text.Trim();
                        _Ob[2] = _Ds.Tables[0].Rows[0]["Cliente"].ToString().Trim();
                        _Ob[3] = _Ds.Tables[0].Rows[0]["Cajas"].ToString().Trim();
                        _Ob[4] = _Ds.Tables[0].Rows[0]["Unidades"].ToString().Trim();
                        _Ob[5] = _Ds.Tables[0].Rows[0]["Kilos"].ToString().Trim();
                        _Ob[6] = _Dg_GridPreFacturasAgre.Rows.Count + 1;
                        _Ob[7] = _Ds.Tables[0].Rows[0]["cidrutdespacho"].ToString().Trim();
                        _Ob[8] = _Ds.Tables[0].Rows[0]["Metros"].ToString().Trim();
                        _Ob[9] = _Ds.Tables[0].Rows[0]["Monto"].ToString().Trim();
                        _Ob[10] = _Ds.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                        _Ob[11] = _Ds.Tables[0].Rows[0]["c_rif"].ToString().Trim();
                        _Ob[12] = _Ds.Tables[0].Rows[0]["ciudad"].ToString().Trim();
                        _Ob[13] = _Ds.Tables[0].Rows[0]["c_factdevuelta"].ToString().Trim();
                        _Ob[14] = _Ds.Tables[0].Rows[0]["cprecarga"].ToString().Trim();
                        _Ob[15] = _Ds.Tables[0].Rows[0]["c_facturaanul"].ToString().Trim();
                        _Dg_GridPreFacturasAgre.Rows.Add(_Ob);
                        _Mtd_AjustarProgressbar();
                        //-------------------------------------------
                        if (_Ds.Tables[0].Rows[0][3] != System.DBNull.Value)
                        { _Dbl_Kilos = Convert.ToDouble(_Ds.Tables[0].Rows[0][3].ToString()); }
                        if (_Ds.Tables[0].Rows[0][5] != System.DBNull.Value)
                        { _Dbl_Metros = Convert.ToDouble(_Ds.Tables[0].Rows[0][5].ToString()); }
                        if (_Ds.Tables[0].Rows[0][6] != System.DBNull.Value)
                        { _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][6].ToString()); }
                        //-------------------------------------------
                        _Str_Cadena = _Mtd_VerificarLimitesExcedidos(_Dbl_Kilos, _Dbl_Metros, _Dbl_Monto);
                        if (_Str_Cadena.Trim().Length > 0)
                        {
                            if (MessageBox.Show("Se ha excedido: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transporte. ¿Esta seguro de ingresar esta prefactura?", "Avdertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                _Int_Imprimir = 0;
                                _ObTemp = _Ob;
                                _Lbl_TituloClave.Text = "Autorize la carga";
                                _Int_FrmClaveProceso = 1;
                                _Pnl_Clave.Visible = true;
                            }
                            else
                            {
                                _Int_FrmNumPreFactAdd = 0;
                                _Dg_GridPreFacturasAgre.Rows.RemoveAt(_Dg_GridPreFacturasAgre.RowCount - 1);
                                _Mtd_AjustarProgressbar();
                            }
                        }
                        else
                        {
                            DataGridViewCell _Dgv_Cell = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.Rows.Count - 1].Cells[0];
                            _Dg_GridPreFacturasAgre.CurrentCell = _Dgv_Cell;
                            _Dg_GridPreFacturasAgre.ClearSelection();
                            _Bt_Imprimir.Enabled = true;
                        }
                    }
                    _Bt_EliminarPrefactura.Enabled = true;
                }
            }
            Cursor = Cursors.WaitCursor;
            _Mtd_CalcularTotalCajas();
            _Mtd_CalcularCosto();
            _Mtd_Verificar_PrefacturasDev(_Dg_GridPreFacturasAgre);
            Cursor = Cursors.Default;
            _Dg_GridPreFacturasAgre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Bt_Subir_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPreFacturasAgre.Rows.Count > 0)
            {
                if (_Dg_GridPreFacturasAgre.SelectedRows.Count == 1)
                {
                    if (_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1 >= 0)
                    {
                        object _Ob0 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[0].Value;
                        object _Ob1 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[1].Value;
                        object _Ob2 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[2].Value;
                        object _Ob3 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[3].Value;
                        object _Ob4 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[4].Value;
                        object _Ob5 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[5].Value;
                        object _Ob6 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[6].Value;
                        object _Ob7 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[7].Value;
                        object _Ob8 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[8].Value;
                        object _Ob9 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[9].Value;
                        object _Ob10 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[10].Value;
                        object _Ob11 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[11].Value;
                        object _Ob12 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[12].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[0].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[0].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[1].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[1].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[2].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[2].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[3].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[3].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[4].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[4].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[5].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[5].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[6].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[6].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[7].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[7].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[8].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[8].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[9].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[9].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[10].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[10].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[11].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[11].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[12].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[12].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[0].Value = _Ob0;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[1].Value = _Ob1;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[2].Value = _Ob2;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[3].Value = _Ob3;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[4].Value = _Ob4;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[5].Value = _Ob5;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[6].Value = _Ob6;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[7].Value = _Ob7;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[8].Value = _Ob8;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[9].Value = _Ob9;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[10].Value = _Ob10;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[11].Value = _Ob11;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[12].Value = _Ob12;
                        DataGridViewCell _Dgv_Cell = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex - 1].Cells[0];
                        _Dg_GridPreFacturasAgre.CurrentCell = _Dgv_Cell;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Selected = true;
                        _Mtd_OrdebarOrden_PreFact();
                        _Mtd_Verificar_PrefacturasDev(_Dg_GridPreFacturasAgre);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void _Bt_Bajar_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPreFacturasAgre.Rows.Count > 0)
            {
                if (_Dg_GridPreFacturasAgre.SelectedRows.Count == 1)
                {
                    if (_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1 <= _Dg_GridPreFacturasAgre.Rows.Count - 1)
                    {
                        object _Ob0 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[0].Value;
                        object _Ob1 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[1].Value;
                        object _Ob2 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[2].Value;
                        object _Ob3 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[3].Value;
                        object _Ob4 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[4].Value;
                        object _Ob5 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[5].Value;
                        object _Ob6 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[6].Value;
                        object _Ob7 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[7].Value;
                        object _Ob8 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[8].Value;
                        object _Ob9 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[9].Value;
                        object _Ob10 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[10].Value;
                        object _Ob11 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[11].Value;
                        object _Ob12 = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[12].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[0].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[0].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[1].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[1].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[2].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[2].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[3].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[3].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[4].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[4].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[5].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[5].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[6].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[6].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[7].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[7].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[8].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[8].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[9].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[9].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[10].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[10].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[11].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[11].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[12].Value = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[12].Value;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[0].Value = _Ob0;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[1].Value = _Ob1;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[2].Value = _Ob2;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[3].Value = _Ob3;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[4].Value = _Ob4;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[5].Value = _Ob5;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[6].Value = _Ob6;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[7].Value = _Ob7;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[8].Value = _Ob8;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[9].Value = _Ob9;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[10].Value = _Ob10;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[11].Value = _Ob11;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells[12].Value = _Ob12;
                        DataGridViewCell _Dgv_Cell = _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex + 1].Cells[0];
                        _Dg_GridPreFacturasAgre.CurrentCell = _Dgv_Cell;
                        _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Selected = true;
                        _Mtd_OrdebarOrden_PreFact();
                        _Mtd_Verificar_PrefacturasDev(_Dg_GridPreFacturasAgre);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void _Mtd_OrdebarOrden_PreFact()
        {
            int _Int_C = 0;
            foreach (DataGridViewRow _DgRow in _Dg_GridPreFacturasAgre.Rows)
            {
                _Int_C++;
                _DgRow.Cells["Orden"].Value = _Int_C;
            }
        }
        private void _Mtd_CalcularTotalCajas()
        {
            int _Int_Cajas = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["CajasP"].Value).Trim().Length > 0)
                {
                    _Int_Cajas += Convert.ToInt32(Convert.ToString(_Dg_Row.Cells["CajasP"].Value).Trim());
                }
            }
            _Txt_Cajas.Text = _Int_Cajas.ToString();
        }
        private void _Mtd_Eliminar_Ruta(string _P_Str_Ruta)
        {
            if (_Txt_Precarga.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "DELETE FROM TPRECARGADR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text.Trim() + "' AND cidrutdespacho='" + _P_Str_Ruta + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                for (int _Int_I = 0; _Int_I <= _Dg_GridPreFacturasAgre.Rows.Count - 1; _Int_I++)
                {
                    if (Convert.ToString(_Dg_GridPreFacturasAgre["cidrutdespacho2", _Int_I].Value) == Convert.ToString(_Dg_GridRutasAgre[0, _Dg_GridRutasAgre.CurrentCell.RowIndex].Value))
                    {
                        _Mtd_Eliminar_Prefactura(Convert.ToString(_Dg_GridPreFacturasAgre.Rows[_Int_I].Cells["ccompanyagre"].Value), Convert.ToString(_Dg_GridPreFacturasAgre.Rows[_Int_I].Cells["cprefacagre"].Value), _Int_I);
                        _Int_I--;
                    }
                }
            }
            else
            {
                for (int _Int_I = 0; _Int_I <= _Dg_GridPreFacturasAgre.Rows.Count - 1; _Int_I++)
                {
                    if (Convert.ToString(_Dg_GridPreFacturasAgre["cidrutdespacho2", _Int_I].Value) == Convert.ToString(_Dg_GridRutasAgre[0, _Dg_GridRutasAgre.CurrentCell.RowIndex].Value))
                    {
                        _Dg_GridPreFacturasAgre.Rows.RemoveAt(_Int_I);
                        _Int_I--;
                    }
                }
            }
            _Dg_GridRutasAgre.Rows.RemoveAt(_Dg_GridRutasAgre.CurrentCell.RowIndex);
        }
        private void _Mtd_Eliminar_Prefactura(string _P_Str_Comp,string _P_Str_Prefactura, int _P_Int_Index)
        {
            if (_Txt_Precarga.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "DELETE FROM TPRECARGADPFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text.Trim() + "' AND cpfactura='" + _P_Str_Prefactura + "'";
                _Str_Cadena = "DELETE FROM TPRECARGADPF WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text.Trim() + "' AND cpfactura='" + _P_Str_Prefactura + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TPREFACTURAM SET cprecarga=0 WHERE ccompany='" + _P_Str_Comp + "' AND cprecarga='" + _Txt_Precarga.Text.Trim() + "' AND cpfactura='" + _P_Str_Prefactura + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            _Dg_GridPreFacturasAgre.Rows.RemoveAt(_P_Int_Index);
        }
        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPreFacturasAgre.Rows.Count > 0)
            {
                if (_Dg_GridPreFacturasAgre.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow _Fila in _Dg_GridPreFacturasAgre.SelectedRows)
                    {
                        if (_Fila.Selected)
                        {
                            _Mtd_Eliminar_Prefactura(Convert.ToString(_Fila.Cells["ccompanyagre"].Value), Convert.ToString(_Fila.Cells["cprefacagre"].Value), _Fila.Index);
                        }
                    }
                    //for (int i = (_Dg_GridPreFacturasAgre.Rows.Count - 1); i >= 0; i--)
                    //{
                    //    if (_Dg_GridPreFacturasAgre.Rows[i].Selected)
                    //    {
                            
                    //    }
                    //}

                    _Mtd_CalcularTotalCajas();
                    _Dg_GridPreFacturasAgre.ClearSelection();
                    _Mtd_AjustarProgressbar();
                    _Mtd_CalcularCosto();
                    _Mtd_Verificar_PrefacturasDev(_Dg_GridPreFacturasAgre);
                    _Bt_Verificacion.Enabled = false;
                }
                else
                { MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
            else
            { MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Tool_Principal.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; _Tool_Principal.Enabled = true; _Lbl_TituloClave.Text = "..."; }
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            if (_Int_FrmClaveProceso == 1)
            {
                for (int _I = 1; _I <= _Int_FrmNumPreFactAdd; _I++)
                {
                    _Dg_GridPreFacturasAgre.Rows.RemoveAt(_Dg_GridPreFacturasAgre.RowCount - 1);
                }
                _Int_FrmNumPreFactAdd = 0;
                _Mtd_AjustarProgressbar();
                _Mtd_CalcularCosto();
            }
            else if (_Int_FrmClaveProceso == 2)
            {
                if (_Txt_Precarga.Text.Trim() != "")
                {
                    string _Str_Sql = "SELECT * FROM TPRECARGASCANPAL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "'";
                    DataSet _DS = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_DS.Tables[0].Rows.Count == 0)
                    {
                        _Bt_Verificacion.Enabled = true;
                    }
                    else
                    {
                        _Bt_Verificacion.Enabled = false;
                    }
                }
                else
                { _Bt_Verificacion.Enabled = false; }
            }
            _Mtd_CalcularTotalCajas();
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }


        bool _Bol_Editar = false;
        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {
                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Pnl_Clave.Visible = false;
                    if (_Int_Imprimir == 0)
                    {
                        _Mtd_AjustarProgressbar();
                        _Bt_Imprimir.Enabled = true;
                    }
                    else if (_Int_Imprimir == 1)
                    {
                        if (!_Mtd_CantidadesEnPreFacturasHanCambiado())
                        {
                            _Mtd_Guardar();
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            if (_Txt_Precarga.Text.Trim() != "")
                            {
                                if (_Mtd_VerifPrecargaImpresa(_Txt_Precarga.Text))
                                {
                                    _Chk_PreImp.Checked = true;
                                    _Bt_Imprimir.Enabled = true;
                                }
                                else
                                {
                                    _Chk_PreImp.Checked = false;
                                    _Bt_Verificacion.Enabled = false;
                                }
                                if (_Chk_PreImp.Checked)
                                {
                                    _Str_Sql = "SELECT * FROM TPRECARGASCANPAL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "'";
                                    DataSet _DS = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_DS.Tables[0].Rows.Count == 0)
                                    {
                                        _Bt_Verificacion.Enabled = true;
                                        _Chk_VerifRealiz.Checked = false;
                                    }
                                    else
                                    {
                                        _Bt_Verificacion.Enabled = false;
                                        _Chk_VerifRealiz.Checked = true;
                                    }
                                }
                            }
                            else
                            { _Bt_Verificacion.Enabled = false; }
                        }
                        else
                        { MessageBox.Show("Otro usuario del sistema ha hecho cambios en una o más pre-facturas que afectan la validez de la pre-carga que usted está realizando.\nPor favor, elimine estas pre-facturas de la pre-carga, y agrégelas de nuevo para seguir con el proceso. \nLas pre-facturas afectadas se muestran en rojo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
            Cursor = Cursors.Default;
        }

     
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {   
            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IMP_PRECARGA"))
            {
                _Er_Error.Dispose();
                //if (_Txt_Placa.Text.Trim().Length > 0 & _Txt_Transportista.Text.Trim().Length > 0 & _Dg_GridRutasAgre.Rows.Count > 0 & _Dg_GridPreFacturasAgre.Rows.Count > 0)
                if (_Dg_GridRutasAgre.Rows.Count > 0 & _Dg_GridPreFacturasAgre.Rows.Count > 0)
                {
                    _Int_Imprimir = 1;
                    _Lbl_TituloClave.Text = "Impresión de Pre-Carga";
                    _Int_FrmClaveProceso = 2;
                    _Pnl_Clave.Visible = true;
                }
                else
                {
                    //if (_Txt_Placa.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Placa, "Información requerida!!!"); }
                    //if (_Txt_Transportista.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Transportista, "Información requerida!!!"); }
                    if (_Dg_GridRutasAgre.Rows.Count == 0)
                    { MessageBox.Show("No existen registros en la ruta de despacho. Por favor agregue...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else if (_Dg_GridPreFacturasAgre.Rows.Count == 0)
                    { MessageBox.Show("No existen registros en las pre-factura. Por favor agregue...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    //return false;
                }
            }
            else
            { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void _Bt_EliminarRuta_Click(object sender, EventArgs e)
        {
            if (_Dg_GridRutasAgre.Rows.Count > 0)
            {
                if (_Dg_GridRutasAgre.SelectedRows.Count == 1)
                {
                    _Mtd_Eliminar_Ruta(Convert.ToString(_Dg_GridRutasAgre.Rows[_Dg_GridRutasAgre.CurrentCell.RowIndex].Cells[0].Value).Trim());
                    _Mtd_CalcularTotalCajas();
                    if (_Dg_GridRutasAgre.Rows.Count == 0)
                    { _Bt_Prefacturas.Enabled = false; }
                    _Dg_GridRutasAgre.ClearSelection();
                    _Mtd_AjustarProgressbar();
                    _Mtd_CalcularCosto();
                    _Bt_Verificacion.Enabled = false;
                }
                else
                { MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
            else
            { MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Verificacion_Click(object sender, EventArgs e)
        {
            if (_Txt_Precarga.Text.Trim().Length > 0 && _Dg_GridPreFacturasAgre.RowCount > 0)
            {
                //////////////////////
                string _Str_Cadena = "Update TPRECARGAM set cverificascanpalm='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("La verificación fue satisfactoria", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Tb_Tab.Deselecting -= new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
                _Tb_Tab.SelectTab(2);
                _Tb_Tab.Deselecting += new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
                _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
                _Chk_VerifRealiz.Checked = true;
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                //////////////////////
                //bool _Bol_Sw = false;
                //string _Str_Cadena = "";
                //DataSet _Ds;

                //_Str_Cadena = "SELECT * FROM TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "'";
                //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                //if (_Ds.Tables[0].Rows.Count == 0)
                //{
                //    _Bol_Sw = true;
                //}
                //else
                //{
                //    MessageBox.Show("Ya se hizo una descarga.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //if (_Bol_Sw)
                //{
                    //_Str_Cadena = "Select cimprimeprecarga from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
                    //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //if (_Ds.Tables[0].Rows.Count > 0)
                    //{
                    //    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    //    {
                    //        OpenFileDialog _Ofd_File = new OpenFileDialog();
                    //        _Ofd_File.Filter = "txt files (*.txt)|*.txt";
                    //        _Ofd_File.ShowDialog(this);
                    //        if (_Ofd_File.FileName.Trim().Length > 0)
                    //        {
                    //            Cursor = Cursors.WaitCursor;
                                //_Mtd_LeerArchivo(_Ofd_File.FileName);
                    //            if ((Frm_Padre)this.MdiParent != null)
                    //            {
                    //                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    //            }
                    //            Cursor = Cursors.Default;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Debe imprimir la pre-carga para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Debe imprimir la pre-carga para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                //}  
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPreFacturasAgre.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                Frm_ConsultaPreFacturaDetalle _Frm = new Frm_ConsultaPreFacturaDetalle(_Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["cprefacagre"].Value.ToString(), _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["CodCliente"].Value.ToString(),
                                                                                     _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["CajasP"].Value.ToString(), _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["UnidadesP"].Value.ToString(),
                                                                                     _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["Monto"].Value.ToString(), _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["c_rif"].Value.ToString(), _Dg_GridPreFacturasAgre.Rows[_Dg_GridPreFacturasAgre.CurrentCell.RowIndex].Cells["ccompanyagre"].Value.ToString());
                Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (_Dg_GridRutasAgre.CurrentCell != null)
            {
                Frm_RutaDespacho _Frm = new Frm_RutaDespacho(_Dg_GridRutasAgre.Rows[_Dg_GridRutasAgre.CurrentCell.RowIndex].Cells[0].Value.ToString());
                _Frm.ShowDialog(this);
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPrecarga.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Dg_GridRutasAgre.Rows.Clear();
                _Dg_GridPreFacturasAgre.Rows.Clear();
                _Dg_GridVerificacion.DataSource = null;
                string _Str_Cadena = "Select cplaca,ccedula,ctipocliente,ctipoalimento from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Dg_GridPrecarga.Rows[_Dg_GridPrecarga.CurrentCell.RowIndex].Cells["cprecarga2"].Value + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _G_Str_TipoClienteSel = _Ds.Tables[0].Rows[0]["ctipocliente"].ToString();
                    _G_Str_TipoAlimentoSel = _Ds.Tables[0].Rows[0]["ctipoalimento"].ToString();
                    if (_G_Str_TipoClienteSel.Length > 0)
                    {
                        if (_Cmb_TipoCliente.Items.Count > 0)
                        {
                            _Cmb_TipoCliente.SelectedValue = _G_Str_TipoClienteSel;
                            _Cmb_TipoPrecarga.SelectedValue = _G_Str_TipoAlimentoSel;
                            _Lbl_TipoPrecarga.Text = "TIPO " + _Cmb_TipoPrecarga.Text.Trim() + " PARA " + _Cmb_TipoCliente.Text.Trim();
                        }
                    }                    
                    _Txt_Precarga.Text = _Dg_GridPrecarga.Rows[_Dg_GridPrecarga.CurrentCell.RowIndex].Cells["cprecarga2"].Value.ToString();
                    _Txt_Placa.Text = _Ds.Tables[0].Rows[0][0].ToString();
                    _Str_Cedula = _Ds.Tables[0].Rows[0][1].ToString();
                    _Str_Cadena = "Select cnombre from TTRANSPORTISTA where cplaca='" + _Txt_Placa.Text.Trim() + "' and ccedula='" + _Str_Cedula + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Txt_Transportista.Text = _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
                    }
                    _Str_Cadena = "SELECT  TRUTDESPACHOM.cidrutdespacho, TRUTDESPACHOM.cdescripcion, TRUTDESPACHOM.cdistanciakm " +
"FROM TRUTDESPACHOM INNER JOIN " +
"TPRECARGADR ON TRUTDESPACHOM.cgroupcomp = TPRECARGADR.cgroupcomp AND " +
"TRUTDESPACHOM.cidrutdespacho = TPRECARGADR.cidrutdespacho " +
"WHERE (TRUTDESPACHOM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGADR.cprecarga = '" + _Txt_Precarga.Text.Trim() + "')";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    object[] _Ob = new object[3];
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        _Ob[0] = _Row[0].ToString();
                        _Ob[1] = _Row[1].ToString();
                        _Ob[2] = _Row[2].ToString();
                        _Dg_GridRutasAgre.Rows.Add(_Ob);
                        _Dg_GridRutasAgre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    _Str_Cadena = "SELECT ccompany, cpfactura, ctotalempaq, ctotalunidad, ctotalkg, cordendespacho, cidrutdespacho, ccliente, Metros, Monto, c_rif, c_nomb_comer, cpfacturasnuevas, cpfacturasnuevasfechora, ciudad,facturaanulada,c_factdevuelta,cprecarga FROM VST_PREFAC_EN_PRECARGA WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cprecarga = '" + _Txt_Precarga.Text.Trim() + "')";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    _Ob = new object[16];
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        _Ob[0] = _Row["ccompany"].ToString();
                        _Ob[1] = _Row["cpfactura"].ToString();
                        _Ob[2] = _Row["c_nomb_comer"].ToString();
                        _Ob[3] = _Row["ctotalempaq"].ToString();
                        _Ob[4] = _Row["ctotalunidad"].ToString();
                        _Ob[5] = _Row["ctotalkg"].ToString();
                        _Ob[6] = _Row["cordendespacho"].ToString();
                        _Ob[7] = _Row["cidrutdespacho"].ToString();
                        _Ob[8] = _Row["Metros"].ToString();
                        _Ob[9] = _Row["Monto"].ToString();
                        _Ob[10] = _Row["ccliente"].ToString();
                        _Ob[11] = _Row["c_rif"].ToString();
                        _Ob[12] = _Row["ciudad"].ToString();
                        _Ob[13] = _Row["c_factdevuelta"].ToString().Trim();
                        _Ob[14] = _Row["cprecarga"].ToString().Trim();
                        _Ob[15] = _Row["facturaanulada"].ToString().Trim();
                        _Ds_DataSetGen.Tables[0].Rows.Add(new object[] { _Txt_Precarga.Text.Trim(), _Row["cpfactura"].ToString(), _Row["cpfacturasnuevas"].ToString(), _Row["cpfacturasnuevasfechora"].ToString() });
                        _Dg_GridPreFacturasAgre.Rows.Add(_Ob);
                        _Dg_GridPreFacturasAgre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    _Mtd_BuscarLimites(_Txt_Placa.Text.Trim());
                    _Mtd_AjustarProgressbar();
                    _Mtd_Actualizar_Dg_GridVerificacion(_Txt_Precarga.Text);
                    _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                    _Tb_Tab.SelectedIndex = 1;
                    _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);

                    if (_Txt_Precarga.Text != "")
                    {
                        if (_Mtd_VerifPrecargaVerificado(_Txt_Precarga.Text))
                        {
                            _Bt_Verificacion.Enabled = false;
                            _Chk_VerifRealiz.Checked = true;
                        }
                        else
                        {
                            _Bt_Verificacion.Enabled = true;
                            _Chk_VerifRealiz.Checked = false;
                        }

                        if (_Mtd_VerifPrecargaImpresa(_Txt_Precarga.Text))
                        {
                            _Chk_PreImp.Checked = true;
                        }
                        else
                        {
                            _Chk_PreImp.Checked = false;
                        }
                    }
                    else
                    {
                        _Chk_PreImp.Checked = false;
                        _Chk_VerifRealiz.Checked = false;
                    }
                    _Mtd_Verificar_PrefacturasDevSinPrecarga(_Dg_GridPreFacturasAgre);
                    _Bt_Transporte.Enabled = false;
                    _Bt_Rutas.Enabled = false;
                    _Bt_EliminarRuta.Enabled = false;
                    _Bt_Prefacturas.Enabled = false;
                    _Bt_EliminarPrefactura.Enabled = false;
                    _Bt_Bajar.Enabled = false;
                    _Bt_Subir.Enabled = false;
                    _Bt_Imprimir.Enabled = true;
                    _Mtd_CalcularCosto();
                }
                _Bt_EditaPreCarga.Visible = myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDITA_PRECARGA");
                _Mtd_CalcularTotalCajas();
                Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            _Int_EstatusPre = 3;
            _Mtd_ActualizarToolPrecarga(_Int_EstatusPre);
        }

        private void preCargasSinCulminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Int_EstatusPre = 4; //PRECARGAS SIN CULMINAR
            _Mtd_ActualizarToolPrecarga(_Int_EstatusPre);
        }
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            _Int_EstatusPre = 2; //PRECARGAS SIN VERIFICACION
            _Mtd_ActualizarToolPrecarga(_Int_EstatusPre);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            _Int_EstatusPre = 1; //PRECARGAS SIN IMPRIMIR
            _Mtd_ActualizarToolPrecarga(_Int_EstatusPre);
        }

        private void _Mtd_ActualizarToolPrecarga(int Int_EstatusPre)
        {
            toolStripComboBox1.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar_Dg_GridPrecarga(Int_EstatusPre);
            _Mtd_Actualizar_Dg_GridTrasportes();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            _Int_EstatusPre = 0;
            _Mtd_ActualizarToolPrecarga(_Int_EstatusPre);
        }
        private void _Mtd_CargarCampoCliente()
        {
            string _Str_SQL = "SELECT TOP 1 ctipoestempleado, ctipoestaccionista, ctipoestcomprela, ctipoesttransport FROM TCONFIGVENT";
            DataSet _Ds_DataSet = new DataSet();
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _G_Str_ClienteAcc = _Ds_DataSet.Tables[0].Rows[0][1].ToString().Trim();
                _G_Str_ClienteCompRela = _Ds_DataSet.Tables[0].Rows[0][2].ToString().Trim();
                _G_Str_ClienteEmpl = _Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim();
                _G_Str_ClienteTransp = _Ds_DataSet.Tables[0].Rows[0][3].ToString().Trim();
            }
        }
        private void _Mtd_CargarTipoCliente()
        {
            if (_G_Str_ClienteAcc.Length > 0 && _G_Str_ClienteCompRela.Length > 0 && _G_Str_ClienteEmpl.Length > 0 && _G_Str_ClienteTransp.Length > 0)
            {
                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
                _Cmb_TipoCliente.DataSource = null;
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("ACCIONISTAS", _G_Str_ClienteAcc));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("CLIENTES REGULARES", "0"));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("COMPAÑIAS RELACIONADAS", _G_Str_ClienteCompRela));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("EMPLEADOS", _G_Str_ClienteEmpl));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("TRANSPORTISTAS", _G_Str_ClienteTransp));
                _Cmb_TipoCliente.DataSource = _myArrayList;
                _Cmb_TipoCliente.DisplayMember = "Display";
                _Cmb_TipoCliente.ValueMember = "Value";
                _Cmb_TipoCliente.SelectedValue = "nulo";
                _Cmb_TipoCliente.DataSource = _myArrayList;
                _Cmb_TipoCliente.SelectedIndex = 0;
            }
        }
        private void _Mtd_CargarTipoPrecarga()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoPrecarga.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ALIMENTOS", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MIXTA", "2"));
            _Cmb_TipoPrecarga.DataSource = _myArrayList;
            _Cmb_TipoPrecarga.DisplayMember = "Display";
            _Cmb_TipoPrecarga.ValueMember = "Value";
            _Cmb_TipoPrecarga.SelectedValue = "nulo";
            _Cmb_TipoPrecarga.DataSource = _myArrayList;
            _Cmb_TipoPrecarga.SelectedIndex = 0;
        }
        private void _Mtd_IniPreCarga()
        {
            _Mtd_CargarTipoCliente();
            _Mtd_CargarTipoPrecarga();
            _Txt_Precarga.Text = "";
            _Txt_Cajas.Text = "";
            _Txt_Placa.Text = "";
            _Txt_Transportista.Text = "";
            _Prb_Kg.Value = 0;
            _Txt_Kg.Text = "0";
            _Lbl_TipoPrecarga.Text = "";
            _Prb_Mt.Value = 0;
            _Txt_Mt.Text = "0";
            _Prb_Bs.Value = 0;
            _Txt_Bs.Text = "0";
            _Dg_GridRutasAgre.Rows.Clear();
            _Dg_GridPreFacturasAgre.Rows.Clear();
            _Txt_Costo.Text = "";
            _Txt_CostoFijo.Text = "";
            _Txt_CostoVariable.Text = "";
            _Dg_GridVerificacion.DataSource = null;
            _Bt_Transportista.Enabled = false;
            _Bt_Transporte.Enabled = true;
            _Bt_Rutas.Enabled = false;
            _Bt_EliminarRuta.Enabled = false;
            _Bt_Prefacturas.Enabled = false;
            _Bt_EliminarPrefactura.Enabled = false;
            _Bt_Bajar.Enabled = false;
            _Bt_Subir.Enabled = false;
            _Bt_Imprimir.Enabled = false;
            _Bt_Verificacion.Enabled = false;
            _Chk_PreImp.Checked = false;
            _Chk_VerifRealiz.Checked = false;
            _Chk_PreImp.Enabled = false;
            _Chk_VerifRealiz.Enabled = false;
            _Int_Estatus = 0;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_PRECARGA_SOLOCONSULTA"))
            {
                e.Cancel = true;
                return;
            }
            //bool _Bol_R = false;
            if (e.TabPageIndex == 1)
            {
                if (_Bt_Transporte.Enabled && _Txt_Precarga.Text == "" && _Txt_Placa.Text != "")
                {//SE ESTABA CREANDO UNA
                    MessageBox.Show("Se continua la carga de la Pre-Carga.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Desea crear una nueva Pre-Carga", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Bol_Editar = false;
                        _Mtd_IniPreCarga();
                        _Cmb_TipoCliente.SelectedValue = "0";
                        _Cmb_TipoPrecarga.SelectedValue = "0";
                        _Bt_EditaPreCarga.Visible = false;
                        _Pnl_TipoCliente.Visible = true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                if (_Txt_Precarga.Text != "")
                {
                    if (_Mtd_VerifPrecargaVerificado(_Txt_Precarga.Text))
                    {
                        _Bt_Verificacion.Enabled = false;
                        _Chk_VerifRealiz.Checked = true;
                    }
                    else
                    {
                        _Bt_Verificacion.Enabled = true;
                        _Chk_VerifRealiz.Checked = false;
                    }

                    if (_Mtd_VerifPrecargaImpresa(_Txt_Precarga.Text))
                    {
                        _Chk_PreImp.Checked = true;
                    }
                    else
                    {
                        _Chk_PreImp.Checked = false;
                    }
                }
                else
                {
                    _Chk_PreImp.Checked = false;
                    _Chk_VerifRealiz.Checked = false;
                }
            }
            else if (e.TabPageIndex == 0)
            {
                toolStripSplitButton4.Enabled = false;
                toolStripSplitButton1.Enabled = true;

                Cursor = Cursors.WaitCursor;
                _Int_Estatus = 1;
                _Mtd_Actualizar_Dg_GridPreFacturas(_Int_Estatus, toolStripComboBox1.Text);
                _Mtd_Actualizar_Dg_GridPrecarga(_Int_EstatusPre);
                _Mtd_Actualizar_Dg_GridTrasportes();
                Cursor = Cursors.Default;
            }
            else if (e.TabPageIndex == 2)
            {
                toolStripSplitButton1.Enabled = false;
                toolStripSplitButton4.Enabled = true;
            }
        }
        bool _Bol_CancelTipoCliente = false;
        private void _Tb_Tab_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (!_Bol_CancelTipoCliente)
                {
                    if (_Bt_Transporte.Enabled)
                    {//SE ESTA CREANDO UNA PRECARGA
                        if (MessageBox.Show("No ha guardado la Precarga. ¿Desea cancelarla?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Mtd_IniPreCarga();
                        }
                    }
                }
            }
        }

        private bool _Mtd_VerifPrecargaImpresa(string _Pr_Str_Precarga)
        {
            bool _Bol_R = false;
            string _Str_Sql = "SELECT cimprimeprecarga FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_Precarga + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == "1")
                {
                    _Bol_R = true;
                }
                else
                {
                    _Bol_R = false;
                }
            }
            return _Bol_R;
        }

        private bool _Mtd_VerifPrecargaVerificado(string _Pr_Str_Precarga)
        {
            bool _Bol_R = false;
            string _Str_Sql = "SELECT cverificascanpalm FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_Precarga + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if  (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == "1")
                {
                    _Bol_R = true;
                }
                else
                {
                    _Bol_R = false;
                }
            }
            return _Bol_R;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_GridPreFacturas.RowCount>0)
            {
                verDetalleToolStripMenuItem.Visible = true;
            }
            else
            {
                verDetalleToolStripMenuItem.Visible = false;
            }
        }

        private void _Txt_Placa_TextChanged(object sender, EventArgs e)
        {
            _Txt_Transportista.Text = "";
        }

        private void _Mtd_CalcularCosto()
        {
            DataSet _Ds;

            string _Str_Tpo_nfactor = "c_tipo_nfactor_";//cam1
            string _Str_Tpo_pfactor = "c_tipo_pfactor_";//cam2
            string _Str_FactNum = "c_fact_num_";//cam11
            string _Str_FactPorc = "c_fact_porc_";//cam22
            double _Dbl_PorcVariables = 0;//por_variables
            double _Dbl_PorcFijos = 0;//por_fijos
            double _Dbl_NumVariables = 0;//num_variables
            double _Dbl_NumFijos = 0;//num_fijos
            string _Str_fieldTpo_nfactor = "";//evaluar
            string _Str_fieldTpo_pfactor = "";//evaluar2
            string _Str_fieldFactNum = "";//sum1
            string _Str_fieldFactPorc = "";//sum2
            double _Dbl_MPorc = 0;//por

            string _Str_Sql = "";   
            double _Dbl_MontoSimpRutaDespacho = 0;
            double _Dbl_CostoDespacho = 0;
            double _Dbl_CostoVarDespacho = 0;
            double _Dbl_CostoFijoDespacho = 0;

            foreach (DataGridViewRow _DgRow in _Dg_GridPreFacturasAgre.Rows)
            {
                _Dbl_MontoSimpRutaDespacho += Convert.ToDouble(_DgRow.Cells["Monto"].Value);
            }

            foreach (DataGridViewRow _DgRow in _Dg_GridRutasAgre.Rows)
            {
                _Dbl_NumVariables = 0;
                _Dbl_NumFijos = 0;
                _Dbl_PorcVariables = 0;
                _Dbl_PorcFijos = 0;
                
                if (_Dbl_MontoSimpRutaDespacho > 0)
                {
                    _Str_Sql = "select * from TTABULADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _DgRow.Cells[0].Value.ToString() + "' and cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow _DRow_ConfigRutas = _Ds.Tables[0].Rows[0];
                        for (int i = 1; i <= 10; i++)
                        {
                            _Dbl_MPorc = 0;
                            _Str_fieldTpo_nfactor = _Str_Tpo_nfactor + i.ToString();
                            _Str_fieldTpo_pfactor = _Str_Tpo_pfactor + i.ToString();
                            _Str_fieldFactNum = _Str_FactNum + i.ToString();
                            _Str_fieldFactPorc = _Str_FactPorc + i.ToString();

                            if (_DRow_ConfigRutas[_Str_fieldTpo_nfactor].ToString() == "0")
                            {
                                _Dbl_NumVariables = _Dbl_NumVariables + Convert.ToDouble(_DRow_ConfigRutas[_Str_fieldFactNum]);
                            }
                            if (_DRow_ConfigRutas[_Str_fieldTpo_nfactor].ToString() == "1")
                            {
                                _Dbl_NumFijos = _Dbl_NumFijos + Convert.ToDouble(_DRow_ConfigRutas[_Str_fieldFactNum]);
                            }
                            //----------------------------------------------------------
                            if (_DRow_ConfigRutas[_Str_fieldTpo_pfactor].ToString() == "0")
                            {
                                _Dbl_MPorc = (_Dbl_MontoSimpRutaDespacho * Convert.ToDouble(_DRow_ConfigRutas[_Str_fieldFactPorc])) / 100;
                                _Dbl_PorcVariables = _Dbl_PorcVariables + _Dbl_MPorc;
                            }
                            if (_DRow_ConfigRutas[_Str_fieldTpo_pfactor].ToString() == "1")
                            {
                                _Dbl_MPorc = (_Dbl_MontoSimpRutaDespacho * Convert.ToDouble(_DRow_ConfigRutas[_Str_fieldFactPorc])) / 100;
                                _Dbl_PorcFijos = _Dbl_PorcFijos + _Dbl_MPorc;
                            }
                        }
                        _Dbl_CostoVarDespacho = _Dbl_CostoVarDespacho + (_Dbl_NumVariables + _Dbl_PorcVariables);
                        _Dbl_CostoFijoDespacho = _Dbl_CostoFijoDespacho + (_Dbl_NumFijos + _Dbl_PorcFijos);
                        _Dbl_CostoDespacho = _Dbl_CostoDespacho + (_Dbl_NumVariables + _Dbl_PorcVariables + _Dbl_NumFijos + _Dbl_PorcFijos);
                    }
                }
            }

            _Txt_CostoFijo.Text = _Dbl_CostoFijoDespacho.ToString("#,##0.00");
            _Txt_CostoVariable.Text = _Dbl_CostoVarDespacho.ToString("#,##0.00");
            _Txt_Costo.Text = _Dbl_CostoDespacho.ToString("#,##0.00");
        }

        private void _Dg_GridPreFacturas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgPreFacturasInfo.Visible = true;
            }
            else
            {
                _Lbl_DgPreFacturasInfo.Visible = false;
            }
        }

        private void _Dg_GridRutas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgRutasInfo.Visible = true;
            }
            else
            {
                _Lbl_DgRutasInfo.Visible = false;
            }
        }

        private void _Dg_GridRutasAgre_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgRutasAgreInfo.Visible = true;
            }
            else
            {
                _Lbl_DgRutasAgreInfo.Visible = false;
            }
        }

        private void _Dg_GridPreFacturasAgre_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgPreFacturasAgreInfo.Visible = true;
            }
            else
            {
                _Lbl_DgPreFacturasAgreInfo.Visible = false;
            }
        }

        private void _Dg_GridPrecarga_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgPrecargaInfo.Visible = true;
            }
            else
            {
                _Lbl_DgPrecargaInfo.Visible = false;
            }
        }

        private void _Bt_OkRuta_Click(object sender, EventArgs e)
        {
        A:
            string _Str_Sql = "";
            bool _Bol_Sw = false;
            DataSet _Ds;
            string _Str_IdRutaSel = "";
            if (_ChkLst_RutasSel.SelectedItems.Count > 0)
            {
                foreach (object _MyObjeto in _ChkLst_RutasSel.SelectedItems)
                {
                    _Str_IdRutaSel = ((Clases._Cls_ArrayList)_MyObjeto).Value;
                    break;
                }
                foreach (object _MyObjeto in _ChkLst_RutasSel.Items)
                {
                    if (_Str_IdRutaSel != ((Clases._Cls_ArrayList)_MyObjeto).Value)
                    {
                        for (int _I = 0; _I < _Dg_GridRutasAgre.Rows.Count; _I++)
                        {
                            if (_Dg_GridRutasAgre[0, _I].Value.ToString().Trim() == ((Clases._Cls_ArrayList)_MyObjeto).Value.Trim())
                            {
                                _Dg_GridRutasAgre.Rows.RemoveAt(_I);
                            }
                        }
                    }
                }
                _Mtd_CargaCheckListRutasDupli();
                if (_ChkLst_RutasSel.Items.Count > 0)
                {
                    MessageBox.Show("Todavía existen rutas con estados y ciudades iguales, seleccione una por favor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto A;
                }
                else
                {
                    for (int _I = 0; _I < _Dg_GridPreFacturasAgre.Rows.Count; _I++)
                    {
                        _Bol_Sw = false;
                        foreach (DataGridViewRow _DgRow in _Dg_GridRutasAgre.Rows)
                        {
                            _Str_Sql = "SELECT cpfactura FROM VST_PREFACTURASSEGUNRUTAS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho=" + _DgRow.Cells[0].Value.ToString();
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                            {
                                if (_Dg_GridPreFacturasAgre["cprefacagre", _I].Value.ToString() == _Drow["cpfactura"].ToString())
                                {
                                    _Bol_Sw = true;
                                    break;
                                }
                            }
                        }
                        if (!_Bol_Sw)
                        {
                            _Dg_GridPreFacturasAgre.Rows.RemoveAt(_I);
                            _I--;
                        }
                    }
                    _Pnl_SelRuta.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una ruta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string _Mtd_FiltroRutasDuplicadas()
        {
            DataSet _Ds_Ant, _Ds_Next;
            bool _Bol_Sw = false;
            string _Str_EstadoAnt = "", _Str_CiudadAnt = "", _Str_RutaAnt="";
            string _Str_Estado = "", _Str_Ciudad = "", _Str_Ruta = "";
            string _Str_RutasDupli = "";
            string _Str_Sql = "";
            foreach (DataGridViewRow _DgRow in _Dg_GridRutasAgre.Rows)
            {
                _Str_Sql = "SELECT cestate,ccity,cpriodespacho FROM TRUTDESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _DgRow.Cells[0].Value.ToString() + "'";
                _Ds_Ant = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Drow in _Ds_Ant.Tables[0].Rows)
                {
                    _Str_EstadoAnt = _Drow["cestate"].ToString();
                    _Str_CiudadAnt = _Drow["ccity"].ToString();
                    _Str_RutaAnt = _DgRow.Cells[0].Value.ToString();

                    foreach (DataGridViewRow _DgRowInt in _Dg_GridRutasAgre.Rows)
                    {
                        if (_DgRow.Index != _DgRowInt.Index)
                        {
                            _Str_Sql = "SELECT cestate,ccity,cpriodespacho FROM TRUTDESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _DgRowInt.Cells[0].Value.ToString() + "'";
                            _Ds_Next = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            foreach (DataRow _Drow_Int in _Ds_Next.Tables[0].Rows)
                            {
                                _Str_Estado = _Drow_Int["cestate"].ToString();
                                _Str_Ciudad = _Drow_Int["ccity"].ToString();
                                _Str_Ruta = _DgRowInt.Cells[0].Value.ToString();
                                if (_Str_EstadoAnt == _Str_Estado && _Str_CiudadAnt == _Str_Ciudad)
                                {
                                    _Str_RutasDupli = _Str_RutasDupli + _Str_Ruta + ",";
                                    _Bol_Sw = true;
                                }
                            }
                        }
                    }
                }
                if (_Bol_Sw)
                {
                    _Str_RutasDupli = _Str_RutasDupli + _Str_RutaAnt;
                    //_Str_RutasDupli = _Str_RutasDupli.Substring(0, _Str_RutasDupli.Length - 1);
                    break;
                    //_Str_RutasDupli = _Str_RutasDupli + _Str_RutaAnt + ";"; //(1,2;5,6,7)
                }
                _Bol_Sw = false;
                
            }
            return _Str_RutasDupli;
        }
        private void _Mtd_CargaCheckListRutasDupli()
        {
            string _Str_Filtro = "", _Str_Sql = "";
            string _Str_RutasDupli = "";
            char[] _DelimiterChars = { ',' };
            _Str_RutasDupli = _Mtd_FiltroRutasDuplicadas();
            string[] _words = _Str_RutasDupli.Split(_DelimiterChars);
            foreach (string _Str_IdRuta in _words)
            {
                if (_Str_IdRuta.Length > 0)
                {
                    _Str_Filtro = _Str_Filtro + "cidrutdespacho=" + _Str_IdRuta + " OR ";
                }
            }
            if (_Str_Filtro.Length > 0)
            {
                _Str_Filtro = "(" + _Str_Filtro.Substring(0, _Str_Filtro.Length - 4) + ")";
                _Str_Sql = "SELECT cidrutdespacho,cdescripcion + ' KM:' + CONVERT(VARCHAR(15),cdistanciakm) FROM TRUTDESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND " + _Str_Filtro;
                myUtilidad._Mtd_CargarCheckList(_ChkLst_RutasSel, _Str_Sql);
            }
            else
            {
                _ChkLst_RutasSel.DataSource = null;
            }
        }
        private void _Pnl_SelRuta_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_SelRuta.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Mtd_CargaCheckListRutasDupli();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Bt_CancelRuta_Click(object sender, EventArgs e)
        {
            if (_ChkLst_RutasSel.Items.Count > 0)
            {
                if (MessageBox.Show("Si Cancela se eliminarán las rutas seleccionadas anteriormente. ¿Seguro que desea cancelar?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    char[] _DelimiterChars = { ',' };
                    string[] _words = _Str_FrmRutasAdd.Split(_DelimiterChars);
                    foreach (string _Str_IdRuta in _words)
                    {
                        for (int _I = 0; _I < _Dg_GridRutasAgre.Rows.Count; _I++)
                        {
                            if (_Dg_GridRutasAgre[0, _I].Value.ToString().Trim() == _Str_IdRuta.Trim())
                            {
                                _Dg_GridRutasAgre.Rows.RemoveAt(_I);
                            }
                        }
                    }
                    _Pnl_SelRuta.Visible = false;
                }
            }
        }

        private void _ChkLst_RutasSel_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                foreach (int _MyItem in _ChkLst_RutasSel.CheckedIndices)
                {
                    _ChkLst_RutasSel.SetItemChecked(_MyItem, false);
                }
            }
        }

        private void _Bt_VerTranspBlock_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar_Dg_GridTrasportesAll();
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "UPDATE TTRANSPORTE SET cesperando=1,cocupado=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cplaca='" + _Dg_GridTrasportes[0, _Dg_GridTrasportes.CurrentCell.RowIndex].Value.ToString() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Mtd_Actualizar_Dg_GridTrasportesAll();
            this.Cursor = Cursors.Default;
        }

        private void _Cntx_Menu6_Opening(object sender, CancelEventArgs e)
        {
            if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_TRANS_LIBRE"))
            {
                if (_Dg_GridTrasportes.SelectedRows.Count == 0)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (_Dg_GridTrasportes["_DgCol_cesperando", _Dg_GridTrasportes.CurrentCell.RowIndex].Value.ToString() == "1")
                    {
                        e.Cancel = true;
                    }
                }
                if (!e.Cancel)
                {
                    toolStripMenuItem17.Text = "Desbloquear el transporte de la placa " + _Dg_GridTrasportes[0, _Dg_GridTrasportes.CurrentCell.RowIndex].Value.ToString();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void _Dg_GridTrasportes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgTranspInfo.Visible = true;
            }
            else
            {
                _Lbl_DgTranspInfo.Visible = false;
            }
        }

        private void _Dg_GridPreFacturas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Verificar_PrefacturasDev();
            this.Cursor = Cursors.Default;
        }

        private void _Dg_GridPreFacturasAgre_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Dg_GridPreFacturasAgre.Rows.Count > 0)
            {
                _Mtd_Verificar_PrefacturasDev(_Dg_GridPreFacturasAgre);
            }
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_DesocuparTransporte(string _P_Str_PreCarga)
        {
            string _Str_Cadena = "SELECT ISNULL(cplaca,0) FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_Cadena = "Update TTRANSPORTE set cocupado='0',cesperando='1' where cplaca='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Bt_EditaPreCarga_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (MessageBox.Show("Al editar la precarga tendrá que re-imprimir la Pre-Carga y volver a verificar. ¿Desea continuar?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                _Mtd_DesocuparTransporte(_Txt_Precarga.Text.Trim());
                string _Str_Sql = "UPDATE TPRECARGAM SET cimprimeprecarga='0',cverificascanpalm='0',cplaca='0',ccedula='0',cfechaasigtransp=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "'";                
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);                
                _Str_Sql = "DELETE FROM TPRECARGASCANPAL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Chk_PreImp.Checked = false;
                _Chk_VerifRealiz.Checked = false;
                _Bt_Rutas.Enabled = true;
                _Bt_Prefacturas.Enabled = true;
                _Bt_EliminarRuta.Enabled = true;
                _Bt_EliminarPrefactura.Enabled = true;
                _Bt_Subir.Enabled = true;
                _Bt_Bajar.Enabled = true;
                _Bol_Editar = true;
                if (_Bol_Editar)
                {
                    _Int_Edicion = _Mtd_IntCantEdicion(_Txt_Precarga.Text);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void _Bt_RutasSegPre_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_RutasSegunPref _Frm = new Frm_RutasSegunPref();
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Imp_PreF_Click(object sender, EventArgs e)
        {
            if (_Txt_Precarga.Text.Trim().Length > 0)
            {
                bool _Bol_Sw = false;
                string _Str_Cadena = "";
                DataSet _Ds;

                _Str_Cadena = "SELECT * FROM TPRECARGASCANPAL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_Precarga.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    _Bol_Sw = true;
                }
                else
                {
                    MessageBox.Show("Ya se hizo una descarga.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (_Bol_Sw)
                {
                    _Str_Cadena = "Select cimprimeprecarga from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cprecarga='" + _Txt_Precarga.Text.Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                        {
                            Cursor = Cursors.WaitCursor;
                            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(1, _Txt_Precarga.Text.Trim());
                            Cursor = Cursors.Default;
                            _Frm_Inf.MdiParent = this.MdiParent;
                            _Frm_Inf.Dock = DockStyle.Fill;
                            _Frm_Inf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Debe imprimir la pre-carga para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe imprimir la pre-carga para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Bt_CerrarO_Click(object sender, EventArgs e)
        {
            _Pnl_Carga.Visible = false;
            _Tb_Tab.Deselecting -= new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
            _Tb_Tab.SelectTab(0);
            _Tb_Tab.Deselecting += new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
        }

        private void _Pnl_Carga_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Carga.Visible)
            { _Tb_Tab.Enabled = false; _Tool_Principal.Enabled = false; }
            else
            { _Tb_Tab.Enabled = true; _Tool_Principal.Enabled = true; }
        }
        string _Str_PlacaOculta = "";
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Str_PlacaOculta = _Mtd_ObtenerPlacaOculta(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[1].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[2].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[3].Value).Trim());
                if (_Str_PlacaOculta.Trim().Length > 0)
                { _Mtd_IniciarPreCarca(_Str_PlacaOculta); }
                else
                {
                    MessageBox.Show("Error. No se pudo completar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Tb_Tab.Deselecting -= new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
                    _Tb_Tab.SelectTab(0);
                    _Tb_Tab.Deselecting += new TabControlCancelEventHandler(_Tb_Tab_Deselecting);
                }
                _Pnl_Carga.Visible = false;
            }
        }

        private bool _Mtd_PreFacturaTieneFacturasDevueltasParaAnular(string cpfactura)
        {
            string _Str_SQL = "SELECT TFACTURAM.cpfactura, TFACTURAM.cfactura, TGUIADESPACHOD.c_estatus FROM TFACTURAM INNER JOIN TGUIADESPACHOD ON TFACTURAM.cgroupcomp = TGUIADESPACHOD.cgroupcomp AND TFACTURAM.ccompany = TGUIADESPACHOD.ccompany AND TFACTURAM.cfactura = TGUIADESPACHOD.cfactura WHERE (TFACTURAM.cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (TFACTURAM.cpfactura = " + cpfactura + ") AND (TGUIADESPACHOD.c_devanular = 1) AND (TGUIADESPACHOD.c_estatus = 'DEV') AND NOT EXISTS (SELECT cfactura FROM TFACTURANUL WHERE TGUIADESPACHOD.ccompany = ccompany AND TGUIADESPACHOD.cfactura = cfactura)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return true; else return false;
        }

        private string _Mtd_CantidadCajasTotalesPreFactura(string _Str_CodCompania, string _Str_CodPreFactura)
        {
            string _Str_SQL = "SELECT CONVERT(VARCHAR,cempaques)+'|'+CONVERT(VARCHAR,cunidades) AS EMPAQUESUNIDADES from VST_T3_PRODUCTOSPORPREFACTURA where ccompany ='" + _Str_CodCompania + "' and cpfactura=" + _Str_CodPreFactura;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return Convert.ToString(_Ds.Tables[0].Rows[0][0].ToString().Trim()); else return "0|0";
        }


        private int _Mtd_CantidadUnidadesTotalesPreFactura(string _Str_CodCompania, string _Str_CodPreFactura)
        {
            string _Str_SQL = "SELECT cunidades from VST_T3_PRODUCTOSPORPREFACTURA where ccompany ='" + _Str_CodCompania + "' and cpfactura=" + _Str_CodPreFactura;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()); else return 0;
        }

        private bool _Mtd_CantidadesEnPreFacturasHanCambiado()
        {
            // chequea si el numero de cajas o unidades de alguna de las prefacturas que se especifican en la precarga es incorrecto debido al fenomeno de "me anularon la factura mientras deje el sistema abierto con la precarga montada porqueme fui a comer"

            bool _Bol_Retornar = false;

            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                string _Str_CodCompania = _Dg_Row.Cells["ccompanyagre"].Value.ToString().Trim();
                string _Str_CodPreFactura = _Dg_Row.Cells["cprefacagre"].Value.ToString().Trim(); ;

                int _Int_CajasGrid = Convert.ToInt32(_Dg_Row.Cells["CajasP"].Value);
                int _Int_UnidadesGrid = Convert.ToInt32(_Dg_Row.Cells["UnidadesP"].Value);
                string _Str_ValorEmpUnd = _Mtd_CantidadCajasTotalesPreFactura(_Str_CodCompania, _Str_CodPreFactura);
                string[] _Str_EmpUnd=_Str_ValorEmpUnd.Split('|');
                if (Convert.ToInt32(_Str_EmpUnd[0]) != _Int_CajasGrid || Convert.ToInt32(_Str_EmpUnd[1]) != _Int_UnidadesGrid)
                {
                    _Dg_Row.DefaultCellStyle.BackColor = Color.Red;
                    _Bol_Retornar = true;
                }
            }
            return _Bol_Retornar;
        }
        private DataTable _Mtd_DetallePrecarga()
        {
            int _Int_Index = 0;
            int _Int_Contador = 0;
            string _Str_SQL;
            string _Str_WHERE = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds_Temporal = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPreFacturasAgre.Rows)
            {
                _Int_Index++;
                _Int_Contador++;
                _Str_WHERE += _Str_WHERE != "" ? " OR " : " AND (";
                _Str_WHERE += "(ccompany='" + Convert.ToString(_Dg_Row.Cells["ccompanyagre"].Value).Trim() + "'";
                _Str_WHERE += " AND cpfactura='" + Convert.ToString(_Dg_Row.Cells["cprefacagre"].Value).Trim() + "')";
                if (_Int_Contador == 5 || _Int_Index == _Dg_GridPreFacturasAgre.Rows.Count)
                {
                    _Str_SQL = "SELECT cproducto AS Producto,";
                    _Str_SQL += " cnamef AS Descripción,";
                    _Str_SQL += " cpempaquesprod AS Cajas,";
                    _Str_SQL += " cpunidadesprod AS Unidades,";
                    _Str_SQL += " Kilos,";
                    _Str_SQL += " ccodfabrica AS [Código alterno]";
                    _Str_SQL += " FROM VST_PRECARGA_EXCEL_V2";
                    _Str_SQL += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_SQL += _Str_WHERE + ") ORDER BY Descripción, Cajas DESC;";

                    _Ds_Temporal = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds.Tables.Count == 0)
                    {
                        DataTable oTabla = new DataTable();

                        oTabla.Columns.Add("Producto", typeof(string));
                        oTabla.Columns.Add("Descripción", typeof(string));
                        oTabla.Columns.Add("Cajas", typeof(string));
                        oTabla.Columns.Add("Unidades", typeof(string));
                        oTabla.Columns.Add("Kilos", typeof(string));
                        oTabla.Columns.Add("[Código alterno]", typeof(string));

                        _Ds.Tables.Add(oTabla);
                    }

                    foreach (DataRow _Fila in _Ds_Temporal.Tables[0].Rows)
                    {
                        _Ds.Tables[0].Rows.Add(new object[]
                            {
                                _Fila[0].ToString().Trim(), 
                                _Fila[1].ToString().Trim(), 
                                _Fila[2].ToString().Trim(), 
                                _Fila[3].ToString().Trim(), 
                                _Fila[4].ToString().Trim(), 
                                _Fila[5].ToString().Trim()
                            });
                    }
                    _Str_WHERE = "";
                    _Int_Contador = 0;
                }
            }
            return _Ds.Tables[0];
        }
        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPreFacturasAgre.Rows.Count > 0)
            {
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                        _MyExcel._Mtd_DatasetToExcel(_Mtd_DetallePrecarga(), _Sfd_1.FileName, "PRECARGA");
                        _MyExcel = null;
                        Cursor = Cursors.Default;
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                MessageBox.Show("No se han agregado pre-facturas", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Dg_GridPreFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // si el pedido tiene observaciones, escribe "@" en una columna especial
            if (e.ColumnIndex == 1)
            { 
                if (_Dg_GridPreFacturas.Rows[e.RowIndex].Cells["c_pedidotieneobs"].Value.ToString().Trim() == "SI")
                {
                    e.Value = "@"; // "\u044D"
                }
                else
                {
                    e.Value = "";
                }
            }
        }

        private void _Pnl_TipoCliente_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_TipoCliente.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }
        string _G_Str_TipoClienteSel = "";
        string _G_Str_TipoAlimentoSel = "";
        private void _Btn_AceptarTipoCliente_Click(object sender, EventArgs e)
        {
            if (_Cmb_TipoCliente.SelectedIndex > 0 & _Cmb_TipoPrecarga.SelectedIndex > 0)
            {
                _Lbl_TipoPrecarga.Text = "TIPO " + _Cmb_TipoPrecarga.Text.Trim() + " PARA " + _Cmb_TipoCliente.Text.Trim();
                _Bol_CancelTipoCliente = false;
                _G_Str_TipoClienteSel = _Cmb_TipoCliente.SelectedValue.ToString().Trim();
                _G_Str_TipoAlimentoSel = _Cmb_TipoPrecarga.SelectedValue.ToString().Trim();
                _Mtd_CargarTransportes();                
                _Pnl_TipoCliente.Visible = false;
                _Pnl_Carga.Visible = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el tipo de cliente y un tipo de precarga", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Btn_CencelarTipoCliente_Click(object sender, EventArgs e)
        {
            _Pnl_TipoCliente.Visible = false;
            _Bol_CancelTipoCliente = true;
            _Tb_Tab.SelectTab(0);
        }
        private bool _Mtd_RequiereGuiaSada(string _P_Str_Precarga)
        {
            var _Bol_RequiereGuiaSada = false;
            string _Str_Cadena = "SELECT DISTINCT TPREFACTURAM.ccompany " +
                                 "FROM TPRECARGAM INNER JOIN " +
                                 "TPRECARGADPF ON TPRECARGAM.cgroupcomp = TPRECARGADPF.cgroupcomp AND " +
                                 "TPRECARGAM.cprecarga = TPRECARGADPF.cprecarga INNER JOIN " +
                                 "TPREFACTURAM ON dbo.TPRECARGADPF.cpfactura = TPREFACTURAM.cpfactura "+
                                 "WHERE TPRECARGAM.cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Ds_Comp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Comp.Tables[0].Rows)
            {
                double _Dbl_Toneladas = 0;
                _Str_Cadena = "SELECT ISNULL(SUM(CONVERT(NUMERIC(18,3),CONVERT(NUMERIC(18,2),CONVERT(NUMERIC(18,2),(TPREFACTURAD.cempaques*(TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))+TPREFACTURAD.cunidades)*CONVERT(NUMERIC(18,2),cpesounid1))/1000000)),0) AS Toneladas " +
                      "FROM TPREFACTURAM INNER JOIN " +
                      "TPREFACTURAD ON TPREFACTURAM.ccompany = TPREFACTURAD.ccompany AND " +
                      "TPREFACTURAM.cpfactura = TPREFACTURAD.cpfactura INNER JOIN " +
                      "TPRECARGADPF ON TPREFACTURAM.cpfactura = TPRECARGADPF.cpfactura INNER JOIN " +
                      "TPRODUCTO ON TPRODUCTO.cproducto = TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSD ON TSICARUBROSD.cproducto=TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSM ON TSICARUBROSD.ccodigorubro=TSICARUBROSM.ccodigorubro AND " +
                      "TSICARUBROSD.cdelete=TSICARUBROSM.cdelete " +
                      "WHERE (TPRECARGADPF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGADPF.cprecarga='" + _P_Str_Precarga + "') AND (TPREFACTURAM.ccompany='" + _Row[0].ToString() + "') AND (TSICARUBROSM.cdelete=0)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Dbl_Toneladas = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
                if (_Dbl_Toneladas > 0)
                {
                    _Bol_RequiereGuiaSada = true;
                }
            }
            return _Bol_RequiereGuiaSada;
        }
    }
}