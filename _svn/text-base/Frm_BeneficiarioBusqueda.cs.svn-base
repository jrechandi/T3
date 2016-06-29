using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_BeneficiarioBusqueda : Form
    {
        MaskedTextBox _Txt_Textbox1;
        TextBox _Txt_Textbox2;
        int _Int_I = 0;
        RadioButton _Rbt_Rif_;
        RadioButton _Rbt_Cedula_;
        bool _Bol_TodosBeneficiarios=false;
        public Frm_BeneficiarioBusqueda()
        {
            InitializeComponent();
        }
        public Frm_BeneficiarioBusqueda(MaskedTextBox _P_Txt_Texbox1,TextBox _P_Txt_Texbox2)
        {
            InitializeComponent();
            _Txt_Textbox1 = _P_Txt_Texbox1;
            _Txt_Textbox2 = _P_Txt_Texbox2;
            _Int_I = 1;
        }
         public Frm_BeneficiarioBusqueda(MaskedTextBox _P_Txt_Texbox1,TextBox _P_Txt_Texbox2,RadioButton _Rbt_Rif, RadioButton _Rbt_Cedula, bool _Bol_MostrarTodos)
        {
            InitializeComponent();
            _Txt_Textbox1 = _P_Txt_Texbox1;
            _Txt_Textbox2 = _P_Txt_Texbox2;
            _Rbt_Rif_ = _Rbt_Rif;
            _Rbt_Cedula_ = _Rbt_Cedula;
            _Bol_TodosBeneficiarios = _Bol_MostrarTodos;
            _Int_I = 2;
            if (_Bol_TodosBeneficiarios)
            {
                _Int_I = 3;
            }            
        }
        private void Frm_BeneficiarioBusqueda_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            if (!_Bol_TodosBeneficiarios)
            {
                _Tsm_Menu[0] = new ToolStripMenuItem("Nombre");
                _Tsm_Menu[1] = new ToolStripMenuItem("Apellido");
            }
            else
            {
                _Tsm_Menu[0] = new ToolStripMenuItem("Rif");
                _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            }
            string[] _Str_Campos = new string[2];
            if (!_Bol_TodosBeneficiarios)
            {
                _Str_Campos[0] = "cnombre";
                _Str_Campos[1] = "capellido";
            }
            else
            {
                _Str_Campos[0] = "Rif";
                _Str_Campos[1] = "Descripción";
            }
            string _Str_Cadena = "SELECT cbeneficiario AS Código,crif as Rif,cnombre as Nombres,capellido as Apellidos,cdescripcion as Tipo,ctipobeneficiarioid from VST_T3_BENEFICIARIOS where 0=0";
            if (_Bol_TodosBeneficiarios)
            {
                _Str_Cadena = "select Rif,Descripción from VST_T3_BENEFICIARIOSORDENPAGO WHERE (CCOMPANY ='SINCOMP' OR CCOMPANY='" + Frm_Padre._Str_Comp + "')";
                //"ORDER BY  ";
            }
            if (_Bol_TodosBeneficiarios)
            {
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Beneficiarios", _Tsm_Menu, _Dg_Grid, true, "", "Descripción");
            }
            else
            {
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Beneficiarios", _Tsm_Menu, _Dg_Grid, true, "");
            }
            //___________________________________
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT cbeneficiario AS Código,crif as Rif,cnombre as Nombres,capellido as Apellidos,cdescripcion as Tipo,ctipobeneficiarioid from VST_T3_BENEFICIARIOS where CDELETE=0";
            if (_Bol_TodosBeneficiarios)
            {
                _Str_Cadena = "select Rif,Descripción from VST_T3_BENEFICIARIOSORDENPAGO WHERE (CCOMPANY ='SINCOMP' OR CCOMPANY='" + Frm_Padre._Str_Comp + "')  ORDER BY Descripción";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            if (!_Bol_TodosBeneficiarios)
            {
                _Dg_Grid.Columns[5].Visible = false;
            }
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Int_I == 1)
            {
                _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) + " " + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
            }
            else if (_Int_I == 2)
            {
                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex).Split('-').Count() > 2)
                {
                    _Rbt_Rif_.Checked = true;
                }
                else
                {
                    _Rbt_Cedula_.Checked = true;
                }
                _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex) + " " + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
            }
            else
            {
                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex).Split('-').Count() > 2)
                {
                    _Rbt_Rif_.Checked = true;
                }
                else
                {
                    _Rbt_Cedula_.Checked = true;
                }
                _Txt_Textbox1.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                _Txt_Textbox2.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
            }
            this.Close();
        }
    }
}
