using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Encuesta : Form
    {
        public Frm_Encuesta()
        {
            InitializeComponent();
        }
        public Frm_Encuesta(string _P_Str_Codigo, bool _P_Bol_Cliente)
        {
            InitializeComponent();
            _Mtd_Desactivar_CheckdePanels(_Pnl_Encuesta);
            if (_P_Bol_Cliente)
            { _Mtd_Cargar_Encuesta(_P_Str_Codigo, _Pnl_Encuesta); }
            else
            { _Mtd_Cargar_Encuesta_Prospecto(_P_Str_Codigo, _Pnl_Encuesta); }
        }
        private void _Mtd_Desactivar_CheckdePanels(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Desactivar_CheckdePanels(_Ctrl);
                }
                if (_Ctrl.GetType() == typeof(CheckBox))
                {
                    if (Convert.ToInt32(((CheckBox)_Ctrl).Tag) < 72)
                    {
                        _Mtd_Desactivar_Checks(((CheckBox)_Ctrl));
                    }
                }
            }
        }
        private void _Mtd_Desactivar_Checks(CheckBox _P_Chbox_Check)
        {
            _P_Chbox_Check.Click += new EventHandler(_P_Chbox_Check_Click);
        }

        void _P_Chbox_Check_Click(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            { ((CheckBox)sender).Checked = false; }
            else { ((CheckBox)sender).Checked = true; }
        }
        private void _Mtd_Cargar_Encuesta(string _P_Str_Codigo, Control _P_Ctrl_Control)
        {
            string _Str_Cadena = "Select ccm_beb_inst,ccm_bombillos,ccm_cerealinf,ccm_colados,ccm_cosmeticos,ccm_cuidadobebe,ccm_cuidadohogar,ccm_cuidadoperso,ccm_detergentes,ccm_enlatados,ccm_ferreteria,ccn_insecticida,ccm_juguetes,ccm_lineablanca,ccm_papeltoalet,ccm_productomed,ccm_untables,ccm_velas,cde_carniceria,cde_charcuteria,cde_desarrolladoep,cde_pocodesarroep,cde_mtscp_20,cde_mtscp_40mas,cde_mtscp_60mas,cde_mtscp_80mas,cde_mtscp_100mas,cde_autoservice_p,cde_autoservice_t,cde_pisodevta_20a50,cde_pisodevta_60a100,cde_pisodevta_200a300,cde_pisodevta_400a600,cde_pasillodvta_2a4,cde_pasillodvta_5a7,cde_pasillodvta_8a10,cde_pasillodvta_11a12,clpc_colgatepalmolive,clpc_consemencey,clpc_drocosca,clpc_energizer,clpc_pfizer,clpc_prodalic,clpc_scjhonson,clpc_velasvirg,clpc_escoberiamejor,clpc_gruponibra,clpc_jyj,clpc_kelloggs,clpc_kc,clpc_kraft,clpc_nestle,clpc_novartis,clpc_catman_20,clpc_catman_50,clpc_catman_70,clpc_catman_90,clpc_catman_100,clpc_presproman_p,clpc_presproman_m,clpc_presproman_g,clpc_frecuenciaofert_f,clpc_frecuenciaofert_o,clpc_frecuenciaofert_c,clpc_frecuenciaofert_n,clpc_cajasregistra_1a2,clpc_cajasregistra_3a5,clpc_cajasregistra_6a9,clpc_cajasregistra_10,clpc_puntodevtas,clpc_estacionamiento from TENCUESTA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
                {
                    if (_Ctrl.Controls.Count > 0)
                    {
                        _Mtd_Cargar_Encuesta(_P_Str_Codigo, _Ctrl);
                    }
                    if (_Ctrl.GetType() == typeof(CheckBox))
                    {
                        if (Convert.ToInt32(((CheckBox)_Ctrl).Tag) < 72)
                        {
                            ((CheckBox)_Ctrl).Checked = Convert.ToBoolean(Convert.ToInt32(_Row[Convert.ToInt32(((CheckBox)_Ctrl).Tag)].ToString()));
                        }
                    }
                }
                if (_Row["clpc_puntodevtas"].ToString() == "1")
                { _Chbox_72.Checked = true; _Chbox_73.Checked = false; }
                else { _Chbox_72.Checked = false; _Chbox_73.Checked = true; }
                if (_Row["clpc_estacionamiento"].ToString() == "1")
                { _Chbox_74.Checked = true; _Chbox_75.Checked = false; }
                else { _Chbox_74.Checked = false; _Chbox_75.Checked = true; }
            }
        }
        private void _Mtd_Cargar_Encuesta_Prospecto(string _P_Str_Codigo, Control _P_Ctrl_Control)
        {
            string _Str_Cadena = "Select ccm_beb_inst,ccm_bombillos,ccm_cerealinf,ccm_colados,ccm_cosmeticos,ccm_cuidadobebe,ccm_cuidadohogar,ccm_cuidadoperso,ccm_detergentes,ccm_enlatados,ccm_ferreteria,ccn_insecticida,ccm_juguetes,ccm_lineablanca,ccm_papeltoalet,ccm_productomed,ccm_untables,ccm_velas,cde_carniceria,cde_charcuteria,cde_desarrolladoep,cde_pocodesarroep,cde_mtscp_20,cde_mtscp_40mas,cde_mtscp_60mas,cde_mtscp_80mas,cde_mtscp_100mas,cde_autoservice_p,cde_autoservice_t,cde_pisodevta_20a50,cde_pisodevta_60a100,cde_pisodevta_200a300,cde_pisodevta_400a600,cde_pasillodvta_2a4,cde_pasillodvta_5a7,cde_pasillodvta_8a10,cde_pasillodvta_11a12,clpc_colgatepalmolive,clpc_consemencey,clpc_drocosca,clpc_energizer,clpc_pfizer,clpc_prodalic,clpc_scjhonson,clpc_velasvirg,clpc_escoberiamejor,clpc_gruponibra,clpc_jyj,clpc_kelloggs,clpc_kc,clpc_kraft,clpc_nestle,clpc_novartis,clpc_catman_20,clpc_catman_50,clpc_catman_70,clpc_catman_90,clpc_catman_100,clpc_presproman_p,clpc_presproman_m,clpc_presproman_g,clpc_frecuenciaofert_f,clpc_frecuenciaofert_o,clpc_frecuenciaofert_c,clpc_frecuenciaofert_n,clpc_cajasregistra_1a2,clpc_cajasregistra_3a5,clpc_cajasregistra_6a9,clpc_cajasregistra_10,clpc_puntodevtas,clpc_estacionamiento from TENCUESTA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
                {
                    if (_Ctrl.Controls.Count > 0)
                    {
                        _Mtd_Cargar_Encuesta_Prospecto(_P_Str_Codigo, _Ctrl);
                    }
                    if (_Ctrl.GetType() == typeof(CheckBox))
                    {
                        if (Convert.ToInt32(((CheckBox)_Ctrl).Tag) < 72)
                        {
                            ((CheckBox)_Ctrl).Checked = Convert.ToBoolean(Convert.ToInt32(_Row[Convert.ToInt32(((CheckBox)_Ctrl).Tag)].ToString()));
                        }
                    }
                }
                if (_Row["clpc_puntodevtas"].ToString() == "1")
                { _Chbox_72.Checked = true; _Chbox_73.Checked = false; }
                else { _Chbox_72.Checked = false; _Chbox_73.Checked = true; }
                if (_Row["clpc_estacionamiento"].ToString() == "1")
                { _Chbox_74.Checked = true; _Chbox_75.Checked = false; }
                else { _Chbox_74.Checked = false; _Chbox_75.Checked = true; }
            }
        }
        private void _Mtd_Ini_Checks(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Ini_Checks(_Ctrl);
                }
                if (_Ctrl.GetType() == typeof(CheckBox))
                {
                    if (Convert.ToInt32(((CheckBox)_Ctrl).Tag) < 72)
                    {
                        ((CheckBox)_Ctrl).Checked = false;
                    }
                }
            }
        }
        private void Frm_Encuesta_Load(object sender, EventArgs e)
        {

        }
    }
}