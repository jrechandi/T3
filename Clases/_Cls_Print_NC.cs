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
    public class _Cls_Print_NC
    {
        bool _Bol_G_PasePrintDialog = false;
        string _Str_Gcgroupcomp = "";
        string _Str_Gccompany = "";
        string _Str_G_NC = "";
        string _Str_Gccliente = "";
        PrintDocument _My_Documento = new PrintDocument();
        PrintDialog _My_PrintDialogo = new PrintDialog();
        PrintPreviewDialog _My_PrintVista = new PrintPreviewDialog();
        public _Cls_Print_NC()
        {
            this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            _Bol_G_PasePrintDialog = false;
        }
        public _Cls_Print_NC(string _Pr_Str_cgroupcomp, string _Pr_Str_ccompany, string _Pr_Str_NC, PrintDialog _Pr_PrintDialog)
        {
            this._My_PrintDialogo = _Pr_PrintDialog;
            this._My_Documento.PrintPage += new PrintPageEventHandler(_My_Documento_PrintPage);
            _Str_Gcgroupcomp = _Pr_Str_cgroupcomp;
            _Str_Gccompany = _Pr_Str_ccompany;
            _Str_G_NC = _Pr_Str_NC;
            _Str_Gccliente = this._Field_IdCliente;
            _Bol_G_PasePrintDialog = true;
        }
        public string _Field_IdCliente
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT ccliente FROM TNOTACREDICC WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotcredicc='" + _Str_G_NC + "'";
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
                string _Str_Sql = "SELECT c_rif FROM TCLIENTE WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccliente='" + _Str_Gccliente + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
                }
                return _Str_R;
            }
        }
        public string _Field_ClienteName
        {
            get
            {
                string _Str_R = "";
                string _Str_Sql = "SELECT c_nomb_comer FROM TCLIENTE WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccliente='" + _Str_Gccliente + "'";
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
                string _Str_Sql = "SELECT c_direcc_fiscal FROM TCLIENTE WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccliente='" + _Str_Gccliente + "'";
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
                string _Str_Sql = "SELECT cdescripcion FROM TNOTACREDICC WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotcredicc='" + this._Str_G_NC + "'";
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
                string _Str_Sql = "SELECT cmontototsi FROM TNOTACREDICC WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotcredicc='" + this._Str_G_NC + "'";
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
                string _Str_Sql = "SELECT cimpuesto FROM TNOTACREDICC WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotcredicc='" + this._Str_G_NC + "'";
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
                string _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + _Str_Gcgroupcomp + "' AND ccompany='" + _Str_Gccompany + "' AND cidnotcredicc='" + this._Str_G_NC + "'";
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
                string _Str_R = "NOTA DE CREDITO N# " + _Str_G_NC;
                return _Str_R;
            }
        }
        private int _Mtd_ObtenerTamañoPapel(string _Pr_Str_NombreSize)
        {
            int _Int_Width = 0;
            int _Int_Height = 0;
            int _Int_rawKind = 0;
            for (int _I = 0; _I < _My_PrintDialogo.PrinterSettings.PaperSizes.Count; _I++)
            {
                if (_My_PrintDialogo.PrinterSettings.PaperSizes[_I].PaperName == _Pr_Str_NombreSize)
                {
                    _Int_rawKind = _My_PrintDialogo.PrinterSettings.PaperSizes[_I].RawKind;
                    _Int_Width = _My_PrintDialogo.PrinterSettings.PaperSizes[_I].Width;
                    _Int_Height = _My_PrintDialogo.PrinterSettings.PaperSizes[_I].Height;
                }
            }
            return _Int_rawKind;
        }

        private void _My_Documento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float _Fl_Linea = 0;
            float _Fl_Y = 0;
            e.PageSettings.PaperSize = new PaperSize("Carta_Mitad", 850, 550);
            //e.PageSettings.PaperSize.RawKind = _Mtd_ObtenerTamañoPapel("Carta_Mitad");
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
            RectangleF _My_RecClienteName = new RectangleF(10, _Fl_Y, 180, _My_Size.Height);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            RectangleF _My_RecClienteDirFis = new RectangleF(10, _Fl_Y, 190, _My_Size.Height);
            _Fl_Y = _Fl_Y + _My_Size.Height + 2;
            RectangleF _My_RecClienteRif = new RectangleF(10, _Fl_Y, 150, _My_Size.Height);

            _My_Sf.Alignment = StringAlignment.Center;
            _My_Grafico.DrawString(this._Field_Titulo, _My_Fuente, Brushes.Black, _My_RecCabecera, _My_Sf);
            _My_Grafico.DrawString("Fecha: " + DateTime.Now.Date.ToShortDateString(), _My_Fuente, Brushes.Black, _My_RecFecha, _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("Cliente: " + this._Field_ClienteName, _My_Fuente, Brushes.Black, _My_RecClienteName, _My_Sf);
            string _Str_DirecFiscal = this._Field_DirecFiscal.Replace("\r", "").Replace("\n", "");
            if (_Str_DirecFiscal.Length > 100)
            {
                _Str_DirecFiscal = _Str_DirecFiscal.Substring(0, 100);
            }
            _My_Grafico.DrawString("Dirección fiscal: " + _Str_DirecFiscal, _My_Fuente, Brushes.Black, _My_RecClienteDirFis, _My_Sf);
            _My_Grafico.DrawString("Rif: " + this._Field_Rif, _My_Fuente, Brushes.Black, _My_RecClienteRif, _My_Sf);
            _Fl_Y = _Fl_Y + 10;
            _My_Grafico.DrawLine(new Pen(Color.Black,0.3f), 10, _Fl_Y, 200, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.3f), 10, _Fl_Y, 200, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Sf.Alignment = StringAlignment.Near;
            _My_Grafico.DrawString("Concepto", _My_Fuente, Brushes.Black, new RectangleF(10,_Fl_Y,105,_My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString("Monto(Bs.F.)", _My_Fuente, Brushes.Black, new RectangleF(120, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Impuesto", _My_Fuente, Brushes.Black, new RectangleF(145, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Grafico.DrawString("Monto total", _My_Fuente, Brushes.Black, new RectangleF(175, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Near;
            _Fl_Y = _Fl_Y + 4;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.3f), 10, _Fl_Y, 200, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Grafico.DrawLine(new Pen(Color.Black, 0.3f), 10, _Fl_Y, 200, _Fl_Y);
            _Fl_Y = _Fl_Y + 2;
            _My_Sf.Alignment = StringAlignment.Near;
            string _Str_Concepto = this._Field_Concepto;
            float _Fl_LongConcepto = 110;
            Int32 _Int_NumLinea = 1;
            if (_My_Grafico.MeasureString(_Str_Concepto, _My_Fuente).Width > _Fl_LongConcepto)
            {
                _Fl_Linea = _My_Grafico.MeasureString(_Str_Concepto, _My_Fuente).Width / _Fl_LongConcepto;
            }
            if (Math.Floor(_Fl_Linea) < _Fl_Linea)
            {
                _Int_NumLinea = Convert.ToInt32(Math.Floor(_Fl_Linea)) + 2;
            }
            //if (_Str_Concepto.Length > 60)
            //{
            //    _Str_Concepto = _Str_Concepto.Substring(0, 60);
            //}
            _My_Grafico.DrawString(_Str_Concepto, _My_Fuente, Brushes.Black, new RectangleF(10, _Fl_Y, 105, (_My_Size.Height * _Int_NumLinea)), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoSimp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(120, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoImp.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(145, _Fl_Y, 25, _My_Size.Height), _My_Sf);
            _My_Sf.Alignment = StringAlignment.Far;
            _My_Grafico.DrawString(this._Field_MontoTotal.ToString("#,##0.00"), _My_Fuente, Brushes.Black, new RectangleF(175, _Fl_Y, 25, _My_Size.Height), _My_Sf);
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
