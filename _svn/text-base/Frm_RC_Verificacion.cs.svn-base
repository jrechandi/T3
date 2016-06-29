using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_RC_Verificacion : Form
    {
        public Frm_RC_Verificacion()
        {
            InitializeComponent();
        }

        private void Frm_RC_Verificacion_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            _Btn_Actualizar.Enabled = false;
            _Mtd_Actualizar_Descargadas();
            _Mtd_Actualizar_Ingresadas();
            _Btn_Actualizar.Enabled = true;
        }

        private void _Mtd_VerificarSiHayQueCerrarFormulario()
        {
            var _Int_Cantidad_Descargadas = _Dg_Grid_Descargadas.Rows.Count;
            var _Int_Cantidad_Ingresadas = _Dg_Grid_Ingresadas.Rows.Count;
            if ((_Int_Cantidad_Descargadas + _Int_Cantidad_Ingresadas) == 0)
            {
                _Mtd_ActualizaNotificadores();
                Close();
            }
        }

        private void _Mtd_Actualizar_Descargadas()
        {
            Cursor = Cursors.WaitCursor;
            var _Str_Cadena = "SELECT T3TRELACCOBM.cfecharela AS Fecha ,(T3TVENDEDOR.cvendedor + ' ' + T3TVENDEDOR.cname) AS [Vendedor] ,cobservaciones AS [Observaciones] ,cidrelacobro AS [Nº Pre-Relación],T3TRELACCOBM.ccompany FROM T3TRELACCOBM INNER JOIN T3TVENDEDOR ON T3TRELACCOBM.ccompany = T3TVENDEDOR.ccompany AND T3TRELACCOBM.cvendedor = T3TVENDEDOR.cvendedor WHERE (T3TRELACCOBM.caprobado = '1') AND (T3TRELACCOBM.caprobadocredito = '0') AND (T3TRELACCOBM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (T3TRELACCOBM.cdelete = '0')";
            var _Ds = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid_Descargadas.Columns.Clear();
            _Dg_Grid_Descargadas.DataSource = _Ds.Tables[0];
            _Dg_Grid_Descargadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid_Descargadas.Columns[4].Visible = false;

            //Cargamos la Columna de Boton
            var _Btn_BotonVerificar = new DataGridViewButtonColumn();
            _Btn_BotonVerificar.HeaderText = "";
            _Btn_BotonVerificar.Name = "_Btn_Verificar_Descargadas";
            _Btn_BotonVerificar.DefaultCellStyle.Font = new Font("Verdana", 7);
            _Btn_BotonVerificar.Text = "Verificar";
            _Btn_BotonVerificar.UseColumnTextForButtonValue = true;
            _Btn_BotonVerificar.Width = 450;
            _Dg_Grid_Descargadas.Columns.Add(_Btn_BotonVerificar);
            
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar_Ingresadas()
        {
            Cursor = Cursors.WaitCursor;
            _Dg_Grid_Ingresadas.SuspendLayout();

            var _Str_Cadena = "SELECT TGUIADESPACHOM.cguiadesp AS [Nº Guía] ,(TTRANSPORTE.cplaca + ' - ' + TTRANSPORTE.cmarca + ' - ' + TTRANSPORTE.ccolor) AS [Transporte] ,TGUIADESPACHOM.cfliqguidespacho AS Liquidada, dbo.formatear(TGUIADESPACHOM.cpagodeldespacho) AS [Monto Cobrado] FROM TGUIADESPACHOM INNER JOIN TPRECARGAM ON TGUIADESPACHOM.cgroupcomp = TPRECARGAM.cgroupcomp AND TGUIADESPACHOM.cprecarga = TPRECARGAM.cprecarga INNER JOIN TGUIADESPACHOD ON TGUIADESPACHOM.cgroupcomp = TGUIADESPACHOD.cgroupcomp AND TGUIADESPACHOM.cguiadesp = TGUIADESPACHOD.cguiadesp AND TGUIADESPACHOM.cprecarga = TGUIADESPACHOD.cprecarga INNER JOIN TRELACCOBM ON TGUIADESPACHOM.cgroupcomp = TRELACCOBM.cgroupcomp AND TGUIADESPACHOM.cguiadesp = TRELACCOBM.cguiacobro INNER JOIN TTRANSPORTE ON TGUIADESPACHOM.cplaca = TTRANSPORTE.cplaca WHERE (TGUIADESPACHOM.cguiacobrada = '1') AND (TGUIADESPACHOM.cliqguidespacho = '1') AND (TGUIADESPACHOM.cfinalizado = '1') AND (TGUIADESPACHOD.c_estatus = 'PAG') AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0) AND (TGUIADESPACHOD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGAM.cimprimeguiadesp = 1) AND (TPRECARGAM.cimprimefactura = 1) AND (TRELACCOBM.ccobrooficina = 1) AND (TRELACCOBM.caprobado = 1) AND (TRELACCOBM.caprobadocredito = 0) AND (TRELACCOBM.cdelete = '0') GROUP BY TGUIADESPACHOM.cguiadesp ,TTRANSPORTE.cplaca + ' - ' + TTRANSPORTE.cmarca + ' - ' + TTRANSPORTE.ccolor ,TGUIADESPACHOM.cfliqguidespacho ,TGUIADESPACHOM.cpagodeldespacho ";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid_Ingresadas.Columns.Clear();
            _Dg_Grid_Ingresadas.DataSource = _Ds.Tables[0];
            _Dg_Grid_Ingresadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid_Ingresadas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Cargamos la Columna de Boton
            var _Btn_BotonVerificar = new DataGridViewButtonColumn();
            _Btn_BotonVerificar.HeaderText = "";
            _Btn_BotonVerificar.Name = "_Btn_Verificar_Ingresadas";
            _Btn_BotonVerificar.DefaultCellStyle.Font = new Font("Verdana", 7);
            _Btn_BotonVerificar.Text = "Verificar";
            _Btn_BotonVerificar.UseColumnTextForButtonValue = true;
            _Btn_BotonVerificar.Width = 450;
            _Dg_Grid_Ingresadas.Columns.Add(_Btn_BotonVerificar);

            //Consutamos los Montos Cobrados
            _Dg_Grid_Ingresadas.Rows.Cast<DataGridViewRow>().ToList().ForEach(row =>
            {
                var _Str_cguiadesp = row.Cells["Nº Guía"].Value.ToString();
                var _Dbl_Monto = 0.0;
                _Str_Cadena = "SELECT SUM((cmontocancelado+cmontoretencion+cmontodescuentos+cmontonotascredito)) As [Monto] FROM VST_RC_COBROSCONTRACAMION_MONTOCOBRADO WHERE cguiacobro='" + _Str_cguiadesp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                    Double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Monto);
                var _Str_Monto = _Dbl_Monto.ToString("c");
                row.Cells["Monto Cobrado"].Value = _Str_Monto;
            });

            _Dg_Grid_Ingresadas.ResumeLayout();
            Cursor = Cursors.Default;
        }

        private void _Dg_Grid_Descargadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0)) return;
            if (_Dg_Grid_Descargadas.Columns[e.ColumnIndex].Name == "_Btn_Verificar_Descargadas")
            {
                //Obtenemos los datos
                var _Int_cidrelacobro = Convert.ToInt32(_Dg_Grid_Descargadas.Rows[e.RowIndex].Cells["Nº Pre-Relación"].Value);
                var _Str_ccompany = _Dg_Grid_Descargadas.Rows[e.RowIndex].Cells["ccompany"].Value.ToString();

                //Verificamos si la caja esta cerrando
                var _Bol_CierreCajaActivado = _Mtd_SeEstaCerrandoCaja(_Str_ccompany);

                //Tomamos el valor
                if (_Bol_CierreCajaActivado)
                {
                    MessageBox.Show("Se esta cerrando caja en otro equipo.\nNo es posible aprobar relaciones en estos momentos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Verificamos si la relacion esta correcta (fue descargada completa)
                if (_Mtd_RelacionDescargadaCorrectamente(Frm_Padre._Str_GroupComp, _Str_ccompany, _Int_cidrelacobro))
                {
                    //Verificamos si la relación ya fue aprobada
                    if (_Mtd_RelacionYaFueAprobada(Frm_Padre._Str_GroupComp, _Str_ccompany, _Int_cidrelacobro))
                    {
                        MessageBox.Show("La relación de cobranza ya fué aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string _Str_Url = CLASES._Cls_Conexion._G_Str_Url_RelacionesCobranzaLocal + "?IdRelacion=" + _Int_cidrelacobro + "&compania=" + _Str_ccompany + "&usuario=" + Frm_Padre._Str_Use.Trim();
                        var _Frm = new Frm_Navegador(_Str_Url, true, true) { Dock = DockStyle.Fill, Width = Width, Height = (Height + 50) };
                        _Frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("La relación de cobranza se está descargando por favor intenten nuevamente en unos minutos..", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _Mtd_Actualizar_Descargadas();
                _Mtd_VerificarSiHayQueCerrarFormulario();
                _Mtd_ActualizaNotificadores();
            }
        }

        private bool _Mtd_SeEstaCerrandoCaja(string  _P_Str_ccompany)
        {
            try
            {
                //Por defecto nadie esta cerrando caja
                var _Bol_CierreCajaActivado = false;
                //Verificamos si se esta cerrando la caja para la compañia actual
                var _Str_Cadena = "SELECT ccerrando FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _P_Str_ccompany + "' AND ccerrada='0' AND ccerrando='1'";
                var _Ds_CierreCaja = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_CierreCaja.Tables[0].Rows.Count > 0)
                {
                    _Bol_CierreCajaActivado = true;
                }
                return _Bol_CierreCajaActivado;
            }
            catch
            {
                return false;
            }
        }

        private bool _Mtd_RelacionYaFueAprobada(string _P_Str_Cgroupcomp, string _P_Str_Ccompany, int _P_Int_Cidrelacobroweb)
        {
            var _Str_Cadena = "select cidrelacobro from trelaccobm where cgroupcomp='" + _P_Str_Cgroupcomp + "' and ccompany='" + _P_Str_Ccompany + "' and cidrelacobroweb='" + _P_Int_Cidrelacobroweb + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Dg_Grid_Ingresadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))  return;
            if (_Dg_Grid_Ingresadas.Columns[e.ColumnIndex].Name == "_Btn_Verificar_Ingresadas")
            {
                var _Str_cguiadesp = Convert.ToInt32(_Dg_Grid_Ingresadas.Rows[e.RowIndex].Cells["Nº Guía"].Value);
                Cursor = Cursors.WaitCursor;
                var _Frm = new Frm_RC_Resumen(_Str_cguiadesp);
                Cursor = Cursors.Default;
                //Cuadramos los tamaños
                _Frm.Left = Left;
                _Frm.Width = Width;
                _Frm.Top = Top;
                _Frm.Height = Height;
                //Mostramos el formulario
                _Frm.ShowDialog(this);
                //Actualizamos el grid
                _Mtd_Actualizar_Ingresadas();
                _Mtd_VerificarSiHayQueCerrarFormulario();
                _Mtd_ActualizaNotificadores();
            }
        }

        private void _Mtd_ActualizaNotificadores()
        {
            if ((Frm_Padre) this.MdiParent != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre) this.MdiParent)._Frm_Contenedor._async_Default);
            }
        }

        private bool _Mtd_RelacionDescargadaCorrectamente(string _P_Str_Cgroupcomp, string _P_Str_Ccompany, int _P_Int_Cidrelacobro)
        {
            int  _Int_CuentaDeRegistros = 0;
            int _Int_TotalDeRegistros = 0;

            //Obtenemos el total de registros a verificar
            var _Str_Cadena = "SELECT ccantdetalles FROM T3TRELACCOBM WHERE cgroupcomp='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_TotalDeRegistros = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
            }

            //Contamos
            _Str_Cadena = " SELECT COUNT(cidrelacobro) FROM ( ";
            _Str_Cadena += " SELECT cidrelacobro FROM T3TRELACCOBDCHEQ WHERE cgroupcomp='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "' ";
            _Str_Cadena += " UNION ALL ";
            _Str_Cadena += " SELECT cidrelacobro FROM T3TRELACCOBDDEPD WHERE cgroupcomp='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "' ";
            _Str_Cadena += " UNION ALL ";
            _Str_Cadena += " SELECT cidrelacobro FROM T3TRELACCOBDD WHERE cgroupcomp='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "' ";
            _Str_Cadena += " UNION ALL ";
            _Str_Cadena += " SELECT cidrelacobro FROM T3TRELACCOBDDEPM WHERE cgroupcomp='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "' ";
            _Str_Cadena += " UNION ALL ";
            _Str_Cadena += " SELECT cidrelacobro FROM T3TRELACCOBD WHERE cgroupcompany='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "' ";
            _Str_Cadena += " UNION ALL ";
            _Str_Cadena += " SELECT cidrelacobro FROM T3TRELACCOBM WHERE cgroupcomp='" + _P_Str_Cgroupcomp + "' AND ccompany='" + _P_Str_Ccompany + "' AND cidrelacobro='" + _P_Int_Cidrelacobro + "' ";
            _Str_Cadena += " ) AS CONSULTOTA";
            _Ds = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_CuentaDeRegistros = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
            }

            //Verificamos
            return _Int_CuentaDeRegistros == _Int_TotalDeRegistros;

        }

        private void _Btn_Actualizar_Click(object sender, EventArgs e)
        {
            _Btn_Actualizar.Enabled = false;
            _Mtd_Actualizar_Descargadas();
            _Mtd_Actualizar_Ingresadas();
            _Btn_Actualizar.Enabled = true;
        }
    }
}
