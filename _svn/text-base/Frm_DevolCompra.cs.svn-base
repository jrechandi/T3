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
    public partial class Frm_DevolCompra : Form
    {
        string _Str_MyProceso = "";
        string _Str_RecepId = "";
        public Frm_DevolCompra()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ciddevcomp";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "";
            if (_Rbt_Pro.Checked)
            { _Str_Cadena = "Select ciddevcomp as Código, CONVERT(char(10),cfechadev,103) AS Fecha,cproveedornombc as Proveedor, cidnotrecepc as [N.R],cnfacturapro as Factura,ccajas as Cajas,cunidades as Unidades,ccostotot as Costo,cidnotentrega as [N.E],cproveedor,cidmotivo,ctipodevol,cporcreconoce,cnnotarecojo from VST_DEVCOMPRAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpresa='1'"; }
            else
            { _Str_Cadena = "Select ciddevcomp as Código, CONVERT(char(10),cfechadev,103) AS Fecha,cproveedornombc as Proveedor, cidnotrecepc as [N.R],cnfacturapro as Factura,ccajas as Cajas,cunidades as Unidades,ccostotot as Costo,cidnotentrega as [N.E],cproveedor,cidmotivo,ctipodevol,cporcreconoce,cnnotarecojo from VST_DEVCOMPRAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpresa='0'"; }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = false;
            _Dg_Grid.Columns[11].Visible = false;
            _Dg_Grid.Columns[12].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public int _Mtd_Entrada_Devolucion()
        {
            string _Str_Cadena = "SELECT ciddevcomp FROM TDEVCOMPRAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY ciddevcomp  DESC";
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
        public int _Mtd_Entrada_NotaEntrega()
        {
            string _Str_Cadena = "SELECT cidnotentrega FROM TNOTAENTREGM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidnotentrega  DESC";
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
        public int _Mtd_Entrada_NotaDebito()
        {
            string _Str_Cadena = "SELECT cidnotadebitocxp FROM TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidnotadebitocxp  DESC";
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
            _Txt_Fecha.Text = "";
            _Txt_Costo.Text = "";
            _Txt_Cajas.Text = "";
            _Txt_Reconoce.Text = "";
            _Txt_Nota.Text = "";
            _Chbox_SinFactura.Checked = false;
            _Grb_Nota.Visible = false;
            _Rbt_B.Checked = false;
            _Rbt_M.Checked = false;
            _Dg_Grid2.Rows.Clear();
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Proveedor();
            _Mtd_Habilitar();
            _Txt_Numero.Enabled = true;
            _Str_MyProceso = "";
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Numero.Enabled = false;
            //_Cmb_Motivo.Enabled = true;
            _Cmb_Proveedor.Enabled = true;
            _Dg_Grid2.ReadOnly = false;
            _Dg_Grid2.Columns[0].ReadOnly = true;
            _Dg_Grid2.Columns[2].ReadOnly = true;
            _Dg_Grid2.Columns[5].ReadOnly = true;
            _Dg_Grid2.Columns[6].ReadOnly = true;
            _Str_MyProceso = "M";
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Numero.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Cmb_Proveedor.Enabled = false;
            _Txt_Nota.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Rbt_B.Enabled = false;
            _Rbt_M.Enabled = false;
            _Dg_Grid2.ReadOnly = true;
        }
        private void _Mtd_Cargar_Motivo()
        {
            _Cmb_Motivo.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT TMOTIVO.cidmotivo,TMOTIVO.cdescripcion FROM TMOTIVO where cmotivodev='1' ORDER BY TMOTIVO.cconcepto ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Motivo.DataSource = _Ds.Tables[0];
            _Cmb_Motivo.DisplayMember = "cdescripcion";
            _Cmb_Motivo.ValueMember = "cidmotivo";
            _Cmb_Motivo.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Proveedor()
        {
            _Cmb_Proveedor.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT DISTINCT TPRODUCTO.cproveedor, TPROVEEDOR.c_nomb_comer FROM TPROVEEDOR INNER JOIN"+
                      " TPRODUCTO ON dbo.TPROVEEDOR.cproveedor = dbo.TPRODUCTO.cproveedor "+
"WHERE     (TPROVEEDOR.cglobal = '1') AND (NOT EXISTS "+
                          "(SELECT cproveedor "+
                            "FROM TFILTROREGIONALP "+
                            "WHERE  (TPRODUCTO.cproveedor = cproveedor) AND (TPRODUCTO.cproducto = cproducto) AND (cdelete = '0') AND CCOMPANY='"+Frm_Padre._Str_Comp+"')) AND "+
                      "(TPROVEEDOR.cdelete = '0') "+
"ORDER BY dbo.TPROVEEDOR.c_nomb_comer";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Proveedor.DataSource = _Ds.Tables[0];
            _Cmb_Proveedor.DisplayMember = "c_nomb_comer";
            _Cmb_Proveedor.ValueMember = "cproveedor";
            _Cmb_Proveedor.SelectedIndex = -1;
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
        private bool _Mtd_Verificar_Grid()
        {
            _Dg_Grid2.EndEdit();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null || _Dg_Row.Cells[4].Value != null))
                {
                    return true;
                }
            }
            return false;
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
        private string _Mtd_Imp_Selec2(string _P_Str_Cadena)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
            string _Str_Cadena = " and (";
            bool _Bol_String = false;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                if (_Row[2].ToString().Trim() == "0")
                {
                    _Str_Cadena = _Str_Cadena + "cproducto!='" + _Row[0].ToString().Trim() + "' and ";
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
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            _Txt_Numero.Text = _Mtd_Entrada_Devolucion().ToString();
            bool _Bol_Verificar_Grid = _Mtd_Verificar_Grid();
            string _Str_Cadena = "Select cnotarecojo from TPROVEEDOR where cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            bool _Bol_Nota = false;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1" & _Rbt_M.Checked)
                { _Bol_Nota = true; }
            }
            if (_Bol_Nota)
            {
                if (_Cmb_Motivo.SelectedIndex != -1 & _Cmb_Proveedor.SelectedIndex != -1 & _Txt_Nota.Text.Trim().Length>0 & _Bol_Verificar_Grid)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TDEVCOMPRAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevcomp='" + _Txt_Numero.Text.Trim() + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        _Str_Cadena = "Select * from TDEVCOMPRAM where cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='"+_Cmb_Proveedor.SelectedValue+"' and cnnotarecojo='"+_Txt_Nota.Text.Trim()+"'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("La Nota de recojo ya existe. Coloque una diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {
                            _Mtd_Guardar_Devolucion(_Txt_Numero.Text.Trim());
                            MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar();
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Tb_Tab.SelectedIndex = 0;
                            _Er_Error.Dispose();
                            if ((Frm_Padre)this.MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                    if (_Cmb_Proveedor.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!!!"); }
                    if (_Txt_Nota.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Nota, "Información requerida!!!"); }
                    if (!_Bol_Verificar_Grid)
                    { MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    return false;
                }
            }
            else if (_Chbox_SinFactura.Checked)
            {
                if (_Cmb_Motivo.SelectedIndex != -1 & _Cmb_Proveedor.SelectedIndex != -1 & _Bol_Verificar_Grid)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TDEVCOMPRAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevcomp='" + _Txt_Numero.Text.Trim() + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        _Mtd_Guardar_Devolucion(_Txt_Numero.Text.Trim());
                        MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Actualizar();
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Er_Error.Dispose();
                        if ((Frm_Padre)this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                        return true;
                    }
                }
                else
                {
                    if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                    if (_Cmb_Proveedor.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!!!"); }
                    if (!_Bol_Verificar_Grid)
                    { MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    return false;
                }
            }
            else
            {
                if (_Cmb_Motivo.SelectedIndex != -1 & _Cmb_Proveedor.SelectedIndex != -1 & _Txt_NRecep.Text.Trim().Length > 0 & _Txt_Fact.Text.Trim().Length > 0 & _Bol_Verificar_Grid)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TDEVCOMPRAM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevcomp='" + _Txt_Numero.Text.Trim() + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        _Mtd_Guardar_Devolucion(_Txt_Numero.Text.Trim());
                        MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Actualizar();
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Er_Error.Dispose();
                        if ((Frm_Padre)this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                        return true;
                    }
                }
                else
                {
                    if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                    if (_Cmb_Proveedor.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!!!"); }
                    if (_Txt_NRecep.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_NRecep, "Información requerida!!!"); }
                    if (_Txt_Fact.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Fact, "Información requerida!!!"); }
                    if (!_Bol_Verificar_Grid)
                    { MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    return false;
                }
            }
        }
        private void _Mtd_Guardar_Devolucion(string _P_Str_ID)
        {
            if (_Txt_Reconoce.Text.Trim().Length == 0)
            { _Txt_Reconoce.Text = "0"; }
            if (_Txt_NRecep.Text.Trim().Length == 0)
            { _Txt_NRecep.Text = "0"; }
            if (_Txt_Fact.Text.Trim().Length == 0)
            { _Txt_Fact.Text = "0"; }
            if (_Txt_Nota.Text.Trim().Length == 0)
            { _Txt_Nota.Text = "0"; }
            string _Str_TipoDev = "";
            if (_Rbt_B.Checked)
            { _Str_TipoDev = "B"; }
            else if (_Rbt_M.Checked)
            { _Str_TipoDev = "M"; }
            if (_Str_RecepId.Trim().Length == 0)
            { _Str_RecepId="0";}
            string _Str_Cadena = "";
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_Cajas = 0;
                double _Dbl_Und = 0;
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnd = 0;
                double _Dbl_CostoTotal = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Invendible = 0;
                double _Dbl_Base_Grabada = 0;
                double _Dbl_Alicuota = 0;
                double _Dbl_Base_Excenta = 0;
                double _Dbl_Monto_Total_D = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null || _Dg_Row.Cells[4].Value != null))
                {
                    _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[3].Value);
                    _Dbl_Und= Convert.ToDouble(_Dg_Row.Cells[4].Value);
                    _Dbl_CostoCajas = Convert.ToDouble(_Dg_Row.Cells[5].Value);
                    _Dbl_CostoUnd = Convert.ToDouble(_Dg_Row.Cells[6].Value);
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_Invendible = Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim()); }
                    }
                    _Dbl_CostoTotal = _Dbl_Cajas * _Dbl_CostoCajas+(_Dbl_Und*_Dbl_CostoUnd);
                    _Dbl_Invendible = ((_Dbl_CostoTotal * _Dbl_Invendible) / 100);
                    _Dbl_CostoTotal = _Dbl_CostoTotal - _Dbl_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString());
                            _Dbl_Alicuota = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        _Dbl_Impuesto = (_Dbl_CostoTotal * _Dbl_Impuesto) / 100;
                        _Dbl_CostoTotal = _Dbl_CostoTotal + _Dbl_Invendible;
                        _Dbl_Base_Grabada = _Dbl_Base_Grabada + _Dbl_CostoTotal;
                    }
                    else
                    {
                        _Dbl_CostoTotal = _Dbl_CostoTotal + _Dbl_Invendible;
                        _Dbl_Base_Excenta = _Dbl_Base_Excenta + _Dbl_CostoTotal;
                    }
                    if (Convert.ToDouble(_Txt_Reconoce.Text.Trim()) > 0 & Convert.ToDouble(_Txt_Reconoce.Text.Trim()) < 100)
                    {
                        _Dbl_CostoTotal = _Dbl_CostoTotal - ((_Dbl_CostoTotal * Convert.ToDouble(_Txt_Reconoce.Text.Trim())) / 100);
                    }
                    _Dbl_Monto_Total_D = (_Dbl_CostoTotal - _Dbl_Invendible) + _Dbl_Impuesto;
                    _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_CostoTotal;
                    _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + _Dbl_Impuesto;
                    _Str_Cadena = "Insert into TDEVCOMPRAD (cgroupcomp,ccompany,ciddevcomp,cproveedor,cidnotrecepc,cproducto,ccajas,cunidades,ccostoxcaj,ccostoxund,ccostotot,ccostimp,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Cmb_Proveedor.SelectedValue + "','" + _Txt_NRecep.Text.Trim() + "','" + _Dg_Row.Cells[0].Value.ToString().Trim() + "','" + _Dbl_Cajas.ToString() + "','" + _Dbl_Und.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoUnd) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            _Str_Cadena = "Insert into TDEVCOMPRAM (cgroupcomp,ccompany,ciddevcomp,cproveedor,cidnotrecepc,cnfacturapro,cporcreconoce,cfechadev,ccostotot,ccostimp,ctipodevol,cidmotivo,cnnotarecojo,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Cmb_Proveedor.SelectedValue + "','" + _Txt_NRecep.Text.Trim() + "','" + _Txt_Fact.Text.Trim() + "','" + _Txt_Reconoce.Text.Trim() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal) + "','" + _Str_TipoDev + "','" + _Cmb_Motivo.SelectedValue + "','" + _Txt_Nota.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            string _Str_NotaEntrega = _Mtd_Guardar_NotaEntrega(_P_Str_ID);
            string _Str_NotaDebito = _Mtd_Guardar_NotaDebito(_Str_NotaEntrega, _P_Str_ID);
            _Str_Cadena = "UPDATE TDEVCOMPRAM SET cidnotentrega='" + _Str_NotaEntrega + "',cidnotadebitocxp='" + _Str_NotaDebito + "' WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevcomp='" + _P_Str_ID + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private string _Mtd_Guardar_NotaEntrega(string _P_Str_ID_Devol)
        {
            string _Str_ID_NotaEntrega = _Mtd_Entrada_NotaEntrega().ToString();
            string _Str_Cadena = "";
            string _Str_TipoNotaEntrega = "";
            string _Str_TipoDevBue = "";
            string _Str_TipoDevMal = "";
            string _Str_TipoFactura = "";
            DateTime _Dtp_Fecha_Factura = new DateTime();
            DataSet _Ds2 = new DataSet();
            _Str_Cadena = "SELECT ctiponotentregaec,ctiponotrecepdevbe,ctiponotrecepdevme,ctipodocumentfact FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                _Str_TipoNotaEntrega = _Ds2.Tables[0].Rows[0][0].ToString();
                _Str_TipoDevBue = _Ds2.Tables[0].Rows[0][1].ToString();
                _Str_TipoDevMal = _Ds2.Tables[0].Rows[0][2].ToString();
                _Str_TipoFactura = _Ds2.Tables[0].Rows[0][3].ToString();
            }
            _Str_Cadena = "Select cdatefactura from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_RecepId + "' and cnfacturapro='" + _Txt_Fact.Text.Trim() + "' and cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
            _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dtp_Fecha_Factura = Convert.ToDateTime(_Ds2.Tables[0].Rows[0][0].ToString());
                }
            }
            double _Dbl_MontoTotalSimIm_M = 0;
            double _Dbl_MontoTotal_M = 0;
            double _Dbl_ImpuestoTotal_M = 0;
            double _Dbl_Invendible_M = 0;
            double _Dbl_Base_Grabada_M = 0;
            double _Dbl_Base_Excenta_M = 0;
            int _Int_ID_Nota_Entrega_D = 1;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_Cajas = 0;
                double _Dbl_Und = 0;
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnd = 0;
                double _Dbl_CostoTotal = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Invendible = 0;
                double _Dbl_Base_Grabada = 0;
                double _Dbl_Alicuota = 0;
                double _Dbl_Base_Excenta = 0;
                double _Dbl_Monto_Total_D = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null || _Dg_Row.Cells[4].Value != null))
                {
                    _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[3].Value);
                    _Dbl_Und = Convert.ToDouble(_Dg_Row.Cells[4].Value);
                    _Dbl_CostoCajas = Convert.ToDouble(_Dg_Row.Cells[5].Value);
                    _Dbl_CostoUnd = Convert.ToDouble(_Dg_Row.Cells[6].Value);
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_Invendible = Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim()); }
                    }
                    _Dbl_CostoTotal = _Dbl_Cajas * _Dbl_CostoCajas+(_Dbl_Und*_Dbl_CostoUnd);
                    _Dbl_Invendible = ((_Dbl_CostoTotal * _Dbl_Invendible) / 100);
                    _Dbl_CostoTotal = _Dbl_CostoTotal - _Dbl_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString());
                            _Dbl_Alicuota = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        _Dbl_Impuesto = (_Dbl_CostoTotal * _Dbl_Impuesto) / 100;
                        _Dbl_CostoTotal = _Dbl_CostoTotal + _Dbl_Invendible;
                        _Dbl_Base_Grabada = _Dbl_Base_Grabada + _Dbl_CostoTotal;
                    }
                    else
                    {
                        _Dbl_CostoTotal = _Dbl_CostoTotal + _Dbl_Invendible;
                        _Dbl_Base_Excenta = _Dbl_Base_Excenta + _Dbl_CostoTotal;
                    }
                    if (Convert.ToDouble(_Txt_Reconoce.Text.Trim()) > 0 & Convert.ToDouble(_Txt_Reconoce.Text.Trim()) < 100)
                    {
                        _Dbl_CostoTotal = _Dbl_CostoTotal - ((_Dbl_CostoTotal * Convert.ToDouble(_Txt_Reconoce.Text.Trim())) / 100);
                    }
                    _Dbl_Monto_Total_D = (_Dbl_CostoTotal - _Dbl_Invendible) + _Dbl_Impuesto;
                    _Dbl_MontoTotalSimIm_M = _Dbl_MontoTotalSimIm_M + _Dbl_CostoTotal;
                    _Dbl_ImpuestoTotal_M = _Dbl_ImpuestoTotal_M + _Dbl_Impuesto;
                    _Dbl_MontoTotal_M = _Dbl_MontoTotal_M + _Dbl_Monto_Total_D;
                    _Dbl_Invendible_M = _Dbl_Invendible_M + _Dbl_Invendible;
                    _Dbl_Base_Grabada_M = _Dbl_Base_Grabada_M + _Dbl_Base_Grabada;
                    _Dbl_Base_Excenta_M = _Dbl_Base_Excenta_M + _Dbl_Base_Excenta;
                    _Str_Cadena = "Insert into TNOTAENTREGD (cgroupcomp,ccompany,ciddevcomp,cidnotentrega,ciddnotentrega,cproducto,cempaques,cunidades,cmontosi,cmontoimp,cmontoinvendi,cbasegrabada,cbasexcenta,cmontototal,calicuota,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_ID_Devol.Trim() + "','" + _Str_ID_NotaEntrega.ToString() + "','" + _Int_ID_Nota_Entrega_D.ToString() + "','" + _Dg_Row.Cells[0].Value.ToString().Trim() + "','" + _Dbl_Cajas.ToString() + "','" + _Dbl_Und.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Excenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Alicuota) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Int_ID_Nota_Entrega_D++;
                }
            }
            if (_Chbox_SinFactura.Checked)
            { _Str_Cadena = "Insert into TNOTAENTREGM (cgroupcomp,ccompany,ciddevcomp,cidnotentrega,ctiponotentrega,cfechanotentrega,ctipodocument,cnumdocu,cproveedor,cporcreconoce,cmontosi,cmontoimp,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_ID_Devol.Trim() + "','" + _Str_ID_NotaEntrega.ToString() + "','" + _Str_TipoNotaEntrega + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_TipoDevMal + "','" + _P_Str_ID_Devol + "','" + _Cmb_Proveedor.SelectedValue + "','" + _Txt_Reconoce.Text.Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotalSimIm_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Invendible_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Grabada_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Excenta_M) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')"; }
            else
            { _Str_Cadena = "Insert into TNOTAENTREGM (cgroupcomp,ccompany,ciddevcomp,cidnotentrega,ctiponotentrega,cfechanotentrega,ctipodocument,cnumdocu,cfechadocu,cproveedor,cporcreconoce,cmontosi,cmontoimp,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_ID_Devol.Trim() + "','" + _Str_ID_NotaEntrega.ToString() + "','" + _Str_TipoNotaEntrega + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_TipoFactura + "','" + _Txt_Fact.Text.Trim() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Factura) + "','" + _Cmb_Proveedor.SelectedValue + "','" + _Txt_Reconoce.Text.Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotalSimIm_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Invendible_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Grabada_M) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Excenta_M) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _Str_ID_NotaEntrega;
        }
        private string _Mtd_Guardar_NotaDebito(string _P_Str_Nota_Entrega, string _P_Str_Devolucion)
        {
            string _Str_Cadena = "Select cproducto,cempaques,cunidades from TNOTAENTREGD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidnotentrega='" + _P_Str_Nota_Entrega + "' and ciddevcomp='" + _P_Str_Devolucion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _Ds2 = new DataSet();
            int _Int_Consecutivo = 0;
            double _Dbl_Monto_Sin_Impuesto = 0;
            double _Dbl_Total_Invendible = 0;
            double _Dbl_Impuesto = 0;
            double _Dbl_Base_Grabada = 0;
            double _Dbl_Base_Excenta = 0;
            string _Str_Descripcion = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_Consecutivo = _Mtd_Entrada_NotaDebito();
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    double _Dbl_Precio = 0;
                    double _Dbl_Monto = 0;
                    double _Dbl_Base_GrabadaD = 0;
                    double _Dbl_Base_ExcentaD = 0;
                    double _Dbl_Alicuota = 0;
                    if (!_Chbox_SinFactura.Checked)
                    {_Str_Cadena = "Select cpreciouni from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_RecepId + "' and cnfacturapro='" + _Txt_Fact.Text + "' and cproducto='" + _Row[0].ToString() + "'";}
                    else
                    {_Str_Cadena = "Select ccostoneto_u1 from TPRODUCTO where cproducto='" + _Row[0].ToString() + "' and cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";}
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {_Dbl_Precio = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString());}
                    if (_Row[1] != System.DBNull.Value)
                    { _Dbl_Monto = _Dbl_Precio * Convert.ToDouble(_Row[1].ToString().Trim()); }
                    //-----------------------------
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'";
                    double _Dbl_Invendible = 0;
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_Invendible = Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim()); }
                    }
                    //-----------------------------
                    _Dbl_Invendible = ((_Dbl_Monto * _Dbl_Invendible) / 100);
                    _Dbl_Total_Invendible = _Dbl_Total_Invendible + _Dbl_Invendible;
                    _Dbl_Monto = _Dbl_Monto - _Dbl_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    double _Dbl_ImpuestoCalculado = 0;
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            _Dbl_ImpuestoCalculado = (_Dbl_Monto * Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                            _Dbl_Impuesto = _Dbl_Impuesto + _Dbl_ImpuestoCalculado;
                            _Dbl_Monto = _Dbl_Monto + _Dbl_Invendible;
                            _Dbl_Base_Grabada = _Dbl_Base_Grabada + _Dbl_Monto;
                            _Dbl_Base_GrabadaD = _Dbl_Base_GrabadaD + _Dbl_Monto;
                            _Dbl_Alicuota = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        catch { _Dbl_Impuesto = _Dbl_Impuesto + 0; }
                    }
                    else
                    {
                        _Dbl_Monto = _Dbl_Monto + _Dbl_Invendible;
                        _Dbl_Base_Excenta = _Dbl_Base_Excenta + _Dbl_Monto;
                        _Dbl_Base_ExcentaD = _Dbl_Base_ExcentaD + _Dbl_Monto;
                    }
                    //----------------------------------------
                    if (Convert.ToDouble(_Txt_Reconoce.Text.Trim()) > 0 & Convert.ToDouble(_Txt_Reconoce.Text.Trim()) < 100)
                    {
                        _Dbl_Monto = _Dbl_Monto - ((_Dbl_Monto * Convert.ToDouble(_Txt_Reconoce.Text.Trim())) / 100);
                    }
                    double _Dbl_Monto_Total_D = (_Dbl_Monto - _Dbl_Invendible) + _Dbl_ImpuestoCalculado;
                    _Str_Cadena = "insert into TNOTADEBITOCPD (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cproducto,ccajas,cunidades,cmontosimp,cmontoinvendi,cbasegrabada,cbasexcenta,cimpuesto,cmontototal,calicuota) values" + "('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Cmb_Proveedor.SelectedValue.ToString() + "','" + _Row[0].ToString() + "','" + _Row[1].ToString() + "','" + _Row[2].ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_ExcentaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoCalculado) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Alicuota) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //----------------------------------------
                    _Dbl_Monto_Sin_Impuesto = _Dbl_Monto_Sin_Impuesto + _Dbl_Monto;
                }
            }
            double _Dbl_Monto_Total = (_Dbl_Monto_Sin_Impuesto - _Dbl_Total_Invendible) + _Dbl_Impuesto;
            _Str_Descripcion = _Cmb_Motivo.Text + " FACTURA# " + _Txt_Fact.Text.Trim();
            string _Str_Motivo = _Cmb_Motivo.SelectedValue.ToString();
            _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
