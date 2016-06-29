using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ComprobRetenCxC : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private readonly string _Str_TipoDocFACT, _Str_TipoDocNC, _Str_TipoDocND;
        public Frm_ComprobRetenCxC()
        {
            InitializeComponent();
            var _Dt = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtp_Desde.Value = new DateTime(_Dt.Year, _Dt.Month, 1);
            _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Cls_VariosMetodos._Mtd_Inyeccion_Sql(this, true);
            _Str_TipoDocFACT = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocfact");
            _Str_TipoDocNC = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocnotcred");
            _Str_TipoDocND = _Cls_VariosMetodos._Mtd_TipoDocument_CXC("ctipdocnotdeb");
            _Mtd_CargarTipoDocument();
        }

        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            var _Str_Cadena =
                "Select ccomproret as Retención,convert(varchar,cfechacomprob,103) as fecha,convert(varchar,TCOMPROBANRETCXCM.ccliente)+' - '+ c_nomb_comer as Cliente,dbo.Fnc_Formatear(cmonto) as Monto, cidcomprobret,TCOMPROBANRETCXCM.ccliente, ccaja, cidcomprobretanul, cmotivoanul from TCOMPROBANRETCXCM inner join TCLIENTE on TCOMPROBANRETCXCM.ccliente=TCLIENTE.ccliente " +
                "where convert(datetime,convert(varchar,cfechacomprob,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "' and canulado='" + Convert.ToInt32(_Chk_Anulados.Checked) + "'";
            if (!string.IsNullOrWhiteSpace(_Txt_ComprobConsultatId.Text))
                _Str_Cadena += " and ccomproret like '%" + _Txt_ComprobConsultatId.Text.Trim() + "%'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["cidcomprobret"].Visible = false;
            _Dg_Grid.Columns["ccliente"].Visible = false;
            _Dg_Grid.Columns["ccaja"].Visible = false;
            _Dg_Grid.Columns["cidcomprobretanul"].Visible = false; 
            _Dg_Grid.Columns["cmotivoanul"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private string _Str_IdComprobRet = "";
        private string _Str_Caja = "";
        private void _Mtd_Ini()
        {
            _Str_IdComprobRet = "";
            _Str_Caja = "";
            _Txt_RetencionId.Text = "";
            _Dtp_Retencion.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Txt_Cliente.Tag = "";
            _Txt_Cliente.Text = "";
            _Txt_RetencionIdNueva.Text = "";
            _Txt_Motivo.Text = "";
            _Bt_Anular.Enabled = false;
            _Dg_Comprobante.Rows.Clear();
        }

        private void _MTd_Habilitar(bool _P_Bol_Habilitar)
        {
            _Dtp_Retencion.Enabled = _P_Bol_Habilitar;
            _Txt_RetencionIdNueva.Enabled = _P_Bol_Habilitar;
            _Txt_Motivo.Enabled = _P_Bol_Habilitar;
            _Bt_Agregar.Enabled = _P_Bol_Habilitar;
        }

        private void _Mtd_CargarTipoDocument()
        {
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_TipoDoc, "SELECT ctdocument,cname FROM TDOCUMENT where ctdocument in ('" +
                                                _Str_TipoDocFACT + "','" + _Str_TipoDocNC + "','" + _Str_TipoDocND + "')");
        }

        private bool _Mtd_TieneSaldo(string _P_Str_Cliente, string _P_Str_TipoDocumento, string _P_Str_Documento)
        {
            string _Str_Cadena;
            if (_P_Str_TipoDocumento == _Str_TipoDocFACT || _P_Str_TipoDocumento == _Str_TipoDocND)
            {
                _Str_Cadena = "SELECT csaldofactura FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp +
                              "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" +
                              _P_Str_Cliente + "' AND ctipodocument='" + _P_Str_TipoDocumento + "' AND cnumdocu='" +
                              _P_Str_Documento + "' AND csaldofactura>0";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede ingresar el documento porque no ha sido saldado.", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                _Str_Cadena = "SELECT cdescontada FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp +
                              "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" +
                              _P_Str_Cliente + "' AND cidnotcredicc='" + _P_Str_Documento + "' AND ISNULL(cdescontada,0)=0";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede ingresar el documento porque no ha sido descontado.", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        private bool _Mtd_VerificarDocumento(string _P_Str_Cliente, string _P_Str_TipoDocumento, string _P_Str_Documento, double _P_Dbl_Retenido)
        {
            string _Str_Cadena;
            if (_P_Str_TipoDocumento == _Str_TipoDocFACT)
            {
                _Str_Cadena = "SELECT c_impuesto_bs FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp +
                              "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" +
                              _P_Str_Cliente + "' AND cfactura='" + _P_Str_Documento + "'";
            }
            else if (_P_Str_TipoDocumento == _Str_TipoDocNC)
            {
                _Str_Cadena = "SELECT cimpuesto FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp +
                              "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" +
                              _P_Str_Cliente + "' AND cidnotcredicc='" + _P_Str_Documento + "'";
            }
            else
            {
                _Str_Cadena = "SELECT cimpuesto FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp +
                   "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" +
                   _P_Str_Cliente + "' AND cidnotadebitocc='" + _P_Str_Documento + "'";
            }
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El documento no existe para el cliente seleccionado.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if(_Mtd_DocumentoAgregado(_P_Str_TipoDocumento,_P_Str_Documento))
            {
                MessageBox.Show("El documento ya ha sido agregado.", "Información",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            double _Dbl_Impuesto;
            double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Impuesto);
            if (_Dbl_Impuesto == 0)
            {
                MessageBox.Show("No se le puede aplicar retención a un documento sin impuesto.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (_Mtd_TieneSaldo(_P_Str_Cliente, _P_Str_TipoDocumento, _P_Str_Documento))
            {
                return false;
            }
            if (_P_Dbl_Retenido >= _Dbl_Impuesto)
            {
                MessageBox.Show("El monto de la retención no puede mayor o igual al impuesto del documento (" + _Dbl_Impuesto.ToString("#,##0.00") + ").", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool _Mtd_VerifContenidoNumerico(string _P_Str_Monto)
        {
            double _Dbl_Monto;
            return double.TryParse(_P_Str_Monto, out _Dbl_Monto) && _Dbl_Monto > 0;
        }

        private void _Mtd_ActualizarComprobante(string _P_Str_TipoDocumento, string _P_Str_Documento,
                                                double _P_Dbl_Retenido)
        {
            if (_P_Str_TipoDocumento == _Str_TipoDocNC)
                _P_Dbl_Retenido = _P_Dbl_Retenido*-1;
            if (_Dg_Comprobante.RowCount > 0)
                _Dg_Comprobante.Rows.RemoveAt(_Dg_Comprobante.RowCount - 1);
            var _Str_Cadena =
                "select ccount,cnaturaleza from TPROCESOSCONTD where cidproceso='P_CXC_RET_ANUL_EMI' order by cideprocesod";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                var _Str_Descrip = "IVA DEBITO PAGADO POR ANTICIPADO (RETENIDO). " + _P_Str_TipoDocumento + " # " +
                                   _P_Str_Documento;
                if (_Row["cnaturaleza"].ToString().Trim().ToUpper() == "D")
                {
                    _Dg_Comprobante.Rows.Add(_Row["ccount"], null, _Str_Descrip, _P_Dbl_Retenido.ToString("#,##0.00"),
                                             null,
                                             _P_Str_Documento, _P_Str_TipoDocumento);
                }
                else
                {
                    _Dg_Comprobante.Rows.Add(_Row["ccount"], null, _Str_Descrip, null,
                                             _P_Dbl_Retenido.ToString("#,##0.00"),
                                             _P_Str_Documento, _P_Str_TipoDocumento);
                }
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void _Mtd_TotalizarComprobante()
        {
            if (_Dg_Comprobante.RowCount <= 0) return;
            string _Str_Debe, _Str_Haber;
            _Mtd_TotalDebeHaber(out _Str_Debe, out _Str_Haber);
            _Dg_Comprobante.Rows.Add(null, null, "TOTAL", _Str_Debe, _Str_Haber);
        }

        private void _Mtd_TotalDebeHaber(out string _P_Str_Debe, out string _P_Str_Haber)
        {
            double _Dbl_Total_Debe = 0, _Dbl_Total_Haber = 0;
            _Dg_Comprobante.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["Cuenta"].Value != null).ToList().ForEach(x =>
                {
                    double _Dbl_Debe;
                    double.TryParse(Convert.ToString(x.Cells["Debe"].Value), out _Dbl_Debe);
                    double _Dbl_Haber;
                    double.TryParse(Convert.ToString(x.Cells["Haber"].Value), out _Dbl_Haber);
                    _Dbl_Total_Debe += _Dbl_Debe;
                    _Dbl_Total_Haber += _Dbl_Haber;

                });
            _P_Str_Debe = _Dbl_Total_Debe.ToString("#,##0.00");
            _P_Str_Haber = _Dbl_Total_Haber.ToString("#,##0.00");
        }

        private void _Mtd_TotalDebeHaber(out double _P_Str_Debe, out double _P_Str_Haber)
        {
            double _Dbl_Total_Debe = 0, _Dbl_Total_Haber = 0;
            _Dg_Comprobante.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["Cuenta"].Value != null).ToList().ForEach(x =>
            {
                double _Dbl_Debe;
                double.TryParse(Convert.ToString(x.Cells["Debe"].Value), out _Dbl_Debe);
                double _Dbl_Haber;
                double.TryParse(Convert.ToString(x.Cells["Haber"].Value), out _Dbl_Haber);
                _Dbl_Total_Debe += _Dbl_Debe;
                _Dbl_Total_Haber += _Dbl_Haber;

            });
            _P_Str_Debe = _Dbl_Total_Debe;
            _P_Str_Haber = _Dbl_Total_Haber;
        }

        private bool _Mtd_DocumentoAgregado(string _P_Str_TipoDocumento, string _P_Str_Documento)
        {
            return
                _Dg_Comprobante.Rows.Cast<DataGridViewRow>()
                               .Any(
                                   x =>
                                   (string) x.Cells["TipoDocumento"].Value == _P_Str_TipoDocumento &&
                                   (string) x.Cells["Documento"].Value == _P_Str_Documento);
        }

        private void _Mtd_EliminarDocumento(string _P_Str_TipoDocumento, string _P_Str_Documento)
        {
            _Dg_Comprobante.Rows.RemoveAt(_Dg_Comprobante.RowCount - 1);
            var _ViewRow = _Dg_Comprobante.Rows.Cast<DataGridViewRow>()
                                          .Where(
                                              x =>
                                              (string) x.Cells["TipoDocumento"].Value == _P_Str_TipoDocumento &&
                                              (string) x.Cells["Documento"].Value == _P_Str_Documento);
            _ViewRow.ToList().ForEach(x => _Dg_Comprobante.Rows.Remove(x));
        }

        private string _Mtd_CrearComprobanteContable()
        {
            double _Dbl_Debe, _Dbl_Haber;
            _Mtd_TotalDebeHaber(out _Dbl_Debe, out _Dbl_Haber);
            var _Cls_Proceso_Cont = new Clases._Cls_ProcesosCont("P_CXC_RET_ANUL_EMI");
            var _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            var _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            var _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            var _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','1','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            _Dg_Comprobante.Rows.Cast<DataGridViewRow>()
                           .Where(x => x.Cells["Cuenta"].Value != null)
                           .ToList()
                           .ForEach(x =>
                               {
                                   var _Str_Cuenta = Convert.ToString(x.Cells["Cuenta"].Value).Trim();
                                   var _Str_Descrip = Convert.ToString(x.Cells["Descripcion"].Value).Trim();
                                   var _Str_TipoDocumento = Convert.ToString(x.Cells["TipoDocumento"].Value).Trim();
                                   var _Str_Documento = Convert.ToString(x.Cells["Documento"].Value).Trim();
                                   double _Dbl_DebeD, _Dbl_HaberD;
                                   double.TryParse(Convert.ToString(x.Cells["Debe"].Value), out _Dbl_DebeD);
                                   double.TryParse(Convert.ToString(x.Cells["Haber"].Value), out _Dbl_HaberD);
                                   _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + (x.Index + 1) + "','" + _Str_Cuenta + "','" + _Str_Descrip + "','" + _Str_TipoDocumento + "','" + _Str_Documento + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DebeD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_HaberD) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                   if (_Dbl_DebeD != 0)
                                   {
                                       CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, Convert.ToString(_Txt_Cliente.Tag).Trim(), _Str_Descrip, _Str_TipoDocumento, _Str_Documento, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DebeD), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "D");
                                   }
                                   else
                                   {
                                       CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), _Str_Cuenta, Convert.ToString(_Txt_Cliente.Tag).Trim(), _Str_Descrip, _Str_TipoDocumento, _Str_Documento, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_HaberD), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "H");
                                   }
                               });
            return _Int_Comprobante.ToString();
        }

        private void _Mtd_Guardar()
        {
            Cursor = Cursors.WaitCursor;
            double _Dbl_Debe, _Dbl_Haber;
            _Mtd_TotalDebeHaber(out _Dbl_Debe, out _Dbl_Haber);
            var _Str_Cadena =
                "INSERT INTO TCOMPROBANRETCXCM (ccompany,ccomproret,cfechacomprob,ccliente,cidcomprob,cmonto,canulado,ccaja) VALUES (@ccompany,@ccomproret,@cfechacomprob,@ccliente,@cidcomprob,@cmonto,@canulado,@ccaja) SELECT SCOPE_IDENTITY()";
            var _Sql_CnxConexion = new SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Sql_ComInsert = new SqlCommand(_Str_Cadena, _Sql_CnxConexion);
            _Sql_ComInsert.Parameters.AddWithValue("@ccompany", Frm_Padre._Str_Comp);
            _Sql_ComInsert.Parameters.AddWithValue("@ccomproret", _Txt_RetencionIdNueva.Text);
            _Sql_ComInsert.Parameters.AddWithValue("@cfechacomprob", _Cls_Formato._Mtd_fecha(_Dtp_Retencion.Value));
            _Sql_ComInsert.Parameters.AddWithValue("@ccliente", Convert.ToString(_Txt_Cliente.Tag));
            _Sql_ComInsert.Parameters.AddWithValue("@cidcomprob","0");
            _Sql_ComInsert.Parameters.AddWithValue("@cmonto", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe));
            _Sql_ComInsert.Parameters.AddWithValue("@canulado", "0");
            _Sql_ComInsert.Parameters.AddWithValue("@ccaja", _Str_Caja);
            _Sql_ComInsert.Connection = _Sql_CnxConexion;
            _Sql_CnxConexion.Open();
            var _Str_Id = _Sql_ComInsert.ExecuteScalar().ToString();
            _Sql_CnxConexion.Close();
            _Dg_Comprobante.Rows.Cast<DataGridViewRow>()
                 .Where(x => x.Cells["Cuenta"].Value != null)
                 .ToList().Select(x => 
                     new
                         {
                             TipoDoumento = x.Cells["TipoDocumento"].Value,
                             Doumento = x.Cells["Documento"].Value,
                             Monto = x.Cells["Debe"].Value ?? x.Cells["Haber"].Value
                         }).Distinct().ToList()
                 .ForEach(x =>
                 {
                     _Str_Cadena =
                         "INSERT INTO TCOMPROBANRETCXCD (cidcomprobret,ccompany,cnumdocu,ctipodocument,cmonto) VALUES ('" +
                         _Str_Id + "','" + Frm_Padre._Str_Comp + "','" + Convert.ToString(x.Doumento).Trim() + "','" + Convert.ToString(x.TipoDoumento).Trim() +
                         "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(x.Monto)) + "')";
                     Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                 });
            var _Str_Comprobante = _Mtd_CrearComprobanteContable();
            _Str_Cadena = "UPDATE TCOMPROBANRETCXCM SET cidcomprob='" + _Str_Comprobante + "' WHERE cidcomprobret='" + _Str_Id + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TCOMPROBANRETCXCM SET canulado='1',cmotivoanul='" + _Txt_Motivo.Text.ToUpper().Trim() + "',cidcomprobretanul='" + _Str_Id + "' WHERE cidcomprobret='" + _Str_IdComprobRet + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            Cursor = Cursors.Default;
            MessageBox.Show("La operación ha sido realizada correctamente.\nSe va a proceder a imprimir el comprobante: " + _Mtd_RetornarID_Correl(_Str_Comprobante), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_ImprimirComprobante(_Str_Comprobante);
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_Actualizar();
        }

        private string _Mtd_RetornarID_Correl(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcorrel FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }

        private void _Mtd_ImprimirComprobante(string _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El comprobante ha sido actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _PrintComprob;
                    }
                }
                else
                {
                    MessageBox.Show("Debe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.\nDebe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private string _Mtd_ObtenerRetencion(string _P_Str_RetencionId)
        {
            var _Str_Cadena = "Select ccomproret from TCOMPROBANRETCXCM where cidcomprobret='" + _P_Str_RetencionId + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }

        private string _Mtd_ObtenerComprobante(string _P_Str_RetencionId)
        {
            var _Str_Cadena = "Select cidcomprob from TCOMPROBANRETCXCM where cidcomprobret='" + _P_Str_RetencionId + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }

        private void _Mtd_CargarComprobante(string _P_Str_RetencionId)
        {
            var _Str_Comprobante = _Mtd_ObtenerComprobante(_P_Str_RetencionId);
            var _Str_Cadena = "Select ccount,cdescrip,ctdocument,cnumdocu,ctotdebe,ctothaber from TCOMPROBAND where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprobante + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                double _Dbl_DebeD, _Dbl_HaberD;
                double.TryParse(Convert.ToString(_Row["ctotdebe"]), out _Dbl_DebeD);
                double.TryParse(Convert.ToString(_Row["ctothaber"]), out _Dbl_HaberD);
                _Dg_Comprobante.Rows.Add(_Row["ccount"], null, _Row["cdescrip"],
                                         _Dbl_DebeD != 0 ? _Dbl_DebeD.ToString("#,##0.00") : null,
                                         _Dbl_HaberD != 0 ? _Dbl_HaberD.ToString("#,##0.00") : null,
                                         _Row["cnumdocu"], _Row["ctdocument"]);
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Dg_Comprobante_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfoComp.Visible = _Bt_Agregar.Enabled;
        }

        private void _Dg_Comprobante_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfoComp.Visible = false;
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Text = _Chk_Anulados.Checked ? "Use: Doble click para ver" : "Use: Click derecho para anular";
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }

        private void Frm_ComprobRetenCxC_Load(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
            _Pnl_Documento.Left = (Width / 2) - (_Pnl_Documento.Width / 2);
            _Pnl_Documento.Top = (Height / 2) - (_Pnl_Documento.Height / 2);
            _Pnl_Clave.Left = (Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Sorted(_Dg_Comprobante);
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void Frm_ComprobRetenCxC_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ComprobRetenCxC_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            { e.Cancel = !_Bt_Agregar.Enabled; }
            else
            {
                _Mtd_Ini();
                _MTd_Habilitar(false);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Cmb_TipoDoc.SelectedIndex = 0;
            _Txt_Documento.Text = "";
            _Txt_MontoRetenido.Text = "";
            _Pnl_Documento.Visible = true;
        }

        private void _Txt_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Documento, e, 8, 0);
        }

        private void _Txt_Documento_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Documento.Text)) { _Txt_Documento.Text = ""; }
        }

        private void _Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_MontoRetenido, e, 15, 2);
        }

        private void _Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_MontoRetenido.Text)) { _Txt_MontoRetenido.Text = ""; }
        }

        private void _Pnl_Documento_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Documento.Visible)
            { _Tb_Tab.Enabled = false; _Cmb_TipoDoc.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Documento.Visible = false;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Cmb_TipoDoc.SelectedIndex > 0 && _Mtd_VerifContenidoNumerico(_Txt_Documento.Text) &&
                _Mtd_VerifContenidoNumerico(_Txt_MontoRetenido.Text))
            {
                if (_Mtd_VerificarDocumento(Convert.ToString(_Txt_Cliente.Tag).Trim(),
                                            Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim(), _Txt_Documento.Text,
                                            double.Parse(_Txt_MontoRetenido.Text)))
                {
                    _Mtd_ActualizarComprobante(Convert.ToString(_Cmb_TipoDoc.SelectedValue).Trim(), _Txt_Documento.Text,
                                               double.Parse(_Txt_MontoRetenido.Text));
                    _Mtd_TotalizarComprobante();
                    _Pnl_Documento.Visible = false;
                    _Bt_Anular.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Todos los datos son obligatorios.", "Información", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Chk_Anulados.Checked || _Dg_Grid.SelectedRows.Count != 1;
        }

        private void _Chk_Anulados_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Tol_Anular_Click(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _MTd_Habilitar(true);
            _Tb_Tab.SelectedIndex = 1;
            _Dtp_Retencion.Value =
                Convert.ToDateTime(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Fecha"].Value);
            _Lbl_Retencion.Text = "Retención #:(a anular)";
            _Txt_RetencionId.Text =
                Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Retención"].Value);
            _Txt_RetencionIdNueva.Text = _Txt_RetencionId.Text;
            _Txt_Cliente.Tag = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value);
            _Txt_Cliente.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cliente"].Value);
            _Str_IdComprobRet = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidcomprobret"].Value);
            _Str_Caja = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccaja"].Value);
            _Txt_Motivo.Focus();
        }

        private void _Cntx_Comprobante_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !_Bt_Agregar.Enabled || _Dg_Comprobante.SelectedRows.Count != 1 ||
                       _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells["Cuenta"].Value == null;
        }

        private void _Tol_Comp_Eliminar_Click(object sender, EventArgs e)
        {
            _Mtd_EliminarDocumento(
                Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells["TipoDocumento"].Value),
                Convert.ToString(_Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Cells["Documento"].Value));
            _Mtd_TotalizarComprobante();
            _Bt_Anular.Enabled = _Dg_Comprobante.RowCount > 0;
        }

        private void _Bt_Anular_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (string.IsNullOrWhiteSpace(_Txt_Motivo.Text) || string.IsNullOrWhiteSpace(_Txt_RetencionIdNueva.Text))
            {
                if (string.IsNullOrWhiteSpace(_Txt_Motivo.Text))
                    _Er_Error.SetError(_Txt_Motivo, "Información requerida!");
                if (string.IsNullOrWhiteSpace(_Txt_RetencionIdNueva.Text))
                    _Er_Error.SetError(_Txt_RetencionIdNueva, "Información requerida!");
            }
            else
            {
                double _Dbl_Debe, _Dbl_Haber;
                _Mtd_TotalDebeHaber(out _Dbl_Debe, out _Dbl_Haber);
                if (_Dbl_Debe != _Dbl_Haber)
                {
                    MessageBox.Show("El comprobante esta descuadrado. Por favor verifique!", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(
                    "Se reemplazaran los datos de la retención elegida por los nuevos datos ingresados.\n" +
                    "¿Esta seguro de continuar con la operación?", "Advertencia", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Pnl_Clave.Visible = true;
                }
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Bt_Agregar.Enabled = false;
                _Bt_Anular.Enabled = false;
                _Pnl_Clave.Visible = false;
                _Mtd_Guardar();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!_Chk_Anulados.Checked)
                return;
            _Dtp_Retencion.Value =
                Convert.ToDateTime(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Fecha"].Value);
            _Lbl_Retencion.Text = "Retención #:(anulada)";
            _Txt_RetencionId.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Retención"].Value);
            _Txt_RetencionIdNueva.Text = _Mtd_ObtenerRetencion(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidcomprobretanul"].Value));
            _Txt_Cliente.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cliente"].Value);
            _Txt_Motivo.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cmotivoanul"].Value);
            _Mtd_CargarComprobante(
                Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidcomprobretanul"].Value));
            _Mtd_TotalizarComprobante();
            _Tb_Tab.Selecting -= (_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += (_Tb_Tab_Selecting);
        }
    }
}
