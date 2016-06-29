using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ProcesosVista : Form
    {
        public Frm_ProcesosVista()
        {
            InitializeComponent();
        }

        public Frm_ProcesosVista(string _Pr_Str_Sql)
        {
            InitializeComponent();
            _Str_SqlAdd = _Pr_Str_Sql;
        }

        string _Str_SqlAdd = "";
        public string _Str_R = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        private void Frm_ProcesosVista_Load(object sender, EventArgs e)
        {
            _Rb_All.Checked = true; 
        }

        private void _Txt_Dato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Rb_Codigo.Checked)//COdigo
            {
                myUtilidad._Mtd_Valida_Numeros(_Txt_Dato, e, 10, 0);
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            string _Str_Sql;
            DataSet _Ds;
            object[] _Str_RowNew = new object[3];
            _Dg_A.Rows.Clear();
            _Str_Sql = "Select ccount,CASE cauxiliar WHEN '0' THEN '' ELSE cauxiliar END as cauxiliar,cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Rb_All.Checked)
            {
            }
            if (_Rb_Codigo.Checked)
            {
                _Str_Sql = _Str_Sql + " AND ccount LIKE '" + _Txt_Dato.Text.Trim() + "%'";
            }
            if (_Rb_Nombre.Checked)
            {
                _Str_Sql = _Str_Sql + " AND cname LIKE '%" + _Txt_Dato.Text.Trim() + "%'";
            }
            _Str_Sql = _Str_Sql + _Str_SqlAdd;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_A.Rows.Add(_Str_RowNew);
            }
            _Dg_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Dg_A_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value != null)
            {
                _Str_R = _Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            _Str_R = "";
            this.Hide();
        }

        private void _Dg_A_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value != null)
            {
                _Str_R = _Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value.ToString();
                _Bt_Ok.PerformClick();
            }
        }

        private void _Rb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_All.Checked)
            {
                _Txt_Dato.Visible = false;
                _Bt_Find.PerformClick();
            }
        }

        private void _Rb_Codigo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Codigo.Checked)
            {
                _Txt_Dato.Visible = true;
                _Txt_Dato.Text = "";
                _Txt_Dato.Focus();
            }
        }

        private void _Rb_Nombre_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Nombre.Checked)
            {
                _Txt_Dato.Visible = true;
                _Txt_Dato.Text = "";
                _Txt_Dato.Focus();
            }
        }
    }
}