using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Inf_ComprasDetalladas : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_ComprasDetalladas()
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
            _Dt_Hasta.ValueChanged += new EventHandler(_Dt_Hasta_ValueChanged);
            _Dt_Desde.ValueChanged += new EventHandler(_Dt_Desde_ValueChanged);
            _Chk_All.Checked = false;
        }
        private void _Chk_All_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_All.Checked)
            {
                for (int _I = 0; _I < _LstChk_Prov.Items.Count; _I++)
                {
                    _LstChk_Prov.SetItemChecked(_I, true);
                }
            }
            else
            {
 
            }
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void Frm_Inf_ComprasDetalladas_Load(object sender, EventArgs e)
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

        private void _Bt_Consulta_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            string _Str_Rango = "Del " + _Dt_Desde.Value.ToShortDateString() + " al " + _Dt_Hasta.Value.ToShortDateString();
            string _Str_WhereProv = "", _Str_Where = "";
            if (_LstChk_Prov.CheckedItems.Count > 0)
            {
                foreach (object _Obj in _LstChk_Prov.CheckedItems)
                {
                    _Str_WhereProv = _Str_WhereProv + " cproveedor='" + ((Clases._Cls_ArrayList)_Obj).Value + "' or";
                }
                _Str_WhereProv = _Str_WhereProv.Substring(0, _Str_WhereProv.Length - 2);
                _Str_Where = "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND convert(datetime,convert(varchar(255),cfechanotrecep,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "' AND  (" + _Str_WhereProv + ")";
                _Str_Sql = "SELECT * FROM VST_COMPRAPRODUCTOS WHERE " + _Str_Where;
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                {
                    if (_Chk_Productos.Checked)
                    {
                        if (_Rb_Simp.Checked)
                        {
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_COMPRAPRODUCTOS" }, "", "T3.Report.rListCprProductos", "Section2", _Str_Rango, "rif", "nit", _Str_Where);
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                        }
                        else if (_Rb_Cimp.Checked)
                        {
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_COMPRAPRODUCTOS" }, "", "T3.Report.rListCprProductosCimp", "Section2", _Str_Rango, "rif", "nit", _Str_Where);
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                        }
                    }
                    else
                    {
                        if (_Rb_Simp.Checked)
                        {
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_NOTARECEPC" }, "", "T3.Report.rListCprProvDet", "Section2", _Str_Rango, "rif", "nit", _Str_Where);
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                        }
                        else if (_Rb_Cimp.Checked)
                        {
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_NOTARECEPC" }, "", "T3.Report.rListCprProvDetCimp", "Section2", _Str_Rango, "rif", "nit", _Str_Where);
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para hasta búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}