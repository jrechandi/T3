using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Tabs : Form
    {
        string _Str_MyProceso = "";
        public Frm_Tabs()
        {
            InitializeComponent();
        }

        private void Frm_Tabs_Load(object sender, EventArgs e)
        {
            llena_combo_grupo();
            //comboBox1.SelectedIndex = 0;
        }
        private void llena_combo_grupo()
        {
            string _Str_SentenciaSQL = "select cgroup,cname from TGROUP WHERE cdelete='0' order by cname";
            _ClsMetodos._Mtd_CargarCombo(comboBox1, _Str_SentenciaSQL);
            //DataSet _DS_ = new DataSet();
            //_DS_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            //this.comboBox1.DataSource = _DS_.Tables[0].DefaultView;
            //this.comboBox1.DisplayMember = "cname";
            //this.comboBox1.ValueMember = "cgroup";
        }
        private void Cargar_lista()
        {
            string _Str_Sql = "", _Str_User="";
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _lis_2.DataSource = null;
            if (comboBox1.SelectedIndex > -1)
            {
                _Str_User = comboBox1.SelectedValue.ToString();
            }
            else
            {
 
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctabs,ctabs_descrip from VST_TTABS where cgroup='" + _Str_User + "'");
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _lis_2.DataSource = _myArrayList;
                _lis_2.DisplayMember = "Display";
                _lis_2.ValueMember = "Value";
            }
            _lis_1.DataSource = null;
            _Str_Sql = "select ctabs,(convert(varchar,ctabs) + ' - ' + cname) as ctabs_descrip from TTAB where not EXISTS (select ctabs from VST_TTABS where cgroup='" + _Str_User + "' AND VST_TTABS.ctabs=TTAB.ctabs)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _ClsMetodos._Mtd_CargarLista(_lis_1, _Str_Sql);


            //_lis_1.Items.Clear();
            //_lis_2.Items.Clear();
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctabs from TTABS where cgroup='" + comboBox1.SelectedValue.ToString() + "'");
            //foreach (DataRow _Row in _Ds.Tables[0].Rows)
            //{
            //    _lis_2.Items.Add(_Row[0].ToString());
            //}
            //for (int _Int_i = 0; _Int_i <= 55; _Int_i++)
            //{
            //    bool _Bl_Sw = false;
            //    foreach (object _Ob in _lis_2.Items)
            //    {
            //        if (_Ob.ToString() == _Int_i.ToString())
            //        {
            //            _Bl_Sw = true;
            //        }
            //    }
            //    if (!_Bl_Sw)
            //    {
            //        _lis_1.Items.Add(_Int_i.ToString());
            //    }
            //}
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void _Bt_Add_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (comboBox1.SelectedIndex < 1)
            {
                _Er_Error.SetError(comboBox1, "Información requerida!!!");
            }
            else
            {
                _Str_Sql = "INSERT INTO TTABS (cgroup,ctabs) VALUES('" + comboBox1.SelectedValue.ToString() + "','" + _lis_1.SelectedValue.ToString() + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("Delete from TTABS where cgroup='"+comboBox1.SelectedValue.ToString()+"'");
                //_lis_2.Items.Add(_lis_1.SelectedItem);
                //_lis_1.Items.Remove(_lis_1.SelectedItem);
                //foreach(object _Ob in _lis_2.Items)
                //{
                //    Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TTABS", "cgroup,ctabs", "'" + comboBox1.SelectedValue.ToString() + "','" + _Ob.ToString() + "'");
                //}
                Cargar_lista();
            }
        }

        private void _Bt_Rem_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex < 1)
            {
                _Er_Error.SetError(comboBox1, "Información requerida!!!");
            }
            else
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("Delete from TTABS where cgroup='" + comboBox1.SelectedValue.ToString() + "' AND ctabs='" + _lis_2.SelectedValue.ToString() + "'");
                //_lis_1.Items.Add(_lis_2.SelectedItem);
                //_lis_2.Items.Remove(_lis_2.SelectedItem);
                //foreach (object _Ob in _lis_2.Items)
                //{
                //    Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TTABS", "cgroup,ctabs", "'" + comboBox1.SelectedValue.ToString() + "','" + _Ob.ToString() + "'");
                //}
                Cargar_lista();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (comboBox1.SelectedIndex!=-1)
            {
                Cargar_lista();
            }
        }

        private void _Bt_TabNuevo_Click(object sender, EventArgs e)
        {
            _Pnl_TabDatos.Parent = this;
            _Txt_TabId.Text = "";
            _Txt_TabName.Text = "";
            _Chk_CodManual.Checked = false;
            _Pnl_TabDatos.Visible = true;
            _Txt_TabName.Focus();
            _Str_MyProceso = "A";
        }
        CLASES._Cls_Varios_Metodos _ClsMetodos = new T3.CLASES._Cls_Varios_Metodos(true);
        private void _Bt_TabSave_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (_Txt_TabName.Text.Trim().Length > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                if (_Str_MyProceso == "A")
                {
                    _Str_Sql = "SELECT MAX(ctabs) FROM TTAB";
                    if (!_Chk_CodManual.Checked)
                    {
                        _Txt_TabId.Text = _ClsMetodos._Mtd_Correlativo(_Str_Sql);
                        if (_Txt_TabId.Text == "1")
                        {
                            if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TTAB where ctabs='0'"))
                            {
                                _Txt_TabId.Text = "0";
                            }
                        }
                    }
                    if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TTAB where ctabs='" + _Txt_TabId.Text + "'"))
                    {
                        _Str_Sql = "INSERT INTO TTAB (ctabs,cname) VALUES('" + _Txt_TabId.Text + "','" + _Txt_TabName.Text.Trim().ToUpper() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        MessageBox.Show("Tab agregado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_TabDatos.Visible = false;
                        Cargar_lista();
                        if (_lis_1.Items.Count > 0)
                        {
                            _lis_1.SetSelected(_lis_1.Items.Count - 1, true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código ya esta en uso, ingrese otro por favor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (_Str_MyProceso == "M")
                {
                    _Str_Sql = "UPDATE TTAB SET cname='" + _Txt_TabName.Text.Trim().ToUpper() + "' WHERE ctabs='" + _Txt_TabId.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Pnl_TabDatos.Visible = false;
                    Cargar_lista();
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Ingrese la descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void _Bt_TabCancel_Click(object sender, EventArgs e)
        {
            _Pnl_TabDatos.Visible = false;
            _Str_MyProceso = "";
        }

        private void _Bt_TabDel_Click(object sender, EventArgs e)
        {
            if (_lis_1.SelectedIndex > 0)
            {
                string _Str_Sql = "DELETE FROM TTAB WHERE ctabs='" + _lis_1.SelectedValue.ToString() + "'";
                if (MessageBox.Show("Esta seguro de eliminar el Tab " + ((Clases._Cls_ArrayList)_lis_1.SelectedItem).Display + "?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    Cargar_lista();
                }
            }
        }

        private void _Chk_CodManual_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_CodManual.Checked)
            {
                _Txt_TabId.ReadOnly = false;
                _Txt_TabId.Focus();
            }
            else
            {
                _Txt_TabId.Text = "";
                _Txt_TabId.ReadOnly = true;
                _Txt_TabName.Focus();
            }
        }

        private void _Pnl_TabDatos_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_TabDatos.Visible)
            {
                panel4.Enabled = false;
                panel3.Enabled = false;
            }
            else
            {
                panel4.Enabled = true;
                panel3.Enabled = true;
            }
        }

        private void _Bt_Edit_Click(object sender, EventArgs e)
        {
            if (_lis_1.SelectedIndex > -1)
            {
                string _Str_Sql = "SELECT cname FROM TTAB WHERE ctabs='" + _lis_1.SelectedValue.ToString() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Txt_TabId.Text = _lis_1.SelectedValue.ToString();
                _Txt_TabName.Text = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Chk_CodManual.Enabled = false;
                _Pnl_TabDatos.Visible = true;
                _Str_MyProceso = "M";
            }
        } 
    }
}