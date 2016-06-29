using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_Inf_PreCarga : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_PreCarga()
        {
            InitializeComponent();
        }

        private void _Mtd_CargarRutas()
        {
            string _Str_Sql = "Select DISTINCT cidrutdespacho,cdescripcion from VST_PRECARGADR where cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _myUtilidad._Mtd_CargarCheckList(_ChkLst_Rutas, _Str_Sql);
        }
        private void _Mtd_CargarTransporte(string _Pr_Str_IdRuta)
        {
            string _Str_Sql = "Select cplaca,(ccedula + ': ' + convert(varchar(100),ctransportista)) from VST_PRECARGADR where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrutdespacho='" + _Pr_Str_IdRuta + "'";
            _myUtilidad._Mtd_CargarCheckList(_ChkLst_Transporte, _Str_Sql);
        }
        private void _Mtd_CargarTransporte(int _Pr_Int_Item,bool _Pr_Bol_Add)
        {
            string _Str_Sql = "";
            string _Str_IdRuta = "";
            for (int _I = 0; _I < _ChkLst_Rutas.Items.Count; _I++)
            {
                if (_Pr_Bol_Add)
                {
                    if (_ChkLst_Rutas.GetItemChecked(_I) || _I == _Pr_Int_Item)
                    {
                        _Str_IdRuta = _Str_IdRuta + " cidrutdespacho='" + ((Clases._Cls_ArrayList)_ChkLst_Rutas.Items[_I]).Value + "' OR";
                    }
                }
                else
                {
                    if (_ChkLst_Rutas.GetItemChecked(_I) && _I != _Pr_Int_Item)
                    {
                        _Str_IdRuta = _Str_IdRuta + " cidrutdespacho='" + ((Clases._Cls_ArrayList)_ChkLst_Rutas.Items[_I]).Value + "' OR";
                    }
                }
            }
            if (_Str_IdRuta.Length > 0)
            {
                _Str_IdRuta = _Str_IdRuta.Substring(0, _Str_IdRuta.Length - 2);
                _Str_Sql = "Select cplaca,(ccedula + ': ' + convert(varchar(100),ctransportista)) from VST_PRECARGADR where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND (" + _Str_IdRuta + ")";
                _myUtilidad._Mtd_CargarCheckList(_ChkLst_Transporte, _Str_Sql);
            }
            else
            {
                _ChkLst_Transporte.DataSource = null;
            }
        }
        private void _ChkLst_Rutas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                _Mtd_CargarTransporte(e.Index,true);
            }
            else
            {
                _Mtd_CargarTransporte(e.Index,false);
            }
        }

        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }
        private void _Mtd_Consultar()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "", _Str_Rutas = "", _Str_Transporte = "", _Str_Cedula = "";
            string _Str_Filtro = " cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            if (!_Chk_PreC.Checked)
            {
                for (int _I = 0; _I < _ChkLst_Rutas.Items.Count; _I++)
                {
                    if (_ChkLst_Rutas.GetItemChecked(_I))
                    {
                        _Str_Rutas = _Str_Rutas + " cidrutdespacho='" + ((Clases._Cls_ArrayList)_ChkLst_Rutas.Items[_I]).Value + "' OR";
                    }
                }
                if (_Str_Rutas.Length > 0)
                {
                    _Str_Rutas = _Str_Rutas.Substring(0, _Str_Rutas.Length - 3);
                    _Str_Filtro = _Str_Filtro + " AND (" + _Str_Rutas + ")";
                }
                for (int _I = 0; _I < _ChkLst_Transporte.Items.Count; _I++)
                {
                    if (_ChkLst_Transporte.GetItemChecked(_I))
                    {
                        _Str_Cedula = ((Clases._Cls_ArrayList)_ChkLst_Transporte.Items[_I]).Display.Substring(0, ((Clases._Cls_ArrayList)_ChkLst_Transporte.Items[_I]).Display.IndexOf(":"));
                        _Str_Transporte = _Str_Transporte + " (ccedula='" + _Str_Cedula + "' AND cplaca='" + ((Clases._Cls_ArrayList)_ChkLst_Transporte.Items[_I]).Value + "') OR";
                    }
                }
                if (_Str_Transporte.Length > 0)
                {
                    _Str_Transporte = _Str_Transporte.Substring(0, _Str_Transporte.Length - 3);
                    _Str_Filtro = _Str_Filtro + " AND (" + _Str_Transporte + ")";
                }

                if (_Rb_Impresa.Checked)
                {
                    _Str_Filtro = _Str_Filtro + " AND cimprimeprecarga=1";
                }
                else if (_Rb_Facturada.Checked)
                {
                    _Str_Filtro = _Str_Filtro + " AND cimprimefactura=1";
                }
                _Str_Filtro = _Str_Filtro + " AND convert(datetime,convert(varchar(255),cfechaprecarga,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            }
            else
            {
                _Str_Filtro += " AND cprecarga='" + _Txt_PreCarga.Text.Trim() + "'";
            }            
            if (_Chk_PreC.Checked)
            { _Str_Sql = "SELECT * FROM VST_PRECARGALISTADO_2 WHERE" + _Str_Filtro; }
            else
            { _Str_Sql = "SELECT * FROM VST_PRECARGALISTADO WHERE" + _Str_Filtro; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //_Ds.Tables[0].TableName=
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Report.rPreCargaListado _My_Reporte = new T3.Report.rPreCargaListado();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
                tex2.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                //----------------------------
                if (_Mtd_RequiereGuiaSada(_Txt_PreCarga.Text.Trim()))
                {
                    _sec = _My_Reporte.ReportDefinition.Sections["Section3"];
                    TextObject _Txt_RequiereGuiaSada = _sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                    _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
                }
                //----------------------------
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
                MessageBox.Show("No existen Precargas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }
        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Chk_PreC.Checked & _Txt_PreCarga.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingrasar el número de Pre-carga que desea consultar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Txt_PreCarga.Focus();
            }
            else
            {
                bool _Bol_PreCargaExist = false;
                if (_Chk_PreC.Checked)
                {
                    string _Str_Cadena = "SELECT cprecarga FROM VST_PRECARGALISTADO_2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cprecarga='" + _Txt_PreCarga.Text.Trim() + "'";
                    _Bol_PreCargaExist = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
                }
                if (!_Chk_PreC.Checked | (_Chk_PreC.Checked & _Bol_PreCargaExist))
                {
                    _Mtd_Consultar();
                }
                else
                {
                    MessageBox.Show("La Pre-carga que introdujo no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Frm_Inf_PreCarga_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_CargarRutas();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }

        private void _Chk_PreC_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_PreC.Checked)
            {
                _ChkLst_Rutas.Enabled = false;
                _Txt_PreCarga.Enabled = true;
                _Txt_PreCarga.Text = "";
                _ChkLst_Transporte.Enabled = false;
                _Dt_Desde.Enabled = false;
                _Dt_Hasta.Enabled = false;
                _Lkbl_Ayer.Enabled = false;
                _Lkbl_Hoy.Enabled = false;
                _Rb_Facturada.Enabled = false;
                _Rb_Impresa.Enabled = false;
                _Txt_PreCarga.Focus();
            }
            else
            {
                _ChkLst_Rutas.Enabled = true;
                _Txt_PreCarga.Enabled = false;
                _ChkLst_Transporte.Enabled = true;
                _Dt_Desde.Enabled = true;
                _Dt_Hasta.Enabled = true;
                _Lkbl_Ayer.Enabled = true;
                _Lkbl_Hoy.Enabled = true;
                _Rb_Facturada.Enabled = true;
                _Rb_Impresa.Enabled = true;
                _Txt_PreCarga.Text = "";
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Txt_PreCarga_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_PreCarga.Text))
            {
                _Txt_PreCarga.Text = "";
            }
        }

        private void _Txt_PreCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private bool _Mtd_RequiereGuiaSada(string _P_Str_Precarga)
        {
            var _Bol_RequiereGuiaSada = false;
            string _Str_Cadena = "SELECT DISTINCT TPREFACTURAM.ccompany " +
                        "FROM TPRECARGAM INNER JOIN " +
                        "TPRECARGADPF ON TPRECARGAM.cgroupcomp = TPRECARGADPF.cgroupcomp AND " +
                        "TPRECARGAM.cprecarga = TPRECARGADPF.cprecarga INNER JOIN " +
                        "TPREFACTURAM ON dbo.TPRECARGADPF.cpfactura = TPREFACTURAM.cpfactura " +
                        "WHERE TPRECARGAM.cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Ds_Comp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Comp.Tables[0].Rows)
            {
                double _Dbl_Toneladas = 0;
                _Str_Cadena = "SELECT ISNULL(SUM(CONVERT(NUMERIC(18,3),CONVERT(NUMERIC(18,2),CONVERT(NUMERIC(18,2),(TPREFACTURAD.cempaques*(TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))+TPREFACTURAD.cunidades)*CONVERT(NUMERIC(18,2),cpesounid1))/1000000)),0) AS Toneladas " +
                      "FROM TPREFACTURAM INNER JOIN " +
                      "TPREFACTURAD ON TPREFACTURAM.ccompany = TPREFACTURAD.ccompany AND " +
                      "TPREFACTURAM.cpfactura = TPREFACTURAD.cpfactura INNER JOIN " +
                      "TPRECARGADPF ON TPREFACTURAM.cpfactura = TPRECARGADPF.cpfactura INNER JOIN " +
                      "TPRODUCTO ON TPRODUCTO.cproducto = TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSD ON TSICARUBROSD.cproducto=TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSM ON TSICARUBROSD.ccodigorubro=TSICARUBROSM.ccodigorubro AND " +
                      "TSICARUBROSD.cdelete=TSICARUBROSM.cdelete " +
                      "WHERE (TPRECARGADPF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGADPF.cprecarga='" + _P_Str_Precarga + "') AND (TPREFACTURAM.ccompany='" + _Row[0].ToString() + "') AND (TSICARUBROSM.cdelete=0)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Dbl_Toneladas = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
                if (_Dbl_Toneladas > 0)
                {
                    _Bol_RequiereGuiaSada = true;
                }
            }
            return _Bol_RequiereGuiaSada;
        }
    }
}