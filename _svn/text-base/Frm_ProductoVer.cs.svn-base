using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ProductoVer : Form
    {
        public Frm_ProductoVer(string _Pr_Str_NR, string _Pr_Str_Fact, string _Pr_Str_Proveedor)
        {
            InitializeComponent();
            _Str_NR = _Pr_Str_NR;
            _Str_Fact = _Pr_Str_Fact;
            _Str_Proveedor = _Pr_Str_Proveedor;
        }

        string _Str_NR = "";
        string _Str_Fact = "";
        string _Str_Proveedor = "";
        public string _Str_R = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        private void _Rb_All_CheckedChanged(object sender, EventArgs e)
        {
            string _Str_Sql="";
            if (_Rb_All.Checked)
            {
                DataSet _Ds;
                object[] _Str_RowNew = new object[4];
                _Dg_A.Rows.Clear();
                _Str_Sql = "Select cproducto,cnamef,cempaques FROM VST_PRODUCTOS_RECEPCIONDFD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cidrecepcion=" + _Str_NR + " and cnfacturapro='" + _Str_Fact + "' AND cproveedor='" + _Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _DataR in _Ds.Tables[0].Rows)
                {
                    Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                    _Dg_A.Rows.Add(_Str_RowNew);
                }
                _Dg_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (_Dg_A.RowCount > 0)
                { 
                    _Lb_Result.Text = "Búsqueda Exitosa.";
                }
                else
                {
                    _Lb_Result.Text = "No se encontraron registros.";
                }
                _Txt_Dato.Visible = false;
                _Bt_Find.Visible = false;
            }
        }

        private void _Rb_Codigo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Codigo.Checked)
            {
                _Txt_Dato.Visible = true;
                _Bt_Find.Visible = true;
            }
        }

        private void _Rb_Nombre_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Nombre.Checked)
            {
                _Txt_Dato.Visible = true;
                _Bt_Find.Visible = true;
            }
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
            object[] _Str_RowNew = new object[4];
            _Dg_A.Rows.Clear();
            _Str_Sql = "Select cproducto,cnamef,cempaques FROM VST_PRODUCTOS_RECEPCIONDFD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and cidrecepcion=" + _Str_NR + " and cnfacturapro='" + _Str_Fact + "' AND cproveedor='" + _Str_Proveedor + "'";
            if (_Rb_All.Checked)
            {
            }
            if (_Rb_Codigo.Checked)
            {
                _Str_Sql = _Str_Sql + " AND cproducto='" + _Txt_Dato.Text.Trim() + "'";
            }
            if (_Rb_Nombre.Checked)
            {
                _Str_Sql = _Str_Sql + " AND cnamef LIKE '%" + _Txt_Dato.Text.Trim() + "%'";
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_A.Rows.Add(_Str_RowNew);
            }
            _Dg_A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_A.RowCount > 0)
            {
                _Lb_Result.Text = "Búsqueda Exitosa.";
            }
            else
            {
                _Lb_Result.Text = "No se encontraron registros.";
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

        private void _Dg_A_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value != null)
            {
                _Str_R = _Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void _Dg_A_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value != null)
            {
                _Str_R = _Dg_A[0, _Dg_A.CurrentCell.RowIndex].Value.ToString();
                _Bt_Ok.PerformClick();
            }
        }

        private void Frm_ProductoVer_Load(object sender, EventArgs e)
        {
            _Rb_All.Checked = true; 
        }


    }
}