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
    public partial class Frm_NotaDebitoCxCAnul : Form
    {
        int _G_Int_Tab = 0;
        string _Str_MyProceso = "";
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_NotaDebitoCxCAnul()
        {
            InitializeComponent();
        }
        public Frm_NotaDebitoCxCAnul(int _P_Int_Tab)
        {
            InitializeComponent();
            _G_Int_Tab = _P_Int_Tab;
            _Rbt_NoAnul.Enabled = false;
        }
        private void Frm_NotaDebitoCxCAnul_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_NotaDebitoCxCAnul_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Mtd_Actualizar_NoAnul()
        {
            string _Str_Where = "";
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocc";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_FindSql = "Select top ?sel cidnotadebitocc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion AS Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_NOTADEBITO_CxC WHERE NOT cidnotadebitocc IN (select top ?omi cidnotadebitocc FROM VST_NOTADEBITO_CxC WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdescontada=0 and cdelete=0 AND canulado=0 AND cimpresa=1 AND cidcomprob>0 AND (ISNULL(cidcomprobanul, 0) = 0) AND (cnotanulado IS NULL OR cnotanulado=''))) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdescontada=0 AND cdelete=0 AND canulado=0 AND cimpresa=1 AND cidcomprob>0 AND (ISNULL(cidcomprobanul, 0) = 0) AND (cnotanulado IS NULL OR cnotanulado='')";
            _Str_Where = "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdescontada=0 AND cdelete=0 AND canulado=0 AND cimpresa=1 AND cidcomprob>0 AND (ISNULL(cidcomprobanul, 0) = 0) AND (cnotanulado IS NULL OR cnotanulado='')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Dédito", _Tsm_Menu, _Dg_Grid, "VST_NOTADEBITO_CxC", _Str_Where, 100, "ORDER BY cidnotadebitocc");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //___________________________________
        }
        private void _Mtd_Actualizar_Anul()
        {
            string _Str_FindSql = "", _Str_Where="";
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocc";
            _Str_Campos[1] = "c_nomb_comer";
            if (_G_Int_Tab == 1)
            {
                _Str_FindSql = "Select top ?sel cidnotadebitocc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion_anul as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_ND_ANUL WHERE NOT cidnotadebitocc IN (select top ?omi cidnotadebitocc FROM VST_ND_ANUL WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1)) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo_anul=0 AND cestatusfirma_anul=1";
                _Str_Where = "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1";
            }
            else
            {
                _Str_FindSql = "Select top ?sel cidnotadebitocc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion_anul as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_ND_ANUL WHERE NOT cidnotadebitocc IN (select top ?omi cidnotadebitocc FROM VST_ND_ANUL WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 AND cactivo_anul=1 AND cestatusfirma_anul=2)) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo_anul=1 AND cestatusfirma_anul=2";
                _Str_Where = "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivo_anul=1 AND cestatusfirma_anul=2";
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Dédito", _Tsm_Menu, _Dg_Grid, "VST_ND_ANUL", _Str_Where, 100, "ORDER BY cidnotadebitocc");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //___________________________________
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
            string _Str_FindSql = "Select top ?sel cidnotadebitocc AS Código, RTRIM(c_nomb_comer) AS Cliente,ccliente,cdescripcion_anul as Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto FROM VST_ND_ANUL WHERE NOT cidnotadebitocc IN (select top ?omi cidnotadebitocc FROM VST_ND_ANUL WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1)) and cdelete=0 AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo_anul=0 AND cestatusfirma_anul=1";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Notas de Créditos", _Tsm_Menu, _Dg_Grid, "VST_ND_ANUL", "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivo_anul=0 AND cestatusfirma_anul=1", 100, "ORDER BY cidnotadebitocc");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotianulndcxc='1' ORDER BY cdescripcion ASC";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
        }
        private void Frm_NotaDebitoCxCAnul_Load(object sender, EventArgs e)
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
        private string _Mtd_MotivoDescrip(string _P_Str_ND)
        {
            string _Str_Cadena = "SELECT TMOTIVO.cdescripcion FROM TNOTADEBICC INNER JOIN TMOTIVO ON TNOTADEBICC.cmotivoanulacion=TMOTIVO.cidmotivo WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _P_Str_ND + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper().Trim();
            }
            return "";
        }
        private void _Mtd_CargarData(string _Pr_Str_ND)
        {
            string _Str_Sql = "SELECT * FROM VST_NOTADEBITO_CxC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Pr_Str_ND + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Ds.Tables[0].Rows[0]["cidnotadebitocc"].ToString();
                _Txt_Control.Text = _Ds.Tables[0].Rows[0]["cnumcontrolnd"].ToString();
                _Txt_CodCliente.Text = _Ds.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                _Txt_DesCliente.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim().ToUpper();
                _Txt_Fecha.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                _Txt_Motivo.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cidmotivodescrip"]).Trim();
                _Txt_Descripcion.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdescripcion"]).Trim();
                _Txt_Documento.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocuaname"]).Trim();
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
                    if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_AND_CXC"))
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
                        _Bt_Anular.Text = "Aprobar N.D.";
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
        private bool _Mtd_ValidadAnular(string _Str_IdAnular, string _Str_Compania)
        {
            bool _Bol_Validar = true;
            string _Str_SQL = "SELECT TOP 1 ctipdocnotdeb FROM TCONFIGCXC WHERE CCOMPANY='"+_Str_Compania+"'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_TipoND = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                _Str_SQL = "SELECT CSALDOFACTURA FROM TSALDOCLIENTED WHERE ctipodocument='"+_Str_TipoND+"' AND CNUMDOCU='"+_Str_IdAnular+"' AND CSALDOFACTURA>0 AND CCOMPANY='"+_Str_Compania+"'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    _Bol_Validar = false;
                }
                else
                {
                    _Str_SQL = "SELECT CNUMDOCU FROM TRELACCOBD WHERE ctipodocument='" + _Str_TipoND + "' AND CNUMDOCU='" + _Str_IdAnular + "' AND CCOMPANY='" + _Str_Compania + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Bol_Validar = false;
                    }
                }
            }
            if (!_Bol_Validar)
            {
                _Str_SQL = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE ccompany='" + _Str_Compania + "' AND cidnotadebitocc='" + _Str_IdAnular + "' AND canulado='1'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0].Rows.Count == 0)
                {
                    _Str_SQL = "SELECT cidnotadebito FROM TNDANUL WHERE ccompany='" + _Str_Compania + "' AND cidnotadebito='" + _Str_IdAnular + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_SQL = "UPDATE TNOTADEBICC SET cmotivoanulacion=null,cfechaanul=NULL WHERE ccompany='" + _Str_Compania + "' AND cidnotadebitocc='" + _Str_IdAnular + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        _Str_SQL = "DELETE FROM TNDANUL WHERE cidnotadebito='" + _Str_IdAnular + "' AND ccompany='" + _Str_Compania + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    }
                }

            }
            return _Bol_Validar;
        }
        int _Int_Sw = 0;
        private void _Bt_Anular_Click(object sender, EventArgs e)
        {
            bool _Bol_Sw = false;
            if (_Mtd_ValidadAnular(_Txt_Cod.Text, Frm_Padre._Str_Comp))
            {
                string _Str_Sql = "SELECT canulado FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Txt_Cod.Text + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1")
                    { _Bol_Sw = true; }
                }

                //-- Inicio -- Validacion de documentos ya usados en orden de pago y/o cobranza
                string _Str_CodigoProveedor = "";
                string _Str_TipoDocumento = "NOTA DE DEBITO CXC";
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
                    if (MessageBox.Show("Esta seguro de anular la ND# " + _Txt_Cod.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _Int_Sw = 1;
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Text = "";
                        _Txt_Clave.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("La Nota de Débito ya fue anulada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("La Nota de Débito no puede ser anulada ya que fue cobrada con anterioridad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Mtd_SeleccionarMotAnul()
        {
            string _Str_Cadena = "SELECT cmotivoanulacion FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' AND NOT cmotivoanulacion IS NULL";
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
                {
                    if (_Mtd_ValidadAnular(_Txt_Cod.Text, Frm_Padre._Str_Comp))
                    {
                        _Mtd_Anular();
                    }
                }
                else
                {
                    _Mtd_Rechazar();
                }
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
                string _Str_cndanu = "";
                string _Str_cidcomprob = "";
                string _Str_Sql = "select cidcomprobanul,ccliente from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Str_MyProceso == "F1")
                    {
                        _Str_Sql = "UPDATE TNOTADEBICC SET cmotivoanulacion='" + _Cmb_Motivo.SelectedValue.ToString() + "',cfechaanul='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_cndanu = _MyUtilidad._Mtd_Correlativo("SELECT MAX(cndanu) FROM TNDANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                        if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("SELECT * FROM TNDANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebito='" + _Txt_Cod.Text.Trim() + "'"))
                        {
                            _Str_Sql = "INSERT INTO TNDANUL (ccompany,cidnotadebito,cndanu,cdescripcion,cfechaanul,cactivo,cestatusfirma,cdateadd,cuseradd,cdelete) VALUES('" +
                                Frm_Padre._Str_Comp + "','" + _Txt_Cod.Text + "','" + _Str_cndanu + "','" + _Txt_Descripcion.Text.ToUpper() + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',0,1,'" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0)";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                        MessageBox.Show("Se cargo la ND como anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        string _Str_Cadena = "SELECT cidnotadebito FROM TNDANUL WHERE cidnotadebito='" + _Txt_Cod.Text.Trim() + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        {
                            PrintDialog _Print = new PrintDialog();
                        _PrintG:
                            if (_Print.ShowDialog() == DialogResult.OK)
                            {
                                string _Str_Id_Comprobante = "";
                                _Str_Cadena = "SELECT cidcomprobanul FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                                DataSet _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_DsTemp.Tables[0].Rows[0][0] == System.DBNull.Value | _DsTemp.Tables[0].Rows[0][0].ToString().Trim() == "0")
                                {
                                    if (CLASES._Cls_Varios_Metodos._Mtd_EsClienteIC(_Txt_CodCliente.Text.Trim()))
                                    { _Str_Id_Comprobante = _MyUtilidad._Mtd_Proceso_P_CXC_ND_A(_Txt_Cod.Text.Trim(), "P_CXC_ND_A_IC"); }
                                    else
                                    { _Str_Id_Comprobante = _MyUtilidad._Mtd_Proceso_P_CXC_ND_A(_Txt_Cod.Text.Trim(), "P_CXC_ND_A"); }
                                    _Str_Sql = "UPDATE TNOTADEBICC SET cidcomprobanul='" + _Str_Id_Comprobante + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                else
                                {
                                    _Str_Id_Comprobante = _DsTemp.Tables[0].Rows[0][0].ToString().Trim();
                                }
                                Cursor = Cursors.WaitCursor;
                                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Id_Comprobante + "'", _Print, true);
                                Cursor = Cursors.Default;
                                _Frm.MdiParent = this.MdiParent;
                                _Frm.Show();
                                if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    _Str_Sql = "UPDATE TNOTADEBICC SET canulado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    _Str_Sql = "UPDATE TNDANUL SET cactivo=1,cestatusfirma=2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebito='" + _Txt_Cod.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    MessageBox.Show("Se anuló correctamente la N.D.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        else
                        {
                            MessageBox.Show("Han eliminado la anulación. Deben cargar la anulación nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
        }
        private void _Mtd_Rechazar()
        {
            string _Str_Sql = "UPDATE TNOTADEBICC SET cmotivoanulacion=null,cfechaanul=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Str_Sql = "DELETE FROM TNDANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebito='" + _Txt_Cod.Text.Trim() + "'";
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
            { _Str_Cadena = "Select cidcomprob from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'"; }
            else
            { _Str_Cadena = "Select cidcomprobanul from TNOTADEBICC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocc='" + _Txt_Cod.Text.Trim() + "' and ccliente='" + _Txt_CodCliente.Text.Trim() + "'"; }
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

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
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

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            { _Txt_Clave.Enabled = true; _Txt_Clave.Focus(); }
            else
            { _Txt_Clave.Text = ""; _Txt_Clave.Enabled = false; }
        }

        private void _Txt_Clave_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Aceptar.Enabled = _Txt_Clave.Enabled;
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            bool _Bol_Sw = false;
            string _Str_Sql = "SELECT canulado FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Txt_Cod.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1")
                { _Bol_Sw = true; }
            }
            if (_Bol_Sw)
            {
                if (MessageBox.Show("Esta seguro de rechazar la anulación de la ND# " + _Txt_Cod.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Int_Sw = 2;
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("La Nota de Débito ya fue anulada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Anular_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Rechazar.Enabled = _Bt_Anular.Enabled && _Str_MyProceso == "F2";
        }
    }
}