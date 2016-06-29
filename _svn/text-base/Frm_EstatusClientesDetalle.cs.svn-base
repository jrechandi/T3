using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace T3
{
    public partial class Frm_EstatusClientesDetalle : Form
    {
        string _Str_Rif = "";
        int _Int_Sw = 0;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        Frm_EstatusClientes _Frm_Formulario;
        int _Int_Estatus = 0;
        string _Str_Cliente = "";
        public Frm_EstatusClientesDetalle()
        {
            InitializeComponent();

        }
        string _Str_CompaniaTemp = "";
        string _Str_PedidoTemp = "";
        public Frm_EstatusClientesDetalle(string _P_Str_CodCliente, string _P_Str_Rif, string _P_Str_Descripcion, int _P_Int_Estatus, string _P_Str_Cliente,Frm_EstatusClientes _P_Frm_Formulario)
        {
            InitializeComponent();
            _Str_Comps = CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp(); 
            _Frm_Formulario=_P_Frm_Formulario;
            _Str_Rif = _P_Str_Rif;
            _Int_Estatus = _P_Int_Estatus;
            _Str_Cliente = _P_Str_Cliente;
            _Txt_Codigo.Text = _P_Str_CodCliente.Trim();
            _Txt_Cliente.Text = _P_Str_Descripcion.Trim();
            _Mtd_Cargar(_P_Str_CodCliente);
            bool _Bol_Sw = false;
            string _Str_Sql = "";
            DataSet _Ds = new DataSet();
            try
            {
                _Str_Sql = "SELECT cvendedor FROM VST_RELCOBRANZA_CLIENTESCONPEDIDOSBLOQUEADOS WHERE " + _Str_Comps + " AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_Codigo.Text.Trim() + "' AND caprobado=1 AND caprobadocredito=0 AND crelalista=1";
                _Ds = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Bol_Sw = true;
                }
            }
            catch { }
            _Str_Sql = "SELECT cvendedor FROM VST_T3_COBRANZASCLIENTEDESBPEDIDOS WHERE " + _Str_Comps + " AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_Codigo.Text + "' AND ccerrada='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Sw = true;
            }
            _Bt_ConsultaCobros.Visible = _Bol_Sw;
        }
        private void _Mtd_Cargar(string _P_Str_Cliente)
        {
            _Mtd_Actualizar_Dg_GridDocumentos(_P_Str_Cliente);
            _Mtd_Actualizar_Dg_GridCheques(_P_Str_Cliente);
            _Mtd_Dg_GridPedidos(_P_Str_Cliente);
        }
        private void _Mtd_Actualizar_Dg_GridDocumentos(string _P_Str_Cliente)
        {
            string _Str_Cadena = "EXEC PA_DOC_PENDIENTES_CLIENT '" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridDocumentos.DataSource = _Ds.Tables[0];
            _Dg_GridDocumentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Dg_GridCheques(string _P_Str_Cliente)
        {
            string _Str_CompsTem = _Str_Comps.Replace("ccompany", "TCHEQDEVUELT.ccompany");
            string _Str_Cadena = "SELECT convert(varchar, TCHEQDEVUELT.cfechaemision,103) as cfechaemision, RTRIM(TCHEQDEVUELT.cnumcheque) AS cnumcheque, RTRIM(TBANCO_2.cname) as cname1, TCHEQDEVUELT.cnumdocu, convert(varchar, TCHEQDEVUELT.cfechadevcheq,103) as cfechacheq, " +
"RTRIM(TBANCO_1.cname) AS cname2, TVENDEDOR.cvendedor + ' - ' + TVENDEDOR.cname AS vend, dbo.Fnc_Formatear(cmontocheq) AS Monto, TMOTIVO.CDESCRIPCION AS CMOTIVOCHQDEV " +
" From TCHEQDEVUELT INNER JOIN"+
                    "  TMOTIVO ON TMOTIVO.cidmotivo = TCHEQDEVUELT.cidmotivo INNER JOIN "+
                      " TVENDEDOR ON TCHEQDEVUELT.ccompany = TVENDEDOR.ccompany AND "+
                      " TCHEQDEVUELT.cvendedor = TVENDEDOR.cvendedor INNER JOIN "+
                      " TSALDOCLIENTED ON TCHEQDEVUELT.cgroupcomp = TSALDOCLIENTED.cgroupcomp AND  "+
                      " TCHEQDEVUELT.ccompany = TSALDOCLIENTED.ccompany AND TCHEQDEVUELT.cnumcheque = TSALDOCLIENTED.cnumdocu AND  "+
                      " TCHEQDEVUELT.ccliente = TSALDOCLIENTED.ccliente INNER JOIN "+
                     "  TCONFIGCXC ON TCHEQDEVUELT.ccompany = TCONFIGCXC.ccompany AND  "+
                      " TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdoccheqdev LEFT OUTER JOIN "+
                     "  TBANCO AS TBANCO_2 ON TCHEQDEVUELT.ccompany = TBANCO_2.ccompany AND  "+
                      " TCHEQDEVUELT.cbancocheque = TBANCO_2.cbanco LEFT OUTER JOIN "+
                     "  TBANCO AS TBANCO_1 ON TCHEQDEVUELT.ccompany = TBANCO_1.ccompany AND  "+
                     "  TCHEQDEVUELT.cbancochequedev = TBANCO_1.cbanco " +
"WHERE " + _Str_CompsTem + " AND (TCHEQDEVUELT.ccliente ='" + _P_Str_Cliente + "') AND (TCHEQDEVUELT.cactivo='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridCheques.DataSource = _Ds.Tables[0];
            _Dg_GridCheques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private double _Mtd_TotalEfectividad()
        {
            double _Dbl_Efectividad = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPedidos.Rows)
            {
                if (_Dg_Row.Cells["cefectividad2"].Value != null)
                {
                    _Dbl_Efectividad = _Dbl_Efectividad + Convert.ToDouble(_Dg_Row.Cells["cefectividad2"].Value);
                }
            }
            return _Dbl_Efectividad;
        }
        string _Str_Pedidos = "";
        private double _Mtd_Cargar_PedBackorder(string _P_Str_Cliente)
        {
            double _Dbl_Monto = 0;
            string _Str_Sql = "SELECT convert(varchar, c_fecha_pedido,103) as c_fecha_pedido,cpedido,cnamefpago,cempaques,dbo.Fnc_Formatear(c_monto_si+c_impuesto) as c_montotot,CCLIENTE, ccompany FROM VST_PEDIDOSBACKORDER WHERE " + _Str_Comps + " AND ccliente='" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_PedBackOrder.DataSource = _Ds.Tables[0];
            _Dg_PedBackOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Str_Sql = "SELECT SUM(c_monto_si+c_impuesto) FROM VST_PEDIDOSBACKORDER WHERE " + _Str_Comps + " AND ccliente='" + _P_Str_Cliente + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count>0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Txt_BackOrderBloqueados.Text = _Dbl_Monto.ToString("#,##0.00");
            return _Dbl_Monto;
        }
        private void _Mtd_Dg_GridPedidos(string _P_Str_Cliente)
        {
            double _Dbl_PedBackOrder = 0;
            string _Str_Cadena = "Select convert(varchar, c_fecha_pedido,103) as c_fecha_pedido,cpedido,cnamefpago,cempaques,dbo.Fnc_Formatear(c_montotot_si+c_impuesto) as c_montotot,cefectividad as cefectividad2,cvendedor + ' - '+cnamevendedor as vend, cruta, ccompany from VST_T3_PEDIDOSPORAPROBARCREDITO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND " + _Str_Comps + " and isnull(caprobadocredito,0)=0 and ccliente='" + _P_Str_Cliente + "' order by cpedido,c_fecha_pedido DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridPedidos.DataSource = _Ds.Tables[0];
            _Dg_GridPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Str_Cadena = "Select SUM(c_montotot_si),SUM(c_impuesto) from VST_T3_PEDIDOSPORAPROBARCREDITO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND " + _Str_Comps + " AND ccliente='" + _P_Str_Cliente + "' and isnull(caprobadocredito,0)=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_PedidosBloqueados = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_PedidosBloqueados = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                {
                    _Dbl_PedidosBloqueados = _Dbl_PedidosBloqueados + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                }
            }
            _Txt_PedidosBloqueados.Text = _Dbl_PedidosBloqueados.ToString("#,##0.00");
            _Str_Cadena = "SELECT SUM(csaldopendi) FROM TSALDOCLIENTEM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _P_Str_Cliente + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_SaldoPorCobrar = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_SaldoPorCobrar = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            _Str_Cadena = "SELECT SUM(c_montotot_si) FROM TPREFACTURAM WHERE " + _Str_Comps + " AND ccliente='" + _P_Str_Cliente + "' AND cfacturado='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_SaldoPorCobrar = _Dbl_SaldoPorCobrar + Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            _Txt_SaldoPorCobrar.Text = _Dbl_SaldoPorCobrar.ToString("#,##0.00");
            _Dbl_PedBackOrder = _Mtd_Cargar_PedBackorder(_P_Str_Cliente);
            _Str_Cadena = "SELECT TLIMITCREDITO.climtehasta " +
