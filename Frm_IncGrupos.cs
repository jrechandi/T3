using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_IncGrupos : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        string _Str_GrupoVta = "";
        public Frm_IncGrupos()
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
                else
                {
                    if (_Ctrl.GetType() != typeof(RadioButton))
                    { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
                }
            }
        }
        private void _Mtd_CargarCargos(ComboBox _P_Cmb_Combo, bool _P_Bol_Consulta)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcargonom, cdescripcion FROM TCARGOSNOM";
            if (_P_Bol_Consulta)
            { _Str_Cadena += " WHERE ISNULL(cdelete,0)='0' AND (cgerarea='1' OR cvendedor='1' OR cgercomer='1' OR cgventas='1')"; }
            else
            { _Str_Cadena += " WHERE ISNULL(cdelete,0)='0' AND (cvendedor='1' OR ((cgercomer='1' OR cgventas='1' OR cgerarea='1') AND NOT EXISTS(SELECT cidcargonom FROM TGRUPOIV WHERE TGRUPOIV.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGRUPOIV.ccompany='" + Frm_Padre._Str_Comp + "' AND TGRUPOIV.cidcargonom=TCARGOSNOM.cidcargonom)))"; }
            //{ _Str_Cadena += " WHERE ISNULL(cdelete,0)='0' AND ((cgerarea='1' OR cvendedor='1') OR ((cgercomer='1' OR cgventas='1') AND NOT EXISTS(SELECT cidcargonom FROM TGRUPOIV WHERE TGRUPOIV.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGRUPOIV.ccompany='" + Frm_Padre._Str_Comp + "' AND TGRUPOIV.cidcargonom=TCARGOSNOM.cidcargonom)))"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarGrupoVta(string _P_Str_Cargo)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "";
            if (_Str_GrupoVta.Trim().Length > 0)
            { _Str_Cadena = "SELECT TGRUPOVTAM.cgrupovta, TGRUPOVTAM.cname FROM TGRUPOVTAM INNER JOIN TGRUPOVTA ON TGRUPOVTAM.cgrupovta = TGRUPOVTA.cgrupovta AND ISNULL(TGRUPOVTAM.cdelete,0) = ISNULL(TGRUPOVTA.cdelete,0) WHERE TGRUPOVTA.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TGRUPOVTAM.cdelete,0)='0' AND (NOT EXISTS(SELECT cidgrupincentivar FROM TGRUPOIV WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TGRUPOIV.cidcargonom='" + _P_Str_Cargo + "' AND TGRUPOIV.cgrupovta=TGRUPOVTAM.cgrupovta) OR TGRUPOVTAM.cgrupovta='" + _Str_GrupoVta + "')"; }
            else
            { _Str_Cadena = "SELECT TGRUPOVTAM.cgrupovta, TGRUPOVTAM.cname FROM TGRUPOVTAM INNER JOIN TGRUPOVTA ON TGRUPOVTAM.cgrupovta = TGRUPOVTA.cgrupovta AND ISNULL(TGRUPOVTAM.cdelete,0) = ISNULL(TGRUPOVTA.cdelete,0) WHERE TGRUPOVTA.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TGRUPOVTAM.cdelete,0)='0' AND NOT EXISTS(SELECT cidgrupincentivar FROM TGRUPOIV WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TGRUPOIV.cidcargonom='" + _P_Str_Cargo + "' AND TGRUPOIV.cgrupovta=TGRUPOVTAM.cgrupovta)"; }
            _Str_Cadena += " ORDER BY TGRUPOVTAM.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_GrupoVtas, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_HeaderText(DataGridView _P_Dg_Grid)
        {
            foreach (DataGridViewColumn _Dg_Col in _P_Dg_Grid.Columns)
            {
                _Dg_Col.HeaderText = _Dg_Col.HeaderText.Replace("_", " ");
            }
        }
        private void _Mtd_Actualizar()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_GRUPOIV
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Incentivo = Campos.cidgrupincentivar, Grupo_Incentivar = Campos.cdesgrupo, Cargo = Campos.cdescargo, Grupo_Vta = Campos.cdesgrupovta, Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            {
                _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim());
            }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Incentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Mtd_HeaderText(_Dg_Grid);
        }
        private void _Mtd_Habilitar(bool _P_Bol_Habilitar)
        {
            _Cmb_Cargo_D.Enabled = _P_Bol_Habilitar;
            _Cmb_GrupoVtas.Enabled = false;
            _Txt_Descripcion.Enabled = _P_Bol_Habilitar;
        }
        public void _Mtd_Habilitar()
        {
            _Cmb_GrupoVtas.Enabled = !_Mtd_CargoGte_Vta_Comer(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
            _Txt_Descripcion.Enabled = true;
        }
        public void _Mtd_Ini()
        {
            _Txt_Grupo_Incentivar.Text = "";
            _Mtd_CargarCargos(_Cmb_Cargo_D, false);
            _Txt_Descripcion.Text = "";
            _Str_GrupoVta = "";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Mtd_Habilitar(true);
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Cargo_D.Focus();
        }
        private string _Mtd_NombComp(string _P_Str_Comp)
        {
            string _Str_Cadena = "Select RTRIM(cabreviado) COLLATE DATABASE_DEFAULT+' - '+LTRIM(cname) AS cname from TCOMPANY WHERE ccompany='" + _P_Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        private void _Mtd_CargarFormulario(int _P_Int_IdGrupo)
        {
            _Mtd_CargarCargos(_Cmb_Cargo_D, true);
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TGRUPOIV where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_IdGrupo select Campos).Single();
            _Txt_Grupo_Incentivar.Text = _P_Int_IdGrupo.ToString();
            _Cmb_Cargo_D.SelectedIndexChanged -= new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Cmb_Cargo_D.SelectedValue = Convert.ToString(_Var_Datos.cidcargonom);
            _Cmb_Cargo_D.SelectedIndexChanged += new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Str_GrupoVta = _Var_Datos.cgrupovta;
            _Mtd_CargarGrupoVta(Convert.ToString(_Var_Datos.cidcargonom));
            if (!_Mtd_CargoGte_Vta_Comer(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim()))
            { _Cmb_GrupoVtas.SelectedValue = Convert.ToString(_Var_Datos.cgrupovta); }
            _Txt_Descripcion.Text = _Var_Datos.cdescripcion;
        }
        private void _Mtd_InsertarTGRUPOIV()
        {
            string _Str_GrupoVtaTemp = "NA";
            if (_Cmb_GrupoVtas.SelectedIndex > 0) { _Str_GrupoVtaTemp = Convert.ToString(_Cmb_GrupoVtas.SelectedValue); }
            DataContext.TGRUPOIV _T_TGRUPOIV = new T3.DataContext.TGRUPOIV()
            {
                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                ccompany = Frm_Padre._Str_Comp,
                cidcargonom = Convert.ToString(_Cmb_Cargo_D.SelectedValue),
                cgrupovta = _Str_GrupoVtaTemp,
                cdescripcion = _Txt_Descripcion.Text.Trim().ToUpper(),
                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                cuseradd = Frm_Padre._Str_Use
            };
            Program._Dat_Tablas.TGRUPOIV.InsertOnSubmit(_T_TGRUPOIV);
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_ModificarTGRUPOIV(int _P_Int_IdGrupo)
        {
            DataContext.TGRUPOIV _T_TGRUPOIV = Program._Dat_Tablas.TGRUPOIV.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_IdGrupo);
            if (_Cmb_GrupoVtas.SelectedIndex > 0)
            { _T_TGRUPOIV.cgrupovta = Convert.ToString(_Cmb_GrupoVtas.SelectedValue); }
            else
            { _T_TGRUPOIV.cgrupovta = "NA"; }
            _T_TGRUPOIV.cdescripcion = _Txt_Descripcion.Text.Trim().ToUpper();
            _T_TGRUPOIV.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TGRUPOIV.cuserupd = Frm_Padre._Str_Use;
            Program._Dat_Tablas.SubmitChanges();
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Cargo_D.SelectedIndex > 0)
            {
                if (_Txt_Descripcion.Text.Trim().Length > 0 & (_Cmb_GrupoVtas.SelectedIndex > 0 | _Mtd_CargoGte_Vta_Comer(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim())))
                {
                    Cursor = Cursors.WaitCursor;
                    bool _Bol_Validado = false;
                    if (_Txt_Grupo_Incentivar.Text.Trim().Length == 0)
                    {
                        if (_Mtd_Existe(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoVtas.SelectedValue).Trim(), 0))
                        { MessageBox.Show("El grupo que desea crear ya existe. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        else if (_Mtd_ExisteDescripcion(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoVtas.SelectedValue).Trim(), 0, _Txt_Descripcion.Text))
                        { MessageBox.Show("Ya existe un grupo con la descripción que introdujo. Por favor coloque una diferente...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        else
                        { _Mtd_InsertarTGRUPOIV(); _Bol_Validado = true; }
                    }
                    else
                    {
                        if (_Mtd_Existe(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoVtas.SelectedValue).Trim(), Convert.ToInt32(_Txt_Grupo_Incentivar.Text)))
                        { MessageBox.Show("El grupo que desea crear ya existe. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        else if (_Mtd_ExisteDescripcion(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoVtas.SelectedValue).Trim(), Convert.ToInt32(_Txt_Grupo_Incentivar.Text), _Txt_Descripcion.Text))
                        { MessageBox.Show("Ya existe un grupo con la descripción que introdujo. Por favor coloque una diferente...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        else
                        { _Mtd_ModificarTGRUPOIV(Convert.ToInt32(_Txt_Grupo_Incentivar.Text)); _Bol_Validado = true; }
                    }
                    Cursor = Cursors.Default;
                    if (_Bol_Validado)
                    {
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.WaitCursor;
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                        Cursor = Cursors.Default;
                        return true;
                    }
                }
                else
                {
                    if (_Cmb_GrupoVtas.SelectedIndex == 0 & !_Mtd_CargoGte_Vta_Comer(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim())) { _Er_Error.SetError(_Cmb_GrupoVtas, "Información requerida!!!"); }
                    if (_Txt_Descripcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                }
            }
            else
            {
                if (_Cmb_Cargo_D.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Cargo_D, "Información requerida!!!"); }
            }
            return false;
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        private bool _Mtd_CargoGte_Vta_Comer(string _P_Str_Cargo)
        {
            return (from Campos in Program._Dat_Tablas.TCARGOSNOM
                    where Campos.cidcargonom == _P_Str_Cargo & (Campos.cgventas == 1 | Campos.cgercomer == 1 | Campos.cgerarea == 1)//where Campos.cidcargonom == _P_Str_Cargo & (Campos.cgventas == 1 | Campos.cgercomer == 1)
                    select Campos.cidcargonom).Count() > 0;
        }
        private bool _Mtd_Existe(string _P_Str_Cargo, string _P_Str_GrupoVta, int _P_Int_Grupo)
        {
            if (_P_Int_Grupo > 0)
            {
                return (from Campos in Program._Dat_Tablas.TGRUPOIV
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidcargonom == _P_Str_Cargo & Campos.cgrupovta == _P_Str_GrupoVta & Campos.cidgrupincentivar != _P_Int_Grupo
                        select Campos).Count() > 0;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TGRUPOIV
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidcargonom == _P_Str_Cargo & Campos.cgrupovta == _P_Str_GrupoVta
                        select Campos).Count() > 0;
            }
        }
        private bool _Mtd_ExisteDescripcion(string _P_Str_Cargo, string _P_Str_GrupoVta, int _P_Int_Grupo,string _P_Str_Descripcion)
        {
            if (_P_Int_Grupo > 0)
            {
                return (from Campos in Program._Dat_Tablas.TGRUPOIV
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar != _P_Int_Grupo & Campos.cdescripcion.Trim().ToUpper() == _P_Str_Descripcion.Trim().ToUpper()
                        select Campos).Count() > 0;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TGRUPOIV
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cdescripcion.Trim().ToUpper() == _P_Str_Descripcion.Trim().ToUpper()
                        select Campos).Count() > 0;
            }
        }
        private bool _Mtd_EliminarRegistros()
        {
            Cursor = Cursors.WaitCursor;
            bool _Bol_TodosEliminados = true;
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                if (!_Mtd_VerificarDependencias(Convert.ToInt32(_DgRow.Cells["Grupo_Incentivo"].Value)))
                {
                    Program._Dat_Tablas.TGRUPOIV.DeleteOnSubmit(Program._Dat_Tablas.TGRUPOIV.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Incentivo"].Value)));
                }
                else
                {
                    _Bol_TodosEliminados = false;
                }
            }
            Program._Dat_Tablas.SubmitChanges();
            Cursor = Cursors.Default;
            return _Bol_TodosEliminados;
        }
        private bool _Mtd_VerificarDependencias(int _P_Int_Grupo)
        {
            if ((from Campos in Program._Dat_Tablas.TINCCOB
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_Grupo
                 select Campos).Count() > 0)
            {
                return true;
            }
            else if ((from Campos in Program._Dat_Tablas.TINCVTAS
                      where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_Grupo
                      select Campos).Count() > 0)
            {
                return true;
            }
            else if ((from Campos in Program._Dat_Tablas.TINCDISTRIBU
                      where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_Grupo
                      select Campos).Count() > 0)
            {
                return true;
            }
            else if ((from Campos in Program._Dat_Tablas.TINCVARIOS
                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_Grupo
                 select Campos).Count() > 0)
            {
                return true;
            }
            else if ((from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                      where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_Grupo
                      select Campos).Count() > 0)
            {
                return true;
            }
            else
            { return false; }
        }
        private void Frm_IncGrupos_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            Cursor = Cursors.WaitCursor;
            _Mtd_Color_Estandar(this);
            _Mtd_CargarCargos(_Cmb_Cargo, true);
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void Frm_IncGrupos_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Txt_Descripcion.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length > 0; ;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncGrupos_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            { e.Cancel = !_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length == 0; }
            else
            {
                _Mtd_Ini();
                _Mtd_Habilitar(false);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void _Cmb_Cargo_D_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo_D, false);
            Cursor = Cursors.Default;
        }

        private void _Cmb_Cargo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo, true);
            Cursor = Cursors.Default;
        }
        private void _Cmb_GrupoVtas_Enter(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupoVta(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
            Cursor = Cursors.Default;
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarFormulario(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Grupo_Incentivo"].Value));
                _Tb_Tab.SelectedIndex = 1;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void _Cmb_Cargo_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Cargo_D.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarGrupoVta(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim()); _Cmb_GrupoVtas.Enabled = !_Mtd_CargoGte_Vta_Comer(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
                Cursor = Cursors.Default;
                _Txt_Descripcion.Text = _Cmb_Cargo_D.Text.ToUpper().Trim() + " " + Frm_Padre._Str_Comp.Trim().ToUpper() + " - " + _Mtd_NombComp(Frm_Padre._Str_Comp).Trim();
            }
            else
            { _Cmb_GrupoVtas.DataSource = null; _Cmb_GrupoVtas.Enabled = false; _Txt_Descripcion.Text = ""; }
        }

        private void _Cmb_GrupoVtas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_GrupoVtas.SelectedIndex > 0)
            { _Txt_Descripcion.Text = _Cmb_Cargo_D.Text.ToUpper().Trim() + " " + _Cmb_GrupoVtas.Text.ToUpper().Trim() + " " + Frm_Padre._Str_Comp.Trim().ToUpper() + " - " + _Mtd_NombComp(Frm_Padre._Str_Comp).Trim(); }
            else
            { _Txt_Descripcion.Text = ""; }

        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar los registros selecionados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Enabled = false;
                if (_Mtd_EliminarRegistros())
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Actualizar();
                    Cursor = Cursors.Default;
                    _Pnl_Clave.Enabled = true;
                    _Pnl_Clave.Visible = false;
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Actualizar();
                    Cursor = Cursors.Default;
                    _Pnl_Clave.Enabled = true;
                    _Pnl_Clave.Visible = false;
                    MessageBox.Show("Uno o mas grupos no pudieron ser eliminados ya que existen parámetros relacionados con estos grupos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }
    }
}
