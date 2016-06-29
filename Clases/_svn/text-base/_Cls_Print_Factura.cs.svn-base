using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace T3.Clases
{
    public enum TiposDocumentoImpresionVentas
    {
        Factura = 0,
        Comprobante, 
        GuiaDespacho
    }

    public class _Cls_Print_Factura
    {
        PrintDocument _My_Documento = new PrintDocument();
        PrintDialog _My_PrintDialogo = new PrintDialog();
        PrintPreviewDialog _My_PrintVista = new PrintPreviewDialog();
        string _Str_InfCliente = "";
        string _Str_Observaciones = "";
        string _Str_TotalCantidad = "0";
        string _Str_SubTotal = "0";
        string _Str_IVA = "0";
        string _Str_Total = "0";
        string _Str_Gcgroupcomp = "";
        string _Str_Gccompany = "";
        string _Str_Gcfactura = "";
        string _Str_Gccliente = "";
        string _Str_Gcpfactura = "";
        string _Str_Gpedido = "";
        string _Str_GFechaPedido = "";
        string _Str_GcondPago = "";
        string _Str_Gvendedor = "";
        string _Str_Galmacen = "";
        string _Str_GfechaFactura = "";
        string _Str_Gvencimiento = "";
        string _Str_Gfpago = "";
        string _Str_Grif = "";
        string _Str_Gnit = "";
        bool _Bol_G_PasePrintDialog = false;

        public _Cls_Print_Factura()
        {
            this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            _Bol_G_PasePrintDialog = false;
        }
        /// <summary>
        /// CONSTRUCTOR QUE SE LE PASA EL PrintDialog
        /// </summary>
        /// <param name="_Pr_Str_cgroupcomp"></param>
        /// <param name="_Pr_Str_ccompany"></param>
        /// <param name="_Pr_Str_cfactura"></param>
        /// <param name="_Pr_PrintDialog"></param>
        public _Cls_Print_Factura(string _Pr_Str_cgroupcomp, string _Pr_Str_ccompany, string _Pr_Str_cfactura, PrintDialog _Pr_PrintDialog)
        {
            this._My_PrintDialogo = _Pr_PrintDialog;
            this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            _Str_Gcgroupcomp = _Pr_Str_cgroupcomp;
            _Str_Gccompany = _Pr_Str_ccompany;
            _Str_Gcfactura = _Pr_Str_cfactura;
            _Str_Gccliente = this._Mtd_GetCliente();
            _Str_Gcpfactura = this._Mtd_GetPreFactura();
            _Mtd_CargarCliente(_Pr_Str_cgroupcomp, this._Str_Gccliente);
            _Str_Observaciones = "OBSERVACIONES: EL PRESENTE DOCUMENTO SE EMITE EN CUMPLIMIENTO DEL ARTICULO 11 DEL DECRETO LEY IVA\n";
            _Str_Observaciones = _Str_Observaciones + "UNA VEZ FIRMADA ESTA FACTURA NO SE ACEPTAN RECLAMOS.\n";
            _Str_Observaciones = _Str_Observaciones + "CHEQUE DEVUELTO PIERDE=P/PAGO(5%) + 3% DE COMISION";
            _Bol_G_PasePrintDialog = true;
        }
        /// <summary>
        /// CONSTRUCTOR QUE NO SE LE PASA EL PrintDialog
        /// </summary>
        /// <param name="_Pr_Str_cgroupcomp"></param>
        /// <param name="_Pr_Str_ccompany"></param>
        /// <param name="_Pr_Str_cfactura"></param>
        public _Cls_Print_Factura(string _Pr_Str_cgroupcomp, string _Pr_Str_ccompany, string _Pr_Str_cfactura)
        {
            this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            _Str_Gcgroupcomp = _Pr_Str_cgroupcomp;
            _Str_Gccompany = _Pr_Str_ccompany;
            _Str_Gcfactura = _Pr_Str_cfactura;
            _Str_Gccliente = this._Mtd_GetCliente();
            _Str_Gcpfactura = this._Mtd_GetPreFactura();
            _Mtd_CargarCliente(_Pr_Str_cgroupcomp, this._Str_Gccliente);
            _Str_Observaciones = "EL PRESENTE DOCUMENTO SE EMITE EN CUMPLIMIENTO DEL ARTICULO 11 DEL DECRETO LEY IVA\n";
            _Str_Observaciones = _Str_Observaciones + "UNA VEZ FIRMADA ESTA FACTURA NO SE ACEPTAN RECLAMOS.\n";
            _Str_Observaciones = _Str_Observaciones + "CHEQUE DEVUELTO PIERDE=P/PAGO(5%) + 3% DE COMISION";
            _Bol_G_PasePrintDialog = false;
        }

        public string _InfCliente
        {
            get { return _Str_InfCliente; }
            set { _Str_InfCliente = value; }
        }

        public string _Observaciones
        {
            get { return _Str_Observaciones; }
            set { _Str_Observaciones = value; }
        }

        public string _TotalCantidad
        {
            get { return _Str_TotalCantidad; }
            set { _Str_TotalCantidad = value; }
        }

        public string _SubTotal
        {
            get { return _Str_SubTotal; }
            set { _Str_SubTotal = value; }
        }

        public string _IVA
        {
            get { return _Str_IVA; }
            set { _Str_IVA = value; }
        }

        public string _Total
        {
            get { return _Str_Total; }
            set { _Str_Total = value; }
        }
        /// <summary>
        /// MANDA A IMPRIMIR LA FACTURA
        /// </summary>
        public void _Mtd_Imprimir()
        {
            if (_Bol_G_PasePrintDialog)
            {
                this._My_Documento.PrinterSettings = this._My_PrintDialogo.PrinterSettings;
                this._My_Documento.Print();
            }
            else
            {
                if (this._My_PrintDialogo.ShowDialog() == DialogResult.OK)
                {
                    this._My_Documento.PrinterSettings = this._My_PrintDialogo.PrinterSettings;
                    this._My_Documento.Print();
                }
            }
            
        }

        //public void _Mtd_Imprimir1()
        //{
        //    this._My_Documento.PrinterSettings = this._My_PrintDialogo.PrinterSettings;
        //    this._My_Documento.Print();
        //}
        /// <summary>
        /// MUESTRA UNA VISTA PREVIA DE LA FACTURA
        /// </summary>
        /// <param name="_Pr_Bol_ShowDialog"></param>
        public void _Mtd_Mostrar(bool _Pr_Bol_ShowDialog)
        {
            this._My_PrintVista.Document = this._My_Documento;
            this._My_PrintVista.Width = Screen.PrimaryScreen.Bounds.Width;
            this._My_PrintVista.Height = Screen.PrimaryScreen.Bounds.Height;
            if (_Pr_Bol_ShowDialog)
            {
                this._My_PrintVista.ShowDialog();
            }
            else
            { this._My_PrintVista.Show(); }
        }
        /// <summary>
        /// OBTIENE EL CODIGO DEL CLIENTE
        /// </summary>
        /// <returns></returns>
        private string _Mtd_GetCliente()
        {
            string _Str_R ="";
            string _Str_Sql = "SELECT ccliente FROM TFACTURAM WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cfactura='" + _Str_Gcfactura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }
        /// <summary>
        /// OBTIENE EL CODIGO DE LA PREFACTURA
        /// </summary>
        /// <returns></returns>
        private string _Mtd_GetPreFactura()
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cpfactura FROM TFACTURAM WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cfactura='" + _Str_Gcfactura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }
        /// <summary>
        /// CARGA LOS DATOS DEL CLLENTE A IMPRIMIR
        /// </summary>
        /// <param name="_Pr_Str_cgroupcomp"></param>
        /// <param name="_Pr_Str_ccliente"></param>
        public void _Mtd_CargarCliente(string _Pr_Str_cgroupcomp, string _Pr_Str_ccliente)
        {
            string _Str_Sql = "SELECT c_nomb_comer,c_razsocial_1,c_direcc_fiscal,c_rif,c_nit,c_telefono from TCLIENTE where cgroupcomp='" + _Str_Gcgroupcomp + "' and ccliente='" + _Str_Gccliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this._Str_InfCliente = Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim() + "\n";
                this._Str_InfCliente = this._Str_InfCliente + Convert.ToString(_Ds.Tables[0].Rows[0]["c_razsocial_1"]).Trim() + "\n";
                this._Str_InfCliente = this._Str_InfCliente + Convert.ToString(_Ds.Tables[0].Rows[0]["c_direcc_fiscal"]).Trim() + "\n";
                this._Str_InfCliente = this._Str_InfCliente + "TLF. " + Convert.ToString(_Ds.Tables[0].Rows[0]["c_telefono"]).Trim() + "\n";
                this._Str_InfCliente = this._Str_InfCliente + "RIF: " + Convert.ToString(_Ds.Tables[0].Rows[0]["c_rif"]).Trim() + "     NIT: " + Convert.ToString(_Ds.Tables[0].Rows[0]["c_nit"]).Trim();
            }
        }
        /// <summary>
        /// CARGA LOS DATOS DE LA CABECERA
        /// </summary>
        public void _Mtd_CargarCabecera()
        {
            string _Str_Sql = "SELECT cpedido,c_fecha_pedido from TPREFACTURAM where ccompany='" + _Str_Gccompany + "' and cpfactura='" + _Str_Gcpfactura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this._Str_Gpedido = Convert.ToString(_Ds.Tables[0].Rows[0]["cpedido"]);
                this._Str_GFechaPedido = Convert.ToString(_Ds.Tables[0].Rows[0]["c_fecha_pedido"]);
            }
            _Str_Sql = "SELECT cfpagoname,cvendedor,c_fecha_factura,cdias FROM VST_FACTURAM WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cfactura='" + _Str_Gcfactura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this._Str_Gfpago = Convert.ToString(_Ds.Tables[0].Rows[0]["cfpagoname"]);
                this._Str_Gvendedor = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]);
                this._Str_GfechaFactura = Convert.ToString(_Ds.Tables[0].Rows[0]["c_fecha_factura"]);
                this._Str_Gvencimiento = Convert.ToString(_Ds.Tables[0].Rows[0]["cdias"])+ " dias";
            }
        }

        private void _My_Documento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            double _Dbl_CostoNetoACobrar = 0;
            double _Dbl_CostoTotalConImpuesto = 0;
            double _Dbl_CostoTotalDescImp = 0;
            double _Dbl_CostoTotalDescuentos = 0;
            double _Dbl_CostoTotalSinDesImp = 0;
            double _Dbl_CostoTotalSinDescuentos = 0;
            double _Dbl_Total = 0;
            double _Dbl_MontoSimp = 0;
            double _Dbl_IVA = 0;
            int _Int_TotUnit = 0;
            int _Int_TotCaja = 0;
            double _Dbl_CostoNetoUnit = 0;
            double _Dbl_Porcen1 = 0;
            double _Dbl_Porcen2 = 0;
            double _Dbl_Tasa = 0;
            float _Fl_Y = 0;
            string _Str_Sql = "";
            string _Str_Descrip = "";
            
            DataSet _Ds;
            Graphics _My_Grafico = e.Graphics;
            _My_Grafico.PageUnit = GraphicsUnit.Millimeter;
            Font _My_Fuente = new Font("Arial", 7, FontStyle.Regular);//Times New Roman
            Font _My_Fuente2 = new Font("Arial", 6, FontStyle.Regular);//Times New Roman
            e.PageSettings.Margins.Top = 0;
            e.PageSettings.Margins.Left = 0;
            e.PageSettings.Margins.Right = 0;
            e.PageSettings.Margins.Bottom = 0;
            StringFormat _My_SfNear = StringFormat.GenericTypographic;
            StringFormat _My_SfFar = StringFormat.GenericTypographic;
            StringFormat _My_SfCenter = StringFormat.GenericTypographic;
            StringFormat _My_Sf = StringFormat.GenericTypographic;
            SizeF _My_Size = _My_Grafico.MeasureString("X", _My_Fuente, 1, _My_SfNear);
            
            RectangleF _My_RecCliente1 = new RectangleF(78, 2, 60, 22);
            RectangleF _My_RecCliente = new RectangleF(96, 2, 150, 22);
            RectangleF _My_RecObs = new RectangleF(3, 142, 107, 20);

            

            _My_SfNear.Alignment = StringAlignment.Near;
            _My_SfFar.Alignment = StringAlignment.Far;
            _My_SfCenter.Alignment = StringAlignment.Center;
