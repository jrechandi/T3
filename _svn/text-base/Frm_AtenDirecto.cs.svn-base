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
    public partial class Frm_AtenDirecto : Form
    {
        string _Str_Cliente = "";
        string _Str_ClienteP = "";
        string[] _Str_Proveedor = new string[0];
        public Frm_AtenDirecto()
        {
            InitializeComponent();
        }

        public Frm_AtenDirecto(string _P_Str_Cliente)
        {
            InitializeComponent();
            _Str_Cliente = _P_Str_Cliente;
            _Str_ClienteP = _Mtd_CodProspecto(_P_Str_Cliente);
            _Mtd_Actualizar();
        }
        private string _Mtd_CodProspecto(string _P_Str_Cliente)
        {
            string _Str_Cadena = "SELECT ISNULL(cclientep,0) FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows[0][0].ToString().Trim();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT cproveedor,c_nomb_comer FROM TPROVEEDOR WHERE cglobal='1' ORDER BY c_nomb_abreviado";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Proveedor = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Proveedor, _Str_Proveedor.Length + 1);
                _Str_Proveedor[_Str_Proveedor.Length - 1] = _Row["cproveedor"].ToString().Trim();
                _ChkList_Prov.Items.Add(_Row["c_nomb_comer"].ToString().Trim());
            }
            _Str_Cadena = "SELECT cproveedor FROM TATENDIRECTO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_Cliente + "' AND ISNULL(cdelete,0)=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            int _Int_Index = 0;
            _ChkList_Prov.ItemCheck -= new ItemCheckEventHandler(_ChkList_Prov_ItemCheck);
            foreach (string _Str_CodProv in _Str_Proveedor)
            {
                if (_Ds.Tables[0].AsEnumerable().Select(_Row=>_Row["cproveedor"].ToString().Trim()).Contains(_Str_CodProv))
                {
                    _ChkList_Prov.SetItemChecked(_Int_Index, true);
                }
                _Int_Index++;
            }
            _ChkList_Prov.ItemCheck += new ItemCheckEventHandler(_ChkList_Prov_ItemCheck);
        }
        private void _Mtd_ActualizarDatos(string _P_Str_Proveedor, ItemCheckEventArgs e)
        {
            string _Str_Cadena = "SELECT cproveedor FROM TATENDIRECTO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_Cliente + "' AND cproveedor='" + _P_Str_Proveedor + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                if (e.NewValue== CheckState.Checked)
                { _Str_Cadena = "UPDATE TATENDIRECTO SET cdelete='0',cuserupd='" + Frm_Padre._Str_Use + "',cdateupd=GETDATE() WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_Cliente + "' AND cproveedor='" + _P_Str_Proveedor + "'"; }
                else
                { _Str_Cadena = "UPDATE TATENDIRECTO SET cdelete='1',cuserupd='" + Frm_Padre._Str_Use + "',cdateupd=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdatedel=GETDATE() WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_Cliente + "' AND cproveedor='" + _P_Str_Proveedor + "'"; }
            }
            else
            { _Str_Cadena = "INSERT INTO TATENDIRECTO (cgroupcomp,cproveedor,cclientep,ccliente,cuseradd,cdateadd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Proveedor + "','" + _Str_ClienteP + "','" + _Str_Cliente + "','" + Frm_Padre._Str_Use + "',GETDATE())"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void Frm_AtenDirecto_Load(object sender, EventArgs e)
        {

        }

        private void _ChkList_Prov_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _Mtd_ActualizarDatos(_Str_Proveedor[e.Index], e);
        }
    }
}
