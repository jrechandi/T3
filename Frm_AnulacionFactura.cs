using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using T3.Clases;

namespace T3
{
    public partial class Frm_AnulacionFactura : Form
    {
        string _Str_MyProceso = "";
        public Frm_AnulacionFactura()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_Actualizar();
        }
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURA"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = !_Pnl_Clave.Visible;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            //if (_Str_MyProceso == "M")
            //{
            //    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            //}
            if (_Str_MyProceso == "")
            {
                if (_Txt_Factura.Text.Trim().Length > 0)
                {
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURA"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else
                {
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURA"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_FindSql = "Select top ?sel cfactura AS Factura,RTRIM(cvendedor_name) as Vendedor, ccliente AS Cliente, RTRIM(c_nomb_comer) AS Descripción,tot_cajas AS Empaques,tot_unidades AS Unidades,dbo.Fnc_Formatear(monto_total) AS Monto,RTRIM(motivo_cdescripcion) AS Motivo, cpedido AS Pedido, CONVERT(VARCHAR,c_fecha_pedido,103) AS [Fecha Ped.] FROM VST_FACTURA_ANUL WHERE NOT cfactura IN (select top ?omi cfactura from VST_FACTURA_ANUL WHERE (ccompany = '" + Frm_Padre._Str_Comp + "')) and cdelete=0 AND convert(datetime,convert(varchar(255),cfechaanul,103)) BETWEEN '" + _My_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _My_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            if (_Rb_FindPorAnular.Checked)
            {
                 _Str_FindSql = _Str_FindSql + " AND cactivo=0 AND cestatusfirma=1";
            }
            else if (_Rb_FindAnuladas.Checked)
            {
                _Str_FindSql = "Select top ?sel cfactura AS Factura, CONVERT(VARCHAR,cfechaanul,103) AS [Fecha Anul.],RTRIM(cvendedor_name) as Vendedor, ccliente AS Cliente, RTRIM(c_nomb_comer) AS Descripción,tot_cajas AS Empaques,tot_unidades AS Unidades,dbo.Fnc_Formatear(monto_total) AS Monto,RTRIM(motivo_cdescripcion) AS Motivo,cpedido AS Pedido, CONVERT(VARCHAR,c_fecha_pedido,103) AS [Fecha Ped.]  FROM VST_FACTURA_ANUL WHERE NOT cfactura IN (select top ?omi cfactura from VST_FACTURA_ANUL WHERE (ccompany = '" + Frm_Padre._Str_Comp + "')) and cdelete=0 AND convert(datetime,convert(varchar(255),cfechaanul,103)) BETWEEN '" + _My_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _My_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
                _Str_FindSql = _Str_FindSql + " AND cactivo=1 AND cestatusfirma=2";
            }
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Factura");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cfactura";
            _Str_Campos[1] = "c_nomb_comer";
            _Dg_Consulta.DataSource = null;
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Facturas", _Tsm_Menu, _Dg_Consulta, "VST_FACTURA_ANUL", "WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND cdelete=0 AND convert(datetime,convert(varchar(255),cfechaanul,103)) BETWEEN '" + _My_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _My_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'", 100, "ORDER BY cfactura");
            _Dg_Consulta.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Consulta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Consulta.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________            
        }
        //private void _Mtd_Consulta()
        //{
        //    string _Str_Sql = "SELECT cfactura,CONVERT(VARCHAR(10),ccliente) + '-' + RTRIM(c_nomb_comer) AS cliente_descrip,CONVERT(VARCHAR(255),cfechaanul,103) AS cfechaanul,motivo_cdescripcion FROM VST_FACTURA_ANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0";
        //    _Str_Sql = _Str_Sql + " AND convert(datetime,convert(varchar(255),cfechaanul,103)) BETWEEN '" + _My_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _My_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
        //    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
        //    object[] _Str_RowNew = new object[4];
        //    _Dg_Consulta.Rows.Clear();
        //    foreach (DataRow _DataR in _Ds.Tables[0].Rows)
        //    {
        //        Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
        //        _Dg_Consulta.Rows.Add(_Str_RowNew);
        //        if (Convert.ToString(_Dg_Consulta[2, _Dg_Consulta.RowCount-1].Value).Length > 0)
        //        {
        //            _Dg_Consulta[2, _Dg_Consulta.RowCount - 1].Value = Convert.ToDateTime(_Dg_Consulta[2, _Dg_Consulta.RowCount - 1].Value).ToShortDateString();
        //        }
        //        else
        //        {
 
        //        }
        //    }
        //    _Dg_Consulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //}
        private void _Mtd_Cargar_Motivo()
        {
            string _Str_Cadena = "SELECT RTRIM(cidmotivo),cdescripcion FROM TMOTIVO where cmotianulfact='1' ORDER BY cdescripcion ASC";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Cadena);
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
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Dg_FactPorAnular.Rows.Clear();
            _Str_MyProceso = "A";
            _Bt_Buscar.Enabled = true;
            _Tb_Tab.SelectTab(1);
            _Bt_Buscar.Focus();
            _Mtd_BotonesMenu();
            _Pnl_Clave.Visible = false;
        }
        public void _Mtd_Cancelar()
        {
            //_Mtd_Ini();
            _Mtd_BotonesMenu();
            string _Str_Sql = "";
            foreach (DataGridViewRow _DgRow in _Dg_FactPorAnular.Rows)
            {
                _Str_Sql = "DELETE FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DgRow.Cells[0].Value.ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TFACTURAM SET cmotianulfact=-1,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _DgRow.Cells[0].Value.ToString() + "'";
                //OJO -1 PARA QUE NO SE ACTIBE EL TRIGGER EN LA TABLA TFACTURAM
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            _Dg_FactPorAnular.Rows.Clear();
            _Mtd_Actualizar();
        }
        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_Cajas.Text = "";
            _Txt_Cliente.Text = "";
            _Txt_Factura.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Pedido.Text = "";
            _Txt_Vendedor.Text = "";
            _Txt_Unidades.Text = "";
            _Dg_Grid.Rows.Clear();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Mtd_Cargar_Motivo();
            _Mtd_Bloquear(false);
        }
        private bool _Mtd_ValidaSave()
        {
            bool _Bol_R = true;
            if (_Dg_FactPorAnular.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _Bol_R = false;
            }
            return _Bol_R;
        }
        public bool _Mtd_Guardar()
        {
            bool _Bol_R = false;
            if (_Mtd_ValidaSave())
            {
                try
                {
                    _Pnl_Clave.BringToFront();
                    _Pnl_Clave.Visible = true;
                    _Bol_R = false;

                }
                catch
                {
                    _Bol_R = false;
                    MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return _Bol_R;

        }
        private string _Mtd_RetornarMotivo(string _P_Str_Motivo)
        {
            string _Str_Cadena = "SELECT cdescripcion FROM TMOTIVO WHERE cidmotivo='" + _P_Str_Motivo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_GuardarPrimeraFirma()
        {
            string _Str_Sql = "";
            string _Str_cfacturanu = "";
            foreach (DataGridViewRow _DgRow in _Dg_FactPorAnular.Rows)
            {
               _Str_cfacturanu = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cfacturanu) FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
               _Str_Sql = "INSERT INTO TFACTURANUL (ccompany,cfactura,cfacturanu,cdescripcion,cfechaanul,cdateadd,cuseradd,cdelete,cactivo,cestatusfirma) VALUES ('" +Frm_Padre._Str_Comp + "','" + Convert.ToString(_DgRow.Cells[0].Value).Trim() + "','" + _Str_cfacturanu + "','" + _Mtd_RetornarMotivo(Convert.ToString(_DgRow.Cells[8].Value).Trim()) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','0','1')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TFACTURAM SET cmotianulfact='" + Convert.ToString(_DgRow.Cells[8].Value).Trim() + "',cfechaanul='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + Convert.ToString(_DgRow.Cells[0].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
        }
        private void _Mtd_Anular()
        {
            if (_Str_MyProceso == "A")
            {
                if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANULFACTURA"))
                {
                    _Mtd_GuardarPrimeraFirma();
                }
            }
            
        }
        private void _Mtd_ImprimirComprobante(string _Pr_Str_ComprobId)
        {
            string _Str_TpoDoc = "";
            string _Str_Sql = "";
            double _Dbl_MontoTot = 0;
            DataSet _Ds;
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
            A:
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'", _Print, true);
                if (MessageBox.Show("Se imprimió correctamente?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "Update TFACTURAM set c_fact_anul='1',cmotianulfact='" + _Cmb_Motivo.SelectedValue + "',cidcomprobanul='" + _Pr_Str_ComprobId + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + _Txt_Factura.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count>0)
                    {
                        _Str_TpoDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                    }
                    _Str_Sql = "DELETE FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _Txt_Cliente.Tag.ToString() + "' AND ctipodocument='" + _Str_TpoDoc + "' and cnumdocu='" + _Txt_Factura.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Dbl_MontoTot = Convert.ToDouble(_Txt_Monto.Text.Replace(".", "").Replace(",", "."));
                    _Str_Sql = "UPDATE TSALDOCLIENTEM SET csaldopendi=csaldopendi-" + _Dbl_MontoTot.ToString().Replace(",", ".") + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _Txt_Cliente.Tag.ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    goto A;
                }
            }

        }
        private void Frm_AnulacionFactura_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Parent = this;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            string _Str_ProcesoInterno = _Str_MyProceso;
            string _Str_Factura = "";
            Cursor = Cursors.WaitCursor;
            TextBox _Txt_TemporalCod = new TextBox();
            TextBox _Txt_TemporalCliente = new TextBox();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(27, _Txt_TemporalCod, _Txt_TemporalCliente, 0, 3, _Mtd_FacturasSeleccionadas());
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            //-----------------------------
            if (_Txt_TemporalCod.Text.Trim().Length > 0)
            {
                _Str_Factura = _Txt_TemporalCod.Text;
                if (_Str_Factura.Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Ini();

                    //-- Inicio -- Validacion de documentos ya usados en orden de pago y/o cobranza
                    string _Str_CodigoProveedor = "";
                    string _Str_TipoDocumento = "FACTURA CXC";
                    string _Str_NumeroDocumento = _Str_Factura;
                    //Verifico que el Documento ya no este en una cobranza
                    string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraCobranza(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoCobranzaIC != "")
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("El siguiente documento ya se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //Verifico que el Documento ya no este en una orden de pago
                    string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoOrdenPago != "")
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //-- Fin -- Validacion de documentos ya usados en orden de pago y/o cobranza

                    _Str_MyProceso = _Str_ProcesoInterno;
                    _Bt_Buscar.Enabled = true;
                    _Txt_Factura.Text = _Str_Factura;
                    _Mtd_CargarData(_Txt_Factura.Text,0);
                    string _Str_Sql = "SELECT cfacturanu from TFACTURANUL where ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + _Txt_Factura.Text + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Cmb_Motivo.Enabled = false;
                    }
                    else
                    {
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.SelectedIndex = -1;
                    }
                    Cursor = Cursors.Default;
                }
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                _Pnl_Clave.BringToFront();
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); 
            }
            else
            { ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = true; _Tb_Tab.Enabled = true; }
        }

        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Motivo();
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private bool _Mtd_VerificarFacturasEnPreCarga()
        {
            string _Str_Cadena = "";
            DataSet _Ds;
            bool _Bol_EnPreCargaComoDev = false;
            bool _Bol_EnFacturaEnGuiaNoLiquid = false;
            bool _Bol_FacturaEnPreCarga = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_FactPorAnular.Rows)
            {
                _Bol_EnPreCargaComoDev = false;
                _Bol_EnFacturaEnGuiaNoLiquid = false;
                _Str_Cadena = "SELECT TPRECARGADPF.cpfactura FROM TPRECARGADPF INNER JOIN TPRECARGAM ON TPRECARGADPF.cgroupcomp = TPRECARGAM.cgroupcomp AND TPRECARGADPF.cprecarga = TPRECARGAM.cprecarga INNER JOIN TFACTURAM ON TPRECARGADPF.cgroupcomp = TFACTURAM.cgroupcomp AND TPRECARGADPF.cprecarga = TFACTURAM.cprecarga AND TPRECARGADPF.cpfactura = TFACTURAM.cpfactura WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTURAM.c_factdevuelta = 1) AND (TFACTURAM.cfactura='" + Convert.ToString(_Dg_Row.Cells["cfactura"].Value).Trim() + "')";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Bol_EnPreCargaComoDev = true; }
                //--------------------------
                _Str_Cadena = "SELECT TGUIADESPACHOD.cfactura FROM TGUIADESPACHOM INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOM.cgroupcomp=TGUIADESPACHOD.cgroupcomp AND TGUIADESPACHOM.cguiadesp=TGUIADESPACHOD.cguiadesp WHERE TGUIADESPACHOM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOD.ccompany='" + Frm_Padre._Str_Comp + "' AND TGUIADESPACHOD.cfactura='" + Convert.ToString(_Dg_Row.Cells["cfactura"].Value).Trim() + "' AND TGUIADESPACHOM.cliqguidespacho='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Bol_EnFacturaEnGuiaNoLiquid = true; }
                //--------------------------
                if (_Bol_EnFacturaEnGuiaNoLiquid | (_Bol_EnPreCargaComoDev & !_Bol_EnFacturaEnGuiaNoLiquid))
                { _Bol_FacturaEnPreCarga = true; _Dg_Row.DefaultCellStyle.BackColor = Color.Red; }
            }
            return _Bol_FacturaEnPreCarga;
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
                    _Pnl_Clave.Visible = false;
                    if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado(Frm_Padre._Str_Comp))
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!_Mtd_VerificarFacturasEnPreCarga())
                    {
                        _Mtd_Anular();
                        if ((Frm_Padre)this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                        _Mtd_Ini();
                        _Dg_FactPorAnular.Rows.Clear();
                        _Mtd_Actualizar();
                        _Mtd_BotonesMenu();
                        _Tb_Tab.SelectTab(0);
                    }
                    else
                    {
                        MessageBox.Show("Existen facturas devueltas en una Pre-Carga que esta por ser procesada.\nDebe eliminar las Facturas marcadas en rojo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void Frm_AnulacionFactura_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            this.Cursor = Cursors.Default;
        }

        private void _Dg_Consulta_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Consulta.Rows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Dg_FactPorAnular.Rows.Clear();
                _Mtd_CargarData( _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), 0);
                _Bt_AddFactura.Enabled = false;
                _Tb_Tab.SelectTab(1);
                _Mtd_BotonesMenu();
                this.Cursor = Cursors.Default;
            }
        }
        private void _Mtd_CargarData(string _Pr_Str_Factura,int _Pr_Int_Detalle)
        {
            double _Dbl_Imp = 0, _Dbl_MontoSimp=0, _Dbl_Total =0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT * FROM VST_FACTURA_ONLY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Pr_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Factura.Text = _Pr_Str_Factura;
                _Txt_Cliente.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]).Trim();
                _Txt_Cliente.Text = _Txt_Cliente.Tag+ "-" + Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim();
                _Txt_Vendedor.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]).Trim();
                _Txt_Vendedor.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]).Trim()+":"+Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor_name"]).Trim();
                _Str_Sql = "SELECT SUM(cempaques), SUM(cunidades) FROM TFACTURAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Pr_Str_Factura + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Txt_Cajas.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]).ToString("#,##0");
                    _Txt_Unidades.Text = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][1]).ToString("#,##0");
                }
                _Dbl_Imp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto_bs"]);
                _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si_bs"]);
                _Dbl_Total = _Dbl_Imp + _Dbl_MontoSimp;
                _Txt_Monto.Text = _Dbl_Total.ToString("#,##0.00");
                _Str_Sql = "SELECT cpedido FROM TPREFACTURAM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cpfactura='"+_Ds.Tables[0].Rows[0]["cpfactura"].ToString()+"'";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Txt_Pedido.Text = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cpedido"]).Trim();
                }
                else
                {
                    _Txt_Pedido.Text = "0";
                }
                if (_Pr_Int_Detalle == 0)
                {
                    _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["cmotianulfact"].ToString();
                }
                else if (_Pr_Int_Detalle == 1)
                {
                    _Str_Sql = "SELECT cmotianulfact FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_Factura.Text + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Cmb_Motivo.SelectedValue = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cmotianulfact"]);
                    }
                }
                _Str_Sql = "SELECT cproducto,(produc_descrip+'.'+produc_descrip_2) AS prod_descrip,cempaques,cunidades FROM VST_FACTURAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_Factura.Text + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                object[] _Str_RowNew = new object[4];
                _Dg_Grid.Rows.Clear();
                foreach (DataRow _DataR in _Ds_A.Tables[0].Rows)
                {
                    Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                    _Dg_Grid.Rows.Add(_Str_RowNew);
                }
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Str_Sql = "SELECT cactivo,cestatusfirma FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_Factura.Text +"'";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["cactivo"]) == "0" && Convert.ToString(_Ds_A.Tables[0].Rows[0]["cestatusfirma"]) == "0")
                    {
                        object[] _Obj_RowNew = new object[9];
                        _Obj_RowNew[0] = _Txt_Factura.Text;
                        _Obj_RowNew[1] = _Txt_Vendedor.Text;
                        _Obj_RowNew[2] = _Txt_Cliente.Text;
                        _Obj_RowNew[3] = _Txt_Cajas.Text;
                        _Obj_RowNew[4] = _Txt_Unidades.Text;
                        _Obj_RowNew[5] = _Txt_Monto.Text;
                        _Obj_RowNew[6] = _Txt_Cliente.Tag.ToString();
                        _Obj_RowNew[7] = _Txt_Vendedor.Tag.ToString();
                        _Obj_RowNew[8] = _Cmb_Motivo.SelectedValue.ToString();
                        _Dg_FactPorAnular.Rows.Add(_Obj_RowNew);
                        _Dg_FactPorAnular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        _Bt_Buscar.Enabled = true;
                        _Str_MyProceso = "A";
                        _Mtd_BotonesMenu();
                    }

                }
            }
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_Factura.Enabled = false;
            _Txt_Pedido.Enabled = false;
            _Txt_Cliente.Enabled = false;
            _Txt_Vendedor.Enabled = false;
            _Bt_AddFactura.Enabled = false;
            _Txt_Cajas.Enabled = false;
            _Txt_Unidades.Enabled = false;
            _Txt_Monto.Enabled = false;
            _Bt_Buscar.Enabled = _Pr_Bol_A;
            _Cmb_Motivo.Enabled = _Pr_Bol_A;
        }
        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1)));
            _Dt_Desde.Value = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1)));
            _Dt_Hasta.Value = Convert.ToDateTime(_My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1)));
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void Frm_AnulacionFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                if (!_Bt_Buscar.Enabled & _Txt_Factura.Text.Trim().Length == 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cmb_Motivo, "");
            if (_Str_MyProceso == "A")
            {
                if (_Cmb_Motivo.SelectedIndex > 0)
                {
                    _Bt_AddFactura.Enabled = true;
                }
                else
                {
                    _Bt_AddFactura.Enabled = false;
                }
            }
        }

        private void _Bt_AddFactura_Click(object sender, EventArgs e)
        {
            string _Str_ProcesoInterno = _Str_MyProceso;
            bool _Bol_Sw = false;
            foreach (DataGridViewRow _DgRow in _Dg_FactPorAnular.Rows)
            {
                if (_DgRow.Cells[0].Value.ToString() == _Txt_Factura.Text)
                {
                    _Bol_Sw = true;
                    break;
                }
            }
            if (_Cmb_Motivo.SelectedIndex<1)
            {
                _Er_Error.SetError(_Cmb_Motivo, "Información requerida.");
                _Bol_Sw = true;
            }
            if (!_Bol_Sw)
            {
                object[] _Obj_RowNew = new object[9];
                _Obj_RowNew[0] = _Txt_Factura.Text;
                _Obj_RowNew[1] = _Txt_Vendedor.Text;
                _Obj_RowNew[2] = _Txt_Cliente.Text;
                _Obj_RowNew[3] = _Txt_Cajas.Text;
                _Obj_RowNew[4] = _Txt_Unidades.Text;
                _Obj_RowNew[5] = _Txt_Monto.Text;
                _Obj_RowNew[6] = _Txt_Cliente.Tag.ToString();
                _Obj_RowNew[7] = _Txt_Vendedor.Tag.ToString();
                _Obj_RowNew[8] = _Cmb_Motivo.SelectedValue.ToString();
                _Dg_FactPorAnular.Rows.Add(_Obj_RowNew);
                _Dg_FactPorAnular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Mtd_Ini();
                _Bt_Buscar.Enabled = true;
                _Str_MyProceso = _Str_ProcesoInterno;
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
            }
            else
            {
                MessageBox.Show("La factura ya fue agregada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void eliminarSelecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _Str_FactDel=_Dg_FactPorAnular[0,_Dg_FactPorAnular.CurrentCell.RowIndex].Value.ToString();
            string _Str_ProcesoInterno = _Str_MyProceso;
            string _Str_Sql = "DELETE FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Str_FactDel + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Str_Sql = "UPDATE TFACTURAM SET cmotianulfact=-1,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Str_FactDel + "'";
            //OJO -1 PARA QUE NO SE ACTIBE EL TRIGGER EN LA TABLA TFACTURAM
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Dg_FactPorAnular.Rows.RemoveAt(_Dg_FactPorAnular.CurrentCell.RowIndex);
            if (_Txt_Factura.Text == _Str_FactDel)
            {
                _Mtd_Ini();
                _Bt_Buscar.Enabled = true;
                _Str_MyProceso = _Str_ProcesoInterno;
            }
            if ((Frm_Padre)this.MdiParent != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            }
        }

        private void _Dg_FactPorAnular_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Bt_AddFactura.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Mtd_CargarData(_Dg_FactPorAnular[0, e.RowIndex].Value.ToString(),1);
            _Bt_AddFactura.Enabled = false;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_FactPorAnular.CurrentCell == null)
            { e.Cancel = true; }
            else
            {
                eliminarSelecciónToolStripMenuItem.Text = "Eliminar factura " + _Dg_FactPorAnular[0,_Dg_FactPorAnular.CurrentCell.RowIndex].Value.ToString();
            }
        }
        private string _Mtd_FacturasSeleccionadas()
        {
            string _Str_R = "";
            foreach (DataGridViewRow _DgRow in _Dg_FactPorAnular.Rows)
            {
                _Str_R = _Str_R + "cnumdocu<>" + _DgRow.Cells[0].Value.ToString() + " AND ";
            }
            if (_Str_R.Length > 0)
            {
                _Str_R = _Str_R.Substring(0, _Str_R.Length - 5);
                _Str_R = " AND (" + _Str_R + ")";
            }
            return _Str_R;
        }
    }
}