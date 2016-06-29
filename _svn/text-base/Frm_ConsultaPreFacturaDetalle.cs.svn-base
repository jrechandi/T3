using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaPreFacturaDetalle : Form
    {
        public Frm_ConsultaPreFacturaDetalle()
        {
            InitializeComponent();
        }
        string _Str_CodCliente = "";
        string _Str_CodVendedor = "";
        double _Dbl_Efectividad = 0;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        Form _Frm_Formulario;
        string _Str_Company = "";
        public Frm_ConsultaPreFacturaDetalle(string _P_Str_Prefactura, string _P_Str_Pedido, string _P_Str_Fecha_Pedido, int _P_Int_Estatus, string _P_Str_CodCliente, string _P_Str_DesCliente, string _P_Str_CodVendedor, string _P_Str_DesVendedor, string _P_Str_Cajas, string _P_Str_Unidades, string _P_Str_Monto, int _P_Int_Backorder, string _P_Str_Company, Form _P_Frm_Formulario)
        {
            // desde grid de prefacturas pendientes, en control de despacho
            InitializeComponent();
            _Str_Company = _P_Str_Company;
            _Bt_Eliminar.Enabled = _Mtd_HabilitarEliminacion(_P_Str_Prefactura) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ELIMINAR_PREFACTURA");
            _Txt_Prefactura.Text = _P_Str_Prefactura;
            _Txt_Pedido.Text = _P_Str_Pedido;
            _Lbl_Fecha.Text = _P_Str_Fecha_Pedido;
            _Frm_Formulario = _P_Frm_Formulario;
            if (_P_Int_Estatus == 1)
            { _Txt_Estatus.Text = "ESPERANDO POR FACTURAR"; }
            else if (_P_Int_Estatus == 2)
            { _Txt_Estatus.Text = "EN PRE-CARGA"; }
            else if (_P_Int_Estatus == 3)
            { _Txt_Estatus.Text = "FACTURADO"; }
            _Str_CodCliente = _P_Str_CodCliente;
            _Txt_Cliente.Text = _P_Str_CodCliente + " - " + _P_Str_DesCliente;
            _Str_CodVendedor = _P_Str_CodVendedor;
            _Txt_Vendedor.Text = _P_Str_CodVendedor + ": " + _P_Str_DesVendedor;
            //_Txt_Cajas.Text = _P_Str_Cajas;
            //_Txt_Unidades.Text = _P_Str_Unidades;
            //_Txt_Monto.Text = _P_Str_Monto;

            _Txt_Cajas.Text = _Mtd_TotalCajasPrefactura(_P_Str_Company, _P_Str_Prefactura, _P_Str_Pedido);
            _Txt_Unidades.Text = _Mtd_TotalUnidadesPrefactura(_P_Str_Company, _P_Str_Prefactura, _P_Str_Pedido);
            _Txt_Monto.Text = Convert.ToDouble(_Mtd_TotalMontoPrefactura(_P_Str_Company, _P_Str_Prefactura, _P_Str_Pedido)).ToString("#,##0.00");

            string _Str_Sql = "SELECT cefectividad FROM TCOTPEDFACM WHERE ccompany='" + _Str_Company + "' AND cpedido='" + _Txt_Pedido.Text + "' AND CCOTIZACION='" + _Txt_Pedido.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cefectividad"]).Trim().Length > 0)
                {
                    _Dbl_Efectividad = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cefectividad"]);
                }
            }
            _Lbl_Porcentaje.Text = _Dbl_Efectividad.ToString() + "%";
            if (_Dbl_Efectividad > 100)
            { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
            else
            { _Prb_Efectividad.Value = Convert.ToInt32(_Dbl_Efectividad); }
            _Chbox_BackOrder.Checked = Convert.ToBoolean(_P_Int_Backorder);

            _Str_Sql = "";
            _Str_Sql += "SELECT dbo.TFACTURAM.ccompany, dbo.TFACTURAM.cfactura, SUM(dbo.TFACTURAD.cempaques) AS ccajas, SUM(dbo.TFACTURAD.cunidades) AS cunidades,";
            _Str_Sql += " dbo.Fnc_Formatear(SUM(dbo.TFACTURAD.c_monto_si_bs)) AS cmonto FROM dbo.TFACTURAM LEFT OUTER JOIN dbo.TFACTURAD";
            _Str_Sql += " ON dbo.TFACTURAM.cgroupcomp = dbo.TFACTURAD.cgroupcomp AND dbo.TFACTURAM.ccompany = dbo.TFACTURAD.ccompany AND dbo.TFACTURAM.cfactura = dbo.TFACTURAD.cfactura";
            _Str_Sql += " GROUP BY dbo.TFACTURAM.cfactura, dbo.TFACTURAM.cgroupcomp, dbo.TFACTURAM.ccompany, dbo.TFACTURAM.cpfactura";
            _Str_Sql += " HAVING (TFACTURAM.cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (TFACTURAM.ccompany = '" + _Str_Company + "') AND (TFACTURAM.cpfactura = " + _Txt_Prefactura.Text + ") ";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //_Txt_Factura.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cfactura"]);
                _Dg_Facturas.DataSource = _Ds.Tables[0];
                _Dg_Facturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                _Dg_Facturas.ClearSelection();
            }
            

            string _Str_Cadena = "SELECT TDDESPACHOC.c_direcc_despa,TDDESPACHOC.c_direcc_descrip " +
                                 ",TESTATE.cname as NombreEstado, TCITY.cname AS NombreCiudad" +
                                 " FROM TPREFACTURAM INNER JOIN TDDESPACHOC ON TPREFACTURAM.ccliente = TDDESPACHOC.ccliente AND TPREFACTURAM.c_direcc_despa = TDDESPACHOC.c_direcc_despa LEFT OUTER JOIN TCITY ON TDDESPACHOC.c_ciudad = TCITY.ccity FULL OUTER JOIN TESTATE ON TCITY.cestate = TESTATE.cestate AND TDDESPACHOC.c_estado = TESTATE.cestate AND TDDESPACHOC.cgroupcomp = TESTATE.cgroupcomp " + 
                                 "WHERE (TPREFACTURAM.ccompany = '" + _Str_Company + "') AND (TPREFACTURAM.cpfactura = '" + _P_Str_Prefactura + "') AND (TPREFACTURAM.ccliente='" + _P_Str_CodCliente + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Direccion.Text = _Ds.Tables[0].Rows[0]["c_direcc_despa"].ToString().Trim() + " - " + _Ds.Tables[0].Rows[0]["c_direcc_descrip"].ToString().Trim();
                _Txt_Estado.Text = _Ds.Tables[0].Rows[0]["NombreEstado"].ToString();
                _Txt_Ciudad.Text = _Ds.Tables[0].Rows[0]["NombreCiudad"].ToString();
            }
            _Txt_Obs.Text = _Mtd_ObtenerObservacion(_P_Str_Pedido);
            _Str_Cadena = "SELECT TPREFACTURAD.cproducto, CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEFC) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEFC) END AS produc_descrip, TPREFACTURAD.cempaques, TPREFACTURAD.cunidades, dbo.Fnc_Formatear(dbo.TPREFACTURAD.c_monto_si) AS c_monto_si " +
