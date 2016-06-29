using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Timers;
using System.Security.Cryptography;
using System.Linq;
namespace T3
{
    public partial class Frm_ConteoCompleto : Form
    {
        Frm_BusquedaAvanzada _Frm_Busq;
        private delegate void ChangeProgressBarCallback();
        private delegate void TimerDelegate(object sender, ElapsedEventArgs e);
        private System.Timers.Timer ticker;
        clslibraryconssa._Cls_Formato _G_Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ConteoCompleto()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 200;
            ticker = new System.Timers.Timer();
            ticker.Elapsed += new ElapsedEventHandler(ticker_Elapsed);
            _Frm_Busq = new Frm_BusquedaAvanzada(this);
            string _Str_Cadena = "Select ciniciado from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                { MessageBox.Show("Se ha iniciado el conteo de inventario físico. No podra realizar operaciones en este módulo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Pnl_Panel_1.Enabled = false; _Pnl_Panel_2.Enabled = false; }
                else
                {
                    _Mtd_Actualizar();
                    _Str_Cadena = "Select * from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Bt_Nuevas.Enabled = false;
                        _Grb_1.Enabled = true;
                        _Bt_Generar.Enabled = false;
                        _Str_Cadena = "Select cimpreso,cimpvertaremit,ciniciado from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows[0]["cimpreso"].ToString().Trim() == "1" & _Ds.Tables[0].Rows[0]["cimpvertaremit"].ToString().Trim() == "1")
                        {
                            _Bt_Imprimir.Enabled = false;
                            _Bt_AbrirConteo.Visible = _Ds.Tables[0].Rows[0]["ciniciado"].ToString().Trim() != "1";
                        }
                        else
                        { _Bt_Imprimir.Enabled = true; }
                        _Dg_Grid.Columns["Seleccionar"].Visible = false;
                    }
                    else
                    {
                        _Bt_Nuevas.Enabled = false;
                        _Bt_Generar.Enabled = true;
                        _Grb_1.Enabled = true;
                        _Dg_Grid.Columns["Seleccionar"].Visible = true;
                    }
                }

            }
            else
            {
                _Bt_Nuevas.Enabled = true;
                _Bt_Generar.Enabled = false;
                _Grb_1.Enabled = false;
                _Grb_2.Enabled = false;
            }
        }

        void ticker_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new TimerDelegate(ticker_Elapsed), sender, e);
            }
            else
            {
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = 0;
                }
                else
                {
                    progressBar1.Value += 10;
                }
            }
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
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT id_conteo FROM TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY id_conteo  DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select DISTINCT id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc as cnamef,cpresentacion,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax,'0' as Seleccionar from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' order by id_tarjetainv";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Dg_Grid.Columns["Seleccionar"].Visible = false;
                _Mtd_Actualizar_Productos("");
            }
            else
            {
                _Dg_Grid.Columns["Seleccionar"].Visible = false;
                _Dg_Grid.DataSource = _Ds.Tables[0];
                _Txt_Tarjetas.Text = _Ds.Tables[0].Rows.Count.ToString();
                _Txt_Fecha.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cdate from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cimpreso from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString() == "1")
                { _Txt_Impresas.Text = "Sí"; }
                else
                { _Txt_Impresas.Text = "No"; }
                _Grb_2.Enabled = false;
            }
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        string _Str_Where = "";
        private DataSet _Mtd_Crear_Dataset(string _P_Str_Cadena)
        {
            _Str_Where = "";
            string _Str_Cadena = "Select DISTINCT '' as id_tarjetainv, c_nomb_abreviado,TPRODUCTO.cproducto,cnamefc as cnamef,cpresentacion,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,TPRODUCTOD.cidproductod,dbo.Fnc_Formatear(TPRODUCTOD.cprecioventamax) AS cprecioventamax,'1' as Seleccionar FROM TPRODUCTO INNER JOIN TPROVEEDOR ON TPRODUCTO.cproveedor=TPROVEEDOR.cproveedor INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor=TGRUPPROVEE.cproveedor INNER JOIN TPRODUCTOD ON TPRODUCTO.cproducto = TPRODUCTOD.cproducto WHERE (TPRODUCTOD.CEXISREALU1<>0 OR TPRODUCTOD.CEXISREALU2<>0) AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT cproducto FROM TFILTROREGIONALP WHERE TFILTROREGIONALP.cproducto=TPRODUCTO.cproducto and TFILTROREGIONALP.cdelete='0') AND EXISTS(SELECT * FROM TPRODUCTO AS T " + _P_Str_Cadena + " AND T.cproducto=TPRODUCTO.cproducto)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_Cadena = "Select DISTINCT '' as id_tarjetainv, c_nomb_abreviado,TPRODUCTO.cproducto,cnamefc as cnamef,cpresentacion,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,TPRODUCTOD.cidproductod,dbo.Fnc_Formatear(TPRODUCTOD.cprecioventamax) AS cprecioventamax,'1' as Seleccionar FROM TPRODUCTO INNER JOIN TPROVEEDOR ON TPRODUCTO.cproveedor=TPROVEEDOR.cproveedor INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor=TGRUPPROVEE.cproveedor INNER JOIN TPRODUCTOD ON TPRODUCTO.cproducto = TPRODUCTOD.cproducto WHERE (TPRODUCTOD.CEXISREALU1<>0 OR TPRODUCTOD.CEXISREALU2<>0) AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT cproducto FROM TFILTROREGIONALP WHERE TFILTROREGIONALP.cproducto=TPRODUCTO.cproducto and TFILTROREGIONALP.cdelete='0') AND NOT EXISTS(SELECT * FROM TPRODUCTO AS T " + _P_Str_Cadena + " AND T.cproducto=TPRODUCTO.cproducto)";
            DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
            {
                int _Int_Index = Array.IndexOf(_Str_Array, _Dtw_Item[2].ToString().TrimEnd());
                if (_Int_Index == -1)
                {
                    _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, _Str_Array.Length + 1);
                    _Str_Array[_Str_Array.Length - 1] = _Dtw_Item[2].ToString().TrimEnd();
                }
            }
            foreach (DataRow _Row in _Ds2.Tables[0].Rows)
            {
                string _Str_Marcado = "0";
                int _Int_Index = Array.IndexOf(_Str_Array, _Row[2].ToString().TrimEnd());
                if (_Int_Index != -1)
                {
                    _Str_Marcado = "1";
                }
                _Ds.Tables[0].Rows.Add(new object[] { _Row[0], _Row[1], _Row[2], _Row[3], _Row[4], _Row[5], _Row[6], _Row[7], _Str_Marcado });
            }
            _Str_Where = _P_Str_Cadena;
            return _Ds;
        }
        private void _Mtd_Actualizar_Productos(string _P_Str_Cadena)
        {
            Cursor = Cursors.WaitCursor;
            if (_P_Str_Cadena.Trim().Length == 0)
            {
                _P_Str_Cadena = "Where 3>5 ";
                DataSet _Ds = _Mtd_Crear_Dataset(_P_Str_Cadena);
                DataView _Dta_View = new DataView(_Ds.Tables[0]);
                _Dta_View.Sort = "Seleccionar desc";
                DataSet _Ds_New = new DataSet();
                _Ds_New.Tables.Add(_Dta_View.Table.Copy());
                _Dg_Grid.DataSource = _Ds_New.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                DataSet _Ds = _Mtd_Crear_Dataset(_P_Str_Cadena);
                DataView _Dta_View = new DataView(_Ds.Tables[0]);
                _Dta_View.Sort = "Seleccionar desc";                
                DataSet _Ds_New = new DataSet();
                _Ds_New.Tables.Add(_Dta_View.Table.Copy());
                DataRow[] _Dta_Rows= _Ds_New.Tables[0].Select("cproducto<>''", "Seleccionar desc");
                _Ds_New.Tables[0].Rows.Clear();
                foreach (DataRow _Dtw_Row in _Dta_Rows)
                {
                    _Ds_New.Tables[0].Rows.Add(_Dtw_Row);
                }
                _Dg_Grid.DataSource = _Dta_View;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            Cursor = Cursors.Default;
        }
        string _Str_Sql = "";
        public void _Mtd_Actualizar_Avanzado(string _P_Str_Cadena)
        {
            _Str_Sql = _P_Str_Cadena;
        }
        private void _Mtd_Conteo_Sql()
        {
            Cursor = Cursors.WaitCursor;
            label13.Visible = true;
            _Prb_Progreso.Maximum = _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Seleccionar"].Value) == "1").Count();
            string _Str_Cadena = "";
            _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Seleccionar"].Value) == "1").ToList().ForEach(Fila => 
            {
                _Str_Cadena = "Insert into TINVFISICOD (id_conteo,id_tarjetainv,cproveedor,cgrupo,csku,csubgrupo,cproducto,cdate,cyearacco,cmontacco,ccompany,cimpr_u2,cidproductod) SELECT DISTINCT '1',(SELECT ISNULL(MAX(id_tarjetainv),0)+1 FROM TINVFISICOD WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'),cproveedor,cgrupo,csku,csubgrupo,TPRODUCTO.cproducto,'" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'," + Clases._Cls_ProcesosCont._Mtd_ContableAno(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "," + Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + ",'" + Frm_Padre._Str_Comp + "',cunidad2,cidproductod FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTO.cproducto = TPRODUCTOD.cproducto WHERE TPRODUCTO.cproducto='" + Convert.ToString(Fila.Cells["cproducto"].Value).Trim() + "' AND cidproductod='" + Convert.ToString(Fila.Cells["cidproductod"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Prb_Progreso.Value++;
            }
            );
            Cursor = Cursors.Default;
            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_Actualizar();
            _Bt_Nuevas.Enabled = false;
            _Bt_Generar.Enabled = true;
            _Grb_1.Enabled = true;
            _Bt_Imprimir.Enabled = true;
            _Bt_Generar.Enabled = false;
            _Bt_Filtrar.Enabled = false;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Mtd_Acceso()
        {
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {

                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    if (_Int_Sw == 1)
                    {
                        _Mtd_Nuevo();
                    }
                    _Pnl_Clave.Visible = false;
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
        }
        private void Frm_ConteoCompleto_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            this.Dock = DockStyle.Fill;
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Adicional.Left = (this.Width / 2) - (_Pnl_Adicional.Width / 2);
            _Pnl_Adicional.Top = (this.Height / 2) - (_Pnl_Adicional.Height / 2);
        }

        private void Frm_ConteoCompleto_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        string[] _Str_Array = new string[0];
        private void _Bt_Filtrar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Str_Sql = "";
            _Frm_Busq.ShowDialog(this);
            Cursor = Cursors.WaitCursor;
            if (_Str_Sql.TrimEnd().Length > 0)
            {
                _Mtd_Actualizar_Productos(_Str_Sql);
            }
            Cursor = Cursors.Default;
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            _Prb_Progreso.Value = 0;
            _Prb_Progreso.Visible = true;
            _Er_Error.Dispose();
            Cursor = Cursors.WaitCursor;
            if (_Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Seleccionar"].Value) == "1").Count() > 0)
            {
                _Mtd_Conteo_Sql();
                label13.Visible = true;
                _Prb_Progreso.Visible = false;
            }
            else
            { MessageBox.Show("Debe marcar las tarjetas para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            Cursor = Cursors.Default;
        }

        private void _Rbt_Filtro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Filtro.Checked) { _Bt_Filtrar.Enabled = true; _Str_Sql = ""; _Mtd_Actualizar_Productos("Where 5>7"); } else { _Bt_Filtrar.Enabled = false; _Str_Sql = ""; }
        }
        int _Int_Sw = 0;
        private void _Bt_Nuevas_Click(object sender, EventArgs e)
        {
            _Str_Array = new string[0];
            _Int_Sw = 1;
            _Pnl_Clave.BringToFront();
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_Borrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de borrar las tarjetas?", "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Borrar();
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            ticker.Start();
            _Pnl_Espere.Visible = true;
            _Pnl_Espere.Parent = this;
            _Pnl_Espere.BringToFront();
            this._Pnl_Espere.Visible = true;
            _Pnl_Espere.Location=new Point(0,0);
            _Mtd_Imprimir();               
        }
       
        private void _Mtd_Borrar()
        {
            string _Str_Cadena = "SELECT DISTINCT '' as id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cpresentacion,CASE WHEN cactivate='1' THEN 'Activo' ELSE 'Inactivo' END AS Status,'0' as Seleccionar FROM TPRODUCTO INNER JOIN TPROVEEDOR ON TPRODUCTO.cproveedor=TPROVEEDOR.cproveedor INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor=TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND 1>2";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Bt_Nuevas.Enabled = true;
            _Bt_Generar.Enabled = false;
            _Grb_1.Enabled = false;
            _Grb_2.Enabled = false;
            _Rbt_Activos.Checked = false;
            _Rbt_Desmarcar.Checked = false;
            _Rbt_Filtro.Checked = false;
            _Rbt_Inactivos.Checked = false;
            _Bt_Imprimir.Enabled = false;
            _Rbt_Todos.Checked = false;
            _Dg_Grid.Columns["Seleccionar"].Visible = true;
            _Txt_Tarjetas.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Impresas.Text = "";
            MessageBox.Show("Las tarjetas han sido borradas correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void _Mtd_GenerarArchivoAscii(string _P_Str_Cadena)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
            string[] _Str_Fila = new string[_Ds.Tables[0].Rows.Count];
            int _Int_I = 0;
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Fila[_Int_I] = CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp).Replace(",", "") + ",";
                _Str_Fila[_Int_I] += _Row["id_tarjetainv"].ToString().Trim().Replace(",","") + ",";
                _Str_Fila[_Int_I] += _Row["cproducto"].ToString().Trim().Replace(",", "") + ",";
                _Str_Fila[_Int_I] += _Row["cnamef"].ToString().Trim().Replace(",", "") + ",";
                _Str_Fila[_Int_I] += _Row["cpresentacion"].ToString().Trim().Replace(",", "");
                _Int_I++;
            }
            System.IO.File.WriteAllLines(Application.StartupPath + @"\AsciiTar.txt", _Str_Fila);
        }
        REPORTESS _Frm_R;
        private void _Mtd_Imprimir()
        {
            if (this.InvokeRequired)
            {
                ChangeProgressBarCallback callback = new ChangeProgressBarCallback(_Mtd_Imprimir);
            }
            else
            {
                try
                {
                    PrintDialog _Print;
                    progressBar1.Maximum = 100;
                    Cursor = Cursors.WaitCursor;
                    string _Str_Cadena = "Select cimpreso from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    Cursor = Cursors.Default;
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                        {
                            MessageBox.Show("Se va a imprimir el reporte de verificación de tarjetas emitidas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //--------------------------------
                            Cursor = Cursors.WaitCursor;
                            _Print = new PrintDialog();
                            Cursor = Cursors.Default;
                            if (_Print.ShowDialog() == DialogResult.OK)
                            {
                                _Bt_Imprimir.Enabled = false;
                                Cursor = Cursors.WaitCursor;
                                _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rVerificacionTar", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "'", _Print, true);
                                Cursor = Cursors.Default;
                                if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    _Frm_R.Close();
                                    Cursor = Cursors.WaitCursor;
                                    _Str_Cadena = "Update TINVFISICOM set cimpvertaremit='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    Cursor = Cursors.Default;
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                                    _Pnl_Panel_1.Enabled = false;
                                    this._Bt_AbrirConteo.Visible = true;
                                }
                                else
                                {
                                    _Bt_Imprimir.Enabled = true;
                                    _Pnl_Panel_1.Enabled = true;
                                    _Pnl_Panel_2.Enabled = true;
                                }
                            }
                            //--------------------------------
                        }
                        else
                        {
                            bool _Bol_No = false;
                            bool _Bol_Impreso = false;
                            if (MessageBox.Show("¿Desea imprimir la tarjetas?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (MessageBox.Show("¿Desea imprimir la totalidad de las tarjetas?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    _Bt_Imprimir.Enabled = false;
                                    Cursor = Cursors.WaitCursor;
                                    Frm_Inf_Varios _Frm = new Frm_Inf_Varios(9, "0", "0");
                                    Cursor = Cursors.Default;
                                    _Frm.Size = this.Size;
                                    _Frm.ShowDialog(this);
                                    if (MessageBox.Show("¿Las tarjetas fueron impresas correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        _Str_Cadena = "Update TINVFISICOM set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                        Cursor = Cursors.Default;
                                        _Bol_Impreso = true;
                                    }
                                    else
                                    {
                                        _Pnl_Adicional.BringToFront();
                                        _Pnl_Adicional.Visible = true;
                                    }
                                }
                                else
                                {
                                    _Pnl_Adicional.BringToFront();
                                    _Pnl_Adicional.Visible = true;
                                }
                            }
                            else
                            {
                                _Bol_No = true;
                                _Bol_Impreso = true;
                            }
                            if (_Bol_Impreso)
                            {
                                MessageBox.Show("A continuación el reporte de verificación de tarjetas emitidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor = Cursors.WaitCursor;
                                _Print = new PrintDialog();
                                Cursor = Cursors.Default;
                                if (_Print.ShowDialog() == DialogResult.OK)
                                {
                                    _Bt_Imprimir.Enabled = false;
                                    Cursor = Cursors.WaitCursor;
                                    _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rVerificacionTar", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "'", _Print, true);
                                    Cursor = Cursors.Default;
                                    if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        _Frm_R.Close();
                                        if (_Bol_No)
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            _Str_Cadena = "Update TINVFISICOM set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                            Cursor = Cursors.Default;
                                        }
                                        _Str_Cadena = "Update TINVFISICOM set cimpvertaremit='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                                        _Pnl_Panel_1.Enabled = false;
                                        _Bt_Generar.Enabled = false;
                                        this._Bt_AbrirConteo.Visible = true;
                                    }
                                    else
                                    {
                                        _Bt_Imprimir.Enabled = true;
                                        _Pnl_Panel_1.Enabled = true;
                                        _Pnl_Panel_2.Enabled = true;
                                    }
                                }
                                else
                                {
                                    _Bt_Imprimir.Enabled = true;
                                    _Pnl_Panel_1.Enabled = true;
                                    _Pnl_Panel_2.Enabled = true;
                                }
                            }
                        }
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("No se pudo conectar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); _Bt_Imprimir.Enabled = true; Cursor = Cursors.Default; }
                finally
                {
                    Cursor = Cursors.Default;
                    progressBar1.Value = 0;
                    progressBar1.Refresh();
                    ticker.Stop();
                    _Pnl_Espere.Visible = false;
                }
            }
        }
        private void _Mtd_Nuevo()
        {
            string _Str_Cadena = "Insert Into TINVFISICOM (ccompany,id_conteo,cdate)values('" + Frm_Padre._Str_Comp + "','1','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Txt_Fecha.Text = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            _Txt_Impresas.Text = "No";
            _Bt_Nuevas.Enabled = false;
            _Bt_Generar.Enabled = true;
            _Grb_1.Enabled = true;
            _Grb_2.Enabled = true;
            _Mtd_Actualizar_Productos("");
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Frm_TarjetaInvent _Frm = new Frm_TarjetaInvent(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[e.RowIndex].Cells[2].Value.ToString(), _Dg_Grid.Rows[e.RowIndex].Cells[3].Value.ToString(), _Dg_Grid.Rows[e.RowIndex].Cells[4].Value.ToString());
                _Frm.ShowDialog(this);
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Pnl_Panel_1.Enabled = false;
                _Pnl_Panel_2.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Pnl_Panel_1.Enabled = true;
                _Pnl_Panel_2.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            _Mtd_Acceso();
        }

        private void _Rbt_Activos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Activos.Checked)
            {
                _Mtd_Actualizar_Productos("Where cactivate='1'");
            }
        }

        private void _Rbt_Inactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Inactivos.Checked)
            {
                _Mtd_Actualizar_Productos("Where cactivate='0'");
            }
        }

        private void _Rbt_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Todos.Checked)
            {
                _Mtd_Actualizar_Productos("Where 0=0");
            }
        }

        private void _Rbt_Desmarcar_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Desmarcar.Checked)
            {
                _Str_Array = new string[0];
                _Mtd_Actualizar_Productos("Where 5>7");
            }
        }

        private void _Txt_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { _Mtd_Acceso(); }
        }

        private void _Bt_Iniciar_Click(object sender, EventArgs e)
        {

        }

        private void _Pnl_Adicional_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Adicional.Visible)
            {
                _Pnl_Panel_1.Enabled = false;
                _Pnl_Panel_2.Enabled = false;
                _Dg_Grid.Enabled = false;
                string _Str_Cadena = "Select id_tarjetainv from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' order by id_tarjetainv Desc";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        int _Int_N = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                        _Num_Desde.Minimum = 1;
                        _Num_Desde.Maximum = _Int_N;
                        _Num_Hasta.Maximum = _Int_N;
                        _Num_Desde.Value = 1;
                        _Num_Hasta.Value = _Int_N;
                    }
                }
            }
            else
            {
                _Pnl_Panel_1.Enabled = true;
                _Pnl_Panel_2.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }

        private void _Num_Desde_ValueChanged(object sender, EventArgs e)
        {
            _Num_Hasta.Minimum = _Num_Desde.Value;
        }

        private void _Bt_Cancelar_Adicional_Click(object sender, EventArgs e)
        {
            _Pnl_Adicional.Visible = false;
            _Bt_Imprimir.Enabled = true;
        }
        private void _Mtd_Adicional()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                PrintDialog _Print = new PrintDialog();
                Cursor = Cursors.Default;
                _Pnl_Adicional.Visible = false;
                Cursor = Cursors.WaitCursor;
                Frm_Inf_Varios _Frm = new Frm_Inf_Varios(9, _Num_Desde.Value.ToString(), _Num_Hasta.Value.ToString());
                Cursor = Cursors.Default;
                _Frm.Size = this.Size;
                _Frm.ShowDialog(this);
                if (MessageBox.Show("¿Las tarjetas fueron impresas correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Cadena = "Update TINVFISICOM set cimpreso='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    Cursor = Cursors.Default;
                    //--------------------------------
                    MessageBox.Show("A continuación el reporte de verificación de tarjetas emitidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.WaitCursor;
                    _Print = new PrintDialog();
                    Cursor = Cursors.Default;
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        _Bt_Imprimir.Enabled = false;
                        Cursor = Cursors.WaitCursor;
                        _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rVerificacionTar", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "'", _Print, true);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Frm_R.Close();
                            _Bt_Imprimir.Enabled = false;
                            Cursor = Cursors.WaitCursor;
                            _Str_Cadena = "Update TINVFISICOM set cimpvertaremit='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            Cursor = Cursors.Default;
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                            this._Bt_AbrirConteo.Visible = true;
                        }
                        else
                        { _Bt_Imprimir.Enabled = true; }
                    }
                    //--------------------------------
                }
                else
                {
                    _Pnl_Adicional.Visible = true;
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("No se pudo conectar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); _Pnl_Adicional.Visible = true; Cursor = Cursors.Default; }
        }
        private void _Bt_Aceptar_Adicional_Click(object sender, EventArgs e)
        {
            _Mtd_Adicional();
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

        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void _Dg_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_Dg_Grid.Rows.Count > 0)
                {
                    if (_Dg_Grid[6, e.RowIndex].Value != null)
                    {
                        if (_Dg_Grid[6, e.RowIndex].Value.ToString() == "1")
                        {
                            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, _Str_Array.Length + 1);
                            _Str_Array[_Str_Array.Length - 1] = _Dg_Grid[2, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            int _Int_Index = Array.IndexOf(_Str_Array, _Dg_Grid[2, e.RowIndex].Value.ToString());
                            if (_Int_Index > -1)
                            {
                                Array.Clear(_Str_Array, _Int_Index, 1);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public bool _Mtd_AbiertoOno(Form _Frm_Formulario)
        {
            foreach (Form _Frm_Hijo in this.MdiParent.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Frm_Formulario.Name)
                {
                    _Frm_Hijo.Activate();
                    return true;
                }
            }
            return false;
        }

        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        var _Dt_Tabla = new DataTable();
                        if (_Dg_Grid.DataSource.GetType() == typeof(DataView))
                            _Dt_Tabla = ((DataView)_Dg_Grid.DataSource).ToTable();
                        else
                            _Dt_Tabla = (DataTable)_Dg_Grid.DataSource;
                        Cursor = Cursors.WaitCursor;
                        Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                        _MyExcel._Mtd_DatasetToExcel(_Dt_Tabla, _Sfd_1.FileName, "CONTEO_INVENT " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString(), _Dg_Grid.Columns);
                        _MyExcel = null;
                        Cursor = Cursors.Default;
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private bool _Mtd_SePuedeIniciarConteo()
        {
            string _Str_Cadena = "Select ccompany from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen ajustes de entrada por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "Select ccompany from TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen ajustes de salida por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT ccompany FROM TAJUSTEINTEGRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado='0' AND ISNULL(cfuseraprobador2,0)=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen ajustes integrados por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT ccompany FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=1 AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen facturas anuladas por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT ccompany FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=2 AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede iniciar el conteo porque existen facturas pendientes por anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void _Bt_AbrirConteo_Click(object sender, EventArgs e)
        {
            CLASES._Cls_Varios_Metodos myUtilidad = new T3.CLASES._Cls_Varios_Metodos(true);
            if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IMPRESION_TARJETA"))
            {
                if (!_Mtd_SePuedeIniciarConteo())
                    return;
                string _Str_Cadena = "Select cimpreso,ciniciado from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        if (_Ds.Tables[0].Rows[0][1].ToString().Trim() == "1")
                        {
                            Frm_ConteoInventario _Frm = new Frm_ConteoInventario();
                            if (!_Mtd_AbiertoOno(_Frm))
                            { _Frm.MdiParent = this.MdiParent; _Frm.Dock = DockStyle.Fill; _Frm.Show(); this.Close(); }
                            else
                            { _Frm.Dispose(); }
                        }
                        else
                        {
                            Frm_VerificacionTarjetas _Frm = new Frm_VerificacionTarjetas();
                            if (!_Mtd_AbiertoOno(_Frm))
                            { _Frm.MdiParent = this.MdiParent; _Frm.Dock = DockStyle.Fill; _Frm.Show(); this.Close(); }
                            else
                            { _Frm.Dispose(); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las tarjetas aún no han sido impresas. No podra realizar operaciones en este módulo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Las tarjetas aún no han sido creadas. No podra realizar operaciones en este módulo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            { MessageBox.Show("Su usuario no posee permiso para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
    }
}