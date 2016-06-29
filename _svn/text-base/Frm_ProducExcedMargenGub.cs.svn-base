using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ProducExcedMargenGub : Form
    {
        private CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        private Color _G_ColorInicialGrid = Color.White;

        public Frm_ProducExcedMargenGub()
        {
            InitializeComponent();
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena =
                "SELECT CONVERT(VARCHAR, TLOGMARGENEXCEDENTE.cfecha, 103) AS cfecha ,TLOGMARGENEXCEDENTE.cpedido ,TLOGMARGENEXCEDENTE.ccliente ,(convert(varchar,TLOGMARGENEXCEDENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS desccliente ,TLOGMARGENEXCEDENTE.cproducto ,TPRODUCTO.cnamef AS descproducto ,TLOGMARGENEXCEDENTE.ccajaspedidas ,TLOGMARGENEXCEDENTE.cunidadespedidas ,dbo.Fnc_Formatear(TLOGMARGENEXCEDENTE.cprecioventa) AS cprecioventa ,dbo.Fnc_Formatear(TLOGMARGENEXCEDENTE.ccostoneto) AS ccostoneto ,dbo.Fnc_Formatear(ROUND(((1 - (ccostoneto / cprecioventa)) * 100), 2)) AS cmargen ,TLOGMARGENEXCEDENTE.cvistonotificador,TLOGMARGENEXCEDENTE.clogid, TLOGMARGENEXCEDENTE.cprecioventamaximo " +
                "FROM TLOGMARGENEXCEDENTE INNER JOIN TCLIENTE ON TLOGMARGENEXCEDENTE.ccliente = TCLIENTE.ccliente INNER JOIN TPRODUCTO ON TLOGMARGENEXCEDENTE.cproducto = TPRODUCTO.cproducto " +
                "WHERE TLOGMARGENEXCEDENTE.ccompany = '" + Frm_Padre._Str_Comp + "' AND cvistonotificador = 0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];

            //Configuramos los anchos de cada columna
            _Dg_Grid.Columns[0].Width = 75;
            _Dg_Grid.Columns[1].Width = 60;
            _Dg_Grid.Columns[2].Width = 60;
            _Dg_Grid.Columns[3].Width = 160;
            _Dg_Grid.Columns[4].Width = 75;
            _Dg_Grid.Columns[5].Width = 160;
            _Dg_Grid.Columns[6].Width = 60;
            _Dg_Grid.Columns[7].Width = 60;
            _Dg_Grid.Columns[8].Width = 80;
            _Dg_Grid.Columns[9].Width = 80;
            _Dg_Grid.Columns[10].Width = 60;
            _Dg_Grid.Columns[11].Width = 60;
            _Dg_Grid.Columns[13].Width = 60;

            //Columnas de tamaño automatico
            _Dg_Grid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _Dg_Grid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Alineamos
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Ocultamos
            _Dg_Grid.Columns[2].Visible = false;

            Cursor = Cursors.Default;
        }

        private void _Mtd_Guardar()
        {
            string _Str_Cadena = "";
            _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["_Dt_columna_cvistonotificador"].Value.ToString() == "1").ToList().ForEach(x =>
                {
                    _Str_Cadena = "UPDATE TLOGMARGENEXCEDENTE SET cvistonotificador='1' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND clogid='" + Convert.ToString(x.Cells["clogid"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                });
        }

        private void Frm_ProducExcedMargenGub_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ProducExcedMargenGub_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (Width/2) - (_Pnl_Clave.Width/2);
            _Pnl_Clave.Top = (Height/2) - (_Pnl_Clave.Height/2);
            _Mtd_Actualizar();
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 11)
            {
                Cursor = Cursors.WaitCursor;

                //Obtengo el valor
                var oMarcado = _Dg_Grid.Rows[e.RowIndex].Cells["_Dt_columna_cvistonotificador"].Value.ToString() == "0";

                //Cambio
                _Dg_Grid.Rows[e.RowIndex].Cells["_Dt_columna_cvistonotificador"].Value = oMarcado ? "1" : "0";

                //Coloreamos
                _Mtd_ColorearRegistros();

                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_ColorearRegistros()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _Dg_Grid.SuspendLayout();

                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _Fila in _Dg_Grid.Rows)
                {
                    //Obtengo los valores
                    var oMarcado = _Fila.Cells["_Dt_columna_cvistonotificador"].Value.ToString() == "1";
                    //Verifico
                    _Fila.DefaultCellStyle.BackColor = oMarcado ? Color.GreenYellow : _G_ColorInicialGrid;
                }
                _Dg_Grid.ResumeLayout();
                Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                _Dg_Grid.ResumeLayout();
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.Rows.Cast<DataGridViewRow>().All(x => x.Cells["_Dt_columna_cvistonotificador"].Value.ToString() == "0"))
            {
                MessageBox.Show("Debe seleccionar por lo menos un registro para marcar como visto.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                Cursor = Cursors.WaitCursor;
                _Pnl_Clave.Enabled = false;
                _Mtd_Guardar();
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Pnl_Clave.Visible = false;
                _Pnl_Clave.Enabled = true;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre) Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                Cursor = Cursors.Default;
                if (_Dg_Grid.RowCount == 0) this.Close();
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Txt_Clave.Focus();
                _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Dg_Grid.Enabled = false;
                _Bt_Guardar.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Dg_Grid.Enabled = true;
                _Bt_Guardar.Enabled = true;
            }
        }
    }
}