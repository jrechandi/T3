using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Cuotaventas1 : Form
    {
        TabControl _Tb_Tab = new TabControl();
        string _Str_MyProceso = "";
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Cuotaventas1()
        {
            InitializeComponent();
            _Mtd_CargarFiltro();
        }
        public Frm_Cuotaventas1(string _P_Str_Zona)
        {
            InitializeComponent();
            _Mtd_CargarFiltro();
            try 
            {
                _Cb_Ano.SelectedItem = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year;
                _Cb_Mes.SelectedValue = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString();
                _Cb_ZonaVta.SelectedValue = _P_Str_Zona;
            }
            catch { }
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }
            if (_Str_MyProceso == "")
            {
                if (_Dg_Cuotas.Rows.Count==0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                }
            }
        }
        private void _Mtd_CargarFiltro()
        {
            int _Int_AnoMin = 0;
            string _Str_Sql = "SELECT MIN(canocalend) FROM TCALENDVTA WHERE cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Int_AnoMin = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    _Int_AnoMin = 2000;
                }
            }
            _Cb_Ano.Items.Clear();
            _Cb_Ano.Items.Add("...");
            for (int _I = _Int_AnoMin; _I <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year; _I++)
            {
                _Cb_Ano.Items.Add(_I);
            }
            _Cb_Ano.SelectedIndex = 0;
            _myUtilidad._Mtd_CargarMesesCombo(_Cb_Mes);
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_CargarZonas(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_CargarZonas();
            }
            _Mtd_CargarProveedores();
        }

        private void _Mtd_CargarZonas()
        {
            string _Str_Sql = "SELECT c_zona,(rtrim(c_zona) + ': ' + rtrim(cname)) as descrip FROM TZONAVENTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cdelete=0 ORDER BY c_zona";
            _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVta, _Str_Sql);
        }
        private void _Mtd_CargarZonas(string _Pr_Str_Gerente)
        {
            string _Str_Sql = "SELECT c_zona,(rtrim(c_zona) + ': ' + rtrim(cname)) as descrip FROM VST_ZONAVENTA_VENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgerarea='"+Frm_Padre._Str_Use+"' ORDER BY c_zona";
            _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVta, _Str_Sql);
        }
        private void _Mtd_CargarProveedores()
        {
            string _Str_Sql = "SELECT DISTINCT " +
"TPROVEEDOR.cproveedor, TPROVEEDOR.c_nomb_comer " +
"FROM TZONAVENTA INNER JOIN " +
"TGRUPPROVEE ON TZONAVENTA.ccompany = TGRUPPROVEE.ccompany AND " +
"TZONAVENTA.cgrupovta = TGRUPPROVEE.cgrupovta INNER JOIN " +
"TPROVEEDOR ON TGRUPPROVEE.cproveedor = TPROVEEDOR.cproveedor ";
            if (_Cb_ZonaVta.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + "WHERE (TZONAVENTA.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TZONAVENTA.c_zona = '" + _Cb_ZonaVta.SelectedValue.ToString() + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            }
            else
            {
                _Str_Sql = _Str_Sql + "WHERE (TZONAVENTA.ccompany = '" + Frm_Padre._Str_Comp + "') AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            }
            _myUtilidad._Mtd_CargarCombo(_Cb_Proveedor, _Str_Sql);
        }
        private void _Mtd_FindDetalle()
        {
            if (_Cb_Ano.SelectedIndex > 0 && _Cb_Mes.SelectedIndex > 0 && _Cb_ZonaVta.SelectedIndex > 0 && _Cb_Proveedor.SelectedIndex > 0)
            {
                DataSet _Ds_A;
                this.Cursor = Cursors.WaitCursor;
                object[] _Str_RowNew = new object[10];
                //_Str_Sql = "SELECT cgrupo,rtrim(cgruponame),ccuotacaja,ccuotaclientes,ccuotabolivares,canocuota,cmescuota,c_zona,cproveedor FROM VST_TCUOTAVTA WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                string _Str_Sql = "SELECT cgrupo,rtrim(cgruponame),null,null,null,null,null,null,null,0 FROM VST_GRUPOPROD WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _Cb_Proveedor.SelectedValue.ToString() + "' ORDER BY cgrupo";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Dg_Cuotas.Rows.Clear();
                foreach (DataRow _DataR in _Ds.Tables[0].Rows)
                {
                    Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                    _Dg_Cuotas.Rows.Add(_Str_RowNew);
                    
                    _Str_Sql = "SELECT * FROM VST_TCUOTAVTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND canocuota=" + _Cb_Ano.Text + " AND cmescuota=" + _Cb_Mes.SelectedValue.ToString() + " AND cproveedor='" + _Cb_Proveedor.SelectedValue.ToString() + "' AND c_zona='" + _Cb_ZonaVta.SelectedValue.ToString() + "' AND cgrupo='" + _Dg_Cuotas[0, _Dg_Cuotas.RowCount - 1].Value.ToString() + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccuotacaja"]) != "")
                        {
                            _Dg_Cuotas[2, _Dg_Cuotas.RowCount - 1].Value = Convert.ToInt32(_Ds_A.Tables[0].Rows[0]["ccuotacaja"]).ToString();
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccuotaclientes"]) != "")
                        {
                            _Dg_Cuotas[3, _Dg_Cuotas.RowCount - 1].Value = Convert.ToInt32(_Ds_A.Tables[0].Rows[0]["ccuotaclientes"]).ToString();
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccuotabolivares"]) != "")
                        {
                            _Dg_Cuotas[4, _Dg_Cuotas.RowCount - 1].Value = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["ccuotabolivares"]).ToString("#,##0.00");
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["canocuota"]) != "")
                        {
                            _Dg_Cuotas[5, _Dg_Cuotas.RowCount - 1].Value = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["canocuota"]).ToString("#,##0");
                        }
                        else
                        {
                            _Dg_Cuotas[5, _Dg_Cuotas.RowCount - 1].Value = _Cb_Ano.Text;
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["cmescuota"]) != "")
                        {
                            _Dg_Cuotas[6, _Dg_Cuotas.RowCount - 1].Value = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cmescuota"]).ToString("#,##0");
                        }
                        else
                        {
                            _Dg_Cuotas[6, _Dg_Cuotas.RowCount - 1].Value = _Cb_Mes.SelectedValue.ToString();
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["c_zona"]) != "")
                        {
                            _Dg_Cuotas[7, _Dg_Cuotas.RowCount - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["c_zona"]).Trim();
                        }
                        else
                        {
                            _Dg_Cuotas[7, _Dg_Cuotas.RowCount - 1].Value = _Cb_ZonaVta.SelectedValue.ToString().Trim();
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["cproveedor"]) != "")
                        {
                            _Dg_Cuotas[8, _Dg_Cuotas.RowCount - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cproveedor"]).Trim();
                        }
                        else
                        {
                            _Dg_Cuotas[8, _Dg_Cuotas.RowCount - 1].Value = _Cb_Proveedor.SelectedValue.ToString();
                        }
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["csubgrupo"]) != "")
                        {
                            _Dg_Cuotas[9, _Dg_Cuotas.RowCount - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["csubgrupo"]).Trim();
                        }
                        else
                        {
                            _Dg_Cuotas[9, _Dg_Cuotas.RowCount - 1].Value = "0";
                        }
                    }
                    _Dg_Cuotas[5, _Dg_Cuotas.RowCount - 1].Value = _Cb_Ano.Text;
                    _Dg_Cuotas[6, _Dg_Cuotas.RowCount - 1].Value = _Cb_Mes.SelectedValue.ToString();
                    _Dg_Cuotas[7, _Dg_Cuotas.RowCount - 1].Value = _Cb_ZonaVta.SelectedValue.ToString().Trim();
                    _Dg_Cuotas[8, _Dg_Cuotas.RowCount - 1].Value = _Cb_Proveedor.SelectedValue.ToString();
                }
                _Dg_Cuotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Seleccione todas las opciones de búsqueda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void _Cb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Cuotas.Rows.Clear();
        }

        private void _Cb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Cuotas.Rows.Clear();
        }

        private void _Cb_ZonaVta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Cuotas.Rows.Clear();
        }

        private void _Cb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Cuotas.Rows.Clear();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_FindDetalle();
            _Mtd_BotonesMenu();
        }

        private void Frm_Cuotaventas1_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Bloquear(true);
        }

        public bool _Mtd_Editar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            double _Dbl_cuotabs = 0;
            int _Int_cuotacaja = 0, _Int_cuotacliente = 0;
            _Dg_Cuotas.EndEdit();
            foreach (DataGridViewRow _DgRow in _Dg_Cuotas.Rows)
            {
                _Dbl_cuotabs = 0; _Int_cuotacaja = 0; _Int_cuotacliente = 0;
                if (Convert.ToString(_DgRow.Cells[2].Value).Trim().Length>0)
                {
                    _Int_cuotacaja = Convert.ToInt32(_DgRow.Cells[2].Value.ToString().Replace(".", ""));
                }
                if (Convert.ToString(_DgRow.Cells[3].Value).Trim().Length>0)
                {
                    _Int_cuotacliente = Convert.ToInt32(_DgRow.Cells[3].Value.ToString().Replace(".", ""));
                }
                if (Convert.ToString(_DgRow.Cells[4].Value).Trim().Length>0)
                {
                    _Dbl_cuotabs= Convert.ToDouble(_DgRow.Cells[4].Value.ToString().Replace(".",""));
                }
                _Str_Sql = "SELECT * FROM TCUOTAVTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and canocuota=" + _DgRow.Cells[5].Value.ToString() + " and cmescuota=" + _DgRow.Cells[6].Value.ToString() + " and c_zona='" + _DgRow.Cells[7].Value.ToString() + "' and cproveedor='" + _DgRow.Cells[8].Value.ToString() + "' AND cgrupo='" + _DgRow.Cells[0].Value.ToString() + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    if (_Int_cuotacaja > 0 && _Int_cuotacliente > 0 && _Dbl_cuotabs > 0)
                    {
                        _Str_Sql = "UPDATE TCUOTAVTA SET ccuotacaja=" + _Int_cuotacaja.ToString().Replace(",", ".") + ",ccuotaclientes=" + _Int_cuotacliente.ToString().Replace(",", ".") + ",ccuotabolivares=" + _Dbl_cuotabs.ToString().Replace(",", ".") + " where ccompany='" + Frm_Padre._Str_Comp + "' and canocuota=" + _DgRow.Cells[5].Value.ToString() + " and cmescuota=" + _DgRow.Cells[6].Value.ToString() + " and c_zona='" + _DgRow.Cells[7].Value.ToString() + "' and cproveedor='" + _DgRow.Cells[8].Value.ToString() + "' AND cgrupo='" + _DgRow.Cells[0].Value.ToString() + "'";
                    }
                    else
                    {
                        _Str_Sql = "DELETE FROM TCUOTAVTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and canocuota=" + _DgRow.Cells[5].Value.ToString() + " and cmescuota=" + _DgRow.Cells[6].Value.ToString() + " and c_zona='" + _DgRow.Cells[7].Value.ToString() + "' and cproveedor='" + _DgRow.Cells[8].Value.ToString() + "' AND cgrupo='" + _DgRow.Cells[0].Value.ToString() + "'";
                    }
                }
                else
                {
                    _Str_Sql = "";
                    if (_Int_cuotacaja > 0 && _Int_cuotacliente > 0 && _Dbl_cuotabs > 0)
                    {
                        _Str_Sql = "INSERT INTO TCUOTAVTA (ccompany,canocuota,cmescuota,cproveedor,cgrupo,csubgrupo,c_zona,ccuotacaja,ccuotaclientes,ccuotabolivares,cdateadd,cuseradd,cdelete) VALUES ('" +
                            Frm_Padre._Str_Comp + "'," + _DgRow.Cells[5].Value.ToString() + "," + _DgRow.Cells[6].Value.ToString() + ",'" + _DgRow.Cells[8].Value.ToString() + "','" + _DgRow.Cells[0].Value.ToString() + "','" + _DgRow.Cells[5].Value.ToString() + "','" + _DgRow.Cells[7].Value.ToString() + "'," + _Int_cuotacaja.ToString().Replace(",", ".") + "," + _Int_cuotacliente.ToString().Replace(",", ".") + "," + _Dbl_cuotabs.ToString().Replace(",", ".") + ",GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                    }
                }
                if (_Str_Sql.Length > 0)
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            _Mtd_Ini();
            _Mtd_FindDetalle();
            MessageBox.Show("Transacción realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Bol_R = true;
            return _Bol_R;
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(false);
            _Str_MyProceso = "M";
            _Pnl_Filtro.Enabled = false;
        }
        public void _Mtd_Ini()
        {
            _Mtd_Bloquear(true);
            _Pnl_Filtro.Enabled = true;
            _Str_MyProceso = "";
            _Mtd_BotonesMenu();
        }
        private void _Mtd_Bloquear(bool _Pr_BolSw)
        {
            _Dg_Cuotas.ReadOnly = _Pr_BolSw;
            _Dg_Cuotas.Columns[0].ReadOnly = true;
            _Dg_Cuotas.Columns[1].ReadOnly = true;
        }

        private void Frm_Cuotaventas1_Activated(object sender, EventArgs e)
        {
            //_Mtd_BotonesMenu();
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_Cuotaventas1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Cuotas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(_Dg_CuotasCell_KeyPress);
            //e.Control.Leave;
            //e.Control.Enter;
        }
        void _Dg_CuotasCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Cuotas.CurrentCell.ColumnIndex == 4)
            {
                _myUtilidad._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2);
            }
            else if (_Dg_Cuotas.CurrentCell.ColumnIndex == 2 | _Dg_Cuotas.CurrentCell.ColumnIndex == 3)
            {
                _myUtilidad._Mtd_Valida_Numeros((TextBox)sender, e, 15, 0);
            }
           
        }

        private void _Cb_ZonaVta_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_CargarZonas(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_CargarZonas();
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarProveedores();
            this.Cursor = Cursors.Default;
        }
    }
}