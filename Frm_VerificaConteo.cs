using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_VerificaConteo : Form
    {
        Frm_ConteoInventario _Frm_Formulario;
        bool _Bol_Tercero = false;
        bool _Bol_ModificarConteo=false;
        string _Str_Id_Conteo = "";
        public Frm_VerificaConteo(bool _P_ModificarConteo, string _P_Str_IdConteo)
        {
            InitializeComponent();
            _Str_Id_Conteo = _P_Str_IdConteo;
            _Bol_ModificarConteo = _P_ModificarConteo;
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select cconteo3 from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "' AND cconteo3='1'"))
            {
                _Bol_Tercero = true;
            }
            else
            {
                _Bol_Tercero = false;
            }
            _Rbt_Diferencias.Checked = true;
            if (_Dg_Grid.Rows.Count == 0)
            {
                _Pnl_Panel.Enabled = true;
                _Bt_Finalizar.Enabled = true;
                _Bt_Impr_Tarjetas.Enabled = false;
                _Bt_Impr_Verificacion.Enabled = false;
            }
            else
            {
                _Bt_Finalizar.Enabled = false;
            }       
        }
        public Frm_VerificaConteo(bool _P_Bol_Diferencias, Frm_ConteoInventario _P_Frm_Formulario)
        {
            InitializeComponent();
            _Frm_Formulario = _P_Frm_Formulario;
            if (_P_Bol_Diferencias)
            {
                _Rbt_Diferencias.Checked = true;
                _Bt_Impr_Verificacion.Enabled = true;
                string _Str_Cadena = "Select cimplistver1y2,cimprimir3er from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1" & _Ds.Tables[0].Rows[0][1].ToString().Trim() == "0")
                    { _Bt_Impr_Tarjetas.Enabled = true; }
                }
            }
            else
            {
                _Rbt_SinDiferencias.Checked = true;
                _Rbt_Todo.Checked = false;
                _Rbt_Diferencias.Checked = false;
            }
        }
        public Frm_VerificaConteo(Frm_ConteoInventario _P_Frm_Formulario)
        {
            InitializeComponent();
            _Frm_Formulario = _P_Frm_Formulario;
            _Bol_Tercero = true;
             _Mtd_HabilitarBotonFinalizar();
        }
        private void _Mtd_HabilitarBotonFinalizar()
        {
            try
            {
                if (_Bol_Tercero)
                {
                    string _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,(Select top 1 c_nomb_abreviado from TPROVEEDOR where TPROVEEDOR.cproveedor=VST_INVENTARIOFISICO.cproveedor) as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cantcont3_u1 as [3er. Cajas],cantcont3_u2 as [3er. Unidades] from VST_INVENTARIOFISICO where (ccompany='" + Frm_Padre._Str_Comp + "' and Conteo1U1<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0) or ccompany='" + Frm_Padre._Str_Comp + "' and Conteo1U2<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0)) and (ccompany='" + Frm_Padre._Str_Comp + "' and Conteo2U1<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0) or ccompany='" + Frm_Padre._Str_Comp + "' and Conteo2U2<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0))";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        _Bt_Finalizar.Enabled = false;
                    }
                    else
                    {
                        _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,(Select top 1 c_nomb_abreviado from TPROVEEDOR where TPROVEEDOR.cproveedor=VST_INVENTARIOFISICO.cproveedor) as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cdiferencaj as [Dif. Cajas],cdiferenunid as [Dif. Unidades] from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and Conteo1U1=0 and Conteo1U2=0 and cnousada='0' or ccompany='" + Frm_Padre._Str_Comp + "' and Conteo2U1=0 and Conteo2U2=0 and cnousada='0'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        {
                            _Bt_Finalizar.Enabled = true;
                        }
                    }
                }
                else
                {
                    _Bt_Finalizar.Enabled = false;
                }
            }
            catch
            {
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
        int _Int_Sw = 0;
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private bool _Mtd_Verificar_Form()
        {
            foreach(Form _Frm in this.MdiParent.MdiChildren)
            {
                if (_Frm.Name == _Frm_Formulario.Name)
                {
                    return true;
                }
            }
            return false;
        }
        private bool _Mtd_VerificarCierre()
        {
            string _Str_Cadena = "SELECT * FROM TINVFISICOM WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Acceso()
        {
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {

                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    if (_Int_Sw == 1)
                    {
                        _Pnl_Clave.Visible = false;
                        bool _Bol_Listado = false;
                        if (MessageBox.Show("¿Desea imprimir las tarjetas como listado?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Bol_Listado = true;
                        }
                        Cursor = Cursors.WaitCursor;
                        PrintDialog _Print = new PrintDialog();
                        Cursor = Cursors.Default;
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            if (!_Bol_Listado)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rTarjetas3", "DetailSection1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and (cdiferencaj>0 or cdiferenunid>0) and cnousada='0'", _Print, true);
                                //_Frm_R.MdiParent = this.MdiParent;
                                //_Frm_R.Dock = DockStyle.Fill;
                                //_Frm_R.Show();
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rListadoVer2", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and (cdiferencaj>0 or cdiferenunid>0) and cnousada='0'", _Print, true);
                                //_Frm_R.MdiParent = this.MdiParent;
                                //_Frm_R.Dock = DockStyle.Fill;
                                //_Frm_R.Show();
                                Cursor = Cursors.Default;
                            }
                            if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Str_Cadena = "Update TINVFISICOM set cimprimir3er='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Bt_Impr_Tarjetas.Enabled = false;
                                if (MessageBox.Show("¿Desea iniciar el conteo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    if (_Mtd_Verificar_Form())
                                    {
                                        _Frm_Formulario.Activate();
                                        _Frm_Formulario._Mtd_Visibilizar_Panel3();
                                    }
                                    else
                                    {
                                        _Frm_Formulario = new Frm_ConteoInventario();
                                        _Frm_Formulario.MdiParent = this.MdiParent;
                                        _Frm_Formulario.Dock = DockStyle.Fill;
                                        _Frm_Formulario.Show();
                                    }
                                    _Frm_R.Close();
                                    this.Close();
                                }
                                else
                                {
                                    _Frm_Formulario.Close();
                                }
                            }
                        }
                    }
                    else if (_Int_Sw == 2)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        _Mtd_Finalizar();
                        this.Cursor = Cursors.Default;
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        private void Frm_VerificaConteo_Load(object sender, EventArgs e)
        {
            _Mtd_ConfigurarEventosText(_Txt_Cajas_1);
            _Mtd_ConfigurarEventosText(_Txt_Cajas_2);
            _Mtd_ConfigurarEventosText(_Txt_Cajas_3);
            _Mtd_ConfigurarEventosText(_Txt_Unid_1);
            _Mtd_ConfigurarEventosText(_Txt_Unid_2);
            _Mtd_ConfigurarEventosText(_Txt_Unid_3);
            _Mtd_Color_Estandar(this);
            this.Dock = DockStyle.Fill;
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            if (!_Bol_Tercero)
            {
                _Pnl_Conteo.Size = new Size(400, _Pnl_Conteo.Height);
                _Grb_Conteo3.Visible = false;
            }
            _Pnl_Conteo.Left = (this.Width / 2) - (_Pnl_Conteo.Width / 2);
            _Pnl_Conteo.Top = (this.Height / 2) - (_Pnl_Conteo.Height / 2);
            if (!_Bol_ModificarConteo)
            {
                _Rbt_Diferencias.Checked = true;
            }
            else
            {
                _Rbt_SinDiferencias.Checked = true;
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "";
            _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
            if (_Rbt_Todo.Checked)
            {
                if (_Bol_Tercero)
                { _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,cidproductod AS Lote,cprecioventamax AS PMV,c_nomb_abreviado as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cantcont3_u1 as [3er. Cajas],cantcont3_u2 as [3er. Unidades] from VST_INVENTARIOFISICO where VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' order by id_tarjetainv"; }
                else
                { _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,cidproductod AS Lote,cprecioventamax AS PMV,c_nomb_abreviado as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cdiferencaj as [Dif. Cajas],cdiferenunid as [Dif. Unidades] from VST_INVENTARIOFISICO where VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' order by id_tarjetainv"; }
            }
            else if (_Rbt_Diferencias.Checked)
            {
                if (_Bol_Tercero)
                { _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,cidproductod AS Lote,cprecioventamax AS PMV,c_nomb_abreviado as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cantcont3_u1 as [3er. Cajas],cantcont3_u2 as [3er. Unidades] from VST_INVENTARIOFISICO where (VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and Conteo1U1<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0) or VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and Conteo1U2<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0)) and (VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and Conteo2U1<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0) or VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and Conteo2U2<>0 and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0)) order by id_tarjetainv"; }
                else
                { _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,cidproductod AS Lote,cprecioventamax AS PMV,c_nomb_abreviado as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cdiferencaj as [Dif. Cajas],cdiferenunid as [Dif. Unidades] from VST_INVENTARIOFISICO where VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and (cdiferencaj>0 or cdiferenunid>0) and cnousada='0' order by id_tarjetainv"; }
            }
            else
            {
                if (_Bol_Tercero)
                { _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,cidproductod AS Lote,cprecioventamax AS PMV,c_nomb_abreviado as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cantcont3_u1 as [3er. Cajas],cantcont3_u2 as [3er. Unidades] from VST_INVENTARIOFISICO where VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and Conteo1U1=0 and Conteo1U2=0 and cnousada='0' or VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and Conteo2U1=0 and Conteo2U2=0 and cnousada='0' or VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and cdiferenunid=0 and cdiferencaj=0 and cnousada='0'  order by id_tarjetainv"; }
                else
                { _Str_Cadena = "Select id_tarjetainv as Tarjeta,cproducto as Producto,cnamefc as Descripción,cidproductod AS Lote,cprecioventamax AS PMV,c_nomb_abreviado as Proveedor,cantcont1_u1 as [1er. Cajas],cantcont1_u2 as [1er. Unidades],cantcont2_u1 as [2do. Cajas],cantcont2_u2 as [2do. Unidades],cdiferencaj as [Dif. Cajas],cdiferenunid as [Dif. Unidades] from VST_INVENTARIOFISICO where VST_INVENTARIOFISICO.ccompany='" + Frm_Padre._Str_Comp + "' and cdiferencaj=0 and cdiferenunid=0 and cnousada='0'  order by id_tarjetainv"; }
            }
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns["1er. Cajas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["1er. Unidades"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["2do. Cajas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["2do. Unidades"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["1er. Cajas"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            _Dg_Grid.Columns["1er. Unidades"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            _Dg_Grid.Columns["2do. Cajas"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            _Dg_Grid.Columns["2do. Unidades"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            _Dg_Grid.Columns[10].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            _Dg_Grid.Columns[11].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            _Dg_Grid.Columns["Lote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["PMV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void _Rbt_Todo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Todo.Checked)
            {
                _Mtd_Actualizar();
            }
        }

        private void _Rbt_Diferencias_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Diferencias.Checked)
            {
                _Mtd_Actualizar();
            }
        }

        private void _Rbt_SinDiferencias_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_SinDiferencias.Checked)
            {
                _Mtd_Actualizar();
            }
        }
        REPORTESS _Frm_R;
        private void _Bt_Impr_Verificacion_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                PrintDialog _Print = new PrintDialog();
                Cursor = Cursors.Default;
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rListadoVer", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and (cdiferencaj>0 or cdiferenunid>0) and cnousada='0'", _Print, true);
                    //_Frm_R.MdiParent = this.MdiParent;
                    //_Frm_R.Dock = DockStyle.Fill;
                    //_Frm_R.Show();
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //_Frm_R.Close();
                        string _Str_Cadena = "Update TINVFISICOM set cimplistver1y2='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Bt_Impr_Tarjetas.Enabled = true;
                        _Bt_Impr_Tarjetas.Focus();
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }

        private void _Bt_Impr_Tarjetas_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Text = "";
            _Txt_Clave.Focus();
            _Int_Sw = 1;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Dg_Grid.Enabled = false;
                _Pnl_Panel.Enabled = false;
            }
            else 
            {
                _Dg_Grid.Enabled = true;
                _Pnl_Panel.Enabled = true;
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarCierre())
            {
                _Mtd_Acceso();
            }
            else
            {
                MessageBox.Show("Se ha cerrado el inventario desde otra máquina", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void _Txt_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Mtd_VerificarCierre())
                {
                    _Mtd_Acceso();
                }
                else
                {
                    MessageBox.Show("Se ha cerrado el inventario desde otra máquina", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT id_conteohist FROM TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY id_conteohist  DESC";
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
        private void _Mtd_Crear_TINVFISICOTEOHIST(int _P_Int_id_conteohist)
        {
            string _Str_Cadena = "Select id_tarjetainv,cantcont1_u1,cantcont1_u2,ccontenidoma1,ccontenidoma2,cunidad2,cimpr_u2,cexisrealu1,cexisrealu2,ccostoneto_u1,ccostoneto_u2,cproducto,cantcont3_u1,cantcont3_u2,cconteo3 from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    bool _Bol_3erConteo = false;
                    if (_Row["cconteo3"].ToString() == "1")
                    {
                        _Bol_3erConteo = true;
                    }
                    else
                    {
                        _Bol_3erConteo = false;
                    }
                    string _Str_AjustEntr = "0";
                    string _Str_AjustSal = "0";
                    int _Int_Cajas1 = 0;
                    int _Int_Unidad1 = 0;
                    int _Int_Cajas2 = 0;
                    int _Int_Unidad2 = 0;
                    double _Dbl_DiferenciaEnUnidades = 0;
                    double _Dbl_Costo_Unidades = 0;
                    double _Dbl_Costo_Cajas = 0;
                    double _Dbl_Costo_Total = 0;
                    int _Int_UnidadesPorCaja = 0;
                    int _Int_TotalUnidadesPorProducto1 = 0;
                    int _Int_TotalUnidadesPorProducto2 = 0;
                    int _Int_TotalCajas = 0;
                    int _Int_TotalUnidades = 0;
                    if (_Bol_3erConteo)
                    {
                        if (_Row["cantcont3_u1"] != System.DBNull.Value)
                        { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont3_u1"].ToString()); }
                    }
                    else
                    {
                        if (_Row["cantcont1_u1"] != System.DBNull.Value)
                        { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont1_u1"].ToString()); }
                    }
                    if (_Bol_3erConteo)
                    {
                        if (_Row["cantcont3_u2"] != System.DBNull.Value)
                        { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont3_u2"].ToString()); }
                    }
                    else
                    {
                        if (_Row["cantcont1_u2"] != System.DBNull.Value)
                        { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont1_u2"].ToString()); }
                    }
                    if (_Row["cexisrealu1"] != System.DBNull.Value)
                    { _Int_Cajas2 = Convert.ToInt32(_Row["cexisrealu1"].ToString()); }
                    if (_Row["cexisrealu2"] != System.DBNull.Value)
                    { _Int_Unidad2 = Convert.ToInt32(_Row["cexisrealu2"].ToString()); }
                    if (_Row["ccontenidoma1"] != System.DBNull.Value)
                    { _Int_UnidadesPorCaja = Convert.ToInt32(_Row["ccontenidoma1"].ToString()); }
                    if (_Row["ccostoneto_u1"] != System.DBNull.Value)
                    { _Dbl_Costo_Cajas = Convert.ToDouble(_Row["ccostoneto_u1"].ToString()); }
                    if (_Row["cunidad2"] != System.DBNull.Value)
                    {
                        if (_Row["cunidad2"].ToString().TrimEnd() == "1")
                        {
                            if (_Row["ccontenidoma2"].ToString().TrimEnd() != "")
                            {
                                if (_Row["ccontenidoma2"].ToString().TrimEnd() != "0")
                                {
                                    if (Convert.ToInt32(_Row["ccontenidoma2"].ToString().TrimEnd()) > 0)
                                    {
                                        _Dbl_Costo_Unidades = _Dbl_Costo_Cajas / (Convert.ToInt32(_Row["ccontenidoma1"].ToString().TrimEnd()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString().TrimEnd()));
                                    }
                                }
                            }
                        }
                        else
                        {
                            _Dbl_Costo_Unidades = 0;
                        }
                    }
                    if (_Row["cimpr_u2"].ToString().Trim() == "1")
                    {
                        _Int_TotalUnidadesPorProducto1 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas1, _Int_Unidad1));
                        _Int_TotalUnidadesPorProducto2 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas2, _Int_Unidad2));
                        if (_Int_TotalUnidadesPorProducto2 > _Int_TotalUnidadesPorProducto1)
                        {
                            _Str_AjustSal = "1";
                            _Str_AjustEntr = "0";
                            _Dbl_DiferenciaEnUnidades = (-1) * Convert.ToDouble(_Int_TotalUnidadesPorProducto2 - _Int_TotalUnidadesPorProducto1);
                        }
                        else
                        {
                            _Str_AjustEntr = "1";
                            _Str_AjustSal = "0";
                            _Dbl_DiferenciaEnUnidades = Convert.ToDouble(_Int_TotalUnidadesPorProducto1 - _Int_TotalUnidadesPorProducto2);
                        }
                        if (_Dbl_Costo_Unidades > 0)
                        {
                            _Dbl_Costo_Total = _Dbl_DiferenciaEnUnidades * _Dbl_Costo_Unidades;
                        }
                        else
                        {
                            double _Dbl_DifCajas = 0;
                            _Dbl_DifCajas = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                            _Dbl_Costo_Total = _Dbl_DifCajas * _Dbl_Costo_Cajas;
                        }
                        if (_Dbl_DiferenciaEnUnidades < 0)
                        {
                            _Int_TotalCajas = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades * (-1)), 0));
                            _Int_TotalCajas = _Int_TotalCajas * (-1);
                        }
                        else
                        {
                            _Int_TotalCajas = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                        }
                        if (_Dbl_DiferenciaEnUnidades < 0)
                        {
                            _Int_TotalUnidades = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades * (-1))));
                            _Int_TotalUnidades = _Int_TotalUnidades * (-1);
                        }
                        else
                        {
                            _Int_TotalUnidades = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades)));
                        }
                        if (_Dbl_DiferenciaEnUnidades != 0)
                        {
                            _Str_Cadena = "Insert into TINVFISICOTEOHIST (ccompany,id_conteohist,id_tarjetainv,cconteocajas,cconteounid,ccajas,cunidad,ccostonetocaj,ccostonetounid,cdifrenciacajas,cdifrenciaunid,ccostoinvent,cnecajussal,cnecajusent,cajustado) values ('" + Frm_Padre._Str_Comp + "','" + _P_Int_id_conteohist.ToString() + "','" + _Row["id_tarjetainv"].ToString().Trim() + "','" + _Int_Cajas1.ToString() + "','" + _Int_Unidad1.ToString() + "','" + _Int_Cajas2.ToString() + "','" + _Int_Unidad2 + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Cajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Unidades) + "','" + _Int_TotalCajas.ToString() + "','" + _Int_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Total) + "','" + _Str_AjustSal + "','" + _Str_AjustEntr + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        if (_Int_Cajas2 > _Int_Cajas1)
                        {
                            _Str_AjustSal = "1";
                            _Int_TotalCajas = (-1) * (_Int_Cajas2 - _Int_Cajas1);
                        }
                        else
                        {
                            _Str_AjustEntr = "1";
                            _Int_TotalCajas = _Int_Cajas1 - _Int_Cajas2;
                        }
                        _Dbl_Costo_Total = _Int_TotalCajas * _Dbl_Costo_Cajas;
                        if (_Int_TotalCajas != 0)
                        {
                            _Str_Cadena = "Insert into TINVFISICOTEOHIST (ccompany,id_conteohist,id_tarjetainv,cconteocajas,cconteounid,ccajas,cunidad,ccostonetocaj,ccostonetounid,cdifrenciacajas,cdifrenciaunid,ccostoinvent,cnecajussal,cnecajusent,cajustado) values ('" + Frm_Padre._Str_Comp + "','" + _P_Int_id_conteohist.ToString() + "','" + _Row["id_tarjetainv"].ToString().Trim() + "','" + _Int_Cajas1.ToString() + "','" + _Int_Unidad1.ToString() + "','" + _Int_Cajas2.ToString() + "','" + _Int_Unidad2 + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Cajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Unidades) + "','" + _Int_TotalCajas.ToString() + "','" + _Int_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Total) + "','" + _Str_AjustSal + "','" + _Str_AjustEntr + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
            }
        }
        private void _Mtd_Ajustar(string _Str_HistoricoAjuste)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int _Int_ConteoHist = Convert.ToInt32(_Str_HistoricoAjuste);
                SqlParameter[] _Sql_Parametros = new SqlParameter[2];
                _Sql_Parametros[0] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _Sql_Parametros[0].Value = Frm_Padre._Str_Comp;
                _Sql_Parametros[1] = new SqlParameter("@id_conteohist", SqlDbType.Real);
                _Sql_Parametros[1].Value = _Int_ConteoHist;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_AJUSTEPORCONTEOHISTORICO", _Sql_Parametros);
                string _Str_SentenciaSQL = "update TINVFISICOHISTM set cfinalizado='3' where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Str_HistoricoAjuste + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                string _Str_Cadena = "Delete from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Delete from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                if (this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                MessageBox.Show("El inventario se ha cerrado correctamente ya que no existe diferencias entre el físico y el teórico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_Frm_Formulario != null)
                {
                    _Frm_Formulario.Close();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hubo un error de tipo " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool _Mtd_ProcesoFinalizado(DateTime _P_Dtm_Date)
        {
            string _Str_Cadena = "SELECT id_conteohist FROM TINVFISICOHISTM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(VARCHAR,cdate,103)=CONVERT(VARCHAR,'" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_P_Dtm_Date) + "',103) AND cfinalizado<>'3'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Finalizar()
        {
            int _Int_Numero =0;
            if (_Bol_ModificarConteo)
            {
                string _Str_Cadena1 = "delete from TINVFISICOHISTM where id_conteohist='" + _Str_Id_Conteo + "' and ccompany='"+Frm_Padre._Str_Comp+"'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1);
                _Str_Cadena1 = "delete from TINVFISICOHISTD where id_conteohist='" + _Str_Id_Conteo + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1);
               _Str_Cadena1 = "delete from TINVFISICOTEOHIST where id_conteohist='" + _Str_Id_Conteo + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena1);
                _Int_Numero = Convert.ToInt32(_Str_Id_Conteo);
            }
            else
            {
                _Int_Numero = _Mtd_Entrada();
            }            
            string _Str_Cadena = "Select cdate from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";

            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                DataRow _Rows = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                if (_Mtd_ProcesoFinalizado(Convert.ToDateTime(_Rows[0].ToString().Trim())))
                {
                    MessageBox.Show("El proceso ha sido finalizado desde otra máquina", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.MdiParent != null)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    }
                    if (_Frm_Formulario != null)
                    {
                        _Frm_Formulario.Close();
                    }
                    this.Close();
                }
                else
                {
                    _Str_Cadena = "insert into TINVFISICOHISTM (ccompany,id_conteohist,cdate,cfinalizado) values ('" + Frm_Padre._Str_Comp + "','" + _Int_Numero + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Rows[0].ToString())) + "','1')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TINVFISICOHISTD(ccompany,id_conteohist,id_tarjetainv,cproveedor,csubgrupo,cgrupo,csku,cproducto,cdate,cyearacco,cmontacco,cimpr_u2,cantcont1_u1,cantcont1_u2,cconteo1,cantcont2_u1,cantcont2_u2,cconteo2,cdiferencaj,cdiferenunid,cantcont3_u1,cantcont3_u2,cconteo3,cidproductod) Select '" + Frm_Padre._Str_Comp + "','" + _Int_Numero.ToString() + "',id_tarjetainv,cproveedor,csubgrupo,cgrupo,csku,cproducto,cdate,cyearacco,cmontacco,cimpr_u2,cantcont1_u1,cantcont1_u2,cconteo1,cantcont2_u1,cantcont2_u2,cconteo2,cdiferencaj,cdiferenunid,cantcont3_u1,cantcont3_u2,cconteo3,cidproductod from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //-------------------------------------------------------------------------
                    _Mtd_Crear_TINVFISICOTEOHIST(_Int_Numero);
                    //-------------------------------------------------------------------------
                    _Pnl_Clave.Visible = false;
                    _Str_Cadena = "SELECT ccompany FROM VST_INVENTARIOFISICOREPORTE WHERE ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("¿Desea imprimir el reporte comparativo?", "Infomación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            PrintDialog _Print = new PrintDialog();
                            if (_Print.ShowDialog() == DialogResult.OK)
                            {
                                REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICOREPORTE" }, "", "T3.Report.rComparativo", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'", _Print, true);
                                //_Frm_R.MdiParent = this.MdiParent;
                                //_Frm_R.Dock = DockStyle.Fill;
                                //_Frm_R.Show();
                            }
                        }
                        if (this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                        //this.Close();
                        if (_Frm_Formulario != null)
                        {
                            _Frm_Formulario.Close();
                        }
                        this.Close();
                    }
                    else
                    {
                        _Mtd_Ajustar(_Int_Numero.ToString());
                    }
                }
            }
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_GuardarDatos(int _P_Int_Conteo, string _P_Str_Tarjeta, TextBox _P_Txt_Cajas, TextBox _P_Txt_Unidades)
        {
            string _Str_Cadena = "";
            //---------------------
            if (_P_Txt_Cajas.Text.Trim().Length == 0)
            { _P_Txt_Cajas.Text = "0"; }
            if (_P_Txt_Unidades.Text.Trim().Length == 0)
            { _P_Txt_Unidades.Text = "0"; }
            //---------------------
            if (_Bol_ModificarConteo | _Bol_Tercero)
            {
                if (_P_Int_Conteo == 1)
                {
                    _Str_Cadena = "Update TINVFISICOD set cantcont1_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont1_u2='" + _P_Txt_Unidades.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value = _P_Txt_Cajas.Text;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value = _P_Txt_Unidades.Text;

                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Style.BackColor = Color.White;
                }
                else if (_P_Int_Conteo == 2)
                {
                    _Str_Cadena = "Update TINVFISICOD set cantcont2_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont2_u2='" + _P_Txt_Unidades.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value = _P_Txt_Cajas.Text;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value = _P_Txt_Unidades.Text;

                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Style.BackColor = Color.White;
                }
                else
                {
                    _Str_Cadena = "Update TINVFISICOD set cantcont3_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont3_u2='" + _P_Txt_Unidades.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value = _P_Txt_Cajas.Text;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value = _P_Txt_Unidades.Text;

                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Style.BackColor = Color.White;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Style.BackColor = Color.White;
                }
                if (_Bol_ModificarConteo)
                {
                    _Str_Cadena = "update TINVFISICOHISTM set cfinalizado='2' where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Str_Id_Conteo + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                bool _Bol_Cuadrado = false;
                if (_Bol_Tercero)
                {
                    _Bol_Cuadrado = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim() || _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim();
                }
                else
                {
                    _Bol_Cuadrado = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim();
                }
                if (_Bol_Cuadrado)
                {
                    _Str_Cadena = "Update TINVFISICOD set cdiferencaj='0',cdiferenunid='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    Cursor = Cursors.WaitCursor;
                    _Mtd_DesMarcar_Marcar();
                    if (_Dg_Grid.Rows.Count == 0)
                    {
                        _Pnl_Conteo.Visible = false;
                        MessageBox.Show("El conteo ha cuadrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_Frm_Formulario != null)
                        { _Frm_Formulario.Close(); }
                        _Grb_1.Enabled = false;
                        _Pnl_Panel.Enabled = true;
                        _Bt_Finalizar.Enabled = true;
                        _Bt_Impr_Tarjetas.Enabled = false;
                        _Bt_Impr_Verificacion.Enabled = false;
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    _Str_Cadena = "Update TINVFISICOD set cdiferencaj='1',cdiferenunid='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_DesMarcar_Marcar();
                }
            }
            else
            {
                if (_P_Int_Conteo == 1)
                {
                    _Str_Cadena = "Update TINVFISICOD set cantcont1_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont1_u2='" + _P_Txt_Unidades.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value = _P_Txt_Cajas.Text;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value = _P_Txt_Unidades.Text;
                }
                else if (_P_Int_Conteo == 2)
                {
                    _Str_Cadena = "Update TINVFISICOD set cantcont2_u1='" + _P_Txt_Cajas.Text.Trim() + "',cantcont2_u2='" + _P_Txt_Unidades.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value = _P_Txt_Cajas.Text;
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value = _P_Txt_Unidades.Text;
                }
                if (_Mtd_Diferencias())
                {
                    _Mtd_DesMarcar_Marcar();
                    _Bt_Impr_Verificacion.Enabled = true;
                    _Str_Cadena = "Select cimplistver1y2,cimprimir3er from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1" & _Ds.Tables[0].Rows[0][1].ToString().Trim() == "0")
                        { _Bt_Impr_Tarjetas.Enabled = true; }
                    }
                }
                else
                {
                    _Pnl_Conteo.Visible = false;
                    MessageBox.Show("El conteo ha cuadrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Frm_Formulario != null)
                    { _Frm_Formulario.Close(); }
                    Frm_ConteoInventario _Frm = new Frm_ConteoInventario();
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                    this.Close();
                }
            }
            _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and (cdiferencaj>0 or cdiferenunid>0) and cnousada='0'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
            { _Bt_Impr_Verificacion.Enabled = false; _Bt_Impr_Tarjetas.Enabled = false; }
        }
        int _Int_Cajas = 0;
        int _Int_Unidades = 0;
        private void _Mtd_Extraer_Cajas_Unidades(int _P_Int_Cantidad, int _P_Int_Unidad)
        {
            int _Int_Contador = 0;
            _Int_Cajas = 0;
            _Int_Unidades = 0;
            for (int _Int_I = 1; _Int_I <= _P_Int_Cantidad; _Int_I++)
            {
                _Int_Contador++;
                if (_Int_Contador == _P_Int_Unidad)
                {
                    _Int_Cajas++;
                    _Int_Contador = 0;
                    if (_Int_I + _P_Int_Unidad > _P_Int_Cantidad)
                    {
                        _Int_Unidades = _P_Int_Cantidad - _Int_I;
                    }
                }
            }
        }
        private bool _Mtd_Diferencias()
        {
            bool _Bol_Diferencias = false;
            string _Str_Cadena = "Select id_tarjetainv,cantcont1_u1,cantcont1_u2,cantcont2_u1,cantcont2_u2,ccontenidoma1,cimpr_u2,cproducto from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    int _Int_Cajas1 = 0;
                    int _Int_Cajas2 = 0;
                    int _Int_Unidad1 = 0;
                    int _Int_Unidad2 = 0;
                    int _Int_UnidadesPorCaja = 0;
                    int _Int_CajasDif = 0;
                    int _Int_UndDif = 0;
                    int _Int_TotalCajas = 0;
                    int _Int_TotalUnidades = 0;
                    if (_Row["cantcont1_u1"] != System.DBNull.Value)
                    { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont1_u1"].ToString()); }
                    if (_Row["cantcont1_u2"] != System.DBNull.Value)
                    { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont1_u2"].ToString()); }
                    if (_Row["cantcont2_u1"] != System.DBNull.Value)
                    { _Int_Cajas2 = Convert.ToInt32(_Row["cantcont2_u1"].ToString()); }
                    if (_Row["cantcont2_u2"] != System.DBNull.Value)
                    { _Int_Unidad2 = Convert.ToInt32(_Row["cantcont2_u2"].ToString()); }
                    if (_Row["ccontenidoma1"] != System.DBNull.Value)
                    { _Int_UnidadesPorCaja = Convert.ToInt32(_Row["ccontenidoma1"].ToString()); }
                    if (_Row["cimpr_u2"].ToString().Trim() == "1")
                    {
                        if (_Int_Cajas1 > _Int_Cajas2)
                        {
                            _Int_CajasDif = _Int_Cajas1 - _Int_Cajas2;
                        }
                        else
                        {
                            _Int_CajasDif = _Int_Cajas2 - _Int_Cajas1;
                        }
                        if (_Int_Unidad1 > _Int_Unidad2)
                        {
                            _Int_UndDif = _Int_Unidad1 - _Int_Unidad2;
                        }
                        else
                        {
                            _Int_UndDif = _Int_Unidad2 - _Int_Unidad1;
                        }
                        _Int_TotalCajas = _Int_CajasDif; 
                        _Int_TotalUnidades = _Int_UndDif;
                        if (_Int_CajasDif > 0 || _Int_UndDif > 0)
                        {
                            _Bol_Diferencias = true;                                                                                //_Int_TotalUnidades
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='" + _Int_TotalCajas.ToString() + "',cdiferenunid='" + _Int_TotalUnidades.ToString() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='0',cdiferenunid='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        if (_Int_Cajas1 > _Int_Cajas2)
                        { _Int_TotalCajas = _Int_Cajas1 - _Int_Cajas2; }
                        else if (_Int_Cajas1 < _Int_Cajas2)
                        { _Int_TotalCajas = _Int_Cajas2 - _Int_Cajas1; }
                        if (_Int_TotalCajas > 0)
                        {
                            _Bol_Diferencias = true;
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='" + _Int_TotalCajas.ToString() + "',cdiferenunid='" + _Int_TotalUnidades.ToString() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='0',cdiferenunid='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
                _Pnl_Clave.Visible = false;
            }
            return _Bol_Diferencias;
        }
        private void _Mtd_IgualarCajas()
        {
            if (_Dg_Grid.RowCount > 0 & _Dg_Grid.CurrentCell != null)
            {
                _Txt_Tarjeta.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Tarjeta.Tag = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Cajas_1.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString();
                _Txt_Unid_1.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString();
                _Txt_Cajas_2.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString();
                _Txt_Unid_2.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString();
                _Txt_Cajas_3.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString();
                _Txt_Unid_3.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString();
            }
        }
        private bool _Mtd_AceptaUnidades(string _P_Str_Tarjeta)
        {
            string _Str_Cadena = "Select cimpr_u2 from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Tarjeta + "' AND cimpr_u2='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_DesMarcar_Marcar()
        {
            if (_Rbt_Todo.Checked)
            { _Rbt_Todo.Checked = false; _Rbt_Todo.Checked = true; }
            else if(_Rbt_Diferencias.Checked)
            { _Rbt_Diferencias.Checked = false; _Rbt_Diferencias.Checked = true; }
            else if (_Rbt_SinDiferencias.Checked)
            { _Rbt_SinDiferencias.Checked = false; _Rbt_SinDiferencias.Checked = true; }
        }
        private void _Mtd_Inhabilitar()
        {
            _Txt_Cajas_1.Enabled = false;
            _Txt_Cajas_2.Enabled = false;
            _Txt_Cajas_3.Enabled = false;
            _Txt_Unid_1.Enabled = false;
            _Txt_Unid_2.Enabled = false;
            _Txt_Unid_3.Enabled = false;
        }
        //------------------------
        private void _Mtd_ConfigurarEventosText(TextBox _P_Txt_Texbox)
        {
            _P_Txt_Texbox.MaxLength = 18;
            _P_Txt_Texbox.TextChanged += new EventHandler(_P_Txt_Texbox_TextChanged);
            _P_Txt_Texbox.KeyPress += new KeyPressEventHandler(_P_Txt_Texbox_KeyPress);
        }

        void _P_Txt_Texbox_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "";
            }
            else
            {
                int _Int_Temp = 0;
                if (!int.TryParse(((TextBox)sender).Text, out _Int_Temp) || _Int_Temp < 0)
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void _P_Txt_Texbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    ((TextBox)sender).Enabled = false;
                    if (((TextBox)sender).Name.IndexOf("_Txt_Cajas") != -1)
                    {
                        if (((TextBox)sender).Text.Trim().Length == 0)
                        { ((TextBox)sender).Text = "0"; }
                        if (_Mtd_AceptaUnidades(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()))
                        {
                            if (((TextBox)sender).Name.Trim() == "_Txt_Cajas_1")
                            { _Txt_Unid_1.Enabled = true; _Txt_Unid_1.Focus(); }
                            else if (((TextBox)sender).Name.Trim() == "_Txt_Cajas_2")
                            { _Txt_Unid_2.Enabled = true; _Txt_Unid_2.Focus(); }
                            else if (((TextBox)sender).Name.Trim() == "_Txt_Cajas_3")
                            { _Txt_Unid_3.Enabled = true; _Txt_Unid_3.Focus(); }
                        }
                        else
                        {
                            if (((TextBox)sender).Name.Trim() == "_Txt_Cajas_1")
                            { _Bt_Aceptar_1.Focus(); }
                            else if (((TextBox)sender).Name.Trim() == "_Txt_Cajas_2")
                            { _Bt_Aceptar_2.Focus(); }
                            else if (((TextBox)sender).Name.Trim() == "_Txt_Cajas_3")
                            { _Bt_Aceptar_3.Focus(); }
                        }
                    }
                    else
                    {
                        if (((TextBox)sender).Text.Trim().Length == 0)
                        { ((TextBox)sender).Text = "0"; }
                        int _Int_Dbunidades = Convert.ToInt32(_MyUtilidad._Mtd_ProductoUndManejo2(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString()));
                        int _Int_Undidades = Convert.ToInt32(((TextBox)sender).Text);
                        if (_Int_Undidades >= _Int_Dbunidades)
                        {
                            MessageBox.Show("La cantidad de unidades debe ser inferior a " + _Int_Dbunidades.ToString() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ((TextBox)sender).Text = "0";
                            ((TextBox)sender).Enabled = true;
                        }
                        else
                        {
                            if (((TextBox)sender).Name.Trim() == "_Txt_Unid_1")
                            { _Bt_Aceptar_1.Focus(); }
                            else if (((TextBox)sender).Name.Trim() == "_Txt_Unid_2")
                            { _Bt_Aceptar_2.Focus(); }
                            else if (((TextBox)sender).Name.Trim() == "_Txt_Unid_3")
                            {  _Bt_Aceptar_3.Focus(); }
                        }
                    }
                }
            }
        }
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        private int _Int_Preparar_Cmb()
        {
            if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim())
            {
                return 1;
            }
            else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim())
            {
                return 2;
            }
            else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim())
            {
                return 3;
            }
            else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Cajas"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Cajas"].Value.ToString().Trim())
            {
                return 4;
            }
            //--------------------------------------------------------------------
            if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim())
            {
                return 1;
            }
            else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim())
            {
                return 2;
            }
            else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() == _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim())
            {
                return 3;
            }
            else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["1er. Unidades"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim() & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["2do. Unidades"].Value.ToString().Trim() != _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value.ToString().Trim())
            {
                return 4;
            }
            return 3;
        }

        private void _Bt_Finalizar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Text = "";
            _Txt_Clave.Focus();
            _Int_Sw = 2;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string _Str_Tarjeta = InputBox.Show("Introduzca el número de tarjeta").Text;
                if (_Str_Tarjeta.Trim().Length > 0)
                {
                    _Mtd_CurrentIndex(_Str_Tarjeta);
                }
            }
            catch
            {
            }
        }
        private void _Mtd_CurrentIndex(string _P_Str_Tarjeta)
        {
            DataGridViewCell _Dg_Cell;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() == _P_Str_Tarjeta.Trim())
                {
                    _Dg_Cell = _Dg_Row.Cells[0];
                    _Dg_Grid.CurrentCell = _Dg_Cell;
                    break;
                }
            }
        }

        private void _Bt_Aceptar_Cont_Click(object sender, EventArgs e)
        {
            
        }

        private void _Pnl_Conteo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Conteo.Visible)
            {
                _Dg_Grid.Enabled = false;
                _Pnl_Panel.Enabled = false;
                _Mtd_Inhabilitar();
            }
            else
            {
                _Dg_Grid.Enabled = true;
                _Pnl_Panel.Enabled = true;
            }
        }

        private void _Bt_Editar_1_Click(object sender, EventArgs e)
        {
            _Mtd_Inhabilitar();
            _Mtd_IgualarCajas();
            _Txt_Cajas_1.Enabled = true;
            _Txt_Cajas_1.Focus();
            _Txt_Cajas_1.Select(0, _Txt_Cajas_1.Text.Length);
        }

        private void _Bt_Editar_2_Click(object sender, EventArgs e)
        {
            _Mtd_Inhabilitar();
            _Mtd_IgualarCajas();
            _Txt_Cajas_2.Enabled = true;
            _Txt_Cajas_2.Focus();
            _Txt_Cajas_2.Select(0, _Txt_Cajas_2.Text.Length);
        }

        private void _Bt_Editar_3_Click(object sender, EventArgs e)
        {
            _Mtd_Inhabilitar();
            _Mtd_IgualarCajas();
            _Txt_Cajas_3.Enabled = true;
            _Txt_Cajas_3.Focus();
            _Txt_Cajas_3.Select(0, _Txt_Cajas_3.Text.Length);
        }

        private void _Bt_Cancelar_1_Click(object sender, EventArgs e)
        {
            _Mtd_IgualarCajas();
            _Txt_Cajas_1.Enabled = false;
            _Txt_Unid_1.Enabled = false;
        }

        private void _Bt_Cancelar_2_Click(object sender, EventArgs e)
        {
            _Mtd_IgualarCajas();
            _Txt_Cajas_2.Enabled = false;
            _Txt_Unid_2.Enabled = false;
        }

        private void _Bt_Cancelar_3_Click(object sender, EventArgs e)
        {
            _Mtd_IgualarCajas();
            _Txt_Cajas_3.Enabled = false;
            _Txt_Unid_3.Enabled = false;
        }

        private void _Bt_Aceptar_1_Click(object sender, EventArgs e)
        {
            int _Int_RowCount = _Dg_Grid.RowCount;
            _Mtd_GuardarDatos(1, _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Txt_Cajas_1, _Txt_Unid_1);
            _Mtd_Inhabilitar();
            _Mtd_IgualarCajas();
            if (_Dg_Grid.RowCount != _Int_RowCount)
            { _Txt_Tarjeta.Focus(); _Txt_Tarjeta.Select(0, _Txt_Tarjeta.Text.Length); }
            else
            { _Bt_Editar_2.Focus(); }
        }

        private void _Bt_Aceptar_2_Click(object sender, EventArgs e)
        {
            int _Int_RowCount = _Dg_Grid.RowCount;
            _Mtd_GuardarDatos(2, _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Txt_Cajas_2, _Txt_Unid_2);
            _Mtd_Inhabilitar();
            _Mtd_IgualarCajas();
            if (_Grb_Conteo3.Visible)
            {
                if (_Dg_Grid.RowCount != _Int_RowCount)
                { _Txt_Tarjeta.Focus(); _Txt_Tarjeta.Select(0, _Txt_Tarjeta.Text.Length); }
                else
                { _Bt_Editar_3.Focus(); }
            }
            else
            {
                _Txt_Tarjeta.Focus();
                _Txt_Tarjeta.Select(0, _Txt_Tarjeta.Text.Length);
            }
            
        }

        private void _Bt_Aceptar_3_Click(object sender, EventArgs e)
        {
            int _Int_RowCount = _Dg_Grid.RowCount;
            _Mtd_GuardarDatos(3, _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Txt_Cajas_3, _Txt_Unid_3);
            _Mtd_Inhabilitar();
            _Mtd_IgualarCajas();
            _Txt_Tarjeta.Focus();
            _Txt_Tarjeta.Select(0, _Txt_Tarjeta.Text.Length);
        }

        private void ajustarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Mtd_IgualarCajas();
            _Pnl_Conteo.Visible = true;
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Conteo.Visible = false;
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
                    _Bt_Tarjeta.Focus();
                    _Bt_Tarjeta.PerformClick();
                }
            }
        }
        private bool _Mtd_ExistenciaTarjeta(string _P_Str_Tarjeta)
        {
            string _Str_Cadena = "Select id_tarjetainv FROM VST_INVENTARIOFISICO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND id_tarjetainv='" + _P_Str_Tarjeta + "' AND cnousada='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Tarjeta_Click(object sender, EventArgs e)
        {
            if (_Txt_Tarjeta.Text.Trim().Length > 0)
            {
                if (_Mtd_ExistenciaTarjeta(_Txt_Tarjeta.Text))
                {
                    _Txt_Tarjeta.Tag = _Txt_Tarjeta.Text;
                    _Mtd_CurrentIndex(_Txt_Tarjeta.Text);
                    _Mtd_IgualarCajas();
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Selected = true;
                    _Bt_Editar_1.Focus();
                }
                else
                { MessageBox.Show("Tarjeta inválida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Txt_Tarjeta.Text = Convert.ToString(_Txt_Tarjeta.Tag); _Txt_Tarjeta.Focus(); }
            }
            else
            { _Txt_Tarjeta.Text = Convert.ToString(_Txt_Tarjeta.Tag); }
        }

        private void _Txt_Tarjeta_MouseUp(object sender, MouseEventArgs e)
        {
            _Txt_Tarjeta.Select(0, _Txt_Tarjeta.Text.Length);
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count != 1;
        }
    }
}
