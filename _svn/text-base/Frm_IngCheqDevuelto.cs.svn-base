using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace T3
{
    public partial class Frm_IngCheqDevuelto : Form
    {
        string _Str_Relacion = "";
        string _Str_Cliente = "";
        string _Str_Vendedor = "";
        string _Str_TipoDoc = "";
        string _Str_TipoCob = "";
        string _Str_NumCuentaDeposito = "";
        string _Str_BancoDeposito = "";
        public Frm_IngCheqDevuelto()
        {
            InitializeComponent();
            _Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_BancoDev();
        }
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Nº Cheque");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cnumcheque";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "Select RTRIM(c_nomb_comer) as c_nomb_comer,cname,cnumcheque,CONVERT(char(10),cfechaemision,103) as cfechaemision,dbo.Fnc_Formatear(cmontocheq) as cmontocheq,cdescripcion,Dias,cidnotadebitocc,cidcheqdevuelt,ccliente from VST_CHEQUEDEVUELTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cactivo='1' AND EXISTS(SELECT csaldofactura FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument=(SELECT TCONFIGCXC.ctipdoccheqdev FROM TCONFIGCXC WHERE TCONFIGCXC.ccompany='" + Frm_Padre._Str_Comp + "') AND cnumdocu=VST_CHEQUEDEVUELTO.cnumcheque AND cactivo=1 AND cdelete=0 AND csaldofactura>0 AND TSALDOCLIENTED.CCLIENTE=VST_CHEQUEDEVUELTO.CCLIENTE)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Ingreso cheques devueltos", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Cargar_Motivo()
        {
            string _Str_Cadena = "SELECT rtrim(cidmotivo),cdescripcion FROM TMOTIVO where cmotivodevcheq='1' ORDER BY cdescripcion ASC";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Cadena);
        }
        private void _Mtd_Cargar_BancoDev()
        {
            string _Str_Cadena = "SELECT TBANCO.cbanco,TBANCO.cname FROM TBANCO INNER JOIN " +
"TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' and TBANCO.cdelete=0";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_BancoDev, _Str_Cadena);
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cidcheqdevuelt FROM TCHEQDEVUELT where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidcheqdevuelt DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Pnl_VariosDocument.Visible = false;
            _Lbx_Documents.DataSource = null;
            _Txt_Cliente.Text = "";
            _Txt_Documento.Text = "";
            _Txt_FechaDevolucion.Text = "";
            _Txt_FechaEmision.Text = "";
            _Txt_Id.Text = "";
            _Txt_Monto.Text = "";
            _Txt_NotaDeb.Text = "";
            _Txt_NotaDebBanc.Text = "";
            _Txt_NumeroCheq.Text = "";
            _Txt_Tipo.Text = "";
            _Txt_Vendedor.Text = "";
            _Txt_Ob.Text = "";
            _Str_Relacion = "";
            _Str_TipoCob = "";
            _Str_TipoDoc = "";
            _Str_Cliente = "";
            _Str_Vendedor = "";
            _Str_NumCuentaDeposito = "";
            _Str_BancoDeposito = "";
            _Chk_NDDesc.Checked = false;
            _Mtd_Cargar_Motivo();
            _Txt_Banco.Text = "";
            _Txt_Banco.Tag = "";
            _Mtd_Cargar_BancoDev();
            _Mtd_Habilitar();
            _Txt_Id.Enabled = true;
            _Mtd_LimpiarND();
            _Lbx_DescuentoPP.Items.Clear();
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Id.Enabled = false;
            _Cmb_BancoDev.Enabled = false;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Id.Enabled = false;
            _Txt_NumeroCheq.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Cmb_BancoDev.Enabled = false;
            _Txt_NotaDebBanc.Enabled = false;
            _Txt_Ob.Enabled = false;
            _Chk_NDDesc.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Bt_NotaDeb.Enabled = false;
            _Cmb_BancoDev.Enabled = true;
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Id.Enabled = true;
            _Cmb_BancoDev.Focus();
        }
        private bool _Mtd_VerificarSiYaExiste()
        {
            if (_Txt_NumeroCheq.Text.Trim().Length > 0 & _Str_Cliente.Trim().Length > 0)
            {
                string _Str_Cadena = "SELECT cidcheqdevuelt FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND RTRIM(LTRIM(cnumcheque))='" + _Txt_NumeroCheq.Text.Trim() + "' AND ccliente='" + _Str_Cliente + "'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private bool _Mtd_ValidaSave()
        {
            bool _Bol_Sw = true;
            _Er_Error.Dispose();
            if (_Cmb_BancoDev.SelectedIndex < 1)
            {
                _Er_Error.SetError(_Cmb_BancoDev, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Txt_NotaDebBanc.Text.Trim().Length == 0)
            { _Txt_NotaDebBanc.Text = "0"; }
            if (_Txt_NotaDebBanc.Text.Trim() == "0")
            {
                _Er_Error.SetError(_Txt_NotaDebBanc, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Cmb_Motivo.SelectedIndex < 1)
            {
                _Er_Error.SetError(_Cmb_Motivo, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Txt_Banco.Text.Trim().Length==0)
            {
                _Er_Error.SetError(_Txt_Banco, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Txt_NumeroCheq.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_NumeroCheq, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Mtd_VerificarSiYaExiste())
            {
                MessageBox.Show("El cheque ya ha sido ingresado", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bol_Sw = false; 
            }
            return _Bol_Sw;
        }
        private string _Mtd_DescripcionBanco(string _P_Str_Banco)
        {
            string _Str_Cadena = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private double _Mtd_ObtenerImpuesto(string _Str_TipoDoc_, string _Str_NumDocu, string _Str_Cliente, string _Str_Compania)
        {
            DataSet _Ds;
            double _Dbl_Imp = 0;
            string _Str_ctipdoccheqdev = "", _Str_ctipoND = "",  _Str_ctipdocfact = "";
            string _Str_Sql = "SELECT ctipdoccheqdev,ctipdocfact,ctax,ctipdocnotdeb FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ctipdoccheqdev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]).Trim();
                _Str_ctipdocfact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
                _Str_ctipoND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]).Trim();
            }
            if (_Str_TipoDoc_.Trim() == _Str_ctipdocfact.Trim())
            {
                _Str_Sql = "SELECT CALICUOTA FROM TFACTURAM WHERE CCLIENTE='" + _Str_Cliente + "' AND CFACTURA='" + _Str_NumDocu + "' AND CCOMPANY='" + _Str_Compania + "'";
            }
            if (_Str_TipoDoc_.Trim() == _Str_ctipoND.Trim())
            {
                _Str_Sql = "SELECT CALICUOTA FROM TNOTADEBICC WHERE CCLIENTE='" + _Str_Cliente + "' AND CIDNOTADEBITOCC='" + _Str_NumDocu + "' AND CCOMPANY='" + _Str_Compania + "'";
            }
            if (_Str_TipoDoc_.Trim() == _Str_ctipdoccheqdev.Trim())
            {
                _Str_Sql = "SELECT CALICUOTA FROM TCHEQDEVUELT WHERE CCLIENTE='" + _Str_Cliente + "' AND CNUMCHEQUE='" + _Str_NumDocu + "' AND CCOMPANY='" + _Str_Compania + "'";
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_Imp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                _Dbl_Imp = 0;
            }
            return _Dbl_Imp;
        }
        private string _Mtd_ND_DescuentoFinanciero(double _Pr_Dbl_PorcDescFinanc, double[] _Dbl_PorcDescFinanc_)
        {
            DataSet _Ds;
            double _Dbl_PorcImp = 0;
            string _Str_ctax = "";
            string _Str_cdescripcion = "";
            double _Dbl_MontoND = 0, _Dbl_MontoDocSimp = 0, _Dbl_MontoNDsimp = 0, _Dbl_MontoNDimp = 0, _Dbl_Alicuota = 0;
            if (_Pnl_SoloDocumento.Visible)
            {
                _Str_cdescripcion = _Cmb_Motivo.Text + " " + _Txt_Tipo.Text + "# " + _Txt_Documento.Text;
            }
            string _Str_ctipdoccheqdev = "",_Str_ctipoND="", _Str_FechaVenc = "", _Str_ctipdocfact = "", _Str_FechaFact="";
            string _Str_ND = "0";
            string _Str_Sql = "SELECT ctipdoccheqdev,ctipdocfact,ctax,ctipdocnotdeb FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ctipdoccheqdev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]).Trim();
                _Str_ctipdocfact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
                _Str_ctipoND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]).Trim();
                _Str_ctax = Convert.ToString(_Ds.Tables[0].Rows[0]["ctax"]).Trim();
            }
            if (_Str_ctax.Length > 0)
            {
                //_Str_Sql = "SELECT cpercent FROM TTAX WHERE ctax='" + _Str_ctax + "'";
                //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //if (_Ds.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                //    {
                //        _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                //    }
                //}
            }
            double _Dbl_MontoDescFin = 0;
            double _Dbl_Monto = 0;
            string _G_Str_DetalleDocumento = "";
            string _DescripcionCompleta = "";

            if (_Pnl_SoloDocumento.Visible)
            {
                _Dbl_MontoDescFin = _Mtd_MontDescFin(_Str_Cliente, _Str_TipoDoc, _Txt_Documento.Text.Trim());
                //_Str_cdescripcion += " + " + _Pr_Dbl_PorcDescFinanc + "% GASTOS ADMIN.";
                _Str_cdescripcion += " + GASTOS ADMIN.";
                                                                                                                        
                if (_Txt_Monto.Text.Trim().Length == 0) { _Txt_Monto.Text = "0"; }
                //----------
                //_Str_cdescripcion = _Cmb_Motivo.Text.Trim().ToUpper() + " " + _Pr_Dbl_PorcDescFinanc + "% GASTOS ADMIN. CHEQ Nº" + _Txt_NumeroCheq.Text.Trim() + " POR BS.F" + _Txt_Monto.Text.Trim() + " DEL BANCO " + _Mtd_DescripcionBanco(Convert.ToString(_Txt_Banco.Tag).Trim()) + ". FEC. " + _Txt_FechaEmision.Text.Trim();
                _Str_cdescripcion = _Cmb_Motivo.Text.Trim().ToUpper() + " GASTOS ADMIN. CHEQ Nº" + _Txt_NumeroCheq.Text.Trim() + " POR BS.F" + _Txt_Monto.Text.Trim() + " DEL BANCO " + _Mtd_DescripcionBanco(Convert.ToString(_Txt_Banco.Tag).Trim()) + ". FEC. " + _Txt_FechaEmision.Text.Trim();

                //-- Detalle del documento para solo uno
                var _L_Str_Ctipodocument = _Str_TipoDoc.Trim().ToUpper();
                var _L_Str_Cnumdocu = _Txt_Documento.Text.Trim();
                var _L_Str_Cgroupcomp = Frm_Padre._Str_GroupComp;
                var _L_Str_Ccompany = Frm_Padre._Str_Comp;

                if (_L_Str_Ctipodocument == _Str_ctipdocfact.Trim().ToUpper())
                {
                    _G_Str_DetalleDocumento += _G_Str_DetalleDocumento.Length == 0 ? T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosFacturaCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany) :
                                                                          "; " + T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosFacturaCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany);
                }
                else if (_L_Str_Ctipodocument == _Str_ctipdoccheqdev.Trim().ToUpper())
                {
                    _G_Str_DetalleDocumento += _G_Str_DetalleDocumento.Length == 0 ? T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosChequeDevueltoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente) :
                                                                          "; " + T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosChequeDevueltoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente);
                }
                else if (_L_Str_Ctipodocument == _Str_ctipoND.Trim().ToUpper())
                {
                    _G_Str_DetalleDocumento += _G_Str_DetalleDocumento.Length == 0 ? T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosNotaDebitoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente) :
                                                                          "; " + T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosNotaDebitoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente);
                }
                _DescripcionCompleta = _Str_cdescripcion + _G_Str_DetalleDocumento;
                _Str_cdescripcion = _DescripcionCompleta.Length > 255 ? _DescripcionCompleta.Substring(0, 255) : _DescripcionCompleta;

                //----------
                //_Dbl_Monto = ((Convert.ToDouble(_Txt_Monto.Text) * _Pr_Dbl_PorcDescFinanc) / 100) + _Dbl_MontoDescFin;

                _Dbl_Monto = ((Convert.ToDouble(_Txt_Monto.Text) * _Pr_Dbl_PorcDescFinanc) / 100);
                _Str_Sql = "SELECT cpercent FROM TTAX WHERE ctax='" + _Str_ctax + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                    {
                        _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                }
                double _Dbl_ImpuSoloDesFinanciero=0;
                _Dbl_ImpuSoloDesFinanciero=(_Dbl_Monto * (_Dbl_PorcImp/100));
                _Dbl_Monto = _Dbl_Monto+_Dbl_ImpuSoloDesFinanciero;
                _Dbl_Monto += _Dbl_MontoDescFin;
                _Dbl_PorcImp = _Mtd_ObtenerImpuesto(_Str_TipoDoc, _Txt_Documento.Text.Trim(), _Str_Cliente, Frm_Padre._Str_Comp);
                double _Dbl_Impuesto = 0;
                if (_Dbl_MontoDescFin > 0)
                {
                    //_Dbl_Impuesto = _Dbl_Monto - ((_Dbl_Monto / (1 + (_Dbl_PorcImp / 100))));
                    _Dbl_Impuesto = _Dbl_MontoDescFin - ((_Dbl_MontoDescFin / (1 + (_Dbl_PorcImp / 100))));
                }
                _Dbl_Impuesto += _Dbl_ImpuSoloDesFinanciero;


                string _Str_Gerente = "";
                string _Str_Cadena = "SELECT TVENDEDOR.cvendedor FROM TVENDEDOR INNER JOIN TVENDEDOR AS TVENDEDOR_1 ON dbo.TVENDEDOR.cvendedor = TVENDEDOR_1.cgerarea WHERE TVENDEDOR_1.ccompany='" + Frm_Padre._Str_Comp + "' AND TVENDEDOR_1.cvendedor='" + _Str_Vendedor + "' AND TVENDEDOR_1.c_tipo_vend='1' AND TVENDEDOR_1.cdelete='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Gerente = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
                if (_Str_Vendedor.Trim().Length == 0)
                { _Str_Vendedor = "0"; }
                if (_Str_Gerente.Trim().Length == 0)
                { _Str_Gerente = "0"; }
                _Dbl_Monto = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_Monto, 2);
                _Dbl_Impuesto = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_Impuesto, 2);
                _Str_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocctemp) FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                _Str_Cadena = "insert into TNOTADEBICCTEMP (cgroupcomp,ccompany,cidnotadebitocctemp,ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cidmotivo,cdateadd,cuseradd,cestatusfirma,cvendedor,cvendedorc,cgerarea,calicuota,cexento)" +
                       " values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ND + "','" + _Str_Cliente + "','" + _Str_ctipdocfact + "','" + _L_Str_Cnumdocu + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_cdescripcion.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto - _Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cmb_Motivo.SelectedValue.ToString() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',1,'" + _Str_Vendedor + "','" + _Str_Vendedor + "','" + _Str_Gerente + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_PorcImp) + "','0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //_Str_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocc) FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                //_Str_Sql = "INSERT INTO TNOTADEBICC (cgroupcomp,ccompany,cidnotadebitocc,ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cfvfnotadebitop,cdescontada,canulado,cactivo,cimpresa,cidmotivo,cdateadd,cuseradd,cdelete,cvendedor,cvendedorc,cgerarea,calicuota) VALUES('" +
                //Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ND + "','" + _Str_Cliente + "','" + _Str_ctipdocfact + "','" + _Txt_NumeroCheq.Text.Trim() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_cdescripcion + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto - _Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',0,0,0,0,'" + _Cmb_Motivo.SelectedValue.ToString() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','0','" + _Str_Vendedor + "','" + _Str_Vendedor + "','" + _Str_Gerente + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_PorcImp) + "')";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                return _Str_ND;
            }
            else
            {                
                _Str_Sql = "SELECT DISTINCT CCLIENTE FROM TCHEQDEVUELTD WHERE CIDCHEQDEVUELT='" + _Txt_Id.Text+ "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                {
                    double _Dbl_DescuentosFinancieros = 0;
                    double _Dbl_MontosDescuentosAcum = 0;
                    _Dbl_Monto = 0;
                    double _Dbl_Monto_I=0;
                    double _Dbl_Impuesto = 0;
                    _Str_cdescripcion = _Cmb_Motivo.Text + " POR DOCUMENTOS: ";
                    string _Str_cdescripcion_ = "";
                    string _Str_Cliente_C = _Dtw_Item["CCLIENTE"].ToString().TrimEnd();
                    string _Str_NumeroDocumento = "";
                    foreach (object _Obj_Ob in _Lbx_Documents.Items)
                    {
                        string[] _Str_Value_ = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                        string[] _Str_Text = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Display.ToString().Split('-');
                        if (_Str_Cliente_C.TrimEnd() == _Str_Value_[1].TrimEnd())
                        {
                            _Dbl_MontoDescFin = _Mtd_MontDescFin(_Str_Cliente_C, _Str_Text[0], _Str_Text[1]);
                            //_Str_cdescripcion += " + " + _Pr_Dbl_PorcDescFinanc + "% GASTOS ADMIN.";
                            _Pr_Dbl_PorcDescFinanc = _Mtd_PorcDesFin(_Mtd_MontDescFin(_Str_Value_[1], _Str_Text[0], _Str_Text[1]));
                            //((T3.Clases._Cls_ArrayList)_Obj_Ob).Value;
                            //_Dbl_PorcDescFinanc += Convert.ToDouble(((T3.Clases._Cls_ArrayList)_Obj_Ob).Value);
                            string[] _Str_Value = _Mtd_DescuentoPP_2(_Str_Text[0], _Str_Text[1], _Str_Value_[1]).Split('-');// ((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                            string _Str_Valor = _Mtd_MontoDetalle(_Str_Text[0], _Str_Text[1], _Str_Value_[1], _Txt_NumeroCheq.Text);
                            
                            _Dbl_DescuentosFinancieros += ((Convert.ToDouble(_Str_Valor.Replace(".", ",")) * _Pr_Dbl_PorcDescFinanc) / 100);
                            _Dbl_MontosDescuentosAcum += _Dbl_MontoDescFin;


                            //_Dbl_Monto_I=((Convert.ToDouble(_Str_Valor.Replace(".", ",")) * _Pr_Dbl_PorcDescFinanc) / 100) + _Dbl_MontoDescFin;

                            _Dbl_Monto_I = ((Convert.ToDouble(_Str_Valor.Replace(".", ",")) * _Pr_Dbl_PorcDescFinanc) / 100);

                            _Str_Sql = "SELECT cpercent FROM TTAX WHERE ctax='" + _Str_ctax + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                                {
                                    _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                                }
                            }
                            double _Dbl_ImpuSoloDesFinanciero = 0;
                            _Dbl_ImpuSoloDesFinanciero = (_Dbl_Monto_I * (_Dbl_PorcImp / 100));
                            _Dbl_Monto_I = _Dbl_Monto_I + _Dbl_ImpuSoloDesFinanciero;
                            _Dbl_Monto_I += _Dbl_MontoDescFin;
                            _Dbl_Monto += _Dbl_Monto_I;                           
                            _Dbl_PorcImp = _Mtd_ObtenerImpuesto(_Str_Text[0], _Str_Text[1], _Str_Value_[1], Frm_Padre._Str_Comp);                            
                            if (_Dbl_MontoDescFin > 0)
                            {
                                //_Dbl_Impuesto += _Dbl_Monto_I-((_Dbl_Monto_I / (1 + (_Dbl_PorcImp / 100))));
                                _Dbl_Impuesto += _Dbl_MontoDescFin - ((_Dbl_MontoDescFin / (1 + (_Dbl_PorcImp / 100))));
                            }
                            _Dbl_Impuesto += _Dbl_ImpuSoloDesFinanciero;
                        }

                        //-- Detalle del documento para solo multiples 
                        var _L_Str_Ctipodocument = _Str_Text[0].Trim().ToUpper();
                        var _L_Str_Cnumdocu = _Str_Text[1].Trim();
                        var _L_Str_Cgroupcomp = Frm_Padre._Str_GroupComp;
                        var _L_Str_Ccompany = Frm_Padre._Str_Comp;

                        if (_L_Str_Ctipodocument == _Str_ctipdocfact.Trim().ToUpper())
                        {
                            _G_Str_DetalleDocumento += _G_Str_DetalleDocumento.Length == 0 ? T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosFacturaCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany) :
                                                                                  "; " + T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosFacturaCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany);
                        }
                        else if (_L_Str_Ctipodocument == _Str_ctipdoccheqdev.Trim().ToUpper())
                        {
                            _G_Str_DetalleDocumento += _G_Str_DetalleDocumento.Length == 0 ? T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosChequeDevueltoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente) :
                                                                                  "; " + T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosChequeDevueltoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente);
                        }
                        else if (_L_Str_Ctipodocument == _Str_ctipoND.Trim().ToUpper())
                        {
                            _G_Str_DetalleDocumento += _G_Str_DetalleDocumento.Length == 0 ? T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosNotaDebitoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente) :
                                                                                  "; " + T3.CLASES._Cls_Varios_Metodos._Mtd_ObtenerDatosNotaDebitoCxC(_L_Str_Cnumdocu, _L_Str_Cgroupcomp, _L_Str_Ccompany, _Str_Cliente);
                        }
                        _Str_NumeroDocumento = _L_Str_Cnumdocu;
                    }
                    //----------
                    _Str_cdescripcion = _Cmb_Motivo.Text.Trim().ToUpper() + " " + _Pr_Dbl_PorcDescFinanc + "% GASTOS ADMIN. CHEQ Nº" + _Txt_NumeroCheq.Text.Trim() + " POR BS.F" + _Txt_Monto.Text.Trim() + " DEL BANCO " + _Mtd_DescripcionBanco(Convert.ToString(_Txt_Banco.Tag).Trim()) + ". FEC. " + _Txt_FechaEmision.Text.Trim();

                    _DescripcionCompleta = _Str_cdescripcion + _G_Str_DetalleDocumento;
                    _Str_cdescripcion = _DescripcionCompleta.Length > 255 ? _DescripcionCompleta.Substring(0, 255) : _DescripcionCompleta;

                    //----------
                    if (_Txt_Monto.Text.Trim().Length == 0) { _Txt_Monto.Text = "0"; }
                    string _Str_Gerente = "";
                    string _Str_Cadena = "SELECT TVENDEDOR.cvendedor FROM TVENDEDOR INNER JOIN TVENDEDOR AS TVENDEDOR_1 ON dbo.TVENDEDOR.cvendedor = TVENDEDOR_1.cgerarea WHERE TVENDEDOR_1.ccompany='" + Frm_Padre._Str_Comp + "' AND TVENDEDOR_1.cvendedor='" + _Str_Vendedor + "' AND TVENDEDOR_1.c_tipo_vend='1' AND TVENDEDOR_1.cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Gerente = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    if (_Str_Vendedor.Trim().Length == 0)
                    { _Str_Vendedor = "0"; }
                    if (_Str_Gerente.Trim().Length == 0)
                    { _Str_Gerente = "0"; }
                    _Dbl_Monto = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_Monto, 2);
                    _Dbl_Impuesto = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_Impuesto, 2);
                    _Str_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocctemp) FROM TNOTADEBICCTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                    _Str_Cadena = "insert into TNOTADEBICCTEMP (cgroupcomp,ccompany,cidnotadebitocctemp,ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cidmotivo,cdateadd,cuseradd,cestatusfirma,cvendedor,cvendedorc,cgerarea,calicuota,cexento)" +
                           " values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ND + "','" + _Str_Cliente + "','" + _Str_ctipdocfact + "','" + _Str_NumeroDocumento + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_cdescripcion.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto - _Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cmb_Motivo.SelectedValue.ToString() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',1,'" + _Str_Vendedor + "','" + _Str_Vendedor + "','" + _Str_Gerente + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_PorcImp) + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //_Str_ND = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocc) FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                    //_Str_Sql = "INSERT INTO TNOTADEBICC (cgroupcomp,ccompany,cidnotadebitocc,ccliente,ctipodocument,cnumdocu,cfecha,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cfvfnotadebitop,cdescontada,canulado,cactivo,cimpresa,cidmotivo,cdateadd,cuseradd,cdelete,cvendedor,cvendedorc,cgerarea,calicuota) VALUES('" +
                    //Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ND + "','" + _Str_Cliente + "','" + _Str_ctipdocfact + "','" + _Txt_NumeroCheq.Text.Trim() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_cdescripcion + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto - _Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',0,0,0,0,'" + _Cmb_Motivo.SelectedValue.ToString() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','0','" + _Str_Vendedor + "','" + _Str_Vendedor + "','" + _Str_Gerente + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_PorcImp) + "')";
                    //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);                    
                }
                return _Str_ND;
            }
   
        }
        private string _Mtd_GerenteDeArea(string _P_Str_Vendedor)
        {
            if (_P_Str_Vendedor.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cgerarea from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _P_Str_Vendedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                }
            }
            return "";
        }
        private double _Mtd_PorcDesFin(double _P_Dbl_DescuentoPP)
        {
            if (_Rbt_Porcent1.Checked)
            {
                return 1;
            }
            else if(_Rbt_Porcent3.Checked)
            {
                return 3;
            }
            //string _Str_Cadena = "SELECT CASE WHEN " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_DescuentoPP) + ">0 THEN cporcdesccheqdev1 ELSE cporcdesccheqdev2 END FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //if (_Ds.Tables[0].Rows.Count > 0)
            //{
            //    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
            //    { return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
            //}
            return 0;
        }
        private double _Mtd_MontDescFin(string _P_Str_Cliente, string _P_Str_TipoDocument, string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT cdesctopp FROM TRELACCOBD WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND ctipodocument='" + _P_Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Documento + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    if (_Rbt_Porcent1.Checked)
                    {
                        return 0;
                    }
                    else if (_Rbt_Porcent3.Checked)
                    {
                        return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                }
            }
            return 0;
        }
        private double _Mtd_MontDescFin_2(string _P_Str_Cliente, string _P_Str_TipoDocument, string _P_Str_Documento)
        {
            string _Str_Cadena = "SELECT cdesctopp FROM TRELACCOBD WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND ctipodocument='" + _P_Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Documento + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return 0;
        }
        public bool _Mtd_Guardar()
        {
            ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Mtd_VerificarCierreCaja();
            if (!((Frm_Padre)this.MdiParent)._Frm_Contenedor._Bol_CierreCajaActivado)
            {
                string _Str_DescFinanc = "0";
                double _Dbl_PorcDescFinanc = 0;
                string _Str_ND = "";
                string _Str_ComprobDevCheq = "";
                double[] _Dbl_PorcDescFinanc_ = null;
                _Er_Error.Dispose();
                if (_Txt_Monto.Text.Trim().Length == 0)
                { _Txt_Monto.Text = "0"; }
                if (_Txt_Documento.Text.Trim().Length == 0)
                { _Txt_Documento.Text = "0"; }

                if (_Mtd_ValidaSave())
                {
                    string _Str_Cadena = "";
                    _Txt_Id.Text = _Mtd_Entrada().ToString();
                    if (_Chk_NDDesc.Checked)
                    {
                        _Str_DescFinanc = "1";
                        if (_Pnl_SoloDocumento.Visible)
                        {
                            _Dbl_PorcDescFinanc = _Mtd_PorcDesFin(_Mtd_MontDescFin(_Str_Cliente, _Str_TipoDoc, _Txt_Documento.Text.Trim()));
                        }
                        else if (_Pnl_VariosDocument.Visible)
                        {
                            _Dbl_PorcDescFinanc_ =new double[_Lbx_Documents.Items.Count];
                            int _Int_Cont_DPP = 0;
                            foreach (object _Obj_Ob in _Lbx_Documents.Items)
                            {
                                string[] _Str_Value_ = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                                string[] _Str_T = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Display.ToString().Split('-');
                                //((T3.Clases._Cls_ArrayList)_Obj_Ob).Value;
                                string[] _Str_Value = _Mtd_DescuentoPP(_Str_T[0], _Str_T[1], _Str_Value_[1]).Split('-');//((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                                _Dbl_PorcDescFinanc_[_Int_Cont_DPP] = Convert.ToDouble(_Str_Value[0].Replace(".", ","));
                                _Dbl_PorcDescFinanc += Convert.ToDouble(_Str_Value[0].Replace(".",","));
                                _Int_Cont_DPP++;
                            }
                        }
                    }
                    _Str_Cadena = "insert into TCHEQDEVUELT (cgroupcomp,ccompany,cidcheqdevuelt,cnumcheque,ccliente,cvendedor,cbancocheque,ctipocobro,cidrelacobro,cfechaemision,cmontocheq,ctipodocument,cnumdocu,cidmotivo,cfechadevcheq,cbancochequedev,cbanconddev,cobservacion,cdateadd,cuseradd,cdelete,cqdescuentfinan,cporcendescfina,calicuota,cgerarea,cidcomprob,cnumcuentadepo,cvendedorcheque) values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Id.Text.Trim() + "','" + _Txt_NumeroCheq.Text.Trim() + "','" + _Str_Cliente + "','" + _Str_Vendedor + "','" + _Txt_Banco.Tag.ToString() + "','" + _Str_TipoCob + "','" + _Str_Relacion + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Txt_FechaEmision.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text)) + "','" + _Str_TipoDoc + "','" + _Txt_Documento.Text + "','" + _Cmb_Motivo.SelectedValue + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cmb_BancoDev.SelectedValue + "','" + _Txt_NotaDebBanc.Text + "','" + _Txt_Ob.Text.Trim().ToUpper() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0'," + _Str_DescFinanc + "," + _Dbl_PorcDescFinanc.ToString().Replace(",", ".") + ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_Alicuota(_Txt_Documento.Text.Trim(), _Str_TipoDoc)) + "','" + _Mtd_GerenteDeArea(_Str_Vendedor) + "','0','" + _Str_NumCuentaDeposito + "','" + _Str_Vendedor + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    if (_Pnl_VariosDocument.Visible)
                    {
                        foreach (object _Obj_Ob in _Lbx_Documents.Items)
                        {
                            string[] _Str_Value_ = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                            string[] _Str_T = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Display.ToString().Split('-');
                            string _Str_Monto = _Mtd_MontoDetalle(_Str_T[0], _Str_T[1], _Str_Value_[1], _Txt_NumeroCheq.Text);
                            _Str_Cadena = "insert into TCHEQDEVUELTD (cgroupcomp,ccompany,cidcheqdevuelt,cnumcheque,ccliente,cclientechq,cbancocheque,ctipodocument,cnumdocu,cdateadd,cuseradd,cdelete,cmontocancel) values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Id.Text.Trim() + "','" + _Txt_NumeroCheq.Text.Trim() + "','" + _Str_Value_[1] + "','"+_Str_Cliente+"','" + _Txt_Banco.Tag.ToString() + "','" + _Str_T[0] + "','" + _Str_T[1] + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','" + _Str_Monto.ToString().Replace(",", ".") + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        string _Str_Monto = _Mtd_MontoDetalle(_Str_TipoDoc, _Txt_Documento.Text, _Str_Cliente, _Txt_NumeroCheq.Text);
                        _Str_Cadena = "insert into TCHEQDEVUELTD (cgroupcomp,ccompany,cidcheqdevuelt,cnumcheque,ccliente,cclientechq,cbancocheque,ctipodocument,cnumdocu,cdateadd,cuseradd,cdelete,cmontocancel) values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Id.Text.Trim() + "','" + _Txt_NumeroCheq.Text.Trim() + "','" + _Str_Cliente + "','" + _Str_Cliente + "','" + _Txt_Banco.Tag.ToString() + "','" + _Str_TipoDoc + "','" + _Txt_Documento.Text + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','" + _Str_Monto.ToString().Replace(",", ".") + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //-----------------------------------------------------------------------------------------------
                    //-------Esto se debe generar desde impresion lote con un tabs
                    //_Str_ComprobDevCheq = _MyUtilidad._Mtd_Proceso_P_CXC_CHEQDEV(_Str_TipoDoc, _Txt_Documento.Text.Trim(), _Cmb_BancoDev.SelectedValue.ToString().Trim(), _Str_Relacion, _Txt_NumeroCheq.Text.Trim(), _Txt_FechaEmision.Text, Convert.ToDouble(_Txt_Monto.Text), _Str_NumCuentaDeposito);
                    //_Mtd_PrintComprob(_Str_ComprobDevCheq);
                    //-------Esto se debe generar desde impresion lote con un tabs
                    _Mtd_ActualizarSaldoCliente(_Txt_Id.Text.Trim());
                    if (_Chk_NDDesc.Checked)
                    {
                        _Str_ND = _Mtd_ND_DescuentoFinanciero(_Dbl_PorcDescFinanc,_Dbl_PorcDescFinanc_);
                        if (_Str_ND.Length > 0)
                        {
                            _Str_Cadena = "UPDATE TCHEQDEVUELT SET cidnotadebitocc=" + _Str_ND + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + _Txt_Id.Text + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        }
                    }
                    else
                    {
                        _Str_DescFinanc = "0";
                        _Dbl_PorcDescFinanc = 0;
                    }
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if ((Frm_Padre)this.MdiParent != null) { System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default); }
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private void Frm_IngCheqDevuelto_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        public void _Mtd_CargarListBox(ListBox _Pr_Lbx, DataSet _Ds_DataSet)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Lbx.DataSource = null;
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            foreach (DataRow _DRow in _Ds_DataSet.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Pr_Lbx.DataSource = _myArrayList;
            _Pr_Lbx.DisplayMember = "Display";
            _Pr_Lbx.ValueMember = "Value";
        }
        private void _Cmb_BancoDev_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_BancoDev();
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Motivo();
            this.Cursor = Cursors.Default;
        }

        private void _Txt_NumeroCheq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_NumeroCheq_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_NumeroCheq, "");
            if (!_Mtd_IsNumeric(_Txt_NumeroCheq.Text))
            {
                _Txt_NumeroCheq.Text = "";
            }
            _Txt_Cliente.Text = "";
            _Txt_Documento.Text = "";
            _Txt_FechaDevolucion.Text = "";
            _Txt_FechaEmision.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Tipo.Text = "";
            _Txt_Vendedor.Text = "";
            _Txt_NotaDebBanc.Text = "";
            _Txt_Ob.Text = "";
            _Txt_Ob.Enabled = false;
            _Txt_NotaDebBanc.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Cmb_Motivo.SelectedIndex = -1;
        }
        private double _Mtd_Alicuota(string _P_Str_Documento, string _P_Str_TipoDocument)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            if (_P_Str_Documento.Trim().Length > 0 & _P_Str_TipoDocument.Trim().Length > 0)
            {
                _Str_Cadena = "SELECT ctipdocfact,ctipdocnotdeb,ctipdoccheqdev FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper())
                {
                    _Str_Cadena = "SELECT calicuota FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _P_Str_Documento + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            return Convert.ToDouble(_Ds.Tables[0].Rows[0]["calicuota"].ToString());
                        }
                    }
                }
                else if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocnotdeb"].ToString().Trim().ToUpper())
                {
                    _Str_Cadena = "SELECT calicuota FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _P_Str_Documento + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            return Convert.ToDouble(_Ds.Tables[0].Rows[0]["calicuota"].ToString());
                        }
                    }
                }
                else if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdoccheqdev"].ToString().Trim().ToUpper())
                {
                    _Str_Cadena = "SELECT calicuota FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + _P_Str_Documento + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            return Convert.ToDouble(_Ds.Tables[0].Rows[0]["calicuota"].ToString());
                        }
                    }
                }
            }
            _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCXC ON TTAX.ctax = TCONFIGCXC.ctax WHERE (TCONFIGCXC.ccompany = '" + Frm_Padre._Str_Comp + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                {
                    return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return 0;
        }
        private DataSet _Mtd_DocumentosCheq(string _Str_Cheque, string _Str_Cliente, string _Str_Banco, string _Str_Compania, string _Str_IdRelacobro, string _Str_Idrelaciondetalle, string _Str_Iddrelaciondep)
        {
            DataSet _Ds_DataSet = new DataSet();
            try
            {
                string _Str_SentenciaSQL = "SELECT CONVERT(VARCHAR,cclientechq)+'-'+CONVERT(VARCHAR,ccliente),ctipodocument+' - '+CONVERT(VARCHAR,cnumdocu) FROM VST_T3_CONSULTACHQTIPODOCUMENT WHERE CCOMPANY='" + _Str_Compania + "' AND cbancocheque='" + _Str_Banco + "' and cnumcheque='" + _Str_Cheque + "' and cclientechq='" + _Str_Cliente + "' and cidrelacobro='" + _Str_IdRelacobro + "' and cidrelaciondetalle='" + _Str_Idrelaciondetalle + "' and cidrelaciondep='" + _Str_Iddrelaciondep + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            }
            catch
            {
            }
            return _Ds_DataSet;
        }
        private DataSet _Mtd_DocumentosCheq(string _Str_Cheque, string _Str_Cliente, string _Str_Banco, string _Str_Compania)
        {
            DataSet _Ds_DataSet = new DataSet();
            try
            {
                string _Str_Idrelaciondetalle = ""; ;
                string _Str_Iddrelaciondep="";
                string _Str_TipoCancel = "0";
                string _Str_SentenciaSQL = "SELECT CONVERT(VARCHAR,cclientechq)+'-'+CONVERT(VARCHAR,ccliente),ctipodocument+' - '+CONVERT(VARCHAR,cnumdocu) FROM TCHEQDEVUELTD WHERE CCOMPANY='" + _Str_Compania + "' AND CNUMCHEQUE='" + _Str_Cheque + "' AND CCLIENTECHQ='" + _Str_Cliente + "' AND CBANCOCHEQUE='" + _Str_Banco + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);               
            }
            catch
            {
            }
            return _Ds_DataSet;
        }
        private string _Mtd_DescuentoPP(string _Str_TipoDoc, string _Str_Documento_, string _Str_Cliente)
        {
            string _Str_SentenciaSQL = "SELECT cmontocancel,cdesctopp FROM TRELACCOBD WHERE CIDRELACOBRO='" + _Str_Relacion + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TipoDoc + "' AND CNUMDOCU='" + _Str_Documento_ + "' AND CCLIENTE='" + _Str_Cliente + "'";
            DataSet _Ds_DataSet = new DataSet();
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                var _Str_cmontocancel = _Ds_DataSet.Tables[0].Rows[0][0].ToString() == "" ? "0" : Convert.ToString(_Ds_DataSet.Tables[0].Rows[0][0].ToString());
                var _Str_cdesctopp = _Ds_DataSet.Tables[0].Rows[0][1].ToString() == "" ? "0" : Convert.ToString(_Ds_DataSet.Tables[0].Rows[0][1].ToString());

                return _Str_cdesctopp + "-" + _Str_cmontocancel;
            }
            else
            {
                return "0-0";
            }
        }
        private string _Mtd_DescuentoPP_2(string _Str_TipoDoc, string _Str_Documento_, string _Str_Cliente)
        {
            string _Str_SentenciaSQL = "SELECT cmontocancel,cdesctopp FROM TRELACCOBD WHERE CIDRELACOBRO='" + _Str_Relacion + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TipoDoc + "' AND CNUMDOCU='" + _Str_Documento_ + "' AND CCLIENTE='" + _Str_Cliente + "'";
            DataSet _Ds_DataSet = new DataSet();
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                if (_Rbt_Porcent1.Checked)
                {
                    return Convert.ToString("0") + "-" + Convert.ToString(_Ds_DataSet.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    return Convert.ToString(_Ds_DataSet.Tables[0].Rows[0][1].ToString()) + "-" + Convert.ToString(_Ds_DataSet.Tables[0].Rows[0][0].ToString());
                }
            }
            else
            {
                return "0-0";
            }
        }
        private string _Mtd_MontoDetalle(string _Str_TipoDoc, string _Str_Documento_, string _Str_Cliente, string _Str_NumCheque)
        {
            try
            {
                DataSet _Ds_DataSet = new DataSet();
                string _Str_Idrelaciondetalle = "";
                string _Str_Iddrelaciondep = "";
                string _Str_TipoCancel = "0";
                string _Str_SentenciaSQL = "SELECT TRELACCOBDCHEQ.CIDDRELACOBRO_CHEQ FROM TRELACCOBDCHEQ WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CNUMCHEQUE='" + _Str_NumCheque + "' AND CCLIENTE='" + _Str_Cliente + "' AND CBANCOCHEQUE='" + _Txt_Banco.Tag + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Iddrelaciondep = "0";
                    _Str_Idrelaciondetalle = _Ds_DataSet.Tables[0].Rows[0]["CIDDRELACOBRO_CHEQ"].ToString();
                    _Str_TipoCancel = "2";
                }
                else
                {
                    _Str_SentenciaSQL = "SELECT TRELACCOBDDEPD.CIDDRELACOBRODEP,TRELACCOBDDEPD.CIDDRELACOBRO_DEPD FROM TRELACCOBDDEPD WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CNUMCHEQUE='" + _Str_NumCheque + "' AND CCLIENTE='" + _Str_Cliente + "' AND CBANCOCHEQUE='" + _Txt_Banco.Tag + "'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    _Str_Iddrelaciondep = _Ds_DataSet.Tables[0].Rows[0]["CIDDRELACOBRODEP"].ToString();
                    _Str_Idrelaciondetalle = _Ds_DataSet.Tables[0].Rows[0]["CIDDRELACOBRO_DEPD"].ToString();
                    _Str_TipoCancel = "1";
                }
                _Str_SentenciaSQL = "SELECT cmontodeefectivo FROM VST_T3_CONSULTACHQTIPODOCUMENT WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cbancocheque='" + _Txt_Banco.Tag.ToString() + "' and cnumcheque='" + _Str_NumCheque + "' and ccliente='" + _Str_Cliente + "' and ctipodocument='" + _Str_TipoDoc + "' and cnumdocu='" + _Str_Documento_ + "' AND  cidrelaciondetalle='" + _Str_Idrelaciondetalle + "' and cidrelaciondep='" + _Str_Iddrelaciondep + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                return _Ds_DataSet.Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Cmb_BancoDev.SelectedIndex > 0)
            {                
                this.Cursor = Cursors.WaitCursor;
                TextBox _Txt_RelacionTemp = new TextBox();
                Frm_BusquedaCheq _Frm = new Frm_BusquedaCheq(" and cbancodepo='" + _Cmb_BancoDev.SelectedValue + "'", _Txt_RelacionTemp);
                _Frm.ShowDialog(this);
                if (_Txt_RelacionTemp.Text.Trim().Length > 0)
                {
                    _Lbx_DescuentoPP.Items.Clear();
                    _Str_Relacion = _Txt_RelacionTemp.Text;
                    string _Str_Cadena = "";
                    if (Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["RelTipo"].Value).Trim() == "DEP")
                    { _Str_Cadena = "SELECT TRELACCOBDD.cnumdocu, TRELACCOBDD.ctipodocument, TDOCUMENT.cname, TRELACCOBDDEPD.cvendedor FROM TRELACCOBDD INNER JOIN TDOCUMENT ON TRELACCOBDD.ctipodocument = TDOCUMENT.ctdocument INNER JOIN TRELACCOBDDEPD ON TRELACCOBDD.ccompany = TRELACCOBDDEPD.ccompany AND TRELACCOBDD.cgroupcomp = TRELACCOBDDEPD.cgroupcomp AND TRELACCOBDD.cidrelaciondetalle = TRELACCOBDDEPD.ciddrelacobro_depd AND TRELACCOBDD.cidrelaciondep = TRELACCOBDDEPD.ciddrelacobrodep AND TRELACCOBDD.cidrelacobro = TRELACCOBDDEPD.cidrelacobro WHERE TRELACCOBDD.ctipocancelado = 1 AND TRELACCOBDD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TRELACCOBDD.ccompany='" + Frm_Padre._Str_Comp + "' AND TRELACCOBDD.cidrelacobro='" + _Str_Relacion + "' AND TRELACCOBDD.cidrelaciondetalle='" + Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ciddrelacobro_depd"].Value).Trim() + "' AND TRELACCOBDD.cidrelaciondep='" + Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ciddrelacobrodep"].Value).Trim() + "' AND TRELACCOBDDEPD.ccliente='" + Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value).Trim() + "'"; }
                    else
                    { _Str_Cadena = "SELECT TRELACCOBDD.cnumdocu, TRELACCOBDD.ctipodocument, TDOCUMENT.cname, TRELACCOBDCHEQ.cvendedor FROM TRELACCOBDD INNER JOIN TDOCUMENT ON TRELACCOBDD.ctipodocument = TDOCUMENT.ctdocument INNER JOIN TRELACCOBDCHEQ ON TRELACCOBDD.ccompany = TRELACCOBDCHEQ.ccompany AND TRELACCOBDD.cgroupcomp = TRELACCOBDCHEQ.cgroupcomp AND TRELACCOBDD.cidrelacobro = TRELACCOBDCHEQ.cidrelacobro AND TRELACCOBDD.cidrelaciondetalle = TRELACCOBDCHEQ.ciddrelacobro_cheq WHERE TRELACCOBDD.cidrelaciondep = 0 AND TRELACCOBDD.ctipocancelado = 2 AND TRELACCOBDD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TRELACCOBDD.ccompany='" + Frm_Padre._Str_Comp + "' AND TRELACCOBDD.cidrelacobro='" + _Str_Relacion + "' AND TRELACCOBDD.cidrelaciondetalle='" + Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ciddrelacobro_depd"].Value).Trim() + "' AND TRELACCOBDD.cidrelaciondep='" + Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ciddrelacobrodep"].Value).Trim() + "' AND TRELACCOBDCHEQ.ccliente='" + Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value).Trim() + "'"; }
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        DataSet _Ds_DataSet = new DataSet();
                        _Ds_DataSet = _Mtd_DocumentosCheq(Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["Nº Cheque"].Value).Trim(), Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value).Trim(), Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["cbancocheque"].Value).Trim(), Frm_Padre._Str_Comp, _Str_Relacion, Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ciddrelacobro_depd"].Value).Trim(), Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ciddrelacobrodep"].Value).Trim());
                        _Txt_NumeroCheq.Text = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["Nº Cheque"].Value).Trim();
                        _Str_TipoDoc = _Ds.Tables[0].Rows[0]["ctipodocument"].ToString().Trim();
                        if (_Ds_DataSet.Tables[0].Rows.Count == 1)
                        {
                            _Txt_Tipo.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                            _Txt_Documento.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString().Trim();
                            _Pnl_SoloDocumento.Visible = true;
                            _Pnl_VariosDocument.Visible = false;
                        }
                        else
                        {
                            _Mtd_CargarListBox(_Lbx_Documents, _Ds_DataSet);
                            foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                            {
                                string[] _Str_T = _Dtw_Item[1].ToString().Trim().Split('-');
                                _Txt_Documento.Text = _Str_T[1];
                                _Txt_Tipo.Text = _Str_T[0];
                                break;
                            }
                            _Pnl_SoloDocumento.Visible = false;
                            _Pnl_VariosDocument.Visible = true;
                            _Lbx_Documents.SelectedIndex = -1;
                        }

                        //Sprint 1 -Ignacio- -29-04-2014- 

                        var _Str_cvendedorguardado = _Ds.Tables[0].Rows[0]["cvendedor"].ToString().Trim();
                        _Str_Vendedor = _Str_cvendedorguardado == "" ? Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["cvendedor"].Value).Trim() : _Str_cvendedorguardado;
                        _Str_Cadena = "Select cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Str_Vendedor + "'";
                        var _Ds_Vendedor = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds_Vendedor.Tables[0].Rows.Count > 0)
                        {
                            _Txt_Vendedor.Text = _Ds_Vendedor.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            _Txt_Vendedor.Text = "CREADO POR OFICINA";
                        }

                        if (_Str_Vendedor == "")
                        {
                            MessageBox.Show("Hubo un problema al obtener el vendedor, por favor mande un ticket con la captura de este error...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Sprint 1 -Ignacio- -29-04-2014-


                        _Str_TipoCob = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ctipocobro"].Value).Trim();
                        _Str_Cliente = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value).Trim();
                        _Txt_Cliente.Text = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["Cliente"].Value).Trim();
                        _Str_NumCuentaDeposito = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["cnumcuentadepo"].Value).Trim();
                        _Str_BancoDeposito = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["cbancodepo"].Value).Trim();
                        _Txt_FechaEmision.Text = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["Fecha de Emisión"].Value).Trim();
                        _Txt_Monto.Text = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["Monto Cheque"].Value).Trim();

                        _Txt_Banco.Tag = Convert.ToString(_Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells["cbancocheque"].Value).Trim();
                        if (Convert.ToString(_Txt_Banco.Tag).Trim().Length > 0)
                        {
                            _Str_Cadena = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Txt_Banco.Tag).Trim() + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Txt_Banco.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                            }
                        }
                        _Txt_FechaDevolucion.Text = "";
                        _Txt_NotaDebBanc.Text = "";
                        _Txt_Ob.Text = "";
                        _Txt_Ob.Enabled = false;
                        _Txt_NotaDebBanc.Enabled = false;
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.SelectedIndex = -1;
                        _Cmb_Motivo.Focus();
                        _Mtd_MostrarDescuentosFinan();
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar el banco para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void _Mtd_MostrarDescuentosFinan()
        {
            double _Dbl_PorcDescFinanc=0;
            if (_Pnl_SoloDocumento.Visible)
            {
                _Dbl_PorcDescFinanc = _Mtd_MontDescFin_2(_Str_Cliente, _Str_TipoDoc, _Txt_Documento.Text.Trim());
                _Lbx_DescuentoPP.Items.Add(_Str_TipoDoc + " - " + _Txt_Documento.Text.Trim() + " - Bs. " + _Dbl_PorcDescFinanc.ToString("#,##0.00"));

            }
            else if (_Pnl_VariosDocument.Visible)
            {
                int _Int_Cont_DPP = 0;
                foreach (object _Obj_Ob in _Lbx_Documents.Items)
                {
                    string[] _Str_Value_ = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                    string[] _Str_T = ((T3.Clases._Cls_ArrayList)_Obj_Ob).Display.ToString().Split('-');
                    //((T3.Clases._Cls_ArrayList)_Obj_Ob).Value;
                    string[] _Str_Value = _Mtd_DescuentoPP(_Str_T[0], _Str_T[1], _Str_Value_[1]).Split('-');//((T3.Clases._Cls_ArrayList)_Obj_Ob).Value.ToString().Split('-');
                    _Dbl_PorcDescFinanc = Convert.ToDouble(_Str_Value[0].Replace(".", ","));
                    _Lbx_DescuentoPP.Items.Add(_Str_T[0]+" - "+  _Str_T[1]+ " - Bs. " +_Dbl_PorcDescFinanc.ToString("#,##0.00"));
                    _Int_Cont_DPP++;
                }
            }
        }
        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            {
                _Txt_FechaDevolucion.Text = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
                _Txt_NotaDebBanc.Text = "";
                _Txt_Ob.Text = "";
                _Txt_Ob.Enabled = true;
                _Txt_NotaDebBanc.Enabled = true;
                _Chk_NDDesc.Enabled = true;
            }
            else
            {
                _Txt_FechaDevolucion.Text = "";
                _Txt_Ob.Text = "";
                _Txt_Ob.Enabled = false;
                _Txt_NotaDebBanc.Text = "";
                _Txt_NotaDebBanc.Enabled = false;
                _Chk_NDDesc.Checked = false;
                _Chk_NDDesc.Enabled = false;
            }
        }

        private void _Txt_NotaDebBanc_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_NotaDebBanc.Text))
            {
                _Txt_NotaDebBanc.Text = "";
            }
        }

        private void _Txt_NotaDebBanc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                DataSet _Ds_Temp = new DataSet();
                string _Str_Cadena = "Select * from TCHEQDEVUELT where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidcheqdevuelt='" + _Dg_Grid.Rows[e.RowIndex].Cells["cidcheqdevuelt"].Value + "' and cnumcheque='" + _Dg_Grid.Rows[e.RowIndex].Cells["cnumcheque"].Value + "' and ccliente='" + _Dg_Grid.Rows[e.RowIndex].Cells["ccliente"].Value + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Id.Text = _Ds.Tables[0].Rows[0]["cidcheqdevuelt"].ToString();
                    _Txt_Banco.Tag = _Ds.Tables[0].Rows[0]["cbancocheque"].ToString().Trim();
                    _Str_Cadena = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Txt_Banco.Tag.ToString() + "'";
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Txt_Banco.Text = _Ds_A.Tables[0].Rows[0]["cname"].ToString().Trim();
                    }
                    _Txt_NumeroCheq.TextChanged -= new EventHandler(_Txt_NumeroCheq_TextChanged);
                    _Txt_NumeroCheq.Text = _Ds.Tables[0].Rows[0]["cnumcheque"].ToString();
                    _Txt_NumeroCheq.TextChanged += new EventHandler(_Txt_NumeroCheq_TextChanged);
                    _Str_Cliente = _Ds.Tables[0].Rows[0]["ccliente"].ToString();
                    _Str_Cadena = "Select c_nomb_comer from TCLIENTE where cgroupcomp='"+Frm_Padre._Str_GroupComp+"' and ccliente='" + _Str_Cliente + "'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    { _Txt_Cliente.Text = _Ds_Temp.Tables[0].Rows[0][0].ToString(); }
                    _Str_Vendedor = _Ds.Tables[0].Rows[0]["cvendedor"].ToString();
                    _Str_Cadena = "Select cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Str_Vendedor + "'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Temp.Tables[0].Rows.Count > 0)
                    { _Txt_Vendedor.Text = _Ds_Temp.Tables[0].Rows[0][0].ToString(); }
                    else
                    { _Txt_Vendedor.Text = "CREADO POR OFICINA"; }
                    _Txt_FechaEmision.Text = _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]));
                    _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["cmontocheq"].ToString();
                    _Str_TipoDoc = _Ds.Tables[0].Rows[0]["ctipodocument"].ToString();
                    _Str_Cadena = "Select cname from TDOCUMENT where ctdocument='" + _Str_TipoDoc + "'";
                    _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    DataSet _Ds_DataSet = _Mtd_DocumentosCheq(_Txt_NumeroCheq.Text, _Str_Cliente, _Txt_Banco.Tag.ToString(), Frm_Padre._Str_Comp);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 1)
                    {
                        _Mtd_CargarListBox(_Lbx_Documents, _Ds_DataSet);
                        foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                        {
                            string[] _Str_T = _Dtw_Item[1].ToString().Trim().Split('-');
                            _Txt_Documento.Text = _Str_T[1];
                            _Txt_Tipo.Text = _Str_T[0];
                            break;
                        }
                        _Pnl_SoloDocumento.Visible = false;
                        _Pnl_VariosDocument.Visible = true;
                    }
                    else
                    {
                        if (_Ds_Temp.Tables[0].Rows.Count > 0)
                        { _Txt_Tipo.Text = _Ds_Temp.Tables[0].Rows[0][0].ToString(); }
                        _Txt_Documento.Text = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Pnl_SoloDocumento.Visible = true;
                        _Pnl_VariosDocument.Visible = false;
                    }
                    _Cmb_Motivo.SelectedIndexChanged -= new EventHandler(_Cmb_Motivo_SelectedIndexChanged);
                    _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["cidmotivo"].ToString().Trim();
                    _Cmb_Motivo.SelectedIndexChanged += new EventHandler(_Cmb_Motivo_SelectedIndexChanged);
                    _Cmb_BancoDev.SelectedIndexChanged -= new EventHandler(_Cmb_BancoDev_SelectedIndexChanged);
                    _Cmb_BancoDev.SelectedValue = _Ds.Tables[0].Rows[0]["cbancochequedev"];
                    _Cmb_BancoDev.SelectedIndexChanged += new EventHandler(_Cmb_BancoDev_SelectedIndexChanged);
                    _Txt_FechaDevolucion.Text = _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadevcheq"]));
                    _Txt_Ob.Text = _Ds.Tables[0].Rows[0]["cobservacion"].ToString();
                    _Txt_NotaDebBanc.Text = _Ds.Tables[0].Rows[0]["cbanconddev"].ToString();
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cqdescuentfinan"]) == "1")
                    {
                        _Chk_NDDesc.Checked = true;
                        _Txt_NotaDeb.Text = _Ds.Tables[0].Rows[0]["cidnotadebitocc"].ToString();
                    }
                    else
                    {
                        _Chk_NDDesc.Checked = false;
                    }
                    _Mtd_Deshabilitar_Todo();
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                    _Tb_Tab.SelectedIndex = 1;
                    _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                    _Bt_NotaDeb.Enabled = true;
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_NotaDeb_Click(object sender, EventArgs e)
        {
            if (_Txt_NotaDeb.Text.Trim().Length > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Frm_NotaDebitoCxC _Frm = new Frm_NotaDebitoCxC(_Txt_NotaDeb.Text.Trim(), this.MdiParent);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("No posee nota de débito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void Frm_IngCheqDevuelto_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //____________________________________________
            if (_Txt_Id.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void Frm_IngCheqDevuelto_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        
        private string _Mtd_ComprobContabND(string _Pr_Str_ND)
        {
            string _Str_Comprob = _MyUtilidad._Mtd_Proceso_P_CXC_ND(_Pr_Str_ND, 1);
            return _Str_Comprob;
        }

        private bool _Mtd_PrintComprob(string _Pr_Str_Comprob)
        {
            bool _Bol_R = false;
            Etiq_Print:
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm_A = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_Comprob + "'", _Print, true);
                    if (MessageBox.Show("Se imprimió correctamente el comprobante", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_Comprob + "'");
                        _Bol_R = true;
                    }
                    else
                    {
                        goto Etiq_Print;
                    }
                    this.Cursor = Cursors.Default;
                }
                catch
                {
                    MessageBox.Show("Problemas al contactar la impresora.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_R = false;
                }
            }
            return _Bol_R;
        }

        private void _Mtd_ActualizarSaldoCliente(string _Pr_Str_DevCheqID)
        {
            string _Str_Fpago = "";
            string _Str_TpoDocFact = "";
            string _Str_TpoDocND = "";
            string _Str_TpoDocCheqDev = "";
            string _Str_cdiasvencfact = "";
            string _Str_cfelimitcobro = "";
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoSimp = 0;
            string _Str_Sql = "SELECT cfpagocheqdev,ctipdoccheqdev,ctipdocfact,ctipdocnotdeb FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds= Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Fpago = Convert.ToString(_Ds.Tables[0].Rows[0]["cfpagocheqdev"]);
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_TpoDocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]);
                _Str_TpoDocCheqDev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]);
            }
            _Str_Sql = "SELECT cdias FROM TFPAGO WHERE cfpago='" + _Str_Fpago + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cdias"]) != "")
                {
                    _Str_cdiasvencfact = Convert.ToString(_Ds.Tables[0].Rows[0]["cdias"]);
                }
                else
                { _Str_cdiasvencfact = "0"; }
            }
            else
            {
                _Str_cdiasvencfact = "0";
            }

            _Str_cfelimitcobro = _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(Convert.ToDouble(_Str_cdiasvencfact)));

            _Str_Sql = "SELECT cmontocheq FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + _Pr_Str_DevCheqID + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontocheq"]);
                _Dbl_MontoSimp = _Dbl_MontoTot;
            }

            _Str_Sql = "INSERT INTO TSALDOCLIENTED (cgroupcomp,ccompany,ccliente,ctipodocument,cnumdocu,cfechafact,cfpago,cmontofactci,cmontofactsi,csaldofactura,cdiasvencfact,cdescppago,cactivo,cdateadd,cuseradd,cdelete,csaldofacturasi,cfechaentrega,cfelimitcobro) values" +//Antes del 12/11/2008 en cfelimitcobro se guardaba el valor de _Str_cdiasvencfact ahora fue cambiado por la fecha actual
            "('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Cliente + "','" + _Str_TpoDocCheqDev + "','" + _Txt_NumeroCheq.Text + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Fpago + "','" + _Dbl_MontoTot.ToString().Replace(".", "").Replace(",", ".") + "','" + _Dbl_MontoSimp.ToString().Replace(".", "").Replace(",", ".") + "','" + _Dbl_MontoTot.ToString().Replace(",", ".") + "','" + _Str_cdiasvencfact + "',0,1,'" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0," + _Dbl_MontoTot.ToString().Replace(".", "").Replace(",", ".") + ",'" + _Txt_FechaEmision.Text + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

            //Se ingresa el cheque devuelto en el movimiento de documentos.
            _Str_Sql = "INSERT INTO TMOVDOCUMENTOS(ccompany,ctipodocument,cnumdocu,ccliente,cfechaact,cvendedor,cfechadocument,cfechalimitecobro) VALUES ";
            _Str_Sql += "('" + Frm_Padre._Str_Comp + "','" + _Str_TpoDocCheqDev + "','" + _Txt_NumeroCheq.Text + "','" + _Str_Cliente + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Vendedor + "','" + _Txt_FechaEmision.Text + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Cmb_BancoDev.Enabled & e.TabPageIndex != 0)
            { e.Cancel = true; }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

        private void _Cmb_BancoDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cmb_BancoDev,"");
            if (_Cmb_BancoDev.SelectedIndex > 0)
            {
                _Txt_Cliente.Text = "";
                _Txt_Documento.Text = "";
                _Txt_FechaDevolucion.Text = "";
                _Txt_FechaEmision.Text = "";
                _Txt_Monto.Text = "";
                _Txt_Tipo.Text = "";
                _Txt_Vendedor.Text = "";
                _Txt_NotaDebBanc.Text = "";
                _Txt_Ob.Text = "";
                _Txt_Ob.Enabled = false;
                _Txt_NotaDebBanc.Enabled = false;
                _Bt_Buscar.Enabled = true;
                _Cmb_Motivo.Enabled = false;
                _Cmb_Motivo.SelectedIndex = -1;
            }
            else
            {
                _Txt_Cliente.Text = "";
                _Txt_Documento.Text = "";
                _Txt_FechaDevolucion.Text = "";
                _Txt_FechaEmision.Text = "";
                _Txt_Monto.Text = "";
                _Txt_NumeroCheq.Text = "";
                _Txt_Tipo.Text = "";
                _Txt_Vendedor.Text = "";
                _Txt_NotaDebBanc.Text = "";
                _Txt_Ob.Text = "";
                _Txt_Ob.Enabled = false;
                _Txt_NumeroCheq.Enabled = false;
                _Txt_NotaDebBanc.Enabled = false;
                _Cmb_Motivo.Enabled = false;
            }
        }
        private void _Mtd_LimpiarND()
        {
            _Rbt_Porcent1.Checked = true;
            _Rbt_Porcent3.Checked = false;            
        }
        private void _Chk_NDDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_NDDesc.Checked)
            {
                _Pnl_ND_Desc.Visible = true;
                _Mtd_LimpiarND();
            }
            else
            {
                _Pnl_ND_Desc.Visible = false;
                _Mtd_LimpiarND();
            }
        }
    }
}