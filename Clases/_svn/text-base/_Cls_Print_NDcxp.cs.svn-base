using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;

namespace T3.Clases
{
    public class _Cls_Print_NDcxp
    {
        DataSet _G_Ds_Detalle;
        bool _Bol_G_PasePrintDialog = false;
        double _G_Dbl_Cajas = 0;
        double _G_Dbl_Unidades = 0;
        double _G_Dbl_BaseGrabada = 0;
        double _G_Dbl_BaseExcenta = 0;
        double _G_Dbl_Invendible = 0;
        double _G_Dbl_Impuesto = 0;
        double _G_Dbl_MontoTotal = 0;
        string _Str_Gcgroupcomp = "";
        string _Str_Gccompany = "";
        string _Str_G_ND = "";
        string _Str_G_proveedor = "";
        Single _MyAreaHeight = 0;
        PrintDocument _My_Documento = new PrintDocument();
        PrintDialog _My_PrintDialogo = new PrintDialog();
        PrintPreviewDialog _My_PrintVista = new PrintPreviewDialog();
        public _Cls_Print_NDcxp()
        {
            this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            _Bol_G_PasePrintDialog = false;
        }
        public _Cls_Print_NDcxp(string _Pr_Str_cgroupcomp, string _Pr_Str_ccompany, string _Pr_Str_ND, PrintDialog _Pr_PrintDialog)
        {
            _Str_Gcgroupcomp = _Pr_Str_cgroupcomp;
            _Str_Gccompany = _Pr_Str_ccompany;
            _Str_G_ND = _Pr_Str_ND;
            this._My_PrintDialogo = _Pr_PrintDialog;
            //PaperSize _My_Papel = new PaperSize("Carta_Mitad", 850, 510);
            
            //this._My_PrintDialogo.PrinterSettings.DefaultPageSettings.PaperSize = _My_Papel;
            
            
            string _Str_Sql = "SELECT cproducto FROM TNOTADEBITOCPD WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp=" + _Str_G_ND;
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPageDetallado);
                _Str_Sql = "SELECT * FROM TNOTADEBITOCPD WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp=" + _Str_G_ND + "";
                _G_Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            }
            else
            {
                this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            }
            
            
            _Str_G_proveedor = this._Field_IdProveedor;
            _Bol_G_PasePrintDialog = true;
        }
        public string _Field_IdProveedor
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT cproveedor FROM TNOTADEBITOCP WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp='" + _Str_G_ND + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
                return _Str_R;
            }
        }
        public string _Field_Rif
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT c_rif FROM TPROVEEDOR WHERE (ccompany='" + _Str_Gccompany + "' OR cglobal=1) AND cproveedor='" + _Str_G_proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
                }
                return _Str_R;
            }
        }
        public string _Field_ProveedorNameFiscal
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT c_nomb_fiscal FROM TPROVEEDOR WHERE (ccompany='" + _Str_Gccompany + "' OR cglobal=1) AND cproveedor='" + _Str_G_proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
                }
                return _Str_R;
            }
        }
        public string _Field_DirecFiscal
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT c_direcc_fiscal FROM TPROVEEDOR WHERE (ccompany='" + _Str_Gccompany + "' OR cglobal=1) AND cproveedor='" + _Str_G_proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
                }
                return _Str_R;
            }
        }
        public string _Field_Concepto
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT cdescripcion FROM TNOTADEBITOCP WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp='" + this._Str_G_ND + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
                }
                return _Str_R;
            }
        }
        public double _Field_MontoSimp
        {
            get
            {
                double _Dbl_R = 0;
                string _Str_Sql = "SELECT cmontototsi FROM TNOTADEBITOCP WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp='" + this._Str_G_ND + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                return _Dbl_R;
            }
        }
        public double _Field_MontoImp
        {
            get
            {
                double _Dbl_R = 0;
                string _Str_Sql = "SELECT cimpuesto FROM TNOTADEBITOCP WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp='" + this._Str_G_ND + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                return _Dbl_R;
            }
        }
        public double _Field_MontoInvendible
        {
            get
            {
                double _Dbl_R = 0;
                string _Str_Sql = "SELECT cporcinvendible FROM TNOTADEBITOCP WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp='" + this._Str_G_ND + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                return _Dbl_R;
            }
        }
        public double _Field_MontoTotal
        {
            get
            {
                double _Dbl_R = 0;
                string _Str_Sql = "SELECT ctotaldocu FROM TNOTADEBITOCP WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotadebitocxp='" + this._Str_G_ND + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                return _Dbl_R;
            }
        }
        public string _Field_Titulo
        {
            get
            {
                string _Str_R = "NOTA DE DÉBITO N# " + _Str_G_ND;
                return _Str_R;
            }
        }
        private void _My_Documento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float _Fl_Linea = 0;
            float _Fl_Y = 0;
            e.PageSettings.PaperSize = new PaperSize("Carta_Mitad", 850, 550);
            Graphics _My_Grafico = e.Graphics;
            _My_Grafico.PageUnit = GraphicsUnit.Millimeter;
            Font _My_Fuente = new Font("Verdana", 7, FontStyle.Regular);
            e.PageSettings.Margins.Top = 0;
            e.PageSettings.Margins.Left = 0;
            e.PageSettings.Margins.Right = 0;
            e.PageSettings.Margins.Bottom = 0;
            StringFormat _My_Sf = StringFormat.GenericTypographic;
            SizeF _My_Size = _My_Grafico.MeasureString("X", _My_Fuente, 1, _My_Sf);
            _Fl_Y = 30;
            RectangleF _My_RecCabecera = new RectangleF(65, _Fl_Y, 80, _My_Size.Height);
            RectangleF _My_RecFecha = new RectangleF(160, _Fl_Y, 50, _My_Size.Height);
            _Fl_Y = _Fl_Y + 10;
            RectangleF _My_RecProveedorName = new RectangleF(10, _Fl_Y, 180, _My_Size.Height);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            RectangleF _My_RecProveedorDirFis = new RectangleF(10, _Fl_Y, 180, _My_Size.Height);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            RectangleF _My_RecRif = new RectangleF(10, _Fl_Y, 150, _My_Size.Height);

            _My_Sf.Alignment = StringAlignment.Center;
            _My_Grafico.DrawString(this._Field_Titulo, _My_Fuente, Brushes.Black, _My_RecCabecera, _My_Sf);
            _My_Grafico.DrawString("Fecha: " + DateTime.Now.Date.ToShortDateString(), _My_Fuente, Brushes.Black, _My_RecFecha, _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("Cliente: " + this._Field_ProveedorNameFiscal, _My_Fuente, Brushes.Black, _My_RecProveedorName, _My_Sf);
            string _Str_DirecFiscal = this._Field_DirecFiscal;
            if (_Str_DirecFiscal.Length > 100)
            {
                _Str_DirecFiscal = _Str_DirecFiscal.Substring(0, 100);
            }
            _My_Grafico.DrawString("Dirección fiscal: " + _Str_DirecFiscal, _My_Fuente, Brushes.Black, _My_RecProveedorDirFis, _My_Sf);
            _My_Grafico.DrawString("Rif: " + this._Field_Rif, _My_Fuente, Brushes.Black, _My_RecRif, _My_Sf);
            _Fl_Y = _Fl_Y + 10;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 10, _Fl_Y, 203, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 10, _Fl_Y, 203, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("Concepto", _My_Fuente, Brushes.Black, new RectangleF(10, _Fl_Y, 90, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString("Monto(Bs.F.)", _My_Fuente, Brushes.Black, new RectangleF(101, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Invendible", _My_Fuente, Brushes.Black, new RectangleF(127, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Impuesto", _My_Fuente, Brushes.Black, new RectangleF(153, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Monto total", _My_Fuente, Brushes.Black, new RectangleF(178, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _Fl_Y = _Fl_Y + 4;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 10, _Fl_Y, 203, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 10, _Fl_Y, 203, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Sf.Alignment = StringAlignment.Near;
            string _Str_Concepto = this._Field_Concepto;
            float _Fl_LongConcepto = 100;
            Int32 _Int_NumLinea = 1;
            if (_My_Grafico.MeasureString(_Str_Concepto, _My_Fuente).Width > _Fl_LongConcepto)
            {
                _Fl_Linea = _My_Grafico.MeasureString(_Str_Concepto, _My_Fuente).Width / _Fl_LongConcepto;
            }
            if (Math.Floor(_Fl_Linea) < _Fl_Linea)
            {
                _Int_NumLinea = Convert.ToInt32(Math.Floor(_Fl_Linea)) + 2;
            }
            _My_Grafico.DrawString(_Str_Concepto, _My_Fuente, Brushes.Black, new RectangleF(10, _Fl_Y, 90, (_My_Size.Height * _Int_NumLinea)), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoSimp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(101, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoInvendible.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(127, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoImp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(153, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoTotal.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(178, _Fl_Y, 25, _My_Size.Height), _My_Sf);
        }
        private void _My_Documento_PrintPageDetallado(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PaperSize _My_Papel = new PaperSize("Carta_Mitad", 850, 510);
            string _Str_Impresora = this._My_PrintDialogo.PrinterSettings.PrinterName;
            string _Str_Sql = "";
            float _Fl_Linea = 0;
            float _Fl_Y = 0;
            
            Graphics _My_Grafico = e.Graphics;

            e.PageSettings.PrinterSettings.PrinterName = _Str_Impresora;
            e.PageSettings.PaperSize = _My_Papel;
            
            _My_Grafico.PageUnit = GraphicsUnit.Millimeter;
            
            Font _My_Fuente = new Font("Verdana", 7, FontStyle.Regular);
            e.PageSettings.Margins.Top = 0;
            e.PageSettings.Margins.Left = 0;
            e.PageSettings.Margins.Right = 0;
            e.PageSettings.Margins.Bottom = 30;
            

            _MyAreaHeight = (e.PageSettings.PaperSize.Height - (e.PageSettings.Margins.Top + e.PageSettings.Margins.Bottom));
        
            StringFormat _My_Sf = StringFormat.GenericTypographic;
            SizeF _My_Size = _My_Grafico.MeasureString("X", _My_Fuente, 1, _My_Sf);
        
            _Fl_Y = 30;
            RectangleF _My_RecCabecera = new RectangleF(65, _Fl_Y, 80, _My_Size.Height);
            RectangleF _My_RecFecha = new RectangleF(160, _Fl_Y, 50, _My_Size.Height);
            _Fl_Y = _Fl_Y + 10;
            RectangleF _My_RecProveedorName = new RectangleF(10, _Fl_Y, 180, _My_Size.Height);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            RectangleF _My_RecProveedorDirFis = new RectangleF(10, _Fl_Y, 180, _My_Size.Height);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            RectangleF _My_RecRif = new RectangleF(10, _Fl_Y, 150, _My_Size.Height);

            _My_Sf.Alignment = StringAlignment.Center;
            _My_Grafico.DrawString(this._Field_Titulo, _My_Fuente, Brushes.Black, _My_RecCabecera, _My_Sf);
            _My_Grafico.DrawString("Fecha: " + DateTime.Now.Date.ToShortDateString(), _My_Fuente, Brushes.Black, _My_RecFecha, _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("Cliente: " + this._Field_ProveedorNameFiscal, _My_Fuente, Brushes.Black, _My_RecProveedorName, _My_Sf);
            string _Str_DirecFiscal = this._Field_DirecFiscal;
            if (_Str_DirecFiscal.Length > 100)
            {
                _Str_DirecFiscal = _Str_DirecFiscal.Substring(0, 100);
            }
            _My_Grafico.DrawString("Dirección fiscal: " + _Str_DirecFiscal, _My_Fuente, Brushes.Black, _My_RecProveedorDirFis, _My_Sf);
            _My_Grafico.DrawString("Rif: " + this._Field_Rif, _My_Fuente, Brushes.Black, _My_RecRif, _My_Sf);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            _My_Grafico.DrawString("Concepto: " + this._Field_Concepto, _My_Fuente, Brushes.Black, new RectangleF(10,_Fl_Y,180,_My_Size.Height), _My_Sf);
            _Fl_Y = _Fl_Y + 5;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 5, _Fl_Y, 210, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 5, _Fl_Y, 210, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("Código", _My_Fuente, Brushes.Black, new RectangleF(5, _Fl_Y, 20, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Descripción", _My_Fuente, Brushes.Black, new RectangleF(26, _Fl_Y, 55, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString("Cajas", _My_Fuente, Brushes.Black, new RectangleF(82, _Fl_Y, 12, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Unidades", _My_Fuente, Brushes.Black, new RectangleF(95, _Fl_Y, 12, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Base grabada", _My_Fuente, Brushes.Black, new RectangleF(108, _Fl_Y, 16, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Base exenta", _My_Fuente, Brushes.Black, new RectangleF(125, _Fl_Y, 16, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString("Invendible", _My_Fuente, Brushes.Black, new RectangleF(142, _Fl_Y, 15, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Impuesto", _My_Fuente, Brushes.Black, new RectangleF(158, _Fl_Y, 18, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("%Alic.", _My_Fuente, Brushes.Black, new RectangleF(177, _Fl_Y, 10, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString("Monto Total", _My_Fuente, Brushes.Black, new RectangleF(188, _Fl_Y, 19, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _Fl_Y = _Fl_Y + 4;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 5, _Fl_Y, 210, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 5, _Fl_Y, 210, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Sf.Alignment = StringAlignment.Near;
            DataSet _Ds_A;
            float _Fl_LongConcepto = 64;
            string _Str_DescripProducto = "";
            Int32 _Int_NumLinea = 1;
            float _Fl_Y_Temp = 0;
            
            for (int _I = 0; _I < _G_Ds_Detalle.Tables[0].Rows.Count; _I++)
            {
                if ((_Fl_Y*4.0f) < _MyAreaHeight)
                {
                    DataRow _Drow = _G_Ds_Detalle.Tables[0].Rows[_I];
                    _Fl_Y_Temp = 0; _Fl_Linea = 1; _Int_NumLinea = 0; _Str_DescripProducto = "";
                    _My_Sf.Alignment = StringAlignment.Near;
                    _My_Grafico.DrawString(_Drow["cproducto"].ToString().Trim(), _My_Fuente, Brushes.Black, new RectangleF(5, _Fl_Y, 20, _My_Size.Height), _My_Sf);
                    _Str_Sql = "SELECT RTRIM(produc_descrip) + ' ' + RTRIM(produc_descrip_2) FROM VST_PRODUCTOS WHERE cproducto='" + _Drow["cproducto"].ToString().Trim() + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_DescripProducto = _Ds_A.Tables[0].Rows[0][0].ToString();
                        if (_My_Grafico.MeasureString(_Str_DescripProducto, _My_Fuente).Width > _Fl_LongConcepto)
                        {
                            _Fl_Linea = _My_Grafico.MeasureString(_Str_DescripProducto, _My_Fuente).Width / _Fl_LongConcepto;
                        }
                        else
                        {
                            _Fl_Linea = 1;
                        }
                        if (Math.Floor(_Fl_Linea) < _Fl_Linea)
                        {
                            _Int_NumLinea = Convert.ToInt32(Math.Floor(_Fl_Linea)) + 2;
                        }
                        else
                        {
                            _Int_NumLinea = Convert.ToInt32(Math.Floor(_Fl_Linea)) + 1;
                        }
                        _My_Sf.Alignment = StringAlignment.Near;
                        _My_Grafico.DrawString(_Str_DescripProducto, _My_Fuente, Brushes.Black, new RectangleF(26, _Fl_Y, 55, (_My_Size.Height * _Int_NumLinea)), _My_Sf);
                        _Fl_Y_Temp = (_My_Size.Height * (_Int_NumLinea - 1));
                    }
                    else
                    {
                        _Fl_Y_Temp = _My_Size.Height;
                    }
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["ccajas"]).ToString("#,##0"), _My_Fuente, Brushes.Black, new RectangleF(82, _Fl_Y, 13, _My_Size.Height), _My_Sf);
                    _G_Dbl_Cajas = _G_Dbl_Cajas + Convert.ToDouble(_Drow["ccajas"]);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["cunidades"]).ToString("#,##0"), _My_Fuente, Brushes.Black, new RectangleF(95, _Fl_Y, 13, _My_Size.Height), _My_Sf);
                    _G_Dbl_Unidades = _G_Dbl_Unidades + Convert.ToDouble(_Drow["cunidades"]);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["cbasegrabada"]).ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(108, _Fl_Y, 16, _My_Size.Height), _My_Sf);
                    _G_Dbl_BaseGrabada = _G_Dbl_BaseGrabada + Convert.ToDouble(_Drow["cbasegrabada"]);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["cbasexcenta"]).ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(125, _Fl_Y, 16, _My_Size.Height), _My_Sf);
                    _G_Dbl_BaseExcenta = _G_Dbl_BaseExcenta + Convert.ToDouble(_Drow["cbasexcenta"]);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["cmontoinvendi"]).ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(142, _Fl_Y, 15, _My_Size.Height), _My_Sf);
                    _G_Dbl_Invendible = _G_Dbl_Invendible + Convert.ToDouble(_Drow["cmontoinvendi"]);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["cimpuesto"]).ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(158, _Fl_Y, 18, _My_Size.Height), _My_Sf);
                    _G_Dbl_Impuesto = _G_Dbl_Impuesto + Convert.ToDouble(_Drow["cimpuesto"]);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(_Drow["calicuota"].ToString(), _My_Fuente, Brushes.Black, new RectangleF(177, _Fl_Y, 10, _My_Size.Height), _My_Sf);
                    _My_Sf.Alignment = StringAlignment.Far;
                    _My_Grafico.DrawString(Convert.ToDouble(_Drow["cmontototal"]).ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(188, _Fl_Y, 19, _My_Size.Height), _My_Sf);
                    _G_Dbl_MontoTotal = _G_Dbl_MontoTotal + Convert.ToDouble(_Drow["cmontototal"]);
                    _G_Ds_Detalle.Tables[0].Rows.Remove(_Drow);
                    _G_Ds_Detalle.AcceptChanges();
                    _I--;
                }
                
                _Fl_Y = _Fl_Y + _Fl_Y_Temp + 1;
                if ((_Fl_Y*4.0f) > _MyAreaHeight)
                {
                    //_Fl_Y = 0;
                    //_My_Grafico.Dispose();
                    e.HasMorePages = true;
                    //goto _Goto_Inicio;
                }
            }
            //ESTABLESCO LOS TOTALES
            if ((_Fl_Y * 4.0f) < _MyAreaHeight)
            {
                _My_Grafico.DrawLine(new Pen(Color.Black, 0.2f), 82, _Fl_Y, 210, _Fl_Y);
                _Fl_Y++;
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_Cajas.ToString("#,##0"), _My_Fuente, Brushes.Black, new RectangleF(82, _Fl_Y, 13, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_Unidades.ToString("#,##0"), _My_Fuente, Brushes.Black, new RectangleF(95, _Fl_Y, 13, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_BaseGrabada.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(108, _Fl_Y, 16, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_BaseExcenta.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(125, _Fl_Y, 16, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_Invendible.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(142, _Fl_Y, 15, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_Impuesto.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(158, _Fl_Y, 18, _My_Size.Height), _My_Sf);
                //_My_Sf.Alignment = StringAlignment.Far;
                //_My_Grafico.DrawString(_Drow["calicuota"].ToString(), _My_Fuente, Brushes.Black, new RectangleF(179, _Fl_Y, 10, _My_Size.Height), _My_Sf);
                _My_Sf.Alignment = StringAlignment.Far;
                _My_Grafico.DrawString(_G_Dbl_MontoTotal.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(188, _Fl_Y, 19, _My_Size.Height), _My_Sf);
            }
        }
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
    }
}

