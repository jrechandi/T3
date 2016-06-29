using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Comprobante : Form
    {
        public Frm_Comprobante()
        {
            InitializeComponent();
        }

        string[] _str_Valores = new string[2];
        string[] _Str_Necesarios = new string[2];
        string[] _Str_Campos = new string[2];
        Control[] _Ctrl_Controles = new Control[2];
        string[] _Str_Where = new string[2];
        string[] _Str_NoRep = new string[1];
        int[] _Int_CodDes = new int[2];
        string[] _Str_Deshabilitar = new string[1];
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_MyProceso = "";

        private void Frm_COMPROBANTE_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Tipo de Documento");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ctypcompro";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select ctypcompro as [Código],cname as [Tipo de Documento] from TTCOMPROBAN where 0=0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Comprobantes", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ctypcompro as [Código],cname as [Tipo de Documento] from TTCOMPROBAN");
            _Dg_Grid.DataSource = _Ds_Data.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_Sorted();
        }

        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Frm_COMPROBANTE_Activated(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Formato = "Select ctypcompro as [Código],cname as [Tipo de Documento] from TTCOMPROBAN";
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta = "Select ctypcompro,cname from TTCOMPROBAN";
            CONTROLES._Ctrl_Buscar._Str_Tabla = "TTCOMPROBAN";
            CONTROLES._Ctrl_Buscar._Str_Where_Vista_Grid = "0=0";
            //-------------------------------------------------------
            _Ctrl_Controles[0] = _Txt_Id;
            _Ctrl_Controles[1] = _Txt_Name;
            //-------------------------------------------------------
            _Str_Campos[0] = "ctypcompro";
            _Str_Campos[1] = "cname";
            //------------------------------------------------------
            _Str_Where[0] = "ctypcompro";
            _Str_Where[1] = "cname";
            //-------------------------------------------------------
            _Str_NoRep[0] = "0";
            //_Str_NoRep[1] = "1";
            //-------------------------------------------------------
            _Int_CodDes[0] = 0;
            _Int_CodDes[1] = 1;
            //-------------------------------------------------------
            _Str_Deshabilitar[0] = "0";
            //-------------------------------------------------------
            CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Str_Campos = _Str_Campos;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Where = _Str_Where;
            CONTROLES._Ctrl_Buscar._Str_Deshabilitados = _Str_Deshabilitar;
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Dg_Datagrid = _Dg_Grid;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Str_NoseDebeRepetir = _Str_NoRep;
            CONTROLES._Ctrl_Buscar._Int_Codigo_Descripcion = _Int_CodDes;
            //CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            CONTROLES._Ctrl_Buscar._Int_Foco = 0;
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_text.Text = "ctypcompro='" + _Txt_Id.Text + "'";
            }
            else
            { CONTROLES._Ctrl_Buscar._Bl_Modifi = false; }
            CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
            _Mtd_BotonesMenu();
        }

        public void _Mtd_llenar()
        {
            _str_Valores[0] = _Txt_Id.Text.ToUpper();
            _str_Valores[1] = _Txt_Name.Text.ToUpper();
            //----------------------------------------------
            _Str_Necesarios[0] = "0";
            _Str_Necesarios[1] = "1";
            //------------------------------------------------
            CONTROLES._Ctrl_Buscar._Str_Valores = _str_Valores;
            CONTROLES._Ctrl_Buscar._Str_Necesario = _Str_Necesarios;
        }

        private void Frm_COMPROBANTE_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_Id.Text = "";
            _Txt_Id.Enabled = false;
            _Txt_Name.Text = "";
            _Txt_Name.Enabled = false;
        }

        private void _Dg_Grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount > 1)
            {
                Cursor = Cursors.WaitCursor;
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_text.Text = "ctypcompro='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
                _Str_MyProceso = "";
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_BotonesMenu()
        {
            if (_Str_MyProceso == "A")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
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
                if (_Txt_Id.Text != "")
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

        private void _Txt_Name_EnabledChanged(object sender, EventArgs e)
        {
            if (_Txt_Name.Enabled == true && _Txt_Id.Text == "")//Estoy Agregando
            {
                _Str_MyProceso = "A";
                _Txt_Id.Enabled = true;
            }
            else
            {
                if (_Txt_Id.Text != "")
                { _Str_MyProceso = "M"; }
            }
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