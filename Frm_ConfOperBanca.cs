using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfOperBanca : Form
    {
        public Frm_ConfOperBanca()
        {
            InitializeComponent();
        }

        public Frm_ConfOperBanca(string[] _Pr_Str_Vec, string _Pr_Str_BancoId)
        {
            InitializeComponent();
            _Str_FrmVec = _Pr_Str_Vec;
            _Mtd_CargarBancos();
            _Mtd_CargarData(_Pr_Str_BancoId);
            if (_Dg_Equival.RowCount == 0)
            {
                _Mtd_CargarGridEquival();
            }
            _Cmb_Banco.SelectedValue = _Pr_Str_BancoId;
            _Cmb_Banco.Enabled = false;
        }

        public string _Str_FrmResult = "";
        string[] _Str_FrmVec;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _MyFormato = new clslibraryconssa._Cls_Formato("es-VE");

        private void _Mtd_CargarBancos()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname FROM TBANCO WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' AND TBANCO.cdelete=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Banco, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }

        private void Frm_ConfOperBanca_Load(object sender, EventArgs e)
        {
            _Pnl_Vista.Parent = this;
            _Pnl_Vista.Visible = false;
        }

        private void _Mtd_CargarListaInf()
        {
            _Lst_Data.Items.Clear();
            foreach (string _Str_Val in _Str_FrmVec)
            {
                if (!_Mtd_VerificarGridDuplicidad(_Str_Val,-1))
                { _Lst_Data.Items.Add(_Str_Val); }
            }
        }

        private void _Mtd_CargarGridEquival()
        {
            _Dg_Equival.Rows.Clear();
            string _Str_Sql = "SELECT coperbanc,cname FROM TOPERBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                if (Convert.ToString(_DRow["coperbanc"]).Trim().Length > 0)
                {
                    _Dg_Equival.Rows.Add();
                    _Dg_Equival[0, _Dg_Equival.RowCount - 1].Value = Convert.ToString(_DRow["coperbanc"]);
                    _Dg_Equival[1, _Dg_Equival.RowCount - 1].Value = Convert.ToString(_DRow["cname"]);
                }
            }
            _Dg_Equival.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Dg_Equival_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                _Mtd_CargarListaInf();
                _Pnl_Vista.BringToFront();
                _Pnl_Vista.Visible = true;
            }
        }

        private void _Pnl_Vista_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Vista.Visible)
            {
                _Pnl_Banco.Enabled = false;
                _Pnl_Data.Enabled = false;
            }
            else
            {
                _Pnl_Banco.Enabled = true;
                _Pnl_Data.Enabled = true;
            }
        }

        private void _Lst_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Lst_Data.SelectedIndex > -1)
            {
                _Pnl_Vista.Visible = false;
                _Dg_Equival[3, _Dg_Equival.CurrentCell.RowIndex].Value = _Lst_Data.Items[_Lst_Data.SelectedIndex].ToString();
                _Lst_Data.Items.RemoveAt(_Lst_Data.SelectedIndex);
            }
        }

        private void _Bt_Save_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            Cursor = Cursors.WaitCursor;
            if (_Dg_Equival.Rows.Count > 0)
            {
                bool _Bol_Sw = false;
                if (!_Mtd_ValidarGridEquival())
                {
                    foreach (DataGridViewRow _DgRow in _Dg_Equival.Rows)
                    {
                        if (Convert.ToString(_DgRow.Cells[3].Value).Trim().Length > 0)
                        {
                            _Bol_Sw = Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("SELECT * FROM TCONFCAPBANCDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue) + "' AND coperbanc='" + Convert.ToString(_DgRow.Cells[0].Value) + "'");
                            if (!_Bol_Sw)
                            {
                                _Str_Sql = "INSERT INTO TCONFCAPBANCDD (ccompany,cbanco,coperbanc,coperbanctrans,cdateadd,cuseradd,cdelete) VALUES ('";
                                _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Cmb_Banco.SelectedValue) + "','" + Convert.ToString(_DgRow.Cells[0].Value) + "','" + Convert.ToString(_DgRow.Cells[3].Value) + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                            }
                            else
                            {
                                _Str_Sql = "UPDATE TCONFCAPBANCDD SET coperbanctrans='" + Convert.ToString(_DgRow.Cells[3].Value).Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'";
                                _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue) + "' AND coperbanc='" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                            }
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                    }
                    MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Str_FrmResult = "S";
                    this.Hide();
                }
                else
                { MessageBox.Show("Ingrese todos los tipos de Operación del Banco", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                MessageBox.Show("No hay Información de Operaciones Bancarias.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor = Cursors.Default;
        }

        private bool _Mtd_ValidarGridEquival()
        {
            bool _Bol_R = false;
            foreach (DataGridViewRow _DgRow in _Dg_Equival.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[3].Value).Trim().Trim().Length == 0)
                {
                    _Bol_R = true;
                    break;
                }
            }
            return _Bol_R;
        }

        private bool _Mtd_VerificarGridDuplicidad(string _Pr_Str_Valor,int _Pr_Int_ColExcep)
        {
            bool _Bol_R = false;
            foreach (DataGridViewRow _DgRow in _Dg_Equival.Rows)
            {
                if (_DgRow.Index != _Pr_Int_ColExcep)
                {
                    if (Convert.ToString(_DgRow.Cells[3].Value).Trim() == _Pr_Str_Valor.Trim())
                    {
                        _Bol_R = true;
                        break;
                    }
                }       
            }
            return _Bol_R;
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            object[] _Str_RowNew = new object[4];
            string _Str_Sql = "SELECT coperbanc,coperbancname,null,coperbanctrans FROM VST_TCONFCAPBANCDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_Id + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Equival.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Equival.Rows.Add(_Str_RowNew);
            }
            _Dg_Equival.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Inicializar()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Equival.Rows)
            {
                _Dg_Row.Cells[3].Value = null;
            }
        }
        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Vista.Visible = false;
        }

        private void _Bt_Inicializar_Click(object sender, EventArgs e)
        {
            _Mtd_Inicializar();
        }
    }
}