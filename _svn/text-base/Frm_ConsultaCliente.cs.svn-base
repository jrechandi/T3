using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaCliente : Form
    {
        public string _Str_FrmR = "";
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ConsultaCliente()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarClientes()
        {
            string _Str_Sql = "SELECT ccliente,(CONVERT(VARCHAR(10),ccliente) + '-' + rtrim(c_nomb_comer)) as cclientename FROM TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete=0";
            _myUtilidad._Mtd_CargarCheckList(_LstChkClientes, _Str_Sql);
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_LstChkClientes.CheckedItems.Count > 0)
            {
                for (int _I = 0; _I < _LstChkClientes.CheckedItems.Count; _I++)
                {
                    _Str_FrmR = ((Clases._Cls_ArrayList)_LstChkClientes.CheckedItems[_I]).Value;
                }
            }
            this.Close();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Str_FrmR = "";
            this.Close();
        }

        private void Frm_ConsultaCliente_Load(object sender, EventArgs e)
        {
            _Mtd_CargarClientes();
        }

        private void _LstChkClientes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (_LstChkClientes.CheckedItems.Count == 1)
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }
    }
}