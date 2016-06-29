using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_AuxContable : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        string _G_Str_ClasificAux = "", _G_Str_IdClasificAux = "";
        public Frm_AuxContable()
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
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_IdAuxiliarCont.Text.Trim().Length > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }
        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_IdAuxiliarCont.Text = "";
            _Cb_ClasificAuxiliar.SelectedIndex = -1;
            _Chk_Activo.Checked = false;
            _Txt_IdClasificAuxiliarText.Text = "";
            _Txt_IdClasificAuxiliar.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_IdTipoAuxiliar.Text = "";
            _G_Str_ClasificAux = "";
            _G_Str_IdClasificAux = "";
            if (_Dg_DetalleTipoAuxiliar.DataSource == null)
            {
                _Dg_DetalleTipoAuxiliar.Rows.Clear();
            }
            else
            {
                _Dg_DetalleTipoAuxiliar.DataSource = null;
            }
            _Mtd_Bloquear(false);
            _Er_Error.Dispose();
            _Mtd_Actualizar();
            _Mtd_BotonesMenu();
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_IdAuxiliarCont.Enabled = false;
            _Cb_ClasificAuxiliar.Enabled = _Pr_Bol_A;
            _Chk_Activo.Enabled = _Pr_Bol_A;
            _Txt_IdClasificAuxiliarText.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Txt_IdTipoAuxiliar.Enabled = false;
            _Bt_BuscarClasifica.Enabled = false;
            _Bt_CopiaDescripcion.Enabled = false;
            _Bt_BuscarTipoAuxiliar.Enabled = false;
            _Bt_Agregar.Enabled = false;
            _Bt_Eliminar.Enabled = false;
        }
        private void _Mtd_CargarComboClasificacion(ComboBox _Pr_Cb)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.Items.Clear();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("1 - CLIENTES", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("2 - PROVEEDOR MATERIA PRIMA", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("3 - PROVEEDOR DE SERVICIO", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("4 - PROVEEDOR OTROS", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("5 - EMPLEADOS", "5"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("6 - BANCO", "6"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("7 - ACTIVO", "7"));
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Auxiliar");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidauxiliarcont";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Sql = "SELECT cidauxiliarcont as Auxiliar, RTRIM(cdescripcion) AS Descripcion, " +
            "CASE WHEN cclasificauxiliar=1 THEN " +
                "'CLIENTES' " +
            "ELSE CASE WHEN cclasificauxiliar=2 THEN " +
                "'PROVEEDOR DE MATERIA PRIMA' " +
            "ELSE CASE WHEN cclasificauxiliar=3 THEN " +
                "'PROVEEDOR DE SERVICIO' " +
            "ELSE CASE WHEN cclasificauxiliar=4 THEN " +
                "'PROVEEDOR OTROS' " +
            "ELSE CASE WHEN cclasificauxiliar=5 THEN " +
                "' EMPLEADO' " +
            "ELSE CASE WHEN cclasificauxiliar=6 THEN " +
                "'BANCO' " +
            "ELSE CASE WHEN cclasificauxiliar=7 THEN " +
                "'ACTIVO' " +
            "END END END END END END " +
            "END AS [Clasificación] " +
            "FROM TAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0";
            if (_Cb_FindClasific.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND cclasificauxiliar=" + _Cb_FindClasific.SelectedValue.ToString();
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Sql, _Str_Campos, "", _Tsm_Menu, _Dg_ConsultaAuxiliar, false, "");
        }
        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "SELECT * FROM TAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidauxiliarcont=" + _Pr_Str_Id;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_IdAuxiliarCont.Text = _Pr_Str_Id;
                _Cb_ClasificAuxiliar.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cclasificauxiliar"]).Trim();
                _G_Str_ClasificAux = Convert.ToString(_Ds.Tables[0].Rows[0]["cclasificauxiliar"]).Trim();
                _Txt_IdClasificAuxiliar.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cidclasificauxiliar"]).Trim();
                _G_Str_IdClasificAux = Convert.ToString(_Ds.Tables[0].Rows[0]["cidclasificauxiliar"]).Trim();
                
                _Txt_Descripcion.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdescripcion"]).Trim();
                _Chk_Activo.Checked = Convert.ToBoolean(_Ds.Tables[0].Rows[0]["cactivo"]);
                _Txt_IdClasificAuxiliarText.Text = _Mtd_GetDescripClasificacion(_Cb_ClasificAuxiliar.SelectedValue.ToString());
                _Mtd_CargarDetalle(_Pr_Str_Id);
            }
        }
        private void _Mtd_CargarDetalle(string _Pr_Str_Id)
        {
            string _Str_Sql = "SELECT TAUXILIARCONTD.cidtipoauxiliar,TTIPAUXILIARCONT.cdescripcion AS cidtipoauxiliar_name FROM TAUXILIARCONTD INNER JOIN TTIPAUXILIARCONT ON TAUXILIARCONTD.cidtipoauxiliar=TTIPAUXILIARCONT.cidtipoauxiliar WHERE TAUXILIARCONTD.ccompany='" + Frm_Padre._Str_Comp + "' AND TAUXILIARCONTD.cidauxiliarcont='" + _Pr_Str_Id + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_DetalleTipoAuxiliar.DataSource = _Ds.Tables[0];
            _Dg_DetalleTipoAuxiliar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        
        private bool _Mtd_ValidaSave()
        {
            string _Str_Sql = "", _Str_Mensaje="";
            bool _Bol_R = true;
            if (_Cb_ClasificAuxiliar.SelectedIndex < 1)
            {
                _Er_Error.SetError(_Cb_ClasificAuxiliar, "Información requerida.");
                _Bol_R = false;
            }
            else
            {
                switch (_Cb_ClasificAuxiliar.SelectedValue.ToString())
                {
                    case "1"://CLIENTES
                        _Str_Mensaje = "Ya existe el Cliente seleccionado.";
                        break;
                    case "2"://PROVEEDOR MATERIA PRIMA
                        _Str_Mensaje = "Ya existe el Proveedor de materia prima seleccionado.";
                        break;
                    case "3"://PROVEEDOR DE SERVICIO
                        _Str_Mensaje = "Ya existe el Proveedor de servicio seleccionado.";
                        break;
                    case "4"://PROVEEDOR OTROS
                        _Str_Mensaje = "Ya existe el Proveedor Otros seleccionado.";
                        break;
                    case "5"://EMPLEADO
                        _Str_Mensaje = "Ya existe el Empleado seleccionado.";
                        break;
                    case "6"://BANCO
                        _Str_Mensaje = "Ya existe el Banco seleccionado.";
                        break;
                    case "7"://ACTIVO

                        break;
                    default:

                        break;
                }
                if (_Str_MyProceso == "A")
                {

                    _Str_Sql = "SELECT * FROM TAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cclasificauxiliar=" + _Cb_ClasificAuxiliar.SelectedValue.ToString() + " AND cidclasificauxiliar='" + _Txt_IdClasificAuxiliar.Text + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                    {
                        MessageBox.Show(_Str_Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_R = false;
                    }
                }
                else if (_Str_MyProceso == "M")
                {
                    if (_Cb_ClasificAuxiliar.SelectedValue.ToString().Trim() != _G_Str_ClasificAux && _Txt_IdClasificAuxiliar.Text.Trim() != _G_Str_IdClasificAux)
                    {
                        _Str_Sql = "SELECT * FROM TAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cclasificauxiliar=" + _Cb_ClasificAuxiliar.SelectedValue.ToString() + " AND cidclasificauxiliar='" + _Txt_IdClasificAuxiliar.Text + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                        {
                            MessageBox.Show(_Str_Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Bol_R = false;
                        }
                    }
                }
            }
            if (_Txt_IdClasificAuxiliar.Text.Length == 0)
            {
                _Er_Error.SetError(_Txt_IdClasificAuxiliar, "Información requerida.");
                _Bol_R = false;
            }
            if (_Txt_Descripcion.Text.Length == 0)
            {
                _Er_Error.SetError(_Txt_Descripcion, "Información requerida.");
                _Bol_R = false;
            }
            if (_Dg_DetalleTipoAuxiliar.Rows.Count == 0)
            {
                _Bol_R = false;
                MessageBox.Show("Ingrese los tipos de auxiliares.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return _Bol_R;
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectedIndex = 1;
            _Str_MyProceso = "M";
            _Bt_BuscarClasifica.Enabled = true;
            _Bt_CopiaDescripcion.Enabled = true;
            _Bt_BuscarTipoAuxiliar.Enabled = true;
        }
        public bool _Mtd_Guardar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_cidauxiliarcont = "";
            if (_Str_MyProceso == "A")
            {
                if (_Mtd_ValidaSave())
                {
                    try
                    {
                        _Str_Sql = "Select Max(cidauxiliarcont) FROM TAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                        _Str_cidauxiliarcont = _myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Txt_IdAuxiliarCont.Text = _Str_cidauxiliarcont;
                        _Str_Sql = "INSERT INTO TAUXILIARCONT (ccompany,cidauxiliarcont,cdescripcion,cclasificauxiliar,cidclasificauxiliar,cactivo,cdateadd,cuseradd,cdelete) VALUES('";
                        _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidauxiliarcont + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + _Cb_ClasificAuxiliar.SelectedValue.ToString() + "','" + _Txt_IdClasificAuxiliar.Text.Trim().ToUpper() + "','" + Convert.ToInt32(_Chk_Activo.Checked).ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        foreach (DataGridViewRow _DgRow in _Dg_DetalleTipoAuxiliar.Rows)
                        {
                            _Str_Sql = "INSERT INTO TAUXILIARCONTD (ccompany,cidauxiliarcont,cidtipoauxiliar) VALUES('" + Frm_Padre._Str_Comp + "'," + _Txt_IdAuxiliarCont.Text + ",'" + _DgRow.Cells[0].Value.ToString() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Ini();
                        _Bol_R = true;
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                    }
                    catch
                    {
                        _Bol_R = false;
                        MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            return _Bol_R;
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Str_MyProceso == "M")
            {
                if (_Mtd_ValidaSave())
                {
                    try
                    {
                        _Str_Sql = "UPDATE TAUXILIARCONT SET cdescripcion='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',cclasificauxiliar=" + _Cb_ClasificAuxiliar.SelectedValue.ToString() + ",cidclasificauxiliar='" + _Txt_IdClasificAuxiliar.Text.Trim() + "',cactivo=" + Convert.ToInt32(_Chk_Activo.Checked).ToString() + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete=0 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidauxiliarcont='" + _Txt_IdAuxiliarCont.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "DELETE FROM TAUXILIARCONTD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidauxiliarcont=" + _Txt_IdAuxiliarCont.Text;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        foreach (DataGridViewRow _DgRow in _Dg_DetalleTipoAuxiliar.Rows)
                        {
                            _Str_Sql = "INSERT INTO TAUXILIARCONTD (ccompany,cidauxiliarcont,cidtipoauxiliar) VALUES('" + Frm_Padre._Str_Comp + "'," + _Txt_IdAuxiliarCont.Text + ",'" + _DgRow.Cells[0].Value.ToString() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Ini();
                        _Bol_R = true;
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                    }
                    catch
                    {
                        _Bol_R = false;
                        MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return _Bol_R;
        }
        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (MessageBox.Show("Está seguro de Elminar esta información?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TAUXILIARCONT SET cdelete=1,cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidauxiliarcont='" + _Txt_IdAuxiliarCont.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                MessageBox.Show("Transacción Eliminada Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Ini();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                _Bol_R = true;
            }
            return _Bol_R;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectedIndex = 1;
            _Cb_ClasificAuxiliar.Focus();
            _Str_MyProceso = "A";
            _Chk_Activo.Checked = true;
            _Mtd_BotonesMenu();
        }
        private void Frm_AuxContable_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Cb_FindClasific.SelectedIndexChanged -= new EventHandler(_Cb_FindClasific_SelectedIndexChanged);
            _Mtd_CargarComboClasificacion(_Cb_FindClasific);
            _Cb_FindClasific.SelectedIndexChanged += new EventHandler(_Cb_FindClasific_SelectedIndexChanged);
            _Cb_ClasificAuxiliar.SelectedIndexChanged -= new EventHandler(_Cb_ClasificAuxiliar_SelectedIndexChanged);
            _Mtd_CargarComboClasificacion(_Cb_ClasificAuxiliar);
            _Cb_ClasificAuxiliar.SelectedIndexChanged += new EventHandler(_Cb_ClasificAuxiliar_SelectedIndexChanged);
            _Mtd_Ini();
        }

        private void Frm_AuxContable_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_AuxContable_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_ConsultaAuxiliar_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_ConsultaAuxiliar.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarData(Convert.ToString(_Dg_ConsultaAuxiliar[0, e.RowIndex].Value));
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Cb_FindClasific_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            this.Cursor = Cursors.Default;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                if (!_Cb_ClasificAuxiliar.Enabled & _Txt_IdAuxiliarCont.Text.Trim().Length == 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Txt_IdTipoAuxiliar.Text.Trim().Length > 0)
            {
                if (!_Mtd_VerificaDupliGridTpoAux(_Txt_IdTipoAuxiliar.Tag.ToString().Trim(), _Dg_DetalleTipoAuxiliar.Rows.Count))
                {
                    object[] _MyObj = new object[] { _Txt_IdTipoAuxiliar.Tag.ToString().Trim(), _Txt_IdTipoAuxiliar.Text.Trim() };
                    _Dg_DetalleTipoAuxiliar.Rows.Add(_MyObj);
                    _Txt_IdTipoAuxiliar.Tag = "";
                    _Txt_IdTipoAuxiliar.Text = "";
                    _Bt_Agregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Este auxiliar de cuenta ya fue agregada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Txt_IdTipoAuxiliar.Text.Trim().Length > 0)
            {
                foreach (DataGridViewRow _DgRow in _Dg_DetalleTipoAuxiliar.Rows)
                {
                    if (_DgRow.Cells[0].Value.ToString().Trim() == _Txt_IdTipoAuxiliar.Tag.ToString().Trim())
                    {
                        _Dg_DetalleTipoAuxiliar.Rows.Remove(_DgRow);
                        _Txt_IdTipoAuxiliar.Text = "";
                        _Txt_IdTipoAuxiliar.Tag = "";
                        _Bt_Eliminar.Enabled = false;
                        break;
                    }
                }
            }
        }

        private void _Bt_CopiaDescripcion_Click(object sender, EventArgs e)
        {
            _Txt_Descripcion.Text = _Txt_IdClasificAuxiliarText.Text;
        }
        private string _Mtd_GetDescripClasificacion(string _Pr_Str_IdClasificacion)
        {
            DataSet _Ds;
            string _Str_R = "";
            string _Str_Sql = "";
            switch (_Pr_Str_IdClasificacion)
            {
                case "1"://CLIENTES
                    _Str_Sql = "SELECT c_nomb_comer FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_IdClasificAuxiliar.Text + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_R = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    break;
                case "2"://PROVEEDOR MATERIA PRIMA
                    _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _Txt_IdClasificAuxiliar.Text + "' AND cglobal=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_R = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    break;
                case "3"://PROVEEDOR DE SERVICIO
                    _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _Txt_IdClasificAuxiliar.Text + "' AND cglobal=0 AND ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_R = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    break;
                case "4"://PROVEEDOR OTROS
                    _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _Txt_IdClasificAuxiliar.Text + "' AND cglobal=2 AND ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_R = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    break;
                case "5"://EMPLEADO
                    _Str_Sql = "SELECT cname FROM TUSER WHERE cuser='" + _Txt_IdClasificAuxiliar.Text + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_R = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    break;
                case "6"://BANCO
                    _Str_Sql = "SELECT cname FROM TBANCO WHERE cbanco='" + _Txt_IdClasificAuxiliar.Text + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_R = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    break;
                case "7"://ACTIVO

                    
                    break;
                default:

                    _Bt_CopiaDescripcion.Enabled = false;
                    break;
            }
            return _Str_R;
        }
        private void _Bt_BuscarClasifica_Click(object sender, EventArgs e)
        {
            switch (_Cb_ClasificAuxiliar.SelectedValue.ToString())
            {
                case "1"://CLIENTES
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
                    _Frm.ShowDialog();
                    if (_Frm._Str_FrmResult == "1")
                    {
                        _Txt_IdClasificAuxiliarText.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Txt_IdClasificAuxiliar.Text = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Bt_CopiaDescripcion.Enabled = true;
                        _Txt_Descripcion.Enabled = true;
                    }
                    break;
                case "2"://PROVEEDOR MATERIA PRIMA
                    Frm_Busqueda2 _Frm1 = new Frm_Busqueda2(33);
                    _Frm1.ShowDialog();
                    if (_Frm1._Str_FrmResult == "1")
                    {
                        _Txt_IdClasificAuxiliarText.Text = _Frm1._Dg_Grid[1, _Frm1._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Txt_IdClasificAuxiliar.Text = _Frm1._Dg_Grid[0, _Frm1._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Bt_CopiaDescripcion.Enabled = true;
                        _Txt_Descripcion.Enabled = true;
                    }
                    break;
                case "3"://PROVEEDOR DE SERVICIO
                    Frm_Busqueda2 _Frm2 = new Frm_Busqueda2(34);
                    _Frm2.ShowDialog();
                    if (_Frm2._Str_FrmResult == "1")
                    {
                        _Txt_IdClasificAuxiliarText.Text = _Frm2._Dg_Grid[1, _Frm2._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Txt_IdClasificAuxiliar.Text = _Frm2._Dg_Grid[0, _Frm2._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Bt_CopiaDescripcion.Enabled = true;
                        _Txt_Descripcion.Enabled = true;
                    }
                    break;
                case "4"://PROVEEDOR OTROS
                    Frm_Busqueda2 _Frm3 = new Frm_Busqueda2(35);
                    _Frm3.ShowDialog();
                    if (_Frm3._Str_FrmResult == "1")
                    {
                        _Txt_IdClasificAuxiliarText.Text = _Frm3._Dg_Grid[1, _Frm3._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Txt_IdClasificAuxiliar.Text = _Frm3._Dg_Grid[0, _Frm3._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Bt_CopiaDescripcion.Enabled = true;
                        _Txt_Descripcion.Enabled = true;
                    }
                    break;
                case "5"://EMPLEADO
                    Frm_Busqueda2 _Frm4 = new Frm_Busqueda2(36);
                    _Frm4.ShowDialog();
                    if (_Frm4._Str_FrmResult == "1")
                    {
                        _Txt_IdClasificAuxiliarText.Text = _Frm4._Dg_Grid[1, _Frm4._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Txt_IdClasificAuxiliar.Text = _Frm4._Dg_Grid[0, _Frm4._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Bt_CopiaDescripcion.Enabled = true;
                        _Txt_Descripcion.Enabled = true;
                    }
                    break;
                case "6"://BANCO
                    Frm_Busqueda2 _Frm5 = new Frm_Busqueda2(37);
                    _Frm5.ShowDialog();
                    if (_Frm5._Str_FrmResult == "1")
                    {
                        _Txt_IdClasificAuxiliarText.Text = _Frm5._Dg_Grid[1, _Frm5._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Txt_IdClasificAuxiliar.Text = _Frm5._Dg_Grid[0, _Frm5._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                        _Bt_CopiaDescripcion.Enabled = true;
                        _Txt_Descripcion.Enabled = true;
                    }
                    break;
                case "7"://ACTIVO

                    _Bt_CopiaDescripcion.Enabled = true;
                    _Txt_Descripcion.Enabled = true;
                    break;
                default:

                    _Bt_CopiaDescripcion.Enabled = false;
                    break;
            }
        }

        private void _Bt_BuscarTipoAuxiliar_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(38);
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_IdTipoAuxiliar.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                _Txt_IdTipoAuxiliar.Tag = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                _Bt_Agregar.Enabled = true;
            }
        }

        private void _Cb_ClasificAuxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                _Txt_IdClasificAuxiliarText.Text = "";
                _Txt_IdClasificAuxiliar.Text = "";
                if (_Cb_ClasificAuxiliar.SelectedIndex > 0)
                {
                    _Bt_BuscarClasifica.Enabled = true;
                }
                else
                {
                    _Bt_BuscarClasifica.Enabled = false;
                    _Txt_Descripcion.Text = "";
                }
            }
        }

        private void _Dg_DetalleTipoAuxiliar_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Dg_DetalleTipoAuxiliar.CurrentCell != null)
                {
                    _Txt_IdTipoAuxiliar.Tag = _Dg_DetalleTipoAuxiliar[0, e.RowIndex].Value.ToString();
                    _Txt_IdTipoAuxiliar.Text = _Dg_DetalleTipoAuxiliar[1, e.RowIndex].Value.ToString();
                    _Bt_Eliminar.Enabled = true;
                }
            }
        }

        private void _Dg_DetalleTipoAuxiliar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Dg_DetalleTipoAuxiliar.SelectedRows.Count == 0)
                {
                    _Bt_Eliminar.Enabled = false;
                }
            }
        }

        private void _Txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Txt_Descripcion.Text.Trim().Length > 0)
                {
                    _Bt_BuscarTipoAuxiliar.Enabled = true;
                }
                else
                {
                    _Bt_BuscarTipoAuxiliar.Enabled = false;
                }
            }
        }

        private bool _Mtd_VerificaDupliGridTpoAux(string _Pr_Str_Valor, int _Pr_Int_RowIndex)
        {
            bool _Bol_R = false;
            foreach (DataGridViewRow _DgRow in _Dg_DetalleTipoAuxiliar.Rows)
            {
                if (_Pr_Int_RowIndex != _DgRow.Index)
                {
                    if (_DgRow.Cells[0].Value.ToString() == _Pr_Str_Valor)
                    {
                        _Bol_R = true;
                        break;
                    }
                }
            }
            return _Bol_R;
        }

        private void _Dg_DetalleTipoAuxiliar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Dg_DetalleTipoAuxiliar.SelectedRows.Count == 0)
                {
                    _Bt_Eliminar.Enabled = false;
                }
            }
        }

        private void _Dg_ConsultaAuxiliar_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void _Dg_DetalleTipoAuxiliar_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfoDet.Visible = true;
            }
            else
            {
                _Lbl_DgInfoDet.Visible = false;
            }
        }
    }
}