"FROM TCLIENTE INNER JOIN " +
"TLIMITCREDITO ON TCLIENTE.c_limt_credit = TLIMITCREDITO.ccodlimite " +
"WHERE (TCLIENTE.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TCLIENTE.ccliente = '" + _P_Str_Cliente + "') AND (TCLIENTE.c_rif = '" + _Str_Rif + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_Limite = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_Limite = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            _Prb_Limite.Maximum = Convert.ToInt32(_Dbl_Limite);
            _Txt_Limite.Text = _Dbl_Limite.ToString("#,##0.00");
            _Str_Cadena = "Select cporcsobregiro from TCONFIGCXC where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_Sobregiro = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_Sobregiro = (_Dbl_Limite * Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString())) / 100;
                }
            }
            _Prb_Sobregiro.Maximum = Convert.ToInt32(_Dbl_Sobregiro);
            _Txt_Sobregiro.Text = _Dbl_Sobregiro.ToString("#,##0.00");
            double _Dbl_Monto = _Dbl_SaldoPorCobrar + _Dbl_PedidosBloqueados + _Dbl_PedBackOrder;
            if (_Dbl_Monto ==_Dbl_Limite)
            { 
                _Prb_Limite.Value = _Prb_Limite.Maximum;
                _Bt_Aprobar.Enabled = true;
            }
            else if (_Dbl_Monto > _Dbl_Limite)
            {
                _Prb_Limite.Value = _Prb_Limite.Maximum;
                double _Dbl_Diferencia = _Dbl_Monto - _Dbl_Limite;
                if (_Dbl_Diferencia <= _Dbl_Sobregiro)
                {
                    _Prb_Sobregiro.Value = Convert.ToInt32(_Dbl_Diferencia);
                    _Bt_Aprobar.Enabled = true;
                }
                else
                { _Prb_Sobregiro.Value = _Prb_Sobregiro.Maximum; }
            }
            else
            {
                _Prb_Limite.Value = Convert.ToInt32(_Dbl_Monto);
            }
            if (_Dg_GridPedidos.Rows.Count == 0)
            { _Bt_Aprobar.Enabled = false; }
        }
        
        //private bool _Mtd_VerificarIgualacion()
        //{
        //    if (_Dbl_Saldo == _Dbl_Saldo2 & _Dbl_Pedido == _Dbl_Pedido2 & _Dbl_Limites == _Dbl_Limite2 & _Dbl_Sobregiros == _Dbl_Sobregiro2 & _Dbl_Toal_Efectividad == _Dbl_Toal_Efectividad2)
        //    { return true; }
        //    else
        //    { return false; }
        //}
        private string _Mtd_Imp_Selec()
        {
            string _Str_Cadena = " and (";
            bool _Bol_String = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPedidos.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    _Str_Cadena = _Str_Cadena + "cpedido='" + _Dg_Row.Cells[1].Value.ToString().Trim() + "' or ";
                    _Bol_String = true;
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 4);
            if (_Bol_String)
            {
                return _Str_Cadena + ")";
            }
            else
            {
                return "";
            }
        }
        private void _Mtd_Rechazar(string _P_Str_Pedidos,string _P_Str_Company)
        {
            if (_Str_Pedidos.Trim().Length > 0)
            {
                string _Str_Cadena = "Update TCOTPEDFACM set cstatus='7',cdateupd=getdate() where ccompany='" + _P_Str_Company + "' and cpedido='" + _P_Str_Pedidos + "' and CCOTIZACION='" + _P_Str_Pedidos + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private bool _Mtd_PedidoNoEvaluandose(string _Str_Usuario, string _Str_Pedido, string _Str_Compania)
        {
            bool _Bol_Valido = true;
            //try
            //{
            //    int _Int_Maestra = 0;
            //    int _Int_Detalle = 0;
            //    int _Int_Pedido = 0;
            //    string _Str_SQL = "SELECT CPFACTURA FROM TPREFACTURAM WHERE CPEDIDO='" + _Str_Pedido + "' AND CCOMPANY='" + _Str_Compania + "'";
            //    DataSet _Ds_DataSet = new DataSet();
            //    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            //    _Int_Maestra = _Ds_DataSet.Tables[0].Rows.Count;
            //    _Str_SQL = "SELECT CPFACTURA FROM TPREFACTURAD WHERE CPEDIDO='" + _Str_Pedido + "' AND CCOMPANY='" + _Str_Compania + "'";
            //    _Ds_DataSet = new DataSet();
            //    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            //    _Int_Detalle = _Ds_DataSet.Tables[0].Rows.Count;
            //    _Str_SQL = "SELECT CPEDIDO FROM TCOTPEDFACM WHERE CPEDIDO='" + _Str_Pedido + "' AND CCOMPANY='" + _Str_Compania + "' AND CEVALUACION='1'";
            //    _Ds_DataSet = new DataSet();
            //    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            //    _Int_Pedido = _Ds_DataSet.Tables[0].Rows.Count;
            //    if (_Int_Pedido > 0)
            //    {
            //        if (_Int_Maestra == 0 && _Int_Detalle > 0)
            //        {
            //            _Bol_Valido = false;
            //        }
            //        if (_Int_Maestra > 0 && _Int_Detalle == 0)
            //        {
            //            _Bol_Valido = false;
            //        }
            //        if (_Int_Maestra > 0 && _Int_Detalle > 0)
            //        {
            //            _Bol_Valido = true;
            //        }
            //        if (_Int_Maestra == 0 && _Int_Detalle == 0)
            //        {
            //            _Bol_Valido = false;
            //        }
            //    }
            //    if (!_Bol_Valido)
            //    {
            //        SqlParameter[] paramsToStore = new SqlParameter[2];
            //        paramsToStore[0] = new SqlParameter("@CNUMCPEDIDO", SqlDbType.Int);
            //        paramsToStore[0].Value = _Str_Pedido;
            //        paramsToStore[1] = new SqlParameter("@CCOMPANY", SqlDbType.VarChar);
            //        paramsToStore[1].Value = _Str_Compania;
            //        CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_ELIMINAR_PREFACTURA_MAL", paramsToStore);
            //        while (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT CNUMPEDIDO FROM TTEMPPEDIDO WHERE CNUMPEDIDO='" + _Str_Pedido + "' AND CCOMPANY='" + _Str_Compania + "'").Tables[0].Rows.Count>0)
            //        {
            //            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("DELETE FROM TTEMPPEDIDO WHERE CNUMPEDIDO='" + _Str_Pedido + "' AND CCOMPANY='" + _Str_Compania + "'");
            //        }
            //    }
            //}
            //catch
            //{
            //    _Bol_Valido = false;
            //}
            return _Bol_Valido;
        }
        private string _Mtd_Aprobacion(string _P_Str_Cliente, string _Str_Compania)
        {
            Cursor = Cursors.WaitCursor;
            double _Dbl_PorcConfig = 0;
            bool _Bol_R = false;
            string[] _Str_PedidosAprobados = new string[_Dg_GridPedidos.Rows.Count];
            string[] _Str_PedidosRechazados = new string[_Dg_GridPedidos.Rows.Count];
            int _Int_Contador1 = 0;
            int _Int_Contador2 = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridPedidos.Rows)
            {
                double _Dbl_Efectividad = 0;
                if (_Dg_Row.Cells["cefectividad2"].Value != null)
                { _Dbl_Efectividad = Convert.ToDouble(_Dg_Row.Cells["cefectividad2"].Value); }
                string _Str_Pedido = _Dg_Row.Cells["cpedido"].Value.ToString();
                string _Str_CompaTem = _Dg_Row.Cells["ccompany"].Value.ToString();
                _Str_CompaniaTemp = _Str_CompaTem;
                _Str_PedidoTemp = _Str_Pedido;
                try
                {
                    SqlParameter[] paramsToStore = new SqlParameter[4];
                    paramsToStore[0] = new SqlParameter("@cpedido1", SqlDbType.Int);
                    paramsToStore[0].Value = _Str_Pedido;
                    paramsToStore[1] = new SqlParameter("@ccompany1", SqlDbType.VarChar);
                    paramsToStore[1].Value = _Str_CompaTem;
                    paramsToStore[2] = new SqlParameter("@cefectividadAnt", SqlDbType.Float);
                    paramsToStore[2].Value = _Dbl_Efectividad;
                    paramsToStore[3] = new SqlParameter("@cuseraprobacion", SqlDbType.VarChar);
                    paramsToStore[3].Value = Frm_Padre._Str_Use;
                    CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_EVALUAREXISTACEPT2", paramsToStore);
                    _Int_Contador1++;
                }
                catch
                {
                    _Int_Contador2++;
                }
            }
            Cursor = Cursors.WaitCursor;
            return "Pedidos autorizados: " + _Int_Contador1 + ", Pedidos que no se pudieron autorizar: "+_Int_Contador2.ToString();
        }
        private string _Mtd_AprobacionBackOrder(string _P_Str_Pedido, string _P_Str_Cliente, string _P_Str_Comp)
        {
            string _Str_Mensaje = "";
            SqlParameter[] paramsToStore = new SqlParameter[3];
            paramsToStore[1] = new SqlParameter("@cpedidoparam", SqlDbType.Int);
            paramsToStore[1].Value = _P_Str_Pedido;
            paramsToStore[0] = new SqlParameter("@ccompany1", SqlDbType.VarChar);
            paramsToStore[0].Value = _P_Str_Comp;
            paramsToStore[2] = new SqlParameter("@cclienteparam", SqlDbType.Float);
            paramsToStore[2].Value = _P_Str_Cliente;
            DataSet _Ds_DataSet = CLASES._Cls_Varios_Metodos._Mtd_ConsultasSP("SP_T3_EVALUARBACKORDER", paramsToStore);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Str_Mensaje = _Ds_DataSet.Tables[0].Rows[0][0].ToString().TrimEnd();
            }
            return _Str_Mensaje;
        }
        private bool _Mtd_AprobacionIndividual(string _P_Str_Cliente, string _Str_Compania)
        {
            Cursor = Cursors.WaitCursor;
            bool _Bol_R = false;
            double _Dbl_PorcConfig = 0;
            double _Dbl_Efectividad = 0;
            if (_Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cefectividad2"].Value != null)
            { _Dbl_Efectividad = Convert.ToDouble(_Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cefectividad2"].Value); }
            string _Str_Pedido = _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString();
            string _Str_CompaTem = _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["ccompany"].Value.ToString();
            _Str_CompaniaTemp = _Str_CompaTem;
            _Str_PedidoTemp = _Str_Pedido;
            SqlParameter[] paramsToStore = new SqlParameter[4];
            try
            {
                paramsToStore[0] = new SqlParameter("@cpedido1", SqlDbType.Int);
                paramsToStore[0].Value = _Str_Pedido;
                paramsToStore[1] = new SqlParameter("@ccompany1", SqlDbType.VarChar);
                paramsToStore[1].Value = _Str_CompaTem;
                paramsToStore[2] = new SqlParameter("@cefectividadAnt", SqlDbType.Float);
                paramsToStore[2].Value = _Dbl_Efectividad;
                paramsToStore[3] = new SqlParameter("@cuseraprobacion", SqlDbType.VarChar);
                paramsToStore[3].Value = Frm_Padre._Str_Use;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_EVALUAREXISTACEPT2", paramsToStore);
                _Bol_R = true;
            }
            catch
            {
                _Bol_R = false;
            }
            Cursor = Cursors.Default;
            return _Bol_R;
        }
        private void _Mtd_Cargar_LimiteCredito()
        {
            string _Str_Cadena = "SELECT RTRIM(TLIMITCREDITO.ccodlimite), TLIMITCREDITO.cdescripcion " +
                                 "FROM TLIMITCREDITO INNER JOIN " +
                                 "VST_LIMTECREDITO ON TLIMITCREDITO.climtehasta <= VST_LIMTECREDITO.climtehasta " +
                                 "WHERE (TLIMITCREDITO.cdelete = '0') AND (VST_LIMTECREDITO.cdelete = '0') AND (VST_LIMTECREDITO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_LIMTECREDITO.cuser = '" + Frm_Padre._Str_Use + "') " +
                                 "ORDER BY TLIMITCREDITO.climtedesde";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_LimiteCredito, _Str_Cadena);
            _Str_Cadena = "SELECT c_limt_credit FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_Codigo.Text.Trim() + "' AND ISNULL(c_limt_credit,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Cmb_LimiteCredito.SelectedValue = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
        }
        string _Str_Comps = "";
        private void Frm_EstatusClientesDetalle_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_RechazarPedido.Left = (this.Width / 2) - (_Pnl_RechazarPedido.Width / 2);
            _Pnl_RechazarPedido.Top = (this.Height / 2) - (_Pnl_RechazarPedido.Height / 2);
            _Pnl_BloqueoManualCliente.Left = (this.Width / 2) - (_Pnl_BloqueoManualCliente.Width / 2);
            _Pnl_BloqueoManualCliente.Top = (this.Height / 2) - (_Pnl_BloqueoManualCliente.Height / 2);
            _Pnl_Limite.Left = (this.Width / 2) - (_Pnl_Limite.Width / 2);
            _Pnl_Limite.Top = (this.Height / 2) - (_Pnl_Limite.Height / 2);
          // si tiene la firma, y ademas el cliente no está ya bloqueado
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_BLOQUEO_MANUAL_CLIENTE") & !_Mtd_ClienteTieneBloqueoManual(Frm_Padre._Str_GroupComp, _Txt_Codigo.Text))
            {
                _Bt_BloqueoManualCliente.Visible = true;
            }
            else
            {
                _Bt_BloqueoManualCliente.Visible = false;
            }
            _Bt_LimiteCredito.Visible = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_LIMIT_CREDIT");
        }

        private void _Bt_Ver_Click(object sender, EventArgs e)
        {
            Frm_Clientes_VC_1 _Frm = new Frm_Clientes_VC_1(_Txt_Codigo.Text.Trim());
            _Frm.ShowDialog();
        }

        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPedidos.CurrentCell != null)
            {
                if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APRUEBA_PEDIDO_CXC"))
                {
                    if (_Mtd_VerficarSobregiroUsu())
                    {
                        _Pnl_Clave.Visible = true;
                        _Int_Sw = 2;
                    }
                    else
                    {
                        MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_PanelSuperior.Enabled = false; _Tb_Tab.Enabled = false; _Pnl_PanelInferior.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_PanelSuperior.Enabled = true; _Tb_Tab.Enabled = true; _Pnl_PanelInferior.Enabled = true; }
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private bool _Mtd_PedidoEvaluando(string _Pr_Str_Pedido,string _P_Str_Comp)
        {
            bool _Bol_Sw = false;
            string _Str_Sql = "SELECT cevaluacion FROM TCOTPEDFACM WHERE ccompany='" + _P_Str_Comp + "' AND cpedido='" + _Pr_Str_Pedido + "' AND CCOTIZACION='" + _Pr_Str_Pedido + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim() == "1")
                {
                    _Bol_Sw = true;
                }
            }
            return _Bol_Sw;
        }
        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
            if (_Mtd_ValidarStatusPedidos(_Dg_GridPedidos[1, _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), _Dg_GridPedidos["ccompany", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString()))
            {
                //Cursor = Cursors.WaitCursor;
                byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
                byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
                string cod = BitConverter.ToString(valorhash);
                cod = cod.Replace("-", "");
                try
                {
                    //Cursor = Cursors.WaitCursor;
                    string _Str_Cadena = "SELECT cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                    System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (Ds22.Tables[0].Rows.Count > 0)
                    {
                        if (_Int_Sw != 3 && _Int_Sw != 4)
                        {
                            if (_Mtd_PedidoEvaluando(_Dg_GridPedidos["cpedido", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), _Dg_GridPedidos["ccompany", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString()))
                            {
                                MessageBox.Show("El pedido se está evaluando.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                _Pnl_Clave.Visible = false;
                                if (_Int_Sw == 0)
                                {
                                    string _Str_CompaniaSel = "";
                                    if (_Mtd_AprobacionIndividual(_Txt_Codigo.Text.Trim(), _Str_CompaniaSel))
                                    {
                                    Verificar:
                                        _Str_Cadena = "SELECT CPEDIDO FROM TCOTPEDFACM WHERE  cstatus='3' and isnull(caprobadocredito,0)=0 AND ccompany='" + _Str_CompaniaTemp + "' and cpedido='" + _Str_PedidoTemp + "' and CCOTIZACION='" + _Str_PedidoTemp + "'";
                                        DataSet _Ds_DataSet = new DataSet();
                                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                        if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                                        {
                                            if (MessageBox.Show("El pedido no pudo ser procesado por problemas con la conexión, ¿Quiere reintentarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                _Mtd_AprobacionIndividual(_Str_PedidoTemp, _Str_CompaniaSel);
                                                goto Verificar;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El pedido fue autorizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    { MessageBox.Show("El pedido no pudo ser autorizado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                                    //_Mtd_AprobacionIndividual(_Txt_Codigo.Text.Trim());
                                }
                                else if (_Int_Sw == 1)
                                {
                                    string _Str_CompaniaSel = "";
                                    // NOTA: El siguiente UPDATE no se está ejecutando, se ejecuta es el de _Bt_RechazarPedidoAceptar_Click
                                    _Str_Cadena = "Update TCOTPEDFACM set cstatus='7',cdateupd=getdate() where ccompany='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["ccompany"].Value.ToString() + "' and cpedido='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString() + "' and CCOTIZACION='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    _Mtd_AprobacionIndividual(_Txt_Codigo.Text.Trim(), _Str_CompaniaSel);
                                    MessageBox.Show("El pedido fue anulado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    string _Str_CompaniaSel = "";
                                    _Str_Cadena = _Mtd_Aprobacion(_Txt_Codigo.Text.Trim(), _Str_CompaniaSel);
                                    if (_Str_Cadena.Length > 0)
                                    {
                                        MessageBox.Show(_Str_Cadena, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                _Mtd_Cargar(_Txt_Codigo.Text.Trim());
                                _Frm_Formulario._Mtd_Actualizar(_Int_Estatus, _Str_Cliente);
                                if (this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                if (_Dg_GridPedidos.Rows.Count == 0 && _Dg_PedBackOrder.Rows.Count == 0)
                                { this.Close(); }
                            }
                        }
                        else
                        {
                            _Pnl_Clave.Visible = false;
                            if (_Int_Sw == 3)
                            {
                                _Str_Cadena = "Update TBACKORDER set cactivo='0', cbloqcred='0' where ccompany='" + _Dg_PedBackOrder.Rows[_Dg_PedBackOrder.CurrentCell.RowIndex].Cells["ccompany2"].Value.ToString() + "' and cpedido='" + _Dg_PedBackOrder.Rows[_Dg_PedBackOrder.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                MessageBox.Show("El backorder fue rechazado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (_Int_Sw == 4)
                            {
                                string _Str_Mensaje = _Mtd_AprobacionBackOrder(_Dg_PedBackOrder.Rows[_Dg_PedBackOrder.CurrentCell.RowIndex].Cells[1].Value.ToString(), _Dg_PedBackOrder.Rows[_Dg_PedBackOrder.CurrentCell.RowIndex].Cells[5].Value.ToString(), Convert.ToString(_Dg_PedBackOrder.Rows[_Dg_PedBackOrder.CurrentCell.RowIndex].Cells["ccompany2"].Value).Trim());
                                //_Str_Cadena = "Update TCOTPEDFACM set cstatus='4' where ccompany='" + Frm_Padre._Str_Comp + "' and cpedido='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString() + "'";
                                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                MessageBox.Show(_Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            _Mtd_Cargar(_Txt_Codigo.Text.Trim());
                            _Frm_Formulario._Mtd_Actualizar(_Int_Estatus, _Str_Cliente);
                            if (this.MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                            if (_Dg_GridPedidos.Rows.Count == 0 && _Dg_PedBackOrder.Rows.Count == 0)
                            { this.Close(); }
                        }
                    }
                    else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
                }
                catch (Exception _Ex)
                {
                    MessageBox.Show("ERROR:" + _Ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        private bool _Mtd_ValidarSaldoCheqDev(string _Str_Cliente, string _Str_GroupComp)
        {
            bool _Bol_Validar = true;
            string _Str_SQL = "SELECT TOP 1 ctipdoccheqdev FROM TCONFIGCXC WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_TipoCheqDev = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                _Str_SQL = "SELECT CSALDOFACTURA,CNUMDOCU,CCOMPANY FROM TSALDOCLIENTED WHERE ctipodocument='" + _Str_TipoCheqDev + "' AND CSALDOFACTURA>0 AND cgroupcomp='" + _Str_GroupComp + "' AND CCLIENTE='" + _Str_Cliente + "' AND cactivo='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Bol_Validar = false;
                }
                else
                {
                    //_Bol_Validar = false;
                    //foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                    //{
                    //    string _Str_CheqDevuelt = _Dtw_Item["CNUMDOCU"].ToString();
                    //    string _Str_Compania = _Dtw_Item["CCOMPANY"].ToString();
                    //    _Str_SQL = "SELECT SUM(cmontodeefectivo) FROM TRELACCOBDD WHERE CONVERT(NUMERIC(18,0),CNUMDOCU)='" + _Str_CheqDevuelt + "' AND CTIPODOCUMENT='" + _Str_TipoCheqDev + "' AND CCOMPANY='" + _Str_Compania + "' AND CCLIENTE='" + _Str_Cliente + "' HAVING  (SUM(cmontodeefectivo) >= '" + _Dtw_Item["CSALDOFACTURA"].ToString().Replace(",",".") + "')";
                    //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    //    if (_Ds.Tables[0].Rows.Count == 0)
                    //    {
                    //        _Bol_Validar = false;
                    //    }
                    //    else
                    //    {
                            
                    //    }
                    //}
                }
            }            
            return _Bol_Validar;
        }
        private bool _Mtd_ValidarStatusPedidos(string _P_Str_Pedido, string _P_Str_Compania)
        {
            bool _Bol_Valido = true;
            try
            {
                string _Str_SQL = "SELECT cpedido,cstatus,cuseraprob FROM TCOTPEDFACM WHERE CCOMPANY='" + _P_Str_Compania + "' AND CPEDIDO='" + _P_Str_Pedido + "' AND CCOTIZACION='" + _P_Str_Pedido + "' AND CSTATUS<>'3'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Bol_Valido = false;
                    if (_Ds.Tables[0].Rows[0][1].ToString() == "7")
                    {
                        MessageBox.Show(@"El pedido fue rechazado por el usuario: " + _Ds.Tables[0].Rows[0][2].ToString().ToUpper() ,
                              "APROBACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (_Ds.Tables[0].Rows[0][1].ToString()!= "7")
                    {
                        MessageBox.Show(@"El pedido ya fue evaluado por el usuario: " + _Ds.Tables[0].Rows[0][2].ToString().ToUpper(),
                              "APROBACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    _Mtd_Dg_GridPedidos(_Txt_Codigo.Text);
                    if (_Dg_GridPedidos.Rows.Count == 0 && _Dg_PedBackOrder.Rows.Count == 0)
                    { this.Close(); }
                }
            }
            catch
            {
            }
            return _Bol_Valido;
        }
        private void aUTORIZARPEDIDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPedidos.CurrentCell != null)
            {
                if (_Mtd_ValidarStatusPedidos(_Dg_GridPedidos[1, _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), _Dg_GridPedidos["ccompany", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString()))
                {
                    if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APRUEBA_PEDIDO_CXC"))
                    {
                        if (_Mtd_ValidarSaldoCheqDev(_Txt_Codigo.Text, Frm_Padre._Str_GroupComp))
                        {
                            if (_Mtd_VerficarSobregiroUsuByPedido(_Dg_GridPedidos[1, _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), _Dg_GridPedidos["ccompany", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString()))
                            {
                                if (!_Mtd_ClienteTieneBloqueoManual(Frm_Padre._Str_GroupComp, _Txt_Codigo.Text))
                                {
                                    _Pnl_Clave.Visible = true;
                                    _Int_Sw = 0;
                                }
                                else
                                {
                                    MessageBox.Show(this, "No se puede realizar el proceso porque ese cliente se encuentra bloqueado manualmente. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El cliente posee cheques devueltos que no han sido cobrados, no pueden aprobarse sus pedidos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
            }
        }

        private void rechazarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_GridPedidos.CurrentCell != null)
            {
                if (_Mtd_ValidarStatusPedidos(_Dg_GridPedidos[1, _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), _Dg_GridPedidos["ccompany", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString()))
                {
                    if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APRUEBA_PEDIDO_CXC"))
                    {
                        _Txt_RechazarPedidoMotivo.Text = "";
                        _Txt_RechazarPedidoClave.Text = "";
                        _Pnl_RechazarPedido.Visible = true;
                        _Txt_RechazarPedidoMotivo.Focus();
                        _Int_Sw = 1;
                    }
                    else
                    { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_GridPedidos.CurrentCell == null)
            { e.Cancel = true; }
        }

        private bool _Mtd_VerficarSobregiroUsu()
        {
            bool _Bol_R = false;
            double _Dbl_Diferencia=0;
            double _Dbl_Limite = 0;
            double _Dbl_SaldoXcobrar = 0;
            double _Dbl_MontoPedBlock = 0;
            double _Dbl_MontoTotal = 0;
            double _Dbl_PorcSobreGiro =0;
            double _Dbl_PorcSobreGiroUsu = _Cls_VariosMetodos._Mtd_GetPorcSobregiroUsuario(Frm_Padre._Str_Use);
            string _Str_Sql = "";
            if (_Txt_SaldoPorCobrar.Text != "")
            {
                _Dbl_SaldoXcobrar = Convert.ToDouble(_Txt_SaldoPorCobrar.Text);
            }
            if (_Txt_PedidosBloqueados.Text != "")
            {
                _Dbl_MontoPedBlock = Convert.ToDouble(_Txt_PedidosBloqueados.Text);
            }
            if (_Txt_BackOrderBloqueados.Text != "")
            {
                _Dbl_MontoPedBlock += Convert.ToDouble(_Txt_BackOrderBloqueados.Text);
            }
            _Dbl_MontoTotal = _Dbl_MontoPedBlock + _Dbl_SaldoXcobrar;
            _Str_Sql = "SELECT climtehasta FROM VST_LIMTECREDITO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + Frm_Padre._Str_Use + "' AND ISNULL(cdelete,0)=0 ORDER BY climtehasta DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Limite = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Dbl_Diferencia = _Dbl_MontoTotal - _Dbl_Limite;
            if (_Dbl_Diferencia > 0)
            {
                _Dbl_PorcSobreGiro = _Dbl_MontoTotal * _Dbl_Diferencia / 100;
                if (_Dbl_PorcSobreGiro <= _Dbl_PorcSobreGiroUsu)
                {//TIENE PERMISO
                    _Bol_R = true;
                }
                else
                {//NO TIENE PERMISO
                    _Bol_R = false;
                }
            }
            else
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }
        private bool _Mtd_VerficarSobregiroUsuByPedido(string _Pr_Str_Pedido,string _P_Str_Comp)
        {
            double _Dbl_Monto = 0;
            double _Dbl_Limite = 0;
            double _Dbl_Diferencia = 0;
            double _Dbl_SaldoPorCobrar = 0;
            double _Dbl_PedidosBloqueados = 0;
            double _Dbl_PorcSobreGiro = 0;
            double _Dbl_PorcSobreGiroUsu = _Cls_VariosMetodos._Mtd_GetPorcSobregiroUsuario(Frm_Padre._Str_Use);
            bool _Bol_R = false;
            string _Str_Sql = "";
            _Str_Sql = "Select c_montotot_si,c_impuesto from VST_T3_PEDIDOSPORAPROBARCREDITO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' AND cpedido='" + _Pr_Str_Pedido + "' AND CCOTIZACION='" + _Pr_Str_Pedido + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_PedidosBloqueados = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                {
                    _Dbl_PedidosBloqueados = _Dbl_PedidosBloqueados + Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                }
            }
            _Str_Sql = "SELECT SUM(c_monto_si+c_impuesto) FROM VST_PEDIDOSBACKORDER WHERE ccompany='" + _P_Str_Comp + "' AND cpedido='" + _Pr_Str_Pedido + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_PedidosBloqueados += Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }               
            }
            _Str_Sql = "Select SUM(csaldofactura) from VST_SALDOFACTURA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cpedido='" + _Pr_Str_Pedido + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dbl_SaldoPorCobrar = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_SaldoPorCobrar = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            _Str_Sql = "Select SUM(c_montotot_si) from TPREFACTURAM where ccompany='" + _P_Str_Comp + "' and cfacturado='0' AND cpedido='" + _Pr_Str_Pedido + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_SaldoPorCobrar = _Dbl_SaldoPorCobrar + Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            _Dbl_Monto = _Dbl_SaldoPorCobrar + _Dbl_PedidosBloqueados;
            _Str_Sql = "SELECT climtehasta FROM VST_LIMTECREDITO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + Frm_Padre._Str_Use + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Limite = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Dbl_Diferencia = _Dbl_Monto - _Dbl_Limite;
            if (_Dbl_Diferencia > 0)
            {
                _Dbl_PorcSobreGiro = ((_Dbl_Monto * 100) / _Dbl_Limite)-100;
                if (_Dbl_PorcSobreGiro <= _Dbl_PorcSobreGiroUsu)
                {//TIENE PERMISO
                    _Bol_R = true;
                }
                else
                {//NO TIENE PERMISO
                    _Str_Sql = "SELECT cexclimaprob,cuseraprob FROM TCOTPEDFACM WHERE CCOTIZACION='" + _Pr_Str_Pedido + "' AND CPEDIDO='" + _Pr_Str_Pedido + "' AND CCOMPANY='" + _P_Str_Comp + "' AND cexclimaprob='1' AND CSTATUS='3' AND cevaluacion='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(@"El pedido fue pre-aprobado por límite de crédito por el usuario: " + _Ds.Tables[0].Rows[0][1].ToString().ToUpper() +
                            " para continuar introduzca su clave", "APROBACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = true;
                    }
                    else
                    {
                        _Bol_R = false;
                    }
                }
            }
            else
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }

        private void _Dg_GridPedidos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgPedidosInfo.Visible = true;
            }
            else
            {
                _Lbl_DgPedidosInfo.Visible = false;
            }
        }

        private void detalleDelPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_ConsultaPedidosDetalle _Frm = new Frm_ConsultaPedidosDetalle(_Dg_GridPedidos[1, _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), Convert.ToString(_Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["ccompany"].Value).Trim());
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_Aprobar_EnabledChanged(object sender, EventArgs e)
        {
            if (_Bt_Aprobar.Enabled)
            {
                _Bt_Aprobar.Visible = true;
            }
            else
            {
                _Bt_Aprobar.Visible = false;
            }
        }

        private void _Bt_ConsultaCobros_Click(object sender, EventArgs e)
        {
            try
            {
                string _Str_SentenciaSQL = "SELECT CCOMPANY FROM T3TCOMPANY WHERE CCOMPANY='"+Frm_Padre._Str_Comp+"'";
                DataSet _Ds_ = new DataSet();
                _Ds_ = Program._MyClsCnn._mtd_conexionSQL2012._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_Ds_.Tables[0].Rows.Count > 0)
                {
                    if (_Txt_Codigo.Text.Trim().Length > 0)
                    {
                        Frm_EstatusClientesDetalleCobros _Frm = new Frm_EstatusClientesDetalleCobros(_Txt_Codigo.Text.Trim());
                        _Frm.ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Disculpe, no se puede mostrar los cobros realizados ya que existe un problema con la conexión al servidor central probablemente sea un problema de internet, intentelo de nuevo en unos minutos. Gracias", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_Dg_PedBackOrder.CurrentCell != null)
            {
                Frm_EstatusBackOrderDetalle _Frm_Form = new Frm_EstatusBackOrderDetalle(_Dg_PedBackOrder[1, _Dg_PedBackOrder.CurrentCell.RowIndex].Value.ToString());
                _Frm_Form.ShowDialog();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (_Dg_PedBackOrder.CurrentCell != null)
            {
                if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APRUEBA_PEDIDO_CXC"))
                {
                    if (_Mtd_VerficarSobregiroUsuByPedido(_Dg_PedBackOrder[1, _Dg_PedBackOrder.CurrentCell.RowIndex].Value.ToString(), _Dg_PedBackOrder["ccompany2", _Dg_PedBackOrder.CurrentCell.RowIndex].Value.ToString()))
                    {
                        _Pnl_Clave.Visible = true;
                        _Int_Sw = 4;
                    }
                    else
                    {
                        MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_Dg_PedBackOrder.CurrentCell != null)
            {
                if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APRUEBA_PEDIDO_CXC"))
                {
                    _Pnl_Clave.Visible = true;
                    _Int_Sw = 3;
                }
                else
                { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void _Bt_HistorialCliente_Click(object sender, EventArgs e)
        {
            Frm_Inf_HistCliente _frm = new Frm_Inf_HistCliente(this._Txt_Codigo.Text.Trim(), _Txt_Cliente.Text.Trim());
            _frm.StartPosition = FormStartPosition.CenterScreen;
            _frm.Size = _Frm_Formulario.Size;
            _frm.ShowDialog();
        }

        private void _Bt_Analisis_Click(object sender, EventArgs e)
        {
            Frm_Inf_AnalisisSaldo _frm = new Frm_Inf_AnalisisSaldo(this._Txt_Codigo.Text.Trim());
            _frm.Size = _Frm_Formulario.Size;
            _frm.StartPosition = FormStartPosition.CenterScreen;
            _frm.ShowDialog();
        }

        private void _Pnl_RechazarPedido_VisibleChanged(object sender, EventArgs e)
        {
          if (_Pnl_RechazarPedido.Visible)
          { _Pnl_PanelSuperior.Enabled = false; _Tb_Tab.Enabled = false; _Pnl_PanelInferior.Enabled = false;}
          else
          { _Pnl_PanelSuperior.Enabled = true; _Tb_Tab.Enabled = true; _Pnl_PanelInferior.Enabled = true; }
        }

        private void _Bt_RechazarPedidoAceptar_Click(object sender, EventArgs e)
        {
          Cursor = Cursors.WaitCursor;
          byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_RechazarPedidoClave.Text);
          byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
          string cod = BitConverter.ToString(valorhash);
          cod = cod.Replace("-", "");
          try
          {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
            System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (Ds22.Tables[0].Rows.Count > 0)
            {
                if (_Mtd_PedidoEvaluando(_Dg_GridPedidos["cpedido", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString(), _Dg_GridPedidos["ccompany", _Dg_GridPedidos.CurrentCell.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("El pedido se está evaluando.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (_Txt_RechazarPedidoMotivo.Text.Trim() != "") // si el motivo del anulacion no se dejó en blanco...
                    {
                        string _Str_Compania = "";
                        _Pnl_RechazarPedido.Visible = false;
                        _Str_Cadena = "Update TCOTPEDFACM set cuseraprobcredito='" + Frm_Padre._Str_Use + "',cuserupd='" + Frm_Padre._Str_Use + "',cstatus='7', c_obs_rechazado='" + _Txt_RechazarPedidoMotivo.Text.ToUpper() + "', c_rechazado = 1,cdateupd=getdate()  where ccompany='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["ccompany"].Value.ToString() + "' and cpedido='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString() + "' and CCOTIZACION='" + _Dg_GridPedidos.Rows[_Dg_GridPedidos.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_AprobacionIndividual(_Txt_Codigo.Text.Trim(), _Str_Compania);
                        MessageBox.Show("El pedido fue anulado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Cargar(_Txt_Codigo.Text.Trim());
                        _Frm_Formulario._Mtd_Actualizar(_Int_Estatus, _Str_Cliente);
                        if (this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                        if (_Dg_GridPedidos.Rows.Count == 0 && _Dg_PedBackOrder.Rows.Count == 0)
                        { this.Close(); }
                    }
                    else
                    {
                        MessageBox.Show("La razón de rechazo no puede estar en blanco. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
              MessageBox.Show(this, "Clave incorrecta. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              _Txt_RechazarPedidoClave.Focus();
              _Txt_RechazarPedidoClave.Select(0, _Txt_RechazarPedidoClave.Text.Length);
            }
          }
          catch (Exception _Ex)
          {
            MessageBox.Show("ERROR:" + _Ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
          Cursor = Cursors.Default;
        }

        private void _Bt_RechazarPedidoCancelar_Click(object sender, EventArgs e)
        {
          _Pnl_RechazarPedido.Visible = false;
        }

        private void _Bt_BloqueoManualCliente_Click(object sender, EventArgs e)
        {
          _Txt_BloqueoManualClienteRazon.Text = "";
          _Txt_BloqueoManualClienteClave.Text = "";
          _Pnl_BloqueoManualCliente.Visible = true;
          _Txt_BloqueoManualClienteRazon.Focus();
        }

        private void _Bt_BloqueoManualClienteCancelar_Click(object sender, EventArgs e)
        {
          _Pnl_BloqueoManualCliente.Visible = false;
        }

        private void _Bt_BloqueoManualClienteAceptar_Click(object sender, EventArgs e)
        {
          Cursor = Cursors.WaitCursor;
          byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_BloqueoManualClienteClave.Text);
          byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
          string cod = BitConverter.ToString(valorhash);
          cod = cod.Replace("-", "");
          try
          {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
            System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (Ds22.Tables[0].Rows.Count > 0)
            {
              if (_Txt_BloqueoManualClienteRazon.Text.Trim() != "")
              {
                _Str_Cadena = "Update TCLIENTE set c_bloqueo_manual = 1, c_bloqueo_manual_usuario = '" + Frm_Padre._Str_Use.ToString() + "', c_bloqueo_manual_fecha = GETDATE(), c_motivo_bloqueo_manual = '" + _Txt_BloqueoManualClienteRazon.Text.ToUpper() + "', cuserupd = '" + Frm_Padre._Str_Use.ToString() + "', cdateupd = GETDATE() WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_Codigo.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El cliente ha sido bloqueado satisfactoriamente.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bt_BloqueoManualCliente.Visible = false;

                _Pnl_BloqueoManualCliente.Visible = false;
              }
              else
              {
                MessageBox.Show("La razón de bloqueo no puede estar en blanco. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
            }
            else
            {
              MessageBox.Show(this, "Clave incorrecta. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              _Txt_BloqueoManualClienteRazon.Focus();
              _Txt_BloqueoManualClienteRazon.Select(0, _Txt_BloqueoManualClienteRazon.Text.Length);
            }
          }
          catch (Exception _Ex)
          {
            MessageBox.Show("ERROR:" + _Ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
          Cursor = Cursors.Default;
        }
        
      private bool _Mtd_ClienteTieneBloqueoManual(string _Str_CodGrupoEmpresa, string _Str_CodCliente)
        {
          bool _Boo_Retornar = false;
          string _Str_SQL = "SELECT ISNULL(c_bloqueo_manual,0) as c_bloqueo_manual FROM TCLIENTE WHERE cgroupcomp='" + _Str_CodGrupoEmpresa + "' AND ccliente='" + _Str_CodCliente + "'";
          System.Data.DataSet Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
          if (Ds.Tables[0].Rows.Count > 0) _Boo_Retornar = Convert.ToBoolean(Ds.Tables[0].Rows[0]["c_bloqueo_manual"]);
          return _Boo_Retornar;
        }

      private void _Pnl_BloqueoManualCliente_VisibleChanged(object sender, EventArgs e)
      {
        if (_Pnl_BloqueoManualCliente.Visible)
        { _Pnl_PanelSuperior.Enabled = false; _Tb_Tab.Enabled = false; _Pnl_PanelInferior.Enabled = false;}
        else
        { _Pnl_PanelSuperior.Enabled = true; _Tb_Tab.Enabled = true; _Pnl_PanelInferior.Enabled = true; }
      }

      private void _Pnl_PanelSuperior_Paint(object sender, PaintEventArgs e)
      {

      }

      private void _Pnl_Limite_VisibleChanged(object sender, EventArgs e)
      {
          if (_Pnl_Limite.Visible)
          { _Pnl_PanelSuperior.Enabled = false; _Tb_Tab.Enabled = false; _Pnl_PanelInferior.Enabled = false; _Mtd_Cargar_LimiteCredito(); _Cmb_LimiteCredito.Focus(); }
          else
          { _Pnl_PanelSuperior.Enabled = true; _Tb_Tab.Enabled = true; _Pnl_PanelInferior.Enabled = true; }
      }

      private void _Bt_Aceptar_L_Click(object sender, EventArgs e)
      {
          if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave_L.Text.Trim()))
          {
              _Pnl_Limite.Visible = false;
              Cursor = Cursors.WaitCursor;
              string _Str_Cadena = "UPDATE TCLIENTE SET c_limt_credit='" + Convert.ToString(_Cmb_LimiteCredito.SelectedValue) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_Codigo.Text.Trim() + "'";
              Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
              _Mtd_Cargar(_Txt_Codigo.Text.Trim());
              Cursor = Cursors.Default;
              MessageBox.Show("La operación ha sido realizada correctamente", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave_L.Focus(); _Txt_Clave_L.Select(0, _Txt_Clave_L.Text.Length); }
      }

      private void _Bt_Cancelar_L_Click(object sender, EventArgs e)
      {
          _Pnl_Limite.Visible = false;
      }

      private void _Bt_LimiteCredito_Click(object sender, EventArgs e)
      {
          _Pnl_Limite.Visible = true;
      }

      private void _Cmb_LimiteCredito_SelectedIndexChanged(object sender, EventArgs e)
      {
          if (_Cmb_LimiteCredito.SelectedIndex > 0)
          { _Txt_Clave_L.Enabled = true; }
          else
          { _Txt_Clave_L.Enabled = false; _Txt_Clave_L.Text = ""; }
      }


      private void _Txt_Clave_L_TextChanged(object sender, EventArgs e)
      {
          if (_Txt_Clave_L.Text.Trim().Length > 0)
          { _Bt_Aceptar_L.Enabled = true; }
          else
          { _Bt_Aceptar_L.Enabled = false; }
      }

      private void _Cmb_LimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
      {
          if (e.KeyChar == (char)13 & _Cmb_LimiteCredito.SelectedIndex > 0)
          {
              _Txt_Clave_L.Focus();
          }
      }

        

    }
}