//_My_SfCenter.SetTabStops()  DELIMITO CADA LINEA
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("VENDIDO A: ",_My_Fuente, Brushes.Black, _My_RecCliente1, _My_Sf);
            _My_Grafico.DrawString(this._Str_InfCliente, _My_Fuente, Brushes.Black, _My_RecCliente, _My_Sf);
            
            this._Mtd_CargarCabecera();

            _Fl_Y = 30;
            //_My_Grafico.DrawString("CLIENTE", _My_Fuente, Brushes.Black, new RectangleF(5, _Fl_Y, 16, 8), _My_Sf);
            _My_Grafico.DrawString("CLIENTE \n"+this._Str_Gccliente, _My_Fuente, Brushes.Black, new RectangleF(2, _Fl_Y, 16, 8), _My_Sf);
            _My_Grafico.DrawString("PEDIDO \n" + this._Str_Gpedido, _My_Fuente, Brushes.Black, new RectangleF(18, _Fl_Y, 15, 8), _My_Sf);
            _My_Grafico.DrawString("FECHA PEDIDO \n" + Convert.ToDateTime(this._Str_GFechaPedido).ToShortDateString(), _My_Fuente, Brushes.Black, new RectangleF(33, _Fl_Y, 25, 8), _My_Sf);
            _My_Grafico.DrawString("CONDICIÓN \n" + this._Str_Gfpago, _My_Fuente, Brushes.Black, new RectangleF(58, _Fl_Y, 15, 8), _My_Sf);
            _My_Grafico.DrawString("VENDEDOR \n" + this._Str_Gvendedor, _My_Fuente, Brushes.Black, new RectangleF(73, _Fl_Y, 16, 8), _My_Sf);
            _My_Grafico.DrawString("ALMACEN \n" + this._Str_Galmacen, _My_Fuente, Brushes.Black, new RectangleF(89, _Fl_Y, 17, 8), _My_Sf);

            _My_Grafico.DrawString("FACTURA \n" + this._Str_Gcfactura, _My_Fuente, Brushes.Black, new RectangleF(106, _Fl_Y, 25, 8), _My_Sf);
            _My_Grafico.DrawString("FECHA FACTURA \n" + Convert.ToDateTime(this._Str_GfechaFactura).ToShortDateString(), _My_Fuente, Brushes.Black, new RectangleF(131, _Fl_Y, 25, 8), _My_Sf);
            _My_Grafico.DrawString("VENCIMIENTO \n" + this._Str_Gfpago, _My_Fuente, Brushes.Black, new RectangleF(156, _Fl_Y, 27, 8), _My_Sf);


            _Fl_Y = 45;
            _My_Grafico.DrawString("CÓDIGO", _My_Fuente, Brushes.Black, new RectangleF(2, _Fl_Y, 16, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("DESCRIPCIÓN", _My_Fuente, Brushes.Black, new RectangleF(19, _Fl_Y, 80, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("PRESENTACIÓN", _My_Fuente, Brushes.Black, new RectangleF(88, _Fl_Y, 20, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString("CANTIDAD", _My_Fuente, Brushes.Black, new RectangleF(108, _Fl_Y, 20, _My_Size.Height), _My_Sf);
            //_My_Grafico.DrawString(_Drow["cunidades"].ToString(), _My_Fuente, Brushes.Black, new RectangleF(118, _Fl_Y, 8, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("PRECIO UNIT.", _My_Fuente, Brushes.Black, new RectangleF(125, _Fl_Y, 21, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("DESCUENTOS", _My_Fuente, Brushes.Black, new RectangleF(148, _Fl_Y, 20, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("MONTO Bs.", _My_Fuente, Brushes.Black, new RectangleF(170, _Fl_Y, 21, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("ALIC.%", _My_Fuente, Brushes.Black, new RectangleF(195, _Fl_Y, 15, _My_Size.Height), _My_Sf);

            _Fl_Y = 48;

            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", _My_Fuente, Brushes.Black, new RectangleF(2, _Fl_Y, 210, _My_Size.Height), _My_Sf);

            _Fl_Y = 52;
            _Str_Sql = "SELECT ccostodescImp,ccostosindescImp,ccostodescuento,ccostototalsindesc,cproducto,cpresentaciondescrip,cempaques,cunidades,ccostoneto_u1_bs,cdesc1,cdesc2,c_monto_si_bs,ctasa,produc_descrip,produc_descrip_2 from VST_FACTURAD where cgroupcomp='" + _Str_Gcgroupcomp + "' and ccompany='" + _Str_Gccompany + "' and cfactura='" + _Str_Gcfactura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                //if (_Fl_Y > 2000)
                //{ break; }
                _My_Sf.Alignment = StringAlignment.Near;
                _My_Grafico.DrawString(_Drow["cproducto"].ToString().Trim(), _My_Fuente, Brushes.Black, new RectangleF(2, _Fl_Y, 16, _My_Size.Height), _My_Sf);
                if (_Drow["produc_descrip"].ToString().Trim().Length > 45)
                {
                    _Str_Descrip = _Drow["produc_descrip"].ToString().Trim().Substring(0, 45);
                }
                else
                {
                    _Str_Descrip = _Drow["produc_descrip"].ToString().Trim();
                }
                _My_Grafico.DrawString(_Str_Descrip, _My_Fuente2, Brushes.Black, new RectangleF(19, _Fl_Y, 80, _My_Size.Height), _My_Sf);
                _My_Grafico.DrawString(_Drow["produc_descrip_2"].ToString(), _My_Fuente2, Brushes.Black, new RectangleF(99, _Fl_Y, 20, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_Drow["cempaques"].ToString(), _My_Fuente, Brushes.Black, new RectangleF(108, _Fl_Y, 7.9f, _My_Size.Height), _My_Sf);
                _My_Grafico.DrawString(_Drow["cunidades"].ToString(), _My_Fuente, Brushes.Black, new RectangleF(116, _Fl_Y, 8, _My_Size.Height), _My_Sf);
                if (Convert.ToString(_Drow["ccostoneto_u1_bs"]) != "")
                { _Dbl_CostoNetoUnit = Convert.ToDouble(_Drow["ccostoneto_u1_bs"]); }
                else
                { _Dbl_CostoNetoUnit = 0; }
                _My_Grafico.DrawString(_Dbl_CostoNetoUnit.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(125, _Fl_Y, 21, _My_Size.Height), _My_Sf);
                if (Convert.ToString(_Drow["cdesc1"]) != "")
                { _Dbl_Porcen1 = Convert.ToDouble(_Drow["cdesc1"]); }
                else
                { _Dbl_Porcen1 = 0; }
                _My_Grafico.DrawString(_Dbl_Porcen1.ToString("#,##0.00") + "%", _My_Fuente, Brushes.Black, new RectangleF(146, _Fl_Y, 11.9f, _My_Size.Height), _My_Sf);
                if (Convert.ToString(_Drow["cdesc2"]) != "")
                { _Dbl_Porcen2 = Convert.ToDouble(_Drow["cdesc2"]); }
                else
                { _Dbl_Porcen2 = 0; }
                _My_Grafico.DrawString(_Dbl_Porcen2.ToString("#,##0.00") + "%", _My_Fuente, Brushes.Black, new RectangleF(158, _Fl_Y, 12, _My_Size.Height), _My_Sf);

                if (Convert.ToString(_Drow["c_monto_si_bs"]) != "")
                { _Dbl_MontoSimp = Convert.ToDouble(_Drow["c_monto_si_bs"]); _Dbl_CostoTotalSinDescuentos += _Dbl_MontoSimp; }
                else
                { _Dbl_MontoSimp = 0; }
                _My_Grafico.DrawString(_Dbl_MontoSimp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(170, _Fl_Y, 21, _My_Size.Height), _My_Sf);

                if (Convert.ToString(_Drow["ctasa"]) != "")
                { _Dbl_Tasa = Convert.ToDouble(_Drow["ctasa"]); }
                else
                { _Dbl_Tasa = 0; }
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_Dbl_Tasa.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(194, _Fl_Y, 10, _My_Size.Height), _My_Sf);
                if (Convert.ToString(_Drow["ccostodescuento"]) != "")
                { _Dbl_CostoTotalDescuentos += Convert.ToDouble(_Drow["ccostodescuento"]); }
                if (Convert.ToString(_Drow["ccostosindescImp"]) != "")
                { _Dbl_CostoTotalSinDesImp += Convert.ToDouble(_Drow["ccostosindescImp"]); }
                if (Convert.ToString(_Drow["ccostodescImp"]) != "")
                { _Dbl_CostoTotalDescImp += Convert.ToDouble(_Drow["ccostodescImp"]); }
                _Fl_Y = _Fl_Y + _My_Size.Height + 1;
            }
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString(this._Str_Observaciones, _My_Fuente, Brushes.Black, _My_RecObs, _My_Sf);

            _Str_Sql = "SELECT SUM(cempaques) AS cempaques, SUM(cunidades) AS cunidades FROM VST_FACTURAD WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' and ccompany='" + _Str_Gccompany + "' and cfactura='" + _Str_Gcfactura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cempaques"]) != "")
                {
                    _Int_TotCaja = Convert.ToInt16(_Ds.Tables[0].Rows[0]["cempaques"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidades"]) != "")
                {
                    _Int_TotUnit = Convert.ToInt16(_Ds.Tables[0].Rows[0]["cunidades"]);
                }
            }
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", _My_Fuente, Brushes.Black, new RectangleF(110, 142, 150f, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(_Int_TotCaja.ToString(), _My_Fuente, Brushes.Black, new RectangleF(108, 146, 7.9f, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString(_Int_TotUnit.ToString(), _My_Fuente, Brushes.Black, new RectangleF(116, 146, 8, _My_Size.Height), _My_Sf);
            //_My_Grafico.DrawString(_Int_TotCaja.ToString() + " . " + _Int_TotUnit.ToString(), _My_Fuente, Brushes.Black, new RectangleF(116, 144, 19, _My_Size.Height), _My_Sf);
            string _Str_Fpago = "";
            _Str_Sql = "SELECT c_montotot_si_bs,c_impuesto_bs,cfpago FROM TFACTURAM WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cfactura='" + _Str_Gcfactura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_montotot_si_bs"]) != "")
                {
                    _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si_bs"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_impuesto_bs"]) != "")
                {
                    _Dbl_IVA = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto_bs"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfpago"]) != "")
                {
                    _Str_Fpago = Convert.ToString(_Ds.Tables[0].Rows[0]["cfpago"].ToString());
                }
            }
            _Dbl_Total = _Dbl_MontoSimp + _Dbl_IVA;
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("SUB-TOTAL Bs.", _My_Fuente, Brushes.Black, new RectangleF(148, 146, 36, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(_Dbl_MontoSimp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(168, 146, 36, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("I.V.A. " + _Dbl_Tasa.ToString("#,##0.00")+"%", _My_Fuente, Brushes.Black, new RectangleF(148, 151, 45, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(_Dbl_IVA.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(168, 151, 36, _My_Size.Height), _My_Sf);
            //_My_Grafico.DrawString(_Dbl_Tasa.ToString("#,##0.00") + "%", _My_Fuente, Brushes.Black, new RectangleF(153, 151, 15, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _Dbl_CostoTotalConImpuesto = _Dbl_IVA + _Dbl_MontoSimp;
            _My_Grafico.DrawString("TOTAL A PAGAR", _My_Fuente, Brushes.Black, new RectangleF(148, 156, 45, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(_Dbl_CostoTotalConImpuesto.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(168, 156, 36, _My_Size.Height), _My_Sf);
            //Descuentos

            double _Dbl_FormaPago = 0;
            if (_Str_Fpago.Length > 0)
            {
                _Str_Sql = "select cporcdes from TFPAGO WHERE cfpago='"+_Str_Fpago+"'";
                 _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                 if (_Ds.Tables[0].Rows.Count > 0)
                 {
                     if (Convert.ToString(_Ds.Tables[0].Rows[0]["cporcdes"]) != "")
                     {
                         _Dbl_FormaPago = Convert.ToDouble(Convert.ToString(_Ds.Tables[0].Rows[0]["cporcdes"]));
                     }
                 }
                 if (_Dbl_FormaPago > 0)
                 {
                     _My_Sf.Alignment = StringAlignment.Near;
                     _My_Grafico.DrawString("DESCUENTO CONTADO SOBRE", _My_Fuente, Brushes.Black, new RectangleF(3, 157, 50, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Far;
                     _My_Grafico.DrawString(_Dbl_CostoTotalConImpuesto.ToString("#,##0.00") + " -->", _My_Fuente, Brushes.Black, new RectangleF(35, 157, 36, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Near;
                     _My_Grafico.DrawString("DESCUENTO:", _My_Fuente, Brushes.Black, new RectangleF(73, 157, 36, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Far;
                     _Dbl_CostoTotalDescuentos = _Dbl_MontoSimp * (_Dbl_FormaPago / 100);
                     _My_Grafico.DrawString(_Dbl_CostoTotalDescuentos.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(90, 157, 36, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Near;
                     _My_Grafico.DrawString("IVA:" + _Dbl_Tasa.ToString("#,##0.00") + "%", _My_Fuente, Brushes.Black, new RectangleF(73, 162, 36, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Far;
                     _Dbl_CostoTotalDescImp = _Dbl_CostoTotalDescuentos * (_Dbl_Tasa / 100);
                     _My_Grafico.DrawString(_Dbl_CostoTotalDescImp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(90, 162, 36, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Near;
                     _Dbl_CostoTotalDescImp += _Dbl_CostoTotalDescuentos;
                     _My_Grafico.DrawString("TOTAL DESC:", _My_Fuente, Brushes.Black, new RectangleF(73, 167, 36, _My_Size.Height), _My_Sf);
                     _My_Sf.Alignment = StringAlignment.Far;
                     _My_Grafico.DrawString(_Dbl_CostoTotalDescImp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(90, 167, 36, _My_Size.Height), _My_Sf);
                 }
                 else
                 {
                     _Dbl_CostoTotalDescImp = 0;
                 }
                _My_Sf.Alignment = StringAlignment.Near;
                _My_Grafico.DrawString("NETO A PAGAR -->", _My_Fuente, Brushes.Black, new RectangleF(3, 167, 30, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _Dbl_CostoNetoACobrar = _Dbl_CostoTotalConImpuesto - _Dbl_CostoTotalDescImp;
                _My_Grafico.DrawString(_Dbl_CostoNetoACobrar.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(25, 167, 36, _My_Size.Height), _My_Sf);
                //RectangleF _My_RecObs = new RectangleF(3, 144, 107, 20);
            }
             _Fl_Y = 193;
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString(this._Str_InfCliente, _My_Fuente, Brushes.Black, new RectangleF(96, _Fl_Y, 150, 24), _My_Sf);
            _Fl_Y = 222;
            _My_Sf.Alignment = StringAlignment.Center;
            _My_Grafico.DrawString(this._Str_Gccliente, _My_Fuente, Brushes.Black, new RectangleF(3, _Fl_Y, 24, 5), _My_Sf);
            _My_Grafico.DrawString(this._Str_Gvendedor, _My_Fuente, Brushes.Black, new RectangleF(26, _Fl_Y, 15, 5), _My_Sf);
            //ALMACEN _My_Grafico.DrawString(this._Str_Galmacen, _My_Fuente, Brushes.Black, new RectangleF(46, _Fl_Y, 20, 5), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString(Convert.ToDateTime(this._Str_GfechaFactura).ToShortDateString(), _My_Fuente, Brushes.Black, new RectangleF(66, _Fl_Y, 30, 5), _My_Sf);
            _My_Grafico.DrawString(this._Str_Gfpago, _My_Fuente, Brushes.Black, new RectangleF(98, _Fl_Y, 30, 5), _My_Sf);
            _My_Grafico.DrawString(this._Str_Gcfactura, _My_Fuente, Brushes.Black, new RectangleF(129, _Fl_Y, 48, 5), _My_Sf);
            _Fl_Y = 230;
            _My_Sf.Alignment = StringAlignment.Center;
            _My_Grafico.DrawString(this._Str_Gcfactura, _My_Fuente, Brushes.Black, new RectangleF(3, _Fl_Y, 24, 5), _My_Sf);
            //_My_Sf.Alignment = StringAlignment.Far;
            _My_Sf.Alignment = StringAlignment.Center;
            _My_Grafico.DrawString(_Dbl_CostoTotalConImpuesto.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(26, _Fl_Y, 15, 5), _My_Sf);
        }
    }
}
