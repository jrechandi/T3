using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class _Ctrl_Comp : UserControl
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public _Ctrl_Comp()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            ((Frm_Padre)Application.OpenForms["Frm_Padre"]).Controls.Add(this);
            this.Left = (this.Parent.Width / 2) - (this.Width / 2);
            this.Top = (this.Parent.Height / 2) - (this.Height / 2);
            this.Visible = false;
            this.Visible = true;
        }
        private void _Mtd_CargarComp()
        {
            //--------------------------------------
            string _Str_Cadena = "SELECT cvendedor FROM TUSER WHERE CUSER='" + Frm_Padre._Str_Use + "' AND NOT cvendedor IS NULL AND LEN(RTRIM(CONVERT(VARCHAR,cvendedor)))>0";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "SELECT TCOMPANY.ccompany, TCOMPANY.cname FROM TUSER INNER JOIN TUSERCOMP ON TUSER.cuser = TUSERCOMP.cuser INNER JOIN TGROUP ON TUSER.cgroup = TGROUP.cgroup INNER JOIN TCOMPANY ON TUSERCOMP.ccompany = TCOMPANY.ccompany INNER JOIN TGROUPCOMPANYD ON TCOMPANY.ccompany = TGROUPCOMPANYD.ccompany WHERE (TUSERCOMP.cuser = '" + Frm_Padre._Str_Use + "') AND (TUSERCOMP.ccompany <> '" + Frm_Padre._Str_Comp + "') AND (TGROUP.cdelete = 0) AND (NOT (TUSER.cvendedor IS NULL)) AND (LEN(RTRIM(CONVERT(VARCHAR, TUSER.cvendedor))) > 0) AND (TGROUPCOMPANYD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')";
            }
            else
            {
                _Str_Cadena = "Select TCOMPANY.ccompany,TCOMPANY.cname from TCOMPANY INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany=TCOMPANY.ccompany where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TCOMPANY.ccompany<>'" + Frm_Padre._Str_Comp + "' and TCOMPANY.cdelete='0'";
            }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Companies, _Str_Cadena);
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
        private string _Mtd_NombUser(string _P_Str_User)
        {
            string _Str_Cadena = "Select cname from TUSER where cuser='" + _P_Str_User + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
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
        private bool _Mtd_PausaCambios(string _P_Str_Company)
        {
            string _Str_Cadena = "SELECT cpausacambio FROM TCOMPANY WHERE ccompany='" + _P_Str_Company + "' AND cpausacambio='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_FrmFisicoVsTeoricoAbierto()
        {
            foreach (Form _Frm in ((Frm_Padre)this.Parent).MdiChildren)
            {
                if (_Frm.GetType() == typeof(Frm_FisicoVsTeorico))
                { return true; }
            }
            return false;
        }
        private void _Mtd_CambiarComp(string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT cgroupcomp FROM TGROUPCOMPANYD where ccompany='" + _P_Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                //_Cls_VariosMetodos._Mtd_Cerrar_T3_Popup("T3BUGS");
                //string _Str_Ruta = Application.StartupPath + @"\T3BUGS.exe";
                string _Str_GroupComp = _Ds.Tables[0].Rows[0][0].ToString().Trim();      
                //string _Str_Argumentos = _Str_GroupComp.Trim() + "," + _P_Str_Comp.ToString().Trim() + "," + Frm_Padre._Str_Use + "," + CLASES._Cls_Conexion._G_Str_VersionT3.Trim().Replace(" ", "_") + "," + CLASES._Cls_Conexion._Int_Sucursal + "," + Convert.ToInt32(CLASES._Cls_Conexion._Bol_UsuarioRemoto) + "," + Convert.ToInt32(CLASES._Cls_Conexion._Bol_ConexionRemota);
                //string[] _Stradssd = _Str_Argumentos.Split(',');
                //System.Diagnostics.Process _System_Proceso = System.Diagnostics.Process.Start(_Str_Ruta, _Str_Argumentos);
                ((Frm_Padre)Application.OpenForms["Frm_Padre"]).statusBar1.Panels["statusBarPanel3"].Text = _P_Str_Comp.Trim().ToUpper() + " - " + _Mtd_NombComp(_P_Str_Comp).Trim();
                ((Frm_Padre)Application.OpenForms["Frm_Padre"]).statusBar1.Panels["statusBarPanel2"].Text = Frm_Padre._Str_Use.Trim() + " - " + _Mtd_NombUser(Frm_Padre._Str_Use).Trim();
                Frm_Padre._Str_GroupComp = _Str_GroupComp.Trim();
                Frm_Padre._Str_Comp = _P_Str_Comp.Trim();
                ((Frm_Contenedor)Application.OpenForms["Frm_Contenedor"])._Bol_CambioComp = true;
                Application.OpenForms["Frm_Contenedor"].Close();
                foreach (Form _Frm in ((Frm_Padre)this.Parent).MdiChildren)
                {
                    _Frm.Close();
                }
                ((Frm_Padre)this.Parent)._Mtd_InicializarT3();
                Cursor = Cursors.Default;
                MessageBox.Show("El cambio de compañía se ha realizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
        private void _Ctrl_Comp_Load(object sender, EventArgs e)
        {
            _Mtd_CargarComp();
        }

        private void _Ctrl_Comp_VisibleChanged(object sender, EventArgs e)
        {
            ((Frm_Padre)this.Parent).menuStrip1.Enabled = !this.Visible;
            ((Frm_Padre)this.Parent)._Ctrl_Buscar1.Enabled = !this.Visible;
            foreach (Form _Frm in ((Frm_Padre)this.Parent).MdiChildren)
            {
                _Frm.Enabled = !this.Visible;
            }
        }

        private void _Bt_Cambiar_Click(object sender, EventArgs e)
        {
            if (_Cmb_Companies.SelectedIndex > 0)
            {
                if (_Mtd_PausaCambios(Convert.ToString(_Cmb_Companies.SelectedValue).Trim()))
                { MessageBox.Show("En estos momentos se están realizando cambios en el sistema para la compañía seleccionada. Por favor intente mas tarde.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else if (_Mtd_FrmFisicoVsTeoricoAbierto())
                { MessageBox.Show("Debe cerrar los formularios activos para realizar el cambio de compañía.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    if (MessageBox.Show("Se cancelará cualquier operación que esté realizando. ¿Esta seguro de cambiar la compañía?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _Mtd_CambiarComp(Convert.ToString(_Cmb_Companies.SelectedValue));
                    }
                    else
                    { this.Dispose(); }
                }
            }
            else
            { MessageBox.Show("Debe seleccionar una compañía para hacer el cambio", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void _Cmb_Companies_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarComp();
        }
    }
}