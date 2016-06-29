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
    public partial class Frm_ConsultaPedidosDetalle : Form
    {
        string _Str_Comp = Frm_Padre._Str_Comp;
        public Frm_ConsultaPedidosDetalle()
        {
            InitializeComponent();
        }
        public Frm_ConsultaPedidosDetalle(string _P_Str_Pedido)
        {
            InitializeComponent();
            _Mtd_CargarPedido(_P_Str_Pedido);
            _Bt_Pasar.Visible = false;
        }
        public Frm_ConsultaPedidosDetalle(string _P_Str_Pedido,string _P_Str_Comp)
        {
            InitializeComponent();
            _Str_Comp = _P_Str_Comp;
            _Mtd_CargarPedido(_P_Str_Pedido);
            _Bt_Pasar.Visible = false;
        }
        string _Str_CodCliente = "";
        string _Str_CodVendedor = "";
        double _Dbl_Efectividad = 0;
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        Frm_ConsultaPedidos _Frm_Formulario;
        Frm_ConsultaMultiple _Frm_FormularioMultiple;

        public Frm_ConsultaPedidosDetalle(string _P_Str_Pedido, string _P_Str_Fecha_Pedido, int _P_Int_Estatus, string _P_Str_CodCliente, string _P_Str_DesCliente, string _P_Str_CodVendedor, string _P_Str_DesVendedor, string _P_Str_Cajas, string _P_Str_Unidades, string _P_Str_Monto, double _P_Dbl_Efectividad, int _P_Int_Backorder, Frm_ConsultaMultiple _P_Frm_Formulario)
        {
            InitializeComponent();
            _Txt_Pedido.Text = _P_Str_Pedido;
            _Txt_Fecha.Text = _P_Str_Fecha_Pedido;
            _Dbl_Efectividad = _P_Dbl_Efectividad;
            _Frm_FormularioMultiple = _P_Frm_Formulario;
            if (_P_Int_Estatus == 1)
            { _Txt_Estatus.Text = "PEDIDO BLOQUEADO POR CRÉDITO"; }
            //else if (_P_Int_Estatus == 2)
            //{ _Txt_Estatus.Text = "PEDIDO BLOQUEADO POR EXISTENCIA"; _Bt_Procesar.Enabled = true; }
            else if (_P_Int_Estatus == 3)
            { _Txt_Estatus.Text = "PEDIDO RECHAZADO POR EXISTENCIA"; _Bt_Pasar.Enabled = true; } //if (_P_Dbl_Efectividad >= 50) { _Bt_Procesar.Enabled = true; } }
            else if (_P_Int_Estatus == 4)
            { _Txt_Estatus.Text = "PEDIDO A FACTURAR"; }
            else if ((_P_Int_Estatus == 5) || (_P_Int_Estatus == 10) || (_P_Int_Estatus == 11))
            { _Txt_Estatus.Text = "FACTURADO"; }
            else if (_P_Int_Estatus == 7)
            { _Txt_Estatus.Text = "PEDIDO ANULADO"; }
            _Str_CodCliente = _P_Str_CodCliente;
            _Txt_Cliente.Text = _P_Str_DesCliente;
            _Str_CodVendedor = _P_Str_CodVendedor;
            _Txt_Vendedor.Text = _P_Str_DesVendedor;
            _Txt_Cajas.Text = _P_Str_Cajas;
            _Txt_Unidades.Text = _P_Str_Unidades;
            _Txt_Monto.Text = _P_Str_Monto;


            string _Str_Cadena = "SELECT cobservaciones FROM TCOTPEDFACM WHERE ccompany='" + _Str_Comp + "' AND cpedido='" + _P_Str_Pedido + "' AND CCOTIZACION='" + _P_Str_Pedido + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Obs.Text = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
            }
            _Lbl_Porcentaje.Text = _P_Dbl_Efectividad.ToString() + "%";
            if (_P_Dbl_Efectividad > 100)
            { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
            else
            { _Prb_Efectividad.Value = Convert.ToInt32(_P_Dbl_Efectividad); }
            _Chbox_BackOrder.Checked = Convert.ToBoolean(_P_Int_Backorder);


            // motivo anulacion
            _Lbl_MotivoRechazo.Text = "Razón :";
            if (_P_Int_Estatus == 9) _Lbl_MotivoRechazo.Text = "Observaciones / razón de rechazo :";
            if (_P_Int_Estatus == 7) _Lbl_MotivoRechazo.Text = "Observaciones / razón de anulación :";
            _Str_Cadena = "SELECT c_obs_rechazado FROM TCOTPEDFACM WHERE ccompany='" + _Str_Comp + "' AND cpedido='" + _P_Str_Pedido + "' and ccotizacion='" + _P_Str_Pedido + "' and (cstatus='9' or cstatus='7')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Pnl_MotivoRechazo.Visible = true;
                _Txt_MotivoRechazo.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_obs_rechazado"]).Trim();
            }



            _Str_Cadena = "Select cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_CONSULTAPEDIDOSDETALLE.cproducto) as cnamef,cempaques,cunidades,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cempaquesfal ELSE cfaltantecajas END as cempaquesfal,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cunidadesfal ELSE cfaltanteunidades END as cunidadesfal from VST_CONSULTAPEDIDOSDETALLE where ccompany='" + _Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cpedido='" + _P_Str_Pedido + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        public Frm_ConsultaPedidosDetalle(string _P_Str_Pedido,string _P_Str_Fecha_Pedido, int _P_Int_Estatus,string _P_Str_CodCliente,string _P_Str_DesCliente,string _P_Str_CodVendedor,string _P_Str_DesVendedor,string _P_Str_Cajas,string _P_Str_Unidades,string _P_Str_Monto,double _P_Dbl_Efectividad,int _P_Int_Backorder,Frm_ConsultaPedidos _P_Frm_Formulario)
        {
            InitializeComponent();
            _Txt_Pedido.Text = _P_Str_Pedido;
            _Txt_Fecha.Text = _P_Str_Fecha_Pedido;
            _Dbl_Efectividad = _P_Dbl_Efectividad;
            _Frm_Formulario = _P_Frm_Formulario;
            if (_P_Int_Estatus == 1)
            { _Txt_Estatus.Text = "PEDIDO BLOQUEADO POR CRÉDITO"; }
            //else if (_P_Int_Estatus == 2)
            //{ _Txt_Estatus.Text = "PEDIDO BLOQUEADO POR EXISTENCIA"; _Bt_Procesar.Enabled = true; }
            else if (_P_Int_Estatus == 3)
            { _Txt_Estatus.Text = "PEDIDO RECHAZADO POR EXISTENCIA"; _Bt_Pasar.Enabled = true; } //if (_P_Dbl_Efectividad >= 50) { _Bt_Procesar.Enabled = true; } }
            else if (_P_Int_Estatus == 4)
            { _Txt_Estatus.Text = "PEDIDO A FACTURAR"; }
            else if (_P_Int_Estatus == 5)
            { _Txt_Estatus.Text = "PEDIDO ANULADO"; }
            _Str_CodCliente = _P_Str_CodCliente;
            _Txt_Cliente.Text = _P_Str_DesCliente;
            _Str_CodVendedor = _P_Str_CodVendedor;
            _Txt_Vendedor.Text = _P_Str_DesVendedor;
            _Txt_Cajas.Text = _P_Str_Cajas;
            _Txt_Unidades.Text = _P_Str_Unidades;
            _Txt_Monto.Text = _P_Str_Monto;


            string _Str_Cadena = "SELECT cobservaciones FROM TCOTPEDFACM WHERE ccompany='" + _Str_Comp + "' AND cpedido='" + _P_Str_Pedido + "' AND CCOTIZACION='" + _P_Str_Pedido + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Obs.Text = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
            }
            _Lbl_Porcentaje.Text = _P_Dbl_Efectividad.ToString() + "%";
            if (_P_Dbl_Efectividad > 100)
            { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
            else
            { _Prb_Efectividad.Value = Convert.ToInt32(_P_Dbl_Efectividad); }
            _Chbox_BackOrder.Checked = Convert.ToBoolean(_P_Int_Backorder);


          // motivo anulacion
          _Lbl_MotivoRechazo.Text = "Razón :";
          if (_P_Int_Estatus == 3) _Lbl_MotivoRechazo.Text = "Observaciones / razón de rechazo :";
          if (_P_Int_Estatus == 5) _Lbl_MotivoRechazo.Text = "Observaciones / razón de anulación :";
          _Str_Cadena = "SELECT c_rechazado, c_obs_rechazado FROM TCOTPEDFACM WHERE ccompany='" + _Str_Comp + "' AND cpedido='" + _P_Str_Pedido + "' AND CCOTIZACION='" + _P_Str_Pedido + "'";
          _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

          if (_Ds.Tables[0].Rows.Count > 0)
            {
              string _Str_PedidoRechazado = Convert.ToString(_Ds.Tables[0].Rows[0]["c_rechazado"]).Trim();
              if (_Str_PedidoRechazado == "1")
              {
                _Pnl_MotivoRechazo.Visible = true;

                _Txt_MotivoRechazo.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_obs_rechazado"]).Trim();
              }
              else
              {
                _Pnl_MotivoRechazo.Visible = false;
              }
            }
          
          
          
            _Str_Cadena = "Select cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_CONSULTAPEDIDOSDETALLE.cproducto) as cnamef,cempaques,cunidades,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cempaquesfal ELSE cfaltantecajas END as cempaquesfal,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cunidadesfal ELSE cfaltanteunidades END as cunidadesfal from VST_CONSULTAPEDIDOSDETALLE where ccompany='" + _Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cpedido='" + _P_Str_Pedido + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void _Mtd_CargarPedido(string _Pr_Str_CodPedido)
        {
            double _Dbl_Impuesto = 0, _Dbl_MontoSimp=0, _Dbl_MontoTot=0, _Dbl_Efectividad=0;
            string _Str_Sql = "SELECT * FROM VST_CONSULTAPEDIDOS WHERE ccompany='" + _Str_Comp + "' AND cpedido='" + _Pr_Str_CodPedido + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cstatus"]) == "3")
                {//BLOQUEADO POR CREDITO
                    _Txt_Estatus.Text = "BLOQUEADO POR CREDITO";
                }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["cstatus"]) == "4" && Convert.ToString(_Ds.Tables[0].Rows[0]["cfactura"]) == "0")
                {//A FACTURAR
                    _Txt_Estatus.Text = "A FACTURAR";
                }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["cstatus"]) == "7")
                {//ANULADOS
                    _Txt_Estatus.Text = "ANULADOS";
                }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["cstatus"]) == "9" && Convert.ToString(_Ds.Tables[0].Rows[0]["c_rechabackorder"]) == "1" && Convert.ToString(_Ds.Tables[0].Rows[0]["c_pendientebackorder"]) == "0")
                {//RECHAZADO POR EXISTENCIA
                    _Txt_Estatus.Text = "RECHAZADO POR EXISTENCIA";
                }
                _Txt_Pedido.Text = _Pr_Str_CodPedido;
                _Txt_Fecha.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_pedido"]).ToShortDateString();

                _Txt_Cliente.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]) + "-" + Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim();
                _Txt_Vendedor.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]) + "-" + Convert.ToString(_Ds.Tables[0].Rows[0]["cnamevendedor"]).Trim();
                _Txt_Cajas.Text = _Ds.Tables[0].Rows[0]["cempaques"].ToString();
                _Txt_Unidades.Text = _Ds.Tables[0].Rows[0]["cunidades"].ToString();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_impuesto"]) != "")
                {
                    _Dbl_Impuesto = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto"]);
                }
                _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si"]);
                _Dbl_MontoTot = _Dbl_MontoSimp + _Dbl_Impuesto;
                _Txt_Monto.Text = _Dbl_MontoTot.ToString("#,##0.00");
                _Txt_Obs.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cobservaciones"]).Trim();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cbackorder"]) == "1")
                {
                    _Chbox_BackOrder.Checked = true;
                }
                else
                {
                    _Chbox_BackOrder.Checked = false;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cefectividad"]) != "")
                {
                    _Dbl_Efectividad = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cefectividad"]);
                }

                _Lbl_Porcentaje.Text = _Dbl_Efectividad.ToString() + "%";
                if (_Dbl_Efectividad > 100)
                { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
                else
                { _Prb_Efectividad.Value = Convert.ToInt32(_Dbl_Efectividad); }

                _Str_Sql = "Select cproducto,((SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_CONSULTAPEDIDOSDETALLE.cproducto)) as cnamef,cempaques,cunidades,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cempaquesfal ELSE cfaltantecajas END as cempaquesfal,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cunidadesfal ELSE cfaltanteunidades END as cunidadesfal from VST_CONSULTAPEDIDOSDETALLE where ccompany='" + _Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cpedido='" + _Pr_Str_CodPedido + "'";
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Dg_Grid.DataSource = _Ds_A.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select cefectividad from VST_CONSULTAPEDIDOS where ccompany='" + _Str_Comp + "' and cpedido='" + _Txt_Pedido.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_EfectividadNueva = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_EfectividadNueva = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            _Lbl_Porcentaje.Text = _Dbl_EfectividadNueva.ToString() + "%";
            if (_Dbl_EfectividadNueva > 100)
            { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
            else
            { _Prb_Efectividad.Value = Convert.ToInt32(_Dbl_EfectividadNueva); }
            _Txt_Estatus.Text = "PEDIDO A FACTURAR";
            _Str_Cadena = "Select cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_CONSULTAPEDIDOSDETALLE.cproducto) as cnamef,cempaques,cunidades,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cempaquesfal ELSE cfaltantecajas END as cempaquesfal,CASE WHEN c_rechabackorder='1' AND cbackorder='1' THEN cunidadesfal ELSE cfaltanteunidades END as cunidadesfal from VST_CONSULTAPEDIDOSDETALLE where ccompany='" + _Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cpedido='" + _Txt_Pedido.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            if (this._Frm_Formulario != null)
            {
                this._Frm_Formulario._Mtd_Actualizar();
            }
            else if (this._Frm_FormularioMultiple != null)
            {
                this._Frm_FormularioMultiple._Mtd_LlenarGridPedidos();
            }
        }
        private bool _Mtd_Procesar()
        {
            SqlParameter[] paramsToStore = new SqlParameter[3];
            paramsToStore[0] = new SqlParameter("@cpedido1", SqlDbType.Int);
            paramsToStore[0].Value = _Txt_Pedido.Text.Trim();
            paramsToStore[1] = new SqlParameter("@ccompany1", SqlDbType.VarChar);
            paramsToStore[1].Value = _Str_Comp;
            paramsToStore[2] = new SqlParameter("@cefectividadAnt", SqlDbType.Float);
            paramsToStore[2].Value = _Dbl_Efectividad;
            CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_EVALUAREXISTACEPT", paramsToStore);
            string _Str_Cadena = "Select cefectividad from VST_CONSULTAPEDIDOS where ccompany='" + _Str_Comp + "' and cpedido='" + _Txt_Pedido.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_EfectividadNueva = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_EfectividadNueva = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            if (_Dbl_EfectividadNueva < _Dbl_Efectividad)
            { return false; }
            else
            { return true; }
        }
        private bool _Mtd_PedidoEvaluando(string _Pr_Str_Pedido)
        {
            bool _Bol_Sw = false;
            string _Str_Sql = "SELECT cevaluacion FROM TCOTPEDFACM WHERE ccompany='" + _Str_Comp + "' AND cpedido='" + _Pr_Str_Pedido + "' AND CCOTIZACION='" + _Pr_Str_Pedido + "'";
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
        private bool _Mtd_Pasar()
        {
            bool _Bol_Sw = false;
            if (_Mtd_PedidoEvaluando(_Txt_Pedido.Text))
            {
                _Bol_Sw = false;
                MessageBox.Show("El pedido se está evaluando por otro usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = new SqlParameter("@cpedido", SqlDbType.Int);
                paramsToStore[0].Value = _Txt_Pedido.Text.Trim();
                paramsToStore[1] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                paramsToStore[1].Value = _Str_Comp;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SPE_PEDIDOABACKORDER", paramsToStore);
                _Bol_Sw = true;
            }
            return _Bol_Sw;
            //System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
        }
        private void _Mtd_Desactivar_Checks(CheckBox _P_Chbox_Check)
        {
            _P_Chbox_Check.Click += new EventHandler(_P_Chbox_Check_Click);
        }

        void _P_Chbox_Check_Click(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            { ((CheckBox)sender).Checked = false; }
            else { ((CheckBox)sender).Checked = true; }
        }
        private void Frm_ConsultaPedidosDetalle_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Desactivar_Checks(_Chbox_BackOrder);
        }

        private void _Bt_Procesar_Click(object sender, EventArgs e)
        {
            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_FACTURA_PEDIDO"))
            {
                _Pnl_Clave.Visible = true;
            }
            else
            { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {

                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Pnl_Clave.Visible = false;
                    _Bt_Pasar.Enabled = false;
                    if (_Mtd_Pasar())
                    {
                        _Mtd_Actualizar();
                        MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        _Pnl_Clave.Visible = true;
                        _Bt_Pasar.Enabled = true;
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch (Exception er) { MessageBox.Show(er.ToString()); }
            Cursor = Cursors.Default;
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_PanelPrincipal.Enabled = false; _Dg_Grid.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_PanelPrincipal.Enabled = true; _Dg_Grid.Enabled = true; }
        }

        private void _Bt_Pasar_Click(object sender, EventArgs e)
        {
            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_RECEXISTEN_BACKORD"))
            {
                _Pnl_Clave.Visible = true;
            }
            else
            { MessageBox.Show("Su usuario no posee permiso para realizar esta operación", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
    }
}