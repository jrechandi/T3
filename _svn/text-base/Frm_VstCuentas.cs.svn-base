using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_VstCuentas : Form
    {
        public string _Str_FrmNodeSelec = "";
        bool _Bol_Cancel = false;
        public Frm_VstCuentas()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarCuentas()
        {
            bool _Bol_Sw = false;
            DataSet _Ds_Aux;
            string _Str_NodoPadre="",_Str_Nodo="",_Str_NodoName="",_Str_NodoPadreName="";
            string _Str_Sql = "SELECT * FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivate=1 ORDER BY ccount";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Tv_Main.SuspendLayout();
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                
                _Str_Nodo = _Drow["ccount"].ToString().Trim();
                _Str_NodoName = _Drow["cname"].ToString().Trim();
                if (_Str_Nodo.IndexOf(".") > -1)
                {
                    _Str_NodoPadre = _Str_Nodo.Substring(0, _Str_Nodo.LastIndexOf("."));
                    _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_NodoPadre + "'";
                    _Ds_Aux = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_Aux.Tables[0].Rows.Count>0)
                    {
                        _Str_NodoPadreName = _Ds_Aux.Tables[0].Rows[0]["cname"].ToString().Trim();
                    }
                    TreeNode[] _My_nodes = _Tv_Main.Nodes.Find(_Str_NodoPadre, true);
                    foreach (TreeNode _My_Nodo in _My_nodes)
                    {
                        _Bol_Sw = true;
                        _My_Nodo.Nodes.Add(_Str_Nodo, _Str_Nodo + ": " + _Str_NodoName);
                    }
                    if (!_Bol_Sw)
                    {//INGRESO EL NODO PADRE
                        _Tv_Main.Nodes.Add(_Str_NodoPadre,_Str_NodoPadre + ": " + _Str_NodoPadreName);

                    }
                }
                else
                {
                    _Tv_Main.Nodes.Add(_Str_Nodo, _Str_Nodo + ": " + _Str_NodoName);
                }
               
            }
            //_Tv_Main.ExpandAll();
            _Tv_Main.CollapseAll();
            _Tv_Main.ResumeLayout();
        }

        private void Frm_VstCuentas_Load(object sender, EventArgs e)
        {
            _Mtd_CargarCuentas();
            _Tv_Main.Focus();
        }

        private void _Tv_Main_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {

                _Str_FrmNodeSelec = e.Node.Name;
            }
            else
            {
                _Str_FrmNodeSelec = "";
            }
        }

        private void _Tv_Main_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!e.Node.Checked)
            {
                foreach (TreeNode _My_Nodo in _Tv_Main.Nodes)
                {
                    if (_Mtd_BloquearTreeView(_My_Nodo))
                    {
                        e.Cancel= true;
                        break;
                    }
                }
            }

        }

        private bool _Mtd_BloquearTreeView(TreeNode _Pr_Nodo)
        {
            bool _Bol_R = false;
            if (_Pr_Nodo.Checked)
            {
                _Bol_R = true;

            }
            else
            {
                foreach (TreeNode _My_Nodo in _Pr_Nodo.Nodes)
                {
                    _Bol_R = _Mtd_BloquearTreeView(_My_Nodo);
                    if (_Bol_R)
                    {
                        break;
                    }
                }
            }
            return _Bol_R;

        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            _Str_FrmNodeSelec = "";
            _Bol_Cancel = true;
            this.Close();
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            _Bol_Cancel = true;
            this.Close();
        }

        private void Frm_VstCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_Bol_Cancel)
            {
                _Str_FrmNodeSelec = "";
            }
        }

        private void _Rb_Prov_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Prov.Checked)
            {
                _Str_FrmNodeSelec = "PRV.X";
            }
        }

        private void _Rb_Banco_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Banco.Checked)
            {
                _Str_FrmNodeSelec = "BNC.X";
            }
        }
    }
}