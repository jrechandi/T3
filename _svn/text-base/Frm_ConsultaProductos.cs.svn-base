using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ZedGraph;
namespace T3
{
    public partial class Frm_ConsultaProductos : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        #region Métodos para consultar el PMV y el premarcado.

        /// <summary>Método para obtener el precio máximo de venta.</summary>
        /// <param name="pCodigoProducto"></param>
        private void cargarPMV(string pCodigoProducto)
        {
            string sSQL;
            
            sSQL = "select case when cpreciomanejado = 1 then (convert(varchar, cpmvpi) + ' - ' + convert(varchar, cfechainicio, 103))";
	        sSQL += " when cpreciomanejado = 2 then (convert(varchar, cpmvmc) + ' - ' + convert(varchar, cfechainicio, 103))";
	        sSQL += " when cpreciomanejado = 3 then (convert(varchar, cpmvp) + ' - ' + convert(varchar, cfechainicio, 103))";
            sSQL += " when cpreciomanejado = 4 then (convert(varchar, cppm) + ' - ' + convert(varchar, cfechainicio, 103))";
            sSQL += " end as cprecio from THISTORICOPMV where cproducto='" + pCodigoProducto + "' order by cpreciomanejado asc;";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            txtPMVPI.Text = "";
            txtPMVMC.Text = "";
            txtPMVP.Text = "";
            txtPPM.Text = "";

            if (dsResultado.Tables[0].Rows.Count == 3)
            {
                txtPMVPI.Text = dsResultado.Tables[0].Rows[0]["cprecio"].ToString().Replace('.', ',');
                txtPMVMC.Text = dsResultado.Tables[0].Rows[1]["cprecio"].ToString().Replace('.', ',');
                txtPMVP.Text = dsResultado.Tables[0].Rows[2]["cprecio"].ToString().Replace('.', ',');
            }
            else if (dsResultado.Tables[0].Rows.Count == 1)
            {
                txtPPM.Text = dsResultado.Tables[0].Rows[0]["cprecio"].ToString().Replace('.', ',');
            }
        }

        #endregion

