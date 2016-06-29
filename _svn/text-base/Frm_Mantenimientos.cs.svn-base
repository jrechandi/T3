using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Mantenimientos : Form
    {
        Form _Frm = new Form();
        string _Str_Clave = "";
        int _Int_Formulario = 0;
        string _Str_cgrupovta = "";
        public Frm_Mantenimientos()
        {
            InitializeComponent();
        }
        public Frm_Mantenimientos(Form _P_Frm, string _P_Str_Clave, int _P_Int_Formulario)
        {
            _Frm = _P_Frm;
            _Str_Clave = _P_Str_Clave;
            _Int_Formulario = _P_Int_Formulario;
            InitializeComponent();
        }
        public Frm_Mantenimientos(Form _P_Frm, string _P_Str_Clave, int _P_Int_Formulario, string _P_Str_cgrupovta)
        {
            _Frm = _P_Frm;
            _Str_Clave = _P_Str_Clave;
            _Int_Formulario = _P_Int_Formulario;
            _Str_cgrupovta = _P_Str_cgrupovta;
            InitializeComponent();
        }
        private void Frm_Mantenimientos_Load(object sender, EventArgs e)
        {
            if (_Int_Formulario == 1)
            {
                //___________________________________
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                string[] _Str_Campos = new string[2];
                _Str_Campos[0] = "cproveedor";
                _Str_Campos[1] = "c_nomb_comer";
                string _Str_Cadena = "select cproveedor as Código,c_nomb_comer as Descripción from tproveedor where cdelete='0'";
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Proveedores", _Tsm_Menu, _Dg_Grid2, true, "");
                //___________________________________
                this.Text = "Proveedores";
            }
            if (_Int_Formulario == 2)
            {
                _Dg_Grid2.MultiSelect = false;
                string _Str_Cadena = "Select * from TZONAVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='"+_Str_Clave+"' and cdelete='0'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { MessageBox.Show("Ya existe un vendedor asignado a esta zona", "Infromación", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
                else
                {
                    //___________________________________
                    ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
                    _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                    _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                    string[] _Str_Campos = new string[2];
                    _Str_Campos[0] = "cvendedor";
                    _Str_Campos[1] = "cname";
                    _Str_Cadena = "select cvendedor as Código,cname as Descripción from TVENDEDOR where cdelete='0' and c_activo='1' and ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend='1' and c_grupo_vta='" + _Str_cgrupovta + "' AND NOT EXISTS(Select * from TZONAVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and TVENDEDOR.cvendedor=TZONAVENDEDOR.cvendedor)";
                    _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Vendedores", _Tsm_Menu, _Dg_Grid2, true, "");
                    //___________________________________
                    this.Text = "Vendedores";
                }
            }
            if (_Int_Formulario == 3)
            {
                //___________________________________
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
                _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
                string[] _Str_Campos = new string[3];
                _Str_Campos[0] = "ccliente";
                _Str_Campos[1] = "c_rif";
                _Str_Campos[2] = "c_nomb_comer";
                //string _Str_Cadena = "select ccliente as Código,c_rif as Rif,c_nomb_comer as Cliente from TCLIENTE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT ccliente, c_rif, c_nomb_comer FROM  vst_zonaporcliente WHERE (cdelete='0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cgrupovta = '" + _Str_cgrupovta + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=vst_zonaporcliente.ccliente)";
                //string _Str_Cadena = "select ccliente as Código,c_rif as Rif,c_nomb_comer as Cliente from TCLIENTE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND (NOT EXISTS(SELECT ccliente, c_rif, c_nomb_comer FROM  vst_zonaporcliente WHERE (cdelete='0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cgrupovta = '" + _Str_cgrupovta + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=vst_zonaporcliente.ccliente) OR (SELECT COUNT(*) FROM VST_ZONACLIENTEDESPACHO WHERE VST_ZONACLIENTEDESPACHO.cgroupcomp=TCLIENTE.cgroupcomp AND VST_ZONACLIENTEDESPACHO.ccliente=TCLIENTE.ccliente)>(select count(*) from vst_zonaporcliente where vst_zonaporcliente.cgroupcomp=TCLIENTE.cgroupcomp AND vst_zonaporcliente.ccliente=TCLIENTE.ccliente AND cdelete='0' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cgrupovta = '" + _Str_cgrupovta + "') group by ccliente))";
                string _Str_Cadena = "select ccliente as Código,c_rif as Rif,c_nomb_comer as Cliente from TCLIENTE where c_activo='1' and cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND (NOT EXISTS(SELECT ccliente, c_rif, c_nomb_comer FROM  vst_zonaporcliente WHERE (cdelete='0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cgrupovta = '" + _Str_cgrupovta + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=vst_zonaporcliente.ccliente) OR ((SELECT COUNT(*) FROM VST_ZONACLIENTEDESPACHO WHERE VST_ZONACLIENTEDESPACHO.cgroupcomp=TCLIENTE.cgroupcomp AND VST_ZONACLIENTEDESPACHO.ccliente=TCLIENTE.ccliente)>(select count(*) from vst_zonaporcliente where vst_zonaporcliente.cgroupcomp=TCLIENTE.cgroupcomp AND vst_zonaporcliente.ccliente=TCLIENTE.ccliente AND cdelete='0' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cgrupovta = '" + _Str_cgrupovta + "') group by ccliente)) and NOT EXISTS(SELECT ccliente, c_rif, c_nomb_comer FROM  vst_zonaporcliente WHERE (cdelete='0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cgrupovta = '" + _Str_cgrupovta + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND c_zona='" + _Str_Clave + "' AND TCLIENTE.ccliente=vst_zonaporcliente.ccliente))";
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Grid2, true, "");
                //___________________________________
                this.Text = "Clientes";
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            bool _Bol_Salir = false;
            foreach (DataGridViewRow _Row in _Dg_Grid2.SelectedRows)
            {
                if (_Int_Formulario == 1)
                {
                    _Mtd_Agregar1(_Row.Cells[0].Value.ToString());
                    ((Frm_VentaporProveedor)_Frm)._Mtd_Evento();
                }
                if (_Int_Formulario == 2)
                {
                    _Mtd_Agregar2(_Row.Cells[0].Value.ToString());
                    ((Frm_ZonaporVendedor)_Frm)._Mtd_Evento();
                    _Bol_Salir = true;
                    break;
                }
                if (_Int_Formulario == 3)
                {
                    _Mtd_Agregar3(_Row.Cells[0].Value.ToString(), _Row.Cells[1].Value.ToString());
                    ((Frm_ZonaporCliente)_Frm)._Mtd_Evento();
                }
            }
            if ((Frm_Padre)this.MdiParent!= null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            }
            if (_Bol_Salir)
            {
                this.Close();
            }
            if (_Int_Formulario == 1)
            {
                //___________________________________
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
                string[] _Str_Campos = new string[2];
                _Str_Campos[0] = "cproveedor";
                _Str_Campos[1] = "c_nomb_comer";
                string _Str_Cadena = "select cproveedor as Código,c_nomb_comer as Descripción from tproveedor where cdelete='0'";
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Proveedores", _Tsm_Menu, _Dg_Grid2, true, "");
                //___________________________________
                this.Text = "Proveedores";
            }
            if (_Int_Formulario == 3)
            {
                //___________________________________
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
                _Tsm_Menu[0] = new ToolStripMenuItem("Código");
                _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
                _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
                string[] _Str_Campos = new string[3];
                _Str_Campos[0] = "ccliente";
                _Str_Campos[1] = "c_rif";
                _Str_Campos[2] = "c_nomb_comer";
                string _Str_Cadena = "select ccliente as Código,c_rif as Rif,c_nomb_comer as Descripción from TCLIENTE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND NOT EXISTS(SELECT ccliente, c_rif, c_nomb_comer FROM  vst_zonaporcliente WHERE (cdelete='0') AND (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cgrupovta = '" + _Str_cgrupovta + "') AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND TCLIENTE.ccliente=vst_zonaporcliente.ccliente)";
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Grid2, true, "");
                //___________________________________
                this.Text = "Clientes";
            }
        }
        private void _Mtd_Agregar1(string _P_Str_Codigo)
        {
            string _Str_Cadena = "Select cdelete from TGRUPPROVEE where ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Str_Clave + "' and cproveedor='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _Str_Clave + "','" + _P_Str_Codigo + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0'";
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TGRUPPROVEE", "ccompany,cgrupovta,cproveedor,cdateadd,cuseradd,cdelete", _Str_Cadena);
            }
            else
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    if (MessageBox.Show("El proveedor (" + _P_Str_Codigo + ") fue eliminado del grupo de ventas (" + _Str_Clave + "). ¿Desea volver a agregarlo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TGRUPPROVEE", "cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Str_Clave + "' and cproveedor='" + _P_Str_Codigo + "'");
                    }
                }
            }
        }
        private void _Mtd_Agregar2(string _P_Str_Codigo)
        {
            string _Str_Cadena = "Select cdelete from TZONAVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Clave + "' and cvendedor='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _Str_Clave + "','" + _P_Str_Codigo + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0'";
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TZONAVENDEDOR", "ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete", _Str_Cadena);
            }
            else
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    if (MessageBox.Show("El vendedor (" + _P_Str_Codigo + ") fue eliminado de la zona de ventas (" + _Str_Clave + "). ¿Desea volver a agregarlo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONAVENDEDOR", "cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Clave + "' and cvendedor='" + _P_Str_Codigo + "'");
                    }
                }
            }
        }
        private void _Mtd_Agregar3(string _P_Str_Codigo,string _P_Str_rif)
        {
            string _Str_Cadena = "Select cdelete from TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Clave + "' and ccliente='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _Str_Clave + "','" + _P_Str_Codigo + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','"+_Str_cgrupovta+"'";
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TZONACLIENTE", "ccompany,c_zona,ccliente,cdateadd,cuseradd,cdelete,cgrupovta", _Str_Cadena);
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCLIENTE", "c_zonificado='1',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_rif + "'");
            }
            else
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    if (_Dg_Grid2.SelectedRows.Count > 1)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONACLIENTE", "cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Clave + "' and ccliente='" + _P_Str_Codigo + "'");
                    }
                    else
                    {
                        if (MessageBox.Show("El cliente (" + _P_Str_Codigo + ") fue eliminado de la zona de ventas (" + _Str_Clave + "). ¿Desea volver a agregarlo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONACLIENTE", "cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Str_Clave + "' and ccliente='" + _P_Str_Codigo + "'");
                        }
                    }

                }
            }
        }

        private void _Dg_Grid2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid2.RowCount > 0)
            {
                if (_Int_Formulario == 3)
                {
                    _Mtd_Agregar3(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex), _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex));
                    ((Frm_ZonaporCliente)_Frm)._Mtd_Evento();
                }
                else if (_Int_Formulario == 2)
                {
                    _Mtd_Agregar2(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                    ((Frm_ZonaporVendedor)_Frm)._Mtd_Evento();
                }
                if ((Frm_Padre)this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                this.Close();
            }
        }
    }
}