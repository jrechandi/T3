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
    public partial class Frm_ReemplazoCuentas : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ReemplazoCuentas()
        {
            InitializeComponent();
            _Mtd_Sorted(_Dg_Grid);
        }

        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns></returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }

        private string _Mtd_ObtenerDescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            _Dg_Grid.Rows.Clear();
            string _Str_Cadena = "Select ccountinactiva,cname,'','','' from TCOUNTINAC inner join TCOUNT ON TCOUNTINAC.ccompany=TCOUNT.ccompany AND TCOUNTINAC.ccountinactiva=TCOUNT.ccount WHERE TCOUNTINAC.ccompany='" + Frm_Padre._Str_Comp + "' and ccountactiva IS NULL";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dg_Grid.Rows.Add(_Row.ItemArray);
            }
            Cursor = Cursors.Default;
        }

        private void _Mtd_Guardar()
        {
            string _Str_Cadena = "";
            _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CuentaNueva"].Value != "").ToList().ForEach(x => {
                _Str_Cadena = "UPDATE TCOUNTINAC SET ccountactiva='" + Convert.ToString(x.Cells["CuentaNueva"].Value).Trim() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccountinactiva='" + Convert.ToString(x.Cells["CuentaInactiva"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            });
        }

        private void Frm_ReemplazoCuentas_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ReemplazoCuentas_Load(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                Cursor = Cursors.WaitCursor;
                Frm_VstCuentas _Frm = new Frm_VstCuentas();
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
                {
                    if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells[3].Value = _Frm._Str_FrmNodeSelec.Trim();
                        _Dg_Grid.Rows[e.RowIndex].Cells[4].Value = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim());
                    }
                    else
                    { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                _Frm.Dispose();
            }
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.Rows.Cast<DataGridViewRow>().All(x => x.Cells["CuentaNueva"].Value == ""))
            {
                MessageBox.Show("Debe seleccionar por lo menos una cuenta para reemplazar.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                Cursor = Cursors.Default;
                if (_Dg_Grid.RowCount == 0)
                    this.Close();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Dg_Grid.Enabled = false; _Bt_Guardar.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Dg_Grid.Enabled = true; _Bt_Guardar.Enabled = true; }
        }
    }
}
