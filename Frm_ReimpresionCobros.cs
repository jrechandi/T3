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
    public partial class Frm_ReimpresionCobros : Form
    {
        public Frm_ReimpresionCobros()
        {
            InitializeComponent();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }

        private void _Bt_Caja_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }
        private void _Mtd_Busqueda()
        {
            try
            {
                _Er_Error.Dispose();
                if (_Txt_Caja.Text.Trim().Length > 0)
                {
                    string _Str_SQL = "SELECT CIDRELACOBRO AS [Id Relación], CIDRELACOBROWEB AS [Id Pre-Relación],CONVERT(VARCHAR,CFECHARELA,103) AS Fecha, CASE WHEN CCOBROOFICINA=1 THEN 'COBRO CAMIÓN' ELSE 'WEB' END AS [Tipo Relación] FROM TRELACCOBM WHERE CAPROBADO='1' AND CCAJA='" + _Txt_Caja.Text + "' AND CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    DataSet _Ds_DataSet= Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    _Dg_Grid.Columns.Clear();
                    _Dg_Grid.DataSource = _Ds_DataSet.Tables[0];
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Dg_Grid.ReadOnly = true;
                    //Cargamos la Columna de Boton
                    var _Btn_BotonVerificar = new DataGridViewButtonColumn();
                    _Btn_BotonVerificar.HeaderText = "";
                    _Btn_BotonVerificar.Name = "_Btn_Imprimir";
                    _Btn_BotonVerificar.DefaultCellStyle.Font = new Font("Verdana", 7);
                    _Btn_BotonVerificar.Text = "Imprimir";
                    _Btn_BotonVerificar.UseColumnTextForButtonValue = true;
                    _Btn_BotonVerificar.Width = 450;
                    _Dg_Grid.Columns.Add(_Btn_BotonVerificar);
                }
                else
                { _Er_Error.SetError(_Txt_Caja, "Información requerida!!!"); }
            }
            catch
            {
            }
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             _Er_Error.Dispose();
             if (e.RowIndex != -1)
             {
                 if (e.ColumnIndex ==4)
                 {
                     string _Str_Relacion = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value);
                     string _Str_PreRelacion = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value);
                     string _Str_TipoRelacion= Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value);
                     if (_Str_TipoRelacion == "COBRO CAMIÓN")
                     {
                         Cursor = Cursors.WaitCursor;
                         Frm_ReporteRelacionCobro _Frm_Form = new Frm_ReporteRelacionCobro(Frm_Padre._Str_GroupComp, Frm_Padre._Str_Comp, "0", _Str_Relacion, false);
                         _Frm_Form.ShowDialog();
                         Cursor = Cursors.Default;
                     }
                     else
                     {
                         if (_Str_PreRelacion.Trim().Length == 0)
                         {
                             _Str_PreRelacion = _Str_Relacion;
                         }
                         string _Str_Url = CLASES._Cls_Conexion._G_Str_Url_RelacionesCobranzaLocal.Replace("mrelacionaprob.aspx", "Resumen_Relacion.aspx") + "?crelacion=" + _Str_PreRelacion + "&compania=" + Frm_Padre._Str_Comp.Trim();
                         var _Frm = new Frm_Navegador(_Str_Url, true, true) { Dock = DockStyle.Fill, Width = Width, Height = (Height + 50) };
                         _Frm.ShowDialog();
                     }
                 }
             }
        }
    }
}
