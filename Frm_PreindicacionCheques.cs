using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_PreindicacionCheques : Form
    {
        string _G_Str_SentenciaSQL;
        DataSet _G_Ds_DataSet;
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_PreindicacionCheques()
        {
            InitializeComponent();
            _Mtd_CargarBancoConsulta();
        }

        private void _Rbt_ConsultaPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            _Pnl_ConsultaFecha.Visible = true;
            _Pnl_ConsultaNCheque.Visible = false;
        }

        private void _Rbt_ConsultaPorNCheque_CheckedChanged(object sender, EventArgs e)
        {
            _Pnl_ConsultaFecha.Visible = false;
            _Pnl_ConsultaNCheque.Visible = true;
        }

        private void Frm_PreindicacionCheques_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Método que sirve para cargar el combo del banco
        /// </summary>
        private void _Mtd_CargarBancoConsulta()
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT DISTINCT RTRIM(CBANCO) AS CBANCO,CNAME FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='1'";
                _myUtilidad._Mtd_CargarCombo(_Cmb_Banco, _G_Str_SentenciaSQL);
                if (_Cmb_Banco.Items.Count > 1)
                {
                    _Cmb_Banco.SelectedValue = "1";
                    _Cmb_Banco.Enabled = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que sirve para cargar el combo de cuentas bancarias según un banco
        /// </summary>
        /// <param name="_P_Str_Banco">Código del banco</param>
        private void _Mtd_CargarCuentaConsultas(string _P_Str_Banco)
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT cnumcuenta,cuentabanname FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _P_Str_Banco + "'";
                _myUtilidad._Mtd_CargarCombo(_Cmb_CuentaBancaria, _G_Str_SentenciaSQL);
                if (_Cmb_CuentaBancaria.Items.Count > 1)
                {
                    _Cmb_CuentaBancaria.Enabled = true;
                }
                else
                {
                    _Cmb_CuentaBancaria.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancoConsulta();
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    _Mtd_CargarCuentaConsultas(_Cmb_Banco.SelectedValue.ToString());
                }
            }
        }

        private void _Cmb_CuentaBancaria_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    _Mtd_CargarCuentaConsultas(_Cmb_Banco.SelectedValue.ToString());
                }
            }
        }

        private void _Btn_Generar_Click(object sender, EventArgs e)
        {
            _Mtd_GenerarArchivo();
        }
        /// <summary>
        /// Método que se emplea para guardar la consulta generada
        /// </summary>
        /// <returns>Retorna el código de la generación guardada</returns>
        private string _Mtd_GuardarGeneracion()
        {
            string _Str_IdGeneracion = "1";
            _G_Str_SentenciaSQL = "SELECT ISNULL(MAX(cidreporte),0)+1 FROM [TPINDICHEQM] WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
            if (_G_Ds_DataSet.Tables[0].Rows[0][0].ToString().Length > 0)
            {
                _Str_IdGeneracion = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                _G_Str_SentenciaSQL = "INSERT INTO [TPINDICHEQM] ([ccompany],[cidreporte],[cbanco],[cnumcuentad],[cfechageneracion],[cfechainicial],[cfechafinal],";
                _G_Str_SentenciaSQL += "[cnumcheqinicial],[cnumcheqfinal],[cdateadd],[cuseradd],[cdelete])";
                if (_Pnl_ConsultaFecha.Visible)
                {
                    _G_Str_SentenciaSQL += " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_IdGeneracion + "','" + _Cmb_Banco.SelectedValue.ToString() + "','" + _Cmb_CuentaBancaria.SelectedValue.ToString() + "',GETDATE(),'" + _Dtp_FechaDesde.Value.ToString("dd/MM/yyyy") + "','" + _Dtp_FechaHasta.Value.ToString("dd/MM/yyyy") + "',";
                    _G_Str_SentenciaSQL += "'0','0',getdate(),'" + Frm_Padre._Str_Use + "','0')";
                }
                else
                {
                    _G_Str_SentenciaSQL += " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_IdGeneracion + "','" + _Cmb_Banco.SelectedValue.ToString() + "','" + _Cmb_CuentaBancaria.SelectedValue.ToString() + "',GETDATE(),null,null,";
                    _G_Str_SentenciaSQL += "'" + _Txt_NChequeDesde.Text + "','" + _Txt_NChequeHasta.Text + "',getdate(),'" + Frm_Padre._Str_Use + "','0')";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                //Se ingresa el detalle
                _G_Str_SentenciaSQL = "INSERT INTO TPINDICHEQD";
                _G_Str_SentenciaSQL += " SELECT  dbo.TEMICHEQTRANSM.ccompany,'" + _Str_IdGeneracion + "', dbo.TEMICHEQTRANSM.cnumcheqtransac, dbo.TEMICHEQTRANSM.cfechaimprimio, CASE WHEN charindex('V-', dbo.TPAGOSCXPM.crif) = 1 AND charindex('-', substring(dbo.TPAGOSCXPM.crif, 3, len(dbo.TPAGOSCXPM.crif))) > 0 THEN substring(dbo.TPAGOSCXPM.crif, 0, charindex('-', substring(dbo.TPAGOSCXPM.crif, 3, len(dbo.TPAGOSCXPM.crif))) + 2) ELSE dbo.TPAGOSCXPM.crif END, ";
                _G_Str_SentenciaSQL += " ISNULL(dbo.TPAGOSCXPM.cbeneficiario, CONVERT(nvarchar(255), dbo.TEMICHEQTRANSM.cpagarse)) AS cbeneficiario, CASE WHEN dbo.TEMICHEQTRANSM.canulado = 0 THEN dbo.TPAGOSCXPM.cmontototal ELSE 0 END AS cmontototal, dbo.TPAGOSCXPM.cidordpago, dbo.TEMICHEQTRANSM.cusersolicitante, dbo.TUSER.cname,";
                _G_Str_SentenciaSQL += " getdate(),'" + Frm_Padre._Str_Use + "',null,null,'0',null,null";
                _G_Str_SentenciaSQL += " FROM dbo.TEMICHEQTRANSM INNER JOIN dbo.TPAGOSCXPM ON dbo.TEMICHEQTRANSM.cgroupcomp = dbo.TPAGOSCXPM.cgroupcomp AND ";
                _G_Str_SentenciaSQL += " dbo.TEMICHEQTRANSM.ccompany = dbo.TPAGOSCXPM.ccompany AND dbo.TEMICHEQTRANSM.cidordpago = dbo.TPAGOSCXPM.cidordpago INNER JOIN";
                _G_Str_SentenciaSQL += " dbo.TUSER ON dbo.TEMICHEQTRANSM.cusersolicitante = dbo.TUSER.cuser WHERE (dbo.TEMICHEQTRANSM.cimpimiocheq = 1)";
                _G_Str_SentenciaSQL += " AND (TPAGOSCXPM.cfpago = 'CHEQ')";
                _G_Str_SentenciaSQL += " AND TEMICHEQTRANSM.CCOMPANY='" + Frm_Padre._Str_Comp + "' and TEMICHEQTRANSM.CBANCO = '" + _Cmb_Banco.SelectedValue.ToString() + "' AND TEMICHEQTRANSM.cnumcuentad = '" + _Cmb_CuentaBancaria.SelectedValue.ToString() + "'";

                if (_Pnl_ConsultaFecha.Visible)
                {
                    _G_Str_SentenciaSQL += " AND CONVERT(DATETIME,CONVERT(VARCHAR,TEMICHEQTRANSM.cfechaimprimio,103)) BETWEEN '" + _Dtp_FechaDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + _Dtp_FechaHasta.Value.ToString("dd/MM/yyyy") + "'";
                }
                else if (_Pnl_ConsultaNCheque.Visible)
                {
                    _G_Str_SentenciaSQL += " AND TEMICHEQTRANSM.cnumcheqtransac BETWEEN '" + _Txt_NChequeDesde.Text + "' AND '" + _Txt_NChequeHasta.Text + "'";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            }
            return _Str_IdGeneracion;
        }
        /// <summary>
        /// Método que se usa para generar el archivo Txt
        /// </summary>
        private void _Mtd_GenerarArchivo()
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                string _Str_NReporte = _Mtd_GuardarGeneracion();
                DialogResult _Dgr_Resultado = _Fbd_Archivos.ShowDialog();
                if (_Dgr_Resultado == DialogResult.OK)
                {
                    string _Str_Carpeta = this._Fbd_Archivos.SelectedPath;
                    System.IO.DirectoryInfo _DirInf = new System.IO.DirectoryInfo(_Str_Carpeta);
                    string _Str_Cadena = "SELECT cnumcheque,crif,REPLACE(REPLACE(REPLACE(UPPER(cbeneficiario),'Ñ','N'),'´',' '),CHAR(39),' ') AS cbeneficiario,cmonto FROM TPINDICHEQD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidreporte='" + _Str_NReporte + "'";
                    _Str_Cadena += " ORDER BY cnumcheque ";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    string[] _Str_Fila = new string[_Ds.Tables[0].Rows.Count+1];
                    int _Int_I = 0;
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        //Numero de Cheque
                        string _Str_NumCheque = "";
                        _Str_NumCheque = _Row["cnumcheque"].ToString().ToString().PadLeft(9, '0');

                        //Rif Beneficiario
                        string _Str_Rif = "";
                        string[] _Str_RifSplit = _Row["crif"].ToString().Split('-');
                        if (_Str_RifSplit.Count() > 2)
                        {
                            _Str_Rif = _Str_RifSplit[0] + (_Str_RifSplit[1] + _Str_RifSplit[2]).PadLeft(9, '0');
                        }
                        else if (_Str_RifSplit.Count() == 2)
                        {
                            _Str_Rif = _Str_RifSplit[0] + _Str_RifSplit[1].PadLeft(9, '0');
                        }
                        else if (_Str_RifSplit.Count() == 1)
                        {
                            _Str_Rif = _Str_RifSplit[0].PadLeft(10, '0');
                        }

                        //Nombre del Beneficiario
                        string _Str_Beneficiario = "";
                        if (_Row["cbeneficiario"].ToString().Trim().Length <= 35)
                        {
                            _Str_Beneficiario = _Row["cbeneficiario"].ToString().Trim().PadRight(35);
                        }
                        else if (_Row["cbeneficiario"].ToString().Trim().Length > 35)
                        {
                            _Str_Beneficiario = _Row["cbeneficiario"].ToString().Trim().Substring(0, 35);
                        }

                        //Monto
                        string _Str_Monto = "";
                        if (_Row["cmonto"].ToString().Replace(".", "").Replace(",", "").Trim().Length < 15)
                        {
                            _Str_Monto += _Row["cmonto"].ToString().Replace(".", "").Replace(",","").PadLeft(15, '0');
                        }
                        //string[] _Str_MontoSplit = _Str_Monto.Split(','); //Divido el Monto

                        //Monto Entero (13 posiciones)




                        _Str_Fila[_Int_I] = _Str_NumCheque.Trim() + (char)9;
                        _Str_Fila[_Int_I] += _Str_Rif.Trim() + (char)9;
                        _Str_Fila[_Int_I] += CLASES._Cls_Varios_Metodos.RemoverCaracteresEspeciales(_Str_Beneficiario) + (char)9;
                        _Str_Fila[_Int_I] += _Str_Monto.Trim();
                        _Int_I++;
                    }

                    //new System.IO.FileStream(@"C:\IVA.txt", System.IO.FileMode.Create);
                    _Str_Carpeta += @"\" + Frm_Padre._Str_Comp.Trim() + "_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + _Str_NReporte + ".txt";
                    System.IO.File.WriteAllLines(_Str_Carpeta, _Str_Fila);
                    MessageBox.Show("El archivo " + Frm_Padre._Str_Comp.Trim() + "_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + _Str_NReporte + ".txt" + " se generó correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("El listado a generar se encuentra vacío por favor realice primero una consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Método que se usa para realizar la consulta
        /// </summary>
        private void _Mtd_Consultar()
        {
            try
            {
                string _Str_CBANCO = _Cmb_Banco.SelectedValue.ToString().Trim();
                string _Str_CCUENTA = _Cmb_CuentaBancaria.SelectedValue.ToString().Trim();

                _G_Str_SentenciaSQL = "SELECT CONVERT(VARCHAR,cfechaemision,103) AS Fecha, cnumcheqtransac as Cheque, crif as [CI o RIF], cbeneficiario as Beneficiario,  dbo.Fnc_Formatear(cmontototal) as Monto,InfOrdenPago as [Inf. Orden de pago] FROM VST_T3_PREINDICACIONCHEQUES WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cbanco = '" + _Str_CBANCO + "' AND cnumcuentad = '" + _Str_CCUENTA + "'";
                if (_Pnl_ConsultaFecha.Visible)
                {
                    _G_Str_SentenciaSQL += " AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaimprimio,103)) BETWEEN '" + _Dtp_FechaDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + _Dtp_FechaHasta.Value.ToString("dd/MM/yyyy") + "'";
                }
                else if (_Pnl_ConsultaNCheque.Visible)
                {
                    _G_Str_SentenciaSQL += " AND cnumcheqtransac BETWEEN '" + _Txt_NChequeDesde.Text + "' AND '" + _Txt_NChequeHasta.Text + "'";
                }
                _G_Str_SentenciaSQL += " ORDER BY cnumcheqtransac ";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Dg_Grid.DataSource = _G_Ds_DataSet.Tables[0];
                _Dg_Grid.Columns["Inf. Orden de pago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch
            {
            }
        }
        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            _Err_Error.Dispose();
            if (_Cmb_CuentaBancaria.SelectedValue != null)
            {
                if (_Cmb_CuentaBancaria.SelectedValue.ToString() != "nulo")
                {
                    if (_Pnl_ConsultaNCheque.Visible)
                    {
                        if (_Txt_NChequeDesde.Text.Trim().Length < 0 || _Txt_NChequeHasta.Text.Trim().Length < 0)
                        {
                            if (_Txt_NChequeDesde.Text.Trim().Length < 0)
                            {
                                _Err_Error.SetError(_Txt_NChequeDesde, "Ingrese la fecha desde");
                            }
                            if (_Txt_NChequeHasta.Text.Trim().Length < 0)
                            {
                                _Err_Error.SetError(_Txt_NChequeHasta, "Ingrese la fecha hasta");
                            }
                        }
                        else
                        {
                            _Mtd_Consultar();
                        }
                    }
                    else
                    {
                        _Mtd_Consultar();
                    }
                }
                else
                {
                    _Err_Error.SetError(_Cmb_CuentaBancaria, "Seleccione la cuenta bancaria");
                }
            }
            else
            {
                _Err_Error.SetError(_Cmb_CuentaBancaria, "Seleccione la cuenta bancaria");
            }
        }

        private void _Dtp_FechaHasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_FechaDesde.MaxDate = _Dtp_FechaHasta.Value;
        }

        private void _Dtp_FechaDesde_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_FechaHasta.MinDate = _Dtp_FechaDesde.Value;
        }

        private void _Txt_NChequeDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_NChequeDesde, e, 15, 0);
        }

        private void _Txt_NChequeHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_NChequeHasta, e, 15, 0);
        }

        private void _Txt_NChequeHasta_TextChanged(object sender, EventArgs e)
        {
            if (!_myUtilidad._Mtd_IsNumeric(_Txt_NChequeHasta.Text)) { _Txt_NChequeHasta.Text = ""; }
        }

        private void _Txt_NChequeDesde_TextChanged(object sender, EventArgs e)
        {
            if (!_myUtilidad._Mtd_IsNumeric(_Txt_NChequeDesde.Text)) { _Txt_NChequeDesde.Text = ""; }
        }

        private void _Cmb_CuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Grid.DataSource = null;
        }
    }
}
