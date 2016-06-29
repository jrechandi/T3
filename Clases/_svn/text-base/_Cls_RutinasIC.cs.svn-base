using System.Data;
using System.Windows.Forms;

namespace T3.Clases
{
    public class _Cls_RutinasIc
    {

        /// <summary>
        /// Determina si un documento se encuentra previamente en una OP no anulada. Devuelve "" si no está. Devuelve el código de la OP si está.
        /// </summary>
        /// <param name="_P_Str_CodigoProveedor">Código del proveedor al que corresponde el documento</param>
        /// <param name="_P_Str_TipoDocumento">Tipo 'largo' de documento ic</param>
        /// <param name="_P_Str_NumeroDocumento">Número o código del documento</param>
        /// <returns>Vacio ("") en caso de que el documento no esté en en ninguna OP no anulada. Código de la OP en caso de que si esté.</returns>
        public static string _Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(string _P_Str_CodigoProveedor, string _P_Str_TipoDocumento, string _P_Str_NumeroDocumento)
        {
            string _Str_Sql = "";
            string _Str_Retornar = "";


            switch (_P_Str_TipoDocumento)
            {
                case "FACTURA CXC":
                case "NOTA DE DEBITO CXC":
                case "NOTA DE CREDITO CXC":
                case "AVISO DE COBRO CXC":

                    _Str_Sql += "SELECT     dbo.TPAGOSCXPM.cidordpago ";
                    _Str_Sql += "FROM       dbo.TPAGOSCXPM INNER JOIN dbo.TPAGOSCXCD ON dbo.TPAGOSCXPM.ccompany = dbo.TPAGOSCXCD.ccompany AND dbo.TPAGOSCXPM.cidordpago = dbo.TPAGOSCXCD.cidordpago ";
                    _Str_Sql += "WHERE     (dbo.TPAGOSCXPM.canulado = 0) AND (dbo.TPAGOSCXCD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TPAGOSCXCD.cnumdocu = '" + _P_Str_NumeroDocumento + "') ";

                    if (_P_Str_TipoDocumento == "FACTURA CXC") _Str_Sql += " AND (dbo.TPAGOSCXCD.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXC") _Str_Sql += " AND (dbo.TPAGOSCXCD.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXC") _Str_Sql += " AND (dbo.TPAGOSCXCD.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXC") _Str_Sql += " AND (dbo.TPAGOSCXCD.ctipodocument = 'AVISOCXC') ";

                    break;

                case "FACTURA CXP":
                case "NOTA DE DEBITO CXP":
                case "NOTA DE CREDITO CXP":
                case "NOTA DE CREDITO PROVEEDOR CXP":
                case "NOTA DE DEBITO PROVEEDOR CXP":
                case "AVISO DE COBRO CXP":
                
                    _Str_Sql = "";
                    _Str_Sql += "SELECT     dbo.TPAGOSCXPM.cidordpago ";
                    _Str_Sql += "FROM         dbo.TPAGOSCXPM INNER JOIN dbo.TPAGOSCXPD ON dbo.TPAGOSCXPM.ccompany = dbo.TPAGOSCXPD.ccompany AND dbo.TPAGOSCXPM.cidordpago = dbo.TPAGOSCXPD.cidordpago AND dbo.TPAGOSCXPM.cgroupcomp = dbo.TPAGOSCXPD.cgroupcomp AND dbo.TPAGOSCXPM.cproveedor = dbo.TPAGOSCXPD.cproveedor ";
                    _Str_Sql += "WHERE     (dbo.TPAGOSCXPM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TPAGOSCXPM.canulado = 0) AND (dbo.TPAGOSCXPD.cproveedor = '" + _P_Str_CodigoProveedor + "') AND (dbo.TPAGOSCXPD.cnumdocu = '" + _P_Str_NumeroDocumento + "') ";

