using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_RecepcionC : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_RecepcionC()
        {
            InitializeComponent();
        }
        public Frm_RecepcionC(string _P_Str_Proveedor, string _P_Str_Placa, string _P_Str_Rec)
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_FacturaComp";
            _Txt_Proveedor.Tag = _P_Str_Proveedor;
            _Txt_Proveedor.Text = _Mtd_DesProveedor(_P_Str_Proveedor);
            _Txt_Rec.Text = _P_Str_Rec;
            _Txt_Placa.Text = _P_Str_Placa;
        }
        private string _Mtd_DesProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
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
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT Factura, Fecha, Total, Cajas, cunidades AS Unidades FROM VST_RECEPFACTURAS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND cfactverif='0'";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Cajas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Unidades"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_ActualizarDif(string _P_Str_Factura)
        {
            Cursor = Cursors.WaitCursor;
            _Dg_Dif.Rows.Clear();
            string _Str_Cadena = "SELECT cproducto, ccodfabrica, cempaques, cunidades, cnamefc, dbo.Fnc_Formatear(cprecioventamaxfact) AS cprecioventamaxfact, dbo.Fnc_Formatear(cprecioventamaxoc) AS cprecioventamaxoc, 'NO DEFINIDO' AS Estatus FROM VST_DIFPMVFACTOC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dg_Dif.Rows.Add(new object[] { _Row[0], _Row[1], _Row[2], _Row[3], _Row[4], _Row[5], _Row[6], _Row[7] });
            }
            _Dg_Dif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private string _Mtd_RetornarOC(string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT ISNULL(ccopiaoc,0) FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_ColocarEstatus(string _P_Str_Estatus)
        {
            foreach (DataGridViewRow _Row in _Dg_Dif.SelectedRows)
            {
                _Row.Cells["Estatus"].Value = _P_Str_Estatus;
            }
        }
        private bool _Mtd_ProductosSinEstatus()
        {
            return _Dg_Dif.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Estatus"].Value).Trim() == "NO DEFINIDO").Count() > 0;
        }
        private void _Mtd_ActualizarEstatusProductos(string _P_Str_Factura)
        {
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Row in _Dg_Dif.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["Estatus"].Value).Trim() == "RECHAZADO"))
            {
                _Str_Cadena = "UPDATE TRECEPCIONDFD SET crechazadoxpmv='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproducto='" + Convert.ToString(_Row.Cells["cproducto"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private void _Mtd_Busqueda(string _P_Str_Factura, string _P_Str_Proveedor)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CFACTURA", _P_Str_Factura);
            parm[2] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[3] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_RecepcionC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Actualizar();
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

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            { _Txt_Observacion.Enabled = false; _Dg_Dif.Rows.Clear(); _Er_Error.Dispose(); }
            else if (e.TabPageIndex == 1)
            { e.Cancel = !_Txt_Observacion.Enabled; }
            else
            { e.Cancel = _Dg_Dif.RowCount == 0; }
        }
        private string _Mtd_MostrarObservacion(string _P_Str_Recepcion, string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT cobservacion FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        private bool _Mtd_TodasFactCorrectas(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "'";
            int _Int_TotalFacturas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
            _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cfactverif='1'";
            int _Int_TotalCorrectas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
            return _Int_TotalFacturas == _Int_TotalCorrectas;
        }
        string _Str_Factura = "";
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                _Txt_Observacion.Enabled = true;
                _Txt_Observacion.Text = _Mtd_MostrarObservacion(_Txt_Rec.Text.Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value).Trim());
                _Mtd_Busqueda(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(_Txt_Proveedor.Tag).Trim());
                _Str_Factura = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value).Trim();
                _Txt_Factura.Text = _Str_Factura;
                _Txt_OC.Text = _Mtd_RetornarOC(_Str_Factura);
                _Mtd_ActualizarDif(_Str_Factura);
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void Frm_RecepcionC_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_RecepcionC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(84);
            if (_Frm._Dg_Grid.RowCount == 0)
            { _Frm.Close(); }
            else
            { _Frm.MdiParent = this.MdiParent; _Frm.Show(); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Grb_Superior.Enabled = false;
                _Pnl_Inferior.Enabled = false;
                _Rpt_Report.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Grb_Superior.Enabled = true;
                _Pnl_Inferior.Enabled = true;
                _Rpt_Report.Enabled = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        int _Int_Sw = 0;
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "UPDATE TRECEPCIONDFM SET cfactverif='" + _Int_Sw + "',cobservacion='" + _Txt_Observacion.Text.ToUpper().Trim() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND cnfacturapro='" + _Str_Factura + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if (_Int_Sw == 1)
                {
                    _Mtd_ActualizarEstatusProductos(_Str_Factura);
                }
                if (_Mtd_TodasFactCorrectas(_Txt_Rec.Text.Trim()))
                {
                    _Str_Cadena = "UPDATE TRECEPCIONM SET ccargfactura='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                if (_Dg_Grid.RowCount == 0)
                { this.Close(); }
                else
                { _Tb_Tab.SelectedIndex = 0; }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Correcta_Click(object sender, EventArgs e)
        {
            if (_Mtd_ProductosSinEstatus())
            {
                MessageBox.Show("Existen diferencias de PMV sin estatus. Debe asignar un estatus a cada diferencia para continuar con el proceso.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Tb_Tab.SelectedIndex = 2;
            }
            else
            {
                _Er_Error.Dispose();
                _Int_Sw = 1;
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Btn_Regresar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ProductosSinEstatus())
            {
                MessageBox.Show("Existen diferencias de PMV sin estatus. Debe asignar un estatus a cada diferencia para continuar con el proceso.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Tb_Tab.SelectedIndex = 2;
            }
            else
            {
                _Tb_Tab.SelectedIndex = 1;
                _Er_Error.Dispose();
                //_Int_Sw = 1;
                //_Pnl_Clave.Visible = true;
            }
        }

        private void _Bt_Enviar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Observacion.Text.Trim().Length > 0)
            {
                _Int_Sw = 2;
                _Pnl_Clave.Visible = true;
            }
            else
            { _Er_Error.SetError(_Txt_Observacion, "Información requerida!!!"); }
        }

        private void _Dg_Dif_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfoDif.Visible = true;
            }
            else
            {
                _Lbl_DgInfoDif.Visible = false;
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Dif.SelectedRows.Count < 1;
        }

        private void _Tol_Aceptar_Click(object sender, EventArgs e)
        {
            _Mtd_ColocarEstatus("ACEPTADO");
        }

        private void _Tol_Rechazar_Click(object sender, EventArgs e)
        {
            _Mtd_ColocarEstatus("RECHAZADO");
        }

    }
}
