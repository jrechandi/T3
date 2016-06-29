using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Formulas : Form
    {
        public Frm_Formulas()
        {
            InitializeComponent();
        }

        string _Str_FindSql = "";
        string _Str_Del="";
        string _Str_MyProceso = "";
        Control[] _Ctrl_Controles = new Control[4];
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
        string[] _Str_FindCampos = new string[1];
        string[] _Str_FrmCosntId = new string[0];

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_cidproceso.Enabled = false;
            _Txt_cdescripcion.Enabled = _Pr_Bol_A;
            _Txt_formula.Enabled = _Pr_Bol_A;
            _Lst_Const.Enabled = _Pr_Bol_A;
            _Lst_Variables.Enabled = _Pr_Bol_A;
            _Txt_Alic.Enabled = _Pr_Bol_A;
            _Bt_AddConst.Enabled = _Pr_Bol_A;
            _Lst_ISLRconst.Enabled = _Pr_Bol_A;
            _Lst_ISLRVar.Enabled = _Pr_Bol_A;
        }

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Mtd_BotonesMenu();
            _Txt_cidproceso.Text = "";
            _Txt_cdescripcion.Text = "";
            _Txt_formula.Text = "";
            _Txt_Alic.Text = "";
            _Bt_AddConst.Visible = false;
            _Lst_ISLRVar.DataSource = null;
            _Lst_ISLRconst.DataSource = null;
            _Lst_Const.DataSource = null;
            _Lst_Variables.Items.Clear();
            _Mtd_Sorted(_Dg_Grid);
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid, true, "");
            _Mtd_Bloquear(false);
        }

        private void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "";

            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            
            /*if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true; 
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_cidproceso.Text != "")
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }*/
        }


        private void _Mtd_Sorted(DataGridView _Pr_Dg)
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Pr_Dg.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT * FROM TFORMULAS WHERE cformula_id='" + _Pr_Str_Id + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_cidproceso.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cformula_id"]);
                _Txt_cdescripcion.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cformula_name"]);
                _Txt_formula.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cformula"]);
                _Txt_Alic.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["calicuota"]);
                //_Txt_formula.AccessibleDescription = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cformula_crypt"]);
                //CARGO LA LISTA DE VARIABLES
                _Mtd_CagarVariables(_Pr_Str_Id);
                //CARGO LAS CONSTANTES
                _Mtd_CargarConstantes();
                _Mtd_CargarISLRconst();
                _Mtd_CargarISLRvar();
            }
        }

        private void _Mtd_CagarVariables(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Lst_Variables.Items.Clear();
            _Str_Sql = "SELECT * FROM TFORMULASVAR WHERE cformula_id='" + _Pr_Str_Id + "' order by cvar_id";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds_A.Tables[0].Rows)
            {
                _Lst_Variables.Items.Add(_Drow["cvar_id"].ToString());
            }
        }

        private void _Mtd_CargarConstantes()
        {
            string _Str_Sql = "";
            _Lst_Const.SelectedIndexChanged -= new System.EventHandler(_Lst_Const_SelectedIndexChanged);
            
            _Str_Sql = "SELECT cidentif,(cconst_name + ': ' + CONVERT(VARCHAR,cconst_valor)) AS const_descrip FROM TCONST WHERE cactivo=1 and cinactivo=0 order by cconst_name";
            myUtilidad._Mtd_CargarLista(_Lst_Const, _Str_Sql);
            _Lst_Const.SelectedIndex = -1;
            _Lst_Const.SelectedIndexChanged += new System.EventHandler(_Lst_Const_SelectedIndexChanged);

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
            _Mtd_CargarISLRconst();
            _Mtd_CargarISLRvar();
            _Tb_Tab.SelectedIndex = 1;
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectTab(1);
            _Mtd_CargarConstantes();
            _Mtd_CargarISLRconst();
            _Mtd_CargarISLRvar();
            _Str_MyProceso = "A";
        }

        public bool _Mtd_Eliminar()
        {
            string _Str_Sql = "";
            bool _Bol_R = false;
            if (MessageBox.Show("Está seguro de Elminar esta Fórmula?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TFORMULAS SET cinactivo=1,cactivo=0 WHERE cformula_id='" + _Txt_cidproceso.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_Ini();
                _Tb_Tab.SelectedIndex = 0;
                //_Mtd_BotonesMenu();
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid, true, "");
                _Bol_R = true;
            }
            
            return _Bol_R;
        }

        public bool _Mtd_Guardar()
        {
            bool _Bol_Val = false;
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_Id = "";
            string _Str_Alic = "";
            int _Int_Pos = 0;
            if (_Str_MyProceso == "A")
            {
                if (_Txt_cdescripcion.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_cdescripcion, "Ingrese la Descripción.");
                    _Bol_Val = true;
                }
                if (_Txt_formula.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_formula, "Ingrese la Fórmula.");
                    _Bol_Val = true;
                }

                if (!_Bol_Val)
                {
                    try
                    {

                        if (_Txt_Alic.Text.Trim() != "")
                        {
                            _Str_Alic = _Txt_Alic.Text.Trim().Replace(",", ".");
                        }
                        else
                        { _Str_Alic = "0"; }
                        //char[] delimiterChars = { ',' };
                        //string[] words = _LstChk_Constantes.AccessibleDescription.Split(delimiterChars); //CAPTURA LOS CODIGOS DE LAS CONSTANTES

                        _Str_Sql = "Select Max(cformula_id) FROM TFORMULAS";
                        _Str_Id = myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Str_Sql = "INSERT INTO TFORMULAS (cformula_id,cformula,cformula_name,cactivo,calicuota) VALUES(";
                        _Str_Sql = _Str_Sql + _Str_Id + ",'" + _Txt_formula.Text.Trim() + "','" + _Txt_cdescripcion.Text.Trim() + "',1," + _Str_Alic + ")";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        //GUARDO VARIABLES
                        for (int i=0;i<_Lst_Variables.Items.Count;i++)
                        {
                            _Str_Sql = "INSERT INTO TFORMULASVAR (cformula_id,cvar_id) VALUES(";
                            _Str_Sql = _Str_Sql + _Str_Id + ",'" + _Lst_Variables.Items[i].ToString() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                        //GUARDO LAS CONSTANTES
                        //for (int i = 0; i < _LstChk_Constantes.Items.Count; i++)
                        //{
                        //    if (_LstChk_Constantes.GetItemChecked(i))
                        //    {
                        //        _Int_Pos = _LstChk_Constantes.Items[i].ToString().IndexOf(":");
                        //        _Str_Sql = "INSERT INTO TFORMULASCONST (cformula_id,cconst_id) VALUES(" + _Str_Id + ",'" + words[i] + "')";
                        //        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        //    }
                        //}
                        _Txt_cidproceso.Text = _Str_Id;
                        _Str_MyProceso = "";
                        _Mtd_Bloquear(false);
                        _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid, true, "");
                        _Mtd_BotonesMenu();
                        MessageBox.Show("Transacción guardada correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = false;
                    }
                    catch
                    { _Bol_R = false; }
                }
            }

            return _Bol_R;
        }

        public bool _Mtd_Editar()
        {
            bool _Bol_Val = false;
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_Alic = "";
            int _Int_Pos = 0;
            if (_Str_MyProceso == "M")
            {
                if (_Txt_cdescripcion.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_cdescripcion, "Ingrese la Descripción.");
                    _Bol_Val = true;
                }
                if (_Txt_formula.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_formula, "Ingrese la Fórmula.");
                    _Bol_Val = true;
                }

                if (!_Bol_Val)
                {
                    try
                    {
                        if (_Txt_Alic.Text.Trim() != "")
                        {
                            _Str_Alic = _Txt_Alic.Text.Trim().Replace(",", ".");
                        }
                        else
                        { _Str_Alic = "0"; }
                        _Str_Sql = "UPDATE TFORMULAS SET cformula='" + _Txt_formula.Text + "',cformula_name='" + _Txt_cdescripcion.Text + "',calicuota='" + _Str_Alic + "'";
                        _Str_Sql = _Str_Sql + " WHERE cformula_id='" + _Txt_cidproceso.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        char[] delimiterChars = { ',' };
                        //string[] words1 = _LstChk_Constantes.AccessibleDescription.Split(delimiterChars);
                        //ELIMINO LAS VARIABLES
                        if (_Str_Del.Length > 0)
                        {
                            _Str_Del.Substring(0, _Str_Del.Length - 1);
                            string[] words = _Str_Del.Split(delimiterChars);
                            foreach (string _Str_A in words)
                            {
                                _Str_Sql = "DELETE FROM TFORMULASVAR WHERE cformula_id='" + _Txt_cidproceso.Text + "' AND cvar_id='" + _Str_A + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                        }
                        //GUARDO VARIABLES
                        for (int i = 0; i < _Lst_Variables.Items.Count; i++)
                        {
                            _Str_Sql = "INSERT INTO TFORMULASVAR (cformula_id,cvar_id) VALUES('";
                            _Str_Sql = _Str_Sql + _Txt_cidproceso.Text.Trim() + "','" + _Lst_Variables.Items[i].ToString() + "')";
                            try
                            { Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql); }
                            catch { }
                        }
                        //GUARDO LAS CONSTANTES
                        //for (int i = 0; i < _LstChk_Constantes.Items.Count; i++)
                        //{
                        //    if (_LstChk_Constantes.GetItemChecked(i))
                        //    {

                        //        _Str_Sql = "INSERT INTO TFORMULASCONST (cformula_id,cconst_id) VALUES('" + _Txt_cidproceso.Text + "','" + words1[i] + "')";
                        //        try
                        //        { Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql); }
                        //        catch { }
                        //    }
                        //    else
                        //    {
                        //        _Str_Sql = "DELETE FROM TFORMULASCONST WHERE cformula_id='" + _Txt_cidproceso.Text + "' AND cconst_id='" + words1[i] + "'";
                        //        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        //    }
                        //}
                        _Str_MyProceso = "";
                        _Mtd_Bloquear(false);
                        _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid, true, "");
                        _Mtd_BotonesMenu();
                        MessageBox.Show("Transacción guardada correctamente.","Importante",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        _Bol_R = false;//DEBERIA SER TRUE PERO EN EL CONTROL ME CAMBIA LA CONFIG DE LAQ BOTONERA
                    }
                    catch
                    { _Bol_R = false; }
                }
            }
            return _Bol_R;
        }

        private void Frm_Formulas_Load(object sender, EventArgs e)
        {
            //ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            //string[] _Str_Campos = new string[1];
            _Str_FindCampos[0] = "cformula_id";
            _Str_FindSql = "Select cformula_id as [Cód.],cformula_name AS [Identificador],cformula as [Fórmula] from TFORMULAS where cactivo=1 and cinactivo=0";
            //string _Str_Cadena = "Select cformula_id as [Código],cformula as [Fórmula] from TFORMULAS where cdelete=0";
            //_Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Fórmulas", _Tsm_Menu, _Dg_Grid);
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0; 
        }

        private void _Mtd_Actualizar()
        {
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_FindCampos, "Fórmulas", _Tsm_Menu, _Dg_Grid, true, ""); 
        }

        private void Frm_Formulas_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            //-------------------------------------------------------
            _Ctrl_Controles[0] = _Txt_cidproceso;
            _Ctrl_Controles[1] = _Txt_cdescripcion;
            _Ctrl_Controles[2] = _Txt_formula;
            _Ctrl_Controles[3] = _Txt_Alic;
           // CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            _Mtd_BotonesMenu();
            CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount >= 0)
            {
                Cursor = Cursors.WaitCursor;
                _Str_MyProceso = "";
                _Mtd_Ini();
                _Str_MyProceso = "C";
                _Mtd_BotonesMenu();
                _Mtd_CargarData(Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void Frm_Formulas_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

 
        private void _Txt_cdescripcion_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_cdescripcion, "");
        }

        private void _Txt_formula_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_formula, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Constantes _Frm = new Frm_Constantes();
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
        }

        private void _Mtd_CargarISLRconst()
        {
            string _Str_Sql = "SELECT * FROM TUNITRIBUT WHERE cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Lst_ISLRconst.DataSource=null;

                System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cunitrib"]).Trim() != "" && Convert.ToString(_Ds.Tables[0].Rows[0]["cvalor"]).Trim() != "")
                {
                    if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["cvalor"]) != 0)
                    {
                        _myArrayList.Add(new T3.Clases._Cls_ArrayList("Unidad Tributaria: " + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cvalor"]).ToString("#,##0.00"), Convert.ToString(_Ds.Tables[0].Rows[0]["cunitrib"]).Trim()));
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]).Trim()!="")
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList("Sustraendo A: " + Convert.ToDouble(_Ds.Tables[0].Rows[0]["csustraendoa"]).ToString("#,##0.00"), "A"));
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]).Trim() != "")
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList("Sustraendo B: " + Convert.ToDouble(_Ds.Tables[0].Rows[0]["csustraendob"]).ToString("#,##0.00"), "B"));
                }
                _Lst_ISLRconst.DataSource = _myArrayList;
                _Lst_ISLRconst.DisplayMember = "Display";
                _Lst_ISLRconst.ValueMember = "Value";
                _Lst_ISLRconst.SelectedIndex = -1;
            }
        }

        private void _Mtd_CargarISLRvar()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Lst_ISLRVar.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Ingreso Bruto(IB)", "IB"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Ingreso Neto(IN)", "IN"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Base Imponible(BI)", "BI"));
            _Lst_ISLRVar.DataSource = _myArrayList;
            _Lst_ISLRVar.DisplayMember = "Display";
            _Lst_ISLRVar.ValueMember = "Value";
            _Lst_ISLRVar.SelectedIndex = -1;
        }

        private void _Lst_Const_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }
    }
}