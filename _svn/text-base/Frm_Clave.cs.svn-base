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
    public partial class Frm_Clave : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Clave()
        {
            InitializeComponent();
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this);
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
        }

        private void _Txt_Clave_TextChanged(object sender, EventArgs e)
        {
            _Bt_Aceptar.Enabled = _Txt_Clave.Text.Length > 0;
        }
    }
}
