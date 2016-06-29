using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ProcesosContables : Form
    {
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_MyProceso = "";
        DataGridViewComboBoxColumn _myDgCmbColVariable;
        DataGridViewComboBoxColumn _myDgCmbCol;
        public Frm_ProcesosContables()
        {
            InitializeComponent();
        }

        private void _Mtd_CargarBusqueda()
        {
            string _Str_Sql = "";
            object[] _Str_RowNew = new object[3];
            _Str_Sql = "Select cidproceso,cdescripcion,cname from VST_TPROCESOSCONT where cdelete='0'";
            if (_Txt_FindCodigo.Text.Trim() != "")
            {
                _Str_Sql = _Str_Sql + " AND cidproceso='" + _Txt_cidproceso.Text + "'";
            }
            if (_Cmb_FindTpoComprob.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND ctypcompro='" + _Cmb_FindTpoComprob.SelectedValue.ToString() + "'";
            }
            if (_Chk_FindSistema.Checked)
            {
                _Str_Sql = _Str_Sql + " AND cprocesistema=1";
            }

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Grid.Rows.Add(_Str_RowNew);
            }
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarData(string _Pr_Str_IdPCont)
        {
            string _Str_Sql = "SELECT * FROM VST_TPROCESOSCONT WHERE cidproceso='" + _Pr_Str_IdPCont + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_cidproceso.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidproceso"]);
                _Txt_cdescripcion.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cdescripcion"]);
                _Txt_cconceptocomp.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cconceptocomp"]);
                _Cb_ctypcompro.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctypcompro"]);
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cprocesistema"]) == "1")
                {
                    _Chk_Sistema.Checked = true;
                }
                else
                { _Chk_Sistema.Checked = false; }
                _Mtd_CargarDetalle(_Pr_Str_IdPCont);
            }
        }

        private void Frm_ProcesosContables_Load(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _Mtd_Color_Estandar(this);
            _myDgCmbColVariable = (DataGridViewComboBoxColumn)_Dg_GridDeta.Columns[3];
            _Mtd_CargarDgVariable();
        }
        private void _Mtd_CargarDgVariable()
        {
            object[] _MyVec_Obj = new object[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
            _myDgCmbColVariable.Items.AddRange(_MyVec_Obj);
        }
        private void _Mtd_TpoComprob()
        {
            myUtilidad._Mtd_CargarCombo(_Cb_ctypcompro, "Select ctypcompro,cname from TTCOMPROBAN");
        }
        private void _Mtd_FindTpoComprob()
        {
            
            myUtilidad._Mtd_CargarCombo(_Cmb_FindTpoComprob, "Select ctypcompro,cname from TTCOMPROBAN");
        }

        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Frm_ProcesosContables_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ProcesosContables_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
        }

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_cidproceso.Text = "";
            _Txt_cidproceso.Enabled = false;
            _Txt_cdescripcion.Text = "";
            _Txt_cdescripcion.Enabled = false;
            _Txt_cconceptocomp.Text = "";
            _Txt_cconceptocomp.Enabled = false;
            _Cb_ctypcompro.SelectedItem  = "...";
            _Cb_ctypcompro.Enabled = false;
            _Chk_Sistema.Checked = false;
            _Chk_Sistema.Enabled = false;
            _Mtd_CargarBusqueda();
            _Mtd_TpoComprob();
            _Mtd_FindTpoComprob();
            _Mtd_IniDetalle();
            _Mtd_Sorted();
        }

        private void _Mtd_IniDetalle()
        {
            _Dg_GridDeta.ClearSelection();
            _Dg_GridDeta.Rows.Clear();
            _Dg_GridDeta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_GridDeta.ReadOnly = true;
        }

        private void _Mtd_CargarDetalle(string _Pr_Str_Cod)
        {
            object[] _Str_RowNew = new object[6];
            _Dg_GridDeta.AllowUserToAddRows = false;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cideprocesod,ccount,null,cvariable,ccountname,cnaturalezaver from VST_PROCESOSCONTD WHERE (ccompany='" + Frm_Padre._Str_Comp + "'  or ccompany is null) and cidproceso='" + _Pr_Str_Cod + "' ORDER BY cideprocesod"); 
            _Dg_GridDeta.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                if (!_Mtd_VerifVariable(Convert.ToString(_DataR["cvariable"]).Trim()))
                {
                    _Str_RowNew[3] = "";
                }
                _Dg_GridDeta.Rows.Add(_Str_RowNew);
                if (_DataR["ccount"].ToString() == "PRV.X")
                {
                    _Dg_GridDeta[4, _Dg_GridDeta.RowCount - 1].Value = "PARAMETRO DE CUENTA DE PROVEEDOR";
                }
                else if (_DataR["ccount"].ToString() == "BNC.X")
                {
                    _Dg_GridDeta[4, _Dg_GridDeta.RowCount - 1].Value = "PARAMETRO DE CUENTA DE BANCO";
                }
            }
            _Dg_GridDeta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void _Mtd_Habilitar()
        {
            _Txt_cidproceso.Enabled = false;
            _Txt_cdescripcion.Enabled = true;
            _Txt_cconceptocomp.Enabled = true;
            _Chk_Sistema.Enabled = true;
            _Cb_ctypcompro.Enabled = true;
            _Dg_GridDeta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_GridDeta.ReadOnly = false;
            _Dg_GridDeta.Columns[0].ReadOnly = true;
            _Dg_GridDeta.Columns[1].ReadOnly = true;
            _Dg_GridDeta.Columns[4].ReadOnly = true;
            _Dg_GridDeta.AllowUserToAddRows = true;
            _Tb_Tab.SelectTab(1);
            _Str_MyProceso = "M";
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Txt_cidproceso.Enabled = true;
            _Txt_cdescripcion.Enabled = true;
            _Txt_cconceptocomp.Enabled = true;
            _Cb_ctypcompro.Enabled = true;
            _Chk_Sistema.Enabled = true;
            _Dg_GridDeta.ClearSelection();
            _Dg_GridDeta.Rows.Clear();
            _Dg_GridDeta.AllowUserToAddRows = true;
            _Dg_GridDeta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_GridDeta.ReadOnly = false;
            _Dg_GridDeta.Columns[0].ReadOnly = true;
            _Dg_GridDeta.Columns[1].ReadOnly = true;
            _Dg_GridDeta.Columns[4].ReadOnly = true;
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectTab(1);
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Str_MyProceso = "A";
        }

        public bool _Mtd_Guardar()
        {
            string _Str_DelSistema = "";
            string _Str_CamposSave, _Str_ValoresSave,_Str_Id="";
            string _Str_Natu="";
            string _Str_TpoDoc;
            bool _Bol_R = false;
            bool _Bol_Val = false;
            int _Int_cideprocesod = 0;
            int i = 0;
            int f, fc;
            _Dg_GridDeta.EndEdit();
            for (f = 0; f < (_Dg_GridDeta.Rows.Count); f++)
            {
                fc = f + 1;
                if (Convert.ToString(_Dg_GridDeta[1, f].Value).Length > 0)
                {
                    if (Convert.ToString(_Dg_GridDeta[4, f].Value) == "" || Convert.ToString(_Dg_GridDeta[4, f].Value) == "...")
                    {
                        MessageBox.Show("Se necesita en Valor para " + _Dg_GridDeta.Columns[4].HeaderText + " en la Fila" + fc.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Bol_Val = true;
                    }
                    else
                    {
                        if (Convert.ToString(_Dg_GridDeta[5, f].Value) == "" || Convert.ToString(_Dg_GridDeta[5, f].Value) == "...")
                        {
                            MessageBox.Show("Se necesita en Valor para " + _Dg_GridDeta.Columns[4].HeaderText + " en la Fila" + fc.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Bol_Val = true;
                        }
                        else
                        {
                            if (Convert.ToString(_Dg_GridDeta[3, f].Value) == "" || Convert.ToString(_Dg_GridDeta[3, f].Value) == "...")
                            {
                                MessageBox.Show("Se necesita en Valor para " + _Dg_GridDeta.Columns[3].HeaderText + " en la Fila" + fc.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _Bol_Val = true;
                            }
                        }
                    }
                }
            }

            if (_Txt_cidproceso.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_cidproceso, "Se necesita el Código.");
                _Bol_Val = true;
            }

            if (_Txt_cconceptocomp.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_cconceptocomp, "Se necesita el Concepto.");
                _Bol_Val = true;
            }

            if (_Txt_cdescripcion.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_cdescripcion, "Se necesita la Descripción.");
                _Bol_Val = true;
            }

            if (_Cb_ctypcompro.SelectedValue.ToString() == "nulo")
            {
                _Er_Error.SetError(_Cb_ctypcompro, "Se necesita el Tipo de Comprobante.");
                _Bol_Val = true;
            }

            if (_Bol_Val == false)
            {
                //Guardo Encabezado
                if (_Cb_ctypcompro.SelectedValue.ToString() == "nulo")
                { _Str_TpoDoc = "null"; }
                else
                { _Str_TpoDoc = "'" + _Cb_ctypcompro.SelectedValue.ToString() + "'"; }
                if (_Chk_Sistema.Checked)
                {
                    _Str_DelSistema = "1";
                }
                else
                {
                    _Str_DelSistema = "0";
                }
                _Str_CamposSave = "cidproceso, cdescripcion, cconceptocomp, ctypcompro, cuseradd, cdelete,cprocesistema,cdateadd";
                _Str_ValoresSave = "'" + _Txt_cidproceso.Text + "','" + _Txt_cdescripcion.Text.Trim().ToUpper() + "','" + _Txt_cconceptocomp.Text.Trim().ToUpper() + "'," + _Str_TpoDoc + ",'" + Frm_Padre._Str_Use + "',0," + _Str_DelSistema + ",GETDATE()";
                try
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TPROCESOSCONT", _Str_CamposSave, _Str_ValoresSave);
                }
                catch { }
                //Guardo Detalle
                _Str_CamposSave = "cidproceso, cideprocesod, ccount, cvariable, cnaturaleza";
                if ((_Dg_GridDeta.Rows.Count - 1) == 0)
                {
                    MessageBox.Show("Faltan Datos en el Detalle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                }
                else
                {
                    for (i = 0; i < (_Dg_GridDeta.Rows.Count); i++)
                    {
                        if (Convert.ToString(_Dg_GridDeta[1, i].Value).Length > 0)
                        {
                            if (_Dg_GridDeta[5, i].Value.ToString() == "DEBE")
                            { _Str_Natu = "'D'"; }
                            if (_Dg_GridDeta[5, i].Value.ToString() == "HABER")
                            { _Str_Natu = "'H'"; }
                            _Int_cideprocesod++;
                            _Str_ValoresSave = "'" + _Txt_cidproceso.Text + "'," + _Int_cideprocesod.ToString() + ",'" + _Dg_GridDeta[1, i].Value.ToString() + "','" + _Dg_GridDeta[3, i].Value.ToString() + "'," + _Str_Natu;
                            Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TPROCESOSCONTD", _Str_CamposSave, _Str_ValoresSave);
                        }
                    }
                    _Bol_R = true;
                }
                if (_Bol_R)
                {
                    _Mtd_Ini();
                    _Mtd_CargarData(_Str_Id);
                    _Tb_Tab.SelectedIndex = 0;
                    MessageBox.Show("Se guardó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return _Bol_R;
        }

        public bool _Mtd_Editar()
        {
            string _Str_DelSistema = "";
            string _Str_Sql, _Str_CamposUpd, _Str_CamposWhereUpd, _Str_Id="";
            string _Str_CamposSave, _Str_ValoresSave;
            string _Str_Natu = "";
            string _Str_TpoDoc;
            bool _Bol_R = false;
            bool _Bol_Val = false;
            int _Int_cideprocesod = 0;
            int i = 0;
            int f, fc;
            _Dg_GridDeta.EndEdit();
            for (f = 0; f < (_Dg_GridDeta.Rows.Count); f++)
            {
                fc = f + 1;
                if (Convert.ToString(_Dg_GridDeta[1, f].Value).Length > 0)
                {
                    if (Convert.ToString(_Dg_GridDeta[4, f].Value) == "" || Convert.ToString(_Dg_GridDeta[4, f].Value) == "...")
                    {
                        MessageBox.Show("Se necesita en Valor para " + _Dg_GridDeta.Columns[4].HeaderText + " en la Fila" + fc.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Bol_Val = true;
                    }
                    else
                    {
                        if (Convert.ToString(_Dg_GridDeta[5, f].Value) == "" || Convert.ToString(_Dg_GridDeta[5, f].Value) == "...")
                        {
                            MessageBox.Show("Se necesita en Valor para " + _Dg_GridDeta.Columns[5].HeaderText + " en la Fila" + fc.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Bol_Val = true;
                        }
                        else
                        {
                            if (Convert.ToString(_Dg_GridDeta[3, f].Value) == "" || Convert.ToString(_Dg_GridDeta[3, f].Value) == "...")
                            {
                                MessageBox.Show("Se necesita en Valor para " + _Dg_GridDeta.Columns[3].HeaderText + " en la Fila" + fc.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _Bol_Val = true;
                            }
                        }
                    }
                }
            }

            if (_Txt_cconceptocomp.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_cconceptocomp, "Se necesita el Concepto.");
                _Bol_Val = true;
            }

            if (_Txt_cdescripcion.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_cdescripcion, "Se necesita la Descripción.");
                _Bol_Val = true;
            }

            if (_Cb_ctypcompro.SelectedValue.ToString() == "nulo")
            {
                _Er_Error.SetError(_Cb_ctypcompro, "Se necesita el Tipo de Comprobante.");
                _Bol_Val = true;
            }

            if (_Bol_Val == false)
            {
                _Str_Id = _Txt_cidproceso.Text;
                //Guardo Encabezado
                if (Convert.ToString(_Cb_ctypcompro.SelectedValue) == "nulo" || Convert.ToString(_Cb_ctypcompro.SelectedValue) == "")
                { _Str_TpoDoc = "null"; }
                else
                { _Str_TpoDoc = "'" + _Cb_ctypcompro.SelectedValue.ToString() + "'"; }
                if (_Chk_Sistema.Checked)
                {
                    _Str_DelSistema = "1";
                }
                else
                {
                    _Str_DelSistema = "0";
                }
                _Str_CamposUpd = "cidproceso='" + _Txt_cidproceso.Text + "', cdescripcion='" + _Txt_cdescripcion.Text.Trim().ToUpper() + "', cconceptocomp='" + _Txt_cconceptocomp.Text.Trim().ToUpper() + "', ctypcompro=" + _Str_TpoDoc + ", cuserupd='" + Frm_Padre._Str_Use + "', cdateupd=GETDATE(),cprocesistema=" + _Str_DelSistema;
                _Str_CamposWhereUpd = "cidproceso='" + _Txt_cidproceso.Text + "'";
                //_Str_ValoresSave = "'" + _Txt_cidproceso.Text + "','" + _Txt_cdescripcion.Text.Trim() + "','" + _Txt_cconceptocomp.Text.Trim() + "'," + _Str_TpoDoc;
                try
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TPROCESOSCONT", _Str_CamposUpd, _Str_CamposWhereUpd);
                }
                catch { }
                //Elimino TODO el Detalle
                _Str_Sql = "DELETE FROM TPROCESOSCONTD WHERE cidproceso='" + _Txt_cidproceso.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                                //Guardo Detalle
                _Str_CamposSave = "cidproceso, cideprocesod, ccount, cvariable, cnaturaleza";
                if ((_Dg_GridDeta.Rows.Count - 1) == 0)
                {
                    MessageBox.Show("Faltan Datos en el Detalle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (i = 0; i < (_Dg_GridDeta.Rows.Count); i++)
                    {
                        if (Convert.ToString(_Dg_GridDeta[0, i].Value).Trim().Length > 0)
                        {
                            if (_Dg_GridDeta[5, i].Value.ToString() == "DEBE")
                            { _Str_Natu = "'D'"; }
                            if (_Dg_GridDeta[5, i].Value.ToString() == "HABER")
                            { _Str_Natu = "'H'"; }
                            _Int_cideprocesod++;
                            _Str_ValoresSave = "'" + _Txt_cidproceso.Text + "'," + _Int_cideprocesod.ToString() + ",'" + _Dg_GridDeta[1, i].Value.ToString() + "','" + _Dg_GridDeta[3, i].Value.ToString() + "'," + _Str_Natu;
                            Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TPROCESOSCONTD", _Str_CamposSave, _Str_ValoresSave);
                            _Bol_R = true;
                        }
                    }
                }
                
                if (_Bol_R)
                {
                    _Mtd_Ini();
                    _Mtd_CargarData(_Str_Id);
                    _Tb_Tab.SelectedIndex = 1;
                    MessageBox.Show("Se guardó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return _Bol_R;
        }

        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql;
            try
            {
                _Str_Sql = "SELECT cprocesistema FROM TPROCESOSCONT WHERE cidproceso='" + _Txt_cidproceso.Text + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0])!="1")
                    {
                        _Str_Sql = "DELETE FROM TPROCESOSCONT WHERE cidproceso='" + _Txt_cidproceso.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Mtd_Ini();
                        _Tb_Tab.SelectedIndex = 0;
                        MessageBox.Show("Se eliminó correctamente el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = true;
                    }
                }
                if (!_Bol_R)
                {
                    MessageBox.Show("No se puede eliminar este proceso porque es un proceso del sistema.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                _Bol_R = false;
            }
            return _Bol_R;
        }

        private void _Dg_GridDeta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _Int_Val=0;
            string _Str_CodCuenta = "", _Str_Sql= "", _Str_Auxiliar="", _Str_CuentaName="";
            if (_Str_MyProceso != "" && _Dg_GridDeta.RowCount>0)
            {
                if (e.ColumnIndex == 2)//El boton de Buscar
                {
                    //Llamo al formulario de busqueda de productos
                    Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
                    _Frm_Vista.ShowDialog();
                    _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
                    if (_Str_CodCuenta != "")
                    {
                        if (_Str_CodCuenta == "PRV.X" || _Str_CodCuenta == "BNC.X")
                        {
                            _Str_Auxiliar = "";
                            if (_Str_CodCuenta == "PRV.X")
                            {
                                _Str_CuentaName = "PARAMETRO DE CUENTA DE PROVEEDOR";
                            }
                            else if (_Str_CodCuenta == "BNC.X")
                            {
                                _Str_CuentaName = "PARAMETRO DE CUENTA DE BANCO";
                            }
                        }
                        else
                        {
                            _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            _Str_CuentaName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim().ToUpper();
                        }

                        if (_Mtd_ValidarGridDetaAdd(_Frm_Vista._Str_FrmNodeSelec, _Str_Auxiliar) == false)
                        {
                            _Dg_GridDeta[1, e.RowIndex].Value = _Str_CodCuenta;
                            _Dg_GridDeta[4, e.RowIndex].Value = _Str_CuentaName;
                            if (_Dg_GridDeta.RowCount == 1)
                            {
                                _Dg_GridDeta.NotifyCurrentCellDirty(true);
                                _Int_Val = 1;
                            }
                            else
                            {
                                if (Convert.ToString(_Dg_GridDeta[0, e.RowIndex].Value) == "")
                                {
                                    _Int_Val = Convert.ToInt16(_Dg_GridDeta[0, (_Dg_GridDeta.RowCount - 2)].Value) + 1;
                                    _Dg_GridDeta.NotifyCurrentCellDirty(true);
                                }
                                else
                                { _Int_Val = Convert.ToInt16(_Dg_GridDeta[0, e.RowIndex].Value); }
                            }
                            _Dg_GridDeta[0, e.RowIndex].Value = _Int_Val;
                            _Dg_GridDeta[5, e.RowIndex].Value = "...";
                            _Dg_GridDeta.AllowUserToAddRows = false;
                        }
                    }
                    _Frm_Vista = null;
                    _Dg_GridDeta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            
        }

        private bool _Mtd_ValidarGridDetaAdd(string _Pr_Str_Val, string _Pr_Str_ValA)
        {
            int i = 0;
            bool _Bol_R;
            _Bol_R = false;
            for (i = 0; i < (_Dg_GridDeta.Rows.Count); i++)
            {
                if (Convert.ToString(_Dg_GridDeta[1, i].Value).Length > 0)
                {
                    if (_Dg_GridDeta[1, i].Value.ToString() == _Pr_Str_Val && _Dg_GridDeta[3, i].Value.ToString() == _Pr_Str_ValA)
                    {
                        MessageBox.Show("La Cuenta ya fue Ingresada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _Bol_R = true;
                        break;
                    }
                }
            }
            return _Bol_R;
        }

        private bool _Mtd_ValidarGridCont(DataGridView _Pr_Dg, int[] _Pr_Int_Col)
        {
            int _Int_Filas;
            if (_Pr_Dg.AllowUserToAddRows)
            { _Int_Filas = _Pr_Dg.RowCount - 1; }
            else
            { _Int_Filas = _Pr_Dg.RowCount; }
            for (int f = 0; f < _Int_Filas; f++)
            {
                for (int i = 0; i < _Pr_Int_Col.Length; i++)
                {
                    if (Convert.ToString(_Pr_Dg[_Pr_Int_Col[i], f].Value) == "" || Convert.ToString(_Pr_Dg[_Pr_Int_Col[i], f].Value)=="...")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void _Dg_GridDeta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (e.ColumnIndex == 3)
                {
                    if (_Mtd_VerifVariableAdd(Convert.ToString(_Dg_GridDeta[3, e.RowIndex].Value),e.RowIndex))
                    {
                        MessageBox.Show("Ya seleccionó la variable " + Convert.ToString(_Dg_GridDeta[3, e.RowIndex].Value), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Dg_GridDeta[3, e.RowIndex].Value = null;
                    }
                }
                int[] _Int_VecCol = new int[3];
                _Int_VecCol[0] = 4;
                _Int_VecCol[1] = 5;
                _Int_VecCol[2] = 3;
                if (_Mtd_ValidarGridCont(_Dg_GridDeta, _Int_VecCol))
                {
                    _Dg_GridDeta.AllowUserToAddRows = false;
                }
                else
                {
                    _Dg_GridDeta.AllowUserToAddRows = true;
                }
                _Dg_GridDeta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void _CMen_A_Del_Click(object sender, EventArgs e)
        {
            if (_Dg_GridDeta.Rows[_Dg_GridDeta.CurrentCell.RowIndex].IsNewRow == false)
            {
                if (_Dg_GridDeta.RowCount > 1)
                {
                    _Dg_GridDeta.Rows.RemoveAt(_Dg_GridDeta.CurrentCell.RowIndex);
                }
                else
                {
                    for (int _I = 0; _I < _Dg_GridDeta.Columns.Count; _I++)
                    {
                        _Dg_GridDeta[_I, 0].Value = null;
                    }
                }
            }
        }

        private void _Txt_cdescripcion_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_cdescripcion, "");
        }

        private void _Txt_cconceptocomp_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_cconceptocomp, "");
        }

        private void _Cb_ctypcompro_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_ctypcompro, "");
        }

        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_cidproceso.Text != "")
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }

        }

        private void _Txt_cidproceso_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_cidproceso, "");
        }

        private void _Txt_cdescripcion_EnabledChanged(object sender, EventArgs e)
        {
            if (_Txt_cdescripcion.Enabled == true && _Txt_cidproceso.Text == "")//Estoy Agregando
            {
                _Txt_cidproceso.Enabled = true;
            }
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

        private void _Dg_GridDeta_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    _Lbl_DgCuentasInfo.Visible = true;
                }
                else
                {
                    _Lbl_DgCuentasInfo.Visible = false;
                }
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_CargarBusqueda();
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_cidproceso.Text.Trim() == "" & e.TabPageIndex != 0)
            {
                e.Cancel = true;
            }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                string _Str_Cod = _Dg_Grid[0, e.RowIndex].Value.ToString();
                Cursor = Cursors.WaitCursor;
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                _Mtd_Ini();
                _Mtd_CargarData(_Str_Cod);
                _Tb_Tab.SelectTab(1);
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
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
        private bool _Mtd_VerifVariableAdd(string _Pr_Str_Variable, int _Pr_Int_Row)
        {
            bool _Bol_R = false;
            foreach (DataGridViewRow _DgRow in _Dg_GridDeta.Rows)
            {
                if (_DgRow.Index != _Pr_Int_Row)
                {
                    if (Convert.ToString(_DgRow.Cells[3].Value).Trim() == _Pr_Str_Variable)
                    {
                        _Bol_R = true;
                    }
                }
            }
            return _Bol_R;
        }

        private void _CMen_A_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_GridDeta.CurrentCell == null || _Str_MyProceso.Length==0)
            {
                e.Cancel = true;
            }
        }

        private void _Dg_GridDeta_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private bool _Mtd_VerifVariable(string _Pr_Str_Valor)
        {
            bool _Bol_Existe = false;
            string[] _MyVec_Obj = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            foreach (string _Str_Cad in _MyVec_Obj)
            {
                if (_Str_Cad == _Pr_Str_Valor)
                {
                    _Bol_Existe = true;
                }
            }
            return _Bol_Existe;
        }

    }
}