using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ReImpresionFacturasPruebas : Form
    {
        Clases._Cls_RutinasImpresion _rutinasImpresion = new Clases._Cls_RutinasImpresion();
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ReImpresionFacturasPruebas()
        {
            InitializeComponent();
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Actualizar(string _P_Str_Desde, string _P_Str_Hasta, int _P_Int_Seleccion,string _P_Str_Where)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT TDOCUMENT.cname as Tipo, TFACTURAM.cfactura as Documento, CONVERT(varchar, TFACTURAM.cfactura) + ' - ' + TCLIENTE.c_nomb_comer AS Descripcion,'" + _P_Int_Seleccion + "' as Imprimir " +
            "FROM TCONFIGCXC INNER JOIN " +
            "TFACTURAM ON TCONFIGCXC.ccompany = TFACTURAM.ccompany INNER JOIN " +
            "TDOCUMENT ON TCONFIGCXC.ctipdocfact = TDOCUMENT.ctdocument INNER JOIN " +
            "TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente " +
            "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTURAM.c_impresa = '1') AND (TFACTURAM.cfactura BETWEEN '" + _P_Str_Desde + "' AND '" + _P_Str_Hasta + "')" + _P_Str_Where;// AND (TFACTURAM.c_numerocontrol='0')";
            _Str_Cadena += " ORDER BY Documento";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private bool _Mtd_Seleccionar()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1")
                    { Cursor = Cursors.Default; return true; }
                }
            }
            Cursor = Cursors.Default;
            return false;
        }
        private void _Mtd_ImprimirFacturas()
        {
            try
            {
                bool _Bool_ClickOk = false;
                string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
                PrintDialog _Print = new PrintDialog();
                string _Str_Sql = "";
                string[] _P_Str_Facturas_ = new string[0];
                DataSet _Ds_DataSet = new DataSet();
                DataTable _Dta_Tabla = new DataTable("Relacion");
                DataColumn _Dta_Columna;

                _Bool_ClickOk = false;
                if (_rutinasImpresion._Mtd_EstaHabilitadoConfiguracionImpresion())
                {
                    PrinterSettings _ObjetoImpresion = null;
                    Clases._Cls_RutinasImpresion._G_TiposDocumento _Tipo = Clases._Cls_RutinasImpresion._G_TiposDocumento.Factura;
                    //Cargo el Objeto que voy a setear enl dialogos segun compañia
                    _ObjetoImpresion = _rutinasImpresion._Mtd_ObjetoImpresion(_Tipo, Frm_Padre._Str_Comp);
                    _Print.PrinterSettings = _ObjetoImpresion;
                    _Bool_ClickOk = true;
                }
                else
                {
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        _Bool_ClickOk = true;
                    }
                }

                Cursor = Cursors.WaitCursor;
                if (_Bool_ClickOk)
                {
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                    {
                        if (Convert.ToString(_Dg_Row.Cells["Imprimir"].Value).Trim() == "1")
                        {
                            //---------------------------------------------------------
                            if (_LstBox_DocPrint.Items.Count > 0)
                            {
                                if (_LstBox_DocPrint.FindStringExact(Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString())) != -1)
                                {
                                    _P_Str_Facturas_ = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_P_Str_Facturas_, _P_Str_Facturas_.Length + 1);
                                    _P_Str_Facturas_[_P_Str_Facturas_.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                                }
                            }
                            else
                            {
                                _P_Str_Facturas_ = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_P_Str_Facturas_, _P_Str_Facturas_.Length + 1);
                                _P_Str_Facturas_[_P_Str_Facturas_.Length - 1] = Convert.ToString(_Dg_Row.Cells["Documento"].Value.ToString());
                            }
                            //---------------------------------------------------------
                        }
                    }
                    //-------------------------
                    _LstBox_DocPrint.Items.Clear();
                    //-------------------------
                    Cursor = Cursors.WaitCursor;
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "ccompany";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cfactura";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "ccliente";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_rif";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_nomb_comer";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cproducto";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cempaques";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cunidades";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdesc1";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdesc2";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "c_monto_si_bs";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "c_impuesto_bs";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "c_impuesto_fact";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cname";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_razsocial_1";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_direcc_fiscal";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_telefono";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "nombredirecc";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_fecha_factura";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdias";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cporcdes";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "c_montotot_si_bs";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cimpuestofact";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "ctotalfact";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "ctotalcondesc";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdescuentofact";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cimpdesc";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cvendedor";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "produc_descrip";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "produc_descrip_2";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "ccostoneto_u1_bs";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cpedido";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "c_dia_ruta";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "calicuota";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cexento";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdescexento";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdescbaseimp";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdesimpbaseimp";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cmontofactsinexento";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cllevaobs";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdescpp";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cdescppmonto";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cmontobgrabada";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cmontobexenta";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cmontobgrabadadescpp";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.Double");
                    _Dta_Columna.ColumnName = "cprecioventamax";
                    _Dta_Columna.ReadOnly = true;
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cpatente";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cnamemunicipiopatente";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    _Dta_Columna = new DataColumn();
                    _Dta_Columna.DataType = System.Type.GetType("System.String");
                    _Dta_Columna.ColumnName = "cobsfactura";
                    _Dta_Tabla.Columns.Add(_Dta_Columna);
                    foreach (string _Str_String in _P_Str_Facturas_)
                    {
                        _Str_Sql = "SELECT ccompany, '" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cfactura), ccliente, c_rif, c_nomb_comer, cproducto, cempaques, cunidades, cdesc1, cdesc2, c_monto_si_bs, c_impuesto_bs, " +
                                   "c_impuesto_fact, cname, c_razsocial_1, c_direcc_fiscal, c_telefono, nombredirecc, c_fecha_factura, cdias, cporcdes, c_montotot_si_bs, cimpuestofact, " +
                                   "ctotalfact, ctotalcondesc, cdescuentofact, cimpdesc, cvendedor, produc_descrip, produc_descrip_2, ccostoneto_u1_bs, cpedido, c_dia_ruta, calicuota, cexento, cdescexento, cdescbaseimp, cdesimpbaseimp, cmontofactsinexento,cllevaobs,ISNULL(cdescpp,0),ISNULL(cdescppmonto,0),ISNULL(cmontobgrabada,0),ISNULL(cmontobexenta,0),ISNULL(cmontobgrabadadescpp,0), ISNULL(cprecioventamax,0),RTRIM(cpatente),RTRIM(cnamemunicipiopatente),RTRIM(cobsfactura) FROM [VST_FACTURAEMISIONV2] where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompanypre='" + Frm_Padre._Str_Comp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura ='" + _Str_String + "'";
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                        {
                            _Dta_Tabla.Rows.Add(new object[] { _Dtw_Item[0].ToString().TrimEnd(), _Dtw_Item[1].ToString().TrimEnd(), _Dtw_Item[2].ToString().TrimEnd(), _Dtw_Item[3].ToString().TrimEnd(), _Dtw_Item[4].ToString().TrimEnd(), _Dtw_Item[5].ToString().TrimEnd(), _Dtw_Item[6].ToString().TrimEnd(), _Dtw_Item[7].ToString().TrimEnd(), _Dtw_Item[8].ToString().TrimEnd(), _Dtw_Item[9].ToString().TrimEnd(), _Dtw_Item[10].ToString().TrimEnd(), _Dtw_Item[11].ToString().TrimEnd(), _Dtw_Item[12].ToString().TrimEnd(), _Dtw_Item[13].ToString().TrimEnd(), _Dtw_Item[14].ToString().TrimEnd(), _Dtw_Item[15].ToString().TrimEnd(), _Dtw_Item[16].ToString().TrimEnd(), _Dtw_Item[17].ToString().TrimEnd(), _Dtw_Item[18].ToString().TrimEnd(), _Dtw_Item[19].ToString().TrimEnd(), _Dtw_Item[20].ToString().TrimEnd(), _Dtw_Item[21].ToString().TrimEnd(), _Dtw_Item[22].ToString().TrimEnd(), _Dtw_Item[23].ToString().TrimEnd(), _Dtw_Item[24].ToString().TrimEnd(), _Dtw_Item[25].ToString().TrimEnd(), _Dtw_Item[26].ToString().TrimEnd(), _Dtw_Item[27].ToString().TrimEnd(), _Dtw_Item[28].ToString().TrimEnd(), _Dtw_Item[29].ToString().TrimEnd(), _Dtw_Item[30].ToString().TrimEnd(), _Dtw_Item[31].ToString().TrimEnd(), _Dtw_Item[32].ToString().TrimEnd(), _Dtw_Item[33].ToString().TrimEnd(), _Dtw_Item[34].ToString().TrimEnd(), _Dtw_Item[35].ToString().TrimEnd(), _Dtw_Item[36].ToString().TrimEnd(), _Dtw_Item[37].ToString().TrimEnd(), _Dtw_Item[38].ToString().TrimEnd(), _Dtw_Item[39].ToString().TrimEnd(), _Dtw_Item[40].ToString().TrimEnd(), _Dtw_Item[41].ToString().TrimEnd(), _Dtw_Item[42].ToString().TrimEnd(), _Dtw_Item[43].ToString().TrimEnd(), _Dtw_Item[44].ToString().TrimEnd(), _Dtw_Item[45].ToString().TrimEnd(), _Dtw_Item[46].ToString().TrimEnd(), _Dtw_Item[47].ToString().TrimEnd(), _Dtw_Item[48].ToString().TrimEnd() });
                        }
                    }
                    if (_Dta_Tabla.Rows.Count > 0)
                    {
                        //PQC MCY (Impresora sin margen arriba) -- Ignacio - 19-06-2013 --
                        //PQC PZO (Impresora sin margen arriba) -- Angel - 25-11-2013 --
                        //if ((T3.CLASES._Cls_Conexion._Int_Sucursal == 2) || (T3.CLASES._Cls_Conexion._Int_Sucursal == 5))
                        //{
                            REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rFacturaEmisionMCY", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                        //}
                        //else
                        //{
                        //    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rFacturaEmision", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                        //}
                    }
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿La impresión fue realizada correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        _Dg_Grid.Columns["Imprimir"].ReadOnly = true;
                        string _Str_Correlativo = _Mtd_Correlativo();
                        foreach (DataGridViewRow _Dg_RowTem in _Dg_Grid.Rows)
                        {
                            if (Convert.ToString(_Dg_RowTem.Cells["Imprimir"].Value).Trim() == "1")
                            {
                                _Str_Sql = "INSERT INTO TREIMPREFACT (cgroupcomp,ccompany,cidreimprefact,cfactura,cfechahora,cusuario) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Correlativo + "','" + Convert.ToString(_Dg_RowTem.Cells["Documento"].Value).Trim() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                        }
                        _Bt_Imprimir.Enabled = false;
                        _Pnl_Numero.Visible = true;
                    }
                    else
                    {
                        _Pnl_ReImpresion.Visible = true;
                    }
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }
        private string _Mtd_Correlativo()
        {
            string _Str_Sql = "SELECT MAX(cidreimprefact) FROM TREIMPREFACT where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            return _Cls_VariosMetodos._Mtd_Correlativo(_Str_Sql);
        }
        private bool _Mtd_BuscarIguales(int _P_Int_Index, object _P_Ob_Valor)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Index != _P_Int_Index)
                {
                    if (Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim() == _P_Ob_Valor.ToString().Trim())
                    { return true; }
                }
            }
            return false;
        }
        private bool _Mtd_FacturaExistente(string _P_Str_NumFactura)
        {
            DataView _Dtv = new DataView(((DataTable)_Dg_Grid.DataSource).DataSet.Tables[0]);
            _Dtv.RowFilter = "Documento='" + _P_Str_NumFactura + "'";
            if (_Dtv.Count > 0)
            {
                return true;
            }
            return false;
        }
        private bool _Mtd_FacturaMarcada(string _P_Str_NumFactura)
        {
            DataView _Dtv = new DataView(((DataTable)_Dg_Grid.DataSource).DataSet.Tables[0]);
            _Dtv.RowFilter = "Documento='" + _P_Str_NumFactura + "'";
            if (_Dtv.Count > 0)
            {
                return (_Dtv[0].Row["Imprimir"].ToString().Trim() == "1");
            }
            return false;
        }
        private void _Mtd_ColocarNumeros(int _P_Str_Numero)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1")
                    {
                        _Dg_Row.Cells["Numero"].Value = _P_Str_Numero;
                        _P_Str_Numero++;
                    }
                }
            }
        }
        private void _Mtd_ActualizarNumeros()
        {
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Imprimir"].Value != null)
                {
                    if (_Dg_Row.Cells["Imprimir"].Value.ToString().Trim() == "1")
                    {
                        _Str_Cadena = "UPDATE TFACTURAM SET c_numerocontrol='" + Convert.ToString(_Dg_Row.Cells["Numero"].Value).Trim() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
        }
        private void _Mtd_Ini()
        {
            _Bt_Actualizar.Enabled = false;
            _Bt_Imprimir.Enabled = true;
            _Dg_Grid.Columns["Imprimir"].ReadOnly = false;
            _Dg_Grid.Columns["Numero"].ReadOnly = true;
            _Mtd_Actualizar(_Txt_Desde.Text.Trim(), _Txt_Hasta.Text.Trim(), 0, " AND 0>1");//Para Inicializar
        }
        private bool _Mtd_VerificarNumContrlMayorComp(string _P_Str_NumCtrl)
        {
            try
            {
                string _Str_Cadena = "SELECT c_numerocontrol FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(c_numerocontrol,0)>=" + _P_Str_NumCtrl.Trim();
                bool _Bol_Return = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
                if (_Bol_Return)
                {
                    MessageBox.Show("El número de control ya fue ingresado anteriormente. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return _Bol_Return;
            }
            catch (Exception _Ex)
            {
                MessageBox.Show("Error al verificar el número de control.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            } 
        }
        private void Frm_ReImpresionFacturas_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_ReImpresion.Left = (this.Width / 2) - (_Pnl_ReImpresion.Width / 2);
            _Pnl_ReImpresion.Top = (this.Height / 2) - (_Pnl_ReImpresion.Height / 2);
            _Pnl_Numero.Left = (this.Width / 2) - (_Pnl_Numero.Width / 2);
            _Pnl_Numero.Top = (this.Height / 2) - (_Pnl_Numero.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted();
        }

        private void _Txt_Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Desde, e, 10, 0);
        }

        private void _Txt_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Hasta, e, 10, 0);
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Desde.Text.Trim().Length > 0 & _Txt_Hasta.Text.Trim().Length > 0)
            {
                if (Convert.ToInt32(_Txt_Desde.Text) > 0 & Convert.ToInt32(_Txt_Hasta.Text) > 0)
                {
                    if (Convert.ToInt32(_Txt_Desde.Text) <= Convert.ToInt32(_Txt_Hasta.Text))
                    {
                        _Mtd_Ini();
                        _Mtd_Actualizar(_Txt_Desde.Text.Trim(), _Txt_Hasta.Text.Trim(), 0, " AND 1>0");
                    }
                    else
                    { MessageBox.Show("El número de factura hasta debe ser mayor que el número de factura desde", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else
                {
                    if (Convert.ToInt32(_Txt_Desde.Text) == 0) { _Er_Error.SetError(_Txt_Desde, "Información requerida!!!"); }
                    if (Convert.ToInt32(_Txt_Hasta.Text) == 0) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
                }
            }
            else
            {
                if (_Txt_Desde.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Desde, "Información requerida!!!"); }
                if (_Txt_Hasta.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
            }
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (_Mtd_Seleccionar())//Verifica si tiene elementos seleccionado
            {
                if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_REIMPREFACT"))
                {
                    _Pnl_Clave.Visible = true;
                }
                else
                {
                    MessageBox.Show("Usted no tiene permisos para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            { MessageBox.Show("No se han seleccionado documentos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Pnl_Superior.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; _Pnl_Superior.Enabled = true; }
        }
        string _Str_NumeroTemp = "";
        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Numero")
                {
                    _Str_NumeroTemp = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value);
                }
            }
        }

        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Numero")
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        if (_Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length == 0)
                        {
                            _Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_NumeroTemp;
                        }
                        else if ((_Mtd_VerificarNumContrlMayorComp(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value)) || _Mtd_BuscarIguales(e.RowIndex, _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value)) & _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value.ToString().Trim() == "1")
                        {
                            //MessageBox.Show("El número de control ya fue ingresado anteriormente. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp;
                        }
                        else
                        { _Str_NumeroTemp = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value); }
                    }
                    else
                    { _Dg_Grid.Rows[e.RowIndex].Cells["Numero"].Value = _Str_NumeroTemp; }
                }
            }
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                if (_Dg_Grid.Columns[e.ColumnIndex].Name.Trim() == "Imprimir" & !_Dg_Grid.Columns["Imprimir"].ReadOnly)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value != null)
                    {
                        if (_Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value.ToString().Trim() == "1")
                        { _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value = 0; }
                        else
                        { _Dg_Grid.Rows[e.RowIndex].Cells["Imprimir"].Value = 1; }
                        _Dg_Grid.EndEdit();
                    }
                }
            }
        }

        private void _Pnl_ReImpresion_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_ReImpresion.Visible)
            { _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Pnl_Superior.Enabled = false; _LstBox_DocPrint.Items.Clear(); _Txt_NumDoc.Text = ""; _Txt_NumDoc.Focus(); }
            else
            { _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; _Pnl_Superior.Enabled = true; }
        }

        private void _Txt_NumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NumDoc, e, 10, 0);
        }

        private void _Bt_AddNumDoc_Click(object sender, EventArgs e)
        {
            if (_Txt_NumDoc.Text.Trim().Length > 0)
            {
                bool _Bol_FacturaExisGrid = _Mtd_FacturaExistente(_Txt_NumDoc.Text);
                int _Int_FacturaExisList = _LstBox_DocPrint.FindStringExact(_Txt_NumDoc.Text.Trim());
                bool _Bol_FacturaMarcada = _Mtd_FacturaMarcada(_Txt_NumDoc.Text);
                if (_Int_FacturaExisList == -1 & _Bol_FacturaExisGrid & _Bol_FacturaMarcada)
                {
                    _LstBox_DocPrint.Items.Add(_Txt_NumDoc.Text.Trim());
                }
                else
                {
                    if (_Int_FacturaExisList > -1)
                    { MessageBox.Show("Este número de documento ya fue cargado en la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else if (!_Bol_FacturaExisGrid)
                    { MessageBox.Show("Este número de documento no existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else
                    { MessageBox.Show("Este número de documento no fue previamente marcado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
        }

        private void _Bt_RestNumDoc_Click(object sender, EventArgs e)
        {
            if (_LstBox_DocPrint.SelectedIndex > -1)
            {
                _LstBox_DocPrint.Items.RemoveAt(_LstBox_DocPrint.SelectedIndex);
            }
        }

        private void _Bt_DesdeNumDoc_Click(object sender, EventArgs e)
        {
            if (_Txt_NumDoc.Text.Trim().Length > 0)
            {
                _LstBox_DocPrint.Items.Clear();
                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value) == "1")
                    {
                        if (Convert.ToInt32(_DgRow.Cells["Documento"].Value) >= Convert.ToInt32(_Txt_NumDoc.Text))
                        {
                            _LstBox_DocPrint.Items.Add(_DgRow.Cells["Documento"].Value.ToString());
                        }
                    }
                }
            }
            else
            {
                _Txt_NumDoc.Focus();
            }
        }

        private void _Bt_ReImprime_Click(object sender, EventArgs e)
        {
            if (_LstBox_DocPrint.Items.Count > 0)
            {
                _Pnl_ReImpresion.Visible = false;
                _Mtd_ImprimirFacturas();
            }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Mtd_ImprimirFacturas();
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_Seleccionar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Mtd_Actualizar(_Txt_Desde.Text.Trim(), _Txt_Hasta.Text.Trim(), 1, " AND 1>0");
            }
        }

        private void _Bt_Quitar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Mtd_Actualizar(_Txt_Desde.Text.Trim(), _Txt_Hasta.Text.Trim(), 0, " AND 1>0");
            }
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            _Mtd_ActualizarNumeros();
            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Txt_Desde.Text = "0";
            _Txt_Hasta.Text = "0";
            _Mtd_Ini();
        }

        private void _Pnl_Numero_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Numero.Visible)
            { _Dg_Grid.Enabled = false; _Pnl_Inferior.Enabled = false; _Pnl_Superior.Enabled = false; _Txt_Numero.Text = ""; _Txt_Numero.Focus(); }
            else
            { _Dg_Grid.Enabled = true; _Pnl_Inferior.Enabled = true; _Pnl_Superior.Enabled = true; }
        }

        private void _Bt_CancelarNumero_Click(object sender, EventArgs e)
        {
            _Pnl_Numero.Visible = false;
        }

        private void _Txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Numero, e, 10, 0);
        }

        private void _Bt_AceptarNumero_Click(object sender, EventArgs e)
        {
            if (_Txt_Numero.Text.Trim().Length > 0)
            {
                if (!_Mtd_VerificarNumContrlMayorComp(_Txt_Numero.Text))
                {
                    _Mtd_ColocarNumeros(Convert.ToInt32(_Txt_Numero.Text));
                    _Dg_Grid.Columns["Numero"].ReadOnly = false;
                    _Pnl_Numero.Visible = false;
                    _Bt_Actualizar.Enabled = true;
                }
                //else
                //{
                //    MessageBox.Show("El número de control ya fue ingresado anteriormente. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void _Bt_Historial_Click(object sender, EventArgs e)
        {
            Frm_HistReimpreFact _Frm = new Frm_HistReimpreFact();
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
        }

        private void _Txt_Desde_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Desde.Text))
            {
                _Txt_Desde.Text = "";
            }
        }

        private void _Txt_Hasta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Hasta.Text))
            {
                _Txt_Hasta.Text = "";
            }
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name.Trim() == "Numero")
            {
                if (!_Mtd_IsNumeric(((TextBox)sender).Text) || ((TextBox)sender).Text.Trim().Length > 9)
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name.Trim() == "Numero")
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void _Txt_Numero_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Numero.Text))
            {
                _Txt_Numero.Text = "";
            }
        }

        private void Frm_ReImpresionFacturas_Shown(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (!CLASES._Cls_Varios_Metodos._Mtd_Facturacion())
            {
                MessageBox.Show("De acuerdo al calendario de cierre no se puede facturar", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (CLASES._Cls_Varios_Metodos._Mtd_BloquearFacturacionPorCierre())
            {
                MessageBox.Show("De acuerdo al calendario de cierre no se puede facturar", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}