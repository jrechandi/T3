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
    public partial class Frm_FisicoVsTeorico : Form
    {
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_Id_Conteo = "";
        public Frm_FisicoVsTeorico()
        {
            InitializeComponent();
        }
        Frm_Busqueda2 _Frm_Busqueda2 = new Frm_Busqueda2();
        int _Int_Sw = 0;
        public Frm_FisicoVsTeorico(Frm_Busqueda2 _P_Frm_Busqueda2, int _P_Int_Sw, string _P_Str_Id_Conteo)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            _Frm_Busqueda2 = _P_Frm_Busqueda2;
            _Str_Id_Conteo = _P_Str_Id_Conteo;
            _Mtd_Actualizar();
        }
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else if (_Ctrl.Name != _Rb_Con.Name & _Ctrl.Name != _Rb_Sin.Name)
                { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
            }
        }
        private void _Mtd_Actualizar()
        {
            string _P_Str_Where = "";
            if (_Rb_Con.Checked)
            { _P_Str_Where = " AND (cajasdif<>0 OR unidif<>0)"; }
            else
            { _P_Str_Where = " AND (cajasdif=0 AND unidif=0)"; }
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Tarjeta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Producto");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "id_tarjetainv";
            _Str_Campos[1] = "cproducto";
            _Str_Campos[2] = "cnamefc";
            //string _Str_Cadena = "SELECT top ?sel id_tarjetainv AS Tarjeta, cproducto AS Producto, cnamefc AS Descripción, cajasconteo AS [Fís. Caj.], undconteo AS [Fís. Unid.], cexisrealu1 AS [Teó. Caj.],cexisrealu2 AS [Teó. Unid.],cajasdif AS [Dif. Caj.],unidif AS [Dif. Unid.],dbo.Fnc_Formatear(cmonto) AS [Dif. Bolívares] FROM VST_T3_CONTEOINVACT WHERE NOT id_tarjetainv IN (SELECT top ?omi id_tarjetainv FROM VST_T3_CONTEOINVACT WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _P_Str_Where + ") AND ccompany='" + Frm_Padre._Str_Comp + "'" + _P_Str_Where;
            string _Str_Cadena = "SELECT id_tarjetainv AS Tarjeta, cproducto AS Producto, cnamefc AS Descripción, cidproductod AS Lote, dbo.Fnc_Formatear(cprecioventamax) AS PMV, cajasconteo AS [Fís. Caj.], undconteo AS [Fís. Unid.], cexisrealu1 AS [Teó. Caj.],cexisrealu2 AS [Teó. Unid.],cajasdif AS [Dif. Caj.],unidif AS [Dif. Unid.],dbo.Fnc_Formatear(cmonto) AS [Dif. Bolívares] FROM VST_T3_CONTEOINVACT WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _P_Str_Where;
            //_Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Comparativo", _Tsm_Menu, _Dg_Grid, "VST_T3_CONTEOINVACT", "WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _P_Str_Where, 100, "ORDER BY id_tarjetainv");
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Comparativo", _Tsm_Menu, _Dg_Grid, true, "", "id_tarjetainv");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //----------------------------------------------------------------------------------------
            _Dg_Grid.Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(206, 206, 242);
            _Dg_Grid.Columns[6].DefaultCellStyle.BackColor = Color.FromArgb(206, 206, 242);
            _Dg_Grid.Columns[7].DefaultCellStyle.BackColor = Color.FromArgb(152, 152, 228);
            _Dg_Grid.Columns[8].DefaultCellStyle.BackColor = Color.FromArgb(152, 152, 228);
            _Dg_Grid.Columns[9].DefaultCellStyle.BackColor = Color.FromArgb(103, 103, 192);
            _Dg_Grid.Columns[10].DefaultCellStyle.BackColor = Color.FromArgb(103, 103, 216);
            _Dg_Grid.Columns[11].DefaultCellStyle.BackColor = Color.FromArgb(235, 233, 133);
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _Str_Cadena = "SELECT ISNULL(dbo.Fnc_Formatear(SUM(cmonto)),0) FROM VST_T3_CONTEOINVACT WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _P_Str_Where;
            _Txt_TotalBs.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_IgualarCajas()
        {
            if (_Dg_Grid.RowCount > 0 & _Dg_Grid.CurrentCell != null)
            {
                _Txt_Tarjeta.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Tarjeta.Tag = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Cajas.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[5].Value.ToString();
                _Txt_Unidades.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[6].Value.ToString();
            }
        }
        private bool _Mtd_AceptaUnidades(string _P_Str_Tarjeta)
        {
            string _Str_Cadena = "Select cimpr_u2 from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "' AND cimpr_u2='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ExistenciaTarjeta(string _P_Str_Tarjeta)
        {
            string _P_Str_Where = "";
            if (_Rb_Con.Checked)
            { _P_Str_Where = " AND (cajasdif<>0 OR unidif<>0)"; }
            else
            { _P_Str_Where = " AND (cajasdif=0 AND unidif=0)"; }
            string _Str_Cadena = "Select id_tarjetainv FROM VST_T3_CONTEOINVACT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_tarjetainv='" + _P_Str_Tarjeta + "'" + _P_Str_Where;
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_CurrentIndex(string _P_Str_Tarjeta)
        {
            DataGridViewCell _Dg_Cell;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() == _P_Str_Tarjeta.Trim())
                {
                    _Dg_Cell = _Dg_Row.Cells[0];
                    _Dg_Grid.CurrentCell = _Dg_Cell;
                    break;
                }
            }
        }
        private bool _Mtd_VerificarTercero(string _P_Str_Tarjeta)
        {
            string _Str_Cadena = "SELECT cconteo3 FROM TINVFISICOD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_tarjetainv='" + _P_Str_Tarjeta + "' AND cconteo3='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Ajustar(string _P_Str_Tarjeta, TextBox _P_Txt_Cajas, TextBox _P_Txt_Unidades)
        {
            string _Str_Cadena = "";
            if (_P_Txt_Cajas.Text.Trim().Length == 0)
            { _P_Txt_Cajas.Text = "0"; }
            if (_P_Txt_Unidades.Text.Trim().Length == 0)
            { _P_Txt_Unidades.Text = "0"; }
            if (_Mtd_VerificarTercero(_P_Str_Tarjeta))
            { _Str_Cadena = "UPDATE TINVFISICOD SET cantcont1_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont2_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont3_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont1_u2='" + _P_Txt_Unidades.Text.Trim() + "',cantcont2_u2='" + _P_Txt_Unidades.Text.Trim() + "',cantcont3_u2='" + _P_Txt_Unidades.Text.Trim() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_tarjetainv='" + _P_Str_Tarjeta + "'"; }
            else
            { _Str_Cadena = "UPDATE TINVFISICOD SET cantcont1_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont2_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont1_u2='" + _P_Txt_Unidades.Text.Trim() + "',cantcont2_u2='" + _P_Txt_Unidades.Text.Trim() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_tarjetainv='" + _P_Str_Tarjeta + "'"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TINVFISICOHISTM SET cfinalizado='2' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_conteohist='" + _Str_Id_Conteo + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Crear_TINVFISICOTEOHIST(int _P_Int_id_conteohist)
        {
            string _Str_Cadena = "Select id_tarjetainv,cantcont1_u1,cantcont1_u2,ccontenidoma1,ccontenidoma2,cunidad2,cimpr_u2,cexisrealu1,cexisrealu2,ccostoneto_u1,ccostoneto_u2,cproducto,cantcont3_u1,cantcont3_u2,cconteo3 from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    bool _Bol_3erConteo = false;
                    if (_Row["cconteo3"].ToString() == "1")
                    {
                        _Bol_3erConteo = true;
                    }
                    else
                    {
                        _Bol_3erConteo = false;
                    }
                    string _Str_AjustEntr = "0";
                    string _Str_AjustSal = "0";
                    int _Int_Cajas1 = 0;
                    int _Int_Unidad1 = 0;
                    int _Int_Cajas2 = 0;
                    int _Int_Unidad2 = 0;
                    double _Dbl_DiferenciaEnUnidades = 0;
                    double _Dbl_Costo_Unidades = 0;
                    double _Dbl_Costo_Cajas = 0;
                    double _Dbl_Costo_Total = 0;
                    int _Int_UnidadesPorCaja = 0;
                    int _Int_TotalUnidadesPorProducto1 = 0;
                    int _Int_TotalUnidadesPorProducto2 = 0;
                    int _Int_TotalCajas = 0;
                    int _Int_TotalUnidades = 0;
                    if (_Bol_3erConteo)
                    {
                        if (_Row["cantcont3_u1"] != System.DBNull.Value)
                        { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont3_u1"].ToString()); }
                    }
                    else
                    {
                        if (_Row["cantcont1_u1"] != System.DBNull.Value)
                        { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont1_u1"].ToString()); }
                    }
                    if (_Bol_3erConteo)
                    {
                        if (_Row["cantcont3_u2"] != System.DBNull.Value)
                        { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont3_u2"].ToString()); }
                    }
                    else
                    {
                        if (_Row["cantcont1_u2"] != System.DBNull.Value)
                        { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont1_u2"].ToString()); }
                    }
                    if (_Row["cexisrealu1"] != System.DBNull.Value)
                    { _Int_Cajas2 = Convert.ToInt32(_Row["cexisrealu1"].ToString()); }
                    if (_Row["cexisrealu2"] != System.DBNull.Value)
                    { _Int_Unidad2 = Convert.ToInt32(_Row["cexisrealu2"].ToString()); }
                    if (_Row["ccontenidoma1"] != System.DBNull.Value)
                    { _Int_UnidadesPorCaja = Convert.ToInt32(_Row["ccontenidoma1"].ToString()); }
                    if (_Row["ccostoneto_u1"] != System.DBNull.Value)
                    { _Dbl_Costo_Cajas = Convert.ToDouble(_Row["ccostoneto_u1"].ToString()); }
                    if (_Row["cunidad2"] != System.DBNull.Value)
                    {
                        if (_Row["cunidad2"].ToString().TrimEnd() == "1")
                        {
                            if (_Row["ccontenidoma2"].ToString().TrimEnd() != "")
                            {
                                if (_Row["ccontenidoma2"].ToString().TrimEnd() != "0")
                                {
                                    if (Convert.ToInt32(_Row["ccontenidoma2"].ToString().TrimEnd()) > 0)
                                    {
                                        _Dbl_Costo_Unidades = _Dbl_Costo_Cajas / (Convert.ToInt32(_Row["ccontenidoma1"].ToString().TrimEnd()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString().TrimEnd()));
                                    }
                                }
                            }
                        }
                        else
                        {
                            _Dbl_Costo_Unidades = 0;
                        }
                    }
                    if (_Row["cimpr_u2"].ToString().Trim() == "1")
                    {
                        _Int_TotalUnidadesPorProducto1 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas1, _Int_Unidad1));
                        _Int_TotalUnidadesPorProducto2 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas2, _Int_Unidad2));
                        if (_Int_TotalUnidadesPorProducto2 > _Int_TotalUnidadesPorProducto1)
                        {
                            _Str_AjustSal = "1";
                            _Str_AjustEntr = "0";
                            _Dbl_DiferenciaEnUnidades = (-1) * Convert.ToDouble(_Int_TotalUnidadesPorProducto2 - _Int_TotalUnidadesPorProducto1);
                        }
                        else
                        {
                            _Str_AjustEntr = "1";
                            _Str_AjustSal = "0";
                            _Dbl_DiferenciaEnUnidades = Convert.ToDouble(_Int_TotalUnidadesPorProducto1 - _Int_TotalUnidadesPorProducto2);
                        }
                        if (_Dbl_Costo_Unidades > 0)
                        {
                            _Dbl_Costo_Total = _Dbl_DiferenciaEnUnidades * _Dbl_Costo_Unidades;
                        }
                        else
                        {
                            double _Dbl_DifCajas = 0;
                            _Dbl_DifCajas = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                            _Dbl_Costo_Total = _Dbl_DifCajas * _Dbl_Costo_Cajas;
                        }
                        if (_Dbl_DiferenciaEnUnidades < 0)
                        {
                            _Int_TotalCajas = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades * (-1)), 0));
                            _Int_TotalCajas = _Int_TotalCajas * (-1);
                        }
                        else
                        {
                            _Int_TotalCajas = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                        }
                        if (_Dbl_DiferenciaEnUnidades < 0)
                        {
                            _Int_TotalUnidades = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades * (-1))));
                            _Int_TotalUnidades = _Int_TotalUnidades * (-1);
                        }
                        else
                        {
                            _Int_TotalUnidades = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades)));
                        }
                        if (_Dbl_DiferenciaEnUnidades != 0)
                        {
                            _Str_Cadena = "Insert into TINVFISICOTEOHIST (ccompany,id_conteohist,id_tarjetainv,cconteocajas,cconteounid,ccajas,cunidad,ccostonetocaj,ccostonetounid,cdifrenciacajas,cdifrenciaunid,ccostoinvent,cnecajussal,cnecajusent,cajustado) values ('" + Frm_Padre._Str_Comp + "','" + _P_Int_id_conteohist.ToString() + "','" + _Row["id_tarjetainv"].ToString().Trim() + "','" + _Int_Cajas1.ToString() + "','" + _Int_Unidad1.ToString() + "','" + _Int_Cajas2.ToString() + "','" + _Int_Unidad2 + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Cajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Unidades) + "','" + _Int_TotalCajas.ToString() + "','" + _Int_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Total) + "','" + _Str_AjustSal + "','" + _Str_AjustEntr + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        if (_Int_Cajas2 > _Int_Cajas1)
                        {
                            _Str_AjustSal = "1";
                            _Int_TotalCajas = (-1) * (_Int_Cajas2 - _Int_Cajas1);
                        }
                        else
                        {
                            _Str_AjustEntr = "1";
                            _Int_TotalCajas = _Int_Cajas1 - _Int_Cajas2;
                        }
                        _Dbl_Costo_Total = _Int_TotalCajas * _Dbl_Costo_Cajas;
                        if (_Int_TotalCajas != 0)
                        {
                            _Str_Cadena = "Insert into TINVFISICOTEOHIST (ccompany,id_conteohist,id_tarjetainv,cconteocajas,cconteounid,ccajas,cunidad,ccostonetocaj,ccostonetounid,cdifrenciacajas,cdifrenciaunid,ccostoinvent,cnecajussal,cnecajusent,cajustado) values ('" + Frm_Padre._Str_Comp + "','" + _P_Int_id_conteohist.ToString() + "','" + _Row["id_tarjetainv"].ToString().Trim() + "','" + _Int_Cajas1.ToString() + "','" + _Int_Unidad1.ToString() + "','" + _Int_Cajas2.ToString() + "','" + _Int_Unidad2 + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Cajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Unidades) + "','" + _Int_TotalCajas.ToString() + "','" + _Int_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Total) + "','" + _Str_AjustSal + "','" + _Str_AjustEntr + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
            }
        }
        private void _Mtd_Ajustar(string _Str_HistoricoAjuste)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int _Int_ConteoHist = Convert.ToInt32(_Str_HistoricoAjuste);
                SqlParameter[] _Sql_Parametros = new SqlParameter[2];
                _Sql_Parametros[0] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _Sql_Parametros[0].Value = Frm_Padre._Str_Comp;
                _Sql_Parametros[1] = new SqlParameter("@id_conteohist", SqlDbType.Real);
                _Sql_Parametros[1].Value = _Int_ConteoHist;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_AJUSTEPORCONTEOHISTORICO", _Sql_Parametros);
                string _Str_SentenciaSQL = "update TINVFISICOHISTM set cfinalizado='3' where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Str_HistoricoAjuste + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                string _Str_Cadena = "Delete from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Delete from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                if (!_Frm_Busqueda2.IsDisposed)
                {
                    if (_Int_Sw == 5)
                    { _Frm_Busqueda2._Mtd_Actualizar_Sw5(); }
                    else
                    { _Frm_Busqueda2._Mtd_Actualizar_Sw31(); }
                }
                if (this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                MessageBox.Show("El inventario se ha cerrado correctamente ya que no existe diferencias entre el físico y el teórico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bol_Cerrar = true;
               this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hubo un error de tipo " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _Mtd_Finalizar()
        {
            _Pnl_Clave.Visible = false;
            int _Int_Numero = 0;
            string _Str_Cadena1 = "DELETE FROM TINVFISICOHISTM where id_conteohist='" + _Str_Id_Conteo + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1);
            _Str_Cadena1 = "DELETE FROM TINVFISICOHISTD where id_conteohist='" + _Str_Id_Conteo + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1);
            _Str_Cadena1 = "DELETE FROM TINVFISICOTEOHIST where id_conteohist='" + _Str_Id_Conteo + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1);
            _Int_Numero = Convert.ToInt32(_Str_Id_Conteo);
            string _Str_Cadena = "SELECT cdate from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";

            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                DataRow _Rows = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                _Str_Cadena = "INSERT INTO TINVFISICOHISTM (ccompany,id_conteohist,cdate,cfinalizado) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Numero + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Rows[0].ToString())) + "','1')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "INSERT INTO TINVFISICOHISTD(ccompany,id_conteohist,id_tarjetainv,cproveedor,csubgrupo,cgrupo,csku,cproducto,cdate,cyearacco,cmontacco,cimpr_u2,cantcont1_u1,cantcont1_u2,cconteo1,cantcont2_u1,cantcont2_u2,cconteo2,cdiferencaj,cdiferenunid,cantcont3_u1,cantcont3_u2,cconteo3,cidproductod) Select '" + Frm_Padre._Str_Comp + "','" + _Int_Numero.ToString() + "',id_tarjetainv,cproveedor,csubgrupo,cgrupo,csku,cproducto,cdate,cyearacco,cmontacco,cimpr_u2,cantcont1_u1,cantcont1_u2,cconteo1,cantcont2_u1,cantcont2_u2,cconteo2,cdiferencaj,cdiferenunid,cantcont3_u1,cantcont3_u2,cconteo3,cidproductod from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //-------------------------------------------------------------------------
                _Mtd_Crear_TINVFISICOTEOHIST(_Int_Numero);
                //-------------------------------------------------------------------------
                //if (MessageBox.Show("¿Desea imprimir el reporte comparativo?", "Infomación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //{
                //    PrintDialog _Print = new PrintDialog();
                //    if (_Print.ShowDialog() == DialogResult.Yes)
                //    {
                //        REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICOREPORTE" }, "", "T3.Report.rComparativo", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'", _Print, true);
                //    }
                //}
                 _Str_Cadena = "SELECT ccompany FROM VST_INVENTARIOFISICOREPORTE WHERE ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'";
                 if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                 {
                     MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     if (!_Frm_Busqueda2.IsDisposed)
                     {
                         if (_Int_Sw == 5)
                         { _Frm_Busqueda2._Mtd_Actualizar_Sw5(); }
                         else
                         { _Frm_Busqueda2._Mtd_Actualizar_Sw31(); }
                     }
                     if (this.MdiParent != null)
                     {
                         System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                     }
                     _Bol_Cerrar = true;
                     this.Close();
                 }
                 else
                 {
                     _Mtd_Ajustar(_Int_Numero.ToString());
                 }
            }
        }
        private void Frm_FisicoVsTeorico_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Conteo.Left = (this.Width / 2) - (_Pnl_Conteo.Width / 2);
            _Pnl_Conteo.Top = (this.Height / 2) - (_Pnl_Conteo.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted();
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            string _P_Str_Where = "";
            if (_Rb_Con.Checked)
            { _P_Str_Where = " AND (cajasdif<>0 OR unidif<>0)"; }
            else
            { _P_Str_Where = " AND (cajasdif=0 AND unidif=0)"; }
            string _Str_Cadena = "SELECT ccompany,'1' AS id_conteohist,id_tarjetainv,cajasconteo AS cconteocajas,undconteo AS cconteounid,cexisrealu1 AS ccajas,cexisrealu2 AS cunidad,'1' AS ccostonetocaj,'1' AS ccostonetounid,cajasdif AS cdifrenciacajas,unidif AS cdifrenciaunid,cmonto AS ccostoinvent,cproducto,cnamefc as cnamef,GETDATE() as cdate,'0' AS cpresentacion, CCODFABRICA,cidproductod,cprecioventamax FROM VST_T3_CONTEOINVACT AS VST_INVENTARIOFISICOREPORTE WHERE ccompany='" + Frm_Padre._Str_Comp + "'" + _P_Str_Where;
            PrintDialog _Prin = new PrintDialog();
            if (_Prin.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm = new REPORTESS("T3.Report.rComparativo", Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0], _Prin, true, "Section1", "cabecera", "rif", "nit");
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Finalizar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void _Txt_Tarjeta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Tarjeta.Text))
            {
                _Txt_Tarjeta.Text = "";
            } 
        }

        private void _Txt_Cajas_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Cajas.Text))
            {
                _Txt_Cajas.Text = "";
            }
            else
            {
                int _Int_Temp = 0;
                if (!int.TryParse(_Txt_Cajas.Text, out _Int_Temp) || _Int_Temp < 0)
                {
                    _Txt_Cajas.Text = "";
                }
            }
        }

        private void _Txt_Unidades_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Unidades.Text))
            {
                _Txt_Unidades.Text = "";
            }
            else
            {
                int _Int_Temp = 0;
                if (!int.TryParse(_Txt_Unidades.Text, out _Int_Temp) || _Int_Temp < 0)
                {
                    _Txt_Unidades.Text = "";
                }
            }
        }

        private void _Txt_Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    _Bt_Tarjeta.Focus();
                    _Bt_Tarjeta.PerformClick();
                }
            }
        }

        private void _Txt_Cajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    _Txt_Cajas.Enabled = false;
                    if (_Txt_Cajas.Text.Trim().Length == 0)
                    { _Txt_Cajas.Text = "0"; }
                    if (_Mtd_AceptaUnidades(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()))
                    { _Txt_Unidades.Enabled = true; _Txt_Unidades.Focus(); }
                    else
                    { _Bt_Ajustar.Focus(); }
                }
            }
        }

        private void _Txt_Unidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    _Txt_Unidades.Enabled = false;
                    if (_Txt_Unidades.Text.Trim().Length == 0)
                    { _Txt_Unidades.Text = "0"; }
                    int _Int_Dbunidades = Convert.ToInt32(_MyUtilidad._Mtd_ProductoUndManejo2(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString()));
                    int _Int_Undidades = Convert.ToInt32(((TextBox)sender).Text);
                    if (_Int_Undidades >= _Int_Dbunidades)
                    {
                        MessageBox.Show("La cantidad de unidades debe ser inferior a " + _Int_Dbunidades.ToString() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Txt_Unidades.Text = "0";
                        _Txt_Unidades.Enabled = true;
                    }
                    else
                    { _Bt_Ajustar.Focus(); }
                }
            }
        }

        private void _Txt_Tarjeta_MouseUp(object sender, MouseEventArgs e)
        {
            _Txt_Tarjeta.Select(0, _Txt_Tarjeta.Text.Length);
        }

        private void _Bt_Tarjeta_Click(object sender, EventArgs e)
        {
            if (_Txt_Tarjeta.Text.Trim().Length > 0)
            {
                if (_Mtd_ExistenciaTarjeta(_Txt_Tarjeta.Text))
                {
                    _Mtd_Actualizar();
                    _Txt_Tarjeta.Tag = _Txt_Tarjeta.Text;
                    _Mtd_CurrentIndex(_Txt_Tarjeta.Text);
                    _Mtd_IgualarCajas();
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Selected = true;
                    _Txt_Cajas.Enabled = true;
                    _Txt_Cajas.Focus();
                    _Txt_Cajas.Select(0, _Txt_Cajas.Text.Length);
                }
                else
                { MessageBox.Show("Tarjeta inválida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Txt_Tarjeta.Text = Convert.ToString(_Txt_Tarjeta.Tag); _Txt_Tarjeta.Focus(); }
            }
            else
            { _Txt_Tarjeta.Text = Convert.ToString(_Txt_Tarjeta.Tag); }
        }

        private void ajustarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Mtd_IgualarCajas();
            _Pnl_Conteo.Visible = true;
        }

        private void _Bt_Ajustar_Click(object sender, EventArgs e)
        {
            int _Int_RowCount = _Dg_Grid.RowCount;
            _Mtd_Ajustar(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value), _Txt_Cajas, _Txt_Unidades);
            _Mtd_Actualizar();
            if (_Dg_Grid.RowCount > 0 & (_Dg_Grid.RowCount == _Int_RowCount))
            {
                _Mtd_CurrentIndex(_Txt_Tarjeta.Text);
                _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Selected = true;
            }
            _Mtd_IgualarCajas();
            _Txt_Tarjeta.Focus();
            if (_Dg_Grid.RowCount == 0)
            { _Pnl_Conteo.Visible = false; }
            if (!_Frm_Busqueda2.IsDisposed)
            {
                if (_Int_Sw == 5)
                { _Frm_Busqueda2._Mtd_Actualizar_Sw5(); }
                else
                { _Frm_Busqueda2._Mtd_Actualizar_Sw31(); }
            }
        }

        private void _Pnl_Conteo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Conteo.Visible)
            {
                _Txt_Cajas.Enabled = false;
                _Txt_Unidades.Enabled = false;
                _Txt_Tarjeta.Focus();
                _Dg_Grid.Enabled = false;
                _Pnl_Inferior.Enabled = false;
                _Ctrl_Busqueda1.Enabled = false;
                _Rb_Con.Enabled = false;
                _Rb_Sin.Enabled = false;
            }
            else
            {
                _Dg_Grid.Enabled = true;
                _Pnl_Inferior.Enabled = true;
                _Ctrl_Busqueda1.Enabled = true;
                _Rb_Con.Enabled = true;
                _Rb_Sin.Enabled = true;
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
                _Dg_Grid.Enabled = false;
                _Pnl_Inferior.Enabled = false;
            }
            else
            {
                _Dg_Grid.Enabled = true;
                _Pnl_Inferior.Enabled = true;
            }
        }
        private bool _Mtd_VerificarCierre()
        {
            string _Str_Cadena = "SELECT id_conteo FROM TINVFISICOM WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        bool _Bol_Cerrar = false;
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Mtd_VerificarCierre())
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Finalizar();
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Se ha cerrado el inventario desde otra máquina", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Bol_Cerrar = true;
                    this.Close();
                }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Cancelar_1_Click(object sender, EventArgs e)
        {
            _Pnl_Conteo.Visible = false;
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Conteo.Visible = false;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Rb_Con_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Con.Checked)
            { _Mtd_Actualizar(); }
        }

        private void _Rb_Sin_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Sin.Checked)
            { _Mtd_Actualizar(); }
        }

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                        _MyExcel._Mtd_DatasetToExcel((DataTable)_Dg_Grid.DataSource, _Sfd_1.FileName, "COMPTIVO_" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString(), _Dg_Grid.Columns);
                        _MyExcel = null;
                        Cursor = Cursors.Default;
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void Frm_FisicoVsTeorico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(e.CloseReason == CloseReason.MdiFormClosing) & !(e.CloseReason == CloseReason.ApplicationExitCall))
            {
                if (!_Bol_Cerrar)
                {
                    e.Cancel = true;
                    if (!_Pnl_Clave.Visible)
                    {
                        if (MessageBox.Show("¿Esta seguro de finalizar el proceso?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Pnl_Clave.Visible = true;
                        }
                    }
                }
            }
        }

        private void Frm_FisicoVsTeorico_Shown(object sender, EventArgs e)
        {
            if (!(_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_FINAL")))
            {
                MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _Bol_Cerrar = true;
                this.Close();
            }
        }

        private void Frm_FisicoVsTeorico_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

    }
}
