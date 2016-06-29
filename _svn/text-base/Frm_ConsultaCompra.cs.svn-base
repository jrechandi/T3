using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaCompra : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ConsultaCompra()
        {
            InitializeComponent();
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
        private void _Mtd_Cargar_NR(string _P_Str_Proveedor, DateTime _P_Dtm_Desde)
        {
            string _Str_Cadena = "SELECT DISTINCT cidnotrecepc,cidnotrecepc FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechanotrecep,103))>=CONVERT(DATETIME,'" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "') AND ctiponotrecep='C' ORDER BY cidnotrecepc";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_NR, _Str_Cadena);
        }
        private void _Mtd_CargarInformacion(string _P_Str_NR)
        {
            string _Str_Cadena = "SELECT CONVERT(VARCHAR,cfechanotrecep,103) AS cfechanotrecep, c_nomb_comer, dbo.Fnc_Formatear(cmontosi) AS cmontosi, dbo.Fnc_Formatear(cmontoimp) AS cmontoimp, dbo.Fnc_Formatear(TNOTARECEPC.cporcinvendible) AS cporcinvendible, dbo.Fnc_Formatear((cmontosi-TNOTARECEPC.cporcinvendible)+cmontoimp) AS Total, cidrecepcion FROM TNOTARECEPC INNER JOIN TPROVEEDOR ON TNOTARECEPC.cproveedor=TPROVEEDOR.cproveedor AND (TNOTARECEPC.ccompany=TPROVEEDOR.ccompany OR cglobal='1') WHERE TNOTARECEPC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTARECEPC.ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _P_Str_NR + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_FechNR.Text = _Ds.Tables[0].Rows[0]["cfechanotrecep"].ToString().Trim();
                _Txt_Proveedor.Text = _Ds.Tables[0].Rows[0]["c_nomb_comer"].ToString().Trim();
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["cmontosi"].ToString().Trim();
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0]["cmontoimp"].ToString().Trim();
                _Txt_Invendible.Text = _Ds.Tables[0].Rows[0]["cporcinvendible"].ToString().Trim();
                _Txt_Total.Text = _Ds.Tables[0].Rows[0]["Total"].ToString().Trim();
                string _Str_ID_Recepcion = _Ds.Tables[0].Rows[0]["cidrecepcion"].ToString().Trim();
                //-------------------------------------Orden de Compra
                _Str_Cadena = "SELECT DISTINCT TORDENCOMPD.cnumoc AS [O.C], TORDENCOMPD.cproducto AS Producto, TPRODUCTO.cnamefc AS Descripción, TORDENCOMPD.ccantunidadma1 AS Cajas, " +
                "TORDENCOMPD.ccantunidadma2 AS Unidades, dbo.Fnc_Formatear(TORDENCOMPD.ctotcostosimp) AS Monto, dbo.Fnc_Formatear(TORDENCOMPD.cimpcosto) AS Inpuesto, " +
                "dbo.Fnc_Formatear(TORDENCOMPD.ctotcostosimp + TORDENCOMPD.cimpcosto) AS Total " +
                "FROM TORDENCOMPD INNER JOIN " +
                "TRECEPCIONRELDIF ON TORDENCOMPD.cnumoc = TRECEPCIONRELDIF.cnumoc INNER JOIN " +
                "TPRODUCTO ON TORDENCOMPD.cproducto = TPRODUCTO.cproducto " +
                "WHERE (TRECEPCIONRELDIF.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TORDENCOMPD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TRECEPCIONRELDIF.cidrecepcion = '" + _Str_ID_Recepcion + "') AND (TORDENCOMPD.cdelete = 0) ORDER BY Producto";
                _Dg_Grid_OC.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
                _Dg_Grid_OC.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_OC.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_OC.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_OC.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_OC.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_OC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //-------------------------------------Factura
                _Str_Cadena = "SELECT DISTINCT TRECEPCIONDFD.cnfacturapro AS FACT, TRECEPCIONDFD.cproducto AS Producto, TPRODUCTO.cnamefc AS Descripción, TRECEPCIONDFD.cempaques AS Cajas, " +
                "TRECEPCIONDFD.cunidades AS Unidades, dbo.Fnc_Formatear(TRECEPCIONDFD.cpresioprocarg) AS Monto, " +
                "dbo.Fnc_Formatear(TRECEPCIONDFD.cporcinvendible) AS Invendible, dbo.Fnc_Formatear(TRECEPCIONDFD.ccalcimp) AS Impuesto, " +
                "dbo.Fnc_Formatear((TRECEPCIONDFD.cpresioprocarg - TRECEPCIONDFD.cporcinvendible) + TRECEPCIONDFD.ccalcimp) AS Total, " +
                "dbo.Fnc_Formatear(TRECEPCIONDFD.ccostobrutolote) AS [Costo bruto], dbo.Fnc_Formatear(TRECEPCIONDFD.cprecioventamax) AS PMV, dbo.Fnc_Formatear(TRECEPCIONDFD.cpreciolista) AS [Precio lista] " +
                "FROM TRECEPCIONRELDIF INNER JOIN " +
                "TRECEPCIONDFD ON TRECEPCIONRELDIF.cgroupcomp = TRECEPCIONDFD.cgroupcomp AND " +
                "TRECEPCIONRELDIF.cidrecepcion = TRECEPCIONDFD.cidrecepcion AND " +
                "TRECEPCIONRELDIF.cnfacturapro = TRECEPCIONDFD.cnfacturapro INNER JOIN " +
                "TPRODUCTO ON TRECEPCIONDFD.cproducto = TPRODUCTO.cproducto INNER JOIN " +
                "TNOTARECEPC ON TRECEPCIONDFD.cgroupcomp = dbo.TNOTARECEPC.cgroupcomp AND " +
                "TRECEPCIONDFD.cidrecepcion = dbo.TNOTARECEPC.cidrecepcion AND " +
                "TRECEPCIONDFD.cnfacturapro = dbo.TNOTARECEPC.cnumdocu " +
                "WHERE (TRECEPCIONRELDIF.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRECEPCIONRELDIF.cidrecepcion = '" + _Str_ID_Recepcion + "') AND (TNOTARECEPC.cidnotrecepc='" + _P_Str_NR + "') ORDER BY Producto";
                _Dg_Grid_FAC.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
                _Dg_Grid_FAC.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_FAC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //-------------------------------------Nota de Recepción
                _Str_Cadena = "SELECT TNOTARECEPD.cidnotrecepc AS [N.R], TNOTARECEPD.cproducto AS Producto, TPRODUCTO.cnamefc AS Descripción, TNOTARECEPD.cempaques AS Cajas, TNOTARECEPD.cunidades AS Unidades, " +
                "dbo.Fnc_Formatear(TNOTARECEPD.cmontosi) AS Monto, dbo.Fnc_Formatear(TNOTARECEPD.cporcinvendible) AS Invendible, dbo.Fnc_Formatear(TNOTARECEPD.cmontoimp) AS Impuesto, dbo.Fnc_Formatear((TNOTARECEPD.cmontosi - TNOTARECEPD.cporcinvendible) + TNOTARECEPD.cmontoimp) AS Total, " +
                "dbo.Fnc_Formatear(TNOTARECEPD.ccostobrutolote) AS [Costo bruto], dbo.Fnc_Formatear(TNOTARECEPD.cprecioventamax) AS PMV, dbo.Fnc_Formatear(TNOTARECEPD.cpreciolista) AS [Precio lista] " +
                "FROM TNOTARECEPD INNER JOIN TPRODUCTO ON TNOTARECEPD.cproducto = TPRODUCTO.cproducto " +
                "WHERE (TNOTARECEPD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TNOTARECEPD.ccompany='" + Frm_Padre._Str_Comp + "') AND (TNOTARECEPD.cidnotrecepc='" + _P_Str_NR + "') ORDER BY Producto";
                _Dg_Grid_NR.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
                _Dg_Grid_NR.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid_NR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void _Mtd_Ini()
        {
            _Txt_FechNR.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_Total.Text = "";
            _Dg_Grid_OC.DataSource = null;
            _Dg_Grid_FAC.DataSource = null;
            _Dg_Grid_NR.DataSource = null;
        }
        private void Frm_ConsultaCompra_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void _Cmb_NR_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Ini();
            if (_Cmb_NR.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarInformacion(_Cmb_NR.SelectedValue.ToString().Trim()); Cursor = Cursors.Default; }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(33);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Proveedor.Tag = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().ToUpper();
                _Txt_Proveedor.Text = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().ToUpper();
                _Mtd_Cargar_NR(Convert.ToString(_Txt_Proveedor.Tag), _Dt_Desde.Value);
            }
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _Cmb_NR.DataSource = null;
            _Txt_Proveedor.Tag = "";
            _Txt_Proveedor.Text = "";
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Txt_Proveedor.Tag).Trim().Length > 0)
            {
                _Mtd_Cargar_NR(Convert.ToString(_Txt_Proveedor.Tag), _Dt_Desde.Value);
            }
        }

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            if (_Cmb_NR.SelectedIndex > 0)
            {
                SaveFileDialog _Sfd_1 = new SaveFileDialog();
                _Sfd_1.Filter = "xls files (*.xls)|*.xls";
                if (_Sfd_1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                    _MyExcel._Mtd_DatasetToExcel(new DataTable[] { (DataTable)_Dg_Grid_NR.DataSource, (DataTable)_Dg_Grid_FAC.DataSource, (DataTable)_Dg_Grid_OC.DataSource }, _Sfd_1.FileName, new string[] { "Nota de Recepción", "Factura", "Orden de Compra" });
                    _MyExcel = null;
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Nota de Recepción", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
