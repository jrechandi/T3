using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigCont : Form
    {
        public Frm_ConfigCont()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarData()
        {
            string _Str_Sql = "SELECT * FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cbegexe"]).Trim().Length > 0)
                {
                    _Txt_IniEjeEconomico.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cbegexe"]).ToShortDateString();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfinishexe"]).Trim().Length > 0)
                {
                    _Txt_FinEjeEconomico.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfinishexe"]).ToShortDateString();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cbegacco"]).Trim().Length > 0)
                {
                    _Txt_IniCont.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cbegacco"]).ToShortDateString();
                }
                _Txt_AnoCont.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cyearacco"]);
                _Txt_MonedaBase.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccurrebas"]);
                _Txt_MonedaOtra.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccurreadd"]);
                _Txt_LongCuenta.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clongcount"]);
                _Txt_NivCuenta.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevelcount"]);
                _Txt_CharSepara.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccharsepa"]);
                _Txt_Nivel1.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel1"]);
                _Txt_Nivel2.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel2"]);
                _Txt_Nivel3.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel3"]);
                _Txt_Nivel4.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel4"]);
                _Txt_Nivel5.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel5"]);
                _Txt_Nivel6.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel6"]);
                _Txt_Nivel7.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel7"]);
                _Txt_Nivel8.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel8"]);
                _Txt_Nivel9.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel9"]);
                _Txt_Nivel10.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["clevel10"]);
            }
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            for (int _I = 0; _I < _Tb_Tab.TabPages.Count; _I++)
            {
                foreach (Control _Ctrl in _Tb_Tab.TabPages[_I].Controls)
                {
                    if (!(_Ctrl is Label))
                    {
                        _Ctrl.Enabled = _Pr_Bol_A;
                    }
                }
            }
        }

        private void Frm_ConfigCont_Load(object sender, EventArgs e)
        {
            _Mtd_Bloquear(false);
            _Mtd_CargarData();
        }

        private void Frm_ConfigCont_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigCont_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}