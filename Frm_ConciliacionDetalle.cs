using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConciliacionDetalle : Form
    {
        string _Str_Frm_BancoId = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _MyFormato = new clslibraryconssa._Cls_Formato("es-VE");
        DataGridView _Dg_MovCont;
        DataGridView _Dg_MovBanco;
        public Frm_ConciliacionDetalle()
        {
            InitializeComponent();
        }

        public Frm_ConciliacionDetalle(int _Pr_Int_Tpo, DataGridView _Pr_DgMovCont, DataGridView _Pr_DgMovBanco, string _Pr_Str_BancoId)
        {
            _Str_Frm_BancoId = _Pr_Str_BancoId;
            _Dg_MovCont = _Pr_DgMovCont;
            _Dg_MovBanco = _Pr_DgMovBanco;
            InitializeComponent();
            switch (_Pr_Int_Tpo)
            {
                case 1: //CHEQUES EN TRANSITO
                    _Mtd_CargarGridChequeTransito(_Str_Frm_BancoId);
                    this.Text = "Cheques en tránsito";
                    break;
                case 2://Depósitos no registrados en contabilidad:
                    _Mtd_CargarGridDepNoRegCont(_Str_Frm_BancoId);
                    this.Text = "Depósitos no registrados en contabilidad";
                    break;
                case 3://Depósitos no registrados en banco:
                    _Mtd_CargarGridDepNoRegBanco(_Str_Frm_BancoId);
                    this.Text = "Depósitos no registrados en banco";
                    break;
                case 4://N.D. no registradas en contabilidad:
                    _Mtd_CargarGridNDNoRegCont(_Str_Frm_BancoId);
                    this.Text = "N.D. no registradas en contabilidad";
                    break;
                case 5://N.D. no registradas en Banco:
                    _Mtd_CargarGridNDNoRegBanco(_Str_Frm_BancoId);
                    this.Text = "N.D. no registradas en Banco";
                    break;
                case 6://Diferencia en conciliación:
                    _Mtd_CargarGridDifConci();
                    this.Text = "Diferencia en conciliación";
                    break;

            }
            _Txt_Total.Text = _Mtd_CalcularTotal().ToString("#,##0.00");
        }

        public Frm_ConciliacionDetalle(int _Pr_Int_Tpo, string[,] _Pr_Str_Data, string _Pr_Str_BancoId, DataGridView _Pr_DgMovCont, DataGridView _Pr_DgMovBanco)
        {
            _Str_Frm_BancoId = _Pr_Str_BancoId;
            _Dg_MovCont = _Pr_DgMovCont;
            _Dg_MovBanco = _Pr_DgMovBanco;
            InitializeComponent();
            switch (_Pr_Int_Tpo)
            {
                case 1: //CHEQUES EN TRANSITO
                    _Mtd_CargarGrid(_Pr_Str_BancoId, _Pr_Str_Data);
                    this.Text = "Cheques en tránsito";
                    break;
                case 2://Depósitos no registrados en contabilidad:
                    _Mtd_CargarGrid(_Pr_Str_BancoId, _Pr_Str_Data);
                    this.Text = "Depósitos no registrados en contabilidad";
                    break;
                case 3://Depósitos no registrados en banco:
                    _Mtd_CargarGrid(_Pr_Str_BancoId, _Pr_Str_Data);
                    this.Text = "Depósitos no registrados en banco";
                    break;
                case 4://N.D. no registradas en contabilidad:
                    _Mtd_CargarGrid(_Pr_Str_BancoId, _Pr_Str_Data);
                    this.Text = "N.D. no registradas en contabilidad";
                    break;
                case 5://N.D. no registradas en Banco:
                    _Mtd_CargarGrid(_Pr_Str_BancoId, _Pr_Str_Data);
                    this.Text = "N.D. no registradas en Banco";
                    break;
                case 6://Diferencia en conciliación:
                    _Mtd_CargarGridDifConci();
                    this.Text = "Diferencia en conciliación";
                    break;

            }
            _Txt_Total.Text = _Mtd_CalcularTotal().ToString("#,##0.00");
        }

        private void Frm_ConciliacionDetalle_Load(object sender, EventArgs e)
        {
            _Txt_Total.ReadOnly = true;
        }

        private void _Mtd_CargarGridChequeTransito(string _Pr_Str_BancoId)
        {
            object[] _Str_RowNew = new object[3];
            string _Str_Sql = "SELECT cnumdocu,cdescipcion,cmonto FROM VST_CHEQUETRANSITO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_DetGen.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_DetGen.Rows.Add(_Str_RowNew);
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGrid(string _Pr_Str_BancoId, string[,] _Pr_Str_Data)
        {
            int _Int_Fil = 0;
            _Dg_DetGen.Rows.Clear();
            _Int_Fil = _Pr_Str_Data.GetUpperBound(1);
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                _Dg_DetGen.Rows.Add();
                _Dg_DetGen[0, _Dg_DetGen.RowCount - 1].Value = _Pr_Str_Data[0, _Int_F].ToString();
                _Dg_DetGen[1, _Dg_DetGen.RowCount - 1].Value = _Pr_Str_Data[1, _Int_F].ToString();
                _Dg_DetGen[2, _Dg_DetGen.RowCount - 1].Value = _Pr_Str_Data[2, _Int_F].ToString();
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGridDepNoRegCont(string _Pr_Str_BancoId)
        {
            object[] _Str_RowNew = new object[3];
            string _Str_Sql = "SELECT cnumdocu,cconcepto,cmontomov FROM VST_DEP_NO_REG_CONTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_DetGen.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_DetGen.Rows.Add(_Str_RowNew);
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGridDepNoRegBanco(string _Pr_Str_BancoId)
        {
            object[] _Str_RowNew = new object[3];
            string _Str_Sql = "SELECT cnumdocu,cdescipcion,cmonto FROM VST_DEP_NO_REG_BANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_DetGen.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_DetGen.Rows.Add(_Str_RowNew);
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGridNDNoRegCont(string _Pr_Str_BancoId)
        {
            object[] _Str_RowNew = new object[3];
            string _Str_Sql = "SELECT cnumdocu,cconcepto,cmontomov FROM VST_ND_NOREG_CONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_DetGen.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_DetGen.Rows.Add(_Str_RowNew);
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGridNDNoRegBanco(string _Pr_Str_BancoId)
        {
            object[] _Str_RowNew = new object[3];
            string _Str_Sql = "SELECT cnumdocu,cdescipcion,cmonto FROM VST_ND_NOREG_BANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_DetGen.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_DetGen.Rows.Add(_Str_RowNew);
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarGridDifConci()
        {
            DataTable _Dt_;
            _Dt_ = _Mtd_DsDifConcil();
            _Dg_DetGen.Rows.Clear();
            foreach (DataRow _Drow in _Dt_.Rows)
            {
                _Dg_DetGen.Rows.Add();
                _Dg_DetGen[0, _Dg_DetGen.RowCount - 1].Value = Convert.ToString(_Drow["cnumdocu"]);
                _Dg_DetGen[1, _Dg_DetGen.RowCount - 1].Value = Convert.ToString(_Drow["cconcepto"]);
                _Dg_DetGen[2, _Dg_DetGen.RowCount - 1].Value = Convert.ToString(_Drow["cmontomov"]);
            }
            _Dg_DetGen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private DataTable _Mtd_DsDifConcil()
        {
            string _Str_TpoOperConvert = "";
            double _Dbl_MontoMovCont = 0;
            double _Dbl_MontoMovBanco = 0;
            double _Dbl_MontoDif = 0;
            bool _Bol_Cell = false;
            bool _Bol_CellA = false;
            DataSet _Ds1;
            DataRow _MyRow;
            DataTable _Dt = new DataTable();
            _Dt.Columns.Add("cfecha", Type.GetType("System.String"));
            _Dt.Columns.Add("ctdocuoper", Type.GetType("System.String"));
            _Dt.Columns.Add("cnumdocu", Type.GetType("System.String"));
            _Dt.Columns.Add("cconcepto", Type.GetType("System.String"));
            _Dt.Columns.Add("cmontomov", Type.GetType("System.String"));


            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                _Dbl_MontoMovCont = 0;
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                    {
                        _Dbl_MontoMovCont = Convert.ToDouble(_DgRow.Cells[5].Value);
                    }

                    foreach (DataGridViewRow _DgRowA in _Dg_MovBanco.Rows)
                    {
                        _Bol_CellA = false;
                        _Dbl_MontoMovBanco = 0;
                        if (Convert.ToString(_DgRowA.Cells[6].Value) != "")
                        {
                            _Bol_CellA = Convert.ToBoolean(_DgRowA.Cells[6].Value);
                        }
                        if (_Bol_CellA)
                        {
                            if (Convert.ToString(_DgRowA.Cells[5].Value) != "")
                            {
                                _Dbl_MontoMovBanco = Convert.ToDouble(_DgRowA.Cells[5].Value);
                            }

                            if (_Dbl_MontoMovBanco != 0 && _Dbl_MontoMovCont != 0)
                            {
                                if (Convert.ToInt32(_DgRow.Cells[0].Value) == Convert.ToInt32(_DgRowA.Cells[0].Value))
                                {
                                    //CONVIERTO EL TIPO DE OPERACION DE TDISPBAND
                                    _Ds1 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + _Str_Frm_BancoId + "','" + Convert.ToString(_DgRowA.Cells[1].Value) + "')");
                                    if (_Ds1.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(_Ds1.Tables[0].Rows[0][0]) != "")
                                        {
                                            _Str_TpoOperConvert = Convert.ToString(_Ds1.Tables[0].Rows[0][0]);
                                        }
                                    }

                                    if (_Str_TpoOperConvert != "")
                                    {
                                        if (Convert.ToString(_DgRow.Cells[1].Value) == _Str_TpoOperConvert)
                                        {
                                            //VERIFICO SI LOS MONTOS SON DIFERENTES
                                            if (_Dbl_MontoMovBanco != _Dbl_MontoMovCont)
                                            {
                                                _Dbl_MontoDif = _Dbl_MontoMovCont - _Dbl_MontoMovBanco;
                                                //AGREGO AL DATASET
                                                _MyRow = _Dt.NewRow();
                                                _MyRow["cfecha"] = Convert.ToString(_DgRowA.Cells[3].Value);
                                                _MyRow["ctdocuoper"] = Convert.ToString(_DgRowA.Cells[1].Value);
                                                _MyRow["cnumdocu"] = Convert.ToString(_DgRowA.Cells[0].Value);
                                                _MyRow["cconcepto"] = Convert.ToString(_DgRowA.Cells[4].Value);
                                                _MyRow["cmontomov"] = _Dbl_MontoDif.ToString().Replace(",", ".");

                                                _Dt.Rows.Add(_MyRow);
                                            }
                                        }
                                    }


                                }
                            }

                        }
                        _Str_TpoOperConvert = "";
                    }
                }

            }

            return _Dt;
        }

        private double _Mtd_CalcularTotal()
        {
            double _Dbl_Total = 0;
            foreach (DataGridViewRow _DgRow in _Dg_DetGen.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[2].Value) != "")
                {
                    _Dbl_Total = _Dbl_Total + Convert.ToDouble(_DgRow.Cells[2].Value);
                }
            }
            return _Dbl_Total;
        }
    }
}