using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace T3.Clases
{
    public class _Cls_ProcesosCont
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _G_Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public const string _G_Str_CuentaContProv = "PRV.X";
        public const string _G_Str_CuentaContBanco = "BNC.X";
        string _G_Str_IdProcesoCont = "";
        public _Cls_ProcesosCont(string _Pr_Str_IdProcesoCont)
        {
            _G_Str_IdProcesoCont = _Pr_Str_IdProcesoCont;
        }

        public static string _Mtd_ContableAno(string _Pr_Str_Fecha)
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cyearacco FROM TCALENDCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' and convert(varchar,cdiafecha_cal,103)=convert(varchar,convert(datetime,'" + _Pr_Str_Fecha + "'),103)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0]["cyearacco"]);
            }
            return _Str_R;
        }
        public static string _Mtd_ContableAno(string _Pr_Str_Fecha, string _P_Str_Comp)
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cyearacco FROM TCALENDCONT WHERE ccompany='" + _P_Str_Comp + "' and convert(varchar,cdiafecha_cal,103)=convert(varchar,convert(datetime,'" + _Pr_Str_Fecha + "'),103)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0]["cyearacco"]);
            }
            return _Str_R;
        }
        public static string _Mtd_ContableMes(string _Pr_Str_Fecha)
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cmontacco FROM TCALENDCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' and convert(varchar,cdiafecha_cal,103)=convert(varchar,convert(datetime,'" + _Pr_Str_Fecha + "'),103)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0]["cmontacco"]);
            }
            return _Str_R;
        }
        public static string _Mtd_ContableMes(string _Pr_Str_Fecha, string _P_Str_Comp)
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cmontacco FROM TCALENDCONT WHERE ccompany='" + _P_Str_Comp + "' and convert(varchar,cdiafecha_cal,103)=convert(varchar,convert(datetime,'" + _Pr_Str_Fecha + "'),103)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0]["cmontacco"]);
            }
            return _Str_R;
        }
        public void _Mtd_Proceso_P_AVISO_COBRO_COBRAR(DataGridView _Pr_Dg_Grid, string _Pr_Str_Proveedor, double _Pr_Dbl_Monto)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }

            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {

                    _Str_CountCont = "XXXX";
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Str_CountContName = "CUENTA DEUDORA";
                    }
                    else
                    {
                        _Str_CountContName = "CUENTA ACREEDORA";
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Pr_Dbl_Monto > 0)
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + " " + _Str_ProveedorName;
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Pr_Dbl_Monto.ToString("#,##0.00");
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Pr_Dbl_Monto.ToString("#,##0.00");
                    }
                }
            }
        }
        /// <summary>
        /// Carga la Plantilla del Comprobante Contable P_CXC_COBRO_CIA_RELA
        /// </summary>
        /// <param name="_Pr_Dg_Grid"></param>
        public void _Mtd_Proceso_P_CXC_COBRO_CIA_RELA(DataGridView _Pr_Dg_Grid)
        {
            string _Str_CountCont = "";
            string _Str_CountContName = "";
            string _Str_Sql = "";
            double _Dbl_MontoGrid = 0;

            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {

                    _Str_CountCont = "XXXX";
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Str_CountContName = "CUENTA DEUDORA";
                    }
                    else
                    {
                        _Str_CountContName = "CUENTA ACREEDORA";
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Dbl_MontoGrid >= 0)
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName;
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                }
            }
        }
        public void _Mtd_Proceso_CTAXPAGAR(DataGridView _Pr_Dg_Grid, string _Pr_Str_Factura, string _Pr_Str_Proveedor, string _Pr_Str_cglobal, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, string _Pr_Str_FechaVenc, double _Pr_Dbl_MontoPlanAhorro, double _Pr_Dbl_MontoInvendible, double _Pr_Dbl_MontoDescuentoFinanciero, IEnumerable<_Cls_Impuesto> _Pr_Impuestos)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Datos = "";
            if (_G_Str_IdProcesoCont == "CXP_NCP" | _G_Str_IdProcesoCont == "CXP_NCPSO")
            { _Str_Datos = " S/NC # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            else if (_G_Str_IdProcesoCont == "CXP_NDP" | _G_Str_IdProcesoCont == "CXP_NDPSO")
            { _Str_Datos = " S/ND # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            else
            { _Str_Datos = " S/F # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                _Str_CountCont = "";
                _Str_CountContName = "";
                _Dbl_MontoGrid = 0;
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Str_Sql = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.ctcount AS ctcountc,TCOUNT.cname AS ctcountname FROM TPROVEEDOR INNER JOIN " +
                        "TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany WHERE TCOUNT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cproveedor='" + _Pr_Str_Proveedor + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountCont = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountc"]).Trim();
                            _Str_CountContName = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"]).Trim().ToUpper();
                        }
                    }
                    else// if (_Pr_Str_cglobal == "2")
                    {
                        _Str_CountCont = "XXXX";
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Str_CountContName = "CUENTA DEUDORA";
                        }
                        else
                        {
                            _Str_CountContName = "CUENTA ACREEDORA";
                        }
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Drow["cideprocesod"].ToString() == "1")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoSimp;
                }
                else if (_Drow["cideprocesod"].ToString() == "2")
                {
                    _Pr_Impuestos.Where(x => x.Impuesto > 0).ToList().ForEach(x =>
                    {
                        _Pr_Dg_Grid.Rows.Add();
                        _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                        _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + " " + x.Alicuota + "%" + _Str_Datos;
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = x.Impuesto.ToString("#,##0.00");
                            _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        }
                        else
                        {
                            _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                            _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = x.Impuesto.ToString("#,##0.00");
                        }
                    });
                }
                else if (_Drow["cideprocesod"].ToString() == "3")
                {
                    _Dbl_MontoGrid = ((_Pr_Dbl_MontoSimp + _Pr_Dbl_MontoImp) - _Pr_Dbl_MontoPlanAhorro) - _Pr_Dbl_MontoInvendible - _Pr_Dbl_MontoDescuentoFinanciero;
                }
                else if (_Drow["cideprocesod"].ToString() == "4")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoInvendible;
                }
                else if (_Drow["cideprocesod"].ToString() == "5")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoPlanAhorro;
                }
                else if (_Drow["cideprocesod"].ToString() == "6")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoDescuentoFinanciero;
                }
                if (_Dbl_MontoGrid > 0 && _Drow["cideprocesod"].ToString() != "2")
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                }
            }
        }
        public void _Mtd_Proceso_P_CXP_ACC(DataGridView _Pr_Dg_Grid, string _Pr_Str_Factura, string _Pr_Str_Proveedor, string _Pr_Str_cglobal, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, string _Pr_Str_FechaVenc, int _P_Int_SwTipoDoc, double _Pr_Dbl_MontoInvendible, double _Pr_Dbl_MontoDescuentoFinanciero, IEnumerable<_Cls_Impuesto> _Pr_Impuestos)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Datos = "";
            if (_P_Int_SwTipoDoc == 1)
            { _Str_Datos = " S/F # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            else if (_P_Int_SwTipoDoc == 2)
            { _Str_Datos = " S/ND # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            else
            { _Str_Datos = " S/NC # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                _Str_CountCont = "";
                _Str_CountContName = "";
                _Dbl_MontoGrid = 0;
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Str_Sql = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.ctcount AS ctcountc,TCOUNT.cname AS ctcountname FROM TPROVEEDOR INNER JOIN " +
                        "TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany WHERE TCOUNT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cproveedor='" + _Pr_Str_Proveedor + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountCont = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountc"]).Trim();
                            _Str_CountContName = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"]).Trim().ToUpper();
                        }

                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Str_CountCont = "XXXX";
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Str_CountContName = "CUENTA DEUDORA";
                        }
                        else
                        {
                            _Str_CountContName = "CUENTA ACREEDORA";
                        }
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Drow["cideprocesod"].ToString() == "1")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoSimp;
                }
                else if (_Drow["cideprocesod"].ToString() == "2")
                {
                    _Pr_Impuestos.Where(x => x.Impuesto > 0).ToList().ForEach(x =>
                    {
                        _Pr_Dg_Grid.Rows.Add();
                        _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                        _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + " " + x.Alicuota + "%" + _Str_Datos;
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = x.Impuesto.ToString("#,##0.00");
                            _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        }
                        else
                        {
                            _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                            _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = x.Impuesto.ToString("#,##0.00");
                        }
                    });
                }
                else if (_Drow["cideprocesod"].ToString() == "3")
                {
                    _Dbl_MontoGrid = (_Pr_Dbl_MontoSimp + _Pr_Dbl_MontoImp) - _Pr_Dbl_MontoInvendible - _Pr_Dbl_MontoDescuentoFinanciero;
                }
                else if (_Drow["cideprocesod"].ToString() == "4")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoInvendible;
                }
                else if (_Drow["cideprocesod"].ToString() == "5")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoDescuentoFinanciero;
                }
                if (_Dbl_MontoGrid > 0 && _Drow["cideprocesod"].ToString() != "2")
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                }
            }
        }
        public void _Mtd_Proceso_P_CXP_CIARELAC(DataGridView _Pr_Dg_Grid, string _Pr_Str_Factura, string _Pr_Str_Proveedor, string _Pr_Str_cglobal, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, string _Pr_Str_FechaVenc, int _P_Int_SwTipoDoc, double _Pr_Dbl_MontoInvendible, double _Pr_Dbl_MontoDescuentoFinanciero, IEnumerable<_Cls_Impuesto> _Pr_Impuestos)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Datos = "";
            if (_P_Int_SwTipoDoc == 1)
            { _Str_Datos = " S/F # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            else if (_P_Int_SwTipoDoc == 2)
            { _Str_Datos = " S/NDP # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            else
            { _Str_Datos = " S/NCP # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc; }
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                _Str_CountCont = "";
                _Str_CountContName = "";
                _Dbl_MontoGrid = 0;
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Str_Sql = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.ctcount AS ctcountc,TCOUNT.cname AS ctcountname FROM TPROVEEDOR INNER JOIN " +
                        "TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany WHERE TCOUNT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cproveedor='" + _Pr_Str_Proveedor + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountCont = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountc"]).Trim();
                            _Str_CountContName = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"]).Trim().ToUpper();
                        }

                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Str_CountCont = "XXXX";
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Str_CountContName = "CUENTA DEUDORA";
                        }
                        else
                        {
                            _Str_CountContName = "CUENTA ACREEDORA";
                        }
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Drow["cideprocesod"].ToString() == "1")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoSimp;
                }
                else if (_Drow["cideprocesod"].ToString() == "2")
                {
                    _Pr_Impuestos.Where(x => x.Impuesto > 0).ToList().ForEach(x =>
                    {
                        _Pr_Dg_Grid.Rows.Add();
                        _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                        _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + " " + x.Alicuota + "%" + _Str_Datos;
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = x.Impuesto.ToString("#,##0.00");
                            _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        }
                        else
                        {
                            _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                            _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = x.Impuesto.ToString("#,##0.00");
                        }
                    });
                }
                else if (_Drow["cideprocesod"].ToString() == "3")
                {
                    _Dbl_MontoGrid = (_Pr_Dbl_MontoSimp + _Pr_Dbl_MontoImp) - _Pr_Dbl_MontoInvendible - _Pr_Dbl_MontoDescuentoFinanciero;
                }
                else if (_Drow["cideprocesod"].ToString() == "4")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoInvendible;
                }
                else if (_Drow["cideprocesod"].ToString() == "5")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoDescuentoFinanciero;
                }
                if (_Dbl_MontoGrid > 0 && _Drow["cideprocesod"].ToString() != "2")
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[0, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    _Pr_Dg_Grid[2, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                }
            }
        }
        public void _Mtd_Proceso_CTAXPAGAR(DataGridView _Pr_Dg_Grid, string _Pr_Str_Factura, string _Pr_Str_Proveedor, string _Pr_Str_cglobal, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal, double _Pr_Dbl_PorcRetiene, string _Pr_Str_FechaVenc)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0, _Dbl_Total = _Pr_Dbl_MontoTotal;
            double _Dbl_Retiene = _Pr_Dbl_PorcRetiene * _Pr_Dbl_MontoImp;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Datos = " S/F # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc;
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Str_Sql = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.ctcount AS ctcountc,TCOUNT.cname AS ctcountname FROM TPROVEEDOR INNER JOIN " +
                        "TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany WHERE TCOUNT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cproveedor='" + _Pr_Str_Proveedor + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountCont = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountc"]).Trim();
                            _Str_CountContName = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"]).Trim().ToUpper();
                        }
                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Str_CountCont = "XXXX";
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Str_CountContName = "CUENTA DEUDORA";
                        }
                        else
                        {
                            _Str_CountContName = "CUENTA ACREEDORA";
                        }
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Drow["cideprocesod"].ToString() == "1")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoSimp;
                }
                else if (_Drow["cideprocesod"].ToString() == "2")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoImp;
                }
                else if (_Drow["cideprocesod"].ToString() == "3")
                {
                    //_Dbl_Total = _Dbl_Total - _Dbl_Retiene;
                    _Dbl_MontoGrid = _Dbl_Total;
                }

                if (_Dbl_MontoGrid > 0)
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[1, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    }
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[5, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[5, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                    if (_Drow["cideprocesod"].ToString() == "2")
                    {
                        _Pr_Dg_Grid[6, _Pr_Dg_Grid.RowCount - 1].Value = "1";//PARA SABER QUE ES COLUMNA FIJA QUE NO SE MODIFICA
                    }
                }
            }
        }
        public void _Mtd_Proceso_P_CXP_ACC(DataGridView _Pr_Dg_Grid, string _Pr_Str_Factura, string _Pr_Str_Proveedor, string _Pr_Str_cglobal, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal, double _Pr_Dbl_PorcRetiene, string _Pr_Str_FechaVenc)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0, _Dbl_Total = _Pr_Dbl_MontoTotal;
            double _Dbl_Retiene = _Pr_Dbl_PorcRetiene * _Pr_Dbl_MontoImp;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Datos = " S/F # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc;
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Str_Sql = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.ctcount AS ctcountc,TCOUNT.cname AS ctcountname FROM TPROVEEDOR INNER JOIN " +
                        "TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany WHERE TCOUNT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cproveedor='" + _Pr_Str_Proveedor + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountCont = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountc"]).Trim();
                            _Str_CountContName = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"]).Trim().ToUpper();
                        }

                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Str_CountCont = "XXXX";
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Str_CountContName = "CUENTA DEUDORA";
                        }
                        else
                        {
                            _Str_CountContName = "CUENTA ACREEDORA";
                        }
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Drow["cideprocesod"].ToString() == "1")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoSimp;
                }
                else if (_Drow["cideprocesod"].ToString() == "2")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoImp;
                }
                else if (_Drow["cideprocesod"].ToString() == "3")
                {
                    //_Dbl_Total = _Dbl_Total - _Dbl_Retiene;
                    _Dbl_MontoGrid = _Dbl_Total;
                }

                if (_Dbl_MontoGrid > 0)
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[1, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    }
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[5, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[5, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                    if (_Drow["cideprocesod"].ToString() == "2")
                    {
                        _Pr_Dg_Grid[6, _Pr_Dg_Grid.RowCount - 1].Value = "1";//PARA SABER QUE ES COLUMNA FIJA QUE NO SE MODIFICA
                    }
                }
            }
        }
        public void _Mtd_Proceso_P_CXP_CIARELAC(DataGridView _Pr_Dg_Grid, string _Pr_Str_Factura, string _Pr_Str_Proveedor, string _Pr_Str_cglobal, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal, double _Pr_Dbl_PorcRetiene, string _Pr_Str_FechaVenc)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            string _Str_Sql = "";
            string _Str_ProveedorName = "";
            double _Dbl_MontoGrid = 0, _Dbl_Total = _Pr_Dbl_MontoTotal;
            double _Dbl_Retiene = _Pr_Dbl_PorcRetiene * _Pr_Dbl_MontoImp;
            _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Pr_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProveedorName = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Datos = " S/F # " + _Pr_Str_Factura + " " + _Str_ProveedorName + ". VEC: " + _Pr_Str_FechaVenc;
            _Str_Sql = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='" + _G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds_Main = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_Main.Tables[0].Rows)
            {
                if (_Drow["ccount"].ToString() == _G_Str_CuentaContProv)
                {
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Str_Sql = "SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.ctcount AS ctcountc,TCOUNT.cname AS ctcountname FROM TPROVEEDOR INNER JOIN " +
                        "TCOUNT ON TPROVEEDOR.ctcount = TCOUNT.ccount AND TPROVEEDOR.ccompany = TCOUNT.ccompany WHERE TCOUNT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cproveedor='" + _Pr_Str_Proveedor + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountCont = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountc"]).Trim();
                            _Str_CountContName = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"]).Trim().ToUpper();
                        }

                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Str_CountCont = "XXXX";
                        if (_Drow["cnaturaleza"].ToString() == "D")
                        {
                            _Str_CountContName = "CUENTA DEUDORA";
                        }
                        else
                        {
                            _Str_CountContName = "CUENTA ACREEDORA";
                        }
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                if (_Drow["cideprocesod"].ToString() == "1")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoSimp;
                }
                else if (_Drow["cideprocesod"].ToString() == "2")
                {
                    _Dbl_MontoGrid = _Pr_Dbl_MontoImp;
                }
                else if (_Drow["cideprocesod"].ToString() == "3")
                {
                    //_Dbl_Total = _Dbl_Total - _Dbl_Retiene;
                    _Dbl_MontoGrid = _Dbl_Total;
                }

                if (_Dbl_MontoGrid > 0)
                {
                    _Pr_Dg_Grid.Rows.Add();
                    _Pr_Dg_Grid[1, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
                    if (_Pr_Str_cglobal == "0")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    }
                    else if (_Pr_Str_cglobal == "2")
                    {
                        _Pr_Dg_Grid[3, _Pr_Dg_Grid.RowCount - 1].Value = _Str_CountContName + _Str_Datos;
                    }
                    if (_Drow["cnaturaleza"].ToString() == "D")
                    {
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                        _Pr_Dg_Grid[5, _Pr_Dg_Grid.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Pr_Dg_Grid[4, _Pr_Dg_Grid.RowCount - 1].Value = "";
                        _Pr_Dg_Grid[5, _Pr_Dg_Grid.RowCount - 1].Value = _Dbl_MontoGrid.ToString("#,##0.00");
                    }
                    if (_Drow["cideprocesod"].ToString() == "2")
                    {
                        _Pr_Dg_Grid[6, _Pr_Dg_Grid.RowCount - 1].Value = "1";//PARA SABER QUE ES COLUMNA FIJA QUE NO SE MODIFICA
                    }
                }
            }
        }
        public string _Mtd_Proceso_P_CXC_NCDPP(string _Pr_Str_NCmin, string _Pr_Str_NCmax, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal)
        {
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;

            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_NCDPP");
            _Str_cconceptocomp = this._Field_ConceptoComprobante;
            _Str_ctypcompro = this._Field_TipoComprobante;

            DataSet _Ds;
            _Str_cyearacco = _Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = _Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());

            _Str_FechaEmi = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
            _Str_cdescripS = " NC EMIT " + _Str_FechaEmi + " DESDE " + _Pr_Str_NCmin + " HASTA " + _Pr_Str_NCmax;
            //GUARDO LA CABECERA
            _Str_cidcomprob = _Mtd_Consecutivo_TCOMPROBANC();
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal) + "',0,'" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_NCDPP' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoImp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoTotal;
                }

                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS;
                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                }
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return _Str_cidcomprob;
        }
        public string _Mtd_Proceso_P_CxC_EGRCHQT(string _Pr_Str_BancoId, string _Pr_Str_BankCuenta, string _Pr_Str_RelCobroId, string _Pr_Str_NumCheque, double _Pr_Dbl_Monto, string _Pr_Str_FechaEmision, string _Pr_Str_NumDep)
        {
            string _Str_Sql = "";
            double _Dbl_Monto = 0;
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_BancoCtaName = "";
            string _Str_CountBancoCta = "";
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cnumdocu = "";
            string _Str_cdescrip = "";
            string _Str_TpoDocDeposito = "";
            string _Str_NumDeposito = "";
            string _Str_Caja = "";
            string _Str_Fecha = "";
            string _Str_BancoName = "";
            int _Int_corder = 0;

            //Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(this._G_Str_IdProcesoCont);
            _Str_cconceptocomp = this._Field_ConceptoComprobante;
            _Str_ctypcompro = this._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT ctipdocumentdep,ctipdoccheq FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocDeposito = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
            }

            _Str_Sql = "SELECT cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_BankCuenta + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_BancoCtaName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
            }
            _Str_Sql = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_BancoName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
            }

            _Str_Sql = "SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_BankCuenta + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CountBancoCta = Convert.ToString(_Ds.Tables[0].Rows[0]["ccount"]).Trim();
            }
            _Str_Sql = "SELECT ccaja FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Pr_Str_RelCobroId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Caja = Convert.ToString(_Ds.Tables[0].Rows[0]["ccaja"]).Trim();
            }
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_Monto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_Monto) + "',0,'" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'1')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + this._G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' or ccompany is null) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {//GUARDO LA CUENTA DEL BANCO (DEBE)
                    _Str_ccount = _Str_CountBancoCta;
                    _Str_ctdocument = _Str_TpoDocDeposito;
                    _Str_cnumdocu = _Pr_Str_NumDep;
                    _Str_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                    _Str_cdescrip = _Str_BancoName + " CTA. " + _Pr_Str_BankCuenta + " DEPOSITO " + _Pr_Str_NumDep + " SEGUN CAJA " + _Str_Caja;
                    _Dbl_Monto = _Pr_Dbl_Monto;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {//(HABER)
                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                    _Str_cnumdocu = _Pr_Str_NumCheque;
                    _Str_Fecha = _Pr_Str_FechaEmision;
                    _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". EGRESO SEGUN CAJA " + _Str_Caja;
                    _Dbl_Monto = _Pr_Dbl_Monto;
                }

                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                }
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return _Str_cidcomprob;
        }

        /// <summary>
        /// Verifica si el egreso existe.
        /// </summary>
        /// <param name="_P_Str_IDEgreCheq">Id del egreso</param>
        /// <param name="_P_Str_NumCheq">Número del cheque</param>
        /// <param name="_P_Str_NumDepo">Número del deposito</param>
        /// <param name="_P_Str_Cliente">Id del cliente</param>
        private bool _Mtd_ExisteEgreso(string _P_Str_IDEgreCheq,string _P_Str_NumCheq,string _P_Str_NumDepo,string _P_Str_Cliente)
        {
            string _Str_Cadena = "SELECT cidegrecheqtran FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _P_Str_IDEgreCheq + "' AND cnumcheque='" + _P_Str_NumCheq + "' AND cnumdepo='" + _P_Str_NumDepo + "' AND ccliente='" + _P_Str_Cliente + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena);
        }

        public string _Mtd_Proceso_P_CxC_EGRCHQT(string[] _P_Str_IDEgreCheq, string[] _P_Str_NumCheq, string[] _P_Str_NumDepo, string[] _P_Str_Cliente)
        {
            //-----------------------------------------
            string _Str_Caja = "";
            string _Str_Sql = "SELECT ccaja FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrada='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Caja = _Ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                _Str_Sql = "SELECT ISNULL(MAX(CONVERT(NUMERIC,cidcaja)),0)+1 FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Str_Caja = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_Sql = "INSERT INTO TCAJACXC (cgroupcomp,ccompany,cidcaja,ccaja,cfecha,csaldoanterior,ccheqdev_saldoant,ccheqtrans_saldoant) " +
                "SELECT TOP 1 cgroupcomp,ccompany,'" + _Str_Caja + "','" + _Str_Caja + "',GETDATE(),csaldoactual,ccheqdev_saldoact,ccheqtrans_saldoact FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CONVERT(NUMERIC,cidcaja) DESC";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            //-----------------------------------------
            double _Dbl_Monto = 0;
            double _Dbl_MontoTotal_D = 0;
            double _Dbl_MontoTotal_H = 0;
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cnumdocu = "";
            string _Str_cdescrip = "";
            string _Str_TpoDocDeposito = "";
            string _Str_Fecha = "";
            string _Str_BancoName = "";
            string _Str_Cadena = "";
            DataSet _Ds_Temp;
            DataSet _Ds_Temp_2;
            int _Int_corder = 0;
            string _Str_TipoCheq = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdoccheq");
            string _Str_TipoDepo = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocumentdep");
            string _Str_Cliente = "";
            //Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(this._G_Str_IdProcesoCont);
            _Str_cconceptocomp = this._Field_ConceptoComprobante;
            _Str_ctypcompro = this._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT ctipdocumentdep,ctipdoccheq FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocDeposito = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
            }
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0',0,'" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + this._G_Str_IdProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' or ccompany is null) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    for (int _Int_Index = 0; _Int_Index <= _P_Str_IDEgreCheq.Length - 1; _Int_Index++)
                    {
                        _Str_Cadena = "SELECT cbancodepo,cnumcuentadepo,cidrelacobro,cnumcheque,cmontocheq,cfechaemision,cnumdepo,ccliente FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _P_Str_IDEgreCheq[_Int_Index] + "' AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND cnumdepo='" + _P_Str_NumDepo[_Int_Index] + "' AND ccliente='" + _P_Str_Cliente[_Int_Index] + "'";
                        _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                        {
                            _Str_Cadena = "SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancodepo"].ToString().Trim() + "' AND cnumcuenta='" + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + "'";
                            _Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            {
                                _Str_ccount = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["ccount"]).Trim();
                            }
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                            //_Str_ctdocument = _Str_TpoDocDeposito;
                            _Str_ctdocument = _Str_TipoDepo;
                            _Str_cnumdocu = _Ds_Temp.Tables[0].Rows[0]["cnumdepo"].ToString().Trim();
                            _Str_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                            _Str_Cadena = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancodepo"].ToString().Trim() + "'";
                            _Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            {
                                _Str_BancoName = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["cname"]).Trim();
                            }
                            //_Str_Cadena = "SELECT ccaja FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Ds_Temp.Tables[0].Rows[0]["cidrelacobro"].ToString().Trim() + "'";
                            //_Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            //if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            //{
                            //    _Str_Caja = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["ccaja"]).Trim();
                            //}
                            //_Str_cdescrip = _Str_BancoName + " CTA. " + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + " DEPOSITO " + _Ds_Temp.Tables[0].Rows[0]["cnumdepo"].ToString().Trim() + " SEGUN CAJA " + _Str_Caja;
                            _Str_cdescrip = "DEPOSITO " + _Ds_Temp.Tables[0].Rows[0]["cnumdepo"].ToString().Trim() + " SEGUN CAJA " + _Str_Caja;
                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString().Trim());
                        }
                        else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                        {
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                            _Str_ccount = Convert.ToString(_Drow["ccount"]);
                            //_Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                            _Str_ctdocument = _Str_TipoCheq;
                            _Str_cnumdocu = _Ds_Temp.Tables[0].Rows[0]["cnumcheque"].ToString().Trim();
                            _Str_Fecha = _Ds_Temp.Tables[0].Rows[0]["cfechaemision"].ToString().Trim();
                            //_Str_Cadena = "SELECT ccaja FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Ds_Temp.Tables[0].Rows[0]["cidrelacobro"].ToString().Trim() + "'";
                            //_Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            //if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            //{
                            //    _Str_Caja = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["ccaja"]).Trim();
                            //}
                            _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". EGRESO CHEQ # " + _Str_cnumdocu + " SEGUN CAJA " + _Str_Caja;
                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString().Trim());
                        }
                        _Int_corder++;
                        if (_Mtd_ExisteEgreso(_P_Str_IDEgreCheq[_Int_Index], _P_Str_NumCheq[_Int_Index], _P_Str_NumDepo[_Int_Index], _P_Str_Cliente[_Int_Index]))
                        {
                            _Dbl_MontoTotal_D += _Dbl_Monto;
                            //--------------
                            if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                            {
                                _Str_Sql = "Select cidcomprob from TCOMPROBAND where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "' and ccount='" + _Str_ccount + "' and ctdocument='" + _Str_ctdocument + "' and cnumdocu='" + _Str_cnumdocu + "'";
                                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                                {
                                    _Int_corder--;
                                    _Str_Sql = "UPDATE TCOMPROBAND SET ctotdebe=ctotdebe+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "  where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "' and ccount='" + _Str_ccount + "' and ctdocument='" + _Str_ctdocument + "' and cnumdocu='" + _Str_cnumdocu + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    _Str_Sql = "UPDATE TCOMPROBANDD SET cdebe=cdebe+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "  where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "' and ccount='" + _Str_ccount + "' and ctdocument='" + _Str_ctdocument + "' and cnumdocu='" + _Str_cnumdocu + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                else
                                {
                                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheq, _Str_cnumdocu, _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)), _Cls_VariosMetodos._Mtd_FechaVencCheqDev(_Str_Cliente, _Str_cnumdocu), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)), _Str_cmontacco, _Str_cyearacco, "D");
                                }
                            }
                            else
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheq, _Str_cnumdocu, _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)), _Cls_VariosMetodos._Mtd_FechaVencCheqDev(_Str_Cliente, _Str_cnumdocu), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)), _Str_cmontacco, _Str_cyearacco, "D");
                            }
                            //--------------
                            _Str_Cadena = "UPDATE TEGRECHEQTRAN SET cidcomprob='" + _Str_cidcomprob + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _P_Str_IDEgreCheq[_Int_Index] + "' AND cnumdepo='" + _P_Str_NumDepo[_Int_Index] + "' AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND ccliente='" + _P_Str_Cliente[_Int_Index] + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    for (int _Int_Index = 0; _Int_Index <= _P_Str_IDEgreCheq.Length - 1; _Int_Index++)
                    {
                        _Str_Cadena = "SELECT cbancodepo,cnumcuentadepo,cidrelacobro,cnumcheque,cmontocheq,cfechaemision,cnumdepo,ccliente FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _P_Str_IDEgreCheq[_Int_Index] + "' AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND cnumdepo='" + _P_Str_NumDepo[_Int_Index] + "' AND ccliente='" + _P_Str_Cliente[_Int_Index] + "'";
                        _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                        {
                            _Str_Cadena = "SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancodepo"].ToString().Trim() + "' AND cnumcuenta='" + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + "'";
                            _Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            {
                                _Str_ccount = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["ccount"]).Trim();
                            }
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                            //_Str_ctdocument = _Str_TpoDocDeposito;
                            _Str_ctdocument = _Str_TipoDepo;
                            _Str_cnumdocu = _Ds_Temp.Tables[0].Rows[0]["cnumdepo"].ToString().Trim();
                            _Str_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                            _Str_Cadena = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancodepo"].ToString().Trim() + "'";
                            _Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            {
                                _Str_BancoName = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["cname"]).Trim();
                            }
                            //_Str_Cadena = "SELECT ccaja FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Ds_Temp.Tables[0].Rows[0]["cidrelacobro"].ToString().Trim() + "'";
                            //_Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            //if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            //{
                            //    _Str_Caja = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["ccaja"]).Trim();
                            //}
                            //_Str_cdescrip = _Str_BancoName + " CTA. " + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + " DEPOSITO " + _Ds_Temp.Tables[0].Rows[0]["cnumdepo"].ToString().Trim() + " SEGUN CAJA " + _Str_Caja;
                            _Str_cdescrip = "DEPOSITO " + _Ds_Temp.Tables[0].Rows[0]["cnumdepo"].ToString().Trim() + " SEGUN CAJA " + _Str_Caja;
                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString().Trim());
                        }
                        else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                        {
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                            _Str_ccount = Convert.ToString(_Drow["ccount"]);
                            //_Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                            _Str_ctdocument = _Str_TipoCheq;
                            _Str_cnumdocu = _Ds_Temp.Tables[0].Rows[0]["cnumcheque"].ToString().Trim();
                            _Str_Fecha = _Ds_Temp.Tables[0].Rows[0]["cfechaemision"].ToString().Trim();
                            //_Str_Cadena = "SELECT ccaja FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Ds_Temp.Tables[0].Rows[0]["cidrelacobro"].ToString().Trim() + "'";
                            //_Ds_Temp_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            //if (_Ds_Temp_2.Tables[0].Rows.Count > 0)
                            //{
                            //    _Str_Caja = Convert.ToString(_Ds_Temp_2.Tables[0].Rows[0]["ccaja"]).Trim();
                            //}
                            _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". EGRESO CHEQ # " + _Str_cnumdocu + " SEGUN CAJA " + _Str_Caja;
                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString().Trim());
                        }
                        _Int_corder++;
                        if (_Mtd_ExisteEgreso(_P_Str_IDEgreCheq[_Int_Index], _P_Str_NumCheq[_Int_Index], _P_Str_NumDepo[_Int_Index], _P_Str_Cliente[_Int_Index]))
                        {
                            _Dbl_MontoTotal_H += _Dbl_Monto;
                            //--------------
                            if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                            {
                                _Str_Sql = "Select cidcomprob from TCOMPROBAND where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "' and ccount='" + _Str_ccount + "' and ctdocument='" + _Str_ctdocument + "' and cnumdocu='" + _Str_cnumdocu + "'";
                                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                                {
                                    _Int_corder--;
                                    _Str_Sql = "UPDATE TCOMPROBAND SET ctothaber=ctothaber+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "  where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "' and ccount='" + _Str_ccount + "' and ctdocument='" + _Str_ctdocument + "' and cnumdocu='" + _Str_cnumdocu + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    _Str_Sql = "UPDATE TCOMPROBANDD SET chaber=chaber+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "  where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "' and ccount='" + _Str_ccount + "' and ctdocument='" + _Str_ctdocument + "' and cnumdocu='" + _Str_cnumdocu + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                else
                                {
                                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheq, _Str_cnumdocu, _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)), _Cls_VariosMetodos._Mtd_FechaVencCheqDev(_Str_Cliente, _Str_cnumdocu), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)), _Str_cmontacco, _Str_cyearacco, "H");
                                }
                            }
                            else
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "','" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheq, _Str_cnumdocu, _G_Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)), _Cls_VariosMetodos._Mtd_FechaVencCheqDev(_Str_Cliente, _Str_cnumdocu), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)), _Str_cmontacco, _Str_cyearacco, "H");
                            }
                            //--------------
                            _Str_Cadena = "UPDATE TEGRECHEQTRAN SET cidcomprob='" + _Str_cidcomprob + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _P_Str_IDEgreCheq[_Int_Index] + "' AND cnumdepo='" + _P_Str_NumDepo[_Int_Index] + "' AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND ccliente='" + _P_Str_Cliente[_Int_Index] + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
            }
            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_D) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_H) + "',cdateupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _Str_cidcomprob;
        }

        public string _Field_ConceptoComprobante
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "Select cconceptocomp from TPROCESOSCONT where cidproceso='" + _G_Str_IdProcesoCont + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().ToUpper();
                }
                return _Str_R;
            }
        }
        public string _Field_TipoComprobante
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "Select ctypcompro from TPROCESOSCONT where cidproceso='" + _G_Str_IdProcesoCont + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().ToUpper();
                }
                return _Str_R;
            }
        }
        public static string _Mtd_Consecutivo_TCOMPROBANC()
        {
            try
            {
                string _Str_R = "";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT MAX(cidcomprob) FROM TCOMPROBANC where ccompany='" + Frm_Padre._Str_Comp + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                    {
                        _Str_R = Convert.ToString(Convert.ToInt32(_Ds.Tables[0].Rows[0][0]) + 1);
                    }
                    else
                    { _Str_R = "1"; }
                }
                return _Str_R;
            }
            catch
            {
                return "0";
            }
        }
    }
}
