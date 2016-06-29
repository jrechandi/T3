using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace T3.Controles
{
    public partial class _Ctrl_Page : UserControl
    {
        public Int64 _Int_RegSel = 0;
        public Int64 _Int_RegOmitidos = 0;
        public Int64 _Int_RegTot = 0;
        Int64 _Int_Npage = 0;
        string _Str_SpName = "";
        Int64 _Int_Apage = 0;
        string _G_Str_OrderBy = "";
        string _Str_Gtabla = "";
        string _Str_GsqlFiltro = "";
        string _Str_Cadena_Consulta_Formato = "";
        DataGridView _Dg_Grig = new DataGridView();
        string _Str_GroupBy = "";

        public _Ctrl_Page()
        {
            InitializeComponent();
        }
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, DataGridView _P_Dg_Grig, string _P_Str_Tabla, string _P_Str_Filtro, Int64 _P_Int_RegSel, string _P_Str_OrderBy, string _Str_Count, string _Str_NombSP)
        {
            _Str_SpName = _Str_NombSP;
            _Str_CountP = _Str_Count;
            _Str_Gtabla = _P_Str_Tabla;
            _Str_GsqlFiltro = _P_Str_Filtro;
            _Int_RegTot = _Mtd_GetTotalReg();
            _Int_RegSel = _P_Int_RegSel;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _G_Str_OrderBy = _P_Str_OrderBy;
            _Dg_Grig = _P_Dg_Grig;
            if (_Txt_Page.Text != "")
            {
                _Mtd_Actulizar();
            }
            else
            {
                _Txt_Page.Text = "1";
            }
        }
        private void _Mtd_Actulizar()
        {
            //double _Dbl_Pages = 0;

            //string _Str_Sql = _Str_Cadena_Consulta_Formato.Replace("?sel", _Int_RegSel.ToString()).Replace("?omi", _Int_RegOmitidos.ToString());
           
            //if (_Str_GroupBy.Trim().Length == 0)
            //{
            //    if (_G_Str_OrderBy.Length > 0)
            //    {
            //        _Str_Sql = _Str_Sql + " " + _Str_GroupBy + " " + _G_Str_OrderBy;
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{
            //    if (_G_Str_OrderBy.Length > 0)
            //    {
            //        _Str_Sql = _Str_Sql + " " + _G_Str_OrderBy;
            //    }
            //    else
            //    {
            //        _Str_Sql = _Str_Sql + " " + _Str_GroupBy;
            //    }
            //}
            //_Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            
            _Mtd_GetTotalReg();
            _Int_Npage = _Int_RegTot / _Int_RegSel;
            _Int_Npage++;
            _Int_Apage = _Int_RegOmitidos / _Int_RegSel;
            _Int_Apage++;
            _Lbl_de.Text = " / " + _Int_Npage.ToString();
            _Txt_Page.TextChanged -= new EventHandler(_Txt_Page_TextChanged);
            _Txt_Page.Text = _Int_Apage.ToString();
            string _Str_Sql = _Str_Cadena_Consulta_Formato;
            SqlParameter[] _Sql_Parameter = new SqlParameter[3];
            _Sql_Parameter[0] = new SqlParameter("@c_SQL", SqlDbType.VarChar);
            _Sql_Parameter[0].Value = _Str_Sql;
            _Sql_Parameter[1] = new SqlParameter("@PageSize", SqlDbType.Real);
            _Sql_Parameter[1].Value = _Int_RegSel;
            _Sql_Parameter[2] = new SqlParameter("@PageNumber", SqlDbType.Real);
            _Sql_Parameter[2].Value = _Txt_Page.Text;
            DataSet _Ds_Data = new DataSet();
            //DataSet _Ds_Data = new DataSet();
            _Ds_Data = CLASES._Cls_Varios_Metodos._Mtd_ConsultasSP(_Str_SpName, _Sql_Parameter);
            _Dg_Grig.DataSource = _Ds_Data.Tables[0];
            _Txt_Page.TextChanged += new EventHandler(_Txt_Page_TextChanged);
            _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void _Mtd_Inicializar(string _Str_Pagina)
        {
            _Txt_Page.Text = _Str_Pagina;
        }
        public void _Mtd_Inicializar(string _P_Str_Pagina,bool _Bol_Valido)
        {
            _Txt_Page.TextChanged -= new EventHandler(_Txt_Page_TextChanged);
            _Txt_Page.Text = _P_Str_Pagina;
            _Txt_Page.TextChanged+=new EventHandler(_Txt_Page_TextChanged);
        }
        private void _Btn_Next_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_GetTotalReg();
            _Int_RegOmitidos = _Int_RegOmitidos + _Int_RegSel;
            _Int_Npage = _Int_RegTot / _Int_RegSel;
            if (_Int_RegOmitidos <= _Int_RegTot)
            {
                _Mtd_Actulizar();
            }
            else
            {
                _Int_RegOmitidos = _Int_RegOmitidos - _Int_RegSel;
            }
            Cursor = Cursors.Default;
        }

        private void _Btn_Antes_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_GetTotalReg();
            _Int_Npage = _Int_RegTot / _Int_RegSel;
            if (_Int_RegOmitidos > 0)
            {
                _Int_RegOmitidos = _Int_RegOmitidos - _Int_RegSel;
                _Mtd_Actulizar();
            }
            Cursor = Cursors.Default;
        }
        public Int64 _Int_R = 0;
        private Int64 _Mtd_GetTotalReg()
        {
            if (_Int_R == 0)
            {
                _Int_R = 0;
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT COUNT(" + _Str_CountP + ") FROM " + _Str_Gtabla + " " + _Str_GsqlFiltro);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Int_R = Convert.ToInt64(_Ds.Tables[0].Rows[0][0]);
                    _Int_RegTot = _Int_R;
                }
            }
            return _Int_R;
        }
        private void _Txt_Page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }
        

        private void _Txt_Page_TextChanged(object sender, EventArgs e)
        {
            Int64 _Int_P = 1;
            if (_Txt_Page.Text != "")
            {
                if (Convert.ToInt64(_Txt_Page.Text) > 0)
                {
                    _Mtd_GetTotalReg();
                    _Int_Npage = _Int_RegTot / _Int_RegSel;
                    _Int_Npage++;
                    _Int_P = Convert.ToInt64(_Txt_Page.Text);
                    if (_Int_P > _Int_Npage)
                    {
                        _Txt_Page.TextChanged -= new EventHandler(_Txt_Page_TextChanged);
                        _Txt_Page.Text = _Int_Npage.ToString();
                        _Txt_Page.TextChanged += new EventHandler(_Txt_Page_TextChanged);
                        _Int_P = _Int_Npage;
                    }
                    _Int_P--;
                    _Int_RegOmitidos = _Int_RegSel * _Int_P;
                    _Mtd_Actulizar();
                }
                else
                {
                    _Txt_Page.Text = "1";
                }
            }
            else
            {
            }
        }
        string _Str_CountP;
        private void _Txt_Page_Leave(object sender, EventArgs e)
        {
            if (_Txt_Page.Text == "")
            {
                _Txt_Page.Text = "1";
            }
        }

        private void _Ctrl_Page_SizeChanged(object sender, EventArgs e)
        {
            _Lbl_de.Width = (this.Width - (_Btn_Antes.Width + _Btn_Next.Width + (_Txt_Page.Width / 3))) / 2;
        }

        private void _Ctrl_Page_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }
    }
}
