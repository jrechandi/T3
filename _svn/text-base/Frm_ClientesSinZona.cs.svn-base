using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ClientesSinZona : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ClientesSinZona()
        {
            InitializeComponent();
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
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_rif";
            _Str_Campos[2] = "c_nomb_comer";
            string _Str_Cadena = "Select ccliente as Código,c_rif as Rif,c_nomb_comer as Descripción,c_direcc_fiscal,c_estado,c_ciudad from TCLIENTE where c_activo='1' and cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT ccliente FROM TZONACLIENTE WHERE (cdelete='0') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=TZONACLIENTE.ccliente)";
            //string _Str_Cadena = "select ccliente as Código,c_rif as Rif,c_nomb_comer as Descripción,c_direcc_fiscal from TCLIENTE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT ccliente, c_rif, c_nomb_comer FROM  vst_rutavisita WHERE (cdelete='0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=vst_rutavisita.ccliente)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
        }
        private void _Mdt_Ini()
        {
            _Txt_Cliente.Text = "";
            _Txt_Denominacion.Text = "";
            _Txt_Direcc_Fiscal.Text = "";
            _Txt_Estado.Text = "";
            _Txt_Ciudad.Text = "";
            _Txt_Rif.Text = "";
            _Dg_Zonas.DataSource = null;
        }
        private void _Mtd_CargarDirecionesD(string _P_Str_Cliente)
        {
            string _Str_Cadena = "select c_direcc_despa,rtrim(c_direcc_descrip) from TDDESPACHOC where ccliente='" + _P_Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' order by c_direcc_despa";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Direcc, _Str_Cadena);
            if (_Cmb_Direcc.Items.Count == 2)
            { _Cmb_Direcc.SelectedIndex = 1; }
        }
        private void _Mtd_Actualizar_Zonas(string _P_Str_Cliente,string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_zona as Zona,cname as Descripción,cgrupovta,cnamevendedor as Vendedor from vst_zonasrelacionadas where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccliente='" + _P_Str_Cliente + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Zonas.DataSource = _Ds.Tables[0];
            _Dg_Zonas.Columns[2].Visible = false;
            _Dg_Zonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Agregar(string _P_Str_Codigo, string _P_Str_rif, string _P_Str_Zona, string _P_Str_Grupo)
        {
            string _Str_Cadena = "Select cdelete from TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and ccliente='" + _P_Str_Codigo + "' and cgrupovta='" + _P_Str_Grupo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _P_Str_Zona + "','" + _P_Str_Codigo + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _P_Str_Grupo + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TZONACLIENTE", "ccompany,c_zona,ccliente,cdateadd,cuseradd,cdelete,cgrupovta", _Str_Cadena);
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCLIENTE", "c_zonificado='1',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_rif + "'");
            }
            else
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    if (MessageBox.Show("El cliente (" + _P_Str_Codigo + ") fue eliminado de la zona de ventas (" + _P_Str_Zona + "). ¿Desea volver a agregarlo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONACLIENTE", "cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and ccliente='" + _P_Str_Codigo + "' and cgrupovta='" + _P_Str_Grupo + "'");
                    }
                }
            }

        }
        private void _Mtd_CargarInfPanel(string _P_Str_Item, string _P_Str_Value)
        {
            _Txt_Descrip.Text = _P_Str_Item;
            string _Str_Estado = "";
            string _Str_Ciudad = "";
            string _Str_Cadena = "Select c_estado,c_ciudad from TDDESPACHOC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text + "' and c_direcc_despa='" + _P_Str_Value + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Estado = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_Ciudad = _Ds.Tables[0].Rows[0][1].ToString();
            }
            if (_Str_Estado.Trim().Length > 0)
            {
                _Str_Cadena = "Select cname from TESTATE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cestate='" + _Str_Estado + "' and cdelete='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Txt_Pnl_Estado.Text = _Ds.Tables[0].Rows[0][0].ToString(); }
            }
            if (_Str_Estado.Trim().Length > 0 & _Str_Ciudad.Trim().Length > 0)
            {
                _Str_Cadena = "Select cname from TCITY where cestate='" + _Str_Estado + "' and ccity='" + _Str_Ciudad + "' and cdelete='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Txt_Pnl_Ciudad.Text = _Ds.Tables[0].Rows[0][0].ToString(); }
            }
        }
        private void _Mtd_IniPanel()
        {
            _Txt_Descrip.Text = "";
            _Txt_Pnl_Ciudad.Text = "";
            _Txt_Pnl_Estado.Text = "";
        }
        private void Frm_ClientesSinZona_Load(object sender, EventArgs e)
        {
            _Pnl_Direcc.Left = (this.Width / 2) - (_Pnl_Direcc.Width / 2);
            _Pnl_Direcc.Top = (this.Height / 2) - (_Pnl_Direcc.Height / 2);
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Actualizar();
        }
        private void Frm_ClientesSinZona_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ClientesSinZona_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Mdt_Ini();
                _Txt_Cliente.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                _Txt_Denominacion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                _Txt_Rif.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_Direcc_Fiscal.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                DataSet _Ds;
                string _Str_Cadena = "";
                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex).Length > 0)
                {
                    _Str_Cadena = "Select cname from TESTATE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cestate='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex) + "' and cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    { _Txt_Estado.Text = _Ds.Tables[0].Rows[0][0].ToString(); }
                }
                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex).Length > 0 & _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex).Length > 0)
                {
                    _Str_Cadena = "Select cname from TCITY where cestate='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex) + "' and ccity='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex) + "' and cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    { _Txt_Ciudad.Text = _Ds.Tables[0].Rows[0][0].ToString(); }
                }
                _Bt_Direcc.Enabled = true;
                _Mtd_CargarDirecionesD(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                _Mtd_Actualizar_Zonas(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex));
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
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

        private void _Dg_Zonas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Zonas.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de asignar esta zona a este cliente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Agregar(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim(), _Dg_Zonas.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), _Dg_Zonas.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    _Mdt_Ini();
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Direcc.Visible)
            { _Tb_Tab.Enabled = false; _Cmb_Direcc.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }
       
        private void _Cmb_Direcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Direcc.DataSource != null)
            {
                if (_Cmb_Direcc.SelectedIndex > 0)
                { _Mtd_CargarInfPanel(_Cmb_Direcc.Text, _Cmb_Direcc.SelectedValue.ToString()); }
                else
                { _Mtd_IniPanel(); }
            }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Direcc.Visible = false;
        }

        private void _Bt_Direcc_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "select c_direcc_despa,rtrim(c_direcc_descrip) from TDDESPACHOC where ccliente='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' order by c_direcc_despa";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Pnl_Direcc.Visible = true;
                }
                else
                {
                    MessageBox.Show("El cliente no tiene dirección de Despacho", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para mostrar la información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}