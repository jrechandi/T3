using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_OperBanc : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_OperBanc()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "coperbanc";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT TOPERBANC.coperbanc AS Código ,TOPERBANC.cname AS Descripción ,CASE cdebe WHEN '1' THEN 'X' ELSE '' END AS Debe ,CASE chaber WHEN '1' THEN 'X' ELSE '' END AS Haber ,CASE WHEN TCOUNT.ccount IS NULL THEN '' ELSE (TCOUNT.ccount + ' - ' + TCOUNT.cname) END AS [Cuenta Contable] FROM TOPERBANC LEFT OUTER JOIN TCOUNT ON TOPERBANC.ccount = TCOUNT.ccount WHERE (TOPERBANC.cdelete = '0') AND (ISNULL(TCOUNT.cdelete,0) = 0) AND ( (TCOUNT.ccompany = '" + Frm_Padre._Str_Comp +"') OR (TCOUNT.ccompany IS NULL) ) ";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Operaciones bancarias", _Tsm_Menu, _Dg_Grid, true, "", "Descripción");
            _Dg_Grid.Columns["Debe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Haber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cname,cdebe from TOPERBANC where coperbanc='" + _Pr_Str_Id + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Pr_Str_Id;
                _Txt_Des.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cdebe"]) == "1")
                {
                    _Rb_Debe.Checked = true;
                }
                else
                {
                    _Rb_Haber.Checked = true;
                }
            }
        }

        private void Frm_OperBanc_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount >= 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarData(Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Txt_Cod.Text = "";
                _Txt_Des.Text = "";
                _Rb_Debe.Checked = false;
                _Rb_Haber.Checked = false;
            }
            else 
            {
                e.Cancel = string.IsNullOrEmpty(_Txt_Cod.Text.Trim());
            }

        }
        private void Frm_OperBanc_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
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
    }
}