using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaFacturaDetalle : Form
    {
        public Frm_ConsultaFacturaDetalle(string _Pr_Str_Factura)
        {
            InitializeComponent();
            _Mtd_CargarFactura(_Pr_Str_Factura);
        }
        private void _Mtd_CargarFactura(string _Pr_Str_Factura)
        {
            //string _Str_Sql = "SELECT * FROM VST_FACTURA_MAIN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + _Pr_Str_Factura + "'";

            string _Str_Sql = null;
                
            _Str_Sql = "SELECT * FROM VST_FACTURA_MAIN";
            _Str_Sql += " INNER JOIN TFPAGO ON TFPAGO.CFPAGO=VST_FACTURA_MAIN.CFPAGO";
            _Str_Sql += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Str_Sql += " AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_Sql += " AND cfactura='" + _Pr_Str_Factura + "'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_NFactura.Text = _Ds.Tables[0].Rows[0]["cfactura"].ToString();
                _Txt_NPedido.Text = _Ds.Tables[0].Rows[0]["cpedido"].ToString();
                _Txt_NGuiaDesp.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cguiadesp"]);
                _Txt_Fecha.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_factura"]).ToShortDateString();
                _Txt_Cliente.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cliente_descrip"]).Trim();
                _Str_Sql = "Select cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]) + "'";
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                { _Txt_Vendedor.Text = _Ds_A.Tables[0].Rows[0][0].ToString(); }
                else
                {
                    _Txt_Vendedor.Text = "CREADO POR OFICINA";
                }
                _Str_Sql = "SELECT SUM(cunidades) as totunidades, SUM(cempaques) as totempaques FROM TFACTURAD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_NFactura.Text + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][1]).Length > 0)
                    {
                        _Txt_Cajas.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][1]).ToString("###0.00");
                    }
                    else
                    {
                        _Txt_Cajas.Text = "0";
                    }
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
                    {
                        _Txt_Unidades.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]).ToString("###0.00");
                    }
                    else
                    {
                        _Txt_Unidades.Text = "0";
                    }
                }
                _Txt_MontoSinIVA.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si_bs"]).ToString("#,##0.00");
                _Txt_MontoIVA.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto_bs"]).ToString("#,##0.00");
                _Txt_Monto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontotot_factura"]).ToString("#,##0.00");
                _Txt_Obs.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_fact_obs"]).Trim();
                _Txt_ObsCobro.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_obs_cob"]).Trim();
                _Txt_StsDesp.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cstsdespacho"]).Trim();
                _Txt_StsCobro.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cstscobrado"]).Trim();
                _Txt_StsGen.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cstsgeneral"]).Trim();
                _Txt_NroControl.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_numerocontrol"]).Trim();
                _Txt_CondicionPago.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
                _Mtd_CargarFacturaDet(_Txt_NFactura.Text);
            }
        }
        private void _Mtd_CargarFacturaDet(string _Pr_Str_Factura)
        {
            string _Str_Sql = "SELECT cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_FACTURAD.cproducto) AS cnamef,cempaques,cunidades, dbo.Fnc_Formatear(c_monto_si_bs) as c_monto_si_bs, dbo.Fnc_Formatear(c_impuesto_bs) as c_impuesto_bs, dbo.Fnc_Formatear((c_monto_si_bs + c_impuesto_bs)) as ctotal FROM VST_FACTURAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Pr_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            object[] _Str_RowNew = new object[7];
            _Dg_Grid.Rows.Clear();
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Grid.Rows.Add(_Str_RowNew);
            }
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Frm_ConsultaFacturaDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}