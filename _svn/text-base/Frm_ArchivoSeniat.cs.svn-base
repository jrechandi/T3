using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
namespace T3
{
    public partial class Frm_ArchivoSeniat : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ArchivoSeniat()
        {
            InitializeComponent();
            _Mtd_ActualizarIVA();
            _Mtd_ActualizarISLR();
            _Mtd_CargarMesesIVA();
            _Mtd_CargarMesesISLR();
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

        private void _Mtd_ActualizarIVA()
        {
            string _Str_Cadena = "SELECT cidarchivoiva AS Archivo,CONVERT(VARCHAR,YEAR(cfechadesde))+CASE WHEN LEN(LTRIM(RTRIM(CONVERT(VARCHAR,MONTH(cfechadesde)))))=1 THEN '0'+CONVERT(VARCHAR,MONTH(cfechadesde)) ELSE CONVERT(VARCHAR,MONTH(cfechadesde)) END AS Periodo, CONVERT(VARCHAR,cfechadesde,103) AS Desde, CONVERT(VARCHAR,cfechahasta,103) AS Hasta, CASE WHEN cverificado='1' THEN 'SÍ' ELSE 'NO' END AS Verificado, cverificado FROM TARCHIVOIVAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Mtd_CargarGrid(_Dg_Grid_IVA, _Cmb_Mes_IVA, _Str_Cadena);
        }
        private void _Mtd_ActualizarISLR()
        {
            string _Str_Cadena = "SELECT cidarchivoislr AS Archivo,CONVERT(VARCHAR,YEAR(cfechadesde))+CASE WHEN LEN(LTRIM(RTRIM(CONVERT(VARCHAR,MONTH(cfechadesde)))))=1 THEN '0'+CONVERT(VARCHAR,MONTH(cfechadesde)) ELSE CONVERT(VARCHAR,MONTH(cfechadesde)) END AS Periodo, CONVERT(VARCHAR,cfechadesde,103) AS Desde, CONVERT(VARCHAR,cfechahasta,103) AS Hasta, CASE WHEN cverificado='1' THEN 'SÍ' ELSE 'NO' END AS Verificado, cverificado FROM TARCHIVOISLRM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Mtd_CargarGrid(_Dg_Grid_ISLR, _Cmb_Mes_ISLR, _Str_Cadena);
        }
        delegate void SetDataSetsCallback(DataGridView _P_Dg_Grid,ComboBox _P_Cmb_Combo,string _P_Str_Cadena);
        private void _Mtd_CargarGrid(DataGridView _P_Dg_Grid, ComboBox _P_Cmb_Combo, string _P_Str_Cadena)
        {
            if (_P_Dg_Grid.InvokeRequired)
            {
                SetDataSetsCallback _Sets = new SetDataSetsCallback(_Mtd_CargarGrid);
                this.Invoke(_Sets, new object[] { _P_Dg_Grid, _P_Cmb_Combo, _P_Str_Cadena });
            }
            else
            {
                string _Str_Filtro = "";
                if (_P_Cmb_Combo.SelectedIndex > 0)
                {
                    string[] _Str_MesAno = _Mtd_ExtraerMesAno(_P_Cmb_Combo.Text.Trim());
                    _Str_Filtro = " AND MONTH(cfechadesde)='" + _Str_MesAno[0] + "' AND YEAR(cfechadesde)='" + _Str_MesAno[1] + "'";
                }

                if (_P_Dg_Grid.Name == "_Dg_Grid_IVA")
                {
                    _Str_Filtro += " ORDER BY cidarchivoiva DESC";
                }
                else
                {
                    _Str_Filtro += " ORDER BY cidarchivoislr DESC";
                }

                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena + _Str_Filtro);

                _P_Dg_Grid.DataSource = _Ds.Tables[0];
                _P_Dg_Grid.Columns[5].Visible = false;
            }
        }
        private void _Mtd_CargarMesesIVA()
        {
            string _Str_Cadena = "";
            
            _Str_Cadena = "SELECT DISTINCT MONTH(cfechadesde) AS mes,";
            _Str_Cadena += " (CONVERT(VARCHAR, MONTH(cfechadesde)) + '-' + CONVERT(VARCHAR, YEAR(cfechadesde))) AS texto,";
            _Str_Cadena += " YEAR(cfechadesde) AS año";
            _Str_Cadena += " FROM TARCHIVOIVAM";
            _Str_Cadena += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Str_Cadena += " AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_Cadena += " ORDER BY DATEPART(year, cfechadesde) DESC, DATEPART(month, cfechadesde) DESC;";

            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes_IVA, _Str_Cadena);
        }

        private void _Mtd_CargarMesesISLR()
        {
            string _Str_Cadena = "";
            
            _Str_Cadena = "SELECT DISTINCT MONTH(cfechadesde) AS mes,";
            _Str_Cadena += " (CONVERT(VARCHAR, MONTH(cfechadesde)) + '-' + CONVERT(VARCHAR, YEAR(cfechadesde))) AS texto,";
            _Str_Cadena += " YEAR(cfechadesde) AS año";
            _Str_Cadena += " FROM TARCHIVOISLRM";
            _Str_Cadena += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Str_Cadena += " AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_Cadena += " ORDER BY DATEPART(year, cfechadesde) DESC, DATEPART(month, cfechadesde) DESC;";

            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes_ISLR, _Str_Cadena);
        }

        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private bool _Mtd_RangoCorrectoIVA(DateTime _P_Dtm_Desde, DateTime _P_Dtm_Hasta)
        {
            string _Str_Cadena = "SELECT cidarchivoiva FROM TARCHIVOIVAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (CONVERT(DATETIME,CONVERT(VARCHAR,cfechadesde,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "' AND '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "' OR CONVERT(DATETIME,CONVERT(VARCHAR,cfechahasta,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "' AND '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0;
        }
        private bool _Mtd_RangoCorrectoISLR(DateTime _P_Dtm_Desde, DateTime _P_Dtm_Hasta)
        {
            string _Str_Cadena = "SELECT cidarchivoislr FROM TARCHIVOISLRM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (CONVERT(DATETIME,CONVERT(VARCHAR,cfechadesde,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "' AND '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "' OR CONVERT(DATETIME,CONVERT(VARCHAR,cfechahasta,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "' AND '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0;
        }
        public void _Mtd_Nuevo()
        {
            if (_Tb_Tab.SelectedIndex == 0)
            {
                if (_Mtd_ConfigurarDesdeHastaIVA())
                { _Pnl_Guardar.Visible = true; }
                else
                { MessageBox.Show("No se encontraron registros para generar archivos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                if (_Mtd_ConfigurarDesdeHastaISLR())
                { _Pnl_Guardar.Visible = true; }
                else
                { MessageBox.Show("No se encontraron registros para generar archivos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private bool _Mtd_ConfigurarDesdeHastaIVA()
        {
            _Dtp_Desde.ValueChanged -= new EventHandler(_Dtp_Desde_ValueChanged);
            _Dtp_Hasta.ValueChanged -= new EventHandler(_Dtp_Hasta_ValueChanged);
            _Dtp_Desde.MaxDate = Convert.ToDateTime("31/12/9998");
            _Dtp_Desde.MinDate = Convert.ToDateTime("01/01/1753");
            _Dtp_Hasta.MaxDate = Convert.ToDateTime("31/12/9998");
            _Dtp_Hasta.MinDate = Convert.ToDateTime("01/01/1753");
            string _Str_Cadena = "SELECT MAX(CONVERT(DATETIME,CONVERT(VARCHAR,cfechahasta,103))) FROM TARCHIVOIVAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'AND ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0] == System.DBNull.Value)
            {
                _Dtp_Desde.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1);//Primer día del mes
                //--------Dividir comentar y descomentar
                //_Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 1).AddMonths(1).AddDays(-1);//Ultimo día del mes
                _Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 15);//
                //--------Dividir comentar y descomentar
            }
            else
            {
                _Dtp_Desde.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]).AddDays(1);
            _Lbl_Volver:
                //--------Dividir comentar y descomentar
                if (_Dtp_Desde.Value.Day < 15)
                {
                    _Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 15);//El dia 15 del mes
                }
                else
                {
                    _Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 1).AddMonths(1).AddDays(-1);//Último día del mes 
                }
                //_Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 1).AddMonths(1).AddDays(-1);//Último día del mes
                //--------Dividir comentar y descomentar
                _Str_Cadena = "SELECT cidcomprobret FROM VST_RETENCION_IVA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count == 0 | _Mtd_QuincenasCreadas(_Dtp_Desde.Value) == 2)
                {
                    _Str_Cadena = "SELECT MIN(CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103))) FROM VST_RETENCION_IVA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) > '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dtp_Desde.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]); goto _Lbl_Volver; }
                    else
                    { return false; }
                }
                else
                {
                    _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
                    _Dtp_Desde.MinDate = _Dtp_Desde.Value;
                    _Dtp_Hasta.MaxDate = _Dtp_Hasta.Value;
                    _Dtp_Hasta.MinDate = _Dtp_Desde.Value;
                }
            }
            _Dtp_Desde.ValueChanged += new EventHandler(_Dtp_Desde_ValueChanged);
            _Dtp_Hasta.ValueChanged += new EventHandler(_Dtp_Hasta_ValueChanged);
            return true;
        }
        private bool _Mtd_ConfigurarDesdeHastaISLR()
        {
            _Dtp_Desde.ValueChanged -= new EventHandler(_Dtp_Desde_ValueChanged);
            _Dtp_Hasta.ValueChanged -= new EventHandler(_Dtp_Hasta_ValueChanged);
            _Dtp_Desde.MaxDate = Convert.ToDateTime("31/12/9998");
            _Dtp_Desde.MinDate = Convert.ToDateTime("01/01/1753");
            _Dtp_Hasta.MaxDate = Convert.ToDateTime("31/12/9998");
            _Dtp_Hasta.MinDate = Convert.ToDateTime("01/01/1753");
            string _Str_Cadena = "SELECT MAX(CONVERT(DATETIME,CONVERT(VARCHAR,cfechahasta,103))) FROM TARCHIVOISLRM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'AND ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0] == System.DBNull.Value)
            {
                _Dtp_Desde.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1);//Primer día del mes
                _Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 1).AddMonths(1).AddDays(-1);//Último día del mes
            }
            else
            {
                _Dtp_Desde.Value = new DateTime(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]).Year, Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]).Month, 1).AddMonths(1);//Primer día del mes
            _Lbl_Volver:
                _Dtp_Hasta.Value = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, 1).AddMonths(1).AddDays(-1);//Último día del mes
                _Str_Cadena = "SELECT cidcomprobislr FROM VST_RETENCION_ISLR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    _Str_Cadena = "SELECT MIN(CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103))) FROM VST_RETENCION_ISLR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) > '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dtp_Desde.Value = new DateTime(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]).Year, Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]).Month, 1); goto _Lbl_Volver; }
                    else
                    { return false; }
                }
                else
                {
                    _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
                    _Dtp_Desde.MinDate = _Dtp_Desde.Value;
                    _Dtp_Hasta.MaxDate = _Dtp_Hasta.Value;
                    _Dtp_Hasta.MinDate = _Dtp_Desde.Value;
                }
            }
            _Dtp_Desde.ValueChanged += new EventHandler(_Dtp_Desde_ValueChanged);
            _Dtp_Hasta.ValueChanged += new EventHandler(_Dtp_Hasta_ValueChanged);
            return true;
        }
        delegate void SetPanelComboCallback(Panel _P_Pnl_Panel,ComboBox _P_Cmb_Combo);
        private void _Mtd_PanelCombo(Panel _P_Pnl_Panel, ComboBox _P_Cmb_Combo)
        {
            if (_P_Pnl_Panel.InvokeRequired)
            {
                SetPanelComboCallback _Sets = new SetPanelComboCallback(_Mtd_PanelCombo);
                this.Invoke(_Sets, new object[] { _P_Pnl_Panel, _P_Cmb_Combo });
            }
            else
            {
                _P_Pnl_Panel.Visible=false;
                _P_Cmb_Combo.SelectedIndex = 0;
            }
        }
        bool _Bol_Guardado = false;
        private void _Mtd_GuardarIVA(DateTime _P_Dtm_Desde, DateTime _P_Dtm_Hasta, string _P_Str_ID_Archivo)
        {
            _Bol_Guardado = false;
            string _Str_Cadena = "";
            string _Str_ID_Archivo = "";
            if (_P_Str_ID_Archivo.Trim().Length > 0)
            { _Str_ID_Archivo = _P_Str_ID_Archivo; }
            else
            {
                _Str_Cadena = "SELECT MAX(cidarchivoiva) FROM TARCHIVOIVAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                _Str_ID_Archivo = _Cls_VariosMetodos._Mtd_Correlativo(_Str_Cadena);
            }
            _Str_Cadena = "SELECT crif,cfechadocu,ctipodocu,c_rif,cnumdocu,cnumdocuctrl,ctotal,ctotalsimp,cretenido,cidcomprobret,ctotmontexcento,calicuota,cproveedor,cdocumentafect FROM VST_RETENCION_IVA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "' AND '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //------------------
                _Mtd_PanelCombo(_Pnl_Guardar, _Cmb_Mes_IVA);
                //------------------
                string _Str_Periodo = _P_Dtm_Desde.Year.ToString() + _P_Dtm_Desde.Month.ToString();
                if (_Str_Periodo.Length == 5) { _Str_Periodo = _Str_Periodo.Insert(4, "0"); }
                if (_P_Str_ID_Archivo.Trim().Length > 0)
                { _Str_Cadena = "UPDATE TARCHIVOIVAM SET cmontacco='" + Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "',cyearacco='" + Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "',cfechadesde='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "',cfechahasta='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoiva='" + _Str_ID_Archivo + "'"; }
                else
                { _Str_Cadena = "INSERT INTO TARCHIVOIVAM (cgroupcomp,ccompany,cidarchivoiva,cmontacco,cyearacco,cfechadesde,cfechahasta) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Archivo + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "','" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TARCHIVOIVAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoiva='" + _Str_ID_Archivo + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    try
                    {
                        _Str_Cadena = "INSERT INTO TARCHIVOIVAD (cgroupcomp,ccompany,cidarchivoiva,crifcontdecla,cperioimpo,cfechafactura,ctipoper,ctipodocu,crifprovee,cnumdocu,cnumcont,cmontotdocu,cbaseimponible,cmontivaretenido,cnumdocuafect,cnumcomproreten,cmontexento,calicuota,cnumexpediente,cproveedor) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Archivo + "','" + _Row["crif"].ToString().Trim() + "','" + _Str_Periodo + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row["cfechadocu"].ToString().Trim())) + "','C','" + _Row["ctipodocu"].ToString().Trim() + "','" + _Row["c_rif"].ToString().Trim() + "','" + _Row["cnumdocu"].ToString().Trim() + "','" + _Row["cnumdocuctrl"].ToString().Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ctotal"].ToString().Trim())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ctotalsimp"].ToString().Trim())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["cretenido"].ToString().Trim())) + "','" + _Row["cdocumentafect"].ToString().Trim() + "','" + _Row["cidcomprobret"].ToString().Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ctotmontexcento"].ToString().Trim())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["calicuota"].ToString().Trim())) + "','0','" + _Row["cproveedor"].ToString().Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    catch { }
                }
                _Mtd_ActualizarIVA();
                _Bol_Guardado = true;
                
            }
            else
            {
                _Bol_Guardado = false;
            }
        }
        private void _Mtd_GuardarISLR(DateTime _P_Dtm_Desde, DateTime _P_Dtm_Hasta, string _P_Str_ID_Archivo)
        {
            _Bol_Guardado = false;
            string _Str_Cadena = "";
            string _Str_ID_Archivo = "";
            if (_P_Str_ID_Archivo.Trim().Length > 0)
            { _Str_ID_Archivo = _P_Str_ID_Archivo; }
            else
            {
                _Str_Cadena = "SELECT MAX(cidarchivoislr) FROM TARCHIVOISLRM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                _Str_ID_Archivo = _Cls_VariosMetodos._Mtd_Correlativo(_Str_Cadena);
            }
            _Str_Cadena = "SELECT crif,c_rif,cnumdocu,cnumdocuctrl,ctotal,cporcentajereten,cproveedor,cfechaemiislr,ISNULL(ccodconcepto,0) AS ccodconcepto FROM VST_RETENCION_ISLR WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemiislr,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "' AND '" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //------------------
                _Mtd_PanelCombo(_Pnl_Guardar, _Cmb_Mes_ISLR);
                //------------------
                string _Str_Periodo = _P_Dtm_Desde.Year.ToString() + _P_Dtm_Desde.Month.ToString();
                if (_Str_Periodo.Length == 5) { _Str_Periodo = _Str_Periodo.Insert(4, "0"); }
                if (_P_Str_ID_Archivo.Trim().Length > 0)
                { _Str_Cadena = "UPDATE TARCHIVOISLRM SET cmontacco='" + Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "',cyearacco='" + Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "',cfechadesde='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "',cfechahasta='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoislr='" + _Str_ID_Archivo + "'"; }
                else
                { _Str_Cadena = "INSERT INTO TARCHIVOISLRM (cgroupcomp,ccompany,cidarchivoislr,cmontacco,cyearacco,cfechadesde,cfechahasta) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Archivo + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" + _Cls_Formato._Mtd_fecha(_P_Dtm_Desde) + "','" + _Cls_Formato._Mtd_fecha(_P_Dtm_Hasta) + "')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TARCHIVOISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoislr='" + _Str_ID_Archivo + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                int _Int_ID_Detalle = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Int_ID_Detalle += 1;
                    _Str_Cadena = "INSERT INTO TARCHIVOISLRD (cgroupcomp,ccompany,cidarchivoislr,crifagenretencion,cfecha,ciddetalle,crifprovee,cnumfact,cnumcont,ccodigoconcepto,cmontdocu,cporcenreten,cproveedor,cfechaoperacion) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Archivo + "','" + _Row["crif"].ToString().Trim() + "','" + _Str_Periodo + "','" + _Int_ID_Detalle.ToString() + "','" + _Row["c_rif"].ToString().Trim() + "','" + _Row["cnumdocu"].ToString().Trim() + "','" + _Row["cnumdocuctrl"].ToString().Trim() + "','" + _Row["ccodconcepto"].ToString().Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ctotal"].ToString().Trim())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["cporcentajereten"].ToString().Trim())) + "','" + _Row["cproveedor"].ToString().Trim() + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row["cfechaemiislr"].ToString().Trim())) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                _Mtd_ActualizarISLR();
                _Bol_Guardado = true;

            }
            else
            {
                _Bol_Guardado = false;
            }
        }
        private void _Mtd_IVA(DateTime _P_Dtm_Desde, DateTime _P_Dtm_Hasta, string _P_Str_ID_Archivo)
        {
            Thread _Thr_Thread = new Thread(new ThreadStart(delegate { _Mtd_GuardarIVA(_P_Dtm_Desde, _P_Dtm_Hasta, _P_Str_ID_Archivo); }));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Por favor espere...");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
        }
        private void _Mtd_ISLR(DateTime _P_Dtm_Desde, DateTime _P_Dtm_Hasta, string _P_Str_ID_Archivo)
        {
            Thread _Thr_Thread = new Thread(new ThreadStart(delegate { _Mtd_GuardarISLR(_P_Dtm_Desde, _P_Dtm_Hasta, _P_Str_ID_Archivo); }));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Por favor espere...");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
        }
        private void _Mtd_Verificar_IVA(string _P_Str_ID_Archivo)
        {
            string _Str_Cadena = "UPDATE TARCHIVOIVAM SET cverificado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoiva='" + _P_Str_ID_Archivo + "'"; 
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Verificar_ISLR(string _P_Str_ID_Archivo)
        {
            string _Str_Cadena = "UPDATE TARCHIVOISLRM SET cverificado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoislr='" + _P_Str_ID_Archivo + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private int _Mtd_QuincenasCreadas(DateTime _Dtm_Desde)
        {
            string _Str_Cadena = "SELECT cidarchivoiva FROM TARCHIVOIVAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND MONTH(cfechadesde)=MONTH(CONVERT(DATETIME,'" + _Cls_Formato._Mtd_fecha(_Dtm_Desde) + "')) AND YEAR(cfechadesde)=YEAR(CONVERT(DATETIME,'" + _Cls_Formato._Mtd_fecha(_Dtm_Desde) + "'))";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
        }
        private void _Mtd_CrearArchivoIVA(string _P_Str_ID_Archivo)
        {
            System.IO.DirectoryInfo _DirInf = new System.IO.DirectoryInfo("c:\\seniat");
            if (!_DirInf.Exists)
            {
                _DirInf.Create();
            }
            string _Str_Cadena = "SELECT REPLACE(crifcontdecla,'-',''),cperioimpo,CONVERT(VARCHAR,YEAR(cfechafactura))+'-'+CASE WHEN LEN(MONTH(cfechafactura))=1 THEN '0'+CONVERT(VARCHAR,MONTH(cfechafactura)) ELSE CONVERT(VARCHAR,MONTH(cfechafactura)) END +'-'+CASE WHEN LEN(DAY(cfechafactura))=1 THEN '0'+CONVERT(VARCHAR,DAY(cfechafactura)) ELSE CONVERT(VARCHAR,DAY(cfechafactura)) END,ctipoper,ctipodocu,REPLACE(crifprovee,'-',''),cnumdocu,cnumcont,REPLACE(cmontotdocu,',','.'),REPLACE(cbaseimponible,',','.'),REPLACE(cmontivaretenido,',','.'),cnumdocuafect,CONVERT(VARCHAR,LTRIM(RTRIM(cperioimpo)))+SUBSTRING('00000000',LEN(LTRIM(RTRIM(cnumcomproreten))),8-LEN(LTRIM(RTRIM(cnumcomproreten))))+CONVERT(VARCHAR,LTRIM(RTRIM(cnumcomproreten))),REPLACE(cmontexento,',','.'),REPLACE(calicuota,',','.'),cnumexpediente FROM TARCHIVOIVAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoiva='" + _P_Str_ID_Archivo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string[] _Str_Fila = new string[_Ds.Tables[0].Rows.Count];
            int _Int_I = 0;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Fila[_Int_I] = _Row[0].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[1].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[2].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[3].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[4].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[5].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[6].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[7].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[8].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[9].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[10].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[11].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[12].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[13].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[14].ToString().Trim() + (char)9;
                _Str_Fila[_Int_I] += _Row[15].ToString().Trim();
                _Int_I++;
            }
            //new System.IO.FileStream(@"C:\IVA.txt", System.IO.FileMode.Create);

            System.IO.File.WriteAllLines(@"C:\seniat\IVA.txt", _Str_Fila);
        }
        
        private void _Mtd_CrearArchivoISLR(string _P_Str_ID_Archivo)
        {
            System.IO.DirectoryInfo _DirInf = new System.IO.DirectoryInfo("c:\\seniat");
            if (!_DirInf.Exists)
            {
                _DirInf.Create();
            }
            string _Str_Cadena = "SELECT REPLACE(crifagenretencion,'-','') AS crifagenretencion,cfecha FROM TARCHIVOISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoislr='" + _P_Str_ID_Archivo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_RifAgente = _Ds.Tables[0].Rows[0]["crifagenretencion"].ToString().Trim();
                string _Str_Periodo = _Ds.Tables[0].Rows[0]["cfecha"].ToString().Trim();
                _Str_Cadena = "SELECT REPLACE(crifprovee,'-','') AS RifRetenido,REPLACE(cnumfact,'-','') AS NumeroFactura, REPLACE(cnumcont,'-','') AS NumeroControl,CONVERT(VARCHAR,cfechaoperacion,103) AS FechaOperacion,ccodigoconcepto AS CodigoConcepto,REPLACE(cmontdocu,',','.') AS MontoOperacion,REPLACE(cporcenreten,',','.') AS PorcentajeRetencion FROM TARCHIVOISLRD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidarchivoislr='" + _P_Str_ID_Archivo + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Ds.Tables[0].TableName = "DetalleRetencion";
                //const string _Str_Comillas = "\"";
                //_Ds.DataSetName = "RelacionRetencionesISLR RifAgente=" + _Str_Comillas + _Str_RifAgente + _Str_Comillas + " Periodo=" + _Str_Periodo;
                _Ds.DataSetName = "RelacionRetencionesISLR";
                _Ds.EnforceConstraints = false;
                XmlDataDocument _Xml_d = new XmlDataDocument(_Ds);
                XmlDeclaration _Xml_Decl = _Xml_d.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
                XmlElement _Xml_Elem = _Xml_d.DocumentElement;
                _Xml_d.InsertBefore(_Xml_Decl, _Xml_Elem);
                XmlAttribute _Xml_a = _Xml_d.CreateAttribute("RifAgente");
                _Xml_a.Value = _Str_RifAgente;
                _Xml_d["RelacionRetencionesISLR"].Attributes.Append(_Xml_a);
                _Xml_a = _Xml_d.CreateAttribute("Periodo");
                _Xml_a.Value = _Str_Periodo;
                _Xml_d["RelacionRetencionesISLR"].Attributes.Append(_Xml_a);
                _Xml_d.Save("c:\\seniat\\XML_relacionRetencionesISLR_.xml");
            }
        }
        public void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 0)
            {
                if (_Mtd_RangoCorrectoIVA(_Dtp_Desde.Value, _Dtp_Hasta.Value))
                {
                    _Mtd_IVA(_Dtp_Desde.Value, _Dtp_Hasta.Value, "");
                    if (_Bol_Guardado)
                    { MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    { MessageBox.Show("No se encontraron registros dentro del rango elegido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                {
                    MessageBox.Show("Ya se han generado archivos con fechas que se encuentran entre el rango que usted eligió.\nVerifique y vuelva a intentarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (_Mtd_RangoCorrectoISLR(_Dtp_Desde.Value, _Dtp_Hasta.Value))
                {
                    _Mtd_ISLR(_Dtp_Desde.Value, _Dtp_Hasta.Value, "");
                    if (_Bol_Guardado)
                    { MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    { MessageBox.Show("No se encontraron registros dentro del rango elegido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                {
                    MessageBox.Show("Ya se han generado archivos con fechas que se encuentran entre el rango que usted eligió.\nVerifique y vuelva a intentarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void _Pnl_Guardar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Guardar.Visible)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                _Tb_Tab.Enabled = false;
                if (_Tb_Tab.SelectedIndex == 0)
                { _Lbl_Titulo.Text = "GENERACIÓN PARA IVA"; }
                else
                { _Lbl_Titulo.Text = "GENERACIÓN PARA ISLR"; }
            }
            else
            { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true; _Tb_Tab.Enabled = true; }
        }
        private void Frm_ArchivoSeniat_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Guardar.Left = (this.Width / 2) - (_Pnl_Guardar.Width / 2);
            _Pnl_Guardar.Top = (this.Height / 2) - (_Pnl_Guardar.Height / 2);
        }

        private void Frm_ArchivoSeniat_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = !_Pnl_Guardar.Visible;
        }

        private void Frm_ArchivoSeniat_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Cntx_Menu_IVA_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid_IVA.SelectedRows.Count == 0)
            { e.Cancel = true; }
            else
            {
                _Tool_Volver_IVA.Enabled = !(Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["cverificado"].Value).Trim() == "1");
                _Tool_Crear_IVA.Enabled = !(Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["cverificado"].Value).Trim() == "1");
                _Tool_Verificar_IVA.Enabled = !(Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["cverificado"].Value).Trim() == "1");
            }
        }

        private void _Cntx_Menu_ISLR_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid_ISLR.SelectedRows.Count == 0)
            { e.Cancel = true; }
            else
            {
                _Tool_Volver_ISLR.Enabled = !(Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["cverificado"].Value).Trim() == "1");
                _Tool_Crear_ISLR.Enabled = !(Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["cverificado"].Value).Trim() == "1");
                _Tool_Verificar_ISLR.Enabled = !(Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["cverificado"].Value).Trim() == "1");
            }
        }
        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Guardar.Visible = false;
        }

        private void _Bt_Consultar_IVA_Click(object sender, EventArgs e)
        {
            _Mtd_ActualizarIVA();
        }

        private void _Bt_Consultar_ISLR_Click(object sender, EventArgs e)
        {
            _Mtd_ActualizarISLR();
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Dtp_Desde_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Hasta.MinDate = _Dtp_Desde.Value;
        }
        private void _Dg_Grid_IVA_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo_IVA.Visible = true;
        }

        private void _Dg_Grid_IVA_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo_IVA.Visible = false;
        }

        private void _Dg_Grid_ISLR_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo_ISLR.Visible = true;
        }

        private void _Dg_Grid_ISLR_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo_ISLR.Visible = false;
        }

        private void _Cmb_Mes_IVA_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarMesesIVA();
        }

        private void _Cmb_Mes_ISLR_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarMesesISLR();
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

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Tb_Tab.SelectedIndex == 0)
                {
                    _Pnl_Clave.Visible = false;
                    _Mtd_Verificar_IVA(Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim());
                    _Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Verificado"].Value = "SÍ";
                    _Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["cverificado"].Value = "1";
                    MessageBox.Show("El periodo ha sido verificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Pnl_Clave.Visible = false;
                    _Mtd_Verificar_ISLR(Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim());
                    _Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Verificado"].Value = "SÍ";
                    _Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["cverificado"].Value = "1";
                    MessageBox.Show("El periodo ha sido verificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Tool_Volver_IVA_Click(object sender, EventArgs e)
        {
            _Mtd_IVA(Convert.ToDateTime(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Desde"].Value), Convert.ToDateTime(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Hasta"].Value), Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim());
            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void _Tool_Crear_IVA_Click(object sender, EventArgs e)
        {
            Thread _Thr_Thread = new Thread(new ThreadStart(delegate { _Mtd_CrearArchivoIVA(Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim()); }));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Por favor espere...");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
            MessageBox.Show("El archivo se ha creado correctamente.\n Se encuentra en C:\\seniat\\IVA.txt", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _Tool_Verificar_IVA_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Tool_Volver_ISLR_Click(object sender, EventArgs e)
        {
            _Mtd_ISLR(Convert.ToDateTime(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Desde"].Value), Convert.ToDateTime(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Hasta"].Value), Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim());
            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void _Tool_Crear_ISLR_Click(object sender, EventArgs e)
        {
            Thread _Thr_Thread = new Thread(new ThreadStart(delegate { _Mtd_CrearArchivoISLR(Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim()); }));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Por favor espere...");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
            MessageBox.Show("El archivo se ha creado correctamente.\n Se encuentra en C:\\seniat\\XML_relacionRetencionesISLR_.xml", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _Tool_Verificar_ISLR_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Tool_Ver_IVA_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(4, Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim(), Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Desde"].Value).Trim(), Convert.ToString(_Dg_Grid_IVA.Rows[_Dg_Grid_IVA.CurrentCell.RowIndex].Cells["Hasta"].Value).Trim());
            Cursor = Cursors.Default;
            _Frm_Inf.MdiParent = this.MdiParent;
            _Frm_Inf.Dock = DockStyle.Fill;
            _Frm_Inf.Show();
        }

        private void _Tool_Ver_ISLR_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(5, Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Archivo"].Value).Trim(), Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Desde"].Value).Trim(), Convert.ToString(_Dg_Grid_ISLR.Rows[_Dg_Grid_ISLR.CurrentCell.RowIndex].Cells["Hasta"].Value).Trim());
            Cursor = Cursors.Default;
            _Frm_Inf.MdiParent = this.MdiParent;
            _Frm_Inf.Dock = DockStyle.Fill;
            _Frm_Inf.Show();
        }
    }
}
