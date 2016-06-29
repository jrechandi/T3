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
    public partial class Frm_Vista_Ascii : Form
    {
        public Frm_Vista_Ascii()
        {
            InitializeComponent();
        }
        string _Str_Recepcion = "";
        string _Str_Factura = "";
        string _Str_Proveedor = "";
        DataSet _Ds_Tabla = new DataSet();
        public Frm_Vista_Ascii(string _P_Str_Recepcion,string _P_Str_Factura,string _P_Str_Proveedor,DataSet _P_Ds)
        {
            InitializeComponent();
            _Ds_Tabla = _P_Ds;
            _Str_Recepcion = _P_Str_Recepcion;
            _Str_Factura = _P_Str_Factura;
            _Str_Proveedor = _P_Str_Proveedor;
            string _Str_Cadena = "";
            DataSet _Ds2 = new DataSet();
            string _Str_Producto = "";
            string _Str_DescProducto = "";
            string _Str_CajasPed = "0";
            string _Str_UnidadesPed = "0";
            string _Str_CajasDesc = "0";
            string _Str_UnidadesDesc = "0";
            string _Str_DiferenciaCaj = "0";
            double _Dbl_UniMinDesc = 0;
            double _Dbl_UniMinPed = 0;
            string _Str_DiferenciaUnd = "0";
            foreach (DataRow _Row in _P_Ds.Tables[0].Rows)
            {
                _Str_Producto = "";
                _Str_CajasPed = "0";
                _Str_UnidadesPed = "0";
                _Str_CajasDesc = "0";
                _Str_UnidadesDesc = "0";
                _Str_DiferenciaCaj = "0";
                _Str_DiferenciaUnd = "0";
                _Dbl_UniMinDesc = 0;
                _Dbl_UniMinPed = 0;
                _Str_Cadena = "Select csolocant,csolocantuni from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Recepcion + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='" + _Row["cproducto"].ToString() + "' and crechazarcaj<>'0'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    int _Int_CajasPed = 0;
                    int _Int_UnidadesPed = 0;
                    int _Int_CajasDes = 0;
                    int _Int_UnidadesDes = 0;
                    if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Int_CajasPed = Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString().TrimEnd());
                    }
                    if (_Ds2.Tables[0].Rows[0][1] != System.DBNull.Value)
                    {
                        _Int_UnidadesPed = Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString().TrimEnd());
                    }
                    if (_Row["cempaques"].ToString().Trim() != "")
                    {
                        _Int_CajasDes = Convert.ToInt32(_Row["cempaques"].ToString().Trim());
                    }
                    if (_Row["cunidades"].ToString() != "")
                    {
                        _Int_UnidadesDes = Convert.ToInt32(_Row["cunidades"].ToString().TrimEnd());
                    }
                    _Dbl_UniMinPed = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString(), _Int_CajasPed, _Int_UnidadesPed));
                    _Dbl_UniMinDesc = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString(), _Int_CajasDes, _Int_UnidadesDes));
                    if (_Dbl_UniMinDesc > _Dbl_UniMinPed)
                    {
                        int _Int_Diferencia = Convert.ToInt32(_Dbl_UniMinDesc - _Dbl_UniMinPed);
                        _Str_DiferenciaCaj = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), _Int_Diferencia, 0);
                        _Str_DiferenciaUnd = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), _Int_Diferencia);
                        _Str_Cadena = "Select CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where cproducto='" + _Row["cproducto"].ToString() + "'";
                        DataSet _Ds3 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds3.Tables[0].Rows.Count > 0)
                        {
                            _Str_Producto = _Row["cproducto"].ToString();
                            _Str_DescProducto = _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            _Str_CajasPed = _Ds2.Tables[0].Rows[0][0].ToString().Trim();
                            _Str_CajasDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc), 0);
                            _Str_UnidadesDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc));
                            //_Str_CajasDesc = _Row["cempaques"].ToString().Trim();
                            _Str_UnidadesPed = _Ds2.Tables[0].Rows[0][1].ToString().Trim();
                            //_Str_UnidadesDesc = "0";
                            //_Dg_Grid2.Rows.Add(new object[] { _Row["cproducto"].ToString(), _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _Ds2.Tables[0].Rows[0][0].ToString().Trim(), _Row["cempaques"].ToString().Trim(), _Int_Diferencia.ToString() });
                        }
                    }
                    else if (_Dbl_UniMinPed > _Dbl_UniMinDesc)
                    {
                        int _Int_Diferencia = Convert.ToInt32(_Dbl_UniMinPed - _Dbl_UniMinDesc);
                        _Str_DiferenciaCaj = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), _Int_Diferencia, 0);
                        _Str_DiferenciaUnd = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), _Int_Diferencia);
                        _Str_Cadena = "Select CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where cproducto='" + _Row["cproducto"].ToString() + "'";
                        DataSet _Ds3 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds3.Tables[0].Rows.Count > 0)
                        {
                            _Str_Producto = _Row["cproducto"].ToString();
                            _Str_DescProducto = _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            _Str_CajasPed = _Ds2.Tables[0].Rows[0][0].ToString().Trim();
                            _Str_CajasDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc), 0);
                            _Str_UnidadesDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc));
                            //_Str_CajasDesc = _Row["cempaques"].ToString().Trim();
                            _Str_UnidadesPed = _Ds2.Tables[0].Rows[0][1].ToString().Trim();
                            //_Str_UnidadesDesc = "0";
                            //_Dg_Grid2.Rows.Add(new object[] { _Row["cproducto"].ToString(), _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _Ds2.Tables[0].Rows[0][0].ToString().Trim(), _Row["cempaques"].ToString().Trim(), _Int_Diferencia.ToString() });
                        }
                    }

                    if (_Str_Producto.TrimEnd().Length > 0)
                    {
                        _Dg_Grid2.Rows.Add(new object[] { _Str_Producto, _Str_DescProducto, _Str_CajasPed, _Str_UnidadesPed, _Str_CajasDesc, _Str_UnidadesDesc, _Str_DiferenciaCaj, _Str_DiferenciaUnd });
                    }
                }
                else
                {
                    _Str_Producto = "";
                    _Str_Cadena = "Select cempaques,cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Recepcion + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='" + _Row["cproducto"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        int _Int_CajasPed = 0;
                        int _Int_UnidadesPed = 0;
                        int _Int_CajasDes = 0;
                        int _Int_UnidadesDes = 0;
                        if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Int_CajasPed = Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString().TrimEnd());
                        }
                        if (_Ds2.Tables[0].Rows[0][1] != System.DBNull.Value)
                        {
                            _Int_UnidadesPed = Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString().TrimEnd());
                        }
                        if (_Row["cempaques"].ToString().Trim() != "")
                        {
                            _Int_CajasDes = Convert.ToInt32(_Row["cempaques"].ToString().Trim());
                        }
                        if (_Row["cunidades"].ToString() != "")
                        {
                            _Int_UnidadesDes = Convert.ToInt32(_Row["cunidades"].ToString().TrimEnd());
                        }
                        _Dbl_UniMinPed = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString(), _Int_CajasPed, _Int_UnidadesPed));
                        _Dbl_UniMinDesc = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString(), _Int_CajasDes, _Int_UnidadesDes));
                        if (_Dbl_UniMinDesc > _Dbl_UniMinPed)
                        {
                            int _Int_Diferencia = Convert.ToInt32(_Dbl_UniMinDesc - _Dbl_UniMinPed);
                            _Str_DiferenciaCaj = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), _Int_Diferencia, 0);
                            _Str_DiferenciaUnd = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), _Int_Diferencia);
                            _Str_Cadena = "Select CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where cproducto='" + _Row["cproducto"].ToString() + "'";
                            DataSet _Ds3 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds3.Tables[0].Rows.Count > 0)
                            {
                                _Str_Producto = _Row["cproducto"].ToString();
                                _Str_DescProducto = _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                                _Str_CajasPed = _Ds2.Tables[0].Rows[0][0].ToString().Trim();
                                _Str_CajasDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc), 0);
                                _Str_UnidadesDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc));
                                //_Str_CajasDesc = _Row["cempaques"].ToString().Trim();
                                _Str_UnidadesPed = _Ds2.Tables[0].Rows[0][1].ToString().Trim();
                                //_Str_UnidadesDesc = "0";
                                //_Dg_Grid2.Rows.Add(new object[] { _Row["cproducto"].ToString(), _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _Ds2.Tables[0].Rows[0][0].ToString().Trim(), _Row["cempaques"].ToString().Trim(), _Int_Diferencia.ToString() });
                            }
                        }
                        else if (_Dbl_UniMinPed > _Dbl_UniMinDesc)
                        {
                            int _Int_Diferencia = Convert.ToInt32(_Dbl_UniMinPed - _Dbl_UniMinDesc);
                            _Str_DiferenciaCaj = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), _Int_Diferencia, 0);
                            _Str_DiferenciaUnd = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), _Int_Diferencia);
                            _Str_Cadena = "Select CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as cnamef from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where cproducto='" + _Row["cproducto"].ToString() + "'";
                            DataSet _Ds3 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds3.Tables[0].Rows.Count > 0)
                            {
                                _Str_Producto = _Row["cproducto"].ToString();
                                _Str_DescProducto = _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                                _Str_CajasPed = _Ds2.Tables[0].Rows[0][0].ToString().Trim();
                                _Str_CajasDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc), 0);
                                _Str_UnidadesDesc = CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString(), Convert.ToInt32(_Dbl_UniMinDesc));
                                //_Str_CajasDesc = _Row["cempaques"].ToString().Trim();
                                _Str_UnidadesPed = _Ds2.Tables[0].Rows[0][1].ToString().Trim();
                                //_Str_UnidadesDesc = "0";
                                //_Dg_Grid2.Rows.Add(new object[] { _Row["cproducto"].ToString(), _Ds3.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _Ds2.Tables[0].Rows[0][0].ToString().Trim(), _Row["cempaques"].ToString().Trim(), _Int_Diferencia.ToString() });
                            }
                        }
                        if (_Str_Producto.TrimEnd().Length > 0)
                        {
                            _Dg_Grid2.Rows.Add(new object[] { _Str_Producto, _Str_DescProducto, _Str_CajasPed, _Str_UnidadesPed, _Str_CajasDesc, _Str_UnidadesDesc, _Str_DiferenciaCaj, _Str_DiferenciaUnd });
                        }
                    }
                }
            }
            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Dg_Grid2.Enabled = false;
                _Bt_Aceptar.Enabled = false;
                _Bt_Cancelar.Enabled = false;
            }
            else
            {
                _Dg_Grid2.Enabled = true;
                _Bt_Aceptar.Enabled = true;
                _Bt_Cancelar.Enabled = true;
            }
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Mtd_Guardar()
        {
            foreach (DataRow _Row in _Ds_Tabla.Tables[0].Rows)
            {
                string _Str_Prod = _Row["cproducto"].ToString();
                string _Str_Fab = _Row["ccodfabrica"].ToString();
                double _Dbl_ccostobrutolote = 0;
                double _Dbl_cprecioventamax = 0;
                double _Dbl_cpreciolista = 0;
                _Mtd_ObtenerCostoBrtuoyPrecioMax(_Str_Recepcion, _Str_Factura, _Row["cproducto"].ToString(), ref _Dbl_ccostobrutolote, ref _Dbl_cprecioventamax, ref _Dbl_cpreciolista);
                string _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cunidades,cproveedor,ccostobrutolote,cprecioventamax,cpreciolista) VALUES(";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Row["cempaques"].ToString().Trim() + ",'" + _Row["cunidades"].ToString().Trim() + "','" + _Str_Proveedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cpreciolista) + "')";
                try
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "cdescargo='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Recepcion + "' and cproveedor='" + _Str_Proveedor + "'");
                }
                catch { }
            }
        }
        private void _Mtd_ObtenerCostoBrtuoyPrecioMax(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Producto, ref double _P_Dbl_ccostobrutolote, ref double _P_Dbl_cprecioventamax, ref double _P_Dbl_cpreciolista)
        {
            string _Str_Cadena = "SELECT ISNULL(ccostobrutolote,0) AS ccostobrutolote,CASE WHEN crechazadoxpmv='1' THEN 0 ELSE ISNULL(cprecioventamax,0) END AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista FROM TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _P_Dbl_ccostobrutolote = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobrutolote"]);
                _P_Dbl_cprecioventamax = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cprecioventamax"]);
                _P_Dbl_cpreciolista = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cpreciolista"]);
            }
        }
        private void _Mtd_Guardar_Ascii()
        {
            DataSet _Ds = new DataSet();
            foreach (DataRow _Row in _Ds_Tabla.Tables[0].Rows)
            {
                string _Str_Prod = _Row["cproducto"].ToString();
                string _Str_Fab = _Row["ccodfabrica"].ToString();
                double _Dbl_ccostobrutolote = 0;
                double _Dbl_cprecioventamax = 0;
                double _Dbl_cpreciolista = 0;
                _Mtd_ObtenerCostoBrtuoyPrecioMax(_Str_Recepcion, _Str_Factura, _Row["cproducto"].ToString(), ref _Dbl_ccostobrutolote, ref _Dbl_cprecioventamax, ref _Dbl_cpreciolista);
                string _Str_Sql = "";
                string _Str_Cadena = "Select csolocant,csolocantuni from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Recepcion + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='" + _Row["cproducto"].ToString() + "' and crechazarcaj<>'0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    string _Str_Empaques = "0";
                    string _Str_Unidades = "0";
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() != "0")
                    {
                        _Str_Empaques = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    if (_Ds.Tables[0].Rows[0][1].ToString().Trim() != "0")
                    {
                        _Str_Unidades = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                    }
                    _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cunidades,cproveedor,ccostobrutolote,cprecioventamax,cpreciolista) VALUES(";
                    _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Str_Empaques + "," + _Str_Unidades + ",'" + _Str_Proveedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cpreciolista) + "')";
                }
                else
                {
                    _Str_Cadena = "Select cempaques,cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Recepcion + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='" + _Row["cproducto"].ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        int _Int_EmpFac = 0;
                        int _Int_EmpAsc = 0;
                        int _Int_UndFac = 0;
                        int _Int_UndAsc = 0;
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Int_EmpFac = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString()); }
                        if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Int_UndFac = Convert.ToInt32(_Ds.Tables[0].Rows[0][1].ToString()); }
                        if (_Row["cempaques"] != System.DBNull.Value)
                        { _Int_EmpAsc = Convert.ToInt32(_Row["cempaques"].ToString()); }
                        if (_Row["cunidades"] != System.DBNull.Value)
                        { _Int_UndAsc = Convert.ToInt32(_Row["cunidades"].ToString()); }
                        string _Str_Empaques = "0";
                        string _Str_Unidades = "0";
                        if (_Int_EmpAsc < _Int_EmpFac)
                        {
                            if (_Row["cempaques"].ToString().Trim() != "0")
                            {
                                _Str_Empaques = _Row["cempaques"].ToString().Trim();
                                //_Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cproveedor) VALUES(";
                                //_Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Row["cempaques"].ToString().Trim() + ",'" + _Str_Proveedor + "')";
                            }
                        }
                        else
                        {
                            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() != "0")
                            {
                                _Str_Empaques = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                               // _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cproveedor) VALUES(";
                                //_Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Ds.Tables[0].Rows[0][0].ToString() + ",'" + _Str_Proveedor + "')";
                            }
                        }
                        if (_Int_UndAsc < _Int_UndFac)
                        {
                            if (_Row["cunidades"].ToString().Trim() != "0")
                            {
                                _Str_Unidades = _Row["cunidades"].ToString().Trim();
                                //_Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cproveedor) VALUES(";
                                //_Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Row["cempaques"].ToString().Trim() + ",'" + _Str_Proveedor + "')";
                            }
                        }
                        else
                        {
                            if (_Ds.Tables[0].Rows[0][1].ToString().Trim() != "0")
                            {
                                _Str_Unidades = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                                // _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cproveedor) VALUES(";
                                //_Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Ds.Tables[0].Rows[0][0].ToString() + ",'" + _Str_Proveedor + "')";
                            }
                        }
                        _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cunidades,cproveedor,ccostobrutolote,cprecioventamax,cpreciolista) VALUES(";
                        _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "," + _Str_Recepcion + "," + _Str_Factura + ",'" + _Str_Prod + "','" + _Str_Fab + "'," + _Str_Empaques + "," + _Str_Unidades + ",'" + _Str_Proveedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cpreciolista) + "')";
                    }
                }
                try
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "cdescargo='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Recepcion + "' and cproveedor='" + _Str_Proveedor + "'");
                }
                catch { }
            }
        }
        private void Frm_Vista_Ascii_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Text = "";
            _Txt_Clave.Focus();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
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
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Guardar_Ascii();
                    Cursor = Cursors.Default;
                    this.Close();
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { MessageBox.Show("Error en la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void _Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_Aceptar2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Guardar();
            Cursor = Cursors.Default;
            this.Close();
        }
    }
}