"FROM TPREFACTURAD INNER JOIN " +
"TPRODUCTO ON TPREFACTURAD.cproducto = TPRODUCTO.cproducto INNER JOIN " +
"TMARCASM ON TPRODUCTO.cmarca = TMARCASM.cmarca " +
"WHERE (TPREFACTURAD.ccompany = '" + _Str_Company + "') AND (TPREFACTURAD.cpedido = '" + _Txt_Pedido.Text.Trim() + "') AND (TPREFACTURAD.cpfactura = '" + _Txt_Prefactura.Text.Trim() + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public Frm_ConsultaPreFacturaDetalle(string _P_Str_Prefactura, string _P_Str_CodCliente, string _P_Str_Cajas, string _P_Str_Unidades, string _P_Str_Monto, string _P_Str_Rif, string _P_Str_Company)
        {
            //desde grid de pre facturas en "crear precarga"
            InitializeComponent();
            _Str_Company = _P_Str_Company;
            _Txt_Prefactura.Text = _P_Str_Prefactura;
            string _Str_Cadena = "Select cpedido,cvendedor,convert(varchar, c_fecha_pedido,103) as c_fecha_pedido,cfacturado,clistofacturar,cprecarga,c_ped_obs from TPREFACTURAM where ccompany='" + _Str_Company + "' and cpfactura='" + _P_Str_Prefactura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_Precaga = 0;
                if (_Ds.Tables[0].Rows[0]["cprecarga"] != System.DBNull.Value)
                { _Int_Precaga = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cprecarga"].ToString()); }
                _Txt_Obs.Text = _Mtd_ObtenerObservacion(Convert.ToString(_Ds.Tables[0].Rows[0]["cpedido"]).Trim());
                _Txt_Pedido.Text = _Ds.Tables[0].Rows[0]["cpedido"].ToString();
                _Lbl_Fecha.Text = _Ds.Tables[0].Rows[0]["c_fecha_pedido"].ToString();
                _Str_CodVendedor = _Ds.Tables[0].Rows[0]["cvendedor"].ToString();
                if (_Ds.Tables[0].Rows[0]["cfacturado"].ToString().Trim() == "1")
                { _Txt_Estatus.Text = "FACTURADO"; }
                else if (_Ds.Tables[0].Rows[0]["clistofacturar"].ToString().Trim() == "1" & _Ds.Tables[0].Rows[0]["cprecarga"].ToString().Trim() == "0" & _Ds.Tables[0].Rows[0]["cfacturado"].ToString().Trim() == "0")
                { _Txt_Estatus.Text = "ESPERANDO POR FACTURAR"; }
                else if (_Ds.Tables[0].Rows[0]["clistofacturar"].ToString().Trim() == "1" & _Int_Precaga > 0 & _Ds.Tables[0].Rows[0]["cfacturado"].ToString().Trim() == "0")
                { _Txt_Estatus.Text = "EN PRE-CARGA"; }
                _Str_Cadena = "Select cname from TVENDEDOR where ccompany='" + _Str_Company + "' and cvendedor='" + _Str_CodVendedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Txt_Vendedor.Text = _Str_CodVendedor + ": " + _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            }
            _Str_Cadena = "Select cefectividad from TCOTPEDFACM where ccompany='" + _Str_Company + "' and cpedido='" + _Txt_Pedido.Text.Trim() + "' and CCOTIZACION='" + _Txt_Pedido.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Dbl_Efectividad = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString()); }
                _Lbl_Porcentaje.Text = _Dbl_Efectividad.ToString() + "%";
                if (_Dbl_Efectividad > 100)
                { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
                else
                { _Prb_Efectividad.Value = Convert.ToInt32(_Dbl_Efectividad); }
            }
            _Str_CodCliente = _P_Str_CodCliente;
            _Str_Cadena = "Select c_nomb_comer,cbackorder from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_CodCliente + "' and c_rif='" + _P_Str_Rif + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_Backorder = 0;
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                { _Int_Backorder = Convert.ToInt32(_Ds.Tables[0].Rows[0][1].ToString()); }
                _Chbox_BackOrder.Checked = Convert.ToBoolean(_Int_Backorder);
                _Txt_Cliente.Text = _P_Str_CodCliente + " - " + _Ds.Tables[0].Rows[0]["c_nomb_comer"].ToString();
            }
            _Str_Cadena = "SELECT TDDESPACHOC.c_direcc_despa,TDDESPACHOC.c_direcc_descrip " +
                          ",TESTATE.cname as NombreEstado, TCITY.cname AS NombreCiudad" +
                          " FROM TPREFACTURAM INNER JOIN TDDESPACHOC ON TPREFACTURAM.ccliente = TDDESPACHOC.ccliente AND TPREFACTURAM.c_direcc_despa = TDDESPACHOC.c_direcc_despa LEFT OUTER JOIN TCITY ON TDDESPACHOC.c_ciudad = TCITY.ccity FULL OUTER JOIN TESTATE ON TCITY.cestate = TESTATE.cestate AND TDDESPACHOC.c_estado = TESTATE.cestate AND TDDESPACHOC.cgroupcomp = TESTATE.cgroupcomp " + 
                          "WHERE (TPREFACTURAM.ccompany = '" + _Str_Company + "') AND (TPREFACTURAM.cpfactura = '" + _P_Str_Prefactura + "') AND (TPREFACTURAM.ccliente='" + _P_Str_CodCliente + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Direccion.Text = _Ds.Tables[0].Rows[0]["c_direcc_despa"].ToString() + " - " + _Ds.Tables[0].Rows[0]["c_direcc_descrip"].ToString().Trim();
                _Txt_Estado.Text = _Ds.Tables[0].Rows[0]["NombreEstado"].ToString();
                _Txt_Ciudad.Text = _Ds.Tables[0].Rows[0]["NombreCiudad"].ToString();
            }
            
            //_Txt_Cajas.Text = _P_Str_Cajas;
            //_Txt_Unidades.Text = _P_Str_Unidades;
            //_Txt_Monto.Text = Convert.ToDouble(_P_Str_Monto).ToString("#,##0.00");

            _Txt_Cajas.Text = _Mtd_TotalCajasPrefactura(_P_Str_Company, _P_Str_Prefactura, _Txt_Pedido.Text);
            _Txt_Unidades.Text = _Mtd_TotalUnidadesPrefactura(_P_Str_Company, _P_Str_Prefactura, _Txt_Pedido.Text);
            _Txt_Monto.Text = Convert.ToDouble(_Mtd_TotalMontoPrefactura(_P_Str_Company, _P_Str_Prefactura, _Txt_Pedido.Text)).ToString("#,##0.00");

            
            
            
            _Str_Cadena = "SELECT TPREFACTURAD.cproducto, CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEFC) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEFC) END AS produc_descrip, TPREFACTURAD.cempaques, TPREFACTURAD.cunidades, dbo.Fnc_Formatear(dbo.TPREFACTURAD.c_monto_si) AS c_monto_si " +
