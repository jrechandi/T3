using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace T3
{
    public partial class Frm_ZonaporVendedor : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ZonaporVendedor()
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
        public Frm_ZonaporVendedor(string _P_Str_Zona, string _P_Str_Grupo)
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
        private void _Mtd_Seleccionar(string _P_Str_Zona, string _P_Str_Grupo)
        {
            _Mtd_Refrescar();
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
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
        private void _bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                Frm_Mantenimientos fr = new Frm_Mantenimientos(this, _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString(), 2, _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[2].Value.ToString());
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
            string _Str_Cadena = "SELECT TVENDEDOR.cvendedor as Código, TVENDEDOR.cname as Descripción FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor WHERE (TVENDEDOR.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TZONAVENDEDOR.c_zona ='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')" + " and (TZONAVENDEDOR.cdelete ='0')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid2.DataSource = _Ds.Tables[0];
            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Refrescar()
        {
            string _Str_Cadena = "Select c_zona as Código,cname as descripción,cgrupovta from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid1.DataSource = _Ds.Tables[0];
            _Dg_Grid1.Columns[2].Visible = false;
            _Dg_Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid2.DataSource = null;
        }
        private void _Mtd_Refrescar(string _Pr_Str_Gerente)
        {
            string _Str_Cadena = "Select c_zona as CÓDIGO,cname as DESCRIPCIÓN,cgrupovta from VST_ZONAVENTA_VENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cgerarea='" + _Pr_Str_Gerente + "'";
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
            //Eliminar movimiento de ventas:
            DateTime _Dtm_TempDes = new DateTime(Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Year, Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Month, 1);
            string _Str_Cadena = "DELETE FROM TMOVINVENTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipo='F' AND cvendedor='" + _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' AND convert(datetime,convert(varchar(255),cdatemov,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtm_TempDes) + "' AND GETDATE() AND cproducto='0'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //--------------
            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONAVENDEDOR", "cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "', cdelete='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' and cvendedor='" + _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eli == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Eliminar();
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    _Mtd_Evento();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Mtd_RowHeaderMouseClick()
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                string _Str_Cadena = "SELECT TVENDEDOR.cvendedor as Código, TVENDEDOR.cname as Descripción FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor WHERE (TVENDEDOR.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TZONAVENDEDOR.c_zona ='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')" + " and (TZONAVENDEDOR.cdelete ='0')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
            }
        }
        private void _Dg_Grid1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                string _Str_Cadena = "SELECT TVENDEDOR.cvendedor as Código, TVENDEDOR.cname as Descripción FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor WHERE (TVENDEDOR.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TZONAVENDEDOR.c_zona ='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')" + " and (TZONAVENDEDOR.cdelete ='0')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
            }
        }

        private void Frm_ZonaporVendedor_Load(object sender, EventArgs e)
        {
            _Pnl_Traspaso.Left = (this.Width / 2) - (_Pnl_Traspaso.Width / 2);
            _Pnl_Traspaso.Top = (this.Height / 2) - (_Pnl_Traspaso.Height / 2);
        }

        private void Frm_ZonaporVendedor_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Mtd_Traspaso(string _P_Str_Zona,string _P_Str_ActualVendedor,string _P_Str_NuevoVendedor)
        {
            //----------------------
            string _Str_Cadena = "UPDATE TZONAVENDEDOR SET cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "', cdelete='1' WHERE ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and cvendedor='" + _P_Str_ActualVendedor + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //----------------------   
            _Str_Cadena = "SELECT * FROM TZONAVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and cvendedor='" + _P_Str_NuevoVendedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_Cadena = "UPDATE TZONAVENDEDOR SET cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and cvendedor='" + _P_Str_NuevoVendedor + "'"; }
            else
            { _Str_Cadena = "INSERT INTO TZONAVENDEDOR (ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete)VALUES('" + Frm_Padre._Str_Comp + "','" + _P_Str_Zona + "','" + _P_Str_NuevoVendedor + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //----------------------
            DateTime _Dtm_TempDes = new DateTime(Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Year, Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Month, 1);
            _Str_Cadena = "UPDATE TMOVINVENTAS SET cvendedor='" + _P_Str_NuevoVendedor + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND c_zona='" + _P_Str_Zona + "' AND convert(datetime,convert(varchar(255),cdatemov,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtm_TempDes) + "' AND GETDATE()";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

        }
        private void _Mtd_CargarVendedores(string _P_Str_ActualVendedor, string _P_Str_GrupoVta)
        {
            string _Str_Cadena = "SELECT cvendedor as Código,cvendedor + '-' + cname as Descripción from TVENDEDOR WHERE c_activo='1' and cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend='1' and c_grupo_vta='" + _P_Str_GrupoVta + "' AND cvendedor<>'" + _P_Str_ActualVendedor + "' AND NOT EXISTS(Select * from TZONAVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and TVENDEDOR.cvendedor=TZONAVENDEDOR.cvendedor)";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Vendedor, _Str_Cadena);
        }
        private void _Bt_Cambiar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                if (_Dg_Grid1.CurrentCell != null & _Dg_Grid2.CurrentCell != null)
                {
                    _Mtd_CargarVendedores(_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    if (_Cmb_Vendedor.Items.Count > 1)
                    {
                        _Txt_Pnl_Zona.Text = _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "-" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                        _Txt_Pnl_Vendedor.Text = _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "-" + _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[1].Value.ToString();
                        _Pnl_Traspaso.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No existen vendedores relacionados al grupo de ventas de la zona", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Traspaso.Visible = false;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cmb_Vendedor.SelectedIndex > 0)
            {
                if (MessageBox.Show("Esta seguro de realizar esta operación", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Mtd_Traspaso(_Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Cmb_Vendedor.SelectedValue.ToString());
                    _Mtd_RowHeaderMouseClick();
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Traspaso.Visible = false;
                }
                else
                { _Pnl_Traspaso.Visible = false; }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el nuevo vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Cmb_Vendedor.Focus();
            }
        }

        private void _Dg_Grid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid1.CurrentCell != null)
            {
                string _Str_Cadena = "SELECT TVENDEDOR.cvendedor as Código, TVENDEDOR.cname as Descripción FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor WHERE (TVENDEDOR.ccompany ='" + Frm_Padre._Str_Comp + "')" + " AND (TZONAVENDEDOR.c_zona ='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')" + " and (TZONAVENDEDOR.cdelete ='0')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
            }
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

        private void _Pnl_Traspaso_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Traspaso.Visible)
            {
                panel1.Enabled = false;
                _Dg_Grid1.Enabled = false;
                _Dg_Grid2.Enabled = false;
                _Cmb_Vendedor.Focus();
            }
            else
            {
                panel1.Enabled = true;
                _Dg_Grid1.Enabled = true;
                _Dg_Grid2.Enabled = true;
            }
        }
    }
}