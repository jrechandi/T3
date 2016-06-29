using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ProveedorSerOtrComp : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ProveedorSerOtrComp()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        string[] _Str_ProveedorNoAsig;
        private void _Mtd_CargarProveeScomp(string _Pr_Str_TpoProv)
        {
            string _Str_Sql = "SELECT cproveedor,(RTRIM(c_nomb_comer)) FROM TPROVEEDOR WHERE NOT EXISTS(SELECT cproveedor FROM TPROVEEDOR AS TPROV WHERE TPROV.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROV.cproveedor=TPROVEEDOR.cproveedor) AND cglobal='" + _Pr_Str_TpoProv + "' AND c_activo='1'";
            if (_Txt_ProvSinComp.Text.Trim().Length > 0)
            {
                _Str_Sql += " AND c_nomb_comer LIKE '%" + _Txt_ProvSinComp.Text.Trim() + "%'";
            }
            if (_Txt_RifSinComp.Text.Trim().Length > 0)
            {
                _Str_Sql += " AND c_rif LIKE '%" + _Txt_RifSinComp.Text.Trim() + "%'";
            }
            _Str_Sql += " ORDER BY c_nomb_comer";
            _myUtilidad._Mtd_CargarLista(_Lst_ProveeScomp, _Str_Sql);
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            int _Int_I = 0;
            _Str_ProveedorNoAsig = new string[_Ds.Tables[0].Rows.Count];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_ProveedorNoAsig[_Int_I] = _Row[0].ToString().Trim();
                _Int_I++;
            }
        }
        string[] _Str_ProveedorAsig;
        private void _Mtd_CargarProveeRel(string _Pr_Str_TpoProv)
        {
            string _Str_Sql = "SELECT cproveedor,(RTRIM(c_nomb_comer)) FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "') AND cglobal='" + _Pr_Str_TpoProv + "' AND c_activo='1'";
            if (_Txt_ProvRelComp.Text.Trim().Length > 0)
            {
                _Str_Sql += " AND c_nomb_comer LIKE '%" + _Txt_ProvRelComp.Text.Trim() + "%'";
            }
            if (_Txt_RifRelComp.Text.Trim().Length > 0)
            {
                _Str_Sql += " AND c_rif LIKE '%" + _Txt_RifRelComp.Text.Trim() + "%'";
            }
            _Str_Sql += " ORDER BY c_nomb_comer";
            _myUtilidad._Mtd_CargarLista(_Lst_ProveeRel, _Str_Sql);
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            int _Int_I = 0;
            _Str_ProveedorAsig = new string[_Ds.Tables[0].Rows.Count];
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_ProveedorAsig[_Int_I] = _Row[0].ToString().Trim();
                _Int_I++;
            }
        }
        private void _Mtd_AsignarProveedor(string _Pr_Str_ProveId)
        {
            string _Str_Sql = "SELECT cproveedor FROM TPROVEEDOR where cproveedor='" + _Pr_Str_ProveId + "' AND casignado=1";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
            {
                _Str_Sql = "EXEC PA_CREAR_PROVEEDOR_COMP '" + Frm_Padre._Str_Comp + "','" + _Pr_Str_ProveId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            else
            {
                _Str_Sql = "UPDATE TPROVEEDOR SET ccompany='" + Frm_Padre._Str_Comp + "', casignado=1, cdateupd=GETDATE() WHERE cproveedor='" + _Pr_Str_ProveId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
        }
        private void _Mtd_QuitarProveedor(string _Pr_Str_ProveId)
        {
            string _Str_Sql = "SELECT cproveedor FROM TPROVEEDOR WHERE cproveedor='" + _Pr_Str_ProveId + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count == 1)
            {
                _Str_Sql = "UPDATE TPROVEEDOR SET ccompany='0',casignado=0 WHERE cproveedor='" + _Pr_Str_ProveId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            else
            {
                _Str_Sql = "DELETE FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Pr_Str_ProveId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
        }
        private void _Mtd_Actualizar()
        {
            _Txt_ProvRelComp.Text = "";
            _Txt_ProvSinComp.Text = "";
            _Txt_RifRelComp.Text = "";
            _Txt_RifSinComp.Text = "";
            _Mtd_CargarProveeScomp(_Rb_Otros.Checked ? "2" : "0");
            _Mtd_CargarProveeRel(_Rb_Otros.Checked ? "2" : "0");
        }
        private bool _Mtd_ProvConMov(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT cproveedor FROM TMOVCXPM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void Frm_ProveedorSerOtrComp_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this, true);
        }

        private void _Rb_Servicio_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Servicio.Checked)
            {
                _Txt_ProvRelComp.Text = "";
                _Txt_ProvSinComp.Text = "";
                _Txt_RifRelComp.Text = "";
                _Txt_RifSinComp.Text = "";
                this.Cursor = Cursors.WaitCursor;
                _Mtd_CargarProveeScomp("0");
                _Mtd_CargarProveeRel("0");
                this.Cursor = Cursors.Default;
            }
        }

        private void _Rb_Otros_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Otros.Checked)
            {
                _Txt_ProvRelComp.Text = "";
                _Txt_ProvSinComp.Text = "";
                _Txt_RifRelComp.Text = "";
                _Txt_RifSinComp.Text = "";
                this.Cursor = Cursors.WaitCursor;
                _Mtd_CargarProveeScomp("2");
                _Mtd_CargarProveeRel("2");
                this.Cursor = Cursors.Default;
            }
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Lst_ProveeScomp.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (int _Int_Prov in _Lst_ProveeScomp.SelectedIndices)
                {
                    _Mtd_AsignarProveedor(_Str_ProveedorNoAsig[_Int_Prov]);
                }
                _Mtd_Actualizar();
                this.Cursor = Cursors.Default;
            }
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Lst_ProveeRel.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;
                bool _Bol_Mov = false;
                foreach (int _Int_Prov in _Lst_ProveeRel.SelectedIndices)
                {
                    if (!_Mtd_ProvConMov(_Str_ProveedorAsig[_Int_Prov]))
                    {
                        _Mtd_QuitarProveedor(_Str_ProveedorAsig[_Int_Prov]);
                    }
                    else
                    {
                        _Bol_Mov = true;
                    }
                }
                _Mtd_Actualizar();
                this.Cursor = Cursors.Default;
                if (_Bol_Mov)
                { MessageBox.Show("Uno o más proveedores no se puedieron eliminar porque ya se han generado movimientos con ellos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            this.Cursor = Cursors.Default;
        }

        private void Frm_ProveedorSerOtrComp_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
        }

        private void Frm_ProveedorSerOtrComp_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_BuscarProvSinComp_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarProveeScomp(_Rb_Otros.Checked ? "2" : "0");
            Cursor = Cursors.Default;
        }

        private void _Bt_BuscarProvRelComp_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarProveeRel(_Rb_Otros.Checked ? "2" : "0");
            Cursor = Cursors.Default;
        }

        private void _Bt_BuscarRifSinComp_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarProveeScomp(_Rb_Otros.Checked ? "2" : "0");
            Cursor = Cursors.Default;
        }

        private void _Bt_BuscarRifRelComp_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarProveeRel(_Rb_Otros.Checked ? "2" : "0");
            Cursor = Cursors.Default;
        }
    }
}