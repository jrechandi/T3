using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_VerComprobante : Form
    {
        public Frm_VerComprobante()
        {
            InitializeComponent();
        }

        public Frm_VerComprobante(string _Pr_Str_ComprobId)
        {
            InitializeComponent();
            _Str_FrmComprobId = _Pr_Str_ComprobId;
            this.Text = "Comprobante Nº " + _Str_FrmComprobId;
        }

        string _Str_FrmComprobId = "";

        private void Frm_VerComprobante_Load(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (_Str_FrmComprobId != "")
            {
                //CARGO LOS DEBES
                _Str_Sql = "SELECT * FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_FrmComprobId + "' and (ctothaber IS NULL or ctothaber=0) AND (ctotdebe<>0)";
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                    _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctotdebe"]).ToString("#,##0.00");
                }
                //CARGO el haber
                _Str_Sql = "SELECT * FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_FrmComprobId + "' and (ctotdebe IS NULL or ctotdebe=0) AND (ctothaber<>0)";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                    _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctothaber"]).ToString("#,##0.00");
                }
            }
            _Mtd_Sorted(_Dg_Comprobante);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Frm_VerComprobante_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_VerComprobante_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}