using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Constantes : Form
    {
        public Frm_Constantes()
        {
            InitializeComponent();
        }

        string _Str_FindSql = "";
        string _Str_MyProceso = "";
        Control[] _Ctrl_Controles = new Control[3];
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
        string[] _Str_FindCampos = new string[2];

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_cconst_id.Enabled = _Pr_Bol_A;
            _Txt_cnombre.Enabled = _Pr_Bol_A;
            _Txt_valor.Enabled = _Pr_Bol_A;
        }

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_cconst_id.Text = "";
            _Txt_cnombre.Text = "";
            _Txt_valor.Text = "";
            _Mtd_Sorted(_Dg_Grid);
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid, true, "");
            _Mtd_Bloquear(false);
        }

        private void _Mtd_Sorted(DataGridView _Pr_Dg)
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Pr_Dg.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Mtd_BotonesMenu()
        {
            if (_Str_MyProceso == "A")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NF,MF,GT,EF,AF,CT"; 
            }
            if (_Str_MyProceso == "M")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GT,EF,AF,CT"; 
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_cconst_id.Text != "")
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MT,GF,ET,AT,CT"; 
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GF,EF,AT,CT"; 
                }
            }
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT * FROM TCONST WHERE cidentif='" + _Pr_Str_Id + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_cconst_id.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidentif"]);
                _Txt_cnombre.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cconst_name"]);
                _Txt_valor.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cconst_valor"]);
            }
        }

        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0;
        }

        public void _Mtd_Habilitar()
        {
            _Str_MyProceso = "M";
            _Mtd_Bloquear(true);
            _Mtd_BotonesMenu();
            _Tb_Tab.SelectedIndex = 1;

        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Str_MyProceso = "A";
            _Mtd_BotonesMenu();
            _Txt_cconst_id.Focus();
            _Tb_Tab.SelectedIndex = 1;
        }

        public bool _Mtd_Eliminar()
        {
            string _Str_Sql = "";
            bool _Bol_R = false;
            if (MessageBox.Show("Está seguro de Elminar esta Constante?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TCONST SET cdelete=1,cuserdel='" + Frm_Padre._Str_Use + "',cdatedel=GETDATE() WHERE cidentif='" + _Txt_cconst_id.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_Ini();
                _Tb_Tab.SelectedIndex = 0;
                _Mtd_BotonesMenu();
                _Bol_R = true;
            }
            return _Bol_R;
        }

        public bool _Mtd_Guardar()
        {
            bool _Bol_Val = false;
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Str_MyProceso == "A")
            {
                if (_Txt_cconst_id.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_cconst_id, "Ingrese el Identificador.");
                    _Bol_Val = true;
                }
                if (_Txt_cnombre.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_cnombre, "Ingrese el Nombre de la Constante.");
                    _Bol_Val = true;
                }
                if (_Txt_valor.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_valor, "Ingrese el Valor.");
                    _Bol_Val = true;
                }

                if (!_Bol_Val)
                {
                    try
                    {
                        _Str_Sql = "INSERT INTO TCONST (cidentif,cconst_valor,cconst_name,cinactivo,cactivo) VALUES('";
                        _Str_Sql = _Str_Sql + _Txt_cconst_id.Text + "','" + _Txt_valor.Text.Replace(".", "").Replace(",", ".") + "','" + _Txt_cnombre.Text.Trim().ToUpper() + "',0,1)";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_MyProceso = "";
                        _Mtd_Bloquear(false);
                        _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid);
                        _Mtd_BotonesMenu();
                        MessageBox.Show("Transacción guardada correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = false;
                    }
                    catch
                    { MessageBox.Show("Problemas al Guardar la Transacción.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning); _Bol_R = false; }
                }
            }

            return _Bol_R;
        }

        public bool _Mtd_Editar()
        {
            bool _Bol_Val = false;
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Str_MyProceso == "M")
            {
                
                if (_Txt_cnombre.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_cnombre, "Ingrese el Nombre de la Constante.");
                    _Bol_Val = true;
                }
                if (_Txt_valor.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_valor, "Ingrese el Valor.");
                    _Bol_Val = true;
                }

                if (!_Bol_Val)
                {
                    try
                    {
                        _Str_Sql = "UPDATE TCONST SET cconst_valor='" + _Txt_valor.Text.Replace(".", "").Replace(",", ".") + "',cconst_name='" + _Txt_cnombre.Text.Trim().ToUpper() + "'";
                        _Str_Sql = _Str_Sql + " WHERE cidentif='" + _Txt_cconst_id.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_MyProceso = "";
                        _Mtd_Bloquear(false);
                        _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid);
                        _Mtd_BotonesMenu();
                        MessageBox.Show("Transacción guardada correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = false;//DEBERIA SER TRUE PERO EN EL CONTROL ME CAMBIA LA CONFIG DE LAQ BOTONERA
                    }
                    catch
                    { MessageBox.Show("Problemas al Guardar la Transacción.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning); _Bol_R = false; }
                }
            }
            return _Bol_R;
        }

        private void Frm_Constantes_Load(object sender, EventArgs e)
        {
            _Tsm_Menu[0] = new ToolStripMenuItem("Identificador");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Str_FindCampos[0] = "cidentif";
            _Str_FindCampos[1] = "cconst_name";
            _Str_FindSql = "Select cidentif as [Identificador],cconst_name as [Constante],cconst_valor as [Valor] from TCONST where cactivo=1 and cinactivo=0";
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0; 
        }

        private void Frm_Constantes_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            //-------------------------------------------------------
            _Ctrl_Controles[0] = _Txt_cconst_id;
            _Ctrl_Controles[1] = _Txt_cnombre;
            _Ctrl_Controles[2] = _Txt_valor;
            // CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "";
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_Str_MyProceso == "A")
                { _Txt_cconst_id.Focus(); }
            }
            CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
            _Mtd_BotonesMenu();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount >= 0)
            {
                _Str_MyProceso = "";
                _Mtd_Ini();
                _Mtd_CargarData(Convert.ToString(_Dg_Grid[0, e.RowIndex].Value));
                _Mtd_BotonesMenu();
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void Frm_Constantes_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Txt_cnombre_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_cnombre, "");
        }

        private void _Txt_valor_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_valor, "");
        }
    }
}