"FROM TPREFACTURAD INNER JOIN " +
"TPRODUCTO ON TPREFACTURAD.cproducto = TPRODUCTO.cproducto INNER JOIN " +
"TMARCASM ON TPRODUCTO.cmarca = TMARCASM.cmarca " +
"WHERE (TPREFACTURAD.ccompany = '" + _Str_Company + "') AND (TPREFACTURAD.cpedido = '" + _Txt_Pedido.Text.Trim() + "') AND (TPREFACTURAD.cpfactura = '" + _Txt_Prefactura.Text.Trim() + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string _Str_Sql = ""; 
            _Str_Sql += "SELECT dbo.TFACTURAM.ccompany, dbo.TFACTURAM.cfactura, SUM(dbo.TFACTURAD.cempaques) AS ccajas, SUM(dbo.TFACTURAD.cunidades) AS cunidades,";
            _Str_Sql += " dbo.Fnc_Formatear(SUM(dbo.TFACTURAD.c_monto_si_bs)) AS cmonto FROM dbo.TFACTURAM LEFT OUTER JOIN dbo.TFACTURAD";
            _Str_Sql += " ON dbo.TFACTURAM.cgroupcomp = dbo.TFACTURAD.cgroupcomp AND dbo.TFACTURAM.ccompany = dbo.TFACTURAD.ccompany AND dbo.TFACTURAM.cfactura = dbo.TFACTURAD.cfactura";
            _Str_Sql += " GROUP BY dbo.TFACTURAM.cfactura, dbo.TFACTURAM.cgroupcomp, dbo.TFACTURAM.ccompany, dbo.TFACTURAM.cpfactura";
            _Str_Sql += " HAVING (TFACTURAM.cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (TFACTURAM.ccompany = '" + _Str_Company + "') AND (TFACTURAM.cpfactura = " + _Txt_Prefactura.Text + ") ";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //_Txt_Factura.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cfactura"]);
                _Dg_Facturas.DataSource = _Ds.Tables[0];
                _Dg_Facturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                _Dg_Facturas.ClearSelection();
            }
        }
        public Frm_ConsultaPreFacturaDetalle(string _P_Str_Prefactura, string _P_Str_Company)
        {
            //desde busqueda2
            InitializeComponent();
            _Str_Company = _P_Str_Company;
            _Txt_Prefactura.Text = _P_Str_Prefactura;
            string _Str_Cadena = "SELECT TPREFACTURAM.cpedido, TPREFACTURAM.cvendedor, CONVERT(varchar, TPREFACTURAM.c_fecha_pedido, 103) AS c_fecha_pedido, TPREFACTURAM.cfacturado, TPREFACTURAM.clistofacturar, TPREFACTURAM.cprecarga, SUM(TPREFACTURAD.cunidades) AS cunidades, SUM(TPREFACTURAD.cempaques) AS cempaques, dbo.Fnc_Formatear(TPREFACTURAM.c_montotot_si) AS c_montotot_si, TPREFACTURAM.ccliente FROM TPREFACTURAM INNER JOIN TPREFACTURAD ON TPREFACTURAM.ccompany = TPREFACTURAD.ccompany AND TPREFACTURAM.cpfactura = TPREFACTURAD.cpfactura AND TPREFACTURAM.cpedido = TPREFACTURAD.cpedido WHERE (TPREFACTURAM.ccompany = '" + _Str_Company + "') AND (TPREFACTURAM.cpfactura = '" + _P_Str_Prefactura + "') GROUP BY TPREFACTURAM.cpedido, TPREFACTURAM.cvendedor, TPREFACTURAM.cfacturado, TPREFACTURAM.c_fecha_pedido, TPREFACTURAM.cprecarga, TPREFACTURAM.clistofacturar, TPREFACTURAM.ccompany, TPREFACTURAM.cpfactura, c_montotot_si, TPREFACTURAM.ccliente";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_Precaga = 0;
                if (_Ds.Tables[0].Rows[0]["cprecarga"] != System.DBNull.Value)
                { _Int_Precaga = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cprecarga"].ToString()); }
                _Txt_Obs.Text = _Mtd_ObtenerObservacion(Convert.ToString(_Ds.Tables[0].Rows[0]["cpedido"]).Trim());
                _Txt_Pedido.Text = _Ds.Tables[0].Rows[0]["cpedido"].ToString();
                _Lbl_Fecha.Text = _Ds.Tables[0].Rows[0]["c_fecha_pedido"].ToString();
                _Str_CodVendedor = _Ds.Tables[0].Rows[0]["cvendedor"].ToString();
                if (_Ds.Tables[0].Rows[0]["cfacturado"].ToString().Trim() == "1")
                { _Txt_Estatus.Text = "FACTURADO"; }
                else if (_Ds.Tables[0].Rows[0]["clistofacturar"].ToString().Trim() == "1" & _Ds.Tables[0].Rows[0]["cprecarga"].ToString().Trim() == "0" & _Ds.Tables[0].Rows[0]["cfacturado"].ToString().Trim() == "0")
                { _Txt_Estatus.Text = "ESPERANDO POR FACTURAR"; }
                else if (_Ds.Tables[0].Rows[0]["clistofacturar"].ToString().Trim() == "1" & _Int_Precaga > 0 & _Ds.Tables[0].Rows[0]["cfacturado"].ToString().Trim() == "0")
                { _Txt_Estatus.Text = "EN PRE-CARGA"; }
                _Str_CodCliente = _Ds.Tables[0].Rows[0]["ccliente"].ToString();
               
                //_Txt_Cajas.Text = _Ds.Tables[0].Rows[0]["cempaques"].ToString();
                //_Txt_Unidades.Text = _Ds.Tables[0].Rows[0]["cunidades"].ToString();
                //_Txt_Monto.Text = _Ds.Tables[0].Rows[0]["c_montotot_si"].ToString();

                _Txt_Cajas.Text = _Mtd_TotalCajasPrefactura(_P_Str_Company, _P_Str_Prefactura, _Txt_Pedido.Text);
                _Txt_Unidades.Text = _Mtd_TotalUnidadesPrefactura(_P_Str_Company, _P_Str_Prefactura, _Txt_Pedido.Text);
                _Txt_Monto.Text = Convert.ToDouble(_Mtd_TotalMontoPrefactura(_P_Str_Company, _P_Str_Prefactura, _Txt_Pedido.Text)).ToString("#,##0.00");

                _Str_Cadena = "Select cname from TVENDEDOR where ccompany='" + _Str_Company + "' and cvendedor='" + _Str_CodVendedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Txt_Vendedor.Text = _Str_CodVendedor + ": " + _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            }
            _Str_Cadena = "Select cefectividad from TCOTPEDFACM where ccompany='" + _Str_Company + "' and cpedido='" + _Txt_Pedido.Text.Trim() + "' and CCOTIZACION='" + _Txt_Pedido.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Dbl_Efectividad = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString()); }
                _Lbl_Porcentaje.Text = _Dbl_Efectividad.ToString() + "%";
                if (_Dbl_Efectividad > 100)
                { _Prb_Efectividad.Value = _Prb_Efectividad.Maximum; }
                else
                { _Prb_Efectividad.Value = Convert.ToInt32(_Dbl_Efectividad); }
            }
            _Str_Cadena = "Select c_nomb_comer,cbackorder from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Str_CodCliente + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_Backorder = 0;
                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                { _Int_Backorder = Convert.ToInt32(_Ds.Tables[0].Rows[0][1].ToString()); }
                _Chbox_BackOrder.Checked = Convert.ToBoolean(_Int_Backorder);
                _Txt_Cliente.Text = _Str_CodCliente + " - " + _Ds.Tables[0].Rows[0]["c_nomb_comer"].ToString();
            }
            _Str_Cadena = "SELECT TDDESPACHOC.c_direcc_despa,TDDESPACHOC.c_direcc_descrip " +
                          ",TESTATE.cname as NombreEstado, TCITY.cname AS NombreCiudad" +
                          " FROM TPREFACTURAM INNER JOIN TDDESPACHOC ON TPREFACTURAM.ccliente = TDDESPACHOC.ccliente AND TPREFACTURAM.c_direcc_despa = TDDESPACHOC.c_direcc_despa LEFT OUTER JOIN TCITY ON TDDESPACHOC.c_ciudad = TCITY.ccity FULL OUTER JOIN TESTATE ON TCITY.cestate = TESTATE.cestate AND TDDESPACHOC.c_estado = TESTATE.cestate AND TDDESPACHOC.cgroupcomp = TESTATE.cgroupcomp " + 
                          "WHERE (TPREFACTURAM.ccompany = '" + _Str_Company + "') AND (TPREFACTURAM.cpfactura = '" + _P_Str_Prefactura + "') AND (TPREFACTURAM.ccliente='" + _Str_CodCliente + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Direccion.Text = _Ds.Tables[0].Rows[0]["c_direcc_despa"].ToString() + " - " + _Ds.Tables[0].Rows[0]["c_direcc_descrip"].ToString().Trim();
                _Txt_Estado.Text = _Ds.Tables[0].Rows[0]["NombreEstado"].ToString();
                _Txt_Ciudad.Text = _Ds.Tables[0].Rows[0]["NombreCiudad"].ToString();
            }
            _Str_Cadena = "SELECT TPREFACTURAD.cproducto, CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEFC) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEFC) END AS produc_descrip, TPREFACTURAD.cempaques, TPREFACTURAD.cunidades, dbo.Fnc_Formatear(dbo.TPREFACTURAD.c_monto_si) AS c_monto_si " +
