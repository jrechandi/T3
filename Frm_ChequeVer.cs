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
    public partial class Frm_ChequeVer : Form
    {
        /// <summary>
        /// Método que permite cancelar los avisos de cobros de las ordenes de pagos por concepto otros pagos.
        /// <param name="_P_Str_OP">Número de la orden de pago.</param>
        /// </summary>
        private void _Mtd_CancelarAvisosCobros(string _P_Str_OP)
        {
            string _Str_SQL;

            // 1. Verificamos si la orden de pago es por concepto otros pagos.

            _Str_SQL = "SELECT *";
            _Str_SQL += " FROM TPAGOSCXPM";
            _Str_SQL += " WHERE cotrospago=1";
            _Str_SQL += " AND ctipotrospago=13";
            _Str_SQL += " AND cidordpago='" + _P_Str_OP + "'";
            _Str_SQL += " AND ccompany='" + Frm_Padre._Str_Comp + "';";

            DataSet _Ds_Datos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Datos.Tables[0].Rows.Count > 0)
            {
                // 2. Actualizamos los avisos de cobros.

                _Str_SQL = "UPDATE TAVISOPAGM";
                _Str_SQL += " SET cestado=1";
                _Str_SQL += " WHERE cidordpago='" + _P_Str_OP + "'";
                _Str_SQL += " AND ccompany='" + Frm_Padre._Str_Comp + "';";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
        }

        public Frm_ChequeVer()
        {
            InitializeComponent();
        }
        Frm_EmisionCheque _Frm_EmisionCheque;
        public Frm_ChequeVer(Frm_EmisionCheque _P_Frm)
        {
            InitializeComponent();
            _Frm_EmisionCheque = _P_Frm;
        }
        public string _Str_CheqTrans = "";
        public string _Str_NumCuenta = "";
        public string _Str_Banco = "";
        public string _Str_OrdPago = "";
        public string _Str_FormaPago = "";
        string _Str_Proveedor = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private void Frm_ChequeVer_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Cheque.Left = (this.Width / 2) - (_Pnl_Cheque.Width / 2);
            _Pnl_Cheque.Top = (this.Height / 2) - (_Pnl_Cheque.Height / 2);
            _Pnl_Transferencia.Left = (this.Width / 2) - (_Pnl_Transferencia.Width / 2);
            _Pnl_Transferencia.Top = (this.Height / 2) - (_Pnl_Transferencia.Height / 2);
            //CARGO EL LOGO DEL BANCO
            switch (_Str_Banco)
            {
                case "1": //BANCO PROVINCIAL
                    _PBox.Image = T3.Properties.Resources.logo_provincial;
                    break;
                case "2": //BANCO BANESCO
                    _PBox.Image = T3.Properties.Resources.logo_Banesco;
                    break;
                case "5": //BANCO VENEZUELA
                    _PBox.Image = T3.Properties.Resources.logo_venezuela;
                    break;
                case "7": //BANCO MERCANTIL
                    _PBox.Image = T3.Properties.Resources.logo_mercantil;
                    break;
                case "13": //BANCO EXTERIOR
                    _PBox.Image = T3.Properties.Resources.logo_exterior;
                    break;
                case "16": //BANCO CARONI
                    _PBox.Image = T3.Properties.Resources.logo_caroni;
                    break;
                case "18": //BANCO SOFITASA
                    _PBox.Image = T3.Properties.Resources.logo_sofitasa;
                    break;
                case "21": //BANCO BNC
                    _PBox.Image = T3.Properties.Resources.logo_bnc;
                    break;
                case "24": //BANCO DEL SUR
                    _PBox.Image = T3.Properties.Resources.logo_bancodelsur;
                    break;
                case "29": //BANCO B.O.D
                    _PBox.Image = T3.Properties.Resources.logo_bod;
                    break;
                case "34": //BANCO MI CASA
                    _PBox.Image = T3.Properties.Resources.Logo_Micasa;
                    break;
                case "36": //BANCO GUAYANA
                    _PBox.Image = T3.Properties.Resources.logo_guayana;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// COLOCA EL MONTO DEPENDIENDO DE LA MEDIDA DEL TEXTO PARA LA IMPRESION
        /// </summary>
        /// <param name="_Pr_Str_Monto"></param>
        public void _Mtd_RedimMontoTxt(string _Pr_Str_Monto)
        {
            string _Str_Texto = "";
            string _Str_TextoR = "";
            int _Int_C = 0;
            Graphics f = panel1.CreateGraphics();
            Font myFuente = new Font(_Txt_MontoDA.Font.FontFamily.Name, 8);

            string[] _Str_Cad;
            char[] delimiterChars = { ' ' };
            _Str_Cad = _Pr_Str_Monto.Split(delimiterChars);
            foreach (string _Str_A in _Str_Cad)
            {
                _Str_Texto = _Str_Texto + _Str_A + " ";
                if (f.MeasureString(_Str_Texto, myFuente).Width <= _Txt_MontoDA.Width)
                {
                    _Txt_MontoDA.Text = _Str_Texto;
                }
                else
                {
                    if (_Str_TextoR == "")
                    {
                        _Str_TextoR = _Str_Cad[_Int_C];
                    }
                    else
                    {
                        _Str_TextoR = _Str_TextoR + " " + _Str_A ;
                    }
                    _Txt_MontoDB.Text = _Str_TextoR;
                }
                _Int_C++;
            }

        }

        private void Frm_ChequeVer_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        bool _Bol_Cerrar = false;
        private void Frm_ChequeVer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Bol_Cerrar)
            {
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
            else if (!_Bt_Print.Enabled & !_Pnl_Clave.Visible)
            { e.Cancel = true; }
        }

        private void _Bt_Print_Click(object sender, EventArgs e)
        {
            if (!_Pnl_Cheque.Visible & !_Pnl_Clave.Visible)
            {
                string _Str_Sql = "";
                if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) != "" & ((_Str_FormaPago == "CHEQ" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_IMP")) | (_Str_FormaPago == "TRANSF" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_TRANSF_IMP"))))
                {
                    _Str_Sql = "SELECT * FROM TEMICHEQTRANSM WHERE cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND cimpimiocheq=0 AND cidemisioncheq='" + _Str_CheqTrans + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'";
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Bt_Print.Enabled = false;
                        if (_Str_FormaPago == "CHEQ")
                        { _Lbl_TituloClave.Text = "Impresión de Cheque"; }
                        else if (_Str_FormaPago == "TRANSF")
                        { _Lbl_TituloClave.Text = "Impresión de Transferencia"; }
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Text = "";
                        _Txt_Clave.Focus();
                    }
                    else
                    { MessageBox.Show("El cheque todavía no puede ser impreso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else
                { MessageBox.Show("Usted no está autorizado a Imprimir este Cheque.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Bt_Print.Enabled = true;
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            if (myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Mtd_ProcesoTerminado())
                {
                    MessageBox.Show("El proceso ha sido culminado por otro usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Bol_Cerrar = true;
                    this.Close();
                }
                else
                {
                    _Pnl_Clave.Visible = false;
                    _Bt_Print.Enabled = false;
                    if (_Str_FormaPago == "CHEQ")
                    { _Mtd_ImprimirCheq(""); }
                    else
                    { _Mtd_ImprimirTransf(); }
                }
            }
            else
            {
                MessageBox.Show("Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
                _Txt_Clave.Focus();
            }
        }
        private string _Mtd_ProxNumCheq(string _P_Str_Banco, string _P_Str_NumCuenta)
        {
            string _Str_Cadena = "SELECT TOP 1 TCHEQUERAD.cnumcheque FROM TCHEQUERAM INNER JOIN TCHEQUERAD ON TCHEQUERAM.cgroupcomp = TCHEQUERAD.cgroupcomp AND TCHEQUERAM.ccompany = TCHEQUERAD.ccompany AND TCHEQUERAM.cidchequera = TCHEQUERAD.cidchequera WHERE (TCHEQUERAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TCHEQUERAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCHEQUERAM.cbanco='" + _P_Str_Banco + "') AND (TCHEQUERAM.cnumcuentad='" + _P_Str_NumCuenta + "') AND (TCHEQUERAD.cimpreso='0' OR TCHEQUERAD.cimpreso IS NULL) AND (TCHEQUERAD.canulado='0' OR TCHEQUERAD.canulado IS NULL) AND (TCHEQUERAM.cactiva='1') ORDER BY TCHEQUERAD.cnumcheque ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            
            return "";
        }
        private string _Mtd_ProxNumTransf(string _P_Str_Banco)
        {
            string _Str_Cadena = "Select cproxnumTransf FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cnumcuenta='" + _Str_NumCuenta.ToString() + "'";
            return myUtilidad._Mtd_Correlativo(_Str_Cadena);
        }
        private string _Mtd_ObtenerIDChequera(string _P_Str_Banco, string _P_Str_NumCuenta, string _P_Str_NumCheque)
        {
            string _Str_Cadena = "SELECT cidchequera FROM TCHEQUERAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cnumcuentad='" + _P_Str_NumCuenta + "' AND '" + _P_Str_NumCheque + "' BETWEEN cnumcheqdesde AND cnumcheqhasta";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_ActualizarCheque(string _P_Str_IDChequera, string _P_Str_IDCheque, bool _P_Bol_Impreso)
        {
            string _Str_Cadena = "";
            if (_P_Bol_Impreso)
            { _Str_Cadena = "UPDATE TCHEQUERAD SET cimpreso='1',cfechaimpreso=GETDATE(),cuserimpreso='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "' AND cnumcheque='" + _P_Str_IDCheque + "'"; }
            else
            { _Str_Cadena = "UPDATE TCHEQUERAD SET canulado='1',cfechanulado=GETDATE(),cuseranulado='" + Frm_Padre._Str_Use + "',cobservacionanul='DESDE IMPRESIÓN DE CHEQUES' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "' AND cnumcheque='" + _P_Str_IDCheque + "'"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private string _Mtd_DiasCaduca()
        {
            string _Str_Cadena = "SELECT cdiascaducacheq FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return "CADUCA A LOS " + _Ds.Tables[0].Rows[0][0].ToString().Trim() + " DÍAS";
            }
            return "";
        }
        string _Str_TempProx = "";
        private void _Mtd_ImprimirCheq(string _P_Str_ProxNumCheq)
        {
            try
            {
                bool _Bol_CierreAuto = false;
                string _Str_Fact = "";
                string _Str_Sql = "";
                PrintDialog _Print = new PrintDialog();
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact from TCONFIGCXP where ccompany='" + Frm_Padre._Str_Comp + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                }
                bool _Bol_Sw = false;
                _Str_Sql = "SELECT cncppp FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _Str_Fact + "' AND cmontoddpp<>0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    if (Convert.ToString(_DRow[0]).Trim().Length > 0)
                    {
                        if (!myUtilidad._Mtd_VerificarNDImpresa(Convert.ToString(_DRow[0]), _Str_Proveedor))
                        {
                            _Bol_Sw = true;
                            break;
                        }
                    }
                }
                if (!_Bol_Sw)
                {
                    string _Str_cproxnumcheq = "";
                    if (_P_Str_ProxNumCheq.Trim().Length == 0)
                    {
                        _Str_cproxnumcheq = _Mtd_ProxNumCheq(_Str_Banco.Trim(), _Str_NumCuenta.Trim());
                        if (_Str_cproxnumcheq.Trim().Length == 0)
                        {
                            MessageBox.Show("No existen números de cheque disponibles. Debe agregar una nueva chequera.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Bol_CierreAuto = true;
                        }
                        else
                        {
                            _Str_Sql = "SELECT TEMICHEQTRANSM.cnumcheqtransac FROM TEMICHEQTRANSM INNER JOIN TPAGOSCXPM ON TEMICHEQTRANSM.cgroupcomp=TPAGOSCXPM.cgroupcomp AND TEMICHEQTRANSM.ccompany=TPAGOSCXPM.ccompany AND TEMICHEQTRANSM.cidordpago=TPAGOSCXPM.cidordpago WHERE TEMICHEQTRANSM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TEMICHEQTRANSM.ccompany='" + Frm_Padre._Str_Comp + "' AND LTRIM(RTRIM(TEMICHEQTRANSM.cbanco))='" + _Str_Banco.Trim() + "' AND LTRIM(RTRIM(TEMICHEQTRANSM.cnumcuentad))='" + _Str_NumCuenta.Trim() + "' AND TEMICHEQTRANSM.cnumcheqtransac='" + _Str_cproxnumcheq.Trim() + "' AND TPAGOSCXPM.cfpago='CHEQ' AND cimpimiocheq=1";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("El próximo cheque a imprimir es el número '" + _Str_cproxnumcheq.Trim() + "' y ya ha sido utilizado anteriormente.\nPor favor verifique...", "Número de cheque repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Bol_CierreAuto = true;
                            }
                        }
                    }
                    else
                    {
                        _Str_cproxnumcheq = _P_Str_ProxNumCheq;
                    }
                    if (!_Bol_CierreAuto)
                    {
                        _Str_TempProx = _Str_cproxnumcheq;
                        if (MessageBox.Show("¿Esta seguro de imprimir el cheque número: " + _Str_cproxnumcheq + " ?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //____________________________________________________________
                            DataSet2.dt_chequeDataTable _Dt_My = new DataSet2.dt_chequeDataTable();
                            _Dt_My.Rows.Add();
                            _Dt_My.Rows[0]["cnumcheque"] = "";
                            _Dt_My.Rows[0]["cmontonum"] = _Txt_Monto.Text.Trim().Replace("*", "x");
                            _Dt_My.Rows[0]["cpersona"] = _Txt_Persona.Text.Trim();
                            _Dt_My.Rows[0]["cmontodescrip"] = _Txt_MontoDA.Text.Trim();
                            _Dt_My.Rows[0]["cmontodescrip1"] = _Txt_MontoDB.Text.Trim();
                            _Dt_My.Rows[0]["cfecha1"] = _Txt_FechaA.Text.Trim();
                            _Dt_My.Rows[0]["cfecha2"] = _Txt_FechaB.Text.Trim();
                            _Dt_My.Rows[0]["ccaduca"] = _Mtd_DiasCaduca();
                            _Dt_My.AcceptChanges();
                            Cursor = Cursors.WaitCursor;
                            if (_Str_Banco == "1") //BANCO PROVINCIAL
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeBBVA(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "2") //BANCO BANESCO
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeBANESCO(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "5") //BANCO VENEZUELA
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeVENEZUELA(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "7") //BANCO MERCANTIL
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeMERCANTIL(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "13") //BANCO EXTERIOR
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeEXTERIOR(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "16") //BANCO CARONI
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeCaroni(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "18") //BANCO SOFITASA
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeSOFITASA(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "21") //BANCO BNC
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeBNC(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "24") //BANCO DEL SUR
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeDSUR(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "29") //BANCO B.O.D
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeBOD(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "34") //BANCO MI CASA
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeMICASA(), _Dt_My, _Print, "Section2");
                            }
                            if (_Str_Banco == "36") //BANCO GUAYANA
                            {
                                REPORTESS _Frm = new REPORTESS(new T3.Report.rChequeGuayana(), _Dt_My, _Print, "Section2");
                            }
                            Cursor = Cursors.Default;
                            //---------------------ACTUALIZAR NUMERO DE CHEQUE
                            if (_P_Str_ProxNumCheq.Trim().Length == 0)
                            {
                                _Str_Sql = "UPDATE TEMICHEQTRANSM SET cnumcheqtransac='" + _Str_cproxnumcheq + "',cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "UPDATE TCUENTBANC SET cproxnumcheq='" + _Str_cproxnumcheq + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Str_Banco + "' AND cnumcuenta='" + _Str_NumCuenta.ToString() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                            if (MessageBox.Show("¿El cheque fue impreso correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Mtd_ActualizarCheque(_Mtd_ObtenerIDChequera(_Str_Banco, _Str_NumCuenta.Trim(), _Str_cproxnumcheq), _Str_cproxnumcheq, true);
                                _Mtd_ImpresoCorrectamenteCheq();
                            }
                            else
                            {
                                _Bt_Salir.Enabled = false;
                                _Bt_ReImp.Enabled = true;
                                _Pnl_Cheque.Visible = true;
                            }

                        }
                        else
                        {
                            _Bt_Salir.Enabled = true;
                            _Bt_ReImp.Enabled = false;
                            _Pnl_Cheque.Visible = true;
                        }
                    }
                    else
                    {
                        _Bol_Cerrar = true;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Existen Notas de Débito por Imprimir por descuentos por pronto pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.Runtime.InteropServices.COMException _Ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al intentar imprimir.\nPor favor reinicie su computador y vuelve a intentarlo. Gracias.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Bol_Cerrar = true;
                this.Close();
            }
            catch (Exception _Ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al intentar imprimir. " + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Bol_Cerrar = true;
                this.Close();
            }
        }
        private void _Mtd_ImprimirTransf()
        {
            try
            {
                string _Str_Fact = "";
                string _Str_Sql = "";
                PrintDialog _Print = new PrintDialog();
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact from TCONFIGCXP where ccompany='" + Frm_Padre._Str_Comp + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                }
                bool _Bol_Sw = false;
                _Str_Sql = "SELECT cncppp FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _Str_Fact + "' AND cmontoddpp<>0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    if (Convert.ToString(_DRow[0]).Trim().Length > 0)
                    {
                        if (!myUtilidad._Mtd_VerificarNDImpresa(Convert.ToString(_DRow[0]), _Str_Proveedor))
                        {
                            _Bol_Sw = true;
                            break;
                        }
                    }
                }
                if (!_Bol_Sw)
                {
                    if (MessageBox.Show("¿Esta seguro de imprimir la transferencia?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //Verificamos si NO esta marcadado como impreso 
                        _Str_Sql = "SELECT cimpimiocheq FROM TEMICHEQTRANSM WHERE cimpimiocheq=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=0 AND cidordpago='" + _Str_OrdPago + "'";
                        DataSet _Ds_V = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_V.Tables[0].Rows.Count > 0) 
                        {
                            if (_Str_TempProx.Trim().Length == 0)
                            { _Str_TempProx = _Mtd_ProxNumTransf(_Str_Banco.Trim()); }
                            //-----------------
                            _Str_Sql = "UPDATE TEMICHEQTRANSM SET cnumcheqtransac='" + _Str_TempProx + "',cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            _Str_Sql = "UPDATE TCUENTBANC SET cproxnumTransf='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Str_Banco + "' AND cnumcuenta='" + _Str_NumCuenta.ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            //-----------------
                            _Mtd_Transferencia(_Str_TempProx);
                            if (MessageBox.Show("¿La transferencia fue impresa correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Mtd_ImpresoCorrectamenteTranf();
                            }
                            else
                            {
                                _Bt_SalirT.Enabled = true;
                                _Bt_ReImpT.Enabled = true;
                                _Pnl_Transferencia.Visible = true;
                            }
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("La transferencia ya había sido marcada como impresa.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Frm_EmisionCheque._Mtd_Cancelar();
                            _Frm_EmisionCheque._Mtd_CargarBusqueda();
                            _Frm_EmisionCheque._Tb_Tab.SelectedIndex = 0;
                            _Bol_Cerrar = true;
                            this.Close();
                        }
                    }
                    else
                    {
                        _Bt_SalirT.Enabled = true;
                        _Bt_ReImpT.Enabled = true;
                        _Pnl_Transferencia.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Existen Notas de Débito por Imprimir por descuentos por pronto pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception _Ex) { MessageBox.Show("Error al intentar imprimir. " + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Cursor = Cursors.Default; _Bol_Cerrar = true; this.Close(); }
        }
        private void _Mtd_AnularNum_Reimrpimir()
        {
            string _Str_Cadena = "Select Max(cidemisioncheq) FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            string _Str_OrdId = myUtilidad._Mtd_Correlativo(_Str_Cadena);
            _Str_Cadena = "INSERT INTO TEMICHEQTRANSM (cgroupcomp, ccompany, cidordpago, cidemisioncheq, cbanco, cnumcuentad, cnumcheqtransac, cusersolicitante, cfusersolicitante, cuserfirmante1, " +
                                 "cfuserfirmante1, cuseraprobador, cfuseraprobador, cconcepto, cidcomprob, cpagarse, ccantidadletras, cfechaemision, cimpimiocheq, cuserimprime, " +
                                 "cfechaimprimio, canulado, centregado, cpersrecibename, cpersrecibeced) " +
                                 "SELECT cgroupcomp, ccompany, cidordpago, '" + _Str_OrdId + "', cbanco, cnumcuentad, cnumcheqtransac, cusersolicitante, cfusersolicitante, cuserfirmante1, " +
                                 "cfuserfirmante1, cuseraprobador, cfuseraprobador, cconcepto, cidcomprob, cpagarse, ccantidadletras, cfechaemision, cimpimiocheq, cuserimprime, " +
                                 "cfechaimprimio, '1', centregado, cpersrecibename, cpersrecibeced FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Mtd_ImprimirCheq("");
        }
        private string _Mtd_CuentaDelBanco(string _P_Str_Banco, string _P_Str_Cuenta)
        {
            string _Str_Cadena = "SELECT ccount FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cnumcuenta='" + _P_Str_Cuenta + "' AND ISNULL(cdelete,0)=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_AnularCompletamente()
        {
            try
            {
                int _Int_ComprobanteAnul = 0;
                string _Str_Cadena = "SELECT ISNULL(cidcomprob,0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    double _Dbl_MontoCuenta = 0;
                    string _Str_Comprobante = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    _Str_Cadena = "SELECT ISNULL(cmontototal,0) FROM VST_EMICHEQTRANSM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Dbl_MontoCuenta = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                    //CREAR COMPROBANTE ANULACIÓN
                    string _Str_CuentaDelBanco = _Mtd_CuentaDelBanco(_Str_Banco, _Str_NumCuenta);
                    _Int_ComprobanteAnul = myUtilidad._Mtd_Consecutivo_TCOMPROBANC();
                    _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus,csistema) SELECT ccompany,'" + _Int_ComprobanteAnul + "',ctypcomp,cname,'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoCuenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoCuenta) + "','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','0','1' FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    if (_Str_CuentaDelBanco.Trim().Length == 0)
                    {
                        throw new Exception("No se obtuvo la cuenta del banco");
                    }
                    _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) SELECT TOP 1 ccompany,'" + _Int_ComprobanteAnul + "','1',ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,'0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',LTRIM(RTRIM(cdescrip)) FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "' AND ccount='" + _Str_CuentaDelBanco + "' AND ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoCuenta) + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) SELECT TOP 1 ccompany,'" + _Int_ComprobanteAnul + "','2',ccount,ctdocument,cnumdocu,cdatedocu,'0',ctothaber,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',LTRIM(RTRIM(cdescrip)) FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "' AND ccount='" + _Str_CuentaDelBanco + "' AND ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoCuenta) + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //CREAR COMPROBANTE ANULACIÓN
                    //<REPLACE>
                    _Str_Cadena = "UPDATE TCOMPROBAND SET cdescrip='CHEQUE # " + _Str_TempProx + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'", "''") + "' +'. ANULACIÓN',cnumdocu='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_ComprobanteAnul + "' AND ccount='" + _Str_CuentaDelBanco + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //<REPLACE>
                    //IMPRIMIR COMPROBANTE DE ANULACIÓN
                    Cursor = Cursors.Default;
                    if (!_Mtd_ImprimirComprobante(_Int_ComprobanteAnul.ToString()))
                    {
                        MessageBox.Show("Debe actualizar el comprobante de anulación desde el notificador 'COMPROBANTES POR ACTUALIZAR'", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_ComprobanteAnul.ToString() + "'");
                    }
                    //IMPRIMIR COMPROBANTE DE ANULACIÓN
                }
            }
            catch (Exception _Ex) { MessageBox.Show("Error al crear el comprobante de anulación. Envíe un control de fallas antes de cerrar esta ventana.\n" + _Ex.Message); }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)_Frm_EmisionCheque.MdiParent)._Frm_Contenedor._async_Default);
            _Frm_EmisionCheque._Mtd_Cancelar();
            _Frm_EmisionCheque._Mtd_CargarBusqueda();
            _Frm_EmisionCheque._Tb_Tab.SelectedIndex = 0;
            _Bol_Cerrar = true;
            this.Close();
        }
        private void _Mtd_Update_DetalleAnticipo(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "SELECT cidordpagoant FROM TPAGOSCXPANT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TPAGOSCXPM SET cidordpagodesc='" + _P_Str_OrdenPago + "',antidescontado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Row[0].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
        }
        private void _Mtd_Delete_DetalleAnticipo(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "DELETE FROM TPAGOSCXPANT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }

        /// <summary>
        /// Salda los documentos CxC de intercompañía.
        /// </summary>
        /// <param name="_P_Str_OrdPago">Id de la orden de pago</param>
        private void _Mtd_SaldarDocumentosCxC(string _P_Str_OrdPago)
        {
            string _Str_Cadena = "select ctipodocument,cnumdocu from TPAGOSCXCD where ccompany='" + Frm_Padre._Str_Comp + "' and cidordpago='" + _P_Str_OrdPago + "' and isnull(cdelete,0)=0";
            DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _DRow in _Ds_DataSet.Tables[0].Rows)
            {
                //N/C, N/D, FACT -> CxC
                if ((_DRow["ctipodocument"].ToString() == "N/C") || (_DRow["ctipodocument"].ToString() == "N/D") || (_DRow["ctipodocument"].ToString() == "FACT"))
                {
                    //Solo N/C CxC
                    if (_DRow["ctipodocument"].ToString() == "N/C")
                    {
                        string _Str_Sql2 = "update TNOTACREDICC set cdescontada=1,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _DRow["cnumdocu"].ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql2);
                    }
                    string _Str_Sql = "update TSALDOCLIENTED set csaldofactura=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _DRow["ctipodocument"].ToString() + "' and cnumdocu='" + _DRow["cnumdocu"].ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                //Solo AVISO CxC (Aviso de Cobro CXC)
                if (_DRow["ctipodocument"].ToString() == "AVISOCXC")
                {
                    string _Str_Sql = "update TAVISOCOBM set cestado=1,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ccodavisocob='" + _DRow["cnumdocu"].ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
        }
        private void _Mtd_ImpresoCorrectamenteCheq()
        {
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            double _Dbl_MontoAux = 0;
            double _Dbl_Saldo = 0;
            double _Dbl_SaldoNew = 0;
            string _Str_Fact = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact from TCONFIGCXP where ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cproveedor from TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Proveedor = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Sql = "UPDATE TEMICHEQTRANSM SET cimpimiocheq=1,cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToShortDateString() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)_Frm_EmisionCheque.MdiParent)._Frm_Contenedor._async_Default);
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprob FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_cidcomprob = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado=1,cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cyearacco='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year + "',cmontacco='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month + "',cregdate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=" + _Str_cidcomprob;
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //<REPLACE>
                _Str_Sql = "UPDATE TCOMPROBAND SET cdescrip='CHEQUE # " + _Str_TempProx + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'", "''") + "',cnumdocu='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "' AND cdescrip LIKE '%<REPLACE>%'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);                
                //<REPLACE>
                if (CLASES._Cls_Varios_Metodos._Mtd_DebitoBancarioCuentaBancaria())
                {
                    //IGTF DEBITO BANCARIO
                    _Str_Sql = "UPDATE TCOMPROBAND SET cdescrip='CARGO POR IGTF DEL CHEQUE # " + _Str_TempProx + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'", "''") + "',cnumdocu='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "' AND cdescrip LIKE '%<REPLACEIGTF>%'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    //IGTF
                }
                _Str_Sql = "UPDATE TPAGOSCXPM SET ccancelado=1,cidemisioncheq='" + _Str_CheqTrans + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_Update_DetalleAnticipo(_Str_OrdPago);
                myUtilidad._Mtd_GenerarNCxDescxPPago(_Str_OrdPago);
                DataSet _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cnumdocu,ctipodocument,cmontocancelar FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "' AND cproveedor='" + _Str_Proveedor + "'");
                foreach (DataRow _DRow in _Ds_B.Tables[0].Rows)
                {//Se actualiza el saldo TFACTPPAGARM.csaldo 
                    if (_Str_Fact == _DRow[1].ToString())
                    {
                        _Dbl_MontoAux = myUtilidad._Mtd_ObtenerMontoAsociadoPago(_Str_OrdPago, _Str_Proveedor, _DRow[0].ToString());
                    }
                    else
                    { _Dbl_MontoAux = 0; }


                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT csaldo FROM TFACTPPAGARM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[0].ToString() + "'");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["csaldo"]) != "")
                        {
                            _Dbl_Saldo = Convert.ToDouble(Convert.ToString(_Ds.Tables[0].Rows[0]["csaldo"]).Replace("-", ""));
                        }
                    }
                    _Dbl_SaldoNew = (_Dbl_Saldo + _Dbl_MontoAux) - (Convert.ToDouble(_DRow["cmontocancelar"]) + _Dbl_MontoAux);
                    _Str_Sql = "UPDATE TFACTPPAGARM SET csaldo=" + _Dbl_SaldoNew.ToString().Replace(",", ".") + ",cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[0].ToString() + "' AND csaldo<>0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    //Se actualiza el saldo TMOVCXPM.csaldo restando (TMOVCXPM.csaldo - TPAGOSCXPD.cmontocancelar)
                    _Str_Sql = "UPDATE TMOVCXPM SET csaldo=" + _Dbl_SaldoNew.ToString().Replace(",", ".") + ",cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[0].ToString() + "' AND csaldo<>0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    //Si hay AVISOS de Cobro CXP los marco como pagados
                    if (_DRow["ctipodocument"].ToString() == "AVISOCXP")
                    {
                        _Str_Sql = "update TAVISOPAGM set cestado=1,csaldo=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ccodavisopag='" + _DRow["cnumdocu"].ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }

                }
                _Mtd_SaldarDocumentosCxC(_Str_OrdPago);
                _Mtd_SaldarRetencionesReposiciones(_Str_OrdPago);
                //IMPRIMO COMPROBANTE DE EGRESO

                string _Str_Cadena = "SELECT cidcomprobcheque FROM VST_COMPROP_CHEQUE_EGRESO WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidemisioncheq='" + _Str_CheqTrans + "' AND cproveedor='" + _Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1',cdateupd=getdate()", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString() + "'");                        
                    }
                }

                MessageBox.Show("Se va a imprimir el comprobante. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrintDialog _Print = new PrintDialog();
            Print:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "VST_COMPROP_CHEQUE_EGRESO" }, "", "T3.Report.rComprobanEgresoCheque", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidemisioncheq='" + _Str_CheqTrans + "' AND cproveedor='" + _Str_Proveedor + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿Se Imprimio correctamente el comprobante?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    { goto Print; }
                    else
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)_Frm_EmisionCheque.MdiParent)._Frm_Contenedor._async_Default);
                    }
                }
                else
                {
                    MessageBox.Show("Puede reimprimir el comprobante desde la consulta de comprobantes contables", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            this._Mtd_CancelarAvisosCobros(_Str_OrdPago);

            _Frm_EmisionCheque._Mtd_Cancelar();
            _Frm_EmisionCheque._Mtd_CargarBusqueda();
            _Frm_EmisionCheque._Tb_Tab.SelectedIndex = 0;
            _Bol_Cerrar = true;
            this.Close();
        }

        /// <summary>
        /// Salda las retenciones de la reposición si esta proviene de una y tiene retenciones cargadas
        /// </summary>
        /// <param name="_P_Str_OrdPago"></param>
        private void _Mtd_SaldarRetencionesReposiciones(string _P_Str_OrdPago)
        {
            var _Str_Sql = "SELECT cidreposiciones FROM TREPOSICIONESM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdPago + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                var _Str_cidreposiciones = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_Sql = "SELECT TREPOSICIONESD.cproveedor, TREPOSICIONESD.ctipodocument, TREPOSICIONESD.cnumdocu " +
                           "FROM TREPOSICIONESD INNER JOIN TCONFIGCXP ON TREPOSICIONESD.ccompany = TCONFIGCXP.ccompany AND (TREPOSICIONESD.ctipodocument = TCONFIGCXP.ctipdocretiva OR TREPOSICIONESD.ctipodocument = TCONFIGCXP.ctipdocretISLR) " +
                           "WHERE TREPOSICIONESD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TREPOSICIONESD.ccompany='" + Frm_Padre._Str_Comp + "' AND TREPOSICIONESD.cidreposiciones='" + _Str_cidreposiciones + "'";
                var _Ds_Retenciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_Retenciones.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _DRow in _Ds_Retenciones.Tables[0].Rows)
                    {
                        //Datos
                        var _Str_Proveedor = _DRow["cproveedor"].ToString();
                        //Saldamos
                        _Str_Sql = "UPDATE TFACTPPAGARM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[2].ToString() + "' AND csaldo<>0";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "UPDATE TMOVCXPM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[2].ToString() + "' AND csaldo<>0";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
            }
        }

        private bool _Mtd_ProcesoTerminado()
        {
            string _Str_Sql = "SELECT cidemisioncheq FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "' AND cimpimiocheq=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private void _Mtd_ImpresoCorrectamenteTranf()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            double _Dbl_MontoAux = 0;
            double _Dbl_Saldo = 0;
            double _Dbl_SaldoNew = 0;
            string _Str_Fact = "";

            //Verificamos si esta marcadado como impreso 
            _Str_Sql = "SELECT cimpimiocheq FROM TEMICHEQTRANSM WHERE cimpimiocheq=1 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=0 AND cidordpago='" + _Str_OrdPago + "'";
            DataSet _Ds_V = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_V.Tables[0].Rows.Count > 0)
            {
                Cursor = Cursors.Default;
                _Frm_EmisionCheque._Mtd_Cancelar();
                _Frm_EmisionCheque._Mtd_CargarBusqueda();
                _Frm_EmisionCheque._Tb_Tab.SelectedIndex = 0;
                _Bol_Cerrar = true;
                this.Close();
                return;
            } //Salimos
        
            //Continuamos el proceso
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact from TCONFIGCXP where ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cproveedor from TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Proveedor = _Ds.Tables[0].Rows[0][0].ToString();
            }
            _Str_Sql = "UPDATE TEMICHEQTRANSM SET cimpimiocheq=1,cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToShortDateString() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)_Frm_EmisionCheque.MdiParent)._Frm_Contenedor._async_Default);
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprob FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_cidcomprob = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado=1,cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=" + _Str_cidcomprob;
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TPAGOSCXPM SET ccancelado=1,cidemisioncheq='" + _Str_CheqTrans + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_Update_DetalleAnticipo(_Str_OrdPago);
                myUtilidad._Mtd_GenerarNCxDescxPPago(_Str_OrdPago);
                DataSet _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cnumdocu,ctipodocument,cmontocancelar FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "' AND cproveedor='" + _Str_Proveedor + "'");
                foreach (DataRow _DRow in _Ds_B.Tables[0].Rows)
                {
                    if (_Str_Fact == _DRow[1].ToString())
                    {
                        _Dbl_MontoAux = myUtilidad._Mtd_ObtenerMontoAsociadoPago(_Str_OrdPago, _Str_Proveedor, _DRow[0].ToString());
                    }
                    else
                    { _Dbl_MontoAux = 0; }
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT csaldo FROM TFACTPPAGARM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[0].ToString() + "'");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["csaldo"]) != "")
                        {
                            _Dbl_Saldo = Convert.ToDouble(Convert.ToString(_Ds.Tables[0].Rows[0]["csaldo"]).Replace("-", ""));
                        }
                    }
                    _Dbl_SaldoNew = (_Dbl_Saldo + _Dbl_MontoAux) - (Convert.ToDouble(_DRow["cmontocancelar"]) + _Dbl_MontoAux);
                    _Str_Sql = "UPDATE TFACTPPAGARM SET csaldo=" + _Dbl_SaldoNew.ToString().Replace(",", ".") + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[0].ToString() + "' AND csaldo<>0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "UPDATE TMOVCXPM SET csaldo=" + _Dbl_SaldoNew.ToString().Replace(",", ".") + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[0].ToString() + "' AND csaldo<>0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    //Si hay AVISOS de Cobro CXP los marco como pagados
                    if (_DRow["ctipodocument"].ToString() == "AVISOCXP")
                    {
                        _Str_Sql = "update TAVISOPAGM set cestado=1,csaldo=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ccodavisopag='" + _DRow["cnumdocu"].ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
                _Mtd_SaldarDocumentosCxC(_Str_OrdPago);
                _Mtd_SaldarRetencionesReposiciones(_Str_OrdPago);
                string _Str_Cadena = "SELECT cidcomprobcheque FROM VST_COMPROP_CHEQUE_EGRESO WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidemisioncheq='" + _Str_CheqTrans + "' AND cproveedor='" + _Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString() + "'");
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)_Frm_EmisionCheque.MdiParent)._Frm_Contenedor._async_Default);
                    }
                }
            }

            this._Mtd_CancelarAvisosCobros(_Str_OrdPago);

            Cursor = Cursors.Default;
            _Frm_EmisionCheque._Mtd_Cancelar();
            _Frm_EmisionCheque._Mtd_CargarBusqueda();
            _Frm_EmisionCheque._Tb_Tab.SelectedIndex = 0;
            _Bol_Cerrar = true;            
            this.Close();
        }
        private void _Mtd_Transferencia(string _P_Str_Transferencia)
        {
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprob FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                string _Str_cidcomprob = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                string _Str_Sql = "UPDATE TCOMPROBANC SET cyearacco='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year + "',cmontacco='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month + "',cregdate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=" + _Str_cidcomprob;
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //------------------------------------------------------------------
                _Str_Sql = "SELECT cdescrip,corder FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Mtd_Replace(_Str_cidcomprob))
                {
                    _Str_Sql = "UPDATE TCOMPROBAND SET cdescrip='TRANSFERENCIA # " + _P_Str_Transferencia + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'", "''") + "',cnumdocu='" + _P_Str_Transferencia + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "' AND cdescrip LIKE '%<REPLACE>%'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    if (CLASES._Cls_Varios_Metodos._Mtd_DebitoBancarioCuentaBancaria())
                    {
                        //IGTF
                        _Str_Sql = "UPDATE TCOMPROBAND SET cdescrip='CARGO IGTF DE LA TRANSFERENCIA # " + _P_Str_Transferencia + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'", "''") + "',cnumdocu='" + _P_Str_Transferencia + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "' AND cdescrip LIKE '%<REPLACEIGTF>%'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        //IGTF
                    }
                }
                else
                {
                    //string _Str_Replace = _Mtd_ObtenerReplace(_Str_cidcomprob);
                    _Str_Sql = "UPDATE TCOMPROBAND SET cdescrip='TRANSFERENCIA # " + _P_Str_Transferencia + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'","''") + "',cnumdocu='" + _P_Str_Transferencia + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "' AND cdescrip LIKE '%TRANSFERENCIA #%'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    if (CLASES._Cls_Varios_Metodos._Mtd_DebitoBancarioCuentaBancaria())
                    {
                        //IGTF
                        _Str_Sql = "UPDATE TCOMPROBAND SET cdescrip='CARGO IGTF DE LA TRANSFERENCIA # " + _P_Str_Transferencia + " " + _Txt_Persona.Text.Trim().ToUpper().Replace("'", "''") + "',cnumdocu='" + _P_Str_Transferencia + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "' AND cdescrip LIKE '%<REPLACEIGTF>%'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        //IGTF
                    }
                }
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cproveedor from TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdPago + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Proveedor = _Ds.Tables[0].Rows[0][0].ToString();
                }
                PrintDialog _Print = new PrintDialog();
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'", _Print, true);
                    Cursor = Cursors.Default;
                    //Cursor = Cursors.WaitCursor;
                    //REPORTESS _Frm = new REPORTESS(new string[] { "VST_COMPROP_CHEQUE_EGRESO" }, "", "T3.Report.rComprobanEgresoCheque", "", "", "", "", "ccompany='" + Frm_Padre._Str_Comp + "' and cidemisioncheq='" + _Str_CheqTrans + "' AND cproveedor='" + _Str_Proveedor + "'", _Print, true);
                    //Cursor = Cursors.Default;
                }
            }
        }
        private bool _Mtd_Replace(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND cdescrip LIKE '%<REPLACE>%'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_ObtenerReplace(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cdescrip FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND cdescrip LIKE '%TRANSFERENCIA #%'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                int _Int_Index = _Str_Cadena.IndexOf("TRANSFERENCIA #");
                _Str_Cadena = _Str_Cadena.Substring(_Int_Index);
                _Int_Index = _Str_Cadena.IndexOf(".");
                return _Str_Cadena.Substring(0, _Int_Index);
            }
            return "";
        }
        private bool _Mtd_ImprimirComprobante(string _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
            _Print:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _Print;
                    }
                }
            }
            catch (Exception _Ex) { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. " + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return false;
        }
        //private void _Bt_AnularNum_Click(object sender, EventArgs e)
        //{
        //    if (_Bt_Salir.Enabled)
        //    {
        //        string _Str_Sql = "UPDATE TEMICHEQTRANSM SET cnumcheqtransac='" + _Str_TempProx + "',cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "'";
        //        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //        _Str_Sql = "UPDATE TCUENTBANC SET cproxnumcheq='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Str_Banco + "' AND cnumcuenta='" + _Str_NumCuenta.ToString() + "'";
        //        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //    }
        //    _Pnl_Cheque.Visible = false;
        //    _Mtd_ActualizarCheque(_Mtd_ObtenerIDChequera(_Str_Banco, _Str_TempProx), _Str_TempProx, false);
        //    _Mtd_AnularNum_Reimrpimir();
        //}

        private void _Bt_ReImp_Click(object sender, EventArgs e)
        {
            _Pnl_Cheque.Visible = false;
            _Mtd_ImprimirCheq(_Str_TempProx);
        }

        private void _Bt_AnularCom_Click(object sender, EventArgs e)
        {
            if (_Bt_Salir.Enabled)
            {
                string _Str_Sql = "UPDATE TEMICHEQTRANSM SET cnumcheqtransac='" + _Str_TempProx + "',cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TCUENTBANC SET cproxnumcheq='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Str_Banco + "' AND cnumcuenta='" + _Str_NumCuenta.ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            _Pnl_Cheque.Visible = false;
            _Mtd_ActualizarCheque(_Mtd_ObtenerIDChequera(_Str_Banco, _Str_NumCuenta.Trim(), _Str_TempProx), _Str_TempProx, false);
            _Mtd_AnularCompletamente();
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            _Bol_Cerrar = true;
            this.Close();
        }

        private void _Bt_SalirT_Click(object sender, EventArgs e)
        {
            _Bol_Cerrar = true;
            this.Close();
        }

        private void _Bt_ReImpT_Click(object sender, EventArgs e)
        {
            _Pnl_Transferencia.Visible = false;
            _Mtd_ImprimirTransf();
        }

        private void _Bt_AnularComT_Click(object sender, EventArgs e)
        {
            if (_Bt_SalirT.Enabled)
            {
                if (_Str_TempProx.Trim().Length == 0)
                { _Str_TempProx = _Mtd_ProxNumTransf(_Str_Banco.Trim()); }
                string _Str_Sql = "UPDATE TEMICHEQTRANSM SET cnumcheqtransac='" + _Str_TempProx + "',cuserimprime='" + Frm_Padre._Str_Use + "',cfechaimprimio='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_CheqTrans + "' AND cidordpago='" + _Str_OrdPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TCUENTBANC SET cproxnumTransf='" + _Str_TempProx + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Str_Banco + "' AND cnumcuenta='" + _Str_NumCuenta.ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            _Pnl_Transferencia.Visible = false;
        }

        private void _Bt_AnularNum_Click(object sender, EventArgs e)
        {

        }
    }
}