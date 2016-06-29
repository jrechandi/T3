using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_NotaRecepVer : Form
    {
        public Frm_NotaRecepVer(string _Pr_Str_Proveedor)
        {
            InitializeComponent();
            _Str_Proveedor = _Pr_Str_Proveedor;
        }

        string _Str_Proveedor="";
        string _Str_RecepId = "";
        public string _Str_R = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            string _Str_Sql;
            DataSet _Ds;
            object[] _Str_RowNew = new object[3];
            _Dg_A.Rows.Clear();
            _Str_Sql = "Select cidnotrecepc,convert(varchar, cfechanotrecep,103) as cfechanotrecep,cnumdocu FROM TNOTARECEPC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ctipodocument='FACT' AND cproveedor='" + _Str_Proveedor + "'";
            if (_Rb_Codigo.Checked)
            {
                _Str_Sql = _Str_Sql + " AND cidnotrecepc=" + _Txt_Dato.Text.Trim();
            }
            if (_Rb_Fecha.Checked)
            {
                _Str_Sql = _Str_Sql + " AND cfechanotrecep BETWEEN '" + _Dtp_Desde.Value.ToShortDateString() + "' AND '" + _Dtp_Hasta.Value.ToShortDateString() + "'";
            }
            _Str_Sql = _Str_Sql + " ORDER BY cfechanotrecep";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_A.Rows.Add(_Str_RowNew);
            }
            _Dg_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_A.RowCount == 0)
            { _Lb_Result.Text = "No se encontraron registros."; }
            else
            { _Lb_Result.Text = "Búsqueda exitosa."; }
        }

        private void _Rb_All_CheckedChanged(object sender, EventArgs e)
        {
            DataSet _Ds;
            object[] _Str_RowNew = new object[3];
            if (_Rb_All.Checked)
            {
                _Dg_A.Rows.Clear();
                //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cidrecepcion,cfechanotrecep,cnumdocu FROM TNOTARECEPC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp=" + Frm_Padre._Str_GroupComp + " ORDER BY cfechanotrecep");
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cidnotrecepc,convert(varchar, cfechanotrecep,103) as cfechanotrecep,cnumdocu FROM TNOTARECEPC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ctipodocument='FACT' AND cproveedor='" + _Str_Proveedor + "' ORDER BY cfechanotrecep");
                foreach (DataRow _DataR in _Ds.Tables[0].Rows)
                {
                    Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                    _Dg_A.Rows.Add(_Str_RowNew);
                }
                _Dg_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (_Dg_A.RowCount == 0)
                { _Lb_Result.Text = "No se encontraron registros."; }
                else
                { _Lb_Result.Text = "Búsqueda exitosa."; }
                _Txt_Dato.Visible = false;
                _Txt_Dato.Text = "";
                _Bt_Find.Visible = false; 
                panel1.Visible = false; 
            }
        }

        private void _Rb_Codigo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Codigo.Checked)
            {
                _Txt_Dato.Visible = true;
                _Txt_Dato.Text = "";
                _Bt_Find.Visible = true;
                panel1.Visible = false; 
            }
        }

        private void _Rb_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Fecha.Checked)
            {
                _Txt_Dato.Visible = false;
                _Txt_Dato.Text = "";
                _Bt_Find.Visible = true;
                panel1.Visible = true;
            }
        }

        private void _Dtp_Desde_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Hasta.MinDate = _Dtp_Desde.Value; 
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

        private void Frm_NotaRecepVer_Load(object sender, EventArgs e)
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

        private void _Dg_A_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value != null)
            {
                _Str_R = "S";
            }
        }

        private void _Dg_A_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value != null)
            {
                _Str_R = "S";
                _Bt_Ok.PerformClick();
            }
        }
    }
}