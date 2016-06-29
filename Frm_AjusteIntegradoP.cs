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
    public partial class Frm_AjusteIntegradoP : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);

        string _Str_Proveedor = "";
        string _Str_NotaRecepcion = "";
        public string ProductoSalida { get; set; }
        public string ProductoSalidaLote { get; set; }
        public string ProductoSalidaPmv { get; set; }
        public string ProductoEntrada { get; set; }
        public string ProductoEntradaLote { get; set; }
        public string ProductoEntradaPmv { get; set; }
        public int ProductoCajas { get; set; }
        public int ProductoUnidades { get; set; }

        public Frm_AjusteIntegradoP(string _P_Str_Proveedor, string _P_Str_NotaRecepcion)
        {
            InitializeComponent();
            //------------------
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_NotaRecepcion = _P_Str_NotaRecepcion;
            //------------------
        }

        public void _Mtd_CargarFormulario()
        {
            _Txt_SalidaProducto.Text = ProductoSalida;
            _Txt_SalidaLote.Text = ProductoSalidaLote;
            _Txt_SalidaPmv.Text = ProductoSalidaPmv;
            _Txt_SalidaProductoDesc.Text = _Mtd_DescripcionProducto(ProductoSalida);
            _Mtd_CargarSalida(ProductoSalida, ProductoSalidaLote, ProductoSalidaPmv);
            //------------------
            _Txt_EntradaProducto.Text = ProductoEntrada;
            _Txt_EntradaLote.Text = ProductoEntradaLote;
            _Txt_EntradaPmv.Text = ProductoEntradaPmv;
            _Txt_EntradaProductoDesc.Text = _Mtd_DescripcionProducto(ProductoEntrada);
            _Mtd_CargarEntrada(ProductoEntrada, ProductoEntradaLote, ProductoEntradaPmv);
            //------------------
            _Txt_Cajas.Text = ProductoCajas.ToString();
            _Txt_Unidades.Text = ProductoUnidades.ToString();
        }

        private string _Mtd_DescripcionProducto(string _P_Str_Producto)
        {
            var _Str_Cadena = "SELECT cnamefc FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

        private void _Mtd_CargarSalida(string _P_Str_Producto, string _P_Str_LoteId,string _P_Str_Pmv)
        {
            _Txt_SalidaNetoCaja.Text = "";
            _Txt_SalidaNetoUnidad.Text = "";
            _Txt_Unidades.Enabled = _Mtd_ManejaUnidades(_P_Str_Producto);
            //var _Str_Cadena = "SELECT dbo.Fnc_Formatear(TPRODUCTOD.ccostonetolote) as CCOSTONETO_U1, dbo.Fnc_Formatear((TPRODUCTOD.ccostonetolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END))) AS CCOSTONETO_U2 FROM TPRODUCTOD INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOD.CPRODUCTO WHERE TPRODUCTO.CPRODUCTO='" + _P_Str_Producto + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _P_Str_LoteId + "'";
            var _Str_Cadena = "SELECT dbo.Fnc_Formatear(TPRODUCTO.CCOSTONETO_U1) as CCOSTONETO_U1, dbo.Fnc_Formatear((TPRODUCTO.CCOSTONETO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END))) AS CCOSTONETO_U2 FROM TPRODUCTOD INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOD.CPRODUCTO WHERE TPRODUCTO.CPRODUCTO='" + _P_Str_Producto + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _P_Str_LoteId + "'";
            DataSet _Ds = new DataSet();
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_SalidaNetoCaja.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["CCOSTONETO_U1"]);
                _Txt_SalidaNetoUnidad.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["CCOSTONETO_U2"]);
                _Bt_Aceptar.Enabled = !string.IsNullOrEmpty(_Txt_EntradaProducto.Text);
            }
        }

        private void _Mtd_CargarEntrada(string _P_Str_Producto, string _P_Str_LoteId, string _P_Str_Pmv)
        {
            _Txt_EntradaNetoCaja.Text = "";
            _Txt_EntradaNetoUnidad.Text = "";
            //var _Str_Cadena = "SELECT dbo.Fnc_Formatear(TPRODUCTOD.ccostonetolote) as CCOSTONETO_U1, dbo.Fnc_Formatear((TPRODUCTOD.ccostonetolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END))) AS CCOSTONETO_U2 FROM TPRODUCTOD INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOD.CPRODUCTO WHERE TPRODUCTO.CPRODUCTO='" + _P_Str_Producto + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _P_Str_LoteId + "'";
            var _Str_Cadena = "SELECT dbo.Fnc_Formatear(TPRODUCTO.CCOSTONETO_U1) as CCOSTONETO_U1, dbo.Fnc_Formatear((TPRODUCTO.CCOSTONETO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END))) AS CCOSTONETO_U2 FROM TPRODUCTOD INNER JOIN TPRODUCTO ON TPRODUCTO.CPRODUCTO=TPRODUCTOD.CPRODUCTO WHERE TPRODUCTO.CPRODUCTO='" + _P_Str_Producto + "' AND TPRODUCTOD.CIDPRODUCTOD='" + _P_Str_LoteId + "'";
            DataSet _Ds = new DataSet();
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_EntradaNetoCaja.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["CCOSTONETO_U1"]);
                _Txt_EntradaNetoUnidad.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["CCOSTONETO_U2"]);
                _Bt_Aceptar.Enabled = !string.IsNullOrEmpty(_Txt_SalidaProducto.Text);
            }
        }

        private bool _Mtd_MayorQueCero(string _P_Str_Variable)
        {
            double _Dbl_Variable = 0;
            if (double.TryParse(_P_Str_Variable, out _Dbl_Variable))
                return _Dbl_Variable > 0;
            return false;
        }

        private bool _Mtd_ManejaUnidades(string _P_Str_Producto)
        {
            var _Str_Cadena = "SELECT cunidad2 FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "' AND ISNULL(cunidad2,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool _Mtd_CantidadesValidas(string _P_Str_Producto, string _P_Str_LoteId, string _P_Str_Cajas, string _P_Str_Unidades)
        {
            var _Str_Cadena = "SELECT ISNULL(cexisrealu1,0) AS cexisrealu1,ISNULL(cexisrealu2,0) AS cexisrealu2,ISNULL(cexiscomu1,0) AS cexiscomu1,ISNULL(cexiscomu2,0) AS cexiscomu2 from TPRODUCTOD WHERE cproducto='" + _P_Str_Producto + "' AND cidproductod='" + _P_Str_LoteId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_Cajas = 0;
                int _Int_Unidades = 0;
                int.TryParse(_P_Str_Cajas, out _Int_Cajas);
                int.TryParse(_P_Str_Unidades, out _Int_Unidades);
                int _Int_UniMinExis = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_P_Str_Producto, Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexisrealu1"].ToString()), Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexisrealu2"].ToString())));
                int _Int_UniMinComp = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_P_Str_Producto, Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexiscomu1"].ToString()), Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexiscomu2"].ToString())));
                int _Int_UnidadesAjus = Convert.ToInt32(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(_P_Str_Producto, _Int_Cajas, _Int_Unidades));
                if (_Int_UnidadesAjus > (_Int_UniMinExis - _Int_UniMinComp))
                {
                    MessageBox.Show("La existencias actuales no permite tal movimiento.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Error en la operación. No se obtuvieron las existencias.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (!_Mtd_MayorQueCero(_Txt_SalidaNetoCaja.Text))
            {
                MessageBox.Show("No se obtuvo el costo neto del producto a cambiar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!_Mtd_MayorQueCero(_Txt_EntradaNetoCaja.Text))
            {
                MessageBox.Show("No se obtuvo el costo neto del producto de reemplazo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!_Mtd_MayorQueCero(_Txt_Cajas.Text) && !_Mtd_MayorQueCero(_Txt_Unidades.Text))
            {
                MessageBox.Show("Debe introducir las cantidades para el movimiento.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_Mtd_MayorQueCero(_Txt_Unidades.Text) && !_Mtd_ManejaUnidades(_Txt_EntradaProducto.Text))
            {
                MessageBox.Show("El producto de reemplazo no se maneja en unidades.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_Mtd_MayorQueCero(_Txt_Unidades.Text))
            {
                //La cantidad de unidades máximas que se pueden ingresar será la del producto cuyas unidades máximas sea menor.
                int _Int_UnidadManejo = Convert.ToInt32(_Cls_VariosMetodos._Mtd_ProductoUndManejo2(_Txt_SalidaProducto.Text));
                int _Int_UnidadManejoEntrada = Convert.ToInt32(_Cls_VariosMetodos._Mtd_ProductoUndManejo2(_Txt_EntradaProducto.Text));
                if (_Int_UnidadManejo > _Int_UnidadManejoEntrada)
                    _Int_UnidadManejo = _Int_UnidadManejoEntrada;
                if (Convert.ToInt32(_Txt_Unidades.Text) >= _Int_UnidadManejo)
                {
                    MessageBox.Show("La cantidad de unidades debe ser inferior a " + _Int_UnidadManejo.ToString() + ".", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (!_Mtd_CantidadesValidas(_Txt_SalidaProducto.Text, ProductoSalidaLote, _Txt_Cajas.Text, _Txt_Unidades.Text))
                return;
            int _Int_Cajas = 0;
            int.TryParse(_Txt_Cajas.Text, out _Int_Cajas);
            ProductoCajas = _Int_Cajas;
            int _Int_Unidades = 0;
            int.TryParse(_Txt_Unidades.Text, out _Int_Unidades);
            ProductoUnidades = _Int_Unidades;
            this.DialogResult = DialogResult.OK;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void _Bt_BuscarProducto_Click(object sender, EventArgs e)
        {
            var _Str_SalidaProductoDesc = _Txt_SalidaProductoDesc.Text;
            Cursor = Cursors.WaitCursor;
            Frm_BusquedaProductoLote _Frm = new Frm_BusquedaProductoLote(true, _Str_Proveedor, _Str_NotaRecepcion, _Txt_SalidaProducto, _Txt_SalidaProductoDesc, _Txt_SalidaLote, _Txt_SalidaPmv);
            Cursor = Cursors.Default;
            _Frm.ShowDialog(this);
            if (_Frm.DialogResult == DialogResult.OK)
            {
                if (((Frm_AjusteIntegrado)Application.OpenForms["Frm_AjusteIntegrado"]).ProductosSalida.Contains(_Txt_SalidaProducto.Text))
                {
                    _Txt_SalidaProducto.Text = ProductoSalida;
                    _Txt_SalidaProductoDesc.Text = _Str_SalidaProductoDesc;
                    _Txt_SalidaLote.Text = ProductoSalidaLote;
                    _Txt_SalidaPmv.Text = ProductoSalidaPmv;
                    MessageBox.Show("El producto seleccionado ya ha sido ingresado en este ajuste. Por favor verifique!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ProductoSalida = _Txt_SalidaProducto.Text;
                    ProductoSalidaLote = _Txt_SalidaLote.Text;
                    ProductoSalidaPmv = _Txt_SalidaPmv.Text;
                    _Mtd_CargarSalida(_Txt_SalidaProducto.Text, _Txt_SalidaLote.Text, _Txt_SalidaPmv.Text);
                }
            }
        }

        private void _Bt_BuscarReemplazo_Click(object sender, EventArgs e)
        {
            var _Str_EntradaProductoDesc = _Txt_EntradaProductoDesc.Text;
            Cursor = Cursors.WaitCursor;
            Frm_BusquedaProductoLote _Frm = new Frm_BusquedaProductoLote(false, _Str_Proveedor, _Str_NotaRecepcion, _Txt_EntradaProducto, _Txt_EntradaProductoDesc, _Txt_EntradaLote, _Txt_EntradaPmv);
            Cursor = Cursors.Default;
            _Frm.ShowDialog(this);
            if (_Frm.DialogResult == DialogResult.OK)
            {
                if (((Frm_AjusteIntegrado)Application.OpenForms["Frm_AjusteIntegrado"]).ProductosEntrada.Contains(_Txt_EntradaProducto.Text))
                {
                    _Txt_EntradaProducto.Text = ProductoEntrada;
                    _Txt_EntradaProductoDesc.Text = _Str_EntradaProductoDesc;
                    _Txt_EntradaLote.Text = ProductoEntradaLote;
                    _Txt_EntradaPmv.Text = ProductoEntradaPmv;
                    MessageBox.Show("El producto seleccionado ya ha sido ingresado en este ajuste. Por favor verifique!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ProductoEntrada = _Txt_EntradaProducto.Text;
                    ProductoEntradaLote = _Txt_EntradaLote.Text;
                    ProductoEntradaPmv = _Txt_EntradaPmv.Text;
                    _Mtd_CargarEntrada(_Txt_EntradaProducto.Text, _Txt_EntradaLote.Text, _Txt_EntradaPmv.Text);
                }
            }
        }

        private void Frm_AjusteIntegradoP_Load(object sender, EventArgs e)
        {

        }

        private void _Txt_Cajas_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Cajas.Text)) { _Txt_Cajas.Text = ""; }
        }

        private void _Txt_Cajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Cajas, e, 8, 0);
        }

        private void _Txt_Unidades_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Unidades.Text)) { _Txt_Unidades.Text = ""; }
        }

        private void _Txt_Unidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Unidades, e, 8, 0);
        }
    }
}
