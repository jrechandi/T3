using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace T3
{
    public partial class Frm_Solicitud : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Solicitud()
        {
            InitializeComponent();
        }
        string _G_Str_Ticket = "";
        public Frm_Solicitud(string _P_Str_Ticket)
        {
            InitializeComponent();
            _G_Str_Ticket = _P_Str_Ticket;
            _Mtd_CargarTransferencias(_G_Str_Ticket);
            _Mtd_Ini();
            _Mtd_Igualar(_P_Str_Ticket);
            string _Str_UserSolicitante = _Mtd_ObtenerSolicitante(_P_Str_Ticket);
            if (_Str_UserSolicitante.Trim().Length > 0)
            { _Cmb_Solicitante.SelectedValue = _Str_UserSolicitante.ToUpper(); }
            _Bt_Activar.Enabled = _Mtd_ExistenActivaciones(_P_Str_Ticket);
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
        private bool _Mtd_ExistenActivaciones(string _P_Str_Ticket)
        {
            string _Str_Cadena = "select cidfalla from T3TREPORTFALLAACTIVARv1 where cidfalla='" + _P_Str_Ticket + "'";
            return Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_ObtenerSolicitante(string _P_Str_Ticket)
        {
            string _Str_Cadena = "SELECT cuser FROM T3TREPORTFALLAv1 WHERE cidfalla='" + _P_Str_Ticket + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_CargarSolicitante()
        {
            string _Str_Cadena = "SELECT DISTINCT UPPER(cuser) AS cuser,cnameuser FROM T3TREPORTFALLAv1 WHERE cidfalla='" + _G_Str_Ticket + "'";
            _Str_Cadena += " UNION SELECT cusuarioconssa,cname FROM T3TREPORTFALLAARQUITECTOv1";
            _Cls_VariosMetodos._Mtd_CargarComboWeb(_Cmb_Solicitante, _Str_Cadena);
        }
        private void _Mtd_CargarArquitectos()
        {
            _Cls_VariosMetodos._Mtd_CargarComboWeb(_Cmb_Arquitecto, "SELECT cusuarioconssa, cname FROM T3TREPORTFALLAARQUITECTOv1");
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
                string _Str_Cadena = "SELECT cidprioridad,CONVERT(VARCHAR,cidprioridad)+ ' - ' +cdescripcion FROM T3TREPORTFALLAPRIORIDADv1 WHERE (ctipofalla='" + Convert.ToString(_Cmb_TipoFalla.SelectedValue).Trim() + "') ORDER BY cdescripcion";
                _Cls_VariosMetodos._Mtd_CargarComboWeb(_Cmb_Prioridad, _Str_Cadena);
            }
            else
            { _Cmb_Prioridad.DataSource = null; }
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
        private void _Mtd_Ini()
        {
            _Mtd_CargarSolicitante();
            _Mtd_CargarArquitectos();
            _Mtd_CargarEstado();
            _Mtd_CargarPrioridad();
            _Mtd_CargarTipoFalla();
            _Txt_Asunto.Text = "";
            _Txt_DetalleFalla.Text = "";
            _Dtp_FechaHora.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
        }
        byte[] _G_Byt;
        public Image _Mtd_ConvertirByteparaImage(byte[] _by_p_)
        {
            byte[] _by_imageBuffer = _by_p_;
            System.IO.MemoryStream _ms = new System.IO.MemoryStream(_by_imageBuffer);
            Image _img_h = Image.FromStream(_ms);
            return _img_h;
        }
        private string _Mtd_FinAprox(string _P_Str_Ticket)
        {
            string _Str_Cadena = "SELECT cfinaprox FROM VST_T3_REPORTFALLASv1 WHERE cticket='" + _P_Str_Ticket + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_Igualar(string _P_Str_Ticket)
        {
            string _Str_Cadena = "SELECT cgroupcomp,UPPER(cuser) AS cuser,cfechahorareporte,ctipofalla,ctitulofalla,cusuarioconssa,cdescripcionusuario,cprioridadconssa,cexplicacionconssa,cestatusconssa,cfechahoraabierto,cfechahorpausa,cmotivopausa,cmotivocerrado FROM T3TREPORTFALLAv1 WHERE cidfalla='" + _P_Str_Ticket + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Cmb_Solicitante.SelectedValue = _Ds.Tables[0].Rows[0]["cuser"].ToString().Trim();
                _Dtp_FechaHora.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechahorareporte"]);
                _Cmb_TipoFalla.SelectedValue = _Ds.Tables[0].Rows[0]["ctipofalla"].ToString().Trim();
                _Txt_Asunto.Text = _Ds.Tables[0].Rows[0]["ctitulofalla"].ToString().Trim();
                _Txt_DetalleFalla.Text = _Ds.Tables[0].Rows[0]["cdescripcionusuario"].ToString().Trim();
                _Cmb_Arquitecto.SelectedValue = _Ds.Tables[0].Rows[0]["cusuarioconssa"].ToString().Trim();
                _Cmb_Estado.SelectedValue = _Ds.Tables[0].Rows[0]["cestatusconssa"].ToString().Trim();
                _Cmb_Prioridad.SelectedValue = _Ds.Tables[0].Rows[0]["cprioridadconssa"].ToString().Trim();
                _Txt_FechaHoraAtendido.Text = _Ds.Tables[0].Rows[0]["cfechahoraabierto"].ToString().Trim();
                _Txt_FinAprox.Text = _Mtd_FinAprox(_P_Str_Ticket);
                _Txt_FechaHoraPausa.Text = _Ds.Tables[0].Rows[0]["cfechahorpausa"].ToString().Trim();
                _Txt_MotivoPausa.Text = _Ds.Tables[0].Rows[0]["cmotivopausa"].ToString().Trim();
                if (_Ds.Tables[0].Rows[0]["cestatusconssa"].ToString().Trim() == "C")
                { _Txt_Nota.Text = _Ds.Tables[0].Rows[0]["cmotivocerrado"].ToString().Trim(); }
                else if (_Ds.Tables[0].Rows[0]["cestatusconssa"].ToString().Trim() == "R" | _Ds.Tables[0].Rows[0]["cestatusconssa"].ToString().Trim() == "M" | _Ds.Tables[0].Rows[0]["cestatusconssa"].ToString().Trim() == "B")
                { _Txt_Nota.Text = _Ds.Tables[0].Rows[0]["cexplicacionconssa"].ToString().Trim(); }
            }
        }
        private void _Mtd_CargarImagen(string _P_Str_Ticket)
        {
            string _Str_Cadena = "SELECT cimagen FROM T3TREPORTFALLAv1 WHERE cidfalla='" + _P_Str_Ticket + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                try
                { _G_Byt = ((byte[])_Ds.Tables[0].Rows[0]["cimagen"]); }
                catch { }
            }
        }

        private void _Mtd_CargarTransferencias(string _P_Str_Ticket)
        {
            string _Str_Cadena = "SELECT cuserde,cuserpara,cfechahortransferencia FROM T3TREPORTFALLATRASNFERENCIAv1 WHERE cidfalla='" + _P_Str_Ticket + "' ORDER BY cidtransferencia";
            _Dg_Tranf.DataSource = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Tranf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        
        private void Frm_Solicitud_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void _Bt_VerCapPantalla_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarImagen(_G_Str_Ticket);
            Cursor = Cursors.Default;
            if (_G_Byt != null)
            {
                Frm_Imagen _Frm = new Frm_Imagen(_Mtd_ConvertirByteparaImage(_G_Byt));
                _Frm.ShowDialog();
            }
            else
            { MessageBox.Show("No se ha cargado ninguna imágen", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_Estado.SelectedValue).Trim() == "C")
            { _Tbp_1.Text = "Motivo"; }
            else if (Convert.ToString(_Cmb_Estado.SelectedValue).Trim() == "R" | Convert.ToString(_Cmb_Estado.SelectedValue).Trim() == "M" | Convert.ToString(_Cmb_Estado.SelectedValue).Trim() == "B")
            { _Tbp_1.Text = "Solución"; }
            else
            { _Tbp_1.Text = "Nota"; }
        }

        private void Frm_Solicitud_Shown(object sender, EventArgs e)
        {
            _Bt_Salir.Focus();
        }

        private void _Cmb_TipoFalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarPrioridad();
        }

        private void _Bt_Activar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Activar _Frm = new Frm_Activar(_G_Str_Ticket);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }
    }
}
