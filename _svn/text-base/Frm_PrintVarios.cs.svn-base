using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_PrintVarios : Form
    {
        public Frm_PrintVarios()
        {
            InitializeComponent();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cb_TpoDoc.SelectedIndex > -1 & _Txt_IdDoc.Text.Trim().Length>0)
            {
                this.Cursor = Cursors.WaitCursor;
                string _Str_Sql = "";
                DataSet _Ds;
                switch (_Cb_TpoDoc.SelectedIndex)
                {//COMPROBANTES CONTABLES
                    case 0:
                        _Str_Sql = "SELECT * FROM vst_reportecomprobante WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_IdDoc.Text + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            Report.rcomprobante _My_Reporte = new T3.Report.rcomprobante();
                            _My_Reporte.SetDataSource(_Ds.Tables[0]);
                            Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
                            tex2.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex3 = _sec.ReportObjects["Direccion"] as TextObject;
                            tex3.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(caddressl) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex4 = _sec.ReportObjects["Telefonos"] as TextObject;
                            tex4.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cphone1) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex5 = _sec.ReportObjects["Email"] as TextObject;
                            tex5.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cemail) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            this._Rpv_Main.ReportSource = _My_Reporte;
                            _Rpv_Main.RefreshReport();
                        }
                        else
                        {
                            this._Rpv_Main.ReportSource = null;
                            MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case 1://GUIA DE DESPACHO
                        _Str_Sql = "SELECT * FROM VST_REPORTEGUIDESPACHO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Txt_IdDoc.Text + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            Report.rGuiaDespacho _My_Reporte = new T3.Report.rGuiaDespacho();
                            _My_Reporte.SetDataSource(_Ds.Tables[0]);
                            //----------------------------
                            string _Str_Cadena = "Select cprecarga from tguiadespachom where cguiadesp='" + _Txt_IdDoc.Text + "'";
                            DataSet _Ds_Guia = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_Guia.Tables[0].Rows.Count > 0)
                            {
                                if (_Mtd_RequiereGuiaSada(_Ds_Guia.Tables[0].Rows[0][0].ToString()))
                                {
                                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section3"];
                                    TextObject _Txt_RequiereGuiaSada = _sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                                    _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
                                }
                            }
                            //----------------------------
                            this._Rpv_Main.ReportSource = _My_Reporte;
                            _Rpv_Main.RefreshReport();
                        }
                        else
                        {
                            this._Rpv_Main.ReportSource = null;
                            MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case 2://NOTA DE RECEPCION
                        _Str_Sql = "SELECT * FROM vst_reportenotaderecepcion WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidnotrecepc='" + _Txt_IdDoc.Text + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            Report.rnoraderecepcion _My_Reporte = new T3.Report.rnoraderecepcion();
                            _My_Reporte.SetDataSource(_Ds.Tables[0]);
                            Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
                            tex2.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex3 = _sec.ReportObjects["Direccion"] as TextObject;
                            tex3.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(caddressl) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex4 = _sec.ReportObjects["Telefonos"] as TextObject;
                            tex4.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cphone1) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex5 = _sec.ReportObjects["Email"] as TextObject;
                            tex5.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cemail) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex6 = _sec.ReportObjects["Text8"] as TextObject;
                            tex6.Text = "Recepción de Mercancía a Proveedores";
                            //
                            this._Rpv_Main.ReportSource = _My_Reporte;
                            _Rpv_Main.RefreshReport();
                        }
                        else
                        {
                            this._Rpv_Main.ReportSource = null;
                            MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case 3://Relación de facturas emitidas
                        _Str_Sql = "SELECT * FROM VST_REPORTE_LISTADOFACTURAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_IdDoc.Text + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            Report.rFacturasEmitidas _My_Reporte = new T3.Report.rFacturasEmitidas();
                            _My_Reporte.SetDataSource(_Ds.Tables[0]);
                            Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
                            tex2.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            //TextObject tex3 = _sec.ReportObjects["Direccion"] as TextObject;
                            //tex3.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(caddressl) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            //TextObject tex4 = _sec.ReportObjects["Telefonos"] as TextObject;
                            //tex4.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cphone1) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            //TextObject tex5 = _sec.ReportObjects["Email"] as TextObject;
                            //tex5.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cemail) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            //
                            this._Rpv_Main.ReportSource = _My_Reporte;
                            _Rpv_Main.RefreshReport();
                        }
                        else
                        {
                            this._Rpv_Main.ReportSource = null;
                            MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case 4:
                        _Str_Sql = "SELECT * FROM VST_PRECARGALISTADO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_IdDoc.Text + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            Report.rPreCargaListado _My_Reporte = new T3.Report.rPreCargaListado();
                            _My_Reporte.SetDataSource(_Ds.Tables[0]);
                            Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
                            tex2.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                            //----------------------------
                            if (_Mtd_RequiereGuiaSada(_Txt_IdDoc.Text))
                            {
                                _sec = _My_Reporte.ReportDefinition.Sections["Section3"];
                                TextObject _Txt_RequiereGuiaSada = _sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                                _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
                            }
                            //----------------------------
                            this._Rpv_Main.ReportSource = _My_Reporte;
                            _Rpv_Main.RefreshReport();
                        }
                        else
                        {
                            this._Rpv_Main.ReportSource = null;
                            MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case 5:
                        DataTable _Dt_TableTemp = _Mtd_ImprimirNR(_Txt_IdDoc.Text.Trim());
                        if (_Dt_TableTemp.Rows.Count > 0)
                        {
                            Report.rNotaRecep_Devol _My_Reporte = new T3.Report.rNotaRecep_Devol();
                            _My_Reporte.SetDataSource(_Dt_TableTemp);
                            try
                            {
                                _My_Reporte.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                                _My_Reporte.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            }
                            catch { }
                            this._Rpv_Main.ReportSource = _My_Reporte;
                            _Rpv_Main.RefreshReport();
                        }
                        else
                        { MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        break;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                if (_Cb_TpoDoc.SelectedIndex == -1) { _Er_Error.SetError(_Cb_TpoDoc, "Información requerida!!!"); }
                if (_Txt_IdDoc.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_IdDoc, "Información requerida!!!"); }
            }
        }
        private DataTable _Mtd_ImprimirNR(string _P_Str_NR)
        {
            DataSet _Ds;
            string _Str_Cadena = "";
            DataTable _Dt_Tabla = new DataTable("Temporal");
            DataColumn _Dt_Colum = new DataColumn();
            _Dt_Colum = new DataColumn("cgroupcomp");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("ccompany");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cidnotrecepc");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("ctiponotrecep");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cfechanotrecep");
            _Dt_Colum.DataType = typeof(DateTime);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("ctipodocument");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cnumdocu");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cfechadocu");
            _Dt_Colum.DataType = typeof(DateTime);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cmontosi");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cmontoimp");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cporcreconoce");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cimpreso");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cporcinvendible");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cproveedor");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cidcomprob");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("ciddnotrecepc");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cproducto");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cempaques");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cunidades");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cmontosi_det");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cmontoimp_det");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("ccliente");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("c_nomb_comer");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cnamefc");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cidmotivo");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("ctipodocument_name");
            _Dt_Colum.DataType = typeof(string);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("total_det");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cprecioventamax");
            _Dt_Colum.DataType = typeof(double);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Dt_Colum = new DataColumn("cnumlote");
            _Dt_Colum.DataType = typeof(int);
            _Dt_Tabla.Columns.Add(_Dt_Colum);
            _Str_Cadena = "SELECT cgroupcomp,ccompany,cidnotrecepc,ctiponotrecep,cfechanotrecep,ctipodocument,cnumdocu,cfechadocu,cmontosi,cmontoimp,cporcreconoce,cimpreso,cporcinvendible,cproveedor,cidcomprob,ciddnotrecepc,cproducto,cempaques,cunidades,cmontosi_det,cmontoimp_det,ccliente,c_nomb_comer,cnamefc,cidmotivo,ctipodocument_name,total_det, cidproductod, cprecioventamax, cnumlote FROM VST_RPT_NOTARECEP_DEVOL where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc ='" + _P_Str_NR + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
            {
                _Dt_Tabla.Rows.Add((new object[] { _Dtw_Item["cgroupcomp"].ToString().TrimEnd(), _Dtw_Item["ccompany"].ToString().TrimEnd(),
                    _Dtw_Item["cidnotrecepc"].ToString().TrimEnd(), _Dtw_Item["ctiponotrecep"].ToString().TrimEnd(), _Dtw_Item["cfechanotrecep"].ToString().TrimEnd(),
                    _Dtw_Item["ctipodocument"].ToString().TrimEnd(), _Dtw_Item["cnumdocu"], _Dtw_Item["cfechadocu"],
                    _Dtw_Item["cmontosi"].ToString().TrimEnd(), _Dtw_Item["cmontoimp"].ToString().TrimEnd(), _Dtw_Item["cporcreconoce"].ToString().TrimEnd(),
                    _Dtw_Item["cimpreso"].ToString().TrimEnd(), _Dtw_Item["cporcinvendible"].ToString().TrimEnd(), _Dtw_Item["cproveedor"].ToString().TrimEnd(),
                    _Dtw_Item["cidcomprob"].ToString().TrimEnd(), _Dtw_Item["ciddnotrecepc"].ToString().TrimEnd(), _Dtw_Item["cproducto"].ToString().TrimEnd(),
                    _Dtw_Item["cempaques"].ToString().TrimEnd(), _Dtw_Item["cunidades"].ToString().TrimEnd(), _Dtw_Item["cmontosi_det"].ToString().TrimEnd(),
                    _Dtw_Item["cmontoimp_det"].ToString().TrimEnd(), _Dtw_Item["ccliente"].ToString().TrimEnd(), _Dtw_Item["c_nomb_comer"].ToString().TrimEnd(),
                    _Dtw_Item["cnamefc"].ToString().TrimEnd(), _Dtw_Item["cidmotivo"].ToString().TrimEnd(), _Dtw_Item["ctipodocument_name"].ToString().TrimEnd(),
                    _Dtw_Item["total_det"].ToString().TrimEnd(), _Dtw_Item["cprecioventamax"].ToString().TrimEnd(), _Dtw_Item["cnumlote"].ToString().TrimEnd() }));
            }
            return _Dt_Tabla;
        }
        private void Frm_PrintVarios_Load(object sender, EventArgs e)
        {

        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Txt_IdDoc_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_IdDoc.Text))
            {
                _Txt_IdDoc.Text = "";
            }
        }

        private void _Txt_IdDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }
        private bool _Mtd_RequiereGuiaSada(string _P_Str_Precarga)
        {
            var _Bol_RequiereGuiaSada = false;
            string _Str_Cadena = "SELECT DISTINCT TPREFACTURAM.ccompany " +
                        "FROM TPRECARGAM INNER JOIN " +
                        "TPRECARGADPF ON TPRECARGAM.cgroupcomp = TPRECARGADPF.cgroupcomp AND " +
                        "TPRECARGAM.cprecarga = TPRECARGADPF.cprecarga INNER JOIN " +
                        "TPREFACTURAM ON dbo.TPRECARGADPF.cpfactura = TPREFACTURAM.cpfactura " +
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