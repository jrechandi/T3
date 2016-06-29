using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConciliacionBancaria : Form
    {
        public Frm_ConciliacionBancaria()
        {
            InitializeComponent();
        }

        string _Str_ConcilFdesde = "";
        string _Str_MyProceso = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _MyFormato = new clslibraryconssa._Cls_Formato("es-VE");

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Lbl_Status.Text = "...";
            _Txt_ConcilId.Text = "";
            _Txt_ConcilFecha.Text = "";
            _Str_ConcilFdesde = "";
            _Pnl_FechaDesde.Parent = this;
            _Pnl_FindFechas.Visible = false;
            if (_Cb_Banco.DataSource != null)
            { _Cb_Banco.SelectedIndex = 0; }
            _Dg_VerMovCont.ReadOnly = true;
            _Dg_VerMovBanco.ReadOnly = true;
            _Dg_MovCont.ReadOnly = true;
            _Dg_MovBanco.ReadOnly = true;
            _Dg_MovCont.Rows.Clear();
            _Dg_MovBanco.Rows.Clear();
            _Mtd_IniResumen(false);
            _Mtd_Bloquear(false);
            _Mtd_CargarVerBancos();
        }

        private void _Mtd_IniResumen(bool _Pr_Bol_Botones)
        {
            _Lbl_SaldoBanco.Text = "0";
            _Lbl_SaldoContable.Text = "0";
            _Lbl_ChequeTranMonto.Text = "0";
            _Bt_ChequeTran.Enabled = _Pr_Bol_Botones;
            _Lbl_DepNoRegContMonto.Text = "0";
            _Bt_DepNoRegCont.Enabled = _Pr_Bol_Botones;
            _Lbl_DepNoRegBancoMonto.Text = "0";
            _Bt_DepNoRegBanco.Enabled = _Pr_Bol_Botones;
            _Lbl_NDNoRegContMonto.Text = "0";
            _Bt_NDNoRegCont.Enabled = _Pr_Bol_Botones;
            _Lbl_DifConciMonto.Text = "0";
            _Bt_DifConci.Enabled = _Pr_Bol_Botones;
            _Bt_NDnoRegBanco.Enabled = _Pr_Bol_Botones;
            _Lbl_NDnoRegBancoMonto.Text = "0";
            _Bt_Conciliar.Enabled = _Pr_Bol_Botones;
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Bt_Conciliar.Enabled = false;
            _Bt_Concilicion.Enabled = false;
            _Txt_ConcilFecha.Enabled = false;
            _Txt_ConcilId.Enabled = false;
            _Bt_NDnoRegBanco.Enabled = false;
            _Tst_MovCont.Enabled = false;
            _Tst_MovBanco.Enabled = false;
            _Dg_MovCont.ReadOnly = true;
            _Dg_MovBanco.ReadOnly = true;
            _Cb_Banco.Enabled = _Pr_Bol_A;
            _Cb_Cuenta.Enabled = _Pr_Bol_A;
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectTab(0);
            _Mtd_CargarBancos();
            _Str_MyProceso = "A";
            _Lbl_Status.Text = "Nueva Conciliación";
            _Cb_Banco.Focus();
            _Txt_ConcilFecha.Text = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
            _Mtd_BotonesMenu();
            
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
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true; ;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Cb_Banco.SelectedIndex > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
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

        private void _Mtd_CargarBancos()
        {
            string _Str_Sql = "select dbo.TBANCO.cbanco,dbo.TBANCO.cname from dbo.TBANCO WHERE  dbo.TBANCO.cdelete=0 AND dbo.TBANCO.ccompany='" + Frm_Padre._Str_Comp + "'";
            _Cb_Banco.SelectedIndexChanged -= new System.EventHandler(_Cb_Banco_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_Banco, _Str_Sql);
            _Cb_Banco.SelectedIndexChanged += new System.EventHandler(_Cb_Banco_SelectedIndexChanged);
        }

        private void _Mtd_CargarCtasBanco(string _Pr_Str_Banco)
        {
            string _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Pr_Str_Banco + "' and cdelete=0";
            _Cb_Cuenta.SelectedIndexChanged -= new System.EventHandler(_Cb_Cuenta_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_Cuenta, _Str_Sql);
            _Cb_Cuenta.SelectedIndexChanged += new System.EventHandler(_Cb_Cuenta_SelectedIndexChanged);
        }

        private void _Mtd_CargarVerBancos()
        {
            string _Str_Sql = "select dbo.TBANCO.cbanco,dbo.TBANCO.cname from dbo.TBANCO WHERE  dbo.TBANCO.cdelete=0 AND dbo.TBANCO.ccompany='" + Frm_Padre._Str_Comp + "'";
            _Cb_VerBanco.SelectedIndexChanged -= new System.EventHandler(_Cb_VerBanco_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_VerBanco, _Str_Sql);
            _Cb_VerBanco.SelectedIndexChanged += new System.EventHandler(_Cb_VerBanco_SelectedIndexChanged);
        }

        private void _Mtd_CargarVerCtasBanco(string _Pr_Str_Banco)
        {
            string _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Pr_Str_Banco + "' and cdelete=0";
            _Cb_VerCuenta.SelectedIndexChanged -= new System.EventHandler(_Cb_VerCuenta_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_VerCuenta, _Str_Sql);
            _Cb_VerCuenta.SelectedIndexChanged += new System.EventHandler(_Cb_VerCuenta_SelectedIndexChanged);
        }

        private void _Mtd_CargarMovContable(string _Pr_Str_BancoId, string _Pr_Str_CtaId, int _Pr_Int_TpoFind)
        {
            object[] _Str_RowNew = new object[13];
            string _Str_Sql = "SELECT cnumdocu,coperbanc,coperbancname,cfecha,cdescipcion,cmonto,null,cidmovbanco,ctdocument,cmovdebe,cmovhaber,cmovsaldo,cidcomprob FROM VST_TMOVBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuentad='" + _Pr_Str_CtaId + "' AND canulado=0";
            switch (_Pr_Int_TpoFind)
            {
                case 1: //periodo
                    _Str_Sql = _Str_Sql + " and cfecha between '" + _MyFormato._Mtd_fecha(_Dtp_Desde.Value) + "' and '" + _MyFormato._Mtd_fecha(_Dtp_Hasta.Value) + "'";
                break;

                case 2://no conciliado
                    _Str_Sql = _Str_Sql + " and cconciliado=0";
                break;
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_MovCont.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_MovCont.Rows.Add(_Str_RowNew);
                if (Convert.ToString(_Dg_MovCont[5, _Dg_MovCont.RowCount - 1].Value) != "")
                {
                    _Dg_MovCont[5, _Dg_MovCont.RowCount - 1].Value = Convert.ToDouble(_Dg_MovCont[5, _Dg_MovCont.RowCount - 1].Value).ToString("#,##0.00");
                }
                if (Convert.ToString(_Dg_MovCont[2, _Dg_MovCont.RowCount - 1].Value) != "")
                {
                    _Dg_MovCont[3, _Dg_MovCont.RowCount - 1].Value = Convert.ToDateTime(_Dg_MovCont[3, _Dg_MovCont.RowCount - 1].Value).ToShortDateString();
                }
            }
            _Dg_MovCont.ReadOnly = false;
            foreach (DataGridViewColumn _DgCol in _Dg_MovCont.Columns)
            {
                if (_DgCol.Index != 6)
                {
                    _DgCol.ReadOnly = true;
                }
                else
                {
                    _DgCol.ReadOnly = false;
                }
            }
            
            _Dg_MovCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Lbl_SaldoContable.Text = _Mtd_SaldoMovCont(_Pr_Str_BancoId, _Pr_Str_CtaId).ToString("#,##0.00");
        }

        private void _Mtd_CargarMovBancario(string _Pr_Str_BancoId, string _Pr_Str_CtaId, int _Pr_Int_TpoFind)
        {
            object[] _Str_RowNew = new object[11];
            DataSet _Ds;
            string _Str_Sql = "SELECT cnumdocu,ctipoperacio,ctipoperacioname,cdatemovi,cconcepto,cmontomov,null,cdispbanc,cdispband,csaldomov,coficinabanc FROM VST_DISPBANCARIA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_CtaId + "' AND cdelete=0";
            switch (_Pr_Int_TpoFind)
            {
                case 1: //Ultimo Mov. + Sin Conciliar
                    //OBTENGO EL ULTIMO MOV.
                    string _Str_Sql1 = "";
                    string _Str_UltMov = "";
                    _Str_Sql1 = "SELECT MAX(cdispbanc) FROM TDISPBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "' AND cnumcuenta='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "' AND cdelete=0 and cconciliado_d=0";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql1);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_UltMov = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    }
                    if (_Str_UltMov != "")
                    {
                        _Str_Sql = _Str_Sql + " and cdispbanc=" + _Str_UltMov;
                    }

                    break;

                case 2://Sin Conciliar
                    _Str_Sql = _Str_Sql + " and cconciliado_d=0";
                    break;
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_MovBanco.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_MovBanco.Rows.Add(_Str_RowNew);
                if (Convert.ToString(_Dg_MovBanco[5, _Dg_MovBanco.RowCount - 1].Value) != "")
                {
                    _Dg_MovBanco[5, _Dg_MovBanco.RowCount - 1].Value = Convert.ToDouble(_Dg_MovBanco[5, _Dg_MovBanco.RowCount - 1].Value).ToString("#,##0.00");
                }
                if (Convert.ToString(_Dg_MovBanco[3, _Dg_MovBanco.RowCount - 1].Value) != "")
                {
                    _Dg_MovBanco[3, _Dg_MovBanco.RowCount - 1].Value = Convert.ToDateTime(_Dg_MovBanco[3, _Dg_MovBanco.RowCount - 1].Value).ToShortDateString();
                }
            }
            _Bt_Conciliar.Enabled = true;
            _Dg_MovBanco.ReadOnly = false;
            foreach (DataGridViewColumn _DgCol in _Dg_MovBanco.Columns)
            {
                if (_DgCol.Index != 6)
                {
                    _DgCol.ReadOnly = true;
                }
                else
                {
                    _DgCol.ReadOnly = false;
                }
            }

            _Dg_MovBanco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Lbl_SaldoBanco.Text = _Mtd_SaldoMovBanco(_Pr_Str_BancoId, _Pr_Str_CtaId).ToString("#,##0.00");
        }

        private double _Mtd_SaldoMovBanco(string _Pr_Str_BancoId, string _Pr_Str_CtaId)
        {
            double _Dbl_R = 0;
            string _Str_Sql = "SELECT csaldobanco FROM TDISPBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_CtaId + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_R;
        }

        private double _Mtd_SaldoMovCont(string _Pr_Str_BancoId, string _Pr_Str_CtaId)
        {
            double _Dbl_R = 0;
            string _Str_Sql = "SELECT cmovsaldo FROM TMOVBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuentad='" + _Pr_Str_CtaId + "' AND canulado=0 ORDER BY cidmovbanco";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[_Ds.Tables[0].Rows.Count-1][0]) != "")
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[_Ds.Tables[0].Rows.Count - 1][0]);
                }
            }
            return _Dbl_R;
        }

        private void Frm_ConciliacionBancaria_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
        }

        private void Frm_ConciliacionBancaria_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConciliacionBancaria_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void _Cb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                _Er_Error.SetError(_Cb_Banco, "");
                if (_Cb_Banco.SelectedIndex > 0)
                {
                    _Mtd_CargarCtasBanco(Convert.ToString(_Cb_Banco.SelectedValue));
                }
                else
                {
                    _Cb_Cuenta.DataSource = null;
                }
                _Bt_Concilicion.Enabled = false;
                _Dg_MovCont.Rows.Clear(); _Dg_MovCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_MovBanco.Rows.Clear(); _Dg_MovBanco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Tst_MovCont.Enabled = false;
                _Tst_MovBanco.Enabled = false;
                _Mtd_IniResumen(false);
            }
            
        }

        private void _Cb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso!="")
            {
                _Er_Error.SetError(_Cb_Cuenta, "");
                _Dg_MovCont.Rows.Clear(); _Dg_MovCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_MovBanco.Rows.Clear(); _Dg_MovBanco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Bt_Concilicion.Enabled = true;
                _Tst_MovCont.Enabled = true;
                _Tst_MovBanco.Enabled = false;
                _Mtd_IniResumen(false);
                
            }

        }

        private void _Tst_MovCont_Periodo_Click(object sender, EventArgs e)
        {
            _Pnl_FindFechas.Visible = true;
        }

        private void _Pnl_FindFechas_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_FindFechas.Visible)
            {
                _Dtp_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dg_MovCont.ReadOnly = true;
            }
            else
            {
                _Dg_MovCont.ReadOnly = false;
            }
        }

        private void _Dtp_Desde_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Hasta.MinDate = _Dtp_Desde.Value;
            _Dtp_Desde.Value = _Dtp_Desde.Value;
            _Dtp_Desde.Focus();

        }

        private void _Bt_FindFechaOk_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMovContable(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), 1);
            Cursor = Cursors.Default;
            _Tst_MovBanco.Enabled = true;
        }

        private void _Tst_MovCont_NoConcil_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMovContable(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), 2);
            Cursor = Cursors.Default;
            _Tst_MovBanco.Enabled = true;
        }

        private void _Tst_MovBanco_UltMovYsinConcil_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMovBancario(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), 1);
            Cursor = Cursors.Default;
        }

        private void _Tst_MovBanco_SinConcil_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMovBancario(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), 2);
            Cursor = Cursors.Default;
        }

        private void _Bt_FindFechaCancel_Click(object sender, EventArgs e)
        {
            _Pnl_FindFechas.Visible = false;
        }

        private void _Dg_MovCont_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void _Dg_MovBanco_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                bool _Bol_Cell = false;
                if (e.ColumnIndex == 6)
                {
                    int _Int_MovCont = _Mtd_VerificarColCheck(_Dg_MovCont);
                    int _Int_MovBanco = _Mtd_VerificarColCheck(_Dg_MovBanco);
                    if (Convert.ToString(_Dg_MovBanco[6, e.RowIndex].Value) != "")
                    {
                        _Bol_Cell = Convert.ToBoolean(_Dg_MovBanco[6, e.RowIndex].Value);
                    }
                    if (_Bol_Cell)
                    {
                        if (_Int_MovCont != _Int_MovBanco)
                        {
                            _Dg_MovBanco[6, e.RowIndex].Value = false;
                        }
                    }
                }
            }
        }

        private int _Mtd_VerificarColCheck(DataGridView _Pr_Dg)
        {
            bool _Bol_Cell = false;
            int _Int_C = 0;
            foreach (DataGridViewRow _DgRow in _Pr_Dg.Rows)
            {
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value)!="")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    _Int_C++;
                }
            }
            return _Int_C;
        }

        private void _Dg_MovCont_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (e.ColumnIndex == 6)
                {
                    bool _Bol_Cell = false;
                    int _Int_MovCont = _Mtd_VerificarColCheck(_Dg_MovCont);
                    int _Int_MovBanco = _Mtd_VerificarColCheck(_Dg_MovBanco);
                    if (Convert.ToString(_Dg_MovCont[6, e.RowIndex].Value) != "")
                    {
                        _Bol_Cell = Convert.ToBoolean(_Dg_MovCont[6, e.RowIndex].Value);
                    }
                    if (!_Bol_Cell)
                    {
                        if (_Int_MovCont != _Int_MovBanco)
                        {
                            e.Cancel = true;
                        }
                    }

                }
            }
        }

        private void _Mtd_MarcarGrid()
        {
            bool _Bol_Cell = false;
            bool _Bol_Sw = false;
            int _Int_Error = 1;//1 bs de diferencia
            double _Dbl_MontoMovCont = 0;
            double _Dbl_MontoMovBanco = 0;
            
            double _Dbl_MontoMovBancoInf = 0;
            double _Dbl_MontoMovBancoSup = 0;

            double _Dbl_MontoMovContInf = 0;
            double _Dbl_MontoMovContSup = 0;

            //COMPARO POR MONTOS
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                {
                    _Dbl_MontoMovCont = Convert.ToDouble(_DgRow.Cells[5].Value);
                }

                foreach (DataGridViewRow _DgRowB in _Dg_MovBanco.Rows)
                {
                    _Bol_Cell = false;
                    _Bol_Sw = false;
                    if (Convert.ToString(_DgRowB.Cells[5].Value) != "")
                    {
                        _Dbl_MontoMovBanco = Convert.ToDouble(_DgRowB.Cells[5].Value);
                    }
                    if (_Dbl_MontoMovCont != 0 && _Dbl_MontoMovBanco != 0)
                    {

                        _Dbl_MontoMovBancoInf = _Dbl_MontoMovBanco - _Int_Error;
                        _Dbl_MontoMovBancoSup = _Dbl_MontoMovBanco + _Int_Error;
                        _Dbl_MontoMovContInf = _Dbl_MontoMovCont - _Int_Error;
                        _Dbl_MontoMovContSup = _Dbl_MontoMovCont + _Int_Error;

                        if (_Dbl_MontoMovCont > _Dbl_MontoMovBancoInf && _Dbl_MontoMovCont < _Dbl_MontoMovBancoSup)
                        { _Bol_Sw = true; }
                        if (_Dbl_MontoMovBanco > _Dbl_MontoMovContInf && _Dbl_MontoMovBanco < _Dbl_MontoMovContSup)
                        { _Bol_Sw = true; }

                        if (_Bol_Sw)
                        {
                            
                            if (Convert.ToString(_DgRowB.Cells[6].Value) != "")
                            {
                                _Bol_Cell = Convert.ToBoolean(_DgRowB.Cells[6].Value);
                            }
                            if (!_Bol_Cell)
                            {
                                _DgRow.Cells[6].Value = true;
                                _DgRowB.Cells[6].Value = true; 
                            }
                            break;
                        }
                    }
                    
                }
            }
        }

        private void _Mtd_AtrasConcilAuto()
        {
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                _DgRow.Cells[6].Value = false;
            }
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                _DgRow.Cells[6].Value = false;
            }

        }

        private void _Bt_Conciliar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (MessageBox.Show("Esta seguro de realizar la conciliación automática?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Mtd_MarcarGrid();
            }
            else
            {
                _Mtd_AtrasConcilAuto();
            }
            _Bt_ChequeTran.Enabled = true;
            _Bt_DepNoRegCont.Enabled = true;
            _Bt_DepNoRegBanco.Enabled = true;
            _Bt_NDNoRegCont.Enabled = true;
            _Bt_DifConci.Enabled = true;
            _Bt_NDnoRegBanco.Enabled = true;
            _Lbl_ChequeTranMonto.Text = _Mtd_ObtenerChequeTransito().ToString("#,##0.00");
            _Lbl_DifConciMonto.Text = _Mtd_ObtenerDifConcil().ToString("#,##0.00");
            _Lbl_DepNoRegContMonto.Text = _Mtd_ObtenerDepNoRegCont().ToString("#,##0.00");
            _Lbl_DepNoRegBancoMonto.Text = _Mtd_ObtenerDepNoRegBanco().ToString("#,##0.00");
            _Lbl_NDNoRegContMonto.Text = _Mtd_ObtenerNDNoRegCont().ToString("#,##0.00");
            _Lbl_NDnoRegBancoMonto.Text = _Mtd_ObtenerNDNoRegBanco().ToString("#,##0.00");
            Cursor = Cursors.Default;
        }

        private void _Bt_ChequeTran_Click(object sender, EventArgs e)
        {
            Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(1, _Mtd_GetChequesTransito(), Convert.ToString(_Cb_Banco.SelectedValue), _Dg_MovCont, _Dg_MovBanco);
            //Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(1, _Dg_MovCont, _Dg_MovBanco, Convert.ToString(_Cb_Banco.SelectedValue));
            _Frm.ShowDialog();
        }

        private double _Mtd_ObtenerChequeTransito()
        {
            string[,] _Str_Result = _Mtd_GetChequesTransito();
            int _Int_Fil = _Str_Result.GetUpperBound(1);
            double _Dbl_R = 0;
            double _Dbl_Monto = 0;
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                if (_Str_Result[2, _Int_F].ToString()!="")
                {
                    _Dbl_Monto = Convert.ToDouble(_Str_Result[2, _Int_F]);
                }
                _Dbl_R = _Dbl_R + _Dbl_Monto;
            }
            return _Dbl_R;
        }

        private void _Bt_DepNoRegCont_Click(object sender, EventArgs e)
        {
            Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(2, _Mtd_GetDepNoRegCont(), Convert.ToString(_Cb_Banco.SelectedValue), _Dg_MovCont, _Dg_MovBanco);
            //Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(2, _Dg_MovCont, _Dg_MovBanco, Convert.ToString(_Cb_Banco.SelectedValue));
            _Frm.ShowDialog();
        }

        private double _Mtd_ObtenerDepNoRegCont()
        {
            string[,] _Str_Result = _Mtd_GetDepNoRegCont();
            int _Int_Fil = _Str_Result.GetUpperBound(1);
            double _Dbl_R = 0;
            double _Dbl_Monto = 0;
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                if (_Str_Result[2, _Int_F].ToString() != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Str_Result[2, _Int_F]);
                }
                _Dbl_R = _Dbl_R + _Dbl_Monto;
            }
            return _Dbl_R;

        }

        private void _Bt_DepNoRegBanco_Click(object sender, EventArgs e)
        {
            Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(3, _Mtd_GetDepNoRegBanco(), Convert.ToString(_Cb_Banco.SelectedValue), _Dg_MovCont, _Dg_MovBanco);
            //Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(3, _Dg_MovCont, _Dg_MovBanco, Convert.ToString(_Cb_Banco.SelectedValue));
            _Frm.ShowDialog();
        }

    

        private double _Mtd_ObtenerDepNoRegBanco()
        {
            string[,] _Str_Result = _Mtd_GetNDNoRegBanco();
            int _Int_Fil = _Str_Result.GetUpperBound(1);
            double _Dbl_R = 0;
            double _Dbl_Monto = 0;
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                if (_Str_Result[2, _Int_F].ToString() != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Str_Result[2, _Int_F]);
                }
                _Dbl_R = _Dbl_R + _Dbl_Monto;
            }
            return _Dbl_R;

        }

        private void _Bt_NDNoRegCont_Click(object sender, EventArgs e)
        {
            Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(4, _Mtd_GetNDNoRegCont(), Convert.ToString(_Cb_Banco.SelectedValue), _Dg_MovCont, _Dg_MovBanco);
            //Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(4, _Dg_MovCont, _Dg_MovBanco, Convert.ToString(_Cb_Banco.SelectedValue));
            _Frm.ShowDialog();
        }

        private double _Mtd_ObtenerNDNoRegCont()
        {
            string[,] _Str_Result = _Mtd_GetNDNoRegCont();
            int _Int_Fil = _Str_Result.GetUpperBound(1);
            double _Dbl_R = 0;
            double _Dbl_Monto = 0;
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                if (_Str_Result[2, _Int_F].ToString() != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Str_Result[2, _Int_F]);
                }
                _Dbl_R = _Dbl_R + _Dbl_Monto;
            }
            return _Dbl_R;

        }

        private void _Bt_NDnoRegBanco_Click(object sender, EventArgs e)
        {
            Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(5, _Mtd_GetNDNoRegBanco(), Convert.ToString(_Cb_Banco.SelectedValue), _Dg_MovCont, _Dg_MovBanco);
            //Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(5, _Dg_MovCont, _Dg_MovBanco, Convert.ToString(_Cb_Banco.SelectedValue));
            _Frm.ShowDialog();
        }


        private double _Mtd_ObtenerNDNoRegBanco()
        {
            string[,] _Str_Result = _Mtd_GetNDNoRegBanco();
            int _Int_Fil = _Str_Result.GetUpperBound(1);
            double _Dbl_R = 0;
            double _Dbl_Monto = 0;
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                if (_Str_Result[2, _Int_F].ToString() != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Str_Result[2, _Int_F]);
                }
                _Dbl_R = _Dbl_R + _Dbl_Monto;
            }
            return _Dbl_R;
        }

        private void _Bt_DifConci_Click(object sender, EventArgs e)
        {
            Frm_ConciliacionDetalle _Frm = new Frm_ConciliacionDetalle(6, _Dg_MovCont, _Dg_MovBanco, Convert.ToString(_Cb_Banco.SelectedValue));
            _Frm.ShowDialog();
        }

 
        private double _Mtd_ObtenerDifConcil()
        {
            double _Dbl_R = 0;
            double _Dbl_MovCont = 0;
            double _Dbl_MovBanco = 0;
            bool _Bol_Cell = false;


            //CARGO EL TOTAL DE LOS MARCADOS EN MOV. CONTABLE
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    if (Convert.ToString(_DgRow.Cells[5].Value).Trim() != "")
                    {
                        _Dbl_MovCont = _Dbl_MovCont + Convert.ToDouble(_DgRow.Cells[5].Value);
                    }
                }
            }
            //CARGO EL TOTAL DE LOS MARCADOS EN MOV. BANCO
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }

                if (_Bol_Cell)
                {
                    if (Convert.ToString(_DgRow.Cells[5].Value).Trim() != "")
                    {
                        _Dbl_MovBanco = _Dbl_MovBanco + Convert.ToDouble(_DgRow.Cells[5].Value);
                    }
                }
            }
            _Dbl_R = _Dbl_MovCont - _Dbl_MovBanco;
            return _Dbl_R;
        }

        private bool _Mtd_ValiadarConciliacion()
        {
            bool _Bol_R = false;
            double _Dbl_SaldoCont = 0;
            double _Dbl_SaldoBanco = 0;
            double _Dbl_SaldoCheTransito = 0;
            double _Dbl_SaldoDepNoRegCont = 0;
            double _Dbl_SaldoDepNoRegBanco = 0;
            double _Dbl_SaldoNDnoRegCont = 0;
            double _Dbl_SaldoNDnoRegBanco = 0;
            double _Dbl_SaldoDifConcil = 0;
            double _Dbl_ConcilFormula = 0;
            if (_Lbl_SaldoContable.Text != "")
            {
                _Dbl_SaldoCont = Convert.ToDouble(_Lbl_SaldoContable.Text);
            }
            if (_Lbl_ChequeTranMonto.Text != "")
            {
                _Dbl_SaldoCheTransito = Convert.ToDouble(_Lbl_ChequeTranMonto.Text);
            }
            if (_Lbl_DepNoRegContMonto.Text != "")
            {
                _Dbl_SaldoDepNoRegCont = Convert.ToDouble(_Lbl_DepNoRegContMonto.Text);
            }
            if (_Lbl_DepNoRegBancoMonto.Text != "")
            {
                _Dbl_SaldoDepNoRegBanco = Convert.ToDouble(_Lbl_DepNoRegBancoMonto.Text);
            }
            if (_Lbl_NDNoRegContMonto.Text != "")
            {
                _Dbl_SaldoNDnoRegCont = Convert.ToDouble(_Lbl_NDNoRegContMonto.Text);
            }
            if (_Lbl_NDnoRegBancoMonto.Text != "")
            {
                _Dbl_SaldoNDnoRegBanco = Convert.ToDouble(_Lbl_NDnoRegBancoMonto.Text);
            }
            if (_Lbl_DifConciMonto.Text != "")
            {
                _Dbl_SaldoDifConcil = Convert.ToDouble(_Lbl_DifConciMonto.Text);
            }
            if (_Lbl_SaldoBanco.Text != "")
            {
                _Dbl_SaldoBanco = Convert.ToDouble(_Lbl_SaldoBanco.Text);
            }
            _Dbl_ConcilFormula = _Dbl_SaldoCont + _Dbl_SaldoDepNoRegCont - _Dbl_SaldoNDnoRegCont + _Dbl_SaldoCheTransito - _Dbl_SaldoDepNoRegBanco + _Dbl_SaldoDifConcil + _Dbl_SaldoNDnoRegBanco;

            if (_Dbl_SaldoBanco != 0)
            {
                if (Math.Round(_Dbl_ConcilFormula,2) == Math.Round(_Dbl_SaldoBanco,2))
                {
                    _Bol_R = true;
                }
                else
                {
                    _Bol_R = false;
                }
            }
            return _Bol_R;
        }

        public bool _Mtd_Guardar()
        {
            string _Str_Sql = "";
            string _Str_ConcilId = "";
            bool _Bol_Val = false;
            bool _Bol_R = false;
            if (_Cb_Banco.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_Banco, "Seleccione Un Banco.");
                _Bol_Val = true;
            }
            if (_Cb_Cuenta.SelectedIndex <= 0)
            {
                _Er_Error.SetError(_Cb_Cuenta, "Seleccione Una Cuenta.");
                _Bol_Val = true;
            }
            
            if (!_Mtd_ValiadarConciliacion())
            {
                MessageBox.Show("La conciliación realizada no es correcta.", "Validación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                _Bol_Val = true;
            }
            if (!_Bol_Val)
            {
                try
                {
                    _Str_ConcilId = _Mtd_GuardarConciliacion();
                    _Mtd_GuardarDepNoRegBanco(_Str_ConcilId);
                    _Mtd_GuardarDepNoRegCont(_Str_ConcilId);
                    _Mtd_GuardarNDNoRegBanco(_Str_ConcilId);
                    _Mtd_GuardarNDNoRegCont(_Str_ConcilId);
                    _Mtd_GuardarCheqTransito(_Str_ConcilId);
                    _Mtd_GuardarDifConcil(_Str_ConcilId);

                    _Mtd_GuardarMovCont(_Str_ConcilId);
                    _Mtd_GuardarMovBanco(_Str_ConcilId);
                    _Mtd_GuardarConciliacion();
                    if (!_Pnl_FechaDesde.Visible)
                    {
                        _Mtd_MarcarMovContConciliado();
                        _Mtd_MarcarMovBancoConciliado();
                        this.Close();
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    _Bol_R = true;
                }
                catch (Exception _Ex)
                {
                    MessageBox.Show("Problemas al guardar la Conciliación. " + _Ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        //ELIMINO LAS TRANSACCIONES REALIZADAS
                        _Str_Sql = "DELETE FROM TCONCILIACONL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cconciliacion=" + _Str_ConcilId;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "DELETE FROM TCONCILIACONB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cconciliacion=" + _Str_ConcilId;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "DELETE FROM TCONCILIACONC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cconciliacion=" + _Str_ConcilId;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "DELETE FROM TCONCILIACOND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cconciliacion=" + _Str_ConcilId;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                        bool _Bol_Cell = false;
                        foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
                        {
                            _Bol_Cell = false;
                            if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                            {
                                _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                            }
                            if (_Bol_Cell)
                            {
                                _Str_Sql = "UPDATE TMOVBANCO SET cconciliado=0,cdateconciliado=null WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidmovbanco='" + Convert.ToString(_DgRow.Cells[7].Value) + "' and cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "' and cnumcuentad='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "' and ctdocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' and cnumdocu='" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                        }

                        int _Int_V = 0;
                        foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
                        {
                            _Bol_Cell = false;
                            if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                            {
                                _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                            }
                            if (_Bol_Cell)
                            {
                                _Str_Sql = "UPDATE TDISPBAND set cconciliado=0,cadateconcil=null WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + Convert.ToString(_DgRow.Cells[7].Value) + "' and cdispband=" + Convert.ToString(_DgRow.Cells[8].Value);
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                            if (_Int_V == 0)
                            {
                                _Str_Sql = "UPDATE TDISPBANC SET cconciliado=0 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + Convert.ToString(_DgRow.Cells[7].Value) + "' and cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "' and cnumcuenta='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                            _Int_V = 1;
                        }
                    }
                    catch { }
                    _Bol_R = false;
                }
            }

            return _Bol_R;
        }

        private string _Mtd_GuardarConciliacion()
        {
            string _Str_Sql = "";
            string _Str_ConcilIdAnt = "";
            string _Str_ConcilId = "";
            string _Str_AnoCont = "";
            string _Str_MesCont = "";
            string _Str_Fdesde = "";
            string _Str_Fhasta = "";
            string _Str_SaldoLibro = "";
            string _Str_SaldoBanco = "";
            string _Str_CheqTransito = "";
            string _Str_cdepnoregcont = "";
            string _Str_cdepnoregbanc = "";
            string _Str_cndnoregcont = "";
            string _Str_cndnoregbanc = "";
            string _Str_cdifconcil="";
            string _Str_cejecutadoautomat = "";


            _Str_SaldoLibro = _Lbl_SaldoContable.Text.Replace(".", "").Replace(",", ".");
            _Str_SaldoBanco = _Lbl_SaldoBanco.Text.Replace(".", "").Replace(",", ".");
            _Str_CheqTransito = _Lbl_ChequeTranMonto.Text.Replace(".", "").Replace(",", ".");
            _Str_cdepnoregcont = _Lbl_DepNoRegContMonto.Text.Replace(".", "").Replace(",", ".");
            _Str_cdepnoregbanc = _Lbl_DepNoRegBancoMonto.Text.Replace(".", "").Replace(",", ".");
            _Str_cndnoregcont = _Lbl_NDNoRegContMonto.Text.Replace(".", "").Replace(",", ".");
            _Str_cndnoregbanc = _Lbl_NDnoRegBancoMonto.Text.Replace(".", "").Replace(",", ".");
            _Str_cdifconcil = _Lbl_DifConciMonto.Text.Replace(".", "").Replace(",", ".");

            if (Convert.ToDouble(_Str_cdifconcil) != 0)
            {
                _Str_cejecutadoautomat = "1";
            }
            else
            {
                _Str_cejecutadoautomat = "0";
            }
            DataSet _Ds;
            _Str_AnoCont = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            _Str_MesCont = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            _Str_ConcilId = myUtilidad._Mtd_Correlativo("select max(cconciliacion) from TCONCILIACONC where ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Str_ConcilId == "1")
            {
                if (_Str_ConcilFdesde == "")
                {
                    //PIDO LA FECHA desde AL USUARIO
                    _Pnl_FechaDesde.BringToFront();
                    _Pnl_FechaDesde.Top = this.Height / 2 - _Pnl_FechaDesde.Height / 2;
                    _Pnl_FechaDesde.Left = this.Width / 2 - _Pnl_FechaDesde.Width / 2;
                    _Pnl_FechaDesde.Visible = true;
                }
            }
            else
            {
                _Str_ConcilIdAnt = Convert.ToString(Convert.ToInt32(_Str_ConcilId) - 1);
                _Str_Sql = "select chasta from TCONCILIACONC where ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0])!="")
                    {
                        _Str_Fdesde = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                        _Str_ConcilFdesde = _Str_Fdesde;
                    }
                }
            }
            if (!_Pnl_FechaDesde.Visible)
            {
                _Str_Fhasta = _MyFormato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
                //GUARDO EL ENCABEZADO
                _Str_Sql = "INSERT INTO TCONCILIACONC (ccompany,cconciliacion,cyearacco,cmontacco,cadetecon,cbanco,cnumcuenta,cdesde,chasta,csaldosegl,csaldosegb,ccheqtrans,cdepnoregcont,cdepnoregbanc,cndnoregcont,cndnoregbanc,cdiferenconciliacion,cejecutadoautomat,cdateadd,cuseradd,cdelete) values ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Str_ConcilId + "," + _Str_AnoCont + "," + _Str_MesCont + ",'" + _MyFormato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "','" + _Str_ConcilFdesde + "','" + _Str_Fhasta + "'," + _Str_SaldoLibro + "," + _Str_SaldoBanco + "," + _Str_CheqTransito + "," + _Str_cdepnoregcont + "," + _Str_cdepnoregbanc + "," + _Str_cndnoregcont + "," + _Str_cndnoregbanc + "," + _Str_cdifconcil + "," + _Str_cejecutadoautomat + ",GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            

            return _Str_ConcilId;
        }

        private void _Mtd_GuardarMovCont(string _Pr_Str_ConcilBancId)
        {
            bool _Bol_Cell = false;
            string _Str_Sql = "";
            string _Str_Fecha = "";
            string _Str_OperBanc = "";
            string _Str_TpoDoc = "";
            string _Str_Numdoc = "";
            string _Str_Descrip = "";
            string _Str_Debe = "";
            string _Str_Haber = "";
            string _Str_Saldo = "";
            string _Str_Comprob = "";
            string _Str_ConcilLibroId = "";
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    if (Convert.ToString(_DgRow.Cells[3].Value) != "")
                    {
                        _Str_Fecha = "'" + _MyFormato._Mtd_fecha(Convert.ToDateTime(_DgRow.Cells[3].Value)) + "'";
                    }
                    else
                    {
                        _Str_Fecha = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[1].Value) != "")
                    {
                        _Str_OperBanc = "'" + Convert.ToString(_DgRow.Cells[1].Value) + "'";
                    }
                    else
                    {
                        _Str_OperBanc = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[8].Value) != "")
                    {
                        _Str_TpoDoc = "'" + Convert.ToString(_DgRow.Cells[8].Value) + "'";
                    }
                    else
                    {
                        _Str_TpoDoc = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[0].Value) != "")
                    {
                        _Str_Numdoc = "'" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                    }
                    else
                    {
                        _Str_Numdoc = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[4].Value) != "")
                    {
                        _Str_Descrip = "'" + Convert.ToString(_DgRow.Cells[4].Value) + "'";
                    }
                    else
                    {
                        _Str_Descrip = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[9].Value) != "")
                    {
                        _Str_Debe = "'" + Convert.ToString(_DgRow.Cells[9].Value).Replace(".", "").Replace(",", ".") + "'";
                    }
                    else
                    {
                        _Str_Debe = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[10].Value) != "")
                    {
                        _Str_Haber = "'" + Convert.ToString(_DgRow.Cells[10].Value).Replace(".", "").Replace(",", ".") + "'";
                    }
                    else
                    {
                        _Str_Haber = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[11].Value) != "")
                    {
                        _Str_Saldo = "'" + Convert.ToString(_DgRow.Cells[11].Value).Replace(".", "").Replace(",", ".") + "'";
                    }
                    else
                    {
                        _Str_Saldo = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[12].Value) != "")
                    {
                        _Str_Comprob = "'" + Convert.ToString(_DgRow.Cells[12].Value) + "'";
                    }
                    else
                    {
                        _Str_Comprob = "null";
                    }

                    _Str_ConcilLibroId = myUtilidad._Mtd_Correlativo("SELECT MAX(cconciliadoidl) FROM TCONCILIACONL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cconciliacion='" + _Pr_Str_ConcilBancId + "'");

                    _Str_Sql = "INSERT INTO TCONCILIACONL (ccompany,cconciliacion,cconciliadoidl,cfecha,coperbanc,ctdocument,cnumdocu,cdescipcion,cmovdebe,cmovhaber,cmovsaldo,canulado,cidcomprob,cdelete,cdateadd,cuseradd) VALUES ('";
                    _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Pr_Str_ConcilBancId + "','" + _Str_ConcilLibroId + "'," + _Str_Fecha + "," + _Str_OperBanc + "," + _Str_TpoDoc + "," + _Str_Numdoc + "," + _Str_Descrip + "," + _Str_Debe + "," + _Str_Haber + "," + _Str_Saldo + ",0," + _Str_Comprob + ",0,GETDATE(),'" + Frm_Padre._Str_Use + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }

                
            }
        }

        private void _Mtd_GuardarMovBanco(string _Pr_Str_ConcilBancId)
        {
            bool _Bol_Cell = false;
            string _Str_Sql = "";
            string _Str_Fecha = "";
            string _Str_OperBanc = "";
            string _Str_Numdoc = "";
            string _Str_Descrip = "";
            string _Str_Monto = "";
            string _Str_Saldo = "";
            string _Str_Oficina = "";
            string _Str_ConcilLibBancoId = "";
            DataSet _Ds;
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    if (Convert.ToString(_DgRow.Cells[3].Value) != "")
                    {
                        _Str_Fecha = "'" + _MyFormato._Mtd_fecha(Convert.ToDateTime(_DgRow.Cells[3].Value)) + "'";
                    }
                    else
                    {
                        _Str_Fecha = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[1].Value) != "")
                    {
                        _Str_Sql = "SELECT dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRow.Cells[1].Value) + "')";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_OperBanc = "'" + Convert.ToString(_Ds.Tables[0].Rows[0][0]) + "'";
                        }
                        else
                        { _Str_OperBanc = "null"; }
                    }
                    else
                    {
                        _Str_OperBanc = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[0].Value) != "")
                    {
                        _Str_Numdoc = "'" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                    }
                    else
                    {
                        _Str_Numdoc = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[4].Value) != "")
                    {
                        _Str_Descrip = "'" + Convert.ToString(_DgRow.Cells[4].Value) + "'";
                    }
                    else
                    {
                        _Str_Descrip = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                    {
                        _Str_Monto = "'" + Convert.ToString(_DgRow.Cells[5].Value).Replace(".", "").Replace(",", ".") + "'";
                    }
                    else
                    {
                        _Str_Monto = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[9].Value) != "")
                    {
                        _Str_Saldo = "'" + Convert.ToString(_DgRow.Cells[9].Value).Replace(".", "").Replace(",", ".") + "'";
                    }
                    else
                    {
                        _Str_Saldo = "null";
                    }
                    if (Convert.ToString(_DgRow.Cells[10].Value) != "")
                    {
                        _Str_Oficina = "'" + Convert.ToString(_DgRow.Cells[10].Value) + "'";
                    }
                    else
                    {
                        _Str_Oficina = "null";
                    }

                    _Str_ConcilLibBancoId = myUtilidad._Mtd_Correlativo("SELECT MAX(cconciliadoidb) FROM TCONCILIACONB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cconciliacion='" + _Pr_Str_ConcilBancId + "'");

                    _Str_Sql = "INSERT INTO TCONCILIACONB (ccompany,cconciliacion,cconciliadoidb,cdatemovi,cnumdocu,ctipoperacio,cconcepto,cmontomov,csaldomov,coficinabanc,cdateadd,cuseradd,cdelete) VALUES ('";
                    _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Pr_Str_ConcilBancId + "','" + _Str_ConcilLibBancoId + "'," + _Str_Fecha + "," + _Str_Numdoc + "," + _Str_OperBanc + "," + _Str_Descrip + "," + _Str_Monto + "," + _Str_Saldo + "," + _Str_Oficina + ",GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }


            }
        }

        private void _Mtd_GuardarCheqTransito(string _Pr_Str_cconciliacion)
        {
            string[,] _Str_Vec = _Mtd_GetChequesTransito();
            int _Int_Fil = _Str_Vec.GetUpperBound(1);
            string _Str_Sql = "";
            string _Str_ConcilDetId = "";
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                _Str_ConcilDetId = myUtilidad._Mtd_Correlativo("select max(cconciliadoid) from TCONCILIACOND where ccompany='" + Frm_Padre._Str_Comp + "' and cconciliacion=" + _Pr_Str_cconciliacion);
                _Str_Sql = "INSERT INTO TCONCILIACOND (ccompany,cconciliacion,cconciliadoid,cfecha,ctdocuoper,cnumdocu,cconcepto,cmontomov,cestatuscocilia) VALUES ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Pr_Str_cconciliacion + "," + _Str_ConcilDetId + ",'" + Convert.ToString(_Str_Vec[5, _Int_F]/*fecha*/) + "','" + Convert.ToString(_Str_Vec[4, _Int_F]/*oper.banc.*/) + "','" + Convert.ToString(_Str_Vec[0, _Int_F]/*num.doc*/) + "','" + Convert.ToString(_Str_Vec[1, _Int_F]/*descrip*/) + "','" + Convert.ToString(_Str_Vec[2, _Int_F]/*MONTO*/).Replace(".", "").Replace(",", ".") + "','DEPBAN')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
        }

        private void _Mtd_GuardarDepNoRegCont(string _Pr_Str_cconciliacion)
        {
            string[,] _Str_Vec = _Mtd_GetDepNoRegCont();
            int _Int_Fil = _Str_Vec.GetUpperBound(1);
            string _Str_Sql = "";
            string _Str_ConcilDetId = "";
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                _Str_ConcilDetId = myUtilidad._Mtd_Correlativo("select max(cconciliadoid) from TCONCILIACOND where ccompany='" + Frm_Padre._Str_Comp + "' and cconciliacion=" + _Pr_Str_cconciliacion);
                _Str_Sql = "INSERT INTO TCONCILIACOND (ccompany,cconciliacion,cconciliadoid,cfecha,ctdocuoper,cnumdocu,cconcepto,cmontomov,cestatuscocilia) VALUES ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Pr_Str_cconciliacion + "," + _Str_ConcilDetId + ",'" + Convert.ToString(_Str_Vec[5, _Int_F]/*fecha*/) + "','" + Convert.ToString(_Str_Vec[4, _Int_F]/*oper.banc.*/) + "','" + Convert.ToString(_Str_Vec[0, _Int_F]/*num.doc*/) + "','" + Convert.ToString(_Str_Vec[1, _Int_F]/*descrip*/) + "','" + Convert.ToString(_Str_Vec[2, _Int_F]/*MONTO*/).Replace(".", "").Replace(",", ".") + "','DEPBAN')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            
        }

        private void _Mtd_GuardarDepNoRegBanco(string _Pr_Str_cconciliacion)
        {
            string[,] _Str_Vec = _Mtd_GetDepNoRegBanco();
            int _Int_Fil = _Str_Vec.GetUpperBound(1);
            string _Str_Sql = "";
            string _Str_ConcilDetId = "";
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                _Str_ConcilDetId = myUtilidad._Mtd_Correlativo("select max(cconciliadoid) from TCONCILIACOND where ccompany='" + Frm_Padre._Str_Comp + "' and cconciliacion=" + _Pr_Str_cconciliacion);
                _Str_Sql = "INSERT INTO TCONCILIACOND (ccompany,cconciliacion,cconciliadoid,cfecha,ctdocuoper,cnumdocu,cconcepto,cmontomov,cestatuscocilia) VALUES ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Pr_Str_cconciliacion + "," + _Str_ConcilDetId + ",'" + Convert.ToString(_Str_Vec[5, _Int_F]/*fecha*/) + "','" + Convert.ToString(_Str_Vec[4, _Int_F]/*oper.banc.*/) + "','" + Convert.ToString(_Str_Vec[0, _Int_F]/*num.doc*/) + "','" + Convert.ToString(_Str_Vec[1, _Int_F]/*descrip*/) + "','" + Convert.ToString(_Str_Vec[2, _Int_F]/*MONTO*/).Replace(".", "").Replace(",", ".") + "','DEPBAN')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
        }

        private void _Mtd_GuardarNDNoRegCont(string _Pr_Str_cconciliacion)
        {
            string[,] _Str_Vec = _Mtd_GetNDNoRegCont();
            int _Int_Fil = _Str_Vec.GetUpperBound(1);
            string _Str_Sql = "";
            string _Str_ConcilDetId = "";
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                _Str_ConcilDetId = myUtilidad._Mtd_Correlativo("select max(cconciliadoid) from TCONCILIACOND where ccompany='" + Frm_Padre._Str_Comp + "' and cconciliacion=" + _Pr_Str_cconciliacion);
                _Str_Sql = "INSERT INTO TCONCILIACOND (ccompany,cconciliacion,cconciliadoid,cfecha,ctdocuoper,cnumdocu,cconcepto,cmontomov,cestatuscocilia) VALUES ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Pr_Str_cconciliacion + "," + _Str_ConcilDetId + ",'" + Convert.ToString(_Str_Vec[5, _Int_F]/*fecha*/) + "','" + Convert.ToString(_Str_Vec[4, _Int_F]/*oper.banc.*/) + "','" + Convert.ToString(_Str_Vec[0, _Int_F]/*num.doc*/) + "','" + Convert.ToString(_Str_Vec[1, _Int_F]/*descrip*/) + "','" + Convert.ToString(_Str_Vec[2, _Int_F]/*MONTO*/).Replace(".", "").Replace(",", ".") + "','DEPBAN')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }

        }

        private void _Mtd_GuardarNDNoRegBanco(string _Pr_Str_cconciliacion)
        {
            string[,] _Str_Vec = _Mtd_GetNDNoRegBanco();
            int _Int_Fil = _Str_Vec.GetUpperBound(1);
            string _Str_Sql = "";
            string _Str_ConcilDetId = "";
            for (int _Int_F = 0; _Int_F < _Int_Fil; _Int_F++)
            {
                _Str_ConcilDetId = myUtilidad._Mtd_Correlativo("select max(cconciliadoid) from TCONCILIACOND where ccompany='" + Frm_Padre._Str_Comp + "' and cconciliacion=" + _Pr_Str_cconciliacion);
                _Str_Sql = "INSERT INTO TCONCILIACOND (ccompany,cconciliacion,cconciliadoid,cfecha,ctdocuoper,cnumdocu,cconcepto,cmontomov,cestatuscocilia) VALUES ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Pr_Str_cconciliacion + "," + _Str_ConcilDetId + ",'" + Convert.ToString(_Str_Vec[5, _Int_F]/*fecha*/) + "','" + Convert.ToString(_Str_Vec[4, _Int_F]/*oper.banc.*/) + "','" + Convert.ToString(_Str_Vec[0, _Int_F]/*num.doc*/) + "','" + Convert.ToString(_Str_Vec[1, _Int_F]/*descrip*/) + "','" + Convert.ToString(_Str_Vec[2, _Int_F]/*MONTO*/).Replace(".", "").Replace(",", ".") + "','DEPBAN')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }

        }

        private void _Mtd_GuardarDifConcil(string _Pr_Str_cconciliacion)
        {
            string _Str_Sql = "";
            string _Str_ConcilDetId = "";
            DataTable _Dt;
            _Dt = _Mtd_DsDifConcil();
            foreach (DataRow _Drow in _Dt.Rows)
            {
                _Str_ConcilDetId = myUtilidad._Mtd_Correlativo("select max(cconciliadoid) from TCONCILIACOND where ccompany='" + Frm_Padre._Str_Comp + "' and cconciliacion=" + _Pr_Str_cconciliacion);
                _Str_Sql = "INSERT INTO TCONCILIACOND (ccompany,cconciliacion,cconciliadoid,cfecha,ctdocuoper,cnumdocu,cconcepto,cmontomov,cestatuscocilia) VALUES ('";
                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "'," + _Pr_Str_cconciliacion + "," + _Str_ConcilDetId + ",'" + Convert.ToString(_Drow["cfecha"]) + "','" + Convert.ToString(_Drow["ctdocuoper"]) + "','" + Convert.ToString(_Drow["cnumdocu"]) + "','" + Convert.ToString(_Drow["cconcepto"]) + "','" + Convert.ToString(_Drow["cmontomov"]).Replace(".", "").Replace(",", ".") + "','DIFCONC')";
            }
        }

        private void _Mtd_MarcarMovContConciliado()
        {
            string _Str_Sql = "";
            bool _Bol_Cell = false;
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    _Str_Sql = "UPDATE TMOVBANCO SET cconciliado=1,cdateconciliado='" + _MyFormato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidmovbanco='" + Convert.ToString(_DgRow.Cells[7].Value) + "' and cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "' and cnumcuentad='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "' and ctdocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' and cnumdocu='" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            
        }

        private void _Mtd_MarcarMovBancoConciliado()
        {
            bool _Bol_Cell = false;
            string _Str_Sql = "";
            int _Int_C = 0;
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    _Str_Sql = "UPDATE TDISPBAND set cconciliado=1,cadateconcil='" + _MyFormato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + Convert.ToString(_DgRow.Cells[7].Value) + "' and cdispband=" + Convert.ToString(_DgRow.Cells[8].Value);
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                if (_Int_C == 0)
                {
                    _Str_Sql = "UPDATE TDISPBANC SET cconciliado=1 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + Convert.ToString(_DgRow.Cells[7].Value) + "' and cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "' and cnumcuenta='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                _Int_C = 1;
            }

            
        }

        private void _Pnl_FechaDesde_VisibleChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Pnl_FechaDesde.Visible)
                {
                    _Dtp_SelFechaDesde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                    _Tb_Tab.Enabled = false;
                }
                else
                {
                    _Tb_Tab.Enabled = true;
                }
            }
        }

        private void _Bt_FechaDesde_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de la fecha seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                _Pnl_FechaDesde.Visible = false;
                _Str_ConcilFdesde = _MyFormato._Mtd_fecha(_Dtp_SelFechaDesde.Value);
                _Mtd_GuardarConciliacion();
                _Mtd_MarcarMovContConciliado();
                _Mtd_MarcarMovBancoConciliado();
                Cursor = Cursors.Default;
                MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private DataTable _Mtd_DsDifConcil()
        {
            string _Str_TpoOperConvert = "";
            double _Dbl_MontoMovCont = 0;
            double _Dbl_MontoMovBanco = 0;
            double _Dbl_MontoDif = 0;
            bool _Bol_Cell = false;
            bool _Bol_CellA = false;
            DataSet _Ds1;
            DataRow _MyRow;
            DataTable _Dt = new DataTable();
            _Dt.Columns.Add("cfecha", Type.GetType("System.String"));
            _Dt.Columns.Add("ctdocuoper", Type.GetType("System.String"));
            _Dt.Columns.Add("cnumdocu", Type.GetType("System.String"));
            _Dt.Columns.Add("cconcepto", Type.GetType("System.String"));
            _Dt.Columns.Add("cmontomov", Type.GetType("System.String"));
            

            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                _Dbl_MontoMovCont = 0;
                _Bol_Cell = false;
                if (Convert.ToString(_DgRow.Cells[6].Value) != "")
                {
                    _Bol_Cell = Convert.ToBoolean(_DgRow.Cells[6].Value);
                }
                if (_Bol_Cell)
                {
                    if (Convert.ToString(_DgRow.Cells[5].Value)!="")
                    {
                        _Dbl_MontoMovCont = Convert.ToDouble(_DgRow.Cells[5].Value);
                    }
                    
                    foreach (DataGridViewRow _DgRowA in _Dg_MovBanco.Rows)
                    {
                        _Bol_CellA = false;
                        _Dbl_MontoMovBanco = 0;
                        if (Convert.ToString(_DgRowA.Cells[6].Value) != "")
                        {
                            _Bol_CellA = Convert.ToBoolean(_DgRowA.Cells[6].Value);
                        }
                        if (_Bol_CellA)
                        {
                            if (Convert.ToString(_DgRowA.Cells[5].Value)!="")
                            {
                                _Dbl_MontoMovBanco = Convert.ToDouble(_DgRowA.Cells[5].Value);
                            }

                            if (_Dbl_MontoMovBanco != 0 && _Dbl_MontoMovCont != 0)
                            {
                                if (Convert.ToInt32(_DgRow.Cells[0].Value) == Convert.ToInt32(_DgRowA.Cells[0].Value))
                                {
                                    //CONVIERTO EL TIPO DE OPERACION DE TDISPBAND
                                    _Ds1 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRowA.Cells[1].Value) + "')");
                                    if (_Ds1.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(_Ds1.Tables[0].Rows[0][0]) != "")
                                        {
                                            _Str_TpoOperConvert = Convert.ToString(_Ds1.Tables[0].Rows[0][0]);
                                        }
                                    }

                                    if (_Str_TpoOperConvert != "")
                                    {
                                        if (Convert.ToString(_DgRow.Cells[1].Value) == _Str_TpoOperConvert)
                                        {
                                            //VERIFICO SI LOS MONTOS SON DIFERENTES
                                            if (_Dbl_MontoMovBanco != _Dbl_MontoMovCont)
                                            {
                                                _Dbl_MontoDif = _Dbl_MontoMovCont - _Dbl_MontoMovBanco;
                                                //AGREGO AL DATASET
                                                _MyRow = _Dt.NewRow();
                                                _MyRow["cfecha"] = Convert.ToString(_DgRowA.Cells[3].Value);
                                                _MyRow["ctdocuoper"] = Convert.ToString(_DgRowA.Cells[1].Value);
                                                _MyRow["cnumdocu"] = Convert.ToString(_DgRowA.Cells[0].Value);
                                                _MyRow["cconcepto"] = Convert.ToString(_DgRowA.Cells[4].Value);
                                                _MyRow["cmontomov"] = _Dbl_MontoDif.ToString().Replace(",",".");

                                                _Dt.Rows.Add(_MyRow);
                                            }
                                        }
                                    }
                                    

                                }
                            }
                            
                        }
                        _Str_TpoOperConvert = "";
                    }
                }

            }

            return _Dt;
        }

        private void _Tst_MovBanco_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void _Bt_Concilicion_Click(object sender, EventArgs e)
        {
            Frm_ConciliaVer _Frm = new Frm_ConciliaVer();
            _Frm.ShowDialog();
        }

        private string[,] _Mtd_GetChequesTransito()
        {
            string[,] _Str_Result;
            bool _Bol_Sw = false;
            int _Int_N = 0;
            string _Str_OperCheq = "";
            string _Str_Sql = "SELECT coperbancemicheq FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_OperCheq = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            //ESTAN EN MOVIMIENTO CONTABLE Y NO ESTE EN DISPONIBIBIDAD BANCARIA
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    if (_Str_OperCheq == Convert.ToString(_DgRow.Cells[1].Value))
                    {
                        _Int_N++;
                    }
                }
            }

            _Str_Result = new string[6, _Int_N+1];
            _Int_N = 0;
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    if (_Str_OperCheq == Convert.ToString(_DgRow.Cells[1].Value))
                    {
                        _Str_Result[0, _Int_N] = Convert.ToString(_DgRow.Cells[0].Value);//NUM.DOC.
                        _Str_Result[1, _Int_N] = Convert.ToString(_DgRow.Cells[4].Value);//CONCEPTO
                        _Str_Result[2, _Int_N] = Convert.ToString(_DgRow.Cells[5].Value);//MONTO
                        _Str_Result[3, _Int_N] = Convert.ToString(_DgRow.Cells[8].Value);//TPO.DOC.
                        _Str_Result[4, _Int_N] = Convert.ToString(_DgRow.Cells[1].Value);//TPO.OPER.BANC
                        _Str_Result[5, _Int_N] = Convert.ToString(_DgRow.Cells[3].Value);//FECHA
                        _Int_N++;
                    }
                }
            }

            return _Str_Result;
        }

        private string[,] _Mtd_GetDepNoRegCont()
        {
            //DEPOSITOS NO REGISTRADOS EN CONTABILIDAD
            string[,] _Str_Result;
            bool _Bol_Sw = false;
            int _Int_N = 0;
            string _Str_DepConvert = "";
            string _Str_Dep = "";
            string _Str_Sql = "SELECT coperdeposito FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Dep = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            //LOS QUE APARECEN EN DISPONIBILIDAD BANCARIA Y NO ESTE EN MOVIMIENTO CONTABLE
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRow.Cells[1].Value) + "')");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_DepConvert = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    }
                    if (_Str_Dep == _Str_DepConvert)
                    {
                        _Int_N++;
                    }
                }
            }

            _Str_Result = new string[6, _Int_N + 1];
            _Int_N = 0;
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRow.Cells[1].Value) + "')");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_DepConvert = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    }

                    if (_Str_Dep == _Str_DepConvert)
                    {
                        _Str_Result[0, _Int_N] = Convert.ToString(_DgRow.Cells[0].Value);//NUM.DOC.
                        _Str_Result[1, _Int_N] = Convert.ToString(_DgRow.Cells[4].Value);//CONCEPTO
                        _Str_Result[2, _Int_N] = Convert.ToString(_DgRow.Cells[5].Value);//MONTO
                        _Str_Result[3, _Int_N] = "";//TPO.DOC.
                        _Str_Result[4, _Int_N] = Convert.ToString(_DgRow.Cells[1].Value);//TPO.OPER.BANC
                        _Str_Result[5, _Int_N] = Convert.ToString(_DgRow.Cells[3].Value);//FECHA
                        _Int_N++;
                    }
                }
            }

            return _Str_Result;
        }

        private string[,] _Mtd_GetDepNoRegBanco()
        {
            //DEPOSITOS NO REGISTRADOS EN BANCO
            string[,] _Str_Result;
            bool _Bol_Sw = false;
            int _Int_N = 0;
            string _Str_Dep = "";
            string _Str_Sql = "SELECT coperdeposito FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Dep = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            //LOS QUE ESTEN EL LIBRO (MOV. CONTABLE) Y NO ESTEN EN LA DISPONIBILIDAD BANCARIA.
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    if (_Str_Dep == Convert.ToString(_DgRow.Cells[1].Value))
                    {
                        _Int_N++;
                    }
                }
            }

            _Str_Result = new string[6, _Int_N + 1];
            _Int_N = 0;
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    if (_Str_Dep == Convert.ToString(_DgRow.Cells[1].Value))
                    {
                        _Str_Result[0, _Int_N] = Convert.ToString(_DgRow.Cells[0].Value);//NUM.DOC.
                        _Str_Result[1, _Int_N] = Convert.ToString(_DgRow.Cells[4].Value);//CONCEPTO
                        _Str_Result[2, _Int_N] = Convert.ToString(_DgRow.Cells[5].Value);//MONTO
                        _Str_Result[3, _Int_N] = Convert.ToString(_DgRow.Cells[8].Value);//TPO.DOC.
                        _Str_Result[4, _Int_N] = Convert.ToString(_DgRow.Cells[1].Value);//TPO.OPER.BANC
                        _Str_Result[5, _Int_N] = Convert.ToString(_DgRow.Cells[3].Value);//FECHA
                        _Int_N++;
                    }
                }
            }

            return _Str_Result;
        }

        private string[,] _Mtd_GetNDNoRegCont()
        {
            //NOTAS DE DEBITO NO REGISTRADAS EN CONTABILIDAD
            string[,] _Str_Result;
            bool _Bol_Sw = false;
            int _Int_N = 0;
            string _Str_NDConvert = "";
            string _Str_ND = "";
            string _Str_Sql = "SELECT copernotadebito FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ND = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            //SON AQUELLAS QUE ESTAN DISPONIBILIDAD BANCARIA Y NO ESTAN EN EL MOV. CONTABLE
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRow.Cells[1].Value) + "')");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_NDConvert = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    }
                    if (_Str_ND == _Str_NDConvert)
                    {
                        _Int_N++;
                    }
                }
            }

            _Str_Result = new string[6, _Int_N + 1];
            _Int_N = 0;
            foreach (DataGridViewRow _DgRow in _Dg_MovBanco.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select dbo.FNC_CONVERT_OPERBANC('" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRow.Cells[1].Value) + "')");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_NDConvert = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                    }
                    if (_Str_ND == _Str_NDConvert)
                    {
                        _Str_Result[0, _Int_N] = Convert.ToString(_DgRow.Cells[0].Value);//NUM.DOC.
                        _Str_Result[1, _Int_N] = Convert.ToString(_DgRow.Cells[4].Value);//CONCEPTO
                        _Str_Result[2, _Int_N] = Convert.ToString(_DgRow.Cells[5].Value);//MONTO
                        _Str_Result[3, _Int_N] = "";//TPO.DOC.
                        _Str_Result[4, _Int_N] = Convert.ToString(_DgRow.Cells[1].Value);//TPO.OPER.BANC
                        _Str_Result[5, _Int_N] = Convert.ToString(_DgRow.Cells[3].Value);//FECHA
                        _Int_N++;
                    }
                }
            }

            return _Str_Result;
        }

        private string[,] _Mtd_GetNDNoRegBanco()
        {
            //NOTAS DE DEBITO NO REGISTRADAS EN BANCO
            string[,] _Str_Result;
            bool _Bol_Sw = false;
            int _Int_N = 0;
            string _Str_NDConvert = "";
            string _Str_ND = "";
            string _Str_Sql = "SELECT copernotadebito FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ND = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            //SON AQUELLAS QUE ESTAN EN MOV. CONTABLE Y NO ESTAN EN DISPONIBILIDAD BANCARIA
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {

                    if (_Str_ND == Convert.ToString(_DgRow.Cells[1].Value))
                    {
                        _Int_N++;
                    }
                }
            }

            _Str_Result = new string[6, _Int_N + 1];
            _Int_N = 0;
            foreach (DataGridViewRow _DgRow in _Dg_MovCont.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[6].Value) == "")
                {
                    _Bol_Sw = false;
                }
                else if (Convert.ToBoolean(_DgRow.Cells[6].Value))
                { _Bol_Sw = true; }
                else
                { _Bol_Sw = false; }
                if (!_Bol_Sw)
                {
                    if (_Str_ND == Convert.ToString(_DgRow.Cells[1].Value))
                    {
                        _Str_Result[0, _Int_N] = Convert.ToString(_DgRow.Cells[0].Value);//NUM.DOC.
                        _Str_Result[1, _Int_N] = Convert.ToString(_DgRow.Cells[4].Value);//CONCEPTO
                        _Str_Result[2, _Int_N] = Convert.ToString(_DgRow.Cells[5].Value);//MONTO
                        _Str_Result[3, _Int_N] = Convert.ToString(_DgRow.Cells[8].Value);//TPO.DOC.
                        _Str_Result[4, _Int_N] = Convert.ToString(_DgRow.Cells[1].Value);//TPO.OPER.BANC
                        _Str_Result[5, _Int_N] = Convert.ToString(_DgRow.Cells[3].Value);//FECHA
                        _Int_N++;
                    }
                }
            }

            return _Str_Result;
        }

        private void _Cb_VerBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_VerBanco.SelectedIndex > 0)
            {
                _Mtd_CargarVerCtasBanco(Convert.ToString(_Cb_VerBanco.SelectedValue));
            }
            else
            {
                _Cb_VerCuenta.DataSource = null;
            }
            _Dg_VerMovCont.Rows.Clear();
            _Dg_VerMovBanco.Rows.Clear();
        }

        private void _Cb_VerCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_VerCuenta.SelectedIndex > 0)
            {
                _Mtd_CargarVerMovContable(Convert.ToString(_Cb_VerBanco.SelectedValue), Convert.ToString(_Cb_VerCuenta.SelectedValue));
                _Mtd_CargarVerMovBancario(Convert.ToString(_Cb_VerBanco.SelectedValue), Convert.ToString(_Cb_VerCuenta.SelectedValue));
            }
            else
            {
                _Dg_VerMovCont.Rows.Clear();
                _Dg_VerMovBanco.Rows.Clear();
            }
        }

        private void _Mtd_CargarVerMovContable(string _Pr_Str_BancoId, string _Pr_Str_CtaId)
        {
            object[] _Str_RowNew = new object[13];
            string _Str_Sql = "SELECT cnumdocu,coperbanc,coperbancname,cfecha,cdescipcion,cmonto,cidmovbanco,ctdocument,cmovdebe,cmovhaber,cmovsaldo,cidcomprob FROM VST_TMOVBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuentad='" + _Pr_Str_CtaId + "' AND canulado=0 and cconciliado=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_VerMovCont.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_VerMovCont.Rows.Add(_Str_RowNew);
                if (Convert.ToString(_Dg_VerMovCont[5, _Dg_VerMovCont.RowCount - 1].Value) != "")
                {
                    _Dg_VerMovCont[5, _Dg_VerMovCont.RowCount - 1].Value = Convert.ToDouble(_Dg_VerMovCont[5, _Dg_VerMovCont.RowCount - 1].Value).ToString("#,##0.00");
                }
                if (Convert.ToString(_Dg_VerMovCont[2, _Dg_VerMovCont.RowCount - 1].Value) != "")
                {
                    _Dg_VerMovCont[3, _Dg_VerMovCont.RowCount - 1].Value = Convert.ToDateTime(_Dg_VerMovCont[3, _Dg_VerMovCont.RowCount - 1].Value).ToShortDateString();
                }
            }
            _Dg_VerMovCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_CargarVerMovBancario(string _Pr_Str_BancoId, string _Pr_Str_CtaId)
        {
            object[] _Str_RowNew = new object[11];
            DataSet _Ds;
            string _Str_Sql = "SELECT cnumdocu,ctipoperacio,ctipoperacioname,cdatemovi,cconcepto,cmontomov,cdispbanc,cdispband,csaldomov,coficinabanc FROM VST_DISPBANCARIA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_CtaId + "' AND cdelete=0 and cconciliado_d=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_VerMovBanco.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_VerMovBanco.Rows.Add(_Str_RowNew);
                if (Convert.ToString(_Dg_VerMovBanco[5, _Dg_VerMovBanco.RowCount - 1].Value) != "")
                {
                    _Dg_VerMovBanco[5, _Dg_VerMovBanco.RowCount - 1].Value = Convert.ToDouble(_Dg_VerMovBanco[5, _Dg_VerMovBanco.RowCount - 1].Value).ToString("#,##0.00");
                }
                if (Convert.ToString(_Dg_VerMovBanco[3, _Dg_VerMovBanco.RowCount - 1].Value) != "")
                {
                    _Dg_VerMovBanco[3, _Dg_VerMovBanco.RowCount - 1].Value = Convert.ToDateTime(_Dg_VerMovBanco[3, _Dg_VerMovBanco.RowCount - 1].Value).ToShortDateString();
                }
            }
            _Dg_VerMovBanco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Cb_Banco_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "select dbo.TBANCO.cbanco,dbo.TBANCO.cname from dbo.TBANCO WHERE  dbo.TBANCO.cdelete=0 AND dbo.TBANCO.ccompany='" + Frm_Padre._Str_Comp + "'";
            myUtilidad._Mtd_CargarCombo(_Cb_Banco, _Str_Sql);
        }

        private void _Cb_Cuenta_DropDown(object sender, EventArgs e)
        {
            if (_Cb_Banco.SelectedIndex > 0)
            {
                string _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cb_Banco.SelectedValue.ToString() + "' and cdelete=0";
                myUtilidad._Mtd_CargarCombo(_Cb_Cuenta, _Str_Sql);
            }
        }

        private void _Cb_VerBanco_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "select dbo.TBANCO.cbanco,dbo.TBANCO.cname from dbo.TBANCO WHERE  dbo.TBANCO.cdelete=0 AND dbo.TBANCO.ccompany='" + Frm_Padre._Str_Comp + "'";
            myUtilidad._Mtd_CargarCombo(_Cb_VerBanco, _Str_Sql);
        }

        private void _Cb_VerCuenta_DropDown(object sender, EventArgs e)
        {
            if (_Cb_VerBanco.SelectedIndex > 0)
            {
                string _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cb_VerBanco.SelectedValue.ToString() + "' and cdelete=0";
                myUtilidad._Mtd_CargarCombo(_Cb_VerCuenta, _Str_Sql);
            }
        }
    }
}