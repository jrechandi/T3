using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Clientes_VC_DireccionD : Form
    {
        public Frm_Clientes_VC_DireccionD()
        {
            InitializeComponent();
            _Mtd_Cargar_Estado();
            if (!_G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_DIR_DESPA_CLIENT"))
            {
                _Bt_TabDel.Enabled = false;
                _Bt_TabNuevo.Enabled = false;
                _Bt_Edit.Enabled = false;
                _Bt_Guardar.Enabled = false;
            }
        }
        public Frm_Clientes_VC_DireccionD(string _P_Str_Cliente)
        {
            InitializeComponent();
            _Str_Cliente = _P_Str_Cliente;
            _Mtd_CargarDirecciones(_Str_Cliente);
            _Mtd_Cargar_Estado();
            if (!_G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_DIR_DESPA_CLIENT"))
            {
                _Bt_TabDel.Enabled = false;
                _Bt_TabNuevo.Enabled = false;
                _Bt_Edit.Enabled = false;
                _Bt_Guardar.Enabled = false;
            }
        }
        private void Frm_Clientes_VC_DireccionD_Load(object sender, EventArgs e)
        {

        }
        string _Str_Cliente;
        string _Str_SentenciaSQL;
        DataSet _DS_DataSet = new DataSet();
        private void _Mtd_CargarDirecciones(string _P_Str_Cliente)
        {
            _Str_SentenciaSQL = "select c_direcc_despa,rtrim(c_direcc_descrip)+' - '+convert(varchar,cnamee)+ ' - '+convert(varchar,cnamec) as c_direcc_descrip,c_estado,c_ciudad from VST_DDESPACHOESTCITY where ccliente='" + _P_Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' order by c_direcc_despa";
            _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_DS_DataSet.Tables[0].Rows.Count > 0)
            {
                this._lis_1.DataSource = _DS_DataSet.Tables[0].DefaultView;
                _lis_1.DisplayMember = "c_direcc_descrip";
                _lis_1.ValueMember = "c_direcc_despa";
                _Bt_Edit.Enabled = true;
                _Bt_TabDel.Enabled = true;
            }
            else
            {
                _Bt_Edit.Enabled = false;
                _Bt_TabDel.Enabled = false;
            }
        }
        CLASES._Cls_Varios_Metodos _G_MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        private void _Mtd_Cargar_Estado()
        {
            _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Estado, "Select RTRIM(cestate),cname from TESTATE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cname ASC");
            _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
        }
        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString());
        }
        private void _Mtd_Cargar_Ciudad(string _P_Str_Estado)
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Ciudad, "Select RTRIM(ccity),cname from TCITY where cdelete='0' and cestate='" + _P_Str_Estado + "' ORDER BY cname ASC");
            _Cmb_Ciudad.Enabled = true;
        }

        private void _Pnl_Direcc_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Direcc.Visible)
            {
                _Bt_Edit.Enabled = false;
                _Bt_TabDel.Enabled = false;
                _Bt_TabNuevo.Enabled = false;
                _lis_1.Enabled = false;
            }
            else
            {
                _Bt_Edit.Enabled = true;
                _Bt_TabDel.Enabled = true;
                _Bt_TabNuevo.Enabled = true;
                _lis_1.Enabled = true;
                _Txt_CodigoDirecc.Text = "";
                _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
                _Cmb_Estado.SelectedIndex = 0;
                _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
                _Cmb_Ciudad.SelectedIndex = 0;
                _Cmb_Ciudad.Enabled = false;
            }
            if (!_G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_DIR_DESPA_CLIENT"))
            {
                _Bt_TabDel.Enabled = false;
                _Bt_TabNuevo.Enabled = false;
                _Bt_Edit.Enabled = false;
                _Bt_Guardar.Enabled = false;
            }
        }
       
        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            bool _Bol_Guardar = false;
            bool _Bol_Valido = true;
            string _Str_Mensaje = "";
            if (_Txt_DireccionDespacho.Text.TrimEnd() == "")
            {
                _Bol_Valido=false;
                _Str_Mensaje += "Descripción de la dirección de despacho requerido \n";
            }
            if (_Cmb_Estado.SelectedIndex == 0 || _Cmb_Estado.SelectedIndex == -1)
            {
                _Bol_Valido = false;
                _Str_Mensaje += "Estado es requerido \n";
            }
            if (_Cmb_Ciudad.SelectedIndex == 0 || _Cmb_Ciudad.SelectedIndex == -1)
            {
                _Bol_Valido = false;
                _Str_Mensaje += "Ciudad es requerido \n";
            }
            if (_Bol_Valido)
            {
                if (_Bol_New)
                {
                    string _Str_Correlativo = _G_MyUtilidad._Mtd_Correlativo("SELECT MAX(c_direcc_despa) FROM TDDESPACHOC WHERE ccliente='" + _Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'");
                    _Txt_CodigoDirecc.Text = _Str_Correlativo;
                    if (_Str_Correlativo != "")
                    {
                        _Str_SentenciaSQL = "insert into TDDESPACHOC(cgroupcomp,c_direcc_despa,ccliente,c_direcc_descrip,C_ESTADO,c_ciudad,cdateadd,cuseradd) VALUES('" + Frm_Padre._Str_GroupComp + "','" + _Txt_CodigoDirecc.Text + "','" + _Str_Cliente + "','" + _Txt_DireccionDespacho.Text.ToUpper() + "','" + _Cmb_Estado.SelectedValue.ToString() + "','" + _Cmb_Ciudad.SelectedValue.ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                        _Str_SentenciaSQL = "UPDATE TCLIENTE SET CDATEUPD=GETDATE(),CUSERADD='" + Frm_Padre._Str_Use + "' WHERE ccliente='" + _Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                        _Bol_Guardar = true;
                        MessageBox.Show("Se insertó correctamente el registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _Str_SentenciaSQL = "UPDATE TDDESPACHOC SET C_ESTADO='" + _Cmb_Estado.SelectedValue.ToString() + "',C_CIUDAD='" + _Cmb_Ciudad.SelectedValue.ToString() + "', c_direcc_descrip='" + _Txt_DireccionDespacho.Text.ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccliente='" + _Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_direcc_despa='" + _Txt_CodigoDirecc.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    _Bol_Guardar = true;
                    _Str_SentenciaSQL = "UPDATE TCLIENTE SET CDATEUPD=GETDATE(),CUSERADD='"+Frm_Padre._Str_Use+"' WHERE ccliente='" + _Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    MessageBox.Show("Se realizaron los cambios correctamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                if (_Bol_Guardar)
                {
                    _Pnl_Direcc.Visible = false;
                    _Bol_New = false;
                    _Mtd_CargarDirecciones(_Str_Cliente);
                }
            }
            else
            {
                MessageBox.Show(_Str_Mensaje, "Requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool _Bol_New;
        private void _Bt_Edit_Click(object sender, EventArgs e)
        {
            if (_lis_1.SelectedValue != null)
            {
                _Str_SentenciaSQL = "select c_direcc_despa,c_direcc_descrip,c_estado,c_ciudad from TDDESPACHOC where ccliente='" + _Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_direcc_despa='"+_lis_1.SelectedValue.ToString()+"' order by c_direcc_despa";
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_DS_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Cmb_Estado.SelectedValue = _DS_DataSet.Tables[0].Rows[0]["c_estado"].ToString().TrimEnd();
                    _Cmb_Ciudad.SelectedValue = _DS_DataSet.Tables[0].Rows[0]["c_ciudad"].ToString().TrimEnd();
                    _Txt_DireccionDespacho.Text = _DS_DataSet.Tables[0].Rows[0]["c_direcc_descrip"].ToString().TrimEnd().ToUpper();
                    _Txt_CodigoDirecc.Text = _DS_DataSet.Tables[0].Rows[0]["c_direcc_despa"].ToString().TrimEnd().ToUpper();
                    _Pnl_Direcc.Visible = true;
                    _Bol_New = false;
                }
            }
        }

        private void _Bt_TabNuevo_Click(object sender, EventArgs e)
        {
            _Pnl_Direcc.Visible = true;
            _Bol_New = true;
            _Txt_DireccionDespacho.Text = "";
            _Txt_CodigoDirecc.Text = "";
            _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
            _Cmb_Estado.SelectedIndex = -1;
            _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
            _Cmb_Ciudad.SelectedIndex = -1;
            _Cmb_Ciudad.Enabled = false;
        }

        private void _Bt_TabDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lis_1.SelectedValue != null)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar la dirección de despacho seleccionada?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        int _Int_Pedidos = 0;
                        int _Int_Prefacturas = 0;
                        _Str_SentenciaSQL = "select count(cpedido) from TCOTPEDFACM WHERE CSTATUS='2' AND CCLIENTE='" + _Str_Cliente + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_DIRECC_DESPA='" + _lis_1.SelectedValue.ToString() + "' OR CSTATUS='3' AND CCLIENTE='" + _Str_Cliente + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_DIRECC_DESPA='" + _lis_1.SelectedValue.ToString() + "'";
                        _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                        _Int_Pedidos = Convert.ToInt32(_DS_DataSet.Tables[0].Rows[0][0].ToString());
                        _Str_SentenciaSQL = "SELECT  COUNT(TPREFACTURAM.CPFACTURA) FROM TPREFACTURAM WHERE NOT EXISTS (SELECT  cpfactura FROM TFACTURAM WHERE (TPREFACTURAM.cpfactura = cpfactura) AND (TPREFACTURAM.ccompany = ccompany)) AND TPREFACTURAM.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPREFACTURAM.C_DIRECC_DESPA='" + _lis_1.SelectedValue.ToString() + "' and TPREFACTURAM.ccliente='"+_Str_Cliente+"'";
                        _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                        _Int_Prefacturas = Convert.ToInt32(_DS_DataSet.Tables[0].Rows[0][0].ToString());
                        if (_Int_Pedidos == 0 && _Int_Prefacturas == 0)
                        {
                            _Str_SentenciaSQL = "update TDDESPACHOC set cdelete='1',cuserupd='" + Frm_Padre._Str_Use + "',CDATEUPD=GETDATE() WHERE ccliente='" + _Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_direcc_despa='" + _lis_1.SelectedValue.ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                            _Mtd_CargarDirecciones(_Str_Cliente);
                        }
                        else
                        {
                            MessageBox.Show("La dirección de despacho seleccionado no puede ser eliminado ya que esta siendo usada en este momento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Pnl_Direcc.Visible = false;            
        }
    }
}