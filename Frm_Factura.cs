using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Factura : Form
    {
        public Frm_Factura()
        {
            InitializeComponent();
        }
        bool _Bol_Constructor = false;
        public Frm_Factura(bool _P_Bool)
        {
            InitializeComponent();
            string _Str_cadena = "SELECT cidrecepcion as Recepción,cdate AS Fecha,c_nomb_abreviado AS Proveedor,cproveedor,cplaca,ctdiferencia " +
 "FROM vst_tabdeevaluacionespendientes WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "'"; 
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Bol_Constructor = true;
        }
        int _Int_Numero = 0;
        public Frm_Factura(int _P_Int_Numero)
        {
            InitializeComponent();
            _Int_Numero = _P_Int_Numero;
            string _Str_cadena = "SELECT cidrecepcion as Recepción,cdateemifactura AS Fecha,cnfacturapro as Factura,( select c_nomb_abreviado from TPROVEEDOR where TPROVEEDOR.cproveedor=TRECEPCIONDFM.cproveedor) AS Proveedor,cproveedor FROM TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccomparafactdes='1' and not exists(Select * from TNOTARECEPC where TNOTARECEPC.cgroupcomp=TRECEPCIONDFM.cgroupcomp and TNOTARECEPC.cidrecepcion=TRECEPCIONDFM.cidrecepcion and TNOTARECEPC.cnumdocu=TRECEPCIONDFM.cnfacturapro)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Frm_Factura_Load(object sender, EventArgs e)
        {
            if (!_Bol_Constructor & _Int_Numero==0)
            {
                string _Str_cadena = "SELECT DISTINCT TRECEPCIONM.cidrecepcion as Recepción,TRECEPCIONM.cdate AS Fecha, TPROVEEDOR.c_nomb_abreviado AS Proveedor,TRECEPCIONM.cproveedor,TRECEPCIONM.cplaca, TGRUPPROVEE.ccompany AS Compañía " +
    "FROM TRECEPCIONM INNER JOIN " +
    "TPROVEEDOR ON TRECEPCIONM.cproveedor = TPROVEEDOR.cproveedor LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor " +
    "WHERE (TRECEPCIONM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND cglobal='1' AND (TRECEPCIONM.ccerrada = 0) AND (TRECEPCIONM.cevaluado = 0)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
                _Dg_Grid.DataSource = _Ds.Tables[0];
                _Dg_Grid.Columns[3].Visible = false;
                _Dg_Grid.Columns[4].Visible = false;
                _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_Bol_Constructor & _Int_Numero == 0)
                {
                    string _Str_cadena = "SELECT cnfacturapro from TRECEPCIONRELDIF where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        string[] _Str_Facturas = new string[_Ds.Tables[0].Rows.Count];
                        int _Int_i = 0;
                        foreach (DataRow _Row in _Ds.Tables[0].Rows)
                        {
                            _Str_Facturas[_Int_i] = _Row[0].ToString();
                            _Int_i++;
                        }
                        Cursor = Cursors.WaitCursor;
                        Frm_OC_FAC _Frm = new Frm_OC_FAC(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString(), Convert.ToInt32(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[5].Value.ToString()), _Str_Facturas, 1);
                        Cursor = Cursors.Default;
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                        this.Close();
                    }
                }
                else if (_Int_Numero == 1)
                {
                    Frm_ASCII_FAC _Frm = new Frm_ASCII_FAC(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[2].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                    this.Close();
                }
            }
            catch { }
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
    }
}