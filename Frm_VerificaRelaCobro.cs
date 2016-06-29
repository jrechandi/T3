using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_VerificaRelaCobro : Form
    {
        string _Str_Vendedor = "";
        public Frm_VerificaRelaCobro()
        {
            InitializeComponent();
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar();
        }
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select convert(varchar, cfecharela,103) as cfecharela,cidrelacobro,cnamevendedor,cobservaciones,cvendedor,ctipocobro from VST_RELACIONCOBM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and crelalista='1' and caprobado='0' and cdelete='0' Order By cidrelacobro,cfecharela DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
        private void Frm_VerificaRelaCobro_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Clave.Visible = false;
        }

        private void _Tool_Actualizar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }
        private DataSet _Mtd_Crear_DataSets()
        {
            DataSet _Ds = new DataSet();
            _Ds.Tables.Add("Tabla");
            _Ds.Tables[0].Columns.Add("Cliente", typeof(string));
            _Ds.Tables[0].Columns.Add("Fecha", typeof(string));
            _Ds.Tables[0].Columns.Add("Tipo", typeof(string));
            _Ds.Tables[0].Columns.Add("Nº Documento", typeof(string));
            _Ds.Tables[0].Columns.Add("Monto", typeof(string));
            _Ds.Tables[0].Columns.Add("NC", typeof(string));
            _Ds.Tables[0].Columns.Add("Desc. P.P.", typeof(string));
            _Ds.Tables[0].Columns.Add("Otros Desc.", typeof(string));
            _Ds.Tables[0].Columns.Add("Neto Cobrado", typeof(string));
            return _Ds;
        }
        private DataView _Mtd_LlenarDataSets(string _P_Str_Relacion)
        {
            string _Str_Factura = "";
            string _Str_NotaCredito = "";
            string _Str_CheqDev = "";
            DataSet _DsRet = _Mtd_Crear_DataSets();
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "Select ctipdocfact,ctipdocnotcred,ctipdoccheqdev from TCONFINCRED where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Factura = _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString();
                _Str_NotaCredito = _Ds.Tables[0].Rows[0]["ctipdocnotcred"].ToString();
                _Str_CheqDev = _Ds.Tables[0].Rows[0]["ctipdoccheqdev"].ToString();
            }

            _Str_Cadena = "Select RTRIM(c_nomb_comer) AS c_nomb_comer,cfechadocu,ctipodocument,cname,cnumdocu,'0',cdesctopp,cdescotros,cmontocancel from VST_RELACIONCOBD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "'";
            DataSet _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Ob = new object[9];
            foreach (DataRow _Row in _Ds_Temp.Tables[0].Rows)
            {
                _Ob[0] = _Row["c_nomb_comer"].ToString();
                _Ob[1] = _Row["cfechadocu"].ToString();
                _Ob[2] = _Row["cname"].ToString();
                _Ob[3] = _Row["cnumdocu"].ToString();
                if (_Row["ctipodocument"].ToString().Trim() == _Str_Factura.Trim().ToUpper())
                {
                    _Str_Cadena = "Select  dbo.Fnc_Formatear(c_montotot_si_bs) from TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + _Row["cnumdocu"].ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {_Ob[4] = _Ds.Tables[0].Rows[0][0].ToString(); }
                    }
                }
                else if (_Row["ctipodocument"].ToString().Trim() == _Str_NotaCredito.Trim().ToUpper())
                {
                    _Str_Cadena = "Select  dbo.Fnc_Formatear(cmontototsi) from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Row["cnumdocu"].ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Ob[4] = _Ds.Tables[0].Rows[0][0].ToString(); }
                    }
                }
                else if (_Row["ctipodocument"].ToString().Trim().ToUpper() == _Str_CheqDev.Trim().ToUpper())
                {
                    _Str_Cadena = "Select  dbo.Fnc_Formatear(cmontochequ) from TCHEQDEVUELT where ccompany='" + Frm_Padre._Str_Comp + "' and cidcheqdevuelt='" + _Row["cnumdocu"].ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Ob[4] = _Ds.Tables[0].Rows[0][0].ToString(); }
                    }
                }
                _Str_Cadena = "Select cnotacred1,cnotacred2,cnotacred3,cnotacred4,cnotacred5,cnotacred6,cnotacred7,cnotacred8,cnotacred9,cnotacred10 from TRELACCOBD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                double _Dbl_NC = 0;
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataSet _Ds_Cred = new DataSet();
                    foreach (DataColumn _Col in _Ds.Tables[0].Columns)
                    {
                        if (_Ds.Tables[0].Rows[0][_Col] != System.DBNull.Value)
                        {
                            _Str_Cadena = "Select ctotaldocu from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Ds.Tables[0].Rows[0][_Col].ToString() + "'";
                            _Ds_Cred = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_Cred.Tables[0].Rows.Count > 0)
                            {
                                if (_Ds_Cred.Tables[0].Rows[0][0] != System.DBNull.Value)
                                {
                                    _Dbl_NC = _Dbl_NC + Convert.ToDouble(_Ds_Cred.Tables[0].Rows[0][0].ToString());
                                }
                            }
                        }
                    }
                }
                _Ob[5] = _Dbl_NC.ToString("##,#0.00");
                _Ob[6] = _Row["cdesctopp"].ToString();
                _Ob[7] = _Row["cdescotros"].ToString();
                _Ob[8] = _Row["cmontocancel"].ToString();
                _DsRet.Tables[0].Rows.Add(_Ob);
            }
            DataView _View = new DataView(_DsRet.Tables[0]);
            _View.Sort = "Fecha DESC";
            return _View;
        }
        private void _Mtd_LlenarDetalle(string _P_Str_Relacion)
        {
            if (_Dg_Detalle.Rows.Count == 0)
            { _Txt_TotalDoc.Text = "0"; }
            else
            { _Txt_TotalDoc.Text = _Dg_Detalle.Rows.Count.ToString(); }
            double _Dbl_TotalNC = 0;
            double _Dbl_TotalDescPP = 0;
            double _Dbl_TotalDescOtros = 0;
            double _Dbl_TotalNeto = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                if (_Dg_Row.Cells["NC"].Value != null)
                { _Dbl_TotalNC = _Dbl_TotalNC + Convert.ToDouble(_Dg_Row.Cells["NC"].Value); }
                if (_Dg_Row.Cells["DescP"].Value != null)
                { _Dbl_TotalDescPP = _Dbl_TotalDescPP + Convert.ToDouble(_Dg_Row.Cells["DescP"].Value); }
                if (_Dg_Row.Cells["Otros"].Value != null)
                { _Dbl_TotalDescOtros = _Dbl_TotalDescOtros + Convert.ToDouble(_Dg_Row.Cells["Otros"].Value); }
                if (_Dg_Row.Cells["Neto"].Value != null)
                { _Dbl_TotalNeto = _Dbl_TotalNeto + Convert.ToDouble(_Dg_Row.Cells["Neto"].Value); }
            }
            _Txt_TotalNc.Text = _Dbl_TotalNC.ToString("#,##0.00");
            _Txt_TotalDesc.Text = _Dbl_TotalDescPP.ToString("#,##0.00");
            _Txt_TotalOtros.Text = _Dbl_TotalDescOtros.ToString("#,##0.00");
            _Txt_TotalNeto.Text = _Dbl_TotalNeto.ToString("#,##0.00");
            _Txt_DepBs.Text = "0";
            _Txt_CheqDiaBs.Text = "0";
            _Txt_CheqTranBs.Text = "0";
            _Txt_TransBs.Text = "0";
            _Txt_TarjCredBs.Text = "0";
            double _Dbl_Acumulado = 0;
            string _Str_Cadena = "Select COUNT(*) AS Numero, dbo.Fnc_Formatear(SUM(cmontodepo)) AS Monto from TRELACCOBDDEPM where cgroupcompany='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { _Txt_DepNum.Text = _Ds.Tables[0].Rows[0][0].ToString(); } else { _Txt_DepNum.Text = "0"; }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value) { _Txt_DepBs.Text = _Ds.Tables[0].Rows[0][1].ToString(); _Dbl_Acumulado = _Dbl_Acumulado + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); } else { _Txt_DepBs.Text = "0"; }
            }
            _Str_Cadena = "Select COUNT(*) AS Numero, dbo.Fnc_Formatear(SUM(cmontocheq)) AS Monto from TRELACCOBDCHEQ where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "' and ccheqdiatransito='D'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { _Txt_CheqDiaNum.Text = _Ds.Tables[0].Rows[0][0].ToString(); } else { _Txt_CheqDiaNum.Text = "0"; }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value) { _Txt_CheqDiaBs.Text = _Ds.Tables[0].Rows[0][1].ToString(); _Dbl_Acumulado = _Dbl_Acumulado + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); } else { _Txt_CheqDiaBs.Text = "0"; }
            }
            _Str_Cadena = "Select COUNT(*) AS Numero, dbo.Fnc_Formatear(SUM(cmontocheq)) AS Monto from TRELACCOBDCHEQ where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "' and ccheqdiatransito='T'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { _Txt_CheqTranNum.Text = _Ds.Tables[0].Rows[0][0].ToString(); } else { _Txt_CheqTranNum.Text = "0"; }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value) { _Txt_CheqTranBs.Text = _Ds.Tables[0].Rows[0][1].ToString(); _Dbl_Acumulado = _Dbl_Acumulado + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); } else { _Txt_CheqTranBs.Text = "0"; }
            }
            _Str_Cadena = "Select COUNT(*) AS Numero, dbo.Fnc_Formatear(SUM(cmontotransacc)) AS Monto from TRELACCOBDTB where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { _Txt_TransNum.Text = _Ds.Tables[0].Rows[0][0].ToString(); } else { _Txt_TransNum.Text = "0"; }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value) { _Txt_TransBs.Text = _Ds.Tables[0].Rows[0][1].ToString(); _Dbl_Acumulado = _Dbl_Acumulado + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); } else { _Txt_TransBs.Text = "0"; }
            }
            _Str_Cadena = "Select COUNT(*) AS Numero, dbo.Fnc_Formatear(SUM(cmontocancel)) AS Monto from TRELACCOBDTC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _P_Str_Relacion + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value) { _Txt_TarjCredNum.Text = _Ds.Tables[0].Rows[0][0].ToString(); } else { _Txt_TarjCredNum.Text = "0"; }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value) { _Txt_TarjCredBs.Text = _Ds.Tables[0].Rows[0][1].ToString(); _Dbl_Acumulado = _Dbl_Acumulado + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString()); } else { _Txt_TarjCredBs.Text = "0"; }
            }
            double _Dbl_Sobrante = _Dbl_Acumulado - _Dbl_TotalNeto;
            _Txt_Sobrante.Text = _Dbl_Sobrante.ToString("#,##0.00");
            _Txt_Total.Text = Convert.ToDouble(_Dbl_Acumulado + _Dbl_Sobrante).ToString("#,##0.00");
            try
            {
                DateTime[] _Dtm = _Mtd_MesActual();
                if (_Dtm[0] == _Dtm[1])
                {
                    _Str_Cadena = "Select dbo.Fnc_Formatear(SUM(cmontocancel)) from TRELACCOBM INNER JOIN " +
"TRELACCOBD ON TRELACCOBM.cgroupcomp = TRELACCOBD.cgroupcomp AND TRELACCOBM.ccompany = TRELACCOBD.ccompany AND " +
"TRELACCOBM.cidrelacobro = TRELACCOBD.cidrelacobro where TRELACCOBM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRELACCOBM.ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Str_Vendedor + "' and convert(varchar, cfecharela,103)='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm[0]) + "'";
                }
                else
                {
                    _Str_Cadena = "Select dbo.Fnc_Formatear(SUM(cmontocancel)) from TRELACCOBM INNER JOIN " +
                "TRELACCOBD ON TRELACCOBM.cgroupcomp = TRELACCOBD.cgroupcomp AND TRELACCOBM.ccompany = TRELACCOBD.ccompany AND " +
                "TRELACCOBM.cidrelacobro = TRELACCOBD.cidrelacobro where TRELACCOBM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRELACCOBM.ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Str_Vendedor + "' and cfecharela between '" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm[0]) + "' and '" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm[1]) + "'";
                }
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Txt_TotalAcum.Text = _Ds.Tables[0].Rows[0][0].ToString(); }
                else
                { _Txt_TotalAcum.Text = "0"; }
            }
            catch { }
        }
        private DateTime[] _Mtd_MesActual()
        {
            DateTime[] _Dtm = new DateTime[2];
            string _Str_Cadena = "";
            _Str_Cadena = "select convert(varchar,cdiafecha,103) as cdiafecha from TCALENDVTA WHERE " + _Mtd_Exists() + " and canocalend='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "' and cmesubicado ='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString() + "' order by convert(datetime,cdiafecha) asc";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_DiaI = "";
            string _Str_DiaF = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaI = _Ds.Tables[0].Rows[0]["cdiafecha"].ToString();  _Dtm[0] = Convert.ToDateTime(_Str_DiaI); }
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_DiaF = _Ds.Tables[0].Rows[_Ds.Tables[0].Rows.Count - 1]["cdiafecha"].ToString(); _Dtm[1] = Convert.ToDateTime(_Str_DiaF).AddDays(1); }
            return _Dtm;
        }
        private string _Mtd_Exists()
        {
            return "(NOT EXISTS  (SELECT * FROM TCALENDVTAEX WHERE CONVERT(varchar, TCALENDVTAEX.cdia, 103) = CONVERT(varchar, TCALENDVTA.cdiafecha, 103) AND TCALENDVTAEX.ccompany='" + Frm_Padre._Str_Comp + "'))";
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Txt_Relacion.Text = _Dg_Grid.Rows[e.RowIndex].Cells["cidrelacobro"].Value.ToString();
                _Txt_Vendedor.Text = _Dg_Grid.Rows[e.RowIndex].Cells["cnamevendedor"].Value.ToString().Trim();
                _Str_Vendedor = _Dg_Grid.Rows[e.RowIndex].Cells["cvendedor"].Value.ToString();
                _Txt_Observaciones.Text = _Dg_Grid.Rows[e.RowIndex].Cells["cobservaciones"].Value.ToString().Trim();
                _Txt_Fecha.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cfecharela"].Value);
                
                string _Str_Cadena = "Select cnamegrupo,ccaja,cidcomprob from VST_RELACIONCOBM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _Dg_Grid.Rows[e.RowIndex].Cells["cidrelacobro"].Value + "' and cvendedor='" + _Dg_Grid.Rows[e.RowIndex].Cells["cvendedor"].Value + "' and ctipocobro='" + _Dg_Grid.Rows[e.RowIndex].Cells["ctipocobro"].Value + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Grupo.Text = _Ds.Tables[0].Rows[0]["cnamegrupo"].ToString();
                    _Txt_Caja.Text = _Ds.Tables[0].Rows[0]["ccaja"].ToString().Trim();
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cidcomprob"]) != "")
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cidcomprob"]) != "0")
                        {
                            _Bt_Aprobar.Enabled = false;
                        }
                        else
                        {
                            _Bt_Aprobar.Enabled = true;
                        }
                    }
                    _Dg_Detalle.DataSource = _Mtd_LlenarDataSets(_Dg_Grid.Rows[e.RowIndex].Cells["cidrelacobro"].Value.ToString()).Table;
                    _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Mtd_LlenarDetalle(_Dg_Grid.Rows[e.RowIndex].Cells["cidrelacobro"].Value.ToString());
                }
                _Bt_Imprimir.Enabled = false;
                _Pnl_Clave.Visible = false;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Relacion.Text.Trim().Length == 0 & e.TabPageIndex!=0)
            { e.Cancel = true; }
        }

        private string _Mtd_CrearCompropCont(string _P_Str_IdCobro, string _P_Str_Caja)
        {
            string _Str_cidcomprob = "";
            int _Int_corder = 0;
            string _Str_DocFact = "";
            string _Str_DocND = "";
            string _Str_DocNC = "";
            string _Str_DocRelCob = "";
            string _Str_FechaDoc = "";
            string _Str_CadAux = "";
            string _Str_DescripCount = "";
            string _Str_ccount = "";
            string _Str_TpoDoc = "";
            string _Str_NumDoc = "";
            string _Str_ctipdoccheq = "";
            string _Str_ctipdocumentdep = "";
            string _Str_ccuentacheqtransito = "";
            string _Str_ccuentacheqtransitoName = "";
            string _Str_ccuentacheqdia = "";
            string _Str_ccuentacheqdiaName = "";
            string _Str_ccuentacheqdevuelto = "";
            string _Str_ccuentacheqdevueltoName = "";
            string _Str_ccuentadescuentos = "";
            string _Str_ccuentadescuentosName = "";
            string _Str_ccuentaivareten="";
            string _Str_ccuentaiva = "";
            string _Str_ccuentaivaName = "";
            string _Str_ccuentaivaretenName = "";
            string _Str_ccuentacxc = "";
            string _Str_ccuentacxcName = "";
            string _Str_BancoId = "";
            string _Str_BancoName = "";
            string _Str_BancoCuenta = "";
            string _Str_cnumcheque = "";
            string _Str_Deposito = "";
            double _Dbl_Monto = 0;
            double _Dbl_IVAFact = 0;
            double _Dbl_IVAND = 0;
            double _Dbl_IVANC = 0;
            double _Dbl_IVA = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_ctypcompro = "";
            string _Str_cconceptocomp = "";
            string _Str_Sql = "";
            DataSet _Ds;
            DataSet _Ds_A;

            _Str_Sql = "SELECT * FROM VST_CONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ctipdoccheq = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheq"]);
                _Str_ctipdocumentdep = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
                _Str_ccuentacheqtransito = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransito"]);
                _Str_ccuentacheqtransitoName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtraname"]);
                _Str_ccuentacheqdia = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdia"]);
                _Str_ccuentacheqdiaName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdianame"]);
                _Str_ccuentacheqdevuelto = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevuelto"]);
                _Str_ccuentacheqdevueltoName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevueltoname"]);
                _Str_ccuentadescuentos = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentos"]);
                _Str_ccuentadescuentosName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentosname"]);
                _Str_ccuentaivareten = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivareten"]);
                _Str_ccuentaivaretenName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaretenname"]);
                _Str_DocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_DocNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotcred"]);
                _Str_DocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]);
                _Str_ccuentaiva = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaiva"]);
                _Str_ccuentaivaName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaname"]);
                _Str_DocRelCob = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocrelcob"]);
                _Str_ccuentacxc = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxc"]);
                _Str_ccuentacxcName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxcname"]);
                _Str_ctypcompro = Convert.ToString(_Ds.Tables[0].Rows[0]["ctypcompro"]);
                _Str_cconceptocomp = Convert.ToString(_Ds.Tables[0].Rows[0]["cconceptocomp"]);
            }



            _Str_cidcomprob = Convert.ToString(_MyUtilidad._Mtd_Consecutivo_TCOMPROBANC());
            //AGREGO LOS DEPOSITOS
            _Str_CadAux = "";
            _Str_Sql = "SELECT * FROM VST_RELACCOBDDEPM WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_FechaDoc = Convert.ToDateTime(_DRow["cfechadepo"]).ToShortDateString(); 
                _Str_BancoId = Convert.ToString(_DRow["cbancodepo"]);
                _Str_BancoCuenta = Convert.ToString(_DRow["cnumcuentadepo"]);
                _Str_BancoName = Convert.ToString(_DRow["cbanconame"]).Trim().ToUpper();
                _Str_Deposito = Convert.ToString(_DRow["cnumdepo"]);
                _Str_ccount = Convert.ToString(_DRow["ccount"]);
                _Str_DescripCount = Convert.ToString(_DRow["ccountname"]);
                _Str_CadAux = _Str_BancoName + " CTA." + _Str_BancoCuenta + "DEPOSITO #" + _Str_Deposito + " SEGUN CAJA " + _P_Str_Caja;
                if (Convert.ToString(_DRow["cmontodepo"]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_DRow["cmontodepo"]);
                }
                else
                {
                    _Dbl_Monto = 0;
                }
                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctipdoccheq + "','" + _Str_Deposito + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaDoc)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            //CHEQUES EN TRANSITO
            _Str_Sql = "SELECT * FROM VST_RELACCOBDCHEQ WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_BancoId = Convert.ToString(_DRow["cbancocheque"]);
                _Str_BancoName = Convert.ToString(_DRow["cbanconame"]).Trim().ToUpper();
                _Str_cnumcheque = Convert.ToString(_DRow["cnumcheque"]);
                _Str_FechaDoc = Convert.ToDateTime(_DRow["cfeahcaemision"]).ToShortDateString();
                _Dbl_Monto = Convert.ToDouble(_DRow["cmontocheq"]);
                
                _Str_CadAux = _Str_ccuentacheqtransitoName + " INGRESOS SEGUN CAJA " + _P_Str_Caja;
                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentacheqtransito + "','" + _Str_ctipdoccheq + "','" + _Str_cnumcheque + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaDoc)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            

            //DESCUENTOS EN VENTAS
            _Str_Sql = "SELECT (cdescto1+cdescto2+cdescto3+cdescto4) AS descventas,ctipodocument,cnumdocu,cfechadocu FROM TRELACCOBD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                _Str_TpoDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument"]);
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfechadocu"]) != "")
                {
                    _Str_FechaDoc = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadocu"]).ToShortDateString();
                }
                
            }
            if (_Dbl_Monto != 0)
            {
                _Str_CadAux = _Str_ccuentadescuentosName + " SEGUN CAJA " + _P_Str_Caja;
                _Int_corder++;
                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentadescuentos + "','" + _Str_TpoDoc + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaDoc)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            //CALCULO EL TOTAL DE IVA

            _Str_Sql = "SELECT cnumdocu FROM TRELACCOBD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "' AND cdelete=0 AND ctipodocument='" + _Str_DocFact + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT c_impuesto_bs FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DRow["cnumdocu"].ToString() + "'";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_A.Tables[0].Rows[0]["c_impuesto_bs"] != System.DBNull.Value)
                    {
                        _Dbl_IVAFact = _Dbl_IVAFact + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["c_impuesto_bs"]);
                    }
                }
            }

            _Str_Sql = "SELECT cnumdocu FROM TRELACCOBD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "' AND cdelete=0 AND ctipodocument='" + _Str_DocNC + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT cimpuesto FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _DRow["cnumdocu"].ToString();
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_A.Tables[0].Rows[0]["cimpuesto"] != System.DBNull.Value)
                    {
                        _Dbl_IVANC = _Dbl_IVANC + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cimpuesto"]);
                    }
                }
            }

            _Str_Sql = "SELECT cnumdocu FROM TRELACCOBD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "' AND cdelete=0 AND ctipodocument='" + _Str_DocND + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT cimpuesto FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _DRow["cnumdocu"].ToString();
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_A.Tables[0].Rows[0]["cimpuesto"] != System.DBNull.Value)
                    {
                        _Dbl_IVAND = _Dbl_IVAND + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cimpuesto"]);
                    }
                }
            }
            _Dbl_IVA = _Dbl_IVAFact + _Dbl_IVAND - _Dbl_IVANC;
            if (_Dbl_IVA != 0)
            {
                _Int_corder++;
                _Str_CadAux = _Str_ccuentaivaName + " SEGUN CAJA " + _P_Str_Caja;
                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentaiva + "','" + _Str_DocRelCob + "','" + _P_Str_IdCobro + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_IVA) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }

            _Dbl_MontoTotal = Convert.ToDouble(_Txt_TotalNeto.Text) + _Dbl_IVA;
            _Int_corder++;
            _Str_CadAux = _Str_ccuentacxcName + " SEGUN CAJA " + _P_Str_Caja;
            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
            _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentacxc + "','" + _Str_DocRelCob + "','" + _P_Str_IdCobro + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

            _Str_Sql = "Select cyearacco from TCONFIGCONT where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cyearacco = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            else
            { _Str_cyearacco = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString(); }
            _Str_Sql = "Select cmontacco from TMONTHC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cfinishd>='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' and cbegind<='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cmontacco = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            else
            { _Str_cmontacco = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString(); }

            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',0,GETDATE(),'" + Frm_Padre._Str_Use + "',0,'1')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Str_Sql = "UPDATE TRELACCOBM SET cidcomprob='" + _Str_cidcomprob + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _P_Str_IdCobro + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_cidcomprob;
        }

        private void _Mtd_ImprimirComprobante(string _Pr_Str_ComprobId)
        {
            string _Str_Sql = "";
            //MessageBox.Show("Prepare la impresora para imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'", _Print, true);
                Cursor = Cursors.Default;

                if (MessageBox.Show("Se imprimió correctamente?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "UPDATE TRELACCOBM SET caprobado=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Txt_Relacion.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Mtd_SaldarDocumentos();
                    _Bt_Imprimir.Enabled = true;
                    _Bt_Aprobar.Enabled = false;
                }
            }

        }

        private void _Mtd_SaldarDocumentos()
        {
            double _Dbl_MontoCobro = 0;
            string _Str_NumDoc = "";
            string _Str_FechaDoc = "";
            string _Str_TpoDoc = "";
            string _Str_Cliente = "";
            int _Int_C = 0;
            string _Str_Sql = "";
            DataSet _Ds;
            _Str_Sql = "SELECT cnumdocu,cmontocancel,cfechadocu,ctipodocument,ccliente FROM TRELACCOBD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Txt_Relacion.Text + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Str_Cliente = Convert.ToString(_DRow["ccliente"]);
                _Str_TpoDoc = Convert.ToString(_DRow["ctipodocument"]);
                _Str_NumDoc = Convert.ToString(_DRow["cnumdocu"]);
                _Str_FechaDoc = Convert.ToDateTime(_DRow["cfechadocu"]).ToShortDateString();
                if (Convert.ToString(_DRow["cmontocancel"]) != "")
                {
                    _Dbl_MontoCobro = Convert.ToDouble(_DRow["cmontocancel"]);
                }
                else
                {
                    _Dbl_MontoCobro = 0;
                }
                _Int_C++;
                _Str_Sql = "INSERT INTO TSALDOCLIENTEDD (cgroupcomp,ccompany,ccliente,ctipodocument,cnumdocu,ciddetalle,cmontocobrado,cfechacobro,cidrelacobro,ccaja)" +
                "VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Cliente + "','" + _Str_TpoDoc + "','" + _Str_NumDoc + "','" + _Int_C.ToString() + "','" + _Dbl_MontoCobro.ToString().Replace(",",".") + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaDoc)) + "','" + _Txt_Relacion.Text + "','" + _Txt_Caja.Text + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TSALDOCLIENTED SET csaldofactura=(csaldofactura-" + _Dbl_MontoCobro.ToString().Replace(",", ".") + "),cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _Str_Cliente + "' and ctipodocument='" + _Str_TpoDoc + "' and cnumdocu='" + _Str_NumDoc + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
        }

        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.BringToFront();
            _Pnl_Clave.Visible = true;
        }

        private void Frm_VerificaRelaCobro_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime[] _Dtm = _Mtd_MesActual();
                string _Str_Factura = "";
                string _Str_NotaCredito = "";
                string _Str_CheqDev = "";
                string _Str_Sql = "SELECT * FROM VST_REPORTE_COBRANZA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro=" + _Txt_Relacion.Text + " AND cdeleted=0";
                DataSet _Ds_A;
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    _Str_Sql = "SELECT dbo.FNC_ACUMULADO_COBRO('" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Str_Vendedor + "','" + _My_Formato._Mtd_fecha(_Dtm[0]) + "','" + _My_Formato._Mtd_fecha(_Dtm[1]) + "')";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                        {
                            _DRow["acumulado_cobro"] = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                        }
                    }

                    _Str_Sql = "Select ctipdocfact,ctipdocnotcred,ctipdoccheqdev from TCONFINCRED where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_Factura = _Ds_A.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper();
                        _Str_NotaCredito = _Ds_A.Tables[0].Rows[0]["ctipdocnotcred"].ToString().Trim().ToUpper();
                        _Str_CheqDev = _Ds_A.Tables[0].Rows[0]["ctipdoccheqdev"].ToString().Trim().ToUpper();
                    }
                    if (Convert.ToString(_DRow["ctipodocument"]).Trim().ToUpper() == _Str_Factura)
                    {
                        _Str_Sql = "SELECT (c_montotot_si_bs) AS total FROM TFACTURAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + Convert.ToString(_DRow["cnumdocu"]) + "'";
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                            {
                                _DRow["monto_doc"] = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    else if (Convert.ToString(_DRow["ctipodocument"]).Trim().ToUpper() == _Str_NotaCredito)
                    {
                        _Str_Sql = "SELECT cmontototsi FROM TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + Convert.ToString(_DRow["cnumdocu"]) + "'";
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                            {
                                _DRow["monto_doc"] = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    else if (Convert.ToString(_DRow["ctipodocument"]).Trim().ToUpper() == _Str_CheqDev)
                    {
                        _Str_Sql = "Select cmontochequ from TCHEQDEVUELT where ccompany='" + Frm_Padre._Str_Comp + "' and cidcheqdevuelt='" + _DRow["cnumdocu"].ToString() + "'";
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                            {
                                _DRow["monto_doc"] = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                _Ds.Tables[0].AcceptChanges();

                PrintDialog _Print = new PrintDialog();
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        REPORTESS _Frm = new REPORTESS("T3.Report.rRelacionCobranza", _Ds.Tables[0], _Print, true, "Section1", "cabecera", "rif", "nit");
                        _Txt_Relacion.Text = "";
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo contactar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor = Cursors.Default;

                }
            }
            catch (Exception _Ex)
            { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }

        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Txt_Clave.Text.Trim() != "")
                {
                    if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                    {//CLAVE CORRECTA
                        string _Str_Comprob = "";
                        _Str_Comprob = _Mtd_CrearCompropCont(_Txt_Relacion.Text, _Txt_Caja.Text.Trim());
                        _Mtd_ImprimirComprobante(_Str_Comprob);
                        _Txt_Relacion.Text = "";
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                        _Pnl_Clave.Visible = false;
                    }
                    else
                    {//CLAVE INCORRECTA
                        _Txt_Clave.Focus();
                        MessageBox.Show("Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Lbl_TituloClave.Text = "Aprobar Relación";
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}