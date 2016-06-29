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
    public partial class Frm_ASCII_FAC : Form
    {
        public Frm_ASCII_FAC()
        {
            InitializeComponent();
        }
        string _Str_FAC = "";
        string _Str_Rec = "";
        string _Str_Proveedor = "";
        string _Str_Fecha_Factura = "";
        string _Str_Comp;
        string _Str_NR = "";
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        public Frm_ASCII_FAC(string _P_Str_FAC, string _P_Str_Rec,string _P_Str_Proveedor)
        {
            InitializeComponent();
            _Str_FAC = _P_Str_FAC;
            _Str_Rec = _P_Str_Rec;
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Comp = _Mtd_CompProveedor(_Str_Proveedor);
            bool _Bol_Faltante = false;
            bool _Bol_Sobrante = false;
            string _Str_Cadena = "Select cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_asciifactura.cproducto) as cnamef,Emp1,Emp2,cdiferenciaemp,Und1,Und2,cdiferenciauni,cfaltante from vst_asciifactura where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cdelete='0' and cnfacturapro='" + _P_Str_FAC + "' and cproveedor='" + _Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Obj = new object[8];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Obj[0] = _Row[0].ToString();
                _Obj[1] = _Row[1].ToString();
                _Obj[2] = _Row["Emp1"].ToString();
                _Obj[3] = _Row["Und1"].ToString();
                _Obj[4] = _Row["Emp2"].ToString();
                _Obj[5] = _Row["Und2"].ToString();
                _Obj[6] = _Row["cdiferenciaemp"].ToString();
                _Obj[7] = _Row["cdiferenciauni"].ToString();
                _Dg_Grid4.Rows.Add(_Obj);
                if (_Row["cfaltante"].ToString() == "1")
                { _Bol_Faltante = true; }
                if (_Row["cfaltante"].ToString() == "2")
                { _Bol_Sobrante = true; }
            }
            //--------------------------------------
            _Str_Cadena = "Select cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where TPRODUCTO.cproducto=TRECEPCIONDDDFD.cproducto) as Nombre,cdiferenciaemp,cdiferenciauni,cfaltante from TRECEPCIONDDDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cnfacturapro='" + _P_Str_FAC + "' and cproveedor='" + _Str_Proveedor + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Obj = new object[8];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "Select * from vst_asciifactura where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cdelete='0' and cnfacturapro='" + _P_Str_FAC + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='"+_Row[0].ToString().Trim()+"'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                {
                    if (_Row[4].ToString() == "2")
                    {
                        _Obj[0] = _Row[0].ToString();
                        _Obj[1] = _Row[1].ToString();
                        _Obj[2] = "0";
                        _Obj[3] = "0";
                        _Obj[4] = _Row[2].ToString();
                        _Obj[5] = _Row[3].ToString();
                        _Obj[6] = _Row[2].ToString();
                        _Obj[7] = _Row[3].ToString();
                        _Dg_Grid4.Rows.Add(_Obj);
                        _Bol_Sobrante = true;
                    }
                    else
                    {
                        _Obj[0] = _Row[0].ToString();
                        _Obj[1] = _Row[1].ToString();
                        _Obj[2] = _Row[2].ToString();
                        _Obj[3] = _Row[3].ToString();
                        _Obj[4] = "0";
                        _Obj[5] = "0";
                        _Obj[6] = _Row[2].ToString();
                        _Obj[7] = _Row[3].ToString();
                        _Dg_Grid4.Rows.Add(_Obj);
                        _Bol_Faltante = true;
                    }
                }
            }
            //--------------------------------------
            if (_Bol_Faltante)
            { _Bt_ND.Enabled = true; }
            if (_Bol_Sobrante)
            { _Bt_NC.Enabled = true; }

            _Str_Cadena="Select cdatefactura from TRECEPCIONDFM where cgroupcomp='"+Frm_Padre._Str_GroupComp+"' and cidrecepcion='"+_P_Str_Rec+"' and cnfacturapro='"+_P_Str_FAC+"' and cproveedor='"+_Str_Proveedor+"'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Fecha_Factura = _Ds.Tables[0].Rows[0][0].ToString();
            }
            //----------------------------------------------------------------------
            _Str_Cadena = "Select DISTINCT cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_facturacomparada.cproducto) as cnamef,ccostobruto_u1,cpreciouni,cpreciodiferenc,cdiferenciaprec from vst_facturacomparada where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Rec + "' and cproveedor='" + _P_Str_Proveedor + "' and caprobadifpdocu='1'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Obj = new object[5];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Obj[0] = _Row[0].ToString();
                _Obj[1] = _Row[1].ToString();
                _Obj[2] = _Row[2].ToString();
                _Obj[3] = _Row[3].ToString();
                _Obj[4] = _Row[4].ToString();
                _Dg_Grid3.Rows.Add(_Obj);
                if (_Row[5].ToString() == "2")
                { _Bol_Faltante = true; }
                if (_Row[5].ToString() == "1")
                { _Bol_Sobrante = true; }
            }
            if (_Bol_Faltante)
            { _Bt_ND.Enabled = true; }
            if (_Bol_Sobrante)
            { _Bt_NC.Enabled = true; }

            //----------------------------------------------------------------------
        }
        private string _Mtd_CompProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "select DISTINCT ccompany from TGRUPPROVEE where cproveedor='" + _P_Str_Proveedor + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 1)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private void Frm_ASCII_FAC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {            
            string _Str_Cadena = "Select cnotarecepcion from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Rec + "' and cnfacturapro='" + _Str_FAC + "'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            Cursor = Cursors.WaitCursor;

            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("El proceso ya ha sido realizado","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        _Bt_Generar.Enabled = false;
                        _Mtd_NotaRecepcion(_Str_Proveedor, _Str_Rec, _Str_FAC, _Str_Fecha_Factura);
                    }
                    catch (Exception _Err)
                    {
                        switch (_Err.Message)
                        {
                            default:
                                MessageBox.Show("Disculpe, debe generar la nota de recepción desde la opción de notificaciones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                break;
                        }
                    }
                }
            }

            Cursor = Cursors.Default;
        }
        private bool _Mtd_Verificar_Facturas(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT DISTINCT cdate,cnfacturapro,cnotarecepcion,cidnotacreditocxp,cidnotadebitocxp from  vst_estatusgeneral where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Recepcion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            bool _Bol_Facturas = false;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                if (_Row[2].ToString() != "1")
                {
                    return false;
                }
                _Bol_Facturas = true;
            }
            if (!_Bol_Facturas)
            { return false; }
            else
            { return true; }
        }
        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Mtd_Verificar_Facturas(_Str_Rec))
            {
                _Dg_Grid4.Enabled = false;
                _Pnl_Clave.Visible = true;
            }
            else
            {
                MessageBox.Show("La recepción no puede ser cerrada","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            Cursor = Cursors.Default;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Dg_Grid4.Enabled = true;
            _Txt_Clave.Text = "";
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
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
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "ccerrada = '1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_Rec + "' and cproveedor='" + _Str_Proveedor + "'");
                    MessageBox.Show("La recepción fue cerrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Clave.Visible = false;
                    _Dg_Grid4.Enabled = true;
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Focus();
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    this.Close();
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch (Exception _Ex) { MessageBox.Show("Error al realizar la operación. \n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            Cursor = Cursors.Default;
        }
        private bool _Mtd_AplicaCostoActual(string _P_Str_Proveedor, string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Producto)
        {
            bool _Bol_R = false;
            string _Str_Sql = "SELECT cnumoc FROM TRECEPCIONDDDOCF WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproducto='" + _P_Str_Producto + "' AND cproveedor='" + _P_Str_Proveedor + "' AND caprobadifpsdocu=0 AND caprobadifpdocu=1";
            _Bol_R = Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
            return _Bol_R;
        }

        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public void _Mtd_NotaRecepcion(string _P_Str_Proveedor,string _P_Str_Recepcion,string _P_Str_Factura,string _P_Str_Fecha_Factura)
        {
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            string _Str_TD = "";
            string _Str_TNR = "";
            int _Int_IDM=_Mtd_Consecutivo_TNOTARECEPC();
            string _Str_Cadena="SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname "+
"FROM TDOCUMENT INNER JOIN "+
"TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentrp "+
"WHERE (TCONFIGCOMP.ccompany = '" + _Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TD = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "Select ctiponotreceprp from TCONFIGCOMP where ccompany='" + _Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TNR = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "SELECT cproducto,CNAMEF as cnamef,cempaques,cunidades,cpreciouni,cpresioprocarg,empfac,undfac,ccontenidoma1,ccontenidoma2,ccostoneto_u1,cdescuento1,ccostobrutolote,cprecioventamax,cpreciolista from vst_notaderecepcion where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and  cproveedor='" + _P_Str_Proveedor + "' and cdelete='0' and cidrecepcion='" + _P_Str_Recepcion + "' and cnfacturapro='" + _P_Str_Factura + "'";
            _Str_Cadena += " UNION ";
            _Str_Cadena += "SELECT cproducto,CNAMEF as cnamef,cempaques,cunidades,cpreciouni,cpresioprocarg,empfac,undfac,ccontenidoma1,ccontenidoma2,ccostoneto_u1,cdescuento1,ccostobrutolote,cprecioventamax,cpreciolista from VST_T3_RECEPCIONFALT where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and  cproveedor='" + _P_Str_Proveedor + "' and cdelete='0' and cidrecepcion='" + _P_Str_Recepcion + "' and cnfacturapro='" + _P_Str_Factura + "'"; 
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            double _Dbl_Monto_Sin_ImpuestoM = 0;
            double _Dbl_ImpuestoM = 0;
            double _Dbl_Total_Invendible = 0;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                double _Dbl_Monto_Sin_ImpuestoD = 0;
                double _Dbl_ImpuestoD = 0;
                try
                {
                    double _Dbl_Precio_Fac = 0;
                    double _Dbl_Emp_Fac = 0;
                    double _Dbl_Und_Fac = 0;
                    double _Dbl_Prec_Uni = 0;
                    double _Dbl_Descuento = 0;
                    if (_Row[6] != System.DBNull.Value)
                    { 
                        _Dbl_Emp_Fac = Convert.ToDouble(_Row[6].ToString()); 
                    }
                    if (_Row[7] != System.DBNull.Value)
                    {
                        _Dbl_Und_Fac = Convert.ToDouble(_Row[7].ToString());
                    }
                    if (_Row["cdescuento1"] != System.DBNull.Value)
                    {
                        _Dbl_Descuento = Convert.ToDouble(_Row["cdescuento1"].ToString());
                    }
                    if (_Mtd_AplicaCostoActual(_P_Str_Proveedor, _P_Str_Recepcion, _P_Str_Factura, _Row["cproducto"].ToString()))
                    {
                        int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                        int _Int_CantidadUni = (Convert.ToInt32(_Dbl_Emp_Fac) * (Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString()))) + Convert.ToInt32(_Dbl_Und_Fac);
                        string _Str_Sql = "SELECT CPRECOC FROM TRECEPCIONDDDOCF WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproducto='" + _Row["cproducto"].ToString() + "' AND cproveedor='" + _P_Str_Proveedor + "' AND caprobadifpsdocu=0 AND caprobadifpdocu=1";
                        DataSet _Ds_DataSet_= Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        foreach (DataRow _Dtw_Item in _Ds_DataSet_.Tables[0].Rows)
                        {
                            double _Dbl_CostoNeto2 = Convert.ToDouble(_Dtw_Item["cprecoc"].ToString()) / _Int_ContenidoU;
                            _Dbl_Precio_Fac = _Dbl_CostoNeto2 * _Int_CantidadUni;
                        }
                        _Dbl_Descuento = 0; //Se hizo esto por problema de diferencias en estadistico de compras segun ticket 18058 -- Ignacio --
                    }
                    else
                    {
                        if (_Row[5] != System.DBNull.Value)
                        {
                            _Dbl_Precio_Fac = Convert.ToDouble(_Row[5].ToString());
                        }
                    }

                    if (_Dbl_Emp_Fac != 0)
                    {
                        if (Convert.ToInt32(_Dbl_Emp_Fac) > 0)
                        {
                            if (_Dbl_Und_Fac != 0)
                            {
                                if (Convert.ToInt32(_Dbl_Und_Fac) > 0)
                                {
                                    int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                    int _Int_CantidadUni = (Convert.ToInt32(_Dbl_Emp_Fac) * (Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString()))) + Convert.ToInt32(_Dbl_Und_Fac);
                                    ///JUAN
                                    _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                    ///JUAN
                                    _Dbl_Prec_Uni = _Dbl_Precio_Fac / _Int_CantidadUni;
                                    //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) / _Int_CantidadUni;
                                    _Dbl_Prec_Uni = _Dbl_Prec_Uni * _Int_ContenidoU;
                                }
                                else
                                {
                                    if (_Dbl_Precio_Fac > 0 & _Dbl_Emp_Fac > 0)
                                    {
                                        ///JUAN
                                        _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                        ///JUAN
                                        _Dbl_Prec_Uni = _Dbl_Precio_Fac / _Dbl_Emp_Fac;
                                        //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) / Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value.ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (_Dbl_Precio_Fac > 0 & _Dbl_Emp_Fac > 0)
                                {
                                    ///JUAN
                                    _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                    ///JUAN
                                    _Dbl_Prec_Uni = _Dbl_Precio_Fac / _Dbl_Emp_Fac;
                                    //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) / Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (_Dbl_Und_Fac != 0)
                            {
                                if (Convert.ToInt32(_Dbl_Und_Fac) > 0)
                                {
                                    if (Convert.ToInt32(_Row["ccontenidoma2"].ToString()) > 0)
                                    {
                                        int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                        //_Dbl_Uni = _Dbl_Precio_Fac * _Int_ContenidoU;
                                        ///JUAN
                                        _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                        ///JUAN
                                        _Dbl_Prec_Uni = _Dbl_Precio_Fac * _Int_ContenidoU;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_Dbl_Und_Fac != 0)
                        {
                            if (_Dbl_Precio_Fac > 0)
                            {
                                if (Convert.ToInt32(_Row["ccontenidoma2"].ToString()) > 0)
                                {
                                    int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                    ///JUAN
                                    _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                    ///JUAN
                                    _Dbl_Prec_Uni = (_Dbl_Precio_Fac / _Dbl_Und_Fac) * _Int_ContenidoU;
                                    //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) * _Int_ContenidoU;
                                }
                            }
                        }
                    }
                    //_Dbl_Prec_Uni = _Dbl_Precio_Fac / _Dbl_Emp_Fac;
                    _Dbl_Monto_Sin_ImpuestoD = _Dbl_Prec_Uni * Convert.ToDouble(_Row[2].ToString());
                    if (_Row[3] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(_Row[3].ToString()) > 0)
                        {
                            if (_Row["ccontenidoma2"] != System.DBNull.Value)
                            {
                                if (Convert.ToInt32(_Row["ccontenidoma2"].ToString().Trim()) > 0)
                                {
                                    double _Dbl_Unidades = Convert.ToInt32(_Row["ccontenidoma1"].ToString().Trim()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString().Trim());
                                    if (_Dbl_Unidades > 0)
                                    {
                                        _Dbl_Monto_Sin_ImpuestoD += (_Dbl_Prec_Uni / _Dbl_Unidades) * Convert.ToDouble(_Row[3].ToString().Trim());
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    _Dbl_Monto_Sin_ImpuestoD = 0;
                }
                //-----------------------------
                _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where (cglobal='1' OR ccompany='" + _Str_Comp + "') AND cproveedor='" + _P_Str_Proveedor + "'";
                double _Dbl_Invendible = 0;
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_Invendible = Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim()); }
                }
                //-----------------------------
                _Dbl_Invendible = ((_Dbl_Monto_Sin_ImpuestoD * _Dbl_Invendible) / 100);
                _Dbl_Total_Invendible = _Dbl_Total_Invendible + _Dbl_Invendible;
                _Dbl_Monto_Sin_ImpuestoD = _Dbl_Monto_Sin_ImpuestoD - _Dbl_Invendible;
                _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        _Dbl_ImpuestoD = (_Dbl_Monto_Sin_ImpuestoD * Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                    }
                    catch { }
                }
                _Dbl_ImpuestoM = _Dbl_ImpuestoM + _Dbl_ImpuestoD;
                _Dbl_Monto_Sin_ImpuestoD = _Dbl_Monto_Sin_ImpuestoD + _Dbl_Invendible;
                _Dbl_Monto_Sin_ImpuestoM = _Dbl_Monto_Sin_ImpuestoM + _Dbl_Monto_Sin_ImpuestoD;


            }
            _Dbl_Total_Invendible = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_Total_Invendible, 2);
            _Str_Cadena = "SELECT cidnotrecepc FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Str_Comp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND CNUMDOCU='"+_P_Str_Factura+"'";
            DataSet _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_Temp.Tables[0].Rows.Count > 0)
            {
                _Int_IDM = Convert.ToInt32(_Ds_Temp.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                _Str_Cadena = "insert into TNOTARECEPC (cgroupcomp,ccompany,cidnotrecepc,cidrecepcion,ctiponotrecep,cfechanotrecep,ctipodocument,cnumdocu,cfechadocu,cmontosi,cmontoimp,cproveedor,cdateadd,cuseradd,cdelete,cporcinvendible,ctrg_cxp,ctrg_movinv) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _Str_Comp + "','" + _Int_IDM.ToString() + "','" + _P_Str_Recepcion + "','" + _Str_TNR + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_TD + "','" + _P_Str_Factura + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_P_Str_Fecha_Factura)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Sin_ImpuestoM) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoM) + "','" + _P_Str_Proveedor + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Total_Invendible) + "',1,1)";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            int _Int_IDD = 0;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                //int _Int_IDD=_Mtd_Consecutivo_TNOTARECEPD(_Int_IDM);
                _Int_IDD++;
                double _Dbl_Monto_Sin_ImpuestoD = 0;
                double _Dbl_ImpuestoD = 0;
                double _Dbl_ccostobrutolote = 0;
                double _Dbl_cprecioventamax = 0;
                double _Dbl_cpreciolista = 0;
                try
                {
                    double _Dbl_Precio_Fac = 0;
                    double _Dbl_Emp_Fac = 0;
                    double _Dbl_Und_Fac = 0;
                    double _Dbl_Prec_Uni = 0;
                    double _Dbl_Descuento = 0;
                    double.TryParse(Convert.ToString(_Row["ccostobrutolote"]).Trim(), out _Dbl_ccostobrutolote);
                    double.TryParse(Convert.ToString(_Row["cprecioventamax"]).Trim(), out _Dbl_cprecioventamax);
                    double.TryParse(Convert.ToString(_Row["cpreciolista"]).Trim(), out _Dbl_cpreciolista);
                    if (_Row[6] != System.DBNull.Value)
                    {
                        _Dbl_Emp_Fac = Convert.ToDouble(_Row[6].ToString());
                    }
                    if (_Row[7] != System.DBNull.Value)
                    {
                        _Dbl_Und_Fac = Convert.ToDouble(_Row[7].ToString());
                    }
                    if (_Row["cdescuento1"] != System.DBNull.Value)
                    {
                        _Dbl_Descuento = Convert.ToDouble(_Row["cdescuento1"].ToString());
                    }
                    if (_Mtd_AplicaCostoActual(_P_Str_Proveedor, _P_Str_Recepcion, _P_Str_Factura, _Row["cproducto"].ToString()))
                    {
                        int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                        int _Int_CantidadUni = (Convert.ToInt32(_Dbl_Emp_Fac) * (Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString()))) + Convert.ToInt32(_Dbl_Und_Fac);
                        string _Str_Sql = "SELECT CPRECOC FROM TRECEPCIONDDDOCF WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproducto='" + _Row["cproducto"].ToString() + "' AND cproveedor='" + _P_Str_Proveedor + "' AND caprobadifpsdocu=0 AND caprobadifpdocu=1";
                        DataSet _Ds_DataSet_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        foreach (DataRow _Dtw_Item in _Ds_DataSet_.Tables[0].Rows)
                        {
                            double _Dbl_CostoNeto2 = Convert.ToDouble(_Dtw_Item["cprecoc"].ToString()) / _Int_ContenidoU;
                            _Dbl_Precio_Fac = _Dbl_CostoNeto2 * _Int_CantidadUni;
                        }  
                    }
                    else
                    {
                        if (_Row[5] != System.DBNull.Value)
                        {
                            _Dbl_Precio_Fac = Convert.ToDouble(_Row[5].ToString());
                        }
                    }
                    if (_Dbl_Emp_Fac != 0)
                    {
                        if (Convert.ToInt32(_Dbl_Emp_Fac) > 0)
                        {
                            if (_Dbl_Und_Fac != 0)
                            {
                                if (Convert.ToInt32(_Dbl_Und_Fac) > 0)
                                {
                                    int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                    int _Int_CantidadUni = (Convert.ToInt32(_Dbl_Emp_Fac) * (Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString()))) + Convert.ToInt32(_Dbl_Und_Fac);
                                    ///JUAN
                                    _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                    ///JUAN
                                    _Dbl_Prec_Uni = _Dbl_Precio_Fac / _Int_CantidadUni;
                                    //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) / _Int_CantidadUni;
                                    _Dbl_Prec_Uni = _Dbl_Prec_Uni * _Int_ContenidoU;
                                }
                                else
                                {
                                    if (_Dbl_Precio_Fac > 0 & _Dbl_Emp_Fac > 0)
                                    {
                                        ///JUAN
                                        _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                        ///JUAN
                                        _Dbl_Prec_Uni = _Dbl_Precio_Fac / _Dbl_Emp_Fac;
                                        //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) / Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value.ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (_Dbl_Precio_Fac > 0 & _Dbl_Emp_Fac > 0)
                                {
                                    ///JUAN
                                    _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                    ///JUAN
                                    _Dbl_Prec_Uni = _Dbl_Precio_Fac / _Dbl_Emp_Fac;
                                    //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) / Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (_Dbl_Und_Fac != 0)
                            {
                                if (Convert.ToInt32(_Dbl_Und_Fac) > 0)
                                {
                                    if (Convert.ToInt32(_Row["ccontenidoma2"].ToString()) > 0)
                                    {
                                        int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                        //_Dbl_Uni = _Dbl_Precio_Fac * _Int_ContenidoU;
                                        ///JUAN
                                        _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                        ///JUAN
                                        _Dbl_Prec_Uni = _Dbl_Precio_Fac * _Int_ContenidoU;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_Dbl_Und_Fac != 0)
                        {
                            if (_Dbl_Precio_Fac > 0)
                            {
                                if (Convert.ToInt32(_Row["ccontenidoma2"].ToString()) > 0)
                                {
                                    int _Int_ContenidoU = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                    ///JUAN
                                    _Dbl_Precio_Fac = _Dbl_Precio_Fac - _Dbl_Descuento;
                                    ///JUAN
                                    _Dbl_Prec_Uni = (_Dbl_Precio_Fac / _Dbl_Und_Fac) * _Int_ContenidoU;
                                    //_Dbl_Uni = Convert.ToDouble(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value.ToString()) * _Int_ContenidoU;
                                }
                            }
                        }
                    }
                    //_Dbl_Prec_Uni = _Dbl_Precio_Fac / _Dbl_Emp_Fac;
                    //_Dbl_Monto_Sin_ImpuestoD = Convert.ToDouble(_Row[3].ToString()) * Convert.ToDouble(_Row[2].ToString()); 
                    _Dbl_Monto_Sin_ImpuestoD = _Dbl_Prec_Uni * Convert.ToDouble(_Row[2].ToString());
                    if (_Row[3] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(_Row[3].ToString()) > 0)
                        {
                            if (_Row["ccontenidoma2"] != System.DBNull.Value)
                            {
                                if (Convert.ToInt32(_Row["ccontenidoma2"].ToString().Trim()) > 0)
                                {
                                    double _Dbl_Unidades = Convert.ToInt32(_Row["ccontenidoma1"].ToString().Trim()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString().Trim());
                                    if (_Dbl_Unidades > 0)
                                    {
                                        _Dbl_Monto_Sin_ImpuestoD += (_Dbl_Prec_Uni / _Dbl_Unidades) * Convert.ToDouble(_Row[3].ToString().Trim());
                                    }
                                }
                            }
                        }
                    }
                }
                catch { _Dbl_Monto_Sin_ImpuestoD = 0; }
                //-----------------------------
                _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where (cglobal='1' OR ccompany='" + _Str_Comp + "') AND cproveedor='" + _P_Str_Proveedor + "'";
                double _Dbl_Invendible = 0;
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Dbl_Invendible=Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());}
                 }
                //-----------------------------
                _Dbl_Invendible = ((_Dbl_Monto_Sin_ImpuestoD * _Dbl_Invendible) / 100);
                _Dbl_Total_Invendible = _Dbl_Total_Invendible + _Dbl_Invendible;
                _Dbl_Monto_Sin_ImpuestoD = _Dbl_Monto_Sin_ImpuestoD - _Dbl_Invendible;
                _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        _Dbl_ImpuestoD = (_Dbl_Monto_Sin_ImpuestoD * Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                    }
                    catch { }
                }
                _Dbl_ImpuestoM = _Dbl_ImpuestoM + _Dbl_ImpuestoD;
                _Dbl_Monto_Sin_ImpuestoD = _Dbl_Monto_Sin_ImpuestoD + _Dbl_Invendible;
                _Dbl_Monto_Sin_ImpuestoM = _Dbl_Monto_Sin_ImpuestoM + _Dbl_Monto_Sin_ImpuestoD;
                _Str_Cadena = "SELECT CPRODUCTO FROM TNOTARECEPD WHERE CPRODUCTO='" + _Row[0].ToString() + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _Int_IDM.ToString() + "'";
                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_Temp.Tables[0].Rows.Count == 0)
                {
                    _Str_Cadena = "insert into TNOTARECEPD (cgroupcomp,ccompany,cidnotrecepc,ciddnotrecepc,cidrecepcion,cproducto,cempaques,cunidades,cmontosi,cmontoimp,cdateadd,cuseradd,cdelete,cporcinvendible,ccostobrutolote,cprecioventamax,cpreciolista) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _Str_Comp + "','" + _Int_IDM.ToString() + "','" + _Int_IDD.ToString() + "','" + _P_Str_Recepcion + "','" + _Row[0].ToString() + "','" + _Row[2].ToString() + "','" + _Row[3].ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_Monto_Sin_ImpuestoD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_ImpuestoD) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_cpreciolista) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            
            _Mtd_Actuaizar_NCyND(_Int_IDM);
            _Str_Cadena = "SELECT cproducto AS Producto, (SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=vst_mostrardettalledenotarecepcion.cproducto) AS Descripción, cempaques AS Cajas, cunidades AS Unidades,cmontosi AS Monto from vst_mostrardettalledenotarecepcion " +
"WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cproveedor = '" + _P_Str_Proveedor + "') AND (ccompany = '" + _Str_Comp + "') AND " +
"(cidnotrecepc = '" + _Int_IDM.ToString() + "') AND (cidrecepcion = '" + _P_Str_Recepcion + "') AND (cnumdocu='" + _P_Str_Factura + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONDFM", "cnotarecepcion='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Recepcion + "' and cnfacturapro='" + _P_Str_Factura + "'");
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "cnotarecepcion='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Recepcion + "' and cproveedor='" + _P_Str_Proveedor + "'");
                _Str_Cadena="Select cnumoc from TRECEPCIONRELDIF where cgroupcomp='"+Frm_Padre._Str_GroupComp+"' and cidrecepcion='"+_P_Str_Recepcion+"' and cnfacturapro='"+_P_Str_Factura+"'";
                DataSet _Ds7=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach(DataRow _Row7 in _Ds7.Tables[0].Rows)
                {
                    _Str_Cadena = "Select * from TORDENCOMPM where ccompany='" + _Str_Comp + "' and cnumoc='" + _Row7[0].ToString() + "' and cproveedor='" + _P_Str_Proveedor + "' AND (cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + _Str_Comp + "'))";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TORDENCOMPM", "centroinvent='1'", "ccompany='" + _Str_Comp + "' and cnumoc='" + _Row7[0].ToString() + "' and cproveedor='" + _P_Str_Proveedor + "'");
                    }
                }
                _Str_NR = _Int_IDM.ToString();
                if ((Frm_Padre)this.MdiParent != null) { System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default); }
                if (_Mtd_Verificar_Facturas(_Str_Rec))
                {
                    if (MessageBox.Show("Nota de recepción generada. ¿Desea cerrar la recepción?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        _Dg_Grid4.Enabled = false;
                        _Pnl_Clave.Visible = true;
                        this.ControlBox = true;
                        _Bt_Generar.Enabled = true;
                    }
                }
                else
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    MessageBox.Show("Nota de recepción generada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); 
                }
            }
        }
        private int _Mtd_Consecutivo_TNOTARECEPC()
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidnotrecepc FROM TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' ORDER BY cidnotrecepc  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
        private int _Mtd_Consecutivo_TNOTARECEPD(int _P_Int_IDM)
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ciddnotrecepc FROM TNOTARECEPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cidnotrecepc='" + _P_Int_IDM.ToString() + "' ORDER BY ciddnotrecepc  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
        private void _Mtd_Actuaizar_NCyND(int _P_Int_NR)
        {
            string _Str_Cadena = "SELECT TNOTACREDICP.cidnotacreditocxp " +
"FROM TNOTARECEPC INNER JOIN " +
"TNOTACREDICP ON TNOTARECEPC.cgroupcomp = TNOTACREDICP.cgroupcomp AND TNOTARECEPC.ccompany = TNOTACREDICP.ccompany AND " +
"TNOTARECEPC.cnumdocu = TNOTACREDICP.cnumdocu " +
"WHERE  (TNOTARECEPC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTARECEPC.ccompany = '" + _Str_Comp + "') AND (TNOTARECEPC.cidnotrecepc = '" + _P_Int_NR.ToString() + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "Update TNOTACREDICP Set cidnotrecepc='" + _P_Int_NR.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cidnotacreditocxp='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            _Str_Cadena = "SELECT TNOTADEBITOCP.cidnotadebitocxp " +
"FROM TNOTARECEPC INNER JOIN " +
"TNOTADEBITOCP ON TNOTARECEPC.cgroupcomp = TNOTADEBITOCP.cgroupcomp AND TNOTARECEPC.ccompany = TNOTADEBITOCP.ccompany AND " +
"TNOTARECEPC.cnumdocu = TNOTADEBITOCP.cnumdocu " +
"WHERE  (TNOTARECEPC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTARECEPC.ccompany = '" + _Str_Comp + "') AND (TNOTARECEPC.cidnotrecepc = '" + _P_Int_NR.ToString() + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "Update TNOTADEBITOCP Set cidnotrecepc='" + _P_Int_NR.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cidnotadebitocxp='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Txt_Clave.Focus(); _Pnl_Abajo.Enabled = false; _Dg_Grid4.Enabled = false; _Grp_Inferior.Enabled = false; }
            else
            { _Pnl_Abajo.Enabled = true; _Dg_Grid4.Enabled = true; _Grp_Inferior.Enabled = true; }
        }
        private void _Mtd_MostrarReporteDevolSica()
        {
            if (_Str_NR.Trim().Length > 0)
            {
                string _Str_Cadena = "SELECT cproducto FROM VST_DEVOLCOMPSICA WHERE ccompany='" + _Str_Comp + "' AND cidnotrecepc='" + _Str_NR + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("A continuación se mostrará el informe de devoluciones en compras (Rubros controlados por SICA) para su impresión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.WaitCursor;
                    Frm_Inf_DevolCompSica _Frm_DevolCompSica = new Frm_Inf_DevolCompSica(_Str_NR, _Str_Comp);
                    _Frm_DevolCompSica.MdiParent = this.MdiParent;
                    _Frm_DevolCompSica.Dock = DockStyle.Fill;
                    Cursor = Cursors.Default;
                    _Frm_DevolCompSica.Show();
                }
            }
        }
        private void _Mtd_MostrarReporteNotaRecepLote()
        {
            if (_Str_NR.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                Frm_Inf_NotaRecepLote _Frm_NotaRecepLote = new Frm_Inf_NotaRecepLote(_Str_NR, _Str_Comp);
                _Frm_NotaRecepLote.MdiParent = this.MdiParent;
                _Frm_NotaRecepLote.Dock = DockStyle.Fill;
                Cursor = Cursors.Default;
                _Frm_NotaRecepLote.Show();
            }
        }
        private void Frm_ASCII_FAC_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _Mtd_MostrarReporteNotaRecepLote();
                _Mtd_MostrarReporteDevolSica();
            }
            catch(Exception Ex)
            { MessageBox.Show("Problemas para imprimir el reporte. Puede imprimir el reporte desde el menú principal del sistema.\n" + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}