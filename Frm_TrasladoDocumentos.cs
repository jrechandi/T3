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
    public partial class Frm_TrasladoDocumentos : Form
    {
        public Frm_TrasladoDocumentos()
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
            _Mtd_Vendedores();
            _Mtd_GridTraspasos();
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
        }
        public void _Mtd_Nuevo()
        {
            tabControl1.Selecting -= new TabControlCancelEventHandler(tabControl1_Selecting);
            tabControl1.SelectTab(1);            
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                e.Cancel = true;
            }
        }
        private void _Mtd_Vendedores()
        {
            try
            {
                _Str_SentenciaSQL = "SELECT CVENDEDOR,CVENDEDOR+' - '+CNAME as cname FROM VST_VENDEDORCOMP WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Cmb_VendedorA.SelectedIndexChanged-=new EventHandler(_Cmb_VendedorA_SelectedIndexChanged);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_VendedorA, _DS_DataSet, "cname", "cvendedor");
                _Cmb_VendedorA.SelectedIndexChanged += new EventHandler(_Cmb_VendedorA_SelectedIndexChanged);
                _Cmb_VendedorB.SelectedIndexChanged-=new EventHandler(_Cmb_VendedorB_SelectedIndexChanged);
                _Cls_Varios._Mtd_CargarCombo(_Cmb_VendedorB, _DS_DataSet, "cname", "cvendedor");
                _Cmb_VendedorB.SelectedIndexChanged += new EventHandler(_Cmb_VendedorB_SelectedIndexChanged);
            }
            catch
            {
            }
        }
        private void _Mtd_GridTraspasos()
        {
            try
            {
                _Str_SentenciaSQL = "select distinct cidtrasladodocu,cfecha,cvendedor_a,cvendedor_d,cimpreso,cprocesado from VST_TTRASLADODOCUMENTOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Dtg_TrasladoCarteraMaestra.DataSource = _DS_DataSet.Tables[0].DefaultView;
                _Dtg_TrasladoCarteraMaestra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
        }
        string _Str_SentenciaSQL;
        DataSet _DS_DataSet = new DataSet();
        CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
        private void Frm_TrasladoDocumentos_Load(object sender, EventArgs e)
        {

        }

        private void _Btn_MostrarCarteraA_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Cmb_VendedorA.Items.Count > 0)
                {
                    if (_Cmb_VendedorA.SelectedIndex > 0)
                    {
                        _Mtd_Cartera(_Dtg_CarteraVenA, _Cmb_VendedorA.SelectedValue.ToString(),true);
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
        private void _Mtd_Cartera(DataGridView _Dtg_Grid, string _Str_Vendedor, bool _Bol_CarteraA)
        {
            try
            {
                if (_Bol_CarteraA)
                {
                    _Str_SentenciaSQL = "select '0' as Seleccionar,ctipo,cnumero,csaldo,ccliente,ctipodocument from VST_TRASPASOCARTERA where cvendedor='" + _Str_Vendedor + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                }
                else
                {
                    _Str_SentenciaSQL = "select ctipo,cnumero,csaldo,ccliente,ctipodocument from VST_TRASPASOCARTERA where cvendedor='" + _Str_Vendedor + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                }
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_DS_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                    _Dtg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("El vendedor seleccionado no tiene documentos disponibles", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                }
                _Dtg_Grid.DefaultCellStyle.BackColor = Color.White;
                _Dtg_Grid.Columns[5].Visible = false;                
                if (_Bol_CarteraA)
                {
                    _Dtg_Grid.Columns[5].Visible = true;
                    _Dtg_Grid.Columns[6].Visible = false; 
                    _Dtg_Grid.ReadOnly = false;
                    _Dtg_Grid.Columns[0].ReadOnly = false;
                    _Dtg_Grid.Columns[1].ReadOnly = false;
                    _Dtg_Grid.Columns[2].ReadOnly = true;
                    _Dtg_Grid.Columns[3].ReadOnly = true;
                    _Dtg_Grid.Columns[4].ReadOnly = true;
                    _Dtg_Grid.Columns[5].ReadOnly = true;
                    _Dtg_Grid.Columns[6].ReadOnly = true;
                }
            }
            catch
            {
            }
        }
        private void _Mtd_Cartera_(DataGridView _Dtg_Grid, string _Str_Vendedor, bool _Bol_CarteraA)
        {
            try
            {
                if (_Bol_CarteraA)
                {
                    _Str_SentenciaSQL = "select '0' as Seleccionar,ctipo,cnumero,csaldo,ccliente,ctipodocument from VST_TRASPASOCARTERA where cvendedor='" + _Str_Vendedor + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                }
                else
                {
                    _Str_SentenciaSQL = "select ctipo,cnumero,csaldo,ccliente,ctipodocument from VST_TRASPASOCARTERA where cvendedor='" + _Str_Vendedor + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                }
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_DS_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                    _Dtg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    //MessageBox.Show("El vendedor seleccionado no tiene cartera disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Dtg_Grid.DataSource = _DS_DataSet.Tables[0].DefaultView;
                    _Dtg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                if (_Bol_CarteraA)
                {
                    _Dtg_Grid.Columns[0].ReadOnly = false;
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
                        _Mtd_Cartera(_Dtg_CarteraVenB, _Cmb_VendedorB.SelectedValue.ToString(),false);
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

        private void Frm_TrasladoDocumentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Mtd_Cancelar()
        {
            tabControl1.SelectedIndex = 0;
        }

        private void Frm_TrasladoDocumentos_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
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

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        private string _Mtd_Traspasar(string _Str_VendedorA, string _Str_VendedorB, string _Str_NumDocu, string _Str_TipoDocumento, string _Str_Cliente)
        {
            string _Str_Codigo = "";
            try
            {
                SqlParameter[] _SQL_Parametros = new SqlParameter[6];
                _SQL_Parametros[0] = new SqlParameter("@cvendedorA", SqlDbType.VarChar);
                _SQL_Parametros[0].Value = _Str_VendedorA;
                _SQL_Parametros[1] = new SqlParameter("@cvendedorB", SqlDbType.VarChar);
                _SQL_Parametros[1].Value = _Str_VendedorB;
                _SQL_Parametros[2] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _SQL_Parametros[2].Value = Frm_Padre._Str_Comp;
                _SQL_Parametros[3] = new SqlParameter("@cnumdocu", SqlDbType.VarChar);
                _SQL_Parametros[3].Value = _Str_NumDocu;
                _SQL_Parametros[4] = new SqlParameter("@ctipodocument", SqlDbType.VarChar);
                _SQL_Parametros[4].Value = _Str_TipoDocumento;
                _SQL_Parametros[5] = new SqlParameter("@ccliente", SqlDbType.VarChar);
                _SQL_Parametros[5].Value = _Str_Cliente;
                _Str_Codigo = CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_TRASPASARDOCUMENTO", _SQL_Parametros, "@cidtrasladodocuout");
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
        private void _Mtd_Imprimir()
        {
            int _Int_Cont = 0;
            if (_Cls_Varios._Mtd_VerificarClaveUsuario(_Txt_Clave.Text))
            {
                _Str_SentenciaSQL = "SELECT MAX(cidtrasladodocu) FROM TTRASLADODOCU WHERE CCOMPANY='"+Frm_Padre._Str_Comp+"'";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                string _Str_IdTraslado = "1";
                if (_DS_DataSet.Tables[0].Rows[0][0].ToString() != "")
                {
                    _Str_IdTraslado = Convert.ToString(Convert.ToInt32(_DS_DataSet.Tables[0].Rows[0][0].ToString()) + 1);
                }
                foreach (DataGridViewRow _Dtg_Row in _Dtg_CarteraVenA.Rows)
                {
                    if (_Dtg_Row.Cells[1].Value.ToString() == "1")
                    {
                        _Int_Cont++;
                        string _Str_NumDocu = "";
                        string _Str_TipoDocument = "";
                        string _Str_Cliente = "";
                        _Str_NumDocu = _Dtg_Row.Cells[3].Value.ToString();
                        _Str_TipoDocument = _Dtg_Row.Cells[6].Value.ToString();
                        string[] _Str_Cliente_ = _Dtg_Row.Cells[5].Value.ToString().Split('-');
                        _Str_Cliente = _Str_Cliente_[0].TrimEnd();
                        string _Str_Codigo = _Mtd_Traspasar(_Cmb_VendedorA.SelectedValue.ToString(), _Cmb_VendedorB.SelectedValue.ToString(), _Str_NumDocu, _Str_TipoDocument, _Str_Cliente);
                        if (_Str_Codigo != "")
                        {
                            _Str_SentenciaSQL = "insert into TTRASLADODOCU(ccompany,cidtrasladodocu,ctipodocument,cnumdocu,cfecha,cvendedor_a,cvendedor_d,cimpreso,cprocesado) values ('" + Frm_Padre._Str_Comp + "','" + _Str_IdTraslado + "','" + _Str_TipoDocument + "','" + _Str_NumDocu + "',getdate(),'" + _Cmb_VendedorA.SelectedValue.ToString() + "','" + _Cmb_VendedorB.SelectedValue.ToString() + "',0,1)";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                        }
                    }
                    else
                    {
                    }
                }
                if (_Int_Cont == 0)
                {
                    MessageBox.Show(this, "Seleccione uno o mas documentos para el traslado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                    
                    _Mtd_Cartera_(_Dtg_CarteraVenA, _Cmb_VendedorA.SelectedValue.ToString(), true);
                    _Mtd_Cartera_(_Dtg_CarteraVenB, _Cmb_VendedorB.SelectedValue.ToString(), false);
                    _Mtd_GridTraspasos();
                Imprimir:
                    PrintDialog _Print = new PrintDialog();
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        REPORTESS _Frm_Reporte = new REPORTESS(new string[] { "VST_TRASPASODOCUMENTODETAIL" }, "", "T3.Report.rTraspasoDocumentos", "Section2", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladodocu='" + _Str_IdTraslado + "'", _Print, true);
                        _Frm_Reporte.Show();
                        if (MessageBox.Show("¿Se imprimió correctamente el traslado del documento?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                                            MessageBox.Show("Debe seleccionar un vendedor distinto para realizar el traspaso del documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        }
                                        else
                                        {
                                            _Str_SentenciaSQL = "update TTRASLADODOCU set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladodocu='" + _Str_IdTraslado + "'";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                                            _Mtd_GridTraspasos();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso del documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso del documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void _Btn_Traspasar_Click(object sender, EventArgs e)
        {
            if (_Cmb_VendedorA.Items.Count > 0 && _Cmb_VendedorB.Items.Count > 0)
            {
                if (_Cmb_VendedorA.SelectedIndex > 0 && _Cmb_VendedorB.SelectedIndex > 0)
                {
                    if (_Cmb_VendedorA.SelectedValue.ToString().TrimEnd() == _Cmb_VendedorB.SelectedValue.ToString().TrimEnd())
                    {
                        MessageBox.Show("Debe seleccionar un vendedor distinto para realizar el traspaso del documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (_Dtg_CarteraVenA.CurrentCell != null)
                        {
                            _Pnl_Clave.Parent = this;
                            _Pnl_Clave.BringToFront();
                            this._Pnl_Clave.Visible = true;
                            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un documento para continuar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso del documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vendedor en cada listado para realizar el traspaso del documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }        
        }

        private void _Dtg_CarteraVenA_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int _Int_Celda=e.RowIndex;
                foreach (DataGridViewRow _Dtg_Row in _Dtg_CarteraVenA.Rows)
                {
                    _Dtg_Row.DefaultCellStyle.BackColor = Color.White;
                }
                _Dtg_CarteraVenA.Rows[_Int_Celda].DefaultCellStyle.BackColor = Color.Khaki;
                _Dtg_CarteraVenA.Columns[6].Visible = false;
            }
            catch
            {
            }
        }

        private void _Dtg_CarteraVenA_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int _Int_Celda = e.RowIndex;
                foreach (DataGridViewRow _Dtg_Row in _Dtg_CarteraVenA.Rows)
                {
                    _Dtg_Row.DefaultCellStyle.BackColor = Color.White;
                }
                _Dtg_CarteraVenA.Rows[_Int_Celda].DefaultCellStyle.BackColor = Color.Khaki;
                _Dtg_CarteraVenA.Columns[6].Visible = false;
            }
            catch
            {
            }
        }
        private void _Mtd_ImprimirSG(string _Str_Codigo)
        {
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                _DS_DataSet=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM VST_TRASPASODOCUMENTODETAILREAL WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladodocu='" + _Str_Codigo + "'");
                REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rTraspasoDocumentos",_DS_DataSet.Tables[0],_Print,true, "Section2", "cabecera", "rif", "nit");
                //REPORTESS _Frm_Reporte = new REPORTESS(new string[] { "VST_TTRASPASOCARTERADETALLE" }, "", "T3.Report.rTrasladoCartera", "Section2", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladocarte='" + _Str_Codigo + "'", _Print, true);
                _Frm_Reporte.Show();
                if (MessageBox.Show("¿Se imprimió correctamente el traslado del documento?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Str_SentenciaSQL = "update TTRASLADODOCU set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidtrasladodocu='" + _Str_Codigo + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    _Mtd_GridTraspasos();
                }
            }
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

        private void _Cmb_VendedorA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Cartera_(_Dtg_CarteraVenA, "", true);
        }

        private void _Cmb_VendedorB_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Cartera_(_Dtg_CarteraVenB, "", true);
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