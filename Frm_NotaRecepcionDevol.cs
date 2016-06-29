using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_NotaRecepcionDevol : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_NotaRecepcionDevol()
        {
            InitializeComponent();
            _Mtd_CargarConsulta();
        }
        private void _Mtd_CargarConsulta()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("N.R.");
            _Tsm_Menu[1] = new ToolStripMenuItem("T.Documento");
            _Tsm_Menu[2] = new ToolStripMenuItem("Documento");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidnotrecepc";
            _Str_Campos[1] = "cname";
            _Str_Campos[2] = "cnumdocu";
            string _Str_Cadena = "Select cidnotrecepc as [N.R.],ctipodocument_name as [T.Documento],cnumdocu as Documento,dbo.Fnc_Formatear(cmontosi) as Monto,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear((cmontosi)+cmontoimp) as Total from VST_NOTARECEPC_DEVOL where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cimpreso='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Notas de Recepción", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_CargarData(string _Pr_Str_NR)
        {
            double _Dbl_MontoSimp=0, _Dbl_MontoImp=0, _Dbl_Total=0;
            string _Str_Sql = "SELECT * FROM VST_NOTARECEPC_DEVOL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='"+_Pr_Str_NR+"'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_NR.Text = _Ds.Tables[0].Rows[0]["cidnotrecepc"].ToString();
                _Txt_FechNR.Text =Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechanotrecep"]).ToShortDateString();
                _Txt_TipoDocument.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument"]);
                _Txt_TipoDocument.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument_name"]);
                _Txt_Document.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecep"]) == "A")
                { _Txt_TNR.Text = "Devolución de Mercancía"; }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecep"]) == "B")
                { _Txt_TNR.Text = "Devolución de Mercancía mal estado"; }
                else if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecep"]) == "C")
                { _Txt_TNR.Text = "Recepción de Mercancía a Proveedores"; }
                else
                {
                    _Txt_TNR.Text = "";
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontosi"]).Length>0)
                {
                    _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosi"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontoimp"]).Length>0)
                {
                    _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontoimp"]);
                }
                _Dbl_Total =_Dbl_MontoSimp+ _Dbl_MontoImp;
                _Txt_Monto.Text = _Dbl_MontoSimp.ToString("#,##0.00");
                _Txt_Impuesto.Text = _Dbl_MontoImp.ToString("#,##0.00");
                _Txt_Total.Text = _Dbl_Total.ToString("#,##0.00");
                _Mtd_CargarDetalle(_Pr_Str_NR);
            }
        }
        private void _Mtd_CargarDetalle(string _Pr_Str_NR)
        {
            string _Str_Sql = "SELECT cproducto,(produc_descrip+'.'+produc_descrip_2) AS descripcion,cempaques,cunidades,dbo.Fnc_Formatear(cmontosi) AS Monto,dbo.Fnc_Formatear(cmontoimp) as Impuesto,dbo.Fnc_Formatear(cmontosi+cmontoimp) as Total FROM VST_NOTARECEPDPRODUCTOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='"+_Pr_Str_NR+"'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_CargarData(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                _Tb_Tab.SelectTab(1);
                this.Cursor = Cursors.Default;
            }
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            string _Str_Cadena1 = "Esta seguro de imprimir la NR# " + _Txt_NR.Text.Trim();
            string _Str_Cadena2 = "Faltan datos para la impresión";
            _Lbl_Texto.Text = "¿Esta seguro de imprimir la NR?";
            if (_Dg_Detalle.Rows.Count > 0)
            {
                if (MessageBox.Show(_Str_Cadena1, "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Pnl_Clave.Parent = this;
                    _Pnl_Clave.Visible = true;
                    _Pnl_Clave.BringToFront();
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show(_Str_Cadena2, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text))
            {
                _Mtd_ImprimirNR();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }
        private void _Mtd_ImprimirNR()
        {
            try
            {
                string _Str_Cadena = "select cimpreso,cidcomprob from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Txt_NR.Text + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        PrintDialog _Print = new PrintDialog();
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave.Text = "";
                            Cursor = Cursors.WaitCursor;
                            REPORTESS _Frm = new REPORTESS(new string[] { "VST_RPT_NOTARECEP_DEVOL" }, "", "T3.Report.rNotaRecep_Devol", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotrecepc='" + _Txt_NR.Text + "'", _Print, true);
                            _Frm.MdiParent = this.MdiParent;
                            //_Frm.Show();
                            Cursor = Cursors.Default;
                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTARECEPC", "cimpreso='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Txt_NR.Text + "'");
                            _Str_Cadena = "UPDATE TDEVVENTAM SET cimprimenr=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='"+_Txt_NR.Text+"'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            this.Close();
                        }
                        else
                        {
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("La NR ya fue impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                    }
                }
            }
            catch (Exception _Ex) 
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Txt_Clave.Text = "";
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private void Frm_NotaRecepcionDevol_Load(object sender, EventArgs e)
        {

        }
    }
}