using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace T3
{
    public partial class Frm_EstatusClientes : Form
    {
        CLASES._Cls_Varios_Metodos _G_MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        int _Int_Estatus = 4;
        string _Str_ThisText = "";
        string[] _Str_Array = new string[0];
        public Frm_EstatusClientes()
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Rb_BloqueoAutomatico.Checked = true;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
        }
        public Frm_EstatusClientes(bool _P_Bol_BloqueoManual)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Rb_BloqueoManual.Checked = true;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
        }
        public Frm_EstatusClientes(int _P_Int_Estatus)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Estatus = _P_Int_Estatus;
            _Rb_BloqueoAutomatico.Checked = true;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
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
                    if (_Ctrl.Name != _Rb_BloqueoAutomatico.Name & _Ctrl.Name != _Rb_BloqueoManual.Name)
                    { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
                }
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Mtd_Cargar_Estado()
        {
            _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Estado, "Select RTRIM(cestate),cname from TESTATE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cname ASC");
            _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
        }

        public void _Mtd_Actualizar(int _P_Int_Estatus, string _P_Str_Cliente)
        {
            string _Str_Comps = CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp();
            _Dg_Grid.Columns["_Col_MotivoBloqueo"].Visible = _Rb_BloqueoManual.Checked;
            string _Str_Cadena = "";
            if (_P_Str_Cliente.Trim().Length == 0)
            {
                _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT dbo.VST_CLIENTE_VENDEDOR.ccliente, dbo.VST_CLIENTE_VENDEDOR.c_nomb_comer, dbo.VST_CLIENTE_VENDEDOR.c_limt_credit_f, dbo.VST_CLIENTE_VENDEDOR.c_fact_venc_f, dbo.VST_CLIENTE_VENDEDOR.c_cheq_dev_f, dbo.VST_CLIENTE_VENDEDOR.c_rif, dbo.VST_CLIENTE_VENDEDOR.cfechabloqueocred, dbo.VST_CLIENTE_VENDEDOR.c_motivo_bloqueo_manual, dbo.TCITY.cname AS c_ciudad";
                _Str_Cadena += " FROM dbo.VST_CLIENTE_VENDEDOR";
                _Str_Cadena += " INNER JOIN dbo.TCLIENTE";
                _Str_Cadena += " ON dbo.VST_CLIENTE_VENDEDOR.cgroupcomp = dbo.TCLIENTE.cgroupcomp AND dbo.VST_CLIENTE_VENDEDOR.ccliente = dbo.TCLIENTE.ccliente";
                _Str_Cadena += " INNER JOIN dbo.TCITY";
                _Str_Cadena += " ON dbo.TCLIENTE.c_ciudad = dbo.TCITY.ccity";

                if (_P_Int_Estatus == 0)
                {
                    _Str_Cadena += " WHERE dbo.VST_CLIENTE_VENDEDOR.cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND dbo.VST_CLIENTE_VENDEDOR.cdelete='0'";
                    _Str_Cadena += " AND (VST_CLIENTE_VENDEDOR.c_limt_credit_f = '1' OR VST_CLIENTE_VENDEDOR.c_fact_venc_f = '1' OR VST_CLIENTE_VENDEDOR.c_cheq_dev_f = '1'";
                    _Str_Cadena += " OR EXISTS(SELECT ccliente FROM TCOTPEDFACM WHERE " + _Str_Comps;
                    _Str_Cadena += " AND TCOTPEDFACM.ccliente=VST_CLIENTE_VENDEDOR.ccliente";
                    _Str_Cadena += " AND TCOTPEDFACM.cstatus='3'";
                    _Str_Cadena += " AND ISNULL(TCOTPEDFACM.caprobadocredito, 0) = 0)) ";
                }
                else if (_P_Int_Estatus == 1)
                {
                    _Str_Cadena += " WHERE dbo.VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.c_limt_credit_f = '1'";
                    _Str_Cadena += " AND dbo.VST_CLIENTE_VENDEDOR.cdelete = '0' ";
                }
                else if (_P_Int_Estatus == 2)
                {
                    _Str_Cadena += " WHERE dbo.VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.c_fact_venc_f = '1'";
                    _Str_Cadena += " AND dbo.VST_CLIENTE_VENDEDOR.cdelete = '0' ";
                }
                else if (_P_Int_Estatus == 3)
                {
                    _Str_Cadena += " WHERE dbo.VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.c_cheq_dev_f = '1'";
                    _Str_Cadena += " AND dbo.VST_CLIENTE_VENDEDOR.cdelete = '0' ";
                }
                else if (_P_Int_Estatus == 4)
                {
                    _Str_Cadena += " WHERE dbo.VST_CLIENTE_VENDEDOR.cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND EXISTS(SELECT ccliente FROM TCOTPEDFACM WHERE " + _Str_Comps;
                    _Str_Cadena += " AND TCOTPEDFACM.ccliente = VST_CLIENTE_VENDEDOR.ccliente";
                    _Str_Cadena += " AND TCOTPEDFACM.cstatus='3'";
                    _Str_Cadena += " AND ISNULL(TCOTPEDFACM.caprobadocredito, 0) = 0)";
                    _Str_Cadena += " AND dbo.VST_CLIENTE_VENDEDOR.cdelete='0'";
                }
                else if (_P_Int_Estatus == 30)
                {
                    _Str_Cadena += " WHERE dbo.VST_CLIENTE_VENDEDOR.cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND dbo.VST_CLIENTE_VENDEDOR.cdelete='0'";
                    _Str_Cadena += " AND (EXISTS(SELECT ccliente FROM TCOTPEDFACM WHERE " + _Str_Comps;
                    _Str_Cadena += " AND TCOTPEDFACM.ccliente = VST_CLIENTE_VENDEDOR.ccliente AND cstatus='3'";
                    _Str_Cadena += " AND ISNULL(TCOTPEDFACM.caprobadocredito,0) = 0";
                    _Str_Cadena += " AND TCOTPEDFACM.cexclimaprob='1')) ";
                }

            }
            else
            {
                //_Str_Cadena = "SELECT DISTINCT ccliente, c_nomb_comer, c_limt_credit_f, c_fact_venc_f, c_cheq_dev_f, c_rif, cfechabloqueocred, c_motivo_bloqueo_manual, dbo.TCITY.cname AS c_ciudad";
                _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT dbo.VST_CLIENTE_VENDEDOR.ccliente, dbo.VST_CLIENTE_VENDEDOR.c_nomb_comer, dbo.VST_CLIENTE_VENDEDOR.c_limt_credit_f, dbo.VST_CLIENTE_VENDEDOR.c_fact_venc_f, dbo.VST_CLIENTE_VENDEDOR.c_cheq_dev_f, dbo.VST_CLIENTE_VENDEDOR.c_rif, dbo.VST_CLIENTE_VENDEDOR.cfechabloqueocred, dbo.VST_CLIENTE_VENDEDOR.c_motivo_bloqueo_manual, dbo.TCITY.cname AS c_ciudad";
                _Str_Cadena += " FROM VST_CLIENTE_VENDEDOR";
                _Str_Cadena += " INNER JOIN dbo.TCLIENTE";
                _Str_Cadena += " ON dbo.VST_CLIENTE_VENDEDOR.cgroupcomp = dbo.TCLIENTE.cgroupcomp AND dbo.VST_CLIENTE_VENDEDOR.ccliente = dbo.TCLIENTE.ccliente";
                _Str_Cadena += " INNER JOIN dbo.TCITY";
                _Str_Cadena += " ON dbo.TCLIENTE.c_ciudad = dbo.TCITY.ccity";

                if (_P_Int_Estatus == 0)
                {
                    _Str_Cadena += " WHERE VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.cdelete='0'";
                    _Str_Cadena += " AND (VST_CLIENTE_VENDEDOR.c_limt_credit_f = '1' OR VST_CLIENTE_VENDEDOR.c_fact_venc_f = '1' OR VST_CLIENTE_VENDEDOR.c_cheq_dev_f = '1'";
                    _Str_Cadena += " OR EXISTS(SELECT ccliente FROM TCOTPEDFACM WHERE " + _Str_Comps;
                    _Str_Cadena += " AND TCOTPEDFACM.ccliente = VST_CLIENTE_VENDEDOR.ccliente";
                    _Str_Cadena += " AND TCOTPEDFACM.cstatus='3'";
                    _Str_Cadena += " AND ISNULL(TCOTPEDFACM.caprobadocredito,0) = 0)) ";
                }
                else if (_P_Int_Estatus == 1)
                {
                    _Str_Cadena += " WHERE VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.cdelete = '0'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.c_limt_credit_f = '1' ";
                }
                else if (_P_Int_Estatus == 2)
                {
                    _Str_Cadena += " WHERE VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.cdelete = '0'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.c_fact_venc_f = '1' ";
                }
                else if (_P_Int_Estatus == 3)
                {
                    _Str_Cadena += " WHERE VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.cdelete = '0'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.c_cheq_dev_f = '1' ";
                }
                else if (_P_Int_Estatus == 4)
                {
                    _Str_Cadena += " WHERE VST_CLIENTE_VENDEDOR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.cdelete = '0'";
                    _Str_Cadena += " AND EXISTS(SELECT ccliente FROM TCOTPEDFACM WHERE " + _Str_Comps;
                    _Str_Cadena += " AND TCOTPEDFACM.ccliente = VST_CLIENTE_VENDEDOR.ccliente";
                    _Str_Cadena += " AND TCOTPEDFACM.cstatus = '3'";
                    _Str_Cadena += " AND ISNULL(TCOTPEDFACM.caprobadocredito, 0) = 0) ";
                }
                else if (_P_Int_Estatus == 30)
                {
                    _Str_Cadena += " WHERE VST_CLIENTE_VENDEDOR.cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND VST_CLIENTE_VENDEDOR.cdelete = '0'";
                    _Str_Cadena += " AND (EXISTS(SELECT ccliente FROM TCOTPEDFACM WHERE " + _Str_Comps;
                    _Str_Cadena += " AND TCOTPEDFACM.ccliente = VST_CLIENTE_VENDEDOR.ccliente";
                    _Str_Cadena += " AND TCOTPEDFACM.cstatus = '3'";
                    _Str_Cadena += " AND ISNULL(TCOTPEDFACM.caprobadocredito, 0) = 0";
                    _Str_Cadena += " AND TCOTPEDFACM.cexclimaprob = '1')) ";
                }
            }

            if (_Cmb_Estado.SelectedIndex > 0)
                _Str_Cadena += " AND TCLIENTE.c_estado = '" + Convert.ToString(_Cmb_Estado.SelectedValue).Trim() + "'";

            if (_Rb_BloqueoAutomatico.Checked)
            {
                _Str_Cadena += " AND ISNULL(dbo.VST_CLIENTE_VENDEDOR.c_bloqueo_manual, 0) = 0 ";
                _Str_Cadena += " ORDER BY dbo.VST_CLIENTE_VENDEDOR.ccliente;";

                DesbloqueoManualClienteToolStripMenuItem.Visible = false;
            }

            if (_Rb_BloqueoManual.Checked)
            {
                _Str_Cadena = "SELECT TOP 100 PERCENT dbo.TCLIENTE.ccliente, dbo.TCLIENTE.c_nomb_comer, dbo.TCLIENTE.c_limt_credit_f, dbo.TCLIENTE.c_fact_venc_f, dbo.TCLIENTE.c_cheq_dev_f,";
                _Str_Cadena += " dbo.TCLIENTE.c_rif, dbo.TCLIENTE.c_bloqueo_manual_fecha, dbo.TCLIENTE.c_motivo_bloqueo_manual, dbo.TCITY.cname as c_ciudad";
                _Str_Cadena += " FROM dbo.TCLIENTE";
                _Str_Cadena += " INNER JOIN dbo.TCITY ON dbo.TCLIENTE.c_ciudad = dbo.TCITY.ccity";

                if (_P_Str_Cliente.Trim().Trim().Length == 0)
                {
                    _Str_Cadena += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND c_bloqueo_manual='1' AND dbo.TCLIENTE.cdelete='0'";
                }
                else
                {
                    _Str_Cadena += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente LIKE '" + _P_Str_Cliente + "%'";
                    _Str_Cadena += " AND c_bloqueo_manual='1' AND dbo.TCLIENTE.cdelete='0'";
                }

                if (_Cmb_Estado.SelectedIndex > 0)
                    _Str_Cadena += " AND TCLIENTE.c_estado = '" + Convert.ToString(_Cmb_Estado.SelectedValue).Trim() + "'";

                _Str_Cadena += " ORDER BY ccliente;";

                if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_BLOQUEO_MANUAL_CLIENTE"))
                {
                    DesbloqueoManualClienteToolStripMenuItem.Visible = true;
                }
                else
                {
                    DesbloqueoManualClienteToolStripMenuItem.Visible = false;
                }
            }

            Cursor = Cursors.WaitCursor;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            _Dg_Grid.ClearSelection();
            _Dg_Grid.Refresh();
            //--------------------------------------------------------------------
            if (_P_Int_Estatus == 0)
            { this.Text = _Str_ThisText + " (Todos los clientes)"; }
            else if (_P_Int_Estatus == 1)
            { this.Text = _Str_ThisText + " (Límite de crédito)"; }
            else if (_P_Int_Estatus == 2)
            { this.Text = _Str_ThisText + " (Documentos pendientes)"; }
            else if (_P_Int_Estatus == 3)
            { this.Text = _Str_ThisText + " (Cheques devueltos)"; }
            else if (_P_Int_Estatus == 4)
            { this.Text = _Str_ThisText + " (Con pedidos bloqueados por crédito)"; }
        }
        private void Frm_ConsultaPedidos_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_DesbloqueoManualCliente.Left = (this.Width / 2) - (_Pnl_DesbloqueoManualCliente.Width / 2);
            _Pnl_DesbloqueoManualCliente.Top = (this.Height / 2) - (_Pnl_DesbloqueoManualCliente.Height / 2);
            _Dg_Grid.ClearSelection();
            _Mtd_Cargar_Estado();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {

        }

        private void _Tool_Constodos_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_ConsLimite_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_ConsDocumentos_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 2;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_ConsCheques_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 3;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }
        private void _Tool_BusTodos_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;
        }

        private void _Tool_BusLimites_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;
        }

        private void _Tool_BusDocumentos_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 2;
        }

        private void _Tool_BusCheques_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 3;
        }

        private void _Tool_Consulta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Tool_Consulta.Text))
            {
                _Tool_Consulta.Text = "";
            }
            else
            {
                _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            }
        }

        private void _Tool_Consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    if (e.KeyChar == (char)13)
            //    {
            //        _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            //    }
            //}
        }

        private void _Tool_Actualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                this.Cursor = Cursors.WaitCursor;
                Frm_EstatusClientesDetalle _Frm = new Frm_EstatusClientesDetalle(_Dg_Grid.Rows[_Dg_Grid.CurrentRow.Index].Cells["Column1"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentRow.Index].Cells["c_rif"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentRow.Index].Cells[1].Value.ToString(), _Int_Estatus, _Tool_Consulta.Text, this);
                this.Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
                if (_Str_Array.Length > 0)
                {
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                    {
                        if (_Dg_Row.Cells["Column1"] != null)
                        {
                            int _Int_Index = Array.IndexOf(_Str_Array, Convert.ToString(_Dg_Row.Cells["Column1"].Value));
                            if (_Int_Index != -1)
                            {
                                _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                            }
                            else
                            {
                                _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void _Tool_ConsPedBloCre_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 4;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void Frm_EstatusClientes_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
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

        private void _Rb_BloqueoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            if (_Rb_BloqueoAutomatico.Checked)
            {
                _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
                if (_Cmb_Estado.SelectedIndex > 0)
                    _Cmb_Estado.SelectedIndex = 0;
                _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
                _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text); toolStripButton3.Enabled = true; toolStripButton1.Enabled = true; 
            }
        }

        private void _Rb_BloqueoManual_CheckedChanged(object sender, EventArgs e)
        {
            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            if (_Rb_BloqueoManual.Checked)
            {
                _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
                if (_Cmb_Estado.SelectedIndex > 0)
                    _Cmb_Estado.SelectedIndex = 0;
                _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
                _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text); toolStripButton3.Enabled = false; toolStripButton1.Enabled = false; 
            }
        }

        private void DesbloqueoManualClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Txt_DesbloqueoManualClienteClave.Text = "";
            _Pnl_DesbloqueoManualCliente.Visible = true;
            _Txt_DesbloqueoManualClienteClave.Focus();
        }

        private void _Pnl_DesbloqueoManualCliente_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_DesbloqueoManualCliente.Visible)
            { _Dg_Grid.Enabled = false; toolStrip1.Enabled = false; _Rb_BloqueoAutomatico.Enabled = false; _Rb_BloqueoManual.Enabled = false; }
            else
            { _Dg_Grid.Enabled = true; toolStrip1.Enabled = true; _Rb_BloqueoAutomatico.Enabled = true; _Rb_BloqueoManual.Enabled = true; }
        }

        private void _Bt_DesbloqueoManualClienteAceptar_Click(object sender, EventArgs e)
        {
            string _Str_CodClienteSeleccionado = _Dg_Grid.Rows[_Dg_Grid.CurrentRow.Index].Cells["Column1"].Value.ToString();
            //Cursor = Cursors.WaitCursor;
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_DesbloqueoManualClienteClave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {
                //Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "SELECT cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Str_Cadena = "Update TCLIENTE set c_bloqueo_manual = 0, c_bloqueo_manual_usuario = '" + Frm_Padre._Str_Use.ToString() + "', c_bloqueo_manual_fecha = GETDATE(), cuserupd = '" + Frm_Padre._Str_Use.ToString() + "', cdateupd = GETDATE() WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_CodClienteSeleccionado + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El cliente ha sido desbloqueado satisfactoriamente.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_DesbloqueoManualCliente.Visible = false;
                    _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);

                }
                else
                {
                    MessageBox.Show(this, "Clave incorrecta. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Txt_DesbloqueoManualClienteClave.Focus();
                    _Txt_DesbloqueoManualClienteClave.Select(0, _Txt_DesbloqueoManualClienteClave.Text.Length);
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show("ERROR:" + _Ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void _Bt_DesbloqueoManualClienteCancelar_Click(object sender, EventArgs e)
        {
            _Pnl_DesbloqueoManualCliente.Visible = false;
        }

        private static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_Historial_Click(object sender, EventArgs e)
        {
            System.Threading.Thread _Thr_Thread = new System.Threading.Thread(new System.Threading.ThreadStart(_Mtd_Cobranza));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor..!!");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
        }
        private void _Mtd_Cobranza()
        {
            try
            {
                _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    if (_Dg_Row.Cells["Column1"] != null)
                    {
                        if (_Mtd_VerificarCobranza(Convert.ToString(_Dg_Row.Cells["Column1"].Value)))
                        {
                            //((DataGridViewCheckBoxCell)_Dg_Row.Cells["ccobranza"]).TrueValue = "1";
                            //_Dg_Row.Cells["ccobranza"].Value = "1";
                            //((DataGridViewCheckBoxCell)_Dg_Row.Cells["ccobranza"]).TrueValue = "1";
                            _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki;
                            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, _Str_Array.Length + 1);
                            _Str_Array[_Str_Array.Length - 1] = Convert.ToString(_Dg_Row.Cells["Column1"].Value);
                        }
                        else
                        {
                            //((DataGridViewCheckBoxCell)_Dg_Row.Cells["ccobranza"]).FalseValue = "0";
                            //_Dg_Row.Cells["ccobranza"].Value = "0";
                            //((DataGridViewCheckBoxCell)_Dg_Row.Cells["ccobranza"]).FalseValue = "0";
                            _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Disculpe, no existe conexión con el servidor central. Intente de nuevo mas tarde. Gracias", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool _Mtd_VerificarCobranza(string _Str_Cliente)
        {
            bool _Bol_Valor = false;
            string _Str_Comps = CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp();
            string _Str_Sql = "SELECT cvendedor FROM VST_RELCOBRANZA_CLIENTESCONPEDIDOSBLOQUEADOS WHERE " + _Str_Comps + " AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_Cliente + "' AND caprobado=1 AND caprobadocredito=0 AND crelalista=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Valor = true;
            }
            _Str_Sql = "SELECT cvendedor FROM VST_T3_COBRANZASCLIENTEDESBPEDIDOS WHERE " + _Str_Comps + " AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_Cliente + "' AND ccerrada='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_Valor = true;
            }
            return _Bol_Valor;
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
        }
    }
}