using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_TransferMME : Form
    {
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_Tabs = false;
        string _Str_MyProceso = "";
        public Frm_TransferMME()
        {
            InitializeComponent();
            _Mtd_Actualizar();
            _Bt_Procesar.Enabled = false;
        }
        public Frm_TransferMME(bool _P_Bol_Tabs)
        {
            InitializeComponent();
            _Mtd_Actualizar_Tabs();
            _Bol_Tabs = true;
            _Bt_Procesar.Enabled = true;
            _Rbt_Pro.Visible = false;
            _Rbt_NoPro.Visible = false;

        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ctransferenciamme";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "";
            if (_Rbt_Pro.Checked)
            { _Str_Cadena = "Select ctransferenciamme as Código, CONVERT(char(10),cfecha,103) AS Fecha,cdescripcion as Descripción, (Select dbo.Fnc_Formatear(SUM(ccosttot_u1+ccosttot_u2)) from TTRANSFERAMMED where TTRANSFERAMMED.ctransferenciamme=TTRANSFERAMMEC.ctransferenciamme) as Monto,calmacensalida,calmacenentrada,cidmotivo from TTRANSFERAMMEC where ccompany='" + Frm_Padre._Str_Comp + "' and cautorizatransf='1'"; }
            else
            { _Str_Cadena = "Select ctransferenciamme as Código, CONVERT(char(10),cfecha,103) AS Fecha,cdescripcion as Descripción, (Select dbo.Fnc_Formatear(SUM(ccosttot_u1+ccosttot_u2)) from TTRANSFERAMMED where TTRANSFERAMMED.ctransferenciamme=TTRANSFERAMMEC.ctransferenciamme) as Monto,calmacensalida,calmacenentrada,cidmotivo from TTRANSFERAMMEC where ccompany='" + Frm_Padre._Str_Comp + "' and cautorizatransf='0'"; }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar_Tabs()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ctransferenciamme";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select ctransferenciamme as Código, CONVERT(char(10),cfecha,103) AS Fecha,cdescripcion as Descripción, (Select dbo.Fnc_Formatear(SUM(ccosttot_u1+ccosttot_u2)) from TTRANSFERAMMED where TTRANSFERAMMED.ctransferenciamme=TTRANSFERAMMEC.ctransferenciamme) as Monto,calmacensalida,calmacenentrada,cidmotivo from TTRANSFERAMMEC where ccompany='" + Frm_Padre._Str_Comp + "' and cautorizatransf='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Transferencias", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.Rows.Count == 0)
            {
                this.Close();
            }
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT ctransferenciamme FROM TTRANSFERAMMEC where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY ctransferenciamme  DESC";
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
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Txt_Numero.Text = "";
            //_Txt_Impuesto.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Costo.Text = "";
            _Dg_Grid2.Rows.Clear();
            _Mtd_Cargar_Motivo();
            //_Mtd_Cargar_Proveedor();
            _Mtd_Cargar_Cmb_Entrada();
            _Mtd_Cargar_Cmb_Salida();
            _Mtd_Habilitar();
            _Txt_Numero.Enabled = true;
            _Str_MyProceso = "";
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Numero.Enabled = false;
            _Txt_Descripcion.Enabled = true;
            _Cmb_Motivo.Enabled = true;
            //_Cmb_Proveedor.Enabled = true;
            //_Cmb_Entrada.Enabled = true;
            //_Cmb_Salida.Enabled = true;
            _Str_MyProceso = "M";
            _Dg_Grid2.ReadOnly = false;
            _Dg_Grid2.Columns[2].ReadOnly = true;
            _Dg_Grid2.Rows.Add();
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Numero.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Cmb_Entrada.Enabled = false;
            _Cmb_Salida.Enabled = false;
            //_Cmb_Proveedor.Enabled = false;
            _Dg_Grid2.ReadOnly = true;
        }
        public void _Mtd_Nuevo()
        {
            _Bol_Error = true;
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Fecha.Text = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            string _Str_Cadena = "Select calmacenpre,calmacenmme from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Cmb_Salida.SelectedValue = _Ds.Tables[0].Rows[0][0].ToString();
                _Cmb_Entrada.SelectedValue = _Ds.Tables[0].Rows[0][1].ToString();
            }
            _Cmb_Entrada.Enabled = true;
            _Cmb_Salida.Enabled = true;
            //_Cmb_Proveedor.Focus();
            _Cmb_Motivo.Focus();
            _Str_MyProceso = "N";
        }
        private bool _Mtd_Verificar_Grid()
        {
            _Dg_Grid2.EndEdit();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null | _Dg_Row.Cells[4].Value != null))
                {
                    return true;
                }
            }
            return false;
        }
        //private void _Mtd_Cargar_Proveedor()
        //{
        //    _Cmb_Proveedor.DataSource = null;
        //    DataSet _Ds;
        //    string _Str_Cadena = "SELECT cproveedor,c_nomb_comer FROM TPROVEEDOR WHERE cdelete='0' and cglobal='1' order by c_nomb_comer";
        //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        //    _Cmb_Proveedor.DataSource = _Ds.Tables[0];
        //    _Cmb_Proveedor.DisplayMember = "c_nomb_comer";
        //    _Cmb_Proveedor.ValueMember = "cproveedor";
        //    _Cmb_Proveedor.SelectedIndex = -1;
        //}
        private void _Mtd_Cargar_Cmb_Salida()
        {
            _Cmb_Salida.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select calmacen,cname from TALMACEN where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Cmb_Salida.DataSource = _Ds.Tables[0];
            _Cmb_Salida.DisplayMember = "cname";
            _Cmb_Salida.ValueMember = "calmacen";
            _Cmb_Salida.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Cmb_Entrada()
        {
            _Cmb_Entrada.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select calmacen,cname from TALMACEN where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Cmb_Entrada.DataSource = _Ds.Tables[0];
            _Cmb_Entrada.DisplayMember = "cname";
            _Cmb_Entrada.ValueMember = "calmacen";
            _Cmb_Entrada.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Motivo()
        {
            _Cmb_Motivo.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT TMOTIVO.cidmotivo,TMOTIVO.cconcepto FROM TMOTIVO where ctransmme='1' ORDER BY TMOTIVO.cconcepto ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Motivo.DataSource = _Ds.Tables[0];
            _Cmb_Motivo.DisplayMember = "cconcepto";
            _Cmb_Motivo.ValueMember = "cidmotivo";
            _Cmb_Motivo.SelectedIndex = -1;
        }
        private string _Mtd_Imp_Selec()
        {
            string _Str_Cadena = " and (";
            bool _Bol_String = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    _Str_Cadena = _Str_Cadena + "cproducto!='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' and ";
                    _Bol_String = true;
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 4);
            if (_Bol_String)
            {
                return _Str_Cadena + ")";
            }
            else
            {
                return "";
            }
        }
        private void _Mtd_Met_Realizar_Calculo()
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            int _Int_CantManejo1 = 0, _Int_CantManejo2=0;
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Cajas = 0;
                double _Dbl_Unidades = 0;
                double _Dbl_ccostobruto_u1 = 0;
                double _Dbl_ccostobruto_u2 = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null | _Dg_Row.Cells[4].Value != null))
                {
                    _Str_Cadena = "Select cproveedor,cgrupo,csku,csubgrupo,ccostoneto_u1,ccostobruto_u1,ccostoneto_u2,ccostobruto_u2,cunidadma1,ccontenidoma1,cunidadma2,ccontenidoma2 from TPRODUCTO where cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u1"].ToString()); }
                        else { _Dbl_ccostobruto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u2"].ToString()); }
                        else { _Dbl_ccostobruto_u2 = 0; }
                        if (_Dg_Row.Cells[3].Value != null)
                        { _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[3].Value.ToString()); }
                        else
                        { _Dbl_Cajas = 0; }
                        if (_Dg_Row.Cells[4].Value != null)
                        { _Dbl_Unidades = Convert.ToDouble(_Dg_Row.Cells[4].Value.ToString()); }
                        else
                        { _Dbl_Unidades = 0; }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidadma1"]).Length > 0)
                        {
                            _Int_CantManejo1 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                        }
                        else
                        {
                            _Int_CantManejo1 = 0;
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidadma2"]).Length > 0)
                        {
                            _Int_CantManejo2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                        }
                        else
                        {
                            _Int_CantManejo2 = 0;
                        }
                        _Dbl_CostoCajas = _Dbl_Cajas * _Dbl_ccostobruto_u1;
                        if (_Int_CantManejo2 > 0)
                        {
                            _Dbl_CostoUnidades = _Dbl_Unidades * (_Dbl_ccostobruto_u1 / (_Int_CantManejo1 / _Int_CantManejo2));
                        }
                        else
                        {
                            _Dbl_CostoUnidades = 0;
                        }
                        _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value.ToString().Trim() + "')";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            { _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); }
                            else { _Dbl_Impuesto = 0; }
                        }
                        else
                        { _Dbl_Impuesto = 0; }
                        _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                        _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas + _Dbl_CostoUnidades);
                        _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + (_Dbl_ImpuestoCajas + _Dbl_ImpuestoUnidades);
                    }
                }
            }
            _Txt_Costo.Text = _Dbl_MontoTotal.ToString("#,##0.00");
            //_Txt_Impuesto.Text = _Dbl_ImpuestoTotal.ToString("#,##0.00");
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                if (_Ctrl.Name != "_Rbt_Pro" & _Ctrl.Name != "_Rbt_NoPro")
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private void Frm_TransferMME_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Cmb_Entrada();
            _Mtd_Cargar_Cmb_Salida();
        }
        string _Str_Producto = "";
        string _Str_Descripcion = "";
        private void _Dg_Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                _Er_Error.Dispose();
                if (e.ColumnIndex == 1 & _Cmb_Motivo.Text.Trim().Length > 0 & !_Cmb_Motivo.Enabled)
                { }
                else if (e.ColumnIndex == 1 & _Cmb_Motivo.SelectedIndex != -1 & _Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Entrada.SelectedIndex != -1 & _Cmb_Salida.SelectedIndex != -1)
                {
                    TextBox _Txt_TemporalCod = new TextBox();
                    TextBox _Txt_TemporalDes = new TextBox();
                    Frm_BusquedaAvanzada2 _Frm = new Frm_BusquedaAvanzada2(_Txt_TemporalCod, _Txt_TemporalDes, _Mtd_Imp_Selec() + " and cexisrealu1>0");
                    _Frm.ShowDialog();
                    if (_Txt_TemporalCod.Text.Trim().Length > 0)
                    {
                        string _Str_Cadena = "Select TPROVEEDOR.cporcinvendible,TPROVEEDOR.cpordevmalestado from TPRODUCTO INNER JOIN TPROVEEDOR ON TPRODUCTO.cproveedor=TPROVEEDOR.cproveedor where TPRODUCTO.cproducto='" + _Txt_TemporalCod.Text.Trim() + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                            {
                                if (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim()) > 0)
                                {
                                    if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        _Str_Producto = _Txt_TemporalCod.Text;
                                        _Str_Descripcion = _Txt_TemporalDes.Text;
                                        _Pnl_Clave.Visible = true;
                                    }
                                }
                                else
                                {
                                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                                    {
                                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString().Trim()) > 0)
                                        {
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Txt_TemporalCod.Text;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Txt_TemporalDes.Text;
                                            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                            {
                                                _Str_Producto = _Txt_TemporalCod.Text;
                                                _Str_Descripcion = _Txt_TemporalDes.Text;
                                                _Pnl_Clave.Visible = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            _Str_Producto = _Txt_TemporalCod.Text;
                                            _Str_Descripcion = _Txt_TemporalDes.Text;
                                            _Pnl_Clave.Visible = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                                {
                                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString().Trim()) > 0)
                                    {
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Txt_TemporalCod.Text;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Txt_TemporalDes.Text;
                                        _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            _Str_Producto = _Txt_TemporalCod.Text;
                                            _Str_Descripcion = _Txt_TemporalDes.Text;
                                            _Pnl_Clave.Visible = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        _Str_Producto = _Txt_TemporalCod.Text;
                                        _Str_Descripcion = _Txt_TemporalDes.Text;
                                        _Pnl_Clave.Visible = true;
                                    }
                                }
                            }
                        }
                        ///////
                    }
                }
                else
                {
                    if (_Cmb_Motivo.SelectedIndex == -1)
                    { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                    if (_Txt_Descripcion.Text.Trim().Length == 0)
                    { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                    if (_Cmb_Entrada.SelectedIndex == -1)
                    { _Er_Error.SetError(_Cmb_Entrada, "Información requerida!!!"); }
                    if (_Cmb_Salida.SelectedIndex == -1)
                    { _Er_Error.SetError(_Cmb_Salida, "Información requerida!!!"); }
                }
            }
        }

        private void _Dg_Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool _Bol_ = false;
                int _int_i = -1;
                foreach (DataGridViewRow _DgRow in _Dg_Grid2.Rows)
                {
                    if (_DgRow.Cells[0].Value != null)
                    {
                        if (_DgRow.Cells[0].Value.ToString().Trim().ToUpper() ==Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value).Trim().ToUpper() & _DgRow.Index != e.RowIndex)
                        {
                            _Bol_ = true;
                            _int_i++;
                            break;
                        }
                    }
                }
                if (!_Bol_)
                {
                        ////
                    string _Str_Cadena = "SELECT dbo.TPROVEEDOR.cporcinvendible, dbo.TPROVEEDOR.cpordevmalestado,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END AS cnamef FROM dbo.TPRODUCTO INNER JOIN dbo.TPROVEEDOR ON dbo.TPRODUCTO.cproveedor = dbo.TPROVEEDOR.cproveedor INNER JOIN dbo.TMARCASM ON dbo.TPRODUCTO.cmarca = dbo.TMARCASM.cmarca where TPRODUCTO.cproducto='" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                            {
                                if (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim()) > 0)
                                {
                                    if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        _Str_Producto = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                        _Str_Descripcion = _Ds.Tables[0].Rows[0][2].ToString();
                                        _Pnl_Clave.Visible = true;
                                    }
                                    else
                                    {
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                                    }
                                }
                                else
                                {
                                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                                    {
                                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString().Trim()) > 0)
                                        {
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Ds.Tables[0].Rows[0][2].ToString();
                                            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                            {
                                                _Str_Producto = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                                _Str_Descripcion = _Ds.Tables[0].Rows[0][2].ToString();
                                                _Pnl_Clave.Visible = true;
                                            }
                                            else
                                            {
                                                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                                                _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                                                _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                                                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            _Str_Producto = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                            _Str_Descripcion = _Ds.Tables[0].Rows[0][2].ToString();
                                            _Pnl_Clave.Visible = true;
                                        }
                                        else
                                        {
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                                {
                                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString().Trim()) > 0)
                                    {
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Ds.Tables[0].Rows[0][2].ToString();
                                        _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            _Str_Producto = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                            _Str_Descripcion = _Ds.Tables[0].Rows[0][2].ToString();
                                            _Pnl_Clave.Visible = true;
                                        }
                                        else
                                        {
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                                        }
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("El proveedor de este producto no acepta devoluciones. ¿Esta seguro de seleccionar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        _Str_Producto = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                                        _Str_Descripcion = _Ds.Tables[0].Rows[0][2].ToString();
                                        _Pnl_Clave.Visible = true;
                                    }
                                    else
                                    {
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                                        _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value != null)
                            {
                                MessageBox.Show("El producto cargado no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (e.RowIndex != _Dg_Grid2.Rows.Count - 1)
                            {
                                _Dg_Grid2.Rows.RemoveAt(e.RowIndex);
                            }
                            else
                            {
                                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                            }
                        }
                        ////
                }
                else
                {
                    MessageBox.Show("El producto ya a sido cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (e.RowIndex != _int_i)
                    {
                        if (e.RowIndex != _Dg_Grid2.Rows.Count - 1)
                        {
                            _Dg_Grid2.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                            _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                        }
                    }
                }
            }
            _Dg_Grid2.Refresh();
            if (_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value != null & _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value != null & (_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value != null | _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value != null))// & e.RowIndex == _Dg_Grid2.Rows.Count - 1)
            {
                string _Str_Cadena = "SELECT cexisrealu1,cexisrealu2 from TPRODUCTO WHERE cproducto='" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    int _Int_CajasRestantesInv = 0, _Int_UndRestantesInv=0;
                    int _Int_UnidCaja = 0;
                    int _Int_I1 = 0;
                    int _Int_I2 = 0;
                    if (_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value != null)
                    { _Int_I1 = Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value.ToString()); }
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    { _Int_I2 = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString()); }
                    int _Int_I3 = 0;
                    int _Int_I4 = 0;
                    if (_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value != null)
                    { _Int_I3 = Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value.ToString()); }
                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                    { _Int_I4 = Convert.ToInt32(_Ds.Tables[0].Rows[0][1].ToString()); }
                    _Int_CajasRestantesInv = _Int_I2 - _Int_I1;
                    _Int_UnidCaja = Convert.ToInt32(_MyUtilidad._Mtd_ProductoUndManejo2(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    if (_Int_CajasRestantesInv > 0)
                    {
                        if (_Int_UnidCaja == -1)
                        { _Int_UndRestantesInv = _Int_I4; }
                        else
                        {
                            _Int_UndRestantesInv = _Int_UnidCaja + _Int_I4;
                        }
                    }
                    else
                    {
                        _Int_UndRestantesInv = _Int_I4;
                    }
                    if (_Int_I1>_Int_I2)
                    {
                        MessageBox.Show("Las cajas no pueden ser mayores a la existencia actual. Existencia actual: " + _Ds.Tables[0].Rows[0][0].ToString().Trim() + " Cajas", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                    }
                    else if (_Int_UndRestantesInv < _Int_I3)
                    {
                        MessageBox.Show("Las unidades no pueden ser mayores a la existencia actual. Existencia actual: " + _Int_UndRestantesInv.ToString() + " Unidades", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                    }
                    //else if (_Int_I3 > _Int_I4)
                    //{
                    //    
                    //    
                    //    //if (_Int_UndRestantesInv > _Int_I3)
                    //    //{
 
                    //    //}
                    //    MessageBox.Show("Las unidades no pueden ser mayores a la existencia actual. Existencia actual: " + _Ds.Tables[0].Rows[0][1].ToString().Trim() + " Unidades", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                    //}
                    else
                    {
                        if (e.RowIndex == _Dg_Grid2.Rows.Count - 1)
                        {
                            _Dg_Grid2.Rows.Add();
                        }
                        _Mtd_Met_Realizar_Calculo();
                    }
                }
            }
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 3 | _Dg_Grid2.CurrentCell.ColumnIndex == 4)
            {
                if (!_Mtd_IsNumeric(((TextBox)sender).Text))
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 3 | _Dg_Grid2.CurrentCell.ColumnIndex == 4)
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }
        bool _Bol_Error = true;
        private void _Dg_Grid2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0 & (_Cmb_Motivo.SelectedIndex==-1 | _Txt_Descripcion.Text.Trim().Length==0 | _Cmb_Entrada.SelectedIndex==-1 | _Cmb_Salida.SelectedIndex==-1))
            {
                _Er_Error.Dispose();
                _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].ReadOnly = true;
                if (_Cmb_Motivo.SelectedIndex == -1)
                { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length == 0)
                { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Cmb_Entrada.SelectedIndex == -1)
                { _Er_Error.SetError(_Cmb_Entrada, "Información requerida!!!"); }
                if (_Cmb_Salida.SelectedIndex == -1)
                { _Er_Error.SetError(_Cmb_Salida, "Información requerida!!!"); }
            }
            else if (e.ColumnIndex == 0)
            {
                _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].ReadOnly = false;
                _Er_Error.Dispose();
            }
            else if (e.ColumnIndex == 3 | e.ColumnIndex == 4)
            {
                if ((_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value == null | _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[2].Value == null))
                {
                    //_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[3].ReadOnly = true;
                    //_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[4].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[3].Value = null;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[4].Value = null;
                }
                else
                {
                    //_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[3].ReadOnly = false;
                    //_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[4].ReadOnly = false;
                }
            }
            if (_Bol_Error)
            {
                _Er_Error.Dispose();
                _Bol_Error = false;
            }
        }

        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Motivo();
        }
        private void _Mtd_ProcesarTrasferencia(string _P_Str_ID,string _P_Str_Salida,string _P_Str_Entrada)
        {
            string _Str_Salida = _Mtd_Generar_AjusteSalida();
            string _Str_Cadena = "UPDATE TAJUSSALC Set cejecutada='1', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustsal='" + _Str_Salida + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TTRANSFERAMMEC Set cajustsal='" + _Str_Salida + "',cautorizatransf='1' where ccompany='" + Frm_Padre._Str_Comp + "' and ctransferenciamme='" + _P_Str_ID + "' and calmacensalida='" + _P_Str_Salida + "' and calmacenentrada='"+_P_Str_Entrada+"'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
                    _Pnl_Clave.Visible = false;
                    if (_Bol_Tabs)
                    {
                        _Mtd_ProcesarTrasferencia(_Txt_Numero.Text, _Cmb_Salida.SelectedValue.ToString(), _Cmb_Entrada.SelectedValue.ToString());
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Er_Error.Dispose();
                        MessageBox.Show("El Proceso ha sido realizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Actualizar_Tabs();
                        _Tb_Tab.SelectedIndex = 0;
                    }
                    else
                    {
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value = _Str_Producto;
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[2].Value = _Str_Descripcion;
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                if (_Bol_Tabs)
                { _Lbl_Descripcion.Text = "¿Esta seguro de procesar la transferencia?"; }
                else
                { _Lbl_Descripcion.Text = "¿Esta seguro de seleccionar este Producto?"; }
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_Cmb_Proveedor.SelectedIndex != -1)
            //{
            //    _Dg_Grid2.Rows.Clear();
            //    _Dg_Grid2.Rows.Add();
            //    _Txt_Costo.Text = "";
            //}
        }

        private void Frm_TransferMME_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //____________________________________________
            if (!_Bol_Tabs)
            {
                if (!_Cmb_Motivo.Enabled & _Cmb_Motivo.Text.Trim().Length > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                }
                else if (!_Txt_Numero.Enabled & _Txt_Numero.Text.Trim().Length > 0 & _Cmb_Motivo.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else if (_Txt_Numero.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }

        private void Frm_TransferMME_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            _Txt_Numero.Text = _Mtd_Entrada().ToString();
            bool _Bol_Verificar_Grid = _Mtd_Verificar_Grid();
            if (_Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Motivo.SelectedIndex != -1 & _Cmb_Entrada.SelectedIndex != -1 & _Cmb_Salida.SelectedIndex != -1 & _Bol_Verificar_Grid)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cajustsal='" + _Txt_Numero.Text.Trim() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    _Mtd_Met_Actuaizar(_Txt_Numero.Text.Trim());
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
                if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                //if (_Cmb_Proveedor.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!!!"); }
                if (_Cmb_Salida.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Salida, "Información requerida!!!"); }
                if (_Cmb_Entrada.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Entrada, "Información requerida!!!"); }
                if (!_Bol_Verificar_Grid)
                { MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            bool _Bol_Verificar_Grid = _Mtd_Verificar_Grid();
            if (_Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Motivo.SelectedIndex != -1 & _Cmb_Entrada.SelectedIndex != -1 & _Cmb_Salida.SelectedIndex != -1 & _Bol_Verificar_Grid)
            {
                //_Mtd_Met_Actuaizar(_Txt_Numero.Text.Trim(), false);
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
                if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                //if (_Cmb_Proveedor.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!!!"); }
                if (_Cmb_Salida.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Salida, "Información requerida!!!"); }
                if (_Cmb_Entrada.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Entrada, "Información requerida!!!"); }
                if (!_Bol_Verificar_Grid)
                { MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                return false;
            }
        }
        private void _Mtd_Met_Actuaizar(string _P_Str_ID)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            int _Int_CantManejo1 = 0, _Int_CantManejo2 = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Cajas = 0;
                double _Dbl_Unidades = 0;
                double _Dbl_ccostobruto_u1 = 0;
                double _Dbl_ccostobruto_u2 = 0;
                double _Dbl_ccostoneto_u1 = 0;
                double _Dbl_ccostoneto_u2 = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null | _Dg_Row.Cells[4].Value != null))
                {
                    _Str_Cadena = "Select cproveedor,cgrupo,csku,csubgrupo,ccostoneto_u1,ccostobruto_u1,ccostoneto_u2,ccostobruto_u2,cunidadma1,ccontenidoma1,cunidadma2,ccontenidoma2 from TPRODUCTO where cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u1"].ToString()); }
                        else { _Dbl_ccostobruto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u2"].ToString()); }
                        else { _Dbl_ccostobruto_u2 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString()); }
                        else { _Dbl_ccostoneto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u2"].ToString()); }
                        else { _Dbl_ccostoneto_u2 = 0; }
                        if (_Dg_Row.Cells[3].Value != null)
                        { _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[3].Value.ToString()); }
                        else
                        { _Dbl_Cajas = 0; }
                        if (_Dg_Row.Cells[4].Value != null)
                        { _Dbl_Unidades = Convert.ToDouble(_Dg_Row.Cells[4].Value.ToString()); }
                        else
                        { _Dbl_Unidades = 0; }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidadma2"]).Length > 0)
                        {
                            _Int_CantManejo2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                        }
                        else
                        {
                            _Int_CantManejo2 = 0;
                        }
                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidadma1"]).Length > 0)
                        {
                            _Int_CantManejo1 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                        }
                        else
                        {
                            _Int_CantManejo1 = 0;
                        }
                        _Dbl_CostoCajas = _Dbl_Cajas * _Dbl_ccostobruto_u1;
                        //_Dbl_CostoUnidades = _Dbl_Unidades * _Dbl_ccostobruto_u2;
                        if (_Int_CantManejo2 > 0)
                        {
                            _Dbl_CostoUnidades = _Dbl_Unidades * (_Dbl_ccostobruto_u1 / (_Int_CantManejo1 / _Int_CantManejo2));
                        }
                        else
                        {
                            _Dbl_CostoUnidades = 0;
                        }
                        _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value.ToString().Trim() + "')";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            { _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); }
                            else { _Dbl_Impuesto = 0; }
                        }
                        else
                        { _Dbl_Impuesto = 0; }
                        _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                        _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas + _Dbl_CostoUnidades);
                        _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + (_Dbl_ImpuestoCajas + _Dbl_ImpuestoUnidades);
                        DataRow _Row = _Ds.Tables[0].Rows[0];
                        _Str_Cadena = "Insert into TTRANSFERAMMED (ccompany,ctransferenciamme,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,canttransferir_u1,canttransferir_u2,ccosttot_u1,ccosttot_u2) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Dg_Row.Cells[0].Value.ToString().Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u2) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u2) + "','" + _Dbl_Cajas.ToString() + "','" + _Dbl_Unidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoUnidades) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
            _Str_Cadena = "Insert into TTRANSFERAMMEC (ccompany,ctransferenciamme,calmacensalida,calmacenentrada,cfecha,cidmotivo,cdescripcion) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Cmb_Salida.SelectedValue + "','" + _Cmb_Entrada.SelectedValue + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Cmb_Motivo.SelectedValue + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        public int _Mtd_EntradaSalida()
        {
            string _Str_Cadena = "SELECT cajustsal FROM TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cajustsal  DESC";
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
        private string _Mtd_Generar_AjusteSalida()
        {
            string _P_Str_ID = _Mtd_EntradaSalida().ToString();
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Cajas = 0;
                double _Dbl_Unidades = 0;
                double _Dbl_ccostobruto_u1 = 0;
                double _Dbl_ccostobruto_u2 = 0;
                double _Dbl_ccostoneto_u1 = 0;
                double _Dbl_ccostoneto_u2 = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null | _Dg_Row.Cells[4].Value != null))
                {
                    _Str_Cadena = "Select cproveedor,cgrupo,csku,csubgrupo,ccostoneto_u1,ccostobruto_u1,ccostoneto_u2,ccostobruto_u2 from TPRODUCTO where cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u1"].ToString()); }
                        else { _Dbl_ccostobruto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u2"].ToString()); }
                        else { _Dbl_ccostobruto_u2 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString()); }
                        else { _Dbl_ccostoneto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u2"].ToString()); }
                        else { _Dbl_ccostoneto_u2 = 0; }
                        if (_Dg_Row.Cells[3].Value != null)
                        { _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[3].Value.ToString()); }
                        else
                        { _Dbl_Cajas = 0; }
                        if (_Dg_Row.Cells[4].Value != null)
                        { _Dbl_Unidades = Convert.ToDouble(_Dg_Row.Cells[4].Value.ToString()); }
                        else
                        { _Dbl_Unidades = 0; }
                        _Dbl_CostoCajas = _Dbl_Cajas * _Dbl_ccostobruto_u1;
                        _Dbl_CostoUnidades = _Dbl_Unidades * _Dbl_ccostobruto_u2;
                        _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value.ToString().Trim() + "')";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            { _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); }
                            else { _Dbl_Impuesto = 0; }
                        }
                        else
                        { _Dbl_Impuesto = 0; }
                        _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                        _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas + _Dbl_CostoUnidades);
                        _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + (_Dbl_ImpuestoCajas + _Dbl_ImpuestoUnidades);
                        DataRow _Row = _Ds.Tables[0].Rows[0];
                        _Str_Cadena = "Insert into TAJUSSALD (ccompany,cajustsal,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Row["cproveedor"].ToString() + "','" + _Row["cgrupo"].ToString() + "','" + _Row["csubgrupo"].ToString() + "','" + _Row["csku"].ToString() + "','" + _Dg_Row.Cells[0].Value.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u2) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u2) + "','" + _Dbl_Cajas.ToString() + "','" + _Dbl_Unidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoUnidades) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoUnidades) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
            _Str_Cadena = "Insert into TAJUSSALC (ccompany,cajustsal,cname,cidmotivo,cyearacco,cmontacco,cdateajus,ccosttotsimp,cvalorimp,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Txt_Descripcion.Text.Trim() + "','" + _Cmb_Motivo.SelectedValue + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _P_Str_ID;
        }
        private void _Cmb_Salida_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_Salida();
        }

        private void _Cmb_Entrada_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_Entrada();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Txt_Numero.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0,e.RowIndex);
                _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                _Txt_Fecha.Text = Convert.ToDateTime(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex)).Date.ToShortDateString();
                _Cmb_Motivo.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex);
                _Txt_Costo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                _Cmb_Salida.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex);
                _Cmb_Entrada.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex);
                string _Str_Cadena = "Select cproducto,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=TTRANSFERAMMED.cproducto) as cnamef,canttransferir_u1,canttransferir_u2 from TTRANSFERAMMED where ccompany='" + Frm_Padre._Str_Comp + "' and ctransferenciamme='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                object[] _Obj = new object[5];
                _Dg_Grid2.Rows.Clear();
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Obj[0] = _Row[0].ToString();
                    _Obj[1] = "";
                    _Obj[2] = _Row[1].ToString();
                    _Obj[3] = _Row[2].ToString();
                    _Obj[4] = _Row[3].ToString();
                    _Dg_Grid2.Rows.Add(_Obj);
                }
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //if (!_Bol_Tabs)
                //{
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                //}
                //else
                //{
                //    _Bt_Generar.Enabled = true;
                //}
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Procesar_Click(object sender, EventArgs e)
        {
            if (_Txt_Numero.Text.Trim().Length > 0 & _Cmb_Motivo.SelectedIndex!=-1)
            {
                if (MessageBox.Show("¿Esta seguro de procesar la transferencia?", "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para reaizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Rbt_Pro_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Rbt_NoPro_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
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

        private void _Dg_Grid2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid2.RowCount > 0)
            {
                string _Str_CodProducto = "";
                double _Dbl_CantUnidades = 0, _Dbl_CantUnid2Prod=0;
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToString(_Dg_Grid2[0, e.RowIndex].Value).Trim().Length > 0)
                    {
                        if (_MyUtilidad._Mtd_ProductoUndManejo2(Convert.ToString(_Dg_Grid2[0, e.RowIndex].Value).Trim()) == -1)
                        {//NO ACEPTA UNIDAD DE MANEJO 2
                            _Dg_Grid2[4, e.RowIndex].ReadOnly = true;
                        }
                        else
                        {
                            _Dg_Grid2[4, e.RowIndex].ReadOnly = false;
                        }
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    _Str_CodProducto = Convert.ToString(_Dg_Grid2[0, e.RowIndex].Value).Trim();
                    if (_Str_CodProducto.Length > 0)
                    {
                        if (Convert.ToString(_Dg_Grid2[e.ColumnIndex, e.RowIndex].Value).Length > 0)
                        {
                            _Dbl_CantUnidades = Convert.ToDouble(_Dg_Grid2[e.ColumnIndex, e.RowIndex].Value);
                        }
                        if (_Dbl_CantUnidades > 0)
                        {
                            _Dbl_CantUnid2Prod=_MyUtilidad._Mtd_ProductoUndManejo2(_Str_CodProducto);
                            if (_Dbl_CantUnid2Prod <= _Dbl_CantUnidades)
                            {
                                MessageBox.Show("No puede ingresar esta cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Dg_Grid2.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_Grid2_CellValueChanged);
                                _Dg_Grid2[e.ColumnIndex, e.RowIndex].Value = "0";
                                _Dg_Grid2.CellValueChanged += new DataGridViewCellEventHandler(_Dg_Grid2_CellValueChanged);
                            }
                        }
                    }
                }
            }
        }

        private void _Cntx_MenuGrid_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid2.CurrentCell != null)
            {
                if (_Dg_Grid2.SelectedRows.Count == 0)
                { e.Cancel = true; }
                else
                {
                    if (Convert.ToString(_Dg_Grid2[0, _Dg_Grid2.CurrentCell.RowIndex].Value).Trim().Length == 0)
                    {
                        e.Cancel = true;
                    }
                }
                if (_Str_MyProceso.Length == 0 & !_Txt_Descripcion.Enabled)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                if (!_Cmb_Motivo.Enabled & _Txt_Numero.Text.Trim().Length == 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Dg_Grid2.Rows.RemoveAt(_Dg_Grid2.CurrentCell.RowIndex);
            _Mtd_Met_Realizar_Calculo();
        }
        
    }
}