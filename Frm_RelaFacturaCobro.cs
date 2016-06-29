using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace T3
{
    public partial class Frm_RelaFacturaCobro : Form
    {
        public Frm_RelaFacturaCobro()
        {
            InitializeComponent();
            Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_InicioRela));
            _Thr_Thread.Start();                           // Ejecutamos el subproceso
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread);
            _Frm_Form.MdiParent = this.MdiParent;
            _Frm_Form.ShowDialog(this);     // Mostramos el formulario de forma modal.
            _Frm_Form.Dispose();
        }
        private void _Mtd_InicioRela()
        {
            _Mtd_CargarCombos();
            _Mtd_CargarComboCredito();
            _Mtd_CargarComboVendedor();
            _Mtd_FacturasRelaCobro("", false, "", "");
            _Mtd_ActualizarEnManosVendedor("", false);
            _Mtd_ActualizarEnManosCredito("", false);
        }
        private void Frm_RelaFacturaCobro_Load(object sender, EventArgs e)
        {

        }
        string _Str_SentenciaSQL;
        DataSet _DS_DataSet = new DataSet();
        private void _Mtd_CargarComboCredito()
        {                        
            CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
            //_Str_SentenciaSQL = "select distinct cvendedor,rtrim(cname) as cname from VST_T3_FACTURASALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and c_enmanosempre='1'";
            
            //_Str_SentenciaSQL = "select distinct CVENDEDOR,rtrim(CVENDEDOR)+' - '+rtrim(cname) as cname from VST_T3_FACTURASALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and c_enmanosempre='1'";            
            _Str_SentenciaSQL = "EXEC PA_FACTURASALCOBROVENDEDORES '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "',1,0,0";
            //_Str_SentenciaSQL = "select cvendedor,CVENDEDOR+' - '+rtrim(cname) as cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend=1 AND c_activo='1' order by cvendedor";                 
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            _Cls_Varios._Mtd_CargarCombo(_Cmb_VendedorFMC, _DS_DataSet, "cname", "cvendedor");
            _Str_SentenciaSQL = "EXEC PA_DIARUTAALCOBRO '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "',1,0,0";
            //_Str_SentenciaSQL = "select distinct cdiaruta from VST_DIARUTAALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and c_enmanosempre='1'";
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            _Cls_Varios._Mtd_CargarCombo(_Cmb_RutaDiaFMC, _DS_DataSet, "cdiaruta", "cdiaruta");
        }
        private void _Mtd_CargarComboVendedor()
        {
            CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
            //_Str_SentenciaSQL = "select distinct cvendedor,rtrim(cname) as cname from VST_T3_FACTURASALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and c_enmanosvende='1'";
            //_Str_SentenciaSQL = "select distinct CVENDEDOR,rtrim(CVENDEDOR)+' - '+rtrim(cname) as cname from VST_T3_FACTURASALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and c_enmanosvende='1'";
            _Str_SentenciaSQL = "EXEC PA_FACTURASALCOBROVENDEDORES '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "',0,1,0";
            //_Str_SentenciaSQL = "select cvendedor,CVENDEDOR+' - '+rtrim(cname) as cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend=1 AND c_activo='1' order by cvendedor";                 
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            _Cls_Varios._Mtd_CargarCombo(_Cmb_VendedorFMV, _DS_DataSet, "cname", "cvendedor");
            //_Str_SentenciaSQL = "select distinct cdiaruta from VST_DIARUTAALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and c_enmanosvende='1'";
            _Str_SentenciaSQL = "EXEC PA_DIARUTAALCOBRO '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "',0,1,0";
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            _Cls_Varios._Mtd_CargarCombo(_Cmb_DiaRutaFMV, _DS_DataSet, "cdiaruta", "cdiaruta");
        }
        private void _Mtd_CargarCombos()
        {
            try
            {
                CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
                //_Str_SentenciaSQL = "select distinct cvendedor,rtrim(cname) as cname from VST_VENDEDORESDOCSALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and cfacturarela is null";
                //Antes/////_Str_SentenciaSQL = "select distinct cvendedor,CVENDEDOR+' - '+rtrim(cname) as cname from VST_VENDEDORESDOCSALCOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and cfacturarela=0";                 
                //_Str_SentenciaSQL = "select cvendedor,CVENDEDOR+' - '+rtrim(cname) as cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend=1 AND c_activo='1' order by cvendedor";                 
                _Str_SentenciaSQL = "SELECT DISTINCT cvendedor,cvendedor+' - '+rtrim(cname) as cname FROM dbo.VST_VENDEDORCHEQALCOBRO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cfacturarela,0)=0";
                _Str_SentenciaSQL += " UNION ";
                _Str_SentenciaSQL += "SELECT DISTINCT cvendedor,cvendedor+' - '+rtrim(cname) as cname FROM dbo.VTS_VENDEDORFACTALCOBRO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cfacturarela,0)=0";
                _Str_SentenciaSQL += " UNION ";
                _Str_SentenciaSQL += "SELECT DISTINCT cvendedor,cvendedor+' - '+rtrim(cname) as cname FROM dbo.VST_VENDEDORNCALCOBRO  WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cfacturarela,0)=0";
                _Str_SentenciaSQL += " UNION ";
                _Str_SentenciaSQL += "SELECT DISTINCT cvendedor,cvendedor+' - '+rtrim(cname) as cname FROM dbo.VST_VENDEDORNDALCOBRO  WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cfacturarela,0)=0";

                _DS_DataSet=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_Vendedor, _DS_DataSet, "cname", "cvendedor");
                _Str_SentenciaSQL = "select distinct cguiadesp from VST_GUIADESPALCOBRO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfacturarela is null";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_Guia, _DS_DataSet, "cguiadesp", "cguiadesp");
                _Str_SentenciaSQL = "EXEC PA_DIARUTAALCOBRO '" + Frm_Padre._Str_Comp + "','"+Frm_Padre._Str_GroupComp+"',NULL,NULL,NULL";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_DiaRuta, _DS_DataSet, "CDIARUTA", "CDIARUTA");               
            }
            catch
            {
            }
        }
        private void _Mtd_FacturasRelaCobro(string _P_Str_SentenciaSQL,bool _Bol_Filter, string _P_Str_Tabla, string _P_Str_Filtros)
        {
            try
            {
                //SqlParameter[] _SQL_PARAMETRO = new SqlParameter[1];
                //_SQL_PARAMETRO[0] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                //_SQL_PARAMETRO[0].Value = Frm_Padre._Str_Comp;
                //CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_CONSULTFACTURALCOBRO", _SQL_PARAMETRO);
                if (_Bol_Filter)
                {
                    _Str_SentenciaSQL = _P_Str_SentenciaSQL;
                    _Ctrl_Page1._Int_R = 0;
                    _Ctrl_Page1._Mtd_Inicializar(_Str_SentenciaSQL, _Dtg_FacturasalCobro, _P_Str_Tabla, _P_Str_Filtros, 100, "ORDER BY ccliente", "ccliente", "SP_PAGINCONSULTFACT");
                }
                else
                {
                    _Str_SentenciaSQL = "select VST_T3_FACTURASALCOBRO.cguiadesp,VST_T3_FACTURASALCOBRO.cnumdocu,VST_T3_FACTURASALCOBRO.ctipodocument,VST_T3_FACTURASALCOBRO.cliente,VST_T3_FACTURASALCOBRO.vendedor,c_fechaentrega,VST_T3_FACTURASALCOBRO.c_montotot_si_bs,VST_T3_FACTURASALCOBRO.c_impuesto_bs,VST_T3_FACTURASALCOBRO.ctotal,TABLA.RUTA AS cdiaruta from VST_T3_FACTURASALCOBRO " +
                    " LEFT OUTER JOIN DBO.FNC_PROXRUTACLIENTETABLA('"+Frm_Padre._Str_Comp+"','"+Frm_Padre._Str_GroupComp+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"') AS TABLA ON "+
                    "  VST_T3_FACTURASALCOBRO.ccliente=TABLA.CCLIENTE AND " +
                     " VST_T3_FACTURASALCOBRO.cvendedor COLLATE DATABASE_DEFAULT=TABLA.cvendedor COLLATE DATABASE_DEFAULT AND " +
                     " VST_T3_FACTURASALCOBRO.CCOMPANY COLLATE DATABASE_DEFAULT=TABLA.CCOMPANY COLLATE DATABASE_DEFAULT " +
                    " where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.cfacturarela=0 order by VST_T3_FACTURASALCOBRO.ctipodocument asc";
                    _Ctrl_Page1._Int_R = 0;
                    _Ctrl_Page1._Mtd_Inicializar(_Str_SentenciaSQL, _Dtg_FacturasalCobro, "VST_T3_FACTURASALCOBRO", "where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.cfacturarela=0", 25, "ORDER BY VST_T3_FACTURASALCOBRO.ccliente", "VST_T3_FACTURASALCOBRO.CCOMPANY", "SP_PAGINCONSULTFACT");
                }
                //_DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                //_DS_DataSet = CLASES._Cls_Varios_Metodos._Mtd_ConsultasSP("SP_CONSULTFACTURALCOBRO", _SQL_PARAMETRO);
                //string _Str_FindSql = "Select top ?sel ccliente AS Código, RTRIM(ccliente_nombcomer) AS Cliente, c_estatus_cob_descrip AS Estatus, c_rif, c_clientesigesod AS [Cod.Sigeco] FROM VST_CLIENTE WHERE NOT ccliente IN (select top ?omi ccliente from VST_CLIENTE WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')) and cdelete=0";

                //_Dtg_FacturasalCobro.DataSource = _DS_DataSet.Tables[0].DefaultView;
                _Dtg_FacturasalCobro.Columns[0].ReadOnly = false;
                _Dtg_FacturasalCobro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                for (int i = 1; i <= 10; i++)
                {
                    _Dtg_FacturasalCobro.Columns[i].ReadOnly = true;
                }
            }
            catch
            {
            }
        }
        string[] _Str_Array=new string[0];
        private void _Dtg_FacturasalCobro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_Dtg_FacturasalCobro[0, e.RowIndex].Value != null)
                    {
                        if (_Dtg_FacturasalCobro[0, e.RowIndex].Value.ToString() == "1")
                        {
                            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, _Str_Array.Length + 1);
                            _Str_Array[_Str_Array.Length - 1] = _Dtg_FacturasalCobro[3, e.RowIndex].Value.ToString().TrimEnd() + "|" + _Dtg_FacturasalCobro[2, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            int _Int_Index = Array.IndexOf(_Str_Array, _Dtg_FacturasalCobro[3, e.RowIndex].Value.ToString().TrimEnd() + "|" + _Dtg_FacturasalCobro[2, e.RowIndex].Value.ToString());
                            Array.Clear(_Str_Array, _Int_Index, 1);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void _Mtd_ActualizarEnManosCredito(string _P_Str_SentenciaSQL, bool _Bol_Filter)
        {
            try
            {
                _Dtg_ManosAreaCredito.CellValueChanged -= new DataGridViewCellEventHandler(_Dtg_ManosAreaCredito_CellValueChanged);
                if (_Bol_Filter)
                {
                    _Str_SentenciaSQL = _P_Str_SentenciaSQL;
                }
                else
                {
                    _Str_SentenciaSQL = "select VST_T3_FACTURASALCOBRO.cnumdocu,VST_T3_FACTURASALCOBRO.ctipodocument,VST_T3_FACTURASALCOBRO.cliente,VST_T3_FACTURASALCOBRO.vendedor,c_fechaentrega,VST_T3_FACTURASALCOBRO.c_montotot_si_bs,VST_T3_FACTURASALCOBRO.c_impuesto_bs,VST_T3_FACTURASALCOBRO.ctotal,TABLA.RUTA AS cdiaruta,VST_T3_FACTURASALCOBRO.ccliente,VST_T3_FACTURASALCOBRO.c_nomb_comer from VST_T3_FACTURASALCOBRO " +
                    " LEFT OUTER JOIN DBO.FNC_PROXRUTACLIENTETABLA('"+Frm_Padre._Str_Comp+"','"+Frm_Padre._Str_GroupComp+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"') AS TABLA ON "+
                    "  VST_T3_FACTURASALCOBRO.ccliente=TABLA.CCLIENTE AND " +
                     " VST_T3_FACTURASALCOBRO.cvendedor COLLATE DATABASE_DEFAULT=TABLA.cvendedor COLLATE DATABASE_DEFAULT AND " +
                     " VST_T3_FACTURASALCOBRO.CCOMPANY COLLATE DATABASE_DEFAULT=TABLA.CCOMPANY COLLATE DATABASE_DEFAULT " +
                    "  where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.c_enmanosempre='1' order by VST_T3_FACTURASALCOBRO.ctipodocument asc";
                }
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Dtg_ManosAreaCredito.DataSource = _DS_DataSet.Tables[0].DefaultView;
                _Dtg_ManosAreaCredito.Columns[0].ReadOnly = false;
                _Dtg_ManosAreaCredito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                for (int i = 1; i <= 9; i++)
                {
                    _Dtg_ManosAreaCredito.Columns[i].ReadOnly = true;
                }
                _Dtg_ManosAreaCredito.CellValueChanged += new DataGridViewCellEventHandler(_Dtg_ManosAreaCredito_CellValueChanged);
            }
            catch
            {
            }
        }
        private void _Mtd_ActualizarEnManosVendedor(string _P_Str_SentenciaSQL, bool _Bol_Filter)
        {
            try
            {
                if (_Bol_Filter)
                {
                    _Str_SentenciaSQL = _P_Str_SentenciaSQL;
                }
                else
                {
                    _Str_SentenciaSQL = "select VST_T3_FACTURASALCOBRO.cnumdocu,VST_T3_FACTURASALCOBRO.ctipodocument,VST_T3_FACTURASALCOBRO.cliente,VST_T3_FACTURASALCOBRO.vendedor,VST_T3_FACTURASALCOBRO.c_fechaentrega,VST_T3_FACTURASALCOBRO.c_montotot_si_bs,VST_T3_FACTURASALCOBRO.c_impuesto_bs,VST_T3_FACTURASALCOBRO.ctotal,TABLA.RUTA AS cdiaruta,VST_T3_FACTURASALCOBRO.ccliente,VST_T3_FACTURASALCOBRO.c_nomb_comer from VST_T3_FACTURASALCOBRO " +
                     " LEFT OUTER JOIN DBO.FNC_PROXRUTACLIENTETABLA('"+Frm_Padre._Str_Comp+"','"+Frm_Padre._Str_GroupComp+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"') AS TABLA ON "+
                    "  VST_T3_FACTURASALCOBRO.ccliente=TABLA.CCLIENTE AND " +
                     " VST_T3_FACTURASALCOBRO.cvendedor COLLATE DATABASE_DEFAULT=TABLA.cvendedor COLLATE DATABASE_DEFAULT AND " +
                     " VST_T3_FACTURASALCOBRO.CCOMPANY COLLATE DATABASE_DEFAULT=TABLA.CCOMPANY COLLATE DATABASE_DEFAULT " +
                    " where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.c_enmanosvende='1' order by VST_T3_FACTURASALCOBRO.ctipodocument asc";
                }
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Dtg_FactAmanosVendedor.DataSource = _DS_DataSet.Tables[0].DefaultView;
                _Dtg_FactAmanosVendedor.Columns[0].ReadOnly = false;
                _Dtg_FactAmanosVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                for (int i = 1; i <= 9; i++)
                {
                    _Dtg_FactAmanosVendedor.Columns[i].ReadOnly = true;
                }
            }
            catch
            {
            }
        }
        private string _Mtd_TipoDoc(string _Str_Tipo)
        {
            string _Str_TipoDoc = "";
            _Str_SentenciaSQL = "select ctipdocfact,ctipdocnotdeb,ctipdoccheqdev,ctipdocnotcred from TCONFIGCXC  where ccompany='" + Frm_Padre._Str_Comp + "'";
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            foreach (DataRow _Dtw_Item in _DS_DataSet.Tables[0].Rows)
            {
                if (_Str_Tipo == "FACT")
                {
                    _Str_TipoDoc = _Dtw_Item["ctipdocfact"].ToString();
                }
                else if (_Str_Tipo == "N/D")
                {
                    _Str_TipoDoc = _Dtw_Item["ctipdocnotdeb"].ToString();
                }
                else if (_Str_Tipo == "CHQDEV")
                {
                    _Str_TipoDoc = _Dtw_Item["ctipdoccheqdev"].ToString();
                }
                else if (_Str_Tipo == "N/C")
                {
                    _Str_TipoDoc = _Dtw_Item["ctipdocnotcred"].ToString();
                }
            }
            return _Str_TipoDoc;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                bool _Bol_Valido = true;
                if (_Str_Array.Length > 0)
                {
                    foreach (string _Str_String in _Str_Array)
                    {
                        if (_Str_String == null)
                        {
                        }
                        else
                        {
                            string[] _Str_Doc = _Str_String.Split('|');
                            if (_Str_Doc.Length > 0)
                            {
                                _Bol_Valido = false;
                                if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select cnumdocu,ctipodocument from TFACTURELACOBRO where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Str_Doc[1] + "' and ctipodocument='" + _Str_Doc[0] + "'"))
                                {
                                    string _Str_GuiaDespacho = "0";
                                    if (_Str_Doc[0] == _Mtd_TipoDoc("FACT"))
                                    {
                                        _Str_SentenciaSQL = "select cguiadesp from TFACTURAM WHERE CFACTURA='" + _Str_Doc[1] + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                                        _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                        if (_DS_DataSet.Tables[0].Rows.Count > 0)
                                        {
                                            _Str_GuiaDespacho = _DS_DataSet.Tables[0].Rows[0][0].ToString();
                                        }
                                    }
                                    _Str_SentenciaSQL = "insert into TFACTURELACOBRO(cgroupcomp,ccompany,cguiadesp,cnumdocu,ctipodocument,c_imprelacobro,c_enmanosvende,c_enmanosempre) ";
                                    _Str_SentenciaSQL += "values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_GuiaDespacho + "','" + _Str_Doc[1] + "','" + _Str_Doc[0] + "','0','0','1')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                                }
                            }
                        }
                    }
                    if (_Bol_Valido)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Debe seleccionar al menos una factura para continuar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
                    }
                    else
                    {
                        _Mtd_ActualizarEnManosCredito("", false);
                        _Mtd_FacturasRelaCobro("",false,"","");
                        _Mtd_CargarComboCredito();
                        _Mtd_CargarComboVendedor();
                        tabControl1.SelectedIndex = 0;
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Debe seleccionar al menos un documento para continuar","Validación",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch
            {
                Cursor = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _Bol_Reporte = true;
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                this._Pnl_Clave.Visible = true;
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            }
            catch
            {
                Cursor = Cursors.Default;
            }
        }
        bool _Bol_Reporte = true;        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _Bol_Reporte = false;
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                this._Pnl_Clave.Visible = true;
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2); 
            }
            catch
            {
                Cursor = Cursors.Default;
            }
        }
        private void _Mtd_Ini()
        {
            try
            {
                _Cmb_VendedorFMV.SelectedIndex = 0;
                _Cmb_VendedorFMC.SelectedIndex = 0;
                _Cmb_Vendedor.SelectedIndex = 0;
                _Cmb_Guia.SelectedIndex = 0;
                _Cmb_RutaDiaFMC.SelectedIndex = 0;
                _Cmb_DiaRuta.SelectedIndex = 0;
                _Cmb_DiaRutaFMV.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Ini();
            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            //_Mtd_FacturasRelaCobro();
            _Ctrl_Page1._Mtd_Inicializar("1");
            _Mtd_FacturasRelaCobro("", false, "", "");
            _Mtd_ActualizarEnManosCredito("", false);
            _Mtd_ActualizarEnManosVendedor("", false);
            Cursor = Cursors.Default;
        }

        private void _Btn_Filtro_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            string _Str_Where = "";
            if (_Cmb_Vendedor.SelectedIndex > 0)
            {
                _Str_Where += " and VST_T3_FACTURASALCOBRO.cvendedor='" + _Cmb_Vendedor.SelectedValue + "'";
            }
            if (_Cmb_Guia.SelectedIndex > 0)
            {
                _Str_Where += " and VST_T3_FACTURASALCOBRO.cguiadesp='" + _Cmb_Guia.SelectedValue + "'";
            }
            if (_Cmb_DiaRuta.SelectedIndex > 0)
            {
                _Str_Where += " and TABLA.RUTA='" + _Cmb_DiaRuta.SelectedValue + "'";
            }
            _Ctrl_Page1._Mtd_Inicializar("", true);
            _Str_SentenciaSQL = "select VST_T3_FACTURASALCOBRO.cguiadesp,VST_T3_FACTURASALCOBRO.cnumdocu,VST_T3_FACTURASALCOBRO.ctipodocument,VST_T3_FACTURASALCOBRO.cliente,VST_T3_FACTURASALCOBRO.vendedor,VST_T3_FACTURASALCOBRO.c_fechaentrega,VST_T3_FACTURASALCOBRO.c_montotot_si_bs,VST_T3_FACTURASALCOBRO.c_impuesto_bs,VST_T3_FACTURASALCOBRO.ctotal,TABLA.RUTA as cdiaruta from VST_T3_FACTURASALCOBRO " +
            " LEFT OUTER JOIN DBO.FNC_PROXRUTACLIENTETABLA('" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "') AS TABLA ON " +
                   "  VST_T3_FACTURASALCOBRO.ccliente=TABLA.CCLIENTE AND " +
                    " VST_T3_FACTURASALCOBRO.cvendedor COLLATE DATABASE_DEFAULT=TABLA.cvendedor COLLATE DATABASE_DEFAULT AND " +
                    " VST_T3_FACTURASALCOBRO.CCOMPANY COLLATE DATABASE_DEFAULT=TABLA.CCOMPANY COLLATE DATABASE_DEFAULT " +
                    " where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.cfacturarela=0" + _Str_Where + " order by VST_T3_FACTURASALCOBRO.ctipodocument asc";
            _Mtd_FacturasRelaCobro(_Str_SentenciaSQL, true, "VST_T3_FACTURASALCOBRO", "where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.cfacturarela is null" + _Str_Where);
            Cursor = Cursors.Default;
        }

        private void _Btn_FiltroFMC_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Where = "";
                if (_Cmb_VendedorFMC.SelectedIndex > 0)
                {
                    _Str_Where += " and VST_T3_FACTURASALCOBRO.cvendedor='" + _Cmb_VendedorFMC.SelectedValue + "'";
                }
                if (_Cmb_RutaDiaFMC.SelectedIndex > 0)
                {
                    _Str_Where += " and TABLA.RUTA='" + _Cmb_RutaDiaFMC.SelectedValue + "'";
                }
                _Str_SentenciaSQL = "select VST_T3_FACTURASALCOBRO.cnumdocu,VST_T3_FACTURASALCOBRO.ctipodocument,VST_T3_FACTURASALCOBRO.cliente,VST_T3_FACTURASALCOBRO.vendedor,VST_T3_FACTURASALCOBRO.c_fechaentrega,VST_T3_FACTURASALCOBRO.c_montotot_si_bs,VST_T3_FACTURASALCOBRO.c_impuesto_bs,VST_T3_FACTURASALCOBRO.ctotal,TABLA.RUTA AS cdiaruta,VST_T3_FACTURASALCOBRO.ccliente,VST_T3_FACTURASALCOBRO.c_nomb_comer from VST_T3_FACTURASALCOBRO " +
                " LEFT OUTER JOIN DBO.FNC_PROXRUTACLIENTETABLA('" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "') AS TABLA ON " +
                   "  VST_T3_FACTURASALCOBRO.ccliente=TABLA.CCLIENTE AND " +
                    " VST_T3_FACTURASALCOBRO.cvendedor COLLATE DATABASE_DEFAULT=TABLA.cvendedor COLLATE DATABASE_DEFAULT AND " +
                    " VST_T3_FACTURASALCOBRO.CCOMPANY COLLATE DATABASE_DEFAULT=TABLA.CCOMPANY COLLATE DATABASE_DEFAULT " +
                    " where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.c_enmanosempre='1'" + _Str_Where + " order by VST_T3_FACTURASALCOBRO.ctipodocument asc";
                _Mtd_ActualizarEnManosCredito(_Str_SentenciaSQL, true);
                Cursor = Cursors.Default;
            }
            catch
            {
            }
        }

        private void _Btn_FiltroFMV_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Where = "";
                if (_Cmb_VendedorFMV.SelectedIndex > 0)
                {
                    _Str_Where += " and VST_T3_FACTURASALCOBRO.cvendedor='" + _Cmb_VendedorFMV.SelectedValue + "'";
                }
                if (_Cmb_DiaRutaFMV.SelectedIndex > 0)
                {
                    _Str_Where += " and TABLA.RUTA='" + _Cmb_DiaRutaFMV.SelectedValue + "'";
                }
                _Str_SentenciaSQL = "select VST_T3_FACTURASALCOBRO.cnumdocu,VST_T3_FACTURASALCOBRO.ctipodocument,VST_T3_FACTURASALCOBRO.cliente,VST_T3_FACTURASALCOBRO.vendedor,VST_T3_FACTURASALCOBRO.c_fechaentrega,VST_T3_FACTURASALCOBRO.c_montotot_si_bs,VST_T3_FACTURASALCOBRO.c_impuesto_bs,VST_T3_FACTURASALCOBRO.ctotal,TABLA.RUTA AS cdiaruta,VST_T3_FACTURASALCOBRO.ccliente,VST_T3_FACTURASALCOBRO.c_nomb_comer from VST_T3_FACTURASALCOBRO " +
                " LEFT OUTER JOIN DBO.FNC_PROXRUTACLIENTETABLA('" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "') AS TABLA ON " +
                  "  VST_T3_FACTURASALCOBRO.ccliente=TABLA.CCLIENTE AND " +
                   " VST_T3_FACTURASALCOBRO.cvendedor COLLATE DATABASE_DEFAULT=TABLA.cvendedor COLLATE DATABASE_DEFAULT AND " +
                   " VST_T3_FACTURASALCOBRO.CCOMPANY COLLATE DATABASE_DEFAULT=TABLA.CCOMPANY COLLATE DATABASE_DEFAULT " +
                   " where VST_T3_FACTURASALCOBRO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_T3_FACTURASALCOBRO.c_enmanosvende='1'" + _Str_Where + " order by VST_T3_FACTURASALCOBRO.ctipodocument asc";
                _Mtd_ActualizarEnManosVendedor(_Str_SentenciaSQL, true);
                Cursor = Cursors.Default;
            }
            catch
            {
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            if (_Pnl_Clave.Visible)
            {
                tabControl1.Enabled = false;
                panel2.Enabled = false;
                _Dtg_FacturasalCobro.Enabled = false;
                _Ctrl_Page1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
                panel2.Enabled = true;
                _Dtg_FacturasalCobro.Enabled = true;
                _Ctrl_Page1.Enabled = true;
            }
        }
        private void _Mtd_Imprimir()
        {

            try
            {
                DataTable _Dta_Tabla = new DataTable("Relacion");
                DataColumn _Dta_Columna;
                DataRow _Dta_Fila;
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "cnumdocu";
                _Dta_Columna.ReadOnly = true;
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "ctipodocument";
                _Dta_Columna.ReadOnly = true;
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "ccliente";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "c_nomb_comer";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "c_fechaentrega";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.Double");
                _Dta_Columna.ColumnName = "c_montotot_si_bs";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.Double");
                _Dta_Columna.ColumnName = "c_impuesto_bs";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.Double");
                _Dta_Columna.ColumnName = "ctotal";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "cdiaruta";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                _Dta_Columna = new DataColumn();
                _Dta_Columna.DataType = System.Type.GetType("System.String");
                _Dta_Columna.ColumnName = "cvendedor";
                _Dta_Tabla.Columns.Add(_Dta_Columna);
                foreach (DataGridViewRow _Dtg_Row in _Dtg_ManosAreaCredito.Rows)
                {
                    if (_Dtg_Row.Cells[0].Value != null)
                    {
                        if (_Dtg_Row.Cells[0].Value.ToString() == "1")
                        {
                            _Dta_Fila = _Dta_Tabla.NewRow();
                            _Dta_Fila["cnumdocu"] = _Dtg_Row.Cells[1].Value.ToString();
                            string _StrTipoDoc = "";
                            if (_Dtg_Row.Cells[2].Value.ToString().TrimEnd() == _Mtd_TipoDoc("FACT"))
                            {
                                _StrTipoDoc = "FACTURA";
                            }
                            if (_Dtg_Row.Cells[2].Value.ToString().TrimEnd() == _Mtd_TipoDoc("N/D"))
                            {
                                _StrTipoDoc = "NOTA DEBITO";
                            }
                            if (_Dtg_Row.Cells[2].Value.ToString().TrimEnd() == _Mtd_TipoDoc("N/C"))
                            {
                                _StrTipoDoc = "NOTA CRÉDITO";
                            }
                            if (_Dtg_Row.Cells[2].Value.ToString().TrimEnd() == _Mtd_TipoDoc("CHQDEV"))
                            {
                                _StrTipoDoc = "CHEQUE DEVUELTO";
                            }
                            _Dta_Fila["ctipodocument"] = _StrTipoDoc;
                            _Dta_Fila["ccliente"] = _Dtg_Row.Cells[10].Value.ToString();
                            _Dta_Fila["c_nomb_comer"] = _Dtg_Row.Cells[11].Value.ToString();
                            _Dta_Fila["c_fechaentrega"] = _Dtg_Row.Cells[5].Value.ToString();
                            if (_StrTipoDoc == "NOTA CRÉDITO")
                            {
                                _Dta_Fila["c_montotot_si_bs"] = Convert.ToString(Convert.ToDouble(_Dtg_Row.Cells[6].Value.ToString())*(-1));
                                _Dta_Fila["c_impuesto_bs"] = Convert.ToString(Convert.ToDouble(_Dtg_Row.Cells[7].Value.ToString()) * (-1));
                                _Dta_Fila["ctotal"] = Convert.ToString(Convert.ToDouble(_Dtg_Row.Cells[8].Value.ToString()) * (-1));
                            }
                            else
                            {
                                _Dta_Fila["c_montotot_si_bs"] = _Dtg_Row.Cells[6].Value.ToString();
                                _Dta_Fila["c_impuesto_bs"] = _Dtg_Row.Cells[7].Value.ToString();
                                _Dta_Fila["ctotal"] = _Dtg_Row.Cells[8].Value.ToString();
                            }                            
                            
                            _Dta_Fila["cdiaruta"] = _Dtg_Row.Cells[9].Value.ToString();
                            _Dta_Fila["cvendedor"] = _Dtg_Row.Cells[4].Value.ToString();
                            _Dta_Tabla.Rows.Add(_Dta_Fila);
                        }
                    }
                }
                if (_Dta_Tabla.Rows.Count > 0)
                {
                Imprimir:
                    PrintDialog _Print = new PrintDialog();
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rRelacionFacturas", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                        _Frm_Reporte.Show();
                        if (MessageBox.Show("¿Se imprimió correctamente la relación de documentos?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Cursor = Cursors.WaitCursor;
                            foreach (DataGridViewRow _Dtg_Row in _Dtg_ManosAreaCredito.Rows)
                            {
                                if (_Dtg_Row.Cells[0].Value != null)
                                {
                                    if (_Dtg_Row.Cells[0].Value.ToString() == "1")
                                    {
                                        _Str_SentenciaSQL = "update TFACTURELACOBRO SET c_enmanosvende='1', c_enmanosempre='0',c_imprelacobro='1' WHERE cnumdocu='" + _Dtg_Row.Cells[1].Value.ToString() + "' and ctipodocument='" + _Dtg_Row.Cells[2].Value.ToString() + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                                    }
                                }
                            }
                            _Mtd_ActualizarEnManosCredito("", false);
                            _Mtd_ActualizarEnManosVendedor("", false);
                            tabControl1.SelectedIndex = 1;
                            _Mtd_CargarComboCredito();
                            _Mtd_CargarComboVendedor();
                            _Pnl_Clave.Visible = false;
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            goto Imprimir;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al menos una factura para continuar");
                }
            }
            catch (Exception _Ex)
            { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            CLASES._Cls_Varios_Metodos _Cls_Varios=new T3.CLASES._Cls_Varios_Metodos(true);
            if (_Cls_Varios._Mtd_VerificarClaveUsuario(_Txt_Clave.Text))
            {
                if (_Bol_Reporte)
                {
                    _Mtd_Imprimir();                    
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    foreach (DataGridViewRow _Dtg_Row in _Dtg_FactAmanosVendedor.Rows)
                    {
                        if (_Dtg_Row.Cells[0].Value != null)
                        {
                            if (_Dtg_Row.Cells[0].Value.ToString() == "1")
                            {
                                _Str_SentenciaSQL = "update TFACTURELACOBRO SET c_enmanosvende='0', c_enmanosempre='1',c_imprelacobro='0' WHERE cnumdocu='" + _Dtg_Row.Cells[1].Value.ToString() + "' and ctipodocument='" + _Dtg_Row.Cells[2].Value.ToString() + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                            }
                        }
                    }
                    _Pnl_Clave.Visible = false;
                    _Mtd_ActualizarEnManosCredito("", false);
                    _Mtd_ActualizarEnManosVendedor("", false);
                    tabControl1.SelectedIndex = 0;
                    _Mtd_CargarComboCredito();
                    _Mtd_CargarComboVendedor();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
           _Pnl_Clave.Visible = false;
        }

        private void _Dtg_FacturasalCobro_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow _Dtg_Item in _Dtg_FacturasalCobro.Rows)
                {
                    int _Int_Index = Array.IndexOf(_Str_Array, _Dtg_Item.Cells[3].Value.ToString().TrimEnd() + "|" + _Dtg_Item.Cells[2].Value.ToString());
                    if (_Int_Index != -1)
                    {
                        _Dtg_Item.Cells[0].Value = 1;
                    }
                    else
                    {
                        _Dtg_Item.Cells[0].Value = 0;
                    }
                }
            }
            catch
            {
            }
        }

        private void Frm_RelaFacturaCobro_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_RelaFacturaCobro_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dtg_ManosAreaCredito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        bool _Bol_VendedorSelec;
        private void _Dtg_ManosAreaCredito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string _Str_Vendedor = "";
                foreach (DataGridViewRow _Dtg_Item in _Dtg_ManosAreaCredito.Rows)
                {
                    if (_Dtg_Item.Cells[0].Value != null)
                    {
                        if (_Dtg_Item.Cells[0].Value.ToString() == "1")
                        {
                            string[] _Str_Vendedor_ = _Dtg_Item.Cells[4].Value.ToString().Split('-');
                            if (_Str_Vendedor == "")
                            {
                                _Str_Vendedor = _Str_Vendedor_[0].TrimEnd();
                            }
                            else
                            {
                                if (_Str_Vendedor == _Str_Vendedor_[0].TrimEnd())
                                {

                                }
                                else
                                {
                                    _Dtg_ManosAreaCredito[0, e.RowIndex].Value = "0";
                                    MessageBox.Show("Solo puede seleccionar documentos de 1 solo vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    _Bol_VendedorSelec = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_FacturasalCobro.CurrentCell != null)
            {
                _Dtg_FacturasalCobro[0, _Dtg_FacturasalCobro.CurrentCell.RowIndex].Value = "1";
            }
            _Dtg_FacturasalCobro.EndEdit();
        }

        private void seleccionarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_FacturasalCobro.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_FacturasalCobro.Rows)
                {
                    _Dtg_Fila.Cells[0].Value = "1";
                    _Dtg_FacturasalCobro.EndEdit();
                    int _Int_Index = Array.IndexOf(_Str_Array, _Dtg_Fila.Cells[3].Value.ToString().TrimEnd() + "|" + _Dtg_Fila.Cells[2].Value.ToString());
                    if (_Int_Index != -1)
                    {
                        //_Dtg_Item.Cells[0].Value = 1;
                    }
                    else
                    {
                        _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, _Str_Array.Length + 1);
                        _Str_Array[_Str_Array.Length - 1] = _Dtg_Fila.Cells[3].Value.ToString().TrimEnd() + "|" + _Dtg_Fila.Cells[2].Value.ToString();
                    }                    
                }
            }
        }

        private void eliminarSelecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_FacturasalCobro.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_FacturasalCobro.Rows)
                {
                    _Dtg_Fila.Cells[0].Value = "0";
                    _Dtg_FacturasalCobro.EndEdit();                    
                }
                _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            }
        }

        private void seleccionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Dtg_ManosAreaCredito.CurrentCell != null)
            {
                _Dtg_ManosAreaCredito[0, _Dtg_ManosAreaCredito.CurrentCell.RowIndex].Value = "1";
                _Dtg_ManosAreaCredito.EndEdit();
            }
        }

        private void seleccionarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Bol_VendedorSelec = false;
            string _Str_Vendedor = "";
            if (_Dtg_ManosAreaCredito.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_ManosAreaCredito.Rows)
                {
                    _Dtg_Fila.Cells[0].Value = "1";
                    _Dtg_ManosAreaCredito.EndEdit();
                    if (_Bol_VendedorSelec)
                    {
                        break;
                    }
                }
            }
        }

        private void eliminarSelecciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Dtg_ManosAreaCredito.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_ManosAreaCredito.Rows)
                {
                    _Dtg_Fila.Cells[0].Value = "0";
                    _Dtg_ManosAreaCredito.EndEdit();
                }
            }
        }

        private void eliminarTodasLasSeleccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_FactAmanosVendedor.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_FactAmanosVendedor.Rows)
                {
                    _Dtg_Fila.Cells[0].Value = "0";
                    _Dtg_FactAmanosVendedor.EndEdit();
                }
            }
        }

        private void seleccionarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_Dtg_FactAmanosVendedor.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_FactAmanosVendedor.Rows)
                {
                    _Dtg_Fila.Cells[0].Value = "1";
                    _Dtg_FactAmanosVendedor.EndEdit();
                }
            }
        }

        private void selecciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_FactAmanosVendedor.CurrentCell != null)
            {
                _Dtg_FactAmanosVendedor[0, _Dtg_FactAmanosVendedor.CurrentCell.RowIndex].Value = "1";
                _Dtg_FactAmanosVendedor.EndEdit();
            }
        }
    }
}