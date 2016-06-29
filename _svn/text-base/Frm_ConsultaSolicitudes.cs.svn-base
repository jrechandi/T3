using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace T3
{
    public partial class Frm_ConsultaSolicitudes : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public WaitCallback _async_Default;
        public Frm_ConsultaSolicitudes()
        {
            InitializeComponent();
            _Lbl_Prio1.BackColor = Color.FromArgb(255, 113, 113);
            _Lbl_Prio2.BackColor = Color.FromArgb(255, 175, 175);
            _Lbl_Prio3.BackColor = Color.FromArgb(255, 252, 183);
            _Lbl_Prio4.BackColor = Color.FromArgb(220, 218, 254);
            _Mtd_Ini(false);
            _Cmb_Solicitante.SelectedValue = Frm_Padre._Str_Use.Trim().ToUpper();
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                if (_Ctrl.GetType() != typeof(CheckBox) & _Ctrl.GetType() != typeof(RadioButton))
                { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
            }
        }
        private void _Mtd_CargarSolicitante()
        {
            string _Str_Cadena = "SELECT DISTINCT UPPER(cuser) AS cuser,cnameuser+' - '+UPPER(cuser), cnameuser FROM T3TREPORTFALLAv1 ORDER BY cnameuser";
            Cursor = Cursors.WaitCursor;
            _Cls_VariosMetodos._Mtd_CargarComboWeb(_Cmb_Solicitante, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarTipoFalla()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoFalla.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Arquitectura (Sistema T3)", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Tecnología (Soporte Técnico)", "2"));
            _Cmb_TipoFalla.DataSource = _myArrayList;
            _Cmb_TipoFalla.DisplayMember = "Display";
            _Cmb_TipoFalla.ValueMember = "Value";
            _Cmb_TipoFalla.SelectedValue = "nulo";
            _Cmb_TipoFalla.DataSource = _myArrayList;
            _Cmb_TipoFalla.SelectedIndex = 0;
        }
        private void _Mtd_CargarFiltrar()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Filtrar.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Solicitudes pendientes", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Solicitudes sin asignar", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Solicitudes en pausa", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Solicitudes en RMA", "4"));
            _Cmb_Filtrar.DataSource = _myArrayList;
            _Cmb_Filtrar.DisplayMember = "Display";
            _Cmb_Filtrar.ValueMember = "Value";
            _Cmb_Filtrar.SelectedValue = "nulo";
            _Cmb_Filtrar.DataSource = _myArrayList;
            _Cmb_Filtrar.SelectedIndex = 0;
        }
        private void _Mtd_CargarArquitectos()
        {
            string _Str_Cadena = "SELECT cusuarioconssa, cname FROM T3TREPORTFALLAARQUITECTOv1";
            if (_Cmb_TipoFalla.SelectedIndex > 0)
            {
                _Str_Cadena += " WHERE (ctipofalla='" + Convert.ToString(_Cmb_TipoFalla.SelectedValue).Trim() + "' OR ctipofalla='0')";//0 para ver administradores.
            }
            _Str_Cadena += " ORDER BY cname";
            _Cls_VariosMetodos._Mtd_CargarComboWeb(_Cmb_Arquitecto, _Str_Cadena);
        }
        private void _Mtd_CargarEstado()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Estado.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Sin atender", "S"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Atendido", "A"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Resuelto", "R"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Por montar", "M"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Pausado", "P"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Cerrado", "C"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Probando", "B"));
            _Cmb_Estado.DataSource = _myArrayList;
            _Cmb_Estado.DisplayMember = "Display";
            _Cmb_Estado.ValueMember = "Value";
            _Cmb_Estado.SelectedValue = "nulo";
            _Cmb_Estado.DataSource = _myArrayList;
            _Cmb_Estado.SelectedIndex = 0;
        }
        private void _Mtd_CargarPrioridad()
        {
            if (_Cmb_TipoFalla.SelectedIndex > 0)
            {
                string _Str_Cadena = "SELECT cidprioridad,cdescripcion FROM T3TREPORTFALLAPRIORIDADv1 WHERE (ctipofalla='" + Convert.ToString(_Cmb_TipoFalla.SelectedValue).Trim() + "') ORDER BY cdescripcion";
                _Cls_VariosMetodos._Mtd_CargarComboWeb(_Cmb_Prioridad, _Str_Cadena);
            }
            else
            { _Cmb_Prioridad.DataSource = null; }
        }
        private void _Mtd_Ini(bool _P_Bol_Actualizar)
        {
            _Mtd_CargarSolicitante();
            _Mtd_CargarTipoFalla();
            _Mtd_CargarFiltrar();
            _Mtd_CargarArquitectos();
            _Mtd_CargarEstado();
            _Mtd_CargarPrioridad();
            _Chk_MostrarF.Checked = true;
            if (_P_Bol_Actualizar)
            { _Mtd_Actualizar(true); }
        }
        delegate void SetDataSetsCallback(string _P_Str_Cadena, DataGridView _P_Dg_Grid);
        private void _Mtd_CargarGrid(string _P_Str_Cadena, DataGridView _P_Dg_Grid)
        {
            if (_P_Dg_Grid.InvokeRequired)
            {
                SetDataSetsCallback _Sets = new SetDataSetsCallback(_Mtd_CargarGrid);
                this.Invoke(_Sets, new object[] { _P_Str_Cadena, _P_Dg_Grid });
            }
            else
            {
                _P_Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_P_Str_Cadena).Tables[0];
                _P_Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewRow _Dg_Row in _P_Dg_Grid.Rows)
                {
                    if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "1")
                    { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 113, 113); }
                    if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "2")
                    { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 175, 175); }
                    if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "3")
                    { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 183); }
                    if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "4")
                    { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(220, 218, 254); }
                }
            }
        }
        private void _Mtd_Actualizar(bool _Bol_Null)
        {
            string _Str_Cadena = "";
            if (_Bol_Null)
            {
                _Str_Cadena = "SELECT cticket,companydescrip,casunto,csolicitantename,CASE WHEN ctipofalla='1' THEN 'Arquitectura (Sistema T3)' ELSE 'Tecnología (Soporte Técnico)' END AS ctipofalla,carquitecto,cprioridad,cfechahorareporte,cdiastrans,cfinaprox,cfechahorpausa,cfechahoracerrado,cestadoname,cuser,cestatusconssa FROM VST_T3_REPORTFALLASv1 WHERE 0>1";
            }
            else
            {
                _Str_Cadena = "SELECT cticket,companydescrip,casunto,csolicitantename,CASE WHEN ctipofalla='1' THEN 'Arquitectura (Sistema T3)' ELSE 'Tecnología (Soporte Técnico)' END AS ctipofalla,carquitecto,cprioridad,cfechahorareporte,cdiastrans,cfinaprox,cfechahorpausa,cfechahoracerrado,cestadoname,cuser,cestatusconssa FROM VST_T3_REPORTFALLASv1 WHERE 0=0";
                //--------------------------------------
                if (_Cmb_Solicitante.SelectedIndex > 0)
                { _Str_Cadena += " AND cuser='" + Convert.ToString(_Cmb_Solicitante.SelectedValue).Trim() + "'"; }
                //--------------------------------------
                if (_Cmb_TipoFalla.SelectedIndex > 0)
                { _Str_Cadena += " AND ctipofalla='" + Convert.ToString(_Cmb_TipoFalla.SelectedValue).Trim() + "'"; }
                //--------------------------------------
                switch (Convert.ToString(_Cmb_Filtrar.SelectedValue).Trim())
                {
                    case "1"://Solicitudes pendientes
                        _Str_Cadena += " AND (cfechahoracerrado IS NULL OR cestatusconssa='M' OR cestatusconssa='B')";
                        break;
                    case "2"://Solicitudes sin asignar
                        _Str_Cadena += " AND cusuarioconssa IS NULL";
                        break;
                    case "3"://Solicitudes en pausa
                        _Str_Cadena += " AND cestatusconssa='P'";
                        break;
                    case "4"://Solicitudes en RMA
                        _Str_Cadena += " AND crma='1'";
                        break;
                    default:
                        break;
                }
                //--------------------------------------
                if (_Cmb_Arquitecto.SelectedIndex > 0)
                { _Str_Cadena += " AND carquitecto='" + Convert.ToString(_Cmb_Arquitecto.SelectedValue) + "'"; }
                //--------------------------------------
                if (_Cmb_Estado.SelectedIndex > 0)
                { _Str_Cadena += " AND cestatusconssa='" + Convert.ToString(_Cmb_Estado.SelectedValue) + "'"; }
                //--------------------------------------
                if (_Cmb_Prioridad.SelectedIndex > 0)
                { _Str_Cadena += " AND cprioridad='" + Convert.ToString(_Cmb_Prioridad.SelectedValue) + "'"; }
                //--------------------------------------
                if (!_Chk_MostrarF.Checked)
                { _Str_Cadena += " AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechahorareporte,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "'"; }
                //--------------------------------------
                if (_Txt_Ticket.Text.Trim().Length > 0)
                { _Str_Cadena += " AND cticket='" + _Txt_Ticket.Text.Trim() + "'"; }
                //--------------------------------------
                _Str_Cadena += " ORDER BY cfechahorareporte DESC";
            }
            Thread _Thr_Thread = new Thread(new ThreadStart(delegate { _Mtd_CargarGrid(_Str_Cadena, _Dg_Grid); }));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Por favor espere...");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
        }
        private void Frm_ConsultaSolicitudes_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar(false);
        }

        private void _Chk_MostrarF_CheckedChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.Enabled = !_Chk_MostrarF.Checked;
            _Dtp_Hasta.Enabled = !_Chk_MostrarF.Checked;
        }

        private void _Dg_Grid_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "1")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 113, 113); }
                if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "2")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 175, 175); }
                if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "3")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 183); }
                if (Convert.ToString(_Dg_Row.Cells["prioridad"].Value).Trim() == "4")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.FromArgb(220, 218, 254); }
            }
        }

        private void Frm_ConsultaSolicitudes_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                Frm_Solicitud _Frm = new Frm_Solicitud(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Ticket"].Value).Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
        }

        private void _Cmb_TipoFalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarArquitectos();
            _Mtd_CargarPrioridad();
        }

        private void _Cmb_Filtrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Filtrar.SelectedIndex > 0)
            {
                _Cmb_Estado.SelectedIndex = 0;
                if (Convert.ToString(_Cmb_Filtrar.SelectedValue).Trim() == "2")
                { _Cmb_Arquitecto.SelectedIndex = 0; }
            }
        }

        private void _Cmb_Arquitecto_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarArquitectos();
            Cursor = Cursors.Default;
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedIndex > 0)
            { _Cmb_Filtrar.SelectedIndex = 0; }
        }

        private void _Bt_ConsulTicket_Click(object sender, EventArgs e)
        {
            _Pnl_Ticket.Visible = true;
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Mtd_Ini(true);
        }

        private void _Bt_Filtrar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar(false);
        }

        private void _Pnl_Ticket_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Ticket.Visible)
            { _Pnl_Filtros.Enabled = false; _Dg_Grid.Enabled = false; _Txt_Ticket.Focus(); }
            else
            { _Pnl_Filtros.Enabled = true; _Dg_Grid.Enabled = true; }
        }

        private void _Bt_Consultar_T_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Ticket.Text.Trim().Length > 0)
            {
                _Mtd_Ini(false);
                _Pnl_Ticket.Visible = false;
                _Mtd_Actualizar(false);
                _Txt_Ticket.Text = "";
            }
            else
            { _Er_Error.SetError(_Txt_Ticket, "Información requerida!!!"); }
        }

        private void _Bt_Cancelar_T_Click(object sender, EventArgs e)
        {
            _Pnl_Ticket.Visible = false;
        }

        private void _Txt_Ticket_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Ticket.Text))
            { _Txt_Ticket.Text = ""; }
        }

        private void _Txt_Ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)13)
            { _Bt_Consultar_T.PerformClick(); }
        }
    }
}
