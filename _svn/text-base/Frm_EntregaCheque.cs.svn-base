using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace T3
{
    public partial class Frm_EntregaCheque : Form
    {
        public Frm_EntregaCheque()
        {
            InitializeComponent();
        }

        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private void _Mtd_CargarBusqueda()
        {
            object[] _Str_RowNew = new object[6];
            string _Str_Sql = "";
            _Str_Sql = "SELECT cidemisioncheq,cconcepto,c_nomb_abreviado,dbo.Fnc_Formatear(cmontototal) AS cmontototal, cproveedor, CONVERT(VARCHAR,cfechaimprimio,103) AS cfechaimprimio FROM VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND centregado=0 AND cimpimiocheq=1 and cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND canulado='0' AND cfpago='CHEQ'";
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " AND cproveedor='" + Convert.ToString(_Cb_ProveedorFind.SelectedValue) + "'"; }
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " AND cglobal=" + Convert.ToString(_Cb_TpoProveFind.SelectedValue); }
            if (_Cb_CatProveFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND ccatproveedor='" + Convert.ToString(_Cb_CatProveFind.SelectedValue) + "'";
            }
            _Str_Sql = _Str_Sql + " ORDER BY cidemisioncheq";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Find.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Find.Rows.Add(_Str_RowNew);
            }
            _Dg_Find.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void _Mtd_CargarTpoProveFind()
        {
            _Cb_TpoProveFind.SelectedIndexChanged -= new System.EventHandler(_Cb_TpoProveFind_SelectedIndexChanged);
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_TpoProveFind.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cb_TpoProveFind.DataSource = _myArrayList;
            _Cb_TpoProveFind.DisplayMember = "Display";
            _Cb_TpoProveFind.ValueMember = "Value";
            _Cb_TpoProveFind.SelectedValue = "nulo";
            _Cb_TpoProveFind.DataSource = _myArrayList;
            _Cb_TpoProveFind.SelectedIndex = 0;
            _Cb_TpoProveFind.SelectedIndexChanged += new System.EventHandler(_Cb_TpoProveFind_SelectedIndexChanged);
        }

        private void _Mtd_CargarCatProve(string _P_Str_Tipo)
        {
            myUtilidad._Mtd_CargarCombo(_Cb_CatProveFind, "Select ccatproveedor,cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + _P_Str_Tipo + "'");
        }

        private void _Mtd_CargarProvee()
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (Convert.ToString(_Cb_TpoProveFind.SelectedValue) == "1")
            {
                _Str_Sql = _Str_Sql + " AND (cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')";
                if (_Cb_CatProveFind.SelectedIndex > 0)
                { _Str_Sql = _Str_Sql + " AND TPROVEEDOR.ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'"; }
            }
            else if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " (cglobal='" + _Cb_TpoProveFind.SelectedValue.ToString() + "' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "')";
                if (_Cb_CatProveFind.SelectedIndex > 0 && _Cb_CatProveFind != null)
                { _Str_Sql = _Str_Sql + " and TPROVEEDOR.ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'"; }
            }
            else
            { _Str_Sql = _Str_Sql + " AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "') OR (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            _Str_Sql = _Str_Sql + " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            _Cb_ProveedorFind.SelectedIndexChanged -= new System.EventHandler(_Cb_ProveedorFind_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_ProveedorFind, _Str_Sql);
            _Cb_ProveedorFind.SelectedIndexChanged += new System.EventHandler(_Cb_ProveedorFind_SelectedIndexChanged);

        }

        public void _Mtd_Ini()
        {
            _Txt_EmisionId.Text = "";
            _Txt_OrdPagoId.Text = "";
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
            _Pnl_DatosPerso.Parent = this;
            _Pnl_DatosPerso.BringToFront();
            if (_Cb_TpoProveFind.DataSource != null)
            { _Cb_TpoProveFind.SelectedIndex = 0; }
            if (_Cb_CatProveFind.DataSource != null)
            { _Cb_CatProveFind.SelectedIndex = 0; }
            if (_Cb_ProveedorFind.DataSource != null)
            { _Cb_ProveedorFind.SelectedIndex = 0; }

            _Txt_TpoPago.Text = "";
            _Txt_FormaPago.Text = "";
            _Cb_Banco.SelectedIndex = -1;
            _Cb_Banco.Text = "";
            _Cb_Cuenta.SelectedIndex = -1;
            _Cb_Cuenta.Text = "";

            _Txt_Doc.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_CantDescrip.Text = "";
            _Txt_Persona.Text = "";
            _Txt_Monto.Text = "";
            _Dt_ChequeEmi.MinDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_ChequeEmi.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();

            _Txt_FirmaSol.Text = "";
            _Txt_FirmaCont.Text = "";
            _Txt_FirmaAprob.Text = "";
            _Pnl_DatosPerso.Visible = false;
            _Pnl_Clave.Visible = false;

            _Mtd_Bloquear(false);
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_EmisionId.Enabled = false;
            _Txt_OrdPagoId.Enabled = false;
            _Bt_EntregarCheq.Enabled = false;
            _Bt_FirmaSol.Enabled = false;
            _Bt_FirmaCont.Enabled = false;
            _Bt_FirmaAprob.Enabled = false;
            _Txt_TpoPago.Enabled = false;
            _Txt_FormaPago.Enabled = false;
            _Cb_Banco.Enabled = _Pr_Bol_A;
            _Cb_Cuenta.Enabled = _Pr_Bol_A;
            _Txt_Concepto.Enabled = _Pr_Bol_A;
            _Txt_Persona.Enabled = _Pr_Bol_A;
            _Dt_Fecha.Enabled = false;
            _Dt_ChequeEmi.Enabled = _Pr_Bol_A;
            _Txt_CantDescrip.Enabled = false;
            _Txt_Monto.Enabled = false;
            _Txt_FirmaSol.Enabled = false;
            _Txt_FirmaCont.Enabled = false;
            _Txt_FirmaAprob.Enabled = false;
            _Txt_Doc.Enabled = false;
            _Bt_OrdPagoGo.Enabled = false;
        }

        private void Frm_EntregaCheque_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Ini();
            _Mtd_CargarTpoProveFind();
            _Mtd_CargarProvee();
            if (_Cb_TpoProveFind.DataSource != null)
            { _Cb_TpoProveFind.SelectedIndex = 0; }
            if (_Cb_ProveedorFind.DataSource != null)
            { _Cb_ProveedorFind.SelectedIndex = 0; }
            _Mtd_CargarBusqueda();
        }

        private void _Cb_ProveedorFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Str_Sql = "";

            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
                _Str_Sql = "Select cglobal,ccatproveedor from TPROVEEDOR WHERE cdelete=0" +
                       " AND ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1 AND cproveedor='" + Convert.ToString(_Cb_ProveedorFind.SelectedValue) + "'";
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {//CARGO EL TIPO Y CATEGORIA EN LOS COMBOS
                    _Cb_CatProveFind.SelectedIndexChanged -= new System.EventHandler(_Cb_CatProveFind_SelectedIndexChanged);
                    _Cb_TpoProveFind.SelectedValue = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                    _Mtd_CargarCatProve(Convert.ToString(_Cb_TpoProveFind.SelectedValue));
                    _Cb_CatProveFind.SelectedValue = Convert.ToString(_Ds_A.Tables[0].Rows[0][1]);
                    _Cb_CatProveFind.SelectedIndexChanged += new System.EventHandler(_Cb_CatProveFind_SelectedIndexChanged);
                    
                }
            }
            else
            {
                if (_Cb_TpoProveFind.SelectedIndex <= 0)
                {
                    _Cb_CatProveFind.DataSource = null;
                }
            }
        }

        private void _Cb_CatProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_CatProveFind.SelectedIndex > 0)
            {
                _Mtd_CargarProvee();
            }
            else
            {
                _Mtd_CargarProvee();
                _Cb_ProveedorFind.SelectedIndex = 0;
            }
        }

        private void _Cb_TpoProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                _Mtd_CargarCatProve(_Cb_TpoProveFind.SelectedValue.ToString());
            }
            else
            {
                _Cb_CatProveFind.DataSource = null;
                _Mtd_CargarProvee();
                _Cb_ProveedorFind.SelectedIndex = 0;
            }
            
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_CargarBusqueda();
        }

        private void Frm_EntregaCheque_Activated(object sender, EventArgs e)
        {
            //CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            _Mtd_BotonesMenu();
            _Mtd_Color_Estandar(this);
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

        private void Frm_EntregaCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Find_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Find.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarData(Convert.ToString(_Dg_Find[0, e.RowIndex].Value));
                Cursor = Cursors.Default;
                _Tb_Tab.SelectTab(1);
                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTREGA_CHEQUE"))
                {
                    _Bt_EntregarCheq.Enabled = true;
                }
            }
            
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT * FROM VST_EMICHEQTRANSM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq=" + _Pr_Str_Id;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_EmisionId.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidemisioncheq"]);
                _Txt_OrdPagoId.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidordpago"]);
                _Txt_TpoPago.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctippagonombre"]);
                _Txt_FormaPago.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpagonombre"]);
                _Cb_Banco.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cbanconame"]);

                _Cb_Cuenta.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumcuentadname"]);
                _Txt_Doc.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumcheqtransac"]);
                _Txt_Monto.Text = Convert.ToDouble(_Ds_Data.Tables[0].Rows[0]["cmontototal"]).ToString("#,##0.00");
                _Txt_CantDescrip.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cmontototaltext"]);
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["c_nomb_fiscal"]).Trim().Length == 0)
                {
                    _Txt_Persona.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpagarse"]);
                    _Txt_Persona.Tag = 0;
                }
                else
                {
                    _Txt_Persona.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["c_nomb_fiscal"]);
                    _Txt_Persona.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]);
                }
                _Dt_Fecha.Value = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfecha"]);
                _Dt_ChequeEmi.MinDate = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfechaemision"]);
                _Dt_ChequeEmi.Value = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfechaemision"]);
                _Txt_Concepto.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cconcepto"]);

                _Txt_FirmaSol.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cusersolicitantename"]);
                _Txt_FirmaSol.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cusersolicitante"]);

                _Txt_FirmaCont.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuserfirmante1name"]);
                _Txt_FirmaCont.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuserfirmante1"]);

                _Txt_FirmaAprob.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuseraprobadorname"]);
                _Txt_FirmaAprob.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuseraprobador"]);
            }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (_Txt_Clave.Text.Trim() != "")
            {
                byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
                byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
                string cod = BitConverter.ToString(valorhash);
                cod = cod.Replace("-", "");
                _Str_Sql = "SELECT cpassw FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use + "' and cpassw='" + cod + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {//COINCIDE
                    _Pnl_DatosPerso.Left = (this.Width / 2) - (_Pnl_DatosPerso.Width / 2);
                    _Pnl_DatosPerso.Top = (this.Height / 2) - (_Pnl_DatosPerso.Height / 2);
                    _Pnl_Clave.Visible = false;
                    _Pnl_DatosPerso.Visible = true;
                    _Txt_Nombre.Focus();

                    
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";

            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }

        private void _Bt_EntregarCheq_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Lbl_TituloClave.Text = "Entrega de Cheque";
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Text = "";
            _Txt_Clave.Focus();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                
            }
            else
            {
                _Tb_Tab.Enabled = true; _Lbl_TituloClave.Text = "";
            }
        }

        private void _Bt_OkDatos_Click(object sender, EventArgs e)
        {
            bool _Bol_Val = false;
            string _Str_Sql = "";
            if (_Txt_Nombre.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_Nombre, "Ingrese el Nombre de la Persona.");
                _Bol_Val = true;
            }
            if (_Txt_Cedula.Text.Trim() == "")
            {
                _Er_Error.SetError(_Txt_Cedula, "Ingrese la Cédula de la Persona.");
                _Bol_Val = true;
            }
            if (!_Bol_Val)
            {
                _Str_Sql = "UPDATE TEMICHEQTRANSM SET centregado=1,cpersrecibename='" + _Txt_Nombre.Text.Trim().ToUpper() + "',cpersrecibeced='" + _Txt_Cedula.Text.Replace(".","") + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("Transacción realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        private void _Bt_DatosCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Pnl_DatosPerso_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_DatosPerso.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Cedula.Text = "";
                _Txt_Nombre.Text = "";
                
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Txt_Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            myUtilidad._Mtd_Valida_Numeros(_Txt_Cedula, e, 8, 0);
        }

        private void _Txt_Cedula_Enter(object sender, EventArgs e)
        {
            if (_Txt_Cedula.Text != "")
            {
                _Txt_Cedula.Text = Convert.ToDouble(_Txt_Cedula.Text).ToString("###0");
            }
        }

        private void _Txt_Cedula_Leave(object sender, EventArgs e)
        {
            if (_Txt_Cedula.Text != "")
            {
                _Txt_Cedula.Text = Convert.ToDouble(_Txt_Cedula.Text).ToString("#,##0");
            }
        }

        private void _Dg_Find_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
    }
}