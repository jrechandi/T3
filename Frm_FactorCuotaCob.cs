using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_FactorCuotaCob : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_FactorCuotaCob()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarZonas()
        {
            string _Str_Sql = "SELECT c_zona,rtrim(c_zonaname) as c_zonaname FROM VST_ZONAVENTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0";
            _Lst_Zona.SelectedIndexChanged -= new EventHandler(_Lst_Zona_SelectedIndexChanged);
            _myUtilidad._Mtd_CargarLista(_Lst_Zona, _Str_Sql);
            _Lst_Zona.SelectedIndexChanged += new EventHandler(_Lst_Zona_SelectedIndexChanged);
        }

        private void _Lst_Zona_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (_Lst_Zona.SelectedIndex > -1)
            {
                _Lbl_Cab.Text = _Lst_Zona.Text + " F.C.";
                _Str_Sql = "SELECT * FROM TCUOTACOBF WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND czona='" + _Lst_Zona.SelectedValue.ToString() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfactor"]) != "")
                    {
                        _Txt_Factor.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cfactor"]).ToString("#,##0.00");
                    }
                    else
                    {
                        _Txt_Factor.Text = "";
                    }
                }
                else
                {
                    _Txt_Factor.Text = "";
                }
                _Pnl_FactorCuota.Visible = true;
                _Txt_Factor.Focus();
            }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            double _Dbl_Factor = 0;
            if (_Txt_Factor.Text != "")
            {
                _Dbl_Factor = Convert.ToDouble(_Txt_Factor.Text);
            }
            _Str_Sql = "SELECT * FROM TCUOTACOBF WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND czona='" + _Lst_Zona.SelectedValue.ToString() + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                _Str_Sql = "UPDATE TCUOTACOBF SET cfactor=" + _Dbl_Factor.ToString().Replace(",", ".") + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND czona='" + _Lst_Zona.SelectedValue.ToString() + "'";
            }
            else
            {
                _Str_Sql = "INSERT INTO TCUOTACOBF (ccompany,czona,cfactor) VALUES('" + Frm_Padre._Str_Comp + "','" + _Lst_Zona.SelectedValue.ToString() + "'," + _Dbl_Factor.ToString().Replace(",", ".") + ")";
            }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Pnl_FactorCuota.Visible = false;
        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            _Pnl_FactorCuota.Visible = false;
        }

        private void Frm_FactorCuotaCob_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_FactorCuotaCob_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_FactorCuotaCob_Load(object sender, EventArgs e)
        {
            _Mtd_CargarZonas();
            if (_Lst_Zona.SelectedIndex > -1)
            {
                _Lst_Zona.SelectedIndex = -1;
                _Lst_Zona.SelectedIndex = 0;
            }
        }

        private void _Txt_Factor_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Factor, e, 15, 2);
        }

        private void _Txt_Factor_Enter(object sender, EventArgs e)
        {
            if (_Txt_Factor.Text != "")
            { _Txt_Factor.Text = _Txt_Factor.Text.Replace(".", ""); }
        }

        private void _Txt_Factor_Leave(object sender, EventArgs e)
        {
            if (_Txt_Factor.Text != "")
            { _Txt_Factor.Text = Convert.ToDouble(_Txt_Factor.Text).ToString("#,##0.00"); }
        }
    }
}