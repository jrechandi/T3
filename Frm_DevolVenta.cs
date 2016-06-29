using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_DevolVenta : Form
    {
        int _Int_SwGuardar = 1;
        int _G_Int_Entrada = 0;
        string _Str_MyProceso = "";
        double _Dbl_FrmImp = 0, _Dbl_FrmMontoSimp=0;
        string[] _Str_FindCampos = new string[2];
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
        bool _Bol_Tabs = false;
        Frm_Busqueda2 _Frm_Busqueda2 = new Frm_Busqueda2();
        
        public Frm_DevolVenta()
        {
            InitializeComponent();
            _Mtd_CargarVendedores();
            _Rbt_Apro.Checked = true;
            _Mtd_CargarConsulta();
        }
        public Frm_DevolVenta(int _Pr_Int_Entrada)
        {
            InitializeComponent();
            _Mtd_CargarVendedores();
            _Bol_Tabs = true;
            _Rbt_PorA.Checked = true;
            //if (_Pr_Int_Entrada == 1)
            //{//PARA CARGAR LAS DEVOLUCIONES PENDIENTES
            //    _G_Int_Entrada = 1;
            //}
        }
        public Frm_DevolVenta(Frm_Busqueda2 _P_Frm_Busqueda2,string _P_Str_Factura, string _P_Str_Cliente, string _Str_DesCliente, string _P_Str_Motivo, string _P_Str_Vendedor)
        {
            InitializeComponent();
            _Bol_Tabs = true;
            _Frm_Busqueda2 = _P_Frm_Busqueda2;
            _Rb_Bestado.Checked = true;
            _Grb_TpoDev.Enabled = false;
            _Rb_Cfact.Checked = true;
            _Grb_Fact.Enabled = false;
            _Mtd_CargarVendedores();
            _Mtd_CargarMotivos();
            _Cb_Motivo.SelectedValue = _P_Str_Motivo;
            _Cb_Motivo.Enabled = false;
            _Txt_Fact.Text = _P_Str_Factura;
            _Txt_Cliente.Tag = _P_Str_Cliente;
            _Txt_Cliente.Text = _Str_DesCliente.Trim().ToUpper();
            _Bt_Buscar.Enabled = false;
            ////-----------
            Cursor = Cursors.WaitCursor;
            string _Str_VendedorDeZona = _Mtd_RetornarVendedorDeZona(_P_Str_Factura);
            Cursor = Cursors.Default;
            if (_Str_VendedorDeZona.Trim().Length > 0)
            {
                _Cb_Vendedor.SelectedValue = _Str_VendedorDeZona;
                _Cb_Vendedor.Enabled = false;
                _Dg_GridDet.Rows.Clear();
                _Dg_GridDet.RowCount = 1;
                _Dg_GridDet.ReadOnly = false;
                _Dg_GridDet.Rows[0].ReadOnly = true;
                _Dg_GridDet.Rows[0].Cells["_Dg_GridDetCol_Caja"].ReadOnly = false;
                _Dg_GridDet.Rows[0].Cells["_Dg_GridDetCol_CxCaja"].ReadOnly = false;
            }
            else
            {
                string _Str_CodigoZona = _Mtd_ObtenerCodigoZona(_P_Str_Factura);
                MessageBox.Show("La zona " + _Str_CodigoZona + " no tiene vendedor asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            ////-----------
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectTab(1);
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Bt_Firma2.Visible = false;
            _Btn_Rechazar.Visible = false;
            _Txt_Cliente.Enabled = false;
            _Str_MyProceso = "A";
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Bol_Tabs)
            {
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_GUIA_CON_DEVOL") & this.MdiParent != null)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                }
            }
            else
            {
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                if (_Str_MyProceso == "A")
                {
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_DEVOLVENTA"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else if (_Str_MyProceso == "F")
                {
                    if ((_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA")))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                        if (_Txt_IdDevol.Text.Trim().Length > 0)
                        { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = (_Mtd_Firma_Nivel_1(_Txt_IdDevol.Text.Trim()) & _Dg_GridDet.ReadOnly); }
                        if (!((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled & !_Dg_GridDet.ReadOnly)
                        { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true; }
                    }
                    else
                    {
                        if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_DEVOLVENTA"))
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
                else if (_Str_MyProceso == "")
                {
                    if (_Txt_IdDevol.Text == "")
                    {
                        if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_DEVOLVENTA"))
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
                        if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_DEVOLVENTA"))
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
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                if (_Ctrl.Name != "_Rbt_Apro" && _Ctrl.Name != "_Rbt_PorA" && _Ctrl.Name != "_Rbt_Rechazadas")
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private void _Mtd_CargarConsulta()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            string _Str_AgruparPor = "";
            _Tsm_Menu[0] = new ToolStripMenuItem("Nº Devol.");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            _Str_FindCampos[0] = "ciddevventa";
            _Str_FindCampos[1] = "(CONVERT(VARCHAR(10),VST_TDEVVENTAM.ccliente) + '-' + rtrim(ccliente_nombcomer))";
            
            if (_G_Int_Entrada == 1)
            {
                _Str_Sql = "Select ciddevventa as [Nº Devol.],CONVERT(char(10),cfechadev,103) as [Fecha],(CONVERT(VARCHAR(10),VST_TDEVVENTAM.ccliente) + '-' + rtrim(ccliente_nombcomer)) as [Cliente],cidnotrecepc as [N.R.],VST_TDEVVENTAM.cfactura AS [Factura],ccajas as [Cajas],cunidades AS [Unidades],ccostotot-ccostimp as [Costo S/I],TFACTURAM.cguiadesp AS Guía,VST_TDEVVENTAM.cvendedor AS Vendedor,VST_TDEVVENTAM.cidmotivo AS [Motivo]  from VST_TDEVVENTAM LEFT JOIN TFACTURAM ON TFACTURAM.cgroupcomp=VST_TDEVVENTAM.cgroupcomp AND TFACTURAM.ccompany=VST_TDEVVENTAM.ccompany AND TFACTURAM.cfactura=VST_TDEVVENTAM.cfactura WHERE VST_TDEVVENTAM.ccompany='" + Frm_Padre._Str_Comp + "' and VST_TDEVVENTAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cfimarnivel=1 AND canuladan=0";
            }
            else if (_G_Int_Entrada == 0)
            {
                _Str_Sql = "Select ciddevventa as [Nº Devol.],CONVERT(char(10),cfechadev,103) as [Fecha],(CONVERT(VARCHAR(10),VST_TDEVVENTAM.ccliente) + '-' + rtrim(ccliente_nombcomer)) as [Cliente],cidnotrecepc as [N.R.],VST_TDEVVENTAM.cfactura AS [Factura],ccajas as [Cajas],cunidades AS [Unidades],ccostotot-ccostimp as [Costo S/I],TFACTURAM.cguiadesp AS Guía,VST_TDEVVENTAM.cvendedor AS Vendedor,VST_TDEVVENTAM.cidmotivo AS [Motivo] from VST_TDEVVENTAM LEFT JOIN TFACTURAM ON TFACTURAM.cgroupcomp=VST_TDEVVENTAM.cgroupcomp AND TFACTURAM.ccompany=VST_TDEVVENTAM.ccompany AND TFACTURAM.cfactura=VST_TDEVVENTAM.cfactura WHERE VST_TDEVVENTAM.ccompany='" + Frm_Padre._Str_Comp + "' and VST_TDEVVENTAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cfimarnivel>1 AND canuladan=0" +
                " AND convert(datetime,convert(varchar(255),cfechadev,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            }
            else if (_G_Int_Entrada == 2)
            {
                _Str_Sql = "Select ciddevventa as [Nº Devol.],CONVERT(char(10),cfechadev,103) as [Fecha],(CONVERT(VARCHAR(10),VST_TDEVVENTAM.ccliente) + '-' + rtrim(ccliente_nombcomer)) as [Cliente],cidnotrecepc as [N.R.],VST_TDEVVENTAM.cfactura AS [Factura],ccajas as [Cajas],cunidades AS [Unidades],ccostotot-ccostimp as [Costo S/I],TFACTURAM.cguiadesp AS Guía,VST_TDEVVENTAM.cvendedor AS Vendedor,VST_TDEVVENTAM.cidmotivo AS [Motivo] from VST_TDEVVENTAM LEFT JOIN TFACTURAM ON TFACTURAM.cgroupcomp=VST_TDEVVENTAM.cgroupcomp AND TFACTURAM.ccompany=VST_TDEVVENTAM.ccompany AND TFACTURAM.cfactura=VST_TDEVVENTAM.cfactura WHERE VST_TDEVVENTAM.ccompany='" + Frm_Padre._Str_Comp + "' and VST_TDEVVENTAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cfimarnivel>1 AND canuladan=1" +
                " AND convert(datetime,convert(varchar(255),cfechadev,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            }
            if (_Cmb_Motivo.SelectedIndex > 0)
            {
                _Str_Sql += " AND cidmotivo='" + Convert.ToString(_Cmb_Motivo.SelectedValue).Trim() + "'";
            }

            _Str_AgruparPor = "VST_TDEVVENTAM.cfactura";

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Sql, _Str_FindCampos, "", _Tsm_Menu, _Dg_Grid, true, "", _Str_AgruparPor);
            _Dg_Grid.Columns["Guía"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Cursor = Cursors.Default;
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Rb_Bestado.Enabled = _Pr_Bol_A;
            _Rb_Mestado.Enabled = _Pr_Bol_A;
            _Txt_IdDevol.Enabled = false;
            _Txt_FechaDevol.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Cb_Motivo.Enabled = false;
            _Rb_Cfact.Enabled = false;
            _Rb_Sfact.Enabled = false;
            _Txt_Fact.Enabled = false;
            _Cb_Vendedor.Enabled = false;
            _Dg_GridDet.ReadOnly = true;
            _Bt_Firma2.Enabled = false;
            if (this.MdiParent != null) { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false; }
            _Btn_Rechazar.Enabled = false;
            //Quitar luego
            //_Rb_Mestado.Enabled = false;
        }
        public void _Mtd_Ini(bool _Bol_CargarConsulta)
        {
            _Int_Sw = 1;
            _Lbl_Nota.Text = "";
            _Str_MyProceso = "";
            _LBox_NC.Items.Clear();
            _Rb_Bestado.Checked = false;
            _Rb_Mestado.Checked = false;
            _Txt_IdDevol.Text = "";
            _Txt_FechaDevol.Text = "";
            _Rb_Cfact.Checked = false;
            _Rb_Sfact.Checked = false;
            _Txt_Fact.Text = "";
            _Dg_GridDet.Rows.Clear();
            _Txt_Cajas.Text = "";
            _Txt_Unidades.Text = "";
            _Txt_MImpuesto.Text = "";
            _Txt_MontoTotal.Text = "";
            _Txt_Costo.Text = "";
            _Txt_Cliente.Text="";
            _Txt_Cliente.Tag="";
            _Cb_Vendedor.SelectedIndex = -1;
            _Lbl_FactoCli.Text = "Factura:";
            _Dg_GridDet.AllowUserToDeleteRows = false;
            _Mtd_CargarVendedores();
            _Mtd_CargarMotivos();
            if (_Bol_CargarConsulta)
            { _Mtd_CargarConsulta(); }
            _Mtd_Bloquear(false);
            _Bt_Firma2.Visible = false;
            _Btn_Rechazar.Visible = false;
            //Quitar luego
            //_Rb_Mestado.Enabled = false;
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,RTRIM(cdescripcion) FROM TMOTIVO where cmotivodev='1' ORDER BY cconcepto ASC";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
        }
        private void _Mtd_CargarMotivos()
        {
            if (_Rb_Bestado.Checked)
            {
                if (_Bol_Tabs)
                {
                    string _Str_Sql = "SELECT cidmotivo,RTRIM(cdescripcion) FROM TMOTIVO ORDER BY cconcepto ASC";
                    _myUtilidad._Mtd_CargarCombo(_Cb_Motivo, _Str_Sql);
                }
                else
                {
                    string _Str_Sql = "SELECT cidmotivo,RTRIM(cdescripcion) FROM TMOTIVO where cmotivodev='1' and cmotivodevme='0' ORDER BY cconcepto ASC";
                    _myUtilidad._Mtd_CargarCombo(_Cb_Motivo, _Str_Sql);
                }
            }
            if (_Rb_Mestado.Checked)
            {
                if (_Bol_Tabs)
                {
                    string _Str_Sql = "SELECT cidmotivo,RTRIM(cdescripcion) FROM TMOTIVO ORDER BY cconcepto ASC";
                    _myUtilidad._Mtd_CargarCombo(_Cb_Motivo, _Str_Sql);
                }
                else
                {
                    string _Str_Sql = "SELECT cidmotivo,RTRIM(cdescripcion) FROM TMOTIVO where cmotivodevme='1' and cmotivodev='1' ORDER BY cconcepto ASC";
                    _myUtilidad._Mtd_CargarCombo(_Cb_Motivo, _Str_Sql);
                }
            }
            else
            {
                _Cb_Motivo.SelectedIndex = -1;
            }
        }
        private void _Mtd_CargarVendedores()
        {
            string _Str_Sql = "SELECT TVENDEDOR.cvendedor,(RTRIM(TVENDEDOR.cvendedor) + ':' + RTRIM(TVENDEDOR.cname)) FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor where TVENDEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TVENDEDOR.c_activo='1' AND TZONAVENDEDOR.cdelete='0' and TVENDEDOR.c_tipo_vend='1' ORDER BY cast(replace(TVENDEDOR.cvendedor,rtrim(TVENDEDOR.ccompany)+'_','') as integer) ASC";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql);
        }
        private void _Mtd_CargarVendedoresCargado()
        {
            string _Str_Sql = "SELECT TVENDEDOR.cvendedor,(RTRIM(TVENDEDOR.cvendedor) + ':' + RTRIM(TVENDEDOR.cname)) FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor where TVENDEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TVENDEDOR.c_tipo_vend='1' ORDER BY cast(replace(TVENDEDOR.cvendedor,rtrim(TVENDEDOR.ccompany)+'_','') as integer) ASC";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql);
        }
        private void _Mtd_CargarNCGeneradas(string _Pr_Str_IdDev)
        {
            string _Str_Cadena = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Pr_Str_IdDev + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _LBox_NC.Items.Add(_Row[0].ToString().Trim());
            }
        }
        private void _Mtd_CargarData(string _Pr_Str_IdDev)
        {
            string _Str_Sql = "SELECT * FROM VST_TDEVVENTAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Pr_Str_IdDev + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodevol"]) == "B")
                {
                    _Rb_Bestado.Checked = true;
                }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodevol"]) == "M")
                {
                    _Rb_Mestado.Checked = true;
                }
                _Txt_IdDevol.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ciddevventa"]);
                _Txt_FechaDevol.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadev"]).ToShortDateString();
                _Mtd_CargarMotivos();
                _Cb_Motivo.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cidmotivo"]);
                
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cconfactura"]) == "1")
                {
                    _Rb_Cfact.Checked = true;
                    _Lbl_FactoCli.Text = "Factura:";
                    _Txt_Fact.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cfactura"]);
                }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["cconfactura"]) == "0")
                {
                    _Rb_Sfact.Checked = true;
                    _Lbl_FactoCli.Text = "Cliente:";
                    _Txt_Fact.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                }
                
                _Txt_Cliente.Text =Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]).Trim() + "-" + Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente_nombcomer"]).Trim();
                _Txt_Cliente.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]).Trim();
                _Cb_Vendedor.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]).Trim();
                if (_Cb_Vendedor.SelectedValue == null)
                {
                    _Mtd_CargarVendedoresCargado();
                    _Cb_Vendedor.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cvendedor"]).Trim();
                }
                _Txt_Cajas.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccajas"]).ToString("#,##0");
                _Txt_Unidades.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cunidades"]).ToString("#,##0");
                double _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostotot"]);
                double _Dbl_Impuesto = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostimp"]);
                double _Dbl_MontoSinImpuesto = _Dbl_MontoTotal - _Dbl_Impuesto;
                _Txt_Costo.Text = _Dbl_MontoSinImpuesto.ToString("#,##0.00");
                _Txt_MImpuesto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostimp"]).ToString("#,##0.00");
                
                _Txt_MontoTotal.Text = _Dbl_MontoTotal.ToString("#,##0.00");
                _Mtd_CargarDetalle(_Pr_Str_IdDev);
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA") && (_Ds.Tables[0].Rows[0]["cfimarnivel"].ToString().Trim() == "1"))
                {
                    _Bol_Tabs = true;
                    _Mtd_CargarMotivos();
                    _Cb_Motivo.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cidmotivo"]);
                    _Bol_Tabs = false;
                    _Mtd_DevoEnVentaConUnd2();
                    _Str_MyProceso = "F";
                    _Bt_Firma2.Enabled = true;
                    if (this.MdiParent != null) { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true; }
                    _Bt_Firma2.Visible = true;
                    _Btn_Rechazar.Enabled = true;
                    _Btn_Rechazar.Visible = true;
                    _Dg_GridDet.ReadOnly = true;
                }
                else
                {
                    _Lbl_Nota.Text = "";
                    _Str_MyProceso = "";
                    _Bt_Firma2.Enabled = false;
                    if (this.MdiParent != null) { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false; }
                    _Bt_Firma2.Visible = false;
                    _Btn_Rechazar.Enabled = false;
                    _Btn_Rechazar.Visible = false;
                }
            }
        }
        private void _Mtd_DevoEnVentaConUnd2()
        {
            try
            {
                string _Str_SQL = "select ccompany from VST_DEVOLVENTACONUND2VEN0 where ccompany='" + Frm_Padre._Str_Comp + "' and ciddevventa='" + _Txt_IdDevol.Text + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Lbl_Nota.Text = "LA DEVOLUCIÓN EN VENTA CONTIENE UNIDADES DE PRODUCTO(S) SIN UNIDAD DE MANEJO 2";
                }
                else
                {
                    _Lbl_Nota.Text = "";
                }
            }
            catch {}
        }

        private void _Mtd_CargarDetalle(string _Pr_Str_IdDev)
        {
            object[] _Str_RowNew = new object[14];
            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
            string _Str_Sql = "SELECT VST_TDEVVENTAD.cproducto,null,(produc_descrip + '.' + produc_descrip_2) as cnamef,null,null,ccajas,cunidades,ccostoxcaj,ccostoxund,ccostotot,cporcreconoce,ccostimp,ISNULL(CONVERT(NUMERIC(18,2),((ccostoxcaj*ccajas)*TTAX.cpercent)/100),0),ISNULL(CONVERT(NUMERIC(18,2),((ccostoxund*cunidades)*TTAX.cpercent)/100),0), cidproductod FROM VST_TDEVVENTAD INNER JOIN TPRODUCTO ON VST_TDEVVENTAD.cproducto = TPRODUCTO.cproducto LEFT JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE VST_TDEVVENTAD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_TDEVVENTAD.ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa=" + _Pr_Str_IdDev + " ORDER BY VST_TDEVVENTAD.cproducto";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_GridDet.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                string _Str_ProductoDetalle = "SELECT * FROM VST_PRODUCTOLOTE WHERE cidproductod='" + _DataR["cidproductod"].ToString() + "'";
                DataSet _Ds_Productos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_ProductoDetalle);
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length - 1);
                _Str_RowNew[3] = _Ds_Productos.Tables[0].Rows[0]["cidproductod"];
                _Str_RowNew[4] = _Ds_Productos.Tables[0].Rows[0]["cprecioventamax"];
                _Dg_GridDet.Rows.Add(_Str_RowNew);
                _Dg_GridDet["_Dg_GridDetCol_CxCaja", _Dg_GridDet.RowCount - 1].Value = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", _Dg_GridDet.RowCount - 1].Value).ToString("#,##0.00");
                _Dg_GridDet["_Dg_GridDetCol_CxUnd", _Dg_GridDet.RowCount - 1].Value = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxUnd", _Dg_GridDet.RowCount - 1].Value).ToString("#,##0.00");
                _Dg_GridDet["_Dg_GridDetCol_Total", _Dg_GridDet.RowCount - 1].Value = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Total", _Dg_GridDet.RowCount - 1].Value).ToString("#,##0.00");
                _Dg_GridDet["CodigoIDProducto", _Dg_GridDet.RowCount - 1].Value = _DataR["cidproductod"].ToString();
            }
            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
            _Dg_GridDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini(true);
            _Str_MyProceso = "A";
            _Mtd_Bloquear(true);
            _Dg_GridDet.AllowUserToDeleteRows = true;
            _Int_SwGuardar =1;
            _Tb_Tab.SelectTab(1);
        }
        /// <summary>
        /// Determina si la factura aún esta marcada como devolución parcial
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_DevolucionParcial()
        {
            string _Str_Cadena = "SELECT cfactura FROM TGUIADESPACHOD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura='" + _Txt_Fact.Text + "' AND ((c_estatus='FIR' AND c_tipdevolparcial='0') OR (c_estatus='PAG' AND (c_cancelaciontot='0' OR c_cancelaciontot='3')))";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        public bool _Mtd_Guardar()
        {
            string _Str_IdDev = "";
            bool _Bol_R = false;
            this.Cursor = Cursors.WaitCursor;
            if (_Mtd_ValidaSave())
            {
                try
                {
                    if (_Pnl_Clave.Visible)
                    {
                        if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_DEVOLVENTA") | _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_GUIA_CON_DEVOL"))
                        {
                            if (_myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                            {
                                
                                if (_Bol_Tabs) 
                                {
                                    if (_Mtd_DevolucionParcial())
                                    {
                                        if (_Int_SwGuardar == 1)
                                        {
                                            _Str_IdDev = _Mtd_GenerarDevolucion();
                                            MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se puede realizar la operación. El estatus de la factura ha sido cambiado por otro usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    if (!_Frm_Busqueda2.IsDisposed)
                                    { _Frm_Busqueda2._Mtd_Actualizar_Sw58(); }
                                    if ((Frm_Padre)this.MdiParent != null)
                                    {
                                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                    }
                                    this.Close(); 
                                }
                                else
                                {
                                    if (_Int_SwGuardar == 1)
                                    {
                                        _Str_IdDev = _Mtd_GenerarDevolucion();
                                        _Txt_IdDevol.Text = _Str_IdDev;
                                        _Txt_FechaDevol.Text = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                                        _Bol_R = true;
                                        _Mtd_Ini(true);
                                        _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                                        _Dt_Desde.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1);
                                        _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                                        _Tb_Tab.SelectTab(0);
                                        MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Clave incorrecta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Txt_Clave.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no está autorizado para cargar la devolución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                        _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Focus();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Problemas al guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_R = false;
                }
            }
            this.Cursor = Cursors.Default;
            return _Bol_R;
        }
        public bool _Mtd_Editar()
        {
            string _Str_NR = "", _Str_NC = "";
            string _Str_Sql = "";
            bool _Bol_R = false;
            this.Cursor = Cursors.WaitCursor;
            if (_Mtd_ValidaSave())
            {
                try
                {
                    if (_Pnl_Clave.Visible)
                    {
                        if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA"))
                        {
                            if (_myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                            {
                                if (!_Dg_GridDet.ReadOnly)
                                { _Mtd_EditarDevolucion(_Txt_IdDevol.Text); _Bol_R = true; }
                                else
                                {
                                    _Str_NR = _Mtd_GenerarNR();
                                    _Str_NC = _Mtd_GenerarNC(_Str_NR);
                                    _Str_Sql = "UPDATE TDEVVENTAM SET CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "',cidnotrecepc='" + _Str_NR + "',cfimarnivel=2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Txt_IdDevol.Text + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    _Bol_R = true;
                                    _Mtd_Ini(true);
                                    _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                                    _Dt_Desde.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1);
                                    _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                                    _Tb_Tab.SelectTab(0);
                                    if ((Frm_Padre)this.MdiParent != null)
                                    {
                                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                    }
                                }
                                MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Clave incorrecta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Txt_Clave.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no está autorizado para autorizar la devolución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                        _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                    }
                }
                catch (Exception _Ex)
                {
                    MessageBox.Show("Problemas al guardar." + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_R = false;
                }
            }
            this.Cursor = Cursors.Default;
            return _Bol_R;
        }
        private bool _Mtd_SegundaEdicion()
        {
            string _Str_NR = "", _Str_NC = "";
            string _Str_Sql = "";
            bool _Bol_R = false;
            this.Cursor = Cursors.WaitCursor;
            if (_Mtd_ValidaSave())
            {
                try
                {
                    if (_Pnl_Clave.Visible)
                    {
                        if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA"))
                        {
                            if (_myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                            {
                                _Mtd_EditarDevolucion(_Txt_IdDevol.Text);
                                _Pnl_Clave.Visible = false;
                                _Bol_R = true;
                                if ((Frm_Padre)this.MdiParent != null)
                                {
                                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                }
                                MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Clave incorrecta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Txt_Clave.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no está autorizado para autorizar la devolución", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                        _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                    }
                }
                catch (Exception _Ex)
                {
                    MessageBox.Show("Problemas al guardar." + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_R = false;
                }
            }
            this.Cursor = Cursors.Default;
            return _Bol_R;
        }

        public bool _Mtd_Rechazar()
        {
            string _Str_Sql;

            bool _Bol_R = false;
            
            Cursor = Cursors.WaitCursor;

            try
            {
                if (_Pnl_Clave.Visible)
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA"))
                    {
                        if (_myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                        {
                            _Str_Sql = "UPDATE TDEVVENTAM SET CDATEUPD=GETDATE(), CUSERUPD='" + Frm_Padre._Str_Use + "', cfimarnivel=2, canuladan=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _Txt_IdDevol.Text + "';";
                            
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                            _Bol_R = true;
                            _Mtd_Ini(true);
                            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                            _Dt_Desde.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1);
                            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
                            
                            _Tb_Tab.SelectTab(0);

                            if (MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)MdiParent)._Frm_Contenedor._async_Default);
                            }

                            MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Clave incorrecta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Txt_Clave.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no está autorizado para autorizar el rechazo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _Pnl_Clave.Left = (Width / 2) - (_Pnl_Clave.Width / 2);
                    _Pnl_Clave.Top = (Height / 2) - (_Pnl_Clave.Height / 2);
                    _Pnl_Clave.Parent = this;
                    _Pnl_Clave.BringToFront();
                    _Pnl_Clave.Visible = true;
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show("Problemas al guardar." + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _Bol_R = false;
            }

            Cursor = Cursors.Default;

            _Rbt_Rechazadas.Checked = true;

            return _Bol_R;
        }

        private bool _Mtd_ValidaSave()
        {
            bool _Bol_Sw = true;
            _Er_Error.Dispose();
            if (!_Rb_Bestado.Checked && !_Rb_Mestado.Checked)
            {
                _Er_Error.SetError(_Grb_TpoDev, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Cb_Motivo.SelectedIndex < 1)
            {
                _Er_Error.SetError(_Cb_Motivo, "Información requerida");
                _Bol_Sw = false;
            }
            if (!_Rb_Cfact.Checked && !_Rb_Sfact.Checked)
            {
                _Er_Error.SetError(_Grb_Fact, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Rb_Cfact.Checked)
            {
                if (_Txt_Fact.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Fact, "Información requerida");
                    _Bol_Sw = false;
                }
            }
            else if (_Rb_Sfact.Checked)
            {
                if (_Txt_Cliente.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Cliente, "Información requerida");
                    _Bol_Sw = false;
                }
            }
            if (_Cb_Vendedor.SelectedIndex < 1)
            {
                _Er_Error.SetError(_Cb_Vendedor, "Información requerida");
                _Bol_Sw = false;
            }
            if (_Bol_Sw)
            {
                if (!_Mtd_VerificarGirdDetalle())
                {
                    MessageBox.Show("Faltan datos en el detalle", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_Sw = false;
                }
                else
                {
                    _Bol_Sw = _Mtd_ValidaGridDetalle(true);
                }
            }
            return _Bol_Sw;
        }
        private bool _Mtd_VerificarGirdDetalle()
        {
            bool _Bol_Entrada = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_GridDet.Rows)
            {
                if (_Dg_Row.Cells["_Dg_GridDetCol_ProdId"].Value != null)
                {
                    if (Convert.ToString(_Dg_Row.Cells["_Dg_GridDetCol_ProdId"].Value).Trim().Length > 0) { if (_Dg_Row.Cells["_Dg_GridDetCol_Caja"].Value != null) { if (Convert.ToString(_Dg_Row.Cells["_Dg_GridDetCol_Caja"].Value).Trim().Length > 0) { if (Convert.ToInt32(_Dg_Row.Cells["_Dg_GridDetCol_Caja"].Value) > 0) { _Bol_Entrada = true; } } } }
                    if (Convert.ToString(_Dg_Row.Cells["_Dg_GridDetCol_ProdId"].Value).Trim().Length > 0) { if (_Dg_Row.Cells["_Dg_GridDetCol_Und"].Value != null) { if (Convert.ToString(_Dg_Row.Cells["_Dg_GridDetCol_Und"].Value).Trim().Length > 0) { if (Convert.ToInt32(_Dg_Row.Cells["_Dg_GridDetCol_Und"].Value) > 0) { _Bol_Entrada = true; } } } }
                }
            }
            return _Bol_Entrada;
        }
        private bool _Mtd_ValidaGridDetalle(bool _Pr_Bol_Msj)
        {
            bool _Bol_Sw = true;
            double _Dbl_Caja = 0, _Dbl_CostoXcaja=0,_Dbl_Und = 0, _Dbl_CostoXUnd=0;
            foreach (DataGridViewRow _DgRow in _Dg_GridDet.Rows)
            {
                _Dbl_Caja = 0;
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value).Length == 0)
                {
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value).Length > 0)
                    {
                        if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value).Length > 0)
                        {
                            _Dbl_CostoXcaja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value);
                        }
                        if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value).Length > 0)
                        {
                            _Dbl_Caja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value);
                        }
                        if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value).Length > 0)
                        {
                            _Dbl_CostoXUnd = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value);
                        }
                        if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Und"].Value).Length > 0)
                        {
                            _Dbl_Und = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Und"].Value);
                        }
                        if ((_Dbl_Caja == 0 || _Dbl_CostoXcaja == 0) && (_Dbl_Und == 0 || _Dbl_CostoXUnd == 0))
                        {
                            if (_Pr_Bol_Msj)
                            {
                                MessageBox.Show("No ha ingresado productos para realizar la devolución.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            _Bol_Sw = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value).Length > 0)
                    {
                        _Dbl_CostoXcaja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value);
                    }
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value).Length > 0)
                    {
                        _Dbl_Caja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value);
                    }
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value).Length > 0)
                    {
                        _Dbl_CostoXUnd = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value);
                    }
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Und"].Value).Length > 0)
                    {
                        _Dbl_Und = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Und"].Value);
                    }
                    if ((_Dbl_Caja == 0 || _Dbl_CostoXcaja == 0) && (_Dbl_Und == 0 || _Dbl_CostoXUnd == 0))
                    {
                        if (_Pr_Bol_Msj)
                        {
                            MessageBox.Show("Faltan datos por ingresar en el detalle de los productos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        _Bol_Sw = false;
                        break;
                    }
                }
            }
            return _Bol_Sw;
        }
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Frm_DevolVenta_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_GridDet);
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMotivo();
            Cursor = Cursors.Default;
            //_Mtd_Ini();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1);
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            //_Mtd_CargarConsulta();
            if (!_Bol_Tabs) { _Tb_Tab.SelectedIndex = 0; }
        }

        private void _Rb_Bestado_CheckedChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Rb_Bestado.Checked)
                {
                    _Cb_Motivo.Enabled = true;
                    _Cb_Motivo.SelectedIndex = -1;
                }
            }
        }

        private void _Rb_Mestado_CheckedChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Rb_Mestado.Checked)
                {
                    _Cb_Motivo.Enabled = true;
                    _Cb_Motivo.SelectedIndex = -1;
                }
            }
        }

        private void _Cb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Cb_Motivo.SelectedIndex > 0)
                {
                    _Rb_Cfact.Enabled = true;
                    _Rb_Sfact.Enabled = true;
                }
                else
                {
                    _Bt_Buscar.Enabled = false;
                    _Rb_Cfact.Enabled = false;
                    _Rb_Sfact.Enabled = false;
                    _Rb_Cfact.Checked = false;
                    _Rb_Sfact.Checked = false;
                    _Txt_Fact.Text = "";
                    _Txt_Cliente.Text = "";
                    _Txt_Cliente.Tag = "";
                    _Cb_Vendedor.SelectedIndex = -1;
                    _Lbl_FactoCli.Text = "Factura:";
                    _Dg_GridDet.Rows.Clear();
                }
            }
        }

        private void _Rb_Cfact_CheckedChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Rb_Cfact.Checked)
                {
                    _Cb_Vendedor.Enabled = false;
                    _Lbl_FactoCli.Text = "Factura:";
                    _Txt_Fact.Text = "";
                    _Txt_Cliente.Text = "";
                    _Txt_Cliente.Tag = "";
                    _Cb_Vendedor.SelectedIndex = -1;
                    _Dg_GridDet.Rows.Clear();
                    _Bt_Buscar.Enabled = true;
                }
            }
        }

        private void _Rb_Sfact_CheckedChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Rb_Sfact.Checked)
                {
                    _Lbl_FactoCli.Text = "Cliente:";
                    _Txt_Fact.Text = "";
                    _Txt_Cliente.Text = "";
                    _Txt_Cliente.Tag = "";
                    _Cb_Vendedor.SelectedIndex = -1;
                    _Dg_GridDet.Rows.Clear();
                    _Bt_Buscar.Enabled = true;
                }
            }
        }
        private string _Mtd_RetornarVendedorDeZona(string _P_Str_Factura)
        {
            string  _Str_Cadena = "SELECT TVENDEDOR.cvendedor FROM TZONAVENDEDOR INNER JOIN TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor INNER JOIN TFACTURAM ON TVENDEDOR.ccompany = TFACTURAM.ccompany AND TZONAVENDEDOR.c_zona = TFACTURAM.c_zona WHERE  (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TVENDEDOR.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TZONAVENDEDOR.cdelete = '0') AND (TVENDEDOR.c_activo = '1') AND (TVENDEDOR.cdelete = '0') AND (TVENDEDOR.c_tipo_vend = '1') AND (TFACTURAM.cfactura = '" + _P_Str_Factura + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            else
            {
                _Str_Cadena = "SELECT TFACTURAM.cvendedorc " +
                            "FROM TFACTURAM INNER JOIN " +
                            "TZONAVENDEDOR ON TFACTURAM.cvendedorc = TZONAVENDEDOR.cvendedor AND " +
                            "TFACTURAM.ccompany = TZONAVENDEDOR.ccompany INNER JOIN " +
                            "TZONACLIENTE ON TFACTURAM.ccliente = TZONACLIENTE.ccliente AND TFACTURAM.ccompany = TZONACLIENTE.ccompany AND " +
                            "TZONAVENDEDOR.c_zona = TZONACLIENTE.c_zona AND ISNULL(TZONAVENDEDOR.cdelete, 0) = ISNULL(TZONACLIENTE.cdelete, 0) INNER JOIN " +
                            "TVENDEDOR ON TZONAVENDEDOR.ccompany = TVENDEDOR.ccompany AND TZONAVENDEDOR.cvendedor = TVENDEDOR.cvendedor AND " +
                            "ISNULL(TZONAVENDEDOR.cdelete, 0) = ISNULL(TVENDEDOR.cdelete, 0) " +
                            "WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TFACTURAM.cfactura = '" + _P_Str_Factura + "') AND (TZONAVENDEDOR.cdelete = 0) AND " +
                            "(TVENDEDOR.c_activo = 1) AND (TVENDEDOR.c_tipo_vend = 1)";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
            }
            return "";
        }
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            this.Cursor = Cursors.WaitCursor;
            if (_Rb_Cfact.Checked)
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(24);
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult.Length > 0)
                {
                    _Mtd_CargarVendedores();
                    _Txt_Fact.Text = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                    _Str_Sql = "SELECT ccliente,c_nomb_comer,cvendedor FROM VST_FACTURA_ONLY WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_Fact.Text + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Txt_Cliente.Tag = _Ds.Tables[0].Rows[0][0].ToString();
                        _Txt_Cliente.Text = _Ds.Tables[0].Rows[0][0].ToString() + "-" + _Ds.Tables[0].Rows[0][1].ToString().Trim();
                        Cursor = Cursors.WaitCursor;
                        string _Str_VendedorDeZona = _Mtd_RetornarVendedorDeZona(_Txt_Fact.Text.Trim());
                        Cursor = Cursors.Default;
                        if (_Str_VendedorDeZona.Trim().Length > 0)
                        {
                            _Cb_Vendedor.SelectedValue = _Str_VendedorDeZona;
                            _Dg_GridDet.Rows.Clear();
                            _Dg_GridDet.RowCount = 1;
                            _Dg_GridDet.ReadOnly = false;
                            _Dg_GridDet.Rows[0].ReadOnly = true;
                            _Dg_GridDet.Rows[0].Cells["_Dg_GridDetCol_Caja"].ReadOnly = false;
                            _Dg_GridDet.Rows[0].Cells["_Dg_GridDetCol_CxCaja"].ReadOnly = false;
                            _Cb_Vendedor.Enabled = false;
                        }
                        else
                        {
                            string _Str_ZonaSinVendedor = "";
                            string _Str_SQL = "SELECT C_ZONA FROM TFACTURAM WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CFACTURA='" + _Txt_Fact.Text.Trim() + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Str_ZonaSinVendedor = _Ds.Tables[0].Rows[0][0].ToString();
                                _Dg_GridDet.Rows.Clear(); MessageBox.Show("La zona " + _Str_ZonaSinVendedor + " no tiene vendedor asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                _Dg_GridDet.Rows.Clear(); MessageBox.Show("La zona no tiene vendedor asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else if (_Rb_Sfact.Checked)
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(18, _Txt_Fact, _Txt_Cliente, 0, 1, "");
                _Frm.ShowDialog();
                _Txt_Cliente.Tag = _Txt_Fact.Text;
                _Txt_Cliente.Text = _Txt_Cliente.Text.Substring(_Txt_Cliente.Text.IndexOf("-")+1);
                _Cb_Vendedor.SelectedIndex = 0;
                _Cb_Vendedor.Enabled = true;
            }
            this.Cursor = Cursors.Default;
        }

        private void _Dg_GridDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((_Str_MyProceso == "A" | _Str_MyProceso == "F") && e.RowIndex > -1)
            {
                if (e.ColumnIndex == 1)
                {
                    DataSet _Ds;
                    int _Int_Manejo1 = 0;
                    bool _Bol_Sw = false, _Bol_Und2 = false, _Bol_CF=false;
                    string _Str_CodProd = "", _Str_ProdName = "", _Str_CodProdDetalle = "";
                    string _Str_PMV = "";
                    double _Dbl_CxCaja = 0, _Dbl_PorctjProv = 0, _Dbl_CostoNeto = 0, _Dbl_ImpT = 0, _Dbl_ImpD = 0, _Dbl_CajaFact = 0;
                    double _Dbl_PorcImp = 0, _Dbl_CxUnd = 0, _Int_UnidadesFact = 0;
                    int _Int_ContUnd2 = 0;
                    string _Str_CodProv = "";
                    string _Str_Sql = "";
                    if (_Rb_Cfact.Checked)
                    {
                        _Bol_CF = true;
                        Frm_Busqueda2 _Frm = new Frm_Busqueda2(25, " AND cfactura='" + _Txt_Fact.Text + "'");
                        _Frm.ShowDialog();
                        if (_Frm._Str_FrmResult.Length > 0)
                        {
                            _Str_CodProd = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                            _Str_ProdName = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().Trim();
                            _Str_CodProdDetalle = _Frm._Dg_Grid[6, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().Trim();
                            if (!_Mtd_VerificarDupliDgDetalle(_Str_CodProd, _Str_CodProdDetalle))
                            {
                                _Str_Sql = "SELECT ccostoneto_u1_bscdesc,ccostoneto_u1_bs,cproveedor,c_impuesto_bs,cempaques,cunidades,cunidad2,ccontenidoma2,ccontenidoma1,cidproductod,cprecioventamax FROM VST_FACTURAPRODUCTOD_2V2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cfactura='" + _Txt_Fact.Text + "' AND cproducto='" + _Str_CodProd + "' and cidproductod='"+_Str_CodProdDetalle+"'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma1"]).Trim().Length > 0)
                                    {
                                        _Int_Manejo1 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                                    }
                                    _Dbl_CostoNeto = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1_bscdesc"]);
                                    _Dbl_CajaFact = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cempaques"]);
                                    _Str_CodProdDetalle = _Ds.Tables[0].Rows[0]["cidproductod"].ToString();
                                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidades"]).Length > 0)
                                    {
                                        _Int_UnidadesFact = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cunidades"]);
                                    }
                                    _Dbl_CxCaja = _Dbl_CostoNeto;
                                    _Str_PMV = _Ds.Tables[0].Rows[0]["cprecioventamax"].ToString();
                                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidad2"]) == "1")
                                    {
                                        if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma2"]).Length > 0)
                                        {
                                            _Int_ContUnd2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                                        }
                                        _Dbl_CxUnd = _Dbl_CostoNeto / (_Int_Manejo1/_Int_ContUnd2);
                                        _Bol_Und2 = true;
                                    }
                                    _Str_CodProv = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                                }

                                if (_Rb_Bestado.Checked)
                                {

                                }
                                else if (_Rb_Mestado.Checked)
                                {
                                    _Str_Sql = "SELECT cporcmalsodica FROM TPROVEEDOR WHERE cproveedor='" + _Str_CodProv + "' AND (cglobal=1 OR ccompany='" + Frm_Padre._Str_Comp + "')";
                                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_Ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                                        {
                                            _Dbl_PorctjProv = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                                        }
                                    }
                                    if (_Dbl_PorctjProv > 0)
                                    {
                                        _Dbl_CxCaja = (_Dbl_CostoNeto * _Dbl_PorctjProv / 100);
                                    }
                                    else
                                    {

                                    }
                                    if (_Bol_Und2)
                                    {
                                        if (_Dbl_PorctjProv > 0)
                                        {
                                            _Dbl_CxUnd = ((_Dbl_CostoNeto / (_Int_Manejo1/_Int_ContUnd2)) * _Dbl_PorctjProv / 100);
                                        }
                                        else
                                        {
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se puede ingresar por devolución un lote de un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Bol_Sw = true;
                            }
                        }
                        else
                        {
                            _Bol_Sw = true;
                        }
                    }
                    else if (_Rb_Sfact.Checked)
                    {
                        _Dg_GridDet.Columns["_Dg_GridDetCol_CxCaja"].ReadOnly = false;
                        TextBox _MyTxt_Cod = new TextBox();
                        TextBox _MyTxt_Descrip = new TextBox();
                        TextBox _Txt_TextBoxLote = new TextBox();
                        TextBox _Txt_TextBoxPMV = new TextBox();
                        TextBox _Txt_TextBoxCodLote = new TextBox();
                        if (_Cb_Vendedor.SelectedIndex > 0)
                        {
                            Frm_BusquedaProductoLote _Frm_Prod = new Frm_BusquedaProductoLote(false, _MyTxt_Cod, _MyTxt_Descrip, _Txt_TextBoxLote, _Txt_TextBoxPMV, _Txt_TextBoxCodLote);
                            _Frm_Prod.ShowDialog();
                            if (_MyTxt_Cod.Text.Trim() != "")
                            {
                                _Str_CodProd = _MyTxt_Cod.Text;
                                _Str_CodProdDetalle = _Txt_TextBoxCodLote.Text;
                                _Str_ProdName = _MyTxt_Descrip.Text;
                                _Str_PMV = _Txt_TextBoxPMV.Text;
                                if (!_Mtd_VerificarDupliDgDetalle(_Str_CodProd, _Str_CodProdDetalle))
                                {
                                    if (_Rb_Bestado.Checked)
                                    {
                                        //LA LISTA DE PRECIOS POR CLIENTE
                                        _Dbl_CostoNeto = _Mtd_ListaPrecio_U1(_Txt_Cliente.Tag.ToString(), _Str_CodProd, _Str_CodProdDetalle);
                                        _Dbl_CxCaja = _Dbl_CostoNeto;
                                        _Str_Sql = "SELECT cunidad2,ccontenidoma2,ccontenidoma1,cidproductod,cprecioventamax FROM VST_PRODUCTOLOTE WHERE cidproductod='" + _Str_CodProdDetalle + "'";
                                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                        if (_Ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidad2"]) == "1")
                                            {
                                                _Int_Manejo1 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                                                _Int_ContUnd2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                                                _Dbl_CxUnd = (_Dbl_CostoNeto / (_Int_Manejo1 / _Int_ContUnd2));
                                                _Bol_Und2 = true;
                                            }
                                        }
                                    }
                                    else if (_Rb_Mestado.Checked)
                                    {
                                        bool _Bol_Regulado = false;
                                        string _Str_SQLPMV = "SELECT CREGPMV FROM TPRODUCTO WHERE CPRODUCTO='" + _MyTxt_Cod.Text.Trim() + "' AND (CREGPMV='1' OR CREGPMV='2')";
                                        DataSet _Ds_PMV = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQLPMV);
                                        if (_Ds_PMV.Tables[0].Rows.Count == 1)
                                        {
                                            _Bol_Regulado = true;
                                        }
                                        if (_Bol_Regulado)
                                        {
                                            _Str_Sql = "SELECT ccostobrutolote as ccostobruto_u1,cunidad2,ccontenidoma2,ccontenidoma1,cidproductod,cprecioventamax FROM VST_PRODUCTOLOTE WHERE cidproductod='" + _Str_CodProdDetalle + "'";
                                        }
                                        else
                                        {
                                            _Str_Sql = "SELECT ccostobruto_u1 as ccostobruto_u1,cunidad2,ccontenidoma2,ccontenidoma1,cidproductod,cprecioventamax FROM VST_PRODUCTOLOTE WHERE cidproductod='" + _Str_CodProdDetalle + "'";
                                        }
                                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                        if (_Ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccostobruto_u1"]).Length > 0)
                                            {
                                                _Dbl_CostoNeto = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u1"]);
                                            }
                                            _Dbl_CxCaja = _Dbl_CostoNeto;
                                            if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunidad2"]) == "1")
                                            {
                                                _Int_Manejo1 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                                                _Int_ContUnd2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                                                _Dbl_CxUnd = (_Dbl_CostoNeto / (_Int_Manejo1 / _Int_ContUnd2));
                                                _Bol_Und2 = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Este producto ya fue ingresado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    _Bol_Sw = true;
                                }
                            }
                            else
                            {
                                _Bol_Sw = true;
                            }
                        }
                        else
                        { MessageBox.Show("Debe seleccionar un vendedor", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); _Bol_Sw = true; }
                    }
                    if (!_Bol_Sw)
                    {
                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                        _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value = _Str_CodProd;
                        _Dg_GridDet["_Dg_GridDetCol_Descrip", e.RowIndex].Value = _Str_ProdName;
                        _Dg_GridDet["_Dg_GridDetCol_PotjProv", e.RowIndex].Value = _Dbl_PorctjProv.ToString("#,##0.000"); ;
                        _Dg_GridDet["_Dg_GridDetCol_CostoNeto", e.RowIndex].Value = _Dbl_CostoNeto.ToString("#,##0.000"); ;
                        _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_CxCaja.ToString("#,##0.000"); ;
                        _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value = 0;
                        _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                        _Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value = _Dbl_CxCaja;
                        _Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value = _Dbl_CxUnd;
                        _Dg_GridDet["_Dg_GridDetCol_NLote", e.RowIndex].Value = _Str_CodProdDetalle;
                        _Dg_GridDet["_Dg_GridDetCol_PMV", e.RowIndex].Value = _Str_PMV;
                        if (_Bol_Und2)
                        {
                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].ReadOnly = false;
                        }
                        else
                        {
                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].ReadOnly = true;
                        }
                        _Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].ReadOnly = false;
                        _Dg_GridDet["CodigoIDProducto", e.RowIndex].Value = _Str_CodProdDetalle;
                        _Dg_GridDet.CurrentCell = _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex];
                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                    }
                }
                else if(e.ColumnIndex==6)
                {
                    if (_Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value != null)
                    {
                        if (_Rb_Bestado.Checked)
                        {
                            string _Str_Sql = "select cproducto,cventaund2, ccontenidoma1,ccontenidoma2,cidproductod,cprecioventamax FROM VST_PRODUCTOLOTE WHERE (cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "') AND (cidproductod = '" + _Dg_GridDet["_Dg_GridDetCol_NLote", e.RowIndex].Value.ToString() + "')";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (_Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "1" || _Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "0")
                                {
                                    _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                                    {
                                        _Dg_GridDet.Rows[e.RowIndex].Cells["_Dg_GridDetCol_Und"].ReadOnly = false;
                                    }
                                    else
                                    {
                                        _Dg_GridDet.Rows[e.RowIndex].Cells["_Dg_GridDetCol_Und"].ReadOnly = true;
                                    }
                                    _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                }
                                else
                                {
                                    _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    _Dg_GridDet.Rows[e.RowIndex].Cells["_Dg_GridDetCol_Und"].ReadOnly = true;
                                    _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                }
                            }
                            else
                            {
                                _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                _Dg_GridDet.Rows[e.RowIndex].Cells["_Dg_GridDetCol_Und"].ReadOnly = true;
                                _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            }
                        }
                        else
                        {
                            _Dg_GridDet.Rows[e.RowIndex].Cells["_Dg_GridDetCol_Und"].ReadOnly = false;
                        }
                    }
                }
            }
        }
        private double _Mtd_Alicuota()
        {
            string _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCXC ON TTAX.ctax = TCONFIGCXC.ctax WHERE (TCONFIGCXC.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                { return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
            }
            return 0;
        }
        private bool _Mtd_ProductoConDPP(string _P_Str_Factura, string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT cproducto FROM VST_FACTURAPRODUCTOD_2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura=" + _P_Str_Factura + " AND cproducto='" + _P_Str_Producto + "' AND cdescppmonto>0";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private double _Mtd_PorcDPPProducto(string _P_Str_Factura, string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT ISNULL(cdescpp,0) FROM VST_FACTURAPRODUCTOD_2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura=" + _P_Str_Factura + " AND cproducto='" + _P_Str_Producto + "' AND cdescppmonto>0";
            return Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0]);
        }
        private string _Mtd_GenerarNC(string _Pr_Str_NR)
        {
            double _Dbl_Alicuota = 0;
            DataSet _Ds;
            string _Str_Sql = "", _Str_TpoDoc = "", _Str_NumDoc = "", _Str_FechaDoc = "", _Str_Descripcion="", _Str_FechVenc="";
            if (_Rb_Cfact.Checked)
            {
                _Str_Sql = "SELECT ctipodocumentfact FROM TCONFIGVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_TpoDoc = "'" + Convert.ToString(_Ds.Tables[0].Rows[0][0]) + "'";
                }
                _Str_NumDoc = "'" + _Txt_Fact.Text + "'";
                _Str_Sql = "SELECT * FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_Fact.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_FechaDoc = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_factura"]));
                    _Str_FechVenc = _Str_FechaDoc;
                    if (_Ds.Tables[0].Rows[0]["calicuota"] != System.DBNull.Value)
                    { _Dbl_Alicuota = Convert.ToDouble(_Ds.Tables[0].Rows[0]["calicuota"].ToString()); }
                }
                _Str_Descripcion = _Cb_Motivo.Text + " FACTURA# " + _Txt_Fact.Text.Trim() + " FEC: " + Convert.ToDateTime(_Str_FechaDoc).ToString("dd/MM/yyyy");
            }
            else if (_Rb_Sfact.Checked)
            {
                _Dbl_Alicuota = _Mtd_Alicuota();
                _Str_TpoDoc = "null";
                _Str_NumDoc = "null";
                _Str_FechaDoc = "null";
                _Str_FechVenc = "'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Date.ToShortDateString() + "'";
                _Str_Descripcion = _Cb_Motivo.Text;
            }
            _Mtd_GenerarNC_DET(_Txt_IdDevol.Text.Trim(), Convert.ToString(_Txt_Cliente.Tag).Trim(), _Str_TpoDoc, _Str_NumDoc, Convert.ToString(_Cb_Motivo.SelectedValue).Trim(), _Str_Descripcion, _Pr_Str_NR, Convert.ToString(_Cb_Vendedor.SelectedValue).Trim(), _Dbl_Alicuota);
            return "0";
        }
        private bool _Mtd_Existe_NC(string _P_Str_NC)
        {
            var _Str_Cadena =
                    "Select cidnotcredicc from TNOTACREDICC where cgroupcomp='" + Frm_Padre._Str_GroupComp +
                    "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _P_Str_NC + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena);
        }

        private string _Mtd_Id_NC(string _P_Str_ID_Devol)
        {
            var _Str_Cadena = "Select top 1 cidnotcredicc from TNOTACREDICC where cgroupcomp='" +
                              Frm_Padre._Str_GroupComp +
                              "' and ccompany='" + Frm_Padre._Str_Comp + "' and ciddevventa='" + _P_Str_ID_Devol +
                              "' order by cidnotcredicc desc";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                var _Str_NC = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_Cadena =
                    "Select cproducto from TNOTACREDICCD where cgroupcomp='" + Frm_Padre._Str_GroupComp +
                    "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _Str_NC + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count < 6)
                    return _Str_NC;
            }
            return _myUtilidad._Mtd_Correlativo("SELECT MAX(cidnotcredicc) FROM TNOTACREDICC WHERE cgroupcomp='" +
                                                Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp +
                                                "'");
        }

        private void _Mtd_GenerarNC_DET(string _P_Str_ID_Devol, string _P_Str_Cliente, string _P_Str_TipoDoc, string _P_Str_NumDoc, string _P_Str_Motivo, string _P_Str_Descripcion, string _P_Str_NR, string _P_Str_Vendedor, double _P_Dbl_Alicuota)
        {
        _Et_Retorno:
            string _Str_Cadena = "SELECT TOP 6 cproducto,SUM(ISNULL(ccostotot,0)-ISNULL(cexento,0)) AS ccostotot, SUM(ISNULL(ccostimp,0)) AS ccostimp, SUM(ISNULL(ccostotot,0) + ISNULL(ccostimp,0)) AS MontoTotal, SUM(ISNULL(cexento,0)) AS cexento FROM TDEVVENTAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _P_Str_ID_Devol + "' AND " +
                   "NOT EXISTS(SELECT TNOTACREDICCD.cproducto FROM TNOTACREDICC INNER JOIN TNOTACREDICCD ON TNOTACREDICC.cgroupcomp = TNOTACREDICCD.cgroupcomp AND " +
                   "TNOTACREDICC.ccompany = TNOTACREDICCD.ccompany AND TNOTACREDICC.cidnotcredicc = TNOTACREDICCD.cidnotcredicc AND " +
                   "TNOTACREDICC.cgroupcomp=TDEVVENTAD.cgroupcomp AND TNOTACREDICC.ccompany=TDEVVENTAD.ccompany AND TNOTACREDICC.ciddevventa=TDEVVENTAD.ciddevventa AND TNOTACREDICCD.cproducto=TDEVVENTAD.cproducto) GROUP BY TDEVVENTAD.cproducto";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_NC = _Mtd_Id_NC(_P_Str_ID_Devol);
                //----------------------
                if (!_Mtd_Existe_NC(_Str_NC))
                    _Mtd_GuardarDatosNC_DET(_Ds, _Str_NC, true, _P_Str_ID_Devol, _P_Str_Cliente, _P_Str_TipoDoc,_P_Str_NumDoc, _P_Str_Motivo, _P_Str_Descripcion, _P_Str_NR, _P_Str_Vendedor,_P_Dbl_Alicuota);
                _Mtd_GuardarDatosNC_DET(_Ds, _Str_NC, false, _P_Str_ID_Devol, _P_Str_Cliente, _P_Str_TipoDoc, _P_Str_NumDoc, _P_Str_Motivo, _P_Str_Descripcion, _P_Str_NR, _P_Str_Vendedor, _P_Dbl_Alicuota);
                goto _Et_Retorno;
            }
        }
        private void _Mtd_GuardarDatosNC_DET(DataSet _P_Ds, string _P_Str_NC, bool _P_Bol_Maestra, string _P_Str_ID_Devol, string _P_Str_Cliente, string _P_Str_TipoDoc, string _P_Str_NumDoc, string _P_Str_Motivo, string _P_Str_Descripcion, string _P_Str_NR, string _P_Str_Vendedor, double _P_Dbl_Alicuota)
        {
            string _Str_Cadena = "";
            double _Dbl_PorcDPPProducto = 0;
            double _Dbl_MontoSinImp = 0, _Dbl_MontoSinImp_D = 0, _Dbl_MontoSinImp_Dpp = 0;
            double _Dbl_Impuesto = 0, _Dbl_Impuesto_D = 0, _Dbl_Impuesto_Dpp = 0;
            double _Dbl_MontoExento = 0, _Dbl_MontoExento_D = 0, _Dbl_MontoExento_Dpp = 0;
            double _Dbl_MontoTotal = 0, _Dbl_MontoTotal_D = 0, _Dbl_MontoTotal_Dpp = 0;
            foreach (DataRow _Row in _P_Ds.Tables[0].Rows)
            {
                //-------
                _Dbl_MontoSinImp_Dpp = 0;
                _Dbl_Impuesto_Dpp = 0;
                _Dbl_MontoExento_Dpp = 0;
                _Dbl_MontoTotal_Dpp = 0;
                //-------
                _Dbl_MontoSinImp_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(Convert.ToDouble(_Row["ccostotot"].ToString()), 2);
                _Dbl_Impuesto_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(Convert.ToDouble(_Row["ccostimp"].ToString()), 2);
                _Dbl_MontoExento_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(Convert.ToDouble(_Row["cexento"].ToString()), 2);
                _Dbl_MontoTotal_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(Convert.ToDouble(_Row["MontoTotal"].ToString()), 2);
                //-------
                if (_P_Str_NumDoc.Trim() != "null")
                {
                    if (_Mtd_ProductoConDPP(_P_Str_NumDoc, _Row["cproducto"].ToString().Trim()))
                    {
                        _Dbl_PorcDPPProducto = _Mtd_PorcDPPProducto(_P_Str_NumDoc, _Row["cproducto"].ToString().Trim());
                        //-----
                        _Dbl_MontoSinImp_D = (100 * _Dbl_MontoSinImp_D) / (100 - _Dbl_PorcDPPProducto);
                        _Dbl_MontoSinImp_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_MontoSinImp_D,2);
                        _Dbl_Impuesto_D = (100 * _Dbl_Impuesto_D) / (100 - _Dbl_PorcDPPProducto);
                        _Dbl_Impuesto_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_Impuesto_D, 2);
                        _Dbl_MontoExento_D = (100 * _Dbl_MontoExento_D) / (100 - _Dbl_PorcDPPProducto);
                        _Dbl_MontoExento_D = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_MontoExento_D, 2);
                        _Dbl_MontoTotal_D = _Dbl_MontoSinImp_D + _Dbl_Impuesto_D + _Dbl_MontoExento_D;

                        _Dbl_MontoSinImp_Dpp = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((_Dbl_MontoSinImp_D * _Dbl_PorcDPPProducto) / 100, 2);
                        _Dbl_Impuesto_Dpp = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((_Dbl_Impuesto_D * _Dbl_PorcDPPProducto) / 100, 2);
                        _Dbl_MontoExento_Dpp = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((_Dbl_MontoExento_D * _Dbl_PorcDPPProducto) / 100, 2);
                        _Dbl_MontoTotal_Dpp = _Dbl_MontoSinImp_Dpp + _Dbl_Impuesto_Dpp + _Dbl_MontoExento_Dpp;
                        //-----
                        _Dbl_MontoSinImp_D = _Dbl_MontoSinImp_D - _Dbl_MontoSinImp_Dpp;
                        _Dbl_Impuesto_D = _Dbl_Impuesto_D - _Dbl_Impuesto_Dpp;
                        _Dbl_MontoExento_D = _Dbl_MontoExento_D - _Dbl_MontoExento_Dpp;
                        _Dbl_MontoTotal_D = _Dbl_MontoSinImp_D + _Dbl_Impuesto_D + _Dbl_MontoExento_D;
                    }
                }
                //-------
                _Dbl_MontoSinImp += _Dbl_MontoSinImp_D;
                _Dbl_Impuesto += _Dbl_Impuesto_D;
                _Dbl_MontoTotal += _Dbl_MontoTotal_D;
                _Dbl_MontoExento += _Dbl_MontoExento_D;
                if (!_P_Bol_Maestra)
                {
                    _Str_Cadena = "INSERT INTO TNOTACREDICCD (cgroupcomp,ccompany,cidnotcredicc,cproducto,ccajas,cunidades,cmontosimp,cimpuesto,cmontototal,cbasegrabada,cbasexcenta,calicuota,cmontosimpdpp,cimpuestodpp,cbasexcentadpp,cmontototaldpp) " +
                    "SELECT TDEVVENTAD.cgroupcomp, TDEVVENTAD.ccompany, '" + _P_Str_NC + "', TDEVVENTAD.cproducto, ISNULL(dbo.Fnc_ConvertUndCajasPro(dbo.TPRODUCTO.cproducto, dbo.Fnc_ConvertCajasUndPro(dbo.TPRODUCTO.cproducto, SUM(dbo.TDEVVENTAD.cunidades), " +
                    "SUM(TDEVVENTAD.ccajas), TPRODUCTO.ccontenidoma1, TPRODUCTO.ccontenidoma2, TPRODUCTO.cunidad2), 0, TPRODUCTO.ccontenidoma1, " +
                    "TPRODUCTO.ccontenidoma2, TPRODUCTO.cunidad2),0), ISNULL(dbo.Fnc_ConvertUndSobrantePro(TPRODUCTO.cproducto, " +
                    "dbo.Fnc_ConvertCajasUndPro(TPRODUCTO.cproducto, SUM(TDEVVENTAD.cunidades), SUM(TDEVVENTAD.ccajas), TPRODUCTO.ccontenidoma1, " +
                    "TPRODUCTO.ccontenidoma2, TPRODUCTO.cunidad2), TPRODUCTO.ccontenidoma1, TPRODUCTO.ccontenidoma2, TPRODUCTO.cunidad2),0), '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoSinImp_D) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto_D) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_D) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoSinImp_D) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExento_D) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Alicuota) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoSinImp_Dpp) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto_Dpp) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExento_Dpp) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_Dpp) + "' " +
                    "FROM TDEVVENTAD INNER JOIN TPRODUCTO ON TDEVVENTAD.cproducto=TPRODUCTO.cproducto WHERE TDEVVENTAD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TDEVVENTAD.ccompany='" + Frm_Padre._Str_Comp + "' AND TDEVVENTAD.ciddevventa='" + _P_Str_ID_Devol + "' AND TDEVVENTAD.cproducto='" + _Row["cproducto"].ToString().Trim() + "' " +
                    "GROUP BY TPRODUCTO.ccontenidoma1, TPRODUCTO.ccontenidoma2, TPRODUCTO.cunidad2, TDEVVENTAD.cproducto, TPRODUCTO.cproducto," +
                    "TDEVVENTAD.ccompany, TDEVVENTAD.cgroupcomp";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            if (_P_Bol_Maestra)
            {
                _Str_Cadena = "INSERT INTO TNOTACREDICC (cgroupcomp,ccompany,cidnotcredicc,ccliente,ctipodocument,cnumdocu,cfecha,cidmotivo,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cfvfnotcredcc,cdescontada,canulado,cactivo,cimpresa,cidnotrecepc,cdateadd,cuseradd,cvendedor,cvendedorc,calicuota,cexento,ciddevventa) VALUES " +
                "('" + Frm_Padre._Str_GroupComp + "', '" + Frm_Padre._Str_Comp + "', '" + _P_Str_NC + "', '" + _P_Str_Cliente + "', " + _P_Str_TipoDoc + ", " + _P_Str_NumDoc + ", '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "', '" + _P_Str_Motivo + "', '" + _P_Str_Descripcion + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoSinImp) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Impuesto) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "', 0,0,0,0, '" + _P_Str_NR + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _P_Str_Vendedor + "','" + _P_Str_Vendedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_Alicuota) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExento) + "','" + _P_Str_ID_Devol + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private string _Mtd_GenerarNR()
        {
            var _Str_Cadena = "Select cidnotrecepc from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp +
                                 "' and ccompany='" + Frm_Padre._Str_Comp + "' and ciddevventa='" +
                                 _Txt_IdDevol.Text.Trim() + "'";
            var _Ds_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_Ds.Tables[0].Rows.Count > 0)
                return _Ds_Ds.Tables[0].Rows[0][0].ToString().Trim();
            int _Int_Unidades = 0;
            double _Dbl_PorcImp = 0, _Dbl_CxUnd = 0, _Dbl_CxCaja = 0, _Dbl_Cajas = 0, _Dbl_Costo = 0, _Dbl_ImpCaja = 0, _Dbl_ImpUnd = 0;
            DataSet _Ds;
            string _Str_Sql = "", _Str_TpoRecep="", _Str_TpoDoc="", _Str_NumDoc="", _Str_FechaDoc="";
            string _Str_NR = "", _Str_NRd = "", _Str_ctrg_movinv = "";
            double _Dbl_MontoSimpDet = 0, _Dbl_MontoImpDet=0;
            if (_Rb_Bestado.Checked)
            {
                _Str_ctrg_movinv = "1";
            }
            else if (_Rb_Mestado.Checked)
            {
                _Str_ctrg_movinv = "0";
            }
            if (_Rb_Cfact.Checked)
            {
                _Str_Sql = "SELECT ctipodocumentfact FROM TCONFIGVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count>0)
                {
                    _Str_TpoDoc = "'" + Convert.ToString(_Ds.Tables[0].Rows[0][0]) + "'";
                }
                _Str_NumDoc = "'" + _Txt_Fact.Text + "'";
                _Str_Sql = "SELECT * FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Txt_Fact.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_FechaDoc = "'" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_factura"])) + "'";
                }

                if (_Rb_Bestado.Checked)
                {
                    _Str_TpoRecep = "A";
                }
                else if (_Rb_Mestado.Checked)
                {
                    _Str_TpoRecep = "B";
                }
            }
            else if (_Rb_Sfact.Checked)
            {
                _Str_TpoDoc = "null";
                _Str_NumDoc = "null";
                _Str_FechaDoc = "null";
                if (_Rb_Bestado.Checked)
                {
                    _Str_TpoRecep = "A";
                }
                else if (_Rb_Mestado.Checked)
                {
                    _Str_TpoRecep = "B";
                }
            }
            _Str_NR = _myUtilidad._Mtd_Correlativo("SELECT MAX(cidnotrecepc) FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
            _Str_Sql = "INSERT INTO TNOTARECEPC (cgroupcomp,ccompany,cidnotrecepc,cidrecepcion,ctiponotrecep,cfechanotrecep,ctipodocument,cnumdocu,cfechadocu,cmontosi,cmontoimp,cporcreconoce,cproveedor,cporcinvendible,cdateadd,cuseradd,ctrg_cxp,ctrg_movinv,cdelete,ciddevventa) VALUES(";
            _Str_Sql = _Str_Sql + "'" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_NR + "','0','" + _Str_TpoRecep + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'," + _Str_TpoDoc + "," + _Str_NumDoc + "," + _Str_FechaDoc + "," + _Txt_Costo.Text.Replace(".", "").Replace(",", ".") + "," + _Txt_MImpuesto.Text.Replace(".", "").Replace(",", ".") + ",0,null,0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0," + _Str_ctrg_movinv + ",0,'" + _Txt_IdDevol.Text.Trim() + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            foreach (DataGridViewRow _DgRow in _Dg_GridDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[0].Value).Trim().Length > 0)
                {
                    _Dbl_PorcImp=0;
                    _Str_Sql = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString() + "')";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                        {
                            _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                        }
                    }
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Und"].Value).Length > 0)
                    {
                        _Int_Unidades = Convert.ToInt32(_DgRow.Cells["_Dg_GridDetCol_Und"].Value);
                    }
                    if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value).Length > 0)
                    {
                        _Dbl_CxUnd = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value);
                    }
                    _Dbl_CxCaja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value);
                    _Dbl_Cajas = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value);
                    _Dbl_Costo = (_Dbl_CxCaja * _Dbl_Cajas) + (_Dbl_CxUnd * _Int_Unidades);
                    _Dbl_ImpCaja = ((_Dbl_CxCaja * _Dbl_Cajas) * _Dbl_PorcImp) / 100;
                    _Dbl_ImpUnd = ((_Dbl_CxUnd * _Int_Unidades) * _Dbl_PorcImp) / 100;
                    _Dbl_MontoImpDet = _Dbl_ImpCaja + _Dbl_ImpUnd;
                    _Dbl_MontoSimpDet = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Total"].Value);
                    _Str_NRd = _myUtilidad._Mtd_Correlativo("SELECT MAX(ciddnotrecepc) FROM TNOTARECEPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _Str_NR + "'");
                    _Str_Sql = "INSERT INTO TNOTARECEPD (cgroupcomp,ccompany,cidnotrecepc,ciddnotrecepc,cproducto,cempaques,cunidades,cmontosi,cmontoimp,cporcinvendible,cdateadd,cuseradd,cidrecepcion,cdelete,cidproductod) VALUES(";
                    _Str_Sql = _Str_Sql + "'" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_NR + "','" + _Str_NRd + "','" + _DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString() + "','" + _DgRow.Cells["_Dg_GridDetCol_Caja"].Value.ToString() + "'," + _DgRow.Cells["_Dg_GridDetCol_Und"].Value.ToString() + "," + _Dbl_MontoSimpDet.ToString().Replace(",", ".") + "," + _Dbl_MontoImpDet.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_PotjProv"].Value.ToString().Replace(".", "").Replace(",", ".") + ",'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,0,'" + Convert.ToString(_DgRow.Cells["CodigoIDProducto"].Value) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            return _Str_NR;
        }
        private string _Mtd_GenerarDevolucion()
        {
            double _Dbl_MontoImpDT = 0;
            string _Str_Sql = "", _Str_Factura = "", _Str_TipoDev="";
            int _Int_ConFact = 0;
            string _Str_DevID = "";
            
            if (_Rb_Cfact.Checked)
            {
                _Str_Factura = "'" + _Txt_Fact.Text + "'";
                _Int_ConFact = 1;
            }
            else if (_Rb_Sfact.Checked)
            {
                _Str_Factura = "0";
                _Int_ConFact = 0;
            }
            if (_Rb_Bestado.Checked)
            {
                _Str_TipoDev = "'B'";
            }
            else if (_Rb_Mestado.Checked)
            {
                _Str_TipoDev = "'M'";
            }
            _Str_DevID = _myUtilidad._Mtd_Correlativo("SELECT MAX(ciddevventa) FROM TDEVVENTAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
            _Str_Sql = "INSERT INTO TDEVVENTAM (cgroupcomp,ccompany,ciddevventa,ccliente,cfactura,ctipodevol,cconfactura,cfechadev,ccostotot,ccostimp,cvendedor,canuladan,cfimarnivel,cidmotivo,cdateadd,cuseradd,cdelete) VALUES(";
            _Str_Sql = _Str_Sql + "'" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_DevID + "','" + _Txt_Cliente.Tag.ToString() + "'," + _Str_Factura + "," + _Str_TipoDev + ",'" + _Int_ConFact.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'," + _Txt_MontoTotal.Text.Replace(".", "").Replace(",", ".") + "," + _Dbl_FrmImp.ToString().Replace(",", ".") + ",'" + _Cb_Vendedor.SelectedValue.ToString() + "',0,1,'" + _Cb_Motivo.SelectedValue.ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            double _Dbl_MontoExenSum=0;
            _Int_SwGuardar = 0;
            foreach (DataGridViewRow _DgRow in _Dg_GridDet.Rows)
            {
                double _Dbl_Exento=0;
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value).Trim().Length > 0)
                {
                    _Dbl_MontoImpDT = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_ImpCaja"].Value.ToString()) + Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_ImpUnd"].Value.ToString());
                    _Dbl_Exento = _Mtd_ExentoDetalle(_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString(), Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Total"].Value.ToString()));
                    _Dbl_MontoExenSum += _Dbl_Exento;
                    _Str_Sql = "INSERT INTO TDEVVENTAD (cgroupcomp,ccompany,ciddevventa,ccliente,cfactura,cproducto,cporcreconoce,ccajas,ccostoxcaj,ccostotot,ccostimp,cunidades,ccostoxund,CEXENTO,cidproductod) VALUES (";
                    _Str_Sql = _Str_Sql + "'" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_DevID + "','" + _Txt_Cliente.Tag.ToString() + "'," + _Str_Factura + ",'" + _DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString() + "'," + _DgRow.Cells["_Dg_GridDetCol_PotjProv"].Value.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_Caja"].Value.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value.ToString().Replace(".", "").Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_Total"].Value.ToString().Replace(".", "").Replace(",", ".") + "," + _Dbl_MontoImpDT.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_Und"].Value.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value.ToString().Replace(".", "").Replace(",", ".") + "," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Exento) + "," + Convert.ToString(_DgRow.Cells["CodigoIDProducto"].Value).Trim() + ")";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            _Str_Sql = "UPDATE TDEVVENTAM SET CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "',cexento=" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExenSum) + " where ccompany='" + Frm_Padre._Str_Comp + "' and ciddevventa='" + _Str_DevID + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_DevID;
        }
        private void _Mtd_EliminarFilasNulas()
        {
            int _Int_Count = _Dg_GridDet.Rows.Count - 1;
            for (int _Int_I = 0; _Int_I <= _Int_Count; _Int_I++)
            {
                if (Convert.ToString(_Dg_GridDet.Rows[_Int_I].Cells["_Dg_GridDetCol_ProdId"].Value).Trim().Length == 0)
                { _Dg_GridDet.Rows.RemoveAt(_Int_I); }
            }
        }
        private void _Mtd_EditarDevolucion(string _P_Str_Devolucion)
        {
            _Mtd_EliminarFilasNulas();
            double _Dbl_MontoImpDT = 0;
            string _Str_Sql = "", _Str_Factura = "0";
            if (_Txt_Fact.Text.Trim().Length > 0)
            {
                if (_Rb_Cfact.Checked)
                {
                    _Str_Factura = _Txt_Fact.Text.Trim();
                }
            }
            _Str_Sql = "DELETE FROM TDEVVENTAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _P_Str_Devolucion + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            double _Dbl_MontoExenSum = 0;
            foreach (DataGridViewRow _DgRow in _Dg_GridDet.Rows)
            {
                double _Dbl_Exento = 0;
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value).Trim().Length > 0)
                {
                    _Dbl_MontoImpDT = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_ImpCaja"].Value.ToString()) + Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_ImpUnd"].Value.ToString());
                    _Dbl_Exento = _Mtd_ExentoDetalle(_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString(), Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Total"].Value.ToString()));
                    _Dbl_MontoExenSum += _Dbl_Exento;
                    _Str_Sql = "INSERT INTO TDEVVENTAD (cgroupcomp,ccompany,ciddevventa,ccliente,cfactura,cproducto,cporcreconoce,ccajas,ccostoxcaj,ccostotot,ccostimp,cunidades,ccostoxund,CEXENTO,cidproductod) VALUES (";
                    _Str_Sql = _Str_Sql + "'" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_Devolucion + "','" + _Txt_Cliente.Tag.ToString() + "'," + _Str_Factura + ",'" + _DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString() + "'," + _DgRow.Cells["_Dg_GridDetCol_PotjProv"].Value.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_Caja"].Value.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value.ToString().Replace(".", "").Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_Total"].Value.ToString().Replace(".", "").Replace(",", ".") + "," + _Dbl_MontoImpDT.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_Und"].Value.ToString().Replace(",", ".") + "," + _DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value.ToString().Replace(".", "").Replace(",", ".") + "," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Exento) + "," + Convert.ToString(_DgRow.Cells["CodigoIDProducto"].Value) + ")";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            _Str_Sql = "UPDATE TDEVVENTAM SET CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "',cexento='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExenSum) + "',ccostotot='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoTotal.Text)) + "',ccostimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_FrmImp) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ciddevventa='" + _P_Str_Devolucion + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }
        private double _Mtd_ExentoDetalle(string _Str_Producto,double _Dbl_PrecioU)
        {
            double _Dbl_Exento = 0;
            try
            {
                string _Str_SentenciaSQL = "SELECT cimpuesto1 FROM TPRODUCTO WHERE CPRODUCTO='" + _Str_Producto + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                foreach(DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                {
                    if (_Dtw_Item["cimpuesto1"].ToString().TrimEnd() != "1")
                    {
                        _Dbl_Exento = _Dbl_PrecioU; 
                    }
                }
            }
            catch (Exception ou)
            {
                _Dbl_Exento = 0;
            }
            return _Dbl_Exento;
        }
        private void _Mtd_ExentoMaestra()
        {
        }
        private void _Mtd_Totalizar()
        {
            int _Int_Unidades = 0, _Int_UnidadesAcum=0;
            double _Dbl_CostoUndAcum = 0, _Dbl_Costo=0, _Dbl_ImpCaja=0, _Dbl_ImpUnd=0;
            double _Dbl_Caja = 0, _Dbl_CostoCaja = 0, _Dbl_Imp=0, _Dbl_CostoUnd=0;
            double _Dbl_CajaAcum = 0, _Dbl_CostoAcum = 0, _Dbl_CostoCajaAcum=0, _Dbl_CostoTotalAcum=0;
            _Dbl_FrmImp = 0;
            foreach (DataGridViewRow _DgRow in _Dg_GridDet.Rows)
            {
                
                _Dbl_Caja = 0;
                _Dbl_CostoCaja = 0;
                _Dbl_CostoUnd = 0;
                _Dbl_Imp = 0; 
                _Int_Unidades = 0;
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Und"].Value) != "")
                {
                    _Int_Unidades = Convert.ToInt32(_DgRow.Cells["_Dg_GridDetCol_Und"].Value);
                }
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value) != "")
                {
                    _Dbl_Caja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_Caja"].Value);
                }
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value) != "")
                {
                    _Dbl_CostoCaja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxCaja"].Value);
                }
                if (Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value) != "")
                {
                    _Dbl_CostoUnd = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_CxUnd"].Value);
                }
                if (_DgRow.Cells["_Dg_GridDetCol_ImpCaja"].Value == null)
                {
                    _Dbl_ImpCaja = 0;
                }
                else
                {
                    if (_DgRow.Cells["_Dg_GridDetCol_ImpCaja"].Value.ToString() != "")
                    {
                        _Dbl_ImpCaja = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_ImpCaja"].Value);
                    }
                    else
                    {
                        _Dbl_ImpCaja = 0;
                    }
                }
                if (_DgRow.Cells["_Dg_GridDetCol_ImpUnd"].Value != null)
                {
                    if (_DgRow.Cells["_Dg_GridDetCol_ImpUnd"].Value.ToString() == "")
                    {
                        _DgRow.Cells["_Dg_GridDetCol_ImpUnd"].Value = "0";
                    }
                    else
                    {
                        _Dbl_ImpUnd = Convert.ToDouble(_DgRow.Cells["_Dg_GridDetCol_ImpUnd"].Value);
                    }
                }
                else
                {
                    _Dbl_ImpUnd = 0;
                }                
                _Dbl_Imp = _Dbl_ImpCaja + _Dbl_ImpUnd;                
                _Dbl_CajaAcum = _Dbl_CajaAcum + _Dbl_Caja;
                _Int_UnidadesAcum = _Int_UnidadesAcum + _Int_Unidades;
                if (_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value != null)
                {
                    if (_Rb_Mestado.Checked)
                    {
                        string _Str_Sql = "select TOP 1 TPROVEEDOR.cpordevmalestado from TPROVEEDOR INNER JOIN TPRODUCTO ON TPROVEEDOR.CPROVEEDOR=TPRODUCTO.CPROVEEDOR WHERE TPRODUCTO.CPRODUCTO='" + _DgRow.Cells["_Dg_GridDetCol_ProdId"].Value.ToString() + "'";
                        double _Dbl_DevRecono = 0;
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                _Dbl_DevRecono = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                                _Dbl_CostoCajaAcum = _Dbl_CostoCajaAcum + (((_Dbl_CostoCaja * _Dbl_DevRecono) / 100) * _Dbl_Caja);
                                _Dbl_CostoUndAcum = _Dbl_CostoUndAcum + (((_Dbl_CostoUnd * _Dbl_DevRecono) / 100) * _Int_Unidades);
                                _Dbl_Costo = (_Dbl_CostoCaja * _Dbl_Caja) + (_Dbl_CostoUnd * _Int_Unidades);
                                _Dbl_Costo = _Dbl_Costo * _Dbl_DevRecono / 100;
                            }
                        }
                    }
                    else
                    {
                        _Dbl_CostoCajaAcum = _Dbl_CostoCajaAcum + (_Dbl_CostoCaja * _Dbl_Caja);
                        _Dbl_CostoUndAcum = _Dbl_CostoUndAcum + (_Dbl_CostoUnd * _Int_Unidades);
                        _Dbl_Costo = (_Dbl_CostoCaja * _Dbl_Caja) + (_Dbl_CostoUnd * _Int_Unidades);
                    }
                }
                else
                {
                    _Dbl_Costo = 0;
                }
                _Dbl_CostoAcum = _Dbl_CostoAcum + Math.Round(_Dbl_Costo, 2);
                _Dbl_FrmImp = _Dbl_FrmImp + _Dbl_Imp;
            }
            _Txt_Cajas.Text = _Dbl_CajaAcum.ToString("#,##0");
            _Txt_Unidades.Text = _Int_UnidadesAcum.ToString("#,##0");
            _Txt_Costo.Text = _Dbl_CostoAcum.ToString("#,##0.00");
            _Txt_MImpuesto.Text = _Dbl_FrmImp.ToString("#,##0.00");
            _Dbl_CostoTotalAcum = _Dbl_FrmImp + _Dbl_CostoAcum;
            _Txt_MontoTotal.Text = _Dbl_CostoTotalAcum.ToString("#,##0.00");
            _Dbl_FrmMontoSimp = _Dbl_CostoAcum;
        }

        private void _Dg_GridDet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_Dg_GridDet.CurrentCell.ColumnIndex == 5 || _Dg_GridDet.CurrentCell.ColumnIndex == 6)
            {
                if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_ProdId", _Dg_GridDet.CurrentCell.RowIndex].Value).Length == 0)
                {
                    ((TextBox)e.Control).ReadOnly = true;
                }
                else
                {
                    ((TextBox)e.Control).ReadOnly = false;
                }
                e.Control.KeyPress += new KeyPressEventHandler(_Dg_GridDetCell_KeyPress);
            }
        }
        private void _Dg_GridDetCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_GridDet.CurrentCell.ColumnIndex == 7)
            {
                _myUtilidad._Mtd_Valida_Numeros(((TextBox)sender), e, 10, 2);
            }
            else
            {
                _myUtilidad._Mtd_Valida_Numeros(((TextBox)sender), e, 10, 0);
            }
        }
        private double _Mtd_ListaPrecio_U1(string _P_Str_Cliente, string _P_Str_Producto, string _P_Str_CodLote)
        {
            double _Dbl_Lista = 0;
            string _Str_Sentencia_SQL = "";
            bool _Bol_Regulado = false;
            _Str_Sentencia_SQL = "SELECT CREGPMV FROM TPRODUCTO WHERE CPRODUCTO='"+_P_Str_Producto+"' AND (CREGPMV='1' OR CREGPMV='2')";
            DataSet _Ds_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sentencia_SQL);
            if (_Ds_.Tables[0].Rows.Count == 1)
            {
                _Bol_Regulado = true;
            }
            _Str_Sentencia_SQL = "select TTCANAL.clistaprecio,TTCANAL.cprecio from TCLIENTE INNER JOIN TTESTABLECIM ON TCLIENTE.c_estable = TTESTABLECIM.ctestablecim INNER JOIN TTCANAL ON TTCANAL.ccanal=TTESTABLECIM.ccanal where TCLIENTE.ccliente='" + _P_Str_Cliente + "' and TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Ds_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sentencia_SQL);
            foreach (DataRow _Dtw_Item in _Ds_.Tables[0].Rows)
            {
                if (_Dtw_Item["clistaprecio"].ToString().TrimEnd() != "")
                {
                    string _Str_Listado = "clistprecio" + _Dtw_Item["clistaprecio"].ToString().TrimEnd();
                    if (_Bol_Regulado)
                    {
                        _Str_Sentencia_SQL = "SELECT TPRODUCTOD.CCOSTOBRUTOLOTE + ((" + _Str_Listado + " * TPRODUCTOD.CCOSTOBRUTOLOTE) / 100) AS Precioventa FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO where TPRODUCTO.cproducto='" + _P_Str_Producto + "' and TPRODUCTOD.CIDPRODUCTOD='" + _P_Str_CodLote + "'";
                    }
                    else
                    {
                        _Str_Sentencia_SQL = "SELECT ccostobruto_u1 + ((" + _Str_Listado + " * ccostobruto_u1) / 100) AS Precioventa FROM TPRODUCTO where cproducto='" + _P_Str_Producto + "'";
                    }
                    DataSet _Ds_2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sentencia_SQL);
                    foreach (DataRow _Dtw_Item2 in _Ds_2.Tables[0].Rows)
                    {
                        if (_Dtw_Item2["Precioventa"].ToString().TrimEnd() != "")
                        {
                            _Dbl_Lista = Convert.ToDouble(_Dtw_Item2["Precioventa"].ToString().TrimEnd());
                        }
                    }
                }
            }
            return _Dbl_Lista;
        }

        private void _Dg_GridDet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((_Str_MyProceso == "A" | _Str_MyProceso == "F"))
            {
                DataSet _Ds;
                bool _Bol_SwStop = false;
                string _Str_Sql = "";
                double _Dbl_ImpCaja = 0, _Dbl_ImpUnd = 0, _Dbl_PorcImp=0, _Dbl_Exento=0;
                double _Dbl_Cajas = 0, _Dbl_CxCaja = 0, _Dbl_Costo = 0, _Dbl_CxUnd = 0;
                int _Int_Unidades = 0;
                if (_Dg_GridDet.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 5)
                    {
                        if (_Rb_Cfact.Checked)
                        {
                            int _Int_UniMinDev = 0;
                            if (_Txt_IdDevol.Text.Trim().Length > 0)
                            {
                                _Str_Sql = "Select cproducto as Producto,cnamefc as [Descripción],UniMin,ccontenidoma1,ccontenidoma2 FROM VST_DEVOLUCIONDETALLELOTE WHERE ciddevventa='" + _Txt_IdDevol.Text + "' and CIDPRODUCTOD='" + _Dg_GridDet["CodigoIDProducto", e.RowIndex].Value.ToString() + "' AND ccompany='" + Frm_Padre._Str_Comp + "'  AND cfactura=" + _Txt_Fact.Text + " and cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Int_UniMinDev = Convert.ToInt32(_Ds.Tables[0].Rows[0]["UniMin"].ToString());
                                }
                            }
                            _Str_Sql = "Select cproducto as Producto,cnamefc as [Descripción],UniMin,ccontenidoma1,ccontenidoma2 FROM VST_FACTURDEVDETALLE_3 WHERE CIDPRODUCTOD='" + _Dg_GridDet["CodigoIDProducto", e.RowIndex].Value.ToString() + "' AND ccompany='" + Frm_Padre._Str_Comp + "'  AND cfactura=" + _Txt_Fact.Text + " and cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";                            
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Str_Sql = "select dbo.unidadesaempaquesped('" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'," + (Convert.ToInt32(_Ds.Tables[0].Rows[0]["UniMin"]) + _Int_UniMinDev) + ")";
                                DataSet _Ds_Descompone = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value) > Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0]))
                                {
                                    //NO SE PUEDE DEVOLVER
                                    MessageBox.Show("El máximo de cajas que puede ingresar es " + Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0]).ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value = 0;
                                    _Bol_SwStop = true;
                                }
                                if (Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0]) > 0)
                                {
                                    if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value) > 0)
                                    {
                                        double _Dbl_UniMin = 0;
                                        double _Dbl_UniMinDevol = 0;
                                        _Dbl_UniMin = Convert.ToInt32(_Ds.Tables[0].Rows[0]["UniMin"])+_Int_UniMinDev;
                                        string _Str_Caj = "0";
                                        if (_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value != null)
                                        {
                                            _Str_Caj = _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value.ToString();
                                        }
                                        string _Str_Uni = "0";
                                        if (_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value != null)
                                        {
                                            _Str_Uni = _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value.ToString();
                                        }
                                        _Str_Sql = "select dbo.empaquesaunidadesped('" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'," + _Str_Caj + "," + _Str_Uni + ")";
                                        _Ds_Descompone = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                        _Dbl_UniMinDevol = Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0].ToString());
                                        if (_Dbl_UniMinDevol > _Dbl_UniMin)
                                        {
                                            double _Dbl_Resta = _Dbl_UniMin;
                                            _Str_Sql = "select dbo._Fnc_ModUnidadesRestantes('" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'," + _Dbl_Resta.ToString() + ")";
                                            _Ds_Descompone = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                            //NO SE PUEDE DEVOLVER
                                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                            MessageBox.Show("El máximo de unidades que puede ingresar es " + Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0]).ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            _Bol_SwStop = true;
                                        }
                                    }
                                }
                                _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            }
                        }
                        if (!_Bol_SwStop)
                        {
                            _Dbl_PorcImp = 0;
                            _Str_Sql = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "')";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                                {
                                    _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                                }
                            }

                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value).Length > 0)
                            {
                                _Int_Unidades = Convert.ToInt32(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value);
                            }
                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value).Length > 0)
                            {
                                _Dbl_CxUnd = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value);
                            }
                            _Dbl_CxCaja = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value);
                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value).Trim().Length == 0)
                            {
                                _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value = "0";
                            }
                            _Dbl_Cajas = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value);
                            _Dbl_Costo = (_Dbl_CxCaja * _Dbl_Cajas) + (_Dbl_CxUnd * _Int_Unidades);
                            _Dbl_ImpCaja = ((_Dbl_CxCaja * _Dbl_Cajas) * _Dbl_PorcImp) / 100;
                            _Dbl_ImpUnd = ((_Dbl_CxUnd * _Int_Unidades) * _Dbl_PorcImp) / 100;
                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_ImpCaja.ToString("#,##0.00");
                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = _Dbl_ImpUnd.ToString("#,##0.00");
                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            if (_Rb_Mestado.Checked)
                            {
                                _Str_Sql = "select TOP 1 TPROVEEDOR.cpordevmalestado from TPROVEEDOR INNER JOIN TPRODUCTO ON TPROVEEDOR.CPROVEEDOR=TPRODUCTO.CPROVEEDOR WHERE TPRODUCTO.CPRODUCTO='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";
                                double _Dbl_DevRecono = 0;
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (_Ds.Tables[0].Rows[0][0].ToString() != "")
                                    {
                                        _Dbl_DevRecono = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                                        if (_Dbl_DevRecono == 0)
                                        {
                                            //_Dg_GridDet.Rows.RemoveAt(e.RowIndex);
                                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                            for (int i = 0; i <= 13; i++)
                                            {
                                                _Dg_GridDet[i, e.RowIndex].Value = "";
                                            }
                                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                            MessageBox.Show("El proveedor del producto no reconoce producto en mal estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {
                                            _Dbl_Costo = (_Dbl_Costo * _Dbl_DevRecono) / 100;
                                            _Dbl_ImpCaja = (_Dbl_ImpCaja * _Dbl_DevRecono) / 100;
                                            _Dbl_ImpUnd = (_Dbl_ImpUnd * _Dbl_DevRecono) / 100;
                                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_ImpCaja.ToString("#,##0.00");
                                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = _Dbl_ImpUnd.ToString("#,##0.00");
                                        }
                                    }
                                    else
                                    {
                                        //_Dg_GridDet.Rows.RemoveAt(e.RowIndex);
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        for (int i = 0; i <= 13; i++)
                                        {
                                            _Dg_GridDet[i, e.RowIndex].Value = "";
                                        }
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        MessageBox.Show("El proveedor del producto no reconoce producto en mal estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                            }
                            _Mtd_Totalizar();
                        }
                    }
                    else if (e.ColumnIndex == 6)
                    {
                        if (_Rb_Cfact.Checked)
                        {
                            int _Int_UniMinDev = 0;
                            if (_Txt_IdDevol.Text.Trim().Length > 0)
                            {
                                _Str_Sql = "Select cproducto as Producto,cnamefc as [Descripción],UniMin,ccontenidoma1,ccontenidoma2 FROM VST_DEVOLUCIONDETALLELOTE WHERE ciddevventa='" + _Txt_IdDevol.Text + "' and CIDPRODUCTOD='" + _Dg_GridDet["CodigoIDProducto", e.RowIndex].Value.ToString() + "' AND ccompany='" + Frm_Padre._Str_Comp + "'  AND cfactura=" + _Txt_Fact.Text + " and cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Int_UniMinDev = Convert.ToInt32(_Ds.Tables[0].Rows[0]["UniMin"].ToString());
                                }
                            }
                             _Str_Sql = "Select cproducto as Producto,cnamefc as [Descripción],UniMin,ccontenidoma1,ccontenidoma2,cventaund2 FROM VST_FACTURDEVDETALLE_3 WHERE CIDPRODUCTOD='" + _Dg_GridDet["CodigoIDProducto", e.RowIndex].Value.ToString() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cfactura=" + _Txt_Fact.Text + " and cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (_Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "1" || _Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "0")
                                {
                                    if (_Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "0")
                                    {
                                        _Lbl_Nota.Text = "EL PRODUCTO " + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + " NO SE VENDE POR UNIDADES";
                                    }
                                    _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                                    {
                                        double _Dbl_CalculoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                                        if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value) > (_Dbl_CalculoUnd-1))
                                        {
                                            MessageBox.Show("El máximo de unidades que puede ingresar es " + Convert.ToString(_Dbl_CalculoUnd - 1), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                            _Bol_SwStop = true;
                                        }
                                        else
                                        {
                                            double _Dbl_UniMin = 0;
                                            double _Dbl_UniMinDevol = 0;
                                            _Dbl_UniMin = Convert.ToInt32(_Ds.Tables[0].Rows[0]["UniMin"]) + _Int_UniMinDev;
                                            string _Str_Caj = "0";
                                            if (_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value != null)
                                            {
                                                _Str_Caj = _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value.ToString();
                                            }
                                            string _Str_Uni = "0";
                                            if (_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value != null)
                                            {
                                                _Str_Uni = _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value.ToString();
                                            }
                                            _Str_Sql = "select dbo.Fnc_EmpaquesAUnidadesProducto('" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'," + _Str_Caj + "," + _Str_Uni + ")";
                                           DataSet _Ds_Descompone = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                           _Dbl_UniMinDevol = Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0].ToString());
                                           if (_Dbl_UniMinDevol > _Dbl_UniMin)
                                            {
                                                double _Dbl_Resta = _Dbl_UniMin;
                                                _Str_Sql = "select dbo.Fnc_ModUnidadesRestantesProducto('" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'," + _Dbl_Resta.ToString() + ")";
                                                _Ds_Descompone = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                                //NO SE PUEDE DEVOLVER
                                                MessageBox.Show("El máximo de unidades que puede ingresar es " + Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0].ToString()), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                                _Bol_SwStop = true;
                                            }
                                            _Str_Sql = "select dbo.unidadesaempaquesped('" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'," + Convert.ToDouble(_Ds.Tables[0].Rows[0]["UniMin"]).ToString("#,##0")+")";
                                            _Ds_Descompone = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                            if (Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0]) > 0)
                                            {
                                                if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value) > 0)
                                                {
                                                    if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value) > Convert.ToDouble(Convert.ToDouble(_Ds_Descompone.Tables[0].Rows[0][0])))
                                                    {
                                                        //NO SE PUEDE DEVOLVER
                                                        _Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value = 0;
                                                        MessageBox.Show("El máximo de cajas que puede ingresar es " + Convert.ToDouble(_Ds.Tables[0].Rows[0]["Cajas"]).ToString("#,##0.00"), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        _Bol_SwStop = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                        _Bol_SwStop = true;
                                    }
                                    _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                }
                                else
                                {
                                    if (_Rb_Mestado.Checked || _Rb_Bestado.Checked)
                                    {
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                                        {
                                            double _Dbl_CalculoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                                            if (Convert.ToDouble(_Dg_GridDet[4, e.RowIndex].Value) > _Dbl_CalculoUnd)
                                            {
                                                MessageBox.Show("El máximo de unidades que puede ingresar es " + _Dbl_CalculoUnd.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                                _Bol_SwStop = true;
                                            }
                                        }
                                        else
                                        {
                                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                            _Bol_SwStop = true;
                                        }
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    }
                                    else
                                    {
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                        _Bol_SwStop = true;
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    }
                                }
                            }
                            else
                            {
                                _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                _Bol_SwStop = true;
                                _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            }
                        }
                        else
                        {
                            _Str_Sql = "select cproducto,cventaund2, ccontenidoma1,ccontenidoma2,cidproductod,cprecioventamax FROM VST_PRODUCTOLOTE WHERE (cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "') AND (cidproductod = '" + _Dg_GridDet["_Dg_GridDetCol_NLote", e.RowIndex].Value.ToString() + "')";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (_Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "1" || _Ds.Tables[0].Rows[0]["cventaund2"].ToString() == "0")
                                {                                    
                                    _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                                    {
                                        double _Dbl_CalculoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                                        if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value) > _Dbl_CalculoUnd)
                                        {
                                            MessageBox.Show("El máximo de unidades que puede ingresar es " + _Dbl_CalculoUnd.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                            _Bol_SwStop = true;
                                        }
                                    }
                                    else
                                    {
                                        _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                        _Bol_SwStop = true;
                                    }
                                    _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                }
                                else
                                {
                                    if (_Rb_Mestado.Checked)
                                    {
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                                        {
                                            double _Dbl_CalculoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                                            if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value) > _Dbl_CalculoUnd)
                                            {
                                                MessageBox.Show("El máximo de unidades que puede ingresar es " + _Dbl_CalculoUnd.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                                _Bol_SwStop = true;
                                            }
                                        }
                                        else
                                        {
                                            _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                            _Bol_SwStop = true;
                                        }
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    }
                                    else
                                    {
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                        _Bol_SwStop = true;
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                    }
                                }
                            }
                            else
                            {
                                _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                _Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value = 0;
                                _Bol_SwStop = true;
                                _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            }
                        }
                        if (!_Bol_SwStop)
                        {
                            _Dbl_PorcImp = 0;
                            _Str_Sql = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "')";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                                {
                                    _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                                }
                            }

                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value).Length > 0)
                            {
                                _Int_Unidades = Convert.ToInt32(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value);
                            }
                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value).Length > 0)
                            {
                                _Dbl_CxUnd = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value);
                            }
                            _Dbl_CxCaja = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value);
                            _Dbl_Cajas = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value);
                            _Dbl_Costo = (_Dbl_CxCaja * _Dbl_Cajas) + (_Dbl_CxUnd * _Int_Unidades);
                            _Dbl_ImpCaja = ((_Dbl_CxCaja * _Dbl_Cajas) * _Dbl_PorcImp) / 100;
                            _Dbl_ImpUnd = ((_Dbl_CxUnd * _Int_Unidades) * _Dbl_PorcImp) / 100;
                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_ImpCaja.ToString("#,##0.00");
                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = _Dbl_ImpUnd.ToString("#,##0.00");
                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            if (_Rb_Mestado.Checked)
                            {
                                _Str_Sql = "select TOP 1 TPROVEEDOR.cpordevmalestado from TPROVEEDOR INNER JOIN TPRODUCTO ON TPROVEEDOR.CPROVEEDOR=TPRODUCTO.CPROVEEDOR WHERE TPRODUCTO.CPRODUCTO='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";
                                double _Dbl_DevRecono = 0;
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (_Ds.Tables[0].Rows[0][0].ToString() != "")
                                    {
                                        _Dbl_DevRecono = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                                        if (_Dbl_DevRecono == 0)
                                        {
                                            //_Dg_GridDet.Rows.RemoveAt(e.RowIndex);
                                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                            for (int i = 0; i <= 13; i++)
                                            {
                                                _Dg_GridDet[i, e.RowIndex].Value = "";
                                            }
                                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                            MessageBox.Show("El proveedor del producto no reconoce producto en mal estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {
                                            _Dbl_Costo = (_Dbl_Costo * _Dbl_DevRecono) / 100;
                                            _Dbl_ImpCaja = (_Dbl_ImpCaja * _Dbl_DevRecono) / 100;
                                            _Dbl_ImpUnd = (_Dbl_ImpUnd * _Dbl_DevRecono) / 100;
                                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_ImpCaja.ToString("#,##0.00");
                                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = _Dbl_ImpUnd.ToString("#,##0.00");
                                        }
                                    }
                                    else
                                    {
                                        //_Dg_GridDet.Rows.RemoveAt(e.RowIndex);
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        for (int i = 0; i <= 13; i++)
                                        {
                                            _Dg_GridDet[i, e.RowIndex].Value = "";
                                        }
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        MessageBox.Show("El proveedor del producto no reconoce producto en mal estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                            }
                            _Mtd_Totalizar();
                        }
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value) > Math.Round(Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CostoNeto", e.RowIndex].Value), 2))
                        {
                            //NO SE PUEDE DEVOLVER
                            MessageBox.Show("El máximo de costo por caja es " + Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CostoNeto", e.RowIndex].Value).ToString("#,##0.00"), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            _Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value = 0;
                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            _Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value = 0;
                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = 0;
                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = 0;
                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = 0;
                            _Bol_SwStop = true;
                        }
                        else
                        {
                            _Str_Sql = "select cproducto,cventaund2, ccontenidoma1,ccontenidoma2,cidproductod,cprecioventamax FROM VST_PRODUCTOLOTE WHERE (cproducto='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "') AND (cidproductod = '" + _Dg_GridDet["_Dg_GridDetCol_NLote", e.RowIndex].Value.ToString() + "')";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                                {
                                    double _Dbl_CalculoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                                    if (Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value) > 0)
                                    {
                                        double _Dbl_MontoPorUnd=0;
                                        _Dbl_MontoPorUnd=Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value)/_Dbl_CalculoUnd;
                                        _Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value = _Dbl_MontoPorUnd.ToString("#,##0.000");
                                    }
                                    else
                                    {
                                        _Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value = 0;
                                    }
                                }
                            }
                            _Bol_SwStop = false;
                        }
                        if (!_Bol_SwStop)
                        {
                            _Dbl_PorcImp = 0;
                            _Str_Sql = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "')";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                                {
                                    _Dbl_PorcImp = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                                }
                            }

                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value).Length > 0)
                            {
                                _Int_Unidades = Convert.ToInt32(_Dg_GridDet["_Dg_GridDetCol_Und", e.RowIndex].Value);
                            }
                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value).Length > 0)
                            {
                                _Dbl_CxUnd = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxUnd", e.RowIndex].Value);
                            }
                            _Dbl_CxCaja = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_CxCaja", e.RowIndex].Value);
                            _Dbl_Cajas = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", e.RowIndex].Value);
                            _Dbl_Costo = (_Dbl_CxCaja * _Dbl_Cajas) + (_Dbl_CxUnd * _Int_Unidades);
                            _Dbl_ImpCaja = ((_Dbl_CxCaja * _Dbl_Cajas) * _Dbl_PorcImp) / 100;
                            _Dbl_ImpUnd = ((_Dbl_CxUnd * _Int_Unidades) * _Dbl_PorcImp) / 100;
                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_ImpCaja.ToString("#,##0.00");
                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = _Dbl_ImpUnd.ToString("#,##0.00");
                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                            if (_Rb_Mestado.Checked)
                            {
                                _Str_Sql = "select TOP 1 TPROVEEDOR.cpordevmalestado from TPROVEEDOR INNER JOIN TPRODUCTO ON TPROVEEDOR.CPROVEEDOR=TPRODUCTO.CPROVEEDOR WHERE TPRODUCTO.CPRODUCTO='" + _Dg_GridDet["_Dg_GridDetCol_ProdId", e.RowIndex].Value.ToString() + "'";
                                double _Dbl_DevRecono = 0;
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (_Ds.Tables[0].Rows[0][0].ToString() != "")
                                    {
                                        _Dbl_DevRecono = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                                        if (_Dbl_DevRecono == 0)
                                        {
                                            //_Dg_GridDet.Rows.RemoveAt(e.RowIndex);
                                            _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                            for (int i = 0; i <= 13; i++)
                                            {
                                                _Dg_GridDet[i, e.RowIndex].Value = "";
                                            }
                                            _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                            MessageBox.Show("El proveedor del producto no reconoce producto en mal estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {
                                            _Dbl_Costo = (_Dbl_Costo * _Dbl_DevRecono) / 100;
                                            _Dbl_ImpCaja = (_Dbl_ImpCaja * _Dbl_DevRecono) / 100;
                                            _Dbl_ImpUnd = (_Dbl_ImpUnd * _Dbl_DevRecono) / 100;
                                            _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                                            _Dg_GridDet["_Dg_GridDetCol_ImpCaja", e.RowIndex].Value = _Dbl_ImpCaja.ToString("#,##0.00");
                                            _Dg_GridDet["_Dg_GridDetCol_ImpUnd", e.RowIndex].Value = _Dbl_ImpUnd.ToString("#,##0.00");
                                        }
                                    }
                                    else
                                    {
                                        //_Dg_GridDet.Rows.RemoveAt(e.RowIndex);
                                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        for (int i = 0; i <= 13; i++)
                                        {
                                            _Dg_GridDet[i, e.RowIndex].Value = "";
                                        }
                                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                                        MessageBox.Show("El proveedor del producto no reconoce producto en mal estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                _Dg_GridDet["_Dg_GridDetCol_Total", e.RowIndex].Value = _Dbl_Costo.ToString("#,##0.00");
                            }
                            _Mtd_Totalizar();
                        }
                    }
                    if (_Mtd_ValidaGridDetalle(false))
                    {
                        if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_ProdId", _Dg_GridDet.RowCount - 1].Value).Length > 0)
                        {
                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_Caja", _Dg_GridDet.RowCount - 1].Value).Length > 0)
                            {
                                _Dbl_Cajas = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Caja", _Dg_GridDet.RowCount - 1].Value);
                            }
                            double _Dbl_Und_=0;
                            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_Und", _Dg_GridDet.RowCount - 1].Value).Length > 0)
                            {
                                _Dbl_Und_ = Convert.ToDouble(_Dg_GridDet["_Dg_GridDetCol_Und", _Dg_GridDet.RowCount - 1].Value);
                            }
                            if (_Dbl_Cajas > 0 || _Dbl_Und_>0)
                            {
                                _Dg_GridDet.RowCount++;
                                _Dg_GridDet.Rows[_Dg_GridDet.RowCount - 1].ReadOnly = true;
                                _Dg_GridDet.Rows[_Dg_GridDet.RowCount - 1].Cells[5].ReadOnly = false;
                            }
                            else
                            { }
                        }
                        else
                        { }
                    }
                    else
                    {
                        if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_ProdId", _Dg_GridDet.RowCount - 1].Value).Trim().Length == 0)
                        {
                            _Dg_GridDet.RowCount--;
                        }
                    }
                }
            }
        }
        private bool _Mtd_Firma_Nivel_1(string _P_Str_Devolucion)
        {
            if (_P_Str_Devolucion.Trim().Length > 0)
            {
                string _Str_Sql = "SELECT cfimarnivel FROM VST_TDEVVENTAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ciddevventa='" + _P_Str_Devolucion + "' AND cfimarnivel='1'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0;
            }
            return false;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Rbt_Apro.Checked){
                Q_cidnotrecepc = _Dg_Grid.Rows[e.RowIndex].Cells[3].Value.ToString();
                _Btn_RPrint.Visible = true;
            }else{_Btn_RPrint.Visible = false;}
            
            if (_Dg_Grid.RowCount > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Ini(false);
                _Mtd_CargarData(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                _Mtd_CargarNCGeneradas(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                _Mtd_BotonesMenu();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA") & _Mtd_Firma_Nivel_1(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)) & this.MdiParent != null);
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectTab(1);
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                this.Cursor = Cursors.Default;
            }
        }

        private void Frm_DevolVenta_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
           // if (this.MdiParent != null) { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = (_Bt_Firma2.Enabled & _Bt_Firma2.Visible & _Tb_Tab.SelectedIndex == 1 & !_Dg_GridDet.ReadOnly); }
        }

        private void Frm_DevolVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Bol_Tabs)
            {
                if (e.TabPageIndex != 0)
                {
                    if (_Str_MyProceso == "")
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (e.TabPageIndex != 1)
                {
                    e.Cancel = true;
                }
            }
        }
        private bool _Mtd_VerificarDupliDgDetalle(string _Pr_Str_Producto, string _P_Str_IdProductod)
        {
            bool _Bol_R = false;
            foreach (DataGridViewRow _DgRow in _Dg_GridDet.Rows)
            {
                if (_Pr_Str_Producto.Trim() == Convert.ToString(_DgRow.Cells["_Dg_GridDetCol_ProdId"].Value).Trim() && _P_Str_IdProductod.Trim() == Convert.ToString(_DgRow.Cells["CodigoIDProducto"].Value).Trim())
                {
                    _Bol_R = true;
                    break;
                }
            }
            return _Bol_R;
        }

        private void _Dg_GridDet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Convert.ToString(_Dg_GridDet["_Dg_GridDetCol_ProdId", e.Row.Index].Value).Trim().Length == 0)
            {
                if (e.Row.Index == 0)
                {
                    for (int _I=0;_I<_Dg_GridDet.ColumnCount;_I++)
                    {
                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                        _Dg_GridDet[_I, e.Row.Index].Value = "";
                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                    }
                    e.Cancel = true;
                }
            }
            else
            {
                if (e.Row.Index == 0)
                {
                    for (int _I = 0; _I < _Dg_GridDet.ColumnCount; _I++)
                    {
                        _Dg_GridDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                        _Dg_GridDet[_I, e.Row.Index].Value = "";
                        _Dg_GridDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_GridDet_CellValueChanged);
                    }
                    e.Cancel = true;
                }  
            }
        }

        private void _Dg_GridDet_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_Str_MyProceso=="A")
            {
                _Mtd_Totalizar();
            }
        }

        private void _Cb_Motivo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarMotivos();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarVendedores();
            this.Cursor = Cursors.Default;
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
            //_Mtd_CargarConsulta();
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {
            //_Mtd_CargarConsulta();
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            bool _Bol_Sw = false;
            this.Cursor = Cursors.WaitCursor;

            if(_Int_Sw == 1)
            {
                if (Convert.ToDouble(_Txt_MontoTotal.Text) == 0)
                {
                    MessageBox.Show("El total de la devolución no puede ser cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return;
                }

                if (_Str_MyProceso == "A")
                {
                    _Bol_Sw = _Mtd_Guardar();
                }
                if (_Str_MyProceso == "F")
                {
                    _Bol_Sw = _Mtd_Editar();
                    if (_Mtd_Firma_Nivel_1(_Txt_IdDevol.Text.Trim()) & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA") & _Bol_Sw)
                    { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true; ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false; _Dg_GridDet.ReadOnly = true; }
                }
            }
            else if(_Int_Sw == 2)
            {
                _Bol_Sw = _Mtd_Rechazar();
            }
            _Pnl_Clave.Visible = !_Bol_Sw;
            this.Cursor = Cursors.Default;
            _Mtd_BotonesMenu();
            _Bol_Firmar = false;
        }
        int _Int_Sw = 1;
        bool _Bol_Firmar = false;
        private void _Bt_Firma2_Click(object sender, EventArgs e)
        {
            //Evita que se puedan Firma devoluciones al haberse iniciado un Conteo de Inventario
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No se pueden realizar operaciónes en este ámbito", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
               // Application.OpenForms[this.Name].Close();
            }
            else
            {
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA"))
                {
                    if (!_Dg_GridDet.ReadOnly)
                    { MessageBox.Show("Debe guardar la información para realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    {
                        _Bol_Firmar = true;
                        _Int_Sw = 1;
                        _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                        _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no tiene permiso para firmar la devolución.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            }
        }

        private void _Rbt_Apro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Apro.Checked)
            {
                _G_Int_Entrada = 0;
                _Dt_Desde.Enabled = true;
                _Dt_Hasta.Enabled = true;
            }
            else if (_Rbt_PorA.Checked)
            {
                _G_Int_Entrada = 1;
                _Dt_Desde.Enabled = false;
                _Dt_Hasta.Enabled = false;
            }
            else if (_Rbt_Rechazadas.Checked)
            {
                _G_Int_Entrada = 2;
                _Dt_Desde.Enabled = true;
                _Dt_Hasta.Enabled = true;
            }
            _Mtd_Ini(true);
        }

        private void _Btn_Rechazar_Click(object sender, EventArgs e)
        {
            if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_DEVOLVENTA"))
            {
                _Int_Sw = 2;
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
            else
            {
                MessageBox.Show("El usuario no tiene permiso para firmar el rechazo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Cb_Vendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Rb_Sfact.Checked & _Cb_Vendedor.SelectedIndex > 0)
            {
                _Dg_GridDet.RowCount = 1;
                _Dg_GridDet.ReadOnly = false;
                _Dg_GridDet.Rows[0].ReadOnly = true;
                _Dg_GridDet.Rows[0].Cells["_Dg_GridDetCol_Caja"].ReadOnly = false;
                _Dg_GridDet.Rows[0].Cells["_Dg_GridDetCol_CxCaja"].ReadOnly = false;
            }
            else if (_Rb_Sfact.Checked & _Cb_Vendedor.SelectedIndex <= 0)
            { _Dg_GridDet.Rows.Clear(); }
        }
        private bool _Mtd_VerificarObject(object _P_Ob_Object)
        {
            if (Convert.ToString(_P_Ob_Object).Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Ob_Object) > 0)
                { return true; }
            }
            return false;
        }
        private void _Mtd_PrepararGrid()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_GridDet.Rows)
            {
                _Dg_Row.ReadOnly = true;
                _Dg_Row.Cells[5].ReadOnly = !_Mtd_VerificarObject(_Dg_Row.Cells[5].Value);
                _Dg_Row.Cells[6].ReadOnly = !_Mtd_VerificarObject(_Dg_Row.Cells[6].Value);
                if (_Rb_Sfact.Checked)
                { _Dg_Row.Cells[7].ReadOnly = !_Mtd_VerificarObject(_Dg_Row.Cells[7].Value); }
            }
        }
        public void _Mtd_Habilitar()
        {
            _Dg_GridDet.ReadOnly = false;
            _Mtd_PrepararGrid();
            _Dg_GridDet.RowCount += 1;
            _Dg_GridDet.Rows[_Dg_GridDet.RowCount-1].ReadOnly = true;
            _Dg_GridDet.Rows[_Dg_GridDet.RowCount - 1].Cells["_Dg_GridDetCol_Caja"].ReadOnly = false;
            _Dg_GridDet.Rows[_Dg_GridDet.RowCount - 1].Cells["_Dg_GridDetCol_CxCaja"].ReadOnly = false;
        }

        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMotivo();
            Cursor = Cursors.Default;
        }

        private void _Bt_CargarConsulta_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarConsulta();
            Cursor = Cursors.Default;
        }

        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        Clases._Cls_ExcelUtilidades _MyExcel = new Clases._Cls_ExcelUtilidades();
                        _MyExcel._Mtd_DatasetToExcel((DataTable)_Dg_Grid.DataSource, _Sfd_1.FileName, "ConsDevolVta", _Dg_Grid.Columns);
                        _MyExcel = null;
                        Cursor = Cursors.Default;
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            { MessageBox.Show("No existen datos para exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private string _Mtd_ObtenerCodigoZona(string _P_Str_CFACTURA)
        {
            string _Str_Cadena = "select c_zona from tfacturam where cfactura = '" + _P_Str_CFACTURA + "' and ccompany = '" + Frm_Padre._Str_Comp + "'";
            string _Str_Retornar = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Retornar = _Row[0].ToString();
                }
            }
            return _Str_Retornar;
        }

        //re-imprimir
        public static string Q_cidnotrecepc;
        private void _Btn_RPrint_Click(object sender, EventArgs e)
        {
            PrintDialog _Print = new PrintDialog();
            //if (_Print.ShowDialog() == DialogResult.OK){
                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm = new REPORTESS(new string[] { "VST_RPT_NOTARECEP_DEVOL" }, "", "T3.Report.rNotaRecep_Devol", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotrecepc='" + Q_cidnotrecepc.Trim() + "'", _Print, false);
                _Frm.Show();
                Cursor = Cursors.Default;
            //}
        }

    }
}