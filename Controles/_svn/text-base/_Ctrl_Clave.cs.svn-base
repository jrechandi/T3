using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class _Ctrl_Clave : UserControl
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public _Ctrl_Clave()
        {
            InitializeComponent();
        }
        int _Int_Sw = 0;
        Control _Ctrl_Control;
        public _Ctrl_Clave(int _P_Int_Sw, Control _P_Ctrl_Control)
        {
            InitializeComponent();
            //IMPORTANTE: En el metodo InitializeComponent el control se ha colocado como visible = false 
            //por esta razón abajo se a colocado como visible = true para llamar al evento VisibleChange,
            //si se crea un evento nuevo o de alguna manera cambia el archivo .designer de este control 
            //se debe volver a coloca el visible = false porque al cambiar el .designer se pierde el visible = false que se coloco.
            _Int_Sw = _P_Int_Sw;
            if (_Int_Sw == 1)
            { _P_Ctrl_Control.Controls.Add(this); }
            else if (_Int_Sw == 2 || _Int_Sw == 3 || _Int_Sw == 4 || _Int_Sw == 5)
            { ((Frm_Padre)((Form)_P_Ctrl_Control).MdiParent).Controls.Add(this); }
            _Ctrl_Control = _P_Ctrl_Control;
            this.Left = (this.Parent.Width / 2) - (this.Width / 2);
            this.Top = (this.Parent.Height / 2) - (this.Height / 2);
            _Mtd_Color_Estandar(this);
            this.Visible = true;
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
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Int_Sw == 1)
                {
                    Frm_AjusteSalida _Frm = new Frm_AjusteSalida();
                    _Frm.Name = "Frm_AjusteSalida2";
                    if (!((Frm_Padre)this.Parent)._Mtd_AbiertoOno(_Frm))
                    { _Frm.MdiParent = (Form)this.Parent; _Frm.Dock = DockStyle.Fill; _Frm.Show(); }
                    else
                    { _Frm.Dispose(); }
                    this.Dispose();
                }
                else if (_Int_Sw == 2)
                {
                    this.Dispose();
                }
                else if (_Int_Sw == 3)
                {
                    //Codigo
                    string _Str_OC = ((Frm_Busqueda)_Ctrl_Control)._Dg_Datagrid.Rows[((Frm_Busqueda)_Ctrl_Control)._Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    string _Str_SentenciaSQL = "UPDATE TORDENCOMPM SET CEVALUADO='1' WHERE CNUMOC='" + _Str_OC + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    _Str_SentenciaSQL = "UPDATE TORDENCOMPM SET CCERRADA='1' WHERE CNUMOC='" + _Str_OC + "' AND CCOMPANY='"+Frm_Padre._Str_Comp+"'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    ((Frm_Busqueda)_Ctrl_Control)._Mtd_Acualizar();
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else if (_Int_Sw == 4)
                {
                    this.Visible = false;
                    ((Frm_RelPagProv)_Ctrl_Control).Cursor = Cursors.WaitCursor;
                    ((Frm_RelPagProv)_Ctrl_Control)._Mtd_GuardarCxP();
                    ((Frm_RelPagProv)_Ctrl_Control).Cursor = Cursors.Default;
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.Parent)._Frm_Contenedor._async_Default);
                    this.Dispose();
                }
                else if (_Int_Sw == 5)
                {
                    this.Visible = false;
                    ((Frm_GuiaManual)_Ctrl_Control)._Mtd_IntroducirNumeroGuia();
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Txt_Clave.Focus();
                _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Ctrl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Int_Sw == 1 || _Int_Sw == 2 || _Int_Sw == 3 || _Int_Sw == 4 || _Int_Sw == 5)
            {
                _Txt_Clave.Focus();
                ((Frm_Padre)this.Parent).menuStrip1.Enabled = !this.Visible;
                ((Frm_Padre)this.Parent)._Ctrl_Buscar1.Enabled = !this.Visible;
                foreach (Form _Frm in ((Frm_Padre)this.Parent).MdiChildren)
                {
                    _Frm.Enabled = !this.Visible;
                }
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            if (_Int_Sw == 1 || _Int_Sw == 3 || _Int_Sw == 4)
            { this.Dispose(); }
            else if (_Int_Sw == 2 || _Int_Sw == 5)
            { ((Form)_Ctrl_Control).Close(); this.Dispose(); }
        }

        private void _Txt_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)13))
            {
                _Bt_Aceptar.PerformClick();
            }
        }
    }
}
