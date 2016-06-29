using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_VistaGerente : Form
    {
        public Frm_VistaGerente()
        {
            InitializeComponent();
            _Pgb_Progress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
        }

        private void Frm_VistaGerente_Load(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_cadena = "Select cfechaoc as Fecha,cnumoc AS [O.C.],c_nomb_comer as Proveedor,ctotsimp as Monto,cproveedor,(Select SUM(ccantunidadma1) from TORDENCOMPD where TORDENCOMPD.ccompany=vst_ordendecompragerente.ccompany and TORDENCOMPD.cnumoc=vst_ordendecompragerente.cnumoc) as Cajas,(Select SUM(ccantunidadma2) from TORDENCOMPD where TORDENCOMPD.ccompany=vst_ordendecompragerente.ccompany and TORDENCOMPD.cnumoc=vst_ordendecompragerente.cnumoc) as Unidades from vst_ordendecompragerente where ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena);

            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns[6].Visible = false;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void cerrarOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
            _Dg_Grid.Enabled = false;
        }
        public void _Mtd_MostrarDetalle(string _P_Str_OC, string _Str_P_Proveedor, string _P_Str_Nombre, string _P_Str_Monto, string _P_Str_Cajas, string _P_Str_Unidades, string _P_Str_Fecha)
        {
            _Dg_Grid_Detalle.Rows.Clear();
            _Txt_OC.Text = _P_Str_OC;
            _Txt_Proveedor.Text = _P_Str_Nombre;
            _Txt_Fecha.Text = _P_Str_Fecha;
            _Txt_Cajas.Text = _P_Str_Cajas;
            _Txt_Unidades.Text = _P_Str_Unidades;
            _Txt_Monto.Text = _P_Str_Monto;
            string _Str_Cadena = "Select ctipodocumentoc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_TipoD = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_TipoD = _Ds.Tables[0].Rows[0][0].ToString(); }
            _Str_Cadena = "Select cnfacturapro,CASE WHEN (SELECT sum(CCANTIDAD_U1) FROM TTEMPOC WHERE CNUMDOCU='" + _P_Str_OC + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctdocument='" + _Str_TipoD + "' AND CSUMA='0') IS NULL THEN cempaques ELSE (SELECT sum(CCANTIDAD_U1) FROM TTEMPOC WHERE CNUMDOCU='" + _P_Str_OC + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctdocument='" + _Str_TipoD + "' AND CSUMA='0') END as cempaques,CASE WHEN (SELECT sum(CCANTIDAD_U2) FROM TTEMPOC WHERE CNUMDOCU='" + _P_Str_OC + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctdocument='" + _Str_TipoD + "' AND CSUMA='0') IS NULL THEN cunidades ELSE (SELECT sum(CCANTIDAD_U2) FROM TTEMPOC WHERE CNUMDOCU='" + _P_Str_OC + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctdocument='" + _Str_TipoD + "' AND CSUMA='0') END as cunidades,ctotmontsimp,cempaques,cunidades,ctdiferencia,cidrecepcion from vst_detallefacturagerente where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnumoc='" + _P_Str_OC + "' and cproveedor='" + _Str_P_Proveedor + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Mtd_Metodo(Convert.ToInt32(_Ds.Tables[0].Rows[0]["ctdiferencia"].ToString()), _Ds.Tables[0].Rows[0]["cidrecepcion"].ToString(), _P_Str_OC, _Str_P_Proveedor, _Ds.Tables[0].Rows[0][0].ToString());
                _Dg_Grid_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void _Mtd_Efectividad(string pOrdenCompra)
        {
            _Lbl_Por.Text = "0";
            _Pgb_Progress.Value = 0;
            
            string _Str_Cadena = "select cefectividad from TORDENCOMPM where ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + pOrdenCompra + "';";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            double _Dbl_Value = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cefectividad"].ToString());

            if (_Dbl_Value > 100)
            {
                _Pgb_Progress.Value = 100;
            }
            else
            {
                _Pgb_Progress.Value = Convert.ToInt32(_Dbl_Value);
            }

            _Lbl_Por.Text = Convert.ToInt32(_Dbl_Value).ToString();
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Dg_Grid.Enabled = true;
            _Txt_Clave.Text = "";
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Dg_Grid.Enabled = true;
            _Txt_Clave.Text = "";
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
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
                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TORDENCOMPM", "ccerrada='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and cnumoc='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString() + "' and cproveedor='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString() + "'");
                    _Txt_OC.Text = "";
                    _Txt_Proveedor.Text = "";
                    _Txt_Fecha.Text = "";
                    _Txt_Cajas.Text = "";
                    _Txt_Monto.Text = "";
                    _Lbl_Por.Text = "0";
                    _Pgb_Progress.Value = 0;
                    _Dg_Grid_Detalle.DataSource = null;
                    MessageBox.Show("La O.C. fue cerrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Pnl_Clave.Visible = false;
                    _Dg_Grid.Enabled = true;
                    _Txt_Clave.Text = "";
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Txt_Clave.Focus(); }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_MostrarDetalle(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[2].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[5].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[6].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString());
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }
        private void _Mtd_Metodo(int _P_Int_Tipo,string _P_Str_Recepcion,string _P_Str_OC,string _P_Str_Proveedor,string _P_Str_Factura)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            DataSet _Ds2 = new DataSet();
            double _Dbl_EmpaquesAcumuladosFAc = 0;
            double _Dbl_EmpaquesFacEntreOC = 0;
            double _Dbl_EmpaquesFacEntreOCTEMP = 0;
            double _Dbl_EmpaquesOCIndividual = 0;
            double _Dbl_EmpaquesOCSeleccionada = 0;
            double _Dbl_EmpaquesFacTotal = 0;
            double _Dbl_UnidadesAcumuladosFAc = 0;
            double _Dbl_UnidadesFacEntreOC = 0;
            double _Dbl_UnidadesFacEntreOCTEMP = 0;
            double _Dbl_UnidadesOCIndividual = 0;
            double _Dbl_UnidadesOCSeleccionada = 0;
            double _Dbl_UnidadesFacTotal = 0;
            double _Dbl_Monto = 0;
            if (_P_Int_Tipo == 1 | _P_Int_Tipo==3)
            {
                string _Str_Factura = "";
                _Str_Cadena = "SELECT SUM(TORDENCOMPD.ccantunidadma1),SUM(TORDENCOMPD.ccantunidadma2) " +
                   "FROM TRECEPCIONRELDIF INNER JOIN " +
                   "TORDENCOMPD ON TRECEPCIONRELDIF.cnumoc = TORDENCOMPD.cnumoc " +
                   "WHERE (TRECEPCIONRELDIF.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TORDENCOMPD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TRECEPCIONRELDIF.cidrecepcion = '" + _P_Str_Recepcion + "') AND " +
                   "(TRECEPCIONRELDIF.cnumoc = '" + _P_Str_OC + "') " +
                   "GROUP BY TRECEPCIONRELDIF.cgroupcomp, TORDENCOMPD.ccompany, TRECEPCIONRELDIF.cidrecepcion, TRECEPCIONRELDIF.cnumoc ";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Dbl_EmpaquesOCSeleccionada = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                    }
                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                    {
                        _Dbl_UnidadesOCSeleccionada = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                    }
                }
                _Str_Cadena = "SELECT SUM(TRECEPCIONDFD.cempaques),TRECEPCIONRELDIF.cnfacturapro,SUM(TRECEPCIONDFD.cunidades) " +
