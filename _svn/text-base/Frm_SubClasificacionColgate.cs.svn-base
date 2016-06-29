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
    public partial class Frm_SubClasificacionColgate : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        DataSet _G_Ds_DataSet = new DataSet();
        string _G_Str_SentenciaSQL;
        string _G_Str_Cliente;
        string _G_Str_TipoEstablecimiento;
        string _G_Str_NombreTipoEstablecimiento;
        string _G_Str_NombreCliente;
        public Frm_SubClasificacionColgate()
        {
            InitializeComponent();
        }
        public Frm_SubClasificacionColgate(string _P_Str_Cliente, string _P_Str_TipoEstablecimiento, string _P_Str_NombreTipoEstablecimiento, string _P_Str_NombreCliente)
        {
            _G_Str_Cliente = _P_Str_Cliente;
            _G_Str_TipoEstablecimiento = _P_Str_TipoEstablecimiento;
            _G_Str_NombreTipoEstablecimiento = _P_Str_NombreTipoEstablecimiento;
            _G_Str_NombreCliente = _P_Str_NombreCliente;
            InitializeComponent();
            _Mtd_CargarSubclasificacionesColgate();
            _Mtd_MostrarDatos();
        }
        private void _Mtd_MostrarDatos()
        {
            _Txt_CodCliente.Text = _G_Str_Cliente;
            _Txt_NombreCliente.Text = _G_Str_NombreCliente;
            _Txt_TipoEstablecimiento.Text = _G_Str_NombreTipoEstablecimiento;
            _Txt_TipoEstablecimiento.Tag = _G_Str_TipoEstablecimiento;
            _G_Str_SentenciaSQL = "SELECT ccustomersegment FROM TCLIENTECUSTOMERSEGITT WHERE CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _G_Str_Cliente + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
            if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                if (_Cmb_SubClasificacion.Items.Count > 1)
                {
                    _Cmb_SubClasificacion.SelectedValue = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                }
            }
        }
        private void _Mtd_CargarSubclasificacionesColgate()
        {
            _G_Str_SentenciaSQL = "SELECT ccustomersegment,cdescripcion from VST_T3_SUBTIPOESTABLECIMIENTOCOLGATE WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ctestablecim='"+_G_Str_TipoEstablecimiento+"'";
            _myUtilidad._Mtd_CargarCombo(_Cmb_SubClasificacion, _G_Str_SentenciaSQL);
        }
        private void Frm_SubClasificacionColgate_Load(object sender, EventArgs e)
        {

        }

        private void _Btn_Actualizar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_SubClasificacion.SelectedValue != null)
            {
                if (_Cmb_SubClasificacion.SelectedValue.ToString() != "nulo")
                {
                    _G_Str_SentenciaSQL = "SELECT ccustomersegment FROM TCLIENTECUSTOMERSEGITT WHERE CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _G_Str_Cliente + "'";
                    _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                    if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        string _Str_AccountType = "";
                        _G_Str_SentenciaSQL="SELECT caccounttype FROM TITTCUSTOMERSEGMENT WHERE ccustomersegment='" + _Cmb_SubClasificacion.SelectedValue.ToString() + "'";
                        _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                        if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
                        {
                            _Str_AccountType = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                            _G_Str_SentenciaSQL = "UPDATE TCLIENTECUSTOMERSEGITT SET caccounttype='" + _Str_AccountType + "',ccustomersegment='" + _Cmb_SubClasificacion.SelectedValue.ToString() + "' WHERE CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _G_Str_Cliente + "'";
                        }
                        else
                        {
                            _G_Str_SentenciaSQL = "";
                        }
                    }
                    else
                    {
                        _G_Str_SentenciaSQL = "INSERT INTO TCLIENTECUSTOMERSEGITT(cgroupcomp,ccliente,caccounttype,ccustomersegment) ";
                        _G_Str_SentenciaSQL += " SELECT '" + Frm_Padre._Str_GroupComp + "','" + _G_Str_Cliente + "',caccounttype,ccustomersegment FROM TITTCUSTOMERSEGMENT WHERE ccustomersegment='" + _Cmb_SubClasificacion.SelectedValue.ToString() + "'";
                    }
                    if (_G_Str_SentenciaSQL != "")
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
                else
                {
                    _Er_Error.SetError(_Cmb_SubClasificacion, "Campo requerido!!!");
                }
            }
            else
            {
                _Er_Error.SetError(_Cmb_SubClasificacion, "Campo requerido!!!");
            }
        }

        private void _Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
