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
    public partial class Frm_AnulNotaDebito : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_AnulNotaDebito()
        {
            InitializeComponent();
            _Mtd_Actualizar_NoAnul();
        }
        bool _Bol_Tabs = false;
        public Frm_AnulNotaDebito(bool _P_Bol_Tabs)
        {
            InitializeComponent();
            _Bol_Tabs = true;
            _Rbt_NoAnul.Enabled = false;
            _Rbt_Anul.Checked = true;
        }
        private void _Mtd_Actualizar_Anul()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocxp";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotadebitocxp as Código,cdescripcion as Descripción,cproveedor,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTADEBITOCP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidcomprob>'0'";
            if (_Bol_Tabs)
            { _Str_Cadena += " AND cactivo='1' AND cimpresa='1' AND (cmotivoanulacion<>'0' AND NOT cmotivoanulacion IS NULL) AND (canulado='0' OR canulado IS NULL)"; }
            else
            { _Str_Cadena += " AND (canulado='1')"; }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //___________________________________
        }
        private void _Mtd_Actualizar_NoAnul()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocxp";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "Select cidnotadebitocxp as Código,cdescripcion as Descripción,cproveedor,dbo.Fnc_Formatear(ctotaldocu) as Monto from TNOTADEBITOCP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and canulado='0' and cactivo='1' and cimpresa='1' and cidcomprob>'0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //___________________________________
        }
        private void _Mtd_ini()
        {
            _Txt_Cod.Text = "";
            _Txt_CodProveedor.Text = "";
            _Txt_DesProveedor.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Control.Text = "";
            _Txt_Documento.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Exento.Text = "";
            _Txt_Motivo.Text = "";
            _Txt_NumDoc.Text = "";
            _Txt_Total.Text = "";
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotianulndcxp='1' ORDER BY cdescripcion ASC";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
        }
        private void Frm_AnulNotaDebito_Load(object sender, EventArgs e)
        {

        }

        private void Frm_AnulNotaDebito_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                string _Str_Cadena = "Select cidnotadebitocxp,cproveedor,ctipodocument,cnumdocu,cnumcontrolnd,cdescripcion,CASE WHEN ISNULL(cidnotrecepc,0)>0 THEN ISNULL(cmontototsi,0)-ISNULL(cbaseexcenta,0) ELSE cmontototsi END AS cmontototsi,cimpuesto,cfechand,cporcinvendible,ctotaldocu,cbaseexcenta from TNOTADEBITOCP where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "' and cproveedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    _Txt_Cod.Text = _Row["cidnotadebitocxp"].ToString().Trim().ToUpper();
                    _Txt_Control.Text = _Row["cnumcontrolnd"].ToString().Trim().ToUpper();
                    _Txt_CodProveedor.Text = _Row["cproveedor"].ToString().Trim().ToUpper();
                    _Str_Cadena = "Select c_nomb_abreviado from TPROVEEDOR where (cglobal='1' OR ccompany='" + Frm_Padre._Str_Comp + "') AND cproveedor='" + _Txt_CodProveedor.Text + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    { _Txt_DesProveedor.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
                    if (Convert.ToString(_Row["cfechand"]) != "")
                    {
                        _Txt_Fecha.Text = Convert.ToDateTime(_Row["cfechand"]).ToShortDateString();
                    }
                    else
                    {
                        _Txt_Fecha.Text = "";
                    }
                    int _Int_Index = _Row["cdescripcion"].ToString().Trim().IndexOf(" FACTURA# ");
                    if (_Int_Index != -1)
                    {
                        _Txt_Motivo.Text = _Row["cdescripcion"].ToString().Trim().Substring(0, _Int_Index).ToUpper();
                    }
                    else
                    {
                        _Txt_Motivo.Text = _Row["cdescripcion"].ToString().Trim().ToUpper();
                    }
                    _Txt_Descripcion.Text = _Row["cdescripcion"].ToString().Trim().ToUpper();
                    _Str_Cadena = "Select cname from TDOCUMENT where ctdocument='" + _Row["ctipodocument"].ToString().Trim().ToUpper() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    { _Txt_Documento.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
                    _Txt_NumDoc.Text = _Row["cnumdocu"].ToString().Trim().ToUpper();
                    if (_Row["cmontototsi"] != System.DBNull.Value)
                    { _Txt_Monto.Text = Convert.ToDouble(_Row["cmontototsi"].ToString().Trim()).ToString("#,##0.00"); }
                    if (_Row["cbaseexcenta"] != System.DBNull.Value)
                    { _Txt_Exento.Text = Convert.ToDouble(_Row["cbaseexcenta"].ToString().Trim()).ToString("#,##0.00"); }
                    if (_Row["cporcinvendible"] != System.DBNull.Value)
                    { _Txt_Invendible.Text = Convert.ToDouble(_Row["cporcinvendible"].ToString().Trim()).ToString("#,##0.00"); }
                    if (_Row["cimpuesto"] != System.DBNull.Value)
                    { _Txt_Impuesto.Text = Convert.ToDouble(_Row["cimpuesto"].ToString().Trim()).ToString("#,##0.00"); }
                    if (_Row["ctotaldocu"] != System.DBNull.Value)
                    { _Txt_Total.Text = Convert.ToDouble(_Row["ctotaldocu"].ToString().Trim()).ToString("#,##0.00"); }
                    _Bt_Detalle.Enabled = _Mtd_TieneDetalle();
                    _Tb_Tab.SelectedIndex = 1;
                    if (_Rbt_Anul.Checked & _Bol_Tabs)
                    {
                        _Bt_Anular.Text = "Aprobar N.D.";
                        _Bt_Rechazar.Text = "Rechazar N.D.";
                    }
                    else if (_Rbt_Anul.Checked & !_Bol_Tabs)
                    {
                        _Bt_Anular.Text = "Anular N.D.";
                        _Bt_Rechazar.Text = "...";
                    }
                    if ((_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_AND_CXP") & !_Bol_Tabs) | (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_AND_CXP")))
                    {
                        _Bt_Anular.Enabled = ((_Rbt_NoAnul.Checked & !_Bol_Tabs) | (_Rbt_Anul.Checked & _Bol_Tabs));
                        if (_Rbt_Anul.Checked & _Bol_Tabs)
                        {
                            _Bt_Rechazar.Enabled = true;
                        }
                        else
                        {
                            _Bt_Rechazar.Enabled = false;
                        }
                    }
                    else
                    {
                        _Bt_Anular.Enabled = false;
                        _Bt_Rechazar.Enabled = false;
                    }
                }
            }
        }

        private void _Bt_Detalle_Click(object sender, EventArgs e)
        {
            if (_Txt_CodProveedor.Text.Trim().Length > 0 & _Txt_Cod.Text.Trim().Length > 0 & _Txt_NumDoc.Text.Trim().Length > 0)
            {
                Frm_DetalleNcNd _Frm = new Frm_DetalleNcNd(_Txt_Cod.Text.Trim(), _Txt_NumDoc.Text.Trim(), 1, _Txt_CodProveedor.Text.Trim());
                _Frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Faltan datos para la impresión", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Anular_Click(object sender, EventArgs e)
        {
            bool _Bol_Sw = false;
            if (_Txt_CodProveedor.Text.Trim().Length > 0 & _Txt_Cod.Text.Trim().Length > 0)
            {
                string _Str_Sql = "SELECT canulado FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "' AND cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1")
                    { _Bol_Sw = true; }
                }

                //-- Inicio -- Validacion de documentos ya usados en orden de pago y/o cobranza
                string _Str_CodigoProveedor = _Txt_CodProveedor.Text.Trim();
                string _Str_TipoDocumento = "NOTA DE DEBITO CXP";
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
                    if (_Mtd_CanNDanular())
                    {
                        if (MessageBox.Show("Esta seguro de anular la ND# " + _Txt_Cod.Text.Trim(), "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            _Pnl_Clave.Visible = true;
                            _Txt_Clave.Text = "";
                            _Txt_Clave.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede Anular la Nota de Débito.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("La Nota de Débito ya fue anulada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para la anulación", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            //Verifico el estado de la ND
            string _Str_Sql = "SELECT canulado, cmotivoanulacion FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "' AND cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si obtengo datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Si esta anulada
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["canulado"]) == "1")
                {
                    MessageBox.Show("La Nota de Débito ya fue anulada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Si no tiene motivo de anulacion
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivoanulacion"]) == "0")
                {
                    MessageBox.Show("La Nota de Débito no esta marcada para anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Pregunto si esta seguro
                if (MessageBox.Show("Esta seguro de rechazar la anulacion de la ND# " + _Txt_Cod.Text.Trim(), "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Actualizo la ND
                    string _Str_Cadena = "UPDATE TNOTADEBITOCP SET cmotivoanulacion='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    //Inicializo los controle muestro mensaje de confirmacion
                    _Pnl_Clave.Visible = false;
                    MessageBox.Show("Se rechazó la anulación de la ND.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ini();
                    _Tb_Tab.SelectedIndex = 0;
                    if (_Rbt_NoAnul.Checked)
                    { _Mtd_Actualizar_NoAnul(); }
                    else
                    { _Mtd_Actualizar_Anul(); }

                }
            }
        }
        private void _Mtd_SeleccionarMotAnul()
        {
            string _Str_Cadena = "SELECT cmotivoanulacion FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' AND NOT cmotivoanulacion IS NULL";
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
                if (_Bol_Tabs)
                { _Tb_Tab.Enabled = false; _Mtd_CargarMotivo(); _Mtd_SeleccionarMotAnul(); _Cmb_Motivo.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Enabled = true; _Txt_Clave.Focus(); }
                else
                { _Tb_Tab.Enabled = false; _Mtd_CargarMotivo(); _Cmb_Motivo.Enabled = true; _Txt_Clave.Text = ""; _Txt_Clave.Enabled = false; _Cmb_Motivo.Focus(); }
            }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
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
                    _Bt_Anular.Enabled = false;
                    if (_Bol_Tabs)
                    {
                        if (_Mtd_CuentasInactivas(_Txt_Cod.Text.Trim()))
                        {
                            this.Close();
                        }
                        else
                        { _Mtd_Anular(); }
                    }
                    else
                    {
                        _Pnl_Clave.Visible = false;
                        _Mtd_Cargar_Anulacion(_Cmb_Motivo.SelectedValue.ToString());
                        MessageBox.Show("Se cargo la ND como anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_ini();
                        _Tb_Tab.SelectedIndex = 0;
                        if (_Rbt_NoAnul.Checked)
                        { _Mtd_Actualizar_NoAnul(); }
                        else
                        { _Mtd_Actualizar_Anul(); }
                    }
                    _Bt_Anular.Enabled = true;
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { MessageBox.Show("Error en la operación"); }
            Cursor = Cursors.Default;
        }
        private void _Mtd_Cargar_Anulacion(string _P_Str_Motivo)
        {
            string _Str_Cadena = "UPDATE TNOTADEBITOCP SET cmotivoanulacion='" + _P_Str_Motivo + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_InsertAuxiliarCont(string _P_Str_Comprob, string _P_Str_ComprobAnul)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_ComprobAnul);
            string _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) SELECT TCOMPROBANDD.ccompany,'" + _P_Str_ComprobAnul + "',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBANDD.ccount ELSE TCOUNTINAC.ccountactiva END,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBANDD.cidtipoauxiliar ELSE TTIPAUXILIARCONTD.cidtipoauxiliar END,cidauxiliarcont,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBANDD.cdescrip)) ELSE REPLACE(TCOMPROBANDD.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN',TCOMPROBANDD.ctdocument,cnumdocu,cfechaemision,cfechavencimiento,chaber,cdebe,'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year + "','0',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBANDD.cclasificauxiliar ELSE TCOUNT_1.cclasificauxiliar END " +
               "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
               "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva LEFT OUTER JOIN " +
               "TTIPAUXILIARCONTD ON TCOUNT_1.ccount = TTIPAUXILIARCONTD.ctcount RIGHT OUTER JOIN " +
               "TCOMPROBANDD INNER JOIN " +
               "TCOUNT ON TCOMPROBANDD.ccompany = TCOUNT.ccompany AND TCOMPROBANDD.ccount = TCOUNT.ccount ON " +
               "(TTIPAUXILIARCONTD.ctdocument = TCOMPROBANDD.ctdocument OR TTIPAUXILIARCONTD.ctdocument IS NULL) AND TCOUNTINAC.ccompany = TCOMPROBANDD.ccompany AND " +
               "TCOUNTINAC.ccountinactiva = TCOMPROBANDD.ccount WHERE TCOMPROBANDD.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANDD.cidcomprob='" + _P_Str_Comprob + "' AND (TCOUNT_1.cauxiliary='1' OR TCOUNTINAC.ccountactiva IS NULL)";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Anular()
        {
            try
            {
                string _Str_Sql = "";
                string _Str_TpoDoc = "";
                string _Str_cidcomprobret = "";
                string _Str_Cadena = "select cidcomprobanul,cdiferenciaprec,cproveedor from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_CodProveedor.Text + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    PrintDialog _Print = new PrintDialog();
                _Print:
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        _Txt_Clave.Text = "";
                        _Pnl_Clave.Visible = false;
                        //_________________________________
                        int _Int_Id_Comprobante = new int();
                        CLASES._Cls_Varios_Metodos _Cls_Proceso = new T3.CLASES._Cls_Varios_Metodos(true);
                        _Str_Cadena = "Select cidcomprobanul from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'";
                        DataSet _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_DsTemp.Tables[0].Rows[0][0] == System.DBNull.Value | _DsTemp.Tables[0].Rows[0][0].ToString().Trim() == "0")
                        {
                            _Str_Cadena = "Select cidcomprob from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'";
                            _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _Int_Id_Comprobante = Convert.ToInt32(_Cls_Proceso._Mtd_CrearComprobanteAnulacion(_DsTemp.Tables[0].Rows[0][0].ToString().Trim()));
                            _Mtd_InsertAuxiliarCont(_DsTemp.Tables[0].Rows[0][0].ToString().Trim(), _Int_Id_Comprobante.ToString());
                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cidcomprobanul='" + _Int_Id_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'");
                        }
                        else
                        {
                            _Int_Id_Comprobante = Convert.ToInt32(_DsTemp.Tables[0].Rows[0][0].ToString().Trim());
                        }
                        Cursor = Cursors.WaitCursor;
                        REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", _Print, true);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //----------------------------------------------------------------------------------
                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "canulado='1',cfechaanul='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'");
                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'");
                            _Str_Sql = "SELECT ctipodocnd FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Str_TpoDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]);
                            }
                            //_________________________________
                            //_________________________________ANULO CUENTAS POR PAGAR
                            _Str_Cadena = "UPDATE TFACTPPAGARM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_CodProveedor.Text + "' AND ctipodocument='" + _Str_TpoDoc + "' and cnumdocu='" + _Txt_Cod.Text + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "UPDATE TMOVCXPM SET cactivo=0,canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_CodProveedor.Text + "' AND ctipodocument='" + _Str_TpoDoc + "' and cnumdocu='" + _Txt_Cod.Text + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Sql = "SELECT cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_CodProveedor.Text + "' AND ctipodocument='" + _Str_TpoDoc + "' and cnumdocu='" + _Txt_Cod.Text + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Str_cidcomprobret = Convert.ToString(_Ds.Tables[0].Rows[0]["cidcomprobret"]);
                            }
                            //ANULO RETENCION DE IVA
                            if (_Str_cidcomprobret != "")
                            {
                                _Str_Cadena = "UPDATE TCOMPROBANRETC SET canulado=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Str_cidcomprobret + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Str_Sql = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _Str_cidcomprobret + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cidcomprob"]) != "")
                                    {
                                        _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + Convert.ToString(_Ds.Tables[0].Rows[0]["cidcomprob"]) + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                }
                            }
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            MessageBox.Show("La operación fué realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_ini();
                            _Tb_Tab.SelectedIndex = 0;
                            if (_Rbt_NoAnul.Checked)
                            { _Mtd_Actualizar_NoAnul(); }
                            else
                            { _Mtd_Actualizar_Anul(); }
                        }
                        else
                        {
                            _Frm.Close();
                            GC.Collect();
                            goto _Print;
                        }
                    }
                    else
                    {
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show("No se puede contactar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Cursor = Cursors.Default; }
        }
        private bool _Mtd_MateriaPrima(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT cglobal FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND cglobal='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_CuentasInactivas(string _P_Str_Id_Nd)
        {
            string _Str_Cadena = "Select cidcomprob from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _P_Str_Id_Nd + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                if (_Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_Comprobante))
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("El comprobante inicial tiene cuentas inactivas.\nDebe reemplazar las cuentas inactivas desde el notificador 'CUENTAS CONTABLES INACTIVAS POR REEMPLAZAR' para realizar la anulación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("No se obtuvo el comprobante inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void _Rbt_NoAnul_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_NoAnul.Checked)
            { _Mtd_ini(); _Mtd_Actualizar_NoAnul(); }
        }

        private void _Rbt_Anul_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Anul.Checked)
            { _Mtd_ini(); _Mtd_Actualizar_Anul(); }
        }

        private void _Bt_Comprobante_Click(object sender, EventArgs e)
        {
            if (_Txt_CodProveedor.Text.Trim().Length > 0 & _Txt_Cod.Text.Trim().Length > 0 & _Txt_NumDoc.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "";
                if (_Rbt_NoAnul.Checked)
                { _Str_Cadena = "Select cidcomprob from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'"; }
                else
                { _Str_Cadena = "Select cidcomprobanul from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_CodProveedor.Text.Trim() + "'"; }
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() != "0")
                    {
                        _Str_Cadena = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
                        Frm_VerComprobante _Frm_VerComprobante = new Frm_VerComprobante(_Str_Cadena);
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
            else
            {
                MessageBox.Show("Faltan datos para la impresión", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool _Mtd_CanNDanular()
        {
            bool _Bol_R = false;
            string _Str_TpoDoc = "";
            string _Str_cordenpaghecha = "";

            string _Str_Sql = "SELECT ctipodocnd FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]);
            }
            _Str_Sql = "SELECT cactivo,canulado,cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_CodProveedor.Text + "' AND ctipodocument='" + _Str_TpoDoc + "' AND cnumdocu='" + _Txt_Cod.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cordenpaghecha = Convert.ToString(_Ds.Tables[0].Rows[0]["cordenpaghecha"]);
            }
            if (_Str_cordenpaghecha == "1")
            {
                _Bol_R = false;
            }
            else
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }

        private bool _Mtd_TieneDetalle()
        {
            string _Str_Sql = "select * from TNOTADEBITOCPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
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
    }
}