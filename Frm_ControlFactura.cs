using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using T3.Clases;

namespace T3
{
    public partial class Frm_ControlFactura : Form
    {
        public Frm_ControlFactura()
        {
            InitializeComponent();
        }

        bool _Bol_FrmTabVer = false;
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        Clases._Cls_RutinasImpresion _rutinasImpresion = new Clases._Cls_RutinasImpresion();
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        double _Dbl_FrmCostoDespacho = 0;
        double _Dbl_FrmCostoVarDespacho = 0;
        double _Dbl_FrmCostoFijoDespacho = 0;
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_FacturarFactAImp.Columns.Count; _Int_i++)
            {
                _Dg_FacturarFactAImp.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Frm_ControlFactura_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Bt_PrintFact.Enabled = false;
            _Bt_PrintGuiaDesp.Enabled = false;
            _Chk_FactImp.Enabled = false;
            _Chk_GuiaDespImp.Enabled = false;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_CargarGridPrecargasSinFact();
            _Mtd_CargarGridFactByPrint();
            _Mtd_Sorted();
        }
        private string _Mtd_DescripcionTipoPrecarga(string _P_Str_Precarga)
        {
            string _Str_Cadena = "SELECT 'TIPO '+CASE WHEN TPRECARGAM.ctipoalimento='0' THEN 'OTROS' WHEN TPRECARGAM.ctipoalimento='1' THEN 'ALIMENTOS' ELSE 'MIXTA' END +' PARA '+ CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS [Tipo Precarga] FROM TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private void _Mtd_ImprimirComprobante(string _Pr_Str_ComprobId, string _P_Str_Comp)
        {
            string _Str_Sql = "";
            bool _Bool_ClickOk = false;
            PrintDialog _Print = new PrintDialog();

        A:
            _Bool_ClickOk = false;
            if (_rutinasImpresion._Mtd_EstaHabilitadoConfiguracionImpresion())
            {
                PrinterSettings _ObjetoImpresion = null;
                Clases._Cls_RutinasImpresion._G_TiposDocumento _Tipo = _Cls_RutinasImpresion._G_TiposDocumento.Comprobante;
                //Cargo el Objeto que voy a setear enl dialogos segun compañia
                _ObjetoImpresion = _rutinasImpresion._Mtd_ObjetoImpresion(_Tipo, _P_Str_Comp);
                _Print.PrinterSettings = _ObjetoImpresion;
                _Bool_ClickOk = true;
            }
            else
            {
                MessageBox.Show("Prepare la impresora para imprimir el comprobante contable de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_P_Str_Comp), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    _Bool_ClickOk = true;
                }
            }

            if (_Bool_ClickOk)
            {
                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + _P_Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'", _Print, true, _P_Str_Comp);
                Cursor = Cursors.Default;

                if (MessageBox.Show("Se imprimió correctamente?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Frm.Close();
                    _Frm.Dispose();
                    _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + _P_Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    goto A;
                }
                //_Bt_PrintFact.Enabled = false;
            }
        }


        /// <summary>
        /// Retorna un valor que indica si una precarga es de intercompañía.
        /// </summary>
        /// <param name="_P_Str_Precarga">Id de la precarga</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_PrecargaIntercompañia(string _P_Str_Precarga)
        {
            string _Str_Cadena = "select top 1 cprecarga from TPRECARGAM inner join TCONFIGVENT on TPRECARGAM.ctipocliente=TCONFIGVENT.ctipoestcomprela where TPRECARGAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TCONFIGVENT.ccompany='" + Frm_Padre._Str_Comp + "' and TPRECARGAM.cprecarga='" + _P_Str_Precarga + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
            {
                _Str_Cadena = "SELECT TFACTURAM.ccliente FROM TFACTURAM INNER JOIN TICRELAPROCLI ON TFACTURAM.ccliente=TICRELAPROCLI.ccliente WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cprecarga='" + _P_Str_Precarga + "' AND TFACTURAM.cdelete<>1 AND TFACTURAM.c_factdevuelta=0";
                return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena);
            }
            return false;
        }
        private string _Mtd_GenerarComprobante(string _P_Str_Comp)
        {
            string _Str_Sql = "";
            DataSet _Ds;
            _Str_Sql = "SELECT cidcomprob FROM TPRECARGACOMPROB WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cprecarga='" + _Txt_PreCargaId.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            else
            {
                string _Str_cidcomprob = "";
                string _Str_cconceptocomp = "";
                string _Str_ctypcompro = "";
                string _Str_cyearacco = "";
                string _Str_cmontacco = "";
                string _Str_FactFirst = "";
                string _Str_FactLast = "";
                double _Dbl_MontoTot = 0;
                double _Dbl_MontoSimp = 0;
                double _Dbl_MontoImp = 0;
                double _Dbl_MontoDesc = 0;
                int _Int_corder = 0;
                int _Int_Ctrl = 0;
                string _Str_ccount = "";
                string _Str_ctdocument = "";
                string _Str_cnumdocu = "";
                string _Str_cdatedocu = "";
                string _Str_cdescrip = "";
                string _Str_cdescripS = "";

                string _Str_ProcesoCont = "P_CXC_FACT_CLIENT";
                if (_Mtd_PrecargaIntercompañia(_Txt_PreCargaId.Text.Trim()))
                    _Str_ProcesoCont = "P_CXC_FACT_CIA_RELA";
                Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
                _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
                _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
                _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(_P_Str_Comp).ToShortDateString(), _P_Str_Comp);
                _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(_P_Str_Comp).ToShortDateString(), _P_Str_Comp);
                _Str_Sql = "SELECT SUM(ISNULL(TFACTURAD.c_monto_si_bs,0)+ISNULL(TFACTURAD.cdescppmonto,0)) AS c_montotot_si, SUM(ISNULL(TFACTURAD.c_impuesto_bs,0)) AS c_impuesto,SUM(ISNULL(TFACTURAD.cdescppmonto,0)) AS c_desc_dpp,SUM(ISNULL(TFACTURAD.c_monto_si_bs,0) + ISNULL(TFACTURAD.c_impuesto_bs,0)) AS c_montotot FROM TFACTURAM INNER JOIN TFACTURAD ON TFACTURAM.cgroupcomp=TFACTURAD.cgroupcomp AND TFACTURAM.ccompany=TFACTURAD.ccompany AND TFACTURAM.cfactura=TFACTURAD.cfactura WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTURAM.ccompany='" + _P_Str_Comp + "' AND TFACTURAM.cprecarga='" + _Txt_PreCargaId.Text + "' AND TFACTURAM.cdelete<>1 AND TFACTURAM.c_factdevuelta=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_montotot_si"]) != "")
                    { _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_impuesto"]) != "")
                    { _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_desc_dpp"]) != "")
                    { _Dbl_MontoDesc = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_desc_dpp"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_montotot"]) != "")
                    { _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot"]); }
                }

                //Obtengo el id del comprobante
                _Str_cidcomprob = Convert.ToString(myUtilidad._Mtd_Consecutivo_TCOMPROBANC(_P_Str_Comp));
                //GUARDO LA CABECERA
                _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
                _Str_Sql = _Str_Sql + _P_Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot + _Dbl_MontoDesc) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot + _Dbl_MontoDesc) + "',0,'" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                //GUARDO EL DETALLE
                _Str_Sql = "select min(cfactura) as FactMin, max(cfactura) as FactMax from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "' AND cdelete<>1  AND c_factdevuelta=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_FactFirst = Convert.ToString(_Ds.Tables[0].Rows[0]["FactMin"]);
                    _Str_FactLast = Convert.ToString(_Ds.Tables[0].Rows[0]["FactMax"]);
                }
                _Str_Sql = "select cfechaprecarga from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_cdatedocu = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaprecarga"]).ToShortDateString();
                }
                _Str_cnumdocu = _Txt_PreCargaId.Text;
                double _Dbl_Monto = 0;
                _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + _Str_ProcesoCont + "' AND ccompany='" + _P_Str_Comp + "' ORDER BY cideprocesod";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                {
                    _Int_corder++;
                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                    _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);
                    if (Convert.ToInt32(_Drow["cideprocesod"]) == 1)
                    { _Dbl_Monto = _Dbl_MontoTot; }
                    else if (Convert.ToInt32(_Drow["cideprocesod"]) == 2)
                    { _Dbl_Monto = _Dbl_MontoSimp; }
                    else if (Convert.ToInt32(_Drow["cideprocesod"]) == 3)
                    { _Dbl_Monto = _Dbl_MontoImp; }
                    else
                    { _Dbl_Monto = _Dbl_MontoDesc; }
                    _Str_cdescripS = _Str_cdescrip + " FACT. DESDE " + _Str_FactFirst + " AL " + _Str_FactLast;
                    if (_Dbl_Monto > 0)
                    {
                        if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values ";
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values ";

                        }
                        _Str_Sql += "('" + _P_Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cdatedocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescripS + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
                myUtilidad._Mtd_InsertarAuxiliarFACT(_Txt_PreCargaId.Text.Trim(), _Str_cidcomprob, _P_Str_Comp, _Str_ProcesoCont);

                //trato de guardar la tabla PEQUSEADA!
                _Lbl_Reintentar:
                try
                {
                    //Mientras no exista el registro
                    while (!_Mtd_ExisteRegistroEnTPRECARGACOMPROB(Frm_Padre._Str_GroupComp, _P_Str_Comp, _Txt_PreCargaId.Text.Trim()))
                    {
                        //inserto el registro
                        _Str_Sql = "INSERT INTO TPRECARGACOMPROB (cgroupcomp,ccompany,cprecarga,cidcomprob) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Txt_PreCargaId.Text.Trim() + "','" + _Str_cidcomprob + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
                catch (Exception _Ex)
                {
                    //var cursor = Cursor; Cursor = Cursors.Default; MessageBox.Show("Error al intentar guardar el id del comprobante contable.\n" + _Ex.Message + "\nPor favor envíe un control de falla antes de cerrar esta ventana.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Cursor = cursor;
                    goto _Lbl_Reintentar;
                }

                _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + _P_Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                return _Str_cidcomprob;
            }
        }
        /// <summary>
        /// Indica se ya esta cargado el registro en la tabla pequseada
        /// </summary>
        /// <param name="_P_Str_cgroupcomp"></param>
        /// <param name="_P_Str_ccompany"></param>
        /// <param name="_P_Str_cprecarga"></param>
        /// <returns></returns>
        private bool _Mtd_ExisteRegistroEnTPRECARGACOMPROB(string _P_Str_cgroupcomp, string _P_Str_ccompany, string _P_Str_cprecarga)
        {
            string _Str_Sql;
            DataSet _Ds;
            //Verifico si el registro existe 
            _Str_Sql = "SELECT cidcomprob FROM TPRECARGACOMPROB WHERE cgroupcomp='" + _P_Str_cgroupcomp + "' AND ccompany='" + _P_Str_ccompany + "' AND cprecarga='" + _P_Str_cprecarga + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si existe
            if (_Ds.Tables[0].Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }

        private void _Mtd_CargarGridPrecargasSinFact()
        {
            object[] _Str_RowNew = new object[6];
            string _Str_Sql = "SELECT CONVERT(VARCHAR,cfechaprecarga,103) AS cfechaprecarga,cprecarga,cplaca,ctotalempaq,ctotalunidad,CAST(ctotalkg AS NUMERIC) AS ctotalkg FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cimprimeprecarga=1 AND cverificascanpalm=1 AND cimprimefactura=0 AND cimprimeguiadesp=0 AND cplaca<>'0' AND ccedula<>'0'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_PreCargarSFact.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_PreCargarSFact.Rows.Add(_Str_RowNew);
            }
            _Dg_PreCargarSFact.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGridFactByPrint()
        {
            string _Str_PreCarga = "";
            object[] _Str_RowNew = new object[12];
            string _Str_Sql = "SELECT ccompany,CONVERT(VARCHAR,c_fecha_factura,103) AS c_fecha_factura,cfactura,cempaques,cunidades,(CAST(ccliente AS VARCHAR(18))+'-'+c_nomb_comer) AS c_nomb_comer,ccliente,cprecarga,c_impresa_descrip,csts_guiadesp_precarga,c_factdevuelta FROM VST_FACTURAG WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cplaca<>'0' AND ccedula<>'0' AND (c_impresa<>1 or cimprimeguiadesp=0 and cprecarga<>0 AND c_factdevuelta=0 OR (c_impresa=1 AND cimprimeguiadesp=0 and cprecarga<>0 AND c_factdevuelta=1)) ORDER BY ccompany,cfactura";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_FactAImp.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_FactAImp.Rows.Add(_Str_RowNew);
            }
            _Dg_FactAImp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewRow _DgRow in _Dg_PreCargarSFact.Rows)
            {
                _Str_PreCarga = _DgRow.Cells["cprecarga1"].Value.ToString();
                for (int i = 0; i < _Dg_FactAImp.Rows.Count; i++)
                {
                    if (_Dg_FactAImp["cprecarga2", i].Value.ToString().Trim() == _Str_PreCarga.Trim())
                    {
                        _Dg_FactAImp.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            _Mtd_Verificar_PrefacturasDev();
        }

        private void _ToolBt_Actualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGridPrecargasSinFact();
            _Mtd_CargarGridFactByPrint();
            Cursor = Cursors.Default;
        }
        private void _Mtd_ImprimirFacturas(string[] _P_Str_Facturas_, PrintDialog _Print, string _P_Str_Comp)
        {
            //Cursor = Cursors.WaitCursor;
            string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(_P_Str_Comp);
            string _Str_Sql = "";
            DataSet _Ds_DataSet = new DataSet();
            DataTable _Dta_Tabla = new DataTable("Relacion");
            DataColumn _Dta_Columna;
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
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cexento";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdescexento";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdescbaseimp";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdesimpbaseimp";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cmontofactsinexento";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cllevaobs";
            _Dta_Columna.ReadOnly = true;
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
                           "ctotalfact, ctotalcondesc, cdescuentofact, cimpdesc, cvendedor, produc_descrip, produc_descrip_2, ccostoneto_u1_bs, cpedido, c_dia_ruta, calicuota, cexento, cdescexento, cdescbaseimp, cdesimpbaseimp, cmontofactsinexento, cllevaobs,ISNULL(cdescpp,0),ISNULL(cdescppmonto,0),ISNULL(cmontobgrabada,0),ISNULL(cmontobexenta,0),ISNULL(cmontobgrabadadescpp,0),ISNULL(cprecioventamax,0),RTRIM(cpatente),RTRIM(cnamemunicipiopatente),RTRIM(cobsfactura) FROM [VST_FACTURAEMISIONV2] where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompanypre='" + _P_Str_Comp + "' and ccompany='" + _P_Str_Comp + "' and cfactura='" + _Str_String + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                {
                    _Dta_Tabla.Rows.Add(new object[] { _Dtw_Item[0].ToString().TrimEnd(), _Dtw_Item[1].ToString().TrimEnd(), _Dtw_Item[2].ToString().TrimEnd(), _Dtw_Item[3].ToString().TrimEnd(), _Dtw_Item[4].ToString().TrimEnd(), _Dtw_Item[5].ToString().TrimEnd(), _Dtw_Item[6].ToString().TrimEnd(), _Dtw_Item[7].ToString().TrimEnd(), _Dtw_Item[8].ToString().TrimEnd(), _Dtw_Item[9].ToString().TrimEnd(), _Dtw_Item[10].ToString().TrimEnd(), _Dtw_Item[11].ToString().TrimEnd(), _Dtw_Item[12].ToString().TrimEnd(), _Dtw_Item[13].ToString().TrimEnd(), _Dtw_Item[14].ToString().TrimEnd(), _Dtw_Item[15].ToString().TrimEnd(), _Dtw_Item[16].ToString().TrimEnd(), _Dtw_Item[17].ToString().TrimEnd(), _Dtw_Item[18].ToString().TrimEnd(), _Dtw_Item[19].ToString().TrimEnd(), _Dtw_Item[20].ToString().TrimEnd(), _Dtw_Item[21].ToString().TrimEnd(), _Dtw_Item[22].ToString().TrimEnd(), _Dtw_Item[23].ToString().TrimEnd(), _Dtw_Item[24].ToString().TrimEnd(), _Dtw_Item[25].ToString().TrimEnd(), _Dtw_Item[26].ToString().TrimEnd(), _Dtw_Item[27].ToString().TrimEnd(), _Dtw_Item[28].ToString().TrimEnd(), _Dtw_Item[29].ToString().TrimEnd(), _Dtw_Item[30].ToString().TrimEnd(), _Dtw_Item[31].ToString().TrimEnd(), _Dtw_Item[32].ToString().TrimEnd(), _Dtw_Item[33].ToString().TrimEnd(), _Dtw_Item[34].ToString().TrimEnd(), _Dtw_Item[35].ToString().TrimEnd(), _Dtw_Item[36].ToString().TrimEnd(), _Dtw_Item[37].ToString().TrimEnd(), _Dtw_Item[38].ToString().TrimEnd(), _Dtw_Item[39].ToString().TrimEnd(), _Dtw_Item[40].ToString().TrimEnd(), _Dtw_Item[41].ToString().TrimEnd(), _Dtw_Item[42].ToString().TrimEnd(), _Dtw_Item[43].ToString().TrimEnd(), _Dtw_Item[44].ToString().TrimEnd(), _Dtw_Item[45].ToString().TrimEnd(), _Dtw_Item[46].ToString().TrimEnd(), _Dtw_Item[47].ToString().TrimEnd(), _Dtw_Item[48].ToString().TrimEnd() });
                }
            }
            if (_Dta_Tabla.Rows.Count > 0)
            {
                //PQC MCY (Impresora sin margen arriba) -- Ignacio - 19-06-2013 --
                if (T3.CLASES._Cls_Conexion._Int_Sucursal == 2)
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rFacturaEmisionMCY", _Dta_Tabla, _Print, true, "Section2", "", "", "", _P_Str_Comp);
                }
                else
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rFacturaEmision", _Dta_Tabla, _Print, true, "Section2", "", "", "", _P_Str_Comp);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una factura para continuar");
            }
            //Cursor = Cursors.Default;
        }

        private void _Bt_PrintFact_Click(object sender, EventArgs e)
        {
            if (_rutinasImpresion._Mtd_EstaHabilitadoConfiguracionImpresion())
            {
                _Mtd_ImprimirFormaParalela(_Txt_PreCargaId.Text.Trim());
            }
            else
            {
                _Mtd_ImprimirVariasComp(_Txt_PreCargaId.Text.Trim());
            }
        }
        private bool _Mtd_VerificarImpresionFacturas(string _P_Str_PreCarga)
        {
            string _Str_Cadena = "SELECT cimprimefactura FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "' AND cimprimefactura='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_ImprimirVariasComp(string _P_Str_PreCarga)
        {
            try
            {
                if (!_Mtd_VerificarImpresionFacturas(_P_Str_PreCarga))
                {
                    PrintDialog _My_PrintDialogo = new PrintDialog();
                    string _Str_Sql = "";
                    int _Int_TotFact = 0;
                    int _Int_TotFactImp = 0;
                    string _Str_Cadena = "SELECT DISTINCT ccompany FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "' AND c_impresa='0'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        string _Str_Filtro = " AND (0=0";
                        string _Str_PrinterName = "";
                        int _Int_TpoPapel = -1;
                        int _Int_SizePapel = -1;
                        bool _Bol_PrintAgain = false;
                        if (MessageBox.Show("Está preparada la impresora para imprimir las facturas de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()).ToUpper() + "?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                        A:
                            _My_PrintDialogo = new PrintDialog();
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cpapersource,cpapersize,ccprinter_name FROM TCONFIGPRINTER WHERE ccompany='" + _Row[0].ToString().Trim() + "'");
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cpapersource"]) != "")
                                {
                                    _Int_TpoPapel = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cpapersource"]);
                                }
                                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cpapersize"]) != "")
                                {
                                    _Int_SizePapel = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cpapersize"]);
                                }
                                _Str_PrinterName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccprinter_name"]);
                            }
                            if (_Int_TpoPapel != -1 && _Int_SizePapel != -1)
                            {

                                try
                                {
                                    _My_PrintDialogo.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = _Str_PrinterName;
                                    for (int _I = 0; _I < _My_PrintDialogo.PrinterSettings.PaperSources.Count; _I++)
                                    {
                                        if (_My_PrintDialogo.PrinterSettings.PaperSources[_I].RawKind == _Int_TpoPapel)
                                        {
                                            _Int_TpoPapel = _I;
                                            break;
                                        }
                                    }
                                    for (int _I = 0; _I < _My_PrintDialogo.PrinterSettings.PaperSizes.Count; _I++)
                                    {
                                        if (_My_PrintDialogo.PrinterSettings.PaperSizes[_I].RawKind == _Int_SizePapel)
                                        {
                                            _Int_SizePapel = _I;
                                            break;
                                        }
                                    }

                                    System.Drawing.Printing.PaperSource _My_TpoPapel = _My_PrintDialogo.PrinterSettings.PaperSources[_Int_TpoPapel];
                                    _My_PrintDialogo.PrinterSettings.DefaultPageSettings.PaperSource = _My_TpoPapel;
                                    System.Drawing.Printing.PaperSize _My_Tamano = _My_PrintDialogo.PrinterSettings.PaperSizes[_Int_SizePapel];
                                    _My_PrintDialogo.PrinterSettings.DefaultPageSettings.PaperSize = _My_Tamano;
                                }
                                catch
                                {
                                    _My_PrintDialogo = new PrintDialog();
                                }

                                if (_My_PrintDialogo.ShowDialog() == DialogResult.OK)
                                {
                                    string[] _Str_Facturas_ = new string[0];
                                    foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                                    {
                                        if (Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim().ToUpper() == _Row[0].ToString().Trim().ToUpper())
                                        {
                                            if (_DgRow.Cells["Marcar"].Value == null)
                                            {
                                                _DgRow.Cells["Marcar"].Value = "0";
                                            }
                                            if (_DgRow.Cells["Marcar"].Value.ToString().Trim() == "0")
                                            {
                                                _Str_Facturas_ = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Facturas_, _Str_Facturas_.Length + 1);
                                                _Str_Facturas_[_Str_Facturas_.Length - 1] = Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim();
                                                //--------
                                                _Str_Filtro = _Str_Filtro + " OR cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                                            }
                                        }
                                    }
                                    if (_Bol_PrintAgain)
                                    {
                                        Frm_ReImprime _Frm_ReImprime = new Frm_ReImprime("FACTURA", _Str_Facturas_, "Re-Impresion de Facturas de la compañía (" + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()) + ")");
                                        if (_Frm_ReImprime.ShowDialog() == DialogResult.OK)
                                        {
                                            _Str_Facturas_ = _Frm_ReImprime._Str_Facturas_R;
                                        }
                                    }
                                    if (_Str_Facturas_.Length > 0)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        _Mtd_ImprimirFacturas(_Str_Facturas_, _My_PrintDialogo, _Row[0].ToString().Trim());
                                        Cursor = Cursors.Default;
                                    }
                                    if (MessageBox.Show("Fueron impresas correctamente las facturas de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()) + "?", "Verificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        string _Str_ComprobId = "";
                                        string _Str_CodPrefactura = "", _Str_PedidoId = "";
                                        Cursor = Cursors.WaitCursor;
                                        _Str_ComprobId = _Mtd_GenerarComprobante(_Row[0].ToString().Trim());
                                        Cursor = Cursors.Default;
                                        //MARCO LAS FACTURAS IMPRESAS
                                        Cursor = Cursors.WaitCursor;
                                        foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                                        {
                                            if (Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim().ToUpper() == _Row[0].ToString().Trim().ToUpper())
                                            {
                                                _Str_Sql = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Row[0].ToString().Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "' AND cprecarga='" + _P_Str_PreCarga + "' AND c_impresa<>1";
                                                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                                                {
                                                    _Str_Sql = "UPDATE TFACTURAM SET c_impresa=1,cidcomprob='" + _Str_ComprobId + "',cdateupd='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Row[0].ToString().Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                }
                                                _Str_Sql = "SELECT cpfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Row[0].ToString().Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                                if (_Ds.Tables[0].Rows.Count > 0)
                                                {
                                                    _Str_CodPrefactura = _Ds.Tables[0].Rows[0][0].ToString();
                                                }
                                                _Str_Sql = "UPDATE TPREFACTURAM SET cproceso='F' WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND cpfactura='" + _Str_CodPrefactura + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                                _Str_Sql = "SELECT cpedido FROM TPREFACTURAM WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND cpfactura='" + _Str_CodPrefactura + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                                if (_Ds.Tables[0].Rows.Count > 0)
                                                {
                                                    _Str_PedidoId = _Ds.Tables[0].Rows[0][0].ToString();
                                                }
                                                _Str_Sql = "UPDATE TCOTPEDFACM SET cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "',cproceso='F' WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND cpedido='" + _Str_PedidoId + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                        }
                                        Cursor = Cursors.Default;
                                        //EL COMPROBANTE CONTABLE
                                        //myUtilidad._Mtd_InsertarAuxiliarFACT(_Txt_PreCargaId.Text.Trim(), _Str_ComprobId, _Row[0].ToString().Trim());
                                        //_Str_Sql = "UPDATE TCOMPROBANDD SET cstatus='2' where ccompany='" + _Row[0].ToString().Trim() + "' and cidcomprob='" + _Str_ComprobId + "'";
                                        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);//Se colocará en cstatus='1' cuando se liquíde la guía
                                        _Mtd_ImprimirComprobante(_Str_ComprobId, _Row[0].ToString().Trim());
                                        //ACTUALIZO EL SALDO DEL CLIENTE
                                        //_Mtd_ActualizarSaldoCliente();
                                        Cursor = Cursors.WaitCursor;
                                        Frm_ImpresionLote _Frm = new Frm_ImpresionLote(_Str_Filtro, true, _Row[0].ToString().Trim());
                                        _Frm.StartPosition = FormStartPosition.CenterScreen;
                                        Cursor = Cursors.Default;
                                        //_Frm.MdiParent = this.MdiParent;
                                        _Frm.ShowDialog();
                                        //_Chk_FactImp.Checked = true;
                                        //_Bt_PrintGuiaDesp.Enabled = true;
                                    }
                                    else
                                    {
                                        _Bol_PrintAgain = true;
                                        goto A;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("La impresora no esta configurada", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    _My_PrintDialogo.Reset();
                    _My_PrintDialogo.Dispose();
                    //VERIFICO QUE TODAS LAS FACTURAS ESTEN IMPRESAS
                    _Str_Sql = "select count(*) from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_TotFact = Convert.ToInt16(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    _Str_Sql = "select count(*) from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "' and c_impresa=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_TotFactImp = Convert.ToInt16(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    if (_Int_TotFact != 0)
                    {
                        if (_Int_TotFact == _Int_TotFactImp)
                        {
                            _Bt_PrintFact.Enabled = false;
                            _Chk_FactImp.Checked = true;
                            _Bt_PrintGuiaDesp.Enabled = true;
                            _Str_Sql = "UPDATE TPRECARGAM SET cimprimefactura=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Las facturas de la Pre-Carga " + _P_Str_PreCarga + " ya fueron impresas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_CargarFacturasByPrecarga(string _Pr_Str_cprecarga)
        {
            object[] _Str_RowNew = new object[15];
            string _Str_Sql = "SELECT ccompany,cfactura,(CAST(ccliente AS VARCHAR(18))+'-'+rtrim(c_nomb_comer)) as c_nomb_comer,rtrim(c_direcc_descrip) as c_direcc_descrip,cempaques,cunidades,c_fecha_factura,c_monto_si_bs,c_impuesto_bs,ccliente,cfpago,Kilos,Metros,c_direcc_despa,c_factdevuelta FROM VST_FACTURATOTALES WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_cprecarga + "' and cdelete=0 AND (c_impresa<>1 or cimprimeguiadesp=0 and cprecarga<>0 AND c_factdevuelta=0 OR (c_impresa=1 AND cimprimeguiadesp=0 and cprecarga<>0 AND c_factdevuelta=1)) AND NOT EXISTS(SELECT cfactura FROM TGUIADESPACHOD WHERE TGUIADESPACHOD.cgroupcomp = VST_FACTURATOTALES.cgroupcomp AND TGUIADESPACHOD.ccompany = VST_FACTURATOTALES.ccompany AND TGUIADESPACHOD.cfactura = VST_FACTURATOTALES.cfactura AND c_estatus='FIR') AND NOT EXISTS (SELECT cfactura FROM TFACTURANUL WHERE VST_FACTURATOTALES.ccompany = ccompany AND VST_FACTURATOTALES.cfactura = cfactura) ORDER BY ccompany,cfactura";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_FacturarFactAImp.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_FacturarFactAImp.Rows.Add(_Str_RowNew);
            }
            _Dg_FacturarFactAImp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Mtd_Verificar_PrefacturasDev2();
            _Dbl_FrmCostoDespacho = 0;
            _Dbl_FrmCostoFijoDespacho = 0;
            _Dbl_FrmCostoVarDespacho = 0;
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string _Mtd_BuscarLimites(string _P_Str_Placa)
        {
            string _Str_Cadena = "Select calto,cancho,cprofundidad,ctttransporte,ccapcarg from TTRANSPORTE where cplaca='" + _P_Str_Placa + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_Alto = 0;
            double _Dbl_Ancho = 0;
            double _Dbl_Profundidad = 0;
            double _Dbl_LimiteMt = 0;
            double _Dbl_LimiteKg = 0;
            double _Dbl_LimiteBs = 0;
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
                        //if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        //{ _Dbl_LimiteKg = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString()); }
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
                { _Str_Cadena = _Str_Cadena + ", Límite en  Bs.F. / Bs.F."; }
                else
                { _Str_Cadena = _Str_Cadena + "El Límite en  Bs.F. / Bs.F."; }
            }
            _Txt_Mt.Text = _Dbl_LimiteMt.ToString();
            _Txt_Kg.Text = _Dbl_LimiteKg.ToString();
            _Txt_Bs.Text = _Dbl_LimiteBs.ToString("#,##0.00");
            _Prb_Kg.Maximum = Convert.ToInt32(_Dbl_LimiteKg);
            _Prb_Mt.Maximum = Convert.ToInt32(_Dbl_LimiteMt);
            _Prb_Bs.Maximum = Convert.ToInt32(_Dbl_LimiteBs);
            return _Str_Cadena;
        }

        private void _Mtd_CargarPreCarga(string _Pr_Str_PreCargaId)
        {
            DataSet _Ds;
            string _Str_Sql = "";
            _Txt_PreCargaId.Text = _Pr_Str_PreCargaId;
            _Str_Sql = "SELECT cplaca,Transporte,cnombre,ccedula FROM VST_PRECARGA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_PreCargaId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Placa.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cplaca"]).Trim();
                _Txt_DescripTransp.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["Transporte"]).Trim();
                _Txt_Transportista.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnombre"]).Trim();
                _Txt_Transportista.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccedula"]).Trim();
            }

            _Str_Sql = "SELECT cidrutdespacho,cdescripcion FROM VST_PRECARGADR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_PreCargaId + "'";
            myUtilidad._Mtd_CargarLista(_Lst_RutasDesp, _Str_Sql);
            _Mtd_BuscarLimites(_Txt_Placa.Text);
        }

        private void _CMen_A_Facturar_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (!CLASES._Cls_Varios_Metodos._Mtd_Facturacion())
            {
                MessageBox.Show("De acuerdo al calendario de cierre no se puede facturar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (CLASES._Cls_Varios_Metodos._Mtd_BloquearFacturacionPorCierre())
            {
                MessageBox.Show("De acuerdo al calendario de cierre no se puede facturar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_GENERA_FACTURA"))
                {
                    string _Str_Placa = "";
                    string _Str_Precarga = _Dg_PreCargarSFact[1, _Dg_PreCargarSFact.CurrentCell.RowIndex].Value.ToString();
                    string _Str_Sql = "SELECT cplaca FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Str_Precarga + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Placa = _Ds.Tables[0].Rows[0][0].ToString();
                    }
                    _Str_Sql = "SELECT cplaca FROM TTRANSPORTE WHERE cplaca='" + _Str_Placa + "' AND cocupado=1";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                    {
                        MessageBox.Show("El transporte con placa " + _Str_Placa + " esta ocupado, y por tanto no se puede facturar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_GenerarFactura();
                        Cursor = Cursors.Default;
                        _Lbl_TipoPrecarga.Text = _Mtd_DescripcionTipoPrecarga(_Str_Precarga);
                    }
                }
                else
                {
                    MessageBox.Show("Usted no tiene permiso para generar la factura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_GenerarFactura()
        {
            string _Str_Sql = "";
            if (_Txt_Clave.Text.Trim() == "")
            {
                _Lbl_TituloClave.Text = "Generando Factura";
                _Pnl_Clave.Visible = true;
            }
            else
            {
                var bSoloFacturasDevueltas = true;
                _Mtd_CargarPreCarga(Convert.ToString(_Dg_PreCargarSFact["cprecarga1", _Dg_PreCargarSFact.CurrentCell.RowIndex].Value));
                //ACTIVO EL TRIGGER  DE ROBERTO
                _Str_Sql = "SELECT c_factdevuelta FROM TPREFACTURAM WHERE " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp() + " AND cprecarga='" + _Dg_PreCargarSFact[1, _Dg_PreCargarSFact.CurrentCell.RowIndex].Value.ToString() + "' AND c_factdevuelta=0";
                DataSet _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                {
                    _Str_Sql = "SELECT cpfactura,c_nomb_comer,c_direcc_descrip,cempaques,cunidades,c_fecha_factura,c_montotot_si,c_impuesto,ccliente,cfpago,Kilos,Metros,c_direcc_despa,ccompany FROM VST_PREFACTURASTOTALES WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Dg_PreCargarSFact[1, _Dg_PreCargarSFact.CurrentCell.RowIndex].Value.ToString() + "' and cdelete=0";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                    {
                        _Str_Sql = "UPDATE TPREFACTURAM SET cfacturado=1 WHERE ccompany='" + Convert.ToString(_Drow["ccompany"].ToString()) + "' AND cpfactura='" + Convert.ToString(_Drow["cpfactura"].ToString()) + "' AND c_factdevuelta = 0";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                    _Str_Sql = "UPDATE TPRECARGAM SET cimprimefactura=2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "'";
                }
                else
                {
                    _Str_Sql = "UPDATE TPRECARGAM SET cimprimefactura=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "'";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_CargarFacturasByPrecarga(Convert.ToString(_Dg_PreCargarSFact["cprecarga1", _Dg_PreCargarSFact.CurrentCell.RowIndex].Value));
                _Mtd_AjustarProgressbar();
                _Bol_FrmTabVer = true;
                _Bt_PrintGuiaDesp.Enabled = false;
                //_Bt_PrintFact.Enabled = true;
                _Tb_Tab.SelectTab(1);
                _Txt_Clave.Text = "";
            }

        }


        private void _Mtd_GenerarGuiaDespacho()
        {
            bool _Bol_Valida = false;
            string _Str_cguiadesp = "";
            string _Str_Sql = "";
            DataSet _Ds;
            foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
            {
                _Str_Sql = "SELECT c_numerocontrol FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length == 0)
                    {
                        _Bol_Valida = true;
                    }
                    else if (Convert.ToDouble(_Ds.Tables[0].Rows[0][0]) == 0)
                    {
                        _Bol_Valida = true;
                    }
                }
            }
            if (!_Bol_Valida)
            {
                _Str_Sql = "SELECT cguiadesp FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    _Str_cguiadesp = myUtilidad._Mtd_Correlativo("SELECT MAX(cguiadesp) FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'");
                    _Str_Sql = "INSERT INTO TGUIADESPACHOM (cgroupcomp,cguiadesp,cprecarga,cplaca,ccedula,cfechasalida) VALUES" +
                    "('" + Frm_Padre._Str_GroupComp + "','" + _Str_cguiadesp + "','" + _Txt_PreCargaId.Text + "','" + _Txt_Placa.Text + "','" + Convert.ToString(_Txt_Transportista.Tag) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_cguiadesp = Convert.ToString(_Ds.Tables[0].Rows[0]["cguiadesp"]);
                }

                foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                {
                    _Str_Sql = "SELECT * FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cprecarga='" + _Txt_PreCargaId.Text + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {//AGREGO
                        _Str_Sql = "INSERT INTO TGUIADESPACHOD (cgroupcomp,ccompany,cguiadesp,cprecarga,cfactura) VALUES" +
                        "('" + Frm_Padre._Str_GroupComp + "','" + Convert.ToString(_DgRow.Cells["ccompany2"].Value) + "','" + _Str_cguiadesp + "','" + _Txt_PreCargaId.Text + "','" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                    _Str_Sql = "UPDATE TFACTURAM SET cguiadesp='" + _Str_cguiadesp + "',cdateupd='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "SELECT cpfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {
                        _Str_Sql = "UPDATE TPREFACTURAM SET cguiadesp='" + _Str_cguiadesp + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cpfactura='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
                //IMPRIMO LA GUIA DE DESPACHO

                _Mtd_PrintGuiaDespacho(_Str_cguiadesp, _Txt_PreCargaId.Text.Trim());
                _Mtd_CargarGridPrecargasSinFact();
                _Mtd_CargarGridFactByPrint();
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                if (_Mtd_VerifGuiaDesp(_Txt_PreCargaId.Text))
                {
                    _Chk_GuiaDespImp.Checked = true;
                }
                else
                {
                    _Chk_GuiaDespImp.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Existen Facturas sin número de control. No se puede continuar con este proceso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DataTable _Mtd_ReporteGuiaDesp(string _P_Str_Guia, string _P_Str_Precarga)
        {
            string _Str_Cadena = "EXEC PA_RUTA_DESCRIP_GUIA '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Guia + "','" + _P_Str_Precarga + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
        }
        private string _Mtd_TipoGuiaSADAMensj(string _P_Str_Guia)
        {
            string _Str_Mensaje = "Debe trabajar con los siguientes tipos de guías SADA:";
            DataSet _Ds_Temp = new DataSet();
            string _Str_Cadena = "SELECT ccompany,ctipoguiasada FROM TGUIADESPACHODD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _P_Str_Guia + "' AND ISNULL(ctipoguiasada,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Mensaje += "\nPara la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row["ccompany"].ToString().Trim()) + ": " + _Mtd_TipoGuiaSADA(Convert.ToInt32(_Row["ctipoguiasada"]));
            }
            return _Str_Mensaje;
        }
        private bool _Mtd_ActualizacionSADA(string _P_Str_Guia)
        {
            bool _Bol_GuiaSada = false;
            string _Str_Cadena = "SELECT DISTINCT ccompany FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _P_Str_Guia + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                int _Int_TipoGuiaSada = _Mtd_TipoGuiaSADA(_P_Str_Guia, _Row[0].ToString().Trim());
                _Str_Cadena = "INSERT INTO TGUIADESPACHODD (cgroupcomp,ccompany,cguiadesp,ctipoguiasada) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + _Row[0].ToString().Trim() + "','" + _P_Str_Guia + "','" + _Int_TipoGuiaSada + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if (_Int_TipoGuiaSada > 0)
                { _Bol_GuiaSada = true; }
            }
            return _Bol_GuiaSada;
        }
        private int _Mtd_TipoGuiaSADA(string _P_Str_Guia, string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT cfronteriza FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cfronteriza,0)='1'";
            bool _Bol_Fronteriza = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            double _Dbl_Toneladas = 0;
            //--------------------
            _Str_Cadena = "SELECT  ISNULL(SUM(CONVERT(NUMERIC(18,3),CONVERT(NUMERIC(18,2),CONVERT(NUMERIC(18,2),(TFACTURAD.cempaques*(TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))+TFACTURAD.cunidades)*CONVERT(NUMERIC(18,2),cpesounid1))/1000000)),0) AS Toneladas " +
                      "FROM TFACTURAM INNER JOIN " +
                      "TFACTURAD ON TFACTURAM.cgroupcomp = TFACTURAD.cgroupcomp AND TFACTURAM.ccompany = TFACTURAD.ccompany AND " +
                      "TFACTURAM.cfactura = TFACTURAD.cfactura INNER JOIN " +
                      "TPRODUCTO ON TFACTURAD.cproducto = TPRODUCTO.cproducto INNER JOIN " +
                      "TSICARUBROSD ON TSICARUBROSD.cproducto=TPRODUCTO.cproducto INNER JOIN " +
                      "TSICARUBROSM ON TSICARUBROSD.ccodigorubro=TSICARUBROSM.ccodigorubro AND " +
                      "TSICARUBROSD.cdelete=TSICARUBROSM.cdelete " +
                      "WHERE (TFACTURAM.cguiadesp='" + _P_Str_Guia + "') AND (TFACTURAM.ccompany='" + _P_Str_Comp + "') AND (TSICARUBROSM.cdelete=0)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Dbl_Toneladas = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
            if (_Bol_Fronteriza)
            {
                if (_Dbl_Toneladas >= 5)
                { return 1; }//"Guía de Movilización SADA";
            }
            else
            {
                if (_Dbl_Toneladas >= 5)
                { return 2; }//"Guía de Seguimiento y Control SADA";
            }
            //---------------
            if (_Dbl_Toneladas > 0)
            { return 3; }//"Guía de Despacho al Detal SADA";
            else
            { return 0; }
        }
        private string _Mtd_TipoGuiaSADA(int _P_Int_TipoGuiaSada)
        {
            switch (_P_Int_TipoGuiaSada)
            {
                case 1:
                    return "Guía de Movilización SADA";
                case 2:
                    return "Guía de Seguimiento y Control SADA";
                default:
                    return "Guía de Despacho al Detal SADA";
            }
        }
        private void _Mtd_PrintGuiaDespacho(string _Pr_Str_cguiadesp, string _Pr_Str_cprecarga)
        {
            string _Str_Sql = "";
            string _Str_Filtro = "";
            bool _Bool_ClickOk = false;
            PrintDialog _Print = new PrintDialog();
            DataSet _Ds;
            _Str_Filtro = "cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            if (_Pr_Str_cguiadesp != "")
            {
                _Str_Filtro = _Str_Filtro + " AND cguiadesp='" + _Pr_Str_cguiadesp + "'";
            }
            if (_Pr_Str_cprecarga != "")
            {
                _Str_Filtro = _Str_Filtro + " AND cprecarga='" + _Pr_Str_cprecarga + "'";
            }
            _Str_Filtro += " ORDER BY ccompany,cfactura";
            try
            {
            GoGuiaDesp:

                _Bool_ClickOk = false;
                if (_rutinasImpresion._Mtd_EstaHabilitadoConfiguracionImpresion())
                {
                    PrinterSettings _ObjetoImpresion = null;
                    Clases._Cls_RutinasImpresion._G_TiposDocumento _Tipo = _Cls_RutinasImpresion._G_TiposDocumento.GuiaDespacho;
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

                if (_Bool_ClickOk)
                {
                    Cursor = Cursors.WaitCursor;
                    //_Mtd_CalcularCostoDespacho();
                    //----------------------------------------------
                    bool _Bol_RequiereGuiaSada = _Mtd_RequiereGuiaSada(_Pr_Str_cprecarga);
                    //----------------------------------------------
                    REPORTESS _Frm = new REPORTESS(new string[] { "VST_REPORTEGUIDESPACHO" }, "", "T3.Report.rGuiaDespacho", "Section1", "cabecera", "rif", "nit", _Str_Filtro, _Print, true, _Bol_RequiereGuiaSada);
                    //REPORTESS _Frm = new REPORTESS("T3.Report.rGuiaDespacho", _Mtd_ReporteGuiaDesp(_Pr_Str_cguiadesp, _Pr_Str_cprecarga), _Print, false, "Section1", "cabecera", "rif", "nit");
                    Cursor = Cursors.Default;
                    //_Frm._Mtd_Imprimir(_Print);
                    _Str_Sql = "SELECT cimprimeguiadesp FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_cprecarga + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimprimeguiadesp"]) == "1")
                        {
                            MessageBox.Show("La Relación de Despacho ya fue Impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (MessageBox.Show("Se imprimió correctamente la relación de despacho?", "Verifique", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //_Frm.Close();
                                //_Frm.Dispose();
                                _Str_Sql = "Update TTRANSPORTE set cesperando='0',cocupado=1 where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                //IMPRIMO EL LISTADO DE LAS FACTURAS EMITIDAS
                                string _Str_Cadena = "SELECT DISTINCT ccompany FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_cprecarga + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                                {
                                    if (!_rutinasImpresion._Mtd_EstaHabilitadoConfiguracionImpresion())
                                    {
                                        MessageBox.Show("Se va a imprimir el reporte de facturas impresas de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    _Mtd_PrintFacturasEmitidas(_Pr_Str_cguiadesp, _Pr_Str_cprecarga, _Row[0].ToString().Trim());
                                }
                                bool _Bol_GuiaSada = _Mtd_ActualizacionSADA(_Pr_Str_cguiadesp);
                                _Str_Sql = "UPDATE TPRECARGAM SET cimprimeguiadesp=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_cprecarga + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Tb_Tab.SelectTab(0);
                                //-------------------------
                                if (_Bol_GuiaSada)
                                {
                                    MessageBox.Show("A continuación se mostrará el informe SICA para su impresión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Cursor = Cursors.WaitCursor;
                                    Frm_Inf_SICA _Frm_Sica = new Frm_Inf_SICA(_Pr_Str_cprecarga);
                                    _Frm_Sica.MdiParent = this.MdiParent;
                                    _Frm_Sica.Dock = DockStyle.Fill;
                                    Cursor = Cursors.Default;
                                    _Frm_Sica.Show();
                                    MessageBox.Show(_Mtd_TipoGuiaSADAMensj(_Pr_Str_cguiadesp), "Tipo de Guía SADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                //-------------------------
                            }
                            else
                            {
                                goto GoGuiaDesp;
                            }
                        }
                    }
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }

        }

        private void _Mtd_PrintFacturasEmitidas(string _Pr_Str_cguiadesp, string _Pr_Str_cprecarga, string _P_Str_Comp)
        {
            string _Str_Filtro = "";
            bool _Bool_ClickOk = false;
            PrintDialog _Print = new PrintDialog();

            _Str_Filtro = "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "'";
            if (_Pr_Str_cguiadesp != "")
            {
                _Str_Filtro = _Str_Filtro + " AND cguiadesp='" + _Pr_Str_cguiadesp + "' AND NOT EXISTS(SELECT * FROM TGUIADESPACHOD WHERE cguiadesp<>VST_REPORTE_LISTADOFACTURAS.CGUIADESP AND ccompany=VST_REPORTE_LISTADOFACTURAS.ccompany AND cfactura=VST_REPORTE_LISTADOFACTURAS.cfactura and ccompany='" + _P_Str_Comp + "' and ccompany=VST_REPORTE_LISTADOFACTURAS.ccompany)";
            }
            if (_Pr_Str_cprecarga != "")
            {
                _Str_Filtro = _Str_Filtro + " AND cprecarga='" + _Pr_Str_cprecarga + "'";
            }
            try
            {
            A:

                _Bool_ClickOk = false;
                if (_rutinasImpresion._Mtd_EstaHabilitadoConfiguracionImpresion())
                {
                    PrinterSettings _ObjetoImpresion = null;
                    Clases._Cls_RutinasImpresion._G_TiposDocumento _Tipo = _Cls_RutinasImpresion._G_TiposDocumento.FacturasEmitidas;
                    //Cargo el Objeto que voy a setear enl dialogos segun compañia
                    _ObjetoImpresion = _rutinasImpresion._Mtd_ObjetoImpresion(_Tipo, _P_Str_Comp);
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

                if (_Bool_ClickOk)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "VST_REPORTE_LISTADOFACTURAS" }, "", "T3.Report.rFacturasEmitidas", "Section1", "cabecera", "rif", "nit", _Str_Filtro, _Print, true, _P_Str_Comp);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("Fue impreso correctamente el listado de Facturas emitidas de la empresa " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_P_Str_Comp) + "?", "Verificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        GC.Collect();
                        goto A;
                    }
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }

        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            _Str_Sql = "SELECT cpassw FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use + "' and cpassw='" + cod + "'";
            DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds2.Tables[0].Rows.Count > 0)
            {//COINCIDE
                _Pnl_Clave.Visible = false;
                _Mtd_GenerarFactura();
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta del Solicitante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.Default;
        }

        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            _Bol_FrmTabVer = false;
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Txt_Clave.Focus();
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Lbl_TituloClave.Text = "...";
            }
        }

        private void _Bt_PrintGuiaDesp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Chk_FactImp.Checked)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_GenerarGuiaDespacho();
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("No se puede imprimir la Relación de despacho sin que se halla impreso la factura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (SqlException _Ex)
            {
                MessageBox.Show("Ocurrio un error de conexión, por favor intente de nuevo en unos minutos");
                Cursor = Cursors.Default;
            }
            catch (Exception _Ex)
            {
                MessageBox.Show("Ocurrio el siguiente error : " + _Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_AjustarProgressbar()
        {
            double _Dbl_Kilos = 0;
            double _Dbl_Metros = 0;
            double _Dbl_Monto = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_FacturarFactAImp.Rows)
            {
                if (_Dg_Row.Cells[11].Value != null)
                { _Dbl_Kilos = _Dbl_Kilos + Convert.ToDouble(_Dg_Row.Cells[11].Value); }
                if (_Dg_Row.Cells[12].Value != null)
                { _Dbl_Metros = _Dbl_Metros + Convert.ToDouble(_Dg_Row.Cells[12].Value); }
                if (_Dg_Row.Cells["Monto1"].Value != null)
                { _Dbl_Monto = _Dbl_Monto + Convert.ToDouble(_Dg_Row.Cells["Monto1"].Value); }
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

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Bol_FrmTabVer = true;
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarPreCarga(Convert.ToString(_Dg_FactAImp["cprecarga2", _Dg_FactAImp.CurrentCell.RowIndex].Value));
            _Mtd_CargarFacturasByPrecarga(Convert.ToString(_Dg_FactAImp["cprecarga2", _Dg_FactAImp.CurrentCell.RowIndex].Value));
            _Lbl_TipoPrecarga.Text = _Mtd_DescripcionTipoPrecarga(Convert.ToString(_Dg_FactAImp["cprecarga2", _Dg_FactAImp.CurrentCell.RowIndex].Value));
            _Mtd_AjustarProgressbar();
            _Tb_Tab.SelectTab(1);
            Cursor = Cursors.Default;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarGridPrecargasSinFact();
                _Mtd_CargarGridFactByPrint();
                Cursor = Cursors.Default;
            }
            else if (e.TabPageIndex == 1)
            {
                if (!_Bol_FrmTabVer)
                { e.Cancel = true; }
                else
                {
                    if (_Mtd_VerifFacturaImp())
                    {
                        _Bt_PrintFact.Enabled = false;
                        _Chk_FactImp.Checked = true;
                    }
                    else
                    {
                        _Bt_PrintFact.Enabled = true;
                        _Chk_FactImp.Checked = false;
                    }
                    if (_Txt_PreCargaId.Text != "")
                    {
                        if (_Mtd_VerifGuiaDesp(_Txt_PreCargaId.Text))
                        {
                            _Chk_GuiaDespImp.Checked = true;
                            //_Bt_PrintGuiaDesp.Enabled = false;
                        }
                        else
                        {
                            _Chk_GuiaDespImp.Checked = false;

                        }
                    }
                    else
                    {
                        _Chk_GuiaDespImp.Checked = false;
                    }
                    if (!_Chk_FactImp.Checked)
                    { _Bt_PrintGuiaDesp.Enabled = false; }
                    else
                    { _Bt_PrintGuiaDesp.Enabled = true; }
                    //_Bt_PrintGuiaDesp.Enabled = true;
                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(17);
            _Frm.ShowDialog(this);
            if (_Frm._Str_FrmResult != "")
            {

            }
        }

        private bool _Mtd_VerifFacturaImp()
        {
            int _Int_I = 0;
            bool _Bol_R = false;
            string _Str_Sql = "";
            DataSet _Ds;
            foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
            {
                _Str_Sql = "SELECT c_impresa FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == "1")
                    {
                        _Int_I++;
                    }
                }
            }
            if (_Dg_FacturarFactAImp.Rows.Count > 0)
            {
                if (_Int_I == _Dg_FacturarFactAImp.Rows.Count)
                {
                    _Bol_R = true;
                }
            }
            else
            { _Bol_R = false; }
            return _Bol_R;

        }

        private bool _Mtd_VerifGuiaDesp(string _Pr_Str_Precarga)
        {
            bool _Bol_R = false;
            DataSet _Ds;
            string _Str_Sql = "";
            foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
            {
                _Str_Sql = "SELECT cimprimeguiadesp FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Pr_Str_Precarga + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == "1")
                    {
                        _Bol_R = true;
                    }
                    else
                    {
                        _Bol_R = false;
                        break;
                    }
                }
            }
            return _Bol_R;
        }

        private void _Tb_Tab_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                string _Str_Impreso = "";
                string _Str_Sql = "";
                if (_Txt_PreCargaId.Text != "")
                {
                    _Str_Sql = "SELECT cimprimefactura FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Impreso = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    }
                    if (_Str_Impreso != "1" && _Bt_PrintFact.Enabled)
                    {
                        MessageBox.Show("Tiene pendiente imprimir la factura. Termine el proceso por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
                _Bol_FrmTabVer = false;
            }
        }

        private void _CMen_A_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_PreCargarSFact.SelectedRows.Count == 0;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_FactAImp.SelectedRows.Count == 0;
        }

        private void _Mtd_Verificar_PrefacturasDev()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_FactAImp.Rows)
            {
                if (_Dg_Row.Cells["c_factdevuelta"].Value == null)
                { _Dg_Row.Cells["c_factdevuelta"].Value = "0"; }
                if (_Dg_Row.Cells["c_factdevuelta"].Value.ToString().Trim() == "1")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                else
                { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
            }
        }

        private void _Mtd_Verificar_PrefacturasDev2()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_FacturarFactAImp.Rows)
            {
                if (_Dg_Row.Cells["c_factdevuelta1"].Value == null)
                { _Dg_Row.Cells["c_factdevuelta1"].Value = "0"; }
                if (_Dg_Row.Cells["c_factdevuelta1"].Value.ToString().Trim() == "1")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                else
                { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
            }
        }

        private void _Mtd_CalcularCostoDespacho()
        {
            DataSet _Ds;
            DataSet _Ds_Rutas;
            string _Str_PreFact = "";
            string _Str_Ruta = "";
            string _Str_Sql = "";
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
            double _Dbl_CostoDespacho = 0;
            double _Dbl_CostoVarDespacho = 0;
            double _Dbl_CostoFijoDespacho = 0;
            double _Dbl_MontoSimpRutaDespacho = 0;

            _Str_Sql = "SELECT cidrutdespacho FROM TPRECARGADR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCargaId.Text + "'";
            _Ds_Rutas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_Rutas.Tables[0].Rows)
            {
                _Dbl_MontoSimpRutaDespacho = 0;
                foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                {
                    _Str_Sql = "SELECT cpfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_PreFact = Convert.ToString(_Ds.Tables[0].Rows[0]["cpfactura"]);
                    }
                    _Str_Sql = "SELECT cidrutdespacho FROM VST_PREFACTURASSEGUNRUTAS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim() + "' AND cpfactura='" + _Str_PreFact + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Ruta = Convert.ToString(_Ds.Tables[0].Rows[0]["cidrutdespacho"]);
                    }

                    if (_Str_Ruta == _DRow["cidrutdespacho"].ToString())
                    {
                        _Dbl_MontoSimpRutaDespacho = _Dbl_MontoSimpRutaDespacho + Convert.ToDouble(_DgRow.Cells["Monto1"].Value);
                    }
                }

                if (_Dbl_MontoSimpRutaDespacho != 0)
                {
                    _Str_Sql = "SELECT * FROM TTABULADESPACHO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _DRow["cidrutdespacho"].ToString() + "' AND cdelete='0'";
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
                    }
                }
            }

            _Dbl_CostoVarDespacho = _Dbl_NumVariables + _Dbl_PorcVariables;
            _Dbl_CostoFijoDespacho = _Dbl_NumFijos + _Dbl_PorcFijos;
            _Dbl_CostoDespacho = _Dbl_NumVariables + _Dbl_PorcVariables + _Dbl_NumFijos + _Dbl_PorcFijos;

            _Dbl_FrmCostoVarDespacho = _Dbl_CostoVarDespacho;
            _Dbl_FrmCostoFijoDespacho = _Dbl_CostoFijoDespacho;
            _Dbl_FrmCostoDespacho = _Dbl_CostoDespacho;
        }

        private void Frm_ControlFactura_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_PreCargarSFact_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgPreCargarSFactInfo.Visible = true;
            }
            else
            {
                _Lbl_DgPreCargarSFactInfo.Visible = false;
            }
        }

        private void _Dg_FactAImp_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgFactAImpInfo.Visible = true;
            }
            else
            {
                _Lbl_DgFactAImpInfo.Visible = false;
            }
        }

        private void _Dg_FacturarFactAImp_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgFacturarFactAImpInfo.Visible = true;
            }
            else
            {
                _Lbl_DgFacturarFactAImpInfo.Visible = false;
            }
        }

        private void _Dg_FactAImp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // - -* - - - - *- *-* -*- -* - - - - * -* 

        private void _Mtd_ImprimirFormaParalela(string _P_Str_PreCarga)
        {
            string _Str_Sql = "";
            bool _Bol_PrintAgain = false;
            int _Int_TotFact = 0;
            int _Int_TotFactImp = 0;
            Dictionary<string, bool> _ImprimirDeNuevoCompañia = new Dictionary<string, bool>();

            try
            {
                if (!_Mtd_VerificarImpresionFacturas(_P_Str_PreCarga))
                {

                    //Valido que existan las impresoras
                    if (!_rutinasImpresion._Mtd_ExistenTodasLasImpresorasConfiguradas())
                    {
                        return;
                    }

                ImprimirDeNuevo:
                    if (MessageBox.Show("Están preparadas las impresoras para la impresión de facturas?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }

                    //Variables de trabajo
                    string _Str_ccomapny = "";

                    //Genero los Worker
                    List<BackgroundWorker> _oWorkers = new List<BackgroundWorker>();
                    //Genero los manejadores de completado
                    AutoResetEvent[] _oManejadoresCompletado = new AutoResetEvent[0];
                    //Contador de Hilos;
                    int _Int_ContadorHilos = 0;

                    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - IMPRESION DE FACTURAS  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
                    Cursor = Cursors.WaitCursor;
                    //Original 
                    //string _Str_Cadena = "SELECT DISTINCT ccompany FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "' AND c_impresa='0'";
                    //Para Ordenar por cantidad de detalle de facturas
                    //string _Str_Cadena = "SELECT TFACTURAM.ccompany, COUNT(TFACTURAD.cproducto) AS CantidadFacturas FROM TFACTURAM INNER JOIN TFACTURAD ON TFACTURAM.cgroupcomp = TFACTURAD.cgroupcomp AND TFACTURAM.ccompany = TFACTURAD.ccompany AND TFACTURAM.cfactura = TFACTURAD.cfactura WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.cprecarga = '" + _P_Str_PreCarga + "') AND (TFACTURAM.c_impresa = '0') GROUP BY TFACTURAM.ccompany ORDER BY CantidadFacturas";
				    string _Str_Cadena = "SELECT ccompany, COUNT(cfactura) AS CantidadFactura, SUM(CantidadDetalle) AS CantidadDetalle,  (COUNT(cfactura) * 33) + SUM(CantidadDetalle) AS LineasImpresion FROM (SELECT TFACTURAM.ccompany, dbo.TFACTURAM.cfactura, COUNT(TFACTURAD.cproducto) AS CantidadDetalle FROM TFACTURAM INNER JOIN TFACTURAD ON TFACTURAM.cgroupcomp = TFACTURAD.cgroupcomp 	AND TFACTURAM.ccompany = TFACTURAD.ccompany	AND TFACTURAM.cfactura = TFACTURAD.cfactura WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') 	AND (TFACTURAM.cprecarga = '" + _P_Str_PreCarga + "') 	AND (TFACTURAM.c_impresa = '0') GROUP BY TFACTURAM.ccompany, dbo.TFACTURAM.cfactura ) AS FACTURAS GROUP BY ccompany ORDER BY LineasImpresion";

                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        string _Str_ccompany = _Row["ccompany"].ToString();
                        //Genero el marcador de facturas impresas correctamente por compañia sino existe ya
                        if (!_ImprimirDeNuevoCompañia.ContainsKey(_Str_ccompany))
                        {
                            _ImprimirDeNuevoCompañia.Add(_Str_ccompany, false);
                        }

                        //Si hay que imprimir de nuevo
                        if (_Bol_PrintAgain)
                        {
                            //Si no hay que imprimir la empresa actual
                            if (!_ImprimirDeNuevoCompañia[_Str_ccompany])
                            {
                                //salto el foreach
                                break;
                            }
                        }

                        //Variables de Trabajo
                        string[] _Str_Facturas_ = new string[0];
                        //Genero el Listado de Facturas a Imprimir
                        foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                        {
                            if (Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim().ToUpper() == _Row[0].ToString().Trim().ToUpper())
                            {
                                if (_DgRow.Cells["Marcar"].Value == null)
                                {
                                    _DgRow.Cells["Marcar"].Value = "0";
                                }
                                if (_DgRow.Cells["Marcar"].Value.ToString().Trim() == "0")
                                {
                                    _Str_Facturas_ = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Facturas_, _Str_Facturas_.Length + 1);
                                    _Str_Facturas_[_Str_Facturas_.Length - 1] = Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim();
                                    //--------
                                }
                            }
                        }
                        if (_Bol_PrintAgain)
                        {
                            Frm_ReImprime _Frm_ReImprime = new Frm_ReImprime("FACTURA", _Str_Facturas_, "Re-Impresion de Facturas de la compañía (" + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()) + ")");
                            if (_Frm_ReImprime.ShowDialog() == DialogResult.OK)
                            {
                                _Str_Facturas_ = _Frm_ReImprime._Str_Facturas_R;
                            }
                        }
                        if (_Str_Facturas_.Length > 0)
                        {
                            //Cuento los Hilos
                            _Int_ContadorHilos += 1;

                            //Creo el Manejador de Completado
                            AutoResetEvent _manejadorCompletado = new AutoResetEvent(false);
                            //Redimensiono el arreglo
                            Array.Resize(ref _oManejadoresCompletado, _oManejadoresCompletado.Length + 1);
                            //Guardo el manejador en el arreglo
                            _oManejadoresCompletado[_Int_ContadorHilos - 1] = _manejadorCompletado;

                            //Creo los Parametros
                            ParametrosHilo _parametrosHilo = new ParametrosHilo
                                {
                                    ccompany = _Row["ccompany"].ToString(),
                                    facturas = _Str_Facturas_,
                                    indice = (_Int_ContadorHilos-1),
                                    evento = _manejadorCompletado
                                };
                            //Ejecuto el Hilo
                            ThreadPool.QueueUserWorkItem(new WaitCallback(_Mtd_HiloDeImpresion), _parametrosHilo);
                        }
                    }
                    if (_Int_ContadorHilos > 0)
                    {
                        //Esperamos a que terminen los hilos
                        Thread _oEsperar = new Thread(_Mtd_EsperarTodosLosHilos);
                        _oEsperar.Start(_oManejadoresCompletado);
                        //Ahora espere por este nuevo hilo.
                        _oEsperar.Join();
                    }
                    Cursor = Cursors.Default;

                    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - PREGUNTO SI FUERON IMPRESAS CORRECTAMENTE  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        //Si hay que imprimir de nuevo
                        string _Str_ccompany = _Row["ccompany"].ToString();
                        if (_Bol_PrintAgain)
                        {
                            //Si no hay que imprimir la empresa actual
                            if (!_ImprimirDeNuevoCompañia[_Str_ccompany])
                            {
                                //salto el foreach
                                break;
                            }
                        }
                        //Si llegamos aqui es que la comapañia actual estaba marcada como reimprimir y pregunto
                        if (MessageBox.Show("Fueron impresas correctamente las facturas de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()) + "?", "Verificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string _Str_ComprobId = "";
                            string _Str_CodPrefactura = "", _Str_PedidoId = "";
                            Cursor = Cursors.WaitCursor;
                            _Str_ComprobId = _Mtd_GenerarComprobante(_Row[0].ToString().Trim());
                            Cursor = Cursors.Default;

                            //Marco la compañia para no imprimir
                            _ImprimirDeNuevoCompañia[_Row["ccompany"].ToString()] = false;

                            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - MOVIMIENTO DE INVENTARIO  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
                            //MARCO LAS FACTURAS IMPRESAS
                            Cursor = Cursors.WaitCursor;
                            foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                            {
                                DataSet _Ds2;
                                if (Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim().ToUpper() == _Row[0].ToString().Trim().ToUpper())
                                {
                                    _Str_Sql = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Row[0].ToString().Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "' AND cprecarga='" + _P_Str_PreCarga + "' AND c_impresa<>1";
                                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                                    {
                                        _Str_Sql = "UPDATE TFACTURAM SET c_impresa=1,cidcomprob='" + _Str_ComprobId + "',cdateupd='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Row[0].ToString().Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                    _Str_Sql = "SELECT cpfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Row[0].ToString().Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_Ds2.Tables[0].Rows.Count > 0)
                                    {
                                        _Str_CodPrefactura = _Ds2.Tables[0].Rows[0][0].ToString();
                                    }
                                    _Str_Sql = "UPDATE TPREFACTURAM SET cproceso='F' WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND cpfactura='" + _Str_CodPrefactura + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    _Str_Sql = "SELECT cpedido FROM TPREFACTURAM WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND cpfactura='" + _Str_CodPrefactura + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_Ds2.Tables[0].Rows.Count > 0)
                                    {
                                        _Str_PedidoId = _Ds2.Tables[0].Rows[0][0].ToString();
                                    }
                                    _Str_Sql = "UPDATE TCOTPEDFACM SET cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value) + "',cproceso='F' WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND cpedido='" + _Str_PedidoId + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                            }
                            Cursor = Cursors.Default;

                            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - COMPROBANTE CONTABLE  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
                            _Mtd_ImprimirComprobante(_Str_ComprobId, _Row[0].ToString().Trim());

                            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - IMPRESION LOTE  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
                            Cursor = Cursors.WaitCursor;

                            //Variables de Trabajo
                            string _Str_Filtro = " AND (0=0";
                            //Genero el fILTRO
                            foreach (DataGridViewRow _DgRow in _Dg_FacturarFactAImp.Rows)
                            {
                                if (Convert.ToString(_DgRow.Cells["ccompany2"].Value).Trim().ToUpper() == _Row[0].ToString().Trim().ToUpper())
                                {
                                    if (_DgRow.Cells["Marcar"].Value == null)
                                    {
                                        _DgRow.Cells["Marcar"].Value = "0";
                                    }
                                    if (_DgRow.Cells["Marcar"].Value.ToString().Trim() == "0")
                                    {
                                        _Str_Filtro = _Str_Filtro + " OR cfactura='" + Convert.ToString(_DgRow.Cells["cfactura1"].Value).Trim() + "'";
                                    }
                                }
                            }
                            
                            Frm_ImpresionLote _Frm = new Frm_ImpresionLote(_Str_Filtro, true, _Row[0].ToString().Trim());
                            _Frm.StartPosition = FormStartPosition.CenterScreen;

                            Cursor = Cursors.Default;
                            _Frm.ShowDialog();
                        }
                        else
                        {
                            //Marco la compañia para imprimir
                            _ImprimirDeNuevoCompañia[_Row["ccompany"].ToString()] = true;
                        }
                    }

                    //Verifico si hay algo marcado para imprimir
                    bool _Bol_HayCompaniasMarcadasParaReimprimir = false;
                    foreach (KeyValuePair<string, bool> oCompania in _ImprimirDeNuevoCompañia)
                    {
                        if (oCompania.Value)
                        {
                            _Bol_HayCompaniasMarcadasParaReimprimir = true;
                        }
                    }

                    //Si hay que reimprimir
                    if (_Bol_HayCompaniasMarcadasParaReimprimir)
                    {
                        _Bol_PrintAgain = true;
                        goto ImprimirDeNuevo;
                    }

                    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - SI TODAS LAS FACTURAS ESTAN IMPRESAS MARCO LA PRECARGA  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
                    //VERIFICO QUE TODAS LAS FACTURAS ESTEN IMPRESAS
                    _Str_Sql = "select count(*) from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_TotFact = Convert.ToInt16(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    _Str_Sql = "select count(*) from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "' and c_impresa=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                        {
                            _Int_TotFactImp = Convert.ToInt16(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    if (_Int_TotFact != 0)
                    {
                        if (_Int_TotFact == _Int_TotFactImp)
                        {
                            _Bt_PrintFact.Enabled = false;
                            _Chk_FactImp.Checked = true;
                            _Bt_PrintGuiaDesp.Enabled = true;
                            _Str_Sql = "UPDATE TPRECARGAM SET cimprimefactura=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                    }
                    //// -///-/-----/--/-

                }
                else
                {
                    MessageBox.Show("Las facturas de la Pre-Carga " + _P_Str_PreCarga + " ya fueron impresas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_EsperarTodosLosHilos(object _P_Eventos)
        {
            try
            {
                AutoResetEvent[] _eventos = _P_Eventos as AutoResetEvent[];

                if (_eventos.Length > 0)
                {
                    WaitHandle.WaitAll(_eventos);
                }
            }
            catch (Exception)
            {
            }
        }

        private void _Mtd_HiloDeImpresion(object _P_Argumentos)
        {
            //Variables
            PrinterSettings _ObjetoImpresion = null;
            PrintDialog _My_PrintDialogo = new PrintDialog();

            //Casteo lo parametros
            ParametrosHilo _parametrosWorker = (ParametrosHilo)_P_Argumentos;

            //Imprimo
            //Tipo de Documento a Imprimir
            Clases._Cls_RutinasImpresion._G_TiposDocumento _Tipo = _Cls_RutinasImpresion._G_TiposDocumento.Factura;

            //Obtengo la configuracionsegun la compañia y el tipo de documento
            _ObjetoImpresion = _rutinasImpresion._Mtd_ObjetoImpresion(_Tipo, _parametrosWorker.ccompany);

            //Seto la la configuracion
            _My_PrintDialogo.PrinterSettings = _ObjetoImpresion;

            try
            {
                //Imprimo
                _Mtd_ImprimirFacturas(_parametrosWorker.facturas, _My_PrintDialogo, _parametrosWorker.ccompany);
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message,"Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Seteo el evento a terminado
            _parametrosWorker.evento.Set();
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
    public class ParametrosHilo
    {
        public string ccompany;
        public string[] facturas;
        public int indice;
        public AutoResetEvent evento;
    }
}