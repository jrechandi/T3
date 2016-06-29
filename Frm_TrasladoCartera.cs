using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_TrasladoCartera : Form
    {
        public Frm_TrasladoCartera()
        {
            InitializeComponent();
            if (_Cls_Varios._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_TRASCART_CXC"))
            {
                _Btn_Traspasar.Enabled = true;
            }
            else
            {
                _Btn_Traspasar.Enabled = false;
            }
            _Mtd_AutoSize();
            _Mtd_Vendedores();
            _Mtd_GridTraspasos();
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
        }
        private void _Mtd_AutoSize()
        {
            panel1.Width = this.Width / 2;
            panel3.Width = this.Width / 2;
        }
        public void _Mtd_Nuevo()
        {
            tabControl1.Selecting-=new TabControlCancelEventHandler(tabControl1_Selecting);
            tabControl1.SelectTab(1);
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
        }
        string _Str_SentenciaSQL;
        DataSet _DS_DataSet = new DataSet();
        CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
        
        private void Frm_TrasladoCartera_Load(object sender, EventArgs e)
        {

        }
        private void _Mtd_Vendedores()
        {
            try
            {
                _Str_SentenciaSQL = "SELECT CVENDEDOR,CVENDEDOR+' - '+CNAME as cname FROM VST_VENDEDORCOMP WHERE CCOMPANY='"+Frm_Padre._Str_Comp+"'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Cmb_VendedorA.SelectedIndexChanged -= new EventHandler(_Cmb_VendedorA_SelectedIndexChanged);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_VendedorA, _DS_DataSet, "cname", "cvendedor");
                _Cmb_VendedorA.SelectedIndexChanged += new EventHandler(_Cmb_VendedorA_SelectedIndexChanged);
                _Cmb_VendedorB.SelectedIndexChanged -= new EventHandler(_Cmb_VendedorB_SelectedIndexChanged);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_VendedorB, _DS_DataSet, "cname", "cvendedor");
                _Cmb_VendedorB.SelectedIndexChanged += new EventHandler(_Cmb_VendedorB_SelectedIndexChanged);
            }
            catch
            {
            }
        }
        private void _Mtd_Cartera(DataGridView _Dtg_Grid, string _Str_Vendedor)
        {
            try
            {
                _Str_SentenciaSQL = "select ctipo,cnumero,csaldo,ccliente from VST_TRASPASOCARTERA where cvendedor='" + _Str_Vendedor + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_DS_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                    _Dtg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("El vendedor seleccionado no tiene cartera disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Dtg_Grid.DataSource = null;
                }
            }
            catch
            {
            }
        }
        private void _Mtd_Cartera_(DataGridView _Dtg_Grid, string _Str_Vendedor)
        {
            try
            {
                _Str_SentenciaSQL = "select ctipo,cnumero,csaldo,ccliente from VST_TRASPASOCARTERA where cvendedor='" + _Str_Vendedor + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_DS_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                    _Dtg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                    _Dtg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch
            {
            }
        }
        private void _Btn_MostrarCarteraA_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Cmb_VendedorA.Items.Count > 0)
                {
                    if (_Cmb_VendedorA.SelectedIndex > 0)
                    {
                        _Mtd_Cartera(_Dtg_CarteraVenA, _Cmb_VendedorA.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
            }
        }

        private void _Btn_MostrarCarteraB_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Cmb_VendedorB.Items.Count > 0)
                {
                    if (_Cmb_VendedorB.SelectedIndex > 0)
                    {
                        _Mtd_Cartera(_Dtg_CarteraVenB, _Cmb_VendedorB.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
            }
        }
        private void _Mtd_GridTraspasos()
        {
            try
            {
                _Str_SentenciaSQL = "select cidtrasladocarte,cfecha,cvendedor_a,cvendedor_d,cimpreso,cprocesado from VST_TTRASLADOCARTERAM where ccompany='"+Frm_Padre._Str_Comp+"'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Dtg_TrasladoCarteraMaestra.DataSource = _DS_DataSet.Tables[0].DefaultView;
                _Dtg_TrasladoCarteraMaestra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
        }
        private string _Mtd_Traspasar(string _Str_VendedorA, string _Str_VendedorB)
        {
            string _Str_Codigo="";
            try
            {
                SqlParameter[] _SQL_Parametros = new SqlParameter[3];
                _SQL_Parametros[0] = new SqlParameter("@cvendedorA", SqlDbType.VarChar);
                _SQL_Parametros[0].Value = _Str_VendedorA;
                _SQL_Parametros[1] = new SqlParameter("@cvendedorB", SqlDbType.VarChar);
                _SQL_Parametros[1].Value = _Str_VendedorB;
                _SQL_Parametros[2] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _SQL_Parametros[2].Value = Frm_Padre._Str_Comp;
                _Str_Codigo = CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_TRASPASARCARTERA", _SQL_Parametros, "@cidtrasladocarteout");
                if (_Str_Codigo != "")
                {
                    //MessageBox.Show("El traspaso fue realizado correctamente");
                }
            }
            catch
            {
            }
            return _Str_Codigo;
        }
        private void _Btn_Traspasar_Click(object sender, EventArgs e)
        {
            if (_Cmb_VendedorA.Items.Count > 0 && _Cmb_VendedorB.Items.Count > 0)
            {
                if (_Cmb_VendedorA.SelectedIndex > 0 && _Cmb_VendedorB.SelectedIndex > 0)
                {
                    if (_Cmb_VendedorA.SelectedValue.ToString().TrimEnd() == _Cmb_VendedorB.SelectedValue.ToString().TrimEnd())
                    {
                        MessageBox.Show("Debe seleccionar un vendedor distinto para realizar el traspaso de la cartera", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        this._Pnl_Clave.Visible = true;
                        _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                        _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso de la cartera", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso de la cartera", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }            
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            if (_Pnl_Clave.Visible)
            {
                tabControl1.Enabled = false;
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
                panel4.Enabled = false;
                panel5.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel3.Enabled = true;
                panel4.Enabled = true;
                panel5.Enabled = true;
            }
        }
        public void _Mtd_Ini()
        {
            _Txt_Clave.Text = "";            
        }
        private void _Mtd_ImprimirSG(string _Str_Codigo)
        {
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                REPORTESS _Frm_Reporte = new REPORTESS(new string[] { "VST_TTRASPASOCARTERADETALLE" }, "", "T3.Report.rTrasladoCartera", "Section2", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladocarte='" + _Str_Codigo + "'", _Print, true);
                _Frm_Reporte.Show();
                if (MessageBox.Show("¿Se imprimió correctamente el traslado de carteras?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Str_SentenciaSQL = "update TTRASLADOCARTEM set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladocarte='" + _Str_Codigo + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    _Mtd_GridTraspasos();
                }
            }
        }
        private void _Mtd_Imprimir()
        {
            if (_Cls_Varios._Mtd_VerificarClaveUsuario(_Txt_Clave.Text))
            {
                string _Str_Codigo = _Mtd_Traspasar(_Cmb_VendedorA.SelectedValue.ToString(), _Cmb_VendedorB.SelectedValue.ToString());
                _Mtd_Cartera_(_Dtg_CarteraVenA, _Cmb_VendedorA.SelectedValue.ToString());
                _Mtd_Cartera_(_Dtg_CarteraVenB, _Cmb_VendedorB.SelectedValue.ToString());
                _Mtd_GridTraspasos();
            Imprimir:
                PrintDialog _Print = new PrintDialog();
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    REPORTESS _Frm_Reporte = new REPORTESS(new string[] { "VST_TTRASPASOCARTERADETALLE" }, "", "T3.Report.rTrasladoCartera", "Section2", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladocarte='" + _Str_Codigo + "'", _Print, true);
                    _Frm_Reporte.Show();
                    if (MessageBox.Show("¿Se imprimió correctamente el traslado de carteras?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;                        
                        if (_Cls_Varios._Mtd_VerificarClaveUsuario(_Txt_Clave.Text))
                        {
                            if (_Cmb_VendedorA.Items.Count > 0 && _Cmb_VendedorB.Items.Count > 0)
                            {
                                if (_Cmb_VendedorA.SelectedIndex > 0 && _Cmb_VendedorB.SelectedIndex > 0)
                                {
                                    if (_Cmb_VendedorA.SelectedValue.ToString().TrimEnd() == _Cmb_VendedorB.SelectedValue.ToString().TrimEnd())
                                    {
                                        MessageBox.Show("Debe seleccionar un vendedor distinto para realizar el traspaso de la cartera", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                    else
                                    {
                                        _Str_SentenciaSQL = "update TTRASLADOCARTEM set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladocarte='" + _Str_Codigo + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                                        _Mtd_GridTraspasos();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso de la cartera", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso de la cartera", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            _Pnl_Clave.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
                        }
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        goto Imprimir;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _Mtd_Imprimir();
            }
            catch(Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_TrasladoCarteraMaestra.CurrentCell != null)
            {
                try
                {
                    _Mtd_ImprimirSG(_Dtg_TrasladoCarteraMaestra[0, _Dtg_TrasladoCarteraMaestra.CurrentCell.RowIndex].Value.ToString());
                }
                catch (Exception _Ex)
                { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
            }
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = tabControl1;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }
        private void Frm_TrasladoCartera_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }
        private void _Mtd_Cancelar()
        {
            tabControl1.SelectedIndex = 0;
        }
        private void Frm_TrasladoCartera_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                e.Cancel = true;
            }
        }

        private void _Cmb_VendedorA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Cartera_(_Dtg_CarteraVenA, "");
        }

        private void _Cmb_VendedorB_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Cartera_(_Dtg_CarteraVenB, "");
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_CarteraVenA.CurrentCell != null)
            {
                _Dtg_CarteraVenA[1, _Dtg_CarteraVenA.CurrentCell.RowIndex].Value = "1";
            }
            _Dtg_CarteraVenA.EndEdit();
        }

        private void seleccionarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_CarteraVenA.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_CarteraVenA.Rows)
                {
                    _Dtg_Fila.Cells[1].Value = "1";
                    _Dtg_CarteraVenA.EndEdit();
                }
            }
        }

        private void eliminarSelecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dtg_CarteraVenA.CurrentCell != null)
            {
                foreach (DataGridViewRow _Dtg_Fila in _Dtg_CarteraVenA.Rows)
                {
                    _Dtg_Fila.Cells[1].Value = "0";
                    _Dtg_CarteraVenA.EndEdit();
                }
            }
        }
    }
}