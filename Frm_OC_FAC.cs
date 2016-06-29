using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_OC_FAC : Form
    {
        public Frm_OC_FAC()
        {
            InitializeComponent();
        }
        bool _Bol_FrmNoDif = false;
        string _Str_Rec = "";
        string _Str_OC = "";
        string _Str_Proveedor="";
        string _Str_Factura = "";
        clslibraryconssa._Cls_Formato _Cls_Formato=new clslibraryconssa._Cls_Formato("es-VE");
        string[] _Str_Facturas;
        bool _Bol_Permiso_Usuario = false;
        //_______________________________________________________________________________________________
        public Frm_OC_FAC(string _P_Str_Rec, string _P_Str_Proveedor, int _P_Int_Tipo, string[] _P_Str_Facturas)
        {
            InitializeComponent();

            _Str_Rec = _P_Str_Rec;
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Facturas = _P_Str_Facturas;
            _Pgb_Progress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            string _Str_Cadena = "Select DISTINCT cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_facturacomparada.cproducto) AS cnamef,ccostobruto_u1,cpreciouni,cpreciodiferenc,ccantunidadma1,ccantunidadma2,cempaques,cunidades,cdiferenciaemp,cdiferenciauni,cnumoc,cnfacturapro,cidrecepcion,cfaltante,cdiferenciaprec,crechazarcaj,crechazarpre,csolocant,cmotrechazo,caprobadifpsdocu,caprobadifpdocu from vst_facturacomparada where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Mtd_Guardar_Cambios_Automaticos();
                _Lbl_Nohay.Text = "No existen diferencias";
                _Lbl_Nohay.Visible = true;
                _Bt_Imprimir.Enabled = false;
                _Bt_Imprimir2.Enabled = false;
                _Bt_Guardar.Enabled = false;
                _Bol_FrmNoDif = true;//gianqui
            }
            int _Int_i = 0;
            object[] _Obj1 = new object[17];
            object[] _Obj2 = new object[15];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                //Empaques
                if (_Row["cfaltante"].ToString() != "0")
                {
                    _Obj1[0] = _Row["cproducto"].ToString();
                    _Obj1[1] = _Row["cnamef"].ToString();
                    if (_Row["ccantunidadma1"] != System.DBNull.Value)
                    { _Obj1[2] = _Row["ccantunidadma1"].ToString(); }
                    else
                    { _Obj1[2] = "0"; }
                    if (_Row["ccantunidadma2"] != System.DBNull.Value)
                    { _Obj1[3] = _Row["ccantunidadma2"].ToString(); }
                    else
                    { _Obj1[3] = "0"; }
                    if (_Row["cempaques"] != System.DBNull.Value)
                    { _Obj1[4] = _Row["cempaques"].ToString(); }
                    else
                    { _Obj1[4] = "0"; }
                    if (_Row["cunidades"] != System.DBNull.Value)
                    { _Obj1[5] = _Row["cunidades"].ToString(); }
                    else
                    { _Obj1[5] = "0"; }
                    _Obj1[6] = _Row["cdiferenciaemp"].ToString();
                    _Obj1[7] = _Row["cdiferenciauni"].ToString();
                    if (_Row["cfaltante"].ToString() == "1")
                    { _Obj1[8] = "Por llegar"; }
                    else
                    { _Obj1[8] = "Sobrante"; }
                    _Obj1[9] = _Row["cnumoc"].ToString();
                    _Obj1[10] = _Row["cnfacturapro"].ToString();
                    _Obj1[11] = _Row["cidrecepcion"].ToString();
                    _Obj1[12] = "0";
                    _Obj1[13] = "0";
                    _Obj1[14] = "0";
                    _Obj1[15] = "";
                    _Obj1[16] = "0";
                    _Dg_Grid4.Rows.Add(_Obj1);
                }
                //Empaques

                //Precio
                if (_Row["cdiferenciaprec"].ToString() != "0")
                {
                    _Bol_Permiso_Usuario = true;
                    _Obj2[0] = _Row["cproducto"].ToString();
                    _Obj2[1] = _Row["cnamef"].ToString();
                    _Obj2[2] = _Row["ccostobruto_u1"].ToString();
                    _Obj2[3] = _Row["cpreciouni"].ToString();
                    _Obj2[4] = _Row["cpreciodiferenc"].ToString();
                    if (_Row["cdiferenciaprec"].ToString() == "1")
                    { _Obj2[5] = "Precio inferior"; }
                    else
                    { _Obj2[5] = "Sobreprecio"; }
                    _Obj2[6] = _Row["cnumoc"].ToString();
                    _Obj2[7] = _Row["cnfacturapro"].ToString();
                    _Obj2[8] = _Row["cidrecepcion"].ToString();
                    _Obj2[9] = _Row["crechazarpre"].ToString();
                    _Obj2[10] = _Row["caprobadifpsdocu"].ToString();
                    _Obj2[11] = _Row["caprobadifpdocu"].ToString();
                    _Obj2[12] = "0";
                    _Dg_Grid3.Rows.Add(_Obj2);
                }
                //Precio
                _Int_i++;

            }
            _Dg_Grid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_P_Int_Tipo == 1)
            {
                _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                DataSet _Ds_Temp = new DataSet();
                double _Dbl_EmpaquesFAC = 0;
                double _Dbl_EmpaquesOC = 0;
                double _Dbl_EmpaquesOCTotal = 0;
                double _Dbl_EmpaquesOCTemp = 0;
                double _Dbl_UnidadesFAC = 0;
                double _Dbl_UnidadeOC = 0;
                double _Dbl_UnidadeOCTotal = 0;
                double _Dbl_UnidadeOCTemp = 0;
                double _Dbl_UniMinOC = 0;
                double _Dbl_UniMinFact = 0;
                double _Dbl_UniMinOCTotal = 0;
                double _Dbl_UniMinOCTemp = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    double _Dbl_Diferencia = 0;
                    double _Dbl_DiferenciaMin = 0;
                    double _Dbl_Diferencia2 = 0;
                    double _Dbl_Value = 0;
                    double _Dbl_Value2 = 0;
                    double _Dbl_ValueUniMin = 0;
                    _Str_Cadena = "Select SUM(ccantunidadma1),SUM(ccantunidadma2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantunidadma2, ccantunidadma1)) as UniMin from TORDENCOMPD where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dbl_EmpaquesOCTemp = _Dbl_EmpaquesOC;
                            _Dbl_EmpaquesOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString());
                        }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        {
                            _Dbl_UnidadeOCTemp = _Dbl_UnidadeOC;
                            _Dbl_UnidadeOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString());
                        }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        {
                            _Dbl_UniMinOCTemp = _Dbl_UniMinOC;
                            _Dbl_UniMinOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString());
                        }
                    }
                    _Str_Cadena = "Select SUM(ccantidad_u1),SUM(ccantidad_u2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantidad_u2, ccantidad_u1)) as UniMin from TTEMPOC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Row[0].ToString() + "' and csuma='0'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_EmpaquesOC = _Dbl_EmpaquesOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString())); }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Dbl_UnidadeOC = _Dbl_UnidadeOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString())); }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        { _Dbl_UniMinOC = _Dbl_UniMinOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString())); }
                    }
                    _Dbl_EmpaquesOCTotal = _Dbl_EmpaquesOCTotal + _Dbl_EmpaquesOC;
                    _Dbl_UnidadeOCTotal = _Dbl_UnidadeOCTotal + _Dbl_UnidadeOC;
                    _Dbl_UniMinOCTotal = _Dbl_UniMinOCTotal + _Dbl_UniMinOC;
                    _Str_Cadena = "SELECT SUM(cempaques) AS Expr1,SUM(cunidades) AS Expr2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, cunidades, cempaques)) as UniMin " +
                         "FROM TRECEPCIONDFD " +
                         "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cidrecepcion = '" + _P_Str_Rec + "') AND (cnfacturapro = '" + _P_Str_Facturas[0].ToString() + "') AND (cproveedor = '" + _P_Str_Proveedor + "') " +
                         "GROUP BY cgroupcomp, cidrecepcion, cnfacturapro, cproveedor";;
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Dbl_UnidadesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        { _Dbl_UniMinFact = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString()); }
                        _Dbl_EmpaquesFAC = _Dbl_EmpaquesFAC - _Dbl_EmpaquesOCTemp;
                        _Dbl_UnidadesFAC = _Dbl_UnidadesFAC - _Dbl_UnidadeOCTemp;
                        _Dbl_UniMinFact = _Dbl_UniMinFact - _Dbl_UniMinOCTemp;
                    }
                    if (_Dbl_EmpaquesFAC >= _Dbl_EmpaquesOC)
                    { _Dbl_EmpaquesFAC = _Dbl_EmpaquesOC; }
                    if (_Dbl_UnidadesFAC >= _Dbl_UnidadeOC)
                    { _Dbl_UnidadesFAC = _Dbl_UnidadeOC; }
                    if (_Dbl_UniMinFact >= _Dbl_UniMinOC)
                    { _Dbl_UniMinFact = _Dbl_UniMinOC; }
                    _Dbl_Diferencia = _Dbl_EmpaquesOC - _Dbl_EmpaquesFAC;
                    _Dbl_Diferencia2 = _Dbl_UnidadeOC - _Dbl_UnidadesFAC;
                    _Dbl_DiferenciaMin = _Dbl_UniMinOC - _Dbl_UniMinFact;
                    
                    if (_Dbl_EmpaquesOC > 0)
                    {
                        _Dbl_Value = 100 - ((_Dbl_Diferencia * 100) / _Dbl_EmpaquesOC);
                    }
                    else
                    {
                        _Dbl_Value = 0;
                    }
                    if (_Dbl_UnidadeOC > 0)
                    {
                        _Dbl_Value2 = 100 - ((_Dbl_Diferencia2 * 100) / _Dbl_UnidadeOC);
                    }
                    else
                    {
                        _Dbl_Value2 = 0;
                    }
                    if (_Dbl_ValueUniMin > 0)
                    {
                        _Dbl_ValueUniMin = 100 - ((_Dbl_DiferenciaMin * 100) / _Dbl_UniMinOC);
                    }
                    else
                    {
                        _Dbl_ValueUniMin = 0;
                    }
                    //string _Str_Valor = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select Cast(cefectividad as integer)+Cast('" + Convert.ToString(Math.Round(_Dbl_Value)) + "' as integer) from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _P_Str_Proveedor + "'").Tables[0].Rows[0][0].ToString();
                    bool _Bol_Cerrar = false;
                    _Str_Cadena = "Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
                    string _Str_Temp = "";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (_Str_Temp != _Row[0].ToString())
                        {

                            double _Dbl_Efect = 0;
                            double _Dbl_Valor = 0;
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            {
                                DataRow _Row_Efec = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                                if (_Row_Efec[0] != System.DBNull.Value)
                                { _Dbl_Efect = Convert.ToDouble(_Row_Efec[0].ToString().Trim()); }
                                //double _Dbl_Promedio = ((_Dbl_Value + _Dbl_Value2) / 2);
                                double _Dbl_Promedio = _Dbl_ValueUniMin;
                                if (_Dbl_Promedio >= _Dbl_Efect)
                                {
                                    _Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio) + "',ccerrada='1',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                                }
                                else
                                {
                                    _Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio) + "',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                                }
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                            //_Str_Temp = _Row[0].ToString();
                        }
                    }
                }
                _Str_Cadena = "SELECT SUM(cempaques) AS Expr1,SUM(cunidades) AS Expr2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, cunidades, cempaques)) as UniMin  " +
                     "FROM TRECEPCIONDFD " +
                     "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cidrecepcion = '" + _P_Str_Rec + "') AND (cnfacturapro = '" + _P_Str_Facturas[0].ToString() + "') AND (cproveedor = '" + _P_Str_Proveedor + "') " +
                     "GROUP BY cgroupcomp, cidrecepcion, cnfacturapro, cproveedor";;
                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
                    if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Dbl_UnidadesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
                    if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                    { _Dbl_UniMinFact = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString()); }
                }
                double _Dbl_Diferencia3 = _Dbl_EmpaquesOCTotal - _Dbl_EmpaquesFAC;
                double _Dbl_Diferencia4 = _Dbl_UnidadeOCTotal - _Dbl_UnidadesFAC;
                double _Dbl_DiferenciaUndMin = _Dbl_UniMinOCTotal - _Dbl_UniMinFact;
                double _Dbl_Value3 =0;
                double _Dbl_Value4 =0;
                double _Dbl_Value5 = 0;
                if (_Dbl_EmpaquesOCTotal > 0)
                {
                    _Dbl_Value3 = 100 - ((_Dbl_Diferencia3 * 100) / _Dbl_EmpaquesOCTotal);
                }
                if (_Dbl_UnidadeOCTotal > 0)
                {
                    _Dbl_Value4 = 100 - ((_Dbl_Diferencia4 * 100) / _Dbl_UnidadeOCTotal);
                }
                if (_Dbl_UniMinOCTotal > 0)
                {
                    _Dbl_Value5 = 100 - ((_Dbl_DiferenciaUndMin * 100) / _Dbl_UniMinOCTotal);
                }
                double _Dbl_Promedio2 = 0;
                //_Dbl_Promedio2 = (_Dbl_Value3 + _Dbl_Value4)/2;
                _Dbl_Promedio2 = _Dbl_Value5;
                if (_Dbl_Promedio2 > 100)
                {
                    _Pgb_Progress.Value = 100;
                }
                else
                {
                    _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Promedio2);
                }
                try
                {
                    _Lbl_Por.Text = Convert.ToInt32(_Dbl_Promedio2).ToString();
                }
                catch { _Lbl_Por.Text = ""; }
            }
            else
            {
                double _Dbl_EmpaquesFAC = 0;
                double _Dbl_EmpaquesOC = 0;
                double _Dbl_UniMinOC = 0;
                double _Dbl_UniMinFAC = 0;
                double _Dbl_UnidadesFAC = 0;
                double _Dbl_UnidadesOC = 0;
                _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_OC = "";
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_OC = _Ds.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "SELECT SUM(ccantunidadma1) AS suma,SUM(ccantunidadma2) AS suma2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantunidadma2, ccantunidadma1)) as UniMin FROM TORDENCOMPD WHERE cnumoc = '" + _Str_OC + "' AND ccompany = '" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_Proveedor + "' GROUP BY cnumoc";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_EmpaquesOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    _Dbl_UnidadesOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    _Dbl_UniMinOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString());
                }
                _Str_Cadena = "Select SUM(ccantidad_u1),SUM(ccantidad_u2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantidad_u2, ccantidad_u1)) as UniMin from TTEMPOC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Str_OC + "' and csuma='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_EmpaquesOC = _Dbl_EmpaquesOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString())); }
                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Dbl_UnidadesOC = _Dbl_UnidadesOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString())); }
                    if (_Ds.Tables[0].Rows[0][2] != System.DBNull.Value)
                    { _Dbl_UniMinOC = _Dbl_UniMinOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString())); }
                }
                _Str_Cadena = "Select suma,suma2,UniMin from vst_totaldeempaquesfactura where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    _Dbl_UnidadesFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    _Dbl_UniMinFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString());
                }
                double _Dbl_Diferencia3 = _Dbl_EmpaquesOC - _Dbl_EmpaquesFAC;
                double _Dbl_Diferencia4 = _Dbl_UnidadesOC - _Dbl_UnidadesFAC;
                double _Dbl_Diferencia5 = _Dbl_UniMinOC - _Dbl_UniMinFAC;
                 double _Dbl_Value3=100;
                 double _Dbl_Value4 = 100;
                 double _Dbl_Value5 = 100;
                 double _Dbl_Promedio3 = 0;
                if (_Dbl_EmpaquesOC > 0)
                {
                    _Dbl_Value3 = 100 - ((_Dbl_Diferencia3 * 100) / _Dbl_EmpaquesOC);
                }
                if (_Dbl_UnidadesOC > 0)
                {
                    _Dbl_Value4 = 100 - ((_Dbl_Diferencia4 * 100) / _Dbl_UnidadesOC);
                }
                if (_Dbl_UniMinOC > 0)
                {
                    _Dbl_Value5 = 100 - ((_Dbl_Diferencia5 * 100) / _Dbl_UniMinOC);
                }
                //string _Str_Valor2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select Cast(cefectividad as integer)+Cast('" + Convert.ToString(Math.Round(_Dbl_Value2)) + "' as integer) from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _P_Str_Proveedor + "'").Tables[0].Rows[0][0].ToString();
                bool _Bol_Cerrar2 = false;
                double _Dbl_Efect2 = 0;
                _Str_Cadena = "Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    DataRow _Row_Efec = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                    if (_Row_Efec[0] != System.DBNull.Value)
                    { _Dbl_Efect2 = Convert.ToDouble(_Row_Efec[0].ToString().Trim()); }                    
                    //_Dbl_Promedio3 = (_Dbl_Value3 + _Dbl_Value4)/2;
                    _Dbl_Promedio3 = _Dbl_Value5;
                    if (_Dbl_Promedio3 >= _Dbl_Efect2)
                    {
                        _Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio3) + "',ccerrada='1',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _Str_Proveedor + "'";
                    }
                    else
                    {
                        _Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio3) + "',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _Str_Proveedor + "'";
                    }
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                if (_Dbl_Promedio3 > 100)
                {
                    _Pgb_Progress.Value = 100;
                }
                else
                {
                    _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Promedio3);
                }
                try
                {
                    _Lbl_Por.Text = Convert.ToInt32(_Dbl_Promedio3).ToString();
                }
                catch { _Lbl_Por.Text = ""; }
            }
            double _Dbl_FaltanesD = 0;
            double _Dbl_EmOC = 0;
            double _Dbl_FaltanesD2 = 0;
            double _Dbl_UnOC = 0;
            _Str_Cadena = "Select ccantempfact,ccantempoc,ccantunifact,ccantunioc from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cproveedor='" + _P_Str_Proveedor + "' and cfaltante='1' and cidrecepcion='" + _P_Str_Rec + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                if (_Row[0] != System.DBNull.Value)
                { _Dbl_FaltanesD = _Dbl_FaltanesD + Convert.ToDouble(_Row[0].ToString().Trim()); }
                if (_Row[2] != System.DBNull.Value)
                { _Dbl_FaltanesD2 = _Dbl_FaltanesD2 + Convert.ToDouble(_Row[2].ToString().Trim()); }
                if (_Row[1] != System.DBNull.Value)
                { _Dbl_EmOC = _Dbl_EmOC + Convert.ToDouble(_Row[1].ToString().Trim()); }
                if (_Row[3] != System.DBNull.Value)
                { _Dbl_UnOC = _Dbl_UnOC + Convert.ToDouble(_Row[3].ToString().Trim()); }
            }
            if (_Dbl_EmOC > _Dbl_FaltanesD)
            { _Txt_Faltantes.Text = Convert.ToString(_Dbl_EmOC - _Dbl_FaltanesD); }
            if (_Dbl_UnOC > _Dbl_FaltanesD2)
            { _Txt_FaltantesUni.Text = Convert.ToString(_Dbl_UnOC - _Dbl_FaltanesD2); }
            if (_Dbl_EmOC < _Dbl_FaltanesD)
            { _Txt_Faltantes.Text = Convert.ToString(_Dbl_FaltanesD - _Dbl_EmOC); }
            if (_Dbl_UnOC < _Dbl_FaltanesD2)
            { _Txt_FaltantesUni.Text = Convert.ToString(_Dbl_FaltanesD2 - _Dbl_UnOC); }
            //_____________________________________
            if (_Bol_Permiso_Usuario)
            {
                _Str_Cadena = "SELECT * " +
"FROM TUSER INNER JOIN " +
"TPROCEFIRMAD ON TUSER.cuser = TPROCEFIRMAD.cuser " +
"WHERE (TUSER.cuser = '" + Frm_Padre._Str_Use + "') AND (TPROCEFIRMAD.cprocesofirma = 'F_DIFERN_OC_FACT') AND TUSER.cfirmante='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dg_Grid3.ContextMenuStrip = contextMenuStrip3;
                }
            }
        }
        //_______________________________________________________________________________________________
        public Frm_OC_FAC(string _P_Str_Rec, string _P_Str_Proveedor, int _P_Int_Tipo, string[] _P_Str_Facturas, bool _P_Bol_Solover)
        {
            InitializeComponent();
            _Str_Rec = _P_Str_Rec;
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Facturas = _P_Str_Facturas;
            _Dg_Grid3.ContextMenuStrip = null;
            _Dg_Grid4.ContextMenuStrip = null;
            _Pgb_Progress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            string _Str_Cadena = "Select DISTINCT cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_facturacomparada.cproducto) AS cnamef,ccostobruto_u1,cpreciouni,cpreciodiferenc,ccantunidadma1,ccantunidadma2,cempaques,cunidades,cdiferenciaemp,cdiferenciauni,cnumoc,cnfacturapro,cidrecepcion,cfaltante,cdiferenciaprec,crechazarcaj,crechazarpre,csolocant,cmotrechazo,caprobadifpsdocu,caprobadifpdocu from vst_facturacomparada where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Mtd_Guardar_Cambios_Automaticos();
                _Lbl_Nohay.Text = "No existen diferencias";
                _Lbl_Nohay.Visible = true;
                _Bt_Imprimir.Enabled = false;
                _Bt_Imprimir2.Enabled = false;
                _Bt_Guardar.Enabled = false;
            }
            DataSet _Ds2 = new DataSet();
            //_Dg_Grid4.DataSource = _Ds.Tables[0];
            int _Int_i = 0;
            object[] _Obj1 = new object[17];
            object[] _Obj2 = new object[15];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                //Empaques
                if (_Row["cfaltante"].ToString() != "0")
                {
                    _Obj1[0] = _Row["cproducto"].ToString();
                    _Obj1[1] = _Row["cnamef"].ToString();
                    if (_Row["ccantunidadma1"] != System.DBNull.Value)
                    { _Obj1[2] = _Row["ccantunidadma1"].ToString(); }
                    else
                    { _Obj1[2] = "0"; }
                    if (_Row["ccantunidadma2"] != System.DBNull.Value)
                    { _Obj1[3] = _Row["ccantunidadma2"].ToString(); }
                    else
                    { _Obj1[3] = "0"; }
                    if (_Row["cempaques"] != System.DBNull.Value)
                    { _Obj1[4] = _Row["cempaques"].ToString(); }
                    else
                    { _Obj1[4] = "0"; }
                    if (_Row["cunidades"] != System.DBNull.Value)
                    { _Obj1[5] = _Row["cunidades"].ToString(); }
                    else
                    { _Obj1[5] = "0"; }
                    _Obj1[6] = _Row["cdiferenciaemp"].ToString();
                    _Obj1[7] = _Row["cdiferenciauni"].ToString();
                    if (_Row["cfaltante"].ToString() == "1")
                    { _Obj1[8] = "Por llegar"; }
                    else
                    { _Obj1[8] = "Sobrante"; }
                    _Obj1[9] = _Row["cnumoc"].ToString();
                    _Obj1[10] = _Row["cnfacturapro"].ToString();
                    _Obj1[11] = _Row["cidrecepcion"].ToString();
                    _Obj1[12] = "0";
                    _Obj1[13] = "0";
                    _Obj1[14] = "0";
                    _Obj1[15] = "";
                    _Obj1[16] = "0";
                    _Dg_Grid4.Rows.Add(_Obj1);
                }
                //Empaques

                //Precio
                if (_Row["cdiferenciaprec"].ToString() != "0")
                {
                    _Bol_Permiso_Usuario = true;
                    _Obj2[0] = _Row["cproducto"].ToString();
                    _Obj2[1] = _Row["cnamef"].ToString();
                    _Obj2[2] = _Row["ccostobruto_u1"].ToString();
                    _Obj2[3] = _Row["cpreciouni"].ToString();
                    _Obj2[4] = _Row["cpreciodiferenc"].ToString();
                    if (_Row["cdiferenciaprec"].ToString() == "1")
                    { _Obj2[5] = "Precio inferior"; }
                    else
                    { _Obj2[5] = "Sobreprecio"; }
                    _Obj2[6] = _Row["cnumoc"].ToString();
                    _Obj2[7] = _Row["cnfacturapro"].ToString();
                    _Obj2[8] = _Row["cidrecepcion"].ToString();
                    _Obj2[9] = _Row["crechazarpre"].ToString();
                    _Obj2[10] = _Row["caprobadifpsdocu"].ToString();
                    _Obj2[11] = _Row["caprobadifpdocu"].ToString();
                    _Obj2[12] = "0";
                    _Dg_Grid3.Rows.Add(_Obj2);
                }
                //Precio
                _Int_i++;

            }
            _Dg_Grid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_P_Int_Tipo == 1)
            {
                _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                DataSet _Ds_Temp = new DataSet();
                double _Dbl_EmpaquesFAC = 0;
                double _Dbl_EmpaquesOC = 0;
                double _Dbl_EmpaquesOCTotal = 0;
                double _Dbl_EmpaquesOCTemp = 0;
                double _Dbl_UnidadesFAC = 0;
                double _Dbl_UnidadeOC = 0;
                double _Dbl_UnidadeOCTotal = 0;
                double _Dbl_UnidadeOCTemp = 0;
                double _Dbl_UniMinOC = 0;
                double _Dbl_UniMinFact = 0;
                double _Dbl_UniMinOCTotal = 0;
                double _Dbl_UniMinOCTemp = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    double _Dbl_Diferencia = 0;
                    double _Dbl_DiferenciaMin = 0;
                    double _Dbl_Diferencia2 = 0;
                    double _Dbl_Value = 0;
                    double _Dbl_Value2 = 0;
                    double _Dbl_ValueUniMin = 0;
                    _Str_Cadena = "Select SUM(ccantunidadma1),SUM(ccantunidadma2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantunidadma2, ccantunidadma1)) as UniMin from TORDENCOMPD where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dbl_EmpaquesOCTemp = _Dbl_EmpaquesOC;
                            _Dbl_EmpaquesOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString());
                        }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        {
                            _Dbl_UnidadeOCTemp = _Dbl_UnidadeOC;
                            _Dbl_UnidadeOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString());
                        }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        {
                            _Dbl_UniMinOCTemp = _Dbl_UniMinOC;
                            _Dbl_UniMinOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString());
                        }
                    }
                    _Str_Cadena = "Select SUM(ccantidad_u1),SUM(ccantidad_u2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantidad_u2, ccantidad_u1)) as UniMin from TTEMPOC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Row[0].ToString() + "' and csuma='0'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_EmpaquesOC = _Dbl_EmpaquesOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString())); }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Dbl_UnidadeOC = _Dbl_UnidadeOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString())); }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        { _Dbl_UniMinOC = _Dbl_UniMinOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString())); }
                    }
                    _Dbl_EmpaquesOCTotal = _Dbl_EmpaquesOCTotal + _Dbl_EmpaquesOC;
                    _Dbl_UnidadeOCTotal = _Dbl_UnidadeOCTotal + _Dbl_UnidadeOC;
                    _Dbl_UniMinOCTotal = _Dbl_UniMinOCTotal + _Dbl_UniMinOC;
                    _Str_Cadena = "SELECT SUM(cempaques) AS Expr1,SUM(cunidades) AS Expr2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, cunidades, cempaques)) as UniMin " +
                         "FROM TRECEPCIONDFD " +
                         "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cidrecepcion = '" + _P_Str_Rec + "') AND (cnfacturapro = '" + _P_Str_Facturas[0].ToString() + "') AND (cproveedor = '" + _P_Str_Proveedor + "') " +
                         "GROUP BY cgroupcomp, cidrecepcion, cnfacturapro, cproveedor"; ;
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Dbl_UnidadesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        { _Dbl_UniMinFact = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString()); }
                        _Dbl_EmpaquesFAC = _Dbl_EmpaquesFAC - _Dbl_EmpaquesOCTemp;
                        _Dbl_UnidadesFAC = _Dbl_UnidadesFAC - _Dbl_UnidadeOCTemp;
                        _Dbl_UniMinFact = _Dbl_UniMinFact - _Dbl_UniMinOCTemp;
                    }
                    if (_Dbl_EmpaquesFAC >= _Dbl_EmpaquesOC)
                    { _Dbl_EmpaquesFAC = _Dbl_EmpaquesOC; }
                    if (_Dbl_UnidadesFAC >= _Dbl_UnidadeOC)
                    { _Dbl_UnidadesFAC = _Dbl_UnidadeOC; }
                    if (_Dbl_UniMinFact >= _Dbl_UniMinOC)
                    { _Dbl_UniMinFact = _Dbl_UniMinOC; }
                    _Dbl_Diferencia = _Dbl_EmpaquesOC - _Dbl_EmpaquesFAC;
                    _Dbl_Diferencia2 = _Dbl_UnidadeOC - _Dbl_UnidadesFAC;
                    _Dbl_DiferenciaMin = _Dbl_UniMinOC - _Dbl_UniMinFact;

                    if (_Dbl_EmpaquesOC > 0)
                    {
                        _Dbl_Value = 100 - ((_Dbl_Diferencia * 100) / _Dbl_EmpaquesOC);
                    }
                    else
                    {
                        _Dbl_Value = 0;
                    }
                    if (_Dbl_UnidadeOC > 0)
                    {
                        _Dbl_Value2 = 100 - ((_Dbl_Diferencia2 * 100) / _Dbl_UnidadeOC);
                    }
                    else
                    {
                        _Dbl_Value2 = 0;
                    }
                    if (_Dbl_ValueUniMin > 0)
                    {
                        _Dbl_ValueUniMin = 100 - ((_Dbl_DiferenciaMin * 100) / _Dbl_UniMinOC);
                    }
                    else
                    {
                        _Dbl_ValueUniMin = 0;
                    }
                    //string _Str_Valor = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select Cast(cefectividad as integer)+Cast('" + Convert.ToString(Math.Round(_Dbl_Value)) + "' as integer) from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _P_Str_Proveedor + "'").Tables[0].Rows[0][0].ToString();
                    bool _Bol_Cerrar = false;
                    _Str_Cadena = "Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
                    string _Str_Temp = "";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (_Str_Temp != _Row[0].ToString())
                        {

                            double _Dbl_Efect = 0;
                            double _Dbl_Valor = 0;
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            {
                                DataRow _Row_Efec = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                                if (_Row_Efec[0] != System.DBNull.Value)
                                { _Dbl_Efect = Convert.ToDouble(_Row_Efec[0].ToString().Trim()); }
                                //double _Dbl_Promedio = ((_Dbl_Value + _Dbl_Value2) / 2);
                                double _Dbl_Promedio = _Dbl_ValueUniMin;
                                if (_Dbl_Promedio >= _Dbl_Efect)
                                {
                                    //_Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio) + "',ccerrada='1',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                                }
                                else
                                {
                                    //_Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio) + "',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                                }
                                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                            //_Str_Temp = _Row[0].ToString();
                        }
                    }
                }
                _Str_Cadena = "SELECT SUM(cempaques) AS Expr1,SUM(cunidades) AS Expr2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, cunidades, cempaques)) as UniMin  " +
                     "FROM TRECEPCIONDFD " +
                     "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cidrecepcion = '" + _P_Str_Rec + "') AND (cnfacturapro = '" + _P_Str_Facturas[0].ToString() + "') AND (cproveedor = '" + _P_Str_Proveedor + "') " +
                     "GROUP BY cgroupcomp, cidrecepcion, cnfacturapro, cproveedor"; ;
                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
                    if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Dbl_UnidadesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
                    if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                    { _Dbl_UniMinFact = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString()); }
                }
                double _Dbl_Diferencia3 = _Dbl_EmpaquesOCTotal - _Dbl_EmpaquesFAC;
                double _Dbl_Diferencia4 = _Dbl_UnidadeOCTotal - _Dbl_UnidadesFAC;
                double _Dbl_DiferenciaUndMin = _Dbl_UniMinOCTotal - _Dbl_UniMinFact;
                double _Dbl_Value3 = 0;
                double _Dbl_Value4 = 0;
                double _Dbl_Value5 = 0;
                if (_Dbl_EmpaquesOCTotal > 0)
                {
                    _Dbl_Value3 = 100 - ((_Dbl_Diferencia3 * 100) / _Dbl_EmpaquesOCTotal);
                }
                if (_Dbl_UnidadeOCTotal > 0)
                {
                    _Dbl_Value4 = 100 - ((_Dbl_Diferencia4 * 100) / _Dbl_UnidadeOCTotal);
                }
                if (_Dbl_UniMinOCTotal > 0)
                {
                    _Dbl_Value5 = 100 - ((_Dbl_DiferenciaUndMin * 100) / _Dbl_UniMinOCTotal);
                }
                double _Dbl_Promedio2 = 0;
                //_Dbl_Promedio2 = (_Dbl_Value3 + _Dbl_Value4)/2;
                _Dbl_Promedio2 = _Dbl_Value5;
                if (_Dbl_Promedio2 > 100)
                {
                    _Pgb_Progress.Value = 100;
                }
                else
                {
                    _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Promedio2);
                }
                try
                {
                    _Lbl_Por.Text = Convert.ToInt32(_Dbl_Promedio2).ToString();
                }
                catch { _Lbl_Por.Text = ""; }
            }
            else
            {
                double _Dbl_EmpaquesFAC = 0;
                double _Dbl_EmpaquesOC = 0;
                double _Dbl_UniMinOC = 0;
                double _Dbl_UniMinFAC = 0;
                double _Dbl_UnidadesFAC = 0;
                double _Dbl_UnidadesOC = 0;
                _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_OC = "";
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_OC = _Ds.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "SELECT SUM(ccantunidadma1) AS suma,SUM(ccantunidadma2) AS suma2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantunidadma2, ccantunidadma1)) as UniMin FROM TORDENCOMPD WHERE cnumoc = '" + _Str_OC + "' AND ccompany = '" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_Proveedor + "' GROUP BY cnumoc";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_EmpaquesOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    _Dbl_UnidadesOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    _Dbl_UniMinOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString());
                }
                _Str_Cadena = "Select SUM(ccantidad_u1),SUM(ccantidad_u2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantidad_u2, ccantidad_u1)) as UniMin from TTEMPOC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Str_OC + "' and csuma='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_EmpaquesOC = _Dbl_EmpaquesOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString())); }
                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Dbl_UnidadesOC = _Dbl_UnidadesOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString())); }
                    if (_Ds.Tables[0].Rows[0][2] != System.DBNull.Value)
                    { _Dbl_UniMinOC = _Dbl_UniMinOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString())); }
                }
                _Str_Cadena = "Select suma,suma2,UniMin from vst_totaldeempaquesfactura where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    _Dbl_UnidadesFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    _Dbl_UniMinFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString());
                }
                double _Dbl_Diferencia3 = _Dbl_EmpaquesOC - _Dbl_EmpaquesFAC;
                double _Dbl_Diferencia4 = _Dbl_UnidadesOC - _Dbl_UnidadesFAC;
                double _Dbl_Diferencia5 = _Dbl_UniMinOC - _Dbl_UniMinFAC;
                double _Dbl_Value3 = 100;
                double _Dbl_Value4 = 100;
                double _Dbl_Value5 = 100;
                double _Dbl_Promedio3 = 0;
                if (_Dbl_EmpaquesOC > 0)
                {
                    _Dbl_Value3 = 100 - ((_Dbl_Diferencia3 * 100) / _Dbl_EmpaquesOC);
                }
                if (_Dbl_UnidadesOC > 0)
                {
                    _Dbl_Value4 = 100 - ((_Dbl_Diferencia4 * 100) / _Dbl_UnidadesOC);
                }
                if (_Dbl_UniMinOC > 0)
                {
                    _Dbl_Value5 = 100 - ((_Dbl_Diferencia5 * 100) / _Dbl_UniMinOC);
                }
                //string _Str_Valor2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select Cast(cefectividad as integer)+Cast('" + Convert.ToString(Math.Round(_Dbl_Value2)) + "' as integer) from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _P_Str_Proveedor + "'").Tables[0].Rows[0][0].ToString();
                bool _Bol_Cerrar2 = false;
                double _Dbl_Efect2 = 0;
                _Str_Cadena = "Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    DataRow _Row_Efec = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                    if (_Row_Efec[0] != System.DBNull.Value)
                    { _Dbl_Efect2 = Convert.ToDouble(_Row_Efec[0].ToString().Trim()); }
                    //_Dbl_Promedio3 = (_Dbl_Value3 + _Dbl_Value4)/2;
                    _Dbl_Promedio3 = _Dbl_Value5;
                    if (_Dbl_Promedio3 >= _Dbl_Efect2)
                    {
                        //_Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio3) + "',ccerrada='1',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _Str_Proveedor + "'";
                    }
                    else
                    {
                        //_Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio3) + "',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _Str_Proveedor + "'";
                    }
                    //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                if (_Dbl_Promedio3 > 100)
                {
                    _Pgb_Progress.Value = 100;
                }
                else
                {
                    _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Promedio3);
                }
                try
                {
                    _Lbl_Por.Text = Convert.ToInt32(_Dbl_Promedio3).ToString();
                }
                catch { _Lbl_Por.Text = ""; }
            }
            double _Dbl_FaltanesD = 0;
            double _Dbl_EmOC = 0;
            double _Dbl_FaltanesD2 = 0;
            double _Dbl_UnOC = 0;
            _Str_Cadena = "Select ccantempfact,ccantempoc,ccantunifact,ccantunioc from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cproveedor='" + _P_Str_Proveedor + "' and cfaltante='1' and cidrecepcion='" + _P_Str_Rec + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                if (_Row[0] != System.DBNull.Value)
                { _Dbl_FaltanesD = _Dbl_FaltanesD + Convert.ToDouble(_Row[0].ToString().Trim()); }
                if (_Row[2] != System.DBNull.Value)
                { _Dbl_FaltanesD2 = _Dbl_FaltanesD2 + Convert.ToDouble(_Row[2].ToString().Trim()); }
                if (_Row[1] != System.DBNull.Value)
                { _Dbl_EmOC = _Dbl_EmOC + Convert.ToDouble(_Row[1].ToString().Trim()); }
                if (_Row[3] != System.DBNull.Value)
                { _Dbl_UnOC = _Dbl_UnOC + Convert.ToDouble(_Row[3].ToString().Trim()); }
            }
            if (_Dbl_EmOC > _Dbl_FaltanesD)
            { _Txt_Faltantes.Text = Convert.ToString(_Dbl_EmOC - _Dbl_FaltanesD); }
            if (_Dbl_UnOC > _Dbl_FaltanesD2)
            { _Txt_FaltantesUni.Text = Convert.ToString(_Dbl_UnOC - _Dbl_FaltanesD2); }
            if (_Dbl_EmOC < _Dbl_FaltanesD)
            { _Txt_Faltantes.Text = Convert.ToString(_Dbl_FaltanesD - _Dbl_EmOC); }
            if (_Dbl_UnOC < _Dbl_FaltanesD2)
            { _Txt_FaltantesUni.Text = Convert.ToString(_Dbl_FaltanesD2 - _Dbl_UnOC); }
            _Bol_guardar = true;
            _Bt_Guardar.Enabled = false;
        }
        public Frm_OC_FAC(string _P_Str_Rec, string _P_Str_Proveedor, int _P_Int_Tipo, string[] _P_Str_Facturas,int _P_Int_Sw)
        {
            InitializeComponent();
            double _Dbl_EfectividadAcum = 0;
            double _Dbl_EfectividadAcum100 = 0;
            _Str_Rec = _P_Str_Rec;
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Facturas = _P_Str_Facturas;
            _Pgb_Progress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            string _Str_Cadena = "Select DISTINCT cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_facturacomparada.cproducto) AS cnamef,ccostobruto_u1,cpreciouni,cpreciodiferenc,ccantunidadma1,ccantunidadma2,cempaques,cunidades,cdiferenciaemp,cdiferenciauni,cnumoc,cnfacturapro,cidrecepcion,cfaltante,cdiferenciaprec,crechazarcaj,crechazarpre,csolocant,cmotrechazo,caprobadifpsdocu,caprobadifpdocu from vst_facturacomparada where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Mtd_Guardar_Cambios_Automaticos();
                _Lbl_Nohay.Text = "No existen diferencias";
                _Lbl_Nohay.Visible = true;
                _Bt_Imprimir.Enabled = false;
                _Bt_Imprimir2.Enabled = false;
                _Bt_Guardar.Enabled = false;
            }
            DataSet _Ds2 = new DataSet();
            //_Dg_Grid4.DataSource = _Ds.Tables[0];
            int _Int_i = 0;
            object[] _Obj1 = new object[17];
            object[] _Obj2 = new object[15];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                //Empaques
                if (_Row["cfaltante"].ToString() != "0")
                {
                    _Obj1[0] = _Row["cproducto"].ToString();
                    _Obj1[1] = _Row["cnamef"].ToString();
                    if (_Row["ccantunidadma1"] != System.DBNull.Value)
                    { _Obj1[2] = _Row["ccantunidadma1"].ToString(); }
                    else
                    { _Obj1[2] = "0"; }
                    if (_Row["ccantunidadma2"] != System.DBNull.Value)
                    { _Obj1[3] = _Row["ccantunidadma2"].ToString(); }
                    else
                    { _Obj1[3] = "0"; }
                    if (_Row["cempaques"] != System.DBNull.Value)
                    { _Obj1[4] = _Row["cempaques"].ToString(); }
                    else
                    { _Obj1[4] = "0"; }
                    if (_Row["cunidades"] != System.DBNull.Value)
                    { _Obj1[5] = _Row["cunidades"].ToString(); }
                    else
                    { _Obj1[5] = "0"; }
                    _Obj1[6] = _Row["cdiferenciaemp"].ToString();
                    _Obj1[7] = _Row["cdiferenciauni"].ToString();
                    if (_Row["cfaltante"].ToString() == "1")
                    { _Obj1[8] = "Por llegar"; }
                    else
                    { _Obj1[8] = "Sobrante"; }
                    _Obj1[9] = _Row["cnumoc"].ToString();
                    _Obj1[10] = _Row["cnfacturapro"].ToString();
                    _Obj1[11] = _Row["cidrecepcion"].ToString();
                    _Obj1[12] = "0";
                    _Obj1[13] = "0";
                    _Obj1[14] = "0";
                    _Obj1[15] = "";
                    _Obj1[16] = "0";
                    _Dg_Grid4.Rows.Add(_Obj1);
                }
                //Empaques

                //Precio
                if (_Row["cdiferenciaprec"].ToString() != "0")
                {
                    _Bol_Permiso_Usuario = true;
                    _Obj2[0] = _Row["cproducto"].ToString();
                    _Obj2[1] = _Row["cnamef"].ToString();
                    _Obj2[2] = _Row["ccostobruto_u1"].ToString();
                    _Obj2[3] = _Row["cpreciouni"].ToString();
                    _Obj2[4] = _Row["cpreciodiferenc"].ToString();
                    if (_Row["cdiferenciaprec"].ToString() == "1")
                    { _Obj2[5] = "Precio inferior"; }
                    else
                    { _Obj2[5] = "Sobreprecio"; }
                    _Obj2[6] = _Row["cnumoc"].ToString();
                    _Obj2[7] = _Row["cnfacturapro"].ToString();
                    _Obj2[8] = _Row["cidrecepcion"].ToString();
                    _Obj2[9] = _Row["crechazarpre"].ToString();
                    _Obj2[10] = _Row["caprobadifpsdocu"].ToString();
                    _Obj2[11] = _Row["caprobadifpdocu"].ToString();
                    _Obj2[12] = "0";
                    _Dg_Grid3.Rows.Add(_Obj2);
                }
                //Precio
                _Int_i++;
            }
            _Dg_Grid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_P_Int_Tipo == 1)
            {
                _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                DataSet _Ds_Temp = new DataSet();
                double _Dbl_EmpaquesFAC = 0;
                double _Dbl_EmpaquesOC = 0;
                double _Dbl_EmpaquesOCTotal = 0;
                double _Dbl_EmpaquesOCTemp = 0;
                double _Dbl_UnidadesFAC = 0;
                double _Dbl_UnidadesOC = 0;
                double _Dbl_UnidadesOCTotal = 0;
                double _Dbl_UnidadesOCTemp = 0;
                double _Dbl_UniMinOC = 0;
                double _Dbl_UniMinFact = 0;
                double _Dbl_UniMinOCTotal = 0;
                double _Dbl_UniMinOCTemp = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    double _Dbl_Diferencia = 0;
                    double _Dbl_Value = 100;
                    double _Dbl_Diferencia2 = 0;
                    double _Dbl_Value2 = 100;
                    double _Dbl_ValueUniMin = 0;
                    double _Dbl_DiferenciaMin = 0;
                    _Str_Cadena = "Select SUM(ccantunidadma1),SUM(ccantunidadma2),SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantunidadma2, ccantunidadma1)) as UniMin from TORDENCOMPD where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dbl_EmpaquesOCTemp = _Dbl_EmpaquesOC;
                            _Dbl_EmpaquesOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString());
                        }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        {
                            _Dbl_UnidadesOCTemp = _Dbl_UnidadesOC;
                            _Dbl_UnidadesOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString());
                        }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        {
                            _Dbl_UniMinOCTemp = _Dbl_UniMinOC;
                            _Dbl_UniMinOC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString());
                        }
                    }
                    //_Str_Cadena = "Select SUM(ccantidad_u1) from TTEMPOC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Row[0].ToString() + "' and csuma='0'";
                    //_Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    //{
                    //    if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                    //    { _Dbl_EmpaquesOC = _Dbl_EmpaquesOC - (Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString())); }
                    //}
                    _Dbl_EmpaquesOCTotal = _Dbl_EmpaquesOCTotal + _Dbl_EmpaquesOC;
                    _Dbl_UnidadesOCTotal = _Dbl_UnidadesOCTotal + _Dbl_UnidadesOC;
                    _Dbl_UniMinOCTotal = _Dbl_UniMinOCTotal + _Dbl_UniMinOC;
                    _Str_Cadena = "SELECT SUM(cempaques) AS Expr1,SUM(cunidades) AS Expr2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, cunidades, cempaques)) as UniMin " +
                         "FROM TRECEPCIONDFD " +
                         "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cidrecepcion = '" + _P_Str_Rec + "') AND (cnfacturapro = '" + _P_Str_Facturas[0].ToString() + "') AND (cproveedor = '" + _P_Str_Proveedor + "') " +
                         "GROUP BY cgroupcomp, cidrecepcion, cnfacturapro, cproveedor"; ;
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
                        if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                        { _Dbl_UnidadesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
                        if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                        { _Dbl_UniMinFact = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString()); }
                        _Dbl_EmpaquesFAC = _Dbl_EmpaquesFAC - _Dbl_EmpaquesOCTemp;
                        _Dbl_UnidadesFAC = _Dbl_UnidadesFAC - _Dbl_UnidadesOCTemp;
                        _Dbl_UniMinFact = _Dbl_UniMinFact - _Dbl_UniMinOCTemp;
                    }
                    if (_Dbl_EmpaquesFAC >= _Dbl_EmpaquesOC)
                    { _Dbl_EmpaquesFAC = _Dbl_EmpaquesOC; }
                    if (_Dbl_UnidadesFAC >= _Dbl_UnidadesOC)
                    { _Dbl_UnidadesFAC = _Dbl_UnidadesOC; }
                    if (_Dbl_UniMinFact >= _Dbl_UniMinOC)
                    { _Dbl_UniMinFact = _Dbl_UniMinOC; }
                    _Dbl_Diferencia = _Dbl_EmpaquesOC - _Dbl_EmpaquesFAC;
                    _Dbl_Diferencia2 = _Dbl_UnidadesOC - _Dbl_UnidadesFAC;
                    _Dbl_DiferenciaMin = _Dbl_UniMinOC - _Dbl_UniMinFact;
                    if (_Dbl_EmpaquesOC > 0)
                    {
                        _Dbl_Value = 100 - ((_Dbl_Diferencia * 100) / _Dbl_EmpaquesOC);
                    }
                    if (_Dbl_UnidadesOC > 0)
                    {
                        _Dbl_Value2 = 100 - ((_Dbl_Diferencia2 * 100) / _Dbl_UnidadesOC);
                    }
                    if (_Dbl_ValueUniMin > 0)
                    {
                        _Dbl_ValueUniMin = 100 - ((_Dbl_DiferenciaMin * 100) / _Dbl_UniMinOC);
                    }
                    else
                    {
                        _Dbl_ValueUniMin = 0;
                    }
                    //string _Str_Valor = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select Cast(cefectividad as integer)+Cast('" + Convert.ToString(Math.Round(_Dbl_Value)) + "' as integer) from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _P_Str_Proveedor + "'").Tables[0].Rows[0][0].ToString();
                    bool _Bol_Cerrar = false;
                    _Str_Cadena = "Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
                    string _Str_Temp = "";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (_Str_Temp != _Row[0].ToString())
                        {
                            double _Dbl_Promedio = 0;
                            double _Dbl_Efect = 0;
                            double _Dbl_Valor = 0;
                            //_Dbl_Promedio = (_Dbl_Value + _Dbl_Value2) / 2;
                            _Dbl_Promedio = _Dbl_ValueUniMin; ;
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            {
                                DataRow _Row_Efec = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                                if (_Row_Efec[0] != System.DBNull.Value)
                                { _Dbl_Efect = Convert.ToDouble(_Row_Efec[0].ToString().Trim()); }
                                if (_Dbl_Promedio >= _Dbl_Efect)
                                {

                                    _Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio) + "',ccerrada='1',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                                }
                                else
                                {
                                    _Str_Cadena = "Update TORDENCOMPM Set cefectividad='" + Math.Round(_Dbl_Promedio) + "',cevaluado='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                                }
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                            //_Str_Temp = _Row[0].ToString();
                        }
                    }
                }
                _Str_Cadena = "SELECT SUM(cempaques) AS Expr1,SUM(cunidades) AS Expr2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, cunidades, cempaques)) as UniMin " +
                     "FROM TRECEPCIONDFD " +
                     "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cidrecepcion = '" + _P_Str_Rec + "') AND (cnfacturapro = '" + _P_Str_Facturas[0].ToString() + "') AND (cproveedor = '" + _P_Str_Proveedor + "') " +
                     "GROUP BY cgroupcomp, cidrecepcion, cnfacturapro, cproveedor"; ;
                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                {
                    if (_Ds_Temp.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][0].ToString()); }
                    if (_Ds_Temp.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Dbl_UnidadesFAC = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][1].ToString()); }
                    if (_Ds_Temp.Tables[0].Rows[0][2] != System.DBNull.Value)
                    { _Dbl_UniMinFact = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0][2].ToString()); }
                }
                double _Dbl_Diferencia3 = _Dbl_EmpaquesOCTotal - _Dbl_EmpaquesFAC;
                double _Dbl_Diferencia4 = _Dbl_UnidadesOCTotal - _Dbl_UnidadesFAC;
                double _Dbl_DiferenciaUndMin = _Dbl_UniMinOCTotal - _Dbl_UniMinFact;
                double _Dbl_Value3 = 100;
                double _Dbl_Value4 = 100;
                double _Dbl_Value5 = 0;
                if (_Dbl_EmpaquesOCTotal > 0)
                {
                    _Dbl_Value3 = 100 - ((_Dbl_Diferencia3 * 100) / _Dbl_EmpaquesOCTotal);
                }
                if (_Dbl_UnidadesOCTotal > 0)
                {
                    _Dbl_Value4 = 100 - ((_Dbl_Diferencia4 * 100) / _Dbl_UnidadesOCTotal);
                }
                if (_Dbl_UniMinOCTotal > 0)
                {
                    _Dbl_Value5 = 100 - ((_Dbl_DiferenciaUndMin * 100) / _Dbl_UniMinOCTotal);
                }
                double _Dbl_Promedio2 = 0;
                //_Dbl_Promedio2 = (_Dbl_Value3 + _Dbl_Value4)/2;
                _Dbl_Promedio2 = _Dbl_Value5;
                if (_Dbl_Promedio2 > 100)
                {
                    _Pgb_Progress.Value = 100;
                }
                else
                {
                    _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Promedio2);
                }
                try
                {
                    _Lbl_Por.Text = Convert.ToInt32(_Dbl_Promedio2).ToString();
                }
                catch { _Lbl_Por.Text = ""; }
            }
            else
            {
                double _Dbl_EmpaquesFAC = 0;
                double _Dbl_EmpaquesOC = 0;
                double _Dbl_EmpaquesOCTemp = 0;
                double _Dbl_UnidadesFAC = 0;
                double _Dbl_UniMinOC = 0;
                double _Dbl_UniMinFAC = 0;
                double _Dbl_UnidadesOC = 0;
                double _Dbl_UnidadesOCTemp = 0;
                double _Dbl_UniMinOCTemp = 0;
                _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_OC = "";
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_OC = _Ds.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "SELECT SUM(ccantunidadma1) AS suma,SUM(ccantunidadma2) AS suma2, SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantunidadma2, ccantunidadma1)) as UniMin FROM TORDENCOMPD WHERE cnumoc = '" + _Str_OC + "' AND ccompany = '" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_Proveedor + "' GROUP BY cnumoc";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_EmpaquesOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    _Dbl_UnidadesOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    _Dbl_UniMinOC = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString());
                }
                _Str_Cadena = "Select SUM(ccantidad_u1),SUM(ccantidad_u2), SUM(dbo.Fnc_ConvertCajasUnd(cproducto, ccantidad_u2, ccantidad_u1)) as UniMin from TTEMPOC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocu='" + _Str_OC + "' and csuma='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {//GERENTEC
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_EmpaquesOCTemp = _Dbl_EmpaquesOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString())); }
                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Dbl_UnidadesOCTemp = _Dbl_UnidadesOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString())); }
                    if (_Ds.Tables[0].Rows[0][2] != System.DBNull.Value)
                    { _Dbl_UniMinOCTemp = _Dbl_UniMinOC - (Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString())); }
                }
                _Str_Cadena = "Select suma,suma2,UniMin from vst_totaldeempaquesfactura where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_EmpaquesFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    _Dbl_UnidadesFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    _Dbl_UniMinFAC = Convert.ToDouble(_Ds.Tables[0].Rows[0][2].ToString());
                }
                double _Dbl_Diferencia3 = _Dbl_EmpaquesOC - _Dbl_EmpaquesFAC;
                double _Dbl_Diferencia4 = _Dbl_UnidadesOC - _Dbl_UnidadesFAC;
                double _Dbl_Diferencia5 = _Dbl_UniMinOC - _Dbl_UniMinFAC;
                double _Dbl_Value3 = 100;
                double _Dbl_Value4 = 100;
                double _Dbl_Value5 = 100;
                if (_Dbl_EmpaquesOC > 0)
                {
                    _Dbl_Value3=100 - ((_Dbl_Diferencia3 * 100) / _Dbl_EmpaquesOC);
                }
                if (_Dbl_UnidadesOC > 0)
                {
                    _Dbl_Value4 = 100 - ((_Dbl_Diferencia4 * 100) / _Dbl_UnidadesOC);
                }
                if (_Dbl_UniMinOC > 0)
                {
                    _Dbl_Value5 = 100 - ((_Dbl_Diferencia5 * 100) / _Dbl_UniMinOC);
                }
                //string _Str_Valor2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select Cast(cefectividad as integer)+Cast('" + Convert.ToString(Math.Round(_Dbl_Value2)) + "' as integer) from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Str_OC + "' and cproveedor='" + _P_Str_Proveedor + "'").Tables[0].Rows[0][0].ToString();
                bool _Bol_Cerrar2 = false;
                double _Dbl_Efect2 = 0;
                double _Dbl_Promedio2 = 0;
                //_Dbl_Promedio2 = (_Dbl_Value3 + _Dbl_Value4) / 2;
                _Dbl_Promedio2 = _Dbl_Value5;
                if (_Dbl_Promedio2 > 100)
                {
                    _Pgb_Progress.Value = 100;
                }
                else
                {
                    _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Promedio2);
                }
                try
                {
                    _Lbl_Por.Text = Convert.ToInt32(_Dbl_Promedio2).ToString();
                }
                catch { _Lbl_Por.Text = ""; }
            }
            double _Dbl_FaltanesD = 0;
            double _Dbl_EmOC = 0;
            double _Dbl_FaltanesD2 = 0;
            double _Dbl_UnOC = 0;
            _Str_Cadena = "Select ccantempfact,ccantempoc,ccantunifact,ccantunioc from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cproveedor='" + _P_Str_Proveedor + "' and cfaltante='1' and cidrecepcion='" + _P_Str_Rec + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                if (_Row[0] != System.DBNull.Value)
                { _Dbl_FaltanesD = _Dbl_FaltanesD + Convert.ToDouble(_Row[0].ToString().Trim()); }
                if (_Row[2] != System.DBNull.Value)
                { _Dbl_FaltanesD2 = _Dbl_FaltanesD2 + Convert.ToDouble(_Row[2].ToString().Trim()); }
                if (_Row[1] != System.DBNull.Value)
                { _Dbl_EmOC = _Dbl_EmOC + Convert.ToDouble(_Row[1].ToString().Trim()); }
                if (_Row[3] != System.DBNull.Value)
                { _Dbl_UnOC = _Dbl_UnOC + Convert.ToDouble(_Row[3].ToString().Trim()); }
            }
            if (_Dbl_EmOC > _Dbl_FaltanesD)
            { _Txt_Faltantes.Text = Convert.ToString(_Dbl_EmOC - _Dbl_FaltanesD); }
            if (_Dbl_UnOC > _Dbl_FaltanesD2)
            { _Txt_FaltantesUni.Text = Convert.ToString(_Dbl_UnOC - _Dbl_FaltanesD2); }
            if (_Dbl_EmOC < _Dbl_FaltanesD)
            { _Txt_Faltantes.Text = Convert.ToString(_Dbl_FaltanesD - _Dbl_EmOC); }
            if (_Dbl_UnOC < _Dbl_FaltanesD2)
            { _Txt_FaltantesUni.Text = Convert.ToString(_Dbl_FaltanesD2 - _Dbl_UnOC); }
            //_____________________________________
            if (_Bol_Permiso_Usuario)
            {
                _Str_Cadena = "SELECT * " +
"FROM TUSER INNER JOIN " +
"TPROCEFIRMAD ON TUSER.cuser = TPROCEFIRMAD.cuser " +
"WHERE (TUSER.cuser = '" + Frm_Padre._Str_Use + "') AND (TPROCEFIRMAD.cprocesofirma = 'F_DIFERN_OC_FACT') AND TUSER.cfirmante='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dg_Grid3.ContextMenuStrip = contextMenuStrip3;
                }
            }

        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
   
        private void Frm_OC_FAC_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        bool _Bol_guardar = false;
        private void Frm_OC_FAC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_Lbl_Nohay.Visible)
            {
                if (!_Bol_guardar)
                {
                    if (MessageBox.Show("Al cerrar el módulo solo el gerente comercial podra firmar esta recepción. ¿Esta seguro de cerrar este módulo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    { e.Cancel = true; }
                }
                else
                {
                    CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                    CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "SELECT * FROM vst_facturacomparada WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Rec + "' and cproveedor='" + _Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                REPORTESS _Frm = new REPORTESS("T3.Report.rFactComparada1", _Ds.Tables[0], "Section1", "cabecera", "rif", "nit");
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
                Cursor = Cursors.Default;
                _Bt_Imprimir.Enabled = false;
                if (!_Bt_Imprimir2.Enabled)
                { this.Close(); }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Txt_Clave.Text = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid4.Rows.Count > 0)
            {
                _Pnl_Motivo.Visible = true;
                _Txt_Motivo.Focus();
            }
        }

        private void _Pnl_Motivo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Motivo.Visible)
            {
                _Grb_1.Enabled = false;
                _Grb_2.Enabled = false;
                _Bt_Imprimir.Enabled = false;
                _Bt_Imprimir2.Enabled = false;
                _Bt_Guardar.Enabled = false;
                _Txt_Motivo.Focus();
            }
            else
            {
                _Grb_1.Enabled = true;
                _Grb_2.Enabled = true;
                //_Bt_Imprimir.Enabled = true;
                //_Bt_Imprimir2.Enabled = true;
                _Bt_Guardar.Enabled = true;
            }
        }

        private void _Bt_AceptarMotivo_Click(object sender, EventArgs e)
        {
            if (_Txt_Motivo.Text.Trim().Length > 0)
            {
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value = _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Value;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[14].Value = _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Value;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value = _Txt_Motivo.Text.Trim();
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value = "1";
                _Mtd_MostrarInfomacion();
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[8].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[9].Style.BackColor = Color.Red;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.Red;
                _Er_Error.Dispose();
                _Txt_Motivo.Text = "";
                _Pnl_Motivo.Visible = false;
                _Dg_Grid4.ClearSelection();
            }
            else
            {
                _Er_Error.SetError(_Txt_Motivo, "Información Requerida!!!");
            }
        }

        private void _Bt_CancelarMotivo_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Txt_Motivo.Text = "";
            _Pnl_Motivo.Visible = false;
            _Dg_Grid4.ClearSelection();
        }

        private void _Txt_AceptarSolo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_AceptarSolo_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_AceptarSolo.Text))
            {
                _Txt_AceptarSolo.Text = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Txt_AceptarSolo.Text = "";
            _Txt_AceptarSoloUni.Text = "";
            _Pnl_AceptarSolo.Visible = false;
            _Dg_Grid4.ClearSelection();
        }

        private void _Bt_AceptarSolo_Click(object sender, EventArgs e)
        {
            if (_Txt_AceptarSolo.Text.Trim().Length > 0)
            {
                if (_Txt_AceptarSoloUni.Text.Trim().Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    int _Int_1 = Convert.ToInt32(_Txt_AceptarSolo.Text.Trim());
                    int _Int_Uni1 = Convert.ToInt32(_Txt_AceptarSoloUni.Text.Trim());
                    int _Int_2 = Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim()) + Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Value.ToString().Trim());
                    int _Int_Uni2 = Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim()) + Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Value.ToString().Trim());
                    int _Int_3 = _Int_2 - _Int_1;
                    int _Int_Uni3 = _Int_Uni2 - _Int_Uni1;
                    if ((_Int_1 > _Int_2) || (_Int_Uni1 > _Int_Uni2))
                    { MessageBox.Show("La cantidad de cajas debe ser menor o igual a " + _Int_2.ToString() +" y la de unidades menor o igual a "+Convert.ToString(_Int_Uni2-1), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Txt_AceptarSolo.Text = ""; _Txt_AceptarSolo.Focus(); }
                    else
                    {
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value = _Txt_AceptarSolo.Text.Trim();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[14].Value = _Txt_AceptarSoloUni.Text.Trim();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value = _Int_3.ToString();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value = "";
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[16].Value = "1";
                        _Mtd_MostrarInfomacion();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[8].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[9].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.Blue;
                        _Er_Error.Dispose();
                        _Txt_AceptarSolo.Text = "";
                        _Txt_AceptarSoloUni.Text = "";
                        _Pnl_AceptarSolo.Visible = false;
                        _Dg_Grid4.ClearSelection();
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    int _Int_1 = Convert.ToInt32(_Txt_AceptarSolo.Text.Trim());
                    int _Int_2 = Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim()) + Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Value.ToString().Trim());
                    int _Int_3 = _Int_2 - _Int_1;
                    if (_Int_1 > _Int_2)
                    { MessageBox.Show("La cantidad de cajas debe ser menor o igual a " + _Int_2.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Txt_AceptarSolo.Text = ""; _Txt_AceptarSolo.Focus(); }
                    else
                    {
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value = _Txt_AceptarSolo.Text.Trim();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[14].Value = "0";
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value = _Int_3.ToString();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value = "";
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[16].Value = "1";
                        _Mtd_MostrarInfomacion();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[8].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[9].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.Blue;
                        _Er_Error.Dispose();
                        _Txt_AceptarSolo.Text = "";
                        _Txt_AceptarSoloUni.Text = "";
                        _Pnl_AceptarSolo.Visible = false;
                        _Dg_Grid4.ClearSelection();
                    }
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                if (_Txt_AceptarSoloUni.Text.Trim().Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    int _Int_Uni1 = Convert.ToInt32(_Txt_AceptarSoloUni.Text.Trim());
                    int _Int_Uni2 = Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim()) + Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Value.ToString().Trim());
                    int _Int_Uni3 = _Int_Uni2 - _Int_Uni1;
                    if (_Int_Uni1 >= _Int_Uni2)
                    { MessageBox.Show("La cantidad de unidades debe ser menor o igual a " + Convert.ToString(_Int_Uni2-1), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Txt_AceptarSolo.Text = ""; _Txt_AceptarSolo.Focus(); }
                    else
                    {
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value = "0";
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[14].Value = _Txt_AceptarSoloUni.Text.Trim();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value = _Int_Uni3.ToString();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value = "";
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[16].Value = "1";
                        _Mtd_MostrarInfomacion();
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[8].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[9].Style.BackColor = Color.Blue;
                        _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.Blue;
                        _Er_Error.Dispose();
                        _Txt_AceptarSolo.Text = "";
                        _Txt_AceptarSoloUni.Text = "";
                        _Pnl_AceptarSolo.Visible = false;
                        _Dg_Grid4.ClearSelection();
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    _Er_Error.SetError(_Txt_AceptarSolo, "Información Requerida!!!");
                }
            }
        }

        private void _Pnl_AceptarSolo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_AceptarSolo.Visible)
            {
                _Grb_1.Enabled = false;
                _Grb_2.Enabled = false;
                _Bt_Imprimir.Enabled = false;
                _Bt_Imprimir2.Enabled = false;
                _Bt_Guardar.Enabled = false;
                _Txt_AceptarSolo.Focus();
            }
            else
            {
                _Grb_1.Enabled = true;
                _Grb_2.Enabled = true;
                //_Bt_Imprimir.Enabled = true;
                //_Bt_Imprimir2.Enabled = true;
                _Bt_Guardar.Enabled = true;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid4.Rows.Count > 0)
            {
                int _Int_Emp = Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim()) + Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Value.ToString().Trim());
                int _Int_Uni = Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim()) + Convert.ToInt32(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Value.ToString().Trim());
                if (_Int_Emp > 0)
                {
                    _Txt_AceptarSolo.Focus();
                    this._Txt_AceptarSolo.Enabled = true;
                }
                else
                {
                    this._Txt_AceptarSolo.Enabled = false;
                }
                if (_Int_Uni > 0)
                {
                    _Txt_AceptarSoloUni.Focus();
                    this._Txt_AceptarSoloUni.Enabled = true;
                }
                else
                {
                    this._Txt_AceptarSoloUni.Enabled = false;
                }
                _Pnl_AceptarSolo.Visible = true;                
            }
        }

        private void rechazarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid3.Rows.Count > 0)
            {
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[9].Value = "1";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Red;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Red;
            }
        }

        private void Frm_OC_FAC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_AceptarSolo.Parent = this;
            _Pnl_Clave.Parent = this;
            _Pnl_Motivo.Parent = this;
            _Pnl_Clave.BringToFront();
            _Pnl_Motivo.BringToFront();
            _Pnl_AceptarSolo.BringToFront();
            _Pnl_AceptarSolo.Left = (this.Width / 2) - (_Pnl_AceptarSolo.Width / 2);
            _Pnl_AceptarSolo.Top = (this.Height / 2) - (_Pnl_AceptarSolo.Height / 2);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Motivo.Left = (this.Width / 2) - (_Pnl_Motivo.Width / 2);
            _Pnl_Motivo.Top = (this.Height / 2) - (_Pnl_Motivo.Height / 2);
            string _Str_Cadena = "Update TRECEPCIONM Set cevaluado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and   cidrecepcion='" + _Str_Rec + "' and cproveedor='" + _Str_Proveedor + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            if (_Bol_FrmNoDif)
            {
                _Mtd_Guardar_Cambios();
                _Mtd_MostrarInfomacion();
                _Pnl_Clave.Visible = false;
                _Txt_Clave.Text = "";
                _Bol_guardar = true;
                //this.Close();
            }
        }
        private void _Mtd_Guardar_Cambios_Automaticos()
        {
            string _Str_Cadena = "";
            foreach (string _Str_Fac in _Str_Facturas)
            {
                _Str_Cadena = "Update TRECEPCIONDFM Set cevaluado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and   cidrecepcion='" + _Str_Rec + "' and cnfacturapro='" + _Str_Fac + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            _Str_Cadena = "Update TRECEPCIONM Set cevaluado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and   cidrecepcion='" + _Str_Rec + "' and cproveedor='" + _Str_Proveedor + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Guardar_Cambios()
        {
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Row in _Dg_Grid4.Rows)
            {
                _Str_Cadena = "Update TRECEPCIONDDDOCF Set crechazarcaj='" + _Row.Cells[12].Value.ToString() + "',csolocant='" + _Row.Cells[13].Value.ToString() + "',csolocantuni='" + _Row.Cells[14].Value.ToString() + "',cmotrechazo='" + _Row.Cells[15].Value.ToString() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Row.Cells[11].Value.ToString() + "' and cproducto='" + _Row.Cells[0].Value.ToString() + "' and cnumoc='" + _Row.Cells[9].Value.ToString() + "' and cnfacturapro='" + _Row.Cells[10].Value.ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            foreach (DataGridViewRow _Row in _Dg_Grid3.Rows)
            {
                _Str_Cadena = "Update TRECEPCIONDDDOCF Set crechazarpre='" + _Row.Cells[9].Value.ToString() + "',caprobadifpsdocu='" + _Row.Cells[10].Value.ToString() + "',caprobadifpdocu='" + _Row.Cells[11].Value.ToString() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Row.Cells[8].Value.ToString() + "' and cproducto='" + _Row.Cells[0].Value.ToString() + "' and cnumoc='" + _Row.Cells[6].Value.ToString() + "' and cnfacturapro='" + _Row.Cells[7].Value.ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            foreach (string _Str_Fac in _Str_Facturas)
            {
                _Str_Cadena = "Update TRECEPCIONDFM Set cevaluado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and  cidrecepcion='" + _Str_Rec + "' and cnfacturapro='" + _Str_Fac + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            foreach (string _Str_Fac in _Str_Facturas)
            {
                _Str_Cadena = "Update TRECEPCIONRELDIF Set cuserfirma='" + Frm_Padre._Str_Use.ToUpper() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and  cidrecepcion='" + _Str_Rec + "' and cnfacturapro='" + _Str_Fac + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            _Str_Cadena = "Update TRECEPCIONM Set cevaluado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and  cidrecepcion='" + _Str_Rec + "' and cproveedor='" + _Str_Proveedor + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Bol_guardar = true;
            //MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Mtd_MostrarInfomacion()
        {
            if (_Dg_Grid4.Rows.Count > 0)
            {
                if (_Dg_Grid4.CurrentCell != null)
                {
                    if (_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value != null)
                    {
                        if (Convert.ToString(_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value).Trim() == "1")
                        { _Lbl_SiNo.Text = "Sí"; }
                        else
                        { _Lbl_SiNo.Text = "No"; }
                    }
                    else
                    { _Lbl_SiNo.Text = ""; }
                    if (_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value != null)
                    { _Lbl_Motivo.Text = _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value.ToString(); }
                    else
                    { _Lbl_Motivo.Text = ""; }
                    if (_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value != null)
                    { _Lbl_AceptarSolo.Text = _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value.ToString(); }
                    else
                    { _Lbl_AceptarSolo.Text = ""; }
                }
            }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
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
                    if (_Mtd_Validar_Marcado_Sobrante() & _Mtd_Validar_Marcado_Sobrepresio())
                    {
                        _Mtd_Guardar_Cambios();
                        _Mtd_MostrarInfomacion();
                        MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                        _Bol_guardar = true;
                        this.Close();
                    }
                    else
                    {
                        if (!_Mtd_Validar_Marcado_Sobrante() & _Mtd_Validar_Marcado_Sobrepresio())
                        { MessageBox.Show("Existen sobrantes sin aprobar. Por favor verifique","Interrupción",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
                        else if (!_Mtd_Validar_Marcado_Sobrepresio() & _Mtd_Validar_Marcado_Sobrante())
                        { MessageBox.Show("Existen diferencias de precio sin aprobar. Por favor verifique", "Interrupción", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        else if (!_Mtd_Validar_Marcado_Sobrante() & !_Mtd_Validar_Marcado_Sobrepresio())
                        { MessageBox.Show("Existen sobrantes sin aprobar y diferencias de precio sin aprobar. Por favor verifique", "Interrupción", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        _Pnl_Clave.Visible = false;
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { MessageBox.Show("Error en la operación","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Grb_1.Enabled = false;
                _Grb_2.Enabled = false;
                _Bt_Imprimir.Enabled = false;
                _Bt_Imprimir2.Enabled = false;
                _Bt_Guardar.Enabled = false;
                _Txt_Clave.Focus();
            }
            else
            {
                _Grb_1.Enabled = true;
                _Grb_2.Enabled = true;
                //_Bt_Imprimir.Enabled = true;
                //_Bt_Imprimir2.Enabled = true;
                _Bt_Guardar.Enabled = true;
            }
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            if (_Bol_Permiso_Usuario)
            {
                string _Str_Cadena = "SELECT * "+
"FROM TUSER INNER JOIN "+
"TPROCEFIRMAD ON TUSER.cuser = TPROCEFIRMAD.cuser "+
"WHERE (TUSER.cuser = '" + Frm_Padre._Str_Use + "') AND (TPROCEFIRMAD.cprocesofirma = 'F_DIFERN_OC_FACT') AND TUSER.cfirmante='1'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Text = "";
                }
                else
                {
                    MessageBox.Show("Su usuario no puede firmar esta evaluación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    _Bol_guardar = true;
                }
            }
            else
            {                
                _Pnl_Clave.Visible = true;           

                _Txt_Clave.Text = "";
            }
        }
        private bool _Mtd_Validar_Marcado_Recha()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid4.Rows)
            {
                if (_Dg_Row.Cells[8].Value.ToString().Trim() == "Sobrante" & _Dg_Row.Cells[12].Value.ToString().Trim() == "1")
                {
                    return false;
                }
            }
            return true;
        }
        private bool _Mtd_Validar_Marcado_Sobrante()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid4.Rows)
            {
                if (_Dg_Row.Cells[8].Value.ToString().Trim() == "Sobrante" & ((Convert.ToString(_Dg_Row.Cells[12].Value).Trim().Length == 0 | Convert.ToString(_Dg_Row.Cells[12].Value).Trim() == "0") & Convert.ToString(_Dg_Row.Cells[16].Value).Trim() != "1"))
                {
                    return false;
                }
            }
            return true;
        }
        private bool _Mtd_Validar_Marcado_Sobrepresio()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid3.Rows)
            {
                if (_Dg_Row.Cells[12].Value.ToString().Trim() == "0")
                {
                    return false;
                }
            }
            return true;
        }
        private bool _Mtd_Validar_Imprimir_Sobrante()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid4.Rows)
            {
                if (_Dg_Row.Cells[5].Value.ToString().Trim() == "Sobrante")
                {
                    return true;
                }
            }
            return false;
        }
        private bool _Mtd_Validar_Imprimir_Porllegar()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid4.Rows)
            {
                if (_Dg_Row.Cells[5].Value.ToString().Trim() == "Por llegar")
                {
                    return true;
                }
            }
            return false;
        }
        private void _Dg_Grid4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_MostrarInfomacion();
        }

        private void _Dg_Grid4_CurrentCellChanged(object sender, EventArgs e)
        {
            _Mtd_MostrarInfomacion();
        } 

        private void aceptarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid4.Rows.Count > 0)
            {
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[12].Value = "0";
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[14].Value = "0";
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[13].Value = "0";
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[15].Value = "";
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[16].Value = "1";
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[8].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[9].Style.BackColor = Color.Green;
                _Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.Green;
                _Mtd_MostrarInfomacion();
                _Dg_Grid4.ClearSelection();
            }
        }

        private void aceptarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid3.Rows.Count > 0)
            {
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[9].Value = "0";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.White;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.White;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.White;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.White;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.FromArgb(192, 192, 255);
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.FromArgb(192, 192, 0);
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.White;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.White;
            }
        }

        private void aprobaciónTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid3.Rows.Count > 0)
            {
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[11].Value = "0";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[10].Value = "1";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[12].Value = "1";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.Yellow;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.Yellow;
                _Dg_Grid3.ClearSelection();
            }
        }

        private void aprobaciónConDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid3.Rows.Count > 0)
            {
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[10].Value = "0";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[11].Value = "1";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[12].Value = "1";
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[6].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[7].Style.BackColor = Color.YellowGreen;
                _Dg_Grid3.ClearSelection();
            }
        }

        private void aceptarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (_Dg_Grid3.Rows.Count > 0)
            //{
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[10].Value = "0";
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[11].Value = "0";
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.White;
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.White;
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.White;
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.White;
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[4].Style.BackColor = Color.FromArgb(192, 192, 255);
            //    _Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[5].Style.BackColor = Color.FromArgb(192, 192, 0);
            //}
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid4.Rows.Count > 0)
            {
                if (_Dg_Grid4.Rows[_Dg_Grid4.CurrentCell.RowIndex].Cells[8].Value.ToString().Trim() == "Sobrante")
                { toolStripMenuItem2.Enabled = true; toolStripMenuItem1.Enabled = true; aceptarTodoToolStripMenuItem.Enabled = true; }
                else
                { toolStripMenuItem2.Enabled = false; toolStripMenuItem1.Enabled = false; aceptarTodoToolStripMenuItem.Enabled = false; }
            }
        }

        private void _Bt_Imprimir2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "SELECT * FROM vst_facturacomparada WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Rec + "' and cproveedor='" + _Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                REPORTESS _Frm = new REPORTESS("T3.Report.rFactComparada2", _Ds.Tables[0], "Section1", "cabecera", "rif", "nit");
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
                Cursor = Cursors.Default;
                _Bt_Imprimir2.Enabled = false;
                if (!_Bt_Imprimir.Enabled)
                { this.Close(); }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid3.Rows.Count > 0)
            {
                if (_Dg_Grid3.Rows[_Dg_Grid3.CurrentCell.RowIndex].Cells[5].Value.ToString().Trim() == "Sobreprecio")
                { aprobaciónTotalToolStripMenuItem.Text = "Aceptar sin ND"; aprobaciónConDocumentoToolStripMenuItem.Text = "Aceptar con ND"; }
                else
                { aprobaciónTotalToolStripMenuItem.Text = "Aceptar sin NC"; aprobaciónConDocumentoToolStripMenuItem.Text = "Aceptar con NC"; }
            }
        }

        private void _Dg_Grid4_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_Dg4Info.Visible = true;
            }
            else
            {
                _Lbl_Dg4Info.Visible = false;
            }
        }

        private void _Dg_Grid3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgDifPrecioInfo.Visible = true;
            }
            else
            {
                _Lbl_DgDifPrecioInfo.Visible = false;
            }
        }

        private void _Txt_AceptarSolo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_AceptarSoloUni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}