using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Inf_OrdenCompra : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_OrdenCompra()
        {
            InitializeComponent();
        }

        private void _Mtd_ListaCheckProv()
        {
            string _Str_Sql = "SELECT DISTINCT TPROVEEDOR.cproveedor,(TPROVEEDOR.cproveedor+' - '+TPROVEEDOR.c_nomb_fiscal) as c_nomb_fiscal FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) ORDER BY c_nomb_fiscal";
            _myUtilidad._Mtd_CargarCheckList(_LstChk_Prov, _Str_Sql);
            
        }
        private void _Mtd_Ini()
        {
            _Mtd_ListaCheckProv();
            _Dt_Desde.ValueChanged -= new EventHandler(_Dt_Desde_ValueChanged);
            _Dt_Hasta.ValueChanged -= new EventHandler(_Dt_Hasta_ValueChanged);
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dg_Consulta.Rows.Clear();
            _Dt_Hasta.ValueChanged += new EventHandler(_Dt_Hasta_ValueChanged);
            _Dt_Desde.ValueChanged += new EventHandler(_Dt_Desde_ValueChanged);
            _Chk_All.Checked = false;
        }
        private void _Mtd_CargarConsulta()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_FiltroProv = "";
            DataSet _Ds_A;
            object[] _My_Obj = new object[7];
            foreach (object _Obj in _LstChk_Prov.CheckedItems)
            {
                _Str_FiltroProv = _Str_FiltroProv + " TORDENCOMPM.cproveedor='" + ((Clases._Cls_ArrayList)_Obj).Value + "' or";
            }
            if (_Str_FiltroProv.Length > 0)
            {
                _Str_FiltroProv = _Str_FiltroProv.Substring(0, _Str_FiltroProv.Length - 2);
                _Dg_Consulta.Rows.Clear();
                _Chk_All.Checked = false;
                string _Str_Sql = "SELECT TORDENCOMPM.ccompany, TORDENCOMPM.cnumoc, TORDENCOMPM.cproveedor, TPROVEEDOR.c_nomb_fiscal, (TORDENCOMPM.cproveedor + ' - ' + TPROVEEDOR.c_nomb_fiscal) as cprovname,"
                          + "TORDENCOMPM.cfechaoc, TORDENCOMPM.cdelete "
                          + "FROM TPROVEEDOR INNER JOIN "
                          + "TORDENCOMPM ON TPROVEEDOR.cproveedor = TORDENCOMPM.cproveedor WHERE TORDENCOMPM.cdelete=0 AND TORDENCOMPM.ccompany='" + Frm_Padre._Str_Comp + "' AND convert(datetime,convert(varchar(255),TORDENCOMPM.cfechaoc,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' and '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "' and (" + _Str_FiltroProv + ") ORDER BY TORDENCOMPM.cproveedor,TORDENCOMPM.cnumoc";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                {
                    _My_Obj[0] = null;
                    _My_Obj[1] = _Drow["cnumoc"].ToString();
                    _My_Obj[2] = Convert.ToDateTime(_Drow["cfechaoc"]).ToShortDateString();
                    _My_Obj[3] = _Drow["cprovname"].ToString().Trim();
                    _Str_Sql = "SELECT * " +
                    "FROM vst_tabordencompra " +
                    "WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND cnumoc='" + _Drow["cnumoc"].ToString() + "' AND (cocaprovee=1) AND (centroinvent=0) AND (ccerrada=0) AND (cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'))";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _My_Obj[4] = true;
                    }
                    else
                    {
                        _My_Obj[4] = false;
                    }
                    _Str_Sql = "SELECT * "
                          + "FROM TRECEPCIONDFM INNER JOIN "
                          + "TNOTARECEPC ON TRECEPCIONDFM.cgroupcomp = TNOTARECEPC.cgroupcomp AND "
                          + "TRECEPCIONDFM.cidrecepcion = TNOTARECEPC.cidrecepcion AND "
                          + "TRECEPCIONDFM.cnfacturapro = TNOTARECEPC.cnumdocu INNER JOIN "
                          + "TPROVEEDOR ON TRECEPCIONDFM.cproveedor = TPROVEEDOR.cproveedor "
                          + "WHERE (TRECEPCIONDFM.cnotarecepcion = '1')  AND ccopiaoc='" + _Drow["cnumoc"].ToString() + "' AND TRECEPCIONDFM.cproveedor='" + _Drow["cproveedor"].ToString() + "' AND "
                          + "TNOTARECEPC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTARECEPC.ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _My_Obj[5] = true;
                    }
                    else
                    {
                        _My_Obj[5] = false;
                    }
                    _My_Obj[6] = _Drow["cproveedor"].ToString();
                    _Dg_Consulta.Rows.Add(_My_Obj);
                }

                _Dg_Consulta.ReadOnly = false;
                foreach (DataGridViewColumn _DgCol in _Dg_Consulta.Columns)
                {
                    if (_DgCol.Index > 0)
                    {
                        _DgCol.ReadOnly = true;
                    }
                }
                _Dg_Consulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Seleccione al menos un proveedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
        }
        private void Frm_Inf_OrdenCompra_Load(object sender, EventArgs e)
        {
            _Mtd_Ini();
        }

        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_CargarConsulta();
        }

        private void _Chk_All_CheckedChanged(object sender, EventArgs e)
        {
            _Dg_Consulta.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_Consulta_CellValueChanged);
            if (_Chk_All.Checked)
            {
                foreach (DataGridViewRow _DgRow in _Dg_Consulta.Rows)
                {
                    _DgRow.Cells[0].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow _DgRow in _Dg_Consulta.Rows)
                {
                    _DgRow.Cells[0].Value = false;
                }
            }
            _Dg_Consulta.CellValueChanged += new DataGridViewCellEventHandler(_Dg_Consulta_CellValueChanged);
            if (_Dg_Consulta.Rows.Count > 0)
            {
                _Dg_Consulta.CurrentCell = _Dg_Consulta[0, _Dg_Consulta.RowCount - 1];
            }
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
            _Dg_Consulta.Rows.Clear();
            _Chk_All.Checked = false;
        }

        private void _Bt_Print_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_WhereOC = "", _Str_Where = "";
            foreach (DataGridViewRow _DgRow in _Dg_Consulta.Rows)
            {
                if (Convert.ToBoolean(_DgRow.Cells[0].Value))
                {
                    _Str_WhereOC = _Str_WhereOC + " cnumoc=" + _DgRow.Cells[1].Value.ToString() + " or";
                }
            }
            if (_Str_WhereOC.Length > 0)
            {
                _Str_WhereOC = _Str_WhereOC.Substring(0, _Str_WhereOC.Length - 2);
                _Str_Where = "ccompany='" + Frm_Padre._Str_Comp + "' and (" + _Str_WhereOC + ")";
                REPORTESS _Frm = new REPORTESS(new string[] { "VST_OC" }, "", "T3.Report.rOC", "Section1", "cabecera", "rif", "nit", _Str_Where);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ordenes de compra.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {
            _Dg_Consulta.Rows.Clear();
            _Chk_All.Checked = false;
        }

        private void _Dg_Consulta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Consulta.RowCount > 0)
            {
                if (Convert.ToBoolean(_Dg_Consulta[0, e.RowIndex].Value))
                {
                    _Chk_All.CheckedChanged -= new EventHandler(_Chk_All_CheckedChanged);
                    _Chk_All.Checked = false;
                    _Chk_All.CheckedChanged += new EventHandler(_Chk_All_CheckedChanged);
                }
            }
        }
    }
}