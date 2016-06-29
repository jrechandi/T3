using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_RutaDespacho : Form
    {
        public Frm_RutaDespacho()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        bool _Bol_Tabs = false;
        public Frm_RutaDespacho(string _P_Str_Ruta)
        {
            InitializeComponent();
            _Mtd_Actualizar();
            _Mtd_Tabs(_P_Str_Ruta);
            _Bol_Tabs = true;
        }
        private void _Mtd_Tabs(string _P_Str_Ruta)
        {
            string _Str_Cadena = "Select cdescripcion,cdistanciakm from TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _P_Str_Ruta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Ruta.Text = _P_Str_Ruta;
                _Txt_Descripcion.Text = _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
                _Txt_Km.Text = _Ds.Tables[0].Rows[0][1].ToString().ToUpper();
                _Str_Cadena = "SELECT RTRIM(TESTATE.cname) AS Estado, RTRIM(TCITY.cname) AS Ciudad, TRUTDESPACHOD.cestate, TRUTDESPACHOD.ccity, TRUTDESPACHOD.cpriodespacho " +
    "FROM TRUTDESPACHOD INNER JOIN " +
    "TESTATE ON TRUTDESPACHOD.cgroupcomp = TESTATE.cgroupcomp AND TRUTDESPACHOD.cestate = TESTATE.cestate INNER JOIN " +
    "TCITY ON TRUTDESPACHOD.cestate = TCITY.cestate AND TRUTDESPACHOD.ccity = TCITY.ccity " +
    "WHERE (TRUTDESPACHOD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRUTDESPACHOD.cidrutdespacho = '" + _P_Str_Ruta + "') and TRUTDESPACHOD.cdelete='0' ORDER BY cpriodespacho";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                object[] _Ob = new object[5];
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Ob[0] = _Row["Estado"].ToString();
                    _Ob[1] = _Row["Ciudad"].ToString();
                    _Ob[2] = _Row["cpriodespacho"].ToString();
                    _Ob[3] = _Row["cestate"].ToString();
                    _Ob[4] = _Row["ccity"].ToString();
                    _Dg_Detalle.Rows.Add(_Ob);
                }
                _Tb_Tab.SelectedIndex = 1;
            }
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
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cidrutdespacho FROM TRUTDESPACHOM  where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cidrutdespacho DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Ruta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Kilómetros");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidrutdespacho";
            _Str_Campos[1] = "cdescripcion";
            _Str_Campos[2] = "cdistanciakm";
            string _Str_Cadena = "Select cidrutdespacho as Ruta,cdescripcion as Descripción,cdistanciakm as Kilómetros from TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Rutas", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void _Mtd_Ini()
        {
            _Txt_Ruta.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Km.Text = "";
            _Dg_Detalle.Rows.Clear();
            _Mtd_Cargar_Cmb_Estado();
            _Mtd_Habilitar();
            _Txt_Ruta.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Ruta.Enabled = false;
            _Txt_Descripcion.Enabled = true;
            _Txt_Km.Enabled = true;
            if (_Txt_Ruta.Text.Trim().Length > 0)
            {
                _Grb_Arriba.Enabled = true;
                _Pnl_Derecho.Enabled = true;
            }
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Ruta.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Txt_Km.Enabled = false;
            _Grb_Arriba.Enabled = false;
            _Pnl_Derecho.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Grb_Arriba.Enabled = false; 
            _Pnl_Derecho.Enabled = false;
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Descripcion.Focus();
        }
        private void _Mtd_Cargar_Cmb_Estado()
        {
            _Cmb_Estado.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cestate,UPPER(cname) as cname from TESTATE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cname ASC");
            _Cmb_Estado.DataSource = _Ds.Tables[0];
            _Cmb_Estado.DisplayMember = "cname";
            _Cmb_Estado.ValueMember = "cestate";
            _Cmb_Estado.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Ciudad(string _P_Str_Estado)
        {
            _Cmb_Ciudad.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccity,UPPER(cname) as cname from TCITY where cdelete='0' and cestate='" + _P_Str_Estado + "' ORDER BY cname ASC");
            _Cmb_Ciudad.DataSource = _Ds.Tables[0];
            _Cmb_Ciudad.DisplayMember = "cname";
            _Cmb_Ciudad.ValueMember = "ccity";
            _Cmb_Ciudad.SelectedIndex = -1;
        }
        private void _Mtd_Verificar()
        {
            //if (_Txt_Descripcion.Text.Trim().Length == 0 | _Txt_Km.Text.Trim().Length == 0)
            if (_Txt_Descripcion.Text.Trim().Length == 0)
            { _Grb_Arriba.Enabled = false; _Pnl_Derecho.Enabled = false; }
            else if (_Txt_Descripcion.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
            { 
                _Grb_Arriba.Enabled = true; _Pnl_Derecho.Enabled = true; 
            }
        }
        private void _Mtd_Agregar()
        {
            object[] _Ob = new object[5];
            _Ob[0] = _Cmb_Estado.Text;
            _Ob[1] = _Cmb_Ciudad.Text;
            _Ob[2] = _Dg_Detalle.Rows.Count + 1;
            _Ob[3] = _Cmb_Estado.SelectedValue;
            _Ob[4] = _Cmb_Ciudad.SelectedValue;
            _Dg_Detalle.Rows.Add(_Ob);
            DataGridViewCell _Dgv_Cell = _Dg_Detalle.Rows[_Dg_Detalle.Rows.Count - 1].Cells[0];
            _Dg_Detalle.CurrentCell = _Dgv_Cell;
            _Dg_Detalle.ClearSelection();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private bool _Mtd_Agregado(string _P_Str_Estado,string _P_Str_Ciudad)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                if (_Dg_Row.Cells["Estado"].Value.ToString().Trim() == _P_Str_Estado & _Dg_Row.Cells["Ciudad"].Value.ToString().Trim() == _P_Str_Ciudad)
                { return true; }
            }
            return false;
        }
        private void _Mtd_Prioridad()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                _Dg_Row.Cells[2].Value = _Dg_Row.Index + 1;
            }
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            _Txt_Ruta.Text = _Mtd_Entrada().ToString();
            if (_Txt_Ruta.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Dg_Detalle.Rows.Count > 0)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Txt_Ruta.Text.Trim() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    _Mtd_Met_Actuaizar(_Txt_Ruta.Text.Trim(), true);
                    MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Ruta.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Ruta, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Dg_Detalle.Rows.Count == 0)
                { MessageBox.Show("No existen datos en el detalle. Por favor ingrese...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            if (_Txt_Ruta.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Dg_Detalle.Rows.Count > 0)
            {
                _Mtd_Met_Actuaizar(_Txt_Ruta.Text.Trim(), false);
                MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Er_Error.Dispose();
                return true;
            }
            else
            {
                if (_Txt_Ruta.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Ruta, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Dg_Detalle.Rows.Count == 0)
                { MessageBox.Show("No existen datos en el detalle. Por favor ingrese...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "DELETE FROM TRUTDESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Txt_Ruta.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TRUTDESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Txt_Ruta.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        private void _Mtd_Met_Actuaizar(string _P_Str_Ruta,bool _P_Bol_Guardar)
        {
            string _Str_Km = "";
            string _Str_Cadena = "";
            if (_Txt_Km.Text.Trim().Length == 0)
            {
                _Str_Km = "0";
            }
            else
            {
                _Str_Km = _Txt_Km.Text;
            }
            if (!_P_Bol_Guardar)
            {
                
                _Str_Cadena = "Delete from TRUTDESPACHOD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _P_Str_Ruta + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TRUTDESPACHOM set cdescripcion='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',cdistanciakm='" + _Str_Km + "',cuserupd='" + Frm_Padre._Str_Use + "',cdateupd=GETDATE(),cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _P_Str_Ruta + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else
            {
                _Str_Cadena = "Insert into TRUTDESPACHOM (cgroupcomp,cidrutdespacho,cdescripcion,cdistanciakm,cuseradd,cdateadd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Ruta + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + _Str_Km + "','" + Frm_Padre._Str_Use + "',GETDATE(),'0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                _Str_Cadena = "Insert into TRUTDESPACHOD (cgroupcomp,cidrutdespacho,cestate,ccity,cpriodespacho,cuseradd,cdateadd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Ruta + "','" + _Dg_Row.Cells["Estado"].Value + "','" + _Dg_Row.Cells["Ciudad"].Value + "','" + _Dg_Row.Cells[2].Value + "','" + Frm_Padre._Str_Use + "',GETDATE(),'0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private void Frm_RutaDespacho_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Cmb_Estado();
        }

        private void _Txt_Km_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Km_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Km.Text))
            {
                _Txt_Km.Text = "";
            }
            //_Mtd_Verificar();
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedIndex != -1)
            {_Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString());}
            else
            {_Cmb_Ciudad.DataSource = null;}
        }

        private void _Cmb_Estado_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_Estado();
        }

        private void _Cmb_Ciudad_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedIndex != -1)
            { _Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString()); }
        }

        private void _Txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            _Mtd_Verificar();
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_Estado.SelectedIndex == -1)
            { _Er_Error.SetError(_Cmb_Estado, "Información requerida!!!"); }
            else if (_Cmb_Ciudad.SelectedIndex == -1)
            { _Er_Error.SetError(_Cmb_Ciudad, "Información requerida!!!"); }
            else if (_Mtd_Agregado(_Cmb_Estado.SelectedValue.ToString().Trim(), _Cmb_Ciudad.SelectedValue.ToString().Trim()))
            { MessageBox.Show("El registro ya fue agregado. Coloque uno diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            else
            {
                string _Str_Cadena = "Select * from TRUTDESPACHOD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cestate='" + _Cmb_Estado.SelectedValue + "' and ccity='" + _Cmb_Ciudad.SelectedValue + "' and cdelete=0";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count == 0)
                { _Mtd_Agregar(); }
                else
                { MessageBox.Show("El estado y la ciudad ya pernetecen. Coloque uno diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.Rows.Count > 0)
            {
                if (_Dg_Detalle.SelectedRows.Count == 1)
                {
                    _Dg_Detalle.Rows.RemoveAt(_Dg_Detalle.CurrentCell.RowIndex);
                    _Mtd_Prioridad();
                    _Dg_Detalle.ClearSelection();
                }
                else
                { MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
            else
            { MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Subir_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.Rows.Count > 0)
            {
                if (_Dg_Detalle.SelectedRows.Count == 1)
                {
                    if (_Dg_Detalle.CurrentCell.RowIndex - 1 >= 0)
                    {
                        object _Ob1 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells["Estado"].Value;
                        object _Ob2 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells["Ciudad"].Value;
                        object _Ob3 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells[0].Value;
                        object _Ob4 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells[1].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells["Estado"].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Estado"].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells["Ciudad"].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Ciudad"].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells[0].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[0].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells[1].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[1].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Estado"].Value = _Ob1;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Ciudad"].Value = _Ob2;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[0].Value = _Ob3;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[1].Value = _Ob4;
                        DataGridViewCell _Dgv_Cell = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex - 1].Cells[0];
                        _Dg_Detalle.CurrentCell = _Dgv_Cell;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Selected = true;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void _Bt_Bajar_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.Rows.Count > 0)
            {
                if (_Dg_Detalle.SelectedRows.Count == 1)
                {
                    if (_Dg_Detalle.CurrentCell.RowIndex + 1 <= _Dg_Detalle.Rows.Count - 1)
                    {
                        object _Ob1 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells["Estado"].Value;
                        object _Ob2 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells["Ciudad"].Value;
                        object _Ob3 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells[0].Value;
                        object _Ob4 = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells[1].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells["Estado"].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Estado"].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells["Ciudad"].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Ciudad"].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells[0].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[0].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells[1].Value = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[1].Value;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Estado"].Value = _Ob1;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Ciudad"].Value = _Ob2;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[0].Value = _Ob3;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells[1].Value = _Ob4;
                        DataGridViewCell _Dgv_Cell = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex + 1].Cells[0];
                        _Dg_Detalle.CurrentCell = _Dgv_Cell;
                        _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Selected = true;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("No existen registros en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Er_Error.Dispose();
            _Mtd_Deshabilitar_Todo();
            _Dg_Detalle.Rows.Clear();
            _Txt_Ruta.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0,e.RowIndex);
            _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
            _Txt_Km.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
            string _Str_Cadena = "SELECT RTRIM(TESTATE.cname) AS Estado, RTRIM(TCITY.cname) AS Ciudad, TRUTDESPACHOD.cestate, TRUTDESPACHOD.ccity, TRUTDESPACHOD.cpriodespacho "+
"FROM TRUTDESPACHOD INNER JOIN "+
"TESTATE ON TRUTDESPACHOD.cgroupcomp = TESTATE.cgroupcomp AND TRUTDESPACHOD.cestate = TESTATE.cestate INNER JOIN "+
"TCITY ON TRUTDESPACHOD.cestate = TCITY.cestate AND TRUTDESPACHOD.ccity = TCITY.ccity "+
"WHERE (TRUTDESPACHOD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRUTDESPACHOD.cidrutdespacho = '" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "') and TRUTDESPACHOD.cdelete='0' ORDER BY cpriodespacho";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Ob = new object[5];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Ob[0] = _Row["Estado"].ToString();
                _Ob[1] = _Row["Ciudad"].ToString();
                _Ob[2] = _Row["cpriodespacho"].ToString();
                _Ob[3] = _Row["cestate"].ToString();
                _Ob[4] = _Row["ccity"].ToString();
                _Dg_Detalle.Rows.Add(_Ob);
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            Cursor = Cursors.Default;
            _Tb_Tab.SelectedIndex = 1;
        }

        private void Frm_RutaDespacho_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            if (!_Bol_Tabs)
            {
                if (!_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                }
                else if (!_Txt_Ruta.Enabled & _Txt_Ruta.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else if (_Txt_Ruta.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                }
                else
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false; }
            }
        }

        private void Frm_RutaDespacho_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Txt_Descripcion_Leave(object sender, EventArgs e)
        {
            _Txt_Descripcion.Text = _Txt_Descripcion.Text.Trim().ToUpper();
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
    }
}