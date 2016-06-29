using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Permisos : Form
    {
        public Frm_Permisos()
        {
            InitializeComponent();
        }

        private void Frm_Permisos_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.menu1.Name);
           // _Mtd_CargarPadres();
            llena_combo_grupo();
        }
        private void llena_combo_grupo()
        {
            string _Str_SentenciaSQL = "select * from TGROUP WHERE cdelete='0' order by cname";
            DataSet _DS_ = new DataSet();
            _DS_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            this.comboBox1.DataSource = _DS_.Tables[0].DefaultView;
            this.comboBox1.DisplayMember = "cname";
            this.comboBox1.ValueMember = "cgroup";
        }
        DataSet _G_DS_Dataset = new DataSet();
        
        private void _Mtd_CargarPadres(string grupo)
        {
            this.treeView1.Nodes.Clear();
            string _Str_SentenciaSQL = "select * from vst_menuporgrupo where grupo='" + grupo + "'";
            _G_DS_Dataset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            foreach (DataRow filas in _G_DS_Dataset.Tables[0].Rows)
            {
                if (filas["c_menuId"].ToString().Equals(filas["c_padreId"].ToString()))
                {
                    TreeNode _Tre_nodo = new TreeNode();
                    _Tre_nodo.Name = filas["c_menuId"].ToString().TrimEnd();
                    _Tre_nodo.Text = filas["c_nameMenu"].ToString().TrimEnd();
                    treeView1.Nodes.Add(_Tre_nodo);
                    _Mtd_cargarHijos(_G_DS_Dataset, _Tre_nodo);
                }
            }
        }
        private void _Mtd_cargarHijos(DataSet _P_DS_, TreeNode _Tre_NodoHijo)
        {
            foreach (DataRow filas in _P_DS_.Tables[0].Rows)
            {
                if (filas["c_padreId"].ToString().Equals(_Tre_NodoHijo.Name) && !filas["c_padreId"].ToString().ToString().Equals(filas["c_menuId"].ToString()))
                {
                    TreeNode _Tre_nodo = new TreeNode();
                    _Tre_nodo.Name = filas["c_menuId"].ToString().TrimEnd();
                    _Tre_nodo.Text = filas["c_nameMenu"].ToString().TrimEnd();
                    _Tre_NodoHijo.Nodes.Add(_Tre_nodo);
                    _Mtd_cargarHijos(_P_DS_, _Tre_nodo);
                }
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this._lbl_descripcion.Text = treeView1.SelectedNode.Text;
            //this.label2.Text = treeView1.SelectedNode.Name;
            _G_Str_codMenuId = treeView1.SelectedNode.Name;

            string _Str_SentenciaSQL = "select c_habilitado,c_favorito from vst_menuporgrupo where c_menuId='" + treeView1.SelectedNode.Name + "' and grupo='" + _G_Str_codGrupo + "'";
            DataSet _DS_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            foreach (DataRow filas in _DS_.Tables[0].Rows)
            {

                if (filas["c_habilitado"].ToString().TrimEnd() == "1")
                {
                    this.checkBox1.Checked = true;
                }
                else
                {
                    this.checkBox1.Checked = false;
                }
                if (filas["c_favorito"].ToString().TrimEnd() == "1")
                {
                    this._Chbox_Favorito.Checked = true;
                }
                else
                {
                    this._Chbox_Favorito.Checked = false;
                }
                this.panel1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarPadres(this.comboBox1.SelectedValue.ToString());
            _G_Str_codGrupo = this.comboBox1.SelectedValue.ToString();
            this.panel1.Visible = false;
        }
        string _G_Str_codGrupo;
        string _G_Str_codMenuId;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string _Str_status="0";
            if (this.checkBox1.Checked)
            {
                _Str_status = "1";
            }
            string _Str_SentenciaSQL = "update TMENUGROUP set c_habilitado='" + _Str_status + "' where c_menuId='"+_G_Str_codMenuId+"' and cgroup='"+_G_Str_codGrupo+"'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
        }

        private void _Chbox_Favorito_CheckedChanged(object sender, EventArgs e)
        {
            string _Str_SentenciaSQL = "update TMENUGROUP set c_favorito='" + Convert.ToInt32(_Chbox_Favorito.Checked).ToString() + "' where c_menuId='" + _G_Str_codMenuId + "' and cgroup='" + _G_Str_codGrupo + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
        }
    }
}