"FROM TRECEPCIONRELDIF INNER JOIN " +
"TRECEPCIONDFD ON TRECEPCIONRELDIF.cgroupcomp = TRECEPCIONDFD.cgroupcomp AND " +
"TRECEPCIONRELDIF.cidrecepcion = TRECEPCIONDFD.cidrecepcion AND " +
"TRECEPCIONRELDIF.cnfacturapro = TRECEPCIONDFD.cnfacturapro " +
"WHERE (TRECEPCIONRELDIF.cnumoc = '" + _P_Str_OC + "') AND (TRECEPCIONRELDIF.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') " +
"GROUP BY TRECEPCIONRELDIF.cidrecepcion, TRECEPCIONRELDIF.cnumoc, TRECEPCIONRELDIF.cnfacturapro";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _Rows in _Ds2.Tables[0].Rows)
                    {
                        if (_Rows[0] != System.DBNull.Value)
                        {
                            _Dbl_EmpaquesFacEntreOCTEMP = _Dbl_EmpaquesFacEntreOC;
                            _Dbl_EmpaquesFacEntreOC = _Dbl_EmpaquesFacEntreOC + Convert.ToDouble(_Rows[0].ToString());
                            _Dbl_EmpaquesFacEntreOC = _Dbl_EmpaquesFacEntreOC - _Dbl_EmpaquesFacEntreOCTEMP;
                            _Str_Factura = _Rows[1].ToString();
                        }
                        if (_Rows[2] != System.DBNull.Value)
                        {
                            _Dbl_UnidadesFacEntreOCTEMP = _Dbl_UnidadesFacEntreOC;
                            _Dbl_UnidadesFacEntreOC = _Dbl_UnidadesFacEntreOC + Convert.ToDouble(_Rows[2].ToString());
                            _Dbl_UnidadesFacEntreOC = _Dbl_UnidadesFacEntreOC - _Dbl_UnidadesFacEntreOCTEMP;
                            _Str_Factura = _Rows[1].ToString();
                        }

                        _Str_Cadena = "Select cnumoc from TRECEPCIONRELDIF where cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Recepcion + "' and cnumoc<>'" + _P_Str_OC + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow _Row in _Ds.Tables[0].Rows)
                            {
                                _Str_Cadena = "SELECT SUM(TORDENCOMPD.ccantunidadma1),SUM(TORDENCOMPD.ccantunidadma2) " +
                               "FROM TRECEPCIONRELDIF INNER JOIN " +
                               "TORDENCOMPD ON TRECEPCIONRELDIF.cnumoc = TORDENCOMPD.cnumoc " +
                               "WHERE (TRECEPCIONRELDIF.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TORDENCOMPD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TRECEPCIONRELDIF.cidrecepcion = '" + _P_Str_Recepcion + "') AND " +
                               "(TRECEPCIONRELDIF.cnumoc = '" + _Row[0].ToString() + "') " +
                               "GROUP BY TRECEPCIONRELDIF.cgroupcomp, TORDENCOMPD.ccompany, TRECEPCIONRELDIF.cidrecepcion, TRECEPCIONRELDIF.cnumoc ";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                                    {
                                        _Dbl_EmpaquesOCIndividual = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                                    }
                                    if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                                    {
                                        _Dbl_UnidadesOCIndividual = Convert.ToDouble(_Ds.Tables[0].Rows[0][1].ToString());
                                    }
                                }
                                if (_Dbl_EmpaquesFacEntreOC > _Dbl_EmpaquesOCIndividual)
                                {
                                    _Dbl_EmpaquesFacTotal = _Dbl_EmpaquesFacEntreOC - _Dbl_EmpaquesOCIndividual;
                                }
                                else
                                {
                                    _Dbl_EmpaquesFacTotal = _Dbl_EmpaquesFacEntreOC;
                                }
                                if (_Dbl_UnidadesFacEntreOC > _Dbl_UnidadesOCIndividual)
                                {
                                    _Dbl_UnidadesFacTotal = _Dbl_UnidadesFacEntreOC - _Dbl_UnidadesOCIndividual;
                                }
                                else
                                {
                                    _Dbl_UnidadesFacTotal = _Dbl_UnidadesFacEntreOC;
                                }
                                _Dbl_EmpaquesAcumuladosFAc = _Dbl_EmpaquesAcumuladosFAc + _Dbl_EmpaquesFacTotal;
                                _Dbl_UnidadesAcumuladosFAc = _Dbl_UnidadesAcumuladosFAc + _Dbl_UnidadesFacTotal;
                                _Str_Cadena = "Select ctotmontsimp from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_Recepcion + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _P_Str_Proveedor + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                                    {
                                        _Dbl_Monto = (Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString()) / _Dbl_EmpaquesFacEntreOC) * _Dbl_EmpaquesFacTotal;
                                    }
                                }
                                object[] _Ob = new object[4];
                                if (_Dbl_EmpaquesFacEntreOC > 0)
                                {
                                    _Ob[0] = _Str_Factura;
                                    _Ob[1] = _Dbl_EmpaquesFacTotal;
                                    _Ob[2] = _Dbl_UnidadesFacTotal;
                                    _Ob[3] = _Dbl_Monto.ToString("#,##0.00");
                                    _Dg_Grid_Detalle.Rows.Add(_Ob);
                                }
                            }
                        }
                        else
                        {
                            object[] _Ob = new object[4];

                            _Str_Cadena = "SELECT dbo.TRECEPCIONDFM.cnfacturapro, sum(dbo.TRECEPCIONDFD.cempaques) as cempaques, sum(dbo.TRECEPCIONDFD.cunidades) as cunidades, ctotmontsimp";
                            _Str_Cadena += " FROM dbo.TRECEPCIONDFD INNER JOIN dbo.TRECEPCIONDFM ON dbo.TRECEPCIONDFD.cgroupcomp = dbo.TRECEPCIONDFM.cgroupcomp AND";
                            _Str_Cadena += " dbo.TRECEPCIONDFD.cidrecepcion = dbo.TRECEPCIONDFM.cidrecepcion AND dbo.TRECEPCIONDFD.cnfacturapro = dbo.TRECEPCIONDFM.cnfacturapro AND";
                            _Str_Cadena += " dbo.TRECEPCIONDFD.cproveedor = dbo.TRECEPCIONDFM.cproveedor";
                            _Str_Cadena += " where ccopiaoc= " + _P_Str_OC + " GROUP BY dbo.TRECEPCIONDFM.cnfacturapro, ctotmontsimp;";

                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow oFila in _Ds.Tables[0].Rows)
                                {
                                    _Ob[0] = oFila["cnfacturapro"].ToString();
                                    _Ob[1] = Convert.ToInt32(oFila["cempaques"].ToString()).ToString("#,##");
                                    _Ob[2] = Convert.ToInt32(oFila["cunidades"].ToString()).ToString("#,##");
                                    _Ob[3] = Convert.ToDouble(oFila["ctotmontsimp"].ToString()).ToString("#,##0.00");
                                    _Dg_Grid_Detalle.Rows.Add(_Ob);
                                }
                            }
                        }
                    }
                }

                _Mtd_Efectividad(_P_Str_OC);
            }
            else
            {
                _Dbl_EmpaquesFacEntreOC = 0;
                _Str_Cadena = "SELECT SUM(TRECEPCIONDFD.cempaques), SUM(TRECEPCIONDFD.cprecioxpro),TRECEPCIONRELDIF.cnfacturapro " +
"FROM TRECEPCIONDFD INNER JOIN " +
"TRECEPCIONRELDIF ON TRECEPCIONDFD.cgroupcomp = TRECEPCIONRELDIF.cgroupcomp AND " +
"TRECEPCIONDFD.cidrecepcion = TRECEPCIONRELDIF.cidrecepcion AND " +
"TRECEPCIONDFD.cnfacturapro = dbo.TRECEPCIONRELDIF.cnfacturapro " +
"WHERE  (TRECEPCIONDFD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRECEPCIONDFD.cidrecepcion = '" + _P_Str_Recepcion + "') AND (TRECEPCIONDFD.cproveedor = '" + _P_Str_Proveedor + "') AND " +
"(TRECEPCIONRELDIF.cnumoc = '" + _P_Str_OC + "') " +
"GROUP BY TRECEPCIONRELDIF.cnumoc, TRECEPCIONRELDIF.cnfacturapro";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    object[] _Ob = new object[3];
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Dbl_Monto = Convert.ToDouble(_Row[1].ToString());
                        _Dbl_EmpaquesFacEntreOC = _Dbl_EmpaquesFacEntreOC + Convert.ToDouble(_Row[0].ToString());
                        _Ob[0] = _Row[2].ToString();
                        _Ob[1] = _Row[0].ToString();
                        _Ob[2] = _Dbl_Monto.ToString("#,##0.00");
                        _Dg_Grid_Detalle.Rows.Add(_Ob);
                    }
                }

                _Mtd_Efectividad(_P_Str_OC);
            }

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
    }
}