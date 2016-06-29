using System;
using System.Windows.Forms;
using System.Data;

namespace T3
{
    public partial class Frm_EALCCConfig : Form
    {
        public Frm_EALCCConfig()
        {
            InitializeComponent();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            string _Str_SQL;
            DataSet _Ds_Datos;
            
            if (_Dtp_Fecha.Value < DateTime.Now)
            {
                MessageBox.Show("La fecha suministrada es incorrecta.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Str_SQL = "SELECT generacionId FROM TGENLIMCREDM WHERE fecha = CONVERT(DATETIME, '" + _Dtp_Fecha.Value.ToShortDateString() + "', 103);";

            _Ds_Datos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Datos.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Ya se configuró el reporte para esa fecha.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Str_SQL = "INSERT INTO TGENLIMCREDM (fecha) VALUES (CONVERT(DATETIME, '" + _Dtp_Fecha.Value.ToShortDateString() + "', 103));";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

            MessageBox.Show("Configurado correctamente.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
