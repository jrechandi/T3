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
    public partial class Frm_GuiaSada : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        string _Str_Comp = "";
        string _Str_Guia = "";
        int _Int_TipoGuiaSada = 0;
        public Frm_GuiaSada(string _P_Str_Comp, string _P_Str_Guia,int _P_Int_TipoGuiaSada)
        {
            InitializeComponent();
            _Str_Comp = _P_Str_Comp;
            _Str_Guia = _P_Str_Guia;
            _Int_TipoGuiaSada = _P_Int_TipoGuiaSada;
            this.Text = _Mtd_TipoGuiaSADA(_P_Int_TipoGuiaSada);
            _Lbl_CompSada.Text = CLASES._Cls_Varios_Metodos._Mtd_NombComp(_P_Str_Comp);
        }

        private bool _Mtd_ExisteGuiaSADA(int _P_Int_Tipo, string _P_Str_GuiaSada)
        {
            string _Str_Cadena = "SELECT cnumguiasada FROM TGUIADESPACHODD WHERE ctipoguiasada='" + _P_Int_Tipo + "' AND cnumguiasada='" + _P_Str_GuiaSada + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_TipoGuiaSADA(int _P_Int_TipoGuiaSada)
        {
            switch (_P_Int_TipoGuiaSada)
            {
                case 1:
                    return "Guía de Movilización SADA";
                case 2:
                    return "Guía de Seguimiento y Control SADA";
                default:
                    return "Guía de Despacho al Detal SADA";
            }
        }
        private void _Btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ExisteGuiaSADA(_Int_TipoGuiaSada, _Txt_GuiaSada.Text.Trim().ToUpper()))
            {
                MessageBox.Show("El número de Guía SADA que introdujo ya existe. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Txt_GuiaSada.SelectAll();
                _Txt_GuiaSada.Focus();
            }
            else
            {
                string _Str_Cadena = "UPDATE TGUIADESPACHODD SET cnumguiasada='" + _Txt_GuiaSada.Text.Trim().ToUpper() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Str_Comp + "' AND cguiadesp='" + _Str_Guia + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                this.Close();
            }
        }
        private bool _Mtd_VerifContTextBoxVarcharNoCero(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (_Cls_VariosMetodos._Mtd_IsNumeric(_P_Txt_TextBox.Text))
                {
                    if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                    { return true; }
                }
                else
                { return true; }
            }
            return false;
        }
        private void Frm_GuiaSada_Load(object sender, EventArgs e)
        {
            
        }

        private void _Txt_GuiaSada_TextChanged(object sender, EventArgs e)
        {
            _Btn_Aceptar.Enabled = _Mtd_VerifContTextBoxVarcharNoCero(_Txt_GuiaSada);
        }

        private void Frm_GuiaSada_Shown(object sender, EventArgs e)
        {
            _Txt_GuiaSada.Focus();
        }

        private void _Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
