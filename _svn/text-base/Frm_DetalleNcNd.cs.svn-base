using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_DetalleNcNd : Form
    {
        public Frm_DetalleNcNd()
        {
            InitializeComponent();
        }
        public Frm_DetalleNcNd(string _P_Str_Clave,string _P_Str_NumDocumeto,int _P_Int_Sw,string _P_Str_Proveedor)
        {
            InitializeComponent();
            if (_P_Int_Sw == 2)//dbo.Fnc_Formatear
            {
                this.Text = "Detalle de la Nota de Crédito";
                string _Str_Cadena = "Select cproducto as Producto,(Select top 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END from TPRODUCTO INNER JOIN dbo.TMARCASM ON dbo.TPRODUCTO.cmarca = dbo.TMARCASM.cmarca where TPRODUCTO.cproducto=TNOTACREDICPD.cproducto) as Descripción, ccajas as Cajas, cunidades as Unidades,dbo.Fnc_Formatear(cbasegrabada) as [B. Grabada], dbo.Fnc_Formatear(cbasexcenta) as [B. Exenta], dbo.Fnc_Formatear(cmontoinvendi) as Invendible, dbo.Fnc_Formatear(cimpuesto) as Impuesto, dbo.Fnc_Formatear(cmontototal) as Total from TNOTACREDICPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotacreditocxp='" + _P_Str_Clave + "' and cproveedor='" + _P_Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Datagrid.DataSource = _Ds.Tables[0];
                _Dg_Datagrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (_P_Int_Sw == 1)
            {
                this.Text = "Detalle de la Nota de Débito";
                string _Str_Cadena = "Select cproducto as Producto,(Select top 1 CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END from TPRODUCTO INNER JOIN dbo.TMARCASM ON dbo.TPRODUCTO.cmarca = dbo.TMARCASM.cmarca where TPRODUCTO.cproducto=TNOTADEBITOCPD.cproducto) as Descripción, ccajas as Cajas, cunidades as Unidades,dbo.Fnc_Formatear(cbasegrabada) as [B. Grabada], dbo.Fnc_Formatear(cbasexcenta) as [B. Exenta], dbo.Fnc_Formatear(cmontoinvendi) as Invendible, dbo.Fnc_Formatear(cimpuesto) as Impuesto, dbo.Fnc_Formatear(cmontototal) as Total from TNOTADEBITOCPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _P_Str_Clave + "' and cproveedor='" + _P_Str_Proveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Datagrid.DataSource = _Ds.Tables[0];
                _Dg_Datagrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

        }
        private void _Dg_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_OCporcerrar_Load(object sender, EventArgs e)
        {

        }
    }
}