"FROM TPREFACTURAD INNER JOIN " +
"TPRODUCTO ON TPREFACTURAD.cproducto = TPRODUCTO.cproducto INNER JOIN " +
"TMARCASM ON TPRODUCTO.cmarca = TMARCASM.cmarca " +
"WHERE (TPREFACTURAD.ccompany = '" + _Str_Company + "') AND (TPREFACTURAD.cpedido = '" + _Txt_Pedido.Text.Trim() + "') AND (TPREFACTURAD.cpfactura = '" + _Txt_Prefactura.Text.Trim() + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string _Str_Sql = "";
            _Str_Sql += "SELECT dbo.TFACTURAM.ccompany, dbo.TFACTURAM.cfactura, SUM(dbo.TFACTURAD.cempaques) AS ccajas, SUM(dbo.TFACTURAD.cunidades) AS cunidades,";
            _Str_Sql += " dbo.Fnc_Formatear(SUM(dbo.TFACTURAD.c_monto_si_bs)) AS cmonto FROM dbo.TFACTURAM LEFT OUTER JOIN dbo.TFACTURAD";
            _Str_Sql += " ON dbo.TFACTURAM.cgroupcomp = dbo.TFACTURAD.cgroupcomp AND dbo.TFACTURAM.ccompany = dbo.TFACTURAD.ccompany AND dbo.TFACTURAM.cfactura = dbo.TFACTURAD.cfactura";
            _Str_Sql += " GROUP BY dbo.TFACTURAM.cfactura, dbo.TFACTURAM.cgroupcomp, dbo.TFACTURAM.ccompany, dbo.TFACTURAM.cpfactura";
            _Str_Sql += " HAVING (TFACTURAM.cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (TFACTURAM.ccompany = '" + _Str_Company + "') AND (TFACTURAM.cpfactura = " + _Txt_Prefactura.Text + ") ";
            
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //_Txt_Factura.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cfactura"]);
                _Dg_Facturas.DataSource = _Ds.Tables[0];
                _Dg_Facturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                _Dg_Facturas.ClearSelection();
            }
        }
        private string _Mtd_ObtenerObservacion(string _P_Str_Pedido)
        {
            if (_P_Str_Pedido.Trim().Length > 0)
            {
                string _Str_Cadena = "SELECT cobservaciones FROM TCOTPEDFACM WHERE ccompany='" + _Str_Company + "' AND cpedido='" + _P_Str_Pedido + "' AND CCOTIZACION='" + _P_Str_Pedido + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                }
            }
            return "";
        }
        private bool _Mtd_HabilitarEliminacion(string _P_Str_Prefactura)
        {
            string _Str_Cadena = "SELECT cfacturado FROM TPREFACTURAM WHERE ccompany='" + _Str_Company + "' AND cpfactura='" + _P_Str_Prefactura + "' AND (cfacturado='0' OR cfacturado IS NULL)";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_EliminarPreFactura(string _P_Str_Prefactura)
        {            
            string _Str_Cadena = "EXEC PA_ELIMINARPREFACTURA '" + _Str_Company + "','" + _P_Str_Prefactura + "','" + Frm_Padre._Str_Use + "'";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            if (_Txt_ObservacionesAnular.Text.Trim().Length > 255)
            {
                _Txt_ObservacionesAnular.Text = _Txt_ObservacionesAnular.Text.Substring(0, 255);
            }
            _Str_Cadena = "UPDATE TCOTPEDFACM";
            _Str_Cadena += " SET C_OBS_RECHAZADO='" + _Txt_ObservacionesAnular.Text.Trim() + "',CDATEUPD=GETDATE() WHERE CCOMPANY='" + _Str_Company + "'";
            _Str_Cadena += " AND CPEDIDO='" + _Txt_Pedido.Text.Trim() + "' AND CCOTIZACION='" + _Txt_Pedido.Text.Trim() + "'";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
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
        private void Frm_ConsultaPreFacturaDetalle_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Desactivar_Checks(_Chbox_BackOrder);
            _Mtd_ColorearGridFacturas();
            _Lbl_DevueltaAnu.BackColor = Color.FromArgb(255, 90, 90);
        }
        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_BloquearAnulacionPrefacturasSegunCierreVentas())
            {
                MessageBox.Show("De acuerdo al calendario no se puede eliminar prefacturas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_Mtd_HabilitarEliminacion(_Txt_Prefactura.Text.Trim()))
            {
                if (MessageBox.Show("¿Esta seguro de eliminar la prefactura '" + _Txt_Prefactura.Text.Trim() + "'?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Pnl_Clave.Visible = true;
                }
            }
            else
            { MessageBox.Show("La prefactura '" + _Txt_Prefactura.Text.Trim() + "' ya ha sido facturada. No se puede realizar la operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Bt_Eliminar.Enabled = false; }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Txt_ObservacionesAnular.Text.Trim() != "")
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_EliminarPreFactura(_Txt_Prefactura.Text.Trim());
                    if (_Frm_Formulario.GetType() == (typeof(Frm_ConsultaPreFactura)))
                    { ((Frm_ConsultaPreFactura)_Frm_Formulario)._Mtd_Actualizar(); }
                    else if (_Frm_Formulario.GetType() == (typeof(Frm_ControlDespacho)))
                    { ((Frm_ControlDespacho)_Frm_Formulario)._Mtd_Actualizar_Dg_GridPreFacturas(-1, ""); }
                    else if (_Frm_Formulario.GetType() == (typeof(Frm_ConsultaMultiple)))
                    { ((Frm_ConsultaMultiple)_Frm_Formulario)._Mtd_LlenarGridPreFactura(); }
                    Cursor = Cursors.Default;
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Indique una observación de porqué se está haciendo la anulación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Txt_ObservacionesAnular.Focus();
                }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_PanelPrincipal.Enabled = false; _Dg_Grid.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_PanelPrincipal.Enabled = true; _Dg_Grid.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Mtd_ColorearGridFacturas()
        {
            string _Str_CodFactura = "";
            string _Str_CodCompania = "";

            foreach (DataGridViewRow _Dg_Row in _Dg_Facturas.Rows)
            {
                _Str_CodFactura = _Dg_Row.Cells["_Col_Cfactura"].Value.ToString().Trim();
                _Str_CodCompania = _Dg_Row.Cells["_Col_Ccompany"].Value.ToString().Trim();
                
                _Dg_Row.DefaultCellStyle.BackColor = Color.White;

                if (_Mtd_FacturaEstaDevuelta(_Str_CodFactura))
                { 
                    _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                    if (_Mtd_FacturaEstaDevueltaParaAnular(_Str_CodFactura)) _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 90, 90);
                }

                if (_Mtd_FacturaEstaAnulada(_Str_CodCompania, _Str_CodFactura)) _Dg_Row.DefaultCellStyle.BackColor = Color.DimGray;
            }
        }

        private bool _Mtd_FacturaEstaDevuelta(string _Str_CodFactura)
        {
            string _Str_SQL = "SELECT cfactura FROM TGUIADESPACHOD WHERE (cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (c_estatus = 'DEV') AND (cfactura = " + _Str_CodFactura + ") AND NOT EXISTS (SELECT cfactura FROM TFACTURANUL WHERE TGUIADESPACHOD.ccompany = ccompany AND TGUIADESPACHOD.cfactura = cfactura)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return true; else return false;
        }

        private bool _Mtd_FacturaEstaDevueltaParaAnular(string _Str_CodFactura)
        {
            string _Str_SQL = "SELECT cfactura FROM TGUIADESPACHOD WHERE (cgroupcomp = " + Frm_Padre._Str_GroupComp + ") AND (c_devanular = 1) AND (cfactura = " + _Str_CodFactura + ") AND NOT EXISTS (SELECT cfactura FROM TFACTURANUL WHERE TGUIADESPACHOD.ccompany = ccompany AND TGUIADESPACHOD.cfactura = cfactura)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return true; else return false;
        }

        private bool _Mtd_FacturaEstaAnulada(string _Str_CodCompania, string _Str_CodFactura)
        {
            string _Str_SQL = "SELECT cfactura FROM TFACTURANUL WHERE (ccompany = '" + _Str_CodCompania + "') AND (cfactura = " + _Str_CodFactura + ")";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return true; else return false;
        }

        private void _Dg_Facturas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_ColorearGridFacturas();
        }

        private string _Mtd_TotalMontoPrefactura(string _Str_CodCompania, string _Str_CodPreFactura, string _Str_CodPedido)
        {
            string _Str_SQL = "SELECT SUM(c_monto_si) as suma FROM TPREFACTURAD WHERE ccompany = '" +_Str_CodCompania +"' AND cpfactura = " + _Str_CodPreFactura +" and cpedido="+_Str_CodPedido; 
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); else return "0";
        }

        private string _Mtd_TotalCajasPrefactura(string _Str_CodCompania, string _Str_CodPreFactura, string _Str_CodPedido)
        {
            string _Str_SQL = "SELECT SUM(cempaques) as suma FROM TPREFACTURAD WHERE ccompany = '" + _Str_CodCompania + "' AND cpfactura = " + _Str_CodPreFactura +" and cpedido="+_Str_CodPedido;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); else return "0";
        }

        private string _Mtd_TotalUnidadesPrefactura(string _Str_CodCompania, string _Str_CodPreFactura, string _Str_CodPedido)
        {
            string _Str_SQL = "SELECT SUM(cunidades) as suma FROM TPREFACTURAD WHERE ccompany = '" + _Str_CodCompania + "' AND cpfactura = " + _Str_CodPreFactura + " and cpedido=" + _Str_CodPedido; 
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0) return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); else return "0";
        }

    }
}