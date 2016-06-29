using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace T3
{
    public partial class Frm_BusquedaCheq : Form
    {
        public Frm_BusquedaCheq()
        {
            InitializeComponent();
        }
        string _Str_Param1 = "";
        TextBox _Txt_Temp = new TextBox();
        public Frm_BusquedaCheq(string _P_Str_Param1,TextBox _P_Txt_Temp)
        {
            InitializeComponent();
            _Str_Param1 = _P_Str_Param1;
            _Txt_Temp = _P_Txt_Temp;
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
        private void _Bt_Cliente_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_Limpiar_C_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Tag = "0"; _Txt_Cliente.Text = "";
        }

        private void Frm_BusquedaCheq_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_Buscar()
        {
            string _Str_Filtro = "";
            if (_Txt_Cliente.Text.Trim().Length > 0)
            { _Str_Filtro = " AND ccliente='" + Convert.ToString(_Txt_Cliente.Tag).Trim() + "'"; }
            if (_Txt_Relacion.Text.Trim().Length > 0)
            { _Str_Filtro += " AND cidrelacobro LIKE '%" + _Txt_Relacion.Text.Trim() + "%'"; }
            if (_Txt_Cheque.Text.Trim().Length > 0)
            { _Str_Filtro += " AND cnumcheque LIKE '%" + _Txt_Cheque.Text.Trim() + "%'"; }
            if (_Chk_Fecha.Checked)
            { _Str_Filtro += " AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
            string _Str_Cadena = "Select cnumcheque as [Nº Cheque],dbo.Fnc_Formatear(cmontocheq) as [Monto Cheque],CONVERT(VARCHAR,ccliente)+ ' - ' +RTRIM(c_nomb_comer) as Cliente,cidrelacobro as Relación,CONVERT(VARCHAR, cfechaemision, 103) as [Fecha de Emisión],ccliente,cvendedor,RelTipo,ctipocobro,cbancodepo,cnumcuentadepo,ciddrelacobro_depd,ciddrelacobrodep,cbancocheque FROM VST_CONSULTA_CHEQUES WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT cnumcheque FROM TCHEQDEVUELT WHERE TCHEQDEVUELT.cgroupcomp=VST_CONSULTA_CHEQUES.cgroupcomp AND TCHEQDEVUELT.ccompany=VST_CONSULTA_CHEQUES.ccompany AND TCHEQDEVUELT.cnumcheque=VST_CONSULTA_CHEQUES.cnumcheque AND TCHEQDEVUELT.ccliente=VST_CONSULTA_CHEQUES.ccliente AND TCHEQDEVUELT.cidrelacobro=VST_CONSULTA_CHEQUES.cidrelacobro) " + _Str_Param1 + _Str_Filtro;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = false;
            _Dg_Grid.Columns[11].Visible = false;
            _Dg_Grid.Columns[12].Visible = false;
            _Dg_Grid.Columns[13].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (!_Chk_Fecha.Checked | (_Chk_Fecha.Checked & _Ctrl_ConsultaMes1._Bol_Listo))
            {
                if (!_Chk_SoloCheque.Checked)
                {
                    if (_Txt_Cliente.Text.Trim().Length > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_Buscar();
                        Cursor = Cursors.Default;
                    }
                    else
                    { MessageBox.Show("Debe seleccionar un cliente para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Buscar();
                    Cursor = Cursors.Default;
                }
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count > 0)
            {
                _Txt_Temp.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[3].Value).Trim();
                this.Close();
            }
        }

        private void _Chk_SoloCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_SoloCheque.Checked)
            {
                _Txt_Cliente.Enabled = false;
                _Txt_Relacion.Enabled = false;
                _Bt_Cliente.Enabled = false;
                _Bt_Limpiar_C.Enabled = false;
                _Ctrl_ConsultaMes1.Enabled = false;
            }
            else
            {
                _Txt_Cliente.Enabled = true;
                _Txt_Relacion.Enabled = true;
                _Bt_Cliente.Enabled = true;
                _Bt_Limpiar_C.Enabled = true;
                _Ctrl_ConsultaMes1.Enabled = true;
            }
        }
    }
}
