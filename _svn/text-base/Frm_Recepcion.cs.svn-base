using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Recepcion : Form
    {
        private CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        private clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        public Frm_Recepcion()
        {
            InitializeComponent();
        }

        private bool _Bol_Menu = false;

        public Frm_Recepcion(bool _P_Bol_Menu)
        {
            InitializeComponent();
            _Bol_Menu = true;
        }

        //PARA UTILIZAR EN EL _Mtd_Leer*************************
        private string _Str_CodProd, _Str_CodFab;
        //******************************************************
        private Control[] _Ctrl_Controles = new Control[9];

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Actualizar();
            _Mtd_Sorted();
            _Mtd_Cargar();
            _Dpt_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Pnl_Feha.Left = (this.Width / 2) - (_Pnl_Feha.Width / 2);
            _Pnl_Feha.Top = (this.Height / 2) - (_Pnl_Feha.Height / 2);
            _Pnl_Productos.Left = (this.Width / 2) - (_Pnl_Productos.Width / 2);
            _Pnl_Productos.Top = (this.Height / 2) - (_Pnl_Productos.Height / 2);
            _Pnl_ProductosInactivos.Left = (this.Width / 2) - (_Pnl_ProductosInactivos.Width / 2);
            _Pnl_ProductosInactivos.Top = (this.Height / 2) - (_Pnl_ProductosInactivos.Height / 2);
            _Mtd_Color_Estandar(this);
        }

        private string _Str_Proveedor = "";

        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                if (_Ctrl.Name != _Mtc_Calendar.Name)
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }

        public void _Mtd_Actualizar()
        {
            string _Str_Cadena = "";
            if (_Bol_Menu)
            {
                _Str_Cadena = "Select cidrecepcion,cdate,c_nomb_abreviado,cplaca,ccargfactura,cdescargo,cnotarecepcion,ccerrada,cproveedor FROM vst_vistarecepcion where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccerrada='0'";
            }
            else
            {
                _Str_Cadena = "Select cidrecepcion,cdate,c_nomb_abreviado,cplaca,ccargfactura,cdescargo,cnotarecepcion,ccerrada,cproveedor FROM vst_vistarecepcion where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccerrada='0' and cevaluado='1'";
            }
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds_Data.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public void _Mtd_Entrada()
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidrecepcion FROM TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cidrecepcion  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                _Txt_Recep.Text = Convert.ToString(Convert.ToInt32(_Obj_f[0].ToString()) + 1);

            }
            catch
            {
                _Txt_Recep.Text = "1";
            }
        }

        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Recepcion_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            if (!_Bol_Menu)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            if (_Txt_Placa.Enabled & _Bol_Menu)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void _Mtd_Cargar()
        {
            _Cbox_Pro.DataSource = null;
            string _Str_Sql = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado  FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY TPROVEEDOR.c_nomb_abreviado ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Cbox_Pro.DataSource = _Ds.Tables[0];
            _Cbox_Pro.SelectedIndexChanged -= new EventHandler(_Cbox_Pro_SelectedIndexChanged);
            _Cbox_Pro.DisplayMember = "c_nomb_abreviado";
            _Cbox_Pro.ValueMember = "cproveedor";
            _Cbox_Pro.SelectedIndexChanged += new EventHandler(_Cbox_Pro_SelectedIndexChanged);
            _Cbox_Pro.SelectedIndex = -1;
        }


        private void _Cbox_Pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cbox_Pro.DataSource != null)
            {
                if (_Cbox_Pro.SelectedIndex != -1)
                {
                    try
                    {
                        _Txt_Proveedor.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select c_nomb_abreviado from TPROVEEDOR where cproveedor='" + _Cbox_Pro.SelectedValue.ToString() + "' and cdelete='0'").Tables[0].Rows[0][0].ToString();
                    }
                    catch
                    {
                    }
                }
                else
                {
                    _Txt_Proveedor.Text = "";
                }
            }
            else
            {
                _Txt_Proveedor.Text = "";
            }
        }

        private void _Txt_User_EnabledChanged(object sender, EventArgs e)
        {
            if (_Txt_User.Enabled)
            {
                _Txt_UserDes.Enabled = true;
            }
            else
            {
                _Txt_UserDes.Enabled = false;
            }
        }

        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }

        public void _Mtd_Ini()
        {
            _Txt_Obs.Text = "";
            _Txt_Placa.Text = "";
            _Txt_User.Text = "";
            _Txt_UserDes.Text = "";
            _Txt_Recep.Text = "";
            _Txt_Proveedor.Text = "";
            _Mtd_Cargar();
            _Dpt_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Cmb_Fac.Items.Clear();
            _Txt_rec2.Text = "";
            _Dg_Estatus.Rows.Clear();
        }

        public void _Mtd_Habilitar_Todo()
        {
            _Txt_Obs.Enabled = true;
            _Txt_Placa.Enabled = true;
            _Txt_Recep.Enabled = true;
            _Dpt_Fecha.Enabled = true;
            _Cbox_Pro.Enabled = true;
        }

        public void _Mtd_Habilitar()
        {
            _Txt_Obs.Enabled = true;
            _Txt_Placa.Enabled = false;
            _Txt_Recep.Enabled = false;
            _Dpt_Fecha.Enabled = true;
            _Cbox_Pro.Enabled = false;
        }

        public void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Obs.Enabled = false;
            _Txt_Placa.Enabled = false;
            _Txt_Recep.Enabled = false;
            _Dpt_Fecha.Enabled = false;
            _Cbox_Pro.Enabled = false;
        }

        public void _Mtd_Deshabilitar()
        {
            _Txt_Obs.Enabled = false;
            _Txt_Placa.Enabled = false;
            _Txt_Recep.Enabled = false;
            _Dpt_Fecha.Enabled = false;
            _Cbox_Pro.Enabled = false;
        }

        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Mtd_Habilitar_Todo();
            _Mtd_Cargar();
            _Tb_Tab.SelectedIndex = 2;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cname from TUSER where cuser='" + Frm_Padre._Str_Use + "' and cdelete='0'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_User.Text = Frm_Padre._Str_Use.ToUpper();
                _Txt_UserDes.Text = _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
        }

        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {

        }

        private void _Cbox_OC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool _Mtd_Guardar()
        {
            if (_Txt_Placa.Text.Trim().Length > 0 & _Cbox_Pro.SelectedIndex != -1)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    _Mtd_Entrada();
                    Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TRECEPCIONM", "cgroupcomp,cidrecepcion,cproveedor,cdate,cplaca,cobservacion,cuserrecibe,cdatosiniciales", "'" + Frm_Padre._Str_GroupComp + "','" + _Txt_Recep.Text + "','" + _Cbox_Pro.SelectedValue.ToString() + "','" + _Cls_Formato._Mtd_fecha(_Dpt_Fecha.Value).ToString() + "','" + _Txt_Placa.Text.ToUpper().Trim() + "','" + _Txt_Obs.Text.ToUpper() + "','" + _Txt_User.Text + "','1'");
                    //-----------------------------
                    _Txt_Proveedor.Text = _Cbox_Pro.SelectedItem.ToString();
                    //-----------------------------
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Deshabilitar_Todo();
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                    _Mtd_Ini();
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    return true;
                }
            }
            else
            {
                if (_Txt_Placa.Text.Trim().Length < 1)
                {
                    _Er_Error.SetError(_Txt_Placa, "Información requerida!!!");
                }
                if (_Cbox_Pro.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cbox_Pro, "Información requerida!!!");
                }
                return false;
            }

        }

        public bool _Mtd_Editar()
        {
            if (_Txt_Placa.Text.Trim().Length > 0 & _Txt_Recep.Text.Trim().Length > 0 & _Cbox_Pro.SelectedValue.ToString() != "nulo")
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "',cidrecepcion='" + _Txt_Recep.Text + "',cproveedor='" + _Cbox_Pro.SelectedValue.ToString() + "',cdate='" + _Cls_Formato._Mtd_fecha(_Dpt_Fecha.Value).ToString() + "',cplaca='" + _Txt_Placa.Text + "',cobservacion='" + _Txt_Obs.Text + "',cuserrecibe='" + _Txt_User.Text + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "' and cproveedor='" + _Cbox_Pro.SelectedValue.ToString() + "'");
                    MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Deshabilitar_Todo();
                    _Mtd_Actualizar();
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Placa.Text.Trim().Length < 1)
                {
                    _Er_Error.SetError(_Txt_Placa, "Información requerida!!!");
                }
                if (_Txt_Recep.Text.Trim().Length < 1)
                {
                    _Er_Error.SetError(_Txt_Recep, "Información requerida!!!");
                }
                if (_Cbox_Pro.SelectedValue.ToString() == "nulo")
                {
                    _Er_Error.SetError(_Cbox_Pro, "Información requerida!!!");
                }
                return false;
            }
        }

        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("Delete from TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "'");
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Deshabilitar_Todo();
                _Mtd_Ini();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Mtd_Ini();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            decimal retNum;

            isNum = decimal.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private int _Int_RowIndex = 0;

        private void _Bt_Conti_Click(object sender, EventArgs e)
        {
            if (_Mtd_Guardar())
            {
                _Tb_Tab.SelectedIndex = 2;
            }
        }

        private void Frm_Recepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        //NUEVOOOOOOOOOOOOOOOOOOOO******************************************************
        private void _Mtd_DescargaFactCargar(string _P_Str_cproveedor)
        {
            try
            {
                string _Str_Sql;
                string _Str_Comp = _Mtd_CompProveedor(_P_Str_cproveedor);
                _Str_Sql = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Recep.Text + "' and cproveedor='" + _P_Str_cproveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Cmb_Fac.Items.Clear();
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Sql = "Select cnumdocu from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnumdocu='" + _Row[0].ToString() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count == 0)
                    {
                        _Cmb_Fac.Items.Add(_Row[0].ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private bool _Mtd_DescargarSioNo()
        {
            string _Str_Sql;
            _Str_Sql = "SELECT ccargfactura FROM TRECEPCIONM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion=" + _Txt_Recep.Text + " AND cproveedor='" + _Str_Proveedor + "' AND cdatosiniciales=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _Mtd_ProductosInactivosFactura(string _P_Str_IdRecepcion, string _P_Str_Factura, string _P_Str_Proveedor)
        {
            bool _Bol_ValidoInactivoFactura = true;
            try
            {
                _Dg_ProductosInactivos.Rows.Clear();
                string _Str_SQL = "SELECT CPRODUCTO FROM TRECEPCIONDFD WHERE EXISTS(SELECT CPRODUCTO FROM TPRODUCTO WHERE TPRODUCTO.CPRODUCTO=TRECEPCIONDFD.CPRODUCTO AND TPRODUCTO.CACTIVATE='0') AND CIDRECEPCION='" + _P_Str_IdRecepcion + "' AND CNFACTURAPRO='" + _P_Str_Factura + "' AND CPROVEEDOR='" + _P_Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Bol_ValidoInactivoFactura = false;
                    object[] _Ob = new object[2];
                    foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                    {
                        _Ob[0] = _Dtw_Item["cproducto"].ToString().Trim();
                        _Ob[1] = _Mtd_RetornarInfProducto(_Dtw_Item["cproducto"].ToString().Trim(), "cnamefc");
                        _Dg_ProductosInactivos.Rows.Add(_Ob);
                    }
                    _Pnl_ProductosInactivos.Visible = true;
                }
                _Dg_ProductosInactivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
            return _Bol_ValidoInactivoFactura;
        }

        private void _Bt_Descarga_Click(object sender, EventArgs e)
        {
            if (_Cmb_Fac.SelectedIndex != -1)
            {
                string _Str_Cadena = "Select cevaluado from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text.Trim() + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string _Str_Sql = "SELECT cproducto AS [Cod Producto],(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_RECEPCIONDD.cproducto) AS Producto,cempaques AS Empaques, cunidades as Unidades FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select * from TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccargfactura='1'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            bool _Bol_Aux = false;
                            if (_Txt_Proveedor.Text == "")
                            {
                                _Er_Error.SetError(_Txt_Proveedor, "Se Necesita este valor");
                                _Bol_Aux = true;
                            }
                            if (_Cmb_Fac.Text == "")
                            {
                                _Er_Error.SetError(_Cmb_Fac, "Se Necesita este valor");
                                _Bol_Aux = true;
                            }
                            if (_Bol_Aux == false)
                            {
                                if (_Mtd_DescargarSioNo())
                                {
                                    //Validamos que la factura no tenga productos inactivos
                                    bool _Bol_ValidoInac = _Mtd_ProductosInactivosFactura(_Txt_rec2.Text.Trim(), _Cmb_Fac.SelectedItem.ToString(), _Str_Proveedor);
                                    if (_Bol_ValidoInac)
                                    {
                                        //Cargamos los datos
                                        _Mtd_Descargar();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Faltan Datos Iniciales de la Recepción", "IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existen facturas cargadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta descarga ya ha sido realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("La factura no ha sido evaluada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Los datos para realizar esta operación no estan completos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataSet _Ds_Tabla = new DataSet();
        private bool _Bol_Error = false;

        private void _Mtd_Crear_Tabla_Temporal()
        {
            _Ds_Tabla = new DataSet();
            _Ds_Tabla.Tables.Add("Tabla");
            _Ds_Tabla.Tables["Tabla"].Columns.Add("cproducto");
            _Ds_Tabla.Tables["Tabla"].Columns.Add("ccodfabrica");
            _Ds_Tabla.Tables["Tabla"].Columns.Add("cempaques");
            _Ds_Tabla.Tables["Tabla"].Columns.Add("cunidades");
        }

        private void _Mtd_Llenar_Tabla(string _P_Str_cproducto, string _P_Str_ccodfabrica, string _P_Str_cempaques, string _P_Str_cunidades)
        {
            _Ds_Tabla.Tables["Tabla"].Rows.Add(new object[] { _P_Str_cproducto, _P_Str_ccodfabrica, _P_Str_cempaques, _P_Str_cunidades });
        }

        private int _Mtd_Extraer_Empaques(string _P_Str_Producto, int _P_Int_Empaques, string _P_Str_Factura)
        {
            string _Str_Cadena = "Select csolocant from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _P_Str_Factura + "' and cproducto='" + _P_Str_Producto + "' and cproveedor='" + _Str_Proveedor + "' and crechazarcaj<>'0'";
            int _Int_Solo = 0;
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                DataRow _Row_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                if (_Row_[0] != System.DBNull.Value)
                {
                    _Int_Solo = Convert.ToInt32(_Row_[0].ToString().Trim());
                }
                if (_P_Int_Empaques > _Int_Solo)
                {
                    _Bol_Error = true;
                }
                else if (_P_Int_Empaques < _Int_Solo)
                {
                    _Bol_Error = true;
                }
                return _P_Int_Empaques;
            }
            else
            {
                _Str_Cadena = "Select cempaques from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _P_Str_Factura + "' and cproducto='" + _P_Str_Producto + "' and cproveedor='" + _Str_Proveedor + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    DataRow _Row_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                    if (_Row_[0] != System.DBNull.Value)
                    {
                        _Int_Solo = Convert.ToInt32(_Row_[0].ToString().Trim());
                    }
                    if (_P_Int_Empaques > _Int_Solo)
                    {
                        _Bol_Error = true;
                    }
                }
                return _P_Int_Empaques;
            }
        }

        private int _Mtd_Extraer_Unidades(string _P_Str_Producto, int _P_Int_Unidades, string _P_Str_Factura)
        {
            string _Str_Cadena = "Select csolocantuni from TRECEPCIONDDDOCF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _P_Str_Factura + "' and cproducto='" + _P_Str_Producto + "' and cproveedor='" + _Str_Proveedor + "' and crechazarcaj<>'0'";
            int _Int_Solo = 0;
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                DataRow _Row_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                if (_Row_[0] != System.DBNull.Value)
                {
                    _Int_Solo = Convert.ToInt32(_Row_[0].ToString().Trim());
                }
                if (_P_Int_Unidades > _Int_Solo)
                {
                    _Bol_Error = true;
                }
                else if (_P_Int_Unidades < _Int_Solo)
                {
                    _Bol_Error = true;
                }
                return _P_Int_Unidades;
            }
            else
            {
                _Str_Cadena = "Select cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _P_Str_Factura + "' and cproducto='" + _P_Str_Producto + "' and cproveedor='" + _Str_Proveedor + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    DataRow _Row_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                    if (_Row_[0] != System.DBNull.Value)
                    {
                        _Int_Solo = Convert.ToInt32(_Row_[0].ToString().Trim());
                    }
                    if (_P_Int_Unidades > _Int_Solo)
                    {
                        _Bol_Error = true;
                    }
                }
                return _P_Int_Unidades;
            }
        }

        private void _Mtd_Guardar_Ascii()
        {
            foreach (DataRow _Row in _Ds_Tabla.Tables[0].Rows)
            {
                string _Str_Prod = _Row["cproducto"].ToString();
                string _Str_Fab = _Row["ccodfabrica"].ToString();
                decimal _Dcm_ccostobrutolote = 0;
                decimal _Dcm_cprecioventamax = 0;
                decimal _Dcm_cpreciolista = 0;
                _Mtd_ObtenerCostoBrtuoyPrecioMax(_Txt_rec2.Text.Trim(), _Cmb_Fac.SelectedItem.ToString(), _Str_Prod.Trim(), ref _Dcm_ccostobrutolote, ref _Dcm_cprecioventamax, ref _Dcm_cpreciolista);
                string _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cunidades,cproveedor,ccostobrutolote,cprecioventamax,cpreciolista) VALUES(";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + ",'" + _Txt_rec2.Text.Trim() + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + _Str_Prod + "','" + _Str_Fab + "'," + _Row["cempaques"].ToString().Trim() + "," + _Row["cunidades"].ToString().Trim() + ",'" + _Str_Proveedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cpreciolista) + "')";
                try
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "cdescargo='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cproveedor='" + _Str_Proveedor + "'");
                }
                catch
                {
                }
            }
        }

        //public void _Mtd_Leer(string archi)
        //{
        //    _Mtd_Crear_Tabla_Temporal();
        //    _Bol_Error = false;
        //    StreamReader objReader = new StreamReader(archi);
        //    string _Str_Sql = "";
        //    string sLine = "";
        //    char[] delimiterChars = { ';' };
        //    DataSet  _Ds_Aux;
        //    while (sLine != null)
        //    {
        //        sLine = objReader.ReadLine();
        //        if (sLine != null)
        //        {
        //            string[] words = sLine.Split(delimiterChars);
        //            if (words.Length == 6)
        //            {
        //                if (_Txt_rec2.Text == words[0] & _Cmb_Fac.SelectedItem.ToString() == words[1] & _Txt_Placa.Text == words[2])
        //                {
        //                    _Str_Sql = "SELECT cproducto,ccodfabrica FROM TPRODUCTO WHERE cproveedor=" + _Str_Proveedor + " AND ccodcorrugado='" + words[3] + "' AND CACTIVATE='1'";
        //                    _Ds_Aux = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
        //                a:
        //                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 1)
        //                    {
        //                        if (MessageBox.Show("Se ha encontrado duplicidad del corrugado " + words[3] + ". ¿Desea seleccionar el producto manualmente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
        //                        {
        //                        c:
        //                            TextBox _Txt_Codigo = new TextBox();
        //                            TextBox _Txt_Codigo2 = new TextBox();
        //                            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
        //                            _Tsm_Menu[0] = new ToolStripMenuItem("Producto");
        //                            _Tsm_Menu[1] = new ToolStripMenuItem("Cod.Fabric");
        //                            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
        //                            string[] _Str_Campos = new string[3];
        //                            _Str_Campos[0] = "cproducto";
        //                            _Str_Campos[1] = "ccodfabrica";
        //                            _Str_Campos[2] = "cnamef";
        //                            string _Str_Cadena = "SELECT cproducto as Producto,ccodfabrica as [Cod.Fabric],CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as Descripción FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE tproducto.cproveedor=" + _Str_Proveedor + " AND tproducto.ccodcorrugado='" + words[3] + "' AND tproducto.CACTIVATE='1'";
        //                            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Codigo, _Txt_Codigo2, _Str_Cadena, _Str_Campos, "Duplicidad de corrugado", _Tsm_Menu, 0, 1);
        //                            _Frm.ShowDialog();
        //                            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Codigo2.Text.Trim().Length > 0)
        //                            {
        //                                _Str_CodProd = _Txt_Codigo.Text.Trim();
        //                                _Str_CodFab = _Txt_Codigo2.Text.Trim();
        //                                if (_Ds_Tabla.Tables[0].Select("cproducto='" + _Str_CodProd + "'").Length == 0)
        //                                { _Mtd_Llenar_Tabla(_Str_CodProd, _Str_CodFab, _Mtd_Extraer_Empaques(_Str_CodProd, Convert.ToInt32(words[4].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString(), _Mtd_Extraer_Unidades(_Str_CodProd, Convert.ToInt32(words[5].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString()); }
        //                                else
        //                                { MessageBox.Show("El producto con el código " + _Str_CodProd + " ya fue registrado, seleccione correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning); goto c; }
        //                            }
        //                            else
        //                            { goto a; }
        //                        }
        //                        else
        //                        {
        //                            goto b;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (_Ds_Aux.Tables[0].Rows.Count > 0)
        //                        {
        //                            _Str_CodProd = _Ds_Aux.Tables[0].Rows[0][0].ToString();
        //                            _Str_CodFab = _Ds_Aux.Tables[0].Rows[0][1].ToString();
        //                            _Mtd_Llenar_Tabla(_Str_CodProd, _Str_CodFab, _Mtd_Extraer_Empaques(_Str_CodProd, Convert.ToInt32(words[4].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString(), _Mtd_Extraer_Unidades(_Str_CodProd, Convert.ToInt32(words[5].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString());
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    objReader.Close();
        //    if (_Bol_Error)
        //    {
        //        Frm_Vista_Ascii _Frm = new Frm_Vista_Ascii(_Txt_rec2.Text.Trim(), _Cmb_Fac.SelectedItem.ToString(), _Str_Proveedor, _Ds_Tabla);
        //        _Frm.ShowDialog();
        //    }
        //    else
        //    {
        //        _Mtd_Guardar_Ascii();
        //    }
        //    _Str_Sql = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,cnamefc AS Producto,cempaques AS Empaques, cunidades as Unidades,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "' and cproveedor='" + _Str_Proveedor + "'";
        //    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
        //    _Mtd_Readonly(_Str_Sql);
        //    _Dg_Descarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        //    if (_Ds.Tables[0].Rows.Count == 0)
        //    { MessageBox.Show("El ascii seleccionado no corresponde con la recepcion o no contiene estructura de código correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //b: ;
        //}

        public void _Mtd_Descargar()
        {
            _Mtd_Crear_Tabla_Temporal();
            _Bol_Error = false;
            string _Str_Sql = "";
            DataSet _Ds_Aux;

            //Obtenemos lo valores de trabajo
            string strCidRecepcion = _Txt_rec2.Text.Trim();
            string strCnFacturaPro = _Cmb_Fac.SelectedItem.ToString();
            string strCPlaca = _Txt_Placa.Text.ToUpper().Trim();

            //Generamos la Consulta
            var _Str_SentenciaSQL = "Select cidrecepcion,cnfacturapro,'" + strCPlaca + "' as cplaca,cproducto,ccodcorrugado,cempaques,cunidades,cnamefc as cnamef,ccodfabrica from VST_DESCARGAFACTURA where cidrecepcion='" + strCidRecepcion + "' and cnfacturapro='" + strCnFacturaPro + "'";

            //Cargamos los datos desde la consulta
            DataSet _DsAntesAscii = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);

            //Verificamos
            if (_DsAntesAscii.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < _DsAntesAscii.Tables[0].Rows.Count; i++)
                {
                    //Obtengo la Fila actual
                    DataRow oFila = _DsAntesAscii.Tables[0].Rows[i];

                    //Consulto si existe un producto con el ccodcorrugado 
                    _Str_Sql = "SELECT cproducto,ccodfabrica FROM TPRODUCTO WHERE cproveedor=" + _Str_Proveedor + " AND ccodcorrugado='" + oFila["ccodcorrugado"].ToString() + "' AND CACTIVATE='1'";
                    _Ds_Aux = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

                a: //Si existe el corrugado
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 1)
                    {
                        if (MessageBox.Show("Se ha encontrado duplicidad del corrugado " + oFila["ccodcorrugado"].ToString() + ". ¿Desea seleccionar el producto manualmente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                        c: //Si desea seleccionar el producto manualmente
                            TextBox _Txt_Codigo = new TextBox();
                            TextBox _Txt_Codigo2 = new TextBox();
                            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
                            _Tsm_Menu[0] = new ToolStripMenuItem("Producto");
                            _Tsm_Menu[1] = new ToolStripMenuItem("Cod.Fabric");
                            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
                            string[] _Str_Campos = new string[3];
                            _Str_Campos[0] = "cproducto";
                            _Str_Campos[1] = "ccodfabrica";
                            _Str_Campos[2] = "cnamef";
                            string _Str_Cadena = "SELECT cproducto as Producto,ccodfabrica as [Cod.Fabric],CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as Descripción FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE tproducto.cproveedor=" + _Str_Proveedor + " AND tproducto.ccodcorrugado='" + oFila["ccodcorrugado"].ToString() + "' AND tproducto.CACTIVATE='1'";
                            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Codigo, _Txt_Codigo2, _Str_Cadena, _Str_Campos, "Duplicidad de corrugado", _Tsm_Menu, 0, 1);
                            _Frm.ShowDialog();
                            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Codigo2.Text.Trim().Length > 0)
                            {
                                _Str_CodProd = _Txt_Codigo.Text.Trim();
                                _Str_CodFab = _Txt_Codigo2.Text.Trim();
                                if (_Ds_Tabla.Tables[0].Select("cproducto='" + _Str_CodProd + "'").Length == 0)
                                {
                                    _Mtd_Llenar_Tabla(_Str_CodProd, _Str_CodFab, _Mtd_Extraer_Empaques(_Str_CodProd, Convert.ToInt32(oFila["cempaques"].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString(), _Mtd_Extraer_Unidades(_Str_CodProd, Convert.ToInt32(oFila["cunidades"].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString());
                                }
                                else
                                {
                                    MessageBox.Show("El producto con el código " + _Str_CodProd + " ya fue registrado, seleccione correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    goto c;
                                }
                            }
                            else
                            {
                                goto a;
                            }
                        }
                        else
                        {
                            goto b;
                        }
                    }
                    else
                    {
                        if (_Ds_Aux.Tables[0].Rows.Count > 0)
                        {
                            _Str_CodProd = _Ds_Aux.Tables[0].Rows[0][0].ToString();
                            _Str_CodFab = _Ds_Aux.Tables[0].Rows[0][1].ToString();
                            _Mtd_Llenar_Tabla(_Str_CodProd, _Str_CodFab, _Mtd_Extraer_Empaques(_Str_CodProd, Convert.ToInt32(oFila["cempaques"].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString(), _Mtd_Extraer_Unidades(_Str_CodProd, Convert.ToInt32(oFila["cunidades"].ToString()), _Cmb_Fac.SelectedItem.ToString()).ToString());
                        }
                    }

                }
            }
            //Guardo el ascii
            _Mtd_Guardar_Ascii();

            //Cargo el grid
            _Str_Sql = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,cnamefc AS Producto,cempaques AS Empaques, cunidades as Unidades,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "' and cproveedor='" + _Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Mtd_Readonly(_Str_Sql);
            _Dg_Descarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            ////Verifico si la cargaron detalles sino asumo que no hay correspondencia
        //if (_Ds.Tables[0].Rows.Count == 0)
        //{ MessageBox.Show("El ascii seleccionado no corresponde con la recepcion o no contiene estructura de código correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        b:
            ;
        }


        private void _Mtd_ObtenerCostoBrtuoyPrecioMax(string _P_Str_Producto, ref decimal _P_Dcm_ccostobrutolote, ref decimal _P_Dcm_cprecioventamax, ref decimal _P_Dcm_cpreciolista)
        {
            string _Str_Cadena = "SELECT TPRODUCTO.ccostobruto_u1 AS ccostobrutolote,TPRODUCTO.cpreciolista AS cpreciolista FROM TPRODUCTO WHERE TPRODUCTO.cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Dcm_ccostobrutolote == 0)
                {
                    _P_Dcm_ccostobrutolote = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccostobrutolote"]);
                }
                if (_P_Dcm_cpreciolista == 0)
                {
                    _P_Dcm_cpreciolista = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cpreciolista"]);
                }
            }
        }

        private void _Mtd_ObtenerCostoBrtuoyPrecioMax(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Producto, ref decimal _P_Dcm_ccostobrutolote, ref decimal _P_Dcm_cprecioventamax, ref decimal _P_Dcm_cpreciolista)
        {
            string _Str_Cadena = "SELECT ISNULL(ccostobrutolote,0) AS ccostobrutolote, ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista FROM TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _P_Dcm_ccostobrutolote = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccostobrutolote"]);
                _P_Dcm_cprecioventamax = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cprecioventamax"]);
                _P_Dcm_cpreciolista = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cpreciolista"]);
            }
            else
            {
                _Str_Cadena = "SELECT TPRODUCTO.ccostobruto_u1 AS ccostobrutolote,TPRODUCTO.cpreciolista AS cpreciolista FROM TPRODUCTO WHERE TPRODUCTO.cproducto='" + _P_Str_Producto + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_P_Dcm_ccostobrutolote == 0)
                    {
                        _P_Dcm_ccostobrutolote = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccostobrutolote"]);
                    }
                    if (_P_Dcm_cpreciolista == 0)
                    {
                        _P_Dcm_cpreciolista = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cpreciolista"]);
                    }
                }
            }
        }

        private void _Mtd_Readonly(string _P_Str_Cadena)
        {
            _Dg_Descarga.Rows.Clear();
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
            object[] _Obj = new object[9];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Obj[0] = _Row[0].ToString();
                _Obj[1] = _Row[1].ToString();
                _Obj[2] = _Row[2].ToString();
                _Obj[3] = _Row[3].ToString();
                _Obj[4] = _Row[4].ToString();
                _Obj[5] = _Row[5].ToString();
                _Obj[6] = _Row[6].ToString();
                _Obj[7] = _Row[7].ToString();
                _Obj[8] = _Row[8].ToString();
                _Dg_Descarga.Rows.Add(_Obj);
                decimal _Dcm_ccostobrutolote = 0;
                decimal _Dcm_cprecioventamax = 0;
                decimal _Dcm_cpreciolista = 0;
                decimal.TryParse(Convert.ToString(_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["ccostobrutolote"].Value).Trim(), out _Dcm_ccostobrutolote);
                decimal.TryParse(Convert.ToString(_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cprecioventamax"].Value).Trim(), out _Dcm_cprecioventamax);
                decimal.TryParse(Convert.ToString(_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cpreciolista"].Value).Trim(), out _Dcm_cpreciolista);
                //_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["ccostobrutolote"].ReadOnly = _Dcm_ccostobrutolote > 0;
                _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cprecioventamax"].ReadOnly = true;
                if (_Mtd_ProductoRechazadoPorPMVDif(Convert.ToString(_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["ProductoInterno"].Value).Trim()))
                {
                    _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].ReadOnly = true;
                    _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cempaques"].Value = "0";
                    _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cunidades"].Value = "0";
                    _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].DefaultCellStyle.BackColor = Color.Red;
                }
                //_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cpreciolista"].ReadOnly = _Dcm_cpreciolista > 0;
                //if (_Dcm_ccostobrutolote == 0 && _Dcm_cprecioventamax == 0 && _Dcm_cpreciolista == 0) //Cambiando en SPRINT 16
                if (_Dcm_ccostobrutolote == 0 && _Dcm_cprecioventamax != 0 && _Dcm_cpreciolista == 0)
                {
                    _Mtd_ObtenerCostoBrtuoyPrecioMax(_Row[0].ToString(), ref _Dcm_ccostobrutolote, ref _Dcm_cprecioventamax, ref _Dcm_cpreciolista);
                    _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["ccostobrutolote"].Value = _Dcm_ccostobrutolote;
                    //_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cprecioventamax"].Value = _Dcm_cprecioventamax; //Eliminado en SPRINT 16
                    _Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cpreciolista"].Value = _Dcm_cpreciolista;
                    //_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["cprecioventamax"].ReadOnly = !_Mtd_ObligatorioPMV(Convert.ToString(_Dg_Descarga.Rows[_Dg_Descarga.RowCount - 1].Cells["ProductoInterno"].Value).Trim());
                }
            }
        }

        private bool _Mtd_ObligatorioPMV(string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT cproducto FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "' AND (cregpmv='1' OR cregpmv='2')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_ProductoRechazadoPorPMVDif(string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT cproducto FROM TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + Convert.ToString(_Cmb_Fac.SelectedItem).Trim() + "' AND cproducto='" + _P_Str_Producto + "' AND crechazadoxpmv='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Mtd_CompararEspecial(string _P_Str_Comp)
        {
            _Mtd_SobrescribirAscii();

            string _Str_Cadena = "";
            DataSet _DS = new DataSet();
            foreach (DataGridViewRow _Dgr in _Dg_Descarga.Rows)
            {
                _Str_Cadena = "Select cempaques,cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproducto='" + _Dgr.Cells[0].Value.ToString() + "'";
                _DS = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_DS.Tables[0].Rows.Count > 0)
                {
                    decimal _Dcm_Empaques_Factura = 0;
                    decimal _Dcm_Empaques_Ascii = 0;
                    decimal _Dcm_Unidades_Factura = 0;
                    decimal _Dcm_Unidades_Ascii = 0;
                    if (_DS.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Dcm_Empaques_Factura = Convert.ToDecimal(_DS.Tables[0].Rows[0][0].ToString());
                    }
                    if (_DS.Tables[0].Rows[0][1] != System.DBNull.Value)
                    {
                        _Dcm_Unidades_Factura = Convert.ToDecimal(_DS.Tables[0].Rows[0][1].ToString());
                    }
                    if (_Dgr.Cells[4].Value != null)
                    {
                        _Dcm_Empaques_Ascii = Convert.ToDecimal(_Dgr.Cells[4].Value.ToString());
                    }
                    if (_Dgr.Cells[5].Value != null)
                    {
                        _Dcm_Unidades_Ascii = Convert.ToDecimal(_Dgr.Cells[5].Value.ToString());
                    }
                    decimal _Dcm_Difer = 0;
                    decimal _Dcm_DiferUniMin = 0;
                    decimal _Dcm_DiferUni = 0;
                    decimal _Dcm_UniMinFact = 0;
                    decimal _Dcm_UniMinAscii = 0;
                    _Dcm_UniMinFact = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_Empaques_Factura), Convert.ToInt32(_Dcm_Unidades_Factura)));
                    _Dcm_UniMinAscii = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_Empaques_Ascii), Convert.ToInt32(_Dcm_Unidades_Ascii)));
                    //if (_Dcm_Empaques_Ascii > _Dcm_Empaques_Factura)
                    if (_Dcm_UniMinAscii > _Dcm_UniMinFact)
                    {
                        _Dcm_DiferUniMin = _Dcm_UniMinAscii - _Dcm_UniMinFact;
                        //_Dcm_Difer = _Dcm_Empaques_Ascii - _Dcm_Empaques_Factura;
                        _Dcm_Difer = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_DiferUniMin), 0));
                        _Dcm_DiferUni = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_DiferUniMin)));
                    }
                    else
                    {
                        //_Dcm_Difer = _Dcm_Empaques_Factura - _Dcm_Empaques_Ascii;
                        _Dcm_DiferUniMin = _Dcm_UniMinFact - _Dcm_UniMinAscii;
                        _Dcm_Difer = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_DiferUniMin), 0));
                        _Dcm_DiferUni = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_DiferUniMin)));
                    }
                    //if (_Dcm_Unidades_Ascii > _Dcm_Unidades_Factura)
                    //{
                    //    _Dcm_DiferUni = _Dcm_Unidades_Ascii - _Dcm_Unidades_Factura;
                    //}
                    //else
                    //{
                    //    _Dcm_DiferUni = _Dcm_Unidades_Factura - _Dcm_Unidades_Ascii;
                    //}
                    //if (_Dcm_Empaques_Ascii > _Dcm_Empaques_Factura || _Dcm_Unidades_Ascii > _Dcm_Unidades_Factura)
                    if (_Dcm_UniMinAscii > _Dcm_UniMinFact)
                    {
                        _Str_Cadena = "insert into TRECEPCIONDDDFD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,cdiferenciaemp,cdiferenciauni,cfaltante,cproveedor) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _Txt_rec2.Text + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + _Dgr.Cells[0].Value.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Difer) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DiferUni) + "','2','" + _Str_Proveedor + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //if (_Dcm_Empaques_Ascii < _Dcm_Empaques_Factura || _Dcm_Unidades_Ascii < _Dcm_Unidades_Factura)
                    if (_Dcm_UniMinAscii < _Dcm_UniMinFact)
                    {
                        _Str_Cadena = "insert into TRECEPCIONDDDFD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,cdiferenciaemp,cdiferenciauni,cfaltante,cproveedor) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _Txt_rec2.Text + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + _Dgr.Cells[0].Value.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Difer) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DiferUni) + "','1','" + _Str_Proveedor + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
                else
                {
                    decimal _Dcm_Empaques_Ascii = 0;
                    decimal _Dcm_Unidades_Ascii = 0;
                    decimal _Dcm_UniMinAscii = 0;
                    decimal _Dcm_Empaques_Ascii2 = 0;
                    decimal _Dcm_Unidades_Ascii2 = 0;
                    if (_Dgr.Cells[4].Value != null)
                    {
                        _Dcm_Empaques_Ascii2 = Convert.ToDecimal(_Dgr.Cells[4].Value.ToString());
                    }
                    if (_Dgr.Cells[5].Value != null)
                    {
                        _Dcm_Unidades_Ascii2 = Convert.ToDecimal(_Dgr.Cells[5].Value.ToString());
                    }
                    _Dcm_UniMinAscii = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_Empaques_Ascii2), Convert.ToInt32(_Dcm_Unidades_Ascii2)));
                    _Dcm_Empaques_Ascii = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_UniMinAscii), 0));
                    _Dcm_Unidades_Ascii = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Dgr.Cells[0].Value.ToString(), Convert.ToInt32(_Dcm_UniMinAscii)));
                    if (_Dcm_Empaques_Ascii > 0 | _Dcm_Unidades_Ascii > 0)
                    {
                        _Str_Cadena = "insert into TRECEPCIONDDDFD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,cdiferenciaemp,cdiferenciauni,cfaltante,cproveedor) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _Txt_rec2.Text + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + _Dgr.Cells[0].Value.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Empaques_Ascii) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Unidades_Ascii) + "','2','" + _Str_Proveedor + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
            _Str_Cadena = "Select cproducto,cempaques,cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text.Trim() + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString().Trim() + "' and not exists(Select * from TRECEPCIONDD where TRECEPCIONDD.cgroupcomp=TRECEPCIONDFD.cgroupcomp and TRECEPCIONDD.cidrecepcion=TRECEPCIONDFD.cidrecepcion and TRECEPCIONDD.cnfacturapro=TRECEPCIONDFD.cnfacturapro and TRECEPCIONDD.cproducto=TRECEPCIONDFD.cproducto and TRECEPCIONDD.cproveedor=TRECEPCIONDFD.cproveedor)";
            _DS = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _DS.Tables[0].Rows)
            {
                decimal _Dcm_Empaques_Factura2 = 0;
                decimal _Dcm_Unidades_Factura2 = 0;
                decimal _Dcm_Empaques_Factura = 0;
                decimal _Dcm_Unidades_Factura = 0;
                decimal _Dcm_UniMinFact = 0;
                if (_Row[1] != System.DBNull.Value)
                {
                    _Dcm_Empaques_Factura2 = Convert.ToDecimal(_Row[1].ToString());
                }
                if (_Row[2] != System.DBNull.Value)
                {
                    _Dcm_Unidades_Factura2 = Convert.ToDecimal(_Row[2].ToString());
                }
                _Dcm_UniMinFact = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row[0].ToString(), Convert.ToInt32(_Dcm_Empaques_Factura2), Convert.ToInt32(_Dcm_Unidades_Factura2)));
                _Dcm_Empaques_Factura = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row[0].ToString(), Convert.ToInt32(_Dcm_UniMinFact), 0));
                _Dcm_Unidades_Factura = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row[0].ToString(), Convert.ToInt32(_Dcm_UniMinFact)));
                _Str_Cadena = "insert into TRECEPCIONDDDFD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,cdiferenciaemp,cdiferenciauni,cfaltante,cproveedor) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _Txt_rec2.Text + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + _Row[0].ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Empaques_Factura) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Unidades_Factura) + "','1','" + _Str_Proveedor + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONDFM", "ccomparafactdes='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'");
            //-------
            _Mtd_Credito_Faltante(_P_Str_Comp);
            _Mtd_Credito_Sobrepresio(_P_Str_Comp);
            _Mtd_Debito_Faltante(_P_Str_Comp);
            _Mtd_Debito_Sobrepresio(_P_Str_Comp);
            MessageBox.Show("La operación fue realizada correctamente", "Informción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string _Mtd_CompProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "select DISTINCT ccompany from TGRUPPROVEE where cproveedor='" + _P_Str_Proveedor + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 1)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }

        private void _Mtd_UpdateTotalDetalleND(string _P_Str_Comp, string _P_Str_ID_ND, string _P_Str_Producto)
        {
            string _Str_Cadena = "UPDATE TNOTADEBITOCPD SET cmontototal=CONVERT(NUMERIC(18,2),((ISNULL(cbasegrabada,0)+ISNULL(cbasexcenta,0)+ISNULL(cimpuesto,0))-ISNULL(cmontoinvendi,0))-(ISNULL(cdescfinanmonto,0))) WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cidnotadebitocxp='" + _P_Str_ID_ND + "' AND cproducto='" + _P_Str_Producto + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private void _Mtd_UpdateTotalDetalleNC(string _P_Str_Comp, string _P_Str_ID_NC, string _P_Str_Producto)
        {
            string _Str_Cadena = "UPDATE TNOTACREDICPD SET cmontototal=CONVERT(NUMERIC(18,2),((ISNULL(cbasegrabada,0)+ISNULL(cbasexcenta,0)+ISNULL(cimpuesto,0))-ISNULL(cmontoinvendi,0))-(ISNULL(cdescfinanmonto,0))) WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cidnotacreditocxp='" + _P_Str_ID_NC + "' AND cproducto='" + _P_Str_Producto + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private decimal _Mtd_SumMontoDetalleND(string _P_Str_ID_ND, string _P_Str_Campo, string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT ISNULL(SUM(" + _P_Str_Campo + "),0) FROM TNOTADEBITOCPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cidnotadebitocxp='" + _P_Str_ID_ND + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return 0;
        }

        private decimal _Mtd_SumMontoDetalleNC(string _P_Str_ID_NC, string _P_Str_Campo, string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT ISNULL(SUM(" + _P_Str_Campo + "),0) FROM TNOTACREDICPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cidnotacreditocxp='" + _P_Str_ID_NC + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return 0;
        }

        private void _Mtd_Debito_Faltante(string _P_Str_Comp)
        {
        _Et_Retorno:
            string _Str_Cadena = "Select TRECEPCIONDDDFD.cproducto,TRECEPCIONDDDFD.cdiferenciaemp,TRECEPCIONDDDFD.cdiferenciauni,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 from TRECEPCIONDDDFD inner join TPRODUCTO ON TPRODUCTO.cproducto=TRECEPCIONDDDFD.cproducto where TRECEPCIONDDDFD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRECEPCIONDDDFD.cidrecepcion='" + _Txt_rec2.Text + "' and TRECEPCIONDDDFD.cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' AND TRECEPCIONDDDFD.cproveedor='" + _Str_Proveedor + "' and TRECEPCIONDDDFD.cfaltante='1' AND NOT EXISTS(SELECT TNOTADEBITOCP.cnumdocu FROM TNOTADEBITOCP INNER JOIN TNOTADEBITOCPD ON TNOTADEBITOCP.cgroupcomp = TNOTADEBITOCPD.cgroupcomp AND TNOTADEBITOCP.ccompany = TNOTADEBITOCPD.ccompany AND TNOTADEBITOCP.cidnotadebitocxp = TNOTADEBITOCPD.cidnotadebitocxp AND TNOTADEBITOCP.cproveedor = TNOTADEBITOCPD.cproveedor WHERE TNOTADEBITOCP.cgroupcomp=TRECEPCIONDDDFD.cgroupcomp AND TNOTADEBITOCP.cproveedor=TRECEPCIONDDDFD.cproveedor AND TNOTADEBITOCP.cnumdocu=TRECEPCIONDDDFD.cnfacturapro AND TNOTADEBITOCP.ccompany='" + _P_Str_Comp + "' AND TNOTADEBITOCPD.cproducto=TRECEPCIONDDDFD.cproducto AND ISNULL(TNOTADEBITOCP.cdiferenciaprec,0)='0')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            int _Int_CantidadReg = 0;
            DataSet _Ds2 = new DataSet();
            int _Int_Consecutivo = 0;
            decimal _Dcm_Monto_Sin_Impuesto = 0;
            decimal _Dcm_Total_Invendible = 0;
            decimal _Dcm_Impuesto = 0;
            decimal _Dcm_Base_Grabada = 0;
            decimal _Dcm_Base_Excenta = 0;
            decimal _Dcm_PorceDescFinanFactura = 0, _Dcm_PorceDescFinanD = 0, _Dcm_DescFinanTotal = 0, _Dcm_DescFinanBExcenta = 0, _Dcm_DescFinanBGrabada = 0, _Dcm_DescFinanImp = 0, _Dcm_TotalDescFinan = 0, _Dcm_TotalDescFinanImp = 0;
            string _Str_Descripcion = "";
            bool _Bol_Ascii = false;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Ascii = true;
                _Int_Consecutivo = _Mtd_Consecutivo_TNOTADEBITOCP(_P_Str_Comp);
                _Dcm_PorceDescFinanFactura = _Mtd_ObtenerPorcentajeDescuentoFinancieroFactura(_Txt_rec2.Text, _Cmb_Fac.SelectedItem.ToString());
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    decimal _Dcm_Precio = 0;
                    decimal _Dcm_Monto = 0;
                    decimal _Dcm_Base_GrabadaD = 0;
                    decimal _Dcm_Base_ExcentaD = 0;
                    decimal _Dcm_Alicuota = 0;
                    _Str_Cadena = "Select cpreciouni from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproducto='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        _Dcm_Precio = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                    }
                    if (_Row[1] != System.DBNull.Value)
                    {
                        _Dcm_Monto = _Dcm_Precio * Convert.ToDecimal(_Row[1].ToString().Trim());
                    }
                    if (_Row[2] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(_Row[2].ToString()) > 0)
                        {
                            decimal _Dcm_Unidades = Convert.ToInt32(_Row[3].ToString().Trim()) / Convert.ToInt32(_Row[4].ToString().Trim());
                            _Dcm_Monto += (_Dcm_Precio / _Dcm_Unidades) * Convert.ToDecimal(_Row[2].ToString().Trim());
                        }
                    }
                    //-----------------------------
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "'";
                    decimal _Dcm_Invendible = 0;
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dcm_Invendible = Convert.ToDecimal(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                        }
                    }
                    //-----------------------------
                    _Dcm_Invendible = ((_Dcm_Monto * _Dcm_Invendible) / 100);
                    _Dcm_Total_Invendible = _Dcm_Total_Invendible + _Dcm_Invendible;
                    _Dcm_Monto = _Dcm_Monto - _Dcm_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    decimal _Dcm_ImpuestoCalculado = 0;
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            _Dcm_ImpuestoCalculado = (_Dcm_Monto * Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                            _Dcm_Impuesto = _Dcm_Impuesto + _Dcm_ImpuestoCalculado;
                            _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                            _Dcm_Base_Grabada = _Dcm_Base_Grabada + _Dcm_Monto;
                            _Dcm_Base_GrabadaD = _Dcm_Base_GrabadaD + _Dcm_Monto;
                            _Dcm_Alicuota = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        catch
                        {
                            _Dcm_Impuesto = _Dcm_Impuesto + 0;
                        }
                    }
                    else
                    {
                        _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                        _Dcm_Base_Excenta = _Dcm_Base_Excenta + _Dcm_Monto;
                        _Dcm_Base_ExcentaD = _Dcm_Base_ExcentaD + _Dcm_Monto;
                    }
                    //----------------------------------------
                    decimal _Dcm_Monto_Total_D = (_Dcm_Monto - _Dcm_Invendible) + _Dcm_ImpuestoCalculado;

                    _Str_Cadena = "SELECT cdescpp FROM TPRODUCTO WHERE cproducto = '" + _Row[0].ToString() + "' and cdelete = '0'";
                    var _DsProducto = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    var _Bool_ProductoConDescPp = _DsProducto.Tables[0].Rows[0][0].ToString() == "1";
                    if (!_Bool_ProductoConDescPp)
                    {
                        _Dcm_PorceDescFinanD = 0;
                        _Dcm_DescFinanBExcenta = 0;
                        _Dcm_DescFinanBGrabada = 0;
                        _Dcm_DescFinanTotal = 0;
                    }
                    else
                    {
                        _Dcm_PorceDescFinanD = _Dcm_PorceDescFinanFactura;
                    }

                    // -Inicio- Calculos Modificados tomando en cuenta el descuento financiero - Ignacio 07/06/2013
                    //Solo si la factura posee descuento financiero
                    if (_Dcm_PorceDescFinanD > 0)
                    {
                        //Calculo el descuento financiero de las bases
                        _Dcm_DescFinanBExcenta = (_Dcm_PorceDescFinanD * _Dcm_Base_ExcentaD) / 100;
                        _Dcm_DescFinanBGrabada = (_Dcm_PorceDescFinanD * _Dcm_Base_GrabadaD) / 100;

                        //Calculo el descuento financiero del impuesto
                        _Dcm_DescFinanImp = (_Dcm_DescFinanBGrabada * _Dcm_Alicuota) / 100;

                        //Truncamos
                        _Dcm_DescFinanBExcenta = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBExcenta, 2));
                        _Dcm_DescFinanBGrabada = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBGrabada, 2));
                        _Dcm_DescFinanImp = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanImp, 2));
                        _Dcm_DescFinanTotal = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada), 2));

                        //Acumulamos
                        _Dcm_TotalDescFinan = _Dcm_TotalDescFinan + _Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada;
                        _Dcm_TotalDescFinanImp = _Dcm_TotalDescFinanImp + _Dcm_DescFinanImp;

                        //Descontamos a los totales
                        _Dcm_Monto = _Dcm_Monto - _Dcm_DescFinanTotal;
                        _Dcm_ImpuestoCalculado = _Dcm_ImpuestoCalculado - _Dcm_DescFinanImp;
                        _Dcm_Impuesto = _Dcm_Impuesto - _Dcm_DescFinanImp;
                        _Dcm_Monto_Total_D = _Dcm_Monto_Total_D - _Dcm_DescFinanBExcenta - _Dcm_DescFinanBGrabada;
                    }
                    // -Fin- Calculos Modificados tomando en cuenta el descuento financiero    - Ignacio 07/06/2013
                    if (_Dcm_Monto > 0)
                    {
                        _Str_Cadena = "insert into TNOTADEBITOCPD (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cproducto,ccajas,cunidades,cmontosimp,cmontoinvendi,cbasegrabada,cbasexcenta,cimpuesto,cmontototal,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Row[0].ToString() + "','" + _Row[1].ToString() + "','" + _Row[2].ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_ExcentaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ImpuestoCalculado) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Alicuota) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_UpdateTotalDetalleND(_P_Str_Comp, _Int_Consecutivo.ToString(), _Row[0].ToString());
                    }
                    //----------------------------------------
                    _Dcm_Monto_Sin_Impuesto = _Dcm_Monto_Sin_Impuesto + _Dcm_Monto;
                    _Int_CantidadReg++;
                    if (_Int_CantidadReg == 6)
                    {
                        break;
                    }
                }

                //decimal _Dcm_Monto_Total = (Math.Round(_Dcm_Monto_Sin_Impuesto, 2) - Math.Round(_Dcm_Total_Invendible, 2)) + Math.Round(_Dcm_Impuesto, 2);
                decimal _Dcm_Monto_Total = (_Dcm_Monto_Sin_Impuesto - _Dcm_Total_Invendible) + _Dcm_Impuesto;
                //-------------------------------------------SOLUCION DE VARIAS FACTURAS UNA OC. DIFERENCIA DE PRECIO
                _Str_Cadena = "SELECT TMOTIVO.cdescripcion,TMOTIVO.cidmotivo FROM TCONFIGCOMP INNER JOIN TMOTIVO ON TCONFIGCOMP.cmotndfaltante = TMOTIVO.cidmotivo WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') and TMOTIVO.cdocumentnd='1'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_Motivo = "";
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Str_Descripcion = _Ds2.Tables[0].Rows[0][0].ToString() + " FACTURA# " + _Cmb_Fac.SelectedItem.ToString();
                    _Str_Motivo = _Ds2.Tables[0].Rows[0][1].ToString();
                }
                _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
                              "FROM TDOCUMENT INNER JOIN " +
                              "TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentfact " +
                              "WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
                DataSet _Ds4 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_TD = "";
                if (_Ds4.Tables[0].Rows.Count > 0)
                {
                    _Str_TD = _Ds4.Tables[0].Rows[0][0].ToString();
                }
                if (_Bol_Ascii)
                {
                    if (_Dcm_Monto_Sin_Impuesto > 0)
                    {
                        decimal _Dcm_AlicuotaM = 0;
                        if (_Dcm_Impuesto > 0)
                        {
                            _Dcm_AlicuotaM = _Mtd_Impuesto(_P_Str_Comp);
                        }
                        //---------------
                        _Dcm_Monto_Sin_Impuesto = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cmontosimp", _P_Str_Comp);
                        _Dcm_Impuesto = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cimpuesto", _P_Str_Comp);
                        _Dcm_Total_Invendible = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cmontoinvendi", _P_Str_Comp);
                        _Dcm_Monto_Total = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cmontototal", _P_Str_Comp);
                        _Dcm_Base_Grabada = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cbasegrabada", _P_Str_Comp);
                        _Dcm_Base_Excenta = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cbasexcenta", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        _Dcm_DescFinanBExcenta = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cdescfinanmontobexcenta", _P_Str_Comp);
                        _Dcm_DescFinanBGrabada = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cdescfinanmontobgrabada", _P_Str_Comp);
                        _Dcm_DescFinanTotal = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cdescfinanmonto", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        //---------------
                        _Str_Cadena = "insert into TNOTADEBITOCP (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cfechand,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cidmotivo,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Sin_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_TD + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Total_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Excenta) + "','" + _Str_Motivo + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_AlicuotaM) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanFactura) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONDFM", "cidnotadebitocxp='" + _Int_Consecutivo.ToString() + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'");
                    }
                }
                goto _Et_Retorno;
            }
        }

        private void _Mtd_Debito_Sobrepresio(string _P_Str_Comp)
        {
        _Et_Retorno:
            string _Str_Cadena = "Select TRECEPCIONDDDOCF.cproducto,TRECEPCIONDDDOCF.cpreciodiferenc,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 from TRECEPCIONDDDOCF inner join TPRODUCTO ON TPRODUCTO.cproducto=TRECEPCIONDDDOCF.cproducto where TRECEPCIONDDDOCF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRECEPCIONDDDOCF.cidrecepcion='" + _Txt_rec2.Text + "' and TRECEPCIONDDDOCF.cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and TRECEPCIONDDDOCF.cproveedor='" + _Str_Proveedor + "' AND TRECEPCIONDDDOCF.cdiferenciaprec='2' AND TRECEPCIONDDDOCF.caprobadifpdocu='1' AND NOT EXISTS(SELECT TNOTADEBITOCP.cnumdocu FROM TNOTADEBITOCP INNER JOIN TNOTADEBITOCPD ON TNOTADEBITOCP.cgroupcomp = TNOTADEBITOCPD.cgroupcomp AND TNOTADEBITOCP.ccompany = TNOTADEBITOCPD.ccompany AND TNOTADEBITOCP.cidnotadebitocxp = TNOTADEBITOCPD.cidnotadebitocxp AND TNOTADEBITOCP.cproveedor = TNOTADEBITOCPD.cproveedor WHERE TNOTADEBITOCP.cgroupcomp=TRECEPCIONDDDOCF.cgroupcomp AND TNOTADEBITOCP.cproveedor=TRECEPCIONDDDOCF.cproveedor AND TNOTADEBITOCP.cnumdocu=TRECEPCIONDDDOCF.cnfacturapro AND TNOTADEBITOCP.ccompany='" + _P_Str_Comp + "' AND TNOTADEBITOCPD.cproducto=TRECEPCIONDDDOCF.cproducto AND ISNULL(TNOTADEBITOCP.cdiferenciaprec,0)='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            int _Int_CantidadReg = 0;
            DataSet _Ds2 = new DataSet();
            int _Int_Consecutivo = 0;
            decimal _Dcm_Monto_Sin_Impuesto = 0;
            decimal _Dcm_Total_Invendible = 0;
            decimal _Dcm_Impuesto = 0;
            decimal _Dcm_Base_Grabada = 0;
            decimal _Dcm_Base_Excenta = 0;
            decimal _Dcm_PorceDescFinanFactura = 0, _Dcm_PorceDescFinanD = 0, _Dcm_DescFinanTotal = 0, _Dcm_DescFinanBExcenta = 0, _Dcm_DescFinanBGrabada = 0, _Dcm_DescFinanImp = 0, _Dcm_TotalDescFinan = 0, _Dcm_TotalDescFinanImp = 0;
            string _Str_Descripcion = "";
            bool _Bol_Orden = false;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Orden = true;
                _Int_Consecutivo = _Mtd_Consecutivo_TNOTADEBITOCP(_P_Str_Comp);
                _Dcm_PorceDescFinanFactura = _Mtd_ObtenerPorcentajeDescuentoFinancieroFactura(_Txt_rec2.Text, _Cmb_Fac.SelectedItem.ToString());
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    decimal _Dcm_Precio = 0;
                    decimal _Dcm_PrecioUni = 0;
                    decimal _Dcm_Monto = 0;
                    decimal _Dcm_Base_GrabadaD = 0;
                    decimal _Dcm_Base_ExcentaD = 0;
                    decimal _Dcm_Alicuota = 0;
                    _Str_Cadena = "Select cempaques,cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproducto='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        _Dcm_Precio = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                        _Dcm_PrecioUni = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][1].ToString());
                    }
                    //----------------------------------------------Descontar
                    decimal _Dcm_Descontar = 0;
                    decimal _Dcm_DescontarUni = 0;
                    _Str_Cadena = "Select cdiferenciaemp,cdiferenciauni from TRECEPCIONDDDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and  cfaltante='1' and cproducto='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        DataRow _Rows = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                        if (_Rows[0] != System.DBNull.Value)
                        {
                            _Dcm_Descontar = Convert.ToDecimal(_Rows[0].ToString().Trim());
                        }
                        if (_Rows[1] != System.DBNull.Value)
                        {
                            _Dcm_DescontarUni = Convert.ToDecimal(_Rows[1].ToString().Trim());
                        }
                    }
                    if (_Dcm_Precio != _Dcm_Descontar)
                    {
                        _Dcm_Precio = _Dcm_Precio - _Dcm_Descontar;
                    }
                    if (_Dcm_PrecioUni != _Dcm_DescontarUni)
                    {
                        _Dcm_PrecioUni = _Dcm_PrecioUni - _Dcm_DescontarUni;
                    }
                    //----------------------------------------------Descontar
                    if (_Row[1] != System.DBNull.Value)
                    {
                        _Dcm_Monto = _Dcm_Precio * Convert.ToDecimal(_Row[1].ToString().Trim());
                        decimal _Dcm_UnidadesConvert = 0;
                        if (_Dcm_PrecioUni > 0)
                        {
                            if (_Row[3].ToString() != "")
                            {
                                if (Convert.ToInt32(_Row[3].ToString().Trim()) > 0)
                                {
                                    _Dcm_UnidadesConvert = Convert.ToInt32(_Row[2].ToString().Trim()) / Convert.ToInt32(_Row[3].ToString().Trim());
                                    if (_Dcm_UnidadesConvert > 0)
                                    {
                                        _Dcm_Monto += (Convert.ToDecimal(_Row[1].ToString().Trim()) / _Dcm_UnidadesConvert) * _Dcm_PrecioUni;
                                    }
                                }
                            }
                        }
                    }
                    //-----------------------------
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "' and cdelete='0'";
                    decimal _Dcm_Invendible = 0;
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dcm_Invendible = Convert.ToDecimal(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                        }
                    }
                    //-----------------------------
                    _Dcm_Invendible = ((_Dcm_Monto * _Dcm_Invendible) / 100);
                    _Dcm_Total_Invendible = _Dcm_Total_Invendible + _Dcm_Invendible;
                    _Dcm_Monto = _Dcm_Monto - _Dcm_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    decimal _Dcm_ImpuestoCalculado = 0;
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            _Dcm_ImpuestoCalculado = (_Dcm_Monto * Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                            _Dcm_Impuesto = _Dcm_Impuesto + _Dcm_ImpuestoCalculado;
                            _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                            _Dcm_Base_Grabada = _Dcm_Base_Grabada + _Dcm_Monto;
                            _Dcm_Base_GrabadaD = _Dcm_Base_GrabadaD + _Dcm_Monto;
                            _Dcm_Alicuota = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        catch
                        {
                            _Dcm_Impuesto = _Dcm_Impuesto + 0;
                        }
                    }
                    else
                    {
                        _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                        _Dcm_Base_Excenta = _Dcm_Base_Excenta + _Dcm_Monto;
                        _Dcm_Base_ExcentaD = _Dcm_Base_ExcentaD + _Dcm_Monto;
                    }
                    //----------------------------------------
                    decimal _Dcm_Monto_Total_D = (_Dcm_Monto - _Dcm_Invendible) + _Dcm_ImpuestoCalculado;

                    _Str_Cadena = "SELECT cdescpp FROM TPRODUCTO WHERE cproducto = '" + _Row[0].ToString() + "' and cdelete = '0'";
                    var _DsProducto = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    var _Bool_ProductoConDescPp = _DsProducto.Tables[0].Rows[0][0].ToString() == "1";
                    if (!_Bool_ProductoConDescPp)
                    {
                        _Dcm_PorceDescFinanD = 0;
                        _Dcm_DescFinanBExcenta = 0;
                        _Dcm_DescFinanBGrabada = 0;
                        _Dcm_DescFinanTotal = 0;
                    }
                    else
                    {
                        _Dcm_PorceDescFinanD = _Dcm_PorceDescFinanFactura;
                    }

                    // -Inicio- Calculos Modificados tomando en cuenta el descuento financiero - Ignacio 07/06/2013
                    //Solo si la factura posee descuento financiero
                    if (_Dcm_PorceDescFinanD > 0)
                    {
                        //Calculo el descuento financiero de las bases
                        _Dcm_DescFinanBExcenta = (_Dcm_PorceDescFinanD * _Dcm_Base_ExcentaD) / 100;
                        _Dcm_DescFinanBGrabada = (_Dcm_PorceDescFinanD * _Dcm_Base_GrabadaD) / 100;

                        //Calculo el descuento financiero del impuesto
                        _Dcm_DescFinanImp = (_Dcm_DescFinanBGrabada * _Dcm_Alicuota) / 100;

                        //Truncamos
                        _Dcm_DescFinanBExcenta = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBExcenta, 2));
                        _Dcm_DescFinanBGrabada = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBGrabada, 2));
                        _Dcm_DescFinanImp = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanImp, 2));
                        _Dcm_DescFinanTotal = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada), 2));

                        //Acumulamos
                        _Dcm_TotalDescFinan = _Dcm_TotalDescFinan + _Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada;
                        _Dcm_TotalDescFinanImp = _Dcm_TotalDescFinanImp + _Dcm_DescFinanImp;

                        //Descontamos a los totales
                        _Dcm_Monto = _Dcm_Monto - _Dcm_DescFinanTotal;
                        _Dcm_ImpuestoCalculado = _Dcm_ImpuestoCalculado - _Dcm_DescFinanImp;
                        _Dcm_Impuesto = _Dcm_Impuesto - _Dcm_DescFinanImp;
                        _Dcm_Monto_Total_D = _Dcm_Monto_Total_D - _Dcm_DescFinanBExcenta - _Dcm_DescFinanBGrabada;
                    }
                    // -Fin- Calculos Modificados tomando en cuenta el descuento financiero    - Ignacio 07/06/2013
                    if (_Dcm_Monto > 0)
                    {
                        _Str_Cadena = "insert into TNOTADEBITOCPD (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cproducto,ccajas,cunidades,cmontosimp,cmontoinvendi,cbasegrabada,cbasexcenta,cimpuesto,cmontototal,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Row[0].ToString() + "','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_ExcentaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ImpuestoCalculado) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Alicuota) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_UpdateTotalDetalleND(_P_Str_Comp, _Int_Consecutivo.ToString(), _Row[0].ToString());
                    }
                    //----------------------------------------
                    _Dcm_Monto_Sin_Impuesto = _Dcm_Monto_Sin_Impuesto + _Dcm_Monto;
                    _Int_CantidadReg++;
                    if (_Int_CantidadReg == 6)
                    {
                        break;
                    }
                }

                //decimal _Dcm_Monto_Total = (Math.Round(_Dcm_Monto_Sin_Impuesto, 2) - Math.Round(_Dcm_Total_Invendible, 2)) + Math.Round(_Dcm_Impuesto, 2);
                decimal _Dcm_Monto_Total = (_Dcm_Monto_Sin_Impuesto - _Dcm_Total_Invendible) + _Dcm_Impuesto;
                //-------------------------------------------SOLUCION DE VARIAS FACTURAS UNA OC. DIFERENCIA DE PRECIO
                _Str_Cadena = "SELECT TMOTIVO.cdescripcion,TMOTIVO.cidmotivo FROM TCONFIGCOMP INNER JOIN TMOTIVO ON TCONFIGCOMP.cmotncdiferprec = TMOTIVO.cidmotivo WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') and TMOTIVO.cdocumentnc='1'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_Motivo = "";
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Str_Descripcion = _Ds2.Tables[0].Rows[0][0].ToString() + " FACTURA# " + _Cmb_Fac.SelectedItem.ToString();
                    _Str_Motivo = _Ds2.Tables[0].Rows[0][1].ToString();
                }
                _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
                              "FROM TDOCUMENT INNER JOIN " +
                              "TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentfact " +
                              "WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
                DataSet _Ds4 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_TD = "";
                if (_Ds4.Tables[0].Rows.Count > 0)
                {
                    _Str_TD = _Ds4.Tables[0].Rows[0][0].ToString();
                }
                if (_Bol_Orden)
                {
                    if (_Dcm_Monto_Sin_Impuesto > 0)
                    {
                        decimal _Dcm_AlicuotaM = 0;
                        if (_Dcm_Impuesto > 0)
                        {
                            _Dcm_AlicuotaM = _Mtd_Impuesto(_P_Str_Comp);
                        }
                        //---------------
                        _Dcm_Monto_Sin_Impuesto = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cmontosimp", _P_Str_Comp);
                        _Dcm_Impuesto = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cimpuesto", _P_Str_Comp);
                        _Dcm_Total_Invendible = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cmontoinvendi", _P_Str_Comp);
                        _Dcm_Monto_Total = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cmontototal", _P_Str_Comp);
                        _Dcm_Base_Grabada = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cbasegrabada", _P_Str_Comp);
                        _Dcm_Base_Excenta = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cbasexcenta", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        _Dcm_DescFinanBExcenta = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cdescfinanmontobexcenta", _P_Str_Comp);
                        _Dcm_DescFinanBGrabada = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cdescfinanmontobgrabada", _P_Str_Comp);
                        _Dcm_DescFinanTotal = _Mtd_SumMontoDetalleND(_Int_Consecutivo.ToString(), "cdescfinanmonto", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        //---------------
                        _Str_Cadena = "insert into TNOTADEBITOCP (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cfechand,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cdiferenciaprec,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cidmotivo,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Sin_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_TD + "','" + _Cmb_Fac.SelectedItem.ToString() + "','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Total_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Excenta) + "','" + _Str_Motivo + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_AlicuotaM) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanFactura) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONDFM", "cidnotadebitocxpdf='" + _Int_Consecutivo.ToString() + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'");
                    }
                }
                goto _Et_Retorno;
            }
        }

        private void _Mtd_Credito_Faltante(string _P_Str_Comp)
        {
        _Et_Retorno:
            string _Str_Cadena = "Select TRECEPCIONDDDFD.cproducto,TRECEPCIONDDDFD.cdiferenciaemp,TRECEPCIONDDDFD.cdiferenciauni,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 from TRECEPCIONDDDFD inner join TPRODUCTO ON TPRODUCTO.cproducto=TRECEPCIONDDDFD.cproducto where TRECEPCIONDDDFD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRECEPCIONDDDFD.cidrecepcion='" + _Txt_rec2.Text + "' and TRECEPCIONDDDFD.cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and  TRECEPCIONDDDFD.cfaltante='2' and TRECEPCIONDDDFD.cproveedor='" + _Str_Proveedor + "' AND NOT EXISTS(SELECT TNOTACREDICP.cnumdocu FROM TNOTACREDICP INNER JOIN TNOTACREDICPD ON TNOTACREDICP.cgroupcomp = TNOTACREDICPD.cgroupcomp AND TNOTACREDICP.ccompany = TNOTACREDICPD.ccompany AND TNOTACREDICP.cidnotacreditocxp = TNOTACREDICPD.cidnotacreditocxp AND TNOTACREDICP.cproveedor = TNOTACREDICPD.cproveedor WHERE TNOTACREDICP.cgroupcomp=TRECEPCIONDDDFD.cgroupcomp AND TNOTACREDICP.cproveedor=TRECEPCIONDDDFD.cproveedor AND TNOTACREDICP.cnumdocu=TRECEPCIONDDDFD.cnfacturapro AND TNOTACREDICP.ccompany='" + _P_Str_Comp + "' AND TNOTACREDICPD.cproducto=TRECEPCIONDDDFD.cproducto AND ISNULL(TNOTACREDICP.cdiferenciaprec,0)='0')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            int _Int_CantidadReg = 0;
            DataSet _Ds2 = new DataSet();
            decimal _Dcm_Monto_Sin_Impuesto = 0;
            decimal _Dcm_Total_Invendible = 0;
            decimal _Dcm_Impuesto = 0;
            string _Str_Descripcion = "";
            decimal _Dcm_Base_Grabada = 0;
            decimal _Dcm_Base_Excenta = 0;
            decimal _Dcm_PorceDescFinanFactura = 0, _Dcm_PorceDescFinanD = 0, _Dcm_DescFinanTotal = 0, _Dcm_DescFinanBExcenta = 0, _Dcm_DescFinanBGrabada = 0, _Dcm_DescFinanImp = 0, _Dcm_TotalDescFinan = 0, _Dcm_TotalDescFinanImp = 0;
            int _Int_Consecutivo = 0;
            bool _Bol_Ascii = false;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Ascii = true;
                _Int_Consecutivo = _Mtd_Consecutivo_TNOTACREDICP(_P_Str_Comp);
                _Dcm_PorceDescFinanFactura = _Mtd_ObtenerPorcentajeDescuentoFinancieroFactura(_Txt_rec2.Text, _Cmb_Fac.SelectedItem.ToString());
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    decimal _Dcm_Precio = 0;
                    decimal _Dcm_Monto = 0;
                    decimal _Dcm_Base_GrabadaD = 0;
                    decimal _Dcm_Base_ExcentaD = 0;
                    decimal _Dcm_Alicuota = 0;
                    _Str_Cadena = "Select cpreciouni from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproducto='" + _Row[0].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dcm_Precio = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            _Dcm_Precio = 0;
                        }
                    }
                    else
                    {
                        _Str_Cadena = "Select ccostobruto_u1 from TPRODUCTO where cproducto='" + _Row[0].ToString() + "'";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            {
                                _Dcm_Precio = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                            }
                            else
                            {
                                _Dcm_Precio = 0;
                            }
                        }
                    }
                    if (_Row[1] != System.DBNull.Value)
                    {
                        _Dcm_Monto += _Dcm_Precio * Convert.ToDecimal(_Row[1].ToString().Trim());
                    }
                    if (_Row[2] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(_Row[2].ToString()) > 0)
                        {
                            if (_Row[4] != System.DBNull.Value)
                            {
                                if (Convert.ToInt32(_Row[4].ToString().Trim()) > 0)
                                {
                                    decimal _Dcm_Unidades = Convert.ToInt32(_Row[3].ToString().Trim()) / Convert.ToInt32(_Row[4].ToString().Trim());
                                    if (_Dcm_Unidades > 0)
                                    {
                                        _Dcm_Monto += (_Dcm_Precio / _Dcm_Unidades) * Convert.ToDecimal(_Row[2].ToString().Trim());
                                    }
                                }
                            }
                        }
                    }
                    //-----------------------------
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "' and cdelete='0'";
                    decimal _Dcm_Invendible = 0;
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dcm_Invendible = Convert.ToDecimal(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                        }
                    }
                    //-----------------------------
                    _Dcm_Invendible = ((_Dcm_Monto * _Dcm_Invendible) / 100);
                    _Dcm_Total_Invendible = _Dcm_Total_Invendible + _Dcm_Invendible;
                    _Dcm_Monto = _Dcm_Monto - _Dcm_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    decimal _Dcm_ImpuestoCalculado = 0;
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            _Dcm_ImpuestoCalculado = (_Dcm_Monto * Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                            _Dcm_Impuesto = _Dcm_Impuesto + _Dcm_ImpuestoCalculado;
                            //------
                            _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                            _Dcm_Base_Grabada = _Dcm_Base_Grabada + _Dcm_Monto;
                            _Dcm_Base_GrabadaD = _Dcm_Base_GrabadaD + _Dcm_Monto;
                            _Dcm_Alicuota = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                            //-----
                        }
                        catch
                        {
                            _Dcm_Impuesto = _Dcm_Impuesto + 0;
                        }
                    }
                    else
                    {
                        _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                        _Dcm_Base_Excenta = _Dcm_Base_Excenta + _Dcm_Monto;
                        _Dcm_Base_ExcentaD = _Dcm_Base_ExcentaD + _Dcm_Monto;
                    }
                    //----------------------------------------
                    decimal _Dcm_Monto_Total_D = (_Dcm_Monto - _Dcm_Invendible) + _Dcm_ImpuestoCalculado;

                    _Str_Cadena = "SELECT cdescpp FROM TPRODUCTO WHERE cproducto = '" + _Row[0].ToString() + "' and cdelete = '0'";
                    var _DsProducto = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    var _Bool_ProductoConDescPp = _DsProducto.Tables[0].Rows[0][0].ToString() == "1";
                    if (!_Bool_ProductoConDescPp)
                    {
                        _Dcm_PorceDescFinanD = 0;
                        _Dcm_DescFinanBExcenta = 0;
                        _Dcm_DescFinanBGrabada = 0;
                        _Dcm_DescFinanTotal = 0;
                    }
                    else
                    {
                        _Dcm_PorceDescFinanD = _Dcm_PorceDescFinanFactura;
                    }

                    // -Inicio- Calculos Modificados tomando en cuenta el descuento financiero - Ignacio 07/06/2013
                    //Solo si la factura posee descuento financiero
                    if (_Dcm_PorceDescFinanD > 0)
                    {
                        //Calculo el descuento financiero de las bases
                        _Dcm_DescFinanBExcenta = (_Dcm_PorceDescFinanD * _Dcm_Base_ExcentaD) / 100;
                        _Dcm_DescFinanBGrabada = (_Dcm_PorceDescFinanD * _Dcm_Base_GrabadaD) / 100;

                        //Calculo el descuento financiero del impuesto
                        _Dcm_DescFinanImp = (_Dcm_DescFinanBGrabada * _Dcm_Alicuota) / 100;

                        //Truncamos
                        _Dcm_DescFinanBExcenta = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBExcenta, 2));
                        _Dcm_DescFinanBGrabada = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBGrabada, 2));
                        _Dcm_DescFinanImp = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanImp, 2));
                        _Dcm_DescFinanTotal = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada), 2));

                        //Acumulamos
                        _Dcm_TotalDescFinan = _Dcm_TotalDescFinan + _Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada;
                        _Dcm_TotalDescFinanImp = _Dcm_TotalDescFinanImp + _Dcm_DescFinanImp;

                        //Descontamos a los totales
                        _Dcm_Monto = _Dcm_Monto - _Dcm_DescFinanTotal;
                        _Dcm_ImpuestoCalculado = _Dcm_ImpuestoCalculado - _Dcm_DescFinanImp;
                        _Dcm_Impuesto = _Dcm_Impuesto - _Dcm_DescFinanImp;
                        _Dcm_Monto_Total_D = _Dcm_Monto_Total_D - _Dcm_DescFinanBExcenta - _Dcm_DescFinanBGrabada;
                    }
                    // -Fin- Calculos Modificados tomando en cuenta el descuento financiero    - Ignacio 07/06/2013
                    if (_Dcm_Monto > 0)
                    {
                        _Str_Cadena = "insert into TNOTACREDICPD (cgroupcomp,ccompany,cidnotacreditocxp,cproveedor,cproducto,ccajas,cunidades,cmontosimp,cmontoinvendi,cbasegrabada,cbasexcenta,cimpuesto,cmontototal,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Row[0].ToString() + "','" + _Row[1].ToString() + "','" + _Row[2].ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_ExcentaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ImpuestoCalculado) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Alicuota) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_UpdateTotalDetalleNC(_P_Str_Comp, _Int_Consecutivo.ToString(), _Row[0].ToString());
                    }
                    _Dcm_Monto_Sin_Impuesto = _Dcm_Monto_Sin_Impuesto + _Dcm_Monto;
                    //----------------------------------------
                    _Int_CantidadReg++;
                    if (_Int_CantidadReg == 6)
                    {
                        break;
                    }
                }

                //decimal _Dcm_Monto_Total = (Math.Round(_Dcm_Monto_Sin_Impuesto, 2) - Math.Round(_Dcm_Total_Invendible, 2)) + Math.Round(_Dcm_Impuesto, 2);
                decimal _Dcm_Monto_Total = (_Dcm_Monto_Sin_Impuesto - _Dcm_Total_Invendible) + _Dcm_Impuesto;
                //-------------------------------------------SOLUCION DE VARIAS FACTURAS UNA OC. DIFERENCIA DE PRECIO
                _Str_Cadena = "SELECT TMOTIVO.cdescripcion,TMOTIVO.cidmotivo FROM TCONFIGCOMP INNER JOIN TMOTIVO ON TCONFIGCOMP.cmotncsobrante = TMOTIVO.cidmotivo WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') and TMOTIVO.cdocumentnc='1'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_Motivo = "";
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Str_Descripcion = _Ds2.Tables[0].Rows[0][0].ToString() + " FACTURA# " + _Cmb_Fac.SelectedItem.ToString();
                    _Str_Motivo = _Ds2.Tables[0].Rows[0][1].ToString();

                }
                _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
                              "FROM TDOCUMENT INNER JOIN " +
                              "TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentfact " +
                              "WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
                DataSet _Ds4 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_TD = "";
                if (_Ds4.Tables[0].Rows.Count > 0)
                {
                    _Str_TD = _Ds4.Tables[0].Rows[0][0].ToString();
                }
                if (_Bol_Ascii)
                {
                    if (_Dcm_Monto_Sin_Impuesto > 0)
                    {
                        decimal _Dcm_AlicuotaM = 0;
                        if (_Dcm_Impuesto > 0)
                        {
                            _Dcm_AlicuotaM = _Mtd_Impuesto(_P_Str_Comp);
                        }
                        //---------------
                        _Dcm_Monto_Sin_Impuesto = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cmontosimp", _P_Str_Comp);
                        _Dcm_Impuesto = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cimpuesto", _P_Str_Comp);
                        _Dcm_Total_Invendible = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cmontoinvendi", _P_Str_Comp);
                        _Dcm_Monto_Total = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cmontototal", _P_Str_Comp);
                        _Dcm_Base_Grabada = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cbasegrabada", _P_Str_Comp);
                        _Dcm_Base_Excenta = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cbasexcenta", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        _Dcm_DescFinanBExcenta = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cdescfinanmontobexcenta", _P_Str_Comp);
                        _Dcm_DescFinanBGrabada = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cdescfinanmontobgrabada", _P_Str_Comp);
                        _Dcm_DescFinanTotal = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cdescfinanmonto", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        //---------------
                        _Str_Cadena = "insert into TNOTACREDICP (cgroupcomp,ccompany,cidnotacreditocxp,cproveedor,cfechanc,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cidmotivo,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Sin_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_TD + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Total_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Excenta) + "','" + _Str_Motivo + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_AlicuotaM) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanFactura) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONDFM", "cidnotacreditocxp='" + _Int_Consecutivo.ToString() + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'");
                    }
                }
                goto _Et_Retorno;
            }
        }

        private decimal _Mtd_Impuesto(string _P_Str_Comp)
        {
            string _Str_Sql = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCOMP ON TTAX.ctax = TCONFIGCOMP.ctax WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            return 0;
        }

        private void _Mtd_Credito_Sobrepresio(string _P_Str_Comp)
        {
        _Et_Retorno:
            string _Str_Cadena = "Select TRECEPCIONDDDOCF.cproducto,TRECEPCIONDDDOCF.cpreciodiferenc,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 from TRECEPCIONDDDOCF inner join TPRODUCTO on TPRODUCTO.cproducto=TRECEPCIONDDDOCF.cproducto where TRECEPCIONDDDOCF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRECEPCIONDDDOCF.cidrecepcion='" + _Txt_rec2.Text + "' and TRECEPCIONDDDOCF.cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and TRECEPCIONDDDOCF.cproveedor='" + _Str_Proveedor + "' AND TRECEPCIONDDDOCF.cdiferenciaprec='1' AND TRECEPCIONDDDOCF.caprobadifpdocu='1' AND NOT EXISTS(SELECT TNOTACREDICP.cnumdocu FROM TNOTACREDICP INNER JOIN TNOTACREDICPD ON TNOTACREDICP.cgroupcomp = TNOTACREDICPD.cgroupcomp AND TNOTACREDICP.ccompany = TNOTACREDICPD.ccompany AND TNOTACREDICP.cidnotacreditocxp = TNOTACREDICPD.cidnotacreditocxp AND TNOTACREDICP.cproveedor = TNOTACREDICPD.cproveedor WHERE TNOTACREDICP.cgroupcomp=TRECEPCIONDDDOCF.cgroupcomp AND TNOTACREDICP.cproveedor=TRECEPCIONDDDOCF.cproveedor AND TNOTACREDICP.cnumdocu=TRECEPCIONDDDOCF.cnfacturapro AND TNOTACREDICP.ccompany='" + _P_Str_Comp + "' AND TNOTACREDICPD.cproducto=TRECEPCIONDDDOCF.cproducto AND ISNULL(TNOTACREDICP.cdiferenciaprec,0)='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            int _Int_CantidadReg = 0;
            DataSet _Ds2 = new DataSet();
            decimal _Dcm_Monto_Sin_Impuesto = 0;
            decimal _Dcm_Total_Invendible = 0;
            decimal _Dcm_Impuesto = 0;
            decimal _Dcm_Base_Grabada = 0;
            decimal _Dcm_Base_Excenta = 0;
            decimal _Dcm_PorceDescFinanFactura = 0, _Dcm_PorceDescFinanD = 0, _Dcm_DescFinanTotal = 0, _Dcm_DescFinanBExcenta = 0, _Dcm_DescFinanBGrabada = 0, _Dcm_DescFinanImp = 0, _Dcm_TotalDescFinan = 0, _Dcm_TotalDescFinanImp = 0;
            string _Str_Descripcion = "";
            int _Int_Consecutivo = 0;
            bool _Bol_Orden = false;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Orden = true;
                _Int_Consecutivo = _Mtd_Consecutivo_TNOTACREDICP(_P_Str_Comp);
                _Dcm_PorceDescFinanFactura = _Mtd_ObtenerPorcentajeDescuentoFinancieroFactura(_Txt_rec2.Text, _Cmb_Fac.SelectedItem.ToString());
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    decimal _Dcm_Precio = 0;
                    decimal _Dcm_PrecioUni = 0;
                    decimal _Dcm_Monto = 0;
                    decimal _Dcm_Base_GrabadaD = 0;
                    decimal _Dcm_Base_ExcentaD = 0;
                    decimal _Dcm_Alicuota = 0;
                    _Str_Cadena = "Select cempaques,cunidades from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproducto='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        _Dcm_Precio = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                        _Dcm_PrecioUni = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][1].ToString());
                    }
                    //----------------------------------------------Descontar
                    decimal _Dcm_Descontar = 0;
                    decimal _Dcm_DescontarUni = 0;
                    _Str_Cadena = "Select cdiferenciaemp,cdiferenciauni from TRECEPCIONDDDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and  cfaltante='1' and cproducto='" + _Row[0].ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        DataRow _Rows = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                        if (_Rows[0] != System.DBNull.Value)
                        {
                            _Dcm_Descontar = Convert.ToDecimal(_Rows[0].ToString().Trim());
                        }
                        if (_Rows[1] != System.DBNull.Value)
                        {
                            _Dcm_DescontarUni = Convert.ToDecimal(_Rows[1].ToString().Trim());
                        }
                    }
                    if (_Dcm_Precio != _Dcm_Descontar)
                    {
                        _Dcm_Precio = _Dcm_Precio - _Dcm_Descontar;
                    }
                    if (_Dcm_PrecioUni != _Dcm_DescontarUni)
                    {
                        _Dcm_PrecioUni = _Dcm_PrecioUni - _Dcm_DescontarUni;
                    }
                    //----------------------------------------------Descontar
                    if (_Row[1] != System.DBNull.Value)
                    {
                        _Dcm_Monto = _Dcm_Precio * Convert.ToDecimal(_Row[1].ToString().Trim());
                        decimal _Dcm_UnidadesConvert = 0;
                        if (_Dcm_PrecioUni > 0)
                        {
                            if (_Row[3].ToString() != "")
                            {
                                if (Convert.ToInt32(_Row[3].ToString().Trim()) > 0)
                                {
                                    _Dcm_UnidadesConvert = Convert.ToInt32(_Row[2].ToString().Trim()) / Convert.ToInt32(_Row[3].ToString().Trim());
                                    if (_Dcm_UnidadesConvert > 0)
                                    {
                                        _Dcm_Monto += (Convert.ToDecimal(_Row[1].ToString().Trim()) / _Dcm_UnidadesConvert) * _Dcm_PrecioUni;
                                    }
                                }
                            }
                        }
                    }

                    //-----------------------------
                    _Str_Cadena = "Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "' and cdelete='0'";
                    decimal _Dcm_Invendible = 0;
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Dcm_Invendible = Convert.ToDecimal(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                        }
                    }
                    //-----------------------------
                    _Dcm_Invendible = ((_Dcm_Monto * _Dcm_Invendible) / 100);
                    _Dcm_Total_Invendible = _Dcm_Total_Invendible + _Dcm_Invendible;
                    _Dcm_Monto = _Dcm_Monto - _Dcm_Invendible;
                    _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Row[0].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    decimal _Dcm_ImpuestoCalculado = 0;
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            _Dcm_ImpuestoCalculado = (_Dcm_Monto * Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString())) / 100;
                            _Dcm_Impuesto = _Dcm_Impuesto + _Dcm_ImpuestoCalculado;
                            _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                            _Dcm_Base_Grabada = _Dcm_Base_Grabada + _Dcm_Monto;
                            _Dcm_Base_GrabadaD = _Dcm_Base_GrabadaD + _Dcm_Monto;
                            _Dcm_Alicuota = Convert.ToDecimal(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                        catch
                        {
                            _Dcm_Impuesto = _Dcm_Impuesto + 0;
                        }
                    }
                    else
                    {
                        _Dcm_Monto = _Dcm_Monto + _Dcm_Invendible;
                        _Dcm_Base_Excenta = _Dcm_Base_Excenta + _Dcm_Monto;
                        _Dcm_Base_ExcentaD = _Dcm_Base_ExcentaD + _Dcm_Monto;
                    }
                    //----------------------------------------
                    decimal _Dcm_Monto_Total_D = (_Dcm_Monto - _Dcm_Invendible) + _Dcm_ImpuestoCalculado;

                    _Str_Cadena = "SELECT cdescpp FROM TPRODUCTO WHERE cproducto = '" + _Row[0].ToString() + "' and cdelete = '0'";
                    var _DsProducto = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    var _Bool_ProductoConDescPp = _DsProducto.Tables[0].Rows[0][0].ToString() == "1";
                    if (!_Bool_ProductoConDescPp)
                    {
                        _Dcm_PorceDescFinanD = 0;
                        _Dcm_DescFinanBExcenta = 0;
                        _Dcm_DescFinanBGrabada = 0;
                        _Dcm_DescFinanTotal = 0;
                    }
                    else
                    {
                        _Dcm_PorceDescFinanD = _Dcm_PorceDescFinanFactura;
                    }

                    // -Inicio- Calculos Modificados tomando en cuenta el descuento financiero - Ignacio 07/06/2013
                    //Solo si la factura posee descuento financiero
                    if (_Dcm_PorceDescFinanD > 0)
                    {
                        //Calculo el descuento financiero de las bases
                        _Dcm_DescFinanBExcenta = (_Dcm_PorceDescFinanD * _Dcm_Base_ExcentaD) / 100;
                        _Dcm_DescFinanBGrabada = (_Dcm_PorceDescFinanD * _Dcm_Base_GrabadaD) / 100;

                        //Calculo el descuento financiero del impuesto
                        _Dcm_DescFinanImp = (_Dcm_DescFinanBGrabada * _Dcm_Alicuota) / 100;

                        //Truncamos
                        _Dcm_DescFinanBExcenta = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBExcenta, 2));
                        _Dcm_DescFinanBGrabada = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanBGrabada, 2));
                        _Dcm_DescFinanImp = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanImp, 2));
                        _Dcm_DescFinanTotal = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada), 2));

                        //Acumulamos
                        _Dcm_TotalDescFinan = _Dcm_TotalDescFinan + _Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada;
                        _Dcm_TotalDescFinanImp = _Dcm_TotalDescFinanImp + _Dcm_DescFinanImp;

                        //Descontamos a los totales
                        _Dcm_Monto = _Dcm_Monto - _Dcm_DescFinanTotal;
                        _Dcm_ImpuestoCalculado = _Dcm_ImpuestoCalculado - _Dcm_DescFinanImp;
                        _Dcm_Impuesto = _Dcm_Impuesto - _Dcm_DescFinanImp;
                        _Dcm_Monto_Total_D = _Dcm_Monto_Total_D - _Dcm_DescFinanBExcenta - _Dcm_DescFinanBGrabada;
                    }
                    // -Fin- Calculos Modificados tomando en cuenta el descuento financiero    - Ignacio 07/06/2013
                    if (_Dcm_Monto > 0)
                    {
                        _Str_Cadena = "insert into TNOTACREDICPD (cgroupcomp,ccompany,cidnotacreditocxp,cproveedor,cproducto,ccajas,cunidades,cmontosimp,cmontoinvendi,cbasegrabada,cbasexcenta,cimpuesto,cmontototal,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Row[0].ToString() + "','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_GrabadaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_ExcentaD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ImpuestoCalculado) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Alicuota) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_UpdateTotalDetalleNC(_P_Str_Comp, _Int_Consecutivo.ToString(), _Row[0].ToString());
                    }
                    //----------------------------------------
                    _Dcm_Monto_Sin_Impuesto = _Dcm_Monto_Sin_Impuesto + _Dcm_Monto;
                    _Int_CantidadReg++;
                    if (_Int_CantidadReg == 6)
                    {
                        break;
                    }
                }

                //decimal _Dcm_Monto_Total = (Math.Round(_Dcm_Monto_Sin_Impuesto, 2) - Math.Round(_Dcm_Total_Invendible, 2)) + Math.Round(_Dcm_Impuesto, 2);
                decimal _Dcm_Monto_Total = (_Dcm_Monto_Sin_Impuesto - _Dcm_Total_Invendible) + _Dcm_Impuesto;
                //-------------------------------------------SOLUCION DE VARIAS FACTURAS UNA OC. DIFERENCIA DE PRECIO
                _Str_Cadena = "SELECT TMOTIVO.cdescripcion,TMOTIVO.cidmotivo FROM TCONFIGCOMP INNER JOIN TMOTIVO ON TCONFIGCOMP.cmotncdiferprec = TMOTIVO.cidmotivo WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') and TMOTIVO.cdocumentnc='1'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_Motivo = "";
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Str_Descripcion = _Ds2.Tables[0].Rows[0][0].ToString() + " FACTURA# " + _Cmb_Fac.SelectedItem.ToString();
                    _Str_Motivo = _Ds2.Tables[0].Rows[0][1].ToString();

                }
                _Str_Cadena = "SELECT TDOCUMENT.ctdocument, TDOCUMENT.cname " +
                              "FROM TDOCUMENT INNER JOIN " +
                              "TCONFIGCOMP ON TDOCUMENT.ctdocument = TCONFIGCOMP.ctipodocumentfact " +
                              "WHERE (TCONFIGCOMP.ccompany = '" + _P_Str_Comp + "') AND (TDOCUMENT.cdelete = 0)";
                DataSet _Ds4 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_TD = "";
                if (_Ds4.Tables[0].Rows.Count > 0)
                {
                    _Str_TD = _Ds4.Tables[0].Rows[0][0].ToString();
                }
                if (_Bol_Orden)
                {
                    if (_Dcm_Monto_Sin_Impuesto > 0)
                    {
                        decimal _Dcm_AlicuotaM = 0;
                        if (_Dcm_Impuesto > 0)
                        {
                            _Dcm_AlicuotaM = _Mtd_Impuesto(_P_Str_Comp);
                        }
                        //---------------
                        _Dcm_Monto_Sin_Impuesto = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cmontosimp", _P_Str_Comp);
                        _Dcm_Impuesto = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cimpuesto", _P_Str_Comp);
                        _Dcm_Total_Invendible = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cmontoinvendi", _P_Str_Comp);
                        _Dcm_Monto_Total = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cmontototal", _P_Str_Comp);
                        _Dcm_Base_Grabada = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cbasegrabada", _P_Str_Comp);
                        _Dcm_Base_Excenta = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cbasexcenta", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        _Dcm_DescFinanBExcenta = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cdescfinanmontobexcenta", _P_Str_Comp);
                        _Dcm_DescFinanBGrabada = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cdescfinanmontobgrabada", _P_Str_Comp);
                        _Dcm_DescFinanTotal = _Mtd_SumMontoDetalleNC(_Int_Consecutivo.ToString(), "cdescfinanmonto", _P_Str_Comp);
                        //-- Descuento Finanaciero
                        //---------------
                        _Str_Cadena = "insert into TNOTACREDICP (cgroupcomp,ccompany,cidnotacreditocxp,cproveedor,cfechanc,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cdiferenciaprec,cporcinvendible,ctotaldocu,cbasegrabada,cbaseexcenta,cidmotivo,calicuota,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) values" + "('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Comp + "','" + _Int_Consecutivo.ToString() + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Sin_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Impuesto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_TD + "','" + _Cmb_Fac.SelectedItem.ToString() + "','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Total_Invendible) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto_Total) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Excenta) + "','" + _Str_Motivo + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_AlicuotaM) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PorceDescFinanFactura) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_DescFinanBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONDFM", "cidnotacreditocxpdf='" + _Int_Consecutivo.ToString() + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'");
                    }
                }
                goto _Et_Retorno;
            }
        }

        private int _Mtd_Consecutivo_TNOTADEBITOCP(string _P_Str_Comp)
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidnotadebitocxp FROM TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' ORDER BY cidnotadebitocxp  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;

            }
            catch
            {
                return 1;
            }
        }

        private int _Mtd_Consecutivo_TNOTACREDICP(string _P_Str_Comp)
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidnotacreditocxp FROM TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' ORDER BY cidnotacreditocxp  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;

            }
            catch
            {
                return 1;
            }
        }

        private bool _Mtd_Verificar_Grid_Descarga()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Descarga.Rows)
            {
                if (_Dg_Row.Cells["cfachavenc"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool _Mtd_Verificar_Costo_Producto(string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT cproducto FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "' AND ISNULL(ccostobruto_u1,0)>0 AND ISNULL(ccostoneto_u1,0)>0";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        private string _Mtd_RetornarInfProducto(string _P_Str_Producto, string _P_Str_Campo)
        {
            string _Str_Cadena = "SELECT cnamefc,dbo.Fnc_Formatear(ccostobruto_u1) AS ccostobruto_u1,dbo.Fnc_Formatear(ccostoneto_u1) AS ccostoneto_u1 FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][_P_Str_Campo].ToString();
        }

        private bool _Mtd_Validar_Costos()
        {
            _Dg_Productos.Rows.Clear();
            object[] _Ob = new object[4];
            foreach (DataGridViewRow _Dg_Row in _Dg_Descarga.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    if (!_Mtd_Verificar_Costo_Producto(Convert.ToString(_Dg_Row.Cells[0].Value).Trim()))
                    {
                        _Ob[0] = Convert.ToString(_Dg_Row.Cells[0].Value).Trim();
                        _Ob[1] = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), "cnamefc");
                        _Ob[2] = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), "ccostobruto_u1");
                        _Ob[3] = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), "ccostoneto_u1");
                        _Dg_Productos.Rows.Add(_Ob);
                    }
                }
            }
            _Dg_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            return _Dg_Productos.Rows.Count == 0;
        }

        private void _Bt_Comparar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (_Dg_Descarga.Rows.Count > 0)
                {
                    if (_Dg_Descarga.Rows[0].Cells[0].Value != null)
                    {
                        string _Str_Comp = _Mtd_CompProveedor(_Str_Proveedor);
                        if (_Str_Comp.Trim().Length > 0)
                        {
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccomparafactdes from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "'");
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                                {
                                    MessageBox.Show("Esta factura ya ha sido comparada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (_Mtd_Verificar_Grid_Descarga())
                                    {
                                        if (_Mtd_CostoBrutPrecioMaxVerificado())
                                        {
                                            if (_Mtd_VerificarUnidadesTodos())
                                            {
                                                if (_Mtd_ProductosInactivosFactura(_Txt_rec2.Text.Trim(), _Cmb_Fac.SelectedItem.ToString(), _Str_Proveedor))
                                                {
                                                    if (_Mtd_Validar_Costos())
                                                    {
                                                        _Mtd_CompararEspecial(_Str_Comp);

                                                        Frm_ASCII_FAC _Frm = new Frm_ASCII_FAC(_Cmb_Fac.SelectedItem.ToString(), _Txt_rec2.Text, _Str_Proveedor);
                                                        _Frm.MdiParent = this.MdiParent;
                                                        _Frm.Show();
                                                        //_Mtd_ImprimirRecepcionVencimiento();
                                                        this.Close();

                                                    }
                                                    else
                                                    {
                                                        _Pnl_Productos.Visible = true;
                                                        //MessageBox.Show("Existen productos con costos iguales a cero(0)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Las unidades marcadas en amarillo sobrepasan el máximo permitido. Debe corregir la información para continuar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Existen registros sin costo bruto, precio máximo o precio de lista. Debe completar la información en las celdas marcadas en amarillo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Existen productos sin fecha de vencimiento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            else
                            {
                                if (_Mtd_Verificar_Grid_Descarga())
                                {
                                    if (_Mtd_CostoBrutPrecioMaxVerificado())
                                    {
                                        if (_Mtd_VerificarUnidadesTodos())
                                        {
                                            if (_Mtd_Validar_Costos())
                                            {
                                                _Mtd_CompararEspecial(_Str_Comp);
                                                Frm_ASCII_FAC _Frm = new Frm_ASCII_FAC(_Cmb_Fac.SelectedItem.ToString(), _Txt_rec2.Text, _Str_Proveedor);
                                                _Frm.MdiParent = this.MdiParent;
                                                _Frm.Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                _Pnl_Productos.Visible = true;
                                                //MessageBox.Show("Existen productos con costos iguales a cero(0)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Las unidades marcadas en amarillo sobrepasan el máximo permitido. Debe corregir la información para continuar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Existen registros sin costo bruto, precio máximo o precio de lista. Debe completar la información en las celdas marcadas en amarillo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Existen productos sin fecha de vencimiento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Problemas al obtener compañía del proveedor. Informar al administrador del sistema.", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen registros para realizar la comparación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No existen registros para realizar la comparación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            Cursor = Cursors.Default;
        }

        private bool _Mtd_DescargaRealizada(string _P_Str_Recepcion, string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT cproducto FROM TRECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND NOT cfachavenc IS NULL";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        private void _Cmb_Fac_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (_Cmb_Fac.SelectedIndex != -1)
            {
                string _Str_Sql = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_RECEPCIONDD.cproducto) AS Producto,cempaques AS Cajas,cunidades AS Unidades,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista,cfachavenc,' ' as Campo FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "'";
                //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //_Dg_Descarga.DataSource = _Ds.Tables[0];
                _Mtd_Readonly(_Str_Sql);
                _Dg_Descarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                if (_Mtd_DescargaRealizada(_Txt_rec2.Text.Trim(), _Cmb_Fac.Text.Trim()))
                {
                    _Bt_Descargar.Enabled = false;
                    _Bt_Comparar.Enabled = false;
                    _Bt_Eliminar.Enabled = false;
                }
                else
                {
                    _Bt_Descargar.Enabled = true;
                    _Bt_Comparar.Enabled = true;
                    _Bt_Eliminar.Enabled = true;
                }
            }
        }

        private void _Txt_Recep_TextChanged(object sender, EventArgs e)
        {
            _Txt_rec2.Text = _Txt_Recep.Text;
        }

        private void _Mtd_Cargar_Grid_Estatus()
        {
            _Dg_Estatus.Rows.Clear();
            string _Str_Cadena = "SELECT DISTINCT cdate,cnfacturapro,cnotarecepcion,cidnotacreditocxp,cidnotadebitocxp from  vst_estatusgeneral where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object[] _Obj = new object[5];
            int _Int_i = 0;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Obj[0] = _Row[0].ToString().Substring(0, 10);
                _Obj[1] = _Row[1].ToString();
                if (_Row[2].ToString() == "1")
                {
                    _Obj[2] = "1";
                }
                else
                {
                    _Obj[2] = "0";
                }

                if (_Row[3].ToString().Trim().Length > 0 & _Row[3].ToString().Trim() != "0")
                {
                    _Obj[3] = "1";
                }
                else
                {
                    _Obj[3] = "0";
                }

                if (_Row[4].ToString().Trim().Length > 0 & _Row[4].ToString().Trim() != "0")
                {
                    _Obj[4] = "1";
                }
                else
                {
                    _Obj[4] = "0";
                }

                _Dg_Estatus.Rows.Add(_Obj);
                _Int_i++;
            }
        }

        private bool _Mtd_Verificar_Facturas(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT DISTINCT cdate,cnfacturapro,cnotarecepcion,cidnotacreditocxp,cidnotadebitocxp from  vst_estatusgeneral where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Recepcion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            bool _Bol_Facturas = false;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                if (_Row[2].ToString() != "1")
                {
                    return false;
                }
                _Bol_Facturas = true;
            }
            if (!_Bol_Facturas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void _Bt_GNR_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Verifica si no se le ha cargado ninguna factura
        /// </summary>
        private bool _Mtd_SoloMaestra(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT cidrecepcion FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0;
        }

        private void cerrarRecepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                if (_Mtd_Verificar_Facturas(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()) | _Mtd_SoloMaestra(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()))
                {
                    if (MessageBox.Show("¿Esta seguro de cerrar esta recepción?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_Mtd_Verificar_Facturas(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim()) | _Mtd_SoloMaestra(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value).Trim())) //Verifico nuevamente
                        {
                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "ccerrada='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' and cproveedor='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cproveedor"].Value.ToString() + "'");
                            _Mtd_Actualizar();
                            _Mtd_Cargar();
                            _Dpt_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                            _Dg_Estatus.Rows.Clear();
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                            MessageBox.Show("La recepción fue cerrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se puedo cerrar la recepción. Otro usuario ha realizado procesos con la recepción", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Esta recepción no puede ser cerrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void _Bt_NR_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[2].Value.ToString() == "1")
                {
                    string _Str_Comp = _Mtd_CompProveedor(_Str_Proveedor);
                    string _Str_Cadena = "Select cnotarecepcion from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cproveedor='" + _Str_Proveedor + "' and cnfacturapro='" + _Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "Select cidnotrecepc,cfechanotrecep,cimpreso from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and  cnumdocu='" + _Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            _Lbl_Titulo.Text = "Nota de Recepción";
                            _Lbl_Numero.Text = "Nota de Recepción Nº: " + _Ds2.Tables[0].Rows[0][0].ToString();
                            _Lbl_Fecha.Text = "Fecha: " + Convert.ToDateTime(_Ds2.Tables[0].Rows[0][1].ToString()).ToString(("dd/MM/yyyy"));
                            if (_Ds2.Tables[0].Rows[0][2].ToString() == "1")
                            {
                                _Lbl_Impreso.Text = "El documento fue impreso";
                            }
                            else
                            {
                                _Lbl_Impreso.Text = "El documento no fue impreso";
                            }
                            _Dg_Estatus.Enabled = false;
                            _Pnl_Clave.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La factura seleccionada no posee nota de recepción", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void _Bt_ND_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[4].Value.ToString() == "1")
                {
                    string _Str_Comp = _Mtd_CompProveedor(_Str_Proveedor);
                    string _Str_Cadena = "Select cidnotadebitocxp from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cproveedor='" + _Str_Proveedor + "' and cnfacturapro='" + _Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "Select cidnotadebitocxp,cfechand,cimpresa from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cproveedor='" + _Str_Proveedor + "' and  cnumdocu='" + _Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            _Lbl_Titulo.Text = "Nota de Débito";
                            _Lbl_Numero.Text = "Nota de Débito Nº: " + _Ds2.Tables[0].Rows[0][0].ToString();
                            _Lbl_Fecha.Text = "Fecha: " + Convert.ToDateTime(_Ds2.Tables[0].Rows[0][1].ToString()).ToString(("dd/MM/yyyy"));
                            if (_Ds2.Tables[0].Rows[0][2].ToString() == "1")
                            {
                                _Lbl_Impreso.Text = "El documento fue impreso";
                            }
                            else
                            {
                                _Lbl_Impreso.Text = "El documento no fue impreso";
                            }
                            _Dg_Estatus.Enabled = false;
                            _Pnl_Clave.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La factura seleccionada no posee nota de débito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void _Bt_NC_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[3].Value.ToString() == "1")
                {
                    string _Str_Comp = _Mtd_CompProveedor(_Str_Proveedor);
                    string _Str_Cadena = "Select cidnotacreditocxp from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cproveedor='" + _Str_Proveedor + "' and cnfacturapro='" + _Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "Select cidnotacreditocxp,cfechanc,cimpresa from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Str_Comp + "' and cproveedor='" + _Str_Proveedor + "' and  cnumdocu='" + _Dg_Estatus.Rows[_Dg_Estatus.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            _Lbl_Titulo.Text = "Nota de Crédito";
                            _Lbl_Numero.Text = "Nota de Crédito Nº: " + _Ds2.Tables[0].Rows[0][0].ToString();
                            _Lbl_Fecha.Text = "Fecha: " + Convert.ToDateTime(_Ds2.Tables[0].Rows[0][1].ToString()).ToString(("dd/MM/yyyy"));
                            if (_Ds2.Tables[0].Rows[0][2].ToString() == "1")
                            {
                                _Lbl_Impreso.Text = "El documento fue impreso";
                            }
                            else
                            {
                                _Lbl_Impreso.Text = "El documento no fue impreso";
                            }
                            _Dg_Estatus.Enabled = false;
                            _Pnl_Clave.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La factura seleccionada no posee nota de crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Dg_Estatus.Enabled = true;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Dg_Estatus.Enabled = true;
        }

        private void _Cbox_Pro_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _Str_cadena = "Select cevaluado from TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "' and cproveedor='" + _Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        _Str_cadena = "SELECT cnfacturapro from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            string[] _Str_Facturas = new string[_Ds.Tables[0].Rows.Count];
                            int _Int_i = 0;
                            foreach (DataRow _Row in _Ds.Tables[0].Rows)
                            {
                                _Str_Facturas[_Int_i] = _Row[0].ToString();
                                _Int_i++;
                            }
                            _Str_cadena = "Select ctdiferencia from TRECEPCIONTDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Recep.Text + "'";
                            DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
                            if (_Ds2.Tables[0].Rows.Count > 0)
                            {
                                _Str_cadena = _Ds2.Tables[0].Rows[0][0].ToString();
                                Frm_OC_FAC _Frm = new Frm_OC_FAC(_Txt_Recep.Text, _Str_Proveedor, Convert.ToInt32(_Str_cadena), _Str_Facturas, true);
                                _Frm.MdiParent = this.MdiParent;
                                _Frm.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La recepción aun no ha sido evaluada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Cmb_Fac.SelectedIndex == -1)
            {
                MessageBox.Show("Los datos para realizar esta operación no estan completos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_Mtd_DescargaRealizada(_Txt_rec2.Text.Trim(), _Cmb_Fac.Text.Trim()))
            {
                MessageBox.Show("La factura ya fue comparada, no se permite agregar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TextBox _Txt_Codigo = new TextBox();
            TextBox _Txt_Codigo2 = new TextBox();
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Producto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cod.Fabric");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cproducto";
            _Str_Campos[1] = "ccodfabrica";
            _Str_Campos[2] = "cnamef";
            //genero la la parte de la consulta que evita la duplicidad de los productos
            string _Str_EvitarProductosDuplicados = _Mtd_GenerarWhereEvitaProductosDuplicados();
            string _Str_Cadena = "SELECT cproducto as Producto,ccodfabrica as [Cod.Fabric],CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as Descripción FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE tproducto.cproveedor=" + _Str_Proveedor + " AND tproducto.CACTIVATE='1' " + _Str_EvitarProductosDuplicados;
            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Codigo, _Txt_Codigo2, _Str_Cadena, _Str_Campos, "Agregar Producto", _Tsm_Menu, 0, 1);
            //Muestro el formulario
            _Frm.ShowDialog();
            //Verifico si se seselecciono algun producto
            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Codigo2.Text.Trim().Length > 0)
            {
                _Str_CodProd = _Txt_Codigo.Text.Trim();
                _Str_CodFab = _Txt_Codigo2.Text.Trim();

                //Cargamos el producto
                string _Str_SQL = "SELECT cproducto,ccodfabrica,ccodcorrugado,CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as Descripcion FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE tproducto.cproducto='" + _Str_CodProd + "' ";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                //Inicializmos el panel
                _Lbl_EtiquetaPanel.Text = "Agregar Producto";
                _Bt_AgregarEditar.Text = "Agregar";

                //Paso los datos
                _Txt_Producto_AgregarEditar.Text = _Ds.Tables[0].Rows[0]["cproducto"].ToString();
                _Txt_CodFabricante_AgregarEditar.Text = _Ds.Tables[0].Rows[0]["ccodfabrica"].ToString();
                _Txt_Corrugado_AgregarEditar.Text = _Ds.Tables[0].Rows[0]["ccodcorrugado"].ToString();
                _Txt_Descripcion_AgregarEditar.Text = _Ds.Tables[0].Rows[0]["Descripcion"].ToString();
                _Txt_Empaques_AgregarEditar.Text = "";
                _Txt_Unidades_AgregarEditar.Text = "";
                //decimal _Dc_Pmv_ParaValidar = _Cls_VariosMetodos._Mtd_ObtenerPMV(_Txt_Producto_AgregarEditar.Text);
                _Txt_PMV_AgregarEditar.Text = "0";//_Dc_Pmv_ParaValidar.ToString("#,##0.00");

                //Activo los controles
                _Txt_Empaques_AgregarEditar.ReadOnly = false;
                _Txt_Empaques_AgregarEditar.Enabled = true;
                _Txt_Unidades_AgregarEditar.ReadOnly = false;
                _Txt_Unidades_AgregarEditar.Enabled = true;
                _Txt_PMV_AgregarEditar.Enabled = _Mtd_ObligatorioPMV(_Txt_Producto_AgregarEditar.Text);

                //Centramos el Panel
                _Pnl_AgregarEditarProducto.Left = (this.Width / 2) - (_Pnl_AgregarEditarProducto.Width / 2);
                _Pnl_AgregarEditarProducto.Top = (this.Height / 2) - (_Pnl_AgregarEditarProducto.Height / 2);
                //Mostramos el Panel
                _Pnl_AgregarEditarProducto.Visible = true;
                //Desactivamos el grid
                _Dg_Descarga.Enabled = false;

            }
        }

        private void editarPMVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Descarga.Rows.Count > 0)
            {
                if (_Cmb_Fac.SelectedIndex == -1)
                {
                    MessageBox.Show("Los datos para realizar esta operación no estan completos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (_Mtd_DescargaRealizada(_Txt_rec2.Text.Trim(), _Cmb_Fac.Text.Trim()))
                {
                    MessageBox.Show("La factura ya fue comparada, no se permite editar PMV", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //verificamos si el producto seleccionado a editar requiere o no PMV
                if (!_Mtd_ObligatorioPMV(_Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()))
                {
                    MessageBox.Show("El Producto seleccionado para editar no requiere PMV", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Inicializmos el panel
                _Lbl_EtiquetaPanel.Text = "Editar PMV del Producto";
                _Bt_AgregarEditar.Text = "Editar";

                //Paso los datos
                _Txt_Producto_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
                _Txt_CodFabricante_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim();
                _Txt_Corrugado_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim();
                _Txt_Descripcion_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim();
                _Txt_Empaques_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells["cempaques"].Value.ToString().Trim();
                _Txt_Unidades_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells["cunidades"].Value.ToString().Trim();
                _Txt_PMV_AgregarEditar.Text = _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells["cprecioventamax"].Value.ToString().Trim();
                //Sprint 15//string dtFechaFactura = _Mtd_ObtenerFechaFactura(_Txt_rec2.Text.Trim(), _Cmb_Fac.SelectedItem.ToString());
                //Sprint 15//CargarComboPMV(_Txt_Producto_AgregarEditar.Text, Convert.ToDateTime(dtFechaFactura), ref _Cmb_PMV_AgregarEditar);

                //Activo los controles
                _Txt_Empaques_AgregarEditar.ReadOnly = true;
                _Txt_Empaques_AgregarEditar.Enabled = false;
                _Txt_Unidades_AgregarEditar.ReadOnly = true;
                _Txt_Unidades_AgregarEditar.Enabled = false;
                _Txt_PMV_AgregarEditar.Enabled = _Mtd_ObligatorioPMV(_Txt_Producto_AgregarEditar.Text);

                //Centramos el Panel
                _Pnl_AgregarEditarProducto.Left = (this.Width / 2) - (_Pnl_AgregarEditarProducto.Width / 2);
                _Pnl_AgregarEditarProducto.Top = (this.Height / 2) - (_Pnl_AgregarEditarProducto.Height / 2);
                //Mostramos el Panel
                _Pnl_AgregarEditarProducto.Visible = true;
                //Desactivamos el grid
                _Dg_Descarga.Enabled = false;
            }
        }

        private void _Bt_AgregarEditar_Click(object sender, EventArgs e)
        {
            if (_Bt_AgregarEditar.Text == "Agregar")
            {
                //Si estamos agregando Producto

                //Valida los valores
                if (_Txt_Empaques_AgregarEditar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe introducir la cantidad de empaques", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (_Txt_Unidades_AgregarEditar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe introducir la cantidad de unidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (_Txt_PMV_AgregarEditar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe introducir un PMV", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!_Mtd_EsNumerico(_Txt_Empaques_AgregarEditar.Text))
                    return;
                if (!_Mtd_EsNumerico(_Txt_Unidades_AgregarEditar.Text))
                    return;
                if (!_Mtd_EsNumerico(_Txt_PMV_AgregarEditar.Text))
                    return;


                //Valido las Unidades
                if (!_Mtd_EsValidoUnidades(_Txt_Producto_AgregarEditar.Text, Convert.ToInt32(_Txt_Unidades_AgregarEditar.Text)))
                    return;


                //verificamos si el producto seleccionado a editar requiere o no PMV
                if (_Mtd_ObligatorioPMV(_Txt_Producto_AgregarEditar.Text))
                {
                    //Tomamos el valor 
                    decimal _Dc_Pmv_Ingresado = Convert.ToDecimal(_Txt_PMV_AgregarEditar.Text);

                    //Esta validacion es solo cuando el producto no es con regulacion flexible
                    if (!_Cls_VariosMetodos._Mtd_ProductoEsConRegulacionFlexible(_Txt_Producto_AgregarEditar.Text))
                    {
                        //Valido que el PMV no sea cero
                        if (_Dc_Pmv_Ingresado == 0)
                        {
                            MessageBox.Show("El PMV ingresado no puede ser cero (0)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //Valido el PMV si no esta configurado el PMV
                    bool _Bol_EsValidoPMV = true, _Bol_NoTienePMV = true;

                    _Bol_EsValidoPMV = _Cls_VariosMetodos._Mtd_VerificarPMV(_Txt_Producto_AgregarEditar.Text, _Dc_Pmv_Ingresado, out _Bol_NoTienePMV);

                    if (!_Bol_NoTienePMV)
                    {
                        MessageBox.Show("El producto requiere PMV pero no esta configurado", "Validación",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //Valido el PMV ingresado por el usuario
                    if (!_Bol_EsValidoPMV)
                    {
                        MessageBox.Show("El PMV ingresado no es igual al PMV manejado por el producto", "Validación",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                //Si llegamos aqui, agregamos la Fila
                _Mtd_AgregarProducto();

                //Cargamos de nuevo el grid
                string _Str_Sql = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_RECEPCIONDD.cproducto) AS Producto,cempaques AS Cajas,cunidades AS Unidades,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista,cfachavenc,' ' as Campo FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "'";
                _Mtd_Readonly(_Str_Sql);
                _Dg_Descarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            }
            else
            {
                //Si estamos editando PMV

                if (_Txt_PMV_AgregarEditar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe introducir un PMV", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!_Mtd_EsNumerico(_Txt_PMV_AgregarEditar.Text))
                    return;

                //Tomamos el valor 
                decimal _Dc_Pmv_Ingresado = Convert.ToDecimal(_Txt_PMV_AgregarEditar.Text);

                //Esta validacion es solo cuando el producto no es con regulacion flexible
                if (!_Cls_VariosMetodos._Mtd_ProductoEsConRegulacionFlexible(_Txt_Producto_AgregarEditar.Text))
                {
                    //Valido que el PMV no sea cero
                    if (_Dc_Pmv_Ingresado == 0)
                    {
                        MessageBox.Show("El PMV ingresado no puede ser cero (0)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                //Valido el PMV si no esta configurado el PMV
                bool _Bol_EsValidoPMV = true, _Bol_NoTienePMV = true;

                _Bol_EsValidoPMV = _Cls_VariosMetodos._Mtd_VerificarPMV(_Txt_Producto_AgregarEditar.Text, _Dc_Pmv_Ingresado, out _Bol_NoTienePMV);

                if (!_Bol_NoTienePMV)
                {
                    MessageBox.Show("El producto requiere PMV pero no esta configurado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Valido el PMV ingresado por el usuario
                if (!_Bol_EsValidoPMV)
                {
                    MessageBox.Show("El PMV ingresado no es igual al PMV manejado por el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Si llegamos aqui, editamos la Fila
                _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[7].Value = _Dc_Pmv_Ingresado.ToString("#,##0.00");

            }

            //Ocultamos el Panel
            _Pnl_AgregarEditarProducto.Visible = false;

            //Activamos el grid
            _Dg_Descarga.Enabled = true;
        }

        private string _Mtd_GenerarWhereEvitaProductosDuplicados()
        {
            string strResultado = "";
            string strCadena = "";
            foreach (DataGridViewRow oFila in _Dg_Descarga.Rows)
            {
                if (strCadena.Length != 0)
                    strCadena += ",";
                strCadena += "'" + oFila.Cells[0].Value + "'";
            }
            if (strCadena.Length != 0)
            {
                strResultado += " AND ";
                strResultado += " cproducto ";
                strResultado += " NOT IN ";
                strResultado += "(";
                strResultado += strCadena;
                strResultado += ") ";
            }
            return strResultado;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Mtd_DescargaRealizada(_Txt_rec2.Text.Trim(), _Cmb_Fac.Text.Trim()))
            {
                MessageBox.Show("La factura ya fue comparada, no se permite eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_Dg_Descarga.Rows.Count > 0)
            {
                if (_Cmb_Fac.SelectedIndex == -1)
                {
                    MessageBox.Show("Los datos para realizar esta operación no estan completos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (_Mtd_DescargaRealizada(_Txt_rec2.Text.Trim(), _Cmb_Fac.Text.Trim()))
                {
                    MessageBox.Show("La factura ya fue comparada, no se permite eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string _Str_Cadena = "Delete from TRECEPCIONDD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text.Trim() + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='" + _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                //_Str_Cadena = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_RECEPCIONDD.cproducto) AS Producto,cempaques AS Empaques,cunidades AS Unidades,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista,cfachavenc,' ' as Campo FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "'";
                _Str_Cadena = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_RECEPCIONDD.cproducto) AS Producto,cempaques AS Empaques,cunidades AS Unidades,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista,cfachavenc,' ' as Campo FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "' and cproveedor='" + _Str_Proveedor + "'";
                //_Str_Cadena = "SELECT cproducto AS [Cod Producto],ccodfabrica,ccodcorrugado as Corrugado,(SELECT TOP 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END FROM TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca WHERE TPRODUCTO.cproducto=VST_RECEPCIONDD.cproducto) AS Producto,cempaques AS Empaques,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(cpreciolista,0) AS cpreciolista,cunidades AS Unidades FROM VST_RECEPCIONDD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND cidrecepcion='" + _Txt_rec2.Text + "' AND cnfacturapro='" + _Cmb_Fac.Text + "' and cproveedor='" + _Str_Proveedor + "'";
                _Mtd_Readonly(_Str_Cadena);
                _Dg_Descarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }

        }

        private bool _Mtd_CostoBrutPrecioMaxVerificado()
        {
            bool _Bol_Return = true;
            foreach (DataGridViewRow _Dg_Rows in _Dg_Descarga.Rows)
            {
                _Dg_Rows.Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                _Dg_Rows.Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                _Dg_Rows.Cells["cprecioventamax"].Style.BackColor = Color.FromArgb(255, 255, 192);
                if (_Dg_Rows.Cells[4].Value != null)
                {
                    decimal _Dcm_ccostobrutolote = 0;
                    decimal _Dcm_cprecioventamax = 0;
                    decimal _Dcm_cpreciolista = 0;
                    decimal.TryParse(Convert.ToString(_Dg_Rows.Cells["ccostobrutolote"].Value).Trim(), out _Dcm_ccostobrutolote);
                    decimal.TryParse(Convert.ToString(_Dg_Rows.Cells["cprecioventamax"].Value).Trim(), out _Dcm_cprecioventamax);
                    decimal.TryParse(Convert.ToString(_Dg_Rows.Cells["cpreciolista"].Value).Trim(), out _Dcm_cpreciolista);
                    if (_Dcm_ccostobrutolote == 0)
                    {
                        _Dg_Rows.Cells["ccostobrutolote"].Style.BackColor = Color.Yellow;
                        _Bol_Return = false;
                    }

                    //Validacion de regulacion flexible
                    var _Str_cproducto = Convert.ToString(_Dg_Rows.Cells["ProductoInterno"].Value).Trim();
                    bool _Bol_cprecioventamax_Correcto;
                    if (_Cls_VariosMetodos._Mtd_ProductoEsConRegulacionFlexible(_Str_cproducto))
                    {
                        _Bol_cprecioventamax_Correcto = _Dcm_cprecioventamax == 0 || _Dcm_cprecioventamax > 0;
                    }
                    else
                    {
                        _Bol_cprecioventamax_Correcto = _Dcm_cprecioventamax > 0;
                    }

                    if (!_Bol_cprecioventamax_Correcto && _Mtd_ObligatorioPMV(Convert.ToString(_Dg_Rows.Cells["ProductoInterno"].Value).Trim()) && !_Mtd_ProductoRechazadoPorPMVDif(Convert.ToString(_Dg_Rows.Cells["ProductoInterno"].Value).Trim()))
                    {
                        _Dg_Rows.Cells["cprecioventamax"].Style.BackColor = Color.Yellow;
                        _Bol_Return = false;
                    }
                    if (_Dcm_cpreciolista == 0)
                    {
                        _Dg_Rows.Cells["cpreciolista"].Style.BackColor = Color.Yellow;
                        _Bol_Return = false;
                    }
                }
            }
            return _Bol_Return;
        }

        private void _Mtd_SobrescribirAscii()
        {
            foreach (DataGridViewRow _Dg_Rows in _Dg_Descarga.Rows)
            {
                if (_Dg_Rows.Cells[4].Value != null)
                {
                    decimal _Dcm_ccostobrutolote = 0;
                    decimal _Dcm_cprecioventamax = 0;
                    decimal _Dcm_cpreciolista = 0;
                    decimal.TryParse(Convert.ToString(_Dg_Rows.Cells["ccostobrutolote"].Value).Trim(), out _Dcm_ccostobrutolote);
                    decimal.TryParse(Convert.ToString(_Dg_Rows.Cells["cprecioventamax"].Value).Trim(), out _Dcm_cprecioventamax);
                    decimal.TryParse(Convert.ToString(_Dg_Rows.Cells["cpreciolista"].Value).Trim(), out _Dcm_cpreciolista);
                    string _Str_Cadena = "Update TRECEPCIONDD set cempaques='" + _Dg_Rows.Cells["cempaques"].Value.ToString() + "',cunidades='" + _Dg_Rows.Cells["cunidades"].Value.ToString() + "',ccostobrutolote='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ccostobrutolote) + "',cprecioventamax='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cprecioventamax) + "',cpreciolista='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cpreciolista) + "',cfachavenc='" + _Dg_Rows.Cells["cfachavenc"].Value.ToString() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text.Trim() + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproveedor='" + _Str_Proveedor + "' and cproducto='" + _Dg_Rows.Cells[0].Value.ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_Dg_Descarga.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar la descarga?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string _Str_Cadena = "Delete from TRECEPCIONDD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text.Trim() + "' and cnfacturapro='" + _Cmb_Fac.SelectedItem.ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Dg_Descarga.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("No existe ninguna descarga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Mtd_MensajesError(int _P_Int_Row, int _P_Int_Col, DataGridView _Dg_Grid2)
        {
            try
            {
                if (_P_Int_Col == 4 & (_P_Int_Col != 7) & _P_Int_Col == 5)
                {
                    if (!_Mtd_IsNumeric(_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value) | _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().IndexOf(".") >= 0 | _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().IndexOf(",") == 0)
                    {
                        if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(".") >= 0)
                        {
                            MessageBox.Show("No debe Introducir puntos (.) en el monto");
                        }
                        else if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == 0)
                        {
                            MessageBox.Show("No debe Introducir comas (,) al inicio del monto");
                        }
                        else if (!_Mtd_IsNumeric(_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value))
                        {
                            MessageBox.Show("No debe Introducir valores alfanuméricos en los montos");
                        }
                        _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                    }
                    else
                    {
                        if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().Length - 1)
                        {
                            _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString() + "0";
                        }
                        else if (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") > 0 & _P_Int_Col != 4 & _P_Int_Col != 5)
                        {
                            string _Str_Cadena = _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().Substring(_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().IndexOf(",") + 1);
                            if (_Str_Cadena.IndexOf(",") >= 0)
                            {
                                MessageBox.Show("No debe Introducir mas de una coma (,) en un monto");
                                _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                            }
                        }
                        else if ((_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") >= 0 & _P_Int_Col == 4) || (_Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") >= 0 & _P_Int_Col == 5))
                        {
                            MessageBox.Show("No debe Introducir decimales en los empaques y/o unidades");
                            _Dg_Grid2.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void _Mtc_Calendar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Mtc_Calendar.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;

            }
        }

        private void _Dg_Descarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 & _Dg_Descarga.Rows.Count > 0 & _Dg_Descarga.CurrentCell != null)
            {
                if (_Dg_Descarga.CurrentCell.RowIndex > -1)
                {
                    _Pnl_Feha.Visible = true;
                }
            }
        }

        private void _Pnl_Feha_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Feha.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Bt_AceptarFecha_Click(object sender, EventArgs e)
        {
            if (_Mtc_Calendar.SelectionStart.Date < CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Date)
            {
                MessageBox.Show("La fecha de vencimiento no puede ser menor a la fecha actual", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (_Chbox_Todos.Checked)
                {
                    foreach (DataGridViewRow _DgRow in _Dg_Descarga.Rows)
                    {
                        _DgRow.Cells["cfachavenc"].Value = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Mtc_Calendar.SelectionStart.Date);
                    }
                }
                else
                {
                    _Dg_Descarga.Rows[_Dg_Descarga.CurrentCell.RowIndex].Cells["cfachavenc"].Value = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Mtc_Calendar.SelectionStart.Date);
                }
                _Pnl_Feha.Visible = false;
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

        private void _Dg_Descarga_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgDescargaInfo.Visible = true;
            }
            else
            {
                _Lbl_DgDescargaInfo.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if ((!_Txt_Placa.Enabled & _Txt_Placa.Text.Trim().Length == 0 & e.TabPageIndex != 0 & _Bol_Menu) | ((_Txt_Placa.Enabled | (!_Txt_Placa.Enabled & _Txt_Placa.Text.Trim().Length > 0)) & (e.TabPageIndex != 0 & e.TabPageIndex != 2) & _Bol_Menu) | (_Txt_Placa.Text.Trim().Length == 0 & e.TabPageIndex != 0 & !_Bol_Menu))
            {
                e.Cancel = true;
            }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Deshabilitar_Todo();
                _Mtd_Ini();
                _Dg_Descarga.Rows.Clear();
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cproveedor,cdate,cplaca,cobservacion,cuserrecibe from TRECEPCIONM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Recep.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (_Cbox_Pro.DataSource != null)
                {
                    _Cbox_Pro.SelectedValue = _Row[0].ToString();
                }
                try
                {
                    _Str_Proveedor = _Row[0].ToString();
                    _Txt_Proveedor.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select c_nomb_abreviado from TPROVEEDOR where cproveedor='" + _Row[0].ToString() + "' and cdelete='0'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                }
                _Dpt_Fecha.Value = Convert.ToDateTime(_Row[1].ToString());
                _Txt_Placa.Text = _Row[2].ToString();
                _Txt_Obs.Text = _Row[3].ToString();
                _Txt_User.Text = _Row[4].ToString();
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cname from TUSER where cuser='" + _Txt_User.Text + "' and cdelete='0'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_UserDes.Text = _Ds.Tables[0].Rows[0][0].ToString();
                }
                _Mtd_Cargar_Grid_Estatus();
                //-----------------------------------------------
                _Mtd_DescargaFactCargar(_Str_Proveedor);
                Cursor = Cursors.Default;
                if (_Bol_Menu)
                {
                    _Tb_Tab.SelectedIndex = 2;
                }
                else
                {
                    _Tb_Tab.SelectedIndex = 1;
                }
            }
        }

        private void _Bt_AceptarP_Click(object sender, EventArgs e)
        {
            _Pnl_Productos.Visible = false;
        }

        private void _Pnl_Productos_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Productos.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private string _Str_NumeroTemp = "";

        private void _Dg_Descarga_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Dg_Descarga.CurrentCell != null)
            {
                if (e.RowIndex != -1 & (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 8))
                {
                    _Str_NumeroTemp = Convert.ToString(_Dg_Descarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }
            }
        }

        private bool _Mtd_VerificarUnidadesTodos()
        {
            bool _Bol_Retorno = true;
            bool _Bol_Temp = true;
            int _Int_NumeroTemp = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Descarga.Rows)
            {
                _Int_NumeroTemp = 0;
                int.TryParse(Convert.ToString(_Dg_Row.Cells["cunidades"].Value).Trim(), out _Int_NumeroTemp);
                _Bol_Temp = _Mtd_ValidacionUnidades(_Int_NumeroTemp, _Dg_Row.Index, false);
                if (!_Bol_Temp)
                {
                    _Bol_Retorno = false;
                }
            }
            return _Bol_Retorno;
        }

        private bool _Mtd_ValidacionUnidades(int _P_Int_Unidades, int _P_Int_RowIndex, bool _P_Bol_Mensaje)
        {
            if (_P_Int_Unidades > 0)
            {
                string _Str_CodProducto = Convert.ToString(_Dg_Descarga.Rows[_P_Int_RowIndex].Cells["ProductoInterno"].Value).Trim();
                decimal _Dcm_CantUnid2Prod = 0;
                _Dg_Descarga.Rows[_P_Int_RowIndex].Cells["cunidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                string _Str_Sql = "SELECT cproducto FROM TPRODUCTO WHERE cproducto='" + _Str_CodProducto + "' AND cventaund2=1";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Dcm_CantUnid2Prod = _Cls_VariosMetodos._Mtd_ProductoUndManejo2Dec(_Str_CodProducto);
                    if (_Dcm_CantUnid2Prod <= _P_Int_Unidades)
                    {
                        if (_P_Bol_Mensaje)
                        {
                            MessageBox.Show("No puede ingresar esta cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Dg_Descarga.Rows[_P_Int_RowIndex].Cells["cunidades"].Value = _Str_NumeroTemp;
                        }
                        else
                        {
                            _Dg_Descarga.Rows[_P_Int_RowIndex].Cells["cunidades"].Style.BackColor = Color.Yellow;
                            return false;
                        }
                    }
                }
                else
                {
                    if (_P_Bol_Mensaje)
                    {
                        MessageBox.Show("No puede ingresar esta cantidad. El producto no se comercializa en Unidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Dg_Descarga.Rows[_P_Int_RowIndex].Cells["cunidades"].Value = _Str_NumeroTemp;
                    }
                    else
                    {
                        _Dg_Descarga.Rows[_P_Int_RowIndex].Cells["cunidades"].Style.BackColor = Color.Yellow;
                        return false;
                    }
                }
            }
            return true;
        }

        private void _Dg_Descarga_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Descarga.CurrentCell != null)
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        int _Int_NumeroTemp = 0;
                        if (!int.TryParse(Convert.ToString(_Dg_Descarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Trim(), out _Int_NumeroTemp))
                        {
                            _Dg_Descarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_NumeroTemp;
                        }
                        else if (e.ColumnIndex == 5)
                        {
                            _Mtd_ValidacionUnidades(_Int_NumeroTemp, e.RowIndex, true);
                        }
                    }
                    else if (e.ColumnIndex == 6 || e.ColumnIndex == 8)
                    {
                        decimal _Dcm_NumeroTemp = 0;
                        if (!decimal.TryParse(Convert.ToString(_Dg_Descarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Trim(), out _Dcm_NumeroTemp))
                        {
                            _Dg_Descarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Str_NumeroTemp;
                        }
                    }
                }
            }
        }

        private bool _Bol_Boleano = false;

        private void _Dg_Descarga_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                _Bol_Boleano = true;
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Descarga.CurrentCell.ColumnIndex == 4 || _Dg_Descarga.CurrentCell.ColumnIndex == 5)
            {
                _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 10, 0);
            }
            else if (_Dg_Descarga.CurrentCell.ColumnIndex == 6 || _Dg_Descarga.CurrentCell.ColumnIndex == 8)
            {
                _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 18, 2);
            }
        }

        private void _Mtd_ImprimirRecepcionVencimiento()
        {
            int _P_Int_Sw = 7;
            string _Str_CGROUPCOMP = Frm_Padre._Str_GroupComp;
            string _Str_CFACTURA = _Cmb_Fac.Text;
            string _Str_CRECEPCION = _Txt_rec2.Text;
            string _Str_CNOMBEMP = _Mtd_NombComp();
            string _Str_CPROVDESC = _Txt_Proveedor.Text;

            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(_P_Int_Sw, _Str_CGROUPCOMP, _Str_CFACTURA, _Str_CRECEPCION, _Str_CNOMBEMP, _Str_CPROVDESC);
            _Frm_Inf.MdiParent = this.MdiParent;
            _Frm_Inf.Dock = DockStyle.Fill;
            _Frm_Inf.Show();

        }


        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

        private void _Btn_AceptarProInact_Click(object sender, EventArgs e)
        {
            _Pnl_ProductosInactivos.Visible = false;
        }

        private void _Pnl_ProductosInactivos_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_ProductosInactivos.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Bt_CerrarP_Click(object sender, EventArgs e)
        {
            _Pnl_AgregarEditarProducto.Visible = false;
            _Dg_Descarga.Enabled = true;
        }

        private bool _Mtd_EsNumerico(string pMontoAValidar)
        {
            if (!_Mtd_IsNumeric(pMontoAValidar) | pMontoAValidar.IndexOf(".") >= 0 | pMontoAValidar.IndexOf(",") == 0)
            {
                if (pMontoAValidar.Trim().IndexOf(".") >= 0)
                {
                    MessageBox.Show("No debe Introducir puntos (.) en el monto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (pMontoAValidar.Trim().IndexOf(",") == 0)
                {
                    MessageBox.Show("No debe Introducir comas (,) al inicio del monto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (!_Mtd_IsNumeric(pMontoAValidar))
                {
                    MessageBox.Show("No debe Introducir valores alfanuméricos en los montos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                pMontoAValidar = "0";
            }
            else
            {
                if (pMontoAValidar.Trim().IndexOf(",") == pMontoAValidar.Trim().Length - 1)
                {
                    pMontoAValidar = pMontoAValidar + "0";
                }
                else if (pMontoAValidar.Trim().IndexOf(",") > 0)
                {
                    string _Str_Cadena = pMontoAValidar.Trim().Substring(pMontoAValidar.IndexOf(",") + 1);
                    if (_Str_Cadena.IndexOf(",") >= 0)
                    {
                        MessageBox.Show("No debe Introducir mas de una coma (,) en un monto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pMontoAValidar = "0";
                        return false;
                    }
                }
                else if ((pMontoAValidar.Trim().IndexOf(",") >= 0) || (pMontoAValidar.Trim().IndexOf(",") >= 0))
                {
                    MessageBox.Show("No debe Introducir decimales en los empaques y/o unidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pMontoAValidar = "0";
                    return false;
                }
            }

            return true;
        }
        private bool _Mtd_EsValidoUnidades(string pCodProducto, int pMontoUnidades)
        {
            if (pMontoUnidades > 0)
            {
                string _Str_CodProducto = pCodProducto;
                decimal _Dcm_CantUnid2Prod = 0;
                string _Str_Sql = "SELECT cproducto FROM TPRODUCTO WHERE cproducto='" + _Str_CodProducto + "' AND cventaund2=1";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Dcm_CantUnid2Prod = _Cls_VariosMetodos._Mtd_ProductoUndManejo2Dec(_Str_CodProducto);
                    if (_Dcm_CantUnid2Prod <= pMontoUnidades)
                    {
                        MessageBox.Show("No puede ingresar esta cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No puede ingresar esta cantidad. El producto no se comercializa en Unidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        private void _Mtd_AgregarProducto()
        {
            //Obtengo los valores
            string _Str_Prod = _Txt_Producto_AgregarEditar.Text;
            string _Str_Fab = _Txt_CodFabricante_AgregarEditar.Text;
            int _Int_cempaques = Convert.ToInt32(_Txt_Empaques_AgregarEditar.Text);
            int _Int_cunidades = Convert.ToInt32(_Txt_Unidades_AgregarEditar.Text);
            decimal _Dcm_ccostobrutolote = 0;
            decimal _Dcm_cprecioventamax = 0;
            decimal _Dcm_cpreciolista = 0;

            _Mtd_ObtenerCostoBrtuoyPrecioMax(_Str_Prod, ref _Dcm_ccostobrutolote, ref _Dcm_cprecioventamax, ref _Dcm_cpreciolista);
            if (_Mtd_ObligatorioPMV(_Str_Prod))
            {
                //Obtengo el Item seleccionado
                _Dcm_cprecioventamax = Convert.ToDecimal(_Txt_PMV_AgregarEditar.Text);
            }
                       

            //Genero el SQL
            string _Str_Sql = "INSERT INTO TRECEPCIONDD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cunidades,cproveedor,ccostobrutolote,cprecioventamax,cpreciolista) VALUES(";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + ",'" + _Txt_rec2.Text.Trim() + "','" + _Cmb_Fac.SelectedItem.ToString() + "','" + _Str_Prod + "','" + _Str_Fab + "'," + _Int_cempaques + "," + _Int_cunidades + ",'" + _Str_Proveedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cpreciolista) + "')";
            //Trato de guardar
            try
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONM", "cdescargo='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_rec2.Text + "' and cproveedor='" + _Str_Proveedor + "'");
            }
            catch (Exception oExcepcion)
            {
            }
        }

        private string _Mtd_ObtenerFechaFactura(string _P_Str_IdRecepcion, string _P_Str_Factura)
        {
            string strResultado = "";
            string _Str_Sql = "Select cdatefactura from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_IdRecepcion + "' and cnfacturapro='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                strResultado = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdatefactura"].ToString()).ToShortDateString();

            }
            return strResultado;
        }

        private decimal _Mtd_ObtenerPorcentajeDescuentoFinancieroFactura(string _P_Str_IdRecepcion, string _P_Str_Factura)
        {
            decimal decResultado = 0;
            string _Str_Sql = "Select cdescfinanporc from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_IdRecepcion + "' and cnfacturapro='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                decResultado = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanporc"]);
            }
            return decResultado;
        }

        private void _Txt_Empaques_AgregarEditar_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Empaques_AgregarEditar.Text)) { _Txt_Empaques_AgregarEditar.Text = ""; }
        }

        private void _Txt_Unidades_AgregarEditar_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Unidades_AgregarEditar.Text)) { _Txt_Unidades_AgregarEditar.Text = ""; }
        }

        private void _Txt_PMV_AgregarEditar_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_PMV_AgregarEditar.Text)) { _Txt_PMV_AgregarEditar.Text = ""; }
        }

        private void _Txt_Empaques_AgregarEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Empaques_AgregarEditar, e, 15, 0);
        }

        private void _Txt_Unidades_AgregarEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Unidades_AgregarEditar, e, 15, 0);
        }

        private void _Txt_PMV_AgregarEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_PMV_AgregarEditar, e, 15, 2);
        }

    }
}