"FROM TDOCUMENT INNER JOIN " +
"TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentfact " +
"WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
            _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_TD = "";
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                _Str_TD = _Ds2.Tables[0].Rows[0][0].ToString();
            }
            _Str_Cadena = "Select cdatefactura from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_RecepId + "' and cnfacturapro='" + _Txt_Fact.Text.Trim() + "' and cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
            _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DateTime _Dte_Fecha = new DateTime();
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dte_Fecha = Convert.ToDateTime(_Ds2.Tables[0].Rows[0][0].ToString());
                }
            }
            if (_Chbox_SinFactura.Checked)
            { _Str_Cadena = "insert into TNOTADEBITOCP (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cfechand,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cidmotivo,cfvfnotadebitop) values" + "('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Cmb_Proveedor.SelectedValue.ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Sin_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_TD + "','" + _Txt_Fact.Text.Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Total_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Total) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Excenta) + "','" + _Str_Motivo + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')"; }
            else
            { _Str_Cadena = "insert into TNOTADEBITOCP (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cfechand,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cidmotivo,cfvfnotadebitop) values" + "('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Cmb_Proveedor.SelectedValue.ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Sin_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_TD + "','" + _Txt_Fact.Text.Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Total_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto_Total) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Base_Excenta) + "','" + _Str_Motivo + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dte_Fecha) + "')"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos _Cls_Proceso = new T3.CLASES._Cls_Varios_Metodos(true);
            int _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_COMP_DEVOLUCION(_Int_Consecutivo.ToString(), _Cmb_Proveedor.SelectedValue.ToString());
            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Int_Consecutivo.ToString() + "' and cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'");
            return _Int_Consecutivo.ToString();
        }
        private void _Mtd_Met_Realizar_Calculo()
        {
            if (_Txt_Reconoce.Text.Trim().Length == 0)
            { _Txt_Reconoce.Text = "0"; }
            string _Str_Cadena = "";
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_CajasTotal=0;
            double _Dbl_UndTotal = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_Cajas = 0;
                double _Dbl_Und = 0;
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnd = 0;
                double _Dbl_CostoTotal = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Invendible = 0;
                double _Dbl_Base_Grabada = 0;
                double _Dbl_Alicuota = 0;
                double _Dbl_Base_Excenta = 0;
                double _Dbl_Monto_Total_D = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[2].Value != null & (_Dg_Row.Cells[3].Value != null || _Dg_Row.Cells[4].Value != null))
                {
                    _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[3].Value);
                    _Dbl_Und = Convert.ToDouble(_Dg_Row.Cells[4].Value);
                    _Dbl_CostoCajas = Convert.ToDouble(_Dg_Row.Cells[5].Value);
                    _Dbl_CostoUnd = Convert.ToDouble(_Dg_Row.Cells[6].Value);
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_Invendible = Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim()); }
                    }
                    _Dbl_CostoTotal = _Dbl_Cajas * _Dbl_CostoCajas+(_Dbl_Und*_Dbl_CostoUnd);
                    _Dbl_Invendible = ((_Dbl_CostoTotal * _Dbl_Invendible) / 100);
                    _Dbl_CostoTotal = _Dbl_CostoTotal - _Dbl_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { 
                            _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); 
                            _Dbl_Alicuota=Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); 
                        }
                        _Dbl_Impuesto = (_Dbl_CostoTotal * _Dbl_Impuesto) / 100;
                        _Dbl_CostoTotal = _Dbl_CostoTotal + _Dbl_Invendible;
                        _Dbl_Base_Grabada = _Dbl_Base_Grabada + _Dbl_CostoTotal;
                    }
                    else
                    {
                        _Dbl_CostoTotal = _Dbl_CostoTotal + _Dbl_Invendible;
                        _Dbl_Base_Excenta = _Dbl_Base_Excenta + _Dbl_CostoTotal;
                    }
                    if (Convert.ToDouble(_Txt_Reconoce.Text.Trim()) > 0 & Convert.ToDouble(_Txt_Reconoce.Text.Trim()) < 100)
                    {
                        _Dbl_CostoTotal = _Dbl_CostoTotal - ((_Dbl_CostoTotal * Convert.ToDouble(_Txt_Reconoce.Text.Trim())) / 100);
                    }
                    _Dbl_Monto_Total_D = (_Dbl_CostoTotal - _Dbl_Invendible) + _Dbl_Impuesto;
                    _Dg_Row.Cells[7].Value = _Dbl_CostoTotal.ToString("#,##0.00");
                    _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_CostoTotal;
                    _Dbl_CajasTotal=_Dbl_CajasTotal+_Dbl_Cajas;
                    _Dbl_UndTotal = _Dbl_UndTotal + _Dbl_Und;
                }
            }
            _Txt_Costo.Text = _Dbl_MontoTotal.ToString("#,##0.00");
            _Txt_Cajas.Text = _Dbl_CajasTotal.ToString();
            _Txt_Und.Text = _Dbl_UndTotal.ToString();
        }
        bool _Bol_Error = true;
        public void _Mtd_Nuevo()
        {
            _Bol_Error = true;
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Fecha.Text = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            _Cmb_Proveedor.Focus();
            _Str_MyProceso = "N";
        }
        private void _Mtd_VerificarProveedor(string _P_Str_Proveedor,string _P_Str_ID)
        {
            if (_P_Str_ID.Trim().Length == 0)
            {_P_Str_ID = "0";}
            string _Str_Cadena = "Select * from TDEVCOMPRAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ciddevcomp='" + _P_Str_ID + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "Select cporcinvendible,cpordevmalestado,cnotarecojo from TPROVEEDOR where cproveedor='" + _P_Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim()) > 0)
                        {
                            if (MessageBox.Show("El proveedor no reconoce por mal estado.¿Esta seguro de seleccionar este proveedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                _Rbt_B.Checked = true;
                            }
                            else
                            {
                                _Pnl_Clave.Visible = true;
                            }
                        }
                        else
                        {
                            if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                            {
                                if (Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString().Trim()) > 0)
                                {
                                    _Txt_Reconoce.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                                    _Mtd_Cargar_Motivo();
                                    _Cmb_Motivo.Enabled = true;
                                    _Dg_Grid2.Rows.Clear();
                                    if (_Ds.Tables[0].Rows[0][2].ToString().Trim() == "1")
                                    {
                                        _Grb_Nota.Visible = true;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("El proveedor no reconoce por mal estado.¿Esta seguro de seleccionar este proveedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                    {
                                        _Rbt_B.Checked = true;
                                    }
                                    else
                                    {
                                        _Pnl_Clave.Visible = true;
                                    }
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("El proveedor no reconoce por mal estado.¿Esta seguro de seleccionar este proveedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                {
                                    _Rbt_B.Checked = true;
                                }
                                else
                                {
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
                                _Txt_Reconoce.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                                _Mtd_Cargar_Motivo();
                                _Cmb_Motivo.Enabled = true;
                                _Dg_Grid2.Rows.Clear();
                                if (_Ds.Tables[0].Rows[0][2].ToString().Trim() == "1")
                                {
                                    _Grb_Nota.Visible = true;
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("El proveedor no reconoce por mal estado.¿Esta seguro de seleccionar este proveedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                {
                                    _Rbt_B.Checked = true;
                                }
                                else
                                {
                                    _Pnl_Clave.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("El proveedor no reconoce por mal estado.¿Esta seguro de seleccionar este proveedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                _Rbt_B.Checked = true;
                            }
                            else
                            {
                                _Pnl_Clave.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        private void Frm_Devol2_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Proveedor();
        }

        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Motivo();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Proveedor();
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex != -1)
            {
                _Rbt_B.Enabled = true;
                _Rbt_M.Enabled = true;
                _Rbt_M.Checked = false;
                _Rbt_B.Checked = false;
                _Txt_Reconoce.Text = "";
                _Grb_Nota.Visible = false;
                _Txt_Nota.Text = "";
                _Txt_NRecep.Text = "";
                _Txt_Fact.Text = "";
                _Txt_Reconoce.Text = "";
                _Bt_Buscar.Enabled = false;
                _Chbox_SinFactura.Checked = false;
                _Cmb_Motivo.Enabled = false;
                _Mtd_Cargar_Motivo();
                _Dg_Grid2.Rows.Clear();
            }
            else
            {
                _Rbt_B.Enabled = false;
                _Rbt_M.Enabled = false;
                _Rbt_M.Checked = false;
                _Rbt_B.Checked = false;
                _Txt_Reconoce.Text = "";
                _Grb_Nota.Visible = false;
                _Txt_Nota.Text = "";
                _Txt_NRecep.Text = "";
                _Txt_Fact.Text = "";
                _Txt_Reconoce.Text = "";
                _Bt_Buscar.Enabled = false;
                _Chbox_SinFactura.Checked = false;
                _Cmb_Motivo.Enabled = false;
                _Mtd_Cargar_Motivo();
                _Dg_Grid2.Rows.Clear();
            }
        }

        private void _Rbt_B_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_B.Checked)
            {
                _Txt_Reconoce.Text = "";
                _Mtd_Cargar_Motivo();
                _Grb_Nota.Visible = false;
                _Cmb_Motivo.Enabled = true;
                _Dg_Grid2.Rows.Clear();
            }
        }

        private void _Rbt_M_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_M.Checked)
            {
                _Txt_NRecep.Text = "";
                _Txt_Fact.Text = "";
                _Mtd_VerificarProveedor(_Cmb_Proveedor.SelectedValue.ToString(), _Txt_Numero.Text.Trim());
            }
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_Motivo.SelectedIndex != -1)
            {
                if (_Rbt_B.Checked)
                {
                    _Bt_Buscar.Enabled = true;
                    _Chbox_SinFactura.Checked = false;
                    _Dg_Grid2.Rows.Clear();
                }
                else if (_Rbt_M.Checked)
                {
                    _Bt_Buscar.Enabled = false;
                    _Chbox_SinFactura.Checked = true;
                    _Dg_Grid2.Rows.Clear();
                    _Dg_Grid2.Rows.Add();
                }
            }
            else
            {
                _Bt_Buscar.Enabled = false;
                _Chbox_SinFactura.Checked = false;
                _Dg_Grid2.Rows.Clear();
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            TextBox _Txt_TemporalCod = new TextBox();
            TextBox _Txt_TemporalDes = new TextBox();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(7, _Txt_TemporalCod, _Txt_TemporalDes, 1, 2, _Cmb_Proveedor.SelectedValue.ToString());
            _Frm.ShowDialog();
            //-----------------------------
            if (_Txt_TemporalCod.Text.Trim().Length > 0)
            {
                _Txt_NRecep.Text = _Txt_TemporalCod.Text;
                _Txt_Fact.Text = _Txt_TemporalDes.Text;
                DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cidrecepcion from TNOTARECEPC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidnotrecepc=" + _Txt_NRecep.Text);
                if (_Ds_Data.Tables[0].Rows.Count > 0)
                {
                    _Str_RecepId = Convert.ToString(_Ds_Data.Tables[0].Rows[0][0]);
                    _Dg_Grid2.Rows.Clear();
                    _Dg_Grid2.Rows.Add();
                }
            }
        }

        private void Frm_Devol2_Activated(object sender, EventArgs e)
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
            if (!_Cmb_Proveedor.Enabled & _Cmb_Proveedor.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Numero.Enabled & _Txt_Numero.Text.Trim().Length > 0 & _Cmb_Proveedor.Enabled)
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

        private void Frm_Devol2_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
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
                    _Mtd_Cargar_Motivo();
                    _Cmb_Motivo.Enabled = true;
                    _Dg_Grid2.Rows.Clear();
                    _Pnl_Clave.Visible = false;
                    _Str_Cadena = "Select cnotarecojo from TPROVEEDOR where cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                        {
                            _Grb_Nota.Visible = true;
                        }
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Rbt_B.Checked = true;
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }
       
        private void _Dg_Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                if (e.ColumnIndex == 1 & _Txt_Nota.Visible & _Txt_Nota.Text.Trim().Length == 0)
                {
                    _Er_Error.SetError(_Grb_Nota, "Información Requerida!!!");
                }
                else if (e.ColumnIndex == 1 & _Cmb_Proveedor.Text.Trim().Length > 0 & !_Cmb_Proveedor.Enabled)
                { }
                else if (e.ColumnIndex == 1)
                {
                    TextBox _Txt_TemporalCod = new TextBox();
                    TextBox _Txt_TemporalDes = new TextBox();
                    string _Str_Cadena = "";
                    Cursor = Cursors.WaitCursor;
                    if (_Chbox_SinFactura.Checked)
                    {
                        _Str_Cadena = "SELECT     dbo.TPRODUCTO.cproducto AS Producto, cnamefc as Descripción, CONVERT(numeric(18, 0), " +
                      "(((dbo.TPRODUCTO.cexismmeu1 * dbo.TPRODUCTO.ccontenidoma1 + dbo.TPRODUCTO.cexismmeu2 * dbo.TPRODUCTO.ccontenidoma2)  " +
                      "- CASE WHEN dbo.TNOTAENTREGD.cempaques IS NULL OR " +
                      "CIMPRESA = 1 THEN 0 ELSE TNOTAENTREGD.cempaques END * dbo.TPRODUCTO.ccontenidoma1)  " +
                     " + CASE WHEN dbo.TNOTAENTREGD.cunidades IS NULL OR " +
                     " CIMPRESA = 1 THEN 0 ELSE dbo.TNOTAENTREGD.cunidades END * dbo.TPRODUCTO.ccontenidoma2) / dbo.TPRODUCTO.ccontenidoma1)  " +
                     " AS Cajas, CONVERT(numeric(18, 0), CONVERT(integer,  " +
                     " ((dbo.TPRODUCTO.cexismmeu1 * dbo.TPRODUCTO.ccontenidoma1 + dbo.TPRODUCTO.cexismmeu2 * dbo.TPRODUCTO.ccontenidoma2)  " +
                     " - CASE WHEN dbo.TNOTAENTREGD.cempaques IS NULL OR " +
                     " CIMPRESA = 1 THEN 0 ELSE TNOTAENTREGD.cempaques END * dbo.TPRODUCTO.ccontenidoma1)  " +
                     " + CASE WHEN dbo.TNOTAENTREGD.cunidades IS NULL OR " +
                     " CIMPRESA = 1 THEN 0 ELSE dbo.TNOTAENTREGD.cunidades END * dbo.TPRODUCTO.ccontenidoma2) % CONVERT(integer,  " +
                     " dbo.TPRODUCTO.ccontenidoma1) / dbo.TPRODUCTO.ccontenidoma2) AS Unidades " +                     
"FROM         dbo.TNOTAENTREGM INNER JOIN " +
                     " dbo.TNOTAENTREGD ON dbo.TNOTAENTREGM.cgroupcomp = dbo.TNOTAENTREGD.cgroupcomp AND  " +
                     " dbo.TNOTAENTREGM.ccompany = dbo.TNOTAENTREGD.ccompany AND dbo.TNOTAENTREGM.ciddevcomp = dbo.TNOTAENTREGD.ciddevcomp AND  ";
                        _Str_Cadena += " dbo.TNOTAENTREGM.cidnotentrega = dbo.TNOTAENTREGD.cidnotentrega and TNOTAENTREGM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TNOTAENTREGM.ccompany='" + Frm_Padre._Str_Comp + "' RIGHT OUTER JOIN ";
                        _Str_Cadena += " dbo.TPRODUCTO ON dbo.TNOTAENTREGD.cproducto = dbo.TPRODUCTO.cproducto where TPRODUCTO.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and CONVERT(numeric(18, 0), (((dbo.TPRODUCTO.cexismmeu1 * dbo.TPRODUCTO.ccontenidoma1 + dbo.TPRODUCTO.cexismmeu2 * dbo.TPRODUCTO.ccontenidoma2)  ";
                        _Str_Cadena += " - CASE WHEN dbo.TNOTAENTREGD.cempaques IS NULL OR " +
                     " CIMPRESA = 1 THEN 0 ELSE TNOTAENTREGD.cempaques END * dbo.TPRODUCTO.ccontenidoma1)  " +
                     " + CASE WHEN dbo.TNOTAENTREGD.cunidades IS NULL OR ";
                        _Str_Cadena += " CIMPRESA = 1 THEN 0 ELSE dbo.TNOTAENTREGD.cunidades END * dbo.TPRODUCTO.ccontenidoma2) / dbo.TPRODUCTO.ccontenidoma1)>0 or TPRODUCTO.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and ";
                        _Str_Cadena += "CONVERT(numeric(18, 0), CONVERT(integer,  " +
                      "((dbo.TPRODUCTO.cexismmeu1 * dbo.TPRODUCTO.ccontenidoma1 + dbo.TPRODUCTO.cexismmeu2 * dbo.TPRODUCTO.ccontenidoma2)  " +
                     " - CASE WHEN dbo.TNOTAENTREGD.cempaques IS NULL OR " +
                     " CIMPRESA = 1 THEN 0 ELSE TNOTAENTREGD.cempaques END * dbo.TPRODUCTO.ccontenidoma1)  " +
                     " + CASE WHEN dbo.TNOTAENTREGD.cunidades IS NULL OR " +
                     " CIMPRESA = 1 THEN 0 ELSE dbo.TNOTAENTREGD.cunidades END * dbo.TPRODUCTO.ccontenidoma2) % CONVERT(integer,  " +
                     " dbo.TPRODUCTO.ccontenidoma1) / dbo.TPRODUCTO.ccontenidoma2)>0 ";
                        _Str_Cadena = _Str_Cadena;// +_Mtd_Imp_Selec2(_Str_Cadena);
                        //_Str_Cadena = "Select cproducto as Producto,cnamef as Descripción,cexismmeu1 as Cajas from TPRODUCTO where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cexismmeu1>0" + _Mtd_Imp_Selec(); 
                    }
                    else
                    {
                        _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción, " +
  "empaqrestantes as Cajas,unidadesrestantes as Unidades "+
                        "from VST_RESTANTESRECEP where cproveedor='" + _Cmb_Proveedor.SelectedValue + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Str_RecepId + "' and cnfacturapro='" + _Txt_Fact.Text.Trim() + "'" + _Mtd_Imp_Selec();
                        _Str_Cadena = _Str_Cadena + _Mtd_Imp_Selec2(_Str_Cadena);
                        //_Str_Cadena = "Select cproducto as Producto,cnamef as Descripción,cempaques as Cajas FROM VST_PRODUCTOS_RECEPCIONDFD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cidrecepcion=" + _Str_RecepId + " and cnfacturapro='" + _Txt_Fact.Text + "' AND cproveedor='" + _Cmb_Proveedor.SelectedValue + "'" + _Mtd_Imp_Selec(); 
                    }
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(9, _Txt_TemporalCod, _Txt_TemporalDes, 0, 1, _Str_Cadena);
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Txt_TemporalCod.Text.Trim().Length > 0)
                    {
                        if (_Chbox_SinFactura.Checked)
                        { _Str_Cadena = "Select dbo.Fnc_Formatear(ccostoneto_u1),dbo.Fnc_Formatear(ccostoneto_u1/(ccontenidoma1/ccontenidoma2)) from TPRODUCTO where cproducto='" + _Txt_TemporalCod.Text.Trim() + "'"; }
                        else
                        { _Str_Cadena = "Select dbo.Fnc_Formatear(TRECEPCIONDFD.cpreciouni),dbo.Fnc_Formatear(TRECEPCIONDFD.cpreciouni/(TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))  from TRECEPCIONDFD inner join TPRODUCTO ON TPRODUCTO.cproducto=TRECEPCIONDFD.cproducto WHERE TRECEPCIONDFD.cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND TRECEPCIONDFD.cnfacturapro='" + _Txt_Fact.Text + "' AND TRECEPCIONDFD.cproveedor='" + _Cmb_Proveedor.SelectedValue + "' AND TRECEPCIONDFD.cproducto='" + _Txt_TemporalCod.Text.Trim() + "'"; }
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Txt_TemporalCod.Text.Trim();
                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Txt_TemporalDes.Text.Trim();
                            _Dg_Grid2.Rows[e.RowIndex].Cells[5].Value = _Ds.Tables[0].Rows[0][0].ToString();
                            _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value = _Ds.Tables[0].Rows[0][1].ToString();
                        }
                    }
                }
            }
        }

        private void _Dg_Grid2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                if (e.ColumnIndex == 3 & _Txt_Nota.Visible & _Txt_Nota.Text.Trim().Length == 0)
                {
                    _Dg_Grid2.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                    _Er_Error.SetError(_Grb_Nota, "Información Requerida!!!");
                }
                else if (e.ColumnIndex == 3)
                {
                    if (_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        _Dg_Grid2.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                    }
                    else
                    {
                        _Dg_Grid2.Rows[e.RowIndex].Cells[3].ReadOnly = false;
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
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 3)
            {
                if (!_Mtd_IsNumeric(((TextBox)sender).Text))
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 3)
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }
        private bool _Mtd_ValidarUnd(int _Int_Und, string _Str_Producto)
        {
            int _Int_Pund = 0;
            CLASES._Cls_Varios_Metodos _Cl = new T3.CLASES._Cls_Varios_Metodos(true);
            _Int_Pund=Convert.ToInt32(_Cl._Mtd_ProductoUndManejo2(_Str_Producto));
            if (_Int_Und >= _Int_Pund)
            {
                MessageBox.Show("La cantidad de unidades no puede ser mayor de " + Convert.ToString(_Int_Pund - 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void _Dg_Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int _Int_Und = 0;
                if (_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value.ToString().TrimEnd() != "")
                {
                    _Int_Und = Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                if (_Mtd_ValidarUnd(_Int_Und, _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {

                }
                else
                {
                    _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = "0";
                }
            }
            _Dg_Grid2.Refresh();
            if (_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value != null & _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value != null & (_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value != null | _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value != null))
            {
                if (_Chbox_SinFactura.Checked)
                {
                    string _Str_Cadena = "SELECT cexismmeu1, cexismmeu2 from TPRODUCTO WHERE cproducto='" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "' and cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //----------------------------------
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "SELECT SUM(TNOTAENTREGD.cempaques),SUM(TNOTAENTREGD.cunidades) " +
    "FROM TNOTAENTREGD INNER JOIN " +
    "TNOTAENTREGM ON TNOTAENTREGD.cgroupcomp = TNOTAENTREGM.cgroupcomp AND " +
    "TNOTAENTREGD.ccompany = TNOTAENTREGM.ccompany AND TNOTAENTREGD.ciddevcomp = TNOTAENTREGM.ciddevcomp AND " +
    "TNOTAENTREGD.cidnotentrega = TNOTAENTREGM.cidnotentrega " +
    "WHERE (TNOTAENTREGM.cimpresa = '0') AND (TNOTAENTREGD.cproducto = '" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "') AND (TNOTAENTREGD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTAENTREGD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        int _Int_1 = 0;
                        _Int_1 = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                        int _Int_2 = 0;
                        _Int_2 = Convert.ToInt32(_Ds.Tables[0].Rows[0][1]);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            {
                                _Int_1 = _Int_1 - Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                                if (_Int_1 < 0)
                                {
                                    _Int_1 = 0;
                                }
                            }
                            if (_Ds2.Tables[0].Rows[0][1] != System.DBNull.Value)
                            {
                                _Int_2 = _Int_2 - Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString());
                                if (_Int_2 < 0)
                                {
                                    _Int_2 = 0;
                                }
                            }
                        }
                        if (_Int_1 < Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value))
                        {
                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                            MessageBox.Show("Las cajas no pueden ser mayores a la existencia actual. Existencia actual: " + _Int_1.ToString() + " Cajas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (_Int_2 < Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value))
                            {
                                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
                                MessageBox.Show("Las unidades no pueden ser mayores a la existencia actual. Existencia actual: " + _Int_2.ToString() + " Unidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
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
                else
                {
                    string _Str_Cadena = "SELECT cempaques,cunidades from TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion=" + _Str_RecepId + " AND cnfacturapro='" + _Txt_Fact.Text + "' AND cproducto='" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "' and cproveedor='" + _Cmb_Proveedor.SelectedValue + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    //----------------------------------
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "SELECT SUM(TNOTAENTREGD.cempaques),SUM(TNOTAENTREGD.cunidades) " +
    "FROM TNOTAENTREGD INNER JOIN " +
    "TNOTAENTREGM ON TNOTAENTREGD.cgroupcomp = TNOTAENTREGM.cgroupcomp AND " +
    "TNOTAENTREGD.ccompany = TNOTAENTREGM.ccompany AND TNOTAENTREGD.ciddevcomp = TNOTAENTREGM.ciddevcomp AND " +
    "TNOTAENTREGD.cidnotentrega = TNOTAENTREGM.cidnotentrega " +
    "WHERE (TNOTAENTREGM.cimpresa = '0') AND (TNOTAENTREGD.cproducto = '" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "') AND (TNOTAENTREGD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTAENTREGD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        int _Int_2 = 0;
                        int _Int_1 = 0;
                        _Int_1 = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                        _Int_2 = Convert.ToInt32(_Ds.Tables[0].Rows[0][1]);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            {
                                _Int_1 = _Int_1 - Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                                if (_Int_1 < 0)
                                {
                                    _Int_1 = 0;
                                }
                            }
                            if (_Ds2.Tables[0].Rows[0][1] != System.DBNull.Value)
                            {
                                _Int_2 = _Int_2 - Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString());
                                if (_Int_2 < 0)
                                {
                                    _Int_2 = 0;
                                }
                            }
                        }
                        if (_Int_1 < Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[3].Value))
                        {
                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                            MessageBox.Show("La cantidad de cajas no puede ser mayor a las cajas que contiene la factura. Nº de Cajas: " + _Int_1.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
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
        }

        private void _Txt_Nota_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Er_Error.Dispose();
            _Mtd_Deshabilitar_Todo();
            _Txt_Numero.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
            _Txt_Fecha.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
            _Cmb_Proveedor.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex);
            if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(11, e.RowIndex).Trim() == "B")
            { _Rbt_B.Checked = true; }
            else
            { _Rbt_M.Checked = true; }
            _Txt_Reconoce.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(12, e.RowIndex);
            if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(13, e.RowIndex).Length > 0)
            { _Grb_Nota.Visible = true; _Txt_Nota.Text = _Dg_Grid.Rows[e.RowIndex].Cells[13].Value.ToString().Trim(); }
            _Cmb_Motivo.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(10, e.RowIndex);
            _Txt_NRecep.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
            _Txt_Fact.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex);
            _Txt_Cajas.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex);
            _Txt_Und.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex);
            _Txt_Costo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(7, e.RowIndex);
            string _Str_Cadena = "Select cproducto,(Select top 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END from TPRODUCTO INNER JOIN dbo.TMARCASM ON dbo.TPRODUCTO.cmarca = dbo.TMARCASM.cmarca where TPRODUCTO.cproducto=TDEVCOMPRAD.cproducto) as cnamef,ccajas,cunidades,ccostoxcaj,ccostoxund,ccostotot from TDEVCOMPRAD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ciddevcomp='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Obj = new object[8];
            _Dg_Grid2.Rows.Clear();
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Obj[0] = _Row[0].ToString();
                _Obj[1] = "";
                _Obj[2] = _Row[1].ToString();
                _Obj[3] = _Row[2].ToString();
                _Obj[4] = _Row[3].ToString();
                _Obj[5] = _Row[4].ToString();
                _Obj[6] = _Row[5].ToString();
                _Obj[7] = _Row[6].ToString();
                _Dg_Grid2.Rows.Add(_Obj);
            }
            _Rbt_B.Enabled = false;
            _Rbt_M.Enabled = false;
            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Motivo.Enabled = false;
            _Txt_Nota.Enabled = false;
        }

        private void _Grb_Nota_VisibleChanged(object sender, EventArgs e)
        {
            if (_Grb_Nota.Visible)
            { _Txt_Nota.Enabled = true; }
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
                if (_Str_MyProceso.Length == 0 & !_Cmb_Proveedor.Enabled)
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
                if (!_Cmb_Proveedor.Enabled & _Txt_Numero.Text.Trim().Length == 0)
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