using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace T3
{
    public partial class Frm_MsjCierreContable : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
        int _cont = 0;
        string Str_Mes;
        string Str_Anio;
        public Frm_MsjCierreContable(string _Str_Mes, string _Str_anio)
        {
            Str_Mes = _Str_Mes;
            Str_Anio = _Str_anio;
            InitializeComponent();
        }

        private void Frm_MsjCierreCaja_Load(object sender, EventArgs e)
        {
            label1.Text = "Se procederá al Cierre Contable del mes.. " + Str_Mes + "-" + Str_Anio;
        }
        private bool _Mtd_MesReAbierto()
        {
            string _Str_Cadena = "SELECT * FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND creabierto='1' AND ccerrado='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarComprobantesDeMes(int _P_Int_Ano, int _P_Int_Mes)
        {
            string _Str_Cadena = "SELECT * FROM TCOMPROBANC INNER JOIN TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany  WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANC.cstatus<>'9' AND TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus<>'1' AND (csistema='1' OR (csistema='0' AND (cestatusfirma='1' OR cestatusfirma='2' OR cestatusfirma='4'))) AND (ccuadrado='1' OR cestatusfirma='4' OR (ccuadrado='0' AND cestatusfirma='1' OR cestatusfirma='2')) AND ctotdebe>0 AND TCOMPROBANC.cyearacco='" + _P_Int_Ano + "' AND TCOMPROBANC.cmontacco='" + _P_Int_Mes + "' AND NOT EXISTS(SELECT cidcomprob FROM TPAGOSCXPM WHERE TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPM.ccompany=TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT TFACTPPAGARM.cestatusfirma FROM TFACTPPAGARM INNER JOIN TCOMPROBANRETC ON TFACTPPAGARM.cproveedor = TCOMPROBANRETC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANRETC.ccompany AND TFACTPPAGARM.cidcomprobret = TCOMPROBANRETC.cidcomprobret WHERE TFACTPPAGARM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany=TCOMPROBANC.ccompany AND TCOMPROBANRETC.cidcomprob=TCOMPROBANC.cidcomprob AND TFACTPPAGARM.cestatusfirma = '1') AND NOT EXISTS(SELECT TFACTPPAGARM.cestatusfirma FROM TFACTPPAGARM INNER JOIN TCOMPROBANISLRC ON TFACTPPAGARM.cproveedor = TCOMPROBANISLRC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANISLRC.ccompany AND TFACTPPAGARM.cidcomprobislr = TCOMPROBANISLRC.cidcomprobislr WHERE TFACTPPAGARM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany=TCOMPROBANC.ccompany AND TCOMPROBANISLRC.cidcomprob=TCOMPROBANC.cidcomprob AND TFACTPPAGARM.cestatusfirma = '1')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_AnulacionesCxPPendientes(int _P_Int_Ano, int _P_Int_Mes)
        {
            string _Str_Cadena = "select * from tfactppagarm inner join tcomprobanc on tfactppagarm.ccompany=tcomprobanc.ccompany and tfactppagarm.cidcomprobanul=tcomprobanc.cidcomprob and tcomprobanc.cyearacco='" + _P_Int_Ano + "' and tcomprobanc.cmontacco='" + _P_Int_Mes + "' and cstatus='9'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!_Mtd_MesReAbierto())
            {
                if (!_Mtd_VerificarComprobantesDeMes(Convert.ToInt32(Str_Anio), Convert.ToInt32(Str_Mes)))
                {
                    if (_Mtd_AnulacionesCxPPendientes(Convert.ToInt32(Str_Anio), Convert.ToInt32(Str_Mes)))
                    {
                        MessageBox.Show("No es posible cerrar el mes ya que existen anulaciones por aprobar de cuentas por pagar del periodo seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _cont++;

                    if (_cont == 1)
                    {
                        btn_aceptar.ForeColor = SystemColors.ControlText;
                    }
                    if (_cont > 1)
                    {
                        btn_aceptar.Enabled = false;
                        btn_cancelar.Enabled = false;
                        //_Cls_Varios._Mtd_IniciarBackupBD(this, "CONT");
                        _Pgr_progreso.Visible = true;
                        label2.Visible = true;
                        _Bak_GroundWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ComprobPendientes _Frm = new Frm_ComprobPendientes(Convert.ToInt32(Str_Anio), Convert.ToInt32(Str_Mes));
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                }
            }
            else
            { MessageBox.Show("No puede realizar la operación ya que existe un mes re-abierto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Mtd_CierreContable()
        {
            string _Str_Resultado = "";
            try
            {
                _Bak_GroundWorker.ReportProgress(10);
                SqlParameter[] _SQL_Parametros = new SqlParameter[3];
                _SQL_Parametros[0] = new SqlParameter("@CCOMPANY", SqlDbType.VarChar);
                _SQL_Parametros[0].Value = Frm_Padre._Str_Comp;
                _Bak_GroundWorker.ReportProgress(20);
                _SQL_Parametros[1] = new SqlParameter("@CMESCONT", SqlDbType.Decimal);
                _SQL_Parametros[1].Value = Str_Mes;
                _Bak_GroundWorker.ReportProgress(30);
                _SQL_Parametros[2] = new SqlParameter("@CANOCONT", SqlDbType.Decimal);
                _SQL_Parametros[2].Value = Str_Anio;
                _Str_Resultado = T3.CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_CIERRECONTABLE", _SQL_Parametros, "@CRESULTADO");
                _Bak_GroundWorker.ReportProgress(70);
                if (_Str_Resultado != "1")
                {
                    MessageBox.Show("No se ha podido cerrar el Período Contable " + Str_Mes + "-" + Str_Anio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    string _Str_Sql = "UPDATE TMESCONTABLE SET ccerrado=1, cdatecerrado=GETDATE(), cusercerrado='" + Frm_Padre._Str_Use + "' WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cmontacco='" + Str_Mes + "' AND cyearacco='" + Str_Anio + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Bak_GroundWorker.ReportProgress(90);
                    MessageBox.Show("Se ha cerrado correctamente el Período Contable " + Str_Mes + "-" + Str_Anio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception _Ex)
            {
                MessageBox.Show("Error en la operación.\n" + _Ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _Mtd_CierreContable();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this._Pgr_progreso.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _Pgr_progreso.Value = 100;
            _Pgr_progreso.Visible = false;
            label2.Visible = false;
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
            this.Close();
        }
    }
}