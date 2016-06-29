using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_CxPVista : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_CxPVista()
        {
            InitializeComponent();
        }

        public Frm_CxPVista(string _Pr_StrProvId,DataGridViewRowCollection _Pr_DgRow, double _Pr_DblMonto)
        {
            InitializeComponent();
            _DgRowFrm = _Pr_DgRow;
            _Str_FrmProvId = _Pr_StrProvId;
            _Dbl_FrmMontoOP = _Pr_DblMonto;
        }

        DataGridViewRowCollection _DgRowFrm;
        double _Dbl_FrmMontoOP = 0;
        string _Str_FrmProvId = "";
        public bool _Bol_FrmResult = false;
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        private void Frm_CxPVista_Load(object sender, EventArgs e)
        {
            _Mtd_CargarBusqueda();
            _Mtd_QuitarFilasYaSel();
        }

        public void _Mtd_QuitarFilasYaSel()
        {
            bool _Bol_Sw = false;
            int _Int_I = 0;
            do
            {
                foreach (DataGridViewRow _DgRowOrigen in _DgRowFrm)
                {
                    if (_Dg_Grid_Rp.Rows.Count > 0)
                    {
                        try
                        {
                            //PROVEEDOR                                                                            TPO. DOC                                                                                      NUM. DOC.
                            if (Convert.ToString(_Dg_Grid_Rp[8, _Int_I].Value) == _Str_FrmProvId && Convert.ToString(_Dg_Grid_Rp[13, _Int_I].Value) == Convert.ToString(_DgRowOrigen.Cells[8].Value) && Convert.ToString(_Dg_Grid_Rp[4, _Int_I].Value) == Convert.ToString(_DgRowOrigen.Cells[2].Value))
                            {
                                _Dg_Grid_Rp.Rows.RemoveAt(_Int_I);
                                _Bol_Sw = true;
                            }
                        }
                        catch { }
                    }
                }
                if (!_Bol_Sw)
                {
                    _Int_I++;
                }
                else
                { _Bol_Sw = false; }
            }
            while (_Int_I < _Dg_Grid_Rp.Rows.Count);
        }

        private void _Mtd_CargarBusqueda()
        {
            string _Str_Sql = "";
            object[] _Str_RowNew = new object[17];
            _Str_Sql = "Select cidfactxp,c_nomb_comer,CONVERT(varchar, cfechaemision, 103) as cfechaemision,CONVERT(varchar, cfechavencimiento, 103) as cfechavencimiento,cnumdocu,cname,cmontodocshow,csaldoshow,cproveedor,cordenpaghecha,vencimiento,ctotalimp,cvencimientodias,ctipodocument,cfact_afectada,cidnotrecepc,cidcomprobret from VST_FACTPPAGARM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cactivo=1 AND canulado=0 AND csaldo <> 0 AND ((SELECT COUNT(*) FROM TCOMPROBANISLRC WHERE TCOMPROBANISLRC.ccompany=VST_FACTPPAGARM.ccompany AND TCOMPROBANISLRC.cidcomprobislr=VST_FACTPPAGARM.cidcomprobislr AND TCOMPROBANISLRC.cimpreso=0 AND TCOMPROBANISLRC.canulado=0)=0) AND NOT EXISTS(SELECT TPAGOSCXPM.cidordpago FROM TPAGOSCXPM INNER JOIN TPAGOSCXPD ON TPAGOSCXPM.cgroupcomp = TPAGOSCXPD.cgroupcomp AND TPAGOSCXPM.ccompany = TPAGOSCXPD.ccompany AND TPAGOSCXPM.cidordpago = TPAGOSCXPD.cidordpago AND TPAGOSCXPM.cproveedor = TPAGOSCXPD.cproveedor WHERE (TPAGOSCXPM.cgroupcomp = VST_FACTPPAGARM.cgroupcomp) AND (TPAGOSCXPM.ccompany = VST_FACTPPAGARM.ccompany) AND (TPAGOSCXPM.cproveedor=VST_FACTPPAGARM.cproveedor) AND (TPAGOSCXPD.ctipodocument = VST_FACTPPAGARM.ctipodocument) AND (TPAGOSCXPD.cnumdocu = VST_FACTPPAGARM.cnumdocu) AND (TPAGOSCXPM.canulado = 0))";
            _Str_Sql += " AND NOT EXISTS(select cidreposiciones from TREPOSICIONESD where cgroupcomp=VST_FACTPPAGARM.cgroupcomp and ccompany=VST_FACTPPAGARM.ccompany and cproveedor=VST_FACTPPAGARM.cproveedor and cnumdocu=VST_FACTPPAGARM.cnumdocu and ctipodocument=VST_FACTPPAGARM.ctipodocument)";
            _Str_Sql = _Str_Sql + " AND cproveedor='" + _Str_FrmProvId + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid_Rp.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Grid_Rp.Rows.Add(_Str_RowNew);
                if (Convert.ToString(_Dg_Grid_Rp[9, _Dg_Grid_Rp.RowCount - 1].Value) == "1")
                {
                    _Dg_Grid_Rp.Rows[_Dg_Grid_Rp.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
            //FORMATEO EL COLOR DE LAS CELDAS DE LOS NUMERO NEGATIVOS
            foreach (DataGridViewRow _DgRow in _Dg_Grid_Rp.Rows)
            {
                if (Convert.ToDouble(Convert.ToString(_DgRow.Cells[6].Value)) < 0)
                {
                    _DgRow.Cells[6].Style.ForeColor = Color.Red;

                }
                _DgRow.Cells[6].Value = Convert.ToDouble(_DgRow.Cells[6].Value).ToString("#,##0.00");
                if (Convert.ToDouble(Convert.ToString(_DgRow.Cells[7].Value)) < 0)
                {

                    _DgRow.Cells[7].Style.ForeColor = Color.Red;

                }
                _DgRow.Cells[7].Value = Convert.ToDouble(_DgRow.Cells[7].Value).ToString("#,##0.00");
            }
            _Dg_Grid_Rp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            _Bol_FrmResult = true;
            this.Hide();
        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            _Bol_FrmResult = false;
            this.Hide();
        }

        private void _CMen_OrdPago_Sel_Click(object sender, EventArgs e)
        {
            double _Dbl_Total = 0;
            double _Dbl_Acum = 0;
            bool _Bol_Sw = false;
            foreach (DataGridViewRow _DgRow in _Dg_Grid_Rp.SelectedRows)
            {
                if (_Str_FrmProvId != Convert.ToString(_DgRow.Cells[8].Value))
                {
                    _Bol_Sw = true;
                    MessageBox.Show("El Pago Solo es a Un Proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }

            }

            //CALCULO EL TOTAL A PAGAR EN LA ORDEN DE PAGO
            if (!_Bol_Sw)
            {
                foreach (DataGridViewRow _DgRow in _Dg_Grid_Rp.SelectedRows)
                {
                    _Dbl_Acum = _Dbl_Acum + Convert.ToDouble(_DgRow.Cells[7].Value.ToString().Replace(".", ""));
                }

                _Dbl_Total = _Dbl_FrmMontoOP + _Dbl_Acum;

                if (_Dbl_Total <= 0)
                {
                    _Bol_Sw = true;
                    MessageBox.Show("El Monto a Pagar es Negativo o Cero.", "Valicación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //MARCO LAS FILAS.
            if (!_Bol_Sw)
            {
                foreach (DataGridViewRow _DgRow in _Dg_Grid_Rp.SelectedRows)
                {
                    if (Convert.ToString(_DgRow.Cells[17].Value) == "1")
                    {
                        if (Convert.ToString(_DgRow.Cells[9].Value) != "1")
                        {
                            _DgRow.DefaultCellStyle.BackColor = Color.White;
                            _DgRow.Cells[6].Style.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                            _DgRow.Cells[7].Style.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                            _DgRow.Cells[17].Value = "0";
                        }
                    }
                    else
                    {
                        if (Convert.ToString(_DgRow.Cells[9].Value) != "1")
                        {
                            _DgRow.DefaultCellStyle.BackColor = Color.Red;
                            _DgRow.Cells[6].Style.BackColor = Color.Red;
                            _DgRow.Cells[7].Style.BackColor = Color.Red;
                            _DgRow.Cells[17].Value = "1";
                        }
                    }
                }
            }
        }

        private void _Pnl_A_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Dg_Grid_Rp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Dg_Grid_Rp.ContextMenuStrip = _CMen_OrdPago;
        }

        private void _Dg_Grid_Rp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _Dg_Grid_Rp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                _Dg_Grid_Rp.ContextMenuStrip = null;
                
            }
        }

        private void _CMen_OrdPago_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToString(_Dg_Grid_Rp[17, _Dg_Grid_Rp.RowCount - 1].Value) == "1")
            {
                _CMen_OrdPago_Sel.Text = "Desmarcar";
            }
            else
            {
                _CMen_OrdPago_Sel.Text = "Seleccionar";
            }
        }

        private void _Dg_Grid_Rp_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
    }
}