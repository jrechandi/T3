using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_GuiaManual : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_GuiaManual()
        {
            InitializeComponent();
            _Dtm_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_Fecha.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_FechaP.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_FechaP.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Mtd_Cargar_Estatus();
            _Mtd_Cargar_Firma();
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Tipo();
            this.Height = _Pnl_Primero.Height + 27;
            _Er_Error.Dispose();
        }
        double _Dbl_Monto = 0;
        Frm_GuiaDespacho _Frm_Guia;
        public Frm_GuiaManual(string _P_Str_Guia, Frm_GuiaDespacho _P_Frm_Guia)
        {
            InitializeComponent();
            _Dtm_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_Fecha.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_FechaP.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_FechaP.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Frm_Guia = _P_Frm_Guia;
            _Txt_Guia.Text = _P_Str_Guia;
            _Mtd_Cargar_Estatus();
            _Mtd_Cargar_Firma();
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Tipo();
            this.Height = _Pnl_Primero.Height + 27;
            _Er_Error.Dispose();
        }
        public Frm_GuiaManual(string _P_Str_Factura, string _P_Str_Guia, Frm_GuiaDespacho _P_Frm_Guia, string _P_Str_Comp)
        {
            InitializeComponent();
            _Dtm_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_Fecha.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_FechaP.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtm_FechaP.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Txt_Factura.Text = _P_Str_Factura;
            _Txt_Factura.Enabled = false;
            _Frm_Guia = _P_Frm_Guia;
            _Txt_Guia.Text = _P_Str_Guia;
            _Mtd_Cargar_Estatus();
            _Mtd_Cargar_Firma();
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Tipo();
            this.Height = _Pnl_Primero.Height + 27;
            _Er_Error.Dispose();
            _Mtd_Igualar(_P_Str_Guia, _P_Str_Factura, _P_Str_Comp);
        }

        private void _Mtd_CargarComp(string _P_Str_Guia,string _P_Str_Factura)
        {
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Comp, "SELECT TCOMPANY.ccompany, TCOMPANY.cname FROM TCOMPANY INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany = TCOMPANY.ccompany INNER JOIN TGUIADESPACHOD ON TGROUPCOMPANYD.cgroupcomp = TGUIADESPACHOD.cgroupcomp AND TGROUPCOMPANYD.ccompany = TGUIADESPACHOD.ccompany where TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOD.cguiadesp='" + _P_Str_Guia + "' AND TGUIADESPACHOD.cfactura='" + _P_Str_Factura + "' AND TCOMPANY.cdelete='0'");
        }
        bool _Bol_ContribuyenteEspecial = false;
        private void _Mtd_Cliente(string _P_Str_Factura,string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT CONVERT(VARCHAR,TCLIENTE.ccliente)+' - '+TCLIENTE.c_nomb_comer, TCLIENTE.ccliente FROM TFACTURAM INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + _P_Str_Comp + "') AND (TFACTURAM.cfactura='" + _P_Str_Factura + "')";
            var _Str_ccliente = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ccliente = _Ds.Tables[0].Rows[0]["ccliente"].ToString().Trim().ToUpper();
                _Txt_Cliente.Text = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                //Si es Especial
                if (_Mtd_ClienteEsContribuyenteEspecial(_Str_ccliente))
                {
                    _Bol_ContribuyenteEspecial = true;
                    _Txt_TipoCliente.Text = "CONTRIBUYENTE ESPECIAL";
                    _Txt_TipoCliente.BackColor = Color.Yellow;
                    _Chk_SinRetencion.BackColor = Color.Yellow;
                }
                else
                {
                    _Bol_ContribuyenteEspecial = false;
                    _Txt_TipoCliente.Text = "CONTRIBUYENTE REGULAR";
                    _Txt_TipoCliente.BackColor = SystemColors.ButtonFace;
                    _Chk_SinRetencion.BackColor = SystemColors.ButtonFace;
                }
            }
        }
        /// <summary>Este método permite verificar si el cliente retiene impuesto.</summary>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <returns>Verdadero si es un cliente que retiene impuesto.</returns>
        private bool _Mtd_ClienteEsContribuyenteEspecial(string _P_Str_Cliente)
        {
            string _Str_SQL;
            bool _Bol_Validar = false;

            _Str_SQL = "select cretieneimp from TCLIENTE inner join TCONTRIBUYENTE on TCLIENTE.c_tip_contribuy = TCONTRIBUYENTE.CCONTRIBUYENTE";
            _Str_SQL += " where (tcliente.CCLIENTE='" + _P_Str_Cliente + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Bol_Validar = ((dsResultados.Tables[0].Rows[0]["cretieneimp"].ToString() == "1") ? true : false);
            }

            return _Bol_Validar;
        }
        private void _Mtd_CurrentIndex(string _P_Str_Factura)
        {
            DataGridViewCell _Dg_Cell;
            foreach (DataGridViewRow _Dg_Row in _Frm_Guia._Dg_Detalle.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Factura"].Value).Trim() == _P_Str_Factura.Trim())
                {
                    _Dg_Cell = _Dg_Row.Cells["Boton"];
                    _Frm_Guia._Dg_Detalle.CurrentCell = _Dg_Cell;
                    break;
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
        private void _Mtd_Guardar(string _P_Str_Factura, string _P_Str_Comp)
        {
            string _Str_Cadena = "";
            if (_Cmb_Estatus.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "FIR")
                {
                    if (_Cmb_Firma.SelectedValue.ToString().Trim() == "1" | (_Cmb_Firma.SelectedValue.ToString().Trim() == "0" & _Cmb_Motivo.SelectedIndex > 0 & _Txt_Ob.Text.Trim().Length > 0))
                    {
                        if (!_Mtd_EstatusPagValido(_Txt_Guia.Text, _P_Str_Factura, _P_Str_Comp, false))
                        {
                            MessageBox.Show("No se puede colocar el estatus elegido a la factura. El cliente tiene facturas pagadas en esta guía que son cobro contra camión. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (_Cmb_Firma.SelectedValue.ToString().Trim() == "1")
                        { _Str_Cadena = "Update TGUIADESPACHOD set c_estatus='FIR',c_entregacliente='1',c_tipdevolparcial='1',c_fechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_Fecha.Value) + "',c_motdevolcion=null,c_obervapordevol=null,cnumdocu='0',ctipodocument=null,c_cancelaciontot=0,c_montocobrado=0,csinretencion='0',ccontribuyente='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cfactura='" + _P_Str_Factura + "'"; }
                        else
                        { _Str_Cadena = "Update TGUIADESPACHOD set c_estatus='FIR',c_entregacliente='1',c_motdevolcion='" + _Cmb_Motivo.SelectedValue + "',c_tipdevolparcial='0',c_fechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_Fecha.Value) + "',c_obervapordevol='" + _Txt_Ob.Text.Trim().ToUpper() + "',cnumdocu='0',ctipodocument=null,c_cancelaciontot=0,c_montocobrado=0,csinretencion='0',ccontribuyente='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cfactura='" + _P_Str_Factura + "'"; }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //------------
                        //Al colocar el filtro 'and cestatusfirma=1' se verifica que el campo cmodificado solo se marcara cuando sea el usuario aprobador el que este modificando
                        //ya que el usuario aprobador solo modifica si el campo cestatusfirma es igual a 1.
                        _Str_Cadena = "Update TGUIADESPACHOM set cmodificado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cestatusfirma=1";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //------------
                        //MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_Frm_Guia != null)
                        {
                            _Frm_Guia._Mtd_CargarDetalle(_Txt_Guia.Text);
                            _Mtd_CurrentIndex(_Txt_Factura.Text);
                        }
                        _Txt_Factura.Text = "";
                        if (!_Txt_Factura.Enabled) { this.Close(); }
                    }
                    else
                    {
                        if (_Cmb_Firma.SelectedIndex == 0)
                        { MessageBox.Show("Debe indicar si la firma es total o parcial", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else
                        {
                            if (_Cmb_Motivo.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Motivo, "¡¡¡Información requerida!!!"); _Cmb_Motivo.Focus(); }
                            else
                            { MessageBox.Show("La observación es obligatoria", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                }
                else if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "DEV")
                {
                    if (_Cmb_Motivo.SelectedIndex > 0)
                    {
                        if (_Txt_Ob.Text.Trim().Length > 0)
                        {
                            string _Str_DevueltaParaAnular = "0";
                            if (_Chk_DevueltaParaAnular.Checked) _Str_DevueltaParaAnular = "1";
                            _Str_Cadena = "Update TGUIADESPACHOD set c_devanular = " + _Str_DevueltaParaAnular + ",c_estatus='DEV',c_motdevolcion='" + _Cmb_Motivo.SelectedValue + "',c_obervapordevol='" + _Txt_Ob.Text.Trim().ToUpper() + "',c_entregacliente=0,cnumdocu='0',ctipodocument=null,c_cancelaciontot=0,c_montocobrado=0,c_tipdevolparcial=null,csinretencion='0',ccontribuyente='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cfactura='" + _P_Str_Factura + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            //------------
                            _Str_Cadena = "Update TGUIADESPACHOM set cmodificado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cestatusfirma=1";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            //------------
                            //MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (_Frm_Guia != null)
                            {
                                _Frm_Guia._Mtd_CargarDetalle(_Txt_Guia.Text);
                                _Mtd_CurrentIndex(_Txt_Factura.Text);
                            }
                            _Txt_Factura.Text = "";
                            if (!_Txt_Factura.Enabled) { this.Close(); }
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar la observación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            _Txt_Ob.Focus();
                        }

                    }
                    else
                    {
                        _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!");
                    }
                }
                else
                {
                    //---------------------------------------------------------------------------------------
                    if ((_Cmb_Tipo.SelectedValue.ToString().Trim() == "1" || _Cmb_Tipo.SelectedValue.ToString().Trim() == "2") || (_Cmb_Tipo.SelectedValue.ToString().Trim() == "0" && _Cmb_Motivo.SelectedIndex > 0 && _Txt_Ob.Text.Trim().Length > 0))
                    {
                        //----------------
                        var _Bol_MarcaContribuyente = _Mtd_MarcarContribuyenteEspecial(_Txt_Factura.Text, _Str_Comp_Temp);
                        //----------------
                        if (_Bol_MarcaContribuyente && !_Chk_SinRetencion.Checked)
                        {
                            if (new Frm_MessageBox("¿Esta usted seguro que cuenta con la retención de este pago?", "Advertencia", SystemIcons.Warning, 6).ShowDialog() == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        //----------------
                        //La siguiente línea indica que el estatus que le estan colocando a la factura no es cobro contra camión
                        //if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "2" || (_Cmb_Tipo.SelectedValue.ToString().Trim() == "0" && _Chk_ErrorEnCheque.Checked) || (_Bol_MarcaContribuyente && _Chk_SinRetencion.Checked))
                        if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "2" || (_Cmb_Tipo.SelectedValue.ToString().Trim() == "0" && _Chk_ErrorEnCheque.Checked) || (_Bol_MarcaContribuyente && _Chk_SinRetencion.Checked))
                        {//La factura no es cobro contra camión

                            //if (!(_Cmb_Tipo.SelectedValue.ToString().Trim() == "0" && _Chk_ErrorEnCheque.Checked))
                                if (!_Mtd_EstatusPagValido(_Txt_Guia.Text, _P_Str_Factura, _P_Str_Comp, false))
                                {
                                    MessageBox.Show("No se puede colocar el estatus elegido a la factura. El cliente tiene facturas pagadas en esta guía que son cobro contra camión. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else if (_Frm_Guia == null)
                                {
                                    //Se vuelve a hacer esta verificación para mayor seguridad.
                                    if (_Mtd_EstatusPuedeSerEditado(_Txt_Guia.Text.Trim(), _P_Str_Factura, _P_Str_Comp))
                                    {
                                        _Str_Cadena = "DELETE FROM TTRCDOCUMENTO WHERE ccompany='" + _P_Str_Comp + "' AND cguia='" + _Txt_Guia.Text + "' AND cfactura='" + _P_Str_Factura + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                        }
                        else
                        {//La factura es cobro contra camión
                            //if (!(_Cmb_Tipo.SelectedValue.ToString().Trim() == "0" && !_Chk_ErrorEnCheque.Checked))
                                if (!_Mtd_EstatusPagValido(_Txt_Guia.Text, _P_Str_Factura, _P_Str_Comp, true))
                                {
                                    MessageBox.Show("No se puede colocar el estatus elegido a la factura. El cliente tiene facturas pagadas en esta guía que no son cobro contra camión. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                        }
                        //----------------
                        if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "1")
                        {
                            _Str_Cadena = "Update TGUIADESPACHOD set c_estatus='PAG',c_entregacliente='1',c_cancelaciontot='1',c_montocobrado=0,c_fechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaP.Value) + "',cnumdocu='0',ctipodocument=null,c_tipdevolparcial=null,csinretencion='" + Convert.ToInt32(_Chk_SinRetencion.Checked) + "',ccontribuyente='" + Convert.ToInt32(_Bol_MarcaContribuyente) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cfactura='" + _P_Str_Factura + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "2")
                        {
                            _Str_Cadena = "Update TGUIADESPACHOD set c_estatus='PAG',c_entregacliente='1',c_cancelaciontot='2',c_montocobrado=0,c_fechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaP.Value) + "',cnumdocu='0',ctipodocument=null,c_tipdevolparcial=null,csinretencion='" + Convert.ToInt32(_Chk_SinRetencion.Checked) + "',ccontribuyente='" + Convert.ToInt32(_Bol_MarcaContribuyente) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cfactura='" + _P_Str_Factura + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {
                            _Str_Cadena = "Update TGUIADESPACHOD set c_estatus='PAG',c_entregacliente='1',c_cancelaciontot='" + (_Chk_ErrorEnCheque.Checked ? "3" : "0") + "',c_montocobrado=0,c_fechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtm_FechaP.Value) + "',cnumdocu='0',ctipodocument=null,c_tipdevolparcial=null,c_motdevolcion='" + _Cmb_Motivo.SelectedValue + "',c_obervapordevol='" + _Txt_Ob.Text.Trim().ToUpper() + "',csinretencion='" + Convert.ToInt32(_Chk_SinRetencion.Checked) + "',ccontribuyente='" + Convert.ToInt32(_Bol_MarcaContribuyente) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _P_Str_Comp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cfactura='" + _P_Str_Factura + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            if (_Chk_ErrorEnCheque.Checked)
                            {//Si se esta marcando como error en cheque todas las pagadas parciales del mismo cliente y compañía deben marcarse como error en cheque
                                //y las demas del mismo cliente y compañía que no sean pagadas parciales eliminarles el estatus para que lo vuelvan a cargar.
                                string _Str_Cliente = _Mtd_ObtenerClienteId(_P_Str_Factura, _P_Str_Comp);
                                if (!string.IsNullOrEmpty(_Str_Cliente))
                                {
                                    //se marcan con error en cheque todas las pagadas parciales
                                    _Str_Cadena = "UPDATE TGUIADESPACHOD SET c_cancelaciontot='3' FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp=TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany=TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura=TFACTURAM.cfactura WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TGUIADESPACHOD.ccompany='" + _P_Str_Comp + "' and TGUIADESPACHOD.cguiadesp='" + _Txt_Guia.Text + "' and TFACTURAM.ccliente='" + _Str_Cliente + "' and TGUIADESPACHOD.c_estatus='PAG' and TGUIADESPACHOD.c_cancelaciontot='0'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    //se elimina el estatus a las que no sean pagadas parciales.
                                    _Str_Cadena = "UPDATE TGUIADESPACHOD SET c_estatus=null,c_entregacliente='0',c_tipdevolparcial=null,c_fechaentrega=null,c_motdevolcion=null,c_obervapordevol=null,cnumdocu='0',ctipodocument=null,c_cancelaciontot=0,c_montocobrado=0,csinretencion='0',ccontribuyente=null FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp=TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany=TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura=TFACTURAM.cfactura WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TGUIADESPACHOD.ccompany='" + _P_Str_Comp + "' and TGUIADESPACHOD.cguiadesp='" + _Txt_Guia.Text + "' and TFACTURAM.ccliente='" + _Str_Cliente + "' and NOT(TGUIADESPACHOD.c_estatus='PAG' and (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                                else
                                {
                                    MessageBox.Show("Error en la operación. No se obtuvo el cliente de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {//Si se esta desmarcando error en cheque todas las pagadas parciales del mismo cliente y compañía que sean error en cheque se les debe desmarcar el error en cheque
                                //y las demas del mismo cliente y compañía que no sean pagadas parciales eliminarles el estatus para que lo vuelvan a cargar.
                                string _Str_Cliente = _Mtd_ObtenerClienteId(_P_Str_Factura, _P_Str_Comp);
                                if (!string.IsNullOrEmpty(_Str_Cliente))
                                {
                                    //se desmarca el error en cheque todas las pagadas parciales
                                    _Str_Cadena = "UPDATE TGUIADESPACHOD SET c_cancelaciontot='0' FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp=TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany=TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura=TFACTURAM.cfactura WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TGUIADESPACHOD.ccompany='" + _P_Str_Comp + "' and TGUIADESPACHOD.cguiadesp='" + _Txt_Guia.Text + "' and TFACTURAM.ccliente='" + _Str_Cliente + "' and TGUIADESPACHOD.c_estatus='PAG' and TGUIADESPACHOD.c_cancelaciontot='3'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    //se elimina el estatus a las que no sean pagadas parciales.
                                    _Str_Cadena = "UPDATE TGUIADESPACHOD SET c_estatus=null,c_entregacliente='0',c_tipdevolparcial=null,c_fechaentrega=null,c_motdevolcion=null,c_obervapordevol=null,cnumdocu='0',ctipodocument=null,c_cancelaciontot=0,c_montocobrado=0,csinretencion='0',ccontribuyente=null FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp=TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany=TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura=TFACTURAM.cfactura WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TGUIADESPACHOD.ccompany='" + _P_Str_Comp + "' and TGUIADESPACHOD.cguiadesp='" + _Txt_Guia.Text + "' and TFACTURAM.ccliente='" + _Str_Cliente + "' and NOT(TGUIADESPACHOD.c_estatus='PAG' and (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                }
                                else
                                {
                                    MessageBox.Show("Error en la operación. No se obtuvo el cliente de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        
                        //------------
                        _Str_Cadena = "Update TGUIADESPACHOM set cmodificado='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text + "' and cestatusfirma=1";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        //------------
                        if (_Frm_Guia != null)
                        {
                            _Frm_Guia._Mtd_CargarDetalle(_Txt_Guia.Text);
                            _Mtd_CurrentIndex(_Txt_Factura.Text);
                        }
                        else
                        {
                            MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _Txt_Factura.Text = "";
                        if (!_Txt_Factura.Enabled) { this.Close(); }
                        //----------------
                    }
                    else
                    {
                        if (_Cmb_Tipo.SelectedIndex == 0)
                        { MessageBox.Show("Debe especificar si la cancelación sera total o parcial", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else
                        {
                            if (_Cmb_Motivo.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Motivo, "¡¡¡Información requerida!!!"); _Cmb_Motivo.Focus(); }
                            else
                            { MessageBox.Show("La observación es obligatoria", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar esta operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Mtd_EliminarEstatus(string _P_Str_Factura, string _P_Str_Comp)
        {
            string _Str_Cadena = "UPDATE TGUIADESPACHOD SET c_estatus=null,c_entregacliente='0',c_tipdevolparcial=null,c_fechaentrega=null,c_motdevolcion=null,c_obervapordevol=null,cnumdocu='0',ctipodocument=null,c_cancelaciontot=0,c_montocobrado=0,csinretencion='0',ccontribuyente=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cguiadesp='" + _Txt_Guia.Text + "' AND cfactura='" + _P_Str_Factura + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //------------
            _Frm_Guia._Mtd_CargarDetalle(_Txt_Guia.Text);
            _Mtd_CurrentIndex(_Txt_Factura.Text);
            this.Close();
            //------------
        }

        private void _Mtd_Ini()
        {
            _Pnl_Segundo.Visible = false;
            _Pnl_Tercero.Visible = false;
            _Pnl_Cuarto.Visible = false;
            _Bt_Aceptar.Enabled = false;
            _Txt_Cliente.Text = "";
            _Txt_Ob.Text = "";
            _Str_EstatusTemp = "";
            _Str_FirmaTemp = "";
            _Str_MotivoTemp = "";
            _Str_TipoTemp = "";
            _Mtd_Cargar_Estatus();
            _Mtd_Cargar_Firma();
            _Mtd_Cargar_Motivo();
            _Mtd_Cargar_Tipo();
            _Cmb_Estatus.Enabled = false;
            _Chk_ErrorEnCheque.Checked = false;
            _Chk_ErrorEnCheque.Enabled = false;
            _Txt_TipoCliente.Text = "";
            _Txt_TipoCliente.BackColor = SystemColors.ButtonFace;
            _Er_Error.Dispose();
        }

        private bool _Mtd_VerificarDevolucion(string _P_Str_Factura, string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT TDEVVENTAM.cfactura FROM TDEVVENTAM INNER JOIN TFACTURAM ON TDEVVENTAM.cgroupcomp=TFACTURAM.cgroupcomp AND TDEVVENTAM.ccompany=TFACTURAM.ccompany AND TDEVVENTAM.cfactura=TFACTURAM.cfactura WHERE TDEVVENTAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TDEVVENTAM.ccompany='" + _P_Str_Comp + "' AND TDEVVENTAM.cfactura='" + _P_Str_Factura + "' AND canuladan<>'1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        string _Str_Comp_Temp = "";
        private void _Mtd_Igualar(string _P_Str_Guia, string _P_Str_Factura, string _P_Str_Comp)
        {
            _Str_Comp_Temp = _P_Str_Comp;
            bool _Bol_Parcial = false;
            _Er_Error.Dispose();
            string _Str_Cadena = "SELECT c_estatus,c_motdevolcion,c_obervapordevol,c_tipdevolparcial,c_fechaentrega,c_cancelaciontot,dbo.Fnc_Formatear(c_montocobrado) as c_montocobrado,cnumdocu, c_devanular,csinretencion FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cguiadesp='" + _P_Str_Guia + "' AND cfactura='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Mtd_Cliente(_P_Str_Factura, _P_Str_Comp);
                this.Height = _Pnl_Primero.Height + 27;
                _Cmb_Estatus.Enabled = true;
                _Cmb_Estatus.Focus();
                if (_Ds.Tables[0].Rows[0]["c_estatus"].ToString().Trim() == "FIR")
                {
                    _Cmb_Estatus.SelectedValue = "FIR";
                    _Str_EstatusTemp = "FIR";
                    _Cmb_Firma.Enabled = true;
                    _Cmb_Firma.Focus();
                    if (_Ds.Tables[0].Rows[0]["c_tipdevolparcial"].ToString() == "1")
                    {
                        _Cmb_Firma.SelectedValue = "1";
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height; _Pnl_Segundo.Visible = true;
                        _Dtm_Fecha.Enabled = true;
                        _Dtm_Fecha.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fechaentrega"]);
                    }
                    else
                    {
                        _Bol_Parcial = true;
                        _Cmb_Firma.SelectedValue = "0";
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height; _Pnl_Segundo.Visible = true; _Pnl_Tercero.Visible = true;
                        _Dtm_Fecha.Enabled = true;
                        _Dtm_Fecha.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fechaentrega"]);
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["c_motdevolcion"].ToString().Trim();
                        _Txt_Ob.Enabled = true;
                        _Txt_Ob.Text = _Ds.Tables[0].Rows[0]["c_obervapordevol"].ToString().Trim();
                        //-------------------------
                        if (_Mtd_VerificarDevolucion(_P_Str_Factura, _P_Str_Comp))
                        {
                            _Cmb_Estatus.SelectedIndexChanged -= new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                            _Mtd_Cargar_EstatusDevParcial("FIR");
                            _Cmb_Estatus.SelectedIndexChanged += new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                            _Bt_EliminarEstatus.Enabled = false;
                            _Cmb_Firma.SelectedIndexChanged -= new EventHandler(_Cmb_Firma_SelectedIndexChanged);
                            _Mtd_Cargar_FirmaDevParcial();
                            _Cmb_Firma.SelectedIndexChanged += new EventHandler(_Cmb_Firma_SelectedIndexChanged);
                            _Cmb_Tipo.SelectedIndexChanged -= new EventHandler(_Cmb_Tipo_SelectedIndexChanged);
                            _Mtd_Cargar_TipoDevParcial();
                            _Cmb_Tipo.SelectedIndexChanged += new EventHandler(_Cmb_Tipo_SelectedIndexChanged);
                        }
                    }
                }
                else if (_Ds.Tables[0].Rows[0]["c_estatus"].ToString().Trim() == "DEV")
                {
                    this.Height = _Pnl_Primero.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height; _Pnl_Tercero.Visible = true;
                    _Cmb_Estatus.SelectedValue = "DEV";
                    _Cmb_Motivo.Enabled = true;
                    _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["c_motdevolcion"].ToString().Trim();
                    _Txt_Ob.Enabled = true;
                    _Txt_Ob.Text = _Ds.Tables[0].Rows[0]["c_obervapordevol"].ToString().Trim();
                    if (_Ds.Tables[0].Rows[0]["c_devanular"].ToString().Trim() == "1") _Chk_DevueltaParaAnular.Checked = true; else _Chk_DevueltaParaAnular.Checked = false;
                }
                else if (_Ds.Tables[0].Rows[0]["c_estatus"].ToString().Trim() == "PAG")
                {
                    this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height; _Pnl_Cuarto.Visible = true;
                    _Cmb_Estatus.SelectedValue = "PAG";
                    _Cmb_Tipo.Enabled = true;
                    _Mtd_MostrarChkSinRetencion(_P_Str_Factura, _P_Str_Comp);
                    _Chk_SinRetencion.Checked = _Ds.Tables[0].Rows[0]["csinretencion"].ToString().Trim() == "1";
                    _Dtm_FechaP.Enabled = true;
                    _Dtm_FechaP.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fechaentrega"]);
                    if (_Ds.Tables[0].Rows[0]["c_cancelaciontot"].ToString() == "1" || _Ds.Tables[0].Rows[0]["c_cancelaciontot"].ToString() == "2")
                    {
                        _Cmb_Tipo.SelectedValue = _Ds.Tables[0].Rows[0]["c_cancelaciontot"].ToString();
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height; _Pnl_Cuarto.Visible = true;
                    }
                    else
                    {
                        _Bol_Parcial = true;
                        _Cmb_Tipo.SelectedValue = "0";
                        _Chk_ErrorEnCheque.Checked = _Ds.Tables[0].Rows[0]["c_cancelaciontot"].ToString() == "3";
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height; _Pnl_Cuarto.Visible = true; _Pnl_Tercero.Visible = true;
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["c_motdevolcion"].ToString().Trim();
                        _Txt_Ob.Enabled = true;
                        _Txt_Ob.Text = _Ds.Tables[0].Rows[0]["c_obervapordevol"].ToString().Trim();
                        //-------------------------
                        if (_Mtd_VerificarDevolucion(_P_Str_Factura, _P_Str_Comp))
                        {
                            _Cmb_Estatus.SelectedIndexChanged -= new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                            _Mtd_Cargar_EstatusDevParcial("PAG");
                            _Cmb_Estatus.SelectedIndexChanged += new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                            _Bt_EliminarEstatus.Enabled = false;
                            _Cmb_Firma.SelectedIndexChanged -= new EventHandler(_Cmb_Firma_SelectedIndexChanged);
                            _Mtd_Cargar_FirmaDevParcial();
                            _Cmb_Firma.SelectedIndexChanged += new EventHandler(_Cmb_Firma_SelectedIndexChanged);
                            _Cmb_Tipo.SelectedIndexChanged -= new EventHandler(_Cmb_Tipo_SelectedIndexChanged);
                            _Mtd_Cargar_TipoDevParcial();
                            _Cmb_Tipo.SelectedIndexChanged += new EventHandler(_Cmb_Tipo_SelectedIndexChanged);
                        }
                    }
                }
                else
                {
                    this.Height = _Pnl_Primero.Height + 27 + _Bt_Aceptar.Height;
                }
                //if (_Bol_Parcial && _Mtd_VerificarDevolucion(_P_Str_Factura, _P_Str_Comp))
                //{
                //    _Bt_Aceptar.Enabled = true;
                //    _Cmb_Motivo.Enabled = false;
                //    _Txt_Ob.Enabled = false;
                //    _Cmb_Estatus.Enabled = false;
                //    _Cmb_Firma.Enabled = false;
                //    _Cmb_Tipo.Enabled = false;
                //    _Dtm_FechaP.Enabled = false;
                //    MessageBox.Show("No se podrá cambiar el estatus porque el documento seleccionado tiene devoluciones en venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //}
                //else
                //{ _Bt_Aceptar.Enabled = true; }
                _Bt_Aceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("La factura que introdujo no pertenece a la guía", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bt_Aceptar.Enabled = false;
                _Txt_Factura.Text = "";
                _Txt_Factura.Focus();
            }
        }
    
        public DataSet _Mtd_DsFirma()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("cfirma");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cfirma"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cfirma"] = "1";
            _DRow_["cname"] = "TOTAL";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cfirma"] = "0";
            _DRow_["cname"] = "PARCIAL";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;
        }
        public DataSet _Mtd_DsFirmaDevParial()
        {
             DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("cfirma");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cfirma"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cfirma"] = "0";
            _DRow_["cname"] = "PARCIAL";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;
        }
        public DataSet _Mtd_DsTipo()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("ctipo");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctipo"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctipo"] = "1";
            _DRow_["cname"] = "TOTAL";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            if (_Frm_Guia != null)
            {
                _DRow_ = _Ds_.Tables[0].NewRow();
                _DRow_["ctipo"] = "0";
                _DRow_["cname"] = "CON DEVOLUCIÓN";
                _Ds_.Tables[0].Rows.Add(_DRow_);
            }
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctipo"] = "2";
            _DRow_["cname"] = "ERROR EN CHEQUE";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;
        }
        public DataSet _Mtd_DsTipoDevParial()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("ctipo");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctipo"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            if (_Frm_Guia != null)
            {
                _DRow_ = _Ds_.Tables[0].NewRow();
                _DRow_["ctipo"] = "0";
                _DRow_["cname"] = "CON DEVOLUCIÓN";
                _Ds_.Tables[0].Rows.Add(_DRow_);
            }
            return _Ds_;
        }
        public DataSet _Mtd_DsPago()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("ctpago");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctpago"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctpago"] = "EFEC";
            _DRow_["cname"] = "EFECTIVO";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["ctpago"] = "CHEQ";
            _DRow_["cname"] = "CHEQUE";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;
        }
        public DataSet _Mtd_DsEstatus()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("cestatus");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cestatus"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            if (_Frm_Guia != null)
            {
                _DRow_ = _Ds_.Tables[0].NewRow();
                _DRow_["cestatus"] = "FIR";
                _DRow_["cname"] = "FIRMADA";
                _Ds_.Tables[0].Rows.Add(_DRow_);
                _DRow_ = _Ds_.Tables[0].NewRow();
                _DRow_["cestatus"] = "DEV";
                _DRow_["cname"] = "DEVUELTA";
                _Ds_.Tables[0].Rows.Add(_DRow_);
            }
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cestatus"] = "PAG";
            _DRow_["cname"] = "PAGADA";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;

        }
        public DataSet _Mtd_DsEstatusDevParial()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("cestatus");
            _Ds_.Tables[0].Columns.Add("cname");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cestatus"] = "nulo";
            _DRow_["cname"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            if (_Frm_Guia != null)
            {
                _DRow_ = _Ds_.Tables[0].NewRow();
                _DRow_["cestatus"] = "FIR";
                _DRow_["cname"] = "FIRMADA";
                _Ds_.Tables[0].Rows.Add(_DRow_);
            }
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["cestatus"] = "PAG";
            _DRow_["cname"] = "PAGADA";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;

        }
        private void _Mtd_Cargar_Estatus()
        {
            _Cmb_Estatus.DataSource = null;
            _Cmb_Estatus.DataSource = _Mtd_DsEstatus().Tables[0];
            _Cmb_Estatus.DisplayMember = "cname";
            _Cmb_Estatus.ValueMember = "cestatus";
            _Cmb_Estatus.SelectedValue = "nulo";
        }
        private void _Mtd_Cargar_EstatusDevParcial(string _P_Str_Value)
        {
            _Cmb_Estatus.DataSource = null;
            _Cmb_Estatus.DataSource = _Mtd_DsEstatusDevParial().Tables[0];
            _Cmb_Estatus.DisplayMember = "cname";
            _Cmb_Estatus.ValueMember = "cestatus";
            _Cmb_Estatus.SelectedValue = _P_Str_Value;
        }
        private void _Mtd_Cargar_Firma()
        {
            _Cmb_Firma.DataSource = null;
            _Cmb_Firma.DataSource = _Mtd_DsFirma().Tables[0];
            _Cmb_Firma.DisplayMember = "cname";
            _Cmb_Firma.ValueMember = "cfirma";
            _Cmb_Firma.SelectedValue = "nulo";
        }
        private void _Mtd_Cargar_FirmaDevParcial()
        {
            _Cmb_Firma.DataSource = null;
            _Cmb_Firma.DataSource = _Mtd_DsFirmaDevParial().Tables[0];
            _Cmb_Firma.DisplayMember = "cname";
            _Cmb_Firma.ValueMember = "cfirma";
            _Cmb_Firma.SelectedValue = "0";
        }
        private void _Mtd_Cargar_Tipo()
        {
            _Cmb_Tipo.DataSource = null;
            _Cmb_Tipo.DataSource = _Mtd_DsTipo().Tables[0];
            _Cmb_Tipo.DisplayMember = "cname";
            _Cmb_Tipo.ValueMember = "ctipo";
            _Cmb_Tipo.SelectedValue = "nulo";
        }
        private void _Mtd_Cargar_TipoDevParcial()
        {
            _Cmb_Tipo.DataSource = null;
            _Cmb_Tipo.DataSource = _Mtd_DsTipoDevParial().Tables[0];
            _Cmb_Tipo.DisplayMember = "cname";
            _Cmb_Tipo.ValueMember = "ctipo";
            _Cmb_Tipo.SelectedValue = "0";
        }
        private void _Mtd_Cargar_Motivo()
        {
            string _Str_Cadena = "SELECT cidmotivo,cdescripcion FROM TMOTIVO where cmotidevfact='1' and cmotivodev='1' and cmotianulfact='1' ORDER BY cconcepto ASC";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Motivo, _Str_Cadena);
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Mtd_MostrarChkSinRetencion(string _P_Str_Factura, string _P_Str_Comp)
        {
            string _Str_Cadena = "Select TFACTURAM.ccliente FROM TFACTURAM INNER JOIN TCLIENTE ON TCLIENTE.cgroupcomp=TFACTURAM.cgroupcomp AND TCLIENTE.ccliente=TFACTURAM.ccliente WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TFACTURAM.ccompany='" + _P_Str_Comp + "' and TFACTURAM.cfactura='" + _P_Str_Factura + "' and TFACTURAM.c_impuesto_bs>0 and TCLIENTE.c_tip_contribuy='2'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Chk_SinRetencion.Visible = _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_MarcarContribuyenteEspecial(string _P_Str_Factura, string _P_Str_Comp)
        {
            string _Str_Cadena = "Select TFACTURAM.ccliente FROM TFACTURAM INNER JOIN TCLIENTE ON TCLIENTE.cgroupcomp=TFACTURAM.cgroupcomp AND TCLIENTE.ccliente=TFACTURAM.ccliente WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TFACTURAM.ccompany='" + _P_Str_Comp + "' and TFACTURAM.cfactura='" + _P_Str_Factura + "' and TFACTURAM.c_impuesto_bs>0 and TCLIENTE.c_tip_contribuy='2'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private string _Mtd_ObtenerClienteId(string _P_Str_Factura, string _P_Str_Comp)
        {
            var _Str_Cadena = "SELECT ccliente FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND TFACTURAM.cfactura='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
                return _Ds.Tables[0].Rows[0][0].ToString();
            return "";
        }
        /// <summary>
        /// Determina si se le puede colocar un estatus a una factura haciendo la siguiente verificación:
        /// La guía seleccionada no puede tener facturas de una misma compañía y un mismo cliente 
        /// que vayan unas para cobro contra camión y otras no.
        /// </summary>
        /// <param name="_P_Str_Guia">Guía</param>
        /// <param name="_P_Str_Factura">Factura</param>
        /// <param name="_P_Str_Comp">Compañía</param>
        /// <param name="_P_Bol_EstatusCobroContraCamion">Si se le quiere colocar el estatus de cobro contra camión</param>
        private bool _Mtd_EstatusPagValido(string _P_Str_Guia, string _P_Str_Factura, string _P_Str_Comp, bool _P_Bol_EstatusCobroContraCamion)
        {
            var _Str_Cadena = "SELECT ccliente FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND TFACTURAM.cfactura='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                var _Str_ClienteId = _Ds.Tables[0].Rows[0][0].ToString();
                if (_P_Bol_EstatusCobroContraCamion)
                {
                    //Facturas del cliente que no son cobro contra camión
                    _Str_Cadena = "SELECT TGUIADESPACHOD.cfactura FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp=TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany=TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura=TFACTURAM.cfactura INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp=TCLIENTE.cgroupcomp AND TFACTURAM.ccliente=TCLIENTE.ccliente WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOD.ccompany='" + _P_Str_Comp + "' AND TGUIADESPACHOD.cguiadesp='" + _P_Str_Guia + "' AND TFACTURAM.ccliente='" + _Str_ClienteId + "' AND TGUIADESPACHOD.cfactura<>'" + _P_Str_Factura + "' AND (TGUIADESPACHOD.c_estatus='FIR' OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='2' OR TGUIADESPACHOD.c_cancelaciontot='3' OR (TCLIENTE.c_tip_contribuy='2' AND TGUIADESPACHOD.csinretencion='1'))))";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    return _Ds.Tables[0].Rows.Count == 0;//Si no hay registros el estatus es válido y se puede colocar
                }
                else
                {
                    //Facturas del cliente que son cobro contra camión
                    _Str_Cadena = "SELECT TGUIADESPACHOD.cfactura FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp=TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany=TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura=TFACTURAM.cfactura INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp=TCLIENTE.cgroupcomp AND TFACTURAM.ccliente=TCLIENTE.ccliente WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOD.ccompany='" + _P_Str_Comp + "' AND TGUIADESPACHOD.cguiadesp='" + _P_Str_Guia + "' AND TFACTURAM.ccliente='" + _Str_ClienteId + "' AND TGUIADESPACHOD.cfactura<>'" + _P_Str_Factura + "' AND TGUIADESPACHOD.c_estatus<>'DEV' AND NOT(TGUIADESPACHOD.c_estatus='FIR' OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='2'  OR TGUIADESPACHOD.c_cancelaciontot='3' OR (TCLIENTE.c_tip_contribuy='2' AND TGUIADESPACHOD.csinretencion='1'))))";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    return _Ds.Tables[0].Rows.Count == 0;//Si no hay registros el estatus es válido y se puede colocar
                }
            }
            return true;
        }

        private bool _Mtd_VerificarVariasComp(string _P_Str_Guia, string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT ccompany FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _P_Str_Guia + "' AND cfactura='" + _P_Str_Factura + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 1;
        }
        private string _Mtd_RetornarComp(string _P_Str_Guia, string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT ccompany FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _P_Str_Guia + "' AND cfactura='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 1)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }

        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }

        private bool _Mtd_VerificarFecha(string _P_Str_Factura, string _Str_CompaniaFact, DateTime pFecha)
        {
            string _Str_Cadena = "SELECT CONVERT(VARCHAR,c_fecha_factura,103) FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Str_CompaniaFact + "' AND cfactura='" + _P_Str_Factura + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_factura,103))>CONVERT(DATETIME,CONVERT(VARCHAR,'" + _Cls_Formato._Mtd_fecha(pFecha) + "',103))";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// Retorna 1 si la guía no existe, 2 si la guía no esta liquidada y 3 si la guía esta cobrada.
        /// </summary>
        /// <param name="_P_Str_Guia">Número de la guía</param>
        private int _Mtd_VerificacionGuia(string _P_Str_Guia)
        {
            string _Str_Cadena = "SELECT cliqguidespacho,cguiacobrada FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _P_Str_Guia + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
                return 1;
            else if (Convert.ToString(_Ds.Tables[0].Rows[0]["cliqguidespacho"]).Trim() != "1")
                return 2;
            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cguiacobrada"]).Trim() == "1")
                return 3;
            return 0;
        }

        public void _Mtd_IntroducirNumeroGuia()
        {
        _Lbl_Reintentar:
            var _Frm_Input = InputBox.Show("Introduzca el número de guía:", "Edición de Estatus por Guía");
            if (_Frm_Input.ReturnCode == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(_Frm_Input.Text))
                {
                    MessageBox.Show("Debe ingresar el número de la guía.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto _Lbl_Reintentar;
                }
                var _Int_VerificacionGuia = _Mtd_VerificacionGuia(_Frm_Input.Text.Trim());
                if (_Int_VerificacionGuia == 1)
                {
                    MessageBox.Show("La guía que introdujo no existe. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto _Lbl_Reintentar;
                }
                else if (_Int_VerificacionGuia == 2)
                {
                    MessageBox.Show("La guía no ha sido liquidada, por lo tanto no puede realizar cambios en ella.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (_Int_VerificacionGuia == 3)
                {
                    MessageBox.Show("La guía ha sido cobrada, por lo tanto no puede realizar cambios en ella.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                this.Text = "Edición de Estatus de la Guía #" + _Frm_Input.Text.Trim();
                _Txt_Guia.Text = _Frm_Input.Text.Trim();
                _Txt_Factura.Focus();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Verifica si la factura puede ser editada. La factura puede ser editada solo si es pagada y sin devoluciones.
        /// </summary>
        /// <param name="_P_Str_Guia">Guía</param>
        /// <param name="_P_Str_Factura">Factura</param>
        /// <param name="_P_Str_Comp">Compañía</param>
        /// <returns>Bool</returns>
        private bool _Mtd_EstatusPuedeSerEditado(string _P_Str_Guia, string _P_Str_Factura, string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT cfactura FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cguiadesp='" + _P_Str_Guia + "' AND cfactura='" + _P_Str_Factura + "' AND c_estatus='PAG' AND c_cancelaciontot<>'0' AND c_cancelaciontot<>'3'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El estatus de la factura ingresada no puede ser editado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Str_Cadena = "SELECT cfactura FROM TTRCDOCUMENTO WHERE ccompany='" + _P_Str_Comp + "' AND cguia='" + _P_Str_Guia + "' AND cfactura='" + _P_Str_Factura + "' AND (cmontonotacredito>0 OR cmontoretencion>0 OR cmontocobradocheque>0 OR cmontocobradoefectivo>0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("La factura ingresada tiene cobros aplicados en cobro contra camión. Debe eliminar esos cobros para porder cambiar el estatus.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Frm_GuiaManual_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void _Txt_Factura_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 0);
            if (e.KeyChar == (char)13)
            {
                if (_Txt_Factura.Text.Trim().Length > 0)
                {
                    _Bt_Buscar.Enabled = true;
                    _Bt_Buscar.Focus();
                }
                else
                {
                    _Er_Error.SetError(_Txt_Factura, "Información Requerida!!!");
                }
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Txt_Factura.Text.Trim().Length > 0)
            {
                _Mtd_Ini();
                if (_Mtd_VerificarVariasComp(_Txt_Guia.Text.Trim(), _Txt_Factura.Text.Trim()))
                {
                    _Mtd_CargarComp(_Txt_Guia.Text.Trim(), _Txt_Factura.Text.Trim());
                    _Pnl_Comp.Visible = true;
                }
                else
                {
                    string _Str_Comp = _Mtd_RetornarComp(_Txt_Guia.Text.Trim(), _Txt_Factura.Text.Trim());
                    if (_Str_Comp.Trim().Length > 0)
                    {
                        if (_Frm_Guia == null && !_Mtd_EstatusPuedeSerEditado(_Txt_Guia.Text.Trim(), _Txt_Factura.Text, _Str_Comp))
                        {
                            _Bt_Aceptar.Enabled = false;
                            _Txt_Factura.Text = "";
                            _Txt_Factura.Focus();
                            return;
                        }
                        _Mtd_Igualar(_Txt_Guia.Text.Trim(), _Txt_Factura.Text, _Str_Comp);
                    }
                    else
                    {
                        MessageBox.Show("La factura que introdujo no pertenece a la guía", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bt_Aceptar.Enabled = false;
                        _Txt_Factura.Text = "";
                        _Txt_Factura.Focus();
                    }
                }
            }
            else
            {
                _Er_Error.SetError(_Txt_Factura, "Información Requerida!!!");
            }
        }

        private void _Cmb_Estatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Cmb_Estatus.SelectedIndex > 0)
                {
                    _Er_Error.Dispose();
                    _Pnl_Segundo.Visible = false;
                    _Pnl_Tercero.Visible = false;
                    _Pnl_Cuarto.Visible = false;
                    _Cmb_Motivo.SelectedIndex = 0;
                    _Txt_Ob.Text = "";
                    _Cmb_Tipo.SelectedIndex = 0;
                    _Cmb_Firma.SelectedIndex = 0;
                    _Chk_DevueltaParaAnular.Enabled = false;
                    _Chk_DevueltaParaAnular.Checked = false;
                    _Mtd_MostrarChkSinRetencion(_Txt_Factura.Text, _Str_Comp_Temp);
                    _Chk_SinRetencion.Checked = false;
                    if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "FIR")
                    {
                        _Pnl_Segundo.Visible = true;
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height;
                        _Cmb_Firma.Enabled = true;
                        _Cmb_Firma.Focus();
                    }
                    else if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "DEV")
                    {
                        _Pnl_Tercero.Visible = true;
                        this.Height = _Pnl_Primero.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                        _Chk_DevueltaParaAnular.Enabled = true;
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.Focus();
                    }
                    else
                    {
                        _Pnl_Cuarto.Visible = true;
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height;
                        _Cmb_Tipo.Enabled = true;
                        _Cmb_Tipo.Focus();
                    }
                    _Str_EstatusTemp = _Cmb_Estatus.SelectedValue.ToString().Trim();
                }
                else
                {
                    _Pnl_Segundo.Visible = false;
                    _Pnl_Tercero.Visible = false;
                    _Pnl_Cuarto.Visible = false;
                    this.Height = _Pnl_Primero.Height + 27 + _Bt_Aceptar.Height;
                    _Er_Error.SetError(_Cmb_Estatus, "Información Requerida!!!");
                }
            }
        }

        private void _Txt_Factura_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Factura.Text))
            {
                _Txt_Factura.Text = "";
            }
            _Mtd_Ini();
        }
        string _Str_EstatusTemp = "";
        private void _Cmb_Estatus_DropDownClosed(object sender, EventArgs e)
        {
            if (_Cmb_Estatus.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                if (_Cmb_Estatus.SelectedValue.ToString().Trim() != _Str_EstatusTemp)
                {
                    _Str_EstatusTemp = _Cmb_Estatus.SelectedValue.ToString().Trim();
                    _Pnl_Segundo.Visible = false;
                    _Pnl_Tercero.Visible = false;
                    _Pnl_Cuarto.Visible = false;
                    _Cmb_Motivo.SelectedIndex = 0;
                    _Txt_Ob.Text = "";
                    _Cmb_Tipo.SelectedIndex = 0;
                    _Cmb_Firma.SelectedIndex = 0;
                    _Chk_DevueltaParaAnular.Enabled = false;
                    _Chk_DevueltaParaAnular.Checked = false;
                    _Mtd_MostrarChkSinRetencion(_Txt_Factura.Text, _Str_Comp_Temp);
                    _Chk_SinRetencion.Checked = false;
                    if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "FIR")
                    {
                        _Pnl_Segundo.Visible = true;
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height;
                        _Cmb_Firma.Enabled = true;
                        _Cmb_Firma.Focus();
                    }
                    else if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "DEV")
                    {
                        _Pnl_Tercero.Visible = true;
                        this.Height = _Pnl_Primero.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                        _Chk_DevueltaParaAnular.Enabled = true;
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.Focus();
                    }
                    else
                    {
                        _Pnl_Cuarto.Visible = true;
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height;
                        _Cmb_Tipo.Enabled = true;
                        _Cmb_Tipo.Focus();
                    }
                }
            }
            else
            {
                _Pnl_Segundo.Visible = false;
                _Pnl_Tercero.Visible = false;
                _Pnl_Cuarto.Visible = false;
                this.Height = _Pnl_Primero.Height + 27 + _Bt_Aceptar.Height;
                _Er_Error.SetError(_Cmb_Estatus, "Información Requerida!!!");
            }
        }

        string _Str_MotivoTemp = "";
        private void _Cmb_Motivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Cmb_Motivo.SelectedIndex > 0)
                {
                    _Er_Error.Dispose();
                    _Txt_Ob.Enabled = true;
                    _Txt_Ob.Focus();
                    _Str_MotivoTemp = _Cmb_Motivo.SelectedValue.ToString().Trim();
                }
                else
                {
                    _Txt_Ob.Enabled = false;
                    _Er_Error.SetError(_Cmb_Motivo, "Información Requerida!!!");
                }
            }
        }

        private void _Cmb_Motivo_DropDownClosed(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                if (_Cmb_Motivo.SelectedValue.ToString().Trim() != _Str_MotivoTemp)
                {
                    _Str_MotivoTemp = _Cmb_Motivo.SelectedValue.ToString().Trim();
                    _Txt_Ob.Enabled = true;
                    _Txt_Ob.Focus();
                }
            }
            else
            {
                _Txt_Ob.Enabled = false;
                _Er_Error.SetError(_Cmb_Motivo, "Información Requerida!!!");
            }
        }
        string _Str_FirmaTemp = "";
        private void _Cmb_Firma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Cmb_Firma.SelectedIndex > 0)
                {
                    _Er_Error.Dispose();
                    _Pnl_Tercero.Visible = false;
                    if (_Cmb_Firma.SelectedValue.ToString().Trim() == "1")
                    {
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height;
                        _Dtm_Fecha.Enabled = true;
                        _Dtm_Fecha.Focus();
                    }
                    else
                    {
                        _Pnl_Tercero.Visible = true;
                        _Pnl_Tercero.BringToFront();
                        _Bt_Aceptar.BringToFront();
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                        _Dtm_Fecha.Enabled = true;
                        _Dtm_Fecha.Focus();
                        _Cmb_Motivo.Enabled = true;
                        //_Cmb_Motivo.Focus();
                    }
                    _Str_FirmaTemp = _Cmb_Firma.SelectedValue.ToString().Trim();
                }
                else
                {
                    _Dtm_Fecha.Enabled = false;
                    _Cmb_Motivo.Enabled = false;
                    _Er_Error.SetError(_Cmb_Firma, "Información Requerida!!!");
                }
            }
        }

        private void _Cmb_Firma_DropDownClosed(object sender, EventArgs e)
        {
            if (_Cmb_Firma.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                if (_Cmb_Firma.SelectedValue.ToString().Trim() != _Str_FirmaTemp)
                {
                    _Str_FirmaTemp = _Cmb_Firma.SelectedValue.ToString().Trim();
                    _Pnl_Tercero.Visible = false;
                    if (_Cmb_Firma.SelectedValue.ToString().Trim() == "1")
                    {
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height;
                        _Dtm_Fecha.Enabled = true;
                        _Dtm_Fecha.Focus();
                    }
                    else
                    {
                        _Pnl_Tercero.Visible = true;
                        _Pnl_Tercero.BringToFront();
                        _Bt_Aceptar.BringToFront();
                        this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                        _Dtm_Fecha.Enabled = true;
                        _Cmb_Motivo.Enabled = true;
                        _Dtm_Fecha.Focus();
                        //_Cmb_Motivo.Focus();
                    }
                }
            }
            else
            {
                _Dtm_Fecha.Enabled = false;
                _Cmb_Motivo.Enabled = false;
                _Er_Error.SetError(_Cmb_Firma, "Información Requerida!!!");
            }
        }

        private void _Txt_Ob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Er_Error.Dispose();
                if (_Txt_Ob.Text.Trim().Length > 0)
                { _Bt_Aceptar.Focus(); }
                else
                { _Er_Error.SetError(_Txt_Ob, "Información Requerida!!!"); }
            }
        }

        private void _Dtm_Fecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_Cmb_Motivo.Visible)
                { _Cmb_Motivo.Focus(); }
                else
                { _Bt_Aceptar.Focus(); }
            }
        }
        string _Str_TipoTemp = "";
        private void _Cmb_Tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Chk_ErrorEnCheque.Checked = false;
                _Chk_ErrorEnCheque.Enabled = false;
                if (_Cmb_Tipo.SelectedIndex > 0)
                {
                    _Dtm_FechaP.Enabled = true;
                    //-------------
                    _Pnl_Tercero.Visible = false;
                    if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "1" || _Cmb_Tipo.SelectedValue.ToString().Trim() == "2")
                    {
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height;
                        _Bt_Aceptar.Focus();
                    }
                    else
                    {
                        _Chk_ErrorEnCheque.Enabled = true;
                        _Pnl_Tercero.Visible = true;
                        _Pnl_Tercero.BringToFront();
                        _Bt_Aceptar.BringToFront();
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.Focus();
                    }
                    //-------------
                    _Er_Error.Dispose();
                    _Str_TipoTemp = _Cmb_Tipo.SelectedValue.ToString().Trim();
                }
                else
                {
                    _Dtm_FechaP.Enabled = false;
                    _Er_Error.SetError(_Cmb_Tipo, "Información Requerida!!!");
                }
            }
        }

        private void _Cmb_Tipo_DropDownClosed(object sender, EventArgs e)
        {

            if (_Cmb_Tipo.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                if (_Cmb_Tipo.SelectedValue.ToString().Trim() != _Str_TipoTemp)
                {
                    _Dtm_FechaP.Enabled = true;
                    _Chk_ErrorEnCheque.Checked = false;
                    _Chk_ErrorEnCheque.Enabled = false;
                    //-------------
                    _Pnl_Tercero.Visible = false;
                    if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "1" || _Cmb_Tipo.SelectedValue.ToString().Trim() == "2")
                    {
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height;
                        _Bt_Aceptar.Focus();
                    }
                    else
                    {
                        _Chk_ErrorEnCheque.Enabled = true;
                        _Pnl_Tercero.Visible = true;
                        _Pnl_Tercero.BringToFront();
                        _Bt_Aceptar.BringToFront();
                        this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                        _Cmb_Motivo.Enabled = true;
                        _Cmb_Motivo.Focus();
                    }
                    //-------------
                    _Str_TipoTemp = _Cmb_Tipo.SelectedValue.ToString().Trim();
                }
            }
            else
            {
                _Dtm_FechaP.Enabled = false;
                _Chk_ErrorEnCheque.Checked = false;
                _Chk_ErrorEnCheque.Enabled = false;
                _Er_Error.SetError(_Cmb_Tipo, "Información Requerida!!!");
            }
        }

        private void _Cmb_Estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Estatus.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                _Pnl_Segundo.Visible = false;
                _Pnl_Tercero.Visible = false;
                _Pnl_Cuarto.Visible = false;
                _Cmb_Motivo.SelectedIndex = 0;
                _Txt_Ob.Text = "";
                _Cmb_Tipo.SelectedIndex = 0;
                _Cmb_Firma.SelectedIndex = 0;
                _Chk_DevueltaParaAnular.Enabled = false;
                _Chk_DevueltaParaAnular.Checked = false;
                _Mtd_MostrarChkSinRetencion(_Txt_Factura.Text, _Str_Comp_Temp);
                _Chk_SinRetencion.Checked = false;
                if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "FIR")
                {
                    _Pnl_Segundo.Visible = true;
                    this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height;
                    _Cmb_Firma.Enabled = true;
                }
                else if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "DEV")
                {
                    _Pnl_Tercero.Visible = true;
                    this.Height = _Pnl_Primero.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                    _Chk_DevueltaParaAnular.Enabled = true;
                    _Cmb_Motivo.Enabled = true;
                }
                else
                {
                    _Pnl_Cuarto.Visible = true;
                    this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height;
                    _Cmb_Tipo.Enabled = true;
                }
                _Str_EstatusTemp = _Cmb_Estatus.SelectedValue.ToString().Trim();
            }
            else
            {
                _Pnl_Segundo.Visible = false;
                _Pnl_Tercero.Visible = false;
                _Pnl_Cuarto.Visible = false;
                this.Height = _Pnl_Primero.Height + 27 + _Bt_Aceptar.Height;
                _Er_Error.SetError(_Cmb_Estatus, "Información Requerida!!!");
            }
        }

        private void _Cmb_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Tipo.SelectedIndex > 0)
            {
                _Chk_ErrorEnCheque.Checked = false;
                _Chk_ErrorEnCheque.Enabled = false;
                _Dtm_FechaP.Enabled = true;
                //-------------
                _Pnl_Tercero.Visible = false;
                if (_Cmb_Tipo.SelectedValue.ToString().Trim() == "1" || _Cmb_Tipo.SelectedValue.ToString().Trim() == "2")
                {
                    this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + 27 + _Bt_Aceptar.Height;
                }
                else
                {
                    _Chk_ErrorEnCheque.Enabled = true;
                    _Pnl_Tercero.Visible = true;
                    _Pnl_Tercero.BringToFront();
                    _Bt_Aceptar.BringToFront();
                    this.Height = _Pnl_Primero.Height + _Pnl_Cuarto.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                    _Cmb_Motivo.Enabled = true;
                }
                //-------------
                _Er_Error.Dispose();
                _Str_TipoTemp = _Cmb_Tipo.SelectedValue.ToString().Trim();
            }
            else
            {
                _Dtm_FechaP.Enabled = false;
                _Er_Error.SetError(_Cmb_Tipo, "Información Requerida!!!");
            }
        }

        private void _Cmb_Firma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Firma.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                _Pnl_Tercero.Visible = false;
                if (_Cmb_Firma.SelectedValue.ToString().Trim() == "1")
                {
                    this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + 27 + _Bt_Aceptar.Height;
                    _Dtm_Fecha.Enabled = true;
                }
                else
                {
                    _Pnl_Tercero.Visible = true;
                    _Pnl_Tercero.BringToFront();
                    _Bt_Aceptar.BringToFront();
                    this.Height = _Pnl_Primero.Height + _Pnl_Segundo.Height + _Pnl_Tercero.Height + 27 + _Bt_Aceptar.Height;
                    _Dtm_Fecha.Enabled = true;
                    _Cmb_Motivo.Enabled = true;
                }
                _Str_FirmaTemp = _Cmb_Firma.SelectedValue.ToString().Trim();
            }
            else
            {
                _Dtm_Fecha.Enabled = false;
                _Cmb_Motivo.Enabled = false;
                _Er_Error.SetError(_Cmb_Firma, "Información Requerida!!!");
            }
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            {
                _Er_Error.Dispose();
                _Txt_Ob.Enabled = true;
                _Str_MotivoTemp = _Cmb_Motivo.SelectedValue.ToString().Trim();
            }
            else
            {
                _Txt_Ob.Enabled = false;
                _Er_Error.SetError(_Cmb_Motivo, "Información Requerida!!!");
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Frm_Guia == null)
            {
                _Mtd_Guardar(_Txt_Factura.Text, _Str_Comp_Temp);
                return;
            }
            string _Str_Cadena = "SELECT cestatusfirma FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text + "' AND cestatusfirma='1'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0 & !_Frm_Guia._Bt_Liquidar.Enabled)
            {
                MessageBox.Show("No se puede realizar la operación. Otro usuario a terminado el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                _Frm_Guia.Close();
            }
            else
            {
                if (_Cmb_Estatus.Enabled && _Mtd_VerificarDevolucion(_Txt_Factura.Text, _Str_Comp_Temp))
                {
                    if (_Cmb_Firma.SelectedIndex > 0 && _Cmb_Tipo.SelectedIndex > 0 &&
                        !((_Cmb_Estatus.SelectedValue.ToString().Trim() == "FIR" && _Cmb_Firma.SelectedValue.ToString().Trim() == "0")
                        || (_Cmb_Estatus.SelectedValue.ToString().Trim() == "PAG" && _Cmb_Tipo.SelectedValue.ToString().Trim() == "0")))
                    {
                        MessageBox.Show("No se podrá colocar el estatus elegido porque el documento seleccionado tiene devoluciones en venta. Se cargará nuevamente el formulario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bt_Buscar.PerformClick();
                        return;
                    }
                }
                if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "FIR" & _Mtd_VerificarFecha(_Txt_Factura.Text, _Str_Comp_Temp, _Dtm_Fecha.Value))
                {
                    MessageBox.Show("La fecha de entrega no debe ser menor a la fecha de emisión de la factura", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (_Cmb_Estatus.SelectedValue.ToString().Trim() == "PAG" & _Mtd_VerificarFecha(_Txt_Factura.Text, _Str_Comp_Temp, _Dtm_FechaP.Value))
                {
                    MessageBox.Show("La fecha de entrega no debe ser menor a la fecha de emisión de la factura", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _Str_Cadena = "SELECT cguiadesp FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text + "' AND cfinalizado='1'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                        MessageBox.Show("La guía ha sido liquidada. No se realizarán los cambios efectuados en esta factura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        _Frm_Guia.Close();
                    }
                    else
                    {
                        _Mtd_Guardar(_Txt_Factura.Text, _Str_Comp_Temp);
                    }
                }
            }
        }

        private void _Bt_Aceptar_Comp_Click(object sender, EventArgs e)
        {
            if (_Cmb_Comp.SelectedIndex > 0)
            {
                if (_Frm_Guia == null && !_Mtd_EstatusPuedeSerEditado(_Txt_Guia.Text.Trim(), _Txt_Factura.Text, Convert.ToString(_Cmb_Comp.SelectedValue).Trim()))
                {
                    _Pnl_Comp.Visible = false;
                    _Bt_Aceptar.Enabled = false;
                    _Txt_Factura.Text = "";
                    _Txt_Factura.Focus();
                    return;
                }
                _Mtd_Igualar(_Txt_Guia.Text.Trim(), _Txt_Factura.Text, Convert.ToString(_Cmb_Comp.SelectedValue).Trim());
                _Pnl_Comp.Visible = false;
            }
            else
            { MessageBox.Show("Debe seleccionar una compañía para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Pnl_Comp_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Comp.Visible)
            {
                _Cmb_Comp.Focus();
                _Pnl_Todo.Enabled = false;
            }
            else
            {
                _Pnl_Todo.Enabled = true;
            }
        }

        private void _Bt_CerrarComp_Click(object sender, EventArgs e)
        {
            _Pnl_Comp.Visible = false;
        }

        private void _Chk_DevueltaParaAnular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                    _Txt_Ob.Focus();
            }
        }

        private void Frm_GuiaManual_Shown(object sender, EventArgs e)
        {
            if (_Frm_Guia != null)
            {
                if (_Txt_Factura.Enabled)
                    _Txt_Factura.Focus();
                else if (_Cmb_Firma.SelectedIndex == 0)
                    _Bt_Buscar.Focus();
                else
                    _Bt_Aceptar.Focus();
            }
            else
            {
                if (!(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_ESTATUS_GUIA")))
                {
                    MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
                else
                {
                    _Ctrl_Clave _Ctrl = new _Ctrl_Clave(5, this);
                }
            }
        }

        private void _Cmb_Estatus_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_EliminarEstatus.Enabled = _Cmb_Estatus.Enabled && _Frm_Guia != null;
        }

        private void _Bt_EliminarEstatus_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarDevolucion(_Txt_Factura.Text, _Str_Comp_Temp))
            {
                _Bt_Buscar.PerformClick();//Si entra aqui quiere decir que otro usuario en otra máquina y cargo devolucion parcial de esta factura. El sistema vuelve a hacer click en el boton buscar para que se muestre el mensaje que no se puede editar porque tiene devoluciones cargadas.
                return;
            }
            if (MessageBox.Show("¿Esta seguro de eliminar el estatus de la factura?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                return;
            _Mtd_EliminarEstatus(_Txt_Factura.Text, _Str_Comp_Temp);
        }

        private void Frm_GuiaManual_Activated(object sender, EventArgs e)
        {
            if (_Frm_Guia == null)
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }
    }
}
