using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_GuiaDespacho : Form
    {
        int _Int_Estatus = 0;
        string _Str_Campo = "cguiadesp";
        string _Str_ThisText = "";
        string _G_Str_Proceso = "";
        int _G_Int_Proceso = 0;
        public Frm_GuiaDespacho()
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
        }
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_Placa = "";
        string _Str_FrmPrecarga = "";

        public Frm_GuiaDespacho(int _P_Int_Proceso)
        {
            InitializeComponent();
            if (_P_Int_Proceso == 1)
            {
                _G_Int_Proceso = _P_Int_Proceso;
            }
            _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
        }
        public Frm_GuiaDespacho(string _P_Str_Placa)
        {
            InitializeComponent();
            _Str_Placa = _P_Str_Placa;
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["cplaca"].Value.ToString().Trim() == _P_Str_Placa.Trim())
                { _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Grid.Rows[_Int_Row].Cells[0];
                _Dg_Grid.CurrentCell = _Dg_Cel;
                _Mtd_Tool_ItemLiq_Click();
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
                else
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_ModifComprobAuxiliar(string _P_Str_Factura, string _P_Str_FechaVenc, string _P_Str_Comp, bool _P_Bol_Devol)
        {
            try
            {
                string _Str_Cadena = "SELECT ISNULL(cidcomprob,0) AS cidcomprob FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_Comp + "' AND cfactura='" + _P_Str_Factura + "' AND cidcomprob>0";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    string _Str_TipoDocFact = _myUtilidad._Mtd_TipoDocument_CXC("ctipdocfact", _P_Str_Comp);
                    if (!_P_Bol_Devol)
                    {
                        _Str_Cadena = "SELECT CCOMPANY FROM TMOVAUXILIARCONT WHERE ccompany='" + _P_Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "' AND ctdocument='" + _Str_TipoDocFact + "' AND cnumdocu='" + _P_Str_Factura + "'";
                        DataSet _Ds_DataSet_MovAux = new DataSet();
                        _Ds_DataSet_MovAux = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds_DataSet_MovAux.Tables[0].Rows.Count > 0)
                        {
                            _Str_Cadena = "UPDATE TMOVAUXILIARCONT SET cfechavencimiento='" + _P_Str_FechaVenc + "' WHERE ccompany='" + _P_Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "' AND ctdocument='" + _Str_TipoDocFact + "' AND cnumdocu='" + _P_Str_Factura + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        _Str_Cadena = "UPDATE TCOMPROBANDD SET cfechavencimiento='" + _P_Str_FechaVenc + "' WHERE ccompany='" + _P_Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "' AND ctdocument='" + _Str_TipoDocFact + "' AND cnumdocu='" + _P_Str_Factura + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //----------------------
                    _Str_Cadena = "UPDATE TCOMPROBANDD SET cstatus='1' WHERE ccompany='" + _P_Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "' AND ctdocument='" + _Str_TipoDocFact + "' AND cnumdocu='" + _P_Str_Factura + "' AND cstatus='2'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            catch { }
        }
        private void _Mtd_Actualizar(int _P_Int_Estatus, string _P_Str_Campo, string _P_Str_Texto)
        {
            string _Str_Cadena = "";
            if (_P_Str_Texto.Trim().Length == 0)
            {
                if (_P_Int_Estatus == 0)
                {
                    if (_G_Int_Proceso == 1)
                    {
                        _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ((cestatusfirma=1)) AND (SELECT COUNT(TFACTURAM.cfactura) FROM TFACTURAM INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND VST_GUIADESPACHO.cguiadesp=TGUIADESPACHOD.cguiadesp AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TFACTURAM.cgroupcomp AND TDEVVENTAM.ccompany=TFACTURAM.ccompany AND TDEVVENTAM.cfactura=TFACTURAM.cfactura))=0 and cliqguidespacho='0' order by cguiadesp,cfechasalida";
                    }
                    else
                    {
                        _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' AND cestatusfirma=0 order by cguiadesp,cfechasalida";
                    }
                }
                else if (_P_Int_Estatus == 1)
                {
                    _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='1' order by cguiadesp,cfechasalida";
                }
            }
            else
            {
                if (_P_Str_Campo.Trim() == "ccedula")
                {
                    if (!_Mtd_IsNumeric(_P_Str_Texto))
                    {
                        MessageBox.Show("Al elegir el filtro de transportista debe ingresar valores numéricos en el criterio de busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (_P_Int_Estatus == 0)
                        {
                            if (_G_Int_Proceso == 1)
                            {
                                _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ((cestatusfirma=1)) AND (SELECT COUNT(TFACTURAM.cfactura) FROM TFACTURAM INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND VST_GUIADESPACHO.cguiadesp=TGUIADESPACHOD.cguiadesp AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TFACTURAM.cgroupcomp AND TDEVVENTAM.ccompany=TFACTURAM.ccompany AND TDEVVENTAM.cfactura=TFACTURAM.cfactura))=0 and cliqguidespacho='0' and " + _P_Str_Campo + " LIKE '" + _P_Str_Texto + "%' order by cguiadesp,cfechasalida";
                            }
                            else
                            {
                                _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' AND cestatusfirma=0 and " + _P_Str_Campo + " LIKE '" + _P_Str_Texto + "%' order by cguiadesp,cfechasalida";
                            }
                        }
                        else if (_P_Int_Estatus == 1)
                        { _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='1' and " + _P_Str_Campo + " LIKE '" + _P_Str_Texto + "%' order by cguiadesp,cfechasalida"; }
                    }
                }
                else
                {
                    if (_P_Int_Estatus == 0)
                    {
                        if (_G_Int_Proceso == 1)
                        {
                            _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ((cestatusfirma=1)) AND (SELECT COUNT(TFACTURAM.cfactura) FROM TFACTURAM INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TFACTURAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND VST_GUIADESPACHO.cguiadesp=TGUIADESPACHOD.cguiadesp AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TFACTURAM.cgroupcomp AND TDEVVENTAM.ccompany=TFACTURAM.ccompany AND TDEVVENTAM.cfactura=TFACTURAM.cfactura))=0 and cliqguidespacho='0' and " + _P_Str_Campo + " LIKE '" + _P_Str_Texto + "%' order by cguiadesp,cfechasalida";
                        }
                        else
                        {
                            _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' AND cestatusfirma=0 and " + _P_Str_Campo + " LIKE '" + _P_Str_Texto + "%' order by cguiadesp,cfechasalida";
                        }
                    }
                    else if (_P_Int_Estatus == 1)
                    { _Str_Cadena = "Select cguiadesp,Transporte,convert(varchar, cfechasalida,103) as cfechasalida,convert(varchar, cfliqguidespacho,103) as cfliqguidespacho,cplaca,ccedula,cliqguidespacho,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs, cempaques, dbo.Fnc_Formatear(c_montotot_si_bs) AS cmonto, dbo._FNC_DESCRIP_RUTAS(cgroupcomp, cprecarga) AS ruta from VST_GUIADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='1' and " + _P_Str_Campo + " LIKE '" + _P_Str_Texto + "%' order by cguiadesp,cfechasalida"; }
                }
            }
            if (_Str_Cadena.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid.DataSource = _Ds.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Grid.Columns["cempaques"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns["cmonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Cursor = Cursors.Default;
                _Dg_Grid.ClearSelection();
            }
            //--------------------------------------------------------------------
            if (_P_Int_Estatus == 0)
            {
                this.Text = _Str_ThisText + " (Guía por liquidar)";
            }
            else if (_P_Int_Estatus == 1)
            { this.Text = _Str_ThisText + " (Guía liquidada)"; }
        }
        public void _Mtd_CargarDetalle(string _P_Str_Guia)
        {
            string _Str_Cadena = "Select ccompany,cfactura,c_nomb_comer,CASE WHEN c_entregacliente='1' THEN 'Si' ELSE 'No' END as c_entregacliente,c_observacionesgen,CASE WHEN c_estatus='DEV' THEN 'DEVUELTA' WHEN (c_estatus='FIR' AND c_tipdevolparcial='1') THEN 'FIRMADA' WHEN (c_estatus='FIR' AND c_tipdevolparcial='0') THEN 'FIRMADA-P' WHEN (c_estatus='PAG' AND c_cancelaciontot='1' AND ccontribuyente='1' AND csinretencion='1') THEN 'PAGADA-SR' WHEN (c_estatus='PAG' AND c_cancelaciontot='1' AND ccontribuyente='1') THEN 'PAGADA-R' WHEN (c_estatus='PAG' AND c_cancelaciontot='1') THEN 'PAGADA' WHEN (c_estatus='PAG' AND c_cancelaciontot='2') THEN 'PAGADA-E' WHEN (c_estatus='PAG' AND c_cancelaciontot='0' AND ccontribuyente='1' AND csinretencion='1') THEN 'PAGADA-P-SR' WHEN (c_estatus='PAG' AND c_cancelaciontot='0' AND ccontribuyente='1') THEN 'PAGADA-P-R' WHEN (c_estatus='PAG' AND c_cancelaciontot='0') THEN 'PAGADA-P' WHEN (c_estatus='PAG' AND c_cancelaciontot='3' AND ccontribuyente='1' AND csinretencion='1') THEN 'PAGADA-P-E-SR' WHEN (c_estatus='PAG' AND c_cancelaciontot='3' AND ccontribuyente='1') THEN 'PAGADA-P-E-R' WHEN (c_estatus='PAG' AND c_cancelaciontot='3') THEN 'PAGADA-P-E' ELSE NULL END as c_estatus,dbo.Fnc_Formatear(c_montotot_si_bs) as c_montotot_si_bs,c_estatus as c_estatusid from VST_GUIADESPACHOD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _P_Str_Guia + "' ORDER BY ccompany,cfactura";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Str_Cadena = "Select  dbo.Fnc_Formatear(SUM(c_montocobrado)) as c_montocobrado from TGUIADESPACHOD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _P_Str_Guia + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_MontoCob.Text = _Ds.Tables[0].Rows[0][0].ToString();
            }
        }
        private void Frm_GuiaDespacho_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Dg_Grid.ClearSelection();
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Ob.Top = (this.Height / 2) - (_Pnl_Ob.Height / 2);
            _Pnl_Ob.Left = (this.Width / 2) - (_Pnl_Ob.Width / 2);
            _Pnl_PagoDesp.Top = (this.Height / 2) - (_Pnl_PagoDesp.Height / 2);
            _Pnl_PagoDesp.Left = (this.Width / 2) - (_Pnl_PagoDesp.Width / 2);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            _Str_Campo = "cguiadesp";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            _Str_Campo = "cplaca";
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            _Str_Campo = "ccedula";
        }

        private void despachandoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
            Cursor = Cursors.Default;
        }

        private void cargandoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
            Cursor = Cursors.Default;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {

        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            bool _Bol_SwNext = false;
            if (_Dg_Grid.CurrentCell == null)
            { e.Cancel = true; }
            else
            {
                string _Str_Sql = "SELECT cguiadesp FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Dg_Grid["cguiadesp", _Dg_Grid.CurrentCell.RowIndex].Value.ToString() + "' AND cestatusfirma=1";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_LIQUIDGUIA"))
                    {
                        _Bol_SwNext = true;
                    }
                }
                else
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_LIQUIDGUIA"))
                    {
                        _Bol_SwNext = true;
                    }
                }
                if (_Bol_SwNext)
                {
                    if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cliqguidespacho"].Value.ToString().Trim() == "0")
                    {
                        _Tool_ItemLiq.Enabled = true;
                        _Tool_ItemLiq.Text = "Liquidar guía";
                    }
                    else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cliqguidespacho"].Value.ToString().Trim() == "1")
                    {
                        _Tool_ItemLiq.Enabled = true;
                        _Tool_ItemLiq.Text = "Ver guía";
                    }
                }
                else
                {
                    _Tool_ItemLiq.Enabled = false;
                }
            }
        }
        private void _Mtd_Tool_ItemLiq_Click()
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                bool _Bol_Sw = false;
                string _Str_Sql = "SELECT cprecarga,dbo.Fnc_Formatear(cpagodeldespacho) AS cpagodeldespacho FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_FrmPrecarga = _Ds.Tables[0].Rows[0]["cprecarga"].ToString();
                    _Txt_Pago.Text = _Ds.Tables[0].Rows[0]["cpagodeldespacho"].ToString();
                }
                _Str_Sql = "SELECT cimprimeguiadesp FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Str_FrmPrecarga + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == "1")
                    {
                        _Bol_Sw = true;
                    }
                }
                if (_Bol_Sw)
                {
                    _Txt_Guia.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    _Txt_Fecha.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    _Txt_Transporte.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    _Txt_MontoGuia.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_montotot_si_bs"].Value.ToString();
                    _Str_Placa = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cplaca"].Value.ToString();
                    if (_Int_Estatus == 0)
                    { _Txt_Estatus.Text = "Guía por liquidar"; }
                    else if (_Int_Estatus == 1)
                    { _Txt_Estatus.Text = "Guía liquidada"; }
                    _Mtd_CargarDetalle(_Txt_Guia.Text.Trim());
                    _Tb_Tab.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("La Guía de despacho no ha sido impresa. Es necesario que este impresa ara liquidar la guía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void _Tool_ItemLiq_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Tool_ItemLiq_Click();
            string _Str_Sql = "SELECT cguiadesp FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Txt_Guia.Text + "' AND cestatusfirma=1";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_LIQUIDGUIA"))
                {
                    _Pnl_Liquida.Visible = true;
                    _Pnl_Guardar.Visible = false;
                }
            }
            else
            {
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_LIQUIDGUIA"))
                {
                    _Pnl_Guardar.Visible = true;
                    _Pnl_Liquida.Visible = false;
                }
            }
            if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cliqguidespacho"].Value.ToString().Trim() == "1")
            {
                _Bt_Liquidar.Enabled = false;
                _Dg_Detalle.ReadOnly = true;
            }
            else
            {
                if (_Pnl_Liquida.Visible)
                { _Bt_Liquidar.Enabled = true; }
                else
                { _Bt_Liquidar.Enabled = false; }
                _Dg_Detalle.ReadOnly = false;
            }
            _Bt_PagoDesp.Enabled = _Pnl_Liquida.Visible & _Bt_Liquidar.Enabled;
            this.Cursor = Cursors.Default;
        }
        public DataSet _Mtd_Comb()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("clave");
            _Ds_.Tables[0].Columns.Add("descripcion");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "DEV";
            _DRow_["descripcion"] = "DEVUELTA";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "FIR";
            _DRow_["descripcion"] = "FIRMADA";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "PAG";
            _DRow_["descripcion"] = "PAGADA";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;

        }
        private void _Mtd_Ini()
        {
            _Txt_Guia.Text = "";
            _Txt_Pago.Text = "";
            _Txt_Transporte.Text = "";
            _Txt_Estatus.Text = "";
            _Txt_MontoCob.Text = "";
            _Txt_MontoGuia.Text = "";
            _Str_FrmPrecarga = "";
        }
        private void _Mtd_CargarCombo(ComboBox _P_Cmb_Combo)
        {
            _P_Cmb_Combo.DataSource = null;
            _P_Cmb_Combo.DataSource = _Mtd_Comb().Tables[0];
            _P_Cmb_Combo.DisplayMember = "descripcion";
            _P_Cmb_Combo.ValueMember = "clave";
            _P_Cmb_Combo.SelectedIndex = -1;
        }
        private bool _Mtd_Verificar_Estatus()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                if (_Dg_Row.Cells["EstatusD"].Value.ToString().Trim().Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void _Dg_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cliqguidespacho"].Value == null)
                { _Dg_Grid.Rows[e.RowIndex].Cells["cliqguidespacho"].Value = 0; }
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cliqguidespacho"].Value.ToString().Trim() == "0")
                { e.Value = new Bitmap(GetType(), "Multimedia._Tool_Espera.ico"); }
                else if (_Dg_Grid.Rows[e.RowIndex].Cells["cliqguidespacho"].Value.ToString().Trim() == "1")
                { e.Value = new Bitmap(_Tool_Icono.Image); }
            }
        }
        private bool _Mtd_GuiaConDevolParcial(string _P_Str_Guia)
        {
            string _Str_Cadena = "SELECT cguiadesp FROM TGUIADESPACHOM AS TABLA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ((cestatusfirma=1)) AND (SELECT COUNT(cfactura) FROM TGUIADESPACHOD INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ((TGUIADESPACHOD.c_estatus='FIR' AND TGUIADESPACHOD.c_tipdevolparcial='0') OR (TGUIADESPACHOD.c_estatus='PAG' AND (TGUIADESPACHOD.c_cancelaciontot='0' OR TGUIADESPACHOD.c_cancelaciontot='3'))) AND TGUIADESPACHOM.cestatusfirma='1' AND TGUIADESPACHOD.cguiadesp=TABLA.cguiadesp AND NOT EXISTS(SELECT cfactura FROM TDEVVENTAM WHERE TDEVVENTAM.cgroupcomp=TGUIADESPACHOD.cgroupcomp AND TDEVVENTAM.ccompany=TGUIADESPACHOD.ccompany AND TDEVVENTAM.cfactura=TGUIADESPACHOD.cfactura))=0 and cliqguidespacho='0' AND cguiadesp='" + _P_Str_Guia + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Liquidar_Click(object sender, EventArgs e)
        {
            if (_Txt_Guia.Text.Trim().Length > 0)
            {
                //Evita que se puedan Liqidar Guías de Despacho al haberse iniciado un Conteo de Inventario
                if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
                {
                    MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.OpenForms[this.Name].Close();
                }
                else
                {
                    if (_Mtd_Verificar_Estatus())
                    {
                        if (_Mtd_GuiaConDevolParcial(_Txt_Guia.Text.Trim()))
                        {
                            _G_Str_Proceso = "L";
                            _Lbl_Titulo.Text = "Liquidar guía";
                            _Pnl_Clave.Visible = true;
                        }
                        else
                        {
                            if ((Frm_Padre)this.MdiParent != null)
                            { System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default); }
                            MessageBox.Show("Ha marcado facturas como 'Devueltas Parcialmente'.\nDebe esperar a que carguen las devoluciones para continuar con la aprobación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    { MessageBox.Show("Debe asignar un estatus para cada factura", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
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
                    _Pnl_Clave.Visible = false;
                    if (_G_Str_Proceso == "G")
                    {
                        _Pnl_PagoDesp.Parent = this;
                        _Pnl_PagoDesp.Top = (this.Height / 2) - (_Pnl_PagoDesp.Height / 2);
                        _Pnl_PagoDesp.Left = (this.Width / 2) - (_Pnl_PagoDesp.Width / 2);
                        _Pnl_PagoDesp.BringToFront();
                        _Pnl_PagoDesp.Visible = true;
                    }
                    else if (_G_Str_Proceso == "L")
                    {
                    _Lbl_Reintentar:
                        _Str_Cadena = "SELECT ccompany,ctipoguiasada FROM TGUIADESPACHODD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Txt_Guia.Text.Trim() + "' AND ISNULL(ctipoguiasada,0)>0 AND (cnumguiasada IS NULL or cnumguiasada='0')";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow _Row in _Ds.Tables[0].Rows)
                            {
                                Frm_GuiaSada _Frm = new Frm_GuiaSada(_Row["ccompany"].ToString().Trim(), _Txt_Guia.Text.Trim(), Convert.ToInt32(_Row["ctipoguiasada"]));
                                _Frm.ShowDialog();
                            }
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds.Tables[0].Rows.Count == 0)
                            { _Mtd_LiquidarGuia(); }
                            else
                            {
                                if (MessageBox.Show("¿Desea cargar las guías SADA para las compañías restantes?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    goto _Lbl_Reintentar;
                                }
                            }
                        }
                        else
                        { _Mtd_LiquidarGuia(); }
                    }

                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                //MessageBox.Show("Puede imprimir los reportes desde el menú principal del sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void _Mtd_LiquidarGuia()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Prefactura = "", _Str_FechaEntrega = "";
            string _Str_CodPedido = "";
            string _Str_CodCliente = "";
            int _Int_Dias = 0;
            string _Str_TD = "";
            DataSet _Ds;
            string _Str_Cadena = "UPDATE TGUIADESPACHOM SET cfinalizado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Txt_Guia.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            foreach (DataGridViewRow _DgRow in _Dg_Detalle.Rows)
            {
                _Str_TD = _myUtilidad._Mtd_TipoDocument_CXC("ctipdocfact", Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim());
                if (Convert.ToString(_DgRow.Cells["_Dg_Detalle_Col_StsFirma"].Value).Trim() == "FIR")
                {
                    string _Str_VendedorFactura = "";
                    string _Str_ClienteFactura = "";
                    _Str_Cadena = "SELECT cpfactura,cvendedor,ccliente,CPEDIDO,ccliente FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Prefactura = Convert.ToString(_Ds.Tables[0].Rows[0]["cpfactura"]);
                        _Str_VendedorFactura = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]);
                        _Str_ClienteFactura = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                        _Str_CodPedido = Convert.ToString(_Ds.Tables[0].Rows[0]["cpedido"]);
                        _Str_CodCliente = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                    }
                    _Str_Cadena = "Update TFACTURAM set c_entregacliente='1',c_factdevuelta='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "SELECT TFPAGO.cdias FROM TSALDOCLIENTED INNER JOIN TFPAGO ON TSALDOCLIENTED.cfpago = TFPAGO.cfpago " +
                        "WHERE TSALDOCLIENTED.CCLIENTE='"+_Str_CodCliente+"' AND (TSALDOCLIENTED.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TSALDOCLIENTED.ccompany = '" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "') AND (TSALDOCLIENTED.ctipodocument = '" + _Str_TD + "') AND " +
                        "(TSALDOCLIENTED.cnumdocu = '" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "')";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Int_Dias = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    _Str_Cadena = "SELECT c_fechaentrega FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND cguiadesp='" + _Txt_Guia.Text + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_FechaEntrega = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fechaentrega"]).ToShortDateString();
                    }
                    
                    _Str_Cadena = "Update TSALDOCLIENTED set cfechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega)) + "',cfelimitcobro='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega).AddDays(_Int_Dias)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cnumdocu='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "' and ctipodocument='" + _Str_TD + "' and ccliente='" + _Str_CodCliente + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    //Se ingresa la factura en el movimiento de documentos.
                    _Str_Cadena = "DELETE FROM TMOVDOCUMENTOS WHERE CNUMDOCU='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "' AND CCOMPANY='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND CTIPODOCUMENT='" + _Str_TD + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TMOVDOCUMENTOS(ccompany,ctipodocument,cnumdocu,ccliente,cfechaact,cvendedor,cfechadocument,cfechalimitecobro) VALUES ";
                    _Str_Cadena += "('" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "','" + _Str_TD + "','" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "','" + _Str_ClienteFactura + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega)) + "','" + _Str_VendedorFactura + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega)) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega).AddDays(_Int_Dias)) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);


                    _Str_Cadena = "SELECT c_factdevuelta FROM TPREFACTURAM where ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cpfactura='" + _Str_Prefactura + "' and cpedido='" + _Str_CodPedido + "' AND c_factdevuelta='1'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    bool _Bol_Devuelto_ = false;
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Bol_Devuelto_ = true;
                    }
                    if (!_Bol_Devuelto_)
                    {
                        _Str_Cadena = "Update TPREFACTURAM set c_factdevuelta='0' where ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cpfactura='" + _Str_Prefactura + "' and cpedido='" + _Str_CodPedido + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    _Mtd_ModifComprobAuxiliar(Convert.ToString(_DgRow.Cells["Factura"].Value).Trim(), new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega).AddDays(_Int_Dias)), Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim(), false);
                }
                else if (Convert.ToString(_DgRow.Cells["_Dg_Detalle_Col_StsFirma"].Value).Trim() == "DEV")
                {
                    _Str_Cadena = "Update TFACTURAM set c_factdevuelta='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "SELECT cpfactura,CPEDIDO FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Prefactura = Convert.ToString(_Ds.Tables[0].Rows[0]["cpfactura"]);
                        _Str_CodPedido = Convert.ToString(_Ds.Tables[0].Rows[0]["cpedido"]);
                    }
                    if (_Str_Prefactura.Length > 0)
                    {
                        _Str_Cadena = "Update TPREFACTURAM set c_factdevuelta='1',cprecarga='0' where ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cpfactura='" + _Str_Prefactura + "' and cpedido='" + _Str_CodPedido + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    _Mtd_ModifComprobAuxiliar(Convert.ToString(_DgRow.Cells["Factura"].Value).Trim(), "", Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim(), true);
                }
                else if (Convert.ToString(_DgRow.Cells["_Dg_Detalle_Col_StsFirma"].Value).Trim() == "PAG")
                {
                    string _Str_VendedorFactura = "";
                    string _Str_ClienteFactura = "";

                    _Str_Cadena = "SELECT cpfactura,cvendedor,ccliente,cpedido,ccliente FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Prefactura = Convert.ToString(_Ds.Tables[0].Rows[0]["cpfactura"]);
                        _Str_VendedorFactura = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]);
                        _Str_ClienteFactura = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                        _Str_CodPedido = Convert.ToString(_Ds.Tables[0].Rows[0]["cpedido"]);
                        _Str_CodCliente = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                    }
                    _Str_Cadena = "SELECT TFPAGO.cdias FROM TSALDOCLIENTED INNER JOIN TFPAGO ON TSALDOCLIENTED.cfpago = TFPAGO.cfpago " +
                        "WHERE (TSALDOCLIENTED.ccliente='"+_Str_CodCliente+"') and (TSALDOCLIENTED.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TSALDOCLIENTED.ccompany = '" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "') AND (TSALDOCLIENTED.ctipodocument = '" + _Str_TD + "') AND " +
                        "(TSALDOCLIENTED.cnumdocu = '" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "')";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        {
                            _Int_Dias = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    _Str_Cadena = "SELECT c_fechaentrega FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND cguiadesp='" + _Txt_Guia.Text + "' AND cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_FechaEntrega = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fechaentrega"]).ToShortDateString();
                    }
                    
                    _Str_Cadena = "Update TFACTURAM set c_entregacliente='1',c_factdevuelta='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cfactura='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "Update TSALDOCLIENTED set cfechaentrega='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega)) + "',cfelimitcobro='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega).AddDays(_Int_Dias)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cnumdocu='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "' and ctipodocument='" + _Str_TD + "' and ccliente='"+_Str_CodCliente+"'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    //Se ingresa la factura en el movimiento de documentos.
                    _Str_Cadena = "DELETE FROM TMOVDOCUMENTOS WHERE CNUMDOCU='" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "' AND CCOMPANY='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' AND CTIPODOCUMENT='" + _Str_TD + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TMOVDOCUMENTOS(ccompany,ctipodocument,cnumdocu,ccliente,cfechaact,cvendedor,cfechadocument,cfechalimitecobro) VALUES ";
                    _Str_Cadena += "('" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "','" + _Str_TD + "','" + Convert.ToString(_DgRow.Cells["Factura"].Value).Trim() + "','" + _Str_ClienteFactura + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega)) + "','" + _Str_VendedorFactura + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega)) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega).AddDays(_Int_Dias)) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    _Str_Cadena = "SELECT c_factdevuelta FROM TPREFACTURAM where ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cpfactura='" + _Str_Prefactura + "' AND c_factdevuelta='1' and cpedido='" + _Str_CodPedido + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    bool _Bol_Devuelto_ = false;
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Bol_Devuelto_ = true;
                    }
                    if (!_Bol_Devuelto_)
                    {
                        _Str_Cadena = "Update TPREFACTURAM set c_factdevuelta='0' where ccompany='" + Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim() + "' and cpfactura='" + _Str_Prefactura + "' and cpedido='" + _Str_CodPedido + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    _Mtd_ModifComprobAuxiliar(_DgRow.Cells["Factura"].Value.ToString().Trim(), new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Str_FechaEntrega).AddDays(_Int_Dias)), Convert.ToString(_DgRow.Cells["ccompany"].Value).Trim(), false);
                }
            }
            _Str_Cadena = "Update TGUIADESPACHOM set cestatusfirma=2,cliqguidespacho='1',cfliqguidespacho='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "Update TTRANSPORTE set cocupado='0',cesperando='1' where cplaca='" + _Str_Placa + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TPRECARGAM SET cimprimefactura=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Str_FrmPrecarga + "' AND cimprimefactura='2'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //------------
            _Str_Cadena = "Select cmodificado from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text.Trim() + "' and cmodificado='1'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("La guía ha sido editada, se va a imprimir la relación de facturas nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Imprimir(_Txt_Guia.Text.Trim(), true, true); 
            }
            else
            { _Mtd_Imprimir(_Txt_Guia.Text.Trim(), false, true); }
            //------------
            if (this.MdiParent != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            }
            MessageBox.Show("La operación fua realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //-------------------------------DEVOLUCIONES EN LA GUIA
            _Str_Cadena = "SELECT cguiadesp FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Txt_Guia.Text.Trim() + "' AND ((c_estatus='FIR' AND c_tipdevolparcial='0') OR (c_estatus = 'PAG' AND (c_cancelaciontot = '0' OR c_cancelaciontot = '3')))";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Guardar_Id_Devoluciones(_Txt_Guia.Text.Trim());
                Cursor = Cursors.Default;
                MessageBox.Show("A continuación se mostrará el informe 'Devoluciones en la Guía' para imprmir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Cursor = Cursors.WaitCursor;
                Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(2, _Txt_Guia.Text.Trim());
                Cursor = Cursors.Default;
                _Frm_Inf.MdiParent = this.MdiParent;
                _Frm_Inf.Dock = DockStyle.Fill;
                _Frm_Inf.Show();
            }
            //-------------------------------
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_Guardar_Id_Devoluciones(string _P_Str_Guia)
        {
            string _Str_Cadena = "UPDATE TGUIADESPACHOD SET ciddevventa=TDEVVENTAM.ciddevventa " +
                      "FROM TGUIADESPACHOD INNER JOIN " +
                      "TFACTURAM ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND " +
                      "TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany INNER JOIN " +
                      "TDEVVENTAM ON TFACTURAM.cgroupcomp = TDEVVENTAM.cgroupcomp AND " +
                      "TFACTURAM.ccompany = TDEVVENTAM.ccompany AND TFACTURAM.cfactura = TDEVVENTAM.cfactura AND " +
                      "TFACTURAM.ccliente = TDEVVENTAM.ccliente " +
                      "WHERE (TGUIADESPACHOD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGUIADESPACHOD.cguiadesp = '" + _P_Str_Guia + "') AND ((TGUIADESPACHOD.c_estatus = 'FIR' AND TGUIADESPACHOD.c_tipdevolparcial = '0') OR (TGUIADESPACHOD.c_estatus = 'PAG' AND (TGUIADESPACHOD.c_cancelaciontot = '0' OR TGUIADESPACHOD.c_cancelaciontot = '3')))";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Tool_Principal.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; _Tool_Principal.Enabled = true; }
        }

        private void _Tool_Consultar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
            }
        }

        private void _Dg_Detalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_Dg_Detalle.ReadOnly)
            {
                if (_Dg_Detalle.CurrentCell != null)
                {
                    if (e.ColumnIndex == 0)
                    {
                        //if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
                        //{
                        //    MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    Application.OpenForms[this.Name].Close();
                        //}
                        //else
                        //{
                        Frm_GuiaManual _Frm = new Frm_GuiaManual(_Dg_Detalle.Rows[e.RowIndex].Cells["Factura"].Value.ToString(), _Txt_Guia.Text, this, _Dg_Detalle.Rows[e.RowIndex].Cells["ccompany"].Value.ToString());
                        _Frm.ShowDialog(this);
                        //}
                    }
                }
            }
        }

        private void _Pnl_Ob_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Ob.Visible)
            {
                if (_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Observaciones"].Value == null)
                { _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Observaciones"].Value = ""; }
                _Tb_Tab.Enabled = false; _Tool_Principal.Enabled = false; _Txt_Ob.Text = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Observaciones"].Value.ToString().ToUpper(); _Txt_Ob.Focus();
            }
            else
            { _Tb_Tab.Enabled = true; _Tool_Principal.Enabled = true; }
        }

        private void _Bt_AceptarOb_Click(object sender, EventArgs e)
        {
            if (_Txt_Ob.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Pnl_Ob.Visible = false;
                string _Str_Cadena = "Update TGUIADESPACHOD set c_observacionesgen='" + _Txt_Ob.Text.Trim().ToUpper() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ccompany"].Value + "'  and cguiadesp='" + _Txt_Guia.Text.Trim() + "' and cfactura='" + _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Factura"].Value + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_CargarDetalle(_Txt_Guia.Text);
                _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe ingresar la observación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.CurrentCell != null)
            {
                _Pnl_Ob.Visible = true;
            }
        }

        private void _Bt_CancelarOb_Click(object sender, EventArgs e)
        {
            _Pnl_Ob.Visible = false;
        }

        private void _Cntx_Obser_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Detalle.CurrentCell == null)
            { e.Cancel = true; }
        }

        private void Frm_GuiaDespacho_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 1 & _Txt_Guia.Text.Trim().Length == 0 & e.TabPageIndex != 0)
            {
                e.Cancel = true;
            }
        }
        private void _Btn_PagDespOk_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            double _Dbl_Monto = 0;
            if (_Txt_MontoDespacho.Text.Trim() != "")
            {
                _Dbl_Monto = Convert.ToDouble(_Txt_MontoDespacho.Text);
            }
            if (_Dbl_Monto > 0)
            {
                double _Dbl_MontoDespCalc = 0;
                string _Str_Cadena = "SELECT ccaltabuladordes FROM TPRECARGAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Str_FrmPrecarga + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccaltabuladordes"]) != "")
                {
                    _Dbl_MontoDespCalc = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccaltabuladordes"]);
                }
                _Str_Cadena = "Update TGUIADESPACHOM set cestatusfirma=1,cpagodeldespacho='" + _Txt_MontoDespacho.Text.Replace(".", "").Replace(",", ".") + "',ccaltabuladordes=" + _Dbl_MontoDespCalc.ToString().Replace(".", "").Replace(",", ".") + " where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cguiadesp='" + _Txt_Guia.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Pnl_PagoDesp.Visible = false;
                if (!_Bt_PagoDesp.Enabled)
                {
                    MessageBox.Show("La operación fua realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Imprimir(_Txt_Guia.Text.Trim(), true, false);
                    _Mtd_Ini();
                    _Tb_Tab.SelectedIndex = 0;
                    _Mtd_Actualizar(_Int_Estatus, _Str_Campo, _Tool_Consultar.Text);
                    if ((Frm_Padre)this.MdiParent != null)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    }
                }
                else
                { _Txt_Pago.Text = _Txt_MontoDespacho.Text; }
            }
            else
            {
                MessageBox.Show("El monto del pago del despacho debe ser mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_Imprimir(string _Str_GuiaDespacho, bool _P_Bol_Imprimir, bool _P_Bol_MarcarFactRelCob)
        {
            if (_P_Bol_Imprimir)
            {
                try
                {
                    PrintDialog _Print;
                    string _Str_Cadena = "SELECT DISTINCT VST_GUIADESPAFACTALCOBRO.ccompany FROM VST_GUIADESPAFACTALCOBRO INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany=VST_GUIADESPAFACTALCOBRO.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Str_GuiaDespacho + "'";
                    _Str_Cadena += "UNION SELECT DISTINCT VST_GUIADESPAFACTALCOBRO2.ccompany FROM VST_GUIADESPAFACTALCOBRO2 INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany=VST_GUIADESPAFACTALCOBRO2.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Str_GuiaDespacho + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        MessageBox.Show("Se va a imprimir la relación de facturas de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Imprimir:
                        _Print = new PrintDialog();
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            //----------------------------
                            _Str_Cadena = "SELECT TCOMPANY.cname AS ccompany, cguiadesp, cfactura, ccliente, c_nomb_comer, c_montotot_si_bs, c_impuesto_bs, c_estatus, c_fechaentrega, total, cliqguidespacho, cfacturasrelacobro, ruta, cvendedor, CedulaTransportista, NombreTransportista FROM VST_GUIADESPAFACTALCOBRO INNER JOIN TCOMPANY ON VST_GUIADESPAFACTALCOBRO.ccompany=TCOMPANY.ccompany WHERE VST_GUIADESPAFACTALCOBRO.ccompany='" + _Row[0].ToString().Trim() + "' AND cguiadesp='" + _Str_GuiaDespacho + "' ORDER BY cfactura";
                            DataSet _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_DsTemp.Tables[0].Rows.Count > 0)
                            {
                                Report.rGuiaFacturaAlCobro2 _My_Reporte = new T3.Report.rGuiaFacturaAlCobro2();
                                _My_Reporte.SetDataSource(_DsTemp.Tables[0]);
                                //----------------------------
                                _Str_Cadena = "SELECT TCOMPANY.cname AS ccompany, cguiadesp, cfactura, ccliente, c_nomb_comer, c_montotot_si_bs, c_impuesto_bs, c_estatus, c_fechaentrega, total, cliqguidespacho, cfacturasrelacobro, ruta, cvendedor, CedulaTransportista, NombreTransportista FROM VST_GUIADESPAFACTALCOBRO2 INNER JOIN TCOMPANY ON VST_GUIADESPAFACTALCOBRO2.ccompany=TCOMPANY.ccompany WHERE VST_GUIADESPAFACTALCOBRO2.ccompany='" + _Row[0].ToString().Trim() + "' AND cguiadesp='" + _Str_GuiaDespacho + "' ORDER BY cfactura";
                                _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_DsTemp.Tables[0].Rows.Count > 0)
                                { _My_Reporte.Subreports[0].SetDataSource(_DsTemp.Tables[0]); }
                                else
                                { _My_Reporte.Section4.SectionFormat.EnableSuppress = true; }
                                //----------------------------
                                var _PageSettings = new System.Drawing.Printing.PageSettings();
                                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                                _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                                //----------------------------
                            }
                            else
                            {
                                _Str_Cadena = "SELECT TCOMPANY.cname AS ccompany, cguiadesp, cfactura, ccliente, c_nomb_comer, c_montotot_si_bs, c_impuesto_bs, c_estatus, c_fechaentrega, total, cliqguidespacho, cfacturasrelacobro, ruta, cvendedor, CedulaTransportista, NombreTransportista FROM VST_GUIADESPAFACTALCOBRO2 INNER JOIN TCOMPANY ON VST_GUIADESPAFACTALCOBRO2.ccompany=TCOMPANY.ccompany WHERE VST_GUIADESPAFACTALCOBRO2.ccompany='" + _Row[0].ToString().Trim() + "' AND cguiadesp='" + _Str_GuiaDespacho + "' ORDER BY cfactura";
                                _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_DsTemp.Tables[0].Rows.Count > 0)
                                {
                                    Report.rGuiaFacturaAlCobro2Sub _My_Reporte = new T3.Report.rGuiaFacturaAlCobro2Sub();
                                    _My_Reporte.SetDataSource(_DsTemp.Tables[0]);
                                    //----------------------------
                                    var _PageSettings = new System.Drawing.Printing.PageSettings();
                                    _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                                    var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                                    _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                                    //----------------------------
                                }
                            }
                            if (MessageBox.Show("¿Se imprimió correctamente la relación de facturas de la compañía " + CLASES._Cls_Varios_Metodos._Mtd_NombComp(_Row[0].ToString().Trim()) + "?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                goto Imprimir;
                            }
                        }
                        else
                        { MessageBox.Show("Puede imprimir los reportes desde el menú principal del sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                catch (Exception _Ex)
                { MessageBox.Show("Puede imprimir los reportes desde el menú principal del sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            if (_P_Bol_MarcarFactRelCob)
            {
                Cursor = Cursors.WaitCursor;
                string _Str_SentenciaSQL = "UPDATE TGUIADESPACHOD SET cfacturasrelacobro='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Str_GuiaDespacho + "' AND (c_estatus='FIR' OR c_estatus='PAG')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                Cursor = Cursors.Default;
            }
        }

        private void _Btn_PagDespCancel_Click(object sender, EventArgs e)
        {
            _Pnl_PagoDesp.Visible = false;
        }

        private void _Txt_MontoDespacho_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_MontoDespacho, e, 15, 2);
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

        private void _Dg_Detalle_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_Dg_Detalle.ReadOnly)
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    _Lbl_DgDetalleInfo.Visible = true;
                }
                else
                {
                    _Lbl_DgDetalleInfo.Visible = false;
                }
            }
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            if (_Txt_Guia.Text.Trim().Length > 0)
            {
                //if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
                //{
                //    MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Application.OpenForms[this.Name].Close();
                //}
                //else
                //{
                if (!_Dg_Detalle.ReadOnly)
                {
                    if (_Mtd_Verificar_Estatus())
                    {
                        _G_Str_Proceso = "G";
                        _Lbl_Titulo.Text = "Cargar guía";
                        _Pnl_Clave.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe asignar un estatus para cada factura", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                { MessageBox.Show("El proceso ya ha sido realizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                //}
            }
        }

        private void _Bt_guia_manual_Click(object sender, EventArgs e)
        {
            if (!_Dg_Detalle.ReadOnly)
            {
                Frm_GuiaManual _Frm = new Frm_GuiaManual(_Txt_Guia.Text, this);
                _Frm.ShowDialog(this);
            }
            else
            { MessageBox.Show("El proceso ya ha sido realizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void Frm_GuiaDespacho_Shown(object sender, EventArgs e)
        {
            //if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            //{
            //    //if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CIERRE_CONTEO"))
            //    //{
            //    //    MessageBox.Show("Se ha iniciado el conteo de inventario.\n Si usted realiza operaciones en este módulo podria ocacionar descuadres en el inventario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    _Ctrl_Clave _Ctrl = new _Ctrl_Clave(2, this);
            //    //}
            //    //else
            //    //{
            //    MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Application.OpenForms[this.Name].Close();
            //    //}
            //}
        }

        private void _Pnl_PagoDesp_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_PagoDesp.Visible)
            {
                if (!_Bt_PagoDesp.Enabled)
                { _Txt_MontoDespacho.Text = ""; }
                else
                {
                    if (_Txt_Pago.Text.Trim().Length == 0)
                    { _Txt_Pago.Text = "0"; }
                    _Txt_MontoDespacho.Text = _Txt_Pago.Text;
                }
                _Txt_MontoDespacho.Focus();
                _Tb_Tab.Enabled = false;
                _Tool_Principal.Enabled = false;
            }
            else
            { _Tb_Tab.Enabled = true; _Tool_Principal.Enabled = true; }
        }

        private void _Bt_PagoDesp_Click(object sender, EventArgs e)
        {
            _Pnl_PagoDesp.Visible = true;
        }
        private string _Mtd_RetornarPreCarga(string _P_Str_Guia)
        {
            string _Str_Cadena = "SELECT cprecarga FROM TGUIADESPACHOM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _P_Str_Guia + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        private DataTable _Mtd_ReporteGuiaDesp(string _P_Str_Guia, string _P_Str_Precarga)
        {
            string _Str_Cadena = "EXEC PA_RUTA_DESCRIP_GUIA '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Guia + "','" + _P_Str_Precarga + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
        }
        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (_Dg_Grid.CurrentCell.RowIndex != -1)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "VST_REPORTEGUIDESPACHO" }, "", "T3.Report.rGuiaDespachoDetalle", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cguiadesp"].Value).Trim() + "'");
                    //REPORTESS _Frm = new REPORTESS("T3.Report.rGuiaDespachoDetalle", _Mtd_ReporteGuiaDesp(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cguiadesp"].Value).Trim(), _Mtd_RetornarPreCarga(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cguiadesp"].Value).Trim())), "Section1", "cabecera", "rif", "nit");
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}