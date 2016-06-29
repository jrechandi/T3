using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace T3
{
    public partial class Frm_PreOrden : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_Proveedor; string _Str_Grupo; string _Str_SubGrupo; string _Str_Marca; string _Str_Producto; string _Str_Estratificacion;
        public Frm_PreOrden()
        {
            InitializeComponent();
        }
        public Frm_PreOrden(string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_Marca, string _P_Str_Producto, string _P_Str_Estratificacion)
        {
            InitializeComponent();
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_Grupo = _P_Str_Grupo;
            _Str_SubGrupo = _P_Str_SubGrupo;
            _Str_Marca = _P_Str_Marca;
            _Str_Producto = _P_Str_Producto;
            _Str_Estratificacion = _P_Str_Estratificacion;
            _Txt_Proveedor.Tag = _P_Str_Proveedor;
            _Txt_Proveedor.Text = _Mtd_NombPorveedor(_P_Str_Proveedor);
            _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ());
            _Mtd_Acualizar();
            _Mtd_Totalizar();
        }
        private string _Mtd_NombPorveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_Acualizar()
        {
            string _Str_Cadena = "SELECT DISTINCT cproducto,cnamefc,ISNULL(cinvsugerido,0) AS Cajas,(ccostobruto_u1 * ISNULL(cinvsugerido,0)) AS Monto,CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((ccostobruto_u1 * cinvsugerido)*TTAX.cpercent)/100 ELSE 0 END AS Impuesto,ccostobruto_u1 AS Costo FROM TPRODUCTO INNER JOIN TGRUPPROVEE ON TPRODUCTO.cproveedor=TGRUPPROVEE.cproveedor LEFT OUTER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE TPRODUCTO.cactivate='1' AND ISNULL(TGRUPPROVEE.cdelete,0)=0 AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND ((TPRODUCTO.cproveedor='" + _Str_Proveedor + "') OR ('" + _Str_Proveedor + "'='nulo')) AND ((TPRODUCTO.cproducto LIKE '" + _Str_Producto + "'+'%') OR ('" + _Str_Producto + "'='nulo')) AND ((cgrupo='" + _Str_Grupo + "') OR ('" + _Str_Grupo + "'='nulo')) AND ((csubgrupo='" + _Str_SubGrupo + "') OR ('" + _Str_SubGrupo + "'='nulo')) AND ((cmarca='" + _Str_Marca + "') OR ('" + _Str_Marca + "'='nulo')) AND ((cestratificacion='" + _Str_Estratificacion + "') OR ('" + _Str_Estratificacion + "'='nulo'))";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dg_Grid.Rows.Add(new object[] { _Row["cproducto"].ToString().ToUpper().Trim(), "   " , _Row["cnamefc"].ToString().ToUpper().Trim(), _Row["Cajas"].ToString().ToUpper().Trim(), _Row["Monto"].ToString().ToUpper().Trim(), _Row["Impuesto"].ToString().ToUpper().Trim(), _Row["Costo"].ToString().ToUpper().Trim() });
            }
            _Dg_Grid.Rows.Add();
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns["Cajas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Cajas"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Cajas"].DefaultCellStyle.BackColor = Color.Khaki;
        }
        private string _Mtd_ObtenerCampo(string _P_Str_Producto, object _P_Ob_Cajas,string _P_Str_Campo)
        {
            if (Convert.ToString(_P_Ob_Cajas).Trim().Length == 0)
            { _P_Ob_Cajas = 0; }
            string _Str_Cadena = "SELECT (ccostobruto_u1 * " + Convert.ToInt32(_P_Ob_Cajas) + ") AS Monto,CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((ccostobruto_u1 * " + Convert.ToInt32(_P_Ob_Cajas) + ")*TTAX.cpercent)/100 ELSE 0 END AS Impuesto FROM TPRODUCTO LEFT OUTER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE cproducto='" + _P_Str_Producto.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][_P_Str_Campo].ToString().Trim(); }
            return "0";
        }
        private void _Mtd_Totalizar()
        {
            int _Int_Cajas = 0;
            double _Dbl_Monto = 0;
            double _Dbl_Impuesto = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Cajas"].Value).Trim().Length > 0)
                { _Int_Cajas += Convert.ToInt32(Convert.ToString(_Dg_Row.Cells["Cajas"].Value).Trim()); }
                if (Convert.ToString(_Dg_Row.Cells["Monto"].Value).Trim().Length > 0)
                { _Dbl_Monto += Convert.ToDouble(Convert.ToString(_Dg_Row.Cells["Monto"].Value).Trim()); }
                if (Convert.ToString(_Dg_Row.Cells["Impuesto"].Value).Trim().Length > 0)
                { _Dbl_Impuesto += Convert.ToDouble(Convert.ToString(_Dg_Row.Cells["Impuesto"].Value).Trim()); }
            }
            _Txt_Cajas.Text = _Int_Cajas.ToString();
            _Txt_TotalSinImp.Text = _Dbl_Monto.ToString("#,##0.00");
            _Txt_Impuesto.Text = _Dbl_Impuesto.ToString("#,##0.00");
            _Txt_Total.Text = Convert.ToDouble(_Dbl_Monto + _Dbl_Impuesto).ToString("#,##0.00");
        }
        private bool _Mtd_Valido(object _P_Ob_Cajas)
        {
            if (Convert.ToString(_P_Ob_Cajas).Trim().Length > 0)
            {
                return Convert.ToInt32(_P_Ob_Cajas) > 0;
            }
            return false;
        }
        private int _Mtd_VerificarGrid()
        {
            int _Int_Sw = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Producto"].Value).Trim().Length > 0)
                {
                    if (!_Mtd_Valido(_Dg_Row.Cells["Cajas"].Value))
                    {
                        _Int_Sw += 1;
                    }
                }
            }
            return _Int_Sw;
        }
        private void _Mtd_GenerarPreOrden()
        {
            _Dg_Grid.EndEdit();
            if (_Dg_Grid.RowCount > 1)
            {
                bool _Bol_Generar = false;
                int _Int_Sw = _Mtd_VerificarGrid();
                if (_Int_Sw == 0)
                { _Bol_Generar = true; }
                else if (_Int_Sw > 0 & _Int_Sw < _Dg_Grid.RowCount -1)
                { _Bol_Generar = MessageBox.Show("Existen registros con cajas en cero(0). Solo se guardarán los registros con cajas mayores a cero(0).\n¿Esta seguro de realizar la operación?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes; }
                else
                { MessageBox.Show("No se puede realizar la operación. Faltan datos en el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                if (_Bol_Generar)
                {
                    if (_Txt_TotalSinImp.Text.Trim().Length == 0)
                    { _Txt_TotalSinImp.Text = "0"; }
                    if (_Txt_Impuesto.Text.Trim().Length == 0)
                    { _Txt_Impuesto.Text = "0"; }
                    Cursor = Cursors.WaitCursor;
                    string _Str_Cadena = "SELECT MAX(cpreoc) FROM TPREORDENCM WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    string _Str_ID_PreOrden = _Cls_VariosMetodos._Mtd_Correlativo(_Str_Cadena);
                    _Str_Cadena = "INSERT INTO TPREORDENCM (ccompany,cpreoc,cfecha,cproveedor,cdateadd,cuseradd,cdelete,cevaluado,cstatus,cnumoc,ctotsimp,ctotimp) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_ID_PreOrden + "',GETDATE(),'" + Convert.ToString(_Txt_Proveedor.Tag).Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','0','0','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_TotalSinImp.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                    {
                        if (_Mtd_Valido(_Dg_Row.Cells["Cajas"].Value))
                        {
                            _Str_Cadena = "INSERT INTO TPREORDENCD (ccompany,cpreoc,cproveedor,cgrupo,csku,csubgrupo,cfecha,cproducto,cprodregular,ccodproveedor,cmarca,cexisrealu1,cexisrealu2,cexiscomu1,cexiscomu2,cexisllegar1,cexisllegar2,cexisultcomp,cpromcomptri,cpromvtastri,cdiarotultcomp,ccomprames,cventasmes,cinvtminimo,cdiferencinv,cnecactualvta,cnecinveact,cinvtmaximo,cinvsugerido,cinventpedir,csugeprovee,cdescuento1,cdescuento2,ccostobruto_u1,ccostobruto_u2,ctotcostosimp,cimpcosto,cdateadd,cuseradd,cmontoprovee,cfecultcomp_u1,cpedidoprome,cpuntoreorden,cultcompra) SELECT '" + Frm_Padre._Str_Comp + "','" + _Str_ID_PreOrden + "',cproveedor,cgrupo,csku,csubgrupo,GETDATE(),cproducto,cprodregular,ccodproveedor,cmarca,cexisrealu1,cexisrealu2,cexiscomu1,cexiscomu2,cexisllegar1,cexisllegar2,cexisultcomp_u1,cpromcomp3m,cpromvta3m_u1,cdiarotultcomp,ccompdelmes,cvtadelmes,cinvmin,cdifcontrinv,cnecvactual,cnecinvactual,cinvmax,'" + Convert.ToString(_Dg_Row.Cells["Cajas"].Value) + "','" + Convert.ToString(_Dg_Row.Cells["Cajas"].Value) + "',0,0,0,ccostobruto_u1,ccostobruto_u2,(ccostobruto_u1 * " + Convert.ToString(_Dg_Row.Cells["Cajas"].Value) + "),CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((ccostobruto_u1 * " + Convert.ToString(_Dg_Row.Cells["Cajas"].Value) + ")*TTAX.cpercent)/100 END,GETDATE(),'" + Frm_Padre._Str_Use + "',0,cfecultcomp_u1,cpedidoprome,cpuntoreorden,cmovultcomp FROM TPRODUCTO LEFT OUTER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE cproducto='" + Convert.ToString(_Dg_Row.Cells["Producto"].Value) + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _Str_Cadena = "UPDATE TPREORDENCD SET CIMPCOSTO='0' WHERE CPREOC='" + _Str_ID_PreOrden + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CPRODUCTO='" + Convert.ToString(_Dg_Row.Cells["Producto"].Value) + "' AND CIMPCOSTO IS NULL";
                            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        }
                    }
                    _Mtd_DTS_Preorden(_Str_ID_PreOrden, Frm_Padre._Str_Comp);
                    Cursor = Cursors.WaitCursor;
                    MessageBox.Show("La operación ha sido realizada correctamente. Se ha generado la Pre-Orden número " + _Str_ID_PreOrden + ".\nA continuación se va a imprimir el reporte de la Pre-Orden.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Mtd_ImprimirPreOrden(_Str_ID_PreOrden);
                }
            }
            else
            {
                MessageBox.Show("No se puede realizar la operación. No existe detalle.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Mtd_ImprimirPreOrden(string _P_Str_PreOrden)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(6, Frm_Padre._Str_Comp, _Mtd_NombComp(), _P_Str_PreOrden, _Str_Proveedor, _Mtd_NombPorveedor(_Str_Proveedor), _Txt_Fecha.Text);
            Cursor = Cursors.Default;
            _Frm_Inf.MdiParent = this.MdiParent;
            _Frm_Inf.Dock = DockStyle.Fill;
            _Frm_Inf.Show();
            this.Close();
        }
        private void _Mtd_DTS_Preorden(string _Str_IdPreorden, string _Str_Compania)
        {
            try
            {
                SqlParameter[] _SQL_Parametros = new SqlParameter[3];
                _SQL_Parametros[0] = new SqlParameter("@numorden", SqlDbType.Int);
                _SQL_Parametros[0].Value = _Str_IdPreorden;
                _SQL_Parametros[1] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                _SQL_Parametros[1].Value = _Str_Compania;
                _SQL_Parametros[2] = new SqlParameter("@cproveedor", SqlDbType.VarChar);
                _SQL_Parametros[2].Value = Convert.ToString(_Txt_Proveedor.Tag).Trim();
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_ENVIAREMAILPOC", _SQL_Parametros);

                _SQL_Parametros = new SqlParameter[3];
                _SQL_Parametros[0] = new SqlParameter("@CPREOC", SqlDbType.Int);
                _SQL_Parametros[0].Value = _Str_IdPreorden;
                _SQL_Parametros[1] = new SqlParameter("@CCOMPANY", SqlDbType.VarChar);
                _SQL_Parametros[1].Value = _Str_Compania;
                string _Str_SQL = "SELECT cservidor FROM TCOMPANY WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                DataSet _DS_DataSet = new DataSet();
                _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                string _Str_Server = _DS_DataSet.Tables[0].Rows[0][0].ToString();
                if (_Str_Server.Trim() != "")
                {
                    _Str_Server = osio.desencriptar(_Str_Server);
                }
                _SQL_Parametros[2] = new SqlParameter("@CSERVER", SqlDbType.VarChar);
                _SQL_Parametros[2].Value = _Str_Server;
                SqlConnection _SQL_Conex = new SqlConnection(Program._MyClsCnn._mtd_conexion3._g_Str_Stringconex);
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_DTS_PREORDEN", _SQL_Parametros, _SQL_Conex);
            }
            catch
            {
            }
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                _Bol_Boleano = true;
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid.Columns[_Dg_Grid.CurrentCell.ColumnIndex].Name == "Cajas")
            {
                _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 0);
            }
        }
        string _Str_Temp_Cajas = "";
        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Dg_Grid.Columns[e.ColumnIndex].Name == "Cajas")
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value != null)
                {
                    _Str_Temp_Cajas = _Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value.ToString();
                }
            }
        }

        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.Columns[e.ColumnIndex].Name == "Cajas")
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value = _Str_Temp_Cajas;
                    }
                }
                else
                { _Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value = _Str_Temp_Cajas; }
                _Dg_Grid.Rows[e.RowIndex].Cells["Monto"].Value = _Mtd_ObtenerCampo(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Producto"].Value), _Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value, "Monto");
                _Dg_Grid.Rows[e.RowIndex].Cells["Impuesto"].Value = _Mtd_ObtenerCampo(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Producto"].Value), _Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].Value, "Impuesto");
                _Mtd_Totalizar();
            }
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_GenerarPreOrden();
        }
        private void Frm_PreOrden_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_PreOrden_Load(object sender, EventArgs e)
        {
            _Mtd_Sorted();
        }
        private void _Mtd_EliminarFila()
        {
            int[] _Int_RowIndex = new int[0];
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Selected)
                {
                    _Int_RowIndex = (int[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Int_RowIndex, _Int_RowIndex.Length + 1);
                    _Int_RowIndex[_Int_RowIndex.Length - 1] = _Dg_Row.Index - (_Int_RowIndex.Length -1);
                }
            }
            foreach (int _Int_Fila in _Int_RowIndex)
            {
                if (Convert.ToString(_Dg_Grid.Rows[_Int_Fila].Cells["Producto"].Value).Trim().Length > 0)
                { _Dg_Grid.Rows.RemoveAt(_Int_Fila); }
            }
        }
        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell == null | _Dg_Grid.RowCount == 0 | _Dg_Grid.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_EliminarFila();
            _Mtd_Totalizar();
            Cursor = Cursors.Default;
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }
        private void _Mtd_InsertarProducto(string _P_Str_Producto,int _P_Int_Index)
        {
            string _Str_Cadena = "SELECT cnamefc,ISNULL(cinvsugerido,0) AS Cajas,(ccostobruto_u1 * ISNULL(cinvsugerido,0)) AS Monto,CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((ccostobruto_u1 * cinvsugerido)*TTAX.cpercent)/100 ELSE 0 END AS Impuesto,ccostobruto_u1 AS Costo FROM TPRODUCTO LEFT OUTER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dg_Grid.Rows[_P_Int_Index].Cells["Producto"].Value = _P_Str_Producto;
                _Dg_Grid.Rows[_P_Int_Index].Cells["Descripcion"].Value = _Ds.Tables[0].Rows[0]["cnamefc"].ToString().Trim();
                _Dg_Grid.Rows[_P_Int_Index].Cells["Cajas"].Value = _Ds.Tables[0].Rows[0]["Cajas"].ToString().Trim();
                _Dg_Grid.Rows[_P_Int_Index].Cells["Monto"].Value = _Ds.Tables[0].Rows[0]["Monto"].ToString().Trim();
                _Dg_Grid.Rows[_P_Int_Index].Cells["Impuesto"].Value = _Ds.Tables[0].Rows[0]["Impuesto"].ToString().Trim();
                _Dg_Grid.Rows[_P_Int_Index].Cells["Costo"].Value = _Ds.Tables[0].Rows[0]["Costo"].ToString().Trim();
            }
        }
        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.RowIndex != -1 & e.ColumnIndex!=-1)
                {
                    if (_Dg_Grid.Columns[e.ColumnIndex].Name == "Buscar")
                    {
                        TextBox _Txt_Temp = new TextBox();
                        Cursor = Cursors.WaitCursor;
                        Frm_BusquedaAvanzada2 _Frm = new Frm_BusquedaAvanzada2(_Txt_Temp, new TextBox(), "", Convert.ToString(_Txt_Proveedor.Tag).Trim());
                        Cursor = Cursors.Default;
                        _Frm.ShowDialog(this);
                        if (_Txt_Temp.Text.Trim().Length > 0)
                        {
                            _Mtd_InsertarProducto(_Txt_Temp.Text.Trim(), e.RowIndex);
                            _Mtd_Totalizar();
                            _Dg_Grid.Columns["Cajas"].DefaultCellStyle.BackColor = Color.Khaki;
                            if (e.RowIndex == _Dg_Grid.RowCount - 1)
                            { _Dg_Grid.Rows.Add(); }
                        }
                    }
                }
            }
        }

        private void _Dg_Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.RowIndex != -1 & e.ColumnIndex != -1)
                {
                    if (_Dg_Grid.Columns[e.ColumnIndex].Name == "Cajas")
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Cajas"].ReadOnly = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Producto"].Value).Trim().Length == 0;
                    }
                }
            }
        }

        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

    }
}