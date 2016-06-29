using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_PrecargaSinTransp : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_PrecargaSinTransp()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar();
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
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Pre-Carga");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cprecarga";
            string _Str_Cadena = "SELECT CONVERT(VARCHAR, cfechaprecarga,103) AS Fecha,cprecarga AS [Pre-Carga],ctotalempaq AS Cajas,ctotalunidad AS Unidades,CAST(ctotalkg AS NUMERIC) AS Kg,'   ' AS [Ruta Desp.],'TIPO '+CASE WHEN TPRECARGAM.ctipoalimento='0' THEN 'OTROS' WHEN TPRECARGAM.ctipoalimento='1' THEN 'ALIMENTOS' ELSE 'MIXTA' END +' PARA '+ CASE WHEN CTIPOCLIENTE = '0' THEN 'CLIENTES REGULARES' WHEN CTIPOCLIENTE IS NULL THEN 'PRECARGA REGULAR' ELSE TTESTABLECIM.CNAME END AS [Tipo Precarga] FROM TPRECARGAM LEFT OUTER JOIN TTESTABLECIM ON TPRECARGAM.ctipocliente = TTESTABLECIM.ctestablecim WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND (cimprimeprecarga='1' and cverificascanpalm='1' and cimprimefactura='0' and cimprimeguiadesp='0' AND cplaca='0' AND ccedula='0')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "PRE-CARGAS", _Tsm_Menu, _Dg_Grid, true, "", "cprecarga,cfechaprecarga DESC");
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_MostrarReporte(string _P_Str_PreCarga)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT * FROM VST_PRECARGALISTADO_2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            Report.rPreCargaListado _My_Reporte = new T3.Report.rPreCargaListado();
            _My_Reporte.SetDataSource(_Ds.Tables[0]);
            Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname),crif FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
            tex1.Text = _Ds.Tables[0].Rows[0][0].ToString();
            TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
            tex2.Text = _Ds.Tables[0].Rows[0][1].ToString();
            //----------------------------
            if (_Mtd_RequiereGuiaSada(_P_Str_PreCarga))
            {
                _sec = _My_Reporte.ReportDefinition.Sections["Section3"];
                TextObject _Txt_RequiereGuiaSada = _sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
            }
            //----------------------------
            _Rpv_Main.ReportSource = _My_Reporte;
            _Rpv_Main.RefreshReport();
            Cursor = Cursors.Default;
        }
        private string _Mtd_verificarTransportista(string _P_Str_Cedula)
        {
            string _Str_Cadena = "select cdc_fec_liccondu,cdc_fec_certsalud,cdc_fec_permsanit,cdc_fec_rcv,cpropietario from TTRANSPORTISTA where cplaca='" + _Txt_Placa.Text + "' and ccedula='" + _P_Str_Cedula + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_Cadena = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cdc_fec_liccondu"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_liccondu"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " la licencia para conducir,"; }
                }
                if (_Ds.Tables[0].Rows[0]["cdc_fec_certsalud"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_certsalud"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " el certificado de Salud,"; }
                }
                if (_Ds.Tables[0].Rows[0]["cdc_fec_permsanit"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_permsanit"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " el permiso sanitario,"; }
                }
                if (_Ds.Tables[0].Rows[0]["cdc_fec_rcv"] != System.DBNull.Value)
                {
                    if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_rcv"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                    { _Str_Cadena = _Str_Cadena + " el permiso sanitario,"; }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cpropietario"]) == "1")
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cdc_fec_rcv"]) != "")
                    {
                        if ((Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdc_fec_rcv"].ToString())) <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())
                        { _Str_Cadena = _Str_Cadena + " la fecha de vencimiento de responsabilidad civil."; }
                    }
                }
            }
            return _Str_Cadena;
        }
        private void _Mtd_Asignar(string _P_Str_PreCarga,string _P_Str_Placa,string _P_Str_Cedula)
        {
            string _Str_Cadena = "UPDATE TPRECARGAM SET cplaca='" + _P_Str_Placa + "',ccedula='" + _P_Str_Cedula + "',cfechaasigtransp='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _P_Str_PreCarga + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }
        private void _Mtd_Ini()
        {
            _Txt_Precarga.Text = "";
            _Bt_Transportista.Enabled = false;
            _Txt_Placa.Text = "";
            _Txt_Transportista.Text = "";
            _Txt_Transportista.Tag = "";
            _Txt_Cajas.Text = "";
            _Txt_Bs.Text = "";
        }
        private void _Mtd_CargarRutas(string _P_Str_Precarga)
        {
            string _Str_Cadena = "SELECT TPRECARGADR.cidrutdespacho AS Ruta, TRUTDESPACHOM.cdescripcion AS Descripción FROM TPRECARGADR INNER JOIN TRUTDESPACHOM ON TPRECARGADR.cgroupcomp = TRUTDESPACHOM.cgroupcomp AND TPRECARGADR.cidrutdespacho = TRUTDESPACHOM.cidrutdespacho WHERE (TPRECARGADR.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGADR.cprecarga = '" + _P_Str_Precarga + "')";
            _Dg_Rutas.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Rutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_MostrarTotales(string _P_Str_Precarga)
        {
            string _Str_Cadena = "SELECT SUM(ISNULL(TPRECARGADPF.ctotalempaq,0)) AS Cajas, dbo.Fnc_Formatear(SUM(ISNULL(TPREFACTURAM.c_montotot_si,0))) AS Monto FROM TPRECARGADPF INNER JOIN TPREFACTURAM ON TPRECARGADPF.cpfactura = TPREFACTURAM.cpfactura WHERE TPRECARGADPF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPRECARGADPF.cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cajas.Text = _Ds.Tables[0].Rows[0]["Cajas"].ToString().Trim();
                _Txt_Bs.Text = _Ds.Tables[0].Rows[0]["Monto"].ToString().Trim();
            }
        }
        private void Frm_PrecargaSinTransp_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Rutas.Left = (this.Width / 2) - (_Pnl_Rutas.Width / 2);
            _Pnl_Rutas.Top = (this.Height / 2) - (_Pnl_Rutas.Height / 2);
            if (!_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_PREC_SIN_TRANS"))
            {
                _Bt_Transporte.Enabled = false;
                _Bt_Asignar.Enabled = false;
            }
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

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Er_Error.Dispose();
                if (_Txt_Placa.Text.Trim().Length > 0 & _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex).Trim() != _Txt_Placa.Text.Trim())
                {
                    string _Str_Cadena = "UPDATE TTRANSPORTE SET cesperando='1' WHERE cplaca='" + _Txt_Placa.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                }
                _Lbl_TipoPrecarga.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex);
                _Mtd_Ini();
                _Txt_Precarga.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Mtd_MostrarReporte(_Txt_Precarga.Text);
                _Mtd_MostrarTotales(_Txt_Precarga.Text);
                _Tb_Tab.SelectTab(1);
            }
        }

        private void _Bt_Transporte_Click(object sender, EventArgs e)
        {
            string _Str_Parametro = "";
            string _Str_Cadena = "";
            TextBox _Txt_Temp = new TextBox();
            if (_Txt_Placa.Text.Trim().Length > 0)
            {
                _Str_Parametro = " AND cplaca<>'" + _Txt_Placa.Text.Trim() + "'";
                _Str_Cadena = "UPDATE TTRANSPORTE SET cesperando='1' WHERE cplaca='" + _Txt_Placa.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(13, _Txt_Placa, _Txt_Temp, 0, 0, _Str_Parametro);
            _Frm.ShowDialog(this);
            if (_Txt_Temp.Text.Trim().Length > 0)
            {
                _Txt_Transportista.Tag = "";
                _Txt_Transportista.Text = "";
                _Str_Cadena = "UPDATE TTRANSPORTE SET cesperando='0' WHERE cplaca='" + _Txt_Placa.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Str_Cadena = "SELECT ccedula,cnombre FROM TTRANSPORTISTA WHERE cplaca='" + _Txt_Placa.Text.Trim() + "' AND cactivate='1' AND cdelete='0'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Bt_Transportista.Enabled = true;
                    _Txt_Transportista.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccedula"]);
                    _Txt_Transportista.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnombre"]);
                    _Str_Cadena = _Mtd_verificarTransportista(Convert.ToString(_Txt_Transportista.Tag));
                    if (_Str_Cadena.Trim().Length > 0)
                    {
                        MessageBox.Show("Se ha vencido: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transportista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    _Bt_Transportista.Enabled = true;
                }
            }
        }

        private void _Bt_Transportista_Click(object sender, EventArgs e)
        {
            if (_Txt_Placa.Text.Trim().Length > 0)
            {
                TextBox _Txt_TemporalCod=new TextBox();
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(14, _Txt_TemporalCod, _Txt_Transportista, 0, 1, "");
                _Frm.ShowDialog(this);
                if (_Txt_TemporalCod.Text.Trim().Length > 0)
                {
                    _Txt_Transportista.Tag = _Txt_TemporalCod.Text.Trim();
                    string _Str_Cadena = _Mtd_verificarTransportista(_Txt_TemporalCod.Text.Trim());
                    if (_Str_Cadena.Trim().Length > 0)
                    {
                        MessageBox.Show("Se ha vencido: " + _Str_Cadena.Substring(0, _Str_Cadena.Length - 1) + " del Transportista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe elegir un transporte para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Precarga.Text.Trim().Length == 0 & e.TabPageIndex == 1)
            { e.Cancel = true; }
        }

        private void Frm_PrecargaSinTransp_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_AprobarCliente_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Placa.Text.Trim().Length > 0 & _Txt_Transportista.Text.Trim().Length > 0)
            {
                _Pnl_Clave.Visible = true;
            }
            else
            {
                if (_Txt_Placa.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Transporte, "Información requerida!!!"); }
                if (_Txt_Transportista.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Transportista, "Información requerida!!!"); }
            }
        }

        private void Frm_PrecargaSinTransp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Txt_Placa.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "UPDATE TTRANSPORTE SET cesperando='1' WHERE cplaca='" + _Txt_Placa.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                //string _Str_Cadena = "UPDATE TTRANSPORTISTA SET cplaca='" + _Txt_Placa.Text.Trim() + "' WHERE ccedula='" + Convert.ToString(_Txt_Transportista.Tag) + "' AND ISNULL(cdelete,0)=0";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Asignar(_Txt_Precarga.Text.Trim(), _Txt_Placa.Text.Trim(), Convert.ToString(_Txt_Transportista.Tag));
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Pnl_Clave.Visible = false;
                _Mtd_Actualizar();
                _Tb_Tab.SelectTab(0);
                _Mtd_Ini();
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                if (_Dg_Grid.Rows.Count == 0)
                { this.Close(); }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Pnl_Rutas_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Rutas.Visible)
            { _Tb_Tab.Enabled = false; }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_Aceptar_Rut_Click(object sender, EventArgs e)
        {
            _Pnl_Rutas.Visible = false;
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 5)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_CargarRutas(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex));
                        Cursor = Cursors.Default;
                        _Lbl_Ruta.Text = "Rutas de Despacho de la Pre-Carga número:" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                        _Pnl_Rutas.Visible = true;
                    }
                }
            }
        }

        private bool _Mtd_RequiereGuiaSada(string _P_Str_Precarga)
        {
            var _Bol_RequiereGuiaSada = false;
            string _Str_Cadena = "SELECT DISTINCT TPREFACTURAM.ccompany " +
                        "FROM TPRECARGAM INNER JOIN " +
                        "TPRECARGADPF ON TPRECARGAM.cgroupcomp = TPRECARGADPF.cgroupcomp AND " +
                        "TPRECARGAM.cprecarga = TPRECARGADPF.cprecarga INNER JOIN " +
                        "TPREFACTURAM ON dbo.TPRECARGADPF.cpfactura = TPREFACTURAM.cpfactura " +
                        "WHERE TPRECARGAM.cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Ds_Comp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Comp.Tables[0].Rows)
            {
                double _Dbl_Toneladas = 0;
                _Str_Cadena = "SELECT ISNULL(SUM(CONVERT(NUMERIC(18,3),CONVERT(NUMERIC(18,2),CONVERT(NUMERIC(18,2),(TPREFACTURAD.cempaques*(TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))+TPREFACTURAD.cunidades)*CONVERT(NUMERIC(18,2),cpesounid1))/1000000)),0) AS Toneladas " +
                      "FROM TPREFACTURAM INNER JOIN " +
                      "TPREFACTURAD ON TPREFACTURAM.ccompany = TPREFACTURAD.ccompany AND " +
                      "TPREFACTURAM.cpfactura = TPREFACTURAD.cpfactura INNER JOIN " +
                      "TPRECARGADPF ON TPREFACTURAM.cpfactura = TPRECARGADPF.cpfactura INNER JOIN " +
                      "TPRODUCTO ON TPRODUCTO.cproducto = TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSD ON TSICARUBROSD.cproducto=TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSM ON TSICARUBROSD.ccodigorubro=TSICARUBROSM.ccodigorubro AND " +
                      "TSICARUBROSD.cdelete=TSICARUBROSM.cdelete " +
                      "WHERE (TPRECARGADPF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGADPF.cprecarga='" + _P_Str_Precarga + "') AND (TPREFACTURAM.ccompany='" + _Row[0].ToString() + "') AND (TSICARUBROSM.cdelete=0)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Dbl_Toneladas = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
                if (_Dbl_Toneladas > 0)
                {
                    _Bol_RequiereGuiaSada = true;
                }
            }
            return _Bol_RequiereGuiaSada;
        }
    }
}
