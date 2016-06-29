using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_AjusteEntrada : Form
    {
        int _G_Int_Tab = 0;
        int _G_Int_Aprobacion = 0;
        bool _Bol_Tabs = new bool();
        string _Str_MyProceso = "";
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        
        string _Str_FirmaAprobador1 = "";
        string _Str_FirmaAprobador2 = "";
        string _Str_TpoUsu = "";
        string _Str_TipoOperacion = "";

        //Ajustes desde el menu
        public Frm_AjusteEntrada()
        {
            InitializeComponent();
            _Bol_Tabs = false;
            _Mtd_Actualizar();
            _Grb_Firma.Visible = false;
        }

        //Ajustes por Aprobar
        public Frm_AjusteEntrada(bool _P_Bol_Tabs, int _P_Int_Aprobacion)
        {
            InitializeComponent();
            _Bol_Tabs = _P_Bol_Tabs;
            _G_Int_Aprobacion = _P_Int_Aprobacion;
            _Mtd_Actualizar_Tabs(_G_Int_Aprobacion); 
            _Dg_Grid2.ReadOnly = true; 
        }

        // Ajustes por Imprimir
        public Frm_AjusteEntrada(int _P_Int_Tabs)
        {
            InitializeComponent();
            _G_Int_Tab = _P_Int_Tabs;
            _Mtd_Actualizar();
            
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="_P_Ctrl_Control">Establece el efecto de color estandar para controles de la aplicación</param>
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
        /// <summary>
        /// Acualiza los registros de la consulta.
        /// </summary>
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cajustent";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cajustent as Código, CONVERT(varchar, cdateajus, 3) AS Fecha,cname as Descripción,cnrecepcion,cidmotivo, dbo.Fnc_Formatear(ccosttotsimp) as Monto, dbo.Fnc_Formatear(cvalorimp) as Impuesto,CASE WHEN cejecutada='1' THEN 'Sí' ELSE 'No' END AS Actualizado, cuseraprobador1,cuseraprobador2,cfuseraprobador1,cfuseraprobador2  from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND canulado='0'";
            if (_G_Int_Tab == 1)
            {
                _Str_Cadena = _Str_Cadena + " AND cimpreso=0 and cejecutada=1";
            }
            _Str_Cadena += " AND (ISNULL(cajusteintegrado,0)='0' OR (cajusteintegrado=1 AND (cimpreso='1' OR canulado='1')))";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Ajustes", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //_Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = false;
            _Dg_Grid.Columns[11].Visible = false;
        }
        /// <summary>
        /// Acualiza los registros de la consulta mostrando solo los que pertenecen a un tabs.
        /// </summary>
        private void _Mtd_Actualizar_Tabs(int _P_Int_Aprobacion)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cajustent";
            _Str_Campos[1] = "cname";

            var _Str_Cadena = "";

            if (_P_Int_Aprobacion == 1) //Aprobacion 1
            {
                _Str_Cadena = "Select cajustent as Código, CONVERT(varchar, cdateajus, 3) AS Fecha,cname as Descripción,cnrecepcion,cidmotivo, dbo.Fnc_Formatear(ccosttotsimp) as Monto, dbo.Fnc_Formatear(cvalorimp) as Impuesto, cuseraprobador1,cuseraprobador2,cfuseraprobador1,cfuseraprobador2 from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador1,0)=0 and isnull(cfuseraprobador2,0)=0";
            }
            else if (_P_Int_Aprobacion == 2) //Aprobacion 2
            {
                _Str_Cadena = "Select cajustent as Código, CONVERT(varchar, cdateajus, 3) AS Fecha,cname as Descripción,cnrecepcion,cidmotivo, dbo.Fnc_Formatear(ccosttotsimp) as Monto, dbo.Fnc_Formatear(cvalorimp) as Impuesto, cuseraprobador1,cuseraprobador2,cfuseraprobador1,cfuseraprobador2 from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cejecutada='0' AND canulado='0' and isnull(cfuseraprobador1,0)=1 and isnull(cfuseraprobador2,0)=0";
            }

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Ajustes", _Tsm_Menu, _Dg_Grid);
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[8].Visible = false;
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = false;
            
            if (_Dg_Grid.Rows.Count == 0)
            {
                this.Close();
                _Dg_Grid2.ReadOnly = true;
                _Bt_FirmaAprobador1.Enabled = false;
                _Bt_FirmaAprobador2.Enabled = false;
                _Bt_EliminarAprobador1.Enabled = false;
                _Bt_EliminarAprobador2.Enabled = false;
            }
        }
        /// <summary>
        /// Devuelve un consecutivo que representa el campo clave de la tabla maestra utilizada
        /// en este formulario.
        /// </summary>
        /// <returns></returns>
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cajustent FROM TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cajustent  DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        /// <summary>
        /// Inicializa los controles del formulario.
        /// </summary>
        public void _Mtd_Ini()
        {
            _Txt_Recepcion.Text = "";
            _Txt_Numero.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Costo.Text = "";
            _Dg_Grid2.Rows.Clear();
            _Mtd_Cargar_Motivo();
            _Mtd_Habilitar();
            _Str_MyProceso = "";
            _Dg_Grid2.AllowUserToDeleteRows = false;
            _Str_FirmaAprobador1 = "";
            _Str_FirmaAprobador2 = "";
            _Txt_FirmaAprobador1.Text = "";
            _Txt_FirmaAprobador2.Text = "";
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Mtd_BotonesMenu();
        }
        /// <summary>
        /// Habilita los controles del formulario.
        /// </summary>
        public void _Mtd_Habilitar()
        {
            _Txt_Recepcion.Enabled = true;
            _Txt_Numero.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Cmb_Motivo.Enabled = true;
            _Dg_Grid2.ReadOnly = false;
            _Dg_Grid2.Columns[2].ReadOnly = true;
            _Dg_Grid2.Columns[3].ReadOnly = true;
            _Dg_Grid2.Columns[4].ReadOnly = true;
            _Dg_Grid2.Rows.Add();
            _Str_MyProceso = "M";
            _Dg_Grid2.AllowUserToDeleteRows = true;
        }
        /// <summary>
        /// Deshabilita los controles del formulario.
        /// </summary>
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Recepcion.Enabled = false;
            _Txt_Numero.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Dg_Grid2.ReadOnly = true;
        }
        /// <summary>
        /// Prepara el formulario para crear un nuevo registro. Metodo llamado dinámicamente desde un formulario padre.
        /// </summary>
        public void _Mtd_Nuevo()
        {
            _Pnl_Descripcion.Visible = false;
            _Bol_Error = true;
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Txt_Fecha.Text = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Recepcion.Focus();
            _Str_MyProceso = "A";
            _Dg_Grid2.AllowUserToDeleteRows = true;
        }
        /// <summary>
        /// Devuelve un valor que indica si el grid del detalle posee campos nulos en cualquier registro
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_Verificar_Grid()
        {
            _Dg_Grid2.EndEdit();
            bool _Bol_Valido = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[4].Value != null & (_Dg_Row.Cells[5].Value != null | _Dg_Row.Cells[6].Value != null))
                {
                    string _Str_Caj = "0";
                    if (_Dg_Row.Cells[5].Value != null)
                    {
                        _Str_Caj = _Dg_Row.Cells[5].Value.ToString();
                    }
                    string _Str_Und="0";
                    if (_Dg_Row.Cells[6].Value != null)
                    {
                        _Str_Und=_Dg_Row.Cells[6].Value.ToString();
                    }
                    if (_Str_Caj == "")
                    {
                        _Str_Caj = "0";
                    }
                    if (_Str_Und == "")
                    {
                        _Str_Und = "0";
                    }
                    if (_Str_Caj != "0" || _Str_Und != "0")
                    {
                        _Bol_Valido = true;
                    }
                    else
                    {
                        _Bol_Valido = false;
                    }
                }
                else
                {
                    if (_Dg_Row.Cells[0].Value != null)
                    {
                        _Bol_Valido = false;
                    }
                }
                if (!_Bol_Valido)
                {
                    break;
                }
            }
            return _Bol_Valido;
        }
        /// <summary>
        /// Guarda el ó los registros en la BD. Metodo llamado dinámicamente desde un formulario padre.
        /// </summary>
        /// <returns></returns>
        public bool _Mtd_Guardar()
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado(Frm_Padre._Str_Comp))
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Er_Error.Dispose();
            _Txt_Numero.Text = _Mtd_Entrada().ToString();
            _Txt_Descripcion.Text = "AJUSTE DE ENTRADA SEGÚN LA RECEPCIÓN " + _Txt_Numero.Text;
            bool _Bol_Verificar_Grid = _Mtd_Verificar_Grid();
            if (_Txt_Recepcion.Text.Trim().Length > 0 & _Cmb_Motivo.SelectedIndex!=-1 & _Bol_Verificar_Grid)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' and cnrecepcion='"+_Txt_Recepcion.Text.Trim()+"'"))
                {
                    MessageBox.Show("La recepción ya ha sido agregada. Coloque una diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Txt_Recepcion.Text = "";
                    _Txt_Recepcion.Focus();
                    return false;
                }
                else
                {
                    //if (!CLASES._Cls_Varios_Metodos._Mtd_Facturacion())
                    //{
                    //    MessageBox.Show("De acuerdo al calendario de cierre no se puede realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                        _Mtd_Met_Actuaizar(_Txt_Numero.Text.Trim(), _Txt_Recepcion.Text.Trim(), true);
                        MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if ((Frm_Padre)this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                    //}
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Recepcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Recepcion, "Información requerida!!!"); }
                if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                if (!_Bol_Verificar_Grid)
                { 
                    MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...","Requerimiento",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); 
                }
                return false;
            }
        }
        /// <summary>
        /// Edita el ó los registros seleccionados de la BD. Metodo llamado dinámicamente desde un formulario padre.
        /// </summary>
        /// <returns></returns>
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            bool _Bol_Verificar_Grid = _Mtd_Verificar_Grid();
            if (_Txt_Recepcion.Text.Trim().Length > 0 & _Cmb_Motivo.SelectedIndex!=-1 & _Bol_Verificar_Grid)
            {
                //if (!CLASES._Cls_Varios_Metodos._Mtd_Facturacion())
                //{
                //    MessageBox.Show("De acuerdo al calendario de cierre no se puede realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                    _Mtd_Met_Actuaizar(_Txt_Numero.Text.Trim(), _Txt_Recepcion.Text.Trim(), false);
                    MessageBox.Show("La operación a sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Er_Error.Dispose();
                return true;
            }
            else
            {
                if (_Txt_Recepcion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Recepcion, "Información requerida!!!"); }
                if (_Cmb_Motivo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                if (!_Bol_Verificar_Grid)
                { MessageBox.Show("Faltan datos en el detalle. Por favor Verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                return false;
            }
        }
        /// <summary>
        /// Elimina el ó los registros seleccionados de la BD. Metodo llamado dinámicamente desde un formulario padre.
        /// </summary>
        /// <returns></returns>
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TAJUSENTC Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_Numero.Text.Trim() + "' and cnrecepcion='"+_Txt_Recepcion.Text.Trim()+"'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        /// <summary>
        /// Obtiene una porción de cadena SQL que devuelve los productos agregados en el grid del detalle para no mostrarlos
        /// en una nueva consulta.
        /// </summary>
        /// <returns></returns>
        private string _Mtd_Imp_Selec()
        {
            string _Str_Cadena = " and (";
            bool _Bol_String = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[0].Value!=null)
                {
                    _Str_Cadena = _Str_Cadena + "cproducto!='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' and ";
                    _Bol_String = true;
                }
            }
            _Str_Cadena = _Str_Cadena.Substring(0, _Str_Cadena.Length - 4);
            if (_Bol_String)
            {
                return _Str_Cadena + ")";
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Devuelve un valor que indica si el parametro es un valor numérico.
        /// </summary>
        /// <param name="Expression">Valor al que se le aplicara la evaluación</param>
        /// <returns></returns>
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_P_Str_ID">Valor del Campo cajustent.</param>
        /// <param name="_P_Str_Rec">Valor del Campo cnrecepcion.</param>
        /// <param name="_P_Bol_Guardar">Valor que indica si el proceso es guardar.</param>
        private void _Mtd_Met_Actuaizar(string  _P_Str_ID,string _P_Str_Rec,bool _P_Bol_Guardar)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            if (!_P_Bol_Guardar)
            {
                _Str_Cadena = "Delete from TAJUSENTD where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='"+_P_Str_ID+"'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                string _Str_IdProductoD = "";
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Cajas=0;
                double _Dbl_Unidades=0;
                double _Dbl_ccostobruto_u1 = 0;
                double _Dbl_ccostobruto_u2 = 0;
                double _Dbl_ccostoneto_u1 = 0;
                double _Dbl_ccostoneto_u2 = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[4].Value != null & (_Dg_Row.Cells[5].Value != null | _Dg_Row.Cells[6].Value != null))
                {
                    _Str_Cadena = "Select TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csku,TPRODUCTO.csubgrupo,TPRODUCTO.CCOSTONETO_U1 AS ccostoneto_u1,TPRODUCTO.CCOSTOBRUTO_U1 AS ccostobruto_u1,(TPRODUCTO.CCOSTONETO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) as ccostoneto_u2,(TPRODUCTO.CCOSTOBRUTO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) AS ccostobruto_u2,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO where TPRODUCTO.cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _Dg_Row.Cells[9].Value.ToString().Trim() + "'";
                    //_Str_Cadena = "Select TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csku,TPRODUCTO.csubgrupo,TPRODUCTOD.ccostonetolote AS ccostoneto_u1,TPRODUCTOD.ccostobrutolote AS ccostobruto_u1,(TPRODUCTOD.ccostonetolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) as ccostoneto_u2,(TPRODUCTOD.ccostobrutolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) AS ccostobruto_u2,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO where TPRODUCTO.cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _Dg_Row.Cells[9].Value.ToString().Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Dg_Row.Cells[9].Value != null)
                        {
                            _Str_IdProductoD = _Dg_Row.Cells[9].Value.ToString();
                        }
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u1"].ToString()); }
                        else { _Dbl_ccostobruto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostobruto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostobruto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostobruto_u2"].ToString()); }
                        else { _Dbl_ccostobruto_u2 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString()); }
                        else { _Dbl_ccostoneto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u2"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u2"].ToString()); }
                        else { _Dbl_ccostoneto_u2 = 0; }
                        if (_Dg_Row.Cells[5].Value != null)
                        {
                            if (Convert.ToString(_Dg_Row.Cells[5].Value).Trim().Length > 0)
                            {
                                _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[5].Value.ToString());
                            }
                        }
                        else
                        { _Dbl_Cajas = 0; }
                        if (_Dg_Row.Cells[6].Value != null)
                        {
                            if (Convert.ToString(_Dg_Row.Cells[6].Value).Trim().Length > 0)
                            {
                                _Dbl_Unidades = Convert.ToDouble(_Dg_Row.Cells[6].Value.ToString());
                            }
                        }
                        else
                        { _Dbl_Unidades = 0; }
                        _Dbl_CostoCajas = _Dbl_Cajas * _Dbl_ccostoneto_u1;
                        double _Dbl_ContenidoUnd = 1;
                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                        {
                            _Dbl_ContenidoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                        }
                        _Dbl_CostoUnidades = _Dbl_Unidades * (_Dbl_ccostoneto_u1 / _Dbl_ContenidoUnd);
                        _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value.ToString().Trim() + "')";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            { _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); }
                            else { _Dbl_Impuesto = 0; }
                        }
                        else
                        { _Dbl_Impuesto = 0; }
                        _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                        _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas+_Dbl_CostoUnidades);
                        _Dbl_ImpuestoTotal=_Dbl_ImpuestoTotal+(_Dbl_ImpuestoCajas+_Dbl_ImpuestoUnidades);
                        DataRow _Row=_Ds.Tables[0].Rows[0];
                        _Str_Cadena = "Insert into TAJUSENTD (ccompany,cajustent,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete,cidproductod) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _Row["cproveedor"].ToString() + "','" + _Row["cgrupo"].ToString() + "','" + _Row["csubgrupo"].ToString() + "','" + _Row["csku"].ToString() + "','" + _Dg_Row.Cells[0].Value.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostoneto_u2) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ccostobruto_u2) + "','" + _Dbl_Cajas.ToString() + "','" + _Dbl_Unidades.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CostoUnidades) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoCajas) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoUnidades) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_IdProductoD + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
            if (_P_Bol_Guardar)
            {
                _Str_Cadena = "Insert into TAJUSENTC (ccompany,cajustent,cnrecepcion,cname,cidmotivo,cyearacco,cmontacco,cdateajus,ccosttotsimp,cvalorimp,cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_Comp + "','" + _P_Str_ID.Trim() + "','" + _P_Str_Rec.Trim() + "','" + _Txt_Descripcion.Text.Trim() + "','" + _Cmb_Motivo.SelectedValue + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month.ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else
            {
                _Str_Cadena = "Update TAJUSENTC set cidmotivo='" + _Cmb_Motivo.SelectedValue + "',ccosttotsimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',cvalorimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ImpuestoTotal) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _P_Str_ID.Trim() + "' and cnrecepcion='" + _P_Str_Rec.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        /// <summary>
        /// Realiza el calculo que determina el total del Costo y total del Impuesto determinado
        /// por todos los registros del detalle.
        /// </summary>
        private void _Mtd_Met_Realizar_Calculo()
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                double _Dbl_Cajas = 0;
                double _Dbl_Unidades = 0;
                double _Dbl_ccostoneto_u1 = 0;
                double _Dbl_ccostoneto_u2 = 0;
                if (_Dg_Row.Cells[0].Value != null & _Dg_Row.Cells[4].Value != null & (_Dg_Row.Cells[5].Value != null | _Dg_Row.Cells[6].Value != null))
                {
                    //_Str_Cadena = "Select TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csku,TPRODUCTO.csubgrupo,TPRODUCTOD.CCOSTONETOLOTE AS ccostoneto_u1,TPRODUCTOd.ccostobrutolote AS ccostobruto_u1,(TPRODUCTOD.CCOSTONETOLOTE / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) as ccostoneto_u2,(TPRODUCTOd.ccostobrutolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) AS ccostobruto_u2,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO where TPRODUCTO.cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _Dg_Row.Cells[9].Value.ToString().Trim() + "'";
                    _Str_Cadena = "Select TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csku,TPRODUCTO.csubgrupo,TPRODUCTO.CCOSTONETO_U1 AS ccostoneto_u1,TPRODUCTO.CCOSTOBRUTO_U1 AS ccostobruto_u1,(TPRODUCTO.CCOSTONETO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) as ccostoneto_u2,(TPRODUCTO.CCOSTOBRUTO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) AS ccostobruto_u2,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO where TPRODUCTO.cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _Dg_Row.Cells[9].Value.ToString().Trim() + "'";
                    //_Str_Cadena = "Select cproveedor,cgrupo,csku,csubgrupo,ccostoneto_u1,ccostobruto_u1,ccostoneto_u2,ccostobruto_u2,ccontenidoma1,ccontenidoma2 from TPRODUCTO where cproducto='" + _Dg_Row.Cells[0].Value.ToString().Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString()); }
                        else { _Dbl_ccostoneto_u1 = 0; }
                        if (_Ds.Tables[0].Rows[0]["ccostoneto_u1"] != System.DBNull.Value)
                        { _Dbl_ccostoneto_u2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString()) / (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString())); }
                        else { _Dbl_ccostoneto_u2 = 0; }
                        if (_Dg_Row.Cells[5].Value != null)
                        { _Dbl_Cajas = Convert.ToDouble(_Dg_Row.Cells[5].Value.ToString()); }
                        else
                        { _Dbl_Cajas = 0; }
                        if (_Dg_Row.Cells[6].Value != null)
                        {
                            if (_Dg_Row.Cells[6].Value.ToString() != "")
                            { _Dbl_Unidades = Convert.ToDouble(_Dg_Row.Cells[6].Value.ToString()); }
                            else
                            {
                                _Dbl_Unidades = 0; 
                            }
                        }
                        else
                        { _Dbl_Unidades = 0; }
                        _Dbl_CostoCajas = _Dbl_Cajas * _Dbl_ccostoneto_u1;
                        double _Dbl_ContenidoUnd = 1;
                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                        {
                            _Dbl_ContenidoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                        }
                        _Dbl_CostoUnidades = _Dbl_Unidades * (_Dbl_ccostoneto_u1 / _Dbl_ContenidoUnd);
                        _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value.ToString().Trim() + "')";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                            { _Dbl_Impuesto = Convert.ToDouble(_Ds2.Tables[0].Rows[0][0].ToString()); }
                            else { _Dbl_Impuesto = 0; }
                        }
                        else
                        { _Dbl_Impuesto = 0; }
                        _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                        _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas + _Dbl_CostoUnidades);
                        _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + (_Dbl_ImpuestoCajas + _Dbl_ImpuestoUnidades);
                    }
                }
            }
            _Txt_Costo.Text = _Dbl_MontoTotal.ToString("#,##0.00");
            _Txt_Impuesto.Text = _Dbl_ImpuestoTotal.ToString("#,##0.00");
        }
        /// <summary>
        ///Carga el combo del Motivo.
        /// </summary>
        private void _Mtd_Cargar_Motivo()
        {
            _Cmb_Motivo.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT TMOTIVO.cidmotivo,TMOTIVO.cdescripcion FROM TMOTIVO where cajusteentr='1' ORDER BY TMOTIVO.cconcepto ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Motivo.DataSource = _Ds.Tables[0];
            _Cmb_Motivo.DisplayMember = "cdescripcion";
            _Cmb_Motivo.ValueMember = "cidmotivo";
            _Cmb_Motivo.SelectedIndex = -1;
        }
        /// <summary>
        /// Determina si el costo neto de un producto es mayor a cero.
        /// </summary>
        /// <param name="_P_Str_Producto">Código del Producto</param>
        /// <returns>bool</returns>
        private bool _Mtd_VerificarCostoNeto(string _P_Str_Producto, string _Str_IdProductoD)
        {
            string _Str_Cadena = "SELECT * FROM TPRODUCTOD WHERE cproducto='" + _P_Str_Producto + "' AND ccostonetolote>0 and cidproductod='" + _Str_IdProductoD + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }

        private void _Mtd_Imprimir(bool _P_Bol_Boton)
        {
            try
            {
            Etiq_Print:
                string _Str_Sql = "";
                PrintDialog _Print = new PrintDialog();
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "VST_AJUSTEENT_RPT" }, "", "T3.Report.rAjtEntrada", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_Numero.Text + "'", _Print, true);
                    Cursor = Cursors.Default;
                    _Frm.Show();
                    if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Str_Sql = "UPDATE TAJUSENTC SET cimpreso=1,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_Numero.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_Sql = "UPDATE TINVFISICOHISTM SET cfinalizado='2' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfinalizado='1'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        Cursor = Cursors.Default;
                        if ((Frm_Padre)this.MdiParent != null)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        }
                        if (_P_Bol_Boton)
                        {
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                            _Er_Error.Dispose();
                            _Mtd_BotonesMenu();
                        }
                        try
                        {
                            ((T3.Report.rAjtEntrada)((CrystalDecisions.Windows.Forms.CrystalReportViewer)_Frm.Controls.Find("crystalReportViewer1", true)[0]).ReportSource).Close();
                            ((T3.Report.rAjtEntrada)((CrystalDecisions.Windows.Forms.CrystalReportViewer)_Frm.Controls.Find("crystalReportViewer1", true)[0]).ReportSource).Dispose();
                        }
                        catch { }
                        GC.Collect();
                        _Frm.Close();
                    }
                    else
                    {
                        try
                        {
                            ((T3.Report.rAjtEntrada)((CrystalDecisions.Windows.Forms.CrystalReportViewer)_Frm.Controls.Find("crystalReportViewer1", true)[0]).ReportSource).Close();
                            ((T3.Report.rAjtEntrada)((CrystalDecisions.Windows.Forms.CrystalReportViewer)_Frm.Controls.Find("crystalReportViewer1", true)[0]).ReportSource).Dispose();
                        }
                        catch { }
                        GC.Collect();
                        _Frm.Close();
                        goto Etiq_Print;
                    }
                }
            }
            catch (Exception _Ex) { this.Cursor = Cursors.Default; MessageBox.Show("Error al conectarse con la impresora.\n" + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void Frm_AjusteEntrada_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Motivo();
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
            //Para evitar editar celdas que no se deben editar
        }

        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 5 | _Dg_Grid2.CurrentCell.ColumnIndex == 6)
            {
                if (!_Mtd_IsNumeric(((TextBox)sender).Text))
                {
                    ((TextBox)sender).Text = "";
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 5 | _Dg_Grid2.CurrentCell.ColumnIndex == 6)
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }
        private bool _Mtd_VerificarCargado(string _Str_Producto, string _Str_IdProductoD)
        {
            return _Dg_Grid2.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToString(x.Cells["cproducto"].Value).Trim() == _Str_Producto && Convert.ToString(x.Cells["cidproductod"].Value).Trim() == _Str_IdProductoD).Count() > 0;
        }
        private void _Dg_Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (_Dg_Grid2.Rows.Count > 0)
            {
                _Er_Error.Dispose();
                if (e.ColumnIndex == 1 & _Cmb_Motivo.Text.Trim().Length > 0 & !_Cmb_Motivo.Enabled)
                { }
                else if (e.ColumnIndex == 1 & _Cmb_Motivo.SelectedIndex != -1 & _Txt_Recepcion.Text.Trim().Length > 0)
                {
                    TextBox _Txt_TemporalCod = new TextBox();
                    TextBox _Txt_TemporalDes = new TextBox();
                    TextBox _Txt_TemporalLote = new TextBox();
                    TextBox _Txt_TemporalPMV = new TextBox();
                    TextBox _Txt_TemporalCodLote = new TextBox();
                    Frm_BusquedaProductoLote _Frm = new Frm_BusquedaProductoLote(false, _Txt_TemporalCod, _Txt_TemporalDes, _Txt_TemporalLote, _Txt_TemporalPMV, _Txt_TemporalCodLote);
                    _Frm.ShowDialog();
                    if (_Txt_TemporalCod.Text.Trim().Length > 0)
                    {
                        if (_Mtd_VerificarCargado(_Txt_TemporalCod.Text, _Txt_TemporalCodLote.Text))
                        {
                            MessageBox.Show("No se puede cargar este producto por que ya fue cargado en el presente ajuste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (_Mtd_VerificarCostoNeto(_Txt_TemporalCod.Text, _Txt_TemporalCodLote.Text))
                            {
                                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Txt_TemporalCod.Text;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Txt_TemporalLote.Text;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = _Txt_TemporalPMV.Text;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = _Txt_TemporalDes.Text;
                                _Dg_Grid2.Rows[e.RowIndex].Cells[9].Value = _Txt_TemporalCodLote.Text;
                                string _Str_SentenciaSQL = "SELECT dbo.Fnc_Formatear(TPRODUCTO.CCOSTONETO_U1) as CCOSTONETO_U1, dbo.Fnc_Formatear((TPRODUCTO.CCOSTONETO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END))) AS CCOSTONETO_U2 FROM TPRODUCTOD INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOD.CPRODUCTO WHERE TPRODUCTO.CPRODUCTO='" + _Txt_TemporalCod.Text + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _Txt_TemporalCodLote.Text + "'";
                                //string _Str_SentenciaSQL = "SELECT dbo.Fnc_Formatear(TPRODUCTOD.CCOSTONETOLOTE) as CCOSTONETO_U1, dbo.Fnc_Formatear((TPRODUCTOD.CCOSTONETOLOTE / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END))) AS CCOSTONETO_U2 FROM TPRODUCTOD INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOD.CPRODUCTO WHERE TPRODUCTO.CPRODUCTO='" + _Txt_TemporalCod.Text + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _Txt_TemporalCodLote.Text + "'";
                                DataSet _Ds_DataSet = new DataSet();
                                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                                {
                                    _Dg_Grid2.Rows[e.RowIndex].Cells["ccostoneto_u1"].Value = _Dtw_Item["CCOSTONETO_U1"].ToString();
                                    _Dg_Grid2.Rows[e.RowIndex].Cells["ccostoneto_u2"].Value = _Dtw_Item["CCOSTONETO_U2"].ToString();
                                }
                                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            }
                            else
                            { MessageBox.Show("No se puede cargar este producto ya que el costo neto esta en cero.\n Verifique el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                }
                //Para evitar editar celdas que no se deben editar
                else if (e.ColumnIndex == 0 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
                {
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[2].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[3].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[7].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[8].ReadOnly = true;
                }
                else
                {
                    if (_Cmb_Motivo.SelectedIndex == -1)
                    { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                    if (_Txt_Recepcion.Text.Trim().Length == 0)
                    { _Er_Error.SetError(_Txt_Recepcion, "Información requerida!!!"); }
                }
            }
        }

        private void _Dg_Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    bool _Bol_ = false;
            //    int _int_i = -1;
            //    _Bol_=_Mtd_VerificarCargado(
            //    if (!_Bol_)
            //    {
            //        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select (produc_descrip + '.' + produc_descrip_2) from VST_PRODUCTOS_A where cproducto='" + _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value + "'");
            //        if (_Ds.Tables[0].Rows.Count > 0)
            //        {
            //            if (_Mtd_VerificarCostoNeto(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value), Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[9].Value)))
            //            {
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = _Ds.Tables[0].Rows[0][0].ToString();
            //                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //            }
            //            else
            //            { 
            //                MessageBox.Show("No se puede cargar este producto ya que el costo neto esta en cero.\n Verifique el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                if (e.RowIndex != _Dg_Grid2.Rows.Count - 1)
            //                {
            //                    _Dg_Grid2.Rows.RemoveAt(e.RowIndex);
            //                }
            //                else
            //                {
            //                    _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
            //                    _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
            //                    _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
            //                    _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value != null)
            //            {
            //                MessageBox.Show("El producto cargado no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            if (e.RowIndex != _Dg_Grid2.Rows.Count - 1)
            //            {
            //                _Dg_Grid2.Rows.RemoveAt(e.RowIndex);
            //            }
            //            else
            //            {
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("El producto ya a sido cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        if (e.RowIndex != _int_i)
            //        {
            //            if (e.RowIndex != _Dg_Grid2.Rows.Count - 1)
            //            {
            //                _Dg_Grid2.Rows.RemoveAt(e.RowIndex);
            //            }
            //            else
            //            {
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
            //                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = null;
            //            }
            //        }
            //    }
            //}
            //else 
            if (e.ColumnIndex == 6)
            {
                int _Int_UndGrid = 0;
                if (Convert.ToString(_Dg_Grid2[6, e.RowIndex].Value).Length > 0)
                {
                    _Int_UndGrid = Convert.ToInt32(_Dg_Grid2[6, e.RowIndex].Value);
                }
                if (_Int_UndGrid > 0)
                {
                    int _Int_DBunidades = Convert.ToInt32(_MyUtilidad._Mtd_ProductoUndManejo2(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    _Int_UndGrid = Convert.ToInt32(_Dg_Grid2[6, e.RowIndex].Value);
                    if (_Int_UndGrid >= _Int_DBunidades)
                    {
                        MessageBox.Show("La cantidad de unidades debe ser inferior a " + _Int_DBunidades.ToString() + ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Dg_Grid2[6, e.RowIndex].Value = "";
                    }
                }
            }
            _Dg_Grid2.Refresh();
            if (_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value != null & _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value != null & (_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value != null | _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value != null))// & e.RowIndex==_Dg_Grid2.Rows.Count-1)
            {
                string _Str_CantCaj = Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value);
                int _Itn_CantCaj = 0;
                string _Str_CantUnd = Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[6].Value);
                int _Itn_CantUnd = 0;
                if (_Str_CantCaj.TrimEnd().Length > 0)
                {
                    _Itn_CantCaj = Convert.ToInt32(_Str_CantCaj);
                }
                if (_Str_CantUnd.TrimEnd().Length > 0)
                {
                    _Itn_CantUnd = Convert.ToInt32(_Str_CantUnd);
                }
                if (_Itn_CantCaj == 0 && _Itn_CantUnd == 0)
                {
                    MessageBox.Show("Introduzca las cantidades para el movimiento", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Dg_Grid2.Rows[e.RowIndex].Cells[5].Value = null;
                    _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value = null;
                }
                else
                {
                    if (e.RowIndex == _Dg_Grid2.Rows.Count - 1)
                    {
                        _Dg_Grid2.Rows.Add();
                    }
                    _Mtd_Met_Realizar_Calculo();
                }
            }
        }

        private void Frm_AjusteEntrada_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_AjusteEntrada_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _Tb_Tab.SelectedIndex = 1;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Pnl_Descripcion.Visible = true;
                _Txt_Numero.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                _Txt_Recepcion.TextChanged-=new EventHandler(_Txt_Recepcion_TextChanged);
                _Txt_Recepcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                _Txt_Recepcion.TextChanged += new EventHandler(_Txt_Recepcion_TextChanged);
                _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                _Txt_Fecha.Text = Convert.ToDateTime(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex)).Date.ToShortDateString();
                _Cmb_Motivo.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex);
                _Txt_Costo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex);
                _Txt_Impuesto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex);

                if (_Bol_Tabs)
                {
                    _Grb_Firma.Visible = true;
                    //Firma Aprobador 1
                    _Txt_FirmaAprobador1.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cuseraprobador1", e.RowIndex);
                    _Txt_FirmaAprobador1.Text = _MyUtilidad._Mtd_ObtenerUsuarioName(_Txt_FirmaAprobador1.Tag.ToString());
                    _Str_FirmaAprobador1 = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cfuseraprobador1", e.RowIndex);
                    if (_Str_FirmaAprobador1 == "1")
                        _Bt_FirmaAprobador1.Enabled = false;
                    else if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTRASALIDA_AJUSTE"))
                        _Bt_FirmaAprobador1.Enabled = true;
                    else
                        _Bt_FirmaAprobador1.Enabled = false;

                    //Firma Aprobador 2
                    if (!_Bt_FirmaAprobador1.Enabled)
                    {
                        _Txt_FirmaAprobador2.Tag = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cuseraprobador2", e.RowIndex);
                        _Txt_FirmaAprobador2.Text = _MyUtilidad._Mtd_ObtenerUsuarioName(_Txt_FirmaAprobador2.Tag.ToString());
                        _Str_FirmaAprobador2 = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cfuseraprobador2", e.RowIndex);
                        if (_Str_FirmaAprobador2 == "1")
                            _Bt_FirmaAprobador2.Enabled = false;
                        else if (_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ENTRASALIDA_AJUSTE_2"))
                            _Bt_FirmaAprobador2.Enabled = true;
                        else
                            _Bt_FirmaAprobador2.Enabled = false;
                    }
                    else
                    {
                        _Bt_FirmaAprobador2.Enabled = false;
                    }
                }
                else
                {
                    _Bt_FirmaAprobador1.Enabled = false;
                    _Bt_FirmaAprobador2.Enabled = false;
                    _Txt_FirmaAprobador1.Text = "";
                    _Txt_FirmaAprobador2.Text = "";
                    _Grb_Firma.Visible = false;
                }

                string _Str_Cadena = "Select TAJUSENTD.cproducto,(Select TOP 1 produc_descrip from VST_PRODUCTOS_A where VST_PRODUCTOS_A.cproducto=TAJUSENTD.cproducto) as cnamef,TAJUSENTD.cantajuse_u1,TAJUSENTD.cantajuse_u2,TAJUSENTD.ccostnet_u1,TAJUSENTD.ccostnet_u2,TPRODUCTOD.CIDPRODUCTOD,TPRODUCTOD.cprecioventamax from TAJUSENTD INNER JOIN TPRODUCTOD ON TPRODUCTOD.CIDPRODUCTOD=TAJUSENTD.CIDPRODUCTOD where TAJUSENTD.ccompany='" + Frm_Padre._Str_Comp + "' and TAJUSENTD.cajustent='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                object[] _Obj = new object[10];
                _Dg_Grid2.Rows.Clear();
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Obj[0] = _Row[0].ToString();
                    _Obj[1] = "";
                    _Obj[2] = _Row["cidproductod"].ToString();
                    _Obj[3] = _Row["cprecioventamax"].ToString();
                    _Obj[4] = _Row[1].ToString();
                    _Obj[5] = _Row[2].ToString();
                    _Obj[6] = _Row[3].ToString();
                    _Obj[7] = _Row[4].ToString();
                    _Obj[8] = _Row[5].ToString();
                    _Obj[9] = _Row["CIDPRODUCTOD"].ToString();
                    _Dg_Grid2.Rows.Add(_Obj);
                }
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Txt_Costo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex);
                _Txt_Impuesto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex);
                if (!_Bol_Tabs)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    if (_Mtd_AjusteEntradaProcesada())
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    }
                    else
                    {
                        //Verificamos si existe alguna aprobacion no se permite editar.
                        _Str_FirmaAprobador1 = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cfuseraprobador1", e.RowIndex);
                        _Str_FirmaAprobador2 = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cfuseraprobador2", e.RowIndex);

                        if ((_Str_FirmaAprobador1 == "1") || (_Str_FirmaAprobador2 == "1"))
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        else
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    }
                }
                _Tb_Tab.SelectedIndex = 1;
                if (_G_Int_Tab == 1)
                {
                    _Bt_Imprimir.Visible = true;
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show("Problemas al Cargar la Información");
            }
            Cursor = Cursors.Default;
        }

        private void _Txt_Recepcion_TextChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Txt_Recepcion.Text.Length > 0)
                {
                    if (!_Mtd_IsNumeric(_Txt_Recepcion.Text))
                    {
                        _Txt_Recepcion.Text = "";
                    }
                    else
                    {
                        _Cmb_Motivo.Enabled = true;
                    }
                }
                else
                {
                    _Cmb_Motivo.Enabled = false;
                }
            }
        }

        private void _Txt_Recepcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Motivo();
        }
        int _Int_Clave = 0;
        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            if (_Txt_Numero.Text.Trim().Length > 0 & _Txt_Recepcion.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("¿Esta seguro de aprobar el ajuste?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Int_Clave = 1;
                    _Lbl_Titulo.Text = "¿Esta seguro de aprobar el ajuste?";
                    _Pnl_Clave.Parent = this;
                    _Pnl_Clave.BringToFront();
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para reaizar la operación","Requerimiento",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Str_TpoUsu == "") return;
            Cursor = Cursors.WaitCursor;
            var _Bol_MostrarMensaje = true;
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {

                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    switch (_Str_TpoUsu)
                    {
                        case "APROBADOR1":
                            switch (_Str_TipoOperacion)
                            {
                                case "FIRMA":
                                    //Guardamos la firma
                                    _Str_Cadena = "UPDATE TAJUSENTC SET cfuseraprobador1=1, cuseraprobador1='" + Frm_Padre._Str_Use + "', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_Numero.Text.Trim() + "' and cnrecepcion='" + _Txt_Recepcion.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    //Actualizamos los controles
                                    _Txt_FirmaAprobador1.Text = _MyUtilidad._Mtd_ObtenerUsuarioName(Frm_Padre._Str_Use);
                                    _Txt_FirmaAprobador1.Tag = Frm_Padre._Str_Use;
                                    break;
                                case "ANULACION":
                                    _Str_Cadena = "UPDATE TAJUSENTC Set canulado='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "', cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_Numero.Text.Trim() + "' and cnrecepcion='" + _Txt_Recepcion.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    break;
                            }
                            break;
                        case "APROBADOR2":
                            switch (_Str_TipoOperacion)
                            {
                                case "FIRMA":
                                    //Guardamos la firma
                                    _Str_Cadena = "UPDATE TAJUSENTC SET cfuseraprobador2=1, cuseraprobador2='" + Frm_Padre._Str_Use + "', cejecutada='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_Numero.Text.Trim() + "' and cnrecepcion='" + _Txt_Recepcion.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    //Actualizamos los controles
                                    _Txt_FirmaAprobador2.Text = _MyUtilidad._Mtd_ObtenerUsuarioName(Frm_Padre._Str_Use);
                                    _Txt_FirmaAprobador2.Tag = Frm_Padre._Str_Use;
                                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _Bol_MostrarMensaje = false;
                                    _Mtd_Imprimir(false);
                                    break;
                                case "ANULACION":
                                    _Str_Cadena = "UPDATE TAJUSENTC Set canulado='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "', cdelete='0' where ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_Numero.Text.Trim() + "' and cnrecepcion='" + _Txt_Recepcion.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    break;
                            }
                            break;
                    }

                    //Continuamos
                    if ((Frm_Padre)this.MdiParent != null)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    }
                    _Pnl_Clave.Visible = false;
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Mtd_Actualizar_Tabs(_G_Int_Aprobacion);
                    if (_Bol_MostrarMensaje)
                    { MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    _Tb_Tab.SelectedIndex = 0;
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
            Cursor=Cursors.Default;
        }
        bool _Bol_Error = true;
        private void _Dg_Grid2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (e.ColumnIndex == 0 & (_Cmb_Motivo.SelectedIndex == -1 | _Txt_Recepcion.Text.Trim().Length == 0))
                {
                    _Er_Error.Dispose();
                    if (_Cmb_Motivo.SelectedIndex == -1)
                    { _Er_Error.SetError(_Cmb_Motivo, "Información requerida!!!"); }
                    if (_Txt_Recepcion.Text.Trim().Length == 0)
                    { _Er_Error.SetError(_Txt_Recepcion, "Información requerida!!!"); }
                }
                else if (e.ColumnIndex == 0)
                {
                    _Er_Error.Dispose();
                }
                else if (e.ColumnIndex == 5 | e.ColumnIndex == 6)
                {
                    if ((_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value == null | _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[4].Value == null))
                    {
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[5].ReadOnly = true;
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[6].ReadOnly = true;
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[5].Value = null;
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[6].Value = null;
                    }
                    else
                    {
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[5].ReadOnly = false;
                        _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[6].ReadOnly = false;
                    }
                }
                //Para evitar editar celdas que no se deben editar
                else if (e.ColumnIndex == 0 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
                {
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[2].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[3].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[7].ReadOnly = true;
                    _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[8].ReadOnly = true;
                }
                if (_Bol_Error)
                {
                    _Er_Error.Dispose();
                    _Bol_Error = false;
                }
            }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex>-1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }
        private bool _Mtd_AjusteEntradaProcesada()
        {
            bool _Bol_R = false;
            string _Str_Sql = "SELECT * FROM TAJUSENTC where ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_Numero.Text + "' AND cejecutada=1 AND cdelete=0";
            _Bol_R = Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
            return _Bol_R;
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
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_Numero.Text.Trim().Length > 0 && _Cmb_Motivo.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else if (_Txt_Numero.Text.Trim().Length > 0 && !_Cmb_Motivo.Enabled)
                {
                    if (!_Bol_Tabs)
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    if (_Mtd_AjusteEntradaProcesada())
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    }
                    else
                    {
                        if (!_Bol_Tabs)
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                        }
                        else
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                        }
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                }
                else if (_Txt_Numero.Text.Trim().Length == 0 && !_Cmb_Motivo.Enabled)
                {
                    if (!_Bol_Tabs)
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Txt_Recepcion.Enabled & _Txt_Numero.Text.Trim().Length == 0 & e.TabPageIndex != 0)
            { e.Cancel = true; }
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cmb_Motivo, "");
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            _Mtd_Imprimir(true);
        }

        private void _Dg_Grid2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_Cmb_Motivo.Enabled)
            {
                if (Convert.ToString(_Dg_Grid2[0, e.Row.Index].Value).Trim().Length == 0)
                {
                    if (e.Row.Index == 0)
                    {
                        for (int _I = 0; _I < _Dg_Grid2.ColumnCount; _I++)
                        {
                            _Dg_Grid2.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Grid2_CellEndEdit);
                            _Dg_Grid2[_I, e.Row.Index].Value = "";
                            _Dg_Grid2.CellEndEdit += new DataGridViewCellEventHandler(_Dg_Grid2_CellEndEdit);
                        }
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (e.Row.Index == 0)
                    {
                        for (int _I = 0; _I < _Dg_Grid2.ColumnCount; _I++)
                        {
                            _Dg_Grid2.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Grid2_CellEndEdit);
                            _Dg_Grid2[_I, e.Row.Index].Value = "";
                            _Dg_Grid2.CellEndEdit += new DataGridViewCellEventHandler(_Dg_Grid2_CellEndEdit);
                        }
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel=true;
            }
        }

        private void _Dg_Grid2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _Mtd_Met_Realizar_Calculo();
        }

        private void _Bt_FirmaAprobador1_EnabledChanged(object sender, EventArgs e)
        {
            if (_Bt_FirmaAprobador1.Enabled)
            {
                _Bt_FirmaAprobador1.BackColor = Color.Yellow;
            }
            else
            { _Bt_FirmaAprobador1.BackColor = Color.FromKnownColor(KnownColor.Control); }
            _Bt_EliminarAprobador1.Enabled = _Bt_FirmaAprobador1.Enabled;

        }
        private void _Bt_FirmaAprobador2_EnabledChanged(object sender, EventArgs e)
        {
            if (_Bt_FirmaAprobador2.Enabled)
            {
                _Bt_FirmaAprobador2.BackColor = Color.Yellow;
            }
            else
            { _Bt_FirmaAprobador2.BackColor = Color.FromKnownColor(KnownColor.Control); }
            _Bt_EliminarAprobador2.Enabled = _Bt_FirmaAprobador2.Enabled;

        }

        private void _Bt_FirmaAprobador1_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado(Frm_Padre._Str_Comp))
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Clave.BringToFront();
            _Lbl_TituloClave.Text = "Firma del Aprobador 1";
            _Pnl_Clave.Visible = true;
            _Str_TpoUsu = "APROBADOR1";
            _Str_TipoOperacion = "FIRMA";
        }
        private void _Bt_FirmaAprobador2_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado(Frm_Padre._Str_Comp))
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Clave.BringToFront();
            _Lbl_TituloClave.Text = "Firma del Aprobador 2";
            _Pnl_Clave.Visible = true;
            _Str_TpoUsu = "APROBADOR2";
            _Str_TipoOperacion = "FIRMA";
        }
        private void _Bt_EliminarAprobador1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de anular el ajuste?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Str_TpoUsu = "APROBADOR1";
                _Str_TipoOperacion = "ANULACION";
                _Lbl_TituloClave.Text = "Firma del Aprobador 1";
                _Lbl_Titulo.Text = "¿Esta seguro de anular el ajuste?";
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
        }
        private void _Bt_EliminarAprobador2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de anular el ajuste?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Str_TpoUsu = "APROBADOR2";
                _Str_TipoOperacion = "ANULACION";
                _Lbl_TituloClave.Text = "Firma del Aprobador 2";
                _Lbl_Titulo.Text = "¿Esta seguro de anular el ajuste?";
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
        }

    }
}