        public Frm_ConsultaProductos()
        {
            InitializeComponent();
            string _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción, dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND 5<4";
            _Mtd_Actualizar(_Str_Cadena);
            _Mtd_Cargar_Proveedor();
            //_Mtd_Cargar_Marca();
            _Mtd_Cargar_Unidad1();
            _Mtd_Cargar_Unidad2();
            _Mtd_Configurar_Controles(this);
        }
        private void _Mtd_Cargar_Proveedor()
        {
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) ORDER BY TPROVEEDOR.c_nomb_abreviado";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname " +
"FROM TGRUPPROM INNER JOIN " +
"TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete " +
"WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0)";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor,string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname " +
"FROM TSUBGRUPOM INNER JOIN " +
"TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
"TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete " +
"WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "')";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TMARCASM.cmarca, TMARCASM.cname " +
"FROM TMARCASM INNER JOIN " +
"TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca " +
"WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '"+_P_Str_Grupo+"') AND (TMARCAS.cproveedor = '"+_P_Str_Proveedor+"')";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
        }
        private void _Mtd_Cargar_Unidad1()
        {
            string _Str_Cadena = "SELECT cunidadman, cname FROM TUNIMAN WHERE (cdelete = 0)";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Unidad1, _Str_Cadena);
        }
        private void _Mtd_Cargar_Unidad2()
        {
            string _Str_Cadena = "SELECT cunidadman, cname FROM TUNIMAN WHERE (cdelete = 0)";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Unidad2, _Str_Cadena);
        }

        private void _Mtd_Buscar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "";
            bool _Bol_Entrada = false;
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "' and csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            else if (_Cmb_Grupo.SelectedIndex>0)
            { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            else if (_Cmb_Subgrupo.SelectedIndex < 1 & _Cmb_Grupo.SelectedIndex < 1 & _Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            if (_Bol_Entrada)
            {
                if (_Cmb_Marca.SelectedIndex > 0)
                { _Str_Cadena = _Str_Cadena + " and cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            }
            else
            {
                if (_Cmb_Marca.SelectedIndex > 0)
                { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            }
            if (_Bol_Entrada)
            {
                if (_Cmb_Unidad1.SelectedIndex > 0 & _Cmb_Unidad2.SelectedIndex < 1)
                { _Str_Cadena = _Str_Cadena + " and cunidadma1='"+_Cmb_Unidad1.SelectedValue.ToString()+"'"; }
                else if (_Cmb_Unidad1.SelectedIndex < 1 & _Cmb_Unidad2.SelectedIndex > 0)
                { _Str_Cadena = _Str_Cadena + " and cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; }
                else if (_Cmb_Unidad1.SelectedIndex > 0 & _Cmb_Unidad2.SelectedIndex > 0)
                { _Str_Cadena = _Str_Cadena + " and cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "' and cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; }
                if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and ccomision='1'"; }
                else if (_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and ccomision='1' and cprodregular is not null"; }
                else if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and ccomision='1' and cprodregular is null"; }
                else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and cprodregular is not null"; }
                else if (!_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and cprodregular is null"; }
                else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and 0=0"; }
                if (_Txt_Buscar.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                if (_Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                if (_Txt_CodigoIn.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                if (_Txt_CodCorrugado.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and ccodcorrugado like('%" + _Txt_CodCorrugado.Text.Trim() + "%')"; }
                if (_Rb_Activo_Bus.Checked)
                { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                else if (_Rb_Inactivo_Bus.Checked)
                { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
            }
            else
            {
                _Bol_Entrada = false;
                if (_Cmb_Unidad1.SelectedIndex > 0 & _Cmb_Unidad2.SelectedIndex < 1)
                { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                else if (_Cmb_Unidad1.SelectedIndex < 1 & _Cmb_Unidad2.SelectedIndex > 0)
                { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                else if (_Cmb_Unidad1.SelectedIndex > 0 & _Cmb_Unidad2.SelectedIndex > 0)
                { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "' and cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                if (_Bol_Entrada)
                {
                    if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and ccomision='1'"; }
                    else if (_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and ccomision='1' and cprodregular is not null"; }
                    else if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and ccomision='1' and cprodregular is null"; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and cprodregular is not null"; }
                    else if (!_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and cprodregular is null"; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and 0=0"; }
                    if (_Txt_Buscar.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                    if (_Txt_CodigoEs.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                    if (_Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                    if (_Txt_CodCorrugado.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and ccodcorrugado like('%" + _Txt_CodCorrugado.Text.Trim() + "%')"; }
                    if (_Rb_Activo_Bus.Checked)
                    { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                    else if (_Rb_Inactivo_Bus.Checked)
                    { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
                }
                else
                {
                    _Bol_Entrada = false;
                    if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND ccomision='1'"; _Bol_Entrada = true; }
                    else if (_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND ccomision='1' and cprodregular is not null"; _Bol_Entrada = true; }
                    else if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND comision='1' and cprodregular is null"; _Bol_Entrada = true; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cprodregular is not null"; _Bol_Entrada = true; }
                    else if (!_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cprodregular is null"; _Bol_Entrada = true; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND 0=0"; _Bol_Entrada = true; }
                    if (_Bol_Entrada)
                    {
                        if (_Txt_Buscar.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                        if (_Txt_CodigoEs.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                        if (_Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                        if (_Txt_CodCorrugado.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and ccodcorrugado like('%" + _Txt_CodCorrugado.Text.Trim() + "%')"; }
                        if (_Rb_Activo_Bus.Checked)
                        { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                        else if (_Rb_Inactivo_Bus.Checked)
                        { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
                    }
                    else
                    {
                        _Bol_Entrada = false;
                        if (_Txt_CodCorrugado.Text.Trim().Length > 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND ccodcorrugado like('%" + _Txt_CodCorrugado.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%') and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cnamefc like('%" + _Txt_Buscar.Text.Trim() + "%') and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; _Bol_Entrada = true; }
                        if (_Bol_Entrada)
                        {
                            if (_Rb_Activo_Bus.Checked)
                            { _Str_Cadena = _Str_Cadena + " and cactivate ='1'"; }
                            else if (_Rb_Inactivo_Bus.Checked)
                            { _Str_Cadena = _Str_Cadena + " and cactivate ='0'"; }
                        }
                        else
                        {
                            if (_Rb_Activo_Bus.Checked)
                            { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cactivate='1'"; }
                            else if (_Rb_Inactivo_Bus.Checked)
                            { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND cactivate='0'"; }
                            else if (_Rbt_Todos_Bus.Checked)
                            { _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción,dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "'"; }
                        }
                    }
                }
            }
            if (_Str_Cadena.Length > 0)
            {
                _Str_Cadena = _Str_Cadena + " ORDER BY cproveedor,cgrupo,csku,csubgrupo";
                _Mtd_Actualizar(_Str_Cadena);
                Cursor = Cursors.Default;
                if (_Dg_Grid.Rows.Count == 0)
                { MessageBox.Show("La consulta no devolvio ningún registro","Información",MessageBoxButtons.OK,MessageBoxIcon.Asterisk); }
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Debe especificar algún criterio de busqueda","Información",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }
        private void _Mtd_Actualizar(string _P_Str_Cadena)
        {
            DataSet _Ds;
            if (_Mtd_UsuarioLimitado())
            {
                _P_Str_Cadena = _P_Str_Cadena.Replace(",dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado]", "");
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
                _Dg_Grid.DataSource = _Ds.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
                _Dg_Grid.DataSource = _Ds.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //___________________________________
        }
        private void _Mtd_Configurar_Controles(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Configurar_Controles(_Ctrl);
                }
                else
                {
                    if (_Ctrl.GetType() == typeof(CheckBox) | _Ctrl.GetType() == typeof(RadioButton))
                    {
                        if (_Ctrl.Name != "_Chbox_Proveedores" & _Ctrl.Name != "_Chbox_Grupos" & _Ctrl.Name != "_Chbox_Subgrupos" & _Ctrl.Name != "_Chbox_Marcas" & _Ctrl.Name != "_Chbox_Comisionables" & _Ctrl.Name != "_Chbox_Unidad1" & _Ctrl.Name != "_Chbox_Unidad2" & _Ctrl.Name != "_Chbox_Promocional" & _Ctrl.Name != "_Chbox_Regular" & _Ctrl.Name != "_Rbt_Compras" & _Ctrl.Name != "_Rbt_Ventas" & _Ctrl.Name != "_Rb_Activo_Bus" & _Ctrl.Name != "_Rb_Inactivo_Bus" & _Ctrl.Name != "_Rbt_Todos_Bus")
                        { _Ctrl.Enabled = false; }
                    }
                    else if (_Ctrl.GetType() == typeof(TextBox))
                    {
                        if (_Ctrl.Name != "_Txt_CodigoEs" & _Ctrl.Name != "_Txt_CodigoIn" & _Ctrl.Name != "_Txt_Buscar" & _Ctrl.Name != "_Txt_CostoNetoP" & _Ctrl.Name != "_Txt_CodCorrugado")
                        { ((TextBox)_Ctrl).ReadOnly = true; }
                    }
                }
            }
        }
        private void _Mtd_Inicializar_Controles(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Inicializar_Controles(_Ctrl);
                }
                else
                {
                    if (_Ctrl.GetType() == typeof(CheckBox) | _Ctrl.GetType() == typeof(RadioButton))
                    {
                        if (_Ctrl.Name != "_Chbox_Proveedores" & _Ctrl.Name != "_Chbox_Grupos" & _Ctrl.Name != "_Chbox_Subgrupos" & _Ctrl.Name != "_Chbox_Marcas" & _Ctrl.Name != "_Chbox_Comisionables" & _Ctrl.Name != "_Chbox_Unidad1" & _Ctrl.Name != "_Chbox_Unidad2" & _Ctrl.Name != "_Chbox_Promocional" & _Ctrl.Name != "_Chbox_Regular" & _Ctrl.Name != "_Rb_Activo_Bus" & _Ctrl.Name != "_Rb_Inactivo_Bus" & _Ctrl.Name != "_Rbt_Todos_Bus")
                        { 
                            if (_Ctrl.GetType() == typeof(CheckBox))
                            { ((CheckBox)_Ctrl).Checked=false;}
                            else
                            {((RadioButton)_Ctrl).Checked=false;}
                        }
                    }
                    else if (_Ctrl.GetType() == typeof(TextBox))
                    {
                        if (_Ctrl.Name != "_Txt_CodigoEs" & _Ctrl.Name != "_Txt_CodigoIn" & _Ctrl.Name != "_Txt_Buscar")
                        { ((TextBox)_Ctrl).Text = ""; }
                    }
                }
            }
        }
        private bool _Mtd_UsuarioLimitado()
        {
            return _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONS_PROD_LIMIT");
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
        private void Frm_Consulta_Productos_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(_Pnl_Producto);
            _Mtd_Texto_Formato(_Txt_Medidas_U_Profundidad);
            _Mtd_Texto_Formato(_Txt_Medidas_U_Alto);
            _Mtd_Texto_Formato(_Txt_Corrugado_U_Profundidad);
            _Mtd_Texto_Formato(_Txt_Corrugado_U_Ancho);
            _Mtd_Texto_Formato(_Txt_Corrugado_U_Alto);
            _Mtd_Texto_Formato(_Txt_Corrugado_U_Peso);
            _Mtd_Texto_Formato(_Txt_Medidas_U_Ancho);
            _Mtd_Texto_Formato(_Txt_Medidas_U_Peso);
            _Pnl_Producto.Left = (this.Width / 2) - (_Pnl_Producto.Width / 2);
            _Pnl_Producto.Top = (this.Height / 2) - (_Pnl_Producto.Height / 2);
            if (_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIF_COST_NETO"))
            {
                _Dg_Grid.ContextMenuStrip = _Cntx_ModifCostNet;
            }
        }
        bool _Bol_Sw = false;
        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString()); _Chbox_Proveedores.Checked = true; _Cmb_Grupo.Enabled = true; }
            else
            { 
                _Cmb_Grupo.DataSource = null; _Cmb_Grupo.Enabled = false; _Chbox_Proveedores.Checked = false; _Cmb_Proveedor.Enabled = true;
                if (_Bol_Sw)
                {
                    if (_Chbox_Proveedores.Checked)
                    {
                        _Cmb_Proveedor.Enabled = true;
                    }
                    else
                    { _Cmb_Proveedor.Enabled = false;  }
                }
                _Bol_Sw = true;
            }
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                _Chbox_Grupos.Checked = true;
                _Cmb_Subgrupo.Enabled = true;
                _Cmb_Marca.Enabled = true;
            }
            else
            {
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Marca.DataSource = null;
                _Chbox_Grupos.Checked = false;
                _Cmb_Subgrupo.Enabled = false;
                _Cmb_Marca.Enabled = false;
                if (_Chbox_Grupos.Checked)
                {
                    _Cmb_Grupo.Enabled = true;
                }
                else
                { _Cmb_Grupo.Enabled = false; }
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Mtd_Buscar();
        }

        private void _Chbox_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Proveedores.Checked)
            { _Cmb_Proveedor.Enabled = true; }
            else
            {
                _Cmb_Proveedor.Enabled = false;
                if (_Cmb_Proveedor.DataSource != null)
                {
                    _Cmb_Proveedor.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Proveedor.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Grupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Grupos.Checked)
            { _Cmb_Grupo.Enabled = true; }
            else
            { 
                _Cmb_Grupo.Enabled = false;
                if (_Cmb_Grupo.DataSource != null)
                {
                    _Cmb_Grupo.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Grupo.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Subgrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Subgrupos.Checked)
            { _Cmb_Subgrupo.Enabled = true; }
            else
            { 
                _Cmb_Subgrupo.Enabled = false;
                if (_Cmb_Subgrupo.DataSource != null)
                {
                    _Cmb_Subgrupo.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Subgrupo.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Marcas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Marcas.Checked)
            { _Cmb_Marca.Enabled = true; }
            else
            { 
                _Cmb_Marca.Enabled = false;
                if (_Cmb_Marca.DataSource != null)
                {
                    _Cmb_Marca.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Marca.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Unidad1_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Unidad1.Checked)
            { _Cmb_Unidad1.Enabled = true; }
            else
            { 
                _Cmb_Unidad1.Enabled = false;
                if (_Cmb_Unidad1.DataSource != null)
                {
                    _Cmb_Unidad1.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Unidad1.SelectedIndex = -1;
                }
            }
        }

        private void _Chbox_Unidad2_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Unidad2.Checked)
            { _Cmb_Unidad2.Enabled = true; }
            else
            { 
                _Cmb_Unidad2.Enabled = false;
                if (_Cmb_Unidad2.DataSource != null)
                {
                    _Cmb_Unidad2.SelectedIndex = 0;
                }
                else
                {
                    _Cmb_Unidad2.SelectedIndex = -1;
                }
            }
        }
        private void _Mtd_Restablecer()
        {
            _Txt_Buscar.Text = "";
            _Txt_CodigoEs.Text = "";
            _Txt_CodigoIn.Text = "";
            _Txt_CodCorrugado.Text = "";
            _Chbox_Comisionables.Checked = false;
            _Rb_Activo_Bus.Checked = true;
            _Chbox_Promocional.Checked = false;
            _Chbox_Regular.Checked = false;
            _Chbox_Proveedores.Checked = false;
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
            _Chbox_Unidad1.Checked = false;
            _Chbox_Unidad2.Checked = false;
            string _Str_Cadena = "Select cproducto as Producto,cnamefc as Descripción, dbo.Fnc_Formatear(ccostobruto_u1) as [Costo Bruto],dbo.Fnc_Formatear(ccostoneto_u1) as [Costo Neto],cexisrealu1 as [Cajas existencia],cexisrealu2 as [Unidades existencia],cexisllegar1 as [Cajas por llegar],cexisllegar2 as [Unidades por llegar],cexiscomu1 as [Cajas comprometidas],cexiscomu2 as [Unidades comprometidas],Empaques as [Emp. Backorder],Unidades as [Und. Backorder],cexismmeu1 AS [Emp. Mal Estado],cexismmeu2 AS [Und. Mal Estado] from VST_PRODUCTOS_B where ccompanyprov = '" + Frm_Padre._Str_Comp + "' AND 5<4";
            _Mtd_Actualizar(_Str_Cadena);
            _Cmb_Proveedor.Enabled = true;
        }
        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Inicializar_Controles(this);
            _Mtd_Restablecer();
        }

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Chbox_Subgrupos.Checked = true; }
            else
            { _Chbox_Subgrupos.Checked = false; }
        }

        private void _Cmb_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Chbox_Marcas.Checked = true; }
            else
            { _Chbox_Marcas.Checked = false; }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void _Lbl_Label_Click(object sender, EventArgs e)
        {

        }

        private void colorProgressBar1_Click(object sender, EventArgs e)
        {

        }

        //private void _Bt_Descripcion_Click(object sender, EventArgs e)
        //{
        //    if (_Pnl_Descripcion.Height == 0)
        //    { _Pnl_Descripcion.Height = 151; }
        //    else
        //    { _Pnl_Descripcion.Height = 0; }
        //}

        //private void _Bt_Unidad_Click(object sender, EventArgs e)
        //{
        //    if (_Pnl_Unidad.Height == 28)
        //    { _Pnl_Unidad.Height = 544; }
        //    else
        //    { _Pnl_Unidad.Height = 28; }
        //}

        //private void _Bt_Lista_Click(object sender, EventArgs e)
        //{
        //    if (_Pnl_Lista.Height == 28)
        //    { _Pnl_Lista.Height = 228; }
        //    else
        //    { _Pnl_Lista.Height = 28; }
        //}

        //private void _Bt_Costo_Click(object sender, EventArgs e)
        //{
        //    if (_Pnl_Costo.Height == 28)
        //    { _Pnl_Costo.Height = 376; }
        //    else
        //    { _Pnl_Costo.Height = 28; }
        //}

        //private void _Bt_Impuesto_Click(object sender, EventArgs e)
        //{
        //    if (_Pnl_Impuesto.Height == 28)
        //    { _Pnl_Impuesto.Height = 236; }
        //    else
        //    { _Pnl_Impuesto.Height = 28; }
        //}
        private void _Mtd_ColocarListaPrecio(string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT ISNULL(clistprecio1,0),ISNULL(clistprecio2,0),ISNULL(clistprecio3,0),ISNULL(clistprecio4,0),ISNULL(clistprecio5,0) FROM TLISTAPRECIOCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Lista_Precio1.Text = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Txt_Lista_Precio2.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                _Txt_Lista_Precio3.Text = _Ds.Tables[0].Rows[0][2].ToString().Trim();
                _Txt_Lista_Precio4.Text = _Ds.Tables[0].Rows[0][3].ToString().Trim();
                _Txt_Lista_Precio5.Text = _Ds.Tables[0].Rows[0][4].ToString().Trim();
            }
            else
            {
                _Txt_Lista_Precio1.Text = "0";
                _Txt_Lista_Precio2.Text = "0";
                _Txt_Lista_Precio3.Text = "0";
                _Txt_Lista_Precio4.Text = "0";
                _Txt_Lista_Precio5.Text = "0";
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                zg1.GraphPane.CurveList.Clear();
                string _Str_Cadena = "Select cproducto,produc_descrip,cactivate,cproveedor,cgrupo,csubgrupo,cmarca,ccodeold,cfechaini,cprodregular,ccodfabrica,ccodcorrugado,ccodunidad,cnamei,cpresentacion,cunidadma1,ccontenidoma1,cunidadma2,ccontenidoma2,cunidad2,cunidadme,ccontenidome,caltura,cancho,cprofundidad,cpesounid2,calturac,canchoc,cprofundidadc,cpesounid1,cu1xpaleta,cu1xcamada,dbo.Fnc_Formatear(cpreciolista) as cpreciolista,dbo.Fnc_Formatear(cdescondp1) as cdescondp1,dbo.Fnc_Formatear(cdescondp2) as cdescondp2,dbo.Fnc_Formatear(cdescondp3) as cdescondp3,dbo.Fnc_Formatear(cdescondp4) as cdescondp4,dbo.Fnc_Formatear(cdescondp5) as cdescondp5,dbo.Fnc_Formatear(ccostobruto_u1) as ccostobruto_u1,dbo.Fnc_Formatear(ccostoneto_u1) as ccostoneto_u1,dbo.Fnc_Formatear(ccostobruto_u2) as ccostobruto_u2,dbo.Fnc_Formatear(ccostoneto_u2) as ccostoneto_u2,dbo.Fnc_Formatear(cpreciosuge) as cpreciosuge,clistprecio1,clistprecio2,clistprecio3,clistprecio4,clistprecio5,ccomision,cimpuesto1,ctax1,ctax2,ctax3,ctax4,ctax5,cexisrealu1,cexisrealu2,cexisllegar1,cexisllegar2,cexiscomu1,cexiscomu2,cexisultcomp_u1,cfecultcomp_u1,cestratificacion,cvtadelmes,cfecvtapmes,ccompdelmes,cfeccompmes,cexismmeu1,cexismmeu2 from VST_PRODUCTOS_A where cproducto='" + _Dg_Grid.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                DataSet _Ds=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    _Txt_CodProductoArriba.Text = _Row["cproducto"].ToString();
                    _Txt_DesProducto.Text = _Row["produc_descrip"].ToString();
                    if (_Row["cactivate"].ToString().Trim() == "1")
                    { _Rbt_Si_Arriba.Checked = true; }
                    else
                    { _Rbt_No_Arriba.Checked = true; }
                    _Str_Cadena = "Select c_nomb_comer from TPROVEEDOR where cproveedor='" + _Row["cproveedor"].ToString() + "'";
                    DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {_Txt_DesProveedor.Text=_Ds2.Tables[0].Rows[0][0].ToString();}
                    _Str_Cadena = "SELECT TGRUPPROM.cname " +
"FROM TGRUPPROM INNER JOIN " +
"TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete " +
"WHERE (TGRUPPROD.cproveedor = '" + _Row["cproveedor"].ToString() + "') AND (TGRUPPROM.cdelete = 0) and (TGRUPPROM.ccodgrupop='" + _Row["cgrupo"].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Grupo.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Str_Cadena = "SELECT TSUBGRUPOM.cname " +
"FROM TSUBGRUPOM INNER JOIN " +
"TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
"TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete " +
"WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _Row["cproveedor"].ToString() + "') AND (TSUBGRUPOD.ccodgrupop = '" + _Row["cgrupo"].ToString() + "') and (TSUBGRUPOM.ccodsubgrup='" + _Row["csubgrupo"].ToString() + "')";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Subgrupo.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Str_Cadena = "SELECT cname FROM TMARCASM WHERE  cmarca='" + _Row["cmarca"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Marca.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    //_Txt_Sku.Text = _Row["csku"].ToString();
                    //_Txt_CodProductoAbajo.Text = _Row["cproducto"].ToString();
                    _Txt_CodAnterior.Text = _Row["ccodeold"].ToString();
                    _Txt_Fecha.Text = _Row["cfechaini"].ToString();
                    if (_Row["cprodregular"].ToString().Trim().Length > 0)
                    { _Gr_Primero.Enabled = true; }
                    else
                    { _Gr_Primero.Enabled = false; }
                    _Txt_Cod_Regular.Text = _Row["cprodregular"].ToString();
                    _Str_Cadena = "Select produc_descrip from VST_PRODUCTOS_A where cproducto='" + _Row["cprodregular"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Regular.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Txt_Cod_Interno.Text = _Row["ccodfabrica"].ToString();
                    _Txt_Barras_Corrugado.Text = _Row["ccodcorrugado"].ToString();
                    _Txt_Barras_Unidad.Text = _Row["ccodunidad"].ToString();
                    _Txt_Des_Proveedor_Abajo.Text = _Row["produc_descrip"].ToString();
                    _Txt_Informacion.Text = _Row["cnamei"].ToString();
                    _Txt_Presentacion.Text = _Row["cpresentacion"].ToString();
                    _Str_Cadena = "SELECT cname FROM TUNIMAN WHERE cunidadman='" + _Row["cunidadma1"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Unidad_Manejo1.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Txt_Contenido_Unidad1.Text = _Row["ccontenidoma1"].ToString();
                    _Str_Cadena = "SELECT cname FROM TUNIMEDI WHERE cunidadmed='" + _Row["cunidadme"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Unidad_Med_X_Unidad.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Txt_Contenido.Text = _Row["ccontenidome"].ToString();
                    _Str_Cadena = "SELECT cname FROM TUNIMAN WHERE cunidadman='" + _Row["cunidadma2"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Unidad_Manejo2.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Txt_Contenido_Unidad2.Text = _Row["ccontenidoma2"].ToString();
                    _Txt_Medidas_U_Alto.Text = _Row["caltura"].ToString();
                    _Txt_Medidas_U_Ancho.Text = _Row["cancho"].ToString();
                    _Txt_Medidas_U_Profundidad.Text = _Row["cprofundidad"].ToString();
                    _Txt_Medidas_U_Peso.Text = _Row["cpesounid1"].ToString();
                    _Txt_Corrugado_U_Alto.Text = _Row["calturac"].ToString();
                    _Txt_Corrugado_U_Ancho.Text = _Row["canchoc"].ToString();
                    _Txt_Corrugado_U_Profundidad.Text = _Row["cprofundidadc"].ToString();
                    _Txt_Corrugado_U_Peso.Text = _Row["cpesounid2"].ToString();
                    //_Txt_Cajas_Paleta.Text = _Row["cu1xpaleta"].ToString();
                    //_Txt_Cajas_Camada.Text = _Row["cu1xcamada"].ToString();
                    _Txt_Precio_Lista.Text = _Row["cpreciolista"].ToString();
                    _Txt_Descuento1.Text = _Row["cdescondp1"].ToString();
                    _Txt_Descuento2.Text = _Row["cdescondp2"].ToString();
                    _Txt_Descuento3.Text = _Row["cdescondp3"].ToString();
                    _Txt_Descuento4.Text = _Row["cdescondp4"].ToString();
                    _Txt_Descuento5.Text = _Row["cdescondp5"].ToString();
                    _Txt_Costo_Bruto1.Text = _Row["ccostobruto_u1"].ToString();
                    //_Txt_Costo_Bruto2.Text = _Row["ccostobruto_u2"].ToString();
                    _Txt_Costo_Bruto2.Text = _Mtd_CalcularCostoBruto(_Row["ccostobruto_u1"].ToString(), _Row["ccontenidoma1"].ToString(), _Row["ccontenidoma2"].ToString());
                    _Txt_Costo_Neto1.Text = _Row["ccostoneto_u1"].ToString();
                    _Txt_Costo_Neto2.Text = _Row["ccostoneto_u2"].ToString();
                    _Txt_Precio_Sugerido.Text = _Row["cpreciosuge"].ToString();
                    _Mtd_ColocarListaPrecio(_Row["cproducto"].ToString().Trim());
                    if (_Row["ccomision"].ToString().Trim() == "1")
                    { _Chbox_Comicionable.Checked = true; }
                    else
                    { _Chbox_Comicionable.Checked = false; }
                    if (_Row["cimpuesto1"].ToString().Trim() == "1")
                    { _Chbox_Impuesto.Checked = true; }
                    else
                    { _Chbox_Impuesto.Checked = false; }
                    _Str_Cadena = "Select cpercent from TTAX where ctax='" + _Row["ctax1"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Impuesto1.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Str_Cadena = "Select cpercent from TTAX where ctax='" + _Row["ctax2"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Impuesto2.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Str_Cadena = "Select cpercent from TTAX where ctax='" + _Row["ctax3"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Impuesto3.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Str_Cadena = "Select cpercent from TTAX where ctax='" + _Row["ctax4"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Impuesto4.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Str_Cadena = "Select cpercent from TTAX where ctax='" + _Row["ctax5"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    { _Txt_Impuesto5.Text = _Ds2.Tables[0].Rows[0][0].ToString(); }
                    _Txt_Exis_En_Cajas.Text = _Row["cexisrealu1"].ToString();
                    _Txt_Exis_En_Unidades.Text = _Row["cexisrealu2"].ToString();
                    _Txt_Exis_Por_Cajas.Text = _Row["cexisllegar1"].ToString();
                    _Txt_Exis_Por_Unidades.Text = _Row["cexisllegar2"].ToString();
                    _Txt_Exis_Comp_Cajas.Text = _Row["cexiscomu1"].ToString();
                    _Txt_Exis_Comp_Unidades.Text = _Row["cexiscomu2"].ToString();
                    _Txt_Exis_Ultima.Text = _Row["cexisultcomp_u1"].ToString();
                    _Txt_CajasMalEstado.Text = _Row["cexismmeu1"].ToString();
                    _Txt_UndMalEstado.Text = _Row["cexismmeu2"].ToString();
                    if (_Row["cfecultcomp_u1"] != System.DBNull.Value)
                    { _Txt_Fecha_Ultima.Text =Convert.ToDateTime(_Row["cfecultcomp_u1"].ToString()).ToString("dd/MM/yyyy"); }
                    _Txt_Venta_Mes.Text = _Row["cvtadelmes"].ToString();
                    if (_Row["cfecvtapmes"] != System.DBNull.Value)
                    { _Txt_Fecha_Venta.Text = Convert.ToDateTime(_Row["cfecvtapmes"].ToString()).ToString("dd/MM/yyyy"); }
                    _Txt_Compra_Mes.Text = _Row["ccompdelmes"].ToString();
                    if (_Row["cfeccompmes"] != System.DBNull.Value)
                    { _Txt_Fecha_Compra.Text = Convert.ToDateTime(_Row["cfeccompmes"].ToString()).ToString("dd/MM/yyyy"); }
                    _Txt_Estratificacion.Text = _Row["cestratificacion"].ToString();
                    _Rbt_Ventas.Checked = true;
                    _Mtd_Crear_Tabla_Ventas(_Row["cproducto"].ToString().Trim());
                    _Tb_Tab.SelectedIndex = 1;
                }
            }
            cargarPMV(_Txt_CodProductoArriba.Text);
            Cursor = Cursors.Default;
        }
        private string _Mtd_CalcularCostoBruto(string _P_Str_CostoBrutoU1, string _P_Str_ContenidomaU1, string _P_Str_ContenidomaU2)
        {
            double _Dbl_ccostobruto_u1 = 0;
            double _Dbl_ccontenidoma1 = 0;
            double _Dbl_ccontenidoma2 = 0;
            if (_P_Str_CostoBrutoU1.Trim().Length>0)
            { _Dbl_ccostobruto_u1 = Convert.ToDouble(_P_Str_CostoBrutoU1); }
            else { _Dbl_ccostobruto_u1 = 0; }

            if (_P_Str_ContenidomaU1.Trim().Length > 0)
            { _Dbl_ccontenidoma1 = Convert.ToDouble(_P_Str_ContenidomaU1); }
            else { _Dbl_ccontenidoma1 = 0; }

            if (_P_Str_ContenidomaU2.Trim().Length > 0)
            { _Dbl_ccontenidoma2 = Convert.ToDouble(_P_Str_ContenidomaU2); }
            else { _Dbl_ccontenidoma2 = 0; }

            return Convert.ToDouble(_Dbl_ccostobruto_u1 * (_Dbl_ccontenidoma2 / _Dbl_ccontenidoma1)).ToString("#,##0.00");
        }
        int _Int_Index = 0;
        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 1 & _Dg_Grid.Rows.Count==0)
            { _Tb_Tab.SelectedIndex = 0; }
            else if ((_Tb_Tab.SelectedIndex == 1 | _Tb_Tab.SelectedIndex == 2) & _Txt_CodProductoArriba.Text.Trim().Length == 0)
            { _Tb_Tab.SelectedIndex = _Int_Index; }
            _Int_Index = _Tb_Tab.SelectedIndex;
        }
        private void _Mtd_Crear_Tabla_Compras(string _P_Str_Producto)
        {
            int max = 12;
            int[] _Int_Intervalos = new int[max];
            string[] _Str_Meses = new string[max];// { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            int j = 0;
            for (int i = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + 1; i <= max; i++)
            {
                _Int_Intervalos[j] = i;
                if (i == 1)
                { _Str_Meses[j] = "Enero "; }
                if (i == 2)
                { _Str_Meses[j] = "Febrero "; }
                if (i == 3)
                { _Str_Meses[j] = "Marzo "; }
                if (i == 4)
                { _Str_Meses[j] = "Abril "; }
                if (i == 5)
                { _Str_Meses[j] = "Mayo "; }
                if (i == 6)
                { _Str_Meses[j] = "Junio "; }
                if (i == 7)
                { _Str_Meses[j] = "Julio "; }
                if (i == 8)
                { _Str_Meses[j] = "Agosto "; }
                if (i == 9)
                { _Str_Meses[j] = "Septiembre "; }
                if (i == 10)
                { _Str_Meses[j] = "Octubre "; }
                if (i == 11)
                { _Str_Meses[j] = "Noviembre "; }
                if (i == 12)
                { _Str_Meses[j] = "Diciembre "; }
                _Str_Meses[j] += (CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year - 1).ToString();
                j++;
            }
            for (int i = 1; i <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month; i++)
            {
                _Int_Intervalos[j] = i;
                if (i == 1)
                { _Str_Meses[j] = "Enero "; }
                if (i == 2)
                { _Str_Meses[j] = "Febrero "; }
                if (i == 3)
                { _Str_Meses[j] = "Marzo "; }
                if (i == 4)
                { _Str_Meses[j] = "Abril "; }
                if (i == 5)
                { _Str_Meses[j] = "Mayo "; }
                if (i == 6)
                { _Str_Meses[j] = "Junio "; }
                if (i == 7)
                { _Str_Meses[j] = "Julio "; }
                if (i == 8)
                { _Str_Meses[j] = "Agosto "; }
                if (i == 9)
                { _Str_Meses[j] = "Septiembre "; }
                if (i == 10)
                { _Str_Meses[j] = "Octubre "; }
                if (i == 11)
                { _Str_Meses[j] = "Noviembre "; }
                if (i == 12)
                { _Str_Meses[j] = "Diciembre "; }
                _Str_Meses[j] += CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString();
                j++;
            }

            double[] _Dbl_CajasMes = new double[max];
            zg1.GraphPane.CurveList.Clear();
            for (int _Int_I = 1; _Int_I <= max; _Int_I++)
            {
                string _Str_Cadena = "SELECT SUM(TNOTARECEPD.cempaques) AS Suma " +
"FROM TNOTARECEPC INNER JOIN " +
"TNOTARECEPD ON TNOTARECEPC.cgroupcomp = TNOTARECEPD.cgroupcomp AND TNOTARECEPC.ccompany = TNOTARECEPD.ccompany AND " +
"TNOTARECEPC.cidnotrecepc = TNOTARECEPD.cidnotrecepc AND TNOTARECEPC.cidrecepcion = TNOTARECEPD.cidrecepcion " +
"WHERE  (MONTH(TNOTARECEPC.cfechanotrecep) = '" + _Int_Intervalos[_Int_I - 1].ToString() + "') AND (YEAR(TNOTARECEPC.cfechanotrecep) = '" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "') AND (TNOTARECEPD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND " +
"(TNOTARECEPD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTARECEPD.cproducto = '" + _P_Str_Producto + "') AND (TNOTARECEPC.cimpreso='1') AND (TNOTARECEPC.cidcomprob!='0')" +
"GROUP BY TNOTARECEPD.cempaques";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Dbl_CajasMes[_Int_I - 1] = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        _Dbl_CajasMes[_Int_I - 1] = 0;
                    }
                }
                else
                {
                    _Dbl_CajasMes[_Int_I - 1] = 0;
                }
            }
//            for (int _Int_I = 1; _Int_I <= max; _Int_I++)
//            {
//                string _Str_Cadena = "SELECT SUM(TNOTARECEPD.cempaques) AS Suma " +
//"FROM TNOTARECEPC INNER JOIN " +
//"TNOTARECEPD ON TNOTARECEPC.cgroupcomp = TNOTARECEPD.cgroupcomp AND TNOTARECEPC.ccompany = TNOTARECEPD.ccompany AND " +
//"TNOTARECEPC.cidnotrecepc = TNOTARECEPD.cidnotrecepc AND TNOTARECEPC.cidrecepcion = TNOTARECEPD.cidrecepcion " +
//"WHERE  (MONTH(TNOTARECEPC.cfechanotrecep) = '" + _Int_I.ToString() + "') AND (YEAR(TNOTARECEPC.cfechanotrecep) = '" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "') AND (TNOTARECEPD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND " +
//"(TNOTARECEPD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTARECEPD.cproducto = '" + _P_Str_Producto + "') AND (TNOTARECEPC.cimpreso='1') AND (TNOTARECEPC.cidcomprob!='0')" +
//"GROUP BY TNOTARECEPD.cempaques";
//                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
//                if (_Ds.Tables[0].Rows.Count > 0)
//                {
//                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
//                    {
//                        _Dbl_CajasMes[_Int_I-1] = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
//                    }
//                    else
//                    {
//                        _Dbl_CajasMes[_Int_I-1] = 0;
//                    }
//                }
//                else
//                {
//                    _Dbl_CajasMes[_Int_I-1] = 0;
//                }
//            }

            GraphPane myPane = zg1.GraphPane;
            myPane.Title.Text = " ";
            myPane.XAxis.Title.Text = " ";//CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString();
            myPane.XAxis.Scale.FontSpec.Angle = 90;//65;
            myPane.YAxis.Title.Text = "CAJAS";
            myPane.YAxis.Scale.MajorStep = 1;
            myPane.YAxis.Scale.MinorStep = 1;
            BarItem myBar = myPane.AddBar("Cant. Cajas", null, _Dbl_CajasMes,
                                                        Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Blue, Color.White,
                                                        Color.Blue);
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.XAxis.Scale.TextLabels = _Str_Meses;

            myPane.XAxis.Type = AxisType.Text;

            myPane.Chart.Fill = new Fill(Color.White,
                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            zg1.AxisChange();
            zg1.Refresh();
        }
        private void _Mtd_Crear_Tabla_Ventas(string _P_Str_Producto)
        {
            int max = 12;
            int[] _Int_Intervalos = new int[max];
            string[] _Str_Meses = new string[max];// { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            int j = 0;
            for (int i = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + 1; i <= max; i++)
            {
                _Int_Intervalos[j] = i;
                if (i == 1)
                { _Str_Meses[j] = "Enero "; }
                if (i == 2)
                { _Str_Meses[j] = "Febrero "; }
                if (i == 3)
                { _Str_Meses[j] = "Marzo "; }
                if (i == 4)
                { _Str_Meses[j] = "Abril "; }
                if (i == 5)
                { _Str_Meses[j] = "Mayo "; }
                if (i == 6)
                { _Str_Meses[j] = "Junio "; }
                if (i == 7)
                { _Str_Meses[j] = "Julio "; }
                if (i == 8)
                { _Str_Meses[j] = "Agosto "; }
                if (i == 9)
                { _Str_Meses[j] = "Septiembre "; }
                if (i == 10)
                { _Str_Meses[j] = "Octubre "; }
                if (i == 11)
                { _Str_Meses[j] = "Noviembre "; }
                if (i == 12)
                { _Str_Meses[j] = "Diciembre "; }
                _Str_Meses[j] += (CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year - 1).ToString();
                j++;
            }
            for (int i = 1; i <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month; i++)
            {
                _Int_Intervalos[j] = i;
                if (i == 1)
                { _Str_Meses[j] = "Enero "; }
                if (i == 2)
                { _Str_Meses[j] = "Febrero "; }
                if (i == 3)
                { _Str_Meses[j] = "Marzo "; }
                if (i == 4)
                { _Str_Meses[j] = "Abril "; }
                if (i == 5)
                { _Str_Meses[j] = "Mayo "; }
                if (i == 6)
                { _Str_Meses[j] = "Junio "; }
                if (i == 7)
                { _Str_Meses[j] = "Julio "; }
                if (i == 8)
                { _Str_Meses[j] = "Agosto "; }
                if (i == 9)
                { _Str_Meses[j] = "Septiembre "; }
                if (i == 10)
                { _Str_Meses[j] = "Octubre "; }
                if (i == 11)
                { _Str_Meses[j] = "Noviembre "; }
                if (i == 12)
                { _Str_Meses[j] = "Diciembre "; }
                _Str_Meses[j] += CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString();
                j++;
            }

            double[] _Dbl_CajasMes = new double[12];
            zg1.GraphPane.CurveList.Clear();
            for (int _Int_I = 1; _Int_I <= 12; _Int_I++)
            {
                string _Str_Cadena = "SELECT SUM(TPREFACTURAD.cempaques) AS Suma " +
"FROM TPREFACTURAM INNER JOIN " +
"TPREFACTURAD ON TPREFACTURAM.ccompany = TPREFACTURAD.ccompany AND TPREFACTURAM.cpedido = TPREFACTURAD.cpedido AND " +
"TPREFACTURAM.cpfactura = TPREFACTURAD.cpfactura " +
"WHERE  (TPREFACTURAD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TPREFACTURAD.cproducto = '" + _P_Str_Producto + "') AND (MONTH(TPREFACTURAM.c_fecha_pedido) = '" + _Int_Intervalos[_Int_I - 1].ToString() + "') AND " +
"(YEAR(TPREFACTURAM.c_fecha_pedido) = '" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString() + "') " +
"GROUP BY TPREFACTURAD.cempaques";
                DataSet _Ds =Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Dbl_CajasMes[_Int_I-1] = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        _Dbl_CajasMes[_Int_I-1] = 0;
                    }
                }
                else
                {
                    _Dbl_CajasMes[_Int_I-1] = 0;
                }
            }
            //zg1.GraphPane = new GraphPane();
            //zg1.GraphPane.XAxis.IsVisible = true;
            //zg1.GraphPane.XAxis.Title.IsVisible = true;
            GraphPane myPane = zg1.GraphPane;
            // Set the Titles
            myPane.Title.Text = " ";
            myPane.XAxis.Title.Text = " ";//CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year.ToString();
            myPane.XAxis.Scale.FontSpec.Angle = 90;
            myPane.YAxis.Title.Text = "CAJAS";
            myPane.YAxis.Scale.MajorStep = 1;
            myPane.YAxis.Scale.MinorStep = 1;
            BarItem myBar = myPane.AddBar("Cant. Cajas", null, _Dbl_CajasMes,
                                                        Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Blue, Color.White,
                                                        Color.Blue);
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels

            myPane.XAxis.Scale.TextLabels = _Str_Meses;
            // Set the XAxis to Text type

            myPane.XAxis.Type = AxisType.Text;

            // Fill the Axis and Pane backgrounds

            myPane.Chart.Fill = new Fill(Color.White,
                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            // Tell ZedGraph to refigure the

            // axes since the data have changed

            zg1.AxisChange();
            zg1.Refresh();
        }

        private void _Rbt_Ventas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Ventas.Checked)
            { _Mtd_Crear_Tabla_Ventas(_Txt_CodProductoArriba.Text.Trim()); }
        }

        private void _Rbt_Compras_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Compras.Checked)
            { _Mtd_Crear_Tabla_Compras(_Txt_CodProductoArriba.Text.Trim()); }
        }

        private void _Txt_Barras_Unidad_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Barras_Unidad.Text.Trim().Length > 0)
            { _Gr_Cuarto.Enabled = true; }
            else
            { _Gr_Cuarto.Enabled = false; }
        }

        private void _Txt_Barras_Corrugado_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Barras_Corrugado.Text.Trim().Length > 0)
            { _Gr_Segundo.Enabled = true; }
            else
            { _Gr_Segundo.Enabled = false; }
        }
        ///////////////////////////////////////////////
        private void _Mtd_Texto_Formato(TextBox _P_Txt_Txt)
        {
            _P_Txt_Txt.TextChanged += new EventHandler(_P_Txt_Txt_TextChanged);
        }

        void _P_Txt_Txt_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length > 0)
            {
                ((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Trim()).ToString("F2");
            }
        }

        private void Frm_ConsultaProductos_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.RowCount > 0)
            {
                if (_Sfd_1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                    _MyExcel._Mtd_DatasetToExcel((DataTable)_Dg_Grid.DataSource, _Sfd_1.FileName, "INVENTARIO " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
                    _MyExcel = null;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Mtd_UsuarioLimitado() & e.TabPageIndex == 2) { e.Cancel = true; }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Mtd_UsuarioLimitado() & e.TabPageIndex > 1) { e.Cancel = true; }
        }

        private void _Txt_CostoNetoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_CostoNetoP, e, 18, 2);
        }

        private void _Txt_CostoNetoP_TextChanged(object sender, EventArgs e)
        {
            if (!_myUtilidad._Mtd_IsNumeric(_Txt_CostoNetoP.Text)) { _Txt_CostoNetoP.Text = ""; }
        }

        private void _Cntx_ModifCostNet_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.CurrentCell == null || !(_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIF_COST_NETO"));
        }
        /// <summary>
        /// Obtiene un valor que indica si el contedito de un TextBox esta validado
        /// </summary>
        /// <param name="_P_Txt_TextBox">TextBox que se va a verificar</param>
        /// <returns>bool</returns>
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }
        private string _Mtd_RetornarInfProducto(string _P_Str_Producto, string _P_Str_Campo)
        {
            string _Str_Cadena = "SELECT cnamefc,dbo.Fnc_Formatear(ccostobruto_u1) AS ccostobruto_u1,dbo.Fnc_Formatear(ccostoneto_u1) AS ccostoneto_u1 FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][_P_Str_Campo].ToString();
        }
        private void _Mtd_ModificarCostoNeto(string _P_Str_Producto, double _P_Dbl_CostoNeto)
        {
            string _Str_Cadena = "UPDATE TPRODUCTO SET ccostoneto_u1='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_CostoNeto) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cproducto='" + _P_Str_Producto + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Pnl_Producto_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Producto.Visible)
            { 
                _Tb_Tab.Enabled = false;
                _Txt_ProductoP.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value);
                _Txt_DescripcionP.Text = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value), "cnamefc");
                _Txt_CostoBrutoP.Text = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value), "ccostobruto_u1");
                _Txt_CostoNetoP.Text = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value), "ccostoneto_u1");
                _Txt_CostoNetoP.Select(0, _Txt_CostoNetoP.Text.Length);
                _Txt_CostoNetoP.Focus();
            }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_CerrarP_Click(object sender, EventArgs e)
        {
            _Pnl_Producto.Visible = false;
        }

        private void _Cntx_Txt_MenuModif_Click(object sender, EventArgs e)
        {
            _Pnl_Producto.Visible = true;
        }

        private void _Bt_Modif_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerifContTextBoxNumeric(_Txt_CostoBrutoP) & _Mtd_VerifContTextBoxNumeric(_Txt_CostoNetoP))
            {
                if (Convert.ToDouble(_Txt_CostoNetoP.Text) > Convert.ToDouble(_Txt_CostoBrutoP.Text))
                { MessageBox.Show("El costo neto no debe ser mayor al costo bruto", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    if (new Frm_MessageBox("¿Esta seguro de modificar el costo neto del producto:\n'" + _Txt_ProductoP.Text + "' " + _Txt_DescripcionP.Text + "?", "Precaución", SystemIcons.Warning, 2).ShowDialog() == DialogResult.Yes)
                    {
                        _Mtd_ModificarCostoNeto(_Txt_ProductoP.Text, Convert.ToDouble(_Txt_CostoNetoP.Text));
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Costo Neto"].Value = Convert.ToDouble(_Txt_CostoNetoP.Text).ToString("#,##0.00");
                        _Txt_Costo_Neto1.Text = _Txt_CostoNetoP.Text;
                        MessageBox.Show("EL costo neto del producto: '" + _Txt_ProductoP.Text + "' " + _Txt_DescripcionP.Text + "\nha sido modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Producto.Visible = false;
                    }
                    else
                    { _Pnl_Producto.Visible = false; }
                }
            }
            else if (_Mtd_VerifContTextBoxNumeric(_Txt_CostoBrutoP) & !_Mtd_VerifContTextBoxNumeric(_Txt_CostoNetoP))
            { MessageBox.Show("El costo neto debe ser mayor a cero(0)", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!_Mtd_VerifContTextBoxNumeric(_Txt_CostoBrutoP))
            { MessageBox.Show("Para modificar el costo neto el costo bruto debe ser mayor a cero(0)", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            { MessageBox.Show("Faltan datos para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void _Cntx_Txt_MenuModifLote_Click(object sender, EventArgs e)
        {
            string _Str_Descripcion = _Mtd_RetornarInfProducto(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value), "cnamefc");
            Cursor = Cursors.WaitCursor;
            Frm_ModifCostNetLote _Frm = new Frm_ModifCostNetLote(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value), _Str_Descripcion);
            Cursor = Cursors.Default;
            _Frm.ShowDialog(this);
        }
        ///////////////////////////////////////////////
    }
}