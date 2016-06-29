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
    public partial class Frm_IncCopiar : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        int _Int_SwInc = 0;
        public Frm_IncCopiar()
        {
            InitializeComponent();
        }
        public Frm_IncCopiar(int _P_Int_SwInc)
        {
            InitializeComponent();
            _Int_SwInc = _P_Int_SwInc;
            if (_P_Int_SwInc == 2)
            {
                _Lbl_Mes.Text = "Cuarto:";
                _Lbl_MesPara.Text = "Cuarto:";
            }
            _Mtd_CargarComp(_Cmb_CompDesde);
        }

        /// <summary>
        /// Configura el estilo visual de un control y sus controles secundarios.
        /// </summary>
        /// <param name="_P_Ctrl_Control">Instancia de un control</param>
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else
                {
                    if (_Ctrl.GetType() != typeof(RadioButton))
                    { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
                }
            }
        }

        /// <summary>
        /// Carga las compañías en el combobox especificado.
        /// </summary>
        /// <param name="_P_Cmb_Combo">Combobox en el que se cargarán las compañías.</param>
        private void _Mtd_CargarComp(ComboBox _P_Cmb_Combo)
        {
            string _Str_Cadena = "SELECT TCOMPANY.ccompany,TCOMPANY.cname FROM TCOMPANY INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany=TCOMPANY.ccompany WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TCOMPANY.cdelete='0'";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
        }

        /// <summary>
        /// Carga en un combobox los grupos de incentivo (desde) filtrados por la empresa (desde) seleccionada.
        /// </summary>
        /// <param name="_P_Str_CompDesde">Id de la empresa (desde).</param>
        private void _Mtd_CargarGrupoDesde(string _P_Str_CompDesde)
        {
            string _Str_Cadena = "";
            if (_Int_SwInc == 0)
            {
                _Str_Cadena = "SELECT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                "FROM TGRUPOIV INNER JOIN " +
                "TINCMARCAFOCO ON TGRUPOIV.cgroupcomp = TINCMARCAFOCO.cgroupcomp AND " +
                "TGRUPOIV.ccompany = TINCMARCAFOCO.ccompany AND TGRUPOIV.cidgrupincentivar = TINCMARCAFOCO.cidgrupincentivar " +
                "WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + _P_Str_CompDesde + "') " +
                "ORDER BY TGRUPOIV.cdescripcion";
            }
            else if (_Int_SwInc == 1)
            {
                _Str_Cadena = "SELECT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                "FROM TGRUPOIV INNER JOIN " +
                "TINCDISTRIBU ON TGRUPOIV.cgroupcomp = TINCDISTRIBU.cgroupcomp AND " +
                "TGRUPOIV.ccompany = TINCDISTRIBU.ccompany AND TGRUPOIV.cidgrupincentivar = TINCDISTRIBU.cidgrupincentivar " +
                "WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + _P_Str_CompDesde + "') " +
                "ORDER BY TGRUPOIV.cdescripcion";
            }
            else
            {
                _Str_Cadena = "SELECT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                "FROM TGRUPOIV INNER JOIN " +
                "TINCSIM ON TGRUPOIV.ccompany = TINCSIM.ccompany AND TGRUPOIV.cidgrupincentivar = TINCSIM.cidgrupincentivar " +
                "WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + _P_Str_CompDesde + "') " +
                "ORDER BY TGRUPOIV.cdescripcion";
            }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_GrupoDesde, _Str_Cadena);
        }

        /// <summary>
        /// Carga  en un combobox los años (desde) según la compañía (desde) y el grupo de incentivo (desde) seleccionados.
        /// </summary>
        /// <param name="_P_Str_CompDesde">Id de la compañía (desde)</param>
        /// <param name="_P_Str_GrupoDesde">Id del grupo de incentivo (desde)</param>
        private void _Mtd_CargarAñoDesde(string _P_Str_CompDesde, string _P_Str_GrupoDesde)
        {
            string _Str_Cadena = "";
            if (_Int_SwInc == 0)
            {
                _Str_Cadena = "SELECT DISTINCT TINCMARCAFOCOD.cano, TINCMARCAFOCOD.cano " +
                "FROM TINCMARCAFOCO INNER JOIN " +
                "TINCMARCAFOCOD ON TINCMARCAFOCO.cidincmarcafoco = TINCMARCAFOCOD.cidincmarcafoco AND " +
                "TINCMARCAFOCO.ccompany = TINCMARCAFOCOD.ccompany " +
                "WHERE (TINCMARCAFOCO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TINCMARCAFOCO.ccompany = '" + _P_Str_CompDesde + "') AND (TINCMARCAFOCO.cidgrupincentivar = '" + _P_Str_GrupoDesde + "') " +
                "ORDER BY TINCMARCAFOCOD.cano";
            }
            else if (_Int_SwInc == 1)
            {
                _Str_Cadena = "SELECT DISTINCT TINCDISTRIBUD.cano, TINCDISTRIBUD.cano " +
                "FROM TINCDISTRIBU INNER JOIN " +
                "TINCDISTRIBUD ON TINCDISTRIBU.cidincdistribu = TINCDISTRIBUD.cidincdistribu AND " +
                "TINCDISTRIBU.ccompany = TINCDISTRIBUD.ccompany " +
                "WHERE (TINCDISTRIBU.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TINCDISTRIBU.ccompany = '" + _P_Str_CompDesde + "') AND (TINCDISTRIBU.cidgrupincentivar = '" + _P_Str_GrupoDesde + "') " +
                "ORDER BY TINCDISTRIBUD.cano";
            }
            else
            {
                _Str_Cadena = "SELECT DISTINCT TINCSID.cano, TINCSID.cano " +
                "FROM TINCSIM INNER JOIN " +
                "TINCSID ON TINCSIM.cidincsim = TINCSID.cidincsim " +
                "WHERE (TINCSIM.ccompany = '" + _P_Str_CompDesde + "') AND (TINCSIM.cidgrupincentivar = '" + _P_Str_GrupoDesde + "') " +
                "ORDER BY TINCSID.cano";
            }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_AnoDesde, _Str_Cadena);
        }

        /// <summary>
        /// Carga  en un combobox los meses (desde) según la compañía (desde), el grupo de incentivo (desde) y el año (desde) seleccionados.
        /// </summary>
        /// <param name="_P_Str_CompDesde">Id de la compañía (desde)</param>
        /// <param name="_P_Str_GrupoDesde">Id del grupo de incentivo (desde)</param>
        /// <param name="_P_Str_Año">Año (desde)</param>
        private void _Mtd_CargarMesDesde(string _P_Str_CompDesde, string _P_Str_GrupoDesde, string _P_Str_Año)
        {
            string _Str_Cadena = "";
            if (_Int_SwInc == 0)
            {
                _Str_Cadena = "SELECT DISTINCT TINCMARCAFOCOD.cmes, TINCMARCAFOCOD.cmes " +
                "FROM TINCMARCAFOCO INNER JOIN " +
                "TINCMARCAFOCOD ON TINCMARCAFOCO.cidincmarcafoco = TINCMARCAFOCOD.cidincmarcafoco AND " +
                "TINCMARCAFOCO.ccompany = TINCMARCAFOCOD.ccompany " +
                "WHERE (TINCMARCAFOCO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TINCMARCAFOCO.ccompany = '" + _P_Str_CompDesde + "') AND (TINCMARCAFOCO.cidgrupincentivar = '" + _P_Str_GrupoDesde + "') AND (TINCMARCAFOCOD.cano='" + _P_Str_Año + "') " +
                "ORDER BY TINCMARCAFOCOD.cmes";
            }
            else if (_Int_SwInc == 1)
            {
                _Str_Cadena = "SELECT DISTINCT TINCDISTRIBUD.cmes, TINCDISTRIBUD.cmes " +
               "FROM TINCDISTRIBU INNER JOIN " +
               "TINCDISTRIBUD ON TINCDISTRIBU.cidincdistribu = TINCDISTRIBUD.cidincdistribu AND " +
               "TINCDISTRIBU.ccompany = TINCDISTRIBUD.ccompany " +
               "WHERE (TINCDISTRIBU.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TINCDISTRIBU.ccompany = '" + _P_Str_CompDesde + "') AND (TINCDISTRIBU.cidgrupincentivar = '" + _P_Str_GrupoDesde + "') AND (TINCDISTRIBUD.cano='" + _P_Str_Año + "') " +
               "ORDER BY TINCDISTRIBUD.cmes";
            }
            else
            {
                _Str_Cadena = "SELECT DISTINCT TINCSID.ccuarto, TINCSID.ccuarto " +
                              "FROM TINCSIM INNER JOIN " +
                              "TINCSID ON TINCSIM.cidincsim = TINCSID.cidincsim " +
                              "WHERE (TINCSIM.ccompany = '" + _P_Str_CompDesde + "') AND (TINCSIM.cidgrupincentivar = '" +
                              _P_Str_GrupoDesde + "') AND (TINCSID.cano='" + _P_Str_Año + "') " +
                              "ORDER BY TINCSID.ccuarto";
            }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_MesDesde, _Str_Cadena);
        }

        /// <summary>
        /// Carga en un combobox los grupos de incentivo (para) filtrados por la empresa (para) seleccionada.
        /// </summary>
        /// <param name="_P_Str_CompDesde">Id de la empresa (para).</param>
        private void _Mtd_CargarGrupoPara(string _P_Str_CompPara)
        {
            string _Str_Cadena = "";
            if (_Int_SwInc == 0 || _Int_SwInc == 2)
            { _Str_Cadena = "SELECT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion FROM TGRUPOIV  INNER JOIN TCARGOSNOM ON TGRUPOIV.cidcargonom = TCARGOSNOM.cidcargonom WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_CompPara + "' AND (cgerarea='1' OR cvendedor='1' OR cgventas='1') ORDER BY TGRUPOIV.cdescripcion"; }
            else
            { _Str_Cadena = "SELECT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion FROM TGRUPOIV  INNER JOIN TCARGOSNOM ON TGRUPOIV.cidcargonom = TCARGOSNOM.cidcargonom WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_CompPara + "' AND (cgercomer='1' OR cgerarea='1' OR cvendedor='1' OR cgventas='1') ORDER BY TGRUPOIV.cdescripcion"; }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_GrupoPara, _Str_Cadena);
        }

        /// <summary>
        /// Obtiene un valor que indica si un año esta disponible para anexarlo a los años (para)
        /// </summary>
        /// <param name="_P_Int_Año">Año a verificar</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_AñoDisponible(int _P_Int_Año)
        {
            if (_Int_SwInc == 0)
            {
                return (from Campos in Program._Dat_Vistas.VST_INC_MARCF_D
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue) & Campos.cano == _P_Int_Año
                        select Campos.cmes).Distinct().Count() < 12;
            }
            else if (_Int_SwInc == 1)
            {
                return (from Campos in Program._Dat_Vistas.VST_INC_DISTRIBU_D
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue) & Campos.cano == _P_Int_Año
                        select Campos.cmes).Distinct().Count() < 12;
            }
            else
            {
                return (from Campos in Program._Dat_Vistas.VST_INC_SI_D
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue) & Campos.cano == _P_Int_Año
                        select Campos.ccuarto).Distinct().Count() < 4;
            }
        }

        /// <summary>
        /// Cargar en un combobox los años (para)
        /// </summary>
        private void _Mtd_CargarAñoPara()
        {
            _Cmb_AnoPara.Items.Clear();
            _Cmb_AnoPara.Items.Add("...");
            for (int _Int_I = 2010; _Int_I <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddYears(2).Year; _Int_I++)
            {
                if (_Mtd_AñoDisponible(_Int_I))
                {
                    _Cmb_AnoPara.Items.Add(_Int_I);
                }
            }
            _Cmb_AnoPara.SelectedIndex = 0;
        }

        /// <summary>
        /// Obtiene un valor que indica si un mes según el año especificado ha sido ya cargado.
        /// Si ya existe no se puede mostrar en los meses (para).
        /// </summary>
        /// <param name="_P_Int_Año">Año</param>
        /// <param name="_P_Int_Mes">Mes a verificar</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_ExisteMes(int _P_Int_Año, int _P_Int_Mes)
        {
            if (_Int_SwInc == 0)
            {
                return (from Campos in Program._Dat_Vistas.VST_INC_MARCF_D
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue) & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes
                        select Campos.cmes).Distinct().Count() > 0;
            }
            else if (_Int_SwInc == 1)
            {
                return (from Campos in Program._Dat_Vistas.VST_INC_DISTRIBU_D
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue) & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes
                        select Campos.cmes).Distinct().Count() > 0;
            }
            else
            {
                return (from Campos in Program._Dat_Vistas.VST_INC_SI_D
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue) & Campos.cano == _P_Int_Año & Campos.ccuarto == _P_Int_Mes
                        select Campos.ccuarto).Distinct().Count() > 0;
            }
        }

        /// <summary>
        /// Carga en un combobox los meses (para).
        /// </summary>
        private void _Mtd_CargarMesPara()
        {
            _Cmb_MesPara.Items.Clear();
            _Cmb_MesPara.Items.Add("...");
            int _Int_NumeroHasta = _Int_SwInc == 2 ? 4 : 12;
            for (int _Int_I = 1; _Int_I <= _Int_NumeroHasta; _Int_I++)
            {
                if (!_Mtd_ExisteMes(Convert.ToInt32(_Cmb_AnoPara.Text), _Int_I))
                {
                    _Cmb_MesPara.Items.Add(_Int_I);
                }
            }
            _Cmb_MesPara.SelectedIndex = 0;
        }

        /// <summary>
        /// Obtiene un valor que indica si el grupo de incentivo (para) ya existe para la empresa (para) seleccionada.
        /// </summary>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo (para)</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            if (_Int_SwInc == 0)
            {
                return (from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == _P_Int_GrupoInc
                        select Campos.cidgrupincentivar).Count() > 0;
            }
            else if (_Int_SwInc==1)
            {
                return (from Campos in Program._Dat_Tablas.TINCDISTRIBU
                        where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == _P_Int_GrupoInc
                        select Campos.cidgrupincentivar).Count() > 0;
            }
            else
            {
                return (from Campos in Program._Dat_Tablas.TINCSIM
                        where Campos.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & Campos.cidgrupincentivar == _P_Int_GrupoInc
                        select Campos.cidgrupincentivar).Count() > 0;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si un proveedor tiene relacion con el grupo de incentivo (para) seleccionado.
        /// </summary>
        /// <param name="_P_Str_CompPara">Id de la compañía (para)</param>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo (para)</param>
        /// <param name="_P_Str_Proveedor">Id del proveedor</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_EstaRelacionadoProveedor(string _P_Str_CompPara, int _P_Int_GrupoInc, string _P_Str_Proveedor)
        {
            return (from CamposTGRUPOIV in Program._Dat_Tablas.TGRUPOIV
                    join CamposTGRUPPROVEE in Program._Dat_Tablas.TGRUPPROVEE on new { ccompany = CamposTGRUPOIV.ccompany, cgrupovta = CamposTGRUPOIV.cgrupovta } equals new { ccompany = CamposTGRUPPROVEE.ccompany, cgrupovta = CamposTGRUPPROVEE.cgrupovta }
                    where CamposTGRUPOIV.ccompany == _P_Str_CompPara & CamposTGRUPOIV.cidgrupincentivar == _P_Int_GrupoInc & CamposTGRUPPROVEE.cproveedor == _P_Str_Proveedor
                    select CamposTGRUPOIV).Count() > 0;
        }

        /// <summary>
        /// Obtiene un valor que indica si un conjunto tiene relacion con el grupo de incentivo (para) seleccionado.
        /// </summary>
        /// <param name="_P_Str_CompPara">Id de la compañía (para)</param>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo (para)</param>
        /// <param name="_P_Int_Conjunto">Id del conjunto</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_EstaRelacionadoConjunto(string _P_Str_CompPara, int _P_Int_GrupoInc, int _P_Int_Conjunto)
        {
            var _Var_Proveedores = (from CamposTINCMARCAFOCODD in Program._Dat_Tablas.TINCMARCAFOCODD
                              join CamposTPRODUCTO in Program._Dat_Tablas.TPRODUCTO on CamposTINCMARCAFOCODD.cproducto equals CamposTPRODUCTO.cproducto
                              where CamposTINCMARCAFOCODD.cconjunto == _P_Int_Conjunto
                              select CamposTPRODUCTO.cproveedor).OrderBy(c => c).Distinct();
            foreach (string _Str_Prov in _Var_Proveedores)
            {
                if (_Mtd_EstaRelacionadoProveedor(_P_Str_CompPara, _P_Int_GrupoInc, _Str_Prov.Trim()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene un valor que indica si los grupos de incentivo seleccionados tienen relacion en cuanto a los proveedores.
        /// </summary>
        /// <param name="_P_Int_SwInc">Valor que indica la entidad a verificar.
        /// (0-MarcaFoco, 1-Distribución, 2-Surtido Ideal)</param>
        /// <returns>Verdadero o falso</returns>
        private bool _Mtd_TieneRelacion(int _P_Int_SwInc)
        {
            if (_P_Int_SwInc == 0)
            {
                var _Var_TINCMARCAFOCO = Program._Dat_Tablas.TINCMARCAFOCO.Single(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoDesde.SelectedValue));
                var _Var_Prove_y_Conjun = (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & Campos.cidincmarcafoco == _Var_TINCMARCAFOCO.cidincmarcafoco & Campos.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & Campos.cmes == Convert.ToInt32(_Cmb_MesDesde.Text) select new { cproveedor = Campos.cproveedor, cconjunto = Campos.cconjunto }).OrderBy(c => c.cproveedor).Distinct();
                foreach (var _Var_Campo in _Var_Prove_y_Conjun)
                {
                    if (_Var_Campo.cproveedor == null)//Es un conjunto
                    {
                        if (_Mtd_EstaRelacionadoConjunto(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), (int)_Var_Campo.cconjunto))
                        { return true; }
                    }
                    else if (_Mtd_EstaRelacionadoProveedor(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), Convert.ToString(_Var_Campo.cproveedor).Trim()))
                    {
                        return true;
                    }
                }
            }
            else if (_P_Int_SwInc == 1)
            {
                var _Var_TINCDISTRIBU = Program._Dat_Tablas.TINCDISTRIBU.Single(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoDesde.SelectedValue));
                var _Var_Proveedores = Program._Dat_Tablas.TINCDISTRIBUD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidincdistribu == _Var_TINCDISTRIBU.cidincdistribu & c.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & c.cmes == Convert.ToInt32(_Cmb_MesDesde.Text)).OrderBy(c => c.cproveedor).Select(c => c.cproveedor).Distinct();
                foreach (var _Var_Prov in _Var_Proveedores)
                {
                    if (_Mtd_EstaRelacionadoProveedor(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), _Var_Prov.Trim()))
                    {
                        return true;
                    }
                }
            }
            else
            {
                var _Var_TINCSIM = Program._Dat_Tablas.TINCSIM.Single(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoDesde.SelectedValue));
                var _Var_Proveedores = Program._Dat_Vistas.VST_INC_SI_D.Where(c => c.cidincsim == _Var_TINCSIM.cidincsim & c.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & c.ccuarto == Convert.ToInt32(_Cmb_MesDesde.Text)).OrderBy(c => c.cproveedor).Select(c => c.cproveedor).Distinct();
                foreach (var _Var_Prov in _Var_Proveedores)
                {
                    if (_Mtd_EstaRelacionadoProveedor(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), _Var_Prov.Trim()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Inserta el detalle de los conjuntos según los parámetros especificados.
        /// </summary>
        /// <param name="_P_Str_CompPara">Id de la compañía (para)</param>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo (para)</param>
        /// <param name="_P_Int_ConjuntoDesde">Id del conjunto (desde)</param>
        /// <param name="_P_Int_ConjuntoHasta">Id del conjunto (hasta)</param>
        private void _Mtd_InsertarConjuntoDetalle(string _P_Str_CompPara, int _P_Int_GrupoInc, int _P_Int_ConjuntoDesde, int _P_Int_ConjuntoHasta)
        {
            var _Var_Proveedores = (from CamposTINCMARCAFOCODD in Program._Dat_Tablas.TINCMARCAFOCODD
                                    join CamposTPRODUCTO in Program._Dat_Tablas.TPRODUCTO on CamposTINCMARCAFOCODD.cproducto equals CamposTPRODUCTO.cproducto
                                    where CamposTINCMARCAFOCODD.cconjunto == _P_Int_ConjuntoDesde
                                    select CamposTPRODUCTO.cproveedor).OrderBy(c => c).Distinct();
            foreach (string _Str_Prov in _Var_Proveedores)
            {
                if (_Mtd_EstaRelacionadoProveedor(_P_Str_CompPara, _P_Int_GrupoInc, _Str_Prov.Trim()))
                {
                    var _Var_TINCMARCAFOCODD = from CamposTINCMARCAFOCODD in Program._Dat_Tablas.TINCMARCAFOCODD
                                               join CamposTPRODUCTO in Program._Dat_Tablas.TPRODUCTO on CamposTINCMARCAFOCODD.cproducto equals CamposTPRODUCTO.cproducto
                                               where CamposTINCMARCAFOCODD.cconjunto == _P_Int_ConjuntoDesde & CamposTPRODUCTO.cproveedor == _Str_Prov.Trim()
                                               select CamposTINCMARCAFOCODD.cproducto;
                    foreach (string _Str_Producto in _Var_TINCMARCAFOCODD)
                    {
                        T3.DataContext.TINCMARCAFOCODD _T_TINCMARCAFOCODD = new T3.DataContext.TINCMARCAFOCODD()
                        {
                            cconjunto = _P_Int_ConjuntoHasta,
                            cproducto = _Str_Producto
                        };
                        Program._Dat_Tablas.TINCMARCAFOCODD.InsertOnSubmit(_T_TINCMARCAFOCODD);
                        Program._Dat_Tablas.SubmitChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Copia el incentivo para la entidad Marcafoco.
        /// </summary>
        private void _Mtd_CopiarIncentivoMarc()
        {
            var _Var_TINCMARCAFOCO = Program._Dat_Tablas.TINCMARCAFOCO.Single(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoDesde.SelectedValue));
            //----------------------------------------------------------
            DataContext.TINCMARCAFOCO _T_TINCMARCAFOCO;
            if (_Mtd_Existe(Convert.ToInt32(_Cmb_GrupoPara.SelectedValue)))
            {
                _T_TINCMARCAFOCO = Program._Dat_Tablas.TINCMARCAFOCO.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue));
                _T_TINCMARCAFOCO.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCMARCAFOCO.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCMARCAFOCO = new T3.DataContext.TINCMARCAFOCO();
                _T_TINCMARCAFOCO.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TINCMARCAFOCO.ccompany = Convert.ToString(_Cmb_CompPara.SelectedValue).Trim();
                _T_TINCMARCAFOCO.cidgrupincentivar = Convert.ToInt32(_Cmb_GrupoPara.SelectedValue);
                _T_TINCMARCAFOCO.cidincmarcafoco = new _Cls_Consecutivos()._Mtd_IncMar();
                _T_TINCMARCAFOCO.casesorgerente = _Var_TINCMARCAFOCO.casesorgerente;
                _T_TINCMARCAFOCO.ccomision1pag = _Var_TINCMARCAFOCO.ccomision1pag;
                _T_TINCMARCAFOCO.ccomision2pag = _Var_TINCMARCAFOCO.ccomision2pag;
                _T_TINCMARCAFOCO.ccomision3pag = _Var_TINCMARCAFOCO.ccomision3pag;
                _T_TINCMARCAFOCO.ccomisiontotal = _Var_TINCMARCAFOCO.ccomisiontotal;
                _T_TINCMARCAFOCO.ccompany = Convert.ToString(_Cmb_CompPara.SelectedValue).Trim();
                _T_TINCMARCAFOCO.ccondicionobjvtas1 = _Var_TINCMARCAFOCO.ccondicionobjvtas1;
                _T_TINCMARCAFOCO.ccondicionobjvtas2 = _Var_TINCMARCAFOCO.ccondicionobjvtas2;
                _T_TINCMARCAFOCO.ccondicionobjvtas3 = _Var_TINCMARCAFOCO.ccondicionobjvtas3;
                _T_TINCMARCAFOCO.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCMARCAFOCO.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCMARCAFOCO.InsertOnSubmit(_T_TINCMARCAFOCO);
            }
            Program._Dat_Tablas.SubmitChanges();
            //----------------------------------------------------------
            bool _Bol_EstaRelacionado = false;
            DataContext.TINCMARCAFOCOD _T_TINCMARCAFOCOD;
            var _Var_Prove_y_Conjun = (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & Campos.cidincmarcafoco == _Var_TINCMARCAFOCO.cidincmarcafoco & Campos.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & Campos.cmes == Convert.ToInt32(_Cmb_MesDesde.Text) select new { cproveedor = Campos.cproveedor, cconjunto = Campos.cconjunto }).OrderBy(c => c.cproveedor).Distinct();
            foreach (var _Var_Campo in _Var_Prove_y_Conjun)
            {
                //--------------------------------
                _Bol_EstaRelacionado = false;
                if (_Var_Campo.cproveedor == null)//Es un conjunto
                {
                    if (_Mtd_EstaRelacionadoConjunto(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), (int)_Var_Campo.cconjunto))
                    { _Bol_EstaRelacionado = true; }
                }
                else if (_Mtd_EstaRelacionadoProveedor(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), Convert.ToString(_Var_Campo.cproveedor).Trim()))
                {
                    _Bol_EstaRelacionado = true;
                }
                //--------------------------------
                if (_Bol_EstaRelacionado)
                {
                    //------------------------------------------
                    var _Var_TINCMARCAFOCOD = from Campos in Program._Dat_Tablas.TINCMARCAFOCOD 
                                              where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & Campos.cidincmarcafoco == _Var_TINCMARCAFOCO.cidincmarcafoco & Campos.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & Campos.cmes == Convert.ToInt32(_Cmb_MesDesde.Text) 
                                              select Campos;
                    //-------------------------
                    if (_Var_Campo.cproveedor == null)//Es un conjunto
                    { _Var_TINCMARCAFOCOD = _Var_TINCMARCAFOCOD.Where(c => c.cconjunto == _Var_Campo.cconjunto).OrderBy(c => c.cidincmarcafocod); }
                    else
                    { _Var_TINCMARCAFOCOD = _Var_TINCMARCAFOCOD.Where(c => c.cproveedor == _Var_Campo.cproveedor).OrderBy(c => c.cidincmarcafocod); }
                    foreach (var _Var in _Var_TINCMARCAFOCOD)
                    {
                        _T_TINCMARCAFOCOD = new T3.DataContext.TINCMARCAFOCOD();
                        _T_TINCMARCAFOCOD.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                        _T_TINCMARCAFOCOD.ccompany = Convert.ToString(_Cmb_CompPara.SelectedValue).Trim();
                        _T_TINCMARCAFOCOD.cidincmarcafoco = _T_TINCMARCAFOCO.cidincmarcafoco;
                        _T_TINCMARCAFOCOD.cidincmarcafocod = new _Cls_Consecutivos()._Mtd_IncMarDetalle(_T_TINCMARCAFOCO.cidincmarcafoco);
                        _T_TINCMARCAFOCOD.cano = Convert.ToInt32(_Cmb_AnoPara.Text);
                        _T_TINCMARCAFOCOD.cmes = Convert.ToInt32(_Cmb_MesPara.Text);
                        _T_TINCMARCAFOCOD.ccanal = _Var.ccanal;
                        _T_TINCMARCAFOCOD.cestable = _Var.cestable;
                        _T_TINCMARCAFOCOD.cgrupo = _Var.cgrupo;
                        _T_TINCMARCAFOCOD.cmarca = _Var.cmarca;
                        _T_TINCMARCAFOCOD.cporcactivamin = _Var.cporcactivamin;
                        _T_TINCMARCAFOCOD.cproducto = _Var.cproducto;
                        _T_TINCMARCAFOCOD.cproveedor = _Var.cproveedor;
                        _T_TINCMARCAFOCOD.csubgrupo = _Var.csubgrupo;
                        if (_Var.cconjunto > 0)
                        {
                            _T_TINCMARCAFOCOD.cconjunto = new _Cls_Consecutivos()._Mtd_IncConjunto();
                            _T_TINCMARCAFOCOD.cconjuntodesc = _Var.cconjuntodesc;
                        }
                        _T_TINCMARCAFOCOD.ctodos = _Var.ctodos;
                        _T_TINCMARCAFOCOD.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                        _T_TINCMARCAFOCOD.cuseradd = Frm_Padre._Str_Use;
                        Program._Dat_Tablas.TINCMARCAFOCOD.InsertOnSubmit(_T_TINCMARCAFOCOD);
                        Program._Dat_Tablas.SubmitChanges();
                        if (_Var.cconjunto > 0)
                        {
                            _Mtd_InsertarConjuntoDetalle(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), (int)_Var.cconjunto, (int)_T_TINCMARCAFOCOD.cconjunto);
                        }
                    }
                    //------------------------------------------
                }
            }
        }

        /// <summary>
        /// Copia el incentivo para la entidad Distribución.
        /// </summary>
        private void _Mtd_CopiarIncentivoDist()
        {
            var _Var_TINCDISTRIBU = Program._Dat_Tablas.TINCDISTRIBU.Single(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoDesde.SelectedValue));
            //----------------------------------------------------------
            DataContext.TINCDISTRIBU _T_TINCDISTRIBU;
            if (_Mtd_Existe(Convert.ToInt32(_Cmb_GrupoPara.SelectedValue)))
            {
                _T_TINCDISTRIBU = Program._Dat_Tablas.TINCDISTRIBU.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue));
                _T_TINCDISTRIBU.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCDISTRIBU.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCDISTRIBU = new T3.DataContext.TINCDISTRIBU();
                _T_TINCDISTRIBU.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TINCDISTRIBU.ccompany = Convert.ToString(_Cmb_CompPara.SelectedValue).Trim();
                _T_TINCDISTRIBU.cidgrupincentivar = Convert.ToInt32(_Cmb_GrupoPara.SelectedValue);
                _T_TINCDISTRIBU.cidincdistribu = new _Cls_Consecutivos()._Mtd_IncDis();
                _T_TINCDISTRIBU.cporcindividual = _Var_TINCDISTRIBU.cporcindividual;
                _T_TINCDISTRIBU.cporcpromedio = _Var_TINCDISTRIBU.cporcpromedio;
                _T_TINCDISTRIBU.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCDISTRIBU.cuserupd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCDISTRIBU.InsertOnSubmit(_T_TINCDISTRIBU);
            }
            Program._Dat_Tablas.SubmitChanges();
            //----------------------------------------------------------
            DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD;
            //var _Var_Proveedores = Program._Dat_Tablas.TINCDISTRIBUD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidincdistribu == _Var_TINCDISTRIBU.cidincdistribu & c.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & c.cmes == Convert.ToInt32(_Cmb_MesDesde.Text)).OrderBy(c => c.cproveedor).Select(c => c.cproveedor).Distinct();
            var _Var_Proveedores = (from Campos in Program._Dat_Tablas.TINCDISTRIBUD where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) && Campos.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() && Campos.cidincdistribu == _Var_TINCDISTRIBU.cidincdistribu && Campos.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & Campos.cmes == Convert.ToInt32(_Cmb_MesDesde.Text) select new { Campos.cproveedor }).OrderBy(c => c.cproveedor).Distinct();
            foreach (var _Var_Prov in _Var_Proveedores)
            {
                if (_Mtd_EstaRelacionadoProveedor(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), _Var_Prov.cproveedor.Trim()))
                {
                    //------------------------------------------
                    var _Var_TINCDISTRIBUD = Program._Dat_Tablas.TINCDISTRIBUD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidincdistribu == _Var_TINCDISTRIBU.cidincdistribu & c.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & c.cmes == Convert.ToInt32(_Cmb_MesDesde.Text) & c.cproveedor == _Var_Prov.cproveedor.Trim()).OrderBy(c => c.cidincdistribud);
                    foreach (var _Var in _Var_TINCDISTRIBUD)
                    {
                        _T_TINCDISTRIBUD = new T3.DataContext.TINCDISTRIBUD();
                        _T_TINCDISTRIBUD.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                        _T_TINCDISTRIBUD.ccompany = Convert.ToString(_Cmb_CompPara.SelectedValue).Trim();
                        _T_TINCDISTRIBUD.cidincdistribu = _T_TINCDISTRIBU.cidincdistribu;
                        _T_TINCDISTRIBUD.cidincdistribud = new _Cls_Consecutivos()._Mtd_IncDisDetalle(_T_TINCDISTRIBU.cidincdistribu);
                        _T_TINCDISTRIBUD.cano = Convert.ToInt32(_Cmb_AnoPara.Text);
                        _T_TINCDISTRIBUD.cmes = Convert.ToInt32(_Cmb_MesPara.Text);
                        _T_TINCDISTRIBUD.cproveedor = _Var.cproveedor;
                        _T_TINCDISTRIBUD.cgrupo = _Var.cgrupo;
                        _T_TINCDISTRIBUD.ccomision = _Var.ccomision;
                        _T_TINCDISTRIBUD.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                        _T_TINCDISTRIBUD.cuseradd = Frm_Padre._Str_Use;
                        Program._Dat_Tablas.TINCDISTRIBUD.InsertOnSubmit(_T_TINCDISTRIBUD);
                        Program._Dat_Tablas.SubmitChanges();
                    }
                    //------------------------------------------
                }
            }
        }


        /// <summary>
        /// Copia el incentivo para la entidad Surtido ideal.
        /// </summary>
        private void _Mtd_CopiarIncentivoSI()
        {
            var _Var_TINCSIM = Program._Dat_Tablas.TINCSIM.Single(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoDesde.SelectedValue));
            //----------------------------------------------------------
            DataContext.TINCSIM _T_TINCSIM;
            if (_Mtd_Existe(Convert.ToInt32(_Cmb_GrupoPara.SelectedValue)))
            {
                _T_TINCSIM = Program._Dat_Tablas.TINCSIM.Single(c => c.ccompany == Convert.ToString(_Cmb_CompPara.SelectedValue).Trim() & c.cidgrupincentivar == Convert.ToInt32(_Cmb_GrupoPara.SelectedValue));
                _T_TINCSIM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCSIM.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCSIM = new T3.DataContext.TINCSIM();
                _T_TINCSIM.ccompany = Convert.ToString(_Cmb_CompPara.SelectedValue).Trim();
                _T_TINCSIM.cidgrupincentivar = Convert.ToInt32(_Cmb_GrupoPara.SelectedValue);
                _T_TINCSIM.ccomisionmensual = _Var_TINCSIM.ccomisionmensual;
                _T_TINCSIM.ctipovendedor = _Var_TINCSIM.ctipovendedor;
                _T_TINCSIM.cvvporcmin = _Var_TINCSIM.cvvporcmin;
                _T_TINCSIM.csiporcmin = _Var_TINCSIM.csiporcmin;
                _T_TINCSIM.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCSIM.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCSIM.InsertOnSubmit(_T_TINCSIM);
            }
            Program._Dat_Tablas.SubmitChanges();
            //----------------------------------------------------------
            DataContext.TINCSID _T_TINCSID;
            var _Var_Proveedores = (from Campos in Program._Dat_Vistas.VST_INC_SI_D where Campos.cidincsim == _Var_TINCSIM.cidincsim & Campos.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & Campos.ccuarto == Convert.ToInt32(_Cmb_MesDesde.Text) select new { Campos.cproveedor }).OrderBy(c => c.cproveedor).Distinct();
            foreach (var _Var_Prov in _Var_Proveedores)
            {
                //--------------------------------
                if (_Mtd_EstaRelacionadoProveedor(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim(), Convert.ToInt32(_Cmb_GrupoPara.SelectedValue), Convert.ToString(_Var_Prov.cproveedor).Trim()))
                {

                    var _Var_TINCSID = Program._Dat_Vistas.VST_INC_SI_D.Where(c => c.ccompany == Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim() & c.cidincsim == _Var_TINCSIM.cidincsim & c.cano == Convert.ToInt32(_Cmb_AnoDesde.Text) & c.ccuarto == Convert.ToInt32(_Cmb_MesDesde.Text) & c.cproveedor == _Var_Prov.cproveedor.Trim()).OrderBy(c => c.cidincsid);
                    foreach (var _Var in _Var_TINCSID)
                    {
                        _T_TINCSID = new T3.DataContext.TINCSID();
                        _T_TINCSID.cidincsim = _T_TINCSIM.cidincsim;
                        _T_TINCSID.cano = Convert.ToInt32(_Cmb_AnoPara.Text);
                        _T_TINCSID.ccuarto = Convert.ToByte(_Cmb_MesPara.Text);
                        _T_TINCSID.ctestable = _Var.ctestable;
                        _T_TINCSID.cproducto = _Var.cproducto;
                        _T_TINCSID.ccanal = _Var.ccanal;
                        _T_TINCSID.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                        _T_TINCSID.cuseradd = Frm_Padre._Str_Use;
                        _T_TINCSID.cdelete = 0;
                        Program._Dat_Tablas.TINCSID.InsertOnSubmit(_T_TINCSID);
                        Program._Dat_Tablas.SubmitChanges();
                    }   
                }
            }
        }

        private void Frm_IncCopiar_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void _Cmb_CompDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CompDesde.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarGrupoDesde(Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_GrupoDesde.Enabled = true; }
            else
            { _Cmb_GrupoDesde.SelectedIndex = -1; _Cmb_GrupoDesde.DataSource = null; _Cmb_GrupoDesde.Enabled = false; }
        }

        private void _Cmb_CompDesde_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarComp(_Cmb_CompDesde);
            Cursor = Cursors.Default;
        }

        private void _Cmb_GrupoDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_GrupoDesde.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarAñoDesde(Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoDesde.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_AnoDesde.Enabled = true; }
            else
            { _Cmb_AnoDesde.SelectedIndex = -1; _Cmb_AnoDesde.DataSource = null; _Cmb_AnoDesde.Enabled = false; }
        }

        private void _Cmb_GrupoDesde_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; 
            _Mtd_CargarGrupoDesde(Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim()); 
            Cursor = Cursors.Default;
        }

        private void _Cmb_AnoDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_AnoDesde.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarMesDesde(Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoDesde.SelectedValue).Trim(), Convert.ToString(_Cmb_AnoDesde.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_MesDesde.Enabled = true; }
            else
            { _Cmb_MesDesde.SelectedIndex = -1; _Cmb_MesDesde.DataSource = null; _Cmb_MesDesde.Enabled = false; }
        }

        private void _Cmb_AnoDesde_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; 
            _Mtd_CargarAñoDesde(Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoDesde.SelectedValue).Trim()); 
            Cursor = Cursors.Default;
        }

        private void _Cmb_MesDesde_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; 
            _Mtd_CargarMesDesde(Convert.ToString(_Cmb_CompDesde.SelectedValue).Trim(), Convert.ToString(_Cmb_GrupoDesde.SelectedValue).Trim(), Convert.ToString(_Cmb_AnoDesde.SelectedValue).Trim()); 
            Cursor = Cursors.Default;
        }

        private void _Cmb_CompPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CompPara.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarGrupoPara(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_GrupoPara.Enabled = true; }
            else
            { _Cmb_GrupoPara.SelectedIndex = -1; _Cmb_GrupoPara.DataSource = null; _Cmb_GrupoPara.Enabled = false; }
        }

        private void _Cmb_CompPara_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarComp(_Cmb_CompPara);
            Cursor = Cursors.Default;
        }

        private void _Cmb_GrupoPara_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupoPara(Convert.ToString(_Cmb_CompPara.SelectedValue).Trim());
            Cursor = Cursors.Default;
        }

        private void _Cmb_GrupoPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_GrupoPara.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarAñoPara(); Cursor = Cursors.Default; _Cmb_AnoPara.Enabled = true; }
            else
            { _Cmb_AnoPara.Items.Clear(); _Cmb_AnoPara.Enabled = false; _Cmb_MesPara.Items.Clear(); _Cmb_MesPara.Enabled = false; _Bt_Copiar.Enabled = false; }
        }

        private void _Cmb_AnoPara_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarAñoPara();
            Cursor = Cursors.Default;

        }

        private void _Cmb_AnoPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_AnoPara.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarMesPara(); Cursor = Cursors.Default; _Cmb_MesPara.Enabled = true; }
            else
            { _Cmb_MesPara.Items.Clear(); _Cmb_MesPara.Enabled = false; _Bt_Copiar.Enabled = false; }
        }

        private void _Cmb_MesPara_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMesPara();
            Cursor = Cursors.Default;
        }

        private void _Cmb_MesDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_MesDesde.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarComp(_Cmb_CompPara); Cursor = Cursors.Default; _Cmb_CompPara.Enabled = true; }
            else
            { _Cmb_CompPara.SelectedIndex = -1; _Cmb_CompPara.DataSource = null; _Cmb_CompPara.Enabled = false; }
        }

        private void _Cmb_MesPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Copiar.Enabled = _Cmb_MesPara.SelectedIndex > 0;
        }

        private void _Bt_Copiar_Click(object sender, EventArgs e)
        {
            if (_Mtd_TieneRelacion(_Int_SwInc))
            {
                _Pnl_Clave.Visible = true;
            }
            else
            { MessageBox.Show("Los grupos seleccionados no tienen relacion en cuanto a los proveedores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Enabled = false;
                Cursor = Cursors.WaitCursor;
                if (_Int_SwInc == 0)
                { _Mtd_CopiarIncentivoMarc(); }
                else if (_Int_SwInc == 1)
                { _Mtd_CopiarIncentivoDist(); }
                else
                { _Mtd_CopiarIncentivoSI(); }
                Cursor = Cursors.Default;
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Grb_Desde.Enabled = false; _Grb_Para.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Grb_Desde.Enabled = true; _Grb_Para.Enabled = true; }
        }
    }
}
