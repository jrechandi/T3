using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_NotaCreditoCxCAnul : Form
    {
        int _G_Int_Tab = 0;
        string _Str_MyProceso = "";
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_NotaCreditoCxCAnul()
        {
            InitializeComponent();
        }
        public Frm_NotaCreditoCxCAnul(int _P_Int_Tab)
        {
            InitializeComponent();
            _G_Int_Tab = _P_Int_Tab;
            _Rbt_NoAnul.Enabled = false;
        }
        private void Frm_NotaCreditoCxCAnul_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_NotaCreditoCxCAnul_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Mtd_Actualizar_NoAnul()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotcredicc";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_FindSql = "Select top ?sel cidnotcredicc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion AS Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_NOTACREDI_CxC WHERE NOT cidnotcredicc IN (select top ?omi cidnotcredicc FROM VST_NOTACREDI_CxC WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdescontada=0 and cdelete=0 AND canulado=0 AND cimpresa=1 AND cidcomprob>0 AND cidcomprobanul=0 AND (cnotanuldo IS NULL OR cnotanuldo=''))) and cdescontada=0 and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND canulado=0 AND cimpresa=1 AND cidcomprob>0 AND cidcomprobanul=0 AND (cnotanuldo IS NULL OR cnotanuldo='')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Créditos", _Tsm_Menu, _Dg_Grid, "VST_NOTACREDI_CxC", "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdescontada=0 AND cdelete=0 AND canulado=0 AND cimpresa=1 AND cidcomprob>0 AND cidcomprobanul=0 AND (cnotanuldo IS NULL OR cnotanuldo='')", 100, "ORDER BY cidnotcredicc");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //___________________________________
        }
        private void _Mtd_Actualizar_Anul()
        {
            //___________________________________
            string _Str_Where = "";
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotcredicc";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_FindSql = "";
            if (_G_Int_Tab == 1)
            {
                _Str_FindSql = "Select top ?sel cidnotcredicc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion_anul as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_NC_ANUL WHERE NOT cidnotcredicc IN (select top ?omi cidnotcredicc FROM VST_NC_ANUL WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1)) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo_anul=0 AND cestatusfirma_anul=1";
                _Str_Where = "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1";
            }
            else
            {
                _Str_FindSql = "Select top ?sel cidnotcredicc AS Código, c_nomb_comer AS Cliente,ccliente,cdescripcion_anul as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_NC_ANUL WHERE NOT cidnotcredicc IN (select top ?omi cidnotcredicc FROM VST_NC_ANUL WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 AND cactivo_anul=1 AND cestatusfirma_anul=2)) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo_anul=1 AND cestatusfirma_anul=2";
                _Str_Where = "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivo_anul=1 AND cestatusfirma_anul=2";
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Créditos", _Tsm_Menu, _Dg_Grid, "VST_NC_ANUL", _Str_Where, 100, "ORDER BY cidnotcredicc");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_Actualizar_Aprob()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotcredicc";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_FindSql = "Select top ?sel cidnotcredicc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion_anul as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_NC_ANUL WHERE NOT cidnotcredicc IN (select top ?omi cidnotcredicc FROM VST_NC_ANUL WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1)) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo_anul=0 AND cestatusfirma_anul=1";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Créditos", _Tsm_Menu, _Dg_Grid, "VST_NC_ANUL", "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1", 100, "ORDER BY cidnotcredicc");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotianulnccxc='1' ORDER BY cdescripcion ASC";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
        }
        private void Frm_NotaCreditoCxCAnul_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            if (_G_Int_Tab == 0)
            {
                _Mtd_Actualizar_NoAnul();
            }
            else if (_G_Int_Tab == 1)
            {
                _Rbt_Anul.Checked = true;
            }
            _Mtd_Ini();
        }

        private void _Mtd_Ini()
        {
            _Txt_Cod.Text = "";
            _Txt_Control.Text = "";
            _Txt_CodCliente.Text = "";
            _Txt_DesCliente.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Motivo.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Documento.Text = "";
            _Txt_NumDoc.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Exento.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Total.Text = "";
            _Mtd_Bloquear(false);
            _Str_MyProceso = "";
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_Val)
        {
            _Txt_Cod.Enabled = false;
            _Txt_Control.Enabled = _Pr_Bol_Val;
            _Txt_CodCliente.Enabled = _Pr_Bol_Val;
            _Txt_DesCliente.Enabled = _Pr_Bol_Val;
            _Txt_Fecha.Enabled = _Pr_Bol_Val;
            _Txt_Motivo.Enabled = _Pr_Bol_Val;
            _Txt_Descripcion.Enabled = _Pr_Bol_Val;
            _Txt_Documento.Enabled = _Pr_Bol_Val;
            _Txt_NumDoc.Enabled = _Pr_Bol_Val;
            _Txt_Monto.Enabled = _Pr_Bol_Val;
            _Txt_Exento.Enabled = _Pr_Bol_Val;
            _Txt_Impuesto.Enabled = _Pr_Bol_Val;
            _Txt_Total.Enabled = _Pr_Bol_Val;
            _Bt_Anular.Enabled = false;
            _Bt_Comprobante.Enabled = false; 
        }
        private string _Mtd_MotivoDescrip(string _P_Str_NC)
        {
            string _Str_Cadena = "SELECT TMOTIVO.cdescripcion FROM TNOTACREDICC INNER JOIN TMOTIVO ON TNOTACREDICC.cmotivoanulacion=TMOTIVO.cidmotivo WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _P_Str_NC + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper().Trim();
            }
            return "";
        }
        private void _Mtd_CargarData(string _Pr_Str_NC)
        {
            string _Str_Sql = "SELECT * FROM VST_NOTACREDI_CxC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Ds.Tables[0].Rows[0]["cidnotcredicc"].ToString();
                _Txt_Control.Text = _Ds.Tables[0].Rows[0]["cnumcontrolnc"].ToString();
                _Txt_CodCliente.Text = _Ds.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                _Txt_DesCliente.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim().ToUpper();
                _Txt_Fecha.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                _Txt_Motivo.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cidmotivodescrip"]).Trim();
                _Txt_Descripcion.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdescripcion"]).Trim();
                _Txt_Documento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentname"]).Trim();
                _Txt_NumDoc.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]).Trim();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]) != "")
                {
                    _Txt_Monto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]).ToString("#,##0.00");
                }
                else
                { _Txt_Monto.Text = "0"; }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cexento"]) != "")
                {
                    _Txt_Exento.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cexento"]).ToString("#,##0.00");
                }
                else
                { _Txt_Exento.Text = "0"; }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]) != "")
                {
                    _Txt_Impuesto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                }
                else
                { _Txt_Impuesto.Text = "0"; }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]) != "")
                {
                    _Txt_Total.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                }
                else
                { _Txt_Total.Text = "0"; }
                _Tb_Tab.SelectTab(1);
            }

        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarData(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                if (_Rbt_NoAnul.Checked)
                {
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ANC_CXC"))
                    {
                        _Bt_Anular.Enabled = true;
                        _Str_MyProceso = "F1";
                    }
                    else
                    {
                        _Bt_Anular.Enabled = false;
                    }
                }
                else
                {
                    if (_G_Int_Tab == 1)
                    {
                        _Txt_Motivo.Text = _Mtd_MotivoDescrip(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                        _Bt_Anular.Enabled = true;
                        _Bt_Anular.Text = "Aprobar N.C.";
                        _Str_MyProceso = "F2";
                        _Bt_Comprobante.Enabled = false;
                    }
                    else
                    {
                        _Bt_Anular.Enabled = false;
                        _Bt_Comprobante.Enabled = true;
                    }
                }
                Cursor = Cursors.Default;
            }
        }
        int _Int_Sw = 0;
        private void _Bt_Anular_Click(object sender, EventArgs e)
        {
            bool _Bol_Sw = false;
            string _Str_Sql = "SELECT canulado FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Txt_Cod.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1")
                { _Bol_Sw = true; }
            }

            //-- Inicio -- Validacion de documentos ya usados en orden de pago y/o cobranza
            string _Str_CodigoProveedor = "";
            string _Str_TipoDocumento = "NOTA DE CREDITO CXC";
            string _Str_NumeroDocumento = _Txt_Cod.Text;
            //Verifico que el Documento ya no este en una cobranza
            string _Str_CodigoCobranzaIC = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraCobranza(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
            if (_Str_CodigoCobranzaIC != "")
            {
                MessageBox.Show("El siguiente documento ya se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Bol_Sw = false;
                return;
            }
            //Verifico que el Documento ya no este en una orden de pago
            string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
            if (_Str_CodigoOrdenPago != "")
            {
                MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Bol_Sw = false;
                return;
            }
            //-- Fin -- Validacion de documentos ya usados en orden de pago y/o cobranza


            if (_Bol_Sw)
            {
                if (MessageBox.Show("Esta seguro de anular la NC# " + _Txt_Cod.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Int_Sw = 1;
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("La Nota de Crédito ya fue anulada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Mtd_SeleccionarMotAnul()
        {
            string _Str_Cadena = "SELECT cmotivoanulacion FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' AND NOT cmotivoanulacion IS NULL";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false; _Mtd_CargarMotivo();
                if (_Str_MyProceso == "F1") 
                {
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Enabled = false;
                    _Cmb_Motivo.Enabled = true;
                    _Cmb_Motivo.Focus();
                }
                else 
                {
                    _Mtd_SeleccionarMotAnul();
                    _Cmb_Motivo.Enabled = false;
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Enabled = true;
                    _Txt_Clave.Focus();
                } 
            }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.WaitCursor;
                if (_Int_Sw == 1)
                { _Mtd_Anular(); }
                else
                { _Mtd_Rechazar(); }
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Mtd_Anular()
        {
            try
            {
                string _Str_cncanu="";
                string _Str_cidcomprob = "";
                bool _Bol_cexedentecobro = false;
                string _Str_Sql = "select cidcomprobanul,ccliente,cexedentecobro from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Ds2.Tables[0].Rows[0]["cexedentecobro"].ToString().Trim() == "1")
                    { _Bol_cexedentecobro = true; }
                    if (_Str_MyProceso == "F1")
                    {
                        _Str_Sql = "UPDATE TNOTACREDICC SET cmotivoanulacion='" + _Cmb_Motivo.SelectedValue.ToString() + "',cfechaanul='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_cncanu = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cncanu) FROM TNCANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                        if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("SELECT * FROM TNCANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredit='" + _Txt_Cod.Text.Trim() + "'"))
                        {
                            _Str_Sql = "INSERT INTO TNCANUL (ccompany,cidnotcredit,cncanu,cdescripcion,cfechaanul,cactivo,cestatusfirma,cdateadd,cuseradd,cdelete) VALUES('" +
                                                           Frm_Padre._Str_Comp + "','" + _Txt_Cod.Text + "','" + _Str_cncanu + "','" + _Txt_Descripcion.Text.ToUpper() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',0,1,'" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0)";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                        MessageBox.Show("Se cargo la NC como anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_Rbt_NoAnul.Checked)
                        { _Mtd_Actualizar_NoAnul(); }
                        else
                        { _Mtd_Actualizar_Anul(); }
                        _Mtd_Ini();
                        _Bt_Anular.Enabled = false;
                        _Tb_Tab.SelectedIndex = 0;
                    }
                    else if (_Str_MyProceso == "F2")
                    {
                        PrintDialog _Print = new PrintDialog();
                    _PrintG:
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            string _Str_Id_Comprobante = "";
                            string _Str_Cadena = "SELECT cidcomprobanul FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                            DataSet _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_DsTemp.Tables[0].Rows[0][0] == System.DBNull.Value | _DsTemp.Tables[0].Rows[0][0].ToString().Trim() == "0")
                            {
                                if (_Bol_cexedentecobro)
                                { _Str_Id_Comprobante = _MyUtilidad._Mtd_Proceso_P_CXC_NC_A(_Txt_Cod.Text.Trim(), "P_CXC_NCEXCD_A"); }
                                else
                                {
                                    if (CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(_Txt_CodCliente.Text.Trim()))
                                    { _Str_Id_Comprobante = _MyUtilidad._Mtd_Proceso_P_CXC_NC_A(_Txt_Cod.Text.Trim(), "P_CXC_NC_A_IC"); }
                                    else
                                    { _Str_Id_Comprobante = _MyUtilidad._Mtd_Proceso_P_CXC_NC_A(_Txt_Cod.Text.Trim(), "P_CXC_NC_A"); }
                                }
                                _Str_Sql = "UPDATE TNOTACREDICC SET cidcomprobanul='" + _Str_Id_Comprobante + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                            else
                            {
                                _Str_Id_Comprobante = _DsTemp.Tables[0].Rows[0][0].ToString().Trim();
                            }
                            REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Id_Comprobante + "'", _Print, true);
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                            if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Str_Sql = "UPDATE TNOTACREDICC SET canulado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "UPDATE TNCANUL SET cactivo=1,cestatusfirma=2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredit='" + _Txt_Cod.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                MessageBox.Show("Se anuló correctamente la N.C.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (_Rbt_NoAnul.Checked)
                                { _Mtd_Actualizar_NoAnul(); }
                                else
                                { _Mtd_Actualizar_Anul(); }
                                _Mtd_Ini();
                                _Bt_Anular.Enabled = false;
                                _Tb_Tab.SelectedIndex = 0;
                            }
                            else
                            {
                                _Frm.Close();
                                GC.Collect();
                                goto _PrintG;
                            }
                        }
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        private void _Mtd_Rechazar()
        {
            string _Str_Sql = "UPDATE TNOTACREDICC SET cmotivoanulacion=null,cfechaanul=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Str_Sql = "DELETE FROM TNCANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredit='" + _Txt_Cod.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_Rbt_NoAnul.Checked)
            { _Mtd_Actualizar_NoAnul(); }
            else
            { _Mtd_Actualizar_Anul(); }
            _Mtd_Ini();
            _Bt_Anular.Enabled = false;
            _Tb_Tab.SelectedIndex = 0;
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Rbt_NoAnul_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_NoAnul.Checked)
            { _Mtd_Ini(); _Mtd_Actualizar_NoAnul(); }
        }

        private void _Rbt_Anul_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Anul.Checked)
            {
                _Mtd_Ini();
                if (_G_Int_Tab == 1)
                {
                    _Mtd_Actualizar_Aprob();
                }
                else
                {
                    _Mtd_Actualizar_Anul();
                }
            }
        }

        private void _Bt_Comprobante_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            string _Str_Comprob = "";
            if (_Rbt_NoAnul.Checked)
            { _Str_Cadena = "Select cidcomprob from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'"; }
            else
            { _Str_Cadena = "Select cidcomprobanul from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() != "0")
                {
                    _Str_Comprob = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    Frm_VerComprobante _Frm_VerComprobante = new Frm_VerComprobante(_Str_Comprob);
                    _Frm_VerComprobante.MdiParent = this.MdiParent;
                    _Frm_VerComprobante.StartPosition = FormStartPosition.CenterScreen;
                    _Frm_VerComprobante.Show();
                }
                else
                { MessageBox.Show("No se puede realizar la operación", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            { MessageBox.Show("No se puede realizar la operación", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Cod.Text.Trim().Length == 0 & e.TabPageIndex != 0)
            { e.Cancel = true; }
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

        private void _Txt_Clave_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Aceptar.Enabled = _Txt_Clave.Enabled;
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            { _Txt_Clave.Enabled = true; _Txt_Clave.Focus(); }
            else
            { _Txt_Clave.Text = ""; _Txt_Clave.Enabled = false; }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void _Bt_Anular_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Rechazar.Enabled = _Bt_Anular.Enabled && _Str_MyProceso == "F2";
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            bool _Bol_Sw = false;
            string _Str_Sql = "SELECT canulado FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Txt_Cod.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1")
                { _Bol_Sw = true; }
            }
            if (_Bol_Sw)
            {
                if (MessageBox.Show("Esta seguro de rechazar la anulación de la NC# " + _Txt_Cod.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Int_Sw = 2;
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("La Nota de Crédito ya fue anulada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}