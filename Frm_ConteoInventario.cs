using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Linq;
namespace T3
{
    public partial class Frm_ConteoInventario : Form
    {
        private bool _Bol_Conteo3 = false;
        bool _Bol_Contex = false;
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _G_Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public void _Mtd_CerrarFormulario()
        {
            this.Close();
        }
        private void _Mtd_HabilitarDesmar()
        {
            string _Str_Cadena = "Select cnousada from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='1' and cnousada='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Btn_Desmarcar.Enabled = true;
            }
            else
            {
                _Btn_Desmarcar.Enabled = false;
            }
            _Str_Cadena = "Select cnousada from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='1' and cnousada='0'";
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               _Btn_Inhabilitar.Enabled = true;
           }
           else
           {
               _Btn_Inhabilitar.Enabled = false;
           }
        }
        public Frm_ConteoInventario()
        {
            InitializeComponent();
            _Mtd_HabilitarDesmar();
            string _Str_Cadena = "Select cfinalizado from TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' and cfinalizado='2' or cfinalizado='1' and ccompany='" + Frm_Padre._Str_Comp + "'";
            if (!Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
            {
                _Str_Cadena = "Select cimprimir3er,ccuadrado from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    bool _Bol_Progress = true;
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        _Bol_Conteo3 = true;
                        _Prb_Progreso1.Visible = false; _Lbl_Text1.Visible = false; _Lbl_P1.Visible = false; _Bt_InfPrimerCont.Visible = false;
                        _Prb_Progreso2.Visible = false; _Lbl_Text2.Visible = false; _Lbl_P2.Visible = false; _Bt_InfSegundoCont.Visible = false;
                        _Prb_Progreso3.Visible = true; _Lbl_Text3.Visible = true; _Lbl_P3.Visible = true; _Bt_InfTercerCont.Visible = true;
                        _Bt_InfPrimerCont.Visible = false;
                        _Bt_InfSegundoCont.Visible = false;
                        _Pnl_Conteo.Visible = true;
                        _Cmb_Conteo.SelectedIndex = 2;
                    }
                    else
                    {
                        _Bt_AgregarTar.Enabled = _MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IMPRESION_TARJETA");
                    }
                    _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0'";
                    int _Int_N1 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
                    _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' and cantcont1_u1=cantcont2_u1 and cantcont1_u2=cantcont2_u2 and cconteo1='1' and cconteo2='1'";
                    int _Int_N2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
                    _Mtd_Progress();
                    if (_Lbl_P1.Text.Trim().Length == 5 & _Lbl_P2.Text.Trim().Length == 5 & _Int_N1 == _Int_N2)
                    {
                        _Mtd_Inicializar();
                        _Bol_Progress = false;
                    }
                    else if (_Lbl_P1.Text.Trim().Length == 5 & _Lbl_P2.Text.Trim().Length == 5 & _Int_N1 != _Int_N2)
                    {
                        _Bol_Progress = false;
                    }
                    if (_Bol_Progress)
                    {
                        if (_Mtd_Progress())
                        { _Pnl_Informacion.Visible = true; }
                        else
                        { _Pnl_Conteo.Visible = true; }
                    }
                }
            }
        }
        public void _Mtd_Visibilizar_Panel3()
        {
            _Bol_Conteo3 = true;
            _Prb_Progreso1.Visible = false; _Lbl_Text1.Visible = false; _Lbl_P1.Visible = false; _Bt_InfPrimerCont.Visible = false;
            _Prb_Progreso2.Visible = false; _Lbl_Text2.Visible = false; _Lbl_P2.Visible = false; _Bt_InfSegundoCont.Visible = false;
            _Prb_Progreso3.Visible = true; _Lbl_Text3.Visible = true; _Lbl_P3.Visible = true; _Bt_InfTercerCont.Visible = true;
            _Cmb_Conteo.SelectedIndex = 2;
            _Txt_Tarjeta.Text = "";
            _Txt_Cajas.Text = "";
            _Txt_Unidades.Text = "";
            _Txt_Producto.Text = "";
            _Lbl_Lote.Text = "";
            _Lbl_PMV.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Conteo.Text = "3er CONTEO";
            _Grb_1.Enabled = true;
            _Bt_Verificacion.Enabled = false;
            _Bt_Aceptar_Arriba.Enabled = true;
            _Bt_Cancelar_Arriba.Enabled = true;
            _Txt_Tarjeta.Focus();
        }
        public void _Mtd_Inicializar()
        {
            _Bol_Conteo3 = true;
            _Prb_Progreso1.Visible = false; _Lbl_Text1.Visible = false; _Lbl_P1.Visible = false; _Bt_InfPrimerCont.Visible = false;
            _Prb_Progreso2.Visible = false; _Lbl_Text2.Visible = false; _Lbl_P2.Visible = false; _Bt_InfSegundoCont.Visible = false;
            _Prb_Progreso3.Visible = false; _Lbl_Text3.Visible = false; _Lbl_P3.Visible = false; _Bt_InfTercerCont.Visible = false;
            _Dg_Grid.DataSource = null;
            _Txt_Tarjeta.Text = "";
            _Txt_Cajas.Text = "";
            _Txt_Unidades.Text = "";
            _Txt_Producto.Text = "";
            _Lbl_Lote.Text = "";
            _Lbl_PMV.Text = "";
            _Txt_Conteo.Text = "";
            _Txt_Descripcion.Text = "";
            _Grb_1.Enabled = false;
            _Bt_Aceptar_Arriba.Enabled = false;
            _Bt_Cancelar_Arriba.Enabled = false;
            _Bt_Finalizar.Enabled = true;
            _Bt_Elegir.Enabled = false;
            _Bt_Verificacion.Enabled = false;
        }
        int _Int_Sw = 0;
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Mtd_Acceso()
        {
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {
                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    if (_Int_Sw == 1)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        _Pnl_Clave.Visible = false;
                        _Mtd_Finalizar();
                        this.Cursor = Cursors.Default;
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { this.Cursor = Cursors.Default; }
        }
        private void _Mtd_Conteo(int _P_Int_Conteo)
        {
            string _Str_Cadena = "";
            if (_P_Int_Conteo == 0)
            {
                _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cantcont1_u1,cantcont1_u2,cimpr_u2,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cconteo1='1' and cnousada='0' order by id_tarjetainv";
                _Dg_Grid.Columns[4].DataPropertyName = "cantcont1_u1";
                _Dg_Grid.Columns[5].DataPropertyName = "cantcont1_u2";
            }
            else if (_P_Int_Conteo == 1)
            {
                _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cantcont2_u1,cantcont2_u2,cimpr_u2,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cconteo2='1' and cnousada='0' order by id_tarjetainv";
                _Dg_Grid.Columns[4].DataPropertyName = "cantcont2_u1";
                _Dg_Grid.Columns[5].DataPropertyName = "cantcont2_u2";
            }
            else if (_P_Int_Conteo == 2)
            {
                _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cantcont3_u1,cantcont3_u2,cimpr_u2,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cconteo3='1' and cnousada='0' order by id_tarjetainv";
                _Dg_Grid.Columns[4].DataPropertyName = "cantcont3_u1";
                _Dg_Grid.Columns[5].DataPropertyName = "cantcont3_u2";
            }
            else if (_P_Int_Conteo == 3)
            {
                _Str_Cadena = "Select id_tarjetainv,c_nomb_abreviado,cproducto,cnamefc AS cnamef,cantcont3_u1,cantcont3_u2,cimpr_u2,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where 0>1";
                _Dg_Grid.Columns[4].DataPropertyName = "cantcont3_u1";
                _Dg_Grid.Columns[5].DataPropertyName = "cantcont3_u2";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Seleccionar(string _P_Int_Numero)
        {
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Int_Numero.Trim())
                { _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Grid.Rows[_Int_Row].Cells[0];
                _Dg_Grid.CurrentCell = _Dg_Cel;
                _Dg_Grid.Rows[_Int_Row].Selected = true;
            }

        }
        private void _Mtd_Buscar(string _P_Str_Numero)
        {
            string _Str_Cadena = "";
            if (_Cmb_Conteo.SelectedIndex==0)
            { _Str_Cadena = "Select cproducto,cnamefc AS cnamef,cantcont1_u1,cantcont1_u2,cimpr_u2,cconteo1,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Numero + "' and cnousada='0'"; }
            else if (_Cmb_Conteo.SelectedIndex == 1)
            { _Str_Cadena = "Select cproducto,cnamefc AS cnamef,cantcont2_u1,cantcont2_u2,cimpr_u2,cconteo2,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _P_Str_Numero + "' and cnousada='0'"; }
            else if (_Cmb_Conteo.SelectedIndex == 2)
            { _Str_Cadena = "Select cproducto,cnamefc AS cnamef,cantcont3_u1,cantcont3_u2,cimpr_u2,cconteo3,cidproductod,dbo.Fnc_Formatear(cprecioventamax) AS cprecioventamax from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and (cdiferencaj>0 or cdiferenunid>0) and id_tarjetainv='" + _P_Str_Numero + "' and cnousada='0'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][5].ToString().Trim() == "1" & !_Bol_Contex)
                {
                    MessageBox.Show("Esta tarjeta ya fue cargada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Seleccionar(_P_Str_Numero);
                    _Txt_Tarjeta.Text = "";
                }
                else
                {
                    _Txt_Producto.Text = _Ds.Tables[0].Rows[0]["cproducto"].ToString().Trim();
                    _Txt_Descripcion.Text = _Ds.Tables[0].Rows[0]["cnamef"].ToString().Trim();
                    _Lbl_Lote.Text = _Ds.Tables[0].Rows[0]["cidproductod"].ToString().Trim();
                    _Lbl_PMV.Text = _Ds.Tables[0].Rows[0]["cprecioventamax"].ToString().Trim();
                    _Txt_Cajas.Text = _Ds.Tables[0].Rows[0][2].ToString().Trim();
                    if (_Ds.Tables[0].Rows[0]["cimpr_u2"].ToString().Trim() == "1")
                    { _Txt_Unidades.Enabled = true; }
                    else
                    { _Txt_Unidades.Enabled = false; }
                    _Txt_Unidades.Text = _Ds.Tables[0].Rows[0][3].ToString().Trim();
                    _Txt_Cajas.Enabled = true;
                    _Txt_Cajas.Focus();
                    _Txt_Tarjeta.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Numero de tarjeta invalido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Txt_Producto.Text = "";
                _Lbl_Lote.Text = "";
                _Lbl_PMV.Text = "";
                _Txt_Descripcion.Text = "";
                _Txt_Cajas.Enabled = false;
                _Txt_Unidades.Enabled = false;
                _Txt_Tarjeta.Text = "";
                _Txt_Tarjeta.Focus();
            }
        }
        bool _Bol_ValidacionesVerificadas = false;
        private bool _Mtd_SePuedeIniciarConteo()
        {
            if (!_Bol_ValidacionesVerificadas)
            {
                string _Str_Cadena = "Select ccompany from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede iniciar el conteo porque existen ajustes de entrada por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                _Str_Cadena = "Select ccompany from TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador2,0)=0 AND ISNULL(cajusteintegrado,0)='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede iniciar el conteo porque existen ajustes de salida por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                _Str_Cadena = "SELECT ccompany FROM TAJUSTEINTEGRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canulado='0' AND ISNULL(cfuseraprobador2,0)=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede iniciar el conteo porque existen ajustes integrados por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                _Str_Cadena = "SELECT ccompany FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=1 AND cdelete=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede iniciar el conteo porque existen facturas anuladas por aprobar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                _Str_Cadena = "SELECT ccompany FROM TFACTURANUL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=0 AND cestatusfirma=2 AND cdelete=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede iniciar el conteo porque existen facturas pendientes por anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                _Bol_ValidacionesVerificadas = true;
            }
            return true;
        }
        private void _Mtd_Update()
        {
            if (!_Mtd_SePuedeIniciarConteo())
            {
                this.Close();
                return;
            }
            int _Int_Cajas = 0;
            int _Int_Unidades = 0;
            if (_Txt_Cajas.Text.TrimEnd() != "")
            {
                _Int_Cajas = Convert.ToInt32(_Txt_Cajas.Text);
            }
            if (_Txt_Unidades.Text.TrimEnd() != "")
            {
                _Int_Unidades = Convert.ToInt32(_Txt_Unidades.Text);
            }
            if (_Int_Cajas >= 0 || _Int_Unidades >= 0)
            {
                bool _Bol_Next = false;
                if (_Txt_Cajas.Text.Trim().Length == 0)
                { _Txt_Cajas.Text = "0"; }
                if (_Txt_Unidades.Text.Trim().Length == 0)
                { _Txt_Unidades.Text = "0"; }

                int _Int_ccontenidoma2 = 0, _Int_Undidades = 0;
                string _Str_Sql = "SELECT ccontenidoma2,ccontenidoma1,cunidad2 from TPRODUCTO WHERE cproducto='" + _Txt_Producto.Text.Trim() + "'";//AND cunidad2='1'
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma2"]).Length > 0)
                    {
                        if (Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                        {
                            _Int_ccontenidoma2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]) / Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                        }
                        else
                        {
                            _Int_ccontenidoma2 = Convert.ToInt32(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                        }
                    }
                    _Int_Undidades = Convert.ToInt32(_Txt_Unidades.Text);
                    if (_Int_Undidades > _Int_ccontenidoma2)
                    {
                        _Bol_Next = false;
                    }
                    else
                    {
                        _Bol_Next = true;
                    }
                }
                if (_Bol_Next)
                {
                    string _Str_Cadena = "";
                    if (_Cmb_Conteo.SelectedIndex == 0)
                    { _Str_Cadena = "Update TINVFISICOD set cantcont1_u1='" + _Txt_Cajas.Text.Trim() + "',cantcont1_u2='" + _Txt_Unidades.Text.Trim() + "',cconteo1='1' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Txt_Tarjeta.Text.Trim() + "'"; }
                    else if (_Cmb_Conteo.SelectedIndex == 1)
                    { _Str_Cadena = "Update TINVFISICOD set cantcont2_u1='" + _Txt_Cajas.Text.Trim() + "',cantcont2_u2='" + _Txt_Unidades.Text.Trim() + "',cconteo2='1' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Txt_Tarjeta.Text.Trim() + "'"; }
                    else if (_Cmb_Conteo.SelectedIndex == 2)
                    { _Str_Cadena = "Update TINVFISICOD set cantcont3_u1='" + _Txt_Cajas.Text.Trim() + "',cantcont3_u2='" + _Txt_Unidades.Text.Trim() + "',cconteo3='1' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Txt_Tarjeta.Text.Trim() + "'"; }
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_Conteo(Convert.ToInt32(_Cmb_Conteo.SelectedIndex.ToString()));
                    _Txt_Tarjeta.Text = "";
                    _Txt_Cajas.Text = "";
                    _Txt_Unidades.Text = "";
                    _Txt_Producto.Text = "";
                    _Lbl_Lote.Text = "";
                    _Lbl_PMV.Text = "";
                    _Txt_Descripcion.Text = "";
                    _Txt_Tarjeta.Enabled = true;
                    _Txt_Tarjeta.Focus();
                    _Txt_Cajas.Enabled = false;
                    _Txt_Unidades.Enabled = false;
                    _Mtd_Progress();
                    _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0'";
                    int _Int_N1 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
                    _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' and cantcont1_u1=cantcont2_u1 and cantcont1_u2=cantcont2_u2 and cconteo1='1' and cconteo2='1'";
                    int _Int_N2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
                    _Str_Cadena = "Update TINVFISICOM set ciniciado='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    if (_Lbl_P1.Text.Trim().Length == 5 & _Lbl_P2.Text.Trim().Length == 5 & _Int_N1 == _Int_N2)
                    {
                        _Bt_Verificacion.Enabled = false;
                        _Mtd_Inicializar();
                        _Str_Cadena = "Update TINVFISICOM set ccuadrado='1' where ccompany='" + Frm_Padre._Str_Comp + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El conteo ha cuadrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se puede cargar tarjetas sin cajas y sin unidades", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Frm_ConteoInventario_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Conteo.Left = (this.Width / 2) - (_Pnl_Conteo.Width / 2);
            _Pnl_Conteo.Top = (this.Height / 2) - (_Pnl_Conteo.Height / 2);
            _Pnl_Informacion.Left = (this.Width / 2) - (_Pnl_Informacion.Width / 2);
            _Pnl_Informacion.Top = (this.Height / 2) - (_Pnl_Informacion.Height / 2);
            _Pnl_Adicional.Left = (this.Width / 2) - (_Pnl_Adicional.Width / 2);
            _Pnl_Adicional.Top = (this.Height / 2) - (_Pnl_Adicional.Height / 2);
            ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Frm_Conteo = this;
            ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Bol_Inventario = true;
        }
        public bool _Mtd_Progress()
        {
            string _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0'";// and cconteo1='1' order by id_tarjetainv";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            bool _Bol_Iniciado = false;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Prb_Progreso1.Maximum = _Ds.Tables[0].Rows.Count;
                _Prb_Progreso2.Maximum = _Ds.Tables[0].Rows.Count;
                _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' and (cdiferencaj>0 or cdiferenunid>0)";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Prb_Progreso3.Maximum = _Ds.Tables[0].Rows.Count;
                _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' and cconteo1='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Prb_Progreso1.Value = _Ds.Tables[0].Rows.Count;
                _Lbl_P1.Text = Convert.ToString(((_Ds.Tables[0].Rows.Count * 100) / _Prb_Progreso1.Maximum)) + " %";
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Bol_Iniciado = true; }
                _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' and cconteo2='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Prb_Progreso2.Value = _Ds.Tables[0].Rows.Count;
                _Lbl_P2.Text = Convert.ToString(((_Ds.Tables[0].Rows.Count * 100) / _Prb_Progreso2.Maximum)) + " %";
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Bol_Iniciado = true; }
                _Str_Cadena = "Select * from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0' and cconteo3='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > _Prb_Progreso3.Maximum)
                { 
                    _Prb_Progreso3.Value = _Prb_Progreso3.Maximum;
                    _Lbl_P3.Text = "100 %";
                }
                else
                {
                    _Prb_Progreso3.Value = _Ds.Tables[0].Rows.Count;
                    if (_Prb_Progreso3.Maximum != 0)
                    {
                        _Lbl_P3.Text = Convert.ToString(((_Ds.Tables[0].Rows.Count * 100) / _Prb_Progreso3.Maximum)) + " %";
                    }
                }
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Bol_Iniciado = true; }
            }
            if (!_Bol_Conteo3)
            {
                if (_Lbl_P1.Text.Trim().Length == 5 & _Lbl_P2.Text.Trim().Length == 5)
                { _Bt_Verificacion.Enabled = (_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_VERIFICA_CONTEO")); }
            }
            else
            {
                if (_Lbl_P3.Text.Trim().Length == 5)
                { _Bt_Verificacion.Enabled = (_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_VERIFICA_CONTEO")); }
                if (_Prb_Progreso3.Maximum == 0)
                {
                    _Mtd_Inicializar();
                    if (this.MdiParent != null)
                    {
                        ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Bol_Inventario = false;
                        ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Frm_Conteo = null;
                    }
                }
            }
            return _Bol_Iniciado;
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Pnl_Clave.BringToFront();
                _Pnl_Panel1.Enabled = false;
                _Pnl_Panel2.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Pnl_Panel1.Enabled = true;
                _Pnl_Panel2.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }
        private void _Mtd_Ajustar(string _Str_HistoricoAjuste)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int _Int_ConteoHist = Convert.ToInt32(_Str_HistoricoAjuste);
                SqlParameter[] _Sql_Parametros = new SqlParameter[2];
                _Sql_Parametros[0] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _Sql_Parametros[0].Value = Frm_Padre._Str_Comp;
                _Sql_Parametros[1] = new SqlParameter("@id_conteohist", SqlDbType.Real);
                _Sql_Parametros[1].Value = _Int_ConteoHist;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_AJUSTEPORCONTEOHISTORICO", _Sql_Parametros);
                string _Str_SentenciaSQL = "update TINVFISICOHISTM set cfinalizado='3' where ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Str_HistoricoAjuste + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                string _Str_Cadena = "Delete from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Delete from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                if (this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                MessageBox.Show("El inventario se ha cerrado correctamente ya que no existe diferencias entre el físico y el teórico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hubo un error de tipo " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            CLASES._Cls_Varios_Metodos _Cls_Varios=new T3.CLASES._Cls_Varios_Metodos(true);
            if (_Int_Sw == 3)
            {
                if (_Cls_Varios._Mtd_VerificarClaveUsuarioFirma(_Txt_Clave.Text, "F_CONTEOINVTARJ_INV"))
                {
                    if (MessageBox.Show("¿Está seguro de deshabilitar la tarjeta N° " + _Dg_Grid[0, _Dg_Grid.CurrentCell.RowIndex].Value.ToString() + " ?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string _Str_Tarjeta = Convert.ToString(_Dg_Grid[0, _Dg_Grid.CurrentCell.RowIndex].Value).Trim();
                        string _Str_SentenciaSQL = "update TINVFISICOD SET cnousada='1',cconteo3='0',cantcont3_u1='0',cantcont3_u2='0',cantcont1_u1='0',cantcont1_u2='0',cantcont2_u1='0',cantcont2_u2='0' WHERE ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Str_Tarjeta + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                        _Mtd_Conteo(Convert.ToInt32(_Cmb_Conteo.SelectedIndex.ToString()));
                        _Pnl_Clave.Visible = false;
                        _Btn_Desmarcar.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
                }
            }
            else
            {
                _Mtd_Acceso();
            }
        }

        private void _Pnl_Conteo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Conteo.Visible)
            {
                _Pnl_Conteo.BringToFront();
                _Pnl_Panel1.Enabled = false;
                _Pnl_Panel2.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Grb_1.Enabled = false;
                _Txt_Tarjeta.Text = "";
                _Txt_Producto.Text = "";
                _Lbl_Lote.Text = "";
                _Lbl_PMV.Text = "";
                _Txt_Descripcion.Text = "";
                //_Txt_Conteo.Text = "";
                _Txt_Cajas.Text = "";
                _Txt_Unidades.Text = "";
            }
            else
            {
                if (_Txt_Conteo.Text != "")
                {
                    _Grb_1.Enabled = true;
                    try
                    {
                        _Cmb_Conteo.SelectedIndex = _G_Int_Conteo;
                    }
                    catch
                    {
                    }
                }
                _Pnl_Panel1.Enabled = true;
                _Pnl_Panel2.Enabled = true;
                _Dg_Grid.Enabled = true;
                _Txt_Tarjeta.Enabled = true;
            }
        }
        int _G_Int_Conteo = 0;
        private void _Bt_Elegir_Click(object sender, EventArgs e)
        {
            _Mtd_Progress();
            _Pnl_Conteo.Visible = true;
            _Bt_Aceptar.Enabled = true;
            _Bt_Cancelar.Enabled = true;
            _G_Int_Conteo = _Cmb_Conteo.SelectedIndex;
            _Cmb_Conteo.SelectedIndex = -1;
            _Cmb_Conteo.Focus();
        }
        private void _Cmb_Conteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!_Bol_Conteo3)
            {
                if (_Cmb_Conteo.SelectedIndex == 2)
                { MessageBox.Show("No puede elegir el 3er conteo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop); _Cmb_Conteo.SelectedIndex = -1; }
                else if (_Cmb_Conteo.SelectedIndex != -1)
                {
                    _G_Int_Conteo = _Cmb_Conteo.SelectedIndex;
                    _Mtd_Conteo(Convert.ToInt32(_Cmb_Conteo.SelectedIndex.ToString()));
                    _Txt_Conteo.Text = _Cmb_Conteo.SelectedItem.ToString();
                    _Pnl_Conteo.Visible = false;
                    _Grb_1.Enabled = true;
                    _Bt_Aceptar_Arriba.Enabled = true;
                    _Bt_Cancelar_Arriba.Enabled = true;
                    _Txt_Tarjeta.Focus();
                }
            }
            else
            {
                if (_Cmb_Conteo.SelectedIndex == 0 | _Cmb_Conteo.SelectedIndex == 1)
                { MessageBox.Show("Solo podrá elegir el 3er conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop); _Cmb_Conteo.SelectedIndex = -1; }
                else if (_Cmb_Conteo.SelectedIndex != -1)
                {
                    _G_Int_Conteo = _Cmb_Conteo.SelectedIndex;
                    _Mtd_Conteo(Convert.ToInt32(_Cmb_Conteo.SelectedIndex.ToString()));
                    _Txt_Conteo.Text = _Cmb_Conteo.SelectedItem.ToString();
                    _Pnl_Conteo.Visible = false;
                    _Grb_1.Enabled = true;
                    _Bt_Aceptar_Arriba.Enabled = true;
                    _Bt_Cancelar_Arriba.Enabled = true;
                    _Txt_Tarjeta.Focus();
                }
            }
            Cursor = Cursors.Default;
        }

        private void _Txt_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {_Mtd_Acceso();}
        }

        private void _Bt_Cancelar_Conteo_Click(object sender, EventArgs e)
        {
            _Pnl_Conteo.Visible = false;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Txt_Tarjeta.Text.Trim().Length > 0)
            {
                _Bol_Contex = false;
                _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
            }
        }

        private void _Txt_Tarjeta_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Tarjeta.Text))
            {
                _Txt_Tarjeta.Text = "";
            }
        }

        private void _Txt_Cajas_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Cajas.Text))
            {
                _Txt_Cajas.Text = "";
            }
            else
            {
                int _Int_Temp = 0;
                if (!int.TryParse(_Txt_Cajas.Text, out _Int_Temp) || _Int_Temp < 0)
                {
                    _Txt_Cajas.Text = "";
                }
            }
        }

        private void _Txt_Unidades_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Unidades.Text))
            {
                _Txt_Unidades.Text = "";
            }
            else
            {
                int _Int_Temp = 0;
                if (!int.TryParse(_Txt_Unidades.Text, out _Int_Temp) || _Int_Temp < 0)
                {
                    _Txt_Unidades.Text = "";
                }
            }
        }

        private void _Txt_Cajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    string _Str_Cadena = "Select cimpr_u2 from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='"+_Txt_Tarjeta.Text.Trim()+"'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                        {
                            _Txt_Cajas.Enabled = false;
                            _Txt_Unidades.Enabled = true;
                            _Txt_Unidades.Focus();
                        }
                        else
                        {
                            _Txt_Cajas.Enabled = false;
                            _Mtd_Update();
                        }
                    }
                }
            }
        }

        private void _Txt_Unidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    if (_Txt_Producto.Text.Trim().Length > 0)
                    {
                        if (_Txt_Unidades.Text.Trim().Length > 0)
                        {
                            int _Int_Dbunidades = Convert.ToInt32(_MyUtilidad._Mtd_ProductoUndManejo2(_Txt_Producto.Text.Trim()));
                            int _Int_Undidades = Convert.ToInt32(_Txt_Unidades.Text);
                            if (_Int_Undidades >= _Int_Dbunidades)
                            {
                                MessageBox.Show("La cantidad de unidades debe ser inferior a " + _Int_Dbunidades.ToString() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _Txt_Unidades.Text="0";
                            }
                            else
                            {
                                _Mtd_Update();
                            }
                        }
                    }                    
                }
            }
        }

        private void _Txt_Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    if (_Txt_Tarjeta.Text.Trim().Length > 0)
                    {
                        _Bol_Contex = false;
                        _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
                    }
                }
            }
        }

        private void _Bt_Aceptar_Arriba_Click(object sender, EventArgs e)
        {
            if (_Txt_Producto.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Update();
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Faltan datos para realizar esta operacón", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Cancelar_Arriba_Click(object sender, EventArgs e)
        {
            _Txt_Tarjeta.Text = "";
            _Txt_Cajas.Text = "";
            _Txt_Unidades.Text = "";
            _Txt_Producto.Text = "";
            _Lbl_Lote.Text = "";
            _Lbl_PMV.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Tarjeta.Enabled = true;
            _Txt_Tarjeta.Focus();
            _Txt_Cajas.Enabled = false;
            _Txt_Unidades.Enabled = false;
        }

        private void _Pnl_Informacion_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Informacion.Visible)
            {
                _Pnl_Informacion.BringToFront();
                _Pnl_Panel1.Enabled = false;
                _Pnl_Panel2.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Grb_1.Enabled = false;
            }
        }

        private void _Bt_Si_Click(object sender, EventArgs e)
        {
            _Pnl_Informacion.Visible = false;
            _Pnl_Conteo.Visible = true;
            _Bt_Aceptar.Enabled = true;
            _Bt_Cancelar.Enabled = true;
            _Cmb_Conteo.SelectedIndex = -1;
            _Cmb_Conteo.Focus();
        }

        private void _Bt_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT id_conteohist FROM TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY id_conteohist  DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void _Mtd_Finalizar()
        {
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM TINVFISICOHISTM WHERE cfinalizado<>'3' AND ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows.Count > 0)
            {
                int _Int_Numero = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT id_conteohist FROM TINVFISICOHISTM WHERE cfinalizado<>'3' AND ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString());
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("¿Desea imprimir el reporte comparativo?", "Infomación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                _Go_Print:
                    PrintDialog _Print = new PrintDialog();
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICOREPORTE" }, "", "T3.Report.rComparativo", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'", _Print, true);
                        if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            _Frm_R.Close();
                            _Frm_R.Dispose();
                            goto _Go_Print;
                        }
                    }
                }
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                this.Close();
            }
            else
            {
                int _Int_Numero = _Mtd_Entrada();
                string _Str_Cadena = "Select cdate from TINVFISICOM where ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    DataRow _Rows = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                    _Str_Cadena = "insert into TINVFISICOHISTM (ccompany,id_conteohist,cdate,cfinalizado) values ('" + Frm_Padre._Str_Comp + "','" + _Int_Numero + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Rows[0].ToString())) + "','1')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TINVFISICOHISTD(ccompany,id_conteohist,id_tarjetainv,cproveedor,csubgrupo,cgrupo,csku,cproducto,cdate,cyearacco,cmontacco,cimpr_u2,cantcont1_u1,cantcont1_u2,cconteo1,cantcont2_u1,cantcont2_u2,cconteo2,cdiferencaj,cdiferenunid,cantcont3_u1,cantcont3_u2,cconteo3,cidproductod) Select '" + Frm_Padre._Str_Comp + "','" + _Int_Numero.ToString() + "',id_tarjetainv,cproveedor,csubgrupo,cgrupo,csku,cproducto,cdate,cyearacco,cmontacco,cimpr_u2,cantcont1_u1,cantcont1_u2,cconteo1,cantcont2_u1,cantcont2_u2,cconteo2,cdiferencaj,cdiferenunid,cantcont3_u1,cantcont3_u2,cconteo3,cidproductod from TINVFISICOD where ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //-------------------------------------------------------------------------
                    _Mtd_Crear_TINVFISICOTEOHIST(_Int_Numero);
                    //-------------------------------------------------------------------------
                    _Pnl_Clave.Visible = false;
                    _Str_Cadena = "SELECT ccompany FROM VST_INVENTARIOFISICOREPORTE WHERE ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("¿Desea imprimir el reporte comparativo?", "Infomación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                        _Go_Print:
                            PrintDialog _Print = new PrintDialog();
                            if (_Print.ShowDialog() == DialogResult.OK)
                            {
                                REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICOREPORTE" }, "", "T3.Report.rComparativo", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and id_conteohist='" + _Int_Numero.ToString() + "'", _Print, true);
                                if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                {
                                    _Frm_R.Close();
                                    _Frm_R.Dispose();
                                    goto _Go_Print;
                                }
                            }
                        }
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        this.Close();
                    }
                    else
                    {
                        _Mtd_Ajustar(_Int_Numero.ToString());
                    }
                }
            }
        }
        int _Int_Cajas = 0;
        int _Int_Unidades = 0;
        private void _Mtd_Extraer_Cajas_Unidades(int _P_Int_Cantidad,int _P_Int_Unidad)
        {
            int _Int_Contador = 0;
            _Int_Cajas = 0;
            _Int_Unidades = 0;
            for (int _Int_I = 1; _Int_I <= _P_Int_Cantidad; _Int_I++)
            {
                _Int_Contador++;
                if (_Int_Contador == _P_Int_Unidad)
                {
                    _Int_Cajas++;
                    _Int_Contador = 0;
                    if (_Int_I + _P_Int_Unidad > _P_Int_Cantidad)
                    {
                        _Int_Unidades = _P_Int_Cantidad - _Int_I;
                    }
                }
            }
         }
        private bool _Mtd_Diferencias()
        {
            bool _Bol_Diferencias = false;
            string _Str_Cadena = "Select id_tarjetainv,cantcont1_u1,cantcont1_u2,cantcont2_u1,cantcont2_u2,ccontenidoma1,cimpr_u2,cproducto from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "' and cnousada='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    int _Int_Cajas1 = 0;
                    int _Int_Cajas2 = 0;
                    int _Int_Unidad1 = 0;
                    int _Int_Unidad2 = 0;
                    double _Dbl_DiferenciaEnUnidades = 0;
                    int _Int_UnidadesPorCaja = 0;
                    int _Int_TotalUnidadesPorProducto1 = 0;
                    int _Int_CajasDif = 0;
                    int _Int_UndDif = 0;
                    int _Int_TotalUnidadesPorProducto2 = 0;
                    int _Int_TotalCajas = 0;
                    int _Int_TotalUnidades = 0;
                    if (_Row["cantcont1_u1"] != System.DBNull.Value)
                    { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont1_u1"].ToString()); }
                    if (_Row["cantcont1_u2"] != System.DBNull.Value)
                    { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont1_u2"].ToString()); }
                    if (_Row["cantcont2_u1"] != System.DBNull.Value)
                    { _Int_Cajas2 = Convert.ToInt32(_Row["cantcont2_u1"].ToString()); }
                    if (_Row["cantcont2_u2"] != System.DBNull.Value)
                    { _Int_Unidad2 = Convert.ToInt32(_Row["cantcont2_u2"].ToString()); }
                    if (_Row["ccontenidoma1"] != System.DBNull.Value)
                    { _Int_UnidadesPorCaja = Convert.ToInt32(_Row["ccontenidoma1"].ToString()); }
                    if (_Row["cimpr_u2"].ToString().Trim() == "1")
                    {
                        //_Int_TotalUnidadesPorProducto1 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(),_Int_Cajas1,_Int_Unidad1));
                        //_Int_TotalUnidadesPorProducto2 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas2, _Int_Unidad2));
                        if (_Int_Cajas1 > _Int_Cajas2)
                        {
                            _Int_CajasDif = _Int_Cajas1 - _Int_Cajas2;
                        }
                        else
                        {
                            _Int_CajasDif = _Int_Cajas2 - _Int_Cajas1;
                        }
                        if (_Int_Unidad1 > _Int_Unidad2)
                        {
                            _Int_UndDif = _Int_Unidad1 - _Int_Unidad2;
                        }
                        else
                        {
                            _Int_UndDif = _Int_Unidad2 - _Int_Unidad1;
                        }
                        //if (_Int_TotalUnidadesPorProducto1 > _Int_TotalUnidadesPorProducto2)
                        //{ _Dbl_DiferenciaEnUnidades =Convert.ToDouble(_Int_TotalUnidadesPorProducto1 - _Int_TotalUnidadesPorProducto2); }
                        //else if (_Int_TotalUnidadesPorProducto1 < _Int_TotalUnidadesPorProducto2)
                        //{ _Dbl_DiferenciaEnUnidades = Convert.ToDouble(_Int_TotalUnidadesPorProducto2 - _Int_TotalUnidadesPorProducto1); }
                        //_Mtd_Extraer_Cajas_Unidades(Convert.ToInt32(_Dbl_DiferenciaEnUnidades), _Int_UnidadesPorCaja);
                        _Int_TotalCajas = _Int_CajasDif; //Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                        _Int_TotalUnidades = _Int_UndDif; //Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades)));
                        //_Int_TotalCajas = _Int_Cajas;
                        //_Int_TotalUnidades = _Int_Unidades;
                        if (_Int_CajasDif > 0 || _Int_UndDif > 0)
                        {
                            _Bol_Diferencias = true;                                                                                //_Int_TotalUnidades
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='" + _Int_TotalCajas.ToString() + "',cdiferenunid='" + _Int_TotalUnidades.ToString() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='0',cdiferenunid='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        if (_Int_Cajas1 > _Int_Cajas2)
                        { _Int_TotalCajas = _Int_Cajas1 - _Int_Cajas2; }
                        else if (_Int_Cajas1 < _Int_Cajas2)
                        { _Int_TotalCajas = _Int_Cajas2 - _Int_Cajas1; }
                        if (_Int_TotalCajas > 0)
                        {
                            _Bol_Diferencias = true;
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='" + _Int_TotalCajas.ToString() + "',cdiferenunid='" + _Int_TotalUnidades.ToString() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        else
                        {
                            _Str_Cadena = "Update TINVFISICOD set cdiferencaj='0',cdiferenunid='0' where ccompany='" + Frm_Padre._Str_Comp + "' and id_tarjetainv='" + _Row["id_tarjetainv"].ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
                _Pnl_Clave.Visible = false;
            }
            return _Bol_Diferencias;
        }
        private void _Mtd_Crear_TINVFISICOTEOHIST(int _P_Int_id_conteohist)
        {
            string _Str_Cadena = "Select id_tarjetainv,cantcont1_u1,cantcont1_u2,ccontenidoma1,ccontenidoma2,cunidad2,cimpr_u2,cexisrealu1,cexisrealu2,ccostoneto_u1,ccostoneto_u2,cproducto,cantcont3_u1,cantcont3_u2,cconteo3 from VST_INVENTARIOFISICO where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    bool _Bol_3erConteo = false;
                    if (_Row["cconteo3"].ToString() == "1")
                    {
                        _Bol_3erConteo = true;
                    }
                    else
                    {
                        _Bol_3erConteo = false;
                    }
                    string _Str_AjustEntr = "0";
                    string _Str_AjustSal = "0";
                    int _Int_Cajas1 = 0;
                    int _Int_Unidad1 = 0;
                    int _Int_Cajas2 = 0;
                    int _Int_Unidad2 = 0;
                    double _Dbl_DiferenciaEnUnidades = 0;
                    double _Dbl_Costo_Unidades = 0;
                    double _Dbl_Costo_Cajas = 0;
                    double _Dbl_Costo_Total = 0;
                    int _Int_UnidadesPorCaja = 0;
                    int _Int_TotalUnidadesPorProducto1 = 0;
                    int _Int_TotalUnidadesPorProducto2 = 0;
                    int _Int_TotalCajas = 0;
                    int _Int_TotalUnidades = 0;
                    if (_Bol_3erConteo)
                    {
                        if (_Row["cantcont3_u1"] != System.DBNull.Value)
                        { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont3_u1"].ToString()); }
                    }
                    else
                    {
                        if (_Row["cantcont1_u1"] != System.DBNull.Value)
                        { _Int_Cajas1 = Convert.ToInt32(_Row["cantcont1_u1"].ToString()); }
                    }
                    if (_Bol_3erConteo)
                    {
                        if (_Row["cantcont3_u2"] != System.DBNull.Value)
                        { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont3_u2"].ToString()); }
                    }
                    else
                    {
                        if (_Row["cantcont1_u2"] != System.DBNull.Value)
                        { _Int_Unidad1 = Convert.ToInt32(_Row["cantcont1_u2"].ToString()); }
                    }
                    if (_Row["cexisrealu1"] != System.DBNull.Value)
                    { _Int_Cajas2 = Convert.ToInt32(_Row["cexisrealu1"].ToString()); }
                    if (_Row["cexisrealu2"] != System.DBNull.Value)
                    { _Int_Unidad2 = Convert.ToInt32(_Row["cexisrealu2"].ToString()); }
                    if (_Row["ccontenidoma1"] != System.DBNull.Value)
                    { _Int_UnidadesPorCaja = Convert.ToInt32(_Row["ccontenidoma1"].ToString()); }
                    if (_Row["ccostoneto_u1"] != System.DBNull.Value)
                    { _Dbl_Costo_Cajas = Convert.ToDouble(_Row["ccostoneto_u1"].ToString()); }
                    if (_Row["cunidad2"] != System.DBNull.Value)
                    {
                        if (_Row["cunidad2"].ToString().TrimEnd() == "1")
                        {
                            if (_Row["ccontenidoma2"].ToString().TrimEnd() != "")
                            {
                                if (_Row["ccontenidoma2"].ToString().TrimEnd() != "0")
                                {
                                    if (Convert.ToInt32(_Row["ccontenidoma2"].ToString().TrimEnd()) > 0)
                                    {
                                        _Dbl_Costo_Unidades = _Dbl_Costo_Cajas / (Convert.ToInt32(_Row["ccontenidoma1"].ToString().TrimEnd()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString().TrimEnd()));
                                    }
                                }
                            }
                        }
                        else
                        {
                            _Dbl_Costo_Unidades = 0;
                        }
                    }
                    if (_Row["cimpr_u2"].ToString().Trim() == "1")
                    {
                        _Int_TotalUnidadesPorProducto1 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas1, _Int_Unidad1));
                        _Int_TotalUnidadesPorProducto2 = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_Row["cproducto"].ToString().TrimEnd(), _Int_Cajas2, _Int_Unidad2));
                        //_Int_TotalUnidadesPorProducto1 = (_Int_Cajas1 * _Int_UnidadesPorCaja) + _Int_Unidad1;
                        //_Int_TotalUnidadesPorProducto2 = (_Int_Cajas2 * _Int_UnidadesPorCaja) + _Int_Unidad2;
                        if (_Int_TotalUnidadesPorProducto2 > _Int_TotalUnidadesPorProducto1)
                        {
                            _Str_AjustSal = "1";
                            _Str_AjustEntr = "0";
                            _Dbl_DiferenciaEnUnidades = (-1) * Convert.ToDouble(_Int_TotalUnidadesPorProducto2 - _Int_TotalUnidadesPorProducto1);
                        }
                        else
                        {
                            _Str_AjustEntr = "1";
                            _Str_AjustSal = "0";
                            _Dbl_DiferenciaEnUnidades = Convert.ToDouble(_Int_TotalUnidadesPorProducto1 - _Int_TotalUnidadesPorProducto2);
                        }
                        //_Mtd_Extraer_Cajas_Unidades(Convert.ToInt32(_Dbl_DiferenciaEnUnidades), _Int_UnidadesPorCaja);
                        if (_Dbl_Costo_Unidades > 0)
                        {
                            _Dbl_Costo_Total = _Dbl_DiferenciaEnUnidades * _Dbl_Costo_Unidades;
                        }
                        else
                        {
                            double _Dbl_DifCajas = 0;
                            _Dbl_DifCajas = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                            _Dbl_Costo_Total = _Dbl_DifCajas * _Dbl_Costo_Cajas;
                        }
                        if (_Dbl_DiferenciaEnUnidades < 0)
                        {
                            _Int_TotalCajas = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades * (-1)), 0));
                            _Int_TotalCajas = _Int_TotalCajas * (-1);
                        }
                        else
                        {
                            _Int_TotalCajas = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades), 0));
                        }
                        if (_Dbl_DiferenciaEnUnidades < 0)
                        {
                            _Int_TotalUnidades = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades * (-1))));
                            _Int_TotalUnidades = _Int_TotalUnidades * (-1);
                        }
                        else
                        {
                            _Int_TotalUnidades = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(_Row["cproducto"].ToString().TrimEnd(), Convert.ToInt32(_Dbl_DiferenciaEnUnidades)));
                        }
                        //_Int_TotalCajas = _Int_Cajas;
                        //_Int_TotalUnidades = _Int_Unidades;
                        if (_Dbl_DiferenciaEnUnidades != 0)
                        {
                            _Str_Cadena = "Insert into TINVFISICOTEOHIST (ccompany,id_conteohist,id_tarjetainv,cconteocajas,cconteounid,ccajas,cunidad,ccostonetocaj,ccostonetounid,cdifrenciacajas,cdifrenciaunid,ccostoinvent,cnecajussal,cnecajusent,cajustado) values ('" + Frm_Padre._Str_Comp + "','" + _P_Int_id_conteohist.ToString() + "','" + _Row["id_tarjetainv"].ToString().Trim() + "','" + _Int_Cajas1.ToString() + "','" + _Int_Unidad1.ToString() + "','" + _Int_Cajas2.ToString() + "','" + _Int_Unidad2 + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Cajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Unidades) + "','" + _Int_TotalCajas.ToString() + "','" + _Int_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Total) + "','" + _Str_AjustSal + "','" + _Str_AjustEntr + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    else
                    {
                        if (_Int_Cajas2 > _Int_Cajas1)
                        {
                            _Str_AjustSal = "1";
                            _Int_TotalCajas = (-1) * (_Int_Cajas2 - _Int_Cajas1);
                        }
                        else
                        {
                            _Str_AjustEntr = "1";
                            _Int_TotalCajas = _Int_Cajas1 - _Int_Cajas2;
                        }
                        _Dbl_Costo_Total = _Int_TotalCajas * _Dbl_Costo_Cajas;
                        if (_Int_TotalCajas != 0)
                        {
                            _Str_Cadena = "Insert into TINVFISICOTEOHIST (ccompany,id_conteohist,id_tarjetainv,cconteocajas,cconteounid,ccajas,cunidad,ccostonetocaj,ccostonetounid,cdifrenciacajas,cdifrenciaunid,ccostoinvent,cnecajussal,cnecajusent,cajustado) values ('" + Frm_Padre._Str_Comp + "','" + _P_Int_id_conteohist.ToString() + "','" + _Row["id_tarjetainv"].ToString().Trim() + "','" + _Int_Cajas1.ToString() + "','" + _Int_Unidad1.ToString() + "','" + _Int_Cajas2.ToString() + "','" + _Int_Unidad2 + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Cajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Unidades) + "','" + _Int_TotalCajas.ToString() + "','" + _Int_TotalUnidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Costo_Total) + "','" + _Str_AjustSal + "','" + _Str_AjustEntr + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
            }
        }
        private void _Bt_Finalizar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Text = "";
            _Txt_Clave.Focus();
            _Int_Sw = 1;
        }

        private void _Bt_Verificacion_Click(object sender, EventArgs e)
        {
            if (!_Bol_Conteo3)
            {
                if (_Mtd_Diferencias())
                {
                    Frm_VerificaConteo _Frm = new Frm_VerificaConteo(true, this);
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                }
                else
                {
                    MessageBox.Show("No hubo diferencias","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _Mtd_Inicializar();
                }
            }
            else
            {
                Frm_VerificaConteo _Frm = new Frm_VerificaConteo(this);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Dock = DockStyle.Fill;
                _Frm.Show();
            }
        }
       

        private void Frm_ConteoInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Bol_Inventario = false;
        }

        private void _Pnl_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editarTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Txt_Cajas.Text = "";
                _Txt_Unidades.Text = "";
                _Txt_Producto.Text = "";
                _Lbl_Lote.Text = "";
                _Lbl_PMV.Text = "";
                _Txt_Descripcion.Text = "";
                _Txt_Tarjeta.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Tarjeta.Enabled = true;
                _Txt_Tarjeta.Focus();
                _Txt_Cajas.Enabled = false;
                _Txt_Unidades.Enabled = false;
                _Bol_Contex = true;
                _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
            }
        }

        private void Frm_ConteoInventario_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
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

        private void _Txt_Unidades_Validating(object sender, CancelEventArgs e)
        {
            if (_Txt_Producto.Text.Trim().Length > 0)
            {
                if (_Txt_Unidades.Text.Trim().Length > 0)
                {
                    int _Int_Dbunidades = Convert.ToInt32(_MyUtilidad._Mtd_ProductoUndManejo2(_Txt_Producto.Text.Trim()));
                    int _Int_Undidades = Convert.ToInt32(_Txt_Unidades.Text);
                    if (_Int_Undidades >= _Int_Dbunidades)
                    {
                        MessageBox.Show("La cantidad de unidades debe ser inferior a " + _Int_Dbunidades.ToString() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void _Btn_Desmarcar_Click(object sender, EventArgs e)
        {
            Frm_VerificacionTarjetas _Frm = new Frm_VerificacionTarjetas(true);
            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
            this.Close();
        }

        private void inhabilitarTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void inhabilitarTarjetaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
                _Int_Sw = 3;
            }
        }

        private void _Bt_InfPrimerCont_Click(object sender, EventArgs e)
        {
            string _P_Str_Tarjeta = _Txt_Tarjeta.Text.Trim();
            Frm_TarjetasConteo _Frm_Tarjetas = new Frm_TarjetasConteo("1", _Txt_Tarjeta);
            _Frm_Tarjetas.ShowDialog(this);
            if (_Txt_Tarjeta.Text.Trim() != _P_Str_Tarjeta)
            {
                if (_Cmb_Conteo.SelectedIndex.ToString().Trim() == "0")
                {
                    if (_Txt_Tarjeta.Text.Trim().Length > 0 & _Txt_Tarjeta.Text.Trim() != _P_Str_Tarjeta)
                    {
                        _Bol_Contex = false;
                        _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
                    }
                }
                else
                {
                    _Txt_Tarjeta.Text = _P_Str_Tarjeta;
                    if (_Cmb_Conteo.SelectedIndex == -1)
                    { MessageBox.Show("No se puede realizar la operación. No se ha seleccionado ningún conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    { MessageBox.Show("No se puede realizar la operación. Se está trabajando con otro conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void _Bt_InfSegundoCont_Click(object sender, EventArgs e)
        {
            string _P_Str_Tarjeta = _Txt_Tarjeta.Text.Trim();
            Frm_TarjetasConteo _Frm_Tarjetas = new Frm_TarjetasConteo("2", _Txt_Tarjeta);
            _Frm_Tarjetas.ShowDialog(this);
            if (_Txt_Tarjeta.Text.Trim() != _P_Str_Tarjeta)
            {
                if (_Cmb_Conteo.SelectedIndex.ToString().Trim() == "1")
                {
                    if (_Txt_Tarjeta.Text.Trim().Length > 0 & _Txt_Tarjeta.Text.Trim() != _P_Str_Tarjeta)
                    {
                        _Bol_Contex = false;
                        _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
                    }
                }
                else
                {
                    _Txt_Tarjeta.Text = _P_Str_Tarjeta;
                    if (_Cmb_Conteo.SelectedIndex == -1)
                    { MessageBox.Show("No se puede realizar la operación. No se ha seleccionado ningún conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    { MessageBox.Show("No se puede realizar la operación. Se está trabajando con otro conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void _Btn_Inhabilitar_Click(object sender, EventArgs e)
        {
            Frm_VerificacionTarjetas _Frm = new Frm_VerificacionTarjetas(true, true);
            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
            this.Close();
        }

        private void _Bt_InfTercerCont_Click(object sender, EventArgs e)
        {
            string _P_Str_Tarjeta = _Txt_Tarjeta.Text.Trim();
            Frm_TarjetasConteo _Frm_Tarjetas = new Frm_TarjetasConteo("3", _Txt_Tarjeta);
            _Frm_Tarjetas.ShowDialog(this);
            if (_Txt_Tarjeta.Text.Trim() != _P_Str_Tarjeta)
            {
                if (_Cmb_Conteo.SelectedIndex.ToString().Trim() == "2")
                {
                    if (_Txt_Tarjeta.Text.Trim().Length > 0 & _Txt_Tarjeta.Text.Trim() != _P_Str_Tarjeta)
                    {
                        _Bol_Contex = false;
                        _Mtd_Buscar(_Txt_Tarjeta.Text.Trim());
                    }
                }
                else
                {
                    _Txt_Tarjeta.Text = _P_Str_Tarjeta;
                    if (_Cmb_Conteo.SelectedIndex == -1)
                    { MessageBox.Show("No se puede realizar la operación. No se ha seleccionado ningún conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    { MessageBox.Show("No se puede realizar la operación. Se está trabajando con otro conteo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void Frm_ConteoInventario_Shown(object sender, EventArgs e)
        {
            string _Str_Cadena = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND c_impresa='0' AND cpfactura<>'0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("No se puede realizar la operación, existen facturas pendientes por imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                _Str_Cadena = "Select cfinalizado from TINVFISICOHISTM where ccompany='" + Frm_Padre._Str_Comp + "' and (cfinalizado='2' or cfinalizado='1')";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Debe finalizar el conteo que esta en proceso actualmente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void _Bt_AgregarTar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_SelecProductos _Frm = new Frm_SelecProductos(2);
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog(this) == DialogResult.Yes)
            {
                string _Str_Cadena = "";
                Cursor = Cursors.WaitCursor;
                _Frm._Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["Select"].Value)).ToList().ForEach(Fila =>
                {
                    _Str_Cadena = "INSERT INTO TINVFISICOD (id_conteo,id_tarjetainv,cproveedor,cgrupo,csku,csubgrupo,cproducto,cdate,cyearacco,cmontacco,ccompany,cimpr_u2,cidproductod) SELECT DISTINCT '1',(SELECT ISNULL(MAX(id_tarjetainv),0)+1 FROM TINVFISICOD WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'),cproveedor,cgrupo,csku,csubgrupo,TPRODUCTO.cproducto,'" + _G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'," + Clases._Cls_ProcesosCont._Mtd_ContableAno(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "," + Clases._Cls_ProcesosCont._Mtd_ContableMes(_G_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + ",'" + Frm_Padre._Str_Comp + "',cunidad2,cidproductod FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTO.cproducto = TPRODUCTOD.cproducto WHERE TPRODUCTO.cproducto='" + Convert.ToString(Fila.Cells["Producto"].Value).Trim() + "' AND cidproductod='" + Convert.ToString(Fila.Cells["Lote"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                );
                _Mtd_Progress();
                Cursor = Cursors.Default;
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Pnl_Adicional_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Adicional.Visible)
            {
                _Pnl_Adicional.BringToFront();
                _Pnl_Panel1.Enabled = false;
                _Pnl_Panel2.Enabled = false;
                _Dg_Grid.Enabled = false;
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "SELECT id_tarjetainv FROM VST_INVENTARIOFISICO WHERE ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY id_tarjetainv DESC";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                Cursor = Cursors.Default;
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        int _Int_N = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString());
                        _Num_Desde.Minimum = 1;
                        _Num_Desde.Maximum = _Int_N;
                        _Num_Hasta.Maximum = _Int_N;
                        _Num_Desde.Value = 1;
                        _Num_Hasta.Value = _Int_N;
                    }
                }
            }
            else
            {
                _Pnl_Panel1.Enabled = true;
                _Pnl_Panel2.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }

        private void _Bt_Cancelar_Adicional_Click(object sender, EventArgs e)
        {
            _Pnl_Adicional.Visible = false;
        }

        private void _Bt_Aceptar_Adicional_Click(object sender, EventArgs e)
        {
            try
            {
                _Pnl_Adicional.Visible = false;
                Cursor = Cursors.WaitCursor;
                Frm_Inf_Varios _Frm = new Frm_Inf_Varios(9, _Num_Desde.Value.ToString(), _Num_Hasta.Value.ToString());
                Cursor = Cursors.Default;
                _Frm.Size = this.Size;
                _Frm.ShowDialog(this);
                if (MessageBox.Show("¿Las tarjetas fueron impresas correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("A continuación el reporte de verificación de tarjetas emitidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.WaitCursor;
                _Lbl_Reiprimir:
                    PrintDialog _Print = new PrintDialog();
                    Cursor = Cursors.Default;
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rVerificacionTar", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "'", _Print, true);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        { goto _Lbl_Reiprimir; }
                    }
                }
                else
                { _Pnl_Adicional.Visible = true; }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("No se pudo conectar con la impresora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); _Pnl_Adicional.Visible = true; Cursor = Cursors.Default; }
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea imprimir la tarjetas?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { _Pnl_Adicional.Visible = true; }
            else
            {
                MessageBox.Show("A continuación el reporte de verificación de tarjetas emitidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.WaitCursor;
            _Lbl_Reiprimir:
                PrintDialog _Print = new PrintDialog();
                Cursor = Cursors.Default;
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm_R = new REPORTESS(new string[] { "VST_INVENTARIOFISICO" }, "", "T3.Report.rVerificacionTar", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿El reporte fue impreso correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    { goto _Lbl_Reiprimir; }
                }
            }
        }
    }
}