                    if (_P_Str_TipoDocumento == "FACTURA CXP") _Str_Sql += " AND (dbo.TPAGOSCXPD.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXP") _Str_Sql += " AND (dbo.TPAGOSCXPD.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXP") _Str_Sql += " AND (dbo.TPAGOSCXPD.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO PROVEEDOR CXP") _Str_Sql += " AND (dbo.TPAGOSCXPD.ctipodocument = 'NCP') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO PROVEEDOR CXP") _Str_Sql += " AND (dbo.TPAGOSCXPD.ctipodocument = 'NDP') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXP") _Str_Sql += " AND (dbo.TPAGOSCXPD.ctipodocument = 'AVISOCXP') ";

                    break;
            }

            try
            {
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidordpago"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la OP
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return _Str_Retornar;
        }

        /// <summary>
        /// Determina si un documento se encuentra previamente en una cobranza intercompañía no rechazada. Devuelve "" si no está. Devuelve el código de la cobranza si está.
        /// </summary>
        /// <param name="_P_Str_CodigoProveedor">Código del proveedor al que corresponde el documento</param>
        /// <param name="_P_Str_TipoDocumento">Tipo 'largo' de documento ic</param>
        /// <param name="_P_Str_NumeroDocumento">Número o código del documento</param>
        /// <returns>Vacio ("") en caso de que el documento no esté en en ninguna cobranza no rechazada. Código de la cobranza en caso de que si esté.</returns>
        public static string _Mtd_DocumentoSeEncuentraCobranza(string _P_Str_CodigoProveedor, string _P_Str_TipoDocumento, string _P_Str_NumeroDocumento)
        {
            string _Str_Sql = "";
            string _Str_Retornar = "";


            switch (_P_Str_TipoDocumento)
            {
                case "FACTURA CXC":
                case "NOTA DE DEBITO CXC":
                case "NOTA DE CREDITO CXC":
                case "AVISO DE COBRO CXC":

                    _Str_Sql += "SELECT    dbo.TICCOBRAM.cidcobranzaic ";
                    _Str_Sql += "FROM      dbo.TICCOBRAM INNER JOIN dbo.TICCOBRAD_CXC ON dbo.TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXC.cidcobranzaic AND dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXC.ccompany ";
                    _Str_Sql += "WHERE    (dbo.TICCOBRAD_CXC.cnumdocu = " + _P_Str_NumeroDocumento + ")  AND (dbo.TICCOBRAD_CXC.ccompany = '" + Frm_Padre._Str_Comp + "')";

                    if (_P_Str_TipoDocumento == "FACTURA CXC") _Str_Sql += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXC") _Str_Sql += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXC") _Str_Sql += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXC") _Str_Sql += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'AVISOCXC') ";
                    break;

                case "FACTURA CXP":
                case "NOTA DE DEBITO CXP":
                case "NOTA DE CREDITO CXP":
                case "NOTA DE CREDITO PROVEEDOR CXP":
                case "NOTA DE DEBITO PROVEEDOR CXP":
                case "AVISO DE COBRO CXP":
                
                    _Str_Sql = "";
                    _Str_Sql += "SELECT    dbo.TICCOBRAM.cidcobranzaic ";
                    _Str_Sql += "FROM         dbo.TICCOBRAM INNER JOIN  dbo.TICCOBRAD_CXP ON dbo.TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXP.cidcobranzaic AND  dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXP.ccompany ";
                    _Str_Sql += "WHERE       (dbo.TICCOBRAD_CXP.cnumdocu = '" + _P_Str_NumeroDocumento + "') AND (dbo.TICCOBRAD_CXP.cproveedor = '" + _P_Str_CodigoProveedor + "') ";

                    if (_P_Str_TipoDocumento == "FACTURA CXP") _Str_Sql += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXP") _Str_Sql += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXP") _Str_Sql += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO PROVEEDOR CXP") _Str_Sql += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'NCP') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO PROVEEDOR CXP") _Str_Sql += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'NDP') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXP") _Str_Sql += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'AVISOCXP') ";

                    break;
            }

            try
            {
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidcobranzaic"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la cobranza
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return _Str_Retornar;
        }
        
        /// <summary>
        /// Indica que el proveedor se encuentra en una orden pago no anulada
        /// </summary>
        /// <param name="_P_Str_CodigoProveedor"></param>
        /// <returns></returns>
        public static string _Mtd_ProveedorSeEncuentraEnOrdenPagoNoAnulada(string _P_Str_CodigoProveedor)
        {
            string _Str_Sql = "";
            string _Str_Retornar = "";

            try
            {
                _Str_Sql += "SELECT dbo.TPAGOSCXPM.cidordpago ";
                _Str_Sql += "FROM   dbo.TPAGOSCXPM ";
                _Str_Sql += "WHERE  (dbo.TPAGOSCXPM.cproveedor = '" + _P_Str_CodigoProveedor + "') AND (dbo.TPAGOSCXPM.canulado = 0) AND (dbo.TPAGOSCXPM.ccompany = '" + Frm_Padre._Str_Comp + "') ";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidordpago"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la OP
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Str_Retornar;
        }

        /// <summary>
        /// Indica que el proveedor se encuentra en una cobranza
        /// </summary>
        /// <param name="_P_Str_CodigoProveedor"></param>
        /// <returns></returns>
        public static string _Mtd_ProveedorSeEncuentraCobranza(string _P_Str_CodigoProveedor)
        {
            string _Str_Sql = "";
            string _Str_Retornar = "";

            try
            {
                _Str_Sql += "SELECT dbo.TICCOBRAM.cidcobranzaic ";
                _Str_Sql += "FROM   dbo.TICCOBRAM INNER JOIN dbo.TICCOBRAD_CXC ON dbo.TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXC.cidcobranzaic AND dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXC.ccompany ";
                _Str_Sql += "WHERE  (dbo.TICCOBRAM.cproveedor = '" + _P_Str_CodigoProveedor + "') AND (dbo.TICCOBRAD_CXC.ccompany = '" + Frm_Padre._Str_Comp + "')";

                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidcobranzaic"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la cobranza
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Str_Retornar;
        }

        /// <summary>
        /// Indica si el cliente esta en algún documento de una Orden de Pago no anulada
        /// </summary>
        /// <param name="_P_Str_CodigoCliente"></param>
        /// <returns></returns>
        public static string _Mtd_ClienteSeEncuentraEnOrdenPagoNoAnulada(string _P_Str_CodigoCliente)
        {
            string _Str_Sql = "";
            string _Str_Retornar = "";

            try
            {
                _Str_Sql += "SELECT cidordpago ";
                _Str_Sql += "FROM   VST_DOCSCXCENORDENPAGO ";
                _Str_Sql += "WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (ccliente = '" + _P_Str_CodigoCliente + "') ";
                
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidordpago"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la OP
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return _Str_Retornar;
        }

        /// <summary>
        /// Indica si el cliente esta en algún documento de una Cobranza
        /// </summary>
        /// <param name="_P_Str_CodigoCliente"></param>
        /// <returns></returns>
        public static string _Mtd_ClienteSeEncuentraCobranza(string _P_Str_CodigoCliente)
        {
            string _Str_Sql = "";
            string _Str_Retornar = "";

            try
            {
                _Str_Sql += "SELECT cidcobranzaic ";
                _Str_Sql += "FROM  VST_DOCSCXCENCOBRANZA ";
                _Str_Sql += "WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (ccliente = '" + _P_Str_CodigoCliente + "') ";

                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidcobranzaic"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la cobranza
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Str_Retornar;
        }

    }
}
