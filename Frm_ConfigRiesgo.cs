using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigRiesgo : Form
    {
        public Frm_ConfigRiesgo()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarData()
        {
            string _Str_Sql = "SELECT * FROM TCONFIGRIESGO";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Descrip.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdescripcion"]).Trim();
                _Txt_SiSuc.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctienesucursal"]).Trim();
                _Txt_NoSuc.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnotienesucursal"]).Trim();
                _Txt_SiPoliza.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cposeepoliza"]).Trim();
                _Txt_NoPoliza.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnoposeepoliza"]).Trim();
                _Txt_SiLocal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctienelocal"]).Trim();
                _Txt_NoLocal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnotienelocal"]).Trim();
                _Txt_SiDepMcia.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cposeedepositom"]).Trim();
                _Txt_NoDepMcia.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnoposeedepositom"]).Trim();
                _Txt_SiAttDirecto.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["catendidodirecto"]).Trim();
                _Txt_NoAttDirecto.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnoatendidodirecto"]).Trim();
                _Txt_SiCheqDev.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cchequedevueltos"]).Trim();
                _Txt_NoCheqDev.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnochequedevueltos"]).Trim();
                _Txt_SiCheqDevF.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cchequedevueltosfecha"]).Trim();
                _Txt_NoCheqDevF.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnochequedevueltosdecha"]).Trim();
                _Txt_SiSaldoVenc.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["csaldovencido"]).Trim();
                _Txt_NoSaldoVenc.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["csaldoporvencer"]).Trim();
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

        private void Frm_ConfigRiesgo_Load(object sender, EventArgs e)
        {
            _Mtd_Bloquear(false);
            _Mtd_CargarData();
        }

        private void Frm_ConfigRiesgo_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigRiesgo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}