using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Ttransporte : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Ttransporte()
        {
            InitializeComponent();
            _Mtd_Actualizar();
            _Mtd_Cargar();
            _Mtd_Color_Estandar(this);
        }
        bool _Bol_Tabs = false;
        public Frm_Ttransporte(string _P_Str_Placa)
        {
            InitializeComponent();
            _Bol_Tabs = true;
            _Mtd_Actualizar();
            _Mtd_Cargar();
            _Mtd_Color_Estandar(this);
            _Mtd_RowHeaderMouseDoubleClick(_P_Str_Placa);
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
        private void Frm_Ttransporte_Load(object sender, EventArgs e)
        {
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Alto);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Ancho);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Capacidad);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Profundidad);
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Txt_Profundidad.Text = "";
            _Txt_Placa.Text = "";
            _Txt_Modelo.Text="";
            _Txt_Marca.Text = "";
            _Txt_Color.Text = "";
            _Txt_Capacidad.Text = "";
            _Txt_Año.Text="";
            _Txt_Ancho.Text = "";
            _Txt_Alto.Text = "";
            _Rbt_Externo.Checked = false;
            _Rbt_Mosanca .Checked =false;
            _Mtd_Cargar();
            _Mtd_Habilitar();
            _Txt_Placa.Enabled = true;
        }
        private void _Mtd_Cargar()
        {
            _Cmb_Tipo.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cttransporte,cname FROM TTTRANSPORTE ORDER BY cname ASC");
           _Cmb_Tipo.DataSource = _Ds.Tables[0];
           _Cmb_Tipo.DisplayMember = "cname";
           _Cmb_Tipo.ValueMember = "cttransporte";
           _Cmb_Tipo.SelectedIndex = -1;
        }

        private void _Cmb_Tipo_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar();
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Profundidad.Enabled = true;
            _Txt_Placa.Enabled = false;
            _Txt_Modelo.Enabled = true;
            _Txt_Marca.Enabled = true;
            _Txt_Color.Enabled = true;
            _Txt_Capacidad.Enabled = true;
            _Txt_Año.Enabled = true;
            _Txt_Ancho.Enabled = true;
            _Txt_Alto.Enabled = true;
            _Rbt_Mosanca.Enabled = true;
            _Rbt_Externo.Enabled = true;
            _Cmb_Tipo.Enabled = true;
        }
        private void Frm_Ttransporte_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            if (!_Bol_Tabs)
            {
                //____________________________________________
                if (!_Txt_Marca.Enabled & _Txt_Marca.Text.Trim().Length > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                }
                else if (!_Txt_Placa.Enabled & _Txt_Placa.Text.Trim().Length > 0 & _Txt_Marca.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else if (_Txt_Placa.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
            }
            //_____________________________________________
        }

        private void Frm_Ttransporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Placa.Focus();
        }
        public bool _Mtd_Guardar()
        {
            if (_Txt_Alto.Text.Trim().Length == 0)
            { _Txt_Alto.Text = "0"; }
            if (_Txt_Ancho.Text.Trim().Length == 0)
            { _Txt_Ancho.Text = "0"; }
            if (_Txt_Profundidad.Text.Trim().Length == 0)
            { _Txt_Profundidad.Text = "0"; }
            if (_Txt_Capacidad.Text.Trim().Length == 0)
            { _Txt_Capacidad.Text = "0"; }
            _Er_Error.Dispose();
            if (_Txt_Placa.Text.Trim().Length > 0 & _Txt_Profundidad.Text.Trim().Length>0 & _Txt_Modelo.Text.Trim().Length>0 & _Txt_Marca.Text.Trim().Length>0 & _Txt_Color.Text.Trim().Length>0 & _Txt_Capacidad.Text.Trim().Length>0 & _Txt_Año.Text.Trim().Length>0 & _Txt_Año.Text.Trim().Length>0 & _Txt_Ancho.Text.Trim().Length>0 & _Txt_Alto.Text.Trim().Length>0  & _Cmb_Tipo.SelectedIndex != -1 & _Int_I!=-1)
            {
                string _Str_Placa = _Txt_Placa.Text.Trim();
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TTRANSPORTE where cplaca='" + _Txt_Placa.Text.Trim() + "'"))
                {
                    string _Str_Cadena = "SELECT cdelete FROM TTRANSPORTE where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        if (MessageBox.Show("El transporte con placa: " + _Txt_Placa.Text + " fue eliminado anteriormente. ¿Desea activarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            _Str_Cadena = "UPDATE TTRANSPORTE Set cplaca='" + _Txt_Placa.Text.Trim().ToUpper() + "',cmarca='" + _Txt_Marca.Text.Trim().ToUpper() + "',cmodelo='" + _Txt_Modelo.Text.Trim().ToUpper() + "',ccolor='" + _Txt_Color.Text.Trim().ToUpper() + "',ctttransporte='" + _Cmb_Tipo.SelectedValue + "',cintext='" + _Int_I.ToString() + "',cano='" + _Txt_Año.Text.Trim() + "',calto='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alto.Text.Trim().ToUpper())) + "',cancho='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Ancho.Text.Trim().ToUpper())) + "',cprofundidad='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Profundidad.Text.Trim().ToUpper())) + "',ccapcarg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capacidad.Text.Trim().ToUpper())) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            MessageBox.Show("El transporte con placa: " + _Txt_Placa.Text + " fue activado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar();
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Mtd_RowHeaderMouseDoubleClick(_Str_Placa);
                            //_Tb_Tab.SelectedIndex = 0;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    string _Str_Cadena = "insert into TTRANSPORTE (cplaca,cmarca,cmodelo,ccolor,ctttransporte,cintext,cano,calto,cancho,cprofundidad,ccapcarg,cdateadd,cuseradd,cdelete) values('" + _Txt_Placa.Text.Trim().ToUpper() + "','" + _Txt_Marca.Text.Trim().ToUpper() + "','" + _Txt_Modelo.Text.Trim().ToUpper() + "','" + _Txt_Color.Text.Trim().ToUpper() + "','" + _Cmb_Tipo.SelectedValue + "','" + _Int_I.ToString() + "','" + _Txt_Año.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alto.Text.Trim().ToUpper())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Ancho.Text.Trim().ToUpper())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Profundidad.Text.Trim().ToUpper())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capacidad.Text.Trim().ToUpper())) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Mtd_RowHeaderMouseDoubleClick(_Str_Placa);
                    //_Tb_Tab.SelectedIndex = 0;
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Placa.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Placa, "Iformación requerida!!!"); }
                if (_Txt_Profundidad.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Profundidad, "Iformación requerida!!!"); }
                if (_Txt_Modelo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Modelo, "Iformación requerida!!!"); }
                if (_Txt_Marca.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Marca, "Iformación requerida!!!"); }
                if (_Txt_Color.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Color, "Iformación requerida!!!"); }
                if (_Txt_Capacidad.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Capacidad, "Iformación requerida!!!"); }
                if (_Txt_Año.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Año, "Iformación requerida!!!"); }
                if (_Txt_Ancho.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Ancho, "Iformación requerida!!!"); }
                if (_Txt_Alto.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Alto, "Iformación requerida!!!"); }                
                if (_Cmb_Tipo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Tipo, "Iformación requerida!!!"); }
                if (_Int_I==-1) { MessageBox.Show("Debe seleccionar una opción de transporte","Infrmación",MessageBoxButtons.OK,MessageBoxIcon.Information); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            if (_Txt_Alto.Text.Trim().Length == 0)
            { _Txt_Alto.Text = "0"; }
            if (_Txt_Ancho.Text.Trim().Length == 0)
            { _Txt_Ancho.Text = "0"; }
            if (_Txt_Profundidad.Text.Trim().Length == 0)
            { _Txt_Profundidad.Text = "0"; }
            if (_Txt_Capacidad.Text.Trim().Length == 0)
            { _Txt_Capacidad.Text = "0"; }
            _Er_Error.Dispose();
            if (_Txt_Placa.Text.Trim().Length > 0 & _Txt_Profundidad.Text.Trim().Length > 0 & _Txt_Modelo.Text.Trim().Length > 0 & _Txt_Marca.Text.Trim().Length > 0 & _Txt_Color.Text.Trim().Length > 0 & _Txt_Capacidad.Text.Trim().Length > 0 & _Txt_Año.Text.Trim().Length > 0 & _Txt_Año.Text.Trim().Length > 0 & _Txt_Ancho.Text.Trim().Length > 0 & _Txt_Alto.Text.Trim().Length > 0 & _Cmb_Tipo.SelectedIndex != -1 & _Int_I != -1)
            {
                    string _Str_Cadena = "UPDATE TTRANSPORTE Set cplaca='" + _Txt_Placa.Text.Trim().ToUpper() + "',cmarca='" + _Txt_Marca.Text.Trim().ToUpper() + "',cmodelo='" + _Txt_Modelo.Text.Trim().ToUpper() + "',ccolor='" + _Txt_Color.Text.Trim().ToUpper() + "',ctttransporte='" + _Cmb_Tipo.SelectedValue + "',cintext='" + _Int_I.ToString() + "',cano='" + _Txt_Año.Text.Trim() + "',calto='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alto.Text.Trim().ToUpper())) + "',cancho='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Ancho.Text.Trim().ToUpper())) + "',cprofundidad='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Profundidad.Text.Trim().ToUpper())) + "',ccapcarg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capacidad.Text.Trim().ToUpper())) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    return true;
            }
            else
            {
                if (_Txt_Placa.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Placa, "Iformación requerida!!!"); }
                if (_Txt_Profundidad.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Profundidad, "Iformación requerida!!!"); }
                if (_Txt_Modelo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Modelo, "Iformación requerida!!!"); }
                if (_Txt_Marca.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Marca, "Iformación requerida!!!"); }
                if (_Txt_Color.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Color, "Iformación requerida!!!"); }
                if (_Txt_Capacidad.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Capacidad, "Iformación requerida!!!"); }
                if (_Txt_Año.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Año, "Iformación requerida!!!"); }
                if (_Txt_Ancho.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Ancho, "Iformación requerida!!!"); }
                if (_Txt_Alto.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Alto, "Iformación requerida!!!"); }
                if (_Cmb_Tipo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Tipo, "Iformación requerida!!!"); }
                if (_Int_I == -1) { MessageBox.Show("Debe seleccionar una opción de transporte", "Infrmación", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TTRANSPORTE Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cplaca='" + _Txt_Placa.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        int _Int_I = -1;
        private void _Rbt_Mosanca_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Mosanca.Checked)
            {
                _Int_I = 1;
            }
            else

            {
                _Int_I = 0;
            }
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Placa");
            _Tsm_Menu[1] = new ToolStripMenuItem("Marca");
            _Tsm_Menu[2] = new ToolStripMenuItem("Modelo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cplaca";
            _Str_Campos[1] = "cmarca";
            _Str_Campos[2] = "cmodelo";
            string _Str_Cadena = "SELECT TTRANSPORTE.cplaca AS Placa, TTRANSPORTE.cmarca AS Marca, TTRANSPORTE.cmodelo AS Modelo, TTTRANSPORTE.cname AS Tipo " +
"FROM TTRANSPORTE LEFT JOIN " +
"TTTRANSPORTE ON TTRANSPORTE.ctttransporte = TTTRANSPORTE.cttransporte " +
"WHERE  (TTRANSPORTE.cdelete = '0')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Transporte", _Tsm_Menu, _Dg_Grid,true,"");
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Rbt_Externo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Externo.Checked)
            {
                _Int_I = 0;
            }
            else
            {
                _Int_I = 1;
            }
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Profundidad.Enabled = false;
            _Txt_Placa.Enabled = false;
            _Txt_Modelo.Enabled = false;
            _Txt_Marca.Enabled = false;
            _Txt_Color.Enabled = false;
            _Txt_Capacidad.Enabled = false;
            _Txt_Año.Enabled = false;
            _Txt_Ancho.Enabled = false;
            _Txt_Alto.Enabled = false;
            _Rbt_Mosanca.Enabled = false;
            _Rbt_Externo.Enabled = false;
            _Cmb_Tipo.Enabled = false;
        }
        

        private void _Txt_Año_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Año_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Año.Text))
            {
                _Txt_Año.Text = "";
            } 
        }
        private bool _Mtd_VerificarTrasportista(string _P_Str_Placa)
        {
            string _Str_Cadena = "SELECT cplaca FROM TTRANSPORTISTA WHERE cplaca='" + _P_Str_Placa + "' AND cactivate='1' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private void _Bt_Transportista_Click(object sender, EventArgs e)
        {
            if (_Txt_Placa.Text.Trim().Length > 0 & !_Txt_Placa.Enabled)
            {
                if (!_Mtd_VerificarTrasportista(_Txt_Placa.Text.Trim()))
                {
                    if (!_Bol_Tabs)
                    {
                        Frm_Transportista _Frm = new Frm_Transportista(_Txt_Placa.Text);
                        if (_Txt_Placa.Text.Trim().Length > 0)
                        {
                            _myUtilidad._Mtd_CerrarFormHijo(((Frm_Padre)this.MdiParent), "Frm_Transportista");
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                        }
                        else
                        {
                            if (!((Frm_Padre)this.MdiParent)._Mtd_AbiertoOno(_Frm))
                            { _Frm.MdiParent = this.MdiParent; _Frm.Show(); }
                            else
                            { _Frm.Dispose(); }
                        }
                    }
                    else
                    {
                        Frm_Transportista _Frm = new Frm_Transportista(_Txt_Placa.Text);
                        _Frm.ShowDialog(this);
                    }
                }
                else
                { MessageBox.Show("El trasporte ya tiene un transportista asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            { MessageBox.Show("Debe guardar la información para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
        private void _Mtd_RowHeaderMouseDoubleClick(string _P_Str_Placa)
        {
            _Er_Error.Dispose();
            _Mtd_Deshabilitar_Todo();
            string _Str_Cadena = "Select cplaca,cmarca,cmodelo,ccolor,ctttransporte,cintext,cano,calto,cancho,cprofundidad,ccapcarg from TTRANSPORTE where cdelete='0' and cplaca='" + _P_Str_Placa + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Alto.Text = _Ds.Tables[0].Rows[0]["calto"].ToString();
                _Txt_Ancho.Text = _Ds.Tables[0].Rows[0]["cancho"].ToString();
                _Txt_Año.Text = _Ds.Tables[0].Rows[0]["cano"].ToString();
                _Txt_Capacidad.Text = _Ds.Tables[0].Rows[0]["ccapcarg"].ToString();
                _Txt_Color.Text = _Ds.Tables[0].Rows[0]["ccolor"].ToString();
                _Txt_Marca.Text = _Ds.Tables[0].Rows[0]["cmarca"].ToString();
                _Txt_Modelo.Text = _Ds.Tables[0].Rows[0]["cmodelo"].ToString();
                _Txt_Placa.Text = _Ds.Tables[0].Rows[0]["cplaca"].ToString();
                _Txt_Profundidad.Text = _Ds.Tables[0].Rows[0]["cprofundidad"].ToString();
                if (_Ds.Tables[0].Rows[0]["cintext"].ToString() == "1")
                { _Rbt_Mosanca.Checked = true; }
                else
                { _Rbt_Externo.Checked = true; }
                if (_Ds.Tables[0].Rows[0]["ctttransporte"] != null)
                {
                    _Cmb_Tipo.SelectedValue = _Ds.Tables[0].Rows[0]["ctttransporte"].ToString();
                }
            }
            if (!_Bol_Tabs)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
            }
            _Tb_Tab.SelectedIndex = 1;
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_RowHeaderMouseDoubleClick(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Cursor = Cursors.Default;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Placa.Text.Trim().Length == 0 & !_Txt_Placa.Enabled & e.TabPageIndex != 0)
            { e.Cancel = true; }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex>-1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }
    }
}