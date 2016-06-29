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
    public partial class Frm_NotaEntrega : Form
    {
        bool _Bol_Tabs = false;
        public Frm_NotaEntrega()
        {
            InitializeComponent();
            _Mtd_Load(false);
        }
        public Frm_NotaEntrega(bool _P_Bol_Tabs)
        {
            InitializeComponent();
            _Mtd_Load(true);
            _Bol_Tabs = true;
        }
        public Frm_NotaEntrega(string _P_Str_NE)
        {
            InitializeComponent();
            _Mtd_Load(false);
            _Mtd_Cargar(_P_Str_NE);
            _Mtd_CargarDetalle(_P_Str_NE);
        }

        string _Str_Sql_Lista = "";
        Control[] _Ctrl_Controles = new Control[0];
        string _Str_MyProceso = "";
        string[] _Str_CamposFiltro = new string[3];
        string[] _Str_CamposFiltroType = new string[3];
        string[] _Str_CamposFiltroName = new string[4];
        string[] _Str_CamposFiltroStyle = new string[3];
        string _Str_Proveedor = "";
        private void _Mtd_Cargar(string _Pr_Str_NEId)
        {
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select * from VST_NOTAENTREGM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotentrega=" + _Pr_Str_NEId);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_NE.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidnotentrega"]);
                _Txt_FechNE.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfechanotentrega"]);
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctiponotentrega"])=="A")
                {_Txt_TNE.Text = Convert.ToString("Devolución en Mercancía").ToUpper(); }
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctiponotentrega"]) == "B")
                { _Txt_TNE.Text = Convert.ToString("Devolución de Mercancia mal estado").ToUpper();}
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctiponotentrega"]) == "C")
                { _Txt_TNE.Text = Convert.ToString("Consumo Interno").ToUpper(); }
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctiponotentrega"]) == "O")
                { _Txt_TNE.Text = Convert.ToString("Otros").ToUpper(); }
                _Txt_TpoDoc.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctipodocumentname"]);
                _Txt_Doc.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumdocu"]);
                _Txt_Proveedor.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["c_nomb_abreviado"]);
                _Str_Proveedor = _Ds_Data.Tables[0].Rows[0]["cproveedor"].ToString();
                _Tb_Tab.SelectedIndex = 1;
            }
            _Ds_Data = null;
        }

        private void _Mtd_CargarDetalle(string _Pr_Str_NEId)
        {
            object[] _Str_RowNew = new object[4];
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select DISTINCT cproducto as Producto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_NOTAENTREGD.cproducto) as Descripción,cempaques as Cajas,dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cmontoinvendi) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(cmontototal) as Total from VST_NOTAENTREGD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotentrega=" + _Pr_Str_NEId);
            _Dg_Detalle.DataSource = _Ds_Data.Tables[0];
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Load(bool _P_Bol_Tabs)
        {
            //-------------------------------------------------------
            _Str_CamposFiltro[0] = "cidnotentrega";
            _Str_CamposFiltro[1] = "cfechanotentrega";
            _Str_CamposFiltro[2] = "c_nomb_comer";
            //-------------------------------------------------------
            _Str_CamposFiltroName[0] = "Nº Nota Entrega";
            _Str_CamposFiltroName[1] = "Fecha de Emisión";
            _Str_CamposFiltroName[2] = "Proveedor";
            _Str_CamposFiltroName[3] = "Todos";
            //-------------------------------------------------------
            _Str_CamposFiltroType[0] = "varchar";
            _Str_CamposFiltroType[1] = "datetime";
            _Str_CamposFiltroType[2] = "varchar";
            //-------------------------------------------------------
            _Str_CamposFiltroStyle[0] = "F";
            _Str_CamposFiltroStyle[1] = "R";
            _Str_CamposFiltroStyle[2] = "L";
            //-------------------------------------------------------
            _Str_Sql_Lista = "SELECT cproveedor,c_nomb_comer from TPROVEEDOR WHERE cdelete='0'";
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Id");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cidnotentrega";
            string _Str_Cadena = "Select cidnotentrega as [Id],CONVERT(VARCHAR,cfechanotentrega,3) as [Fecha],c_nomb_comer as [Proveedor],dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(ctotaldocu) as Total from VST_NOTAENTREGM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Entrega", _Tsm_Menu, _Dg_Grid, _Str_CamposFiltro, _Str_CamposFiltroName, _Str_CamposFiltroType, _Str_CamposFiltroStyle, _Str_Sql_Lista);
            //___________________________________
            if (_P_Bol_Tabs)
            {
                _Mtd_CargarFind("Select cidnotentrega as [Id],CONVERT(VARCHAR,cfechanotentrega,3) as [Fecha],c_nomb_comer as [Proveedor],dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(ctotaldocu) as Total from VST_NOTAENTREGM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0' and cimpresa='0'");
            }
            else
            {
                _Mtd_CargarFind("Select cidnotentrega as [Id],CONVERT(VARCHAR,cfechanotentrega,3) as [Fecha],c_nomb_comer as [Proveedor],dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(ctotaldocu) as Total from VST_NOTAENTREGM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0'");
            }
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void Frm_NotaEntrega_Load(object sender, EventArgs e)
        {

        }
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                if (MessageBox.Show("Esta seguro de imprimir la NE# " + _Txt_NE.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para la impresión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_NotaEntrega_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Formato = "Select cidnotentrega as [Id],CONVERT(VARCHAR,cfechanotentrega,3) as [Fecha],c_nomb_comer as [Proveedor],dbo.Fnc_Formatear(cmontosi) AS [Monto] from VST_NOTAENTREGM";
            CONTROLES._Ctrl_Buscar._Str_Where_Vista_Grid = "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0'";
            //-------------------------------------------------------
            _Str_CamposFiltro[0] = "cidnotentrega";
            _Str_CamposFiltro[1] = "cfechanotentrega";
            _Str_CamposFiltro[2] = "c_nomb_comer";
            //-------------------------------------------------------
            _Str_CamposFiltroName[0] = "Nº Nota Entrega";
            _Str_CamposFiltroName[1] = "Fecha de Emisión";
            _Str_CamposFiltroName[2] = "Proveedor";
            _Str_CamposFiltroName[3] = "Todos";
            //-------------------------------------------------------
            _Str_CamposFiltroType[0] = "varchar";
            _Str_CamposFiltroType[1] = "datetime";
            _Str_CamposFiltroType[2] = "varchar";
            //-------------------------------------------------------
            _Str_CamposFiltroStyle[0] = "F";
            _Str_CamposFiltroStyle[1] = "R";
            _Str_CamposFiltroStyle[2] = "L";
            //-------------------------------------------------------
            _Str_Sql_Lista = "SELECT cproveedor,c_nomb_comer from TPROVEEDOR WHERE cdelete='0'";
            CONTROLES._Ctrl_Buscar._Str_FindSql_Lista = _Str_Sql_Lista;
            CONTROLES._Ctrl_Buscar._Dg_Datagrid = _Dg_Grid;
            CONTROLES._Ctrl_Buscar._Str_CamposFiltro = _Str_CamposFiltro;
            CONTROLES._Ctrl_Buscar._Str_CamposFiltroName = _Str_CamposFiltroName;
            CONTROLES._Ctrl_Buscar._Str_CamposFiltroType = _Str_CamposFiltroType;
            CONTROLES._Ctrl_Buscar._Str_CamposFiltroStyle = _Str_CamposFiltroStyle;
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_NotaEntrega_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Mtd_CargarFind(string _Pr_Str_Sql)
        {
            _Dg_Grid.DataSource = null;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Pr_Str_Sql);
            _Dg_Grid.DataSource = _Ds_Data.Tables[0];
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_Sorted();
        }
        private void _Mtd_CargarFind1(string _Pr_Str_Sql)
        {
            _Dg_Grid.DataSource = null;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Pr_Str_Sql);
            _Dg_Grid.DataSource = _Ds_Data.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_Sorted();
        }
        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //**************************************
        private void _Mtd_BotonesMenu()
        {
            if (_Str_MyProceso == "A")
            { CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NF,MF,GT,EF,AF,CT"; }
            if (_Str_MyProceso == "M")
            { CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GT,EF,AF,CT"; }
            if (_Str_MyProceso == "")
            {
                if (_Txt_NE.Text != "")
                { CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GF,ET,AT,CT"; }
                else
                { CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GF,EF,AT,CT"; }
            }
        }

        public void _Mtd_Ini()
        {
            _Txt_NE.Text = "";
            _Txt_FechNE.Text = "";
            _Txt_TNE.Text = "";
            _Txt_TpoDoc.Text = "";
            _Txt_Doc.Text = "";
            _Txt_Proveedor.Text = "";
            _Dg_Detalle.ReadOnly = true;
            _Dg_Detalle.AllowUserToAddRows = false;
            _Dg_Detalle.Rows.Clear();
            if (_Bol_Tabs)
            {
                _Mtd_CargarFind("Select cidnotentrega as [Id],CONVERT(VARCHAR,cfechanotentrega,3) as [Fecha],c_nomb_comer as [Proveedor],dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(ctotaldocu) as Total from VST_NOTAENTREGM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0' and cimpresa='0'");
            }
            else
            {
                _Mtd_CargarFind("Select cidnotentrega as [Id],CONVERT(VARCHAR,cfechanotentrega,3) as [Fecha],c_nomb_comer as [Proveedor],dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cporcinvendible) as Invendible,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(ctotaldocu) as Total from VST_NOTAENTREGM where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cdelete='0'");
            }
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NF,MF,GF,EF,AT,CT";
        }
        private void _Mtd_Imprimir()
        {
            try
            {
                string _Str_Cadena = "select cimpresa from TNOTAENTREGM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotentrega='" + _Txt_NE.Text + "' and cproveedor='" + _Str_Proveedor + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Ds2.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        PrintDialog _Print = new PrintDialog();
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            _Txt_Clave.Text = "";
                            _Pnl_Clave.Visible = false;
                            Cursor = Cursors.WaitCursor;
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_REPORTENOTAENTREGA" }, "", "T3.Report.rNotaEntrega", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotentrega='" + _Txt_NE.Text + "' and cproveedor='" + _Str_Proveedor + "'", _Print, true);
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                            A:
                                string _Str_Numero = InputBox.Show("Introduzca el número de control").Text;
                                if (_Str_Numero.Trim().Length > 0)
                                {
                                    _Str_Cadena = "Select * from TNOTAENTREGM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cnumcontrolne='" + _Str_Numero + "'";
                                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                                    {
                                        if (MessageBox.Show("El número de control del documento ya fue registrado. ¿Desea intentarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            goto A;
                                        }
                                    }
                                    else
                                    {
                                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTAENTREGM", "cimpresa='1',cnumcontrolne='" + _Str_Numero + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotentrega='" + _Txt_NE.Text + "' and cproveedor='" + _Str_Proveedor + "'");
                                        _Str_Cadena = "Select ciddevcomp from TNOTAENTREGM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotentrega='" + _Txt_NE.Text.Trim() + "'";
                                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                        if (_Ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() != "0")
                                            {
                                                _Str_Cadena = "Select ctipodevol from TDEVCOMPRAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ciddevcomp='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "' and cproveedor='" + _Str_Proveedor + "'";
                                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                                if (_Ds.Tables[0].Rows.Count > 0)
                                                {
                                                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "B")
                                                    {
                                                        _Mtd_Generar_AjusteSalida();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
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
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                        MessageBox.Show("La NE ya fue impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        REPORTESS _Frm = new REPORTESS(new string[] { "VST_REPORTENOTAENTREGA" }, "", "T3.Report.rNotaEntrega", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotentrega='" + _Txt_NE.Text + "' and cproveedor='" + _Str_Proveedor + "'");
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.crystalReportViewer1.ShowPrintButton = false;
                        _Frm.Show();
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cajustsal FROM TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cajustsal  DESC";
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
        private void _Mtd_Generar_AjusteSalida()
        {
           string _Str_ID = _Mtd_Entrada().ToString();
            string _Str_Cadena = "";
            string _Str_ciddevcomp = "";
            DataSet _DsM=new DataSet();
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            _Str_Cadena = "Select cproducto,cempaques,cunidades,ciddevcomp from TNOTAENTREGD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotentrega='" + _Txt_NE.Text.Trim() + "'";
            _DsM = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _DsM.Tables[0].Rows)
            {
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Cajas = 0;
                double _Dbl_Unidades = 0;
                double _Dbl_ccostobruto_u1 = 0;
                double _Dbl_ccostobruto_u2 = 0;
                double _Dbl_ccostoneto_u1 = 0;
                double _Dbl_ccostoneto_u2 = 0;
                _Str_ciddevcomp = _Row[3].ToString();
                _Str_Cadena = "Select cproveedor,cgrupo,csku,csubgrupo,ccostoneto_u1,ccostobruto_u1,ccostoneto_u2,ccostobruto_u2 from TPRODUCTO where cproducto='" + _Row[0].ToString() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0]["ccostobruto_u1"] != System.DBNull.Value)
                    { _Dbl_ccostobruto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u1"].ToString()); }
                    else { _Dbl_ccostobruto_u1 = 0; }
                    if (_Ds.Tables[0].Rows[0]["ccostobruto_u2"] != System.DBNull.Value)
                    { _Dbl_ccostobruto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u2"].ToString()); }
                    else { _Dbl_ccostobruto_u2 = 0; }
                    if (_Ds.Tables[0].Rows[0]["ccostoneto_u1"] != System.DBNull.Value)
                    { _Dbl_ccostoneto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString()); }
                    else { _Dbl_ccostoneto_u1 = 0; }
                    if (_Ds.Tables[0].Rows[0]["ccostoneto_u2"] != System.DBNull.Value)
                    { _Dbl_ccostoneto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u2"].ToString()); }
                    else { _Dbl_ccostoneto_u2 = 0; }
                    if (_Row[1] != System.DBNull.Value)
                    { _Dbl_Cajas = Convert.ToDouble(_Row[1].ToString()); }
                    else
                    { _Dbl_Cajas = 0; }
                    if (_Row[2] != System.DBNull.Value)
                    { _Dbl_Unidades = Convert.ToDouble(_Row[2].ToString()); }
                    else
                    { _Dbl_Unidades = 0; }
                    _Dbl_CostoCajas = _Dbl_Cajas * _Dbl_ccostobruto_u1;
                    _Dbl_CostoUnidades = _Dbl_Unidades * _Dbl_ccostobruto_u2;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); }
                        else { _Dbl_Impuesto = 0; }
                    }
                    else
                    { _Dbl_Impuesto = 0; }
                    _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                    _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                    _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas + _Dbl_CostoUnidades);
                    _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + (_Dbl_ImpuestoCajas + _Dbl_ImpuestoUnidades);
                    DataRow _Row2 = _Ds.Tables[0].Rows[0];
                    _Str_Cadena = "Insert into TAJUSSALD (ccompany,cajustsal,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _Str_ID.Trim() + "','" + _Row2["cproveedor"].ToString() + "','" + _Row2["cgrupo"].ToString() + "','" + _Row2["csubgrupo"].ToString() + "','" + _Row2["csku"].ToString() + "','" + _Row[0].ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u2) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u2) + "','" + _Dbl_Cajas.ToString() + "','" + _Dbl_Unidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoUnidades) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoUnidades) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            string _Str_Motivo="";
            _Str_Cadena = "Select cidmotivo from TDEVCOMPRAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ciddevcomp='" + _Str_ciddevcomp + "' and cproveedor='" + _Str_Proveedor + "'";
            _DsM = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_DsM.Tables[0].Rows.Count > 0)
            { _Str_Motivo = _DsM.Tables[0].Rows[0][0].ToString(); }
            _Str_Cadena = "Insert into TAJUSSALC (ccompany,cajustsal,cname,cidmotivo,cyearacco,cmontacco,cdateajus,ccosttotsimp,cvalorimp,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _Str_ID.Trim() + "','DEVOLUCIÓN','" + _Str_Motivo + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSSALC Set cejecutada='1', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustsal='" + _Str_ID.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Cargar(Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
            _Mtd_CargarDetalle(Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
            _Txt_Monto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
            _Txt_Invendible.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex);
            _Txt_Impuesto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex);
            _Txt_Total.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex);
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NF,MF,GF,EF,AT,CT";
            Cursor = Cursors.Default;
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
                _Mtd_Imprimir();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
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
    }
}

