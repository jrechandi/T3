using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_HistVendedor : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_HistVendedor()
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
        private void Frm_HistVendedor_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_CargarHistorial(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "SELECT RTRIM(THISTVENZONA.c_zona) + ' - ' + LTRIM(TZONAVENTA.cname) AS Zona, RTRIM(THISTVENZONA.cgerarea) + ' - ' + LTRIM(TVENDEDOR.cname) AS Gerente, CONVERT(VARCHAR,THISTVENZONA.cfechai,103) AS [Fecha Inicial], ISNULL(CONVERT(VARCHAR,THISTVENZONA.cfechaf,103),'ACTUAL') AS [Fecha Final] " +
            "FROM THISTVENZONA INNER JOIN TVENDEDOR ON THISTVENZONA.ccompany = TVENDEDOR.ccompany AND THISTVENZONA.cgerarea = TVENDEDOR.cvendedor INNER JOIN TZONAVENTA ON THISTVENZONA.ccompany = TZONAVENTA.ccompany AND THISTVENZONA.c_zona = TZONAVENTA.c_zona " +
            "WHERE THISTVENZONA.ccompany='" + Frm_Padre._Str_Comp + "' AND THISTVENZONA.cvendedor='" + _P_Str_Vendedor + "' " +
            "ORDER BY THISTVENZONA.cidhist";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private bool _Mtd_ExistsHistorial(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "SELECT cvendedor FROM THISTVENZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_CambiarFecha(string _P_Str_Vendedor, DateTime _P_Dtm_Fecha)
        {
            string _Str_Cadena = "SELECT TOP 2 cfechaf,cidhist FROM THISTVENZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' ORDER BY cidhist DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length > 0)
            { 
                _Str_Cadena = "UPDATE THISTVENZONA SET cfechaf='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Fecha) + "',cfechaupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidhist='" + _Ds.Tables[0].Rows[0]["cidhist"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else if (_Ds.Tables[0].Rows[0]["cfechaf"].ToString().Trim().Length == 0 & _Ds.Tables[0].Rows.Count == 2)
            {
                _Str_Cadena = "UPDATE THISTVENZONA SET cfechai='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Fecha) + "',cfechaupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidhist='" + _Ds.Tables[0].Rows[0]["cidhist"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE THISTVENZONA SET cfechaf='" + _Cls_Formato._Mtd_fecha(_P_Dtm_Fecha) + "',cfechaupd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidhist='" + _Ds.Tables[0].Rows[1]["cidhist"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private bool _Mtd_VerificarEdicion(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "SELECT TOP 2 cfechaf,cidhist FROM THISTVENZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' ORDER BY cidhist DESC";
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
        private void _Mtd_ObtenerFechaInicial(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "SELECT TOP 2 cfechai,cfechaf,cidhist FROM THISTVENZONA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' ORDER BY cidhist DESC";
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
        private void _Bt_Vendedor_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Txt_Vendedor, 0, " AND c_tipo_vend='1'");
            _Frm.ShowDialog(this);
            Cursor = Cursors.Default;
            if (_Txt_Vendedor.Text.Trim().Length > 0)
            {
                _Bt_Cambiar.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_HIST_VENDEDOR") & _Mtd_ExistsHistorial(Convert.ToString(_Txt_Vendedor.Tag).Trim()) & _Mtd_VerificarEdicion(Convert.ToString(_Txt_Vendedor.Tag).Trim());
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarHistorial(Convert.ToString(_Txt_Vendedor.Tag).Trim());
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_LimpiarVendedor_Click(object sender, EventArgs e)
        {
            _Txt_Vendedor.Text = ""; _Txt_Vendedor.Tag = "";
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
                _Mtd_CambiarFecha(Convert.ToString(_Txt_Vendedor.Tag).Trim(), _Dtp_FechaFinal.Value);
                _Mtd_CargarHistorial(Convert.ToString(_Txt_Vendedor.Tag).Trim());
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
                _Mtd_ObtenerFechaInicial(Convert.ToString(_Txt_Vendedor.Tag).Trim());
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

        private void Frm_HistVendedor_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}
