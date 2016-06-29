using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace T3
{
    public partial class Frm_VerificacionTarjetas : Form
    {
        public Frm_VerificacionTarjetas()
        {
            InitializeComponent();
            _Bol_Autorizacion = false;
            string _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax,'0' as Seleccionar from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='1' order by id_tarjetainv";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Dg_Grid.Columns["cnamef1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        bool _Bol_Autorizacion;
        bool _Bol_InHabilitar;
        public Frm_VerificacionTarjetas(bool _P_Bol_Autorizacion)
        {
            InitializeComponent();
            _Bol_Autorizacion = _P_Bol_Autorizacion;
            _Bol_InHabilitar = false;
            string _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax,cnousada as Seleccionar from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='1' and cnousada='1' order by id_tarjetainv";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Dg_Grid.Columns["cnamef1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public Frm_VerificacionTarjetas(bool _P_Bol_Autorizacion, bool _P_Bol_Inhabilitar)
        {
            InitializeComponent();
            _Bol_Autorizacion = _P_Bol_Autorizacion;
            _Bol_InHabilitar = _P_Bol_Inhabilitar;
            string _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax,cnousada as Seleccionar from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='1' and cnousada='0' order by id_tarjetainv";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Dg_Grid.Columns["cnamef1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Buscar(string _P_Str_Numero)
        {
            if (!_Bol_Autorizacion)
            {
                string _Str_Cadena = "Select cproducto,cnamefc AS cnamef from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Numero + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Producto.Text = _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim();
                    _Txt_Descripcion.Text = _Ds.Tables[0].Rows[0]["cnamef"].ToString().Trim();
                    _Bt_Aceptar_Arriba.Focus();
                }
                else
                {
                    MessageBox.Show("Numero de tarjeta invalido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Txt_Producto.Text = "";
                    _Txt_Descripcion.Text = "";
                    _Txt_Tarjeta.Text = "";
                    _Txt_Tarjeta.Focus();
                }
            }
            else
            {
                if (_Bol_InHabilitar)
                {
                    string _Str_Cadena = "Select cproducto,cnamefc AS cnamef from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Numero + "' and VST_INVENTARIOFISICO.cnousada='0'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        DataSet _Ds_DataSet = new DataSet();
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cexisrealu1,cexisrealu2 FROM TPRODUCTO WHERE cproducto='" + _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim() + "' and cexisrealu1>0 or cproducto='" + _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim() + "' and cexisrealu2>0");
                        if (_Ds_DataSet.Tables[0].Rows.Count < 1)
                        {
                            _Txt_Producto.Text = _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim();
                            _Txt_Descripcion.Text = _Ds.Tables[0].Rows[0]["cnamef"].ToString().Trim();
                            _Bt_Aceptar_Arriba.Focus();
                        }
                        else
                        {
                            MessageBox.Show("La tarjeta no puede ser inhabilitada por que el producto tiene existencia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Txt_Producto.Text = "";
                            _Txt_Descripcion.Text = "";
                            _Txt_Tarjeta.Text = "";
                            _Txt_Tarjeta.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Numero de tarjeta invalido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Txt_Producto.Text = "";
                        _Txt_Descripcion.Text = "";
                        _Txt_Tarjeta.Text = "";
                        _Txt_Tarjeta.Focus();
                    }
                }
                else
                {
                    string _Str_Cadena = "Select cproducto,cnamefc AS cnamef from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Numero + "' and VST_INVENTARIOFISICO.cnousada='1'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Txt_Producto.Text = _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim();
                        _Txt_Descripcion.Text = _Ds.Tables[0].Rows[0]["cnamef"].ToString().Trim();
                        _Bt_Aceptar_Arriba.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Numero de tarjeta invalido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Txt_Producto.Text = "";
                        _Txt_Descripcion.Text = "";
                        _Txt_Tarjeta.Text = "";
                        _Txt_Tarjeta.Focus();
                    }
                }                
            }
        }
        private void _Mtd_Marcar(string _P_Int_Numero)
        {
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Int_Numero.Trim())
                { _Dg_Row.Cells["Select"].Value = 1; _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Grid.Rows[_Int_Row].Cells[0];
                _Dg_Grid.CurrentCell = _Dg_Cel;
                _Txt_Producto.Text = "";
                _Txt_Descripcion.Text = "";
                _Txt_Tarjeta.Text = "";
                _Txt_Tarjeta.Focus();
            }

        }
        private void Frm_VerificacionTarjetas_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Productos.Left = (this.Width / 2) - (_Pnl_Productos.Width / 2);
            _Pnl_Productos.Top = (this.Height / 2) - (_Pnl_Productos.Height / 2);
        }
        private void _Mtd_AgregarProducto(string _P_Str_Tarjeta)
        {
            string _Str_Cadena = "SELECT cproducto,cnamefc,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax FROM VST_INVENTARIOFISICO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_tarjetainv='" + _P_Str_Tarjeta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                object[] _Ob = new object[5];
                _Ob[0] = _P_Str_Tarjeta.Trim();
                _Ob[1] = _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim().ToUpper();
                _Ob[2] = _Ds.Tables[0].Rows[0]["cnamefc"].ToString().Trim().ToUpper();
                _Ob[3] = _Ds.Tables[0].Rows[0]["cidproductod"].ToString().Trim();
                _Ob[4] = _Ds.Tables[0].Rows[0]["cprecioventamax"].ToString().Trim();
                _Dg_Productos.Rows.Add(_Ob);
                _Dg_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Productos.Columns["cnamef2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void _Bt_Finalizar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
            this._Pnl_Clave.Visible = true;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Txt_Tarjeta.Text.Trim().Length > 0)
            {
                _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
            }
        }

        private void _Txt_Tarjeta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Tarjeta.Text))
            {
                _Txt_Tarjeta.Text = "";
            }
        }

        private void _Txt_Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    if (_Txt_Tarjeta.Text.Trim().Length > 0)
                    {
                        _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
                    }
                }
            }
        }

        private void _Bt_Cancelar_Arriba_Click(object sender, EventArgs e)
        {
            _Txt_Producto.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Tarjeta.Text = "";
            _Txt_Tarjeta.Focus();
        }

        private void _Bt_Aceptar_Arriba_Click(object sender, EventArgs e)
        {
            if (_Txt_Producto.Text.Trim().Length > 0 & _Txt_Tarjeta.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Marcar(_Txt_Tarjeta.Text.Trim());
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar la operación","Requerimiento",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void Frm_VerificacionTarjetas_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            if (_Pnl_Clave.Visible)
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
            else
            {
                panel1.Enabled = true;
                panel2.Enabled = true;
            }          
            
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        private bool _Mtd_ExistProducto(string _Str_Producto, string _P_Str_IDProducto)
        {
            string _Str_SQL = "SELECT cproducto FROM TPRODUCTOD WHERE cproducto='" + _Str_Producto + "' AND cidproductod='" + _P_Str_IDProducto + "' AND (CEXISREALU1>0 OR CEXISREALU2>0)";
            DataSet _DS_DataSet = new DataSet();
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_DS_DataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool _Mtd_SePuedeIniciarConteo()
        {
            string _Str_Cadena = "Select ccompany from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen ajustes de entrada por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "Select ccompany from TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen ajustes de salida por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT ccompany FROM TAJUSTEINTEGRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado='0' AND ISNULL(cfuseraprobador2,0)=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen ajustes integrados por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT ccompany FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=1 AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen facturas anuladas por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT ccompany FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=2 AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen facturas pendientes por anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            CLASES._Cls_Varios_Metodos _Cls_Varios = new T3.CLASES._Cls_Varios_Metodos(true);
            if (_Cls_Varios._Mtd_VerificarClaveUsuarioFirma(_Txt_Clave.Text, "F_CONTEOINVTARJ_INV"))
            {
                if (!_Mtd_SePuedeIniciarConteo())
                {
                    this.Close();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "";
                _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Select"].Value) == "1").ToList().ForEach(Fila =>
                {
                    if (_Mtd_ExistProducto(Convert.ToString(Fila.Cells["cproductom"].Value).Trim(), Convert.ToString(Fila.Cells["cidproductod"].Value).Trim()))
                    {
                        _Mtd_AgregarProducto(Fila.Cells["id_tarjetainv"].Value.ToString().Trim());
                    }
                    else
                    {
                        _Str_Cadena = "Update TINVFISICOD set cnousada='1' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + Convert.ToString(Fila.Cells["id_tarjetainv"].Value).Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
                );
                _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Select"].Value) != "1").ToList().ForEach(Fila =>
                {
                    _Str_Cadena = "Update TINVFISICOD set cnousada='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + Convert.ToString(Fila.Cells["id_tarjetainv"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                );
                _Str_Cadena = "Update TINVFISICOM set ciniciado='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                if (_Dg_Productos.RowCount > 0)
                {
                    _Pnl_Productos.Visible = true;
                }
                else
                {
                    Cursor = Cursors.Default;
                    Frm_ConteoInventario _Frm = new Frm_ConteoInventario();
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Pnl_Productos_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Productos.Visible)
            {
                Cursor = Cursors.Default;
                _Pnl_Clave.Visible = false;
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
            else
            {
                panel1.Enabled = true;
                panel2.Enabled = true;
            } 
        }

        private void _Bt_AceptarP_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_ConteoInventario _Frm = new Frm_ConteoInventario();
            Cursor = Cursors.Default;
            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            if (!_Frm.IsDisposed)
            {
                _Frm.Show();
            }
            this.Close();
        }
    }
}