using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using T3.Clases;

namespace T3
{
    public partial class Frm_CapturaBancoConfPos : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private DataSet _G_Ds_DataSet;
        int _G_Int_CantidadDeColumnas;

        private string _G_Str_cbanco;
        private byte _G_Byte_ctipoconfiguracion;

        public Frm_CapturaBancoConfPos()
        {
            InitializeComponent();
        }
        private void _Mtd_CargarGrid(DataSet _P_Ds_DataSet)
        {
            _Dg_Detalle.Rows.Clear();
            foreach (DataRow _Row in _P_Ds_DataSet.Tables[0].Rows)
            {
                _Dg_Detalle.Rows.Add(_Row.ItemArray);
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
        public void _Mtd_CargarCombo(ComboBox _P_Cmb_Combo, string _Str_Sql, bool _P_Bol_Consulta)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmb_Combo.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

            //Ignacio - 2012-11-14
            //Se cambiaron estas lineas para permitir se cargue el combo con todos los bancos
            //string[] _Str_BancosConfigurados = new string[] { "1", "13", "18", "29" };
            //foreach (DataRow _DRow in _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => _Str_BancosConfigurados.Contains(x[0].ToString().Trim())))

            foreach (DataRow _DRow in _Ds.Tables[0].Rows.Cast<DataRow>())
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _P_Cmb_Combo.DataSource = _myArrayList;
            _P_Cmb_Combo.DisplayMember = "Display";
            _P_Cmb_Combo.ValueMember = "Value";
            _P_Cmb_Combo.SelectedValue = "nulo";
        }
        private void _Mtd_CargarBanco(ComboBox _P_Cmb_Combo, bool _P_Bol_Consulta)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname " +
                                 "FROM TBANCO INNER JOIN TCUENTBANC " +
                                 "ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco " +
                                 "WHERE " +
                                 "TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' " +
                                 "AND " +
                                 "ISNULL(TBANCO.cdelete,0)=0";
            if (!_P_Bol_Consulta)
            { 
                _Str_Cadena += " AND NOT EXISTS(" +
                               "SELECT cbanco " +
                               "FROM TCONFCAPBANCD " +
                               "WHERE " + 
                               "LTRIM(RTRIM(TCONFCAPBANCD.cbanco))=LTRIM(RTRIM(TBANCO.cbanco)) " +
                               "AND " +
                               "TCONFCAPBANCD.ccompany=TBANCO.ccompany AND ISNULL(TCONFCAPBANCD.cdelete,0)=0 "; 
                if (_Opt_TipoConciliacion.Checked || _Opt_TipoDisponibilidad.Checked)
                {
                    var _ctipoconfiguracion = _Opt_TipoConciliacion.Checked ? "1" : "2";
                    _Str_Cadena += "AND TCONFCAPBANCD.ctipoconfiguracion = '" + _ctipoconfiguracion + "'";
                }
                _Str_Cadena += ") ";
            }
            //-----------
            _Str_Cadena += " GROUP BY LTRIM(RTRIM(TBANCO.cbanco)), TBANCO.cname";
            _Str_Cadena += " ORDER BY REPLACE(TBANCO.cname,'BANCO','')";
            _Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena, _P_Bol_Consulta);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarTipoArchivo(ComboBox _P_Cmb_Combo)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmb_Combo.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            //Ignacio - 2012-11-14
            // Se añadieron dos tipos nuevos de archvivos permitidos ASCII y CSV
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ASCII", "A"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("CSV", "C"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("EXCEL", "E"));
            _P_Cmb_Combo.DataSource = _myArrayList;
            _P_Cmb_Combo.DisplayMember = "Display";
            _P_Cmb_Combo.ValueMember = "Value";
            _P_Cmb_Combo.SelectedValue = "nulo";
            _P_Cmb_Combo.DataSource = _myArrayList;
            _P_Cmb_Combo.SelectedIndex = 0;
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT cbanconame,cascciexceldescrip,cbanco,cascciexcel,[Tipo Configuración],ctipoconfiguracion FROM VST_CONFCAPBANCD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0";
            //---------------
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Str_Cadena += " AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue).Trim() + "'"; }
            if (_Cmb_TipArchivo.SelectedIndex > 0)
            { _Str_Cadena += " AND cascciexcel='" + Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim() + "'"; }
            //---------------
            _Str_Cadena += " ORDER BY REPLACE(cbanconame,'BANCO','')";
            //---------------
            Cursor = Cursors.WaitCursor;
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            Cursor = Cursors.Default;
            _Dg_Grid.Columns[2].Visible = false;
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_InicializarComboConf()
        {
            _Cls_RutinasInterfazBancaria._Mtd_CargarComboFormatoFechas(_Cmb_FormatoDeFecha);
            foreach (Control _Ctrl in _Pnl_IzquierdoD.Controls)
            {
                if (_Ctrl.GetType() == typeof(ComboBox))
                {
                    if ((((ComboBox)_Ctrl).Name != "_Cmb_FormatoDeFecha") && (((ComboBox)_Ctrl).Name != "_Cmb_SeparadorDecimales") && (((ComboBox)_Ctrl).Name != "_Cmb_CantidadDecimales"))
                    {
                        ((ComboBox)_Ctrl).Items.Clear();
                    }
                }
            }
        }
        private bool _Mtd_PosicionSeleccionada(ComboBox _P_Cmb_Combo, int _P_Int_Pos)
        {
            var _Var_Controls = from _Ctrl in _Pnl_IzquierdoD.Controls.Cast<Control>() where _Ctrl.GetType() == typeof(ComboBox) select _Ctrl;
            return (from _Ctrl in _Var_Controls.Cast<ComboBox>() where Convert.ToString(_Ctrl.Text).Trim() == _P_Int_Pos.ToString() & _Ctrl.Name != _P_Cmb_Combo.Name select _Ctrl).Count() > 0;
        }
        private bool _Mtd_PosicionSeleccionada(int _P_Int_Pos)
        {
            var _Var_Controls = from _Ctrl in _Pnl_IzquierdoD.Controls.Cast<Control>() where _Ctrl.GetType() == typeof(ComboBox) select _Ctrl;
            return (from _Ctrl in _Var_Controls.Cast<ComboBox>() where Convert.ToString(_Ctrl.Text).Trim() == _P_Int_Pos.ToString() select _Ctrl).Count() > 0;
        }
        private void _Mtd_CargarComboConf(ComboBox _P_Cmb_Combo)
        {
            _P_Cmb_Combo.Items.Clear();
            for (int _Int_I = 1; _Int_I <= _Dg_Detalle.ColumnCount; _Int_I++)
            {
                if (!_Mtd_PosicionSeleccionada(_P_Cmb_Combo, _Int_I))
                { _P_Cmb_Combo.Items.Add(_Int_I); }
            }
        }
        private void _Mtd_ConfigurarColumnas(DataGridView _P_Dg_Grid_Origen, DataGridView _P_Dg_Grid_Destino)
        {
            //-------------------------------EliminarColumnasSobrantes
            int _Int_Count = _P_Dg_Grid_Origen.ColumnCount - 1;
            for (int _Int_I = _Int_Count; _Int_I >= 8; _Int_I--)
            {
                _P_Dg_Grid_Origen.Columns.Remove("_Col_" + _Int_I);
            }
            //-------------------------------Igualar Columnas
            for (int _Int_I = 8; _Int_I > _P_Dg_Grid_Origen.ColumnCount; _Int_I--)
            {
                _P_Dg_Grid_Destino.Columns.Remove("_Col_" + _Int_I);
            }
            //-------------------------------
        }
        private void _Mtd_IniGridDetalle(int _P_Int_CantidadColumnas)
        {
            _Dg_Detalle.Rows.Clear();
            _Dg_Detalle.Columns.Clear();
            DataGridViewTextBoxColumn _Col;
            for (int _Int_I = 1; _Int_I <= _P_Int_CantidadColumnas; _Int_I++)
            {
                _Col = new DataGridViewTextBoxColumn();
                _Col.Name = "_Col_" + _Int_I;
                _Col.HeaderText = "Pos.(" + _Int_I + ")";
                _Dg_Detalle.Columns.Add(_Col);
            }
        }
        private object[] _Mtd_ConvertRowToObject(DataGridViewRow _P_Dg_Row)
        {
            object[] _Ob = new object[_P_Dg_Row.Cells.Count];
            for (int _Int_I = 0; _Int_I < _P_Dg_Row.Cells.Count; _Int_I++)
            {
                _Ob[_Int_I] = _P_Dg_Row.Cells[_Int_I].Value;
            }
            return _Ob;
        }
        private void _Mtd_RenombrarColumnas()
        {
            int _Int_I = 0;
            _Dg_Detalle.SuspendLayout();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataGridViewColumn _Col in _Dg_Detalle.Columns)
            {
                _Int_I++;
                if (!_Mtd_PosicionSeleccionada(_Int_I))
                { _Col.HeaderText = "Pos.(" + _Int_I + ")"; }
            }
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.ResumeLayout();
        }
        private void _Mtd_AlinearColumnas()
        {
            int _Int_I = 0;
            _Dg_Detalle.SuspendLayout();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataGridViewColumn _Col in _Dg_Detalle.Columns)
            {
                switch (_Col.HeaderText)
                {
                    case "Monto del movimiento":
                    case "Monto del movimiento 1":
                    case "Saldo del movimiento":
                        _Dg_Detalle.Columns[_Int_I].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    default:
                        _Dg_Detalle.Columns[_Int_I].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                }
                _Int_I++;
            }
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.ResumeLayout();
        }
        private decimal _Mtd_StringToDecimal(string _P_Str_Valor)
        {
            if (_P_Str_Valor.Trim().Length == 0)
            { return 0; }
            return Convert.ToDecimal(_P_Str_Valor);
        }

        private bool _Mtd_ExisteTCONFCAPBANCD(string _P_Str_Banco, byte _P_Byte_ctipoconfiguracion)
        {
            return (from Campos in Program._Dat_Tablas.TCONFCAPBANCD
                    where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cbanco == _P_Str_Banco.Trim() & Campos.ctipoconfiguracion == _P_Byte_ctipoconfiguracion
                    select Campos.cbanco).Count() > 0;
        }
        private void _Mtd_SeleccionarCombosConf()
        {
            var _Var_Controls = from _Ctrl in _Pnl_IzquierdoD.Controls.Cast<Control>() where _Ctrl.GetType() == typeof(ComboBox) select _Ctrl;
            foreach (ComboBox _Cmb_ in _Var_Controls)
            {
                if ((_Cmb_.Name != "_Cmb_FormatoDeFecha") & (_Cmb_.Name != "_Cmb_SeparadorDecimales") & (_Cmb_.Name != "_Cmb_CantidadDecimales"))
                {
                    if (_Cmb_.Items[0].ToString().Trim() == "0")
                    { _Cmb_.Items.Clear(); }
                    else
                    { _Cmb_.SelectedIndex = 0; }
                }
            }
        }
        public void _Mtd_Habilitar()
        {
            string _Str_Banco = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim();
            //_Mtd_Nuevo();
            _Mtd_CargarBanco(_Cmb_BancoD, true);
            _Cmb_BancoD.SelectedValue = _Str_Banco;
            _Cmb_BancoD.Enabled = false;
            _Mtd_Igualar(_G_Str_cbanco, _G_Byte_ctipoconfiguracion);
            _Pnl_IzquierdoD.Enabled = true;
            _Txt_ccantidadcaracteresatomarconcepto.Enabled = _Chk_ObtenerTipoOperacionSegunElUsuario.Checked;
            _Txt_ccantidadcaracteresatomarconcepto.ReadOnly = !_Txt_ccantidadcaracteresatomarconcepto.Enabled;
            _Pnl_SuperiorD.Enabled = true;
            _Bt_Abrir.Enabled = true;
        }
        private void _Mtd_Ini()
        {
            _Mtd_CargarBanco(_Cmb_BancoD, false);
            _Mtd_CargarTipoArchivo(_Cmb_TipArchivoD);
            _Mtd_CargarSeparadorDecimales();
            _Mtd_CargarCantidadDecimales();
            _Mtd_InicializarComboConf();
            _Mtd_IniGridDetalle(8);
            _Txt_RutaFile.Text = "";
            _Opt_TipoConciliacion.Checked = false;
            _Opt_TipoDisponibilidad.Checked = false;
            _Txt_ccantidadcaracteresatomarconcepto.Text = "";
            _Txt_ccantidadcolumnasvaciaspermitidas.Text = "";
            _Er_Error.Dispose();
        }
        public void _Mtd_Nuevo()
        {
            _Pnl_SuperiorD.Enabled = true;
            _Pnl_IzquierdoD.Enabled = false;
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_BancoD.Enabled = true;
            _Cmb_BancoD.Focus();
        }
        private void _Mtd_InsertarTCONFCAPBANCD(string _P_Str_Banco, byte _P_Byte_ctipoconfiguracion)
        {
            DataContext.TCONFCAPBANCD _T_TCONFCAPBANCD = new T3.DataContext.TCONFCAPBANCD()
            {
                ccompany = Frm_Padre._Str_Comp,
                cascciexcel = Convert.ToChar(_Cmb_TipArchivoD.SelectedValue),
                cbanco = _P_Str_Banco.Trim(),
                cposconcepto = _Mtd_StringToDecimal(_Cmb_Concepto.Text),
                cposdatemovi = _Mtd_StringToDecimal(_Cmb_FechaMov.Text),
                cposmontomov = _Mtd_StringToDecimal(_Cmb_MontoMov.Text),
                cposmontomov1 = _Mtd_StringToDecimal(_Cmb_MontoMov1.Text),
                cposnumdocu = _Mtd_StringToDecimal(_Cmb_NumDoc.Text),
                cposoficinabanc = _Mtd_StringToDecimal(_Cmb_OficBanco.Text),
                cpossaldomov = _Mtd_StringToDecimal(_Cmb_SaldoMov.Text),
                cpostipoperacio = _Mtd_StringToDecimal(_Cmb_TipOper.Text),
                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                cuseradd = Frm_Padre._Str_Use,
                cdelete = 0,

                ctiposeparador = Convert.ToByte(_Txt_TipoDeSeparador.Text),
                cdelimitador = _Txt_Delimitador.Text,
                clineainiciodatos = _Mtd_StringToDecimal(_Txt_LineaInicioDatos.Text),

                cformatofecha = _Cmb_FormatoDeFecha.Text,

                ctiposeparadordecimal = Convert.ToByte(_Cmb_SeparadorDecimales.SelectedValue),
                ccantidaddigitosdecimales = Convert.ToByte(_Cmb_CantidadDecimales.SelectedValue),
                cobtenermontoregistroseguncolumnasaldo = _Chk_ObtenerMontoRegistroSegunColumnaSaldo.Checked ? Convert.ToByte(1) : Convert.ToByte(0),
                cobtenertipooperacionseguncolumnaconcepto = _Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked ? Convert.ToByte(1) : Convert.ToByte(0),
                cobtenertipooperacionsegunsignomonto = _Chk_ObtenerTipoOperacionSegunSignoMonto.Checked ? Convert.ToByte(1) : Convert.ToByte(0),
                cobtenertipooperacionsegunelusuario = _Chk_ObtenerTipoOperacionSegunElUsuario.Checked ? Convert.ToByte(1) : Convert.ToByte(0),
                ccantidadcaracteresatomarconcepto = Convert.ToByte(_Txt_ccantidadcaracteresatomarconcepto.Text),
                ccantidadcolumnasvaciaspermitidas = Convert.ToByte(_Txt_ccantidadcolumnasvaciaspermitidas.Text),
                ctipoconfiguracion = _P_Byte_ctipoconfiguracion,
            };
            Program._Dat_Tablas.TCONFCAPBANCD.InsertOnSubmit(_T_TCONFCAPBANCD);
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_EliminarTCONFCAPBANCD(string _P_Str_Banco, byte _P_Byte_ctipoconfiguracion)
        {
            DataContext.TCONFCAPBANCD _T_TCONFCAPBANCD = Program._Dat_Tablas.TCONFCAPBANCD.Single(Campos => Campos.ccompany == Frm_Padre._Str_Comp & Campos.cbanco == _P_Str_Banco.Trim() & Campos.ctipoconfiguracion == _P_Byte_ctipoconfiguracion);
            Program._Dat_Tablas.TCONFCAPBANCD.DeleteOnSubmit(_T_TCONFCAPBANCD);
            Program._Dat_Tablas.SubmitChanges();
        }
        //private void _Mtd_ModificarTCONFCAPBANCD(string _P_Str_Banco)
        //{
        //    //DataContext.TCONFCAPBANCD _T_TCONFCAPBANCD = Program._Dat_Tablas.TCONFCAPBANCD.Single(Campos => Campos.ccompany == Frm_Padre._Str_Comp & Campos.cbanco == _P_Str_Banco.Trim() & Campos.cascciexcel == Convert.ToChar(_Cmb_TipArchivoD.SelectedValue));
        //    DataContext.TCONFCAPBANCD _T_TCONFCAPBANCD = Program._Dat_Tablas.TCONFCAPBANCD.Single(Campos => Campos.ccompany == Frm_Padre._Str_Comp & Campos.cbanco == _P_Str_Banco.Trim());
        //    _T_TCONFCAPBANCD.cposconcepto = _Mtd_StringToDecimal(_Cmb_Concepto.Text);
        //    _T_TCONFCAPBANCD.cposdatemovi = _Mtd_StringToDecimal(_Cmb_FechaMov.Text);
        //    _T_TCONFCAPBANCD.cposmontomov = _Mtd_StringToDecimal(_Cmb_MontoMov.Text);
        //    _T_TCONFCAPBANCD.cposmontomov1 = _Mtd_StringToDecimal(_Cmb_MontoMov1.Text);
        //    _T_TCONFCAPBANCD.cposnumdocu = _Mtd_StringToDecimal(_Cmb_NumDoc.Text);
        //    _T_TCONFCAPBANCD.cposoficinabanc = _Mtd_StringToDecimal(_Cmb_OficBanco.Text);
        //    _T_TCONFCAPBANCD.cpossaldomov = _Mtd_StringToDecimal(_Cmb_SaldoMov.Text);
        //    _T_TCONFCAPBANCD.cpostipoperacio = _Mtd_StringToDecimal(_Cmb_TipOper.Text);
        //    _T_TCONFCAPBANCD.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
        //    _T_TCONFCAPBANCD.cuserupd = Frm_Padre._Str_Use;

        //    _T_TCONFCAPBANCD.cascciexcel = Convert.ToChar(_Cmb_TipArchivoD.SelectedValue);

        //    //Si estaba borrado, lo vuelvo a habilitar;
        //    _T_TCONFCAPBANCD.cdelete = 0;
        //    _T_TCONFCAPBANCD.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
        //    _T_TCONFCAPBANCD.cuseradd = Frm_Padre._Str_Use;

        //    _T_TCONFCAPBANCD.ctiposeparador = Convert.ToByte(_Txt_TipoDeSeparador.Text);
        //    _T_TCONFCAPBANCD.cdelimitador = _Txt_Delimitador.Text;
        //    _T_TCONFCAPBANCD.clineainiciodatos = _Mtd_StringToDecimal(_Txt_LineaInicioDatos.Text);

        //    Program._Dat_Tablas.SubmitChanges();
        //}
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        private bool _Mtd_ColumnasObligatoriasConfiguradas()
        {
            bool _Bol_Return = true;
            var _Var_Controls = from _Ctrl in _Pnl_IzquierdoD.Controls.Cast<Control>() where _Ctrl.GetType() == typeof(ComboBox) select _Ctrl;
            foreach (ComboBox _Cmb_ in _Var_Controls.Cast<ComboBox>().Where(c => c.Name != _Cmb_Concepto.Name && c.Name != _Cmb_MontoMov1.Name && c.Name != _Cmb_SaldoMov.Name && c.Name != _Cmb_OficBanco.Name && c.Name != _Cmb_TipOper.Name && c.SelectedIndex == -1))
            {
                _Er_Error.SetError(_Cmb_, "Información requerida!!!");
                _Bol_Return = false;
            }
            //Aqui verificamos con la nueva opcion de que el tipo de operacion se toma del concepto
            if (_Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked)
            {
                //Validacion normal
                if (_Cmb_Concepto.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cmb_Concepto, "Información requerida!!!");
                    _Bol_Return = false;
                }
            }
            //Aqui verificamos con la nueva opcion de que el tipo de operacion se toma del signo del monto
            else if (_Chk_ObtenerTipoOperacionSegunSignoMonto.Checked)
            {
                //Validacion normal
                if (_Cmb_MontoMov.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cmb_Concepto, "Información requerida!!!");
                    _Bol_Return = false;
                }
            }
            //Aqui verificamos con la nueva opcion de que el tipo de operacion lo cargar el usuario
            else if (_Chk_ObtenerTipoOperacionSegunElUsuario.Checked)
            {
                //Validamos que se haya cargado la cantidad de caracteres del concepto
                if (_Txt_ccantidadcaracteresatomarconcepto.Text == "")
                {
                    _Er_Error.SetError(_Txt_ccantidadcaracteresatomarconcepto, "Información requerida!!!");
                    _Bol_Return = false;
                }
                if (Convert.ToByte(_Txt_ccantidadcaracteresatomarconcepto.Text) < 0)
                {
                    _Er_Error.SetError(_Txt_ccantidadcaracteresatomarconcepto, "Información requerida, no puede ser meno que cero!!!");
                    _Bol_Return = false;
                }
                if (Convert.ToByte(_Txt_ccantidadcaracteresatomarconcepto.Text) > 255)
                {
                    _Er_Error.SetError(_Txt_ccantidadcaracteresatomarconcepto, "Información requerida, no puede ser mayor a 255!!!");
                    _Bol_Return = false;
                }
            }
            else
            {
                //Validacion normal
                if (_Cmb_TipOper.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cmb_TipOper, "Información requerida!!!");
                    _Bol_Return = false;
                }
            }
            if (!_Opt_TipoConciliacion.Checked & !_Opt_TipoDisponibilidad.Checked)
            {
                _Er_Error.SetError(_Opt_TipoConciliacion, "Información requerida!!!");
                _Er_Error.SetError(_Opt_TipoDisponibilidad, "Información requerida!!!");
                _Bol_Return = false;
            }

            //Validamos que se haya cargado la cantidad de columnas vacias permitidas para los registros
            if (_Txt_ccantidadcolumnasvaciaspermitidas.Text == "")
            {
                _Er_Error.SetError(_Txt_ccantidadcolumnasvaciaspermitidas, "Información requerida!!!");
                _Bol_Return = false;
            }
            if (Convert.ToByte(_Txt_ccantidadcolumnasvaciaspermitidas.Text) < 0)
            {
                _Er_Error.SetError(_Txt_ccantidadcolumnasvaciaspermitidas, "Información requerida, no puede ser menor que cero!!!");
                _Bol_Return = false;
            }
            if (Convert.ToByte(_Txt_ccantidadcolumnasvaciaspermitidas.Text) > 255)
            {
                _Er_Error.SetError(_Txt_ccantidadcolumnasvaciaspermitidas, "Información requerida, no puede ser mayor a 255!!!");
                _Bol_Return = false;
            }

            return _Bol_Return;
        }
        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (MessageBox.Show("Está seguro de Eliminar esta configuración para este Banco?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TCONFCAPBANCD SET cdelete=1,cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                Program._Dat_Tablas.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Program._Dat_Tablas.TCONFCAPBANCD);
                MessageBox.Show("Transacción Eliminada Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Color_Estandar(this);
                _Mtd_CargarBanco(_Cmb_Banco, true);
                _Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
                _Mtd_Actualizar();
                _Txt_LineaInicioDatos.Text = "";
                _Txt_TipoDeSeparador.Text = "";
                _Txt_Delimitador.Text = "";
                _Tb_Tab.SelectedIndex = 0;
                _Bol_R = true;
            }
            return _Bol_R;
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Dg_Detalle.RowCount > 0 & _Mtd_ColumnasObligatoriasConfiguradas())
            {
                //Verifico si el formato la columna de fecha seleccionada SE PUEDA convertir a fecha valida segun el formato de fecha seleccionado desde el dataset original
                if (_Cls_RutinasInterfazBancaria._Mtd_VerificarConversionDeDatosAFecha(_G_Ds_DataSet, Convert.ToInt32(_Cmb_FechaMov.Text), _Cmb_FormatoDeFecha.Text))
                {
                    var _ctipoconfiguracion = _Opt_TipoConciliacion.Checked ? Convert.ToByte(1) : Convert.ToByte(2);

                    if (_Mtd_ExisteTCONFCAPBANCD(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), _ctipoconfiguracion))
                    {
                        _Mtd_EliminarTCONFCAPBANCD(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), _ctipoconfiguracion);
                        _Mtd_InsertarTCONFCAPBANCD(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), _ctipoconfiguracion);
                    }
                    else
                    {
                        _Mtd_InsertarTCONFCAPBANCD(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), _ctipoconfiguracion);
                    }
                    _G_Ds_DataSet = null;
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                    MessageBox.Show("La configuración se ha guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    _Er_Error.SetError(_Cmb_FormatoDeFecha, "No se puede convertir la fecha al formato seleccionado. Información requerida!!!");
                    return false;
                }
            }
            else
            {
                if (_Dg_Detalle.RowCount == 0)
                { _Er_Error.SetError(_Txt_RutaFile, "Información requerida!!!"); }
            }
            return false;
        }
        private void _Mtd_Igualar(string _P_Str_Banco, byte _P_Byte_ctipoconfiguracion)
        {
            _G_Str_cbanco = _P_Str_Banco;
            _G_Byte_ctipoconfiguracion = _P_Byte_ctipoconfiguracion;

            var _Var_Datos = from Campos in Program._Dat_Tablas.TCONFCAPBANCD
                             where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cbanco == _P_Str_Banco.Trim() & Campos.ctipoconfiguracion == _P_Byte_ctipoconfiguracion
                             select Campos;

            //Guardo la cantidad de columnas a cargar en la variable del fomulario
            _G_Int_CantidadDeColumnas = _Cls_RutinasInterfazBancaria._Mtd_ObtenerCantidadDeColumnasConfiguracionBancaria(_Var_Datos.Single());

            _Cmb_BancoD.SelectedValue = _Var_Datos.Single().cbanco;
            _Cmb_TipArchivoD.SelectedValue = _Var_Datos.Single().cascciexcel.ToString();
            _Cmb_NumDoc.Items.Add(_Var_Datos.Single().cposnumdocu);
            _Cmb_FechaMov.Items.Add(_Var_Datos.Single().cposdatemovi);
            _Cmb_TipOper.Items.Add(_Var_Datos.Single().cpostipoperacio);
            _Cmb_MontoMov.Items.Add(_Var_Datos.Single().cposmontomov);
            _Cmb_MontoMov1.Items.Add(_Var_Datos.Single().cposmontomov1);
            _Cmb_Concepto.Items.Add(_Var_Datos.Single().cposconcepto);
            _Cmb_OficBanco.Items.Add(_Var_Datos.Single().cposoficinabanc);
            _Cmb_SaldoMov.Items.Add(_Var_Datos.Single().cpossaldomov);

            _Txt_LineaInicioDatos.Text = _Var_Datos.Single().clineainiciodatos.ToString();
            _Txt_TipoDeSeparador.Text = _Var_Datos.Single().ctiposeparador.ToString();
            _Txt_Delimitador.Text = _Var_Datos.Single().cdelimitador + "";

            _Cmb_FormatoDeFecha.Text = _Var_Datos.Single().cformatofecha;

            _Cmb_SeparadorDecimales.SelectedValue = _Var_Datos.Single().ctiposeparadordecimal.ToString();
            _Cmb_CantidadDecimales.SelectedValue = _Var_Datos.Single().ccantidaddigitosdecimales.ToString();

            _Mtd_SeleccionarCombosConf();

            _Chk_ObtenerMontoRegistroSegunColumnaSaldo.Checked = _Var_Datos.Single().cobtenermontoregistroseguncolumnasaldo == 1;
            _Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked = _Var_Datos.Single().cobtenertipooperacionseguncolumnaconcepto == 1;
            _Chk_ObtenerTipoOperacionSegunSignoMonto.Checked = _Var_Datos.Single().cobtenertipooperacionsegunsignomonto == 1;
            _Chk_ObtenerTipoOperacionSegunElUsuario.Checked = _Var_Datos.Single().cobtenertipooperacionsegunelusuario == 1;
            _Txt_ccantidadcaracteresatomarconcepto.Text = _Var_Datos.Single().ccantidadcaracteresatomarconcepto.ToString(CultureInfo.InvariantCulture);
            _Txt_ccantidadcolumnasvaciaspermitidas.Text = _Var_Datos.Single().ccantidadcolumnasvaciaspermitidas.ToString(CultureInfo.InvariantCulture);
            
            if (_Var_Datos.Single().ctipoconfiguracion == 1)
                _Opt_TipoConciliacion.Checked = true;
            else
                _Opt_TipoDisponibilidad.Checked = true;

        }
        private void Frm_CapturaBancoConfPos_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Pnl_SuperiorD.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Pnl_SuperiorD.Enabled & _Tb_Tab.SelectedIndex == 1;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
        }

        private void Frm_CapturaBancoConfPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_CapturaBancoConfPos_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_CargarBanco(_Cmb_Banco, true);
            _Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
            _Mtd_Actualizar();
            _Txt_LineaInicioDatos.Text = "";
            _Txt_TipoDeSeparador.Text = "";
            _Txt_Delimitador.Text = "";
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco(_Cmb_Banco, true);
        }

        private void _Cmb_TipArchivo_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Cmb_BancoD_DropDown(object sender, EventArgs e)
        {
            if (!_Opt_TipoConciliacion.Checked & !_Opt_TipoDisponibilidad.Checked)
            {
                MessageBox.Show("Error en la operación. Debe seleccionar el tipo de configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Mtd_CargarBanco(_Cmb_BancoD, false);
        }

        private void _Cmb_TipArchivoD_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTipoArchivo(_Cmb_TipArchivoD);
        }

        private void _Cmb_BancoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarTipoArchivo(_Cmb_TipArchivoD);
            _Cmb_TipArchivoD.Enabled = _Cmb_BancoD.SelectedIndex > 0;
        }

        private void _Cmb_TipArchivoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Abrir.Enabled = _Cmb_TipArchivoD.SelectedIndex > 0;
            _Mtd_InicializarComboConf();
            _Pnl_IzquierdoD.Enabled = false;
            _Mtd_IniGridDetalle(_G_Int_CantidadDeColumnas);
            _Txt_RutaFile.Text = "";
            _Txt_LineaInicioDatos.Text = "";
            _Txt_TipoDeSeparador.Text = "";
            _Txt_Delimitador.Text = "";
        }
        private void _Bt_Abrir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_TipArchivoD.SelectedValue).Trim() == "A")
            {
                _Dlg_OpenFile.Filter = "Txt files (*.txt)|*.txt";
            }
            else if (Convert.ToString(_Cmb_TipArchivoD.SelectedValue).Trim() == "C")
            {
                _Dlg_OpenFile.Filter = "Csv files (*.csv)|*.csv";
            }
            else
            {
                _Dlg_OpenFile.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            }
            if (_Dlg_OpenFile.ShowDialog() == DialogResult.OK && _Dlg_OpenFile.CheckFileExists)
            {
                //Pasamos le nombre a minuscula
                var _Str_NombreArchivo = _Dlg_OpenFile.FileName.Trim().ToLower();
               
                if (_Cls_RutinasInterfazBancaria._Mtd_EsAscii(_Str_NombreArchivo))
                {
                    _Pnl_IzquierdoD.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        Frm_VistaArchivo _Frm = new Frm_VistaArchivo(_Str_NombreArchivo);
                        if (_Frm.ShowDialog(this) == DialogResult.OK)
                        {
                            Cursor = Cursors.WaitCursor;
                            PasarDatosDelFormularioDeVistaDeArchivo(_Frm);
                            DataSet _Ds_NewDataDs = new DataSet();                      //Genero el Dataset Vacio
                            _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ExportarDeDataGridViewADataSet(_Frm._Dg_Carga);         //Paso el DatagridView al Dataset
                            _G_Ds_DataSet = _Ds_NewDataDs;
                            _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, 1);   //Limpio los Datos
                            _Dg_Detalle.Rows.Clear();                                   //Borro el Grid
                            if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)                // Si viene vacio genero el error
                            { throw new Exception(); }

                            _Mtd_IniGridDetalle(_Ds_NewDataDs.Tables[0].Columns.Count); //Inicializo el Grid
                            _Mtd_CargarGrid(_Ds_NewDataDs);                             //Cargo el Grid

                            Cursor = Cursors.Default;
                        }
                    }
                    catch (Exception _Ex)
                    {
                        MessageBox.Show("Error en la operación. Verifique que el archivo elegido corresponda con el banco seleccionado.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor = Cursors.Default;
                    if (_Dg_Detalle.RowCount > 0)
                    {
                        _Txt_RutaFile.Text = _Str_NombreArchivo;
                        _Pnl_IzquierdoD.Enabled = true;
                        _Cmb_NumDoc.Focus();
                    }

                }
                else if (_Cls_RutinasInterfazBancaria._Mtd_EsCsv(_Str_NombreArchivo))
                {
                    _Pnl_IzquierdoD.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        Frm_VistaArchivo _Frm = new Frm_VistaArchivo(_Str_NombreArchivo);
                        if (_Frm.ShowDialog(this) == DialogResult.OK)
                        {
                            Cursor = Cursors.WaitCursor;
                            PasarDatosDelFormularioDeVistaDeArchivo(_Frm);
                            DataSet _Ds_NewDataDs = new DataSet();                      //Genero el Dataset Vacio
                            _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ExportarDeDataGridViewADataSet(_Frm._Dg_Carga);         //Paso el DatagridView al Dataset

                            _G_Ds_DataSet = _Ds_NewDataDs;
                            _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, 1);   //Limpio los Datos
                            _Dg_Detalle.Rows.Clear();                                   //Borro el Grid
                            if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)                // Si viene vacio genero el error
                            { throw new Exception(); }

                            _Mtd_IniGridDetalle(_Ds_NewDataDs.Tables[0].Columns.Count); //Inicializo el Grid
                            _Mtd_CargarGrid(_Ds_NewDataDs);                             //Cargo el Grid

                            Cursor = Cursors.Default;
                        }
                    }
                    catch (Exception _Ex)
                    {
                        MessageBox.Show("Error en la operación. Verifique que el archivo elegido corresponda con el banco seleccionado.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor = Cursors.Default;
                    if (_Dg_Detalle.RowCount > 0)
                    {
                        _Txt_RutaFile.Text = _Str_NombreArchivo;
                        _Pnl_IzquierdoD.Enabled = true;
                        _Cmb_NumDoc.Focus();
                    }
                }
                else if (_Cls_RutinasInterfazBancaria._Mtd_EsExcel(_Str_NombreArchivo))
                {
                    _Pnl_IzquierdoD.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        //Solicito la Linea de Inicio de Datos
                        string _Str_LineaInicioDatos = "";
                        while (!_Cls_VariosMetodos._Mtd_IsNumeric(_Str_LineaInicioDatos))
                        {
                            _Str_LineaInicioDatos = InputBox.Show("Por favor introduzca la Línea de Inicio de Datos", "¿Cuál es la Línea de Inicio de Datos?").Text;
                        }
                        _Txt_LineaInicioDatos.Text = _Str_LineaInicioDatos;
                        //Configuro los Campos que no son de Excel y que no pueden estar vacios
                        _Txt_TipoDeSeparador.Text = "0";
                        _Txt_Delimitador.Text = "";
                        //Cargo el archivo de Excel
                        Cursor = Cursors.WaitCursor;
                        var _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_GetExcel(_Str_NombreArchivo);
                        //Configuro el Dataset
                        _G_Ds_DataSet = _Ds_NewDataDs;
                        _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, Convert.ToInt32(_Str_LineaInicioDatos));
                        if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)
                        { throw new Exception(); }
                        _Mtd_IniGridDetalle(_Ds_NewDataDs.Tables[0].Columns.Count);
                        _Mtd_CargarGrid(_Ds_NewDataDs);

                    }
                    catch (Exception _Ex)
                    {
                        MessageBox.Show("Error en la operación. Verifique que el archivo elegido corresponda con el banco seleccionado.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor = Cursors.Default;
                    if (_Dg_Detalle.RowCount > 0)
                    {
                        _Txt_RutaFile.Text = _Str_NombreArchivo;
                        _Pnl_IzquierdoD.Enabled = true;
                        _Cmb_NumDoc.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Archivo no válido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        // Ignacio - 2012-11-15
        private void PasarDatosDelFormularioDeVistaDeArchivo(Frm_VistaArchivo _Frm)
        {

            //Tipo de Separador
            _Txt_TipoDeSeparador.Text = _Frm._Rb_Caracteres.Checked ? "0" : "1";

            //Delimitadores
            if (_Frm._Rb_Tabulacion.Checked)
            {
                _Txt_Delimitador.Text = "\t";
            }
            else if (_Frm._Rb_Coma.Checked)
            {
                _Txt_Delimitador.Text = ",";
            }
            else if (_Frm._Rb_PuntoYComa.Checked)
            {
                _Txt_Delimitador.Text = ";";
            }
            else if (_Frm._Rb_Espacio.Checked)
            {
                _Txt_Delimitador.Text = " ";
            }
            else if (_Frm._Rb_Otro.Checked)
            {
                _Txt_Delimitador.Text = _Frm._Txt_Otro.Text;
            }

            //Linea Inicio Datos
            _Txt_LineaInicioDatos.Text = _Frm._Txt_LineaInicioDatos.Text;

        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Pnl_SuperiorD.Enabled & e.TabPageIndex == 1)
            { e.Cancel = true; }
            else if (e.TabPageIndex == 0)
            {
                _Mtd_Ini();
                _Pnl_SuperiorD.Enabled = false;
                _Pnl_IzquierdoD.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
        }

        private void _Cmb_CombosConf_DropDown(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectedIndex = -1;
            _Mtd_RenombrarColumnas();
        }

        private void _Bt_Inicializar_Click(object sender, EventArgs e)
        {
            _Mtd_InicializarComboConf();
            _Mtd_RenombrarColumnas();
        }

        private void _Cmb_CombosConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtenemos el nombre del combo
            var _Srt_NombreCombo = ((ComboBox) sender).Name;
            if (((ComboBox)sender).SelectedIndex > -1)
            {
                //Excepto para los Combos de configuracion de decimales
                if ((_Srt_NombreCombo != "_Cmb_SeparadorDecimales") & (_Srt_NombreCombo != "_Cmb_CantidadDecimales") & (_Srt_NombreCombo != "_Cmb_FormatoDeFecha"))
                {
                    _Dg_Detalle.Columns[Convert.ToInt32(((ComboBox)sender).Text) - 1].HeaderText = Convert.ToString(((ComboBox)sender).Tag);
                }
                //Si se selecciona algo del combo de fechas activo el combo de formato de fechas
                if (((ComboBox)sender).Name == "_Cmb_FechaMov")
                {
                    //Si tiene seleccionado algun valor
                    if (((ComboBox)sender).SelectedIndex > -1)
                    {
                        _Cmb_FormatoDeFecha.Enabled = true;
                    }
                    else
                    {
                        _Cmb_FormatoDeFecha.Enabled = false;
                    }
                }
                //Si se selecciona algo del combo de separador de decimales, el numero de decimales a tomar es no aplica
                if (((ComboBox)sender).Name == "_Cmb_SeparadorDecimales")
                {
                    //Si tiene seleccionado algun valor
                    if (((ComboBox)sender).SelectedIndex > 0)
                    {
                        _Cmb_CantidadDecimales.Enabled = false;
                        //_Cmb_CantidadDecimales.SelectedValue = 0;
                    }
                    else
                    {
                        _Cmb_CantidadDecimales.Enabled = true;
                        //_Cmb_CantidadDecimales.SelectedValue = "0";
                    }
                }
                //Si se selecciona algo del combo de cantidad de decimales, el separador de decimales a tomar es no aplica
                if (((ComboBox)sender).Name == "_Cmb_CantidadDecimales")
                {
                    //Si tiene seleccionado algun valor
                    if (((ComboBox)sender).SelectedIndex > 0)
                    {
                        _Cmb_SeparadorDecimales.Enabled = false;
                        //_Cmb_SeparadorDecimales.SelectedValue = 0;
                    }
                    else
                    {
                        _Cmb_SeparadorDecimales.Enabled = true;
                        //_Cmb_SeparadorDecimales.SelectedValue = "0";
                    }
                }
            }
            _Mtd_RenombrarColumnas();
            _Mtd_FormatearGridSegunCombos();
            _Mtd_AlinearColumnas();
        }

        private void _Cmb_CombosConf_Enter(object sender, EventArgs e)
        {
            _Mtd_CargarComboConf(((ComboBox)sender));
            _Mtd_RenombrarColumnas();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Mtd_CargarBanco(_Cmb_BancoD, true);
                _Mtd_CargarSeparadorDecimales();
                _Mtd_CargarCantidadDecimales();
                _Mtd_Igualar(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cbanco"].Value).Trim(), Convert.ToByte(_Dg_Grid.Rows[e.RowIndex].Cells["ctipoconfiguracion"].Value));
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            }
        }

        private void _Mtd_CargarSeparadorDecimales()
        {
            var _myArrayList = new System.Collections.ArrayList();
            _Cmb_SeparadorDecimales.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("No Aplica", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Coma(,)", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Punto(.)", "2"));
            _Cmb_SeparadorDecimales.DataSource = _myArrayList;
            _Cmb_SeparadorDecimales.DisplayMember = "Display";
            _Cmb_SeparadorDecimales.ValueMember = "Value";
            _Cmb_SeparadorDecimales.SelectedValue = "0";
            _Cmb_SeparadorDecimales.DataSource = _myArrayList;
            _Cmb_SeparadorDecimales.SelectedIndex = 0;
        }

        private void _Mtd_CargarCantidadDecimales()
        {
            var _myArrayList = new System.Collections.ArrayList();
            _Cmb_CantidadDecimales.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("No Aplica", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("1", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("2", "2"));
            _Cmb_CantidadDecimales.DataSource = _myArrayList;
            _Cmb_CantidadDecimales.DisplayMember = "Display";
            _Cmb_CantidadDecimales.ValueMember = "Value";
            _Cmb_CantidadDecimales.SelectedValue = "0";
            _Cmb_CantidadDecimales.DataSource = _myArrayList;
            _Cmb_CantidadDecimales.SelectedIndex = 0;
        }

        private void _Mtd_FormatearGridSegunCombos()
        {
            if (_G_Ds_DataSet != null)
            {
                Cursor = Cursors.WaitCursor;
                Byte _Byte_SeparadorDecimal = 0;
                Byte _Byte_CantidadDigitosDecimal = 0;
                //Obtenemos los valores segun los combos
                if (_Cmb_SeparadorDecimales.SelectedValue != null)
                {
                    _Byte_SeparadorDecimal = Convert.ToByte(_Cmb_SeparadorDecimales.SelectedValue);
                }
                if (_Cmb_CantidadDecimales.SelectedValue != null)
                {
                    _Byte_CantidadDigitosDecimal = Convert.ToByte(_Cmb_CantidadDecimales.SelectedValue);
                }
                _Mtd_FormatearGrid(_Dg_Detalle, _G_Ds_DataSet, _Byte_SeparadorDecimal, _Byte_CantidadDigitosDecimal);
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_FormatearGrid(DataGridView _P_Dg, DataSet _P_Ds_Original, byte _P_Byte_SeparadorDecimal, byte _P_Byte_CantidadDigitosDecimal)
        {
            //Obtenemos los indices de los combos
            var _Int_NumeroDocumento = (Convert.ToInt32(_Cmb_NumDoc.SelectedItem) - 1);
            var _Int_FechaMovimiento = (Convert.ToInt32(_Cmb_FechaMov.SelectedItem) - 1);
            var _Int_MontoMovimiento = (Convert.ToInt32(_Cmb_MontoMov.SelectedItem) - 1);
            var _Int_MontoMovimiento1 = (Convert.ToInt32(_Cmb_MontoMov1.SelectedItem)-1);
            var _Int_MontoSaldo =  (Convert.ToInt32(_Cmb_SaldoMov.SelectedItem)-1);
            var _Dt_Clon = _P_Ds_Original.Tables[0].Copy();

            var _Dc_SaldoInicial = new decimal(0);
            var _Dc_SaldoAnterior = new decimal(0);
            var _Dc_SaldoActual = new decimal(0);
            var _Dc_Diferencia = new decimal(0);

            var _Dc_MontoConSigno = new decimal(0);
            var _Dc_DiferenciaSegunSaldo = new decimal(0);

            var _Bol_EsPrimerRegistro = true;

            _Dg_Detalle.SuspendLayout();
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dg_Detalle.Rows.Clear();
            foreach (DataRow _Row in _Dt_Clon.Rows)
            {
                _Dg_Detalle.SuspendLayout();
                _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                string _Str_Valor;

                //Para NumeroDocumento
                if (_Int_NumeroDocumento > -1)
                {
                    //Tomo el Formato Selecionado
                    _Str_Valor = _Row[_Int_NumeroDocumento].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearNumeroDocumento(_Str_Valor);
                    _Row[_Int_NumeroDocumento] = _Str_Valor;
                }

                //Para FechaMovimiento
                if (_Int_FechaMovimiento > -1)
                {
                    //Tomo el Formato Selecionado
                    var _Str_FormatoFechaMovimiento = _Cmb_FormatoDeFecha.Text;
                    bool _Bool_ConversionCorrecta;
                    _Str_Valor = _Row[_Int_FechaMovimiento].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearFecha(_Str_Valor, _Str_FormatoFechaMovimiento, out _Bool_ConversionCorrecta, DateTime.Now.Date.Month, DateTime.Now.Year);
                    _Row[_Int_FechaMovimiento] = _Str_Valor;
                }
                //Para MontoMovimiento
                if (_Int_MontoMovimiento > -1)
                {
                    _Str_Valor = _Row[_Int_MontoMovimiento].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_Valor, _P_Byte_SeparadorDecimal, _P_Byte_CantidadDigitosDecimal);
                    _Row[_Int_MontoMovimiento] = _Str_Valor;
                }
                //Para MontoMovimiento1
                if (_Int_MontoMovimiento1 > -1)
                {
                    _Str_Valor = _Row[_Int_MontoMovimiento1].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_Valor, _P_Byte_SeparadorDecimal, _P_Byte_CantidadDigitosDecimal);
                    _Row[_Int_MontoMovimiento1] = _Str_Valor;
                }
                //Para MontoSaldo
                if (_Int_MontoSaldo > -1)
                {
                    _Str_Valor = _Row[_Int_MontoSaldo].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_Valor, _P_Byte_SeparadorDecimal, _P_Byte_CantidadDigitosDecimal);
                    _Row[_Int_MontoSaldo] = _Str_Valor;
                }

                //Calculamos el Monto con Signo
                _Dc_MontoConSigno = 0;
                if (_Int_MontoMovimiento > -1)
                {
                    _Str_Valor = _Row[_Int_MontoMovimiento].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_Valor, _P_Byte_SeparadorDecimal, _P_Byte_CantidadDigitosDecimal);
                    var _Dc_Valor = new decimal(0);
                    if (decimal.TryParse(_Str_Valor, out _Dc_Valor))
                        _Dc_MontoConSigno -= _Dc_Valor;
                }
                    
                if (_Int_MontoMovimiento1 > -1)
                {
                    _Str_Valor = _Row[_Int_MontoMovimiento1].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_Valor, _P_Byte_SeparadorDecimal, _P_Byte_CantidadDigitosDecimal);
                    var _Dc_Valor = new decimal(0);
                    if (decimal.TryParse(_Str_Valor, out _Dc_Valor))
                        _Dc_MontoConSigno += _Dc_Valor;
                }

                //Calculamos el Monto segun la columna de saldos
                _Dc_DiferenciaSegunSaldo = 0;
                if (_Int_MontoSaldo > -1)
                {
                    _Str_Valor = _Row[_Int_MontoSaldo].ToString();
                    _Str_Valor = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_Valor, _P_Byte_SeparadorDecimal, _P_Byte_CantidadDigitosDecimal);
                    var _Dc_Valor = new decimal(0);
                    if (decimal.TryParse(_Str_Valor, out _Dc_Valor))
                        _Dc_SaldoActual = _Dc_Valor;
                    _Dc_DiferenciaSegunSaldo = _Dc_SaldoActual - _Dc_SaldoAnterior;
                }

                //Si el monto del registro debe obtener en funcion al saldo
                if (_Chk_ObtenerMontoRegistroSegunColumnaSaldo.Checked)
                {
                    //Solo si no es primer registro
                    if (!_Bol_EsPrimerRegistro)
                    {
                        //Redondeamos
                        _Dc_MontoConSigno = Math.Round(_Dc_MontoConSigno, 2);
                        _Dc_DiferenciaSegunSaldo = Math.Round(_Dc_DiferenciaSegunSaldo, 2);

                        //Calculos
                        _Dc_Diferencia = Math.Round((_Dc_DiferenciaSegunSaldo - _Dc_MontoConSigno),2);

                        //Verificamos
                        if (_Dc_Diferencia != 0)
                        {
                            var _Bol_SignoPositivo = _Dc_Diferencia > 0;
                            var _Str_ = Math.Abs(_Dc_DiferenciaSegunSaldo).ToString("#,##0.00");
                            //Pasamos al grid
                            _Mtd_AsignarMontoAGrid(_Str_, _Bol_SignoPositivo, _Row, _Int_MontoMovimiento, _Int_MontoMovimiento1, _Int_MontoSaldo);
                        }
                    }
                    else
                    {
                        //Luego de pasar el primer registro marcamos
                        _Bol_EsPrimerRegistro = false;
                    }
                }

                //Actualizamos el Saldo Anterior
                _Dc_SaldoAnterior = _Dc_SaldoActual;


                //Pasamos el row al datagrid
                _Dg_Detalle.Rows.Add(_Row.ItemArray);
            }
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.ResumeLayout();
        }

        private void _Mtd_AsignarMontoAGrid(string _P_Str_MontoCorrecto, bool _P_Bool_SignoPositivo, DataRow _P_Row, int _P_Int_MontoMovimiento, int _P_Int_MontoMovimiento1, int _P_Int_MontoSaldo)
        {
            //tiene que haber seleccionado alguno de los combos de monto y el de saldo
            if (((_P_Int_MontoMovimiento > -1) | (_P_Int_MontoMovimiento1 > -1)) & (_P_Int_MontoSaldo > -1))
            {
                if ((_P_Int_MontoMovimiento > -1) & (_P_Int_MontoMovimiento1 > -1)) //Si estan activados los dos combos de monto
                {
                    //En funcion al signo
                    if (_P_Bool_SignoPositivo)
                        _P_Row[_P_Int_MontoMovimiento] = _P_Str_MontoCorrecto;
                    else
                        _P_Row[_P_Int_MontoMovimiento1] = _P_Str_MontoCorrecto;
                }
                else if (_P_Int_MontoMovimiento > -1) //Si esta MontoMovimiento
                {
                    _P_Row[_P_Int_MontoMovimiento] = _P_Str_MontoCorrecto;
                }
                else if (_P_Int_MontoMovimiento1 > -1) //Si esta MontoMovimiento1
                {
                    _P_Row[_P_Int_MontoMovimiento1] = _P_Str_MontoCorrecto;
                }
            }
        }

        private void _Chk_ObtenerMontoRegistroSegunColumnaSaldo_CheckedChanged(object sender, EventArgs e)
        {
            //Verifico que la columna saldo debe estar configurada
            if (!_Mtd_EstaConfiguradaColumnaSaldo() & _Chk_ObtenerMontoRegistroSegunColumnaSaldo.Checked)
            {
                MessageBox.Show("Error en la operación. Debe seleccionar una columna válida para el saldo del documento.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Chk_ObtenerMontoRegistroSegunColumnaSaldo.Checked = false;
            }
            _Mtd_RenombrarColumnas();
            _Mtd_FormatearGridSegunCombos();
            _Mtd_AlinearColumnas();
        }

        private void _Chk_ObtenerTipoOperacionSegunColumnaConcepto_CheckedChanged(object sender, EventArgs e)
        {
            //Verifico que la columna de concepto debe estar configurada
            if (!_Mtd_EstaConfiguradaColumnaConcepto() & _Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked)
            {
                MessageBox.Show("Error en la operación. Debe seleccionar una columna válida para el concepto del documento.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked = false;
            }
            //Si activamos la casilla entonces borramos la columna de tipo de operacion
            if (_Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked)
            {
                _Chk_ObtenerTipoOperacionSegunSignoMonto.Checked = false;
                _Chk_ObtenerTipoOperacionSegunElUsuario.Checked = false;
                _Cmb_TipOper.SelectedIndex = -1;
                _Cmb_TipOper.Enabled = false;
            }
            else
            {
                _Cmb_TipOper.Enabled = true;
            }
            _Mtd_RenombrarColumnas();
            _Mtd_FormatearGridSegunCombos();
            _Mtd_AlinearColumnas();
        }

        private void _Chk_ObtenerTipoOperacionSegunSignoMonto_CheckedChanged(object sender, EventArgs e)
        {
            //Verifico que la columna de monto debe estar configurada
            if (!_Mtd_EstaConfiguradaColumnaMonto() & _Chk_ObtenerTipoOperacionSegunSignoMonto.Checked)
            {
                MessageBox.Show("Error en la operación. Debe seleccionar una columna válida para el Monto del documento.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Chk_ObtenerTipoOperacionSegunSignoMonto.Checked = false;
            }
            //Si activamos la casilla entonces borramos la columna de tipo de operacion
            if (_Chk_ObtenerTipoOperacionSegunSignoMonto.Checked)
            {
                //Quitamos la otra marca
                _Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked = false;
                _Chk_ObtenerTipoOperacionSegunElUsuario.Checked = false;
                _Cmb_TipOper.SelectedIndex = -1;
                _Cmb_TipOper.Enabled = false;
            }
            else
            {
                _Cmb_TipOper.Enabled = true;
            }
            _Mtd_RenombrarColumnas();
            _Mtd_FormatearGridSegunCombos();
            _Mtd_AlinearColumnas();
        }
        private void _Chk_ObtenerTipoOperacionSegunElUsuario_CheckedChanged(object sender, EventArgs e)
        {
            //Si activamos la casilla entonces borramos la columna de tipo de operacion
            if (_Chk_ObtenerTipoOperacionSegunElUsuario.Checked)
            {
                _Chk_ObtenerTipoOperacionSegunColumnaConcepto.Checked = false; 
                _Chk_ObtenerTipoOperacionSegunSignoMonto.Checked = false;
                _Cmb_TipOper.SelectedIndex = -1;
                _Cmb_TipOper.Enabled = false;
                _Txt_ccantidadcaracteresatomarconcepto.Enabled = true & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
                _Txt_ccantidadcaracteresatomarconcepto.ReadOnly = !_Txt_ccantidadcaracteresatomarconcepto.Enabled;
            }
            else
            {
                _Cmb_TipOper.Enabled = true;
                _Txt_ccantidadcaracteresatomarconcepto.Enabled = false;
                _Txt_ccantidadcaracteresatomarconcepto.ReadOnly = true;
            }
            _Mtd_RenombrarColumnas();
            _Mtd_FormatearGridSegunCombos();
            _Mtd_AlinearColumnas();
        }


        private bool _Mtd_EstaConfiguradaColumnaSaldo()
        {
            return _Cmb_SaldoMov.SelectedIndex > -1;
        }
        private bool _Mtd_EstaConfiguradaColumnaConcepto()
        {
            return _Cmb_Concepto.SelectedIndex > -1;
        }
        private bool _Mtd_EstaConfiguradaColumnaMonto()
        {
            return _Cmb_MontoMov.SelectedIndex > -1;
        }

        private void _Txt_ccantidadcaracteresatomarconcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void _Txt_ccantidadcolumnasvaciaspermitidas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void _Txt_ccantidadcolumnasvaciaspermitidas_TextChanged(object sender, EventArgs e)
        {
            byte _cantidad = 0;
            byte.TryParse(_Txt_ccantidadcolumnasvaciaspermitidas.Text, out _cantidad);
            if (_Txt_ccantidadcolumnasvaciaspermitidas.Text.Trim() != "")
            {
                _Mtd_LimpiarGrid();
            }

        }

        private void _Mtd_LimpiarGrid()
        {
            Cursor = Cursors.WaitCursor;
            if (_G_Ds_DataSet != null)
            {
                byte _cantidad = 0;
                byte.TryParse(_Txt_ccantidadcolumnasvaciaspermitidas.Text, out _cantidad);
                var _Ds_NewDataDs = _G_Ds_DataSet.Copy();
                _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, 1, 0, _cantidad);
                _Dg_Detalle.Rows.Clear();
                if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)
                {
                    //throw new Exception();
                }
                _Mtd_IniGridDetalle(_Ds_NewDataDs.Tables[0].Columns.Count);
                _Mtd_CargarGrid(_Ds_NewDataDs);
                _Mtd_RenombrarColumnas();
                _Mtd_FormatearGridSegunCombos();
                _Mtd_AlinearColumnas();
            }
            Cursor = Cursors.Default;
        }
    }
}
