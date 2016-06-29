using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigImpresion : Form
    {
        enum _G_TiposEstadoFormulario
        {
            Consultando = 0,
            Agregando,
            Modificando
        }

        private _G_TiposEstadoFormulario _G_EstadoFormulario = _G_TiposEstadoFormulario.Consultando;
        private string _G_Str_cidimpresion = "";

        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ConfigImpresion()
        {
            InitializeComponent();
        }

        private void Frm_ConfigPrinterFact2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Actualizar();
            _Mtd_HabilitarControles(false);
            _G_EstadoFormulario = _G_TiposEstadoFormulario.Consultando;
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
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Tipo Documento");
            _Tsm_Menu[2] = new ToolStripMenuItem("Impresora");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidimpresion";
            _Str_Campos[1] = "ctipodocument";
            _Str_Campos[2] = "ccprinter_name";
            //string _Str_Cadena = "SELECT TCONFIGIMPRESION.cidimpresion AS Código, CASE TCONFIGIMPRESION.ctipodocument WHEN 1 THEN 'Factura' WHEN 2 THEN 'Comprobante' WHEN 3 THEN 'Guía despacho' WHEN 4 THEN 'Facturas Emitidas' END AS [Tipo Documento], TCONFIGIMPRESION.ccprinter_name AS Impresora, TCONFIGIMPRESION.cidimpresion, TCONFIGIMPRESION.ctipodocument,TCONFIGIMPRESION.ccprinter_name FROM TCONFIGIMPRESION WHERE cdelete='0'";
            String _Str_Cadena = "SELECT dbo.TCONFIGIMPRESION.cidimpresion AS Código 	,CASE TCONFIGIMPRESION.ctipodocument 		WHEN 1 			THEN 'FACTURA' + ' - ' + TCOMPANY.cname 		WHEN 2 			THEN 'COMPROBANTE'  		WHEN 3 			THEN 'GUIA DESPACHO' 		WHEN 4 			THEN 'FACTURAS EMITIDAS' 		END  AS [Tipo Documento] 	,dbo.TCONFIGIMPRESION.ccprinter_name AS Impresora 	,dbo.TCONFIGIMPRESION.cidimpresion 	,dbo.TCONFIGIMPRESION.ctipodocument 	,dbo.TCONFIGIMPRESION.ccprinter_name 	,dbo.TCONFIGIMPRESION.ccompany FROM dbo.TCONFIGIMPRESION INNER JOIN dbo.TCOMPANY ON dbo.TCONFIGIMPRESION.ccompany = dbo.TCOMPANY.ccompany WHERE (dbo.TCONFIGIMPRESION.cdelete = '0' and TCONFIGIMPRESION.ctipodocument = 1)  UNION  SELECT TOP 1 dbo.TCONFIGIMPRESION.cidimpresion AS Código 	,CASE TCONFIGIMPRESION.ctipodocument 		WHEN 1 			THEN 'FACTURA' + ' - ' + TCOMPANY.cname 		WHEN 2 			THEN 'COMPROBANTE'  		WHEN 3 			THEN 'GUIA DESPACHO' 		WHEN 4 			THEN 'FACTURAS EMITIDAS' 		END  AS [Tipo Documento] 	,dbo.TCONFIGIMPRESION.ccprinter_name AS Impresora 	,dbo.TCONFIGIMPRESION.cidimpresion 	,dbo.TCONFIGIMPRESION.ctipodocument 	,dbo.TCONFIGIMPRESION.ccprinter_name 	,dbo.TCONFIGIMPRESION.ccompany FROM dbo.TCONFIGIMPRESION INNER JOIN dbo.TCOMPANY ON dbo.TCONFIGIMPRESION.ccompany = dbo.TCOMPANY.ccompany WHERE (dbo.TCONFIGIMPRESION.cdelete = '0' and TCONFIGIMPRESION.ctipodocument = 2)  UNION  SELECT TOP 1 dbo.TCONFIGIMPRESION.cidimpresion AS Código 	,CASE TCONFIGIMPRESION.ctipodocument 		WHEN 1 			THEN 'FACTURA' + ' - ' + TCOMPANY.cname 		WHEN 2 			THEN 'COMPROBANTE'  		WHEN 3 			THEN 'GUIA DESPACHO' 		WHEN 4 			THEN 'FACTURAS EMITIDAS' 		END  AS [Tipo Documento] 	,dbo.TCONFIGIMPRESION.ccprinter_name AS Impresora 	,dbo.TCONFIGIMPRESION.cidimpresion 	,dbo.TCONFIGIMPRESION.ctipodocument 	,dbo.TCONFIGIMPRESION.ccprinter_name 	,dbo.TCONFIGIMPRESION.ccompany FROM dbo.TCONFIGIMPRESION INNER JOIN dbo.TCOMPANY ON dbo.TCONFIGIMPRESION.ccompany = dbo.TCOMPANY.ccompany WHERE (dbo.TCONFIGIMPRESION.cdelete = '0' and TCONFIGIMPRESION.ctipodocument = 3)  UNION  SELECT TOP 1 dbo.TCONFIGIMPRESION.cidimpresion AS Código 	,CASE TCONFIGIMPRESION.ctipodocument 		WHEN 1 			THEN 'FACTURA' + ' - ' + TCOMPANY.cname 		WHEN 2 			THEN 'COMPROBANTE'  		WHEN 3 			THEN 'GUIA DESPACHO' 		WHEN 4 			THEN 'FACTURAS EMITIDAS' 		END  AS [Tipo Documento] 	,dbo.TCONFIGIMPRESION.ccprinter_name AS Impresora 	,dbo.TCONFIGIMPRESION.cidimpresion 	,dbo.TCONFIGIMPRESION.ctipodocument 	,dbo.TCONFIGIMPRESION.ccprinter_name 	,dbo.TCONFIGIMPRESION.ccompany FROM dbo.TCONFIGIMPRESION INNER JOIN dbo.TCOMPANY ON dbo.TCONFIGIMPRESION.ccompany = dbo.TCOMPANY.ccompany WHERE (dbo.TCONFIGIMPRESION.cdelete = '0' and TCONFIGIMPRESION.ctipodocument = 4)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Configuraciones", _Tsm_Menu, _Dg_Grid, true, "", "ctipodocument");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.Columns[0].Visible = false;
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
        }
        private void _Mtd_CargarComboTipoDocumento()
        {
            DataSet _Ds;
            string _Str_Sql;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoDocumento.DataSource = null;
            _myArrayList.Add(new _Cls_ArrayList3("...", "0", ""));

            //Recorro las Compañias
            _Str_Sql = "Select ccompany,cname from TCOMPANY where cdelete='0'";
            DataSet _Ds_Compañias = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow oFila in _Ds_Compañias.Tables[0].Rows)
            {
                string ccompany = oFila["ccompany"].ToString();
                string cname = oFila["cname"].ToString();

                _myArrayList.Add(new _Cls_ArrayList3("FACTURA - " + cname, "1", ccompany));
            }

            _myArrayList.Add(new _Cls_ArrayList3("COMPROBANTE", "2", ""));
            _myArrayList.Add(new _Cls_ArrayList3("GUIA DESPACHO", "3", ""));
            _myArrayList.Add(new _Cls_ArrayList3("FACTURAS EMITIDAS", "4", ""));

            _Cmb_TipoDocumento.DataSource = _myArrayList;
            _Cmb_TipoDocumento.DisplayMember = "Display";
            _Cmb_TipoDocumento.ValueMember = "Value";
            _Cmb_TipoDocumento.SelectedValue = "0";

        }

        private void _Mtd_CargarImpresoras()
        {
            try
            {
                _Cmb_Impresora.Items.Clear();
                _Cmb_Impresora.Items.Add("...");
                for (int _I = 0; _I < PrinterSettings.InstalledPrinters.Count; _I++)
                {
                    _Cmb_Impresora.Items.Add(PrinterSettings.InstalledPrinters[_I].ToString());
                }
                _Cmb_Impresora.SelectedIndex = 0;
            }
            catch
            {
                throw new Exception("Problemas al cargar las impresoras.");
            }
        }
        private void Frm_ConfigImpresion_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;

        }
        private void Frm_ConfigImpresion_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }


        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_Ini();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            else
            { e.Cancel = true; }
        }
        public void _Mtd_Ini()
        {
            _Mtd_HabilitarControles(false);
            _G_Str_cidimpresion = "";
            _Cmb_TipoDocumento.SelectedIndex = 0;
            _Cmb_Impresora.SelectedIndex = 0;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            _Mtd_Actualizar();
            _Tb_Tab.SelectedIndex = 0;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_CargarComboTipoDocumento();
            _Mtd_CargarImpresoras();
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Mtd_HabilitarControles(true);
            _G_EstadoFormulario = _G_TiposEstadoFormulario.Agregando;
            _Cmb_TipoDocumento.Focus();
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Mtd_HabilitarControles(true);
            _Cmb_TipoDocumento.Enabled = false;
            _G_EstadoFormulario = _G_TiposEstadoFormulario.Modificando;
            _Cmb_TipoDocumento.Focus();
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }
        public void _Mtd_HabilitarControles(bool pActivar)
        {
            _Cmb_TipoDocumento.Enabled = pActivar;
            _Cmb_Impresora.Enabled = pActivar;
        }

        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }

        private void _Mtd_EliminarRegistros()
        {
            string _Str_Cadena = "";
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dvr_Fila in _Dg_Grid.SelectedRows)
            {
                _Str_Cadena = "UPDATE TCONFIGIMPRESION SET cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' WHERE cidimpresion='" + Convert.ToString(_Dvr_Fila.Cells["cidimpresion"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            Cursor = Cursors.Default;
        }

        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_TipoDocumento.SelectedIndex > 0 & _Cmb_Impresora.SelectedIndex > 0)
            {
                string _Str_Cadena = "";
                DataSet _Ds_DataSet;
                string ccompany = ((_Cls_ArrayList3)_Cmb_TipoDocumento.SelectedItem).Company;

                if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Agregando) //Agregando
                {
                    if (_Mtd_Validar())
                    {
                        Cursor = Cursors.WaitCursor;

                        //Si tiene compañia
                        if (ccompany != "")
                        {
                            _Str_Cadena = "SELECT cidimpresion FROM TCONFIGIMPRESION WHERE ccompany='" + ccompany + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=1";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0) //Existe y estaba eliminado
                            {
                                _Str_Cadena = "UPDATE TCONFIGIMPRESION SET ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "',ccprinter_name='" + Convert.ToString(_Cmb_Impresora.Text).Trim() + "',cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + ccompany + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "'";
                            }
                            else//No existe
                            {
                                _Str_Cadena = "INSERT INTO TCONFIGIMPRESION (ccompany,ctipodocument,ccprinter_name,cdateadd,cuseradd,cdelete) VALUES ('" + ccompany + "','" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_Impresora.Text).Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                            }
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {

                            //Recorro las Compañias
                            _Str_Cadena = "Select ccompany,cname from TCOMPANY where cdelete='0'";
                            DataSet _Ds_Compañias = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            foreach (DataRow oFila in _Ds_Compañias.Tables[0].Rows)
                            {
                                string ccompany2 = oFila["ccompany"].ToString();

                                _Str_Cadena = "SELECT cidimpresion FROM TCONFIGIMPRESION WHERE ccompany='" + ccompany2 + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=1";
                                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds_DataSet.Tables[0].Rows.Count > 0) //Existe y estaba eliminado
                                {
                                    _Str_Cadena = "UPDATE TCONFIGIMPRESION SET ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "',ccprinter_name='" + Convert.ToString(_Cmb_Impresora.Text).Trim() + "',cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + ccompany2 + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "'";
                                }
                                else//No existe
                                {
                                    _Str_Cadena = "INSERT INTO TCONFIGIMPRESION (ccompany,ctipodocument,ccprinter_name,cdateadd,cuseradd,cdelete) VALUES ('" + ccompany2 + "','" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_Impresora.Text).Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                                }
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            }
                        }

                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Er_Error.Dispose();
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                        return false;
                    }
                }
                else if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Modificando) //Modificando
                {
                    if (_Mtd_Validar())
                    {

                        //Si tiene compañia
                        if (ccompany != "")
                        {
                            _Str_Cadena = "UPDATE TCONFIGIMPRESION SET ccprinter_name='" + Convert.ToString(_Cmb_Impresora.Text).Trim() + "',cdateupd=GETDATE(),cuserupd='" + ccompany + "' WHERE ccompany='" + ccompany + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {

                            //Recorro las Compañias
                            _Str_Cadena = "Select ccompany,cname from TCOMPANY where cdelete='0'";
                            DataSet _Ds_Compañias = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            foreach (DataRow oFila in _Ds_Compañias.Tables[0].Rows)
                            {
                                string ccompany2 = oFila["ccompany"].ToString();
                                string cname = oFila["cname"].ToString();

                                _Str_Cadena = "UPDATE TCONFIGIMPRESION SET ccprinter_name='" + Convert.ToString(_Cmb_Impresora.Text).Trim() + "',cdateupd=GETDATE(),cuserupd='" + ccompany2 + "' WHERE ccompany='" + ccompany2 + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                            }
                        }

                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Er_Error.Dispose();
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                if (_Cmb_TipoDocumento.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_TipoDocumento, "Información requerida!!!"); }
                if (_Cmb_Impresora.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Impresora, "Información requerida!!!"); }
            }
            return false;
        }

        private bool _Mtd_Validar()
        {
            string _Str_Cadena = "";
            DataSet _Ds_DataSet;
            string ccompany = ((_Cls_ArrayList3)_Cmb_TipoDocumento.SelectedItem).Company;

            if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Agregando)
            {
                //Si tiene compañia
                if (ccompany != "")
                {
                    _Str_Cadena = "SELECT cidimpresion FROM TCONFIGIMPRESION WHERE ccompany='" + ccompany + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=0";
                }
                else
                {
                    _Str_Cadena = "SELECT cidimpresion FROM TCONFIGIMPRESION WHERE  ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=0";
                }
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("El Tipo de documento que introdujo ya tiene configurada una impresora. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Modificando)
            {
                //Si tiene compañia
                if (ccompany != "")
                {
                    _Str_Cadena = "SELECT cidimpresion FROM TCONFIGIMPRESION WHERE ccompany='" + ccompany + "' AND ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=0 AND cidimpresion<>'" + _G_Str_cidimpresion + "'";
                }
                else
                {
                    //_Str_Cadena = "SELECT cidimpresion FROM TCONFIGIMPRESION WHERE ctipodocument='" + Convert.ToString(_Cmb_TipoDocumento.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=0 AND cidimpresion<>'" + _G_Str_cidimpresion + "'";
                    return true;
                }
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("El Tipo de documento que introdujo ya tiene configurada una impresora. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Mtd_CargarComboTipoDocumento();
                _Mtd_CargarImpresoras();

                //_Cmb_TipoDocumento.SelectedIndexChanged -= new EventHandler(_Cmb_TipoDocumento);
                //_Cmb_TipoDocumento.SelectedIndexChanged += new EventHandler(_Cmb_BancoD_SelectedIndexChanged);

                _G_Str_cidimpresion = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidimpresion"].Value).Trim();

                //Obtengo el Item a seleccionar
                _Cls_ArrayList3 oItemSeleccionado = null;
                foreach (_Cls_ArrayList3 oItem in _Cmb_TipoDocumento.Items)
                {
                    int oTipoDocumento = Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["ctipodocument"].Value);
                    var oCompania = _Dg_Grid.Rows[e.RowIndex].Cells["ccompany"].Value.ToString();

                    switch (oTipoDocumento)
                    {
                        case (int)T3.Clases._Cls_RutinasImpresion._G_TiposDocumento.Factura:
                            if ((oItem.Value == oTipoDocumento.ToString()) && (oItem.Company == oCompania))
                            {
                                oItemSeleccionado = oItem;
                            }
                            break;
                        default:
                            if ((oItem.Value == oTipoDocumento.ToString()) && (oItem.Company == ""))
                            {
                                oItemSeleccionado = oItem;
                            }
                            break;
                    }
                }
                _Cmb_TipoDocumento.SelectedItem = oItemSeleccionado;

                _Cmb_Impresora.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["ccprinter_name"].Value).Trim();

                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
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

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0;
        }

        private void _Cntx_Menu_Click(object sender, EventArgs e)
        {
        }

        private void _Tool_Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar los registros seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Mtd_EliminarRegistros();
                _Mtd_Actualizar();
                MessageBox.Show("Los registros seleccionados han sido eliminados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public class _Cls_ArrayList3
        {
            private string m_Display;
            private string m_Value;
            private string m_Company;
            public _Cls_ArrayList3(string Display, string Value, string Company)
            {
                m_Display = Display;
                m_Value = Value;
                m_Company = Company;
            }
            public string Display
            {
                get { return m_Display; }
            }
            public string Value
            {
                get { return m_Value; }
            }
            public string Company
            {
                get { return m_Company; }
            }
        }
    }
}
