using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace T3
{
    public partial class Frm_AjusInventario : Form
    {
        public Frm_AjusInventario()
        {
            InitializeComponent();
        }
        CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
        public Frm_AjusInventario(string _P_Str_HistoricoAjuste)
        {           
            InitializeComponent();
            if (_Cls_Varios._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSCONTEO_INV"))
            {
                _Bt_Aprobar.Visible = true;
            }
            else
            {
                _Bt_Aprobar.Visible = false;
                //_Rpv_Main.Dock = DockStyle.Fill;
            }
            this._Txt_IdConteo.Text = _P_Str_HistoricoAjuste;
            _Str_HistoricoAjuste = _P_Str_HistoricoAjuste;
            _Mtd_Reporte();
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
        string _Str_HistoricoAjuste;
        string _Str_SentenciaSQL;
        DataSet _Ds_DataSet = new DataSet();
        private void _Mtd_Reporte()
        {
            _Str_SentenciaSQL = "select * from VST_INVENTARIOFISICOREPORTE where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Str_HistoricoAjuste + "'";
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            Report.rComparativo _MyReport = new T3.Report.rComparativo();
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _MyReport.SetDataSource(_Ds_DataSet.Tables[0]);
                Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                _Rpv_Main.ReportSource = _MyReport;
                _Rpv_Main.RefreshReport();
                _Bt_Aprobar.Enabled = true;
            }
            else
            {
                _Bt_Aprobar.Enabled = false;
                MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Rpv_Main.ReportSource = null;
            }
        }
        private bool _Mtd_VerificarAjusteSalida()
        {
            string _Str_Cadena = "SELECT * FROM TAJUSSALC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cimpreso='0' AND canulado='0' and cdelete='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            string _Str_Finalizado = "0";
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cfinalizado FROM TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' AND id_conteohist='" + _Str_HistoricoAjuste + "'");
            foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
            {
                _Str_Finalizado = _Dtw_Item["cfinalizado"].ToString();
            }
            if (_Str_Finalizado == "1")
            {
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                this._Pnl_Clave.Visible = true;
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            }
            else
            {
                MessageBox.Show(this, "No puede ajustar el conteo hasta que se finalice el proceso de verificación de conteo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void _Mtd_Ajustar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int _Int_ConteoHist = Convert.ToInt32(_Str_HistoricoAjuste);
                SqlParameter[] _Sql_Parametros = new SqlParameter[2];
                _Sql_Parametros[0] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _Sql_Parametros[0].Value = Frm_Padre._Str_Comp;
                _Sql_Parametros[1] = new SqlParameter("@id_conteohist", SqlDbType.Real);
                _Sql_Parametros[1].Value = _Int_ConteoHist;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_AJUSTEPORCONTEOHISTORICO", _Sql_Parametros);
                _Str_SentenciaSQL = "update TINVFISICOHISTM set cfinalizado='3' where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='"+_Str_HistoricoAjuste+"'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                string _Str_Cadena = "Delete from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Delete from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                if (this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                MessageBox.Show("Se realizó el proceso de ajustes correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bt_Aprobar.Enabled = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hubo un error de tipo " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cls_Varios._Mtd_VerificarClaveUsuario(_Txt_Clave.Text))
            {
                if (!_Mtd_VerificarAjusteSalida())
                {
                    _Pnl_Clave.Visible = false;
                    _Rpv_Main.Enabled = false;
                    _Bt_Aprobar.Enabled = false;
                    _Cls_Varios._Mtd_IniciarBackupBD(this, "INV");
                    _Mtd_Ajustar();
                }
                else
                {
                    _Pnl_Clave.Visible = false;
                    MessageBox.Show("Existen ajustes de salida por procesar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            if (_Pnl_Clave.Visible)
            {
                _Bt_Aprobar.Enabled = false;
                _Rpv_Main.Enabled = false;
                _Txt_Clave.Focus();
            }
            else
            {
                _Rpv_Main.Enabled = true;
                _Bt_Aprobar.Enabled = true;
            }
        }

        private void Frm_AjusInventario_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
        }
    }
}