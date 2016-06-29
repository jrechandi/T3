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
    public partial class Frm_ReAbrirMesCont : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ReAbrirMesCont()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted();
            _Mtd_Actualizar();
        }
        bool _Bol_Tabs = false;
        public Frm_ReAbrirMesCont(bool _P_Bol_Tabs)
        {
            InitializeComponent();
            _Bol_Tabs = true;
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted();
            _Mtd_ActualizarMesReAbierto();
            this.Text = "Cerrar mes re-abierto";
            _Menu_Abrir.Text = "Cerrar mes";
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
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Meses.Columns.Count; _Int_i++)
            {
                _Dg_Meses.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT cmontacco as mes,cyearacco as ano,cmontacco as mes2 FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='1' ORDER BY CONVERT(DATETIME,CONVERT(VARCHAR,cmontacco)+'/1/'+CONVERT(VARCHAR,cyearacco)) DESC";
            _Dg_Meses.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Meses.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Meses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_ActualizarMesReAbierto()
        {
            string _Str_Cadena = "SELECT cmontacco as mes,cyearacco as ano,cmontacco as mes2 FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND creabierto='1' AND ccerrado='0'";
            _Dg_Meses.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Meses.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Meses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_EjecutarCierre(string _P_Str_Mes, string _P_Str_Ano)
        {
            SqlParameter[] _SQL_Parametros = new SqlParameter[3];
            _SQL_Parametros[0] = new SqlParameter("@CCOMPANY", SqlDbType.VarChar);
            _SQL_Parametros[0].Value = Frm_Padre._Str_Comp;
            _SQL_Parametros[1] = new SqlParameter("@CMESCONT", SqlDbType.Decimal);
            _SQL_Parametros[1].Value = _P_Str_Mes;
            _SQL_Parametros[2] = new SqlParameter("@CANOCONT", SqlDbType.Decimal);
            _SQL_Parametros[2].Value = _P_Str_Ano;
            T3.CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_CIERRECONTABLE_REABIERTO", _SQL_Parametros, "@CRESULTADO");
        }
        private void _Mtd_CerrarMes()
        {
            string _Str_Cadena = "SELECT cmontacco,cyearacco FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND creabierto='1' AND ccerrado='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "SELECT cmontacco,cyearacco FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ((ccerrado='1' AND CONVERT(DATETIME,CONVERT(VARCHAR,cmontacco)+'/1/'+CONVERT(VARCHAR,cyearacco)) BETWEEN CONVERT(DATETIME,CONVERT(VARCHAR,'" + _Ds.Tables[0].Rows[0]["cmontacco"].ToString() + "')+'/1/'+CONVERT(VARCHAR,'" + _Ds.Tables[0].Rows[0]["cyearacco"].ToString() + "')) AND (SELECT TOP 1 CONVERT(DATETIME,CONVERT(VARCHAR,cmontacco)+'/1/'+CONVERT(VARCHAR,cyearacco)) FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='1' ORDER BY CONVERT(DATETIME,CONVERT(VARCHAR,cmontacco)+'/1/'+CONVERT(VARCHAR,cyearacco)) DESC)) OR ccerrado='0' AND creabierto='1') ORDER BY CONVERT(DATETIME,CONVERT(VARCHAR,cmontacco)+'/1/'+CONVERT(VARCHAR,cyearacco)) ASC";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Dg_Row in _Ds.Tables[0].Rows)
                {
                    _Mtd_EjecutarCierre(_Dg_Row["cmontacco"].ToString(), _Dg_Row["cyearacco"].ToString());
                    _Str_Cadena = "UPDATE TMESCONTABLE SET ccerrado=1, creabierto='0',creversado='1', cdatereversado=GETDATE(), cusereversado='" + Frm_Padre._Str_Use + "' WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cmontacco='" + _Dg_Row["cmontacco"].ToString() + "' AND cyearacco='" + _Dg_Row["cyearacco"].ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }
        private void _Cntx_Abrir_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (_Dg_Meses.Rows.Count == 0 | _Dg_Meses.CurrentCell == null);
        }

        private void Frm_AbrirMesCont_Load(object sender, EventArgs e)
        {

        }

        private void Frm_AbrirMesCont_Shown(object sender, EventArgs e)
        {
            if (_Mtd_MesReAbierto() & !_Bol_Tabs)
            {
                MessageBox.Show("No puede entrar a este módulo porque ya existe un mes re-abierto", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            else if (!(_Cls_Variosmetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_RE_ABRIR_MES")))
            {
                MessageBox.Show("Usted no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }
        private bool _Mtd_MesReAbierto()
        {
            string _Str_Cadena = "SELECT * FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND creabierto='1' AND ccerrado='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_AbrirMes(string _P_Str_Ano, string _P_Str_Mes)
        {
            string _Str_Cadena = "UPDATE TMESCONTABLE SET ccerrado='0',creabierto='1',cdatereabierto=GETDATE(),cusereabierto='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmontacco='" + _P_Str_Mes + "' AND cyearacco='" + _P_Str_Ano + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE FROM TCOUNTHIST WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmontaacco='" + _P_Str_Mes + "' AND cyearacco='" + _P_Str_Ano + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private bool _Mtd_VerificarComprobantesDeMes(int _P_Int_Ano, int _P_Int_Mes)
        {
            string _Str_Cadena = "SELECT * FROM TCOMPROBANC INNER JOIN TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany  WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANC.cstatus<>'9' AND TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus<>'1' AND (csistema='1' OR (csistema='0' AND (cestatusfirma='1' OR cestatusfirma='2' OR cestatusfirma='4'))) AND (ccuadrado='1' OR cestatusfirma='4' OR (ccuadrado='0' AND cestatusfirma='1' OR cestatusfirma='2')) AND ctotdebe>0 AND TCOMPROBANC.cyearacco='" + _P_Int_Ano + "' AND TCOMPROBANC.cmontacco='" + _P_Int_Mes + "' AND NOT EXISTS(SELECT cidcomprob FROM TPAGOSCXPM WHERE TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPM.ccompany=TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT TFACTPPAGARM.cestatusfirma FROM TFACTPPAGARM INNER JOIN TCOMPROBANRETC ON TFACTPPAGARM.cproveedor = TCOMPROBANRETC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANRETC.ccompany AND TFACTPPAGARM.cidcomprobret = TCOMPROBANRETC.cidcomprobret WHERE TFACTPPAGARM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany=TCOMPROBANC.ccompany AND TCOMPROBANRETC.cidcomprob=TCOMPROBANC.cidcomprob AND TFACTPPAGARM.cestatusfirma = '1') AND NOT EXISTS(SELECT TFACTPPAGARM.cestatusfirma FROM TFACTPPAGARM INNER JOIN TCOMPROBANISLRC ON TFACTPPAGARM.cproveedor = TCOMPROBANISLRC.cproveedor AND TFACTPPAGARM.ccompany = TCOMPROBANISLRC.ccompany AND TFACTPPAGARM.cidcomprobislr = TCOMPROBANISLRC.cidcomprobislr WHERE TFACTPPAGARM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany=TCOMPROBANC.ccompany AND TCOMPROBANISLRC.cidcomprob=TCOMPROBANC.cidcomprob AND TFACTPPAGARM.cestatusfirma = '1')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Menu_Abrir_Click(object sender, EventArgs e)
        {
            if (!_Bol_Tabs)
            {
                if (!_Mtd_MesReAbierto())
                {
                    if (new Frm_MessageBox("¿Esta seguro de re-abrir el mes " + Convert.ToString(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["mes"].Value) + "-" + Convert.ToString(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["ano"].Value) + " ?", "Precaución", SystemIcons.Warning, 3).ShowDialog() == DialogResult.Yes)
                    {
                        _Mtd_AbrirMes(Convert.ToString(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["ano"].Value), Convert.ToString(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["mes2"].Value));
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ya ha sido re-abierto un mes", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                if (!_Mtd_VerificarComprobantesDeMes(Convert.ToInt32(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["ano"].Value), Convert.ToInt32(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["mes2"].Value)))
                {
                    if (new Frm_MessageBox("¿Esta seguro de re-cerrar el mes " + Convert.ToString(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["mes"].Value) + "-" + Convert.ToString(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["ano"].Value) + " ?", "Precaución", SystemIcons.Warning, 3).ShowDialog() == DialogResult.Yes)
                    {
                        //_Cls_Variosmetodos._Mtd_IniciarBackupBD(this, "CONT");
                        this.Cursor = Cursors.WaitCursor;
                        this.Size = new Size(333, 235);
                        _Dg_Meses.Enabled = false;
                        _Pgr_Progreso.Visible = true;
                        _Lbl_Espere.Visible = true;
                        _Bak_GroundWorker.RunWorkerAsync();
                    }
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ComprobPendientes _Frm = new Frm_ComprobPendientes(Convert.ToInt32(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["ano"].Value), Convert.ToInt32(_Dg_Meses.Rows[_Dg_Meses.CurrentCell.RowIndex].Cells["mes2"].Value));
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                }
            }
        }

        private void _Bak_GroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _Mtd_CerrarMes();
        }

        private void _Bak_GroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            _Pgr_Progreso.Style = ProgressBarStyle.Blocks;
            _Pgr_Progreso.Value = 100;
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
            MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void _Dg_Meses_MouseEnter(object sender, EventArgs e)
        {
            if (!_Bol_Tabs)
            { _Lbl_DgInfo.Visible = true; }
        }

        private void _Dg_Meses_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }
    }
}
