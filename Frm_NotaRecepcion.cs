using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_NotaRecepcion : Form
    {
        public Frm_NotaRecepcion()
        {
            InitializeComponent();
        }
        string _Str_cidnotrecepc = "";
        string _Str_cidrecepcion = "";
        string _Str_cnumdocu = "";
        string _Str_TiDo = "";
        public Frm_NotaRecepcion(string _P_Str_Proveedor, string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Fecha_Factura,bool _P_Bol_Boleano)
        {
            InitializeComponent();
            _Int_Sw = 1;
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            string _Str_TD = "";
            string _Str_TNR = "";
            string _Str_Cadena = "";
            int _Int_IDM = 0;
            _Str_Cadena = "Select cidnotrecepc,dbo.Fnc_Formatear(cmontosi) as cmontosi,dbo.Fnc_Formatear(cporcinvendible) as cporcinvendible,dbo.Fnc_Formatear(cmontoimp) as cmontoimp,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total,(Select top 1 cnumoc from TRECEPCIONRELDIF where TRECEPCIONRELDIF.cidrecepcion=TNOTARECEPC.cidrecepcion and TRECEPCIONRELDIF.cnfacturapro=TNOTARECEPC.cnumdocu and TRECEPCIONRELDIF.cgroupcomp=TNOTARECEPC.cgroupcomp) as orden from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrecepcion='" + _P_Str_Recepcion + "' and cnumdocu='" + _P_Str_Factura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_IDM = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                _Txt_NR.Text = _Int_IDM.ToString();
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0][1].ToString();
                _Txt_Invendible.Text = _Ds.Tables[0].Rows[0][2].ToString();
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0][3].ToString();
                _Txt_Total.Text = _Ds.Tables[0].Rows[0][4].ToString();
                _Txt_OC.Text = _Ds.Tables[0].Rows[0][5].ToString();
            }
            _Str_cidnotrecepc = _Int_IDM.ToString();
            _Str_cidrecepcion = _P_Str_Recepcion;
            _Str_cnumdocu = _P_Str_Factura;
            _Txt_Document.Text = _P_Str_Factura;
            _Txt_FechNR.Text = _Mtd_FechaNotaDeRecepcion(Frm_Padre._Str_GroupComp, Frm_Padre._Str_Comp, _Str_cidnotrecepc);
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
"FROM TDOCUMENT INNER JOIN " +
"TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentrp " +
"WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TiDo = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_TD = _Ds.Tables[0].Rows[0][0].ToString();
                _Txt_TipoDocument.Text = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_TDocument = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "Select ctiponotreceprp from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TNR = _Ds.Tables[0].Rows[0][0].ToString();
                if (_Str_TNR == "A")
                { _Txt_TNR.Text = "Devolución de Mercancía"; }
                else if (_Str_TNR == "B")
                { _Txt_TNR.Text = "Devolución de Mercancía mal estado"; }
                else if (_Str_TNR == "C")
                { _Txt_TNR.Text = "Recepción de Mercancía a Proveedores"; }
            }
            try
            {
                _Txt_Proveedor.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select c_nomb_abreviado from TPROVEEDOR where cproveedor='" + _P_Str_Proveedor + "' and cdelete='0'").Tables[0].Rows[0][0].ToString();
            }
            catch { }
            // si se empieza a guardar el monto exento en la tabla TRECEPCIONDFD, entonces se puede usar este sql
            //_Str_Cadena = "SELECT vst_mostrardettalledenotarecepcion.cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, vst_mostrardettalledenotarecepcion.cempaques AS Cajas, vst_mostrardettalledenotarecepcion.cunidades AS Unidades,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cmontosi) AS Monto,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cporcinvendible) as Invendible,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cmontoimp) as Impuesto,dbo.Fnc_Formatear((vst_mostrardettalledenotarecepcion.cmontosi-vst_mostrardettalledenotarecepcion.cporcinvendible)+vst_mostrardettalledenotarecepcion.cmontoimp) as Total, TRECEPCIONDFD.cbaseexcenta AS [Monto exento] FROM vst_mostrardettalledenotarecepcion LEFT OUTER JOIN TRECEPCIONDFD ON vst_mostrardettalledenotarecepcion.cgroupcomp = TRECEPCIONDFD.cgroupcomp AND vst_mostrardettalledenotarecepcion.cidrecepcion = TRECEPCIONDFD.cidrecepcion AND vst_mostrardettalledenotarecepcion.cnumdocu = TRECEPCIONDFD.cnfacturapro AND vst_mostrardettalledenotarecepcion.cproducto = TRECEPCIONDFD.cproducto  " +
            //  "WHERE (vst_mostrardettalledenotarecepcion.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (vst_mostrardettalledenotarecepcion.cproveedor = '" + _P_Str_Proveedor + "') AND (vst_mostrardettalledenotarecepcion.ccompany = '" + Frm_Padre._Str_Comp + "') AND " + "(vst_mostrardettalledenotarecepcion.cidnotrecepc = '" + _Txt_NR.Text + "') AND (vst_mostrardettalledenotarecepcion.cidrecepcion = '" + _P_Str_Recepcion + "') AND (vst_mostrardettalledenotarecepcion.cnumdocu='" + _P_Str_Factura + "')";
            _Str_Cadena = "SELECT cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, cempaques AS Cajas, cunidades AS Unidades,dbo.Fnc_Formatear(cmontosi) AS Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total, dbo.Fnc_Formatear(ccostobrutolote) AS [Costo bruto], dbo.Fnc_Formatear(cprecioventamax) AS PMV, dbo.Fnc_Formatear(cpreciolista) AS [Precio lista] from vst_mostrardettalledenotarecepcion " +
"WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cproveedor = '" + _P_Str_Proveedor + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND " +
"(cidnotrecepc = '" + _Txt_NR.Text + "') AND (cidrecepcion = '" + _P_Str_Recepcion + "') AND (cnumdocu='" + _P_Str_Factura + "')";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Tb_Tab.SelectedIndex = 1;
        }
        //---------------------------------------------------------------------------------
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        int _Int_Sw = 0;
        public Frm_NotaRecepcion(string _P_Str_Proveedor, string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Fecha_Factura, int _P_Int_Sw)
        {
            InitializeComponent();
            _Int_Sw = 2;
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            string _Str_TD = "";
            string _Str_TNR = "";
            string _Str_Cadena = "";
            int _Int_IDM = 0;
            _Str_Cadena = "Select cidnotrecepc,dbo.Fnc_Formatear(cmontosi) as cmontosi,dbo.Fnc_Formatear(cporcinvendible) as cporcinvendible,dbo.Fnc_Formatear(cmontoimp) as cmontoimp,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total,(Select top 1 cnumoc from TRECEPCIONRELDIF where TRECEPCIONRELDIF.cidrecepcion=TNOTARECEPC.cidrecepcion and TRECEPCIONRELDIF.cnfacturapro=TNOTARECEPC.cnumdocu and TRECEPCIONRELDIF.cgroupcomp=TNOTARECEPC.cgroupcomp) as orden from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrecepcion='" + _P_Str_Recepcion + "' and cnumdocu='" + _P_Str_Factura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_IDM = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                _Txt_NR.Text = _Int_IDM.ToString();
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0][1].ToString();
                _Txt_Invendible.Text = _Ds.Tables[0].Rows[0][2].ToString();
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0][3].ToString();
                _Txt_Total.Text = _Ds.Tables[0].Rows[0][4].ToString();
                _Txt_OC.Text = _Ds.Tables[0].Rows[0][5].ToString();
            }
            _Str_cidnotrecepc = _Int_IDM.ToString();
            _Str_cidrecepcion = _P_Str_Recepcion;
            _Str_cnumdocu = _P_Str_Factura;
            _Txt_Document.Text = _P_Str_Factura;
            _Txt_FechNR.Text = _Mtd_FechaNotaDeRecepcion(Frm_Padre._Str_GroupComp, Frm_Padre._Str_Comp, _Str_cidnotrecepc);
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
"FROM TDOCUMENT INNER JOIN " +
"TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentrp " +
"WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TiDo = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_TD = _Ds.Tables[0].Rows[0][0].ToString();
                _Txt_TipoDocument.Text = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_TDocument = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "Select ctiponotreceprp from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TNR = _Ds.Tables[0].Rows[0][0].ToString();
                if (_Str_TNR == "A")
                { _Txt_TNR.Text = "Devolución de Mercancía"; }
                else if (_Str_TNR == "B")
                { _Txt_TNR.Text = "Devolución de Mercancía mal estado"; }
                else if (_Str_TNR == "C")
                { _Txt_TNR.Text = "Recepción de Mercancía a Proveedores"; }
            }
            try
            {
                _Txt_Proveedor.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select c_nomb_abreviado from TPROVEEDOR where cproveedor='" + _P_Str_Proveedor + "' and cdelete='0'").Tables[0].Rows[0][0].ToString();
            }
            catch { }

            // si se empieza a guardar el monto exento en la tabla TRECEPCIONDFD, entonces se puede usar este sql
            //_Str_Cadena = "SELECT vst_mostrardettalledenotarecepcion.cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, vst_mostrardettalledenotarecepcion.cempaques AS Cajas, vst_mostrardettalledenotarecepcion.cunidades AS Unidades,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cmontosi) AS Monto,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cporcinvendible) as Invendible,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cmontoimp) as Impuesto,dbo.Fnc_Formatear((vst_mostrardettalledenotarecepcion.cmontosi-vst_mostrardettalledenotarecepcion.cporcinvendible)+vst_mostrardettalledenotarecepcion.cmontoimp) as Total, TRECEPCIONDFD.cbaseexcenta AS [Monto exento] FROM vst_mostrardettalledenotarecepcion LEFT OUTER JOIN TRECEPCIONDFD ON vst_mostrardettalledenotarecepcion.cgroupcomp = TRECEPCIONDFD.cgroupcomp AND vst_mostrardettalledenotarecepcion.cidrecepcion = TRECEPCIONDFD.cidrecepcion AND vst_mostrardettalledenotarecepcion.cnumdocu = TRECEPCIONDFD.cnfacturapro AND vst_mostrardettalledenotarecepcion.cproducto = TRECEPCIONDFD.cproducto  " +
            //  "WHERE (vst_mostrardettalledenotarecepcion.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (vst_mostrardettalledenotarecepcion.cproveedor = '" + _P_Str_Proveedor + "') AND (vst_mostrardettalledenotarecepcion.ccompany = '" + Frm_Padre._Str_Comp + "') AND " + "(vst_mostrardettalledenotarecepcion.cidnotrecepc = '" + _Txt_NR.Text + "') AND (vst_mostrardettalledenotarecepcion.cidrecepcion = '" + _P_Str_Recepcion + "') AND (vst_mostrardettalledenotarecepcion.cnumdocu='" + _P_Str_Factura + "')";
            _Str_Cadena = "SELECT cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, cempaques AS Cajas, cunidades AS Unidades,dbo.Fnc_Formatear(cmontosi) AS Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total, dbo.Fnc_Formatear(ccostobrutolote) AS [Costo bruto], dbo.Fnc_Formatear(cprecioventamax) AS PMV, dbo.Fnc_Formatear(cpreciolista) AS [Precio lista] from vst_mostrardettalledenotarecepcion " +
"WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cproveedor = '" + _P_Str_Proveedor + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND " +
"(cidnotrecepc = '" + _Txt_NR.Text + "') AND (cidrecepcion = '" + _P_Str_Recepcion + "') AND (cnumdocu='" + _P_Str_Factura + "')";
  
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Tb_Tab.SelectedIndex = 1;
        }
        string _Str_TDocument = "";
        string _Str_Proveedor = "";
        private void _Mtd_MostrarDetalle(string _P_Str_Proveedor, string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Fecha_Factura, string _P_Str_cidnotrecepc)
        {
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            string _Str_TD = "";
            string _Str_TNR = "";
            string _Str_Cadena = "";;
            int _Int_IDM = Convert.ToInt32(_P_Str_cidnotrecepc);
            _Str_cidnotrecepc = _Int_IDM.ToString();
            _Str_cidrecepcion = _P_Str_Recepcion;
            _Str_cnumdocu = _P_Str_Factura;
            _Txt_NR.Text = _Int_IDM.ToString();
            _Txt_Document.Text = _P_Str_Factura;
            _Txt_FechNR.Text = _Mtd_FechaNotaDeRecepcion(Frm_Padre._Str_GroupComp, Frm_Padre._Str_Comp, _Str_cidnotrecepc);
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
"FROM TDOCUMENT INNER JOIN " +
"TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentrp " +
"WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TiDo = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_TD = _Ds.Tables[0].Rows[0][0].ToString();
                _Txt_TipoDocument.Text = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_TDocument = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "Select ctiponotreceprp from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TNR = _Ds.Tables[0].Rows[0][0].ToString();
                if (_Str_TNR == "A")
                { _Txt_TNR.Text = "Devolución de Mercancía"; }
                else if (_Str_TNR == "B")
                { _Txt_TNR.Text = "Devolución de Mercancía mal estado"; }
                else if (_Str_TNR == "C")
                { _Txt_TNR.Text = "Recepción de Mercancía a Proveedores"; }
            }
            try
            {
                _Txt_Proveedor.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select c_nomb_abreviado from TPROVEEDOR where cproveedor='" + _P_Str_Proveedor + "' and cdelete='0'").Tables[0].Rows[0][0].ToString();
            }
            catch { }
            // si se empieza a guardar el monto exento en la tabla TRECEPCIONDFD, entonces se puede usar este sql
            //_Str_Cadena = "SELECT vst_mostrardettalledenotarecepcion.cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, vst_mostrardettalledenotarecepcion.cempaques AS Cajas, vst_mostrardettalledenotarecepcion.cunidades AS Unidades,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cmontosi) AS Monto,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cporcinvendible) as Invendible,dbo.Fnc_Formatear(vst_mostrardettalledenotarecepcion.cmontoimp) as Impuesto,dbo.Fnc_Formatear((vst_mostrardettalledenotarecepcion.cmontosi-vst_mostrardettalledenotarecepcion.cporcinvendible)+vst_mostrardettalledenotarecepcion.cmontoimp) as Total, TRECEPCIONDFD.cbaseexcenta AS [Monto exento] FROM vst_mostrardettalledenotarecepcion LEFT OUTER JOIN TRECEPCIONDFD ON vst_mostrardettalledenotarecepcion.cgroupcomp = TRECEPCIONDFD.cgroupcomp AND vst_mostrardettalledenotarecepcion.cidrecepcion = TRECEPCIONDFD.cidrecepcion AND vst_mostrardettalledenotarecepcion.cnumdocu = TRECEPCIONDFD.cnfacturapro AND vst_mostrardettalledenotarecepcion.cproducto = TRECEPCIONDFD.cproducto  " +
            //  "WHERE (vst_mostrardettalledenotarecepcion.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (vst_mostrardettalledenotarecepcion.cproveedor = '" + _P_Str_Proveedor + "') AND (vst_mostrardettalledenotarecepcion.ccompany = '" + Frm_Padre._Str_Comp + "') AND " + "(vst_mostrardettalledenotarecepcion.cidnotrecepc = '" + _Txt_NR.Text + "') AND (vst_mostrardettalledenotarecepcion.cidrecepcion = '" + _P_Str_Recepcion + "') AND (vst_mostrardettalledenotarecepcion.cnumdocu='" + _P_Str_Factura + "')";
            _Str_Cadena = "SELECT cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, cempaques AS Cajas, cunidades AS Unidades,dbo.Fnc_Formatear(cmontosi) AS Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total, dbo.Fnc_Formatear(ccostobrutolote) AS [Costo bruto], dbo.Fnc_Formatear(cprecioventamax) AS PMV, dbo.Fnc_Formatear(cpreciolista) AS [Precio lista] from vst_mostrardettalledenotarecepcion " +
"WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cproveedor = '" + _P_Str_Proveedor + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND " +
"(cidnotrecepc = '" + _Txt_NR.Text + "') AND (cidrecepcion = '" + _P_Str_Recepcion + "') AND (cnumdocu='" + _P_Str_Factura + "')";
  
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
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
            _Txt_Exento.Text = _Mtd_TotalExento(_P_Str_Proveedor, _P_Str_Recepcion, _P_Str_Factura);
            _Tb_Tab.SelectedIndex = 1;
        }
        private void Frm_NotaRecepcion_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void Frm_NotaRecepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private int _Mtd_Consecutivo_TNOTARECEPC()
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidnotrecepc FROM TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidnotrecepc  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
         private int _Mtd_Consecutivo_TNOTARECEPD(int _P_Int_IDM)
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ciddnotrecepc FROM TNOTARECEPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='"+_P_Int_IDM.ToString()+"' ORDER BY ciddnotrecepc  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
        private void _Mtd_Actual_Imprimir()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[4];
            _Tsm_Menu[0] = new ToolStripMenuItem("N.R.");
            _Tsm_Menu[1] = new ToolStripMenuItem("T.Documento");
            _Tsm_Menu[2] = new ToolStripMenuItem("Documento");
            _Tsm_Menu[3] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[4];
            _Str_Campos[0] = "cidnotrecepc";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "cnumdocu";
            _Str_Campos[3] = "c_nomb_abreviado";
            string _Str_Cadena = "Select cidnotrecepc as [N.R.],cname as [T.Documento],cnumdocu as Documento,c_nomb_abreviado as Proveedor,cproveedor,cidrecepcion,cnumdocu,cfechadocu,dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total,(Select top 1 cnumoc from TRECEPCIONRELDIF where TRECEPCIONRELDIF.cidrecepcion=vst_consultanotarecepcionmaestra.cidrecepcion and TRECEPCIONRELDIF.cnfacturapro=vst_consultanotarecepcionmaestra.cnumdocu and TRECEPCIONRELDIF.cgroupcomp=vst_consultanotarecepcionmaestra.cgroupcomp) as orden,totalcajas AS Cajas from vst_consultanotarecepcionmaestra where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Recepción", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Str_Cadena = "Select cidnotrecepc as [N.R.],cname as [T.Documento],cnumdocu as Documento,c_nomb_abreviado as Proveedor,cproveedor,cidrecepcion,cnumdocu,cfechadocu,dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total,(Select top 1 cnumoc from TRECEPCIONRELDIF where TRECEPCIONRELDIF.cidrecepcion=vst_consultanotarecepcionmaestra.cidrecepcion and TRECEPCIONRELDIF.cnfacturapro=vst_consultanotarecepcionmaestra.cnumdocu and TRECEPCIONRELDIF.cgroupcomp=vst_consultanotarecepcionmaestra.cgroupcomp) as orden,totalcajas AS Cajas from vst_consultanotarecepcionmaestra where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            foreach (DataGridViewColumn _Gg_Col in _Dg_Grid.Columns)
            {
                if (_Gg_Col.Index > 3 & _Gg_Col.Index < 8)
                {
                    _Gg_Col.Visible = false;
                }
            }
            _Dg_Grid.Columns[12].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Cajas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_Actual_Total()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[4];
            _Tsm_Menu[0] = new ToolStripMenuItem("N.R.");
            _Tsm_Menu[1] = new ToolStripMenuItem("T.Documento");
            _Tsm_Menu[2] = new ToolStripMenuItem("Documento");
            _Tsm_Menu[3] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[4];
            _Str_Campos[0] = "cidnotrecepc";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "cnumdocu";
            _Str_Campos[3] = "c_nomb_abreviado";
            string _Str_Cadena = "Select cidnotrecepc as [N.R.],cname as [T.Documento],cnumdocu as Documento,c_nomb_abreviado as Proveedor,cproveedor,cidrecepcion,cnumdocu,cfechadocu,dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total,(Select top 1 cnumoc from TRECEPCIONRELDIF where TRECEPCIONRELDIF.cidrecepcion=vst_consultanotarecepcionmaestra.cidrecepcion and TRECEPCIONRELDIF.cnfacturapro=vst_consultanotarecepcionmaestra.cnumdocu and TRECEPCIONRELDIF.cgroupcomp=vst_consultanotarecepcionmaestra.cgroupcomp) as orden,totalcajas AS Cajas from vst_consultanotarecepcionmaestra where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Recepción", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Str_Cadena = "Select cidnotrecepc as [N.R.],cname as [T.Documento],cnumdocu as Documento,c_nomb_abreviado as Proveedor,cproveedor,cidrecepcion,cnumdocu,cfechadocu,dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi-cporcinvendible)+cmontoimp) as Total,(Select top 1 cnumoc from TRECEPCIONRELDIF where TRECEPCIONRELDIF.cidrecepcion=vst_consultanotarecepcionmaestra.cidrecepcion and TRECEPCIONRELDIF.cnfacturapro=vst_consultanotarecepcionmaestra.cnumdocu and TRECEPCIONRELDIF.cgroupcomp=vst_consultanotarecepcionmaestra.cgroupcomp) as orden,totalcajas AS Cajas from vst_consultanotarecepcionmaestra where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_Cadena += " ORDER BY cidnotrecepc DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            foreach (DataGridViewColumn _Gg_Col in _Dg_Grid.Columns)
            {
                if (_Gg_Col.Index > 3 & _Gg_Col.Index < 8)
                {
                    _Gg_Col.Visible = false;
                }
            }
            _Dg_Grid.Columns[12].Visible = false;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Cajas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void Frm_NotaRecepcion_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            if (_Int_Sw == 0)
            {
                _Mtd_Actual_Total();               
                _Bt_Imprimir.Enabled = false;
            }
            else if (_Int_Sw == 1)
            {
                _Mtd_Actual_Imprimir();
                _Bt_Imprimir.Enabled = true;
            }
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        //cnumoc,cproveedor,cidrecepcion,cnumdocu,cfechadocu
        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (_Dg_Grid.Rows[0].Cells[0].Value != null)
                {
                    _Txt_Monto.Text = "";
                    _Txt_Invendible.Text = "";
                    _Txt_Impuesto.Text = "";
                    _Txt_Total.Text = "";
                    _Txt_OC.Text = "";
                    _Txt_Monto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(8,_Dg_Grid.CurrentCell.RowIndex);
                    _Txt_Invendible.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(9,_Dg_Grid.CurrentCell.RowIndex);
                    _Txt_Impuesto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(10,_Dg_Grid.CurrentCell.RowIndex);
                    _Txt_Total.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(11, _Dg_Grid.CurrentCell.RowIndex);
                    _Txt_OC.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(12, _Dg_Grid.CurrentCell.RowIndex);
                    _Mtd_MostrarDetalle(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, _Dg_Grid.CurrentCell.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, _Dg_Grid.CurrentCell.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, _Dg_Grid.CurrentCell.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(7, _Dg_Grid.CurrentCell.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex));
                    _Tb_Tab.SelectedIndex = 1;
                    _Bt_Imprimir.Enabled = true;
                }
            }
            catch { }
            Cursor = Cursors.Default;
        }
        private void _Mtd_Imprimir2()
        {
            try
            {
                string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
                string _Str_Cadena = "select cimpreso,cidcomprob from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        PrintDialog _Print = new PrintDialog();
                    Print:
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave.Text = "";
                            //----------------------------------------------
                            ////Cursor = Cursors.WaitCursor;
                            ////REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportenotaderecepcion" }, "", "T3.Report.rnoraderecepcion", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "' and cdelete='0' and cnumdocu='" + _Str_cnumdocu + "'", _Print, true);
                            ////Cursor = Cursors.Default;
                            //----------------------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Str_Cadena = "SELECT '" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotrecepc) AS cidnotrecepc, cname, cnumdocu, c_nomb_comer, cgroupcomp, cidrecepcion, cproveedor, ctiponotrecep, ctipodocument, cdelete, ccompany, cfechadocu, cproducto, cfechanotrecep, cempaques, simbolo, cmontosi, cmontoimp, cporcinvendible, ccontenidome, cnamef, ccontenidoma1, produc_descrip, produc_descrip_2, cunidades,ccostobrutolote,cprecioventamax,cpreciolista FROM vst_reportenotaderecepcion WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "' and cdelete='0' and cnumdocu='" + _Str_cnumdocu + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            Report.rnoraderecepcion _My_Reporte = new T3.Report.rnoraderecepcion();
                            _My_Reporte.SetDataSource(_Ds.Tables[0]);
                            Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            tex1 = _sec.ReportObjects["rif"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            tex1 = _sec.ReportObjects["Direccion"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(caddress) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            tex1 = _sec.ReportObjects["Telefonos"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(ltrim(cphone1))+' / '+rtrim(ltrim(cphone2)) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            tex1 = _sec.ReportObjects["Email"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cemail) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            //---Configuración de impresión.
                            var _PageSettings = new System.Drawing.Printing.PageSettings();
                            _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                            _PageSettings.Landscape = false;
                            var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                            _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                            //---Configuración de impresión.
                            Cursor = Cursors.Default;
                            //----------------------------------------------
                            if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTARECEPC", "cimpreso='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "'");
                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TFACTPPAGARM", "cfacturaactivo='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Str_Proveedor + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and ctipodocument='" + _Str_TiDo + "' and cnumdocu='" + _Txt_Document.Text.Trim() + "'");
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                this.Close();
                            }
                            else
                            {
                                goto Print;
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
                        MessageBox.Show("La NR ya fue impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                    }
                }
            }
            catch (Exception _Ex) 
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }
        private void _Mtd_ImprimirNR()
        {
            try
            {
                string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
                string _Str_Cadena = "select cimpreso,cidcomprob from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    PrintDialog _Print = new PrintDialog();
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        //----------------------------------------------
                        ////Cursor = Cursors.WaitCursor;
                        ////REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportenotaderecepcion" }, "", "T3.Report.rnoraderecepcion", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "' and cdelete='0' and cnumdocu='" + _Str_cnumdocu + "'", _Print, true);
                        ////Cursor = Cursors.Default;
                        //----------------------------------------------
                        Cursor = Cursors.WaitCursor;
                        _Str_Cadena = "SELECT '" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotrecepc) AS cidnotrecepc, cname, cnumdocu, c_nomb_comer, cgroupcomp, cidrecepcion, cproveedor, ctiponotrecep, ctipodocument, cdelete, ccompany, cfechadocu, cproducto, cfechanotrecep, cempaques, simbolo, cmontosi, cmontoimp, cporcinvendible, ccontenidome, cnamef, ccontenidoma1, produc_descrip, produc_descrip_2, cunidades,ccostobrutolote,cprecioventamax,cpreciolista FROM vst_reportenotaderecepcion WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "' and cdelete='0' and cnumdocu='" + _Str_cnumdocu + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        Report.rnoraderecepcion _My_Reporte = new T3.Report.rnoraderecepcion();
                        _My_Reporte.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        tex1 = _sec.ReportObjects["rif"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        tex1 = _sec.ReportObjects["Direccion"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(caddress) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        tex1 = _sec.ReportObjects["Telefonos"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(ltrim(cphone1))+' / '+rtrim(ltrim(cphone2)) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        tex1 = _sec.ReportObjects["Email"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cemail) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        //---Configuración de impresión.
                        var _PageSettings = new System.Drawing.Printing.PageSettings();
                        _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                        _PageSettings.Landscape = false;
                        var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                        _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                        //---Configuración de impresión.
                        Cursor = Cursors.Default;
                        //----------------------------------------------

                    }
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }
        private void _Mtd_Generar()
        {
            try
            {
                double _Dbl_MontoInvend = 0;
                string _Str_Cadena = "select cidcomprob from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Str_cidnotrecepc + "' and cidrecepcion='" + _Str_cidrecepcion + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        PrintDialog _Print = new PrintDialog();
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave.Text = "";
                            Cursor = Cursors.WaitCursor;
                            //____________________________________________________________
                            string _Str_Cadena3 = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "' and cdelete='0'";
                            DataSet _Ds8 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena3);
                            CLASES._Cls_Varios_Metodos _Cls_Procesos = new T3.CLASES._Cls_Varios_Metodos(true);
                            int _Int_ID_Comprobante = new int();
                            if (_Ds8.Tables[0].Rows.Count > 0)
                            {
                                if (_Txt_Invendible.Text.Trim().Length > 0)
                                {
                                    _Dbl_MontoInvend = Convert.ToDouble(_Txt_Invendible.Text);
                                }
                                if (_Dbl_MontoInvend == 0)
                                {
                                    _Int_ID_Comprobante = _Cls_Procesos._Mtd_Proceso_P_COMPRA(_Txt_NR.Text.Trim(), _Str_cidrecepcion, _Str_Proveedor, _Txt_Document.Text.Trim());
                                }
                                else
                                {
                                    _Int_ID_Comprobante = _Cls_Procesos._Mtd_Proceso_P_COMPRA_INVEND(_Txt_NR.Text.Trim(), _Str_cidrecepcion, _Dbl_MontoInvend, _Str_Proveedor, _Txt_Document.Text.Trim());
                                }
                            }
                            //____________________________________________________________
                        Print2:
                                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_ID_Comprobante.ToString() + "'", _Print, true);
                                _Frm.MdiParent = this.MdiParent;
                                _Frm.Show();
                                Cursor = Cursors.Default;
                                if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_ID_Comprobante.ToString() + "'");
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTARECEPC", "cidcomprob='" + _Int_ID_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Txt_NR.Text.Trim() + "' and cidrecepcion='" + _Str_cidrecepcion + "'");
                                    this.Close();
                                }
                                else
                                {
                                    _Frm.Close();
                                    goto Print2;
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
                        MessageBox.Show("El comprobante ya fue generado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                    }
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default; 
            }
        }
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            string _Str_SQL = "select cidnotrecepc from TNOTARECEPC where cimpreso='1' and cidnotrecepc='" + _Txt_NR.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0].Rows.Count > 0)
            {
                _Mtd_ImprimirNR();
            }
            else
            {
                string _Str_Cadena1 = "Esta seguro de imprimir la NR# " + _Txt_NR.Text.Trim();
                string _Str_Cadena2 = "Faltan datos para la impresión";
                _Lbl_Texto.Text = "¿Esta seguro de imprimir la NR?";
                if (_Dg_Detalle.Rows.Count > 0)
                {
                    if (MessageBox.Show(_Str_Cadena1, "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _Pnl_Clave.Visible = true;
                        _Pnl_Clave.BringToFront();
                        _Txt_Clave.Focus();


                    }
                }
                else
                {
                    MessageBox.Show(_Str_Cadena2, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Txt_Clave.Text = "";
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Grb_Grupo.Enabled = true;
            _Dg_Detalle.Enabled = true;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
            System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (Ds22.Tables[0].Rows.Count > 0)
            {
                if (_Int_Sw == 1)
                { _Mtd_Imprimir2(); }
                else if (_Int_Sw == 2)
                { _Mtd_Generar(); }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            string _Str_Cadena1 = "Esta seguro de generar el comprobante de la NR# " + _Txt_NR.Text.Trim();
            string _Str_Cadena2 = "Faltan datos para la generación";
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
                MessageBox.Show(_Str_Cadena2, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string _Mtd_TotalExento(string _P_Str_Proveedor, string _P_Str_Recepcion, string _P_Str_Factura)
        {
            // Frm_Padre._Str_GroupComp
            DataSet _Ds;

            string _Str_Cadena = "SELECT dbo.Fnc_Formatear(cbaseexcenta) as cbaseexcenta FROM TRECEPCIONDFM WHERE (cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (cidrecepcion = " + _P_Str_Recepcion + ") AND (cnfacturapro = '" + _P_Str_Factura + "') AND (cproveedor = '" + _P_Str_Proveedor + "')";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            else
                return "";
        }

        private string _Mtd_FechaNotaDeRecepcion(string _Str_CodigoGrupoCompania, string _Str_CodigoCompania,string _Str_CodigoNR)
        {
            DataSet _Ds;

            string _Str_Cadena = "SELECT cfechanotrecep FROM TNOTARECEPC WHERE (ccompany = '" + _Str_CodigoCompania + "') AND (cgroupcomp = " + _Str_CodigoGrupoCompania +") AND (cidnotrecepc = " + _Str_CodigoNR + ") AND (cdelete = 0)";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            else
                return "";
        }
          
       

    }
}