using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace T3
{
    public partial class Frm_FacturasPorFirmar : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_FacturasPorFirmar()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        public void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Factura");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "Factura";
            string _Str_Cadena = "SELECT Factura,CONVERT(VARCHAR,Fecha,103) AS Fecha,dbo.Fnc_Formatear(ctotmontsimp) AS Monto,dbo.Fnc_Formatear(VST_RECEPFACTURAS.cporcinvendible) as Invendible,dbo.Fnc_Formatear(ctotalimp) AS Impuesto, Total,VST_RECEPFACTURAS.cproveedor,TPROVEEDOR.c_nomb_comer,cidrecepcion FROM VST_RECEPFACTURAS INNER JOIN TPROVEEDOR ON VST_RECEPFACTURAS.cproveedor=TPROVEEDOR.cproveedor AND (TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' OR TPROVEEDOR.cglobal='1') WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cnotarecepcion='0' AND cfirmado='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "FACTURAS", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }
        private void _Mtd_Mostar_Detalle(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TRECEPCIONDFD.cproducto as Producto,(Select top 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where TPRODUCTO.cproducto=TRECEPCIONDFD.cproducto) as Descripción,TRECEPCIONDFD.cempaques as Cajas,TRECEPCIONDFD.cunidades as Unidades,dbo.Fnc_Formatear(TRECEPCIONDFD.cprecioxpro) AS Monto, " +
            "dbo.Fnc_Formatear(TRECEPCIONDFD.cporcinvendible) AS Invendible, " +
            "dbo.Fnc_Formatear(TRECEPCIONDFD.ccalcimp) AS Impuesto, " +
            "dbo.Fnc_Formatear((TRECEPCIONDFD.cpresioprocarg-TRECEPCIONDFD.cporcinvendible)+TRECEPCIONDFD.ccalcimp) as Total " +
            "FROM TRECEPCIONDFD LEFT OUTER JOIN " +
            "TPROVEEDOR ON TRECEPCIONDFD.cproveedor = TPROVEEDOR.cproveedor " +
            "WHERE (TRECEPCIONDFD.cnfacturapro = '" + _P_Str_Factura + "') AND (TRECEPCIONDFD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRECEPCIONDFD.cidrecepcion = '" + _P_Str_Recepcion + "') AND " +
            "(TRECEPCIONDFD.cproveedor = '" + _P_Str_Proveedor + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_EliminarFactura(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Proveedor)
        {
            string _Str_Cadena = "DELETE FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproveedor='" + _P_Str_Proveedor + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE FROM TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_FirmarFactura(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Proveedor)
        {
            string _Str_Cadena = "UPDATE TRECEPCIONDFM SET cfirmado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND cproveedor='" + _P_Str_Proveedor + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Ini()
        {
            _Txt_Factura.Text = "";
            _Txt_Factura.Tag = "";
            _Txt_Fecha.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Total.Text = "";
            _Txt_Proveedor.Tag = "";
            _Txt_Proveedor.Text = "";
            _Dg_Detalle.DataSource = null;
        }
        private void Frm_FacturasPorFirmar_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _Txt_Factura.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Factura", e.RowIndex);
                _Txt_Factura.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cidrecepcion", e.RowIndex);
                _Txt_Fecha.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Fecha", e.RowIndex);
                _Txt_Monto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Monto", e.RowIndex);
                _Txt_Invendible.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Invendible", e.RowIndex);
                _Txt_Impuesto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Impuesto", e.RowIndex);
                _Txt_Total.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Total", e.RowIndex);
                _Txt_Proveedor.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cproveedor", e.RowIndex);
                _Txt_Proveedor.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("c_nomb_comer", e.RowIndex);
                _Mtd_Mostar_Detalle(_Ctrl_Busqueda1._Mtd_RetornarStringCelda("cidrecepcion", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("Factura", e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cproveedor", e.RowIndex));
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Factura.Text.Trim().Length == 0 & e.TabPageIndex == 1) { e.Cancel = true; }
        }
        int _Int_Clave = 0;
        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la factura?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Int_Clave = 1;
                _Lbl_Texto.Text = "¿Esta seguro de eliminar la factura?";
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Bt_Firmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de firmar la factura?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Int_Clave = 2;
                _Lbl_Texto.Text = "¿Esta seguro de firmar la factura?";
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Int_Clave == 1)
                { _Mtd_EliminarFactura(Convert.ToString(_Txt_Factura.Tag).Trim(), _Txt_Factura.Text.Trim(), Convert.ToString(_Txt_Proveedor.Tag).Trim()); }
                else
                { _Mtd_FirmarFactura(Convert.ToString(_Txt_Factura.Tag).Trim(), _Txt_Factura.Text.Trim(), Convert.ToString(_Txt_Proveedor.Tag).Trim()); }
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Pnl_Clave.Visible = false;
                _Mtd_Ini();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }
    }
}