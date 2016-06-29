using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ZonaporCliente : Form
    {
        /// <summary>
        /// Permite verificar si el cliente tiene pedidos bloqueados.
        /// </summary>
        /// <returns>Verdadero si el cliente tiene pedidos bloqueados.</returns>
        private bool _Mtd_VerificarPedidosBloqueados()
        {
            string _Str_SQL;
            DataSet _Ds_Resultado;

            if (_Dg_Grid2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.SelectedRows)
                {
                    _Str_SQL = "SELECT cpedido FROM VST_CONSULTAPEDIDOSPORESTATUS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_SQL += " AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cstatus='3') AND (ccliente='" + _Dg_Row.Cells[0].Value + "') AND c_activo='1';";
                    _Ds_Resultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds_Resultado.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Frm_ZonaporCliente()
        {
            InitializeComponent();
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Refrescar(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Refrescar();
            }
        }

        public Frm_ZonaporCliente(string _P_Str_Zona,string _P_Str_Grupo)
        {
            InitializeComponent();
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Refrescar(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Refrescar();
            }
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid1.Rows)
            {
                if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Zona.Trim() & _Dg_Row.Cells[2].Value.ToString().Trim() == _P_Str_Grupo.Trim())
                { _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Grid1.Rows[_Int_Row].Cells[0];
                _Dg_Grid1.CurrentCell = _Dg_Cel;
                _Mtd_RowHeaderMouseClick();
            }
        }

        private void Frm_ZonaporCliente_Load(object sender, EventArgs e)
        {
           
        }

        private void _bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                Frm_Mantenimientos fr = new Frm_Mantenimientos(this, _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString(), 3, _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[2].Value.ToString());
                fr.ShowDialog();
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
            }
            else
            {
                MessageBox.Show("Debe selecionar una zona", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void _Mtd_Evento()
        {
            string _Str_Cadena = "SELECT TCLIENTE.ccliente CÓDIGO,TCLIENTE.c_nomb_comer as DESCRIPCIÓN FROM TZONACLIENTE INNER JOIN TCLIENTE ON TZONACLIENTE.ccliente = TCLIENTE.ccliente AND TZONACLIENTE.cdelete = TCLIENTE.cdelete WHERE (TZONACLIENTE.cdelete = 0) AND (TZONACLIENTE.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')" + " and (TZONACLIENTE.c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid2.DataSource = _Ds.Tables[0];
            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Refrescar()
        {
            string _Str_Cadena = "Select c_zona as CÓDIGO,cname as DESCRIPCIÓN,cgrupovta from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid1.DataSource = _Ds.Tables[0];
            _Dg_Grid1.Columns[2].Visible = false;
            _Dg_Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid2.DataSource = null;
        }
        private void _Mtd_Refrescar(string _Pr_Str_Gerente)
        {
            string _Str_Cadena = "Select c_zona as CÓDIGO,cname as DESCRIPCIÓN,cgrupovta from VST_ZONAVENTA_VENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cgerarea='"+_Pr_Str_Gerente+"'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid1.DataSource = _Ds.Tables[0];
            _Dg_Grid1.Columns[2].Visible = false;
            _Dg_Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid2.DataSource = null;
        }
        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Refrescar(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Refrescar();
            }
            _Mtd_RowHeaderMouseClick();
            Cursor = Cursors.Default;
        }
        private void _Mtd_Eliminar()
        {
            if (_Dg_Grid2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.SelectedRows)
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONACLIENTE", "cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "', cdelete='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' and ccliente='" + _Dg_Row.Cells[0].Value.ToString() + "'");
                }
            }
            else
            {
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONACLIENTE", "cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "', cdelete='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' and ccliente='" + _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
            }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarPedidosBloqueados())
            {
                MessageBox.Show("Existen clientes con pedidos por facturar o bloqueados por crédito, verifique.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (_Dg_Grid2.Rows.Count > 0)
            {
                DialogResult eli;
                if (_Dg_Grid2.SelectedRows.Count > 0)
                { eli = MessageBox.Show("Esta seguro de eliminar los registros seleccionados?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); }
                else
                { eli = MessageBox.Show("Esta seguro de eliminar el registro?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); }
                if (eli == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Eliminar();
                    _Mtd_Evento();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Debe selecionar por lo menos un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Mtd_RowHeaderMouseClick()
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                string _Str_Cadena = "SELECT TCLIENTE.ccliente as CÓDIGO,TCLIENTE.c_nomb_comer as DESCRIPCIÓN FROM TZONACLIENTE INNER JOIN TCLIENTE ON TZONACLIENTE.ccliente = TCLIENTE.ccliente AND TZONACLIENTE.cdelete = TCLIENTE.cdelete WHERE (TZONACLIENTE.cdelete = 0) AND (TZONACLIENTE.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')" + " and (TZONACLIENTE.c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
            }
        }
        private void _Dg_Grid1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                string _Str_Cadena = "SELECT TCLIENTE.ccliente as CÓDIGO,TCLIENTE.c_nomb_comer as DESCRIPCIÓN FROM TZONACLIENTE INNER JOIN TCLIENTE ON TZONACLIENTE.ccliente = TCLIENTE.ccliente AND TZONACLIENTE.cdelete = TCLIENTE.cdelete WHERE (TZONACLIENTE.cdelete = 0) AND (TZONACLIENTE.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')" + " and (TZONACLIENTE.c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void _Dg_Grid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex > -1 && e.RowIndex > -1)
            //{
            //    _Dg_Grid2.DataSource = null;
            //    _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //}
        }

        private void _Dg_Grid1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void Frm_ZonaporCliente_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid1.CurrentCell != null)
            {
                string _Str_Cadena = "SELECT TCLIENTE.ccliente as CÓDIGO,TCLIENTE.c_nomb_comer as DESCRIPCIÓN FROM TZONACLIENTE INNER JOIN TCLIENTE ON TZONACLIENTE.ccliente = TCLIENTE.ccliente AND TZONACLIENTE.cdelete = TCLIENTE.cdelete WHERE (TZONACLIENTE.cdelete = 0) AND (TZONACLIENTE.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TCLIENTE.cgroupcomp ='" + Frm_Padre._Str_GroupComp + "')" + " and (TZONACLIENTE.c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
    }
}