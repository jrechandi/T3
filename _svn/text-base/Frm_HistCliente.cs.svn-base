using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_HistCliente : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_HistCliente()
        {
            InitializeComponent();
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

        private void Frm_HistCliente_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_CargarHistorial(string _P_Str_Cliente, string _P_Str_Zona)
        {
            string _Str_Cadena = "SELECT RTRIM(THISTCLIZONA.c_zona) + ' - ' + LTRIM(TZONAVENTA.cname) AS Zona, CASE WHEN THISTCLIZONA.cinsidencia='0' THEN 'SEMANAL' WHEN THISTCLIZONA.cinsidencia='1' THEN 'QUINCENAL' ELSE 'MENSUAL' END AS Insidencia, CONVERT(VARCHAR,THISTCLIZONA.cfechai,103) AS [Fecha Inicial], ISNULL(CONVERT(VARCHAR,THISTCLIZONA.cfechaf,103),'ACTUAL') AS [Fecha Final] " +
            "FROM THISTCLIZONA INNER JOIN TZONAVENTA ON THISTCLIZONA.ccompany = TZONAVENTA.ccompany AND THISTCLIZONA.c_zona = TZONAVENTA.c_zona " +
            "WHERE THISTCLIZONA.ccompany='" + Frm_Padre._Str_Comp + "' AND THISTCLIZONA.ccliente='" + _P_Str_Cliente + "' AND THISTCLIZONA.c_zona='" + _P_Str_Zona + "' " +
            "ORDER BY THISTCLIZONA.cidhist";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private bool _Mtd_ExistsHistorial(string _P_Str_Cliente, string _P_Str_Zona)
        {
            string _Str_Cadena = "SELECT ccliente FROM THISTCLIZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND c_zona='" + _P_Str_Zona + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_CambiarFecha(string _P_Str_Cliente, string _P_Str_Zona, DateTime _P_Dtm_Fecha)
        {
            string _Str_Cadena = "SELECT TOP 2 cfechaf,cidhist FROM THISTCLIZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND c_zona='" + _P_Str_Zona + "' ORDER BY cidhist DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length > 0)
            {
                _Str_Cadena = "UPDATE THISTCLIZONA SET cfechaf='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Fecha) + "',cfechaupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidhist='" + _Ds.Tables[0].Rows[0]["cidhist"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length == 0 & _Ds.Tables[0].Rows.Count == 2)
            {
                _Str_Cadena = "UPDATE THISTCLIZONA SET cfechai='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Fecha) + "',cfechaupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidhist='" + _Ds.Tables[0].Rows[0]["cidhist"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE THISTCLIZONA SET cfechaf='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Fecha) + "',cfechaupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidhist='" + _Ds.Tables[0].Rows[1]["cidhist"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private bool _Mtd_VerificarEdicion(string _P_Str_Cliente,string _P_Str_Zona)
        {
            string _Str_Cadena = "SELECT TOP 2 cfechaf,cidhist FROM THISTCLIZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND c_zona='" + _P_Str_Zona + "' ORDER BY cidhist DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length == 0 & _Ds.Tables[0].Rows.Count == 1)
                {
                    return false;
                }
            }
            else
            { return false; }
            return true;
        }
        private void _Mtd_ObtenerFechaInicial(string _P_Str_Cliente, string _P_Str_Zona)
        {
            string _Str_Cadena = "SELECT TOP 1 cfechai,cfechaf FROM THISTCLIZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND c_zona='" + _P_Str_Zona + "' ORDER BY cidhist DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length > 0)
            {
                _Dtp_FechaFinal.MinDate = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechai"].ToString().Trim());
                _Dtp_FechaFinal.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim());
            }
            else if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length == 0 & _Ds.Tables[0].Rows.Count == 2)
            {
                _Dtp_FechaFinal.MinDate = Convert.ToDateTime(_Ds.Tables[0].Rows[1]["cfechai"].ToString().Trim());
                _Dtp_FechaFinal.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechai"].ToString().Trim());
            }
        }
        private void _Bt_Cliente_Click(object sender, EventArgs e)
        {
            string _Str_ClienteTemp = Convert.ToString(_Txt_Cliente.Tag).Trim();
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            _Frm.ShowDialog(this);
            Cursor = Cursors.Default;
            if (Convert.ToString(_Txt_Cliente.Tag).Trim() != _Str_ClienteTemp)
            {
                _Txt_Zona.Text = ""; _Txt_Zona.Tag = ""; _Bt_Zona.Enabled = true; _Bt_LimpiarZona.Enabled = true;
                _Dg_Grid.DataSource = null;
                _Bt_Cambiar.Enabled = false;
            }
        }
        private void _Bt_LimpiarCliente_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
            _Txt_Zona.Text = ""; _Txt_Zona.Tag = ""; _Bt_Zona.Enabled = false; _Bt_LimpiarZona.Enabled = false;
            _Dg_Grid.DataSource = null;
            _Bt_Cambiar.Enabled = false;
        }

        private void _Bt_Zona_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(79, _Txt_Zona, 0, " AND EXISTS(SELECT c_zona FROM TZONACLIENTE WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Txt_Cliente.Tag).Trim() + "' AND TZONACLIENTE.c_zona=TZONAVENTA.c_zona)");
            _Frm.ShowDialog(this);
            Cursor = Cursors.Default;
            if (_Txt_Zona.Text.Trim().Length > 0)
            {
                _Bt_Cambiar.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_HIST_CLIENTE") & _Mtd_ExistsHistorial(Convert.ToString(_Txt_Cliente.Tag).Trim(), Convert.ToString(_Txt_Zona.Tag).Trim()) & _Mtd_VerificarEdicion(Convert.ToString(_Txt_Cliente.Tag).Trim(), Convert.ToString(_Txt_Zona.Tag).Trim());
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarHistorial(Convert.ToString(_Txt_Cliente.Tag).Trim(), Convert.ToString(_Txt_Zona.Tag).Trim());
                Cursor = Cursors.Default;
            }
        }
        private void _Bt_LimpiarZona_Click(object sender, EventArgs e)
        {
            _Txt_Zona.Text = ""; _Txt_Zona.Tag = "";
            _Dg_Grid.DataSource = null;
            _Bt_Cambiar.Enabled = false;
        }
        private void _Bt_Cambiar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Mtd_CambiarFecha(Convert.ToString(_Txt_Cliente.Tag).Trim(), Convert.ToString(_Txt_Zona.Tag).Trim(), _Dtp_FechaFinal.Value);
                _Mtd_CargarHistorial(Convert.ToString(_Txt_Cliente.Tag).Trim(), Convert.ToString(_Txt_Zona.Tag).Trim());
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Pnl_Superior.Enabled = false;
                _Pnl_Inferior.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Txt_Clave.Text = "";
                _Mtd_ObtenerFechaInicial(Convert.ToString(_Txt_Cliente.Tag).Trim(), Convert.ToString(_Txt_Zona.Tag).Trim());
                _Dtp_FechaFinal.Focus();
            }
            else
            {
                _Pnl_Superior.Enabled = true;
                _Pnl_Inferior.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void Frm_HistCliente_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}
