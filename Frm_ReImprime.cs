using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace T3
{
    public partial class Frm_ReImprime : Form
    {
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _G_Str_TpoDoc = "";
        string[] _G_Str_Documentos;
        public Frm_ReImprime(string _Pr_Str_TpoDoc, string[] _Pr_Str_Documentos, string _Pr_Str_Titulo)
        {
            InitializeComponent();
            _G_Str_TpoDoc = _Pr_Str_TpoDoc;
            _G_Str_Documentos = _Pr_Str_Documentos;
            DataTable _Dta_Tabla = _Mtd_CargarDT();
            foreach (string _Str_Numero in _Pr_Str_Documentos)
            {
                object[] _Obj_Fila = new object[3];
                _Obj_Fila[0]=_Pr_Str_TpoDoc;
                _Obj_Fila[1]=_Str_Numero;
                _Obj_Fila[2] = 0;
                _Dta_Tabla.Rows.Add(_Obj_Fila);
            }
            _Dta_Tabla.AcceptChanges(); 
            _Dta_Tabla.DefaultView.Sort = "Documento";
            _Dg_Grid.DataSource = _Dta_Tabla.DefaultView;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_NumDoc.Text = _Dg_Grid["Documento", 0].Value.ToString();
            this.Text = _Pr_Str_Titulo;
        }

        private DataTable _Mtd_CargarDT()
        {
            DataTable _Dta_Tabla = new DataTable();
            DataColumn _Dta_Columna;
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "Tipo";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "Documento";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Byte");
            _Dta_Columna.ColumnName = "Imprimir";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            return _Dta_Tabla;
        }

        private void _Bt_DesdeNumDoc_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bool _Bol_Sw = false;
            if (_Txt_NumDoc.Text.Trim().Length > 0)
            {
                foreach (string _Str_Doc in _G_Str_Documentos)
                {
                    if (_Str_Doc == _Txt_NumDoc.Text)
                    {
                        _Bol_Sw = true;
                    }
                }
            }
            if (_Bol_Sw)
            {
                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                {
                    if (Convert.ToInt64(_DgRow.Cells["Documento"].Value) >= Convert.ToInt64(_Txt_NumDoc.Text))
                    {
                        _DgRow.Cells["Imprimir"].Value = 1;
                    }
                    else
                    {
                        _DgRow.Cells["Imprimir"].Value = 0;
                    }
                }
                _Dg_Grid.Refresh();
            }
            else
            {
                MessageBox.Show("Número de documento no válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = Cursors.Default;
        }
        public string[] _Str_Facturas_R = new string[0];
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.Rows.Cast<DataGridViewRow>().Any(x =>  Convert.ToString(x.Cells["Imprimir"].Value) == "1"))
            {
                _Str_Facturas_R = new string[0];
                foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells["Imprimir"].Value) == "1")
                    {
                        _Str_Facturas_R = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Facturas_R, _Str_Facturas_R.Length + 1);
                        _Str_Facturas_R[_Str_Facturas_R.Length - 1] = _DgRow.Cells["Documento"].Value.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos una factura", "Requerimiento", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                DialogResult = DialogResult.None;
            }
        }

        private void _Txt_NumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            _MyUtilidad._Mtd_Valida_Numeros(_Txt_NumDoc, e, 10, 0);
        }

        private void _Bt_SelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
            {
                _DgRow.Cells["Imprimir"].Value = 1;
            }
        }

       
    }
}