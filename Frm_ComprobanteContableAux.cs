using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ComprobanteContableAux : Form
    {
        public Frm_ComprobanteContableAux()
        {
            InitializeComponent();
        }
        
        public Frm_ComprobanteContableAux(string _P_Str_Count,string _P_Str_ID_Auxiliar)
        {
            InitializeComponent();
            string _Str_Cadena = "SELECT cauxiliary,cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _P_Str_Count + "' AND cauxiliary='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cuenta.Text = _P_Str_Count;
                _Txt_Descripcion.Text = _Mtd_DescripCuenta(_P_Str_Count);
                if (_Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim().Length > 0)
                {
                    _Txt_Clasificacion.Tag = _Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim();
                    _Txt_Clasificacion.Text = _Mtd_RetornarClasificacion(_Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim());
                    if (_P_Str_ID_Auxiliar.Trim().Length > 0)
                    {
                        _Txt_ID_Auxiliar.Tag = _P_Str_ID_Auxiliar;
                        if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "1")
                        {
                            _Txt_ID_Auxiliar.Text = _Mtd_DesCliente(_P_Str_ID_Auxiliar);
                        }
                        else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "2" | Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "3" | Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "4")
                        {
                            _Txt_ID_Auxiliar.Text = _Mtd_DesProveedor(_P_Str_ID_Auxiliar);
                        }
                        else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "5")
                        {
                            _Txt_ID_Auxiliar.Text = _Mtd_DesEmpleado(_P_Str_ID_Auxiliar);
                        }
                        else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "6")
                        {
                            _Txt_ID_Auxiliar.Text = _Mtd_DesBanco(_P_Str_ID_Auxiliar);
                        }
                    }
                }
            }
        }
        private string _Mtd_RetornarClasificacion(string _P_Str_clasificacion)
        {
            if (_P_Str_clasificacion.Trim() == "1")
            { return "CLIENTES"; }
            else if (_P_Str_clasificacion.Trim() == "2")
            { return "PROVEEDOR MATERIA PRIMA"; }
            else if (_P_Str_clasificacion.Trim() == "3" | _P_Str_clasificacion.Trim() == "4")
            { return "PROVEEDOR DE SERVICIO/OTROS"; }
            //else if (_P_Str_clasificacion.Trim() == "4")
            //{ return "PROVEEDOR DE SERVICIO/OTROS"; }
            else if (_P_Str_clasificacion.Trim() == "5")
            { return "EMPLEADOS"; }
            else if (_P_Str_clasificacion.Trim() == "6")
            { return "BANCO"; }
            else if (_P_Str_clasificacion.Trim() == "7")
            { return "ACTIVO"; }
            else if (_P_Str_clasificacion.Trim() == "8")
            { return "COMPAÑÍA RELACIONADA"; }
            else if (_P_Str_clasificacion.Trim() == "9")
            { return "ACCIONISTAS"; }
            return "";
        }
        private string _Mtd_DesCliente(string _P_Str_Cliente)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private string _Mtd_DesProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private string _Mtd_DesEmpleado(string _P_Str_Empleado)
        {
            string _Str_Cadena = "SELECT ISNULL(cnombre1,'')+' '+ISNULL(cnombre2,'')+' '+ISNULL(capellido1,'')+' '+ISNULL(capellido2,'') FROM TEMPLEADOS_SPI WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cid_spi='" + _P_Str_Empleado + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private string _Mtd_DesBanco(string _P_Str_Banco)
        {
            string _Str_Cadena = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private string _Mtd_DescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }

        private void Frm_ComprobanteContableAux_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            string _Str_Temp = _Txt_ID_Auxiliar.Text.Trim();
            string _Str_Cadena = "";
            if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "1")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult == "1")
                {
                    _Txt_ID_Auxiliar.Tag = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                    _Txt_ID_Auxiliar.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                }
            }
            else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "2")
            {
                _Str_Cadena = " AND (cglobal='1')";
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_ID_Auxiliar, 0, _Str_Cadena);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "3" | Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "4")
            {
                _Str_Cadena = " AND (cglobal='0' OR cglobal='2') AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'";
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_ID_Auxiliar, 0, _Str_Cadena);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "5")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(36);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult == "1")
                {
                    _Txt_ID_Auxiliar.Tag = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                    _Txt_ID_Auxiliar.Text = _Frm._Dg_Grid[2, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                }
            }
            else if (Convert.ToString(_Txt_Clasificacion.Tag).Trim() == "6")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(37);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult == "1")
                {
                    _Txt_ID_Auxiliar.Tag = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                    _Txt_ID_Auxiliar.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
                }
            }
            if (_Str_Temp != _Txt_ID_Auxiliar.Text.Trim()) { this.Close(); }
        }
    }
}
