using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace T3
{
    public partial class Frm_Estratificacion : Form
    {
        public Frm_Estratificacion()
        {
            InitializeComponent();
            _Dtp_FechDesde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_FechHasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(1);
        }

        private void Frm_Estratificacion_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y - (this.Height * 2));
        }
        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Bt_Generar.Enabled = false;
            _Dtp_FechDesde.Enabled = false;
            _Dtp_FechHasta.Enabled = false;
            _Pgr_Progreso.Visible = true;
            _Lbl_Espere.Visible = true;
            _Bak_GroundWorker.RunWorkerAsync();
        }
        private void _Mtd_CalcularEstratificacion()
        {
            SqlParameter[] _P_Stored = new SqlParameter[4];
            _P_Stored[0] = new SqlParameter("@CGROUPCOMP", SqlDbType.NVarChar);
            _P_Stored[0].Value = Frm_Padre._Str_GroupComp;
            _P_Stored[1] = new SqlParameter("@CCOMPANY", SqlDbType.NVarChar);
            _P_Stored[1].Value = Frm_Padre._Str_Comp;
            _P_Stored[2] = new SqlParameter("@CFECHAI", SqlDbType.DateTime);
            _P_Stored[2].Value = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FechDesde.Value);
            _P_Stored[3] = new SqlParameter("@CFECHAF", SqlDbType.DateTime);
            _P_Stored[3].Value = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FechHasta.Value);
            CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_CALCULAR_ESTRATIFICACION", _P_Stored);
        }
        private void _Dtp_FechDesde_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_FechHasta.MinDate = _Dtp_FechDesde.Value.AddDays(1);
        }

        private void _Bak_GroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _Mtd_CalcularEstratificacion();
        }

        private void _Bak_GroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            _Pgr_Progreso.Style = ProgressBarStyle.Blocks;
            _Pgr_Progreso.Value = 100;
            MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}