using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ComprobAjusInv : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_ValorCeldaTem = "XXXX";
        public Frm_ComprobAjusInv()
        {
            InitializeComponent();
        }
        int _Int_Sw = 0;
        public Frm_ComprobAjusInv(int _P_Int_Sw)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            this.Text = _P_Int_Sw == 1 ? "COMPROBANTES DE AJUSTES DE ENTRADA INCOMPLETOS" : "COMPROBANTES DE AJUSTES DE SALIDA INCOMPLETOS";
        }

        private void Frm_ComprobAjusInv_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Actualizar();
            _Pnl_Clave.Left = (Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Sorted(_Dg_Comprobante);
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                _Txt_Ajuste.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Ajuste"].Value);
                _Dtp_Fecha.Value = Convert.ToDateTime(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Fecha"].Value);
                _Txt_Descripcion.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Descripción"].Value);
                _Txt_Monto.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Monto"].Value);
                _Mtd_CargarComprobante(_Txt_Monto.Text);
                _Tb_Tab.SelectedIndex = 1;
                if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_COMPROBC") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                }
                Cursor = Cursors.Default;
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
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Mtd_GuardarComprobante();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private string _Mtd_CrearComprobanteContable()
        {
            var _Str_TipoDocAjus = _Cls_VariosMetodos._Mtd_TipoDocument_INV(_Int_Sw == 1 ? "ctipodocent" : "ctipodocsal").Trim();
            double _Dbl_Monto = 0;
            double.TryParse(_Txt_Monto.Text, out _Dbl_Monto);
            var _Cls_Proceso_Cont = new Clases._Cls_ProcesosCont(_Int_Sw == 1 ? "P_INV_AJUS_ENT" : "P_INV_AJUS_SAL");
            var _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            var _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            var _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            var _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','1','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Dg_Comprobante.Rows.Cast<DataGridViewRow>()
                           .Where(x => x.Cells["Cuenta"].Value != null)
                           .ToList()
                           .ForEach(x =>
                           {
                               var _Str_Cuenta = Convert.ToString(x.Cells["Cuenta"].Value).Trim();
                               var _Str_Descrip = Convert.ToString(x.Cells["Descripcion"].Value).Trim();
                               var _Str_TipoDocumento = _Str_TipoDocAjus;
                               var _Str_Documento = _Txt_Ajuste.Text;
                               double _Dbl_DebeD, _Dbl_HaberD;
                               double.TryParse(Convert.ToString(x.Cells["Debe"].Value), out _Dbl_DebeD);
                               double.TryParse(Convert.ToString(x.Cells["Haber"].Value), out _Dbl_HaberD);
                               _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + (x.Index + 1) + "','" + _Str_Cuenta + "','" + _Str_Descrip + "','" + _Str_TipoDocumento + "','" + _Str_Documento + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DebeD) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_HaberD) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                           });
            return _Int_Comprobante.ToString();
        }

        private void _Mtd_GuardarComprobante()
        {
            Cursor = Cursors.WaitCursor;
            var _Str_Comprobante = _Mtd_CrearComprobanteContable();
            var _Str_Cadena = _Int_Sw == 1 ? "UPDATE TAJUSENTC SET cidcomprob='" + _Str_Comprobante + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_Ajuste.Text + "'" :
                "UPDATE TAJUSSALC SET cidcomprob='" + _Str_Comprobante + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustsal='" + _Txt_Ajuste.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            Cursor = Cursors.Default;
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            MessageBox.Show("La operación ha sido realizada correctamente.\nSe va a proceder a imprimir el comprobante: " + _Mtd_RetornarID_Correl(_Str_Comprobante), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_ImprimirComprobante(_Str_Comprobante);
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_Actualizar();
            if (_Dg_Grid.RowCount == 0)
                this.Close();
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

        private void _Mtd_Inicializar()
        {
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            _Txt_Ajuste.Text = "";
            _Dtp_Fecha.Value = DateTime.Now;
            _Txt_Descripcion.Text = "";
            _Txt_Monto.Text = "";
            _Dg_Comprobante.Rows.Clear();
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
            var _Str_Cadena = "";
            _Str_Cadena = _Int_Sw == 1 ? "Select cajustent as Ajuste, CONVERT(varchar, cdateajus, 3) AS Fecha,cname as Descripción, dbo.Fnc_Formatear(ccosttotsimp) as Monto, dbo.Fnc_Formatear(cvalorimp) as Impuesto from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='0' AND cimpreso='1'" :
                "Select cajustsal as Ajuste, CONVERT(varchar, cdateajus, 3) AS Fecha,cname as Descripción, dbo.Fnc_Formatear(ccosttotsimp) as Monto, dbo.Fnc_Formatear(cvalorimp) as Impuesto from TAJUSSALC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='0' AND cimpreso='1'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Mtd_HabilitarCeldaXXXX(bool _P_Bol_Habilitar)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() == "XXXX")
                { _Dg_Row.Cells[0].ReadOnly = !_P_Bol_Habilitar; }
                else
                { _Dg_Row.Cells[0].ReadOnly = true; }
            }
        }

        private string _Mtd_ObtenerDescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }

        private bool _Mtd_CuentasValidas()
        {
            var _Str_Cadena = "";
            var _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and cactivate='1' and ccount='" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                        return false;
                }
            }
            return true;
        }

        private bool _Mtd_DescripcionesCompletas()
        {
            var _Str_Cadena = "";
            var _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (Convert.ToString(_Dg_Row.Cells[2].Value).Trim().Length == 0)
                        return false;
                }
            }
            return true;
        }

        private bool _Mtd_DescripcionesDesbordadas()
        {
            var _Str_Cadena = "";
            var _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (Convert.ToString(_Dg_Row.Cells[2].Value).Trim().Length > 255)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si la cuenta ya ha sido ingresada.
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Int_RowIndex">Índice de la fila</param>
        /// <returns></returns>
        private bool _Mtd_ValidarCuenta(string _P_Str_Cuenta, int _P_Int_RowIndex)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Cuenta & _Dg_Row.Index != _P_Int_RowIndex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns></returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }
        private void _Mtd_CargarComprobante(string _P_Str_Monto)
        {
            string _Str_CountCont = "", _Str_CountContName = "";
            var _Str_ProcesoCont = _Int_Sw == 1 ? "P_INV_AJUS_ENT" : "P_INV_AJUS_SAL";
            string _Str_Cadena = "SELECT ccount,cnaturaleza,ccountname FROM VST_PROCESOSCONTD WHERE cidproceso='" + _Str_ProcesoCont + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                if (_Drow["ccount"].ToString() == "PRV.X")
                {
                    _Str_CountCont = "XXXX";
                    _Str_CountContName = Convert.ToString(_Drow["cnaturaleza"]).Trim() == "D" ? "CUENTA DEUDORA" : "CUENTA ACREEDORA";
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Drow["ccount"]).Trim();
                    _Str_CountContName = Convert.ToString(_Drow["ccountname"]).Trim().ToUpper();
                }
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = _Str_CountCont;
                _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = _Str_CountContName;
                if (_Drow["cnaturaleza"].ToString() == "D")
                {
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _P_Str_Monto;
                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                }
                else
                {
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "";
                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _P_Str_Monto;
                }
                _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].ReadOnly = false;
            }
            if (_Dg_Comprobante.RowCount > 0)
            {
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _P_Str_Monto, _P_Str_Monto });
                _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].ReadOnly = true;
            }
            _Mtd_HabilitarCeldaXXXX(true);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public bool _Mtd_Guardar()
        {
            _Dg_Comprobante.EndEdit();
            if (!_Mtd_CuentasValidas())
            {
                MessageBox.Show("Debe elegir una cuenta válida.", "Reuquerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!_Mtd_DescripcionesCompletas())
            {
                MessageBox.Show("Debe ingresar la descripción para cada registro.", "Reuquerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (_Mtd_DescripcionesDesbordadas())
            {
                MessageBox.Show("Algunos registros tienen descripciones que superan el máximo permitido (255 caracteres).", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            _Pnl_Clave.Visible = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            return false;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_Inicializar();
            }
            else
            {
                e.Cancel = _Txt_Ajuste.Text.Trim().Length == 0;
            }
        }

        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1 & !_Dg_Comprobante.Rows[e.RowIndex].Cells[0].ReadOnly)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_VstCuentas _Frm = new Frm_VstCuentas();
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
                    {
                        if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                        {
                            _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Frm._Str_FrmNodeSelec.Trim(); _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim()); _Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                            //CODIGO COMENTADO SEGUN TICKET 12930 - IGNACIO AL 12-02-2014
                            //if (!_Mtd_ValidarCuenta(_Frm._Str_FrmNodeSelec.Trim(), e.RowIndex))
                            //{
                            //    _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Frm._Str_FrmNodeSelec.Trim(); _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim()); _Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                            //}
                            //else
                            //{
                            //    MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX";
                            //}
                            //CODIGO COMENTADO SEGUN TICKET 12930 - IGNACIO AL 12-02-2014
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX"; }
                    }
                    _Frm.Dispose();
                }
            }
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem;
                    }
                    else
                    {
                        if (_Mtd_CuentaDetalle(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()))
                        {
                            _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

                            //CODIGO COMENTADO SEGUN TICKET 12930 - IGNACIO AL 12-02-2014
                            //if (!_Mtd_ValidarCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), e.RowIndex))
                            //{
                            //    _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                            //}
                            //else
                            //{
                            //    MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem;
                            //    _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX";
                            //}
                            //CODIGO COMENTADO SEGUN TICKET 12930 - IGNACIO AL 12-02-2014
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = "XXXX"; }
                    }
                }
                else
                { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Str_ValorCeldaTem; }
            }
        }

        private void _Dg_Comprobante_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    _Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }

        private void Frm_ComprobAjusInv_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_COMPROBC") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_COMPROBC"))
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                if (_Tb_Tab.SelectedIndex == 1 && !_Pnl_Clave.Visible)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                }
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_ComprobAjusInv_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}
